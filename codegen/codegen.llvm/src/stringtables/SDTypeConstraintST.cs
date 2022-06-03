namespace Z0.llvm.strings
{
    using System;

    using static core;

    public enum SDTypeConstraintKind : uint
    {
        anonymous_3664 = 0,
        anonymous_3665 = 1,
        anonymous_3666 = 2,
        anonymous_3667 = 3,
        anonymous_3668 = 4,
        anonymous_3669 = 5,
        anonymous_3670 = 6,
        anonymous_3671 = 7,
        anonymous_3672 = 8,
        anonymous_3673 = 9,
        anonymous_3674 = 10,
        anonymous_3675 = 11,
        anonymous_3676 = 12,
        anonymous_3677 = 13,
        anonymous_3678 = 14,
        anonymous_3679 = 15,
        anonymous_3680 = 16,
        anonymous_3681 = 17,
        anonymous_3682 = 18,
        anonymous_3683 = 19,
        anonymous_3684 = 20,
        anonymous_3685 = 21,
        anonymous_3686 = 22,
        anonymous_3687 = 23,
        anonymous_3688 = 24,
        anonymous_3689 = 25,
        anonymous_3690 = 26,
        anonymous_3691 = 27,
        anonymous_3692 = 28,
        anonymous_3693 = 29,
        anonymous_3694 = 30,
        anonymous_3695 = 31,
        anonymous_3696 = 32,
        anonymous_3697 = 33,
        anonymous_3698 = 34,
        anonymous_3699 = 35,
        anonymous_3700 = 36,
        anonymous_3701 = 37,
        anonymous_3707 = 38,
        anonymous_3712 = 39,
        anonymous_3842 = 40,
        anonymous_3843 = 41,
        anonymous_3844 = 42,
        anonymous_3845 = 43,
        anonymous_3846 = 44,
        anonymous_3847 = 45,
        anonymous_3848 = 46,
        anonymous_3849 = 47,
        anonymous_3850 = 48,
        anonymous_3851 = 49,
        anonymous_3852 = 50,
        anonymous_3853 = 51,
        anonymous_3854 = 52,
        anonymous_3855 = 53,
        anonymous_3860 = 54,
        anonymous_4326 = 55,
        anonymous_4328 = 56,
        anonymous_4330 = 57,
        anonymous_4332 = 58,
        anonymous_4333 = 59,
        anonymous_4334 = 60,
        anonymous_4336 = 61,
        anonymous_4340 = 62,
        anonymous_4342 = 63,
        anonymous_4344 = 64,
        anonymous_4346 = 65,
        anonymous_4348 = 66,
        anonymous_4349 = 67,
        anonymous_4352 = 68,
        anonymous_4353 = 69,
        anonymous_4354 = 70,
        anonymous_4355 = 71,
        anonymous_4357 = 72,
        anonymous_4358 = 73,
        anonymous_4360 = 74,
        anonymous_4361 = 75,
        anonymous_4364 = 76,
        anonymous_4367 = 77,
        anonymous_4368 = 78,
        anonymous_4369 = 79,
        anonymous_4371 = 80,
        anonymous_4374 = 81,
        anonymous_4375 = 82,
        anonymous_4379 = 83,
        anonymous_4384 = 84,
        anonymous_4387 = 85,
        anonymous_4388 = 86,
        anonymous_4389 = 87,
        anonymous_4391 = 88,
        anonymous_4394 = 89,
        anonymous_4395 = 90,
        anonymous_4400 = 91,
        anonymous_4403 = 92,
        anonymous_4407 = 93,
        anonymous_4408 = 94,
        anonymous_4415 = 95,
        anonymous_6080 = 96,
        anonymous_8715 = 97,
    }

    public readonly struct SDTypeConstraintST
    {
        public const uint EntryCount = 98;

        public const uint CharCount = 1372;

        public static MemoryAddress CharBase => address(Data);

        public static MemoryAddress OffsetBase => address(Offsets);

        public static MemoryStrings<SDTypeConstraintKind> Strings => MemoryStrings.create(Offsets,Data);

        public static ReadOnlySpan<byte> Offsets => new byte[392]{0x00,0x00,0x00,0x00,0x0e,0x00,0x00,0x00,0x1c,0x00,0x00,0x00,0x2a,0x00,0x00,0x00,0x38,0x00,0x00,0x00,0x46,0x00,0x00,0x00,0x54,0x00,0x00,0x00,0x62,0x00,0x00,0x00,0x70,0x00,0x00,0x00,0x7e,0x00,0x00,0x00,0x8c,0x00,0x00,0x00,0x9a,0x00,0x00,0x00,0xa8,0x00,0x00,0x00,0xb6,0x00,0x00,0x00,0xc4,0x00,0x00,0x00,0xd2,0x00,0x00,0x00,0xe0,0x00,0x00,0x00,0xee,0x00,0x00,0x00,0xfc,0x00,0x00,0x00,0x0a,0x01,0x00,0x00,0x18,0x01,0x00,0x00,0x26,0x01,0x00,0x00,0x34,0x01,0x00,0x00,0x42,0x01,0x00,0x00,0x50,0x01,0x00,0x00,0x5e,0x01,0x00,0x00,0x6c,0x01,0x00,0x00,0x7a,0x01,0x00,0x00,0x88,0x01,0x00,0x00,0x96,0x01,0x00,0x00,0xa4,0x01,0x00,0x00,0xb2,0x01,0x00,0x00,0xc0,0x01,0x00,0x00,0xce,0x01,0x00,0x00,0xdc,0x01,0x00,0x00,0xea,0x01,0x00,0x00,0xf8,0x01,0x00,0x00,0x06,0x02,0x00,0x00,0x14,0x02,0x00,0x00,0x22,0x02,0x00,0x00,0x30,0x02,0x00,0x00,0x3e,0x02,0x00,0x00,0x4c,0x02,0x00,0x00,0x5a,0x02,0x00,0x00,0x68,0x02,0x00,0x00,0x76,0x02,0x00,0x00,0x84,0x02,0x00,0x00,0x92,0x02,0x00,0x00,0xa0,0x02,0x00,0x00,0xae,0x02,0x00,0x00,0xbc,0x02,0x00,0x00,0xca,0x02,0x00,0x00,0xd8,0x02,0x00,0x00,0xe6,0x02,0x00,0x00,0xf4,0x02,0x00,0x00,0x02,0x03,0x00,0x00,0x10,0x03,0x00,0x00,0x1e,0x03,0x00,0x00,0x2c,0x03,0x00,0x00,0x3a,0x03,0x00,0x00,0x48,0x03,0x00,0x00,0x56,0x03,0x00,0x00,0x64,0x03,0x00,0x00,0x72,0x03,0x00,0x00,0x80,0x03,0x00,0x00,0x8e,0x03,0x00,0x00,0x9c,0x03,0x00,0x00,0xaa,0x03,0x00,0x00,0xb8,0x03,0x00,0x00,0xc6,0x03,0x00,0x00,0xd4,0x03,0x00,0x00,0xe2,0x03,0x00,0x00,0xf0,0x03,0x00,0x00,0xfe,0x03,0x00,0x00,0x0c,0x04,0x00,0x00,0x1a,0x04,0x00,0x00,0x28,0x04,0x00,0x00,0x36,0x04,0x00,0x00,0x44,0x04,0x00,0x00,0x52,0x04,0x00,0x00,0x60,0x04,0x00,0x00,0x6e,0x04,0x00,0x00,0x7c,0x04,0x00,0x00,0x8a,0x04,0x00,0x00,0x98,0x04,0x00,0x00,0xa6,0x04,0x00,0x00,0xb4,0x04,0x00,0x00,0xc2,0x04,0x00,0x00,0xd0,0x04,0x00,0x00,0xde,0x04,0x00,0x00,0xec,0x04,0x00,0x00,0xfa,0x04,0x00,0x00,0x08,0x05,0x00,0x00,0x16,0x05,0x00,0x00,0x24,0x05,0x00,0x00,0x32,0x05,0x00,0x00,0x40,0x05,0x00,0x00,0x4e,0x05,0x00,0x00};

        public static ReadOnlySpan<char> Data => new char[1372]{'a','n','o','n','y','m','o','u','s','_','3','6','6','4','a','n','o','n','y','m','o','u','s','_','3','6','6','5','a','n','o','n','y','m','o','u','s','_','3','6','6','6','a','n','o','n','y','m','o','u','s','_','3','6','6','7','a','n','o','n','y','m','o','u','s','_','3','6','6','8','a','n','o','n','y','m','o','u','s','_','3','6','6','9','a','n','o','n','y','m','o','u','s','_','3','6','7','0','a','n','o','n','y','m','o','u','s','_','3','6','7','1','a','n','o','n','y','m','o','u','s','_','3','6','7','2','a','n','o','n','y','m','o','u','s','_','3','6','7','3','a','n','o','n','y','m','o','u','s','_','3','6','7','4','a','n','o','n','y','m','o','u','s','_','3','6','7','5','a','n','o','n','y','m','o','u','s','_','3','6','7','6','a','n','o','n','y','m','o','u','s','_','3','6','7','7','a','n','o','n','y','m','o','u','s','_','3','6','7','8','a','n','o','n','y','m','o','u','s','_','3','6','7','9','a','n','o','n','y','m','o','u','s','_','3','6','8','0','a','n','o','n','y','m','o','u','s','_','3','6','8','1','a','n','o','n','y','m','o','u','s','_','3','6','8','2','a','n','o','n','y','m','o','u','s','_','3','6','8','3','a','n','o','n','y','m','o','u','s','_','3','6','8','4','a','n','o','n','y','m','o','u','s','_','3','6','8','5','a','n','o','n','y','m','o','u','s','_','3','6','8','6','a','n','o','n','y','m','o','u','s','_','3','6','8','7','a','n','o','n','y','m','o','u','s','_','3','6','8','8','a','n','o','n','y','m','o','u','s','_','3','6','8','9','a','n','o','n','y','m','o','u','s','_','3','6','9','0','a','n','o','n','y','m','o','u','s','_','3','6','9','1','a','n','o','n','y','m','o','u','s','_','3','6','9','2','a','n','o','n','y','m','o','u','s','_','3','6','9','3','a','n','o','n','y','m','o','u','s','_','3','6','9','4','a','n','o','n','y','m','o','u','s','_','3','6','9','5','a','n','o','n','y','m','o','u','s','_','3','6','9','6','a','n','o','n','y','m','o','u','s','_','3','6','9','7','a','n','o','n','y','m','o','u','s','_','3','6','9','8','a','n','o','n','y','m','o','u','s','_','3','6','9','9','a','n','o','n','y','m','o','u','s','_','3','7','0','0','a','n','o','n','y','m','o','u','s','_','3','7','0','1','a','n','o','n','y','m','o','u','s','_','3','7','0','7','a','n','o','n','y','m','o','u','s','_','3','7','1','2','a','n','o','n','y','m','o','u','s','_','3','8','4','2','a','n','o','n','y','m','o','u','s','_','3','8','4','3','a','n','o','n','y','m','o','u','s','_','3','8','4','4','a','n','o','n','y','m','o','u','s','_','3','8','4','5','a','n','o','n','y','m','o','u','s','_','3','8','4','6','a','n','o','n','y','m','o','u','s','_','3','8','4','7','a','n','o','n','y','m','o','u','s','_','3','8','4','8','a','n','o','n','y','m','o','u','s','_','3','8','4','9','a','n','o','n','y','m','o','u','s','_','3','8','5','0','a','n','o','n','y','m','o','u','s','_','3','8','5','1','a','n','o','n','y','m','o','u','s','_','3','8','5','2','a','n','o','n','y','m','o','u','s','_','3','8','5','3','a','n','o','n','y','m','o','u','s','_','3','8','5','4','a','n','o','n','y','m','o','u','s','_','3','8','5','5','a','n','o','n','y','m','o','u','s','_','3','8','6','0','a','n','o','n','y','m','o','u','s','_','4','3','2','6','a','n','o','n','y','m','o','u','s','_','4','3','2','8','a','n','o','n','y','m','o','u','s','_','4','3','3','0','a','n','o','n','y','m','o','u','s','_','4','3','3','2','a','n','o','n','y','m','o','u','s','_','4','3','3','3','a','n','o','n','y','m','o','u','s','_','4','3','3','4','a','n','o','n','y','m','o','u','s','_','4','3','3','6','a','n','o','n','y','m','o','u','s','_','4','3','4','0','a','n','o','n','y','m','o','u','s','_','4','3','4','2','a','n','o','n','y','m','o','u','s','_','4','3','4','4','a','n','o','n','y','m','o','u','s','_','4','3','4','6','a','n','o','n','y','m','o','u','s','_','4','3','4','8','a','n','o','n','y','m','o','u','s','_','4','3','4','9','a','n','o','n','y','m','o','u','s','_','4','3','5','2','a','n','o','n','y','m','o','u','s','_','4','3','5','3','a','n','o','n','y','m','o','u','s','_','4','3','5','4','a','n','o','n','y','m','o','u','s','_','4','3','5','5','a','n','o','n','y','m','o','u','s','_','4','3','5','7','a','n','o','n','y','m','o','u','s','_','4','3','5','8','a','n','o','n','y','m','o','u','s','_','4','3','6','0','a','n','o','n','y','m','o','u','s','_','4','3','6','1','a','n','o','n','y','m','o','u','s','_','4','3','6','4','a','n','o','n','y','m','o','u','s','_','4','3','6','7','a','n','o','n','y','m','o','u','s','_','4','3','6','8','a','n','o','n','y','m','o','u','s','_','4','3','6','9','a','n','o','n','y','m','o','u','s','_','4','3','7','1','a','n','o','n','y','m','o','u','s','_','4','3','7','4','a','n','o','n','y','m','o','u','s','_','4','3','7','5','a','n','o','n','y','m','o','u','s','_','4','3','7','9','a','n','o','n','y','m','o','u','s','_','4','3','8','4','a','n','o','n','y','m','o','u','s','_','4','3','8','7','a','n','o','n','y','m','o','u','s','_','4','3','8','8','a','n','o','n','y','m','o','u','s','_','4','3','8','9','a','n','o','n','y','m','o','u','s','_','4','3','9','1','a','n','o','n','y','m','o','u','s','_','4','3','9','4','a','n','o','n','y','m','o','u','s','_','4','3','9','5','a','n','o','n','y','m','o','u','s','_','4','4','0','0','a','n','o','n','y','m','o','u','s','_','4','4','0','3','a','n','o','n','y','m','o','u','s','_','4','4','0','7','a','n','o','n','y','m','o','u','s','_','4','4','0','8','a','n','o','n','y','m','o','u','s','_','4','4','1','5','a','n','o','n','y','m','o','u','s','_','6','0','8','0','a','n','o','n','y','m','o','u','s','_','8','7','1','5',};
    }
}
