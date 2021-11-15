//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using CC = RegClassCode;

    public readonly struct RegClasses
    {
        public static GpClass Gp => default;

        public static SegClass Seg => default;

        public static FlagClass Flag => default;

        public static MaskClass KReg => default;

        public static CrClass Cr => default;

        public static XCrClass XCr => default;

        public static DbClass Db => default;

        public static XmmClass Xmm => default;

        public static YmmClass Ymm => default;

        public static ZmmClass Zmm => default;

        public static IPtrClass IP => default;

        public static SPtrClass SP => default;

        public static BndClass Bnd => default;

        public static StClass St => default;

        public readonly struct GpClass : IRegClass<GpClass>
        {
            public CC Kind => CC.GP;

            public static implicit operator CC(GpClass src)
                => src.Kind;
        }

        public readonly struct SegClass : IRegClass<SegClass>
        {
            public CC Kind => CC.SEG;

            public static implicit operator CC(SegClass src)
                => src.Kind;
        }

        public readonly struct FlagClass : IRegClass<FlagClass>
        {
            public CC Kind => CC.FLAG;

            public static implicit operator CC(FlagClass src)
                => src.Kind;
        }

        public readonly struct CrClass : IRegClass<CrClass>
        {
            public CC Kind => CC.CR;

            public static implicit operator CC(CrClass src)
                => src.Kind;
        }

        public readonly struct DbClass : IRegClass<DbClass>
        {
            public CC Kind => CC.DB;

            public static implicit operator CC(DbClass src)
                => src.Kind;
        }

        public readonly struct IPtrClass : IRegClass<IPtrClass>
        {
            public CC Kind => CC.IPTR;

            public static implicit operator CC(IPtrClass src)
                => src.Kind;
        }

        public readonly struct SPtrClass : IRegClass<SPtrClass>
        {
            public CC Kind => CC.SPTR;

            public static implicit operator CC(SPtrClass src)
                => src.Kind;
        }

        public readonly struct XmmClass : IRegClass<XmmClass>
        {
            public CC Kind => CC.XMM;


            public static implicit operator CC(XmmClass src)
                => src.Kind;

        }

        public readonly struct YmmClass : IRegClass<YmmClass>
        {
            public CC Kind => CC.YMM;

            public static implicit operator CC(YmmClass src)
                => src.Kind;
        }

        public readonly struct ZmmClass : IRegClass<ZmmClass>
        {
            public CC Kind => CC.ZMM;

            public static implicit operator CC(ZmmClass src)
                => src.Kind;
        }

        public readonly struct MaskClass : IRegClass<MaskClass>
        {
            public CC Kind => CC.MASK;

            public static implicit operator CC(MaskClass src)
                => src.Kind;
        }

        public readonly struct BndClass : IRegClass<BndClass>
        {
            public CC Kind => CC.BND;

            public static implicit operator CC(BndClass src)
                => src.Kind;
        }

        public readonly struct StClass : IRegClass<StClass>
        {
            public CC Kind => CC.ST;

            public static implicit operator CC(StClass src)
                => src.Kind;
        }

        public readonly struct MmxClass : IRegClass<MmxClass>
        {
            public CC Kind => CC.MMX;

            public static implicit operator CC(MmxClass src)
                => src.Kind;
        }

        public readonly struct XCrClass : IRegClass<XCrClass>
        {
            public CC Kind => CC.XCR;

            public static implicit operator CC(XCrClass src)
                => src.Kind;
        }
    }
}