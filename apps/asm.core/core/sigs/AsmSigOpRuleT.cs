//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;
    using static core;

    public interface IAsmSigOpRule : IRuleExpr
    {

    }

    public interface IAsmSigOpRule<T> : IAsmSigOpRule, IRuleExpr<T>
    {


    }

    public class AsmSigOpRule<T> : RuleExpr<T>, IAsmSigOpRule<T>
    {
        public AsmSigOpRule(T value)
            : base(value)
        {

        }

        public override string Format()
            => Content.ToString();

        public static implicit operator AsmSigOpRule<T>(T src)
            => new AsmSigOpRule<T>(src);
    }

    public class AsmSigOpChoices<T> : AsmSigOpRule<SeqExpr<T>>
        where T : IRuleExpr
    {
        public AsmSigOpChoices(Index<T> choices)
            : base(Rules.seq(choices.Storage))
        {

        }
    }

    public class AsmSigOpOption<T> : AsmSigOpRule<OptionRule<T>>
    {
        public AsmSigOpOption(T option)
            : base(Rules.option(option))
        {


        }
    }

    public class AsmSigOpValue<T> : AsmSigOpRule<RuleValueExpr<T>>
    {
        public AsmSigOpValue(T value)
            : base(value)
        {

        }
    }
}