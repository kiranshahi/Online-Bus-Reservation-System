using System.Web;
using System.Web.Mvc;

namespace Online_Bus_Reservation_System
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
