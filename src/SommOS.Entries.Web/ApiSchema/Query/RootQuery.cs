using GraphQL.Types;
using SommOS.Entries.Web.ApiSchema.Types.EntryTypes;
using SommOS.Entries.Web.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SommOS.Entries.Web.ApiSchema.Query
{
    public class RootQuery : ObjectGraphType<object>
    {
        public RootQuery(IEntryService entryService)
        {
            Name = "entries";
            FieldAsync<ListGraphType<EntryType>>(
                "entries",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "userId" }),
                resolve: async context =>
                {
                    var id = context.GetArgument<Guid>("userId");
                    return await context.TryAsyncResolve(
                        async c => await entryService.GetUserEntries(id));
                });
        }
    }
}
