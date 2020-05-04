using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Cars.Models;

namespace Cars
{
    public class YearOfIssue
    {
        public YearOfIssue()
        {
           ModelCarYear = new HashSet<ModelCarYear>();
        }

        public int Id { get; set; }
        public int Year { get; set; }

        public virtual ICollection<ModelCarYear> ModelCarYear { get; set; }

    }
}
