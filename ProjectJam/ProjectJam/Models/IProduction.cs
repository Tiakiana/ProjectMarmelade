using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectJam.Models
{
    interface IProduction
    {
        /// <summary>
        /// Production cost
        /// </summary>
        double TotalCost { get; }
        /// <summary>
        /// Total production time for a product
        /// </summary>
        TimeSpan TotalTime { get; }
        /// <summary>
        /// Container Mass (Weight per kg)
        /// </summary>
        double ContainerMass { get; set; }
        /// <summary>
        /// Speed per Container
        /// </summary>
        TimeSpan SpeedPerContainer { get; set; }
        /// <summary>
        /// Number of glass per hour
        /// </summary>
        int GlassPerHour { get; set; }
        /// <summary>
        /// Target product for production
        /// </summary>
        Product TargetProduct { get; set; }
        
    }
}
