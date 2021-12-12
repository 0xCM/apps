//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public enum TypeRelationKind : byte
    {
        None = 0,

        Cover,

        Subtype,

        Surrogate,

        Refinement,

    }
}