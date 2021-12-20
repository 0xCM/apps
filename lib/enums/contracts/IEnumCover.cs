//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public interface IEnumCover<E> : ILiteralCover<E>
        where E : unmanaged, Enum
    {

    }

    public interface IEnumCover<C,E> : IEnumCover<E>
        where E : unmanaged, Enum
        where C : struct
    {

    }
}