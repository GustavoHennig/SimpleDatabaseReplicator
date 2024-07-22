using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDatabaseReplicator.UI
{
    class Dialogs
    {
        public static string InputBox(string Caption, string default_value)
        {

            InputBox ib = new InputBox();
            ib.Text = Caption;
            ib.Texto = default_value;
            ib.ShowDialog();
            return ib.Texto;

        }

        public static string InputBox(string Caption)
        {

            return InputBox(Caption, "");

        }
    }
}
