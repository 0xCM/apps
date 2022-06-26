//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ListedFiles : IIndex<ListedFile>
    {
        [Op]
        public static string format(ListedFiles src)
        {
            var dst = text.buffer();
            format(src,dst);
            return dst.Emit();
        }

        [Op]
        public static void format(ListedFiles src, ITextBuffer dst)
        {
            var records = src.View;
            var count = records.Length;
            var formatter = Tables.formatter<ListedFile>();
            dst.AppendLine(formatter.FormatHeader());
            for(var i=0u; i<count; i++)
            {
                dst.AppendLine(formatter.Format(src[i]));
            }
        }

        readonly Index<ListedFile> Data;

        [MethodImpl(Inline)]
        public ListedFiles(ListedFile[] src)
            => Data = src;

        public uint Count
        {
            [MethodImpl(Inline)]
            get => (uint)Data.Length;
        }

        public ReadOnlySpan<ListedFile> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        public Span<ListedFile> Edit
        {
            [MethodImpl(Inline)]
            get => Data.Edit;
        }

        public ListedFile[] Storage
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public ref ListedFile this[ulong index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ref ListedFile this[long index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ref ListedFile First
        {
            [MethodImpl(Inline)]
            get => ref Data.First;
        }

        public string Format()
            => format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator ListedFiles(ListedFile[] src)
            => new ListedFiles(src);

        [MethodImpl(Inline)]
        public static implicit operator ListedFile[](ListedFiles src)
            => src.Storage;

        public static ListedFiles Empty => sys.empty<ListedFile>();
    }
}