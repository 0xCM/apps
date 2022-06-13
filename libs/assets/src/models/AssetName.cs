//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct AssetName : IComparable<AssetName>
    {
        public readonly string FullName;

        public readonly string ShortName;

        public readonly Hash32 Hash;

        [MethodImpl(Inline)]
        internal AssetName(string full, string @short)
        {
            FullName = full;
            ShortName = @short;
            Hash = core.hash(full);
        }

        public ResourceName ManifestName
        {
            [MethodImpl(Inline)]
            get => new ResourceName(FullName);
        }

        public override int GetHashCode()
            => Hash;

        public bool Equals(AssetName src)
            => FullName == src.FullName;

        public bool Contains(string match)
            => text.contains(FullName,match);

        public string Format()
            => FullName;

        public override string ToString()
            => Format();

        public int CompareTo(AssetName src)
            => FullName.CompareTo(src.FullName);

        public FS.FileName FileName
            => FS.file(FullName.ReplaceAny(Path.GetInvalidPathChars(), Chars.Underscore));

        public FS.FileName ShortFileName
            => FS.file(ShortName.ReplaceAny(Path.GetInvalidPathChars(), Chars.Underscore));

        public static AssetName Empty => new AssetName(EmptyString, EmptyString);
    }
}