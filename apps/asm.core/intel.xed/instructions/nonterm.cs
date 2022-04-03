//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;
    using static XedModels;

    public ref struct GStore16<T>
        where T : unmanaged
    {
        public static uint Capacity => size<T>()/ByteBlock16.Size;

        public readonly byte Count;

        ByteBlock16 Data;

        public GStore16(int count, ByteBlock16 src)
        {
            Count = (byte)count;
            Data = src;
        }

        public ref T this[int i]
        {
            [MethodImpl(Inline)]
            get => ref @as<T>(seek(Data[0],i*size<T>()));
        }
    }

    partial class XedPatterns
    {
        public static GStore16<Nonterminal> nonterms(Index<RuleCell> src)
        {
            var Capacity = GStore16<Nonterminal>.Capacity;
            var storage = ByteBlock16.Empty;
            ref var dst = ref @as<Nonterminal>(storage.First);
            var j=0;
            for(var i=0; i<src.Count && j<Capacity; i++)
            {
                ref readonly var data = ref src[i].Data;
                if(XedParsers.IsNontermCall(data))
                {
                    if(XedParsers.parse(data, out Nonterminal nt))
                        seek(dst,j++) = nt;
                }
            }
            return new (j,storage);
        }

        [MethodImpl(Inline), Op]
        public static bool nonterm(in PatternOp src, out Nonterminal dst)
        {
            var result = XedPatterns.first(src.Attribs, OpAttribClass.Nonterminal, out var attrib);
            if(result)
                dst = attrib.ToNonTerm();
            else
                dst = Nonterminal.Empty;
            return result;
        }
    }
}