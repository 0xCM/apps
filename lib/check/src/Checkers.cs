//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;

    using static core;

    public readonly struct Checkers
    {
        public static Type[] types(params Assembly[] src)
            => src.Types().Tagged<CheckerAttribute>().Concrete();

        public static ICheckService[] services(IWfRuntime wf, params Assembly[] src)
        {
            var types = Checkers.types(core.controller());
            var dst = list<ICheckService>();
            foreach(var type in types)
            {
                var factories = type.StaticMethods().Where(x => x.Name == "create");
                if(factories.Length == 1)
                {
                    var service = (ICheckService)first(factories).Invoke(null, new object[]{wf});
                    dst.Add(service);
                }
            }
            return dst.ToArray();
        }
    }
}