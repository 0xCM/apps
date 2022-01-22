//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    public class AsmTokens : AppService<AsmTokens>
    {
        AsmOpCodeTokens.OpCodeTokenSet _OpCodes;

        AsmSigModels.SigTokenSet _Sigs;

        AsmRegTokens.RegTokenSet _Regs;

        ConditionCodes.ConditionTokenSet _Conditions;

        AsmPrefixCodes.PrefixTokenSet _Prefixes;

        public AsmTokens()
        {
            _OpCodes = AsmOpCodeTokens.OpCodeTokenSet.create();
            _Sigs = AsmSigModels.SigTokenSet.create();
            _Regs = AsmRegTokens.RegTokenSet.create();
            _Conditions = ConditionCodes.ConditionTokenSet.create();
            _Prefixes = AsmPrefixCodes.PrefixTokenSet.create();
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
    }
}