namespace OrderApp
{
    /*
     * Danie
     */
    public class Dish
    {
        public Dish()
        {
        }

        public Dish(OrderApp.DishService.Dish dish)
        {
            Name = dish.Name;
            Id = dish.Id;
            Price = dish.Price;
            Description = dish.Description;
            DishGroupId = dish.DishGroupId;
        }

        public Dish(int id, string name, double price, string description, int dishGroupId)
        {
            Name = name;
            Id = id;
            Price = price;
            Description = description;
            DishGroupId = dishGroupId;
        }

        /*
         * Nazwa dania
         */
        public string Name { get; set; }


        /*
         * Identyfikator dania
         */
        public int Id { get; set; }


        /*
         * Cena dania
         */
        public double Price { get; set; }


        /*
         * Opis dania
         */
        public string Description { get; set; }


        /*
         * Identyfikator grupy do której należy danie
         */
        public int DishGroupId { get; set; }

    }
}