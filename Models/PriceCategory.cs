using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Cars.Models;

namespace Cars.Models
{
    public class PriceCategory
    {
        public PriceCategory()
        {
            ModelCar = new HashSet<ModelCar>();
        }
        public int Id { get; set; }
        public string Price { get; set; }
        public virtual ICollection<ModelCar> ModelCar { get; set; }
    }
}
