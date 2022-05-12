//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        public readonly struct ChipMap
        {
            readonly ConstLookup<ChipCode,IsaKinds> Data;

            [MethodImpl(Inline)]
            public ChipMap(ConstLookup<ChipCode,IsaKinds> src)
            {
                Data = src;
            }

            public IsaKinds this[ChipCode code]
            {
                [MethodImpl(Inline)]
                get => Data[code];
            }

            public ReadOnlySpan<ChipCode> Codes
            {
                [MethodImpl(Inline)]
                get => Data.Keys;
            }
            public ReadOnlySpan<IsaKinds> Kinds
            {
                [MethodImpl(Inline)]
                get => Data.Values;
            }
        }
    }
}