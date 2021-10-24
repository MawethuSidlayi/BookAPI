using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Domain.Models
{
    public class BookSubscriptions: BaseEntity
    {
        public Guid User_Id { get; set; }
        public int Book_Id{ get; set; }
    }
}
