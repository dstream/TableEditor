using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MultiLocationMapTableEditor.Models;

namespace MultiLocationMapTableEditor
{
    public static class Extensions
    {
        public static bool DetectIsJson(this string input)
        {
            input = input.Trim();
            return input.StartsWith("{") && input.EndsWith("}")
                   || input.StartsWith("[") && input.EndsWith("]");
        }

        public static bool IsVisiableColumn(this CellModel cellModel, TableEditorModel tableEditorModel, int colIndex)
        {
            if(colIndex == CellModel.LatitudeColumnIndex || colIndex == CellModel.LongitudeColumnIndex) // lat, long col always invisible
            {
                return false;
            }
            switch (colIndex) {
                case CellModel.LocationTitleColumnIndex:
                    return tableEditorModel.ShowLocationTitle;                    
                case CellModel.AddressColumnIndex:
                    return tableEditorModel.ShowAddress;
                case CellModel.PhonenNumberColumnIndex:
                    return tableEditorModel.ShowPhoneNumber;
                case CellModel.EmailColumnIndex:
                    return tableEditorModel.ShowEmail;
                case CellModel.WebsiteColumnIndex:
                    return tableEditorModel.ShowWebsite;
            }
            return true;
        }

        public static string GetLatitude(this IEnumerable<CellModel> row)
        {
            return row.GetFieldValue(CellModel.LatitudeColumnIndex);
        }

        public static string GetLongitude(this IEnumerable<CellModel> row)
        {
            return row.GetFieldValue(CellModel.LongitudeColumnIndex);
        }

        public static string GetLocationTitle(this IEnumerable<CellModel> row)
        {
            return row.GetFieldValue(CellModel.LocationTitleColumnIndex);
        }

        public static string GetAddress(this IEnumerable<CellModel> row)
        {
            return row.GetFieldValue(CellModel.AddressColumnIndex);
        }

        public static string GetPhoneNumber(this IEnumerable<CellModel> row)
        {
            return row.GetFieldValue(CellModel.PhonenNumberColumnIndex);
        }

        public static string GetEmailAddress(this IEnumerable<CellModel> row)
        {
            return row.GetFieldValue(CellModel.EmailColumnIndex);
        }

        public static string GetWebsite(this IEnumerable<CellModel> row)
        {
            return row.GetFieldValue(CellModel.WebsiteColumnIndex);
        }

        public static string GetFieldValue(this IEnumerable<CellModel> row, int index)
        {
            var cell = row.ElementAtOrDefault(index);
            return cell == null ? string.Empty : cell.Value;
        }

        public static bool IsValid(this IEnumerable<CellModel> row)
        {
            if (string.IsNullOrEmpty(row.GetLocationTitle())) return false;
            var decimalRx = new Regex(@"^\d+(\.\d+)?$");
            if (!decimalRx.IsMatch(row.GetLatitude())) return false;
            if (!decimalRx.IsMatch(row.GetLongitude())) return false;
            return true;
        }
    }
}
