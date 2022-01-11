//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public abstract class DataPattern<T>
        where T : unmanaged
    {
        protected readonly Index<T> Cells;

        protected DataPattern(T[] cells)
        {
            Cells = cells;
        }
    }
}