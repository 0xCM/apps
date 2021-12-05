//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct Clr
    {
        /// <summary>
        /// Queries the host type for a <see cref='ClrInterfaceMap'/>
        /// </summary>
        /// <param name="host">The reifying type</param>
        /// <param name="contract">The contract type</param>
        [MethodImpl(Inline), Op]
        public static ClrInterfaceMap imap(Type host, Type contract)
        {
            var src = host.InterfaceMap(contract);
            var dst = new ClrInterfaceMap();
            dst.Specs = src.InterfaceMethods;
            dst.SpecType = src.InterfaceType;
            dst.Impl = src.TargetMethods;
            dst.ImplType = src.TargetType;
            return dst;
        }

        public static ClrInterfaceMap imap<H,C>()
            where C : class
                => imap(typeof(H), typeof(C));
    }
}