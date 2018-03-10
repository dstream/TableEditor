using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiLocationMapTableEditor.Models
{
    public class TableEditorModel
    {
        /*
        {
            showLocationTitle: true,
            showAddress: true,
            showPhoneNumber: true,
            showEmail: true,
            showWebsite: true,
            tableStyle: null,
            columnStylesSelected: [
                null,
                null,
                null,
                null,
                null,
                null,
                null
            ],
            rowStylesSelected: [
               null,
               null,
               null
            ],
            cells: [
                [{ value: "Location title" }, { value: "Address" }, { value: "Phone number" }, { value: "Email address" }, { value: "Website" }, { value: "Latitude[invisible]" }, { value: "Longlongitude[invisible]" }],
                [{ value: "" }, { value: "" }, { value: "" }, { value: "" }, { value: "" }, { value: "" }, { value: "" }],
                [{ value: "" }, { value: "" }, { value: "" }, { value: "" }, { value: "" }, { value: "" }, { value: "" }],
            ]
        }
        */

        public bool ShowLocationTitle { get; set; }
        public bool ShowAddress { get; set; }
        public bool ShowPhoneNumber { get; set; }
        public bool ShowEmail { get; set; }
        public bool ShowWebsite { get; set; }
        public string TableStyle { get; set; }
        public IEnumerable<string> ColumnStylesSelected { get; set; }
        public IEnumerable<string> RowStylesSelected { get; set; }
        public IEnumerable<IEnumerable<CellModel>> Cells { get; set; }
    }
}
