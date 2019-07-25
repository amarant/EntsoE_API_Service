using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntsoE_DataModel
{
    public static class BorderFlow
    {
        static Dictionary<string, List<string>> _borders = new Dictionary<string, List<string>>();

        public enum Location
        {
            BE,
            NL,
            DE_AT_LU,
            FR,
            CH,
            AT,
            CZ,
            GB,
            NO_2,
            HU,
            IT_NORD,
            ES,
            SI,
            RS,
            PL,
            ME,
            DK_1,
            RO,
            LT,
            BG,
            SE_3,
            LV,
            IE_SEM,
            BA,
            NO_1,
            SE_4,
            NO_5,
            SK,
            EE,
            DK_2,
            FI,
            NO_4,
            SE_1,
            SE_2,
            DE_LU,
            MK,
            PT,
            GR,
            NO_3,
            IT_BRNN,
            IT_SUD,
            IT_FOGN,
            IT_ROSN,
            IT_CSUD
        }

        static BorderFlow()
        {
            _borders.Add("BE", new List<string> { "NL", "DE-AT-LU", "FR", "GB", "DE-LU" });
            _borders.Add("NL", new List<string> { "BE", "DE-AT-LU", "DE-LU", "GB", "NO-2" });
            _borders.Add("DE-AT-LU", new List<string> { "BE", "CH", "CZ", "DK-1", "DK-2", "FR", "IT-NORD", "IT-NORD-AT", "NL", "PL", "SE-4", "SI" });
            _borders.Add("FR", new List<string> { "BE", "CH", "DE-AT-LU", "DE-LU", "ES", "GB", "IT-NORD", "IT-NORD-FR" });
            _borders.Add("CH", new List<string> { "AT", "DE-AT-LU", "DE-LU", "FR", "IT-NORD", "IT-NORD-CH" });
            _borders.Add("AT", new List<string> { "CH", "CZ", "DE-LU", "HU", "IT-NORD", "SI" });
            _borders.Add("CZ", new List<string> { "AT", "DE-AT-LU", "DE-LU", "PL", "SK" });
            _borders.Add("GB", new List<string> { "BE", "FR", "IE-SEM", "NL" });
            _borders.Add("NO-2", new List<string> { "DK-1", "NL", "NO-5" });
            _borders.Add("HU", new List<string> { "AT", "HR", "RO", "RS", "SK", "UA" });
            _borders.Add("IT-NORD", new List<string> { "CH", "DE-AT-LU", "FR", "SI", "AT" });
            _borders.Add("ES", new List<string> { "FR", "PT" });
            _borders.Add("SI", new List<string> { "AT", "DE-AT-LU", "HR", "IT-NORD" });
            _borders.Add("RS", new List<string> { "AL", "BA", "BG", "HR", "HU", "ME", "MK", "RO" });
            _borders.Add("PL", new List<string> { "CZ", "DE-AT-LU", "DE-LU", "LT", "SE-4", "SK", "UA" });
            _borders.Add("ME", new List<string> { "AL", "BA", "RS" });
            _borders.Add("DK-1", new List<string> { "DE-AT-LU", "DE-LU", "DK-2", "NO-2", "SE-3" });
            _borders.Add("RO", new List<string> { "BG", "HU", "RS", "UA" });
            _borders.Add("LT", new List<string> { "BY", "LV", "PL", "RU-KGD", "SE-4" });
            _borders.Add("BG", new List<string> { "GR", "MK", "RO", "RS", "TR" });
            _borders.Add("SE-3", new List<string> { "DK-1", "FI", "NO-1", "SE-4" });
            _borders.Add("LV", new List<string> { "EE", "LT", "RU" });
            _borders.Add("IE-SEM", new List<string> { "GB" });
            _borders.Add("BA", new List<string> { "HR", "ME", "RS" });
            _borders.Add("NO-1", new List<string> { "NO-2", "NO-3", "NO-5", "SE-3" });
            _borders.Add("SE-4", new List<string> { "DE-AT-LU", "DE-LU", "DK-2", "LT", "PL" });
            _borders.Add("NO-5", new List<string> { "NO-1", "NO-2", "NO-3" });
            _borders.Add("SK", new List<string> { "CZ", "HU", "PL", "UA" });
            _borders.Add("EE", new List<string> { "FI", "LV", "RU" });
            _borders.Add("DK-2", new List<string> { "DE-AT-LU", "DE-LU", "SE-4" });
            _borders.Add("FI", new List<string> { "EE", "NO-4", "RU", "SE-1", "SE-3" });
            _borders.Add("NO-4", new List<string> { "SE-2", "FI", "SE-1" });
            _borders.Add("SE-1", new List<string> { "FI", "NO-4", "SE-2" });
            _borders.Add("SE-2", new List<string> { "NO-3", "NO-4", "SE-3" });
            _borders.Add("DE-LU", new List<string> { "AT", "BE", "CH", "CZ", "DK-1", "DK-2", "FR", "NL", "PL", "SE-4" });
            _borders.Add("MK", new List<string> { "BG", "GR", "RS" });
            _borders.Add("PT", new List<string> { "ES" });
            _borders.Add("GR", new List<string> { "AL", "BG", "IT-BRNN", "IT-GR", "MK", "TR" });
            _borders.Add("NO-3", new List<string> { "NO-4", "NO-5", "SE-2" });
            _borders.Add("IT-BRNN", new List<string> { "GR", "IT-SUD" });
            _borders.Add("IT-SUD", new List<string> { "IT-BRNN", "IT-CSUD", "IT-FOGN", "IT-ROSN" });
            _borders.Add("IT-FOGN", new List<string> { "IT-SUD" });
            _borders.Add("IT-ROSN", new List<string> { "IT-SICI", "IT-SUD" });
            _borders.Add("IT-CSUD", new List<string> { "IT-CNOR", "IT-SARD", "IT-SUD" });
        }

        public static List<List<string>> GetBorderFlows()
        {
            return _borders.Select(i => i.Value).ToList();
        }

        public static List<string> GetFlow(Location location)
        {
            return _borders.Where(i => i.Key == location.ToString().Replace("_", "-")).FirstOrDefault().Value;
        }

        public static List<List<string>> GetFlows(List<Location> locations)
        {
            return _borders.Where(i => locations.Select(x => x.ToString().Replace("_", "-")).ToList().Contains(i.Key)).Select(i => i.Value).ToList();
        }

        public static List<string> GetFlow(string code)
        {
            return _borders.Where(i => i.Key == code).FirstOrDefault().Value;
        }

        public static List<List<string>> GetFlows(List<string> codes)
        {
            return _borders.Where(i => codes.Contains(i.Key)).Select(i => i.Value).ToList();
        }
    }
}
