using Abp.Dependency;
using GraphQL;
using GraphQL.Types;
using Hitechsoft.CRM.Queries.Container;

namespace Hitechsoft.CRM.Schemas
{
    public class MainSchema : Schema, ITransientDependency
    {
        public MainSchema(IDependencyResolver resolver) :
            base(resolver)
        {
            Query = resolver.Resolve<QueryContainer>();
        }
    }
}