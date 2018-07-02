using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Wostal.WCF.Restaurant.Config;
using Wostal.WCF.Restaurant.Contract;

namespace Wostal.WCF.Restaurant.Repository
{
    public class OrderRepository
    {
        private readonly SqlConnection sqlConnection;

        public OrderRepository()
        {
            var settings = new Setting();
            sqlConnection = new SqlConnection(settings.DbAddress);
        }

        public List<Order> GetAllOrdersWithoutMeals()
        {
            sqlConnection.Open();
            var orders = new List<Order>();
            using (var sqlCommand = new SqlCommand("SELECT orderFromClientId, email, note, date FROM orderFromClient",
                sqlConnection))
            {
                var reader = sqlCommand.ExecuteReader();
                try
                {
                    while (reader.Read())
                        orders.Add(new Order((int) reader["orderFromClientId"], (string) reader["email"],
                            (string) reader["note"],
                            (DateTime) reader["date"], new List<DishWithAddition>()));
                }
                finally
                {
                    reader.Close();
                }
            }
            sqlConnection.Close();
            return orders;
        }

        public List<Order> GetAllOrderHistory()
        {
            DishRepository dishRepository = new DishRepository();
            var meals = dishRepository.GetAllDishes();
            var additions = dishRepository.GetAllAdditions();
            var orders = GetAllOrdersWithoutMeals();
            sqlConnection.Open();
            using (var sqlCommand = new SqlCommand(
                "SELECT do.orderFromClientId, do.dishId, doa.additionId FROM dish_order AS do LEFT JOIN " +
                "dish_order_addition AS doa ON do.dish_orderId=doa.dish_orderId", sqlConnection))
            {
                var reader = sqlCommand.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        var order = orders.Find(element => element.Id == (int) reader["orderFromClientId"]);
                        var dishWithAddition =
                            order.DishWithAdditionses.FirstOrDefault(element => element.Id == (int) reader["dishId"]);
                        if (dishWithAddition == null)
                        {
                            dishWithAddition = new DishWithAddition(
                                meals.FirstOrDefault(element => element.Id == (int) reader["dishId"]),
                                new List<Addition>());
                            orders.Find(element => element.Id == (int) reader["orderFromClientId"])
                                .DishWithAdditionses
                                .Add(dishWithAddition);
                        }

                        if (!reader.IsDBNull(reader.GetOrdinal("additionId")))
                        {
                            var addit = additions?.Find(element => element.Id == (int) reader["additionId"]);
                            dishWithAddition.Add(addit);
                        }
                    }
                }
                finally
                {
                    reader.Close();
                }
            }
            sqlConnection.Close();
            return orders;
        }

        public bool InsertOrder(string comment, string email)
        {
            sqlConnection.Open();
            var query = "INSERT INTO orderFromClient (date, note, email) VALUES(GETDATE(), @comment, @email)";
            using (var command = new SqlCommand(query, sqlConnection))
            {
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@comment", comment);
                var result = command.ExecuteNonQuery();
                sqlConnection.Close();
                if (result <= 0) return false;
            }
            sqlConnection.Close();
            return true;
        }

        public bool InsertDishToNewOrder(int dishId)
        {
            sqlConnection.Open();
            var query =
                "INSERT INTO dish_order (dishId, orderFromClientId) VALUES(@dishId, (SELECT MAX(orderFromClientId) FROM orderFromClient))";
            using (var command = new SqlCommand(query, sqlConnection))
            {
                command.Parameters.AddWithValue("@dishId", dishId);
                var result = command.ExecuteNonQuery();
                sqlConnection.Close();
                if (result <= 0) return false;
            }
            sqlConnection.Close();
            return true;
        }

        public bool InsertAdditionToNewDish(int additionId)
        {
            sqlConnection.Open();
            var query =
                "INSERT INTO dish_order_addition (dish_orderId, additionId) VALUES((SELECT MAX(dish_orderId) FROM dish_order), @additionId)";
            using (var command = new SqlCommand(query, sqlConnection))
            {
                command.Parameters.AddWithValue("@additionId", additionId);
                var result = command.ExecuteNonQuery();
                sqlConnection.Close();
                if (result <= 0) return false;
            }
            sqlConnection.Close();
            return true;
        }
    }
}