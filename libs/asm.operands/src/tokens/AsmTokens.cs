//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    public class AsmTokens : AppService<AsmTokens>
    {
        [MethodImpl(Inline)]
        public static AsmSigToken sig<T>(AsmSigTokenKind kind, T value)
            where T : unmanaged
                => new AsmSigToken(kind, u8(value));

        [MethodImpl(Inline), Op]
        public static AsmSigToken specialize(in AsmToken src)
            => new AsmSigToken((AsmSigTokenKind)src.Index, (byte)src.Value);

        public static bool sig(string expr, out AsmSigToken dst)
            => Tokens.SigToken(expr, out dst);

        public static bool opcode(string expr, out AsmOcToken dst)
            => Tokens.OpCodeToken(expr, out dst);

        public static AsmTokens Tokens
            => data("AsmTokens", AsmTokens.calc);

        Index<AsmToken> Data;

        Dictionary<string,AsmToken> SigTokens;

        Dictionary<string,AsmToken> OcTokens;

        public AsmTokens()
        {
            Data = sys.empty<AsmToken>();
            SigTokens = dict<string,AsmToken>();
            OcTokens = dict<string,AsmToken>();
        }

        public ReadOnlySpan<AsmToken> View
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
            var buffer = alloc<AsmToken>(count);
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