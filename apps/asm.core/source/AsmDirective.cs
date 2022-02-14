//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    public readonly struct AsmDirective : IAsmSourcePart
    {
        [Parser]
        public static Outcome parse(string src, out AsmDirective dst)
        {
            var input = src.Trim();
            var name = input;
            var i = text.index(src, Chars.Dot);
            var j = text.index(src, Chars.Colon);
            var result = Outcome.Failure;
            if(i >= 0 && j < 0)
            {
                var k = text.index(src, Chars.Comma);
                if(k > 0)
                {
                    name = text.left(src,k).Trim();
                    var args = text.right(src,i).SplitClean(Chars.Comma);
                    var count =  args.Length;
                    switch(count)
                    {
                        case 1:
                            dst = asm.directive(name, skip(args,0));
                        break;
                        case 2:
                            dst = asm.directive(name, skip(args,0), skip(args,1));
                        break;
                        case 3:
                            dst = asm.directive(name, skip(args,0), skip(args,1), skip(args,2));
                        break;
                        default:
                            dst = asm.directive(name);
                        break;
                    }
                }
                else
                    dst = asm.directive(name);

                result = Outcome.Success;
            }
            else
                dst = AsmDirective.Empty;

            return result;
        }

        public readonly text31 Name;

        public readonly AsmDirectiveOp Op0;

        public readonly AsmDirectiveOp Op1;

        public readonly AsmDirectiveOp Op2;

        [MethodImpl(Inline)]
        public AsmDirective(text31 name, AsmDirectiveOp op0 = default, AsmDirectiveOp op1 = default, AsmDirectiveOp op2 = default)
        {
            Name = name.IsNonEmpty ? (name[0] == Chars.Dot ? core.slice(name.Bytes,1) : name.Bytes) : default(ReadOnlySpan<byte>);
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