//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial struct Cmd
    {
        internal const ushort MaxVarCount = 255;

        [Op]
        public static CmdVars vars(ushort count)
            => new CmdVar[count];

        public static CmdVars vars(params Pair<string>[] src)
        {
            var dst = new CmdVar[MaxVarCount];
            var count = min(src.Length,src.Length);
            for(var i=0; i<count; i++)
                seek(dst,i) = skip(src,i);
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static CmdVars vars(CmdVar[] src)
            => src;

        [Op]
        public static CmdVars vars()
            => new CmdVar[MaxVarCount];

        [Op, Closures(Closure)]
        public static Index<CmdVar<K>> vars<K>()
            where K : unmanaged
                => new CmdVar<K>[MaxVarCount];
    }
}