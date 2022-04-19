//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static core;

    public interface IStringFormatter
    {
        string Format(ReadOnlySpan<byte> src);
    }

    public interface IStringFormatter<T> : IStringFormatter
        where T : unmanaged
    {
        string Format(ReadOnlySpan<T> src);

        string IStringFormatter.Format(ReadOnlySpan<byte> src)
            => Format(recover<T>(src));
    }
}