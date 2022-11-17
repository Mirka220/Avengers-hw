﻿using Avengers_hw.Repository;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Avengers_hw.Utils
{
    public class CastleInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer windsorContainer, IConfigurationStore service)
        {
            windsorContainer.Register(Component.For<IHomeRepository>().ImplementedBy<HomeRepository>());

            var controllers = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.BaseType == typeof(Controller)).ToList();
        }
    }
}