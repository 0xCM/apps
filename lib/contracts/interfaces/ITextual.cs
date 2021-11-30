//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public interface ITextual
    {
        string Format();
    }

    public interface ILexical : ITextual
    {
        int CompareTo(ILexical src)
            => Format().CompareTo(src.Format());
    }

    public interface ILexical<T> : ILexical, IComparable<T>
        where T : ILexical<T>, ITextual
    {
        int IComparable<T>.CompareTo(T src)
            => Format().CompareTo(src.Format());
    }
}