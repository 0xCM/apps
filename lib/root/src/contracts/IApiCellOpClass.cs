//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IApiCellOpClass<F,W,E> : ICellFunctionClass, IOperationClassHost<F,E>
        where F : struct, IApiCellOpClass<F,W,E>
        where W : unmanaged, ITypeWidth
        where E : unmanaged, Enum
    {
        NativeTypeWidth ICellFunctionClass.Width
            => Widths.type<W>();
    }
}