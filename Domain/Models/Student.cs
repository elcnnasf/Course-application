using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Student : BaseEntity
    {
        public string name { get; set; }
        public string surname { get; set; }
        public int age { get; set; }
        public Groups group { get; set; }

    }
}
