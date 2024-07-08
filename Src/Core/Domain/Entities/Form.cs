using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Form : Entity
    {

        public string Title { get; set; }
        public virtual List<Question> Questions { get; set; }

        public virtual List<Answer> Answers { get; set; }
        public int OperatorId { get; set; }
        public Operator Operator{ get; set; }

    }
}
