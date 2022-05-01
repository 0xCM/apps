//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class XedDataTypes
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public readonly struct LiteralValue<T>
            where T : unmanaged
        {
            public static uint MetaWidth => core.width<T>() + LiteralType.MetaWidth;

            public readonly LiteralType Type;

            public readonly T Value;

            [MethodImpl(Inline)]
            public LiteralValue(LiteralType type, T value)
            {
                Type = type;
                Value = value;
            }

            [MethodImpl(Inline)]
            public static implicit operator LiteralValue(LiteralValue<T> src)
                => new LiteralValue(src.Type, core.bw64(src.Value));
        }

        [StructLayout(LayoutKind.Sequential,Pack=1), DataWidth(MetaWidth,MetaWidth)]
        public readonly struct LiteralValue
        {
            public const uint MetaWidth = LiteralType.MetaWidth + 64;

            public readonly LiteralType Type;

            public readonly ulong Value;

            [MethodImpl(Inline)]
            public LiteralValue(LiteralType type, ulong value)
            {
                Type = type;
                Value = value;
            }

            [MethodImpl(Inline)]
            public static implicit operator LiteralValue<ulong>(LiteralValue src)
                => new LiteralValue<ulong>(src.Type, src.Value);
        }
    }
}