using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Cars.Models;

namespace Cars
{
    public class ModelCarYear
    {
 
        public int Id { get; set; }
        public int IdCar { get; set; }
        public int IdYear { get; set; }
        public virtual ModelCar IdCarNavigation { get; set; }
        public virtual YearOfIssue IdYearNavigation { get; set; }
    }
}
