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
    using static core;

    public readonly struct ClrTypeAdapter : IClrRuntimeType<ClrTypeAdapter>
    {
        public Type Definition {get;}

        public ClrArtifactKind Kind
            => (ClrArtifactKind)Definition.TypeKind();

        [MethodImpl(Inline)]
        public ClrTypeAdapter(Type src)
            => Definition = src;

        public Assembly Assembly
        {
            [MethodImpl(Inline)]
            get => Definition.Assembly;
        }

        public CliToken Token
        {
            [MethodImpl(Inline)]
            get => Definition.MetadataToken;
        }

        public string Name
        {
            [MethodImpl(Inline)]
            get => Definition.Name;
        }

        public ReadOnlySpan<ClrTypeAdapter> NestedTypes
        {
            [MethodImpl(Inline)]
            get => recover<Type,ClrTypeAdapter>(Definition.GetNestedTypes());
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Definition is null;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !IsEmpty;
        }

        string IClrArtifact.Name
            => Definition.Name;

        [MethodImpl(Inline), Closures(AllNumeric)]
        public static ClrTypeAdapter<T> From<T>()
            => default;

        [MethodImpl(Inline), Ignore]
        public string Format()
            => Definition.FullName;

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator ClrTypeAdapter(Type src)
            => new ClrTypeAdapter(src);

        [MethodImpl(Inline)]
        public static implicit operator Type(ClrTypeAdapter src)
            => src.Definition;
    }
}