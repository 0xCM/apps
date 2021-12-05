//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection;

    using static Root;

    partial struct Clr
    {
        [MethodImpl(Inline), Op]
        public static Assembly corlib()
            => typeof(uint).Assembly;
    }
}