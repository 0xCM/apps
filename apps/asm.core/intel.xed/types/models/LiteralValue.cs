//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class XedDataTypes
    {
        [StructLayout(LayoutKind.Sequential,Pack=1), DataWidth(MetaWidth,MetaWidth)]
        public readonly struct LiteralValue
        {
            public const uint MetaWidth = TypeKey.MetaWidth + PrimalType.W64;

            public readonly TypeKey Type;

            public readonly ulong Value;

            [MethodImpl(Inline)]
            public LiteralValue(TypeKey type, ulong value)
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