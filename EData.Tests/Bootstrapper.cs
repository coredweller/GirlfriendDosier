using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;
using Core.Infrastructure;

namespace EData.Tests
{
    public static class Bootstrapper
    {
        public static void Bootstrap() {
            //setup IoC container
            ObjectFactory.Initialize(x =>
            {
                x.AddRegistry(new Core.CoreRegistry());
                x.AddRegistry(new EData.EDataRegistry());
            });

            Ioc.InitializeWith(new DependencyResolverFactory(new DependencyResolver()));
        }

        public static void CheckConfiguration() {
            ObjectFactory.AssertConfigurationIsValid();
            System.Diagnostics.Debug.Write(ObjectFactory.WhatDoIHave());
        }
    }
}
