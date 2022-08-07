namespace Z0.llvm.strings
{
    using System;

    using static core;

    public enum SDTypeConstraintKind : uint
    {
        anonymous_3711 = 0,
        anonymous_3712 = 1,
        anonymous_3713 = 2,
        anonymous_3714 = 3,
        anonymous_3715 = 4,
        anonymous_3716 = 5,
        anonymous_3717 = 6,
        anonymous_3718 = 7,
        anonymous_3719 = 8,
        anonymous_3720 = 9,
        anonymous_3721 = 10,
        anonymous_3722 = 11,
        anonymous_3723 = 12,
        anonymous_3724 = 13,
        anonymous_3725 = 14,
        anonymous_3726 = 15,
        anonymous_3727 = 16,
        anonymous_3728 = 17,
        anonymous_3729 = 18,
        anonymous_3730 = 19,
        anonymous_3731 = 20,
        anonymous_3732 = 21,
        anonymous_3733 = 22,
        anonymous_3734 = 23,
        anonymous_3735 = 24,
        anonymous_3736 = 25,
        anonymous_3737 = 26,
        anonymous_3738 = 27,
        anonymous_3739 = 28,
        anonymous_3740 = 29,
        anonymous_3741 = 30,
        anonymous_3742 = 31,
        anonymous_3743 = 32,
        anonymous_3744 = 33,
        anonymous_3745 = 34,
        anonymous_3746 = 35,
        anonymous_3752 = 36,
        anonymous_3757 = 37,
        anonymous_3889 = 38,
        anonymous_3890 = 39,
        anonymous_3891 = 40,
        anonymous_3892 = 41,
        anonymous_3893 = 42,
        anonymous_3894 = 43,
        anonymous_3895 = 44,
        anonymous_3896 = 45,
        anonymous_3897 = 46,
        anonymous_3898 = 47,
        anonymous_3899 = 48,
        anonymous_3900 = 49,
        anonymous_3901 = 50,
        anonymous_3906 = 51,
        anonymous_4372 = 52,
        anonymous_4374 = 53,
        anonymous_4376 = 54,
        anonymous_4378 = 55,
        anonymous_4379 = 56,
        anonymous_4380 = 57,
        anonymous_4382 = 58,
        anonymous_4386 = 59,
        anonymous_4388 = 60,
        anonymous_4390 = 61,
        anonymous_4392 = 62,
        anonymous_4394 = 63,
        anonymous_4395 = 64,
        anonymous_4398 = 65,
        anonymous_4399 = 66,
        anonymous_4402 = 67,
        anonymous_4403 = 68,
        anonymous_4407 = 69,
        anonymous_4408 = 70,
        anonymous_4409 = 71,
        anonymous_4413 = 72,
        anonymous_4414 = 73,
        anonymous_4418 = 74,
        anonymous_4423 = 75,
        anonymous_4426 = 76,
        anonymous_4427 = 77,
        anonymous_4428 = 78,
        anonymous_4430 = 79,
        anonymous_4432 = 80,
        anonymous_4433 = 81,
        anonymous_4434 = 82,
        anonymous_4437 = 83,
        anonymous_4438 = 84,
        anonymous_4443 = 85,
        anonymous_4446 = 86,
        anonymous_4450 = 87,
        anonymous_4451 = 88,
        anonymous_4452 = 89,
        anonymous_4453 = 90,
        anonymous_4460 = 91,
        anonymous_6226 = 92,
        anonymous_9303 = 93,
    }

    [ApiCompleteAttribute]
    public readonly struct SDTypeConstraintST
    {
        public const uint EntryCount = 94;

        public const uint CharCount = 1316;

        public static MemoryAddress CharBase => address(Data);

        public static MemoryAddress OffsetBase => address(Offsets);

        public static MemoryStrings<SDTypeConstraintKind> Strings => MemoryStrings.create(Offsets,Data);

        public static ReadOnlySpan<byte> Offsets => new byte[376]{0x00,0x00,0x00,0x00,0x0e,0x00,0x00,0x00,0x1c,0x00,0x00,0x00,0x2a,0x00,0x00,0x00,0x38,0x00,0x00,0x00,0x46,0x00,0x00,0x00,0x54,0x00,0x00,0x00,0x62,0x00,0x00,0x00,0x70,0x00,0x00,0x00,0x7e,0x00,0x00,0x00,0x8c,0x00,0x00,0x00,0x9a,0x00,0x00,0x00,0xa8,0x00,0x00,0x00,0xb6,0x00,0x00,0x00,0xc4,0x00,0x00,0x00,0xd2,0x00,0x00,0x00,0xe0,0x00,0x00,0x00,0xee,0x00,0x00,0x00,0xfc,0x00,0x00,0x00,0x0a,0x01,0x00,0x00,0x18,0x01,0x00,0x00,0x26,0x01,0x00,0x00,0x34,0x01,0x00,0x00,0x42,0x01,0x00,0x00,0x50,0x01,0x00,0x00,0x5e,0x01,0x00,0x00,0x6c,0x01,0x00,0x00,0x7a,0x01,0x00,0x00,0x88,0x01,0x00,0x00,0x96,0x01,0x00,0x00,0xa4,0x01,0x00,0x00,0xb2,0x01,0x00,0x00,0xc0,0x01,0x00,0x00,0xce,0x01,0x00,0x00,0xdc,0x01,0x00,0x00,0xea,0x01,0x00,0x00,0xf8,0x01,0x00,0x00,0x06,0x02,0x00,0x00,0x14,0x02,0x00,0x00,0x22,0x02,0x00,0x00,0x30,0x02,0x00,0x00,0x3e,0x02,0x00,0x00,0x4c,0x02,0x00,0x00,0x5a,0x02,0x00,0x00,0x68,0x02,0x00,0x00,0x76,0x02,0x00,0x00,0x84,0x02,0x00,0x00,0x92,0x02,0x00,0x00,0xa0,0x02,0x00,0x00,0xae,0x02,0x00,0x00,0xbc,0x02,0x00,0x00,0xca,0x02,0x00,0x00,0xd8,0x02,0x00,0x00,0xe6,0x02,0x00,0x00,0xf4,0x02,0x00,0x00,0x02,0x03,0x00,0x00,0x10,0x03,0x00,0x00,0x1e,0x03,0x00,0x00,0x2c,0x03,0x00,0x00,0x3a,0x03,0x00,0x00,0x48,0x03,0x00,0x00,0x56,0x03,0x00,0x00,0x64,0x03,0x00,0x00,0x72,0x03,0x00,0x00,0x80,0x03,0x00,0x00,0x8e,0x03,0x00,0x00,0x9c,0x03,0x00,0x00,0xaa,0x03,0x00,0x00,0xb8,0x03,0x00,0x00,0xc6,0x03,0x00,0x00,0xd4,0x03,0x00,0x00,0xe2,0x03,0x00,0x00,0xf0,0x03,0x00,0x00,0xfe,0x03,0x00,0x00,0x0c,0x04,0x00,0x00,0x1a,0x04,0x00,0x00,0x28,0x04,0x00,0x00,0x36,0x04,0x00,0x00,0x44,0x04,0x00,0x00,0x52,0x04,0x00,0x00,0x60,0x04,0x00,0x00,0x6e,0x04,0x00,0x00,0x7c,0x04,0x00,0x00,0x8a,0x04,0x00,0x00,0x98,0x04,0x00,0x00,0xa6,0x04,0x00,0x00,0xb4,0x04,0x00,0x00,0xc2,0x04,0x00,0x00,0xd0,0x04,0x00,0x00,0xde,0x04,0x00,0x00,0xec,0x04,0x00,0x00,0xfa,0x04,0x00,0x00,0x08,0x05,0x00,0x00,0x16,0x05,0x00,0x00};

        public static ReadOnlySpan<char> Data => new char[1316]{'a','n','o','n','y','m','o','u','s','_','3','7','1','1','a','n','o','n','y','m','o','u','s','_','3','7','1','2','a','n','o','n','y','m','o','u','s','_','3','7','1','3','a','n','o','n','y','m','o','u','s','_','3','7','1','4','a','n','o','n','y','m','o','u','s','_','3','7','1','5','a','n','o','n','y','m','o','u','s','_','3','7','1','6','a','n','o','n','y','m','o','u','s','_','3','7','1','7','a','n','o','n','y','m','o','u','s','_','3','7','1','8','a','n','o','n','y','m','o','u','s','_','3','7','1','9','a','n','o','n','y','m','o','u','s','_','3','7','2','0','a','n','o','n','y','m','o','u','s','_','3','7','2','1','a','n','o','n','y','m','o','u','s','_','3','7','2','2','a','n','o','n','y','m','o','u','s','_','3','7','2','3','a','n','o','n','y','m','o','u','s','_','3','7','2','4','a','n','o','n','y','m','o','u','s','_','3','7','2','5','a','n','o','n','y','m','o','u','s','_','3','7','2','6','a','n','o','n','y','m','o','u','s','_','3','7','2','7','a','n','o','n','y','m','o','u','s','_','3','7','2','8','a','n','o','n','y','m','o','u','s','_','3','7','2','9','a','n','o','n','y','m','o','u','s','_','3','7','3','0','a','n','o','n','y','m','o','u','s','_','3','7','3','1','a','n','o','n','y','m','o','u','s','_','3','7','3','2','a','n','o','n','y','m','o','u','s','_','3','7','3','3','a','n','o','n','y','m','o','u','s','_','3','7','3','4','a','n','o','n','y','m','o','u','s','_','3','7','3','5','a','n','o','n','y','m','o','u','s','_','3','7','3','6','a','n','o','n','y','m','o','u','s','_','3','7','3','7','a','n','o','n','y','m','o','u','s','_','3','7','3','8','a','n','o','n','y','m','o','u','s','_','3','7','3','9','a','n','o','n','y','m','o','u','s','_','3','7','4','0','a','n','o','n','y','m','o','u','s','_','3','7','4','1','a','n','o','n','y','m','o','u','s','_','3','7','4','2','a','n','o','n','y','m','o','u','s','_','3','7','4','3','a','n','o','n','y','m','o','u','s','_','3','7','4','4','a','n','o','n','y','m','o','u','s','_','3','7','4','5','a','n','o','n','y','m','o','u','s','_','3','7','4','6','a','n','o','n','y','m','o','u','s','_','3','7','5','2','a','n','o','n','y','m','o','u','s','_','3','7','5','7','a','n','o','n','y','m','o','u','s','_','3','8','8','9','a','n','o','n','y','m','o','u','s','_','3','8','9','0','a','n','o','n','y','m','o','u','s','_','3','8','9','1','a','n','o','n','y','m','o','u','s','_','3','8','9','2','a','n','o','n','y','m','o','u','s','_','3','8','9','3','a','n','o','n','y','m','o','u','s','_','3','8','9','4','a','n','o','n','y','m','o','u','s','_','3','8','9','5','a','n','o','n','y','m','o','u','s','_','3','8','9','6','a','n','o','n','y','m','o','u','s','_','3','8','9','7','a','n','o','n','y','m','o','u','s','_','3','8','9','8','a','n','o','n','y','m','o','u','s','_','3','8','9','9','a','n','o','n','y','m','o','u','s','_','3','9','0','0','a','n','o','n','y','m','o','u','s','_','3','9','0','1','a','n','o','n','y','m','o','u','s','_','3','9','0','6','a','n','o','n','y','m','o','u','s','_','4','3','7','2','a','n','o','n','y','m','o','u','s','_','4','3','7','4','a','n','o','n','y','m','o','u','s','_','4','3','7','6','a','n','o','n','y','m','o','u','s','_','4','3','7','8','a','n','o','n','y','m','o','u','s','_','4','3','7','9','a','n','o','n','y','m','o','u','s','_','4','3','8','0','a','n','o','n','y','m','o','u','s','_','4','3','8','2','a','n','o','n','y','m','o','u','s','_','4','3','8','6','a','n','o','n','y','m','o','u','s','_','4','3','8','8','a','n','o','n','y','m','o','u','s','_','4','3','9','0','a','n','o','n','y','m','o','u','s','_','4','3','9','2','a','n','o','n','y','m','o','u','s','_','4','3','9','4','a','n','o','n','y','m','o','u','s','_','4','3','9','5','a','n','o','n','y','m','o','u','s','_','4','3','9','8','a','n','o','n','y','m','o','u','s','_','4','3','9','9','a','n','o','n','y','m','o','u','s','_','4','4','0','2','a','n','o','n','y','m','o','u','s','_','4','4','0','3','a','n','o','n','y','m','o','u','s','_','4','4','0','7','a','n','o','n','y','m','o','u','s','_','4','4','0','8','a','n','o','n','y','m','o','u','s','_','4','4','0','9','a','n','o','n','y','m','o','u','s','_','4','4','1','3','a','n','o','n','y','m','o','u','s','_','4','4','1','4','a','n','o','n','y','m','o','u','s','_','4','4','1','8','a','n','o','n','y','m','o','u','s','_','4','4','2','3','a','n','o','n','y','m','o','u','s','_','4','4','2','6','a','n','o','n','y','m','o','u','s','_','4','4','2','7','a','n','o','n','y','m','o','u','s','_','4','4','2','8','a','n','o','n','y','m','o','u','s','_','4','4','3','0','a','n','o','n','y','m','o','u','s','_','4','4','3','2','a','n','o','n','y','m','o','u','s','_','4','4','3','3','a','n','o','n','y','m','o','u','s','_','4','4','3','4','a','n','o','n','y','m','o','u','s','_','4','4','3','7','a','n','o','n','y','m','o','u','s','_','4','4','3','8','a','n','o','n','y','m','o','u','s','_','4','4','4','3','a','n','o','n','y','m','o','u','s','_','4','4','4','6','a','n','o','n','y','m','o','u','s','_','4','4','5','0','a','n','o','n','y','m','o','u','s','_','4','4','5','1','a','n','o','n','y','m','o','u','s','_','4','4','5','2','a','n','o','n','y','m','o','u','s','_','4','4','5','3','a','n','o','n','y','m','o','u','s','_','4','4','6','0','a','n','o','n','y','m','o','u','s','_','6','2','2','6','a','n','o','n','y','m','o','u','s','_','9','3','0','3',};
    }
}
