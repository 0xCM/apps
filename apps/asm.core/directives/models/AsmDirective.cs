//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public sealed class AsmDirective : AsmDirective<AsmDirective>
    {
        public AsmDirective(text15 name, AsmDirectiveOp op0 = default, AsmDirectiveOp op1 = default, AsmDirectiveOp op2 = default)
            : base(name,op0,op1,op2)
        {

        }

        [MethodImpl(Inline)]
        public static implicit operator AsmCell(AsmDirective src)
            => asm.cell(src.Format(), AsmCellKind.Directive);

        public static AsmDirective Empty => new AsmDirective(EmptyString, EmptyString, EmptyString, EmptyString);
    }
}