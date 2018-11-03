using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using SommOS.Entries.Web.ApiSchema.Mutation;
using SommOS.Entries.Web.ApiSchema.Query;

namespace SommOS.Entries.Web.ApiSchema
{
    public class EntriesSchema : Schema
    {
        public EntriesSchema(RootQuery query, RootMutation mutation, IDependencyResolver resolver)
        {
            Query = query;
            Mutation = mutation;
            DependencyResolver = resolver;
        }
    }
}
