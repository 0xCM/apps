//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public readonly struct StorageBlocks
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op]
        public static ByteBlock16 block(W128 w, ReadOnlySpan<byte> src)
        {
            var dst = ByteBlock16.Empty;
            copy(src,ref dst);
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static ByteBlock32 block(W256 w, ReadOnlySpan<byte> src)
        {
            var dst = ByteBlock32.Empty;
            copy(src,ref dst);
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static ByteBlock64 block(Vector256<byte> lo, Vector256<byte> hi)
        {
            var src = new Seg512(lo,hi);
            var dst = ByteBlocks.alloc(n64);
            copy(bytes(src), ref dst);
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static ByteBlock32 block(Vector256<byte> src)
        {
            var dst = ByteBlock32.Empty;
            cpu.vstore(src, dst.Bytes);
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static ByteBlock16 block(Vector128<byte> src)
        {
            var dst = ByteBlock16.Empty;
            cpu.vstore(src, dst.Bytes);
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static Vector128<byte> vector(W128 w, ByteBlock16 src)
            => gcpu.vload(w, src.Bytes);

        [MethodImpl(Inline), Op]
        public static Vector256<byte> vector(W256 w, ByteBlock32 src)
            => gcpu.vload(w, src.Bytes);

        [MethodImpl(Inline), Op]
        public static Vector128<T> vector<T>(W128 w, ByteBlock16 src)
            where T : unmanaged
                => gcpu.vload(w, @as<T>(src.First));

        [MethodImpl(Inline), Op]
        public static Vector256<T> vector<T>(W256 w, ByteBlock32 src)
            where T : unmanaged
                => gcpu.vload(w, @as<T>(src.First));

        readonly struct Seg512
        {
            readonly Vector256<byte> Lo;

            readonly Vector256<byte> Hi;

            [MethodImpl(Inline), Op]
            public Seg512(Vector256<byte> lo, Vector256<byte> hi)
            {
                Lo = lo;
                Hi = hi;
            }
        }

        // [MethodImpl(Inline), Op]
        // public static ref ByteBlock2 copy(ReadOnlySpan<byte> src, ref ByteBlock2 dst)
        // {
        //     const ushort Size = ByteBlock2.Size;
        //     var size = max(src.Length, Size);
        //     ref var target = ref u8(dst);
        //     if(size == Size)
        //         dst = @as<ByteBlock2>(src);
        //     else
        //         Bytes.copy(slice(src, 0, size), ref target);
        //     return ref dst;
        // }

        // [MethodImpl(Inline), Op]
        // public static ref ByteBlock3 copy(ReadOnlySpan<byte> src, ref ByteBlock3 dst)
        // {
        //     const ushort Size = ByteBlock3.Size;
        //     var size = max(src.Length, Size);
        //     ref var target = ref u8(dst);
        //     if(size == Size)
        //         dst = @as<ByteBlock3>(src);
        //     else
        //         Bytes.copy(slice(src, 0, size), ref target);
        //     return ref dst;
        // }

        // [MethodImpl(Inline), Op]
        // public static ref ByteBlock4 copy(ReadOnlySpan<byte> src, ref ByteBlock4 dst)
        // {
        //     const ushort Size = ByteBlock4.Size;
        //     var size = max(src.Length, Size);
        //     ref var target = ref u8(dst);
        //     if(size == Size)
        //         dst = @as<ByteBlock4>(src);
        //     else
        //         Bytes.copy(slice(src, 0, size), ref target);
        //     return ref dst;
        // }

        // [MethodImpl(Inline), Op]
        // public static ref ByteBlock5 copy(ReadOnlySpan<byte> src, ref ByteBlock5 dst)
        // {
        //     const ushort Size = ByteBlock5.Size;
        //     var size = max(src.Length, Size);
        //     ref var target = ref u8(dst);
        //     if(size == Size)
        //         dst = @as<ByteBlock5>(src);
        //     else
        //         Bytes.copy(slice(src, 0, size), ref target);
        //     return ref dst;
        // }

        // [MethodImpl(Inline), Op]
        // public static ref ByteBlock8 copy(ReadOnlySpan<byte> src, ref ByteBlock8 dst)
        // {
        //     const ushort Size = ByteBlock8.Size;
        //     var size = max(src.Length, Size);
        //     ref var target = ref u8(dst);
        //     if(size == Size)
        //         dst = @as<ByteBlock8>(src);
        //     else
        //         Bytes.copy(slice(src, 0, size), ref target);
        //     return ref dst;
        // }

        [MethodImpl(Inline), Op]
        public static T block<T>(ReadOnlySpan<byte> src)
            where T : unmanaged, IStorageBlock
        {
            var dst = default(T);
            copy(src, ref dst);
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static ref T copy<T>(ReadOnlySpan<byte> src, ref T dst)
            where T : unmanaged, IStorageBlock
        {
            var size = max(src.Length, dst.Size);
            ref var target = ref u8(dst);
            if(size == dst.Size)
                dst = @as<T>(src);
            else
                Bytes.copy(slice(src, 0, size), ref target);
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref ByteBlock16 copy(ReadOnlySpan<byte> src, ref ByteBlock16 dst)
        {
            const ushort Size = ByteBlock16.Size;
            var w = w128;
            ref var target = ref u8(dst);
            var size = max(src.Length, Size);
            var data = slice(src, 0, size);
            if(size == Size)
                cpu.vstore(cpu.vload(w, data), ref target);
            else
                Bytes.copy(data,  ref target);

            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref ByteBlock32 copy(ReadOnlySpan<byte> src, ref ByteBlock32 dst)
        {
            const ushort Size = ByteBlock32.Size;
            var w = w256;
            ref var target = ref u8(dst);
            var size = max(src.Length, Size);
            var data = slice(src, 0, size);
            if(size == Size)
                cpu.vstore(cpu.vload(w, data), ref target);
            else
                Bytes.copy(data,  ref target);
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref ByteBlock64 copy(ReadOnlySpan<byte> src, ref ByteBlock64 dst)
        {
            ref var lo = ref @as<ByteBlock64,ByteBlock32>(dst);
            ref var hi = ref seek(lo,1);
            copy(src, ref lo);
            copy(slice(src,32), ref hi);
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref ByteBlock128 copy(ReadOnlySpan<byte> src, ref ByteBlock128 dst)
        {
            const ushort Block0 = 0*32;
            const ushort Block1 = 1*32;
            const ushort Block2 = 2*32;
            const ushort Block3 = 3*32;

            var v0 = cpu.vload(w256, skip(src,Block0));
            cpu.vstore(v0, ref seek(u8(dst), Block0));

            v0 = cpu.vload(w256, skip(src, Block1));
            cpu.vstore(v0, ref seek(u8(dst), Block1));

            v0 = cpu.vload(w256, skip(src, Block2));
            cpu.vstore(v0, ref seek(u8(dst), Block2));

            v0 = cpu.vload(w256, skip(src, Block3));
            cpu.vstore(v0, ref seek(u8(dst), Block3));

            return ref dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T cell<T>(ref T src, int index)
            where T : unmanaged, IStorageBlock<T>
                => ref seek(recover<T>(src.Bytes),index);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> span<T>(ref T src)
            where T : unmanaged, IStorageBlock<T>
                => recover<T>(src.Bytes);

        public static string format<T>(in T src)
            where T : unmanaged, IStorageBlock<T>
                => src.Bytes.FormatHex();

        public static string format<T>(in T src, char sep, bool prespec=false, bool uppercase = false)
            where T : unmanaged, IStorageBlock<T>
                => src.Bytes.FormatHex(sep, prespec:prespec, uppercase:uppercase);

        public static string format<T>(in T src, in HexFormatOptions options)
            where T : unmanaged, IStorageBlock<T>
                => src.Bytes.FormatHex(options);

        [MethodImpl(Inline)]
        public static TrimmedBlock<T> trim<T>(in T src)
            where T : unmanaged, IStorageBlock<T>
                => src;

        [MethodImpl(Inline)]
        public static ByteSize size<T>(in TrimmedBlock<T> src)
            where T : unmanaged, IStorageBlock<T>
        {
            var data = src.BlockData;
            var length = (int)src.BlockSize;
            var size = 0;
            for(var i=length-1; i>=0; i--)
            {
                ref readonly var b = ref skip(data,i);
                if(b == 0)
                    continue;
                else
                {
                    size = i + 1;
                    break;
                }

            }
            return size;
        }

        public static string format<T>(in TrimmedBlock<T> src)
            where T : unmanaged, IStorageBlock<T>
        {
            var sz = size(src);
            if(sz == 0)
                sz = 1;
            return core.slice(src.BlockData, 0, sz).FormatHex();
        }

        public static string format<T>(in TrimmedBlock<T> src, in HexFormatOptions options)
            where T : unmanaged, IStorageBlock<T>
                => core.slice(src.BlockData, 0, size(src)).FormatHex(options);

        [MethodImpl(Inline)]
        public static bool empty<T>(in T src)
            where T : unmanaged, IStorageBlock<T>
        {
            var b = src.Bytes;
            var count = b.Length;
            var empty = true;
            for(var i=0; i<count; i++)
            {
                if(skip(b,i) != 0)
                {
                    empty=false;
                    break;
                }
            }
            return empty;
        }
    }
}