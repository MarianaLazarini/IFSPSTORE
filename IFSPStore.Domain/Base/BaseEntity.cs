using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFSPStore.Domain.Base
{
    public abstract class BaseEntity<TID> : IBaseEntity//a clase já vai ter o entity inserida
    {
        protected BaseEntity()
        {

        }
        protected BaseEntity(TID id)
        {
            Id = id;
        }
        public TID? Id { get; set; }
    }
}
