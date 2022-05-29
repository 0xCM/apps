//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static MemorySections;

    using System.IO;

    [Free]
    public interface IMemoryEmitter
    {
        void Emit(MemoryRange src, StreamWriter dst, byte bpl = 40);

        void Emit(MemoryRange src, FS.FilePath dst, byte bpl = 40);

        void Emit(MemoryAddress @base, ByteSize size, FS.FilePath dst, byte bpl = 40);

        void EmitPaged(MemoryRange src, StreamWriter dst, byte bpl = 40);

        void EmitPaged(MemoryRange src, FS.FilePath dst, byte bpl = 40);

        void EmitPaged(MemoryAddress @base, ByteSize size, FS.FilePath dst, byte bpl = 40);
    }

    [Free]
    public interface IMemorySection
    {
        ushort Index {get;}

        MemoryAddress Base();

        Capacity Capacity();

        Span<byte> Storage();

        Span<T> Storage<T>()
            where T : unmanaged
                => core.recover<T>(Storage());

        Descriptor Descriptor()
            => new Descriptor(Index, Base(), Capacity());

        ByteSize SegSize
            => Capacity().SegSize;

        byte SegScale
            => Capacity().SegsPerBlock;

        uint BlockCount
            => Capacity().BlockCount;

        ByteSize BlockSize
            => Capacity().BlockSize;

        ByteSize TotalSize
            => Capacity().TotalSize;
    }

    [Free]
    public interface IMemorySection<T> : IMemorySection
        where T : unmanaged, IMemorySection<T>
    {
    }
}