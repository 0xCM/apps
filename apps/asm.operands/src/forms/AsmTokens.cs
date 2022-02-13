//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    public readonly struct AsmTokens
    {
        public static bool unique(ReadOnlySpan<AsmToken> src, out AsmToken duplicate)
        {
            var dst = hashset<string>();
            var count = src.Length;
            var result = true;
            duplicate = AsmToken.Empty;
            for(var i=0; i<count; i++)
            {
                ref readonly var token = ref src[i];
                if(dst.Contains(token.Expression))
                {
                    duplicate = token;
                    result = false;
                    break;
                }
                else
                    dst.Add(token.Expression);
            }
            return result;
        }

        [MethodImpl(Inline)]
        public static AsmTokens data()
            => Instance;

        public static bool sig(string expr, out AsmSigToken dst)
            => data().SigToken(expr, out dst);

        public static bool opcode(string expr, out AsmOcToken dst)
            => data().OpCodeToken(expr, out dst);

        static AsmTokens load()
        {
            var sigs = AsmSigDatasets.tokens().View;
            var sigcount = sigs.Length;
            var opcodes = AsmOcDatasets.tokens().View;
            var occount = opcodes.Length;
            var count = sigcount + occount;
            var buffer = alloc<AsmToken>(count);
            var j=0u;
            for(var i=0u; i<occount; i++,j++)
            {
                seek(buffer,j) = skip(opcodes,i);
                seek(buffer,j).Seq = j;
            }

            for(var i=0u; i<sigcount; i++,j++)
            {
                seek(buffer,j) = skip(sigs,i);
                seek(buffer,j).Seq = j;
            }
            return new AsmTokens(buffer);
        }

        readonly Index<AsmToken> Data;

        readonly Dictionary<string,AsmToken> SigTokens;

        readonly Dictionary<string,AsmToken> OcTokens;

        AsmTokens(Index<AsmToken> src)
        {
            Data = src;
            SigTokens = src.Where(x => x.ClassName == nameof(AsmSigToken)).Select(x => (x.Expression.Format(),x)).ToDictionary();
            OcTokens = src.Where(x => x.ClassName == nameof(AsmOcToken)).Select(x => (x.Expression.Format(),x)).ToDictionary();
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
                dst = AsmSigs.specialize(sig);
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

        static AsmTokens()
        {
            Instance = load();
        }

        static AsmTokens Instance;
    }
}