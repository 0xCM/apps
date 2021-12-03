//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [SymSource]
    public enum ScalarClass : byte
    {
        None,

        [Symbol("u")]
        U = 1,

        [Symbol("i")]
        I = 2,

        [Symbol("f")]
        F = 4,

        [Symbol("c")]
        C = 8,
    }
}

