//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ListedFiles : SortedSeq<ListedFile>
    {
        public static ListedFiles list(FS.Files src)
            => new ListedFiles(new ListedFiles(src.Storage.Mapi((i,x) => new ListedFile(i,x))));

        [Op]
        public static string format(ListedFiles src)
        {
            var dst = text.emitter();
            format(src,dst);
            return dst.Emit();
        }

        [Op]
        public static void format(ListedFiles src, ITextEmitter dst)
        {
            var records = src.View;
            var count = records.Length;
            var formatter = Tables.formatter<ListedFile>();
            dst.AppendLine(formatter.FormatHeader());
            for(var i=0u; i<count; i++)
                dst.AppendLine(formatter.Format(src[i]));
        }

        public ListedFiles()
        {

        }

        [MethodImpl(Inline)]
        public ListedFiles(ListedFile[] src)
            : base(src)
        {

        }

        public override string Format()
            => format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator ListedFiles(ListedFile[] src)
            => new ListedFiles(src);
    }
}