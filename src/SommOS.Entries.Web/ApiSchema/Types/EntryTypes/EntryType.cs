using GraphQL.Types;
using SommOS.Entries.Core.Interfaces;
using SommOS.Entries.Web.ApiSchema.Types.VarietalTypes;
using SommOS.Entries.Web.Models;
using SommOS.Entries.Web.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SommOS.Entries.Web.ApiSchema.Types.EntryTypes
{
    public class EntryType : ObjectGraphType<Entry>
    {
        public EntryType(IEntryRepository entryRepository, IEntryService entryService)
        {
            Field(e => e.WineName);
            Field(e => e.Country);
            Field(e => e.Region);
            Field(e => e.Producer);
            Field(e => e.Notes);
            Field(e => e.Vintage);
            Field(e => e.Tags);
            Field(e => e.Id, type: typeof(IdGraphType));
            Field(e => e.UserId, type: typeof(IdGraphType));
            Field(e => e.DateAdded, type: typeof(DateGraphType));
            Field(e => e.LastModified, type: typeof(DateGraphType));
            Field<ListGraphType<VarietalType>>("varietals", resolve: context =>
            {
                return entryRepository.GetEntryVarietals(context.Source.Id);
            });
            Field<StringGraphType>("wineLabel", resolve: context =>
            {
                return entryService.GetEntryWineLabelBase64(context.Source.Id);
            });
        }
    }
}
