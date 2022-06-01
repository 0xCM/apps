//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [ApiHost]
    public readonly partial struct Storage
    {
        const NumericKind Closure = UnsignedInts;

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
        public static ByteBlock16 block(W128 w, ReadOnlySpan<byte> src)
        {
            var dst = ByteBlock16.Empty;
            Bytes.copy(src,ref dst);
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static ByteBlock32 block(W256 w, ReadOnlySpan<byte> src)
        {
            var dst = ByteBlock32.Empty;
            Bytes.copy(src,ref dst);
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static ByteBlock64 block(Vector256<byte> lo, Vector256<byte> hi)
        {
            var src = new Seg512(lo,hi);
            var dst = ByteBlocks.alloc(n64);
            Bytes.copy(bytes(src), ref dst);
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

        [MethodImpl(Inline), Op]
        public static T block<T>(ReadOnlySpan<byte> src)
            where T : unmanaged, IStorageBlock
        {
            var dst = default(T);
            copy(src, ref dst);
            return dst;
        }


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