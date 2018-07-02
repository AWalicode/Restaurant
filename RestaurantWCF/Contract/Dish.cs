using System.Runtime.Serialization;

namespace Wostal.WCF.Restaurant.Contract
{
    /*
     * Danie
     */
    [DataContract]
    public class Dish
    {
        public Dish()
        {
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
        [DataMember] public string Name { get; set; }


        /*
         * Identyfikator dania
         */
        [DataMember] public int Id { get; set; }


        /*
         * Cena dania
         */
        [DataMember] public double Price { get; set; }


        /*
         * Opis dania
         */
        [DataMember] public string Description { get; set; }


        /*
         * Identyfikator grupy do której należy danie
         */
        [DataMember] public int DishGroupId { get; set; }
    }
}