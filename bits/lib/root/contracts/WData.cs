//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public interface WData<W> : IDataWidth<W>
        where W : struct, WData<W>
    {
        DataWidth IDataWidth.DataWidth
            => (DataWidth)Widths.data<W>();

        bool IEquatable<W>.Equals(W src)
            => src.BitWidth == BitWidth;
    }
}