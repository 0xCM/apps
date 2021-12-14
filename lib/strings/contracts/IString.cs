//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IString : IValue, ITextual, IMeasured
    {

    }

    public interface IString<T> : IString, IValue<T>
    {

    }

    public interface IString<K,T> : IString<T>, IValue<K,T>
        where K : unmanaged
    {

    }
}