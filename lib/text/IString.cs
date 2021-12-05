//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IString : ITyped, ITextual, IMeasured
    {

    }

    public interface IString<T> : IString, IContented<T>
    {

    }
}