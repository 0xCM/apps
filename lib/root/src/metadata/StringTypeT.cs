//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Root;

    public abstract class StringType<T> : DataType<T>
        where T : StringType<T>, new()
    {

    }
}