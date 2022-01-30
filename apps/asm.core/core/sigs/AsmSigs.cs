//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [ApiHost]
    public class AsmSigs : AppService<AsmSigs>
    {
        const NumericKind Closure = UnsignedInts;

        AsmOpCodes OpCodes => Service(Wf.AsmOpCodes);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static AsmSigOp operand<T>(AsmSigOpKind kind, T value, NativeSizeCode size = NativeSizeCode.Unknown)
            where T : unmanaged
                => new AsmSigOp(kind, core.bw8(value), size);

        public static Identifier identify(AsmSigRuleExpr target)
        {
            var operands = target.Operands;
            var opcount = operands.Count;
            var buffer = text.buffer();
            buffer.Append(target.Mnemonic.Format(MnemonicCase.Lowercase));
            for(var j=0; j<opcount; j++)
            {
                buffer.Append(Chars.Underscore);

                AsmSigOpExpr op = operands[j].Format().Replace(":", "x").Replace("&", "a");
                if(op.Modified(out var t, out var m))
                    buffer.AppendFormat("{0}_{1}", t, m);
                else
                    buffer.Append(op.Format());
            }
            var name = buffer.Emit().Replace("lock", "@lock");
            return name;
        }

        public static Identifier identify(in AsmSigExpr src)
        {
            var operands = src.Operands();
            var opcount = operands.Length;
            var buffer = text.buffer();
            buffer.Append(src.Mnemonic.Format(MnemonicCase.Lowercase));
            for(var j=0; j<opcount; j++)
            {
                buffer.Append(Chars.Underscore);
                AsmSigOpExpr op = operands[j].Format().Replace(":", "x").Replace("&", "a");
                if(op.Modified(out var t, out var m))
                    buffer.AppendFormat("{0}_{1}", t, m);
                else
                    buffer.Append(op.Format());
            }

            var name = buffer.Emit().Replace("lock", "@lock");
            return name;
        }

        public static bool modified(AsmSigOpExpr src, out string target, out AsmModifierKind mod)
        {
            mod = AsmModifierKind.None;
            target = EmptyString;
            var i = text.index(src.Text, Chars.LBrace);
            if(i > 0)
            {
                target = text.trim(text.left(src.Text,i));
                var modtext = text.trim(text.right(src.Text,i-1));
                var modifiers = Symbols.index<AsmModifierKind>();
                modifiers.ExprKind(modtext, out mod);
            }
            return mod != 0;
        }

        protected override void OnInit()
        {

        }

        public bool IsModified(in AsmSigOpExpr src)
            => src.Text.Contains(Chars.LBrace);

        public Outcome Parse(string src, out AsmSig dst)
            => AsmSigParser.parse(src, out dst);

        public Outcome<AsmForm> BuildForm(in AsmSigExpr sigexpr, in CharBlock36 ocexpr)
        {
            var result = Outcome<AsmForm>.Empty;
            result = OpCodes.Parse(ocexpr, out var opcode);
            if(result)
            {
                var expect = text.trim(text.despace(ocexpr.Format()));
                var actual = opcode.Format();
                if(expect != actual)
                {
                    result = (false, string.Format("'{0}' != '{1}'", actual, expect));
                    return result;
                }
            }
            else
                return result;

            result = AsmSigParser.parse(sigexpr.Format(), out var sig);
            if(result.Fail)
            {
                result = (false,string.Format("Sig parse failure:{0}", sigexpr.Format()));
                return result;
            }

            return new AsmForm(AsmForm.identify(new AsmFormExpr(sigexpr, ocexpr)).Text, sig, opcode);
        }
    }
}