//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class FolderPaths : Seq<FolderPaths,FS.FolderPath>
    {
        public static string format(FolderPaths src, char sep = Chars.Semicolon)
        {
            var dst = text.buffer();
            var count = src.Data.Count;
            for(var i=0; i<count; i++)
            {
                dst.Append(src.Data[i].Format(PathSeparator.BS));
                if(i != count - 1)
                    dst.Append(sep);
            }
            return dst.Emit();
        }

        public FolderPaths()
        {

        }

        [MethodImpl(Inline)]
        public FolderPaths(FS.FolderPath[] src)
            : base(src)
        {

        }

        public FS.FolderPath[] Storage
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public override string Format()
            => format(this);

        [MethodImpl(Inline)]
        public static implicit operator FolderPaths(FS.FolderPath[] src)
            => new FolderPaths(src);

        [MethodImpl(Inline)]
        public static implicit operator FS.FolderPath[](FolderPaths src)
            => src.Storage;
    }
}