using System;
using GraphQL;
using GraphQL.Types;
using GraphQL101.Query;

namespace GraphQL101.Schema
{
    public class GreetingSchema : GraphQL.Types.Schema
    {
        public GreetingSchema(GreetingQuery query)
        {
            Query = query;
        }
    }
}
