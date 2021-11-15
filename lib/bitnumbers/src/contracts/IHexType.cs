//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public interface IHexType
    {
        Hex8Seq Value {get;}
    }


    public interface IHexType<H> : IHexType
        where H : unmanaged, IHexType<H>
    {
        Type Reified
            => typeof(H);
    }
}