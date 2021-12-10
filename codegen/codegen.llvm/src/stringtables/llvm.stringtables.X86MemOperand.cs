namespace Z0.llvm.stringtables
{
    using System;

    using static core;

    public enum X86MemOperandKind: uint
    {
        anymem=0,
        dstidx16=1,
        dstidx32=2,
        dstidx64=3,
        dstidx8=4,
        f128mem=5,
        f256mem=6,
        f32mem=7,
        f512mem=8,
        f64mem=9,
        f80mem=10,
        i128mem=11,
        i16mem=12,
        i256mem=13,
        i32mem=14,
        i512mem=15,
        i64mem=16,
        i8mem=17,
        offset16_16=18,
        offset16_32=19,
        offset16_8=20,
        offset32_16=21,
        offset32_32=22,
        offset32_64=23,
        offset32_8=24,
        offset64_16=25,
        offset64_32=26,
        offset64_64=27,
        offset64_8=28,
        opaquemem=29,
        sdmem=30,
        sibmem=31,
        srcidx16=32,
        srcidx32=33,
        srcidx64=34,
        srcidx8=35,
        ssmem=36,
        vx128mem=37,
        vx128xmem=38,
        vx256mem=39,
        vx256xmem=40,
        vx64mem=41,
        vx64xmem=42,
        vy128mem=43,
        vy128xmem=44,
        vy256mem=45,
        vy256xmem=46,
        vy512xmem=47,
        vz256mem=48,
        vz512mem=49,
    }

    public readonly struct X86MemOperand
    {
        public const uint EntryCount = 50;

        public const uint CharCount = 402;

        public static MemoryAddress CharBase => address(Data);

        public static MemoryAddress OffsetBase => address(Offsets);

        public static MemoryStrings Strings => strings.memory(Offsets,Data);

        public static ReadOnlySpan<byte> Offsets => new byte[200]{0x00,0x00,0x00,0x00,0x06,0x00,0x00,0x00,0x0e,0x00,0x00,0x00,0x16,0x00,0x00,0x00,0x1e,0x00,0x00,0x00,0x25,0x00,0x00,0x00,0x2c,0x00,0x00,0x00,0x33,0x00,0x00,0x00,0x39,0x00,0x00,0x00,0x40,0x00,0x00,0x00,0x46,0x00,0x00,0x00,0x4c,0x00,0x00,0x00,0x53,0x00,0x00,0x00,0x59,0x00,0x00,0x00,0x60,0x00,0x00,0x00,0x66,0x00,0x00,0x00,0x6d,0x00,0x00,0x00,0x73,0x00,0x00,0x00,0x78,0x00,0x00,0x00,0x83,0x00,0x00,0x00,0x8e,0x00,0x00,0x00,0x98,0x00,0x00,0x00,0xa3,0x00,0x00,0x00,0xae,0x00,0x00,0x00,0xb9,0x00,0x00,0x00,0xc3,0x00,0x00,0x00,0xce,0x00,0x00,0x00,0xd9,0x00,0x00,0x00,0xe4,0x00,0x00,0x00,0xee,0x00,0x00,0x00,0xf7,0x00,0x00,0x00,0xfc,0x00,0x00,0x00,0x02,0x01,0x00,0x00,0x0a,0x01,0x00,0x00,0x12,0x01,0x00,0x00,0x1a,0x01,0x00,0x00,0x21,0x01,0x00,0x00,0x26,0x01,0x00,0x00,0x2e,0x01,0x00,0x00,0x37,0x01,0x00,0x00,0x3f,0x01,0x00,0x00,0x48,0x01,0x00,0x00,0x4f,0x01,0x00,0x00,0x57,0x01,0x00,0x00,0x5f,0x01,0x00,0x00,0x68,0x01,0x00,0x00,0x70,0x01,0x00,0x00,0x79,0x01,0x00,0x00,0x82,0x01,0x00,0x00,0x8a,0x01,0x00,0x00};

        public static ReadOnlySpan<char> Data => new char[402]{'a','n','y','m','e','m','d','s','t','i','d','x','1','6','d','s','t','i','d','x','3','2','d','s','t','i','d','x','6','4','d','s','t','i','d','x','8','f','1','2','8','m','e','m','f','2','5','6','m','e','m','f','3','2','m','e','m','f','5','1','2','m','e','m','f','6','4','m','e','m','f','8','0','m','e','m','i','1','2','8','m','e','m','i','1','6','m','e','m','i','2','5','6','m','e','m','i','3','2','m','e','m','i','5','1','2','m','e','m','i','6','4','m','e','m','i','8','m','e','m','o','f','f','s','e','t','1','6','_','1','6','o','f','f','s','e','t','1','6','_','3','2','o','f','f','s','e','t','1','6','_','8','o','f','f','s','e','t','3','2','_','1','6','o','f','f','s','e','t','3','2','_','3','2','o','f','f','s','e','t','3','2','_','6','4','o','f','f','s','e','t','3','2','_','8','o','f','f','s','e','t','6','4','_','1','6','o','f','f','s','e','t','6','4','_','3','2','o','f','f','s','e','t','6','4','_','6','4','o','f','f','s','e','t','6','4','_','8','o','p','a','q','u','e','m','e','m','s','d','m','e','m','s','i','b','m','e','m','s','r','c','i','d','x','1','6','s','r','c','i','d','x','3','2','s','r','c','i','d','x','6','4','s','r','c','i','d','x','8','s','s','m','e','m','v','x','1','2','8','m','e','m','v','x','1','2','8','x','m','e','m','v','x','2','5','6','m','e','m','v','x','2','5','6','x','m','e','m','v','x','6','4','m','e','m','v','x','6','4','x','m','e','m','v','y','1','2','8','m','e','m','v','y','1','2','8','x','m','e','m','v','y','2','5','6','m','e','m','v','y','2','5','6','x','m','e','m','v','y','5','1','2','x','m','e','m','v','z','2','5','6','m','e','m','v','z','5','1','2','m','e','m',};
    }

}
