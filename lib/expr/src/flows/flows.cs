//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Flows
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct flows
    {
        const NumericKind Closure = UnsignedInts;

        /// <summary>
        /// Creates a <see cref='NativeFlow{S,T}'/> from a specified source to a specified target;
        /// </summary>
        /// <param name="src">The source</param>
        /// <param name="dst">The target</param>
        /// <typeparam name="S">The source type</typeparam>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline)]
        public static NativeFlow<S,T> flow<S,T>(in S src, in T dst)
            where S : INativeChannel
            where T : INativeChannel
                => new NativeFlow<S,T>(src,dst);

        [MethodImpl(Inline)]
        public static NativeFlow<K,S,T> flow<K,S,T>(K kind, in S src, in T dst)
            where K : unmanaged
            where S : INativeChannel
            where T : INativeChannel
                => new NativeFlow<K,S,T>(kind,src,dst);

        [MethodImpl(Inline), Op]
        public static NativeChannel channel(uint cells, uint width, ChannelMask mask = default)
            => new NativeChannel(cells, width, mask);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static NativeChannel<T> channel<T>(uint cells, ChannelMask mask = default)
            where T : unmanaged, ITypeWidth
                => new NativeChannel<T>(cells,mask);

        [MethodImpl(Inline)]
        public static NativeChannel<N,W> channel<N,W>(N n = default, W w = default)
            where W : unmanaged, ITypeWidth
            where N : unmanaged, ITypeNat
                => new NativeChannel<N,W>();

        [MethodImpl(Inline)]
        public static NativeChannel<N,W> channel<N,W>(ChannelMask mask, N n = default, W w = default)
            where W : unmanaged, ITypeWidth
            where N : unmanaged, ITypeNat
                => new NativeChannel<N,W>(mask);

        [MethodImpl(Inline), Op]
        public static MergeMask mmask(ulong value)
            => new MergeMask(value);

        [MethodImpl(Inline)]
        public static NativeFiber<T> fiber<T>(T channel, uint cell = 0, ushort offset = 0, byte width = 0)
            where T : unmanaged,INativeChannel
                => new NativeFiber<T>(channel,cell,offset,width);

        [MethodImpl(Inline), Op]
        public static NativeFiber fiber(NativeChannel channel, uint cell = 0, ushort offset = 0, byte width = 0)
            => new NativeFiber(channel,cell,offset,width);

        [MethodImpl(Inline), Op]
        public static ZeroMask zmask(ulong value)
            => new ZeroMask(value);

         public static string syntax<S,T>(NativeFlow<S,T> flow)
            where S : INativeChannel
            where T : INativeChannel
        {
            const string Pattern = "{0}:{1} -> {4}:{5}";
            return string.Format(Pattern, flow.Source, typeof(S).Name, flow.Target, typeof(T).Name);
        }

        public static string syntax<K,S,T>(NativeFlow<K,S,T> flow)
            where K : unmanaged
            where S : INativeChannel
            where T : INativeChannel
        {
            const string Pattern = "{0}:{1} |{2}:{3}> {4}:{5}";
            return string.Format(Pattern, flow.Source, typeof(S).Name, flow.Kind, typeof(K).Name, flow.Target, typeof(T).Name);
        }

        internal static string format(ZeroMask src)
            => string.Format("z{{0}}", src.Value.FormatBits());

        internal static string format(MergeMask src)
            => string.Format("k{{0}}", src.Value.FormatBits());

        internal static string format(ChannelMask src)
        {
            if(src.IsEmpty)
                return EmptyString;
            else
            {
                if(src.Kind == MaskKind.Zero)
                    return string.Format("z{{0}}", src.Value.FormatBits());
                else
                    return string.Format("k{{0}}", src.Value.FormatBits());
            }
        }

        internal static string format(NativeChannel src)
        {
            if(src.Mask.IsEmpty)
                return string.Format("{0}x{1}", src.CellCount, src.CellWidth);
            else
                return string.Format("{0}x{1} {2}", src.CellCount, src.CellWidth, format(src.Mask));
        }

        internal static string format<K,S,T>(in NativeFlow<K,S,T> flow)
            where K : unmanaged
            where S : INativeChannel
            where T : INativeChannel
                => string.Format("{0} |{1}> {2}", flow.Source, flow.Kind, flow.Target);

        internal static RenderPattern<S,T> RenderFlow<S,T>() => "{0} -> {1}";

        internal static RenderPattern<T,T> RenderFlow<T>() => RenderFlow<T,T>();

        internal static string format<S,T>(in NativeFlow<S,T> flow)
            where S : INativeChannel
            where T : INativeChannel
                => RenderFlow<S,T>().Format(flow.Source, flow.Target);


        [MethodImpl(Inline), Op]
        public static NativeChannel<N1,W8> channel(N1 n, W8 w)
            => flows.channel(n,w8);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N2,W8> channel(N2 n, W8 w)
            => flows.channel(n,w8);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N3,W8> channel(N3 n, W8 w)
            => flows.channel(n,w8);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N4,W8> channel(N4 n, W8 w)
            => flows.channel(n,w8);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N5,W8> channel(N5 n, W8 w)
            => flows.channel(n,w8);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N6,W8> channel(N6 n, W8 w)
            => flows.channel(n,w8);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N7,W8> channel(N7 n, W8 w)
            => flows.channel(n,w8);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N8,W8> channel(N8 n, W8 w)
            => flows.channel(n,w8);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N1,W16> channel(N1 n, W16 w)
            => flows.channel(n,w16);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N2,W16> channel(N2 n, W16 w)
            => flows.channel(n,w16);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N3,W16> channel(N3 n, W16 w)
            => flows.channel(n,w16);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N4,W16> channel(N4 n, W16 w)
            => flows.channel(n,w16);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N5,W16> channel(N5 n, W16 w)
            => flows.channel(n,w16);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N6,W16> channel(N6 n, W16 w)
            => flows.channel(n,w16);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N7,W16> channel(N7 n, W16 w)
            => flows.channel(n,w16);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N16,W8> channel(N16 n, W8 w)
            => flows.channel(n,w8);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N32,W8> channel(N32 n, W8 w)
            => flows.channel(n,w8);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N64,W8> channel(N64 n, W8 w)
            => flows.channel(n,w8);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N128,W8> channel(N128 n, W8 w)
            => flows.channel(n,w8);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N256,W8> channel(N256 n, W8 w)
            => flows.channel(n,w8);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N512,W8> channel(N512 n, W8 w)
            => flows.channel(n,w8);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N1024,W8> channel(N1024 n, W8 w)
            => flows.channel(n,w8);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N2048,W8> channel(N2048 n, W8 w)
            => flows.channel(n,w8);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N4096,W8> channel(N4096 n, W8 w)
            => flows.channel(n,w8);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N8,W16> channel(N8 n, W16 w)
            => flows.channel(n,w16);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N16,W16> channel(N16 n, W16 w)
            => flows.channel(n,w16);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N32,W16> channel(N32 n, W16 w)
            => flows.channel(n,w16);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N64,W16> channel(N64 n, W16 w)
            => flows.channel(n,w16);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N128,W16> channel(N128 n, W16 w)
            => flows.channel(n,w16);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N256,W16> channel(N256 n, W16 w)
            => flows.channel(n,w16);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N512,W16> channel(N512 n, W16 w)
            => flows.channel(n,w16);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N1024,W16> channel(N1024 n, W16 w)
            => flows.channel(n,w16);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N2048,W16> channel(N2048 n, W16 w)
            => flows.channel(n,w16);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N4096,W16> channel(N4096 n, W16 w)
            => flows.channel(n,w16);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N8,W32> channel(N8 n, W32 w)
            => flows.channel(n,w32);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N16,W32> channel(N16 n, W32 w)
            => flows.channel(n,w32);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N32,W32> channel(N32 n, W32 w)
            => flows.channel(n,w32);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N64,W32> channel(N64 n, W32 w)
            => flows.channel(n,w32);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N128,W32> channel(N128 n, W32 w)
            => flows.channel(n,w32);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N256,W32> channel(N256 n, W32 w)
            => flows.channel(n,w32);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N512,W32> channel(N512 n, W32 w)
            => flows.channel(n,w32);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N1024,W32> channel(N1024 n, W32 w)
            => flows.channel(n,w32);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N2048,W32> channel(N2048 n, W32 w)
            => flows.channel(n,w32);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N4096,W32> channel(N4096 n, W32 w)
            => flows.channel(n,w32);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N8,W64> channel(N8 n, W64 w)
            => flows.channel(n,w64);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N16,W64> channel(N16 n, W64 w)
            => flows.channel(n,w64);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N32,W64> channel(N32 n, W64 w)
            => flows.channel(n,w64);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N64,W64> channel(N64 n, W64 w)
            => flows.channel(n,w64);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N128,W64> channel(N128 n, W64 w)
            => flows.channel(n,w64);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N256,W64> channel(N256 n, W64 w)
            => flows.channel(n,w64);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N512,W64> channel(N512 n, W64 w)
            => flows.channel(n,w64);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N1024,W64> channel(N1024 n, W64 w)
            => flows.channel(n,w64);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N2048,W64> channel(N2048 n, W64 w)
            => flows.channel(n,w64);

        [MethodImpl(Inline), Op]
        public static NativeChannel<N4096,W64> channel(N4096 n, W64 w)
            => flows.channel(n,w64);
    }
}