//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = ClrAssemblyNames;

    public readonly record struct ClrAssemblyName : IDataType<ClrAssemblyName>
    {
        readonly AssemblyName Subject;

        [MethodImpl(Inline)]
        public ClrAssemblyName(AssemblyName src)
            => Subject = src;

        [MethodImpl(Inline)]
        public ClrAssemblyName(Assembly src)
            => Subject = src.GetName();

        public string FullName
        {
            [MethodImpl(Inline)]
            get => Subject.FullName;
        }

        public string SimpleName
        {
            [MethodImpl(Inline)]
            get => Subject.Name;
        }

        public AssemblyVersion Version
        {
            [MethodImpl(Inline)]
            get => api.version(Subject);
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => core.hash(FullName);
        }

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public string Format()
            => api.format(Subject);

        public override string ToString()
            => Format();

        public int CompareTo(ClrAssemblyName src)
            => FullName.CompareTo(src.FullName);

        [MethodImpl(Inline)]
        public string Format(AssemblyNameKind kind)
            => api.format(Subject, kind);

        public bool Equals(ClrAssemblyName src)
            => Subject?.Equals(src.Subject) ?? false;


        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Subject is null;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !(Subject is null);
        }

        [MethodImpl(Inline)]
        public static implicit operator ClrAssemblyName(AssemblyName src)
            => new ClrAssemblyName(src);

        [MethodImpl(Inline)]
        public static implicit operator AssemblyName(ClrAssemblyName src)
            => src.Subject;

        [MethodImpl(Inline)]
        public static implicit operator ClrAssemblyName(Assembly src)
            => new ClrAssemblyName(src);

        public static ClrAssemblyName Empty
        {
            [MethodImpl(Inline)]
            get => new ClrAssemblyName(new AssemblyName());
        }

    }
}