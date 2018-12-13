using Newtonsoft.Json;
using System.Net;

namespace SimpleStore.DataAccess.Helpers
{
    public class ServiceResult
    {
        public HttpStatusCode Status { get; set; }
        public object Data { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this,
                new JsonSerializerSettings {ReferenceLoopHandling = ReferenceLoopHandling.Ignore});
        }
    }
}