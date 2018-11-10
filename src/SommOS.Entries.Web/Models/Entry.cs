using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SommOS.Entries.Web.Models
{
    public class Entry
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string WineName { get; set; }
        public string Notes { get; set; }
        public string Producer { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string Vintage { get; set; }
        public List<string> Tags { get; set; }
        public List<Varietal> Varietals { get; set; }
        public DateTimeOffset DateAdded { get; set; }
        public DateTimeOffset LastModified { get; set; }
        public string WineLabel { get; set; }
    }
}
