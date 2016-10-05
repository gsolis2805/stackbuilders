using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicoYPlacaPredictor
{
    public class DayRules
    {
        //in this class there are defined days and hours cars can road
        DateTime _date;
        
        //constructor gets the date
        public DayRules(DateTime date)
        {
            _date = date;
        }

        //this function will return the restricted numbers of the day
        public List<int>GetRestrictedNumbers()
        {
            List<int> plateNumbers = new List<int>();
            int[] numbers = new int[2];
            DayOfWeek dayOfWeek = _date.DayOfWeek;
            
            if (dayOfWeek == DayOfWeek.Monday)
            {
                plateNumbers.Add(1);
                plateNumbers.Add(2);
            }
            else if (dayOfWeek == DayOfWeek.Tuesday)
            {
                plateNumbers.Add(3);
                plateNumbers.Add(4);
            }
            else if (dayOfWeek == DayOfWeek.Wednesday)
            {
                plateNumbers.Add(5);
                plateNumbers.Add(6);
            }
            else if (dayOfWeek == DayOfWeek.Thursday)
            {
                plateNumbers.Add(7);
                plateNumbers.Add(8);
            }else if (dayOfWeek == DayOfWeek.Friday)
            {
                plateNumbers.Add(9);
                plateNumbers.Add(0);
            }
            
            return plateNumbers;
        }


        public List<Schedule> GetRestrictedHours()
        {
            List<Schedule> restricted = new List<Schedule>();
            //Morning restriction
            Schedule s = new Schedule();
            s.TimeSince = new DateTime(2016,1,1,7,0,0);
            s.TimeUntil = new DateTime(2016, 1, 1, 9, 30, 0);
            
            restricted.Add(s);
            //afternoon restriction
            s = new Schedule();
            s.TimeSince = new DateTime(2016, 1, 1, 16, 0, 0);
            s.TimeUntil = new DateTime(2016, 1, 1, 19, 30, 0);
            restricted.Add(s);
            return restricted;
        }
    }

}
