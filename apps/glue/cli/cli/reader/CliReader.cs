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

    using static Root;

    [ApiHost]
    public unsafe partial class CliReader
    {
        [Op]
        public static CliReader read(Assembly src)
            => new CliReader(src);

        [Op]
        public static CliReader read(MetadataReader src)
            => new CliReader(src);

        [Op]
        public static CliReader read(MemorySeg src)
            => new CliReader(src);

        [Op]
        public static CliReader read(PEMemoryBlock src)
            => new CliReader(src);

        const byte TableCount = (byte)TableIndex.CustomDebugInformation + 1;

        readonly MetadataReader MD;

        readonly MemorySeg Segment;

        [MethodImpl(Inline)]
        public CliReader(Assembly src)
        {
            Segment = Clr.metadata(src);
            MD = new MetadataReader(Segment.BaseAddress.Pointer<byte>(), Segment.Size);
        }

        [MethodImpl(Inline)]
        public CliReader(MemorySeg src)
        {
            Segment = src;
            MD = new MetadataReader(Segment.BaseAddress.Pointer<byte>(), Segment.Size);
        }

        [MethodImpl(Inline)]
        public CliReader(PEMemoryBlock src)
        {
            Segment = MemorySegs.define(src.Pointer, src.Length);
            MD = new MetadataReader(Segment.BaseAddress.Pointer<byte>(), Segment.Size);
        }

        [MethodImpl(Inline)]
        public CliReader(MetadataReader src)
        {
            Segment = MemorySegs.define(src.MetadataPointer, src.MetadataLength);
            MD = src;
        }

        public ByteSize MetaSize
        {
            [MethodImpl(Inline)]
            get => Segment.Size;
        }

        public ReadOnlySpan<byte> MetaBytes
        {
            [MethodImpl(Inline)]
            get => MemorySegs.view<byte>(Segment);
        }
    }
}