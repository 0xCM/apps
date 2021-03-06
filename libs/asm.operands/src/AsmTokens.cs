//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    public class AsmTokens
    {
        [MethodImpl(Inline), Op]
        public static ref readonly AsmTokens tokens()
            => ref Instance;

        [MethodImpl(Inline), Op]
        public static AsmSigToken sig(in AsmToken src)
            => new AsmSigToken((AsmSigTokenKind)src.Index, (byte)src.Value);

        [MethodImpl(Inline), Op]
        public static AsmOcToken opcode(in AsmToken src)
            => new AsmOcToken((AsmOcTokenKind)src.Index, (byte)src.Value);

        public static bool parse(string expr, out AsmSigToken dst)
            => Instance.SigToken(expr, out dst);

        public static bool parse(string expr, out AsmOcToken dst)
            => Instance.OpCodeToken(expr, out dst);

        public static ref readonly ReadOnlySeq<AsmToken> SigTokenDefs => ref Instance._SigTokenDefs;

        public static ref readonly ReadOnlySeq<AsmToken> OcTokenDefs => ref Instance._OcTokenDefs;

        public static ReadOnlySpan<string> SigTokenValues => Instance.SigTokens.Keys;

        public static ReadOnlySpan<string> OcTokenValues => Instance.OcTokens.Keys;

        ReadOnlySeq<AsmToken> _SigTokenDefs;

        ReadOnlySeq<AsmToken> _OcTokenDefs;

        SortedLookup<string,AsmToken> SigTokens;

        SortedLookup<string,AsmToken> OcTokens;

        Index<AsmToken> Data;

        public static ref readonly Index<AsmToken> TokenDefs
        {
            [MethodImpl(Inline)]
            get => ref Instance.Data;
        }

        public bool SigToken(string expr, out AsmSigToken dst)
        {
            if(SigTokens.Find(expr, out var sig))
            {
                dst = AsmTokens.sig(sig);
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
            if(OcTokens.Find(expr, out var opcode))
            {
                dst = AsmTokens.opcode(opcode);
                return true;
            }
            else
            {
                dst = default;
                return false;
            }
        }

        static AsmTokens Instance;

        static AsmTokens()
        {
            Instance = calc();
        }

        static AsmTokens calc()
        {
            var dst = new AsmTokens();
            var sigs = AsmSigDatasets.Instance.Records;
            var opcodes = SdmOpCodes.Datasets.Records;
            dst._OcTokenDefs = opcodes;
            dst._SigTokenDefs = sigs;
            dst.SigTokens = sigs.Select(s => (s.Expr.Text, s)).ToDictionary();
            dst.OcTokens = opcodes.Select(s => (s.Expr.Text, s)).ToDictionary();
            var sigcount = sigs.Length;
            var occount = opcodes.Length;
            var count = sigcount + occount;
            dst.Data = alloc<AsmToken>(count);
            var j=0u;
            for(var i=0u; i<occount; i++,j++)
            {
                dst.Data[j] = opcodes[i];
                dst.Data[j].Seq = j;
            }

            for(var i=0u; i<sigcount; i++,j++)
            {
                dst.Data[j] = sigs[i];
                dst.Data[j].Seq = j;
            }
            return dst;
        }
    }
}