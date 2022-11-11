using Avengers_hw.Models;
using Avengers_hw.Repository;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Avengers_hw.Utils
{
    public class NinjectRegulations : NinjectModule
    {
        public override void Load()
        {
            Bind<IHomeRepository>().To<HomeRepository>().WithConstructorArgument("dbEntities", new AvengersEntities());
        }
    }
}