namespace Z0.llvm.strings
{
    using System;

    using static core;

    public enum ProcessorKind : uint
    {
        anonymous_22683 = 0,
        anonymous_22684 = 1,
        anonymous_22685 = 2,
        anonymous_22686 = 3,
        anonymous_22687 = 4,
        anonymous_22688 = 5,
        anonymous_22689 = 6,
        anonymous_22690 = 7,
        anonymous_22691 = 8,
        anonymous_22692 = 9,
        anonymous_22693 = 10,
        anonymous_22694 = 11,
        anonymous_22695 = 12,
        anonymous_22696 = 13,
        anonymous_22697 = 14,
        anonymous_22698 = 15,
        anonymous_22699 = 16,
        anonymous_22700 = 17,
        anonymous_22701 = 18,
        anonymous_22702 = 19,
        anonymous_22703 = 20,
        anonymous_22704 = 21,
        anonymous_22705 = 22,
        anonymous_22706 = 23,
        anonymous_22707 = 24,
        anonymous_22708 = 25,
        anonymous_22709 = 26,
        anonymous_22710 = 27,
        anonymous_22711 = 28,
        anonymous_22712 = 29,
        anonymous_22713 = 30,
        anonymous_22714 = 31,
        anonymous_22715 = 32,
        anonymous_22716 = 33,
        anonymous_22717 = 34,
        anonymous_22718 = 35,
        anonymous_22719 = 36,
        anonymous_22720 = 37,
        anonymous_22721 = 38,
        anonymous_22722 = 39,
        anonymous_22723 = 40,
        anonymous_22724 = 41,
        anonymous_22725 = 42,
        anonymous_22726 = 43,
        anonymous_22727 = 44,
        anonymous_22728 = 45,
        anonymous_22729 = 46,
        anonymous_22730 = 47,
        anonymous_22731 = 48,
        anonymous_22732 = 49,
        anonymous_22733 = 50,
        anonymous_22734 = 51,
        anonymous_22735 = 52,
        anonymous_22736 = 53,
        anonymous_22737 = 54,
        anonymous_22738 = 55,
        anonymous_22739 = 56,
        anonymous_22740 = 57,
        anonymous_22741 = 58,
        anonymous_22742 = 59,
        anonymous_22743 = 60,
        anonymous_22744 = 61,
        anonymous_22745 = 62,
        anonymous_22746 = 63,
        anonymous_22747 = 64,
        anonymous_22748 = 65,
        anonymous_22749 = 66,
        anonymous_22750 = 67,
        anonymous_22751 = 68,
        anonymous_22752 = 69,
        anonymous_22753 = 70,
        anonymous_22754 = 71,
        anonymous_22755 = 72,
        anonymous_22756 = 73,
        anonymous_22757 = 74,
        anonymous_22758 = 75,
        anonymous_22759 = 76,
        anonymous_22760 = 77,
        anonymous_22761 = 78,
        anonymous_22762 = 79,
        anonymous_22763 = 80,
        anonymous_22764 = 81,
        anonymous_22765 = 82,
        anonymous_22766 = 83,
        anonymous_22767 = 84,
        anonymous_22768 = 85,
    }

    public readonly struct ProcessorST
    {
        public const uint EntryCount = 86;

        public const uint CharCount = 1290;

        public static MemoryAddress CharBase => address(Data);

        public static MemoryAddress OffsetBase => address(Offsets);

        public static MemoryStrings<ProcessorKind> Strings => MemoryStrings.create(Offsets,Data);

        public static ReadOnlySpan<byte> Offsets => new byte[344]{0x00,0x00,0x00,0x00,0x0f,0x00,0x00,0x00,0x1e,0x00,0x00,0x00,0x2d,0x00,0x00,0x00,0x3c,0x00,0x00,0x00,0x4b,0x00,0x00,0x00,0x5a,0x00,0x00,0x00,0x69,0x00,0x00,0x00,0x78,0x00,0x00,0x00,0x87,0x00,0x00,0x00,0x96,0x00,0x00,0x00,0xa5,0x00,0x00,0x00,0xb4,0x00,0x00,0x00,0xc3,0x00,0x00,0x00,0xd2,0x00,0x00,0x00,0xe1,0x00,0x00,0x00,0xf0,0x00,0x00,0x00,0xff,0x00,0x00,0x00,0x0e,0x01,0x00,0x00,0x1d,0x01,0x00,0x00,0x2c,0x01,0x00,0x00,0x3b,0x01,0x00,0x00,0x4a,0x01,0x00,0x00,0x59,0x01,0x00,0x00,0x68,0x01,0x00,0x00,0x77,0x01,0x00,0x00,0x86,0x01,0x00,0x00,0x95,0x01,0x00,0x00,0xa4,0x01,0x00,0x00,0xb3,0x01,0x00,0x00,0xc2,0x01,0x00,0x00,0xd1,0x01,0x00,0x00,0xe0,0x01,0x00,0x00,0xef,0x01,0x00,0x00,0xfe,0x01,0x00,0x00,0x0d,0x02,0x00,0x00,0x1c,0x02,0x00,0x00,0x2b,0x02,0x00,0x00,0x3a,0x02,0x00,0x00,0x49,0x02,0x00,0x00,0x58,0x02,0x00,0x00,0x67,0x02,0x00,0x00,0x76,0x02,0x00,0x00,0x85,0x02,0x00,0x00,0x94,0x02,0x00,0x00,0xa3,0x02,0x00,0x00,0xb2,0x02,0x00,0x00,0xc1,0x02,0x00,0x00,0xd0,0x02,0x00,0x00,0xdf,0x02,0x00,0x00,0xee,0x02,0x00,0x00,0xfd,0x02,0x00,0x00,0x0c,0x03,0x00,0x00,0x1b,0x03,0x00,0x00,0x2a,0x03,0x00,0x00,0x39,0x03,0x00,0x00,0x48,0x03,0x00,0x00,0x57,0x03,0x00,0x00,0x66,0x03,0x00,0x00,0x75,0x03,0x00,0x00,0x84,0x03,0x00,0x00,0x93,0x03,0x00,0x00,0xa2,0x03,0x00,0x00,0xb1,0x03,0x00,0x00,0xc0,0x03,0x00,0x00,0xcf,0x03,0x00,0x00,0xde,0x03,0x00,0x00,0xed,0x03,0x00,0x00,0xfc,0x03,0x00,0x00,0x0b,0x04,0x00,0x00,0x1a,0x04,0x00,0x00,0x29,0x04,0x00,0x00,0x38,0x04,0x00,0x00,0x47,0x04,0x00,0x00,0x56,0x04,0x00,0x00,0x65,0x04,0x00,0x00,0x74,0x04,0x00,0x00,0x83,0x04,0x00,0x00,0x92,0x04,0x00,0x00,0xa1,0x04,0x00,0x00,0xb0,0x04,0x00,0x00,0xbf,0x04,0x00,0x00,0xce,0x04,0x00,0x00,0xdd,0x04,0x00,0x00,0xec,0x04,0x00,0x00,0xfb,0x04,0x00,0x00};

        public static ReadOnlySpan<char> Data => new char[1290]{'a','n','o','n','y','m','o','u','s','_','2','2','6','8','3','a','n','o','n','y','m','o','u','s','_','2','2','6','8','4','a','n','o','n','y','m','o','u','s','_','2','2','6','8','5','a','n','o','n','y','m','o','u','s','_','2','2','6','8','6','a','n','o','n','y','m','o','u','s','_','2','2','6','8','7','a','n','o','n','y','m','o','u','s','_','2','2','6','8','8','a','n','o','n','y','m','o','u','s','_','2','2','6','8','9','a','n','o','n','y','m','o','u','s','_','2','2','6','9','0','a','n','o','n','y','m','o','u','s','_','2','2','6','9','1','a','n','o','n','y','m','o','u','s','_','2','2','6','9','2','a','n','o','n','y','m','o','u','s','_','2','2','6','9','3','a','n','o','n','y','m','o','u','s','_','2','2','6','9','4','a','n','o','n','y','m','o','u','s','_','2','2','6','9','5','a','n','o','n','y','m','o','u','s','_','2','2','6','9','6','a','n','o','n','y','m','o','u','s','_','2','2','6','9','7','a','n','o','n','y','m','o','u','s','_','2','2','6','9','8','a','n','o','n','y','m','o','u','s','_','2','2','6','9','9','a','n','o','n','y','m','o','u','s','_','2','2','7','0','0','a','n','o','n','y','m','o','u','s','_','2','2','7','0','1','a','n','o','n','y','m','o','u','s','_','2','2','7','0','2','a','n','o','n','y','m','o','u','s','_','2','2','7','0','3','a','n','o','n','y','m','o','u','s','_','2','2','7','0','4','a','n','o','n','y','m','o','u','s','_','2','2','7','0','5','a','n','o','n','y','m','o','u','s','_','2','2','7','0','6','a','n','o','n','y','m','o','u','s','_','2','2','7','0','7','a','n','o','n','y','m','o','u','s','_','2','2','7','0','8','a','n','o','n','y','m','o','u','s','_','2','2','7','0','9','a','n','o','n','y','m','o','u','s','_','2','2','7','1','0','a','n','o','n','y','m','o','u','s','_','2','2','7','1','1','a','n','o','n','y','m','o','u','s','_','2','2','7','1','2','a','n','o','n','y','m','o','u','s','_','2','2','7','1','3','a','n','o','n','y','m','o','u','s','_','2','2','7','1','4','a','n','o','n','y','m','o','u','s','_','2','2','7','1','5','a','n','o','n','y','m','o','u','s','_','2','2','7','1','6','a','n','o','n','y','m','o','u','s','_','2','2','7','1','7','a','n','o','n','y','m','o','u','s','_','2','2','7','1','8','a','n','o','n','y','m','o','u','s','_','2','2','7','1','9','a','n','o','n','y','m','o','u','s','_','2','2','7','2','0','a','n','o','n','y','m','o','u','s','_','2','2','7','2','1','a','n','o','n','y','m','o','u','s','_','2','2','7','2','2','a','n','o','n','y','m','o','u','s','_','2','2','7','2','3','a','n','o','n','y','m','o','u','s','_','2','2','7','2','4','a','n','o','n','y','m','o','u','s','_','2','2','7','2','5','a','n','o','n','y','m','o','u','s','_','2','2','7','2','6','a','n','o','n','y','m','o','u','s','_','2','2','7','2','7','a','n','o','n','y','m','o','u','s','_','2','2','7','2','8','a','n','o','n','y','m','o','u','s','_','2','2','7','2','9','a','n','o','n','y','m','o','u','s','_','2','2','7','3','0','a','n','o','n','y','m','o','u','s','_','2','2','7','3','1','a','n','o','n','y','m','o','u','s','_','2','2','7','3','2','a','n','o','n','y','m','o','u','s','_','2','2','7','3','3','a','n','o','n','y','m','o','u','s','_','2','2','7','3','4','a','n','o','n','y','m','o','u','s','_','2','2','7','3','5','a','n','o','n','y','m','o','u','s','_','2','2','7','3','6','a','n','o','n','y','m','o','u','s','_','2','2','7','3','7','a','n','o','n','y','m','o','u','s','_','2','2','7','3','8','a','n','o','n','y','m','o','u','s','_','2','2','7','3','9','a','n','o','n','y','m','o','u','s','_','2','2','7','4','0','a','n','o','n','y','m','o','u','s','_','2','2','7','4','1','a','n','o','n','y','m','o','u','s','_','2','2','7','4','2','a','n','o','n','y','m','o','u','s','_','2','2','7','4','3','a','n','o','n','y','m','o','u','s','_','2','2','7','4','4','a','n','o','n','y','m','o','u','s','_','2','2','7','4','5','a','n','o','n','y','m','o','u','s','_','2','2','7','4','6','a','n','o','n','y','m','o','u','s','_','2','2','7','4','7','a','n','o','n','y','m','o','u','s','_','2','2','7','4','8','a','n','o','n','y','m','o','u','s','_','2','2','7','4','9','a','n','o','n','y','m','o','u','s','_','2','2','7','5','0','a','n','o','n','y','m','o','u','s','_','2','2','7','5','1','a','n','o','n','y','m','o','u','s','_','2','2','7','5','2','a','n','o','n','y','m','o','u','s','_','2','2','7','5','3','a','n','o','n','y','m','o','u','s','_','2','2','7','5','4','a','n','o','n','y','m','o','u','s','_','2','2','7','5','5','a','n','o','n','y','m','o','u','s','_','2','2','7','5','6','a','n','o','n','y','m','o','u','s','_','2','2','7','5','7','a','n','o','n','y','m','o','u','s','_','2','2','7','5','8','a','n','o','n','y','m','o','u','s','_','2','2','7','5','9','a','n','o','n','y','m','o','u','s','_','2','2','7','6','0','a','n','o','n','y','m','o','u','s','_','2','2','7','6','1','a','n','o','n','y','m','o','u','s','_','2','2','7','6','2','a','n','o','n','y','m','o','u','s','_','2','2','7','6','3','a','n','o','n','y','m','o','u','s','_','2','2','7','6','4','a','n','o','n','y','m','o','u','s','_','2','2','7','6','5','a','n','o','n','y','m','o','u','s','_','2','2','7','6','6','a','n','o','n','y','m','o','u','s','_','2','2','7','6','7','a','n','o','n','y','m','o','u','s','_','2','2','7','6','8',};
    }
}
