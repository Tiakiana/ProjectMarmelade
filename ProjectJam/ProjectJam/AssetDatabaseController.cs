using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Domain
{
    class AssetDatabaseController
    {   
        // Properties
        private SqlConnection AssetConnection { get; set; }

        //Methods
        public void InsertAsset()
        {
            // DO STUFF
        }
        public void ShowAssetInfo()
        {
            // DO STUFF
        }
        public void PlanMaintenance()
        {
            // DO STUFF
        }
        public void MaintenanceDone()
        {
            // DO STUFF
        }

        public Asset LoadAsset(int id)
        {
            // DO STUFF
            // StoredProcedureCall
            return someAsset;
        }
        public void SaveAsset(Asset saveasset)
        {
            // DO STUFF
            // StoredProcedureCall
        }

    }
}
