//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection;

    using static Root;
    using static core;

    [ApiHost]
    public readonly partial struct CliHeaps
    {
        public static string describe<T>(T heap)
            where T : ICliHeap
                => string.Format("{0,-20} | {1} | {2}", heap.HeapKind, heap.BaseAddress, heap.Size);

        public static Index<CliBlobHeap> blobs(ReadOnlySpan<Assembly> src)
        {
            var count = src.Length;
            var buffer = alloc<CliBlobHeap>(count);
            ref var dst = ref first(buffer);
            for(var i=0; i<count; i++)
            {
                ref readonly var component = ref skip(src,i);
                var reader = CliReader.read(component);
                seek(dst,i) = reader.BlobHeap();
            }
            return buffer;
        }

        public static Index<CliGuidHeap> guids(ReadOnlySpan<Assembly> src)
        {
            var count = src.Length;
            var buffer = alloc<CliGuidHeap>(count);
            ref var dst = ref first(buffer);
            for(var i=0; i<count; i++)
            {
                ref readonly var component = ref skip(src,i);
                var reader = CliReader.read(component);
                seek(dst,i) = reader.GuidHeap();
            }
            return buffer;
        }

        public static Index<CliStringHeap> strings(ReadOnlySpan<Assembly> src)
        {
            var count = src.Length;
            var buffer = alloc<CliStringHeap>(count*2);
            ref var dst = ref first(buffer);
            var j=0;
            for(var i=0; i<count; i++)
            {
                ref readonly var component = ref skip(src,i);
                var reader = CliReader.read(component);
                seek(dst,j++) = reader.StringHeap(CliStringKind.System);
                seek(dst,j++) = reader.StringHeap(CliStringKind.User);
            }
            return buffer;
        }

        [MethodImpl(Inline), Op]
        public static unsafe uint count(CliStringHeap src)
        {
            var counter = 0u;
            var pCurrent = src.BaseAddress.Pointer<char>();
            var pLast = (src.BaseAddress + src.Size).Pointer<char>();
            while(pCurrent < pLast)
            {
                if(*pCurrent++ == Chars.Null)
                    counter++;
            }
            return counter;
        }

        [MethodImpl(Inline), Op]
        public static unsafe uint terminators(CliStringHeap src, Span<uint> dst)
        {
            var counter = 0u;
            var pCurrent = src.BaseAddress.Pointer<char>();
            var pLast = (src.BaseAddress + src.Size).Pointer<char>();
            var pos = 0u;
            while(pCurrent < pLast)
            {
                if(*pCurrent++ == Chars.Null)
                    seek(dst, counter++) = pos*2;
                pos++;
            }
            return counter;
        }

        public static Index<uint> terminators(CliStringHeap src)
        {
            var dst = alloc<uint>(count(src));
            terminators(src,dst);
            return dst;
        }
    }
}