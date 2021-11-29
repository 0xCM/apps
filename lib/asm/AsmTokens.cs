//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    public class AsmTokens : WsService<AsmTokens>
    {
        OpCodes _OpCodes;

        Sigs _Sigs;

        Regs _Regs;

        Conditions _Conditions;

        Prefixes _Prefixes;

        public AsmTokens()
        {
            _OpCodes = OpCodes.create();
            _Sigs = Sigs.create();
            _Regs = Regs.create();
            _Conditions = Conditions.create();
            _Prefixes = Prefixes.create();
        }

        public ITokenSet OpCodeTokens()
            => _OpCodes;

        public ITokenSet SigTokens()
            => _Sigs;

        public ITokenSet RegTokens()
            => _Regs;

        public ITokenSet ConditonTokens()
            => _Conditions;

        public ITokenSet PrefixTokens()
            => _Prefixes;

        public sealed class OpCodes : TokenSet<OpCodes>
        {
            public override string Name
                => "asm.opcodes";

            public override Type[] Types()
                => typeof(AsmOpCodeTokens).GetNestedTypes().Enums().Tagged<SymSourceAttribute>();
        }

        public sealed class Sigs : TokenSet<Sigs>
        {
            public override string Name
                => "asm.sigs";

            public override Type[] Types()
                => typeof(AsmSigs).GetNestedTypes().Enums().Tagged<SymSourceAttribute>();
        }

        public sealed class Prefixes : TokenSet<Prefixes>
        {
            public override string Name
                => "asm.prefixes";

            public override Type[] Types()
                => typeof(AsmPrefixCodes).GetNestedTypes().Enums().Tagged<SymSourceAttribute>();
        }

        public sealed class Regs : TokenSet<Regs>
        {
            public override string Name
                => "asm.regs";

            public override Type[] Types()
                => typeof(AsmRegTokens).GetNestedTypes().Enums().Tagged<SymSourceAttribute>();
        }

        public sealed class Conditions : TokenSet<Conditions>
        {
            public override string Name
                => "asm.cc";

            public override Type[] Types()
                => typeof(ConditionCodes).GetNestedTypes().Enums().Tagged<SymSourceAttribute>();
        }
    }
}