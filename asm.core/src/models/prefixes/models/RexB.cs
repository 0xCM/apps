//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static AsmOpCodeTokens;

    public struct RexB
    {
        readonly byte Value;

        [MethodImpl(Inline)]
        internal RexB(RexBToken token, RegIndexCode r)
        {
            Value = math.or((byte)token, math.sll((byte)r,3));
        }

        public bit Enabled
        {
            [MethodImpl(Inline)]
            get => emath.lteq(Token, RexBToken.ro);
        }

        public RexBToken Token
        {
            [MethodImpl(Inline)]
            get => (RexBToken)((byte)Value & 0b111);
        }

        public RegIndex Reg
        {
            [MethodImpl(Inline)]
            get => math.srl((byte)Value,3);
        }
    }
}