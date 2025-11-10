using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Groups : BaseEntity
    {
        public string name { get; set; }
        public string teacher { get; set; }
        public int room { get; set; }
    }
}
