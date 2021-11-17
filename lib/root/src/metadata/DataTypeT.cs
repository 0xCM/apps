//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public abstract class DataType<T>
        where T : DataType<T>, new()
    {
        public virtual bool IsFixedWidth {get;}
    }
}