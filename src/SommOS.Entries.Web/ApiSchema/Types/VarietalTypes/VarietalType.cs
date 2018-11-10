using GraphQL.Types;
using SommOS.Entries.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SommOS.Entries.Web.ApiSchema.Types.VarietalTypes
{
    public class VarietalType : ObjectGraphType<Varietal>
    {
        public VarietalType()
        {
            Field(v => v.Name);
            Field(v => v.Percentage, type: typeof(DecimalGraphType));
            Field(v => v.Id, type: typeof(IdGraphType));
        }
    }
}
