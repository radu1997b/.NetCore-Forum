using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.DAL.Domain
{
    public abstract class Entity
    {
        public long Id { get; set; }
        public DateTime CreationDate { get; private set; } = DateTime.Now;
    }
}
