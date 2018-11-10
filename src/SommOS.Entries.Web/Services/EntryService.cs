using AutoMapper;
using SommOS.Entries.Core.Interfaces;
using SommOS.Entries.Web.Models;
using SommOS.Entries.Web.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SommOS.Entries.Web.Services
{
    public class EntryService : IEntryService
    {
        private readonly IEntryRepository _entryRepository;

        public EntryService(IEntryRepository entryRepository)
        {
            _entryRepository = entryRepository;
        }

        public List<Varietal> GetEntryVarietals(Guid entryId)
        {
            List<Varietal> mappedVarietals = new List<Varietal>();
            var varietals = _entryRepository.GetEntryVarietals(entryId);

            foreach(var v in varietals)
            {
                mappedVarietals.Add(Mapper.Map<Varietal>(v));
            }

            return mappedVarietals;
        }

        public string GetEntryWineLabelBase64(Guid entryId)
        {
            var bytes = _entryRepository.GetEntryWineLabel(entryId);
            var base64 = Convert.ToBase64String(bytes);
            return base64;
        }

        public Task<List<Entry>> GetUserEntries(Guid userId)
        {
            List<Entry> mapped = new List<Entry>();
            var entries = _entryRepository.GetEntries(userId);
            
            foreach (var e in entries)
            {
                mapped.Add(Mapper.Map<Entry>(e));
            }

            return Task.FromResult(mapped);
        }
    }
}
