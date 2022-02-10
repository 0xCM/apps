//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public sealed class AsmSigTokenSet : TokenSet<AsmSigTokenSet,AsmSigOpKind>
    {
        public override string Name
            => "asm.sigs";

        public override Type[] Types()
            => typeof(AsmSigTokens).GetNestedTypes().Enums().Tagged<SymSourceAttribute>();

        public Dictionary<Type,AsmSigOpKind> TypeKinds()
            => Types().Map(t => (t,(AsmSigOpKind)t.Tag<SymSourceAttribute>().Require().SymKind)).ToDictionary();
    }
}