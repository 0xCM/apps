//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    public readonly struct AsmDirective : IAsmSourcePart
    {
        [MethodImpl(Inline), Op]
        public static AsmDirective @byte(Hex8 src)
            => define(".byte", src);

        [MethodImpl(Inline), Op]
        public static AsmDirective word(Hex16 src)
            => define(".2byte", src);

        [MethodImpl(Inline), Op]
        public static AsmDirective dword(Hex32 src)
            => define(".4byte", src);

        [MethodImpl(Inline), Op]
        public static AsmDirective qword(Hex64 src)
            => define(".8byte", src);

        [MethodImpl(Inline), Op]
        public static AsmDirective define(text31 name)
            => new AsmDirective(name);

        public static AsmDirective define(AsmDirectiveKind kind, AsmDirectiveOp op0 = default, AsmDirectiveOp op1 = default, AsmDirectiveOp op2 = default)
            => new AsmDirective(Symbols.index<AsmDirectiveKind>()[kind].Expr.Format(),op0,op1,op2);

        [MethodImpl(Inline), Op]
        public static AsmDirective define(text31 name, AsmDirectiveOp op0, AsmDirectiveOp op1, AsmDirectiveOp op2 = default)
            => new AsmDirective(name, op0, op1, op2);

        [Op]
        public static AsmDirective define(text31 name, ReadOnlySpan<AsmDirectiveOp> args)
        {
            var dst = define(name);
            switch(args.Length)
            {
                case 1:
                    dst = define(name, skip(args,0));
                break;
                case 2:
                    dst = define(name, skip(args,0), skip(args,1));
                break;
                case 3:
                    dst = define(name, skip(args,0), skip(args,1), skip(args,2));
                break;
                default:
                    break;
            }
            return dst;
        }

        [MethodImpl(Inline)]
        public static AsmDirective define<T>(text31 name, T arg)
            => new AsmDirective(name, new AsmDirectiveOp<T>(arg));

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
                            dst = define(name, skip(args,0));
                        break;
                        case 2:
                            dst = define(name, skip(args,0), skip(args,1));
                        break;
                        case 3:
                            dst = define(name, skip(args,0), skip(args,1), skip(args,2));
                        break;
                        default:
                            dst = define(name);
                        break;
                    }
                }
                else
                    dst = define(name);

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
            [MethodImpl(Inline)]
            get => Name.IsEmpty;
        }

        public string Format()
            => AsmRender.directive(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator AsmCell(AsmDirective src)
            => asm.cell(src.Format(), AsmPartKind.Directive);

        public static AsmDirective Empty => new AsmDirective(EmptyString, EmptyString, EmptyString, EmptyString);
    }
}