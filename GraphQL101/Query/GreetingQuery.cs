using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using GraphQL101.Models;

namespace GraphQL101.Query
{
    /// <summary>
    /// All queries are subclassed from ObjectGraphType
    /// </summary>
    public class GreetingQuery : ObjectGraphType
    {
        public GreetingQuery()
        {
            // Fields are defined in the constructor of the query class.
            Field<StringGraphType>(
                name: "steve",
                resolve: context => "Hi, Steve"
            );

            Field<StringGraphType>(
                name: "naveen",
                resolve: context => "Hi, Naveen"
            );

            Field<ItemType>(
                "sample",
                resolve: context =>
                {
                    return new Item
                    {
                        Barcode = "123",
                        Title = "Headphone",
                        SellingPrice = 12.99M
                    };
                }
            );

            //Field<ItemType>(
            //    "item",
            //    arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "barcode" }),
            //    resolve: context =>
            //    {
            //        var barcode = context.GetArgument<string>("barcode");
            //        return new DataSource().GetItemByBarcode(barcode);
            //    }
            //);
        }
    }
}
