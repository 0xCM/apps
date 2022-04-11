//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedModels;

    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential,Pack=1),DataWidth(64)]
        public readonly struct XedOpCode : IEquatable<XedOpCode>, IComparable<XedOpCode>
        {
            public static ref ulong convert(XedOpCode src, out ulong dst)
            {
                dst = core.@as<XedOpCode,ulong>(src);
                return ref dst;
            }

            public static ref XedOpCode convert(ulong src, out XedOpCode dst)
            {
                dst = core.@as<ulong,XedOpCode>(src);
                return ref dst;
            }

            public readonly MachineMode Mode;

            public readonly OpCodeKind Kind;

            public readonly AsmOcValue Value;

            readonly byte Pad;

            [MethodImpl(Inline)]
            public XedOpCode(MachineMode mode, OpCodeKind kind, AsmOcValue value)
            {
                Mode = mode;
                Kind = kind;
                Value = value;
                Pad = 0;
            }

            public OpCodeClass Class
            {
                [MethodImpl(Inline)]
                get => XedPatterns.occlass(Kind);
            }

            public Hash32 Hash
            {
                [MethodImpl(Inline)]
                get => ((uint)Mode << 29) | (((uint)Class << 24) | (uint)Value);
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Kind == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Kind != 0;
            }

            public asci2 Symbol
                => XedPatterns.symbol(Kind);

            public asci4 Selector
                => XedPatterns.selector(Kind);

            public asci8 MapSpec
                => string.Format("{0}:{1}", Symbol, Selector);

            public string Format()
                => $"{Symbol}[{Selector}]:{Value}";

            public override string ToString()
                => Format();


            public override int GetHashCode()
                => Hash;

            public bool Equals(XedOpCode src)
                => Kind == src.Kind && Value == src.Value;

            public override bool Equals(object src)
                => src is XedOpCode x && Equals(x);

            public int CompareTo(XedOpCode src)
            {
                var result = Value.CompareTo(src.Value);
                if(result==0)
                    result = XedPatterns.cmp(Kind, src.Kind);
                return result;
            }

            [MethodImpl(Inline)]
            public static bool operator==(XedOpCode a, XedOpCode b)
                => a.Equals(b);

            [MethodImpl(Inline)]
            public static bool operator!=(XedOpCode a, XedOpCode b)
                => !a.Equals(b);

            [MethodImpl(Inline)]
            public static explicit operator ulong(XedOpCode src)
                => convert(src, out _);

            [MethodImpl(Inline)]
            public static explicit operator XedOpCode(ulong src)
                => convert(src, out _);

            public static XedOpCode Empty => default;
        }
    }
}