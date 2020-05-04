using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cars.Models
{
    public class BodyType
    {
        public BodyType()
        {
            ModelCar = new HashSet<ModelCar>();
        }
        public int Id { get; set; }
        public string TypeName { get; set; }
        public virtual ICollection<ModelCar> ModelCar { get; set; }
    }
}
