//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    public sealed class AsmSigTokenSet : TokenSet<AsmSigTokenSet>
    {
        public override string Name
            => "asm.sigs";

        public override Type[] Types()
            => typeof(AsmSigTokens).GetNestedTypes().Enums().Tagged<SymSourceAttribute>();
    }
}