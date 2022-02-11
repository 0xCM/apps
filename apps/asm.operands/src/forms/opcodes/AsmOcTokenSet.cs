//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public sealed class AsmOcTokenSet : TokenSet<AsmOcTokenSet,AsmOcTokenKind>
    {
        public override string Name
            => "asm.opcodes";

        public override Type[] Types()
            => typeof(AsmOcTokens).GetNestedTypes().Enums().Tagged<SymSourceAttribute>();
    }
}