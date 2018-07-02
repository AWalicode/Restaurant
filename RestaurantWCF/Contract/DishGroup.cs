using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Wostal.WCF.Restaurant.Contract
{
    /*
     * Grupa potraw do której nalerzą dodatki oraz dania
     *
     */
    [DataContract]
    public class DishGroup : IEquatable<DishGroup>
    {
        public DishGroup(int id, string name, List<Dish> meals, List<Addition> additions)
        {
            Name = name;
            Id = id;
            Meals = meals;
            Additions = additions;
        }


        /*
         * Nazwa grupy np.: 'Dania główne'
         *
         */
        [DataMember] public string Name { get; set; }


        /*
         * Identyfikator grupy
         *
         */
        [DataMember] public int Id { get; set; }


        /*
         * Lista dań należących do grupy
         *
         */
        [DataMember] public List<Dish> Meals { get; set; }


        /*
         * Lista dodatków należących do grupy
         *
         */
        [DataMember] public List<Addition> Additions { get; set; }


        /*
         * Porównuje dwie grupy. Potrzebne dla IEquatable<DishGroup>
         * @param {DishGroup} other - grupa do porównania
         * @return bool
         *
         */
        public bool Equals(DishGroup other)
        {
            if (other == null) return false;
            return Id.Equals(other.Id);
        }
    }
}