using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;
using Core.Configuration;
using StructureMap.Configuration.DSL;

namespace Core
{
    public class CoreRegistry : Registry
    {
        public CoreRegistry()
        {
            For<IAppConfigManager>()
                .Singleton()
                .Use<AppConfigManager>();
        }
    }
}
