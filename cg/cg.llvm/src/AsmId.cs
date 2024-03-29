﻿namespace Z0
{
    [SymSource]
    public enum AsmId : ushort
    {
        PHI = 0,

        INLINEASM = 1,

        INLINEASM_BR = 2,

        CFI_INSTRUCTION = 3,

        EH_LABEL = 4,

        GC_LABEL = 5,

        ANNOTATION_LABEL = 6,

        KILL = 7,

        EXTRACT_SUBREG = 8,

        INSERT_SUBREG = 9,

        IMPLICIT_DEF = 10,

        SUBREG_TO_REG = 11,

        COPY_TO_REGCLASS = 12,

        DBG_VALUE = 13,

        DBG_VALUE_LIST = 14,

        DBG_INSTR_REF = 15,

        DBG_PHI = 16,

        DBG_LABEL = 17,

        REG_SEQUENCE = 18,

        COPY = 19,

        BUNDLE = 20,

        LIFETIME_START = 21,

        LIFETIME_END = 22,

        PSEUDO_PROBE = 23,

        ARITH_FENCE = 24,

        STACKMAP = 25,

        FENTRY_CALL = 26,

        PATCHPOINT = 27,

        LOAD_STACK_GUARD = 28,

        PREALLOCATED_SETUP = 29,

        PREALLOCATED_ARG = 30,

        STATEPOINT = 31,

        LOCAL_ESCAPE = 32,

        FAULTING_OP = 33,

        PATCHABLE_OP = 34,

        PATCHABLE_FUNCTION_ENTER = 35,

        PATCHABLE_RET = 36,

        PATCHABLE_FUNCTION_EXIT = 37,

        PATCHABLE_TAIL_CALL = 38,

        PATCHABLE_EVENT_CALL = 39,

        PATCHABLE_TYPED_EVENT_CALL = 40,

        ICALL_BRANCH_FUNNEL = 41,

        G_ASSERT_SEXT = 42,

        G_ASSERT_ZEXT = 43,

        G_ASSERT_ALIGN = 44,

        G_ADD = 45,

        G_SUB = 46,

        G_MUL = 47,

        G_SDIV = 48,

        G_UDIV = 49,

        G_SREM = 50,

        G_UREM = 51,

        G_SDIVREM = 52,

        G_UDIVREM = 53,

        G_AND = 54,

        G_OR = 55,

        G_XOR = 56,

        G_IMPLICIT_DEF = 57,

        G_PHI = 58,

        G_FRAME_INDEX = 59,

        G_GLOBAL_VALUE = 60,

        G_EXTRACT = 61,

        G_UNMERGE_VALUES = 62,

        G_INSERT = 63,

        G_MERGE_VALUES = 64,

        G_BUILD_VECTOR = 65,

        G_BUILD_VECTOR_TRUNC = 66,

        G_CONCAT_VECTORS = 67,

        G_PTRTOINT = 68,

        G_INTTOPTR = 69,

        G_BITCAST = 70,

        G_FREEZE = 71,

        G_INTRINSIC_TRUNC = 72,

        G_INTRINSIC_ROUND = 73,

        G_INTRINSIC_LRINT = 74,

        G_INTRINSIC_ROUNDEVEN = 75,

        G_READCYCLECOUNTER = 76,

        G_LOAD = 77,

        G_SEXTLOAD = 78,

        G_ZEXTLOAD = 79,

        G_INDEXED_LOAD = 80,

        G_INDEXED_SEXTLOAD = 81,

        G_INDEXED_ZEXTLOAD = 82,

        G_STORE = 83,

        G_INDEXED_STORE = 84,

        G_ATOMIC_CMPXCHG_WITH_SUCCESS = 85,

        G_ATOMIC_CMPXCHG = 86,

        G_ATOMICRMW_XCHG = 87,

        G_ATOMICRMW_ADD = 88,

        G_ATOMICRMW_SUB = 89,

        G_ATOMICRMW_AND = 90,

        G_ATOMICRMW_NAND = 91,

        G_ATOMICRMW_OR = 92,

        G_ATOMICRMW_XOR = 93,

        G_ATOMICRMW_MAX = 94,

        G_ATOMICRMW_MIN = 95,

        G_ATOMICRMW_UMAX = 96,

        G_ATOMICRMW_UMIN = 97,

        G_ATOMICRMW_FADD = 98,

        G_ATOMICRMW_FSUB = 99,

        G_FENCE = 100,

        G_BRCOND = 101,

        G_BRINDIRECT = 102,

        G_INTRINSIC = 103,

        G_INTRINSIC_W_SIDE_EFFECTS = 104,

        G_ANYEXT = 105,

        G_TRUNC = 106,

        G_CONSTANT = 107,

        G_FCONSTANT = 108,

        G_VASTART = 109,

        G_VAARG = 110,

        G_SEXT = 111,

        G_SEXT_INREG = 112,

        G_ZEXT = 113,

        G_SHL = 114,

        G_LSHR = 115,

        G_ASHR = 116,

        G_FSHL = 117,

        G_FSHR = 118,

        G_ROTR = 119,

        G_ROTL = 120,

        G_ICMP = 121,

        G_FCMP = 122,

        G_SELECT = 123,

        G_UADDO = 124,

        G_UADDE = 125,

        G_USUBO = 126,

        G_USUBE = 127,

        G_SADDO = 128,

        G_SADDE = 129,

        G_SSUBO = 130,

        G_SSUBE = 131,

        G_UMULO = 132,

        G_SMULO = 133,

        G_UMULH = 134,

        G_SMULH = 135,

        G_UADDSAT = 136,

        G_SADDSAT = 137,

        G_USUBSAT = 138,

        G_SSUBSAT = 139,

        G_USHLSAT = 140,

        G_SSHLSAT = 141,

        G_SMULFIX = 142,

        G_UMULFIX = 143,

        G_SMULFIXSAT = 144,

        G_UMULFIXSAT = 145,

        G_SDIVFIX = 146,

        G_UDIVFIX = 147,

        G_SDIVFIXSAT = 148,

        G_UDIVFIXSAT = 149,

        G_FADD = 150,

        G_FSUB = 151,

        G_FMUL = 152,

        G_FMA = 153,

        G_FMAD = 154,

        G_FDIV = 155,

        G_FREM = 156,

        G_FPOW = 157,

        G_FPOWI = 158,

        G_FEXP = 159,

        G_FEXP2 = 160,

        G_FLOG = 161,

        G_FLOG2 = 162,

        G_FLOG10 = 163,

        G_FNEG = 164,

        G_FPEXT = 165,

        G_FPTRUNC = 166,

        G_FPTOSI = 167,

        G_FPTOUI = 168,

        G_SITOFP = 169,

        G_UITOFP = 170,

        G_FABS = 171,

        G_FCOPYSIGN = 172,

        G_FCANONICALIZE = 173,

        G_FMINNUM = 174,

        G_FMAXNUM = 175,

        G_FMINNUM_IEEE = 176,

        G_FMAXNUM_IEEE = 177,

        G_FMINIMUM = 178,

        G_FMAXIMUM = 179,

        G_PTR_ADD = 180,

        G_PTRMASK = 181,

        G_SMIN = 182,

        G_SMAX = 183,

        G_UMIN = 184,

        G_UMAX = 185,

        G_ABS = 186,

        G_LROUND = 187,

        G_LLROUND = 188,

        G_BR = 189,

        G_BRJT = 190,

        G_INSERT_VECTOR_ELT = 191,

        G_EXTRACT_VECTOR_ELT = 192,

        G_SHUFFLE_VECTOR = 193,

        G_CTTZ = 194,

        G_CTTZ_ZERO_UNDEF = 195,

        G_CTLZ = 196,

        G_CTLZ_ZERO_UNDEF = 197,

        G_CTPOP = 198,

        G_BSWAP = 199,

        G_BITREVERSE = 200,

        G_FCEIL = 201,

        G_FCOS = 202,

        G_FSIN = 203,

        G_FSQRT = 204,

        G_FFLOOR = 205,

        G_FRINT = 206,

        G_FNEARBYINT = 207,

        G_ADDRSPACE_CAST = 208,

        G_BLOCK_ADDR = 209,

        G_JUMP_TABLE = 210,

        G_DYN_STACKALLOC = 211,

        G_STRICT_FADD = 212,

        G_STRICT_FSUB = 213,

        G_STRICT_FMUL = 214,

        G_STRICT_FDIV = 215,

        G_STRICT_FREM = 216,

        G_STRICT_FMA = 217,

        G_STRICT_FSQRT = 218,

        G_READ_REGISTER = 219,

        G_WRITE_REGISTER = 220,

        G_MEMCPY = 221,

        G_MEMCPY_INLINE = 222,

        G_MEMMOVE = 223,

        G_MEMSET = 224,

        G_BZERO = 225,

        G_VECREDUCE_SEQ_FADD = 226,

        G_VECREDUCE_SEQ_FMUL = 227,

        G_VECREDUCE_FADD = 228,

        G_VECREDUCE_FMUL = 229,

        G_VECREDUCE_FMAX = 230,

        G_VECREDUCE_FMIN = 231,

        G_VECREDUCE_ADD = 232,

        G_VECREDUCE_MUL = 233,

        G_VECREDUCE_AND = 234,

        G_VECREDUCE_OR = 235,

        G_VECREDUCE_XOR = 236,

        G_VECREDUCE_SMAX = 237,

        G_VECREDUCE_SMIN = 238,

        G_VECREDUCE_UMAX = 239,

        G_VECREDUCE_UMIN = 240,

        G_SBFX = 241,

        G_UBFX = 242,

        ADD16ri8_DB = 243,

        ADD16ri_DB = 244,

        ADD16rr_DB = 245,

        ADD32ri8_DB = 246,

        ADD32ri_DB = 247,

        ADD32rr_DB = 248,

        ADD64ri32_DB = 249,

        ADD64ri8_DB = 250,

        ADD64rr_DB = 251,

        ADD8ri_DB = 252,

        ADD8rr_DB = 253,

        AVX1_SETALLONES = 254,

        AVX2_SETALLONES = 255,

        AVX512_128_SET0 = 256,

        AVX512_256_SET0 = 257,

        AVX512_512_SET0 = 258,

        AVX512_512_SETALLONES = 259,

        AVX512_512_SEXT_MASK_32 = 260,

        AVX512_512_SEXT_MASK_64 = 261,

        AVX512_FsFLD0F128 = 262,

        AVX512_FsFLD0SD = 263,

        AVX512_FsFLD0SH = 264,

        AVX512_FsFLD0SS = 265,

        AVX_SET0 = 266,

        CALL64m_RVMARKER = 267,

        CALL64pcrel32_RVMARKER = 268,

        CALL64r_RVMARKER = 269,

        FsFLD0F128 = 270,

        FsFLD0SD = 271,

        FsFLD0SS = 272,

        INDIRECT_THUNK_CALL32 = 273,

        INDIRECT_THUNK_CALL64 = 274,

        INDIRECT_THUNK_TCRETURN32 = 275,

        INDIRECT_THUNK_TCRETURN64 = 276,

        KSET0D = 277,

        KSET0Q = 278,

        KSET0W = 279,

        KSET1D = 280,

        KSET1Q = 281,

        KSET1W = 282,

        LCMPXCHG16B_NO_RBX = 283,

        LCMPXCHG16B_SAVE_RBX = 284,

        MMX_SET0 = 285,

        MORESTACK_RET = 286,

        MORESTACK_RET_RESTORE_R10 = 287,

        MOV32ImmSExti8 = 288,

        MOV32r0 = 289,

        MOV32r1 = 290,

        MOV32r_1 = 291,

        MOV32ri64 = 292,

        MOV64ImmSExti8 = 293,

        MWAITX = 294,

        MWAITX_SAVE_RBX = 295,

        SEH_EndPrologue = 296,

        SEH_Epilogue = 297,

        SEH_PushFrame = 298,

        SEH_PushReg = 299,

        SEH_SaveReg = 300,

        SEH_SaveXMM = 301,

        SEH_SetFrame = 302,

        SEH_StackAlign = 303,

        SEH_StackAlloc = 304,

        SETB_C32r = 305,

        SETB_C64r = 306,

        SHLDROT32ri = 307,

        SHLDROT64ri = 308,

        SHRDROT32ri = 309,

        SHRDROT64ri = 310,

        VMOVAPSZ128mr_NOVLX = 311,

        VMOVAPSZ128rm_NOVLX = 312,

        VMOVAPSZ256mr_NOVLX = 313,

        VMOVAPSZ256rm_NOVLX = 314,

        VMOVUPSZ128mr_NOVLX = 315,

        VMOVUPSZ128rm_NOVLX = 316,

        VMOVUPSZ256mr_NOVLX = 317,

        VMOVUPSZ256rm_NOVLX = 318,

        V_SET0 = 319,

        V_SETALLONES = 320,

        XABORT_DEF = 321,

        XOR32_FP = 322,

        XOR64_FP = 323,

        AAA = 324,

        AAD8i8 = 325,

        AAM8i8 = 326,

        AAS = 327,

        ABS_F = 328,

        ABS_Fp32 = 329,

        ABS_Fp64 = 330,

        ABS_Fp80 = 331,

        ADC16i16 = 332,

        ADC16mi = 333,

        ADC16mi8 = 334,

        ADC16mr = 335,

        ADC16ri = 336,

        ADC16ri8 = 337,

        ADC16rm = 338,

        ADC16rr = 339,

        ADC16rr_REV = 340,

        ADC32i32 = 341,

        ADC32mi = 342,

        ADC32mi8 = 343,

        ADC32mr = 344,

        ADC32ri = 345,

        ADC32ri8 = 346,

        ADC32rm = 347,

        ADC32rr = 348,

        ADC32rr_REV = 349,

        ADC64i32 = 350,

        ADC64mi32 = 351,

        ADC64mi8 = 352,

        ADC64mr = 353,

        ADC64ri32 = 354,

        ADC64ri8 = 355,

        ADC64rm = 356,

        ADC64rr = 357,

        ADC64rr_REV = 358,

        ADC8i8 = 359,

        ADC8mi = 360,

        ADC8mi8 = 361,

        ADC8mr = 362,

        ADC8ri = 363,

        ADC8ri8 = 364,

        ADC8rm = 365,

        ADC8rr = 366,

        ADC8rr_REV = 367,

        ADCX32rm = 368,

        ADCX32rr = 369,

        ADCX64rm = 370,

        ADCX64rr = 371,

        ADD16i16 = 372,

        ADD16mi = 373,

        ADD16mi8 = 374,

        ADD16mr = 375,

        ADD16ri = 376,

        ADD16ri8 = 377,

        ADD16rm = 378,

        ADD16rr = 379,

        ADD16rr_REV = 380,

        ADD32i32 = 381,

        ADD32mi = 382,

        ADD32mi8 = 383,

        ADD32mr = 384,

        ADD32ri = 385,

        ADD32ri8 = 386,

        ADD32rm = 387,

        ADD32rr = 388,

        ADD32rr_REV = 389,

        ADD64i32 = 390,

        ADD64mi32 = 391,

        ADD64mi8 = 392,

        ADD64mr = 393,

        ADD64ri32 = 394,

        ADD64ri8 = 395,

        ADD64rm = 396,

        ADD64rr = 397,

        ADD64rr_REV = 398,

        ADD8i8 = 399,

        ADD8mi = 400,

        ADD8mi8 = 401,

        ADD8mr = 402,

        ADD8ri = 403,

        ADD8ri8 = 404,

        ADD8rm = 405,

        ADD8rr = 406,

        ADD8rr_REV = 407,

        ADDPDrm = 408,

        ADDPDrr = 409,

        ADDPSrm = 410,

        ADDPSrr = 411,

        ADDR16_PREFIX = 412,

        ADDR32_PREFIX = 413,

        ADDSDrm = 414,

        ADDSDrm_Int = 415,

        ADDSDrr = 416,

        ADDSDrr_Int = 417,

        ADDSSrm = 418,

        ADDSSrm_Int = 419,

        ADDSSrr = 420,

        ADDSSrr_Int = 421,

        ADDSUBPDrm = 422,

        ADDSUBPDrr = 423,

        ADDSUBPSrm = 424,

        ADDSUBPSrr = 425,

        ADD_F32m = 426,

        ADD_F64m = 427,

        ADD_FI16m = 428,

        ADD_FI32m = 429,

        ADD_FPrST0 = 430,

        ADD_FST0r = 431,

        ADD_Fp32 = 432,

        ADD_Fp32m = 433,

        ADD_Fp64 = 434,

        ADD_Fp64m = 435,

        ADD_Fp64m32 = 436,

        ADD_Fp80 = 437,

        ADD_Fp80m32 = 438,

        ADD_Fp80m64 = 439,

        ADD_FpI16m32 = 440,

        ADD_FpI16m64 = 441,

        ADD_FpI16m80 = 442,

        ADD_FpI32m32 = 443,

        ADD_FpI32m64 = 444,

        ADD_FpI32m80 = 445,

        ADD_FrST0 = 446,

        ADJCALLSTACKDOWN32 = 447,

        ADJCALLSTACKDOWN64 = 448,

        ADJCALLSTACKUP32 = 449,

        ADJCALLSTACKUP64 = 450,

        ADOX32rm = 451,

        ADOX32rr = 452,

        ADOX64rm = 453,

        ADOX64rr = 454,

        AESDEC128KL = 455,

        AESDEC256KL = 456,

        AESDECLASTrm = 457,

        AESDECLASTrr = 458,

        AESDECWIDE128KL = 459,

        AESDECWIDE256KL = 460,

        AESDECrm = 461,

        AESDECrr = 462,

        AESENC128KL = 463,

        AESENC256KL = 464,

        AESENCLASTrm = 465,

        AESENCLASTrr = 466,

        AESENCWIDE128KL = 467,

        AESENCWIDE256KL = 468,

        AESENCrm = 469,

        AESENCrr = 470,

        AESIMCrm = 471,

        AESIMCrr = 472,

        AESKEYGENASSIST128rm = 473,

        AESKEYGENASSIST128rr = 474,

        AND16i16 = 475,

        AND16mi = 476,

        AND16mi8 = 477,

        AND16mr = 478,

        AND16ri = 479,

        AND16ri8 = 480,

        AND16rm = 481,

        AND16rr = 482,

        AND16rr_REV = 483,

        AND32i32 = 484,

        AND32mi = 485,

        AND32mi8 = 486,

        AND32mr = 487,

        AND32ri = 488,

        AND32ri8 = 489,

        AND32rm = 490,

        AND32rr = 491,

        AND32rr_REV = 492,

        AND64i32 = 493,

        AND64mi32 = 494,

        AND64mi8 = 495,

        AND64mr = 496,

        AND64ri32 = 497,

        AND64ri8 = 498,

        AND64rm = 499,

        AND64rr = 500,

        AND64rr_REV = 501,

        AND8i8 = 502,

        AND8mi = 503,

        AND8mi8 = 504,

        AND8mr = 505,

        AND8ri = 506,

        AND8ri8 = 507,

        AND8rm = 508,

        AND8rr = 509,

        AND8rr_REV = 510,

        ANDN32rm = 511,

        ANDN32rr = 512,

        ANDN64rm = 513,

        ANDN64rr = 514,

        ANDNPDrm = 515,

        ANDNPDrr = 516,

        ANDNPSrm = 517,

        ANDNPSrr = 518,

        ANDPDrm = 519,

        ANDPDrr = 520,

        ANDPSrm = 521,

        ANDPSrr = 522,

        ARPL16mr = 523,

        ARPL16rr = 524,

        ASAN_CHECK_MEMACCESS = 525,

        BEXTR32rm = 526,

        BEXTR32rr = 527,

        BEXTR64rm = 528,

        BEXTR64rr = 529,

        BEXTRI32mi = 530,

        BEXTRI32ri = 531,

        BEXTRI64mi = 532,

        BEXTRI64ri = 533,

        BLCFILL32rm = 534,

        BLCFILL32rr = 535,

        BLCFILL64rm = 536,

        BLCFILL64rr = 537,

        BLCI32rm = 538,

        BLCI32rr = 539,

        BLCI64rm = 540,

        BLCI64rr = 541,

        BLCIC32rm = 542,

        BLCIC32rr = 543,

        BLCIC64rm = 544,

        BLCIC64rr = 545,

        BLCMSK32rm = 546,

        BLCMSK32rr = 547,

        BLCMSK64rm = 548,

        BLCMSK64rr = 549,

        BLCS32rm = 550,

        BLCS32rr = 551,

        BLCS64rm = 552,

        BLCS64rr = 553,

        BLENDPDrmi = 554,

        BLENDPDrri = 555,

        BLENDPSrmi = 556,

        BLENDPSrri = 557,

        BLENDVPDrm0 = 558,

        BLENDVPDrr0 = 559,

        BLENDVPSrm0 = 560,

        BLENDVPSrr0 = 561,

        BLSFILL32rm = 562,

        BLSFILL32rr = 563,

        BLSFILL64rm = 564,

        BLSFILL64rr = 565,

        BLSI32rm = 566,

        BLSI32rr = 567,

        BLSI64rm = 568,

        BLSI64rr = 569,

        BLSIC32rm = 570,

        BLSIC32rr = 571,

        BLSIC64rm = 572,

        BLSIC64rr = 573,

        BLSMSK32rm = 574,

        BLSMSK32rr = 575,

        BLSMSK64rm = 576,

        BLSMSK64rr = 577,

        BLSR32rm = 578,

        BLSR32rr = 579,

        BLSR64rm = 580,

        BLSR64rr = 581,

        BOUNDS16rm = 582,

        BOUNDS32rm = 583,

        BSF16rm = 584,

        BSF16rr = 585,

        BSF32rm = 586,

        BSF32rr = 587,

        BSF64rm = 588,

        BSF64rr = 589,

        BSR16rm = 590,

        BSR16rr = 591,

        BSR32rm = 592,

        BSR32rr = 593,

        BSR64rm = 594,

        BSR64rr = 595,

        BSWAP16r_BAD = 596,

        BSWAP32r = 597,

        BSWAP64r = 598,

        BT16mi8 = 599,

        BT16mr = 600,

        BT16ri8 = 601,

        BT16rr = 602,

        BT32mi8 = 603,

        BT32mr = 604,

        BT32ri8 = 605,

        BT32rr = 606,

        BT64mi8 = 607,

        BT64mr = 608,

        BT64ri8 = 609,

        BT64rr = 610,

        BTC16mi8 = 611,

        BTC16mr = 612,

        BTC16ri8 = 613,

        BTC16rr = 614,

        BTC32mi8 = 615,

        BTC32mr = 616,

        BTC32ri8 = 617,

        BTC32rr = 618,

        BTC64mi8 = 619,

        BTC64mr = 620,

        BTC64ri8 = 621,

        BTC64rr = 622,

        BTR16mi8 = 623,

        BTR16mr = 624,

        BTR16ri8 = 625,

        BTR16rr = 626,

        BTR32mi8 = 627,

        BTR32mr = 628,

        BTR32ri8 = 629,

        BTR32rr = 630,

        BTR64mi8 = 631,

        BTR64mr = 632,

        BTR64ri8 = 633,

        BTR64rr = 634,

        BTS16mi8 = 635,

        BTS16mr = 636,

        BTS16ri8 = 637,

        BTS16rr = 638,

        BTS32mi8 = 639,

        BTS32mr = 640,

        BTS32ri8 = 641,

        BTS32rr = 642,

        BTS64mi8 = 643,

        BTS64mr = 644,

        BTS64ri8 = 645,

        BTS64rr = 646,

        BZHI32rm = 647,

        BZHI32rr = 648,

        BZHI64rm = 649,

        BZHI64rr = 650,

        CALL16m = 651,

        CALL16m_NT = 652,

        CALL16r = 653,

        CALL16r_NT = 654,

        CALL32m = 655,

        CALL32m_NT = 656,

        CALL32r = 657,

        CALL32r_NT = 658,

        CALL64m = 659,

        CALL64m_NT = 660,

        CALL64pcrel32 = 661,

        CALL64r = 662,

        CALL64r_NT = 663,

        CALLpcrel16 = 664,

        CALLpcrel32 = 665,

        CATCHRET = 666,

        CBW = 667,

        CDQ = 668,

        CDQE = 669,

        CHS_F = 670,

        CHS_Fp32 = 671,

        CHS_Fp64 = 672,

        CHS_Fp80 = 673,

        CLAC = 674,

        CLC = 675,

        CLD = 676,

        CLDEMOTE = 677,

        CLEANUPRET = 678,

        CLFLUSH = 679,

        CLFLUSHOPT = 680,

        CLGI = 681,

        CLI = 682,

        CLRSSBSY = 683,

        CLTS = 684,

        CLUI = 685,

        CLWB = 686,

        CLZERO32r = 687,

        CLZERO64r = 688,

        CMC = 689,

        CMOV16rm = 690,

        CMOV16rr = 691,

        CMOV32rm = 692,

        CMOV32rr = 693,

        CMOV64rm = 694,

        CMOV64rr = 695,

        CMOVBE_F = 696,

        CMOVBE_Fp32 = 697,

        CMOVBE_Fp64 = 698,

        CMOVBE_Fp80 = 699,

        CMOVB_F = 700,

        CMOVB_Fp32 = 701,

        CMOVB_Fp64 = 702,

        CMOVB_Fp80 = 703,

        CMOVE_F = 704,

        CMOVE_Fp32 = 705,

        CMOVE_Fp64 = 706,

        CMOVE_Fp80 = 707,

        CMOVNBE_F = 708,

        CMOVNBE_Fp32 = 709,

        CMOVNBE_Fp64 = 710,

        CMOVNBE_Fp80 = 711,

        CMOVNB_F = 712,

        CMOVNB_Fp32 = 713,

        CMOVNB_Fp64 = 714,

        CMOVNB_Fp80 = 715,

        CMOVNE_F = 716,

        CMOVNE_Fp32 = 717,

        CMOVNE_Fp64 = 718,

        CMOVNE_Fp80 = 719,

        CMOVNP_F = 720,

        CMOVNP_Fp32 = 721,

        CMOVNP_Fp64 = 722,

        CMOVNP_Fp80 = 723,

        CMOVP_F = 724,

        CMOVP_Fp32 = 725,

        CMOVP_Fp64 = 726,

        CMOVP_Fp80 = 727,

        CMOV_FR16X = 728,

        CMOV_FR32 = 729,

        CMOV_FR32X = 730,

        CMOV_FR64 = 731,

        CMOV_FR64X = 732,

        CMOV_GR16 = 733,

        CMOV_GR32 = 734,

        CMOV_GR8 = 735,

        CMOV_RFP32 = 736,

        CMOV_RFP64 = 737,

        CMOV_RFP80 = 738,

        CMOV_VK1 = 739,

        CMOV_VK16 = 740,

        CMOV_VK2 = 741,

        CMOV_VK32 = 742,

        CMOV_VK4 = 743,

        CMOV_VK64 = 744,

        CMOV_VK8 = 745,

        CMOV_VR128 = 746,

        CMOV_VR128X = 747,

        CMOV_VR256 = 748,

        CMOV_VR256X = 749,

        CMOV_VR512 = 750,

        CMOV_VR64 = 751,

        CMP16i16 = 752,

        CMP16mi = 753,

        CMP16mi8 = 754,

        CMP16mr = 755,

        CMP16ri = 756,

        CMP16ri8 = 757,

        CMP16rm = 758,

        CMP16rr = 759,

        CMP16rr_REV = 760,

        CMP32i32 = 761,

        CMP32mi = 762,

        CMP32mi8 = 763,

        CMP32mr = 764,

        CMP32ri = 765,

        CMP32ri8 = 766,

        CMP32rm = 767,

        CMP32rr = 768,

        CMP32rr_REV = 769,

        CMP64i32 = 770,

        CMP64mi32 = 771,

        CMP64mi8 = 772,

        CMP64mr = 773,

        CMP64ri32 = 774,

        CMP64ri8 = 775,

        CMP64rm = 776,

        CMP64rr = 777,

        CMP64rr_REV = 778,

        CMP8i8 = 779,

        CMP8mi = 780,

        CMP8mi8 = 781,

        CMP8mr = 782,

        CMP8ri = 783,

        CMP8ri8 = 784,

        CMP8rm = 785,

        CMP8rr = 786,

        CMP8rr_REV = 787,

        CMPPDrmi = 788,

        CMPPDrri = 789,

        CMPPSrmi = 790,

        CMPPSrri = 791,

        CMPSB = 792,

        CMPSDrm = 793,

        CMPSDrm_Int = 794,

        CMPSDrr = 795,

        CMPSDrr_Int = 796,

        CMPSL = 797,

        CMPSQ = 798,

        CMPSSrm = 799,

        CMPSSrm_Int = 800,

        CMPSSrr = 801,

        CMPSSrr_Int = 802,

        CMPSW = 803,

        CMPXCHG16B = 804,

        CMPXCHG16rm = 805,

        CMPXCHG16rr = 806,

        CMPXCHG32rm = 807,

        CMPXCHG32rr = 808,

        CMPXCHG64rm = 809,

        CMPXCHG64rr = 810,

        CMPXCHG8B = 811,

        CMPXCHG8rm = 812,

        CMPXCHG8rr = 813,

        COMISDrm = 814,

        COMISDrm_Int = 815,

        COMISDrr = 816,

        COMISDrr_Int = 817,

        COMISSrm = 818,

        COMISSrm_Int = 819,

        COMISSrr = 820,

        COMISSrr_Int = 821,

        COMP_FST0r = 822,

        COM_FIPr = 823,

        COM_FIr = 824,

        COM_FST0r = 825,

        COM_FpIr32 = 826,

        COM_FpIr64 = 827,

        COM_FpIr80 = 828,

        COM_Fpr32 = 829,

        COM_Fpr64 = 830,

        COM_Fpr80 = 831,

        CPUID = 832,

        CQO = 833,

        CRC32r32m16 = 834,

        CRC32r32m32 = 835,

        CRC32r32m8 = 836,

        CRC32r32r16 = 837,

        CRC32r32r32 = 838,

        CRC32r32r8 = 839,

        CRC32r64m64 = 840,

        CRC32r64m8 = 841,

        CRC32r64r64 = 842,

        CRC32r64r8 = 843,

        CS_PREFIX = 844,

        CVTDQ2PDrm = 845,

        CVTDQ2PDrr = 846,

        CVTDQ2PSrm = 847,

        CVTDQ2PSrr = 848,

        CVTPD2DQrm = 849,

        CVTPD2DQrr = 850,

        CVTPD2PSrm = 851,

        CVTPD2PSrr = 852,

        CVTPS2DQrm = 853,

        CVTPS2DQrr = 854,

        CVTPS2PDrm = 855,

        CVTPS2PDrr = 856,

        CVTSD2SI64rm = 857,

        CVTSD2SI64rm_Int = 858,

        CVTSD2SI64rr = 859,

        CVTSD2SI64rr_Int = 860,

        CVTSD2SIrm = 861,

        CVTSD2SIrm_Int = 862,

        CVTSD2SIrr = 863,

        CVTSD2SIrr_Int = 864,

        CVTSD2SSrm = 865,

        CVTSD2SSrm_Int = 866,

        CVTSD2SSrr = 867,

        CVTSD2SSrr_Int = 868,

        CVTSI2SDrm = 869,

        CVTSI2SDrm_Int = 870,

        CVTSI2SDrr = 871,

        CVTSI2SDrr_Int = 872,

        CVTSI2SSrm = 873,

        CVTSI2SSrm_Int = 874,

        CVTSI2SSrr = 875,

        CVTSI2SSrr_Int = 876,

        CVTSI642SDrm = 877,

        CVTSI642SDrm_Int = 878,

        CVTSI642SDrr = 879,

        CVTSI642SDrr_Int = 880,

        CVTSI642SSrm = 881,

        CVTSI642SSrm_Int = 882,

        CVTSI642SSrr = 883,

        CVTSI642SSrr_Int = 884,

        CVTSS2SDrm = 885,

        CVTSS2SDrm_Int = 886,

        CVTSS2SDrr = 887,

        CVTSS2SDrr_Int = 888,

        CVTSS2SI64rm = 889,

        CVTSS2SI64rm_Int = 890,

        CVTSS2SI64rr = 891,

        CVTSS2SI64rr_Int = 892,

        CVTSS2SIrm = 893,

        CVTSS2SIrm_Int = 894,

        CVTSS2SIrr = 895,

        CVTSS2SIrr_Int = 896,

        CVTTPD2DQrm = 897,

        CVTTPD2DQrr = 898,

        CVTTPS2DQrm = 899,

        CVTTPS2DQrr = 900,

        CVTTSD2SI64rm = 901,

        CVTTSD2SI64rm_Int = 902,

        CVTTSD2SI64rr = 903,

        CVTTSD2SI64rr_Int = 904,

        CVTTSD2SIrm = 905,

        CVTTSD2SIrm_Int = 906,

        CVTTSD2SIrr = 907,

        CVTTSD2SIrr_Int = 908,

        CVTTSS2SI64rm = 909,

        CVTTSS2SI64rm_Int = 910,

        CVTTSS2SI64rr = 911,

        CVTTSS2SI64rr_Int = 912,

        CVTTSS2SIrm = 913,

        CVTTSS2SIrm_Int = 914,

        CVTTSS2SIrr = 915,

        CVTTSS2SIrr_Int = 916,

        CWD = 917,

        CWDE = 918,

        DAA = 919,

        DAS = 920,

        DATA16_PREFIX = 921,

        DEC16m = 922,

        DEC16r = 923,

        DEC16r_alt = 924,

        DEC32m = 925,

        DEC32r = 926,

        DEC32r_alt = 927,

        DEC64m = 928,

        DEC64r = 929,

        DEC8m = 930,

        DEC8r = 931,

        DIV16m = 932,

        DIV16r = 933,

        DIV32m = 934,

        DIV32r = 935,

        DIV64m = 936,

        DIV64r = 937,

        DIV8m = 938,

        DIV8r = 939,

        DIVPDrm = 940,

        DIVPDrr = 941,

        DIVPSrm = 942,

        DIVPSrr = 943,

        DIVR_F32m = 944,

        DIVR_F64m = 945,

        DIVR_FI16m = 946,

        DIVR_FI32m = 947,

        DIVR_FPrST0 = 948,

        DIVR_FST0r = 949,

        DIVR_Fp32m = 950,

        DIVR_Fp64m = 951,

        DIVR_Fp64m32 = 952,

        DIVR_Fp80m32 = 953,

        DIVR_Fp80m64 = 954,

        DIVR_FpI16m32 = 955,

        DIVR_FpI16m64 = 956,

        DIVR_FpI16m80 = 957,

        DIVR_FpI32m32 = 958,

        DIVR_FpI32m64 = 959,

        DIVR_FpI32m80 = 960,

        DIVR_FrST0 = 961,

        DIVSDrm = 962,

        DIVSDrm_Int = 963,

        DIVSDrr = 964,

        DIVSDrr_Int = 965,

        DIVSSrm = 966,

        DIVSSrm_Int = 967,

        DIVSSrr = 968,

        DIVSSrr_Int = 969,

        DIV_F32m = 970,

        DIV_F64m = 971,

        DIV_FI16m = 972,

        DIV_FI32m = 973,

        DIV_FPrST0 = 974,

        DIV_FST0r = 975,

        DIV_Fp32 = 976,

        DIV_Fp32m = 977,

        DIV_Fp64 = 978,

        DIV_Fp64m = 979,

        DIV_Fp64m32 = 980,

        DIV_Fp80 = 981,

        DIV_Fp80m32 = 982,

        DIV_Fp80m64 = 983,

        DIV_FpI16m32 = 984,

        DIV_FpI16m64 = 985,

        DIV_FpI16m80 = 986,

        DIV_FpI32m32 = 987,

        DIV_FpI32m64 = 988,

        DIV_FpI32m80 = 989,

        DIV_FrST0 = 990,

        DPPDrmi = 991,

        DPPDrri = 992,

        DPPSrmi = 993,

        DPPSrri = 994,

        DS_PREFIX = 995,

        DYN_ALLOCA_32 = 996,

        DYN_ALLOCA_64 = 997,

        EH_RETURN = 998,

        EH_RETURN64 = 999,

        EH_SjLj_LongJmp32 = 1000,

        EH_SjLj_LongJmp64 = 1001,

        EH_SjLj_SetJmp32 = 1002,

        EH_SjLj_SetJmp64 = 1003,

        EH_SjLj_Setup = 1004,

        ENCLS = 1005,

        ENCLU = 1006,

        ENCLV = 1007,

        ENCODEKEY128 = 1008,

        ENCODEKEY256 = 1009,

        ENDBR32 = 1010,

        ENDBR64 = 1011,

        ENQCMD16 = 1012,

        ENQCMD32 = 1013,

        ENQCMD64 = 1014,

        ENQCMDS16 = 1015,

        ENQCMDS32 = 1016,

        ENQCMDS64 = 1017,

        ENTER = 1018,

        ES_PREFIX = 1019,

        EXTRACTPSmr = 1020,

        EXTRACTPSrr = 1021,

        EXTRQ = 1022,

        EXTRQI = 1023,

        F2XM1 = 1024,

        FARCALL16i = 1025,

        FARCALL16m = 1026,

        FARCALL32i = 1027,

        FARCALL32m = 1028,

        FARCALL64m = 1029,

        FARJMP16i = 1030,

        FARJMP16m = 1031,

        FARJMP32i = 1032,

        FARJMP32m = 1033,

        FARJMP64m = 1034,

        FBLDm = 1035,

        FBSTPm = 1036,

        FCOM32m = 1037,

        FCOM64m = 1038,

        FCOMP32m = 1039,

        FCOMP64m = 1040,

        FCOMPP = 1041,

        FCOS = 1042,

        FDECSTP = 1043,

        FEMMS = 1044,

        FFREE = 1045,

        FFREEP = 1046,

        FICOM16m = 1047,

        FICOM32m = 1048,

        FICOMP16m = 1049,

        FICOMP32m = 1050,

        FINCSTP = 1051,

        FLDCW16m = 1052,

        FLDENVm = 1053,

        FLDL2E = 1054,

        FLDL2T = 1055,

        FLDLG2 = 1056,

        FLDLN2 = 1057,

        FLDPI = 1058,

        FNCLEX = 1059,

        FNINIT = 1060,

        FNOP = 1061,

        FNSTCW16m = 1062,

        FNSTSW16r = 1063,

        FNSTSWm = 1064,

        FP32_TO_INT16_IN_MEM = 1065,

        FP32_TO_INT32_IN_MEM = 1066,

        FP32_TO_INT64_IN_MEM = 1067,

        FP64_TO_INT16_IN_MEM = 1068,

        FP64_TO_INT32_IN_MEM = 1069,

        FP64_TO_INT64_IN_MEM = 1070,

        FP80_TO_INT16_IN_MEM = 1071,

        FP80_TO_INT32_IN_MEM = 1072,

        FP80_TO_INT64_IN_MEM = 1073,

        FPATAN = 1074,

        FPREM = 1075,

        FPREM1 = 1076,

        FPTAN = 1077,

        FRNDINT = 1078,

        FRSTORm = 1079,

        FSAVEm = 1080,

        FSCALE = 1081,

        FSIN = 1082,

        FSINCOS = 1083,

        FSTENVm = 1084,

        FS_PREFIX = 1085,

        FXRSTOR = 1086,

        FXRSTOR64 = 1087,

        FXSAVE = 1088,

        FXSAVE64 = 1089,

        FXTRACT = 1090,

        FYL2X = 1091,

        FYL2XP1 = 1092,

        GETSEC = 1093,

        GF2P8AFFINEINVQBrmi = 1094,

        GF2P8AFFINEINVQBrri = 1095,

        GF2P8AFFINEQBrmi = 1096,

        GF2P8AFFINEQBrri = 1097,

        GF2P8MULBrm = 1098,

        GF2P8MULBrr = 1099,

        GS_PREFIX = 1100,

        HADDPDrm = 1101,

        HADDPDrr = 1102,

        HADDPSrm = 1103,

        HADDPSrr = 1104,

        HLT = 1105,

        HRESET = 1106,

        HSUBPDrm = 1107,

        HSUBPDrr = 1108,

        HSUBPSrm = 1109,

        HSUBPSrr = 1110,

        IDIV16m = 1111,

        IDIV16r = 1112,

        IDIV32m = 1113,

        IDIV32r = 1114,

        IDIV64m = 1115,

        IDIV64r = 1116,

        IDIV8m = 1117,

        IDIV8r = 1118,

        ILD_F16m = 1119,

        ILD_F32m = 1120,

        ILD_F64m = 1121,

        ILD_Fp16m32 = 1122,

        ILD_Fp16m64 = 1123,

        ILD_Fp16m80 = 1124,

        ILD_Fp32m32 = 1125,

        ILD_Fp32m64 = 1126,

        ILD_Fp32m80 = 1127,

        ILD_Fp64m32 = 1128,

        ILD_Fp64m64 = 1129,

        ILD_Fp64m80 = 1130,

        IMUL16m = 1131,

        IMUL16r = 1132,

        IMUL16rm = 1133,

        IMUL16rmi = 1134,

        IMUL16rmi8 = 1135,

        IMUL16rr = 1136,

        IMUL16rri = 1137,

        IMUL16rri8 = 1138,

        IMUL32m = 1139,

        IMUL32r = 1140,

        IMUL32rm = 1141,

        IMUL32rmi = 1142,

        IMUL32rmi8 = 1143,

        IMUL32rr = 1144,

        IMUL32rri = 1145,

        IMUL32rri8 = 1146,

        IMUL64m = 1147,

        IMUL64r = 1148,

        IMUL64rm = 1149,

        IMUL64rmi32 = 1150,

        IMUL64rmi8 = 1151,

        IMUL64rr = 1152,

        IMUL64rri32 = 1153,

        IMUL64rri8 = 1154,

        IMUL8m = 1155,

        IMUL8r = 1156,

        IN16ri = 1157,

        IN16rr = 1158,

        IN32ri = 1159,

        IN32rr = 1160,

        IN8ri = 1161,

        IN8rr = 1162,

        INC16m = 1163,

        INC16r = 1164,

        INC16r_alt = 1165,

        INC32m = 1166,

        INC32r = 1167,

        INC32r_alt = 1168,

        INC64m = 1169,

        INC64r = 1170,

        INC8m = 1171,

        INC8r = 1172,

        INCSSPD = 1173,

        INCSSPQ = 1174,

        INSB = 1175,

        INSERTPSrm = 1176,

        INSERTPSrr = 1177,

        INSERTQ = 1178,

        INSERTQI = 1179,

        INSL = 1180,

        INSW = 1181,

        INT = 1182,

        INT3 = 1183,

        INTO = 1184,

        INVD = 1185,

        INVEPT32 = 1186,

        INVEPT64 = 1187,

        INVLPG = 1188,

        INVLPGA32 = 1189,

        INVLPGA64 = 1190,

        INVLPGB32 = 1191,

        INVLPGB64 = 1192,

        INVPCID32 = 1193,

        INVPCID64 = 1194,

        INVVPID32 = 1195,

        INVVPID64 = 1196,

        IRET = 1197,

        IRET16 = 1198,

        IRET32 = 1199,

        IRET64 = 1200,

        ISTT_FP16m = 1201,

        ISTT_FP32m = 1202,

        ISTT_FP64m = 1203,

        ISTT_Fp16m32 = 1204,

        ISTT_Fp16m64 = 1205,

        ISTT_Fp16m80 = 1206,

        ISTT_Fp32m32 = 1207,

        ISTT_Fp32m64 = 1208,

        ISTT_Fp32m80 = 1209,

        ISTT_Fp64m32 = 1210,

        ISTT_Fp64m64 = 1211,

        ISTT_Fp64m80 = 1212,

        IST_F16m = 1213,

        IST_F32m = 1214,

        IST_FP16m = 1215,

        IST_FP32m = 1216,

        IST_FP64m = 1217,

        IST_Fp16m32 = 1218,

        IST_Fp16m64 = 1219,

        IST_Fp16m80 = 1220,

        IST_Fp32m32 = 1221,

        IST_Fp32m64 = 1222,

        IST_Fp32m80 = 1223,

        IST_Fp64m32 = 1224,

        IST_Fp64m64 = 1225,

        IST_Fp64m80 = 1226,

        Int_MemBarrier = 1227,

        Int_eh_sjlj_setup_dispatch = 1228,

        JCC_1 = 1229,

        JCC_2 = 1230,

        JCC_4 = 1231,

        JCXZ = 1232,

        JECXZ = 1233,

        JMP16m = 1234,

        JMP16m_NT = 1235,

        JMP16r = 1236,

        JMP16r_NT = 1237,

        JMP32m = 1238,

        JMP32m_NT = 1239,

        JMP32r = 1240,

        JMP32r_NT = 1241,

        JMP64m = 1242,

        JMP64m_NT = 1243,

        JMP64m_REX = 1244,

        JMP64r = 1245,

        JMP64r_NT = 1246,

        JMP64r_REX = 1247,

        JMP_1 = 1248,

        JMP_2 = 1249,

        JMP_4 = 1250,

        JRCXZ = 1251,

        KADDBrr = 1252,

        KADDDrr = 1253,

        KADDQrr = 1254,

        KADDWrr = 1255,

        KANDBrr = 1256,

        KANDDrr = 1257,

        KANDNBrr = 1258,

        KANDNDrr = 1259,

        KANDNQrr = 1260,

        KANDNWrr = 1261,

        KANDQrr = 1262,

        KANDWrr = 1263,

        KMOVBkk = 1264,

        KMOVBkm = 1265,

        KMOVBkr = 1266,

        KMOVBmk = 1267,

        KMOVBrk = 1268,

        KMOVDkk = 1269,

        KMOVDkm = 1270,

        KMOVDkr = 1271,

        KMOVDmk = 1272,

        KMOVDrk = 1273,

        KMOVQkk = 1274,

        KMOVQkm = 1275,

        KMOVQkr = 1276,

        KMOVQmk = 1277,

        KMOVQrk = 1278,

        KMOVWkk = 1279,

        KMOVWkm = 1280,

        KMOVWkr = 1281,

        KMOVWmk = 1282,

        KMOVWrk = 1283,

        KNOTBrr = 1284,

        KNOTDrr = 1285,

        KNOTQrr = 1286,

        KNOTWrr = 1287,

        KORBrr = 1288,

        KORDrr = 1289,

        KORQrr = 1290,

        KORTESTBrr = 1291,

        KORTESTDrr = 1292,

        KORTESTQrr = 1293,

        KORTESTWrr = 1294,

        KORWrr = 1295,

        KSHIFTLBri = 1296,

        KSHIFTLDri = 1297,

        KSHIFTLQri = 1298,

        KSHIFTLWri = 1299,

        KSHIFTRBri = 1300,

        KSHIFTRDri = 1301,

        KSHIFTRQri = 1302,

        KSHIFTRWri = 1303,

        KTESTBrr = 1304,

        KTESTDrr = 1305,

        KTESTQrr = 1306,

        KTESTWrr = 1307,

        KUNPCKBWrr = 1308,

        KUNPCKDQrr = 1309,

        KUNPCKWDrr = 1310,

        KXNORBrr = 1311,

        KXNORDrr = 1312,

        KXNORQrr = 1313,

        KXNORWrr = 1314,

        KXORBrr = 1315,

        KXORDrr = 1316,

        KXORQrr = 1317,

        KXORWrr = 1318,

        LAHF = 1319,

        LAR16rm = 1320,

        LAR16rr = 1321,

        LAR32rm = 1322,

        LAR32rr = 1323,

        LAR64rm = 1324,

        LAR64rr = 1325,

        LCMPXCHG16 = 1326,

        LCMPXCHG16B = 1327,

        LCMPXCHG32 = 1328,

        LCMPXCHG64 = 1329,

        LCMPXCHG8 = 1330,

        LCMPXCHG8B = 1331,

        LDDQUrm = 1332,

        LDMXCSR = 1333,

        LDS16rm = 1334,

        LDS32rm = 1335,

        LDTILECFG = 1336,

        LD_F0 = 1337,

        LD_F1 = 1338,

        LD_F32m = 1339,

        LD_F64m = 1340,

        LD_F80m = 1341,

        LD_Fp032 = 1342,

        LD_Fp064 = 1343,

        LD_Fp080 = 1344,

        LD_Fp132 = 1345,

        LD_Fp164 = 1346,

        LD_Fp180 = 1347,

        LD_Fp32m = 1348,

        LD_Fp32m64 = 1349,

        LD_Fp32m80 = 1350,

        LD_Fp64m = 1351,

        LD_Fp64m80 = 1352,

        LD_Fp80m = 1353,

        LD_Frr = 1354,

        LEA16r = 1355,

        LEA32r = 1356,

        LEA64_32r = 1357,

        LEA64r = 1358,

        LEAVE = 1359,

        LEAVE64 = 1360,

        LES16rm = 1361,

        LES32rm = 1362,

        LFENCE = 1363,

        LFS16rm = 1364,

        LFS32rm = 1365,

        LFS64rm = 1366,

        LGDT16m = 1367,

        LGDT32m = 1368,

        LGDT64m = 1369,

        LGS16rm = 1370,

        LGS32rm = 1371,

        LGS64rm = 1372,

        LIDT16m = 1373,

        LIDT32m = 1374,

        LIDT64m = 1375,

        LLDT16m = 1376,

        LLDT16r = 1377,

        LLWPCB = 1378,

        LLWPCB64 = 1379,

        LMSW16m = 1380,

        LMSW16r = 1381,

        LOADIWKEY = 1382,

        LOCK_ADD16mi = 1383,

        LOCK_ADD16mi8 = 1384,

        LOCK_ADD16mr = 1385,

        LOCK_ADD32mi = 1386,

        LOCK_ADD32mi8 = 1387,

        LOCK_ADD32mr = 1388,

        LOCK_ADD64mi32 = 1389,

        LOCK_ADD64mi8 = 1390,

        LOCK_ADD64mr = 1391,

        LOCK_ADD8mi = 1392,

        LOCK_ADD8mr = 1393,

        LOCK_AND16mi = 1394,

        LOCK_AND16mi8 = 1395,

        LOCK_AND16mr = 1396,

        LOCK_AND32mi = 1397,

        LOCK_AND32mi8 = 1398,

        LOCK_AND32mr = 1399,

        LOCK_AND64mi32 = 1400,

        LOCK_AND64mi8 = 1401,

        LOCK_AND64mr = 1402,

        LOCK_AND8mi = 1403,

        LOCK_AND8mr = 1404,

        LOCK_DEC16m = 1405,

        LOCK_DEC32m = 1406,

        LOCK_DEC64m = 1407,

        LOCK_DEC8m = 1408,

        LOCK_INC16m = 1409,

        LOCK_INC32m = 1410,

        LOCK_INC64m = 1411,

        LOCK_INC8m = 1412,

        LOCK_OR16mi = 1413,

        LOCK_OR16mi8 = 1414,

        LOCK_OR16mr = 1415,

        LOCK_OR32mi = 1416,

        LOCK_OR32mi8 = 1417,

        LOCK_OR32mr = 1418,

        LOCK_OR64mi32 = 1419,

        LOCK_OR64mi8 = 1420,

        LOCK_OR64mr = 1421,

        LOCK_OR8mi = 1422,

        LOCK_OR8mr = 1423,

        LOCK_PREFIX = 1424,

        LOCK_SUB16mi = 1425,

        LOCK_SUB16mi8 = 1426,

        LOCK_SUB16mr = 1427,

        LOCK_SUB32mi = 1428,

        LOCK_SUB32mi8 = 1429,

        LOCK_SUB32mr = 1430,

        LOCK_SUB64mi32 = 1431,

        LOCK_SUB64mi8 = 1432,

        LOCK_SUB64mr = 1433,

        LOCK_SUB8mi = 1434,

        LOCK_SUB8mr = 1435,

        LOCK_XOR16mi = 1436,

        LOCK_XOR16mi8 = 1437,

        LOCK_XOR16mr = 1438,

        LOCK_XOR32mi = 1439,

        LOCK_XOR32mi8 = 1440,

        LOCK_XOR32mr = 1441,

        LOCK_XOR64mi32 = 1442,

        LOCK_XOR64mi8 = 1443,

        LOCK_XOR64mr = 1444,

        LOCK_XOR8mi = 1445,

        LOCK_XOR8mr = 1446,

        LODSB = 1447,

        LODSL = 1448,

        LODSQ = 1449,

        LODSW = 1450,

        LOOP = 1451,

        LOOPE = 1452,

        LOOPNE = 1453,

        LRET16 = 1454,

        LRET32 = 1455,

        LRET64 = 1456,

        LRETI16 = 1457,

        LRETI32 = 1458,

        LRETI64 = 1459,

        LSL16rm = 1460,

        LSL16rr = 1461,

        LSL32rm = 1462,

        LSL32rr = 1463,

        LSL64rm = 1464,

        LSL64rr = 1465,

        LSS16rm = 1466,

        LSS32rm = 1467,

        LSS64rm = 1468,

        LTRm = 1469,

        LTRr = 1470,

        LWPINS32rmi = 1471,

        LWPINS32rri = 1472,

        LWPINS64rmi = 1473,

        LWPINS64rri = 1474,

        LWPVAL32rmi = 1475,

        LWPVAL32rri = 1476,

        LWPVAL64rmi = 1477,

        LWPVAL64rri = 1478,

        LXADD16 = 1479,

        LXADD32 = 1480,

        LXADD64 = 1481,

        LXADD8 = 1482,

        LZCNT16rm = 1483,

        LZCNT16rr = 1484,

        LZCNT32rm = 1485,

        LZCNT32rr = 1486,

        LZCNT64rm = 1487,

        LZCNT64rr = 1488,

        MASKMOVDQU = 1489,

        MASKMOVDQU64 = 1490,

        MASKMOVDQUX32 = 1491,

        MASKPAIR16LOAD = 1492,

        MASKPAIR16STORE = 1493,

        MAXCPDrm = 1494,

        MAXCPDrr = 1495,

        MAXCPSrm = 1496,

        MAXCPSrr = 1497,

        MAXCSDrm = 1498,

        MAXCSDrr = 1499,

        MAXCSSrm = 1500,

        MAXCSSrr = 1501,

        MAXPDrm = 1502,

        MAXPDrr = 1503,

        MAXPSrm = 1504,

        MAXPSrr = 1505,

        MAXSDrm = 1506,

        MAXSDrm_Int = 1507,

        MAXSDrr = 1508,

        MAXSDrr_Int = 1509,

        MAXSSrm = 1510,

        MAXSSrm_Int = 1511,

        MAXSSrr = 1512,

        MAXSSrr_Int = 1513,

        MFENCE = 1514,

        MINCPDrm = 1515,

        MINCPDrr = 1516,

        MINCPSrm = 1517,

        MINCPSrr = 1518,

        MINCSDrm = 1519,

        MINCSDrr = 1520,

        MINCSSrm = 1521,

        MINCSSrr = 1522,

        MINPDrm = 1523,

        MINPDrr = 1524,

        MINPSrm = 1525,

        MINPSrr = 1526,

        MINSDrm = 1527,

        MINSDrm_Int = 1528,

        MINSDrr = 1529,

        MINSDrr_Int = 1530,

        MINSSrm = 1531,

        MINSSrm_Int = 1532,

        MINSSrr = 1533,

        MINSSrr_Int = 1534,

        MMX_CVTPD2PIrm = 1535,

        MMX_CVTPD2PIrr = 1536,

        MMX_CVTPI2PDrm = 1537,

        MMX_CVTPI2PDrr = 1538,

        MMX_CVTPI2PSrm = 1539,

        MMX_CVTPI2PSrr = 1540,

        MMX_CVTPS2PIrm = 1541,

        MMX_CVTPS2PIrr = 1542,

        MMX_CVTTPD2PIrm = 1543,

        MMX_CVTTPD2PIrr = 1544,

        MMX_CVTTPS2PIrm = 1545,

        MMX_CVTTPS2PIrr = 1546,

        MMX_EMMS = 1547,

        MMX_MASKMOVQ = 1548,

        MMX_MASKMOVQ64 = 1549,

        MMX_MOVD64from64rm = 1550,

        MMX_MOVD64from64rr = 1551,

        MMX_MOVD64grr = 1552,

        MMX_MOVD64mr = 1553,

        MMX_MOVD64rm = 1554,

        MMX_MOVD64rr = 1555,

        MMX_MOVD64to64rm = 1556,

        MMX_MOVD64to64rr = 1557,

        MMX_MOVDQ2Qrr = 1558,

        MMX_MOVFR642Qrr = 1559,

        MMX_MOVNTQmr = 1560,

        MMX_MOVQ2DQrr = 1561,

        MMX_MOVQ2FR64rr = 1562,

        MMX_MOVQ64mr = 1563,

        MMX_MOVQ64rm = 1564,

        MMX_MOVQ64rr = 1565,

        MMX_MOVQ64rr_REV = 1566,

        MMX_PABSBrm = 1567,

        MMX_PABSBrr = 1568,

        MMX_PABSDrm = 1569,

        MMX_PABSDrr = 1570,

        MMX_PABSWrm = 1571,

        MMX_PABSWrr = 1572,

        MMX_PACKSSDWrm = 1573,

        MMX_PACKSSDWrr = 1574,

        MMX_PACKSSWBrm = 1575,

        MMX_PACKSSWBrr = 1576,

        MMX_PACKUSWBrm = 1577,

        MMX_PACKUSWBrr = 1578,

        MMX_PADDBrm = 1579,

        MMX_PADDBrr = 1580,

        MMX_PADDDrm = 1581,

        MMX_PADDDrr = 1582,

        MMX_PADDQrm = 1583,

        MMX_PADDQrr = 1584,

        MMX_PADDSBrm = 1585,

        MMX_PADDSBrr = 1586,

        MMX_PADDSWrm = 1587,

        MMX_PADDSWrr = 1588,

        MMX_PADDUSBrm = 1589,

        MMX_PADDUSBrr = 1590,

        MMX_PADDUSWrm = 1591,

        MMX_PADDUSWrr = 1592,

        MMX_PADDWrm = 1593,

        MMX_PADDWrr = 1594,

        MMX_PALIGNRrmi = 1595,

        MMX_PALIGNRrri = 1596,

        MMX_PANDNrm = 1597,

        MMX_PANDNrr = 1598,

        MMX_PANDrm = 1599,

        MMX_PANDrr = 1600,

        MMX_PAVGBrm = 1601,

        MMX_PAVGBrr = 1602,

        MMX_PAVGWrm = 1603,

        MMX_PAVGWrr = 1604,

        MMX_PCMPEQBrm = 1605,

        MMX_PCMPEQBrr = 1606,

        MMX_PCMPEQDrm = 1607,

        MMX_PCMPEQDrr = 1608,

        MMX_PCMPEQWrm = 1609,

        MMX_PCMPEQWrr = 1610,

        MMX_PCMPGTBrm = 1611,

        MMX_PCMPGTBrr = 1612,

        MMX_PCMPGTDrm = 1613,

        MMX_PCMPGTDrr = 1614,

        MMX_PCMPGTWrm = 1615,

        MMX_PCMPGTWrr = 1616,

        MMX_PEXTRWrr = 1617,

        MMX_PHADDDrm = 1618,

        MMX_PHADDDrr = 1619,

        MMX_PHADDSWrm = 1620,

        MMX_PHADDSWrr = 1621,

        MMX_PHADDWrm = 1622,

        MMX_PHADDWrr = 1623,

        MMX_PHSUBDrm = 1624,

        MMX_PHSUBDrr = 1625,

        MMX_PHSUBSWrm = 1626,

        MMX_PHSUBSWrr = 1627,

        MMX_PHSUBWrm = 1628,

        MMX_PHSUBWrr = 1629,

        MMX_PINSRWrm = 1630,

        MMX_PINSRWrr = 1631,

        MMX_PMADDUBSWrm = 1632,

        MMX_PMADDUBSWrr = 1633,

        MMX_PMADDWDrm = 1634,

        MMX_PMADDWDrr = 1635,

        MMX_PMAXSWrm = 1636,

        MMX_PMAXSWrr = 1637,

        MMX_PMAXUBrm = 1638,

        MMX_PMAXUBrr = 1639,

        MMX_PMINSWrm = 1640,

        MMX_PMINSWrr = 1641,

        MMX_PMINUBrm = 1642,

        MMX_PMINUBrr = 1643,

        MMX_PMOVMSKBrr = 1644,

        MMX_PMULHRSWrm = 1645,

        MMX_PMULHRSWrr = 1646,

        MMX_PMULHUWrm = 1647,

        MMX_PMULHUWrr = 1648,

        MMX_PMULHWrm = 1649,

        MMX_PMULHWrr = 1650,

        MMX_PMULLWrm = 1651,

        MMX_PMULLWrr = 1652,

        MMX_PMULUDQrm = 1653,

        MMX_PMULUDQrr = 1654,

        MMX_PORrm = 1655,

        MMX_PORrr = 1656,

        MMX_PSADBWrm = 1657,

        MMX_PSADBWrr = 1658,

        MMX_PSHUFBrm = 1659,

        MMX_PSHUFBrr = 1660,

        MMX_PSHUFWmi = 1661,

        MMX_PSHUFWri = 1662,

        MMX_PSIGNBrm = 1663,

        MMX_PSIGNBrr = 1664,

        MMX_PSIGNDrm = 1665,

        MMX_PSIGNDrr = 1666,

        MMX_PSIGNWrm = 1667,

        MMX_PSIGNWrr = 1668,

        MMX_PSLLDri = 1669,

        MMX_PSLLDrm = 1670,

        MMX_PSLLDrr = 1671,

        MMX_PSLLQri = 1672,

        MMX_PSLLQrm = 1673,

        MMX_PSLLQrr = 1674,

        MMX_PSLLWri = 1675,

        MMX_PSLLWrm = 1676,

        MMX_PSLLWrr = 1677,

        MMX_PSRADri = 1678,

        MMX_PSRADrm = 1679,

        MMX_PSRADrr = 1680,

        MMX_PSRAWri = 1681,

        MMX_PSRAWrm = 1682,

        MMX_PSRAWrr = 1683,

        MMX_PSRLDri = 1684,

        MMX_PSRLDrm = 1685,

        MMX_PSRLDrr = 1686,

        MMX_PSRLQri = 1687,

        MMX_PSRLQrm = 1688,

        MMX_PSRLQrr = 1689,

        MMX_PSRLWri = 1690,

        MMX_PSRLWrm = 1691,

        MMX_PSRLWrr = 1692,

        MMX_PSUBBrm = 1693,

        MMX_PSUBBrr = 1694,

        MMX_PSUBDrm = 1695,

        MMX_PSUBDrr = 1696,

        MMX_PSUBQrm = 1697,

        MMX_PSUBQrr = 1698,

        MMX_PSUBSBrm = 1699,

        MMX_PSUBSBrr = 1700,

        MMX_PSUBSWrm = 1701,

        MMX_PSUBSWrr = 1702,

        MMX_PSUBUSBrm = 1703,

        MMX_PSUBUSBrr = 1704,

        MMX_PSUBUSWrm = 1705,

        MMX_PSUBUSWrr = 1706,

        MMX_PSUBWrm = 1707,

        MMX_PSUBWrr = 1708,

        MMX_PUNPCKHBWrm = 1709,

        MMX_PUNPCKHBWrr = 1710,

        MMX_PUNPCKHDQrm = 1711,

        MMX_PUNPCKHDQrr = 1712,

        MMX_PUNPCKHWDrm = 1713,

        MMX_PUNPCKHWDrr = 1714,

        MMX_PUNPCKLBWrm = 1715,

        MMX_PUNPCKLBWrr = 1716,

        MMX_PUNPCKLDQrm = 1717,

        MMX_PUNPCKLDQrr = 1718,

        MMX_PUNPCKLWDrm = 1719,

        MMX_PUNPCKLWDrr = 1720,

        MMX_PXORrm = 1721,

        MMX_PXORrr = 1722,

        MONITOR32rrr = 1723,

        MONITOR64rrr = 1724,

        MONITORX32rrr = 1725,

        MONITORX64rrr = 1726,

        MONTMUL = 1727,

        MOV16ao16 = 1728,

        MOV16ao32 = 1729,

        MOV16ao64 = 1730,

        MOV16mi = 1731,

        MOV16mr = 1732,

        MOV16ms = 1733,

        MOV16o16a = 1734,

        MOV16o32a = 1735,

        MOV16o64a = 1736,

        MOV16ri = 1737,

        MOV16ri_alt = 1738,

        MOV16rm = 1739,

        MOV16rr = 1740,

        MOV16rr_REV = 1741,

        MOV16rs = 1742,

        MOV16sm = 1743,

        MOV16sr = 1744,

        MOV32ao16 = 1745,

        MOV32ao32 = 1746,

        MOV32ao64 = 1747,

        MOV32cr = 1748,

        MOV32dr = 1749,

        MOV32mi = 1750,

        MOV32mr = 1751,

        MOV32o16a = 1752,

        MOV32o32a = 1753,

        MOV32o64a = 1754,

        MOV32rc = 1755,

        MOV32rd = 1756,

        MOV32ri = 1757,

        MOV32ri_alt = 1758,

        MOV32rm = 1759,

        MOV32rr = 1760,

        MOV32rr_REV = 1761,

        MOV32rs = 1762,

        MOV32sr = 1763,

        MOV64ao32 = 1764,

        MOV64ao64 = 1765,

        MOV64cr = 1766,

        MOV64dr = 1767,

        MOV64mi32 = 1768,

        MOV64mr = 1769,

        MOV64o32a = 1770,

        MOV64o64a = 1771,

        MOV64rc = 1772,

        MOV64rd = 1773,

        MOV64ri = 1774,

        MOV64ri32 = 1775,

        MOV64rm = 1776,

        MOV64rr = 1777,

        MOV64rr_REV = 1778,

        MOV64rs = 1779,

        MOV64sr = 1780,

        MOV64toPQIrm = 1781,

        MOV64toPQIrr = 1782,

        MOV64toSDrr = 1783,

        MOV8ao16 = 1784,

        MOV8ao32 = 1785,

        MOV8ao64 = 1786,

        MOV8mi = 1787,

        MOV8mr = 1788,

        MOV8mr_NOREX = 1789,

        MOV8o16a = 1790,

        MOV8o32a = 1791,

        MOV8o64a = 1792,

        MOV8ri = 1793,

        MOV8ri_alt = 1794,

        MOV8rm = 1795,

        MOV8rm_NOREX = 1796,

        MOV8rr = 1797,

        MOV8rr_NOREX = 1798,

        MOV8rr_REV = 1799,

        MOVAPDmr = 1800,

        MOVAPDrm = 1801,

        MOVAPDrr = 1802,

        MOVAPDrr_REV = 1803,

        MOVAPSmr = 1804,

        MOVAPSrm = 1805,

        MOVAPSrr = 1806,

        MOVAPSrr_REV = 1807,

        MOVBE16mr = 1808,

        MOVBE16rm = 1809,

        MOVBE32mr = 1810,

        MOVBE32rm = 1811,

        MOVBE64mr = 1812,

        MOVBE64rm = 1813,

        MOVDDUPrm = 1814,

        MOVDDUPrr = 1815,

        MOVDI2PDIrm = 1816,

        MOVDI2PDIrr = 1817,

        MOVDI2SSrr = 1818,

        MOVDIR64B16 = 1819,

        MOVDIR64B32 = 1820,

        MOVDIR64B64 = 1821,

        MOVDIRI32 = 1822,

        MOVDIRI64 = 1823,

        MOVDQAmr = 1824,

        MOVDQArm = 1825,

        MOVDQArr = 1826,

        MOVDQArr_REV = 1827,

        MOVDQUmr = 1828,

        MOVDQUrm = 1829,

        MOVDQUrr = 1830,

        MOVDQUrr_REV = 1831,

        MOVHLPSrr = 1832,

        MOVHPDmr = 1833,

        MOVHPDrm = 1834,

        MOVHPSmr = 1835,

        MOVHPSrm = 1836,

        MOVLHPSrr = 1837,

        MOVLPDmr = 1838,

        MOVLPDrm = 1839,

        MOVLPSmr = 1840,

        MOVLPSrm = 1841,

        MOVMSKPDrr = 1842,

        MOVMSKPSrr = 1843,

        MOVNTDQArm = 1844,

        MOVNTDQmr = 1845,

        MOVNTI_64mr = 1846,

        MOVNTImr = 1847,

        MOVNTPDmr = 1848,

        MOVNTPSmr = 1849,

        MOVNTSD = 1850,

        MOVNTSS = 1851,

        MOVPC32r = 1852,

        MOVPDI2DImr = 1853,

        MOVPDI2DIrr = 1854,

        MOVPQI2QImr = 1855,

        MOVPQI2QIrr = 1856,

        MOVPQIto64mr = 1857,

        MOVPQIto64rr = 1858,

        MOVQI2PQIrm = 1859,

        MOVSB = 1860,

        MOVSDmr = 1861,

        MOVSDrm = 1862,

        MOVSDrm_alt = 1863,

        MOVSDrr = 1864,

        MOVSDrr_REV = 1865,

        MOVSDto64rr = 1866,

        MOVSHDUPrm = 1867,

        MOVSHDUPrr = 1868,

        MOVSL = 1869,

        MOVSLDUPrm = 1870,

        MOVSLDUPrr = 1871,

        MOVSQ = 1872,

        MOVSS2DIrr = 1873,

        MOVSSmr = 1874,

        MOVSSrm = 1875,

        MOVSSrm_alt = 1876,

        MOVSSrr = 1877,

        MOVSSrr_REV = 1878,

        MOVSW = 1879,

        MOVSX16rm16 = 1880,

        MOVSX16rm32 = 1881,

        MOVSX16rm8 = 1882,

        MOVSX16rr16 = 1883,

        MOVSX16rr32 = 1884,

        MOVSX16rr8 = 1885,

        MOVSX32rm16 = 1886,

        MOVSX32rm32 = 1887,

        MOVSX32rm8 = 1888,

        MOVSX32rm8_NOREX = 1889,

        MOVSX32rr16 = 1890,

        MOVSX32rr32 = 1891,

        MOVSX32rr8 = 1892,

        MOVSX32rr8_NOREX = 1893,

        MOVSX64rm16 = 1894,

        MOVSX64rm32 = 1895,

        MOVSX64rm8 = 1896,

        MOVSX64rr16 = 1897,

        MOVSX64rr32 = 1898,

        MOVSX64rr8 = 1899,

        MOVUPDmr = 1900,

        MOVUPDrm = 1901,

        MOVUPDrr = 1902,

        MOVUPDrr_REV = 1903,

        MOVUPSmr = 1904,

        MOVUPSrm = 1905,

        MOVUPSrr = 1906,

        MOVUPSrr_REV = 1907,

        MOVZPQILo2PQIrr = 1908,

        MOVZX16rm16 = 1909,

        MOVZX16rm8 = 1910,

        MOVZX16rr16 = 1911,

        MOVZX16rr8 = 1912,

        MOVZX32rm16 = 1913,

        MOVZX32rm8 = 1914,

        MOVZX32rm8_NOREX = 1915,

        MOVZX32rr16 = 1916,

        MOVZX32rr8 = 1917,

        MOVZX32rr8_NOREX = 1918,

        MOVZX64rm16 = 1919,

        MOVZX64rm8 = 1920,

        MOVZX64rr16 = 1921,

        MOVZX64rr8 = 1922,

        MPSADBWrmi = 1923,

        MPSADBWrri = 1924,

        MUL16m = 1925,

        MUL16r = 1926,

        MUL32m = 1927,

        MUL32r = 1928,

        MUL64m = 1929,

        MUL64r = 1930,

        MUL8m = 1931,

        MUL8r = 1932,

        MULPDrm = 1933,

        MULPDrr = 1934,

        MULPSrm = 1935,

        MULPSrr = 1936,

        MULSDrm = 1937,

        MULSDrm_Int = 1938,

        MULSDrr = 1939,

        MULSDrr_Int = 1940,

        MULSSrm = 1941,

        MULSSrm_Int = 1942,

        MULSSrr = 1943,

        MULSSrr_Int = 1944,

        MULX32Hrm = 1945,

        MULX32Hrr = 1946,

        MULX32rm = 1947,

        MULX32rr = 1948,

        MULX64Hrm = 1949,

        MULX64Hrr = 1950,

        MULX64rm = 1951,

        MULX64rr = 1952,

        MUL_F32m = 1953,

        MUL_F64m = 1954,

        MUL_FI16m = 1955,

        MUL_FI32m = 1956,

        MUL_FPrST0 = 1957,

        MUL_FST0r = 1958,

        MUL_Fp32 = 1959,

        MUL_Fp32m = 1960,

        MUL_Fp64 = 1961,

        MUL_Fp64m = 1962,

        MUL_Fp64m32 = 1963,

        MUL_Fp80 = 1964,

        MUL_Fp80m32 = 1965,

        MUL_Fp80m64 = 1966,

        MUL_FpI16m32 = 1967,

        MUL_FpI16m64 = 1968,

        MUL_FpI16m80 = 1969,

        MUL_FpI32m32 = 1970,

        MUL_FpI32m64 = 1971,

        MUL_FpI32m80 = 1972,

        MUL_FrST0 = 1973,

        MWAITXrrr = 1974,

        MWAITrr = 1975,

        NEG16m = 1976,

        NEG16r = 1977,

        NEG32m = 1978,

        NEG32r = 1979,

        NEG64m = 1980,

        NEG64r = 1981,

        NEG8m = 1982,

        NEG8r = 1983,

        NOOP = 1984,

        NOOPL = 1985,

        NOOPLr = 1986,

        NOOPQ = 1987,

        NOOPQr = 1988,

        NOOPW = 1989,

        NOOPWr = 1990,

        NOT16m = 1991,

        NOT16r = 1992,

        NOT32m = 1993,

        NOT32r = 1994,

        NOT64m = 1995,

        NOT64r = 1996,

        NOT8m = 1997,

        NOT8r = 1998,

        OR16i16 = 1999,

        OR16mi = 2000,

        OR16mi8 = 2001,

        OR16mr = 2002,

        OR16ri = 2003,

        OR16ri8 = 2004,

        OR16rm = 2005,

        OR16rr = 2006,

        OR16rr_REV = 2007,

        OR32i32 = 2008,

        OR32mi = 2009,

        OR32mi8 = 2010,

        OR32mi8Locked = 2011,

        OR32mr = 2012,

        OR32ri = 2013,

        OR32ri8 = 2014,

        OR32rm = 2015,

        OR32rr = 2016,

        OR32rr_REV = 2017,

        OR64i32 = 2018,

        OR64mi32 = 2019,

        OR64mi8 = 2020,

        OR64mr = 2021,

        OR64ri32 = 2022,

        OR64ri8 = 2023,

        OR64rm = 2024,

        OR64rr = 2025,

        OR64rr_REV = 2026,

        OR8i8 = 2027,

        OR8mi = 2028,

        OR8mi8 = 2029,

        OR8mr = 2030,

        OR8ri = 2031,

        OR8ri8 = 2032,

        OR8rm = 2033,

        OR8rr = 2034,

        OR8rr_REV = 2035,

        ORPDrm = 2036,

        ORPDrr = 2037,

        ORPSrm = 2038,

        ORPSrr = 2039,

        OUT16ir = 2040,

        OUT16rr = 2041,

        OUT32ir = 2042,

        OUT32rr = 2043,

        OUT8ir = 2044,

        OUT8rr = 2045,

        OUTSB = 2046,

        OUTSL = 2047,

        OUTSW = 2048,

        PABSBrm = 2049,

        PABSBrr = 2050,

        PABSDrm = 2051,

        PABSDrr = 2052,

        PABSWrm = 2053,

        PABSWrr = 2054,

        PACKSSDWrm = 2055,

        PACKSSDWrr = 2056,

        PACKSSWBrm = 2057,

        PACKSSWBrr = 2058,

        PACKUSDWrm = 2059,

        PACKUSDWrr = 2060,

        PACKUSWBrm = 2061,

        PACKUSWBrr = 2062,

        PADDBrm = 2063,

        PADDBrr = 2064,

        PADDDrm = 2065,

        PADDDrr = 2066,

        PADDQrm = 2067,

        PADDQrr = 2068,

        PADDSBrm = 2069,

        PADDSBrr = 2070,

        PADDSWrm = 2071,

        PADDSWrr = 2072,

        PADDUSBrm = 2073,

        PADDUSBrr = 2074,

        PADDUSWrm = 2075,

        PADDUSWrr = 2076,

        PADDWrm = 2077,

        PADDWrr = 2078,

        PALIGNRrmi = 2079,

        PALIGNRrri = 2080,

        PANDNrm = 2081,

        PANDNrr = 2082,

        PANDrm = 2083,

        PANDrr = 2084,

        PAUSE = 2085,

        PAVGBrm = 2086,

        PAVGBrr = 2087,

        PAVGUSBrm = 2088,

        PAVGUSBrr = 2089,

        PAVGWrm = 2090,

        PAVGWrr = 2091,

        PBLENDVBrm0 = 2092,

        PBLENDVBrr0 = 2093,

        PBLENDWrmi = 2094,

        PBLENDWrri = 2095,

        PCLMULQDQrm = 2096,

        PCLMULQDQrr = 2097,

        PCMPEQBrm = 2098,

        PCMPEQBrr = 2099,

        PCMPEQDrm = 2100,

        PCMPEQDrr = 2101,

        PCMPEQQrm = 2102,

        PCMPEQQrr = 2103,

        PCMPEQWrm = 2104,

        PCMPEQWrr = 2105,

        PCMPESTRIrm = 2106,

        PCMPESTRIrr = 2107,

        PCMPESTRMrm = 2108,

        PCMPESTRMrr = 2109,

        PCMPGTBrm = 2110,

        PCMPGTBrr = 2111,

        PCMPGTDrm = 2112,

        PCMPGTDrr = 2113,

        PCMPGTQrm = 2114,

        PCMPGTQrr = 2115,

        PCMPGTWrm = 2116,

        PCMPGTWrr = 2117,

        PCMPISTRIrm = 2118,

        PCMPISTRIrr = 2119,

        PCMPISTRMrm = 2120,

        PCMPISTRMrr = 2121,

        PCONFIG = 2122,

        PDEP32rm = 2123,

        PDEP32rr = 2124,

        PDEP64rm = 2125,

        PDEP64rr = 2126,

        PEXT32rm = 2127,

        PEXT32rr = 2128,

        PEXT64rm = 2129,

        PEXT64rr = 2130,

        PEXTRBmr = 2131,

        PEXTRBrr = 2132,

        PEXTRDmr = 2133,

        PEXTRDrr = 2134,

        PEXTRQmr = 2135,

        PEXTRQrr = 2136,

        PEXTRWmr = 2137,

        PEXTRWrr = 2138,

        PEXTRWrr_REV = 2139,

        PF2IDrm = 2140,

        PF2IDrr = 2141,

        PF2IWrm = 2142,

        PF2IWrr = 2143,

        PFACCrm = 2144,

        PFACCrr = 2145,

        PFADDrm = 2146,

        PFADDrr = 2147,

        PFCMPEQrm = 2148,

        PFCMPEQrr = 2149,

        PFCMPGErm = 2150,

        PFCMPGErr = 2151,

        PFCMPGTrm = 2152,

        PFCMPGTrr = 2153,

        PFMAXrm = 2154,

        PFMAXrr = 2155,

        PFMINrm = 2156,

        PFMINrr = 2157,

        PFMULrm = 2158,

        PFMULrr = 2159,

        PFNACCrm = 2160,

        PFNACCrr = 2161,

        PFPNACCrm = 2162,

        PFPNACCrr = 2163,

        PFRCPIT1rm = 2164,

        PFRCPIT1rr = 2165,

        PFRCPIT2rm = 2166,

        PFRCPIT2rr = 2167,

        PFRCPrm = 2168,

        PFRCPrr = 2169,

        PFRSQIT1rm = 2170,

        PFRSQIT1rr = 2171,

        PFRSQRTrm = 2172,

        PFRSQRTrr = 2173,

        PFSUBRrm = 2174,

        PFSUBRrr = 2175,

        PFSUBrm = 2176,

        PFSUBrr = 2177,

        PHADDDrm = 2178,

        PHADDDrr = 2179,

        PHADDSWrm = 2180,

        PHADDSWrr = 2181,

        PHADDWrm = 2182,

        PHADDWrr = 2183,

        PHMINPOSUWrm = 2184,

        PHMINPOSUWrr = 2185,

        PHSUBDrm = 2186,

        PHSUBDrr = 2187,

        PHSUBSWrm = 2188,

        PHSUBSWrr = 2189,

        PHSUBWrm = 2190,

        PHSUBWrr = 2191,

        PI2FDrm = 2192,

        PI2FDrr = 2193,

        PI2FWrm = 2194,

        PI2FWrr = 2195,

        PINSRBrm = 2196,

        PINSRBrr = 2197,

        PINSRDrm = 2198,

        PINSRDrr = 2199,

        PINSRQrm = 2200,

        PINSRQrr = 2201,

        PINSRWrm = 2202,

        PINSRWrr = 2203,

        PLDTILECFGV = 2204,

        PMADDUBSWrm = 2205,

        PMADDUBSWrr = 2206,

        PMADDWDrm = 2207,

        PMADDWDrr = 2208,

        PMAXSBrm = 2209,

        PMAXSBrr = 2210,

        PMAXSDrm = 2211,

        PMAXSDrr = 2212,

        PMAXSWrm = 2213,

        PMAXSWrr = 2214,

        PMAXUBrm = 2215,

        PMAXUBrr = 2216,

        PMAXUDrm = 2217,

        PMAXUDrr = 2218,

        PMAXUWrm = 2219,

        PMAXUWrr = 2220,

        PMINSBrm = 2221,

        PMINSBrr = 2222,

        PMINSDrm = 2223,

        PMINSDrr = 2224,

        PMINSWrm = 2225,

        PMINSWrr = 2226,

        PMINUBrm = 2227,

        PMINUBrr = 2228,

        PMINUDrm = 2229,

        PMINUDrr = 2230,

        PMINUWrm = 2231,

        PMINUWrr = 2232,

        PMOVMSKBrr = 2233,

        PMOVSXBDrm = 2234,

        PMOVSXBDrr = 2235,

        PMOVSXBQrm = 2236,

        PMOVSXBQrr = 2237,

        PMOVSXBWrm = 2238,

        PMOVSXBWrr = 2239,

        PMOVSXDQrm = 2240,

        PMOVSXDQrr = 2241,

        PMOVSXWDrm = 2242,

        PMOVSXWDrr = 2243,

        PMOVSXWQrm = 2244,

        PMOVSXWQrr = 2245,

        PMOVZXBDrm = 2246,

        PMOVZXBDrr = 2247,

        PMOVZXBQrm = 2248,

        PMOVZXBQrr = 2249,

        PMOVZXBWrm = 2250,

        PMOVZXBWrr = 2251,

        PMOVZXDQrm = 2252,

        PMOVZXDQrr = 2253,

        PMOVZXWDrm = 2254,

        PMOVZXWDrr = 2255,

        PMOVZXWQrm = 2256,

        PMOVZXWQrr = 2257,

        PMULDQrm = 2258,

        PMULDQrr = 2259,

        PMULHRSWrm = 2260,

        PMULHRSWrr = 2261,

        PMULHRWrm = 2262,

        PMULHRWrr = 2263,

        PMULHUWrm = 2264,

        PMULHUWrr = 2265,

        PMULHWrm = 2266,

        PMULHWrr = 2267,

        PMULLDrm = 2268,

        PMULLDrr = 2269,

        PMULLWrm = 2270,

        PMULLWrr = 2271,

        PMULUDQrm = 2272,

        PMULUDQrr = 2273,

        POP16r = 2274,

        POP16rmm = 2275,

        POP16rmr = 2276,

        POP32r = 2277,

        POP32rmm = 2278,

        POP32rmr = 2279,

        POP64r = 2280,

        POP64rmm = 2281,

        POP64rmr = 2282,

        POPA16 = 2283,

        POPA32 = 2284,

        POPCNT16rm = 2285,

        POPCNT16rr = 2286,

        POPCNT32rm = 2287,

        POPCNT32rr = 2288,

        POPCNT64rm = 2289,

        POPCNT64rr = 2290,

        POPDS16 = 2291,

        POPDS32 = 2292,

        POPES16 = 2293,

        POPES32 = 2294,

        POPF16 = 2295,

        POPF32 = 2296,

        POPF64 = 2297,

        POPFS16 = 2298,

        POPFS32 = 2299,

        POPFS64 = 2300,

        POPGS16 = 2301,

        POPGS32 = 2302,

        POPGS64 = 2303,

        POPSS16 = 2304,

        POPSS32 = 2305,

        PORrm = 2306,

        PORrr = 2307,

        PREFETCH = 2308,

        PREFETCHNTA = 2309,

        PREFETCHT0 = 2310,

        PREFETCHT1 = 2311,

        PREFETCHT2 = 2312,

        PREFETCHW = 2313,

        PREFETCHWT1 = 2314,

        PROBED_ALLOCA_32 = 2315,

        PROBED_ALLOCA_64 = 2316,

        PSADBWrm = 2317,

        PSADBWrr = 2318,

        PSHUFBrm = 2319,

        PSHUFBrr = 2320,

        PSHUFDmi = 2321,

        PSHUFDri = 2322,

        PSHUFHWmi = 2323,

        PSHUFHWri = 2324,

        PSHUFLWmi = 2325,

        PSHUFLWri = 2326,

        PSIGNBrm = 2327,

        PSIGNBrr = 2328,

        PSIGNDrm = 2329,

        PSIGNDrr = 2330,

        PSIGNWrm = 2331,

        PSIGNWrr = 2332,

        PSLLDQri = 2333,

        PSLLDri = 2334,

        PSLLDrm = 2335,

        PSLLDrr = 2336,

        PSLLQri = 2337,

        PSLLQrm = 2338,

        PSLLQrr = 2339,

        PSLLWri = 2340,

        PSLLWrm = 2341,

        PSLLWrr = 2342,

        PSMASH = 2343,

        PSRADri = 2344,

        PSRADrm = 2345,

        PSRADrr = 2346,

        PSRAWri = 2347,

        PSRAWrm = 2348,

        PSRAWrr = 2349,

        PSRLDQri = 2350,

        PSRLDri = 2351,

        PSRLDrm = 2352,

        PSRLDrr = 2353,

        PSRLQri = 2354,

        PSRLQrm = 2355,

        PSRLQrr = 2356,

        PSRLWri = 2357,

        PSRLWrm = 2358,

        PSRLWrr = 2359,

        PSUBBrm = 2360,

        PSUBBrr = 2361,

        PSUBDrm = 2362,

        PSUBDrr = 2363,

        PSUBQrm = 2364,

        PSUBQrr = 2365,

        PSUBSBrm = 2366,

        PSUBSBrr = 2367,

        PSUBSWrm = 2368,

        PSUBSWrr = 2369,

        PSUBUSBrm = 2370,

        PSUBUSBrr = 2371,

        PSUBUSWrm = 2372,

        PSUBUSWrr = 2373,

        PSUBWrm = 2374,

        PSUBWrr = 2375,

        PSWAPDrm = 2376,

        PSWAPDrr = 2377,

        PTDPBF16PS = 2378,

        PTDPBF16PSV = 2379,

        PTDPBSSD = 2380,

        PTDPBSSDV = 2381,

        PTDPBSUD = 2382,

        PTDPBSUDV = 2383,

        PTDPBUSD = 2384,

        PTDPBUSDV = 2385,

        PTDPBUUD = 2386,

        PTDPBUUDV = 2387,

        PTESTrm = 2388,

        PTESTrr = 2389,

        PTILELOADD = 2390,

        PTILELOADDT1 = 2391,

        PTILELOADDT1V = 2392,

        PTILELOADDV = 2393,

        PTILESTORED = 2394,

        PTILESTOREDV = 2395,

        PTILEZERO = 2396,

        PTILEZEROV = 2397,

        PTWRITE64m = 2398,

        PTWRITE64r = 2399,

        PTWRITEm = 2400,

        PTWRITEr = 2401,

        PUNPCKHBWrm = 2402,

        PUNPCKHBWrr = 2403,

        PUNPCKHDQrm = 2404,

        PUNPCKHDQrr = 2405,

        PUNPCKHQDQrm = 2406,

        PUNPCKHQDQrr = 2407,

        PUNPCKHWDrm = 2408,

        PUNPCKHWDrr = 2409,

        PUNPCKLBWrm = 2410,

        PUNPCKLBWrr = 2411,

        PUNPCKLDQrm = 2412,

        PUNPCKLDQrr = 2413,

        PUNPCKLQDQrm = 2414,

        PUNPCKLQDQrr = 2415,

        PUNPCKLWDrm = 2416,

        PUNPCKLWDrr = 2417,

        PUSH16i8 = 2418,

        PUSH16r = 2419,

        PUSH16rmm = 2420,

        PUSH16rmr = 2421,

        PUSH32i8 = 2422,

        PUSH32r = 2423,

        PUSH32rmm = 2424,

        PUSH32rmr = 2425,

        PUSH64i32 = 2426,

        PUSH64i8 = 2427,

        PUSH64r = 2428,

        PUSH64rmm = 2429,

        PUSH64rmr = 2430,

        PUSHA16 = 2431,

        PUSHA32 = 2432,

        PUSHCS16 = 2433,

        PUSHCS32 = 2434,

        PUSHDS16 = 2435,

        PUSHDS32 = 2436,

        PUSHES16 = 2437,

        PUSHES32 = 2438,

        PUSHF16 = 2439,

        PUSHF32 = 2440,

        PUSHF64 = 2441,

        PUSHFS16 = 2442,

        PUSHFS32 = 2443,

        PUSHFS64 = 2444,

        PUSHGS16 = 2445,

        PUSHGS32 = 2446,

        PUSHGS64 = 2447,

        PUSHSS16 = 2448,

        PUSHSS32 = 2449,

        PUSHi16 = 2450,

        PUSHi32 = 2451,

        PVALIDATE32 = 2452,

        PVALIDATE64 = 2453,

        PXORrm = 2454,

        PXORrr = 2455,

        RCL16m1 = 2456,

        RCL16mCL = 2457,

        RCL16mi = 2458,

        RCL16r1 = 2459,

        RCL16rCL = 2460,

        RCL16ri = 2461,

        RCL32m1 = 2462,

        RCL32mCL = 2463,

        RCL32mi = 2464,

        RCL32r1 = 2465,

        RCL32rCL = 2466,

        RCL32ri = 2467,

        RCL64m1 = 2468,

        RCL64mCL = 2469,

        RCL64mi = 2470,

        RCL64r1 = 2471,

        RCL64rCL = 2472,

        RCL64ri = 2473,

        RCL8m1 = 2474,

        RCL8mCL = 2475,

        RCL8mi = 2476,

        RCL8r1 = 2477,

        RCL8rCL = 2478,

        RCL8ri = 2479,

        RCPPSm = 2480,

        RCPPSr = 2481,

        RCPSSm = 2482,

        RCPSSm_Int = 2483,

        RCPSSr = 2484,

        RCPSSr_Int = 2485,

        RCR16m1 = 2486,

        RCR16mCL = 2487,

        RCR16mi = 2488,

        RCR16r1 = 2489,

        RCR16rCL = 2490,

        RCR16ri = 2491,

        RCR32m1 = 2492,

        RCR32mCL = 2493,

        RCR32mi = 2494,

        RCR32r1 = 2495,

        RCR32rCL = 2496,

        RCR32ri = 2497,

        RCR64m1 = 2498,

        RCR64mCL = 2499,

        RCR64mi = 2500,

        RCR64r1 = 2501,

        RCR64rCL = 2502,

        RCR64ri = 2503,

        RCR8m1 = 2504,

        RCR8mCL = 2505,

        RCR8mi = 2506,

        RCR8r1 = 2507,

        RCR8rCL = 2508,

        RCR8ri = 2509,

        RDFLAGS32 = 2510,

        RDFLAGS64 = 2511,

        RDFSBASE = 2512,

        RDFSBASE64 = 2513,

        RDGSBASE = 2514,

        RDGSBASE64 = 2515,

        RDMSR = 2516,

        RDPID32 = 2517,

        RDPID64 = 2518,

        RDPKRUr = 2519,

        RDPMC = 2520,

        RDRAND16r = 2521,

        RDRAND32r = 2522,

        RDRAND64r = 2523,

        RDSEED16r = 2524,

        RDSEED32r = 2525,

        RDSEED64r = 2526,

        RDSSPD = 2527,

        RDSSPQ = 2528,

        RDTSC = 2529,

        RDTSCP = 2530,

        REPNE_PREFIX = 2531,

        REP_MOVSB_32 = 2532,

        REP_MOVSB_64 = 2533,

        REP_MOVSD_32 = 2534,

        REP_MOVSD_64 = 2535,

        REP_MOVSQ_32 = 2536,

        REP_MOVSQ_64 = 2537,

        REP_MOVSW_32 = 2538,

        REP_MOVSW_64 = 2539,

        REP_PREFIX = 2540,

        REP_STOSB_32 = 2541,

        REP_STOSB_64 = 2542,

        REP_STOSD_32 = 2543,

        REP_STOSD_64 = 2544,

        REP_STOSQ_32 = 2545,

        REP_STOSQ_64 = 2546,

        REP_STOSW_32 = 2547,

        REP_STOSW_64 = 2548,

        RET = 2549,

        RET16 = 2550,

        RET32 = 2551,

        RET64 = 2552,

        RETI16 = 2553,

        RETI32 = 2554,

        RETI64 = 2555,

        REX64_PREFIX = 2556,

        RMPADJUST = 2557,

        RMPUPDATE = 2558,

        ROL16m1 = 2559,

        ROL16mCL = 2560,

        ROL16mi = 2561,

        ROL16r1 = 2562,

        ROL16rCL = 2563,

        ROL16ri = 2564,

        ROL32m1 = 2565,

        ROL32mCL = 2566,

        ROL32mi = 2567,

        ROL32r1 = 2568,

        ROL32rCL = 2569,

        ROL32ri = 2570,

        ROL64m1 = 2571,

        ROL64mCL = 2572,

        ROL64mi = 2573,

        ROL64r1 = 2574,

        ROL64rCL = 2575,

        ROL64ri = 2576,

        ROL8m1 = 2577,

        ROL8mCL = 2578,

        ROL8mi = 2579,

        ROL8r1 = 2580,

        ROL8rCL = 2581,

        ROL8ri = 2582,

        ROR16m1 = 2583,

        ROR16mCL = 2584,

        ROR16mi = 2585,

        ROR16r1 = 2586,

        ROR16rCL = 2587,

        ROR16ri = 2588,

        ROR32m1 = 2589,

        ROR32mCL = 2590,

        ROR32mi = 2591,

        ROR32r1 = 2592,

        ROR32rCL = 2593,

        ROR32ri = 2594,

        ROR64m1 = 2595,

        ROR64mCL = 2596,

        ROR64mi = 2597,

        ROR64r1 = 2598,

        ROR64rCL = 2599,

        ROR64ri = 2600,

        ROR8m1 = 2601,

        ROR8mCL = 2602,

        ROR8mi = 2603,

        ROR8r1 = 2604,

        ROR8rCL = 2605,

        ROR8ri = 2606,

        RORX32mi = 2607,

        RORX32ri = 2608,

        RORX64mi = 2609,

        RORX64ri = 2610,

        ROUNDPDm = 2611,

        ROUNDPDr = 2612,

        ROUNDPSm = 2613,

        ROUNDPSr = 2614,

        ROUNDSDm = 2615,

        ROUNDSDm_Int = 2616,

        ROUNDSDr = 2617,

        ROUNDSDr_Int = 2618,

        ROUNDSSm = 2619,

        ROUNDSSm_Int = 2620,

        ROUNDSSr = 2621,

        ROUNDSSr_Int = 2622,

        RSM = 2623,

        RSQRTPSm = 2624,

        RSQRTPSr = 2625,

        RSQRTSSm = 2626,

        RSQRTSSm_Int = 2627,

        RSQRTSSr = 2628,

        RSQRTSSr_Int = 2629,

        RSTORSSP = 2630,

        SAHF = 2631,

        SALC = 2632,

        SAR16m1 = 2633,

        SAR16mCL = 2634,

        SAR16mi = 2635,

        SAR16r1 = 2636,

        SAR16rCL = 2637,

        SAR16ri = 2638,

        SAR32m1 = 2639,

        SAR32mCL = 2640,

        SAR32mi = 2641,

        SAR32r1 = 2642,

        SAR32rCL = 2643,

        SAR32ri = 2644,

        SAR64m1 = 2645,

        SAR64mCL = 2646,

        SAR64mi = 2647,

        SAR64r1 = 2648,

        SAR64rCL = 2649,

        SAR64ri = 2650,

        SAR8m1 = 2651,

        SAR8mCL = 2652,

        SAR8mi = 2653,

        SAR8r1 = 2654,

        SAR8rCL = 2655,

        SAR8ri = 2656,

        SARX32rm = 2657,

        SARX32rr = 2658,

        SARX64rm = 2659,

        SARX64rr = 2660,

        SAVEPREVSSP = 2661,

        SBB16i16 = 2662,

        SBB16mi = 2663,

        SBB16mi8 = 2664,

        SBB16mr = 2665,

        SBB16ri = 2666,

        SBB16ri8 = 2667,

        SBB16rm = 2668,

        SBB16rr = 2669,

        SBB16rr_REV = 2670,

        SBB32i32 = 2671,

        SBB32mi = 2672,

        SBB32mi8 = 2673,

        SBB32mr = 2674,

        SBB32ri = 2675,

        SBB32ri8 = 2676,

        SBB32rm = 2677,

        SBB32rr = 2678,

        SBB32rr_REV = 2679,

        SBB64i32 = 2680,

        SBB64mi32 = 2681,

        SBB64mi8 = 2682,

        SBB64mr = 2683,

        SBB64ri32 = 2684,

        SBB64ri8 = 2685,

        SBB64rm = 2686,

        SBB64rr = 2687,

        SBB64rr_REV = 2688,

        SBB8i8 = 2689,

        SBB8mi = 2690,

        SBB8mi8 = 2691,

        SBB8mr = 2692,

        SBB8ri = 2693,

        SBB8ri8 = 2694,

        SBB8rm = 2695,

        SBB8rr = 2696,

        SBB8rr_REV = 2697,

        SCASB = 2698,

        SCASL = 2699,

        SCASQ = 2700,

        SCASW = 2701,

        SEAMCALL = 2702,

        SEAMOPS = 2703,

        SEAMRET = 2704,

        SEG_ALLOCA_32 = 2705,

        SEG_ALLOCA_64 = 2706,

        SENDUIPI = 2707,

        SERIALIZE = 2708,

        SETCCm = 2709,

        SETCCr = 2710,

        SETSSBSY = 2711,

        SFENCE = 2712,

        SGDT16m = 2713,

        SGDT32m = 2714,

        SGDT64m = 2715,

        SHA1MSG1rm = 2716,

        SHA1MSG1rr = 2717,

        SHA1MSG2rm = 2718,

        SHA1MSG2rr = 2719,

        SHA1NEXTErm = 2720,

        SHA1NEXTErr = 2721,

        SHA1RNDS4rmi = 2722,

        SHA1RNDS4rri = 2723,

        SHA256MSG1rm = 2724,

        SHA256MSG1rr = 2725,

        SHA256MSG2rm = 2726,

        SHA256MSG2rr = 2727,

        SHA256RNDS2rm = 2728,

        SHA256RNDS2rr = 2729,

        SHL16m1 = 2730,

        SHL16mCL = 2731,

        SHL16mi = 2732,

        SHL16r1 = 2733,

        SHL16rCL = 2734,

        SHL16ri = 2735,

        SHL32m1 = 2736,

        SHL32mCL = 2737,

        SHL32mi = 2738,

        SHL32r1 = 2739,

        SHL32rCL = 2740,

        SHL32ri = 2741,

        SHL64m1 = 2742,

        SHL64mCL = 2743,

        SHL64mi = 2744,

        SHL64r1 = 2745,

        SHL64rCL = 2746,

        SHL64ri = 2747,

        SHL8m1 = 2748,

        SHL8mCL = 2749,

        SHL8mi = 2750,

        SHL8r1 = 2751,

        SHL8rCL = 2752,

        SHL8ri = 2753,

        SHLD16mrCL = 2754,

        SHLD16mri8 = 2755,

        SHLD16rrCL = 2756,

        SHLD16rri8 = 2757,

        SHLD32mrCL = 2758,

        SHLD32mri8 = 2759,

        SHLD32rrCL = 2760,

        SHLD32rri8 = 2761,

        SHLD64mrCL = 2762,

        SHLD64mri8 = 2763,

        SHLD64rrCL = 2764,

        SHLD64rri8 = 2765,

        SHLX32rm = 2766,

        SHLX32rr = 2767,

        SHLX64rm = 2768,

        SHLX64rr = 2769,

        SHR16m1 = 2770,

        SHR16mCL = 2771,

        SHR16mi = 2772,

        SHR16r1 = 2773,

        SHR16rCL = 2774,

        SHR16ri = 2775,

        SHR32m1 = 2776,

        SHR32mCL = 2777,

        SHR32mi = 2778,

        SHR32r1 = 2779,

        SHR32rCL = 2780,

        SHR32ri = 2781,

        SHR64m1 = 2782,

        SHR64mCL = 2783,

        SHR64mi = 2784,

        SHR64r1 = 2785,

        SHR64rCL = 2786,

        SHR64ri = 2787,

        SHR8m1 = 2788,

        SHR8mCL = 2789,

        SHR8mi = 2790,

        SHR8r1 = 2791,

        SHR8rCL = 2792,

        SHR8ri = 2793,

        SHRD16mrCL = 2794,

        SHRD16mri8 = 2795,

        SHRD16rrCL = 2796,

        SHRD16rri8 = 2797,

        SHRD32mrCL = 2798,

        SHRD32mri8 = 2799,

        SHRD32rrCL = 2800,

        SHRD32rri8 = 2801,

        SHRD64mrCL = 2802,

        SHRD64mri8 = 2803,

        SHRD64rrCL = 2804,

        SHRD64rri8 = 2805,

        SHRX32rm = 2806,

        SHRX32rr = 2807,

        SHRX64rm = 2808,

        SHRX64rr = 2809,

        SHUFPDrmi = 2810,

        SHUFPDrri = 2811,

        SHUFPSrmi = 2812,

        SHUFPSrri = 2813,

        SIDT16m = 2814,

        SIDT32m = 2815,

        SIDT64m = 2816,

        SKINIT = 2817,

        SLDT16m = 2818,

        SLDT16r = 2819,

        SLDT32r = 2820,

        SLDT64r = 2821,

        SLWPCB = 2822,

        SLWPCB64 = 2823,

        SMSW16m = 2824,

        SMSW16r = 2825,

        SMSW32r = 2826,

        SMSW64r = 2827,

        SQRTPDm = 2828,

        SQRTPDr = 2829,

        SQRTPSm = 2830,

        SQRTPSr = 2831,

        SQRTSDm = 2832,

        SQRTSDm_Int = 2833,

        SQRTSDr = 2834,

        SQRTSDr_Int = 2835,

        SQRTSSm = 2836,

        SQRTSSm_Int = 2837,

        SQRTSSr = 2838,

        SQRTSSr_Int = 2839,

        SQRT_F = 2840,

        SQRT_Fp32 = 2841,

        SQRT_Fp64 = 2842,

        SQRT_Fp80 = 2843,

        SS_PREFIX = 2844,

        STAC = 2845,

        STACKALLOC_W_PROBING = 2846,

        STC = 2847,

        STD = 2848,

        STGI = 2849,

        STI = 2850,

        STMXCSR = 2851,

        STOSB = 2852,

        STOSL = 2853,

        STOSQ = 2854,

        STOSW = 2855,

        STR16r = 2856,

        STR32r = 2857,

        STR64r = 2858,

        STRm = 2859,

        STTILECFG = 2860,

        STUI = 2861,

        ST_F32m = 2862,

        ST_F64m = 2863,

        ST_FP32m = 2864,

        ST_FP64m = 2865,

        ST_FP80m = 2866,

        ST_FPrr = 2867,

        ST_Fp32m = 2868,

        ST_Fp64m = 2869,

        ST_Fp64m32 = 2870,

        ST_Fp80m32 = 2871,

        ST_Fp80m64 = 2872,

        ST_FpP32m = 2873,

        ST_FpP64m = 2874,

        ST_FpP64m32 = 2875,

        ST_FpP80m = 2876,

        ST_FpP80m32 = 2877,

        ST_FpP80m64 = 2878,

        ST_Frr = 2879,

        SUB16i16 = 2880,

        SUB16mi = 2881,

        SUB16mi8 = 2882,

        SUB16mr = 2883,

        SUB16ri = 2884,

        SUB16ri8 = 2885,

        SUB16rm = 2886,

        SUB16rr = 2887,

        SUB16rr_REV = 2888,

        SUB32i32 = 2889,

        SUB32mi = 2890,

        SUB32mi8 = 2891,

        SUB32mr = 2892,

        SUB32ri = 2893,

        SUB32ri8 = 2894,

        SUB32rm = 2895,

        SUB32rr = 2896,

        SUB32rr_REV = 2897,

        SUB64i32 = 2898,

        SUB64mi32 = 2899,

        SUB64mi8 = 2900,

        SUB64mr = 2901,

        SUB64ri32 = 2902,

        SUB64ri8 = 2903,

        SUB64rm = 2904,

        SUB64rr = 2905,

        SUB64rr_REV = 2906,

        SUB8i8 = 2907,

        SUB8mi = 2908,

        SUB8mi8 = 2909,

        SUB8mr = 2910,

        SUB8ri = 2911,

        SUB8ri8 = 2912,

        SUB8rm = 2913,

        SUB8rr = 2914,

        SUB8rr_REV = 2915,

        SUBPDrm = 2916,

        SUBPDrr = 2917,

        SUBPSrm = 2918,

        SUBPSrr = 2919,

        SUBR_F32m = 2920,

        SUBR_F64m = 2921,

        SUBR_FI16m = 2922,

        SUBR_FI32m = 2923,

        SUBR_FPrST0 = 2924,

        SUBR_FST0r = 2925,

        SUBR_Fp32m = 2926,

        SUBR_Fp64m = 2927,

        SUBR_Fp64m32 = 2928,

        SUBR_Fp80m32 = 2929,

        SUBR_Fp80m64 = 2930,

        SUBR_FpI16m32 = 2931,

        SUBR_FpI16m64 = 2932,

        SUBR_FpI16m80 = 2933,

        SUBR_FpI32m32 = 2934,

        SUBR_FpI32m64 = 2935,

        SUBR_FpI32m80 = 2936,

        SUBR_FrST0 = 2937,

        SUBSDrm = 2938,

        SUBSDrm_Int = 2939,

        SUBSDrr = 2940,

        SUBSDrr_Int = 2941,

        SUBSSrm = 2942,

        SUBSSrm_Int = 2943,

        SUBSSrr = 2944,

        SUBSSrr_Int = 2945,

        SUB_F32m = 2946,

        SUB_F64m = 2947,

        SUB_FI16m = 2948,

        SUB_FI32m = 2949,

        SUB_FPrST0 = 2950,

        SUB_FST0r = 2951,

        SUB_Fp32 = 2952,

        SUB_Fp32m = 2953,

        SUB_Fp64 = 2954,

        SUB_Fp64m = 2955,

        SUB_Fp64m32 = 2956,

        SUB_Fp80 = 2957,

        SUB_Fp80m32 = 2958,

        SUB_Fp80m64 = 2959,

        SUB_FpI16m32 = 2960,

        SUB_FpI16m64 = 2961,

        SUB_FpI16m80 = 2962,

        SUB_FpI32m32 = 2963,

        SUB_FpI32m64 = 2964,

        SUB_FpI32m80 = 2965,

        SUB_FrST0 = 2966,

        SWAPGS = 2967,

        SYSCALL = 2968,

        SYSENTER = 2969,

        SYSEXIT = 2970,

        SYSEXIT64 = 2971,

        SYSRET = 2972,

        SYSRET64 = 2973,

        T1MSKC32rm = 2974,

        T1MSKC32rr = 2975,

        T1MSKC64rm = 2976,

        T1MSKC64rr = 2977,

        TAILJMPd = 2978,

        TAILJMPd64 = 2979,

        TAILJMPd64_CC = 2980,

        TAILJMPd_CC = 2981,

        TAILJMPm = 2982,

        TAILJMPm64 = 2983,

        TAILJMPm64_REX = 2984,

        TAILJMPr = 2985,

        TAILJMPr64 = 2986,

        TAILJMPr64_REX = 2987,

        TCRETURNdi = 2988,

        TCRETURNdi64 = 2989,

        TCRETURNdi64cc = 2990,

        TCRETURNdicc = 2991,

        TCRETURNmi = 2992,

        TCRETURNmi64 = 2993,

        TCRETURNri = 2994,

        TCRETURNri64 = 2995,

        TDCALL = 2996,

        TDPBF16PS = 2997,

        TDPBSSD = 2998,

        TDPBSUD = 2999,

        TDPBUSD = 3000,

        TDPBUUD = 3001,

        TEST16i16 = 3002,

        TEST16mi = 3003,

        TEST16mr = 3004,

        TEST16ri = 3005,

        TEST16rr = 3006,

        TEST32i32 = 3007,

        TEST32mi = 3008,

        TEST32mr = 3009,

        TEST32ri = 3010,

        TEST32rr = 3011,

        TEST64i32 = 3012,

        TEST64mi32 = 3013,

        TEST64mr = 3014,

        TEST64ri32 = 3015,

        TEST64rr = 3016,

        TEST8i8 = 3017,

        TEST8mi = 3018,

        TEST8mr = 3019,

        TEST8ri = 3020,

        TEST8rr = 3021,

        TESTUI = 3022,

        TILELOADD = 3023,

        TILELOADDT1 = 3024,

        TILERELEASE = 3025,

        TILESTORED = 3026,

        TILEZERO = 3027,

        TLBSYNC = 3028,

        TLSCall_32 = 3029,

        TLSCall_64 = 3030,

        TLS_addr32 = 3031,

        TLS_addr64 = 3032,

        TLS_addrX32 = 3033,

        TLS_base_addr32 = 3034,

        TLS_base_addr64 = 3035,

        TLS_base_addrX32 = 3036,

        TPAUSE = 3037,

        TRAP = 3038,

        TST_F = 3039,

        TST_Fp32 = 3040,

        TST_Fp64 = 3041,

        TST_Fp80 = 3042,

        TZCNT16rm = 3043,

        TZCNT16rr = 3044,

        TZCNT32rm = 3045,

        TZCNT32rr = 3046,

        TZCNT64rm = 3047,

        TZCNT64rr = 3048,

        TZMSK32rm = 3049,

        TZMSK32rr = 3050,

        TZMSK64rm = 3051,

        TZMSK64rr = 3052,

        UBSAN_UD1 = 3053,

        UCOMISDrm = 3054,

        UCOMISDrm_Int = 3055,

        UCOMISDrr = 3056,

        UCOMISDrr_Int = 3057,

        UCOMISSrm = 3058,

        UCOMISSrm_Int = 3059,

        UCOMISSrr = 3060,

        UCOMISSrr_Int = 3061,

        UCOM_FIPr = 3062,

        UCOM_FIr = 3063,

        UCOM_FPPr = 3064,

        UCOM_FPr = 3065,

        UCOM_FpIr32 = 3066,

        UCOM_FpIr64 = 3067,

        UCOM_FpIr80 = 3068,

        UCOM_Fpr32 = 3069,

        UCOM_Fpr64 = 3070,

        UCOM_Fpr80 = 3071,

        UCOM_Fr = 3072,

        UD1Lm = 3073,

        UD1Lr = 3074,

        UD1Qm = 3075,

        UD1Qr = 3076,

        UD1Wm = 3077,

        UD1Wr = 3078,

        UIRET = 3079,

        UMONITOR16 = 3080,

        UMONITOR32 = 3081,

        UMONITOR64 = 3082,

        UMWAIT = 3083,

        UNPCKHPDrm = 3084,

        UNPCKHPDrr = 3085,

        UNPCKHPSrm = 3086,

        UNPCKHPSrr = 3087,

        UNPCKLPDrm = 3088,

        UNPCKLPDrr = 3089,

        UNPCKLPSrm = 3090,

        UNPCKLPSrr = 3091,

        V4FMADDPSrm = 3092,

        V4FMADDPSrmk = 3093,

        V4FMADDPSrmkz = 3094,

        V4FMADDSSrm = 3095,

        V4FMADDSSrmk = 3096,

        V4FMADDSSrmkz = 3097,

        V4FNMADDPSrm = 3098,

        V4FNMADDPSrmk = 3099,

        V4FNMADDPSrmkz = 3100,

        V4FNMADDSSrm = 3101,

        V4FNMADDSSrmk = 3102,

        V4FNMADDSSrmkz = 3103,

        VAARG_64 = 3104,

        VAARG_X32 = 3105,

        VADDPDYrm = 3106,

        VADDPDYrr = 3107,

        VADDPDZ128rm = 3108,

        VADDPDZ128rmb = 3109,

        VADDPDZ128rmbk = 3110,

        VADDPDZ128rmbkz = 3111,

        VADDPDZ128rmk = 3112,

        VADDPDZ128rmkz = 3113,

        VADDPDZ128rr = 3114,

        VADDPDZ128rrk = 3115,

        VADDPDZ128rrkz = 3116,

        VADDPDZ256rm = 3117,

        VADDPDZ256rmb = 3118,

        VADDPDZ256rmbk = 3119,

        VADDPDZ256rmbkz = 3120,

        VADDPDZ256rmk = 3121,

        VADDPDZ256rmkz = 3122,

        VADDPDZ256rr = 3123,

        VADDPDZ256rrk = 3124,

        VADDPDZ256rrkz = 3125,

        VADDPDZrm = 3126,

        VADDPDZrmb = 3127,

        VADDPDZrmbk = 3128,

        VADDPDZrmbkz = 3129,

        VADDPDZrmk = 3130,

        VADDPDZrmkz = 3131,

        VADDPDZrr = 3132,

        VADDPDZrrb = 3133,

        VADDPDZrrbk = 3134,

        VADDPDZrrbkz = 3135,

        VADDPDZrrk = 3136,

        VADDPDZrrkz = 3137,

        VADDPDrm = 3138,

        VADDPDrr = 3139,

        VADDPHZ128rm = 3140,

        VADDPHZ128rmb = 3141,

        VADDPHZ128rmbk = 3142,

        VADDPHZ128rmbkz = 3143,

        VADDPHZ128rmk = 3144,

        VADDPHZ128rmkz = 3145,

        VADDPHZ128rr = 3146,

        VADDPHZ128rrk = 3147,

        VADDPHZ128rrkz = 3148,

        VADDPHZ256rm = 3149,

        VADDPHZ256rmb = 3150,

        VADDPHZ256rmbk = 3151,

        VADDPHZ256rmbkz = 3152,

        VADDPHZ256rmk = 3153,

        VADDPHZ256rmkz = 3154,

        VADDPHZ256rr = 3155,

        VADDPHZ256rrk = 3156,

        VADDPHZ256rrkz = 3157,

        VADDPHZrm = 3158,

        VADDPHZrmb = 3159,

        VADDPHZrmbk = 3160,

        VADDPHZrmbkz = 3161,

        VADDPHZrmk = 3162,

        VADDPHZrmkz = 3163,

        VADDPHZrr = 3164,

        VADDPHZrrb = 3165,

        VADDPHZrrbk = 3166,

        VADDPHZrrbkz = 3167,

        VADDPHZrrk = 3168,

        VADDPHZrrkz = 3169,

        VADDPSYrm = 3170,

        VADDPSYrr = 3171,

        VADDPSZ128rm = 3172,

        VADDPSZ128rmb = 3173,

        VADDPSZ128rmbk = 3174,

        VADDPSZ128rmbkz = 3175,

        VADDPSZ128rmk = 3176,

        VADDPSZ128rmkz = 3177,

        VADDPSZ128rr = 3178,

        VADDPSZ128rrk = 3179,

        VADDPSZ128rrkz = 3180,

        VADDPSZ256rm = 3181,

        VADDPSZ256rmb = 3182,

        VADDPSZ256rmbk = 3183,

        VADDPSZ256rmbkz = 3184,

        VADDPSZ256rmk = 3185,

        VADDPSZ256rmkz = 3186,

        VADDPSZ256rr = 3187,

        VADDPSZ256rrk = 3188,

        VADDPSZ256rrkz = 3189,

        VADDPSZrm = 3190,

        VADDPSZrmb = 3191,

        VADDPSZrmbk = 3192,

        VADDPSZrmbkz = 3193,

        VADDPSZrmk = 3194,

        VADDPSZrmkz = 3195,

        VADDPSZrr = 3196,

        VADDPSZrrb = 3197,

        VADDPSZrrbk = 3198,

        VADDPSZrrbkz = 3199,

        VADDPSZrrk = 3200,

        VADDPSZrrkz = 3201,

        VADDPSrm = 3202,

        VADDPSrr = 3203,

        VADDSDZrm = 3204,

        VADDSDZrm_Int = 3205,

        VADDSDZrm_Intk = 3206,

        VADDSDZrm_Intkz = 3207,

        VADDSDZrr = 3208,

        VADDSDZrr_Int = 3209,

        VADDSDZrr_Intk = 3210,

        VADDSDZrr_Intkz = 3211,

        VADDSDZrrb_Int = 3212,

        VADDSDZrrb_Intk = 3213,

        VADDSDZrrb_Intkz = 3214,

        VADDSDrm = 3215,

        VADDSDrm_Int = 3216,

        VADDSDrr = 3217,

        VADDSDrr_Int = 3218,

        VADDSHZrm = 3219,

        VADDSHZrm_Int = 3220,

        VADDSHZrm_Intk = 3221,

        VADDSHZrm_Intkz = 3222,

        VADDSHZrr = 3223,

        VADDSHZrr_Int = 3224,

        VADDSHZrr_Intk = 3225,

        VADDSHZrr_Intkz = 3226,

        VADDSHZrrb_Int = 3227,

        VADDSHZrrb_Intk = 3228,

        VADDSHZrrb_Intkz = 3229,

        VADDSSZrm = 3230,

        VADDSSZrm_Int = 3231,

        VADDSSZrm_Intk = 3232,

        VADDSSZrm_Intkz = 3233,

        VADDSSZrr = 3234,

        VADDSSZrr_Int = 3235,

        VADDSSZrr_Intk = 3236,

        VADDSSZrr_Intkz = 3237,

        VADDSSZrrb_Int = 3238,

        VADDSSZrrb_Intk = 3239,

        VADDSSZrrb_Intkz = 3240,

        VADDSSrm = 3241,

        VADDSSrm_Int = 3242,

        VADDSSrr = 3243,

        VADDSSrr_Int = 3244,

        VADDSUBPDYrm = 3245,

        VADDSUBPDYrr = 3246,

        VADDSUBPDrm = 3247,

        VADDSUBPDrr = 3248,

        VADDSUBPSYrm = 3249,

        VADDSUBPSYrr = 3250,

        VADDSUBPSrm = 3251,

        VADDSUBPSrr = 3252,

        VAESDECLASTYrm = 3253,

        VAESDECLASTYrr = 3254,

        VAESDECLASTZ128rm = 3255,

        VAESDECLASTZ128rr = 3256,

        VAESDECLASTZ256rm = 3257,

        VAESDECLASTZ256rr = 3258,

        VAESDECLASTZrm = 3259,

        VAESDECLASTZrr = 3260,

        VAESDECLASTrm = 3261,

        VAESDECLASTrr = 3262,

        VAESDECYrm = 3263,

        VAESDECYrr = 3264,

        VAESDECZ128rm = 3265,

        VAESDECZ128rr = 3266,

        VAESDECZ256rm = 3267,

        VAESDECZ256rr = 3268,

        VAESDECZrm = 3269,

        VAESDECZrr = 3270,

        VAESDECrm = 3271,

        VAESDECrr = 3272,

        VAESENCLASTYrm = 3273,

        VAESENCLASTYrr = 3274,

        VAESENCLASTZ128rm = 3275,

        VAESENCLASTZ128rr = 3276,

        VAESENCLASTZ256rm = 3277,

        VAESENCLASTZ256rr = 3278,

        VAESENCLASTZrm = 3279,

        VAESENCLASTZrr = 3280,

        VAESENCLASTrm = 3281,

        VAESENCLASTrr = 3282,

        VAESENCYrm = 3283,

        VAESENCYrr = 3284,

        VAESENCZ128rm = 3285,

        VAESENCZ128rr = 3286,

        VAESENCZ256rm = 3287,

        VAESENCZ256rr = 3288,

        VAESENCZrm = 3289,

        VAESENCZrr = 3290,

        VAESENCrm = 3291,

        VAESENCrr = 3292,

        VAESIMCrm = 3293,

        VAESIMCrr = 3294,

        VAESKEYGENASSIST128rm = 3295,

        VAESKEYGENASSIST128rr = 3296,

        VALIGNDZ128rmbi = 3297,

        VALIGNDZ128rmbik = 3298,

        VALIGNDZ128rmbikz = 3299,

        VALIGNDZ128rmi = 3300,

        VALIGNDZ128rmik = 3301,

        VALIGNDZ128rmikz = 3302,

        VALIGNDZ128rri = 3303,

        VALIGNDZ128rrik = 3304,

        VALIGNDZ128rrikz = 3305,

        VALIGNDZ256rmbi = 3306,

        VALIGNDZ256rmbik = 3307,

        VALIGNDZ256rmbikz = 3308,

        VALIGNDZ256rmi = 3309,

        VALIGNDZ256rmik = 3310,

        VALIGNDZ256rmikz = 3311,

        VALIGNDZ256rri = 3312,

        VALIGNDZ256rrik = 3313,

        VALIGNDZ256rrikz = 3314,

        VALIGNDZrmbi = 3315,

        VALIGNDZrmbik = 3316,

        VALIGNDZrmbikz = 3317,

        VALIGNDZrmi = 3318,

        VALIGNDZrmik = 3319,

        VALIGNDZrmikz = 3320,

        VALIGNDZrri = 3321,

        VALIGNDZrrik = 3322,

        VALIGNDZrrikz = 3323,

        VALIGNQZ128rmbi = 3324,

        VALIGNQZ128rmbik = 3325,

        VALIGNQZ128rmbikz = 3326,

        VALIGNQZ128rmi = 3327,

        VALIGNQZ128rmik = 3328,

        VALIGNQZ128rmikz = 3329,

        VALIGNQZ128rri = 3330,

        VALIGNQZ128rrik = 3331,

        VALIGNQZ128rrikz = 3332,

        VALIGNQZ256rmbi = 3333,

        VALIGNQZ256rmbik = 3334,

        VALIGNQZ256rmbikz = 3335,

        VALIGNQZ256rmi = 3336,

        VALIGNQZ256rmik = 3337,

        VALIGNQZ256rmikz = 3338,

        VALIGNQZ256rri = 3339,

        VALIGNQZ256rrik = 3340,

        VALIGNQZ256rrikz = 3341,

        VALIGNQZrmbi = 3342,

        VALIGNQZrmbik = 3343,

        VALIGNQZrmbikz = 3344,

        VALIGNQZrmi = 3345,

        VALIGNQZrmik = 3346,

        VALIGNQZrmikz = 3347,

        VALIGNQZrri = 3348,

        VALIGNQZrrik = 3349,

        VALIGNQZrrikz = 3350,

        VANDNPDYrm = 3351,

        VANDNPDYrr = 3352,

        VANDNPDZ128rm = 3353,

        VANDNPDZ128rmb = 3354,

        VANDNPDZ128rmbk = 3355,

        VANDNPDZ128rmbkz = 3356,

        VANDNPDZ128rmk = 3357,

        VANDNPDZ128rmkz = 3358,

        VANDNPDZ128rr = 3359,

        VANDNPDZ128rrk = 3360,

        VANDNPDZ128rrkz = 3361,

        VANDNPDZ256rm = 3362,

        VANDNPDZ256rmb = 3363,

        VANDNPDZ256rmbk = 3364,

        VANDNPDZ256rmbkz = 3365,

        VANDNPDZ256rmk = 3366,

        VANDNPDZ256rmkz = 3367,

        VANDNPDZ256rr = 3368,

        VANDNPDZ256rrk = 3369,

        VANDNPDZ256rrkz = 3370,

        VANDNPDZrm = 3371,

        VANDNPDZrmb = 3372,

        VANDNPDZrmbk = 3373,

        VANDNPDZrmbkz = 3374,

        VANDNPDZrmk = 3375,

        VANDNPDZrmkz = 3376,

        VANDNPDZrr = 3377,

        VANDNPDZrrk = 3378,

        VANDNPDZrrkz = 3379,

        VANDNPDrm = 3380,

        VANDNPDrr = 3381,

        VANDNPSYrm = 3382,

        VANDNPSYrr = 3383,

        VANDNPSZ128rm = 3384,

        VANDNPSZ128rmb = 3385,

        VANDNPSZ128rmbk = 3386,

        VANDNPSZ128rmbkz = 3387,

        VANDNPSZ128rmk = 3388,

        VANDNPSZ128rmkz = 3389,

        VANDNPSZ128rr = 3390,

        VANDNPSZ128rrk = 3391,

        VANDNPSZ128rrkz = 3392,

        VANDNPSZ256rm = 3393,

        VANDNPSZ256rmb = 3394,

        VANDNPSZ256rmbk = 3395,

        VANDNPSZ256rmbkz = 3396,

        VANDNPSZ256rmk = 3397,

        VANDNPSZ256rmkz = 3398,

        VANDNPSZ256rr = 3399,

        VANDNPSZ256rrk = 3400,

        VANDNPSZ256rrkz = 3401,

        VANDNPSZrm = 3402,

        VANDNPSZrmb = 3403,

        VANDNPSZrmbk = 3404,

        VANDNPSZrmbkz = 3405,

        VANDNPSZrmk = 3406,

        VANDNPSZrmkz = 3407,

        VANDNPSZrr = 3408,

        VANDNPSZrrk = 3409,

        VANDNPSZrrkz = 3410,

        VANDNPSrm = 3411,

        VANDNPSrr = 3412,

        VANDPDYrm = 3413,

        VANDPDYrr = 3414,

        VANDPDZ128rm = 3415,

        VANDPDZ128rmb = 3416,

        VANDPDZ128rmbk = 3417,

        VANDPDZ128rmbkz = 3418,

        VANDPDZ128rmk = 3419,

        VANDPDZ128rmkz = 3420,

        VANDPDZ128rr = 3421,

        VANDPDZ128rrk = 3422,

        VANDPDZ128rrkz = 3423,

        VANDPDZ256rm = 3424,

        VANDPDZ256rmb = 3425,

        VANDPDZ256rmbk = 3426,

        VANDPDZ256rmbkz = 3427,

        VANDPDZ256rmk = 3428,

        VANDPDZ256rmkz = 3429,

        VANDPDZ256rr = 3430,

        VANDPDZ256rrk = 3431,

        VANDPDZ256rrkz = 3432,

        VANDPDZrm = 3433,

        VANDPDZrmb = 3434,

        VANDPDZrmbk = 3435,

        VANDPDZrmbkz = 3436,

        VANDPDZrmk = 3437,

        VANDPDZrmkz = 3438,

        VANDPDZrr = 3439,

        VANDPDZrrk = 3440,

        VANDPDZrrkz = 3441,

        VANDPDrm = 3442,

        VANDPDrr = 3443,

        VANDPSYrm = 3444,

        VANDPSYrr = 3445,

        VANDPSZ128rm = 3446,

        VANDPSZ128rmb = 3447,

        VANDPSZ128rmbk = 3448,

        VANDPSZ128rmbkz = 3449,

        VANDPSZ128rmk = 3450,

        VANDPSZ128rmkz = 3451,

        VANDPSZ128rr = 3452,

        VANDPSZ128rrk = 3453,

        VANDPSZ128rrkz = 3454,

        VANDPSZ256rm = 3455,

        VANDPSZ256rmb = 3456,

        VANDPSZ256rmbk = 3457,

        VANDPSZ256rmbkz = 3458,

        VANDPSZ256rmk = 3459,

        VANDPSZ256rmkz = 3460,

        VANDPSZ256rr = 3461,

        VANDPSZ256rrk = 3462,

        VANDPSZ256rrkz = 3463,

        VANDPSZrm = 3464,

        VANDPSZrmb = 3465,

        VANDPSZrmbk = 3466,

        VANDPSZrmbkz = 3467,

        VANDPSZrmk = 3468,

        VANDPSZrmkz = 3469,

        VANDPSZrr = 3470,

        VANDPSZrrk = 3471,

        VANDPSZrrkz = 3472,

        VANDPSrm = 3473,

        VANDPSrr = 3474,

        VASTART_SAVE_XMM_REGS = 3475,

        VBLENDMPDZ128rm = 3476,

        VBLENDMPDZ128rmb = 3477,

        VBLENDMPDZ128rmbk = 3478,

        VBLENDMPDZ128rmbkz = 3479,

        VBLENDMPDZ128rmk = 3480,

        VBLENDMPDZ128rmkz = 3481,

        VBLENDMPDZ128rr = 3482,

        VBLENDMPDZ128rrk = 3483,

        VBLENDMPDZ128rrkz = 3484,

        VBLENDMPDZ256rm = 3485,

        VBLENDMPDZ256rmb = 3486,

        VBLENDMPDZ256rmbk = 3487,

        VBLENDMPDZ256rmbkz = 3488,

        VBLENDMPDZ256rmk = 3489,

        VBLENDMPDZ256rmkz = 3490,

        VBLENDMPDZ256rr = 3491,

        VBLENDMPDZ256rrk = 3492,

        VBLENDMPDZ256rrkz = 3493,

        VBLENDMPDZrm = 3494,

        VBLENDMPDZrmb = 3495,

        VBLENDMPDZrmbk = 3496,

        VBLENDMPDZrmbkz = 3497,

        VBLENDMPDZrmk = 3498,

        VBLENDMPDZrmkz = 3499,

        VBLENDMPDZrr = 3500,

        VBLENDMPDZrrk = 3501,

        VBLENDMPDZrrkz = 3502,

        VBLENDMPSZ128rm = 3503,

        VBLENDMPSZ128rmb = 3504,

        VBLENDMPSZ128rmbk = 3505,

        VBLENDMPSZ128rmbkz = 3506,

        VBLENDMPSZ128rmk = 3507,

        VBLENDMPSZ128rmkz = 3508,

        VBLENDMPSZ128rr = 3509,

        VBLENDMPSZ128rrk = 3510,

        VBLENDMPSZ128rrkz = 3511,

        VBLENDMPSZ256rm = 3512,

        VBLENDMPSZ256rmb = 3513,

        VBLENDMPSZ256rmbk = 3514,

        VBLENDMPSZ256rmbkz = 3515,

        VBLENDMPSZ256rmk = 3516,

        VBLENDMPSZ256rmkz = 3517,

        VBLENDMPSZ256rr = 3518,

        VBLENDMPSZ256rrk = 3519,

        VBLENDMPSZ256rrkz = 3520,

        VBLENDMPSZrm = 3521,

        VBLENDMPSZrmb = 3522,

        VBLENDMPSZrmbk = 3523,

        VBLENDMPSZrmbkz = 3524,

        VBLENDMPSZrmk = 3525,

        VBLENDMPSZrmkz = 3526,

        VBLENDMPSZrr = 3527,

        VBLENDMPSZrrk = 3528,

        VBLENDMPSZrrkz = 3529,

        VBLENDPDYrmi = 3530,

        VBLENDPDYrri = 3531,

        VBLENDPDrmi = 3532,

        VBLENDPDrri = 3533,

        VBLENDPSYrmi = 3534,

        VBLENDPSYrri = 3535,

        VBLENDPSrmi = 3536,

        VBLENDPSrri = 3537,

        VBLENDVPDYrm = 3538,

        VBLENDVPDYrr = 3539,

        VBLENDVPDrm = 3540,

        VBLENDVPDrr = 3541,

        VBLENDVPSYrm = 3542,

        VBLENDVPSYrr = 3543,

        VBLENDVPSrm = 3544,

        VBLENDVPSrr = 3545,

        VBROADCASTF128 = 3546,

        VBROADCASTF32X2Z256rm = 3547,

        VBROADCASTF32X2Z256rmk = 3548,

        VBROADCASTF32X2Z256rmkz = 3549,

        VBROADCASTF32X2Z256rr = 3550,

        VBROADCASTF32X2Z256rrk = 3551,

        VBROADCASTF32X2Z256rrkz = 3552,

        VBROADCASTF32X2Zrm = 3553,

        VBROADCASTF32X2Zrmk = 3554,

        VBROADCASTF32X2Zrmkz = 3555,

        VBROADCASTF32X2Zrr = 3556,

        VBROADCASTF32X2Zrrk = 3557,

        VBROADCASTF32X2Zrrkz = 3558,

        VBROADCASTF32X4Z256rm = 3559,

        VBROADCASTF32X4Z256rmk = 3560,

        VBROADCASTF32X4Z256rmkz = 3561,

        VBROADCASTF32X4rm = 3562,

        VBROADCASTF32X4rmk = 3563,

        VBROADCASTF32X4rmkz = 3564,

        VBROADCASTF32X8rm = 3565,

        VBROADCASTF32X8rmk = 3566,

        VBROADCASTF32X8rmkz = 3567,

        VBROADCASTF64X2Z128rm = 3568,

        VBROADCASTF64X2Z128rmk = 3569,

        VBROADCASTF64X2Z128rmkz = 3570,

        VBROADCASTF64X2rm = 3571,

        VBROADCASTF64X2rmk = 3572,

        VBROADCASTF64X2rmkz = 3573,

        VBROADCASTF64X4rm = 3574,

        VBROADCASTF64X4rmk = 3575,

        VBROADCASTF64X4rmkz = 3576,

        VBROADCASTI128 = 3577,

        VBROADCASTI32X2Z128rm = 3578,

        VBROADCASTI32X2Z128rmk = 3579,

        VBROADCASTI32X2Z128rmkz = 3580,

        VBROADCASTI32X2Z128rr = 3581,

        VBROADCASTI32X2Z128rrk = 3582,

        VBROADCASTI32X2Z128rrkz = 3583,

        VBROADCASTI32X2Z256rm = 3584,

        VBROADCASTI32X2Z256rmk = 3585,

        VBROADCASTI32X2Z256rmkz = 3586,

        VBROADCASTI32X2Z256rr = 3587,

        VBROADCASTI32X2Z256rrk = 3588,

        VBROADCASTI32X2Z256rrkz = 3589,

        VBROADCASTI32X2Zrm = 3590,

        VBROADCASTI32X2Zrmk = 3591,

        VBROADCASTI32X2Zrmkz = 3592,

        VBROADCASTI32X2Zrr = 3593,

        VBROADCASTI32X2Zrrk = 3594,

        VBROADCASTI32X2Zrrkz = 3595,

        VBROADCASTI32X4Z256rm = 3596,

        VBROADCASTI32X4Z256rmk = 3597,

        VBROADCASTI32X4Z256rmkz = 3598,

        VBROADCASTI32X4rm = 3599,

        VBROADCASTI32X4rmk = 3600,

        VBROADCASTI32X4rmkz = 3601,

        VBROADCASTI32X8rm = 3602,

        VBROADCASTI32X8rmk = 3603,

        VBROADCASTI32X8rmkz = 3604,

        VBROADCASTI64X2Z128rm = 3605,

        VBROADCASTI64X2Z128rmk = 3606,

        VBROADCASTI64X2Z128rmkz = 3607,

        VBROADCASTI64X2rm = 3608,

        VBROADCASTI64X2rmk = 3609,

        VBROADCASTI64X2rmkz = 3610,

        VBROADCASTI64X4rm = 3611,

        VBROADCASTI64X4rmk = 3612,

        VBROADCASTI64X4rmkz = 3613,

        VBROADCASTSDYrm = 3614,

        VBROADCASTSDYrr = 3615,

        VBROADCASTSDZ256rm = 3616,

        VBROADCASTSDZ256rmk = 3617,

        VBROADCASTSDZ256rmkz = 3618,

        VBROADCASTSDZ256rr = 3619,

        VBROADCASTSDZ256rrk = 3620,

        VBROADCASTSDZ256rrkz = 3621,

        VBROADCASTSDZrm = 3622,

        VBROADCASTSDZrmk = 3623,

        VBROADCASTSDZrmkz = 3624,

        VBROADCASTSDZrr = 3625,

        VBROADCASTSDZrrk = 3626,

        VBROADCASTSDZrrkz = 3627,

        VBROADCASTSSYrm = 3628,

        VBROADCASTSSYrr = 3629,

        VBROADCASTSSZ128rm = 3630,

        VBROADCASTSSZ128rmk = 3631,

        VBROADCASTSSZ128rmkz = 3632,

        VBROADCASTSSZ128rr = 3633,

        VBROADCASTSSZ128rrk = 3634,

        VBROADCASTSSZ128rrkz = 3635,

        VBROADCASTSSZ256rm = 3636,

        VBROADCASTSSZ256rmk = 3637,

        VBROADCASTSSZ256rmkz = 3638,

        VBROADCASTSSZ256rr = 3639,

        VBROADCASTSSZ256rrk = 3640,

        VBROADCASTSSZ256rrkz = 3641,

        VBROADCASTSSZrm = 3642,

        VBROADCASTSSZrmk = 3643,

        VBROADCASTSSZrmkz = 3644,

        VBROADCASTSSZrr = 3645,

        VBROADCASTSSZrrk = 3646,

        VBROADCASTSSZrrkz = 3647,

        VBROADCASTSSrm = 3648,

        VBROADCASTSSrr = 3649,

        VCMPPDYrmi = 3650,

        VCMPPDYrri = 3651,

        VCMPPDZ128rmbi = 3652,

        VCMPPDZ128rmbik = 3653,

        VCMPPDZ128rmi = 3654,

        VCMPPDZ128rmik = 3655,

        VCMPPDZ128rri = 3656,

        VCMPPDZ128rrik = 3657,

        VCMPPDZ256rmbi = 3658,

        VCMPPDZ256rmbik = 3659,

        VCMPPDZ256rmi = 3660,

        VCMPPDZ256rmik = 3661,

        VCMPPDZ256rri = 3662,

        VCMPPDZ256rrik = 3663,

        VCMPPDZrmbi = 3664,

        VCMPPDZrmbik = 3665,

        VCMPPDZrmi = 3666,

        VCMPPDZrmik = 3667,

        VCMPPDZrri = 3668,

        VCMPPDZrrib = 3669,

        VCMPPDZrribk = 3670,

        VCMPPDZrrik = 3671,

        VCMPPDrmi = 3672,

        VCMPPDrri = 3673,

        VCMPPHZ128rmbi = 3674,

        VCMPPHZ128rmbik = 3675,

        VCMPPHZ128rmi = 3676,

        VCMPPHZ128rmik = 3677,

        VCMPPHZ128rri = 3678,

        VCMPPHZ128rrik = 3679,

        VCMPPHZ256rmbi = 3680,

        VCMPPHZ256rmbik = 3681,

        VCMPPHZ256rmi = 3682,

        VCMPPHZ256rmik = 3683,

        VCMPPHZ256rri = 3684,

        VCMPPHZ256rrik = 3685,

        VCMPPHZrmbi = 3686,

        VCMPPHZrmbik = 3687,

        VCMPPHZrmi = 3688,

        VCMPPHZrmik = 3689,

        VCMPPHZrri = 3690,

        VCMPPHZrrib = 3691,

        VCMPPHZrribk = 3692,

        VCMPPHZrrik = 3693,

        VCMPPSYrmi = 3694,

        VCMPPSYrri = 3695,

        VCMPPSZ128rmbi = 3696,

        VCMPPSZ128rmbik = 3697,

        VCMPPSZ128rmi = 3698,

        VCMPPSZ128rmik = 3699,

        VCMPPSZ128rri = 3700,

        VCMPPSZ128rrik = 3701,

        VCMPPSZ256rmbi = 3702,

        VCMPPSZ256rmbik = 3703,

        VCMPPSZ256rmi = 3704,

        VCMPPSZ256rmik = 3705,

        VCMPPSZ256rri = 3706,

        VCMPPSZ256rrik = 3707,

        VCMPPSZrmbi = 3708,

        VCMPPSZrmbik = 3709,

        VCMPPSZrmi = 3710,

        VCMPPSZrmik = 3711,

        VCMPPSZrri = 3712,

        VCMPPSZrrib = 3713,

        VCMPPSZrribk = 3714,

        VCMPPSZrrik = 3715,

        VCMPPSrmi = 3716,

        VCMPPSrri = 3717,

        VCMPSDZrm = 3718,

        VCMPSDZrm_Int = 3719,

        VCMPSDZrm_Intk = 3720,

        VCMPSDZrr = 3721,

        VCMPSDZrr_Int = 3722,

        VCMPSDZrr_Intk = 3723,

        VCMPSDZrrb_Int = 3724,

        VCMPSDZrrb_Intk = 3725,

        VCMPSDrm = 3726,

        VCMPSDrm_Int = 3727,

        VCMPSDrr = 3728,

        VCMPSDrr_Int = 3729,

        VCMPSHZrm = 3730,

        VCMPSHZrm_Int = 3731,

        VCMPSHZrm_Intk = 3732,

        VCMPSHZrr = 3733,

        VCMPSHZrr_Int = 3734,

        VCMPSHZrr_Intk = 3735,

        VCMPSHZrrb_Int = 3736,

        VCMPSHZrrb_Intk = 3737,

        VCMPSSZrm = 3738,

        VCMPSSZrm_Int = 3739,

        VCMPSSZrm_Intk = 3740,

        VCMPSSZrr = 3741,

        VCMPSSZrr_Int = 3742,

        VCMPSSZrr_Intk = 3743,

        VCMPSSZrrb_Int = 3744,

        VCMPSSZrrb_Intk = 3745,

        VCMPSSrm = 3746,

        VCMPSSrm_Int = 3747,

        VCMPSSrr = 3748,

        VCMPSSrr_Int = 3749,

        VCOMISDZrm = 3750,

        VCOMISDZrm_Int = 3751,

        VCOMISDZrr = 3752,

        VCOMISDZrr_Int = 3753,

        VCOMISDZrrb = 3754,

        VCOMISDrm = 3755,

        VCOMISDrm_Int = 3756,

        VCOMISDrr = 3757,

        VCOMISDrr_Int = 3758,

        VCOMISHZrm = 3759,

        VCOMISHZrm_Int = 3760,

        VCOMISHZrr = 3761,

        VCOMISHZrr_Int = 3762,

        VCOMISHZrrb = 3763,

        VCOMISSZrm = 3764,

        VCOMISSZrm_Int = 3765,

        VCOMISSZrr = 3766,

        VCOMISSZrr_Int = 3767,

        VCOMISSZrrb = 3768,

        VCOMISSrm = 3769,

        VCOMISSrm_Int = 3770,

        VCOMISSrr = 3771,

        VCOMISSrr_Int = 3772,

        VCOMPRESSPDZ128mr = 3773,

        VCOMPRESSPDZ128mrk = 3774,

        VCOMPRESSPDZ128rr = 3775,

        VCOMPRESSPDZ128rrk = 3776,

        VCOMPRESSPDZ128rrkz = 3777,

        VCOMPRESSPDZ256mr = 3778,

        VCOMPRESSPDZ256mrk = 3779,

        VCOMPRESSPDZ256rr = 3780,

        VCOMPRESSPDZ256rrk = 3781,

        VCOMPRESSPDZ256rrkz = 3782,

        VCOMPRESSPDZmr = 3783,

        VCOMPRESSPDZmrk = 3784,

        VCOMPRESSPDZrr = 3785,

        VCOMPRESSPDZrrk = 3786,

        VCOMPRESSPDZrrkz = 3787,

        VCOMPRESSPSZ128mr = 3788,

        VCOMPRESSPSZ128mrk = 3789,

        VCOMPRESSPSZ128rr = 3790,

        VCOMPRESSPSZ128rrk = 3791,

        VCOMPRESSPSZ128rrkz = 3792,

        VCOMPRESSPSZ256mr = 3793,

        VCOMPRESSPSZ256mrk = 3794,

        VCOMPRESSPSZ256rr = 3795,

        VCOMPRESSPSZ256rrk = 3796,

        VCOMPRESSPSZ256rrkz = 3797,

        VCOMPRESSPSZmr = 3798,

        VCOMPRESSPSZmrk = 3799,

        VCOMPRESSPSZrr = 3800,

        VCOMPRESSPSZrrk = 3801,

        VCOMPRESSPSZrrkz = 3802,

        VCVTDQ2PDYrm = 3803,

        VCVTDQ2PDYrr = 3804,

        VCVTDQ2PDZ128rm = 3805,

        VCVTDQ2PDZ128rmb = 3806,

        VCVTDQ2PDZ128rmbk = 3807,

        VCVTDQ2PDZ128rmbkz = 3808,

        VCVTDQ2PDZ128rmk = 3809,

        VCVTDQ2PDZ128rmkz = 3810,

        VCVTDQ2PDZ128rr = 3811,

        VCVTDQ2PDZ128rrk = 3812,

        VCVTDQ2PDZ128rrkz = 3813,

        VCVTDQ2PDZ256rm = 3814,

        VCVTDQ2PDZ256rmb = 3815,

        VCVTDQ2PDZ256rmbk = 3816,

        VCVTDQ2PDZ256rmbkz = 3817,

        VCVTDQ2PDZ256rmk = 3818,

        VCVTDQ2PDZ256rmkz = 3819,

        VCVTDQ2PDZ256rr = 3820,

        VCVTDQ2PDZ256rrk = 3821,

        VCVTDQ2PDZ256rrkz = 3822,

        VCVTDQ2PDZrm = 3823,

        VCVTDQ2PDZrmb = 3824,

        VCVTDQ2PDZrmbk = 3825,

        VCVTDQ2PDZrmbkz = 3826,

        VCVTDQ2PDZrmk = 3827,

        VCVTDQ2PDZrmkz = 3828,

        VCVTDQ2PDZrr = 3829,

        VCVTDQ2PDZrrk = 3830,

        VCVTDQ2PDZrrkz = 3831,

        VCVTDQ2PDrm = 3832,

        VCVTDQ2PDrr = 3833,

        VCVTDQ2PHZ128rm = 3834,

        VCVTDQ2PHZ128rmb = 3835,

        VCVTDQ2PHZ128rmbk = 3836,

        VCVTDQ2PHZ128rmbkz = 3837,

        VCVTDQ2PHZ128rmk = 3838,

        VCVTDQ2PHZ128rmkz = 3839,

        VCVTDQ2PHZ128rr = 3840,

        VCVTDQ2PHZ128rrk = 3841,

        VCVTDQ2PHZ128rrkz = 3842,

        VCVTDQ2PHZ256rm = 3843,

        VCVTDQ2PHZ256rmb = 3844,

        VCVTDQ2PHZ256rmbk = 3845,

        VCVTDQ2PHZ256rmbkz = 3846,

        VCVTDQ2PHZ256rmk = 3847,

        VCVTDQ2PHZ256rmkz = 3848,

        VCVTDQ2PHZ256rr = 3849,

        VCVTDQ2PHZ256rrk = 3850,

        VCVTDQ2PHZ256rrkz = 3851,

        VCVTDQ2PHZrm = 3852,

        VCVTDQ2PHZrmb = 3853,

        VCVTDQ2PHZrmbk = 3854,

        VCVTDQ2PHZrmbkz = 3855,

        VCVTDQ2PHZrmk = 3856,

        VCVTDQ2PHZrmkz = 3857,

        VCVTDQ2PHZrr = 3858,

        VCVTDQ2PHZrrb = 3859,

        VCVTDQ2PHZrrbk = 3860,

        VCVTDQ2PHZrrbkz = 3861,

        VCVTDQ2PHZrrk = 3862,

        VCVTDQ2PHZrrkz = 3863,

        VCVTDQ2PSYrm = 3864,

        VCVTDQ2PSYrr = 3865,

        VCVTDQ2PSZ128rm = 3866,

        VCVTDQ2PSZ128rmb = 3867,

        VCVTDQ2PSZ128rmbk = 3868,

        VCVTDQ2PSZ128rmbkz = 3869,

        VCVTDQ2PSZ128rmk = 3870,

        VCVTDQ2PSZ128rmkz = 3871,

        VCVTDQ2PSZ128rr = 3872,

        VCVTDQ2PSZ128rrk = 3873,

        VCVTDQ2PSZ128rrkz = 3874,

        VCVTDQ2PSZ256rm = 3875,

        VCVTDQ2PSZ256rmb = 3876,

        VCVTDQ2PSZ256rmbk = 3877,

        VCVTDQ2PSZ256rmbkz = 3878,

        VCVTDQ2PSZ256rmk = 3879,

        VCVTDQ2PSZ256rmkz = 3880,

        VCVTDQ2PSZ256rr = 3881,

        VCVTDQ2PSZ256rrk = 3882,

        VCVTDQ2PSZ256rrkz = 3883,

        VCVTDQ2PSZrm = 3884,

        VCVTDQ2PSZrmb = 3885,

        VCVTDQ2PSZrmbk = 3886,

        VCVTDQ2PSZrmbkz = 3887,

        VCVTDQ2PSZrmk = 3888,

        VCVTDQ2PSZrmkz = 3889,

        VCVTDQ2PSZrr = 3890,

        VCVTDQ2PSZrrb = 3891,

        VCVTDQ2PSZrrbk = 3892,

        VCVTDQ2PSZrrbkz = 3893,

        VCVTDQ2PSZrrk = 3894,

        VCVTDQ2PSZrrkz = 3895,

        VCVTDQ2PSrm = 3896,

        VCVTDQ2PSrr = 3897,

        VCVTNE2PS2BF16Z128rm = 3898,

        VCVTNE2PS2BF16Z128rmb = 3899,

        VCVTNE2PS2BF16Z128rmbk = 3900,

        VCVTNE2PS2BF16Z128rmbkz = 3901,

        VCVTNE2PS2BF16Z128rmk = 3902,

        VCVTNE2PS2BF16Z128rmkz = 3903,

        VCVTNE2PS2BF16Z128rr = 3904,

        VCVTNE2PS2BF16Z128rrk = 3905,

        VCVTNE2PS2BF16Z128rrkz = 3906,

        VCVTNE2PS2BF16Z256rm = 3907,

        VCVTNE2PS2BF16Z256rmb = 3908,

        VCVTNE2PS2BF16Z256rmbk = 3909,

        VCVTNE2PS2BF16Z256rmbkz = 3910,

        VCVTNE2PS2BF16Z256rmk = 3911,

        VCVTNE2PS2BF16Z256rmkz = 3912,

        VCVTNE2PS2BF16Z256rr = 3913,

        VCVTNE2PS2BF16Z256rrk = 3914,

        VCVTNE2PS2BF16Z256rrkz = 3915,

        VCVTNE2PS2BF16Zrm = 3916,

        VCVTNE2PS2BF16Zrmb = 3917,

        VCVTNE2PS2BF16Zrmbk = 3918,

        VCVTNE2PS2BF16Zrmbkz = 3919,

        VCVTNE2PS2BF16Zrmk = 3920,

        VCVTNE2PS2BF16Zrmkz = 3921,

        VCVTNE2PS2BF16Zrr = 3922,

        VCVTNE2PS2BF16Zrrk = 3923,

        VCVTNE2PS2BF16Zrrkz = 3924,

        VCVTNEPS2BF16Z128rm = 3925,

        VCVTNEPS2BF16Z128rmb = 3926,

        VCVTNEPS2BF16Z128rmbk = 3927,

        VCVTNEPS2BF16Z128rmbkz = 3928,

        VCVTNEPS2BF16Z128rmk = 3929,

        VCVTNEPS2BF16Z128rmkz = 3930,

        VCVTNEPS2BF16Z128rr = 3931,

        VCVTNEPS2BF16Z128rrk = 3932,

        VCVTNEPS2BF16Z128rrkz = 3933,

        VCVTNEPS2BF16Z256rm = 3934,

        VCVTNEPS2BF16Z256rmb = 3935,

        VCVTNEPS2BF16Z256rmbk = 3936,

        VCVTNEPS2BF16Z256rmbkz = 3937,

        VCVTNEPS2BF16Z256rmk = 3938,

        VCVTNEPS2BF16Z256rmkz = 3939,

        VCVTNEPS2BF16Z256rr = 3940,

        VCVTNEPS2BF16Z256rrk = 3941,

        VCVTNEPS2BF16Z256rrkz = 3942,

        VCVTNEPS2BF16Zrm = 3943,

        VCVTNEPS2BF16Zrmb = 3944,

        VCVTNEPS2BF16Zrmbk = 3945,

        VCVTNEPS2BF16Zrmbkz = 3946,

        VCVTNEPS2BF16Zrmk = 3947,

        VCVTNEPS2BF16Zrmkz = 3948,

        VCVTNEPS2BF16Zrr = 3949,

        VCVTNEPS2BF16Zrrk = 3950,

        VCVTNEPS2BF16Zrrkz = 3951,

        VCVTPD2DQYrm = 3952,

        VCVTPD2DQYrr = 3953,

        VCVTPD2DQZ128rm = 3954,

        VCVTPD2DQZ128rmb = 3955,

        VCVTPD2DQZ128rmbk = 3956,

        VCVTPD2DQZ128rmbkz = 3957,

        VCVTPD2DQZ128rmk = 3958,

        VCVTPD2DQZ128rmkz = 3959,

        VCVTPD2DQZ128rr = 3960,

        VCVTPD2DQZ128rrk = 3961,

        VCVTPD2DQZ128rrkz = 3962,

        VCVTPD2DQZ256rm = 3963,

        VCVTPD2DQZ256rmb = 3964,

        VCVTPD2DQZ256rmbk = 3965,

        VCVTPD2DQZ256rmbkz = 3966,

        VCVTPD2DQZ256rmk = 3967,

        VCVTPD2DQZ256rmkz = 3968,

        VCVTPD2DQZ256rr = 3969,

        VCVTPD2DQZ256rrk = 3970,

        VCVTPD2DQZ256rrkz = 3971,

        VCVTPD2DQZrm = 3972,

        VCVTPD2DQZrmb = 3973,

        VCVTPD2DQZrmbk = 3974,

        VCVTPD2DQZrmbkz = 3975,

        VCVTPD2DQZrmk = 3976,

        VCVTPD2DQZrmkz = 3977,

        VCVTPD2DQZrr = 3978,

        VCVTPD2DQZrrb = 3979,

        VCVTPD2DQZrrbk = 3980,

        VCVTPD2DQZrrbkz = 3981,

        VCVTPD2DQZrrk = 3982,

        VCVTPD2DQZrrkz = 3983,

        VCVTPD2DQrm = 3984,

        VCVTPD2DQrr = 3985,

        VCVTPD2PHZ128rm = 3986,

        VCVTPD2PHZ128rmb = 3987,

        VCVTPD2PHZ128rmbk = 3988,

        VCVTPD2PHZ128rmbkz = 3989,

        VCVTPD2PHZ128rmk = 3990,

        VCVTPD2PHZ128rmkz = 3991,

        VCVTPD2PHZ128rr = 3992,

        VCVTPD2PHZ128rrk = 3993,

        VCVTPD2PHZ128rrkz = 3994,

        VCVTPD2PHZ256rm = 3995,

        VCVTPD2PHZ256rmb = 3996,

        VCVTPD2PHZ256rmbk = 3997,

        VCVTPD2PHZ256rmbkz = 3998,

        VCVTPD2PHZ256rmk = 3999,

        VCVTPD2PHZ256rmkz = 4000,

        VCVTPD2PHZ256rr = 4001,

        VCVTPD2PHZ256rrk = 4002,

        VCVTPD2PHZ256rrkz = 4003,

        VCVTPD2PHZrm = 4004,

        VCVTPD2PHZrmb = 4005,

        VCVTPD2PHZrmbk = 4006,

        VCVTPD2PHZrmbkz = 4007,

        VCVTPD2PHZrmk = 4008,

        VCVTPD2PHZrmkz = 4009,

        VCVTPD2PHZrr = 4010,

        VCVTPD2PHZrrb = 4011,

        VCVTPD2PHZrrbk = 4012,

        VCVTPD2PHZrrbkz = 4013,

        VCVTPD2PHZrrk = 4014,

        VCVTPD2PHZrrkz = 4015,

        VCVTPD2PSYrm = 4016,

        VCVTPD2PSYrr = 4017,

        VCVTPD2PSZ128rm = 4018,

        VCVTPD2PSZ128rmb = 4019,

        VCVTPD2PSZ128rmbk = 4020,

        VCVTPD2PSZ128rmbkz = 4021,

        VCVTPD2PSZ128rmk = 4022,

        VCVTPD2PSZ128rmkz = 4023,

        VCVTPD2PSZ128rr = 4024,

        VCVTPD2PSZ128rrk = 4025,

        VCVTPD2PSZ128rrkz = 4026,

        VCVTPD2PSZ256rm = 4027,

        VCVTPD2PSZ256rmb = 4028,

        VCVTPD2PSZ256rmbk = 4029,

        VCVTPD2PSZ256rmbkz = 4030,

        VCVTPD2PSZ256rmk = 4031,

        VCVTPD2PSZ256rmkz = 4032,

        VCVTPD2PSZ256rr = 4033,

        VCVTPD2PSZ256rrk = 4034,

        VCVTPD2PSZ256rrkz = 4035,

        VCVTPD2PSZrm = 4036,

        VCVTPD2PSZrmb = 4037,

        VCVTPD2PSZrmbk = 4038,

        VCVTPD2PSZrmbkz = 4039,

        VCVTPD2PSZrmk = 4040,

        VCVTPD2PSZrmkz = 4041,

        VCVTPD2PSZrr = 4042,

        VCVTPD2PSZrrb = 4043,

        VCVTPD2PSZrrbk = 4044,

        VCVTPD2PSZrrbkz = 4045,

        VCVTPD2PSZrrk = 4046,

        VCVTPD2PSZrrkz = 4047,

        VCVTPD2PSrm = 4048,

        VCVTPD2PSrr = 4049,

        VCVTPD2QQZ128rm = 4050,

        VCVTPD2QQZ128rmb = 4051,

        VCVTPD2QQZ128rmbk = 4052,

        VCVTPD2QQZ128rmbkz = 4053,

        VCVTPD2QQZ128rmk = 4054,

        VCVTPD2QQZ128rmkz = 4055,

        VCVTPD2QQZ128rr = 4056,

        VCVTPD2QQZ128rrk = 4057,

        VCVTPD2QQZ128rrkz = 4058,

        VCVTPD2QQZ256rm = 4059,

        VCVTPD2QQZ256rmb = 4060,

        VCVTPD2QQZ256rmbk = 4061,

        VCVTPD2QQZ256rmbkz = 4062,

        VCVTPD2QQZ256rmk = 4063,

        VCVTPD2QQZ256rmkz = 4064,

        VCVTPD2QQZ256rr = 4065,

        VCVTPD2QQZ256rrk = 4066,

        VCVTPD2QQZ256rrkz = 4067,

        VCVTPD2QQZrm = 4068,

        VCVTPD2QQZrmb = 4069,

        VCVTPD2QQZrmbk = 4070,

        VCVTPD2QQZrmbkz = 4071,

        VCVTPD2QQZrmk = 4072,

        VCVTPD2QQZrmkz = 4073,

        VCVTPD2QQZrr = 4074,

        VCVTPD2QQZrrb = 4075,

        VCVTPD2QQZrrbk = 4076,

        VCVTPD2QQZrrbkz = 4077,

        VCVTPD2QQZrrk = 4078,

        VCVTPD2QQZrrkz = 4079,

        VCVTPD2UDQZ128rm = 4080,

        VCVTPD2UDQZ128rmb = 4081,

        VCVTPD2UDQZ128rmbk = 4082,

        VCVTPD2UDQZ128rmbkz = 4083,

        VCVTPD2UDQZ128rmk = 4084,

        VCVTPD2UDQZ128rmkz = 4085,

        VCVTPD2UDQZ128rr = 4086,

        VCVTPD2UDQZ128rrk = 4087,

        VCVTPD2UDQZ128rrkz = 4088,

        VCVTPD2UDQZ256rm = 4089,

        VCVTPD2UDQZ256rmb = 4090,

        VCVTPD2UDQZ256rmbk = 4091,

        VCVTPD2UDQZ256rmbkz = 4092,

        VCVTPD2UDQZ256rmk = 4093,

        VCVTPD2UDQZ256rmkz = 4094,

        VCVTPD2UDQZ256rr = 4095,

        VCVTPD2UDQZ256rrk = 4096,

        VCVTPD2UDQZ256rrkz = 4097,

        VCVTPD2UDQZrm = 4098,

        VCVTPD2UDQZrmb = 4099,

        VCVTPD2UDQZrmbk = 4100,

        VCVTPD2UDQZrmbkz = 4101,

        VCVTPD2UDQZrmk = 4102,

        VCVTPD2UDQZrmkz = 4103,

        VCVTPD2UDQZrr = 4104,

        VCVTPD2UDQZrrb = 4105,

        VCVTPD2UDQZrrbk = 4106,

        VCVTPD2UDQZrrbkz = 4107,

        VCVTPD2UDQZrrk = 4108,

        VCVTPD2UDQZrrkz = 4109,

        VCVTPD2UQQZ128rm = 4110,

        VCVTPD2UQQZ128rmb = 4111,

        VCVTPD2UQQZ128rmbk = 4112,

        VCVTPD2UQQZ128rmbkz = 4113,

        VCVTPD2UQQZ128rmk = 4114,

        VCVTPD2UQQZ128rmkz = 4115,

        VCVTPD2UQQZ128rr = 4116,

        VCVTPD2UQQZ128rrk = 4117,

        VCVTPD2UQQZ128rrkz = 4118,

        VCVTPD2UQQZ256rm = 4119,

        VCVTPD2UQQZ256rmb = 4120,

        VCVTPD2UQQZ256rmbk = 4121,

        VCVTPD2UQQZ256rmbkz = 4122,

        VCVTPD2UQQZ256rmk = 4123,

        VCVTPD2UQQZ256rmkz = 4124,

        VCVTPD2UQQZ256rr = 4125,

        VCVTPD2UQQZ256rrk = 4126,

        VCVTPD2UQQZ256rrkz = 4127,

        VCVTPD2UQQZrm = 4128,

        VCVTPD2UQQZrmb = 4129,

        VCVTPD2UQQZrmbk = 4130,

        VCVTPD2UQQZrmbkz = 4131,

        VCVTPD2UQQZrmk = 4132,

        VCVTPD2UQQZrmkz = 4133,

        VCVTPD2UQQZrr = 4134,

        VCVTPD2UQQZrrb = 4135,

        VCVTPD2UQQZrrbk = 4136,

        VCVTPD2UQQZrrbkz = 4137,

        VCVTPD2UQQZrrk = 4138,

        VCVTPD2UQQZrrkz = 4139,

        VCVTPH2DQZ128rm = 4140,

        VCVTPH2DQZ128rmb = 4141,

        VCVTPH2DQZ128rmbk = 4142,

        VCVTPH2DQZ128rmbkz = 4143,

        VCVTPH2DQZ128rmk = 4144,

        VCVTPH2DQZ128rmkz = 4145,

        VCVTPH2DQZ128rr = 4146,

        VCVTPH2DQZ128rrk = 4147,

        VCVTPH2DQZ128rrkz = 4148,

        VCVTPH2DQZ256rm = 4149,

        VCVTPH2DQZ256rmb = 4150,

        VCVTPH2DQZ256rmbk = 4151,

        VCVTPH2DQZ256rmbkz = 4152,

        VCVTPH2DQZ256rmk = 4153,

        VCVTPH2DQZ256rmkz = 4154,

        VCVTPH2DQZ256rr = 4155,

        VCVTPH2DQZ256rrk = 4156,

        VCVTPH2DQZ256rrkz = 4157,

        VCVTPH2DQZrm = 4158,

        VCVTPH2DQZrmb = 4159,

        VCVTPH2DQZrmbk = 4160,

        VCVTPH2DQZrmbkz = 4161,

        VCVTPH2DQZrmk = 4162,

        VCVTPH2DQZrmkz = 4163,

        VCVTPH2DQZrr = 4164,

        VCVTPH2DQZrrb = 4165,

        VCVTPH2DQZrrbk = 4166,

        VCVTPH2DQZrrbkz = 4167,

        VCVTPH2DQZrrk = 4168,

        VCVTPH2DQZrrkz = 4169,

        VCVTPH2PDZ128rm = 4170,

        VCVTPH2PDZ128rmb = 4171,

        VCVTPH2PDZ128rmbk = 4172,

        VCVTPH2PDZ128rmbkz = 4173,

        VCVTPH2PDZ128rmk = 4174,

        VCVTPH2PDZ128rmkz = 4175,

        VCVTPH2PDZ128rr = 4176,

        VCVTPH2PDZ128rrk = 4177,

        VCVTPH2PDZ128rrkz = 4178,

        VCVTPH2PDZ256rm = 4179,

        VCVTPH2PDZ256rmb = 4180,

        VCVTPH2PDZ256rmbk = 4181,

        VCVTPH2PDZ256rmbkz = 4182,

        VCVTPH2PDZ256rmk = 4183,

        VCVTPH2PDZ256rmkz = 4184,

        VCVTPH2PDZ256rr = 4185,

        VCVTPH2PDZ256rrk = 4186,

        VCVTPH2PDZ256rrkz = 4187,

        VCVTPH2PDZrm = 4188,

        VCVTPH2PDZrmb = 4189,

        VCVTPH2PDZrmbk = 4190,

        VCVTPH2PDZrmbkz = 4191,

        VCVTPH2PDZrmk = 4192,

        VCVTPH2PDZrmkz = 4193,

        VCVTPH2PDZrr = 4194,

        VCVTPH2PDZrrb = 4195,

        VCVTPH2PDZrrbk = 4196,

        VCVTPH2PDZrrbkz = 4197,

        VCVTPH2PDZrrk = 4198,

        VCVTPH2PDZrrkz = 4199,

        VCVTPH2PSXZ128rm = 4200,

        VCVTPH2PSXZ128rmb = 4201,

        VCVTPH2PSXZ128rmbk = 4202,

        VCVTPH2PSXZ128rmbkz = 4203,

        VCVTPH2PSXZ128rmk = 4204,

        VCVTPH2PSXZ128rmkz = 4205,

        VCVTPH2PSXZ128rr = 4206,

        VCVTPH2PSXZ128rrk = 4207,

        VCVTPH2PSXZ128rrkz = 4208,

        VCVTPH2PSXZ256rm = 4209,

        VCVTPH2PSXZ256rmb = 4210,

        VCVTPH2PSXZ256rmbk = 4211,

        VCVTPH2PSXZ256rmbkz = 4212,

        VCVTPH2PSXZ256rmk = 4213,

        VCVTPH2PSXZ256rmkz = 4214,

        VCVTPH2PSXZ256rr = 4215,

        VCVTPH2PSXZ256rrk = 4216,

        VCVTPH2PSXZ256rrkz = 4217,

        VCVTPH2PSXZrm = 4218,

        VCVTPH2PSXZrmb = 4219,

        VCVTPH2PSXZrmbk = 4220,

        VCVTPH2PSXZrmbkz = 4221,

        VCVTPH2PSXZrmk = 4222,

        VCVTPH2PSXZrmkz = 4223,

        VCVTPH2PSXZrr = 4224,

        VCVTPH2PSXZrrb = 4225,

        VCVTPH2PSXZrrbk = 4226,

        VCVTPH2PSXZrrbkz = 4227,

        VCVTPH2PSXZrrk = 4228,

        VCVTPH2PSXZrrkz = 4229,

        VCVTPH2PSYrm = 4230,

        VCVTPH2PSYrr = 4231,

        VCVTPH2PSZ128rm = 4232,

        VCVTPH2PSZ128rmk = 4233,

        VCVTPH2PSZ128rmkz = 4234,

        VCVTPH2PSZ128rr = 4235,

        VCVTPH2PSZ128rrk = 4236,

        VCVTPH2PSZ128rrkz = 4237,

        VCVTPH2PSZ256rm = 4238,

        VCVTPH2PSZ256rmk = 4239,

        VCVTPH2PSZ256rmkz = 4240,

        VCVTPH2PSZ256rr = 4241,

        VCVTPH2PSZ256rrk = 4242,

        VCVTPH2PSZ256rrkz = 4243,

        VCVTPH2PSZrm = 4244,

        VCVTPH2PSZrmk = 4245,

        VCVTPH2PSZrmkz = 4246,

        VCVTPH2PSZrr = 4247,

        VCVTPH2PSZrrb = 4248,

        VCVTPH2PSZrrbk = 4249,

        VCVTPH2PSZrrbkz = 4250,

        VCVTPH2PSZrrk = 4251,

        VCVTPH2PSZrrkz = 4252,

        VCVTPH2PSrm = 4253,

        VCVTPH2PSrr = 4254,

        VCVTPH2QQZ128rm = 4255,

        VCVTPH2QQZ128rmb = 4256,

        VCVTPH2QQZ128rmbk = 4257,

        VCVTPH2QQZ128rmbkz = 4258,

        VCVTPH2QQZ128rmk = 4259,

        VCVTPH2QQZ128rmkz = 4260,

        VCVTPH2QQZ128rr = 4261,

        VCVTPH2QQZ128rrk = 4262,

        VCVTPH2QQZ128rrkz = 4263,

        VCVTPH2QQZ256rm = 4264,

        VCVTPH2QQZ256rmb = 4265,

        VCVTPH2QQZ256rmbk = 4266,

        VCVTPH2QQZ256rmbkz = 4267,

        VCVTPH2QQZ256rmk = 4268,

        VCVTPH2QQZ256rmkz = 4269,

        VCVTPH2QQZ256rr = 4270,

        VCVTPH2QQZ256rrk = 4271,

        VCVTPH2QQZ256rrkz = 4272,

        VCVTPH2QQZrm = 4273,

        VCVTPH2QQZrmb = 4274,

        VCVTPH2QQZrmbk = 4275,

        VCVTPH2QQZrmbkz = 4276,

        VCVTPH2QQZrmk = 4277,

        VCVTPH2QQZrmkz = 4278,

        VCVTPH2QQZrr = 4279,

        VCVTPH2QQZrrb = 4280,

        VCVTPH2QQZrrbk = 4281,

        VCVTPH2QQZrrbkz = 4282,

        VCVTPH2QQZrrk = 4283,

        VCVTPH2QQZrrkz = 4284,

        VCVTPH2UDQZ128rm = 4285,

        VCVTPH2UDQZ128rmb = 4286,

        VCVTPH2UDQZ128rmbk = 4287,

        VCVTPH2UDQZ128rmbkz = 4288,

        VCVTPH2UDQZ128rmk = 4289,

        VCVTPH2UDQZ128rmkz = 4290,

        VCVTPH2UDQZ128rr = 4291,

        VCVTPH2UDQZ128rrk = 4292,

        VCVTPH2UDQZ128rrkz = 4293,

        VCVTPH2UDQZ256rm = 4294,

        VCVTPH2UDQZ256rmb = 4295,

        VCVTPH2UDQZ256rmbk = 4296,

        VCVTPH2UDQZ256rmbkz = 4297,

        VCVTPH2UDQZ256rmk = 4298,

        VCVTPH2UDQZ256rmkz = 4299,

        VCVTPH2UDQZ256rr = 4300,

        VCVTPH2UDQZ256rrk = 4301,

        VCVTPH2UDQZ256rrkz = 4302,

        VCVTPH2UDQZrm = 4303,

        VCVTPH2UDQZrmb = 4304,

        VCVTPH2UDQZrmbk = 4305,

        VCVTPH2UDQZrmbkz = 4306,

        VCVTPH2UDQZrmk = 4307,

        VCVTPH2UDQZrmkz = 4308,

        VCVTPH2UDQZrr = 4309,

        VCVTPH2UDQZrrb = 4310,

        VCVTPH2UDQZrrbk = 4311,

        VCVTPH2UDQZrrbkz = 4312,

        VCVTPH2UDQZrrk = 4313,

        VCVTPH2UDQZrrkz = 4314,

        VCVTPH2UQQZ128rm = 4315,

        VCVTPH2UQQZ128rmb = 4316,

        VCVTPH2UQQZ128rmbk = 4317,

        VCVTPH2UQQZ128rmbkz = 4318,

        VCVTPH2UQQZ128rmk = 4319,

        VCVTPH2UQQZ128rmkz = 4320,

        VCVTPH2UQQZ128rr = 4321,

        VCVTPH2UQQZ128rrk = 4322,

        VCVTPH2UQQZ128rrkz = 4323,

        VCVTPH2UQQZ256rm = 4324,

        VCVTPH2UQQZ256rmb = 4325,

        VCVTPH2UQQZ256rmbk = 4326,

        VCVTPH2UQQZ256rmbkz = 4327,

        VCVTPH2UQQZ256rmk = 4328,

        VCVTPH2UQQZ256rmkz = 4329,

        VCVTPH2UQQZ256rr = 4330,

        VCVTPH2UQQZ256rrk = 4331,

        VCVTPH2UQQZ256rrkz = 4332,

        VCVTPH2UQQZrm = 4333,

        VCVTPH2UQQZrmb = 4334,

        VCVTPH2UQQZrmbk = 4335,

        VCVTPH2UQQZrmbkz = 4336,

        VCVTPH2UQQZrmk = 4337,

        VCVTPH2UQQZrmkz = 4338,

        VCVTPH2UQQZrr = 4339,

        VCVTPH2UQQZrrb = 4340,

        VCVTPH2UQQZrrbk = 4341,

        VCVTPH2UQQZrrbkz = 4342,

        VCVTPH2UQQZrrk = 4343,

        VCVTPH2UQQZrrkz = 4344,

        VCVTPH2UWZ128rm = 4345,

        VCVTPH2UWZ128rmb = 4346,

        VCVTPH2UWZ128rmbk = 4347,

        VCVTPH2UWZ128rmbkz = 4348,

        VCVTPH2UWZ128rmk = 4349,

        VCVTPH2UWZ128rmkz = 4350,

        VCVTPH2UWZ128rr = 4351,

        VCVTPH2UWZ128rrk = 4352,

        VCVTPH2UWZ128rrkz = 4353,

        VCVTPH2UWZ256rm = 4354,

        VCVTPH2UWZ256rmb = 4355,

        VCVTPH2UWZ256rmbk = 4356,

        VCVTPH2UWZ256rmbkz = 4357,

        VCVTPH2UWZ256rmk = 4358,

        VCVTPH2UWZ256rmkz = 4359,

        VCVTPH2UWZ256rr = 4360,

        VCVTPH2UWZ256rrk = 4361,

        VCVTPH2UWZ256rrkz = 4362,

        VCVTPH2UWZrm = 4363,

        VCVTPH2UWZrmb = 4364,

        VCVTPH2UWZrmbk = 4365,

        VCVTPH2UWZrmbkz = 4366,

        VCVTPH2UWZrmk = 4367,

        VCVTPH2UWZrmkz = 4368,

        VCVTPH2UWZrr = 4369,

        VCVTPH2UWZrrb = 4370,

        VCVTPH2UWZrrbk = 4371,

        VCVTPH2UWZrrbkz = 4372,

        VCVTPH2UWZrrk = 4373,

        VCVTPH2UWZrrkz = 4374,

        VCVTPH2WZ128rm = 4375,

        VCVTPH2WZ128rmb = 4376,

        VCVTPH2WZ128rmbk = 4377,

        VCVTPH2WZ128rmbkz = 4378,

        VCVTPH2WZ128rmk = 4379,

        VCVTPH2WZ128rmkz = 4380,

        VCVTPH2WZ128rr = 4381,

        VCVTPH2WZ128rrk = 4382,

        VCVTPH2WZ128rrkz = 4383,

        VCVTPH2WZ256rm = 4384,

        VCVTPH2WZ256rmb = 4385,

        VCVTPH2WZ256rmbk = 4386,

        VCVTPH2WZ256rmbkz = 4387,

        VCVTPH2WZ256rmk = 4388,

        VCVTPH2WZ256rmkz = 4389,

        VCVTPH2WZ256rr = 4390,

        VCVTPH2WZ256rrk = 4391,

        VCVTPH2WZ256rrkz = 4392,

        VCVTPH2WZrm = 4393,

        VCVTPH2WZrmb = 4394,

        VCVTPH2WZrmbk = 4395,

        VCVTPH2WZrmbkz = 4396,

        VCVTPH2WZrmk = 4397,

        VCVTPH2WZrmkz = 4398,

        VCVTPH2WZrr = 4399,

        VCVTPH2WZrrb = 4400,

        VCVTPH2WZrrbk = 4401,

        VCVTPH2WZrrbkz = 4402,

        VCVTPH2WZrrk = 4403,

        VCVTPH2WZrrkz = 4404,

        VCVTPS2DQYrm = 4405,

        VCVTPS2DQYrr = 4406,

        VCVTPS2DQZ128rm = 4407,

        VCVTPS2DQZ128rmb = 4408,

        VCVTPS2DQZ128rmbk = 4409,

        VCVTPS2DQZ128rmbkz = 4410,

        VCVTPS2DQZ128rmk = 4411,

        VCVTPS2DQZ128rmkz = 4412,

        VCVTPS2DQZ128rr = 4413,

        VCVTPS2DQZ128rrk = 4414,

        VCVTPS2DQZ128rrkz = 4415,

        VCVTPS2DQZ256rm = 4416,

        VCVTPS2DQZ256rmb = 4417,

        VCVTPS2DQZ256rmbk = 4418,

        VCVTPS2DQZ256rmbkz = 4419,

        VCVTPS2DQZ256rmk = 4420,

        VCVTPS2DQZ256rmkz = 4421,

        VCVTPS2DQZ256rr = 4422,

        VCVTPS2DQZ256rrk = 4423,

        VCVTPS2DQZ256rrkz = 4424,

        VCVTPS2DQZrm = 4425,

        VCVTPS2DQZrmb = 4426,

        VCVTPS2DQZrmbk = 4427,

        VCVTPS2DQZrmbkz = 4428,

        VCVTPS2DQZrmk = 4429,

        VCVTPS2DQZrmkz = 4430,

        VCVTPS2DQZrr = 4431,

        VCVTPS2DQZrrb = 4432,

        VCVTPS2DQZrrbk = 4433,

        VCVTPS2DQZrrbkz = 4434,

        VCVTPS2DQZrrk = 4435,

        VCVTPS2DQZrrkz = 4436,

        VCVTPS2DQrm = 4437,

        VCVTPS2DQrr = 4438,

        VCVTPS2PDYrm = 4439,

        VCVTPS2PDYrr = 4440,

        VCVTPS2PDZ128rm = 4441,

        VCVTPS2PDZ128rmb = 4442,

        VCVTPS2PDZ128rmbk = 4443,

        VCVTPS2PDZ128rmbkz = 4444,

        VCVTPS2PDZ128rmk = 4445,

        VCVTPS2PDZ128rmkz = 4446,

        VCVTPS2PDZ128rr = 4447,

        VCVTPS2PDZ128rrk = 4448,

        VCVTPS2PDZ128rrkz = 4449,

        VCVTPS2PDZ256rm = 4450,

        VCVTPS2PDZ256rmb = 4451,

        VCVTPS2PDZ256rmbk = 4452,

        VCVTPS2PDZ256rmbkz = 4453,

        VCVTPS2PDZ256rmk = 4454,

        VCVTPS2PDZ256rmkz = 4455,

        VCVTPS2PDZ256rr = 4456,

        VCVTPS2PDZ256rrk = 4457,

        VCVTPS2PDZ256rrkz = 4458,

        VCVTPS2PDZrm = 4459,

        VCVTPS2PDZrmb = 4460,

        VCVTPS2PDZrmbk = 4461,

        VCVTPS2PDZrmbkz = 4462,

        VCVTPS2PDZrmk = 4463,

        VCVTPS2PDZrmkz = 4464,

        VCVTPS2PDZrr = 4465,

        VCVTPS2PDZrrb = 4466,

        VCVTPS2PDZrrbk = 4467,

        VCVTPS2PDZrrbkz = 4468,

        VCVTPS2PDZrrk = 4469,

        VCVTPS2PDZrrkz = 4470,

        VCVTPS2PDrm = 4471,

        VCVTPS2PDrr = 4472,

        VCVTPS2PHXZ128rm = 4473,

        VCVTPS2PHXZ128rmb = 4474,

        VCVTPS2PHXZ128rmbk = 4475,

        VCVTPS2PHXZ128rmbkz = 4476,

        VCVTPS2PHXZ128rmk = 4477,

        VCVTPS2PHXZ128rmkz = 4478,

        VCVTPS2PHXZ128rr = 4479,

        VCVTPS2PHXZ128rrk = 4480,

        VCVTPS2PHXZ128rrkz = 4481,

        VCVTPS2PHXZ256rm = 4482,

        VCVTPS2PHXZ256rmb = 4483,

        VCVTPS2PHXZ256rmbk = 4484,

        VCVTPS2PHXZ256rmbkz = 4485,

        VCVTPS2PHXZ256rmk = 4486,

        VCVTPS2PHXZ256rmkz = 4487,

        VCVTPS2PHXZ256rr = 4488,

        VCVTPS2PHXZ256rrk = 4489,

        VCVTPS2PHXZ256rrkz = 4490,

        VCVTPS2PHXZrm = 4491,

        VCVTPS2PHXZrmb = 4492,

        VCVTPS2PHXZrmbk = 4493,

        VCVTPS2PHXZrmbkz = 4494,

        VCVTPS2PHXZrmk = 4495,

        VCVTPS2PHXZrmkz = 4496,

        VCVTPS2PHXZrr = 4497,

        VCVTPS2PHXZrrb = 4498,

        VCVTPS2PHXZrrbk = 4499,

        VCVTPS2PHXZrrbkz = 4500,

        VCVTPS2PHXZrrk = 4501,

        VCVTPS2PHXZrrkz = 4502,

        VCVTPS2PHYmr = 4503,

        VCVTPS2PHYrr = 4504,

        VCVTPS2PHZ128mr = 4505,

        VCVTPS2PHZ128mrk = 4506,

        VCVTPS2PHZ128rr = 4507,

        VCVTPS2PHZ128rrk = 4508,

        VCVTPS2PHZ128rrkz = 4509,

        VCVTPS2PHZ256mr = 4510,

        VCVTPS2PHZ256mrk = 4511,

        VCVTPS2PHZ256rr = 4512,

        VCVTPS2PHZ256rrk = 4513,

        VCVTPS2PHZ256rrkz = 4514,

        VCVTPS2PHZmr = 4515,

        VCVTPS2PHZmrk = 4516,

        VCVTPS2PHZrr = 4517,

        VCVTPS2PHZrrb = 4518,

        VCVTPS2PHZrrbk = 4519,

        VCVTPS2PHZrrbkz = 4520,

        VCVTPS2PHZrrk = 4521,

        VCVTPS2PHZrrkz = 4522,

        VCVTPS2PHmr = 4523,

        VCVTPS2PHrr = 4524,

        VCVTPS2QQZ128rm = 4525,

        VCVTPS2QQZ128rmb = 4526,

        VCVTPS2QQZ128rmbk = 4527,

        VCVTPS2QQZ128rmbkz = 4528,

        VCVTPS2QQZ128rmk = 4529,

        VCVTPS2QQZ128rmkz = 4530,

        VCVTPS2QQZ128rr = 4531,

        VCVTPS2QQZ128rrk = 4532,

        VCVTPS2QQZ128rrkz = 4533,

        VCVTPS2QQZ256rm = 4534,

        VCVTPS2QQZ256rmb = 4535,

        VCVTPS2QQZ256rmbk = 4536,

        VCVTPS2QQZ256rmbkz = 4537,

        VCVTPS2QQZ256rmk = 4538,

        VCVTPS2QQZ256rmkz = 4539,

        VCVTPS2QQZ256rr = 4540,

        VCVTPS2QQZ256rrk = 4541,

        VCVTPS2QQZ256rrkz = 4542,

        VCVTPS2QQZrm = 4543,

        VCVTPS2QQZrmb = 4544,

        VCVTPS2QQZrmbk = 4545,

        VCVTPS2QQZrmbkz = 4546,

        VCVTPS2QQZrmk = 4547,

        VCVTPS2QQZrmkz = 4548,

        VCVTPS2QQZrr = 4549,

        VCVTPS2QQZrrb = 4550,

        VCVTPS2QQZrrbk = 4551,

        VCVTPS2QQZrrbkz = 4552,

        VCVTPS2QQZrrk = 4553,

        VCVTPS2QQZrrkz = 4554,

        VCVTPS2UDQZ128rm = 4555,

        VCVTPS2UDQZ128rmb = 4556,

        VCVTPS2UDQZ128rmbk = 4557,

        VCVTPS2UDQZ128rmbkz = 4558,

        VCVTPS2UDQZ128rmk = 4559,

        VCVTPS2UDQZ128rmkz = 4560,

        VCVTPS2UDQZ128rr = 4561,

        VCVTPS2UDQZ128rrk = 4562,

        VCVTPS2UDQZ128rrkz = 4563,

        VCVTPS2UDQZ256rm = 4564,

        VCVTPS2UDQZ256rmb = 4565,

        VCVTPS2UDQZ256rmbk = 4566,

        VCVTPS2UDQZ256rmbkz = 4567,

        VCVTPS2UDQZ256rmk = 4568,

        VCVTPS2UDQZ256rmkz = 4569,

        VCVTPS2UDQZ256rr = 4570,

        VCVTPS2UDQZ256rrk = 4571,

        VCVTPS2UDQZ256rrkz = 4572,

        VCVTPS2UDQZrm = 4573,

        VCVTPS2UDQZrmb = 4574,

        VCVTPS2UDQZrmbk = 4575,

        VCVTPS2UDQZrmbkz = 4576,

        VCVTPS2UDQZrmk = 4577,

        VCVTPS2UDQZrmkz = 4578,

        VCVTPS2UDQZrr = 4579,

        VCVTPS2UDQZrrb = 4580,

        VCVTPS2UDQZrrbk = 4581,

        VCVTPS2UDQZrrbkz = 4582,

        VCVTPS2UDQZrrk = 4583,

        VCVTPS2UDQZrrkz = 4584,

        VCVTPS2UQQZ128rm = 4585,

        VCVTPS2UQQZ128rmb = 4586,

        VCVTPS2UQQZ128rmbk = 4587,

        VCVTPS2UQQZ128rmbkz = 4588,

        VCVTPS2UQQZ128rmk = 4589,

        VCVTPS2UQQZ128rmkz = 4590,

        VCVTPS2UQQZ128rr = 4591,

        VCVTPS2UQQZ128rrk = 4592,

        VCVTPS2UQQZ128rrkz = 4593,

        VCVTPS2UQQZ256rm = 4594,

        VCVTPS2UQQZ256rmb = 4595,

        VCVTPS2UQQZ256rmbk = 4596,

        VCVTPS2UQQZ256rmbkz = 4597,

        VCVTPS2UQQZ256rmk = 4598,

        VCVTPS2UQQZ256rmkz = 4599,

        VCVTPS2UQQZ256rr = 4600,

        VCVTPS2UQQZ256rrk = 4601,

        VCVTPS2UQQZ256rrkz = 4602,

        VCVTPS2UQQZrm = 4603,

        VCVTPS2UQQZrmb = 4604,

        VCVTPS2UQQZrmbk = 4605,

        VCVTPS2UQQZrmbkz = 4606,

        VCVTPS2UQQZrmk = 4607,

        VCVTPS2UQQZrmkz = 4608,

        VCVTPS2UQQZrr = 4609,

        VCVTPS2UQQZrrb = 4610,

        VCVTPS2UQQZrrbk = 4611,

        VCVTPS2UQQZrrbkz = 4612,

        VCVTPS2UQQZrrk = 4613,

        VCVTPS2UQQZrrkz = 4614,

        VCVTQQ2PDZ128rm = 4615,

        VCVTQQ2PDZ128rmb = 4616,

        VCVTQQ2PDZ128rmbk = 4617,

        VCVTQQ2PDZ128rmbkz = 4618,

        VCVTQQ2PDZ128rmk = 4619,

        VCVTQQ2PDZ128rmkz = 4620,

        VCVTQQ2PDZ128rr = 4621,

        VCVTQQ2PDZ128rrk = 4622,

        VCVTQQ2PDZ128rrkz = 4623,

        VCVTQQ2PDZ256rm = 4624,

        VCVTQQ2PDZ256rmb = 4625,

        VCVTQQ2PDZ256rmbk = 4626,

        VCVTQQ2PDZ256rmbkz = 4627,

        VCVTQQ2PDZ256rmk = 4628,

        VCVTQQ2PDZ256rmkz = 4629,

        VCVTQQ2PDZ256rr = 4630,

        VCVTQQ2PDZ256rrk = 4631,

        VCVTQQ2PDZ256rrkz = 4632,

        VCVTQQ2PDZrm = 4633,

        VCVTQQ2PDZrmb = 4634,

        VCVTQQ2PDZrmbk = 4635,

        VCVTQQ2PDZrmbkz = 4636,

        VCVTQQ2PDZrmk = 4637,

        VCVTQQ2PDZrmkz = 4638,

        VCVTQQ2PDZrr = 4639,

        VCVTQQ2PDZrrb = 4640,

        VCVTQQ2PDZrrbk = 4641,

        VCVTQQ2PDZrrbkz = 4642,

        VCVTQQ2PDZrrk = 4643,

        VCVTQQ2PDZrrkz = 4644,

        VCVTQQ2PHZ128rm = 4645,

        VCVTQQ2PHZ128rmb = 4646,

        VCVTQQ2PHZ128rmbk = 4647,

        VCVTQQ2PHZ128rmbkz = 4648,

        VCVTQQ2PHZ128rmk = 4649,

        VCVTQQ2PHZ128rmkz = 4650,

        VCVTQQ2PHZ128rr = 4651,

        VCVTQQ2PHZ128rrk = 4652,

        VCVTQQ2PHZ128rrkz = 4653,

        VCVTQQ2PHZ256rm = 4654,

        VCVTQQ2PHZ256rmb = 4655,

        VCVTQQ2PHZ256rmbk = 4656,

        VCVTQQ2PHZ256rmbkz = 4657,

        VCVTQQ2PHZ256rmk = 4658,

        VCVTQQ2PHZ256rmkz = 4659,

        VCVTQQ2PHZ256rr = 4660,

        VCVTQQ2PHZ256rrk = 4661,

        VCVTQQ2PHZ256rrkz = 4662,

        VCVTQQ2PHZrm = 4663,

        VCVTQQ2PHZrmb = 4664,

        VCVTQQ2PHZrmbk = 4665,

        VCVTQQ2PHZrmbkz = 4666,

        VCVTQQ2PHZrmk = 4667,

        VCVTQQ2PHZrmkz = 4668,

        VCVTQQ2PHZrr = 4669,

        VCVTQQ2PHZrrb = 4670,

        VCVTQQ2PHZrrbk = 4671,

        VCVTQQ2PHZrrbkz = 4672,

        VCVTQQ2PHZrrk = 4673,

        VCVTQQ2PHZrrkz = 4674,

        VCVTQQ2PSZ128rm = 4675,

        VCVTQQ2PSZ128rmb = 4676,

        VCVTQQ2PSZ128rmbk = 4677,

        VCVTQQ2PSZ128rmbkz = 4678,

        VCVTQQ2PSZ128rmk = 4679,

        VCVTQQ2PSZ128rmkz = 4680,

        VCVTQQ2PSZ128rr = 4681,

        VCVTQQ2PSZ128rrk = 4682,

        VCVTQQ2PSZ128rrkz = 4683,

        VCVTQQ2PSZ256rm = 4684,

        VCVTQQ2PSZ256rmb = 4685,

        VCVTQQ2PSZ256rmbk = 4686,

        VCVTQQ2PSZ256rmbkz = 4687,

        VCVTQQ2PSZ256rmk = 4688,

        VCVTQQ2PSZ256rmkz = 4689,

        VCVTQQ2PSZ256rr = 4690,

        VCVTQQ2PSZ256rrk = 4691,

        VCVTQQ2PSZ256rrkz = 4692,

        VCVTQQ2PSZrm = 4693,

        VCVTQQ2PSZrmb = 4694,

        VCVTQQ2PSZrmbk = 4695,

        VCVTQQ2PSZrmbkz = 4696,

        VCVTQQ2PSZrmk = 4697,

        VCVTQQ2PSZrmkz = 4698,

        VCVTQQ2PSZrr = 4699,

        VCVTQQ2PSZrrb = 4700,

        VCVTQQ2PSZrrbk = 4701,

        VCVTQQ2PSZrrbkz = 4702,

        VCVTQQ2PSZrrk = 4703,

        VCVTQQ2PSZrrkz = 4704,

        VCVTSD2SHZrm = 4705,

        VCVTSD2SHZrm_Int = 4706,

        VCVTSD2SHZrm_Intk = 4707,

        VCVTSD2SHZrm_Intkz = 4708,

        VCVTSD2SHZrr = 4709,

        VCVTSD2SHZrr_Int = 4710,

        VCVTSD2SHZrr_Intk = 4711,

        VCVTSD2SHZrr_Intkz = 4712,

        VCVTSD2SHZrrb_Int = 4713,

        VCVTSD2SHZrrb_Intk = 4714,

        VCVTSD2SHZrrb_Intkz = 4715,

        VCVTSD2SI64Zrm = 4716,

        VCVTSD2SI64Zrm_Int = 4717,

        VCVTSD2SI64Zrr = 4718,

        VCVTSD2SI64Zrr_Int = 4719,

        VCVTSD2SI64Zrrb_Int = 4720,

        VCVTSD2SI64rm = 4721,

        VCVTSD2SI64rm_Int = 4722,

        VCVTSD2SI64rr = 4723,

        VCVTSD2SI64rr_Int = 4724,

        VCVTSD2SIZrm = 4725,

        VCVTSD2SIZrm_Int = 4726,

        VCVTSD2SIZrr = 4727,

        VCVTSD2SIZrr_Int = 4728,

        VCVTSD2SIZrrb_Int = 4729,

        VCVTSD2SIrm = 4730,

        VCVTSD2SIrm_Int = 4731,

        VCVTSD2SIrr = 4732,

        VCVTSD2SIrr_Int = 4733,

        VCVTSD2SSZrm = 4734,

        VCVTSD2SSZrm_Int = 4735,

        VCVTSD2SSZrm_Intk = 4736,

        VCVTSD2SSZrm_Intkz = 4737,

        VCVTSD2SSZrr = 4738,

        VCVTSD2SSZrr_Int = 4739,

        VCVTSD2SSZrr_Intk = 4740,

        VCVTSD2SSZrr_Intkz = 4741,

        VCVTSD2SSZrrb_Int = 4742,

        VCVTSD2SSZrrb_Intk = 4743,

        VCVTSD2SSZrrb_Intkz = 4744,

        VCVTSD2SSrm = 4745,

        VCVTSD2SSrm_Int = 4746,

        VCVTSD2SSrr = 4747,

        VCVTSD2SSrr_Int = 4748,

        VCVTSD2USI64Zrm_Int = 4749,

        VCVTSD2USI64Zrr_Int = 4750,

        VCVTSD2USI64Zrrb_Int = 4751,

        VCVTSD2USIZrm_Int = 4752,

        VCVTSD2USIZrr_Int = 4753,

        VCVTSD2USIZrrb_Int = 4754,

        VCVTSH2SDZrm = 4755,

        VCVTSH2SDZrm_Int = 4756,

        VCVTSH2SDZrm_Intk = 4757,

        VCVTSH2SDZrm_Intkz = 4758,

        VCVTSH2SDZrr = 4759,

        VCVTSH2SDZrr_Int = 4760,

        VCVTSH2SDZrr_Intk = 4761,

        VCVTSH2SDZrr_Intkz = 4762,

        VCVTSH2SDZrrb_Int = 4763,

        VCVTSH2SDZrrb_Intk = 4764,

        VCVTSH2SDZrrb_Intkz = 4765,

        VCVTSH2SI64Zrm_Int = 4766,

        VCVTSH2SI64Zrr_Int = 4767,

        VCVTSH2SI64Zrrb_Int = 4768,

        VCVTSH2SIZrm_Int = 4769,

        VCVTSH2SIZrr_Int = 4770,

        VCVTSH2SIZrrb_Int = 4771,

        VCVTSH2SSZrm = 4772,

        VCVTSH2SSZrm_Int = 4773,

        VCVTSH2SSZrm_Intk = 4774,

        VCVTSH2SSZrm_Intkz = 4775,

        VCVTSH2SSZrr = 4776,

        VCVTSH2SSZrr_Int = 4777,

        VCVTSH2SSZrr_Intk = 4778,

        VCVTSH2SSZrr_Intkz = 4779,

        VCVTSH2SSZrrb_Int = 4780,

        VCVTSH2SSZrrb_Intk = 4781,

        VCVTSH2SSZrrb_Intkz = 4782,

        VCVTSH2USI64Zrm_Int = 4783,

        VCVTSH2USI64Zrr_Int = 4784,

        VCVTSH2USI64Zrrb_Int = 4785,

        VCVTSH2USIZrm_Int = 4786,

        VCVTSH2USIZrr_Int = 4787,

        VCVTSH2USIZrrb_Int = 4788,

        VCVTSI2SDZrm = 4789,

        VCVTSI2SDZrm_Int = 4790,

        VCVTSI2SDZrr = 4791,

        VCVTSI2SDZrr_Int = 4792,

        VCVTSI2SDrm = 4793,

        VCVTSI2SDrm_Int = 4794,

        VCVTSI2SDrr = 4795,

        VCVTSI2SDrr_Int = 4796,

        VCVTSI2SHZrm = 4797,

        VCVTSI2SHZrm_Int = 4798,

        VCVTSI2SHZrr = 4799,

        VCVTSI2SHZrr_Int = 4800,

        VCVTSI2SHZrrb_Int = 4801,

        VCVTSI2SSZrm = 4802,

        VCVTSI2SSZrm_Int = 4803,

        VCVTSI2SSZrr = 4804,

        VCVTSI2SSZrr_Int = 4805,

        VCVTSI2SSZrrb_Int = 4806,

        VCVTSI2SSrm = 4807,

        VCVTSI2SSrm_Int = 4808,

        VCVTSI2SSrr = 4809,

        VCVTSI2SSrr_Int = 4810,

        VCVTSI642SDZrm = 4811,

        VCVTSI642SDZrm_Int = 4812,

        VCVTSI642SDZrr = 4813,

        VCVTSI642SDZrr_Int = 4814,

        VCVTSI642SDZrrb_Int = 4815,

        VCVTSI642SDrm = 4816,

        VCVTSI642SDrm_Int = 4817,

        VCVTSI642SDrr = 4818,

        VCVTSI642SDrr_Int = 4819,

        VCVTSI642SHZrm = 4820,

        VCVTSI642SHZrm_Int = 4821,

        VCVTSI642SHZrr = 4822,

        VCVTSI642SHZrr_Int = 4823,

        VCVTSI642SHZrrb_Int = 4824,

        VCVTSI642SSZrm = 4825,

        VCVTSI642SSZrm_Int = 4826,

        VCVTSI642SSZrr = 4827,

        VCVTSI642SSZrr_Int = 4828,

        VCVTSI642SSZrrb_Int = 4829,

        VCVTSI642SSrm = 4830,

        VCVTSI642SSrm_Int = 4831,

        VCVTSI642SSrr = 4832,

        VCVTSI642SSrr_Int = 4833,

        VCVTSS2SDZrm = 4834,

        VCVTSS2SDZrm_Int = 4835,

        VCVTSS2SDZrm_Intk = 4836,

        VCVTSS2SDZrm_Intkz = 4837,

        VCVTSS2SDZrr = 4838,

        VCVTSS2SDZrr_Int = 4839,

        VCVTSS2SDZrr_Intk = 4840,

        VCVTSS2SDZrr_Intkz = 4841,

        VCVTSS2SDZrrb_Int = 4842,

        VCVTSS2SDZrrb_Intk = 4843,

        VCVTSS2SDZrrb_Intkz = 4844,

        VCVTSS2SDrm = 4845,

        VCVTSS2SDrm_Int = 4846,

        VCVTSS2SDrr = 4847,

        VCVTSS2SDrr_Int = 4848,

        VCVTSS2SHZrm = 4849,

        VCVTSS2SHZrm_Int = 4850,

        VCVTSS2SHZrm_Intk = 4851,

        VCVTSS2SHZrm_Intkz = 4852,

        VCVTSS2SHZrr = 4853,

        VCVTSS2SHZrr_Int = 4854,

        VCVTSS2SHZrr_Intk = 4855,

        VCVTSS2SHZrr_Intkz = 4856,

        VCVTSS2SHZrrb_Int = 4857,

        VCVTSS2SHZrrb_Intk = 4858,

        VCVTSS2SHZrrb_Intkz = 4859,

        VCVTSS2SI64Zrm = 4860,

        VCVTSS2SI64Zrm_Int = 4861,

        VCVTSS2SI64Zrr = 4862,

        VCVTSS2SI64Zrr_Int = 4863,

        VCVTSS2SI64Zrrb_Int = 4864,

        VCVTSS2SI64rm = 4865,

        VCVTSS2SI64rm_Int = 4866,

        VCVTSS2SI64rr = 4867,

        VCVTSS2SI64rr_Int = 4868,

        VCVTSS2SIZrm = 4869,

        VCVTSS2SIZrm_Int = 4870,

        VCVTSS2SIZrr = 4871,

        VCVTSS2SIZrr_Int = 4872,

        VCVTSS2SIZrrb_Int = 4873,

        VCVTSS2SIrm = 4874,

        VCVTSS2SIrm_Int = 4875,

        VCVTSS2SIrr = 4876,

        VCVTSS2SIrr_Int = 4877,

        VCVTSS2USI64Zrm_Int = 4878,

        VCVTSS2USI64Zrr_Int = 4879,

        VCVTSS2USI64Zrrb_Int = 4880,

        VCVTSS2USIZrm_Int = 4881,

        VCVTSS2USIZrr_Int = 4882,

        VCVTSS2USIZrrb_Int = 4883,

        VCVTTPD2DQYrm = 4884,

        VCVTTPD2DQYrr = 4885,

        VCVTTPD2DQZ128rm = 4886,

        VCVTTPD2DQZ128rmb = 4887,

        VCVTTPD2DQZ128rmbk = 4888,

        VCVTTPD2DQZ128rmbkz = 4889,

        VCVTTPD2DQZ128rmk = 4890,

        VCVTTPD2DQZ128rmkz = 4891,

        VCVTTPD2DQZ128rr = 4892,

        VCVTTPD2DQZ128rrk = 4893,

        VCVTTPD2DQZ128rrkz = 4894,

        VCVTTPD2DQZ256rm = 4895,

        VCVTTPD2DQZ256rmb = 4896,

        VCVTTPD2DQZ256rmbk = 4897,

        VCVTTPD2DQZ256rmbkz = 4898,

        VCVTTPD2DQZ256rmk = 4899,

        VCVTTPD2DQZ256rmkz = 4900,

        VCVTTPD2DQZ256rr = 4901,

        VCVTTPD2DQZ256rrk = 4902,

        VCVTTPD2DQZ256rrkz = 4903,

        VCVTTPD2DQZrm = 4904,

        VCVTTPD2DQZrmb = 4905,

        VCVTTPD2DQZrmbk = 4906,

        VCVTTPD2DQZrmbkz = 4907,

        VCVTTPD2DQZrmk = 4908,

        VCVTTPD2DQZrmkz = 4909,

        VCVTTPD2DQZrr = 4910,

        VCVTTPD2DQZrrb = 4911,

        VCVTTPD2DQZrrbk = 4912,

        VCVTTPD2DQZrrbkz = 4913,

        VCVTTPD2DQZrrk = 4914,

        VCVTTPD2DQZrrkz = 4915,

        VCVTTPD2DQrm = 4916,

        VCVTTPD2DQrr = 4917,

        VCVTTPD2QQZ128rm = 4918,

        VCVTTPD2QQZ128rmb = 4919,

        VCVTTPD2QQZ128rmbk = 4920,

        VCVTTPD2QQZ128rmbkz = 4921,

        VCVTTPD2QQZ128rmk = 4922,

        VCVTTPD2QQZ128rmkz = 4923,

        VCVTTPD2QQZ128rr = 4924,

        VCVTTPD2QQZ128rrk = 4925,

        VCVTTPD2QQZ128rrkz = 4926,

        VCVTTPD2QQZ256rm = 4927,

        VCVTTPD2QQZ256rmb = 4928,

        VCVTTPD2QQZ256rmbk = 4929,

        VCVTTPD2QQZ256rmbkz = 4930,

        VCVTTPD2QQZ256rmk = 4931,

        VCVTTPD2QQZ256rmkz = 4932,

        VCVTTPD2QQZ256rr = 4933,

        VCVTTPD2QQZ256rrk = 4934,

        VCVTTPD2QQZ256rrkz = 4935,

        VCVTTPD2QQZrm = 4936,

        VCVTTPD2QQZrmb = 4937,

        VCVTTPD2QQZrmbk = 4938,

        VCVTTPD2QQZrmbkz = 4939,

        VCVTTPD2QQZrmk = 4940,

        VCVTTPD2QQZrmkz = 4941,

        VCVTTPD2QQZrr = 4942,

        VCVTTPD2QQZrrb = 4943,

        VCVTTPD2QQZrrbk = 4944,

        VCVTTPD2QQZrrbkz = 4945,

        VCVTTPD2QQZrrk = 4946,

        VCVTTPD2QQZrrkz = 4947,

        VCVTTPD2UDQZ128rm = 4948,

        VCVTTPD2UDQZ128rmb = 4949,

        VCVTTPD2UDQZ128rmbk = 4950,

        VCVTTPD2UDQZ128rmbkz = 4951,

        VCVTTPD2UDQZ128rmk = 4952,

        VCVTTPD2UDQZ128rmkz = 4953,

        VCVTTPD2UDQZ128rr = 4954,

        VCVTTPD2UDQZ128rrk = 4955,

        VCVTTPD2UDQZ128rrkz = 4956,

        VCVTTPD2UDQZ256rm = 4957,

        VCVTTPD2UDQZ256rmb = 4958,

        VCVTTPD2UDQZ256rmbk = 4959,

        VCVTTPD2UDQZ256rmbkz = 4960,

        VCVTTPD2UDQZ256rmk = 4961,

        VCVTTPD2UDQZ256rmkz = 4962,

        VCVTTPD2UDQZ256rr = 4963,

        VCVTTPD2UDQZ256rrk = 4964,

        VCVTTPD2UDQZ256rrkz = 4965,

        VCVTTPD2UDQZrm = 4966,

        VCVTTPD2UDQZrmb = 4967,

        VCVTTPD2UDQZrmbk = 4968,

        VCVTTPD2UDQZrmbkz = 4969,

        VCVTTPD2UDQZrmk = 4970,

        VCVTTPD2UDQZrmkz = 4971,

        VCVTTPD2UDQZrr = 4972,

        VCVTTPD2UDQZrrb = 4973,

        VCVTTPD2UDQZrrbk = 4974,

        VCVTTPD2UDQZrrbkz = 4975,

        VCVTTPD2UDQZrrk = 4976,

        VCVTTPD2UDQZrrkz = 4977,

        VCVTTPD2UQQZ128rm = 4978,

        VCVTTPD2UQQZ128rmb = 4979,

        VCVTTPD2UQQZ128rmbk = 4980,

        VCVTTPD2UQQZ128rmbkz = 4981,

        VCVTTPD2UQQZ128rmk = 4982,

        VCVTTPD2UQQZ128rmkz = 4983,

        VCVTTPD2UQQZ128rr = 4984,

        VCVTTPD2UQQZ128rrk = 4985,

        VCVTTPD2UQQZ128rrkz = 4986,

        VCVTTPD2UQQZ256rm = 4987,

        VCVTTPD2UQQZ256rmb = 4988,

        VCVTTPD2UQQZ256rmbk = 4989,

        VCVTTPD2UQQZ256rmbkz = 4990,

        VCVTTPD2UQQZ256rmk = 4991,

        VCVTTPD2UQQZ256rmkz = 4992,

        VCVTTPD2UQQZ256rr = 4993,

        VCVTTPD2UQQZ256rrk = 4994,

        VCVTTPD2UQQZ256rrkz = 4995,

        VCVTTPD2UQQZrm = 4996,

        VCVTTPD2UQQZrmb = 4997,

        VCVTTPD2UQQZrmbk = 4998,

        VCVTTPD2UQQZrmbkz = 4999,

        VCVTTPD2UQQZrmk = 5000,

        VCVTTPD2UQQZrmkz = 5001,

        VCVTTPD2UQQZrr = 5002,

        VCVTTPD2UQQZrrb = 5003,

        VCVTTPD2UQQZrrbk = 5004,

        VCVTTPD2UQQZrrbkz = 5005,

        VCVTTPD2UQQZrrk = 5006,

        VCVTTPD2UQQZrrkz = 5007,

        VCVTTPH2DQZ128rm = 5008,

        VCVTTPH2DQZ128rmb = 5009,

        VCVTTPH2DQZ128rmbk = 5010,

        VCVTTPH2DQZ128rmbkz = 5011,

        VCVTTPH2DQZ128rmk = 5012,

        VCVTTPH2DQZ128rmkz = 5013,

        VCVTTPH2DQZ128rr = 5014,

        VCVTTPH2DQZ128rrk = 5015,

        VCVTTPH2DQZ128rrkz = 5016,

        VCVTTPH2DQZ256rm = 5017,

        VCVTTPH2DQZ256rmb = 5018,

        VCVTTPH2DQZ256rmbk = 5019,

        VCVTTPH2DQZ256rmbkz = 5020,

        VCVTTPH2DQZ256rmk = 5021,

        VCVTTPH2DQZ256rmkz = 5022,

        VCVTTPH2DQZ256rr = 5023,

        VCVTTPH2DQZ256rrk = 5024,

        VCVTTPH2DQZ256rrkz = 5025,

        VCVTTPH2DQZrm = 5026,

        VCVTTPH2DQZrmb = 5027,

        VCVTTPH2DQZrmbk = 5028,

        VCVTTPH2DQZrmbkz = 5029,

        VCVTTPH2DQZrmk = 5030,

        VCVTTPH2DQZrmkz = 5031,

        VCVTTPH2DQZrr = 5032,

        VCVTTPH2DQZrrb = 5033,

        VCVTTPH2DQZrrbk = 5034,

        VCVTTPH2DQZrrbkz = 5035,

        VCVTTPH2DQZrrk = 5036,

        VCVTTPH2DQZrrkz = 5037,

        VCVTTPH2QQZ128rm = 5038,

        VCVTTPH2QQZ128rmb = 5039,

        VCVTTPH2QQZ128rmbk = 5040,

        VCVTTPH2QQZ128rmbkz = 5041,

        VCVTTPH2QQZ128rmk = 5042,

        VCVTTPH2QQZ128rmkz = 5043,

        VCVTTPH2QQZ128rr = 5044,

        VCVTTPH2QQZ128rrk = 5045,

        VCVTTPH2QQZ128rrkz = 5046,

        VCVTTPH2QQZ256rm = 5047,

        VCVTTPH2QQZ256rmb = 5048,

        VCVTTPH2QQZ256rmbk = 5049,

        VCVTTPH2QQZ256rmbkz = 5050,

        VCVTTPH2QQZ256rmk = 5051,

        VCVTTPH2QQZ256rmkz = 5052,

        VCVTTPH2QQZ256rr = 5053,

        VCVTTPH2QQZ256rrk = 5054,

        VCVTTPH2QQZ256rrkz = 5055,

        VCVTTPH2QQZrm = 5056,

        VCVTTPH2QQZrmb = 5057,

        VCVTTPH2QQZrmbk = 5058,

        VCVTTPH2QQZrmbkz = 5059,

        VCVTTPH2QQZrmk = 5060,

        VCVTTPH2QQZrmkz = 5061,

        VCVTTPH2QQZrr = 5062,

        VCVTTPH2QQZrrb = 5063,

        VCVTTPH2QQZrrbk = 5064,

        VCVTTPH2QQZrrbkz = 5065,

        VCVTTPH2QQZrrk = 5066,

        VCVTTPH2QQZrrkz = 5067,

        VCVTTPH2UDQZ128rm = 5068,

        VCVTTPH2UDQZ128rmb = 5069,

        VCVTTPH2UDQZ128rmbk = 5070,

        VCVTTPH2UDQZ128rmbkz = 5071,

        VCVTTPH2UDQZ128rmk = 5072,

        VCVTTPH2UDQZ128rmkz = 5073,

        VCVTTPH2UDQZ128rr = 5074,

        VCVTTPH2UDQZ128rrk = 5075,

        VCVTTPH2UDQZ128rrkz = 5076,

        VCVTTPH2UDQZ256rm = 5077,

        VCVTTPH2UDQZ256rmb = 5078,

        VCVTTPH2UDQZ256rmbk = 5079,

        VCVTTPH2UDQZ256rmbkz = 5080,

        VCVTTPH2UDQZ256rmk = 5081,

        VCVTTPH2UDQZ256rmkz = 5082,

        VCVTTPH2UDQZ256rr = 5083,

        VCVTTPH2UDQZ256rrk = 5084,

        VCVTTPH2UDQZ256rrkz = 5085,

        VCVTTPH2UDQZrm = 5086,

        VCVTTPH2UDQZrmb = 5087,

        VCVTTPH2UDQZrmbk = 5088,

        VCVTTPH2UDQZrmbkz = 5089,

        VCVTTPH2UDQZrmk = 5090,

        VCVTTPH2UDQZrmkz = 5091,

        VCVTTPH2UDQZrr = 5092,

        VCVTTPH2UDQZrrb = 5093,

        VCVTTPH2UDQZrrbk = 5094,

        VCVTTPH2UDQZrrbkz = 5095,

        VCVTTPH2UDQZrrk = 5096,

        VCVTTPH2UDQZrrkz = 5097,

        VCVTTPH2UQQZ128rm = 5098,

        VCVTTPH2UQQZ128rmb = 5099,

        VCVTTPH2UQQZ128rmbk = 5100,

        VCVTTPH2UQQZ128rmbkz = 5101,

        VCVTTPH2UQQZ128rmk = 5102,

        VCVTTPH2UQQZ128rmkz = 5103,

        VCVTTPH2UQQZ128rr = 5104,

        VCVTTPH2UQQZ128rrk = 5105,

        VCVTTPH2UQQZ128rrkz = 5106,

        VCVTTPH2UQQZ256rm = 5107,

        VCVTTPH2UQQZ256rmb = 5108,

        VCVTTPH2UQQZ256rmbk = 5109,

        VCVTTPH2UQQZ256rmbkz = 5110,

        VCVTTPH2UQQZ256rmk = 5111,

        VCVTTPH2UQQZ256rmkz = 5112,

        VCVTTPH2UQQZ256rr = 5113,

        VCVTTPH2UQQZ256rrk = 5114,

        VCVTTPH2UQQZ256rrkz = 5115,

        VCVTTPH2UQQZrm = 5116,

        VCVTTPH2UQQZrmb = 5117,

        VCVTTPH2UQQZrmbk = 5118,

        VCVTTPH2UQQZrmbkz = 5119,

        VCVTTPH2UQQZrmk = 5120,

        VCVTTPH2UQQZrmkz = 5121,

        VCVTTPH2UQQZrr = 5122,

        VCVTTPH2UQQZrrb = 5123,

        VCVTTPH2UQQZrrbk = 5124,

        VCVTTPH2UQQZrrbkz = 5125,

        VCVTTPH2UQQZrrk = 5126,

        VCVTTPH2UQQZrrkz = 5127,

        VCVTTPH2UWZ128rm = 5128,

        VCVTTPH2UWZ128rmb = 5129,

        VCVTTPH2UWZ128rmbk = 5130,

        VCVTTPH2UWZ128rmbkz = 5131,

        VCVTTPH2UWZ128rmk = 5132,

        VCVTTPH2UWZ128rmkz = 5133,

        VCVTTPH2UWZ128rr = 5134,

        VCVTTPH2UWZ128rrk = 5135,

        VCVTTPH2UWZ128rrkz = 5136,

        VCVTTPH2UWZ256rm = 5137,

        VCVTTPH2UWZ256rmb = 5138,

        VCVTTPH2UWZ256rmbk = 5139,

        VCVTTPH2UWZ256rmbkz = 5140,

        VCVTTPH2UWZ256rmk = 5141,

        VCVTTPH2UWZ256rmkz = 5142,

        VCVTTPH2UWZ256rr = 5143,

        VCVTTPH2UWZ256rrk = 5144,

        VCVTTPH2UWZ256rrkz = 5145,

        VCVTTPH2UWZrm = 5146,

        VCVTTPH2UWZrmb = 5147,

        VCVTTPH2UWZrmbk = 5148,

        VCVTTPH2UWZrmbkz = 5149,

        VCVTTPH2UWZrmk = 5150,

        VCVTTPH2UWZrmkz = 5151,

        VCVTTPH2UWZrr = 5152,

        VCVTTPH2UWZrrb = 5153,

        VCVTTPH2UWZrrbk = 5154,

        VCVTTPH2UWZrrbkz = 5155,

        VCVTTPH2UWZrrk = 5156,

        VCVTTPH2UWZrrkz = 5157,

        VCVTTPH2WZ128rm = 5158,

        VCVTTPH2WZ128rmb = 5159,

        VCVTTPH2WZ128rmbk = 5160,

        VCVTTPH2WZ128rmbkz = 5161,

        VCVTTPH2WZ128rmk = 5162,

        VCVTTPH2WZ128rmkz = 5163,

        VCVTTPH2WZ128rr = 5164,

        VCVTTPH2WZ128rrk = 5165,

        VCVTTPH2WZ128rrkz = 5166,

        VCVTTPH2WZ256rm = 5167,

        VCVTTPH2WZ256rmb = 5168,

        VCVTTPH2WZ256rmbk = 5169,

        VCVTTPH2WZ256rmbkz = 5170,

        VCVTTPH2WZ256rmk = 5171,

        VCVTTPH2WZ256rmkz = 5172,

        VCVTTPH2WZ256rr = 5173,

        VCVTTPH2WZ256rrk = 5174,

        VCVTTPH2WZ256rrkz = 5175,

        VCVTTPH2WZrm = 5176,

        VCVTTPH2WZrmb = 5177,

        VCVTTPH2WZrmbk = 5178,

        VCVTTPH2WZrmbkz = 5179,

        VCVTTPH2WZrmk = 5180,

        VCVTTPH2WZrmkz = 5181,

        VCVTTPH2WZrr = 5182,

        VCVTTPH2WZrrb = 5183,

        VCVTTPH2WZrrbk = 5184,

        VCVTTPH2WZrrbkz = 5185,

        VCVTTPH2WZrrk = 5186,

        VCVTTPH2WZrrkz = 5187,

        VCVTTPS2DQYrm = 5188,

        VCVTTPS2DQYrr = 5189,

        VCVTTPS2DQZ128rm = 5190,

        VCVTTPS2DQZ128rmb = 5191,

        VCVTTPS2DQZ128rmbk = 5192,

        VCVTTPS2DQZ128rmbkz = 5193,

        VCVTTPS2DQZ128rmk = 5194,

        VCVTTPS2DQZ128rmkz = 5195,

        VCVTTPS2DQZ128rr = 5196,

        VCVTTPS2DQZ128rrk = 5197,

        VCVTTPS2DQZ128rrkz = 5198,

        VCVTTPS2DQZ256rm = 5199,

        VCVTTPS2DQZ256rmb = 5200,

        VCVTTPS2DQZ256rmbk = 5201,

        VCVTTPS2DQZ256rmbkz = 5202,

        VCVTTPS2DQZ256rmk = 5203,

        VCVTTPS2DQZ256rmkz = 5204,

        VCVTTPS2DQZ256rr = 5205,

        VCVTTPS2DQZ256rrk = 5206,

        VCVTTPS2DQZ256rrkz = 5207,

        VCVTTPS2DQZrm = 5208,

        VCVTTPS2DQZrmb = 5209,

        VCVTTPS2DQZrmbk = 5210,

        VCVTTPS2DQZrmbkz = 5211,

        VCVTTPS2DQZrmk = 5212,

        VCVTTPS2DQZrmkz = 5213,

        VCVTTPS2DQZrr = 5214,

        VCVTTPS2DQZrrb = 5215,

        VCVTTPS2DQZrrbk = 5216,

        VCVTTPS2DQZrrbkz = 5217,

        VCVTTPS2DQZrrk = 5218,

        VCVTTPS2DQZrrkz = 5219,

        VCVTTPS2DQrm = 5220,

        VCVTTPS2DQrr = 5221,

        VCVTTPS2QQZ128rm = 5222,

        VCVTTPS2QQZ128rmb = 5223,

        VCVTTPS2QQZ128rmbk = 5224,

        VCVTTPS2QQZ128rmbkz = 5225,

        VCVTTPS2QQZ128rmk = 5226,

        VCVTTPS2QQZ128rmkz = 5227,

        VCVTTPS2QQZ128rr = 5228,

        VCVTTPS2QQZ128rrk = 5229,

        VCVTTPS2QQZ128rrkz = 5230,

        VCVTTPS2QQZ256rm = 5231,

        VCVTTPS2QQZ256rmb = 5232,

        VCVTTPS2QQZ256rmbk = 5233,

        VCVTTPS2QQZ256rmbkz = 5234,

        VCVTTPS2QQZ256rmk = 5235,

        VCVTTPS2QQZ256rmkz = 5236,

        VCVTTPS2QQZ256rr = 5237,

        VCVTTPS2QQZ256rrk = 5238,

        VCVTTPS2QQZ256rrkz = 5239,

        VCVTTPS2QQZrm = 5240,

        VCVTTPS2QQZrmb = 5241,

        VCVTTPS2QQZrmbk = 5242,

        VCVTTPS2QQZrmbkz = 5243,

        VCVTTPS2QQZrmk = 5244,

        VCVTTPS2QQZrmkz = 5245,

        VCVTTPS2QQZrr = 5246,

        VCVTTPS2QQZrrb = 5247,

        VCVTTPS2QQZrrbk = 5248,

        VCVTTPS2QQZrrbkz = 5249,

        VCVTTPS2QQZrrk = 5250,

        VCVTTPS2QQZrrkz = 5251,

        VCVTTPS2UDQZ128rm = 5252,

        VCVTTPS2UDQZ128rmb = 5253,

        VCVTTPS2UDQZ128rmbk = 5254,

        VCVTTPS2UDQZ128rmbkz = 5255,

        VCVTTPS2UDQZ128rmk = 5256,

        VCVTTPS2UDQZ128rmkz = 5257,

        VCVTTPS2UDQZ128rr = 5258,

        VCVTTPS2UDQZ128rrk = 5259,

        VCVTTPS2UDQZ128rrkz = 5260,

        VCVTTPS2UDQZ256rm = 5261,

        VCVTTPS2UDQZ256rmb = 5262,

        VCVTTPS2UDQZ256rmbk = 5263,

        VCVTTPS2UDQZ256rmbkz = 5264,

        VCVTTPS2UDQZ256rmk = 5265,

        VCVTTPS2UDQZ256rmkz = 5266,

        VCVTTPS2UDQZ256rr = 5267,

        VCVTTPS2UDQZ256rrk = 5268,

        VCVTTPS2UDQZ256rrkz = 5269,

        VCVTTPS2UDQZrm = 5270,

        VCVTTPS2UDQZrmb = 5271,

        VCVTTPS2UDQZrmbk = 5272,

        VCVTTPS2UDQZrmbkz = 5273,

        VCVTTPS2UDQZrmk = 5274,

        VCVTTPS2UDQZrmkz = 5275,

        VCVTTPS2UDQZrr = 5276,

        VCVTTPS2UDQZrrb = 5277,

        VCVTTPS2UDQZrrbk = 5278,

        VCVTTPS2UDQZrrbkz = 5279,

        VCVTTPS2UDQZrrk = 5280,

        VCVTTPS2UDQZrrkz = 5281,

        VCVTTPS2UQQZ128rm = 5282,

        VCVTTPS2UQQZ128rmb = 5283,

        VCVTTPS2UQQZ128rmbk = 5284,

        VCVTTPS2UQQZ128rmbkz = 5285,

        VCVTTPS2UQQZ128rmk = 5286,

        VCVTTPS2UQQZ128rmkz = 5287,

        VCVTTPS2UQQZ128rr = 5288,

        VCVTTPS2UQQZ128rrk = 5289,

        VCVTTPS2UQQZ128rrkz = 5290,

        VCVTTPS2UQQZ256rm = 5291,

        VCVTTPS2UQQZ256rmb = 5292,

        VCVTTPS2UQQZ256rmbk = 5293,

        VCVTTPS2UQQZ256rmbkz = 5294,

        VCVTTPS2UQQZ256rmk = 5295,

        VCVTTPS2UQQZ256rmkz = 5296,

        VCVTTPS2UQQZ256rr = 5297,

        VCVTTPS2UQQZ256rrk = 5298,

        VCVTTPS2UQQZ256rrkz = 5299,

        VCVTTPS2UQQZrm = 5300,

        VCVTTPS2UQQZrmb = 5301,

        VCVTTPS2UQQZrmbk = 5302,

        VCVTTPS2UQQZrmbkz = 5303,

        VCVTTPS2UQQZrmk = 5304,

        VCVTTPS2UQQZrmkz = 5305,

        VCVTTPS2UQQZrr = 5306,

        VCVTTPS2UQQZrrb = 5307,

        VCVTTPS2UQQZrrbk = 5308,

        VCVTTPS2UQQZrrbkz = 5309,

        VCVTTPS2UQQZrrk = 5310,

        VCVTTPS2UQQZrrkz = 5311,

        VCVTTSD2SI64Zrm = 5312,

        VCVTTSD2SI64Zrm_Int = 5313,

        VCVTTSD2SI64Zrr = 5314,

        VCVTTSD2SI64Zrr_Int = 5315,

        VCVTTSD2SI64Zrrb_Int = 5316,

        VCVTTSD2SI64rm = 5317,

        VCVTTSD2SI64rm_Int = 5318,

        VCVTTSD2SI64rr = 5319,

        VCVTTSD2SI64rr_Int = 5320,

        VCVTTSD2SIZrm = 5321,

        VCVTTSD2SIZrm_Int = 5322,

        VCVTTSD2SIZrr = 5323,

        VCVTTSD2SIZrr_Int = 5324,

        VCVTTSD2SIZrrb_Int = 5325,

        VCVTTSD2SIrm = 5326,

        VCVTTSD2SIrm_Int = 5327,

        VCVTTSD2SIrr = 5328,

        VCVTTSD2SIrr_Int = 5329,

        VCVTTSD2USI64Zrm = 5330,

        VCVTTSD2USI64Zrm_Int = 5331,

        VCVTTSD2USI64Zrr = 5332,

        VCVTTSD2USI64Zrr_Int = 5333,

        VCVTTSD2USI64Zrrb_Int = 5334,

        VCVTTSD2USIZrm = 5335,

        VCVTTSD2USIZrm_Int = 5336,

        VCVTTSD2USIZrr = 5337,

        VCVTTSD2USIZrr_Int = 5338,

        VCVTTSD2USIZrrb_Int = 5339,

        VCVTTSH2SI64Zrm = 5340,

        VCVTTSH2SI64Zrm_Int = 5341,

        VCVTTSH2SI64Zrr = 5342,

        VCVTTSH2SI64Zrr_Int = 5343,

        VCVTTSH2SI64Zrrb_Int = 5344,

        VCVTTSH2SIZrm = 5345,

        VCVTTSH2SIZrm_Int = 5346,

        VCVTTSH2SIZrr = 5347,

        VCVTTSH2SIZrr_Int = 5348,

        VCVTTSH2SIZrrb_Int = 5349,

        VCVTTSH2USI64Zrm = 5350,

        VCVTTSH2USI64Zrm_Int = 5351,

        VCVTTSH2USI64Zrr = 5352,

        VCVTTSH2USI64Zrr_Int = 5353,

        VCVTTSH2USI64Zrrb_Int = 5354,

        VCVTTSH2USIZrm = 5355,

        VCVTTSH2USIZrm_Int = 5356,

        VCVTTSH2USIZrr = 5357,

        VCVTTSH2USIZrr_Int = 5358,

        VCVTTSH2USIZrrb_Int = 5359,

        VCVTTSS2SI64Zrm = 5360,

        VCVTTSS2SI64Zrm_Int = 5361,

        VCVTTSS2SI64Zrr = 5362,

        VCVTTSS2SI64Zrr_Int = 5363,

        VCVTTSS2SI64Zrrb_Int = 5364,

        VCVTTSS2SI64rm = 5365,

        VCVTTSS2SI64rm_Int = 5366,

        VCVTTSS2SI64rr = 5367,

        VCVTTSS2SI64rr_Int = 5368,

        VCVTTSS2SIZrm = 5369,

        VCVTTSS2SIZrm_Int = 5370,

        VCVTTSS2SIZrr = 5371,

        VCVTTSS2SIZrr_Int = 5372,

        VCVTTSS2SIZrrb_Int = 5373,

        VCVTTSS2SIrm = 5374,

        VCVTTSS2SIrm_Int = 5375,

        VCVTTSS2SIrr = 5376,

        VCVTTSS2SIrr_Int = 5377,

        VCVTTSS2USI64Zrm = 5378,

        VCVTTSS2USI64Zrm_Int = 5379,

        VCVTTSS2USI64Zrr = 5380,

        VCVTTSS2USI64Zrr_Int = 5381,

        VCVTTSS2USI64Zrrb_Int = 5382,

        VCVTTSS2USIZrm = 5383,

        VCVTTSS2USIZrm_Int = 5384,

        VCVTTSS2USIZrr = 5385,

        VCVTTSS2USIZrr_Int = 5386,

        VCVTTSS2USIZrrb_Int = 5387,

        VCVTUDQ2PDZ128rm = 5388,

        VCVTUDQ2PDZ128rmb = 5389,

        VCVTUDQ2PDZ128rmbk = 5390,

        VCVTUDQ2PDZ128rmbkz = 5391,

        VCVTUDQ2PDZ128rmk = 5392,

        VCVTUDQ2PDZ128rmkz = 5393,

        VCVTUDQ2PDZ128rr = 5394,

        VCVTUDQ2PDZ128rrk = 5395,

        VCVTUDQ2PDZ128rrkz = 5396,

        VCVTUDQ2PDZ256rm = 5397,

        VCVTUDQ2PDZ256rmb = 5398,

        VCVTUDQ2PDZ256rmbk = 5399,

        VCVTUDQ2PDZ256rmbkz = 5400,

        VCVTUDQ2PDZ256rmk = 5401,

        VCVTUDQ2PDZ256rmkz = 5402,

        VCVTUDQ2PDZ256rr = 5403,

        VCVTUDQ2PDZ256rrk = 5404,

        VCVTUDQ2PDZ256rrkz = 5405,

        VCVTUDQ2PDZrm = 5406,

        VCVTUDQ2PDZrmb = 5407,

        VCVTUDQ2PDZrmbk = 5408,

        VCVTUDQ2PDZrmbkz = 5409,

        VCVTUDQ2PDZrmk = 5410,

        VCVTUDQ2PDZrmkz = 5411,

        VCVTUDQ2PDZrr = 5412,

        VCVTUDQ2PDZrrk = 5413,

        VCVTUDQ2PDZrrkz = 5414,

        VCVTUDQ2PHZ128rm = 5415,

        VCVTUDQ2PHZ128rmb = 5416,

        VCVTUDQ2PHZ128rmbk = 5417,

        VCVTUDQ2PHZ128rmbkz = 5418,

        VCVTUDQ2PHZ128rmk = 5419,

        VCVTUDQ2PHZ128rmkz = 5420,

        VCVTUDQ2PHZ128rr = 5421,

        VCVTUDQ2PHZ128rrk = 5422,

        VCVTUDQ2PHZ128rrkz = 5423,

        VCVTUDQ2PHZ256rm = 5424,

        VCVTUDQ2PHZ256rmb = 5425,

        VCVTUDQ2PHZ256rmbk = 5426,

        VCVTUDQ2PHZ256rmbkz = 5427,

        VCVTUDQ2PHZ256rmk = 5428,

        VCVTUDQ2PHZ256rmkz = 5429,

        VCVTUDQ2PHZ256rr = 5430,

        VCVTUDQ2PHZ256rrk = 5431,

        VCVTUDQ2PHZ256rrkz = 5432,

        VCVTUDQ2PHZrm = 5433,

        VCVTUDQ2PHZrmb = 5434,

        VCVTUDQ2PHZrmbk = 5435,

        VCVTUDQ2PHZrmbkz = 5436,

        VCVTUDQ2PHZrmk = 5437,

        VCVTUDQ2PHZrmkz = 5438,

        VCVTUDQ2PHZrr = 5439,

        VCVTUDQ2PHZrrb = 5440,

        VCVTUDQ2PHZrrbk = 5441,

        VCVTUDQ2PHZrrbkz = 5442,

        VCVTUDQ2PHZrrk = 5443,

        VCVTUDQ2PHZrrkz = 5444,

        VCVTUDQ2PSZ128rm = 5445,

        VCVTUDQ2PSZ128rmb = 5446,

        VCVTUDQ2PSZ128rmbk = 5447,

        VCVTUDQ2PSZ128rmbkz = 5448,

        VCVTUDQ2PSZ128rmk = 5449,

        VCVTUDQ2PSZ128rmkz = 5450,

        VCVTUDQ2PSZ128rr = 5451,

        VCVTUDQ2PSZ128rrk = 5452,

        VCVTUDQ2PSZ128rrkz = 5453,

        VCVTUDQ2PSZ256rm = 5454,

        VCVTUDQ2PSZ256rmb = 5455,

        VCVTUDQ2PSZ256rmbk = 5456,

        VCVTUDQ2PSZ256rmbkz = 5457,

        VCVTUDQ2PSZ256rmk = 5458,

        VCVTUDQ2PSZ256rmkz = 5459,

        VCVTUDQ2PSZ256rr = 5460,

        VCVTUDQ2PSZ256rrk = 5461,

        VCVTUDQ2PSZ256rrkz = 5462,

        VCVTUDQ2PSZrm = 5463,

        VCVTUDQ2PSZrmb = 5464,

        VCVTUDQ2PSZrmbk = 5465,

        VCVTUDQ2PSZrmbkz = 5466,

        VCVTUDQ2PSZrmk = 5467,

        VCVTUDQ2PSZrmkz = 5468,

        VCVTUDQ2PSZrr = 5469,

        VCVTUDQ2PSZrrb = 5470,

        VCVTUDQ2PSZrrbk = 5471,

        VCVTUDQ2PSZrrbkz = 5472,

        VCVTUDQ2PSZrrk = 5473,

        VCVTUDQ2PSZrrkz = 5474,

        VCVTUQQ2PDZ128rm = 5475,

        VCVTUQQ2PDZ128rmb = 5476,

        VCVTUQQ2PDZ128rmbk = 5477,

        VCVTUQQ2PDZ128rmbkz = 5478,

        VCVTUQQ2PDZ128rmk = 5479,

        VCVTUQQ2PDZ128rmkz = 5480,

        VCVTUQQ2PDZ128rr = 5481,

        VCVTUQQ2PDZ128rrk = 5482,

        VCVTUQQ2PDZ128rrkz = 5483,

        VCVTUQQ2PDZ256rm = 5484,

        VCVTUQQ2PDZ256rmb = 5485,

        VCVTUQQ2PDZ256rmbk = 5486,

        VCVTUQQ2PDZ256rmbkz = 5487,

        VCVTUQQ2PDZ256rmk = 5488,

        VCVTUQQ2PDZ256rmkz = 5489,

        VCVTUQQ2PDZ256rr = 5490,

        VCVTUQQ2PDZ256rrk = 5491,

        VCVTUQQ2PDZ256rrkz = 5492,

        VCVTUQQ2PDZrm = 5493,

        VCVTUQQ2PDZrmb = 5494,

        VCVTUQQ2PDZrmbk = 5495,

        VCVTUQQ2PDZrmbkz = 5496,

        VCVTUQQ2PDZrmk = 5497,

        VCVTUQQ2PDZrmkz = 5498,

        VCVTUQQ2PDZrr = 5499,

        VCVTUQQ2PDZrrb = 5500,

        VCVTUQQ2PDZrrbk = 5501,

        VCVTUQQ2PDZrrbkz = 5502,

        VCVTUQQ2PDZrrk = 5503,

        VCVTUQQ2PDZrrkz = 5504,

        VCVTUQQ2PHZ128rm = 5505,

        VCVTUQQ2PHZ128rmb = 5506,

        VCVTUQQ2PHZ128rmbk = 5507,

        VCVTUQQ2PHZ128rmbkz = 5508,

        VCVTUQQ2PHZ128rmk = 5509,

        VCVTUQQ2PHZ128rmkz = 5510,

        VCVTUQQ2PHZ128rr = 5511,

        VCVTUQQ2PHZ128rrk = 5512,

        VCVTUQQ2PHZ128rrkz = 5513,

        VCVTUQQ2PHZ256rm = 5514,

        VCVTUQQ2PHZ256rmb = 5515,

        VCVTUQQ2PHZ256rmbk = 5516,

        VCVTUQQ2PHZ256rmbkz = 5517,

        VCVTUQQ2PHZ256rmk = 5518,

        VCVTUQQ2PHZ256rmkz = 5519,

        VCVTUQQ2PHZ256rr = 5520,

        VCVTUQQ2PHZ256rrk = 5521,

        VCVTUQQ2PHZ256rrkz = 5522,

        VCVTUQQ2PHZrm = 5523,

        VCVTUQQ2PHZrmb = 5524,

        VCVTUQQ2PHZrmbk = 5525,

        VCVTUQQ2PHZrmbkz = 5526,

        VCVTUQQ2PHZrmk = 5527,

        VCVTUQQ2PHZrmkz = 5528,

        VCVTUQQ2PHZrr = 5529,

        VCVTUQQ2PHZrrb = 5530,

        VCVTUQQ2PHZrrbk = 5531,

        VCVTUQQ2PHZrrbkz = 5532,

        VCVTUQQ2PHZrrk = 5533,

        VCVTUQQ2PHZrrkz = 5534,

        VCVTUQQ2PSZ128rm = 5535,

        VCVTUQQ2PSZ128rmb = 5536,

        VCVTUQQ2PSZ128rmbk = 5537,

        VCVTUQQ2PSZ128rmbkz = 5538,

        VCVTUQQ2PSZ128rmk = 5539,

        VCVTUQQ2PSZ128rmkz = 5540,

        VCVTUQQ2PSZ128rr = 5541,

        VCVTUQQ2PSZ128rrk = 5542,

        VCVTUQQ2PSZ128rrkz = 5543,

        VCVTUQQ2PSZ256rm = 5544,

        VCVTUQQ2PSZ256rmb = 5545,

        VCVTUQQ2PSZ256rmbk = 5546,

        VCVTUQQ2PSZ256rmbkz = 5547,

        VCVTUQQ2PSZ256rmk = 5548,

        VCVTUQQ2PSZ256rmkz = 5549,

        VCVTUQQ2PSZ256rr = 5550,

        VCVTUQQ2PSZ256rrk = 5551,

        VCVTUQQ2PSZ256rrkz = 5552,

        VCVTUQQ2PSZrm = 5553,

        VCVTUQQ2PSZrmb = 5554,

        VCVTUQQ2PSZrmbk = 5555,

        VCVTUQQ2PSZrmbkz = 5556,

        VCVTUQQ2PSZrmk = 5557,

        VCVTUQQ2PSZrmkz = 5558,

        VCVTUQQ2PSZrr = 5559,

        VCVTUQQ2PSZrrb = 5560,

        VCVTUQQ2PSZrrbk = 5561,

        VCVTUQQ2PSZrrbkz = 5562,

        VCVTUQQ2PSZrrk = 5563,

        VCVTUQQ2PSZrrkz = 5564,

        VCVTUSI2SDZrm = 5565,

        VCVTUSI2SDZrm_Int = 5566,

        VCVTUSI2SDZrr = 5567,

        VCVTUSI2SDZrr_Int = 5568,

        VCVTUSI2SHZrm = 5569,

        VCVTUSI2SHZrm_Int = 5570,

        VCVTUSI2SHZrr = 5571,

        VCVTUSI2SHZrr_Int = 5572,

        VCVTUSI2SHZrrb_Int = 5573,

        VCVTUSI2SSZrm = 5574,

        VCVTUSI2SSZrm_Int = 5575,

        VCVTUSI2SSZrr = 5576,

        VCVTUSI2SSZrr_Int = 5577,

        VCVTUSI2SSZrrb_Int = 5578,

        VCVTUSI642SDZrm = 5579,

        VCVTUSI642SDZrm_Int = 5580,

        VCVTUSI642SDZrr = 5581,

        VCVTUSI642SDZrr_Int = 5582,

        VCVTUSI642SDZrrb_Int = 5583,

        VCVTUSI642SHZrm = 5584,

        VCVTUSI642SHZrm_Int = 5585,

        VCVTUSI642SHZrr = 5586,

        VCVTUSI642SHZrr_Int = 5587,

        VCVTUSI642SHZrrb_Int = 5588,

        VCVTUSI642SSZrm = 5589,

        VCVTUSI642SSZrm_Int = 5590,

        VCVTUSI642SSZrr = 5591,

        VCVTUSI642SSZrr_Int = 5592,

        VCVTUSI642SSZrrb_Int = 5593,

        VCVTUW2PHZ128rm = 5594,

        VCVTUW2PHZ128rmb = 5595,

        VCVTUW2PHZ128rmbk = 5596,

        VCVTUW2PHZ128rmbkz = 5597,

        VCVTUW2PHZ128rmk = 5598,

        VCVTUW2PHZ128rmkz = 5599,

        VCVTUW2PHZ128rr = 5600,

        VCVTUW2PHZ128rrk = 5601,

        VCVTUW2PHZ128rrkz = 5602,

        VCVTUW2PHZ256rm = 5603,

        VCVTUW2PHZ256rmb = 5604,

        VCVTUW2PHZ256rmbk = 5605,

        VCVTUW2PHZ256rmbkz = 5606,

        VCVTUW2PHZ256rmk = 5607,

        VCVTUW2PHZ256rmkz = 5608,

        VCVTUW2PHZ256rr = 5609,

        VCVTUW2PHZ256rrk = 5610,

        VCVTUW2PHZ256rrkz = 5611,

        VCVTUW2PHZrm = 5612,

        VCVTUW2PHZrmb = 5613,

        VCVTUW2PHZrmbk = 5614,

        VCVTUW2PHZrmbkz = 5615,

        VCVTUW2PHZrmk = 5616,

        VCVTUW2PHZrmkz = 5617,

        VCVTUW2PHZrr = 5618,

        VCVTUW2PHZrrb = 5619,

        VCVTUW2PHZrrbk = 5620,

        VCVTUW2PHZrrbkz = 5621,

        VCVTUW2PHZrrk = 5622,

        VCVTUW2PHZrrkz = 5623,

        VCVTW2PHZ128rm = 5624,

        VCVTW2PHZ128rmb = 5625,

        VCVTW2PHZ128rmbk = 5626,

        VCVTW2PHZ128rmbkz = 5627,

        VCVTW2PHZ128rmk = 5628,

        VCVTW2PHZ128rmkz = 5629,

        VCVTW2PHZ128rr = 5630,

        VCVTW2PHZ128rrk = 5631,

        VCVTW2PHZ128rrkz = 5632,

        VCVTW2PHZ256rm = 5633,

        VCVTW2PHZ256rmb = 5634,

        VCVTW2PHZ256rmbk = 5635,

        VCVTW2PHZ256rmbkz = 5636,

        VCVTW2PHZ256rmk = 5637,

        VCVTW2PHZ256rmkz = 5638,

        VCVTW2PHZ256rr = 5639,

        VCVTW2PHZ256rrk = 5640,

        VCVTW2PHZ256rrkz = 5641,

        VCVTW2PHZrm = 5642,

        VCVTW2PHZrmb = 5643,

        VCVTW2PHZrmbk = 5644,

        VCVTW2PHZrmbkz = 5645,

        VCVTW2PHZrmk = 5646,

        VCVTW2PHZrmkz = 5647,

        VCVTW2PHZrr = 5648,

        VCVTW2PHZrrb = 5649,

        VCVTW2PHZrrbk = 5650,

        VCVTW2PHZrrbkz = 5651,

        VCVTW2PHZrrk = 5652,

        VCVTW2PHZrrkz = 5653,

        VDBPSADBWZ128rmi = 5654,

        VDBPSADBWZ128rmik = 5655,

        VDBPSADBWZ128rmikz = 5656,

        VDBPSADBWZ128rri = 5657,

        VDBPSADBWZ128rrik = 5658,

        VDBPSADBWZ128rrikz = 5659,

        VDBPSADBWZ256rmi = 5660,

        VDBPSADBWZ256rmik = 5661,

        VDBPSADBWZ256rmikz = 5662,

        VDBPSADBWZ256rri = 5663,

        VDBPSADBWZ256rrik = 5664,

        VDBPSADBWZ256rrikz = 5665,

        VDBPSADBWZrmi = 5666,

        VDBPSADBWZrmik = 5667,

        VDBPSADBWZrmikz = 5668,

        VDBPSADBWZrri = 5669,

        VDBPSADBWZrrik = 5670,

        VDBPSADBWZrrikz = 5671,

        VDIVPDYrm = 5672,

        VDIVPDYrr = 5673,

        VDIVPDZ128rm = 5674,

        VDIVPDZ128rmb = 5675,

        VDIVPDZ128rmbk = 5676,

        VDIVPDZ128rmbkz = 5677,

        VDIVPDZ128rmk = 5678,

        VDIVPDZ128rmkz = 5679,

        VDIVPDZ128rr = 5680,

        VDIVPDZ128rrk = 5681,

        VDIVPDZ128rrkz = 5682,

        VDIVPDZ256rm = 5683,

        VDIVPDZ256rmb = 5684,

        VDIVPDZ256rmbk = 5685,

        VDIVPDZ256rmbkz = 5686,

        VDIVPDZ256rmk = 5687,

        VDIVPDZ256rmkz = 5688,

        VDIVPDZ256rr = 5689,

        VDIVPDZ256rrk = 5690,

        VDIVPDZ256rrkz = 5691,

        VDIVPDZrm = 5692,

        VDIVPDZrmb = 5693,

        VDIVPDZrmbk = 5694,

        VDIVPDZrmbkz = 5695,

        VDIVPDZrmk = 5696,

        VDIVPDZrmkz = 5697,

        VDIVPDZrr = 5698,

        VDIVPDZrrb = 5699,

        VDIVPDZrrbk = 5700,

        VDIVPDZrrbkz = 5701,

        VDIVPDZrrk = 5702,

        VDIVPDZrrkz = 5703,

        VDIVPDrm = 5704,

        VDIVPDrr = 5705,

        VDIVPHZ128rm = 5706,

        VDIVPHZ128rmb = 5707,

        VDIVPHZ128rmbk = 5708,

        VDIVPHZ128rmbkz = 5709,

        VDIVPHZ128rmk = 5710,

        VDIVPHZ128rmkz = 5711,

        VDIVPHZ128rr = 5712,

        VDIVPHZ128rrk = 5713,

        VDIVPHZ128rrkz = 5714,

        VDIVPHZ256rm = 5715,

        VDIVPHZ256rmb = 5716,

        VDIVPHZ256rmbk = 5717,

        VDIVPHZ256rmbkz = 5718,

        VDIVPHZ256rmk = 5719,

        VDIVPHZ256rmkz = 5720,

        VDIVPHZ256rr = 5721,

        VDIVPHZ256rrk = 5722,

        VDIVPHZ256rrkz = 5723,

        VDIVPHZrm = 5724,

        VDIVPHZrmb = 5725,

        VDIVPHZrmbk = 5726,

        VDIVPHZrmbkz = 5727,

        VDIVPHZrmk = 5728,

        VDIVPHZrmkz = 5729,

        VDIVPHZrr = 5730,

        VDIVPHZrrb = 5731,

        VDIVPHZrrbk = 5732,

        VDIVPHZrrbkz = 5733,

        VDIVPHZrrk = 5734,

        VDIVPHZrrkz = 5735,

        VDIVPSYrm = 5736,

        VDIVPSYrr = 5737,

        VDIVPSZ128rm = 5738,

        VDIVPSZ128rmb = 5739,

        VDIVPSZ128rmbk = 5740,

        VDIVPSZ128rmbkz = 5741,

        VDIVPSZ128rmk = 5742,

        VDIVPSZ128rmkz = 5743,

        VDIVPSZ128rr = 5744,

        VDIVPSZ128rrk = 5745,

        VDIVPSZ128rrkz = 5746,

        VDIVPSZ256rm = 5747,

        VDIVPSZ256rmb = 5748,

        VDIVPSZ256rmbk = 5749,

        VDIVPSZ256rmbkz = 5750,

        VDIVPSZ256rmk = 5751,

        VDIVPSZ256rmkz = 5752,

        VDIVPSZ256rr = 5753,

        VDIVPSZ256rrk = 5754,

        VDIVPSZ256rrkz = 5755,

        VDIVPSZrm = 5756,

        VDIVPSZrmb = 5757,

        VDIVPSZrmbk = 5758,

        VDIVPSZrmbkz = 5759,

        VDIVPSZrmk = 5760,

        VDIVPSZrmkz = 5761,

        VDIVPSZrr = 5762,

        VDIVPSZrrb = 5763,

        VDIVPSZrrbk = 5764,

        VDIVPSZrrbkz = 5765,

        VDIVPSZrrk = 5766,

        VDIVPSZrrkz = 5767,

        VDIVPSrm = 5768,

        VDIVPSrr = 5769,

        VDIVSDZrm = 5770,

        VDIVSDZrm_Int = 5771,

        VDIVSDZrm_Intk = 5772,

        VDIVSDZrm_Intkz = 5773,

        VDIVSDZrr = 5774,

        VDIVSDZrr_Int = 5775,

        VDIVSDZrr_Intk = 5776,

        VDIVSDZrr_Intkz = 5777,

        VDIVSDZrrb_Int = 5778,

        VDIVSDZrrb_Intk = 5779,

        VDIVSDZrrb_Intkz = 5780,

        VDIVSDrm = 5781,

        VDIVSDrm_Int = 5782,

        VDIVSDrr = 5783,

        VDIVSDrr_Int = 5784,

        VDIVSHZrm = 5785,

        VDIVSHZrm_Int = 5786,

        VDIVSHZrm_Intk = 5787,

        VDIVSHZrm_Intkz = 5788,

        VDIVSHZrr = 5789,

        VDIVSHZrr_Int = 5790,

        VDIVSHZrr_Intk = 5791,

        VDIVSHZrr_Intkz = 5792,

        VDIVSHZrrb_Int = 5793,

        VDIVSHZrrb_Intk = 5794,

        VDIVSHZrrb_Intkz = 5795,

        VDIVSSZrm = 5796,

        VDIVSSZrm_Int = 5797,

        VDIVSSZrm_Intk = 5798,

        VDIVSSZrm_Intkz = 5799,

        VDIVSSZrr = 5800,

        VDIVSSZrr_Int = 5801,

        VDIVSSZrr_Intk = 5802,

        VDIVSSZrr_Intkz = 5803,

        VDIVSSZrrb_Int = 5804,

        VDIVSSZrrb_Intk = 5805,

        VDIVSSZrrb_Intkz = 5806,

        VDIVSSrm = 5807,

        VDIVSSrm_Int = 5808,

        VDIVSSrr = 5809,

        VDIVSSrr_Int = 5810,

        VDPBF16PSZ128m = 5811,

        VDPBF16PSZ128mb = 5812,

        VDPBF16PSZ128mbk = 5813,

        VDPBF16PSZ128mbkz = 5814,

        VDPBF16PSZ128mk = 5815,

        VDPBF16PSZ128mkz = 5816,

        VDPBF16PSZ128r = 5817,

        VDPBF16PSZ128rk = 5818,

        VDPBF16PSZ128rkz = 5819,

        VDPBF16PSZ256m = 5820,

        VDPBF16PSZ256mb = 5821,

        VDPBF16PSZ256mbk = 5822,

        VDPBF16PSZ256mbkz = 5823,

        VDPBF16PSZ256mk = 5824,

        VDPBF16PSZ256mkz = 5825,

        VDPBF16PSZ256r = 5826,

        VDPBF16PSZ256rk = 5827,

        VDPBF16PSZ256rkz = 5828,

        VDPBF16PSZm = 5829,

        VDPBF16PSZmb = 5830,

        VDPBF16PSZmbk = 5831,

        VDPBF16PSZmbkz = 5832,

        VDPBF16PSZmk = 5833,

        VDPBF16PSZmkz = 5834,

        VDPBF16PSZr = 5835,

        VDPBF16PSZrk = 5836,

        VDPBF16PSZrkz = 5837,

        VDPPDrmi = 5838,

        VDPPDrri = 5839,

        VDPPSYrmi = 5840,

        VDPPSYrri = 5841,

        VDPPSrmi = 5842,

        VDPPSrri = 5843,

        VERRm = 5844,

        VERRr = 5845,

        VERWm = 5846,

        VERWr = 5847,

        VEXP2PDZm = 5848,

        VEXP2PDZmb = 5849,

        VEXP2PDZmbk = 5850,

        VEXP2PDZmbkz = 5851,

        VEXP2PDZmk = 5852,

        VEXP2PDZmkz = 5853,

        VEXP2PDZr = 5854,

        VEXP2PDZrb = 5855,

        VEXP2PDZrbk = 5856,

        VEXP2PDZrbkz = 5857,

        VEXP2PDZrk = 5858,

        VEXP2PDZrkz = 5859,

        VEXP2PSZm = 5860,

        VEXP2PSZmb = 5861,

        VEXP2PSZmbk = 5862,

        VEXP2PSZmbkz = 5863,

        VEXP2PSZmk = 5864,

        VEXP2PSZmkz = 5865,

        VEXP2PSZr = 5866,

        VEXP2PSZrb = 5867,

        VEXP2PSZrbk = 5868,

        VEXP2PSZrbkz = 5869,

        VEXP2PSZrk = 5870,

        VEXP2PSZrkz = 5871,

        VEXPANDPDZ128rm = 5872,

        VEXPANDPDZ128rmk = 5873,

        VEXPANDPDZ128rmkz = 5874,

        VEXPANDPDZ128rr = 5875,

        VEXPANDPDZ128rrk = 5876,

        VEXPANDPDZ128rrkz = 5877,

        VEXPANDPDZ256rm = 5878,

        VEXPANDPDZ256rmk = 5879,

        VEXPANDPDZ256rmkz = 5880,

        VEXPANDPDZ256rr = 5881,

        VEXPANDPDZ256rrk = 5882,

        VEXPANDPDZ256rrkz = 5883,

        VEXPANDPDZrm = 5884,

        VEXPANDPDZrmk = 5885,

        VEXPANDPDZrmkz = 5886,

        VEXPANDPDZrr = 5887,

        VEXPANDPDZrrk = 5888,

        VEXPANDPDZrrkz = 5889,

        VEXPANDPSZ128rm = 5890,

        VEXPANDPSZ128rmk = 5891,

        VEXPANDPSZ128rmkz = 5892,

        VEXPANDPSZ128rr = 5893,

        VEXPANDPSZ128rrk = 5894,

        VEXPANDPSZ128rrkz = 5895,

        VEXPANDPSZ256rm = 5896,

        VEXPANDPSZ256rmk = 5897,

        VEXPANDPSZ256rmkz = 5898,

        VEXPANDPSZ256rr = 5899,

        VEXPANDPSZ256rrk = 5900,

        VEXPANDPSZ256rrkz = 5901,

        VEXPANDPSZrm = 5902,

        VEXPANDPSZrmk = 5903,

        VEXPANDPSZrmkz = 5904,

        VEXPANDPSZrr = 5905,

        VEXPANDPSZrrk = 5906,

        VEXPANDPSZrrkz = 5907,

        VEXTRACTF128mr = 5908,

        VEXTRACTF128rr = 5909,

        VEXTRACTF32x4Z256mr = 5910,

        VEXTRACTF32x4Z256mrk = 5911,

        VEXTRACTF32x4Z256rr = 5912,

        VEXTRACTF32x4Z256rrk = 5913,

        VEXTRACTF32x4Z256rrkz = 5914,

        VEXTRACTF32x4Zmr = 5915,

        VEXTRACTF32x4Zmrk = 5916,

        VEXTRACTF32x4Zrr = 5917,

        VEXTRACTF32x4Zrrk = 5918,

        VEXTRACTF32x4Zrrkz = 5919,

        VEXTRACTF32x8Zmr = 5920,

        VEXTRACTF32x8Zmrk = 5921,

        VEXTRACTF32x8Zrr = 5922,

        VEXTRACTF32x8Zrrk = 5923,

        VEXTRACTF32x8Zrrkz = 5924,

        VEXTRACTF64x2Z256mr = 5925,

        VEXTRACTF64x2Z256mrk = 5926,

        VEXTRACTF64x2Z256rr = 5927,

        VEXTRACTF64x2Z256rrk = 5928,

        VEXTRACTF64x2Z256rrkz = 5929,

        VEXTRACTF64x2Zmr = 5930,

        VEXTRACTF64x2Zmrk = 5931,

        VEXTRACTF64x2Zrr = 5932,

        VEXTRACTF64x2Zrrk = 5933,

        VEXTRACTF64x2Zrrkz = 5934,

        VEXTRACTF64x4Zmr = 5935,

        VEXTRACTF64x4Zmrk = 5936,

        VEXTRACTF64x4Zrr = 5937,

        VEXTRACTF64x4Zrrk = 5938,

        VEXTRACTF64x4Zrrkz = 5939,

        VEXTRACTI128mr = 5940,

        VEXTRACTI128rr = 5941,

        VEXTRACTI32x4Z256mr = 5942,

        VEXTRACTI32x4Z256mrk = 5943,

        VEXTRACTI32x4Z256rr = 5944,

        VEXTRACTI32x4Z256rrk = 5945,

        VEXTRACTI32x4Z256rrkz = 5946,

        VEXTRACTI32x4Zmr = 5947,

        VEXTRACTI32x4Zmrk = 5948,

        VEXTRACTI32x4Zrr = 5949,

        VEXTRACTI32x4Zrrk = 5950,

        VEXTRACTI32x4Zrrkz = 5951,

        VEXTRACTI32x8Zmr = 5952,

        VEXTRACTI32x8Zmrk = 5953,

        VEXTRACTI32x8Zrr = 5954,

        VEXTRACTI32x8Zrrk = 5955,

        VEXTRACTI32x8Zrrkz = 5956,

        VEXTRACTI64x2Z256mr = 5957,

        VEXTRACTI64x2Z256mrk = 5958,

        VEXTRACTI64x2Z256rr = 5959,

        VEXTRACTI64x2Z256rrk = 5960,

        VEXTRACTI64x2Z256rrkz = 5961,

        VEXTRACTI64x2Zmr = 5962,

        VEXTRACTI64x2Zmrk = 5963,

        VEXTRACTI64x2Zrr = 5964,

        VEXTRACTI64x2Zrrk = 5965,

        VEXTRACTI64x2Zrrkz = 5966,

        VEXTRACTI64x4Zmr = 5967,

        VEXTRACTI64x4Zmrk = 5968,

        VEXTRACTI64x4Zrr = 5969,

        VEXTRACTI64x4Zrrk = 5970,

        VEXTRACTI64x4Zrrkz = 5971,

        VEXTRACTPSZmr = 5972,

        VEXTRACTPSZrr = 5973,

        VEXTRACTPSmr = 5974,

        VEXTRACTPSrr = 5975,

        VFCMADDCPHZ128m = 5976,

        VFCMADDCPHZ128mb = 5977,

        VFCMADDCPHZ128mbk = 5978,

        VFCMADDCPHZ128mbkz = 5979,

        VFCMADDCPHZ128mk = 5980,

        VFCMADDCPHZ128mkz = 5981,

        VFCMADDCPHZ128r = 5982,

        VFCMADDCPHZ128rk = 5983,

        VFCMADDCPHZ128rkz = 5984,

        VFCMADDCPHZ256m = 5985,

        VFCMADDCPHZ256mb = 5986,

        VFCMADDCPHZ256mbk = 5987,

        VFCMADDCPHZ256mbkz = 5988,

        VFCMADDCPHZ256mk = 5989,

        VFCMADDCPHZ256mkz = 5990,

        VFCMADDCPHZ256r = 5991,

        VFCMADDCPHZ256rk = 5992,

        VFCMADDCPHZ256rkz = 5993,

        VFCMADDCPHZm = 5994,

        VFCMADDCPHZmb = 5995,

        VFCMADDCPHZmbk = 5996,

        VFCMADDCPHZmbkz = 5997,

        VFCMADDCPHZmk = 5998,

        VFCMADDCPHZmkz = 5999,

        VFCMADDCPHZr = 6000,

        VFCMADDCPHZrb = 6001,

        VFCMADDCPHZrbk = 6002,

        VFCMADDCPHZrbkz = 6003,

        VFCMADDCPHZrk = 6004,

        VFCMADDCPHZrkz = 6005,

        VFCMADDCSHZm = 6006,

        VFCMADDCSHZmk = 6007,

        VFCMADDCSHZmkz = 6008,

        VFCMADDCSHZr = 6009,

        VFCMADDCSHZrb = 6010,

        VFCMADDCSHZrbk = 6011,

        VFCMADDCSHZrbkz = 6012,

        VFCMADDCSHZrk = 6013,

        VFCMADDCSHZrkz = 6014,

        VFCMULCPHZ128rm = 6015,

        VFCMULCPHZ128rmb = 6016,

        VFCMULCPHZ128rmbk = 6017,

        VFCMULCPHZ128rmbkz = 6018,

        VFCMULCPHZ128rmk = 6019,

        VFCMULCPHZ128rmkz = 6020,

        VFCMULCPHZ128rr = 6021,

        VFCMULCPHZ128rrk = 6022,

        VFCMULCPHZ128rrkz = 6023,

        VFCMULCPHZ256rm = 6024,

        VFCMULCPHZ256rmb = 6025,

        VFCMULCPHZ256rmbk = 6026,

        VFCMULCPHZ256rmbkz = 6027,

        VFCMULCPHZ256rmk = 6028,

        VFCMULCPHZ256rmkz = 6029,

        VFCMULCPHZ256rr = 6030,

        VFCMULCPHZ256rrk = 6031,

        VFCMULCPHZ256rrkz = 6032,

        VFCMULCPHZrm = 6033,

        VFCMULCPHZrmb = 6034,

        VFCMULCPHZrmbk = 6035,

        VFCMULCPHZrmbkz = 6036,

        VFCMULCPHZrmk = 6037,

        VFCMULCPHZrmkz = 6038,

        VFCMULCPHZrr = 6039,

        VFCMULCPHZrrb = 6040,

        VFCMULCPHZrrbk = 6041,

        VFCMULCPHZrrbkz = 6042,

        VFCMULCPHZrrk = 6043,

        VFCMULCPHZrrkz = 6044,

        VFCMULCSHZrm = 6045,

        VFCMULCSHZrmk = 6046,

        VFCMULCSHZrmkz = 6047,

        VFCMULCSHZrr = 6048,

        VFCMULCSHZrrb = 6049,

        VFCMULCSHZrrbk = 6050,

        VFCMULCSHZrrbkz = 6051,

        VFCMULCSHZrrk = 6052,

        VFCMULCSHZrrkz = 6053,

        VFIXUPIMMPDZ128rmbi = 6054,

        VFIXUPIMMPDZ128rmbik = 6055,

        VFIXUPIMMPDZ128rmbikz = 6056,

        VFIXUPIMMPDZ128rmi = 6057,

        VFIXUPIMMPDZ128rmik = 6058,

        VFIXUPIMMPDZ128rmikz = 6059,

        VFIXUPIMMPDZ128rri = 6060,

        VFIXUPIMMPDZ128rrik = 6061,

        VFIXUPIMMPDZ128rrikz = 6062,

        VFIXUPIMMPDZ256rmbi = 6063,

        VFIXUPIMMPDZ256rmbik = 6064,

        VFIXUPIMMPDZ256rmbikz = 6065,

        VFIXUPIMMPDZ256rmi = 6066,

        VFIXUPIMMPDZ256rmik = 6067,

        VFIXUPIMMPDZ256rmikz = 6068,

        VFIXUPIMMPDZ256rri = 6069,

        VFIXUPIMMPDZ256rrik = 6070,

        VFIXUPIMMPDZ256rrikz = 6071,

        VFIXUPIMMPDZrmbi = 6072,

        VFIXUPIMMPDZrmbik = 6073,

        VFIXUPIMMPDZrmbikz = 6074,

        VFIXUPIMMPDZrmi = 6075,

        VFIXUPIMMPDZrmik = 6076,

        VFIXUPIMMPDZrmikz = 6077,

        VFIXUPIMMPDZrri = 6078,

        VFIXUPIMMPDZrrib = 6079,

        VFIXUPIMMPDZrribk = 6080,

        VFIXUPIMMPDZrribkz = 6081,

        VFIXUPIMMPDZrrik = 6082,

        VFIXUPIMMPDZrrikz = 6083,

        VFIXUPIMMPSZ128rmbi = 6084,

        VFIXUPIMMPSZ128rmbik = 6085,

        VFIXUPIMMPSZ128rmbikz = 6086,

        VFIXUPIMMPSZ128rmi = 6087,

        VFIXUPIMMPSZ128rmik = 6088,

        VFIXUPIMMPSZ128rmikz = 6089,

        VFIXUPIMMPSZ128rri = 6090,

        VFIXUPIMMPSZ128rrik = 6091,

        VFIXUPIMMPSZ128rrikz = 6092,

        VFIXUPIMMPSZ256rmbi = 6093,

        VFIXUPIMMPSZ256rmbik = 6094,

        VFIXUPIMMPSZ256rmbikz = 6095,

        VFIXUPIMMPSZ256rmi = 6096,

        VFIXUPIMMPSZ256rmik = 6097,

        VFIXUPIMMPSZ256rmikz = 6098,

        VFIXUPIMMPSZ256rri = 6099,

        VFIXUPIMMPSZ256rrik = 6100,

        VFIXUPIMMPSZ256rrikz = 6101,

        VFIXUPIMMPSZrmbi = 6102,

        VFIXUPIMMPSZrmbik = 6103,

        VFIXUPIMMPSZrmbikz = 6104,

        VFIXUPIMMPSZrmi = 6105,

        VFIXUPIMMPSZrmik = 6106,

        VFIXUPIMMPSZrmikz = 6107,

        VFIXUPIMMPSZrri = 6108,

        VFIXUPIMMPSZrrib = 6109,

        VFIXUPIMMPSZrribk = 6110,

        VFIXUPIMMPSZrribkz = 6111,

        VFIXUPIMMPSZrrik = 6112,

        VFIXUPIMMPSZrrikz = 6113,

        VFIXUPIMMSDZrmi = 6114,

        VFIXUPIMMSDZrmik = 6115,

        VFIXUPIMMSDZrmikz = 6116,

        VFIXUPIMMSDZrri = 6117,

        VFIXUPIMMSDZrrib = 6118,

        VFIXUPIMMSDZrribk = 6119,

        VFIXUPIMMSDZrribkz = 6120,

        VFIXUPIMMSDZrrik = 6121,

        VFIXUPIMMSDZrrikz = 6122,

        VFIXUPIMMSSZrmi = 6123,

        VFIXUPIMMSSZrmik = 6124,

        VFIXUPIMMSSZrmikz = 6125,

        VFIXUPIMMSSZrri = 6126,

        VFIXUPIMMSSZrrib = 6127,

        VFIXUPIMMSSZrribk = 6128,

        VFIXUPIMMSSZrribkz = 6129,

        VFIXUPIMMSSZrrik = 6130,

        VFIXUPIMMSSZrrikz = 6131,

        VFMADD132PDYm = 6132,

        VFMADD132PDYr = 6133,

        VFMADD132PDZ128m = 6134,

        VFMADD132PDZ128mb = 6135,

        VFMADD132PDZ128mbk = 6136,

        VFMADD132PDZ128mbkz = 6137,

        VFMADD132PDZ128mk = 6138,

        VFMADD132PDZ128mkz = 6139,

        VFMADD132PDZ128r = 6140,

        VFMADD132PDZ128rk = 6141,

        VFMADD132PDZ128rkz = 6142,

        VFMADD132PDZ256m = 6143,

        VFMADD132PDZ256mb = 6144,

        VFMADD132PDZ256mbk = 6145,

        VFMADD132PDZ256mbkz = 6146,

        VFMADD132PDZ256mk = 6147,

        VFMADD132PDZ256mkz = 6148,

        VFMADD132PDZ256r = 6149,

        VFMADD132PDZ256rk = 6150,

        VFMADD132PDZ256rkz = 6151,

        VFMADD132PDZm = 6152,

        VFMADD132PDZmb = 6153,

        VFMADD132PDZmbk = 6154,

        VFMADD132PDZmbkz = 6155,

        VFMADD132PDZmk = 6156,

        VFMADD132PDZmkz = 6157,

        VFMADD132PDZr = 6158,

        VFMADD132PDZrb = 6159,

        VFMADD132PDZrbk = 6160,

        VFMADD132PDZrbkz = 6161,

        VFMADD132PDZrk = 6162,

        VFMADD132PDZrkz = 6163,

        VFMADD132PDm = 6164,

        VFMADD132PDr = 6165,

        VFMADD132PHZ128m = 6166,

        VFMADD132PHZ128mb = 6167,

        VFMADD132PHZ128mbk = 6168,

        VFMADD132PHZ128mbkz = 6169,

        VFMADD132PHZ128mk = 6170,

        VFMADD132PHZ128mkz = 6171,

        VFMADD132PHZ128r = 6172,

        VFMADD132PHZ128rk = 6173,

        VFMADD132PHZ128rkz = 6174,

        VFMADD132PHZ256m = 6175,

        VFMADD132PHZ256mb = 6176,

        VFMADD132PHZ256mbk = 6177,

        VFMADD132PHZ256mbkz = 6178,

        VFMADD132PHZ256mk = 6179,

        VFMADD132PHZ256mkz = 6180,

        VFMADD132PHZ256r = 6181,

        VFMADD132PHZ256rk = 6182,

        VFMADD132PHZ256rkz = 6183,

        VFMADD132PHZm = 6184,

        VFMADD132PHZmb = 6185,

        VFMADD132PHZmbk = 6186,

        VFMADD132PHZmbkz = 6187,

        VFMADD132PHZmk = 6188,

        VFMADD132PHZmkz = 6189,

        VFMADD132PHZr = 6190,

        VFMADD132PHZrb = 6191,

        VFMADD132PHZrbk = 6192,

        VFMADD132PHZrbkz = 6193,

        VFMADD132PHZrk = 6194,

        VFMADD132PHZrkz = 6195,

        VFMADD132PSYm = 6196,

        VFMADD132PSYr = 6197,

        VFMADD132PSZ128m = 6198,

        VFMADD132PSZ128mb = 6199,

        VFMADD132PSZ128mbk = 6200,

        VFMADD132PSZ128mbkz = 6201,

        VFMADD132PSZ128mk = 6202,

        VFMADD132PSZ128mkz = 6203,

        VFMADD132PSZ128r = 6204,

        VFMADD132PSZ128rk = 6205,

        VFMADD132PSZ128rkz = 6206,

        VFMADD132PSZ256m = 6207,

        VFMADD132PSZ256mb = 6208,

        VFMADD132PSZ256mbk = 6209,

        VFMADD132PSZ256mbkz = 6210,

        VFMADD132PSZ256mk = 6211,

        VFMADD132PSZ256mkz = 6212,

        VFMADD132PSZ256r = 6213,

        VFMADD132PSZ256rk = 6214,

        VFMADD132PSZ256rkz = 6215,

        VFMADD132PSZm = 6216,

        VFMADD132PSZmb = 6217,

        VFMADD132PSZmbk = 6218,

        VFMADD132PSZmbkz = 6219,

        VFMADD132PSZmk = 6220,

        VFMADD132PSZmkz = 6221,

        VFMADD132PSZr = 6222,

        VFMADD132PSZrb = 6223,

        VFMADD132PSZrbk = 6224,

        VFMADD132PSZrbkz = 6225,

        VFMADD132PSZrk = 6226,

        VFMADD132PSZrkz = 6227,

        VFMADD132PSm = 6228,

        VFMADD132PSr = 6229,

        VFMADD132SDZm = 6230,

        VFMADD132SDZm_Int = 6231,

        VFMADD132SDZm_Intk = 6232,

        VFMADD132SDZm_Intkz = 6233,

        VFMADD132SDZr = 6234,

        VFMADD132SDZr_Int = 6235,

        VFMADD132SDZr_Intk = 6236,

        VFMADD132SDZr_Intkz = 6237,

        VFMADD132SDZrb = 6238,

        VFMADD132SDZrb_Int = 6239,

        VFMADD132SDZrb_Intk = 6240,

        VFMADD132SDZrb_Intkz = 6241,

        VFMADD132SDm = 6242,

        VFMADD132SDm_Int = 6243,

        VFMADD132SDr = 6244,

        VFMADD132SDr_Int = 6245,

        VFMADD132SHZm = 6246,

        VFMADD132SHZm_Int = 6247,

        VFMADD132SHZm_Intk = 6248,

        VFMADD132SHZm_Intkz = 6249,

        VFMADD132SHZr = 6250,

        VFMADD132SHZr_Int = 6251,

        VFMADD132SHZr_Intk = 6252,

        VFMADD132SHZr_Intkz = 6253,

        VFMADD132SHZrb = 6254,

        VFMADD132SHZrb_Int = 6255,

        VFMADD132SHZrb_Intk = 6256,

        VFMADD132SHZrb_Intkz = 6257,

        VFMADD132SSZm = 6258,

        VFMADD132SSZm_Int = 6259,

        VFMADD132SSZm_Intk = 6260,

        VFMADD132SSZm_Intkz = 6261,

        VFMADD132SSZr = 6262,

        VFMADD132SSZr_Int = 6263,

        VFMADD132SSZr_Intk = 6264,

        VFMADD132SSZr_Intkz = 6265,

        VFMADD132SSZrb = 6266,

        VFMADD132SSZrb_Int = 6267,

        VFMADD132SSZrb_Intk = 6268,

        VFMADD132SSZrb_Intkz = 6269,

        VFMADD132SSm = 6270,

        VFMADD132SSm_Int = 6271,

        VFMADD132SSr = 6272,

        VFMADD132SSr_Int = 6273,

        VFMADD213PDYm = 6274,

        VFMADD213PDYr = 6275,

        VFMADD213PDZ128m = 6276,

        VFMADD213PDZ128mb = 6277,

        VFMADD213PDZ128mbk = 6278,

        VFMADD213PDZ128mbkz = 6279,

        VFMADD213PDZ128mk = 6280,

        VFMADD213PDZ128mkz = 6281,

        VFMADD213PDZ128r = 6282,

        VFMADD213PDZ128rk = 6283,

        VFMADD213PDZ128rkz = 6284,

        VFMADD213PDZ256m = 6285,

        VFMADD213PDZ256mb = 6286,

        VFMADD213PDZ256mbk = 6287,

        VFMADD213PDZ256mbkz = 6288,

        VFMADD213PDZ256mk = 6289,

        VFMADD213PDZ256mkz = 6290,

        VFMADD213PDZ256r = 6291,

        VFMADD213PDZ256rk = 6292,

        VFMADD213PDZ256rkz = 6293,

        VFMADD213PDZm = 6294,

        VFMADD213PDZmb = 6295,

        VFMADD213PDZmbk = 6296,

        VFMADD213PDZmbkz = 6297,

        VFMADD213PDZmk = 6298,

        VFMADD213PDZmkz = 6299,

        VFMADD213PDZr = 6300,

        VFMADD213PDZrb = 6301,

        VFMADD213PDZrbk = 6302,

        VFMADD213PDZrbkz = 6303,

        VFMADD213PDZrk = 6304,

        VFMADD213PDZrkz = 6305,

        VFMADD213PDm = 6306,

        VFMADD213PDr = 6307,

        VFMADD213PHZ128m = 6308,

        VFMADD213PHZ128mb = 6309,

        VFMADD213PHZ128mbk = 6310,

        VFMADD213PHZ128mbkz = 6311,

        VFMADD213PHZ128mk = 6312,

        VFMADD213PHZ128mkz = 6313,

        VFMADD213PHZ128r = 6314,

        VFMADD213PHZ128rk = 6315,

        VFMADD213PHZ128rkz = 6316,

        VFMADD213PHZ256m = 6317,

        VFMADD213PHZ256mb = 6318,

        VFMADD213PHZ256mbk = 6319,

        VFMADD213PHZ256mbkz = 6320,

        VFMADD213PHZ256mk = 6321,

        VFMADD213PHZ256mkz = 6322,

        VFMADD213PHZ256r = 6323,

        VFMADD213PHZ256rk = 6324,

        VFMADD213PHZ256rkz = 6325,

        VFMADD213PHZm = 6326,

        VFMADD213PHZmb = 6327,

        VFMADD213PHZmbk = 6328,

        VFMADD213PHZmbkz = 6329,

        VFMADD213PHZmk = 6330,

        VFMADD213PHZmkz = 6331,

        VFMADD213PHZr = 6332,

        VFMADD213PHZrb = 6333,

        VFMADD213PHZrbk = 6334,

        VFMADD213PHZrbkz = 6335,

        VFMADD213PHZrk = 6336,

        VFMADD213PHZrkz = 6337,

        VFMADD213PSYm = 6338,

        VFMADD213PSYr = 6339,

        VFMADD213PSZ128m = 6340,

        VFMADD213PSZ128mb = 6341,

        VFMADD213PSZ128mbk = 6342,

        VFMADD213PSZ128mbkz = 6343,

        VFMADD213PSZ128mk = 6344,

        VFMADD213PSZ128mkz = 6345,

        VFMADD213PSZ128r = 6346,

        VFMADD213PSZ128rk = 6347,

        VFMADD213PSZ128rkz = 6348,

        VFMADD213PSZ256m = 6349,

        VFMADD213PSZ256mb = 6350,

        VFMADD213PSZ256mbk = 6351,

        VFMADD213PSZ256mbkz = 6352,

        VFMADD213PSZ256mk = 6353,

        VFMADD213PSZ256mkz = 6354,

        VFMADD213PSZ256r = 6355,

        VFMADD213PSZ256rk = 6356,

        VFMADD213PSZ256rkz = 6357,

        VFMADD213PSZm = 6358,

        VFMADD213PSZmb = 6359,

        VFMADD213PSZmbk = 6360,

        VFMADD213PSZmbkz = 6361,

        VFMADD213PSZmk = 6362,

        VFMADD213PSZmkz = 6363,

        VFMADD213PSZr = 6364,

        VFMADD213PSZrb = 6365,

        VFMADD213PSZrbk = 6366,

        VFMADD213PSZrbkz = 6367,

        VFMADD213PSZrk = 6368,

        VFMADD213PSZrkz = 6369,

        VFMADD213PSm = 6370,

        VFMADD213PSr = 6371,

        VFMADD213SDZm = 6372,

        VFMADD213SDZm_Int = 6373,

        VFMADD213SDZm_Intk = 6374,

        VFMADD213SDZm_Intkz = 6375,

        VFMADD213SDZr = 6376,

        VFMADD213SDZr_Int = 6377,

        VFMADD213SDZr_Intk = 6378,

        VFMADD213SDZr_Intkz = 6379,

        VFMADD213SDZrb = 6380,

        VFMADD213SDZrb_Int = 6381,

        VFMADD213SDZrb_Intk = 6382,

        VFMADD213SDZrb_Intkz = 6383,

        VFMADD213SDm = 6384,

        VFMADD213SDm_Int = 6385,

        VFMADD213SDr = 6386,

        VFMADD213SDr_Int = 6387,

        VFMADD213SHZm = 6388,

        VFMADD213SHZm_Int = 6389,

        VFMADD213SHZm_Intk = 6390,

        VFMADD213SHZm_Intkz = 6391,

        VFMADD213SHZr = 6392,

        VFMADD213SHZr_Int = 6393,

        VFMADD213SHZr_Intk = 6394,

        VFMADD213SHZr_Intkz = 6395,

        VFMADD213SHZrb = 6396,

        VFMADD213SHZrb_Int = 6397,

        VFMADD213SHZrb_Intk = 6398,

        VFMADD213SHZrb_Intkz = 6399,

        VFMADD213SSZm = 6400,

        VFMADD213SSZm_Int = 6401,

        VFMADD213SSZm_Intk = 6402,

        VFMADD213SSZm_Intkz = 6403,

        VFMADD213SSZr = 6404,

        VFMADD213SSZr_Int = 6405,

        VFMADD213SSZr_Intk = 6406,

        VFMADD213SSZr_Intkz = 6407,

        VFMADD213SSZrb = 6408,

        VFMADD213SSZrb_Int = 6409,

        VFMADD213SSZrb_Intk = 6410,

        VFMADD213SSZrb_Intkz = 6411,

        VFMADD213SSm = 6412,

        VFMADD213SSm_Int = 6413,

        VFMADD213SSr = 6414,

        VFMADD213SSr_Int = 6415,

        VFMADD231PDYm = 6416,

        VFMADD231PDYr = 6417,

        VFMADD231PDZ128m = 6418,

        VFMADD231PDZ128mb = 6419,

        VFMADD231PDZ128mbk = 6420,

        VFMADD231PDZ128mbkz = 6421,

        VFMADD231PDZ128mk = 6422,

        VFMADD231PDZ128mkz = 6423,

        VFMADD231PDZ128r = 6424,

        VFMADD231PDZ128rk = 6425,

        VFMADD231PDZ128rkz = 6426,

        VFMADD231PDZ256m = 6427,

        VFMADD231PDZ256mb = 6428,

        VFMADD231PDZ256mbk = 6429,

        VFMADD231PDZ256mbkz = 6430,

        VFMADD231PDZ256mk = 6431,

        VFMADD231PDZ256mkz = 6432,

        VFMADD231PDZ256r = 6433,

        VFMADD231PDZ256rk = 6434,

        VFMADD231PDZ256rkz = 6435,

        VFMADD231PDZm = 6436,

        VFMADD231PDZmb = 6437,

        VFMADD231PDZmbk = 6438,

        VFMADD231PDZmbkz = 6439,

        VFMADD231PDZmk = 6440,

        VFMADD231PDZmkz = 6441,

        VFMADD231PDZr = 6442,

        VFMADD231PDZrb = 6443,

        VFMADD231PDZrbk = 6444,

        VFMADD231PDZrbkz = 6445,

        VFMADD231PDZrk = 6446,

        VFMADD231PDZrkz = 6447,

        VFMADD231PDm = 6448,

        VFMADD231PDr = 6449,

        VFMADD231PHZ128m = 6450,

        VFMADD231PHZ128mb = 6451,

        VFMADD231PHZ128mbk = 6452,

        VFMADD231PHZ128mbkz = 6453,

        VFMADD231PHZ128mk = 6454,

        VFMADD231PHZ128mkz = 6455,

        VFMADD231PHZ128r = 6456,

        VFMADD231PHZ128rk = 6457,

        VFMADD231PHZ128rkz = 6458,

        VFMADD231PHZ256m = 6459,

        VFMADD231PHZ256mb = 6460,

        VFMADD231PHZ256mbk = 6461,

        VFMADD231PHZ256mbkz = 6462,

        VFMADD231PHZ256mk = 6463,

        VFMADD231PHZ256mkz = 6464,

        VFMADD231PHZ256r = 6465,

        VFMADD231PHZ256rk = 6466,

        VFMADD231PHZ256rkz = 6467,

        VFMADD231PHZm = 6468,

        VFMADD231PHZmb = 6469,

        VFMADD231PHZmbk = 6470,

        VFMADD231PHZmbkz = 6471,

        VFMADD231PHZmk = 6472,

        VFMADD231PHZmkz = 6473,

        VFMADD231PHZr = 6474,

        VFMADD231PHZrb = 6475,

        VFMADD231PHZrbk = 6476,

        VFMADD231PHZrbkz = 6477,

        VFMADD231PHZrk = 6478,

        VFMADD231PHZrkz = 6479,

        VFMADD231PSYm = 6480,

        VFMADD231PSYr = 6481,

        VFMADD231PSZ128m = 6482,

        VFMADD231PSZ128mb = 6483,

        VFMADD231PSZ128mbk = 6484,

        VFMADD231PSZ128mbkz = 6485,

        VFMADD231PSZ128mk = 6486,

        VFMADD231PSZ128mkz = 6487,

        VFMADD231PSZ128r = 6488,

        VFMADD231PSZ128rk = 6489,

        VFMADD231PSZ128rkz = 6490,

        VFMADD231PSZ256m = 6491,

        VFMADD231PSZ256mb = 6492,

        VFMADD231PSZ256mbk = 6493,

        VFMADD231PSZ256mbkz = 6494,

        VFMADD231PSZ256mk = 6495,

        VFMADD231PSZ256mkz = 6496,

        VFMADD231PSZ256r = 6497,

        VFMADD231PSZ256rk = 6498,

        VFMADD231PSZ256rkz = 6499,

        VFMADD231PSZm = 6500,

        VFMADD231PSZmb = 6501,

        VFMADD231PSZmbk = 6502,

        VFMADD231PSZmbkz = 6503,

        VFMADD231PSZmk = 6504,

        VFMADD231PSZmkz = 6505,

        VFMADD231PSZr = 6506,

        VFMADD231PSZrb = 6507,

        VFMADD231PSZrbk = 6508,

        VFMADD231PSZrbkz = 6509,

        VFMADD231PSZrk = 6510,

        VFMADD231PSZrkz = 6511,

        VFMADD231PSm = 6512,

        VFMADD231PSr = 6513,

        VFMADD231SDZm = 6514,

        VFMADD231SDZm_Int = 6515,

        VFMADD231SDZm_Intk = 6516,

        VFMADD231SDZm_Intkz = 6517,

        VFMADD231SDZr = 6518,

        VFMADD231SDZr_Int = 6519,

        VFMADD231SDZr_Intk = 6520,

        VFMADD231SDZr_Intkz = 6521,

        VFMADD231SDZrb = 6522,

        VFMADD231SDZrb_Int = 6523,

        VFMADD231SDZrb_Intk = 6524,

        VFMADD231SDZrb_Intkz = 6525,

        VFMADD231SDm = 6526,

        VFMADD231SDm_Int = 6527,

        VFMADD231SDr = 6528,

        VFMADD231SDr_Int = 6529,

        VFMADD231SHZm = 6530,

        VFMADD231SHZm_Int = 6531,

        VFMADD231SHZm_Intk = 6532,

        VFMADD231SHZm_Intkz = 6533,

        VFMADD231SHZr = 6534,

        VFMADD231SHZr_Int = 6535,

        VFMADD231SHZr_Intk = 6536,

        VFMADD231SHZr_Intkz = 6537,

        VFMADD231SHZrb = 6538,

        VFMADD231SHZrb_Int = 6539,

        VFMADD231SHZrb_Intk = 6540,

        VFMADD231SHZrb_Intkz = 6541,

        VFMADD231SSZm = 6542,

        VFMADD231SSZm_Int = 6543,

        VFMADD231SSZm_Intk = 6544,

        VFMADD231SSZm_Intkz = 6545,

        VFMADD231SSZr = 6546,

        VFMADD231SSZr_Int = 6547,

        VFMADD231SSZr_Intk = 6548,

        VFMADD231SSZr_Intkz = 6549,

        VFMADD231SSZrb = 6550,

        VFMADD231SSZrb_Int = 6551,

        VFMADD231SSZrb_Intk = 6552,

        VFMADD231SSZrb_Intkz = 6553,

        VFMADD231SSm = 6554,

        VFMADD231SSm_Int = 6555,

        VFMADD231SSr = 6556,

        VFMADD231SSr_Int = 6557,

        VFMADDCPHZ128m = 6558,

        VFMADDCPHZ128mb = 6559,

        VFMADDCPHZ128mbk = 6560,

        VFMADDCPHZ128mbkz = 6561,

        VFMADDCPHZ128mk = 6562,

        VFMADDCPHZ128mkz = 6563,

        VFMADDCPHZ128r = 6564,

        VFMADDCPHZ128rk = 6565,

        VFMADDCPHZ128rkz = 6566,

        VFMADDCPHZ256m = 6567,

        VFMADDCPHZ256mb = 6568,

        VFMADDCPHZ256mbk = 6569,

        VFMADDCPHZ256mbkz = 6570,

        VFMADDCPHZ256mk = 6571,

        VFMADDCPHZ256mkz = 6572,

        VFMADDCPHZ256r = 6573,

        VFMADDCPHZ256rk = 6574,

        VFMADDCPHZ256rkz = 6575,

        VFMADDCPHZm = 6576,

        VFMADDCPHZmb = 6577,

        VFMADDCPHZmbk = 6578,

        VFMADDCPHZmbkz = 6579,

        VFMADDCPHZmk = 6580,

        VFMADDCPHZmkz = 6581,

        VFMADDCPHZr = 6582,

        VFMADDCPHZrb = 6583,

        VFMADDCPHZrbk = 6584,

        VFMADDCPHZrbkz = 6585,

        VFMADDCPHZrk = 6586,

        VFMADDCPHZrkz = 6587,

        VFMADDCSHZm = 6588,

        VFMADDCSHZmk = 6589,

        VFMADDCSHZmkz = 6590,

        VFMADDCSHZr = 6591,

        VFMADDCSHZrb = 6592,

        VFMADDCSHZrbk = 6593,

        VFMADDCSHZrbkz = 6594,

        VFMADDCSHZrk = 6595,

        VFMADDCSHZrkz = 6596,

        VFMADDPD4Ymr = 6597,

        VFMADDPD4Yrm = 6598,

        VFMADDPD4Yrr = 6599,

        VFMADDPD4Yrr_REV = 6600,

        VFMADDPD4mr = 6601,

        VFMADDPD4rm = 6602,

        VFMADDPD4rr = 6603,

        VFMADDPD4rr_REV = 6604,

        VFMADDPS4Ymr = 6605,

        VFMADDPS4Yrm = 6606,

        VFMADDPS4Yrr = 6607,

        VFMADDPS4Yrr_REV = 6608,

        VFMADDPS4mr = 6609,

        VFMADDPS4rm = 6610,

        VFMADDPS4rr = 6611,

        VFMADDPS4rr_REV = 6612,

        VFMADDSD4mr = 6613,

        VFMADDSD4mr_Int = 6614,

        VFMADDSD4rm = 6615,

        VFMADDSD4rm_Int = 6616,

        VFMADDSD4rr = 6617,

        VFMADDSD4rr_Int = 6618,

        VFMADDSD4rr_Int_REV = 6619,

        VFMADDSD4rr_REV = 6620,

        VFMADDSS4mr = 6621,

        VFMADDSS4mr_Int = 6622,

        VFMADDSS4rm = 6623,

        VFMADDSS4rm_Int = 6624,

        VFMADDSS4rr = 6625,

        VFMADDSS4rr_Int = 6626,

        VFMADDSS4rr_Int_REV = 6627,

        VFMADDSS4rr_REV = 6628,

        VFMADDSUB132PDYm = 6629,

        VFMADDSUB132PDYr = 6630,

        VFMADDSUB132PDZ128m = 6631,

        VFMADDSUB132PDZ128mb = 6632,

        VFMADDSUB132PDZ128mbk = 6633,

        VFMADDSUB132PDZ128mbkz = 6634,

        VFMADDSUB132PDZ128mk = 6635,

        VFMADDSUB132PDZ128mkz = 6636,

        VFMADDSUB132PDZ128r = 6637,

        VFMADDSUB132PDZ128rk = 6638,

        VFMADDSUB132PDZ128rkz = 6639,

        VFMADDSUB132PDZ256m = 6640,

        VFMADDSUB132PDZ256mb = 6641,

        VFMADDSUB132PDZ256mbk = 6642,

        VFMADDSUB132PDZ256mbkz = 6643,

        VFMADDSUB132PDZ256mk = 6644,

        VFMADDSUB132PDZ256mkz = 6645,

        VFMADDSUB132PDZ256r = 6646,

        VFMADDSUB132PDZ256rk = 6647,

        VFMADDSUB132PDZ256rkz = 6648,

        VFMADDSUB132PDZm = 6649,

        VFMADDSUB132PDZmb = 6650,

        VFMADDSUB132PDZmbk = 6651,

        VFMADDSUB132PDZmbkz = 6652,

        VFMADDSUB132PDZmk = 6653,

        VFMADDSUB132PDZmkz = 6654,

        VFMADDSUB132PDZr = 6655,

        VFMADDSUB132PDZrb = 6656,

        VFMADDSUB132PDZrbk = 6657,

        VFMADDSUB132PDZrbkz = 6658,

        VFMADDSUB132PDZrk = 6659,

        VFMADDSUB132PDZrkz = 6660,

        VFMADDSUB132PDm = 6661,

        VFMADDSUB132PDr = 6662,

        VFMADDSUB132PHZ128m = 6663,

        VFMADDSUB132PHZ128mb = 6664,

        VFMADDSUB132PHZ128mbk = 6665,

        VFMADDSUB132PHZ128mbkz = 6666,

        VFMADDSUB132PHZ128mk = 6667,

        VFMADDSUB132PHZ128mkz = 6668,

        VFMADDSUB132PHZ128r = 6669,

        VFMADDSUB132PHZ128rk = 6670,

        VFMADDSUB132PHZ128rkz = 6671,

        VFMADDSUB132PHZ256m = 6672,

        VFMADDSUB132PHZ256mb = 6673,

        VFMADDSUB132PHZ256mbk = 6674,

        VFMADDSUB132PHZ256mbkz = 6675,

        VFMADDSUB132PHZ256mk = 6676,

        VFMADDSUB132PHZ256mkz = 6677,

        VFMADDSUB132PHZ256r = 6678,

        VFMADDSUB132PHZ256rk = 6679,

        VFMADDSUB132PHZ256rkz = 6680,

        VFMADDSUB132PHZm = 6681,

        VFMADDSUB132PHZmb = 6682,

        VFMADDSUB132PHZmbk = 6683,

        VFMADDSUB132PHZmbkz = 6684,

        VFMADDSUB132PHZmk = 6685,

        VFMADDSUB132PHZmkz = 6686,

        VFMADDSUB132PHZr = 6687,

        VFMADDSUB132PHZrb = 6688,

        VFMADDSUB132PHZrbk = 6689,

        VFMADDSUB132PHZrbkz = 6690,

        VFMADDSUB132PHZrk = 6691,

        VFMADDSUB132PHZrkz = 6692,

        VFMADDSUB132PSYm = 6693,

        VFMADDSUB132PSYr = 6694,

        VFMADDSUB132PSZ128m = 6695,

        VFMADDSUB132PSZ128mb = 6696,

        VFMADDSUB132PSZ128mbk = 6697,

        VFMADDSUB132PSZ128mbkz = 6698,

        VFMADDSUB132PSZ128mk = 6699,

        VFMADDSUB132PSZ128mkz = 6700,

        VFMADDSUB132PSZ128r = 6701,

        VFMADDSUB132PSZ128rk = 6702,

        VFMADDSUB132PSZ128rkz = 6703,

        VFMADDSUB132PSZ256m = 6704,

        VFMADDSUB132PSZ256mb = 6705,

        VFMADDSUB132PSZ256mbk = 6706,

        VFMADDSUB132PSZ256mbkz = 6707,

        VFMADDSUB132PSZ256mk = 6708,

        VFMADDSUB132PSZ256mkz = 6709,

        VFMADDSUB132PSZ256r = 6710,

        VFMADDSUB132PSZ256rk = 6711,

        VFMADDSUB132PSZ256rkz = 6712,

        VFMADDSUB132PSZm = 6713,

        VFMADDSUB132PSZmb = 6714,

        VFMADDSUB132PSZmbk = 6715,

        VFMADDSUB132PSZmbkz = 6716,

        VFMADDSUB132PSZmk = 6717,

        VFMADDSUB132PSZmkz = 6718,

        VFMADDSUB132PSZr = 6719,

        VFMADDSUB132PSZrb = 6720,

        VFMADDSUB132PSZrbk = 6721,

        VFMADDSUB132PSZrbkz = 6722,

        VFMADDSUB132PSZrk = 6723,

        VFMADDSUB132PSZrkz = 6724,

        VFMADDSUB132PSm = 6725,

        VFMADDSUB132PSr = 6726,

        VFMADDSUB213PDYm = 6727,

        VFMADDSUB213PDYr = 6728,

        VFMADDSUB213PDZ128m = 6729,

        VFMADDSUB213PDZ128mb = 6730,

        VFMADDSUB213PDZ128mbk = 6731,

        VFMADDSUB213PDZ128mbkz = 6732,

        VFMADDSUB213PDZ128mk = 6733,

        VFMADDSUB213PDZ128mkz = 6734,

        VFMADDSUB213PDZ128r = 6735,

        VFMADDSUB213PDZ128rk = 6736,

        VFMADDSUB213PDZ128rkz = 6737,

        VFMADDSUB213PDZ256m = 6738,

        VFMADDSUB213PDZ256mb = 6739,

        VFMADDSUB213PDZ256mbk = 6740,

        VFMADDSUB213PDZ256mbkz = 6741,

        VFMADDSUB213PDZ256mk = 6742,

        VFMADDSUB213PDZ256mkz = 6743,

        VFMADDSUB213PDZ256r = 6744,

        VFMADDSUB213PDZ256rk = 6745,

        VFMADDSUB213PDZ256rkz = 6746,

        VFMADDSUB213PDZm = 6747,

        VFMADDSUB213PDZmb = 6748,

        VFMADDSUB213PDZmbk = 6749,

        VFMADDSUB213PDZmbkz = 6750,

        VFMADDSUB213PDZmk = 6751,

        VFMADDSUB213PDZmkz = 6752,

        VFMADDSUB213PDZr = 6753,

        VFMADDSUB213PDZrb = 6754,

        VFMADDSUB213PDZrbk = 6755,

        VFMADDSUB213PDZrbkz = 6756,

        VFMADDSUB213PDZrk = 6757,

        VFMADDSUB213PDZrkz = 6758,

        VFMADDSUB213PDm = 6759,

        VFMADDSUB213PDr = 6760,

        VFMADDSUB213PHZ128m = 6761,

        VFMADDSUB213PHZ128mb = 6762,

        VFMADDSUB213PHZ128mbk = 6763,

        VFMADDSUB213PHZ128mbkz = 6764,

        VFMADDSUB213PHZ128mk = 6765,

        VFMADDSUB213PHZ128mkz = 6766,

        VFMADDSUB213PHZ128r = 6767,

        VFMADDSUB213PHZ128rk = 6768,

        VFMADDSUB213PHZ128rkz = 6769,

        VFMADDSUB213PHZ256m = 6770,

        VFMADDSUB213PHZ256mb = 6771,

        VFMADDSUB213PHZ256mbk = 6772,

        VFMADDSUB213PHZ256mbkz = 6773,

        VFMADDSUB213PHZ256mk = 6774,

        VFMADDSUB213PHZ256mkz = 6775,

        VFMADDSUB213PHZ256r = 6776,

        VFMADDSUB213PHZ256rk = 6777,

        VFMADDSUB213PHZ256rkz = 6778,

        VFMADDSUB213PHZm = 6779,

        VFMADDSUB213PHZmb = 6780,

        VFMADDSUB213PHZmbk = 6781,

        VFMADDSUB213PHZmbkz = 6782,

        VFMADDSUB213PHZmk = 6783,

        VFMADDSUB213PHZmkz = 6784,

        VFMADDSUB213PHZr = 6785,

        VFMADDSUB213PHZrb = 6786,

        VFMADDSUB213PHZrbk = 6787,

        VFMADDSUB213PHZrbkz = 6788,

        VFMADDSUB213PHZrk = 6789,

        VFMADDSUB213PHZrkz = 6790,

        VFMADDSUB213PSYm = 6791,

        VFMADDSUB213PSYr = 6792,

        VFMADDSUB213PSZ128m = 6793,

        VFMADDSUB213PSZ128mb = 6794,

        VFMADDSUB213PSZ128mbk = 6795,

        VFMADDSUB213PSZ128mbkz = 6796,

        VFMADDSUB213PSZ128mk = 6797,

        VFMADDSUB213PSZ128mkz = 6798,

        VFMADDSUB213PSZ128r = 6799,

        VFMADDSUB213PSZ128rk = 6800,

        VFMADDSUB213PSZ128rkz = 6801,

        VFMADDSUB213PSZ256m = 6802,

        VFMADDSUB213PSZ256mb = 6803,

        VFMADDSUB213PSZ256mbk = 6804,

        VFMADDSUB213PSZ256mbkz = 6805,

        VFMADDSUB213PSZ256mk = 6806,

        VFMADDSUB213PSZ256mkz = 6807,

        VFMADDSUB213PSZ256r = 6808,

        VFMADDSUB213PSZ256rk = 6809,

        VFMADDSUB213PSZ256rkz = 6810,

        VFMADDSUB213PSZm = 6811,

        VFMADDSUB213PSZmb = 6812,

        VFMADDSUB213PSZmbk = 6813,

        VFMADDSUB213PSZmbkz = 6814,

        VFMADDSUB213PSZmk = 6815,

        VFMADDSUB213PSZmkz = 6816,

        VFMADDSUB213PSZr = 6817,

        VFMADDSUB213PSZrb = 6818,

        VFMADDSUB213PSZrbk = 6819,

        VFMADDSUB213PSZrbkz = 6820,

        VFMADDSUB213PSZrk = 6821,

        VFMADDSUB213PSZrkz = 6822,

        VFMADDSUB213PSm = 6823,

        VFMADDSUB213PSr = 6824,

        VFMADDSUB231PDYm = 6825,

        VFMADDSUB231PDYr = 6826,

        VFMADDSUB231PDZ128m = 6827,

        VFMADDSUB231PDZ128mb = 6828,

        VFMADDSUB231PDZ128mbk = 6829,

        VFMADDSUB231PDZ128mbkz = 6830,

        VFMADDSUB231PDZ128mk = 6831,

        VFMADDSUB231PDZ128mkz = 6832,

        VFMADDSUB231PDZ128r = 6833,

        VFMADDSUB231PDZ128rk = 6834,

        VFMADDSUB231PDZ128rkz = 6835,

        VFMADDSUB231PDZ256m = 6836,

        VFMADDSUB231PDZ256mb = 6837,

        VFMADDSUB231PDZ256mbk = 6838,

        VFMADDSUB231PDZ256mbkz = 6839,

        VFMADDSUB231PDZ256mk = 6840,

        VFMADDSUB231PDZ256mkz = 6841,

        VFMADDSUB231PDZ256r = 6842,

        VFMADDSUB231PDZ256rk = 6843,

        VFMADDSUB231PDZ256rkz = 6844,

        VFMADDSUB231PDZm = 6845,

        VFMADDSUB231PDZmb = 6846,

        VFMADDSUB231PDZmbk = 6847,

        VFMADDSUB231PDZmbkz = 6848,

        VFMADDSUB231PDZmk = 6849,

        VFMADDSUB231PDZmkz = 6850,

        VFMADDSUB231PDZr = 6851,

        VFMADDSUB231PDZrb = 6852,

        VFMADDSUB231PDZrbk = 6853,

        VFMADDSUB231PDZrbkz = 6854,

        VFMADDSUB231PDZrk = 6855,

        VFMADDSUB231PDZrkz = 6856,

        VFMADDSUB231PDm = 6857,

        VFMADDSUB231PDr = 6858,

        VFMADDSUB231PHZ128m = 6859,

        VFMADDSUB231PHZ128mb = 6860,

        VFMADDSUB231PHZ128mbk = 6861,

        VFMADDSUB231PHZ128mbkz = 6862,

        VFMADDSUB231PHZ128mk = 6863,

        VFMADDSUB231PHZ128mkz = 6864,

        VFMADDSUB231PHZ128r = 6865,

        VFMADDSUB231PHZ128rk = 6866,

        VFMADDSUB231PHZ128rkz = 6867,

        VFMADDSUB231PHZ256m = 6868,

        VFMADDSUB231PHZ256mb = 6869,

        VFMADDSUB231PHZ256mbk = 6870,

        VFMADDSUB231PHZ256mbkz = 6871,

        VFMADDSUB231PHZ256mk = 6872,

        VFMADDSUB231PHZ256mkz = 6873,

        VFMADDSUB231PHZ256r = 6874,

        VFMADDSUB231PHZ256rk = 6875,

        VFMADDSUB231PHZ256rkz = 6876,

        VFMADDSUB231PHZm = 6877,

        VFMADDSUB231PHZmb = 6878,

        VFMADDSUB231PHZmbk = 6879,

        VFMADDSUB231PHZmbkz = 6880,

        VFMADDSUB231PHZmk = 6881,

        VFMADDSUB231PHZmkz = 6882,

        VFMADDSUB231PHZr = 6883,

        VFMADDSUB231PHZrb = 6884,

        VFMADDSUB231PHZrbk = 6885,

        VFMADDSUB231PHZrbkz = 6886,

        VFMADDSUB231PHZrk = 6887,

        VFMADDSUB231PHZrkz = 6888,

        VFMADDSUB231PSYm = 6889,

        VFMADDSUB231PSYr = 6890,

        VFMADDSUB231PSZ128m = 6891,

        VFMADDSUB231PSZ128mb = 6892,

        VFMADDSUB231PSZ128mbk = 6893,

        VFMADDSUB231PSZ128mbkz = 6894,

        VFMADDSUB231PSZ128mk = 6895,

        VFMADDSUB231PSZ128mkz = 6896,

        VFMADDSUB231PSZ128r = 6897,

        VFMADDSUB231PSZ128rk = 6898,

        VFMADDSUB231PSZ128rkz = 6899,

        VFMADDSUB231PSZ256m = 6900,

        VFMADDSUB231PSZ256mb = 6901,

        VFMADDSUB231PSZ256mbk = 6902,

        VFMADDSUB231PSZ256mbkz = 6903,

        VFMADDSUB231PSZ256mk = 6904,

        VFMADDSUB231PSZ256mkz = 6905,

        VFMADDSUB231PSZ256r = 6906,

        VFMADDSUB231PSZ256rk = 6907,

        VFMADDSUB231PSZ256rkz = 6908,

        VFMADDSUB231PSZm = 6909,

        VFMADDSUB231PSZmb = 6910,

        VFMADDSUB231PSZmbk = 6911,

        VFMADDSUB231PSZmbkz = 6912,

        VFMADDSUB231PSZmk = 6913,

        VFMADDSUB231PSZmkz = 6914,

        VFMADDSUB231PSZr = 6915,

        VFMADDSUB231PSZrb = 6916,

        VFMADDSUB231PSZrbk = 6917,

        VFMADDSUB231PSZrbkz = 6918,

        VFMADDSUB231PSZrk = 6919,

        VFMADDSUB231PSZrkz = 6920,

        VFMADDSUB231PSm = 6921,

        VFMADDSUB231PSr = 6922,

        VFMADDSUBPD4Ymr = 6923,

        VFMADDSUBPD4Yrm = 6924,

        VFMADDSUBPD4Yrr = 6925,

        VFMADDSUBPD4Yrr_REV = 6926,

        VFMADDSUBPD4mr = 6927,

        VFMADDSUBPD4rm = 6928,

        VFMADDSUBPD4rr = 6929,

        VFMADDSUBPD4rr_REV = 6930,

        VFMADDSUBPS4Ymr = 6931,

        VFMADDSUBPS4Yrm = 6932,

        VFMADDSUBPS4Yrr = 6933,

        VFMADDSUBPS4Yrr_REV = 6934,

        VFMADDSUBPS4mr = 6935,

        VFMADDSUBPS4rm = 6936,

        VFMADDSUBPS4rr = 6937,

        VFMADDSUBPS4rr_REV = 6938,

        VFMSUB132PDYm = 6939,

        VFMSUB132PDYr = 6940,

        VFMSUB132PDZ128m = 6941,

        VFMSUB132PDZ128mb = 6942,

        VFMSUB132PDZ128mbk = 6943,

        VFMSUB132PDZ128mbkz = 6944,

        VFMSUB132PDZ128mk = 6945,

        VFMSUB132PDZ128mkz = 6946,

        VFMSUB132PDZ128r = 6947,

        VFMSUB132PDZ128rk = 6948,

        VFMSUB132PDZ128rkz = 6949,

        VFMSUB132PDZ256m = 6950,

        VFMSUB132PDZ256mb = 6951,

        VFMSUB132PDZ256mbk = 6952,

        VFMSUB132PDZ256mbkz = 6953,

        VFMSUB132PDZ256mk = 6954,

        VFMSUB132PDZ256mkz = 6955,

        VFMSUB132PDZ256r = 6956,

        VFMSUB132PDZ256rk = 6957,

        VFMSUB132PDZ256rkz = 6958,

        VFMSUB132PDZm = 6959,

        VFMSUB132PDZmb = 6960,

        VFMSUB132PDZmbk = 6961,

        VFMSUB132PDZmbkz = 6962,

        VFMSUB132PDZmk = 6963,

        VFMSUB132PDZmkz = 6964,

        VFMSUB132PDZr = 6965,

        VFMSUB132PDZrb = 6966,

        VFMSUB132PDZrbk = 6967,

        VFMSUB132PDZrbkz = 6968,

        VFMSUB132PDZrk = 6969,

        VFMSUB132PDZrkz = 6970,

        VFMSUB132PDm = 6971,

        VFMSUB132PDr = 6972,

        VFMSUB132PHZ128m = 6973,

        VFMSUB132PHZ128mb = 6974,

        VFMSUB132PHZ128mbk = 6975,

        VFMSUB132PHZ128mbkz = 6976,

        VFMSUB132PHZ128mk = 6977,

        VFMSUB132PHZ128mkz = 6978,

        VFMSUB132PHZ128r = 6979,

        VFMSUB132PHZ128rk = 6980,

        VFMSUB132PHZ128rkz = 6981,

        VFMSUB132PHZ256m = 6982,

        VFMSUB132PHZ256mb = 6983,

        VFMSUB132PHZ256mbk = 6984,

        VFMSUB132PHZ256mbkz = 6985,

        VFMSUB132PHZ256mk = 6986,

        VFMSUB132PHZ256mkz = 6987,

        VFMSUB132PHZ256r = 6988,

        VFMSUB132PHZ256rk = 6989,

        VFMSUB132PHZ256rkz = 6990,

        VFMSUB132PHZm = 6991,

        VFMSUB132PHZmb = 6992,

        VFMSUB132PHZmbk = 6993,

        VFMSUB132PHZmbkz = 6994,

        VFMSUB132PHZmk = 6995,

        VFMSUB132PHZmkz = 6996,

        VFMSUB132PHZr = 6997,

        VFMSUB132PHZrb = 6998,

        VFMSUB132PHZrbk = 6999,

        VFMSUB132PHZrbkz = 7000,

        VFMSUB132PHZrk = 7001,

        VFMSUB132PHZrkz = 7002,

        VFMSUB132PSYm = 7003,

        VFMSUB132PSYr = 7004,

        VFMSUB132PSZ128m = 7005,

        VFMSUB132PSZ128mb = 7006,

        VFMSUB132PSZ128mbk = 7007,

        VFMSUB132PSZ128mbkz = 7008,

        VFMSUB132PSZ128mk = 7009,

        VFMSUB132PSZ128mkz = 7010,

        VFMSUB132PSZ128r = 7011,

        VFMSUB132PSZ128rk = 7012,

        VFMSUB132PSZ128rkz = 7013,

        VFMSUB132PSZ256m = 7014,

        VFMSUB132PSZ256mb = 7015,

        VFMSUB132PSZ256mbk = 7016,

        VFMSUB132PSZ256mbkz = 7017,

        VFMSUB132PSZ256mk = 7018,

        VFMSUB132PSZ256mkz = 7019,

        VFMSUB132PSZ256r = 7020,

        VFMSUB132PSZ256rk = 7021,

        VFMSUB132PSZ256rkz = 7022,

        VFMSUB132PSZm = 7023,

        VFMSUB132PSZmb = 7024,

        VFMSUB132PSZmbk = 7025,

        VFMSUB132PSZmbkz = 7026,

        VFMSUB132PSZmk = 7027,

        VFMSUB132PSZmkz = 7028,

        VFMSUB132PSZr = 7029,

        VFMSUB132PSZrb = 7030,

        VFMSUB132PSZrbk = 7031,

        VFMSUB132PSZrbkz = 7032,

        VFMSUB132PSZrk = 7033,

        VFMSUB132PSZrkz = 7034,

        VFMSUB132PSm = 7035,

        VFMSUB132PSr = 7036,

        VFMSUB132SDZm = 7037,

        VFMSUB132SDZm_Int = 7038,

        VFMSUB132SDZm_Intk = 7039,

        VFMSUB132SDZm_Intkz = 7040,

        VFMSUB132SDZr = 7041,

        VFMSUB132SDZr_Int = 7042,

        VFMSUB132SDZr_Intk = 7043,

        VFMSUB132SDZr_Intkz = 7044,

        VFMSUB132SDZrb = 7045,

        VFMSUB132SDZrb_Int = 7046,

        VFMSUB132SDZrb_Intk = 7047,

        VFMSUB132SDZrb_Intkz = 7048,

        VFMSUB132SDm = 7049,

        VFMSUB132SDm_Int = 7050,

        VFMSUB132SDr = 7051,

        VFMSUB132SDr_Int = 7052,

        VFMSUB132SHZm = 7053,

        VFMSUB132SHZm_Int = 7054,

        VFMSUB132SHZm_Intk = 7055,

        VFMSUB132SHZm_Intkz = 7056,

        VFMSUB132SHZr = 7057,

        VFMSUB132SHZr_Int = 7058,

        VFMSUB132SHZr_Intk = 7059,

        VFMSUB132SHZr_Intkz = 7060,

        VFMSUB132SHZrb = 7061,

        VFMSUB132SHZrb_Int = 7062,

        VFMSUB132SHZrb_Intk = 7063,

        VFMSUB132SHZrb_Intkz = 7064,

        VFMSUB132SSZm = 7065,

        VFMSUB132SSZm_Int = 7066,

        VFMSUB132SSZm_Intk = 7067,

        VFMSUB132SSZm_Intkz = 7068,

        VFMSUB132SSZr = 7069,

        VFMSUB132SSZr_Int = 7070,

        VFMSUB132SSZr_Intk = 7071,

        VFMSUB132SSZr_Intkz = 7072,

        VFMSUB132SSZrb = 7073,

        VFMSUB132SSZrb_Int = 7074,

        VFMSUB132SSZrb_Intk = 7075,

        VFMSUB132SSZrb_Intkz = 7076,

        VFMSUB132SSm = 7077,

        VFMSUB132SSm_Int = 7078,

        VFMSUB132SSr = 7079,

        VFMSUB132SSr_Int = 7080,

        VFMSUB213PDYm = 7081,

        VFMSUB213PDYr = 7082,

        VFMSUB213PDZ128m = 7083,

        VFMSUB213PDZ128mb = 7084,

        VFMSUB213PDZ128mbk = 7085,

        VFMSUB213PDZ128mbkz = 7086,

        VFMSUB213PDZ128mk = 7087,

        VFMSUB213PDZ128mkz = 7088,

        VFMSUB213PDZ128r = 7089,

        VFMSUB213PDZ128rk = 7090,

        VFMSUB213PDZ128rkz = 7091,

        VFMSUB213PDZ256m = 7092,

        VFMSUB213PDZ256mb = 7093,

        VFMSUB213PDZ256mbk = 7094,

        VFMSUB213PDZ256mbkz = 7095,

        VFMSUB213PDZ256mk = 7096,

        VFMSUB213PDZ256mkz = 7097,

        VFMSUB213PDZ256r = 7098,

        VFMSUB213PDZ256rk = 7099,

        VFMSUB213PDZ256rkz = 7100,

        VFMSUB213PDZm = 7101,

        VFMSUB213PDZmb = 7102,

        VFMSUB213PDZmbk = 7103,

        VFMSUB213PDZmbkz = 7104,

        VFMSUB213PDZmk = 7105,

        VFMSUB213PDZmkz = 7106,

        VFMSUB213PDZr = 7107,

        VFMSUB213PDZrb = 7108,

        VFMSUB213PDZrbk = 7109,

        VFMSUB213PDZrbkz = 7110,

        VFMSUB213PDZrk = 7111,

        VFMSUB213PDZrkz = 7112,

        VFMSUB213PDm = 7113,

        VFMSUB213PDr = 7114,

        VFMSUB213PHZ128m = 7115,

        VFMSUB213PHZ128mb = 7116,

        VFMSUB213PHZ128mbk = 7117,

        VFMSUB213PHZ128mbkz = 7118,

        VFMSUB213PHZ128mk = 7119,

        VFMSUB213PHZ128mkz = 7120,

        VFMSUB213PHZ128r = 7121,

        VFMSUB213PHZ128rk = 7122,

        VFMSUB213PHZ128rkz = 7123,

        VFMSUB213PHZ256m = 7124,

        VFMSUB213PHZ256mb = 7125,

        VFMSUB213PHZ256mbk = 7126,

        VFMSUB213PHZ256mbkz = 7127,

        VFMSUB213PHZ256mk = 7128,

        VFMSUB213PHZ256mkz = 7129,

        VFMSUB213PHZ256r = 7130,

        VFMSUB213PHZ256rk = 7131,

        VFMSUB213PHZ256rkz = 7132,

        VFMSUB213PHZm = 7133,

        VFMSUB213PHZmb = 7134,

        VFMSUB213PHZmbk = 7135,

        VFMSUB213PHZmbkz = 7136,

        VFMSUB213PHZmk = 7137,

        VFMSUB213PHZmkz = 7138,

        VFMSUB213PHZr = 7139,

        VFMSUB213PHZrb = 7140,

        VFMSUB213PHZrbk = 7141,

        VFMSUB213PHZrbkz = 7142,

        VFMSUB213PHZrk = 7143,

        VFMSUB213PHZrkz = 7144,

        VFMSUB213PSYm = 7145,

        VFMSUB213PSYr = 7146,

        VFMSUB213PSZ128m = 7147,

        VFMSUB213PSZ128mb = 7148,

        VFMSUB213PSZ128mbk = 7149,

        VFMSUB213PSZ128mbkz = 7150,

        VFMSUB213PSZ128mk = 7151,

        VFMSUB213PSZ128mkz = 7152,

        VFMSUB213PSZ128r = 7153,

        VFMSUB213PSZ128rk = 7154,

        VFMSUB213PSZ128rkz = 7155,

        VFMSUB213PSZ256m = 7156,

        VFMSUB213PSZ256mb = 7157,

        VFMSUB213PSZ256mbk = 7158,

        VFMSUB213PSZ256mbkz = 7159,

        VFMSUB213PSZ256mk = 7160,

        VFMSUB213PSZ256mkz = 7161,

        VFMSUB213PSZ256r = 7162,

        VFMSUB213PSZ256rk = 7163,

        VFMSUB213PSZ256rkz = 7164,

        VFMSUB213PSZm = 7165,

        VFMSUB213PSZmb = 7166,

        VFMSUB213PSZmbk = 7167,

        VFMSUB213PSZmbkz = 7168,

        VFMSUB213PSZmk = 7169,

        VFMSUB213PSZmkz = 7170,

        VFMSUB213PSZr = 7171,

        VFMSUB213PSZrb = 7172,

        VFMSUB213PSZrbk = 7173,

        VFMSUB213PSZrbkz = 7174,

        VFMSUB213PSZrk = 7175,

        VFMSUB213PSZrkz = 7176,

        VFMSUB213PSm = 7177,

        VFMSUB213PSr = 7178,

        VFMSUB213SDZm = 7179,

        VFMSUB213SDZm_Int = 7180,

        VFMSUB213SDZm_Intk = 7181,

        VFMSUB213SDZm_Intkz = 7182,

        VFMSUB213SDZr = 7183,

        VFMSUB213SDZr_Int = 7184,

        VFMSUB213SDZr_Intk = 7185,

        VFMSUB213SDZr_Intkz = 7186,

        VFMSUB213SDZrb = 7187,

        VFMSUB213SDZrb_Int = 7188,

        VFMSUB213SDZrb_Intk = 7189,

        VFMSUB213SDZrb_Intkz = 7190,

        VFMSUB213SDm = 7191,

        VFMSUB213SDm_Int = 7192,

        VFMSUB213SDr = 7193,

        VFMSUB213SDr_Int = 7194,

        VFMSUB213SHZm = 7195,

        VFMSUB213SHZm_Int = 7196,

        VFMSUB213SHZm_Intk = 7197,

        VFMSUB213SHZm_Intkz = 7198,

        VFMSUB213SHZr = 7199,

        VFMSUB213SHZr_Int = 7200,

        VFMSUB213SHZr_Intk = 7201,

        VFMSUB213SHZr_Intkz = 7202,

        VFMSUB213SHZrb = 7203,

        VFMSUB213SHZrb_Int = 7204,

        VFMSUB213SHZrb_Intk = 7205,

        VFMSUB213SHZrb_Intkz = 7206,

        VFMSUB213SSZm = 7207,

        VFMSUB213SSZm_Int = 7208,

        VFMSUB213SSZm_Intk = 7209,

        VFMSUB213SSZm_Intkz = 7210,

        VFMSUB213SSZr = 7211,

        VFMSUB213SSZr_Int = 7212,

        VFMSUB213SSZr_Intk = 7213,

        VFMSUB213SSZr_Intkz = 7214,

        VFMSUB213SSZrb = 7215,

        VFMSUB213SSZrb_Int = 7216,

        VFMSUB213SSZrb_Intk = 7217,

        VFMSUB213SSZrb_Intkz = 7218,

        VFMSUB213SSm = 7219,

        VFMSUB213SSm_Int = 7220,

        VFMSUB213SSr = 7221,

        VFMSUB213SSr_Int = 7222,

        VFMSUB231PDYm = 7223,

        VFMSUB231PDYr = 7224,

        VFMSUB231PDZ128m = 7225,

        VFMSUB231PDZ128mb = 7226,

        VFMSUB231PDZ128mbk = 7227,

        VFMSUB231PDZ128mbkz = 7228,

        VFMSUB231PDZ128mk = 7229,

        VFMSUB231PDZ128mkz = 7230,

        VFMSUB231PDZ128r = 7231,

        VFMSUB231PDZ128rk = 7232,

        VFMSUB231PDZ128rkz = 7233,

        VFMSUB231PDZ256m = 7234,

        VFMSUB231PDZ256mb = 7235,

        VFMSUB231PDZ256mbk = 7236,

        VFMSUB231PDZ256mbkz = 7237,

        VFMSUB231PDZ256mk = 7238,

        VFMSUB231PDZ256mkz = 7239,

        VFMSUB231PDZ256r = 7240,

        VFMSUB231PDZ256rk = 7241,

        VFMSUB231PDZ256rkz = 7242,

        VFMSUB231PDZm = 7243,

        VFMSUB231PDZmb = 7244,

        VFMSUB231PDZmbk = 7245,

        VFMSUB231PDZmbkz = 7246,

        VFMSUB231PDZmk = 7247,

        VFMSUB231PDZmkz = 7248,

        VFMSUB231PDZr = 7249,

        VFMSUB231PDZrb = 7250,

        VFMSUB231PDZrbk = 7251,

        VFMSUB231PDZrbkz = 7252,

        VFMSUB231PDZrk = 7253,

        VFMSUB231PDZrkz = 7254,

        VFMSUB231PDm = 7255,

        VFMSUB231PDr = 7256,

        VFMSUB231PHZ128m = 7257,

        VFMSUB231PHZ128mb = 7258,

        VFMSUB231PHZ128mbk = 7259,

        VFMSUB231PHZ128mbkz = 7260,

        VFMSUB231PHZ128mk = 7261,

        VFMSUB231PHZ128mkz = 7262,

        VFMSUB231PHZ128r = 7263,

        VFMSUB231PHZ128rk = 7264,

        VFMSUB231PHZ128rkz = 7265,

        VFMSUB231PHZ256m = 7266,

        VFMSUB231PHZ256mb = 7267,

        VFMSUB231PHZ256mbk = 7268,

        VFMSUB231PHZ256mbkz = 7269,

        VFMSUB231PHZ256mk = 7270,

        VFMSUB231PHZ256mkz = 7271,

        VFMSUB231PHZ256r = 7272,

        VFMSUB231PHZ256rk = 7273,

        VFMSUB231PHZ256rkz = 7274,

        VFMSUB231PHZm = 7275,

        VFMSUB231PHZmb = 7276,

        VFMSUB231PHZmbk = 7277,

        VFMSUB231PHZmbkz = 7278,

        VFMSUB231PHZmk = 7279,

        VFMSUB231PHZmkz = 7280,

        VFMSUB231PHZr = 7281,

        VFMSUB231PHZrb = 7282,

        VFMSUB231PHZrbk = 7283,

        VFMSUB231PHZrbkz = 7284,

        VFMSUB231PHZrk = 7285,

        VFMSUB231PHZrkz = 7286,

        VFMSUB231PSYm = 7287,

        VFMSUB231PSYr = 7288,

        VFMSUB231PSZ128m = 7289,

        VFMSUB231PSZ128mb = 7290,

        VFMSUB231PSZ128mbk = 7291,

        VFMSUB231PSZ128mbkz = 7292,

        VFMSUB231PSZ128mk = 7293,

        VFMSUB231PSZ128mkz = 7294,

        VFMSUB231PSZ128r = 7295,

        VFMSUB231PSZ128rk = 7296,

        VFMSUB231PSZ128rkz = 7297,

        VFMSUB231PSZ256m = 7298,

        VFMSUB231PSZ256mb = 7299,

        VFMSUB231PSZ256mbk = 7300,

        VFMSUB231PSZ256mbkz = 7301,

        VFMSUB231PSZ256mk = 7302,

        VFMSUB231PSZ256mkz = 7303,

        VFMSUB231PSZ256r = 7304,

        VFMSUB231PSZ256rk = 7305,

        VFMSUB231PSZ256rkz = 7306,

        VFMSUB231PSZm = 7307,

        VFMSUB231PSZmb = 7308,

        VFMSUB231PSZmbk = 7309,

        VFMSUB231PSZmbkz = 7310,

        VFMSUB231PSZmk = 7311,

        VFMSUB231PSZmkz = 7312,

        VFMSUB231PSZr = 7313,

        VFMSUB231PSZrb = 7314,

        VFMSUB231PSZrbk = 7315,

        VFMSUB231PSZrbkz = 7316,

        VFMSUB231PSZrk = 7317,

        VFMSUB231PSZrkz = 7318,

        VFMSUB231PSm = 7319,

        VFMSUB231PSr = 7320,

        VFMSUB231SDZm = 7321,

        VFMSUB231SDZm_Int = 7322,

        VFMSUB231SDZm_Intk = 7323,

        VFMSUB231SDZm_Intkz = 7324,

        VFMSUB231SDZr = 7325,

        VFMSUB231SDZr_Int = 7326,

        VFMSUB231SDZr_Intk = 7327,

        VFMSUB231SDZr_Intkz = 7328,

        VFMSUB231SDZrb = 7329,

        VFMSUB231SDZrb_Int = 7330,

        VFMSUB231SDZrb_Intk = 7331,

        VFMSUB231SDZrb_Intkz = 7332,

        VFMSUB231SDm = 7333,

        VFMSUB231SDm_Int = 7334,

        VFMSUB231SDr = 7335,

        VFMSUB231SDr_Int = 7336,

        VFMSUB231SHZm = 7337,

        VFMSUB231SHZm_Int = 7338,

        VFMSUB231SHZm_Intk = 7339,

        VFMSUB231SHZm_Intkz = 7340,

        VFMSUB231SHZr = 7341,

        VFMSUB231SHZr_Int = 7342,

        VFMSUB231SHZr_Intk = 7343,

        VFMSUB231SHZr_Intkz = 7344,

        VFMSUB231SHZrb = 7345,

        VFMSUB231SHZrb_Int = 7346,

        VFMSUB231SHZrb_Intk = 7347,

        VFMSUB231SHZrb_Intkz = 7348,

        VFMSUB231SSZm = 7349,

        VFMSUB231SSZm_Int = 7350,

        VFMSUB231SSZm_Intk = 7351,

        VFMSUB231SSZm_Intkz = 7352,

        VFMSUB231SSZr = 7353,

        VFMSUB231SSZr_Int = 7354,

        VFMSUB231SSZr_Intk = 7355,

        VFMSUB231SSZr_Intkz = 7356,

        VFMSUB231SSZrb = 7357,

        VFMSUB231SSZrb_Int = 7358,

        VFMSUB231SSZrb_Intk = 7359,

        VFMSUB231SSZrb_Intkz = 7360,

        VFMSUB231SSm = 7361,

        VFMSUB231SSm_Int = 7362,

        VFMSUB231SSr = 7363,

        VFMSUB231SSr_Int = 7364,

        VFMSUBADD132PDYm = 7365,

        VFMSUBADD132PDYr = 7366,

        VFMSUBADD132PDZ128m = 7367,

        VFMSUBADD132PDZ128mb = 7368,

        VFMSUBADD132PDZ128mbk = 7369,

        VFMSUBADD132PDZ128mbkz = 7370,

        VFMSUBADD132PDZ128mk = 7371,

        VFMSUBADD132PDZ128mkz = 7372,

        VFMSUBADD132PDZ128r = 7373,

        VFMSUBADD132PDZ128rk = 7374,

        VFMSUBADD132PDZ128rkz = 7375,

        VFMSUBADD132PDZ256m = 7376,

        VFMSUBADD132PDZ256mb = 7377,

        VFMSUBADD132PDZ256mbk = 7378,

        VFMSUBADD132PDZ256mbkz = 7379,

        VFMSUBADD132PDZ256mk = 7380,

        VFMSUBADD132PDZ256mkz = 7381,

        VFMSUBADD132PDZ256r = 7382,

        VFMSUBADD132PDZ256rk = 7383,

        VFMSUBADD132PDZ256rkz = 7384,

        VFMSUBADD132PDZm = 7385,

        VFMSUBADD132PDZmb = 7386,

        VFMSUBADD132PDZmbk = 7387,

        VFMSUBADD132PDZmbkz = 7388,

        VFMSUBADD132PDZmk = 7389,

        VFMSUBADD132PDZmkz = 7390,

        VFMSUBADD132PDZr = 7391,

        VFMSUBADD132PDZrb = 7392,

        VFMSUBADD132PDZrbk = 7393,

        VFMSUBADD132PDZrbkz = 7394,

        VFMSUBADD132PDZrk = 7395,

        VFMSUBADD132PDZrkz = 7396,

        VFMSUBADD132PDm = 7397,

        VFMSUBADD132PDr = 7398,

        VFMSUBADD132PHZ128m = 7399,

        VFMSUBADD132PHZ128mb = 7400,

        VFMSUBADD132PHZ128mbk = 7401,

        VFMSUBADD132PHZ128mbkz = 7402,

        VFMSUBADD132PHZ128mk = 7403,

        VFMSUBADD132PHZ128mkz = 7404,

        VFMSUBADD132PHZ128r = 7405,

        VFMSUBADD132PHZ128rk = 7406,

        VFMSUBADD132PHZ128rkz = 7407,

        VFMSUBADD132PHZ256m = 7408,

        VFMSUBADD132PHZ256mb = 7409,

        VFMSUBADD132PHZ256mbk = 7410,

        VFMSUBADD132PHZ256mbkz = 7411,

        VFMSUBADD132PHZ256mk = 7412,

        VFMSUBADD132PHZ256mkz = 7413,

        VFMSUBADD132PHZ256r = 7414,

        VFMSUBADD132PHZ256rk = 7415,

        VFMSUBADD132PHZ256rkz = 7416,

        VFMSUBADD132PHZm = 7417,

        VFMSUBADD132PHZmb = 7418,

        VFMSUBADD132PHZmbk = 7419,

        VFMSUBADD132PHZmbkz = 7420,

        VFMSUBADD132PHZmk = 7421,

        VFMSUBADD132PHZmkz = 7422,

        VFMSUBADD132PHZr = 7423,

        VFMSUBADD132PHZrb = 7424,

        VFMSUBADD132PHZrbk = 7425,

        VFMSUBADD132PHZrbkz = 7426,

        VFMSUBADD132PHZrk = 7427,

        VFMSUBADD132PHZrkz = 7428,

        VFMSUBADD132PSYm = 7429,

        VFMSUBADD132PSYr = 7430,

        VFMSUBADD132PSZ128m = 7431,

        VFMSUBADD132PSZ128mb = 7432,

        VFMSUBADD132PSZ128mbk = 7433,

        VFMSUBADD132PSZ128mbkz = 7434,

        VFMSUBADD132PSZ128mk = 7435,

        VFMSUBADD132PSZ128mkz = 7436,

        VFMSUBADD132PSZ128r = 7437,

        VFMSUBADD132PSZ128rk = 7438,

        VFMSUBADD132PSZ128rkz = 7439,

        VFMSUBADD132PSZ256m = 7440,

        VFMSUBADD132PSZ256mb = 7441,

        VFMSUBADD132PSZ256mbk = 7442,

        VFMSUBADD132PSZ256mbkz = 7443,

        VFMSUBADD132PSZ256mk = 7444,

        VFMSUBADD132PSZ256mkz = 7445,

        VFMSUBADD132PSZ256r = 7446,

        VFMSUBADD132PSZ256rk = 7447,

        VFMSUBADD132PSZ256rkz = 7448,

        VFMSUBADD132PSZm = 7449,

        VFMSUBADD132PSZmb = 7450,

        VFMSUBADD132PSZmbk = 7451,

        VFMSUBADD132PSZmbkz = 7452,

        VFMSUBADD132PSZmk = 7453,

        VFMSUBADD132PSZmkz = 7454,

        VFMSUBADD132PSZr = 7455,

        VFMSUBADD132PSZrb = 7456,

        VFMSUBADD132PSZrbk = 7457,

        VFMSUBADD132PSZrbkz = 7458,

        VFMSUBADD132PSZrk = 7459,

        VFMSUBADD132PSZrkz = 7460,

        VFMSUBADD132PSm = 7461,

        VFMSUBADD132PSr = 7462,

        VFMSUBADD213PDYm = 7463,

        VFMSUBADD213PDYr = 7464,

        VFMSUBADD213PDZ128m = 7465,

        VFMSUBADD213PDZ128mb = 7466,

        VFMSUBADD213PDZ128mbk = 7467,

        VFMSUBADD213PDZ128mbkz = 7468,

        VFMSUBADD213PDZ128mk = 7469,

        VFMSUBADD213PDZ128mkz = 7470,

        VFMSUBADD213PDZ128r = 7471,

        VFMSUBADD213PDZ128rk = 7472,

        VFMSUBADD213PDZ128rkz = 7473,

        VFMSUBADD213PDZ256m = 7474,

        VFMSUBADD213PDZ256mb = 7475,

        VFMSUBADD213PDZ256mbk = 7476,

        VFMSUBADD213PDZ256mbkz = 7477,

        VFMSUBADD213PDZ256mk = 7478,

        VFMSUBADD213PDZ256mkz = 7479,

        VFMSUBADD213PDZ256r = 7480,

        VFMSUBADD213PDZ256rk = 7481,

        VFMSUBADD213PDZ256rkz = 7482,

        VFMSUBADD213PDZm = 7483,

        VFMSUBADD213PDZmb = 7484,

        VFMSUBADD213PDZmbk = 7485,

        VFMSUBADD213PDZmbkz = 7486,

        VFMSUBADD213PDZmk = 7487,

        VFMSUBADD213PDZmkz = 7488,

        VFMSUBADD213PDZr = 7489,

        VFMSUBADD213PDZrb = 7490,

        VFMSUBADD213PDZrbk = 7491,

        VFMSUBADD213PDZrbkz = 7492,

        VFMSUBADD213PDZrk = 7493,

        VFMSUBADD213PDZrkz = 7494,

        VFMSUBADD213PDm = 7495,

        VFMSUBADD213PDr = 7496,

        VFMSUBADD213PHZ128m = 7497,

        VFMSUBADD213PHZ128mb = 7498,

        VFMSUBADD213PHZ128mbk = 7499,

        VFMSUBADD213PHZ128mbkz = 7500,

        VFMSUBADD213PHZ128mk = 7501,

        VFMSUBADD213PHZ128mkz = 7502,

        VFMSUBADD213PHZ128r = 7503,

        VFMSUBADD213PHZ128rk = 7504,

        VFMSUBADD213PHZ128rkz = 7505,

        VFMSUBADD213PHZ256m = 7506,

        VFMSUBADD213PHZ256mb = 7507,

        VFMSUBADD213PHZ256mbk = 7508,

        VFMSUBADD213PHZ256mbkz = 7509,

        VFMSUBADD213PHZ256mk = 7510,

        VFMSUBADD213PHZ256mkz = 7511,

        VFMSUBADD213PHZ256r = 7512,

        VFMSUBADD213PHZ256rk = 7513,

        VFMSUBADD213PHZ256rkz = 7514,

        VFMSUBADD213PHZm = 7515,

        VFMSUBADD213PHZmb = 7516,

        VFMSUBADD213PHZmbk = 7517,

        VFMSUBADD213PHZmbkz = 7518,

        VFMSUBADD213PHZmk = 7519,

        VFMSUBADD213PHZmkz = 7520,

        VFMSUBADD213PHZr = 7521,

        VFMSUBADD213PHZrb = 7522,

        VFMSUBADD213PHZrbk = 7523,

        VFMSUBADD213PHZrbkz = 7524,

        VFMSUBADD213PHZrk = 7525,

        VFMSUBADD213PHZrkz = 7526,

        VFMSUBADD213PSYm = 7527,

        VFMSUBADD213PSYr = 7528,

        VFMSUBADD213PSZ128m = 7529,

        VFMSUBADD213PSZ128mb = 7530,

        VFMSUBADD213PSZ128mbk = 7531,

        VFMSUBADD213PSZ128mbkz = 7532,

        VFMSUBADD213PSZ128mk = 7533,

        VFMSUBADD213PSZ128mkz = 7534,

        VFMSUBADD213PSZ128r = 7535,

        VFMSUBADD213PSZ128rk = 7536,

        VFMSUBADD213PSZ128rkz = 7537,

        VFMSUBADD213PSZ256m = 7538,

        VFMSUBADD213PSZ256mb = 7539,

        VFMSUBADD213PSZ256mbk = 7540,

        VFMSUBADD213PSZ256mbkz = 7541,

        VFMSUBADD213PSZ256mk = 7542,

        VFMSUBADD213PSZ256mkz = 7543,

        VFMSUBADD213PSZ256r = 7544,

        VFMSUBADD213PSZ256rk = 7545,

        VFMSUBADD213PSZ256rkz = 7546,

        VFMSUBADD213PSZm = 7547,

        VFMSUBADD213PSZmb = 7548,

        VFMSUBADD213PSZmbk = 7549,

        VFMSUBADD213PSZmbkz = 7550,

        VFMSUBADD213PSZmk = 7551,

        VFMSUBADD213PSZmkz = 7552,

        VFMSUBADD213PSZr = 7553,

        VFMSUBADD213PSZrb = 7554,

        VFMSUBADD213PSZrbk = 7555,

        VFMSUBADD213PSZrbkz = 7556,

        VFMSUBADD213PSZrk = 7557,

        VFMSUBADD213PSZrkz = 7558,

        VFMSUBADD213PSm = 7559,

        VFMSUBADD213PSr = 7560,

        VFMSUBADD231PDYm = 7561,

        VFMSUBADD231PDYr = 7562,

        VFMSUBADD231PDZ128m = 7563,

        VFMSUBADD231PDZ128mb = 7564,

        VFMSUBADD231PDZ128mbk = 7565,

        VFMSUBADD231PDZ128mbkz = 7566,

        VFMSUBADD231PDZ128mk = 7567,

        VFMSUBADD231PDZ128mkz = 7568,

        VFMSUBADD231PDZ128r = 7569,

        VFMSUBADD231PDZ128rk = 7570,

        VFMSUBADD231PDZ128rkz = 7571,

        VFMSUBADD231PDZ256m = 7572,

        VFMSUBADD231PDZ256mb = 7573,

        VFMSUBADD231PDZ256mbk = 7574,

        VFMSUBADD231PDZ256mbkz = 7575,

        VFMSUBADD231PDZ256mk = 7576,

        VFMSUBADD231PDZ256mkz = 7577,

        VFMSUBADD231PDZ256r = 7578,

        VFMSUBADD231PDZ256rk = 7579,

        VFMSUBADD231PDZ256rkz = 7580,

        VFMSUBADD231PDZm = 7581,

        VFMSUBADD231PDZmb = 7582,

        VFMSUBADD231PDZmbk = 7583,

        VFMSUBADD231PDZmbkz = 7584,

        VFMSUBADD231PDZmk = 7585,

        VFMSUBADD231PDZmkz = 7586,

        VFMSUBADD231PDZr = 7587,

        VFMSUBADD231PDZrb = 7588,

        VFMSUBADD231PDZrbk = 7589,

        VFMSUBADD231PDZrbkz = 7590,

        VFMSUBADD231PDZrk = 7591,

        VFMSUBADD231PDZrkz = 7592,

        VFMSUBADD231PDm = 7593,

        VFMSUBADD231PDr = 7594,

        VFMSUBADD231PHZ128m = 7595,

        VFMSUBADD231PHZ128mb = 7596,

        VFMSUBADD231PHZ128mbk = 7597,

        VFMSUBADD231PHZ128mbkz = 7598,

        VFMSUBADD231PHZ128mk = 7599,

        VFMSUBADD231PHZ128mkz = 7600,

        VFMSUBADD231PHZ128r = 7601,

        VFMSUBADD231PHZ128rk = 7602,

        VFMSUBADD231PHZ128rkz = 7603,

        VFMSUBADD231PHZ256m = 7604,

        VFMSUBADD231PHZ256mb = 7605,

        VFMSUBADD231PHZ256mbk = 7606,

        VFMSUBADD231PHZ256mbkz = 7607,

        VFMSUBADD231PHZ256mk = 7608,

        VFMSUBADD231PHZ256mkz = 7609,

        VFMSUBADD231PHZ256r = 7610,

        VFMSUBADD231PHZ256rk = 7611,

        VFMSUBADD231PHZ256rkz = 7612,

        VFMSUBADD231PHZm = 7613,

        VFMSUBADD231PHZmb = 7614,

        VFMSUBADD231PHZmbk = 7615,

        VFMSUBADD231PHZmbkz = 7616,

        VFMSUBADD231PHZmk = 7617,

        VFMSUBADD231PHZmkz = 7618,

        VFMSUBADD231PHZr = 7619,

        VFMSUBADD231PHZrb = 7620,

        VFMSUBADD231PHZrbk = 7621,

        VFMSUBADD231PHZrbkz = 7622,

        VFMSUBADD231PHZrk = 7623,

        VFMSUBADD231PHZrkz = 7624,

        VFMSUBADD231PSYm = 7625,

        VFMSUBADD231PSYr = 7626,

        VFMSUBADD231PSZ128m = 7627,

        VFMSUBADD231PSZ128mb = 7628,

        VFMSUBADD231PSZ128mbk = 7629,

        VFMSUBADD231PSZ128mbkz = 7630,

        VFMSUBADD231PSZ128mk = 7631,

        VFMSUBADD231PSZ128mkz = 7632,

        VFMSUBADD231PSZ128r = 7633,

        VFMSUBADD231PSZ128rk = 7634,

        VFMSUBADD231PSZ128rkz = 7635,

        VFMSUBADD231PSZ256m = 7636,

        VFMSUBADD231PSZ256mb = 7637,

        VFMSUBADD231PSZ256mbk = 7638,

        VFMSUBADD231PSZ256mbkz = 7639,

        VFMSUBADD231PSZ256mk = 7640,

        VFMSUBADD231PSZ256mkz = 7641,

        VFMSUBADD231PSZ256r = 7642,

        VFMSUBADD231PSZ256rk = 7643,

        VFMSUBADD231PSZ256rkz = 7644,

        VFMSUBADD231PSZm = 7645,

        VFMSUBADD231PSZmb = 7646,

        VFMSUBADD231PSZmbk = 7647,

        VFMSUBADD231PSZmbkz = 7648,

        VFMSUBADD231PSZmk = 7649,

        VFMSUBADD231PSZmkz = 7650,

        VFMSUBADD231PSZr = 7651,

        VFMSUBADD231PSZrb = 7652,

        VFMSUBADD231PSZrbk = 7653,

        VFMSUBADD231PSZrbkz = 7654,

        VFMSUBADD231PSZrk = 7655,

        VFMSUBADD231PSZrkz = 7656,

        VFMSUBADD231PSm = 7657,

        VFMSUBADD231PSr = 7658,

        VFMSUBADDPD4Ymr = 7659,

        VFMSUBADDPD4Yrm = 7660,

        VFMSUBADDPD4Yrr = 7661,

        VFMSUBADDPD4Yrr_REV = 7662,

        VFMSUBADDPD4mr = 7663,

        VFMSUBADDPD4rm = 7664,

        VFMSUBADDPD4rr = 7665,

        VFMSUBADDPD4rr_REV = 7666,

        VFMSUBADDPS4Ymr = 7667,

        VFMSUBADDPS4Yrm = 7668,

        VFMSUBADDPS4Yrr = 7669,

        VFMSUBADDPS4Yrr_REV = 7670,

        VFMSUBADDPS4mr = 7671,

        VFMSUBADDPS4rm = 7672,

        VFMSUBADDPS4rr = 7673,

        VFMSUBADDPS4rr_REV = 7674,

        VFMSUBPD4Ymr = 7675,

        VFMSUBPD4Yrm = 7676,

        VFMSUBPD4Yrr = 7677,

        VFMSUBPD4Yrr_REV = 7678,

        VFMSUBPD4mr = 7679,

        VFMSUBPD4rm = 7680,

        VFMSUBPD4rr = 7681,

        VFMSUBPD4rr_REV = 7682,

        VFMSUBPS4Ymr = 7683,

        VFMSUBPS4Yrm = 7684,

        VFMSUBPS4Yrr = 7685,

        VFMSUBPS4Yrr_REV = 7686,

        VFMSUBPS4mr = 7687,

        VFMSUBPS4rm = 7688,

        VFMSUBPS4rr = 7689,

        VFMSUBPS4rr_REV = 7690,

        VFMSUBSD4mr = 7691,

        VFMSUBSD4mr_Int = 7692,

        VFMSUBSD4rm = 7693,

        VFMSUBSD4rm_Int = 7694,

        VFMSUBSD4rr = 7695,

        VFMSUBSD4rr_Int = 7696,

        VFMSUBSD4rr_Int_REV = 7697,

        VFMSUBSD4rr_REV = 7698,

        VFMSUBSS4mr = 7699,

        VFMSUBSS4mr_Int = 7700,

        VFMSUBSS4rm = 7701,

        VFMSUBSS4rm_Int = 7702,

        VFMSUBSS4rr = 7703,

        VFMSUBSS4rr_Int = 7704,

        VFMSUBSS4rr_Int_REV = 7705,

        VFMSUBSS4rr_REV = 7706,

        VFMULCPHZ128rm = 7707,

        VFMULCPHZ128rmb = 7708,

        VFMULCPHZ128rmbk = 7709,

        VFMULCPHZ128rmbkz = 7710,

        VFMULCPHZ128rmk = 7711,

        VFMULCPHZ128rmkz = 7712,

        VFMULCPHZ128rr = 7713,

        VFMULCPHZ128rrk = 7714,

        VFMULCPHZ128rrkz = 7715,

        VFMULCPHZ256rm = 7716,

        VFMULCPHZ256rmb = 7717,

        VFMULCPHZ256rmbk = 7718,

        VFMULCPHZ256rmbkz = 7719,

        VFMULCPHZ256rmk = 7720,

        VFMULCPHZ256rmkz = 7721,

        VFMULCPHZ256rr = 7722,

        VFMULCPHZ256rrk = 7723,

        VFMULCPHZ256rrkz = 7724,

        VFMULCPHZrm = 7725,

        VFMULCPHZrmb = 7726,

        VFMULCPHZrmbk = 7727,

        VFMULCPHZrmbkz = 7728,

        VFMULCPHZrmk = 7729,

        VFMULCPHZrmkz = 7730,

        VFMULCPHZrr = 7731,

        VFMULCPHZrrb = 7732,

        VFMULCPHZrrbk = 7733,

        VFMULCPHZrrbkz = 7734,

        VFMULCPHZrrk = 7735,

        VFMULCPHZrrkz = 7736,

        VFMULCSHZrm = 7737,

        VFMULCSHZrmk = 7738,

        VFMULCSHZrmkz = 7739,

        VFMULCSHZrr = 7740,

        VFMULCSHZrrb = 7741,

        VFMULCSHZrrbk = 7742,

        VFMULCSHZrrbkz = 7743,

        VFMULCSHZrrk = 7744,

        VFMULCSHZrrkz = 7745,

        VFNMADD132PDYm = 7746,

        VFNMADD132PDYr = 7747,

        VFNMADD132PDZ128m = 7748,

        VFNMADD132PDZ128mb = 7749,

        VFNMADD132PDZ128mbk = 7750,

        VFNMADD132PDZ128mbkz = 7751,

        VFNMADD132PDZ128mk = 7752,

        VFNMADD132PDZ128mkz = 7753,

        VFNMADD132PDZ128r = 7754,

        VFNMADD132PDZ128rk = 7755,

        VFNMADD132PDZ128rkz = 7756,

        VFNMADD132PDZ256m = 7757,

        VFNMADD132PDZ256mb = 7758,

        VFNMADD132PDZ256mbk = 7759,

        VFNMADD132PDZ256mbkz = 7760,

        VFNMADD132PDZ256mk = 7761,

        VFNMADD132PDZ256mkz = 7762,

        VFNMADD132PDZ256r = 7763,

        VFNMADD132PDZ256rk = 7764,

        VFNMADD132PDZ256rkz = 7765,

        VFNMADD132PDZm = 7766,

        VFNMADD132PDZmb = 7767,

        VFNMADD132PDZmbk = 7768,

        VFNMADD132PDZmbkz = 7769,

        VFNMADD132PDZmk = 7770,

        VFNMADD132PDZmkz = 7771,

        VFNMADD132PDZr = 7772,

        VFNMADD132PDZrb = 7773,

        VFNMADD132PDZrbk = 7774,

        VFNMADD132PDZrbkz = 7775,

        VFNMADD132PDZrk = 7776,

        VFNMADD132PDZrkz = 7777,

        VFNMADD132PDm = 7778,

        VFNMADD132PDr = 7779,

        VFNMADD132PHZ128m = 7780,

        VFNMADD132PHZ128mb = 7781,

        VFNMADD132PHZ128mbk = 7782,

        VFNMADD132PHZ128mbkz = 7783,

        VFNMADD132PHZ128mk = 7784,

        VFNMADD132PHZ128mkz = 7785,

        VFNMADD132PHZ128r = 7786,

        VFNMADD132PHZ128rk = 7787,

        VFNMADD132PHZ128rkz = 7788,

        VFNMADD132PHZ256m = 7789,

        VFNMADD132PHZ256mb = 7790,

        VFNMADD132PHZ256mbk = 7791,

        VFNMADD132PHZ256mbkz = 7792,

        VFNMADD132PHZ256mk = 7793,

        VFNMADD132PHZ256mkz = 7794,

        VFNMADD132PHZ256r = 7795,

        VFNMADD132PHZ256rk = 7796,

        VFNMADD132PHZ256rkz = 7797,

        VFNMADD132PHZm = 7798,

        VFNMADD132PHZmb = 7799,

        VFNMADD132PHZmbk = 7800,

        VFNMADD132PHZmbkz = 7801,

        VFNMADD132PHZmk = 7802,

        VFNMADD132PHZmkz = 7803,

        VFNMADD132PHZr = 7804,

        VFNMADD132PHZrb = 7805,

        VFNMADD132PHZrbk = 7806,

        VFNMADD132PHZrbkz = 7807,

        VFNMADD132PHZrk = 7808,

        VFNMADD132PHZrkz = 7809,

        VFNMADD132PSYm = 7810,

        VFNMADD132PSYr = 7811,

        VFNMADD132PSZ128m = 7812,

        VFNMADD132PSZ128mb = 7813,

        VFNMADD132PSZ128mbk = 7814,

        VFNMADD132PSZ128mbkz = 7815,

        VFNMADD132PSZ128mk = 7816,

        VFNMADD132PSZ128mkz = 7817,

        VFNMADD132PSZ128r = 7818,

        VFNMADD132PSZ128rk = 7819,

        VFNMADD132PSZ128rkz = 7820,

        VFNMADD132PSZ256m = 7821,

        VFNMADD132PSZ256mb = 7822,

        VFNMADD132PSZ256mbk = 7823,

        VFNMADD132PSZ256mbkz = 7824,

        VFNMADD132PSZ256mk = 7825,

        VFNMADD132PSZ256mkz = 7826,

        VFNMADD132PSZ256r = 7827,

        VFNMADD132PSZ256rk = 7828,

        VFNMADD132PSZ256rkz = 7829,

        VFNMADD132PSZm = 7830,

        VFNMADD132PSZmb = 7831,

        VFNMADD132PSZmbk = 7832,

        VFNMADD132PSZmbkz = 7833,

        VFNMADD132PSZmk = 7834,

        VFNMADD132PSZmkz = 7835,

        VFNMADD132PSZr = 7836,

        VFNMADD132PSZrb = 7837,

        VFNMADD132PSZrbk = 7838,

        VFNMADD132PSZrbkz = 7839,

        VFNMADD132PSZrk = 7840,

        VFNMADD132PSZrkz = 7841,

        VFNMADD132PSm = 7842,

        VFNMADD132PSr = 7843,

        VFNMADD132SDZm = 7844,

        VFNMADD132SDZm_Int = 7845,

        VFNMADD132SDZm_Intk = 7846,

        VFNMADD132SDZm_Intkz = 7847,

        VFNMADD132SDZr = 7848,

        VFNMADD132SDZr_Int = 7849,

        VFNMADD132SDZr_Intk = 7850,

        VFNMADD132SDZr_Intkz = 7851,

        VFNMADD132SDZrb = 7852,

        VFNMADD132SDZrb_Int = 7853,

        VFNMADD132SDZrb_Intk = 7854,

        VFNMADD132SDZrb_Intkz = 7855,

        VFNMADD132SDm = 7856,

        VFNMADD132SDm_Int = 7857,

        VFNMADD132SDr = 7858,

        VFNMADD132SDr_Int = 7859,

        VFNMADD132SHZm = 7860,

        VFNMADD132SHZm_Int = 7861,

        VFNMADD132SHZm_Intk = 7862,

        VFNMADD132SHZm_Intkz = 7863,

        VFNMADD132SHZr = 7864,

        VFNMADD132SHZr_Int = 7865,

        VFNMADD132SHZr_Intk = 7866,

        VFNMADD132SHZr_Intkz = 7867,

        VFNMADD132SHZrb = 7868,

        VFNMADD132SHZrb_Int = 7869,

        VFNMADD132SHZrb_Intk = 7870,

        VFNMADD132SHZrb_Intkz = 7871,

        VFNMADD132SSZm = 7872,

        VFNMADD132SSZm_Int = 7873,

        VFNMADD132SSZm_Intk = 7874,

        VFNMADD132SSZm_Intkz = 7875,

        VFNMADD132SSZr = 7876,

        VFNMADD132SSZr_Int = 7877,

        VFNMADD132SSZr_Intk = 7878,

        VFNMADD132SSZr_Intkz = 7879,

        VFNMADD132SSZrb = 7880,

        VFNMADD132SSZrb_Int = 7881,

        VFNMADD132SSZrb_Intk = 7882,

        VFNMADD132SSZrb_Intkz = 7883,

        VFNMADD132SSm = 7884,

        VFNMADD132SSm_Int = 7885,

        VFNMADD132SSr = 7886,

        VFNMADD132SSr_Int = 7887,

        VFNMADD213PDYm = 7888,

        VFNMADD213PDYr = 7889,

        VFNMADD213PDZ128m = 7890,

        VFNMADD213PDZ128mb = 7891,

        VFNMADD213PDZ128mbk = 7892,

        VFNMADD213PDZ128mbkz = 7893,

        VFNMADD213PDZ128mk = 7894,

        VFNMADD213PDZ128mkz = 7895,

        VFNMADD213PDZ128r = 7896,

        VFNMADD213PDZ128rk = 7897,

        VFNMADD213PDZ128rkz = 7898,

        VFNMADD213PDZ256m = 7899,

        VFNMADD213PDZ256mb = 7900,

        VFNMADD213PDZ256mbk = 7901,

        VFNMADD213PDZ256mbkz = 7902,

        VFNMADD213PDZ256mk = 7903,

        VFNMADD213PDZ256mkz = 7904,

        VFNMADD213PDZ256r = 7905,

        VFNMADD213PDZ256rk = 7906,

        VFNMADD213PDZ256rkz = 7907,

        VFNMADD213PDZm = 7908,

        VFNMADD213PDZmb = 7909,

        VFNMADD213PDZmbk = 7910,

        VFNMADD213PDZmbkz = 7911,

        VFNMADD213PDZmk = 7912,

        VFNMADD213PDZmkz = 7913,

        VFNMADD213PDZr = 7914,

        VFNMADD213PDZrb = 7915,

        VFNMADD213PDZrbk = 7916,

        VFNMADD213PDZrbkz = 7917,

        VFNMADD213PDZrk = 7918,

        VFNMADD213PDZrkz = 7919,

        VFNMADD213PDm = 7920,

        VFNMADD213PDr = 7921,

        VFNMADD213PHZ128m = 7922,

        VFNMADD213PHZ128mb = 7923,

        VFNMADD213PHZ128mbk = 7924,

        VFNMADD213PHZ128mbkz = 7925,

        VFNMADD213PHZ128mk = 7926,

        VFNMADD213PHZ128mkz = 7927,

        VFNMADD213PHZ128r = 7928,

        VFNMADD213PHZ128rk = 7929,

        VFNMADD213PHZ128rkz = 7930,

        VFNMADD213PHZ256m = 7931,

        VFNMADD213PHZ256mb = 7932,

        VFNMADD213PHZ256mbk = 7933,

        VFNMADD213PHZ256mbkz = 7934,

        VFNMADD213PHZ256mk = 7935,

        VFNMADD213PHZ256mkz = 7936,

        VFNMADD213PHZ256r = 7937,

        VFNMADD213PHZ256rk = 7938,

        VFNMADD213PHZ256rkz = 7939,

        VFNMADD213PHZm = 7940,

        VFNMADD213PHZmb = 7941,

        VFNMADD213PHZmbk = 7942,

        VFNMADD213PHZmbkz = 7943,

        VFNMADD213PHZmk = 7944,

        VFNMADD213PHZmkz = 7945,

        VFNMADD213PHZr = 7946,

        VFNMADD213PHZrb = 7947,

        VFNMADD213PHZrbk = 7948,

        VFNMADD213PHZrbkz = 7949,

        VFNMADD213PHZrk = 7950,

        VFNMADD213PHZrkz = 7951,

        VFNMADD213PSYm = 7952,

        VFNMADD213PSYr = 7953,

        VFNMADD213PSZ128m = 7954,

        VFNMADD213PSZ128mb = 7955,

        VFNMADD213PSZ128mbk = 7956,

        VFNMADD213PSZ128mbkz = 7957,

        VFNMADD213PSZ128mk = 7958,

        VFNMADD213PSZ128mkz = 7959,

        VFNMADD213PSZ128r = 7960,

        VFNMADD213PSZ128rk = 7961,

        VFNMADD213PSZ128rkz = 7962,

        VFNMADD213PSZ256m = 7963,

        VFNMADD213PSZ256mb = 7964,

        VFNMADD213PSZ256mbk = 7965,

        VFNMADD213PSZ256mbkz = 7966,

        VFNMADD213PSZ256mk = 7967,

        VFNMADD213PSZ256mkz = 7968,

        VFNMADD213PSZ256r = 7969,

        VFNMADD213PSZ256rk = 7970,

        VFNMADD213PSZ256rkz = 7971,

        VFNMADD213PSZm = 7972,

        VFNMADD213PSZmb = 7973,

        VFNMADD213PSZmbk = 7974,

        VFNMADD213PSZmbkz = 7975,

        VFNMADD213PSZmk = 7976,

        VFNMADD213PSZmkz = 7977,

        VFNMADD213PSZr = 7978,

        VFNMADD213PSZrb = 7979,

        VFNMADD213PSZrbk = 7980,

        VFNMADD213PSZrbkz = 7981,

        VFNMADD213PSZrk = 7982,

        VFNMADD213PSZrkz = 7983,

        VFNMADD213PSm = 7984,

        VFNMADD213PSr = 7985,

        VFNMADD213SDZm = 7986,

        VFNMADD213SDZm_Int = 7987,

        VFNMADD213SDZm_Intk = 7988,

        VFNMADD213SDZm_Intkz = 7989,

        VFNMADD213SDZr = 7990,

        VFNMADD213SDZr_Int = 7991,

        VFNMADD213SDZr_Intk = 7992,

        VFNMADD213SDZr_Intkz = 7993,

        VFNMADD213SDZrb = 7994,

        VFNMADD213SDZrb_Int = 7995,

        VFNMADD213SDZrb_Intk = 7996,

        VFNMADD213SDZrb_Intkz = 7997,

        VFNMADD213SDm = 7998,

        VFNMADD213SDm_Int = 7999,

        VFNMADD213SDr = 8000,

        VFNMADD213SDr_Int = 8001,

        VFNMADD213SHZm = 8002,

        VFNMADD213SHZm_Int = 8003,

        VFNMADD213SHZm_Intk = 8004,

        VFNMADD213SHZm_Intkz = 8005,

        VFNMADD213SHZr = 8006,

        VFNMADD213SHZr_Int = 8007,

        VFNMADD213SHZr_Intk = 8008,

        VFNMADD213SHZr_Intkz = 8009,

        VFNMADD213SHZrb = 8010,

        VFNMADD213SHZrb_Int = 8011,

        VFNMADD213SHZrb_Intk = 8012,

        VFNMADD213SHZrb_Intkz = 8013,

        VFNMADD213SSZm = 8014,

        VFNMADD213SSZm_Int = 8015,

        VFNMADD213SSZm_Intk = 8016,

        VFNMADD213SSZm_Intkz = 8017,

        VFNMADD213SSZr = 8018,

        VFNMADD213SSZr_Int = 8019,

        VFNMADD213SSZr_Intk = 8020,

        VFNMADD213SSZr_Intkz = 8021,

        VFNMADD213SSZrb = 8022,

        VFNMADD213SSZrb_Int = 8023,

        VFNMADD213SSZrb_Intk = 8024,

        VFNMADD213SSZrb_Intkz = 8025,

        VFNMADD213SSm = 8026,

        VFNMADD213SSm_Int = 8027,

        VFNMADD213SSr = 8028,

        VFNMADD213SSr_Int = 8029,

        VFNMADD231PDYm = 8030,

        VFNMADD231PDYr = 8031,

        VFNMADD231PDZ128m = 8032,

        VFNMADD231PDZ128mb = 8033,

        VFNMADD231PDZ128mbk = 8034,

        VFNMADD231PDZ128mbkz = 8035,

        VFNMADD231PDZ128mk = 8036,

        VFNMADD231PDZ128mkz = 8037,

        VFNMADD231PDZ128r = 8038,

        VFNMADD231PDZ128rk = 8039,

        VFNMADD231PDZ128rkz = 8040,

        VFNMADD231PDZ256m = 8041,

        VFNMADD231PDZ256mb = 8042,

        VFNMADD231PDZ256mbk = 8043,

        VFNMADD231PDZ256mbkz = 8044,

        VFNMADD231PDZ256mk = 8045,

        VFNMADD231PDZ256mkz = 8046,

        VFNMADD231PDZ256r = 8047,

        VFNMADD231PDZ256rk = 8048,

        VFNMADD231PDZ256rkz = 8049,

        VFNMADD231PDZm = 8050,

        VFNMADD231PDZmb = 8051,

        VFNMADD231PDZmbk = 8052,

        VFNMADD231PDZmbkz = 8053,

        VFNMADD231PDZmk = 8054,

        VFNMADD231PDZmkz = 8055,

        VFNMADD231PDZr = 8056,

        VFNMADD231PDZrb = 8057,

        VFNMADD231PDZrbk = 8058,

        VFNMADD231PDZrbkz = 8059,

        VFNMADD231PDZrk = 8060,

        VFNMADD231PDZrkz = 8061,

        VFNMADD231PDm = 8062,

        VFNMADD231PDr = 8063,

        VFNMADD231PHZ128m = 8064,

        VFNMADD231PHZ128mb = 8065,

        VFNMADD231PHZ128mbk = 8066,

        VFNMADD231PHZ128mbkz = 8067,

        VFNMADD231PHZ128mk = 8068,

        VFNMADD231PHZ128mkz = 8069,

        VFNMADD231PHZ128r = 8070,

        VFNMADD231PHZ128rk = 8071,

        VFNMADD231PHZ128rkz = 8072,

        VFNMADD231PHZ256m = 8073,

        VFNMADD231PHZ256mb = 8074,

        VFNMADD231PHZ256mbk = 8075,

        VFNMADD231PHZ256mbkz = 8076,

        VFNMADD231PHZ256mk = 8077,

        VFNMADD231PHZ256mkz = 8078,

        VFNMADD231PHZ256r = 8079,

        VFNMADD231PHZ256rk = 8080,

        VFNMADD231PHZ256rkz = 8081,

        VFNMADD231PHZm = 8082,

        VFNMADD231PHZmb = 8083,

        VFNMADD231PHZmbk = 8084,

        VFNMADD231PHZmbkz = 8085,

        VFNMADD231PHZmk = 8086,

        VFNMADD231PHZmkz = 8087,

        VFNMADD231PHZr = 8088,

        VFNMADD231PHZrb = 8089,

        VFNMADD231PHZrbk = 8090,

        VFNMADD231PHZrbkz = 8091,

        VFNMADD231PHZrk = 8092,

        VFNMADD231PHZrkz = 8093,

        VFNMADD231PSYm = 8094,

        VFNMADD231PSYr = 8095,

        VFNMADD231PSZ128m = 8096,

        VFNMADD231PSZ128mb = 8097,

        VFNMADD231PSZ128mbk = 8098,

        VFNMADD231PSZ128mbkz = 8099,

        VFNMADD231PSZ128mk = 8100,

        VFNMADD231PSZ128mkz = 8101,

        VFNMADD231PSZ128r = 8102,

        VFNMADD231PSZ128rk = 8103,

        VFNMADD231PSZ128rkz = 8104,

        VFNMADD231PSZ256m = 8105,

        VFNMADD231PSZ256mb = 8106,

        VFNMADD231PSZ256mbk = 8107,

        VFNMADD231PSZ256mbkz = 8108,

        VFNMADD231PSZ256mk = 8109,

        VFNMADD231PSZ256mkz = 8110,

        VFNMADD231PSZ256r = 8111,

        VFNMADD231PSZ256rk = 8112,

        VFNMADD231PSZ256rkz = 8113,

        VFNMADD231PSZm = 8114,

        VFNMADD231PSZmb = 8115,

        VFNMADD231PSZmbk = 8116,

        VFNMADD231PSZmbkz = 8117,

        VFNMADD231PSZmk = 8118,

        VFNMADD231PSZmkz = 8119,

        VFNMADD231PSZr = 8120,

        VFNMADD231PSZrb = 8121,

        VFNMADD231PSZrbk = 8122,

        VFNMADD231PSZrbkz = 8123,

        VFNMADD231PSZrk = 8124,

        VFNMADD231PSZrkz = 8125,

        VFNMADD231PSm = 8126,

        VFNMADD231PSr = 8127,

        VFNMADD231SDZm = 8128,

        VFNMADD231SDZm_Int = 8129,

        VFNMADD231SDZm_Intk = 8130,

        VFNMADD231SDZm_Intkz = 8131,

        VFNMADD231SDZr = 8132,

        VFNMADD231SDZr_Int = 8133,

        VFNMADD231SDZr_Intk = 8134,

        VFNMADD231SDZr_Intkz = 8135,

        VFNMADD231SDZrb = 8136,

        VFNMADD231SDZrb_Int = 8137,

        VFNMADD231SDZrb_Intk = 8138,

        VFNMADD231SDZrb_Intkz = 8139,

        VFNMADD231SDm = 8140,

        VFNMADD231SDm_Int = 8141,

        VFNMADD231SDr = 8142,

        VFNMADD231SDr_Int = 8143,

        VFNMADD231SHZm = 8144,

        VFNMADD231SHZm_Int = 8145,

        VFNMADD231SHZm_Intk = 8146,

        VFNMADD231SHZm_Intkz = 8147,

        VFNMADD231SHZr = 8148,

        VFNMADD231SHZr_Int = 8149,

        VFNMADD231SHZr_Intk = 8150,

        VFNMADD231SHZr_Intkz = 8151,

        VFNMADD231SHZrb = 8152,

        VFNMADD231SHZrb_Int = 8153,

        VFNMADD231SHZrb_Intk = 8154,

        VFNMADD231SHZrb_Intkz = 8155,

        VFNMADD231SSZm = 8156,

        VFNMADD231SSZm_Int = 8157,

        VFNMADD231SSZm_Intk = 8158,

        VFNMADD231SSZm_Intkz = 8159,

        VFNMADD231SSZr = 8160,

        VFNMADD231SSZr_Int = 8161,

        VFNMADD231SSZr_Intk = 8162,

        VFNMADD231SSZr_Intkz = 8163,

        VFNMADD231SSZrb = 8164,

        VFNMADD231SSZrb_Int = 8165,

        VFNMADD231SSZrb_Intk = 8166,

        VFNMADD231SSZrb_Intkz = 8167,

        VFNMADD231SSm = 8168,

        VFNMADD231SSm_Int = 8169,

        VFNMADD231SSr = 8170,

        VFNMADD231SSr_Int = 8171,

        VFNMADDPD4Ymr = 8172,

        VFNMADDPD4Yrm = 8173,

        VFNMADDPD4Yrr = 8174,

        VFNMADDPD4Yrr_REV = 8175,

        VFNMADDPD4mr = 8176,

        VFNMADDPD4rm = 8177,

        VFNMADDPD4rr = 8178,

        VFNMADDPD4rr_REV = 8179,

        VFNMADDPS4Ymr = 8180,

        VFNMADDPS4Yrm = 8181,

        VFNMADDPS4Yrr = 8182,

        VFNMADDPS4Yrr_REV = 8183,

        VFNMADDPS4mr = 8184,

        VFNMADDPS4rm = 8185,

        VFNMADDPS4rr = 8186,

        VFNMADDPS4rr_REV = 8187,

        VFNMADDSD4mr = 8188,

        VFNMADDSD4mr_Int = 8189,

        VFNMADDSD4rm = 8190,

        VFNMADDSD4rm_Int = 8191,

        VFNMADDSD4rr = 8192,

        VFNMADDSD4rr_Int = 8193,

        VFNMADDSD4rr_Int_REV = 8194,

        VFNMADDSD4rr_REV = 8195,

        VFNMADDSS4mr = 8196,

        VFNMADDSS4mr_Int = 8197,

        VFNMADDSS4rm = 8198,

        VFNMADDSS4rm_Int = 8199,

        VFNMADDSS4rr = 8200,

        VFNMADDSS4rr_Int = 8201,

        VFNMADDSS4rr_Int_REV = 8202,

        VFNMADDSS4rr_REV = 8203,

        VFNMSUB132PDYm = 8204,

        VFNMSUB132PDYr = 8205,

        VFNMSUB132PDZ128m = 8206,

        VFNMSUB132PDZ128mb = 8207,

        VFNMSUB132PDZ128mbk = 8208,

        VFNMSUB132PDZ128mbkz = 8209,

        VFNMSUB132PDZ128mk = 8210,

        VFNMSUB132PDZ128mkz = 8211,

        VFNMSUB132PDZ128r = 8212,

        VFNMSUB132PDZ128rk = 8213,

        VFNMSUB132PDZ128rkz = 8214,

        VFNMSUB132PDZ256m = 8215,

        VFNMSUB132PDZ256mb = 8216,

        VFNMSUB132PDZ256mbk = 8217,

        VFNMSUB132PDZ256mbkz = 8218,

        VFNMSUB132PDZ256mk = 8219,

        VFNMSUB132PDZ256mkz = 8220,

        VFNMSUB132PDZ256r = 8221,

        VFNMSUB132PDZ256rk = 8222,

        VFNMSUB132PDZ256rkz = 8223,

        VFNMSUB132PDZm = 8224,

        VFNMSUB132PDZmb = 8225,

        VFNMSUB132PDZmbk = 8226,

        VFNMSUB132PDZmbkz = 8227,

        VFNMSUB132PDZmk = 8228,

        VFNMSUB132PDZmkz = 8229,

        VFNMSUB132PDZr = 8230,

        VFNMSUB132PDZrb = 8231,

        VFNMSUB132PDZrbk = 8232,

        VFNMSUB132PDZrbkz = 8233,

        VFNMSUB132PDZrk = 8234,

        VFNMSUB132PDZrkz = 8235,

        VFNMSUB132PDm = 8236,

        VFNMSUB132PDr = 8237,

        VFNMSUB132PHZ128m = 8238,

        VFNMSUB132PHZ128mb = 8239,

        VFNMSUB132PHZ128mbk = 8240,

        VFNMSUB132PHZ128mbkz = 8241,

        VFNMSUB132PHZ128mk = 8242,

        VFNMSUB132PHZ128mkz = 8243,

        VFNMSUB132PHZ128r = 8244,

        VFNMSUB132PHZ128rk = 8245,

        VFNMSUB132PHZ128rkz = 8246,

        VFNMSUB132PHZ256m = 8247,

        VFNMSUB132PHZ256mb = 8248,

        VFNMSUB132PHZ256mbk = 8249,

        VFNMSUB132PHZ256mbkz = 8250,

        VFNMSUB132PHZ256mk = 8251,

        VFNMSUB132PHZ256mkz = 8252,

        VFNMSUB132PHZ256r = 8253,

        VFNMSUB132PHZ256rk = 8254,

        VFNMSUB132PHZ256rkz = 8255,

        VFNMSUB132PHZm = 8256,

        VFNMSUB132PHZmb = 8257,

        VFNMSUB132PHZmbk = 8258,

        VFNMSUB132PHZmbkz = 8259,

        VFNMSUB132PHZmk = 8260,

        VFNMSUB132PHZmkz = 8261,

        VFNMSUB132PHZr = 8262,

        VFNMSUB132PHZrb = 8263,

        VFNMSUB132PHZrbk = 8264,

        VFNMSUB132PHZrbkz = 8265,

        VFNMSUB132PHZrk = 8266,

        VFNMSUB132PHZrkz = 8267,

        VFNMSUB132PSYm = 8268,

        VFNMSUB132PSYr = 8269,

        VFNMSUB132PSZ128m = 8270,

        VFNMSUB132PSZ128mb = 8271,

        VFNMSUB132PSZ128mbk = 8272,

        VFNMSUB132PSZ128mbkz = 8273,

        VFNMSUB132PSZ128mk = 8274,

        VFNMSUB132PSZ128mkz = 8275,

        VFNMSUB132PSZ128r = 8276,

        VFNMSUB132PSZ128rk = 8277,

        VFNMSUB132PSZ128rkz = 8278,

        VFNMSUB132PSZ256m = 8279,

        VFNMSUB132PSZ256mb = 8280,

        VFNMSUB132PSZ256mbk = 8281,

        VFNMSUB132PSZ256mbkz = 8282,

        VFNMSUB132PSZ256mk = 8283,

        VFNMSUB132PSZ256mkz = 8284,

        VFNMSUB132PSZ256r = 8285,

        VFNMSUB132PSZ256rk = 8286,

        VFNMSUB132PSZ256rkz = 8287,

        VFNMSUB132PSZm = 8288,

        VFNMSUB132PSZmb = 8289,

        VFNMSUB132PSZmbk = 8290,

        VFNMSUB132PSZmbkz = 8291,

        VFNMSUB132PSZmk = 8292,

        VFNMSUB132PSZmkz = 8293,

        VFNMSUB132PSZr = 8294,

        VFNMSUB132PSZrb = 8295,

        VFNMSUB132PSZrbk = 8296,

        VFNMSUB132PSZrbkz = 8297,

        VFNMSUB132PSZrk = 8298,

        VFNMSUB132PSZrkz = 8299,

        VFNMSUB132PSm = 8300,

        VFNMSUB132PSr = 8301,

        VFNMSUB132SDZm = 8302,

        VFNMSUB132SDZm_Int = 8303,

        VFNMSUB132SDZm_Intk = 8304,

        VFNMSUB132SDZm_Intkz = 8305,

        VFNMSUB132SDZr = 8306,

        VFNMSUB132SDZr_Int = 8307,

        VFNMSUB132SDZr_Intk = 8308,

        VFNMSUB132SDZr_Intkz = 8309,

        VFNMSUB132SDZrb = 8310,

        VFNMSUB132SDZrb_Int = 8311,

        VFNMSUB132SDZrb_Intk = 8312,

        VFNMSUB132SDZrb_Intkz = 8313,

        VFNMSUB132SDm = 8314,

        VFNMSUB132SDm_Int = 8315,

        VFNMSUB132SDr = 8316,

        VFNMSUB132SDr_Int = 8317,

        VFNMSUB132SHZm = 8318,

        VFNMSUB132SHZm_Int = 8319,

        VFNMSUB132SHZm_Intk = 8320,

        VFNMSUB132SHZm_Intkz = 8321,

        VFNMSUB132SHZr = 8322,

        VFNMSUB132SHZr_Int = 8323,

        VFNMSUB132SHZr_Intk = 8324,

        VFNMSUB132SHZr_Intkz = 8325,

        VFNMSUB132SHZrb = 8326,

        VFNMSUB132SHZrb_Int = 8327,

        VFNMSUB132SHZrb_Intk = 8328,

        VFNMSUB132SHZrb_Intkz = 8329,

        VFNMSUB132SSZm = 8330,

        VFNMSUB132SSZm_Int = 8331,

        VFNMSUB132SSZm_Intk = 8332,

        VFNMSUB132SSZm_Intkz = 8333,

        VFNMSUB132SSZr = 8334,

        VFNMSUB132SSZr_Int = 8335,

        VFNMSUB132SSZr_Intk = 8336,

        VFNMSUB132SSZr_Intkz = 8337,

        VFNMSUB132SSZrb = 8338,

        VFNMSUB132SSZrb_Int = 8339,

        VFNMSUB132SSZrb_Intk = 8340,

        VFNMSUB132SSZrb_Intkz = 8341,

        VFNMSUB132SSm = 8342,

        VFNMSUB132SSm_Int = 8343,

        VFNMSUB132SSr = 8344,

        VFNMSUB132SSr_Int = 8345,

        VFNMSUB213PDYm = 8346,

        VFNMSUB213PDYr = 8347,

        VFNMSUB213PDZ128m = 8348,

        VFNMSUB213PDZ128mb = 8349,

        VFNMSUB213PDZ128mbk = 8350,

        VFNMSUB213PDZ128mbkz = 8351,

        VFNMSUB213PDZ128mk = 8352,

        VFNMSUB213PDZ128mkz = 8353,

        VFNMSUB213PDZ128r = 8354,

        VFNMSUB213PDZ128rk = 8355,

        VFNMSUB213PDZ128rkz = 8356,

        VFNMSUB213PDZ256m = 8357,

        VFNMSUB213PDZ256mb = 8358,

        VFNMSUB213PDZ256mbk = 8359,

        VFNMSUB213PDZ256mbkz = 8360,

        VFNMSUB213PDZ256mk = 8361,

        VFNMSUB213PDZ256mkz = 8362,

        VFNMSUB213PDZ256r = 8363,

        VFNMSUB213PDZ256rk = 8364,

        VFNMSUB213PDZ256rkz = 8365,

        VFNMSUB213PDZm = 8366,

        VFNMSUB213PDZmb = 8367,

        VFNMSUB213PDZmbk = 8368,

        VFNMSUB213PDZmbkz = 8369,

        VFNMSUB213PDZmk = 8370,

        VFNMSUB213PDZmkz = 8371,

        VFNMSUB213PDZr = 8372,

        VFNMSUB213PDZrb = 8373,

        VFNMSUB213PDZrbk = 8374,

        VFNMSUB213PDZrbkz = 8375,

        VFNMSUB213PDZrk = 8376,

        VFNMSUB213PDZrkz = 8377,

        VFNMSUB213PDm = 8378,

        VFNMSUB213PDr = 8379,

        VFNMSUB213PHZ128m = 8380,

        VFNMSUB213PHZ128mb = 8381,

        VFNMSUB213PHZ128mbk = 8382,

        VFNMSUB213PHZ128mbkz = 8383,

        VFNMSUB213PHZ128mk = 8384,

        VFNMSUB213PHZ128mkz = 8385,

        VFNMSUB213PHZ128r = 8386,

        VFNMSUB213PHZ128rk = 8387,

        VFNMSUB213PHZ128rkz = 8388,

        VFNMSUB213PHZ256m = 8389,

        VFNMSUB213PHZ256mb = 8390,

        VFNMSUB213PHZ256mbk = 8391,

        VFNMSUB213PHZ256mbkz = 8392,

        VFNMSUB213PHZ256mk = 8393,

        VFNMSUB213PHZ256mkz = 8394,

        VFNMSUB213PHZ256r = 8395,

        VFNMSUB213PHZ256rk = 8396,

        VFNMSUB213PHZ256rkz = 8397,

        VFNMSUB213PHZm = 8398,

        VFNMSUB213PHZmb = 8399,

        VFNMSUB213PHZmbk = 8400,

        VFNMSUB213PHZmbkz = 8401,

        VFNMSUB213PHZmk = 8402,

        VFNMSUB213PHZmkz = 8403,

        VFNMSUB213PHZr = 8404,

        VFNMSUB213PHZrb = 8405,

        VFNMSUB213PHZrbk = 8406,

        VFNMSUB213PHZrbkz = 8407,

        VFNMSUB213PHZrk = 8408,

        VFNMSUB213PHZrkz = 8409,

        VFNMSUB213PSYm = 8410,

        VFNMSUB213PSYr = 8411,

        VFNMSUB213PSZ128m = 8412,

        VFNMSUB213PSZ128mb = 8413,

        VFNMSUB213PSZ128mbk = 8414,

        VFNMSUB213PSZ128mbkz = 8415,

        VFNMSUB213PSZ128mk = 8416,

        VFNMSUB213PSZ128mkz = 8417,

        VFNMSUB213PSZ128r = 8418,

        VFNMSUB213PSZ128rk = 8419,

        VFNMSUB213PSZ128rkz = 8420,

        VFNMSUB213PSZ256m = 8421,

        VFNMSUB213PSZ256mb = 8422,

        VFNMSUB213PSZ256mbk = 8423,

        VFNMSUB213PSZ256mbkz = 8424,

        VFNMSUB213PSZ256mk = 8425,

        VFNMSUB213PSZ256mkz = 8426,

        VFNMSUB213PSZ256r = 8427,

        VFNMSUB213PSZ256rk = 8428,

        VFNMSUB213PSZ256rkz = 8429,

        VFNMSUB213PSZm = 8430,

        VFNMSUB213PSZmb = 8431,

        VFNMSUB213PSZmbk = 8432,

        VFNMSUB213PSZmbkz = 8433,

        VFNMSUB213PSZmk = 8434,

        VFNMSUB213PSZmkz = 8435,

        VFNMSUB213PSZr = 8436,

        VFNMSUB213PSZrb = 8437,

        VFNMSUB213PSZrbk = 8438,

        VFNMSUB213PSZrbkz = 8439,

        VFNMSUB213PSZrk = 8440,

        VFNMSUB213PSZrkz = 8441,

        VFNMSUB213PSm = 8442,

        VFNMSUB213PSr = 8443,

        VFNMSUB213SDZm = 8444,

        VFNMSUB213SDZm_Int = 8445,

        VFNMSUB213SDZm_Intk = 8446,

        VFNMSUB213SDZm_Intkz = 8447,

        VFNMSUB213SDZr = 8448,

        VFNMSUB213SDZr_Int = 8449,

        VFNMSUB213SDZr_Intk = 8450,

        VFNMSUB213SDZr_Intkz = 8451,

        VFNMSUB213SDZrb = 8452,

        VFNMSUB213SDZrb_Int = 8453,

        VFNMSUB213SDZrb_Intk = 8454,

        VFNMSUB213SDZrb_Intkz = 8455,

        VFNMSUB213SDm = 8456,

        VFNMSUB213SDm_Int = 8457,

        VFNMSUB213SDr = 8458,

        VFNMSUB213SDr_Int = 8459,

        VFNMSUB213SHZm = 8460,

        VFNMSUB213SHZm_Int = 8461,

        VFNMSUB213SHZm_Intk = 8462,

        VFNMSUB213SHZm_Intkz = 8463,

        VFNMSUB213SHZr = 8464,

        VFNMSUB213SHZr_Int = 8465,

        VFNMSUB213SHZr_Intk = 8466,

        VFNMSUB213SHZr_Intkz = 8467,

        VFNMSUB213SHZrb = 8468,

        VFNMSUB213SHZrb_Int = 8469,

        VFNMSUB213SHZrb_Intk = 8470,

        VFNMSUB213SHZrb_Intkz = 8471,

        VFNMSUB213SSZm = 8472,

        VFNMSUB213SSZm_Int = 8473,

        VFNMSUB213SSZm_Intk = 8474,

        VFNMSUB213SSZm_Intkz = 8475,

        VFNMSUB213SSZr = 8476,

        VFNMSUB213SSZr_Int = 8477,

        VFNMSUB213SSZr_Intk = 8478,

        VFNMSUB213SSZr_Intkz = 8479,

        VFNMSUB213SSZrb = 8480,

        VFNMSUB213SSZrb_Int = 8481,

        VFNMSUB213SSZrb_Intk = 8482,

        VFNMSUB213SSZrb_Intkz = 8483,

        VFNMSUB213SSm = 8484,

        VFNMSUB213SSm_Int = 8485,

        VFNMSUB213SSr = 8486,

        VFNMSUB213SSr_Int = 8487,

        VFNMSUB231PDYm = 8488,

        VFNMSUB231PDYr = 8489,

        VFNMSUB231PDZ128m = 8490,

        VFNMSUB231PDZ128mb = 8491,

        VFNMSUB231PDZ128mbk = 8492,

        VFNMSUB231PDZ128mbkz = 8493,

        VFNMSUB231PDZ128mk = 8494,

        VFNMSUB231PDZ128mkz = 8495,

        VFNMSUB231PDZ128r = 8496,

        VFNMSUB231PDZ128rk = 8497,

        VFNMSUB231PDZ128rkz = 8498,

        VFNMSUB231PDZ256m = 8499,

        VFNMSUB231PDZ256mb = 8500,

        VFNMSUB231PDZ256mbk = 8501,

        VFNMSUB231PDZ256mbkz = 8502,

        VFNMSUB231PDZ256mk = 8503,

        VFNMSUB231PDZ256mkz = 8504,

        VFNMSUB231PDZ256r = 8505,

        VFNMSUB231PDZ256rk = 8506,

        VFNMSUB231PDZ256rkz = 8507,

        VFNMSUB231PDZm = 8508,

        VFNMSUB231PDZmb = 8509,

        VFNMSUB231PDZmbk = 8510,

        VFNMSUB231PDZmbkz = 8511,

        VFNMSUB231PDZmk = 8512,

        VFNMSUB231PDZmkz = 8513,

        VFNMSUB231PDZr = 8514,

        VFNMSUB231PDZrb = 8515,

        VFNMSUB231PDZrbk = 8516,

        VFNMSUB231PDZrbkz = 8517,

        VFNMSUB231PDZrk = 8518,

        VFNMSUB231PDZrkz = 8519,

        VFNMSUB231PDm = 8520,

        VFNMSUB231PDr = 8521,

        VFNMSUB231PHZ128m = 8522,

        VFNMSUB231PHZ128mb = 8523,

        VFNMSUB231PHZ128mbk = 8524,

        VFNMSUB231PHZ128mbkz = 8525,

        VFNMSUB231PHZ128mk = 8526,

        VFNMSUB231PHZ128mkz = 8527,

        VFNMSUB231PHZ128r = 8528,

        VFNMSUB231PHZ128rk = 8529,

        VFNMSUB231PHZ128rkz = 8530,

        VFNMSUB231PHZ256m = 8531,

        VFNMSUB231PHZ256mb = 8532,

        VFNMSUB231PHZ256mbk = 8533,

        VFNMSUB231PHZ256mbkz = 8534,

        VFNMSUB231PHZ256mk = 8535,

        VFNMSUB231PHZ256mkz = 8536,

        VFNMSUB231PHZ256r = 8537,

        VFNMSUB231PHZ256rk = 8538,

        VFNMSUB231PHZ256rkz = 8539,

        VFNMSUB231PHZm = 8540,

        VFNMSUB231PHZmb = 8541,

        VFNMSUB231PHZmbk = 8542,

        VFNMSUB231PHZmbkz = 8543,

        VFNMSUB231PHZmk = 8544,

        VFNMSUB231PHZmkz = 8545,

        VFNMSUB231PHZr = 8546,

        VFNMSUB231PHZrb = 8547,

        VFNMSUB231PHZrbk = 8548,

        VFNMSUB231PHZrbkz = 8549,

        VFNMSUB231PHZrk = 8550,

        VFNMSUB231PHZrkz = 8551,

        VFNMSUB231PSYm = 8552,

        VFNMSUB231PSYr = 8553,

        VFNMSUB231PSZ128m = 8554,

        VFNMSUB231PSZ128mb = 8555,

        VFNMSUB231PSZ128mbk = 8556,

        VFNMSUB231PSZ128mbkz = 8557,

        VFNMSUB231PSZ128mk = 8558,

        VFNMSUB231PSZ128mkz = 8559,

        VFNMSUB231PSZ128r = 8560,

        VFNMSUB231PSZ128rk = 8561,

        VFNMSUB231PSZ128rkz = 8562,

        VFNMSUB231PSZ256m = 8563,

        VFNMSUB231PSZ256mb = 8564,

        VFNMSUB231PSZ256mbk = 8565,

        VFNMSUB231PSZ256mbkz = 8566,

        VFNMSUB231PSZ256mk = 8567,

        VFNMSUB231PSZ256mkz = 8568,

        VFNMSUB231PSZ256r = 8569,

        VFNMSUB231PSZ256rk = 8570,

        VFNMSUB231PSZ256rkz = 8571,

        VFNMSUB231PSZm = 8572,

        VFNMSUB231PSZmb = 8573,

        VFNMSUB231PSZmbk = 8574,

        VFNMSUB231PSZmbkz = 8575,

        VFNMSUB231PSZmk = 8576,

        VFNMSUB231PSZmkz = 8577,

        VFNMSUB231PSZr = 8578,

        VFNMSUB231PSZrb = 8579,

        VFNMSUB231PSZrbk = 8580,

        VFNMSUB231PSZrbkz = 8581,

        VFNMSUB231PSZrk = 8582,

        VFNMSUB231PSZrkz = 8583,

        VFNMSUB231PSm = 8584,

        VFNMSUB231PSr = 8585,

        VFNMSUB231SDZm = 8586,

        VFNMSUB231SDZm_Int = 8587,

        VFNMSUB231SDZm_Intk = 8588,

        VFNMSUB231SDZm_Intkz = 8589,

        VFNMSUB231SDZr = 8590,

        VFNMSUB231SDZr_Int = 8591,

        VFNMSUB231SDZr_Intk = 8592,

        VFNMSUB231SDZr_Intkz = 8593,

        VFNMSUB231SDZrb = 8594,

        VFNMSUB231SDZrb_Int = 8595,

        VFNMSUB231SDZrb_Intk = 8596,

        VFNMSUB231SDZrb_Intkz = 8597,

        VFNMSUB231SDm = 8598,

        VFNMSUB231SDm_Int = 8599,

        VFNMSUB231SDr = 8600,

        VFNMSUB231SDr_Int = 8601,

        VFNMSUB231SHZm = 8602,

        VFNMSUB231SHZm_Int = 8603,

        VFNMSUB231SHZm_Intk = 8604,

        VFNMSUB231SHZm_Intkz = 8605,

        VFNMSUB231SHZr = 8606,

        VFNMSUB231SHZr_Int = 8607,

        VFNMSUB231SHZr_Intk = 8608,

        VFNMSUB231SHZr_Intkz = 8609,

        VFNMSUB231SHZrb = 8610,

        VFNMSUB231SHZrb_Int = 8611,

        VFNMSUB231SHZrb_Intk = 8612,

        VFNMSUB231SHZrb_Intkz = 8613,

        VFNMSUB231SSZm = 8614,

        VFNMSUB231SSZm_Int = 8615,

        VFNMSUB231SSZm_Intk = 8616,

        VFNMSUB231SSZm_Intkz = 8617,

        VFNMSUB231SSZr = 8618,

        VFNMSUB231SSZr_Int = 8619,

        VFNMSUB231SSZr_Intk = 8620,

        VFNMSUB231SSZr_Intkz = 8621,

        VFNMSUB231SSZrb = 8622,

        VFNMSUB231SSZrb_Int = 8623,

        VFNMSUB231SSZrb_Intk = 8624,

        VFNMSUB231SSZrb_Intkz = 8625,

        VFNMSUB231SSm = 8626,

        VFNMSUB231SSm_Int = 8627,

        VFNMSUB231SSr = 8628,

        VFNMSUB231SSr_Int = 8629,

        VFNMSUBPD4Ymr = 8630,

        VFNMSUBPD4Yrm = 8631,

        VFNMSUBPD4Yrr = 8632,

        VFNMSUBPD4Yrr_REV = 8633,

        VFNMSUBPD4mr = 8634,

        VFNMSUBPD4rm = 8635,

        VFNMSUBPD4rr = 8636,

        VFNMSUBPD4rr_REV = 8637,

        VFNMSUBPS4Ymr = 8638,

        VFNMSUBPS4Yrm = 8639,

        VFNMSUBPS4Yrr = 8640,

        VFNMSUBPS4Yrr_REV = 8641,

        VFNMSUBPS4mr = 8642,

        VFNMSUBPS4rm = 8643,

        VFNMSUBPS4rr = 8644,

        VFNMSUBPS4rr_REV = 8645,

        VFNMSUBSD4mr = 8646,

        VFNMSUBSD4mr_Int = 8647,

        VFNMSUBSD4rm = 8648,

        VFNMSUBSD4rm_Int = 8649,

        VFNMSUBSD4rr = 8650,

        VFNMSUBSD4rr_Int = 8651,

        VFNMSUBSD4rr_Int_REV = 8652,

        VFNMSUBSD4rr_REV = 8653,

        VFNMSUBSS4mr = 8654,

        VFNMSUBSS4mr_Int = 8655,

        VFNMSUBSS4rm = 8656,

        VFNMSUBSS4rm_Int = 8657,

        VFNMSUBSS4rr = 8658,

        VFNMSUBSS4rr_Int = 8659,

        VFNMSUBSS4rr_Int_REV = 8660,

        VFNMSUBSS4rr_REV = 8661,

        VFPCLASSPDZ128rm = 8662,

        VFPCLASSPDZ128rmb = 8663,

        VFPCLASSPDZ128rmbk = 8664,

        VFPCLASSPDZ128rmk = 8665,

        VFPCLASSPDZ128rr = 8666,

        VFPCLASSPDZ128rrk = 8667,

        VFPCLASSPDZ256rm = 8668,

        VFPCLASSPDZ256rmb = 8669,

        VFPCLASSPDZ256rmbk = 8670,

        VFPCLASSPDZ256rmk = 8671,

        VFPCLASSPDZ256rr = 8672,

        VFPCLASSPDZ256rrk = 8673,

        VFPCLASSPDZrm = 8674,

        VFPCLASSPDZrmb = 8675,

        VFPCLASSPDZrmbk = 8676,

        VFPCLASSPDZrmk = 8677,

        VFPCLASSPDZrr = 8678,

        VFPCLASSPDZrrk = 8679,

        VFPCLASSPHZ128rm = 8680,

        VFPCLASSPHZ128rmb = 8681,

        VFPCLASSPHZ128rmbk = 8682,

        VFPCLASSPHZ128rmk = 8683,

        VFPCLASSPHZ128rr = 8684,

        VFPCLASSPHZ128rrk = 8685,

        VFPCLASSPHZ256rm = 8686,

        VFPCLASSPHZ256rmb = 8687,

        VFPCLASSPHZ256rmbk = 8688,

        VFPCLASSPHZ256rmk = 8689,

        VFPCLASSPHZ256rr = 8690,

        VFPCLASSPHZ256rrk = 8691,

        VFPCLASSPHZrm = 8692,

        VFPCLASSPHZrmb = 8693,

        VFPCLASSPHZrmbk = 8694,

        VFPCLASSPHZrmk = 8695,

        VFPCLASSPHZrr = 8696,

        VFPCLASSPHZrrk = 8697,

        VFPCLASSPSZ128rm = 8698,

        VFPCLASSPSZ128rmb = 8699,

        VFPCLASSPSZ128rmbk = 8700,

        VFPCLASSPSZ128rmk = 8701,

        VFPCLASSPSZ128rr = 8702,

        VFPCLASSPSZ128rrk = 8703,

        VFPCLASSPSZ256rm = 8704,

        VFPCLASSPSZ256rmb = 8705,

        VFPCLASSPSZ256rmbk = 8706,

        VFPCLASSPSZ256rmk = 8707,

        VFPCLASSPSZ256rr = 8708,

        VFPCLASSPSZ256rrk = 8709,

        VFPCLASSPSZrm = 8710,

        VFPCLASSPSZrmb = 8711,

        VFPCLASSPSZrmbk = 8712,

        VFPCLASSPSZrmk = 8713,

        VFPCLASSPSZrr = 8714,

        VFPCLASSPSZrrk = 8715,

        VFPCLASSSDZrm = 8716,

        VFPCLASSSDZrmk = 8717,

        VFPCLASSSDZrr = 8718,

        VFPCLASSSDZrrk = 8719,

        VFPCLASSSHZrm = 8720,

        VFPCLASSSHZrmk = 8721,

        VFPCLASSSHZrr = 8722,

        VFPCLASSSHZrrk = 8723,

        VFPCLASSSSZrm = 8724,

        VFPCLASSSSZrmk = 8725,

        VFPCLASSSSZrr = 8726,

        VFPCLASSSSZrrk = 8727,

        VFRCZPDYrm = 8728,

        VFRCZPDYrr = 8729,

        VFRCZPDrm = 8730,

        VFRCZPDrr = 8731,

        VFRCZPSYrm = 8732,

        VFRCZPSYrr = 8733,

        VFRCZPSrm = 8734,

        VFRCZPSrr = 8735,

        VFRCZSDrm = 8736,

        VFRCZSDrr = 8737,

        VFRCZSSrm = 8738,

        VFRCZSSrr = 8739,

        VGATHERDPDYrm = 8740,

        VGATHERDPDZ128rm = 8741,

        VGATHERDPDZ256rm = 8742,

        VGATHERDPDZrm = 8743,

        VGATHERDPDrm = 8744,

        VGATHERDPSYrm = 8745,

        VGATHERDPSZ128rm = 8746,

        VGATHERDPSZ256rm = 8747,

        VGATHERDPSZrm = 8748,

        VGATHERDPSrm = 8749,

        VGATHERPF0DPDm = 8750,

        VGATHERPF0DPSm = 8751,

        VGATHERPF0QPDm = 8752,

        VGATHERPF0QPSm = 8753,

        VGATHERPF1DPDm = 8754,

        VGATHERPF1DPSm = 8755,

        VGATHERPF1QPDm = 8756,

        VGATHERPF1QPSm = 8757,

        VGATHERQPDYrm = 8758,

        VGATHERQPDZ128rm = 8759,

        VGATHERQPDZ256rm = 8760,

        VGATHERQPDZrm = 8761,

        VGATHERQPDrm = 8762,

        VGATHERQPSYrm = 8763,

        VGATHERQPSZ128rm = 8764,

        VGATHERQPSZ256rm = 8765,

        VGATHERQPSZrm = 8766,

        VGATHERQPSrm = 8767,

        VGETEXPPDZ128m = 8768,

        VGETEXPPDZ128mb = 8769,

        VGETEXPPDZ128mbk = 8770,

        VGETEXPPDZ128mbkz = 8771,

        VGETEXPPDZ128mk = 8772,

        VGETEXPPDZ128mkz = 8773,

        VGETEXPPDZ128r = 8774,

        VGETEXPPDZ128rk = 8775,

        VGETEXPPDZ128rkz = 8776,

        VGETEXPPDZ256m = 8777,

        VGETEXPPDZ256mb = 8778,

        VGETEXPPDZ256mbk = 8779,

        VGETEXPPDZ256mbkz = 8780,

        VGETEXPPDZ256mk = 8781,

        VGETEXPPDZ256mkz = 8782,

        VGETEXPPDZ256r = 8783,

        VGETEXPPDZ256rk = 8784,

        VGETEXPPDZ256rkz = 8785,

        VGETEXPPDZm = 8786,

        VGETEXPPDZmb = 8787,

        VGETEXPPDZmbk = 8788,

        VGETEXPPDZmbkz = 8789,

        VGETEXPPDZmk = 8790,

        VGETEXPPDZmkz = 8791,

        VGETEXPPDZr = 8792,

        VGETEXPPDZrb = 8793,

        VGETEXPPDZrbk = 8794,

        VGETEXPPDZrbkz = 8795,

        VGETEXPPDZrk = 8796,

        VGETEXPPDZrkz = 8797,

        VGETEXPPHZ128m = 8798,

        VGETEXPPHZ128mb = 8799,

        VGETEXPPHZ128mbk = 8800,

        VGETEXPPHZ128mbkz = 8801,

        VGETEXPPHZ128mk = 8802,

        VGETEXPPHZ128mkz = 8803,

        VGETEXPPHZ128r = 8804,

        VGETEXPPHZ128rk = 8805,

        VGETEXPPHZ128rkz = 8806,

        VGETEXPPHZ256m = 8807,

        VGETEXPPHZ256mb = 8808,

        VGETEXPPHZ256mbk = 8809,

        VGETEXPPHZ256mbkz = 8810,

        VGETEXPPHZ256mk = 8811,

        VGETEXPPHZ256mkz = 8812,

        VGETEXPPHZ256r = 8813,

        VGETEXPPHZ256rk = 8814,

        VGETEXPPHZ256rkz = 8815,

        VGETEXPPHZm = 8816,

        VGETEXPPHZmb = 8817,

        VGETEXPPHZmbk = 8818,

        VGETEXPPHZmbkz = 8819,

        VGETEXPPHZmk = 8820,

        VGETEXPPHZmkz = 8821,

        VGETEXPPHZr = 8822,

        VGETEXPPHZrb = 8823,

        VGETEXPPHZrbk = 8824,

        VGETEXPPHZrbkz = 8825,

        VGETEXPPHZrk = 8826,

        VGETEXPPHZrkz = 8827,

        VGETEXPPSZ128m = 8828,

        VGETEXPPSZ128mb = 8829,

        VGETEXPPSZ128mbk = 8830,

        VGETEXPPSZ128mbkz = 8831,

        VGETEXPPSZ128mk = 8832,

        VGETEXPPSZ128mkz = 8833,

        VGETEXPPSZ128r = 8834,

        VGETEXPPSZ128rk = 8835,

        VGETEXPPSZ128rkz = 8836,

        VGETEXPPSZ256m = 8837,

        VGETEXPPSZ256mb = 8838,

        VGETEXPPSZ256mbk = 8839,

        VGETEXPPSZ256mbkz = 8840,

        VGETEXPPSZ256mk = 8841,

        VGETEXPPSZ256mkz = 8842,

        VGETEXPPSZ256r = 8843,

        VGETEXPPSZ256rk = 8844,

        VGETEXPPSZ256rkz = 8845,

        VGETEXPPSZm = 8846,

        VGETEXPPSZmb = 8847,

        VGETEXPPSZmbk = 8848,

        VGETEXPPSZmbkz = 8849,

        VGETEXPPSZmk = 8850,

        VGETEXPPSZmkz = 8851,

        VGETEXPPSZr = 8852,

        VGETEXPPSZrb = 8853,

        VGETEXPPSZrbk = 8854,

        VGETEXPPSZrbkz = 8855,

        VGETEXPPSZrk = 8856,

        VGETEXPPSZrkz = 8857,

        VGETEXPSDZm = 8858,

        VGETEXPSDZmk = 8859,

        VGETEXPSDZmkz = 8860,

        VGETEXPSDZr = 8861,

        VGETEXPSDZrb = 8862,

        VGETEXPSDZrbk = 8863,

        VGETEXPSDZrbkz = 8864,

        VGETEXPSDZrk = 8865,

        VGETEXPSDZrkz = 8866,

        VGETEXPSHZm = 8867,

        VGETEXPSHZmk = 8868,

        VGETEXPSHZmkz = 8869,

        VGETEXPSHZr = 8870,

        VGETEXPSHZrb = 8871,

        VGETEXPSHZrbk = 8872,

        VGETEXPSHZrbkz = 8873,

        VGETEXPSHZrk = 8874,

        VGETEXPSHZrkz = 8875,

        VGETEXPSSZm = 8876,

        VGETEXPSSZmk = 8877,

        VGETEXPSSZmkz = 8878,

        VGETEXPSSZr = 8879,

        VGETEXPSSZrb = 8880,

        VGETEXPSSZrbk = 8881,

        VGETEXPSSZrbkz = 8882,

        VGETEXPSSZrk = 8883,

        VGETEXPSSZrkz = 8884,

        VGETMANTPDZ128rmbi = 8885,

        VGETMANTPDZ128rmbik = 8886,

        VGETMANTPDZ128rmbikz = 8887,

        VGETMANTPDZ128rmi = 8888,

        VGETMANTPDZ128rmik = 8889,

        VGETMANTPDZ128rmikz = 8890,

        VGETMANTPDZ128rri = 8891,

        VGETMANTPDZ128rrik = 8892,

        VGETMANTPDZ128rrikz = 8893,

        VGETMANTPDZ256rmbi = 8894,

        VGETMANTPDZ256rmbik = 8895,

        VGETMANTPDZ256rmbikz = 8896,

        VGETMANTPDZ256rmi = 8897,

        VGETMANTPDZ256rmik = 8898,

        VGETMANTPDZ256rmikz = 8899,

        VGETMANTPDZ256rri = 8900,

        VGETMANTPDZ256rrik = 8901,

        VGETMANTPDZ256rrikz = 8902,

        VGETMANTPDZrmbi = 8903,

        VGETMANTPDZrmbik = 8904,

        VGETMANTPDZrmbikz = 8905,

        VGETMANTPDZrmi = 8906,

        VGETMANTPDZrmik = 8907,

        VGETMANTPDZrmikz = 8908,

        VGETMANTPDZrri = 8909,

        VGETMANTPDZrrib = 8910,

        VGETMANTPDZrribk = 8911,

        VGETMANTPDZrribkz = 8912,

        VGETMANTPDZrrik = 8913,

        VGETMANTPDZrrikz = 8914,

        VGETMANTPHZ128rmbi = 8915,

        VGETMANTPHZ128rmbik = 8916,

        VGETMANTPHZ128rmbikz = 8917,

        VGETMANTPHZ128rmi = 8918,

        VGETMANTPHZ128rmik = 8919,

        VGETMANTPHZ128rmikz = 8920,

        VGETMANTPHZ128rri = 8921,

        VGETMANTPHZ128rrik = 8922,

        VGETMANTPHZ128rrikz = 8923,

        VGETMANTPHZ256rmbi = 8924,

        VGETMANTPHZ256rmbik = 8925,

        VGETMANTPHZ256rmbikz = 8926,

        VGETMANTPHZ256rmi = 8927,

        VGETMANTPHZ256rmik = 8928,

        VGETMANTPHZ256rmikz = 8929,

        VGETMANTPHZ256rri = 8930,

        VGETMANTPHZ256rrik = 8931,

        VGETMANTPHZ256rrikz = 8932,

        VGETMANTPHZrmbi = 8933,

        VGETMANTPHZrmbik = 8934,

        VGETMANTPHZrmbikz = 8935,

        VGETMANTPHZrmi = 8936,

        VGETMANTPHZrmik = 8937,

        VGETMANTPHZrmikz = 8938,

        VGETMANTPHZrri = 8939,

        VGETMANTPHZrrib = 8940,

        VGETMANTPHZrribk = 8941,

        VGETMANTPHZrribkz = 8942,

        VGETMANTPHZrrik = 8943,

        VGETMANTPHZrrikz = 8944,

        VGETMANTPSZ128rmbi = 8945,

        VGETMANTPSZ128rmbik = 8946,

        VGETMANTPSZ128rmbikz = 8947,

        VGETMANTPSZ128rmi = 8948,

        VGETMANTPSZ128rmik = 8949,

        VGETMANTPSZ128rmikz = 8950,

        VGETMANTPSZ128rri = 8951,

        VGETMANTPSZ128rrik = 8952,

        VGETMANTPSZ128rrikz = 8953,

        VGETMANTPSZ256rmbi = 8954,

        VGETMANTPSZ256rmbik = 8955,

        VGETMANTPSZ256rmbikz = 8956,

        VGETMANTPSZ256rmi = 8957,

        VGETMANTPSZ256rmik = 8958,

        VGETMANTPSZ256rmikz = 8959,

        VGETMANTPSZ256rri = 8960,

        VGETMANTPSZ256rrik = 8961,

        VGETMANTPSZ256rrikz = 8962,

        VGETMANTPSZrmbi = 8963,

        VGETMANTPSZrmbik = 8964,

        VGETMANTPSZrmbikz = 8965,

        VGETMANTPSZrmi = 8966,

        VGETMANTPSZrmik = 8967,

        VGETMANTPSZrmikz = 8968,

        VGETMANTPSZrri = 8969,

        VGETMANTPSZrrib = 8970,

        VGETMANTPSZrribk = 8971,

        VGETMANTPSZrribkz = 8972,

        VGETMANTPSZrrik = 8973,

        VGETMANTPSZrrikz = 8974,

        VGETMANTSDZrmi = 8975,

        VGETMANTSDZrmik = 8976,

        VGETMANTSDZrmikz = 8977,

        VGETMANTSDZrri = 8978,

        VGETMANTSDZrrib = 8979,

        VGETMANTSDZrribk = 8980,

        VGETMANTSDZrribkz = 8981,

        VGETMANTSDZrrik = 8982,

        VGETMANTSDZrrikz = 8983,

        VGETMANTSHZrmi = 8984,

        VGETMANTSHZrmik = 8985,

        VGETMANTSHZrmikz = 8986,

        VGETMANTSHZrri = 8987,

        VGETMANTSHZrrib = 8988,

        VGETMANTSHZrribk = 8989,

        VGETMANTSHZrribkz = 8990,

        VGETMANTSHZrrik = 8991,

        VGETMANTSHZrrikz = 8992,

        VGETMANTSSZrmi = 8993,

        VGETMANTSSZrmik = 8994,

        VGETMANTSSZrmikz = 8995,

        VGETMANTSSZrri = 8996,

        VGETMANTSSZrrib = 8997,

        VGETMANTSSZrribk = 8998,

        VGETMANTSSZrribkz = 8999,

        VGETMANTSSZrrik = 9000,

        VGETMANTSSZrrikz = 9001,

        VGF2P8AFFINEINVQBYrmi = 9002,

        VGF2P8AFFINEINVQBYrri = 9003,

        VGF2P8AFFINEINVQBZ128rmbi = 9004,

        VGF2P8AFFINEINVQBZ128rmbik = 9005,

        VGF2P8AFFINEINVQBZ128rmbikz = 9006,

        VGF2P8AFFINEINVQBZ128rmi = 9007,

        VGF2P8AFFINEINVQBZ128rmik = 9008,

        VGF2P8AFFINEINVQBZ128rmikz = 9009,

        VGF2P8AFFINEINVQBZ128rri = 9010,

        VGF2P8AFFINEINVQBZ128rrik = 9011,

        VGF2P8AFFINEINVQBZ128rrikz = 9012,

        VGF2P8AFFINEINVQBZ256rmbi = 9013,

        VGF2P8AFFINEINVQBZ256rmbik = 9014,

        VGF2P8AFFINEINVQBZ256rmbikz = 9015,

        VGF2P8AFFINEINVQBZ256rmi = 9016,

        VGF2P8AFFINEINVQBZ256rmik = 9017,

        VGF2P8AFFINEINVQBZ256rmikz = 9018,

        VGF2P8AFFINEINVQBZ256rri = 9019,

        VGF2P8AFFINEINVQBZ256rrik = 9020,

        VGF2P8AFFINEINVQBZ256rrikz = 9021,

        VGF2P8AFFINEINVQBZrmbi = 9022,

        VGF2P8AFFINEINVQBZrmbik = 9023,

        VGF2P8AFFINEINVQBZrmbikz = 9024,

        VGF2P8AFFINEINVQBZrmi = 9025,

        VGF2P8AFFINEINVQBZrmik = 9026,

        VGF2P8AFFINEINVQBZrmikz = 9027,

        VGF2P8AFFINEINVQBZrri = 9028,

        VGF2P8AFFINEINVQBZrrik = 9029,

        VGF2P8AFFINEINVQBZrrikz = 9030,

        VGF2P8AFFINEINVQBrmi = 9031,

        VGF2P8AFFINEINVQBrri = 9032,

        VGF2P8AFFINEQBYrmi = 9033,

        VGF2P8AFFINEQBYrri = 9034,

        VGF2P8AFFINEQBZ128rmbi = 9035,

        VGF2P8AFFINEQBZ128rmbik = 9036,

        VGF2P8AFFINEQBZ128rmbikz = 9037,

        VGF2P8AFFINEQBZ128rmi = 9038,

        VGF2P8AFFINEQBZ128rmik = 9039,

        VGF2P8AFFINEQBZ128rmikz = 9040,

        VGF2P8AFFINEQBZ128rri = 9041,

        VGF2P8AFFINEQBZ128rrik = 9042,

        VGF2P8AFFINEQBZ128rrikz = 9043,

        VGF2P8AFFINEQBZ256rmbi = 9044,

        VGF2P8AFFINEQBZ256rmbik = 9045,

        VGF2P8AFFINEQBZ256rmbikz = 9046,

        VGF2P8AFFINEQBZ256rmi = 9047,

        VGF2P8AFFINEQBZ256rmik = 9048,

        VGF2P8AFFINEQBZ256rmikz = 9049,

        VGF2P8AFFINEQBZ256rri = 9050,

        VGF2P8AFFINEQBZ256rrik = 9051,

        VGF2P8AFFINEQBZ256rrikz = 9052,

        VGF2P8AFFINEQBZrmbi = 9053,

        VGF2P8AFFINEQBZrmbik = 9054,

        VGF2P8AFFINEQBZrmbikz = 9055,

        VGF2P8AFFINEQBZrmi = 9056,

        VGF2P8AFFINEQBZrmik = 9057,

        VGF2P8AFFINEQBZrmikz = 9058,

        VGF2P8AFFINEQBZrri = 9059,

        VGF2P8AFFINEQBZrrik = 9060,

        VGF2P8AFFINEQBZrrikz = 9061,

        VGF2P8AFFINEQBrmi = 9062,

        VGF2P8AFFINEQBrri = 9063,

        VGF2P8MULBYrm = 9064,

        VGF2P8MULBYrr = 9065,

        VGF2P8MULBZ128rm = 9066,

        VGF2P8MULBZ128rmk = 9067,

        VGF2P8MULBZ128rmkz = 9068,

        VGF2P8MULBZ128rr = 9069,

        VGF2P8MULBZ128rrk = 9070,

        VGF2P8MULBZ128rrkz = 9071,

        VGF2P8MULBZ256rm = 9072,

        VGF2P8MULBZ256rmk = 9073,

        VGF2P8MULBZ256rmkz = 9074,

        VGF2P8MULBZ256rr = 9075,

        VGF2P8MULBZ256rrk = 9076,

        VGF2P8MULBZ256rrkz = 9077,

        VGF2P8MULBZrm = 9078,

        VGF2P8MULBZrmk = 9079,

        VGF2P8MULBZrmkz = 9080,

        VGF2P8MULBZrr = 9081,

        VGF2P8MULBZrrk = 9082,

        VGF2P8MULBZrrkz = 9083,

        VGF2P8MULBrm = 9084,

        VGF2P8MULBrr = 9085,

        VHADDPDYrm = 9086,

        VHADDPDYrr = 9087,

        VHADDPDrm = 9088,

        VHADDPDrr = 9089,

        VHADDPSYrm = 9090,

        VHADDPSYrr = 9091,

        VHADDPSrm = 9092,

        VHADDPSrr = 9093,

        VHSUBPDYrm = 9094,

        VHSUBPDYrr = 9095,

        VHSUBPDrm = 9096,

        VHSUBPDrr = 9097,

        VHSUBPSYrm = 9098,

        VHSUBPSYrr = 9099,

        VHSUBPSrm = 9100,

        VHSUBPSrr = 9101,

        VINSERTF128rm = 9102,

        VINSERTF128rr = 9103,

        VINSERTF32x4Z256rm = 9104,

        VINSERTF32x4Z256rmk = 9105,

        VINSERTF32x4Z256rmkz = 9106,

        VINSERTF32x4Z256rr = 9107,

        VINSERTF32x4Z256rrk = 9108,

        VINSERTF32x4Z256rrkz = 9109,

        VINSERTF32x4Zrm = 9110,

        VINSERTF32x4Zrmk = 9111,

        VINSERTF32x4Zrmkz = 9112,

        VINSERTF32x4Zrr = 9113,

        VINSERTF32x4Zrrk = 9114,

        VINSERTF32x4Zrrkz = 9115,

        VINSERTF32x8Zrm = 9116,

        VINSERTF32x8Zrmk = 9117,

        VINSERTF32x8Zrmkz = 9118,

        VINSERTF32x8Zrr = 9119,

        VINSERTF32x8Zrrk = 9120,

        VINSERTF32x8Zrrkz = 9121,

        VINSERTF64x2Z256rm = 9122,

        VINSERTF64x2Z256rmk = 9123,

        VINSERTF64x2Z256rmkz = 9124,

        VINSERTF64x2Z256rr = 9125,

        VINSERTF64x2Z256rrk = 9126,

        VINSERTF64x2Z256rrkz = 9127,

        VINSERTF64x2Zrm = 9128,

        VINSERTF64x2Zrmk = 9129,

        VINSERTF64x2Zrmkz = 9130,

        VINSERTF64x2Zrr = 9131,

        VINSERTF64x2Zrrk = 9132,

        VINSERTF64x2Zrrkz = 9133,

        VINSERTF64x4Zrm = 9134,

        VINSERTF64x4Zrmk = 9135,

        VINSERTF64x4Zrmkz = 9136,

        VINSERTF64x4Zrr = 9137,

        VINSERTF64x4Zrrk = 9138,

        VINSERTF64x4Zrrkz = 9139,

        VINSERTI128rm = 9140,

        VINSERTI128rr = 9141,

        VINSERTI32x4Z256rm = 9142,

        VINSERTI32x4Z256rmk = 9143,

        VINSERTI32x4Z256rmkz = 9144,

        VINSERTI32x4Z256rr = 9145,

        VINSERTI32x4Z256rrk = 9146,

        VINSERTI32x4Z256rrkz = 9147,

        VINSERTI32x4Zrm = 9148,

        VINSERTI32x4Zrmk = 9149,

        VINSERTI32x4Zrmkz = 9150,

        VINSERTI32x4Zrr = 9151,

        VINSERTI32x4Zrrk = 9152,

        VINSERTI32x4Zrrkz = 9153,

        VINSERTI32x8Zrm = 9154,

        VINSERTI32x8Zrmk = 9155,

        VINSERTI32x8Zrmkz = 9156,

        VINSERTI32x8Zrr = 9157,

        VINSERTI32x8Zrrk = 9158,

        VINSERTI32x8Zrrkz = 9159,

        VINSERTI64x2Z256rm = 9160,

        VINSERTI64x2Z256rmk = 9161,

        VINSERTI64x2Z256rmkz = 9162,

        VINSERTI64x2Z256rr = 9163,

        VINSERTI64x2Z256rrk = 9164,

        VINSERTI64x2Z256rrkz = 9165,

        VINSERTI64x2Zrm = 9166,

        VINSERTI64x2Zrmk = 9167,

        VINSERTI64x2Zrmkz = 9168,

        VINSERTI64x2Zrr = 9169,

        VINSERTI64x2Zrrk = 9170,

        VINSERTI64x2Zrrkz = 9171,

        VINSERTI64x4Zrm = 9172,

        VINSERTI64x4Zrmk = 9173,

        VINSERTI64x4Zrmkz = 9174,

        VINSERTI64x4Zrr = 9175,

        VINSERTI64x4Zrrk = 9176,

        VINSERTI64x4Zrrkz = 9177,

        VINSERTPSZrm = 9178,

        VINSERTPSZrr = 9179,

        VINSERTPSrm = 9180,

        VINSERTPSrr = 9181,

        VLDDQUYrm = 9182,

        VLDDQUrm = 9183,

        VLDMXCSR = 9184,

        VMASKMOVDQU = 9185,

        VMASKMOVDQU64 = 9186,

        VMASKMOVDQUX32 = 9187,

        VMASKMOVPDYmr = 9188,

        VMASKMOVPDYrm = 9189,

        VMASKMOVPDmr = 9190,

        VMASKMOVPDrm = 9191,

        VMASKMOVPSYmr = 9192,

        VMASKMOVPSYrm = 9193,

        VMASKMOVPSmr = 9194,

        VMASKMOVPSrm = 9195,

        VMAXCPDYrm = 9196,

        VMAXCPDYrr = 9197,

        VMAXCPDZ128rm = 9198,

        VMAXCPDZ128rmb = 9199,

        VMAXCPDZ128rmbk = 9200,

        VMAXCPDZ128rmbkz = 9201,

        VMAXCPDZ128rmk = 9202,

        VMAXCPDZ128rmkz = 9203,

        VMAXCPDZ128rr = 9204,

        VMAXCPDZ128rrk = 9205,

        VMAXCPDZ128rrkz = 9206,

        VMAXCPDZ256rm = 9207,

        VMAXCPDZ256rmb = 9208,

        VMAXCPDZ256rmbk = 9209,

        VMAXCPDZ256rmbkz = 9210,

        VMAXCPDZ256rmk = 9211,

        VMAXCPDZ256rmkz = 9212,

        VMAXCPDZ256rr = 9213,

        VMAXCPDZ256rrk = 9214,

        VMAXCPDZ256rrkz = 9215,

        VMAXCPDZrm = 9216,

        VMAXCPDZrmb = 9217,

        VMAXCPDZrmbk = 9218,

        VMAXCPDZrmbkz = 9219,

        VMAXCPDZrmk = 9220,

        VMAXCPDZrmkz = 9221,

        VMAXCPDZrr = 9222,

        VMAXCPDZrrk = 9223,

        VMAXCPDZrrkz = 9224,

        VMAXCPDrm = 9225,

        VMAXCPDrr = 9226,

        VMAXCPHZ128rm = 9227,

        VMAXCPHZ128rmb = 9228,

        VMAXCPHZ128rmbk = 9229,

        VMAXCPHZ128rmbkz = 9230,

        VMAXCPHZ128rmk = 9231,

        VMAXCPHZ128rmkz = 9232,

        VMAXCPHZ128rr = 9233,

        VMAXCPHZ128rrk = 9234,

        VMAXCPHZ128rrkz = 9235,

        VMAXCPHZ256rm = 9236,

        VMAXCPHZ256rmb = 9237,

        VMAXCPHZ256rmbk = 9238,

        VMAXCPHZ256rmbkz = 9239,

        VMAXCPHZ256rmk = 9240,

        VMAXCPHZ256rmkz = 9241,

        VMAXCPHZ256rr = 9242,

        VMAXCPHZ256rrk = 9243,

        VMAXCPHZ256rrkz = 9244,

        VMAXCPHZrm = 9245,

        VMAXCPHZrmb = 9246,

        VMAXCPHZrmbk = 9247,

        VMAXCPHZrmbkz = 9248,

        VMAXCPHZrmk = 9249,

        VMAXCPHZrmkz = 9250,

        VMAXCPHZrr = 9251,

        VMAXCPHZrrk = 9252,

        VMAXCPHZrrkz = 9253,

        VMAXCPSYrm = 9254,

        VMAXCPSYrr = 9255,

        VMAXCPSZ128rm = 9256,

        VMAXCPSZ128rmb = 9257,

        VMAXCPSZ128rmbk = 9258,

        VMAXCPSZ128rmbkz = 9259,

        VMAXCPSZ128rmk = 9260,

        VMAXCPSZ128rmkz = 9261,

        VMAXCPSZ128rr = 9262,

        VMAXCPSZ128rrk = 9263,

        VMAXCPSZ128rrkz = 9264,

        VMAXCPSZ256rm = 9265,

        VMAXCPSZ256rmb = 9266,

        VMAXCPSZ256rmbk = 9267,

        VMAXCPSZ256rmbkz = 9268,

        VMAXCPSZ256rmk = 9269,

        VMAXCPSZ256rmkz = 9270,

        VMAXCPSZ256rr = 9271,

        VMAXCPSZ256rrk = 9272,

        VMAXCPSZ256rrkz = 9273,

        VMAXCPSZrm = 9274,

        VMAXCPSZrmb = 9275,

        VMAXCPSZrmbk = 9276,

        VMAXCPSZrmbkz = 9277,

        VMAXCPSZrmk = 9278,

        VMAXCPSZrmkz = 9279,

        VMAXCPSZrr = 9280,

        VMAXCPSZrrk = 9281,

        VMAXCPSZrrkz = 9282,

        VMAXCPSrm = 9283,

        VMAXCPSrr = 9284,

        VMAXCSDZrm = 9285,

        VMAXCSDZrr = 9286,

        VMAXCSDrm = 9287,

        VMAXCSDrr = 9288,

        VMAXCSHZrm = 9289,

        VMAXCSHZrr = 9290,

        VMAXCSSZrm = 9291,

        VMAXCSSZrr = 9292,

        VMAXCSSrm = 9293,

        VMAXCSSrr = 9294,

        VMAXPDYrm = 9295,

        VMAXPDYrr = 9296,

        VMAXPDZ128rm = 9297,

        VMAXPDZ128rmb = 9298,

        VMAXPDZ128rmbk = 9299,

        VMAXPDZ128rmbkz = 9300,

        VMAXPDZ128rmk = 9301,

        VMAXPDZ128rmkz = 9302,

        VMAXPDZ128rr = 9303,

        VMAXPDZ128rrk = 9304,

        VMAXPDZ128rrkz = 9305,

        VMAXPDZ256rm = 9306,

        VMAXPDZ256rmb = 9307,

        VMAXPDZ256rmbk = 9308,

        VMAXPDZ256rmbkz = 9309,

        VMAXPDZ256rmk = 9310,

        VMAXPDZ256rmkz = 9311,

        VMAXPDZ256rr = 9312,

        VMAXPDZ256rrk = 9313,

        VMAXPDZ256rrkz = 9314,

        VMAXPDZrm = 9315,

        VMAXPDZrmb = 9316,

        VMAXPDZrmbk = 9317,

        VMAXPDZrmbkz = 9318,

        VMAXPDZrmk = 9319,

        VMAXPDZrmkz = 9320,

        VMAXPDZrr = 9321,

        VMAXPDZrrb = 9322,

        VMAXPDZrrbk = 9323,

        VMAXPDZrrbkz = 9324,

        VMAXPDZrrk = 9325,

        VMAXPDZrrkz = 9326,

        VMAXPDrm = 9327,

        VMAXPDrr = 9328,

        VMAXPHZ128rm = 9329,

        VMAXPHZ128rmb = 9330,

        VMAXPHZ128rmbk = 9331,

        VMAXPHZ128rmbkz = 9332,

        VMAXPHZ128rmk = 9333,

        VMAXPHZ128rmkz = 9334,

        VMAXPHZ128rr = 9335,

        VMAXPHZ128rrk = 9336,

        VMAXPHZ128rrkz = 9337,

        VMAXPHZ256rm = 9338,

        VMAXPHZ256rmb = 9339,

        VMAXPHZ256rmbk = 9340,

        VMAXPHZ256rmbkz = 9341,

        VMAXPHZ256rmk = 9342,

        VMAXPHZ256rmkz = 9343,

        VMAXPHZ256rr = 9344,

        VMAXPHZ256rrk = 9345,

        VMAXPHZ256rrkz = 9346,

        VMAXPHZrm = 9347,

        VMAXPHZrmb = 9348,

        VMAXPHZrmbk = 9349,

        VMAXPHZrmbkz = 9350,

        VMAXPHZrmk = 9351,

        VMAXPHZrmkz = 9352,

        VMAXPHZrr = 9353,

        VMAXPHZrrb = 9354,

        VMAXPHZrrbk = 9355,

        VMAXPHZrrbkz = 9356,

        VMAXPHZrrk = 9357,

        VMAXPHZrrkz = 9358,

        VMAXPSYrm = 9359,

        VMAXPSYrr = 9360,

        VMAXPSZ128rm = 9361,

        VMAXPSZ128rmb = 9362,

        VMAXPSZ128rmbk = 9363,

        VMAXPSZ128rmbkz = 9364,

        VMAXPSZ128rmk = 9365,

        VMAXPSZ128rmkz = 9366,

        VMAXPSZ128rr = 9367,

        VMAXPSZ128rrk = 9368,

        VMAXPSZ128rrkz = 9369,

        VMAXPSZ256rm = 9370,

        VMAXPSZ256rmb = 9371,

        VMAXPSZ256rmbk = 9372,

        VMAXPSZ256rmbkz = 9373,

        VMAXPSZ256rmk = 9374,

        VMAXPSZ256rmkz = 9375,

        VMAXPSZ256rr = 9376,

        VMAXPSZ256rrk = 9377,

        VMAXPSZ256rrkz = 9378,

        VMAXPSZrm = 9379,

        VMAXPSZrmb = 9380,

        VMAXPSZrmbk = 9381,

        VMAXPSZrmbkz = 9382,

        VMAXPSZrmk = 9383,

        VMAXPSZrmkz = 9384,

        VMAXPSZrr = 9385,

        VMAXPSZrrb = 9386,

        VMAXPSZrrbk = 9387,

        VMAXPSZrrbkz = 9388,

        VMAXPSZrrk = 9389,

        VMAXPSZrrkz = 9390,

        VMAXPSrm = 9391,

        VMAXPSrr = 9392,

        VMAXSDZrm = 9393,

        VMAXSDZrm_Int = 9394,

        VMAXSDZrm_Intk = 9395,

        VMAXSDZrm_Intkz = 9396,

        VMAXSDZrr = 9397,

        VMAXSDZrr_Int = 9398,

        VMAXSDZrr_Intk = 9399,

        VMAXSDZrr_Intkz = 9400,

        VMAXSDZrrb_Int = 9401,

        VMAXSDZrrb_Intk = 9402,

        VMAXSDZrrb_Intkz = 9403,

        VMAXSDrm = 9404,

        VMAXSDrm_Int = 9405,

        VMAXSDrr = 9406,

        VMAXSDrr_Int = 9407,

        VMAXSHZrm = 9408,

        VMAXSHZrm_Int = 9409,

        VMAXSHZrm_Intk = 9410,

        VMAXSHZrm_Intkz = 9411,

        VMAXSHZrr = 9412,

        VMAXSHZrr_Int = 9413,

        VMAXSHZrr_Intk = 9414,

        VMAXSHZrr_Intkz = 9415,

        VMAXSHZrrb_Int = 9416,

        VMAXSHZrrb_Intk = 9417,

        VMAXSHZrrb_Intkz = 9418,

        VMAXSSZrm = 9419,

        VMAXSSZrm_Int = 9420,

        VMAXSSZrm_Intk = 9421,

        VMAXSSZrm_Intkz = 9422,

        VMAXSSZrr = 9423,

        VMAXSSZrr_Int = 9424,

        VMAXSSZrr_Intk = 9425,

        VMAXSSZrr_Intkz = 9426,

        VMAXSSZrrb_Int = 9427,

        VMAXSSZrrb_Intk = 9428,

        VMAXSSZrrb_Intkz = 9429,

        VMAXSSrm = 9430,

        VMAXSSrm_Int = 9431,

        VMAXSSrr = 9432,

        VMAXSSrr_Int = 9433,

        VMCALL = 9434,

        VMCLEARm = 9435,

        VMFUNC = 9436,

        VMINCPDYrm = 9437,

        VMINCPDYrr = 9438,

        VMINCPDZ128rm = 9439,

        VMINCPDZ128rmb = 9440,

        VMINCPDZ128rmbk = 9441,

        VMINCPDZ128rmbkz = 9442,

        VMINCPDZ128rmk = 9443,

        VMINCPDZ128rmkz = 9444,

        VMINCPDZ128rr = 9445,

        VMINCPDZ128rrk = 9446,

        VMINCPDZ128rrkz = 9447,

        VMINCPDZ256rm = 9448,

        VMINCPDZ256rmb = 9449,

        VMINCPDZ256rmbk = 9450,

        VMINCPDZ256rmbkz = 9451,

        VMINCPDZ256rmk = 9452,

        VMINCPDZ256rmkz = 9453,

        VMINCPDZ256rr = 9454,

        VMINCPDZ256rrk = 9455,

        VMINCPDZ256rrkz = 9456,

        VMINCPDZrm = 9457,

        VMINCPDZrmb = 9458,

        VMINCPDZrmbk = 9459,

        VMINCPDZrmbkz = 9460,

        VMINCPDZrmk = 9461,

        VMINCPDZrmkz = 9462,

        VMINCPDZrr = 9463,

        VMINCPDZrrk = 9464,

        VMINCPDZrrkz = 9465,

        VMINCPDrm = 9466,

        VMINCPDrr = 9467,

        VMINCPHZ128rm = 9468,

        VMINCPHZ128rmb = 9469,

        VMINCPHZ128rmbk = 9470,

        VMINCPHZ128rmbkz = 9471,

        VMINCPHZ128rmk = 9472,

        VMINCPHZ128rmkz = 9473,

        VMINCPHZ128rr = 9474,

        VMINCPHZ128rrk = 9475,

        VMINCPHZ128rrkz = 9476,

        VMINCPHZ256rm = 9477,

        VMINCPHZ256rmb = 9478,

        VMINCPHZ256rmbk = 9479,

        VMINCPHZ256rmbkz = 9480,

        VMINCPHZ256rmk = 9481,

        VMINCPHZ256rmkz = 9482,

        VMINCPHZ256rr = 9483,

        VMINCPHZ256rrk = 9484,

        VMINCPHZ256rrkz = 9485,

        VMINCPHZrm = 9486,

        VMINCPHZrmb = 9487,

        VMINCPHZrmbk = 9488,

        VMINCPHZrmbkz = 9489,

        VMINCPHZrmk = 9490,

        VMINCPHZrmkz = 9491,

        VMINCPHZrr = 9492,

        VMINCPHZrrk = 9493,

        VMINCPHZrrkz = 9494,

        VMINCPSYrm = 9495,

        VMINCPSYrr = 9496,

        VMINCPSZ128rm = 9497,

        VMINCPSZ128rmb = 9498,

        VMINCPSZ128rmbk = 9499,

        VMINCPSZ128rmbkz = 9500,

        VMINCPSZ128rmk = 9501,

        VMINCPSZ128rmkz = 9502,

        VMINCPSZ128rr = 9503,

        VMINCPSZ128rrk = 9504,

        VMINCPSZ128rrkz = 9505,

        VMINCPSZ256rm = 9506,

        VMINCPSZ256rmb = 9507,

        VMINCPSZ256rmbk = 9508,

        VMINCPSZ256rmbkz = 9509,

        VMINCPSZ256rmk = 9510,

        VMINCPSZ256rmkz = 9511,

        VMINCPSZ256rr = 9512,

        VMINCPSZ256rrk = 9513,

        VMINCPSZ256rrkz = 9514,

        VMINCPSZrm = 9515,

        VMINCPSZrmb = 9516,

        VMINCPSZrmbk = 9517,

        VMINCPSZrmbkz = 9518,

        VMINCPSZrmk = 9519,

        VMINCPSZrmkz = 9520,

        VMINCPSZrr = 9521,

        VMINCPSZrrk = 9522,

        VMINCPSZrrkz = 9523,

        VMINCPSrm = 9524,

        VMINCPSrr = 9525,

        VMINCSDZrm = 9526,

        VMINCSDZrr = 9527,

        VMINCSDrm = 9528,

        VMINCSDrr = 9529,

        VMINCSHZrm = 9530,

        VMINCSHZrr = 9531,

        VMINCSSZrm = 9532,

        VMINCSSZrr = 9533,

        VMINCSSrm = 9534,

        VMINCSSrr = 9535,

        VMINPDYrm = 9536,

        VMINPDYrr = 9537,

        VMINPDZ128rm = 9538,

        VMINPDZ128rmb = 9539,

        VMINPDZ128rmbk = 9540,

        VMINPDZ128rmbkz = 9541,

        VMINPDZ128rmk = 9542,

        VMINPDZ128rmkz = 9543,

        VMINPDZ128rr = 9544,

        VMINPDZ128rrk = 9545,

        VMINPDZ128rrkz = 9546,

        VMINPDZ256rm = 9547,

        VMINPDZ256rmb = 9548,

        VMINPDZ256rmbk = 9549,

        VMINPDZ256rmbkz = 9550,

        VMINPDZ256rmk = 9551,

        VMINPDZ256rmkz = 9552,

        VMINPDZ256rr = 9553,

        VMINPDZ256rrk = 9554,

        VMINPDZ256rrkz = 9555,

        VMINPDZrm = 9556,

        VMINPDZrmb = 9557,

        VMINPDZrmbk = 9558,

        VMINPDZrmbkz = 9559,

        VMINPDZrmk = 9560,

        VMINPDZrmkz = 9561,

        VMINPDZrr = 9562,

        VMINPDZrrb = 9563,

        VMINPDZrrbk = 9564,

        VMINPDZrrbkz = 9565,

        VMINPDZrrk = 9566,

        VMINPDZrrkz = 9567,

        VMINPDrm = 9568,

        VMINPDrr = 9569,

        VMINPHZ128rm = 9570,

        VMINPHZ128rmb = 9571,

        VMINPHZ128rmbk = 9572,

        VMINPHZ128rmbkz = 9573,

        VMINPHZ128rmk = 9574,

        VMINPHZ128rmkz = 9575,

        VMINPHZ128rr = 9576,

        VMINPHZ128rrk = 9577,

        VMINPHZ128rrkz = 9578,

        VMINPHZ256rm = 9579,

        VMINPHZ256rmb = 9580,

        VMINPHZ256rmbk = 9581,

        VMINPHZ256rmbkz = 9582,

        VMINPHZ256rmk = 9583,

        VMINPHZ256rmkz = 9584,

        VMINPHZ256rr = 9585,

        VMINPHZ256rrk = 9586,

        VMINPHZ256rrkz = 9587,

        VMINPHZrm = 9588,

        VMINPHZrmb = 9589,

        VMINPHZrmbk = 9590,

        VMINPHZrmbkz = 9591,

        VMINPHZrmk = 9592,

        VMINPHZrmkz = 9593,

        VMINPHZrr = 9594,

        VMINPHZrrb = 9595,

        VMINPHZrrbk = 9596,

        VMINPHZrrbkz = 9597,

        VMINPHZrrk = 9598,

        VMINPHZrrkz = 9599,

        VMINPSYrm = 9600,

        VMINPSYrr = 9601,

        VMINPSZ128rm = 9602,

        VMINPSZ128rmb = 9603,

        VMINPSZ128rmbk = 9604,

        VMINPSZ128rmbkz = 9605,

        VMINPSZ128rmk = 9606,

        VMINPSZ128rmkz = 9607,

        VMINPSZ128rr = 9608,

        VMINPSZ128rrk = 9609,

        VMINPSZ128rrkz = 9610,

        VMINPSZ256rm = 9611,

        VMINPSZ256rmb = 9612,

        VMINPSZ256rmbk = 9613,

        VMINPSZ256rmbkz = 9614,

        VMINPSZ256rmk = 9615,

        VMINPSZ256rmkz = 9616,

        VMINPSZ256rr = 9617,

        VMINPSZ256rrk = 9618,

        VMINPSZ256rrkz = 9619,

        VMINPSZrm = 9620,

        VMINPSZrmb = 9621,

        VMINPSZrmbk = 9622,

        VMINPSZrmbkz = 9623,

        VMINPSZrmk = 9624,

        VMINPSZrmkz = 9625,

        VMINPSZrr = 9626,

        VMINPSZrrb = 9627,

        VMINPSZrrbk = 9628,

        VMINPSZrrbkz = 9629,

        VMINPSZrrk = 9630,

        VMINPSZrrkz = 9631,

        VMINPSrm = 9632,

        VMINPSrr = 9633,

        VMINSDZrm = 9634,

        VMINSDZrm_Int = 9635,

        VMINSDZrm_Intk = 9636,

        VMINSDZrm_Intkz = 9637,

        VMINSDZrr = 9638,

        VMINSDZrr_Int = 9639,

        VMINSDZrr_Intk = 9640,

        VMINSDZrr_Intkz = 9641,

        VMINSDZrrb_Int = 9642,

        VMINSDZrrb_Intk = 9643,

        VMINSDZrrb_Intkz = 9644,

        VMINSDrm = 9645,

        VMINSDrm_Int = 9646,

        VMINSDrr = 9647,

        VMINSDrr_Int = 9648,

        VMINSHZrm = 9649,

        VMINSHZrm_Int = 9650,

        VMINSHZrm_Intk = 9651,

        VMINSHZrm_Intkz = 9652,

        VMINSHZrr = 9653,

        VMINSHZrr_Int = 9654,

        VMINSHZrr_Intk = 9655,

        VMINSHZrr_Intkz = 9656,

        VMINSHZrrb_Int = 9657,

        VMINSHZrrb_Intk = 9658,

        VMINSHZrrb_Intkz = 9659,

        VMINSSZrm = 9660,

        VMINSSZrm_Int = 9661,

        VMINSSZrm_Intk = 9662,

        VMINSSZrm_Intkz = 9663,

        VMINSSZrr = 9664,

        VMINSSZrr_Int = 9665,

        VMINSSZrr_Intk = 9666,

        VMINSSZrr_Intkz = 9667,

        VMINSSZrrb_Int = 9668,

        VMINSSZrrb_Intk = 9669,

        VMINSSZrrb_Intkz = 9670,

        VMINSSrm = 9671,

        VMINSSrm_Int = 9672,

        VMINSSrr = 9673,

        VMINSSrr_Int = 9674,

        VMLAUNCH = 9675,

        VMLOAD32 = 9676,

        VMLOAD64 = 9677,

        VMMCALL = 9678,

        VMOV64toPQIZrm = 9679,

        VMOV64toPQIZrr = 9680,

        VMOV64toPQIrm = 9681,

        VMOV64toPQIrr = 9682,

        VMOV64toSDZrr = 9683,

        VMOV64toSDrr = 9684,

        VMOVAPDYmr = 9685,

        VMOVAPDYrm = 9686,

        VMOVAPDYrr = 9687,

        VMOVAPDYrr_REV = 9688,

        VMOVAPDZ128mr = 9689,

        VMOVAPDZ128mrk = 9690,

        VMOVAPDZ128rm = 9691,

        VMOVAPDZ128rmk = 9692,

        VMOVAPDZ128rmkz = 9693,

        VMOVAPDZ128rr = 9694,

        VMOVAPDZ128rr_REV = 9695,

        VMOVAPDZ128rrk = 9696,

        VMOVAPDZ128rrk_REV = 9697,

        VMOVAPDZ128rrkz = 9698,

        VMOVAPDZ128rrkz_REV = 9699,

        VMOVAPDZ256mr = 9700,

        VMOVAPDZ256mrk = 9701,

        VMOVAPDZ256rm = 9702,

        VMOVAPDZ256rmk = 9703,

        VMOVAPDZ256rmkz = 9704,

        VMOVAPDZ256rr = 9705,

        VMOVAPDZ256rr_REV = 9706,

        VMOVAPDZ256rrk = 9707,

        VMOVAPDZ256rrk_REV = 9708,

        VMOVAPDZ256rrkz = 9709,

        VMOVAPDZ256rrkz_REV = 9710,

        VMOVAPDZmr = 9711,

        VMOVAPDZmrk = 9712,

        VMOVAPDZrm = 9713,

        VMOVAPDZrmk = 9714,

        VMOVAPDZrmkz = 9715,

        VMOVAPDZrr = 9716,

        VMOVAPDZrr_REV = 9717,

        VMOVAPDZrrk = 9718,

        VMOVAPDZrrk_REV = 9719,

        VMOVAPDZrrkz = 9720,

        VMOVAPDZrrkz_REV = 9721,

        VMOVAPDmr = 9722,

        VMOVAPDrm = 9723,

        VMOVAPDrr = 9724,

        VMOVAPDrr_REV = 9725,

        VMOVAPSYmr = 9726,

        VMOVAPSYrm = 9727,

        VMOVAPSYrr = 9728,

        VMOVAPSYrr_REV = 9729,

        VMOVAPSZ128mr = 9730,

        VMOVAPSZ128mrk = 9731,

        VMOVAPSZ128rm = 9732,

        VMOVAPSZ128rmk = 9733,

        VMOVAPSZ128rmkz = 9734,

        VMOVAPSZ128rr = 9735,

        VMOVAPSZ128rr_REV = 9736,

        VMOVAPSZ128rrk = 9737,

        VMOVAPSZ128rrk_REV = 9738,

        VMOVAPSZ128rrkz = 9739,

        VMOVAPSZ128rrkz_REV = 9740,

        VMOVAPSZ256mr = 9741,

        VMOVAPSZ256mrk = 9742,

        VMOVAPSZ256rm = 9743,

        VMOVAPSZ256rmk = 9744,

        VMOVAPSZ256rmkz = 9745,

        VMOVAPSZ256rr = 9746,

        VMOVAPSZ256rr_REV = 9747,

        VMOVAPSZ256rrk = 9748,

        VMOVAPSZ256rrk_REV = 9749,

        VMOVAPSZ256rrkz = 9750,

        VMOVAPSZ256rrkz_REV = 9751,

        VMOVAPSZmr = 9752,

        VMOVAPSZmrk = 9753,

        VMOVAPSZrm = 9754,

        VMOVAPSZrmk = 9755,

        VMOVAPSZrmkz = 9756,

        VMOVAPSZrr = 9757,

        VMOVAPSZrr_REV = 9758,

        VMOVAPSZrrk = 9759,

        VMOVAPSZrrk_REV = 9760,

        VMOVAPSZrrkz = 9761,

        VMOVAPSZrrkz_REV = 9762,

        VMOVAPSmr = 9763,

        VMOVAPSrm = 9764,

        VMOVAPSrr = 9765,

        VMOVAPSrr_REV = 9766,

        VMOVDDUPYrm = 9767,

        VMOVDDUPYrr = 9768,

        VMOVDDUPZ128rm = 9769,

        VMOVDDUPZ128rmk = 9770,

        VMOVDDUPZ128rmkz = 9771,

        VMOVDDUPZ128rr = 9772,

        VMOVDDUPZ128rrk = 9773,

        VMOVDDUPZ128rrkz = 9774,

        VMOVDDUPZ256rm = 9775,

        VMOVDDUPZ256rmk = 9776,

        VMOVDDUPZ256rmkz = 9777,

        VMOVDDUPZ256rr = 9778,

        VMOVDDUPZ256rrk = 9779,

        VMOVDDUPZ256rrkz = 9780,

        VMOVDDUPZrm = 9781,

        VMOVDDUPZrmk = 9782,

        VMOVDDUPZrmkz = 9783,

        VMOVDDUPZrr = 9784,

        VMOVDDUPZrrk = 9785,

        VMOVDDUPZrrkz = 9786,

        VMOVDDUPrm = 9787,

        VMOVDDUPrr = 9788,

        VMOVDI2PDIZrm = 9789,

        VMOVDI2PDIZrr = 9790,

        VMOVDI2PDIrm = 9791,

        VMOVDI2PDIrr = 9792,

        VMOVDI2SSZrr = 9793,

        VMOVDI2SSrr = 9794,

        VMOVDQA32Z128mr = 9795,

        VMOVDQA32Z128mrk = 9796,

        VMOVDQA32Z128rm = 9797,

        VMOVDQA32Z128rmk = 9798,

        VMOVDQA32Z128rmkz = 9799,

        VMOVDQA32Z128rr = 9800,

        VMOVDQA32Z128rr_REV = 9801,

        VMOVDQA32Z128rrk = 9802,

        VMOVDQA32Z128rrk_REV = 9803,

        VMOVDQA32Z128rrkz = 9804,

        VMOVDQA32Z128rrkz_REV = 9805,

        VMOVDQA32Z256mr = 9806,

        VMOVDQA32Z256mrk = 9807,

        VMOVDQA32Z256rm = 9808,

        VMOVDQA32Z256rmk = 9809,

        VMOVDQA32Z256rmkz = 9810,

        VMOVDQA32Z256rr = 9811,

        VMOVDQA32Z256rr_REV = 9812,

        VMOVDQA32Z256rrk = 9813,

        VMOVDQA32Z256rrk_REV = 9814,

        VMOVDQA32Z256rrkz = 9815,

        VMOVDQA32Z256rrkz_REV = 9816,

        VMOVDQA32Zmr = 9817,

        VMOVDQA32Zmrk = 9818,

        VMOVDQA32Zrm = 9819,

        VMOVDQA32Zrmk = 9820,

        VMOVDQA32Zrmkz = 9821,

        VMOVDQA32Zrr = 9822,

        VMOVDQA32Zrr_REV = 9823,

        VMOVDQA32Zrrk = 9824,

        VMOVDQA32Zrrk_REV = 9825,

        VMOVDQA32Zrrkz = 9826,

        VMOVDQA32Zrrkz_REV = 9827,

        VMOVDQA64Z128mr = 9828,

        VMOVDQA64Z128mrk = 9829,

        VMOVDQA64Z128rm = 9830,

        VMOVDQA64Z128rmk = 9831,

        VMOVDQA64Z128rmkz = 9832,

        VMOVDQA64Z128rr = 9833,

        VMOVDQA64Z128rr_REV = 9834,

        VMOVDQA64Z128rrk = 9835,

        VMOVDQA64Z128rrk_REV = 9836,

        VMOVDQA64Z128rrkz = 9837,

        VMOVDQA64Z128rrkz_REV = 9838,

        VMOVDQA64Z256mr = 9839,

        VMOVDQA64Z256mrk = 9840,

        VMOVDQA64Z256rm = 9841,

        VMOVDQA64Z256rmk = 9842,

        VMOVDQA64Z256rmkz = 9843,

        VMOVDQA64Z256rr = 9844,

        VMOVDQA64Z256rr_REV = 9845,

        VMOVDQA64Z256rrk = 9846,

        VMOVDQA64Z256rrk_REV = 9847,

        VMOVDQA64Z256rrkz = 9848,

        VMOVDQA64Z256rrkz_REV = 9849,

        VMOVDQA64Zmr = 9850,

        VMOVDQA64Zmrk = 9851,

        VMOVDQA64Zrm = 9852,

        VMOVDQA64Zrmk = 9853,

        VMOVDQA64Zrmkz = 9854,

        VMOVDQA64Zrr = 9855,

        VMOVDQA64Zrr_REV = 9856,

        VMOVDQA64Zrrk = 9857,

        VMOVDQA64Zrrk_REV = 9858,

        VMOVDQA64Zrrkz = 9859,

        VMOVDQA64Zrrkz_REV = 9860,

        VMOVDQAYmr = 9861,

        VMOVDQAYrm = 9862,

        VMOVDQAYrr = 9863,

        VMOVDQAYrr_REV = 9864,

        VMOVDQAmr = 9865,

        VMOVDQArm = 9866,

        VMOVDQArr = 9867,

        VMOVDQArr_REV = 9868,

        VMOVDQU16Z128mr = 9869,

        VMOVDQU16Z128mrk = 9870,

        VMOVDQU16Z128rm = 9871,

        VMOVDQU16Z128rmk = 9872,

        VMOVDQU16Z128rmkz = 9873,

        VMOVDQU16Z128rr = 9874,

        VMOVDQU16Z128rr_REV = 9875,

        VMOVDQU16Z128rrk = 9876,

        VMOVDQU16Z128rrk_REV = 9877,

        VMOVDQU16Z128rrkz = 9878,

        VMOVDQU16Z128rrkz_REV = 9879,

        VMOVDQU16Z256mr = 9880,

        VMOVDQU16Z256mrk = 9881,

        VMOVDQU16Z256rm = 9882,

        VMOVDQU16Z256rmk = 9883,

        VMOVDQU16Z256rmkz = 9884,

        VMOVDQU16Z256rr = 9885,

        VMOVDQU16Z256rr_REV = 9886,

        VMOVDQU16Z256rrk = 9887,

        VMOVDQU16Z256rrk_REV = 9888,

        VMOVDQU16Z256rrkz = 9889,

        VMOVDQU16Z256rrkz_REV = 9890,

        VMOVDQU16Zmr = 9891,

        VMOVDQU16Zmrk = 9892,

        VMOVDQU16Zrm = 9893,

        VMOVDQU16Zrmk = 9894,

        VMOVDQU16Zrmkz = 9895,

        VMOVDQU16Zrr = 9896,

        VMOVDQU16Zrr_REV = 9897,

        VMOVDQU16Zrrk = 9898,

        VMOVDQU16Zrrk_REV = 9899,

        VMOVDQU16Zrrkz = 9900,

        VMOVDQU16Zrrkz_REV = 9901,

        VMOVDQU32Z128mr = 9902,

        VMOVDQU32Z128mrk = 9903,

        VMOVDQU32Z128rm = 9904,

        VMOVDQU32Z128rmk = 9905,

        VMOVDQU32Z128rmkz = 9906,

        VMOVDQU32Z128rr = 9907,

        VMOVDQU32Z128rr_REV = 9908,

        VMOVDQU32Z128rrk = 9909,

        VMOVDQU32Z128rrk_REV = 9910,

        VMOVDQU32Z128rrkz = 9911,

        VMOVDQU32Z128rrkz_REV = 9912,

        VMOVDQU32Z256mr = 9913,

        VMOVDQU32Z256mrk = 9914,

        VMOVDQU32Z256rm = 9915,

        VMOVDQU32Z256rmk = 9916,

        VMOVDQU32Z256rmkz = 9917,

        VMOVDQU32Z256rr = 9918,

        VMOVDQU32Z256rr_REV = 9919,

        VMOVDQU32Z256rrk = 9920,

        VMOVDQU32Z256rrk_REV = 9921,

        VMOVDQU32Z256rrkz = 9922,

        VMOVDQU32Z256rrkz_REV = 9923,

        VMOVDQU32Zmr = 9924,

        VMOVDQU32Zmrk = 9925,

        VMOVDQU32Zrm = 9926,

        VMOVDQU32Zrmk = 9927,

        VMOVDQU32Zrmkz = 9928,

        VMOVDQU32Zrr = 9929,

        VMOVDQU32Zrr_REV = 9930,

        VMOVDQU32Zrrk = 9931,

        VMOVDQU32Zrrk_REV = 9932,

        VMOVDQU32Zrrkz = 9933,

        VMOVDQU32Zrrkz_REV = 9934,

        VMOVDQU64Z128mr = 9935,

        VMOVDQU64Z128mrk = 9936,

        VMOVDQU64Z128rm = 9937,

        VMOVDQU64Z128rmk = 9938,

        VMOVDQU64Z128rmkz = 9939,

        VMOVDQU64Z128rr = 9940,

        VMOVDQU64Z128rr_REV = 9941,

        VMOVDQU64Z128rrk = 9942,

        VMOVDQU64Z128rrk_REV = 9943,

        VMOVDQU64Z128rrkz = 9944,

        VMOVDQU64Z128rrkz_REV = 9945,

        VMOVDQU64Z256mr = 9946,

        VMOVDQU64Z256mrk = 9947,

        VMOVDQU64Z256rm = 9948,

        VMOVDQU64Z256rmk = 9949,

        VMOVDQU64Z256rmkz = 9950,

        VMOVDQU64Z256rr = 9951,

        VMOVDQU64Z256rr_REV = 9952,

        VMOVDQU64Z256rrk = 9953,

        VMOVDQU64Z256rrk_REV = 9954,

        VMOVDQU64Z256rrkz = 9955,

        VMOVDQU64Z256rrkz_REV = 9956,

        VMOVDQU64Zmr = 9957,

        VMOVDQU64Zmrk = 9958,

        VMOVDQU64Zrm = 9959,

        VMOVDQU64Zrmk = 9960,

        VMOVDQU64Zrmkz = 9961,

        VMOVDQU64Zrr = 9962,

        VMOVDQU64Zrr_REV = 9963,

        VMOVDQU64Zrrk = 9964,

        VMOVDQU64Zrrk_REV = 9965,

        VMOVDQU64Zrrkz = 9966,

        VMOVDQU64Zrrkz_REV = 9967,

        VMOVDQU8Z128mr = 9968,

        VMOVDQU8Z128mrk = 9969,

        VMOVDQU8Z128rm = 9970,

        VMOVDQU8Z128rmk = 9971,

        VMOVDQU8Z128rmkz = 9972,

        VMOVDQU8Z128rr = 9973,

        VMOVDQU8Z128rr_REV = 9974,

        VMOVDQU8Z128rrk = 9975,

        VMOVDQU8Z128rrk_REV = 9976,

        VMOVDQU8Z128rrkz = 9977,

        VMOVDQU8Z128rrkz_REV = 9978,

        VMOVDQU8Z256mr = 9979,

        VMOVDQU8Z256mrk = 9980,

        VMOVDQU8Z256rm = 9981,

        VMOVDQU8Z256rmk = 9982,

        VMOVDQU8Z256rmkz = 9983,

        VMOVDQU8Z256rr = 9984,

        VMOVDQU8Z256rr_REV = 9985,

        VMOVDQU8Z256rrk = 9986,

        VMOVDQU8Z256rrk_REV = 9987,

        VMOVDQU8Z256rrkz = 9988,

        VMOVDQU8Z256rrkz_REV = 9989,

        VMOVDQU8Zmr = 9990,

        VMOVDQU8Zmrk = 9991,

        VMOVDQU8Zrm = 9992,

        VMOVDQU8Zrmk = 9993,

        VMOVDQU8Zrmkz = 9994,

        VMOVDQU8Zrr = 9995,

        VMOVDQU8Zrr_REV = 9996,

        VMOVDQU8Zrrk = 9997,

        VMOVDQU8Zrrk_REV = 9998,

        VMOVDQU8Zrrkz = 9999,

        VMOVDQU8Zrrkz_REV = 10000,

        VMOVDQUYmr = 10001,

        VMOVDQUYrm = 10002,

        VMOVDQUYrr = 10003,

        VMOVDQUYrr_REV = 10004,

        VMOVDQUmr = 10005,

        VMOVDQUrm = 10006,

        VMOVDQUrr = 10007,

        VMOVDQUrr_REV = 10008,

        VMOVHLPSZrr = 10009,

        VMOVHLPSrr = 10010,

        VMOVHPDZ128mr = 10011,

        VMOVHPDZ128rm = 10012,

        VMOVHPDmr = 10013,

        VMOVHPDrm = 10014,

        VMOVHPSZ128mr = 10015,

        VMOVHPSZ128rm = 10016,

        VMOVHPSmr = 10017,

        VMOVHPSrm = 10018,

        VMOVLHPSZrr = 10019,

        VMOVLHPSrr = 10020,

        VMOVLPDZ128mr = 10021,

        VMOVLPDZ128rm = 10022,

        VMOVLPDmr = 10023,

        VMOVLPDrm = 10024,

        VMOVLPSZ128mr = 10025,

        VMOVLPSZ128rm = 10026,

        VMOVLPSmr = 10027,

        VMOVLPSrm = 10028,

        VMOVMSKPDYrr = 10029,

        VMOVMSKPDrr = 10030,

        VMOVMSKPSYrr = 10031,

        VMOVMSKPSrr = 10032,

        VMOVNTDQAYrm = 10033,

        VMOVNTDQAZ128rm = 10034,

        VMOVNTDQAZ256rm = 10035,

        VMOVNTDQAZrm = 10036,

        VMOVNTDQArm = 10037,

        VMOVNTDQYmr = 10038,

        VMOVNTDQZ128mr = 10039,

        VMOVNTDQZ256mr = 10040,

        VMOVNTDQZmr = 10041,

        VMOVNTDQmr = 10042,

        VMOVNTPDYmr = 10043,

        VMOVNTPDZ128mr = 10044,

        VMOVNTPDZ256mr = 10045,

        VMOVNTPDZmr = 10046,

        VMOVNTPDmr = 10047,

        VMOVNTPSYmr = 10048,

        VMOVNTPSZ128mr = 10049,

        VMOVNTPSZ256mr = 10050,

        VMOVNTPSZmr = 10051,

        VMOVNTPSmr = 10052,

        VMOVPDI2DIZmr = 10053,

        VMOVPDI2DIZrr = 10054,

        VMOVPDI2DImr = 10055,

        VMOVPDI2DIrr = 10056,

        VMOVPQI2QIZmr = 10057,

        VMOVPQI2QIZrr = 10058,

        VMOVPQI2QImr = 10059,

        VMOVPQI2QIrr = 10060,

        VMOVPQIto64Zmr = 10061,

        VMOVPQIto64Zrr = 10062,

        VMOVPQIto64mr = 10063,

        VMOVPQIto64rr = 10064,

        VMOVQI2PQIZrm = 10065,

        VMOVQI2PQIrm = 10066,

        VMOVSDZmr = 10067,

        VMOVSDZmrk = 10068,

        VMOVSDZrm = 10069,

        VMOVSDZrm_alt = 10070,

        VMOVSDZrmk = 10071,

        VMOVSDZrmkz = 10072,

        VMOVSDZrr = 10073,

        VMOVSDZrr_REV = 10074,

        VMOVSDZrrk = 10075,

        VMOVSDZrrk_REV = 10076,

        VMOVSDZrrkz = 10077,

        VMOVSDZrrkz_REV = 10078,

        VMOVSDmr = 10079,

        VMOVSDrm = 10080,

        VMOVSDrm_alt = 10081,

        VMOVSDrr = 10082,

        VMOVSDrr_REV = 10083,

        VMOVSDto64Zrr = 10084,

        VMOVSDto64rr = 10085,

        VMOVSH2Wrr = 10086,

        VMOVSHDUPYrm = 10087,

        VMOVSHDUPYrr = 10088,

        VMOVSHDUPZ128rm = 10089,

        VMOVSHDUPZ128rmk = 10090,

        VMOVSHDUPZ128rmkz = 10091,

        VMOVSHDUPZ128rr = 10092,

        VMOVSHDUPZ128rrk = 10093,

        VMOVSHDUPZ128rrkz = 10094,

        VMOVSHDUPZ256rm = 10095,

        VMOVSHDUPZ256rmk = 10096,

        VMOVSHDUPZ256rmkz = 10097,

        VMOVSHDUPZ256rr = 10098,

        VMOVSHDUPZ256rrk = 10099,

        VMOVSHDUPZ256rrkz = 10100,

        VMOVSHDUPZrm = 10101,

        VMOVSHDUPZrmk = 10102,

        VMOVSHDUPZrmkz = 10103,

        VMOVSHDUPZrr = 10104,

        VMOVSHDUPZrrk = 10105,

        VMOVSHDUPZrrkz = 10106,

        VMOVSHDUPrm = 10107,

        VMOVSHDUPrr = 10108,

        VMOVSHZmr = 10109,

        VMOVSHZmrk = 10110,

        VMOVSHZrm = 10111,

        VMOVSHZrm_alt = 10112,

        VMOVSHZrmk = 10113,

        VMOVSHZrmkz = 10114,

        VMOVSHZrr = 10115,

        VMOVSHZrr_REV = 10116,

        VMOVSHZrrk = 10117,

        VMOVSHZrrk_REV = 10118,

        VMOVSHZrrkz = 10119,

        VMOVSHZrrkz_REV = 10120,

        VMOVSHtoW64rr = 10121,

        VMOVSLDUPYrm = 10122,

        VMOVSLDUPYrr = 10123,

        VMOVSLDUPZ128rm = 10124,

        VMOVSLDUPZ128rmk = 10125,

        VMOVSLDUPZ128rmkz = 10126,

        VMOVSLDUPZ128rr = 10127,

        VMOVSLDUPZ128rrk = 10128,

        VMOVSLDUPZ128rrkz = 10129,

        VMOVSLDUPZ256rm = 10130,

        VMOVSLDUPZ256rmk = 10131,

        VMOVSLDUPZ256rmkz = 10132,

        VMOVSLDUPZ256rr = 10133,

        VMOVSLDUPZ256rrk = 10134,

        VMOVSLDUPZ256rrkz = 10135,

        VMOVSLDUPZrm = 10136,

        VMOVSLDUPZrmk = 10137,

        VMOVSLDUPZrmkz = 10138,

        VMOVSLDUPZrr = 10139,

        VMOVSLDUPZrrk = 10140,

        VMOVSLDUPZrrkz = 10141,

        VMOVSLDUPrm = 10142,

        VMOVSLDUPrr = 10143,

        VMOVSS2DIZrr = 10144,

        VMOVSS2DIrr = 10145,

        VMOVSSZmr = 10146,

        VMOVSSZmrk = 10147,

        VMOVSSZrm = 10148,

        VMOVSSZrm_alt = 10149,

        VMOVSSZrmk = 10150,

        VMOVSSZrmkz = 10151,

        VMOVSSZrr = 10152,

        VMOVSSZrr_REV = 10153,

        VMOVSSZrrk = 10154,

        VMOVSSZrrk_REV = 10155,

        VMOVSSZrrkz = 10156,

        VMOVSSZrrkz_REV = 10157,

        VMOVSSmr = 10158,

        VMOVSSrm = 10159,

        VMOVSSrm_alt = 10160,

        VMOVSSrr = 10161,

        VMOVSSrr_REV = 10162,

        VMOVUPDYmr = 10163,

        VMOVUPDYrm = 10164,

        VMOVUPDYrr = 10165,

        VMOVUPDYrr_REV = 10166,

        VMOVUPDZ128mr = 10167,

        VMOVUPDZ128mrk = 10168,

        VMOVUPDZ128rm = 10169,

        VMOVUPDZ128rmk = 10170,

        VMOVUPDZ128rmkz = 10171,

        VMOVUPDZ128rr = 10172,

        VMOVUPDZ128rr_REV = 10173,

        VMOVUPDZ128rrk = 10174,

        VMOVUPDZ128rrk_REV = 10175,

        VMOVUPDZ128rrkz = 10176,

        VMOVUPDZ128rrkz_REV = 10177,

        VMOVUPDZ256mr = 10178,

        VMOVUPDZ256mrk = 10179,

        VMOVUPDZ256rm = 10180,

        VMOVUPDZ256rmk = 10181,

        VMOVUPDZ256rmkz = 10182,

        VMOVUPDZ256rr = 10183,

        VMOVUPDZ256rr_REV = 10184,

        VMOVUPDZ256rrk = 10185,

        VMOVUPDZ256rrk_REV = 10186,

        VMOVUPDZ256rrkz = 10187,

        VMOVUPDZ256rrkz_REV = 10188,

        VMOVUPDZmr = 10189,

        VMOVUPDZmrk = 10190,

        VMOVUPDZrm = 10191,

        VMOVUPDZrmk = 10192,

        VMOVUPDZrmkz = 10193,

        VMOVUPDZrr = 10194,

        VMOVUPDZrr_REV = 10195,

        VMOVUPDZrrk = 10196,

        VMOVUPDZrrk_REV = 10197,

        VMOVUPDZrrkz = 10198,

        VMOVUPDZrrkz_REV = 10199,

        VMOVUPDmr = 10200,

        VMOVUPDrm = 10201,

        VMOVUPDrr = 10202,

        VMOVUPDrr_REV = 10203,

        VMOVUPSYmr = 10204,

        VMOVUPSYrm = 10205,

        VMOVUPSYrr = 10206,

        VMOVUPSYrr_REV = 10207,

        VMOVUPSZ128mr = 10208,

        VMOVUPSZ128mrk = 10209,

        VMOVUPSZ128rm = 10210,

        VMOVUPSZ128rmk = 10211,

        VMOVUPSZ128rmkz = 10212,

        VMOVUPSZ128rr = 10213,

        VMOVUPSZ128rr_REV = 10214,

        VMOVUPSZ128rrk = 10215,

        VMOVUPSZ128rrk_REV = 10216,

        VMOVUPSZ128rrkz = 10217,

        VMOVUPSZ128rrkz_REV = 10218,

        VMOVUPSZ256mr = 10219,

        VMOVUPSZ256mrk = 10220,

        VMOVUPSZ256rm = 10221,

        VMOVUPSZ256rmk = 10222,

        VMOVUPSZ256rmkz = 10223,

        VMOVUPSZ256rr = 10224,

        VMOVUPSZ256rr_REV = 10225,

        VMOVUPSZ256rrk = 10226,

        VMOVUPSZ256rrk_REV = 10227,

        VMOVUPSZ256rrkz = 10228,

        VMOVUPSZ256rrkz_REV = 10229,

        VMOVUPSZmr = 10230,

        VMOVUPSZmrk = 10231,

        VMOVUPSZrm = 10232,

        VMOVUPSZrmk = 10233,

        VMOVUPSZrmkz = 10234,

        VMOVUPSZrr = 10235,

        VMOVUPSZrr_REV = 10236,

        VMOVUPSZrrk = 10237,

        VMOVUPSZrrk_REV = 10238,

        VMOVUPSZrrkz = 10239,

        VMOVUPSZrrkz_REV = 10240,

        VMOVUPSmr = 10241,

        VMOVUPSrm = 10242,

        VMOVUPSrr = 10243,

        VMOVUPSrr_REV = 10244,

        VMOVW2SHrr = 10245,

        VMOVW64toSHrr = 10246,

        VMOVWmr = 10247,

        VMOVWrm = 10248,

        VMOVZPQILo2PQIZrr = 10249,

        VMOVZPQILo2PQIrr = 10250,

        VMPSADBWYrmi = 10251,

        VMPSADBWYrri = 10252,

        VMPSADBWrmi = 10253,

        VMPSADBWrri = 10254,

        VMPTRLDm = 10255,

        VMPTRSTm = 10256,

        VMREAD32mr = 10257,

        VMREAD32rr = 10258,

        VMREAD64mr = 10259,

        VMREAD64rr = 10260,

        VMRESUME = 10261,

        VMRUN32 = 10262,

        VMRUN64 = 10263,

        VMSAVE32 = 10264,

        VMSAVE64 = 10265,

        VMULPDYrm = 10266,

        VMULPDYrr = 10267,

        VMULPDZ128rm = 10268,

        VMULPDZ128rmb = 10269,

        VMULPDZ128rmbk = 10270,

        VMULPDZ128rmbkz = 10271,

        VMULPDZ128rmk = 10272,

        VMULPDZ128rmkz = 10273,

        VMULPDZ128rr = 10274,

        VMULPDZ128rrk = 10275,

        VMULPDZ128rrkz = 10276,

        VMULPDZ256rm = 10277,

        VMULPDZ256rmb = 10278,

        VMULPDZ256rmbk = 10279,

        VMULPDZ256rmbkz = 10280,

        VMULPDZ256rmk = 10281,

        VMULPDZ256rmkz = 10282,

        VMULPDZ256rr = 10283,

        VMULPDZ256rrk = 10284,

        VMULPDZ256rrkz = 10285,

        VMULPDZrm = 10286,

        VMULPDZrmb = 10287,

        VMULPDZrmbk = 10288,

        VMULPDZrmbkz = 10289,

        VMULPDZrmk = 10290,

        VMULPDZrmkz = 10291,

        VMULPDZrr = 10292,

        VMULPDZrrb = 10293,

        VMULPDZrrbk = 10294,

        VMULPDZrrbkz = 10295,

        VMULPDZrrk = 10296,

        VMULPDZrrkz = 10297,

        VMULPDrm = 10298,

        VMULPDrr = 10299,

        VMULPHZ128rm = 10300,

        VMULPHZ128rmb = 10301,

        VMULPHZ128rmbk = 10302,

        VMULPHZ128rmbkz = 10303,

        VMULPHZ128rmk = 10304,

        VMULPHZ128rmkz = 10305,

        VMULPHZ128rr = 10306,

        VMULPHZ128rrk = 10307,

        VMULPHZ128rrkz = 10308,

        VMULPHZ256rm = 10309,

        VMULPHZ256rmb = 10310,

        VMULPHZ256rmbk = 10311,

        VMULPHZ256rmbkz = 10312,

        VMULPHZ256rmk = 10313,

        VMULPHZ256rmkz = 10314,

        VMULPHZ256rr = 10315,

        VMULPHZ256rrk = 10316,

        VMULPHZ256rrkz = 10317,

        VMULPHZrm = 10318,

        VMULPHZrmb = 10319,

        VMULPHZrmbk = 10320,

        VMULPHZrmbkz = 10321,

        VMULPHZrmk = 10322,

        VMULPHZrmkz = 10323,

        VMULPHZrr = 10324,

        VMULPHZrrb = 10325,

        VMULPHZrrbk = 10326,

        VMULPHZrrbkz = 10327,

        VMULPHZrrk = 10328,

        VMULPHZrrkz = 10329,

        VMULPSYrm = 10330,

        VMULPSYrr = 10331,

        VMULPSZ128rm = 10332,

        VMULPSZ128rmb = 10333,

        VMULPSZ128rmbk = 10334,

        VMULPSZ128rmbkz = 10335,

        VMULPSZ128rmk = 10336,

        VMULPSZ128rmkz = 10337,

        VMULPSZ128rr = 10338,

        VMULPSZ128rrk = 10339,

        VMULPSZ128rrkz = 10340,

        VMULPSZ256rm = 10341,

        VMULPSZ256rmb = 10342,

        VMULPSZ256rmbk = 10343,

        VMULPSZ256rmbkz = 10344,

        VMULPSZ256rmk = 10345,

        VMULPSZ256rmkz = 10346,

        VMULPSZ256rr = 10347,

        VMULPSZ256rrk = 10348,

        VMULPSZ256rrkz = 10349,

        VMULPSZrm = 10350,

        VMULPSZrmb = 10351,

        VMULPSZrmbk = 10352,

        VMULPSZrmbkz = 10353,

        VMULPSZrmk = 10354,

        VMULPSZrmkz = 10355,

        VMULPSZrr = 10356,

        VMULPSZrrb = 10357,

        VMULPSZrrbk = 10358,

        VMULPSZrrbkz = 10359,

        VMULPSZrrk = 10360,

        VMULPSZrrkz = 10361,

        VMULPSrm = 10362,

        VMULPSrr = 10363,

        VMULSDZrm = 10364,

        VMULSDZrm_Int = 10365,

        VMULSDZrm_Intk = 10366,

        VMULSDZrm_Intkz = 10367,

        VMULSDZrr = 10368,

        VMULSDZrr_Int = 10369,

        VMULSDZrr_Intk = 10370,

        VMULSDZrr_Intkz = 10371,

        VMULSDZrrb_Int = 10372,

        VMULSDZrrb_Intk = 10373,

        VMULSDZrrb_Intkz = 10374,

        VMULSDrm = 10375,

        VMULSDrm_Int = 10376,

        VMULSDrr = 10377,

        VMULSDrr_Int = 10378,

        VMULSHZrm = 10379,

        VMULSHZrm_Int = 10380,

        VMULSHZrm_Intk = 10381,

        VMULSHZrm_Intkz = 10382,

        VMULSHZrr = 10383,

        VMULSHZrr_Int = 10384,

        VMULSHZrr_Intk = 10385,

        VMULSHZrr_Intkz = 10386,

        VMULSHZrrb_Int = 10387,

        VMULSHZrrb_Intk = 10388,

        VMULSHZrrb_Intkz = 10389,

        VMULSSZrm = 10390,

        VMULSSZrm_Int = 10391,

        VMULSSZrm_Intk = 10392,

        VMULSSZrm_Intkz = 10393,

        VMULSSZrr = 10394,

        VMULSSZrr_Int = 10395,

        VMULSSZrr_Intk = 10396,

        VMULSSZrr_Intkz = 10397,

        VMULSSZrrb_Int = 10398,

        VMULSSZrrb_Intk = 10399,

        VMULSSZrrb_Intkz = 10400,

        VMULSSrm = 10401,

        VMULSSrm_Int = 10402,

        VMULSSrr = 10403,

        VMULSSrr_Int = 10404,

        VMWRITE32rm = 10405,

        VMWRITE32rr = 10406,

        VMWRITE64rm = 10407,

        VMWRITE64rr = 10408,

        VMXOFF = 10409,

        VMXON = 10410,

        VORPDYrm = 10411,

        VORPDYrr = 10412,

        VORPDZ128rm = 10413,

        VORPDZ128rmb = 10414,

        VORPDZ128rmbk = 10415,

        VORPDZ128rmbkz = 10416,

        VORPDZ128rmk = 10417,

        VORPDZ128rmkz = 10418,

        VORPDZ128rr = 10419,

        VORPDZ128rrk = 10420,

        VORPDZ128rrkz = 10421,

        VORPDZ256rm = 10422,

        VORPDZ256rmb = 10423,

        VORPDZ256rmbk = 10424,

        VORPDZ256rmbkz = 10425,

        VORPDZ256rmk = 10426,

        VORPDZ256rmkz = 10427,

        VORPDZ256rr = 10428,

        VORPDZ256rrk = 10429,

        VORPDZ256rrkz = 10430,

        VORPDZrm = 10431,

        VORPDZrmb = 10432,

        VORPDZrmbk = 10433,

        VORPDZrmbkz = 10434,

        VORPDZrmk = 10435,

        VORPDZrmkz = 10436,

        VORPDZrr = 10437,

        VORPDZrrk = 10438,

        VORPDZrrkz = 10439,

        VORPDrm = 10440,

        VORPDrr = 10441,

        VORPSYrm = 10442,

        VORPSYrr = 10443,

        VORPSZ128rm = 10444,

        VORPSZ128rmb = 10445,

        VORPSZ128rmbk = 10446,

        VORPSZ128rmbkz = 10447,

        VORPSZ128rmk = 10448,

        VORPSZ128rmkz = 10449,

        VORPSZ128rr = 10450,

        VORPSZ128rrk = 10451,

        VORPSZ128rrkz = 10452,

        VORPSZ256rm = 10453,

        VORPSZ256rmb = 10454,

        VORPSZ256rmbk = 10455,

        VORPSZ256rmbkz = 10456,

        VORPSZ256rmk = 10457,

        VORPSZ256rmkz = 10458,

        VORPSZ256rr = 10459,

        VORPSZ256rrk = 10460,

        VORPSZ256rrkz = 10461,

        VORPSZrm = 10462,

        VORPSZrmb = 10463,

        VORPSZrmbk = 10464,

        VORPSZrmbkz = 10465,

        VORPSZrmk = 10466,

        VORPSZrmkz = 10467,

        VORPSZrr = 10468,

        VORPSZrrk = 10469,

        VORPSZrrkz = 10470,

        VORPSrm = 10471,

        VORPSrr = 10472,

        VP2INTERSECTDZ128rm = 10473,

        VP2INTERSECTDZ128rmb = 10474,

        VP2INTERSECTDZ128rr = 10475,

        VP2INTERSECTDZ256rm = 10476,

        VP2INTERSECTDZ256rmb = 10477,

        VP2INTERSECTDZ256rr = 10478,

        VP2INTERSECTDZrm = 10479,

        VP2INTERSECTDZrmb = 10480,

        VP2INTERSECTDZrr = 10481,

        VP2INTERSECTQZ128rm = 10482,

        VP2INTERSECTQZ128rmb = 10483,

        VP2INTERSECTQZ128rr = 10484,

        VP2INTERSECTQZ256rm = 10485,

        VP2INTERSECTQZ256rmb = 10486,

        VP2INTERSECTQZ256rr = 10487,

        VP2INTERSECTQZrm = 10488,

        VP2INTERSECTQZrmb = 10489,

        VP2INTERSECTQZrr = 10490,

        VP4DPWSSDSrm = 10491,

        VP4DPWSSDSrmk = 10492,

        VP4DPWSSDSrmkz = 10493,

        VP4DPWSSDrm = 10494,

        VP4DPWSSDrmk = 10495,

        VP4DPWSSDrmkz = 10496,

        VPABSBYrm = 10497,

        VPABSBYrr = 10498,

        VPABSBZ128rm = 10499,

        VPABSBZ128rmk = 10500,

        VPABSBZ128rmkz = 10501,

        VPABSBZ128rr = 10502,

        VPABSBZ128rrk = 10503,

        VPABSBZ128rrkz = 10504,

        VPABSBZ256rm = 10505,

        VPABSBZ256rmk = 10506,

        VPABSBZ256rmkz = 10507,

        VPABSBZ256rr = 10508,

        VPABSBZ256rrk = 10509,

        VPABSBZ256rrkz = 10510,

        VPABSBZrm = 10511,

        VPABSBZrmk = 10512,

        VPABSBZrmkz = 10513,

        VPABSBZrr = 10514,

        VPABSBZrrk = 10515,

        VPABSBZrrkz = 10516,

        VPABSBrm = 10517,

        VPABSBrr = 10518,

        VPABSDYrm = 10519,

        VPABSDYrr = 10520,

        VPABSDZ128rm = 10521,

        VPABSDZ128rmb = 10522,

        VPABSDZ128rmbk = 10523,

        VPABSDZ128rmbkz = 10524,

        VPABSDZ128rmk = 10525,

        VPABSDZ128rmkz = 10526,

        VPABSDZ128rr = 10527,

        VPABSDZ128rrk = 10528,

        VPABSDZ128rrkz = 10529,

        VPABSDZ256rm = 10530,

        VPABSDZ256rmb = 10531,

        VPABSDZ256rmbk = 10532,

        VPABSDZ256rmbkz = 10533,

        VPABSDZ256rmk = 10534,

        VPABSDZ256rmkz = 10535,

        VPABSDZ256rr = 10536,

        VPABSDZ256rrk = 10537,

        VPABSDZ256rrkz = 10538,

        VPABSDZrm = 10539,

        VPABSDZrmb = 10540,

        VPABSDZrmbk = 10541,

        VPABSDZrmbkz = 10542,

        VPABSDZrmk = 10543,

        VPABSDZrmkz = 10544,

        VPABSDZrr = 10545,

        VPABSDZrrk = 10546,

        VPABSDZrrkz = 10547,

        VPABSDrm = 10548,

        VPABSDrr = 10549,

        VPABSQZ128rm = 10550,

        VPABSQZ128rmb = 10551,

        VPABSQZ128rmbk = 10552,

        VPABSQZ128rmbkz = 10553,

        VPABSQZ128rmk = 10554,

        VPABSQZ128rmkz = 10555,

        VPABSQZ128rr = 10556,

        VPABSQZ128rrk = 10557,

        VPABSQZ128rrkz = 10558,

        VPABSQZ256rm = 10559,

        VPABSQZ256rmb = 10560,

        VPABSQZ256rmbk = 10561,

        VPABSQZ256rmbkz = 10562,

        VPABSQZ256rmk = 10563,

        VPABSQZ256rmkz = 10564,

        VPABSQZ256rr = 10565,

        VPABSQZ256rrk = 10566,

        VPABSQZ256rrkz = 10567,

        VPABSQZrm = 10568,

        VPABSQZrmb = 10569,

        VPABSQZrmbk = 10570,

        VPABSQZrmbkz = 10571,

        VPABSQZrmk = 10572,

        VPABSQZrmkz = 10573,

        VPABSQZrr = 10574,

        VPABSQZrrk = 10575,

        VPABSQZrrkz = 10576,

        VPABSWYrm = 10577,

        VPABSWYrr = 10578,

        VPABSWZ128rm = 10579,

        VPABSWZ128rmk = 10580,

        VPABSWZ128rmkz = 10581,

        VPABSWZ128rr = 10582,

        VPABSWZ128rrk = 10583,

        VPABSWZ128rrkz = 10584,

        VPABSWZ256rm = 10585,

        VPABSWZ256rmk = 10586,

        VPABSWZ256rmkz = 10587,

        VPABSWZ256rr = 10588,

        VPABSWZ256rrk = 10589,

        VPABSWZ256rrkz = 10590,

        VPABSWZrm = 10591,

        VPABSWZrmk = 10592,

        VPABSWZrmkz = 10593,

        VPABSWZrr = 10594,

        VPABSWZrrk = 10595,

        VPABSWZrrkz = 10596,

        VPABSWrm = 10597,

        VPABSWrr = 10598,

        VPACKSSDWYrm = 10599,

        VPACKSSDWYrr = 10600,

        VPACKSSDWZ128rm = 10601,

        VPACKSSDWZ128rmb = 10602,

        VPACKSSDWZ128rmbk = 10603,

        VPACKSSDWZ128rmbkz = 10604,

        VPACKSSDWZ128rmk = 10605,

        VPACKSSDWZ128rmkz = 10606,

        VPACKSSDWZ128rr = 10607,

        VPACKSSDWZ128rrk = 10608,

        VPACKSSDWZ128rrkz = 10609,

        VPACKSSDWZ256rm = 10610,

        VPACKSSDWZ256rmb = 10611,

        VPACKSSDWZ256rmbk = 10612,

        VPACKSSDWZ256rmbkz = 10613,

        VPACKSSDWZ256rmk = 10614,

        VPACKSSDWZ256rmkz = 10615,

        VPACKSSDWZ256rr = 10616,

        VPACKSSDWZ256rrk = 10617,

        VPACKSSDWZ256rrkz = 10618,

        VPACKSSDWZrm = 10619,

        VPACKSSDWZrmb = 10620,

        VPACKSSDWZrmbk = 10621,

        VPACKSSDWZrmbkz = 10622,

        VPACKSSDWZrmk = 10623,

        VPACKSSDWZrmkz = 10624,

        VPACKSSDWZrr = 10625,

        VPACKSSDWZrrk = 10626,

        VPACKSSDWZrrkz = 10627,

        VPACKSSDWrm = 10628,

        VPACKSSDWrr = 10629,

        VPACKSSWBYrm = 10630,

        VPACKSSWBYrr = 10631,

        VPACKSSWBZ128rm = 10632,

        VPACKSSWBZ128rmk = 10633,

        VPACKSSWBZ128rmkz = 10634,

        VPACKSSWBZ128rr = 10635,

        VPACKSSWBZ128rrk = 10636,

        VPACKSSWBZ128rrkz = 10637,

        VPACKSSWBZ256rm = 10638,

        VPACKSSWBZ256rmk = 10639,

        VPACKSSWBZ256rmkz = 10640,

        VPACKSSWBZ256rr = 10641,

        VPACKSSWBZ256rrk = 10642,

        VPACKSSWBZ256rrkz = 10643,

        VPACKSSWBZrm = 10644,

        VPACKSSWBZrmk = 10645,

        VPACKSSWBZrmkz = 10646,

        VPACKSSWBZrr = 10647,

        VPACKSSWBZrrk = 10648,

        VPACKSSWBZrrkz = 10649,

        VPACKSSWBrm = 10650,

        VPACKSSWBrr = 10651,

        VPACKUSDWYrm = 10652,

        VPACKUSDWYrr = 10653,

        VPACKUSDWZ128rm = 10654,

        VPACKUSDWZ128rmb = 10655,

        VPACKUSDWZ128rmbk = 10656,

        VPACKUSDWZ128rmbkz = 10657,

        VPACKUSDWZ128rmk = 10658,

        VPACKUSDWZ128rmkz = 10659,

        VPACKUSDWZ128rr = 10660,

        VPACKUSDWZ128rrk = 10661,

        VPACKUSDWZ128rrkz = 10662,

        VPACKUSDWZ256rm = 10663,

        VPACKUSDWZ256rmb = 10664,

        VPACKUSDWZ256rmbk = 10665,

        VPACKUSDWZ256rmbkz = 10666,

        VPACKUSDWZ256rmk = 10667,

        VPACKUSDWZ256rmkz = 10668,

        VPACKUSDWZ256rr = 10669,

        VPACKUSDWZ256rrk = 10670,

        VPACKUSDWZ256rrkz = 10671,

        VPACKUSDWZrm = 10672,

        VPACKUSDWZrmb = 10673,

        VPACKUSDWZrmbk = 10674,

        VPACKUSDWZrmbkz = 10675,

        VPACKUSDWZrmk = 10676,

        VPACKUSDWZrmkz = 10677,

        VPACKUSDWZrr = 10678,

        VPACKUSDWZrrk = 10679,

        VPACKUSDWZrrkz = 10680,

        VPACKUSDWrm = 10681,

        VPACKUSDWrr = 10682,

        VPACKUSWBYrm = 10683,

        VPACKUSWBYrr = 10684,

        VPACKUSWBZ128rm = 10685,

        VPACKUSWBZ128rmk = 10686,

        VPACKUSWBZ128rmkz = 10687,

        VPACKUSWBZ128rr = 10688,

        VPACKUSWBZ128rrk = 10689,

        VPACKUSWBZ128rrkz = 10690,

        VPACKUSWBZ256rm = 10691,

        VPACKUSWBZ256rmk = 10692,

        VPACKUSWBZ256rmkz = 10693,

        VPACKUSWBZ256rr = 10694,

        VPACKUSWBZ256rrk = 10695,

        VPACKUSWBZ256rrkz = 10696,

        VPACKUSWBZrm = 10697,

        VPACKUSWBZrmk = 10698,

        VPACKUSWBZrmkz = 10699,

        VPACKUSWBZrr = 10700,

        VPACKUSWBZrrk = 10701,

        VPACKUSWBZrrkz = 10702,

        VPACKUSWBrm = 10703,

        VPACKUSWBrr = 10704,

        VPADDBYrm = 10705,

        VPADDBYrr = 10706,

        VPADDBZ128rm = 10707,

        VPADDBZ128rmk = 10708,

        VPADDBZ128rmkz = 10709,

        VPADDBZ128rr = 10710,

        VPADDBZ128rrk = 10711,

        VPADDBZ128rrkz = 10712,

        VPADDBZ256rm = 10713,

        VPADDBZ256rmk = 10714,

        VPADDBZ256rmkz = 10715,

        VPADDBZ256rr = 10716,

        VPADDBZ256rrk = 10717,

        VPADDBZ256rrkz = 10718,

        VPADDBZrm = 10719,

        VPADDBZrmk = 10720,

        VPADDBZrmkz = 10721,

        VPADDBZrr = 10722,

        VPADDBZrrk = 10723,

        VPADDBZrrkz = 10724,

        VPADDBrm = 10725,

        VPADDBrr = 10726,

        VPADDDYrm = 10727,

        VPADDDYrr = 10728,

        VPADDDZ128rm = 10729,

        VPADDDZ128rmb = 10730,

        VPADDDZ128rmbk = 10731,

        VPADDDZ128rmbkz = 10732,

        VPADDDZ128rmk = 10733,

        VPADDDZ128rmkz = 10734,

        VPADDDZ128rr = 10735,

        VPADDDZ128rrk = 10736,

        VPADDDZ128rrkz = 10737,

        VPADDDZ256rm = 10738,

        VPADDDZ256rmb = 10739,

        VPADDDZ256rmbk = 10740,

        VPADDDZ256rmbkz = 10741,

        VPADDDZ256rmk = 10742,

        VPADDDZ256rmkz = 10743,

        VPADDDZ256rr = 10744,

        VPADDDZ256rrk = 10745,

        VPADDDZ256rrkz = 10746,

        VPADDDZrm = 10747,

        VPADDDZrmb = 10748,

        VPADDDZrmbk = 10749,

        VPADDDZrmbkz = 10750,

        VPADDDZrmk = 10751,

        VPADDDZrmkz = 10752,

        VPADDDZrr = 10753,

        VPADDDZrrk = 10754,

        VPADDDZrrkz = 10755,

        VPADDDrm = 10756,

        VPADDDrr = 10757,

        VPADDQYrm = 10758,

        VPADDQYrr = 10759,

        VPADDQZ128rm = 10760,

        VPADDQZ128rmb = 10761,

        VPADDQZ128rmbk = 10762,

        VPADDQZ128rmbkz = 10763,

        VPADDQZ128rmk = 10764,

        VPADDQZ128rmkz = 10765,

        VPADDQZ128rr = 10766,

        VPADDQZ128rrk = 10767,

        VPADDQZ128rrkz = 10768,

        VPADDQZ256rm = 10769,

        VPADDQZ256rmb = 10770,

        VPADDQZ256rmbk = 10771,

        VPADDQZ256rmbkz = 10772,

        VPADDQZ256rmk = 10773,

        VPADDQZ256rmkz = 10774,

        VPADDQZ256rr = 10775,

        VPADDQZ256rrk = 10776,

        VPADDQZ256rrkz = 10777,

        VPADDQZrm = 10778,

        VPADDQZrmb = 10779,

        VPADDQZrmbk = 10780,

        VPADDQZrmbkz = 10781,

        VPADDQZrmk = 10782,

        VPADDQZrmkz = 10783,

        VPADDQZrr = 10784,

        VPADDQZrrk = 10785,

        VPADDQZrrkz = 10786,

        VPADDQrm = 10787,

        VPADDQrr = 10788,

        VPADDSBYrm = 10789,

        VPADDSBYrr = 10790,

        VPADDSBZ128rm = 10791,

        VPADDSBZ128rmk = 10792,

        VPADDSBZ128rmkz = 10793,

        VPADDSBZ128rr = 10794,

        VPADDSBZ128rrk = 10795,

        VPADDSBZ128rrkz = 10796,

        VPADDSBZ256rm = 10797,

        VPADDSBZ256rmk = 10798,

        VPADDSBZ256rmkz = 10799,

        VPADDSBZ256rr = 10800,

        VPADDSBZ256rrk = 10801,

        VPADDSBZ256rrkz = 10802,

        VPADDSBZrm = 10803,

        VPADDSBZrmk = 10804,

        VPADDSBZrmkz = 10805,

        VPADDSBZrr = 10806,

        VPADDSBZrrk = 10807,

        VPADDSBZrrkz = 10808,

        VPADDSBrm = 10809,

        VPADDSBrr = 10810,

        VPADDSWYrm = 10811,

        VPADDSWYrr = 10812,

        VPADDSWZ128rm = 10813,

        VPADDSWZ128rmk = 10814,

        VPADDSWZ128rmkz = 10815,

        VPADDSWZ128rr = 10816,

        VPADDSWZ128rrk = 10817,

        VPADDSWZ128rrkz = 10818,

        VPADDSWZ256rm = 10819,

        VPADDSWZ256rmk = 10820,

        VPADDSWZ256rmkz = 10821,

        VPADDSWZ256rr = 10822,

        VPADDSWZ256rrk = 10823,

        VPADDSWZ256rrkz = 10824,

        VPADDSWZrm = 10825,

        VPADDSWZrmk = 10826,

        VPADDSWZrmkz = 10827,

        VPADDSWZrr = 10828,

        VPADDSWZrrk = 10829,

        VPADDSWZrrkz = 10830,

        VPADDSWrm = 10831,

        VPADDSWrr = 10832,

        VPADDUSBYrm = 10833,

        VPADDUSBYrr = 10834,

        VPADDUSBZ128rm = 10835,

        VPADDUSBZ128rmk = 10836,

        VPADDUSBZ128rmkz = 10837,

        VPADDUSBZ128rr = 10838,

        VPADDUSBZ128rrk = 10839,

        VPADDUSBZ128rrkz = 10840,

        VPADDUSBZ256rm = 10841,

        VPADDUSBZ256rmk = 10842,

        VPADDUSBZ256rmkz = 10843,

        VPADDUSBZ256rr = 10844,

        VPADDUSBZ256rrk = 10845,

        VPADDUSBZ256rrkz = 10846,

        VPADDUSBZrm = 10847,

        VPADDUSBZrmk = 10848,

        VPADDUSBZrmkz = 10849,

        VPADDUSBZrr = 10850,

        VPADDUSBZrrk = 10851,

        VPADDUSBZrrkz = 10852,

        VPADDUSBrm = 10853,

        VPADDUSBrr = 10854,

        VPADDUSWYrm = 10855,

        VPADDUSWYrr = 10856,

        VPADDUSWZ128rm = 10857,

        VPADDUSWZ128rmk = 10858,

        VPADDUSWZ128rmkz = 10859,

        VPADDUSWZ128rr = 10860,

        VPADDUSWZ128rrk = 10861,

        VPADDUSWZ128rrkz = 10862,

        VPADDUSWZ256rm = 10863,

        VPADDUSWZ256rmk = 10864,

        VPADDUSWZ256rmkz = 10865,

        VPADDUSWZ256rr = 10866,

        VPADDUSWZ256rrk = 10867,

        VPADDUSWZ256rrkz = 10868,

        VPADDUSWZrm = 10869,

        VPADDUSWZrmk = 10870,

        VPADDUSWZrmkz = 10871,

        VPADDUSWZrr = 10872,

        VPADDUSWZrrk = 10873,

        VPADDUSWZrrkz = 10874,

        VPADDUSWrm = 10875,

        VPADDUSWrr = 10876,

        VPADDWYrm = 10877,

        VPADDWYrr = 10878,

        VPADDWZ128rm = 10879,

        VPADDWZ128rmk = 10880,

        VPADDWZ128rmkz = 10881,

        VPADDWZ128rr = 10882,

        VPADDWZ128rrk = 10883,

        VPADDWZ128rrkz = 10884,

        VPADDWZ256rm = 10885,

        VPADDWZ256rmk = 10886,

        VPADDWZ256rmkz = 10887,

        VPADDWZ256rr = 10888,

        VPADDWZ256rrk = 10889,

        VPADDWZ256rrkz = 10890,

        VPADDWZrm = 10891,

        VPADDWZrmk = 10892,

        VPADDWZrmkz = 10893,

        VPADDWZrr = 10894,

        VPADDWZrrk = 10895,

        VPADDWZrrkz = 10896,

        VPADDWrm = 10897,

        VPADDWrr = 10898,

        VPALIGNRYrmi = 10899,

        VPALIGNRYrri = 10900,

        VPALIGNRZ128rmi = 10901,

        VPALIGNRZ128rmik = 10902,

        VPALIGNRZ128rmikz = 10903,

        VPALIGNRZ128rri = 10904,

        VPALIGNRZ128rrik = 10905,

        VPALIGNRZ128rrikz = 10906,

        VPALIGNRZ256rmi = 10907,

        VPALIGNRZ256rmik = 10908,

        VPALIGNRZ256rmikz = 10909,

        VPALIGNRZ256rri = 10910,

        VPALIGNRZ256rrik = 10911,

        VPALIGNRZ256rrikz = 10912,

        VPALIGNRZrmi = 10913,

        VPALIGNRZrmik = 10914,

        VPALIGNRZrmikz = 10915,

        VPALIGNRZrri = 10916,

        VPALIGNRZrrik = 10917,

        VPALIGNRZrrikz = 10918,

        VPALIGNRrmi = 10919,

        VPALIGNRrri = 10920,

        VPANDDZ128rm = 10921,

        VPANDDZ128rmb = 10922,

        VPANDDZ128rmbk = 10923,

        VPANDDZ128rmbkz = 10924,

        VPANDDZ128rmk = 10925,

        VPANDDZ128rmkz = 10926,

        VPANDDZ128rr = 10927,

        VPANDDZ128rrk = 10928,

        VPANDDZ128rrkz = 10929,

        VPANDDZ256rm = 10930,

        VPANDDZ256rmb = 10931,

        VPANDDZ256rmbk = 10932,

        VPANDDZ256rmbkz = 10933,

        VPANDDZ256rmk = 10934,

        VPANDDZ256rmkz = 10935,

        VPANDDZ256rr = 10936,

        VPANDDZ256rrk = 10937,

        VPANDDZ256rrkz = 10938,

        VPANDDZrm = 10939,

        VPANDDZrmb = 10940,

        VPANDDZrmbk = 10941,

        VPANDDZrmbkz = 10942,

        VPANDDZrmk = 10943,

        VPANDDZrmkz = 10944,

        VPANDDZrr = 10945,

        VPANDDZrrk = 10946,

        VPANDDZrrkz = 10947,

        VPANDNDZ128rm = 10948,

        VPANDNDZ128rmb = 10949,

        VPANDNDZ128rmbk = 10950,

        VPANDNDZ128rmbkz = 10951,

        VPANDNDZ128rmk = 10952,

        VPANDNDZ128rmkz = 10953,

        VPANDNDZ128rr = 10954,

        VPANDNDZ128rrk = 10955,

        VPANDNDZ128rrkz = 10956,

        VPANDNDZ256rm = 10957,

        VPANDNDZ256rmb = 10958,

        VPANDNDZ256rmbk = 10959,

        VPANDNDZ256rmbkz = 10960,

        VPANDNDZ256rmk = 10961,

        VPANDNDZ256rmkz = 10962,

        VPANDNDZ256rr = 10963,

        VPANDNDZ256rrk = 10964,

        VPANDNDZ256rrkz = 10965,

        VPANDNDZrm = 10966,

        VPANDNDZrmb = 10967,

        VPANDNDZrmbk = 10968,

        VPANDNDZrmbkz = 10969,

        VPANDNDZrmk = 10970,

        VPANDNDZrmkz = 10971,

        VPANDNDZrr = 10972,

        VPANDNDZrrk = 10973,

        VPANDNDZrrkz = 10974,

        VPANDNQZ128rm = 10975,

        VPANDNQZ128rmb = 10976,

        VPANDNQZ128rmbk = 10977,

        VPANDNQZ128rmbkz = 10978,

        VPANDNQZ128rmk = 10979,

        VPANDNQZ128rmkz = 10980,

        VPANDNQZ128rr = 10981,

        VPANDNQZ128rrk = 10982,

        VPANDNQZ128rrkz = 10983,

        VPANDNQZ256rm = 10984,

        VPANDNQZ256rmb = 10985,

        VPANDNQZ256rmbk = 10986,

        VPANDNQZ256rmbkz = 10987,

        VPANDNQZ256rmk = 10988,

        VPANDNQZ256rmkz = 10989,

        VPANDNQZ256rr = 10990,

        VPANDNQZ256rrk = 10991,

        VPANDNQZ256rrkz = 10992,

        VPANDNQZrm = 10993,

        VPANDNQZrmb = 10994,

        VPANDNQZrmbk = 10995,

        VPANDNQZrmbkz = 10996,

        VPANDNQZrmk = 10997,

        VPANDNQZrmkz = 10998,

        VPANDNQZrr = 10999,

        VPANDNQZrrk = 11000,

        VPANDNQZrrkz = 11001,

        VPANDNYrm = 11002,

        VPANDNYrr = 11003,

        VPANDNrm = 11004,

        VPANDNrr = 11005,

        VPANDQZ128rm = 11006,

        VPANDQZ128rmb = 11007,

        VPANDQZ128rmbk = 11008,

        VPANDQZ128rmbkz = 11009,

        VPANDQZ128rmk = 11010,

        VPANDQZ128rmkz = 11011,

        VPANDQZ128rr = 11012,

        VPANDQZ128rrk = 11013,

        VPANDQZ128rrkz = 11014,

        VPANDQZ256rm = 11015,

        VPANDQZ256rmb = 11016,

        VPANDQZ256rmbk = 11017,

        VPANDQZ256rmbkz = 11018,

        VPANDQZ256rmk = 11019,

        VPANDQZ256rmkz = 11020,

        VPANDQZ256rr = 11021,

        VPANDQZ256rrk = 11022,

        VPANDQZ256rrkz = 11023,

        VPANDQZrm = 11024,

        VPANDQZrmb = 11025,

        VPANDQZrmbk = 11026,

        VPANDQZrmbkz = 11027,

        VPANDQZrmk = 11028,

        VPANDQZrmkz = 11029,

        VPANDQZrr = 11030,

        VPANDQZrrk = 11031,

        VPANDQZrrkz = 11032,

        VPANDYrm = 11033,

        VPANDYrr = 11034,

        VPANDrm = 11035,

        VPANDrr = 11036,

        VPAVGBYrm = 11037,

        VPAVGBYrr = 11038,

        VPAVGBZ128rm = 11039,

        VPAVGBZ128rmk = 11040,

        VPAVGBZ128rmkz = 11041,

        VPAVGBZ128rr = 11042,

        VPAVGBZ128rrk = 11043,

        VPAVGBZ128rrkz = 11044,

        VPAVGBZ256rm = 11045,

        VPAVGBZ256rmk = 11046,

        VPAVGBZ256rmkz = 11047,

        VPAVGBZ256rr = 11048,

        VPAVGBZ256rrk = 11049,

        VPAVGBZ256rrkz = 11050,

        VPAVGBZrm = 11051,

        VPAVGBZrmk = 11052,

        VPAVGBZrmkz = 11053,

        VPAVGBZrr = 11054,

        VPAVGBZrrk = 11055,

        VPAVGBZrrkz = 11056,

        VPAVGBrm = 11057,

        VPAVGBrr = 11058,

        VPAVGWYrm = 11059,

        VPAVGWYrr = 11060,

        VPAVGWZ128rm = 11061,

        VPAVGWZ128rmk = 11062,

        VPAVGWZ128rmkz = 11063,

        VPAVGWZ128rr = 11064,

        VPAVGWZ128rrk = 11065,

        VPAVGWZ128rrkz = 11066,

        VPAVGWZ256rm = 11067,

        VPAVGWZ256rmk = 11068,

        VPAVGWZ256rmkz = 11069,

        VPAVGWZ256rr = 11070,

        VPAVGWZ256rrk = 11071,

        VPAVGWZ256rrkz = 11072,

        VPAVGWZrm = 11073,

        VPAVGWZrmk = 11074,

        VPAVGWZrmkz = 11075,

        VPAVGWZrr = 11076,

        VPAVGWZrrk = 11077,

        VPAVGWZrrkz = 11078,

        VPAVGWrm = 11079,

        VPAVGWrr = 11080,

        VPBLENDDYrmi = 11081,

        VPBLENDDYrri = 11082,

        VPBLENDDrmi = 11083,

        VPBLENDDrri = 11084,

        VPBLENDMBZ128rm = 11085,

        VPBLENDMBZ128rmk = 11086,

        VPBLENDMBZ128rmkz = 11087,

        VPBLENDMBZ128rr = 11088,

        VPBLENDMBZ128rrk = 11089,

        VPBLENDMBZ128rrkz = 11090,

        VPBLENDMBZ256rm = 11091,

        VPBLENDMBZ256rmk = 11092,

        VPBLENDMBZ256rmkz = 11093,

        VPBLENDMBZ256rr = 11094,

        VPBLENDMBZ256rrk = 11095,

        VPBLENDMBZ256rrkz = 11096,

        VPBLENDMBZrm = 11097,

        VPBLENDMBZrmk = 11098,

        VPBLENDMBZrmkz = 11099,

        VPBLENDMBZrr = 11100,

        VPBLENDMBZrrk = 11101,

        VPBLENDMBZrrkz = 11102,

        VPBLENDMDZ128rm = 11103,

        VPBLENDMDZ128rmb = 11104,

        VPBLENDMDZ128rmbk = 11105,

        VPBLENDMDZ128rmbkz = 11106,

        VPBLENDMDZ128rmk = 11107,

        VPBLENDMDZ128rmkz = 11108,

        VPBLENDMDZ128rr = 11109,

        VPBLENDMDZ128rrk = 11110,

        VPBLENDMDZ128rrkz = 11111,

        VPBLENDMDZ256rm = 11112,

        VPBLENDMDZ256rmb = 11113,

        VPBLENDMDZ256rmbk = 11114,

        VPBLENDMDZ256rmbkz = 11115,

        VPBLENDMDZ256rmk = 11116,

        VPBLENDMDZ256rmkz = 11117,

        VPBLENDMDZ256rr = 11118,

        VPBLENDMDZ256rrk = 11119,

        VPBLENDMDZ256rrkz = 11120,

        VPBLENDMDZrm = 11121,

        VPBLENDMDZrmb = 11122,

        VPBLENDMDZrmbk = 11123,

        VPBLENDMDZrmbkz = 11124,

        VPBLENDMDZrmk = 11125,

        VPBLENDMDZrmkz = 11126,

        VPBLENDMDZrr = 11127,

        VPBLENDMDZrrk = 11128,

        VPBLENDMDZrrkz = 11129,

        VPBLENDMQZ128rm = 11130,

        VPBLENDMQZ128rmb = 11131,

        VPBLENDMQZ128rmbk = 11132,

        VPBLENDMQZ128rmbkz = 11133,

        VPBLENDMQZ128rmk = 11134,

        VPBLENDMQZ128rmkz = 11135,

        VPBLENDMQZ128rr = 11136,

        VPBLENDMQZ128rrk = 11137,

        VPBLENDMQZ128rrkz = 11138,

        VPBLENDMQZ256rm = 11139,

        VPBLENDMQZ256rmb = 11140,

        VPBLENDMQZ256rmbk = 11141,

        VPBLENDMQZ256rmbkz = 11142,

        VPBLENDMQZ256rmk = 11143,

        VPBLENDMQZ256rmkz = 11144,

        VPBLENDMQZ256rr = 11145,

        VPBLENDMQZ256rrk = 11146,

        VPBLENDMQZ256rrkz = 11147,

        VPBLENDMQZrm = 11148,

        VPBLENDMQZrmb = 11149,

        VPBLENDMQZrmbk = 11150,

        VPBLENDMQZrmbkz = 11151,

        VPBLENDMQZrmk = 11152,

        VPBLENDMQZrmkz = 11153,

        VPBLENDMQZrr = 11154,

        VPBLENDMQZrrk = 11155,

        VPBLENDMQZrrkz = 11156,

        VPBLENDMWZ128rm = 11157,

        VPBLENDMWZ128rmk = 11158,

        VPBLENDMWZ128rmkz = 11159,

        VPBLENDMWZ128rr = 11160,

        VPBLENDMWZ128rrk = 11161,

        VPBLENDMWZ128rrkz = 11162,

        VPBLENDMWZ256rm = 11163,

        VPBLENDMWZ256rmk = 11164,

        VPBLENDMWZ256rmkz = 11165,

        VPBLENDMWZ256rr = 11166,

        VPBLENDMWZ256rrk = 11167,

        VPBLENDMWZ256rrkz = 11168,

        VPBLENDMWZrm = 11169,

        VPBLENDMWZrmk = 11170,

        VPBLENDMWZrmkz = 11171,

        VPBLENDMWZrr = 11172,

        VPBLENDMWZrrk = 11173,

        VPBLENDMWZrrkz = 11174,

        VPBLENDVBYrm = 11175,

        VPBLENDVBYrr = 11176,

        VPBLENDVBrm = 11177,

        VPBLENDVBrr = 11178,

        VPBLENDWYrmi = 11179,

        VPBLENDWYrri = 11180,

        VPBLENDWrmi = 11181,

        VPBLENDWrri = 11182,

        VPBROADCASTBYrm = 11183,

        VPBROADCASTBYrr = 11184,

        VPBROADCASTBZ128rm = 11185,

        VPBROADCASTBZ128rmk = 11186,

        VPBROADCASTBZ128rmkz = 11187,

        VPBROADCASTBZ128rr = 11188,

        VPBROADCASTBZ128rrk = 11189,

        VPBROADCASTBZ128rrkz = 11190,

        VPBROADCASTBZ256rm = 11191,

        VPBROADCASTBZ256rmk = 11192,

        VPBROADCASTBZ256rmkz = 11193,

        VPBROADCASTBZ256rr = 11194,

        VPBROADCASTBZ256rrk = 11195,

        VPBROADCASTBZ256rrkz = 11196,

        VPBROADCASTBZrm = 11197,

        VPBROADCASTBZrmk = 11198,

        VPBROADCASTBZrmkz = 11199,

        VPBROADCASTBZrr = 11200,

        VPBROADCASTBZrrk = 11201,

        VPBROADCASTBZrrkz = 11202,

        VPBROADCASTBrZ128rr = 11203,

        VPBROADCASTBrZ128rrk = 11204,

        VPBROADCASTBrZ128rrkz = 11205,

        VPBROADCASTBrZ256rr = 11206,

        VPBROADCASTBrZ256rrk = 11207,

        VPBROADCASTBrZ256rrkz = 11208,

        VPBROADCASTBrZrr = 11209,

        VPBROADCASTBrZrrk = 11210,

        VPBROADCASTBrZrrkz = 11211,

        VPBROADCASTBrm = 11212,

        VPBROADCASTBrr = 11213,

        VPBROADCASTDYrm = 11214,

        VPBROADCASTDYrr = 11215,

        VPBROADCASTDZ128rm = 11216,

        VPBROADCASTDZ128rmk = 11217,

        VPBROADCASTDZ128rmkz = 11218,

        VPBROADCASTDZ128rr = 11219,

        VPBROADCASTDZ128rrk = 11220,

        VPBROADCASTDZ128rrkz = 11221,

        VPBROADCASTDZ256rm = 11222,

        VPBROADCASTDZ256rmk = 11223,

        VPBROADCASTDZ256rmkz = 11224,

        VPBROADCASTDZ256rr = 11225,

        VPBROADCASTDZ256rrk = 11226,

        VPBROADCASTDZ256rrkz = 11227,

        VPBROADCASTDZrm = 11228,

        VPBROADCASTDZrmk = 11229,

        VPBROADCASTDZrmkz = 11230,

        VPBROADCASTDZrr = 11231,

        VPBROADCASTDZrrk = 11232,

        VPBROADCASTDZrrkz = 11233,

        VPBROADCASTDrZ128rr = 11234,

        VPBROADCASTDrZ128rrk = 11235,

        VPBROADCASTDrZ128rrkz = 11236,

        VPBROADCASTDrZ256rr = 11237,

        VPBROADCASTDrZ256rrk = 11238,

        VPBROADCASTDrZ256rrkz = 11239,

        VPBROADCASTDrZrr = 11240,

        VPBROADCASTDrZrrk = 11241,

        VPBROADCASTDrZrrkz = 11242,

        VPBROADCASTDrm = 11243,

        VPBROADCASTDrr = 11244,

        VPBROADCASTMB2QZ128rr = 11245,

        VPBROADCASTMB2QZ256rr = 11246,

        VPBROADCASTMB2QZrr = 11247,

        VPBROADCASTMW2DZ128rr = 11248,

        VPBROADCASTMW2DZ256rr = 11249,

        VPBROADCASTMW2DZrr = 11250,

        VPBROADCASTQYrm = 11251,

        VPBROADCASTQYrr = 11252,

        VPBROADCASTQZ128rm = 11253,

        VPBROADCASTQZ128rmk = 11254,

        VPBROADCASTQZ128rmkz = 11255,

        VPBROADCASTQZ128rr = 11256,

        VPBROADCASTQZ128rrk = 11257,

        VPBROADCASTQZ128rrkz = 11258,

        VPBROADCASTQZ256rm = 11259,

        VPBROADCASTQZ256rmk = 11260,

        VPBROADCASTQZ256rmkz = 11261,

        VPBROADCASTQZ256rr = 11262,

        VPBROADCASTQZ256rrk = 11263,

        VPBROADCASTQZ256rrkz = 11264,

        VPBROADCASTQZrm = 11265,

        VPBROADCASTQZrmk = 11266,

        VPBROADCASTQZrmkz = 11267,

        VPBROADCASTQZrr = 11268,

        VPBROADCASTQZrrk = 11269,

        VPBROADCASTQZrrkz = 11270,

        VPBROADCASTQrZ128rr = 11271,

        VPBROADCASTQrZ128rrk = 11272,

        VPBROADCASTQrZ128rrkz = 11273,

        VPBROADCASTQrZ256rr = 11274,

        VPBROADCASTQrZ256rrk = 11275,

        VPBROADCASTQrZ256rrkz = 11276,

        VPBROADCASTQrZrr = 11277,

        VPBROADCASTQrZrrk = 11278,

        VPBROADCASTQrZrrkz = 11279,

        VPBROADCASTQrm = 11280,

        VPBROADCASTQrr = 11281,

        VPBROADCASTWYrm = 11282,

        VPBROADCASTWYrr = 11283,

        VPBROADCASTWZ128rm = 11284,

        VPBROADCASTWZ128rmk = 11285,

        VPBROADCASTWZ128rmkz = 11286,

        VPBROADCASTWZ128rr = 11287,

        VPBROADCASTWZ128rrk = 11288,

        VPBROADCASTWZ128rrkz = 11289,

        VPBROADCASTWZ256rm = 11290,

        VPBROADCASTWZ256rmk = 11291,

        VPBROADCASTWZ256rmkz = 11292,

        VPBROADCASTWZ256rr = 11293,

        VPBROADCASTWZ256rrk = 11294,

        VPBROADCASTWZ256rrkz = 11295,

        VPBROADCASTWZrm = 11296,

        VPBROADCASTWZrmk = 11297,

        VPBROADCASTWZrmkz = 11298,

        VPBROADCASTWZrr = 11299,

        VPBROADCASTWZrrk = 11300,

        VPBROADCASTWZrrkz = 11301,

        VPBROADCASTWrZ128rr = 11302,

        VPBROADCASTWrZ128rrk = 11303,

        VPBROADCASTWrZ128rrkz = 11304,

        VPBROADCASTWrZ256rr = 11305,

        VPBROADCASTWrZ256rrk = 11306,

        VPBROADCASTWrZ256rrkz = 11307,

        VPBROADCASTWrZrr = 11308,

        VPBROADCASTWrZrrk = 11309,

        VPBROADCASTWrZrrkz = 11310,

        VPBROADCASTWrm = 11311,

        VPBROADCASTWrr = 11312,

        VPCLMULQDQYrm = 11313,

        VPCLMULQDQYrr = 11314,

        VPCLMULQDQZ128rm = 11315,

        VPCLMULQDQZ128rr = 11316,

        VPCLMULQDQZ256rm = 11317,

        VPCLMULQDQZ256rr = 11318,

        VPCLMULQDQZrm = 11319,

        VPCLMULQDQZrr = 11320,

        VPCLMULQDQrm = 11321,

        VPCLMULQDQrr = 11322,

        VPCMOVYrmr = 11323,

        VPCMOVYrrm = 11324,

        VPCMOVYrrr = 11325,

        VPCMOVYrrr_REV = 11326,

        VPCMOVrmr = 11327,

        VPCMOVrrm = 11328,

        VPCMOVrrr = 11329,

        VPCMOVrrr_REV = 11330,

        VPCMPBZ128rmi = 11331,

        VPCMPBZ128rmik = 11332,

        VPCMPBZ128rri = 11333,

        VPCMPBZ128rrik = 11334,

        VPCMPBZ256rmi = 11335,

        VPCMPBZ256rmik = 11336,

        VPCMPBZ256rri = 11337,

        VPCMPBZ256rrik = 11338,

        VPCMPBZrmi = 11339,

        VPCMPBZrmik = 11340,

        VPCMPBZrri = 11341,

        VPCMPBZrrik = 11342,

        VPCMPDZ128rmi = 11343,

        VPCMPDZ128rmib = 11344,

        VPCMPDZ128rmibk = 11345,

        VPCMPDZ128rmik = 11346,

        VPCMPDZ128rri = 11347,

        VPCMPDZ128rrik = 11348,

        VPCMPDZ256rmi = 11349,

        VPCMPDZ256rmib = 11350,

        VPCMPDZ256rmibk = 11351,

        VPCMPDZ256rmik = 11352,

        VPCMPDZ256rri = 11353,

        VPCMPDZ256rrik = 11354,

        VPCMPDZrmi = 11355,

        VPCMPDZrmib = 11356,

        VPCMPDZrmibk = 11357,

        VPCMPDZrmik = 11358,

        VPCMPDZrri = 11359,

        VPCMPDZrrik = 11360,

        VPCMPEQBYrm = 11361,

        VPCMPEQBYrr = 11362,

        VPCMPEQBZ128rm = 11363,

        VPCMPEQBZ128rmk = 11364,

        VPCMPEQBZ128rr = 11365,

        VPCMPEQBZ128rrk = 11366,

        VPCMPEQBZ256rm = 11367,

        VPCMPEQBZ256rmk = 11368,

        VPCMPEQBZ256rr = 11369,

        VPCMPEQBZ256rrk = 11370,

        VPCMPEQBZrm = 11371,

        VPCMPEQBZrmk = 11372,

        VPCMPEQBZrr = 11373,

        VPCMPEQBZrrk = 11374,

        VPCMPEQBrm = 11375,

        VPCMPEQBrr = 11376,

        VPCMPEQDYrm = 11377,

        VPCMPEQDYrr = 11378,

        VPCMPEQDZ128rm = 11379,

        VPCMPEQDZ128rmb = 11380,

        VPCMPEQDZ128rmbk = 11381,

        VPCMPEQDZ128rmk = 11382,

        VPCMPEQDZ128rr = 11383,

        VPCMPEQDZ128rrk = 11384,

        VPCMPEQDZ256rm = 11385,

        VPCMPEQDZ256rmb = 11386,

        VPCMPEQDZ256rmbk = 11387,

        VPCMPEQDZ256rmk = 11388,

        VPCMPEQDZ256rr = 11389,

        VPCMPEQDZ256rrk = 11390,

        VPCMPEQDZrm = 11391,

        VPCMPEQDZrmb = 11392,

        VPCMPEQDZrmbk = 11393,

        VPCMPEQDZrmk = 11394,

        VPCMPEQDZrr = 11395,

        VPCMPEQDZrrk = 11396,

        VPCMPEQDrm = 11397,

        VPCMPEQDrr = 11398,

        VPCMPEQQYrm = 11399,

        VPCMPEQQYrr = 11400,

        VPCMPEQQZ128rm = 11401,

        VPCMPEQQZ128rmb = 11402,

        VPCMPEQQZ128rmbk = 11403,

        VPCMPEQQZ128rmk = 11404,

        VPCMPEQQZ128rr = 11405,

        VPCMPEQQZ128rrk = 11406,

        VPCMPEQQZ256rm = 11407,

        VPCMPEQQZ256rmb = 11408,

        VPCMPEQQZ256rmbk = 11409,

        VPCMPEQQZ256rmk = 11410,

        VPCMPEQQZ256rr = 11411,

        VPCMPEQQZ256rrk = 11412,

        VPCMPEQQZrm = 11413,

        VPCMPEQQZrmb = 11414,

        VPCMPEQQZrmbk = 11415,

        VPCMPEQQZrmk = 11416,

        VPCMPEQQZrr = 11417,

        VPCMPEQQZrrk = 11418,

        VPCMPEQQrm = 11419,

        VPCMPEQQrr = 11420,

        VPCMPEQWYrm = 11421,

        VPCMPEQWYrr = 11422,

        VPCMPEQWZ128rm = 11423,

        VPCMPEQWZ128rmk = 11424,

        VPCMPEQWZ128rr = 11425,

        VPCMPEQWZ128rrk = 11426,

        VPCMPEQWZ256rm = 11427,

        VPCMPEQWZ256rmk = 11428,

        VPCMPEQWZ256rr = 11429,

        VPCMPEQWZ256rrk = 11430,

        VPCMPEQWZrm = 11431,

        VPCMPEQWZrmk = 11432,

        VPCMPEQWZrr = 11433,

        VPCMPEQWZrrk = 11434,

        VPCMPEQWrm = 11435,

        VPCMPEQWrr = 11436,

        VPCMPESTRIrm = 11437,

        VPCMPESTRIrr = 11438,

        VPCMPESTRMrm = 11439,

        VPCMPESTRMrr = 11440,

        VPCMPGTBYrm = 11441,

        VPCMPGTBYrr = 11442,

        VPCMPGTBZ128rm = 11443,

        VPCMPGTBZ128rmk = 11444,

        VPCMPGTBZ128rr = 11445,

        VPCMPGTBZ128rrk = 11446,

        VPCMPGTBZ256rm = 11447,

        VPCMPGTBZ256rmk = 11448,

        VPCMPGTBZ256rr = 11449,

        VPCMPGTBZ256rrk = 11450,

        VPCMPGTBZrm = 11451,

        VPCMPGTBZrmk = 11452,

        VPCMPGTBZrr = 11453,

        VPCMPGTBZrrk = 11454,

        VPCMPGTBrm = 11455,

        VPCMPGTBrr = 11456,

        VPCMPGTDYrm = 11457,

        VPCMPGTDYrr = 11458,

        VPCMPGTDZ128rm = 11459,

        VPCMPGTDZ128rmb = 11460,

        VPCMPGTDZ128rmbk = 11461,

        VPCMPGTDZ128rmk = 11462,

        VPCMPGTDZ128rr = 11463,

        VPCMPGTDZ128rrk = 11464,

        VPCMPGTDZ256rm = 11465,

        VPCMPGTDZ256rmb = 11466,

        VPCMPGTDZ256rmbk = 11467,

        VPCMPGTDZ256rmk = 11468,

        VPCMPGTDZ256rr = 11469,

        VPCMPGTDZ256rrk = 11470,

        VPCMPGTDZrm = 11471,

        VPCMPGTDZrmb = 11472,

        VPCMPGTDZrmbk = 11473,

        VPCMPGTDZrmk = 11474,

        VPCMPGTDZrr = 11475,

        VPCMPGTDZrrk = 11476,

        VPCMPGTDrm = 11477,

        VPCMPGTDrr = 11478,

        VPCMPGTQYrm = 11479,

        VPCMPGTQYrr = 11480,

        VPCMPGTQZ128rm = 11481,

        VPCMPGTQZ128rmb = 11482,

        VPCMPGTQZ128rmbk = 11483,

        VPCMPGTQZ128rmk = 11484,

        VPCMPGTQZ128rr = 11485,

        VPCMPGTQZ128rrk = 11486,

        VPCMPGTQZ256rm = 11487,

        VPCMPGTQZ256rmb = 11488,

        VPCMPGTQZ256rmbk = 11489,

        VPCMPGTQZ256rmk = 11490,

        VPCMPGTQZ256rr = 11491,

        VPCMPGTQZ256rrk = 11492,

        VPCMPGTQZrm = 11493,

        VPCMPGTQZrmb = 11494,

        VPCMPGTQZrmbk = 11495,

        VPCMPGTQZrmk = 11496,

        VPCMPGTQZrr = 11497,

        VPCMPGTQZrrk = 11498,

        VPCMPGTQrm = 11499,

        VPCMPGTQrr = 11500,

        VPCMPGTWYrm = 11501,

        VPCMPGTWYrr = 11502,

        VPCMPGTWZ128rm = 11503,

        VPCMPGTWZ128rmk = 11504,

        VPCMPGTWZ128rr = 11505,

        VPCMPGTWZ128rrk = 11506,

        VPCMPGTWZ256rm = 11507,

        VPCMPGTWZ256rmk = 11508,

        VPCMPGTWZ256rr = 11509,

        VPCMPGTWZ256rrk = 11510,

        VPCMPGTWZrm = 11511,

        VPCMPGTWZrmk = 11512,

        VPCMPGTWZrr = 11513,

        VPCMPGTWZrrk = 11514,

        VPCMPGTWrm = 11515,

        VPCMPGTWrr = 11516,

        VPCMPISTRIrm = 11517,

        VPCMPISTRIrr = 11518,

        VPCMPISTRMrm = 11519,

        VPCMPISTRMrr = 11520,

        VPCMPQZ128rmi = 11521,

        VPCMPQZ128rmib = 11522,

        VPCMPQZ128rmibk = 11523,

        VPCMPQZ128rmik = 11524,

        VPCMPQZ128rri = 11525,

        VPCMPQZ128rrik = 11526,

        VPCMPQZ256rmi = 11527,

        VPCMPQZ256rmib = 11528,

        VPCMPQZ256rmibk = 11529,

        VPCMPQZ256rmik = 11530,

        VPCMPQZ256rri = 11531,

        VPCMPQZ256rrik = 11532,

        VPCMPQZrmi = 11533,

        VPCMPQZrmib = 11534,

        VPCMPQZrmibk = 11535,

        VPCMPQZrmik = 11536,

        VPCMPQZrri = 11537,

        VPCMPQZrrik = 11538,

        VPCMPUBZ128rmi = 11539,

        VPCMPUBZ128rmik = 11540,

        VPCMPUBZ128rri = 11541,

        VPCMPUBZ128rrik = 11542,

        VPCMPUBZ256rmi = 11543,

        VPCMPUBZ256rmik = 11544,

        VPCMPUBZ256rri = 11545,

        VPCMPUBZ256rrik = 11546,

        VPCMPUBZrmi = 11547,

        VPCMPUBZrmik = 11548,

        VPCMPUBZrri = 11549,

        VPCMPUBZrrik = 11550,

        VPCMPUDZ128rmi = 11551,

        VPCMPUDZ128rmib = 11552,

        VPCMPUDZ128rmibk = 11553,

        VPCMPUDZ128rmik = 11554,

        VPCMPUDZ128rri = 11555,

        VPCMPUDZ128rrik = 11556,

        VPCMPUDZ256rmi = 11557,

        VPCMPUDZ256rmib = 11558,

        VPCMPUDZ256rmibk = 11559,

        VPCMPUDZ256rmik = 11560,

        VPCMPUDZ256rri = 11561,

        VPCMPUDZ256rrik = 11562,

        VPCMPUDZrmi = 11563,

        VPCMPUDZrmib = 11564,

        VPCMPUDZrmibk = 11565,

        VPCMPUDZrmik = 11566,

        VPCMPUDZrri = 11567,

        VPCMPUDZrrik = 11568,

        VPCMPUQZ128rmi = 11569,

        VPCMPUQZ128rmib = 11570,

        VPCMPUQZ128rmibk = 11571,

        VPCMPUQZ128rmik = 11572,

        VPCMPUQZ128rri = 11573,

        VPCMPUQZ128rrik = 11574,

        VPCMPUQZ256rmi = 11575,

        VPCMPUQZ256rmib = 11576,

        VPCMPUQZ256rmibk = 11577,

        VPCMPUQZ256rmik = 11578,

        VPCMPUQZ256rri = 11579,

        VPCMPUQZ256rrik = 11580,

        VPCMPUQZrmi = 11581,

        VPCMPUQZrmib = 11582,

        VPCMPUQZrmibk = 11583,

        VPCMPUQZrmik = 11584,

        VPCMPUQZrri = 11585,

        VPCMPUQZrrik = 11586,

        VPCMPUWZ128rmi = 11587,

        VPCMPUWZ128rmik = 11588,

        VPCMPUWZ128rri = 11589,

        VPCMPUWZ128rrik = 11590,

        VPCMPUWZ256rmi = 11591,

        VPCMPUWZ256rmik = 11592,

        VPCMPUWZ256rri = 11593,

        VPCMPUWZ256rrik = 11594,

        VPCMPUWZrmi = 11595,

        VPCMPUWZrmik = 11596,

        VPCMPUWZrri = 11597,

        VPCMPUWZrrik = 11598,

        VPCMPWZ128rmi = 11599,

        VPCMPWZ128rmik = 11600,

        VPCMPWZ128rri = 11601,

        VPCMPWZ128rrik = 11602,

        VPCMPWZ256rmi = 11603,

        VPCMPWZ256rmik = 11604,

        VPCMPWZ256rri = 11605,

        VPCMPWZ256rrik = 11606,

        VPCMPWZrmi = 11607,

        VPCMPWZrmik = 11608,

        VPCMPWZrri = 11609,

        VPCMPWZrrik = 11610,

        VPCOMBmi = 11611,

        VPCOMBri = 11612,

        VPCOMDmi = 11613,

        VPCOMDri = 11614,

        VPCOMPRESSBZ128mr = 11615,

        VPCOMPRESSBZ128mrk = 11616,

        VPCOMPRESSBZ128rr = 11617,

        VPCOMPRESSBZ128rrk = 11618,

        VPCOMPRESSBZ128rrkz = 11619,

        VPCOMPRESSBZ256mr = 11620,

        VPCOMPRESSBZ256mrk = 11621,

        VPCOMPRESSBZ256rr = 11622,

        VPCOMPRESSBZ256rrk = 11623,

        VPCOMPRESSBZ256rrkz = 11624,

        VPCOMPRESSBZmr = 11625,

        VPCOMPRESSBZmrk = 11626,

        VPCOMPRESSBZrr = 11627,

        VPCOMPRESSBZrrk = 11628,

        VPCOMPRESSBZrrkz = 11629,

        VPCOMPRESSDZ128mr = 11630,

        VPCOMPRESSDZ128mrk = 11631,

        VPCOMPRESSDZ128rr = 11632,

        VPCOMPRESSDZ128rrk = 11633,

        VPCOMPRESSDZ128rrkz = 11634,

        VPCOMPRESSDZ256mr = 11635,

        VPCOMPRESSDZ256mrk = 11636,

        VPCOMPRESSDZ256rr = 11637,

        VPCOMPRESSDZ256rrk = 11638,

        VPCOMPRESSDZ256rrkz = 11639,

        VPCOMPRESSDZmr = 11640,

        VPCOMPRESSDZmrk = 11641,

        VPCOMPRESSDZrr = 11642,

        VPCOMPRESSDZrrk = 11643,

        VPCOMPRESSDZrrkz = 11644,

        VPCOMPRESSQZ128mr = 11645,

        VPCOMPRESSQZ128mrk = 11646,

        VPCOMPRESSQZ128rr = 11647,

        VPCOMPRESSQZ128rrk = 11648,

        VPCOMPRESSQZ128rrkz = 11649,

        VPCOMPRESSQZ256mr = 11650,

        VPCOMPRESSQZ256mrk = 11651,

        VPCOMPRESSQZ256rr = 11652,

        VPCOMPRESSQZ256rrk = 11653,

        VPCOMPRESSQZ256rrkz = 11654,

        VPCOMPRESSQZmr = 11655,

        VPCOMPRESSQZmrk = 11656,

        VPCOMPRESSQZrr = 11657,

        VPCOMPRESSQZrrk = 11658,

        VPCOMPRESSQZrrkz = 11659,

        VPCOMPRESSWZ128mr = 11660,

        VPCOMPRESSWZ128mrk = 11661,

        VPCOMPRESSWZ128rr = 11662,

        VPCOMPRESSWZ128rrk = 11663,

        VPCOMPRESSWZ128rrkz = 11664,

        VPCOMPRESSWZ256mr = 11665,

        VPCOMPRESSWZ256mrk = 11666,

        VPCOMPRESSWZ256rr = 11667,

        VPCOMPRESSWZ256rrk = 11668,

        VPCOMPRESSWZ256rrkz = 11669,

        VPCOMPRESSWZmr = 11670,

        VPCOMPRESSWZmrk = 11671,

        VPCOMPRESSWZrr = 11672,

        VPCOMPRESSWZrrk = 11673,

        VPCOMPRESSWZrrkz = 11674,

        VPCOMQmi = 11675,

        VPCOMQri = 11676,

        VPCOMUBmi = 11677,

        VPCOMUBri = 11678,

        VPCOMUDmi = 11679,

        VPCOMUDri = 11680,

        VPCOMUQmi = 11681,

        VPCOMUQri = 11682,

        VPCOMUWmi = 11683,

        VPCOMUWri = 11684,

        VPCOMWmi = 11685,

        VPCOMWri = 11686,

        VPCONFLICTDZ128rm = 11687,

        VPCONFLICTDZ128rmb = 11688,

        VPCONFLICTDZ128rmbk = 11689,

        VPCONFLICTDZ128rmbkz = 11690,

        VPCONFLICTDZ128rmk = 11691,

        VPCONFLICTDZ128rmkz = 11692,

        VPCONFLICTDZ128rr = 11693,

        VPCONFLICTDZ128rrk = 11694,

        VPCONFLICTDZ128rrkz = 11695,

        VPCONFLICTDZ256rm = 11696,

        VPCONFLICTDZ256rmb = 11697,

        VPCONFLICTDZ256rmbk = 11698,

        VPCONFLICTDZ256rmbkz = 11699,

        VPCONFLICTDZ256rmk = 11700,

        VPCONFLICTDZ256rmkz = 11701,

        VPCONFLICTDZ256rr = 11702,

        VPCONFLICTDZ256rrk = 11703,

        VPCONFLICTDZ256rrkz = 11704,

        VPCONFLICTDZrm = 11705,

        VPCONFLICTDZrmb = 11706,

        VPCONFLICTDZrmbk = 11707,

        VPCONFLICTDZrmbkz = 11708,

        VPCONFLICTDZrmk = 11709,

        VPCONFLICTDZrmkz = 11710,

        VPCONFLICTDZrr = 11711,

        VPCONFLICTDZrrk = 11712,

        VPCONFLICTDZrrkz = 11713,

        VPCONFLICTQZ128rm = 11714,

        VPCONFLICTQZ128rmb = 11715,

        VPCONFLICTQZ128rmbk = 11716,

        VPCONFLICTQZ128rmbkz = 11717,

        VPCONFLICTQZ128rmk = 11718,

        VPCONFLICTQZ128rmkz = 11719,

        VPCONFLICTQZ128rr = 11720,

        VPCONFLICTQZ128rrk = 11721,

        VPCONFLICTQZ128rrkz = 11722,

        VPCONFLICTQZ256rm = 11723,

        VPCONFLICTQZ256rmb = 11724,

        VPCONFLICTQZ256rmbk = 11725,

        VPCONFLICTQZ256rmbkz = 11726,

        VPCONFLICTQZ256rmk = 11727,

        VPCONFLICTQZ256rmkz = 11728,

        VPCONFLICTQZ256rr = 11729,

        VPCONFLICTQZ256rrk = 11730,

        VPCONFLICTQZ256rrkz = 11731,

        VPCONFLICTQZrm = 11732,

        VPCONFLICTQZrmb = 11733,

        VPCONFLICTQZrmbk = 11734,

        VPCONFLICTQZrmbkz = 11735,

        VPCONFLICTQZrmk = 11736,

        VPCONFLICTQZrmkz = 11737,

        VPCONFLICTQZrr = 11738,

        VPCONFLICTQZrrk = 11739,

        VPCONFLICTQZrrkz = 11740,

        VPDPBUSDSYrm = 11741,

        VPDPBUSDSYrr = 11742,

        VPDPBUSDSZ128m = 11743,

        VPDPBUSDSZ128mb = 11744,

        VPDPBUSDSZ128mbk = 11745,

        VPDPBUSDSZ128mbkz = 11746,

        VPDPBUSDSZ128mk = 11747,

        VPDPBUSDSZ128mkz = 11748,

        VPDPBUSDSZ128r = 11749,

        VPDPBUSDSZ128rk = 11750,

        VPDPBUSDSZ128rkz = 11751,

        VPDPBUSDSZ256m = 11752,

        VPDPBUSDSZ256mb = 11753,

        VPDPBUSDSZ256mbk = 11754,

        VPDPBUSDSZ256mbkz = 11755,

        VPDPBUSDSZ256mk = 11756,

        VPDPBUSDSZ256mkz = 11757,

        VPDPBUSDSZ256r = 11758,

        VPDPBUSDSZ256rk = 11759,

        VPDPBUSDSZ256rkz = 11760,

        VPDPBUSDSZm = 11761,

        VPDPBUSDSZmb = 11762,

        VPDPBUSDSZmbk = 11763,

        VPDPBUSDSZmbkz = 11764,

        VPDPBUSDSZmk = 11765,

        VPDPBUSDSZmkz = 11766,

        VPDPBUSDSZr = 11767,

        VPDPBUSDSZrk = 11768,

        VPDPBUSDSZrkz = 11769,

        VPDPBUSDSrm = 11770,

        VPDPBUSDSrr = 11771,

        VPDPBUSDYrm = 11772,

        VPDPBUSDYrr = 11773,

        VPDPBUSDZ128m = 11774,

        VPDPBUSDZ128mb = 11775,

        VPDPBUSDZ128mbk = 11776,

        VPDPBUSDZ128mbkz = 11777,

        VPDPBUSDZ128mk = 11778,

        VPDPBUSDZ128mkz = 11779,

        VPDPBUSDZ128r = 11780,

        VPDPBUSDZ128rk = 11781,

        VPDPBUSDZ128rkz = 11782,

        VPDPBUSDZ256m = 11783,

        VPDPBUSDZ256mb = 11784,

        VPDPBUSDZ256mbk = 11785,

        VPDPBUSDZ256mbkz = 11786,

        VPDPBUSDZ256mk = 11787,

        VPDPBUSDZ256mkz = 11788,

        VPDPBUSDZ256r = 11789,

        VPDPBUSDZ256rk = 11790,

        VPDPBUSDZ256rkz = 11791,

        VPDPBUSDZm = 11792,

        VPDPBUSDZmb = 11793,

        VPDPBUSDZmbk = 11794,

        VPDPBUSDZmbkz = 11795,

        VPDPBUSDZmk = 11796,

        VPDPBUSDZmkz = 11797,

        VPDPBUSDZr = 11798,

        VPDPBUSDZrk = 11799,

        VPDPBUSDZrkz = 11800,

        VPDPBUSDrm = 11801,

        VPDPBUSDrr = 11802,

        VPDPWSSDSYrm = 11803,

        VPDPWSSDSYrr = 11804,

        VPDPWSSDSZ128m = 11805,

        VPDPWSSDSZ128mb = 11806,

        VPDPWSSDSZ128mbk = 11807,

        VPDPWSSDSZ128mbkz = 11808,

        VPDPWSSDSZ128mk = 11809,

        VPDPWSSDSZ128mkz = 11810,

        VPDPWSSDSZ128r = 11811,

        VPDPWSSDSZ128rk = 11812,

        VPDPWSSDSZ128rkz = 11813,

        VPDPWSSDSZ256m = 11814,

        VPDPWSSDSZ256mb = 11815,

        VPDPWSSDSZ256mbk = 11816,

        VPDPWSSDSZ256mbkz = 11817,

        VPDPWSSDSZ256mk = 11818,

        VPDPWSSDSZ256mkz = 11819,

        VPDPWSSDSZ256r = 11820,

        VPDPWSSDSZ256rk = 11821,

        VPDPWSSDSZ256rkz = 11822,

        VPDPWSSDSZm = 11823,

        VPDPWSSDSZmb = 11824,

        VPDPWSSDSZmbk = 11825,

        VPDPWSSDSZmbkz = 11826,

        VPDPWSSDSZmk = 11827,

        VPDPWSSDSZmkz = 11828,

        VPDPWSSDSZr = 11829,

        VPDPWSSDSZrk = 11830,

        VPDPWSSDSZrkz = 11831,

        VPDPWSSDSrm = 11832,

        VPDPWSSDSrr = 11833,

        VPDPWSSDYrm = 11834,

        VPDPWSSDYrr = 11835,

        VPDPWSSDZ128m = 11836,

        VPDPWSSDZ128mb = 11837,

        VPDPWSSDZ128mbk = 11838,

        VPDPWSSDZ128mbkz = 11839,

        VPDPWSSDZ128mk = 11840,

        VPDPWSSDZ128mkz = 11841,

        VPDPWSSDZ128r = 11842,

        VPDPWSSDZ128rk = 11843,

        VPDPWSSDZ128rkz = 11844,

        VPDPWSSDZ256m = 11845,

        VPDPWSSDZ256mb = 11846,

        VPDPWSSDZ256mbk = 11847,

        VPDPWSSDZ256mbkz = 11848,

        VPDPWSSDZ256mk = 11849,

        VPDPWSSDZ256mkz = 11850,

        VPDPWSSDZ256r = 11851,

        VPDPWSSDZ256rk = 11852,

        VPDPWSSDZ256rkz = 11853,

        VPDPWSSDZm = 11854,

        VPDPWSSDZmb = 11855,

        VPDPWSSDZmbk = 11856,

        VPDPWSSDZmbkz = 11857,

        VPDPWSSDZmk = 11858,

        VPDPWSSDZmkz = 11859,

        VPDPWSSDZr = 11860,

        VPDPWSSDZrk = 11861,

        VPDPWSSDZrkz = 11862,

        VPDPWSSDrm = 11863,

        VPDPWSSDrr = 11864,

        VPERM2F128rm = 11865,

        VPERM2F128rr = 11866,

        VPERM2I128rm = 11867,

        VPERM2I128rr = 11868,

        VPERMBZ128rm = 11869,

        VPERMBZ128rmk = 11870,

        VPERMBZ128rmkz = 11871,

        VPERMBZ128rr = 11872,

        VPERMBZ128rrk = 11873,

        VPERMBZ128rrkz = 11874,

        VPERMBZ256rm = 11875,

        VPERMBZ256rmk = 11876,

        VPERMBZ256rmkz = 11877,

        VPERMBZ256rr = 11878,

        VPERMBZ256rrk = 11879,

        VPERMBZ256rrkz = 11880,

        VPERMBZrm = 11881,

        VPERMBZrmk = 11882,

        VPERMBZrmkz = 11883,

        VPERMBZrr = 11884,

        VPERMBZrrk = 11885,

        VPERMBZrrkz = 11886,

        VPERMDYrm = 11887,

        VPERMDYrr = 11888,

        VPERMDZ256rm = 11889,

        VPERMDZ256rmb = 11890,

        VPERMDZ256rmbk = 11891,

        VPERMDZ256rmbkz = 11892,

        VPERMDZ256rmk = 11893,

        VPERMDZ256rmkz = 11894,

        VPERMDZ256rr = 11895,

        VPERMDZ256rrk = 11896,

        VPERMDZ256rrkz = 11897,

        VPERMDZrm = 11898,

        VPERMDZrmb = 11899,

        VPERMDZrmbk = 11900,

        VPERMDZrmbkz = 11901,

        VPERMDZrmk = 11902,

        VPERMDZrmkz = 11903,

        VPERMDZrr = 11904,

        VPERMDZrrk = 11905,

        VPERMDZrrkz = 11906,

        VPERMI2B128rm = 11907,

        VPERMI2B128rmk = 11908,

        VPERMI2B128rmkz = 11909,

        VPERMI2B128rr = 11910,

        VPERMI2B128rrk = 11911,

        VPERMI2B128rrkz = 11912,

        VPERMI2B256rm = 11913,

        VPERMI2B256rmk = 11914,

        VPERMI2B256rmkz = 11915,

        VPERMI2B256rr = 11916,

        VPERMI2B256rrk = 11917,

        VPERMI2B256rrkz = 11918,

        VPERMI2Brm = 11919,

        VPERMI2Brmk = 11920,

        VPERMI2Brmkz = 11921,

        VPERMI2Brr = 11922,

        VPERMI2Brrk = 11923,

        VPERMI2Brrkz = 11924,

        VPERMI2D128rm = 11925,

        VPERMI2D128rmb = 11926,

        VPERMI2D128rmbk = 11927,

        VPERMI2D128rmbkz = 11928,

        VPERMI2D128rmk = 11929,

        VPERMI2D128rmkz = 11930,

        VPERMI2D128rr = 11931,

        VPERMI2D128rrk = 11932,

        VPERMI2D128rrkz = 11933,

        VPERMI2D256rm = 11934,

        VPERMI2D256rmb = 11935,

        VPERMI2D256rmbk = 11936,

        VPERMI2D256rmbkz = 11937,

        VPERMI2D256rmk = 11938,

        VPERMI2D256rmkz = 11939,

        VPERMI2D256rr = 11940,

        VPERMI2D256rrk = 11941,

        VPERMI2D256rrkz = 11942,

        VPERMI2Drm = 11943,

        VPERMI2Drmb = 11944,

        VPERMI2Drmbk = 11945,

        VPERMI2Drmbkz = 11946,

        VPERMI2Drmk = 11947,

        VPERMI2Drmkz = 11948,

        VPERMI2Drr = 11949,

        VPERMI2Drrk = 11950,

        VPERMI2Drrkz = 11951,

        VPERMI2PD128rm = 11952,

        VPERMI2PD128rmb = 11953,

        VPERMI2PD128rmbk = 11954,

        VPERMI2PD128rmbkz = 11955,

        VPERMI2PD128rmk = 11956,

        VPERMI2PD128rmkz = 11957,

        VPERMI2PD128rr = 11958,

        VPERMI2PD128rrk = 11959,

        VPERMI2PD128rrkz = 11960,

        VPERMI2PD256rm = 11961,

        VPERMI2PD256rmb = 11962,

        VPERMI2PD256rmbk = 11963,

        VPERMI2PD256rmbkz = 11964,

        VPERMI2PD256rmk = 11965,

        VPERMI2PD256rmkz = 11966,

        VPERMI2PD256rr = 11967,

        VPERMI2PD256rrk = 11968,

        VPERMI2PD256rrkz = 11969,

        VPERMI2PDrm = 11970,

        VPERMI2PDrmb = 11971,

        VPERMI2PDrmbk = 11972,

        VPERMI2PDrmbkz = 11973,

        VPERMI2PDrmk = 11974,

        VPERMI2PDrmkz = 11975,

        VPERMI2PDrr = 11976,

        VPERMI2PDrrk = 11977,

        VPERMI2PDrrkz = 11978,

        VPERMI2PS128rm = 11979,

        VPERMI2PS128rmb = 11980,

        VPERMI2PS128rmbk = 11981,

        VPERMI2PS128rmbkz = 11982,

        VPERMI2PS128rmk = 11983,

        VPERMI2PS128rmkz = 11984,

        VPERMI2PS128rr = 11985,

        VPERMI2PS128rrk = 11986,

        VPERMI2PS128rrkz = 11987,

        VPERMI2PS256rm = 11988,

        VPERMI2PS256rmb = 11989,

        VPERMI2PS256rmbk = 11990,

        VPERMI2PS256rmbkz = 11991,

        VPERMI2PS256rmk = 11992,

        VPERMI2PS256rmkz = 11993,

        VPERMI2PS256rr = 11994,

        VPERMI2PS256rrk = 11995,

        VPERMI2PS256rrkz = 11996,

        VPERMI2PSrm = 11997,

        VPERMI2PSrmb = 11998,

        VPERMI2PSrmbk = 11999,

        VPERMI2PSrmbkz = 12000,

        VPERMI2PSrmk = 12001,

        VPERMI2PSrmkz = 12002,

        VPERMI2PSrr = 12003,

        VPERMI2PSrrk = 12004,

        VPERMI2PSrrkz = 12005,

        VPERMI2Q128rm = 12006,

        VPERMI2Q128rmb = 12007,

        VPERMI2Q128rmbk = 12008,

        VPERMI2Q128rmbkz = 12009,

        VPERMI2Q128rmk = 12010,

        VPERMI2Q128rmkz = 12011,

        VPERMI2Q128rr = 12012,

        VPERMI2Q128rrk = 12013,

        VPERMI2Q128rrkz = 12014,

        VPERMI2Q256rm = 12015,

        VPERMI2Q256rmb = 12016,

        VPERMI2Q256rmbk = 12017,

        VPERMI2Q256rmbkz = 12018,

        VPERMI2Q256rmk = 12019,

        VPERMI2Q256rmkz = 12020,

        VPERMI2Q256rr = 12021,

        VPERMI2Q256rrk = 12022,

        VPERMI2Q256rrkz = 12023,

        VPERMI2Qrm = 12024,

        VPERMI2Qrmb = 12025,

        VPERMI2Qrmbk = 12026,

        VPERMI2Qrmbkz = 12027,

        VPERMI2Qrmk = 12028,

        VPERMI2Qrmkz = 12029,

        VPERMI2Qrr = 12030,

        VPERMI2Qrrk = 12031,

        VPERMI2Qrrkz = 12032,

        VPERMI2W128rm = 12033,

        VPERMI2W128rmk = 12034,

        VPERMI2W128rmkz = 12035,

        VPERMI2W128rr = 12036,

        VPERMI2W128rrk = 12037,

        VPERMI2W128rrkz = 12038,

        VPERMI2W256rm = 12039,

        VPERMI2W256rmk = 12040,

        VPERMI2W256rmkz = 12041,

        VPERMI2W256rr = 12042,

        VPERMI2W256rrk = 12043,

        VPERMI2W256rrkz = 12044,

        VPERMI2Wrm = 12045,

        VPERMI2Wrmk = 12046,

        VPERMI2Wrmkz = 12047,

        VPERMI2Wrr = 12048,

        VPERMI2Wrrk = 12049,

        VPERMI2Wrrkz = 12050,

        VPERMIL2PDYmr = 12051,

        VPERMIL2PDYrm = 12052,

        VPERMIL2PDYrr = 12053,

        VPERMIL2PDYrr_REV = 12054,

        VPERMIL2PDmr = 12055,

        VPERMIL2PDrm = 12056,

        VPERMIL2PDrr = 12057,

        VPERMIL2PDrr_REV = 12058,

        VPERMIL2PSYmr = 12059,

        VPERMIL2PSYrm = 12060,

        VPERMIL2PSYrr = 12061,

        VPERMIL2PSYrr_REV = 12062,

        VPERMIL2PSmr = 12063,

        VPERMIL2PSrm = 12064,

        VPERMIL2PSrr = 12065,

        VPERMIL2PSrr_REV = 12066,

        VPERMILPDYmi = 12067,

        VPERMILPDYri = 12068,

        VPERMILPDYrm = 12069,

        VPERMILPDYrr = 12070,

        VPERMILPDZ128mbi = 12071,

        VPERMILPDZ128mbik = 12072,

        VPERMILPDZ128mbikz = 12073,

        VPERMILPDZ128mi = 12074,

        VPERMILPDZ128mik = 12075,

        VPERMILPDZ128mikz = 12076,

        VPERMILPDZ128ri = 12077,

        VPERMILPDZ128rik = 12078,

        VPERMILPDZ128rikz = 12079,

        VPERMILPDZ128rm = 12080,

        VPERMILPDZ128rmb = 12081,

        VPERMILPDZ128rmbk = 12082,

        VPERMILPDZ128rmbkz = 12083,

        VPERMILPDZ128rmk = 12084,

        VPERMILPDZ128rmkz = 12085,

        VPERMILPDZ128rr = 12086,

        VPERMILPDZ128rrk = 12087,

        VPERMILPDZ128rrkz = 12088,

        VPERMILPDZ256mbi = 12089,

        VPERMILPDZ256mbik = 12090,

        VPERMILPDZ256mbikz = 12091,

        VPERMILPDZ256mi = 12092,

        VPERMILPDZ256mik = 12093,

        VPERMILPDZ256mikz = 12094,

        VPERMILPDZ256ri = 12095,

        VPERMILPDZ256rik = 12096,

        VPERMILPDZ256rikz = 12097,

        VPERMILPDZ256rm = 12098,

        VPERMILPDZ256rmb = 12099,

        VPERMILPDZ256rmbk = 12100,

        VPERMILPDZ256rmbkz = 12101,

        VPERMILPDZ256rmk = 12102,

        VPERMILPDZ256rmkz = 12103,

        VPERMILPDZ256rr = 12104,

        VPERMILPDZ256rrk = 12105,

        VPERMILPDZ256rrkz = 12106,

        VPERMILPDZmbi = 12107,

        VPERMILPDZmbik = 12108,

        VPERMILPDZmbikz = 12109,

        VPERMILPDZmi = 12110,

        VPERMILPDZmik = 12111,

        VPERMILPDZmikz = 12112,

        VPERMILPDZri = 12113,

        VPERMILPDZrik = 12114,

        VPERMILPDZrikz = 12115,

        VPERMILPDZrm = 12116,

        VPERMILPDZrmb = 12117,

        VPERMILPDZrmbk = 12118,

        VPERMILPDZrmbkz = 12119,

        VPERMILPDZrmk = 12120,

        VPERMILPDZrmkz = 12121,

        VPERMILPDZrr = 12122,

        VPERMILPDZrrk = 12123,

        VPERMILPDZrrkz = 12124,

        VPERMILPDmi = 12125,

        VPERMILPDri = 12126,

        VPERMILPDrm = 12127,

        VPERMILPDrr = 12128,

        VPERMILPSYmi = 12129,

        VPERMILPSYri = 12130,

        VPERMILPSYrm = 12131,

        VPERMILPSYrr = 12132,

        VPERMILPSZ128mbi = 12133,

        VPERMILPSZ128mbik = 12134,

        VPERMILPSZ128mbikz = 12135,

        VPERMILPSZ128mi = 12136,

        VPERMILPSZ128mik = 12137,

        VPERMILPSZ128mikz = 12138,

        VPERMILPSZ128ri = 12139,

        VPERMILPSZ128rik = 12140,

        VPERMILPSZ128rikz = 12141,

        VPERMILPSZ128rm = 12142,

        VPERMILPSZ128rmb = 12143,

        VPERMILPSZ128rmbk = 12144,

        VPERMILPSZ128rmbkz = 12145,

        VPERMILPSZ128rmk = 12146,

        VPERMILPSZ128rmkz = 12147,

        VPERMILPSZ128rr = 12148,

        VPERMILPSZ128rrk = 12149,

        VPERMILPSZ128rrkz = 12150,

        VPERMILPSZ256mbi = 12151,

        VPERMILPSZ256mbik = 12152,

        VPERMILPSZ256mbikz = 12153,

        VPERMILPSZ256mi = 12154,

        VPERMILPSZ256mik = 12155,

        VPERMILPSZ256mikz = 12156,

        VPERMILPSZ256ri = 12157,

        VPERMILPSZ256rik = 12158,

        VPERMILPSZ256rikz = 12159,

        VPERMILPSZ256rm = 12160,

        VPERMILPSZ256rmb = 12161,

        VPERMILPSZ256rmbk = 12162,

        VPERMILPSZ256rmbkz = 12163,

        VPERMILPSZ256rmk = 12164,

        VPERMILPSZ256rmkz = 12165,

        VPERMILPSZ256rr = 12166,

        VPERMILPSZ256rrk = 12167,

        VPERMILPSZ256rrkz = 12168,

        VPERMILPSZmbi = 12169,

        VPERMILPSZmbik = 12170,

        VPERMILPSZmbikz = 12171,

        VPERMILPSZmi = 12172,

        VPERMILPSZmik = 12173,

        VPERMILPSZmikz = 12174,

        VPERMILPSZri = 12175,

        VPERMILPSZrik = 12176,

        VPERMILPSZrikz = 12177,

        VPERMILPSZrm = 12178,

        VPERMILPSZrmb = 12179,

        VPERMILPSZrmbk = 12180,

        VPERMILPSZrmbkz = 12181,

        VPERMILPSZrmk = 12182,

        VPERMILPSZrmkz = 12183,

        VPERMILPSZrr = 12184,

        VPERMILPSZrrk = 12185,

        VPERMILPSZrrkz = 12186,

        VPERMILPSmi = 12187,

        VPERMILPSri = 12188,

        VPERMILPSrm = 12189,

        VPERMILPSrr = 12190,

        VPERMPDYmi = 12191,

        VPERMPDYri = 12192,

        VPERMPDZ256mbi = 12193,

        VPERMPDZ256mbik = 12194,

        VPERMPDZ256mbikz = 12195,

        VPERMPDZ256mi = 12196,

        VPERMPDZ256mik = 12197,

        VPERMPDZ256mikz = 12198,

        VPERMPDZ256ri = 12199,

        VPERMPDZ256rik = 12200,

        VPERMPDZ256rikz = 12201,

        VPERMPDZ256rm = 12202,

        VPERMPDZ256rmb = 12203,

        VPERMPDZ256rmbk = 12204,

        VPERMPDZ256rmbkz = 12205,

        VPERMPDZ256rmk = 12206,

        VPERMPDZ256rmkz = 12207,

        VPERMPDZ256rr = 12208,

        VPERMPDZ256rrk = 12209,

        VPERMPDZ256rrkz = 12210,

        VPERMPDZmbi = 12211,

        VPERMPDZmbik = 12212,

        VPERMPDZmbikz = 12213,

        VPERMPDZmi = 12214,

        VPERMPDZmik = 12215,

        VPERMPDZmikz = 12216,

        VPERMPDZri = 12217,

        VPERMPDZrik = 12218,

        VPERMPDZrikz = 12219,

        VPERMPDZrm = 12220,

        VPERMPDZrmb = 12221,

        VPERMPDZrmbk = 12222,

        VPERMPDZrmbkz = 12223,

        VPERMPDZrmk = 12224,

        VPERMPDZrmkz = 12225,

        VPERMPDZrr = 12226,

        VPERMPDZrrk = 12227,

        VPERMPDZrrkz = 12228,

        VPERMPSYrm = 12229,

        VPERMPSYrr = 12230,

        VPERMPSZ256rm = 12231,

        VPERMPSZ256rmb = 12232,

        VPERMPSZ256rmbk = 12233,

        VPERMPSZ256rmbkz = 12234,

        VPERMPSZ256rmk = 12235,

        VPERMPSZ256rmkz = 12236,

        VPERMPSZ256rr = 12237,

        VPERMPSZ256rrk = 12238,

        VPERMPSZ256rrkz = 12239,

        VPERMPSZrm = 12240,

        VPERMPSZrmb = 12241,

        VPERMPSZrmbk = 12242,

        VPERMPSZrmbkz = 12243,

        VPERMPSZrmk = 12244,

        VPERMPSZrmkz = 12245,

        VPERMPSZrr = 12246,

        VPERMPSZrrk = 12247,

        VPERMPSZrrkz = 12248,

        VPERMQYmi = 12249,

        VPERMQYri = 12250,

        VPERMQZ256mbi = 12251,

        VPERMQZ256mbik = 12252,

        VPERMQZ256mbikz = 12253,

        VPERMQZ256mi = 12254,

        VPERMQZ256mik = 12255,

        VPERMQZ256mikz = 12256,

        VPERMQZ256ri = 12257,

        VPERMQZ256rik = 12258,

        VPERMQZ256rikz = 12259,

        VPERMQZ256rm = 12260,

        VPERMQZ256rmb = 12261,

        VPERMQZ256rmbk = 12262,

        VPERMQZ256rmbkz = 12263,

        VPERMQZ256rmk = 12264,

        VPERMQZ256rmkz = 12265,

        VPERMQZ256rr = 12266,

        VPERMQZ256rrk = 12267,

        VPERMQZ256rrkz = 12268,

        VPERMQZmbi = 12269,

        VPERMQZmbik = 12270,

        VPERMQZmbikz = 12271,

        VPERMQZmi = 12272,

        VPERMQZmik = 12273,

        VPERMQZmikz = 12274,

        VPERMQZri = 12275,

        VPERMQZrik = 12276,

        VPERMQZrikz = 12277,

        VPERMQZrm = 12278,

        VPERMQZrmb = 12279,

        VPERMQZrmbk = 12280,

        VPERMQZrmbkz = 12281,

        VPERMQZrmk = 12282,

        VPERMQZrmkz = 12283,

        VPERMQZrr = 12284,

        VPERMQZrrk = 12285,

        VPERMQZrrkz = 12286,

        VPERMT2B128rm = 12287,

        VPERMT2B128rmk = 12288,

        VPERMT2B128rmkz = 12289,

        VPERMT2B128rr = 12290,

        VPERMT2B128rrk = 12291,

        VPERMT2B128rrkz = 12292,

        VPERMT2B256rm = 12293,

        VPERMT2B256rmk = 12294,

        VPERMT2B256rmkz = 12295,

        VPERMT2B256rr = 12296,

        VPERMT2B256rrk = 12297,

        VPERMT2B256rrkz = 12298,

        VPERMT2Brm = 12299,

        VPERMT2Brmk = 12300,

        VPERMT2Brmkz = 12301,

        VPERMT2Brr = 12302,

        VPERMT2Brrk = 12303,

        VPERMT2Brrkz = 12304,

        VPERMT2D128rm = 12305,

        VPERMT2D128rmb = 12306,

        VPERMT2D128rmbk = 12307,

        VPERMT2D128rmbkz = 12308,

        VPERMT2D128rmk = 12309,

        VPERMT2D128rmkz = 12310,

        VPERMT2D128rr = 12311,

        VPERMT2D128rrk = 12312,

        VPERMT2D128rrkz = 12313,

        VPERMT2D256rm = 12314,

        VPERMT2D256rmb = 12315,

        VPERMT2D256rmbk = 12316,

        VPERMT2D256rmbkz = 12317,

        VPERMT2D256rmk = 12318,

        VPERMT2D256rmkz = 12319,

        VPERMT2D256rr = 12320,

        VPERMT2D256rrk = 12321,

        VPERMT2D256rrkz = 12322,

        VPERMT2Drm = 12323,

        VPERMT2Drmb = 12324,

        VPERMT2Drmbk = 12325,

        VPERMT2Drmbkz = 12326,

        VPERMT2Drmk = 12327,

        VPERMT2Drmkz = 12328,

        VPERMT2Drr = 12329,

        VPERMT2Drrk = 12330,

        VPERMT2Drrkz = 12331,

        VPERMT2PD128rm = 12332,

        VPERMT2PD128rmb = 12333,

        VPERMT2PD128rmbk = 12334,

        VPERMT2PD128rmbkz = 12335,

        VPERMT2PD128rmk = 12336,

        VPERMT2PD128rmkz = 12337,

        VPERMT2PD128rr = 12338,

        VPERMT2PD128rrk = 12339,

        VPERMT2PD128rrkz = 12340,

        VPERMT2PD256rm = 12341,

        VPERMT2PD256rmb = 12342,

        VPERMT2PD256rmbk = 12343,

        VPERMT2PD256rmbkz = 12344,

        VPERMT2PD256rmk = 12345,

        VPERMT2PD256rmkz = 12346,

        VPERMT2PD256rr = 12347,

        VPERMT2PD256rrk = 12348,

        VPERMT2PD256rrkz = 12349,

        VPERMT2PDrm = 12350,

        VPERMT2PDrmb = 12351,

        VPERMT2PDrmbk = 12352,

        VPERMT2PDrmbkz = 12353,

        VPERMT2PDrmk = 12354,

        VPERMT2PDrmkz = 12355,

        VPERMT2PDrr = 12356,

        VPERMT2PDrrk = 12357,

        VPERMT2PDrrkz = 12358,

        VPERMT2PS128rm = 12359,

        VPERMT2PS128rmb = 12360,

        VPERMT2PS128rmbk = 12361,

        VPERMT2PS128rmbkz = 12362,

        VPERMT2PS128rmk = 12363,

        VPERMT2PS128rmkz = 12364,

        VPERMT2PS128rr = 12365,

        VPERMT2PS128rrk = 12366,

        VPERMT2PS128rrkz = 12367,

        VPERMT2PS256rm = 12368,

        VPERMT2PS256rmb = 12369,

        VPERMT2PS256rmbk = 12370,

        VPERMT2PS256rmbkz = 12371,

        VPERMT2PS256rmk = 12372,

        VPERMT2PS256rmkz = 12373,

        VPERMT2PS256rr = 12374,

        VPERMT2PS256rrk = 12375,

        VPERMT2PS256rrkz = 12376,

        VPERMT2PSrm = 12377,

        VPERMT2PSrmb = 12378,

        VPERMT2PSrmbk = 12379,

        VPERMT2PSrmbkz = 12380,

        VPERMT2PSrmk = 12381,

        VPERMT2PSrmkz = 12382,

        VPERMT2PSrr = 12383,

        VPERMT2PSrrk = 12384,

        VPERMT2PSrrkz = 12385,

        VPERMT2Q128rm = 12386,

        VPERMT2Q128rmb = 12387,

        VPERMT2Q128rmbk = 12388,

        VPERMT2Q128rmbkz = 12389,

        VPERMT2Q128rmk = 12390,

        VPERMT2Q128rmkz = 12391,

        VPERMT2Q128rr = 12392,

        VPERMT2Q128rrk = 12393,

        VPERMT2Q128rrkz = 12394,

        VPERMT2Q256rm = 12395,

        VPERMT2Q256rmb = 12396,

        VPERMT2Q256rmbk = 12397,

        VPERMT2Q256rmbkz = 12398,

        VPERMT2Q256rmk = 12399,

        VPERMT2Q256rmkz = 12400,

        VPERMT2Q256rr = 12401,

        VPERMT2Q256rrk = 12402,

        VPERMT2Q256rrkz = 12403,

        VPERMT2Qrm = 12404,

        VPERMT2Qrmb = 12405,

        VPERMT2Qrmbk = 12406,

        VPERMT2Qrmbkz = 12407,

        VPERMT2Qrmk = 12408,

        VPERMT2Qrmkz = 12409,

        VPERMT2Qrr = 12410,

        VPERMT2Qrrk = 12411,

        VPERMT2Qrrkz = 12412,

        VPERMT2W128rm = 12413,

        VPERMT2W128rmk = 12414,

        VPERMT2W128rmkz = 12415,

        VPERMT2W128rr = 12416,

        VPERMT2W128rrk = 12417,

        VPERMT2W128rrkz = 12418,

        VPERMT2W256rm = 12419,

        VPERMT2W256rmk = 12420,

        VPERMT2W256rmkz = 12421,

        VPERMT2W256rr = 12422,

        VPERMT2W256rrk = 12423,

        VPERMT2W256rrkz = 12424,

        VPERMT2Wrm = 12425,

        VPERMT2Wrmk = 12426,

        VPERMT2Wrmkz = 12427,

        VPERMT2Wrr = 12428,

        VPERMT2Wrrk = 12429,

        VPERMT2Wrrkz = 12430,

        VPERMWZ128rm = 12431,

        VPERMWZ128rmk = 12432,

        VPERMWZ128rmkz = 12433,

        VPERMWZ128rr = 12434,

        VPERMWZ128rrk = 12435,

        VPERMWZ128rrkz = 12436,

        VPERMWZ256rm = 12437,

        VPERMWZ256rmk = 12438,

        VPERMWZ256rmkz = 12439,

        VPERMWZ256rr = 12440,

        VPERMWZ256rrk = 12441,

        VPERMWZ256rrkz = 12442,

        VPERMWZrm = 12443,

        VPERMWZrmk = 12444,

        VPERMWZrmkz = 12445,

        VPERMWZrr = 12446,

        VPERMWZrrk = 12447,

        VPERMWZrrkz = 12448,

        VPEXPANDBZ128rm = 12449,

        VPEXPANDBZ128rmk = 12450,

        VPEXPANDBZ128rmkz = 12451,

        VPEXPANDBZ128rr = 12452,

        VPEXPANDBZ128rrk = 12453,

        VPEXPANDBZ128rrkz = 12454,

        VPEXPANDBZ256rm = 12455,

        VPEXPANDBZ256rmk = 12456,

        VPEXPANDBZ256rmkz = 12457,

        VPEXPANDBZ256rr = 12458,

        VPEXPANDBZ256rrk = 12459,

        VPEXPANDBZ256rrkz = 12460,

        VPEXPANDBZrm = 12461,

        VPEXPANDBZrmk = 12462,

        VPEXPANDBZrmkz = 12463,

        VPEXPANDBZrr = 12464,

        VPEXPANDBZrrk = 12465,

        VPEXPANDBZrrkz = 12466,

        VPEXPANDDZ128rm = 12467,

        VPEXPANDDZ128rmk = 12468,

        VPEXPANDDZ128rmkz = 12469,

        VPEXPANDDZ128rr = 12470,

        VPEXPANDDZ128rrk = 12471,

        VPEXPANDDZ128rrkz = 12472,

        VPEXPANDDZ256rm = 12473,

        VPEXPANDDZ256rmk = 12474,

        VPEXPANDDZ256rmkz = 12475,

        VPEXPANDDZ256rr = 12476,

        VPEXPANDDZ256rrk = 12477,

        VPEXPANDDZ256rrkz = 12478,

        VPEXPANDDZrm = 12479,

        VPEXPANDDZrmk = 12480,

        VPEXPANDDZrmkz = 12481,

        VPEXPANDDZrr = 12482,

        VPEXPANDDZrrk = 12483,

        VPEXPANDDZrrkz = 12484,

        VPEXPANDQZ128rm = 12485,

        VPEXPANDQZ128rmk = 12486,

        VPEXPANDQZ128rmkz = 12487,

        VPEXPANDQZ128rr = 12488,

        VPEXPANDQZ128rrk = 12489,

        VPEXPANDQZ128rrkz = 12490,

        VPEXPANDQZ256rm = 12491,

        VPEXPANDQZ256rmk = 12492,

        VPEXPANDQZ256rmkz = 12493,

        VPEXPANDQZ256rr = 12494,

        VPEXPANDQZ256rrk = 12495,

        VPEXPANDQZ256rrkz = 12496,

        VPEXPANDQZrm = 12497,

        VPEXPANDQZrmk = 12498,

        VPEXPANDQZrmkz = 12499,

        VPEXPANDQZrr = 12500,

        VPEXPANDQZrrk = 12501,

        VPEXPANDQZrrkz = 12502,

        VPEXPANDWZ128rm = 12503,

        VPEXPANDWZ128rmk = 12504,

        VPEXPANDWZ128rmkz = 12505,

        VPEXPANDWZ128rr = 12506,

        VPEXPANDWZ128rrk = 12507,

        VPEXPANDWZ128rrkz = 12508,

        VPEXPANDWZ256rm = 12509,

        VPEXPANDWZ256rmk = 12510,

        VPEXPANDWZ256rmkz = 12511,

        VPEXPANDWZ256rr = 12512,

        VPEXPANDWZ256rrk = 12513,

        VPEXPANDWZ256rrkz = 12514,

        VPEXPANDWZrm = 12515,

        VPEXPANDWZrmk = 12516,

        VPEXPANDWZrmkz = 12517,

        VPEXPANDWZrr = 12518,

        VPEXPANDWZrrk = 12519,

        VPEXPANDWZrrkz = 12520,

        VPEXTRBZmr = 12521,

        VPEXTRBZrr = 12522,

        VPEXTRBmr = 12523,

        VPEXTRBrr = 12524,

        VPEXTRDZmr = 12525,

        VPEXTRDZrr = 12526,

        VPEXTRDmr = 12527,

        VPEXTRDrr = 12528,

        VPEXTRQZmr = 12529,

        VPEXTRQZrr = 12530,

        VPEXTRQmr = 12531,

        VPEXTRQrr = 12532,

        VPEXTRWZmr = 12533,

        VPEXTRWZrr = 12534,

        VPEXTRWZrr_REV = 12535,

        VPEXTRWmr = 12536,

        VPEXTRWrr = 12537,

        VPEXTRWrr_REV = 12538,

        VPGATHERDDYrm = 12539,

        VPGATHERDDZ128rm = 12540,

        VPGATHERDDZ256rm = 12541,

        VPGATHERDDZrm = 12542,

        VPGATHERDDrm = 12543,

        VPGATHERDQYrm = 12544,

        VPGATHERDQZ128rm = 12545,

        VPGATHERDQZ256rm = 12546,

        VPGATHERDQZrm = 12547,

        VPGATHERDQrm = 12548,

        VPGATHERQDYrm = 12549,

        VPGATHERQDZ128rm = 12550,

        VPGATHERQDZ256rm = 12551,

        VPGATHERQDZrm = 12552,

        VPGATHERQDrm = 12553,

        VPGATHERQQYrm = 12554,

        VPGATHERQQZ128rm = 12555,

        VPGATHERQQZ256rm = 12556,

        VPGATHERQQZrm = 12557,

        VPGATHERQQrm = 12558,

        VPHADDBDrm = 12559,

        VPHADDBDrr = 12560,

        VPHADDBQrm = 12561,

        VPHADDBQrr = 12562,

        VPHADDBWrm = 12563,

        VPHADDBWrr = 12564,

        VPHADDDQrm = 12565,

        VPHADDDQrr = 12566,

        VPHADDDYrm = 12567,

        VPHADDDYrr = 12568,

        VPHADDDrm = 12569,

        VPHADDDrr = 12570,

        VPHADDSWYrm = 12571,

        VPHADDSWYrr = 12572,

        VPHADDSWrm = 12573,

        VPHADDSWrr = 12574,

        VPHADDUBDrm = 12575,

        VPHADDUBDrr = 12576,

        VPHADDUBQrm = 12577,

        VPHADDUBQrr = 12578,

        VPHADDUBWrm = 12579,

        VPHADDUBWrr = 12580,

        VPHADDUDQrm = 12581,

        VPHADDUDQrr = 12582,

        VPHADDUWDrm = 12583,

        VPHADDUWDrr = 12584,

        VPHADDUWQrm = 12585,

        VPHADDUWQrr = 12586,

        VPHADDWDrm = 12587,

        VPHADDWDrr = 12588,

        VPHADDWQrm = 12589,

        VPHADDWQrr = 12590,

        VPHADDWYrm = 12591,

        VPHADDWYrr = 12592,

        VPHADDWrm = 12593,

        VPHADDWrr = 12594,

        VPHMINPOSUWrm = 12595,

        VPHMINPOSUWrr = 12596,

        VPHSUBBWrm = 12597,

        VPHSUBBWrr = 12598,

        VPHSUBDQrm = 12599,

        VPHSUBDQrr = 12600,

        VPHSUBDYrm = 12601,

        VPHSUBDYrr = 12602,

        VPHSUBDrm = 12603,

        VPHSUBDrr = 12604,

        VPHSUBSWYrm = 12605,

        VPHSUBSWYrr = 12606,

        VPHSUBSWrm = 12607,

        VPHSUBSWrr = 12608,

        VPHSUBWDrm = 12609,

        VPHSUBWDrr = 12610,

        VPHSUBWYrm = 12611,

        VPHSUBWYrr = 12612,

        VPHSUBWrm = 12613,

        VPHSUBWrr = 12614,

        VPINSRBZrm = 12615,

        VPINSRBZrr = 12616,

        VPINSRBrm = 12617,

        VPINSRBrr = 12618,

        VPINSRDZrm = 12619,

        VPINSRDZrr = 12620,

        VPINSRDrm = 12621,

        VPINSRDrr = 12622,

        VPINSRQZrm = 12623,

        VPINSRQZrr = 12624,

        VPINSRQrm = 12625,

        VPINSRQrr = 12626,

        VPINSRWZrm = 12627,

        VPINSRWZrr = 12628,

        VPINSRWrm = 12629,

        VPINSRWrr = 12630,

        VPLZCNTDZ128rm = 12631,

        VPLZCNTDZ128rmb = 12632,

        VPLZCNTDZ128rmbk = 12633,

        VPLZCNTDZ128rmbkz = 12634,

        VPLZCNTDZ128rmk = 12635,

        VPLZCNTDZ128rmkz = 12636,

        VPLZCNTDZ128rr = 12637,

        VPLZCNTDZ128rrk = 12638,

        VPLZCNTDZ128rrkz = 12639,

        VPLZCNTDZ256rm = 12640,

        VPLZCNTDZ256rmb = 12641,

        VPLZCNTDZ256rmbk = 12642,

        VPLZCNTDZ256rmbkz = 12643,

        VPLZCNTDZ256rmk = 12644,

        VPLZCNTDZ256rmkz = 12645,

        VPLZCNTDZ256rr = 12646,

        VPLZCNTDZ256rrk = 12647,

        VPLZCNTDZ256rrkz = 12648,

        VPLZCNTDZrm = 12649,

        VPLZCNTDZrmb = 12650,

        VPLZCNTDZrmbk = 12651,

        VPLZCNTDZrmbkz = 12652,

        VPLZCNTDZrmk = 12653,

        VPLZCNTDZrmkz = 12654,

        VPLZCNTDZrr = 12655,

        VPLZCNTDZrrk = 12656,

        VPLZCNTDZrrkz = 12657,

        VPLZCNTQZ128rm = 12658,

        VPLZCNTQZ128rmb = 12659,

        VPLZCNTQZ128rmbk = 12660,

        VPLZCNTQZ128rmbkz = 12661,

        VPLZCNTQZ128rmk = 12662,

        VPLZCNTQZ128rmkz = 12663,

        VPLZCNTQZ128rr = 12664,

        VPLZCNTQZ128rrk = 12665,

        VPLZCNTQZ128rrkz = 12666,

        VPLZCNTQZ256rm = 12667,

        VPLZCNTQZ256rmb = 12668,

        VPLZCNTQZ256rmbk = 12669,

        VPLZCNTQZ256rmbkz = 12670,

        VPLZCNTQZ256rmk = 12671,

        VPLZCNTQZ256rmkz = 12672,

        VPLZCNTQZ256rr = 12673,

        VPLZCNTQZ256rrk = 12674,

        VPLZCNTQZ256rrkz = 12675,

        VPLZCNTQZrm = 12676,

        VPLZCNTQZrmb = 12677,

        VPLZCNTQZrmbk = 12678,

        VPLZCNTQZrmbkz = 12679,

        VPLZCNTQZrmk = 12680,

        VPLZCNTQZrmkz = 12681,

        VPLZCNTQZrr = 12682,

        VPLZCNTQZrrk = 12683,

        VPLZCNTQZrrkz = 12684,

        VPMACSDDrm = 12685,

        VPMACSDDrr = 12686,

        VPMACSDQHrm = 12687,

        VPMACSDQHrr = 12688,

        VPMACSDQLrm = 12689,

        VPMACSDQLrr = 12690,

        VPMACSSDDrm = 12691,

        VPMACSSDDrr = 12692,

        VPMACSSDQHrm = 12693,

        VPMACSSDQHrr = 12694,

        VPMACSSDQLrm = 12695,

        VPMACSSDQLrr = 12696,

        VPMACSSWDrm = 12697,

        VPMACSSWDrr = 12698,

        VPMACSSWWrm = 12699,

        VPMACSSWWrr = 12700,

        VPMACSWDrm = 12701,

        VPMACSWDrr = 12702,

        VPMACSWWrm = 12703,

        VPMACSWWrr = 12704,

        VPMADCSSWDrm = 12705,

        VPMADCSSWDrr = 12706,

        VPMADCSWDrm = 12707,

        VPMADCSWDrr = 12708,

        VPMADD52HUQZ128m = 12709,

        VPMADD52HUQZ128mb = 12710,

        VPMADD52HUQZ128mbk = 12711,

        VPMADD52HUQZ128mbkz = 12712,

        VPMADD52HUQZ128mk = 12713,

        VPMADD52HUQZ128mkz = 12714,

        VPMADD52HUQZ128r = 12715,

        VPMADD52HUQZ128rk = 12716,

        VPMADD52HUQZ128rkz = 12717,

        VPMADD52HUQZ256m = 12718,

        VPMADD52HUQZ256mb = 12719,

        VPMADD52HUQZ256mbk = 12720,

        VPMADD52HUQZ256mbkz = 12721,

        VPMADD52HUQZ256mk = 12722,

        VPMADD52HUQZ256mkz = 12723,

        VPMADD52HUQZ256r = 12724,

        VPMADD52HUQZ256rk = 12725,

        VPMADD52HUQZ256rkz = 12726,

        VPMADD52HUQZm = 12727,

        VPMADD52HUQZmb = 12728,

        VPMADD52HUQZmbk = 12729,

        VPMADD52HUQZmbkz = 12730,

        VPMADD52HUQZmk = 12731,

        VPMADD52HUQZmkz = 12732,

        VPMADD52HUQZr = 12733,

        VPMADD52HUQZrk = 12734,

        VPMADD52HUQZrkz = 12735,

        VPMADD52LUQZ128m = 12736,

        VPMADD52LUQZ128mb = 12737,

        VPMADD52LUQZ128mbk = 12738,

        VPMADD52LUQZ128mbkz = 12739,

        VPMADD52LUQZ128mk = 12740,

        VPMADD52LUQZ128mkz = 12741,

        VPMADD52LUQZ128r = 12742,

        VPMADD52LUQZ128rk = 12743,

        VPMADD52LUQZ128rkz = 12744,

        VPMADD52LUQZ256m = 12745,

        VPMADD52LUQZ256mb = 12746,

        VPMADD52LUQZ256mbk = 12747,

        VPMADD52LUQZ256mbkz = 12748,

        VPMADD52LUQZ256mk = 12749,

        VPMADD52LUQZ256mkz = 12750,

        VPMADD52LUQZ256r = 12751,

        VPMADD52LUQZ256rk = 12752,

        VPMADD52LUQZ256rkz = 12753,

        VPMADD52LUQZm = 12754,

        VPMADD52LUQZmb = 12755,

        VPMADD52LUQZmbk = 12756,

        VPMADD52LUQZmbkz = 12757,

        VPMADD52LUQZmk = 12758,

        VPMADD52LUQZmkz = 12759,

        VPMADD52LUQZr = 12760,

        VPMADD52LUQZrk = 12761,

        VPMADD52LUQZrkz = 12762,

        VPMADDUBSWYrm = 12763,

        VPMADDUBSWYrr = 12764,

        VPMADDUBSWZ128rm = 12765,

        VPMADDUBSWZ128rmk = 12766,

        VPMADDUBSWZ128rmkz = 12767,

        VPMADDUBSWZ128rr = 12768,

        VPMADDUBSWZ128rrk = 12769,

        VPMADDUBSWZ128rrkz = 12770,

        VPMADDUBSWZ256rm = 12771,

        VPMADDUBSWZ256rmk = 12772,

        VPMADDUBSWZ256rmkz = 12773,

        VPMADDUBSWZ256rr = 12774,

        VPMADDUBSWZ256rrk = 12775,

        VPMADDUBSWZ256rrkz = 12776,

        VPMADDUBSWZrm = 12777,

        VPMADDUBSWZrmk = 12778,

        VPMADDUBSWZrmkz = 12779,

        VPMADDUBSWZrr = 12780,

        VPMADDUBSWZrrk = 12781,

        VPMADDUBSWZrrkz = 12782,

        VPMADDUBSWrm = 12783,

        VPMADDUBSWrr = 12784,

        VPMADDWDYrm = 12785,

        VPMADDWDYrr = 12786,

        VPMADDWDZ128rm = 12787,

        VPMADDWDZ128rmk = 12788,

        VPMADDWDZ128rmkz = 12789,

        VPMADDWDZ128rr = 12790,

        VPMADDWDZ128rrk = 12791,

        VPMADDWDZ128rrkz = 12792,

        VPMADDWDZ256rm = 12793,

        VPMADDWDZ256rmk = 12794,

        VPMADDWDZ256rmkz = 12795,

        VPMADDWDZ256rr = 12796,

        VPMADDWDZ256rrk = 12797,

        VPMADDWDZ256rrkz = 12798,

        VPMADDWDZrm = 12799,

        VPMADDWDZrmk = 12800,

        VPMADDWDZrmkz = 12801,

        VPMADDWDZrr = 12802,

        VPMADDWDZrrk = 12803,

        VPMADDWDZrrkz = 12804,

        VPMADDWDrm = 12805,

        VPMADDWDrr = 12806,

        VPMASKMOVDYmr = 12807,

        VPMASKMOVDYrm = 12808,

        VPMASKMOVDmr = 12809,

        VPMASKMOVDrm = 12810,

        VPMASKMOVQYmr = 12811,

        VPMASKMOVQYrm = 12812,

        VPMASKMOVQmr = 12813,

        VPMASKMOVQrm = 12814,

        VPMAXSBYrm = 12815,

        VPMAXSBYrr = 12816,

        VPMAXSBZ128rm = 12817,

        VPMAXSBZ128rmk = 12818,

        VPMAXSBZ128rmkz = 12819,

        VPMAXSBZ128rr = 12820,

        VPMAXSBZ128rrk = 12821,

        VPMAXSBZ128rrkz = 12822,

        VPMAXSBZ256rm = 12823,

        VPMAXSBZ256rmk = 12824,

        VPMAXSBZ256rmkz = 12825,

        VPMAXSBZ256rr = 12826,

        VPMAXSBZ256rrk = 12827,

        VPMAXSBZ256rrkz = 12828,

        VPMAXSBZrm = 12829,

        VPMAXSBZrmk = 12830,

        VPMAXSBZrmkz = 12831,

        VPMAXSBZrr = 12832,

        VPMAXSBZrrk = 12833,

        VPMAXSBZrrkz = 12834,

        VPMAXSBrm = 12835,

        VPMAXSBrr = 12836,

        VPMAXSDYrm = 12837,

        VPMAXSDYrr = 12838,

        VPMAXSDZ128rm = 12839,

        VPMAXSDZ128rmb = 12840,

        VPMAXSDZ128rmbk = 12841,

        VPMAXSDZ128rmbkz = 12842,

        VPMAXSDZ128rmk = 12843,

        VPMAXSDZ128rmkz = 12844,

        VPMAXSDZ128rr = 12845,

        VPMAXSDZ128rrk = 12846,

        VPMAXSDZ128rrkz = 12847,

        VPMAXSDZ256rm = 12848,

        VPMAXSDZ256rmb = 12849,

        VPMAXSDZ256rmbk = 12850,

        VPMAXSDZ256rmbkz = 12851,

        VPMAXSDZ256rmk = 12852,

        VPMAXSDZ256rmkz = 12853,

        VPMAXSDZ256rr = 12854,

        VPMAXSDZ256rrk = 12855,

        VPMAXSDZ256rrkz = 12856,

        VPMAXSDZrm = 12857,

        VPMAXSDZrmb = 12858,

        VPMAXSDZrmbk = 12859,

        VPMAXSDZrmbkz = 12860,

        VPMAXSDZrmk = 12861,

        VPMAXSDZrmkz = 12862,

        VPMAXSDZrr = 12863,

        VPMAXSDZrrk = 12864,

        VPMAXSDZrrkz = 12865,

        VPMAXSDrm = 12866,

        VPMAXSDrr = 12867,

        VPMAXSQZ128rm = 12868,

        VPMAXSQZ128rmb = 12869,

        VPMAXSQZ128rmbk = 12870,

        VPMAXSQZ128rmbkz = 12871,

        VPMAXSQZ128rmk = 12872,

        VPMAXSQZ128rmkz = 12873,

        VPMAXSQZ128rr = 12874,

        VPMAXSQZ128rrk = 12875,

        VPMAXSQZ128rrkz = 12876,

        VPMAXSQZ256rm = 12877,

        VPMAXSQZ256rmb = 12878,

        VPMAXSQZ256rmbk = 12879,

        VPMAXSQZ256rmbkz = 12880,

        VPMAXSQZ256rmk = 12881,

        VPMAXSQZ256rmkz = 12882,

        VPMAXSQZ256rr = 12883,

        VPMAXSQZ256rrk = 12884,

        VPMAXSQZ256rrkz = 12885,

        VPMAXSQZrm = 12886,

        VPMAXSQZrmb = 12887,

        VPMAXSQZrmbk = 12888,

        VPMAXSQZrmbkz = 12889,

        VPMAXSQZrmk = 12890,

        VPMAXSQZrmkz = 12891,

        VPMAXSQZrr = 12892,

        VPMAXSQZrrk = 12893,

        VPMAXSQZrrkz = 12894,

        VPMAXSWYrm = 12895,

        VPMAXSWYrr = 12896,

        VPMAXSWZ128rm = 12897,

        VPMAXSWZ128rmk = 12898,

        VPMAXSWZ128rmkz = 12899,

        VPMAXSWZ128rr = 12900,

        VPMAXSWZ128rrk = 12901,

        VPMAXSWZ128rrkz = 12902,

        VPMAXSWZ256rm = 12903,

        VPMAXSWZ256rmk = 12904,

        VPMAXSWZ256rmkz = 12905,

        VPMAXSWZ256rr = 12906,

        VPMAXSWZ256rrk = 12907,

        VPMAXSWZ256rrkz = 12908,

        VPMAXSWZrm = 12909,

        VPMAXSWZrmk = 12910,

        VPMAXSWZrmkz = 12911,

        VPMAXSWZrr = 12912,

        VPMAXSWZrrk = 12913,

        VPMAXSWZrrkz = 12914,

        VPMAXSWrm = 12915,

        VPMAXSWrr = 12916,

        VPMAXUBYrm = 12917,

        VPMAXUBYrr = 12918,

        VPMAXUBZ128rm = 12919,

        VPMAXUBZ128rmk = 12920,

        VPMAXUBZ128rmkz = 12921,

        VPMAXUBZ128rr = 12922,

        VPMAXUBZ128rrk = 12923,

        VPMAXUBZ128rrkz = 12924,

        VPMAXUBZ256rm = 12925,

        VPMAXUBZ256rmk = 12926,

        VPMAXUBZ256rmkz = 12927,

        VPMAXUBZ256rr = 12928,

        VPMAXUBZ256rrk = 12929,

        VPMAXUBZ256rrkz = 12930,

        VPMAXUBZrm = 12931,

        VPMAXUBZrmk = 12932,

        VPMAXUBZrmkz = 12933,

        VPMAXUBZrr = 12934,

        VPMAXUBZrrk = 12935,

        VPMAXUBZrrkz = 12936,

        VPMAXUBrm = 12937,

        VPMAXUBrr = 12938,

        VPMAXUDYrm = 12939,

        VPMAXUDYrr = 12940,

        VPMAXUDZ128rm = 12941,

        VPMAXUDZ128rmb = 12942,

        VPMAXUDZ128rmbk = 12943,

        VPMAXUDZ128rmbkz = 12944,

        VPMAXUDZ128rmk = 12945,

        VPMAXUDZ128rmkz = 12946,

        VPMAXUDZ128rr = 12947,

        VPMAXUDZ128rrk = 12948,

        VPMAXUDZ128rrkz = 12949,

        VPMAXUDZ256rm = 12950,

        VPMAXUDZ256rmb = 12951,

        VPMAXUDZ256rmbk = 12952,

        VPMAXUDZ256rmbkz = 12953,

        VPMAXUDZ256rmk = 12954,

        VPMAXUDZ256rmkz = 12955,

        VPMAXUDZ256rr = 12956,

        VPMAXUDZ256rrk = 12957,

        VPMAXUDZ256rrkz = 12958,

        VPMAXUDZrm = 12959,

        VPMAXUDZrmb = 12960,

        VPMAXUDZrmbk = 12961,

        VPMAXUDZrmbkz = 12962,

        VPMAXUDZrmk = 12963,

        VPMAXUDZrmkz = 12964,

        VPMAXUDZrr = 12965,

        VPMAXUDZrrk = 12966,

        VPMAXUDZrrkz = 12967,

        VPMAXUDrm = 12968,

        VPMAXUDrr = 12969,

        VPMAXUQZ128rm = 12970,

        VPMAXUQZ128rmb = 12971,

        VPMAXUQZ128rmbk = 12972,

        VPMAXUQZ128rmbkz = 12973,

        VPMAXUQZ128rmk = 12974,

        VPMAXUQZ128rmkz = 12975,

        VPMAXUQZ128rr = 12976,

        VPMAXUQZ128rrk = 12977,

        VPMAXUQZ128rrkz = 12978,

        VPMAXUQZ256rm = 12979,

        VPMAXUQZ256rmb = 12980,

        VPMAXUQZ256rmbk = 12981,

        VPMAXUQZ256rmbkz = 12982,

        VPMAXUQZ256rmk = 12983,

        VPMAXUQZ256rmkz = 12984,

        VPMAXUQZ256rr = 12985,

        VPMAXUQZ256rrk = 12986,

        VPMAXUQZ256rrkz = 12987,

        VPMAXUQZrm = 12988,

        VPMAXUQZrmb = 12989,

        VPMAXUQZrmbk = 12990,

        VPMAXUQZrmbkz = 12991,

        VPMAXUQZrmk = 12992,

        VPMAXUQZrmkz = 12993,

        VPMAXUQZrr = 12994,

        VPMAXUQZrrk = 12995,

        VPMAXUQZrrkz = 12996,

        VPMAXUWYrm = 12997,

        VPMAXUWYrr = 12998,

        VPMAXUWZ128rm = 12999,

        VPMAXUWZ128rmk = 13000,

        VPMAXUWZ128rmkz = 13001,

        VPMAXUWZ128rr = 13002,

        VPMAXUWZ128rrk = 13003,

        VPMAXUWZ128rrkz = 13004,

        VPMAXUWZ256rm = 13005,

        VPMAXUWZ256rmk = 13006,

        VPMAXUWZ256rmkz = 13007,

        VPMAXUWZ256rr = 13008,

        VPMAXUWZ256rrk = 13009,

        VPMAXUWZ256rrkz = 13010,

        VPMAXUWZrm = 13011,

        VPMAXUWZrmk = 13012,

        VPMAXUWZrmkz = 13013,

        VPMAXUWZrr = 13014,

        VPMAXUWZrrk = 13015,

        VPMAXUWZrrkz = 13016,

        VPMAXUWrm = 13017,

        VPMAXUWrr = 13018,

        VPMINSBYrm = 13019,

        VPMINSBYrr = 13020,

        VPMINSBZ128rm = 13021,

        VPMINSBZ128rmk = 13022,

        VPMINSBZ128rmkz = 13023,

        VPMINSBZ128rr = 13024,

        VPMINSBZ128rrk = 13025,

        VPMINSBZ128rrkz = 13026,

        VPMINSBZ256rm = 13027,

        VPMINSBZ256rmk = 13028,

        VPMINSBZ256rmkz = 13029,

        VPMINSBZ256rr = 13030,

        VPMINSBZ256rrk = 13031,

        VPMINSBZ256rrkz = 13032,

        VPMINSBZrm = 13033,

        VPMINSBZrmk = 13034,

        VPMINSBZrmkz = 13035,

        VPMINSBZrr = 13036,

        VPMINSBZrrk = 13037,

        VPMINSBZrrkz = 13038,

        VPMINSBrm = 13039,

        VPMINSBrr = 13040,

        VPMINSDYrm = 13041,

        VPMINSDYrr = 13042,

        VPMINSDZ128rm = 13043,

        VPMINSDZ128rmb = 13044,

        VPMINSDZ128rmbk = 13045,

        VPMINSDZ128rmbkz = 13046,

        VPMINSDZ128rmk = 13047,

        VPMINSDZ128rmkz = 13048,

        VPMINSDZ128rr = 13049,

        VPMINSDZ128rrk = 13050,

        VPMINSDZ128rrkz = 13051,

        VPMINSDZ256rm = 13052,

        VPMINSDZ256rmb = 13053,

        VPMINSDZ256rmbk = 13054,

        VPMINSDZ256rmbkz = 13055,

        VPMINSDZ256rmk = 13056,

        VPMINSDZ256rmkz = 13057,

        VPMINSDZ256rr = 13058,

        VPMINSDZ256rrk = 13059,

        VPMINSDZ256rrkz = 13060,

        VPMINSDZrm = 13061,

        VPMINSDZrmb = 13062,

        VPMINSDZrmbk = 13063,

        VPMINSDZrmbkz = 13064,

        VPMINSDZrmk = 13065,

        VPMINSDZrmkz = 13066,

        VPMINSDZrr = 13067,

        VPMINSDZrrk = 13068,

        VPMINSDZrrkz = 13069,

        VPMINSDrm = 13070,

        VPMINSDrr = 13071,

        VPMINSQZ128rm = 13072,

        VPMINSQZ128rmb = 13073,

        VPMINSQZ128rmbk = 13074,

        VPMINSQZ128rmbkz = 13075,

        VPMINSQZ128rmk = 13076,

        VPMINSQZ128rmkz = 13077,

        VPMINSQZ128rr = 13078,

        VPMINSQZ128rrk = 13079,

        VPMINSQZ128rrkz = 13080,

        VPMINSQZ256rm = 13081,

        VPMINSQZ256rmb = 13082,

        VPMINSQZ256rmbk = 13083,

        VPMINSQZ256rmbkz = 13084,

        VPMINSQZ256rmk = 13085,

        VPMINSQZ256rmkz = 13086,

        VPMINSQZ256rr = 13087,

        VPMINSQZ256rrk = 13088,

        VPMINSQZ256rrkz = 13089,

        VPMINSQZrm = 13090,

        VPMINSQZrmb = 13091,

        VPMINSQZrmbk = 13092,

        VPMINSQZrmbkz = 13093,

        VPMINSQZrmk = 13094,

        VPMINSQZrmkz = 13095,

        VPMINSQZrr = 13096,

        VPMINSQZrrk = 13097,

        VPMINSQZrrkz = 13098,

        VPMINSWYrm = 13099,

        VPMINSWYrr = 13100,

        VPMINSWZ128rm = 13101,

        VPMINSWZ128rmk = 13102,

        VPMINSWZ128rmkz = 13103,

        VPMINSWZ128rr = 13104,

        VPMINSWZ128rrk = 13105,

        VPMINSWZ128rrkz = 13106,

        VPMINSWZ256rm = 13107,

        VPMINSWZ256rmk = 13108,

        VPMINSWZ256rmkz = 13109,

        VPMINSWZ256rr = 13110,

        VPMINSWZ256rrk = 13111,

        VPMINSWZ256rrkz = 13112,

        VPMINSWZrm = 13113,

        VPMINSWZrmk = 13114,

        VPMINSWZrmkz = 13115,

        VPMINSWZrr = 13116,

        VPMINSWZrrk = 13117,

        VPMINSWZrrkz = 13118,

        VPMINSWrm = 13119,

        VPMINSWrr = 13120,

        VPMINUBYrm = 13121,

        VPMINUBYrr = 13122,

        VPMINUBZ128rm = 13123,

        VPMINUBZ128rmk = 13124,

        VPMINUBZ128rmkz = 13125,

        VPMINUBZ128rr = 13126,

        VPMINUBZ128rrk = 13127,

        VPMINUBZ128rrkz = 13128,

        VPMINUBZ256rm = 13129,

        VPMINUBZ256rmk = 13130,

        VPMINUBZ256rmkz = 13131,

        VPMINUBZ256rr = 13132,

        VPMINUBZ256rrk = 13133,

        VPMINUBZ256rrkz = 13134,

        VPMINUBZrm = 13135,

        VPMINUBZrmk = 13136,

        VPMINUBZrmkz = 13137,

        VPMINUBZrr = 13138,

        VPMINUBZrrk = 13139,

        VPMINUBZrrkz = 13140,

        VPMINUBrm = 13141,

        VPMINUBrr = 13142,

        VPMINUDYrm = 13143,

        VPMINUDYrr = 13144,

        VPMINUDZ128rm = 13145,

        VPMINUDZ128rmb = 13146,

        VPMINUDZ128rmbk = 13147,

        VPMINUDZ128rmbkz = 13148,

        VPMINUDZ128rmk = 13149,

        VPMINUDZ128rmkz = 13150,

        VPMINUDZ128rr = 13151,

        VPMINUDZ128rrk = 13152,

        VPMINUDZ128rrkz = 13153,

        VPMINUDZ256rm = 13154,

        VPMINUDZ256rmb = 13155,

        VPMINUDZ256rmbk = 13156,

        VPMINUDZ256rmbkz = 13157,

        VPMINUDZ256rmk = 13158,

        VPMINUDZ256rmkz = 13159,

        VPMINUDZ256rr = 13160,

        VPMINUDZ256rrk = 13161,

        VPMINUDZ256rrkz = 13162,

        VPMINUDZrm = 13163,

        VPMINUDZrmb = 13164,

        VPMINUDZrmbk = 13165,

        VPMINUDZrmbkz = 13166,

        VPMINUDZrmk = 13167,

        VPMINUDZrmkz = 13168,

        VPMINUDZrr = 13169,

        VPMINUDZrrk = 13170,

        VPMINUDZrrkz = 13171,

        VPMINUDrm = 13172,

        VPMINUDrr = 13173,

        VPMINUQZ128rm = 13174,

        VPMINUQZ128rmb = 13175,

        VPMINUQZ128rmbk = 13176,

        VPMINUQZ128rmbkz = 13177,

        VPMINUQZ128rmk = 13178,

        VPMINUQZ128rmkz = 13179,

        VPMINUQZ128rr = 13180,

        VPMINUQZ128rrk = 13181,

        VPMINUQZ128rrkz = 13182,

        VPMINUQZ256rm = 13183,

        VPMINUQZ256rmb = 13184,

        VPMINUQZ256rmbk = 13185,

        VPMINUQZ256rmbkz = 13186,

        VPMINUQZ256rmk = 13187,

        VPMINUQZ256rmkz = 13188,

        VPMINUQZ256rr = 13189,

        VPMINUQZ256rrk = 13190,

        VPMINUQZ256rrkz = 13191,

        VPMINUQZrm = 13192,

        VPMINUQZrmb = 13193,

        VPMINUQZrmbk = 13194,

        VPMINUQZrmbkz = 13195,

        VPMINUQZrmk = 13196,

        VPMINUQZrmkz = 13197,

        VPMINUQZrr = 13198,

        VPMINUQZrrk = 13199,

        VPMINUQZrrkz = 13200,

        VPMINUWYrm = 13201,

        VPMINUWYrr = 13202,

        VPMINUWZ128rm = 13203,

        VPMINUWZ128rmk = 13204,

        VPMINUWZ128rmkz = 13205,

        VPMINUWZ128rr = 13206,

        VPMINUWZ128rrk = 13207,

        VPMINUWZ128rrkz = 13208,

        VPMINUWZ256rm = 13209,

        VPMINUWZ256rmk = 13210,

        VPMINUWZ256rmkz = 13211,

        VPMINUWZ256rr = 13212,

        VPMINUWZ256rrk = 13213,

        VPMINUWZ256rrkz = 13214,

        VPMINUWZrm = 13215,

        VPMINUWZrmk = 13216,

        VPMINUWZrmkz = 13217,

        VPMINUWZrr = 13218,

        VPMINUWZrrk = 13219,

        VPMINUWZrrkz = 13220,

        VPMINUWrm = 13221,

        VPMINUWrr = 13222,

        VPMOVB2MZ128rr = 13223,

        VPMOVB2MZ256rr = 13224,

        VPMOVB2MZrr = 13225,

        VPMOVD2MZ128rr = 13226,

        VPMOVD2MZ256rr = 13227,

        VPMOVD2MZrr = 13228,

        VPMOVDBZ128mr = 13229,

        VPMOVDBZ128mrk = 13230,

        VPMOVDBZ128rr = 13231,

        VPMOVDBZ128rrk = 13232,

        VPMOVDBZ128rrkz = 13233,

        VPMOVDBZ256mr = 13234,

        VPMOVDBZ256mrk = 13235,

        VPMOVDBZ256rr = 13236,

        VPMOVDBZ256rrk = 13237,

        VPMOVDBZ256rrkz = 13238,

        VPMOVDBZmr = 13239,

        VPMOVDBZmrk = 13240,

        VPMOVDBZrr = 13241,

        VPMOVDBZrrk = 13242,

        VPMOVDBZrrkz = 13243,

        VPMOVDWZ128mr = 13244,

        VPMOVDWZ128mrk = 13245,

        VPMOVDWZ128rr = 13246,

        VPMOVDWZ128rrk = 13247,

        VPMOVDWZ128rrkz = 13248,

        VPMOVDWZ256mr = 13249,

        VPMOVDWZ256mrk = 13250,

        VPMOVDWZ256rr = 13251,

        VPMOVDWZ256rrk = 13252,

        VPMOVDWZ256rrkz = 13253,

        VPMOVDWZmr = 13254,

        VPMOVDWZmrk = 13255,

        VPMOVDWZrr = 13256,

        VPMOVDWZrrk = 13257,

        VPMOVDWZrrkz = 13258,

        VPMOVM2BZ128rr = 13259,

        VPMOVM2BZ256rr = 13260,

        VPMOVM2BZrr = 13261,

        VPMOVM2DZ128rr = 13262,

        VPMOVM2DZ256rr = 13263,

        VPMOVM2DZrr = 13264,

        VPMOVM2QZ128rr = 13265,

        VPMOVM2QZ256rr = 13266,

        VPMOVM2QZrr = 13267,

        VPMOVM2WZ128rr = 13268,

        VPMOVM2WZ256rr = 13269,

        VPMOVM2WZrr = 13270,

        VPMOVMSKBYrr = 13271,

        VPMOVMSKBrr = 13272,

        VPMOVQ2MZ128rr = 13273,

        VPMOVQ2MZ256rr = 13274,

        VPMOVQ2MZrr = 13275,

        VPMOVQBZ128mr = 13276,

        VPMOVQBZ128mrk = 13277,

        VPMOVQBZ128rr = 13278,

        VPMOVQBZ128rrk = 13279,

        VPMOVQBZ128rrkz = 13280,

        VPMOVQBZ256mr = 13281,

        VPMOVQBZ256mrk = 13282,

        VPMOVQBZ256rr = 13283,

        VPMOVQBZ256rrk = 13284,

        VPMOVQBZ256rrkz = 13285,

        VPMOVQBZmr = 13286,

        VPMOVQBZmrk = 13287,

        VPMOVQBZrr = 13288,

        VPMOVQBZrrk = 13289,

        VPMOVQBZrrkz = 13290,

        VPMOVQDZ128mr = 13291,

        VPMOVQDZ128mrk = 13292,

        VPMOVQDZ128rr = 13293,

        VPMOVQDZ128rrk = 13294,

        VPMOVQDZ128rrkz = 13295,

        VPMOVQDZ256mr = 13296,

        VPMOVQDZ256mrk = 13297,

        VPMOVQDZ256rr = 13298,

        VPMOVQDZ256rrk = 13299,

        VPMOVQDZ256rrkz = 13300,

        VPMOVQDZmr = 13301,

        VPMOVQDZmrk = 13302,

        VPMOVQDZrr = 13303,

        VPMOVQDZrrk = 13304,

        VPMOVQDZrrkz = 13305,

        VPMOVQWZ128mr = 13306,

        VPMOVQWZ128mrk = 13307,

        VPMOVQWZ128rr = 13308,

        VPMOVQWZ128rrk = 13309,

        VPMOVQWZ128rrkz = 13310,

        VPMOVQWZ256mr = 13311,

        VPMOVQWZ256mrk = 13312,

        VPMOVQWZ256rr = 13313,

        VPMOVQWZ256rrk = 13314,

        VPMOVQWZ256rrkz = 13315,

        VPMOVQWZmr = 13316,

        VPMOVQWZmrk = 13317,

        VPMOVQWZrr = 13318,

        VPMOVQWZrrk = 13319,

        VPMOVQWZrrkz = 13320,

        VPMOVSDBZ128mr = 13321,

        VPMOVSDBZ128mrk = 13322,

        VPMOVSDBZ128rr = 13323,

        VPMOVSDBZ128rrk = 13324,

        VPMOVSDBZ128rrkz = 13325,

        VPMOVSDBZ256mr = 13326,

        VPMOVSDBZ256mrk = 13327,

        VPMOVSDBZ256rr = 13328,

        VPMOVSDBZ256rrk = 13329,

        VPMOVSDBZ256rrkz = 13330,

        VPMOVSDBZmr = 13331,

        VPMOVSDBZmrk = 13332,

        VPMOVSDBZrr = 13333,

        VPMOVSDBZrrk = 13334,

        VPMOVSDBZrrkz = 13335,

        VPMOVSDWZ128mr = 13336,

        VPMOVSDWZ128mrk = 13337,

        VPMOVSDWZ128rr = 13338,

        VPMOVSDWZ128rrk = 13339,

        VPMOVSDWZ128rrkz = 13340,

        VPMOVSDWZ256mr = 13341,

        VPMOVSDWZ256mrk = 13342,

        VPMOVSDWZ256rr = 13343,

        VPMOVSDWZ256rrk = 13344,

        VPMOVSDWZ256rrkz = 13345,

        VPMOVSDWZmr = 13346,

        VPMOVSDWZmrk = 13347,

        VPMOVSDWZrr = 13348,

        VPMOVSDWZrrk = 13349,

        VPMOVSDWZrrkz = 13350,

        VPMOVSQBZ128mr = 13351,

        VPMOVSQBZ128mrk = 13352,

        VPMOVSQBZ128rr = 13353,

        VPMOVSQBZ128rrk = 13354,

        VPMOVSQBZ128rrkz = 13355,

        VPMOVSQBZ256mr = 13356,

        VPMOVSQBZ256mrk = 13357,

        VPMOVSQBZ256rr = 13358,

        VPMOVSQBZ256rrk = 13359,

        VPMOVSQBZ256rrkz = 13360,

        VPMOVSQBZmr = 13361,

        VPMOVSQBZmrk = 13362,

        VPMOVSQBZrr = 13363,

        VPMOVSQBZrrk = 13364,

        VPMOVSQBZrrkz = 13365,

        VPMOVSQDZ128mr = 13366,

        VPMOVSQDZ128mrk = 13367,

        VPMOVSQDZ128rr = 13368,

        VPMOVSQDZ128rrk = 13369,

        VPMOVSQDZ128rrkz = 13370,

        VPMOVSQDZ256mr = 13371,

        VPMOVSQDZ256mrk = 13372,

        VPMOVSQDZ256rr = 13373,

        VPMOVSQDZ256rrk = 13374,

        VPMOVSQDZ256rrkz = 13375,

        VPMOVSQDZmr = 13376,

        VPMOVSQDZmrk = 13377,

        VPMOVSQDZrr = 13378,

        VPMOVSQDZrrk = 13379,

        VPMOVSQDZrrkz = 13380,

        VPMOVSQWZ128mr = 13381,

        VPMOVSQWZ128mrk = 13382,

        VPMOVSQWZ128rr = 13383,

        VPMOVSQWZ128rrk = 13384,

        VPMOVSQWZ128rrkz = 13385,

        VPMOVSQWZ256mr = 13386,

        VPMOVSQWZ256mrk = 13387,

        VPMOVSQWZ256rr = 13388,

        VPMOVSQWZ256rrk = 13389,

        VPMOVSQWZ256rrkz = 13390,

        VPMOVSQWZmr = 13391,

        VPMOVSQWZmrk = 13392,

        VPMOVSQWZrr = 13393,

        VPMOVSQWZrrk = 13394,

        VPMOVSQWZrrkz = 13395,

        VPMOVSWBZ128mr = 13396,

        VPMOVSWBZ128mrk = 13397,

        VPMOVSWBZ128rr = 13398,

        VPMOVSWBZ128rrk = 13399,

        VPMOVSWBZ128rrkz = 13400,

        VPMOVSWBZ256mr = 13401,

        VPMOVSWBZ256mrk = 13402,

        VPMOVSWBZ256rr = 13403,

        VPMOVSWBZ256rrk = 13404,

        VPMOVSWBZ256rrkz = 13405,

        VPMOVSWBZmr = 13406,

        VPMOVSWBZmrk = 13407,

        VPMOVSWBZrr = 13408,

        VPMOVSWBZrrk = 13409,

        VPMOVSWBZrrkz = 13410,

        VPMOVSXBDYrm = 13411,

        VPMOVSXBDYrr = 13412,

        VPMOVSXBDZ128rm = 13413,

        VPMOVSXBDZ128rmk = 13414,

        VPMOVSXBDZ128rmkz = 13415,

        VPMOVSXBDZ128rr = 13416,

        VPMOVSXBDZ128rrk = 13417,

        VPMOVSXBDZ128rrkz = 13418,

        VPMOVSXBDZ256rm = 13419,

        VPMOVSXBDZ256rmk = 13420,

        VPMOVSXBDZ256rmkz = 13421,

        VPMOVSXBDZ256rr = 13422,

        VPMOVSXBDZ256rrk = 13423,

        VPMOVSXBDZ256rrkz = 13424,

        VPMOVSXBDZrm = 13425,

        VPMOVSXBDZrmk = 13426,

        VPMOVSXBDZrmkz = 13427,

        VPMOVSXBDZrr = 13428,

        VPMOVSXBDZrrk = 13429,

        VPMOVSXBDZrrkz = 13430,

        VPMOVSXBDrm = 13431,

        VPMOVSXBDrr = 13432,

        VPMOVSXBQYrm = 13433,

        VPMOVSXBQYrr = 13434,

        VPMOVSXBQZ128rm = 13435,

        VPMOVSXBQZ128rmk = 13436,

        VPMOVSXBQZ128rmkz = 13437,

        VPMOVSXBQZ128rr = 13438,

        VPMOVSXBQZ128rrk = 13439,

        VPMOVSXBQZ128rrkz = 13440,

        VPMOVSXBQZ256rm = 13441,

        VPMOVSXBQZ256rmk = 13442,

        VPMOVSXBQZ256rmkz = 13443,

        VPMOVSXBQZ256rr = 13444,

        VPMOVSXBQZ256rrk = 13445,

        VPMOVSXBQZ256rrkz = 13446,

        VPMOVSXBQZrm = 13447,

        VPMOVSXBQZrmk = 13448,

        VPMOVSXBQZrmkz = 13449,

        VPMOVSXBQZrr = 13450,

        VPMOVSXBQZrrk = 13451,

        VPMOVSXBQZrrkz = 13452,

        VPMOVSXBQrm = 13453,

        VPMOVSXBQrr = 13454,

        VPMOVSXBWYrm = 13455,

        VPMOVSXBWYrr = 13456,

        VPMOVSXBWZ128rm = 13457,

        VPMOVSXBWZ128rmk = 13458,

        VPMOVSXBWZ128rmkz = 13459,

        VPMOVSXBWZ128rr = 13460,

        VPMOVSXBWZ128rrk = 13461,

        VPMOVSXBWZ128rrkz = 13462,

        VPMOVSXBWZ256rm = 13463,

        VPMOVSXBWZ256rmk = 13464,

        VPMOVSXBWZ256rmkz = 13465,

        VPMOVSXBWZ256rr = 13466,

        VPMOVSXBWZ256rrk = 13467,

        VPMOVSXBWZ256rrkz = 13468,

        VPMOVSXBWZrm = 13469,

        VPMOVSXBWZrmk = 13470,

        VPMOVSXBWZrmkz = 13471,

        VPMOVSXBWZrr = 13472,

        VPMOVSXBWZrrk = 13473,

        VPMOVSXBWZrrkz = 13474,

        VPMOVSXBWrm = 13475,

        VPMOVSXBWrr = 13476,

        VPMOVSXDQYrm = 13477,

        VPMOVSXDQYrr = 13478,

        VPMOVSXDQZ128rm = 13479,

        VPMOVSXDQZ128rmk = 13480,

        VPMOVSXDQZ128rmkz = 13481,

        VPMOVSXDQZ128rr = 13482,

        VPMOVSXDQZ128rrk = 13483,

        VPMOVSXDQZ128rrkz = 13484,

        VPMOVSXDQZ256rm = 13485,

        VPMOVSXDQZ256rmk = 13486,

        VPMOVSXDQZ256rmkz = 13487,

        VPMOVSXDQZ256rr = 13488,

        VPMOVSXDQZ256rrk = 13489,

        VPMOVSXDQZ256rrkz = 13490,

        VPMOVSXDQZrm = 13491,

        VPMOVSXDQZrmk = 13492,

        VPMOVSXDQZrmkz = 13493,

        VPMOVSXDQZrr = 13494,

        VPMOVSXDQZrrk = 13495,

        VPMOVSXDQZrrkz = 13496,

        VPMOVSXDQrm = 13497,

        VPMOVSXDQrr = 13498,

        VPMOVSXWDYrm = 13499,

        VPMOVSXWDYrr = 13500,

        VPMOVSXWDZ128rm = 13501,

        VPMOVSXWDZ128rmk = 13502,

        VPMOVSXWDZ128rmkz = 13503,

        VPMOVSXWDZ128rr = 13504,

        VPMOVSXWDZ128rrk = 13505,

        VPMOVSXWDZ128rrkz = 13506,

        VPMOVSXWDZ256rm = 13507,

        VPMOVSXWDZ256rmk = 13508,

        VPMOVSXWDZ256rmkz = 13509,

        VPMOVSXWDZ256rr = 13510,

        VPMOVSXWDZ256rrk = 13511,

        VPMOVSXWDZ256rrkz = 13512,

        VPMOVSXWDZrm = 13513,

        VPMOVSXWDZrmk = 13514,

        VPMOVSXWDZrmkz = 13515,

        VPMOVSXWDZrr = 13516,

        VPMOVSXWDZrrk = 13517,

        VPMOVSXWDZrrkz = 13518,

        VPMOVSXWDrm = 13519,

        VPMOVSXWDrr = 13520,

        VPMOVSXWQYrm = 13521,

        VPMOVSXWQYrr = 13522,

        VPMOVSXWQZ128rm = 13523,

        VPMOVSXWQZ128rmk = 13524,

        VPMOVSXWQZ128rmkz = 13525,

        VPMOVSXWQZ128rr = 13526,

        VPMOVSXWQZ128rrk = 13527,

        VPMOVSXWQZ128rrkz = 13528,

        VPMOVSXWQZ256rm = 13529,

        VPMOVSXWQZ256rmk = 13530,

        VPMOVSXWQZ256rmkz = 13531,

        VPMOVSXWQZ256rr = 13532,

        VPMOVSXWQZ256rrk = 13533,

        VPMOVSXWQZ256rrkz = 13534,

        VPMOVSXWQZrm = 13535,

        VPMOVSXWQZrmk = 13536,

        VPMOVSXWQZrmkz = 13537,

        VPMOVSXWQZrr = 13538,

        VPMOVSXWQZrrk = 13539,

        VPMOVSXWQZrrkz = 13540,

        VPMOVSXWQrm = 13541,

        VPMOVSXWQrr = 13542,

        VPMOVUSDBZ128mr = 13543,

        VPMOVUSDBZ128mrk = 13544,

        VPMOVUSDBZ128rr = 13545,

        VPMOVUSDBZ128rrk = 13546,

        VPMOVUSDBZ128rrkz = 13547,

        VPMOVUSDBZ256mr = 13548,

        VPMOVUSDBZ256mrk = 13549,

        VPMOVUSDBZ256rr = 13550,

        VPMOVUSDBZ256rrk = 13551,

        VPMOVUSDBZ256rrkz = 13552,

        VPMOVUSDBZmr = 13553,

        VPMOVUSDBZmrk = 13554,

        VPMOVUSDBZrr = 13555,

        VPMOVUSDBZrrk = 13556,

        VPMOVUSDBZrrkz = 13557,

        VPMOVUSDWZ128mr = 13558,

        VPMOVUSDWZ128mrk = 13559,

        VPMOVUSDWZ128rr = 13560,

        VPMOVUSDWZ128rrk = 13561,

        VPMOVUSDWZ128rrkz = 13562,

        VPMOVUSDWZ256mr = 13563,

        VPMOVUSDWZ256mrk = 13564,

        VPMOVUSDWZ256rr = 13565,

        VPMOVUSDWZ256rrk = 13566,

        VPMOVUSDWZ256rrkz = 13567,

        VPMOVUSDWZmr = 13568,

        VPMOVUSDWZmrk = 13569,

        VPMOVUSDWZrr = 13570,

        VPMOVUSDWZrrk = 13571,

        VPMOVUSDWZrrkz = 13572,

        VPMOVUSQBZ128mr = 13573,

        VPMOVUSQBZ128mrk = 13574,

        VPMOVUSQBZ128rr = 13575,

        VPMOVUSQBZ128rrk = 13576,

        VPMOVUSQBZ128rrkz = 13577,

        VPMOVUSQBZ256mr = 13578,

        VPMOVUSQBZ256mrk = 13579,

        VPMOVUSQBZ256rr = 13580,

        VPMOVUSQBZ256rrk = 13581,

        VPMOVUSQBZ256rrkz = 13582,

        VPMOVUSQBZmr = 13583,

        VPMOVUSQBZmrk = 13584,

        VPMOVUSQBZrr = 13585,

        VPMOVUSQBZrrk = 13586,

        VPMOVUSQBZrrkz = 13587,

        VPMOVUSQDZ128mr = 13588,

        VPMOVUSQDZ128mrk = 13589,

        VPMOVUSQDZ128rr = 13590,

        VPMOVUSQDZ128rrk = 13591,

        VPMOVUSQDZ128rrkz = 13592,

        VPMOVUSQDZ256mr = 13593,

        VPMOVUSQDZ256mrk = 13594,

        VPMOVUSQDZ256rr = 13595,

        VPMOVUSQDZ256rrk = 13596,

        VPMOVUSQDZ256rrkz = 13597,

        VPMOVUSQDZmr = 13598,

        VPMOVUSQDZmrk = 13599,

        VPMOVUSQDZrr = 13600,

        VPMOVUSQDZrrk = 13601,

        VPMOVUSQDZrrkz = 13602,

        VPMOVUSQWZ128mr = 13603,

        VPMOVUSQWZ128mrk = 13604,

        VPMOVUSQWZ128rr = 13605,

        VPMOVUSQWZ128rrk = 13606,

        VPMOVUSQWZ128rrkz = 13607,

        VPMOVUSQWZ256mr = 13608,

        VPMOVUSQWZ256mrk = 13609,

        VPMOVUSQWZ256rr = 13610,

        VPMOVUSQWZ256rrk = 13611,

        VPMOVUSQWZ256rrkz = 13612,

        VPMOVUSQWZmr = 13613,

        VPMOVUSQWZmrk = 13614,

        VPMOVUSQWZrr = 13615,

        VPMOVUSQWZrrk = 13616,

        VPMOVUSQWZrrkz = 13617,

        VPMOVUSWBZ128mr = 13618,

        VPMOVUSWBZ128mrk = 13619,

        VPMOVUSWBZ128rr = 13620,

        VPMOVUSWBZ128rrk = 13621,

        VPMOVUSWBZ128rrkz = 13622,

        VPMOVUSWBZ256mr = 13623,

        VPMOVUSWBZ256mrk = 13624,

        VPMOVUSWBZ256rr = 13625,

        VPMOVUSWBZ256rrk = 13626,

        VPMOVUSWBZ256rrkz = 13627,

        VPMOVUSWBZmr = 13628,

        VPMOVUSWBZmrk = 13629,

        VPMOVUSWBZrr = 13630,

        VPMOVUSWBZrrk = 13631,

        VPMOVUSWBZrrkz = 13632,

        VPMOVW2MZ128rr = 13633,

        VPMOVW2MZ256rr = 13634,

        VPMOVW2MZrr = 13635,

        VPMOVWBZ128mr = 13636,

        VPMOVWBZ128mrk = 13637,

        VPMOVWBZ128rr = 13638,

        VPMOVWBZ128rrk = 13639,

        VPMOVWBZ128rrkz = 13640,

        VPMOVWBZ256mr = 13641,

        VPMOVWBZ256mrk = 13642,

        VPMOVWBZ256rr = 13643,

        VPMOVWBZ256rrk = 13644,

        VPMOVWBZ256rrkz = 13645,

        VPMOVWBZmr = 13646,

        VPMOVWBZmrk = 13647,

        VPMOVWBZrr = 13648,

        VPMOVWBZrrk = 13649,

        VPMOVWBZrrkz = 13650,

        VPMOVZXBDYrm = 13651,

        VPMOVZXBDYrr = 13652,

        VPMOVZXBDZ128rm = 13653,

        VPMOVZXBDZ128rmk = 13654,

        VPMOVZXBDZ128rmkz = 13655,

        VPMOVZXBDZ128rr = 13656,

        VPMOVZXBDZ128rrk = 13657,

        VPMOVZXBDZ128rrkz = 13658,

        VPMOVZXBDZ256rm = 13659,

        VPMOVZXBDZ256rmk = 13660,

        VPMOVZXBDZ256rmkz = 13661,

        VPMOVZXBDZ256rr = 13662,

        VPMOVZXBDZ256rrk = 13663,

        VPMOVZXBDZ256rrkz = 13664,

        VPMOVZXBDZrm = 13665,

        VPMOVZXBDZrmk = 13666,

        VPMOVZXBDZrmkz = 13667,

        VPMOVZXBDZrr = 13668,

        VPMOVZXBDZrrk = 13669,

        VPMOVZXBDZrrkz = 13670,

        VPMOVZXBDrm = 13671,

        VPMOVZXBDrr = 13672,

        VPMOVZXBQYrm = 13673,

        VPMOVZXBQYrr = 13674,

        VPMOVZXBQZ128rm = 13675,

        VPMOVZXBQZ128rmk = 13676,

        VPMOVZXBQZ128rmkz = 13677,

        VPMOVZXBQZ128rr = 13678,

        VPMOVZXBQZ128rrk = 13679,

        VPMOVZXBQZ128rrkz = 13680,

        VPMOVZXBQZ256rm = 13681,

        VPMOVZXBQZ256rmk = 13682,

        VPMOVZXBQZ256rmkz = 13683,

        VPMOVZXBQZ256rr = 13684,

        VPMOVZXBQZ256rrk = 13685,

        VPMOVZXBQZ256rrkz = 13686,

        VPMOVZXBQZrm = 13687,

        VPMOVZXBQZrmk = 13688,

        VPMOVZXBQZrmkz = 13689,

        VPMOVZXBQZrr = 13690,

        VPMOVZXBQZrrk = 13691,

        VPMOVZXBQZrrkz = 13692,

        VPMOVZXBQrm = 13693,

        VPMOVZXBQrr = 13694,

        VPMOVZXBWYrm = 13695,

        VPMOVZXBWYrr = 13696,

        VPMOVZXBWZ128rm = 13697,

        VPMOVZXBWZ128rmk = 13698,

        VPMOVZXBWZ128rmkz = 13699,

        VPMOVZXBWZ128rr = 13700,

        VPMOVZXBWZ128rrk = 13701,

        VPMOVZXBWZ128rrkz = 13702,

        VPMOVZXBWZ256rm = 13703,

        VPMOVZXBWZ256rmk = 13704,

        VPMOVZXBWZ256rmkz = 13705,

        VPMOVZXBWZ256rr = 13706,

        VPMOVZXBWZ256rrk = 13707,

        VPMOVZXBWZ256rrkz = 13708,

        VPMOVZXBWZrm = 13709,

        VPMOVZXBWZrmk = 13710,

        VPMOVZXBWZrmkz = 13711,

        VPMOVZXBWZrr = 13712,

        VPMOVZXBWZrrk = 13713,

        VPMOVZXBWZrrkz = 13714,

        VPMOVZXBWrm = 13715,

        VPMOVZXBWrr = 13716,

        VPMOVZXDQYrm = 13717,

        VPMOVZXDQYrr = 13718,

        VPMOVZXDQZ128rm = 13719,

        VPMOVZXDQZ128rmk = 13720,

        VPMOVZXDQZ128rmkz = 13721,

        VPMOVZXDQZ128rr = 13722,

        VPMOVZXDQZ128rrk = 13723,

        VPMOVZXDQZ128rrkz = 13724,

        VPMOVZXDQZ256rm = 13725,

        VPMOVZXDQZ256rmk = 13726,

        VPMOVZXDQZ256rmkz = 13727,

        VPMOVZXDQZ256rr = 13728,

        VPMOVZXDQZ256rrk = 13729,

        VPMOVZXDQZ256rrkz = 13730,

        VPMOVZXDQZrm = 13731,

        VPMOVZXDQZrmk = 13732,

        VPMOVZXDQZrmkz = 13733,

        VPMOVZXDQZrr = 13734,

        VPMOVZXDQZrrk = 13735,

        VPMOVZXDQZrrkz = 13736,

        VPMOVZXDQrm = 13737,

        VPMOVZXDQrr = 13738,

        VPMOVZXWDYrm = 13739,

        VPMOVZXWDYrr = 13740,

        VPMOVZXWDZ128rm = 13741,

        VPMOVZXWDZ128rmk = 13742,

        VPMOVZXWDZ128rmkz = 13743,

        VPMOVZXWDZ128rr = 13744,

        VPMOVZXWDZ128rrk = 13745,

        VPMOVZXWDZ128rrkz = 13746,

        VPMOVZXWDZ256rm = 13747,

        VPMOVZXWDZ256rmk = 13748,

        VPMOVZXWDZ256rmkz = 13749,

        VPMOVZXWDZ256rr = 13750,

        VPMOVZXWDZ256rrk = 13751,

        VPMOVZXWDZ256rrkz = 13752,

        VPMOVZXWDZrm = 13753,

        VPMOVZXWDZrmk = 13754,

        VPMOVZXWDZrmkz = 13755,

        VPMOVZXWDZrr = 13756,

        VPMOVZXWDZrrk = 13757,

        VPMOVZXWDZrrkz = 13758,

        VPMOVZXWDrm = 13759,

        VPMOVZXWDrr = 13760,

        VPMOVZXWQYrm = 13761,

        VPMOVZXWQYrr = 13762,

        VPMOVZXWQZ128rm = 13763,

        VPMOVZXWQZ128rmk = 13764,

        VPMOVZXWQZ128rmkz = 13765,

        VPMOVZXWQZ128rr = 13766,

        VPMOVZXWQZ128rrk = 13767,

        VPMOVZXWQZ128rrkz = 13768,

        VPMOVZXWQZ256rm = 13769,

        VPMOVZXWQZ256rmk = 13770,

        VPMOVZXWQZ256rmkz = 13771,

        VPMOVZXWQZ256rr = 13772,

        VPMOVZXWQZ256rrk = 13773,

        VPMOVZXWQZ256rrkz = 13774,

        VPMOVZXWQZrm = 13775,

        VPMOVZXWQZrmk = 13776,

        VPMOVZXWQZrmkz = 13777,

        VPMOVZXWQZrr = 13778,

        VPMOVZXWQZrrk = 13779,

        VPMOVZXWQZrrkz = 13780,

        VPMOVZXWQrm = 13781,

        VPMOVZXWQrr = 13782,

        VPMULDQYrm = 13783,

        VPMULDQYrr = 13784,

        VPMULDQZ128rm = 13785,

        VPMULDQZ128rmb = 13786,

        VPMULDQZ128rmbk = 13787,

        VPMULDQZ128rmbkz = 13788,

        VPMULDQZ128rmk = 13789,

        VPMULDQZ128rmkz = 13790,

        VPMULDQZ128rr = 13791,

        VPMULDQZ128rrk = 13792,

        VPMULDQZ128rrkz = 13793,

        VPMULDQZ256rm = 13794,

        VPMULDQZ256rmb = 13795,

        VPMULDQZ256rmbk = 13796,

        VPMULDQZ256rmbkz = 13797,

        VPMULDQZ256rmk = 13798,

        VPMULDQZ256rmkz = 13799,

        VPMULDQZ256rr = 13800,

        VPMULDQZ256rrk = 13801,

        VPMULDQZ256rrkz = 13802,

        VPMULDQZrm = 13803,

        VPMULDQZrmb = 13804,

        VPMULDQZrmbk = 13805,

        VPMULDQZrmbkz = 13806,

        VPMULDQZrmk = 13807,

        VPMULDQZrmkz = 13808,

        VPMULDQZrr = 13809,

        VPMULDQZrrk = 13810,

        VPMULDQZrrkz = 13811,

        VPMULDQrm = 13812,

        VPMULDQrr = 13813,

        VPMULHRSWYrm = 13814,

        VPMULHRSWYrr = 13815,

        VPMULHRSWZ128rm = 13816,

        VPMULHRSWZ128rmk = 13817,

        VPMULHRSWZ128rmkz = 13818,

        VPMULHRSWZ128rr = 13819,

        VPMULHRSWZ128rrk = 13820,

        VPMULHRSWZ128rrkz = 13821,

        VPMULHRSWZ256rm = 13822,

        VPMULHRSWZ256rmk = 13823,

        VPMULHRSWZ256rmkz = 13824,

        VPMULHRSWZ256rr = 13825,

        VPMULHRSWZ256rrk = 13826,

        VPMULHRSWZ256rrkz = 13827,

        VPMULHRSWZrm = 13828,

        VPMULHRSWZrmk = 13829,

        VPMULHRSWZrmkz = 13830,

        VPMULHRSWZrr = 13831,

        VPMULHRSWZrrk = 13832,

        VPMULHRSWZrrkz = 13833,

        VPMULHRSWrm = 13834,

        VPMULHRSWrr = 13835,

        VPMULHUWYrm = 13836,

        VPMULHUWYrr = 13837,

        VPMULHUWZ128rm = 13838,

        VPMULHUWZ128rmk = 13839,

        VPMULHUWZ128rmkz = 13840,

        VPMULHUWZ128rr = 13841,

        VPMULHUWZ128rrk = 13842,

        VPMULHUWZ128rrkz = 13843,

        VPMULHUWZ256rm = 13844,

        VPMULHUWZ256rmk = 13845,

        VPMULHUWZ256rmkz = 13846,

        VPMULHUWZ256rr = 13847,

        VPMULHUWZ256rrk = 13848,

        VPMULHUWZ256rrkz = 13849,

        VPMULHUWZrm = 13850,

        VPMULHUWZrmk = 13851,

        VPMULHUWZrmkz = 13852,

        VPMULHUWZrr = 13853,

        VPMULHUWZrrk = 13854,

        VPMULHUWZrrkz = 13855,

        VPMULHUWrm = 13856,

        VPMULHUWrr = 13857,

        VPMULHWYrm = 13858,

        VPMULHWYrr = 13859,

        VPMULHWZ128rm = 13860,

        VPMULHWZ128rmk = 13861,

        VPMULHWZ128rmkz = 13862,

        VPMULHWZ128rr = 13863,

        VPMULHWZ128rrk = 13864,

        VPMULHWZ128rrkz = 13865,

        VPMULHWZ256rm = 13866,

        VPMULHWZ256rmk = 13867,

        VPMULHWZ256rmkz = 13868,

        VPMULHWZ256rr = 13869,

        VPMULHWZ256rrk = 13870,

        VPMULHWZ256rrkz = 13871,

        VPMULHWZrm = 13872,

        VPMULHWZrmk = 13873,

        VPMULHWZrmkz = 13874,

        VPMULHWZrr = 13875,

        VPMULHWZrrk = 13876,

        VPMULHWZrrkz = 13877,

        VPMULHWrm = 13878,

        VPMULHWrr = 13879,

        VPMULLDYrm = 13880,

        VPMULLDYrr = 13881,

        VPMULLDZ128rm = 13882,

        VPMULLDZ128rmb = 13883,

        VPMULLDZ128rmbk = 13884,

        VPMULLDZ128rmbkz = 13885,

        VPMULLDZ128rmk = 13886,

        VPMULLDZ128rmkz = 13887,

        VPMULLDZ128rr = 13888,

        VPMULLDZ128rrk = 13889,

        VPMULLDZ128rrkz = 13890,

        VPMULLDZ256rm = 13891,

        VPMULLDZ256rmb = 13892,

        VPMULLDZ256rmbk = 13893,

        VPMULLDZ256rmbkz = 13894,

        VPMULLDZ256rmk = 13895,

        VPMULLDZ256rmkz = 13896,

        VPMULLDZ256rr = 13897,

        VPMULLDZ256rrk = 13898,

        VPMULLDZ256rrkz = 13899,

        VPMULLDZrm = 13900,

        VPMULLDZrmb = 13901,

        VPMULLDZrmbk = 13902,

        VPMULLDZrmbkz = 13903,

        VPMULLDZrmk = 13904,

        VPMULLDZrmkz = 13905,

        VPMULLDZrr = 13906,

        VPMULLDZrrk = 13907,

        VPMULLDZrrkz = 13908,

        VPMULLDrm = 13909,

        VPMULLDrr = 13910,

        VPMULLQZ128rm = 13911,

        VPMULLQZ128rmb = 13912,

        VPMULLQZ128rmbk = 13913,

        VPMULLQZ128rmbkz = 13914,

        VPMULLQZ128rmk = 13915,

        VPMULLQZ128rmkz = 13916,

        VPMULLQZ128rr = 13917,

        VPMULLQZ128rrk = 13918,

        VPMULLQZ128rrkz = 13919,

        VPMULLQZ256rm = 13920,

        VPMULLQZ256rmb = 13921,

        VPMULLQZ256rmbk = 13922,

        VPMULLQZ256rmbkz = 13923,

        VPMULLQZ256rmk = 13924,

        VPMULLQZ256rmkz = 13925,

        VPMULLQZ256rr = 13926,

        VPMULLQZ256rrk = 13927,

        VPMULLQZ256rrkz = 13928,

        VPMULLQZrm = 13929,

        VPMULLQZrmb = 13930,

        VPMULLQZrmbk = 13931,

        VPMULLQZrmbkz = 13932,

        VPMULLQZrmk = 13933,

        VPMULLQZrmkz = 13934,

        VPMULLQZrr = 13935,

        VPMULLQZrrk = 13936,

        VPMULLQZrrkz = 13937,

        VPMULLWYrm = 13938,

        VPMULLWYrr = 13939,

        VPMULLWZ128rm = 13940,

        VPMULLWZ128rmk = 13941,

        VPMULLWZ128rmkz = 13942,

        VPMULLWZ128rr = 13943,

        VPMULLWZ128rrk = 13944,

        VPMULLWZ128rrkz = 13945,

        VPMULLWZ256rm = 13946,

        VPMULLWZ256rmk = 13947,

        VPMULLWZ256rmkz = 13948,

        VPMULLWZ256rr = 13949,

        VPMULLWZ256rrk = 13950,

        VPMULLWZ256rrkz = 13951,

        VPMULLWZrm = 13952,

        VPMULLWZrmk = 13953,

        VPMULLWZrmkz = 13954,

        VPMULLWZrr = 13955,

        VPMULLWZrrk = 13956,

        VPMULLWZrrkz = 13957,

        VPMULLWrm = 13958,

        VPMULLWrr = 13959,

        VPMULTISHIFTQBZ128rm = 13960,

        VPMULTISHIFTQBZ128rmb = 13961,

        VPMULTISHIFTQBZ128rmbk = 13962,

        VPMULTISHIFTQBZ128rmbkz = 13963,

        VPMULTISHIFTQBZ128rmk = 13964,

        VPMULTISHIFTQBZ128rmkz = 13965,

        VPMULTISHIFTQBZ128rr = 13966,

        VPMULTISHIFTQBZ128rrk = 13967,

        VPMULTISHIFTQBZ128rrkz = 13968,

        VPMULTISHIFTQBZ256rm = 13969,

        VPMULTISHIFTQBZ256rmb = 13970,

        VPMULTISHIFTQBZ256rmbk = 13971,

        VPMULTISHIFTQBZ256rmbkz = 13972,

        VPMULTISHIFTQBZ256rmk = 13973,

        VPMULTISHIFTQBZ256rmkz = 13974,

        VPMULTISHIFTQBZ256rr = 13975,

        VPMULTISHIFTQBZ256rrk = 13976,

        VPMULTISHIFTQBZ256rrkz = 13977,

        VPMULTISHIFTQBZrm = 13978,

        VPMULTISHIFTQBZrmb = 13979,

        VPMULTISHIFTQBZrmbk = 13980,

        VPMULTISHIFTQBZrmbkz = 13981,

        VPMULTISHIFTQBZrmk = 13982,

        VPMULTISHIFTQBZrmkz = 13983,

        VPMULTISHIFTQBZrr = 13984,

        VPMULTISHIFTQBZrrk = 13985,

        VPMULTISHIFTQBZrrkz = 13986,

        VPMULUDQYrm = 13987,

        VPMULUDQYrr = 13988,

        VPMULUDQZ128rm = 13989,

        VPMULUDQZ128rmb = 13990,

        VPMULUDQZ128rmbk = 13991,

        VPMULUDQZ128rmbkz = 13992,

        VPMULUDQZ128rmk = 13993,

        VPMULUDQZ128rmkz = 13994,

        VPMULUDQZ128rr = 13995,

        VPMULUDQZ128rrk = 13996,

        VPMULUDQZ128rrkz = 13997,

        VPMULUDQZ256rm = 13998,

        VPMULUDQZ256rmb = 13999,

        VPMULUDQZ256rmbk = 14000,

        VPMULUDQZ256rmbkz = 14001,

        VPMULUDQZ256rmk = 14002,

        VPMULUDQZ256rmkz = 14003,

        VPMULUDQZ256rr = 14004,

        VPMULUDQZ256rrk = 14005,

        VPMULUDQZ256rrkz = 14006,

        VPMULUDQZrm = 14007,

        VPMULUDQZrmb = 14008,

        VPMULUDQZrmbk = 14009,

        VPMULUDQZrmbkz = 14010,

        VPMULUDQZrmk = 14011,

        VPMULUDQZrmkz = 14012,

        VPMULUDQZrr = 14013,

        VPMULUDQZrrk = 14014,

        VPMULUDQZrrkz = 14015,

        VPMULUDQrm = 14016,

        VPMULUDQrr = 14017,

        VPOPCNTBZ128rm = 14018,

        VPOPCNTBZ128rmk = 14019,

        VPOPCNTBZ128rmkz = 14020,

        VPOPCNTBZ128rr = 14021,

        VPOPCNTBZ128rrk = 14022,

        VPOPCNTBZ128rrkz = 14023,

        VPOPCNTBZ256rm = 14024,

        VPOPCNTBZ256rmk = 14025,

        VPOPCNTBZ256rmkz = 14026,

        VPOPCNTBZ256rr = 14027,

        VPOPCNTBZ256rrk = 14028,

        VPOPCNTBZ256rrkz = 14029,

        VPOPCNTBZrm = 14030,

        VPOPCNTBZrmk = 14031,

        VPOPCNTBZrmkz = 14032,

        VPOPCNTBZrr = 14033,

        VPOPCNTBZrrk = 14034,

        VPOPCNTBZrrkz = 14035,

        VPOPCNTDZ128rm = 14036,

        VPOPCNTDZ128rmb = 14037,

        VPOPCNTDZ128rmbk = 14038,

        VPOPCNTDZ128rmbkz = 14039,

        VPOPCNTDZ128rmk = 14040,

        VPOPCNTDZ128rmkz = 14041,

        VPOPCNTDZ128rr = 14042,

        VPOPCNTDZ128rrk = 14043,

        VPOPCNTDZ128rrkz = 14044,

        VPOPCNTDZ256rm = 14045,

        VPOPCNTDZ256rmb = 14046,

        VPOPCNTDZ256rmbk = 14047,

        VPOPCNTDZ256rmbkz = 14048,

        VPOPCNTDZ256rmk = 14049,

        VPOPCNTDZ256rmkz = 14050,

        VPOPCNTDZ256rr = 14051,

        VPOPCNTDZ256rrk = 14052,

        VPOPCNTDZ256rrkz = 14053,

        VPOPCNTDZrm = 14054,

        VPOPCNTDZrmb = 14055,

        VPOPCNTDZrmbk = 14056,

        VPOPCNTDZrmbkz = 14057,

        VPOPCNTDZrmk = 14058,

        VPOPCNTDZrmkz = 14059,

        VPOPCNTDZrr = 14060,

        VPOPCNTDZrrk = 14061,

        VPOPCNTDZrrkz = 14062,

        VPOPCNTQZ128rm = 14063,

        VPOPCNTQZ128rmb = 14064,

        VPOPCNTQZ128rmbk = 14065,

        VPOPCNTQZ128rmbkz = 14066,

        VPOPCNTQZ128rmk = 14067,

        VPOPCNTQZ128rmkz = 14068,

        VPOPCNTQZ128rr = 14069,

        VPOPCNTQZ128rrk = 14070,

        VPOPCNTQZ128rrkz = 14071,

        VPOPCNTQZ256rm = 14072,

        VPOPCNTQZ256rmb = 14073,

        VPOPCNTQZ256rmbk = 14074,

        VPOPCNTQZ256rmbkz = 14075,

        VPOPCNTQZ256rmk = 14076,

        VPOPCNTQZ256rmkz = 14077,

        VPOPCNTQZ256rr = 14078,

        VPOPCNTQZ256rrk = 14079,

        VPOPCNTQZ256rrkz = 14080,

        VPOPCNTQZrm = 14081,

        VPOPCNTQZrmb = 14082,

        VPOPCNTQZrmbk = 14083,

        VPOPCNTQZrmbkz = 14084,

        VPOPCNTQZrmk = 14085,

        VPOPCNTQZrmkz = 14086,

        VPOPCNTQZrr = 14087,

        VPOPCNTQZrrk = 14088,

        VPOPCNTQZrrkz = 14089,

        VPOPCNTWZ128rm = 14090,

        VPOPCNTWZ128rmk = 14091,

        VPOPCNTWZ128rmkz = 14092,

        VPOPCNTWZ128rr = 14093,

        VPOPCNTWZ128rrk = 14094,

        VPOPCNTWZ128rrkz = 14095,

        VPOPCNTWZ256rm = 14096,

        VPOPCNTWZ256rmk = 14097,

        VPOPCNTWZ256rmkz = 14098,

        VPOPCNTWZ256rr = 14099,

        VPOPCNTWZ256rrk = 14100,

        VPOPCNTWZ256rrkz = 14101,

        VPOPCNTWZrm = 14102,

        VPOPCNTWZrmk = 14103,

        VPOPCNTWZrmkz = 14104,

        VPOPCNTWZrr = 14105,

        VPOPCNTWZrrk = 14106,

        VPOPCNTWZrrkz = 14107,

        VPORDZ128rm = 14108,

        VPORDZ128rmb = 14109,

        VPORDZ128rmbk = 14110,

        VPORDZ128rmbkz = 14111,

        VPORDZ128rmk = 14112,

        VPORDZ128rmkz = 14113,

        VPORDZ128rr = 14114,

        VPORDZ128rrk = 14115,

        VPORDZ128rrkz = 14116,

        VPORDZ256rm = 14117,

        VPORDZ256rmb = 14118,

        VPORDZ256rmbk = 14119,

        VPORDZ256rmbkz = 14120,

        VPORDZ256rmk = 14121,

        VPORDZ256rmkz = 14122,

        VPORDZ256rr = 14123,

        VPORDZ256rrk = 14124,

        VPORDZ256rrkz = 14125,

        VPORDZrm = 14126,

        VPORDZrmb = 14127,

        VPORDZrmbk = 14128,

        VPORDZrmbkz = 14129,

        VPORDZrmk = 14130,

        VPORDZrmkz = 14131,

        VPORDZrr = 14132,

        VPORDZrrk = 14133,

        VPORDZrrkz = 14134,

        VPORQZ128rm = 14135,

        VPORQZ128rmb = 14136,

        VPORQZ128rmbk = 14137,

        VPORQZ128rmbkz = 14138,

        VPORQZ128rmk = 14139,

        VPORQZ128rmkz = 14140,

        VPORQZ128rr = 14141,

        VPORQZ128rrk = 14142,

        VPORQZ128rrkz = 14143,

        VPORQZ256rm = 14144,

        VPORQZ256rmb = 14145,

        VPORQZ256rmbk = 14146,

        VPORQZ256rmbkz = 14147,

        VPORQZ256rmk = 14148,

        VPORQZ256rmkz = 14149,

        VPORQZ256rr = 14150,

        VPORQZ256rrk = 14151,

        VPORQZ256rrkz = 14152,

        VPORQZrm = 14153,

        VPORQZrmb = 14154,

        VPORQZrmbk = 14155,

        VPORQZrmbkz = 14156,

        VPORQZrmk = 14157,

        VPORQZrmkz = 14158,

        VPORQZrr = 14159,

        VPORQZrrk = 14160,

        VPORQZrrkz = 14161,

        VPORYrm = 14162,

        VPORYrr = 14163,

        VPORrm = 14164,

        VPORrr = 14165,

        VPPERMrmr = 14166,

        VPPERMrrm = 14167,

        VPPERMrrr = 14168,

        VPPERMrrr_REV = 14169,

        VPROLDZ128mbi = 14170,

        VPROLDZ128mbik = 14171,

        VPROLDZ128mbikz = 14172,

        VPROLDZ128mi = 14173,

        VPROLDZ128mik = 14174,

        VPROLDZ128mikz = 14175,

        VPROLDZ128ri = 14176,

        VPROLDZ128rik = 14177,

        VPROLDZ128rikz = 14178,

        VPROLDZ256mbi = 14179,

        VPROLDZ256mbik = 14180,

        VPROLDZ256mbikz = 14181,

        VPROLDZ256mi = 14182,

        VPROLDZ256mik = 14183,

        VPROLDZ256mikz = 14184,

        VPROLDZ256ri = 14185,

        VPROLDZ256rik = 14186,

        VPROLDZ256rikz = 14187,

        VPROLDZmbi = 14188,

        VPROLDZmbik = 14189,

        VPROLDZmbikz = 14190,

        VPROLDZmi = 14191,

        VPROLDZmik = 14192,

        VPROLDZmikz = 14193,

        VPROLDZri = 14194,

        VPROLDZrik = 14195,

        VPROLDZrikz = 14196,

        VPROLQZ128mbi = 14197,

        VPROLQZ128mbik = 14198,

        VPROLQZ128mbikz = 14199,

        VPROLQZ128mi = 14200,

        VPROLQZ128mik = 14201,

        VPROLQZ128mikz = 14202,

        VPROLQZ128ri = 14203,

        VPROLQZ128rik = 14204,

        VPROLQZ128rikz = 14205,

        VPROLQZ256mbi = 14206,

        VPROLQZ256mbik = 14207,

        VPROLQZ256mbikz = 14208,

        VPROLQZ256mi = 14209,

        VPROLQZ256mik = 14210,

        VPROLQZ256mikz = 14211,

        VPROLQZ256ri = 14212,

        VPROLQZ256rik = 14213,

        VPROLQZ256rikz = 14214,

        VPROLQZmbi = 14215,

        VPROLQZmbik = 14216,

        VPROLQZmbikz = 14217,

        VPROLQZmi = 14218,

        VPROLQZmik = 14219,

        VPROLQZmikz = 14220,

        VPROLQZri = 14221,

        VPROLQZrik = 14222,

        VPROLQZrikz = 14223,

        VPROLVDZ128rm = 14224,

        VPROLVDZ128rmb = 14225,

        VPROLVDZ128rmbk = 14226,

        VPROLVDZ128rmbkz = 14227,

        VPROLVDZ128rmk = 14228,

        VPROLVDZ128rmkz = 14229,

        VPROLVDZ128rr = 14230,

        VPROLVDZ128rrk = 14231,

        VPROLVDZ128rrkz = 14232,

        VPROLVDZ256rm = 14233,

        VPROLVDZ256rmb = 14234,

        VPROLVDZ256rmbk = 14235,

        VPROLVDZ256rmbkz = 14236,

        VPROLVDZ256rmk = 14237,

        VPROLVDZ256rmkz = 14238,

        VPROLVDZ256rr = 14239,

        VPROLVDZ256rrk = 14240,

        VPROLVDZ256rrkz = 14241,

        VPROLVDZrm = 14242,

        VPROLVDZrmb = 14243,

        VPROLVDZrmbk = 14244,

        VPROLVDZrmbkz = 14245,

        VPROLVDZrmk = 14246,

        VPROLVDZrmkz = 14247,

        VPROLVDZrr = 14248,

        VPROLVDZrrk = 14249,

        VPROLVDZrrkz = 14250,

        VPROLVQZ128rm = 14251,

        VPROLVQZ128rmb = 14252,

        VPROLVQZ128rmbk = 14253,

        VPROLVQZ128rmbkz = 14254,

        VPROLVQZ128rmk = 14255,

        VPROLVQZ128rmkz = 14256,

        VPROLVQZ128rr = 14257,

        VPROLVQZ128rrk = 14258,

        VPROLVQZ128rrkz = 14259,

        VPROLVQZ256rm = 14260,

        VPROLVQZ256rmb = 14261,

        VPROLVQZ256rmbk = 14262,

        VPROLVQZ256rmbkz = 14263,

        VPROLVQZ256rmk = 14264,

        VPROLVQZ256rmkz = 14265,

        VPROLVQZ256rr = 14266,

        VPROLVQZ256rrk = 14267,

        VPROLVQZ256rrkz = 14268,

        VPROLVQZrm = 14269,

        VPROLVQZrmb = 14270,

        VPROLVQZrmbk = 14271,

        VPROLVQZrmbkz = 14272,

        VPROLVQZrmk = 14273,

        VPROLVQZrmkz = 14274,

        VPROLVQZrr = 14275,

        VPROLVQZrrk = 14276,

        VPROLVQZrrkz = 14277,

        VPRORDZ128mbi = 14278,

        VPRORDZ128mbik = 14279,

        VPRORDZ128mbikz = 14280,

        VPRORDZ128mi = 14281,

        VPRORDZ128mik = 14282,

        VPRORDZ128mikz = 14283,

        VPRORDZ128ri = 14284,

        VPRORDZ128rik = 14285,

        VPRORDZ128rikz = 14286,

        VPRORDZ256mbi = 14287,

        VPRORDZ256mbik = 14288,

        VPRORDZ256mbikz = 14289,

        VPRORDZ256mi = 14290,

        VPRORDZ256mik = 14291,

        VPRORDZ256mikz = 14292,

        VPRORDZ256ri = 14293,

        VPRORDZ256rik = 14294,

        VPRORDZ256rikz = 14295,

        VPRORDZmbi = 14296,

        VPRORDZmbik = 14297,

        VPRORDZmbikz = 14298,

        VPRORDZmi = 14299,

        VPRORDZmik = 14300,

        VPRORDZmikz = 14301,

        VPRORDZri = 14302,

        VPRORDZrik = 14303,

        VPRORDZrikz = 14304,

        VPRORQZ128mbi = 14305,

        VPRORQZ128mbik = 14306,

        VPRORQZ128mbikz = 14307,

        VPRORQZ128mi = 14308,

        VPRORQZ128mik = 14309,

        VPRORQZ128mikz = 14310,

        VPRORQZ128ri = 14311,

        VPRORQZ128rik = 14312,

        VPRORQZ128rikz = 14313,

        VPRORQZ256mbi = 14314,

        VPRORQZ256mbik = 14315,

        VPRORQZ256mbikz = 14316,

        VPRORQZ256mi = 14317,

        VPRORQZ256mik = 14318,

        VPRORQZ256mikz = 14319,

        VPRORQZ256ri = 14320,

        VPRORQZ256rik = 14321,

        VPRORQZ256rikz = 14322,

        VPRORQZmbi = 14323,

        VPRORQZmbik = 14324,

        VPRORQZmbikz = 14325,

        VPRORQZmi = 14326,

        VPRORQZmik = 14327,

        VPRORQZmikz = 14328,

        VPRORQZri = 14329,

        VPRORQZrik = 14330,

        VPRORQZrikz = 14331,

        VPRORVDZ128rm = 14332,

        VPRORVDZ128rmb = 14333,

        VPRORVDZ128rmbk = 14334,

        VPRORVDZ128rmbkz = 14335,

        VPRORVDZ128rmk = 14336,

        VPRORVDZ128rmkz = 14337,

        VPRORVDZ128rr = 14338,

        VPRORVDZ128rrk = 14339,

        VPRORVDZ128rrkz = 14340,

        VPRORVDZ256rm = 14341,

        VPRORVDZ256rmb = 14342,

        VPRORVDZ256rmbk = 14343,

        VPRORVDZ256rmbkz = 14344,

        VPRORVDZ256rmk = 14345,

        VPRORVDZ256rmkz = 14346,

        VPRORVDZ256rr = 14347,

        VPRORVDZ256rrk = 14348,

        VPRORVDZ256rrkz = 14349,

        VPRORVDZrm = 14350,

        VPRORVDZrmb = 14351,

        VPRORVDZrmbk = 14352,

        VPRORVDZrmbkz = 14353,

        VPRORVDZrmk = 14354,

        VPRORVDZrmkz = 14355,

        VPRORVDZrr = 14356,

        VPRORVDZrrk = 14357,

        VPRORVDZrrkz = 14358,

        VPRORVQZ128rm = 14359,

        VPRORVQZ128rmb = 14360,

        VPRORVQZ128rmbk = 14361,

        VPRORVQZ128rmbkz = 14362,

        VPRORVQZ128rmk = 14363,

        VPRORVQZ128rmkz = 14364,

        VPRORVQZ128rr = 14365,

        VPRORVQZ128rrk = 14366,

        VPRORVQZ128rrkz = 14367,

        VPRORVQZ256rm = 14368,

        VPRORVQZ256rmb = 14369,

        VPRORVQZ256rmbk = 14370,

        VPRORVQZ256rmbkz = 14371,

        VPRORVQZ256rmk = 14372,

        VPRORVQZ256rmkz = 14373,

        VPRORVQZ256rr = 14374,

        VPRORVQZ256rrk = 14375,

        VPRORVQZ256rrkz = 14376,

        VPRORVQZrm = 14377,

        VPRORVQZrmb = 14378,

        VPRORVQZrmbk = 14379,

        VPRORVQZrmbkz = 14380,

        VPRORVQZrmk = 14381,

        VPRORVQZrmkz = 14382,

        VPRORVQZrr = 14383,

        VPRORVQZrrk = 14384,

        VPRORVQZrrkz = 14385,

        VPROTBmi = 14386,

        VPROTBmr = 14387,

        VPROTBri = 14388,

        VPROTBrm = 14389,

        VPROTBrr = 14390,

        VPROTBrr_REV = 14391,

        VPROTDmi = 14392,

        VPROTDmr = 14393,

        VPROTDri = 14394,

        VPROTDrm = 14395,

        VPROTDrr = 14396,

        VPROTDrr_REV = 14397,

        VPROTQmi = 14398,

        VPROTQmr = 14399,

        VPROTQri = 14400,

        VPROTQrm = 14401,

        VPROTQrr = 14402,

        VPROTQrr_REV = 14403,

        VPROTWmi = 14404,

        VPROTWmr = 14405,

        VPROTWri = 14406,

        VPROTWrm = 14407,

        VPROTWrr = 14408,

        VPROTWrr_REV = 14409,

        VPSADBWYrm = 14410,

        VPSADBWYrr = 14411,

        VPSADBWZ128rm = 14412,

        VPSADBWZ128rr = 14413,

        VPSADBWZ256rm = 14414,

        VPSADBWZ256rr = 14415,

        VPSADBWZrm = 14416,

        VPSADBWZrr = 14417,

        VPSADBWrm = 14418,

        VPSADBWrr = 14419,

        VPSCATTERDDZ128mr = 14420,

        VPSCATTERDDZ256mr = 14421,

        VPSCATTERDDZmr = 14422,

        VPSCATTERDQZ128mr = 14423,

        VPSCATTERDQZ256mr = 14424,

        VPSCATTERDQZmr = 14425,

        VPSCATTERQDZ128mr = 14426,

        VPSCATTERQDZ256mr = 14427,

        VPSCATTERQDZmr = 14428,

        VPSCATTERQQZ128mr = 14429,

        VPSCATTERQQZ256mr = 14430,

        VPSCATTERQQZmr = 14431,

        VPSHABmr = 14432,

        VPSHABrm = 14433,

        VPSHABrr = 14434,

        VPSHABrr_REV = 14435,

        VPSHADmr = 14436,

        VPSHADrm = 14437,

        VPSHADrr = 14438,

        VPSHADrr_REV = 14439,

        VPSHAQmr = 14440,

        VPSHAQrm = 14441,

        VPSHAQrr = 14442,

        VPSHAQrr_REV = 14443,

        VPSHAWmr = 14444,

        VPSHAWrm = 14445,

        VPSHAWrr = 14446,

        VPSHAWrr_REV = 14447,

        VPSHLBmr = 14448,

        VPSHLBrm = 14449,

        VPSHLBrr = 14450,

        VPSHLBrr_REV = 14451,

        VPSHLDDZ128rmbi = 14452,

        VPSHLDDZ128rmbik = 14453,

        VPSHLDDZ128rmbikz = 14454,

        VPSHLDDZ128rmi = 14455,

        VPSHLDDZ128rmik = 14456,

        VPSHLDDZ128rmikz = 14457,

        VPSHLDDZ128rri = 14458,

        VPSHLDDZ128rrik = 14459,

        VPSHLDDZ128rrikz = 14460,

        VPSHLDDZ256rmbi = 14461,

        VPSHLDDZ256rmbik = 14462,

        VPSHLDDZ256rmbikz = 14463,

        VPSHLDDZ256rmi = 14464,

        VPSHLDDZ256rmik = 14465,

        VPSHLDDZ256rmikz = 14466,

        VPSHLDDZ256rri = 14467,

        VPSHLDDZ256rrik = 14468,

        VPSHLDDZ256rrikz = 14469,

        VPSHLDDZrmbi = 14470,

        VPSHLDDZrmbik = 14471,

        VPSHLDDZrmbikz = 14472,

        VPSHLDDZrmi = 14473,

        VPSHLDDZrmik = 14474,

        VPSHLDDZrmikz = 14475,

        VPSHLDDZrri = 14476,

        VPSHLDDZrrik = 14477,

        VPSHLDDZrrikz = 14478,

        VPSHLDQZ128rmbi = 14479,

        VPSHLDQZ128rmbik = 14480,

        VPSHLDQZ128rmbikz = 14481,

        VPSHLDQZ128rmi = 14482,

        VPSHLDQZ128rmik = 14483,

        VPSHLDQZ128rmikz = 14484,

        VPSHLDQZ128rri = 14485,

        VPSHLDQZ128rrik = 14486,

        VPSHLDQZ128rrikz = 14487,

        VPSHLDQZ256rmbi = 14488,

        VPSHLDQZ256rmbik = 14489,

        VPSHLDQZ256rmbikz = 14490,

        VPSHLDQZ256rmi = 14491,

        VPSHLDQZ256rmik = 14492,

        VPSHLDQZ256rmikz = 14493,

        VPSHLDQZ256rri = 14494,

        VPSHLDQZ256rrik = 14495,

        VPSHLDQZ256rrikz = 14496,

        VPSHLDQZrmbi = 14497,

        VPSHLDQZrmbik = 14498,

        VPSHLDQZrmbikz = 14499,

        VPSHLDQZrmi = 14500,

        VPSHLDQZrmik = 14501,

        VPSHLDQZrmikz = 14502,

        VPSHLDQZrri = 14503,

        VPSHLDQZrrik = 14504,

        VPSHLDQZrrikz = 14505,

        VPSHLDVDZ128m = 14506,

        VPSHLDVDZ128mb = 14507,

        VPSHLDVDZ128mbk = 14508,

        VPSHLDVDZ128mbkz = 14509,

        VPSHLDVDZ128mk = 14510,

        VPSHLDVDZ128mkz = 14511,

        VPSHLDVDZ128r = 14512,

        VPSHLDVDZ128rk = 14513,

        VPSHLDVDZ128rkz = 14514,

        VPSHLDVDZ256m = 14515,

        VPSHLDVDZ256mb = 14516,

        VPSHLDVDZ256mbk = 14517,

        VPSHLDVDZ256mbkz = 14518,

        VPSHLDVDZ256mk = 14519,

        VPSHLDVDZ256mkz = 14520,

        VPSHLDVDZ256r = 14521,

        VPSHLDVDZ256rk = 14522,

        VPSHLDVDZ256rkz = 14523,

        VPSHLDVDZm = 14524,

        VPSHLDVDZmb = 14525,

        VPSHLDVDZmbk = 14526,

        VPSHLDVDZmbkz = 14527,

        VPSHLDVDZmk = 14528,

        VPSHLDVDZmkz = 14529,

        VPSHLDVDZr = 14530,

        VPSHLDVDZrk = 14531,

        VPSHLDVDZrkz = 14532,

        VPSHLDVQZ128m = 14533,

        VPSHLDVQZ128mb = 14534,

        VPSHLDVQZ128mbk = 14535,

        VPSHLDVQZ128mbkz = 14536,

        VPSHLDVQZ128mk = 14537,

        VPSHLDVQZ128mkz = 14538,

        VPSHLDVQZ128r = 14539,

        VPSHLDVQZ128rk = 14540,

        VPSHLDVQZ128rkz = 14541,

        VPSHLDVQZ256m = 14542,

        VPSHLDVQZ256mb = 14543,

        VPSHLDVQZ256mbk = 14544,

        VPSHLDVQZ256mbkz = 14545,

        VPSHLDVQZ256mk = 14546,

        VPSHLDVQZ256mkz = 14547,

        VPSHLDVQZ256r = 14548,

        VPSHLDVQZ256rk = 14549,

        VPSHLDVQZ256rkz = 14550,

        VPSHLDVQZm = 14551,

        VPSHLDVQZmb = 14552,

        VPSHLDVQZmbk = 14553,

        VPSHLDVQZmbkz = 14554,

        VPSHLDVQZmk = 14555,

        VPSHLDVQZmkz = 14556,

        VPSHLDVQZr = 14557,

        VPSHLDVQZrk = 14558,

        VPSHLDVQZrkz = 14559,

        VPSHLDVWZ128m = 14560,

        VPSHLDVWZ128mk = 14561,

        VPSHLDVWZ128mkz = 14562,

        VPSHLDVWZ128r = 14563,

        VPSHLDVWZ128rk = 14564,

        VPSHLDVWZ128rkz = 14565,

        VPSHLDVWZ256m = 14566,

        VPSHLDVWZ256mk = 14567,

        VPSHLDVWZ256mkz = 14568,

        VPSHLDVWZ256r = 14569,

        VPSHLDVWZ256rk = 14570,

        VPSHLDVWZ256rkz = 14571,

        VPSHLDVWZm = 14572,

        VPSHLDVWZmk = 14573,

        VPSHLDVWZmkz = 14574,

        VPSHLDVWZr = 14575,

        VPSHLDVWZrk = 14576,

        VPSHLDVWZrkz = 14577,

        VPSHLDWZ128rmi = 14578,

        VPSHLDWZ128rmik = 14579,

        VPSHLDWZ128rmikz = 14580,

        VPSHLDWZ128rri = 14581,

        VPSHLDWZ128rrik = 14582,

        VPSHLDWZ128rrikz = 14583,

        VPSHLDWZ256rmi = 14584,

        VPSHLDWZ256rmik = 14585,

        VPSHLDWZ256rmikz = 14586,

        VPSHLDWZ256rri = 14587,

        VPSHLDWZ256rrik = 14588,

        VPSHLDWZ256rrikz = 14589,

        VPSHLDWZrmi = 14590,

        VPSHLDWZrmik = 14591,

        VPSHLDWZrmikz = 14592,

        VPSHLDWZrri = 14593,

        VPSHLDWZrrik = 14594,

        VPSHLDWZrrikz = 14595,

        VPSHLDmr = 14596,

        VPSHLDrm = 14597,

        VPSHLDrr = 14598,

        VPSHLDrr_REV = 14599,

        VPSHLQmr = 14600,

        VPSHLQrm = 14601,

        VPSHLQrr = 14602,

        VPSHLQrr_REV = 14603,

        VPSHLWmr = 14604,

        VPSHLWrm = 14605,

        VPSHLWrr = 14606,

        VPSHLWrr_REV = 14607,

        VPSHRDDZ128rmbi = 14608,

        VPSHRDDZ128rmbik = 14609,

        VPSHRDDZ128rmbikz = 14610,

        VPSHRDDZ128rmi = 14611,

        VPSHRDDZ128rmik = 14612,

        VPSHRDDZ128rmikz = 14613,

        VPSHRDDZ128rri = 14614,

        VPSHRDDZ128rrik = 14615,

        VPSHRDDZ128rrikz = 14616,

        VPSHRDDZ256rmbi = 14617,

        VPSHRDDZ256rmbik = 14618,

        VPSHRDDZ256rmbikz = 14619,

        VPSHRDDZ256rmi = 14620,

        VPSHRDDZ256rmik = 14621,

        VPSHRDDZ256rmikz = 14622,

        VPSHRDDZ256rri = 14623,

        VPSHRDDZ256rrik = 14624,

        VPSHRDDZ256rrikz = 14625,

        VPSHRDDZrmbi = 14626,

        VPSHRDDZrmbik = 14627,

        VPSHRDDZrmbikz = 14628,

        VPSHRDDZrmi = 14629,

        VPSHRDDZrmik = 14630,

        VPSHRDDZrmikz = 14631,

        VPSHRDDZrri = 14632,

        VPSHRDDZrrik = 14633,

        VPSHRDDZrrikz = 14634,

        VPSHRDQZ128rmbi = 14635,

        VPSHRDQZ128rmbik = 14636,

        VPSHRDQZ128rmbikz = 14637,

        VPSHRDQZ128rmi = 14638,

        VPSHRDQZ128rmik = 14639,

        VPSHRDQZ128rmikz = 14640,

        VPSHRDQZ128rri = 14641,

        VPSHRDQZ128rrik = 14642,

        VPSHRDQZ128rrikz = 14643,

        VPSHRDQZ256rmbi = 14644,

        VPSHRDQZ256rmbik = 14645,

        VPSHRDQZ256rmbikz = 14646,

        VPSHRDQZ256rmi = 14647,

        VPSHRDQZ256rmik = 14648,

        VPSHRDQZ256rmikz = 14649,

        VPSHRDQZ256rri = 14650,

        VPSHRDQZ256rrik = 14651,

        VPSHRDQZ256rrikz = 14652,

        VPSHRDQZrmbi = 14653,

        VPSHRDQZrmbik = 14654,

        VPSHRDQZrmbikz = 14655,

        VPSHRDQZrmi = 14656,

        VPSHRDQZrmik = 14657,

        VPSHRDQZrmikz = 14658,

        VPSHRDQZrri = 14659,

        VPSHRDQZrrik = 14660,

        VPSHRDQZrrikz = 14661,

        VPSHRDVDZ128m = 14662,

        VPSHRDVDZ128mb = 14663,

        VPSHRDVDZ128mbk = 14664,

        VPSHRDVDZ128mbkz = 14665,

        VPSHRDVDZ128mk = 14666,

        VPSHRDVDZ128mkz = 14667,

        VPSHRDVDZ128r = 14668,

        VPSHRDVDZ128rk = 14669,

        VPSHRDVDZ128rkz = 14670,

        VPSHRDVDZ256m = 14671,

        VPSHRDVDZ256mb = 14672,

        VPSHRDVDZ256mbk = 14673,

        VPSHRDVDZ256mbkz = 14674,

        VPSHRDVDZ256mk = 14675,

        VPSHRDVDZ256mkz = 14676,

        VPSHRDVDZ256r = 14677,

        VPSHRDVDZ256rk = 14678,

        VPSHRDVDZ256rkz = 14679,

        VPSHRDVDZm = 14680,

        VPSHRDVDZmb = 14681,

        VPSHRDVDZmbk = 14682,

        VPSHRDVDZmbkz = 14683,

        VPSHRDVDZmk = 14684,

        VPSHRDVDZmkz = 14685,

        VPSHRDVDZr = 14686,

        VPSHRDVDZrk = 14687,

        VPSHRDVDZrkz = 14688,

        VPSHRDVQZ128m = 14689,

        VPSHRDVQZ128mb = 14690,

        VPSHRDVQZ128mbk = 14691,

        VPSHRDVQZ128mbkz = 14692,

        VPSHRDVQZ128mk = 14693,

        VPSHRDVQZ128mkz = 14694,

        VPSHRDVQZ128r = 14695,

        VPSHRDVQZ128rk = 14696,

        VPSHRDVQZ128rkz = 14697,

        VPSHRDVQZ256m = 14698,

        VPSHRDVQZ256mb = 14699,

        VPSHRDVQZ256mbk = 14700,

        VPSHRDVQZ256mbkz = 14701,

        VPSHRDVQZ256mk = 14702,

        VPSHRDVQZ256mkz = 14703,

        VPSHRDVQZ256r = 14704,

        VPSHRDVQZ256rk = 14705,

        VPSHRDVQZ256rkz = 14706,

        VPSHRDVQZm = 14707,

        VPSHRDVQZmb = 14708,

        VPSHRDVQZmbk = 14709,

        VPSHRDVQZmbkz = 14710,

        VPSHRDVQZmk = 14711,

        VPSHRDVQZmkz = 14712,

        VPSHRDVQZr = 14713,

        VPSHRDVQZrk = 14714,

        VPSHRDVQZrkz = 14715,

        VPSHRDVWZ128m = 14716,

        VPSHRDVWZ128mk = 14717,

        VPSHRDVWZ128mkz = 14718,

        VPSHRDVWZ128r = 14719,

        VPSHRDVWZ128rk = 14720,

        VPSHRDVWZ128rkz = 14721,

        VPSHRDVWZ256m = 14722,

        VPSHRDVWZ256mk = 14723,

        VPSHRDVWZ256mkz = 14724,

        VPSHRDVWZ256r = 14725,

        VPSHRDVWZ256rk = 14726,

        VPSHRDVWZ256rkz = 14727,

        VPSHRDVWZm = 14728,

        VPSHRDVWZmk = 14729,

        VPSHRDVWZmkz = 14730,

        VPSHRDVWZr = 14731,

        VPSHRDVWZrk = 14732,

        VPSHRDVWZrkz = 14733,

        VPSHRDWZ128rmi = 14734,

        VPSHRDWZ128rmik = 14735,

        VPSHRDWZ128rmikz = 14736,

        VPSHRDWZ128rri = 14737,

        VPSHRDWZ128rrik = 14738,

        VPSHRDWZ128rrikz = 14739,

        VPSHRDWZ256rmi = 14740,

        VPSHRDWZ256rmik = 14741,

        VPSHRDWZ256rmikz = 14742,

        VPSHRDWZ256rri = 14743,

        VPSHRDWZ256rrik = 14744,

        VPSHRDWZ256rrikz = 14745,

        VPSHRDWZrmi = 14746,

        VPSHRDWZrmik = 14747,

        VPSHRDWZrmikz = 14748,

        VPSHRDWZrri = 14749,

        VPSHRDWZrrik = 14750,

        VPSHRDWZrrikz = 14751,

        VPSHUFBITQMBZ128rm = 14752,

        VPSHUFBITQMBZ128rmk = 14753,

        VPSHUFBITQMBZ128rr = 14754,

        VPSHUFBITQMBZ128rrk = 14755,

        VPSHUFBITQMBZ256rm = 14756,

        VPSHUFBITQMBZ256rmk = 14757,

        VPSHUFBITQMBZ256rr = 14758,

        VPSHUFBITQMBZ256rrk = 14759,

        VPSHUFBITQMBZrm = 14760,

        VPSHUFBITQMBZrmk = 14761,

        VPSHUFBITQMBZrr = 14762,

        VPSHUFBITQMBZrrk = 14763,

        VPSHUFBYrm = 14764,

        VPSHUFBYrr = 14765,

        VPSHUFBZ128rm = 14766,

        VPSHUFBZ128rmk = 14767,

        VPSHUFBZ128rmkz = 14768,

        VPSHUFBZ128rr = 14769,

        VPSHUFBZ128rrk = 14770,

        VPSHUFBZ128rrkz = 14771,

        VPSHUFBZ256rm = 14772,

        VPSHUFBZ256rmk = 14773,

        VPSHUFBZ256rmkz = 14774,

        VPSHUFBZ256rr = 14775,

        VPSHUFBZ256rrk = 14776,

        VPSHUFBZ256rrkz = 14777,

        VPSHUFBZrm = 14778,

        VPSHUFBZrmk = 14779,

        VPSHUFBZrmkz = 14780,

        VPSHUFBZrr = 14781,

        VPSHUFBZrrk = 14782,

        VPSHUFBZrrkz = 14783,

        VPSHUFBrm = 14784,

        VPSHUFBrr = 14785,

        VPSHUFDYmi = 14786,

        VPSHUFDYri = 14787,

        VPSHUFDZ128mbi = 14788,

        VPSHUFDZ128mbik = 14789,

        VPSHUFDZ128mbikz = 14790,

        VPSHUFDZ128mi = 14791,

        VPSHUFDZ128mik = 14792,

        VPSHUFDZ128mikz = 14793,

        VPSHUFDZ128ri = 14794,

        VPSHUFDZ128rik = 14795,

        VPSHUFDZ128rikz = 14796,

        VPSHUFDZ256mbi = 14797,

        VPSHUFDZ256mbik = 14798,

        VPSHUFDZ256mbikz = 14799,

        VPSHUFDZ256mi = 14800,

        VPSHUFDZ256mik = 14801,

        VPSHUFDZ256mikz = 14802,

        VPSHUFDZ256ri = 14803,

        VPSHUFDZ256rik = 14804,

        VPSHUFDZ256rikz = 14805,

        VPSHUFDZmbi = 14806,

        VPSHUFDZmbik = 14807,

        VPSHUFDZmbikz = 14808,

        VPSHUFDZmi = 14809,

        VPSHUFDZmik = 14810,

        VPSHUFDZmikz = 14811,

        VPSHUFDZri = 14812,

        VPSHUFDZrik = 14813,

        VPSHUFDZrikz = 14814,

        VPSHUFDmi = 14815,

        VPSHUFDri = 14816,

        VPSHUFHWYmi = 14817,

        VPSHUFHWYri = 14818,

        VPSHUFHWZ128mi = 14819,

        VPSHUFHWZ128mik = 14820,

        VPSHUFHWZ128mikz = 14821,

        VPSHUFHWZ128ri = 14822,

        VPSHUFHWZ128rik = 14823,

        VPSHUFHWZ128rikz = 14824,

        VPSHUFHWZ256mi = 14825,

        VPSHUFHWZ256mik = 14826,

        VPSHUFHWZ256mikz = 14827,

        VPSHUFHWZ256ri = 14828,

        VPSHUFHWZ256rik = 14829,

        VPSHUFHWZ256rikz = 14830,

        VPSHUFHWZmi = 14831,

        VPSHUFHWZmik = 14832,

        VPSHUFHWZmikz = 14833,

        VPSHUFHWZri = 14834,

        VPSHUFHWZrik = 14835,

        VPSHUFHWZrikz = 14836,

        VPSHUFHWmi = 14837,

        VPSHUFHWri = 14838,

        VPSHUFLWYmi = 14839,

        VPSHUFLWYri = 14840,

        VPSHUFLWZ128mi = 14841,

        VPSHUFLWZ128mik = 14842,

        VPSHUFLWZ128mikz = 14843,

        VPSHUFLWZ128ri = 14844,

        VPSHUFLWZ128rik = 14845,

        VPSHUFLWZ128rikz = 14846,

        VPSHUFLWZ256mi = 14847,

        VPSHUFLWZ256mik = 14848,

        VPSHUFLWZ256mikz = 14849,

        VPSHUFLWZ256ri = 14850,

        VPSHUFLWZ256rik = 14851,

        VPSHUFLWZ256rikz = 14852,

        VPSHUFLWZmi = 14853,

        VPSHUFLWZmik = 14854,

        VPSHUFLWZmikz = 14855,

        VPSHUFLWZri = 14856,

        VPSHUFLWZrik = 14857,

        VPSHUFLWZrikz = 14858,

        VPSHUFLWmi = 14859,

        VPSHUFLWri = 14860,

        VPSIGNBYrm = 14861,

        VPSIGNBYrr = 14862,

        VPSIGNBrm = 14863,

        VPSIGNBrr = 14864,

        VPSIGNDYrm = 14865,

        VPSIGNDYrr = 14866,

        VPSIGNDrm = 14867,

        VPSIGNDrr = 14868,

        VPSIGNWYrm = 14869,

        VPSIGNWYrr = 14870,

        VPSIGNWrm = 14871,

        VPSIGNWrr = 14872,

        VPSLLDQYri = 14873,

        VPSLLDQZ128mi = 14874,

        VPSLLDQZ128ri = 14875,

        VPSLLDQZ256mi = 14876,

        VPSLLDQZ256ri = 14877,

        VPSLLDQZmi = 14878,

        VPSLLDQZri = 14879,

        VPSLLDQri = 14880,

        VPSLLDYri = 14881,

        VPSLLDYrm = 14882,

        VPSLLDYrr = 14883,

        VPSLLDZ128mbi = 14884,

        VPSLLDZ128mbik = 14885,

        VPSLLDZ128mbikz = 14886,

        VPSLLDZ128mi = 14887,

        VPSLLDZ128mik = 14888,

        VPSLLDZ128mikz = 14889,

        VPSLLDZ128ri = 14890,

        VPSLLDZ128rik = 14891,

        VPSLLDZ128rikz = 14892,

        VPSLLDZ128rm = 14893,

        VPSLLDZ128rmk = 14894,

        VPSLLDZ128rmkz = 14895,

        VPSLLDZ128rr = 14896,

        VPSLLDZ128rrk = 14897,

        VPSLLDZ128rrkz = 14898,

        VPSLLDZ256mbi = 14899,

        VPSLLDZ256mbik = 14900,

        VPSLLDZ256mbikz = 14901,

        VPSLLDZ256mi = 14902,

        VPSLLDZ256mik = 14903,

        VPSLLDZ256mikz = 14904,

        VPSLLDZ256ri = 14905,

        VPSLLDZ256rik = 14906,

        VPSLLDZ256rikz = 14907,

        VPSLLDZ256rm = 14908,

        VPSLLDZ256rmk = 14909,

        VPSLLDZ256rmkz = 14910,

        VPSLLDZ256rr = 14911,

        VPSLLDZ256rrk = 14912,

        VPSLLDZ256rrkz = 14913,

        VPSLLDZmbi = 14914,

        VPSLLDZmbik = 14915,

        VPSLLDZmbikz = 14916,

        VPSLLDZmi = 14917,

        VPSLLDZmik = 14918,

        VPSLLDZmikz = 14919,

        VPSLLDZri = 14920,

        VPSLLDZrik = 14921,

        VPSLLDZrikz = 14922,

        VPSLLDZrm = 14923,

        VPSLLDZrmk = 14924,

        VPSLLDZrmkz = 14925,

        VPSLLDZrr = 14926,

        VPSLLDZrrk = 14927,

        VPSLLDZrrkz = 14928,

        VPSLLDri = 14929,

        VPSLLDrm = 14930,

        VPSLLDrr = 14931,

        VPSLLQYri = 14932,

        VPSLLQYrm = 14933,

        VPSLLQYrr = 14934,

        VPSLLQZ128mbi = 14935,

        VPSLLQZ128mbik = 14936,

        VPSLLQZ128mbikz = 14937,

        VPSLLQZ128mi = 14938,

        VPSLLQZ128mik = 14939,

        VPSLLQZ128mikz = 14940,

        VPSLLQZ128ri = 14941,

        VPSLLQZ128rik = 14942,

        VPSLLQZ128rikz = 14943,

        VPSLLQZ128rm = 14944,

        VPSLLQZ128rmk = 14945,

        VPSLLQZ128rmkz = 14946,

        VPSLLQZ128rr = 14947,

        VPSLLQZ128rrk = 14948,

        VPSLLQZ128rrkz = 14949,

        VPSLLQZ256mbi = 14950,

        VPSLLQZ256mbik = 14951,

        VPSLLQZ256mbikz = 14952,

        VPSLLQZ256mi = 14953,

        VPSLLQZ256mik = 14954,

        VPSLLQZ256mikz = 14955,

        VPSLLQZ256ri = 14956,

        VPSLLQZ256rik = 14957,

        VPSLLQZ256rikz = 14958,

        VPSLLQZ256rm = 14959,

        VPSLLQZ256rmk = 14960,

        VPSLLQZ256rmkz = 14961,

        VPSLLQZ256rr = 14962,

        VPSLLQZ256rrk = 14963,

        VPSLLQZ256rrkz = 14964,

        VPSLLQZmbi = 14965,

        VPSLLQZmbik = 14966,

        VPSLLQZmbikz = 14967,

        VPSLLQZmi = 14968,

        VPSLLQZmik = 14969,

        VPSLLQZmikz = 14970,

        VPSLLQZri = 14971,

        VPSLLQZrik = 14972,

        VPSLLQZrikz = 14973,

        VPSLLQZrm = 14974,

        VPSLLQZrmk = 14975,

        VPSLLQZrmkz = 14976,

        VPSLLQZrr = 14977,

        VPSLLQZrrk = 14978,

        VPSLLQZrrkz = 14979,

        VPSLLQri = 14980,

        VPSLLQrm = 14981,

        VPSLLQrr = 14982,

        VPSLLVDYrm = 14983,

        VPSLLVDYrr = 14984,

        VPSLLVDZ128rm = 14985,

        VPSLLVDZ128rmb = 14986,

        VPSLLVDZ128rmbk = 14987,

        VPSLLVDZ128rmbkz = 14988,

        VPSLLVDZ128rmk = 14989,

        VPSLLVDZ128rmkz = 14990,

        VPSLLVDZ128rr = 14991,

        VPSLLVDZ128rrk = 14992,

        VPSLLVDZ128rrkz = 14993,

        VPSLLVDZ256rm = 14994,

        VPSLLVDZ256rmb = 14995,

        VPSLLVDZ256rmbk = 14996,

        VPSLLVDZ256rmbkz = 14997,

        VPSLLVDZ256rmk = 14998,

        VPSLLVDZ256rmkz = 14999,

        VPSLLVDZ256rr = 15000,

        VPSLLVDZ256rrk = 15001,

        VPSLLVDZ256rrkz = 15002,

        VPSLLVDZrm = 15003,

        VPSLLVDZrmb = 15004,

        VPSLLVDZrmbk = 15005,

        VPSLLVDZrmbkz = 15006,

        VPSLLVDZrmk = 15007,

        VPSLLVDZrmkz = 15008,

        VPSLLVDZrr = 15009,

        VPSLLVDZrrk = 15010,

        VPSLLVDZrrkz = 15011,

        VPSLLVDrm = 15012,

        VPSLLVDrr = 15013,

        VPSLLVQYrm = 15014,

        VPSLLVQYrr = 15015,

        VPSLLVQZ128rm = 15016,

        VPSLLVQZ128rmb = 15017,

        VPSLLVQZ128rmbk = 15018,

        VPSLLVQZ128rmbkz = 15019,

        VPSLLVQZ128rmk = 15020,

        VPSLLVQZ128rmkz = 15021,

        VPSLLVQZ128rr = 15022,

        VPSLLVQZ128rrk = 15023,

        VPSLLVQZ128rrkz = 15024,

        VPSLLVQZ256rm = 15025,

        VPSLLVQZ256rmb = 15026,

        VPSLLVQZ256rmbk = 15027,

        VPSLLVQZ256rmbkz = 15028,

        VPSLLVQZ256rmk = 15029,

        VPSLLVQZ256rmkz = 15030,

        VPSLLVQZ256rr = 15031,

        VPSLLVQZ256rrk = 15032,

        VPSLLVQZ256rrkz = 15033,

        VPSLLVQZrm = 15034,

        VPSLLVQZrmb = 15035,

        VPSLLVQZrmbk = 15036,

        VPSLLVQZrmbkz = 15037,

        VPSLLVQZrmk = 15038,

        VPSLLVQZrmkz = 15039,

        VPSLLVQZrr = 15040,

        VPSLLVQZrrk = 15041,

        VPSLLVQZrrkz = 15042,

        VPSLLVQrm = 15043,

        VPSLLVQrr = 15044,

        VPSLLVWZ128rm = 15045,

        VPSLLVWZ128rmk = 15046,

        VPSLLVWZ128rmkz = 15047,

        VPSLLVWZ128rr = 15048,

        VPSLLVWZ128rrk = 15049,

        VPSLLVWZ128rrkz = 15050,

        VPSLLVWZ256rm = 15051,

        VPSLLVWZ256rmk = 15052,

        VPSLLVWZ256rmkz = 15053,

        VPSLLVWZ256rr = 15054,

        VPSLLVWZ256rrk = 15055,

        VPSLLVWZ256rrkz = 15056,

        VPSLLVWZrm = 15057,

        VPSLLVWZrmk = 15058,

        VPSLLVWZrmkz = 15059,

        VPSLLVWZrr = 15060,

        VPSLLVWZrrk = 15061,

        VPSLLVWZrrkz = 15062,

        VPSLLWYri = 15063,

        VPSLLWYrm = 15064,

        VPSLLWYrr = 15065,

        VPSLLWZ128mi = 15066,

        VPSLLWZ128mik = 15067,

        VPSLLWZ128mikz = 15068,

        VPSLLWZ128ri = 15069,

        VPSLLWZ128rik = 15070,

        VPSLLWZ128rikz = 15071,

        VPSLLWZ128rm = 15072,

        VPSLLWZ128rmk = 15073,

        VPSLLWZ128rmkz = 15074,

        VPSLLWZ128rr = 15075,

        VPSLLWZ128rrk = 15076,

        VPSLLWZ128rrkz = 15077,

        VPSLLWZ256mi = 15078,

        VPSLLWZ256mik = 15079,

        VPSLLWZ256mikz = 15080,

        VPSLLWZ256ri = 15081,

        VPSLLWZ256rik = 15082,

        VPSLLWZ256rikz = 15083,

        VPSLLWZ256rm = 15084,

        VPSLLWZ256rmk = 15085,

        VPSLLWZ256rmkz = 15086,

        VPSLLWZ256rr = 15087,

        VPSLLWZ256rrk = 15088,

        VPSLLWZ256rrkz = 15089,

        VPSLLWZmi = 15090,

        VPSLLWZmik = 15091,

        VPSLLWZmikz = 15092,

        VPSLLWZri = 15093,

        VPSLLWZrik = 15094,

        VPSLLWZrikz = 15095,

        VPSLLWZrm = 15096,

        VPSLLWZrmk = 15097,

        VPSLLWZrmkz = 15098,

        VPSLLWZrr = 15099,

        VPSLLWZrrk = 15100,

        VPSLLWZrrkz = 15101,

        VPSLLWri = 15102,

        VPSLLWrm = 15103,

        VPSLLWrr = 15104,

        VPSRADYri = 15105,

        VPSRADYrm = 15106,

        VPSRADYrr = 15107,

        VPSRADZ128mbi = 15108,

        VPSRADZ128mbik = 15109,

        VPSRADZ128mbikz = 15110,

        VPSRADZ128mi = 15111,

        VPSRADZ128mik = 15112,

        VPSRADZ128mikz = 15113,

        VPSRADZ128ri = 15114,

        VPSRADZ128rik = 15115,

        VPSRADZ128rikz = 15116,

        VPSRADZ128rm = 15117,

        VPSRADZ128rmk = 15118,

        VPSRADZ128rmkz = 15119,

        VPSRADZ128rr = 15120,

        VPSRADZ128rrk = 15121,

        VPSRADZ128rrkz = 15122,

        VPSRADZ256mbi = 15123,

        VPSRADZ256mbik = 15124,

        VPSRADZ256mbikz = 15125,

        VPSRADZ256mi = 15126,

        VPSRADZ256mik = 15127,

        VPSRADZ256mikz = 15128,

        VPSRADZ256ri = 15129,

        VPSRADZ256rik = 15130,

        VPSRADZ256rikz = 15131,

        VPSRADZ256rm = 15132,

        VPSRADZ256rmk = 15133,

        VPSRADZ256rmkz = 15134,

        VPSRADZ256rr = 15135,

        VPSRADZ256rrk = 15136,

        VPSRADZ256rrkz = 15137,

        VPSRADZmbi = 15138,

        VPSRADZmbik = 15139,

        VPSRADZmbikz = 15140,

        VPSRADZmi = 15141,

        VPSRADZmik = 15142,

        VPSRADZmikz = 15143,

        VPSRADZri = 15144,

        VPSRADZrik = 15145,

        VPSRADZrikz = 15146,

        VPSRADZrm = 15147,

        VPSRADZrmk = 15148,

        VPSRADZrmkz = 15149,

        VPSRADZrr = 15150,

        VPSRADZrrk = 15151,

        VPSRADZrrkz = 15152,

        VPSRADri = 15153,

        VPSRADrm = 15154,

        VPSRADrr = 15155,

        VPSRAQZ128mbi = 15156,

        VPSRAQZ128mbik = 15157,

        VPSRAQZ128mbikz = 15158,

        VPSRAQZ128mi = 15159,

        VPSRAQZ128mik = 15160,

        VPSRAQZ128mikz = 15161,

        VPSRAQZ128ri = 15162,

        VPSRAQZ128rik = 15163,

        VPSRAQZ128rikz = 15164,

        VPSRAQZ128rm = 15165,

        VPSRAQZ128rmk = 15166,

        VPSRAQZ128rmkz = 15167,

        VPSRAQZ128rr = 15168,

        VPSRAQZ128rrk = 15169,

        VPSRAQZ128rrkz = 15170,

        VPSRAQZ256mbi = 15171,

        VPSRAQZ256mbik = 15172,

        VPSRAQZ256mbikz = 15173,

        VPSRAQZ256mi = 15174,

        VPSRAQZ256mik = 15175,

        VPSRAQZ256mikz = 15176,

        VPSRAQZ256ri = 15177,

        VPSRAQZ256rik = 15178,

        VPSRAQZ256rikz = 15179,

        VPSRAQZ256rm = 15180,

        VPSRAQZ256rmk = 15181,

        VPSRAQZ256rmkz = 15182,

        VPSRAQZ256rr = 15183,

        VPSRAQZ256rrk = 15184,

        VPSRAQZ256rrkz = 15185,

        VPSRAQZmbi = 15186,

        VPSRAQZmbik = 15187,

        VPSRAQZmbikz = 15188,

        VPSRAQZmi = 15189,

        VPSRAQZmik = 15190,

        VPSRAQZmikz = 15191,

        VPSRAQZri = 15192,

        VPSRAQZrik = 15193,

        VPSRAQZrikz = 15194,

        VPSRAQZrm = 15195,

        VPSRAQZrmk = 15196,

        VPSRAQZrmkz = 15197,

        VPSRAQZrr = 15198,

        VPSRAQZrrk = 15199,

        VPSRAQZrrkz = 15200,

        VPSRAVDYrm = 15201,

        VPSRAVDYrr = 15202,

        VPSRAVDZ128rm = 15203,

        VPSRAVDZ128rmb = 15204,

        VPSRAVDZ128rmbk = 15205,

        VPSRAVDZ128rmbkz = 15206,

        VPSRAVDZ128rmk = 15207,

        VPSRAVDZ128rmkz = 15208,

        VPSRAVDZ128rr = 15209,

        VPSRAVDZ128rrk = 15210,

        VPSRAVDZ128rrkz = 15211,

        VPSRAVDZ256rm = 15212,

        VPSRAVDZ256rmb = 15213,

        VPSRAVDZ256rmbk = 15214,

        VPSRAVDZ256rmbkz = 15215,

        VPSRAVDZ256rmk = 15216,

        VPSRAVDZ256rmkz = 15217,

        VPSRAVDZ256rr = 15218,

        VPSRAVDZ256rrk = 15219,

        VPSRAVDZ256rrkz = 15220,

        VPSRAVDZrm = 15221,

        VPSRAVDZrmb = 15222,

        VPSRAVDZrmbk = 15223,

        VPSRAVDZrmbkz = 15224,

        VPSRAVDZrmk = 15225,

        VPSRAVDZrmkz = 15226,

        VPSRAVDZrr = 15227,

        VPSRAVDZrrk = 15228,

        VPSRAVDZrrkz = 15229,

        VPSRAVDrm = 15230,

        VPSRAVDrr = 15231,

        VPSRAVQZ128rm = 15232,

        VPSRAVQZ128rmb = 15233,

        VPSRAVQZ128rmbk = 15234,

        VPSRAVQZ128rmbkz = 15235,

        VPSRAVQZ128rmk = 15236,

        VPSRAVQZ128rmkz = 15237,

        VPSRAVQZ128rr = 15238,

        VPSRAVQZ128rrk = 15239,

        VPSRAVQZ128rrkz = 15240,

        VPSRAVQZ256rm = 15241,

        VPSRAVQZ256rmb = 15242,

        VPSRAVQZ256rmbk = 15243,

        VPSRAVQZ256rmbkz = 15244,

        VPSRAVQZ256rmk = 15245,

        VPSRAVQZ256rmkz = 15246,

        VPSRAVQZ256rr = 15247,

        VPSRAVQZ256rrk = 15248,

        VPSRAVQZ256rrkz = 15249,

        VPSRAVQZrm = 15250,

        VPSRAVQZrmb = 15251,

        VPSRAVQZrmbk = 15252,

        VPSRAVQZrmbkz = 15253,

        VPSRAVQZrmk = 15254,

        VPSRAVQZrmkz = 15255,

        VPSRAVQZrr = 15256,

        VPSRAVQZrrk = 15257,

        VPSRAVQZrrkz = 15258,

        VPSRAVWZ128rm = 15259,

        VPSRAVWZ128rmk = 15260,

        VPSRAVWZ128rmkz = 15261,

        VPSRAVWZ128rr = 15262,

        VPSRAVWZ128rrk = 15263,

        VPSRAVWZ128rrkz = 15264,

        VPSRAVWZ256rm = 15265,

        VPSRAVWZ256rmk = 15266,

        VPSRAVWZ256rmkz = 15267,

        VPSRAVWZ256rr = 15268,

        VPSRAVWZ256rrk = 15269,

        VPSRAVWZ256rrkz = 15270,

        VPSRAVWZrm = 15271,

        VPSRAVWZrmk = 15272,

        VPSRAVWZrmkz = 15273,

        VPSRAVWZrr = 15274,

        VPSRAVWZrrk = 15275,

        VPSRAVWZrrkz = 15276,

        VPSRAWYri = 15277,

        VPSRAWYrm = 15278,

        VPSRAWYrr = 15279,

        VPSRAWZ128mi = 15280,

        VPSRAWZ128mik = 15281,

        VPSRAWZ128mikz = 15282,

        VPSRAWZ128ri = 15283,

        VPSRAWZ128rik = 15284,

        VPSRAWZ128rikz = 15285,

        VPSRAWZ128rm = 15286,

        VPSRAWZ128rmk = 15287,

        VPSRAWZ128rmkz = 15288,

        VPSRAWZ128rr = 15289,

        VPSRAWZ128rrk = 15290,

        VPSRAWZ128rrkz = 15291,

        VPSRAWZ256mi = 15292,

        VPSRAWZ256mik = 15293,

        VPSRAWZ256mikz = 15294,

        VPSRAWZ256ri = 15295,

        VPSRAWZ256rik = 15296,

        VPSRAWZ256rikz = 15297,

        VPSRAWZ256rm = 15298,

        VPSRAWZ256rmk = 15299,

        VPSRAWZ256rmkz = 15300,

        VPSRAWZ256rr = 15301,

        VPSRAWZ256rrk = 15302,

        VPSRAWZ256rrkz = 15303,

        VPSRAWZmi = 15304,

        VPSRAWZmik = 15305,

        VPSRAWZmikz = 15306,

        VPSRAWZri = 15307,

        VPSRAWZrik = 15308,

        VPSRAWZrikz = 15309,

        VPSRAWZrm = 15310,

        VPSRAWZrmk = 15311,

        VPSRAWZrmkz = 15312,

        VPSRAWZrr = 15313,

        VPSRAWZrrk = 15314,

        VPSRAWZrrkz = 15315,

        VPSRAWri = 15316,

        VPSRAWrm = 15317,

        VPSRAWrr = 15318,

        VPSRLDQYri = 15319,

        VPSRLDQZ128mi = 15320,

        VPSRLDQZ128ri = 15321,

        VPSRLDQZ256mi = 15322,

        VPSRLDQZ256ri = 15323,

        VPSRLDQZmi = 15324,

        VPSRLDQZri = 15325,

        VPSRLDQri = 15326,

        VPSRLDYri = 15327,

        VPSRLDYrm = 15328,

        VPSRLDYrr = 15329,

        VPSRLDZ128mbi = 15330,

        VPSRLDZ128mbik = 15331,

        VPSRLDZ128mbikz = 15332,

        VPSRLDZ128mi = 15333,

        VPSRLDZ128mik = 15334,

        VPSRLDZ128mikz = 15335,

        VPSRLDZ128ri = 15336,

        VPSRLDZ128rik = 15337,

        VPSRLDZ128rikz = 15338,

        VPSRLDZ128rm = 15339,

        VPSRLDZ128rmk = 15340,

        VPSRLDZ128rmkz = 15341,

        VPSRLDZ128rr = 15342,

        VPSRLDZ128rrk = 15343,

        VPSRLDZ128rrkz = 15344,

        VPSRLDZ256mbi = 15345,

        VPSRLDZ256mbik = 15346,

        VPSRLDZ256mbikz = 15347,

        VPSRLDZ256mi = 15348,

        VPSRLDZ256mik = 15349,

        VPSRLDZ256mikz = 15350,

        VPSRLDZ256ri = 15351,

        VPSRLDZ256rik = 15352,

        VPSRLDZ256rikz = 15353,

        VPSRLDZ256rm = 15354,

        VPSRLDZ256rmk = 15355,

        VPSRLDZ256rmkz = 15356,

        VPSRLDZ256rr = 15357,

        VPSRLDZ256rrk = 15358,

        VPSRLDZ256rrkz = 15359,

        VPSRLDZmbi = 15360,

        VPSRLDZmbik = 15361,

        VPSRLDZmbikz = 15362,

        VPSRLDZmi = 15363,

        VPSRLDZmik = 15364,

        VPSRLDZmikz = 15365,

        VPSRLDZri = 15366,

        VPSRLDZrik = 15367,

        VPSRLDZrikz = 15368,

        VPSRLDZrm = 15369,

        VPSRLDZrmk = 15370,

        VPSRLDZrmkz = 15371,

        VPSRLDZrr = 15372,

        VPSRLDZrrk = 15373,

        VPSRLDZrrkz = 15374,

        VPSRLDri = 15375,

        VPSRLDrm = 15376,

        VPSRLDrr = 15377,

        VPSRLQYri = 15378,

        VPSRLQYrm = 15379,

        VPSRLQYrr = 15380,

        VPSRLQZ128mbi = 15381,

        VPSRLQZ128mbik = 15382,

        VPSRLQZ128mbikz = 15383,

        VPSRLQZ128mi = 15384,

        VPSRLQZ128mik = 15385,

        VPSRLQZ128mikz = 15386,

        VPSRLQZ128ri = 15387,

        VPSRLQZ128rik = 15388,

        VPSRLQZ128rikz = 15389,

        VPSRLQZ128rm = 15390,

        VPSRLQZ128rmk = 15391,

        VPSRLQZ128rmkz = 15392,

        VPSRLQZ128rr = 15393,

        VPSRLQZ128rrk = 15394,

        VPSRLQZ128rrkz = 15395,

        VPSRLQZ256mbi = 15396,

        VPSRLQZ256mbik = 15397,

        VPSRLQZ256mbikz = 15398,

        VPSRLQZ256mi = 15399,

        VPSRLQZ256mik = 15400,

        VPSRLQZ256mikz = 15401,

        VPSRLQZ256ri = 15402,

        VPSRLQZ256rik = 15403,

        VPSRLQZ256rikz = 15404,

        VPSRLQZ256rm = 15405,

        VPSRLQZ256rmk = 15406,

        VPSRLQZ256rmkz = 15407,

        VPSRLQZ256rr = 15408,

        VPSRLQZ256rrk = 15409,

        VPSRLQZ256rrkz = 15410,

        VPSRLQZmbi = 15411,

        VPSRLQZmbik = 15412,

        VPSRLQZmbikz = 15413,

        VPSRLQZmi = 15414,

        VPSRLQZmik = 15415,

        VPSRLQZmikz = 15416,

        VPSRLQZri = 15417,

        VPSRLQZrik = 15418,

        VPSRLQZrikz = 15419,

        VPSRLQZrm = 15420,

        VPSRLQZrmk = 15421,

        VPSRLQZrmkz = 15422,

        VPSRLQZrr = 15423,

        VPSRLQZrrk = 15424,

        VPSRLQZrrkz = 15425,

        VPSRLQri = 15426,

        VPSRLQrm = 15427,

        VPSRLQrr = 15428,

        VPSRLVDYrm = 15429,

        VPSRLVDYrr = 15430,

        VPSRLVDZ128rm = 15431,

        VPSRLVDZ128rmb = 15432,

        VPSRLVDZ128rmbk = 15433,

        VPSRLVDZ128rmbkz = 15434,

        VPSRLVDZ128rmk = 15435,

        VPSRLVDZ128rmkz = 15436,

        VPSRLVDZ128rr = 15437,

        VPSRLVDZ128rrk = 15438,

        VPSRLVDZ128rrkz = 15439,

        VPSRLVDZ256rm = 15440,

        VPSRLVDZ256rmb = 15441,

        VPSRLVDZ256rmbk = 15442,

        VPSRLVDZ256rmbkz = 15443,

        VPSRLVDZ256rmk = 15444,

        VPSRLVDZ256rmkz = 15445,

        VPSRLVDZ256rr = 15446,

        VPSRLVDZ256rrk = 15447,

        VPSRLVDZ256rrkz = 15448,

        VPSRLVDZrm = 15449,

        VPSRLVDZrmb = 15450,

        VPSRLVDZrmbk = 15451,

        VPSRLVDZrmbkz = 15452,

        VPSRLVDZrmk = 15453,

        VPSRLVDZrmkz = 15454,

        VPSRLVDZrr = 15455,

        VPSRLVDZrrk = 15456,

        VPSRLVDZrrkz = 15457,

        VPSRLVDrm = 15458,

        VPSRLVDrr = 15459,

        VPSRLVQYrm = 15460,

        VPSRLVQYrr = 15461,

        VPSRLVQZ128rm = 15462,

        VPSRLVQZ128rmb = 15463,

        VPSRLVQZ128rmbk = 15464,

        VPSRLVQZ128rmbkz = 15465,

        VPSRLVQZ128rmk = 15466,

        VPSRLVQZ128rmkz = 15467,

        VPSRLVQZ128rr = 15468,

        VPSRLVQZ128rrk = 15469,

        VPSRLVQZ128rrkz = 15470,

        VPSRLVQZ256rm = 15471,

        VPSRLVQZ256rmb = 15472,

        VPSRLVQZ256rmbk = 15473,

        VPSRLVQZ256rmbkz = 15474,

        VPSRLVQZ256rmk = 15475,

        VPSRLVQZ256rmkz = 15476,

        VPSRLVQZ256rr = 15477,

        VPSRLVQZ256rrk = 15478,

        VPSRLVQZ256rrkz = 15479,

        VPSRLVQZrm = 15480,

        VPSRLVQZrmb = 15481,

        VPSRLVQZrmbk = 15482,

        VPSRLVQZrmbkz = 15483,

        VPSRLVQZrmk = 15484,

        VPSRLVQZrmkz = 15485,

        VPSRLVQZrr = 15486,

        VPSRLVQZrrk = 15487,

        VPSRLVQZrrkz = 15488,

        VPSRLVQrm = 15489,

        VPSRLVQrr = 15490,

        VPSRLVWZ128rm = 15491,

        VPSRLVWZ128rmk = 15492,

        VPSRLVWZ128rmkz = 15493,

        VPSRLVWZ128rr = 15494,

        VPSRLVWZ128rrk = 15495,

        VPSRLVWZ128rrkz = 15496,

        VPSRLVWZ256rm = 15497,

        VPSRLVWZ256rmk = 15498,

        VPSRLVWZ256rmkz = 15499,

        VPSRLVWZ256rr = 15500,

        VPSRLVWZ256rrk = 15501,

        VPSRLVWZ256rrkz = 15502,

        VPSRLVWZrm = 15503,

        VPSRLVWZrmk = 15504,

        VPSRLVWZrmkz = 15505,

        VPSRLVWZrr = 15506,

        VPSRLVWZrrk = 15507,

        VPSRLVWZrrkz = 15508,

        VPSRLWYri = 15509,

        VPSRLWYrm = 15510,

        VPSRLWYrr = 15511,

        VPSRLWZ128mi = 15512,

        VPSRLWZ128mik = 15513,

        VPSRLWZ128mikz = 15514,

        VPSRLWZ128ri = 15515,

        VPSRLWZ128rik = 15516,

        VPSRLWZ128rikz = 15517,

        VPSRLWZ128rm = 15518,

        VPSRLWZ128rmk = 15519,

        VPSRLWZ128rmkz = 15520,

        VPSRLWZ128rr = 15521,

        VPSRLWZ128rrk = 15522,

        VPSRLWZ128rrkz = 15523,

        VPSRLWZ256mi = 15524,

        VPSRLWZ256mik = 15525,

        VPSRLWZ256mikz = 15526,

        VPSRLWZ256ri = 15527,

        VPSRLWZ256rik = 15528,

        VPSRLWZ256rikz = 15529,

        VPSRLWZ256rm = 15530,

        VPSRLWZ256rmk = 15531,

        VPSRLWZ256rmkz = 15532,

        VPSRLWZ256rr = 15533,

        VPSRLWZ256rrk = 15534,

        VPSRLWZ256rrkz = 15535,

        VPSRLWZmi = 15536,

        VPSRLWZmik = 15537,

        VPSRLWZmikz = 15538,

        VPSRLWZri = 15539,

        VPSRLWZrik = 15540,

        VPSRLWZrikz = 15541,

        VPSRLWZrm = 15542,

        VPSRLWZrmk = 15543,

        VPSRLWZrmkz = 15544,

        VPSRLWZrr = 15545,

        VPSRLWZrrk = 15546,

        VPSRLWZrrkz = 15547,

        VPSRLWri = 15548,

        VPSRLWrm = 15549,

        VPSRLWrr = 15550,

        VPSUBBYrm = 15551,

        VPSUBBYrr = 15552,

        VPSUBBZ128rm = 15553,

        VPSUBBZ128rmk = 15554,

        VPSUBBZ128rmkz = 15555,

        VPSUBBZ128rr = 15556,

        VPSUBBZ128rrk = 15557,

        VPSUBBZ128rrkz = 15558,

        VPSUBBZ256rm = 15559,

        VPSUBBZ256rmk = 15560,

        VPSUBBZ256rmkz = 15561,

        VPSUBBZ256rr = 15562,

        VPSUBBZ256rrk = 15563,

        VPSUBBZ256rrkz = 15564,

        VPSUBBZrm = 15565,

        VPSUBBZrmk = 15566,

        VPSUBBZrmkz = 15567,

        VPSUBBZrr = 15568,

        VPSUBBZrrk = 15569,

        VPSUBBZrrkz = 15570,

        VPSUBBrm = 15571,

        VPSUBBrr = 15572,

        VPSUBDYrm = 15573,

        VPSUBDYrr = 15574,

        VPSUBDZ128rm = 15575,

        VPSUBDZ128rmb = 15576,

        VPSUBDZ128rmbk = 15577,

        VPSUBDZ128rmbkz = 15578,

        VPSUBDZ128rmk = 15579,

        VPSUBDZ128rmkz = 15580,

        VPSUBDZ128rr = 15581,

        VPSUBDZ128rrk = 15582,

        VPSUBDZ128rrkz = 15583,

        VPSUBDZ256rm = 15584,

        VPSUBDZ256rmb = 15585,

        VPSUBDZ256rmbk = 15586,

        VPSUBDZ256rmbkz = 15587,

        VPSUBDZ256rmk = 15588,

        VPSUBDZ256rmkz = 15589,

        VPSUBDZ256rr = 15590,

        VPSUBDZ256rrk = 15591,

        VPSUBDZ256rrkz = 15592,

        VPSUBDZrm = 15593,

        VPSUBDZrmb = 15594,

        VPSUBDZrmbk = 15595,

        VPSUBDZrmbkz = 15596,

        VPSUBDZrmk = 15597,

        VPSUBDZrmkz = 15598,

        VPSUBDZrr = 15599,

        VPSUBDZrrk = 15600,

        VPSUBDZrrkz = 15601,

        VPSUBDrm = 15602,

        VPSUBDrr = 15603,

        VPSUBQYrm = 15604,

        VPSUBQYrr = 15605,

        VPSUBQZ128rm = 15606,

        VPSUBQZ128rmb = 15607,

        VPSUBQZ128rmbk = 15608,

        VPSUBQZ128rmbkz = 15609,

        VPSUBQZ128rmk = 15610,

        VPSUBQZ128rmkz = 15611,

        VPSUBQZ128rr = 15612,

        VPSUBQZ128rrk = 15613,

        VPSUBQZ128rrkz = 15614,

        VPSUBQZ256rm = 15615,

        VPSUBQZ256rmb = 15616,

        VPSUBQZ256rmbk = 15617,

        VPSUBQZ256rmbkz = 15618,

        VPSUBQZ256rmk = 15619,

        VPSUBQZ256rmkz = 15620,

        VPSUBQZ256rr = 15621,

        VPSUBQZ256rrk = 15622,

        VPSUBQZ256rrkz = 15623,

        VPSUBQZrm = 15624,

        VPSUBQZrmb = 15625,

        VPSUBQZrmbk = 15626,

        VPSUBQZrmbkz = 15627,

        VPSUBQZrmk = 15628,

        VPSUBQZrmkz = 15629,

        VPSUBQZrr = 15630,

        VPSUBQZrrk = 15631,

        VPSUBQZrrkz = 15632,

        VPSUBQrm = 15633,

        VPSUBQrr = 15634,

        VPSUBSBYrm = 15635,

        VPSUBSBYrr = 15636,

        VPSUBSBZ128rm = 15637,

        VPSUBSBZ128rmk = 15638,

        VPSUBSBZ128rmkz = 15639,

        VPSUBSBZ128rr = 15640,

        VPSUBSBZ128rrk = 15641,

        VPSUBSBZ128rrkz = 15642,

        VPSUBSBZ256rm = 15643,

        VPSUBSBZ256rmk = 15644,

        VPSUBSBZ256rmkz = 15645,

        VPSUBSBZ256rr = 15646,

        VPSUBSBZ256rrk = 15647,

        VPSUBSBZ256rrkz = 15648,

        VPSUBSBZrm = 15649,

        VPSUBSBZrmk = 15650,

        VPSUBSBZrmkz = 15651,

        VPSUBSBZrr = 15652,

        VPSUBSBZrrk = 15653,

        VPSUBSBZrrkz = 15654,

        VPSUBSBrm = 15655,

        VPSUBSBrr = 15656,

        VPSUBSWYrm = 15657,

        VPSUBSWYrr = 15658,

        VPSUBSWZ128rm = 15659,

        VPSUBSWZ128rmk = 15660,

        VPSUBSWZ128rmkz = 15661,

        VPSUBSWZ128rr = 15662,

        VPSUBSWZ128rrk = 15663,

        VPSUBSWZ128rrkz = 15664,

        VPSUBSWZ256rm = 15665,

        VPSUBSWZ256rmk = 15666,

        VPSUBSWZ256rmkz = 15667,

        VPSUBSWZ256rr = 15668,

        VPSUBSWZ256rrk = 15669,

        VPSUBSWZ256rrkz = 15670,

        VPSUBSWZrm = 15671,

        VPSUBSWZrmk = 15672,

        VPSUBSWZrmkz = 15673,

        VPSUBSWZrr = 15674,

        VPSUBSWZrrk = 15675,

        VPSUBSWZrrkz = 15676,

        VPSUBSWrm = 15677,

        VPSUBSWrr = 15678,

        VPSUBUSBYrm = 15679,

        VPSUBUSBYrr = 15680,

        VPSUBUSBZ128rm = 15681,

        VPSUBUSBZ128rmk = 15682,

        VPSUBUSBZ128rmkz = 15683,

        VPSUBUSBZ128rr = 15684,

        VPSUBUSBZ128rrk = 15685,

        VPSUBUSBZ128rrkz = 15686,

        VPSUBUSBZ256rm = 15687,

        VPSUBUSBZ256rmk = 15688,

        VPSUBUSBZ256rmkz = 15689,

        VPSUBUSBZ256rr = 15690,

        VPSUBUSBZ256rrk = 15691,

        VPSUBUSBZ256rrkz = 15692,

        VPSUBUSBZrm = 15693,

        VPSUBUSBZrmk = 15694,

        VPSUBUSBZrmkz = 15695,

        VPSUBUSBZrr = 15696,

        VPSUBUSBZrrk = 15697,

        VPSUBUSBZrrkz = 15698,

        VPSUBUSBrm = 15699,

        VPSUBUSBrr = 15700,

        VPSUBUSWYrm = 15701,

        VPSUBUSWYrr = 15702,

        VPSUBUSWZ128rm = 15703,

        VPSUBUSWZ128rmk = 15704,

        VPSUBUSWZ128rmkz = 15705,

        VPSUBUSWZ128rr = 15706,

        VPSUBUSWZ128rrk = 15707,

        VPSUBUSWZ128rrkz = 15708,

        VPSUBUSWZ256rm = 15709,

        VPSUBUSWZ256rmk = 15710,

        VPSUBUSWZ256rmkz = 15711,

        VPSUBUSWZ256rr = 15712,

        VPSUBUSWZ256rrk = 15713,

        VPSUBUSWZ256rrkz = 15714,

        VPSUBUSWZrm = 15715,

        VPSUBUSWZrmk = 15716,

        VPSUBUSWZrmkz = 15717,

        VPSUBUSWZrr = 15718,

        VPSUBUSWZrrk = 15719,

        VPSUBUSWZrrkz = 15720,

        VPSUBUSWrm = 15721,

        VPSUBUSWrr = 15722,

        VPSUBWYrm = 15723,

        VPSUBWYrr = 15724,

        VPSUBWZ128rm = 15725,

        VPSUBWZ128rmk = 15726,

        VPSUBWZ128rmkz = 15727,

        VPSUBWZ128rr = 15728,

        VPSUBWZ128rrk = 15729,

        VPSUBWZ128rrkz = 15730,

        VPSUBWZ256rm = 15731,

        VPSUBWZ256rmk = 15732,

        VPSUBWZ256rmkz = 15733,

        VPSUBWZ256rr = 15734,

        VPSUBWZ256rrk = 15735,

        VPSUBWZ256rrkz = 15736,

        VPSUBWZrm = 15737,

        VPSUBWZrmk = 15738,

        VPSUBWZrmkz = 15739,

        VPSUBWZrr = 15740,

        VPSUBWZrrk = 15741,

        VPSUBWZrrkz = 15742,

        VPSUBWrm = 15743,

        VPSUBWrr = 15744,

        VPTERNLOGDZ128rmbi = 15745,

        VPTERNLOGDZ128rmbik = 15746,

        VPTERNLOGDZ128rmbikz = 15747,

        VPTERNLOGDZ128rmi = 15748,

        VPTERNLOGDZ128rmik = 15749,

        VPTERNLOGDZ128rmikz = 15750,

        VPTERNLOGDZ128rri = 15751,

        VPTERNLOGDZ128rrik = 15752,

        VPTERNLOGDZ128rrikz = 15753,

        VPTERNLOGDZ256rmbi = 15754,

        VPTERNLOGDZ256rmbik = 15755,

        VPTERNLOGDZ256rmbikz = 15756,

        VPTERNLOGDZ256rmi = 15757,

        VPTERNLOGDZ256rmik = 15758,

        VPTERNLOGDZ256rmikz = 15759,

        VPTERNLOGDZ256rri = 15760,

        VPTERNLOGDZ256rrik = 15761,

        VPTERNLOGDZ256rrikz = 15762,

        VPTERNLOGDZrmbi = 15763,

        VPTERNLOGDZrmbik = 15764,

        VPTERNLOGDZrmbikz = 15765,

        VPTERNLOGDZrmi = 15766,

        VPTERNLOGDZrmik = 15767,

        VPTERNLOGDZrmikz = 15768,

        VPTERNLOGDZrri = 15769,

        VPTERNLOGDZrrik = 15770,

        VPTERNLOGDZrrikz = 15771,

        VPTERNLOGQZ128rmbi = 15772,

        VPTERNLOGQZ128rmbik = 15773,

        VPTERNLOGQZ128rmbikz = 15774,

        VPTERNLOGQZ128rmi = 15775,

        VPTERNLOGQZ128rmik = 15776,

        VPTERNLOGQZ128rmikz = 15777,

        VPTERNLOGQZ128rri = 15778,

        VPTERNLOGQZ128rrik = 15779,

        VPTERNLOGQZ128rrikz = 15780,

        VPTERNLOGQZ256rmbi = 15781,

        VPTERNLOGQZ256rmbik = 15782,

        VPTERNLOGQZ256rmbikz = 15783,

        VPTERNLOGQZ256rmi = 15784,

        VPTERNLOGQZ256rmik = 15785,

        VPTERNLOGQZ256rmikz = 15786,

        VPTERNLOGQZ256rri = 15787,

        VPTERNLOGQZ256rrik = 15788,

        VPTERNLOGQZ256rrikz = 15789,

        VPTERNLOGQZrmbi = 15790,

        VPTERNLOGQZrmbik = 15791,

        VPTERNLOGQZrmbikz = 15792,

        VPTERNLOGQZrmi = 15793,

        VPTERNLOGQZrmik = 15794,

        VPTERNLOGQZrmikz = 15795,

        VPTERNLOGQZrri = 15796,

        VPTERNLOGQZrrik = 15797,

        VPTERNLOGQZrrikz = 15798,

        VPTESTMBZ128rm = 15799,

        VPTESTMBZ128rmk = 15800,

        VPTESTMBZ128rr = 15801,

        VPTESTMBZ128rrk = 15802,

        VPTESTMBZ256rm = 15803,

        VPTESTMBZ256rmk = 15804,

        VPTESTMBZ256rr = 15805,

        VPTESTMBZ256rrk = 15806,

        VPTESTMBZrm = 15807,

        VPTESTMBZrmk = 15808,

        VPTESTMBZrr = 15809,

        VPTESTMBZrrk = 15810,

        VPTESTMDZ128rm = 15811,

        VPTESTMDZ128rmb = 15812,

        VPTESTMDZ128rmbk = 15813,

        VPTESTMDZ128rmk = 15814,

        VPTESTMDZ128rr = 15815,

        VPTESTMDZ128rrk = 15816,

        VPTESTMDZ256rm = 15817,

        VPTESTMDZ256rmb = 15818,

        VPTESTMDZ256rmbk = 15819,

        VPTESTMDZ256rmk = 15820,

        VPTESTMDZ256rr = 15821,

        VPTESTMDZ256rrk = 15822,

        VPTESTMDZrm = 15823,

        VPTESTMDZrmb = 15824,

        VPTESTMDZrmbk = 15825,

        VPTESTMDZrmk = 15826,

        VPTESTMDZrr = 15827,

        VPTESTMDZrrk = 15828,

        VPTESTMQZ128rm = 15829,

        VPTESTMQZ128rmb = 15830,

        VPTESTMQZ128rmbk = 15831,

        VPTESTMQZ128rmk = 15832,

        VPTESTMQZ128rr = 15833,

        VPTESTMQZ128rrk = 15834,

        VPTESTMQZ256rm = 15835,

        VPTESTMQZ256rmb = 15836,

        VPTESTMQZ256rmbk = 15837,

        VPTESTMQZ256rmk = 15838,

        VPTESTMQZ256rr = 15839,

        VPTESTMQZ256rrk = 15840,

        VPTESTMQZrm = 15841,

        VPTESTMQZrmb = 15842,

        VPTESTMQZrmbk = 15843,

        VPTESTMQZrmk = 15844,

        VPTESTMQZrr = 15845,

        VPTESTMQZrrk = 15846,

        VPTESTMWZ128rm = 15847,

        VPTESTMWZ128rmk = 15848,

        VPTESTMWZ128rr = 15849,

        VPTESTMWZ128rrk = 15850,

        VPTESTMWZ256rm = 15851,

        VPTESTMWZ256rmk = 15852,

        VPTESTMWZ256rr = 15853,

        VPTESTMWZ256rrk = 15854,

        VPTESTMWZrm = 15855,

        VPTESTMWZrmk = 15856,

        VPTESTMWZrr = 15857,

        VPTESTMWZrrk = 15858,

        VPTESTNMBZ128rm = 15859,

        VPTESTNMBZ128rmk = 15860,

        VPTESTNMBZ128rr = 15861,

        VPTESTNMBZ128rrk = 15862,

        VPTESTNMBZ256rm = 15863,

        VPTESTNMBZ256rmk = 15864,

        VPTESTNMBZ256rr = 15865,

        VPTESTNMBZ256rrk = 15866,

        VPTESTNMBZrm = 15867,

        VPTESTNMBZrmk = 15868,

        VPTESTNMBZrr = 15869,

        VPTESTNMBZrrk = 15870,

        VPTESTNMDZ128rm = 15871,

        VPTESTNMDZ128rmb = 15872,

        VPTESTNMDZ128rmbk = 15873,

        VPTESTNMDZ128rmk = 15874,

        VPTESTNMDZ128rr = 15875,

        VPTESTNMDZ128rrk = 15876,

        VPTESTNMDZ256rm = 15877,

        VPTESTNMDZ256rmb = 15878,

        VPTESTNMDZ256rmbk = 15879,

        VPTESTNMDZ256rmk = 15880,

        VPTESTNMDZ256rr = 15881,

        VPTESTNMDZ256rrk = 15882,

        VPTESTNMDZrm = 15883,

        VPTESTNMDZrmb = 15884,

        VPTESTNMDZrmbk = 15885,

        VPTESTNMDZrmk = 15886,

        VPTESTNMDZrr = 15887,

        VPTESTNMDZrrk = 15888,

        VPTESTNMQZ128rm = 15889,

        VPTESTNMQZ128rmb = 15890,

        VPTESTNMQZ128rmbk = 15891,

        VPTESTNMQZ128rmk = 15892,

        VPTESTNMQZ128rr = 15893,

        VPTESTNMQZ128rrk = 15894,

        VPTESTNMQZ256rm = 15895,

        VPTESTNMQZ256rmb = 15896,

        VPTESTNMQZ256rmbk = 15897,

        VPTESTNMQZ256rmk = 15898,

        VPTESTNMQZ256rr = 15899,

        VPTESTNMQZ256rrk = 15900,

        VPTESTNMQZrm = 15901,

        VPTESTNMQZrmb = 15902,

        VPTESTNMQZrmbk = 15903,

        VPTESTNMQZrmk = 15904,

        VPTESTNMQZrr = 15905,

        VPTESTNMQZrrk = 15906,

        VPTESTNMWZ128rm = 15907,

        VPTESTNMWZ128rmk = 15908,

        VPTESTNMWZ128rr = 15909,

        VPTESTNMWZ128rrk = 15910,

        VPTESTNMWZ256rm = 15911,

        VPTESTNMWZ256rmk = 15912,

        VPTESTNMWZ256rr = 15913,

        VPTESTNMWZ256rrk = 15914,

        VPTESTNMWZrm = 15915,

        VPTESTNMWZrmk = 15916,

        VPTESTNMWZrr = 15917,

        VPTESTNMWZrrk = 15918,

        VPTESTYrm = 15919,

        VPTESTYrr = 15920,

        VPTESTrm = 15921,

        VPTESTrr = 15922,

        VPUNPCKHBWYrm = 15923,

        VPUNPCKHBWYrr = 15924,

        VPUNPCKHBWZ128rm = 15925,

        VPUNPCKHBWZ128rmk = 15926,

        VPUNPCKHBWZ128rmkz = 15927,

        VPUNPCKHBWZ128rr = 15928,

        VPUNPCKHBWZ128rrk = 15929,

        VPUNPCKHBWZ128rrkz = 15930,

        VPUNPCKHBWZ256rm = 15931,

        VPUNPCKHBWZ256rmk = 15932,

        VPUNPCKHBWZ256rmkz = 15933,

        VPUNPCKHBWZ256rr = 15934,

        VPUNPCKHBWZ256rrk = 15935,

        VPUNPCKHBWZ256rrkz = 15936,

        VPUNPCKHBWZrm = 15937,

        VPUNPCKHBWZrmk = 15938,

        VPUNPCKHBWZrmkz = 15939,

        VPUNPCKHBWZrr = 15940,

        VPUNPCKHBWZrrk = 15941,

        VPUNPCKHBWZrrkz = 15942,

        VPUNPCKHBWrm = 15943,

        VPUNPCKHBWrr = 15944,

        VPUNPCKHDQYrm = 15945,

        VPUNPCKHDQYrr = 15946,

        VPUNPCKHDQZ128rm = 15947,

        VPUNPCKHDQZ128rmb = 15948,

        VPUNPCKHDQZ128rmbk = 15949,

        VPUNPCKHDQZ128rmbkz = 15950,

        VPUNPCKHDQZ128rmk = 15951,

        VPUNPCKHDQZ128rmkz = 15952,

        VPUNPCKHDQZ128rr = 15953,

        VPUNPCKHDQZ128rrk = 15954,

        VPUNPCKHDQZ128rrkz = 15955,

        VPUNPCKHDQZ256rm = 15956,

        VPUNPCKHDQZ256rmb = 15957,

        VPUNPCKHDQZ256rmbk = 15958,

        VPUNPCKHDQZ256rmbkz = 15959,

        VPUNPCKHDQZ256rmk = 15960,

        VPUNPCKHDQZ256rmkz = 15961,

        VPUNPCKHDQZ256rr = 15962,

        VPUNPCKHDQZ256rrk = 15963,

        VPUNPCKHDQZ256rrkz = 15964,

        VPUNPCKHDQZrm = 15965,

        VPUNPCKHDQZrmb = 15966,

        VPUNPCKHDQZrmbk = 15967,

        VPUNPCKHDQZrmbkz = 15968,

        VPUNPCKHDQZrmk = 15969,

        VPUNPCKHDQZrmkz = 15970,

        VPUNPCKHDQZrr = 15971,

        VPUNPCKHDQZrrk = 15972,

        VPUNPCKHDQZrrkz = 15973,

        VPUNPCKHDQrm = 15974,

        VPUNPCKHDQrr = 15975,

        VPUNPCKHQDQYrm = 15976,

        VPUNPCKHQDQYrr = 15977,

        VPUNPCKHQDQZ128rm = 15978,

        VPUNPCKHQDQZ128rmb = 15979,

        VPUNPCKHQDQZ128rmbk = 15980,

        VPUNPCKHQDQZ128rmbkz = 15981,

        VPUNPCKHQDQZ128rmk = 15982,

        VPUNPCKHQDQZ128rmkz = 15983,

        VPUNPCKHQDQZ128rr = 15984,

        VPUNPCKHQDQZ128rrk = 15985,

        VPUNPCKHQDQZ128rrkz = 15986,

        VPUNPCKHQDQZ256rm = 15987,

        VPUNPCKHQDQZ256rmb = 15988,

        VPUNPCKHQDQZ256rmbk = 15989,

        VPUNPCKHQDQZ256rmbkz = 15990,

        VPUNPCKHQDQZ256rmk = 15991,

        VPUNPCKHQDQZ256rmkz = 15992,

        VPUNPCKHQDQZ256rr = 15993,

        VPUNPCKHQDQZ256rrk = 15994,

        VPUNPCKHQDQZ256rrkz = 15995,

        VPUNPCKHQDQZrm = 15996,

        VPUNPCKHQDQZrmb = 15997,

        VPUNPCKHQDQZrmbk = 15998,

        VPUNPCKHQDQZrmbkz = 15999,

        VPUNPCKHQDQZrmk = 16000,

        VPUNPCKHQDQZrmkz = 16001,

        VPUNPCKHQDQZrr = 16002,

        VPUNPCKHQDQZrrk = 16003,

        VPUNPCKHQDQZrrkz = 16004,

        VPUNPCKHQDQrm = 16005,

        VPUNPCKHQDQrr = 16006,

        VPUNPCKHWDYrm = 16007,

        VPUNPCKHWDYrr = 16008,

        VPUNPCKHWDZ128rm = 16009,

        VPUNPCKHWDZ128rmk = 16010,

        VPUNPCKHWDZ128rmkz = 16011,

        VPUNPCKHWDZ128rr = 16012,

        VPUNPCKHWDZ128rrk = 16013,

        VPUNPCKHWDZ128rrkz = 16014,

        VPUNPCKHWDZ256rm = 16015,

        VPUNPCKHWDZ256rmk = 16016,

        VPUNPCKHWDZ256rmkz = 16017,

        VPUNPCKHWDZ256rr = 16018,

        VPUNPCKHWDZ256rrk = 16019,

        VPUNPCKHWDZ256rrkz = 16020,

        VPUNPCKHWDZrm = 16021,

        VPUNPCKHWDZrmk = 16022,

        VPUNPCKHWDZrmkz = 16023,

        VPUNPCKHWDZrr = 16024,

        VPUNPCKHWDZrrk = 16025,

        VPUNPCKHWDZrrkz = 16026,

        VPUNPCKHWDrm = 16027,

        VPUNPCKHWDrr = 16028,

        VPUNPCKLBWYrm = 16029,

        VPUNPCKLBWYrr = 16030,

        VPUNPCKLBWZ128rm = 16031,

        VPUNPCKLBWZ128rmk = 16032,

        VPUNPCKLBWZ128rmkz = 16033,

        VPUNPCKLBWZ128rr = 16034,

        VPUNPCKLBWZ128rrk = 16035,

        VPUNPCKLBWZ128rrkz = 16036,

        VPUNPCKLBWZ256rm = 16037,

        VPUNPCKLBWZ256rmk = 16038,

        VPUNPCKLBWZ256rmkz = 16039,

        VPUNPCKLBWZ256rr = 16040,

        VPUNPCKLBWZ256rrk = 16041,

        VPUNPCKLBWZ256rrkz = 16042,

        VPUNPCKLBWZrm = 16043,

        VPUNPCKLBWZrmk = 16044,

        VPUNPCKLBWZrmkz = 16045,

        VPUNPCKLBWZrr = 16046,

        VPUNPCKLBWZrrk = 16047,

        VPUNPCKLBWZrrkz = 16048,

        VPUNPCKLBWrm = 16049,

        VPUNPCKLBWrr = 16050,

        VPUNPCKLDQYrm = 16051,

        VPUNPCKLDQYrr = 16052,

        VPUNPCKLDQZ128rm = 16053,

        VPUNPCKLDQZ128rmb = 16054,

        VPUNPCKLDQZ128rmbk = 16055,

        VPUNPCKLDQZ128rmbkz = 16056,

        VPUNPCKLDQZ128rmk = 16057,

        VPUNPCKLDQZ128rmkz = 16058,

        VPUNPCKLDQZ128rr = 16059,

        VPUNPCKLDQZ128rrk = 16060,

        VPUNPCKLDQZ128rrkz = 16061,

        VPUNPCKLDQZ256rm = 16062,

        VPUNPCKLDQZ256rmb = 16063,

        VPUNPCKLDQZ256rmbk = 16064,

        VPUNPCKLDQZ256rmbkz = 16065,

        VPUNPCKLDQZ256rmk = 16066,

        VPUNPCKLDQZ256rmkz = 16067,

        VPUNPCKLDQZ256rr = 16068,

        VPUNPCKLDQZ256rrk = 16069,

        VPUNPCKLDQZ256rrkz = 16070,

        VPUNPCKLDQZrm = 16071,

        VPUNPCKLDQZrmb = 16072,

        VPUNPCKLDQZrmbk = 16073,

        VPUNPCKLDQZrmbkz = 16074,

        VPUNPCKLDQZrmk = 16075,

        VPUNPCKLDQZrmkz = 16076,

        VPUNPCKLDQZrr = 16077,

        VPUNPCKLDQZrrk = 16078,

        VPUNPCKLDQZrrkz = 16079,

        VPUNPCKLDQrm = 16080,

        VPUNPCKLDQrr = 16081,

        VPUNPCKLQDQYrm = 16082,

        VPUNPCKLQDQYrr = 16083,

        VPUNPCKLQDQZ128rm = 16084,

        VPUNPCKLQDQZ128rmb = 16085,

        VPUNPCKLQDQZ128rmbk = 16086,

        VPUNPCKLQDQZ128rmbkz = 16087,

        VPUNPCKLQDQZ128rmk = 16088,

        VPUNPCKLQDQZ128rmkz = 16089,

        VPUNPCKLQDQZ128rr = 16090,

        VPUNPCKLQDQZ128rrk = 16091,

        VPUNPCKLQDQZ128rrkz = 16092,

        VPUNPCKLQDQZ256rm = 16093,

        VPUNPCKLQDQZ256rmb = 16094,

        VPUNPCKLQDQZ256rmbk = 16095,

        VPUNPCKLQDQZ256rmbkz = 16096,

        VPUNPCKLQDQZ256rmk = 16097,

        VPUNPCKLQDQZ256rmkz = 16098,

        VPUNPCKLQDQZ256rr = 16099,

        VPUNPCKLQDQZ256rrk = 16100,

        VPUNPCKLQDQZ256rrkz = 16101,

        VPUNPCKLQDQZrm = 16102,

        VPUNPCKLQDQZrmb = 16103,

        VPUNPCKLQDQZrmbk = 16104,

        VPUNPCKLQDQZrmbkz = 16105,

        VPUNPCKLQDQZrmk = 16106,

        VPUNPCKLQDQZrmkz = 16107,

        VPUNPCKLQDQZrr = 16108,

        VPUNPCKLQDQZrrk = 16109,

        VPUNPCKLQDQZrrkz = 16110,

        VPUNPCKLQDQrm = 16111,

        VPUNPCKLQDQrr = 16112,

        VPUNPCKLWDYrm = 16113,

        VPUNPCKLWDYrr = 16114,

        VPUNPCKLWDZ128rm = 16115,

        VPUNPCKLWDZ128rmk = 16116,

        VPUNPCKLWDZ128rmkz = 16117,

        VPUNPCKLWDZ128rr = 16118,

        VPUNPCKLWDZ128rrk = 16119,

        VPUNPCKLWDZ128rrkz = 16120,

        VPUNPCKLWDZ256rm = 16121,

        VPUNPCKLWDZ256rmk = 16122,

        VPUNPCKLWDZ256rmkz = 16123,

        VPUNPCKLWDZ256rr = 16124,

        VPUNPCKLWDZ256rrk = 16125,

        VPUNPCKLWDZ256rrkz = 16126,

        VPUNPCKLWDZrm = 16127,

        VPUNPCKLWDZrmk = 16128,

        VPUNPCKLWDZrmkz = 16129,

        VPUNPCKLWDZrr = 16130,

        VPUNPCKLWDZrrk = 16131,

        VPUNPCKLWDZrrkz = 16132,

        VPUNPCKLWDrm = 16133,

        VPUNPCKLWDrr = 16134,

        VPXORDZ128rm = 16135,

        VPXORDZ128rmb = 16136,

        VPXORDZ128rmbk = 16137,

        VPXORDZ128rmbkz = 16138,

        VPXORDZ128rmk = 16139,

        VPXORDZ128rmkz = 16140,

        VPXORDZ128rr = 16141,

        VPXORDZ128rrk = 16142,

        VPXORDZ128rrkz = 16143,

        VPXORDZ256rm = 16144,

        VPXORDZ256rmb = 16145,

        VPXORDZ256rmbk = 16146,

        VPXORDZ256rmbkz = 16147,

        VPXORDZ256rmk = 16148,

        VPXORDZ256rmkz = 16149,

        VPXORDZ256rr = 16150,

        VPXORDZ256rrk = 16151,

        VPXORDZ256rrkz = 16152,

        VPXORDZrm = 16153,

        VPXORDZrmb = 16154,

        VPXORDZrmbk = 16155,

        VPXORDZrmbkz = 16156,

        VPXORDZrmk = 16157,

        VPXORDZrmkz = 16158,

        VPXORDZrr = 16159,

        VPXORDZrrk = 16160,

        VPXORDZrrkz = 16161,

        VPXORQZ128rm = 16162,

        VPXORQZ128rmb = 16163,

        VPXORQZ128rmbk = 16164,

        VPXORQZ128rmbkz = 16165,

        VPXORQZ128rmk = 16166,

        VPXORQZ128rmkz = 16167,

        VPXORQZ128rr = 16168,

        VPXORQZ128rrk = 16169,

        VPXORQZ128rrkz = 16170,

        VPXORQZ256rm = 16171,

        VPXORQZ256rmb = 16172,

        VPXORQZ256rmbk = 16173,

        VPXORQZ256rmbkz = 16174,

        VPXORQZ256rmk = 16175,

        VPXORQZ256rmkz = 16176,

        VPXORQZ256rr = 16177,

        VPXORQZ256rrk = 16178,

        VPXORQZ256rrkz = 16179,

        VPXORQZrm = 16180,

        VPXORQZrmb = 16181,

        VPXORQZrmbk = 16182,

        VPXORQZrmbkz = 16183,

        VPXORQZrmk = 16184,

        VPXORQZrmkz = 16185,

        VPXORQZrr = 16186,

        VPXORQZrrk = 16187,

        VPXORQZrrkz = 16188,

        VPXORYrm = 16189,

        VPXORYrr = 16190,

        VPXORrm = 16191,

        VPXORrr = 16192,

        VRANGEPDZ128rmbi = 16193,

        VRANGEPDZ128rmbik = 16194,

        VRANGEPDZ128rmbikz = 16195,

        VRANGEPDZ128rmi = 16196,

        VRANGEPDZ128rmik = 16197,

        VRANGEPDZ128rmikz = 16198,

        VRANGEPDZ128rri = 16199,

        VRANGEPDZ128rrik = 16200,

        VRANGEPDZ128rrikz = 16201,

        VRANGEPDZ256rmbi = 16202,

        VRANGEPDZ256rmbik = 16203,

        VRANGEPDZ256rmbikz = 16204,

        VRANGEPDZ256rmi = 16205,

        VRANGEPDZ256rmik = 16206,

        VRANGEPDZ256rmikz = 16207,

        VRANGEPDZ256rri = 16208,

        VRANGEPDZ256rrik = 16209,

        VRANGEPDZ256rrikz = 16210,

        VRANGEPDZrmbi = 16211,

        VRANGEPDZrmbik = 16212,

        VRANGEPDZrmbikz = 16213,

        VRANGEPDZrmi = 16214,

        VRANGEPDZrmik = 16215,

        VRANGEPDZrmikz = 16216,

        VRANGEPDZrri = 16217,

        VRANGEPDZrrib = 16218,

        VRANGEPDZrribk = 16219,

        VRANGEPDZrribkz = 16220,

        VRANGEPDZrrik = 16221,

        VRANGEPDZrrikz = 16222,

        VRANGEPSZ128rmbi = 16223,

        VRANGEPSZ128rmbik = 16224,

        VRANGEPSZ128rmbikz = 16225,

        VRANGEPSZ128rmi = 16226,

        VRANGEPSZ128rmik = 16227,

        VRANGEPSZ128rmikz = 16228,

        VRANGEPSZ128rri = 16229,

        VRANGEPSZ128rrik = 16230,

        VRANGEPSZ128rrikz = 16231,

        VRANGEPSZ256rmbi = 16232,

        VRANGEPSZ256rmbik = 16233,

        VRANGEPSZ256rmbikz = 16234,

        VRANGEPSZ256rmi = 16235,

        VRANGEPSZ256rmik = 16236,

        VRANGEPSZ256rmikz = 16237,

        VRANGEPSZ256rri = 16238,

        VRANGEPSZ256rrik = 16239,

        VRANGEPSZ256rrikz = 16240,

        VRANGEPSZrmbi = 16241,

        VRANGEPSZrmbik = 16242,

        VRANGEPSZrmbikz = 16243,

        VRANGEPSZrmi = 16244,

        VRANGEPSZrmik = 16245,

        VRANGEPSZrmikz = 16246,

        VRANGEPSZrri = 16247,

        VRANGEPSZrrib = 16248,

        VRANGEPSZrribk = 16249,

        VRANGEPSZrribkz = 16250,

        VRANGEPSZrrik = 16251,

        VRANGEPSZrrikz = 16252,

        VRANGESDZrmi = 16253,

        VRANGESDZrmik = 16254,

        VRANGESDZrmikz = 16255,

        VRANGESDZrri = 16256,

        VRANGESDZrrib = 16257,

        VRANGESDZrribk = 16258,

        VRANGESDZrribkz = 16259,

        VRANGESDZrrik = 16260,

        VRANGESDZrrikz = 16261,

        VRANGESSZrmi = 16262,

        VRANGESSZrmik = 16263,

        VRANGESSZrmikz = 16264,

        VRANGESSZrri = 16265,

        VRANGESSZrrib = 16266,

        VRANGESSZrribk = 16267,

        VRANGESSZrribkz = 16268,

        VRANGESSZrrik = 16269,

        VRANGESSZrrikz = 16270,

        VRCP14PDZ128m = 16271,

        VRCP14PDZ128mb = 16272,

        VRCP14PDZ128mbk = 16273,

        VRCP14PDZ128mbkz = 16274,

        VRCP14PDZ128mk = 16275,

        VRCP14PDZ128mkz = 16276,

        VRCP14PDZ128r = 16277,

        VRCP14PDZ128rk = 16278,

        VRCP14PDZ128rkz = 16279,

        VRCP14PDZ256m = 16280,

        VRCP14PDZ256mb = 16281,

        VRCP14PDZ256mbk = 16282,

        VRCP14PDZ256mbkz = 16283,

        VRCP14PDZ256mk = 16284,

        VRCP14PDZ256mkz = 16285,

        VRCP14PDZ256r = 16286,

        VRCP14PDZ256rk = 16287,

        VRCP14PDZ256rkz = 16288,

        VRCP14PDZm = 16289,

        VRCP14PDZmb = 16290,

        VRCP14PDZmbk = 16291,

        VRCP14PDZmbkz = 16292,

        VRCP14PDZmk = 16293,

        VRCP14PDZmkz = 16294,

        VRCP14PDZr = 16295,

        VRCP14PDZrk = 16296,

        VRCP14PDZrkz = 16297,

        VRCP14PSZ128m = 16298,

        VRCP14PSZ128mb = 16299,

        VRCP14PSZ128mbk = 16300,

        VRCP14PSZ128mbkz = 16301,

        VRCP14PSZ128mk = 16302,

        VRCP14PSZ128mkz = 16303,

        VRCP14PSZ128r = 16304,

        VRCP14PSZ128rk = 16305,

        VRCP14PSZ128rkz = 16306,

        VRCP14PSZ256m = 16307,

        VRCP14PSZ256mb = 16308,

        VRCP14PSZ256mbk = 16309,

        VRCP14PSZ256mbkz = 16310,

        VRCP14PSZ256mk = 16311,

        VRCP14PSZ256mkz = 16312,

        VRCP14PSZ256r = 16313,

        VRCP14PSZ256rk = 16314,

        VRCP14PSZ256rkz = 16315,

        VRCP14PSZm = 16316,

        VRCP14PSZmb = 16317,

        VRCP14PSZmbk = 16318,

        VRCP14PSZmbkz = 16319,

        VRCP14PSZmk = 16320,

        VRCP14PSZmkz = 16321,

        VRCP14PSZr = 16322,

        VRCP14PSZrk = 16323,

        VRCP14PSZrkz = 16324,

        VRCP14SDZrm = 16325,

        VRCP14SDZrmk = 16326,

        VRCP14SDZrmkz = 16327,

        VRCP14SDZrr = 16328,

        VRCP14SDZrrk = 16329,

        VRCP14SDZrrkz = 16330,

        VRCP14SSZrm = 16331,

        VRCP14SSZrmk = 16332,

        VRCP14SSZrmkz = 16333,

        VRCP14SSZrr = 16334,

        VRCP14SSZrrk = 16335,

        VRCP14SSZrrkz = 16336,

        VRCP28PDZm = 16337,

        VRCP28PDZmb = 16338,

        VRCP28PDZmbk = 16339,

        VRCP28PDZmbkz = 16340,

        VRCP28PDZmk = 16341,

        VRCP28PDZmkz = 16342,

        VRCP28PDZr = 16343,

        VRCP28PDZrb = 16344,

        VRCP28PDZrbk = 16345,

        VRCP28PDZrbkz = 16346,

        VRCP28PDZrk = 16347,

        VRCP28PDZrkz = 16348,

        VRCP28PSZm = 16349,

        VRCP28PSZmb = 16350,

        VRCP28PSZmbk = 16351,

        VRCP28PSZmbkz = 16352,

        VRCP28PSZmk = 16353,

        VRCP28PSZmkz = 16354,

        VRCP28PSZr = 16355,

        VRCP28PSZrb = 16356,

        VRCP28PSZrbk = 16357,

        VRCP28PSZrbkz = 16358,

        VRCP28PSZrk = 16359,

        VRCP28PSZrkz = 16360,

        VRCP28SDZm = 16361,

        VRCP28SDZmk = 16362,

        VRCP28SDZmkz = 16363,

        VRCP28SDZr = 16364,

        VRCP28SDZrb = 16365,

        VRCP28SDZrbk = 16366,

        VRCP28SDZrbkz = 16367,

        VRCP28SDZrk = 16368,

        VRCP28SDZrkz = 16369,

        VRCP28SSZm = 16370,

        VRCP28SSZmk = 16371,

        VRCP28SSZmkz = 16372,

        VRCP28SSZr = 16373,

        VRCP28SSZrb = 16374,

        VRCP28SSZrbk = 16375,

        VRCP28SSZrbkz = 16376,

        VRCP28SSZrk = 16377,

        VRCP28SSZrkz = 16378,

        VRCPPHZ128m = 16379,

        VRCPPHZ128mb = 16380,

        VRCPPHZ128mbk = 16381,

        VRCPPHZ128mbkz = 16382,

        VRCPPHZ128mk = 16383,

        VRCPPHZ128mkz = 16384,

        VRCPPHZ128r = 16385,

        VRCPPHZ128rk = 16386,

        VRCPPHZ128rkz = 16387,

        VRCPPHZ256m = 16388,

        VRCPPHZ256mb = 16389,

        VRCPPHZ256mbk = 16390,

        VRCPPHZ256mbkz = 16391,

        VRCPPHZ256mk = 16392,

        VRCPPHZ256mkz = 16393,

        VRCPPHZ256r = 16394,

        VRCPPHZ256rk = 16395,

        VRCPPHZ256rkz = 16396,

        VRCPPHZm = 16397,

        VRCPPHZmb = 16398,

        VRCPPHZmbk = 16399,

        VRCPPHZmbkz = 16400,

        VRCPPHZmk = 16401,

        VRCPPHZmkz = 16402,

        VRCPPHZr = 16403,

        VRCPPHZrk = 16404,

        VRCPPHZrkz = 16405,

        VRCPPSYm = 16406,

        VRCPPSYr = 16407,

        VRCPPSm = 16408,

        VRCPPSr = 16409,

        VRCPSHZrm = 16410,

        VRCPSHZrmk = 16411,

        VRCPSHZrmkz = 16412,

        VRCPSHZrr = 16413,

        VRCPSHZrrk = 16414,

        VRCPSHZrrkz = 16415,

        VRCPSSm = 16416,

        VRCPSSm_Int = 16417,

        VRCPSSr = 16418,

        VRCPSSr_Int = 16419,

        VREDUCEPDZ128rmbi = 16420,

        VREDUCEPDZ128rmbik = 16421,

        VREDUCEPDZ128rmbikz = 16422,

        VREDUCEPDZ128rmi = 16423,

        VREDUCEPDZ128rmik = 16424,

        VREDUCEPDZ128rmikz = 16425,

        VREDUCEPDZ128rri = 16426,

        VREDUCEPDZ128rrik = 16427,

        VREDUCEPDZ128rrikz = 16428,

        VREDUCEPDZ256rmbi = 16429,

        VREDUCEPDZ256rmbik = 16430,

        VREDUCEPDZ256rmbikz = 16431,

        VREDUCEPDZ256rmi = 16432,

        VREDUCEPDZ256rmik = 16433,

        VREDUCEPDZ256rmikz = 16434,

        VREDUCEPDZ256rri = 16435,

        VREDUCEPDZ256rrik = 16436,

        VREDUCEPDZ256rrikz = 16437,

        VREDUCEPDZrmbi = 16438,

        VREDUCEPDZrmbik = 16439,

        VREDUCEPDZrmbikz = 16440,

        VREDUCEPDZrmi = 16441,

        VREDUCEPDZrmik = 16442,

        VREDUCEPDZrmikz = 16443,

        VREDUCEPDZrri = 16444,

        VREDUCEPDZrrib = 16445,

        VREDUCEPDZrribk = 16446,

        VREDUCEPDZrribkz = 16447,

        VREDUCEPDZrrik = 16448,

        VREDUCEPDZrrikz = 16449,

        VREDUCEPHZ128rmbi = 16450,

        VREDUCEPHZ128rmbik = 16451,

        VREDUCEPHZ128rmbikz = 16452,

        VREDUCEPHZ128rmi = 16453,

        VREDUCEPHZ128rmik = 16454,

        VREDUCEPHZ128rmikz = 16455,

        VREDUCEPHZ128rri = 16456,

        VREDUCEPHZ128rrik = 16457,

        VREDUCEPHZ128rrikz = 16458,

        VREDUCEPHZ256rmbi = 16459,

        VREDUCEPHZ256rmbik = 16460,

        VREDUCEPHZ256rmbikz = 16461,

        VREDUCEPHZ256rmi = 16462,

        VREDUCEPHZ256rmik = 16463,

        VREDUCEPHZ256rmikz = 16464,

        VREDUCEPHZ256rri = 16465,

        VREDUCEPHZ256rrik = 16466,

        VREDUCEPHZ256rrikz = 16467,

        VREDUCEPHZrmbi = 16468,

        VREDUCEPHZrmbik = 16469,

        VREDUCEPHZrmbikz = 16470,

        VREDUCEPHZrmi = 16471,

        VREDUCEPHZrmik = 16472,

        VREDUCEPHZrmikz = 16473,

        VREDUCEPHZrri = 16474,

        VREDUCEPHZrrib = 16475,

        VREDUCEPHZrribk = 16476,

        VREDUCEPHZrribkz = 16477,

        VREDUCEPHZrrik = 16478,

        VREDUCEPHZrrikz = 16479,

        VREDUCEPSZ128rmbi = 16480,

        VREDUCEPSZ128rmbik = 16481,

        VREDUCEPSZ128rmbikz = 16482,

        VREDUCEPSZ128rmi = 16483,

        VREDUCEPSZ128rmik = 16484,

        VREDUCEPSZ128rmikz = 16485,

        VREDUCEPSZ128rri = 16486,

        VREDUCEPSZ128rrik = 16487,

        VREDUCEPSZ128rrikz = 16488,

        VREDUCEPSZ256rmbi = 16489,

        VREDUCEPSZ256rmbik = 16490,

        VREDUCEPSZ256rmbikz = 16491,

        VREDUCEPSZ256rmi = 16492,

        VREDUCEPSZ256rmik = 16493,

        VREDUCEPSZ256rmikz = 16494,

        VREDUCEPSZ256rri = 16495,

        VREDUCEPSZ256rrik = 16496,

        VREDUCEPSZ256rrikz = 16497,

        VREDUCEPSZrmbi = 16498,

        VREDUCEPSZrmbik = 16499,

        VREDUCEPSZrmbikz = 16500,

        VREDUCEPSZrmi = 16501,

        VREDUCEPSZrmik = 16502,

        VREDUCEPSZrmikz = 16503,

        VREDUCEPSZrri = 16504,

        VREDUCEPSZrrib = 16505,

        VREDUCEPSZrribk = 16506,

        VREDUCEPSZrribkz = 16507,

        VREDUCEPSZrrik = 16508,

        VREDUCEPSZrrikz = 16509,

        VREDUCESDZrmi = 16510,

        VREDUCESDZrmik = 16511,

        VREDUCESDZrmikz = 16512,

        VREDUCESDZrri = 16513,

        VREDUCESDZrrib = 16514,

        VREDUCESDZrribk = 16515,

        VREDUCESDZrribkz = 16516,

        VREDUCESDZrrik = 16517,

        VREDUCESDZrrikz = 16518,

        VREDUCESHZrmi = 16519,

        VREDUCESHZrmik = 16520,

        VREDUCESHZrmikz = 16521,

        VREDUCESHZrri = 16522,

        VREDUCESHZrrib = 16523,

        VREDUCESHZrribk = 16524,

        VREDUCESHZrribkz = 16525,

        VREDUCESHZrrik = 16526,

        VREDUCESHZrrikz = 16527,

        VREDUCESSZrmi = 16528,

        VREDUCESSZrmik = 16529,

        VREDUCESSZrmikz = 16530,

        VREDUCESSZrri = 16531,

        VREDUCESSZrrib = 16532,

        VREDUCESSZrribk = 16533,

        VREDUCESSZrribkz = 16534,

        VREDUCESSZrrik = 16535,

        VREDUCESSZrrikz = 16536,

        VRNDSCALEPDZ128rmbi = 16537,

        VRNDSCALEPDZ128rmbik = 16538,

        VRNDSCALEPDZ128rmbikz = 16539,

        VRNDSCALEPDZ128rmi = 16540,

        VRNDSCALEPDZ128rmik = 16541,

        VRNDSCALEPDZ128rmikz = 16542,

        VRNDSCALEPDZ128rri = 16543,

        VRNDSCALEPDZ128rrik = 16544,

        VRNDSCALEPDZ128rrikz = 16545,

        VRNDSCALEPDZ256rmbi = 16546,

        VRNDSCALEPDZ256rmbik = 16547,

        VRNDSCALEPDZ256rmbikz = 16548,

        VRNDSCALEPDZ256rmi = 16549,

        VRNDSCALEPDZ256rmik = 16550,

        VRNDSCALEPDZ256rmikz = 16551,

        VRNDSCALEPDZ256rri = 16552,

        VRNDSCALEPDZ256rrik = 16553,

        VRNDSCALEPDZ256rrikz = 16554,

        VRNDSCALEPDZrmbi = 16555,

        VRNDSCALEPDZrmbik = 16556,

        VRNDSCALEPDZrmbikz = 16557,

        VRNDSCALEPDZrmi = 16558,

        VRNDSCALEPDZrmik = 16559,

        VRNDSCALEPDZrmikz = 16560,

        VRNDSCALEPDZrri = 16561,

        VRNDSCALEPDZrrib = 16562,

        VRNDSCALEPDZrribk = 16563,

        VRNDSCALEPDZrribkz = 16564,

        VRNDSCALEPDZrrik = 16565,

        VRNDSCALEPDZrrikz = 16566,

        VRNDSCALEPHZ128rmbi = 16567,

        VRNDSCALEPHZ128rmbik = 16568,

        VRNDSCALEPHZ128rmbikz = 16569,

        VRNDSCALEPHZ128rmi = 16570,

        VRNDSCALEPHZ128rmik = 16571,

        VRNDSCALEPHZ128rmikz = 16572,

        VRNDSCALEPHZ128rri = 16573,

        VRNDSCALEPHZ128rrik = 16574,

        VRNDSCALEPHZ128rrikz = 16575,

        VRNDSCALEPHZ256rmbi = 16576,

        VRNDSCALEPHZ256rmbik = 16577,

        VRNDSCALEPHZ256rmbikz = 16578,

        VRNDSCALEPHZ256rmi = 16579,

        VRNDSCALEPHZ256rmik = 16580,

        VRNDSCALEPHZ256rmikz = 16581,

        VRNDSCALEPHZ256rri = 16582,

        VRNDSCALEPHZ256rrik = 16583,

        VRNDSCALEPHZ256rrikz = 16584,

        VRNDSCALEPHZrmbi = 16585,

        VRNDSCALEPHZrmbik = 16586,

        VRNDSCALEPHZrmbikz = 16587,

        VRNDSCALEPHZrmi = 16588,

        VRNDSCALEPHZrmik = 16589,

        VRNDSCALEPHZrmikz = 16590,

        VRNDSCALEPHZrri = 16591,

        VRNDSCALEPHZrrib = 16592,

        VRNDSCALEPHZrribk = 16593,

        VRNDSCALEPHZrribkz = 16594,

        VRNDSCALEPHZrrik = 16595,

        VRNDSCALEPHZrrikz = 16596,

        VRNDSCALEPSZ128rmbi = 16597,

        VRNDSCALEPSZ128rmbik = 16598,

        VRNDSCALEPSZ128rmbikz = 16599,

        VRNDSCALEPSZ128rmi = 16600,

        VRNDSCALEPSZ128rmik = 16601,

        VRNDSCALEPSZ128rmikz = 16602,

        VRNDSCALEPSZ128rri = 16603,

        VRNDSCALEPSZ128rrik = 16604,

        VRNDSCALEPSZ128rrikz = 16605,

        VRNDSCALEPSZ256rmbi = 16606,

        VRNDSCALEPSZ256rmbik = 16607,

        VRNDSCALEPSZ256rmbikz = 16608,

        VRNDSCALEPSZ256rmi = 16609,

        VRNDSCALEPSZ256rmik = 16610,

        VRNDSCALEPSZ256rmikz = 16611,

        VRNDSCALEPSZ256rri = 16612,

        VRNDSCALEPSZ256rrik = 16613,

        VRNDSCALEPSZ256rrikz = 16614,

        VRNDSCALEPSZrmbi = 16615,

        VRNDSCALEPSZrmbik = 16616,

        VRNDSCALEPSZrmbikz = 16617,

        VRNDSCALEPSZrmi = 16618,

        VRNDSCALEPSZrmik = 16619,

        VRNDSCALEPSZrmikz = 16620,

        VRNDSCALEPSZrri = 16621,

        VRNDSCALEPSZrrib = 16622,

        VRNDSCALEPSZrribk = 16623,

        VRNDSCALEPSZrribkz = 16624,

        VRNDSCALEPSZrrik = 16625,

        VRNDSCALEPSZrrikz = 16626,

        VRNDSCALESDZm = 16627,

        VRNDSCALESDZm_Int = 16628,

        VRNDSCALESDZm_Intk = 16629,

        VRNDSCALESDZm_Intkz = 16630,

        VRNDSCALESDZr = 16631,

        VRNDSCALESDZr_Int = 16632,

        VRNDSCALESDZr_Intk = 16633,

        VRNDSCALESDZr_Intkz = 16634,

        VRNDSCALESDZrb_Int = 16635,

        VRNDSCALESDZrb_Intk = 16636,

        VRNDSCALESDZrb_Intkz = 16637,

        VRNDSCALESHZm = 16638,

        VRNDSCALESHZm_Int = 16639,

        VRNDSCALESHZm_Intk = 16640,

        VRNDSCALESHZm_Intkz = 16641,

        VRNDSCALESHZr = 16642,

        VRNDSCALESHZr_Int = 16643,

        VRNDSCALESHZr_Intk = 16644,

        VRNDSCALESHZr_Intkz = 16645,

        VRNDSCALESHZrb_Int = 16646,

        VRNDSCALESHZrb_Intk = 16647,

        VRNDSCALESHZrb_Intkz = 16648,

        VRNDSCALESSZm = 16649,

        VRNDSCALESSZm_Int = 16650,

        VRNDSCALESSZm_Intk = 16651,

        VRNDSCALESSZm_Intkz = 16652,

        VRNDSCALESSZr = 16653,

        VRNDSCALESSZr_Int = 16654,

        VRNDSCALESSZr_Intk = 16655,

        VRNDSCALESSZr_Intkz = 16656,

        VRNDSCALESSZrb_Int = 16657,

        VRNDSCALESSZrb_Intk = 16658,

        VRNDSCALESSZrb_Intkz = 16659,

        VROUNDPDYm = 16660,

        VROUNDPDYr = 16661,

        VROUNDPDm = 16662,

        VROUNDPDr = 16663,

        VROUNDPSYm = 16664,

        VROUNDPSYr = 16665,

        VROUNDPSm = 16666,

        VROUNDPSr = 16667,

        VROUNDSDm = 16668,

        VROUNDSDm_Int = 16669,

        VROUNDSDr = 16670,

        VROUNDSDr_Int = 16671,

        VROUNDSSm = 16672,

        VROUNDSSm_Int = 16673,

        VROUNDSSr = 16674,

        VROUNDSSr_Int = 16675,

        VRSQRT14PDZ128m = 16676,

        VRSQRT14PDZ128mb = 16677,

        VRSQRT14PDZ128mbk = 16678,

        VRSQRT14PDZ128mbkz = 16679,

        VRSQRT14PDZ128mk = 16680,

        VRSQRT14PDZ128mkz = 16681,

        VRSQRT14PDZ128r = 16682,

        VRSQRT14PDZ128rk = 16683,

        VRSQRT14PDZ128rkz = 16684,

        VRSQRT14PDZ256m = 16685,

        VRSQRT14PDZ256mb = 16686,

        VRSQRT14PDZ256mbk = 16687,

        VRSQRT14PDZ256mbkz = 16688,

        VRSQRT14PDZ256mk = 16689,

        VRSQRT14PDZ256mkz = 16690,

        VRSQRT14PDZ256r = 16691,

        VRSQRT14PDZ256rk = 16692,

        VRSQRT14PDZ256rkz = 16693,

        VRSQRT14PDZm = 16694,

        VRSQRT14PDZmb = 16695,

        VRSQRT14PDZmbk = 16696,

        VRSQRT14PDZmbkz = 16697,

        VRSQRT14PDZmk = 16698,

        VRSQRT14PDZmkz = 16699,

        VRSQRT14PDZr = 16700,

        VRSQRT14PDZrk = 16701,

        VRSQRT14PDZrkz = 16702,

        VRSQRT14PSZ128m = 16703,

        VRSQRT14PSZ128mb = 16704,

        VRSQRT14PSZ128mbk = 16705,

        VRSQRT14PSZ128mbkz = 16706,

        VRSQRT14PSZ128mk = 16707,

        VRSQRT14PSZ128mkz = 16708,

        VRSQRT14PSZ128r = 16709,

        VRSQRT14PSZ128rk = 16710,

        VRSQRT14PSZ128rkz = 16711,

        VRSQRT14PSZ256m = 16712,

        VRSQRT14PSZ256mb = 16713,

        VRSQRT14PSZ256mbk = 16714,

        VRSQRT14PSZ256mbkz = 16715,

        VRSQRT14PSZ256mk = 16716,

        VRSQRT14PSZ256mkz = 16717,

        VRSQRT14PSZ256r = 16718,

        VRSQRT14PSZ256rk = 16719,

        VRSQRT14PSZ256rkz = 16720,

        VRSQRT14PSZm = 16721,

        VRSQRT14PSZmb = 16722,

        VRSQRT14PSZmbk = 16723,

        VRSQRT14PSZmbkz = 16724,

        VRSQRT14PSZmk = 16725,

        VRSQRT14PSZmkz = 16726,

        VRSQRT14PSZr = 16727,

        VRSQRT14PSZrk = 16728,

        VRSQRT14PSZrkz = 16729,

        VRSQRT14SDZrm = 16730,

        VRSQRT14SDZrmk = 16731,

        VRSQRT14SDZrmkz = 16732,

        VRSQRT14SDZrr = 16733,

        VRSQRT14SDZrrk = 16734,

        VRSQRT14SDZrrkz = 16735,

        VRSQRT14SSZrm = 16736,

        VRSQRT14SSZrmk = 16737,

        VRSQRT14SSZrmkz = 16738,

        VRSQRT14SSZrr = 16739,

        VRSQRT14SSZrrk = 16740,

        VRSQRT14SSZrrkz = 16741,

        VRSQRT28PDZm = 16742,

        VRSQRT28PDZmb = 16743,

        VRSQRT28PDZmbk = 16744,

        VRSQRT28PDZmbkz = 16745,

        VRSQRT28PDZmk = 16746,

        VRSQRT28PDZmkz = 16747,

        VRSQRT28PDZr = 16748,

        VRSQRT28PDZrb = 16749,

        VRSQRT28PDZrbk = 16750,

        VRSQRT28PDZrbkz = 16751,

        VRSQRT28PDZrk = 16752,

        VRSQRT28PDZrkz = 16753,

        VRSQRT28PSZm = 16754,

        VRSQRT28PSZmb = 16755,

        VRSQRT28PSZmbk = 16756,

        VRSQRT28PSZmbkz = 16757,

        VRSQRT28PSZmk = 16758,

        VRSQRT28PSZmkz = 16759,

        VRSQRT28PSZr = 16760,

        VRSQRT28PSZrb = 16761,

        VRSQRT28PSZrbk = 16762,

        VRSQRT28PSZrbkz = 16763,

        VRSQRT28PSZrk = 16764,

        VRSQRT28PSZrkz = 16765,

        VRSQRT28SDZm = 16766,

        VRSQRT28SDZmk = 16767,

        VRSQRT28SDZmkz = 16768,

        VRSQRT28SDZr = 16769,

        VRSQRT28SDZrb = 16770,

        VRSQRT28SDZrbk = 16771,

        VRSQRT28SDZrbkz = 16772,

        VRSQRT28SDZrk = 16773,

        VRSQRT28SDZrkz = 16774,

        VRSQRT28SSZm = 16775,

        VRSQRT28SSZmk = 16776,

        VRSQRT28SSZmkz = 16777,

        VRSQRT28SSZr = 16778,

        VRSQRT28SSZrb = 16779,

        VRSQRT28SSZrbk = 16780,

        VRSQRT28SSZrbkz = 16781,

        VRSQRT28SSZrk = 16782,

        VRSQRT28SSZrkz = 16783,

        VRSQRTPHZ128m = 16784,

        VRSQRTPHZ128mb = 16785,

        VRSQRTPHZ128mbk = 16786,

        VRSQRTPHZ128mbkz = 16787,

        VRSQRTPHZ128mk = 16788,

        VRSQRTPHZ128mkz = 16789,

        VRSQRTPHZ128r = 16790,

        VRSQRTPHZ128rk = 16791,

        VRSQRTPHZ128rkz = 16792,

        VRSQRTPHZ256m = 16793,

        VRSQRTPHZ256mb = 16794,

        VRSQRTPHZ256mbk = 16795,

        VRSQRTPHZ256mbkz = 16796,

        VRSQRTPHZ256mk = 16797,

        VRSQRTPHZ256mkz = 16798,

        VRSQRTPHZ256r = 16799,

        VRSQRTPHZ256rk = 16800,

        VRSQRTPHZ256rkz = 16801,

        VRSQRTPHZm = 16802,

        VRSQRTPHZmb = 16803,

        VRSQRTPHZmbk = 16804,

        VRSQRTPHZmbkz = 16805,

        VRSQRTPHZmk = 16806,

        VRSQRTPHZmkz = 16807,

        VRSQRTPHZr = 16808,

        VRSQRTPHZrk = 16809,

        VRSQRTPHZrkz = 16810,

        VRSQRTPSYm = 16811,

        VRSQRTPSYr = 16812,

        VRSQRTPSm = 16813,

        VRSQRTPSr = 16814,

        VRSQRTSHZrm = 16815,

        VRSQRTSHZrmk = 16816,

        VRSQRTSHZrmkz = 16817,

        VRSQRTSHZrr = 16818,

        VRSQRTSHZrrk = 16819,

        VRSQRTSHZrrkz = 16820,

        VRSQRTSSm = 16821,

        VRSQRTSSm_Int = 16822,

        VRSQRTSSr = 16823,

        VRSQRTSSr_Int = 16824,

        VSCALEFPDZ128rm = 16825,

        VSCALEFPDZ128rmb = 16826,

        VSCALEFPDZ128rmbk = 16827,

        VSCALEFPDZ128rmbkz = 16828,

        VSCALEFPDZ128rmk = 16829,

        VSCALEFPDZ128rmkz = 16830,

        VSCALEFPDZ128rr = 16831,

        VSCALEFPDZ128rrk = 16832,

        VSCALEFPDZ128rrkz = 16833,

        VSCALEFPDZ256rm = 16834,

        VSCALEFPDZ256rmb = 16835,

        VSCALEFPDZ256rmbk = 16836,

        VSCALEFPDZ256rmbkz = 16837,

        VSCALEFPDZ256rmk = 16838,

        VSCALEFPDZ256rmkz = 16839,

        VSCALEFPDZ256rr = 16840,

        VSCALEFPDZ256rrk = 16841,

        VSCALEFPDZ256rrkz = 16842,

        VSCALEFPDZrm = 16843,

        VSCALEFPDZrmb = 16844,

        VSCALEFPDZrmbk = 16845,

        VSCALEFPDZrmbkz = 16846,

        VSCALEFPDZrmk = 16847,

        VSCALEFPDZrmkz = 16848,

        VSCALEFPDZrr = 16849,

        VSCALEFPDZrrb = 16850,

        VSCALEFPDZrrbk = 16851,

        VSCALEFPDZrrbkz = 16852,

        VSCALEFPDZrrk = 16853,

        VSCALEFPDZrrkz = 16854,

        VSCALEFPHZ128rm = 16855,

        VSCALEFPHZ128rmb = 16856,

        VSCALEFPHZ128rmbk = 16857,

        VSCALEFPHZ128rmbkz = 16858,

        VSCALEFPHZ128rmk = 16859,

        VSCALEFPHZ128rmkz = 16860,

        VSCALEFPHZ128rr = 16861,

        VSCALEFPHZ128rrk = 16862,

        VSCALEFPHZ128rrkz = 16863,

        VSCALEFPHZ256rm = 16864,

        VSCALEFPHZ256rmb = 16865,

        VSCALEFPHZ256rmbk = 16866,

        VSCALEFPHZ256rmbkz = 16867,

        VSCALEFPHZ256rmk = 16868,

        VSCALEFPHZ256rmkz = 16869,

        VSCALEFPHZ256rr = 16870,

        VSCALEFPHZ256rrk = 16871,

        VSCALEFPHZ256rrkz = 16872,

        VSCALEFPHZrm = 16873,

        VSCALEFPHZrmb = 16874,

        VSCALEFPHZrmbk = 16875,

        VSCALEFPHZrmbkz = 16876,

        VSCALEFPHZrmk = 16877,

        VSCALEFPHZrmkz = 16878,

        VSCALEFPHZrr = 16879,

        VSCALEFPHZrrb = 16880,

        VSCALEFPHZrrbk = 16881,

        VSCALEFPHZrrbkz = 16882,

        VSCALEFPHZrrk = 16883,

        VSCALEFPHZrrkz = 16884,

        VSCALEFPSZ128rm = 16885,

        VSCALEFPSZ128rmb = 16886,

        VSCALEFPSZ128rmbk = 16887,

        VSCALEFPSZ128rmbkz = 16888,

        VSCALEFPSZ128rmk = 16889,

        VSCALEFPSZ128rmkz = 16890,

        VSCALEFPSZ128rr = 16891,

        VSCALEFPSZ128rrk = 16892,

        VSCALEFPSZ128rrkz = 16893,

        VSCALEFPSZ256rm = 16894,

        VSCALEFPSZ256rmb = 16895,

        VSCALEFPSZ256rmbk = 16896,

        VSCALEFPSZ256rmbkz = 16897,

        VSCALEFPSZ256rmk = 16898,

        VSCALEFPSZ256rmkz = 16899,

        VSCALEFPSZ256rr = 16900,

        VSCALEFPSZ256rrk = 16901,

        VSCALEFPSZ256rrkz = 16902,

        VSCALEFPSZrm = 16903,

        VSCALEFPSZrmb = 16904,

        VSCALEFPSZrmbk = 16905,

        VSCALEFPSZrmbkz = 16906,

        VSCALEFPSZrmk = 16907,

        VSCALEFPSZrmkz = 16908,

        VSCALEFPSZrr = 16909,

        VSCALEFPSZrrb = 16910,

        VSCALEFPSZrrbk = 16911,

        VSCALEFPSZrrbkz = 16912,

        VSCALEFPSZrrk = 16913,

        VSCALEFPSZrrkz = 16914,

        VSCALEFSDZrm = 16915,

        VSCALEFSDZrmk = 16916,

        VSCALEFSDZrmkz = 16917,

        VSCALEFSDZrr = 16918,

        VSCALEFSDZrrb_Int = 16919,

        VSCALEFSDZrrb_Intk = 16920,

        VSCALEFSDZrrb_Intkz = 16921,

        VSCALEFSDZrrk = 16922,

        VSCALEFSDZrrkz = 16923,

        VSCALEFSHZrm = 16924,

        VSCALEFSHZrmk = 16925,

        VSCALEFSHZrmkz = 16926,

        VSCALEFSHZrr = 16927,

        VSCALEFSHZrrb_Int = 16928,

        VSCALEFSHZrrb_Intk = 16929,

        VSCALEFSHZrrb_Intkz = 16930,

        VSCALEFSHZrrk = 16931,

        VSCALEFSHZrrkz = 16932,

        VSCALEFSSZrm = 16933,

        VSCALEFSSZrmk = 16934,

        VSCALEFSSZrmkz = 16935,

        VSCALEFSSZrr = 16936,

        VSCALEFSSZrrb_Int = 16937,

        VSCALEFSSZrrb_Intk = 16938,

        VSCALEFSSZrrb_Intkz = 16939,

        VSCALEFSSZrrk = 16940,

        VSCALEFSSZrrkz = 16941,

        VSCATTERDPDZ128mr = 16942,

        VSCATTERDPDZ256mr = 16943,

        VSCATTERDPDZmr = 16944,

        VSCATTERDPSZ128mr = 16945,

        VSCATTERDPSZ256mr = 16946,

        VSCATTERDPSZmr = 16947,

        VSCATTERPF0DPDm = 16948,

        VSCATTERPF0DPSm = 16949,

        VSCATTERPF0QPDm = 16950,

        VSCATTERPF0QPSm = 16951,

        VSCATTERPF1DPDm = 16952,

        VSCATTERPF1DPSm = 16953,

        VSCATTERPF1QPDm = 16954,

        VSCATTERPF1QPSm = 16955,

        VSCATTERQPDZ128mr = 16956,

        VSCATTERQPDZ256mr = 16957,

        VSCATTERQPDZmr = 16958,

        VSCATTERQPSZ128mr = 16959,

        VSCATTERQPSZ256mr = 16960,

        VSCATTERQPSZmr = 16961,

        VSHUFF32X4Z256rmbi = 16962,

        VSHUFF32X4Z256rmbik = 16963,

        VSHUFF32X4Z256rmbikz = 16964,

        VSHUFF32X4Z256rmi = 16965,

        VSHUFF32X4Z256rmik = 16966,

        VSHUFF32X4Z256rmikz = 16967,

        VSHUFF32X4Z256rri = 16968,

        VSHUFF32X4Z256rrik = 16969,

        VSHUFF32X4Z256rrikz = 16970,

        VSHUFF32X4Zrmbi = 16971,

        VSHUFF32X4Zrmbik = 16972,

        VSHUFF32X4Zrmbikz = 16973,

        VSHUFF32X4Zrmi = 16974,

        VSHUFF32X4Zrmik = 16975,

        VSHUFF32X4Zrmikz = 16976,

        VSHUFF32X4Zrri = 16977,

        VSHUFF32X4Zrrik = 16978,

        VSHUFF32X4Zrrikz = 16979,

        VSHUFF64X2Z256rmbi = 16980,

        VSHUFF64X2Z256rmbik = 16981,

        VSHUFF64X2Z256rmbikz = 16982,

        VSHUFF64X2Z256rmi = 16983,

        VSHUFF64X2Z256rmik = 16984,

        VSHUFF64X2Z256rmikz = 16985,

        VSHUFF64X2Z256rri = 16986,

        VSHUFF64X2Z256rrik = 16987,

        VSHUFF64X2Z256rrikz = 16988,

        VSHUFF64X2Zrmbi = 16989,

        VSHUFF64X2Zrmbik = 16990,

        VSHUFF64X2Zrmbikz = 16991,

        VSHUFF64X2Zrmi = 16992,

        VSHUFF64X2Zrmik = 16993,

        VSHUFF64X2Zrmikz = 16994,

        VSHUFF64X2Zrri = 16995,

        VSHUFF64X2Zrrik = 16996,

        VSHUFF64X2Zrrikz = 16997,

        VSHUFI32X4Z256rmbi = 16998,

        VSHUFI32X4Z256rmbik = 16999,

        VSHUFI32X4Z256rmbikz = 17000,

        VSHUFI32X4Z256rmi = 17001,

        VSHUFI32X4Z256rmik = 17002,

        VSHUFI32X4Z256rmikz = 17003,

        VSHUFI32X4Z256rri = 17004,

        VSHUFI32X4Z256rrik = 17005,

        VSHUFI32X4Z256rrikz = 17006,

        VSHUFI32X4Zrmbi = 17007,

        VSHUFI32X4Zrmbik = 17008,

        VSHUFI32X4Zrmbikz = 17009,

        VSHUFI32X4Zrmi = 17010,

        VSHUFI32X4Zrmik = 17011,

        VSHUFI32X4Zrmikz = 17012,

        VSHUFI32X4Zrri = 17013,

        VSHUFI32X4Zrrik = 17014,

        VSHUFI32X4Zrrikz = 17015,

        VSHUFI64X2Z256rmbi = 17016,

        VSHUFI64X2Z256rmbik = 17017,

        VSHUFI64X2Z256rmbikz = 17018,

        VSHUFI64X2Z256rmi = 17019,

        VSHUFI64X2Z256rmik = 17020,

        VSHUFI64X2Z256rmikz = 17021,

        VSHUFI64X2Z256rri = 17022,

        VSHUFI64X2Z256rrik = 17023,

        VSHUFI64X2Z256rrikz = 17024,

        VSHUFI64X2Zrmbi = 17025,

        VSHUFI64X2Zrmbik = 17026,

        VSHUFI64X2Zrmbikz = 17027,

        VSHUFI64X2Zrmi = 17028,

        VSHUFI64X2Zrmik = 17029,

        VSHUFI64X2Zrmikz = 17030,

        VSHUFI64X2Zrri = 17031,

        VSHUFI64X2Zrrik = 17032,

        VSHUFI64X2Zrrikz = 17033,

        VSHUFPDYrmi = 17034,

        VSHUFPDYrri = 17035,

        VSHUFPDZ128rmbi = 17036,

        VSHUFPDZ128rmbik = 17037,

        VSHUFPDZ128rmbikz = 17038,

        VSHUFPDZ128rmi = 17039,

        VSHUFPDZ128rmik = 17040,

        VSHUFPDZ128rmikz = 17041,

        VSHUFPDZ128rri = 17042,

        VSHUFPDZ128rrik = 17043,

        VSHUFPDZ128rrikz = 17044,

        VSHUFPDZ256rmbi = 17045,

        VSHUFPDZ256rmbik = 17046,

        VSHUFPDZ256rmbikz = 17047,

        VSHUFPDZ256rmi = 17048,

        VSHUFPDZ256rmik = 17049,

        VSHUFPDZ256rmikz = 17050,

        VSHUFPDZ256rri = 17051,

        VSHUFPDZ256rrik = 17052,

        VSHUFPDZ256rrikz = 17053,

        VSHUFPDZrmbi = 17054,

        VSHUFPDZrmbik = 17055,

        VSHUFPDZrmbikz = 17056,

        VSHUFPDZrmi = 17057,

        VSHUFPDZrmik = 17058,

        VSHUFPDZrmikz = 17059,

        VSHUFPDZrri = 17060,

        VSHUFPDZrrik = 17061,

        VSHUFPDZrrikz = 17062,

        VSHUFPDrmi = 17063,

        VSHUFPDrri = 17064,

        VSHUFPSYrmi = 17065,

        VSHUFPSYrri = 17066,

        VSHUFPSZ128rmbi = 17067,

        VSHUFPSZ128rmbik = 17068,

        VSHUFPSZ128rmbikz = 17069,

        VSHUFPSZ128rmi = 17070,

        VSHUFPSZ128rmik = 17071,

        VSHUFPSZ128rmikz = 17072,

        VSHUFPSZ128rri = 17073,

        VSHUFPSZ128rrik = 17074,

        VSHUFPSZ128rrikz = 17075,

        VSHUFPSZ256rmbi = 17076,

        VSHUFPSZ256rmbik = 17077,

        VSHUFPSZ256rmbikz = 17078,

        VSHUFPSZ256rmi = 17079,

        VSHUFPSZ256rmik = 17080,

        VSHUFPSZ256rmikz = 17081,

        VSHUFPSZ256rri = 17082,

        VSHUFPSZ256rrik = 17083,

        VSHUFPSZ256rrikz = 17084,

        VSHUFPSZrmbi = 17085,

        VSHUFPSZrmbik = 17086,

        VSHUFPSZrmbikz = 17087,

        VSHUFPSZrmi = 17088,

        VSHUFPSZrmik = 17089,

        VSHUFPSZrmikz = 17090,

        VSHUFPSZrri = 17091,

        VSHUFPSZrrik = 17092,

        VSHUFPSZrrikz = 17093,

        VSHUFPSrmi = 17094,

        VSHUFPSrri = 17095,

        VSQRTPDYm = 17096,

        VSQRTPDYr = 17097,

        VSQRTPDZ128m = 17098,

        VSQRTPDZ128mb = 17099,

        VSQRTPDZ128mbk = 17100,

        VSQRTPDZ128mbkz = 17101,

        VSQRTPDZ128mk = 17102,

        VSQRTPDZ128mkz = 17103,

        VSQRTPDZ128r = 17104,

        VSQRTPDZ128rk = 17105,

        VSQRTPDZ128rkz = 17106,

        VSQRTPDZ256m = 17107,

        VSQRTPDZ256mb = 17108,

        VSQRTPDZ256mbk = 17109,

        VSQRTPDZ256mbkz = 17110,

        VSQRTPDZ256mk = 17111,

        VSQRTPDZ256mkz = 17112,

        VSQRTPDZ256r = 17113,

        VSQRTPDZ256rk = 17114,

        VSQRTPDZ256rkz = 17115,

        VSQRTPDZm = 17116,

        VSQRTPDZmb = 17117,

        VSQRTPDZmbk = 17118,

        VSQRTPDZmbkz = 17119,

        VSQRTPDZmk = 17120,

        VSQRTPDZmkz = 17121,

        VSQRTPDZr = 17122,

        VSQRTPDZrb = 17123,

        VSQRTPDZrbk = 17124,

        VSQRTPDZrbkz = 17125,

        VSQRTPDZrk = 17126,

        VSQRTPDZrkz = 17127,

        VSQRTPDm = 17128,

        VSQRTPDr = 17129,

        VSQRTPHZ128m = 17130,

        VSQRTPHZ128mb = 17131,

        VSQRTPHZ128mbk = 17132,

        VSQRTPHZ128mbkz = 17133,

        VSQRTPHZ128mk = 17134,

        VSQRTPHZ128mkz = 17135,

        VSQRTPHZ128r = 17136,

        VSQRTPHZ128rk = 17137,

        VSQRTPHZ128rkz = 17138,

        VSQRTPHZ256m = 17139,

        VSQRTPHZ256mb = 17140,

        VSQRTPHZ256mbk = 17141,

        VSQRTPHZ256mbkz = 17142,

        VSQRTPHZ256mk = 17143,

        VSQRTPHZ256mkz = 17144,

        VSQRTPHZ256r = 17145,

        VSQRTPHZ256rk = 17146,

        VSQRTPHZ256rkz = 17147,

        VSQRTPHZm = 17148,

        VSQRTPHZmb = 17149,

        VSQRTPHZmbk = 17150,

        VSQRTPHZmbkz = 17151,

        VSQRTPHZmk = 17152,

        VSQRTPHZmkz = 17153,

        VSQRTPHZr = 17154,

        VSQRTPHZrb = 17155,

        VSQRTPHZrbk = 17156,

        VSQRTPHZrbkz = 17157,

        VSQRTPHZrk = 17158,

        VSQRTPHZrkz = 17159,

        VSQRTPSYm = 17160,

        VSQRTPSYr = 17161,

        VSQRTPSZ128m = 17162,

        VSQRTPSZ128mb = 17163,

        VSQRTPSZ128mbk = 17164,

        VSQRTPSZ128mbkz = 17165,

        VSQRTPSZ128mk = 17166,

        VSQRTPSZ128mkz = 17167,

        VSQRTPSZ128r = 17168,

        VSQRTPSZ128rk = 17169,

        VSQRTPSZ128rkz = 17170,

        VSQRTPSZ256m = 17171,

        VSQRTPSZ256mb = 17172,

        VSQRTPSZ256mbk = 17173,

        VSQRTPSZ256mbkz = 17174,

        VSQRTPSZ256mk = 17175,

        VSQRTPSZ256mkz = 17176,

        VSQRTPSZ256r = 17177,

        VSQRTPSZ256rk = 17178,

        VSQRTPSZ256rkz = 17179,

        VSQRTPSZm = 17180,

        VSQRTPSZmb = 17181,

        VSQRTPSZmbk = 17182,

        VSQRTPSZmbkz = 17183,

        VSQRTPSZmk = 17184,

        VSQRTPSZmkz = 17185,

        VSQRTPSZr = 17186,

        VSQRTPSZrb = 17187,

        VSQRTPSZrbk = 17188,

        VSQRTPSZrbkz = 17189,

        VSQRTPSZrk = 17190,

        VSQRTPSZrkz = 17191,

        VSQRTPSm = 17192,

        VSQRTPSr = 17193,

        VSQRTSDZm = 17194,

        VSQRTSDZm_Int = 17195,

        VSQRTSDZm_Intk = 17196,

        VSQRTSDZm_Intkz = 17197,

        VSQRTSDZr = 17198,

        VSQRTSDZr_Int = 17199,

        VSQRTSDZr_Intk = 17200,

        VSQRTSDZr_Intkz = 17201,

        VSQRTSDZrb_Int = 17202,

        VSQRTSDZrb_Intk = 17203,

        VSQRTSDZrb_Intkz = 17204,

        VSQRTSDm = 17205,

        VSQRTSDm_Int = 17206,

        VSQRTSDr = 17207,

        VSQRTSDr_Int = 17208,

        VSQRTSHZm = 17209,

        VSQRTSHZm_Int = 17210,

        VSQRTSHZm_Intk = 17211,

        VSQRTSHZm_Intkz = 17212,

        VSQRTSHZr = 17213,

        VSQRTSHZr_Int = 17214,

        VSQRTSHZr_Intk = 17215,

        VSQRTSHZr_Intkz = 17216,

        VSQRTSHZrb_Int = 17217,

        VSQRTSHZrb_Intk = 17218,

        VSQRTSHZrb_Intkz = 17219,

        VSQRTSSZm = 17220,

        VSQRTSSZm_Int = 17221,

        VSQRTSSZm_Intk = 17222,

        VSQRTSSZm_Intkz = 17223,

        VSQRTSSZr = 17224,

        VSQRTSSZr_Int = 17225,

        VSQRTSSZr_Intk = 17226,

        VSQRTSSZr_Intkz = 17227,

        VSQRTSSZrb_Int = 17228,

        VSQRTSSZrb_Intk = 17229,

        VSQRTSSZrb_Intkz = 17230,

        VSQRTSSm = 17231,

        VSQRTSSm_Int = 17232,

        VSQRTSSr = 17233,

        VSQRTSSr_Int = 17234,

        VSTMXCSR = 17235,

        VSUBPDYrm = 17236,

        VSUBPDYrr = 17237,

        VSUBPDZ128rm = 17238,

        VSUBPDZ128rmb = 17239,

        VSUBPDZ128rmbk = 17240,

        VSUBPDZ128rmbkz = 17241,

        VSUBPDZ128rmk = 17242,

        VSUBPDZ128rmkz = 17243,

        VSUBPDZ128rr = 17244,

        VSUBPDZ128rrk = 17245,

        VSUBPDZ128rrkz = 17246,

        VSUBPDZ256rm = 17247,

        VSUBPDZ256rmb = 17248,

        VSUBPDZ256rmbk = 17249,

        VSUBPDZ256rmbkz = 17250,

        VSUBPDZ256rmk = 17251,

        VSUBPDZ256rmkz = 17252,

        VSUBPDZ256rr = 17253,

        VSUBPDZ256rrk = 17254,

        VSUBPDZ256rrkz = 17255,

        VSUBPDZrm = 17256,

        VSUBPDZrmb = 17257,

        VSUBPDZrmbk = 17258,

        VSUBPDZrmbkz = 17259,

        VSUBPDZrmk = 17260,

        VSUBPDZrmkz = 17261,

        VSUBPDZrr = 17262,

        VSUBPDZrrb = 17263,

        VSUBPDZrrbk = 17264,

        VSUBPDZrrbkz = 17265,

        VSUBPDZrrk = 17266,

        VSUBPDZrrkz = 17267,

        VSUBPDrm = 17268,

        VSUBPDrr = 17269,

        VSUBPHZ128rm = 17270,

        VSUBPHZ128rmb = 17271,

        VSUBPHZ128rmbk = 17272,

        VSUBPHZ128rmbkz = 17273,

        VSUBPHZ128rmk = 17274,

        VSUBPHZ128rmkz = 17275,

        VSUBPHZ128rr = 17276,

        VSUBPHZ128rrk = 17277,

        VSUBPHZ128rrkz = 17278,

        VSUBPHZ256rm = 17279,

        VSUBPHZ256rmb = 17280,

        VSUBPHZ256rmbk = 17281,

        VSUBPHZ256rmbkz = 17282,

        VSUBPHZ256rmk = 17283,

        VSUBPHZ256rmkz = 17284,

        VSUBPHZ256rr = 17285,

        VSUBPHZ256rrk = 17286,

        VSUBPHZ256rrkz = 17287,

        VSUBPHZrm = 17288,

        VSUBPHZrmb = 17289,

        VSUBPHZrmbk = 17290,

        VSUBPHZrmbkz = 17291,

        VSUBPHZrmk = 17292,

        VSUBPHZrmkz = 17293,

        VSUBPHZrr = 17294,

        VSUBPHZrrb = 17295,

        VSUBPHZrrbk = 17296,

        VSUBPHZrrbkz = 17297,

        VSUBPHZrrk = 17298,

        VSUBPHZrrkz = 17299,

        VSUBPSYrm = 17300,

        VSUBPSYrr = 17301,

        VSUBPSZ128rm = 17302,

        VSUBPSZ128rmb = 17303,

        VSUBPSZ128rmbk = 17304,

        VSUBPSZ128rmbkz = 17305,

        VSUBPSZ128rmk = 17306,

        VSUBPSZ128rmkz = 17307,

        VSUBPSZ128rr = 17308,

        VSUBPSZ128rrk = 17309,

        VSUBPSZ128rrkz = 17310,

        VSUBPSZ256rm = 17311,

        VSUBPSZ256rmb = 17312,

        VSUBPSZ256rmbk = 17313,

        VSUBPSZ256rmbkz = 17314,

        VSUBPSZ256rmk = 17315,

        VSUBPSZ256rmkz = 17316,

        VSUBPSZ256rr = 17317,

        VSUBPSZ256rrk = 17318,

        VSUBPSZ256rrkz = 17319,

        VSUBPSZrm = 17320,

        VSUBPSZrmb = 17321,

        VSUBPSZrmbk = 17322,

        VSUBPSZrmbkz = 17323,

        VSUBPSZrmk = 17324,

        VSUBPSZrmkz = 17325,

        VSUBPSZrr = 17326,

        VSUBPSZrrb = 17327,

        VSUBPSZrrbk = 17328,

        VSUBPSZrrbkz = 17329,

        VSUBPSZrrk = 17330,

        VSUBPSZrrkz = 17331,

        VSUBPSrm = 17332,

        VSUBPSrr = 17333,

        VSUBSDZrm = 17334,

        VSUBSDZrm_Int = 17335,

        VSUBSDZrm_Intk = 17336,

        VSUBSDZrm_Intkz = 17337,

        VSUBSDZrr = 17338,

        VSUBSDZrr_Int = 17339,

        VSUBSDZrr_Intk = 17340,

        VSUBSDZrr_Intkz = 17341,

        VSUBSDZrrb_Int = 17342,

        VSUBSDZrrb_Intk = 17343,

        VSUBSDZrrb_Intkz = 17344,

        VSUBSDrm = 17345,

        VSUBSDrm_Int = 17346,

        VSUBSDrr = 17347,

        VSUBSDrr_Int = 17348,

        VSUBSHZrm = 17349,

        VSUBSHZrm_Int = 17350,

        VSUBSHZrm_Intk = 17351,

        VSUBSHZrm_Intkz = 17352,

        VSUBSHZrr = 17353,

        VSUBSHZrr_Int = 17354,

        VSUBSHZrr_Intk = 17355,

        VSUBSHZrr_Intkz = 17356,

        VSUBSHZrrb_Int = 17357,

        VSUBSHZrrb_Intk = 17358,

        VSUBSHZrrb_Intkz = 17359,

        VSUBSSZrm = 17360,

        VSUBSSZrm_Int = 17361,

        VSUBSSZrm_Intk = 17362,

        VSUBSSZrm_Intkz = 17363,

        VSUBSSZrr = 17364,

        VSUBSSZrr_Int = 17365,

        VSUBSSZrr_Intk = 17366,

        VSUBSSZrr_Intkz = 17367,

        VSUBSSZrrb_Int = 17368,

        VSUBSSZrrb_Intk = 17369,

        VSUBSSZrrb_Intkz = 17370,

        VSUBSSrm = 17371,

        VSUBSSrm_Int = 17372,

        VSUBSSrr = 17373,

        VSUBSSrr_Int = 17374,

        VTESTPDYrm = 17375,

        VTESTPDYrr = 17376,

        VTESTPDrm = 17377,

        VTESTPDrr = 17378,

        VTESTPSYrm = 17379,

        VTESTPSYrr = 17380,

        VTESTPSrm = 17381,

        VTESTPSrr = 17382,

        VUCOMISDZrm = 17383,

        VUCOMISDZrm_Int = 17384,

        VUCOMISDZrr = 17385,

        VUCOMISDZrr_Int = 17386,

        VUCOMISDZrrb = 17387,

        VUCOMISDrm = 17388,

        VUCOMISDrm_Int = 17389,

        VUCOMISDrr = 17390,

        VUCOMISDrr_Int = 17391,

        VUCOMISHZrm = 17392,

        VUCOMISHZrm_Int = 17393,

        VUCOMISHZrr = 17394,

        VUCOMISHZrr_Int = 17395,

        VUCOMISHZrrb = 17396,

        VUCOMISSZrm = 17397,

        VUCOMISSZrm_Int = 17398,

        VUCOMISSZrr = 17399,

        VUCOMISSZrr_Int = 17400,

        VUCOMISSZrrb = 17401,

        VUCOMISSrm = 17402,

        VUCOMISSrm_Int = 17403,

        VUCOMISSrr = 17404,

        VUCOMISSrr_Int = 17405,

        VUNPCKHPDYrm = 17406,

        VUNPCKHPDYrr = 17407,

        VUNPCKHPDZ128rm = 17408,

        VUNPCKHPDZ128rmb = 17409,

        VUNPCKHPDZ128rmbk = 17410,

        VUNPCKHPDZ128rmbkz = 17411,

        VUNPCKHPDZ128rmk = 17412,

        VUNPCKHPDZ128rmkz = 17413,

        VUNPCKHPDZ128rr = 17414,

        VUNPCKHPDZ128rrk = 17415,

        VUNPCKHPDZ128rrkz = 17416,

        VUNPCKHPDZ256rm = 17417,

        VUNPCKHPDZ256rmb = 17418,

        VUNPCKHPDZ256rmbk = 17419,

        VUNPCKHPDZ256rmbkz = 17420,

        VUNPCKHPDZ256rmk = 17421,

        VUNPCKHPDZ256rmkz = 17422,

        VUNPCKHPDZ256rr = 17423,

        VUNPCKHPDZ256rrk = 17424,

        VUNPCKHPDZ256rrkz = 17425,

        VUNPCKHPDZrm = 17426,

        VUNPCKHPDZrmb = 17427,

        VUNPCKHPDZrmbk = 17428,

        VUNPCKHPDZrmbkz = 17429,

        VUNPCKHPDZrmk = 17430,

        VUNPCKHPDZrmkz = 17431,

        VUNPCKHPDZrr = 17432,

        VUNPCKHPDZrrk = 17433,

        VUNPCKHPDZrrkz = 17434,

        VUNPCKHPDrm = 17435,

        VUNPCKHPDrr = 17436,

        VUNPCKHPSYrm = 17437,

        VUNPCKHPSYrr = 17438,

        VUNPCKHPSZ128rm = 17439,

        VUNPCKHPSZ128rmb = 17440,

        VUNPCKHPSZ128rmbk = 17441,

        VUNPCKHPSZ128rmbkz = 17442,

        VUNPCKHPSZ128rmk = 17443,

        VUNPCKHPSZ128rmkz = 17444,

        VUNPCKHPSZ128rr = 17445,

        VUNPCKHPSZ128rrk = 17446,

        VUNPCKHPSZ128rrkz = 17447,

        VUNPCKHPSZ256rm = 17448,

        VUNPCKHPSZ256rmb = 17449,

        VUNPCKHPSZ256rmbk = 17450,

        VUNPCKHPSZ256rmbkz = 17451,

        VUNPCKHPSZ256rmk = 17452,

        VUNPCKHPSZ256rmkz = 17453,

        VUNPCKHPSZ256rr = 17454,

        VUNPCKHPSZ256rrk = 17455,

        VUNPCKHPSZ256rrkz = 17456,

        VUNPCKHPSZrm = 17457,

        VUNPCKHPSZrmb = 17458,

        VUNPCKHPSZrmbk = 17459,

        VUNPCKHPSZrmbkz = 17460,

        VUNPCKHPSZrmk = 17461,

        VUNPCKHPSZrmkz = 17462,

        VUNPCKHPSZrr = 17463,

        VUNPCKHPSZrrk = 17464,

        VUNPCKHPSZrrkz = 17465,

        VUNPCKHPSrm = 17466,

        VUNPCKHPSrr = 17467,

        VUNPCKLPDYrm = 17468,

        VUNPCKLPDYrr = 17469,

        VUNPCKLPDZ128rm = 17470,

        VUNPCKLPDZ128rmb = 17471,

        VUNPCKLPDZ128rmbk = 17472,

        VUNPCKLPDZ128rmbkz = 17473,

        VUNPCKLPDZ128rmk = 17474,

        VUNPCKLPDZ128rmkz = 17475,

        VUNPCKLPDZ128rr = 17476,

        VUNPCKLPDZ128rrk = 17477,

        VUNPCKLPDZ128rrkz = 17478,

        VUNPCKLPDZ256rm = 17479,

        VUNPCKLPDZ256rmb = 17480,

        VUNPCKLPDZ256rmbk = 17481,

        VUNPCKLPDZ256rmbkz = 17482,

        VUNPCKLPDZ256rmk = 17483,

        VUNPCKLPDZ256rmkz = 17484,

        VUNPCKLPDZ256rr = 17485,

        VUNPCKLPDZ256rrk = 17486,

        VUNPCKLPDZ256rrkz = 17487,

        VUNPCKLPDZrm = 17488,

        VUNPCKLPDZrmb = 17489,

        VUNPCKLPDZrmbk = 17490,

        VUNPCKLPDZrmbkz = 17491,

        VUNPCKLPDZrmk = 17492,

        VUNPCKLPDZrmkz = 17493,

        VUNPCKLPDZrr = 17494,

        VUNPCKLPDZrrk = 17495,

        VUNPCKLPDZrrkz = 17496,

        VUNPCKLPDrm = 17497,

        VUNPCKLPDrr = 17498,

        VUNPCKLPSYrm = 17499,

        VUNPCKLPSYrr = 17500,

        VUNPCKLPSZ128rm = 17501,

        VUNPCKLPSZ128rmb = 17502,

        VUNPCKLPSZ128rmbk = 17503,

        VUNPCKLPSZ128rmbkz = 17504,

        VUNPCKLPSZ128rmk = 17505,

        VUNPCKLPSZ128rmkz = 17506,

        VUNPCKLPSZ128rr = 17507,

        VUNPCKLPSZ128rrk = 17508,

        VUNPCKLPSZ128rrkz = 17509,

        VUNPCKLPSZ256rm = 17510,

        VUNPCKLPSZ256rmb = 17511,

        VUNPCKLPSZ256rmbk = 17512,

        VUNPCKLPSZ256rmbkz = 17513,

        VUNPCKLPSZ256rmk = 17514,

        VUNPCKLPSZ256rmkz = 17515,

        VUNPCKLPSZ256rr = 17516,

        VUNPCKLPSZ256rrk = 17517,

        VUNPCKLPSZ256rrkz = 17518,

        VUNPCKLPSZrm = 17519,

        VUNPCKLPSZrmb = 17520,

        VUNPCKLPSZrmbk = 17521,

        VUNPCKLPSZrmbkz = 17522,

        VUNPCKLPSZrmk = 17523,

        VUNPCKLPSZrmkz = 17524,

        VUNPCKLPSZrr = 17525,

        VUNPCKLPSZrrk = 17526,

        VUNPCKLPSZrrkz = 17527,

        VUNPCKLPSrm = 17528,

        VUNPCKLPSrr = 17529,

        VXORPDYrm = 17530,

        VXORPDYrr = 17531,

        VXORPDZ128rm = 17532,

        VXORPDZ128rmb = 17533,

        VXORPDZ128rmbk = 17534,

        VXORPDZ128rmbkz = 17535,

        VXORPDZ128rmk = 17536,

        VXORPDZ128rmkz = 17537,

        VXORPDZ128rr = 17538,

        VXORPDZ128rrk = 17539,

        VXORPDZ128rrkz = 17540,

        VXORPDZ256rm = 17541,

        VXORPDZ256rmb = 17542,

        VXORPDZ256rmbk = 17543,

        VXORPDZ256rmbkz = 17544,

        VXORPDZ256rmk = 17545,

        VXORPDZ256rmkz = 17546,

        VXORPDZ256rr = 17547,

        VXORPDZ256rrk = 17548,

        VXORPDZ256rrkz = 17549,

        VXORPDZrm = 17550,

        VXORPDZrmb = 17551,

        VXORPDZrmbk = 17552,

        VXORPDZrmbkz = 17553,

        VXORPDZrmk = 17554,

        VXORPDZrmkz = 17555,

        VXORPDZrr = 17556,

        VXORPDZrrk = 17557,

        VXORPDZrrkz = 17558,

        VXORPDrm = 17559,

        VXORPDrr = 17560,

        VXORPSYrm = 17561,

        VXORPSYrr = 17562,

        VXORPSZ128rm = 17563,

        VXORPSZ128rmb = 17564,

        VXORPSZ128rmbk = 17565,

        VXORPSZ128rmbkz = 17566,

        VXORPSZ128rmk = 17567,

        VXORPSZ128rmkz = 17568,

        VXORPSZ128rr = 17569,

        VXORPSZ128rrk = 17570,

        VXORPSZ128rrkz = 17571,

        VXORPSZ256rm = 17572,

        VXORPSZ256rmb = 17573,

        VXORPSZ256rmbk = 17574,

        VXORPSZ256rmbkz = 17575,

        VXORPSZ256rmk = 17576,

        VXORPSZ256rmkz = 17577,

        VXORPSZ256rr = 17578,

        VXORPSZ256rrk = 17579,

        VXORPSZ256rrkz = 17580,

        VXORPSZrm = 17581,

        VXORPSZrmb = 17582,

        VXORPSZrmbk = 17583,

        VXORPSZrmbkz = 17584,

        VXORPSZrmk = 17585,

        VXORPSZrmkz = 17586,

        VXORPSZrr = 17587,

        VXORPSZrrk = 17588,

        VXORPSZrrkz = 17589,

        VXORPSrm = 17590,

        VXORPSrr = 17591,

        VZEROALL = 17592,

        VZEROUPPER = 17593,

        WAIT = 17594,

        WBINVD = 17595,

        WBNOINVD = 17596,

        WRFLAGS32 = 17597,

        WRFLAGS64 = 17598,

        WRFSBASE = 17599,

        WRFSBASE64 = 17600,

        WRGSBASE = 17601,

        WRGSBASE64 = 17602,

        WRMSR = 17603,

        WRPKRUr = 17604,

        WRSSD = 17605,

        WRSSQ = 17606,

        WRUSSD = 17607,

        WRUSSQ = 17608,

        XABORT = 17609,

        XACQUIRE_PREFIX = 17610,

        XADD16rm = 17611,

        XADD16rr = 17612,

        XADD32rm = 17613,

        XADD32rr = 17614,

        XADD64rm = 17615,

        XADD64rr = 17616,

        XADD8rm = 17617,

        XADD8rr = 17618,

        XAM_F = 17619,

        XAM_Fp32 = 17620,

        XAM_Fp64 = 17621,

        XAM_Fp80 = 17622,

        XBEGIN = 17623,

        XBEGIN_2 = 17624,

        XBEGIN_4 = 17625,

        XCHG16ar = 17626,

        XCHG16rm = 17627,

        XCHG16rr = 17628,

        XCHG32ar = 17629,

        XCHG32rm = 17630,

        XCHG32rr = 17631,

        XCHG64ar = 17632,

        XCHG64rm = 17633,

        XCHG64rr = 17634,

        XCHG8rm = 17635,

        XCHG8rr = 17636,

        XCH_F = 17637,

        XCRYPTCBC = 17638,

        XCRYPTCFB = 17639,

        XCRYPTCTR = 17640,

        XCRYPTECB = 17641,

        XCRYPTOFB = 17642,

        XEND = 17643,

        XGETBV = 17644,

        XLAT = 17645,

        XOR16i16 = 17646,

        XOR16mi = 17647,

        XOR16mi8 = 17648,

        XOR16mr = 17649,

        XOR16ri = 17650,

        XOR16ri8 = 17651,

        XOR16rm = 17652,

        XOR16rr = 17653,

        XOR16rr_REV = 17654,

        XOR32i32 = 17655,

        XOR32mi = 17656,

        XOR32mi8 = 17657,

        XOR32mr = 17658,

        XOR32ri = 17659,

        XOR32ri8 = 17660,

        XOR32rm = 17661,

        XOR32rr = 17662,

        XOR32rr_REV = 17663,

        XOR64i32 = 17664,

        XOR64mi32 = 17665,

        XOR64mi8 = 17666,

        XOR64mr = 17667,

        XOR64ri32 = 17668,

        XOR64ri8 = 17669,

        XOR64rm = 17670,

        XOR64rr = 17671,

        XOR64rr_REV = 17672,

        XOR8i8 = 17673,

        XOR8mi = 17674,

        XOR8mi8 = 17675,

        XOR8mr = 17676,

        XOR8ri = 17677,

        XOR8ri8 = 17678,

        XOR8rm = 17679,

        XOR8rr = 17680,

        XOR8rr_NOREX = 17681,

        XOR8rr_REV = 17682,

        XORPDrm = 17683,

        XORPDrr = 17684,

        XORPSrm = 17685,

        XORPSrr = 17686,

        XRELEASE_PREFIX = 17687,

        XRESLDTRK = 17688,

        XRSTOR = 17689,

        XRSTOR64 = 17690,

        XRSTORS = 17691,

        XRSTORS64 = 17692,

        XSAVE = 17693,

        XSAVE64 = 17694,

        XSAVEC = 17695,

        XSAVEC64 = 17696,

        XSAVEOPT = 17697,

        XSAVEOPT64 = 17698,

        XSAVES = 17699,

        XSAVES64 = 17700,

        XSETBV = 17701,

        XSHA1 = 17702,

        XSHA256 = 17703,

        XSTORE = 17704,

        XSUSLDTRK = 17705,

        XTEST = 17706,
    }
}

