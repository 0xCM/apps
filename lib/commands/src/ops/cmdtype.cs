//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;

    partial struct Cmd
    {
        [Op]
        public static CmdTypeInfo cmdtype(Type src)
            => new CmdTypeInfo(src, src.DeclaredInstanceFields());

        public static CmdTypeInfo<T> cmdtype<T>()
            where T : struct, ICmd<T>
                => default;

        [Op]
        public static Index<CmdTypeInfo> cmdtypes(Assembly[] src)
            => src.Types().Tagged<CmdAttribute>().Select(cmdtype);
    }
}