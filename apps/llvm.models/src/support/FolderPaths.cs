//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public readonly struct FolderPaths : IIndex<FS.FolderPath>
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

        Index<FS.FolderPath> Data {get;}

        [MethodImpl(Inline)]
        public FolderPaths(FS.FolderPath[] src)
        {
            Data = src;
        }

        public FS.FolderPath[] Storage
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public ref FS.FolderPath this[int index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ref FS.FolderPath this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public string Format()
            => format(this);

        public string Format(char sep)
            => format(this, sep);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator FolderPaths(FS.FolderPath[] src)
            => new FolderPaths(src);

        [MethodImpl(Inline)]
        public static implicit operator FS.FolderPath[](FolderPaths src)
            => src.Storage;

        public static FolderPaths Empty
            => sys.empty<FS.FolderPath>();
    }
}