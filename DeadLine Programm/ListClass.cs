using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DeadLine_Programm
{
    class ConvertClass
    {
        List<ConvertClass> listD = new List<ConvertClass>();
        public void ConvertToDataTime()
        {
            using (StreamReader sr = new StreamReader("listDL.json"))
            {
                listD = JsonConvert.DeserializeObject<List<ConvertClass>>(sr.ReadToEnd());
            }

            foreach (var v in listD)
            {
                string time = Convert.ToString(v);
                var dt = Convert.ToDateTime(v);
            }
        }
    }
}
