//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class XedPatterns
    {
        public readonly struct PatternOps
        {
            readonly Index<PatternOp> Data;

            [MethodImpl(Inline)]
            public PatternOps(PatternOp[] src)
            {
                Data = src;
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

            public PatternOps Sort()
            {
                Data.Sort();
                return this;
            }

            [MethodImpl(Inline)]
            public bool NonTerminal(out PatternOp dst)
            {
                for(var i=0; i<Count; i++)
                {
                    ref readonly var op = ref this[i];
                    if(op.IsNonTerminal)
                    {
                        dst = op;
                        return true;
                    }
                }
                dst = PatternOp.Empty;
                return false;
            }

            [MethodImpl(Inline)]
            public static implicit operator PatternOps(PatternOp[] src)
                => new PatternOps(src);

            [MethodImpl(Inline)]
            public static implicit operator PatternOps(Index<PatternOp> src)
                => new PatternOps(src);

            [MethodImpl(Inline)]
            public static implicit operator PatternOp[](PatternOps src)
                => src.Data;

            [MethodImpl(Inline)]
            public static implicit operator Index<PatternOp>(PatternOps src)
                => src.Data;

            public static PatternOps Empty => sys.empty<PatternOp>();
        }
    }
}