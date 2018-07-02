using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using NLog;
using Wostal.WCF.Restaurant.Config;
using Wostal.WCF.Restaurant.Contract;
using Wostal.WCF.Restaurant.Repository;

namespace Wostal.WCF.Restaurant
{
    /*
     * Main service
     */
    public class DishService : IDishService
    {
        public List<DishGroup> GetAllGroupedDishes()
        {
            return new DishRepository().GetAllGroupedDishes();
        }


        public bool SubmitOrder(Order order)
        {
            var logger = LogManager.GetCurrentClassLogger();
            var settings = new Setting();
            var dbAddress = settings.DbAddress;
            OrderRepository orderRepository = new OrderRepository();

            if (order.Email == null) return false;
            using (var sqlConnection = new SqlConnection(dbAddress))
            {
                orderRepository.InsertOrder(order.Comment, order.Email);

                foreach (var dishWithAddition in order.DishWithAdditionses)
                {
                    orderRepository.InsertDishToNewOrder(dishWithAddition.Id);

                    foreach (var addition in dishWithAddition.Additions)
                    {
                        orderRepository.InsertAdditionToNewDish(addition.Id);
                    }
                }
            }

            /*
             * Send email to client
             */
            var client = new SmtpClient(settings.EmailHost, settings.EmailPort)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(settings.EmailUsername,
                    settings.EmailPassword)
            };
            var orderInfo = order.Email.Trim() + ", " + order.Comment.Trim() + ", " + order.Date;
            orderInfo += "---------";
            foreach (var dishWithAddition in order.DishWithAdditionses)
            {
                orderInfo += dishWithAddition.Name.Trim() + "( ";
                foreach (var add in dishWithAddition.Additions) orderInfo += add.Name.Trim() + "; ";
                orderInfo += " ) ";
            }

            try
            {
                client.Send(settings.EmailUsername, order.Email.Trim(), "Zamówienie",
                    orderInfo);
                return true;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return true;
            }
        }


        /*
         *
         * Get Order History
         * @return List<Order>
         */
        public List<Order> GetAllOrderHistory()
        {
            return new OrderRepository().GetAllOrderHistory();
        }
    }
}