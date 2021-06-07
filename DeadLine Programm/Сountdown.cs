using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace DeadLine_Programm
{
    public class Сountdown
    {
       
        public DateTime Time { get; set; }

        public static int[] SearchTime()
        {
            List<Сountdown> listDL = new List<Сountdown>();

            long xDay = 2913810;
            long xHours = 69931446;
            long xMinutes = 4195886816;
            long xSeconds = 251753208960;

            
                using (StreamReader sr = new StreamReader("listDL.json"))
                {
                    listDL = JsonConvert.DeserializeObject<List<Сountdown>>(sr.ReadToEnd());
                }
           

             foreach (var el in listDL)
             {
               
                    long minDay = (el.Time - DateTime.Today).Days;
                    long minHours = (el.Time - DateTime.Today).Hours;
                    long minMinutes = (el.Time - DateTime.Today).Minutes;
                    long minSeconds = (el.Time - DateTime.Now).Seconds;

                    if (minDay < xDay)
                    {
                        xDay = minDay;
                        xHours = minHours;
                        xMinutes = minMinutes;
                        xSeconds = minSeconds;
                    }
                    if (minDay == xDay)
                    {
                        if (minHours < xHours)
                        {
                            xHours = minHours;
                            xMinutes = minMinutes;
                            xSeconds = minSeconds;
                        }
                    }
                    if (minDay == xDay)
                    {
                        if (minHours == xHours)
                        {
                            if (minMinutes < xMinutes)
                            {
                                xMinutes = minMinutes;
                                xSeconds = minSeconds;
                            }
                        }
                    }
                    if (minDay == xDay)
                    {
                        if (minHours == xHours)
                        {
                            if (minMinutes == xMinutes)
                            {
                                if (Convert.ToUInt32(minSeconds) < xSeconds)
                                {
                                    xSeconds = minSeconds;
                                }
                            }
                        }
                    }
                }
             
                

             int[] countTime = new int[4];
             countTime[0] = Convert.ToInt32(xDay);
             countTime[1] = Convert.ToInt32(xHours);
             countTime[2] = Convert.ToInt32(xMinutes);
             countTime[3] = Convert.ToInt32(xSeconds);

             return countTime;
            
           
        }

    }
}
