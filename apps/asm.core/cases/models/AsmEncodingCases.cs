//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{

    public readonly struct AsmEncodingCases
    {
        readonly Index<AsmEncodingCase> Data;

        [MethodImpl(Inline)]
        public AsmEncodingCases(AsmEncodingCase[] src)
        {
            Data = src;
        }

        public ref AsmEncodingCase this[int index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }


        public ref AsmEncodingCase this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public ReadOnlySpan<AsmEncodingCase> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }
    }
}