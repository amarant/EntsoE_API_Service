using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntsoE_DataModel
{
    public static class BiddingZone
    {
        static Dictionary<string, string> _biddingZones = new Dictionary<string, string>();

        public enum ZoneName
        {
            DE,
            LU,
            DE_50HZ,
            DE_AMPRION,
            DE_TENNET,
            DE_TRANSNET,
            IT_NORD,
            IT_NORD_AT,
            IT_NORD_FR,
            IT_NORD_CH,
            IT_CNOR,
            IT_CSUD,
            IT_SUD,
            IT_FOGN,
            IT_ROSN,
            IT_BRNN,
            IT_PRGP,
            IT_SARD,
            IT_SICI,
            IT_GR,
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
            DK_2,
            IE_SEM,
            UA
        }

        static BiddingZone()
        {
            _biddingZones.Add("DE", "10Y1001A1001A63L");
            _biddingZones.Add("LU", "10Y1001A1001A63L");
            _biddingZones.Add("DE-50HZ", "10YDE-VE-------2");
            _biddingZones.Add("DE-AMPRION", "10YDE-RWENET---I");
            _biddingZones.Add("DE-TENNET", "10YDE-EON------1");
            _biddingZones.Add("DE-TRANSNET", "10YDE-ENBW-----N");
            _biddingZones.Add("IT-NORD", "10Y1001A1001A73I");
            _biddingZones.Add("IT-NORD-AT", "10Y1001A1001A80L");
            _biddingZones.Add("IT-NORD-FR", "10Y1001A1001A81J");
            _biddingZones.Add("IT-NORD-CH", "10Y1001A1001A68B");
            _biddingZones.Add("IT-CNOR", "10Y1001A1001A70O");
            _biddingZones.Add("IT-CSUD", "10Y1001A1001A71M");
            _biddingZones.Add("IT-SUD", "10Y1001A1001A788");
            _biddingZones.Add("IT-FOGN", "10Y1001A1001A72K");
            _biddingZones.Add("IT-ROSN", "10Y1001A1001A77A");
            _biddingZones.Add("IT-BRNN", "10Y1001A1001A699");
            _biddingZones.Add("IT-PRGP", "10Y1001A1001A76C");
            _biddingZones.Add("IT-SARD", "10Y1001A1001A74G");
            _biddingZones.Add("IT-SICI", "10Y1001A1001A75E");
            _biddingZones.Add("IT-GR", "10Y1001A1001A66F");
            _biddingZones.Add("NO-1", "10YNO-1--------2");
            _biddingZones.Add("NO-2", "10YNO-2--------T");
            _biddingZones.Add("NO-3", "10YNO-3--------J");
            _biddingZones.Add("NO-4", "10YNO-4--------9");
            _biddingZones.Add("NO-5", "10Y1001A1001A48H");
            _biddingZones.Add("SE-1", "10Y1001A1001A44P");
            _biddingZones.Add("SE-2", "10Y1001A1001A45N");
            _biddingZones.Add("SE-3", "10Y1001A1001A46L");
            _biddingZones.Add("SE-4", "10Y1001A1001A47J");
            _biddingZones.Add("DK-1", "10YDK-1--------W");
            _biddingZones.Add("DK-2", "10YDK-2--------M");
            _biddingZones.Add("IE-SEM", "10Y1001A1001A59C");
            _biddingZones.Add("UA", "10Y1001C--00003F");
        }

        public static List<string> GetBiddingZoneCodes()
        {
            return _biddingZones.Select(i => i.Value).ToList();
        }

        public static string GetBiddingZone(ZoneName zoneName)
        {
            return _biddingZones.Where(i => i.Key == zoneName.ToString().Replace("_", "-")).FirstOrDefault().Value;
        }

        public static List<string> GetBiddingZones(List<ZoneName> zoneNames)
        {
            return _biddingZones.Where(i => zoneNames.Select(x => x.ToString().Replace("_", "-")).ToList().Contains(i.Key)).Select(i => i.Value).ToList();
        }

        public static string GetBiddingZone(string code)
        {
            return _biddingZones.Where(i => i.Key == code).FirstOrDefault().Value;
        }

        public static List<string> GetBiddingZones(List<string> codes)
        {
            return _biddingZones.Where(i => codes.Contains(i.Key)).Select(i => i.Value).ToList();
        }
    }
}
