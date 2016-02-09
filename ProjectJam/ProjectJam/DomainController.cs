using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class DomainController
    {
        static DomainController dct = null;
        public static DomainController getDCT()
        {
            if (dct == null)
            {
                dct = new DomainController();
            }
            return dct;
        }
        public DomainController()
        {

        }

        public QualityTestController GetQualityTestController() {
            return QualityTestController.getQTC();
        }
        public void onStart(string type)
        {
            switch (type)
            {
                case "M1":
                    Persistance.DBController.setController(PersistanceTypes.Persistance1);
                    break;
                case "M2":
                    Persistance.DBController.setController(PersistanceTypes.Persistance2);
                    break;
                default:
                    throw new Exception("There is no such persistance available");
            }

        }
    }
}
