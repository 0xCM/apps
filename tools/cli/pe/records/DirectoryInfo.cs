//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Reflection.PortableExecutable;

    using static Root;

    partial struct PeRecords
    {
        [StructLayout(LayoutKind.Sequential), Record(TableId)]
        public struct DirectoryInfo : IRecord<DirectoryInfo>
        {
            public const string TableId = "pe.dirinfo";

            public Address32 Rva;

            public uint Size;

            [MethodImpl(Inline)]
            internal DirectoryInfo(DirectoryEntry src)
            {
                Rva = src.RelativeVirtualAddress;
                Size = (uint)src.Size;
            }

            public static implicit operator DirectoryInfo(DirectoryEntry src)
                => new DirectoryInfo(src);
        }
    }
}