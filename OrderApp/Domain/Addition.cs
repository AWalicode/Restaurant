using System;
using OrderApp.DishService;

namespace OrderApp
{
    /*
     *
     * Dodatek do dania
     */
    public class Addition
    {
        public Addition(OrderApp.DishService.Addition add)
        {
            Name = add.Name;
            Id = add.Id;
            Price = add.Price;
            DishGroupId = add.DishGroupId;
        }

        public Addition(int id, string name, double price, int dishGroupId)
        {
            Name = name;
            Id = id;
            Price = price;
            DishGroupId = dishGroupId;
        }

        /*
         * Nazwa dodatku
         */
        public string Name { get; set; }


        /*
         * Identyfikator dodatku
         */
        public int Id { get; set; }


        /*
         * Cena dodatku
         */
        public double Price { get; set; }


        /*
         * Identyfikator grupy do której należy danie
         */
        public int DishGroupId { get; set; }
    }
}
