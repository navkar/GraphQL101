using GraphQL.Types;
using GraphQL101.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL101.Models
{
    /// <summary>
    /// register the ItemType in our root query object
    /// </summary>
    public class ItemType : ObjectGraphType<Item>
    {
        public ItemType()
        {
            Field(i => i.Barcode);
            Field(i => i.Title);
            Field(i => i.SellingPrice);
        }
    }
}
