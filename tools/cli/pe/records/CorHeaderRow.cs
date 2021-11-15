//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.InteropServices;
    using System.Reflection.PortableExecutable;

    partial struct PeRecords
    {
        [Record(TableId), StructLayout(LayoutKind.Sequential)]
        public struct CorHeaderRow : IRecord<CorHeaderRow>
        {
            public const string TableId = "pe-corheader";

            public ushort MajorRuntimeVersion;

            public ushort MinorRuntimeVersion;

            public DirectoryInfo MetadataDirectory;

            public CorFlags Flags;

            public int EntryPointTokenOrRelativeVirtualAddress;

            public DirectoryInfo ResourcesDirectory;

            public DirectoryInfo StrongNameSignatureDirectory;

            public DirectoryInfo CodeManagerTableDirectory;

            public DirectoryInfo VtableFixupsDirectory;

            public DirectoryInfo ExportAddressTableJumpsDirectory;

            public DirectoryInfo ManagedNativeHeaderDirectory;
        }
    }
}