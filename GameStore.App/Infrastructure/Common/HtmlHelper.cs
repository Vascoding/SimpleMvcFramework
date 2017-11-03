namespace GameStore.App.Infrastructure.Common
{
    public class HtmlHelper
    {
        public static string AdminAllGamesAsString(string title, double size, decimal price)
        {
            return $@"<tr class=""table-warning"">
                    <th scope = ""row"">1</ th>
                    <td>{title}</ td>
                    <td>{size} GB </ td>
                    <td>{price} &euro;</ td>
                    <td>
                    <a href = ""#"" class=""btn btn-warning btn-sm"" > Edit</a>
                    <a href = ""#"" class=""btn btn-danger btn-sm"" > Delete</a>
                    </td>
                    </tr>
                    <tr>";
        }
    }
}