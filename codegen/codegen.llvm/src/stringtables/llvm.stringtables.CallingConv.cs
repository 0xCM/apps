﻿namespace Z0.llvm.stringtables
{
    using System;

    using static core;

    public enum CallingConvKind: uint
    {
        CC_Intel_OCL_BI=0,
        CC_X86=1,
        CC_X86_32=2,
        CC_X86_32_C=3,
        CC_X86_32_Common=4,
        CC_X86_32_FastCC=5,
        CC_X86_32_FastCall=6,
        CC_X86_32_GHC=7,
        CC_X86_32_HiPE=8,
        CC_X86_32_MCU=9,
        CC_X86_32_RegCall=10,
        CC_X86_32_ThisCall=11,
        CC_X86_32_ThisCall_Common=12,
        CC_X86_32_ThisCall_Mingw=13,
        CC_X86_32_ThisCall_Win=14,
        CC_X86_32_Vector_Common=15,
        CC_X86_32_Vector_Darwin=16,
        CC_X86_32_Vector_Standard=17,
        CC_X86_64=18,
        CC_X86_64_AnyReg=19,
        CC_X86_64_C=20,
        CC_X86_64_GHC=21,
        CC_X86_64_HHVM=22,
        CC_X86_64_HHVM_C=23,
        CC_X86_64_HiPE=24,
        CC_X86_64_WebKit_JS=25,
        CC_X86_SysV64_RegCall=26,
        CC_X86_Win32_CFGuard_Check=27,
        CC_X86_Win32_VectorCall=28,
        CC_X86_Win64_C=29,
        CC_X86_Win64_RegCall=30,
        CC_X86_Win64_VectorCall=31,
        RetCC_Intel_OCL_BI=32,
        RetCC_X86=33,
        RetCC_X86Common=34,
        RetCC_X86_32=35,
        RetCC_X86_32_C=36,
        RetCC_X86_32_Fast=37,
        RetCC_X86_32_HiPE=38,
        RetCC_X86_32_RegCall=39,
        RetCC_X86_32_VectorCall=40,
        RetCC_X86_64=41,
        RetCC_X86_64_AnyReg=42,
        RetCC_X86_64_C=43,
        RetCC_X86_64_HHVM=44,
        RetCC_X86_64_HiPE=45,
        RetCC_X86_64_Swift=46,
        RetCC_X86_64_Vectorcall=47,
        RetCC_X86_64_WebKit_JS=48,
        RetCC_X86_SysV64_RegCall=49,
        RetCC_X86_Win64_C=50,
        RetCC_X86_Win64_RegCall=51,
    }

    public readonly struct CallingConvData
    {
        public const uint EntryCount = 52;

        public const uint CharCount = 898;

        public static MemoryAddress CharBase => address(Data);

        public static MemoryAddress OffsetBase => address(Offsets);

        public static MemoryStrings Strings => strings.memory(Offsets,Data);

        public static ReadOnlySpan<byte> Offsets => new byte[208]{0x00,0x00,0x00,0x00,0x0f,0x00,0x00,0x00,0x15,0x00,0x00,0x00,0x1e,0x00,0x00,0x00,0x29,0x00,0x00,0x00,0x39,0x00,0x00,0x00,0x49,0x00,0x00,0x00,0x5b,0x00,0x00,0x00,0x68,0x00,0x00,0x00,0x76,0x00,0x00,0x00,0x83,0x00,0x00,0x00,0x94,0x00,0x00,0x00,0xa6,0x00,0x00,0x00,0xbf,0x00,0x00,0x00,0xd7,0x00,0x00,0x00,0xed,0x00,0x00,0x00,0x04,0x01,0x00,0x00,0x1b,0x01,0x00,0x00,0x34,0x01,0x00,0x00,0x3d,0x01,0x00,0x00,0x4d,0x01,0x00,0x00,0x58,0x01,0x00,0x00,0x65,0x01,0x00,0x00,0x73,0x01,0x00,0x00,0x83,0x01,0x00,0x00,0x91,0x01,0x00,0x00,0xa4,0x01,0x00,0x00,0xb9,0x01,0x00,0x00,0xd3,0x01,0x00,0x00,0xea,0x01,0x00,0x00,0xf8,0x01,0x00,0x00,0x0c,0x02,0x00,0x00,0x23,0x02,0x00,0x00,0x35,0x02,0x00,0x00,0x3e,0x02,0x00,0x00,0x4d,0x02,0x00,0x00,0x59,0x02,0x00,0x00,0x67,0x02,0x00,0x00,0x78,0x02,0x00,0x00,0x89,0x02,0x00,0x00,0x9d,0x02,0x00,0x00,0xb4,0x02,0x00,0x00,0xc0,0x02,0x00,0x00,0xd3,0x02,0x00,0x00,0xe1,0x02,0x00,0x00,0xf2,0x02,0x00,0x00,0x03,0x03,0x00,0x00,0x15,0x03,0x00,0x00,0x2c,0x03,0x00,0x00,0x42,0x03,0x00,0x00,0x5a,0x03,0x00,0x00,0x6b,0x03,0x00,0x00};

        public static ReadOnlySpan<char> Data => new char[898]{'C','C','_','I','n','t','e','l','_','O','C','L','_','B','I','C','C','_','X','8','6','C','C','_','X','8','6','_','3','2','C','C','_','X','8','6','_','3','2','_','C','C','C','_','X','8','6','_','3','2','_','C','o','m','m','o','n','C','C','_','X','8','6','_','3','2','_','F','a','s','t','C','C','C','C','_','X','8','6','_','3','2','_','F','a','s','t','C','a','l','l','C','C','_','X','8','6','_','3','2','_','G','H','C','C','C','_','X','8','6','_','3','2','_','H','i','P','E','C','C','_','X','8','6','_','3','2','_','M','C','U','C','C','_','X','8','6','_','3','2','_','R','e','g','C','a','l','l','C','C','_','X','8','6','_','3','2','_','T','h','i','s','C','a','l','l','C','C','_','X','8','6','_','3','2','_','T','h','i','s','C','a','l','l','_','C','o','m','m','o','n','C','C','_','X','8','6','_','3','2','_','T','h','i','s','C','a','l','l','_','M','i','n','g','w','C','C','_','X','8','6','_','3','2','_','T','h','i','s','C','a','l','l','_','W','i','n','C','C','_','X','8','6','_','3','2','_','V','e','c','t','o','r','_','C','o','m','m','o','n','C','C','_','X','8','6','_','3','2','_','V','e','c','t','o','r','_','D','a','r','w','i','n','C','C','_','X','8','6','_','3','2','_','V','e','c','t','o','r','_','S','t','a','n','d','a','r','d','C','C','_','X','8','6','_','6','4','C','C','_','X','8','6','_','6','4','_','A','n','y','R','e','g','C','C','_','X','8','6','_','6','4','_','C','C','C','_','X','8','6','_','6','4','_','G','H','C','C','C','_','X','8','6','_','6','4','_','H','H','V','M','C','C','_','X','8','6','_','6','4','_','H','H','V','M','_','C','C','C','_','X','8','6','_','6','4','_','H','i','P','E','C','C','_','X','8','6','_','6','4','_','W','e','b','K','i','t','_','J','S','C','C','_','X','8','6','_','S','y','s','V','6','4','_','R','e','g','C','a','l','l','C','C','_','X','8','6','_','W','i','n','3','2','_','C','F','G','u','a','r','d','_','C','h','e','c','k','C','C','_','X','8','6','_','W','i','n','3','2','_','V','e','c','t','o','r','C','a','l','l','C','C','_','X','8','6','_','W','i','n','6','4','_','C','C','C','_','X','8','6','_','W','i','n','6','4','_','R','e','g','C','a','l','l','C','C','_','X','8','6','_','W','i','n','6','4','_','V','e','c','t','o','r','C','a','l','l','R','e','t','C','C','_','I','n','t','e','l','_','O','C','L','_','B','I','R','e','t','C','C','_','X','8','6','R','e','t','C','C','_','X','8','6','C','o','m','m','o','n','R','e','t','C','C','_','X','8','6','_','3','2','R','e','t','C','C','_','X','8','6','_','3','2','_','C','R','e','t','C','C','_','X','8','6','_','3','2','_','F','a','s','t','R','e','t','C','C','_','X','8','6','_','3','2','_','H','i','P','E','R','e','t','C','C','_','X','8','6','_','3','2','_','R','e','g','C','a','l','l','R','e','t','C','C','_','X','8','6','_','3','2','_','V','e','c','t','o','r','C','a','l','l','R','e','t','C','C','_','X','8','6','_','6','4','R','e','t','C','C','_','X','8','6','_','6','4','_','A','n','y','R','e','g','R','e','t','C','C','_','X','8','6','_','6','4','_','C','R','e','t','C','C','_','X','8','6','_','6','4','_','H','H','V','M','R','e','t','C','C','_','X','8','6','_','6','4','_','H','i','P','E','R','e','t','C','C','_','X','8','6','_','6','4','_','S','w','i','f','t','R','e','t','C','C','_','X','8','6','_','6','4','_','V','e','c','t','o','r','c','a','l','l','R','e','t','C','C','_','X','8','6','_','6','4','_','W','e','b','K','i','t','_','J','S','R','e','t','C','C','_','X','8','6','_','S','y','s','V','6','4','_','R','e','g','C','a','l','l','R','e','t','C','C','_','X','8','6','_','W','i','n','6','4','_','C','R','e','t','C','C','_','X','8','6','_','W','i','n','6','4','_','R','e','g','C','a','l','l',};
    }

}
