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

            public readonly ModIndicator Mod;

            public readonly RexBit RexW;

            public readonly RepIndicator Rep;

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
                Rep = XedFields.rep(fields);
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
                Rep = RepIndicator.Empty;
                Rep = XedFields.rep(fields);
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
                Rep = RepIndicator.Empty;
                Rep = XedFields.rep(fields);
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
                Rep = src.Rep;
            }

            [MethodImpl(Inline)]
            public PatternSort(in InstOpDetail src)
            {
                InstClass = src.InstClass;
                OpCode = src.OpCode;
                Mode = src.Mode;
                Lock = src.Lock;
                Mod = src.Mod;
                RexW = src.RexW;
                Rep = src.Rep;
            }

            [MethodImpl(Inline)]
            public PatternSort(in PatternOpCode src)
            {
                InstClass = src.InstClass;
                OpCode = src.OpCode;
                Mode = src.Mode;
                Lock = src.Lock;
                Mod = src.Mod;
                RexW = src.RexW;
                Rep = src.Rep;
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

                    if(result==0)
                    {
                        var a = (uint)Rep.Kind | ((uint)Mod.Kind << 4) | (RexW.IsNonEmpty ? 0xFFu << 8 : 0u);
                        var b = (uint)src.Rep.Kind | ((uint)src.Mod.Kind << 4) | (src.RexW.IsNonEmpty ? 0xFFu << 8 : 0u);
                        result = a.CompareTo(b);
                    }

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