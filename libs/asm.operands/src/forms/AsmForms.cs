//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    public readonly struct AsmForms
    {
        readonly SortedLookup<string,AsmForm> Data;

        public AsmForms(AsmForm[] src)
        {
            Data = map(src, form => (form.Name.Format(), form)).ToDictionary();
        }

        public ReadOnlySpan<AsmForm> View
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

        public ref readonly AsmForm this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref skip(View,index);
        }

        public ref readonly AsmForm this[int index]
        {
            [MethodImpl(Inline)]
            get => ref skip(View,index);
        }

        [MethodImpl(Inline)]
        public bool Find(string name, out AsmForm form)
            => Data.Find(name, out form);

        [MethodImpl(Inline)]
        public static implicit operator AsmForms(AsmForm[] src)
            => new AsmForms(src);
    }
}
