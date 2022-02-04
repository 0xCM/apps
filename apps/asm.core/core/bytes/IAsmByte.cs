//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    public interface IAsmByte : ITextual, INullity
    {
        byte Value();

        bool INullity.IsEmpty
            => Value() == 0;
    }

    public interface IAsmByte<T> : IAsmByte, IEquatable<T>, IComparable<T>
        where T : unmanaged, IAsmByte<T>
    {
        string ITextual.Format()
            => AsmBytes.format((T)this);

        bool IEquatable<T>.Equals(T other)
            => Value() == other.Value();

        int IComparable<T>.CompareTo(T other)
            => Value().CompareTo(other.Value());
    }
}