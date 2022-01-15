//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct AsmDirective : IAsmSourcePart
    {
        public readonly text31 Name;

        public readonly AsmDirectiveOp Op0;

        public readonly AsmDirectiveOp Op1;

        public readonly AsmDirectiveOp Op2;

        [MethodImpl(Inline)]
        public AsmDirective(text31 name, AsmDirectiveOp op0 = default, AsmDirectiveOp op1 = default, AsmDirectiveOp op2 = default)
        {
            Name = name;
            Op0 = op0;
            Op1 = op1;
            Op2 = op2;
        }

        AsmPartKind IAsmSourcePart.PartKind
        {
            [MethodImpl(Inline)]
            get => AsmPartKind.Directive;
        }

        public bool IsEmpty
        {
            get => Name.IsEmpty;
        }

        public string Format()
        {
            var dst = text.buffer();
            dst.AppendFormat(".{0}", Name);
            if(Op0.IsNonEmpty)
            {
                dst.AppendFormat(" {0}", Op0.Format());
                if(Op1.IsNonEmpty)
                {
                    dst.AppendFormat(", {0}", Op1.Format());
                    if(Op2.IsNonEmpty)
                        dst.AppendFormat(", {0}", Op2.Format());
                }
            }

            return dst.Emit();
        }

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator AsmCell(AsmDirective src)
            => asm.cell(src.Format(), AsmPartKind.Directive);

        public static AsmDirective Empty => new AsmDirective(EmptyString, EmptyString, EmptyString, EmptyString);

    }
}