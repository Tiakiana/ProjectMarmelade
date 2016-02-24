using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class Factory
    {
        public static Factory factory;

        public static Factory GetFactory() {
            if (factory == null)
            {
                factory = new Factory();
                
            }
            return factory;
        }
        public QualityTestFactory GetQTF() {
            return factory.GetQTF();
        } 

        //internal QualityTestFactory qtf;
   
       


    }
}
