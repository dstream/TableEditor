Umbraco 7 Multi location map TableEditor
===========
Table editor to build a multi location to show on a map, with ability to add more extend columns


Features:
- Use your own markup.
- Editor adds/removes rows/cols.
- Set limit on rows/cols.
- Add table, row and column styles.
- Fixed field: title, address, phone, email, latitude, longitude (can't not remove)
- Add more columns, rows
- Options to hide fixed fields

![TableEditor](https://pbs.twimg.com/media/BouPOV3IYAAHghE.png)

###Install
Presently it's a manual install:

 - Create a `~/App_Plugins/MultiLocationMapTableEditor` folder.
 - Drop the `/css`, `/js`, `/views` and `package.manifest` into your `~/App_Plugins/MultiLocationMapTableEditor` folder.
 - Drop the dll in `/bin`
 - Touch web.config
 - Configure in `Developer->Datatypes`

###Sample Partial Call
`@Html.Partial("~/pathtopartial/partialname.cshtml", Model.Content.GetPropertyValue<TableEditorModel>("propname"))`

###Sample Partial Template
You can use the sample template below or customize your own.

    @inherits Umbraco.Web.Mvc.UmbracoViewPage<TableEditorModel>
    @{
        var rowIndex = 0;
    }
    <div class="table-responsive">
        <table class="table table-hover">
            <thead>
                <tr>
                    @{
                        var columnIndex = 0;
                        foreach (var column in locations.Cells.First())
                        {
                            if (column.IsVisiableColumn(locations, columnIndex))
                            {
                                <th>@column.Value</th>
                            }
                            columnIndex++;
                        }
                    }
                </tr>
            </thead>
            <tbody>
                @foreach (var row in locations.Cells.Skip(1))
                {
                    if (!row.IsValid()) { continue; }
                    <tr class="@locations.RowStylesSelected.ElementAtOrDefault(rowIndex)" >
                        @{
                            columnIndex = 0;

                            foreach (var column in row)
                            {
                                if (column.IsVisiableColumn(locations, columnIndex))
                                {
                                    <td class="@locations.ColumnStylesSelected.ElementAtOrDefault(columnIndex)">@column.Value</td>
                                }
                                columnIndex++;
                            }
                        }
                    </tr>
                    rowIndex++;
                }
            </tbody>
        </table>
    </div>

###Screenshots
- Front-end: http://prntscr.com/in7f1v
- Back-end: http://prntscr.com/in7fmx

