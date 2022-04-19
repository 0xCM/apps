//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [DataWidth(Width, 8)]
        public readonly record struct RexBit
        {
            public const byte Width = uint2.Width;

            readonly byte Data;

            [MethodImpl(Inline)]
            public RexBit(RexField indicator, bit state)
            {
                if(indicator.IsNonEmpty)
                    Data = bit.set((byte)indicator, 7, state);
                else
                    Data = 0;
            }

            public bit State
            {
                [MethodImpl(Inline)]
                get => bit.test(Data,7);
            }

            public RexField Field
            {
                [MethodImpl(Inline)]
                get => IsNonEmpty ? new RexField((char)math.and(sbyte.MaxValue,Data)) : RexField.Empty;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Data == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Data != 0;
            }

            public string Format()
                => IsEmpty ? EmptyString : State.Format();

            public override string ToString()
                => Format();

            public int CompareTo(RexBit src)
            {
                var result = 0;
                if(IsNonEmpty && src.IsNonEmpty)
                {
                    result = Field.CompareTo(src.Field);
                    if(result==0)
                        result = ((byte)State).CompareTo((byte)src.State);
                }
                return result;
            }

            public static RexBit Empty => default;

            [MethodImpl(Inline)]
            public static implicit operator bit(RexBit src)
                => src.State;

            [MethodImpl(Inline)]
            public static explicit operator uint(RexBit src)
                => (uint)src.State;
        }
    }
}