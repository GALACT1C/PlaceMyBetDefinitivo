using System.Web;
using System.Web.Mvc;

namespace PlaceMyBet_Carlos_Tamarit_Martinez
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
