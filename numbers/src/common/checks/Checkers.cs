//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public readonly struct Checkers
    {
        public static Type[] types(params Assembly[] src)
            => src.Types().Tagged<CheckerAttribute>().Concrete();

        public static ConstLookup<Identifier,ICheckService> discover(IWfRuntime wf, params Assembly[] src)
        {
            var dst = list<ICheckService>();
            foreach(var type in types(src))
            {
                var factories = type.StaticMethods().Where(x => x.Name == "create");
                if(factories.Length == 1)
                    dst.Add((ICheckService)first(factories).Invoke(null, new object[]{wf}));
            }
            return dst.ToArray().Select(x => (x.Name, x)).ToConstLookup();
        }
    }
}