//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Root;

    [ApiHost]
    public readonly partial struct Seq
    {
        const NumericKind Closure = UInt64k;

        [MethodImpl(Inline)]
        public unsafe static void read<T>(Span<T> src, Action<T> dst)
            where T : unmanaged
                => memory.read(src,dst);

        [MethodImpl(Inline)]
        public static unsafe SeqEditor<T> editor<T>(T* pSrc, long count)
            where T : unmanaged
                => memory.editor(pSrc,count);

        [MethodImpl(Inline)]
        public static unsafe SeqEditor<T> editor<T>(NativeBuffer<T> src)
            where T : unmanaged
                => memory.editor(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe SeqReader<T> reader<T>(T* pSrc, long count)
            where T : unmanaged
                => memory.reader(pSrc,count);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe SeqReader<T> reader<T>(NativeBuffer<T> src)
            where T : unmanaged
                => memory.reader(src);

        [MethodImpl(Inline)]
        public static SeqReader<A0,A1> reader<A0,A1>(SeqReader<A0> r0, SeqReader<A1> r1)
            where A0 : unmanaged
            where A1 : unmanaged
                => memory.reader(r0,r1);
    }
}