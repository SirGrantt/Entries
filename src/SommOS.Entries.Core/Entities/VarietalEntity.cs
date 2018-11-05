using System;
using System.Collections.Generic;
using System.Text;

namespace SommOS.Entries.Core.Entities
{
    public class VarietalEntity
    {
        public string Name { get; set; }
        public decimal Percentage { get; set; }
        public Guid Id { get; set; }

        public Guid EntryId { get; set; }
        public EntryEntity Entry { get; set; }
    }
}
