using Application.Features.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Form.Queries.Response
{
    public class GetAllFormsQueryResponse
    {
        public virtual List<GetFormDTO> Forms { get; set; }
        
    }
}
