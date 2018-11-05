using SommOS.Entries.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SommOS.Entries.Core.Interfaces
{
    public interface IEntryRepository
    {
        List<EntryEntity> GetEntries(Guid userId);
        EntryEntity GetEntryById(Guid entryId);
        void AddEntry(EntryEntity entry);
        void UpdateEntry(EntryEntity entry);
    }
}
