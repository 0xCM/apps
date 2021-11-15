//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection.Metadata;
    using System.Reflection.PortableExecutable;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    using static Root;

    [ApiHost, Free]
    public unsafe partial class CliMemoryMap : IDisposable
    {
        public static CliMemoryMap create(FS.FilePath src)
            => new CliMemoryMap(src);

        readonly MemoryFile Source;

        public PEReader PE {get;}

        public MetadataReader MD {get;}

        public ulong ImageSize {get;}

        public Ptr<byte> BasePointer {get;}

        public PEMemoryBlock MtadataBlock {get;}

        public CliMemoryMap(FS.FilePath src)
        {
            if(src.IsNonEmpty)
            {
                Source = MemoryFiles.map(src);
                BasePointer = Source.BaseAddress.Pointer<byte>();
                PE = new PEReader(BasePointer, (int)Source.Size);
                ImageSize = Source.Size;
                MD = PE.GetMetadataReader();
                MtadataBlock = PE.GetMetadata();
            }
            else
            {
                Source = MemoryFile.Empty;
            }
        }


        public void Dispose()
        {
            if(IsNonEmpty)
            {
                PE.Dispose();
                Source.Dispose();
            }
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Source.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Source.IsNonEmpty;
        }

        public DirectoryEntry ResourceDirectory
        {
            [MethodImpl(Inline)]
            get => PeHeaders.PEHeader.ResourceTableDirectory;
        }

        public MemorySeg ResourceSegment
        {
            [MethodImpl(Inline)]
            get => new MemorySeg(((MemoryAddress)ResourceDirectory.RelativeVirtualAddress).Pointer<byte>(), ResourceDirectory.Size);
        }

        public PEHeaders PeHeaders
        {
            [MethodImpl(Inline)]
            get => PE.PEHeaders;
        }

        public CoffHeader CoffHeader
        {
            [MethodImpl(Inline)]
            get => PeHeaders.CoffHeader;
        }

        public CorHeader CorHeader
        {
            [MethodImpl(Inline)]
            get => PeHeaders.CorHeader;
        }

        [MethodImpl(Inline)]
        public PEMemoryBlock SectonData(DirectoryEntry src)
            => PE.GetSectionData(src.RelativeVirtualAddress);

        [MethodImpl(Inline)]
        public unsafe ReadOnlySpan<byte> Read(PEMemoryBlock src)
            => core.cover<byte>(src.Pointer, (uint)src.Length);

        public ReadOnlySpan<byte> Resources
        {
            [MethodImpl(Inline)]
            get => Read(SectonData(ResourceDirectory));
        }

        public static CliMemoryMap Empty
            => new CliMemoryMap(FS.FilePath.Empty);
    }
}