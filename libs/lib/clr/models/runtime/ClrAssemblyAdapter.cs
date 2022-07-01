//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ClrAssemblyAdapter : IRuntimeObject<ClrAssemblyAdapter,Assembly>
    {
        public Assembly Definition {get;}

        [MethodImpl(Inline)]
        public ClrAssemblyAdapter(Assembly src)
            => Definition = src;

        public ClrArtifactKind Kind
            => ClrArtifactKind.Assembly;

        public PartId Part
        {
            [MethodImpl(Inline)]
            get => Definition.Id();
        }

        public bool IsPart
        {
            [MethodImpl(Inline)]
            get => Definition.Id() != 0;
        }

        public NameOld SimpleName
        {
            [MethodImpl(Inline)]
            get => Definition.GetSimpleName();
        }

        public MemorySeg Metadata
        {
            [MethodImpl(Inline)]
            get => Clr.metadata(this);
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

        public ClrAssemblyName Name
            => Definition;

        public ReadOnlySpan<ClrAssemblyName> ReferencedAssemblies
            => Clr.references(Definition);

        public CliToken Token
        {
            [MethodImpl(Inline)]
            get => Definition.ManifestModule.MetadataToken;
        }

        public ReadOnlySpan<byte> RawMetadata
        {
            [MethodImpl(Inline)]
            get => Clr.metaspan(Definition);
        }

        string IClrArtifact.Name
            => Definition.FullName;

        [MethodImpl(Inline)]
        public static implicit operator Assembly(ClrAssemblyAdapter src)
            => src.Definition;

        [MethodImpl(Inline)]
        public static implicit operator ClrAssemblyAdapter(Assembly src)
            => new ClrAssemblyAdapter(src);
    }
}