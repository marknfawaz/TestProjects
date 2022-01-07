using System.Collections.Generic;
using Newtonsoft.Json;

namespace FrameworkWithSdkStyleProjFile
{
    public class Program 
    {
        public static void Main(string[] args)
        {
            var d = new Dictionary<string, string>();
            JsonConvert.SerializeObject(d);
        }
    }
}
