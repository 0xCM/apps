//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct AsmOpCodeSpec : IAsmOpCode<AsmOpCodeSpec>
    {
        readonly Index<AsmOcToken> Data;

        [MethodImpl(Inline)]
        public AsmOpCodeSpec(AsmOcToken[] tokens)
        {
            Data = tokens;
        }

        public ReadOnlySpan<AsmOcToken> Tokens
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        [MethodImpl(Inline)]
        public static implicit operator AsmOpCodeSpec(AsmOcToken[] src)
            => new AsmOpCodeSpec(src);

        public static AsmOpCodeSpec Empty => new AsmOpCodeSpec(sys.empty<AsmOcToken>());
    }
}