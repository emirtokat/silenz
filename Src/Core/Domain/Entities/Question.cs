using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Question : Entity
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public int FormId { get; set; } 

        public virtual Form Form { get; set; }
        public List<QuestionOpt> QuestionOpts { get; set; }

    }
}
