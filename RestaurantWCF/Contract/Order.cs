using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Wostal.WCF.Restaurant.Contract
{
    /*
     * Zamówienie
     *
     */
    [DataContract]
    public class Order
    {
        public Order()
        {
        }

        public Order(int id, string email, string comment, DateTime dt, List<DishWithAddition> dishWithAdditions)
        {
            Id = id;
            Email = email;
            Comment = comment;
            Date = dt.ToString();
            DishWithAdditionses = dishWithAdditions;
        }

        /*
         * Lista dań z dodatkami
         *
         */
        [DataMember] public List<DishWithAddition> DishWithAdditionses { get; set; }


        /*
         * Email składającego zamówienie
         *
         */
        [DataMember] public string Email { get; set; }


        /*
         * Data zamówienia
         *
         */
        [DataMember] public string Date { get; set; }


        /*
         * Komentarz do zamówienia
         *
         */
        [DataMember] public string Comment { get; set; }


        /*
         * Identyfikator zamówienia
         *
         */
        [DataMember] public int Id { get; set; }
    }
}