using System.Collections.Generic;

namespace OrderApp
{
    /*
     * Danie z dodatkami
     *
     */
    public class DishWithAddition : Dish
    {

        public DishWithAddition(Dish dish, List<Addition> list)
        {
            Name = dish.Name;
            Id = dish.Id;
            Price = dish.Price;
            Description = dish.Description;
            DishGroupId = dish.DishGroupId;
            Additions = list;
        }

        public DishWithAddition(DishService.DishWithAddition dish)
        {
            Name = dish.Name;
            Id = dish.Id;
            Price = dish.Price;
            Description = dish.Description;
            DishGroupId = dish.DishGroupId;
            Additions = new List<Addition>();
            foreach (DishService.Addition add in dish.Additions)
            {
                Additions.Add(new Addition(add));
            }
        }


        /*
          * Dodaje dodatek do dania  aktualizuje cene
          * @param {Addition} add - Dodatek do dania
          * @return void;
          */
        public void Add(Addition add)
        {
            Additions.Add(add);
            Price += add.Price;
        }


        /*
         * Usuwa dodatek i aktualizuje cene
         * @param {Addition} add - Dodatek do dania
         * @return void;
         */
        public void Remove(Addition add)
        {
            Additions.Remove(add);
            Price -= add.Price;
        }

        /*
         * Lista dodatków
         *
         */
        private List<Addition> Additions { get; set; }

        /*
         * Zwraca listę dodatków
         *
         */
        public List<Addition> GetAdditions()
        {
            return this.Additions;
        }
    }
}
