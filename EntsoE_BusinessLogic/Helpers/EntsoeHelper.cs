using System;
using System.Collections.Generic;
using System.Text;

namespace EntsoE_BusinessLogic.Helpers
{
    public class EntsoeHelper
    {
        public static readonly DateTime MinDate = new DateTime(2015, 1, 1);
        public static int RetryCount = 5;
        public static int PollingCount = 900000;

        public static int GetIntervalInMinutes(string code)
        {
            switch (code)
            {
                case "PT60M":
                    return 60;
                case "PT1H":
                    return 60;
                case "PT30M":
                    return 30;
                case "PT15M":
                    return 15;
                case "P1Y":
                    return 525600;
                default:
                    return 1;
            }
        }
    }
}
