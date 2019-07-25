using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntsoE_DataModel
{
    public static class BSN_Mapping
    {
        static Dictionary<string, string> _mappings = new Dictionary<string, string>();

        public enum Key
        {
            A29,
            A43,
            A46,
            A53,
            A54,
            A85,
            A95,
            A96,
            A97,
            A98,
            B01,
            B02,
            B03,
            B04,
            B05,
            B07,
            B08,
            B09,
            B10,
            B11
        }

        static BSN_Mapping()
        {
            _mappings.Add("A29", "Already allocated capacity (AAC)");
            _mappings.Add("A43", "Requested capacity (without price)");
            _mappings.Add("A46", "System Operator redispatching");
            _mappings.Add("A53", "Planned maintenance");
            _mappings.Add("A54", "Unplanned outage");
            _mappings.Add("A85", "Internal redispatch");
            _mappings.Add("A95", "Frequency containment reserve");
            _mappings.Add("A96", "Automatic frequency restoration reserve");
            _mappings.Add("A97", "Manual frequency restoration reserve");
            _mappings.Add("A98", "Replacement reserve");
            _mappings.Add("B01", "Interconnector network evolution");
            _mappings.Add("B02", "Interconnector network dismantling");
            _mappings.Add("B03", "Counter trade");
            _mappings.Add("B04", "Congestion costs");
            _mappings.Add("B05", "Capacity allocated (including price)");
            _mappings.Add("B07", "Auction revenue");
            _mappings.Add("B08", "Total nominated capacity");
            _mappings.Add("B09", "Net position");
            _mappings.Add("B10", "Congestion income");
            _mappings.Add("B11", "Production unit");
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
