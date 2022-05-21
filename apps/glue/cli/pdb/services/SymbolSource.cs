//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public ref struct PdbSymbolSource
    {
        /// <summary>
        /// Loads a symbol source from specified binary data
        /// </summary>
        /// <param name="pe">The pe data</param>
        /// <param name="pdb">The pdb data</param>
        [Op]
        public static PdbSymbolSource create(ReadOnlySpan<byte> pe, ReadOnlySpan<byte> pdb)
            => new PdbSymbolSource(pe,pdb);

        /// <summary>
        /// Loads a <see cref='PdbSymbolSource'/> for specified pe and pdb paths
        /// </summary>
        /// <param name="pe">The pe file path</param>
        /// <param name="pdb">The pdb file path</param>
        [Op]
        public static PdbSymbolSource create(FS.FilePath pe, FS.FilePath pdb)
            => new PdbSymbolSource(pe, pdb);

        /// <summary>
        /// Loads a <see cref='PdbSymbolSource'/> for specified pe, assuming the existence of a colocated pdb
        /// </summary>
        /// <param name="pe">The pe file path</param>
        [Op]
        public static PdbSymbolSource create(FS.FilePath pe)
            => new PdbSymbolSource(pe, pe.ChangeExtension(FS.Pdb));

        public readonly bool IsPortable;

        public readonly FS.FilePath PePath;

        readonly ReadOnlySpan<byte> PeData;

        readonly ReadOnlySpan<byte> PdbData;

        readonly PinnedPtr<byte> PePin;

        readonly PinnedPtr<byte> PdbPin;

        public readonly MemoryStream PeStream;

        public readonly FS.FilePath PdbPath;

        public readonly MemoryStream PdbStream;

        public readonly PdbKind PdbKind;

        /// <summary>
        /// Specifies whether the pe image has been loaded by the runtime
        /// </summary>
        public readonly bool RuntimeLoaded;

        /// <summary>
        /// Specifies whether the pe and pdb streams are defined
        /// </summary>
        public readonly bool Streams;

        public PdbSymbolSource(ReadOnlySpan<byte> pe, ReadOnlySpan<byte> pdb)
        {
            RuntimeLoaded = true;
            Streams = false;
            PePath = FS.FilePath.Empty;
            PdbPath = FS.FilePath.Empty;
            PeData = pe;
            PdbData = pdb;
            PeStream = default;
            PdbStream = default;
            PePin = PinnedPtr<byte>.Empty;
            PdbPin = PinnedPtr<byte>.Empty;
            IsPortable = PdbQuery.portable(PdbData);
            PdbKind = PdbQuery.pdbkind(PdbData);
        }

        public PdbSymbolSource(FS.FilePath pe, FS.FilePath pdb)
        {
            RuntimeLoaded = false;
            Streams = true;
            PePath = pe;
            PdbPath = pdb;
            var peData = File.ReadAllBytes(PePath.Name);
            var pdbData = File.ReadAllBytes(PdbPath.Name);
            PePin = memory.pin<byte>(peData);
            PdbPin = memory.pin<byte>(pdbData);
            PeData = peData;
            PdbData = pdbData;
            PeStream = new MemoryStream(peData);
            PdbStream = new MemoryStream(pdbData);
            IsPortable = PdbQuery.portable(PdbData);
            PdbKind = PdbQuery.pdbkind(PdbData);
        }

        public void Dispose()
        {
            PeStream?.Dispose();
            PdbStream?.Dispose();
            PePin.Dispose();
            PdbPin.Dispose();
        }

        public unsafe SegRef PeSrc
        {
            [MethodImpl(Inline)]
            get => new SegRef(address(PeData), PeData.Length);
        }

        public unsafe SegRef PdbSrc
        {
            [MethodImpl(Inline)]
            get => new SegRef(address(PdbData), PdbData.Length);
        }

        public ByteSize PdbSize
        {
            [MethodImpl(Inline)]
            get => PdbData.Length;
        }

        public ByteSize PeSize
        {
            [MethodImpl(Inline)]
            get => PeData.Length;
        }

        public static PdbSymbolSource Empty
        {
            [MethodImpl(Inline)]
            get => new PdbSymbolSource(sys.empty<byte>().ToReadOnlySpan(), sys.empty<byte>().ToReadOnlySpan());
        }
    }
}