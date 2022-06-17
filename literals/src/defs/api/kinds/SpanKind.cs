//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [SymSource("api.kinds")]
    public enum SpanKind
    {
        None = 0,

        Mutable = 1,

        Immutable = 2,

        Custom = 3
    }
}