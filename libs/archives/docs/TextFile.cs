//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        public static TextFileStats FileStats(this FS.FilePath src)
            => TextFile.stats(src);
    }

    public readonly struct TextFile : IFsEntry<TextFile>
    {
        public static TextFileStats stats(FS.FilePath src)
        {
            var dst = new TextFileStats();
            using var reader = src.Utf8Reader();
            var line = reader.ReadLine();
            while(line != null)
            {
                var length = (uint)line.Length;
                if(length > dst.MaxLineLength)
                    dst.MaxLineLength = length;
                dst.CharCount += length;
                dst.LineCount++;
                line = reader.ReadLine();
            }
            return dst;
        }


        public FS.FilePath Path {get;}

        public FS.PathPart Name
        {
            [MethodImpl(Inline)]
            get => Path.Name;
        }

        [MethodImpl(Inline)]
        public TextFile(FS.FilePath src)
            => Path = src;

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsNonEmpty;
        }

        [MethodImpl(Inline)]
        public int CompareTo(TextFile src)
            => Name.CompareTo(src.Name);

        [MethodImpl(Inline)]
        public bool Equals(TextFile src)
            => Name == src.Name;

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Name.Hash;
        }

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public static implicit operator TextFile(FS.FilePath src)
            => new TextFile(src);

        [MethodImpl(Inline)]
        public static implicit operator FS.FilePath(TextFile src)
            => src.Path;
    }
}