//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public readonly struct FixedChars
    {
        [MethodImpl(Inline), Op]
        public static uint hash(text7 src)
            => alg.hash.calc(src.Storage);

        [Op]
        public static string format(in text7 src)
        {
            Span<char> dst = stackalloc char[text7.MaxLength];
            var count = src.Length;
            var data = src.Bytes;
            for(var i=0; i<count; i++)
                seek(dst, i) = (char)skip(data,i);
            return TextTools.format(slice(dst,0,count));
        }

        [MethodImpl(Inline), Op]
        public static text7 txt(N7 n, ReadOnlySpan<char> src)
        {
            const byte Max = text7.MaxLength;
            var length = (byte)min(available(src), Max);
            var storage = 0ul;
            var dst = bytes(storage);
            pack(src, length, dst);
            seek(dst,7) = length;
            return new text7(storage);
        }

        [MethodImpl(Inline), Op]
        public static text7 txt(N7 n7, char src)
        {
            var storage = (ulong)src;
            return new text7(storage);
        }

        [MethodImpl(Inline), Op]
        public static bool eq(text7 a, text7 b)
            => a.Storage == b.Storage;

        [MethodImpl(Inline), Op]
        public static bool neq(text7 a, text7 b)
            => a.Storage != b.Storage;

        [MethodImpl(Inline), Op]
        public static text31 txt(N31 n, ReadOnlySpan<char> src)
        {
            const byte Max = text31.MaxLength;
            var length = (byte)min(available(src), Max);
            var storage = text31.StorageType.Empty;
            var dst = storage.Bytes;
            pack(src, length, dst);
            seek(dst,31) = length;
            return new text31(storage);
        }

        [Op]
        public static string format(in text31 src)
        {
            Span<char> dst = stackalloc char[text31.MaxLength];
            var count = src.Length;
            var data = src.Bytes;
            for(var i=0; i<count; i++)
                seek(dst,i) = (char)skip(data,i);
            return TextTools.format(slice(dst,0,count));
        }

        [MethodImpl(Inline), Op]
        public static text15 txt(N15 n, ReadOnlySpan<char> src)
        {
            const byte Max = text15.MaxLength;
            var length = (byte)min(available(src), Max);
            var storage = text15.StorageType.Empty;
            var dst = storage.Bytes;
            pack(src, length, dst);
            seek(dst,15) = length;
            return new text15(storage);
        }

        [MethodImpl(Inline), Op]
        static uint available(ReadOnlySpan<char> src)
        {
            var present = 0u;
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                if(skip(src,i) != 0)
                    present++;
                else
                    break;
            }
            return present;
        }

        [MethodImpl(Inline), Op]
        static void pack(ReadOnlySpan<char> src, uint count, Span<byte> dst)
        {
            for(var i=0; i<count; i++)
                seek(dst,i) = (byte)skip(src,i);
        }

        [Op]
        public static string format(in text15 src)
        {
            Span<char> dst = stackalloc char[text15.MaxLength];
            var count = src.Length;
            var data = src.Bytes;
            for(var i=0; i<count; i++)
                seek(dst,i) = (char)skip(data,i);
            return TextTools.format(slice(dst,0,count));
        }
    }
}