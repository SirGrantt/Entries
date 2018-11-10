using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SommOS.Entries.Web.Models
{
    public class Varietal
    {
        public string Name { get; set; }
        public decimal Percentage { get; set; }
        public Guid Id { get; set; }
        public Guid EntryId { get; set; }
    }
}
