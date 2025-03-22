using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SimpleDatabaseReplicator.DataObjects
{
    public class TableRowComparator
    {

        public static bool Compare(TableRow tableRow1, TableRow tableRow2, bool markDifferentCells)
        {
            if (tableRow1 == null && tableRow2 == null)
            {
                return true;
            }
            else if (tableRow1 == null || tableRow2 == null)
            {
                return false;
            }


            try
            {
                bool same = true;


                foreach (string k in tableRow1.Data.Keys)
                {
                    if (tableRow2.Data.ContainsKey(k))
                    {
                        if (!ObjectComparison.EquivalentValue(tableRow1.Data[k].Value, tableRow2.Data[k].Value))
                        {
                            if (markDifferentCells)
                            {
                                tableRow1.Data[k].IsDifferent = true;
                                tableRow2.Data[k].IsDifferent = true;
                                same = false;
                                // dot not stop when comparing, all cell must be checked
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                    else
                    {
                        return false;//TODO: Schema is different
                    }
                }
                return same;
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
                return false;
            }

        }
    }
}
