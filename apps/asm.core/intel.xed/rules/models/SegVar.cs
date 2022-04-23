//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly record struct SegVar
        {
            internal const ulong KindMask = 0xFF00_0000_0000_0000;

            internal const ulong FirstKind = 0x0100_0000_0000_0000;

            readonly asci8 Name;

            [MethodImpl(Inline)]
            public SegVar(asci8 name)
            {
                Name = name;
            }

            [MethodImpl(Inline)]
            public SegVar(SegVarKind name)
            {
                Name = (ulong)name;
            }

            bool IsKind
            {
                [MethodImpl(Inline)]
                get => ((ulong)Name & KindMask) != 0;
            }

            public string Format()
            {
                var dst = EmptyString;
                if(IsKind)
                {
                    var kind = (SegVarKind)(ulong)Name;
                    dst = kind.ToString();
                }
                else
                    dst = Name.Format();
                return dst;
            }

            public override string ToString()
                => Format();

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Name.IsEmpty;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Name.IsNonEmpty;
            }

            [MethodImpl(Inline)]
            public static explicit operator ulong(SegVar src)
                => (ulong)src.Name;

            public static SegVar Empty => default;
        }
    }
}