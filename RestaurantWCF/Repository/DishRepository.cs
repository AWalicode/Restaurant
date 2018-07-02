using System.Collections.Generic;
using System.Data.SqlClient;
using Wostal.WCF.Restaurant.Config;
using Wostal.WCF.Restaurant.Contract;

namespace Wostal.WCF.Restaurant.Repository
{
    public class DishRepository
    {
        private readonly SqlConnection sqlConnection;

        public DishRepository()
        {
            var settings = new Setting();
            sqlConnection = new SqlConnection(settings.DbAddress);
        }

        public List<DishGroup> GetAllGroupedDishes()
        {
            var dishGroups = new List<DishGroup>();
            List<Addition> additions = GetAllAdditions();
            sqlConnection.Open();

            /*
             * Get information about groups and dishes
             */
            using (var sqlCommand = new SqlCommand(
                "SELECT d.dishId, d.name, d.price, d.description, d.dishGroupId, g.name AS gName FROM dishGroup AS g " +
                "INNER JOIN dish AS d ON g.dishGroupId = d.dishGroupId;", sqlConnection))
            {
                var reader = sqlCommand.ExecuteReader();
                try
                {
                    while (reader.Read())
                        if (!dishGroups.Exists(dishGroup => dishGroup.Id == (int) reader["dishGroupId"]))
                        {
                            var dg = new DishGroup((int) reader["dishGroupId"], (string) reader["gName"],
                                new List<Dish>(), new List<Addition>());
                            dg?.Meals?.Add(new Dish((int) reader["dishId"], (string) reader["name"],
                                (double) reader["price"],
                                (string) reader["description"], (int) reader["dishGroupId"]));
                            dishGroups.Add(dg);
                        }
                        else
                        {
                            var dg = dishGroups.Find(x => x.Id == (int) reader["dishGroupId"]);
                            dg?.Meals?.Add(new Dish((int) reader["dishId"], (string) reader["name"],
                                (double) reader["price"],
                                (string) reader["description"], (int) reader["dishGroupId"]));
                        }
                }
                finally
                {
                    reader.Close();
                }
            }
            foreach (var addition in additions)
            {
                var dg = dishGroups.Find(x => x.Id == addition.DishGroupId);
                dg?.Additions?.Add(addition);
            }
            sqlConnection.Close();
            return dishGroups;
        }


        public List<Addition> GetAllAdditions()
        {
            sqlConnection.Open();
            var additions = new List<Addition>();
            using (var sqlCommand =
                new SqlCommand("SELECT additionId, name, price, dishGroupId FROM addition", sqlConnection))
            {
                var reader = sqlCommand.ExecuteReader();
                try
                {
                    while (reader.Read())
                        additions.Add(new Addition((int) reader["additionId"], (string) reader["name"],
                            (double) reader["price"], (int) reader["dishGroupId"]));
                }
                finally
                {
                    reader.Close();
                }
            }
            sqlConnection.Close();
            return additions;
        }

        public List<Dish> GetAllDishes()
        {
            sqlConnection.Open();
            List<Dish> dishes = new List<Dish>();
            using (var sqlCommand = new SqlCommand("SELECT dishId, name, price, description, dishGroupId FROM dish",
                sqlConnection))
            {
                var reader = sqlCommand.ExecuteReader();
                try
                {
                    while (reader.Read())
                        dishes.Add(new Dish((int)reader["dishId"], (string)reader["name"], (double)reader["price"],
                            (string)reader["description"],
                            (int)reader["dishGroupId"]));
                }
                finally
                {
                    reader.Close();
                }
            }
            sqlConnection.Close();
            return dishes;
        }
    }
}