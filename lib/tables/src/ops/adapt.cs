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

    partial struct Tables
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref RowAdapter<T> adapt<T>(in T src, ref RowAdapter<T> adapter)
            where T : struct
        {
            adapter.Source = src;
            load(adapter.Fields.Storage, adapter.Index++, adapter.Source, ref adapter.Row);
            return ref adapter;
        }
    }
}