//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IDynamicRow
    {
        dynamic[] Cells {get;}
    }

    [Free]
    public interface IDynamicRow<T> : IDynamicRow
        where T : struct
    {

    }
}