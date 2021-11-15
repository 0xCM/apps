//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static math;
    using static Root;

    [ApiComplete]
    public struct BitsF128
    {
        Vector128<ulong> Data;

        public ulong LoBits
        {
            [MethodImpl(Inline)]
            get => Data.GetElement(0);
        }

        public ulong HiBits
        {
            [MethodImpl(Inline)]
            get => Data.GetElement(1);
        }

        [MethodImpl(Inline)]
        internal BitsF128(decimal src)
        {
            Data = core.@as<decimal,Vector128<ulong>>(src);
        }
    }
}