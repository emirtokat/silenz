using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class QuestionOpt : Core.Persistence.Repositories.Entity
    {
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
        public string Name { get; set; }
    }
}
