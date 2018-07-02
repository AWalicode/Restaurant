using System.Collections.Generic;

namespace OrderApp
{
    /*
     * Zamówienie
     *
     */
    public class Order
    {
        public Order(List<DishWithAddition> dishWithAdditionses)
        {
            DishWithAdditionses = dishWithAdditionses;
        }

        public Order(DishService.Order order)
        {
            Email = order.Email;
            Comment = order.Comment;
            Date = order.Date;
            DishWithAdditionses = new List<DishWithAddition>();
            foreach (DishService.DishWithAddition dwa in order.DishWithAdditionses)
            {
                DishWithAdditionses.Add(new DishWithAddition(dwa));
            }
        }

        /*
         * Zwraca cenne zamówienia
         * @return double
         */
        public double GetPrice()
        {
            double price = 0;
            foreach (DishWithAddition dwa in DishWithAdditionses)
            {
                price += dwa.Price;
            }

            return price;
        }

        /*
         * Lista dań z dodatkami
         *
         */
        public List<DishWithAddition> DishWithAdditionses { get; set; }


        /*
         * Email składającego zamówienie
         *
         */
        public string Email { get; set; }


        /*
         * Data zamówienia
         *
         */
        public string Date { get; set; }


        /*
         * Komentarz do zamówienia
         *
         */
        public string Comment { get; set; }

    }
}
