//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ClrRecordFields : IIndex<ClrTableField>
    {
        readonly Index<ClrTableField> Data;

        [MethodImpl(Inline)]
        public ClrRecordFields(ClrTableField[] src)
            => Data = src;

        [MethodImpl(Inline)]
        public string FormatFieldValue<T>(int index, T value)
            => Data[index].Format(value);

        public uint Count
        {
            [MethodImpl(Inline)]
            get => (uint)Data.Length;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Data.Length;
        }

        public ref ClrTableField this[ulong index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ref ClrTableField this[long index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ReadOnlySpan<ClrTableField> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        public Span<ClrTableField> Edit
        {
            [MethodImpl(Inline)]
            get => Data.Storage;
        }

        public ClrTableField[] Storage
        {
            [MethodImpl(Inline)]
            get => Data.Storage;
        }


        [MethodImpl(Inline)]
        public static implicit operator ClrRecordFields(ClrTableField[] src)
            => new ClrRecordFields(src);

        public static ClrRecordFields Empty
            => new ClrRecordFields(sys.empty<ClrTableField>());
    }
}