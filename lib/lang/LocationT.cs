//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public interface IStore
    {

    }

    public interface IStore<T> : IStore
    {
        ILocation Deposit(T value);

        T Retrieve(ILocation key);
    }



    public interface ILocation
    {

    }

    public interface ILocation<S> : ILocation
        where S : IStore
    {

    }

}