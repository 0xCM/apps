//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Reflection.Metadata;
    using System.Reflection.PortableExecutable;
    using System.Reflection.Metadata.Ecma335;
    using System.IO;
    using System.Linq;

    using static Root;
    using static core;
    using static PeRecords;

    public partial class PeReader : IDisposable
    {
        public static CliRowIndex index(in PeStream state, Handle handle)
            => new CliToken(state.Reader.GetToken(handle));

        [Op]
        public static PeReader create(FS.FilePath src)
            => new PeReader(src);

        readonly FS.FilePath Source;

        readonly FileStream Stream;

        public PEReader PE {get;}

        public MetadataReader MD
        {
            [MethodImpl(Inline)]
            get
            {
                if(_MD == null)
                    _MD = PE.GetMetadataReader();
                return _MD;
            }
        }

        MetadataReader _MD;

        PEMemoryBlock? _MetadataBlock;

        PEMemoryBlock MetadataBlock
        {
            [MethodImpl(Inline)]
            get
            {
                if(!_MetadataBlock.HasValue)
                    _MetadataBlock = PE.GetMetadata();
                return _MetadataBlock.Value;
            }
        }

        CliReader CliReader()
            => Z0.CliReader.read(MetadataBlock);

        public PeReader(FS.FilePath src)
        {
            Source = src;
            Stream = File.OpenRead(src.Name);
            PE = new PEReader(Stream);
        }

        [MethodImpl(Inline)]
        public unsafe ReadOnlySpan<byte> Read(PEMemoryBlock src)
            => cover<byte>(src.Pointer, src.Length);

        public void Dispose()
        {
            PE?.Dispose();
            Stream?.Dispose();
        }

        public PeFileInfo ReadPeInfo()
        {
            var pe = PE.PEHeaders.PEHeader;
            var coff = PE.PEHeaders.CoffHeader;
            var dst = new PeFileInfo();
            dst.Machine = coff.Machine;
            dst.ImageBase = pe.ImageBase;
            dst.EntryPointOffset = pe.AddressOfEntryPoint;
            dst.CodeOffset = pe.BaseOfCode;
            dst.CodeSize = (uint)pe.SizeOfCode;
            dst.DataOffset = pe.BaseOfData;
            dst.ImageSize = (uint)pe.SizeOfImage;
            dst.ExportDir = pe.ExportTableDirectory;
            dst.ImportDir = pe.ImportTableDirectory;
            dst.ResourceDir = pe.ResourceTableDirectory;
            dst.RelocationDir = pe.BaseRelocationTableDirectory;
            dst.ImportAddressDir = pe.ImportAddressTableDirectory;
            dst.LoadConfigDir = pe.LoadConfigTableDirectory;
            dst.DebugDir = pe.DebugTableDirectory;
            dst.Characteristics = coff.Characteristics;
            return dst;
        }

        public CoffInfo ReadCoffInfo()
        {
            var src = PeHeaders.CoffHeader;
            var dst = new CoffInfo();
            dst.Characteristics = src.Characteristics;
            dst.Machine = src.Machine;
            dst.NumberOfSections = (ushort)src.NumberOfSections;
            dst.NumberOfSymbols = (uint)src.NumberOfSymbols;
            dst.PointerToSymbolTable = src.PointerToSymbolTable;
            dst.SizeOfOptionalHeader = (ushort)src.SizeOfOptionalHeader;
            dst.TimeDateStamp = (uint)src.TimeDateStamp;
            return dst;
        }

        public PEHeaders PeHeaders
        {
            [MethodImpl(Inline)]
            get => PE.PEHeaders;
        }

        public CorHeader CorHeader
        {
            [MethodImpl(Inline)]
            get => PeHeaders.CorHeader;
        }

        ReadOnlySpan<SectionHeader> SectionHeaders
            => PeHeaders.SectionHeaders.ToReadOnlySpan();

        public ReadOnlySpan<MemberReferenceHandle> MemberRefHandles
            => MD.MemberReferences.ToArray();

        public DirectoryEntry ResourcesDirectory
            => CorHeader.ResourcesDirectory;

        public DirectoryEntry CodeManagerTableDirectory
            => CorHeader.CodeManagerTableDirectory;

        public DirectoryEntry ExportAddressTableJumpsDirectory
            => CorHeader.ExportAddressTableJumpsDirectory;

        public CorFlags Flags
            => CorHeader.Flags;

        public DirectoryEntry ManagedNativeHeaderDirectory
            => CorHeader.ManagedNativeHeaderDirectory;

        public DirectoryEntry MetadataDirectory
            => CorHeader.MetadataDirectory;

        public DirectoryEntry VtableFixupsDirectory
            => CorHeader.VtableFixupsDirectory;

        public PEMemoryBlock ReadSectionData(DirectoryEntry src)
            => PE.GetSectionData(src.RelativeVirtualAddress);
    }
}