using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cars.Models;


namespace Cars 
{
    public partial class ModelCar
    {
        public ModelCar()
        {
            ModelCarYear = new HashSet<ModelCarYear>();
        }
        public int Id { get; set; }       
        public string ModelName { get; set; }
        public int IdEngine { get; set; }
        public int IdBody { get; set; }
        public int IdPrice { get; set; }
        public virtual BodyType IdBodyNavigation { get; set; }
        public virtual Engine IdEngineNavigation { get; set; }
        public virtual PriceCategory IdPriceNavigation { get; set; }
        public virtual ICollection<ModelCarYear> ModelCarYear { get; set; }
    }
}
