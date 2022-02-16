//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public sealed class AsmPrefixTokens : TokenSet<AsmPrefixTokens>
    {
        public override string Name
            => "asm.prefixes";

        public override Type[] Types()
            => typeof(AsmPrefixCodes).GetNestedTypes().Enums().Tagged<SymSourceAttribute>();
    }
}