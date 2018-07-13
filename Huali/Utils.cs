using DevComponents.DotNetBar.Controls; 

namespace Huali
{
    public partial class Utils
    {
        public static void H2(string key)
        {
            DesktopAlert.Show(string.Format("<h2>{0}</h2>", key));
        }
    }
}
