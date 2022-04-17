//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static core;

    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public readonly record struct PatternSort : IComparable<PatternSort>, IComparer<InstPatternRecord>, IComparer<InstPatternSpec>
        {
            public static PatternSort comparer() => default;

            public readonly InstClass InstClass;

            public readonly XedOpCode OpCode;

            public readonly MachineMode Mode;

            public readonly InstLock Lock;

            public readonly ModKind Mod;

            public readonly RexBit RexW;

            [MethodImpl(Inline)]
            public PatternSort(InstPattern src)
            {
                ref readonly var fields = ref src.Fields;
                InstClass = src.InstClass;
                OpCode = src.OpCode;
                Mode = src.Mode;
                Lock = src.Lock;
                Mod = XedFields.mod(fields);
                RexW = XedFields.rexw(fields);
            }

            [MethodImpl(Inline)]
            public PatternSort(in InstPatternRecord src)
            {
                ref readonly var fields = ref src.Body.Fields;
                InstClass = src.InstClass;
                OpCode = src.OpCode;
                Mode = src.Mode;
                Lock = src.Lock;
                Mod = XedFields.mod(fields);
                RexW = XedFields.rexw(fields);
            }

            [MethodImpl(Inline)]
            public PatternSort(in InstPatternSpec src)
            {
                ref readonly var fields = ref src.Body.Fields;
                InstClass = src.InstClass;
                OpCode = src.OpCode;
                Mode = src.Mode;
                Lock = XedFields.@lock(fields);
                Mod = XedFields.mod(fields);
                RexW = XedFields.rexw(fields);
           }

            [MethodImpl(Inline)]
            public PatternSort(in InstGroupSeq src)
            {
                InstClass = src.InstClass;
                OpCode = src.OpCode;
                Mode = src.Mode;
                Lock = src.Lock;
                Mod = src.Mod;
                RexW = src.RexW;
            }

            public int CompareTo(PatternSort src)
            {
                var result = InstClass.CompareTo(src.InstClass);
                if(result == 0)
                {
                    result = OpCode.Value.CompareTo(src.OpCode.Value);

                    if(result == 0)
                        result = Mode.CompareTo(src.Mode);

                    if(result == 0)
                        result = Lock.CompareTo(src.Lock);

                    if(result == 0 && Mod.IsNonEmpty && src.Mod.IsNonEmpty)
                        result = Mod.CompareTo(src.Mod);

                    if(result == 0 && RexW.IsNonEmpty && src.RexW.IsNonEmpty)
                        result = RexW.CompareTo(src.RexW);

                }
                return result;
            }

            public string Format()
                => GetHashCode().FormatHex();

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public int Compare(InstPatternRecord x, InstPatternRecord y)
                => x.Sort().CompareTo(y.Sort());

            [MethodImpl(Inline)]
            public int Compare(InstPatternSpec x, InstPatternSpec y)
                => x.Sort().CompareTo(y.Sort());

            [MethodImpl(Inline)]
            public int Compare(InstPattern x, InstPattern y)
                => x.Sort().CompareTo(y.Sort());
        }
    }
}