//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public sealed class FolderPaths : Seq<FolderPaths,FS.FolderPath>
    {
        public static Outcome parse(char sep, string src, out FolderPaths dst)
        {
            var result = Outcome.Success;
            dst = Empty;
            var i = text.index(src, sep);
            if(i > 0)
            {
                var parts = text.split(src, sep);
                var count = parts.Length;
                dst = alloc<FS.FolderPath>(count);
                for(var j=0; j<count; j++)
                    dst[j] = FS.dir(skip(parts,j));
            }
            else
                dst = new FolderPaths(new FS.FolderPath[]{FS.dir(src)});
            return result;
        }

        public static Outcome parse(string src, out FolderPaths dst)
            => parse(Chars.Semicolon, src, out dst);

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

        public string Format(char sep)
            => format(this, sep);

        [MethodImpl(Inline)]
        public static implicit operator FolderPaths(FS.FolderPath[] src)
            => new FolderPaths(src);

        [MethodImpl(Inline)]
        public static implicit operator FS.FolderPath[](FolderPaths src)
            => src.Storage;
    }
}