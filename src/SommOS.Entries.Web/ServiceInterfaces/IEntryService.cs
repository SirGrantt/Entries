using SommOS.Entries.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SommOS.Entries.Web.ServiceInterfaces
{
    public interface IEntryService
    {
        string GetEntryWineLabelBase64(Guid entryId);
        List<Entry> GetUserEntries(Guid userId);
        List<Varietal> GetEntryVarietals(Guid entryId);
    }
}
