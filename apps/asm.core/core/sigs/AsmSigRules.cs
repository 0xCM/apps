//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public class AsmSigRules
    {
        public static AsmSigRule<T> define<T>(AsmMnemonic mnemonic, byte opcount)
            where T : IRuleExpr
                => new AsmSigRule<T>(mnemonic, opcount);

        public static AsmSigOpRule<T> op<T>(T src)
            where T : IRuleExpr
                => new AsmSigOpRule<T>(src);

        public static AsmSigOpRule<RuleValueExpr<T>> opval<T>(T src)
            => new AsmSigOpRule<RuleValueExpr<T>>(src);

        public static AsmSigOpOption<T> option<T>(T src)
            => new AsmSigOpOption<T>(src);

        public static AsmSigOpChoices<T> choices<T>(T[] src)
            where T : IRuleExpr
                => new AsmSigOpChoices<T>(src);

        public static AsmSigOpValue<T> value<T>(T src)
            => new AsmSigOpValue<T>(src);
    }
}