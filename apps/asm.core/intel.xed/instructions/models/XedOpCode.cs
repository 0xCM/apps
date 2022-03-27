//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedModels;

    partial class XedPatterns
    {
        [StructLayout(LayoutKind.Sequential,Pack=1),DataWidth(64)]
        public readonly struct XedOpCode : IEquatable<XedOpCode>, IComparable<XedOpCode>
        {
            public readonly OpCodeKind Kind;

            public readonly AsmOcValue Value;

            [MethodImpl(Inline)]
            public XedOpCode(OpCodeKind kind, AsmOcValue value)
            {
                Kind = kind;
                Value = value;
            }

            public OpCodeClass Class
            {
                [MethodImpl(Inline)]
                get => XedPatterns.@class(Kind);
            }
            public Hash32 Hash
            {
                [MethodImpl(Inline)]
                get => (((uint)Kind << 24) | (uint)Value);
            }

            public string Format()
                => XedRender.format(this);

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
                var a = (byte)XedPatterns.ocindex(Kind);
                var b = (byte)XedPatterns.ocindex(src.Kind);
                var result = a.CompareTo(b);
                if(result == 0)
                    result = Value.CompareTo(src.Value);
                return result;
            }

            public static XedOpCode Empty => default;

            [MethodImpl(Inline)]
            public static bool operator==(XedOpCode a, XedOpCode b)
                => a.Equals(b);

            [MethodImpl(Inline)]
            public static bool operator!=(XedOpCode a, XedOpCode b)
                => !a.Equals(b);
        }
    }
}