//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IString : IValue, ITextual, IMeasured, ITerm
    {

    }

    public interface IString<T> : IString, ITerm<T>
    {

    }

    public interface IString<K,T> : IString<T>
        where K : unmanaged
    {

    }
}