using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntsoE_DataModel
{
    public static class DocumentType
    {
        static Dictionary<string, string> _mappings = new Dictionary<string, string>();

        public enum Key
        {
            A09,
            A11,
            A25,
            A26,
            A31,
            A44,
            A61,
            A63,
            A65,
            A68,
            A69,
            A70,
            A71,
            A72,
            A73,
            A74,
            A75,
            A76,
            A77,
            A78,
            A79,
            A80,
            A81,
            A82,
            A83,
            A84,
            A85,
            A86,
            A87,
            A88,
            A89,
            A90,
            A91,
            A92,
            A93,
            A94,
            A95,
            B11
        }

        static DocumentType()
        {
            _mappings.Add("A09", "Finalised schedule");
            _mappings.Add("A11", "Aggregated energy data report");
            _mappings.Add("A25", "Allocation result document");
            _mappings.Add("A26", "Capacity document");
            _mappings.Add("A31", "Agreed capacity");
            _mappings.Add("A44", "Price Document");
            _mappings.Add("A61", "Estimated Net Transfer Capacity");
            _mappings.Add("A63", "Redispatch notice");
            _mappings.Add("A65", "System total load");
            _mappings.Add("A68", "Installed generation per type");
            _mappings.Add("A69", "Wind and solar forecast");
            _mappings.Add("A70", "Load forecast margin");
            _mappings.Add("A71", "Generation forecast");
            _mappings.Add("A72", "Reservoir filling information");
            _mappings.Add("A73", "Actual generation");
            _mappings.Add("A74", "Wind and solar generation");
            _mappings.Add("A75", "Actual generation per type");
            _mappings.Add("A76", "Load unavailability");
            _mappings.Add("A77", "Production unavailability");
            _mappings.Add("A78", "Transmission unavailability");
            _mappings.Add("A79", "Offshore grid infrastructure unavailability");
            _mappings.Add("A80", "Generation unavailability");
            _mappings.Add("A81", "Contracted reserves");
            _mappings.Add("A82", "Accepted offers");
            _mappings.Add("A83", "Activated balancing quantities");
            _mappings.Add("A84", "Activated balancing prices");
            _mappings.Add("A85", "Imbalance prices");
            _mappings.Add("A86", "Imbalance volume");
            _mappings.Add("A87", "Financial situation");
            _mappings.Add("A88", "Cross border balancing");
            _mappings.Add("A89", "Contracted reserve prices");
            _mappings.Add("A90", "Interconnection network expansion");
            _mappings.Add("A91", "Counter trade notice");
            _mappings.Add("A92", "Congestion costs");
            _mappings.Add("A93", "DC link capacity");
            _mappings.Add("A94", "Non EU allocations");
            _mappings.Add("A95", "Configuration document");
            _mappings.Add("B11", "Flow-based allocations");
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
