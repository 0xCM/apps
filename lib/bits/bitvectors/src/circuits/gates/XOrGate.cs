//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    partial class LegacyCircuits
    {
        public readonly struct XOrGate : IBinaryGate
        {
            [MethodImpl(Inline)]
            public bit Invoke(bit x, bit y)
                => (x ^ y);
        }
    }
}