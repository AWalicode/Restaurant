using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using OrderApp.DishService;

namespace OrderApp
{
    /*
     * Formularz z menu i zamówieniem
     */
    public partial class OrderForm : Form
    {
        public DishServiceClient Client;
        public Order Order;

        public OrderForm()
        {
            InitializeComponent();
            Order = new Order(new List<DishWithAddition>());
        }

        /*
         *
         * Konwertuje dane przychodzące z serwisu na List<DishGroup>
         * Generuje menu
         * @param {Object} sender - objekt wywołujący zdarzenie
         * @param {EventArgs} e - Event
         * @return void
         * @return void
         */
        private void OrderForm_Load(object sender, EventArgs e)
        {
            Client = new DishServiceClient();
            var dishGroups = new List<DishGroup>();
            foreach (var dg in Client.GetAllGroupedDishes()) dishGroups.Add(new DishGroup(dg));
            menuTableLayout.ColumnCount = 3;
            menuTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            menuTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            menuTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));

            orderTableLayout.ColumnCount = 3;
            orderTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            orderTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            orderTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));

            foreach (var dg in dishGroups)
            {
                AddNewRowToMenu(dg.Name, null, null);
                foreach (var dish in dg.Meals)
                {
                    var addOrderButton = new ButtonWithData();
                    addOrderButton.Text = "Dodaj: " + dish.Price + "zł";
                    addOrderButton.Click += AddOrder_BtnClick;
                    addOrderButton.Dish = dish;
                    addOrderButton.GroupName = dg.Name;
                    addOrderButton.Additions = dg.Additions.ToList();
                    AddNewRowToMenu(dish.Name, dish.Description, addOrderButton);
                }
            }
        }

        /*
        * Dodaje wiersz do menu
        * @param {string} name - nazwa dania lub grupy
        * @param {string} [descriprion] - opis dania
        * @param {Button} [button] - Przycis dodający danie do zamówienia
        * @return void
        */
        public void AddNewRowToMenu(string name, string description, Button button)
        {
            var label = new Label();
            menuTableLayout.RowCount++;
            menuTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            label.Text = name;
            label.TextAlign = ContentAlignment.MiddleLeft;
            label.AutoSize = true;
            menuTableLayout.Controls.Add(label);
            if (button == null)
            {
                menuTableLayout.Controls.Add(new Label());
                menuTableLayout.Controls.Add(new Label());
                label.Font = new Font(label.Font, FontStyle.Bold);
            }
            else
            {
                menuTableLayout.Controls.Add(new Label {Text = description, AutoSize = true});
                menuTableLayout.Controls.Add(button);
            }
        }

        /*
        * Dodaje wiersz do zamówienia
        * @param {int} id - identyfikator dania z zamówienia
        * @return void
        */
        public void AddNewRowToOrder(int id)
        {
            var dwa = Order.DishWithAdditionses.ElementAt(id);
            var label = new Label();
            orderTableLayout.RowCount++;
            orderTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50));
            var dishName = dwa.Name.Trim() + "( ";
            foreach (var add in dwa.GetAdditions()) dishName += add.Name.Trim() + ", ";

            dishName += " )";
            label.Text = dishName;
            label.TextAlign = ContentAlignment.MiddleLeft;
            label.AutoSize = true;
            orderTableLayout.Controls.Add(label);
            orderTableLayout.Controls.Add(new Label {Text = dwa.Price.ToString().Trim() + "zł"});
            var removeDishButton = new ButtonWithData();
            removeDishButton.Text = "Usuń";
            removeDishButton.Click += RemoveDish_BtnClick;
            removeDishButton.Id = id;
            orderTableLayout.Controls.Add(removeDishButton);
        }


        /*
        * Dodaje danie do listy z zamówieniem
        * @param {int} id - identyfikator dania z zamówienia
        * @return void
        */
        public void AddDishToOrderList(int id)
        {
            AddNewRowToOrder(id);
            sendOrder.Enabled = true;
            sendOrder.Text = "Zamów:" + Order.GetPrice() + "zł";
        }

        /*
        * Handler obsługujący zdarzenie kliknięcia w przycisk dodający pozycje do zamówienia
        * Otwiera Addform
        * @param {Object} sender - objekt wywołujący zdarzenie
        * @param {EventArgs} e - Event
        * @return void
        */
        private void AddOrder_BtnClick(object sender, EventArgs e)
        {
            var btn = (ButtonWithData) sender;
            var addForm = new AddForm(btn.Dish, btn.Additions, btn.GroupName, this);
            addForm.Show();
        }


        /*
        * Handler obsługujący zdarzenie kliknięcia w przycisk usuwający danie z zamówienia
        * @param {Object} sender - objekt wywołujący zdarzenie
        * @param {EventArgs} e - Event
        * @return void
        */
        private void RemoveDish_BtnClick(object sender, EventArgs e)
        {
            var btn = (ButtonWithData) sender;
            Order.DishWithAdditionses.RemoveAt(btn.Id);
            orderTableLayout.Controls.Clear();
            var id = 0;
            foreach (var dwa in Order.DishWithAdditionses)
            {
                AddNewRowToOrder(id);
                id++;
            }

            sendOrder.Text = "Zamów:" + Order.GetPrice() + "zł";
            if (Order.DishWithAdditionses.Count == 0) sendOrder.Enabled = false;
        }


        /*
        * Handler obsługujący zdarzenie kliknięcia w przycisk wysyłający zamówienie
        * Wysyła zamówienie
        * @param {Object} sender - objekt wywołujący zdarzenie
        * @param {EventArgs} e - Event
        * @return void
        */
        private void sendOrder_Click(object sender, EventArgs e)
        {
            var ord = new DishService.Order();
            ord.Email = emailBox.Text;
            ord.Comment = note.Text;
            ord.DishWithAdditionses = new List<DishService.DishWithAddition>();
            foreach (var dwa in Order.DishWithAdditionses)
            {
                var dishServiceDwa = new DishService.DishWithAddition();
                dishServiceDwa.Id = dwa.Id;
                dishServiceDwa.Price = dwa.Price;
                dishServiceDwa.Description = dwa.Description;
                dishServiceDwa.DishGroupId = dwa.DishGroupId;
                dishServiceDwa.Name = dwa.Name;
                dishServiceDwa.Additions = new List<DishService.Addition>();
                foreach (var add in dwa.GetAdditions())
                {
                    var a = new DishService.Addition();
                    a.Price = add.Price;
                    a.Name = add.Name;
                    a.DishGroupId = add.DishGroupId;
                    a.Id = add.Id;
                    dishServiceDwa.Additions.Add(a);
                }

                ord.DishWithAdditionses.Add(dishServiceDwa);
            }

            if (Client.SubmitOrder(ord))
                MessageBox.Show("Złożono zamówienie");
            else
                MessageBox.Show("Nie udało się złożyć zamówienia");
        }


        /*
        * Handler obsługujący zdarzenie kliknięcia w przycisk otwierający formularz
        * z historią zamówień
        * Wysyła zamówienie
        * @param {Object} sender - objekt wywołujący zdarzenie
        * @param {EventArgs} e - Event
        * @return void
        */
        private void historyOrderButton_Click(object sender, EventArgs e)
        {
            var window = new OrderHistoryForm();
            window.Show();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
        }
    }
}