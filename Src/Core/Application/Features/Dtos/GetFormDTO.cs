using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Dtos
{
    public class GetFormDTO
    {
        public string Title { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int UserID{ get; set; }
        public int ID{ get; set; }
    }
}
