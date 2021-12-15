//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using NBK = NumericBaseKind;

    [SymSource("api.kinds", NBK.Base16), Flags]
    public enum ParamDirection : byte
    {
        None = 0,

        [Symbol("in")]
        In = 1,

        [Symbol("out")]
        Out = 2,

        [Symbol("inout")]
        Bidirectional = In | Out,
    }
}