using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderApp
{
    /*
     * CheckBox rozszerzony o dane
     */
    class CheckBoxWithData : CheckBox
    {
        /*
         * Dodatek
         */
        public Addition Addition { get; set; }
    }
}
