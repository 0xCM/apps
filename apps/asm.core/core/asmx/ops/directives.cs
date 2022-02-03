//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial struct AsmX
    {
        [MethodImpl(Inline), Op]
        public static AsmDirective directive(text31 name)
            => new AsmDirective(name);

        [MethodImpl(Inline), Op]
        public static AsmDirective directive(text31 name, AsmDirectiveOp op0, AsmDirectiveOp op1, AsmDirectiveOp op2 = default)
            => new AsmDirective(name, op0, op1, op2);

        [MethodImpl(Inline)]
        public static AsmDirective directive<T>(text31 name, T arg)
            => new AsmDirective(name, new AsmDirectiveOp<T>(arg));

        [Op]
        public static AsmDirective directive(text31 name, ReadOnlySpan<AsmDirectiveOp> args)
        {
            var dst = directive(name);
            switch(args.Length)
            {
                case 1:
                    dst = directive(name, skip(args,0));
                break;
                case 2:
                    dst = directive(name, skip(args,0), skip(args,1));
                break;
                case 3:
                    dst = directive(name, skip(args,0), skip(args,1), skip(args,2));
                break;
                default:
                    break;
            }
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static AsmDirective @byte(Hex8 src)
            => directive(".byte", src);

        [MethodImpl(Inline), Op]
        public static AsmDirective word(Hex16 src)
            => directive(".2byte", src);

        [MethodImpl(Inline), Op]
        public static AsmDirective dword(Hex32 src)
            => directive(".4byte", src);

        [MethodImpl(Inline), Op]
        public static AsmDirective qword(Hex64 src)
            => directive(".8byte", src);
    }
}