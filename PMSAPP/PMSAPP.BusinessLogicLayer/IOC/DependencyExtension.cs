using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Extension;
using Unity;
using PMSAPP.DataAccessLayer.Implementation;
using PMSAPP.DataAccessLayer.Abstract;
using PMSAPP.Entities;

namespace PMSAPP.BusinessLogicLayer.IOC
{
    public class DependencyExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            this.Container.RegisterType<
                IDataAccess<Product>, ProductDataAccessComponent>();
        }
    }
}
