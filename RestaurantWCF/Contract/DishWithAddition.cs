using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Wostal.WCF.Restaurant.Contract
{
    /*
     * Danie z dodatkami
     *
     */
    [DataContract]
    public class DishWithAddition : Dish
    {
        public DishWithAddition(int id, string name, double price, string description, int dishGroupId,
            List<Addition> additions) : base(id, name, price, description, dishGroupId)
        {
            foreach (var add in additions) Additions.Add(add);
        }

        public DishWithAddition(Dish dish, List<Addition> additions)
        {
            Name = dish.Name;
            Id = dish.Id;
            Price = dish.Price;
            Description = dish.Description;
            DishGroupId = dish.DishGroupId;
            Additions = additions;
            foreach (var add in additions) Additions.Add(add);
        }


        /*
         * Lista dodatków
         *
         */
        [DataMember] public List<Addition> Additions { get; set; }


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
    }
}