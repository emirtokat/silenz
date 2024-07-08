using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Dtos
{
    public class GetOperatorDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Domain.Entities.Form> Forms{ get; set; }

    }
}
