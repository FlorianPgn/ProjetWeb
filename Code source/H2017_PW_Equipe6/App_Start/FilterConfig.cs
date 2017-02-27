using System.Web;
using System.Web.Mvc;

namespace H2017_PW_Equipe6
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
