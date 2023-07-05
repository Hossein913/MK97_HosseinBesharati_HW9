namespace ProductManager
{
    public class PositiveConstraint : IRouteConstraint
    {
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            int id;

            if (Int32.TryParse(values["id"].ToString(),out id)) 
            {
                if (id > 0) 
                {
                    return true;
                }
            }
            return false;
        }
    }
}
