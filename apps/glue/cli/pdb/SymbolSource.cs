//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.IO;

    using static Root;
    using static core;
    using static PdbServices;

    public ref struct PdbSymbolSource
    {
        public bool IsPortable {get;}

        public FS.FilePath PePath {get;}

        readonly ReadOnlySpan<byte> PeData;

        readonly ReadOnlySpan<byte> PdbData;

        readonly PinnedPtr<byte> PePin;

        readonly PinnedPtr<byte> PdbPin;

        public MemoryStream PeStream {get;}

        public ByteSize PeSize
        {
            [MethodImpl(Inline)]
            get => PeData.Length;
        }

        public FS.FilePath PdbPath {get;}

        public MemoryStream PdbStream {get;}

        public PdbKind PdbKind {get;}

        public ByteSize PdbSize
        {
            [MethodImpl(Inline)]
            get => PdbData.Length;
        }

        /// <summary>
        /// Specifies whether the pe image has been loaded by the runtime
        /// </summary>
        public bool RuntimeLoaded {get;}

        /// <summary>
        /// Specifies whether the pe and pdb streams are defined
        /// </summary>
        public bool Streams {get;}

        internal PdbSymbolSource(ReadOnlySpan<byte> pe, ReadOnlySpan<byte> pdb)
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
            IsPortable = portable(PdbData);
            PdbKind = pdbkind(PdbData);
        }

        internal PdbSymbolSource(FS.FilePath pe, FS.FilePath pdb)
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
            IsPortable = portable(PdbData);
            PdbKind = pdbkind(PdbData);
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

        public static PdbSymbolSource Empty
        {
            [MethodImpl(Inline)]
            get => new PdbSymbolSource(sys.empty<byte>().ToReadOnlySpan(), sys.empty<byte>().ToReadOnlySpan());
        }
    }
}