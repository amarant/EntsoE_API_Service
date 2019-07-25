using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntsoE_DataModel
{
    public static class PSR_Mapping
    {
        static Dictionary<string, string> _mappings = new Dictionary<string, string>();

        public enum Key
        {
            A03,
            A04,
            A05,
            B01,
            B02,
            B03,
            B04,
            B05,
            B06,
            B07,
            B08,
            B09,
            B10,
            B11,
            B12,
            B13,
            B14,
            B15,
            B16,
            B17,
            B18,
            B19,
            B20,
            B21,
            B22,
            B23,
            B24
        }

        static PSR_Mapping()
        {
            _mappings.Add("A03", "Mixed");
            _mappings.Add("A04", "Generation");
            _mappings.Add("A05", "Load");
            _mappings.Add("B01", "Biomass");
            _mappings.Add("B02", "Fossil Brown coal/Lignite");
            _mappings.Add("B03", "Fossil Coal-derived gas");
            _mappings.Add("B04", "Fossil Gas");
            _mappings.Add("B05", "Fossil Hard coal");
            _mappings.Add("B06", "Fossil Oil");
            _mappings.Add("B07", "Fossil Oil shale");
            _mappings.Add("B08", "Fossil Peat");
            _mappings.Add("B09", "Geothermal");
            _mappings.Add("B10", "Hydro Pumped Storage");
            _mappings.Add("B11", "Hydro Run-of-river and poundage");
            _mappings.Add("B12", "Hydro Water Reservoir");
            _mappings.Add("B13", "Marine");
            _mappings.Add("B14", "Nuclear");
            _mappings.Add("B15", "Other renewable");
            _mappings.Add("B16", "Solar");
            _mappings.Add("B17", "Waste");
            _mappings.Add("B18", "Wind Offshore");
            _mappings.Add("B19", "Wind Onshore");
            _mappings.Add("B20", "Other");
            _mappings.Add("B21", "AC Link");
            _mappings.Add("B22", "DC Link");
            _mappings.Add("B23", "Substation");
            _mappings.Add("B24", "Transformer");
        }

        public static List<string> GetMappings()
        {
            return _mappings.Select(i => i.Value).ToList();
        }

        public static string GetMapping(Key key)
        {
            return _mappings.Where(i => i.Key == key.ToString().Replace("_", "-")).FirstOrDefault().Value;
        }

        public static List<string> GetMappings(List<Key> keys)
        {
            return _mappings.Where(i => keys.Select(x => x.ToString().Replace("_", "-")).ToList().Contains(i.Key)).Select(i => i.Value).ToList();
        }

        public static string GetMapping(string code)
        {
            return _mappings.Where(i => i.Key == code).FirstOrDefault().Value;
        }

        public static List<string> GetMappings(List<string> codes)
        {
            return _mappings.Where(i => codes.Contains(i.Key)).Select(i => i.Value).ToList();
        }
    }
}
