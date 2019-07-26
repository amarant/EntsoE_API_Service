using System;
using System.Collections.Generic;
using System.Linq;

namespace EntsoE_DataModel
{
    public static class Country
    {
        static Dictionary<string, string> _domains = new Dictionary<string, string>();

        public enum Code
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
            DE_AT_LU,
            DE_LU,
        }

        static Country()
        {
            _domains.Add("AL", "10YAL-KESH-----5");
            _domains.Add("AT", "10YAT-APG------L");
            _domains.Add("BA", "10YBA-JPCC-----D");
            _domains.Add("BE", "10YBE----------2");
            _domains.Add("BG", "10YCA-BULGARIA-R");
            _domains.Add("BY", "10Y1001A1001A51S");
            _domains.Add("CH", "10YCH-SWISSGRIDZ");
            _domains.Add("CZ", "10YCZ-CEPS-----N");
            _domains.Add("DE", "10Y1001A1001A83F");
            _domains.Add("DK", "10Y1001A1001A65H");
            _domains.Add("EE", "10Y1001A1001A39I");
            _domains.Add("ES", "10YES-REE------0");
            _domains.Add("FI", "10YFI-1--------U");
            _domains.Add("FR", "10YFR-RTE------C");
            _domains.Add("GB", "10YGB----------A");
            _domains.Add("GB-NIR", "10Y1001A1001A016");
            _domains.Add("GR", "10YGR-HTSO-----Y");
            _domains.Add("HR", "10YHR-HEP------M");
            _domains.Add("HU", "10YHU-MAVIR----U");
            _domains.Add("IE", "10YIE-1001A00010");
            _domains.Add("IT", "10YIT-GRTN-----B");
            _domains.Add("LT", "10YLT-1001A0008Q");
            _domains.Add("LU", "10YLU-CEGEDEL-NQ");
            _domains.Add("LV", "10YLV-1001A00074");
            _domains.Add("ME", "10YCS-CG-TSO---S");
            _domains.Add("MK", "10YMK-MEPSO----8");
            _domains.Add("MT", "10Y1001A1001A93C");
            _domains.Add("NL", "10YNL----------L");
            _domains.Add("NO", "10YNO-0--------C");
            _domains.Add("PL", "10YPL-AREA-----S");
            _domains.Add("PT", "10YPT-REN------W");
            _domains.Add("RO", "10YRO-TEL------P");
            _domains.Add("RS", "10YCS-SERBIATSOV");
            _domains.Add("RU", "10Y1001A1001A49F");
            _domains.Add("RU-KGD", "10Y1001A1001A50U");
            _domains.Add("SE", "10YSE-1--------K");
            _domains.Add("SI", "10YSI-ELES-----O");
            _domains.Add("SK", "10YSK-SEPS-----K");
            _domains.Add("TR", "10YTR-TEIAS----W");
            _domains.Add("UA", "10YUA-WEPS-----0");
            _domains.Add("DE-AT-LU", "10Y1001A1001A63L");
            _domains.Add("DE-LU", "10Y1001A1001A82H");
        }

        public static List<string> GetDomainCodes()
        {
            return _domains.Select(i => i.Value).ToList();
        }

        public static string GetDomain(Code domainName)
        {
            return _domains.Where(i => i.Key == domainName.ToString().Replace("_","-")).FirstOrDefault().Value;
        }

        public static List<string> GetDomains(List<Code> codes)
        {
            return _domains.Where(i => codes.Select(x => x.ToString().Replace("_", "-")).ToList().Contains(i.Key)).Select(i => i.Value).ToList();
        }

        public static string GetDomain(string code)
        {
            return _domains.Where(i => i.Key == code).FirstOrDefault().Value;
        }

        public static List<string> GetDomains(List<string> codes)
        {
            return _domains.Where(i => codes.Contains(i.Key)).Select(i => i.Value).ToList();
        }
    }
}
