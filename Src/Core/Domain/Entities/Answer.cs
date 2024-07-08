using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Answer : Entity
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Occupation { get; set; }
        public int FormId { get; set; }
        public  virtual Form Form{ get; set; }
        public bool SendFeedBackEmail { get; set; }
        public virtual List<UserAnswer> UserAnswers { get; set; }
    }
}
