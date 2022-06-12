//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public readonly struct SdmForms
    {
        readonly SortedLookup<string,SdmForm> Data;

        public SdmForms(SdmForm[] src)
        {
            Data = map(src, form => (form.Name.Format(), form)).ToDictionary();
        }

        public ReadOnlySpan<SdmForm> View
        {
            [MethodImpl(Inline)]
            get => Data.Values;
        }

        public ReadOnlySpan<string> Names
        {
            [MethodImpl(Inline)]
            get => Data.Keys;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.EntryCount;
        }

        public ref readonly SdmForm this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref skip(View,index);
        }

        public ref readonly SdmForm this[int index]
        {
            [MethodImpl(Inline)]
            get => ref skip(View,index);
        }

        [MethodImpl(Inline)]
        public bool Find(string name, out SdmForm form)
            => Data.Find(name, out form);

        [MethodImpl(Inline)]
        public static implicit operator SdmForms(SdmForm[] src)
            => new SdmForms(src);
    }
}
