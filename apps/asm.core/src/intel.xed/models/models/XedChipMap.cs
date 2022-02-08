//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRecords;

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