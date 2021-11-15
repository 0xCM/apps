//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public interface IUniversal
    {


    }

    public interface IUniversal<U> : IUniversal
    {

    }

    public interface IUniversal<U,S> : IUniversal<U>
        where S : struct
    {

    }
}