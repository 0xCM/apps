﻿namespace Z0.llvm.stringtables
{
    using System;

    using static core;

    public readonly struct GenericInstruction
    {
        public const uint EntryCount = 198;

        public const uint CharCount = 2089;

        public static MemoryAddress CharBase => address(Data);

        public static MemoryAddress OffsetBase => address(Offsets);

        public static MemoryStrings Strings => strings.memory(Offsets, Data);

        public enum Index : uint
        {
            G_ABS=0,
            G_ADD=1,
            G_ADDRSPACE_CAST=2,
            G_AND=3,
            G_ANYEXT=4,
            G_ASHR=5,
            G_ASSERT_SEXT=6,
            G_ASSERT_ZEXT=7,
            G_ATOMICRMW_ADD=8,
            G_ATOMICRMW_AND=9,
            G_ATOMICRMW_FADD=10,
            G_ATOMICRMW_FSUB=11,
            G_ATOMICRMW_MAX=12,
            G_ATOMICRMW_MIN=13,
            G_ATOMICRMW_NAND=14,
            G_ATOMICRMW_OR=15,
            G_ATOMICRMW_SUB=16,
            G_ATOMICRMW_UMAX=17,
            G_ATOMICRMW_UMIN=18,
            G_ATOMICRMW_XCHG=19,
            G_ATOMICRMW_XOR=20,
            G_ATOMIC_CMPXCHG=21,
            G_ATOMIC_CMPXCHG_WITH_SUCCESS=22,
            G_BITCAST=23,
            G_BITREVERSE=24,
            G_BLOCK_ADDR=25,
            G_BR=26,
            G_BRCOND=27,
            G_BRINDIRECT=28,
            G_BRJT=29,
            G_BSWAP=30,
            G_BUILD_VECTOR=31,
            G_BUILD_VECTOR_TRUNC=32,
            G_BZERO=33,
            G_CONCAT_VECTORS=34,
            G_CONSTANT=35,
            G_CTLZ=36,
            G_CTLZ_ZERO_UNDEF=37,
            G_CTPOP=38,
            G_CTTZ=39,
            G_CTTZ_ZERO_UNDEF=40,
            G_DYN_STACKALLOC=41,
            G_EXTRACT=42,
            G_EXTRACT_VECTOR_ELT=43,
            G_FABS=44,
            G_FADD=45,
            G_FCANONICALIZE=46,
            G_FCEIL=47,
            G_FCMP=48,
            G_FCONSTANT=49,
            G_FCOPYSIGN=50,
            G_FCOS=51,
            G_FDIV=52,
            G_FENCE=53,
            G_FEXP=54,
            G_FEXP2=55,
            G_FFLOOR=56,
            G_FLOG=57,
            G_FLOG10=58,
            G_FLOG2=59,
            G_FMA=60,
            G_FMAD=61,
            G_FMAXIMUM=62,
            G_FMAXNUM=63,
            G_FMAXNUM_IEEE=64,
            G_FMINIMUM=65,
            G_FMINNUM=66,
            G_FMINNUM_IEEE=67,
            G_FMUL=68,
            G_FNEARBYINT=69,
            G_FNEG=70,
            G_FPEXT=71,
            G_FPOW=72,
            G_FPOWI=73,
            G_FPTOSI=74,
            G_FPTOUI=75,
            G_FPTRUNC=76,
            G_FRAME_INDEX=77,
            G_FREEZE=78,
            G_FREM=79,
            G_FRINT=80,
            G_FSHL=81,
            G_FSHR=82,
            G_FSIN=83,
            G_FSQRT=84,
            G_FSUB=85,
            G_GLOBAL_VALUE=86,
            G_ICMP=87,
            G_IMPLICIT_DEF=88,
            G_INDEXED_LOAD=89,
            G_INDEXED_SEXTLOAD=90,
            G_INDEXED_STORE=91,
            G_INDEXED_ZEXTLOAD=92,
            G_INSERT=93,
            G_INSERT_VECTOR_ELT=94,
            G_INTRINSIC=95,
            G_INTRINSIC_LRINT=96,
            G_INTRINSIC_ROUND=97,
            G_INTRINSIC_ROUNDEVEN=98,
            G_INTRINSIC_TRUNC=99,
            G_INTRINSIC_W_SIDE_EFFECTS=100,
            G_INTTOPTR=101,
            G_JUMP_TABLE=102,
            G_LOAD=103,
            G_LSHR=104,
            G_MEMCPY=105,
            G_MEMCPY_INLINE=106,
            G_MEMMOVE=107,
            G_MEMSET=108,
            G_MERGE_VALUES=109,
            G_MUL=110,
            G_OR=111,
            G_PHI=112,
            G_PTRMASK=113,
            G_PTRTOINT=114,
            G_PTR_ADD=115,
            G_READCYCLECOUNTER=116,
            G_READ_REGISTER=117,
            G_ROTL=118,
            G_ROTR=119,
            G_SADDE=120,
            G_SADDO=121,
            G_SADDSAT=122,
            G_SBFX=123,
            G_SDIV=124,
            G_SDIVFIX=125,
            G_SDIVFIXSAT=126,
            G_SDIVREM=127,
            G_SELECT=128,
            G_SEXT=129,
            G_SEXTLOAD=130,
            G_SEXT_INREG=131,
            G_SHL=132,
            G_SHUFFLE_VECTOR=133,
            G_SITOFP=134,
            G_SMAX=135,
            G_SMIN=136,
            G_SMULFIX=137,
            G_SMULFIXSAT=138,
            G_SMULH=139,
            G_SMULO=140,
            G_SREM=141,
            G_SSHLSAT=142,
            G_SSUBE=143,
            G_SSUBO=144,
            G_SSUBSAT=145,
            G_STORE=146,
            G_STRICT_FADD=147,
            G_STRICT_FDIV=148,
            G_STRICT_FMA=149,
            G_STRICT_FMUL=150,
            G_STRICT_FREM=151,
            G_STRICT_FSQRT=152,
            G_STRICT_FSUB=153,
            G_SUB=154,
            G_TRUNC=155,
            G_UADDE=156,
            G_UADDO=157,
            G_UADDSAT=158,
            G_UBFX=159,
            G_UDIV=160,
            G_UDIVFIX=161,
            G_UDIVFIXSAT=162,
            G_UDIVREM=163,
            G_UITOFP=164,
            G_UMAX=165,
            G_UMIN=166,
            G_UMULFIX=167,
            G_UMULFIXSAT=168,
            G_UMULH=169,
            G_UMULO=170,
            G_UNMERGE_VALUES=171,
            G_UREM=172,
            G_USHLSAT=173,
            G_USUBE=174,
            G_USUBO=175,
            G_USUBSAT=176,
            G_VAARG=177,
            G_VASTART=178,
            G_VECREDUCE_ADD=179,
            G_VECREDUCE_AND=180,
            G_VECREDUCE_FADD=181,
            G_VECREDUCE_FMAX=182,
            G_VECREDUCE_FMIN=183,
            G_VECREDUCE_FMUL=184,
            G_VECREDUCE_MUL=185,
            G_VECREDUCE_OR=186,
            G_VECREDUCE_SEQ_FADD=187,
            G_VECREDUCE_SEQ_FMUL=188,
            G_VECREDUCE_SMAX=189,
            G_VECREDUCE_SMIN=190,
            G_VECREDUCE_UMAX=191,
            G_VECREDUCE_UMIN=192,
            G_VECREDUCE_XOR=193,
            G_WRITE_REGISTER=194,
            G_XOR=195,
            G_ZEXT=196,
            G_ZEXTLOAD=197,
        }

        public static ReadOnlySpan<byte> Offsets => new byte[792]{0x00,0x00,0x00,0x00,0x05,0x00,0x00,0x00,0x0a,0x00,0x00,0x00,0x1a,0x00,0x00,0x00,0x1f,0x00,0x00,0x00,0x27,0x00,0x00,0x00,0x2d,0x00,0x00,0x00,0x3a,0x00,0x00,0x00,0x47,0x00,0x00,0x00,0x56,0x00,0x00,0x00,0x65,0x00,0x00,0x00,0x75,0x00,0x00,0x00,0x85,0x00,0x00,0x00,0x94,0x00,0x00,0x00,0xa3,0x00,0x00,0x00,0xb3,0x00,0x00,0x00,0xc1,0x00,0x00,0x00,0xd0,0x00,0x00,0x00,0xe0,0x00,0x00,0x00,0xf0,0x00,0x00,0x00,0x00,0x01,0x00,0x00,0x0f,0x01,0x00,0x00,0x1f,0x01,0x00,0x00,0x3c,0x01,0x00,0x00,0x45,0x01,0x00,0x00,0x51,0x01,0x00,0x00,0x5d,0x01,0x00,0x00,0x61,0x01,0x00,0x00,0x69,0x01,0x00,0x00,0x75,0x01,0x00,0x00,0x7b,0x01,0x00,0x00,0x82,0x01,0x00,0x00,0x90,0x01,0x00,0x00,0xa4,0x01,0x00,0x00,0xab,0x01,0x00,0x00,0xbb,0x01,0x00,0x00,0xc5,0x01,0x00,0x00,0xcb,0x01,0x00,0x00,0xdc,0x01,0x00,0x00,0xe3,0x01,0x00,0x00,0xe9,0x01,0x00,0x00,0xfa,0x01,0x00,0x00,0x0a,0x02,0x00,0x00,0x13,0x02,0x00,0x00,0x27,0x02,0x00,0x00,0x2d,0x02,0x00,0x00,0x33,0x02,0x00,0x00,0x42,0x02,0x00,0x00,0x49,0x02,0x00,0x00,0x4f,0x02,0x00,0x00,0x5a,0x02,0x00,0x00,0x65,0x02,0x00,0x00,0x6b,0x02,0x00,0x00,0x71,0x02,0x00,0x00,0x78,0x02,0x00,0x00,0x7e,0x02,0x00,0x00,0x85,0x02,0x00,0x00,0x8d,0x02,0x00,0x00,0x93,0x02,0x00,0x00,0x9b,0x02,0x00,0x00,0xa2,0x02,0x00,0x00,0xa7,0x02,0x00,0x00,0xad,0x02,0x00,0x00,0xb7,0x02,0x00,0x00,0xc0,0x02,0x00,0x00,0xce,0x02,0x00,0x00,0xd8,0x02,0x00,0x00,0xe1,0x02,0x00,0x00,0xef,0x02,0x00,0x00,0xf5,0x02,0x00,0x00,0x01,0x03,0x00,0x00,0x07,0x03,0x00,0x00,0x0e,0x03,0x00,0x00,0x14,0x03,0x00,0x00,0x1b,0x03,0x00,0x00,0x23,0x03,0x00,0x00,0x2b,0x03,0x00,0x00,0x34,0x03,0x00,0x00,0x41,0x03,0x00,0x00,0x49,0x03,0x00,0x00,0x4f,0x03,0x00,0x00,0x56,0x03,0x00,0x00,0x5c,0x03,0x00,0x00,0x62,0x03,0x00,0x00,0x68,0x03,0x00,0x00,0x6f,0x03,0x00,0x00,0x75,0x03,0x00,0x00,0x83,0x03,0x00,0x00,0x89,0x03,0x00,0x00,0x97,0x03,0x00,0x00,0xa5,0x03,0x00,0x00,0xb7,0x03,0x00,0x00,0xc6,0x03,0x00,0x00,0xd8,0x03,0x00,0x00,0xe0,0x03,0x00,0x00,0xf3,0x03,0x00,0x00,0xfe,0x03,0x00,0x00,0x0f,0x04,0x00,0x00,0x20,0x04,0x00,0x00,0x35,0x04,0x00,0x00,0x46,0x04,0x00,0x00,0x60,0x04,0x00,0x00,0x6a,0x04,0x00,0x00,0x76,0x04,0x00,0x00,0x7c,0x04,0x00,0x00,0x82,0x04,0x00,0x00,0x8a,0x04,0x00,0x00,0x99,0x04,0x00,0x00,0xa2,0x04,0x00,0x00,0xaa,0x04,0x00,0x00,0xb8,0x04,0x00,0x00,0xbd,0x04,0x00,0x00,0xc1,0x04,0x00,0x00,0xc6,0x04,0x00,0x00,0xcf,0x04,0x00,0x00,0xd9,0x04,0x00,0x00,0xe2,0x04,0x00,0x00,0xf4,0x04,0x00,0x00,0x03,0x05,0x00,0x00,0x09,0x05,0x00,0x00,0x0f,0x05,0x00,0x00,0x16,0x05,0x00,0x00,0x1d,0x05,0x00,0x00,0x26,0x05,0x00,0x00,0x2c,0x05,0x00,0x00,0x32,0x05,0x00,0x00,0x3b,0x05,0x00,0x00,0x47,0x05,0x00,0x00,0x50,0x05,0x00,0x00,0x58,0x05,0x00,0x00,0x5e,0x05,0x00,0x00,0x68,0x05,0x00,0x00,0x74,0x05,0x00,0x00,0x79,0x05,0x00,0x00,0x89,0x05,0x00,0x00,0x91,0x05,0x00,0x00,0x97,0x05,0x00,0x00,0x9d,0x05,0x00,0x00,0xa6,0x05,0x00,0x00,0xb2,0x05,0x00,0x00,0xb9,0x05,0x00,0x00,0xc0,0x05,0x00,0x00,0xc6,0x05,0x00,0x00,0xcf,0x05,0x00,0x00,0xd6,0x05,0x00,0x00,0xdd,0x05,0x00,0x00,0xe6,0x05,0x00,0x00,0xed,0x05,0x00,0x00,0xfa,0x05,0x00,0x00,0x07,0x06,0x00,0x00,0x13,0x06,0x00,0x00,0x20,0x06,0x00,0x00,0x2d,0x06,0x00,0x00,0x3b,0x06,0x00,0x00,0x48,0x06,0x00,0x00,0x4d,0x06,0x00,0x00,0x54,0x06,0x00,0x00,0x5b,0x06,0x00,0x00,0x62,0x06,0x00,0x00,0x6b,0x06,0x00,0x00,0x71,0x06,0x00,0x00,0x77,0x06,0x00,0x00,0x80,0x06,0x00,0x00,0x8c,0x06,0x00,0x00,0x95,0x06,0x00,0x00,0x9d,0x06,0x00,0x00,0xa3,0x06,0x00,0x00,0xa9,0x06,0x00,0x00,0xb2,0x06,0x00,0x00,0xbe,0x06,0x00,0x00,0xc5,0x06,0x00,0x00,0xcc,0x06,0x00,0x00,0xdc,0x06,0x00,0x00,0xe2,0x06,0x00,0x00,0xeb,0x06,0x00,0x00,0xf2,0x06,0x00,0x00,0xf9,0x06,0x00,0x00,0x02,0x07,0x00,0x00,0x09,0x07,0x00,0x00,0x12,0x07,0x00,0x00,0x21,0x07,0x00,0x00,0x30,0x07,0x00,0x00,0x40,0x07,0x00,0x00,0x50,0x07,0x00,0x00,0x60,0x07,0x00,0x00,0x70,0x07,0x00,0x00,0x7f,0x07,0x00,0x00,0x8d,0x07,0x00,0x00,0xa1,0x07,0x00,0x00,0xb5,0x07,0x00,0x00,0xc5,0x07,0x00,0x00,0xd5,0x07,0x00,0x00,0xe5,0x07,0x00,0x00,0xf5,0x07,0x00,0x00,0x04,0x08,0x00,0x00,0x14,0x08,0x00,0x00,0x19,0x08,0x00,0x00,0x1f,0x08,0x00,0x00};

        public static ReadOnlySpan<char> Data => new char[2089]{'G','_','A','B','S','G','_','A','D','D','G','_','A','D','D','R','S','P','A','C','E','_','C','A','S','T','G','_','A','N','D','G','_','A','N','Y','E','X','T','G','_','A','S','H','R','G','_','A','S','S','E','R','T','_','S','E','X','T','G','_','A','S','S','E','R','T','_','Z','E','X','T','G','_','A','T','O','M','I','C','R','M','W','_','A','D','D','G','_','A','T','O','M','I','C','R','M','W','_','A','N','D','G','_','A','T','O','M','I','C','R','M','W','_','F','A','D','D','G','_','A','T','O','M','I','C','R','M','W','_','F','S','U','B','G','_','A','T','O','M','I','C','R','M','W','_','M','A','X','G','_','A','T','O','M','I','C','R','M','W','_','M','I','N','G','_','A','T','O','M','I','C','R','M','W','_','N','A','N','D','G','_','A','T','O','M','I','C','R','M','W','_','O','R','G','_','A','T','O','M','I','C','R','M','W','_','S','U','B','G','_','A','T','O','M','I','C','R','M','W','_','U','M','A','X','G','_','A','T','O','M','I','C','R','M','W','_','U','M','I','N','G','_','A','T','O','M','I','C','R','M','W','_','X','C','H','G','G','_','A','T','O','M','I','C','R','M','W','_','X','O','R','G','_','A','T','O','M','I','C','_','C','M','P','X','C','H','G','G','_','A','T','O','M','I','C','_','C','M','P','X','C','H','G','_','W','I','T','H','_','S','U','C','C','E','S','S','G','_','B','I','T','C','A','S','T','G','_','B','I','T','R','E','V','E','R','S','E','G','_','B','L','O','C','K','_','A','D','D','R','G','_','B','R','G','_','B','R','C','O','N','D','G','_','B','R','I','N','D','I','R','E','C','T','G','_','B','R','J','T','G','_','B','S','W','A','P','G','_','B','U','I','L','D','_','V','E','C','T','O','R','G','_','B','U','I','L','D','_','V','E','C','T','O','R','_','T','R','U','N','C','G','_','B','Z','E','R','O','G','_','C','O','N','C','A','T','_','V','E','C','T','O','R','S','G','_','C','O','N','S','T','A','N','T','G','_','C','T','L','Z','G','_','C','T','L','Z','_','Z','E','R','O','_','U','N','D','E','F','G','_','C','T','P','O','P','G','_','C','T','T','Z','G','_','C','T','T','Z','_','Z','E','R','O','_','U','N','D','E','F','G','_','D','Y','N','_','S','T','A','C','K','A','L','L','O','C','G','_','E','X','T','R','A','C','T','G','_','E','X','T','R','A','C','T','_','V','E','C','T','O','R','_','E','L','T','G','_','F','A','B','S','G','_','F','A','D','D','G','_','F','C','A','N','O','N','I','C','A','L','I','Z','E','G','_','F','C','E','I','L','G','_','F','C','M','P','G','_','F','C','O','N','S','T','A','N','T','G','_','F','C','O','P','Y','S','I','G','N','G','_','F','C','O','S','G','_','F','D','I','V','G','_','F','E','N','C','E','G','_','F','E','X','P','G','_','F','E','X','P','2','G','_','F','F','L','O','O','R','G','_','F','L','O','G','G','_','F','L','O','G','1','0','G','_','F','L','O','G','2','G','_','F','M','A','G','_','F','M','A','D','G','_','F','M','A','X','I','M','U','M','G','_','F','M','A','X','N','U','M','G','_','F','M','A','X','N','U','M','_','I','E','E','E','G','_','F','M','I','N','I','M','U','M','G','_','F','M','I','N','N','U','M','G','_','F','M','I','N','N','U','M','_','I','E','E','E','G','_','F','M','U','L','G','_','F','N','E','A','R','B','Y','I','N','T','G','_','F','N','E','G','G','_','F','P','E','X','T','G','_','F','P','O','W','G','_','F','P','O','W','I','G','_','F','P','T','O','S','I','G','_','F','P','T','O','U','I','G','_','F','P','T','R','U','N','C','G','_','F','R','A','M','E','_','I','N','D','E','X','G','_','F','R','E','E','Z','E','G','_','F','R','E','M','G','_','F','R','I','N','T','G','_','F','S','H','L','G','_','F','S','H','R','G','_','F','S','I','N','G','_','F','S','Q','R','T','G','_','F','S','U','B','G','_','G','L','O','B','A','L','_','V','A','L','U','E','G','_','I','C','M','P','G','_','I','M','P','L','I','C','I','T','_','D','E','F','G','_','I','N','D','E','X','E','D','_','L','O','A','D','G','_','I','N','D','E','X','E','D','_','S','E','X','T','L','O','A','D','G','_','I','N','D','E','X','E','D','_','S','T','O','R','E','G','_','I','N','D','E','X','E','D','_','Z','E','X','T','L','O','A','D','G','_','I','N','S','E','R','T','G','_','I','N','S','E','R','T','_','V','E','C','T','O','R','_','E','L','T','G','_','I','N','T','R','I','N','S','I','C','G','_','I','N','T','R','I','N','S','I','C','_','L','R','I','N','T','G','_','I','N','T','R','I','N','S','I','C','_','R','O','U','N','D','G','_','I','N','T','R','I','N','S','I','C','_','R','O','U','N','D','E','V','E','N','G','_','I','N','T','R','I','N','S','I','C','_','T','R','U','N','C','G','_','I','N','T','R','I','N','S','I','C','_','W','_','S','I','D','E','_','E','F','F','E','C','T','S','G','_','I','N','T','T','O','P','T','R','G','_','J','U','M','P','_','T','A','B','L','E','G','_','L','O','A','D','G','_','L','S','H','R','G','_','M','E','M','C','P','Y','G','_','M','E','M','C','P','Y','_','I','N','L','I','N','E','G','_','M','E','M','M','O','V','E','G','_','M','E','M','S','E','T','G','_','M','E','R','G','E','_','V','A','L','U','E','S','G','_','M','U','L','G','_','O','R','G','_','P','H','I','G','_','P','T','R','M','A','S','K','G','_','P','T','R','T','O','I','N','T','G','_','P','T','R','_','A','D','D','G','_','R','E','A','D','C','Y','C','L','E','C','O','U','N','T','E','R','G','_','R','E','A','D','_','R','E','G','I','S','T','E','R','G','_','R','O','T','L','G','_','R','O','T','R','G','_','S','A','D','D','E','G','_','S','A','D','D','O','G','_','S','A','D','D','S','A','T','G','_','S','B','F','X','G','_','S','D','I','V','G','_','S','D','I','V','F','I','X','G','_','S','D','I','V','F','I','X','S','A','T','G','_','S','D','I','V','R','E','M','G','_','S','E','L','E','C','T','G','_','S','E','X','T','G','_','S','E','X','T','L','O','A','D','G','_','S','E','X','T','_','I','N','R','E','G','G','_','S','H','L','G','_','S','H','U','F','F','L','E','_','V','E','C','T','O','R','G','_','S','I','T','O','F','P','G','_','S','M','A','X','G','_','S','M','I','N','G','_','S','M','U','L','F','I','X','G','_','S','M','U','L','F','I','X','S','A','T','G','_','S','M','U','L','H','G','_','S','M','U','L','O','G','_','S','R','E','M','G','_','S','S','H','L','S','A','T','G','_','S','S','U','B','E','G','_','S','S','U','B','O','G','_','S','S','U','B','S','A','T','G','_','S','T','O','R','E','G','_','S','T','R','I','C','T','_','F','A','D','D','G','_','S','T','R','I','C','T','_','F','D','I','V','G','_','S','T','R','I','C','T','_','F','M','A','G','_','S','T','R','I','C','T','_','F','M','U','L','G','_','S','T','R','I','C','T','_','F','R','E','M','G','_','S','T','R','I','C','T','_','F','S','Q','R','T','G','_','S','T','R','I','C','T','_','F','S','U','B','G','_','S','U','B','G','_','T','R','U','N','C','G','_','U','A','D','D','E','G','_','U','A','D','D','O','G','_','U','A','D','D','S','A','T','G','_','U','B','F','X','G','_','U','D','I','V','G','_','U','D','I','V','F','I','X','G','_','U','D','I','V','F','I','X','S','A','T','G','_','U','D','I','V','R','E','M','G','_','U','I','T','O','F','P','G','_','U','M','A','X','G','_','U','M','I','N','G','_','U','M','U','L','F','I','X','G','_','U','M','U','L','F','I','X','S','A','T','G','_','U','M','U','L','H','G','_','U','M','U','L','O','G','_','U','N','M','E','R','G','E','_','V','A','L','U','E','S','G','_','U','R','E','M','G','_','U','S','H','L','S','A','T','G','_','U','S','U','B','E','G','_','U','S','U','B','O','G','_','U','S','U','B','S','A','T','G','_','V','A','A','R','G','G','_','V','A','S','T','A','R','T','G','_','V','E','C','R','E','D','U','C','E','_','A','D','D','G','_','V','E','C','R','E','D','U','C','E','_','A','N','D','G','_','V','E','C','R','E','D','U','C','E','_','F','A','D','D','G','_','V','E','C','R','E','D','U','C','E','_','F','M','A','X','G','_','V','E','C','R','E','D','U','C','E','_','F','M','I','N','G','_','V','E','C','R','E','D','U','C','E','_','F','M','U','L','G','_','V','E','C','R','E','D','U','C','E','_','M','U','L','G','_','V','E','C','R','E','D','U','C','E','_','O','R','G','_','V','E','C','R','E','D','U','C','E','_','S','E','Q','_','F','A','D','D','G','_','V','E','C','R','E','D','U','C','E','_','S','E','Q','_','F','M','U','L','G','_','V','E','C','R','E','D','U','C','E','_','S','M','A','X','G','_','V','E','C','R','E','D','U','C','E','_','S','M','I','N','G','_','V','E','C','R','E','D','U','C','E','_','U','M','A','X','G','_','V','E','C','R','E','D','U','C','E','_','U','M','I','N','G','_','V','E','C','R','E','D','U','C','E','_','X','O','R','G','_','W','R','I','T','E','_','R','E','G','I','S','T','E','R','G','_','X','O','R','G','_','Z','E','X','T','G','_','Z','E','X','T','L','O','A','D',};
    }

}
