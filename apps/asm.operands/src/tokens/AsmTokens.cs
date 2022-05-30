//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    public class AsmTokens : AppService<AsmTokens>
    {
        public static AsmToken generalize(in Token<AsmSigTokenKind> src)
        {
            var dst = new AsmToken();
            var token = new AsmSigToken(src.Kind, (byte)src.Value);
            dst.Id = token.Id;
            dst.ClassName = nameof(AsmSigToken);
            dst.Value = (byte)src.Value;
            dst.KindName = src.Kind.ToString();
            dst.KindValue = (byte)src.Kind;
            dst.Index = (ushort)src.Key;
            dst.Name = src.Name;
            dst.Expr = src.Expr.Text;
            return dst;
        }

        [MethodImpl(Inline)]
        public static AsmSigToken sig<T>(AsmSigTokenKind kind, T value)
            where T : unmanaged
                => new AsmSigToken(kind, u8(value));

        [MethodImpl(Inline), Op]
        public static AsmSigToken specialize(in AsmToken2 src)
            => new AsmSigToken((AsmSigTokenKind)src.KindIndex, (byte)src.Value);

        public static bool sig(string expr, out AsmSigToken dst)
            => Tokens.SigToken(expr, out dst);

        public static bool opcode(string expr, out AsmOcToken dst)
            => Tokens.OpCodeToken(expr, out dst);

        public static AsmTokens Tokens
            => data("AsmTokens", AsmTokens.calc);

        public static bool unique(ReadOnlySpan<AsmToken> src, out AsmToken duplicate)
        {
            var dst = hashset<string>();
            var count = src.Length;
            var result = true;
            duplicate = AsmToken.Empty;
            for(var i=0; i<count; i++)
            {
                ref readonly var token = ref src[i];
                if(dst.Contains(token.Expr))
                {
                    duplicate = token;
                    result = false;
                    break;
                }
                else
                    dst.Add(token.Expr);
            }
            return result;
        }

        Index<AsmToken2> Data;

        Dictionary<string,AsmToken2> SigTokens;

        Dictionary<string,AsmToken2> OcTokens;

        public AsmTokens()
        {
            Data = sys.empty<AsmToken2>();
            SigTokens = dict<string,AsmToken2>();
            OcTokens = dict<string,AsmToken2>();
        }

        public ReadOnlySpan<AsmToken2> View
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public bool SigToken(string expr, out AsmSigToken dst)
        {
            if(SigTokens.TryGetValue(expr, out var sig))
            {
                dst = specialize(sig);
                return true;
            }
            else
            {
                dst = default;
                return false;
            }
        }

        public bool OpCodeToken(string expr, out AsmOcToken dst)
        {
            if(OcTokens.TryGetValue(expr, out var opcode))
            {
                dst = AsmOpCodes.specialize(opcode);
                return true;
            }
            else
            {
                dst = default;
                return false;
            }
        }

        static AsmTokens calc()
        {
            var sigs = AsmSigDatasets.Instance.Records;
            var sigcount = sigs.Length;
            var opcodes = AsmOcDatasets.Instance.Records;
            var occount = opcodes.Length;
            var count = sigcount + occount;
            var buffer = alloc<AsmToken2>(count);
            var j=0u;
            for(var i=0u; i<occount; i++,j++)
            {
                seek(buffer,j) = opcodes[i];
                seek(buffer,j).Seq = j;
            }

            for(var i=0u; i<sigcount; i++,j++)
            {
                seek(buffer,j) = sigs[i];
                seek(buffer,j).Seq = j;
            }
            var dst = new AsmTokens();
            dst.Data = buffer;
            dst.SigTokens = sigs.Map(s => (s.Expr.Format(),s)).ToDictionary();
            dst.OcTokens = opcodes.Map(s => (s.Expr.Format(),s)).ToDictionary();
            return dst;
        }
    }
}