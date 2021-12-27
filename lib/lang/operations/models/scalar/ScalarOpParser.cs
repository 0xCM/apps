//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using Ops;

    using static Root;

    readonly struct ScalarOpParser
    {
        public static Outcome parse(ScalarType type, string src, out ScalarCmpPred dst)
        {
            dst = default;
            return true;
        }
    }
}