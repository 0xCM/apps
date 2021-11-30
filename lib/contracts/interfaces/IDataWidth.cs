//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public interface IDataWidth : IBitWidth, ITextual
    {
        DataWidth DataWidth {get;}

        TypeSignKind TypeSign
            => TypeSignKind.Unsigned;


        uint IBitWidth.BitWidth
            => (uint)DataWidth;

        string ITextual.Format()
            => DataWidth.FormatValue();
    }

    public interface IDataWidth<W> : IDataWidth, IEquatable<W>
        where W : struct, IDataWidth<W>
    {

    }
}