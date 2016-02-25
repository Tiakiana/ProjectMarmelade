using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectJam.Models;

namespace ProjectJam.Controllers
{
    public static class PlanController
    {
        // Generate Production plan
        static ProductionPlan plan = new ProductionPlan();

        static List<ProductionPlan> planList = new List<ProductionPlan>();
        
        public static void DoProductionPlan()
        {
            plan.GeneratePlan();
        }
        

    }
}
