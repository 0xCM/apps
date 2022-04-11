//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        public readonly record struct RexBit
        {
            readonly byte Data;

            [MethodImpl(Inline)]
            public RexBit(char c, bit state)
            {
                var indicator = RexIndicator.parse(c);
                if(indicator.IsNonEmpty)
                    Data = bit.set((byte)indicator, 7, state);
                else
                    Data = 0;
            }

            [MethodImpl(Inline)]
            public RexBit(RexIndicator indicator, bit state)
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

            public RexIndicator Indicator
            {
                [MethodImpl(Inline)]
                get => IsNonEmpty ? new RexIndicator((char)math.and(sbyte.MaxValue,Data)) : RexIndicator.Empty;
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
                    result = Indicator.CompareTo(src.Indicator);
                    if(result==0)
                        result = ((byte)State).CompareTo((byte)src.State);
                }
                return result;
            }

            public static RexBit Empty => default;
        }
    }
}