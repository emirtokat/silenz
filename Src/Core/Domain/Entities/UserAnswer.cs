using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserAnswer : Entity
    {
        public int AnswerId { get; set; }
        public virtual Answer Answer { get; set; }
        public string Name { get; set; }

    }
}
