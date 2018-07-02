using System;
using System.Collections.Generic;

namespace OrderApp
{
    /*
     * Grupa potraw do której nalerzą dodatki oraz dania
     *
     */
    public class DishGroup
    {
        public DishGroup(DishService.DishGroup dg)
        {
            Name = dg.Name;
            Id = dg.Id;
            Meals = new List<Dish>();
            foreach (DishService.Dish dish in dg.Meals)
            {
                Meals.Add(new Dish(dish));
            }

            Additions = new List<Addition>();
            foreach (DishService.Addition add in dg.Additions)
            {
                Additions.Add(new Addition(add));
            }
        }

        /*
         * Nazwa grupy np.: 'Dania główne'
         *
         */
        public string Name { get; set; }


        /*
         * Identyfikator grupy
         *
         */
        public int Id { get; set; }


        /*
         * Lista dań należących do grupy
         *
         */
        public List<Dish> Meals { get; set; }


        /*
         * Lista dodatków należących do grupy
         *
         */
        public List<Addition> Additions { get; set; }
    }
}