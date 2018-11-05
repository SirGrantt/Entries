using SommOS.Entries.Core.Entities;
using SommOS.Entries.Core.Interfaces;
using SommOS.Entries.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SommOS.Entries.Infrastructure.Repositories
{
    public class EntryRepository : IEntryRepository
    {
        private readonly EntriesContext _context;

        public EntryRepository(EntriesContext context)
        {
            _context = context;
        }

        public void AddEntry(EntryEntity entry)
        {
            _context.Entries.Add(entry);
        }

        public List<EntryEntity> GetEntries(Guid userId)
        {
            return _context.Entries.Where(e => e.UserId == userId).ToList();
        }

        public EntryEntity GetEntryById(Guid entryId)
        {
            return _context.Entries.Where(e => e.Id == entryId).AsNoTracking().FirstOrDefault();
        }

        public void UpdateEntry(EntryEntity entry)
        {
            throw new NotImplementedException();
        }
    }
}
