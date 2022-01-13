//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection;

    partial struct Cmd
    {
        [Op]
        public static Type[] types(params Assembly[] src)
            =>  src.Types().Tagged<CmdAttribute>();
    }
}