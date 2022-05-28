//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static AsmSigTokens;

    public sealed class AsmSigTokenSet : TokenSet<AsmSigTokenSet,AsmSigTokenKind>
    {
        public override string Name
            => "asm.sigs";

        public override Type[] Types()
            => typeof(AsmSigTokens).GetNestedTypes().Enums().Tagged<SymSourceAttribute>();

        public Dictionary<Type,AsmSigTokenKind> TypeKinds()
            => Types().Map(t => (t,(AsmSigTokenKind)t.Tag<SigTokenKind>().Require().Kind)).ToDictionary();

    }
}