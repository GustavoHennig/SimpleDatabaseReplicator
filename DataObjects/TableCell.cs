using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDatabaseReplicator.DataObjects
{
    public class TableCell
    {
        public TableCell(object value)
        {
            Value = value;
        }

        public bool IsDifferent { get; set; }
        public object Value { get; set; }
    }
}
