//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static text;

    [ApiHost]
    public readonly struct SizedText
    {
        public static asci<B> load<B>(ReadOnlySpan<byte> src)
            where B : unmanaged, IStorageBlock<B>
        {
            var data = src;
            var dst = asci<B>.Empty;
            if(data.Length >= asci<B>.StorageSize)
                dst = new asci<B>(@as<byte,B>(data));
            else
                dst = new asci<B>(Storage.block<B>(data));
            return dst;
        }

        [MethodImpl(Inline)]
        public static asci<B> load<B>(ReadOnlySpan<AsciSymbol> src)
        where B : unmanaged, IStorageBlock<B>
            => load<B>(core.recover<AsciSymbol,byte>(src));

        [MethodImpl(Inline)]
        public static asci<B> load<B>(ReadOnlySpan<AsciCode> src)
        where B : unmanaged, IStorageBlock<B>
            => load<B>(core.recover<AsciCode,byte>(src));

        public static text<K,B> load<K,B>(ReadOnlySpan<char> src)
            where K : unmanaged, IEquatable<K>, IComparable<K>
            where B : unmanaged, IStorageBlock<B>
        {
            var data = recover<byte>(span(src));
            var dst = text<K,B>.Empty;
            if(data.Length >= text<K,B>.StorageSize)
                dst = new text<K,B>(@as<byte,B>(data));
            else
                dst = new text<K,B>(Storage.block<B>(data));
            return dst;
        }

        public static text<K,B> load<K,B>(string src)
            where K : unmanaged, IEquatable<K>, IComparable<K>
            where B : unmanaged, IStorageBlock<B>
                => load<K,B>(core.span(src));


        [MethodImpl(Inline), Op]
        public static uint lines<C>(string src, Span<text<C>> dst, bool keepblank = false, bool trim = true)
            where C : unmanaged, ICharBlock<C>
        {
            var k=0u;
            var capacity = (uint)dst.Length;
            using(var reader = new StringReader(src))
            {
                var next = reader.ReadLine();
                while(next != null && k<capacity)
                {
                    if(text.blank(next))
                        if(keepblank)
                            seek(dst,k++) = next;
                    else
                        seek(dst, k++) = trim ? text.trim(next) : next;
                    next = reader.ReadLine();
                }
            }
            return k;
        }

        [MethodImpl(Inline), Op]
        public static uint lines<K,B>(string src, Span<text<K,B>> dst, bool keepblank = false, bool trim = true)
            where B : unmanaged, IStorageBlock<B>
            where K : unmanaged, IEquatable<K>, IComparable<K>
        {
            var k=0u;
            var capacity = (uint)dst.Length;
            using(var reader = new StringReader(src))
            {
                var next = reader.ReadLine();
                while(next != null && k<capacity)
                {
                    if(Z0.text.blank(next))
                        if(keepblank)
                            seek(dst,k++) = load<K,B>(next);
                    else
                        seek(dst, k++) = load<K,B>(trim ? text.trim(next) : next);
                    next = reader.ReadLine();
                }
            }
            return k;
        }

        [MethodImpl(Inline)]
        public static text<C> blocked<C>(in C src)
            where C : unmanaged, ICharBlock<C>
                => new text<C>(src);

        [MethodImpl(Inline), Op]
        public static text<CharBlock1> c16(N1 n, string src = EmptyString)
            => src;

        [MethodImpl(Inline), Op]
        public static text<CharBlock2> c16(N2 n, string src = EmptyString)
            => src;

        [MethodImpl(Inline), Op]
        public static text<CharBlock3> c16(N3 n, string src = EmptyString)
            => src;

        [MethodImpl(Inline), Op]
        public static text<CharBlock4> c16(N4 n, string src = EmptyString)
            => src;

        [MethodImpl(Inline), Op]
        public static text<CharBlock5> c16(N5 n, string src = EmptyString)
            => src;

        [MethodImpl(Inline), Op]
        public static text<CharBlock6> c16(N6 n, string src = EmptyString)
            => src;

        [MethodImpl(Inline), Op]
        public static text<CharBlock7> c16(N7 n, string src = EmptyString)
            => src;

        [MethodImpl(Inline), Op]
        public static text<CharBlock8> c16(N8 n, string src = EmptyString)
            => src;

        [MethodImpl(Inline), Op]
        public static text<CharBlock9> c16(N9 n, string src = EmptyString)
            => src;

        [MethodImpl(Inline), Op]
        public static text<CharBlock10> c16(N10 n, string src = EmptyString)
            => src;

        [MethodImpl(Inline), Op]
        public static text<CharBlock11> c16(N11 n, string src = EmptyString)
            => src;

        [MethodImpl(Inline), Op]
        public static text<CharBlock12> c16(N12 n, string src = EmptyString)
            => src;

        [MethodImpl(Inline), Op]
        public static text<CharBlock13> c16(N13 n, string src = EmptyString)
            => src;

        [MethodImpl(Inline), Op]
        public static text<CharBlock14> c16(N14 n, string src = EmptyString)
            => src;

        [MethodImpl(Inline), Op]
        public static text<CharBlock15> c16(N15 n, string src = EmptyString)
            => src;

        [MethodImpl(Inline), Op]
        public static text<CharBlock16> c16(N16 n, string src = EmptyString)
            => src;

        [MethodImpl(Inline), Op]
        public static text<CharBlock24> c16(N24 n, string src = EmptyString)
            => src;

        [MethodImpl(Inline), Op]
        public static text<CharBlock32> c16(N32 n, string src = EmptyString)
            => src;

        [MethodImpl(Inline), Op]
        public static text<CharBlock48> c16(N48 n, string src = EmptyString)
            => src;

        [MethodImpl(Inline), Op]
        public static text<CharBlock64> c16(N64 n, string src = EmptyString)
            => src;

        [MethodImpl(Inline), Op]
        public static text<CharBlock80> c16(N80 n, string src = EmptyString)
            => src;

        [MethodImpl(Inline), Op]
        public static text<CharBlock84> c16(N84 n, string src = EmptyString)
            => src;

        [MethodImpl(Inline), Op]
        public static text<CharBlock128> c16(N128 n, string src = EmptyString)
            => src;

        [MethodImpl(Inline), Op]
        public static text<CharBlock256> c16(N256 n, string src = EmptyString)
            => src;

        [MethodImpl(Inline), Op]
        public static text<CharBlock512> c16(N512 n, string src = EmptyString)
            => src;

    }
}