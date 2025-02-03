using System.Net.Mime;
using System.Security.AccessControl;
using static Ecommerce.Web.Utility.SD;

namespace Ecommerce.Web.Models
{
    public class Request
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }
    }
}
