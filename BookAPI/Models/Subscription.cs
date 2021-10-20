using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Models
{
    public class Subscription: BaseEntity
    {
        public int UserId { get; set; }
        public int BookId { get; set; }
    }
}
