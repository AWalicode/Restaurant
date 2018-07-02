using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using OrderApp.DishService;

namespace OrderApp
{
    /*
     *
     * Formularz z historią zamówień
     */
    public partial class OrderHistoryForm : Form
    {
        public OrderHistoryForm()
        {
            InitializeComponent();
        }


        /*
         * Konwertuje dane przychodzące z serwisu na List<order>
         * Generuje wiersze do tabeli z zamówieniami
         * @return void
         */
        private void OrderHistory_Load(object sender, EventArgs e)
        {
            var client = new DishServiceClient();
            var orders = new List<Order>();
            foreach (var order in client.GetAllOrderHistory()) orders.Add(new Order(order));
            foreach (var order in orders) AddNewRowToOrderHistory(order);
        }


        /*
         * Dodaje wiersz do tabeli na podstawie zamówienia
         * @param {Order} order - zamówienie
         * @return void
         */
        public void AddNewRowToOrderHistory(Order order)
        {
            var label = new Label();
            historyTableLayout.RowCount++;
            historyTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50));
            var orderInfo = order.Email.Trim() + ", " + order.Comment.Trim() + ", " + order.Date;
            label.Text = orderInfo;
            label.TextAlign = ContentAlignment.MiddleLeft;
            label.AutoSize = true;
            historyTableLayout.Controls.Add(label);
            var orderMeals = "";
            foreach (var dwa in order.DishWithAdditionses)
            {
                orderMeals += dwa.Name.Trim() + "( ";
                foreach (var add in dwa.GetAdditions()) orderMeals += add.Name.Trim() + "; ";

                orderMeals += " ) ";
            }

            historyTableLayout.Controls.Add(new Label {Text = orderMeals, AutoSize = true});
            historyTableLayout.Controls.Add(new Label {Text = order.GetPrice().ToString().Trim() + "zł"});
        }
    }
}