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
        public AssetMaintenance(int mainId,string description, DateTime plannedDate)
        {
            this.MaintenanceID = mainId;
            this.MaintenanceDescription = description;
            this.PlannedMaintenanceDate = plannedDate;
            this.maintenanceStatus = MaintenanceStatus.Planned;

        }
        // METHODS
        public void PlanMaintenance()
        {
            // DO STUFF
        }

        public void CompleteMaintenance()
        {
            maintenanceStatus = MaintenanceStatus.Done;
        }

        public void PerformMaintenance()
        {
            maintenanceStatus = MaintenanceStatus.InProgress;
        }
    }
}
