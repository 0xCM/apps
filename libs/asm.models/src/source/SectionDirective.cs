//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial struct AsmDirectives
    {
        public sealed class SectionDirective : AsmDirective<SectionDirective>
        {
            public SectionDirective(text15 name, CoffSectionFlags flags = default, CoffComDatKind comdat = default, AsmDirectiveOp data = default)
                : base(".section", name.Format(), operand(format(flags)), format(comdat), data)
            {

            }
        }
    }
}