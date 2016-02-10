using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{       enum MaintenanceStatus { Planned, InProgress, Done};
    class AssetMaintenance
    {
        // Properties
        private int MaintenanceID { get; set; }
        private string MaintenanceDescription { get; set; }
        private DateTime PlannedMaintenanceDate { get; set; }
        private MaintenanceStatus maintenanceStatus { get; set; }
        
        // Constructors
        public AssetMaintenance()
        {
            this.MaintenanceID = 1;// GET auto incremented ID from DB
            this.MaintenanceDescription = "NOT APPLIED";
            this.PlannedMaintenanceDate = DateTime.Today;
            this.maintenanceStatus = MaintenanceStatus.Planned;

        }
        // METHODS
        public void PlanMaintenance()
        {
            // DO STUFF
        }
        public void MaintenanceDone()
        {
            // DO STUFF
        }

        //public void PerformMaintenance()
        //{
        //    // DO STUFF
        //}
    }
}
