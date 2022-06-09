namespace Z0.llvm.strings
{
    using System;

    using static core;

    public enum MCInstPredicateKind : uint
    {
        CheckLockPrefix = 0,
        IsAtomicCompareAndSwap = 1,
        IsAtomicCompareAndSwap16B = 2,
        IsAtomicCompareAndSwap8B = 3,
        IsAtomicCompareAndSwap_8 = 4,
        IsCMOVArm_Or_CMOVBErm = 5,
        IsCMOVArr_Or_CMOVBErr = 6,
        IsCompareAndSwap16B = 7,
        IsCompareAndSwap8B = 8,
        IsRegMemCompareAndSwap = 9,
        IsRegMemCompareAndSwap_16_32_64 = 10,
        IsRegMemCompareAndSwap_8 = 11,
        IsRegRegCompareAndSwap = 12,
        IsRegRegCompareAndSwap_16_32_64 = 13,
        IsRegRegCompareAndSwap_8 = 14,
        IsSETAm_Or_SETBEm = 15,
        IsSETAr_Or_SETBEr = 16,
        IsThreeOperandsLEAFn = 17,
        IsThreeOperandsLEAPredicate = 18,
        ZeroIdiomPredicate = 19,
        ZeroIdiomVPERMPredicate = 20,
        anonymous_12572 = 21,
        anonymous_12573 = 22,
        anonymous_12574 = 23,
        anonymous_12575 = 24,
        anonymous_12576 = 25,
        anonymous_12577 = 26,
        anonymous_12578 = 27,
        anonymous_12579 = 28,
        anonymous_16175 = 29,
        anonymous_16176 = 30,
        anonymous_16177 = 31,
        anonymous_16178 = 32,
        anonymous_16179 = 33,
        anonymous_17056 = 34,
        anonymous_17205 = 35,
        anonymous_17208 = 36,
        anonymous_17211 = 37,
        anonymous_17214 = 38,
        anonymous_17222 = 39,
        anonymous_17225 = 40,
        anonymous_17228 = 41,
        anonymous_17231 = 42,
        anonymous_9795 = 43,
        anonymous_9796 = 44,
        anonymous_9797 = 45,
        anonymous_9798 = 46,
        anonymous_9799 = 47,
        anonymous_9800 = 48,
        anonymous_9801 = 49,
        anonymous_9802 = 50,
        anonymous_9803 = 51,
        anonymous_9804 = 52,
        anonymous_9805 = 53,
        anonymous_9806 = 54,
        anonymous_9807 = 55,
        anonymous_9810 = 56,
        anonymous_9811 = 57,
        anonymous_9812 = 58,
        anonymous_9813 = 59,
        anonymous_9814 = 60,
        anonymous_9815 = 61,
        anonymous_9816 = 62,
        anonymous_9817 = 63,
    }

    public readonly struct MCInstPredicateST
    {
        public const uint EntryCount = 64;

        public const uint CharCount = 1089;

        public static MemoryAddress CharBase => address(Data);

        public static MemoryAddress OffsetBase => address(Offsets);

        public static MemoryStrings<MCInstPredicateKind> Strings => MemoryStrings.create(Offsets,Data);

        public static ReadOnlySpan<byte> Offsets => new byte[256]{0x00,0x00,0x00,0x00,0x0f,0x00,0x00,0x00,0x25,0x00,0x00,0x00,0x3e,0x00,0x00,0x00,0x56,0x00,0x00,0x00,0x6e,0x00,0x00,0x00,0x83,0x00,0x00,0x00,0x98,0x00,0x00,0x00,0xab,0x00,0x00,0x00,0xbd,0x00,0x00,0x00,0xd3,0x00,0x00,0x00,0xf2,0x00,0x00,0x00,0x0a,0x01,0x00,0x00,0x20,0x01,0x00,0x00,0x3f,0x01,0x00,0x00,0x57,0x01,0x00,0x00,0x68,0x01,0x00,0x00,0x79,0x01,0x00,0x00,0x8d,0x01,0x00,0x00,0xa8,0x01,0x00,0x00,0xba,0x01,0x00,0x00,0xd1,0x01,0x00,0x00,0xe0,0x01,0x00,0x00,0xef,0x01,0x00,0x00,0xfe,0x01,0x00,0x00,0x0d,0x02,0x00,0x00,0x1c,0x02,0x00,0x00,0x2b,0x02,0x00,0x00,0x3a,0x02,0x00,0x00,0x49,0x02,0x00,0x00,0x58,0x02,0x00,0x00,0x67,0x02,0x00,0x00,0x76,0x02,0x00,0x00,0x85,0x02,0x00,0x00,0x94,0x02,0x00,0x00,0xa3,0x02,0x00,0x00,0xb2,0x02,0x00,0x00,0xc1,0x02,0x00,0x00,0xd0,0x02,0x00,0x00,0xdf,0x02,0x00,0x00,0xee,0x02,0x00,0x00,0xfd,0x02,0x00,0x00,0x0c,0x03,0x00,0x00,0x1b,0x03,0x00,0x00,0x29,0x03,0x00,0x00,0x37,0x03,0x00,0x00,0x45,0x03,0x00,0x00,0x53,0x03,0x00,0x00,0x61,0x03,0x00,0x00,0x6f,0x03,0x00,0x00,0x7d,0x03,0x00,0x00,0x8b,0x03,0x00,0x00,0x99,0x03,0x00,0x00,0xa7,0x03,0x00,0x00,0xb5,0x03,0x00,0x00,0xc3,0x03,0x00,0x00,0xd1,0x03,0x00,0x00,0xdf,0x03,0x00,0x00,0xed,0x03,0x00,0x00,0xfb,0x03,0x00,0x00,0x09,0x04,0x00,0x00,0x17,0x04,0x00,0x00,0x25,0x04,0x00,0x00,0x33,0x04,0x00,0x00};

        public static ReadOnlySpan<char> Data => new char[1089]{'C','h','e','c','k','L','o','c','k','P','r','e','f','i','x','I','s','A','t','o','m','i','c','C','o','m','p','a','r','e','A','n','d','S','w','a','p','I','s','A','t','o','m','i','c','C','o','m','p','a','r','e','A','n','d','S','w','a','p','1','6','B','I','s','A','t','o','m','i','c','C','o','m','p','a','r','e','A','n','d','S','w','a','p','8','B','I','s','A','t','o','m','i','c','C','o','m','p','a','r','e','A','n','d','S','w','a','p','_','8','I','s','C','M','O','V','A','r','m','_','O','r','_','C','M','O','V','B','E','r','m','I','s','C','M','O','V','A','r','r','_','O','r','_','C','M','O','V','B','E','r','r','I','s','C','o','m','p','a','r','e','A','n','d','S','w','a','p','1','6','B','I','s','C','o','m','p','a','r','e','A','n','d','S','w','a','p','8','B','I','s','R','e','g','M','e','m','C','o','m','p','a','r','e','A','n','d','S','w','a','p','I','s','R','e','g','M','e','m','C','o','m','p','a','r','e','A','n','d','S','w','a','p','_','1','6','_','3','2','_','6','4','I','s','R','e','g','M','e','m','C','o','m','p','a','r','e','A','n','d','S','w','a','p','_','8','I','s','R','e','g','R','e','g','C','o','m','p','a','r','e','A','n','d','S','w','a','p','I','s','R','e','g','R','e','g','C','o','m','p','a','r','e','A','n','d','S','w','a','p','_','1','6','_','3','2','_','6','4','I','s','R','e','g','R','e','g','C','o','m','p','a','r','e','A','n','d','S','w','a','p','_','8','I','s','S','E','T','A','m','_','O','r','_','S','E','T','B','E','m','I','s','S','E','T','A','r','_','O','r','_','S','E','T','B','E','r','I','s','T','h','r','e','e','O','p','e','r','a','n','d','s','L','E','A','F','n','I','s','T','h','r','e','e','O','p','e','r','a','n','d','s','L','E','A','P','r','e','d','i','c','a','t','e','Z','e','r','o','I','d','i','o','m','P','r','e','d','i','c','a','t','e','Z','e','r','o','I','d','i','o','m','V','P','E','R','M','P','r','e','d','i','c','a','t','e','a','n','o','n','y','m','o','u','s','_','1','2','5','7','2','a','n','o','n','y','m','o','u','s','_','1','2','5','7','3','a','n','o','n','y','m','o','u','s','_','1','2','5','7','4','a','n','o','n','y','m','o','u','s','_','1','2','5','7','5','a','n','o','n','y','m','o','u','s','_','1','2','5','7','6','a','n','o','n','y','m','o','u','s','_','1','2','5','7','7','a','n','o','n','y','m','o','u','s','_','1','2','5','7','8','a','n','o','n','y','m','o','u','s','_','1','2','5','7','9','a','n','o','n','y','m','o','u','s','_','1','6','1','7','5','a','n','o','n','y','m','o','u','s','_','1','6','1','7','6','a','n','o','n','y','m','o','u','s','_','1','6','1','7','7','a','n','o','n','y','m','o','u','s','_','1','6','1','7','8','a','n','o','n','y','m','o','u','s','_','1','6','1','7','9','a','n','o','n','y','m','o','u','s','_','1','7','0','5','6','a','n','o','n','y','m','o','u','s','_','1','7','2','0','5','a','n','o','n','y','m','o','u','s','_','1','7','2','0','8','a','n','o','n','y','m','o','u','s','_','1','7','2','1','1','a','n','o','n','y','m','o','u','s','_','1','7','2','1','4','a','n','o','n','y','m','o','u','s','_','1','7','2','2','2','a','n','o','n','y','m','o','u','s','_','1','7','2','2','5','a','n','o','n','y','m','o','u','s','_','1','7','2','2','8','a','n','o','n','y','m','o','u','s','_','1','7','2','3','1','a','n','o','n','y','m','o','u','s','_','9','7','9','5','a','n','o','n','y','m','o','u','s','_','9','7','9','6','a','n','o','n','y','m','o','u','s','_','9','7','9','7','a','n','o','n','y','m','o','u','s','_','9','7','9','8','a','n','o','n','y','m','o','u','s','_','9','7','9','9','a','n','o','n','y','m','o','u','s','_','9','8','0','0','a','n','o','n','y','m','o','u','s','_','9','8','0','1','a','n','o','n','y','m','o','u','s','_','9','8','0','2','a','n','o','n','y','m','o','u','s','_','9','8','0','3','a','n','o','n','y','m','o','u','s','_','9','8','0','4','a','n','o','n','y','m','o','u','s','_','9','8','0','5','a','n','o','n','y','m','o','u','s','_','9','8','0','6','a','n','o','n','y','m','o','u','s','_','9','8','0','7','a','n','o','n','y','m','o','u','s','_','9','8','1','0','a','n','o','n','y','m','o','u','s','_','9','8','1','1','a','n','o','n','y','m','o','u','s','_','9','8','1','2','a','n','o','n','y','m','o','u','s','_','9','8','1','3','a','n','o','n','y','m','o','u','s','_','9','8','1','4','a','n','o','n','y','m','o','u','s','_','9','8','1','5','a','n','o','n','y','m','o','u','s','_','9','8','1','6','a','n','o','n','y','m','o','u','s','_','9','8','1','7',};
    }
}
