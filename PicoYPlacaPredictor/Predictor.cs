using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicoYPlacaPredictor
{
    public class Predictor
    {

        int finalPlateNumber;
        DateTime date;

        string _dateStr;
        string _timeStr;
        string _plate;

        public Predictor(string dateStr, string timeStr, string plate)
        {
            _dateStr = dateStr;
            _timeStr = timeStr;
            _plate = plate;
            try{
                date = DateTime.Parse(dateStr + " " + timeStr);
            }
            catch
            {
                Console.WriteLine("There is an error in your data, please verify formating");
            }
            
        }

        public bool CanCarRoad()
        {

            if (_plate.Length == 8) //PPP-1234
                try
                {
                    finalPlateNumber = int.Parse(_plate.Substring(_plate.Length - 1, 1));
                }
                catch
                {
                    finalPlateNumber = -1;
                    Console.WriteLine("Character in position 8 is not a number");
                }
            else if (_plate.Length == 6) //HR999F
                try
                {
                    finalPlateNumber = int.Parse(_plate.Substring(_plate.Length - 2, 1));
                }
                catch
                {
                    finalPlateNumber = -1;
                    Console.WriteLine("Character in position 6 is not a number");
                }
            else
            {
                finalPlateNumber = -1;
                Console.WriteLine("Plate must be 6 or 8 ");
            }
                

            if (finalPlateNumber > -1){
                DayRules rules = new DayRules(date);
                List<int> restrictedNumbers = rules.GetRestrictedNumbers();
                //in first place number will be evaluated
                foreach(int number in restrictedNumbers){
                    if (number == finalPlateNumber){
                        //it must evaluate schedule
                        List<Schedule> schedules = rules.GetRestrictedHours();
                        foreach (Schedule s in schedules)
                        {
                            //validate time in schedule
                            if (TimeSpan.Compare(s.TimeSince.TimeOfDay, date.TimeOfDay) <= 0 &&
                                TimeSpan.Compare(date.TimeOfDay, s.TimeUntil.TimeOfDay) <= 0)
                            {
                                return false;
                            }

                        }
                    }
                }

                return true;
            }
            else
                return false;
            
           
        }

    }
}
