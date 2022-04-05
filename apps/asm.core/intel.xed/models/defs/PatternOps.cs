//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial struct XedModels
    {
        public readonly struct PatternOps : IComparable<PatternOps>
        {
            public readonly uint PatternId;

            readonly Index<PatternOp> Data;

            [MethodImpl(Inline)]
            public PatternOps(uint pattern, PatternOp[] src)
            {
                Data = src;
                PatternId = pattern;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Data.IsEmpty;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Data.IsNonEmpty;
            }

            public PatternOp[] Storage
            {
                [MethodImpl(Inline)]
                get => Data;
            }

            public uint Count
            {
                [MethodImpl(Inline)]
                get => Data.Count;
            }

            public ref PatternOp this[int i]
            {
                [MethodImpl(Inline)]
                get => ref Data[i];
            }

            public ref PatternOp this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref Data[i];
            }

            public Index<OpName> Names
                => Data.Select(x => x.Name);

            [MethodImpl(Inline)]
            public FunctionSet Nonterms()
            {
                var dst = FunctionSet.create();
                for(var i=0; i<Count; i++)
                {
                    ref readonly var op = ref this[i];
                    if(op.Nonterminal(out var nt))
                        dst.Include(nt);
                }
                return dst;
            }

            [MethodImpl(Inline)]
            public uint Nonterms(ref FunctionSet dst)
            {
                var counter = 0u;
                for(var i=0; i<Count; i++)
                {
                    ref readonly var op = ref this[i];
                    if(op.Nonterminal(out var nt))
                    {
                        dst.Include(nt);
                        counter++;
                    }
                }
                return counter;
            }

            public int CompareTo(PatternOps src)
                => PatternId.CompareTo(src.PatternId);

            [MethodImpl(Inline)]
            public static implicit operator PatternOp[](PatternOps src)
                => src.Data;

            [MethodImpl(Inline)]
            public static implicit operator Index<PatternOp>(PatternOps src)
                => src.Data;

            public static PatternOps Empty => new(0u,sys.empty<PatternOp>());
        }
    }
}