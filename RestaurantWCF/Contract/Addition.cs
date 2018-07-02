using System;
using System.Runtime.Serialization;

namespace Wostal.WCF.Restaurant.Contract
{
    /*
     *
     * Dodatek do dania
     */
    [DataContract]
    public class Addition : IEquatable<Addition>
    {
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
        [DataMember] public string Name { get; set; }


        /*
         * Identyfikator dodatku
         */
        [DataMember] public int Id { get; set; }


        /*
         * Cena dodatku
         */
        [DataMember] public double Price { get; set; }


        /*
         * Identyfikator grupy do której należy danie
         */
        [DataMember] public int DishGroupId { get; set; }


        /*
         * Porównuje dwa dodatki. Potrzebne dla IEquatable<Addition>
         * @param {Addition} other - dodatek do porównania
         * @return bool
         *
         */
        public bool Equals(Addition other)
        {
            if (other == null) return false;
            return Id.Equals(other.Id);
        }
    }
}