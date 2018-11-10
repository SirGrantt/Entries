using SommOS.Entries.Web.ApiSchema.Types.VarietalTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SommOS.Entries.Web.ApiSchema.Types.EntryTypes
{
    public class EntryInput
    {
        public Guid UserId { get; set; }
        public string WineName { get; set; }
        public string Notes { get; set; }
        public string Producer { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string Vintage { get; set; }
        public List<string> Tags { get; set; }
        public List<VarietalInput> Varietals { get; set; }
        public string WineLabel { get; set; }
    }
}
