using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShop.Data.Entities
{
    public interface IEntity
    {
        int Id { get; set; }

        //string Name { get; set; }
        //bool WasDeleted { get; set; }
    }
}
