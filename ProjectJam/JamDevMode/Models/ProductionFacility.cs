using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectJam.Models
{
    public class ProductionFacility
    {
        public enum FacilityStatus { Good, Working, Broken }

        public FacilityStatus Status { get; set; }

        public void CheckFacility()
        {

        }
    }
}
