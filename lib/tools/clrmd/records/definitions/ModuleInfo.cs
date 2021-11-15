//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.InteropServices;

    using ClrMd = Microsoft.Diagnostics.Runtime;

    partial struct DiagnosticRecords
    {
        [Record(TableId), StructLayout(LayoutKind.Sequential)]
        public struct ModuleInfo : IRecord<ModuleInfo>
        {
            public const string TableId = "diagnostic.modules";

            public const byte FieldCount = 9;

            public StringAddress Name;

            public MemoryAddress Address;

            public MemoryAddress ImageBase;

            public MemoryAddress AssemblyAddress;

            public MemoryAddress MetadataAddress;

            public ByteSize MetadataSize;

            public ClrMd.ModuleLayout Layout;

            public PdbInfo Pdb;

            public StringAddress ModulePath;

            public static ReadOnlySpan<byte> RenderWidths
                => new byte[FieldCount]{64, 16, 16, 16, 16, 16, 16, 164, 8,};
        }
    }
}