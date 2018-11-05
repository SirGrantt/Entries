using System;
using System.Collections.Generic;
using System.Text;

namespace SommOS.Entries.Core.Entities
{
    public class EntryLabelEntity
    {
        public Guid Id { get; set; }
        public byte[] Image { get; set; }

        public Guid EntryId { get; set; }
        public EntryEntity Entry { get; set; }
    }
}
