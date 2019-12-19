using Newtonsoft.Json;

namespace ProyectoEjemplo.Helpers
{
    public class ResponseError
    {
        public int Code { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this).ToLower();
        }
    }
}
