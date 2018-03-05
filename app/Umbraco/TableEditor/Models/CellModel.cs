using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiLocationMapTableEditor.Models
{
    public class CellModel
    {
        public string Value { get; set; }

        public const int LocationTitleColumnIndex = 0;
        public const int AddressColumnIndex = 1;
        public const int PhonenNumberColumnIndex = 2;
        public const int EmailColumnIndex = 3;
        public const int LatitudeColumnIndex = 4;
        public const int LongitudeColumnIndex = 5;
    }
}
