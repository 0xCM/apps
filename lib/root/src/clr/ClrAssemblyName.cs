//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection;

    using static Root;

    using api = ClrAssemblyNames;

    public readonly struct ClrAssemblyName : IEquatable<ClrAssemblyName>
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

        [MethodImpl(Inline)]
        public string Format()
            => api.format(Subject);

        [MethodImpl(Inline)]
        public string Format(AssemblyNameKind kind)
            => api.format(Subject, kind);

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => Subject?.GetHashCode() ?? 0;

        public bool Equals(ClrAssemblyName src)
            => Subject?.Equals(src.Subject) ?? false;

        public override bool Equals(object src)
            => src is ClrAssemblyName n && Equals(n);

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