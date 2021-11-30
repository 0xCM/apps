//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IDynamicRow
    {
        dynamic[] Cells {get;}

        uint RowIndex {get;}
    }

    [Free]
    public interface IDynamicRow<T> : IDynamicRow
        where T : struct
    {
        T Source {get;}
    }
}