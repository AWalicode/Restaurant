using System.Collections.Generic;
using System.Windows.Forms;

namespace OrderApp
{
    /*
     * Przycisk rozszerzony o dane
     */
    class ButtonWithData : Button
    {
        /*
         * Lista dodatków
         */
        public List<Addition> Additions { get; set; }

        /*
         * Danie
         */
        public Dish Dish { get; set; }

        /*
         * Nazwa grupy
         */
        public string GroupName { get; set; }

        /*
         * Identyfikator dania z zamówienia
         */
        public int Id { get; set; }
    }
}
