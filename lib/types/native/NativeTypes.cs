//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using SK = NativeSegKind;

    [ApiHost]
    public partial class NativeTypes
    {
        const NumericKind Closure = NumericKind.All;

        public readonly struct Seg16x8u : INativeSegKind<Seg16x8u,W16,byte>
        {

        }

        public readonly struct Seg16x8i : INativeSegKind<Seg16x8i,W16,sbyte>
        {


        }

        public readonly struct Seg16x16u : INativeSegKind<Seg16x16u,W16,ushort>
        {

        }

        public readonly struct Seg16x16i : INativeSegKind<Seg16x16i,W16,short>
        {

        }

        public readonly struct Seg32x8u : INativeSegKind<W32,byte>
        {

        }

        public readonly struct Seg32x8i : INativeSegKind<W32,sbyte>
        {

        }

        public readonly struct Seg32x16u : INativeSegKind<W32,ushort>
        {

        }

        public readonly struct Seg32x16i : INativeSegKind<W32,short>
        {

        }

        public readonly struct Seg32x32u : INativeSegKind<W32,uint>
        {

        }

        public readonly struct Seg32x32i : INativeSegKind<W32,int>
        {

        }

        public readonly struct Seg64x8u : INativeSegKind<W64,byte>
        {

        }

        public readonly struct Seg64x8i : INativeSegKind<W64,sbyte>
        {

        }

        public readonly struct Seg64x16u : INativeSegKind<W64,ushort>
        {

        }

        public readonly struct Seg64x16i : INativeSegKind<W64,short>
        {

        }

        public readonly struct Seg64x32u : INativeSegKind<W64,uint>
        {

        }

        public readonly struct Seg64x32i : INativeSegKind<W64,int>
        {

        }

        public readonly struct Seg64x64u : INativeSegKind<W64,ulong>
        {

        }

        public readonly struct Seg64x64i : INativeSegKind<W64,long>
        {

        }

        public readonly struct Seg128x8u : INativeSegKind<W128,byte>
        {

        }

        public readonly struct Seg128x8i : INativeSegKind<W128,sbyte>
        {

        }

        public readonly struct Seg128x16u : INativeSegKind<W128,ushort>
        {

        }

        public readonly struct Seg128x16i : INativeSegKind<W128,short>
        {

        }

        public readonly struct Seg128x32u : INativeSegKind<W128,uint>
        {

        }

        public readonly struct Seg128x32i : INativeSegKind<W128,int>
        {

        }

        public readonly struct Seg128x64u : INativeSegKind<W128,ulong>
        {

        }

        public readonly struct Seg128x64i : INativeSegKind<W128,long>
        {

        }

        public readonly struct Seg128x32f : INativeSegKind<W128,float>
        {

        }

        public readonly struct Seg128x64f : INativeSegKind<W128,double>
        {

        }

        public readonly struct Seg256x8u : INativeSegKind<W256,byte>
        {

        }

        public readonly struct Seg256x8i : INativeSegKind<W256,sbyte>
        {

        }

        public readonly struct Seg256x16u : INativeSegKind<W256,ushort>
        {

        }

        public readonly struct Seg256x16i : INativeSegKind<W256,short>
        {

        }

        public readonly struct Seg256x32u : INativeSegKind<W256,uint>
        {

        }

        public readonly struct Seg256x32i : INativeSegKind<W256,int>
        {

        }

        public readonly struct Seg256x64u : INativeSegKind<W256,ulong>
        {

        }

        public readonly struct Seg256x64i : INativeSegKind<W256,long>
        {

        }

        public readonly struct Seg256x32f : INativeSegKind<W256,float>
        {

        }

        public readonly struct Seg256x64f : INativeSegKind<W256,double>
        {

        }

        public readonly struct Seg512x8u : INativeSegKind<W512,byte>
        {

        }

        public readonly struct Seg512x8i : INativeSegKind<W512,sbyte>
        {

        }

        public readonly struct Seg512x16u : INativeSegKind<W512,ushort>
        {

        }

        public readonly struct Seg512x16i : INativeSegKind<W512,short>
        {

        }

        public readonly struct Seg512x32u : INativeSegKind<W512,uint>
        {

        }

        public readonly struct Seg512x32i : INativeSegKind<W512,int>
        {

        }

        public readonly struct Seg512x64u : INativeSegKind<W512,ulong>
        {

        }

        public readonly struct Seg512x64i : INativeSegKind<W512,long>
        {

        }

        public readonly struct Seg512x32f : INativeSegKind<W512,float>
        {

        }

        public readonly struct Seg512x64f : INativeSegKind<W512,double>
        {

        }

        public readonly struct Seg8u : INativeSegKind<Seg8u>
        {
            public SK Class => SK.Seg8u;


            public static implicit operator SK(Seg8u src)
                => src.Class;
        }

        public readonly struct Seg16u : INativeSegKind<Seg16u>
        {
            public SK Class => SK.Seg16u;

            public static implicit operator SK(Seg16u src)
                => src.Class;
        }

        public readonly struct Seg32u : INativeSegKind<Seg32u>
        {
            public SK Class => SK.Seg32u;

            public static implicit operator NativeSegKind(Seg32u src)
                => src.Class;
        }

        public readonly struct Seg64u : INativeSegKind<Seg64u>
        {
            public SK Class => SK.Seg64u;

            public static implicit operator SK(Seg64u src)
                => src.Class;
        }

        public readonly struct Seg128 : INativeSegKind<Seg128>
        {
            public SK Class => SK.Seg128u;

            public static implicit operator SK(Seg128 src)
                => src.Class;
        }

        public readonly struct Seg256 : INativeSegKind<Seg256>
        {
            public SK Class => SK.Seg256u;

            public static implicit operator SK(Seg256 src)
                => src.Class;
        }

        public readonly struct Seg512 : INativeSegKind<Seg512>
        {
            public SK Class => SK.Seg512u;

            public static implicit operator SK(Seg512 src)
                => src.Class;
        }
    }
}