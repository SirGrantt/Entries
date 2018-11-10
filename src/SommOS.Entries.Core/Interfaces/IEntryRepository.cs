using SommOS.Entries.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SommOS.Entries.Core.Interfaces
{
    public interface IEntryRepository
    {
        EntryEntity GetEntryById(Guid entryId);
        List<EntryEntity> GetEntries(Guid userId);
        List<VarietalEntity> GetEntryVarietals(Guid entryId);
        byte[] GetEntryWineLabel(Guid entryId);
        void AddEntry(EntryEntity entry);
        void UpdateEntry(EntryEntity entry);
    }
}
