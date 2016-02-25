using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectJam.Models
{
    interface IPlan
    {
        Product Item { get; }

        int NumberOfProduct { get; }

        int SaleRevenue();

        int ResourceRequirement(Resource ingredient);

        Dictionary<Resource, int> ResourceUsage();


    }
}
