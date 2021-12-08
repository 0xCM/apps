//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct DigitParserResult : ITextual
    {
        public DigitParserCase Case {get;}

        public byte Output {get;}

        [MethodImpl(Inline), Op]
        public DigitParserResult(DigitParserCase @case, byte output)
        {
            Case = @case;
            Output = output;
        }

        public bool Passed => Output == Case.Expect;

        public string Format()
            => string.Format("{0} | {1} ({2})", Case, Passed ? "Passed" : "Failed", EvalResultExpr.eq(Output, Case.Expect, Passed));

        public override string ToString()
            => Format();
    }
}