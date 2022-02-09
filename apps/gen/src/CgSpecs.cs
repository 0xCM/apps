//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct CgSpecs
    {
        public static CgSpec define(string ns, params string[] usings)
            => new CgSpec(ns,usings);

        public static CgSpec<T> define<T>(string ns, string[] usings, T body)
            => new CgSpec<T>(ns, usings, body);

        public static SwitchMap<S,T> @switch<S,T>(string name, S[] src, T[] dst)
            where S : unmanaged
            where T : unmanaged
                => new SwitchMap<S,T>(name,src,dst);
    }
}