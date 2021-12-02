//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using SK = NativeSegKind;

    [ApiHost]
    public partial class NativeSegKinds
    {
        const NumericKind Closure = NumericKind.All;

        public readonly struct Seg16x8u : ISegmetedKind<Seg16x8u,W16,byte>
        {

        }

        public readonly struct Seg16x8i : ISegmetedKind<Seg16x8i,W16,sbyte>
        {


        }

        public readonly struct Seg16x16u : ISegmetedKind<Seg16x16u,W16,ushort>
        {

        }

        public readonly struct Seg16x16i : ISegmetedKind<Seg16x16i,W16,short>
        {

        }

        public readonly struct Seg32x8u : ISegmentedKind<W32,byte>
        {

        }

        public readonly struct Seg32x8i : ISegmentedKind<W32,sbyte>
        {

        }

        public readonly struct Seg32x16u : ISegmentedKind<W32,ushort>
        {

        }

        public readonly struct Seg32x16i : ISegmentedKind<W32,short>
        {

        }

        public readonly struct Seg32x32u : ISegmentedKind<W32,uint>
        {

        }

        public readonly struct Seg32x32i : ISegmentedKind<W32,int>
        {

        }

        public readonly struct Seg64x8u : ISegmentedKind<W64,byte>
        {

        }

        public readonly struct Seg64x8i : ISegmentedKind<W64,sbyte>
        {

        }

        public readonly struct Seg64x16u : ISegmentedKind<W64,ushort>
        {

        }

        public readonly struct Seg64x16i : ISegmentedKind<W64,short>
        {

        }

        public readonly struct Seg64x32u : ISegmentedKind<W64,uint>
        {

        }

        public readonly struct Seg64x32i : ISegmentedKind<W64,int>
        {

        }

        public readonly struct Seg64x64u : ISegmentedKind<W64,ulong>
        {

        }

        public readonly struct Seg64x64i : ISegmentedKind<W64,long>
        {

        }

        public readonly struct Seg128x8u : ISegmentedKind<W128,byte>
        {

        }

        public readonly struct Seg128x8i : ISegmentedKind<W128,sbyte>
        {

        }

        public readonly struct Seg128x16u : ISegmentedKind<W128,ushort>
        {

        }

        public readonly struct Seg128x16i : ISegmentedKind<W128,short>
        {

        }

        public readonly struct Seg128x32u : ISegmentedKind<W128,uint>
        {

        }

        public readonly struct Seg128x32i : ISegmentedKind<W128,int>
        {

        }

        public readonly struct Seg128x64u : ISegmentedKind<W128,ulong>
        {

        }

        public readonly struct Seg128x64i : ISegmentedKind<W128,long>
        {

        }

        public readonly struct Seg128x32f : ISegmentedKind<W128,float>
        {

        }

        public readonly struct Seg128x64f : ISegmentedKind<W128,double>
        {

        }

        public readonly struct Seg256x8u : ISegmentedKind<W256,byte>
        {

        }

        public readonly struct Seg256x8i : ISegmentedKind<W256,sbyte>
        {

        }

        public readonly struct Seg256x16u : ISegmentedKind<W256,ushort>
        {

        }

        public readonly struct Seg256x16i : ISegmentedKind<W256,short>
        {

        }

        public readonly struct Seg256x32u : ISegmentedKind<W256,uint>
        {

        }

        public readonly struct Seg256x32i : ISegmentedKind<W256,int>
        {

        }

        public readonly struct Seg256x64u : ISegmentedKind<W256,ulong>
        {

        }

        public readonly struct Seg256x64i : ISegmentedKind<W256,long>
        {

        }

        public readonly struct Seg256x32f : ISegmentedKind<W256,float>
        {

        }

        public readonly struct Seg256x64f : ISegmentedKind<W256,double>
        {

        }

        public readonly struct Seg512x8u : ISegmentedKind<W512,byte>
        {

        }

        public readonly struct Seg512x8i : ISegmentedKind<W512,sbyte>
        {

        }

        public readonly struct Seg512x16u : ISegmentedKind<W512,ushort>
        {

        }

        public readonly struct Seg512x16i : ISegmentedKind<W512,short>
        {

        }

        /// <summary>
        /// Characterizes <see cref='W512'/> types that are semented over the <see cref='uint'/> domain
        /// </summary>
        public readonly struct Seg512x32u : ISegmentedKind<W512,uint>
        {

        }

        /// <summary>
        /// Characterizes <see cref='W512'/> types that are semented over the <see cref='int'/> domain
        /// </summary>
        public readonly struct Seg512x32i : ISegmentedKind<W512,int>
        {

        }

        public readonly struct Seg512x64u : ISegmentedKind<W512,ulong>
        {

        }

        public readonly struct Seg512x64i : ISegmentedKind<W512,long>
        {

        }

        public readonly struct Seg512x32f : ISegmentedKind<W512,float>
        {

        }

        public readonly struct Seg512x64f : ISegmentedKind<W512,double>
        {

        }

        public readonly struct Seg8 : ISegmentedKind<Seg8>
        {
            public SK Class => SK.Seg8;

            public NativeTypeWidth SegWidth => NativeTypeWidth.W8;

            public static implicit operator SK(Seg8 src)
                => src.Class;
        }

        public readonly struct Seg16 : ISegmentedKind<Seg16>
        {
            public SK Class => SK.Seg16;

            public NativeTypeWidth SegWidth => NativeTypeWidth.W16;

            public static implicit operator SK(Seg16 src)
                => src.Class;
        }

        public readonly struct Seg32 : ISegmentedKind<Seg32>
        {
            public SK Class => SK.Seg32;

            public NativeTypeWidth SegWidth => NativeTypeWidth.W32;

            public static implicit operator NativeSegKind(Seg32 src)
                => src.Class;
        }

        public readonly struct Seg64 : ISegmentedKind<Seg64>
        {
            public SK Class => SK.Seg64;

            public NativeTypeWidth SegWidth => NativeTypeWidth.W64;

            public static implicit operator SK(Seg64 src)
                => src.Class;
        }

        public readonly struct Seg128 : ISegmentedKind<Seg128>
        {
            public SK Class => SK.Seg128;

            public NativeTypeWidth SegWidth => NativeTypeWidth.W128;

            public static implicit operator SK(Seg128 src)
                => src.Class;
        }

        public readonly struct Seg256 : ISegmentedKind<Seg256>
        {
            public SK Class => SK.Seg256;

            public NativeTypeWidth SegWidth => NativeTypeWidth.W256;

            public static implicit operator SK(Seg256 src)
                => src.Class;
        }

        public readonly struct Seg512 : ISegmentedKind<Seg512>
        {
            public SK Class => SK.Seg512;

            public NativeTypeWidth SegWidth => NativeTypeWidth.W512;

            public static implicit operator SK(Seg512 src)
                => src.Class;
        }
    }
}