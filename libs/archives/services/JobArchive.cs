//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct JobArchive : IDbArchive<JobArchive>
    {
        public FS.FolderPath Root {get;}

        public JobArchive(FS.FolderPath root)
        {
            Root = root;
        }

        public ReadOnlySeq<JobType> JobTypes()
            => default;
    }

    public readonly record struct JobType : INamed<JobType>
    {
        public readonly asci16 Name;

        [MethodImpl(Inline)]
        public JobType(asci16 name)
        {
            Name = name;
        }

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

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Name.Hash;
        }

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public string Format()
            => Name.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public int CompareTo(JobType src)
            => Name.CompareTo(src.Name);

        [MethodImpl(Inline)]
        public bool Equals(JobType src)
            => Name.Equals(src.Name);

        [MethodImpl(Inline)]
        public static implicit operator JobType(string name)
            => new JobType(name);

        [MethodImpl(Inline)]
        public static implicit operator JobType(asci16 name)
            => new JobType(name);
    }
}