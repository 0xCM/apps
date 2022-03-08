//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    public readonly struct XedChipMap
    {
        readonly Index<ChipCode,IsaKinds> Data;

        readonly Index<ChipCode> _Codes;

        [MethodImpl(Inline)]
        public XedChipMap(Index<ChipCode> codes, Index<ChipCode,IsaKinds> src)
        {
            _Codes = codes;
            Data = src;
        }

        public ref readonly IsaKinds this[ChipCode code]
        {
            [MethodImpl(Inline)]
            get => ref Data[code];
        }


        public ReadOnlySpan<IsaKinds> Kinds
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        public ReadOnlySpan<ChipCode> Chips
        {
            [MethodImpl(Inline)]
            get => _Codes.View;
        }
    }
}