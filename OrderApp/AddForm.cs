using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace OrderApp
{
    /*
     *
     * Formularz szczegółowymi informacjami o daniu dodawanym do zamówienia
     */
    public partial class AddForm : Form
    {
        private readonly List<Addition> Additions;
        private readonly List<CheckBox> CheckBoxesOfAdditions;
        private readonly DishWithAddition DishWithAddition;
        private readonly string GroupName;
        private readonly OrderForm Sender;

        public AddForm(Dish dish, List<Addition> additions, string groupName, OrderForm form)
        {
            DishWithAddition = new DishWithAddition(dish, new List<Addition>());
            Additions = additions;
            GroupName = groupName;
            CheckBoxesOfAdditions = new List<CheckBox>();
            Sender = form;
            InitializeComponent();
        }

        /*
         * 
         * Inicjalizuje formularz
         * @param {Object} sender - objekt wywołujący zdarzenie
         * @param {EventArgs} e - Event
         * @return void
         */
        private void AddForm_Load(object sender, EventArgs e)
        {
            nameLabel.Text = DishWithAddition.Name;
            descriptionLabel.Text = DishWithAddition.Description;
            groupLabel.Text = GroupName;
            addDishButton.Text = DishWithAddition.Price + "zł";
            foreach (var add in Additions) AddNewRowToAdditionsList(add);
        }

        /*
         * 
         * Dodaje wiersz do listy z dodatkami
         * @param {Addition} add - dodatek
         * @return void
         */
        public void AddNewRowToAdditionsList(Addition add)
        {
            var checkBox = new CheckBoxWithData();
            additionsTableLayout.RowCount++;
            additionsTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            checkBox.Text = add.Name;
            checkBox.TextAlign = ContentAlignment.MiddleLeft;
            checkBox.AutoSize = true;
            checkBox.Addition = add;
            checkBox.Click += CheckBox_click;
            additionsTableLayout.Controls.Add(checkBox);
            CheckBoxesOfAdditions.Add(checkBox);
            additionsTableLayout.Controls.Add(new Label {Text = "Cena: " + add.Price + "zł"});
        }


        /*
        * Handler obsługujący zdarzenie kliknięcia w checkbox z dodatkiem
        * @param {Object} sender - objekt wywołujący zdarzenie
        * @param {EventArgs} e - Event
        * @return void
        */
        private void CheckBox_click(object sender, EventArgs e)
        {
            var cbwd = (CheckBoxWithData) sender;
            if (!cbwd.Checked)
                DishWithAddition.Remove(cbwd.Addition);
            else
                DishWithAddition.Add(cbwd.Addition);
            addDishButton.Text = DishWithAddition.Price + "zł";
        }

        /*
        * Handler obsługujący zdarzenie kliknięcia w przycisk dodający danie z dodatkami do zamówienia
        * Zamyka formularz
        * @param {Object} sender - objekt wywołujący zdarzenie
        * @param {EventArgs} e - Event
        * @return void
        */
        private void addDishButton_Click(object sender, EventArgs e)
        {
            Sender.Order.DishWithAdditionses.Add(DishWithAddition);
            Sender.AddDishToOrderList(Sender.Order.DishWithAdditionses.Count - 1);
            Close();
        }
    }
}