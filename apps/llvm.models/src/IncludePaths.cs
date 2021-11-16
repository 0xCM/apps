//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct IncludePaths : IIndex<FS.FolderPath>
    {
        public static Outcome parse(string src, out IncludePaths dst)
        {
            var result = Outcome.Success;
            dst = Empty;
            var i = text.index(src, Chars.Semicolon);
            if(i > 0)
            {


            }
            return result;
        }

        Index<FS.FolderPath> Data {get;}

        [MethodImpl(Inline)]
        public IncludePaths(FS.FolderPath[] src)
        {
            Data = src;
        }

        public FS.FolderPath[] Storage
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public string Format()
        {
            var dst = text.buffer();
            var count = Data.Count;
            for(var i=0; i<count; i++)
            {
                dst.Append(Data[i].Format(PathSeparator.BS));
                if(i != count - 1)
                    dst.Append(Chars.Semicolon);
            }
            return dst.Emit();
        }

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator IncludePaths(FS.FolderPath[] src)
            => new IncludePaths(src);

        [MethodImpl(Inline)]
        public static implicit operator FS.FolderPath[](IncludePaths src)
            => src.Storage;

        public static IncludePaths Empty => sys.empty<FS.FolderPath>();
    }
}