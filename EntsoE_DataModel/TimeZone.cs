using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntsoE_DataModel
{
    public static class TimeZone
    {
        static Dictionary<string, string> _timeZones = new Dictionary<string, string>();

        public enum ZoneName
        {
            AL,
            AT,
            BA,
            BE,
            BG,
            BY,
            CH,
            CZ,
            DE,
            DE_50HZ,
            DE_AMPRIRON,
            DE_TENNET,
            DE_TRANSNET,
            DE_LU,
            DK,
            EE,
            ES,
            FI,
            FR,
            GB,
            GB_NIR,
            GR,
            HR,
            HU,
            IE,
            IE_SEM,
            IT,
            LT,
            LU,
            LV,
            ME,
            MK,
            MT,
            NL,
            NO,
            PL,
            PT,
            RO,
            RS,
            RU,
            RU_KGD,
            SE,
            SI,
            SK,
            TR,
            UA,
            IT_NORD,
            IT_CNOR,
            IT_CSUD,
            IT_SUD,
            IT_FOGN,
            IT_ROSN,
            IT_BRNN,
            IT_PRGP,
            IT_SARD,
            IT_SICI,
            DE_AT_LU,
            NO_1,
            NO_2,
            NO_3,
            NO_4,
            NO_5,
            SE_1,
            SE_2,
            SE_3,
            SE_4,
            DK_1,
            DK_2
        }
        static TimeZone()
        {
            _timeZones.Add("AL", "Europe/Tirane");
            _timeZones.Add("AT", "Europe/Vienna");
            _timeZones.Add("BA", "Europe/Sarajevo");
            _timeZones.Add("BE", "Europe/Brussels");
            _timeZones.Add("BG", "Europe/Sofia");
            _timeZones.Add("BY", "Europe/Minsk");
            _timeZones.Add("CH", "Europe/Zurich");
            _timeZones.Add("CZ", "Europe/Prague");
            _timeZones.Add("DE", "Europe/Berlin");
            _timeZones.Add("DE-50HZ", "Europe/Berlin");
            _timeZones.Add("DE-AMPRIRON", "Europe/Berlin");
            _timeZones.Add("DE-TENNET", "Europe/Berlin");
            _timeZones.Add("DE-TRANSNET", "Europe/Berlin");
            _timeZones.Add("DE-LU", "Europe/Berlin");
            _timeZones.Add("DK", "Europe/Copenhagen");
            _timeZones.Add("EE", "Europe/Tallinn");
            _timeZones.Add("ES", "Europe/Madrid");
            _timeZones.Add("FI", "Europe/Helsinki");
            _timeZones.Add("FR", "Europe/Paris");
            _timeZones.Add("GB", "Europe/London");
            _timeZones.Add("GB-NIR", "Europe/Belfast");
            _timeZones.Add("GR", "Europe/Athens");
            _timeZones.Add("HR", "Europe/Zagreb");
            _timeZones.Add("HU", "Europe/Budapest");
            _timeZones.Add("IE", "Europe/Dublin");
            _timeZones.Add("IE-SEM", "Europe/Dublin");
            _timeZones.Add("IT", "Europe/Rome");
            _timeZones.Add("LT", "Europe/Vilnius");
            _timeZones.Add("LU", "Europe/Luxembourg");
            _timeZones.Add("LV", "Europe/Riga");
            _timeZones.Add("ME", "Europe/Podgorica");
            _timeZones.Add("MK", "Europe/Skopje");
            _timeZones.Add("MT", "Europe/Malta");
            _timeZones.Add("NL", "Europe/Amsterdam");
            _timeZones.Add("NO", "Europe/Oslo");
            _timeZones.Add("PL", "Europe/Warsaw");
            _timeZones.Add("PT", "Europe/Lisbon");
            _timeZones.Add("RO", "Europe/Bucharest");
            _timeZones.Add("RS", "Europe/Belgrade");
            _timeZones.Add("RU", "Europe/Moscow");
            _timeZones.Add("RU-KGD", "Europe/Kaliningrad");
            _timeZones.Add("SE", "Europe/Stockholm");
            _timeZones.Add("SI", "Europe/Ljubljana");
            _timeZones.Add("SK", "Europe/Bratislava");
            _timeZones.Add("TR", "Europe/Istanbul");
            _timeZones.Add("UA", "Europe/Kiev");
            _timeZones.Add("IT-NORD", "Europe/Rome");
            _timeZones.Add("IT-CNOR", "Europe/Rome");
            _timeZones.Add("IT-CSUD", "Europe/Rome");
            _timeZones.Add("IT-SUD", "Europe/Rome");
            _timeZones.Add("IT-FOGN", "Europe/Rome");
            _timeZones.Add("IT-ROSN", "Europe/Rome");
            _timeZones.Add("IT-BRNN", "Europe/Rome");
            _timeZones.Add("IT-PRGP", "Europe/Rome");
            _timeZones.Add("IT-SARD", "Europe/Rome");
            _timeZones.Add("IT-SICI", "Europe/Rome");
            _timeZones.Add("DE-AT-LU", "Europe/Berlin");
            _timeZones.Add("NO-1", "Europe/Oslo");
            _timeZones.Add("NO-2", "Europe/Oslo");
            _timeZones.Add("NO-3", "Europe/Oslo");
            _timeZones.Add("NO-4", "Europe/Oslo");
            _timeZones.Add("NO-5", "Europe/Oslo");
            _timeZones.Add("SE-1", "Europe/Stockholm");
            _timeZones.Add("SE-2", "Europe/Stockholm");
            _timeZones.Add("SE-3", "Europe/Stockholm");
            _timeZones.Add("SE-4", "Europe/Stockholm");
            _timeZones.Add("DK-1", "Europe/Copenhagen");
            _timeZones.Add("DK-2", "Europe/Copenhagen");
        }

        public static List<string> GetBiddingZoneCodes()
        {
            return _timeZones.Select(i => i.Value).ToList();
        }

        public static string GetTimeZone(ZoneName zoneName)
        {
            return _timeZones.Where(i => i.Key == zoneName.ToString().Replace("_", "-")).FirstOrDefault().Value;
        }

        public static List<string> GetTimeZones(List<ZoneName> zoneNames)
        {
            return _timeZones.Where(i => zoneNames.Select(x => x.ToString().Replace("_", "-")).ToList().Contains(i.Key)).Select(i => i.Value).ToList();
        }

        public static string GetTimeZone(string code)
        {
            return _timeZones.Where(i => i.Key == code).FirstOrDefault().Value;
        }

        public static List<string> GetTimeZones(List<string> codes)
        {
            return _timeZones.Where(i => codes.Contains(i.Key)).Select(i => i.Value).ToList();
        }
    }
}
