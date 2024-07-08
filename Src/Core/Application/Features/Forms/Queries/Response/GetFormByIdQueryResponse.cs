using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Form.Queries.Response
{
    public class GetFormByIdQueryResponse
    {
        public string Title { get; set; }
        public virtual List<Question> Questions { get; set; }
        public String OperatorName{ get; set; }
    }
}
