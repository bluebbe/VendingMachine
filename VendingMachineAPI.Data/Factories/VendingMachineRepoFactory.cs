using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VendingMachineAPI.Data.Interfaces;
using VendingMachineAPI.Data.MockRepository;
using VendingMachineAPI.Data.ADO;

namespace VendingMachineAPI.Data.Factories
{
    public class VendingMachineRepoFactory
    {
        public static IVendingMachine GetRepository()
        {
            switch(Settings.GetRepositoryType())
            {
                case "MEMORY":
                    return new VendingMachineMockRepository();
                case "ADO":
                    return new VendingMachineADORepository();
                default: throw new Exception("Could not find valid Repository configuration value");

            }
        }
    }
}