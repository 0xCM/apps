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

        G_ADD = 44,

        G_SUB = 45,

        G_MUL = 46,

        G_SDIV = 47,

        G_UDIV = 48,

        G_SREM = 49,

        G_UREM = 50,

        G_SDIVREM = 51,

        G_UDIVREM = 52,

        G_AND = 53,

        G_OR = 54,

        G_XOR = 55,

        G_IMPLICIT_DEF = 56,

        G_PHI = 57,

        G_FRAME_INDEX = 58,

        G_GLOBAL_VALUE = 59,

        G_EXTRACT = 60,

        G_UNMERGE_VALUES = 61,

        G_INSERT = 62,

        G_MERGE_VALUES = 63,

        G_BUILD_VECTOR = 64,

        G_BUILD_VECTOR_TRUNC = 65,

        G_CONCAT_VECTORS = 66,

        G_PTRTOINT = 67,

        G_INTTOPTR = 68,

        G_BITCAST = 69,

        G_FREEZE = 70,

        G_INTRINSIC_TRUNC = 71,

        G_INTRINSIC_ROUND = 72,

        G_INTRINSIC_LRINT = 73,

        G_INTRINSIC_ROUNDEVEN = 74,

        G_READCYCLECOUNTER = 75,

        G_LOAD = 76,

        G_SEXTLOAD = 77,

        G_ZEXTLOAD = 78,

        G_INDEXED_LOAD = 79,

        G_INDEXED_SEXTLOAD = 80,

        G_INDEXED_ZEXTLOAD = 81,

        G_STORE = 82,

        G_INDEXED_STORE = 83,

        G_ATOMIC_CMPXCHG_WITH_SUCCESS = 84,

        G_ATOMIC_CMPXCHG = 85,

        G_ATOMICRMW_XCHG = 86,

        G_ATOMICRMW_ADD = 87,

        G_ATOMICRMW_SUB = 88,

        G_ATOMICRMW_AND = 89,

        G_ATOMICRMW_NAND = 90,

        G_ATOMICRMW_OR = 91,

        G_ATOMICRMW_XOR = 92,

        G_ATOMICRMW_MAX = 93,

        G_ATOMICRMW_MIN = 94,

        G_ATOMICRMW_UMAX = 95,

        G_ATOMICRMW_UMIN = 96,

        G_ATOMICRMW_FADD = 97,

        G_ATOMICRMW_FSUB = 98,

        G_FENCE = 99,

        G_BRCOND = 100,

        G_BRINDIRECT = 101,

        G_INTRINSIC = 102,

        G_INTRINSIC_W_SIDE_EFFECTS = 103,

        G_ANYEXT = 104,

        G_TRUNC = 105,

        G_CONSTANT = 106,

        G_FCONSTANT = 107,

        G_VASTART = 108,

        G_VAARG = 109,

        G_SEXT = 110,

        G_SEXT_INREG = 111,

        G_ZEXT = 112,

        G_SHL = 113,

        G_LSHR = 114,

        G_ASHR = 115,

        G_FSHL = 116,

        G_FSHR = 117,

        G_ROTR = 118,

        G_ROTL = 119,

        G_ICMP = 120,

        G_FCMP = 121,

        G_SELECT = 122,

        G_UADDO = 123,

        G_UADDE = 124,

        G_USUBO = 125,

        G_USUBE = 126,

        G_SADDO = 127,

        G_SADDE = 128,

        G_SSUBO = 129,

        G_SSUBE = 130,

        G_UMULO = 131,

        G_SMULO = 132,

        G_UMULH = 133,

        G_SMULH = 134,

        G_UADDSAT = 135,

        G_SADDSAT = 136,

        G_USUBSAT = 137,

        G_SSUBSAT = 138,

        G_USHLSAT = 139,

        G_SSHLSAT = 140,

        G_SMULFIX = 141,

        G_UMULFIX = 142,

        G_SMULFIXSAT = 143,

        G_UMULFIXSAT = 144,

        G_SDIVFIX = 145,

        G_UDIVFIX = 146,

        G_SDIVFIXSAT = 147,

        G_UDIVFIXSAT = 148,

        G_FADD = 149,

        G_FSUB = 150,

        G_FMUL = 151,

        G_FMA = 152,

        G_FMAD = 153,

        G_FDIV = 154,

        G_FREM = 155,

        G_FPOW = 156,

        G_FPOWI = 157,

        G_FEXP = 158,

        G_FEXP2 = 159,

        G_FLOG = 160,

        G_FLOG2 = 161,

        G_FLOG10 = 162,

        G_FNEG = 163,

        G_FPEXT = 164,

        G_FPTRUNC = 165,

        G_FPTOSI = 166,

        G_FPTOUI = 167,

        G_SITOFP = 168,

        G_UITOFP = 169,

        G_FABS = 170,

        G_FCOPYSIGN = 171,

        G_FCANONICALIZE = 172,

        G_FMINNUM = 173,

        G_FMAXNUM = 174,

        G_FMINNUM_IEEE = 175,

        G_FMAXNUM_IEEE = 176,

        G_FMINIMUM = 177,

        G_FMAXIMUM = 178,

        G_PTR_ADD = 179,

        G_PTRMASK = 180,

        G_SMIN = 181,

        G_SMAX = 182,

        G_UMIN = 183,

        G_UMAX = 184,

        G_ABS = 185,

        G_BR = 186,

        G_BRJT = 187,

        G_INSERT_VECTOR_ELT = 188,

        G_EXTRACT_VECTOR_ELT = 189,

        G_SHUFFLE_VECTOR = 190,

        G_CTTZ = 191,

        G_CTTZ_ZERO_UNDEF = 192,

        G_CTLZ = 193,

        G_CTLZ_ZERO_UNDEF = 194,

        G_CTPOP = 195,

        G_BSWAP = 196,

        G_BITREVERSE = 197,

        G_FCEIL = 198,

        G_FCOS = 199,

        G_FSIN = 200,

        G_FSQRT = 201,

        G_FFLOOR = 202,

        G_FRINT = 203,

        G_FNEARBYINT = 204,

        G_ADDRSPACE_CAST = 205,

        G_BLOCK_ADDR = 206,

        G_JUMP_TABLE = 207,

        G_DYN_STACKALLOC = 208,

        G_STRICT_FADD = 209,

        G_STRICT_FSUB = 210,

        G_STRICT_FMUL = 211,

        G_STRICT_FDIV = 212,

        G_STRICT_FREM = 213,

        G_STRICT_FMA = 214,

        G_STRICT_FSQRT = 215,

        G_READ_REGISTER = 216,

        G_WRITE_REGISTER = 217,

        G_MEMCPY = 218,

        G_MEMCPY_INLINE = 219,

        G_MEMMOVE = 220,

        G_MEMSET = 221,

        G_BZERO = 222,

        G_VECREDUCE_SEQ_FADD = 223,

        G_VECREDUCE_SEQ_FMUL = 224,

        G_VECREDUCE_FADD = 225,

        G_VECREDUCE_FMUL = 226,

        G_VECREDUCE_FMAX = 227,

        G_VECREDUCE_FMIN = 228,

        G_VECREDUCE_ADD = 229,

        G_VECREDUCE_MUL = 230,

        G_VECREDUCE_AND = 231,

        G_VECREDUCE_OR = 232,

        G_VECREDUCE_XOR = 233,

        G_VECREDUCE_SMAX = 234,

        G_VECREDUCE_SMIN = 235,

        G_VECREDUCE_UMAX = 236,

        G_VECREDUCE_UMIN = 237,

        G_SBFX = 238,

        G_UBFX = 239,

        ADD16ri8_DB = 240,

        ADD16ri_DB = 241,

        ADD16rr_DB = 242,

        ADD32ri8_DB = 243,

        ADD32ri_DB = 244,

        ADD32rr_DB = 245,

        ADD64ri32_DB = 246,

        ADD64ri8_DB = 247,

        ADD64rr_DB = 248,

        ADD8ri_DB = 249,

        ADD8rr_DB = 250,

        AVX1_SETALLONES = 251,

        AVX2_SETALLONES = 252,

        AVX512_128_SET0 = 253,

        AVX512_256_SET0 = 254,

        AVX512_512_SET0 = 255,

        AVX512_512_SETALLONES = 256,

        AVX512_512_SEXT_MASK_32 = 257,

        AVX512_512_SEXT_MASK_64 = 258,

        AVX512_FsFLD0F128 = 259,

        AVX512_FsFLD0SD = 260,

        AVX512_FsFLD0SS = 261,

        AVX_SET0 = 262,

        CALL64m_RVMARKER = 263,

        CALL64pcrel32_RVMARKER = 264,

        CALL64r_RVMARKER = 265,

        FsFLD0F128 = 266,

        FsFLD0SD = 267,

        FsFLD0SS = 268,

        INDIRECT_THUNK_CALL32 = 269,

        INDIRECT_THUNK_CALL64 = 270,

        INDIRECT_THUNK_TCRETURN32 = 271,

        INDIRECT_THUNK_TCRETURN64 = 272,

        KSET0D = 273,

        KSET0Q = 274,

        KSET0W = 275,

        KSET1D = 276,

        KSET1Q = 277,

        KSET1W = 278,

        LCMPXCHG16B_NO_RBX = 279,

        LCMPXCHG16B_SAVE_RBX = 280,

        MMX_SET0 = 281,

        MORESTACK_RET = 282,

        MORESTACK_RET_RESTORE_R10 = 283,

        MOV32ImmSExti8 = 284,

        MOV32r0 = 285,

        MOV32r1 = 286,

        MOV32r_1 = 287,

        MOV32ri64 = 288,

        MOV64ImmSExti8 = 289,

        MWAITX = 290,

        MWAITX_SAVE_RBX = 291,

        SEH_EndPrologue = 292,

        SEH_Epilogue = 293,

        SEH_PushFrame = 294,

        SEH_PushReg = 295,

        SEH_SaveReg = 296,

        SEH_SaveXMM = 297,

        SEH_SetFrame = 298,

        SEH_StackAlign = 299,

        SEH_StackAlloc = 300,

        SETB_C32r = 301,

        SETB_C64r = 302,

        SHLDROT32ri = 303,

        SHLDROT64ri = 304,

        SHRDROT32ri = 305,

        SHRDROT64ri = 306,

        VMOVAPSZ128mr_NOVLX = 307,

        VMOVAPSZ128rm_NOVLX = 308,

        VMOVAPSZ256mr_NOVLX = 309,

        VMOVAPSZ256rm_NOVLX = 310,

        VMOVUPSZ128mr_NOVLX = 311,

        VMOVUPSZ128rm_NOVLX = 312,

        VMOVUPSZ256mr_NOVLX = 313,

        VMOVUPSZ256rm_NOVLX = 314,

        V_SET0 = 315,

        V_SETALLONES = 316,

        XABORT_DEF = 317,

        XOR32_FP = 318,

        XOR64_FP = 319,

        AAA = 320,

        AAD8i8 = 321,

        AAM8i8 = 322,

        AAS = 323,

        ABS_F = 324,

        ABS_Fp32 = 325,

        ABS_Fp64 = 326,

        ABS_Fp80 = 327,

        ADC16i16 = 328,

        ADC16mi = 329,

        ADC16mi8 = 330,

        ADC16mr = 331,

        ADC16ri = 332,

        ADC16ri8 = 333,

        ADC16rm = 334,

        ADC16rr = 335,

        ADC16rr_REV = 336,

        ADC32i32 = 337,

        ADC32mi = 338,

        ADC32mi8 = 339,

        ADC32mr = 340,

        ADC32ri = 341,

        ADC32ri8 = 342,

        ADC32rm = 343,

        ADC32rr = 344,

        ADC32rr_REV = 345,

        ADC64i32 = 346,

        ADC64mi32 = 347,

        ADC64mi8 = 348,

        ADC64mr = 349,

        ADC64ri32 = 350,

        ADC64ri8 = 351,

        ADC64rm = 352,

        ADC64rr = 353,

        ADC64rr_REV = 354,

        ADC8i8 = 355,

        ADC8mi = 356,

        ADC8mi8 = 357,

        ADC8mr = 358,

        ADC8ri = 359,

        ADC8ri8 = 360,

        ADC8rm = 361,

        ADC8rr = 362,

        ADC8rr_REV = 363,

        ADCX32rm = 364,

        ADCX32rr = 365,

        ADCX64rm = 366,

        ADCX64rr = 367,

        ADD16i16 = 368,

        ADD16mi = 369,

        ADD16mi8 = 370,

        ADD16mr = 371,

        ADD16ri = 372,

        ADD16ri8 = 373,

        ADD16rm = 374,

        ADD16rr = 375,

        ADD16rr_REV = 376,

        ADD32i32 = 377,

        ADD32mi = 378,

        ADD32mi8 = 379,

        ADD32mr = 380,

        ADD32ri = 381,

        ADD32ri8 = 382,

        ADD32rm = 383,

        ADD32rr = 384,

        ADD32rr_REV = 385,

        ADD64i32 = 386,

        ADD64mi32 = 387,

        ADD64mi8 = 388,

        ADD64mr = 389,

        ADD64ri32 = 390,

        ADD64ri8 = 391,

        ADD64rm = 392,

        ADD64rr = 393,

        ADD64rr_REV = 394,

        ADD8i8 = 395,

        ADD8mi = 396,

        ADD8mi8 = 397,

        ADD8mr = 398,

        ADD8ri = 399,

        ADD8ri8 = 400,

        ADD8rm = 401,

        ADD8rr = 402,

        ADD8rr_REV = 403,

        ADDPDrm = 404,

        ADDPDrr = 405,

        ADDPSrm = 406,

        ADDPSrr = 407,

        ADDR16_PREFIX = 408,

        ADDR32_PREFIX = 409,

        ADDSDrm = 410,

        ADDSDrm_Int = 411,

        ADDSDrr = 412,

        ADDSDrr_Int = 413,

        ADDSSrm = 414,

        ADDSSrm_Int = 415,

        ADDSSrr = 416,

        ADDSSrr_Int = 417,

        ADDSUBPDrm = 418,

        ADDSUBPDrr = 419,

        ADDSUBPSrm = 420,

        ADDSUBPSrr = 421,

        ADD_F32m = 422,

        ADD_F64m = 423,

        ADD_FI16m = 424,

        ADD_FI32m = 425,

        ADD_FPrST0 = 426,

        ADD_FST0r = 427,

        ADD_Fp32 = 428,

        ADD_Fp32m = 429,

        ADD_Fp64 = 430,

        ADD_Fp64m = 431,

        ADD_Fp64m32 = 432,

        ADD_Fp80 = 433,

        ADD_Fp80m32 = 434,

        ADD_Fp80m64 = 435,

        ADD_FpI16m32 = 436,

        ADD_FpI16m64 = 437,

        ADD_FpI16m80 = 438,

        ADD_FpI32m32 = 439,

        ADD_FpI32m64 = 440,

        ADD_FpI32m80 = 441,

        ADD_FrST0 = 442,

        ADJCALLSTACKDOWN32 = 443,

        ADJCALLSTACKDOWN64 = 444,

        ADJCALLSTACKUP32 = 445,

        ADJCALLSTACKUP64 = 446,

        ADOX32rm = 447,

        ADOX32rr = 448,

        ADOX64rm = 449,

        ADOX64rr = 450,

        AESDEC128KL = 451,

        AESDEC256KL = 452,

        AESDECLASTrm = 453,

        AESDECLASTrr = 454,

        AESDECWIDE128KL = 455,

        AESDECWIDE256KL = 456,

        AESDECrm = 457,

        AESDECrr = 458,

        AESENC128KL = 459,

        AESENC256KL = 460,

        AESENCLASTrm = 461,

        AESENCLASTrr = 462,

        AESENCWIDE128KL = 463,

        AESENCWIDE256KL = 464,

        AESENCrm = 465,

        AESENCrr = 466,

        AESIMCrm = 467,

        AESIMCrr = 468,

        AESKEYGENASSIST128rm = 469,

        AESKEYGENASSIST128rr = 470,

        AND16i16 = 471,

        AND16mi = 472,

        AND16mi8 = 473,

        AND16mr = 474,

        AND16ri = 475,

        AND16ri8 = 476,

        AND16rm = 477,

        AND16rr = 478,

        AND16rr_REV = 479,

        AND32i32 = 480,

        AND32mi = 481,

        AND32mi8 = 482,

        AND32mr = 483,

        AND32ri = 484,

        AND32ri8 = 485,

        AND32rm = 486,

        AND32rr = 487,

        AND32rr_REV = 488,

        AND64i32 = 489,

        AND64mi32 = 490,

        AND64mi8 = 491,

        AND64mr = 492,

        AND64ri32 = 493,

        AND64ri8 = 494,

        AND64rm = 495,

        AND64rr = 496,

        AND64rr_REV = 497,

        AND8i8 = 498,

        AND8mi = 499,

        AND8mi8 = 500,

        AND8mr = 501,

        AND8ri = 502,

        AND8ri8 = 503,

        AND8rm = 504,

        AND8rr = 505,

        AND8rr_REV = 506,

        ANDN32rm = 507,

        ANDN32rr = 508,

        ANDN64rm = 509,

        ANDN64rr = 510,

        ANDNPDrm = 511,

        ANDNPDrr = 512,

        ANDNPSrm = 513,

        ANDNPSrr = 514,

        ANDPDrm = 515,

        ANDPDrr = 516,

        ANDPSrm = 517,

        ANDPSrr = 518,

        ARPL16mr = 519,

        ARPL16rr = 520,

        BEXTR32rm = 521,

        BEXTR32rr = 522,

        BEXTR64rm = 523,

        BEXTR64rr = 524,

        BEXTRI32mi = 525,

        BEXTRI32ri = 526,

        BEXTRI64mi = 527,

        BEXTRI64ri = 528,

        BLCFILL32rm = 529,

        BLCFILL32rr = 530,

        BLCFILL64rm = 531,

        BLCFILL64rr = 532,

        BLCI32rm = 533,

        BLCI32rr = 534,

        BLCI64rm = 535,

        BLCI64rr = 536,

        BLCIC32rm = 537,

        BLCIC32rr = 538,

        BLCIC64rm = 539,

        BLCIC64rr = 540,

        BLCMSK32rm = 541,

        BLCMSK32rr = 542,

        BLCMSK64rm = 543,

        BLCMSK64rr = 544,

        BLCS32rm = 545,

        BLCS32rr = 546,

        BLCS64rm = 547,

        BLCS64rr = 548,

        BLENDPDrmi = 549,

        BLENDPDrri = 550,

        BLENDPSrmi = 551,

        BLENDPSrri = 552,

        BLENDVPDrm0 = 553,

        BLENDVPDrr0 = 554,

        BLENDVPSrm0 = 555,

        BLENDVPSrr0 = 556,

        BLSFILL32rm = 557,

        BLSFILL32rr = 558,

        BLSFILL64rm = 559,

        BLSFILL64rr = 560,

        BLSI32rm = 561,

        BLSI32rr = 562,

        BLSI64rm = 563,

        BLSI64rr = 564,

        BLSIC32rm = 565,

        BLSIC32rr = 566,

        BLSIC64rm = 567,

        BLSIC64rr = 568,

        BLSMSK32rm = 569,

        BLSMSK32rr = 570,

        BLSMSK64rm = 571,

        BLSMSK64rr = 572,

        BLSR32rm = 573,

        BLSR32rr = 574,

        BLSR64rm = 575,

        BLSR64rr = 576,

        BNDCL32rm = 577,

        BNDCL32rr = 578,

        BNDCL64rm = 579,

        BNDCL64rr = 580,

        BNDCN32rm = 581,

        BNDCN32rr = 582,

        BNDCN64rm = 583,

        BNDCN64rr = 584,

        BNDCU32rm = 585,

        BNDCU32rr = 586,

        BNDCU64rm = 587,

        BNDCU64rr = 588,

        BNDLDXrm = 589,

        BNDMK32rm = 590,

        BNDMK64rm = 591,

        BNDMOV32mr = 592,

        BNDMOV32rm = 593,

        BNDMOV64mr = 594,

        BNDMOV64rm = 595,

        BNDMOVrr = 596,

        BNDMOVrr_REV = 597,

        BNDSTXmr = 598,

        BOUNDS16rm = 599,

        BOUNDS32rm = 600,

        BSF16rm = 601,

        BSF16rr = 602,

        BSF32rm = 603,

        BSF32rr = 604,

        BSF64rm = 605,

        BSF64rr = 606,

        BSR16rm = 607,

        BSR16rr = 608,

        BSR32rm = 609,

        BSR32rr = 610,

        BSR64rm = 611,

        BSR64rr = 612,

        BSWAP16r_BAD = 613,

        BSWAP32r = 614,

        BSWAP64r = 615,

        BT16mi8 = 616,

        BT16mr = 617,

        BT16ri8 = 618,

        BT16rr = 619,

        BT32mi8 = 620,

        BT32mr = 621,

        BT32ri8 = 622,

        BT32rr = 623,

        BT64mi8 = 624,

        BT64mr = 625,

        BT64ri8 = 626,

        BT64rr = 627,

        BTC16mi8 = 628,

        BTC16mr = 629,

        BTC16ri8 = 630,

        BTC16rr = 631,

        BTC32mi8 = 632,

        BTC32mr = 633,

        BTC32ri8 = 634,

        BTC32rr = 635,

        BTC64mi8 = 636,

        BTC64mr = 637,

        BTC64ri8 = 638,

        BTC64rr = 639,

        BTR16mi8 = 640,

        BTR16mr = 641,

        BTR16ri8 = 642,

        BTR16rr = 643,

        BTR32mi8 = 644,

        BTR32mr = 645,

        BTR32ri8 = 646,

        BTR32rr = 647,

        BTR64mi8 = 648,

        BTR64mr = 649,

        BTR64ri8 = 650,

        BTR64rr = 651,

        BTS16mi8 = 652,

        BTS16mr = 653,

        BTS16ri8 = 654,

        BTS16rr = 655,

        BTS32mi8 = 656,

        BTS32mr = 657,

        BTS32ri8 = 658,

        BTS32rr = 659,

        BTS64mi8 = 660,

        BTS64mr = 661,

        BTS64ri8 = 662,

        BTS64rr = 663,

        BZHI32rm = 664,

        BZHI32rr = 665,

        BZHI64rm = 666,

        BZHI64rr = 667,

        CALL16m = 668,

        CALL16m_NT = 669,

        CALL16r = 670,

        CALL16r_NT = 671,

        CALL32m = 672,

        CALL32m_NT = 673,

        CALL32r = 674,

        CALL32r_NT = 675,

        CALL64m = 676,

        CALL64m_NT = 677,

        CALL64pcrel32 = 678,

        CALL64r = 679,

        CALL64r_NT = 680,

        CALLpcrel16 = 681,

        CALLpcrel32 = 682,

        CATCHRET = 683,

        CBW = 684,

        CDQ = 685,

        CDQE = 686,

        CHS_F = 687,

        CHS_Fp32 = 688,

        CHS_Fp64 = 689,

        CHS_Fp80 = 690,

        CLAC = 691,

        CLC = 692,

        CLD = 693,

        CLDEMOTE = 694,

        CLEANUPRET = 695,

        CLFLUSH = 696,

        CLFLUSHOPT = 697,

        CLGI = 698,

        CLI = 699,

        CLRSSBSY = 700,

        CLTS = 701,

        CLUI = 702,

        CLWB = 703,

        CLZERO32r = 704,

        CLZERO64r = 705,

        CMC = 706,

        CMOV16rm = 707,

        CMOV16rr = 708,

        CMOV32rm = 709,

        CMOV32rr = 710,

        CMOV64rm = 711,

        CMOV64rr = 712,

        CMOVBE_F = 713,

        CMOVBE_Fp32 = 714,

        CMOVBE_Fp64 = 715,

        CMOVBE_Fp80 = 716,

        CMOVB_F = 717,

        CMOVB_Fp32 = 718,

        CMOVB_Fp64 = 719,

        CMOVB_Fp80 = 720,

        CMOVE_F = 721,

        CMOVE_Fp32 = 722,

        CMOVE_Fp64 = 723,

        CMOVE_Fp80 = 724,

        CMOVNBE_F = 725,

        CMOVNBE_Fp32 = 726,

        CMOVNBE_Fp64 = 727,

        CMOVNBE_Fp80 = 728,

        CMOVNB_F = 729,

        CMOVNB_Fp32 = 730,

        CMOVNB_Fp64 = 731,

        CMOVNB_Fp80 = 732,

        CMOVNE_F = 733,

        CMOVNE_Fp32 = 734,

        CMOVNE_Fp64 = 735,

        CMOVNE_Fp80 = 736,

        CMOVNP_F = 737,

        CMOVNP_Fp32 = 738,

        CMOVNP_Fp64 = 739,

        CMOVNP_Fp80 = 740,

        CMOVP_F = 741,

        CMOVP_Fp32 = 742,

        CMOVP_Fp64 = 743,

        CMOVP_Fp80 = 744,

        CMOV_FR32 = 745,

        CMOV_FR32X = 746,

        CMOV_FR64 = 747,

        CMOV_FR64X = 748,

        CMOV_GR16 = 749,

        CMOV_GR32 = 750,

        CMOV_GR8 = 751,

        CMOV_RFP32 = 752,

        CMOV_RFP64 = 753,

        CMOV_RFP80 = 754,

        CMOV_VK1 = 755,

        CMOV_VK16 = 756,

        CMOV_VK2 = 757,

        CMOV_VK32 = 758,

        CMOV_VK4 = 759,

        CMOV_VK64 = 760,

        CMOV_VK8 = 761,

        CMOV_VR128 = 762,

        CMOV_VR128X = 763,

        CMOV_VR256 = 764,

        CMOV_VR256X = 765,

        CMOV_VR512 = 766,

        CMOV_VR64 = 767,

        CMP16i16 = 768,

        CMP16mi = 769,

        CMP16mi8 = 770,

        CMP16mr = 771,

        CMP16ri = 772,

        CMP16ri8 = 773,

        CMP16rm = 774,

        CMP16rr = 775,

        CMP16rr_REV = 776,

        CMP32i32 = 777,

        CMP32mi = 778,

        CMP32mi8 = 779,

        CMP32mr = 780,

        CMP32ri = 781,

        CMP32ri8 = 782,

        CMP32rm = 783,

        CMP32rr = 784,

        CMP32rr_REV = 785,

        CMP64i32 = 786,

        CMP64mi32 = 787,

        CMP64mi8 = 788,

        CMP64mr = 789,

        CMP64ri32 = 790,

        CMP64ri8 = 791,

        CMP64rm = 792,

        CMP64rr = 793,

        CMP64rr_REV = 794,

        CMP8i8 = 795,

        CMP8mi = 796,

        CMP8mi8 = 797,

        CMP8mr = 798,

        CMP8ri = 799,

        CMP8ri8 = 800,

        CMP8rm = 801,

        CMP8rr = 802,

        CMP8rr_REV = 803,

        CMPPDrmi = 804,

        CMPPDrri = 805,

        CMPPSrmi = 806,

        CMPPSrri = 807,

        CMPSB = 808,

        CMPSDrm = 809,

        CMPSDrm_Int = 810,

        CMPSDrr = 811,

        CMPSDrr_Int = 812,

        CMPSL = 813,

        CMPSQ = 814,

        CMPSSrm = 815,

        CMPSSrm_Int = 816,

        CMPSSrr = 817,

        CMPSSrr_Int = 818,

        CMPSW = 819,

        CMPXCHG16B = 820,

        CMPXCHG16rm = 821,

        CMPXCHG16rr = 822,

        CMPXCHG32rm = 823,

        CMPXCHG32rr = 824,

        CMPXCHG64rm = 825,

        CMPXCHG64rr = 826,

        CMPXCHG8B = 827,

        CMPXCHG8rm = 828,

        CMPXCHG8rr = 829,

        COMISDrm = 830,

        COMISDrm_Int = 831,

        COMISDrr = 832,

        COMISDrr_Int = 833,

        COMISSrm = 834,

        COMISSrm_Int = 835,

        COMISSrr = 836,

        COMISSrr_Int = 837,

        COMP_FST0r = 838,

        COM_FIPr = 839,

        COM_FIr = 840,

        COM_FST0r = 841,

        COM_FpIr32 = 842,

        COM_FpIr64 = 843,

        COM_FpIr80 = 844,

        COM_Fpr32 = 845,

        COM_Fpr64 = 846,

        COM_Fpr80 = 847,

        CPUID = 848,

        CQO = 849,

        CRC32r32m16 = 850,

        CRC32r32m32 = 851,

        CRC32r32m8 = 852,

        CRC32r32r16 = 853,

        CRC32r32r32 = 854,

        CRC32r32r8 = 855,

        CRC32r64m64 = 856,

        CRC32r64m8 = 857,

        CRC32r64r64 = 858,

        CRC32r64r8 = 859,

        CS_PREFIX = 860,

        CVTDQ2PDrm = 861,

        CVTDQ2PDrr = 862,

        CVTDQ2PSrm = 863,

        CVTDQ2PSrr = 864,

        CVTPD2DQrm = 865,

        CVTPD2DQrr = 866,

        CVTPD2PSrm = 867,

        CVTPD2PSrr = 868,

        CVTPS2DQrm = 869,

        CVTPS2DQrr = 870,

        CVTPS2PDrm = 871,

        CVTPS2PDrr = 872,

        CVTSD2SI64rm = 873,

        CVTSD2SI64rm_Int = 874,

        CVTSD2SI64rr = 875,

        CVTSD2SI64rr_Int = 876,

        CVTSD2SIrm = 877,

        CVTSD2SIrm_Int = 878,

        CVTSD2SIrr = 879,

        CVTSD2SIrr_Int = 880,

        CVTSD2SSrm = 881,

        CVTSD2SSrm_Int = 882,

        CVTSD2SSrr = 883,

        CVTSD2SSrr_Int = 884,

        CVTSI2SDrm = 885,

        CVTSI2SDrm_Int = 886,

        CVTSI2SDrr = 887,

        CVTSI2SDrr_Int = 888,

        CVTSI2SSrm = 889,

        CVTSI2SSrm_Int = 890,

        CVTSI2SSrr = 891,

        CVTSI2SSrr_Int = 892,

        CVTSI642SDrm = 893,

        CVTSI642SDrm_Int = 894,

        CVTSI642SDrr = 895,

        CVTSI642SDrr_Int = 896,

        CVTSI642SSrm = 897,

        CVTSI642SSrm_Int = 898,

        CVTSI642SSrr = 899,

        CVTSI642SSrr_Int = 900,

        CVTSS2SDrm = 901,

        CVTSS2SDrm_Int = 902,

        CVTSS2SDrr = 903,

        CVTSS2SDrr_Int = 904,

        CVTSS2SI64rm = 905,

        CVTSS2SI64rm_Int = 906,

        CVTSS2SI64rr = 907,

        CVTSS2SI64rr_Int = 908,

        CVTSS2SIrm = 909,

        CVTSS2SIrm_Int = 910,

        CVTSS2SIrr = 911,

        CVTSS2SIrr_Int = 912,

        CVTTPD2DQrm = 913,

        CVTTPD2DQrr = 914,

        CVTTPS2DQrm = 915,

        CVTTPS2DQrr = 916,

        CVTTSD2SI64rm = 917,

        CVTTSD2SI64rm_Int = 918,

        CVTTSD2SI64rr = 919,

        CVTTSD2SI64rr_Int = 920,

        CVTTSD2SIrm = 921,

        CVTTSD2SIrm_Int = 922,

        CVTTSD2SIrr = 923,

        CVTTSD2SIrr_Int = 924,

        CVTTSS2SI64rm = 925,

        CVTTSS2SI64rm_Int = 926,

        CVTTSS2SI64rr = 927,

        CVTTSS2SI64rr_Int = 928,

        CVTTSS2SIrm = 929,

        CVTTSS2SIrm_Int = 930,

        CVTTSS2SIrr = 931,

        CVTTSS2SIrr_Int = 932,

        CWD = 933,

        CWDE = 934,

        DAA = 935,

        DAS = 936,

        DATA16_PREFIX = 937,

        DEC16m = 938,

        DEC16r = 939,

        DEC16r_alt = 940,

        DEC32m = 941,

        DEC32r = 942,

        DEC32r_alt = 943,

        DEC64m = 944,

        DEC64r = 945,

        DEC8m = 946,

        DEC8r = 947,

        DIV16m = 948,

        DIV16r = 949,

        DIV32m = 950,

        DIV32r = 951,

        DIV64m = 952,

        DIV64r = 953,

        DIV8m = 954,

        DIV8r = 955,

        DIVPDrm = 956,

        DIVPDrr = 957,

        DIVPSrm = 958,

        DIVPSrr = 959,

        DIVR_F32m = 960,

        DIVR_F64m = 961,

        DIVR_FI16m = 962,

        DIVR_FI32m = 963,

        DIVR_FPrST0 = 964,

        DIVR_FST0r = 965,

        DIVR_Fp32m = 966,

        DIVR_Fp64m = 967,

        DIVR_Fp64m32 = 968,

        DIVR_Fp80m32 = 969,

        DIVR_Fp80m64 = 970,

        DIVR_FpI16m32 = 971,

        DIVR_FpI16m64 = 972,

        DIVR_FpI16m80 = 973,

        DIVR_FpI32m32 = 974,

        DIVR_FpI32m64 = 975,

        DIVR_FpI32m80 = 976,

        DIVR_FrST0 = 977,

        DIVSDrm = 978,

        DIVSDrm_Int = 979,

        DIVSDrr = 980,

        DIVSDrr_Int = 981,

        DIVSSrm = 982,

        DIVSSrm_Int = 983,

        DIVSSrr = 984,

        DIVSSrr_Int = 985,

        DIV_F32m = 986,

        DIV_F64m = 987,

        DIV_FI16m = 988,

        DIV_FI32m = 989,

        DIV_FPrST0 = 990,

        DIV_FST0r = 991,

        DIV_Fp32 = 992,

        DIV_Fp32m = 993,

        DIV_Fp64 = 994,

        DIV_Fp64m = 995,

        DIV_Fp64m32 = 996,

        DIV_Fp80 = 997,

        DIV_Fp80m32 = 998,

        DIV_Fp80m64 = 999,

        DIV_FpI16m32 = 1000,

        DIV_FpI16m64 = 1001,

        DIV_FpI16m80 = 1002,

        DIV_FpI32m32 = 1003,

        DIV_FpI32m64 = 1004,

        DIV_FpI32m80 = 1005,

        DIV_FrST0 = 1006,

        DPPDrmi = 1007,

        DPPDrri = 1008,

        DPPSrmi = 1009,

        DPPSrri = 1010,

        DS_PREFIX = 1011,

        EH_RETURN = 1012,

        EH_RETURN64 = 1013,

        EH_SjLj_LongJmp32 = 1014,

        EH_SjLj_LongJmp64 = 1015,

        EH_SjLj_SetJmp32 = 1016,

        EH_SjLj_SetJmp64 = 1017,

        EH_SjLj_Setup = 1018,

        ENCLS = 1019,

        ENCLU = 1020,

        ENCLV = 1021,

        ENCODEKEY128 = 1022,

        ENCODEKEY256 = 1023,

        ENDBR32 = 1024,

        ENDBR64 = 1025,

        ENQCMD16 = 1026,

        ENQCMD32 = 1027,

        ENQCMD64 = 1028,

        ENQCMDS16 = 1029,

        ENQCMDS32 = 1030,

        ENQCMDS64 = 1031,

        ENTER = 1032,

        ES_PREFIX = 1033,

        EXTRACTPSmr = 1034,

        EXTRACTPSrr = 1035,

        EXTRQ = 1036,

        EXTRQI = 1037,

        F2XM1 = 1038,

        FARCALL16i = 1039,

        FARCALL16m = 1040,

        FARCALL32i = 1041,

        FARCALL32m = 1042,

        FARCALL64m = 1043,

        FARJMP16i = 1044,

        FARJMP16m = 1045,

        FARJMP32i = 1046,

        FARJMP32m = 1047,

        FARJMP64m = 1048,

        FBLDm = 1049,

        FBSTPm = 1050,

        FCOM32m = 1051,

        FCOM64m = 1052,

        FCOMP32m = 1053,

        FCOMP64m = 1054,

        FCOMPP = 1055,

        FCOS = 1056,

        FDECSTP = 1057,

        FEMMS = 1058,

        FFREE = 1059,

        FFREEP = 1060,

        FICOM16m = 1061,

        FICOM32m = 1062,

        FICOMP16m = 1063,

        FICOMP32m = 1064,

        FINCSTP = 1065,

        FLDCW16m = 1066,

        FLDENVm = 1067,

        FLDL2E = 1068,

        FLDL2T = 1069,

        FLDLG2 = 1070,

        FLDLN2 = 1071,

        FLDPI = 1072,

        FNCLEX = 1073,

        FNINIT = 1074,

        FNOP = 1075,

        FNSTCW16m = 1076,

        FNSTSW16r = 1077,

        FNSTSWm = 1078,

        FP32_TO_INT16_IN_MEM = 1079,

        FP32_TO_INT32_IN_MEM = 1080,

        FP32_TO_INT64_IN_MEM = 1081,

        FP64_TO_INT16_IN_MEM = 1082,

        FP64_TO_INT32_IN_MEM = 1083,

        FP64_TO_INT64_IN_MEM = 1084,

        FP80_TO_INT16_IN_MEM = 1085,

        FP80_TO_INT32_IN_MEM = 1086,

        FP80_TO_INT64_IN_MEM = 1087,

        FPATAN = 1088,

        FPREM = 1089,

        FPREM1 = 1090,

        FPTAN = 1091,

        FRNDINT = 1092,

        FRSTORm = 1093,

        FSAVEm = 1094,

        FSCALE = 1095,

        FSIN = 1096,

        FSINCOS = 1097,

        FSTENVm = 1098,

        FS_PREFIX = 1099,

        FXRSTOR = 1100,

        FXRSTOR64 = 1101,

        FXSAVE = 1102,

        FXSAVE64 = 1103,

        FXTRACT = 1104,

        FYL2X = 1105,

        FYL2XP1 = 1106,

        GETSEC = 1107,

        GF2P8AFFINEINVQBrmi = 1108,

        GF2P8AFFINEINVQBrri = 1109,

        GF2P8AFFINEQBrmi = 1110,

        GF2P8AFFINEQBrri = 1111,

        GF2P8MULBrm = 1112,

        GF2P8MULBrr = 1113,

        GS_PREFIX = 1114,

        HADDPDrm = 1115,

        HADDPDrr = 1116,

        HADDPSrm = 1117,

        HADDPSrr = 1118,

        HLT = 1119,

        HRESET = 1120,

        HSUBPDrm = 1121,

        HSUBPDrr = 1122,

        HSUBPSrm = 1123,

        HSUBPSrr = 1124,

        IDIV16m = 1125,

        IDIV16r = 1126,

        IDIV32m = 1127,

        IDIV32r = 1128,

        IDIV64m = 1129,

        IDIV64r = 1130,

        IDIV8m = 1131,

        IDIV8r = 1132,

        ILD_F16m = 1133,

        ILD_F32m = 1134,

        ILD_F64m = 1135,

        ILD_Fp16m32 = 1136,

        ILD_Fp16m64 = 1137,

        ILD_Fp16m80 = 1138,

        ILD_Fp32m32 = 1139,

        ILD_Fp32m64 = 1140,

        ILD_Fp32m80 = 1141,

        ILD_Fp64m32 = 1142,

        ILD_Fp64m64 = 1143,

        ILD_Fp64m80 = 1144,

        IMUL16m = 1145,

        IMUL16r = 1146,

        IMUL16rm = 1147,

        IMUL16rmi = 1148,

        IMUL16rmi8 = 1149,

        IMUL16rr = 1150,

        IMUL16rri = 1151,

        IMUL16rri8 = 1152,

        IMUL32m = 1153,

        IMUL32r = 1154,

        IMUL32rm = 1155,

        IMUL32rmi = 1156,

        IMUL32rmi8 = 1157,

        IMUL32rr = 1158,

        IMUL32rri = 1159,

        IMUL32rri8 = 1160,

        IMUL64m = 1161,

        IMUL64r = 1162,

        IMUL64rm = 1163,

        IMUL64rmi32 = 1164,

        IMUL64rmi8 = 1165,

        IMUL64rr = 1166,

        IMUL64rri32 = 1167,

        IMUL64rri8 = 1168,

        IMUL8m = 1169,

        IMUL8r = 1170,

        IN16ri = 1171,

        IN16rr = 1172,

        IN32ri = 1173,

        IN32rr = 1174,

        IN8ri = 1175,

        IN8rr = 1176,

        INC16m = 1177,

        INC16r = 1178,

        INC16r_alt = 1179,

        INC32m = 1180,

        INC32r = 1181,

        INC32r_alt = 1182,

        INC64m = 1183,

        INC64r = 1184,

        INC8m = 1185,

        INC8r = 1186,

        INCSSPD = 1187,

        INCSSPQ = 1188,

        INSB = 1189,

        INSERTPSrm = 1190,

        INSERTPSrr = 1191,

        INSERTQ = 1192,

        INSERTQI = 1193,

        INSL = 1194,

        INSW = 1195,

        INT = 1196,

        INT3 = 1197,

        INTO = 1198,

        INVD = 1199,

        INVEPT32 = 1200,

        INVEPT64 = 1201,

        INVLPG = 1202,

        INVLPGA32 = 1203,

        INVLPGA64 = 1204,

        INVLPGB32 = 1205,

        INVLPGB64 = 1206,

        INVPCID32 = 1207,

        INVPCID64 = 1208,

        INVVPID32 = 1209,

        INVVPID64 = 1210,

        IRET = 1211,

        IRET16 = 1212,

        IRET32 = 1213,

        IRET64 = 1214,

        ISTT_FP16m = 1215,

        ISTT_FP32m = 1216,

        ISTT_FP64m = 1217,

        ISTT_Fp16m32 = 1218,

        ISTT_Fp16m64 = 1219,

        ISTT_Fp16m80 = 1220,

        ISTT_Fp32m32 = 1221,

        ISTT_Fp32m64 = 1222,

        ISTT_Fp32m80 = 1223,

        ISTT_Fp64m32 = 1224,

        ISTT_Fp64m64 = 1225,

        ISTT_Fp64m80 = 1226,

        IST_F16m = 1227,

        IST_F32m = 1228,

        IST_FP16m = 1229,

        IST_FP32m = 1230,

        IST_FP64m = 1231,

        IST_Fp16m32 = 1232,

        IST_Fp16m64 = 1233,

        IST_Fp16m80 = 1234,

        IST_Fp32m32 = 1235,

        IST_Fp32m64 = 1236,

        IST_Fp32m80 = 1237,

        IST_Fp64m32 = 1238,

        IST_Fp64m64 = 1239,

        IST_Fp64m80 = 1240,

        Int_MemBarrier = 1241,

        Int_eh_sjlj_setup_dispatch = 1242,

        JCC_1 = 1243,

        JCC_2 = 1244,

        JCC_4 = 1245,

        JCXZ = 1246,

        JECXZ = 1247,

        JMP16m = 1248,

        JMP16m_NT = 1249,

        JMP16r = 1250,

        JMP16r_NT = 1251,

        JMP32m = 1252,

        JMP32m_NT = 1253,

        JMP32r = 1254,

        JMP32r_NT = 1255,

        JMP64m = 1256,

        JMP64m_NT = 1257,

        JMP64m_REX = 1258,

        JMP64r = 1259,

        JMP64r_NT = 1260,

        JMP64r_REX = 1261,

        JMP_1 = 1262,

        JMP_2 = 1263,

        JMP_4 = 1264,

        JRCXZ = 1265,

        KADDBrr = 1266,

        KADDDrr = 1267,

        KADDQrr = 1268,

        KADDWrr = 1269,

        KANDBrr = 1270,

        KANDDrr = 1271,

        KANDNBrr = 1272,

        KANDNDrr = 1273,

        KANDNQrr = 1274,

        KANDNWrr = 1275,

        KANDQrr = 1276,

        KANDWrr = 1277,

        KMOVBkk = 1278,

        KMOVBkm = 1279,

        KMOVBkr = 1280,

        KMOVBmk = 1281,

        KMOVBrk = 1282,

        KMOVDkk = 1283,

        KMOVDkm = 1284,

        KMOVDkr = 1285,

        KMOVDmk = 1286,

        KMOVDrk = 1287,

        KMOVQkk = 1288,

        KMOVQkm = 1289,

        KMOVQkr = 1290,

        KMOVQmk = 1291,

        KMOVQrk = 1292,

        KMOVWkk = 1293,

        KMOVWkm = 1294,

        KMOVWkr = 1295,

        KMOVWmk = 1296,

        KMOVWrk = 1297,

        KNOTBrr = 1298,

        KNOTDrr = 1299,

        KNOTQrr = 1300,

        KNOTWrr = 1301,

        KORBrr = 1302,

        KORDrr = 1303,

        KORQrr = 1304,

        KORTESTBrr = 1305,

        KORTESTDrr = 1306,

        KORTESTQrr = 1307,

        KORTESTWrr = 1308,

        KORWrr = 1309,

        KSHIFTLBri = 1310,

        KSHIFTLDri = 1311,

        KSHIFTLQri = 1312,

        KSHIFTLWri = 1313,

        KSHIFTRBri = 1314,

        KSHIFTRDri = 1315,

        KSHIFTRQri = 1316,

        KSHIFTRWri = 1317,

        KTESTBrr = 1318,

        KTESTDrr = 1319,

        KTESTQrr = 1320,

        KTESTWrr = 1321,

        KUNPCKBWrr = 1322,

        KUNPCKDQrr = 1323,

        KUNPCKWDrr = 1324,

        KXNORBrr = 1325,

        KXNORDrr = 1326,

        KXNORQrr = 1327,

        KXNORWrr = 1328,

        KXORBrr = 1329,

        KXORDrr = 1330,

        KXORQrr = 1331,

        KXORWrr = 1332,

        LAHF = 1333,

        LAR16rm = 1334,

        LAR16rr = 1335,

        LAR32rm = 1336,

        LAR32rr = 1337,

        LAR64rm = 1338,

        LAR64rr = 1339,

        LCMPXCHG16 = 1340,

        LCMPXCHG16B = 1341,

        LCMPXCHG32 = 1342,

        LCMPXCHG64 = 1343,

        LCMPXCHG8 = 1344,

        LCMPXCHG8B = 1345,

        LDDQUrm = 1346,

        LDMXCSR = 1347,

        LDS16rm = 1348,

        LDS32rm = 1349,

        LDTILECFG = 1350,

        LD_F0 = 1351,

        LD_F1 = 1352,

        LD_F32m = 1353,

        LD_F64m = 1354,

        LD_F80m = 1355,

        LD_Fp032 = 1356,

        LD_Fp064 = 1357,

        LD_Fp080 = 1358,

        LD_Fp132 = 1359,

        LD_Fp164 = 1360,

        LD_Fp180 = 1361,

        LD_Fp32m = 1362,

        LD_Fp32m64 = 1363,

        LD_Fp32m80 = 1364,

        LD_Fp64m = 1365,

        LD_Fp64m80 = 1366,

        LD_Fp80m = 1367,

        LD_Frr = 1368,

        LEA16r = 1369,

        LEA32r = 1370,

        LEA64_32r = 1371,

        LEA64r = 1372,

        LEAVE = 1373,

        LEAVE64 = 1374,

        LES16rm = 1375,

        LES32rm = 1376,

        LFENCE = 1377,

        LFS16rm = 1378,

        LFS32rm = 1379,

        LFS64rm = 1380,

        LGDT16m = 1381,

        LGDT32m = 1382,

        LGDT64m = 1383,

        LGS16rm = 1384,

        LGS32rm = 1385,

        LGS64rm = 1386,

        LIDT16m = 1387,

        LIDT32m = 1388,

        LIDT64m = 1389,

        LLDT16m = 1390,

        LLDT16r = 1391,

        LLWPCB = 1392,

        LLWPCB64 = 1393,

        LMSW16m = 1394,

        LMSW16r = 1395,

        LOADIWKEY = 1396,

        LOCK_ADD16mi = 1397,

        LOCK_ADD16mi8 = 1398,

        LOCK_ADD16mr = 1399,

        LOCK_ADD32mi = 1400,

        LOCK_ADD32mi8 = 1401,

        LOCK_ADD32mr = 1402,

        LOCK_ADD64mi32 = 1403,

        LOCK_ADD64mi8 = 1404,

        LOCK_ADD64mr = 1405,

        LOCK_ADD8mi = 1406,

        LOCK_ADD8mr = 1407,

        LOCK_AND16mi = 1408,

        LOCK_AND16mi8 = 1409,

        LOCK_AND16mr = 1410,

        LOCK_AND32mi = 1411,

        LOCK_AND32mi8 = 1412,

        LOCK_AND32mr = 1413,

        LOCK_AND64mi32 = 1414,

        LOCK_AND64mi8 = 1415,

        LOCK_AND64mr = 1416,

        LOCK_AND8mi = 1417,

        LOCK_AND8mr = 1418,

        LOCK_DEC16m = 1419,

        LOCK_DEC32m = 1420,

        LOCK_DEC64m = 1421,

        LOCK_DEC8m = 1422,

        LOCK_INC16m = 1423,

        LOCK_INC32m = 1424,

        LOCK_INC64m = 1425,

        LOCK_INC8m = 1426,

        LOCK_OR16mi = 1427,

        LOCK_OR16mi8 = 1428,

        LOCK_OR16mr = 1429,

        LOCK_OR32mi = 1430,

        LOCK_OR32mi8 = 1431,

        LOCK_OR32mr = 1432,

        LOCK_OR64mi32 = 1433,

        LOCK_OR64mi8 = 1434,

        LOCK_OR64mr = 1435,

        LOCK_OR8mi = 1436,

        LOCK_OR8mr = 1437,

        LOCK_PREFIX = 1438,

        LOCK_SUB16mi = 1439,

        LOCK_SUB16mi8 = 1440,

        LOCK_SUB16mr = 1441,

        LOCK_SUB32mi = 1442,

        LOCK_SUB32mi8 = 1443,

        LOCK_SUB32mr = 1444,

        LOCK_SUB64mi32 = 1445,

        LOCK_SUB64mi8 = 1446,

        LOCK_SUB64mr = 1447,

        LOCK_SUB8mi = 1448,

        LOCK_SUB8mr = 1449,

        LOCK_XOR16mi = 1450,

        LOCK_XOR16mi8 = 1451,

        LOCK_XOR16mr = 1452,

        LOCK_XOR32mi = 1453,

        LOCK_XOR32mi8 = 1454,

        LOCK_XOR32mr = 1455,

        LOCK_XOR64mi32 = 1456,

        LOCK_XOR64mi8 = 1457,

        LOCK_XOR64mr = 1458,

        LOCK_XOR8mi = 1459,

        LOCK_XOR8mr = 1460,

        LODSB = 1461,

        LODSL = 1462,

        LODSQ = 1463,

        LODSW = 1464,

        LOOP = 1465,

        LOOPE = 1466,

        LOOPNE = 1467,

        LRETIL = 1468,

        LRETIQ = 1469,

        LRETIW = 1470,

        LRETL = 1471,

        LRETQ = 1472,

        LRETW = 1473,

        LSL16rm = 1474,

        LSL16rr = 1475,

        LSL32rm = 1476,

        LSL32rr = 1477,

        LSL64rm = 1478,

        LSL64rr = 1479,

        LSS16rm = 1480,

        LSS32rm = 1481,

        LSS64rm = 1482,

        LTRm = 1483,

        LTRr = 1484,

        LWPINS32rmi = 1485,

        LWPINS32rri = 1486,

        LWPINS64rmi = 1487,

        LWPINS64rri = 1488,

        LWPVAL32rmi = 1489,

        LWPVAL32rri = 1490,

        LWPVAL64rmi = 1491,

        LWPVAL64rri = 1492,

        LXADD16 = 1493,

        LXADD32 = 1494,

        LXADD64 = 1495,

        LXADD8 = 1496,

        LZCNT16rm = 1497,

        LZCNT16rr = 1498,

        LZCNT32rm = 1499,

        LZCNT32rr = 1500,

        LZCNT64rm = 1501,

        LZCNT64rr = 1502,

        MASKMOVDQU = 1503,

        MASKMOVDQU64 = 1504,

        MASKMOVDQUX32 = 1505,

        MASKPAIR16LOAD = 1506,

        MASKPAIR16STORE = 1507,

        MAXCPDrm = 1508,

        MAXCPDrr = 1509,

        MAXCPSrm = 1510,

        MAXCPSrr = 1511,

        MAXCSDrm = 1512,

        MAXCSDrr = 1513,

        MAXCSSrm = 1514,

        MAXCSSrr = 1515,

        MAXPDrm = 1516,

        MAXPDrr = 1517,

        MAXPSrm = 1518,

        MAXPSrr = 1519,

        MAXSDrm = 1520,

        MAXSDrm_Int = 1521,

        MAXSDrr = 1522,

        MAXSDrr_Int = 1523,

        MAXSSrm = 1524,

        MAXSSrm_Int = 1525,

        MAXSSrr = 1526,

        MAXSSrr_Int = 1527,

        MFENCE = 1528,

        MINCPDrm = 1529,

        MINCPDrr = 1530,

        MINCPSrm = 1531,

        MINCPSrr = 1532,

        MINCSDrm = 1533,

        MINCSDrr = 1534,

        MINCSSrm = 1535,

        MINCSSrr = 1536,

        MINPDrm = 1537,

        MINPDrr = 1538,

        MINPSrm = 1539,

        MINPSrr = 1540,

        MINSDrm = 1541,

        MINSDrm_Int = 1542,

        MINSDrr = 1543,

        MINSDrr_Int = 1544,

        MINSSrm = 1545,

        MINSSrm_Int = 1546,

        MINSSrr = 1547,

        MINSSrr_Int = 1548,

        MMX_CVTPD2PIirm = 1549,

        MMX_CVTPD2PIirr = 1550,

        MMX_CVTPI2PDirm = 1551,

        MMX_CVTPI2PDirr = 1552,

        MMX_CVTPI2PSirm = 1553,

        MMX_CVTPI2PSirr = 1554,

        MMX_CVTPS2PIirm = 1555,

        MMX_CVTPS2PIirr = 1556,

        MMX_CVTTPD2PIirm = 1557,

        MMX_CVTTPD2PIirr = 1558,

        MMX_CVTTPS2PIirm = 1559,

        MMX_CVTTPS2PIirr = 1560,

        MMX_EMMS = 1561,

        MMX_MASKMOVQ = 1562,

        MMX_MASKMOVQ64 = 1563,

        MMX_MOVD64from64rm = 1564,

        MMX_MOVD64from64rr = 1565,

        MMX_MOVD64grr = 1566,

        MMX_MOVD64mr = 1567,

        MMX_MOVD64rm = 1568,

        MMX_MOVD64rr = 1569,

        MMX_MOVD64to64rm = 1570,

        MMX_MOVD64to64rr = 1571,

        MMX_MOVDQ2Qrr = 1572,

        MMX_MOVFR642Qrr = 1573,

        MMX_MOVNTQmr = 1574,

        MMX_MOVQ2DQrr = 1575,

        MMX_MOVQ2FR64rr = 1576,

        MMX_MOVQ64mr = 1577,

        MMX_MOVQ64rm = 1578,

        MMX_MOVQ64rr = 1579,

        MMX_MOVQ64rr_REV = 1580,

        MMX_PABSBrm = 1581,

        MMX_PABSBrr = 1582,

        MMX_PABSDrm = 1583,

        MMX_PABSDrr = 1584,

        MMX_PABSWrm = 1585,

        MMX_PABSWrr = 1586,

        MMX_PACKSSDWirm = 1587,

        MMX_PACKSSDWirr = 1588,

        MMX_PACKSSWBirm = 1589,

        MMX_PACKSSWBirr = 1590,

        MMX_PACKUSWBirm = 1591,

        MMX_PACKUSWBirr = 1592,

        MMX_PADDBirm = 1593,

        MMX_PADDBirr = 1594,

        MMX_PADDDirm = 1595,

        MMX_PADDDirr = 1596,

        MMX_PADDQirm = 1597,

        MMX_PADDQirr = 1598,

        MMX_PADDSBirm = 1599,

        MMX_PADDSBirr = 1600,

        MMX_PADDSWirm = 1601,

        MMX_PADDSWirr = 1602,

        MMX_PADDUSBirm = 1603,

        MMX_PADDUSBirr = 1604,

        MMX_PADDUSWirm = 1605,

        MMX_PADDUSWirr = 1606,

        MMX_PADDWirm = 1607,

        MMX_PADDWirr = 1608,

        MMX_PALIGNRrmi = 1609,

        MMX_PALIGNRrri = 1610,

        MMX_PANDNirm = 1611,

        MMX_PANDNirr = 1612,

        MMX_PANDirm = 1613,

        MMX_PANDirr = 1614,

        MMX_PAVGBirm = 1615,

        MMX_PAVGBirr = 1616,

        MMX_PAVGWirm = 1617,

        MMX_PAVGWirr = 1618,

        MMX_PCMPEQBirm = 1619,

        MMX_PCMPEQBirr = 1620,

        MMX_PCMPEQDirm = 1621,

        MMX_PCMPEQDirr = 1622,

        MMX_PCMPEQWirm = 1623,

        MMX_PCMPEQWirr = 1624,

        MMX_PCMPGTBirm = 1625,

        MMX_PCMPGTBirr = 1626,

        MMX_PCMPGTDirm = 1627,

        MMX_PCMPGTDirr = 1628,

        MMX_PCMPGTWirm = 1629,

        MMX_PCMPGTWirr = 1630,

        MMX_PEXTRWrr = 1631,

        MMX_PHADDDrm = 1632,

        MMX_PHADDDrr = 1633,

        MMX_PHADDSWrm = 1634,

        MMX_PHADDSWrr = 1635,

        MMX_PHADDWrm = 1636,

        MMX_PHADDWrr = 1637,

        MMX_PHSUBDrm = 1638,

        MMX_PHSUBDrr = 1639,

        MMX_PHSUBSWrm = 1640,

        MMX_PHSUBSWrr = 1641,

        MMX_PHSUBWrm = 1642,

        MMX_PHSUBWrr = 1643,

        MMX_PINSRWrm = 1644,

        MMX_PINSRWrr = 1645,

        MMX_PMADDUBSWrm = 1646,

        MMX_PMADDUBSWrr = 1647,

        MMX_PMADDWDirm = 1648,

        MMX_PMADDWDirr = 1649,

        MMX_PMAXSWirm = 1650,

        MMX_PMAXSWirr = 1651,

        MMX_PMAXUBirm = 1652,

        MMX_PMAXUBirr = 1653,

        MMX_PMINSWirm = 1654,

        MMX_PMINSWirr = 1655,

        MMX_PMINUBirm = 1656,

        MMX_PMINUBirr = 1657,

        MMX_PMOVMSKBrr = 1658,

        MMX_PMULHRSWrm = 1659,

        MMX_PMULHRSWrr = 1660,

        MMX_PMULHUWirm = 1661,

        MMX_PMULHUWirr = 1662,

        MMX_PMULHWirm = 1663,

        MMX_PMULHWirr = 1664,

        MMX_PMULLWirm = 1665,

        MMX_PMULLWirr = 1666,

        MMX_PMULUDQirm = 1667,

        MMX_PMULUDQirr = 1668,

        MMX_PORirm = 1669,

        MMX_PORirr = 1670,

        MMX_PSADBWirm = 1671,

        MMX_PSADBWirr = 1672,

        MMX_PSHUFBrm = 1673,

        MMX_PSHUFBrr = 1674,

        MMX_PSHUFWmi = 1675,

        MMX_PSHUFWri = 1676,

        MMX_PSIGNBrm = 1677,

        MMX_PSIGNBrr = 1678,

        MMX_PSIGNDrm = 1679,

        MMX_PSIGNDrr = 1680,

        MMX_PSIGNWrm = 1681,

        MMX_PSIGNWrr = 1682,

        MMX_PSLLDri = 1683,

        MMX_PSLLDrm = 1684,

        MMX_PSLLDrr = 1685,

        MMX_PSLLQri = 1686,

        MMX_PSLLQrm = 1687,

        MMX_PSLLQrr = 1688,

        MMX_PSLLWri = 1689,

        MMX_PSLLWrm = 1690,

        MMX_PSLLWrr = 1691,

        MMX_PSRADri = 1692,

        MMX_PSRADrm = 1693,

        MMX_PSRADrr = 1694,

        MMX_PSRAWri = 1695,

        MMX_PSRAWrm = 1696,

        MMX_PSRAWrr = 1697,

        MMX_PSRLDri = 1698,

        MMX_PSRLDrm = 1699,

        MMX_PSRLDrr = 1700,

        MMX_PSRLQri = 1701,

        MMX_PSRLQrm = 1702,

        MMX_PSRLQrr = 1703,

        MMX_PSRLWri = 1704,

        MMX_PSRLWrm = 1705,

        MMX_PSRLWrr = 1706,

        MMX_PSUBBirm = 1707,

        MMX_PSUBBirr = 1708,

        MMX_PSUBDirm = 1709,

        MMX_PSUBDirr = 1710,

        MMX_PSUBQirm = 1711,

        MMX_PSUBQirr = 1712,

        MMX_PSUBSBirm = 1713,

        MMX_PSUBSBirr = 1714,

        MMX_PSUBSWirm = 1715,

        MMX_PSUBSWirr = 1716,

        MMX_PSUBUSBirm = 1717,

        MMX_PSUBUSBirr = 1718,

        MMX_PSUBUSWirm = 1719,

        MMX_PSUBUSWirr = 1720,

        MMX_PSUBWirm = 1721,

        MMX_PSUBWirr = 1722,

        MMX_PUNPCKHBWirm = 1723,

        MMX_PUNPCKHBWirr = 1724,

        MMX_PUNPCKHDQirm = 1725,

        MMX_PUNPCKHDQirr = 1726,

        MMX_PUNPCKHWDirm = 1727,

        MMX_PUNPCKHWDirr = 1728,

        MMX_PUNPCKLBWirm = 1729,

        MMX_PUNPCKLBWirr = 1730,

        MMX_PUNPCKLDQirm = 1731,

        MMX_PUNPCKLDQirr = 1732,

        MMX_PUNPCKLWDirm = 1733,

        MMX_PUNPCKLWDirr = 1734,

        MMX_PXORirm = 1735,

        MMX_PXORirr = 1736,

        MONITOR32rrr = 1737,

        MONITOR64rrr = 1738,

        MONITORX32rrr = 1739,

        MONITORX64rrr = 1740,

        MONTMUL = 1741,

        MOV16ao16 = 1742,

        MOV16ao32 = 1743,

        MOV16ao64 = 1744,

        MOV16mi = 1745,

        MOV16mr = 1746,

        MOV16ms = 1747,

        MOV16o16a = 1748,

        MOV16o32a = 1749,

        MOV16o64a = 1750,

        MOV16ri = 1751,

        MOV16ri_alt = 1752,

        MOV16rm = 1753,

        MOV16rr = 1754,

        MOV16rr_REV = 1755,

        MOV16rs = 1756,

        MOV16sm = 1757,

        MOV16sr = 1758,

        MOV32ao16 = 1759,

        MOV32ao32 = 1760,

        MOV32ao64 = 1761,

        MOV32cr = 1762,

        MOV32dr = 1763,

        MOV32mi = 1764,

        MOV32mr = 1765,

        MOV32o16a = 1766,

        MOV32o32a = 1767,

        MOV32o64a = 1768,

        MOV32rc = 1769,

        MOV32rd = 1770,

        MOV32ri = 1771,

        MOV32ri_alt = 1772,

        MOV32rm = 1773,

        MOV32rr = 1774,

        MOV32rr_REV = 1775,

        MOV32rs = 1776,

        MOV32sr = 1777,

        MOV64ao32 = 1778,

        MOV64ao64 = 1779,

        MOV64cr = 1780,

        MOV64dr = 1781,

        MOV64mi32 = 1782,

        MOV64mr = 1783,

        MOV64o32a = 1784,

        MOV64o64a = 1785,

        MOV64rc = 1786,

        MOV64rd = 1787,

        MOV64ri = 1788,

        MOV64ri32 = 1789,

        MOV64rm = 1790,

        MOV64rr = 1791,

        MOV64rr_REV = 1792,

        MOV64rs = 1793,

        MOV64sr = 1794,

        MOV64toPQIrm = 1795,

        MOV64toPQIrr = 1796,

        MOV64toSDrr = 1797,

        MOV8ao16 = 1798,

        MOV8ao32 = 1799,

        MOV8ao64 = 1800,

        MOV8mi = 1801,

        MOV8mr = 1802,

        MOV8mr_NOREX = 1803,

        MOV8o16a = 1804,

        MOV8o32a = 1805,

        MOV8o64a = 1806,

        MOV8ri = 1807,

        MOV8ri_alt = 1808,

        MOV8rm = 1809,

        MOV8rm_NOREX = 1810,

        MOV8rr = 1811,

        MOV8rr_NOREX = 1812,

        MOV8rr_REV = 1813,

        MOVAPDmr = 1814,

        MOVAPDrm = 1815,

        MOVAPDrr = 1816,

        MOVAPDrr_REV = 1817,

        MOVAPSmr = 1818,

        MOVAPSrm = 1819,

        MOVAPSrr = 1820,

        MOVAPSrr_REV = 1821,

        MOVBE16mr = 1822,

        MOVBE16rm = 1823,

        MOVBE32mr = 1824,

        MOVBE32rm = 1825,

        MOVBE64mr = 1826,

        MOVBE64rm = 1827,

        MOVDDUPrm = 1828,

        MOVDDUPrr = 1829,

        MOVDI2PDIrm = 1830,

        MOVDI2PDIrr = 1831,

        MOVDI2SSrr = 1832,

        MOVDIR64B16 = 1833,

        MOVDIR64B32 = 1834,

        MOVDIR64B64 = 1835,

        MOVDIRI32 = 1836,

        MOVDIRI64 = 1837,

        MOVDQAmr = 1838,

        MOVDQArm = 1839,

        MOVDQArr = 1840,

        MOVDQArr_REV = 1841,

        MOVDQUmr = 1842,

        MOVDQUrm = 1843,

        MOVDQUrr = 1844,

        MOVDQUrr_REV = 1845,

        MOVHLPSrr = 1846,

        MOVHPDmr = 1847,

        MOVHPDrm = 1848,

        MOVHPSmr = 1849,

        MOVHPSrm = 1850,

        MOVLHPSrr = 1851,

        MOVLPDmr = 1852,

        MOVLPDrm = 1853,

        MOVLPSmr = 1854,

        MOVLPSrm = 1855,

        MOVMSKPDrr = 1856,

        MOVMSKPSrr = 1857,

        MOVNTDQArm = 1858,

        MOVNTDQmr = 1859,

        MOVNTI_64mr = 1860,

        MOVNTImr = 1861,

        MOVNTPDmr = 1862,

        MOVNTPSmr = 1863,

        MOVNTSD = 1864,

        MOVNTSS = 1865,

        MOVPC32r = 1866,

        MOVPDI2DImr = 1867,

        MOVPDI2DIrr = 1868,

        MOVPQI2QImr = 1869,

        MOVPQI2QIrr = 1870,

        MOVPQIto64mr = 1871,

        MOVPQIto64rr = 1872,

        MOVQI2PQIrm = 1873,

        MOVSB = 1874,

        MOVSDmr = 1875,

        MOVSDrm = 1876,

        MOVSDrm_alt = 1877,

        MOVSDrr = 1878,

        MOVSDrr_REV = 1879,

        MOVSDto64rr = 1880,

        MOVSHDUPrm = 1881,

        MOVSHDUPrr = 1882,

        MOVSL = 1883,

        MOVSLDUPrm = 1884,

        MOVSLDUPrr = 1885,

        MOVSQ = 1886,

        MOVSS2DIrr = 1887,

        MOVSSmr = 1888,

        MOVSSrm = 1889,

        MOVSSrm_alt = 1890,

        MOVSSrr = 1891,

        MOVSSrr_REV = 1892,

        MOVSW = 1893,

        MOVSX16rm16 = 1894,

        MOVSX16rm32 = 1895,

        MOVSX16rm8 = 1896,

        MOVSX16rr16 = 1897,

        MOVSX16rr32 = 1898,

        MOVSX16rr8 = 1899,

        MOVSX32rm16 = 1900,

        MOVSX32rm32 = 1901,

        MOVSX32rm8 = 1902,

        MOVSX32rm8_NOREX = 1903,

        MOVSX32rr16 = 1904,

        MOVSX32rr32 = 1905,

        MOVSX32rr8 = 1906,

        MOVSX32rr8_NOREX = 1907,

        MOVSX64rm16 = 1908,

        MOVSX64rm32 = 1909,

        MOVSX64rm8 = 1910,

        MOVSX64rr16 = 1911,

        MOVSX64rr32 = 1912,

        MOVSX64rr8 = 1913,

        MOVUPDmr = 1914,

        MOVUPDrm = 1915,

        MOVUPDrr = 1916,

        MOVUPDrr_REV = 1917,

        MOVUPSmr = 1918,

        MOVUPSrm = 1919,

        MOVUPSrr = 1920,

        MOVUPSrr_REV = 1921,

        MOVZPQILo2PQIrr = 1922,

        MOVZX16rm16 = 1923,

        MOVZX16rm8 = 1924,

        MOVZX16rr16 = 1925,

        MOVZX16rr8 = 1926,

        MOVZX32rm16 = 1927,

        MOVZX32rm8 = 1928,

        MOVZX32rm8_NOREX = 1929,

        MOVZX32rr16 = 1930,

        MOVZX32rr8 = 1931,

        MOVZX32rr8_NOREX = 1932,

        MOVZX64rm16 = 1933,

        MOVZX64rm8 = 1934,

        MOVZX64rr16 = 1935,

        MOVZX64rr8 = 1936,

        MPSADBWrmi = 1937,

        MPSADBWrri = 1938,

        MUL16m = 1939,

        MUL16r = 1940,

        MUL32m = 1941,

        MUL32r = 1942,

        MUL64m = 1943,

        MUL64r = 1944,

        MUL8m = 1945,

        MUL8r = 1946,

        MULPDrm = 1947,

        MULPDrr = 1948,

        MULPSrm = 1949,

        MULPSrr = 1950,

        MULSDrm = 1951,

        MULSDrm_Int = 1952,

        MULSDrr = 1953,

        MULSDrr_Int = 1954,

        MULSSrm = 1955,

        MULSSrm_Int = 1956,

        MULSSrr = 1957,

        MULSSrr_Int = 1958,

        MULX32Hrm = 1959,

        MULX32Hrr = 1960,

        MULX32rm = 1961,

        MULX32rr = 1962,

        MULX64Hrm = 1963,

        MULX64Hrr = 1964,

        MULX64rm = 1965,

        MULX64rr = 1966,

        MUL_F32m = 1967,

        MUL_F64m = 1968,

        MUL_FI16m = 1969,

        MUL_FI32m = 1970,

        MUL_FPrST0 = 1971,

        MUL_FST0r = 1972,

        MUL_Fp32 = 1973,

        MUL_Fp32m = 1974,

        MUL_Fp64 = 1975,

        MUL_Fp64m = 1976,

        MUL_Fp64m32 = 1977,

        MUL_Fp80 = 1978,

        MUL_Fp80m32 = 1979,

        MUL_Fp80m64 = 1980,

        MUL_FpI16m32 = 1981,

        MUL_FpI16m64 = 1982,

        MUL_FpI16m80 = 1983,

        MUL_FpI32m32 = 1984,

        MUL_FpI32m64 = 1985,

        MUL_FpI32m80 = 1986,

        MUL_FrST0 = 1987,

        MWAITXrrr = 1988,

        MWAITrr = 1989,

        NEG16m = 1990,

        NEG16r = 1991,

        NEG32m = 1992,

        NEG32r = 1993,

        NEG64m = 1994,

        NEG64r = 1995,

        NEG8m = 1996,

        NEG8r = 1997,

        NOOP = 1998,

        NOOPL = 1999,

        NOOPLr = 2000,

        NOOPQ = 2001,

        NOOPQr = 2002,

        NOOPW = 2003,

        NOOPWr = 2004,

        NOT16m = 2005,

        NOT16r = 2006,

        NOT32m = 2007,

        NOT32r = 2008,

        NOT64m = 2009,

        NOT64r = 2010,

        NOT8m = 2011,

        NOT8r = 2012,

        OR16i16 = 2013,

        OR16mi = 2014,

        OR16mi8 = 2015,

        OR16mr = 2016,

        OR16ri = 2017,

        OR16ri8 = 2018,

        OR16rm = 2019,

        OR16rr = 2020,

        OR16rr_REV = 2021,

        OR32i32 = 2022,

        OR32mi = 2023,

        OR32mi8 = 2024,

        OR32mi8Locked = 2025,

        OR32mr = 2026,

        OR32ri = 2027,

        OR32ri8 = 2028,

        OR32rm = 2029,

        OR32rr = 2030,

        OR32rr_REV = 2031,

        OR64i32 = 2032,

        OR64mi32 = 2033,

        OR64mi8 = 2034,

        OR64mr = 2035,

        OR64ri32 = 2036,

        OR64ri8 = 2037,

        OR64rm = 2038,

        OR64rr = 2039,

        OR64rr_REV = 2040,

        OR8i8 = 2041,

        OR8mi = 2042,

        OR8mi8 = 2043,

        OR8mr = 2044,

        OR8ri = 2045,

        OR8ri8 = 2046,

        OR8rm = 2047,

        OR8rr = 2048,

        OR8rr_REV = 2049,

        ORPDrm = 2050,

        ORPDrr = 2051,

        ORPSrm = 2052,

        ORPSrr = 2053,

        OUT16ir = 2054,

        OUT16rr = 2055,

        OUT32ir = 2056,

        OUT32rr = 2057,

        OUT8ir = 2058,

        OUT8rr = 2059,

        OUTSB = 2060,

        OUTSL = 2061,

        OUTSW = 2062,

        PABSBrm = 2063,

        PABSBrr = 2064,

        PABSDrm = 2065,

        PABSDrr = 2066,

        PABSWrm = 2067,

        PABSWrr = 2068,

        PACKSSDWrm = 2069,

        PACKSSDWrr = 2070,

        PACKSSWBrm = 2071,

        PACKSSWBrr = 2072,

        PACKUSDWrm = 2073,

        PACKUSDWrr = 2074,

        PACKUSWBrm = 2075,

        PACKUSWBrr = 2076,

        PADDBrm = 2077,

        PADDBrr = 2078,

        PADDDrm = 2079,

        PADDDrr = 2080,

        PADDQrm = 2081,

        PADDQrr = 2082,

        PADDSBrm = 2083,

        PADDSBrr = 2084,

        PADDSWrm = 2085,

        PADDSWrr = 2086,

        PADDUSBrm = 2087,

        PADDUSBrr = 2088,

        PADDUSWrm = 2089,

        PADDUSWrr = 2090,

        PADDWrm = 2091,

        PADDWrr = 2092,

        PALIGNRrmi = 2093,

        PALIGNRrri = 2094,

        PANDNrm = 2095,

        PANDNrr = 2096,

        PANDrm = 2097,

        PANDrr = 2098,

        PAUSE = 2099,

        PAVGBrm = 2100,

        PAVGBrr = 2101,

        PAVGUSBrm = 2102,

        PAVGUSBrr = 2103,

        PAVGWrm = 2104,

        PAVGWrr = 2105,

        PBLENDVBrm0 = 2106,

        PBLENDVBrr0 = 2107,

        PBLENDWrmi = 2108,

        PBLENDWrri = 2109,

        PCLMULQDQrm = 2110,

        PCLMULQDQrr = 2111,

        PCMPEQBrm = 2112,

        PCMPEQBrr = 2113,

        PCMPEQDrm = 2114,

        PCMPEQDrr = 2115,

        PCMPEQQrm = 2116,

        PCMPEQQrr = 2117,

        PCMPEQWrm = 2118,

        PCMPEQWrr = 2119,

        PCMPESTRIrm = 2120,

        PCMPESTRIrr = 2121,

        PCMPESTRMrm = 2122,

        PCMPESTRMrr = 2123,

        PCMPGTBrm = 2124,

        PCMPGTBrr = 2125,

        PCMPGTDrm = 2126,

        PCMPGTDrr = 2127,

        PCMPGTQrm = 2128,

        PCMPGTQrr = 2129,

        PCMPGTWrm = 2130,

        PCMPGTWrr = 2131,

        PCMPISTRIrm = 2132,

        PCMPISTRIrr = 2133,

        PCMPISTRMrm = 2134,

        PCMPISTRMrr = 2135,

        PCONFIG = 2136,

        PDEP32rm = 2137,

        PDEP32rr = 2138,

        PDEP64rm = 2139,

        PDEP64rr = 2140,

        PEXT32rm = 2141,

        PEXT32rr = 2142,

        PEXT64rm = 2143,

        PEXT64rr = 2144,

        PEXTRBmr = 2145,

        PEXTRBrr = 2146,

        PEXTRDmr = 2147,

        PEXTRDrr = 2148,

        PEXTRQmr = 2149,

        PEXTRQrr = 2150,

        PEXTRWmr = 2151,

        PEXTRWrr = 2152,

        PEXTRWrr_REV = 2153,

        PF2IDrm = 2154,

        PF2IDrr = 2155,

        PF2IWrm = 2156,

        PF2IWrr = 2157,

        PFACCrm = 2158,

        PFACCrr = 2159,

        PFADDrm = 2160,

        PFADDrr = 2161,

        PFCMPEQrm = 2162,

        PFCMPEQrr = 2163,

        PFCMPGErm = 2164,

        PFCMPGErr = 2165,

        PFCMPGTrm = 2166,

        PFCMPGTrr = 2167,

        PFMAXrm = 2168,

        PFMAXrr = 2169,

        PFMINrm = 2170,

        PFMINrr = 2171,

        PFMULrm = 2172,

        PFMULrr = 2173,

        PFNACCrm = 2174,

        PFNACCrr = 2175,

        PFPNACCrm = 2176,

        PFPNACCrr = 2177,

        PFRCPIT1rm = 2178,

        PFRCPIT1rr = 2179,

        PFRCPIT2rm = 2180,

        PFRCPIT2rr = 2181,

        PFRCPrm = 2182,

        PFRCPrr = 2183,

        PFRSQIT1rm = 2184,

        PFRSQIT1rr = 2185,

        PFRSQRTrm = 2186,

        PFRSQRTrr = 2187,

        PFSUBRrm = 2188,

        PFSUBRrr = 2189,

        PFSUBrm = 2190,

        PFSUBrr = 2191,

        PHADDDrm = 2192,

        PHADDDrr = 2193,

        PHADDSWrm = 2194,

        PHADDSWrr = 2195,

        PHADDWrm = 2196,

        PHADDWrr = 2197,

        PHMINPOSUWrm = 2198,

        PHMINPOSUWrr = 2199,

        PHSUBDrm = 2200,

        PHSUBDrr = 2201,

        PHSUBSWrm = 2202,

        PHSUBSWrr = 2203,

        PHSUBWrm = 2204,

        PHSUBWrr = 2205,

        PI2FDrm = 2206,

        PI2FDrr = 2207,

        PI2FWrm = 2208,

        PI2FWrr = 2209,

        PINSRBrm = 2210,

        PINSRBrr = 2211,

        PINSRDrm = 2212,

        PINSRDrr = 2213,

        PINSRQrm = 2214,

        PINSRQrr = 2215,

        PINSRWrm = 2216,

        PINSRWrr = 2217,

        PLDTILECFGV = 2218,

        PMADDUBSWrm = 2219,

        PMADDUBSWrr = 2220,

        PMADDWDrm = 2221,

        PMADDWDrr = 2222,

        PMAXSBrm = 2223,

        PMAXSBrr = 2224,

        PMAXSDrm = 2225,

        PMAXSDrr = 2226,

        PMAXSWrm = 2227,

        PMAXSWrr = 2228,

        PMAXUBrm = 2229,

        PMAXUBrr = 2230,

        PMAXUDrm = 2231,

        PMAXUDrr = 2232,

        PMAXUWrm = 2233,

        PMAXUWrr = 2234,

        PMINSBrm = 2235,

        PMINSBrr = 2236,

        PMINSDrm = 2237,

        PMINSDrr = 2238,

        PMINSWrm = 2239,

        PMINSWrr = 2240,

        PMINUBrm = 2241,

        PMINUBrr = 2242,

        PMINUDrm = 2243,

        PMINUDrr = 2244,

        PMINUWrm = 2245,

        PMINUWrr = 2246,

        PMOVMSKBrr = 2247,

        PMOVSXBDrm = 2248,

        PMOVSXBDrr = 2249,

        PMOVSXBQrm = 2250,

        PMOVSXBQrr = 2251,

        PMOVSXBWrm = 2252,

        PMOVSXBWrr = 2253,

        PMOVSXDQrm = 2254,

        PMOVSXDQrr = 2255,

        PMOVSXWDrm = 2256,

        PMOVSXWDrr = 2257,

        PMOVSXWQrm = 2258,

        PMOVSXWQrr = 2259,

        PMOVZXBDrm = 2260,

        PMOVZXBDrr = 2261,

        PMOVZXBQrm = 2262,

        PMOVZXBQrr = 2263,

        PMOVZXBWrm = 2264,

        PMOVZXBWrr = 2265,

        PMOVZXDQrm = 2266,

        PMOVZXDQrr = 2267,

        PMOVZXWDrm = 2268,

        PMOVZXWDrr = 2269,

        PMOVZXWQrm = 2270,

        PMOVZXWQrr = 2271,

        PMULDQrm = 2272,

        PMULDQrr = 2273,

        PMULHRSWrm = 2274,

        PMULHRSWrr = 2275,

        PMULHRWrm = 2276,

        PMULHRWrr = 2277,

        PMULHUWrm = 2278,

        PMULHUWrr = 2279,

        PMULHWrm = 2280,

        PMULHWrr = 2281,

        PMULLDrm = 2282,

        PMULLDrr = 2283,

        PMULLWrm = 2284,

        PMULLWrr = 2285,

        PMULUDQrm = 2286,

        PMULUDQrr = 2287,

        POP16r = 2288,

        POP16rmm = 2289,

        POP16rmr = 2290,

        POP32r = 2291,

        POP32rmm = 2292,

        POP32rmr = 2293,

        POP64r = 2294,

        POP64rmm = 2295,

        POP64rmr = 2296,

        POPA16 = 2297,

        POPA32 = 2298,

        POPCNT16rm = 2299,

        POPCNT16rr = 2300,

        POPCNT32rm = 2301,

        POPCNT32rr = 2302,

        POPCNT64rm = 2303,

        POPCNT64rr = 2304,

        POPDS16 = 2305,

        POPDS32 = 2306,

        POPES16 = 2307,

        POPES32 = 2308,

        POPF16 = 2309,

        POPF32 = 2310,

        POPF64 = 2311,

        POPFS16 = 2312,

        POPFS32 = 2313,

        POPFS64 = 2314,

        POPGS16 = 2315,

        POPGS32 = 2316,

        POPGS64 = 2317,

        POPSS16 = 2318,

        POPSS32 = 2319,

        PORrm = 2320,

        PORrr = 2321,

        PREFETCH = 2322,

        PREFETCHNTA = 2323,

        PREFETCHT0 = 2324,

        PREFETCHT1 = 2325,

        PREFETCHT2 = 2326,

        PREFETCHW = 2327,

        PREFETCHWT1 = 2328,

        PROBED_ALLOCA_32 = 2329,

        PROBED_ALLOCA_64 = 2330,

        PSADBWrm = 2331,

        PSADBWrr = 2332,

        PSHUFBrm = 2333,

        PSHUFBrr = 2334,

        PSHUFDmi = 2335,

        PSHUFDri = 2336,

        PSHUFHWmi = 2337,

        PSHUFHWri = 2338,

        PSHUFLWmi = 2339,

        PSHUFLWri = 2340,

        PSIGNBrm = 2341,

        PSIGNBrr = 2342,

        PSIGNDrm = 2343,

        PSIGNDrr = 2344,

        PSIGNWrm = 2345,

        PSIGNWrr = 2346,

        PSLLDQri = 2347,

        PSLLDri = 2348,

        PSLLDrm = 2349,

        PSLLDrr = 2350,

        PSLLQri = 2351,

        PSLLQrm = 2352,

        PSLLQrr = 2353,

        PSLLWri = 2354,

        PSLLWrm = 2355,

        PSLLWrr = 2356,

        PSMASH = 2357,

        PSRADri = 2358,

        PSRADrm = 2359,

        PSRADrr = 2360,

        PSRAWri = 2361,

        PSRAWrm = 2362,

        PSRAWrr = 2363,

        PSRLDQri = 2364,

        PSRLDri = 2365,

        PSRLDrm = 2366,

        PSRLDrr = 2367,

        PSRLQri = 2368,

        PSRLQrm = 2369,

        PSRLQrr = 2370,

        PSRLWri = 2371,

        PSRLWrm = 2372,

        PSRLWrr = 2373,

        PSUBBrm = 2374,

        PSUBBrr = 2375,

        PSUBDrm = 2376,

        PSUBDrr = 2377,

        PSUBQrm = 2378,

        PSUBQrr = 2379,

        PSUBSBrm = 2380,

        PSUBSBrr = 2381,

        PSUBSWrm = 2382,

        PSUBSWrr = 2383,

        PSUBUSBrm = 2384,

        PSUBUSBrr = 2385,

        PSUBUSWrm = 2386,

        PSUBUSWrr = 2387,

        PSUBWrm = 2388,

        PSUBWrr = 2389,

        PSWAPDrm = 2390,

        PSWAPDrr = 2391,

        PTDPBF16PS = 2392,

        PTDPBF16PSV = 2393,

        PTDPBSSD = 2394,

        PTDPBSSDV = 2395,

        PTDPBSUD = 2396,

        PTDPBSUDV = 2397,

        PTDPBUSD = 2398,

        PTDPBUSDV = 2399,

        PTDPBUUD = 2400,

        PTDPBUUDV = 2401,

        PTESTrm = 2402,

        PTESTrr = 2403,

        PTILELOADD = 2404,

        PTILELOADDT1 = 2405,

        PTILELOADDT1V = 2406,

        PTILELOADDV = 2407,

        PTILESTORED = 2408,

        PTILESTOREDV = 2409,

        PTILEZERO = 2410,

        PTILEZEROV = 2411,

        PTWRITE64m = 2412,

        PTWRITE64r = 2413,

        PTWRITEm = 2414,

        PTWRITEr = 2415,

        PUNPCKHBWrm = 2416,

        PUNPCKHBWrr = 2417,

        PUNPCKHDQrm = 2418,

        PUNPCKHDQrr = 2419,

        PUNPCKHQDQrm = 2420,

        PUNPCKHQDQrr = 2421,

        PUNPCKHWDrm = 2422,

        PUNPCKHWDrr = 2423,

        PUNPCKLBWrm = 2424,

        PUNPCKLBWrr = 2425,

        PUNPCKLDQrm = 2426,

        PUNPCKLDQrr = 2427,

        PUNPCKLQDQrm = 2428,

        PUNPCKLQDQrr = 2429,

        PUNPCKLWDrm = 2430,

        PUNPCKLWDrr = 2431,

        PUSH16i8 = 2432,

        PUSH16r = 2433,

        PUSH16rmm = 2434,

        PUSH16rmr = 2435,

        PUSH32i8 = 2436,

        PUSH32r = 2437,

        PUSH32rmm = 2438,

        PUSH32rmr = 2439,

        PUSH64i32 = 2440,

        PUSH64i8 = 2441,

        PUSH64r = 2442,

        PUSH64rmm = 2443,

        PUSH64rmr = 2444,

        PUSHA16 = 2445,

        PUSHA32 = 2446,

        PUSHCS16 = 2447,

        PUSHCS32 = 2448,

        PUSHDS16 = 2449,

        PUSHDS32 = 2450,

        PUSHES16 = 2451,

        PUSHES32 = 2452,

        PUSHF16 = 2453,

        PUSHF32 = 2454,

        PUSHF64 = 2455,

        PUSHFS16 = 2456,

        PUSHFS32 = 2457,

        PUSHFS64 = 2458,

        PUSHGS16 = 2459,

        PUSHGS32 = 2460,

        PUSHGS64 = 2461,

        PUSHSS16 = 2462,

        PUSHSS32 = 2463,

        PUSHi16 = 2464,

        PUSHi32 = 2465,

        PVALIDATE32 = 2466,

        PVALIDATE64 = 2467,

        PXORrm = 2468,

        PXORrr = 2469,

        RCL16m1 = 2470,

        RCL16mCL = 2471,

        RCL16mi = 2472,

        RCL16r1 = 2473,

        RCL16rCL = 2474,

        RCL16ri = 2475,

        RCL32m1 = 2476,

        RCL32mCL = 2477,

        RCL32mi = 2478,

        RCL32r1 = 2479,

        RCL32rCL = 2480,

        RCL32ri = 2481,

        RCL64m1 = 2482,

        RCL64mCL = 2483,

        RCL64mi = 2484,

        RCL64r1 = 2485,

        RCL64rCL = 2486,

        RCL64ri = 2487,

        RCL8m1 = 2488,

        RCL8mCL = 2489,

        RCL8mi = 2490,

        RCL8r1 = 2491,

        RCL8rCL = 2492,

        RCL8ri = 2493,

        RCPPSm = 2494,

        RCPPSr = 2495,

        RCPSSm = 2496,

        RCPSSm_Int = 2497,

        RCPSSr = 2498,

        RCPSSr_Int = 2499,

        RCR16m1 = 2500,

        RCR16mCL = 2501,

        RCR16mi = 2502,

        RCR16r1 = 2503,

        RCR16rCL = 2504,

        RCR16ri = 2505,

        RCR32m1 = 2506,

        RCR32mCL = 2507,

        RCR32mi = 2508,

        RCR32r1 = 2509,

        RCR32rCL = 2510,

        RCR32ri = 2511,

        RCR64m1 = 2512,

        RCR64mCL = 2513,

        RCR64mi = 2514,

        RCR64r1 = 2515,

        RCR64rCL = 2516,

        RCR64ri = 2517,

        RCR8m1 = 2518,

        RCR8mCL = 2519,

        RCR8mi = 2520,

        RCR8r1 = 2521,

        RCR8rCL = 2522,

        RCR8ri = 2523,

        RDFLAGS32 = 2524,

        RDFLAGS64 = 2525,

        RDFSBASE = 2526,

        RDFSBASE64 = 2527,

        RDGSBASE = 2528,

        RDGSBASE64 = 2529,

        RDMSR = 2530,

        RDPID32 = 2531,

        RDPID64 = 2532,

        RDPKRUr = 2533,

        RDPMC = 2534,

        RDRAND16r = 2535,

        RDRAND32r = 2536,

        RDRAND64r = 2537,

        RDSEED16r = 2538,

        RDSEED32r = 2539,

        RDSEED64r = 2540,

        RDSSPD = 2541,

        RDSSPQ = 2542,

        RDTSC = 2543,

        RDTSCP = 2544,

        REPNE_PREFIX = 2545,

        REP_MOVSB_32 = 2546,

        REP_MOVSB_64 = 2547,

        REP_MOVSD_32 = 2548,

        REP_MOVSD_64 = 2549,

        REP_MOVSQ_32 = 2550,

        REP_MOVSQ_64 = 2551,

        REP_MOVSW_32 = 2552,

        REP_MOVSW_64 = 2553,

        REP_PREFIX = 2554,

        REP_STOSB_32 = 2555,

        REP_STOSB_64 = 2556,

        REP_STOSD_32 = 2557,

        REP_STOSD_64 = 2558,

        REP_STOSQ_32 = 2559,

        REP_STOSQ_64 = 2560,

        REP_STOSW_32 = 2561,

        REP_STOSW_64 = 2562,

        RET = 2563,

        RETIL = 2564,

        RETIQ = 2565,

        RETIW = 2566,

        RETL = 2567,

        RETQ = 2568,

        RETW = 2569,

        REX64_PREFIX = 2570,

        RMPADJUST = 2571,

        RMPUPDATE = 2572,

        ROL16m1 = 2573,

        ROL16mCL = 2574,

        ROL16mi = 2575,

        ROL16r1 = 2576,

        ROL16rCL = 2577,

        ROL16ri = 2578,

        ROL32m1 = 2579,

        ROL32mCL = 2580,

        ROL32mi = 2581,

        ROL32r1 = 2582,

        ROL32rCL = 2583,

        ROL32ri = 2584,

        ROL64m1 = 2585,

        ROL64mCL = 2586,

        ROL64mi = 2587,

        ROL64r1 = 2588,

        ROL64rCL = 2589,

        ROL64ri = 2590,

        ROL8m1 = 2591,

        ROL8mCL = 2592,

        ROL8mi = 2593,

        ROL8r1 = 2594,

        ROL8rCL = 2595,

        ROL8ri = 2596,

        ROR16m1 = 2597,

        ROR16mCL = 2598,

        ROR16mi = 2599,

        ROR16r1 = 2600,

        ROR16rCL = 2601,

        ROR16ri = 2602,

        ROR32m1 = 2603,

        ROR32mCL = 2604,

        ROR32mi = 2605,

        ROR32r1 = 2606,

        ROR32rCL = 2607,

        ROR32ri = 2608,

        ROR64m1 = 2609,

        ROR64mCL = 2610,

        ROR64mi = 2611,

        ROR64r1 = 2612,

        ROR64rCL = 2613,

        ROR64ri = 2614,

        ROR8m1 = 2615,

        ROR8mCL = 2616,

        ROR8mi = 2617,

        ROR8r1 = 2618,

        ROR8rCL = 2619,

        ROR8ri = 2620,

        RORX32mi = 2621,

        RORX32ri = 2622,

        RORX64mi = 2623,

        RORX64ri = 2624,

        ROUNDPDm = 2625,

        ROUNDPDr = 2626,

        ROUNDPSm = 2627,

        ROUNDPSr = 2628,

        ROUNDSDm = 2629,

        ROUNDSDm_Int = 2630,

        ROUNDSDr = 2631,

        ROUNDSDr_Int = 2632,

        ROUNDSSm = 2633,

        ROUNDSSm_Int = 2634,

        ROUNDSSr = 2635,

        ROUNDSSr_Int = 2636,

        RSM = 2637,

        RSQRTPSm = 2638,

        RSQRTPSr = 2639,

        RSQRTSSm = 2640,

        RSQRTSSm_Int = 2641,

        RSQRTSSr = 2642,

        RSQRTSSr_Int = 2643,

        RSTORSSP = 2644,

        SAHF = 2645,

        SALC = 2646,

        SAR16m1 = 2647,

        SAR16mCL = 2648,

        SAR16mi = 2649,

        SAR16r1 = 2650,

        SAR16rCL = 2651,

        SAR16ri = 2652,

        SAR32m1 = 2653,

        SAR32mCL = 2654,

        SAR32mi = 2655,

        SAR32r1 = 2656,

        SAR32rCL = 2657,

        SAR32ri = 2658,

        SAR64m1 = 2659,

        SAR64mCL = 2660,

        SAR64mi = 2661,

        SAR64r1 = 2662,

        SAR64rCL = 2663,

        SAR64ri = 2664,

        SAR8m1 = 2665,

        SAR8mCL = 2666,

        SAR8mi = 2667,

        SAR8r1 = 2668,

        SAR8rCL = 2669,

        SAR8ri = 2670,

        SARX32rm = 2671,

        SARX32rr = 2672,

        SARX64rm = 2673,

        SARX64rr = 2674,

        SAVEPREVSSP = 2675,

        SBB16i16 = 2676,

        SBB16mi = 2677,

        SBB16mi8 = 2678,

        SBB16mr = 2679,

        SBB16ri = 2680,

        SBB16ri8 = 2681,

        SBB16rm = 2682,

        SBB16rr = 2683,

        SBB16rr_REV = 2684,

        SBB32i32 = 2685,

        SBB32mi = 2686,

        SBB32mi8 = 2687,

        SBB32mr = 2688,

        SBB32ri = 2689,

        SBB32ri8 = 2690,

        SBB32rm = 2691,

        SBB32rr = 2692,

        SBB32rr_REV = 2693,

        SBB64i32 = 2694,

        SBB64mi32 = 2695,

        SBB64mi8 = 2696,

        SBB64mr = 2697,

        SBB64ri32 = 2698,

        SBB64ri8 = 2699,

        SBB64rm = 2700,

        SBB64rr = 2701,

        SBB64rr_REV = 2702,

        SBB8i8 = 2703,

        SBB8mi = 2704,

        SBB8mi8 = 2705,

        SBB8mr = 2706,

        SBB8ri = 2707,

        SBB8ri8 = 2708,

        SBB8rm = 2709,

        SBB8rr = 2710,

        SBB8rr_REV = 2711,

        SCASB = 2712,

        SCASL = 2713,

        SCASQ = 2714,

        SCASW = 2715,

        SEAMCALL = 2716,

        SEAMOPS = 2717,

        SEAMRET = 2718,

        SEG_ALLOCA_32 = 2719,

        SEG_ALLOCA_64 = 2720,

        SENDUIPI = 2721,

        SERIALIZE = 2722,

        SETCCm = 2723,

        SETCCr = 2724,

        SETSSBSY = 2725,

        SFENCE = 2726,

        SGDT16m = 2727,

        SGDT32m = 2728,

        SGDT64m = 2729,

        SHA1MSG1rm = 2730,

        SHA1MSG1rr = 2731,

        SHA1MSG2rm = 2732,

        SHA1MSG2rr = 2733,

        SHA1NEXTErm = 2734,

        SHA1NEXTErr = 2735,

        SHA1RNDS4rmi = 2736,

        SHA1RNDS4rri = 2737,

        SHA256MSG1rm = 2738,

        SHA256MSG1rr = 2739,

        SHA256MSG2rm = 2740,

        SHA256MSG2rr = 2741,

        SHA256RNDS2rm = 2742,

        SHA256RNDS2rr = 2743,

        SHL16m1 = 2744,

        SHL16mCL = 2745,

        SHL16mi = 2746,

        SHL16r1 = 2747,

        SHL16rCL = 2748,

        SHL16ri = 2749,

        SHL32m1 = 2750,

        SHL32mCL = 2751,

        SHL32mi = 2752,

        SHL32r1 = 2753,

        SHL32rCL = 2754,

        SHL32ri = 2755,

        SHL64m1 = 2756,

        SHL64mCL = 2757,

        SHL64mi = 2758,

        SHL64r1 = 2759,

        SHL64rCL = 2760,

        SHL64ri = 2761,

        SHL8m1 = 2762,

        SHL8mCL = 2763,

        SHL8mi = 2764,

        SHL8r1 = 2765,

        SHL8rCL = 2766,

        SHL8ri = 2767,

        SHLD16mrCL = 2768,

        SHLD16mri8 = 2769,

        SHLD16rrCL = 2770,

        SHLD16rri8 = 2771,

        SHLD32mrCL = 2772,

        SHLD32mri8 = 2773,

        SHLD32rrCL = 2774,

        SHLD32rri8 = 2775,

        SHLD64mrCL = 2776,

        SHLD64mri8 = 2777,

        SHLD64rrCL = 2778,

        SHLD64rri8 = 2779,

        SHLX32rm = 2780,

        SHLX32rr = 2781,

        SHLX64rm = 2782,

        SHLX64rr = 2783,

        SHR16m1 = 2784,

        SHR16mCL = 2785,

        SHR16mi = 2786,

        SHR16r1 = 2787,

        SHR16rCL = 2788,

        SHR16ri = 2789,

        SHR32m1 = 2790,

        SHR32mCL = 2791,

        SHR32mi = 2792,

        SHR32r1 = 2793,

        SHR32rCL = 2794,

        SHR32ri = 2795,

        SHR64m1 = 2796,

        SHR64mCL = 2797,

        SHR64mi = 2798,

        SHR64r1 = 2799,

        SHR64rCL = 2800,

        SHR64ri = 2801,

        SHR8m1 = 2802,

        SHR8mCL = 2803,

        SHR8mi = 2804,

        SHR8r1 = 2805,

        SHR8rCL = 2806,

        SHR8ri = 2807,

        SHRD16mrCL = 2808,

        SHRD16mri8 = 2809,

        SHRD16rrCL = 2810,

        SHRD16rri8 = 2811,

        SHRD32mrCL = 2812,

        SHRD32mri8 = 2813,

        SHRD32rrCL = 2814,

        SHRD32rri8 = 2815,

        SHRD64mrCL = 2816,

        SHRD64mri8 = 2817,

        SHRD64rrCL = 2818,

        SHRD64rri8 = 2819,

        SHRX32rm = 2820,

        SHRX32rr = 2821,

        SHRX64rm = 2822,

        SHRX64rr = 2823,

        SHUFPDrmi = 2824,

        SHUFPDrri = 2825,

        SHUFPSrmi = 2826,

        SHUFPSrri = 2827,

        SIDT16m = 2828,

        SIDT32m = 2829,

        SIDT64m = 2830,

        SKINIT = 2831,

        SLDT16m = 2832,

        SLDT16r = 2833,

        SLDT32r = 2834,

        SLDT64r = 2835,

        SLWPCB = 2836,

        SLWPCB64 = 2837,

        SMSW16m = 2838,

        SMSW16r = 2839,

        SMSW32r = 2840,

        SMSW64r = 2841,

        SQRTPDm = 2842,

        SQRTPDr = 2843,

        SQRTPSm = 2844,

        SQRTPSr = 2845,

        SQRTSDm = 2846,

        SQRTSDm_Int = 2847,

        SQRTSDr = 2848,

        SQRTSDr_Int = 2849,

        SQRTSSm = 2850,

        SQRTSSm_Int = 2851,

        SQRTSSr = 2852,

        SQRTSSr_Int = 2853,

        SQRT_F = 2854,

        SQRT_Fp32 = 2855,

        SQRT_Fp64 = 2856,

        SQRT_Fp80 = 2857,

        SS_PREFIX = 2858,

        STAC = 2859,

        STACKALLOC_W_PROBING = 2860,

        STC = 2861,

        STD = 2862,

        STGI = 2863,

        STI = 2864,

        STMXCSR = 2865,

        STOSB = 2866,

        STOSL = 2867,

        STOSQ = 2868,

        STOSW = 2869,

        STR16r = 2870,

        STR32r = 2871,

        STR64r = 2872,

        STRm = 2873,

        STTILECFG = 2874,

        STUI = 2875,

        ST_F32m = 2876,

        ST_F64m = 2877,

        ST_FP32m = 2878,

        ST_FP64m = 2879,

        ST_FP80m = 2880,

        ST_FPrr = 2881,

        ST_Fp32m = 2882,

        ST_Fp64m = 2883,

        ST_Fp64m32 = 2884,

        ST_Fp80m32 = 2885,

        ST_Fp80m64 = 2886,

        ST_FpP32m = 2887,

        ST_FpP64m = 2888,

        ST_FpP64m32 = 2889,

        ST_FpP80m = 2890,

        ST_FpP80m32 = 2891,

        ST_FpP80m64 = 2892,

        ST_Frr = 2893,

        SUB16i16 = 2894,

        SUB16mi = 2895,

        SUB16mi8 = 2896,

        SUB16mr = 2897,

        SUB16ri = 2898,

        SUB16ri8 = 2899,

        SUB16rm = 2900,

        SUB16rr = 2901,

        SUB16rr_REV = 2902,

        SUB32i32 = 2903,

        SUB32mi = 2904,

        SUB32mi8 = 2905,

        SUB32mr = 2906,

        SUB32ri = 2907,

        SUB32ri8 = 2908,

        SUB32rm = 2909,

        SUB32rr = 2910,

        SUB32rr_REV = 2911,

        SUB64i32 = 2912,

        SUB64mi32 = 2913,

        SUB64mi8 = 2914,

        SUB64mr = 2915,

        SUB64ri32 = 2916,

        SUB64ri8 = 2917,

        SUB64rm = 2918,

        SUB64rr = 2919,

        SUB64rr_REV = 2920,

        SUB8i8 = 2921,

        SUB8mi = 2922,

        SUB8mi8 = 2923,

        SUB8mr = 2924,

        SUB8ri = 2925,

        SUB8ri8 = 2926,

        SUB8rm = 2927,

        SUB8rr = 2928,

        SUB8rr_REV = 2929,

        SUBPDrm = 2930,

        SUBPDrr = 2931,

        SUBPSrm = 2932,

        SUBPSrr = 2933,

        SUBR_F32m = 2934,

        SUBR_F64m = 2935,

        SUBR_FI16m = 2936,

        SUBR_FI32m = 2937,

        SUBR_FPrST0 = 2938,

        SUBR_FST0r = 2939,

        SUBR_Fp32m = 2940,

        SUBR_Fp64m = 2941,

        SUBR_Fp64m32 = 2942,

        SUBR_Fp80m32 = 2943,

        SUBR_Fp80m64 = 2944,

        SUBR_FpI16m32 = 2945,

        SUBR_FpI16m64 = 2946,

        SUBR_FpI16m80 = 2947,

        SUBR_FpI32m32 = 2948,

        SUBR_FpI32m64 = 2949,

        SUBR_FpI32m80 = 2950,

        SUBR_FrST0 = 2951,

        SUBSDrm = 2952,

        SUBSDrm_Int = 2953,

        SUBSDrr = 2954,

        SUBSDrr_Int = 2955,

        SUBSSrm = 2956,

        SUBSSrm_Int = 2957,

        SUBSSrr = 2958,

        SUBSSrr_Int = 2959,

        SUB_F32m = 2960,

        SUB_F64m = 2961,

        SUB_FI16m = 2962,

        SUB_FI32m = 2963,

        SUB_FPrST0 = 2964,

        SUB_FST0r = 2965,

        SUB_Fp32 = 2966,

        SUB_Fp32m = 2967,

        SUB_Fp64 = 2968,

        SUB_Fp64m = 2969,

        SUB_Fp64m32 = 2970,

        SUB_Fp80 = 2971,

        SUB_Fp80m32 = 2972,

        SUB_Fp80m64 = 2973,

        SUB_FpI16m32 = 2974,

        SUB_FpI16m64 = 2975,

        SUB_FpI16m80 = 2976,

        SUB_FpI32m32 = 2977,

        SUB_FpI32m64 = 2978,

        SUB_FpI32m80 = 2979,

        SUB_FrST0 = 2980,

        SWAPGS = 2981,

        SYSCALL = 2982,

        SYSENTER = 2983,

        SYSEXIT = 2984,

        SYSEXIT64 = 2985,

        SYSRET = 2986,

        SYSRET64 = 2987,

        T1MSKC32rm = 2988,

        T1MSKC32rr = 2989,

        T1MSKC64rm = 2990,

        T1MSKC64rr = 2991,

        TAILJMPd = 2992,

        TAILJMPd64 = 2993,

        TAILJMPd64_CC = 2994,

        TAILJMPd_CC = 2995,

        TAILJMPm = 2996,

        TAILJMPm64 = 2997,

        TAILJMPm64_REX = 2998,

        TAILJMPr = 2999,

        TAILJMPr64 = 3000,

        TAILJMPr64_REX = 3001,

        TCRETURNdi = 3002,

        TCRETURNdi64 = 3003,

        TCRETURNdi64cc = 3004,

        TCRETURNdicc = 3005,

        TCRETURNmi = 3006,

        TCRETURNmi64 = 3007,

        TCRETURNri = 3008,

        TCRETURNri64 = 3009,

        TDCALL = 3010,

        TDPBF16PS = 3011,

        TDPBSSD = 3012,

        TDPBSUD = 3013,

        TDPBUSD = 3014,

        TDPBUUD = 3015,

        TEST16i16 = 3016,

        TEST16mi = 3017,

        TEST16mr = 3018,

        TEST16ri = 3019,

        TEST16rr = 3020,

        TEST32i32 = 3021,

        TEST32mi = 3022,

        TEST32mr = 3023,

        TEST32ri = 3024,

        TEST32rr = 3025,

        TEST64i32 = 3026,

        TEST64mi32 = 3027,

        TEST64mr = 3028,

        TEST64ri32 = 3029,

        TEST64rr = 3030,

        TEST8i8 = 3031,

        TEST8mi = 3032,

        TEST8mr = 3033,

        TEST8ri = 3034,

        TEST8rr = 3035,

        TESTUI = 3036,

        TILELOADD = 3037,

        TILELOADDT1 = 3038,

        TILERELEASE = 3039,

        TILESTORED = 3040,

        TILEZERO = 3041,

        TLBSYNC = 3042,

        TLSCall_32 = 3043,

        TLSCall_64 = 3044,

        TLS_addr32 = 3045,

        TLS_addr64 = 3046,

        TLS_addrX32 = 3047,

        TLS_base_addr32 = 3048,

        TLS_base_addr64 = 3049,

        TLS_base_addrX32 = 3050,

        TPAUSE = 3051,

        TRAP = 3052,

        TST_F = 3053,

        TST_Fp32 = 3054,

        TST_Fp64 = 3055,

        TST_Fp80 = 3056,

        TZCNT16rm = 3057,

        TZCNT16rr = 3058,

        TZCNT32rm = 3059,

        TZCNT32rr = 3060,

        TZCNT64rm = 3061,

        TZCNT64rr = 3062,

        TZMSK32rm = 3063,

        TZMSK32rr = 3064,

        TZMSK64rm = 3065,

        TZMSK64rr = 3066,

        UBSAN_UD1 = 3067,

        UCOMISDrm = 3068,

        UCOMISDrm_Int = 3069,

        UCOMISDrr = 3070,

        UCOMISDrr_Int = 3071,

        UCOMISSrm = 3072,

        UCOMISSrm_Int = 3073,

        UCOMISSrr = 3074,

        UCOMISSrr_Int = 3075,

        UCOM_FIPr = 3076,

        UCOM_FIr = 3077,

        UCOM_FPPr = 3078,

        UCOM_FPr = 3079,

        UCOM_FpIr32 = 3080,

        UCOM_FpIr64 = 3081,

        UCOM_FpIr80 = 3082,

        UCOM_Fpr32 = 3083,

        UCOM_Fpr64 = 3084,

        UCOM_Fpr80 = 3085,

        UCOM_Fr = 3086,

        UD1Lm = 3087,

        UD1Lr = 3088,

        UD1Qm = 3089,

        UD1Qr = 3090,

        UD1Wm = 3091,

        UD1Wr = 3092,

        UIRET = 3093,

        UMONITOR16 = 3094,

        UMONITOR32 = 3095,

        UMONITOR64 = 3096,

        UMWAIT = 3097,

        UNPCKHPDrm = 3098,

        UNPCKHPDrr = 3099,

        UNPCKHPSrm = 3100,

        UNPCKHPSrr = 3101,

        UNPCKLPDrm = 3102,

        UNPCKLPDrr = 3103,

        UNPCKLPSrm = 3104,

        UNPCKLPSrr = 3105,

        V4FMADDPSrm = 3106,

        V4FMADDPSrmk = 3107,

        V4FMADDPSrmkz = 3108,

        V4FMADDSSrm = 3109,

        V4FMADDSSrmk = 3110,

        V4FMADDSSrmkz = 3111,

        V4FNMADDPSrm = 3112,

        V4FNMADDPSrmk = 3113,

        V4FNMADDPSrmkz = 3114,

        V4FNMADDSSrm = 3115,

        V4FNMADDSSrmk = 3116,

        V4FNMADDSSrmkz = 3117,

        VAARG_64 = 3118,

        VAARG_X32 = 3119,

        VADDPDYrm = 3120,

        VADDPDYrr = 3121,

        VADDPDZ128rm = 3122,

        VADDPDZ128rmb = 3123,

        VADDPDZ128rmbk = 3124,

        VADDPDZ128rmbkz = 3125,

        VADDPDZ128rmk = 3126,

        VADDPDZ128rmkz = 3127,

        VADDPDZ128rr = 3128,

        VADDPDZ128rrk = 3129,

        VADDPDZ128rrkz = 3130,

        VADDPDZ256rm = 3131,

        VADDPDZ256rmb = 3132,

        VADDPDZ256rmbk = 3133,

        VADDPDZ256rmbkz = 3134,

        VADDPDZ256rmk = 3135,

        VADDPDZ256rmkz = 3136,

        VADDPDZ256rr = 3137,

        VADDPDZ256rrk = 3138,

        VADDPDZ256rrkz = 3139,

        VADDPDZrm = 3140,

        VADDPDZrmb = 3141,

        VADDPDZrmbk = 3142,

        VADDPDZrmbkz = 3143,

        VADDPDZrmk = 3144,

        VADDPDZrmkz = 3145,

        VADDPDZrr = 3146,

        VADDPDZrrb = 3147,

        VADDPDZrrbk = 3148,

        VADDPDZrrbkz = 3149,

        VADDPDZrrk = 3150,

        VADDPDZrrkz = 3151,

        VADDPDrm = 3152,

        VADDPDrr = 3153,

        VADDPSYrm = 3154,

        VADDPSYrr = 3155,

        VADDPSZ128rm = 3156,

        VADDPSZ128rmb = 3157,

        VADDPSZ128rmbk = 3158,

        VADDPSZ128rmbkz = 3159,

        VADDPSZ128rmk = 3160,

        VADDPSZ128rmkz = 3161,

        VADDPSZ128rr = 3162,

        VADDPSZ128rrk = 3163,

        VADDPSZ128rrkz = 3164,

        VADDPSZ256rm = 3165,

        VADDPSZ256rmb = 3166,

        VADDPSZ256rmbk = 3167,

        VADDPSZ256rmbkz = 3168,

        VADDPSZ256rmk = 3169,

        VADDPSZ256rmkz = 3170,

        VADDPSZ256rr = 3171,

        VADDPSZ256rrk = 3172,

        VADDPSZ256rrkz = 3173,

        VADDPSZrm = 3174,

        VADDPSZrmb = 3175,

        VADDPSZrmbk = 3176,

        VADDPSZrmbkz = 3177,

        VADDPSZrmk = 3178,

        VADDPSZrmkz = 3179,

        VADDPSZrr = 3180,

        VADDPSZrrb = 3181,

        VADDPSZrrbk = 3182,

        VADDPSZrrbkz = 3183,

        VADDPSZrrk = 3184,

        VADDPSZrrkz = 3185,

        VADDPSrm = 3186,

        VADDPSrr = 3187,

        VADDSDZrm = 3188,

        VADDSDZrm_Int = 3189,

        VADDSDZrm_Intk = 3190,

        VADDSDZrm_Intkz = 3191,

        VADDSDZrr = 3192,

        VADDSDZrr_Int = 3193,

        VADDSDZrr_Intk = 3194,

        VADDSDZrr_Intkz = 3195,

        VADDSDZrrb_Int = 3196,

        VADDSDZrrb_Intk = 3197,

        VADDSDZrrb_Intkz = 3198,

        VADDSDrm = 3199,

        VADDSDrm_Int = 3200,

        VADDSDrr = 3201,

        VADDSDrr_Int = 3202,

        VADDSSZrm = 3203,

        VADDSSZrm_Int = 3204,

        VADDSSZrm_Intk = 3205,

        VADDSSZrm_Intkz = 3206,

        VADDSSZrr = 3207,

        VADDSSZrr_Int = 3208,

        VADDSSZrr_Intk = 3209,

        VADDSSZrr_Intkz = 3210,

        VADDSSZrrb_Int = 3211,

        VADDSSZrrb_Intk = 3212,

        VADDSSZrrb_Intkz = 3213,

        VADDSSrm = 3214,

        VADDSSrm_Int = 3215,

        VADDSSrr = 3216,

        VADDSSrr_Int = 3217,

        VADDSUBPDYrm = 3218,

        VADDSUBPDYrr = 3219,

        VADDSUBPDrm = 3220,

        VADDSUBPDrr = 3221,

        VADDSUBPSYrm = 3222,

        VADDSUBPSYrr = 3223,

        VADDSUBPSrm = 3224,

        VADDSUBPSrr = 3225,

        VAESDECLASTYrm = 3226,

        VAESDECLASTYrr = 3227,

        VAESDECLASTZ128rm = 3228,

        VAESDECLASTZ128rr = 3229,

        VAESDECLASTZ256rm = 3230,

        VAESDECLASTZ256rr = 3231,

        VAESDECLASTZrm = 3232,

        VAESDECLASTZrr = 3233,

        VAESDECLASTrm = 3234,

        VAESDECLASTrr = 3235,

        VAESDECYrm = 3236,

        VAESDECYrr = 3237,

        VAESDECZ128rm = 3238,

        VAESDECZ128rr = 3239,

        VAESDECZ256rm = 3240,

        VAESDECZ256rr = 3241,

        VAESDECZrm = 3242,

        VAESDECZrr = 3243,

        VAESDECrm = 3244,

        VAESDECrr = 3245,

        VAESENCLASTYrm = 3246,

        VAESENCLASTYrr = 3247,

        VAESENCLASTZ128rm = 3248,

        VAESENCLASTZ128rr = 3249,

        VAESENCLASTZ256rm = 3250,

        VAESENCLASTZ256rr = 3251,

        VAESENCLASTZrm = 3252,

        VAESENCLASTZrr = 3253,

        VAESENCLASTrm = 3254,

        VAESENCLASTrr = 3255,

        VAESENCYrm = 3256,

        VAESENCYrr = 3257,

        VAESENCZ128rm = 3258,

        VAESENCZ128rr = 3259,

        VAESENCZ256rm = 3260,

        VAESENCZ256rr = 3261,

        VAESENCZrm = 3262,

        VAESENCZrr = 3263,

        VAESENCrm = 3264,

        VAESENCrr = 3265,

        VAESIMCrm = 3266,

        VAESIMCrr = 3267,

        VAESKEYGENASSIST128rm = 3268,

        VAESKEYGENASSIST128rr = 3269,

        VALIGNDZ128rmbi = 3270,

        VALIGNDZ128rmbik = 3271,

        VALIGNDZ128rmbikz = 3272,

        VALIGNDZ128rmi = 3273,

        VALIGNDZ128rmik = 3274,

        VALIGNDZ128rmikz = 3275,

        VALIGNDZ128rri = 3276,

        VALIGNDZ128rrik = 3277,

        VALIGNDZ128rrikz = 3278,

        VALIGNDZ256rmbi = 3279,

        VALIGNDZ256rmbik = 3280,

        VALIGNDZ256rmbikz = 3281,

        VALIGNDZ256rmi = 3282,

        VALIGNDZ256rmik = 3283,

        VALIGNDZ256rmikz = 3284,

        VALIGNDZ256rri = 3285,

        VALIGNDZ256rrik = 3286,

        VALIGNDZ256rrikz = 3287,

        VALIGNDZrmbi = 3288,

        VALIGNDZrmbik = 3289,

        VALIGNDZrmbikz = 3290,

        VALIGNDZrmi = 3291,

        VALIGNDZrmik = 3292,

        VALIGNDZrmikz = 3293,

        VALIGNDZrri = 3294,

        VALIGNDZrrik = 3295,

        VALIGNDZrrikz = 3296,

        VALIGNQZ128rmbi = 3297,

        VALIGNQZ128rmbik = 3298,

        VALIGNQZ128rmbikz = 3299,

        VALIGNQZ128rmi = 3300,

        VALIGNQZ128rmik = 3301,

        VALIGNQZ128rmikz = 3302,

        VALIGNQZ128rri = 3303,

        VALIGNQZ128rrik = 3304,

        VALIGNQZ128rrikz = 3305,

        VALIGNQZ256rmbi = 3306,

        VALIGNQZ256rmbik = 3307,

        VALIGNQZ256rmbikz = 3308,

        VALIGNQZ256rmi = 3309,

        VALIGNQZ256rmik = 3310,

        VALIGNQZ256rmikz = 3311,

        VALIGNQZ256rri = 3312,

        VALIGNQZ256rrik = 3313,

        VALIGNQZ256rrikz = 3314,

        VALIGNQZrmbi = 3315,

        VALIGNQZrmbik = 3316,

        VALIGNQZrmbikz = 3317,

        VALIGNQZrmi = 3318,

        VALIGNQZrmik = 3319,

        VALIGNQZrmikz = 3320,

        VALIGNQZrri = 3321,

        VALIGNQZrrik = 3322,

        VALIGNQZrrikz = 3323,

        VANDNPDYrm = 3324,

        VANDNPDYrr = 3325,

        VANDNPDZ128rm = 3326,

        VANDNPDZ128rmb = 3327,

        VANDNPDZ128rmbk = 3328,

        VANDNPDZ128rmbkz = 3329,

        VANDNPDZ128rmk = 3330,

        VANDNPDZ128rmkz = 3331,

        VANDNPDZ128rr = 3332,

        VANDNPDZ128rrk = 3333,

        VANDNPDZ128rrkz = 3334,

        VANDNPDZ256rm = 3335,

        VANDNPDZ256rmb = 3336,

        VANDNPDZ256rmbk = 3337,

        VANDNPDZ256rmbkz = 3338,

        VANDNPDZ256rmk = 3339,

        VANDNPDZ256rmkz = 3340,

        VANDNPDZ256rr = 3341,

        VANDNPDZ256rrk = 3342,

        VANDNPDZ256rrkz = 3343,

        VANDNPDZrm = 3344,

        VANDNPDZrmb = 3345,

        VANDNPDZrmbk = 3346,

        VANDNPDZrmbkz = 3347,

        VANDNPDZrmk = 3348,

        VANDNPDZrmkz = 3349,

        VANDNPDZrr = 3350,

        VANDNPDZrrk = 3351,

        VANDNPDZrrkz = 3352,

        VANDNPDrm = 3353,

        VANDNPDrr = 3354,

        VANDNPSYrm = 3355,

        VANDNPSYrr = 3356,

        VANDNPSZ128rm = 3357,

        VANDNPSZ128rmb = 3358,

        VANDNPSZ128rmbk = 3359,

        VANDNPSZ128rmbkz = 3360,

        VANDNPSZ128rmk = 3361,

        VANDNPSZ128rmkz = 3362,

        VANDNPSZ128rr = 3363,

        VANDNPSZ128rrk = 3364,

        VANDNPSZ128rrkz = 3365,

        VANDNPSZ256rm = 3366,

        VANDNPSZ256rmb = 3367,

        VANDNPSZ256rmbk = 3368,

        VANDNPSZ256rmbkz = 3369,

        VANDNPSZ256rmk = 3370,

        VANDNPSZ256rmkz = 3371,

        VANDNPSZ256rr = 3372,

        VANDNPSZ256rrk = 3373,

        VANDNPSZ256rrkz = 3374,

        VANDNPSZrm = 3375,

        VANDNPSZrmb = 3376,

        VANDNPSZrmbk = 3377,

        VANDNPSZrmbkz = 3378,

        VANDNPSZrmk = 3379,

        VANDNPSZrmkz = 3380,

        VANDNPSZrr = 3381,

        VANDNPSZrrk = 3382,

        VANDNPSZrrkz = 3383,

        VANDNPSrm = 3384,

        VANDNPSrr = 3385,

        VANDPDYrm = 3386,

        VANDPDYrr = 3387,

        VANDPDZ128rm = 3388,

        VANDPDZ128rmb = 3389,

        VANDPDZ128rmbk = 3390,

        VANDPDZ128rmbkz = 3391,

        VANDPDZ128rmk = 3392,

        VANDPDZ128rmkz = 3393,

        VANDPDZ128rr = 3394,

        VANDPDZ128rrk = 3395,

        VANDPDZ128rrkz = 3396,

        VANDPDZ256rm = 3397,

        VANDPDZ256rmb = 3398,

        VANDPDZ256rmbk = 3399,

        VANDPDZ256rmbkz = 3400,

        VANDPDZ256rmk = 3401,

        VANDPDZ256rmkz = 3402,

        VANDPDZ256rr = 3403,

        VANDPDZ256rrk = 3404,

        VANDPDZ256rrkz = 3405,

        VANDPDZrm = 3406,

        VANDPDZrmb = 3407,

        VANDPDZrmbk = 3408,

        VANDPDZrmbkz = 3409,

        VANDPDZrmk = 3410,

        VANDPDZrmkz = 3411,

        VANDPDZrr = 3412,

        VANDPDZrrk = 3413,

        VANDPDZrrkz = 3414,

        VANDPDrm = 3415,

        VANDPDrr = 3416,

        VANDPSYrm = 3417,

        VANDPSYrr = 3418,

        VANDPSZ128rm = 3419,

        VANDPSZ128rmb = 3420,

        VANDPSZ128rmbk = 3421,

        VANDPSZ128rmbkz = 3422,

        VANDPSZ128rmk = 3423,

        VANDPSZ128rmkz = 3424,

        VANDPSZ128rr = 3425,

        VANDPSZ128rrk = 3426,

        VANDPSZ128rrkz = 3427,

        VANDPSZ256rm = 3428,

        VANDPSZ256rmb = 3429,

        VANDPSZ256rmbk = 3430,

        VANDPSZ256rmbkz = 3431,

        VANDPSZ256rmk = 3432,

        VANDPSZ256rmkz = 3433,

        VANDPSZ256rr = 3434,

        VANDPSZ256rrk = 3435,

        VANDPSZ256rrkz = 3436,

        VANDPSZrm = 3437,

        VANDPSZrmb = 3438,

        VANDPSZrmbk = 3439,

        VANDPSZrmbkz = 3440,

        VANDPSZrmk = 3441,

        VANDPSZrmkz = 3442,

        VANDPSZrr = 3443,

        VANDPSZrrk = 3444,

        VANDPSZrrkz = 3445,

        VANDPSrm = 3446,

        VANDPSrr = 3447,

        VASTART_SAVE_XMM_REGS = 3448,

        VBLENDMPDZ128rm = 3449,

        VBLENDMPDZ128rmb = 3450,

        VBLENDMPDZ128rmbk = 3451,

        VBLENDMPDZ128rmbkz = 3452,

        VBLENDMPDZ128rmk = 3453,

        VBLENDMPDZ128rmkz = 3454,

        VBLENDMPDZ128rr = 3455,

        VBLENDMPDZ128rrk = 3456,

        VBLENDMPDZ128rrkz = 3457,

        VBLENDMPDZ256rm = 3458,

        VBLENDMPDZ256rmb = 3459,

        VBLENDMPDZ256rmbk = 3460,

        VBLENDMPDZ256rmbkz = 3461,

        VBLENDMPDZ256rmk = 3462,

        VBLENDMPDZ256rmkz = 3463,

        VBLENDMPDZ256rr = 3464,

        VBLENDMPDZ256rrk = 3465,

        VBLENDMPDZ256rrkz = 3466,

        VBLENDMPDZrm = 3467,

        VBLENDMPDZrmb = 3468,

        VBLENDMPDZrmbk = 3469,

        VBLENDMPDZrmbkz = 3470,

        VBLENDMPDZrmk = 3471,

        VBLENDMPDZrmkz = 3472,

        VBLENDMPDZrr = 3473,

        VBLENDMPDZrrk = 3474,

        VBLENDMPDZrrkz = 3475,

        VBLENDMPSZ128rm = 3476,

        VBLENDMPSZ128rmb = 3477,

        VBLENDMPSZ128rmbk = 3478,

        VBLENDMPSZ128rmbkz = 3479,

        VBLENDMPSZ128rmk = 3480,

        VBLENDMPSZ128rmkz = 3481,

        VBLENDMPSZ128rr = 3482,

        VBLENDMPSZ128rrk = 3483,

        VBLENDMPSZ128rrkz = 3484,

        VBLENDMPSZ256rm = 3485,

        VBLENDMPSZ256rmb = 3486,

        VBLENDMPSZ256rmbk = 3487,

        VBLENDMPSZ256rmbkz = 3488,

        VBLENDMPSZ256rmk = 3489,

        VBLENDMPSZ256rmkz = 3490,

        VBLENDMPSZ256rr = 3491,

        VBLENDMPSZ256rrk = 3492,

        VBLENDMPSZ256rrkz = 3493,

        VBLENDMPSZrm = 3494,

        VBLENDMPSZrmb = 3495,

        VBLENDMPSZrmbk = 3496,

        VBLENDMPSZrmbkz = 3497,

        VBLENDMPSZrmk = 3498,

        VBLENDMPSZrmkz = 3499,

        VBLENDMPSZrr = 3500,

        VBLENDMPSZrrk = 3501,

        VBLENDMPSZrrkz = 3502,

        VBLENDPDYrmi = 3503,

        VBLENDPDYrri = 3504,

        VBLENDPDrmi = 3505,

        VBLENDPDrri = 3506,

        VBLENDPSYrmi = 3507,

        VBLENDPSYrri = 3508,

        VBLENDPSrmi = 3509,

        VBLENDPSrri = 3510,

        VBLENDVPDYrm = 3511,

        VBLENDVPDYrr = 3512,

        VBLENDVPDrm = 3513,

        VBLENDVPDrr = 3514,

        VBLENDVPSYrm = 3515,

        VBLENDVPSYrr = 3516,

        VBLENDVPSrm = 3517,

        VBLENDVPSrr = 3518,

        VBROADCASTF128 = 3519,

        VBROADCASTF32X2Z256rm = 3520,

        VBROADCASTF32X2Z256rmk = 3521,

        VBROADCASTF32X2Z256rmkz = 3522,

        VBROADCASTF32X2Z256rr = 3523,

        VBROADCASTF32X2Z256rrk = 3524,

        VBROADCASTF32X2Z256rrkz = 3525,

        VBROADCASTF32X2Zrm = 3526,

        VBROADCASTF32X2Zrmk = 3527,

        VBROADCASTF32X2Zrmkz = 3528,

        VBROADCASTF32X2Zrr = 3529,

        VBROADCASTF32X2Zrrk = 3530,

        VBROADCASTF32X2Zrrkz = 3531,

        VBROADCASTF32X4Z256rm = 3532,

        VBROADCASTF32X4Z256rmk = 3533,

        VBROADCASTF32X4Z256rmkz = 3534,

        VBROADCASTF32X4rm = 3535,

        VBROADCASTF32X4rmk = 3536,

        VBROADCASTF32X4rmkz = 3537,

        VBROADCASTF32X8rm = 3538,

        VBROADCASTF32X8rmk = 3539,

        VBROADCASTF32X8rmkz = 3540,

        VBROADCASTF64X2Z128rm = 3541,

        VBROADCASTF64X2Z128rmk = 3542,

        VBROADCASTF64X2Z128rmkz = 3543,

        VBROADCASTF64X2rm = 3544,

        VBROADCASTF64X2rmk = 3545,

        VBROADCASTF64X2rmkz = 3546,

        VBROADCASTF64X4rm = 3547,

        VBROADCASTF64X4rmk = 3548,

        VBROADCASTF64X4rmkz = 3549,

        VBROADCASTI128 = 3550,

        VBROADCASTI32X2Z128rm = 3551,

        VBROADCASTI32X2Z128rmk = 3552,

        VBROADCASTI32X2Z128rmkz = 3553,

        VBROADCASTI32X2Z128rr = 3554,

        VBROADCASTI32X2Z128rrk = 3555,

        VBROADCASTI32X2Z128rrkz = 3556,

        VBROADCASTI32X2Z256rm = 3557,

        VBROADCASTI32X2Z256rmk = 3558,

        VBROADCASTI32X2Z256rmkz = 3559,

        VBROADCASTI32X2Z256rr = 3560,

        VBROADCASTI32X2Z256rrk = 3561,

        VBROADCASTI32X2Z256rrkz = 3562,

        VBROADCASTI32X2Zrm = 3563,

        VBROADCASTI32X2Zrmk = 3564,

        VBROADCASTI32X2Zrmkz = 3565,

        VBROADCASTI32X2Zrr = 3566,

        VBROADCASTI32X2Zrrk = 3567,

        VBROADCASTI32X2Zrrkz = 3568,

        VBROADCASTI32X4Z256rm = 3569,

        VBROADCASTI32X4Z256rmk = 3570,

        VBROADCASTI32X4Z256rmkz = 3571,

        VBROADCASTI32X4rm = 3572,

        VBROADCASTI32X4rmk = 3573,

        VBROADCASTI32X4rmkz = 3574,

        VBROADCASTI32X8rm = 3575,

        VBROADCASTI32X8rmk = 3576,

        VBROADCASTI32X8rmkz = 3577,

        VBROADCASTI64X2Z128rm = 3578,

        VBROADCASTI64X2Z128rmk = 3579,

        VBROADCASTI64X2Z128rmkz = 3580,

        VBROADCASTI64X2rm = 3581,

        VBROADCASTI64X2rmk = 3582,

        VBROADCASTI64X2rmkz = 3583,

        VBROADCASTI64X4rm = 3584,

        VBROADCASTI64X4rmk = 3585,

        VBROADCASTI64X4rmkz = 3586,

        VBROADCASTSDYrm = 3587,

        VBROADCASTSDYrr = 3588,

        VBROADCASTSDZ256rm = 3589,

        VBROADCASTSDZ256rmk = 3590,

        VBROADCASTSDZ256rmkz = 3591,

        VBROADCASTSDZ256rr = 3592,

        VBROADCASTSDZ256rrk = 3593,

        VBROADCASTSDZ256rrkz = 3594,

        VBROADCASTSDZrm = 3595,

        VBROADCASTSDZrmk = 3596,

        VBROADCASTSDZrmkz = 3597,

        VBROADCASTSDZrr = 3598,

        VBROADCASTSDZrrk = 3599,

        VBROADCASTSDZrrkz = 3600,

        VBROADCASTSSYrm = 3601,

        VBROADCASTSSYrr = 3602,

        VBROADCASTSSZ128rm = 3603,

        VBROADCASTSSZ128rmk = 3604,

        VBROADCASTSSZ128rmkz = 3605,

        VBROADCASTSSZ128rr = 3606,

        VBROADCASTSSZ128rrk = 3607,

        VBROADCASTSSZ128rrkz = 3608,

        VBROADCASTSSZ256rm = 3609,

        VBROADCASTSSZ256rmk = 3610,

        VBROADCASTSSZ256rmkz = 3611,

        VBROADCASTSSZ256rr = 3612,

        VBROADCASTSSZ256rrk = 3613,

        VBROADCASTSSZ256rrkz = 3614,

        VBROADCASTSSZrm = 3615,

        VBROADCASTSSZrmk = 3616,

        VBROADCASTSSZrmkz = 3617,

        VBROADCASTSSZrr = 3618,

        VBROADCASTSSZrrk = 3619,

        VBROADCASTSSZrrkz = 3620,

        VBROADCASTSSrm = 3621,

        VBROADCASTSSrr = 3622,

        VCMPPDYrmi = 3623,

        VCMPPDYrri = 3624,

        VCMPPDZ128rmbi = 3625,

        VCMPPDZ128rmbik = 3626,

        VCMPPDZ128rmi = 3627,

        VCMPPDZ128rmik = 3628,

        VCMPPDZ128rri = 3629,

        VCMPPDZ128rrik = 3630,

        VCMPPDZ256rmbi = 3631,

        VCMPPDZ256rmbik = 3632,

        VCMPPDZ256rmi = 3633,

        VCMPPDZ256rmik = 3634,

        VCMPPDZ256rri = 3635,

        VCMPPDZ256rrik = 3636,

        VCMPPDZrmbi = 3637,

        VCMPPDZrmbik = 3638,

        VCMPPDZrmi = 3639,

        VCMPPDZrmik = 3640,

        VCMPPDZrri = 3641,

        VCMPPDZrrib = 3642,

        VCMPPDZrribk = 3643,

        VCMPPDZrrik = 3644,

        VCMPPDrmi = 3645,

        VCMPPDrri = 3646,

        VCMPPSYrmi = 3647,

        VCMPPSYrri = 3648,

        VCMPPSZ128rmbi = 3649,

        VCMPPSZ128rmbik = 3650,

        VCMPPSZ128rmi = 3651,

        VCMPPSZ128rmik = 3652,

        VCMPPSZ128rri = 3653,

        VCMPPSZ128rrik = 3654,

        VCMPPSZ256rmbi = 3655,

        VCMPPSZ256rmbik = 3656,

        VCMPPSZ256rmi = 3657,

        VCMPPSZ256rmik = 3658,

        VCMPPSZ256rri = 3659,

        VCMPPSZ256rrik = 3660,

        VCMPPSZrmbi = 3661,

        VCMPPSZrmbik = 3662,

        VCMPPSZrmi = 3663,

        VCMPPSZrmik = 3664,

        VCMPPSZrri = 3665,

        VCMPPSZrrib = 3666,

        VCMPPSZrribk = 3667,

        VCMPPSZrrik = 3668,

        VCMPPSrmi = 3669,

        VCMPPSrri = 3670,

        VCMPSDZrm = 3671,

        VCMPSDZrm_Int = 3672,

        VCMPSDZrm_Intk = 3673,

        VCMPSDZrr = 3674,

        VCMPSDZrr_Int = 3675,

        VCMPSDZrr_Intk = 3676,

        VCMPSDZrrb_Int = 3677,

        VCMPSDZrrb_Intk = 3678,

        VCMPSDrm = 3679,

        VCMPSDrm_Int = 3680,

        VCMPSDrr = 3681,

        VCMPSDrr_Int = 3682,

        VCMPSSZrm = 3683,

        VCMPSSZrm_Int = 3684,

        VCMPSSZrm_Intk = 3685,

        VCMPSSZrr = 3686,

        VCMPSSZrr_Int = 3687,

        VCMPSSZrr_Intk = 3688,

        VCMPSSZrrb_Int = 3689,

        VCMPSSZrrb_Intk = 3690,

        VCMPSSrm = 3691,

        VCMPSSrm_Int = 3692,

        VCMPSSrr = 3693,

        VCMPSSrr_Int = 3694,

        VCOMISDZrm = 3695,

        VCOMISDZrm_Int = 3696,

        VCOMISDZrr = 3697,

        VCOMISDZrr_Int = 3698,

        VCOMISDZrrb = 3699,

        VCOMISDrm = 3700,

        VCOMISDrm_Int = 3701,

        VCOMISDrr = 3702,

        VCOMISDrr_Int = 3703,

        VCOMISSZrm = 3704,

        VCOMISSZrm_Int = 3705,

        VCOMISSZrr = 3706,

        VCOMISSZrr_Int = 3707,

        VCOMISSZrrb = 3708,

        VCOMISSrm = 3709,

        VCOMISSrm_Int = 3710,

        VCOMISSrr = 3711,

        VCOMISSrr_Int = 3712,

        VCOMPRESSPDZ128mr = 3713,

        VCOMPRESSPDZ128mrk = 3714,

        VCOMPRESSPDZ128rr = 3715,

        VCOMPRESSPDZ128rrk = 3716,

        VCOMPRESSPDZ128rrkz = 3717,

        VCOMPRESSPDZ256mr = 3718,

        VCOMPRESSPDZ256mrk = 3719,

        VCOMPRESSPDZ256rr = 3720,

        VCOMPRESSPDZ256rrk = 3721,

        VCOMPRESSPDZ256rrkz = 3722,

        VCOMPRESSPDZmr = 3723,

        VCOMPRESSPDZmrk = 3724,

        VCOMPRESSPDZrr = 3725,

        VCOMPRESSPDZrrk = 3726,

        VCOMPRESSPDZrrkz = 3727,

        VCOMPRESSPSZ128mr = 3728,

        VCOMPRESSPSZ128mrk = 3729,

        VCOMPRESSPSZ128rr = 3730,

        VCOMPRESSPSZ128rrk = 3731,

        VCOMPRESSPSZ128rrkz = 3732,

        VCOMPRESSPSZ256mr = 3733,

        VCOMPRESSPSZ256mrk = 3734,

        VCOMPRESSPSZ256rr = 3735,

        VCOMPRESSPSZ256rrk = 3736,

        VCOMPRESSPSZ256rrkz = 3737,

        VCOMPRESSPSZmr = 3738,

        VCOMPRESSPSZmrk = 3739,

        VCOMPRESSPSZrr = 3740,

        VCOMPRESSPSZrrk = 3741,

        VCOMPRESSPSZrrkz = 3742,

        VCVTDQ2PDYrm = 3743,

        VCVTDQ2PDYrr = 3744,

        VCVTDQ2PDZ128rm = 3745,

        VCVTDQ2PDZ128rmb = 3746,

        VCVTDQ2PDZ128rmbk = 3747,

        VCVTDQ2PDZ128rmbkz = 3748,

        VCVTDQ2PDZ128rmk = 3749,

        VCVTDQ2PDZ128rmkz = 3750,

        VCVTDQ2PDZ128rr = 3751,

        VCVTDQ2PDZ128rrk = 3752,

        VCVTDQ2PDZ128rrkz = 3753,

        VCVTDQ2PDZ256rm = 3754,

        VCVTDQ2PDZ256rmb = 3755,

        VCVTDQ2PDZ256rmbk = 3756,

        VCVTDQ2PDZ256rmbkz = 3757,

        VCVTDQ2PDZ256rmk = 3758,

        VCVTDQ2PDZ256rmkz = 3759,

        VCVTDQ2PDZ256rr = 3760,

        VCVTDQ2PDZ256rrk = 3761,

        VCVTDQ2PDZ256rrkz = 3762,

        VCVTDQ2PDZrm = 3763,

        VCVTDQ2PDZrmb = 3764,

        VCVTDQ2PDZrmbk = 3765,

        VCVTDQ2PDZrmbkz = 3766,

        VCVTDQ2PDZrmk = 3767,

        VCVTDQ2PDZrmkz = 3768,

        VCVTDQ2PDZrr = 3769,

        VCVTDQ2PDZrrk = 3770,

        VCVTDQ2PDZrrkz = 3771,

        VCVTDQ2PDrm = 3772,

        VCVTDQ2PDrr = 3773,

        VCVTDQ2PSYrm = 3774,

        VCVTDQ2PSYrr = 3775,

        VCVTDQ2PSZ128rm = 3776,

        VCVTDQ2PSZ128rmb = 3777,

        VCVTDQ2PSZ128rmbk = 3778,

        VCVTDQ2PSZ128rmbkz = 3779,

        VCVTDQ2PSZ128rmk = 3780,

        VCVTDQ2PSZ128rmkz = 3781,

        VCVTDQ2PSZ128rr = 3782,

        VCVTDQ2PSZ128rrk = 3783,

        VCVTDQ2PSZ128rrkz = 3784,

        VCVTDQ2PSZ256rm = 3785,

        VCVTDQ2PSZ256rmb = 3786,

        VCVTDQ2PSZ256rmbk = 3787,

        VCVTDQ2PSZ256rmbkz = 3788,

        VCVTDQ2PSZ256rmk = 3789,

        VCVTDQ2PSZ256rmkz = 3790,

        VCVTDQ2PSZ256rr = 3791,

        VCVTDQ2PSZ256rrk = 3792,

        VCVTDQ2PSZ256rrkz = 3793,

        VCVTDQ2PSZrm = 3794,

        VCVTDQ2PSZrmb = 3795,

        VCVTDQ2PSZrmbk = 3796,

        VCVTDQ2PSZrmbkz = 3797,

        VCVTDQ2PSZrmk = 3798,

        VCVTDQ2PSZrmkz = 3799,

        VCVTDQ2PSZrr = 3800,

        VCVTDQ2PSZrrb = 3801,

        VCVTDQ2PSZrrbk = 3802,

        VCVTDQ2PSZrrbkz = 3803,

        VCVTDQ2PSZrrk = 3804,

        VCVTDQ2PSZrrkz = 3805,

        VCVTDQ2PSrm = 3806,

        VCVTDQ2PSrr = 3807,

        VCVTNE2PS2BF16Z128rm = 3808,

        VCVTNE2PS2BF16Z128rmb = 3809,

        VCVTNE2PS2BF16Z128rmbk = 3810,

        VCVTNE2PS2BF16Z128rmbkz = 3811,

        VCVTNE2PS2BF16Z128rmk = 3812,

        VCVTNE2PS2BF16Z128rmkz = 3813,

        VCVTNE2PS2BF16Z128rr = 3814,

        VCVTNE2PS2BF16Z128rrk = 3815,

        VCVTNE2PS2BF16Z128rrkz = 3816,

        VCVTNE2PS2BF16Z256rm = 3817,

        VCVTNE2PS2BF16Z256rmb = 3818,

        VCVTNE2PS2BF16Z256rmbk = 3819,

        VCVTNE2PS2BF16Z256rmbkz = 3820,

        VCVTNE2PS2BF16Z256rmk = 3821,

        VCVTNE2PS2BF16Z256rmkz = 3822,

        VCVTNE2PS2BF16Z256rr = 3823,

        VCVTNE2PS2BF16Z256rrk = 3824,

        VCVTNE2PS2BF16Z256rrkz = 3825,

        VCVTNE2PS2BF16Zrm = 3826,

        VCVTNE2PS2BF16Zrmb = 3827,

        VCVTNE2PS2BF16Zrmbk = 3828,

        VCVTNE2PS2BF16Zrmbkz = 3829,

        VCVTNE2PS2BF16Zrmk = 3830,

        VCVTNE2PS2BF16Zrmkz = 3831,

        VCVTNE2PS2BF16Zrr = 3832,

        VCVTNE2PS2BF16Zrrk = 3833,

        VCVTNE2PS2BF16Zrrkz = 3834,

        VCVTNEPS2BF16Z128rm = 3835,

        VCVTNEPS2BF16Z128rmb = 3836,

        VCVTNEPS2BF16Z128rmbk = 3837,

        VCVTNEPS2BF16Z128rmbkz = 3838,

        VCVTNEPS2BF16Z128rmk = 3839,

        VCVTNEPS2BF16Z128rmkz = 3840,

        VCVTNEPS2BF16Z128rr = 3841,

        VCVTNEPS2BF16Z128rrk = 3842,

        VCVTNEPS2BF16Z128rrkz = 3843,

        VCVTNEPS2BF16Z256rm = 3844,

        VCVTNEPS2BF16Z256rmb = 3845,

        VCVTNEPS2BF16Z256rmbk = 3846,

        VCVTNEPS2BF16Z256rmbkz = 3847,

        VCVTNEPS2BF16Z256rmk = 3848,

        VCVTNEPS2BF16Z256rmkz = 3849,

        VCVTNEPS2BF16Z256rr = 3850,

        VCVTNEPS2BF16Z256rrk = 3851,

        VCVTNEPS2BF16Z256rrkz = 3852,

        VCVTNEPS2BF16Zrm = 3853,

        VCVTNEPS2BF16Zrmb = 3854,

        VCVTNEPS2BF16Zrmbk = 3855,

        VCVTNEPS2BF16Zrmbkz = 3856,

        VCVTNEPS2BF16Zrmk = 3857,

        VCVTNEPS2BF16Zrmkz = 3858,

        VCVTNEPS2BF16Zrr = 3859,

        VCVTNEPS2BF16Zrrk = 3860,

        VCVTNEPS2BF16Zrrkz = 3861,

        VCVTPD2DQYrm = 3862,

        VCVTPD2DQYrr = 3863,

        VCVTPD2DQZ128rm = 3864,

        VCVTPD2DQZ128rmb = 3865,

        VCVTPD2DQZ128rmbk = 3866,

        VCVTPD2DQZ128rmbkz = 3867,

        VCVTPD2DQZ128rmk = 3868,

        VCVTPD2DQZ128rmkz = 3869,

        VCVTPD2DQZ128rr = 3870,

        VCVTPD2DQZ128rrk = 3871,

        VCVTPD2DQZ128rrkz = 3872,

        VCVTPD2DQZ256rm = 3873,

        VCVTPD2DQZ256rmb = 3874,

        VCVTPD2DQZ256rmbk = 3875,

        VCVTPD2DQZ256rmbkz = 3876,

        VCVTPD2DQZ256rmk = 3877,

        VCVTPD2DQZ256rmkz = 3878,

        VCVTPD2DQZ256rr = 3879,

        VCVTPD2DQZ256rrk = 3880,

        VCVTPD2DQZ256rrkz = 3881,

        VCVTPD2DQZrm = 3882,

        VCVTPD2DQZrmb = 3883,

        VCVTPD2DQZrmbk = 3884,

        VCVTPD2DQZrmbkz = 3885,

        VCVTPD2DQZrmk = 3886,

        VCVTPD2DQZrmkz = 3887,

        VCVTPD2DQZrr = 3888,

        VCVTPD2DQZrrb = 3889,

        VCVTPD2DQZrrbk = 3890,

        VCVTPD2DQZrrbkz = 3891,

        VCVTPD2DQZrrk = 3892,

        VCVTPD2DQZrrkz = 3893,

        VCVTPD2DQrm = 3894,

        VCVTPD2DQrr = 3895,

        VCVTPD2PSYrm = 3896,

        VCVTPD2PSYrr = 3897,

        VCVTPD2PSZ128rm = 3898,

        VCVTPD2PSZ128rmb = 3899,

        VCVTPD2PSZ128rmbk = 3900,

        VCVTPD2PSZ128rmbkz = 3901,

        VCVTPD2PSZ128rmk = 3902,

        VCVTPD2PSZ128rmkz = 3903,

        VCVTPD2PSZ128rr = 3904,

        VCVTPD2PSZ128rrk = 3905,

        VCVTPD2PSZ128rrkz = 3906,

        VCVTPD2PSZ256rm = 3907,

        VCVTPD2PSZ256rmb = 3908,

        VCVTPD2PSZ256rmbk = 3909,

        VCVTPD2PSZ256rmbkz = 3910,

        VCVTPD2PSZ256rmk = 3911,

        VCVTPD2PSZ256rmkz = 3912,

        VCVTPD2PSZ256rr = 3913,

        VCVTPD2PSZ256rrk = 3914,

        VCVTPD2PSZ256rrkz = 3915,

        VCVTPD2PSZrm = 3916,

        VCVTPD2PSZrmb = 3917,

        VCVTPD2PSZrmbk = 3918,

        VCVTPD2PSZrmbkz = 3919,

        VCVTPD2PSZrmk = 3920,

        VCVTPD2PSZrmkz = 3921,

        VCVTPD2PSZrr = 3922,

        VCVTPD2PSZrrb = 3923,

        VCVTPD2PSZrrbk = 3924,

        VCVTPD2PSZrrbkz = 3925,

        VCVTPD2PSZrrk = 3926,

        VCVTPD2PSZrrkz = 3927,

        VCVTPD2PSrm = 3928,

        VCVTPD2PSrr = 3929,

        VCVTPD2QQZ128rm = 3930,

        VCVTPD2QQZ128rmb = 3931,

        VCVTPD2QQZ128rmbk = 3932,

        VCVTPD2QQZ128rmbkz = 3933,

        VCVTPD2QQZ128rmk = 3934,

        VCVTPD2QQZ128rmkz = 3935,

        VCVTPD2QQZ128rr = 3936,

        VCVTPD2QQZ128rrk = 3937,

        VCVTPD2QQZ128rrkz = 3938,

        VCVTPD2QQZ256rm = 3939,

        VCVTPD2QQZ256rmb = 3940,

        VCVTPD2QQZ256rmbk = 3941,

        VCVTPD2QQZ256rmbkz = 3942,

        VCVTPD2QQZ256rmk = 3943,

        VCVTPD2QQZ256rmkz = 3944,

        VCVTPD2QQZ256rr = 3945,

        VCVTPD2QQZ256rrk = 3946,

        VCVTPD2QQZ256rrkz = 3947,

        VCVTPD2QQZrm = 3948,

        VCVTPD2QQZrmb = 3949,

        VCVTPD2QQZrmbk = 3950,

        VCVTPD2QQZrmbkz = 3951,

        VCVTPD2QQZrmk = 3952,

        VCVTPD2QQZrmkz = 3953,

        VCVTPD2QQZrr = 3954,

        VCVTPD2QQZrrb = 3955,

        VCVTPD2QQZrrbk = 3956,

        VCVTPD2QQZrrbkz = 3957,

        VCVTPD2QQZrrk = 3958,

        VCVTPD2QQZrrkz = 3959,

        VCVTPD2UDQZ128rm = 3960,

        VCVTPD2UDQZ128rmb = 3961,

        VCVTPD2UDQZ128rmbk = 3962,

        VCVTPD2UDQZ128rmbkz = 3963,

        VCVTPD2UDQZ128rmk = 3964,

        VCVTPD2UDQZ128rmkz = 3965,

        VCVTPD2UDQZ128rr = 3966,

        VCVTPD2UDQZ128rrk = 3967,

        VCVTPD2UDQZ128rrkz = 3968,

        VCVTPD2UDQZ256rm = 3969,

        VCVTPD2UDQZ256rmb = 3970,

        VCVTPD2UDQZ256rmbk = 3971,

        VCVTPD2UDQZ256rmbkz = 3972,

        VCVTPD2UDQZ256rmk = 3973,

        VCVTPD2UDQZ256rmkz = 3974,

        VCVTPD2UDQZ256rr = 3975,

        VCVTPD2UDQZ256rrk = 3976,

        VCVTPD2UDQZ256rrkz = 3977,

        VCVTPD2UDQZrm = 3978,

        VCVTPD2UDQZrmb = 3979,

        VCVTPD2UDQZrmbk = 3980,

        VCVTPD2UDQZrmbkz = 3981,

        VCVTPD2UDQZrmk = 3982,

        VCVTPD2UDQZrmkz = 3983,

        VCVTPD2UDQZrr = 3984,

        VCVTPD2UDQZrrb = 3985,

        VCVTPD2UDQZrrbk = 3986,

        VCVTPD2UDQZrrbkz = 3987,

        VCVTPD2UDQZrrk = 3988,

        VCVTPD2UDQZrrkz = 3989,

        VCVTPD2UQQZ128rm = 3990,

        VCVTPD2UQQZ128rmb = 3991,

        VCVTPD2UQQZ128rmbk = 3992,

        VCVTPD2UQQZ128rmbkz = 3993,

        VCVTPD2UQQZ128rmk = 3994,

        VCVTPD2UQQZ128rmkz = 3995,

        VCVTPD2UQQZ128rr = 3996,

        VCVTPD2UQQZ128rrk = 3997,

        VCVTPD2UQQZ128rrkz = 3998,

        VCVTPD2UQQZ256rm = 3999,

        VCVTPD2UQQZ256rmb = 4000,

        VCVTPD2UQQZ256rmbk = 4001,

        VCVTPD2UQQZ256rmbkz = 4002,

        VCVTPD2UQQZ256rmk = 4003,

        VCVTPD2UQQZ256rmkz = 4004,

        VCVTPD2UQQZ256rr = 4005,

        VCVTPD2UQQZ256rrk = 4006,

        VCVTPD2UQQZ256rrkz = 4007,

        VCVTPD2UQQZrm = 4008,

        VCVTPD2UQQZrmb = 4009,

        VCVTPD2UQQZrmbk = 4010,

        VCVTPD2UQQZrmbkz = 4011,

        VCVTPD2UQQZrmk = 4012,

        VCVTPD2UQQZrmkz = 4013,

        VCVTPD2UQQZrr = 4014,

        VCVTPD2UQQZrrb = 4015,

        VCVTPD2UQQZrrbk = 4016,

        VCVTPD2UQQZrrbkz = 4017,

        VCVTPD2UQQZrrk = 4018,

        VCVTPD2UQQZrrkz = 4019,

        VCVTPH2PSYrm = 4020,

        VCVTPH2PSYrr = 4021,

        VCVTPH2PSZ128rm = 4022,

        VCVTPH2PSZ128rmk = 4023,

        VCVTPH2PSZ128rmkz = 4024,

        VCVTPH2PSZ128rr = 4025,

        VCVTPH2PSZ128rrk = 4026,

        VCVTPH2PSZ128rrkz = 4027,

        VCVTPH2PSZ256rm = 4028,

        VCVTPH2PSZ256rmk = 4029,

        VCVTPH2PSZ256rmkz = 4030,

        VCVTPH2PSZ256rr = 4031,

        VCVTPH2PSZ256rrk = 4032,

        VCVTPH2PSZ256rrkz = 4033,

        VCVTPH2PSZrm = 4034,

        VCVTPH2PSZrmk = 4035,

        VCVTPH2PSZrmkz = 4036,

        VCVTPH2PSZrr = 4037,

        VCVTPH2PSZrrb = 4038,

        VCVTPH2PSZrrbk = 4039,

        VCVTPH2PSZrrbkz = 4040,

        VCVTPH2PSZrrk = 4041,

        VCVTPH2PSZrrkz = 4042,

        VCVTPH2PSrm = 4043,

        VCVTPH2PSrr = 4044,

        VCVTPS2DQYrm = 4045,

        VCVTPS2DQYrr = 4046,

        VCVTPS2DQZ128rm = 4047,

        VCVTPS2DQZ128rmb = 4048,

        VCVTPS2DQZ128rmbk = 4049,

        VCVTPS2DQZ128rmbkz = 4050,

        VCVTPS2DQZ128rmk = 4051,

        VCVTPS2DQZ128rmkz = 4052,

        VCVTPS2DQZ128rr = 4053,

        VCVTPS2DQZ128rrk = 4054,

        VCVTPS2DQZ128rrkz = 4055,

        VCVTPS2DQZ256rm = 4056,

        VCVTPS2DQZ256rmb = 4057,

        VCVTPS2DQZ256rmbk = 4058,

        VCVTPS2DQZ256rmbkz = 4059,

        VCVTPS2DQZ256rmk = 4060,

        VCVTPS2DQZ256rmkz = 4061,

        VCVTPS2DQZ256rr = 4062,

        VCVTPS2DQZ256rrk = 4063,

        VCVTPS2DQZ256rrkz = 4064,

        VCVTPS2DQZrm = 4065,

        VCVTPS2DQZrmb = 4066,

        VCVTPS2DQZrmbk = 4067,

        VCVTPS2DQZrmbkz = 4068,

        VCVTPS2DQZrmk = 4069,

        VCVTPS2DQZrmkz = 4070,

        VCVTPS2DQZrr = 4071,

        VCVTPS2DQZrrb = 4072,

        VCVTPS2DQZrrbk = 4073,

        VCVTPS2DQZrrbkz = 4074,

        VCVTPS2DQZrrk = 4075,

        VCVTPS2DQZrrkz = 4076,

        VCVTPS2DQrm = 4077,

        VCVTPS2DQrr = 4078,

        VCVTPS2PDYrm = 4079,

        VCVTPS2PDYrr = 4080,

        VCVTPS2PDZ128rm = 4081,

        VCVTPS2PDZ128rmb = 4082,

        VCVTPS2PDZ128rmbk = 4083,

        VCVTPS2PDZ128rmbkz = 4084,

        VCVTPS2PDZ128rmk = 4085,

        VCVTPS2PDZ128rmkz = 4086,

        VCVTPS2PDZ128rr = 4087,

        VCVTPS2PDZ128rrk = 4088,

        VCVTPS2PDZ128rrkz = 4089,

        VCVTPS2PDZ256rm = 4090,

        VCVTPS2PDZ256rmb = 4091,

        VCVTPS2PDZ256rmbk = 4092,

        VCVTPS2PDZ256rmbkz = 4093,

        VCVTPS2PDZ256rmk = 4094,

        VCVTPS2PDZ256rmkz = 4095,

        VCVTPS2PDZ256rr = 4096,

        VCVTPS2PDZ256rrk = 4097,

        VCVTPS2PDZ256rrkz = 4098,

        VCVTPS2PDZrm = 4099,

        VCVTPS2PDZrmb = 4100,

        VCVTPS2PDZrmbk = 4101,

        VCVTPS2PDZrmbkz = 4102,

        VCVTPS2PDZrmk = 4103,

        VCVTPS2PDZrmkz = 4104,

        VCVTPS2PDZrr = 4105,

        VCVTPS2PDZrrb = 4106,

        VCVTPS2PDZrrbk = 4107,

        VCVTPS2PDZrrbkz = 4108,

        VCVTPS2PDZrrk = 4109,

        VCVTPS2PDZrrkz = 4110,

        VCVTPS2PDrm = 4111,

        VCVTPS2PDrr = 4112,

        VCVTPS2PHYmr = 4113,

        VCVTPS2PHYrr = 4114,

        VCVTPS2PHZ128mr = 4115,

        VCVTPS2PHZ128mrk = 4116,

        VCVTPS2PHZ128rr = 4117,

        VCVTPS2PHZ128rrk = 4118,

        VCVTPS2PHZ128rrkz = 4119,

        VCVTPS2PHZ256mr = 4120,

        VCVTPS2PHZ256mrk = 4121,

        VCVTPS2PHZ256rr = 4122,

        VCVTPS2PHZ256rrk = 4123,

        VCVTPS2PHZ256rrkz = 4124,

        VCVTPS2PHZmr = 4125,

        VCVTPS2PHZmrk = 4126,

        VCVTPS2PHZrr = 4127,

        VCVTPS2PHZrrb = 4128,

        VCVTPS2PHZrrbk = 4129,

        VCVTPS2PHZrrbkz = 4130,

        VCVTPS2PHZrrk = 4131,

        VCVTPS2PHZrrkz = 4132,

        VCVTPS2PHmr = 4133,

        VCVTPS2PHrr = 4134,

        VCVTPS2QQZ128rm = 4135,

        VCVTPS2QQZ128rmb = 4136,

        VCVTPS2QQZ128rmbk = 4137,

        VCVTPS2QQZ128rmbkz = 4138,

        VCVTPS2QQZ128rmk = 4139,

        VCVTPS2QQZ128rmkz = 4140,

        VCVTPS2QQZ128rr = 4141,

        VCVTPS2QQZ128rrk = 4142,

        VCVTPS2QQZ128rrkz = 4143,

        VCVTPS2QQZ256rm = 4144,

        VCVTPS2QQZ256rmb = 4145,

        VCVTPS2QQZ256rmbk = 4146,

        VCVTPS2QQZ256rmbkz = 4147,

        VCVTPS2QQZ256rmk = 4148,

        VCVTPS2QQZ256rmkz = 4149,

        VCVTPS2QQZ256rr = 4150,

        VCVTPS2QQZ256rrk = 4151,

        VCVTPS2QQZ256rrkz = 4152,

        VCVTPS2QQZrm = 4153,

        VCVTPS2QQZrmb = 4154,

        VCVTPS2QQZrmbk = 4155,

        VCVTPS2QQZrmbkz = 4156,

        VCVTPS2QQZrmk = 4157,

        VCVTPS2QQZrmkz = 4158,

        VCVTPS2QQZrr = 4159,

        VCVTPS2QQZrrb = 4160,

        VCVTPS2QQZrrbk = 4161,

        VCVTPS2QQZrrbkz = 4162,

        VCVTPS2QQZrrk = 4163,

        VCVTPS2QQZrrkz = 4164,

        VCVTPS2UDQZ128rm = 4165,

        VCVTPS2UDQZ128rmb = 4166,

        VCVTPS2UDQZ128rmbk = 4167,

        VCVTPS2UDQZ128rmbkz = 4168,

        VCVTPS2UDQZ128rmk = 4169,

        VCVTPS2UDQZ128rmkz = 4170,

        VCVTPS2UDQZ128rr = 4171,

        VCVTPS2UDQZ128rrk = 4172,

        VCVTPS2UDQZ128rrkz = 4173,

        VCVTPS2UDQZ256rm = 4174,

        VCVTPS2UDQZ256rmb = 4175,

        VCVTPS2UDQZ256rmbk = 4176,

        VCVTPS2UDQZ256rmbkz = 4177,

        VCVTPS2UDQZ256rmk = 4178,

        VCVTPS2UDQZ256rmkz = 4179,

        VCVTPS2UDQZ256rr = 4180,

        VCVTPS2UDQZ256rrk = 4181,

        VCVTPS2UDQZ256rrkz = 4182,

        VCVTPS2UDQZrm = 4183,

        VCVTPS2UDQZrmb = 4184,

        VCVTPS2UDQZrmbk = 4185,

        VCVTPS2UDQZrmbkz = 4186,

        VCVTPS2UDQZrmk = 4187,

        VCVTPS2UDQZrmkz = 4188,

        VCVTPS2UDQZrr = 4189,

        VCVTPS2UDQZrrb = 4190,

        VCVTPS2UDQZrrbk = 4191,

        VCVTPS2UDQZrrbkz = 4192,

        VCVTPS2UDQZrrk = 4193,

        VCVTPS2UDQZrrkz = 4194,

        VCVTPS2UQQZ128rm = 4195,

        VCVTPS2UQQZ128rmb = 4196,

        VCVTPS2UQQZ128rmbk = 4197,

        VCVTPS2UQQZ128rmbkz = 4198,

        VCVTPS2UQQZ128rmk = 4199,

        VCVTPS2UQQZ128rmkz = 4200,

        VCVTPS2UQQZ128rr = 4201,

        VCVTPS2UQQZ128rrk = 4202,

        VCVTPS2UQQZ128rrkz = 4203,

        VCVTPS2UQQZ256rm = 4204,

        VCVTPS2UQQZ256rmb = 4205,

        VCVTPS2UQQZ256rmbk = 4206,

        VCVTPS2UQQZ256rmbkz = 4207,

        VCVTPS2UQQZ256rmk = 4208,

        VCVTPS2UQQZ256rmkz = 4209,

        VCVTPS2UQQZ256rr = 4210,

        VCVTPS2UQQZ256rrk = 4211,

        VCVTPS2UQQZ256rrkz = 4212,

        VCVTPS2UQQZrm = 4213,

        VCVTPS2UQQZrmb = 4214,

        VCVTPS2UQQZrmbk = 4215,

        VCVTPS2UQQZrmbkz = 4216,

        VCVTPS2UQQZrmk = 4217,

        VCVTPS2UQQZrmkz = 4218,

        VCVTPS2UQQZrr = 4219,

        VCVTPS2UQQZrrb = 4220,

        VCVTPS2UQQZrrbk = 4221,

        VCVTPS2UQQZrrbkz = 4222,

        VCVTPS2UQQZrrk = 4223,

        VCVTPS2UQQZrrkz = 4224,

        VCVTQQ2PDZ128rm = 4225,

        VCVTQQ2PDZ128rmb = 4226,

        VCVTQQ2PDZ128rmbk = 4227,

        VCVTQQ2PDZ128rmbkz = 4228,

        VCVTQQ2PDZ128rmk = 4229,

        VCVTQQ2PDZ128rmkz = 4230,

        VCVTQQ2PDZ128rr = 4231,

        VCVTQQ2PDZ128rrk = 4232,

        VCVTQQ2PDZ128rrkz = 4233,

        VCVTQQ2PDZ256rm = 4234,

        VCVTQQ2PDZ256rmb = 4235,

        VCVTQQ2PDZ256rmbk = 4236,

        VCVTQQ2PDZ256rmbkz = 4237,

        VCVTQQ2PDZ256rmk = 4238,

        VCVTQQ2PDZ256rmkz = 4239,

        VCVTQQ2PDZ256rr = 4240,

        VCVTQQ2PDZ256rrk = 4241,

        VCVTQQ2PDZ256rrkz = 4242,

        VCVTQQ2PDZrm = 4243,

        VCVTQQ2PDZrmb = 4244,

        VCVTQQ2PDZrmbk = 4245,

        VCVTQQ2PDZrmbkz = 4246,

        VCVTQQ2PDZrmk = 4247,

        VCVTQQ2PDZrmkz = 4248,

        VCVTQQ2PDZrr = 4249,

        VCVTQQ2PDZrrb = 4250,

        VCVTQQ2PDZrrbk = 4251,

        VCVTQQ2PDZrrbkz = 4252,

        VCVTQQ2PDZrrk = 4253,

        VCVTQQ2PDZrrkz = 4254,

        VCVTQQ2PSZ128rm = 4255,

        VCVTQQ2PSZ128rmb = 4256,

        VCVTQQ2PSZ128rmbk = 4257,

        VCVTQQ2PSZ128rmbkz = 4258,

        VCVTQQ2PSZ128rmk = 4259,

        VCVTQQ2PSZ128rmkz = 4260,

        VCVTQQ2PSZ128rr = 4261,

        VCVTQQ2PSZ128rrk = 4262,

        VCVTQQ2PSZ128rrkz = 4263,

        VCVTQQ2PSZ256rm = 4264,

        VCVTQQ2PSZ256rmb = 4265,

        VCVTQQ2PSZ256rmbk = 4266,

        VCVTQQ2PSZ256rmbkz = 4267,

        VCVTQQ2PSZ256rmk = 4268,

        VCVTQQ2PSZ256rmkz = 4269,

        VCVTQQ2PSZ256rr = 4270,

        VCVTQQ2PSZ256rrk = 4271,

        VCVTQQ2PSZ256rrkz = 4272,

        VCVTQQ2PSZrm = 4273,

        VCVTQQ2PSZrmb = 4274,

        VCVTQQ2PSZrmbk = 4275,

        VCVTQQ2PSZrmbkz = 4276,

        VCVTQQ2PSZrmk = 4277,

        VCVTQQ2PSZrmkz = 4278,

        VCVTQQ2PSZrr = 4279,

        VCVTQQ2PSZrrb = 4280,

        VCVTQQ2PSZrrbk = 4281,

        VCVTQQ2PSZrrbkz = 4282,

        VCVTQQ2PSZrrk = 4283,

        VCVTQQ2PSZrrkz = 4284,

        VCVTSD2SI64Zrm = 4285,

        VCVTSD2SI64Zrm_Int = 4286,

        VCVTSD2SI64Zrr = 4287,

        VCVTSD2SI64Zrr_Int = 4288,

        VCVTSD2SI64Zrrb_Int = 4289,

        VCVTSD2SI64rm = 4290,

        VCVTSD2SI64rm_Int = 4291,

        VCVTSD2SI64rr = 4292,

        VCVTSD2SI64rr_Int = 4293,

        VCVTSD2SIZrm = 4294,

        VCVTSD2SIZrm_Int = 4295,

        VCVTSD2SIZrr = 4296,

        VCVTSD2SIZrr_Int = 4297,

        VCVTSD2SIZrrb_Int = 4298,

        VCVTSD2SIrm = 4299,

        VCVTSD2SIrm_Int = 4300,

        VCVTSD2SIrr = 4301,

        VCVTSD2SIrr_Int = 4302,

        VCVTSD2SSZrm = 4303,

        VCVTSD2SSZrm_Int = 4304,

        VCVTSD2SSZrm_Intk = 4305,

        VCVTSD2SSZrm_Intkz = 4306,

        VCVTSD2SSZrr = 4307,

        VCVTSD2SSZrr_Int = 4308,

        VCVTSD2SSZrr_Intk = 4309,

        VCVTSD2SSZrr_Intkz = 4310,

        VCVTSD2SSZrrb_Int = 4311,

        VCVTSD2SSZrrb_Intk = 4312,

        VCVTSD2SSZrrb_Intkz = 4313,

        VCVTSD2SSrm = 4314,

        VCVTSD2SSrm_Int = 4315,

        VCVTSD2SSrr = 4316,

        VCVTSD2SSrr_Int = 4317,

        VCVTSD2USI64Zrm_Int = 4318,

        VCVTSD2USI64Zrr_Int = 4319,

        VCVTSD2USI64Zrrb_Int = 4320,

        VCVTSD2USIZrm_Int = 4321,

        VCVTSD2USIZrr_Int = 4322,

        VCVTSD2USIZrrb_Int = 4323,

        VCVTSI2SDZrm = 4324,

        VCVTSI2SDZrm_Int = 4325,

        VCVTSI2SDZrr = 4326,

        VCVTSI2SDZrr_Int = 4327,

        VCVTSI2SDrm = 4328,

        VCVTSI2SDrm_Int = 4329,

        VCVTSI2SDrr = 4330,

        VCVTSI2SDrr_Int = 4331,

        VCVTSI2SSZrm = 4332,

        VCVTSI2SSZrm_Int = 4333,

        VCVTSI2SSZrr = 4334,

        VCVTSI2SSZrr_Int = 4335,

        VCVTSI2SSZrrb_Int = 4336,

        VCVTSI2SSrm = 4337,

        VCVTSI2SSrm_Int = 4338,

        VCVTSI2SSrr = 4339,

        VCVTSI2SSrr_Int = 4340,

        VCVTSI642SDZrm = 4341,

        VCVTSI642SDZrm_Int = 4342,

        VCVTSI642SDZrr = 4343,

        VCVTSI642SDZrr_Int = 4344,

        VCVTSI642SDZrrb_Int = 4345,

        VCVTSI642SDrm = 4346,

        VCVTSI642SDrm_Int = 4347,

        VCVTSI642SDrr = 4348,

        VCVTSI642SDrr_Int = 4349,

        VCVTSI642SSZrm = 4350,

        VCVTSI642SSZrm_Int = 4351,

        VCVTSI642SSZrr = 4352,

        VCVTSI642SSZrr_Int = 4353,

        VCVTSI642SSZrrb_Int = 4354,

        VCVTSI642SSrm = 4355,

        VCVTSI642SSrm_Int = 4356,

        VCVTSI642SSrr = 4357,

        VCVTSI642SSrr_Int = 4358,

        VCVTSS2SDZrm = 4359,

        VCVTSS2SDZrm_Int = 4360,

        VCVTSS2SDZrm_Intk = 4361,

        VCVTSS2SDZrm_Intkz = 4362,

        VCVTSS2SDZrr = 4363,

        VCVTSS2SDZrr_Int = 4364,

        VCVTSS2SDZrr_Intk = 4365,

        VCVTSS2SDZrr_Intkz = 4366,

        VCVTSS2SDZrrb_Int = 4367,

        VCVTSS2SDZrrb_Intk = 4368,

        VCVTSS2SDZrrb_Intkz = 4369,

        VCVTSS2SDrm = 4370,

        VCVTSS2SDrm_Int = 4371,

        VCVTSS2SDrr = 4372,

        VCVTSS2SDrr_Int = 4373,

        VCVTSS2SI64Zrm = 4374,

        VCVTSS2SI64Zrm_Int = 4375,

        VCVTSS2SI64Zrr = 4376,

        VCVTSS2SI64Zrr_Int = 4377,

        VCVTSS2SI64Zrrb_Int = 4378,

        VCVTSS2SI64rm = 4379,

        VCVTSS2SI64rm_Int = 4380,

        VCVTSS2SI64rr = 4381,

        VCVTSS2SI64rr_Int = 4382,

        VCVTSS2SIZrm = 4383,

        VCVTSS2SIZrm_Int = 4384,

        VCVTSS2SIZrr = 4385,

        VCVTSS2SIZrr_Int = 4386,

        VCVTSS2SIZrrb_Int = 4387,

        VCVTSS2SIrm = 4388,

        VCVTSS2SIrm_Int = 4389,

        VCVTSS2SIrr = 4390,

        VCVTSS2SIrr_Int = 4391,

        VCVTSS2USI64Zrm_Int = 4392,

        VCVTSS2USI64Zrr_Int = 4393,

        VCVTSS2USI64Zrrb_Int = 4394,

        VCVTSS2USIZrm_Int = 4395,

        VCVTSS2USIZrr_Int = 4396,

        VCVTSS2USIZrrb_Int = 4397,

        VCVTTPD2DQYrm = 4398,

        VCVTTPD2DQYrr = 4399,

        VCVTTPD2DQZ128rm = 4400,

        VCVTTPD2DQZ128rmb = 4401,

        VCVTTPD2DQZ128rmbk = 4402,

        VCVTTPD2DQZ128rmbkz = 4403,

        VCVTTPD2DQZ128rmk = 4404,

        VCVTTPD2DQZ128rmkz = 4405,

        VCVTTPD2DQZ128rr = 4406,

        VCVTTPD2DQZ128rrk = 4407,

        VCVTTPD2DQZ128rrkz = 4408,

        VCVTTPD2DQZ256rm = 4409,

        VCVTTPD2DQZ256rmb = 4410,

        VCVTTPD2DQZ256rmbk = 4411,

        VCVTTPD2DQZ256rmbkz = 4412,

        VCVTTPD2DQZ256rmk = 4413,

        VCVTTPD2DQZ256rmkz = 4414,

        VCVTTPD2DQZ256rr = 4415,

        VCVTTPD2DQZ256rrk = 4416,

        VCVTTPD2DQZ256rrkz = 4417,

        VCVTTPD2DQZrm = 4418,

        VCVTTPD2DQZrmb = 4419,

        VCVTTPD2DQZrmbk = 4420,

        VCVTTPD2DQZrmbkz = 4421,

        VCVTTPD2DQZrmk = 4422,

        VCVTTPD2DQZrmkz = 4423,

        VCVTTPD2DQZrr = 4424,

        VCVTTPD2DQZrrb = 4425,

        VCVTTPD2DQZrrbk = 4426,

        VCVTTPD2DQZrrbkz = 4427,

        VCVTTPD2DQZrrk = 4428,

        VCVTTPD2DQZrrkz = 4429,

        VCVTTPD2DQrm = 4430,

        VCVTTPD2DQrr = 4431,

        VCVTTPD2QQZ128rm = 4432,

        VCVTTPD2QQZ128rmb = 4433,

        VCVTTPD2QQZ128rmbk = 4434,

        VCVTTPD2QQZ128rmbkz = 4435,

        VCVTTPD2QQZ128rmk = 4436,

        VCVTTPD2QQZ128rmkz = 4437,

        VCVTTPD2QQZ128rr = 4438,

        VCVTTPD2QQZ128rrk = 4439,

        VCVTTPD2QQZ128rrkz = 4440,

        VCVTTPD2QQZ256rm = 4441,

        VCVTTPD2QQZ256rmb = 4442,

        VCVTTPD2QQZ256rmbk = 4443,

        VCVTTPD2QQZ256rmbkz = 4444,

        VCVTTPD2QQZ256rmk = 4445,

        VCVTTPD2QQZ256rmkz = 4446,

        VCVTTPD2QQZ256rr = 4447,

        VCVTTPD2QQZ256rrk = 4448,

        VCVTTPD2QQZ256rrkz = 4449,

        VCVTTPD2QQZrm = 4450,

        VCVTTPD2QQZrmb = 4451,

        VCVTTPD2QQZrmbk = 4452,

        VCVTTPD2QQZrmbkz = 4453,

        VCVTTPD2QQZrmk = 4454,

        VCVTTPD2QQZrmkz = 4455,

        VCVTTPD2QQZrr = 4456,

        VCVTTPD2QQZrrb = 4457,

        VCVTTPD2QQZrrbk = 4458,

        VCVTTPD2QQZrrbkz = 4459,

        VCVTTPD2QQZrrk = 4460,

        VCVTTPD2QQZrrkz = 4461,

        VCVTTPD2UDQZ128rm = 4462,

        VCVTTPD2UDQZ128rmb = 4463,

        VCVTTPD2UDQZ128rmbk = 4464,

        VCVTTPD2UDQZ128rmbkz = 4465,

        VCVTTPD2UDQZ128rmk = 4466,

        VCVTTPD2UDQZ128rmkz = 4467,

        VCVTTPD2UDQZ128rr = 4468,

        VCVTTPD2UDQZ128rrk = 4469,

        VCVTTPD2UDQZ128rrkz = 4470,

        VCVTTPD2UDQZ256rm = 4471,

        VCVTTPD2UDQZ256rmb = 4472,

        VCVTTPD2UDQZ256rmbk = 4473,

        VCVTTPD2UDQZ256rmbkz = 4474,

        VCVTTPD2UDQZ256rmk = 4475,

        VCVTTPD2UDQZ256rmkz = 4476,

        VCVTTPD2UDQZ256rr = 4477,

        VCVTTPD2UDQZ256rrk = 4478,

        VCVTTPD2UDQZ256rrkz = 4479,

        VCVTTPD2UDQZrm = 4480,

        VCVTTPD2UDQZrmb = 4481,

        VCVTTPD2UDQZrmbk = 4482,

        VCVTTPD2UDQZrmbkz = 4483,

        VCVTTPD2UDQZrmk = 4484,

        VCVTTPD2UDQZrmkz = 4485,

        VCVTTPD2UDQZrr = 4486,

        VCVTTPD2UDQZrrb = 4487,

        VCVTTPD2UDQZrrbk = 4488,

        VCVTTPD2UDQZrrbkz = 4489,

        VCVTTPD2UDQZrrk = 4490,

        VCVTTPD2UDQZrrkz = 4491,

        VCVTTPD2UQQZ128rm = 4492,

        VCVTTPD2UQQZ128rmb = 4493,

        VCVTTPD2UQQZ128rmbk = 4494,

        VCVTTPD2UQQZ128rmbkz = 4495,

        VCVTTPD2UQQZ128rmk = 4496,

        VCVTTPD2UQQZ128rmkz = 4497,

        VCVTTPD2UQQZ128rr = 4498,

        VCVTTPD2UQQZ128rrk = 4499,

        VCVTTPD2UQQZ128rrkz = 4500,

        VCVTTPD2UQQZ256rm = 4501,

        VCVTTPD2UQQZ256rmb = 4502,

        VCVTTPD2UQQZ256rmbk = 4503,

        VCVTTPD2UQQZ256rmbkz = 4504,

        VCVTTPD2UQQZ256rmk = 4505,

        VCVTTPD2UQQZ256rmkz = 4506,

        VCVTTPD2UQQZ256rr = 4507,

        VCVTTPD2UQQZ256rrk = 4508,

        VCVTTPD2UQQZ256rrkz = 4509,

        VCVTTPD2UQQZrm = 4510,

        VCVTTPD2UQQZrmb = 4511,

        VCVTTPD2UQQZrmbk = 4512,

        VCVTTPD2UQQZrmbkz = 4513,

        VCVTTPD2UQQZrmk = 4514,

        VCVTTPD2UQQZrmkz = 4515,

        VCVTTPD2UQQZrr = 4516,

        VCVTTPD2UQQZrrb = 4517,

        VCVTTPD2UQQZrrbk = 4518,

        VCVTTPD2UQQZrrbkz = 4519,

        VCVTTPD2UQQZrrk = 4520,

        VCVTTPD2UQQZrrkz = 4521,

        VCVTTPS2DQYrm = 4522,

        VCVTTPS2DQYrr = 4523,

        VCVTTPS2DQZ128rm = 4524,

        VCVTTPS2DQZ128rmb = 4525,

        VCVTTPS2DQZ128rmbk = 4526,

        VCVTTPS2DQZ128rmbkz = 4527,

        VCVTTPS2DQZ128rmk = 4528,

        VCVTTPS2DQZ128rmkz = 4529,

        VCVTTPS2DQZ128rr = 4530,

        VCVTTPS2DQZ128rrk = 4531,

        VCVTTPS2DQZ128rrkz = 4532,

        VCVTTPS2DQZ256rm = 4533,

        VCVTTPS2DQZ256rmb = 4534,

        VCVTTPS2DQZ256rmbk = 4535,

        VCVTTPS2DQZ256rmbkz = 4536,

        VCVTTPS2DQZ256rmk = 4537,

        VCVTTPS2DQZ256rmkz = 4538,

        VCVTTPS2DQZ256rr = 4539,

        VCVTTPS2DQZ256rrk = 4540,

        VCVTTPS2DQZ256rrkz = 4541,

        VCVTTPS2DQZrm = 4542,

        VCVTTPS2DQZrmb = 4543,

        VCVTTPS2DQZrmbk = 4544,

        VCVTTPS2DQZrmbkz = 4545,

        VCVTTPS2DQZrmk = 4546,

        VCVTTPS2DQZrmkz = 4547,

        VCVTTPS2DQZrr = 4548,

        VCVTTPS2DQZrrb = 4549,

        VCVTTPS2DQZrrbk = 4550,

        VCVTTPS2DQZrrbkz = 4551,

        VCVTTPS2DQZrrk = 4552,

        VCVTTPS2DQZrrkz = 4553,

        VCVTTPS2DQrm = 4554,

        VCVTTPS2DQrr = 4555,

        VCVTTPS2QQZ128rm = 4556,

        VCVTTPS2QQZ128rmb = 4557,

        VCVTTPS2QQZ128rmbk = 4558,

        VCVTTPS2QQZ128rmbkz = 4559,

        VCVTTPS2QQZ128rmk = 4560,

        VCVTTPS2QQZ128rmkz = 4561,

        VCVTTPS2QQZ128rr = 4562,

        VCVTTPS2QQZ128rrk = 4563,

        VCVTTPS2QQZ128rrkz = 4564,

        VCVTTPS2QQZ256rm = 4565,

        VCVTTPS2QQZ256rmb = 4566,

        VCVTTPS2QQZ256rmbk = 4567,

        VCVTTPS2QQZ256rmbkz = 4568,

        VCVTTPS2QQZ256rmk = 4569,

        VCVTTPS2QQZ256rmkz = 4570,

        VCVTTPS2QQZ256rr = 4571,

        VCVTTPS2QQZ256rrk = 4572,

        VCVTTPS2QQZ256rrkz = 4573,

        VCVTTPS2QQZrm = 4574,

        VCVTTPS2QQZrmb = 4575,

        VCVTTPS2QQZrmbk = 4576,

        VCVTTPS2QQZrmbkz = 4577,

        VCVTTPS2QQZrmk = 4578,

        VCVTTPS2QQZrmkz = 4579,

        VCVTTPS2QQZrr = 4580,

        VCVTTPS2QQZrrb = 4581,

        VCVTTPS2QQZrrbk = 4582,

        VCVTTPS2QQZrrbkz = 4583,

        VCVTTPS2QQZrrk = 4584,

        VCVTTPS2QQZrrkz = 4585,

        VCVTTPS2UDQZ128rm = 4586,

        VCVTTPS2UDQZ128rmb = 4587,

        VCVTTPS2UDQZ128rmbk = 4588,

        VCVTTPS2UDQZ128rmbkz = 4589,

        VCVTTPS2UDQZ128rmk = 4590,

        VCVTTPS2UDQZ128rmkz = 4591,

        VCVTTPS2UDQZ128rr = 4592,

        VCVTTPS2UDQZ128rrk = 4593,

        VCVTTPS2UDQZ128rrkz = 4594,

        VCVTTPS2UDQZ256rm = 4595,

        VCVTTPS2UDQZ256rmb = 4596,

        VCVTTPS2UDQZ256rmbk = 4597,

        VCVTTPS2UDQZ256rmbkz = 4598,

        VCVTTPS2UDQZ256rmk = 4599,

        VCVTTPS2UDQZ256rmkz = 4600,

        VCVTTPS2UDQZ256rr = 4601,

        VCVTTPS2UDQZ256rrk = 4602,

        VCVTTPS2UDQZ256rrkz = 4603,

        VCVTTPS2UDQZrm = 4604,

        VCVTTPS2UDQZrmb = 4605,

        VCVTTPS2UDQZrmbk = 4606,

        VCVTTPS2UDQZrmbkz = 4607,

        VCVTTPS2UDQZrmk = 4608,

        VCVTTPS2UDQZrmkz = 4609,

        VCVTTPS2UDQZrr = 4610,

        VCVTTPS2UDQZrrb = 4611,

        VCVTTPS2UDQZrrbk = 4612,

        VCVTTPS2UDQZrrbkz = 4613,

        VCVTTPS2UDQZrrk = 4614,

        VCVTTPS2UDQZrrkz = 4615,

        VCVTTPS2UQQZ128rm = 4616,

        VCVTTPS2UQQZ128rmb = 4617,

        VCVTTPS2UQQZ128rmbk = 4618,

        VCVTTPS2UQQZ128rmbkz = 4619,

        VCVTTPS2UQQZ128rmk = 4620,

        VCVTTPS2UQQZ128rmkz = 4621,

        VCVTTPS2UQQZ128rr = 4622,

        VCVTTPS2UQQZ128rrk = 4623,

        VCVTTPS2UQQZ128rrkz = 4624,

        VCVTTPS2UQQZ256rm = 4625,

        VCVTTPS2UQQZ256rmb = 4626,

        VCVTTPS2UQQZ256rmbk = 4627,

        VCVTTPS2UQQZ256rmbkz = 4628,

        VCVTTPS2UQQZ256rmk = 4629,

        VCVTTPS2UQQZ256rmkz = 4630,

        VCVTTPS2UQQZ256rr = 4631,

        VCVTTPS2UQQZ256rrk = 4632,

        VCVTTPS2UQQZ256rrkz = 4633,

        VCVTTPS2UQQZrm = 4634,

        VCVTTPS2UQQZrmb = 4635,

        VCVTTPS2UQQZrmbk = 4636,

        VCVTTPS2UQQZrmbkz = 4637,

        VCVTTPS2UQQZrmk = 4638,

        VCVTTPS2UQQZrmkz = 4639,

        VCVTTPS2UQQZrr = 4640,

        VCVTTPS2UQQZrrb = 4641,

        VCVTTPS2UQQZrrbk = 4642,

        VCVTTPS2UQQZrrbkz = 4643,

        VCVTTPS2UQQZrrk = 4644,

        VCVTTPS2UQQZrrkz = 4645,

        VCVTTSD2SI64Zrm = 4646,

        VCVTTSD2SI64Zrm_Int = 4647,

        VCVTTSD2SI64Zrr = 4648,

        VCVTTSD2SI64Zrr_Int = 4649,

        VCVTTSD2SI64Zrrb_Int = 4650,

        VCVTTSD2SI64rm = 4651,

        VCVTTSD2SI64rm_Int = 4652,

        VCVTTSD2SI64rr = 4653,

        VCVTTSD2SI64rr_Int = 4654,

        VCVTTSD2SIZrm = 4655,

        VCVTTSD2SIZrm_Int = 4656,

        VCVTTSD2SIZrr = 4657,

        VCVTTSD2SIZrr_Int = 4658,

        VCVTTSD2SIZrrb_Int = 4659,

        VCVTTSD2SIrm = 4660,

        VCVTTSD2SIrm_Int = 4661,

        VCVTTSD2SIrr = 4662,

        VCVTTSD2SIrr_Int = 4663,

        VCVTTSD2USI64Zrm = 4664,

        VCVTTSD2USI64Zrm_Int = 4665,

        VCVTTSD2USI64Zrr = 4666,

        VCVTTSD2USI64Zrr_Int = 4667,

        VCVTTSD2USI64Zrrb_Int = 4668,

        VCVTTSD2USIZrm = 4669,

        VCVTTSD2USIZrm_Int = 4670,

        VCVTTSD2USIZrr = 4671,

        VCVTTSD2USIZrr_Int = 4672,

        VCVTTSD2USIZrrb_Int = 4673,

        VCVTTSS2SI64Zrm = 4674,

        VCVTTSS2SI64Zrm_Int = 4675,

        VCVTTSS2SI64Zrr = 4676,

        VCVTTSS2SI64Zrr_Int = 4677,

        VCVTTSS2SI64Zrrb_Int = 4678,

        VCVTTSS2SI64rm = 4679,

        VCVTTSS2SI64rm_Int = 4680,

        VCVTTSS2SI64rr = 4681,

        VCVTTSS2SI64rr_Int = 4682,

        VCVTTSS2SIZrm = 4683,

        VCVTTSS2SIZrm_Int = 4684,

        VCVTTSS2SIZrr = 4685,

        VCVTTSS2SIZrr_Int = 4686,

        VCVTTSS2SIZrrb_Int = 4687,

        VCVTTSS2SIrm = 4688,

        VCVTTSS2SIrm_Int = 4689,

        VCVTTSS2SIrr = 4690,

        VCVTTSS2SIrr_Int = 4691,

        VCVTTSS2USI64Zrm = 4692,

        VCVTTSS2USI64Zrm_Int = 4693,

        VCVTTSS2USI64Zrr = 4694,

        VCVTTSS2USI64Zrr_Int = 4695,

        VCVTTSS2USI64Zrrb_Int = 4696,

        VCVTTSS2USIZrm = 4697,

        VCVTTSS2USIZrm_Int = 4698,

        VCVTTSS2USIZrr = 4699,

        VCVTTSS2USIZrr_Int = 4700,

        VCVTTSS2USIZrrb_Int = 4701,

        VCVTUDQ2PDZ128rm = 4702,

        VCVTUDQ2PDZ128rmb = 4703,

        VCVTUDQ2PDZ128rmbk = 4704,

        VCVTUDQ2PDZ128rmbkz = 4705,

        VCVTUDQ2PDZ128rmk = 4706,

        VCVTUDQ2PDZ128rmkz = 4707,

        VCVTUDQ2PDZ128rr = 4708,

        VCVTUDQ2PDZ128rrk = 4709,

        VCVTUDQ2PDZ128rrkz = 4710,

        VCVTUDQ2PDZ256rm = 4711,

        VCVTUDQ2PDZ256rmb = 4712,

        VCVTUDQ2PDZ256rmbk = 4713,

        VCVTUDQ2PDZ256rmbkz = 4714,

        VCVTUDQ2PDZ256rmk = 4715,

        VCVTUDQ2PDZ256rmkz = 4716,

        VCVTUDQ2PDZ256rr = 4717,

        VCVTUDQ2PDZ256rrk = 4718,

        VCVTUDQ2PDZ256rrkz = 4719,

        VCVTUDQ2PDZrm = 4720,

        VCVTUDQ2PDZrmb = 4721,

        VCVTUDQ2PDZrmbk = 4722,

        VCVTUDQ2PDZrmbkz = 4723,

        VCVTUDQ2PDZrmk = 4724,

        VCVTUDQ2PDZrmkz = 4725,

        VCVTUDQ2PDZrr = 4726,

        VCVTUDQ2PDZrrk = 4727,

        VCVTUDQ2PDZrrkz = 4728,

        VCVTUDQ2PSZ128rm = 4729,

        VCVTUDQ2PSZ128rmb = 4730,

        VCVTUDQ2PSZ128rmbk = 4731,

        VCVTUDQ2PSZ128rmbkz = 4732,

        VCVTUDQ2PSZ128rmk = 4733,

        VCVTUDQ2PSZ128rmkz = 4734,

        VCVTUDQ2PSZ128rr = 4735,

        VCVTUDQ2PSZ128rrk = 4736,

        VCVTUDQ2PSZ128rrkz = 4737,

        VCVTUDQ2PSZ256rm = 4738,

        VCVTUDQ2PSZ256rmb = 4739,

        VCVTUDQ2PSZ256rmbk = 4740,

        VCVTUDQ2PSZ256rmbkz = 4741,

        VCVTUDQ2PSZ256rmk = 4742,

        VCVTUDQ2PSZ256rmkz = 4743,

        VCVTUDQ2PSZ256rr = 4744,

        VCVTUDQ2PSZ256rrk = 4745,

        VCVTUDQ2PSZ256rrkz = 4746,

        VCVTUDQ2PSZrm = 4747,

        VCVTUDQ2PSZrmb = 4748,

        VCVTUDQ2PSZrmbk = 4749,

        VCVTUDQ2PSZrmbkz = 4750,

        VCVTUDQ2PSZrmk = 4751,

        VCVTUDQ2PSZrmkz = 4752,

        VCVTUDQ2PSZrr = 4753,

        VCVTUDQ2PSZrrb = 4754,

        VCVTUDQ2PSZrrbk = 4755,

        VCVTUDQ2PSZrrbkz = 4756,

        VCVTUDQ2PSZrrk = 4757,

        VCVTUDQ2PSZrrkz = 4758,

        VCVTUQQ2PDZ128rm = 4759,

        VCVTUQQ2PDZ128rmb = 4760,

        VCVTUQQ2PDZ128rmbk = 4761,

        VCVTUQQ2PDZ128rmbkz = 4762,

        VCVTUQQ2PDZ128rmk = 4763,

        VCVTUQQ2PDZ128rmkz = 4764,

        VCVTUQQ2PDZ128rr = 4765,

        VCVTUQQ2PDZ128rrk = 4766,

        VCVTUQQ2PDZ128rrkz = 4767,

        VCVTUQQ2PDZ256rm = 4768,

        VCVTUQQ2PDZ256rmb = 4769,

        VCVTUQQ2PDZ256rmbk = 4770,

        VCVTUQQ2PDZ256rmbkz = 4771,

        VCVTUQQ2PDZ256rmk = 4772,

        VCVTUQQ2PDZ256rmkz = 4773,

        VCVTUQQ2PDZ256rr = 4774,

        VCVTUQQ2PDZ256rrk = 4775,

        VCVTUQQ2PDZ256rrkz = 4776,

        VCVTUQQ2PDZrm = 4777,

        VCVTUQQ2PDZrmb = 4778,

        VCVTUQQ2PDZrmbk = 4779,

        VCVTUQQ2PDZrmbkz = 4780,

        VCVTUQQ2PDZrmk = 4781,

        VCVTUQQ2PDZrmkz = 4782,

        VCVTUQQ2PDZrr = 4783,

        VCVTUQQ2PDZrrb = 4784,

        VCVTUQQ2PDZrrbk = 4785,

        VCVTUQQ2PDZrrbkz = 4786,

        VCVTUQQ2PDZrrk = 4787,

        VCVTUQQ2PDZrrkz = 4788,

        VCVTUQQ2PSZ128rm = 4789,

        VCVTUQQ2PSZ128rmb = 4790,

        VCVTUQQ2PSZ128rmbk = 4791,

        VCVTUQQ2PSZ128rmbkz = 4792,

        VCVTUQQ2PSZ128rmk = 4793,

        VCVTUQQ2PSZ128rmkz = 4794,

        VCVTUQQ2PSZ128rr = 4795,

        VCVTUQQ2PSZ128rrk = 4796,

        VCVTUQQ2PSZ128rrkz = 4797,

        VCVTUQQ2PSZ256rm = 4798,

        VCVTUQQ2PSZ256rmb = 4799,

        VCVTUQQ2PSZ256rmbk = 4800,

        VCVTUQQ2PSZ256rmbkz = 4801,

        VCVTUQQ2PSZ256rmk = 4802,

        VCVTUQQ2PSZ256rmkz = 4803,

        VCVTUQQ2PSZ256rr = 4804,

        VCVTUQQ2PSZ256rrk = 4805,

        VCVTUQQ2PSZ256rrkz = 4806,

        VCVTUQQ2PSZrm = 4807,

        VCVTUQQ2PSZrmb = 4808,

        VCVTUQQ2PSZrmbk = 4809,

        VCVTUQQ2PSZrmbkz = 4810,

        VCVTUQQ2PSZrmk = 4811,

        VCVTUQQ2PSZrmkz = 4812,

        VCVTUQQ2PSZrr = 4813,

        VCVTUQQ2PSZrrb = 4814,

        VCVTUQQ2PSZrrbk = 4815,

        VCVTUQQ2PSZrrbkz = 4816,

        VCVTUQQ2PSZrrk = 4817,

        VCVTUQQ2PSZrrkz = 4818,

        VCVTUSI2SDZrm = 4819,

        VCVTUSI2SDZrm_Int = 4820,

        VCVTUSI2SDZrr = 4821,

        VCVTUSI2SDZrr_Int = 4822,

        VCVTUSI2SSZrm = 4823,

        VCVTUSI2SSZrm_Int = 4824,

        VCVTUSI2SSZrr = 4825,

        VCVTUSI2SSZrr_Int = 4826,

        VCVTUSI2SSZrrb_Int = 4827,

        VCVTUSI642SDZrm = 4828,

        VCVTUSI642SDZrm_Int = 4829,

        VCVTUSI642SDZrr = 4830,

        VCVTUSI642SDZrr_Int = 4831,

        VCVTUSI642SDZrrb_Int = 4832,

        VCVTUSI642SSZrm = 4833,

        VCVTUSI642SSZrm_Int = 4834,

        VCVTUSI642SSZrr = 4835,

        VCVTUSI642SSZrr_Int = 4836,

        VCVTUSI642SSZrrb_Int = 4837,

        VDBPSADBWZ128rmi = 4838,

        VDBPSADBWZ128rmik = 4839,

        VDBPSADBWZ128rmikz = 4840,

        VDBPSADBWZ128rri = 4841,

        VDBPSADBWZ128rrik = 4842,

        VDBPSADBWZ128rrikz = 4843,

        VDBPSADBWZ256rmi = 4844,

        VDBPSADBWZ256rmik = 4845,

        VDBPSADBWZ256rmikz = 4846,

        VDBPSADBWZ256rri = 4847,

        VDBPSADBWZ256rrik = 4848,

        VDBPSADBWZ256rrikz = 4849,

        VDBPSADBWZrmi = 4850,

        VDBPSADBWZrmik = 4851,

        VDBPSADBWZrmikz = 4852,

        VDBPSADBWZrri = 4853,

        VDBPSADBWZrrik = 4854,

        VDBPSADBWZrrikz = 4855,

        VDIVPDYrm = 4856,

        VDIVPDYrr = 4857,

        VDIVPDZ128rm = 4858,

        VDIVPDZ128rmb = 4859,

        VDIVPDZ128rmbk = 4860,

        VDIVPDZ128rmbkz = 4861,

        VDIVPDZ128rmk = 4862,

        VDIVPDZ128rmkz = 4863,

        VDIVPDZ128rr = 4864,

        VDIVPDZ128rrk = 4865,

        VDIVPDZ128rrkz = 4866,

        VDIVPDZ256rm = 4867,

        VDIVPDZ256rmb = 4868,

        VDIVPDZ256rmbk = 4869,

        VDIVPDZ256rmbkz = 4870,

        VDIVPDZ256rmk = 4871,

        VDIVPDZ256rmkz = 4872,

        VDIVPDZ256rr = 4873,

        VDIVPDZ256rrk = 4874,

        VDIVPDZ256rrkz = 4875,

        VDIVPDZrm = 4876,

        VDIVPDZrmb = 4877,

        VDIVPDZrmbk = 4878,

        VDIVPDZrmbkz = 4879,

        VDIVPDZrmk = 4880,

        VDIVPDZrmkz = 4881,

        VDIVPDZrr = 4882,

        VDIVPDZrrb = 4883,

        VDIVPDZrrbk = 4884,

        VDIVPDZrrbkz = 4885,

        VDIVPDZrrk = 4886,

        VDIVPDZrrkz = 4887,

        VDIVPDrm = 4888,

        VDIVPDrr = 4889,

        VDIVPSYrm = 4890,

        VDIVPSYrr = 4891,

        VDIVPSZ128rm = 4892,

        VDIVPSZ128rmb = 4893,

        VDIVPSZ128rmbk = 4894,

        VDIVPSZ128rmbkz = 4895,

        VDIVPSZ128rmk = 4896,

        VDIVPSZ128rmkz = 4897,

        VDIVPSZ128rr = 4898,

        VDIVPSZ128rrk = 4899,

        VDIVPSZ128rrkz = 4900,

        VDIVPSZ256rm = 4901,

        VDIVPSZ256rmb = 4902,

        VDIVPSZ256rmbk = 4903,

        VDIVPSZ256rmbkz = 4904,

        VDIVPSZ256rmk = 4905,

        VDIVPSZ256rmkz = 4906,

        VDIVPSZ256rr = 4907,

        VDIVPSZ256rrk = 4908,

        VDIVPSZ256rrkz = 4909,

        VDIVPSZrm = 4910,

        VDIVPSZrmb = 4911,

        VDIVPSZrmbk = 4912,

        VDIVPSZrmbkz = 4913,

        VDIVPSZrmk = 4914,

        VDIVPSZrmkz = 4915,

        VDIVPSZrr = 4916,

        VDIVPSZrrb = 4917,

        VDIVPSZrrbk = 4918,

        VDIVPSZrrbkz = 4919,

        VDIVPSZrrk = 4920,

        VDIVPSZrrkz = 4921,

        VDIVPSrm = 4922,

        VDIVPSrr = 4923,

        VDIVSDZrm = 4924,

        VDIVSDZrm_Int = 4925,

        VDIVSDZrm_Intk = 4926,

        VDIVSDZrm_Intkz = 4927,

        VDIVSDZrr = 4928,

        VDIVSDZrr_Int = 4929,

        VDIVSDZrr_Intk = 4930,

        VDIVSDZrr_Intkz = 4931,

        VDIVSDZrrb_Int = 4932,

        VDIVSDZrrb_Intk = 4933,

        VDIVSDZrrb_Intkz = 4934,

        VDIVSDrm = 4935,

        VDIVSDrm_Int = 4936,

        VDIVSDrr = 4937,

        VDIVSDrr_Int = 4938,

        VDIVSSZrm = 4939,

        VDIVSSZrm_Int = 4940,

        VDIVSSZrm_Intk = 4941,

        VDIVSSZrm_Intkz = 4942,

        VDIVSSZrr = 4943,

        VDIVSSZrr_Int = 4944,

        VDIVSSZrr_Intk = 4945,

        VDIVSSZrr_Intkz = 4946,

        VDIVSSZrrb_Int = 4947,

        VDIVSSZrrb_Intk = 4948,

        VDIVSSZrrb_Intkz = 4949,

        VDIVSSrm = 4950,

        VDIVSSrm_Int = 4951,

        VDIVSSrr = 4952,

        VDIVSSrr_Int = 4953,

        VDPBF16PSZ128m = 4954,

        VDPBF16PSZ128mb = 4955,

        VDPBF16PSZ128mbk = 4956,

        VDPBF16PSZ128mbkz = 4957,

        VDPBF16PSZ128mk = 4958,

        VDPBF16PSZ128mkz = 4959,

        VDPBF16PSZ128r = 4960,

        VDPBF16PSZ128rk = 4961,

        VDPBF16PSZ128rkz = 4962,

        VDPBF16PSZ256m = 4963,

        VDPBF16PSZ256mb = 4964,

        VDPBF16PSZ256mbk = 4965,

        VDPBF16PSZ256mbkz = 4966,

        VDPBF16PSZ256mk = 4967,

        VDPBF16PSZ256mkz = 4968,

        VDPBF16PSZ256r = 4969,

        VDPBF16PSZ256rk = 4970,

        VDPBF16PSZ256rkz = 4971,

        VDPBF16PSZm = 4972,

        VDPBF16PSZmb = 4973,

        VDPBF16PSZmbk = 4974,

        VDPBF16PSZmbkz = 4975,

        VDPBF16PSZmk = 4976,

        VDPBF16PSZmkz = 4977,

        VDPBF16PSZr = 4978,

        VDPBF16PSZrk = 4979,

        VDPBF16PSZrkz = 4980,

        VDPPDrmi = 4981,

        VDPPDrri = 4982,

        VDPPSYrmi = 4983,

        VDPPSYrri = 4984,

        VDPPSrmi = 4985,

        VDPPSrri = 4986,

        VERRm = 4987,

        VERRr = 4988,

        VERWm = 4989,

        VERWr = 4990,

        VEXP2PDZm = 4991,

        VEXP2PDZmb = 4992,

        VEXP2PDZmbk = 4993,

        VEXP2PDZmbkz = 4994,

        VEXP2PDZmk = 4995,

        VEXP2PDZmkz = 4996,

        VEXP2PDZr = 4997,

        VEXP2PDZrb = 4998,

        VEXP2PDZrbk = 4999,

        VEXP2PDZrbkz = 5000,

        VEXP2PDZrk = 5001,

        VEXP2PDZrkz = 5002,

        VEXP2PSZm = 5003,

        VEXP2PSZmb = 5004,

        VEXP2PSZmbk = 5005,

        VEXP2PSZmbkz = 5006,

        VEXP2PSZmk = 5007,

        VEXP2PSZmkz = 5008,

        VEXP2PSZr = 5009,

        VEXP2PSZrb = 5010,

        VEXP2PSZrbk = 5011,

        VEXP2PSZrbkz = 5012,

        VEXP2PSZrk = 5013,

        VEXP2PSZrkz = 5014,

        VEXPANDPDZ128rm = 5015,

        VEXPANDPDZ128rmk = 5016,

        VEXPANDPDZ128rmkz = 5017,

        VEXPANDPDZ128rr = 5018,

        VEXPANDPDZ128rrk = 5019,

        VEXPANDPDZ128rrkz = 5020,

        VEXPANDPDZ256rm = 5021,

        VEXPANDPDZ256rmk = 5022,

        VEXPANDPDZ256rmkz = 5023,

        VEXPANDPDZ256rr = 5024,

        VEXPANDPDZ256rrk = 5025,

        VEXPANDPDZ256rrkz = 5026,

        VEXPANDPDZrm = 5027,

        VEXPANDPDZrmk = 5028,

        VEXPANDPDZrmkz = 5029,

        VEXPANDPDZrr = 5030,

        VEXPANDPDZrrk = 5031,

        VEXPANDPDZrrkz = 5032,

        VEXPANDPSZ128rm = 5033,

        VEXPANDPSZ128rmk = 5034,

        VEXPANDPSZ128rmkz = 5035,

        VEXPANDPSZ128rr = 5036,

        VEXPANDPSZ128rrk = 5037,

        VEXPANDPSZ128rrkz = 5038,

        VEXPANDPSZ256rm = 5039,

        VEXPANDPSZ256rmk = 5040,

        VEXPANDPSZ256rmkz = 5041,

        VEXPANDPSZ256rr = 5042,

        VEXPANDPSZ256rrk = 5043,

        VEXPANDPSZ256rrkz = 5044,

        VEXPANDPSZrm = 5045,

        VEXPANDPSZrmk = 5046,

        VEXPANDPSZrmkz = 5047,

        VEXPANDPSZrr = 5048,

        VEXPANDPSZrrk = 5049,

        VEXPANDPSZrrkz = 5050,

        VEXTRACTF128mr = 5051,

        VEXTRACTF128rr = 5052,

        VEXTRACTF32x4Z256mr = 5053,

        VEXTRACTF32x4Z256mrk = 5054,

        VEXTRACTF32x4Z256rr = 5055,

        VEXTRACTF32x4Z256rrk = 5056,

        VEXTRACTF32x4Z256rrkz = 5057,

        VEXTRACTF32x4Zmr = 5058,

        VEXTRACTF32x4Zmrk = 5059,

        VEXTRACTF32x4Zrr = 5060,

        VEXTRACTF32x4Zrrk = 5061,

        VEXTRACTF32x4Zrrkz = 5062,

        VEXTRACTF32x8Zmr = 5063,

        VEXTRACTF32x8Zmrk = 5064,

        VEXTRACTF32x8Zrr = 5065,

        VEXTRACTF32x8Zrrk = 5066,

        VEXTRACTF32x8Zrrkz = 5067,

        VEXTRACTF64x2Z256mr = 5068,

        VEXTRACTF64x2Z256mrk = 5069,

        VEXTRACTF64x2Z256rr = 5070,

        VEXTRACTF64x2Z256rrk = 5071,

        VEXTRACTF64x2Z256rrkz = 5072,

        VEXTRACTF64x2Zmr = 5073,

        VEXTRACTF64x2Zmrk = 5074,

        VEXTRACTF64x2Zrr = 5075,

        VEXTRACTF64x2Zrrk = 5076,

        VEXTRACTF64x2Zrrkz = 5077,

        VEXTRACTF64x4Zmr = 5078,

        VEXTRACTF64x4Zmrk = 5079,

        VEXTRACTF64x4Zrr = 5080,

        VEXTRACTF64x4Zrrk = 5081,

        VEXTRACTF64x4Zrrkz = 5082,

        VEXTRACTI128mr = 5083,

        VEXTRACTI128rr = 5084,

        VEXTRACTI32x4Z256mr = 5085,

        VEXTRACTI32x4Z256mrk = 5086,

        VEXTRACTI32x4Z256rr = 5087,

        VEXTRACTI32x4Z256rrk = 5088,

        VEXTRACTI32x4Z256rrkz = 5089,

        VEXTRACTI32x4Zmr = 5090,

        VEXTRACTI32x4Zmrk = 5091,

        VEXTRACTI32x4Zrr = 5092,

        VEXTRACTI32x4Zrrk = 5093,

        VEXTRACTI32x4Zrrkz = 5094,

        VEXTRACTI32x8Zmr = 5095,

        VEXTRACTI32x8Zmrk = 5096,

        VEXTRACTI32x8Zrr = 5097,

        VEXTRACTI32x8Zrrk = 5098,

        VEXTRACTI32x8Zrrkz = 5099,

        VEXTRACTI64x2Z256mr = 5100,

        VEXTRACTI64x2Z256mrk = 5101,

        VEXTRACTI64x2Z256rr = 5102,

        VEXTRACTI64x2Z256rrk = 5103,

        VEXTRACTI64x2Z256rrkz = 5104,

        VEXTRACTI64x2Zmr = 5105,

        VEXTRACTI64x2Zmrk = 5106,

        VEXTRACTI64x2Zrr = 5107,

        VEXTRACTI64x2Zrrk = 5108,

        VEXTRACTI64x2Zrrkz = 5109,

        VEXTRACTI64x4Zmr = 5110,

        VEXTRACTI64x4Zmrk = 5111,

        VEXTRACTI64x4Zrr = 5112,

        VEXTRACTI64x4Zrrk = 5113,

        VEXTRACTI64x4Zrrkz = 5114,

        VEXTRACTPSZmr = 5115,

        VEXTRACTPSZrr = 5116,

        VEXTRACTPSmr = 5117,

        VEXTRACTPSrr = 5118,

        VFIXUPIMMPDZ128rmbi = 5119,

        VFIXUPIMMPDZ128rmbik = 5120,

        VFIXUPIMMPDZ128rmbikz = 5121,

        VFIXUPIMMPDZ128rmi = 5122,

        VFIXUPIMMPDZ128rmik = 5123,

        VFIXUPIMMPDZ128rmikz = 5124,

        VFIXUPIMMPDZ128rri = 5125,

        VFIXUPIMMPDZ128rrik = 5126,

        VFIXUPIMMPDZ128rrikz = 5127,

        VFIXUPIMMPDZ256rmbi = 5128,

        VFIXUPIMMPDZ256rmbik = 5129,

        VFIXUPIMMPDZ256rmbikz = 5130,

        VFIXUPIMMPDZ256rmi = 5131,

        VFIXUPIMMPDZ256rmik = 5132,

        VFIXUPIMMPDZ256rmikz = 5133,

        VFIXUPIMMPDZ256rri = 5134,

        VFIXUPIMMPDZ256rrik = 5135,

        VFIXUPIMMPDZ256rrikz = 5136,

        VFIXUPIMMPDZrmbi = 5137,

        VFIXUPIMMPDZrmbik = 5138,

        VFIXUPIMMPDZrmbikz = 5139,

        VFIXUPIMMPDZrmi = 5140,

        VFIXUPIMMPDZrmik = 5141,

        VFIXUPIMMPDZrmikz = 5142,

        VFIXUPIMMPDZrri = 5143,

        VFIXUPIMMPDZrrib = 5144,

        VFIXUPIMMPDZrribk = 5145,

        VFIXUPIMMPDZrribkz = 5146,

        VFIXUPIMMPDZrrik = 5147,

        VFIXUPIMMPDZrrikz = 5148,

        VFIXUPIMMPSZ128rmbi = 5149,

        VFIXUPIMMPSZ128rmbik = 5150,

        VFIXUPIMMPSZ128rmbikz = 5151,

        VFIXUPIMMPSZ128rmi = 5152,

        VFIXUPIMMPSZ128rmik = 5153,

        VFIXUPIMMPSZ128rmikz = 5154,

        VFIXUPIMMPSZ128rri = 5155,

        VFIXUPIMMPSZ128rrik = 5156,

        VFIXUPIMMPSZ128rrikz = 5157,

        VFIXUPIMMPSZ256rmbi = 5158,

        VFIXUPIMMPSZ256rmbik = 5159,

        VFIXUPIMMPSZ256rmbikz = 5160,

        VFIXUPIMMPSZ256rmi = 5161,

        VFIXUPIMMPSZ256rmik = 5162,

        VFIXUPIMMPSZ256rmikz = 5163,

        VFIXUPIMMPSZ256rri = 5164,

        VFIXUPIMMPSZ256rrik = 5165,

        VFIXUPIMMPSZ256rrikz = 5166,

        VFIXUPIMMPSZrmbi = 5167,

        VFIXUPIMMPSZrmbik = 5168,

        VFIXUPIMMPSZrmbikz = 5169,

        VFIXUPIMMPSZrmi = 5170,

        VFIXUPIMMPSZrmik = 5171,

        VFIXUPIMMPSZrmikz = 5172,

        VFIXUPIMMPSZrri = 5173,

        VFIXUPIMMPSZrrib = 5174,

        VFIXUPIMMPSZrribk = 5175,

        VFIXUPIMMPSZrribkz = 5176,

        VFIXUPIMMPSZrrik = 5177,

        VFIXUPIMMPSZrrikz = 5178,

        VFIXUPIMMSDZrmi = 5179,

        VFIXUPIMMSDZrmik = 5180,

        VFIXUPIMMSDZrmikz = 5181,

        VFIXUPIMMSDZrri = 5182,

        VFIXUPIMMSDZrrib = 5183,

        VFIXUPIMMSDZrribk = 5184,

        VFIXUPIMMSDZrribkz = 5185,

        VFIXUPIMMSDZrrik = 5186,

        VFIXUPIMMSDZrrikz = 5187,

        VFIXUPIMMSSZrmi = 5188,

        VFIXUPIMMSSZrmik = 5189,

        VFIXUPIMMSSZrmikz = 5190,

        VFIXUPIMMSSZrri = 5191,

        VFIXUPIMMSSZrrib = 5192,

        VFIXUPIMMSSZrribk = 5193,

        VFIXUPIMMSSZrribkz = 5194,

        VFIXUPIMMSSZrrik = 5195,

        VFIXUPIMMSSZrrikz = 5196,

        VFMADD132PDYm = 5197,

        VFMADD132PDYr = 5198,

        VFMADD132PDZ128m = 5199,

        VFMADD132PDZ128mb = 5200,

        VFMADD132PDZ128mbk = 5201,

        VFMADD132PDZ128mbkz = 5202,

        VFMADD132PDZ128mk = 5203,

        VFMADD132PDZ128mkz = 5204,

        VFMADD132PDZ128r = 5205,

        VFMADD132PDZ128rk = 5206,

        VFMADD132PDZ128rkz = 5207,

        VFMADD132PDZ256m = 5208,

        VFMADD132PDZ256mb = 5209,

        VFMADD132PDZ256mbk = 5210,

        VFMADD132PDZ256mbkz = 5211,

        VFMADD132PDZ256mk = 5212,

        VFMADD132PDZ256mkz = 5213,

        VFMADD132PDZ256r = 5214,

        VFMADD132PDZ256rk = 5215,

        VFMADD132PDZ256rkz = 5216,

        VFMADD132PDZm = 5217,

        VFMADD132PDZmb = 5218,

        VFMADD132PDZmbk = 5219,

        VFMADD132PDZmbkz = 5220,

        VFMADD132PDZmk = 5221,

        VFMADD132PDZmkz = 5222,

        VFMADD132PDZr = 5223,

        VFMADD132PDZrb = 5224,

        VFMADD132PDZrbk = 5225,

        VFMADD132PDZrbkz = 5226,

        VFMADD132PDZrk = 5227,

        VFMADD132PDZrkz = 5228,

        VFMADD132PDm = 5229,

        VFMADD132PDr = 5230,

        VFMADD132PSYm = 5231,

        VFMADD132PSYr = 5232,

        VFMADD132PSZ128m = 5233,

        VFMADD132PSZ128mb = 5234,

        VFMADD132PSZ128mbk = 5235,

        VFMADD132PSZ128mbkz = 5236,

        VFMADD132PSZ128mk = 5237,

        VFMADD132PSZ128mkz = 5238,

        VFMADD132PSZ128r = 5239,

        VFMADD132PSZ128rk = 5240,

        VFMADD132PSZ128rkz = 5241,

        VFMADD132PSZ256m = 5242,

        VFMADD132PSZ256mb = 5243,

        VFMADD132PSZ256mbk = 5244,

        VFMADD132PSZ256mbkz = 5245,

        VFMADD132PSZ256mk = 5246,

        VFMADD132PSZ256mkz = 5247,

        VFMADD132PSZ256r = 5248,

        VFMADD132PSZ256rk = 5249,

        VFMADD132PSZ256rkz = 5250,

        VFMADD132PSZm = 5251,

        VFMADD132PSZmb = 5252,

        VFMADD132PSZmbk = 5253,

        VFMADD132PSZmbkz = 5254,

        VFMADD132PSZmk = 5255,

        VFMADD132PSZmkz = 5256,

        VFMADD132PSZr = 5257,

        VFMADD132PSZrb = 5258,

        VFMADD132PSZrbk = 5259,

        VFMADD132PSZrbkz = 5260,

        VFMADD132PSZrk = 5261,

        VFMADD132PSZrkz = 5262,

        VFMADD132PSm = 5263,

        VFMADD132PSr = 5264,

        VFMADD132SDZm = 5265,

        VFMADD132SDZm_Int = 5266,

        VFMADD132SDZm_Intk = 5267,

        VFMADD132SDZm_Intkz = 5268,

        VFMADD132SDZr = 5269,

        VFMADD132SDZr_Int = 5270,

        VFMADD132SDZr_Intk = 5271,

        VFMADD132SDZr_Intkz = 5272,

        VFMADD132SDZrb = 5273,

        VFMADD132SDZrb_Int = 5274,

        VFMADD132SDZrb_Intk = 5275,

        VFMADD132SDZrb_Intkz = 5276,

        VFMADD132SDm = 5277,

        VFMADD132SDm_Int = 5278,

        VFMADD132SDr = 5279,

        VFMADD132SDr_Int = 5280,

        VFMADD132SSZm = 5281,

        VFMADD132SSZm_Int = 5282,

        VFMADD132SSZm_Intk = 5283,

        VFMADD132SSZm_Intkz = 5284,

        VFMADD132SSZr = 5285,

        VFMADD132SSZr_Int = 5286,

        VFMADD132SSZr_Intk = 5287,

        VFMADD132SSZr_Intkz = 5288,

        VFMADD132SSZrb = 5289,

        VFMADD132SSZrb_Int = 5290,

        VFMADD132SSZrb_Intk = 5291,

        VFMADD132SSZrb_Intkz = 5292,

        VFMADD132SSm = 5293,

        VFMADD132SSm_Int = 5294,

        VFMADD132SSr = 5295,

        VFMADD132SSr_Int = 5296,

        VFMADD213PDYm = 5297,

        VFMADD213PDYr = 5298,

        VFMADD213PDZ128m = 5299,

        VFMADD213PDZ128mb = 5300,

        VFMADD213PDZ128mbk = 5301,

        VFMADD213PDZ128mbkz = 5302,

        VFMADD213PDZ128mk = 5303,

        VFMADD213PDZ128mkz = 5304,

        VFMADD213PDZ128r = 5305,

        VFMADD213PDZ128rk = 5306,

        VFMADD213PDZ128rkz = 5307,

        VFMADD213PDZ256m = 5308,

        VFMADD213PDZ256mb = 5309,

        VFMADD213PDZ256mbk = 5310,

        VFMADD213PDZ256mbkz = 5311,

        VFMADD213PDZ256mk = 5312,

        VFMADD213PDZ256mkz = 5313,

        VFMADD213PDZ256r = 5314,

        VFMADD213PDZ256rk = 5315,

        VFMADD213PDZ256rkz = 5316,

        VFMADD213PDZm = 5317,

        VFMADD213PDZmb = 5318,

        VFMADD213PDZmbk = 5319,

        VFMADD213PDZmbkz = 5320,

        VFMADD213PDZmk = 5321,

        VFMADD213PDZmkz = 5322,

        VFMADD213PDZr = 5323,

        VFMADD213PDZrb = 5324,

        VFMADD213PDZrbk = 5325,

        VFMADD213PDZrbkz = 5326,

        VFMADD213PDZrk = 5327,

        VFMADD213PDZrkz = 5328,

        VFMADD213PDm = 5329,

        VFMADD213PDr = 5330,

        VFMADD213PSYm = 5331,

        VFMADD213PSYr = 5332,

        VFMADD213PSZ128m = 5333,

        VFMADD213PSZ128mb = 5334,

        VFMADD213PSZ128mbk = 5335,

        VFMADD213PSZ128mbkz = 5336,

        VFMADD213PSZ128mk = 5337,

        VFMADD213PSZ128mkz = 5338,

        VFMADD213PSZ128r = 5339,

        VFMADD213PSZ128rk = 5340,

        VFMADD213PSZ128rkz = 5341,

        VFMADD213PSZ256m = 5342,

        VFMADD213PSZ256mb = 5343,

        VFMADD213PSZ256mbk = 5344,

        VFMADD213PSZ256mbkz = 5345,

        VFMADD213PSZ256mk = 5346,

        VFMADD213PSZ256mkz = 5347,

        VFMADD213PSZ256r = 5348,

        VFMADD213PSZ256rk = 5349,

        VFMADD213PSZ256rkz = 5350,

        VFMADD213PSZm = 5351,

        VFMADD213PSZmb = 5352,

        VFMADD213PSZmbk = 5353,

        VFMADD213PSZmbkz = 5354,

        VFMADD213PSZmk = 5355,

        VFMADD213PSZmkz = 5356,

        VFMADD213PSZr = 5357,

        VFMADD213PSZrb = 5358,

        VFMADD213PSZrbk = 5359,

        VFMADD213PSZrbkz = 5360,

        VFMADD213PSZrk = 5361,

        VFMADD213PSZrkz = 5362,

        VFMADD213PSm = 5363,

        VFMADD213PSr = 5364,

        VFMADD213SDZm = 5365,

        VFMADD213SDZm_Int = 5366,

        VFMADD213SDZm_Intk = 5367,

        VFMADD213SDZm_Intkz = 5368,

        VFMADD213SDZr = 5369,

        VFMADD213SDZr_Int = 5370,

        VFMADD213SDZr_Intk = 5371,

        VFMADD213SDZr_Intkz = 5372,

        VFMADD213SDZrb = 5373,

        VFMADD213SDZrb_Int = 5374,

        VFMADD213SDZrb_Intk = 5375,

        VFMADD213SDZrb_Intkz = 5376,

        VFMADD213SDm = 5377,

        VFMADD213SDm_Int = 5378,

        VFMADD213SDr = 5379,

        VFMADD213SDr_Int = 5380,

        VFMADD213SSZm = 5381,

        VFMADD213SSZm_Int = 5382,

        VFMADD213SSZm_Intk = 5383,

        VFMADD213SSZm_Intkz = 5384,

        VFMADD213SSZr = 5385,

        VFMADD213SSZr_Int = 5386,

        VFMADD213SSZr_Intk = 5387,

        VFMADD213SSZr_Intkz = 5388,

        VFMADD213SSZrb = 5389,

        VFMADD213SSZrb_Int = 5390,

        VFMADD213SSZrb_Intk = 5391,

        VFMADD213SSZrb_Intkz = 5392,

        VFMADD213SSm = 5393,

        VFMADD213SSm_Int = 5394,

        VFMADD213SSr = 5395,

        VFMADD213SSr_Int = 5396,

        VFMADD231PDYm = 5397,

        VFMADD231PDYr = 5398,

        VFMADD231PDZ128m = 5399,

        VFMADD231PDZ128mb = 5400,

        VFMADD231PDZ128mbk = 5401,

        VFMADD231PDZ128mbkz = 5402,

        VFMADD231PDZ128mk = 5403,

        VFMADD231PDZ128mkz = 5404,

        VFMADD231PDZ128r = 5405,

        VFMADD231PDZ128rk = 5406,

        VFMADD231PDZ128rkz = 5407,

        VFMADD231PDZ256m = 5408,

        VFMADD231PDZ256mb = 5409,

        VFMADD231PDZ256mbk = 5410,

        VFMADD231PDZ256mbkz = 5411,

        VFMADD231PDZ256mk = 5412,

        VFMADD231PDZ256mkz = 5413,

        VFMADD231PDZ256r = 5414,

        VFMADD231PDZ256rk = 5415,

        VFMADD231PDZ256rkz = 5416,

        VFMADD231PDZm = 5417,

        VFMADD231PDZmb = 5418,

        VFMADD231PDZmbk = 5419,

        VFMADD231PDZmbkz = 5420,

        VFMADD231PDZmk = 5421,

        VFMADD231PDZmkz = 5422,

        VFMADD231PDZr = 5423,

        VFMADD231PDZrb = 5424,

        VFMADD231PDZrbk = 5425,

        VFMADD231PDZrbkz = 5426,

        VFMADD231PDZrk = 5427,

        VFMADD231PDZrkz = 5428,

        VFMADD231PDm = 5429,

        VFMADD231PDr = 5430,

        VFMADD231PSYm = 5431,

        VFMADD231PSYr = 5432,

        VFMADD231PSZ128m = 5433,

        VFMADD231PSZ128mb = 5434,

        VFMADD231PSZ128mbk = 5435,

        VFMADD231PSZ128mbkz = 5436,

        VFMADD231PSZ128mk = 5437,

        VFMADD231PSZ128mkz = 5438,

        VFMADD231PSZ128r = 5439,

        VFMADD231PSZ128rk = 5440,

        VFMADD231PSZ128rkz = 5441,

        VFMADD231PSZ256m = 5442,

        VFMADD231PSZ256mb = 5443,

        VFMADD231PSZ256mbk = 5444,

        VFMADD231PSZ256mbkz = 5445,

        VFMADD231PSZ256mk = 5446,

        VFMADD231PSZ256mkz = 5447,

        VFMADD231PSZ256r = 5448,

        VFMADD231PSZ256rk = 5449,

        VFMADD231PSZ256rkz = 5450,

        VFMADD231PSZm = 5451,

        VFMADD231PSZmb = 5452,

        VFMADD231PSZmbk = 5453,

        VFMADD231PSZmbkz = 5454,

        VFMADD231PSZmk = 5455,

        VFMADD231PSZmkz = 5456,

        VFMADD231PSZr = 5457,

        VFMADD231PSZrb = 5458,

        VFMADD231PSZrbk = 5459,

        VFMADD231PSZrbkz = 5460,

        VFMADD231PSZrk = 5461,

        VFMADD231PSZrkz = 5462,

        VFMADD231PSm = 5463,

        VFMADD231PSr = 5464,

        VFMADD231SDZm = 5465,

        VFMADD231SDZm_Int = 5466,

        VFMADD231SDZm_Intk = 5467,

        VFMADD231SDZm_Intkz = 5468,

        VFMADD231SDZr = 5469,

        VFMADD231SDZr_Int = 5470,

        VFMADD231SDZr_Intk = 5471,

        VFMADD231SDZr_Intkz = 5472,

        VFMADD231SDZrb = 5473,

        VFMADD231SDZrb_Int = 5474,

        VFMADD231SDZrb_Intk = 5475,

        VFMADD231SDZrb_Intkz = 5476,

        VFMADD231SDm = 5477,

        VFMADD231SDm_Int = 5478,

        VFMADD231SDr = 5479,

        VFMADD231SDr_Int = 5480,

        VFMADD231SSZm = 5481,

        VFMADD231SSZm_Int = 5482,

        VFMADD231SSZm_Intk = 5483,

        VFMADD231SSZm_Intkz = 5484,

        VFMADD231SSZr = 5485,

        VFMADD231SSZr_Int = 5486,

        VFMADD231SSZr_Intk = 5487,

        VFMADD231SSZr_Intkz = 5488,

        VFMADD231SSZrb = 5489,

        VFMADD231SSZrb_Int = 5490,

        VFMADD231SSZrb_Intk = 5491,

        VFMADD231SSZrb_Intkz = 5492,

        VFMADD231SSm = 5493,

        VFMADD231SSm_Int = 5494,

        VFMADD231SSr = 5495,

        VFMADD231SSr_Int = 5496,

        VFMADDPD4Ymr = 5497,

        VFMADDPD4Yrm = 5498,

        VFMADDPD4Yrr = 5499,

        VFMADDPD4Yrr_REV = 5500,

        VFMADDPD4mr = 5501,

        VFMADDPD4rm = 5502,

        VFMADDPD4rr = 5503,

        VFMADDPD4rr_REV = 5504,

        VFMADDPS4Ymr = 5505,

        VFMADDPS4Yrm = 5506,

        VFMADDPS4Yrr = 5507,

        VFMADDPS4Yrr_REV = 5508,

        VFMADDPS4mr = 5509,

        VFMADDPS4rm = 5510,

        VFMADDPS4rr = 5511,

        VFMADDPS4rr_REV = 5512,

        VFMADDSD4mr = 5513,

        VFMADDSD4mr_Int = 5514,

        VFMADDSD4rm = 5515,

        VFMADDSD4rm_Int = 5516,

        VFMADDSD4rr = 5517,

        VFMADDSD4rr_Int = 5518,

        VFMADDSD4rr_Int_REV = 5519,

        VFMADDSD4rr_REV = 5520,

        VFMADDSS4mr = 5521,

        VFMADDSS4mr_Int = 5522,

        VFMADDSS4rm = 5523,

        VFMADDSS4rm_Int = 5524,

        VFMADDSS4rr = 5525,

        VFMADDSS4rr_Int = 5526,

        VFMADDSS4rr_Int_REV = 5527,

        VFMADDSS4rr_REV = 5528,

        VFMADDSUB132PDYm = 5529,

        VFMADDSUB132PDYr = 5530,

        VFMADDSUB132PDZ128m = 5531,

        VFMADDSUB132PDZ128mb = 5532,

        VFMADDSUB132PDZ128mbk = 5533,

        VFMADDSUB132PDZ128mbkz = 5534,

        VFMADDSUB132PDZ128mk = 5535,

        VFMADDSUB132PDZ128mkz = 5536,

        VFMADDSUB132PDZ128r = 5537,

        VFMADDSUB132PDZ128rk = 5538,

        VFMADDSUB132PDZ128rkz = 5539,

        VFMADDSUB132PDZ256m = 5540,

        VFMADDSUB132PDZ256mb = 5541,

        VFMADDSUB132PDZ256mbk = 5542,

        VFMADDSUB132PDZ256mbkz = 5543,

        VFMADDSUB132PDZ256mk = 5544,

        VFMADDSUB132PDZ256mkz = 5545,

        VFMADDSUB132PDZ256r = 5546,

        VFMADDSUB132PDZ256rk = 5547,

        VFMADDSUB132PDZ256rkz = 5548,

        VFMADDSUB132PDZm = 5549,

        VFMADDSUB132PDZmb = 5550,

        VFMADDSUB132PDZmbk = 5551,

        VFMADDSUB132PDZmbkz = 5552,

        VFMADDSUB132PDZmk = 5553,

        VFMADDSUB132PDZmkz = 5554,

        VFMADDSUB132PDZr = 5555,

        VFMADDSUB132PDZrb = 5556,

        VFMADDSUB132PDZrbk = 5557,

        VFMADDSUB132PDZrbkz = 5558,

        VFMADDSUB132PDZrk = 5559,

        VFMADDSUB132PDZrkz = 5560,

        VFMADDSUB132PDm = 5561,

        VFMADDSUB132PDr = 5562,

        VFMADDSUB132PSYm = 5563,

        VFMADDSUB132PSYr = 5564,

        VFMADDSUB132PSZ128m = 5565,

        VFMADDSUB132PSZ128mb = 5566,

        VFMADDSUB132PSZ128mbk = 5567,

        VFMADDSUB132PSZ128mbkz = 5568,

        VFMADDSUB132PSZ128mk = 5569,

        VFMADDSUB132PSZ128mkz = 5570,

        VFMADDSUB132PSZ128r = 5571,

        VFMADDSUB132PSZ128rk = 5572,

        VFMADDSUB132PSZ128rkz = 5573,

        VFMADDSUB132PSZ256m = 5574,

        VFMADDSUB132PSZ256mb = 5575,

        VFMADDSUB132PSZ256mbk = 5576,

        VFMADDSUB132PSZ256mbkz = 5577,

        VFMADDSUB132PSZ256mk = 5578,

        VFMADDSUB132PSZ256mkz = 5579,

        VFMADDSUB132PSZ256r = 5580,

        VFMADDSUB132PSZ256rk = 5581,

        VFMADDSUB132PSZ256rkz = 5582,

        VFMADDSUB132PSZm = 5583,

        VFMADDSUB132PSZmb = 5584,

        VFMADDSUB132PSZmbk = 5585,

        VFMADDSUB132PSZmbkz = 5586,

        VFMADDSUB132PSZmk = 5587,

        VFMADDSUB132PSZmkz = 5588,

        VFMADDSUB132PSZr = 5589,

        VFMADDSUB132PSZrb = 5590,

        VFMADDSUB132PSZrbk = 5591,

        VFMADDSUB132PSZrbkz = 5592,

        VFMADDSUB132PSZrk = 5593,

        VFMADDSUB132PSZrkz = 5594,

        VFMADDSUB132PSm = 5595,

        VFMADDSUB132PSr = 5596,

        VFMADDSUB213PDYm = 5597,

        VFMADDSUB213PDYr = 5598,

        VFMADDSUB213PDZ128m = 5599,

        VFMADDSUB213PDZ128mb = 5600,

        VFMADDSUB213PDZ128mbk = 5601,

        VFMADDSUB213PDZ128mbkz = 5602,

        VFMADDSUB213PDZ128mk = 5603,

        VFMADDSUB213PDZ128mkz = 5604,

        VFMADDSUB213PDZ128r = 5605,

        VFMADDSUB213PDZ128rk = 5606,

        VFMADDSUB213PDZ128rkz = 5607,

        VFMADDSUB213PDZ256m = 5608,

        VFMADDSUB213PDZ256mb = 5609,

        VFMADDSUB213PDZ256mbk = 5610,

        VFMADDSUB213PDZ256mbkz = 5611,

        VFMADDSUB213PDZ256mk = 5612,

        VFMADDSUB213PDZ256mkz = 5613,

        VFMADDSUB213PDZ256r = 5614,

        VFMADDSUB213PDZ256rk = 5615,

        VFMADDSUB213PDZ256rkz = 5616,

        VFMADDSUB213PDZm = 5617,

        VFMADDSUB213PDZmb = 5618,

        VFMADDSUB213PDZmbk = 5619,

        VFMADDSUB213PDZmbkz = 5620,

        VFMADDSUB213PDZmk = 5621,

        VFMADDSUB213PDZmkz = 5622,

        VFMADDSUB213PDZr = 5623,

        VFMADDSUB213PDZrb = 5624,

        VFMADDSUB213PDZrbk = 5625,

        VFMADDSUB213PDZrbkz = 5626,

        VFMADDSUB213PDZrk = 5627,

        VFMADDSUB213PDZrkz = 5628,

        VFMADDSUB213PDm = 5629,

        VFMADDSUB213PDr = 5630,

        VFMADDSUB213PSYm = 5631,

        VFMADDSUB213PSYr = 5632,

        VFMADDSUB213PSZ128m = 5633,

        VFMADDSUB213PSZ128mb = 5634,

        VFMADDSUB213PSZ128mbk = 5635,

        VFMADDSUB213PSZ128mbkz = 5636,

        VFMADDSUB213PSZ128mk = 5637,

        VFMADDSUB213PSZ128mkz = 5638,

        VFMADDSUB213PSZ128r = 5639,

        VFMADDSUB213PSZ128rk = 5640,

        VFMADDSUB213PSZ128rkz = 5641,

        VFMADDSUB213PSZ256m = 5642,

        VFMADDSUB213PSZ256mb = 5643,

        VFMADDSUB213PSZ256mbk = 5644,

        VFMADDSUB213PSZ256mbkz = 5645,

        VFMADDSUB213PSZ256mk = 5646,

        VFMADDSUB213PSZ256mkz = 5647,

        VFMADDSUB213PSZ256r = 5648,

        VFMADDSUB213PSZ256rk = 5649,

        VFMADDSUB213PSZ256rkz = 5650,

        VFMADDSUB213PSZm = 5651,

        VFMADDSUB213PSZmb = 5652,

        VFMADDSUB213PSZmbk = 5653,

        VFMADDSUB213PSZmbkz = 5654,

        VFMADDSUB213PSZmk = 5655,

        VFMADDSUB213PSZmkz = 5656,

        VFMADDSUB213PSZr = 5657,

        VFMADDSUB213PSZrb = 5658,

        VFMADDSUB213PSZrbk = 5659,

        VFMADDSUB213PSZrbkz = 5660,

        VFMADDSUB213PSZrk = 5661,

        VFMADDSUB213PSZrkz = 5662,

        VFMADDSUB213PSm = 5663,

        VFMADDSUB213PSr = 5664,

        VFMADDSUB231PDYm = 5665,

        VFMADDSUB231PDYr = 5666,

        VFMADDSUB231PDZ128m = 5667,

        VFMADDSUB231PDZ128mb = 5668,

        VFMADDSUB231PDZ128mbk = 5669,

        VFMADDSUB231PDZ128mbkz = 5670,

        VFMADDSUB231PDZ128mk = 5671,

        VFMADDSUB231PDZ128mkz = 5672,

        VFMADDSUB231PDZ128r = 5673,

        VFMADDSUB231PDZ128rk = 5674,

        VFMADDSUB231PDZ128rkz = 5675,

        VFMADDSUB231PDZ256m = 5676,

        VFMADDSUB231PDZ256mb = 5677,

        VFMADDSUB231PDZ256mbk = 5678,

        VFMADDSUB231PDZ256mbkz = 5679,

        VFMADDSUB231PDZ256mk = 5680,

        VFMADDSUB231PDZ256mkz = 5681,

        VFMADDSUB231PDZ256r = 5682,

        VFMADDSUB231PDZ256rk = 5683,

        VFMADDSUB231PDZ256rkz = 5684,

        VFMADDSUB231PDZm = 5685,

        VFMADDSUB231PDZmb = 5686,

        VFMADDSUB231PDZmbk = 5687,

        VFMADDSUB231PDZmbkz = 5688,

        VFMADDSUB231PDZmk = 5689,

        VFMADDSUB231PDZmkz = 5690,

        VFMADDSUB231PDZr = 5691,

        VFMADDSUB231PDZrb = 5692,

        VFMADDSUB231PDZrbk = 5693,

        VFMADDSUB231PDZrbkz = 5694,

        VFMADDSUB231PDZrk = 5695,

        VFMADDSUB231PDZrkz = 5696,

        VFMADDSUB231PDm = 5697,

        VFMADDSUB231PDr = 5698,

        VFMADDSUB231PSYm = 5699,

        VFMADDSUB231PSYr = 5700,

        VFMADDSUB231PSZ128m = 5701,

        VFMADDSUB231PSZ128mb = 5702,

        VFMADDSUB231PSZ128mbk = 5703,

        VFMADDSUB231PSZ128mbkz = 5704,

        VFMADDSUB231PSZ128mk = 5705,

        VFMADDSUB231PSZ128mkz = 5706,

        VFMADDSUB231PSZ128r = 5707,

        VFMADDSUB231PSZ128rk = 5708,

        VFMADDSUB231PSZ128rkz = 5709,

        VFMADDSUB231PSZ256m = 5710,

        VFMADDSUB231PSZ256mb = 5711,

        VFMADDSUB231PSZ256mbk = 5712,

        VFMADDSUB231PSZ256mbkz = 5713,

        VFMADDSUB231PSZ256mk = 5714,

        VFMADDSUB231PSZ256mkz = 5715,

        VFMADDSUB231PSZ256r = 5716,

        VFMADDSUB231PSZ256rk = 5717,

        VFMADDSUB231PSZ256rkz = 5718,

        VFMADDSUB231PSZm = 5719,

        VFMADDSUB231PSZmb = 5720,

        VFMADDSUB231PSZmbk = 5721,

        VFMADDSUB231PSZmbkz = 5722,

        VFMADDSUB231PSZmk = 5723,

        VFMADDSUB231PSZmkz = 5724,

        VFMADDSUB231PSZr = 5725,

        VFMADDSUB231PSZrb = 5726,

        VFMADDSUB231PSZrbk = 5727,

        VFMADDSUB231PSZrbkz = 5728,

        VFMADDSUB231PSZrk = 5729,

        VFMADDSUB231PSZrkz = 5730,

        VFMADDSUB231PSm = 5731,

        VFMADDSUB231PSr = 5732,

        VFMADDSUBPD4Ymr = 5733,

        VFMADDSUBPD4Yrm = 5734,

        VFMADDSUBPD4Yrr = 5735,

        VFMADDSUBPD4Yrr_REV = 5736,

        VFMADDSUBPD4mr = 5737,

        VFMADDSUBPD4rm = 5738,

        VFMADDSUBPD4rr = 5739,

        VFMADDSUBPD4rr_REV = 5740,

        VFMADDSUBPS4Ymr = 5741,

        VFMADDSUBPS4Yrm = 5742,

        VFMADDSUBPS4Yrr = 5743,

        VFMADDSUBPS4Yrr_REV = 5744,

        VFMADDSUBPS4mr = 5745,

        VFMADDSUBPS4rm = 5746,

        VFMADDSUBPS4rr = 5747,

        VFMADDSUBPS4rr_REV = 5748,

        VFMSUB132PDYm = 5749,

        VFMSUB132PDYr = 5750,

        VFMSUB132PDZ128m = 5751,

        VFMSUB132PDZ128mb = 5752,

        VFMSUB132PDZ128mbk = 5753,

        VFMSUB132PDZ128mbkz = 5754,

        VFMSUB132PDZ128mk = 5755,

        VFMSUB132PDZ128mkz = 5756,

        VFMSUB132PDZ128r = 5757,

        VFMSUB132PDZ128rk = 5758,

        VFMSUB132PDZ128rkz = 5759,

        VFMSUB132PDZ256m = 5760,

        VFMSUB132PDZ256mb = 5761,

        VFMSUB132PDZ256mbk = 5762,

        VFMSUB132PDZ256mbkz = 5763,

        VFMSUB132PDZ256mk = 5764,

        VFMSUB132PDZ256mkz = 5765,

        VFMSUB132PDZ256r = 5766,

        VFMSUB132PDZ256rk = 5767,

        VFMSUB132PDZ256rkz = 5768,

        VFMSUB132PDZm = 5769,

        VFMSUB132PDZmb = 5770,

        VFMSUB132PDZmbk = 5771,

        VFMSUB132PDZmbkz = 5772,

        VFMSUB132PDZmk = 5773,

        VFMSUB132PDZmkz = 5774,

        VFMSUB132PDZr = 5775,

        VFMSUB132PDZrb = 5776,

        VFMSUB132PDZrbk = 5777,

        VFMSUB132PDZrbkz = 5778,

        VFMSUB132PDZrk = 5779,

        VFMSUB132PDZrkz = 5780,

        VFMSUB132PDm = 5781,

        VFMSUB132PDr = 5782,

        VFMSUB132PSYm = 5783,

        VFMSUB132PSYr = 5784,

        VFMSUB132PSZ128m = 5785,

        VFMSUB132PSZ128mb = 5786,

        VFMSUB132PSZ128mbk = 5787,

        VFMSUB132PSZ128mbkz = 5788,

        VFMSUB132PSZ128mk = 5789,

        VFMSUB132PSZ128mkz = 5790,

        VFMSUB132PSZ128r = 5791,

        VFMSUB132PSZ128rk = 5792,

        VFMSUB132PSZ128rkz = 5793,

        VFMSUB132PSZ256m = 5794,

        VFMSUB132PSZ256mb = 5795,

        VFMSUB132PSZ256mbk = 5796,

        VFMSUB132PSZ256mbkz = 5797,

        VFMSUB132PSZ256mk = 5798,

        VFMSUB132PSZ256mkz = 5799,

        VFMSUB132PSZ256r = 5800,

        VFMSUB132PSZ256rk = 5801,

        VFMSUB132PSZ256rkz = 5802,

        VFMSUB132PSZm = 5803,

        VFMSUB132PSZmb = 5804,

        VFMSUB132PSZmbk = 5805,

        VFMSUB132PSZmbkz = 5806,

        VFMSUB132PSZmk = 5807,

        VFMSUB132PSZmkz = 5808,

        VFMSUB132PSZr = 5809,

        VFMSUB132PSZrb = 5810,

        VFMSUB132PSZrbk = 5811,

        VFMSUB132PSZrbkz = 5812,

        VFMSUB132PSZrk = 5813,

        VFMSUB132PSZrkz = 5814,

        VFMSUB132PSm = 5815,

        VFMSUB132PSr = 5816,

        VFMSUB132SDZm = 5817,

        VFMSUB132SDZm_Int = 5818,

        VFMSUB132SDZm_Intk = 5819,

        VFMSUB132SDZm_Intkz = 5820,

        VFMSUB132SDZr = 5821,

        VFMSUB132SDZr_Int = 5822,

        VFMSUB132SDZr_Intk = 5823,

        VFMSUB132SDZr_Intkz = 5824,

        VFMSUB132SDZrb = 5825,

        VFMSUB132SDZrb_Int = 5826,

        VFMSUB132SDZrb_Intk = 5827,

        VFMSUB132SDZrb_Intkz = 5828,

        VFMSUB132SDm = 5829,

        VFMSUB132SDm_Int = 5830,

        VFMSUB132SDr = 5831,

        VFMSUB132SDr_Int = 5832,

        VFMSUB132SSZm = 5833,

        VFMSUB132SSZm_Int = 5834,

        VFMSUB132SSZm_Intk = 5835,

        VFMSUB132SSZm_Intkz = 5836,

        VFMSUB132SSZr = 5837,

        VFMSUB132SSZr_Int = 5838,

        VFMSUB132SSZr_Intk = 5839,

        VFMSUB132SSZr_Intkz = 5840,

        VFMSUB132SSZrb = 5841,

        VFMSUB132SSZrb_Int = 5842,

        VFMSUB132SSZrb_Intk = 5843,

        VFMSUB132SSZrb_Intkz = 5844,

        VFMSUB132SSm = 5845,

        VFMSUB132SSm_Int = 5846,

        VFMSUB132SSr = 5847,

        VFMSUB132SSr_Int = 5848,

        VFMSUB213PDYm = 5849,

        VFMSUB213PDYr = 5850,

        VFMSUB213PDZ128m = 5851,

        VFMSUB213PDZ128mb = 5852,

        VFMSUB213PDZ128mbk = 5853,

        VFMSUB213PDZ128mbkz = 5854,

        VFMSUB213PDZ128mk = 5855,

        VFMSUB213PDZ128mkz = 5856,

        VFMSUB213PDZ128r = 5857,

        VFMSUB213PDZ128rk = 5858,

        VFMSUB213PDZ128rkz = 5859,

        VFMSUB213PDZ256m = 5860,

        VFMSUB213PDZ256mb = 5861,

        VFMSUB213PDZ256mbk = 5862,

        VFMSUB213PDZ256mbkz = 5863,

        VFMSUB213PDZ256mk = 5864,

        VFMSUB213PDZ256mkz = 5865,

        VFMSUB213PDZ256r = 5866,

        VFMSUB213PDZ256rk = 5867,

        VFMSUB213PDZ256rkz = 5868,

        VFMSUB213PDZm = 5869,

        VFMSUB213PDZmb = 5870,

        VFMSUB213PDZmbk = 5871,

        VFMSUB213PDZmbkz = 5872,

        VFMSUB213PDZmk = 5873,

        VFMSUB213PDZmkz = 5874,

        VFMSUB213PDZr = 5875,

        VFMSUB213PDZrb = 5876,

        VFMSUB213PDZrbk = 5877,

        VFMSUB213PDZrbkz = 5878,

        VFMSUB213PDZrk = 5879,

        VFMSUB213PDZrkz = 5880,

        VFMSUB213PDm = 5881,

        VFMSUB213PDr = 5882,

        VFMSUB213PSYm = 5883,

        VFMSUB213PSYr = 5884,

        VFMSUB213PSZ128m = 5885,

        VFMSUB213PSZ128mb = 5886,

        VFMSUB213PSZ128mbk = 5887,

        VFMSUB213PSZ128mbkz = 5888,

        VFMSUB213PSZ128mk = 5889,

        VFMSUB213PSZ128mkz = 5890,

        VFMSUB213PSZ128r = 5891,

        VFMSUB213PSZ128rk = 5892,

        VFMSUB213PSZ128rkz = 5893,

        VFMSUB213PSZ256m = 5894,

        VFMSUB213PSZ256mb = 5895,

        VFMSUB213PSZ256mbk = 5896,

        VFMSUB213PSZ256mbkz = 5897,

        VFMSUB213PSZ256mk = 5898,

        VFMSUB213PSZ256mkz = 5899,

        VFMSUB213PSZ256r = 5900,

        VFMSUB213PSZ256rk = 5901,

        VFMSUB213PSZ256rkz = 5902,

        VFMSUB213PSZm = 5903,

        VFMSUB213PSZmb = 5904,

        VFMSUB213PSZmbk = 5905,

        VFMSUB213PSZmbkz = 5906,

        VFMSUB213PSZmk = 5907,

        VFMSUB213PSZmkz = 5908,

        VFMSUB213PSZr = 5909,

        VFMSUB213PSZrb = 5910,

        VFMSUB213PSZrbk = 5911,

        VFMSUB213PSZrbkz = 5912,

        VFMSUB213PSZrk = 5913,

        VFMSUB213PSZrkz = 5914,

        VFMSUB213PSm = 5915,

        VFMSUB213PSr = 5916,

        VFMSUB213SDZm = 5917,

        VFMSUB213SDZm_Int = 5918,

        VFMSUB213SDZm_Intk = 5919,

        VFMSUB213SDZm_Intkz = 5920,

        VFMSUB213SDZr = 5921,

        VFMSUB213SDZr_Int = 5922,

        VFMSUB213SDZr_Intk = 5923,

        VFMSUB213SDZr_Intkz = 5924,

        VFMSUB213SDZrb = 5925,

        VFMSUB213SDZrb_Int = 5926,

        VFMSUB213SDZrb_Intk = 5927,

        VFMSUB213SDZrb_Intkz = 5928,

        VFMSUB213SDm = 5929,

        VFMSUB213SDm_Int = 5930,

        VFMSUB213SDr = 5931,

        VFMSUB213SDr_Int = 5932,

        VFMSUB213SSZm = 5933,

        VFMSUB213SSZm_Int = 5934,

        VFMSUB213SSZm_Intk = 5935,

        VFMSUB213SSZm_Intkz = 5936,

        VFMSUB213SSZr = 5937,

        VFMSUB213SSZr_Int = 5938,

        VFMSUB213SSZr_Intk = 5939,

        VFMSUB213SSZr_Intkz = 5940,

        VFMSUB213SSZrb = 5941,

        VFMSUB213SSZrb_Int = 5942,

        VFMSUB213SSZrb_Intk = 5943,

        VFMSUB213SSZrb_Intkz = 5944,

        VFMSUB213SSm = 5945,

        VFMSUB213SSm_Int = 5946,

        VFMSUB213SSr = 5947,

        VFMSUB213SSr_Int = 5948,

        VFMSUB231PDYm = 5949,

        VFMSUB231PDYr = 5950,

        VFMSUB231PDZ128m = 5951,

        VFMSUB231PDZ128mb = 5952,

        VFMSUB231PDZ128mbk = 5953,

        VFMSUB231PDZ128mbkz = 5954,

        VFMSUB231PDZ128mk = 5955,

        VFMSUB231PDZ128mkz = 5956,

        VFMSUB231PDZ128r = 5957,

        VFMSUB231PDZ128rk = 5958,

        VFMSUB231PDZ128rkz = 5959,

        VFMSUB231PDZ256m = 5960,

        VFMSUB231PDZ256mb = 5961,

        VFMSUB231PDZ256mbk = 5962,

        VFMSUB231PDZ256mbkz = 5963,

        VFMSUB231PDZ256mk = 5964,

        VFMSUB231PDZ256mkz = 5965,

        VFMSUB231PDZ256r = 5966,

        VFMSUB231PDZ256rk = 5967,

        VFMSUB231PDZ256rkz = 5968,

        VFMSUB231PDZm = 5969,

        VFMSUB231PDZmb = 5970,

        VFMSUB231PDZmbk = 5971,

        VFMSUB231PDZmbkz = 5972,

        VFMSUB231PDZmk = 5973,

        VFMSUB231PDZmkz = 5974,

        VFMSUB231PDZr = 5975,

        VFMSUB231PDZrb = 5976,

        VFMSUB231PDZrbk = 5977,

        VFMSUB231PDZrbkz = 5978,

        VFMSUB231PDZrk = 5979,

        VFMSUB231PDZrkz = 5980,

        VFMSUB231PDm = 5981,

        VFMSUB231PDr = 5982,

        VFMSUB231PSYm = 5983,

        VFMSUB231PSYr = 5984,

        VFMSUB231PSZ128m = 5985,

        VFMSUB231PSZ128mb = 5986,

        VFMSUB231PSZ128mbk = 5987,

        VFMSUB231PSZ128mbkz = 5988,

        VFMSUB231PSZ128mk = 5989,

        VFMSUB231PSZ128mkz = 5990,

        VFMSUB231PSZ128r = 5991,

        VFMSUB231PSZ128rk = 5992,

        VFMSUB231PSZ128rkz = 5993,

        VFMSUB231PSZ256m = 5994,

        VFMSUB231PSZ256mb = 5995,

        VFMSUB231PSZ256mbk = 5996,

        VFMSUB231PSZ256mbkz = 5997,

        VFMSUB231PSZ256mk = 5998,

        VFMSUB231PSZ256mkz = 5999,

        VFMSUB231PSZ256r = 6000,

        VFMSUB231PSZ256rk = 6001,

        VFMSUB231PSZ256rkz = 6002,

        VFMSUB231PSZm = 6003,

        VFMSUB231PSZmb = 6004,

        VFMSUB231PSZmbk = 6005,

        VFMSUB231PSZmbkz = 6006,

        VFMSUB231PSZmk = 6007,

        VFMSUB231PSZmkz = 6008,

        VFMSUB231PSZr = 6009,

        VFMSUB231PSZrb = 6010,

        VFMSUB231PSZrbk = 6011,

        VFMSUB231PSZrbkz = 6012,

        VFMSUB231PSZrk = 6013,

        VFMSUB231PSZrkz = 6014,

        VFMSUB231PSm = 6015,

        VFMSUB231PSr = 6016,

        VFMSUB231SDZm = 6017,

        VFMSUB231SDZm_Int = 6018,

        VFMSUB231SDZm_Intk = 6019,

        VFMSUB231SDZm_Intkz = 6020,

        VFMSUB231SDZr = 6021,

        VFMSUB231SDZr_Int = 6022,

        VFMSUB231SDZr_Intk = 6023,

        VFMSUB231SDZr_Intkz = 6024,

        VFMSUB231SDZrb = 6025,

        VFMSUB231SDZrb_Int = 6026,

        VFMSUB231SDZrb_Intk = 6027,

        VFMSUB231SDZrb_Intkz = 6028,

        VFMSUB231SDm = 6029,

        VFMSUB231SDm_Int = 6030,

        VFMSUB231SDr = 6031,

        VFMSUB231SDr_Int = 6032,

        VFMSUB231SSZm = 6033,

        VFMSUB231SSZm_Int = 6034,

        VFMSUB231SSZm_Intk = 6035,

        VFMSUB231SSZm_Intkz = 6036,

        VFMSUB231SSZr = 6037,

        VFMSUB231SSZr_Int = 6038,

        VFMSUB231SSZr_Intk = 6039,

        VFMSUB231SSZr_Intkz = 6040,

        VFMSUB231SSZrb = 6041,

        VFMSUB231SSZrb_Int = 6042,

        VFMSUB231SSZrb_Intk = 6043,

        VFMSUB231SSZrb_Intkz = 6044,

        VFMSUB231SSm = 6045,

        VFMSUB231SSm_Int = 6046,

        VFMSUB231SSr = 6047,

        VFMSUB231SSr_Int = 6048,

        VFMSUBADD132PDYm = 6049,

        VFMSUBADD132PDYr = 6050,

        VFMSUBADD132PDZ128m = 6051,

        VFMSUBADD132PDZ128mb = 6052,

        VFMSUBADD132PDZ128mbk = 6053,

        VFMSUBADD132PDZ128mbkz = 6054,

        VFMSUBADD132PDZ128mk = 6055,

        VFMSUBADD132PDZ128mkz = 6056,

        VFMSUBADD132PDZ128r = 6057,

        VFMSUBADD132PDZ128rk = 6058,

        VFMSUBADD132PDZ128rkz = 6059,

        VFMSUBADD132PDZ256m = 6060,

        VFMSUBADD132PDZ256mb = 6061,

        VFMSUBADD132PDZ256mbk = 6062,

        VFMSUBADD132PDZ256mbkz = 6063,

        VFMSUBADD132PDZ256mk = 6064,

        VFMSUBADD132PDZ256mkz = 6065,

        VFMSUBADD132PDZ256r = 6066,

        VFMSUBADD132PDZ256rk = 6067,

        VFMSUBADD132PDZ256rkz = 6068,

        VFMSUBADD132PDZm = 6069,

        VFMSUBADD132PDZmb = 6070,

        VFMSUBADD132PDZmbk = 6071,

        VFMSUBADD132PDZmbkz = 6072,

        VFMSUBADD132PDZmk = 6073,

        VFMSUBADD132PDZmkz = 6074,

        VFMSUBADD132PDZr = 6075,

        VFMSUBADD132PDZrb = 6076,

        VFMSUBADD132PDZrbk = 6077,

        VFMSUBADD132PDZrbkz = 6078,

        VFMSUBADD132PDZrk = 6079,

        VFMSUBADD132PDZrkz = 6080,

        VFMSUBADD132PDm = 6081,

        VFMSUBADD132PDr = 6082,

        VFMSUBADD132PSYm = 6083,

        VFMSUBADD132PSYr = 6084,

        VFMSUBADD132PSZ128m = 6085,

        VFMSUBADD132PSZ128mb = 6086,

        VFMSUBADD132PSZ128mbk = 6087,

        VFMSUBADD132PSZ128mbkz = 6088,

        VFMSUBADD132PSZ128mk = 6089,

        VFMSUBADD132PSZ128mkz = 6090,

        VFMSUBADD132PSZ128r = 6091,

        VFMSUBADD132PSZ128rk = 6092,

        VFMSUBADD132PSZ128rkz = 6093,

        VFMSUBADD132PSZ256m = 6094,

        VFMSUBADD132PSZ256mb = 6095,

        VFMSUBADD132PSZ256mbk = 6096,

        VFMSUBADD132PSZ256mbkz = 6097,

        VFMSUBADD132PSZ256mk = 6098,

        VFMSUBADD132PSZ256mkz = 6099,

        VFMSUBADD132PSZ256r = 6100,

        VFMSUBADD132PSZ256rk = 6101,

        VFMSUBADD132PSZ256rkz = 6102,

        VFMSUBADD132PSZm = 6103,

        VFMSUBADD132PSZmb = 6104,

        VFMSUBADD132PSZmbk = 6105,

        VFMSUBADD132PSZmbkz = 6106,

        VFMSUBADD132PSZmk = 6107,

        VFMSUBADD132PSZmkz = 6108,

        VFMSUBADD132PSZr = 6109,

        VFMSUBADD132PSZrb = 6110,

        VFMSUBADD132PSZrbk = 6111,

        VFMSUBADD132PSZrbkz = 6112,

        VFMSUBADD132PSZrk = 6113,

        VFMSUBADD132PSZrkz = 6114,

        VFMSUBADD132PSm = 6115,

        VFMSUBADD132PSr = 6116,

        VFMSUBADD213PDYm = 6117,

        VFMSUBADD213PDYr = 6118,

        VFMSUBADD213PDZ128m = 6119,

        VFMSUBADD213PDZ128mb = 6120,

        VFMSUBADD213PDZ128mbk = 6121,

        VFMSUBADD213PDZ128mbkz = 6122,

        VFMSUBADD213PDZ128mk = 6123,

        VFMSUBADD213PDZ128mkz = 6124,

        VFMSUBADD213PDZ128r = 6125,

        VFMSUBADD213PDZ128rk = 6126,

        VFMSUBADD213PDZ128rkz = 6127,

        VFMSUBADD213PDZ256m = 6128,

        VFMSUBADD213PDZ256mb = 6129,

        VFMSUBADD213PDZ256mbk = 6130,

        VFMSUBADD213PDZ256mbkz = 6131,

        VFMSUBADD213PDZ256mk = 6132,

        VFMSUBADD213PDZ256mkz = 6133,

        VFMSUBADD213PDZ256r = 6134,

        VFMSUBADD213PDZ256rk = 6135,

        VFMSUBADD213PDZ256rkz = 6136,

        VFMSUBADD213PDZm = 6137,

        VFMSUBADD213PDZmb = 6138,

        VFMSUBADD213PDZmbk = 6139,

        VFMSUBADD213PDZmbkz = 6140,

        VFMSUBADD213PDZmk = 6141,

        VFMSUBADD213PDZmkz = 6142,

        VFMSUBADD213PDZr = 6143,

        VFMSUBADD213PDZrb = 6144,

        VFMSUBADD213PDZrbk = 6145,

        VFMSUBADD213PDZrbkz = 6146,

        VFMSUBADD213PDZrk = 6147,

        VFMSUBADD213PDZrkz = 6148,

        VFMSUBADD213PDm = 6149,

        VFMSUBADD213PDr = 6150,

        VFMSUBADD213PSYm = 6151,

        VFMSUBADD213PSYr = 6152,

        VFMSUBADD213PSZ128m = 6153,

        VFMSUBADD213PSZ128mb = 6154,

        VFMSUBADD213PSZ128mbk = 6155,

        VFMSUBADD213PSZ128mbkz = 6156,

        VFMSUBADD213PSZ128mk = 6157,

        VFMSUBADD213PSZ128mkz = 6158,

        VFMSUBADD213PSZ128r = 6159,

        VFMSUBADD213PSZ128rk = 6160,

        VFMSUBADD213PSZ128rkz = 6161,

        VFMSUBADD213PSZ256m = 6162,

        VFMSUBADD213PSZ256mb = 6163,

        VFMSUBADD213PSZ256mbk = 6164,

        VFMSUBADD213PSZ256mbkz = 6165,

        VFMSUBADD213PSZ256mk = 6166,

        VFMSUBADD213PSZ256mkz = 6167,

        VFMSUBADD213PSZ256r = 6168,

        VFMSUBADD213PSZ256rk = 6169,

        VFMSUBADD213PSZ256rkz = 6170,

        VFMSUBADD213PSZm = 6171,

        VFMSUBADD213PSZmb = 6172,

        VFMSUBADD213PSZmbk = 6173,

        VFMSUBADD213PSZmbkz = 6174,

        VFMSUBADD213PSZmk = 6175,

        VFMSUBADD213PSZmkz = 6176,

        VFMSUBADD213PSZr = 6177,

        VFMSUBADD213PSZrb = 6178,

        VFMSUBADD213PSZrbk = 6179,

        VFMSUBADD213PSZrbkz = 6180,

        VFMSUBADD213PSZrk = 6181,

        VFMSUBADD213PSZrkz = 6182,

        VFMSUBADD213PSm = 6183,

        VFMSUBADD213PSr = 6184,

        VFMSUBADD231PDYm = 6185,

        VFMSUBADD231PDYr = 6186,

        VFMSUBADD231PDZ128m = 6187,

        VFMSUBADD231PDZ128mb = 6188,

        VFMSUBADD231PDZ128mbk = 6189,

        VFMSUBADD231PDZ128mbkz = 6190,

        VFMSUBADD231PDZ128mk = 6191,

        VFMSUBADD231PDZ128mkz = 6192,

        VFMSUBADD231PDZ128r = 6193,

        VFMSUBADD231PDZ128rk = 6194,

        VFMSUBADD231PDZ128rkz = 6195,

        VFMSUBADD231PDZ256m = 6196,

        VFMSUBADD231PDZ256mb = 6197,

        VFMSUBADD231PDZ256mbk = 6198,

        VFMSUBADD231PDZ256mbkz = 6199,

        VFMSUBADD231PDZ256mk = 6200,

        VFMSUBADD231PDZ256mkz = 6201,

        VFMSUBADD231PDZ256r = 6202,

        VFMSUBADD231PDZ256rk = 6203,

        VFMSUBADD231PDZ256rkz = 6204,

        VFMSUBADD231PDZm = 6205,

        VFMSUBADD231PDZmb = 6206,

        VFMSUBADD231PDZmbk = 6207,

        VFMSUBADD231PDZmbkz = 6208,

        VFMSUBADD231PDZmk = 6209,

        VFMSUBADD231PDZmkz = 6210,

        VFMSUBADD231PDZr = 6211,

        VFMSUBADD231PDZrb = 6212,

        VFMSUBADD231PDZrbk = 6213,

        VFMSUBADD231PDZrbkz = 6214,

        VFMSUBADD231PDZrk = 6215,

        VFMSUBADD231PDZrkz = 6216,

        VFMSUBADD231PDm = 6217,

        VFMSUBADD231PDr = 6218,

        VFMSUBADD231PSYm = 6219,

        VFMSUBADD231PSYr = 6220,

        VFMSUBADD231PSZ128m = 6221,

        VFMSUBADD231PSZ128mb = 6222,

        VFMSUBADD231PSZ128mbk = 6223,

        VFMSUBADD231PSZ128mbkz = 6224,

        VFMSUBADD231PSZ128mk = 6225,

        VFMSUBADD231PSZ128mkz = 6226,

        VFMSUBADD231PSZ128r = 6227,

        VFMSUBADD231PSZ128rk = 6228,

        VFMSUBADD231PSZ128rkz = 6229,

        VFMSUBADD231PSZ256m = 6230,

        VFMSUBADD231PSZ256mb = 6231,

        VFMSUBADD231PSZ256mbk = 6232,

        VFMSUBADD231PSZ256mbkz = 6233,

        VFMSUBADD231PSZ256mk = 6234,

        VFMSUBADD231PSZ256mkz = 6235,

        VFMSUBADD231PSZ256r = 6236,

        VFMSUBADD231PSZ256rk = 6237,

        VFMSUBADD231PSZ256rkz = 6238,

        VFMSUBADD231PSZm = 6239,

        VFMSUBADD231PSZmb = 6240,

        VFMSUBADD231PSZmbk = 6241,

        VFMSUBADD231PSZmbkz = 6242,

        VFMSUBADD231PSZmk = 6243,

        VFMSUBADD231PSZmkz = 6244,

        VFMSUBADD231PSZr = 6245,

        VFMSUBADD231PSZrb = 6246,

        VFMSUBADD231PSZrbk = 6247,

        VFMSUBADD231PSZrbkz = 6248,

        VFMSUBADD231PSZrk = 6249,

        VFMSUBADD231PSZrkz = 6250,

        VFMSUBADD231PSm = 6251,

        VFMSUBADD231PSr = 6252,

        VFMSUBADDPD4Ymr = 6253,

        VFMSUBADDPD4Yrm = 6254,

        VFMSUBADDPD4Yrr = 6255,

        VFMSUBADDPD4Yrr_REV = 6256,

        VFMSUBADDPD4mr = 6257,

        VFMSUBADDPD4rm = 6258,

        VFMSUBADDPD4rr = 6259,

        VFMSUBADDPD4rr_REV = 6260,

        VFMSUBADDPS4Ymr = 6261,

        VFMSUBADDPS4Yrm = 6262,

        VFMSUBADDPS4Yrr = 6263,

        VFMSUBADDPS4Yrr_REV = 6264,

        VFMSUBADDPS4mr = 6265,

        VFMSUBADDPS4rm = 6266,

        VFMSUBADDPS4rr = 6267,

        VFMSUBADDPS4rr_REV = 6268,

        VFMSUBPD4Ymr = 6269,

        VFMSUBPD4Yrm = 6270,

        VFMSUBPD4Yrr = 6271,

        VFMSUBPD4Yrr_REV = 6272,

        VFMSUBPD4mr = 6273,

        VFMSUBPD4rm = 6274,

        VFMSUBPD4rr = 6275,

        VFMSUBPD4rr_REV = 6276,

        VFMSUBPS4Ymr = 6277,

        VFMSUBPS4Yrm = 6278,

        VFMSUBPS4Yrr = 6279,

        VFMSUBPS4Yrr_REV = 6280,

        VFMSUBPS4mr = 6281,

        VFMSUBPS4rm = 6282,

        VFMSUBPS4rr = 6283,

        VFMSUBPS4rr_REV = 6284,

        VFMSUBSD4mr = 6285,

        VFMSUBSD4mr_Int = 6286,

        VFMSUBSD4rm = 6287,

        VFMSUBSD4rm_Int = 6288,

        VFMSUBSD4rr = 6289,

        VFMSUBSD4rr_Int = 6290,

        VFMSUBSD4rr_Int_REV = 6291,

        VFMSUBSD4rr_REV = 6292,

        VFMSUBSS4mr = 6293,

        VFMSUBSS4mr_Int = 6294,

        VFMSUBSS4rm = 6295,

        VFMSUBSS4rm_Int = 6296,

        VFMSUBSS4rr = 6297,

        VFMSUBSS4rr_Int = 6298,

        VFMSUBSS4rr_Int_REV = 6299,

        VFMSUBSS4rr_REV = 6300,

        VFNMADD132PDYm = 6301,

        VFNMADD132PDYr = 6302,

        VFNMADD132PDZ128m = 6303,

        VFNMADD132PDZ128mb = 6304,

        VFNMADD132PDZ128mbk = 6305,

        VFNMADD132PDZ128mbkz = 6306,

        VFNMADD132PDZ128mk = 6307,

        VFNMADD132PDZ128mkz = 6308,

        VFNMADD132PDZ128r = 6309,

        VFNMADD132PDZ128rk = 6310,

        VFNMADD132PDZ128rkz = 6311,

        VFNMADD132PDZ256m = 6312,

        VFNMADD132PDZ256mb = 6313,

        VFNMADD132PDZ256mbk = 6314,

        VFNMADD132PDZ256mbkz = 6315,

        VFNMADD132PDZ256mk = 6316,

        VFNMADD132PDZ256mkz = 6317,

        VFNMADD132PDZ256r = 6318,

        VFNMADD132PDZ256rk = 6319,

        VFNMADD132PDZ256rkz = 6320,

        VFNMADD132PDZm = 6321,

        VFNMADD132PDZmb = 6322,

        VFNMADD132PDZmbk = 6323,

        VFNMADD132PDZmbkz = 6324,

        VFNMADD132PDZmk = 6325,

        VFNMADD132PDZmkz = 6326,

        VFNMADD132PDZr = 6327,

        VFNMADD132PDZrb = 6328,

        VFNMADD132PDZrbk = 6329,

        VFNMADD132PDZrbkz = 6330,

        VFNMADD132PDZrk = 6331,

        VFNMADD132PDZrkz = 6332,

        VFNMADD132PDm = 6333,

        VFNMADD132PDr = 6334,

        VFNMADD132PSYm = 6335,

        VFNMADD132PSYr = 6336,

        VFNMADD132PSZ128m = 6337,

        VFNMADD132PSZ128mb = 6338,

        VFNMADD132PSZ128mbk = 6339,

        VFNMADD132PSZ128mbkz = 6340,

        VFNMADD132PSZ128mk = 6341,

        VFNMADD132PSZ128mkz = 6342,

        VFNMADD132PSZ128r = 6343,

        VFNMADD132PSZ128rk = 6344,

        VFNMADD132PSZ128rkz = 6345,

        VFNMADD132PSZ256m = 6346,

        VFNMADD132PSZ256mb = 6347,

        VFNMADD132PSZ256mbk = 6348,

        VFNMADD132PSZ256mbkz = 6349,

        VFNMADD132PSZ256mk = 6350,

        VFNMADD132PSZ256mkz = 6351,

        VFNMADD132PSZ256r = 6352,

        VFNMADD132PSZ256rk = 6353,

        VFNMADD132PSZ256rkz = 6354,

        VFNMADD132PSZm = 6355,

        VFNMADD132PSZmb = 6356,

        VFNMADD132PSZmbk = 6357,

        VFNMADD132PSZmbkz = 6358,

        VFNMADD132PSZmk = 6359,

        VFNMADD132PSZmkz = 6360,

        VFNMADD132PSZr = 6361,

        VFNMADD132PSZrb = 6362,

        VFNMADD132PSZrbk = 6363,

        VFNMADD132PSZrbkz = 6364,

        VFNMADD132PSZrk = 6365,

        VFNMADD132PSZrkz = 6366,

        VFNMADD132PSm = 6367,

        VFNMADD132PSr = 6368,

        VFNMADD132SDZm = 6369,

        VFNMADD132SDZm_Int = 6370,

        VFNMADD132SDZm_Intk = 6371,

        VFNMADD132SDZm_Intkz = 6372,

        VFNMADD132SDZr = 6373,

        VFNMADD132SDZr_Int = 6374,

        VFNMADD132SDZr_Intk = 6375,

        VFNMADD132SDZr_Intkz = 6376,

        VFNMADD132SDZrb = 6377,

        VFNMADD132SDZrb_Int = 6378,

        VFNMADD132SDZrb_Intk = 6379,

        VFNMADD132SDZrb_Intkz = 6380,

        VFNMADD132SDm = 6381,

        VFNMADD132SDm_Int = 6382,

        VFNMADD132SDr = 6383,

        VFNMADD132SDr_Int = 6384,

        VFNMADD132SSZm = 6385,

        VFNMADD132SSZm_Int = 6386,

        VFNMADD132SSZm_Intk = 6387,

        VFNMADD132SSZm_Intkz = 6388,

        VFNMADD132SSZr = 6389,

        VFNMADD132SSZr_Int = 6390,

        VFNMADD132SSZr_Intk = 6391,

        VFNMADD132SSZr_Intkz = 6392,

        VFNMADD132SSZrb = 6393,

        VFNMADD132SSZrb_Int = 6394,

        VFNMADD132SSZrb_Intk = 6395,

        VFNMADD132SSZrb_Intkz = 6396,

        VFNMADD132SSm = 6397,

        VFNMADD132SSm_Int = 6398,

        VFNMADD132SSr = 6399,

        VFNMADD132SSr_Int = 6400,

        VFNMADD213PDYm = 6401,

        VFNMADD213PDYr = 6402,

        VFNMADD213PDZ128m = 6403,

        VFNMADD213PDZ128mb = 6404,

        VFNMADD213PDZ128mbk = 6405,

        VFNMADD213PDZ128mbkz = 6406,

        VFNMADD213PDZ128mk = 6407,

        VFNMADD213PDZ128mkz = 6408,

        VFNMADD213PDZ128r = 6409,

        VFNMADD213PDZ128rk = 6410,

        VFNMADD213PDZ128rkz = 6411,

        VFNMADD213PDZ256m = 6412,

        VFNMADD213PDZ256mb = 6413,

        VFNMADD213PDZ256mbk = 6414,

        VFNMADD213PDZ256mbkz = 6415,

        VFNMADD213PDZ256mk = 6416,

        VFNMADD213PDZ256mkz = 6417,

        VFNMADD213PDZ256r = 6418,

        VFNMADD213PDZ256rk = 6419,

        VFNMADD213PDZ256rkz = 6420,

        VFNMADD213PDZm = 6421,

        VFNMADD213PDZmb = 6422,

        VFNMADD213PDZmbk = 6423,

        VFNMADD213PDZmbkz = 6424,

        VFNMADD213PDZmk = 6425,

        VFNMADD213PDZmkz = 6426,

        VFNMADD213PDZr = 6427,

        VFNMADD213PDZrb = 6428,

        VFNMADD213PDZrbk = 6429,

        VFNMADD213PDZrbkz = 6430,

        VFNMADD213PDZrk = 6431,

        VFNMADD213PDZrkz = 6432,

        VFNMADD213PDm = 6433,

        VFNMADD213PDr = 6434,

        VFNMADD213PSYm = 6435,

        VFNMADD213PSYr = 6436,

        VFNMADD213PSZ128m = 6437,

        VFNMADD213PSZ128mb = 6438,

        VFNMADD213PSZ128mbk = 6439,

        VFNMADD213PSZ128mbkz = 6440,

        VFNMADD213PSZ128mk = 6441,

        VFNMADD213PSZ128mkz = 6442,

        VFNMADD213PSZ128r = 6443,

        VFNMADD213PSZ128rk = 6444,

        VFNMADD213PSZ128rkz = 6445,

        VFNMADD213PSZ256m = 6446,

        VFNMADD213PSZ256mb = 6447,

        VFNMADD213PSZ256mbk = 6448,

        VFNMADD213PSZ256mbkz = 6449,

        VFNMADD213PSZ256mk = 6450,

        VFNMADD213PSZ256mkz = 6451,

        VFNMADD213PSZ256r = 6452,

        VFNMADD213PSZ256rk = 6453,

        VFNMADD213PSZ256rkz = 6454,

        VFNMADD213PSZm = 6455,

        VFNMADD213PSZmb = 6456,

        VFNMADD213PSZmbk = 6457,

        VFNMADD213PSZmbkz = 6458,

        VFNMADD213PSZmk = 6459,

        VFNMADD213PSZmkz = 6460,

        VFNMADD213PSZr = 6461,

        VFNMADD213PSZrb = 6462,

        VFNMADD213PSZrbk = 6463,

        VFNMADD213PSZrbkz = 6464,

        VFNMADD213PSZrk = 6465,

        VFNMADD213PSZrkz = 6466,

        VFNMADD213PSm = 6467,

        VFNMADD213PSr = 6468,

        VFNMADD213SDZm = 6469,

        VFNMADD213SDZm_Int = 6470,

        VFNMADD213SDZm_Intk = 6471,

        VFNMADD213SDZm_Intkz = 6472,

        VFNMADD213SDZr = 6473,

        VFNMADD213SDZr_Int = 6474,

        VFNMADD213SDZr_Intk = 6475,

        VFNMADD213SDZr_Intkz = 6476,

        VFNMADD213SDZrb = 6477,

        VFNMADD213SDZrb_Int = 6478,

        VFNMADD213SDZrb_Intk = 6479,

        VFNMADD213SDZrb_Intkz = 6480,

        VFNMADD213SDm = 6481,

        VFNMADD213SDm_Int = 6482,

        VFNMADD213SDr = 6483,

        VFNMADD213SDr_Int = 6484,

        VFNMADD213SSZm = 6485,

        VFNMADD213SSZm_Int = 6486,

        VFNMADD213SSZm_Intk = 6487,

        VFNMADD213SSZm_Intkz = 6488,

        VFNMADD213SSZr = 6489,

        VFNMADD213SSZr_Int = 6490,

        VFNMADD213SSZr_Intk = 6491,

        VFNMADD213SSZr_Intkz = 6492,

        VFNMADD213SSZrb = 6493,

        VFNMADD213SSZrb_Int = 6494,

        VFNMADD213SSZrb_Intk = 6495,

        VFNMADD213SSZrb_Intkz = 6496,

        VFNMADD213SSm = 6497,

        VFNMADD213SSm_Int = 6498,

        VFNMADD213SSr = 6499,

        VFNMADD213SSr_Int = 6500,

        VFNMADD231PDYm = 6501,

        VFNMADD231PDYr = 6502,

        VFNMADD231PDZ128m = 6503,

        VFNMADD231PDZ128mb = 6504,

        VFNMADD231PDZ128mbk = 6505,

        VFNMADD231PDZ128mbkz = 6506,

        VFNMADD231PDZ128mk = 6507,

        VFNMADD231PDZ128mkz = 6508,

        VFNMADD231PDZ128r = 6509,

        VFNMADD231PDZ128rk = 6510,

        VFNMADD231PDZ128rkz = 6511,

        VFNMADD231PDZ256m = 6512,

        VFNMADD231PDZ256mb = 6513,

        VFNMADD231PDZ256mbk = 6514,

        VFNMADD231PDZ256mbkz = 6515,

        VFNMADD231PDZ256mk = 6516,

        VFNMADD231PDZ256mkz = 6517,

        VFNMADD231PDZ256r = 6518,

        VFNMADD231PDZ256rk = 6519,

        VFNMADD231PDZ256rkz = 6520,

        VFNMADD231PDZm = 6521,

        VFNMADD231PDZmb = 6522,

        VFNMADD231PDZmbk = 6523,

        VFNMADD231PDZmbkz = 6524,

        VFNMADD231PDZmk = 6525,

        VFNMADD231PDZmkz = 6526,

        VFNMADD231PDZr = 6527,

        VFNMADD231PDZrb = 6528,

        VFNMADD231PDZrbk = 6529,

        VFNMADD231PDZrbkz = 6530,

        VFNMADD231PDZrk = 6531,

        VFNMADD231PDZrkz = 6532,

        VFNMADD231PDm = 6533,

        VFNMADD231PDr = 6534,

        VFNMADD231PSYm = 6535,

        VFNMADD231PSYr = 6536,

        VFNMADD231PSZ128m = 6537,

        VFNMADD231PSZ128mb = 6538,

        VFNMADD231PSZ128mbk = 6539,

        VFNMADD231PSZ128mbkz = 6540,

        VFNMADD231PSZ128mk = 6541,

        VFNMADD231PSZ128mkz = 6542,

        VFNMADD231PSZ128r = 6543,

        VFNMADD231PSZ128rk = 6544,

        VFNMADD231PSZ128rkz = 6545,

        VFNMADD231PSZ256m = 6546,

        VFNMADD231PSZ256mb = 6547,

        VFNMADD231PSZ256mbk = 6548,

        VFNMADD231PSZ256mbkz = 6549,

        VFNMADD231PSZ256mk = 6550,

        VFNMADD231PSZ256mkz = 6551,

        VFNMADD231PSZ256r = 6552,

        VFNMADD231PSZ256rk = 6553,

        VFNMADD231PSZ256rkz = 6554,

        VFNMADD231PSZm = 6555,

        VFNMADD231PSZmb = 6556,

        VFNMADD231PSZmbk = 6557,

        VFNMADD231PSZmbkz = 6558,

        VFNMADD231PSZmk = 6559,

        VFNMADD231PSZmkz = 6560,

        VFNMADD231PSZr = 6561,

        VFNMADD231PSZrb = 6562,

        VFNMADD231PSZrbk = 6563,

        VFNMADD231PSZrbkz = 6564,

        VFNMADD231PSZrk = 6565,

        VFNMADD231PSZrkz = 6566,

        VFNMADD231PSm = 6567,

        VFNMADD231PSr = 6568,

        VFNMADD231SDZm = 6569,

        VFNMADD231SDZm_Int = 6570,

        VFNMADD231SDZm_Intk = 6571,

        VFNMADD231SDZm_Intkz = 6572,

        VFNMADD231SDZr = 6573,

        VFNMADD231SDZr_Int = 6574,

        VFNMADD231SDZr_Intk = 6575,

        VFNMADD231SDZr_Intkz = 6576,

        VFNMADD231SDZrb = 6577,

        VFNMADD231SDZrb_Int = 6578,

        VFNMADD231SDZrb_Intk = 6579,

        VFNMADD231SDZrb_Intkz = 6580,

        VFNMADD231SDm = 6581,

        VFNMADD231SDm_Int = 6582,

        VFNMADD231SDr = 6583,

        VFNMADD231SDr_Int = 6584,

        VFNMADD231SSZm = 6585,

        VFNMADD231SSZm_Int = 6586,

        VFNMADD231SSZm_Intk = 6587,

        VFNMADD231SSZm_Intkz = 6588,

        VFNMADD231SSZr = 6589,

        VFNMADD231SSZr_Int = 6590,

        VFNMADD231SSZr_Intk = 6591,

        VFNMADD231SSZr_Intkz = 6592,

        VFNMADD231SSZrb = 6593,

        VFNMADD231SSZrb_Int = 6594,

        VFNMADD231SSZrb_Intk = 6595,

        VFNMADD231SSZrb_Intkz = 6596,

        VFNMADD231SSm = 6597,

        VFNMADD231SSm_Int = 6598,

        VFNMADD231SSr = 6599,

        VFNMADD231SSr_Int = 6600,

        VFNMADDPD4Ymr = 6601,

        VFNMADDPD4Yrm = 6602,

        VFNMADDPD4Yrr = 6603,

        VFNMADDPD4Yrr_REV = 6604,

        VFNMADDPD4mr = 6605,

        VFNMADDPD4rm = 6606,

        VFNMADDPD4rr = 6607,

        VFNMADDPD4rr_REV = 6608,

        VFNMADDPS4Ymr = 6609,

        VFNMADDPS4Yrm = 6610,

        VFNMADDPS4Yrr = 6611,

        VFNMADDPS4Yrr_REV = 6612,

        VFNMADDPS4mr = 6613,

        VFNMADDPS4rm = 6614,

        VFNMADDPS4rr = 6615,

        VFNMADDPS4rr_REV = 6616,

        VFNMADDSD4mr = 6617,

        VFNMADDSD4mr_Int = 6618,

        VFNMADDSD4rm = 6619,

        VFNMADDSD4rm_Int = 6620,

        VFNMADDSD4rr = 6621,

        VFNMADDSD4rr_Int = 6622,

        VFNMADDSD4rr_Int_REV = 6623,

        VFNMADDSD4rr_REV = 6624,

        VFNMADDSS4mr = 6625,

        VFNMADDSS4mr_Int = 6626,

        VFNMADDSS4rm = 6627,

        VFNMADDSS4rm_Int = 6628,

        VFNMADDSS4rr = 6629,

        VFNMADDSS4rr_Int = 6630,

        VFNMADDSS4rr_Int_REV = 6631,

        VFNMADDSS4rr_REV = 6632,

        VFNMSUB132PDYm = 6633,

        VFNMSUB132PDYr = 6634,

        VFNMSUB132PDZ128m = 6635,

        VFNMSUB132PDZ128mb = 6636,

        VFNMSUB132PDZ128mbk = 6637,

        VFNMSUB132PDZ128mbkz = 6638,

        VFNMSUB132PDZ128mk = 6639,

        VFNMSUB132PDZ128mkz = 6640,

        VFNMSUB132PDZ128r = 6641,

        VFNMSUB132PDZ128rk = 6642,

        VFNMSUB132PDZ128rkz = 6643,

        VFNMSUB132PDZ256m = 6644,

        VFNMSUB132PDZ256mb = 6645,

        VFNMSUB132PDZ256mbk = 6646,

        VFNMSUB132PDZ256mbkz = 6647,

        VFNMSUB132PDZ256mk = 6648,

        VFNMSUB132PDZ256mkz = 6649,

        VFNMSUB132PDZ256r = 6650,

        VFNMSUB132PDZ256rk = 6651,

        VFNMSUB132PDZ256rkz = 6652,

        VFNMSUB132PDZm = 6653,

        VFNMSUB132PDZmb = 6654,

        VFNMSUB132PDZmbk = 6655,

        VFNMSUB132PDZmbkz = 6656,

        VFNMSUB132PDZmk = 6657,

        VFNMSUB132PDZmkz = 6658,

        VFNMSUB132PDZr = 6659,

        VFNMSUB132PDZrb = 6660,

        VFNMSUB132PDZrbk = 6661,

        VFNMSUB132PDZrbkz = 6662,

        VFNMSUB132PDZrk = 6663,

        VFNMSUB132PDZrkz = 6664,

        VFNMSUB132PDm = 6665,

        VFNMSUB132PDr = 6666,

        VFNMSUB132PSYm = 6667,

        VFNMSUB132PSYr = 6668,

        VFNMSUB132PSZ128m = 6669,

        VFNMSUB132PSZ128mb = 6670,

        VFNMSUB132PSZ128mbk = 6671,

        VFNMSUB132PSZ128mbkz = 6672,

        VFNMSUB132PSZ128mk = 6673,

        VFNMSUB132PSZ128mkz = 6674,

        VFNMSUB132PSZ128r = 6675,

        VFNMSUB132PSZ128rk = 6676,

        VFNMSUB132PSZ128rkz = 6677,

        VFNMSUB132PSZ256m = 6678,

        VFNMSUB132PSZ256mb = 6679,

        VFNMSUB132PSZ256mbk = 6680,

        VFNMSUB132PSZ256mbkz = 6681,

        VFNMSUB132PSZ256mk = 6682,

        VFNMSUB132PSZ256mkz = 6683,

        VFNMSUB132PSZ256r = 6684,

        VFNMSUB132PSZ256rk = 6685,

        VFNMSUB132PSZ256rkz = 6686,

        VFNMSUB132PSZm = 6687,

        VFNMSUB132PSZmb = 6688,

        VFNMSUB132PSZmbk = 6689,

        VFNMSUB132PSZmbkz = 6690,

        VFNMSUB132PSZmk = 6691,

        VFNMSUB132PSZmkz = 6692,

        VFNMSUB132PSZr = 6693,

        VFNMSUB132PSZrb = 6694,

        VFNMSUB132PSZrbk = 6695,

        VFNMSUB132PSZrbkz = 6696,

        VFNMSUB132PSZrk = 6697,

        VFNMSUB132PSZrkz = 6698,

        VFNMSUB132PSm = 6699,

        VFNMSUB132PSr = 6700,

        VFNMSUB132SDZm = 6701,

        VFNMSUB132SDZm_Int = 6702,

        VFNMSUB132SDZm_Intk = 6703,

        VFNMSUB132SDZm_Intkz = 6704,

        VFNMSUB132SDZr = 6705,

        VFNMSUB132SDZr_Int = 6706,

        VFNMSUB132SDZr_Intk = 6707,

        VFNMSUB132SDZr_Intkz = 6708,

        VFNMSUB132SDZrb = 6709,

        VFNMSUB132SDZrb_Int = 6710,

        VFNMSUB132SDZrb_Intk = 6711,

        VFNMSUB132SDZrb_Intkz = 6712,

        VFNMSUB132SDm = 6713,

        VFNMSUB132SDm_Int = 6714,

        VFNMSUB132SDr = 6715,

        VFNMSUB132SDr_Int = 6716,

        VFNMSUB132SSZm = 6717,

        VFNMSUB132SSZm_Int = 6718,

        VFNMSUB132SSZm_Intk = 6719,

        VFNMSUB132SSZm_Intkz = 6720,

        VFNMSUB132SSZr = 6721,

        VFNMSUB132SSZr_Int = 6722,

        VFNMSUB132SSZr_Intk = 6723,

        VFNMSUB132SSZr_Intkz = 6724,

        VFNMSUB132SSZrb = 6725,

        VFNMSUB132SSZrb_Int = 6726,

        VFNMSUB132SSZrb_Intk = 6727,

        VFNMSUB132SSZrb_Intkz = 6728,

        VFNMSUB132SSm = 6729,

        VFNMSUB132SSm_Int = 6730,

        VFNMSUB132SSr = 6731,

        VFNMSUB132SSr_Int = 6732,

        VFNMSUB213PDYm = 6733,

        VFNMSUB213PDYr = 6734,

        VFNMSUB213PDZ128m = 6735,

        VFNMSUB213PDZ128mb = 6736,

        VFNMSUB213PDZ128mbk = 6737,

        VFNMSUB213PDZ128mbkz = 6738,

        VFNMSUB213PDZ128mk = 6739,

        VFNMSUB213PDZ128mkz = 6740,

        VFNMSUB213PDZ128r = 6741,

        VFNMSUB213PDZ128rk = 6742,

        VFNMSUB213PDZ128rkz = 6743,

        VFNMSUB213PDZ256m = 6744,

        VFNMSUB213PDZ256mb = 6745,

        VFNMSUB213PDZ256mbk = 6746,

        VFNMSUB213PDZ256mbkz = 6747,

        VFNMSUB213PDZ256mk = 6748,

        VFNMSUB213PDZ256mkz = 6749,

        VFNMSUB213PDZ256r = 6750,

        VFNMSUB213PDZ256rk = 6751,

        VFNMSUB213PDZ256rkz = 6752,

        VFNMSUB213PDZm = 6753,

        VFNMSUB213PDZmb = 6754,

        VFNMSUB213PDZmbk = 6755,

        VFNMSUB213PDZmbkz = 6756,

        VFNMSUB213PDZmk = 6757,

        VFNMSUB213PDZmkz = 6758,

        VFNMSUB213PDZr = 6759,

        VFNMSUB213PDZrb = 6760,

        VFNMSUB213PDZrbk = 6761,

        VFNMSUB213PDZrbkz = 6762,

        VFNMSUB213PDZrk = 6763,

        VFNMSUB213PDZrkz = 6764,

        VFNMSUB213PDm = 6765,

        VFNMSUB213PDr = 6766,

        VFNMSUB213PSYm = 6767,

        VFNMSUB213PSYr = 6768,

        VFNMSUB213PSZ128m = 6769,

        VFNMSUB213PSZ128mb = 6770,

        VFNMSUB213PSZ128mbk = 6771,

        VFNMSUB213PSZ128mbkz = 6772,

        VFNMSUB213PSZ128mk = 6773,

        VFNMSUB213PSZ128mkz = 6774,

        VFNMSUB213PSZ128r = 6775,

        VFNMSUB213PSZ128rk = 6776,

        VFNMSUB213PSZ128rkz = 6777,

        VFNMSUB213PSZ256m = 6778,

        VFNMSUB213PSZ256mb = 6779,

        VFNMSUB213PSZ256mbk = 6780,

        VFNMSUB213PSZ256mbkz = 6781,

        VFNMSUB213PSZ256mk = 6782,

        VFNMSUB213PSZ256mkz = 6783,

        VFNMSUB213PSZ256r = 6784,

        VFNMSUB213PSZ256rk = 6785,

        VFNMSUB213PSZ256rkz = 6786,

        VFNMSUB213PSZm = 6787,

        VFNMSUB213PSZmb = 6788,

        VFNMSUB213PSZmbk = 6789,

        VFNMSUB213PSZmbkz = 6790,

        VFNMSUB213PSZmk = 6791,

        VFNMSUB213PSZmkz = 6792,

        VFNMSUB213PSZr = 6793,

        VFNMSUB213PSZrb = 6794,

        VFNMSUB213PSZrbk = 6795,

        VFNMSUB213PSZrbkz = 6796,

        VFNMSUB213PSZrk = 6797,

        VFNMSUB213PSZrkz = 6798,

        VFNMSUB213PSm = 6799,

        VFNMSUB213PSr = 6800,

        VFNMSUB213SDZm = 6801,

        VFNMSUB213SDZm_Int = 6802,

        VFNMSUB213SDZm_Intk = 6803,

        VFNMSUB213SDZm_Intkz = 6804,

        VFNMSUB213SDZr = 6805,

        VFNMSUB213SDZr_Int = 6806,

        VFNMSUB213SDZr_Intk = 6807,

        VFNMSUB213SDZr_Intkz = 6808,

        VFNMSUB213SDZrb = 6809,

        VFNMSUB213SDZrb_Int = 6810,

        VFNMSUB213SDZrb_Intk = 6811,

        VFNMSUB213SDZrb_Intkz = 6812,

        VFNMSUB213SDm = 6813,

        VFNMSUB213SDm_Int = 6814,

        VFNMSUB213SDr = 6815,

        VFNMSUB213SDr_Int = 6816,

        VFNMSUB213SSZm = 6817,

        VFNMSUB213SSZm_Int = 6818,

        VFNMSUB213SSZm_Intk = 6819,

        VFNMSUB213SSZm_Intkz = 6820,

        VFNMSUB213SSZr = 6821,

        VFNMSUB213SSZr_Int = 6822,

        VFNMSUB213SSZr_Intk = 6823,

        VFNMSUB213SSZr_Intkz = 6824,

        VFNMSUB213SSZrb = 6825,

        VFNMSUB213SSZrb_Int = 6826,

        VFNMSUB213SSZrb_Intk = 6827,

        VFNMSUB213SSZrb_Intkz = 6828,

        VFNMSUB213SSm = 6829,

        VFNMSUB213SSm_Int = 6830,

        VFNMSUB213SSr = 6831,

        VFNMSUB213SSr_Int = 6832,

        VFNMSUB231PDYm = 6833,

        VFNMSUB231PDYr = 6834,

        VFNMSUB231PDZ128m = 6835,

        VFNMSUB231PDZ128mb = 6836,

        VFNMSUB231PDZ128mbk = 6837,

        VFNMSUB231PDZ128mbkz = 6838,

        VFNMSUB231PDZ128mk = 6839,

        VFNMSUB231PDZ128mkz = 6840,

        VFNMSUB231PDZ128r = 6841,

        VFNMSUB231PDZ128rk = 6842,

        VFNMSUB231PDZ128rkz = 6843,

        VFNMSUB231PDZ256m = 6844,

        VFNMSUB231PDZ256mb = 6845,

        VFNMSUB231PDZ256mbk = 6846,

        VFNMSUB231PDZ256mbkz = 6847,

        VFNMSUB231PDZ256mk = 6848,

        VFNMSUB231PDZ256mkz = 6849,

        VFNMSUB231PDZ256r = 6850,

        VFNMSUB231PDZ256rk = 6851,

        VFNMSUB231PDZ256rkz = 6852,

        VFNMSUB231PDZm = 6853,

        VFNMSUB231PDZmb = 6854,

        VFNMSUB231PDZmbk = 6855,

        VFNMSUB231PDZmbkz = 6856,

        VFNMSUB231PDZmk = 6857,

        VFNMSUB231PDZmkz = 6858,

        VFNMSUB231PDZr = 6859,

        VFNMSUB231PDZrb = 6860,

        VFNMSUB231PDZrbk = 6861,

        VFNMSUB231PDZrbkz = 6862,

        VFNMSUB231PDZrk = 6863,

        VFNMSUB231PDZrkz = 6864,

        VFNMSUB231PDm = 6865,

        VFNMSUB231PDr = 6866,

        VFNMSUB231PSYm = 6867,

        VFNMSUB231PSYr = 6868,

        VFNMSUB231PSZ128m = 6869,

        VFNMSUB231PSZ128mb = 6870,

        VFNMSUB231PSZ128mbk = 6871,

        VFNMSUB231PSZ128mbkz = 6872,

        VFNMSUB231PSZ128mk = 6873,

        VFNMSUB231PSZ128mkz = 6874,

        VFNMSUB231PSZ128r = 6875,

        VFNMSUB231PSZ128rk = 6876,

        VFNMSUB231PSZ128rkz = 6877,

        VFNMSUB231PSZ256m = 6878,

        VFNMSUB231PSZ256mb = 6879,

        VFNMSUB231PSZ256mbk = 6880,

        VFNMSUB231PSZ256mbkz = 6881,

        VFNMSUB231PSZ256mk = 6882,

        VFNMSUB231PSZ256mkz = 6883,

        VFNMSUB231PSZ256r = 6884,

        VFNMSUB231PSZ256rk = 6885,

        VFNMSUB231PSZ256rkz = 6886,

        VFNMSUB231PSZm = 6887,

        VFNMSUB231PSZmb = 6888,

        VFNMSUB231PSZmbk = 6889,

        VFNMSUB231PSZmbkz = 6890,

        VFNMSUB231PSZmk = 6891,

        VFNMSUB231PSZmkz = 6892,

        VFNMSUB231PSZr = 6893,

        VFNMSUB231PSZrb = 6894,

        VFNMSUB231PSZrbk = 6895,

        VFNMSUB231PSZrbkz = 6896,

        VFNMSUB231PSZrk = 6897,

        VFNMSUB231PSZrkz = 6898,

        VFNMSUB231PSm = 6899,

        VFNMSUB231PSr = 6900,

        VFNMSUB231SDZm = 6901,

        VFNMSUB231SDZm_Int = 6902,

        VFNMSUB231SDZm_Intk = 6903,

        VFNMSUB231SDZm_Intkz = 6904,

        VFNMSUB231SDZr = 6905,

        VFNMSUB231SDZr_Int = 6906,

        VFNMSUB231SDZr_Intk = 6907,

        VFNMSUB231SDZr_Intkz = 6908,

        VFNMSUB231SDZrb = 6909,

        VFNMSUB231SDZrb_Int = 6910,

        VFNMSUB231SDZrb_Intk = 6911,

        VFNMSUB231SDZrb_Intkz = 6912,

        VFNMSUB231SDm = 6913,

        VFNMSUB231SDm_Int = 6914,

        VFNMSUB231SDr = 6915,

        VFNMSUB231SDr_Int = 6916,

        VFNMSUB231SSZm = 6917,

        VFNMSUB231SSZm_Int = 6918,

        VFNMSUB231SSZm_Intk = 6919,

        VFNMSUB231SSZm_Intkz = 6920,

        VFNMSUB231SSZr = 6921,

        VFNMSUB231SSZr_Int = 6922,

        VFNMSUB231SSZr_Intk = 6923,

        VFNMSUB231SSZr_Intkz = 6924,

        VFNMSUB231SSZrb = 6925,

        VFNMSUB231SSZrb_Int = 6926,

        VFNMSUB231SSZrb_Intk = 6927,

        VFNMSUB231SSZrb_Intkz = 6928,

        VFNMSUB231SSm = 6929,

        VFNMSUB231SSm_Int = 6930,

        VFNMSUB231SSr = 6931,

        VFNMSUB231SSr_Int = 6932,

        VFNMSUBPD4Ymr = 6933,

        VFNMSUBPD4Yrm = 6934,

        VFNMSUBPD4Yrr = 6935,

        VFNMSUBPD4Yrr_REV = 6936,

        VFNMSUBPD4mr = 6937,

        VFNMSUBPD4rm = 6938,

        VFNMSUBPD4rr = 6939,

        VFNMSUBPD4rr_REV = 6940,

        VFNMSUBPS4Ymr = 6941,

        VFNMSUBPS4Yrm = 6942,

        VFNMSUBPS4Yrr = 6943,

        VFNMSUBPS4Yrr_REV = 6944,

        VFNMSUBPS4mr = 6945,

        VFNMSUBPS4rm = 6946,

        VFNMSUBPS4rr = 6947,

        VFNMSUBPS4rr_REV = 6948,

        VFNMSUBSD4mr = 6949,

        VFNMSUBSD4mr_Int = 6950,

        VFNMSUBSD4rm = 6951,

        VFNMSUBSD4rm_Int = 6952,

        VFNMSUBSD4rr = 6953,

        VFNMSUBSD4rr_Int = 6954,

        VFNMSUBSD4rr_Int_REV = 6955,

        VFNMSUBSD4rr_REV = 6956,

        VFNMSUBSS4mr = 6957,

        VFNMSUBSS4mr_Int = 6958,

        VFNMSUBSS4rm = 6959,

        VFNMSUBSS4rm_Int = 6960,

        VFNMSUBSS4rr = 6961,

        VFNMSUBSS4rr_Int = 6962,

        VFNMSUBSS4rr_Int_REV = 6963,

        VFNMSUBSS4rr_REV = 6964,

        VFPCLASSPDZ128rm = 6965,

        VFPCLASSPDZ128rmb = 6966,

        VFPCLASSPDZ128rmbk = 6967,

        VFPCLASSPDZ128rmk = 6968,

        VFPCLASSPDZ128rr = 6969,

        VFPCLASSPDZ128rrk = 6970,

        VFPCLASSPDZ256rm = 6971,

        VFPCLASSPDZ256rmb = 6972,

        VFPCLASSPDZ256rmbk = 6973,

        VFPCLASSPDZ256rmk = 6974,

        VFPCLASSPDZ256rr = 6975,

        VFPCLASSPDZ256rrk = 6976,

        VFPCLASSPDZrm = 6977,

        VFPCLASSPDZrmb = 6978,

        VFPCLASSPDZrmbk = 6979,

        VFPCLASSPDZrmk = 6980,

        VFPCLASSPDZrr = 6981,

        VFPCLASSPDZrrk = 6982,

        VFPCLASSPSZ128rm = 6983,

        VFPCLASSPSZ128rmb = 6984,

        VFPCLASSPSZ128rmbk = 6985,

        VFPCLASSPSZ128rmk = 6986,

        VFPCLASSPSZ128rr = 6987,

        VFPCLASSPSZ128rrk = 6988,

        VFPCLASSPSZ256rm = 6989,

        VFPCLASSPSZ256rmb = 6990,

        VFPCLASSPSZ256rmbk = 6991,

        VFPCLASSPSZ256rmk = 6992,

        VFPCLASSPSZ256rr = 6993,

        VFPCLASSPSZ256rrk = 6994,

        VFPCLASSPSZrm = 6995,

        VFPCLASSPSZrmb = 6996,

        VFPCLASSPSZrmbk = 6997,

        VFPCLASSPSZrmk = 6998,

        VFPCLASSPSZrr = 6999,

        VFPCLASSPSZrrk = 7000,

        VFPCLASSSDZrm = 7001,

        VFPCLASSSDZrmk = 7002,

        VFPCLASSSDZrr = 7003,

        VFPCLASSSDZrrk = 7004,

        VFPCLASSSSZrm = 7005,

        VFPCLASSSSZrmk = 7006,

        VFPCLASSSSZrr = 7007,

        VFPCLASSSSZrrk = 7008,

        VFRCZPDYrm = 7009,

        VFRCZPDYrr = 7010,

        VFRCZPDrm = 7011,

        VFRCZPDrr = 7012,

        VFRCZPSYrm = 7013,

        VFRCZPSYrr = 7014,

        VFRCZPSrm = 7015,

        VFRCZPSrr = 7016,

        VFRCZSDrm = 7017,

        VFRCZSDrr = 7018,

        VFRCZSSrm = 7019,

        VFRCZSSrr = 7020,

        VGATHERDPDYrm = 7021,

        VGATHERDPDZ128rm = 7022,

        VGATHERDPDZ256rm = 7023,

        VGATHERDPDZrm = 7024,

        VGATHERDPDrm = 7025,

        VGATHERDPSYrm = 7026,

        VGATHERDPSZ128rm = 7027,

        VGATHERDPSZ256rm = 7028,

        VGATHERDPSZrm = 7029,

        VGATHERDPSrm = 7030,

        VGATHERPF0DPDm = 7031,

        VGATHERPF0DPSm = 7032,

        VGATHERPF0QPDm = 7033,

        VGATHERPF0QPSm = 7034,

        VGATHERPF1DPDm = 7035,

        VGATHERPF1DPSm = 7036,

        VGATHERPF1QPDm = 7037,

        VGATHERPF1QPSm = 7038,

        VGATHERQPDYrm = 7039,

        VGATHERQPDZ128rm = 7040,

        VGATHERQPDZ256rm = 7041,

        VGATHERQPDZrm = 7042,

        VGATHERQPDrm = 7043,

        VGATHERQPSYrm = 7044,

        VGATHERQPSZ128rm = 7045,

        VGATHERQPSZ256rm = 7046,

        VGATHERQPSZrm = 7047,

        VGATHERQPSrm = 7048,

        VGETEXPPDZ128m = 7049,

        VGETEXPPDZ128mb = 7050,

        VGETEXPPDZ128mbk = 7051,

        VGETEXPPDZ128mbkz = 7052,

        VGETEXPPDZ128mk = 7053,

        VGETEXPPDZ128mkz = 7054,

        VGETEXPPDZ128r = 7055,

        VGETEXPPDZ128rk = 7056,

        VGETEXPPDZ128rkz = 7057,

        VGETEXPPDZ256m = 7058,

        VGETEXPPDZ256mb = 7059,

        VGETEXPPDZ256mbk = 7060,

        VGETEXPPDZ256mbkz = 7061,

        VGETEXPPDZ256mk = 7062,

        VGETEXPPDZ256mkz = 7063,

        VGETEXPPDZ256r = 7064,

        VGETEXPPDZ256rk = 7065,

        VGETEXPPDZ256rkz = 7066,

        VGETEXPPDZm = 7067,

        VGETEXPPDZmb = 7068,

        VGETEXPPDZmbk = 7069,

        VGETEXPPDZmbkz = 7070,

        VGETEXPPDZmk = 7071,

        VGETEXPPDZmkz = 7072,

        VGETEXPPDZr = 7073,

        VGETEXPPDZrb = 7074,

        VGETEXPPDZrbk = 7075,

        VGETEXPPDZrbkz = 7076,

        VGETEXPPDZrk = 7077,

        VGETEXPPDZrkz = 7078,

        VGETEXPPSZ128m = 7079,

        VGETEXPPSZ128mb = 7080,

        VGETEXPPSZ128mbk = 7081,

        VGETEXPPSZ128mbkz = 7082,

        VGETEXPPSZ128mk = 7083,

        VGETEXPPSZ128mkz = 7084,

        VGETEXPPSZ128r = 7085,

        VGETEXPPSZ128rk = 7086,

        VGETEXPPSZ128rkz = 7087,

        VGETEXPPSZ256m = 7088,

        VGETEXPPSZ256mb = 7089,

        VGETEXPPSZ256mbk = 7090,

        VGETEXPPSZ256mbkz = 7091,

        VGETEXPPSZ256mk = 7092,

        VGETEXPPSZ256mkz = 7093,

        VGETEXPPSZ256r = 7094,

        VGETEXPPSZ256rk = 7095,

        VGETEXPPSZ256rkz = 7096,

        VGETEXPPSZm = 7097,

        VGETEXPPSZmb = 7098,

        VGETEXPPSZmbk = 7099,

        VGETEXPPSZmbkz = 7100,

        VGETEXPPSZmk = 7101,

        VGETEXPPSZmkz = 7102,

        VGETEXPPSZr = 7103,

        VGETEXPPSZrb = 7104,

        VGETEXPPSZrbk = 7105,

        VGETEXPPSZrbkz = 7106,

        VGETEXPPSZrk = 7107,

        VGETEXPPSZrkz = 7108,

        VGETEXPSDZm = 7109,

        VGETEXPSDZmk = 7110,

        VGETEXPSDZmkz = 7111,

        VGETEXPSDZr = 7112,

        VGETEXPSDZrb = 7113,

        VGETEXPSDZrbk = 7114,

        VGETEXPSDZrbkz = 7115,

        VGETEXPSDZrk = 7116,

        VGETEXPSDZrkz = 7117,

        VGETEXPSSZm = 7118,

        VGETEXPSSZmk = 7119,

        VGETEXPSSZmkz = 7120,

        VGETEXPSSZr = 7121,

        VGETEXPSSZrb = 7122,

        VGETEXPSSZrbk = 7123,

        VGETEXPSSZrbkz = 7124,

        VGETEXPSSZrk = 7125,

        VGETEXPSSZrkz = 7126,

        VGETMANTPDZ128rmbi = 7127,

        VGETMANTPDZ128rmbik = 7128,

        VGETMANTPDZ128rmbikz = 7129,

        VGETMANTPDZ128rmi = 7130,

        VGETMANTPDZ128rmik = 7131,

        VGETMANTPDZ128rmikz = 7132,

        VGETMANTPDZ128rri = 7133,

        VGETMANTPDZ128rrik = 7134,

        VGETMANTPDZ128rrikz = 7135,

        VGETMANTPDZ256rmbi = 7136,

        VGETMANTPDZ256rmbik = 7137,

        VGETMANTPDZ256rmbikz = 7138,

        VGETMANTPDZ256rmi = 7139,

        VGETMANTPDZ256rmik = 7140,

        VGETMANTPDZ256rmikz = 7141,

        VGETMANTPDZ256rri = 7142,

        VGETMANTPDZ256rrik = 7143,

        VGETMANTPDZ256rrikz = 7144,

        VGETMANTPDZrmbi = 7145,

        VGETMANTPDZrmbik = 7146,

        VGETMANTPDZrmbikz = 7147,

        VGETMANTPDZrmi = 7148,

        VGETMANTPDZrmik = 7149,

        VGETMANTPDZrmikz = 7150,

        VGETMANTPDZrri = 7151,

        VGETMANTPDZrrib = 7152,

        VGETMANTPDZrribk = 7153,

        VGETMANTPDZrribkz = 7154,

        VGETMANTPDZrrik = 7155,

        VGETMANTPDZrrikz = 7156,

        VGETMANTPSZ128rmbi = 7157,

        VGETMANTPSZ128rmbik = 7158,

        VGETMANTPSZ128rmbikz = 7159,

        VGETMANTPSZ128rmi = 7160,

        VGETMANTPSZ128rmik = 7161,

        VGETMANTPSZ128rmikz = 7162,

        VGETMANTPSZ128rri = 7163,

        VGETMANTPSZ128rrik = 7164,

        VGETMANTPSZ128rrikz = 7165,

        VGETMANTPSZ256rmbi = 7166,

        VGETMANTPSZ256rmbik = 7167,

        VGETMANTPSZ256rmbikz = 7168,

        VGETMANTPSZ256rmi = 7169,

        VGETMANTPSZ256rmik = 7170,

        VGETMANTPSZ256rmikz = 7171,

        VGETMANTPSZ256rri = 7172,

        VGETMANTPSZ256rrik = 7173,

        VGETMANTPSZ256rrikz = 7174,

        VGETMANTPSZrmbi = 7175,

        VGETMANTPSZrmbik = 7176,

        VGETMANTPSZrmbikz = 7177,

        VGETMANTPSZrmi = 7178,

        VGETMANTPSZrmik = 7179,

        VGETMANTPSZrmikz = 7180,

        VGETMANTPSZrri = 7181,

        VGETMANTPSZrrib = 7182,

        VGETMANTPSZrribk = 7183,

        VGETMANTPSZrribkz = 7184,

        VGETMANTPSZrrik = 7185,

        VGETMANTPSZrrikz = 7186,

        VGETMANTSDZrmi = 7187,

        VGETMANTSDZrmik = 7188,

        VGETMANTSDZrmikz = 7189,

        VGETMANTSDZrri = 7190,

        VGETMANTSDZrrib = 7191,

        VGETMANTSDZrribk = 7192,

        VGETMANTSDZrribkz = 7193,

        VGETMANTSDZrrik = 7194,

        VGETMANTSDZrrikz = 7195,

        VGETMANTSSZrmi = 7196,

        VGETMANTSSZrmik = 7197,

        VGETMANTSSZrmikz = 7198,

        VGETMANTSSZrri = 7199,

        VGETMANTSSZrrib = 7200,

        VGETMANTSSZrribk = 7201,

        VGETMANTSSZrribkz = 7202,

        VGETMANTSSZrrik = 7203,

        VGETMANTSSZrrikz = 7204,

        VGF2P8AFFINEINVQBYrmi = 7205,

        VGF2P8AFFINEINVQBYrri = 7206,

        VGF2P8AFFINEINVQBZ128rmbi = 7207,

        VGF2P8AFFINEINVQBZ128rmbik = 7208,

        VGF2P8AFFINEINVQBZ128rmbikz = 7209,

        VGF2P8AFFINEINVQBZ128rmi = 7210,

        VGF2P8AFFINEINVQBZ128rmik = 7211,

        VGF2P8AFFINEINVQBZ128rmikz = 7212,

        VGF2P8AFFINEINVQBZ128rri = 7213,

        VGF2P8AFFINEINVQBZ128rrik = 7214,

        VGF2P8AFFINEINVQBZ128rrikz = 7215,

        VGF2P8AFFINEINVQBZ256rmbi = 7216,

        VGF2P8AFFINEINVQBZ256rmbik = 7217,

        VGF2P8AFFINEINVQBZ256rmbikz = 7218,

        VGF2P8AFFINEINVQBZ256rmi = 7219,

        VGF2P8AFFINEINVQBZ256rmik = 7220,

        VGF2P8AFFINEINVQBZ256rmikz = 7221,

        VGF2P8AFFINEINVQBZ256rri = 7222,

        VGF2P8AFFINEINVQBZ256rrik = 7223,

        VGF2P8AFFINEINVQBZ256rrikz = 7224,

        VGF2P8AFFINEINVQBZrmbi = 7225,

        VGF2P8AFFINEINVQBZrmbik = 7226,

        VGF2P8AFFINEINVQBZrmbikz = 7227,

        VGF2P8AFFINEINVQBZrmi = 7228,

        VGF2P8AFFINEINVQBZrmik = 7229,

        VGF2P8AFFINEINVQBZrmikz = 7230,

        VGF2P8AFFINEINVQBZrri = 7231,

        VGF2P8AFFINEINVQBZrrik = 7232,

        VGF2P8AFFINEINVQBZrrikz = 7233,

        VGF2P8AFFINEINVQBrmi = 7234,

        VGF2P8AFFINEINVQBrri = 7235,

        VGF2P8AFFINEQBYrmi = 7236,

        VGF2P8AFFINEQBYrri = 7237,

        VGF2P8AFFINEQBZ128rmbi = 7238,

        VGF2P8AFFINEQBZ128rmbik = 7239,

        VGF2P8AFFINEQBZ128rmbikz = 7240,

        VGF2P8AFFINEQBZ128rmi = 7241,

        VGF2P8AFFINEQBZ128rmik = 7242,

        VGF2P8AFFINEQBZ128rmikz = 7243,

        VGF2P8AFFINEQBZ128rri = 7244,

        VGF2P8AFFINEQBZ128rrik = 7245,

        VGF2P8AFFINEQBZ128rrikz = 7246,

        VGF2P8AFFINEQBZ256rmbi = 7247,

        VGF2P8AFFINEQBZ256rmbik = 7248,

        VGF2P8AFFINEQBZ256rmbikz = 7249,

        VGF2P8AFFINEQBZ256rmi = 7250,

        VGF2P8AFFINEQBZ256rmik = 7251,

        VGF2P8AFFINEQBZ256rmikz = 7252,

        VGF2P8AFFINEQBZ256rri = 7253,

        VGF2P8AFFINEQBZ256rrik = 7254,

        VGF2P8AFFINEQBZ256rrikz = 7255,

        VGF2P8AFFINEQBZrmbi = 7256,

        VGF2P8AFFINEQBZrmbik = 7257,

        VGF2P8AFFINEQBZrmbikz = 7258,

        VGF2P8AFFINEQBZrmi = 7259,

        VGF2P8AFFINEQBZrmik = 7260,

        VGF2P8AFFINEQBZrmikz = 7261,

        VGF2P8AFFINEQBZrri = 7262,

        VGF2P8AFFINEQBZrrik = 7263,

        VGF2P8AFFINEQBZrrikz = 7264,

        VGF2P8AFFINEQBrmi = 7265,

        VGF2P8AFFINEQBrri = 7266,

        VGF2P8MULBYrm = 7267,

        VGF2P8MULBYrr = 7268,

        VGF2P8MULBZ128rm = 7269,

        VGF2P8MULBZ128rmk = 7270,

        VGF2P8MULBZ128rmkz = 7271,

        VGF2P8MULBZ128rr = 7272,

        VGF2P8MULBZ128rrk = 7273,

        VGF2P8MULBZ128rrkz = 7274,

        VGF2P8MULBZ256rm = 7275,

        VGF2P8MULBZ256rmk = 7276,

        VGF2P8MULBZ256rmkz = 7277,

        VGF2P8MULBZ256rr = 7278,

        VGF2P8MULBZ256rrk = 7279,

        VGF2P8MULBZ256rrkz = 7280,

        VGF2P8MULBZrm = 7281,

        VGF2P8MULBZrmk = 7282,

        VGF2P8MULBZrmkz = 7283,

        VGF2P8MULBZrr = 7284,

        VGF2P8MULBZrrk = 7285,

        VGF2P8MULBZrrkz = 7286,

        VGF2P8MULBrm = 7287,

        VGF2P8MULBrr = 7288,

        VHADDPDYrm = 7289,

        VHADDPDYrr = 7290,

        VHADDPDrm = 7291,

        VHADDPDrr = 7292,

        VHADDPSYrm = 7293,

        VHADDPSYrr = 7294,

        VHADDPSrm = 7295,

        VHADDPSrr = 7296,

        VHSUBPDYrm = 7297,

        VHSUBPDYrr = 7298,

        VHSUBPDrm = 7299,

        VHSUBPDrr = 7300,

        VHSUBPSYrm = 7301,

        VHSUBPSYrr = 7302,

        VHSUBPSrm = 7303,

        VHSUBPSrr = 7304,

        VINSERTF128rm = 7305,

        VINSERTF128rr = 7306,

        VINSERTF32x4Z256rm = 7307,

        VINSERTF32x4Z256rmk = 7308,

        VINSERTF32x4Z256rmkz = 7309,

        VINSERTF32x4Z256rr = 7310,

        VINSERTF32x4Z256rrk = 7311,

        VINSERTF32x4Z256rrkz = 7312,

        VINSERTF32x4Zrm = 7313,

        VINSERTF32x4Zrmk = 7314,

        VINSERTF32x4Zrmkz = 7315,

        VINSERTF32x4Zrr = 7316,

        VINSERTF32x4Zrrk = 7317,

        VINSERTF32x4Zrrkz = 7318,

        VINSERTF32x8Zrm = 7319,

        VINSERTF32x8Zrmk = 7320,

        VINSERTF32x8Zrmkz = 7321,

        VINSERTF32x8Zrr = 7322,

        VINSERTF32x8Zrrk = 7323,

        VINSERTF32x8Zrrkz = 7324,

        VINSERTF64x2Z256rm = 7325,

        VINSERTF64x2Z256rmk = 7326,

        VINSERTF64x2Z256rmkz = 7327,

        VINSERTF64x2Z256rr = 7328,

        VINSERTF64x2Z256rrk = 7329,

        VINSERTF64x2Z256rrkz = 7330,

        VINSERTF64x2Zrm = 7331,

        VINSERTF64x2Zrmk = 7332,

        VINSERTF64x2Zrmkz = 7333,

        VINSERTF64x2Zrr = 7334,

        VINSERTF64x2Zrrk = 7335,

        VINSERTF64x2Zrrkz = 7336,

        VINSERTF64x4Zrm = 7337,

        VINSERTF64x4Zrmk = 7338,

        VINSERTF64x4Zrmkz = 7339,

        VINSERTF64x4Zrr = 7340,

        VINSERTF64x4Zrrk = 7341,

        VINSERTF64x4Zrrkz = 7342,

        VINSERTI128rm = 7343,

        VINSERTI128rr = 7344,

        VINSERTI32x4Z256rm = 7345,

        VINSERTI32x4Z256rmk = 7346,

        VINSERTI32x4Z256rmkz = 7347,

        VINSERTI32x4Z256rr = 7348,

        VINSERTI32x4Z256rrk = 7349,

        VINSERTI32x4Z256rrkz = 7350,

        VINSERTI32x4Zrm = 7351,

        VINSERTI32x4Zrmk = 7352,

        VINSERTI32x4Zrmkz = 7353,

        VINSERTI32x4Zrr = 7354,

        VINSERTI32x4Zrrk = 7355,

        VINSERTI32x4Zrrkz = 7356,

        VINSERTI32x8Zrm = 7357,

        VINSERTI32x8Zrmk = 7358,

        VINSERTI32x8Zrmkz = 7359,

        VINSERTI32x8Zrr = 7360,

        VINSERTI32x8Zrrk = 7361,

        VINSERTI32x8Zrrkz = 7362,

        VINSERTI64x2Z256rm = 7363,

        VINSERTI64x2Z256rmk = 7364,

        VINSERTI64x2Z256rmkz = 7365,

        VINSERTI64x2Z256rr = 7366,

        VINSERTI64x2Z256rrk = 7367,

        VINSERTI64x2Z256rrkz = 7368,

        VINSERTI64x2Zrm = 7369,

        VINSERTI64x2Zrmk = 7370,

        VINSERTI64x2Zrmkz = 7371,

        VINSERTI64x2Zrr = 7372,

        VINSERTI64x2Zrrk = 7373,

        VINSERTI64x2Zrrkz = 7374,

        VINSERTI64x4Zrm = 7375,

        VINSERTI64x4Zrmk = 7376,

        VINSERTI64x4Zrmkz = 7377,

        VINSERTI64x4Zrr = 7378,

        VINSERTI64x4Zrrk = 7379,

        VINSERTI64x4Zrrkz = 7380,

        VINSERTPSZrm = 7381,

        VINSERTPSZrr = 7382,

        VINSERTPSrm = 7383,

        VINSERTPSrr = 7384,

        VLDDQUYrm = 7385,

        VLDDQUrm = 7386,

        VLDMXCSR = 7387,

        VMASKMOVDQU = 7388,

        VMASKMOVDQU64 = 7389,

        VMASKMOVDQUX32 = 7390,

        VMASKMOVPDYmr = 7391,

        VMASKMOVPDYrm = 7392,

        VMASKMOVPDmr = 7393,

        VMASKMOVPDrm = 7394,

        VMASKMOVPSYmr = 7395,

        VMASKMOVPSYrm = 7396,

        VMASKMOVPSmr = 7397,

        VMASKMOVPSrm = 7398,

        VMAXCPDYrm = 7399,

        VMAXCPDYrr = 7400,

        VMAXCPDZ128rm = 7401,

        VMAXCPDZ128rmb = 7402,

        VMAXCPDZ128rmbk = 7403,

        VMAXCPDZ128rmbkz = 7404,

        VMAXCPDZ128rmk = 7405,

        VMAXCPDZ128rmkz = 7406,

        VMAXCPDZ128rr = 7407,

        VMAXCPDZ128rrk = 7408,

        VMAXCPDZ128rrkz = 7409,

        VMAXCPDZ256rm = 7410,

        VMAXCPDZ256rmb = 7411,

        VMAXCPDZ256rmbk = 7412,

        VMAXCPDZ256rmbkz = 7413,

        VMAXCPDZ256rmk = 7414,

        VMAXCPDZ256rmkz = 7415,

        VMAXCPDZ256rr = 7416,

        VMAXCPDZ256rrk = 7417,

        VMAXCPDZ256rrkz = 7418,

        VMAXCPDZrm = 7419,

        VMAXCPDZrmb = 7420,

        VMAXCPDZrmbk = 7421,

        VMAXCPDZrmbkz = 7422,

        VMAXCPDZrmk = 7423,

        VMAXCPDZrmkz = 7424,

        VMAXCPDZrr = 7425,

        VMAXCPDZrrk = 7426,

        VMAXCPDZrrkz = 7427,

        VMAXCPDrm = 7428,

        VMAXCPDrr = 7429,

        VMAXCPSYrm = 7430,

        VMAXCPSYrr = 7431,

        VMAXCPSZ128rm = 7432,

        VMAXCPSZ128rmb = 7433,

        VMAXCPSZ128rmbk = 7434,

        VMAXCPSZ128rmbkz = 7435,

        VMAXCPSZ128rmk = 7436,

        VMAXCPSZ128rmkz = 7437,

        VMAXCPSZ128rr = 7438,

        VMAXCPSZ128rrk = 7439,

        VMAXCPSZ128rrkz = 7440,

        VMAXCPSZ256rm = 7441,

        VMAXCPSZ256rmb = 7442,

        VMAXCPSZ256rmbk = 7443,

        VMAXCPSZ256rmbkz = 7444,

        VMAXCPSZ256rmk = 7445,

        VMAXCPSZ256rmkz = 7446,

        VMAXCPSZ256rr = 7447,

        VMAXCPSZ256rrk = 7448,

        VMAXCPSZ256rrkz = 7449,

        VMAXCPSZrm = 7450,

        VMAXCPSZrmb = 7451,

        VMAXCPSZrmbk = 7452,

        VMAXCPSZrmbkz = 7453,

        VMAXCPSZrmk = 7454,

        VMAXCPSZrmkz = 7455,

        VMAXCPSZrr = 7456,

        VMAXCPSZrrk = 7457,

        VMAXCPSZrrkz = 7458,

        VMAXCPSrm = 7459,

        VMAXCPSrr = 7460,

        VMAXCSDZrm = 7461,

        VMAXCSDZrr = 7462,

        VMAXCSDrm = 7463,

        VMAXCSDrr = 7464,

        VMAXCSSZrm = 7465,

        VMAXCSSZrr = 7466,

        VMAXCSSrm = 7467,

        VMAXCSSrr = 7468,

        VMAXPDYrm = 7469,

        VMAXPDYrr = 7470,

        VMAXPDZ128rm = 7471,

        VMAXPDZ128rmb = 7472,

        VMAXPDZ128rmbk = 7473,

        VMAXPDZ128rmbkz = 7474,

        VMAXPDZ128rmk = 7475,

        VMAXPDZ128rmkz = 7476,

        VMAXPDZ128rr = 7477,

        VMAXPDZ128rrk = 7478,

        VMAXPDZ128rrkz = 7479,

        VMAXPDZ256rm = 7480,

        VMAXPDZ256rmb = 7481,

        VMAXPDZ256rmbk = 7482,

        VMAXPDZ256rmbkz = 7483,

        VMAXPDZ256rmk = 7484,

        VMAXPDZ256rmkz = 7485,

        VMAXPDZ256rr = 7486,

        VMAXPDZ256rrk = 7487,

        VMAXPDZ256rrkz = 7488,

        VMAXPDZrm = 7489,

        VMAXPDZrmb = 7490,

        VMAXPDZrmbk = 7491,

        VMAXPDZrmbkz = 7492,

        VMAXPDZrmk = 7493,

        VMAXPDZrmkz = 7494,

        VMAXPDZrr = 7495,

        VMAXPDZrrb = 7496,

        VMAXPDZrrbk = 7497,

        VMAXPDZrrbkz = 7498,

        VMAXPDZrrk = 7499,

        VMAXPDZrrkz = 7500,

        VMAXPDrm = 7501,

        VMAXPDrr = 7502,

        VMAXPSYrm = 7503,

        VMAXPSYrr = 7504,

        VMAXPSZ128rm = 7505,

        VMAXPSZ128rmb = 7506,

        VMAXPSZ128rmbk = 7507,

        VMAXPSZ128rmbkz = 7508,

        VMAXPSZ128rmk = 7509,

        VMAXPSZ128rmkz = 7510,

        VMAXPSZ128rr = 7511,

        VMAXPSZ128rrk = 7512,

        VMAXPSZ128rrkz = 7513,

        VMAXPSZ256rm = 7514,

        VMAXPSZ256rmb = 7515,

        VMAXPSZ256rmbk = 7516,

        VMAXPSZ256rmbkz = 7517,

        VMAXPSZ256rmk = 7518,

        VMAXPSZ256rmkz = 7519,

        VMAXPSZ256rr = 7520,

        VMAXPSZ256rrk = 7521,

        VMAXPSZ256rrkz = 7522,

        VMAXPSZrm = 7523,

        VMAXPSZrmb = 7524,

        VMAXPSZrmbk = 7525,

        VMAXPSZrmbkz = 7526,

        VMAXPSZrmk = 7527,

        VMAXPSZrmkz = 7528,

        VMAXPSZrr = 7529,

        VMAXPSZrrb = 7530,

        VMAXPSZrrbk = 7531,

        VMAXPSZrrbkz = 7532,

        VMAXPSZrrk = 7533,

        VMAXPSZrrkz = 7534,

        VMAXPSrm = 7535,

        VMAXPSrr = 7536,

        VMAXSDZrm = 7537,

        VMAXSDZrm_Int = 7538,

        VMAXSDZrm_Intk = 7539,

        VMAXSDZrm_Intkz = 7540,

        VMAXSDZrr = 7541,

        VMAXSDZrr_Int = 7542,

        VMAXSDZrr_Intk = 7543,

        VMAXSDZrr_Intkz = 7544,

        VMAXSDZrrb_Int = 7545,

        VMAXSDZrrb_Intk = 7546,

        VMAXSDZrrb_Intkz = 7547,

        VMAXSDrm = 7548,

        VMAXSDrm_Int = 7549,

        VMAXSDrr = 7550,

        VMAXSDrr_Int = 7551,

        VMAXSSZrm = 7552,

        VMAXSSZrm_Int = 7553,

        VMAXSSZrm_Intk = 7554,

        VMAXSSZrm_Intkz = 7555,

        VMAXSSZrr = 7556,

        VMAXSSZrr_Int = 7557,

        VMAXSSZrr_Intk = 7558,

        VMAXSSZrr_Intkz = 7559,

        VMAXSSZrrb_Int = 7560,

        VMAXSSZrrb_Intk = 7561,

        VMAXSSZrrb_Intkz = 7562,

        VMAXSSrm = 7563,

        VMAXSSrm_Int = 7564,

        VMAXSSrr = 7565,

        VMAXSSrr_Int = 7566,

        VMCALL = 7567,

        VMCLEARm = 7568,

        VMFUNC = 7569,

        VMINCPDYrm = 7570,

        VMINCPDYrr = 7571,

        VMINCPDZ128rm = 7572,

        VMINCPDZ128rmb = 7573,

        VMINCPDZ128rmbk = 7574,

        VMINCPDZ128rmbkz = 7575,

        VMINCPDZ128rmk = 7576,

        VMINCPDZ128rmkz = 7577,

        VMINCPDZ128rr = 7578,

        VMINCPDZ128rrk = 7579,

        VMINCPDZ128rrkz = 7580,

        VMINCPDZ256rm = 7581,

        VMINCPDZ256rmb = 7582,

        VMINCPDZ256rmbk = 7583,

        VMINCPDZ256rmbkz = 7584,

        VMINCPDZ256rmk = 7585,

        VMINCPDZ256rmkz = 7586,

        VMINCPDZ256rr = 7587,

        VMINCPDZ256rrk = 7588,

        VMINCPDZ256rrkz = 7589,

        VMINCPDZrm = 7590,

        VMINCPDZrmb = 7591,

        VMINCPDZrmbk = 7592,

        VMINCPDZrmbkz = 7593,

        VMINCPDZrmk = 7594,

        VMINCPDZrmkz = 7595,

        VMINCPDZrr = 7596,

        VMINCPDZrrk = 7597,

        VMINCPDZrrkz = 7598,

        VMINCPDrm = 7599,

        VMINCPDrr = 7600,

        VMINCPSYrm = 7601,

        VMINCPSYrr = 7602,

        VMINCPSZ128rm = 7603,

        VMINCPSZ128rmb = 7604,

        VMINCPSZ128rmbk = 7605,

        VMINCPSZ128rmbkz = 7606,

        VMINCPSZ128rmk = 7607,

        VMINCPSZ128rmkz = 7608,

        VMINCPSZ128rr = 7609,

        VMINCPSZ128rrk = 7610,

        VMINCPSZ128rrkz = 7611,

        VMINCPSZ256rm = 7612,

        VMINCPSZ256rmb = 7613,

        VMINCPSZ256rmbk = 7614,

        VMINCPSZ256rmbkz = 7615,

        VMINCPSZ256rmk = 7616,

        VMINCPSZ256rmkz = 7617,

        VMINCPSZ256rr = 7618,

        VMINCPSZ256rrk = 7619,

        VMINCPSZ256rrkz = 7620,

        VMINCPSZrm = 7621,

        VMINCPSZrmb = 7622,

        VMINCPSZrmbk = 7623,

        VMINCPSZrmbkz = 7624,

        VMINCPSZrmk = 7625,

        VMINCPSZrmkz = 7626,

        VMINCPSZrr = 7627,

        VMINCPSZrrk = 7628,

        VMINCPSZrrkz = 7629,

        VMINCPSrm = 7630,

        VMINCPSrr = 7631,

        VMINCSDZrm = 7632,

        VMINCSDZrr = 7633,

        VMINCSDrm = 7634,

        VMINCSDrr = 7635,

        VMINCSSZrm = 7636,

        VMINCSSZrr = 7637,

        VMINCSSrm = 7638,

        VMINCSSrr = 7639,

        VMINPDYrm = 7640,

        VMINPDYrr = 7641,

        VMINPDZ128rm = 7642,

        VMINPDZ128rmb = 7643,

        VMINPDZ128rmbk = 7644,

        VMINPDZ128rmbkz = 7645,

        VMINPDZ128rmk = 7646,

        VMINPDZ128rmkz = 7647,

        VMINPDZ128rr = 7648,

        VMINPDZ128rrk = 7649,

        VMINPDZ128rrkz = 7650,

        VMINPDZ256rm = 7651,

        VMINPDZ256rmb = 7652,

        VMINPDZ256rmbk = 7653,

        VMINPDZ256rmbkz = 7654,

        VMINPDZ256rmk = 7655,

        VMINPDZ256rmkz = 7656,

        VMINPDZ256rr = 7657,

        VMINPDZ256rrk = 7658,

        VMINPDZ256rrkz = 7659,

        VMINPDZrm = 7660,

        VMINPDZrmb = 7661,

        VMINPDZrmbk = 7662,

        VMINPDZrmbkz = 7663,

        VMINPDZrmk = 7664,

        VMINPDZrmkz = 7665,

        VMINPDZrr = 7666,

        VMINPDZrrb = 7667,

        VMINPDZrrbk = 7668,

        VMINPDZrrbkz = 7669,

        VMINPDZrrk = 7670,

        VMINPDZrrkz = 7671,

        VMINPDrm = 7672,

        VMINPDrr = 7673,

        VMINPSYrm = 7674,

        VMINPSYrr = 7675,

        VMINPSZ128rm = 7676,

        VMINPSZ128rmb = 7677,

        VMINPSZ128rmbk = 7678,

        VMINPSZ128rmbkz = 7679,

        VMINPSZ128rmk = 7680,

        VMINPSZ128rmkz = 7681,

        VMINPSZ128rr = 7682,

        VMINPSZ128rrk = 7683,

        VMINPSZ128rrkz = 7684,

        VMINPSZ256rm = 7685,

        VMINPSZ256rmb = 7686,

        VMINPSZ256rmbk = 7687,

        VMINPSZ256rmbkz = 7688,

        VMINPSZ256rmk = 7689,

        VMINPSZ256rmkz = 7690,

        VMINPSZ256rr = 7691,

        VMINPSZ256rrk = 7692,

        VMINPSZ256rrkz = 7693,

        VMINPSZrm = 7694,

        VMINPSZrmb = 7695,

        VMINPSZrmbk = 7696,

        VMINPSZrmbkz = 7697,

        VMINPSZrmk = 7698,

        VMINPSZrmkz = 7699,

        VMINPSZrr = 7700,

        VMINPSZrrb = 7701,

        VMINPSZrrbk = 7702,

        VMINPSZrrbkz = 7703,

        VMINPSZrrk = 7704,

        VMINPSZrrkz = 7705,

        VMINPSrm = 7706,

        VMINPSrr = 7707,

        VMINSDZrm = 7708,

        VMINSDZrm_Int = 7709,

        VMINSDZrm_Intk = 7710,

        VMINSDZrm_Intkz = 7711,

        VMINSDZrr = 7712,

        VMINSDZrr_Int = 7713,

        VMINSDZrr_Intk = 7714,

        VMINSDZrr_Intkz = 7715,

        VMINSDZrrb_Int = 7716,

        VMINSDZrrb_Intk = 7717,

        VMINSDZrrb_Intkz = 7718,

        VMINSDrm = 7719,

        VMINSDrm_Int = 7720,

        VMINSDrr = 7721,

        VMINSDrr_Int = 7722,

        VMINSSZrm = 7723,

        VMINSSZrm_Int = 7724,

        VMINSSZrm_Intk = 7725,

        VMINSSZrm_Intkz = 7726,

        VMINSSZrr = 7727,

        VMINSSZrr_Int = 7728,

        VMINSSZrr_Intk = 7729,

        VMINSSZrr_Intkz = 7730,

        VMINSSZrrb_Int = 7731,

        VMINSSZrrb_Intk = 7732,

        VMINSSZrrb_Intkz = 7733,

        VMINSSrm = 7734,

        VMINSSrm_Int = 7735,

        VMINSSrr = 7736,

        VMINSSrr_Int = 7737,

        VMLAUNCH = 7738,

        VMLOAD32 = 7739,

        VMLOAD64 = 7740,

        VMMCALL = 7741,

        VMOV64toPQIZrm = 7742,

        VMOV64toPQIZrr = 7743,

        VMOV64toPQIrm = 7744,

        VMOV64toPQIrr = 7745,

        VMOV64toSDZrr = 7746,

        VMOV64toSDrr = 7747,

        VMOVAPDYmr = 7748,

        VMOVAPDYrm = 7749,

        VMOVAPDYrr = 7750,

        VMOVAPDYrr_REV = 7751,

        VMOVAPDZ128mr = 7752,

        VMOVAPDZ128mrk = 7753,

        VMOVAPDZ128rm = 7754,

        VMOVAPDZ128rmk = 7755,

        VMOVAPDZ128rmkz = 7756,

        VMOVAPDZ128rr = 7757,

        VMOVAPDZ128rr_REV = 7758,

        VMOVAPDZ128rrk = 7759,

        VMOVAPDZ128rrk_REV = 7760,

        VMOVAPDZ128rrkz = 7761,

        VMOVAPDZ128rrkz_REV = 7762,

        VMOVAPDZ256mr = 7763,

        VMOVAPDZ256mrk = 7764,

        VMOVAPDZ256rm = 7765,

        VMOVAPDZ256rmk = 7766,

        VMOVAPDZ256rmkz = 7767,

        VMOVAPDZ256rr = 7768,

        VMOVAPDZ256rr_REV = 7769,

        VMOVAPDZ256rrk = 7770,

        VMOVAPDZ256rrk_REV = 7771,

        VMOVAPDZ256rrkz = 7772,

        VMOVAPDZ256rrkz_REV = 7773,

        VMOVAPDZmr = 7774,

        VMOVAPDZmrk = 7775,

        VMOVAPDZrm = 7776,

        VMOVAPDZrmk = 7777,

        VMOVAPDZrmkz = 7778,

        VMOVAPDZrr = 7779,

        VMOVAPDZrr_REV = 7780,

        VMOVAPDZrrk = 7781,

        VMOVAPDZrrk_REV = 7782,

        VMOVAPDZrrkz = 7783,

        VMOVAPDZrrkz_REV = 7784,

        VMOVAPDmr = 7785,

        VMOVAPDrm = 7786,

        VMOVAPDrr = 7787,

        VMOVAPDrr_REV = 7788,

        VMOVAPSYmr = 7789,

        VMOVAPSYrm = 7790,

        VMOVAPSYrr = 7791,

        VMOVAPSYrr_REV = 7792,

        VMOVAPSZ128mr = 7793,

        VMOVAPSZ128mrk = 7794,

        VMOVAPSZ128rm = 7795,

        VMOVAPSZ128rmk = 7796,

        VMOVAPSZ128rmkz = 7797,

        VMOVAPSZ128rr = 7798,

        VMOVAPSZ128rr_REV = 7799,

        VMOVAPSZ128rrk = 7800,

        VMOVAPSZ128rrk_REV = 7801,

        VMOVAPSZ128rrkz = 7802,

        VMOVAPSZ128rrkz_REV = 7803,

        VMOVAPSZ256mr = 7804,

        VMOVAPSZ256mrk = 7805,

        VMOVAPSZ256rm = 7806,

        VMOVAPSZ256rmk = 7807,

        VMOVAPSZ256rmkz = 7808,

        VMOVAPSZ256rr = 7809,

        VMOVAPSZ256rr_REV = 7810,

        VMOVAPSZ256rrk = 7811,

        VMOVAPSZ256rrk_REV = 7812,

        VMOVAPSZ256rrkz = 7813,

        VMOVAPSZ256rrkz_REV = 7814,

        VMOVAPSZmr = 7815,

        VMOVAPSZmrk = 7816,

        VMOVAPSZrm = 7817,

        VMOVAPSZrmk = 7818,

        VMOVAPSZrmkz = 7819,

        VMOVAPSZrr = 7820,

        VMOVAPSZrr_REV = 7821,

        VMOVAPSZrrk = 7822,

        VMOVAPSZrrk_REV = 7823,

        VMOVAPSZrrkz = 7824,

        VMOVAPSZrrkz_REV = 7825,

        VMOVAPSmr = 7826,

        VMOVAPSrm = 7827,

        VMOVAPSrr = 7828,

        VMOVAPSrr_REV = 7829,

        VMOVDDUPYrm = 7830,

        VMOVDDUPYrr = 7831,

        VMOVDDUPZ128rm = 7832,

        VMOVDDUPZ128rmk = 7833,

        VMOVDDUPZ128rmkz = 7834,

        VMOVDDUPZ128rr = 7835,

        VMOVDDUPZ128rrk = 7836,

        VMOVDDUPZ128rrkz = 7837,

        VMOVDDUPZ256rm = 7838,

        VMOVDDUPZ256rmk = 7839,

        VMOVDDUPZ256rmkz = 7840,

        VMOVDDUPZ256rr = 7841,

        VMOVDDUPZ256rrk = 7842,

        VMOVDDUPZ256rrkz = 7843,

        VMOVDDUPZrm = 7844,

        VMOVDDUPZrmk = 7845,

        VMOVDDUPZrmkz = 7846,

        VMOVDDUPZrr = 7847,

        VMOVDDUPZrrk = 7848,

        VMOVDDUPZrrkz = 7849,

        VMOVDDUPrm = 7850,

        VMOVDDUPrr = 7851,

        VMOVDI2PDIZrm = 7852,

        VMOVDI2PDIZrr = 7853,

        VMOVDI2PDIrm = 7854,

        VMOVDI2PDIrr = 7855,

        VMOVDI2SSZrr = 7856,

        VMOVDI2SSrr = 7857,

        VMOVDQA32Z128mr = 7858,

        VMOVDQA32Z128mrk = 7859,

        VMOVDQA32Z128rm = 7860,

        VMOVDQA32Z128rmk = 7861,

        VMOVDQA32Z128rmkz = 7862,

        VMOVDQA32Z128rr = 7863,

        VMOVDQA32Z128rr_REV = 7864,

        VMOVDQA32Z128rrk = 7865,

        VMOVDQA32Z128rrk_REV = 7866,

        VMOVDQA32Z128rrkz = 7867,

        VMOVDQA32Z128rrkz_REV = 7868,

        VMOVDQA32Z256mr = 7869,

        VMOVDQA32Z256mrk = 7870,

        VMOVDQA32Z256rm = 7871,

        VMOVDQA32Z256rmk = 7872,

        VMOVDQA32Z256rmkz = 7873,

        VMOVDQA32Z256rr = 7874,

        VMOVDQA32Z256rr_REV = 7875,

        VMOVDQA32Z256rrk = 7876,

        VMOVDQA32Z256rrk_REV = 7877,

        VMOVDQA32Z256rrkz = 7878,

        VMOVDQA32Z256rrkz_REV = 7879,

        VMOVDQA32Zmr = 7880,

        VMOVDQA32Zmrk = 7881,

        VMOVDQA32Zrm = 7882,

        VMOVDQA32Zrmk = 7883,

        VMOVDQA32Zrmkz = 7884,

        VMOVDQA32Zrr = 7885,

        VMOVDQA32Zrr_REV = 7886,

        VMOVDQA32Zrrk = 7887,

        VMOVDQA32Zrrk_REV = 7888,

        VMOVDQA32Zrrkz = 7889,

        VMOVDQA32Zrrkz_REV = 7890,

        VMOVDQA64Z128mr = 7891,

        VMOVDQA64Z128mrk = 7892,

        VMOVDQA64Z128rm = 7893,

        VMOVDQA64Z128rmk = 7894,

        VMOVDQA64Z128rmkz = 7895,

        VMOVDQA64Z128rr = 7896,

        VMOVDQA64Z128rr_REV = 7897,

        VMOVDQA64Z128rrk = 7898,

        VMOVDQA64Z128rrk_REV = 7899,

        VMOVDQA64Z128rrkz = 7900,

        VMOVDQA64Z128rrkz_REV = 7901,

        VMOVDQA64Z256mr = 7902,

        VMOVDQA64Z256mrk = 7903,

        VMOVDQA64Z256rm = 7904,

        VMOVDQA64Z256rmk = 7905,

        VMOVDQA64Z256rmkz = 7906,

        VMOVDQA64Z256rr = 7907,

        VMOVDQA64Z256rr_REV = 7908,

        VMOVDQA64Z256rrk = 7909,

        VMOVDQA64Z256rrk_REV = 7910,

        VMOVDQA64Z256rrkz = 7911,

        VMOVDQA64Z256rrkz_REV = 7912,

        VMOVDQA64Zmr = 7913,

        VMOVDQA64Zmrk = 7914,

        VMOVDQA64Zrm = 7915,

        VMOVDQA64Zrmk = 7916,

        VMOVDQA64Zrmkz = 7917,

        VMOVDQA64Zrr = 7918,

        VMOVDQA64Zrr_REV = 7919,

        VMOVDQA64Zrrk = 7920,

        VMOVDQA64Zrrk_REV = 7921,

        VMOVDQA64Zrrkz = 7922,

        VMOVDQA64Zrrkz_REV = 7923,

        VMOVDQAYmr = 7924,

        VMOVDQAYrm = 7925,

        VMOVDQAYrr = 7926,

        VMOVDQAYrr_REV = 7927,

        VMOVDQAmr = 7928,

        VMOVDQArm = 7929,

        VMOVDQArr = 7930,

        VMOVDQArr_REV = 7931,

        VMOVDQU16Z128mr = 7932,

        VMOVDQU16Z128mrk = 7933,

        VMOVDQU16Z128rm = 7934,

        VMOVDQU16Z128rmk = 7935,

        VMOVDQU16Z128rmkz = 7936,

        VMOVDQU16Z128rr = 7937,

        VMOVDQU16Z128rr_REV = 7938,

        VMOVDQU16Z128rrk = 7939,

        VMOVDQU16Z128rrk_REV = 7940,

        VMOVDQU16Z128rrkz = 7941,

        VMOVDQU16Z128rrkz_REV = 7942,

        VMOVDQU16Z256mr = 7943,

        VMOVDQU16Z256mrk = 7944,

        VMOVDQU16Z256rm = 7945,

        VMOVDQU16Z256rmk = 7946,

        VMOVDQU16Z256rmkz = 7947,

        VMOVDQU16Z256rr = 7948,

        VMOVDQU16Z256rr_REV = 7949,

        VMOVDQU16Z256rrk = 7950,

        VMOVDQU16Z256rrk_REV = 7951,

        VMOVDQU16Z256rrkz = 7952,

        VMOVDQU16Z256rrkz_REV = 7953,

        VMOVDQU16Zmr = 7954,

        VMOVDQU16Zmrk = 7955,

        VMOVDQU16Zrm = 7956,

        VMOVDQU16Zrmk = 7957,

        VMOVDQU16Zrmkz = 7958,

        VMOVDQU16Zrr = 7959,

        VMOVDQU16Zrr_REV = 7960,

        VMOVDQU16Zrrk = 7961,

        VMOVDQU16Zrrk_REV = 7962,

        VMOVDQU16Zrrkz = 7963,

        VMOVDQU16Zrrkz_REV = 7964,

        VMOVDQU32Z128mr = 7965,

        VMOVDQU32Z128mrk = 7966,

        VMOVDQU32Z128rm = 7967,

        VMOVDQU32Z128rmk = 7968,

        VMOVDQU32Z128rmkz = 7969,

        VMOVDQU32Z128rr = 7970,

        VMOVDQU32Z128rr_REV = 7971,

        VMOVDQU32Z128rrk = 7972,

        VMOVDQU32Z128rrk_REV = 7973,

        VMOVDQU32Z128rrkz = 7974,

        VMOVDQU32Z128rrkz_REV = 7975,

        VMOVDQU32Z256mr = 7976,

        VMOVDQU32Z256mrk = 7977,

        VMOVDQU32Z256rm = 7978,

        VMOVDQU32Z256rmk = 7979,

        VMOVDQU32Z256rmkz = 7980,

        VMOVDQU32Z256rr = 7981,

        VMOVDQU32Z256rr_REV = 7982,

        VMOVDQU32Z256rrk = 7983,

        VMOVDQU32Z256rrk_REV = 7984,

        VMOVDQU32Z256rrkz = 7985,

        VMOVDQU32Z256rrkz_REV = 7986,

        VMOVDQU32Zmr = 7987,

        VMOVDQU32Zmrk = 7988,

        VMOVDQU32Zrm = 7989,

        VMOVDQU32Zrmk = 7990,

        VMOVDQU32Zrmkz = 7991,

        VMOVDQU32Zrr = 7992,

        VMOVDQU32Zrr_REV = 7993,

        VMOVDQU32Zrrk = 7994,

        VMOVDQU32Zrrk_REV = 7995,

        VMOVDQU32Zrrkz = 7996,

        VMOVDQU32Zrrkz_REV = 7997,

        VMOVDQU64Z128mr = 7998,

        VMOVDQU64Z128mrk = 7999,

        VMOVDQU64Z128rm = 8000,

        VMOVDQU64Z128rmk = 8001,

        VMOVDQU64Z128rmkz = 8002,

        VMOVDQU64Z128rr = 8003,

        VMOVDQU64Z128rr_REV = 8004,

        VMOVDQU64Z128rrk = 8005,

        VMOVDQU64Z128rrk_REV = 8006,

        VMOVDQU64Z128rrkz = 8007,

        VMOVDQU64Z128rrkz_REV = 8008,

        VMOVDQU64Z256mr = 8009,

        VMOVDQU64Z256mrk = 8010,

        VMOVDQU64Z256rm = 8011,

        VMOVDQU64Z256rmk = 8012,

        VMOVDQU64Z256rmkz = 8013,

        VMOVDQU64Z256rr = 8014,

        VMOVDQU64Z256rr_REV = 8015,

        VMOVDQU64Z256rrk = 8016,

        VMOVDQU64Z256rrk_REV = 8017,

        VMOVDQU64Z256rrkz = 8018,

        VMOVDQU64Z256rrkz_REV = 8019,

        VMOVDQU64Zmr = 8020,

        VMOVDQU64Zmrk = 8021,

        VMOVDQU64Zrm = 8022,

        VMOVDQU64Zrmk = 8023,

        VMOVDQU64Zrmkz = 8024,

        VMOVDQU64Zrr = 8025,

        VMOVDQU64Zrr_REV = 8026,

        VMOVDQU64Zrrk = 8027,

        VMOVDQU64Zrrk_REV = 8028,

        VMOVDQU64Zrrkz = 8029,

        VMOVDQU64Zrrkz_REV = 8030,

        VMOVDQU8Z128mr = 8031,

        VMOVDQU8Z128mrk = 8032,

        VMOVDQU8Z128rm = 8033,

        VMOVDQU8Z128rmk = 8034,

        VMOVDQU8Z128rmkz = 8035,

        VMOVDQU8Z128rr = 8036,

        VMOVDQU8Z128rr_REV = 8037,

        VMOVDQU8Z128rrk = 8038,

        VMOVDQU8Z128rrk_REV = 8039,

        VMOVDQU8Z128rrkz = 8040,

        VMOVDQU8Z128rrkz_REV = 8041,

        VMOVDQU8Z256mr = 8042,

        VMOVDQU8Z256mrk = 8043,

        VMOVDQU8Z256rm = 8044,

        VMOVDQU8Z256rmk = 8045,

        VMOVDQU8Z256rmkz = 8046,

        VMOVDQU8Z256rr = 8047,

        VMOVDQU8Z256rr_REV = 8048,

        VMOVDQU8Z256rrk = 8049,

        VMOVDQU8Z256rrk_REV = 8050,

        VMOVDQU8Z256rrkz = 8051,

        VMOVDQU8Z256rrkz_REV = 8052,

        VMOVDQU8Zmr = 8053,

        VMOVDQU8Zmrk = 8054,

        VMOVDQU8Zrm = 8055,

        VMOVDQU8Zrmk = 8056,

        VMOVDQU8Zrmkz = 8057,

        VMOVDQU8Zrr = 8058,

        VMOVDQU8Zrr_REV = 8059,

        VMOVDQU8Zrrk = 8060,

        VMOVDQU8Zrrk_REV = 8061,

        VMOVDQU8Zrrkz = 8062,

        VMOVDQU8Zrrkz_REV = 8063,

        VMOVDQUYmr = 8064,

        VMOVDQUYrm = 8065,

        VMOVDQUYrr = 8066,

        VMOVDQUYrr_REV = 8067,

        VMOVDQUmr = 8068,

        VMOVDQUrm = 8069,

        VMOVDQUrr = 8070,

        VMOVDQUrr_REV = 8071,

        VMOVHLPSZrr = 8072,

        VMOVHLPSrr = 8073,

        VMOVHPDZ128mr = 8074,

        VMOVHPDZ128rm = 8075,

        VMOVHPDmr = 8076,

        VMOVHPDrm = 8077,

        VMOVHPSZ128mr = 8078,

        VMOVHPSZ128rm = 8079,

        VMOVHPSmr = 8080,

        VMOVHPSrm = 8081,

        VMOVLHPSZrr = 8082,

        VMOVLHPSrr = 8083,

        VMOVLPDZ128mr = 8084,

        VMOVLPDZ128rm = 8085,

        VMOVLPDmr = 8086,

        VMOVLPDrm = 8087,

        VMOVLPSZ128mr = 8088,

        VMOVLPSZ128rm = 8089,

        VMOVLPSmr = 8090,

        VMOVLPSrm = 8091,

        VMOVMSKPDYrr = 8092,

        VMOVMSKPDrr = 8093,

        VMOVMSKPSYrr = 8094,

        VMOVMSKPSrr = 8095,

        VMOVNTDQAYrm = 8096,

        VMOVNTDQAZ128rm = 8097,

        VMOVNTDQAZ256rm = 8098,

        VMOVNTDQAZrm = 8099,

        VMOVNTDQArm = 8100,

        VMOVNTDQYmr = 8101,

        VMOVNTDQZ128mr = 8102,

        VMOVNTDQZ256mr = 8103,

        VMOVNTDQZmr = 8104,

        VMOVNTDQmr = 8105,

        VMOVNTPDYmr = 8106,

        VMOVNTPDZ128mr = 8107,

        VMOVNTPDZ256mr = 8108,

        VMOVNTPDZmr = 8109,

        VMOVNTPDmr = 8110,

        VMOVNTPSYmr = 8111,

        VMOVNTPSZ128mr = 8112,

        VMOVNTPSZ256mr = 8113,

        VMOVNTPSZmr = 8114,

        VMOVNTPSmr = 8115,

        VMOVPDI2DIZmr = 8116,

        VMOVPDI2DIZrr = 8117,

        VMOVPDI2DImr = 8118,

        VMOVPDI2DIrr = 8119,

        VMOVPQI2QIZmr = 8120,

        VMOVPQI2QIZrr = 8121,

        VMOVPQI2QImr = 8122,

        VMOVPQI2QIrr = 8123,

        VMOVPQIto64Zmr = 8124,

        VMOVPQIto64Zrr = 8125,

        VMOVPQIto64mr = 8126,

        VMOVPQIto64rr = 8127,

        VMOVQI2PQIZrm = 8128,

        VMOVQI2PQIrm = 8129,

        VMOVSDZmr = 8130,

        VMOVSDZmrk = 8131,

        VMOVSDZrm = 8132,

        VMOVSDZrm_alt = 8133,

        VMOVSDZrmk = 8134,

        VMOVSDZrmkz = 8135,

        VMOVSDZrr = 8136,

        VMOVSDZrr_REV = 8137,

        VMOVSDZrrk = 8138,

        VMOVSDZrrk_REV = 8139,

        VMOVSDZrrkz = 8140,

        VMOVSDZrrkz_REV = 8141,

        VMOVSDmr = 8142,

        VMOVSDrm = 8143,

        VMOVSDrm_alt = 8144,

        VMOVSDrr = 8145,

        VMOVSDrr_REV = 8146,

        VMOVSDto64Zrr = 8147,

        VMOVSDto64rr = 8148,

        VMOVSHDUPYrm = 8149,

        VMOVSHDUPYrr = 8150,

        VMOVSHDUPZ128rm = 8151,

        VMOVSHDUPZ128rmk = 8152,

        VMOVSHDUPZ128rmkz = 8153,

        VMOVSHDUPZ128rr = 8154,

        VMOVSHDUPZ128rrk = 8155,

        VMOVSHDUPZ128rrkz = 8156,

        VMOVSHDUPZ256rm = 8157,

        VMOVSHDUPZ256rmk = 8158,

        VMOVSHDUPZ256rmkz = 8159,

        VMOVSHDUPZ256rr = 8160,

        VMOVSHDUPZ256rrk = 8161,

        VMOVSHDUPZ256rrkz = 8162,

        VMOVSHDUPZrm = 8163,

        VMOVSHDUPZrmk = 8164,

        VMOVSHDUPZrmkz = 8165,

        VMOVSHDUPZrr = 8166,

        VMOVSHDUPZrrk = 8167,

        VMOVSHDUPZrrkz = 8168,

        VMOVSHDUPrm = 8169,

        VMOVSHDUPrr = 8170,

        VMOVSLDUPYrm = 8171,

        VMOVSLDUPYrr = 8172,

        VMOVSLDUPZ128rm = 8173,

        VMOVSLDUPZ128rmk = 8174,

        VMOVSLDUPZ128rmkz = 8175,

        VMOVSLDUPZ128rr = 8176,

        VMOVSLDUPZ128rrk = 8177,

        VMOVSLDUPZ128rrkz = 8178,

        VMOVSLDUPZ256rm = 8179,

        VMOVSLDUPZ256rmk = 8180,

        VMOVSLDUPZ256rmkz = 8181,

        VMOVSLDUPZ256rr = 8182,

        VMOVSLDUPZ256rrk = 8183,

        VMOVSLDUPZ256rrkz = 8184,

        VMOVSLDUPZrm = 8185,

        VMOVSLDUPZrmk = 8186,

        VMOVSLDUPZrmkz = 8187,

        VMOVSLDUPZrr = 8188,

        VMOVSLDUPZrrk = 8189,

        VMOVSLDUPZrrkz = 8190,

        VMOVSLDUPrm = 8191,

        VMOVSLDUPrr = 8192,

        VMOVSS2DIZrr = 8193,

        VMOVSS2DIrr = 8194,

        VMOVSSZmr = 8195,

        VMOVSSZmrk = 8196,

        VMOVSSZrm = 8197,

        VMOVSSZrm_alt = 8198,

        VMOVSSZrmk = 8199,

        VMOVSSZrmkz = 8200,

        VMOVSSZrr = 8201,

        VMOVSSZrr_REV = 8202,

        VMOVSSZrrk = 8203,

        VMOVSSZrrk_REV = 8204,

        VMOVSSZrrkz = 8205,

        VMOVSSZrrkz_REV = 8206,

        VMOVSSmr = 8207,

        VMOVSSrm = 8208,

        VMOVSSrm_alt = 8209,

        VMOVSSrr = 8210,

        VMOVSSrr_REV = 8211,

        VMOVUPDYmr = 8212,

        VMOVUPDYrm = 8213,

        VMOVUPDYrr = 8214,

        VMOVUPDYrr_REV = 8215,

        VMOVUPDZ128mr = 8216,

        VMOVUPDZ128mrk = 8217,

        VMOVUPDZ128rm = 8218,

        VMOVUPDZ128rmk = 8219,

        VMOVUPDZ128rmkz = 8220,

        VMOVUPDZ128rr = 8221,

        VMOVUPDZ128rr_REV = 8222,

        VMOVUPDZ128rrk = 8223,

        VMOVUPDZ128rrk_REV = 8224,

        VMOVUPDZ128rrkz = 8225,

        VMOVUPDZ128rrkz_REV = 8226,

        VMOVUPDZ256mr = 8227,

        VMOVUPDZ256mrk = 8228,

        VMOVUPDZ256rm = 8229,

        VMOVUPDZ256rmk = 8230,

        VMOVUPDZ256rmkz = 8231,

        VMOVUPDZ256rr = 8232,

        VMOVUPDZ256rr_REV = 8233,

        VMOVUPDZ256rrk = 8234,

        VMOVUPDZ256rrk_REV = 8235,

        VMOVUPDZ256rrkz = 8236,

        VMOVUPDZ256rrkz_REV = 8237,

        VMOVUPDZmr = 8238,

        VMOVUPDZmrk = 8239,

        VMOVUPDZrm = 8240,

        VMOVUPDZrmk = 8241,

        VMOVUPDZrmkz = 8242,

        VMOVUPDZrr = 8243,

        VMOVUPDZrr_REV = 8244,

        VMOVUPDZrrk = 8245,

        VMOVUPDZrrk_REV = 8246,

        VMOVUPDZrrkz = 8247,

        VMOVUPDZrrkz_REV = 8248,

        VMOVUPDmr = 8249,

        VMOVUPDrm = 8250,

        VMOVUPDrr = 8251,

        VMOVUPDrr_REV = 8252,

        VMOVUPSYmr = 8253,

        VMOVUPSYrm = 8254,

        VMOVUPSYrr = 8255,

        VMOVUPSYrr_REV = 8256,

        VMOVUPSZ128mr = 8257,

        VMOVUPSZ128mrk = 8258,

        VMOVUPSZ128rm = 8259,

        VMOVUPSZ128rmk = 8260,

        VMOVUPSZ128rmkz = 8261,

        VMOVUPSZ128rr = 8262,

        VMOVUPSZ128rr_REV = 8263,

        VMOVUPSZ128rrk = 8264,

        VMOVUPSZ128rrk_REV = 8265,

        VMOVUPSZ128rrkz = 8266,

        VMOVUPSZ128rrkz_REV = 8267,

        VMOVUPSZ256mr = 8268,

        VMOVUPSZ256mrk = 8269,

        VMOVUPSZ256rm = 8270,

        VMOVUPSZ256rmk = 8271,

        VMOVUPSZ256rmkz = 8272,

        VMOVUPSZ256rr = 8273,

        VMOVUPSZ256rr_REV = 8274,

        VMOVUPSZ256rrk = 8275,

        VMOVUPSZ256rrk_REV = 8276,

        VMOVUPSZ256rrkz = 8277,

        VMOVUPSZ256rrkz_REV = 8278,

        VMOVUPSZmr = 8279,

        VMOVUPSZmrk = 8280,

        VMOVUPSZrm = 8281,

        VMOVUPSZrmk = 8282,

        VMOVUPSZrmkz = 8283,

        VMOVUPSZrr = 8284,

        VMOVUPSZrr_REV = 8285,

        VMOVUPSZrrk = 8286,

        VMOVUPSZrrk_REV = 8287,

        VMOVUPSZrrkz = 8288,

        VMOVUPSZrrkz_REV = 8289,

        VMOVUPSmr = 8290,

        VMOVUPSrm = 8291,

        VMOVUPSrr = 8292,

        VMOVUPSrr_REV = 8293,

        VMOVZPQILo2PQIZrr = 8294,

        VMOVZPQILo2PQIrr = 8295,

        VMPSADBWYrmi = 8296,

        VMPSADBWYrri = 8297,

        VMPSADBWrmi = 8298,

        VMPSADBWrri = 8299,

        VMPTRLDm = 8300,

        VMPTRSTm = 8301,

        VMREAD32mr = 8302,

        VMREAD32rr = 8303,

        VMREAD64mr = 8304,

        VMREAD64rr = 8305,

        VMRESUME = 8306,

        VMRUN32 = 8307,

        VMRUN64 = 8308,

        VMSAVE32 = 8309,

        VMSAVE64 = 8310,

        VMULPDYrm = 8311,

        VMULPDYrr = 8312,

        VMULPDZ128rm = 8313,

        VMULPDZ128rmb = 8314,

        VMULPDZ128rmbk = 8315,

        VMULPDZ128rmbkz = 8316,

        VMULPDZ128rmk = 8317,

        VMULPDZ128rmkz = 8318,

        VMULPDZ128rr = 8319,

        VMULPDZ128rrk = 8320,

        VMULPDZ128rrkz = 8321,

        VMULPDZ256rm = 8322,

        VMULPDZ256rmb = 8323,

        VMULPDZ256rmbk = 8324,

        VMULPDZ256rmbkz = 8325,

        VMULPDZ256rmk = 8326,

        VMULPDZ256rmkz = 8327,

        VMULPDZ256rr = 8328,

        VMULPDZ256rrk = 8329,

        VMULPDZ256rrkz = 8330,

        VMULPDZrm = 8331,

        VMULPDZrmb = 8332,

        VMULPDZrmbk = 8333,

        VMULPDZrmbkz = 8334,

        VMULPDZrmk = 8335,

        VMULPDZrmkz = 8336,

        VMULPDZrr = 8337,

        VMULPDZrrb = 8338,

        VMULPDZrrbk = 8339,

        VMULPDZrrbkz = 8340,

        VMULPDZrrk = 8341,

        VMULPDZrrkz = 8342,

        VMULPDrm = 8343,

        VMULPDrr = 8344,

        VMULPSYrm = 8345,

        VMULPSYrr = 8346,

        VMULPSZ128rm = 8347,

        VMULPSZ128rmb = 8348,

        VMULPSZ128rmbk = 8349,

        VMULPSZ128rmbkz = 8350,

        VMULPSZ128rmk = 8351,

        VMULPSZ128rmkz = 8352,

        VMULPSZ128rr = 8353,

        VMULPSZ128rrk = 8354,

        VMULPSZ128rrkz = 8355,

        VMULPSZ256rm = 8356,

        VMULPSZ256rmb = 8357,

        VMULPSZ256rmbk = 8358,

        VMULPSZ256rmbkz = 8359,

        VMULPSZ256rmk = 8360,

        VMULPSZ256rmkz = 8361,

        VMULPSZ256rr = 8362,

        VMULPSZ256rrk = 8363,

        VMULPSZ256rrkz = 8364,

        VMULPSZrm = 8365,

        VMULPSZrmb = 8366,

        VMULPSZrmbk = 8367,

        VMULPSZrmbkz = 8368,

        VMULPSZrmk = 8369,

        VMULPSZrmkz = 8370,

        VMULPSZrr = 8371,

        VMULPSZrrb = 8372,

        VMULPSZrrbk = 8373,

        VMULPSZrrbkz = 8374,

        VMULPSZrrk = 8375,

        VMULPSZrrkz = 8376,

        VMULPSrm = 8377,

        VMULPSrr = 8378,

        VMULSDZrm = 8379,

        VMULSDZrm_Int = 8380,

        VMULSDZrm_Intk = 8381,

        VMULSDZrm_Intkz = 8382,

        VMULSDZrr = 8383,

        VMULSDZrr_Int = 8384,

        VMULSDZrr_Intk = 8385,

        VMULSDZrr_Intkz = 8386,

        VMULSDZrrb_Int = 8387,

        VMULSDZrrb_Intk = 8388,

        VMULSDZrrb_Intkz = 8389,

        VMULSDrm = 8390,

        VMULSDrm_Int = 8391,

        VMULSDrr = 8392,

        VMULSDrr_Int = 8393,

        VMULSSZrm = 8394,

        VMULSSZrm_Int = 8395,

        VMULSSZrm_Intk = 8396,

        VMULSSZrm_Intkz = 8397,

        VMULSSZrr = 8398,

        VMULSSZrr_Int = 8399,

        VMULSSZrr_Intk = 8400,

        VMULSSZrr_Intkz = 8401,

        VMULSSZrrb_Int = 8402,

        VMULSSZrrb_Intk = 8403,

        VMULSSZrrb_Intkz = 8404,

        VMULSSrm = 8405,

        VMULSSrm_Int = 8406,

        VMULSSrr = 8407,

        VMULSSrr_Int = 8408,

        VMWRITE32rm = 8409,

        VMWRITE32rr = 8410,

        VMWRITE64rm = 8411,

        VMWRITE64rr = 8412,

        VMXOFF = 8413,

        VMXON = 8414,

        VORPDYrm = 8415,

        VORPDYrr = 8416,

        VORPDZ128rm = 8417,

        VORPDZ128rmb = 8418,

        VORPDZ128rmbk = 8419,

        VORPDZ128rmbkz = 8420,

        VORPDZ128rmk = 8421,

        VORPDZ128rmkz = 8422,

        VORPDZ128rr = 8423,

        VORPDZ128rrk = 8424,

        VORPDZ128rrkz = 8425,

        VORPDZ256rm = 8426,

        VORPDZ256rmb = 8427,

        VORPDZ256rmbk = 8428,

        VORPDZ256rmbkz = 8429,

        VORPDZ256rmk = 8430,

        VORPDZ256rmkz = 8431,

        VORPDZ256rr = 8432,

        VORPDZ256rrk = 8433,

        VORPDZ256rrkz = 8434,

        VORPDZrm = 8435,

        VORPDZrmb = 8436,

        VORPDZrmbk = 8437,

        VORPDZrmbkz = 8438,

        VORPDZrmk = 8439,

        VORPDZrmkz = 8440,

        VORPDZrr = 8441,

        VORPDZrrk = 8442,

        VORPDZrrkz = 8443,

        VORPDrm = 8444,

        VORPDrr = 8445,

        VORPSYrm = 8446,

        VORPSYrr = 8447,

        VORPSZ128rm = 8448,

        VORPSZ128rmb = 8449,

        VORPSZ128rmbk = 8450,

        VORPSZ128rmbkz = 8451,

        VORPSZ128rmk = 8452,

        VORPSZ128rmkz = 8453,

        VORPSZ128rr = 8454,

        VORPSZ128rrk = 8455,

        VORPSZ128rrkz = 8456,

        VORPSZ256rm = 8457,

        VORPSZ256rmb = 8458,

        VORPSZ256rmbk = 8459,

        VORPSZ256rmbkz = 8460,

        VORPSZ256rmk = 8461,

        VORPSZ256rmkz = 8462,

        VORPSZ256rr = 8463,

        VORPSZ256rrk = 8464,

        VORPSZ256rrkz = 8465,

        VORPSZrm = 8466,

        VORPSZrmb = 8467,

        VORPSZrmbk = 8468,

        VORPSZrmbkz = 8469,

        VORPSZrmk = 8470,

        VORPSZrmkz = 8471,

        VORPSZrr = 8472,

        VORPSZrrk = 8473,

        VORPSZrrkz = 8474,

        VORPSrm = 8475,

        VORPSrr = 8476,

        VP2INTERSECTDZ128rm = 8477,

        VP2INTERSECTDZ128rmb = 8478,

        VP2INTERSECTDZ128rr = 8479,

        VP2INTERSECTDZ256rm = 8480,

        VP2INTERSECTDZ256rmb = 8481,

        VP2INTERSECTDZ256rr = 8482,

        VP2INTERSECTDZrm = 8483,

        VP2INTERSECTDZrmb = 8484,

        VP2INTERSECTDZrr = 8485,

        VP2INTERSECTQZ128rm = 8486,

        VP2INTERSECTQZ128rmb = 8487,

        VP2INTERSECTQZ128rr = 8488,

        VP2INTERSECTQZ256rm = 8489,

        VP2INTERSECTQZ256rmb = 8490,

        VP2INTERSECTQZ256rr = 8491,

        VP2INTERSECTQZrm = 8492,

        VP2INTERSECTQZrmb = 8493,

        VP2INTERSECTQZrr = 8494,

        VP4DPWSSDSrm = 8495,

        VP4DPWSSDSrmk = 8496,

        VP4DPWSSDSrmkz = 8497,

        VP4DPWSSDrm = 8498,

        VP4DPWSSDrmk = 8499,

        VP4DPWSSDrmkz = 8500,

        VPABSBYrm = 8501,

        VPABSBYrr = 8502,

        VPABSBZ128rm = 8503,

        VPABSBZ128rmk = 8504,

        VPABSBZ128rmkz = 8505,

        VPABSBZ128rr = 8506,

        VPABSBZ128rrk = 8507,

        VPABSBZ128rrkz = 8508,

        VPABSBZ256rm = 8509,

        VPABSBZ256rmk = 8510,

        VPABSBZ256rmkz = 8511,

        VPABSBZ256rr = 8512,

        VPABSBZ256rrk = 8513,

        VPABSBZ256rrkz = 8514,

        VPABSBZrm = 8515,

        VPABSBZrmk = 8516,

        VPABSBZrmkz = 8517,

        VPABSBZrr = 8518,

        VPABSBZrrk = 8519,

        VPABSBZrrkz = 8520,

        VPABSBrm = 8521,

        VPABSBrr = 8522,

        VPABSDYrm = 8523,

        VPABSDYrr = 8524,

        VPABSDZ128rm = 8525,

        VPABSDZ128rmb = 8526,

        VPABSDZ128rmbk = 8527,

        VPABSDZ128rmbkz = 8528,

        VPABSDZ128rmk = 8529,

        VPABSDZ128rmkz = 8530,

        VPABSDZ128rr = 8531,

        VPABSDZ128rrk = 8532,

        VPABSDZ128rrkz = 8533,

        VPABSDZ256rm = 8534,

        VPABSDZ256rmb = 8535,

        VPABSDZ256rmbk = 8536,

        VPABSDZ256rmbkz = 8537,

        VPABSDZ256rmk = 8538,

        VPABSDZ256rmkz = 8539,

        VPABSDZ256rr = 8540,

        VPABSDZ256rrk = 8541,

        VPABSDZ256rrkz = 8542,

        VPABSDZrm = 8543,

        VPABSDZrmb = 8544,

        VPABSDZrmbk = 8545,

        VPABSDZrmbkz = 8546,

        VPABSDZrmk = 8547,

        VPABSDZrmkz = 8548,

        VPABSDZrr = 8549,

        VPABSDZrrk = 8550,

        VPABSDZrrkz = 8551,

        VPABSDrm = 8552,

        VPABSDrr = 8553,

        VPABSQZ128rm = 8554,

        VPABSQZ128rmb = 8555,

        VPABSQZ128rmbk = 8556,

        VPABSQZ128rmbkz = 8557,

        VPABSQZ128rmk = 8558,

        VPABSQZ128rmkz = 8559,

        VPABSQZ128rr = 8560,

        VPABSQZ128rrk = 8561,

        VPABSQZ128rrkz = 8562,

        VPABSQZ256rm = 8563,

        VPABSQZ256rmb = 8564,

        VPABSQZ256rmbk = 8565,

        VPABSQZ256rmbkz = 8566,

        VPABSQZ256rmk = 8567,

        VPABSQZ256rmkz = 8568,

        VPABSQZ256rr = 8569,

        VPABSQZ256rrk = 8570,

        VPABSQZ256rrkz = 8571,

        VPABSQZrm = 8572,

        VPABSQZrmb = 8573,

        VPABSQZrmbk = 8574,

        VPABSQZrmbkz = 8575,

        VPABSQZrmk = 8576,

        VPABSQZrmkz = 8577,

        VPABSQZrr = 8578,

        VPABSQZrrk = 8579,

        VPABSQZrrkz = 8580,

        VPABSWYrm = 8581,

        VPABSWYrr = 8582,

        VPABSWZ128rm = 8583,

        VPABSWZ128rmk = 8584,

        VPABSWZ128rmkz = 8585,

        VPABSWZ128rr = 8586,

        VPABSWZ128rrk = 8587,

        VPABSWZ128rrkz = 8588,

        VPABSWZ256rm = 8589,

        VPABSWZ256rmk = 8590,

        VPABSWZ256rmkz = 8591,

        VPABSWZ256rr = 8592,

        VPABSWZ256rrk = 8593,

        VPABSWZ256rrkz = 8594,

        VPABSWZrm = 8595,

        VPABSWZrmk = 8596,

        VPABSWZrmkz = 8597,

        VPABSWZrr = 8598,

        VPABSWZrrk = 8599,

        VPABSWZrrkz = 8600,

        VPABSWrm = 8601,

        VPABSWrr = 8602,

        VPACKSSDWYrm = 8603,

        VPACKSSDWYrr = 8604,

        VPACKSSDWZ128rm = 8605,

        VPACKSSDWZ128rmb = 8606,

        VPACKSSDWZ128rmbk = 8607,

        VPACKSSDWZ128rmbkz = 8608,

        VPACKSSDWZ128rmk = 8609,

        VPACKSSDWZ128rmkz = 8610,

        VPACKSSDWZ128rr = 8611,

        VPACKSSDWZ128rrk = 8612,

        VPACKSSDWZ128rrkz = 8613,

        VPACKSSDWZ256rm = 8614,

        VPACKSSDWZ256rmb = 8615,

        VPACKSSDWZ256rmbk = 8616,

        VPACKSSDWZ256rmbkz = 8617,

        VPACKSSDWZ256rmk = 8618,

        VPACKSSDWZ256rmkz = 8619,

        VPACKSSDWZ256rr = 8620,

        VPACKSSDWZ256rrk = 8621,

        VPACKSSDWZ256rrkz = 8622,

        VPACKSSDWZrm = 8623,

        VPACKSSDWZrmb = 8624,

        VPACKSSDWZrmbk = 8625,

        VPACKSSDWZrmbkz = 8626,

        VPACKSSDWZrmk = 8627,

        VPACKSSDWZrmkz = 8628,

        VPACKSSDWZrr = 8629,

        VPACKSSDWZrrk = 8630,

        VPACKSSDWZrrkz = 8631,

        VPACKSSDWrm = 8632,

        VPACKSSDWrr = 8633,

        VPACKSSWBYrm = 8634,

        VPACKSSWBYrr = 8635,

        VPACKSSWBZ128rm = 8636,

        VPACKSSWBZ128rmk = 8637,

        VPACKSSWBZ128rmkz = 8638,

        VPACKSSWBZ128rr = 8639,

        VPACKSSWBZ128rrk = 8640,

        VPACKSSWBZ128rrkz = 8641,

        VPACKSSWBZ256rm = 8642,

        VPACKSSWBZ256rmk = 8643,

        VPACKSSWBZ256rmkz = 8644,

        VPACKSSWBZ256rr = 8645,

        VPACKSSWBZ256rrk = 8646,

        VPACKSSWBZ256rrkz = 8647,

        VPACKSSWBZrm = 8648,

        VPACKSSWBZrmk = 8649,

        VPACKSSWBZrmkz = 8650,

        VPACKSSWBZrr = 8651,

        VPACKSSWBZrrk = 8652,

        VPACKSSWBZrrkz = 8653,

        VPACKSSWBrm = 8654,

        VPACKSSWBrr = 8655,

        VPACKUSDWYrm = 8656,

        VPACKUSDWYrr = 8657,

        VPACKUSDWZ128rm = 8658,

        VPACKUSDWZ128rmb = 8659,

        VPACKUSDWZ128rmbk = 8660,

        VPACKUSDWZ128rmbkz = 8661,

        VPACKUSDWZ128rmk = 8662,

        VPACKUSDWZ128rmkz = 8663,

        VPACKUSDWZ128rr = 8664,

        VPACKUSDWZ128rrk = 8665,

        VPACKUSDWZ128rrkz = 8666,

        VPACKUSDWZ256rm = 8667,

        VPACKUSDWZ256rmb = 8668,

        VPACKUSDWZ256rmbk = 8669,

        VPACKUSDWZ256rmbkz = 8670,

        VPACKUSDWZ256rmk = 8671,

        VPACKUSDWZ256rmkz = 8672,

        VPACKUSDWZ256rr = 8673,

        VPACKUSDWZ256rrk = 8674,

        VPACKUSDWZ256rrkz = 8675,

        VPACKUSDWZrm = 8676,

        VPACKUSDWZrmb = 8677,

        VPACKUSDWZrmbk = 8678,

        VPACKUSDWZrmbkz = 8679,

        VPACKUSDWZrmk = 8680,

        VPACKUSDWZrmkz = 8681,

        VPACKUSDWZrr = 8682,

        VPACKUSDWZrrk = 8683,

        VPACKUSDWZrrkz = 8684,

        VPACKUSDWrm = 8685,

        VPACKUSDWrr = 8686,

        VPACKUSWBYrm = 8687,

        VPACKUSWBYrr = 8688,

        VPACKUSWBZ128rm = 8689,

        VPACKUSWBZ128rmk = 8690,

        VPACKUSWBZ128rmkz = 8691,

        VPACKUSWBZ128rr = 8692,

        VPACKUSWBZ128rrk = 8693,

        VPACKUSWBZ128rrkz = 8694,

        VPACKUSWBZ256rm = 8695,

        VPACKUSWBZ256rmk = 8696,

        VPACKUSWBZ256rmkz = 8697,

        VPACKUSWBZ256rr = 8698,

        VPACKUSWBZ256rrk = 8699,

        VPACKUSWBZ256rrkz = 8700,

        VPACKUSWBZrm = 8701,

        VPACKUSWBZrmk = 8702,

        VPACKUSWBZrmkz = 8703,

        VPACKUSWBZrr = 8704,

        VPACKUSWBZrrk = 8705,

        VPACKUSWBZrrkz = 8706,

        VPACKUSWBrm = 8707,

        VPACKUSWBrr = 8708,

        VPADDBYrm = 8709,

        VPADDBYrr = 8710,

        VPADDBZ128rm = 8711,

        VPADDBZ128rmk = 8712,

        VPADDBZ128rmkz = 8713,

        VPADDBZ128rr = 8714,

        VPADDBZ128rrk = 8715,

        VPADDBZ128rrkz = 8716,

        VPADDBZ256rm = 8717,

        VPADDBZ256rmk = 8718,

        VPADDBZ256rmkz = 8719,

        VPADDBZ256rr = 8720,

        VPADDBZ256rrk = 8721,

        VPADDBZ256rrkz = 8722,

        VPADDBZrm = 8723,

        VPADDBZrmk = 8724,

        VPADDBZrmkz = 8725,

        VPADDBZrr = 8726,

        VPADDBZrrk = 8727,

        VPADDBZrrkz = 8728,

        VPADDBrm = 8729,

        VPADDBrr = 8730,

        VPADDDYrm = 8731,

        VPADDDYrr = 8732,

        VPADDDZ128rm = 8733,

        VPADDDZ128rmb = 8734,

        VPADDDZ128rmbk = 8735,

        VPADDDZ128rmbkz = 8736,

        VPADDDZ128rmk = 8737,

        VPADDDZ128rmkz = 8738,

        VPADDDZ128rr = 8739,

        VPADDDZ128rrk = 8740,

        VPADDDZ128rrkz = 8741,

        VPADDDZ256rm = 8742,

        VPADDDZ256rmb = 8743,

        VPADDDZ256rmbk = 8744,

        VPADDDZ256rmbkz = 8745,

        VPADDDZ256rmk = 8746,

        VPADDDZ256rmkz = 8747,

        VPADDDZ256rr = 8748,

        VPADDDZ256rrk = 8749,

        VPADDDZ256rrkz = 8750,

        VPADDDZrm = 8751,

        VPADDDZrmb = 8752,

        VPADDDZrmbk = 8753,

        VPADDDZrmbkz = 8754,

        VPADDDZrmk = 8755,

        VPADDDZrmkz = 8756,

        VPADDDZrr = 8757,

        VPADDDZrrk = 8758,

        VPADDDZrrkz = 8759,

        VPADDDrm = 8760,

        VPADDDrr = 8761,

        VPADDQYrm = 8762,

        VPADDQYrr = 8763,

        VPADDQZ128rm = 8764,

        VPADDQZ128rmb = 8765,

        VPADDQZ128rmbk = 8766,

        VPADDQZ128rmbkz = 8767,

        VPADDQZ128rmk = 8768,

        VPADDQZ128rmkz = 8769,

        VPADDQZ128rr = 8770,

        VPADDQZ128rrk = 8771,

        VPADDQZ128rrkz = 8772,

        VPADDQZ256rm = 8773,

        VPADDQZ256rmb = 8774,

        VPADDQZ256rmbk = 8775,

        VPADDQZ256rmbkz = 8776,

        VPADDQZ256rmk = 8777,

        VPADDQZ256rmkz = 8778,

        VPADDQZ256rr = 8779,

        VPADDQZ256rrk = 8780,

        VPADDQZ256rrkz = 8781,

        VPADDQZrm = 8782,

        VPADDQZrmb = 8783,

        VPADDQZrmbk = 8784,

        VPADDQZrmbkz = 8785,

        VPADDQZrmk = 8786,

        VPADDQZrmkz = 8787,

        VPADDQZrr = 8788,

        VPADDQZrrk = 8789,

        VPADDQZrrkz = 8790,

        VPADDQrm = 8791,

        VPADDQrr = 8792,

        VPADDSBYrm = 8793,

        VPADDSBYrr = 8794,

        VPADDSBZ128rm = 8795,

        VPADDSBZ128rmk = 8796,

        VPADDSBZ128rmkz = 8797,

        VPADDSBZ128rr = 8798,

        VPADDSBZ128rrk = 8799,

        VPADDSBZ128rrkz = 8800,

        VPADDSBZ256rm = 8801,

        VPADDSBZ256rmk = 8802,

        VPADDSBZ256rmkz = 8803,

        VPADDSBZ256rr = 8804,

        VPADDSBZ256rrk = 8805,

        VPADDSBZ256rrkz = 8806,

        VPADDSBZrm = 8807,

        VPADDSBZrmk = 8808,

        VPADDSBZrmkz = 8809,

        VPADDSBZrr = 8810,

        VPADDSBZrrk = 8811,

        VPADDSBZrrkz = 8812,

        VPADDSBrm = 8813,

        VPADDSBrr = 8814,

        VPADDSWYrm = 8815,

        VPADDSWYrr = 8816,

        VPADDSWZ128rm = 8817,

        VPADDSWZ128rmk = 8818,

        VPADDSWZ128rmkz = 8819,

        VPADDSWZ128rr = 8820,

        VPADDSWZ128rrk = 8821,

        VPADDSWZ128rrkz = 8822,

        VPADDSWZ256rm = 8823,

        VPADDSWZ256rmk = 8824,

        VPADDSWZ256rmkz = 8825,

        VPADDSWZ256rr = 8826,

        VPADDSWZ256rrk = 8827,

        VPADDSWZ256rrkz = 8828,

        VPADDSWZrm = 8829,

        VPADDSWZrmk = 8830,

        VPADDSWZrmkz = 8831,

        VPADDSWZrr = 8832,

        VPADDSWZrrk = 8833,

        VPADDSWZrrkz = 8834,

        VPADDSWrm = 8835,

        VPADDSWrr = 8836,

        VPADDUSBYrm = 8837,

        VPADDUSBYrr = 8838,

        VPADDUSBZ128rm = 8839,

        VPADDUSBZ128rmk = 8840,

        VPADDUSBZ128rmkz = 8841,

        VPADDUSBZ128rr = 8842,

        VPADDUSBZ128rrk = 8843,

        VPADDUSBZ128rrkz = 8844,

        VPADDUSBZ256rm = 8845,

        VPADDUSBZ256rmk = 8846,

        VPADDUSBZ256rmkz = 8847,

        VPADDUSBZ256rr = 8848,

        VPADDUSBZ256rrk = 8849,

        VPADDUSBZ256rrkz = 8850,

        VPADDUSBZrm = 8851,

        VPADDUSBZrmk = 8852,

        VPADDUSBZrmkz = 8853,

        VPADDUSBZrr = 8854,

        VPADDUSBZrrk = 8855,

        VPADDUSBZrrkz = 8856,

        VPADDUSBrm = 8857,

        VPADDUSBrr = 8858,

        VPADDUSWYrm = 8859,

        VPADDUSWYrr = 8860,

        VPADDUSWZ128rm = 8861,

        VPADDUSWZ128rmk = 8862,

        VPADDUSWZ128rmkz = 8863,

        VPADDUSWZ128rr = 8864,

        VPADDUSWZ128rrk = 8865,

        VPADDUSWZ128rrkz = 8866,

        VPADDUSWZ256rm = 8867,

        VPADDUSWZ256rmk = 8868,

        VPADDUSWZ256rmkz = 8869,

        VPADDUSWZ256rr = 8870,

        VPADDUSWZ256rrk = 8871,

        VPADDUSWZ256rrkz = 8872,

        VPADDUSWZrm = 8873,

        VPADDUSWZrmk = 8874,

        VPADDUSWZrmkz = 8875,

        VPADDUSWZrr = 8876,

        VPADDUSWZrrk = 8877,

        VPADDUSWZrrkz = 8878,

        VPADDUSWrm = 8879,

        VPADDUSWrr = 8880,

        VPADDWYrm = 8881,

        VPADDWYrr = 8882,

        VPADDWZ128rm = 8883,

        VPADDWZ128rmk = 8884,

        VPADDWZ128rmkz = 8885,

        VPADDWZ128rr = 8886,

        VPADDWZ128rrk = 8887,

        VPADDWZ128rrkz = 8888,

        VPADDWZ256rm = 8889,

        VPADDWZ256rmk = 8890,

        VPADDWZ256rmkz = 8891,

        VPADDWZ256rr = 8892,

        VPADDWZ256rrk = 8893,

        VPADDWZ256rrkz = 8894,

        VPADDWZrm = 8895,

        VPADDWZrmk = 8896,

        VPADDWZrmkz = 8897,

        VPADDWZrr = 8898,

        VPADDWZrrk = 8899,

        VPADDWZrrkz = 8900,

        VPADDWrm = 8901,

        VPADDWrr = 8902,

        VPALIGNRYrmi = 8903,

        VPALIGNRYrri = 8904,

        VPALIGNRZ128rmi = 8905,

        VPALIGNRZ128rmik = 8906,

        VPALIGNRZ128rmikz = 8907,

        VPALIGNRZ128rri = 8908,

        VPALIGNRZ128rrik = 8909,

        VPALIGNRZ128rrikz = 8910,

        VPALIGNRZ256rmi = 8911,

        VPALIGNRZ256rmik = 8912,

        VPALIGNRZ256rmikz = 8913,

        VPALIGNRZ256rri = 8914,

        VPALIGNRZ256rrik = 8915,

        VPALIGNRZ256rrikz = 8916,

        VPALIGNRZrmi = 8917,

        VPALIGNRZrmik = 8918,

        VPALIGNRZrmikz = 8919,

        VPALIGNRZrri = 8920,

        VPALIGNRZrrik = 8921,

        VPALIGNRZrrikz = 8922,

        VPALIGNRrmi = 8923,

        VPALIGNRrri = 8924,

        VPANDDZ128rm = 8925,

        VPANDDZ128rmb = 8926,

        VPANDDZ128rmbk = 8927,

        VPANDDZ128rmbkz = 8928,

        VPANDDZ128rmk = 8929,

        VPANDDZ128rmkz = 8930,

        VPANDDZ128rr = 8931,

        VPANDDZ128rrk = 8932,

        VPANDDZ128rrkz = 8933,

        VPANDDZ256rm = 8934,

        VPANDDZ256rmb = 8935,

        VPANDDZ256rmbk = 8936,

        VPANDDZ256rmbkz = 8937,

        VPANDDZ256rmk = 8938,

        VPANDDZ256rmkz = 8939,

        VPANDDZ256rr = 8940,

        VPANDDZ256rrk = 8941,

        VPANDDZ256rrkz = 8942,

        VPANDDZrm = 8943,

        VPANDDZrmb = 8944,

        VPANDDZrmbk = 8945,

        VPANDDZrmbkz = 8946,

        VPANDDZrmk = 8947,

        VPANDDZrmkz = 8948,

        VPANDDZrr = 8949,

        VPANDDZrrk = 8950,

        VPANDDZrrkz = 8951,

        VPANDNDZ128rm = 8952,

        VPANDNDZ128rmb = 8953,

        VPANDNDZ128rmbk = 8954,

        VPANDNDZ128rmbkz = 8955,

        VPANDNDZ128rmk = 8956,

        VPANDNDZ128rmkz = 8957,

        VPANDNDZ128rr = 8958,

        VPANDNDZ128rrk = 8959,

        VPANDNDZ128rrkz = 8960,

        VPANDNDZ256rm = 8961,

        VPANDNDZ256rmb = 8962,

        VPANDNDZ256rmbk = 8963,

        VPANDNDZ256rmbkz = 8964,

        VPANDNDZ256rmk = 8965,

        VPANDNDZ256rmkz = 8966,

        VPANDNDZ256rr = 8967,

        VPANDNDZ256rrk = 8968,

        VPANDNDZ256rrkz = 8969,

        VPANDNDZrm = 8970,

        VPANDNDZrmb = 8971,

        VPANDNDZrmbk = 8972,

        VPANDNDZrmbkz = 8973,

        VPANDNDZrmk = 8974,

        VPANDNDZrmkz = 8975,

        VPANDNDZrr = 8976,

        VPANDNDZrrk = 8977,

        VPANDNDZrrkz = 8978,

        VPANDNQZ128rm = 8979,

        VPANDNQZ128rmb = 8980,

        VPANDNQZ128rmbk = 8981,

        VPANDNQZ128rmbkz = 8982,

        VPANDNQZ128rmk = 8983,

        VPANDNQZ128rmkz = 8984,

        VPANDNQZ128rr = 8985,

        VPANDNQZ128rrk = 8986,

        VPANDNQZ128rrkz = 8987,

        VPANDNQZ256rm = 8988,

        VPANDNQZ256rmb = 8989,

        VPANDNQZ256rmbk = 8990,

        VPANDNQZ256rmbkz = 8991,

        VPANDNQZ256rmk = 8992,

        VPANDNQZ256rmkz = 8993,

        VPANDNQZ256rr = 8994,

        VPANDNQZ256rrk = 8995,

        VPANDNQZ256rrkz = 8996,

        VPANDNQZrm = 8997,

        VPANDNQZrmb = 8998,

        VPANDNQZrmbk = 8999,

        VPANDNQZrmbkz = 9000,

        VPANDNQZrmk = 9001,

        VPANDNQZrmkz = 9002,

        VPANDNQZrr = 9003,

        VPANDNQZrrk = 9004,

        VPANDNQZrrkz = 9005,

        VPANDNYrm = 9006,

        VPANDNYrr = 9007,

        VPANDNrm = 9008,

        VPANDNrr = 9009,

        VPANDQZ128rm = 9010,

        VPANDQZ128rmb = 9011,

        VPANDQZ128rmbk = 9012,

        VPANDQZ128rmbkz = 9013,

        VPANDQZ128rmk = 9014,

        VPANDQZ128rmkz = 9015,

        VPANDQZ128rr = 9016,

        VPANDQZ128rrk = 9017,

        VPANDQZ128rrkz = 9018,

        VPANDQZ256rm = 9019,

        VPANDQZ256rmb = 9020,

        VPANDQZ256rmbk = 9021,

        VPANDQZ256rmbkz = 9022,

        VPANDQZ256rmk = 9023,

        VPANDQZ256rmkz = 9024,

        VPANDQZ256rr = 9025,

        VPANDQZ256rrk = 9026,

        VPANDQZ256rrkz = 9027,

        VPANDQZrm = 9028,

        VPANDQZrmb = 9029,

        VPANDQZrmbk = 9030,

        VPANDQZrmbkz = 9031,

        VPANDQZrmk = 9032,

        VPANDQZrmkz = 9033,

        VPANDQZrr = 9034,

        VPANDQZrrk = 9035,

        VPANDQZrrkz = 9036,

        VPANDYrm = 9037,

        VPANDYrr = 9038,

        VPANDrm = 9039,

        VPANDrr = 9040,

        VPAVGBYrm = 9041,

        VPAVGBYrr = 9042,

        VPAVGBZ128rm = 9043,

        VPAVGBZ128rmk = 9044,

        VPAVGBZ128rmkz = 9045,

        VPAVGBZ128rr = 9046,

        VPAVGBZ128rrk = 9047,

        VPAVGBZ128rrkz = 9048,

        VPAVGBZ256rm = 9049,

        VPAVGBZ256rmk = 9050,

        VPAVGBZ256rmkz = 9051,

        VPAVGBZ256rr = 9052,

        VPAVGBZ256rrk = 9053,

        VPAVGBZ256rrkz = 9054,

        VPAVGBZrm = 9055,

        VPAVGBZrmk = 9056,

        VPAVGBZrmkz = 9057,

        VPAVGBZrr = 9058,

        VPAVGBZrrk = 9059,

        VPAVGBZrrkz = 9060,

        VPAVGBrm = 9061,

        VPAVGBrr = 9062,

        VPAVGWYrm = 9063,

        VPAVGWYrr = 9064,

        VPAVGWZ128rm = 9065,

        VPAVGWZ128rmk = 9066,

        VPAVGWZ128rmkz = 9067,

        VPAVGWZ128rr = 9068,

        VPAVGWZ128rrk = 9069,

        VPAVGWZ128rrkz = 9070,

        VPAVGWZ256rm = 9071,

        VPAVGWZ256rmk = 9072,

        VPAVGWZ256rmkz = 9073,

        VPAVGWZ256rr = 9074,

        VPAVGWZ256rrk = 9075,

        VPAVGWZ256rrkz = 9076,

        VPAVGWZrm = 9077,

        VPAVGWZrmk = 9078,

        VPAVGWZrmkz = 9079,

        VPAVGWZrr = 9080,

        VPAVGWZrrk = 9081,

        VPAVGWZrrkz = 9082,

        VPAVGWrm = 9083,

        VPAVGWrr = 9084,

        VPBLENDDYrmi = 9085,

        VPBLENDDYrri = 9086,

        VPBLENDDrmi = 9087,

        VPBLENDDrri = 9088,

        VPBLENDMBZ128rm = 9089,

        VPBLENDMBZ128rmk = 9090,

        VPBLENDMBZ128rmkz = 9091,

        VPBLENDMBZ128rr = 9092,

        VPBLENDMBZ128rrk = 9093,

        VPBLENDMBZ128rrkz = 9094,

        VPBLENDMBZ256rm = 9095,

        VPBLENDMBZ256rmk = 9096,

        VPBLENDMBZ256rmkz = 9097,

        VPBLENDMBZ256rr = 9098,

        VPBLENDMBZ256rrk = 9099,

        VPBLENDMBZ256rrkz = 9100,

        VPBLENDMBZrm = 9101,

        VPBLENDMBZrmk = 9102,

        VPBLENDMBZrmkz = 9103,

        VPBLENDMBZrr = 9104,

        VPBLENDMBZrrk = 9105,

        VPBLENDMBZrrkz = 9106,

        VPBLENDMDZ128rm = 9107,

        VPBLENDMDZ128rmb = 9108,

        VPBLENDMDZ128rmbk = 9109,

        VPBLENDMDZ128rmbkz = 9110,

        VPBLENDMDZ128rmk = 9111,

        VPBLENDMDZ128rmkz = 9112,

        VPBLENDMDZ128rr = 9113,

        VPBLENDMDZ128rrk = 9114,

        VPBLENDMDZ128rrkz = 9115,

        VPBLENDMDZ256rm = 9116,

        VPBLENDMDZ256rmb = 9117,

        VPBLENDMDZ256rmbk = 9118,

        VPBLENDMDZ256rmbkz = 9119,

        VPBLENDMDZ256rmk = 9120,

        VPBLENDMDZ256rmkz = 9121,

        VPBLENDMDZ256rr = 9122,

        VPBLENDMDZ256rrk = 9123,

        VPBLENDMDZ256rrkz = 9124,

        VPBLENDMDZrm = 9125,

        VPBLENDMDZrmb = 9126,

        VPBLENDMDZrmbk = 9127,

        VPBLENDMDZrmbkz = 9128,

        VPBLENDMDZrmk = 9129,

        VPBLENDMDZrmkz = 9130,

        VPBLENDMDZrr = 9131,

        VPBLENDMDZrrk = 9132,

        VPBLENDMDZrrkz = 9133,

        VPBLENDMQZ128rm = 9134,

        VPBLENDMQZ128rmb = 9135,

        VPBLENDMQZ128rmbk = 9136,

        VPBLENDMQZ128rmbkz = 9137,

        VPBLENDMQZ128rmk = 9138,

        VPBLENDMQZ128rmkz = 9139,

        VPBLENDMQZ128rr = 9140,

        VPBLENDMQZ128rrk = 9141,

        VPBLENDMQZ128rrkz = 9142,

        VPBLENDMQZ256rm = 9143,

        VPBLENDMQZ256rmb = 9144,

        VPBLENDMQZ256rmbk = 9145,

        VPBLENDMQZ256rmbkz = 9146,

        VPBLENDMQZ256rmk = 9147,

        VPBLENDMQZ256rmkz = 9148,

        VPBLENDMQZ256rr = 9149,

        VPBLENDMQZ256rrk = 9150,

        VPBLENDMQZ256rrkz = 9151,

        VPBLENDMQZrm = 9152,

        VPBLENDMQZrmb = 9153,

        VPBLENDMQZrmbk = 9154,

        VPBLENDMQZrmbkz = 9155,

        VPBLENDMQZrmk = 9156,

        VPBLENDMQZrmkz = 9157,

        VPBLENDMQZrr = 9158,

        VPBLENDMQZrrk = 9159,

        VPBLENDMQZrrkz = 9160,

        VPBLENDMWZ128rm = 9161,

        VPBLENDMWZ128rmk = 9162,

        VPBLENDMWZ128rmkz = 9163,

        VPBLENDMWZ128rr = 9164,

        VPBLENDMWZ128rrk = 9165,

        VPBLENDMWZ128rrkz = 9166,

        VPBLENDMWZ256rm = 9167,

        VPBLENDMWZ256rmk = 9168,

        VPBLENDMWZ256rmkz = 9169,

        VPBLENDMWZ256rr = 9170,

        VPBLENDMWZ256rrk = 9171,

        VPBLENDMWZ256rrkz = 9172,

        VPBLENDMWZrm = 9173,

        VPBLENDMWZrmk = 9174,

        VPBLENDMWZrmkz = 9175,

        VPBLENDMWZrr = 9176,

        VPBLENDMWZrrk = 9177,

        VPBLENDMWZrrkz = 9178,

        VPBLENDVBYrm = 9179,

        VPBLENDVBYrr = 9180,

        VPBLENDVBrm = 9181,

        VPBLENDVBrr = 9182,

        VPBLENDWYrmi = 9183,

        VPBLENDWYrri = 9184,

        VPBLENDWrmi = 9185,

        VPBLENDWrri = 9186,

        VPBROADCASTBYrm = 9187,

        VPBROADCASTBYrr = 9188,

        VPBROADCASTBZ128rm = 9189,

        VPBROADCASTBZ128rmk = 9190,

        VPBROADCASTBZ128rmkz = 9191,

        VPBROADCASTBZ128rr = 9192,

        VPBROADCASTBZ128rrk = 9193,

        VPBROADCASTBZ128rrkz = 9194,

        VPBROADCASTBZ256rm = 9195,

        VPBROADCASTBZ256rmk = 9196,

        VPBROADCASTBZ256rmkz = 9197,

        VPBROADCASTBZ256rr = 9198,

        VPBROADCASTBZ256rrk = 9199,

        VPBROADCASTBZ256rrkz = 9200,

        VPBROADCASTBZrm = 9201,

        VPBROADCASTBZrmk = 9202,

        VPBROADCASTBZrmkz = 9203,

        VPBROADCASTBZrr = 9204,

        VPBROADCASTBZrrk = 9205,

        VPBROADCASTBZrrkz = 9206,

        VPBROADCASTBrZ128rr = 9207,

        VPBROADCASTBrZ128rrk = 9208,

        VPBROADCASTBrZ128rrkz = 9209,

        VPBROADCASTBrZ256rr = 9210,

        VPBROADCASTBrZ256rrk = 9211,

        VPBROADCASTBrZ256rrkz = 9212,

        VPBROADCASTBrZrr = 9213,

        VPBROADCASTBrZrrk = 9214,

        VPBROADCASTBrZrrkz = 9215,

        VPBROADCASTBrm = 9216,

        VPBROADCASTBrr = 9217,

        VPBROADCASTDYrm = 9218,

        VPBROADCASTDYrr = 9219,

        VPBROADCASTDZ128rm = 9220,

        VPBROADCASTDZ128rmk = 9221,

        VPBROADCASTDZ128rmkz = 9222,

        VPBROADCASTDZ128rr = 9223,

        VPBROADCASTDZ128rrk = 9224,

        VPBROADCASTDZ128rrkz = 9225,

        VPBROADCASTDZ256rm = 9226,

        VPBROADCASTDZ256rmk = 9227,

        VPBROADCASTDZ256rmkz = 9228,

        VPBROADCASTDZ256rr = 9229,

        VPBROADCASTDZ256rrk = 9230,

        VPBROADCASTDZ256rrkz = 9231,

        VPBROADCASTDZrm = 9232,

        VPBROADCASTDZrmk = 9233,

        VPBROADCASTDZrmkz = 9234,

        VPBROADCASTDZrr = 9235,

        VPBROADCASTDZrrk = 9236,

        VPBROADCASTDZrrkz = 9237,

        VPBROADCASTDrZ128rr = 9238,

        VPBROADCASTDrZ128rrk = 9239,

        VPBROADCASTDrZ128rrkz = 9240,

        VPBROADCASTDrZ256rr = 9241,

        VPBROADCASTDrZ256rrk = 9242,

        VPBROADCASTDrZ256rrkz = 9243,

        VPBROADCASTDrZrr = 9244,

        VPBROADCASTDrZrrk = 9245,

        VPBROADCASTDrZrrkz = 9246,

        VPBROADCASTDrm = 9247,

        VPBROADCASTDrr = 9248,

        VPBROADCASTMB2QZ128rr = 9249,

        VPBROADCASTMB2QZ256rr = 9250,

        VPBROADCASTMB2QZrr = 9251,

        VPBROADCASTMW2DZ128rr = 9252,

        VPBROADCASTMW2DZ256rr = 9253,

        VPBROADCASTMW2DZrr = 9254,

        VPBROADCASTQYrm = 9255,

        VPBROADCASTQYrr = 9256,

        VPBROADCASTQZ128rm = 9257,

        VPBROADCASTQZ128rmk = 9258,

        VPBROADCASTQZ128rmkz = 9259,

        VPBROADCASTQZ128rr = 9260,

        VPBROADCASTQZ128rrk = 9261,

        VPBROADCASTQZ128rrkz = 9262,

        VPBROADCASTQZ256rm = 9263,

        VPBROADCASTQZ256rmk = 9264,

        VPBROADCASTQZ256rmkz = 9265,

        VPBROADCASTQZ256rr = 9266,

        VPBROADCASTQZ256rrk = 9267,

        VPBROADCASTQZ256rrkz = 9268,

        VPBROADCASTQZrm = 9269,

        VPBROADCASTQZrmk = 9270,

        VPBROADCASTQZrmkz = 9271,

        VPBROADCASTQZrr = 9272,

        VPBROADCASTQZrrk = 9273,

        VPBROADCASTQZrrkz = 9274,

        VPBROADCASTQrZ128rr = 9275,

        VPBROADCASTQrZ128rrk = 9276,

        VPBROADCASTQrZ128rrkz = 9277,

        VPBROADCASTQrZ256rr = 9278,

        VPBROADCASTQrZ256rrk = 9279,

        VPBROADCASTQrZ256rrkz = 9280,

        VPBROADCASTQrZrr = 9281,

        VPBROADCASTQrZrrk = 9282,

        VPBROADCASTQrZrrkz = 9283,

        VPBROADCASTQrm = 9284,

        VPBROADCASTQrr = 9285,

        VPBROADCASTWYrm = 9286,

        VPBROADCASTWYrr = 9287,

        VPBROADCASTWZ128rm = 9288,

        VPBROADCASTWZ128rmk = 9289,

        VPBROADCASTWZ128rmkz = 9290,

        VPBROADCASTWZ128rr = 9291,

        VPBROADCASTWZ128rrk = 9292,

        VPBROADCASTWZ128rrkz = 9293,

        VPBROADCASTWZ256rm = 9294,

        VPBROADCASTWZ256rmk = 9295,

        VPBROADCASTWZ256rmkz = 9296,

        VPBROADCASTWZ256rr = 9297,

        VPBROADCASTWZ256rrk = 9298,

        VPBROADCASTWZ256rrkz = 9299,

        VPBROADCASTWZrm = 9300,

        VPBROADCASTWZrmk = 9301,

        VPBROADCASTWZrmkz = 9302,

        VPBROADCASTWZrr = 9303,

        VPBROADCASTWZrrk = 9304,

        VPBROADCASTWZrrkz = 9305,

        VPBROADCASTWrZ128rr = 9306,

        VPBROADCASTWrZ128rrk = 9307,

        VPBROADCASTWrZ128rrkz = 9308,

        VPBROADCASTWrZ256rr = 9309,

        VPBROADCASTWrZ256rrk = 9310,

        VPBROADCASTWrZ256rrkz = 9311,

        VPBROADCASTWrZrr = 9312,

        VPBROADCASTWrZrrk = 9313,

        VPBROADCASTWrZrrkz = 9314,

        VPBROADCASTWrm = 9315,

        VPBROADCASTWrr = 9316,

        VPCLMULQDQYrm = 9317,

        VPCLMULQDQYrr = 9318,

        VPCLMULQDQZ128rm = 9319,

        VPCLMULQDQZ128rr = 9320,

        VPCLMULQDQZ256rm = 9321,

        VPCLMULQDQZ256rr = 9322,

        VPCLMULQDQZrm = 9323,

        VPCLMULQDQZrr = 9324,

        VPCLMULQDQrm = 9325,

        VPCLMULQDQrr = 9326,

        VPCMOVYrmr = 9327,

        VPCMOVYrrm = 9328,

        VPCMOVYrrr = 9329,

        VPCMOVYrrr_REV = 9330,

        VPCMOVrmr = 9331,

        VPCMOVrrm = 9332,

        VPCMOVrrr = 9333,

        VPCMOVrrr_REV = 9334,

        VPCMPBZ128rmi = 9335,

        VPCMPBZ128rmik = 9336,

        VPCMPBZ128rri = 9337,

        VPCMPBZ128rrik = 9338,

        VPCMPBZ256rmi = 9339,

        VPCMPBZ256rmik = 9340,

        VPCMPBZ256rri = 9341,

        VPCMPBZ256rrik = 9342,

        VPCMPBZrmi = 9343,

        VPCMPBZrmik = 9344,

        VPCMPBZrri = 9345,

        VPCMPBZrrik = 9346,

        VPCMPDZ128rmi = 9347,

        VPCMPDZ128rmib = 9348,

        VPCMPDZ128rmibk = 9349,

        VPCMPDZ128rmik = 9350,

        VPCMPDZ128rri = 9351,

        VPCMPDZ128rrik = 9352,

        VPCMPDZ256rmi = 9353,

        VPCMPDZ256rmib = 9354,

        VPCMPDZ256rmibk = 9355,

        VPCMPDZ256rmik = 9356,

        VPCMPDZ256rri = 9357,

        VPCMPDZ256rrik = 9358,

        VPCMPDZrmi = 9359,

        VPCMPDZrmib = 9360,

        VPCMPDZrmibk = 9361,

        VPCMPDZrmik = 9362,

        VPCMPDZrri = 9363,

        VPCMPDZrrik = 9364,

        VPCMPEQBYrm = 9365,

        VPCMPEQBYrr = 9366,

        VPCMPEQBZ128rm = 9367,

        VPCMPEQBZ128rmk = 9368,

        VPCMPEQBZ128rr = 9369,

        VPCMPEQBZ128rrk = 9370,

        VPCMPEQBZ256rm = 9371,

        VPCMPEQBZ256rmk = 9372,

        VPCMPEQBZ256rr = 9373,

        VPCMPEQBZ256rrk = 9374,

        VPCMPEQBZrm = 9375,

        VPCMPEQBZrmk = 9376,

        VPCMPEQBZrr = 9377,

        VPCMPEQBZrrk = 9378,

        VPCMPEQBrm = 9379,

        VPCMPEQBrr = 9380,

        VPCMPEQDYrm = 9381,

        VPCMPEQDYrr = 9382,

        VPCMPEQDZ128rm = 9383,

        VPCMPEQDZ128rmb = 9384,

        VPCMPEQDZ128rmbk = 9385,

        VPCMPEQDZ128rmk = 9386,

        VPCMPEQDZ128rr = 9387,

        VPCMPEQDZ128rrk = 9388,

        VPCMPEQDZ256rm = 9389,

        VPCMPEQDZ256rmb = 9390,

        VPCMPEQDZ256rmbk = 9391,

        VPCMPEQDZ256rmk = 9392,

        VPCMPEQDZ256rr = 9393,

        VPCMPEQDZ256rrk = 9394,

        VPCMPEQDZrm = 9395,

        VPCMPEQDZrmb = 9396,

        VPCMPEQDZrmbk = 9397,

        VPCMPEQDZrmk = 9398,

        VPCMPEQDZrr = 9399,

        VPCMPEQDZrrk = 9400,

        VPCMPEQDrm = 9401,

        VPCMPEQDrr = 9402,

        VPCMPEQQYrm = 9403,

        VPCMPEQQYrr = 9404,

        VPCMPEQQZ128rm = 9405,

        VPCMPEQQZ128rmb = 9406,

        VPCMPEQQZ128rmbk = 9407,

        VPCMPEQQZ128rmk = 9408,

        VPCMPEQQZ128rr = 9409,

        VPCMPEQQZ128rrk = 9410,

        VPCMPEQQZ256rm = 9411,

        VPCMPEQQZ256rmb = 9412,

        VPCMPEQQZ256rmbk = 9413,

        VPCMPEQQZ256rmk = 9414,

        VPCMPEQQZ256rr = 9415,

        VPCMPEQQZ256rrk = 9416,

        VPCMPEQQZrm = 9417,

        VPCMPEQQZrmb = 9418,

        VPCMPEQQZrmbk = 9419,

        VPCMPEQQZrmk = 9420,

        VPCMPEQQZrr = 9421,

        VPCMPEQQZrrk = 9422,

        VPCMPEQQrm = 9423,

        VPCMPEQQrr = 9424,

        VPCMPEQWYrm = 9425,

        VPCMPEQWYrr = 9426,

        VPCMPEQWZ128rm = 9427,

        VPCMPEQWZ128rmk = 9428,

        VPCMPEQWZ128rr = 9429,

        VPCMPEQWZ128rrk = 9430,

        VPCMPEQWZ256rm = 9431,

        VPCMPEQWZ256rmk = 9432,

        VPCMPEQWZ256rr = 9433,

        VPCMPEQWZ256rrk = 9434,

        VPCMPEQWZrm = 9435,

        VPCMPEQWZrmk = 9436,

        VPCMPEQWZrr = 9437,

        VPCMPEQWZrrk = 9438,

        VPCMPEQWrm = 9439,

        VPCMPEQWrr = 9440,

        VPCMPESTRIrm = 9441,

        VPCMPESTRIrr = 9442,

        VPCMPESTRMrm = 9443,

        VPCMPESTRMrr = 9444,

        VPCMPGTBYrm = 9445,

        VPCMPGTBYrr = 9446,

        VPCMPGTBZ128rm = 9447,

        VPCMPGTBZ128rmk = 9448,

        VPCMPGTBZ128rr = 9449,

        VPCMPGTBZ128rrk = 9450,

        VPCMPGTBZ256rm = 9451,

        VPCMPGTBZ256rmk = 9452,

        VPCMPGTBZ256rr = 9453,

        VPCMPGTBZ256rrk = 9454,

        VPCMPGTBZrm = 9455,

        VPCMPGTBZrmk = 9456,

        VPCMPGTBZrr = 9457,

        VPCMPGTBZrrk = 9458,

        VPCMPGTBrm = 9459,

        VPCMPGTBrr = 9460,

        VPCMPGTDYrm = 9461,

        VPCMPGTDYrr = 9462,

        VPCMPGTDZ128rm = 9463,

        VPCMPGTDZ128rmb = 9464,

        VPCMPGTDZ128rmbk = 9465,

        VPCMPGTDZ128rmk = 9466,

        VPCMPGTDZ128rr = 9467,

        VPCMPGTDZ128rrk = 9468,

        VPCMPGTDZ256rm = 9469,

        VPCMPGTDZ256rmb = 9470,

        VPCMPGTDZ256rmbk = 9471,

        VPCMPGTDZ256rmk = 9472,

        VPCMPGTDZ256rr = 9473,

        VPCMPGTDZ256rrk = 9474,

        VPCMPGTDZrm = 9475,

        VPCMPGTDZrmb = 9476,

        VPCMPGTDZrmbk = 9477,

        VPCMPGTDZrmk = 9478,

        VPCMPGTDZrr = 9479,

        VPCMPGTDZrrk = 9480,

        VPCMPGTDrm = 9481,

        VPCMPGTDrr = 9482,

        VPCMPGTQYrm = 9483,

        VPCMPGTQYrr = 9484,

        VPCMPGTQZ128rm = 9485,

        VPCMPGTQZ128rmb = 9486,

        VPCMPGTQZ128rmbk = 9487,

        VPCMPGTQZ128rmk = 9488,

        VPCMPGTQZ128rr = 9489,

        VPCMPGTQZ128rrk = 9490,

        VPCMPGTQZ256rm = 9491,

        VPCMPGTQZ256rmb = 9492,

        VPCMPGTQZ256rmbk = 9493,

        VPCMPGTQZ256rmk = 9494,

        VPCMPGTQZ256rr = 9495,

        VPCMPGTQZ256rrk = 9496,

        VPCMPGTQZrm = 9497,

        VPCMPGTQZrmb = 9498,

        VPCMPGTQZrmbk = 9499,

        VPCMPGTQZrmk = 9500,

        VPCMPGTQZrr = 9501,

        VPCMPGTQZrrk = 9502,

        VPCMPGTQrm = 9503,

        VPCMPGTQrr = 9504,

        VPCMPGTWYrm = 9505,

        VPCMPGTWYrr = 9506,

        VPCMPGTWZ128rm = 9507,

        VPCMPGTWZ128rmk = 9508,

        VPCMPGTWZ128rr = 9509,

        VPCMPGTWZ128rrk = 9510,

        VPCMPGTWZ256rm = 9511,

        VPCMPGTWZ256rmk = 9512,

        VPCMPGTWZ256rr = 9513,

        VPCMPGTWZ256rrk = 9514,

        VPCMPGTWZrm = 9515,

        VPCMPGTWZrmk = 9516,

        VPCMPGTWZrr = 9517,

        VPCMPGTWZrrk = 9518,

        VPCMPGTWrm = 9519,

        VPCMPGTWrr = 9520,

        VPCMPISTRIrm = 9521,

        VPCMPISTRIrr = 9522,

        VPCMPISTRMrm = 9523,

        VPCMPISTRMrr = 9524,

        VPCMPQZ128rmi = 9525,

        VPCMPQZ128rmib = 9526,

        VPCMPQZ128rmibk = 9527,

        VPCMPQZ128rmik = 9528,

        VPCMPQZ128rri = 9529,

        VPCMPQZ128rrik = 9530,

        VPCMPQZ256rmi = 9531,

        VPCMPQZ256rmib = 9532,

        VPCMPQZ256rmibk = 9533,

        VPCMPQZ256rmik = 9534,

        VPCMPQZ256rri = 9535,

        VPCMPQZ256rrik = 9536,

        VPCMPQZrmi = 9537,

        VPCMPQZrmib = 9538,

        VPCMPQZrmibk = 9539,

        VPCMPQZrmik = 9540,

        VPCMPQZrri = 9541,

        VPCMPQZrrik = 9542,

        VPCMPUBZ128rmi = 9543,

        VPCMPUBZ128rmik = 9544,

        VPCMPUBZ128rri = 9545,

        VPCMPUBZ128rrik = 9546,

        VPCMPUBZ256rmi = 9547,

        VPCMPUBZ256rmik = 9548,

        VPCMPUBZ256rri = 9549,

        VPCMPUBZ256rrik = 9550,

        VPCMPUBZrmi = 9551,

        VPCMPUBZrmik = 9552,

        VPCMPUBZrri = 9553,

        VPCMPUBZrrik = 9554,

        VPCMPUDZ128rmi = 9555,

        VPCMPUDZ128rmib = 9556,

        VPCMPUDZ128rmibk = 9557,

        VPCMPUDZ128rmik = 9558,

        VPCMPUDZ128rri = 9559,

        VPCMPUDZ128rrik = 9560,

        VPCMPUDZ256rmi = 9561,

        VPCMPUDZ256rmib = 9562,

        VPCMPUDZ256rmibk = 9563,

        VPCMPUDZ256rmik = 9564,

        VPCMPUDZ256rri = 9565,

        VPCMPUDZ256rrik = 9566,

        VPCMPUDZrmi = 9567,

        VPCMPUDZrmib = 9568,

        VPCMPUDZrmibk = 9569,

        VPCMPUDZrmik = 9570,

        VPCMPUDZrri = 9571,

        VPCMPUDZrrik = 9572,

        VPCMPUQZ128rmi = 9573,

        VPCMPUQZ128rmib = 9574,

        VPCMPUQZ128rmibk = 9575,

        VPCMPUQZ128rmik = 9576,

        VPCMPUQZ128rri = 9577,

        VPCMPUQZ128rrik = 9578,

        VPCMPUQZ256rmi = 9579,

        VPCMPUQZ256rmib = 9580,

        VPCMPUQZ256rmibk = 9581,

        VPCMPUQZ256rmik = 9582,

        VPCMPUQZ256rri = 9583,

        VPCMPUQZ256rrik = 9584,

        VPCMPUQZrmi = 9585,

        VPCMPUQZrmib = 9586,

        VPCMPUQZrmibk = 9587,

        VPCMPUQZrmik = 9588,

        VPCMPUQZrri = 9589,

        VPCMPUQZrrik = 9590,

        VPCMPUWZ128rmi = 9591,

        VPCMPUWZ128rmik = 9592,

        VPCMPUWZ128rri = 9593,

        VPCMPUWZ128rrik = 9594,

        VPCMPUWZ256rmi = 9595,

        VPCMPUWZ256rmik = 9596,

        VPCMPUWZ256rri = 9597,

        VPCMPUWZ256rrik = 9598,

        VPCMPUWZrmi = 9599,

        VPCMPUWZrmik = 9600,

        VPCMPUWZrri = 9601,

        VPCMPUWZrrik = 9602,

        VPCMPWZ128rmi = 9603,

        VPCMPWZ128rmik = 9604,

        VPCMPWZ128rri = 9605,

        VPCMPWZ128rrik = 9606,

        VPCMPWZ256rmi = 9607,

        VPCMPWZ256rmik = 9608,

        VPCMPWZ256rri = 9609,

        VPCMPWZ256rrik = 9610,

        VPCMPWZrmi = 9611,

        VPCMPWZrmik = 9612,

        VPCMPWZrri = 9613,

        VPCMPWZrrik = 9614,

        VPCOMBmi = 9615,

        VPCOMBri = 9616,

        VPCOMDmi = 9617,

        VPCOMDri = 9618,

        VPCOMPRESSBZ128mr = 9619,

        VPCOMPRESSBZ128mrk = 9620,

        VPCOMPRESSBZ128rr = 9621,

        VPCOMPRESSBZ128rrk = 9622,

        VPCOMPRESSBZ128rrkz = 9623,

        VPCOMPRESSBZ256mr = 9624,

        VPCOMPRESSBZ256mrk = 9625,

        VPCOMPRESSBZ256rr = 9626,

        VPCOMPRESSBZ256rrk = 9627,

        VPCOMPRESSBZ256rrkz = 9628,

        VPCOMPRESSBZmr = 9629,

        VPCOMPRESSBZmrk = 9630,

        VPCOMPRESSBZrr = 9631,

        VPCOMPRESSBZrrk = 9632,

        VPCOMPRESSBZrrkz = 9633,

        VPCOMPRESSDZ128mr = 9634,

        VPCOMPRESSDZ128mrk = 9635,

        VPCOMPRESSDZ128rr = 9636,

        VPCOMPRESSDZ128rrk = 9637,

        VPCOMPRESSDZ128rrkz = 9638,

        VPCOMPRESSDZ256mr = 9639,

        VPCOMPRESSDZ256mrk = 9640,

        VPCOMPRESSDZ256rr = 9641,

        VPCOMPRESSDZ256rrk = 9642,

        VPCOMPRESSDZ256rrkz = 9643,

        VPCOMPRESSDZmr = 9644,

        VPCOMPRESSDZmrk = 9645,

        VPCOMPRESSDZrr = 9646,

        VPCOMPRESSDZrrk = 9647,

        VPCOMPRESSDZrrkz = 9648,

        VPCOMPRESSQZ128mr = 9649,

        VPCOMPRESSQZ128mrk = 9650,

        VPCOMPRESSQZ128rr = 9651,

        VPCOMPRESSQZ128rrk = 9652,

        VPCOMPRESSQZ128rrkz = 9653,

        VPCOMPRESSQZ256mr = 9654,

        VPCOMPRESSQZ256mrk = 9655,

        VPCOMPRESSQZ256rr = 9656,

        VPCOMPRESSQZ256rrk = 9657,

        VPCOMPRESSQZ256rrkz = 9658,

        VPCOMPRESSQZmr = 9659,

        VPCOMPRESSQZmrk = 9660,

        VPCOMPRESSQZrr = 9661,

        VPCOMPRESSQZrrk = 9662,

        VPCOMPRESSQZrrkz = 9663,

        VPCOMPRESSWZ128mr = 9664,

        VPCOMPRESSWZ128mrk = 9665,

        VPCOMPRESSWZ128rr = 9666,

        VPCOMPRESSWZ128rrk = 9667,

        VPCOMPRESSWZ128rrkz = 9668,

        VPCOMPRESSWZ256mr = 9669,

        VPCOMPRESSWZ256mrk = 9670,

        VPCOMPRESSWZ256rr = 9671,

        VPCOMPRESSWZ256rrk = 9672,

        VPCOMPRESSWZ256rrkz = 9673,

        VPCOMPRESSWZmr = 9674,

        VPCOMPRESSWZmrk = 9675,

        VPCOMPRESSWZrr = 9676,

        VPCOMPRESSWZrrk = 9677,

        VPCOMPRESSWZrrkz = 9678,

        VPCOMQmi = 9679,

        VPCOMQri = 9680,

        VPCOMUBmi = 9681,

        VPCOMUBri = 9682,

        VPCOMUDmi = 9683,

        VPCOMUDri = 9684,

        VPCOMUQmi = 9685,

        VPCOMUQri = 9686,

        VPCOMUWmi = 9687,

        VPCOMUWri = 9688,

        VPCOMWmi = 9689,

        VPCOMWri = 9690,

        VPCONFLICTDZ128rm = 9691,

        VPCONFLICTDZ128rmb = 9692,

        VPCONFLICTDZ128rmbk = 9693,

        VPCONFLICTDZ128rmbkz = 9694,

        VPCONFLICTDZ128rmk = 9695,

        VPCONFLICTDZ128rmkz = 9696,

        VPCONFLICTDZ128rr = 9697,

        VPCONFLICTDZ128rrk = 9698,

        VPCONFLICTDZ128rrkz = 9699,

        VPCONFLICTDZ256rm = 9700,

        VPCONFLICTDZ256rmb = 9701,

        VPCONFLICTDZ256rmbk = 9702,

        VPCONFLICTDZ256rmbkz = 9703,

        VPCONFLICTDZ256rmk = 9704,

        VPCONFLICTDZ256rmkz = 9705,

        VPCONFLICTDZ256rr = 9706,

        VPCONFLICTDZ256rrk = 9707,

        VPCONFLICTDZ256rrkz = 9708,

        VPCONFLICTDZrm = 9709,

        VPCONFLICTDZrmb = 9710,

        VPCONFLICTDZrmbk = 9711,

        VPCONFLICTDZrmbkz = 9712,

        VPCONFLICTDZrmk = 9713,

        VPCONFLICTDZrmkz = 9714,

        VPCONFLICTDZrr = 9715,

        VPCONFLICTDZrrk = 9716,

        VPCONFLICTDZrrkz = 9717,

        VPCONFLICTQZ128rm = 9718,

        VPCONFLICTQZ128rmb = 9719,

        VPCONFLICTQZ128rmbk = 9720,

        VPCONFLICTQZ128rmbkz = 9721,

        VPCONFLICTQZ128rmk = 9722,

        VPCONFLICTQZ128rmkz = 9723,

        VPCONFLICTQZ128rr = 9724,

        VPCONFLICTQZ128rrk = 9725,

        VPCONFLICTQZ128rrkz = 9726,

        VPCONFLICTQZ256rm = 9727,

        VPCONFLICTQZ256rmb = 9728,

        VPCONFLICTQZ256rmbk = 9729,

        VPCONFLICTQZ256rmbkz = 9730,

        VPCONFLICTQZ256rmk = 9731,

        VPCONFLICTQZ256rmkz = 9732,

        VPCONFLICTQZ256rr = 9733,

        VPCONFLICTQZ256rrk = 9734,

        VPCONFLICTQZ256rrkz = 9735,

        VPCONFLICTQZrm = 9736,

        VPCONFLICTQZrmb = 9737,

        VPCONFLICTQZrmbk = 9738,

        VPCONFLICTQZrmbkz = 9739,

        VPCONFLICTQZrmk = 9740,

        VPCONFLICTQZrmkz = 9741,

        VPCONFLICTQZrr = 9742,

        VPCONFLICTQZrrk = 9743,

        VPCONFLICTQZrrkz = 9744,

        VPDPBUSDSYrm = 9745,

        VPDPBUSDSYrr = 9746,

        VPDPBUSDSZ128m = 9747,

        VPDPBUSDSZ128mb = 9748,

        VPDPBUSDSZ128mbk = 9749,

        VPDPBUSDSZ128mbkz = 9750,

        VPDPBUSDSZ128mk = 9751,

        VPDPBUSDSZ128mkz = 9752,

        VPDPBUSDSZ128r = 9753,

        VPDPBUSDSZ128rk = 9754,

        VPDPBUSDSZ128rkz = 9755,

        VPDPBUSDSZ256m = 9756,

        VPDPBUSDSZ256mb = 9757,

        VPDPBUSDSZ256mbk = 9758,

        VPDPBUSDSZ256mbkz = 9759,

        VPDPBUSDSZ256mk = 9760,

        VPDPBUSDSZ256mkz = 9761,

        VPDPBUSDSZ256r = 9762,

        VPDPBUSDSZ256rk = 9763,

        VPDPBUSDSZ256rkz = 9764,

        VPDPBUSDSZm = 9765,

        VPDPBUSDSZmb = 9766,

        VPDPBUSDSZmbk = 9767,

        VPDPBUSDSZmbkz = 9768,

        VPDPBUSDSZmk = 9769,

        VPDPBUSDSZmkz = 9770,

        VPDPBUSDSZr = 9771,

        VPDPBUSDSZrk = 9772,

        VPDPBUSDSZrkz = 9773,

        VPDPBUSDSrm = 9774,

        VPDPBUSDSrr = 9775,

        VPDPBUSDYrm = 9776,

        VPDPBUSDYrr = 9777,

        VPDPBUSDZ128m = 9778,

        VPDPBUSDZ128mb = 9779,

        VPDPBUSDZ128mbk = 9780,

        VPDPBUSDZ128mbkz = 9781,

        VPDPBUSDZ128mk = 9782,

        VPDPBUSDZ128mkz = 9783,

        VPDPBUSDZ128r = 9784,

        VPDPBUSDZ128rk = 9785,

        VPDPBUSDZ128rkz = 9786,

        VPDPBUSDZ256m = 9787,

        VPDPBUSDZ256mb = 9788,

        VPDPBUSDZ256mbk = 9789,

        VPDPBUSDZ256mbkz = 9790,

        VPDPBUSDZ256mk = 9791,

        VPDPBUSDZ256mkz = 9792,

        VPDPBUSDZ256r = 9793,

        VPDPBUSDZ256rk = 9794,

        VPDPBUSDZ256rkz = 9795,

        VPDPBUSDZm = 9796,

        VPDPBUSDZmb = 9797,

        VPDPBUSDZmbk = 9798,

        VPDPBUSDZmbkz = 9799,

        VPDPBUSDZmk = 9800,

        VPDPBUSDZmkz = 9801,

        VPDPBUSDZr = 9802,

        VPDPBUSDZrk = 9803,

        VPDPBUSDZrkz = 9804,

        VPDPBUSDrm = 9805,

        VPDPBUSDrr = 9806,

        VPDPWSSDSYrm = 9807,

        VPDPWSSDSYrr = 9808,

        VPDPWSSDSZ128m = 9809,

        VPDPWSSDSZ128mb = 9810,

        VPDPWSSDSZ128mbk = 9811,

        VPDPWSSDSZ128mbkz = 9812,

        VPDPWSSDSZ128mk = 9813,

        VPDPWSSDSZ128mkz = 9814,

        VPDPWSSDSZ128r = 9815,

        VPDPWSSDSZ128rk = 9816,

        VPDPWSSDSZ128rkz = 9817,

        VPDPWSSDSZ256m = 9818,

        VPDPWSSDSZ256mb = 9819,

        VPDPWSSDSZ256mbk = 9820,

        VPDPWSSDSZ256mbkz = 9821,

        VPDPWSSDSZ256mk = 9822,

        VPDPWSSDSZ256mkz = 9823,

        VPDPWSSDSZ256r = 9824,

        VPDPWSSDSZ256rk = 9825,

        VPDPWSSDSZ256rkz = 9826,

        VPDPWSSDSZm = 9827,

        VPDPWSSDSZmb = 9828,

        VPDPWSSDSZmbk = 9829,

        VPDPWSSDSZmbkz = 9830,

        VPDPWSSDSZmk = 9831,

        VPDPWSSDSZmkz = 9832,

        VPDPWSSDSZr = 9833,

        VPDPWSSDSZrk = 9834,

        VPDPWSSDSZrkz = 9835,

        VPDPWSSDSrm = 9836,

        VPDPWSSDSrr = 9837,

        VPDPWSSDYrm = 9838,

        VPDPWSSDYrr = 9839,

        VPDPWSSDZ128m = 9840,

        VPDPWSSDZ128mb = 9841,

        VPDPWSSDZ128mbk = 9842,

        VPDPWSSDZ128mbkz = 9843,

        VPDPWSSDZ128mk = 9844,

        VPDPWSSDZ128mkz = 9845,

        VPDPWSSDZ128r = 9846,

        VPDPWSSDZ128rk = 9847,

        VPDPWSSDZ128rkz = 9848,

        VPDPWSSDZ256m = 9849,

        VPDPWSSDZ256mb = 9850,

        VPDPWSSDZ256mbk = 9851,

        VPDPWSSDZ256mbkz = 9852,

        VPDPWSSDZ256mk = 9853,

        VPDPWSSDZ256mkz = 9854,

        VPDPWSSDZ256r = 9855,

        VPDPWSSDZ256rk = 9856,

        VPDPWSSDZ256rkz = 9857,

        VPDPWSSDZm = 9858,

        VPDPWSSDZmb = 9859,

        VPDPWSSDZmbk = 9860,

        VPDPWSSDZmbkz = 9861,

        VPDPWSSDZmk = 9862,

        VPDPWSSDZmkz = 9863,

        VPDPWSSDZr = 9864,

        VPDPWSSDZrk = 9865,

        VPDPWSSDZrkz = 9866,

        VPDPWSSDrm = 9867,

        VPDPWSSDrr = 9868,

        VPERM2F128rm = 9869,

        VPERM2F128rr = 9870,

        VPERM2I128rm = 9871,

        VPERM2I128rr = 9872,

        VPERMBZ128rm = 9873,

        VPERMBZ128rmk = 9874,

        VPERMBZ128rmkz = 9875,

        VPERMBZ128rr = 9876,

        VPERMBZ128rrk = 9877,

        VPERMBZ128rrkz = 9878,

        VPERMBZ256rm = 9879,

        VPERMBZ256rmk = 9880,

        VPERMBZ256rmkz = 9881,

        VPERMBZ256rr = 9882,

        VPERMBZ256rrk = 9883,

        VPERMBZ256rrkz = 9884,

        VPERMBZrm = 9885,

        VPERMBZrmk = 9886,

        VPERMBZrmkz = 9887,

        VPERMBZrr = 9888,

        VPERMBZrrk = 9889,

        VPERMBZrrkz = 9890,

        VPERMDYrm = 9891,

        VPERMDYrr = 9892,

        VPERMDZ256rm = 9893,

        VPERMDZ256rmb = 9894,

        VPERMDZ256rmbk = 9895,

        VPERMDZ256rmbkz = 9896,

        VPERMDZ256rmk = 9897,

        VPERMDZ256rmkz = 9898,

        VPERMDZ256rr = 9899,

        VPERMDZ256rrk = 9900,

        VPERMDZ256rrkz = 9901,

        VPERMDZrm = 9902,

        VPERMDZrmb = 9903,

        VPERMDZrmbk = 9904,

        VPERMDZrmbkz = 9905,

        VPERMDZrmk = 9906,

        VPERMDZrmkz = 9907,

        VPERMDZrr = 9908,

        VPERMDZrrk = 9909,

        VPERMDZrrkz = 9910,

        VPERMI2B128rm = 9911,

        VPERMI2B128rmk = 9912,

        VPERMI2B128rmkz = 9913,

        VPERMI2B128rr = 9914,

        VPERMI2B128rrk = 9915,

        VPERMI2B128rrkz = 9916,

        VPERMI2B256rm = 9917,

        VPERMI2B256rmk = 9918,

        VPERMI2B256rmkz = 9919,

        VPERMI2B256rr = 9920,

        VPERMI2B256rrk = 9921,

        VPERMI2B256rrkz = 9922,

        VPERMI2Brm = 9923,

        VPERMI2Brmk = 9924,

        VPERMI2Brmkz = 9925,

        VPERMI2Brr = 9926,

        VPERMI2Brrk = 9927,

        VPERMI2Brrkz = 9928,

        VPERMI2D128rm = 9929,

        VPERMI2D128rmb = 9930,

        VPERMI2D128rmbk = 9931,

        VPERMI2D128rmbkz = 9932,

        VPERMI2D128rmk = 9933,

        VPERMI2D128rmkz = 9934,

        VPERMI2D128rr = 9935,

        VPERMI2D128rrk = 9936,

        VPERMI2D128rrkz = 9937,

        VPERMI2D256rm = 9938,

        VPERMI2D256rmb = 9939,

        VPERMI2D256rmbk = 9940,

        VPERMI2D256rmbkz = 9941,

        VPERMI2D256rmk = 9942,

        VPERMI2D256rmkz = 9943,

        VPERMI2D256rr = 9944,

        VPERMI2D256rrk = 9945,

        VPERMI2D256rrkz = 9946,

        VPERMI2Drm = 9947,

        VPERMI2Drmb = 9948,

        VPERMI2Drmbk = 9949,

        VPERMI2Drmbkz = 9950,

        VPERMI2Drmk = 9951,

        VPERMI2Drmkz = 9952,

        VPERMI2Drr = 9953,

        VPERMI2Drrk = 9954,

        VPERMI2Drrkz = 9955,

        VPERMI2PD128rm = 9956,

        VPERMI2PD128rmb = 9957,

        VPERMI2PD128rmbk = 9958,

        VPERMI2PD128rmbkz = 9959,

        VPERMI2PD128rmk = 9960,

        VPERMI2PD128rmkz = 9961,

        VPERMI2PD128rr = 9962,

        VPERMI2PD128rrk = 9963,

        VPERMI2PD128rrkz = 9964,

        VPERMI2PD256rm = 9965,

        VPERMI2PD256rmb = 9966,

        VPERMI2PD256rmbk = 9967,

        VPERMI2PD256rmbkz = 9968,

        VPERMI2PD256rmk = 9969,

        VPERMI2PD256rmkz = 9970,

        VPERMI2PD256rr = 9971,

        VPERMI2PD256rrk = 9972,

        VPERMI2PD256rrkz = 9973,

        VPERMI2PDrm = 9974,

        VPERMI2PDrmb = 9975,

        VPERMI2PDrmbk = 9976,

        VPERMI2PDrmbkz = 9977,

        VPERMI2PDrmk = 9978,

        VPERMI2PDrmkz = 9979,

        VPERMI2PDrr = 9980,

        VPERMI2PDrrk = 9981,

        VPERMI2PDrrkz = 9982,

        VPERMI2PS128rm = 9983,

        VPERMI2PS128rmb = 9984,

        VPERMI2PS128rmbk = 9985,

        VPERMI2PS128rmbkz = 9986,

        VPERMI2PS128rmk = 9987,

        VPERMI2PS128rmkz = 9988,

        VPERMI2PS128rr = 9989,

        VPERMI2PS128rrk = 9990,

        VPERMI2PS128rrkz = 9991,

        VPERMI2PS256rm = 9992,

        VPERMI2PS256rmb = 9993,

        VPERMI2PS256rmbk = 9994,

        VPERMI2PS256rmbkz = 9995,

        VPERMI2PS256rmk = 9996,

        VPERMI2PS256rmkz = 9997,

        VPERMI2PS256rr = 9998,

        VPERMI2PS256rrk = 9999,

        VPERMI2PS256rrkz = 10000,

        VPERMI2PSrm = 10001,

        VPERMI2PSrmb = 10002,

        VPERMI2PSrmbk = 10003,

        VPERMI2PSrmbkz = 10004,

        VPERMI2PSrmk = 10005,

        VPERMI2PSrmkz = 10006,

        VPERMI2PSrr = 10007,

        VPERMI2PSrrk = 10008,

        VPERMI2PSrrkz = 10009,

        VPERMI2Q128rm = 10010,

        VPERMI2Q128rmb = 10011,

        VPERMI2Q128rmbk = 10012,

        VPERMI2Q128rmbkz = 10013,

        VPERMI2Q128rmk = 10014,

        VPERMI2Q128rmkz = 10015,

        VPERMI2Q128rr = 10016,

        VPERMI2Q128rrk = 10017,

        VPERMI2Q128rrkz = 10018,

        VPERMI2Q256rm = 10019,

        VPERMI2Q256rmb = 10020,

        VPERMI2Q256rmbk = 10021,

        VPERMI2Q256rmbkz = 10022,

        VPERMI2Q256rmk = 10023,

        VPERMI2Q256rmkz = 10024,

        VPERMI2Q256rr = 10025,

        VPERMI2Q256rrk = 10026,

        VPERMI2Q256rrkz = 10027,

        VPERMI2Qrm = 10028,

        VPERMI2Qrmb = 10029,

        VPERMI2Qrmbk = 10030,

        VPERMI2Qrmbkz = 10031,

        VPERMI2Qrmk = 10032,

        VPERMI2Qrmkz = 10033,

        VPERMI2Qrr = 10034,

        VPERMI2Qrrk = 10035,

        VPERMI2Qrrkz = 10036,

        VPERMI2W128rm = 10037,

        VPERMI2W128rmk = 10038,

        VPERMI2W128rmkz = 10039,

        VPERMI2W128rr = 10040,

        VPERMI2W128rrk = 10041,

        VPERMI2W128rrkz = 10042,

        VPERMI2W256rm = 10043,

        VPERMI2W256rmk = 10044,

        VPERMI2W256rmkz = 10045,

        VPERMI2W256rr = 10046,

        VPERMI2W256rrk = 10047,

        VPERMI2W256rrkz = 10048,

        VPERMI2Wrm = 10049,

        VPERMI2Wrmk = 10050,

        VPERMI2Wrmkz = 10051,

        VPERMI2Wrr = 10052,

        VPERMI2Wrrk = 10053,

        VPERMI2Wrrkz = 10054,

        VPERMIL2PDYmr = 10055,

        VPERMIL2PDYrm = 10056,

        VPERMIL2PDYrr = 10057,

        VPERMIL2PDYrr_REV = 10058,

        VPERMIL2PDmr = 10059,

        VPERMIL2PDrm = 10060,

        VPERMIL2PDrr = 10061,

        VPERMIL2PDrr_REV = 10062,

        VPERMIL2PSYmr = 10063,

        VPERMIL2PSYrm = 10064,

        VPERMIL2PSYrr = 10065,

        VPERMIL2PSYrr_REV = 10066,

        VPERMIL2PSmr = 10067,

        VPERMIL2PSrm = 10068,

        VPERMIL2PSrr = 10069,

        VPERMIL2PSrr_REV = 10070,

        VPERMILPDYmi = 10071,

        VPERMILPDYri = 10072,

        VPERMILPDYrm = 10073,

        VPERMILPDYrr = 10074,

        VPERMILPDZ128mbi = 10075,

        VPERMILPDZ128mbik = 10076,

        VPERMILPDZ128mbikz = 10077,

        VPERMILPDZ128mi = 10078,

        VPERMILPDZ128mik = 10079,

        VPERMILPDZ128mikz = 10080,

        VPERMILPDZ128ri = 10081,

        VPERMILPDZ128rik = 10082,

        VPERMILPDZ128rikz = 10083,

        VPERMILPDZ128rm = 10084,

        VPERMILPDZ128rmb = 10085,

        VPERMILPDZ128rmbk = 10086,

        VPERMILPDZ128rmbkz = 10087,

        VPERMILPDZ128rmk = 10088,

        VPERMILPDZ128rmkz = 10089,

        VPERMILPDZ128rr = 10090,

        VPERMILPDZ128rrk = 10091,

        VPERMILPDZ128rrkz = 10092,

        VPERMILPDZ256mbi = 10093,

        VPERMILPDZ256mbik = 10094,

        VPERMILPDZ256mbikz = 10095,

        VPERMILPDZ256mi = 10096,

        VPERMILPDZ256mik = 10097,

        VPERMILPDZ256mikz = 10098,

        VPERMILPDZ256ri = 10099,

        VPERMILPDZ256rik = 10100,

        VPERMILPDZ256rikz = 10101,

        VPERMILPDZ256rm = 10102,

        VPERMILPDZ256rmb = 10103,

        VPERMILPDZ256rmbk = 10104,

        VPERMILPDZ256rmbkz = 10105,

        VPERMILPDZ256rmk = 10106,

        VPERMILPDZ256rmkz = 10107,

        VPERMILPDZ256rr = 10108,

        VPERMILPDZ256rrk = 10109,

        VPERMILPDZ256rrkz = 10110,

        VPERMILPDZmbi = 10111,

        VPERMILPDZmbik = 10112,

        VPERMILPDZmbikz = 10113,

        VPERMILPDZmi = 10114,

        VPERMILPDZmik = 10115,

        VPERMILPDZmikz = 10116,

        VPERMILPDZri = 10117,

        VPERMILPDZrik = 10118,

        VPERMILPDZrikz = 10119,

        VPERMILPDZrm = 10120,

        VPERMILPDZrmb = 10121,

        VPERMILPDZrmbk = 10122,

        VPERMILPDZrmbkz = 10123,

        VPERMILPDZrmk = 10124,

        VPERMILPDZrmkz = 10125,

        VPERMILPDZrr = 10126,

        VPERMILPDZrrk = 10127,

        VPERMILPDZrrkz = 10128,

        VPERMILPDmi = 10129,

        VPERMILPDri = 10130,

        VPERMILPDrm = 10131,

        VPERMILPDrr = 10132,

        VPERMILPSYmi = 10133,

        VPERMILPSYri = 10134,

        VPERMILPSYrm = 10135,

        VPERMILPSYrr = 10136,

        VPERMILPSZ128mbi = 10137,

        VPERMILPSZ128mbik = 10138,

        VPERMILPSZ128mbikz = 10139,

        VPERMILPSZ128mi = 10140,

        VPERMILPSZ128mik = 10141,

        VPERMILPSZ128mikz = 10142,

        VPERMILPSZ128ri = 10143,

        VPERMILPSZ128rik = 10144,

        VPERMILPSZ128rikz = 10145,

        VPERMILPSZ128rm = 10146,

        VPERMILPSZ128rmb = 10147,

        VPERMILPSZ128rmbk = 10148,

        VPERMILPSZ128rmbkz = 10149,

        VPERMILPSZ128rmk = 10150,

        VPERMILPSZ128rmkz = 10151,

        VPERMILPSZ128rr = 10152,

        VPERMILPSZ128rrk = 10153,

        VPERMILPSZ128rrkz = 10154,

        VPERMILPSZ256mbi = 10155,

        VPERMILPSZ256mbik = 10156,

        VPERMILPSZ256mbikz = 10157,

        VPERMILPSZ256mi = 10158,

        VPERMILPSZ256mik = 10159,

        VPERMILPSZ256mikz = 10160,

        VPERMILPSZ256ri = 10161,

        VPERMILPSZ256rik = 10162,

        VPERMILPSZ256rikz = 10163,

        VPERMILPSZ256rm = 10164,

        VPERMILPSZ256rmb = 10165,

        VPERMILPSZ256rmbk = 10166,

        VPERMILPSZ256rmbkz = 10167,

        VPERMILPSZ256rmk = 10168,

        VPERMILPSZ256rmkz = 10169,

        VPERMILPSZ256rr = 10170,

        VPERMILPSZ256rrk = 10171,

        VPERMILPSZ256rrkz = 10172,

        VPERMILPSZmbi = 10173,

        VPERMILPSZmbik = 10174,

        VPERMILPSZmbikz = 10175,

        VPERMILPSZmi = 10176,

        VPERMILPSZmik = 10177,

        VPERMILPSZmikz = 10178,

        VPERMILPSZri = 10179,

        VPERMILPSZrik = 10180,

        VPERMILPSZrikz = 10181,

        VPERMILPSZrm = 10182,

        VPERMILPSZrmb = 10183,

        VPERMILPSZrmbk = 10184,

        VPERMILPSZrmbkz = 10185,

        VPERMILPSZrmk = 10186,

        VPERMILPSZrmkz = 10187,

        VPERMILPSZrr = 10188,

        VPERMILPSZrrk = 10189,

        VPERMILPSZrrkz = 10190,

        VPERMILPSmi = 10191,

        VPERMILPSri = 10192,

        VPERMILPSrm = 10193,

        VPERMILPSrr = 10194,

        VPERMPDYmi = 10195,

        VPERMPDYri = 10196,

        VPERMPDZ256mbi = 10197,

        VPERMPDZ256mbik = 10198,

        VPERMPDZ256mbikz = 10199,

        VPERMPDZ256mi = 10200,

        VPERMPDZ256mik = 10201,

        VPERMPDZ256mikz = 10202,

        VPERMPDZ256ri = 10203,

        VPERMPDZ256rik = 10204,

        VPERMPDZ256rikz = 10205,

        VPERMPDZ256rm = 10206,

        VPERMPDZ256rmb = 10207,

        VPERMPDZ256rmbk = 10208,

        VPERMPDZ256rmbkz = 10209,

        VPERMPDZ256rmk = 10210,

        VPERMPDZ256rmkz = 10211,

        VPERMPDZ256rr = 10212,

        VPERMPDZ256rrk = 10213,

        VPERMPDZ256rrkz = 10214,

        VPERMPDZmbi = 10215,

        VPERMPDZmbik = 10216,

        VPERMPDZmbikz = 10217,

        VPERMPDZmi = 10218,

        VPERMPDZmik = 10219,

        VPERMPDZmikz = 10220,

        VPERMPDZri = 10221,

        VPERMPDZrik = 10222,

        VPERMPDZrikz = 10223,

        VPERMPDZrm = 10224,

        VPERMPDZrmb = 10225,

        VPERMPDZrmbk = 10226,

        VPERMPDZrmbkz = 10227,

        VPERMPDZrmk = 10228,

        VPERMPDZrmkz = 10229,

        VPERMPDZrr = 10230,

        VPERMPDZrrk = 10231,

        VPERMPDZrrkz = 10232,

        VPERMPSYrm = 10233,

        VPERMPSYrr = 10234,

        VPERMPSZ256rm = 10235,

        VPERMPSZ256rmb = 10236,

        VPERMPSZ256rmbk = 10237,

        VPERMPSZ256rmbkz = 10238,

        VPERMPSZ256rmk = 10239,

        VPERMPSZ256rmkz = 10240,

        VPERMPSZ256rr = 10241,

        VPERMPSZ256rrk = 10242,

        VPERMPSZ256rrkz = 10243,

        VPERMPSZrm = 10244,

        VPERMPSZrmb = 10245,

        VPERMPSZrmbk = 10246,

        VPERMPSZrmbkz = 10247,

        VPERMPSZrmk = 10248,

        VPERMPSZrmkz = 10249,

        VPERMPSZrr = 10250,

        VPERMPSZrrk = 10251,

        VPERMPSZrrkz = 10252,

        VPERMQYmi = 10253,

        VPERMQYri = 10254,

        VPERMQZ256mbi = 10255,

        VPERMQZ256mbik = 10256,

        VPERMQZ256mbikz = 10257,

        VPERMQZ256mi = 10258,

        VPERMQZ256mik = 10259,

        VPERMQZ256mikz = 10260,

        VPERMQZ256ri = 10261,

        VPERMQZ256rik = 10262,

        VPERMQZ256rikz = 10263,

        VPERMQZ256rm = 10264,

        VPERMQZ256rmb = 10265,

        VPERMQZ256rmbk = 10266,

        VPERMQZ256rmbkz = 10267,

        VPERMQZ256rmk = 10268,

        VPERMQZ256rmkz = 10269,

        VPERMQZ256rr = 10270,

        VPERMQZ256rrk = 10271,

        VPERMQZ256rrkz = 10272,

        VPERMQZmbi = 10273,

        VPERMQZmbik = 10274,

        VPERMQZmbikz = 10275,

        VPERMQZmi = 10276,

        VPERMQZmik = 10277,

        VPERMQZmikz = 10278,

        VPERMQZri = 10279,

        VPERMQZrik = 10280,

        VPERMQZrikz = 10281,

        VPERMQZrm = 10282,

        VPERMQZrmb = 10283,

        VPERMQZrmbk = 10284,

        VPERMQZrmbkz = 10285,

        VPERMQZrmk = 10286,

        VPERMQZrmkz = 10287,

        VPERMQZrr = 10288,

        VPERMQZrrk = 10289,

        VPERMQZrrkz = 10290,

        VPERMT2B128rm = 10291,

        VPERMT2B128rmk = 10292,

        VPERMT2B128rmkz = 10293,

        VPERMT2B128rr = 10294,

        VPERMT2B128rrk = 10295,

        VPERMT2B128rrkz = 10296,

        VPERMT2B256rm = 10297,

        VPERMT2B256rmk = 10298,

        VPERMT2B256rmkz = 10299,

        VPERMT2B256rr = 10300,

        VPERMT2B256rrk = 10301,

        VPERMT2B256rrkz = 10302,

        VPERMT2Brm = 10303,

        VPERMT2Brmk = 10304,

        VPERMT2Brmkz = 10305,

        VPERMT2Brr = 10306,

        VPERMT2Brrk = 10307,

        VPERMT2Brrkz = 10308,

        VPERMT2D128rm = 10309,

        VPERMT2D128rmb = 10310,

        VPERMT2D128rmbk = 10311,

        VPERMT2D128rmbkz = 10312,

        VPERMT2D128rmk = 10313,

        VPERMT2D128rmkz = 10314,

        VPERMT2D128rr = 10315,

        VPERMT2D128rrk = 10316,

        VPERMT2D128rrkz = 10317,

        VPERMT2D256rm = 10318,

        VPERMT2D256rmb = 10319,

        VPERMT2D256rmbk = 10320,

        VPERMT2D256rmbkz = 10321,

        VPERMT2D256rmk = 10322,

        VPERMT2D256rmkz = 10323,

        VPERMT2D256rr = 10324,

        VPERMT2D256rrk = 10325,

        VPERMT2D256rrkz = 10326,

        VPERMT2Drm = 10327,

        VPERMT2Drmb = 10328,

        VPERMT2Drmbk = 10329,

        VPERMT2Drmbkz = 10330,

        VPERMT2Drmk = 10331,

        VPERMT2Drmkz = 10332,

        VPERMT2Drr = 10333,

        VPERMT2Drrk = 10334,

        VPERMT2Drrkz = 10335,

        VPERMT2PD128rm = 10336,

        VPERMT2PD128rmb = 10337,

        VPERMT2PD128rmbk = 10338,

        VPERMT2PD128rmbkz = 10339,

        VPERMT2PD128rmk = 10340,

        VPERMT2PD128rmkz = 10341,

        VPERMT2PD128rr = 10342,

        VPERMT2PD128rrk = 10343,

        VPERMT2PD128rrkz = 10344,

        VPERMT2PD256rm = 10345,

        VPERMT2PD256rmb = 10346,

        VPERMT2PD256rmbk = 10347,

        VPERMT2PD256rmbkz = 10348,

        VPERMT2PD256rmk = 10349,

        VPERMT2PD256rmkz = 10350,

        VPERMT2PD256rr = 10351,

        VPERMT2PD256rrk = 10352,

        VPERMT2PD256rrkz = 10353,

        VPERMT2PDrm = 10354,

        VPERMT2PDrmb = 10355,

        VPERMT2PDrmbk = 10356,

        VPERMT2PDrmbkz = 10357,

        VPERMT2PDrmk = 10358,

        VPERMT2PDrmkz = 10359,

        VPERMT2PDrr = 10360,

        VPERMT2PDrrk = 10361,

        VPERMT2PDrrkz = 10362,

        VPERMT2PS128rm = 10363,

        VPERMT2PS128rmb = 10364,

        VPERMT2PS128rmbk = 10365,

        VPERMT2PS128rmbkz = 10366,

        VPERMT2PS128rmk = 10367,

        VPERMT2PS128rmkz = 10368,

        VPERMT2PS128rr = 10369,

        VPERMT2PS128rrk = 10370,

        VPERMT2PS128rrkz = 10371,

        VPERMT2PS256rm = 10372,

        VPERMT2PS256rmb = 10373,

        VPERMT2PS256rmbk = 10374,

        VPERMT2PS256rmbkz = 10375,

        VPERMT2PS256rmk = 10376,

        VPERMT2PS256rmkz = 10377,

        VPERMT2PS256rr = 10378,

        VPERMT2PS256rrk = 10379,

        VPERMT2PS256rrkz = 10380,

        VPERMT2PSrm = 10381,

        VPERMT2PSrmb = 10382,

        VPERMT2PSrmbk = 10383,

        VPERMT2PSrmbkz = 10384,

        VPERMT2PSrmk = 10385,

        VPERMT2PSrmkz = 10386,

        VPERMT2PSrr = 10387,

        VPERMT2PSrrk = 10388,

        VPERMT2PSrrkz = 10389,

        VPERMT2Q128rm = 10390,

        VPERMT2Q128rmb = 10391,

        VPERMT2Q128rmbk = 10392,

        VPERMT2Q128rmbkz = 10393,

        VPERMT2Q128rmk = 10394,

        VPERMT2Q128rmkz = 10395,

        VPERMT2Q128rr = 10396,

        VPERMT2Q128rrk = 10397,

        VPERMT2Q128rrkz = 10398,

        VPERMT2Q256rm = 10399,

        VPERMT2Q256rmb = 10400,

        VPERMT2Q256rmbk = 10401,

        VPERMT2Q256rmbkz = 10402,

        VPERMT2Q256rmk = 10403,

        VPERMT2Q256rmkz = 10404,

        VPERMT2Q256rr = 10405,

        VPERMT2Q256rrk = 10406,

        VPERMT2Q256rrkz = 10407,

        VPERMT2Qrm = 10408,

        VPERMT2Qrmb = 10409,

        VPERMT2Qrmbk = 10410,

        VPERMT2Qrmbkz = 10411,

        VPERMT2Qrmk = 10412,

        VPERMT2Qrmkz = 10413,

        VPERMT2Qrr = 10414,

        VPERMT2Qrrk = 10415,

        VPERMT2Qrrkz = 10416,

        VPERMT2W128rm = 10417,

        VPERMT2W128rmk = 10418,

        VPERMT2W128rmkz = 10419,

        VPERMT2W128rr = 10420,

        VPERMT2W128rrk = 10421,

        VPERMT2W128rrkz = 10422,

        VPERMT2W256rm = 10423,

        VPERMT2W256rmk = 10424,

        VPERMT2W256rmkz = 10425,

        VPERMT2W256rr = 10426,

        VPERMT2W256rrk = 10427,

        VPERMT2W256rrkz = 10428,

        VPERMT2Wrm = 10429,

        VPERMT2Wrmk = 10430,

        VPERMT2Wrmkz = 10431,

        VPERMT2Wrr = 10432,

        VPERMT2Wrrk = 10433,

        VPERMT2Wrrkz = 10434,

        VPERMWZ128rm = 10435,

        VPERMWZ128rmk = 10436,

        VPERMWZ128rmkz = 10437,

        VPERMWZ128rr = 10438,

        VPERMWZ128rrk = 10439,

        VPERMWZ128rrkz = 10440,

        VPERMWZ256rm = 10441,

        VPERMWZ256rmk = 10442,

        VPERMWZ256rmkz = 10443,

        VPERMWZ256rr = 10444,

        VPERMWZ256rrk = 10445,

        VPERMWZ256rrkz = 10446,

        VPERMWZrm = 10447,

        VPERMWZrmk = 10448,

        VPERMWZrmkz = 10449,

        VPERMWZrr = 10450,

        VPERMWZrrk = 10451,

        VPERMWZrrkz = 10452,

        VPEXPANDBZ128rm = 10453,

        VPEXPANDBZ128rmk = 10454,

        VPEXPANDBZ128rmkz = 10455,

        VPEXPANDBZ128rr = 10456,

        VPEXPANDBZ128rrk = 10457,

        VPEXPANDBZ128rrkz = 10458,

        VPEXPANDBZ256rm = 10459,

        VPEXPANDBZ256rmk = 10460,

        VPEXPANDBZ256rmkz = 10461,

        VPEXPANDBZ256rr = 10462,

        VPEXPANDBZ256rrk = 10463,

        VPEXPANDBZ256rrkz = 10464,

        VPEXPANDBZrm = 10465,

        VPEXPANDBZrmk = 10466,

        VPEXPANDBZrmkz = 10467,

        VPEXPANDBZrr = 10468,

        VPEXPANDBZrrk = 10469,

        VPEXPANDBZrrkz = 10470,

        VPEXPANDDZ128rm = 10471,

        VPEXPANDDZ128rmk = 10472,

        VPEXPANDDZ128rmkz = 10473,

        VPEXPANDDZ128rr = 10474,

        VPEXPANDDZ128rrk = 10475,

        VPEXPANDDZ128rrkz = 10476,

        VPEXPANDDZ256rm = 10477,

        VPEXPANDDZ256rmk = 10478,

        VPEXPANDDZ256rmkz = 10479,

        VPEXPANDDZ256rr = 10480,

        VPEXPANDDZ256rrk = 10481,

        VPEXPANDDZ256rrkz = 10482,

        VPEXPANDDZrm = 10483,

        VPEXPANDDZrmk = 10484,

        VPEXPANDDZrmkz = 10485,

        VPEXPANDDZrr = 10486,

        VPEXPANDDZrrk = 10487,

        VPEXPANDDZrrkz = 10488,

        VPEXPANDQZ128rm = 10489,

        VPEXPANDQZ128rmk = 10490,

        VPEXPANDQZ128rmkz = 10491,

        VPEXPANDQZ128rr = 10492,

        VPEXPANDQZ128rrk = 10493,

        VPEXPANDQZ128rrkz = 10494,

        VPEXPANDQZ256rm = 10495,

        VPEXPANDQZ256rmk = 10496,

        VPEXPANDQZ256rmkz = 10497,

        VPEXPANDQZ256rr = 10498,

        VPEXPANDQZ256rrk = 10499,

        VPEXPANDQZ256rrkz = 10500,

        VPEXPANDQZrm = 10501,

        VPEXPANDQZrmk = 10502,

        VPEXPANDQZrmkz = 10503,

        VPEXPANDQZrr = 10504,

        VPEXPANDQZrrk = 10505,

        VPEXPANDQZrrkz = 10506,

        VPEXPANDWZ128rm = 10507,

        VPEXPANDWZ128rmk = 10508,

        VPEXPANDWZ128rmkz = 10509,

        VPEXPANDWZ128rr = 10510,

        VPEXPANDWZ128rrk = 10511,

        VPEXPANDWZ128rrkz = 10512,

        VPEXPANDWZ256rm = 10513,

        VPEXPANDWZ256rmk = 10514,

        VPEXPANDWZ256rmkz = 10515,

        VPEXPANDWZ256rr = 10516,

        VPEXPANDWZ256rrk = 10517,

        VPEXPANDWZ256rrkz = 10518,

        VPEXPANDWZrm = 10519,

        VPEXPANDWZrmk = 10520,

        VPEXPANDWZrmkz = 10521,

        VPEXPANDWZrr = 10522,

        VPEXPANDWZrrk = 10523,

        VPEXPANDWZrrkz = 10524,

        VPEXTRBZmr = 10525,

        VPEXTRBZrr = 10526,

        VPEXTRBmr = 10527,

        VPEXTRBrr = 10528,

        VPEXTRDZmr = 10529,

        VPEXTRDZrr = 10530,

        VPEXTRDmr = 10531,

        VPEXTRDrr = 10532,

        VPEXTRQZmr = 10533,

        VPEXTRQZrr = 10534,

        VPEXTRQmr = 10535,

        VPEXTRQrr = 10536,

        VPEXTRWZmr = 10537,

        VPEXTRWZrr = 10538,

        VPEXTRWZrr_REV = 10539,

        VPEXTRWmr = 10540,

        VPEXTRWrr = 10541,

        VPEXTRWrr_REV = 10542,

        VPGATHERDDYrm = 10543,

        VPGATHERDDZ128rm = 10544,

        VPGATHERDDZ256rm = 10545,

        VPGATHERDDZrm = 10546,

        VPGATHERDDrm = 10547,

        VPGATHERDQYrm = 10548,

        VPGATHERDQZ128rm = 10549,

        VPGATHERDQZ256rm = 10550,

        VPGATHERDQZrm = 10551,

        VPGATHERDQrm = 10552,

        VPGATHERQDYrm = 10553,

        VPGATHERQDZ128rm = 10554,

        VPGATHERQDZ256rm = 10555,

        VPGATHERQDZrm = 10556,

        VPGATHERQDrm = 10557,

        VPGATHERQQYrm = 10558,

        VPGATHERQQZ128rm = 10559,

        VPGATHERQQZ256rm = 10560,

        VPGATHERQQZrm = 10561,

        VPGATHERQQrm = 10562,

        VPHADDBDrm = 10563,

        VPHADDBDrr = 10564,

        VPHADDBQrm = 10565,

        VPHADDBQrr = 10566,

        VPHADDBWrm = 10567,

        VPHADDBWrr = 10568,

        VPHADDDQrm = 10569,

        VPHADDDQrr = 10570,

        VPHADDDYrm = 10571,

        VPHADDDYrr = 10572,

        VPHADDDrm = 10573,

        VPHADDDrr = 10574,

        VPHADDSWYrm = 10575,

        VPHADDSWYrr = 10576,

        VPHADDSWrm = 10577,

        VPHADDSWrr = 10578,

        VPHADDUBDrm = 10579,

        VPHADDUBDrr = 10580,

        VPHADDUBQrm = 10581,

        VPHADDUBQrr = 10582,

        VPHADDUBWrm = 10583,

        VPHADDUBWrr = 10584,

        VPHADDUDQrm = 10585,

        VPHADDUDQrr = 10586,

        VPHADDUWDrm = 10587,

        VPHADDUWDrr = 10588,

        VPHADDUWQrm = 10589,

        VPHADDUWQrr = 10590,

        VPHADDWDrm = 10591,

        VPHADDWDrr = 10592,

        VPHADDWQrm = 10593,

        VPHADDWQrr = 10594,

        VPHADDWYrm = 10595,

        VPHADDWYrr = 10596,

        VPHADDWrm = 10597,

        VPHADDWrr = 10598,

        VPHMINPOSUWrm = 10599,

        VPHMINPOSUWrr = 10600,

        VPHSUBBWrm = 10601,

        VPHSUBBWrr = 10602,

        VPHSUBDQrm = 10603,

        VPHSUBDQrr = 10604,

        VPHSUBDYrm = 10605,

        VPHSUBDYrr = 10606,

        VPHSUBDrm = 10607,

        VPHSUBDrr = 10608,

        VPHSUBSWYrm = 10609,

        VPHSUBSWYrr = 10610,

        VPHSUBSWrm = 10611,

        VPHSUBSWrr = 10612,

        VPHSUBWDrm = 10613,

        VPHSUBWDrr = 10614,

        VPHSUBWYrm = 10615,

        VPHSUBWYrr = 10616,

        VPHSUBWrm = 10617,

        VPHSUBWrr = 10618,

        VPINSRBZrm = 10619,

        VPINSRBZrr = 10620,

        VPINSRBrm = 10621,

        VPINSRBrr = 10622,

        VPINSRDZrm = 10623,

        VPINSRDZrr = 10624,

        VPINSRDrm = 10625,

        VPINSRDrr = 10626,

        VPINSRQZrm = 10627,

        VPINSRQZrr = 10628,

        VPINSRQrm = 10629,

        VPINSRQrr = 10630,

        VPINSRWZrm = 10631,

        VPINSRWZrr = 10632,

        VPINSRWrm = 10633,

        VPINSRWrr = 10634,

        VPLZCNTDZ128rm = 10635,

        VPLZCNTDZ128rmb = 10636,

        VPLZCNTDZ128rmbk = 10637,

        VPLZCNTDZ128rmbkz = 10638,

        VPLZCNTDZ128rmk = 10639,

        VPLZCNTDZ128rmkz = 10640,

        VPLZCNTDZ128rr = 10641,

        VPLZCNTDZ128rrk = 10642,

        VPLZCNTDZ128rrkz = 10643,

        VPLZCNTDZ256rm = 10644,

        VPLZCNTDZ256rmb = 10645,

        VPLZCNTDZ256rmbk = 10646,

        VPLZCNTDZ256rmbkz = 10647,

        VPLZCNTDZ256rmk = 10648,

        VPLZCNTDZ256rmkz = 10649,

        VPLZCNTDZ256rr = 10650,

        VPLZCNTDZ256rrk = 10651,

        VPLZCNTDZ256rrkz = 10652,

        VPLZCNTDZrm = 10653,

        VPLZCNTDZrmb = 10654,

        VPLZCNTDZrmbk = 10655,

        VPLZCNTDZrmbkz = 10656,

        VPLZCNTDZrmk = 10657,

        VPLZCNTDZrmkz = 10658,

        VPLZCNTDZrr = 10659,

        VPLZCNTDZrrk = 10660,

        VPLZCNTDZrrkz = 10661,

        VPLZCNTQZ128rm = 10662,

        VPLZCNTQZ128rmb = 10663,

        VPLZCNTQZ128rmbk = 10664,

        VPLZCNTQZ128rmbkz = 10665,

        VPLZCNTQZ128rmk = 10666,

        VPLZCNTQZ128rmkz = 10667,

        VPLZCNTQZ128rr = 10668,

        VPLZCNTQZ128rrk = 10669,

        VPLZCNTQZ128rrkz = 10670,

        VPLZCNTQZ256rm = 10671,

        VPLZCNTQZ256rmb = 10672,

        VPLZCNTQZ256rmbk = 10673,

        VPLZCNTQZ256rmbkz = 10674,

        VPLZCNTQZ256rmk = 10675,

        VPLZCNTQZ256rmkz = 10676,

        VPLZCNTQZ256rr = 10677,

        VPLZCNTQZ256rrk = 10678,

        VPLZCNTQZ256rrkz = 10679,

        VPLZCNTQZrm = 10680,

        VPLZCNTQZrmb = 10681,

        VPLZCNTQZrmbk = 10682,

        VPLZCNTQZrmbkz = 10683,

        VPLZCNTQZrmk = 10684,

        VPLZCNTQZrmkz = 10685,

        VPLZCNTQZrr = 10686,

        VPLZCNTQZrrk = 10687,

        VPLZCNTQZrrkz = 10688,

        VPMACSDDrm = 10689,

        VPMACSDDrr = 10690,

        VPMACSDQHrm = 10691,

        VPMACSDQHrr = 10692,

        VPMACSDQLrm = 10693,

        VPMACSDQLrr = 10694,

        VPMACSSDDrm = 10695,

        VPMACSSDDrr = 10696,

        VPMACSSDQHrm = 10697,

        VPMACSSDQHrr = 10698,

        VPMACSSDQLrm = 10699,

        VPMACSSDQLrr = 10700,

        VPMACSSWDrm = 10701,

        VPMACSSWDrr = 10702,

        VPMACSSWWrm = 10703,

        VPMACSSWWrr = 10704,

        VPMACSWDrm = 10705,

        VPMACSWDrr = 10706,

        VPMACSWWrm = 10707,

        VPMACSWWrr = 10708,

        VPMADCSSWDrm = 10709,

        VPMADCSSWDrr = 10710,

        VPMADCSWDrm = 10711,

        VPMADCSWDrr = 10712,

        VPMADD52HUQZ128m = 10713,

        VPMADD52HUQZ128mb = 10714,

        VPMADD52HUQZ128mbk = 10715,

        VPMADD52HUQZ128mbkz = 10716,

        VPMADD52HUQZ128mk = 10717,

        VPMADD52HUQZ128mkz = 10718,

        VPMADD52HUQZ128r = 10719,

        VPMADD52HUQZ128rk = 10720,

        VPMADD52HUQZ128rkz = 10721,

        VPMADD52HUQZ256m = 10722,

        VPMADD52HUQZ256mb = 10723,

        VPMADD52HUQZ256mbk = 10724,

        VPMADD52HUQZ256mbkz = 10725,

        VPMADD52HUQZ256mk = 10726,

        VPMADD52HUQZ256mkz = 10727,

        VPMADD52HUQZ256r = 10728,

        VPMADD52HUQZ256rk = 10729,

        VPMADD52HUQZ256rkz = 10730,

        VPMADD52HUQZm = 10731,

        VPMADD52HUQZmb = 10732,

        VPMADD52HUQZmbk = 10733,

        VPMADD52HUQZmbkz = 10734,

        VPMADD52HUQZmk = 10735,

        VPMADD52HUQZmkz = 10736,

        VPMADD52HUQZr = 10737,

        VPMADD52HUQZrk = 10738,

        VPMADD52HUQZrkz = 10739,

        VPMADD52LUQZ128m = 10740,

        VPMADD52LUQZ128mb = 10741,

        VPMADD52LUQZ128mbk = 10742,

        VPMADD52LUQZ128mbkz = 10743,

        VPMADD52LUQZ128mk = 10744,

        VPMADD52LUQZ128mkz = 10745,

        VPMADD52LUQZ128r = 10746,

        VPMADD52LUQZ128rk = 10747,

        VPMADD52LUQZ128rkz = 10748,

        VPMADD52LUQZ256m = 10749,

        VPMADD52LUQZ256mb = 10750,

        VPMADD52LUQZ256mbk = 10751,

        VPMADD52LUQZ256mbkz = 10752,

        VPMADD52LUQZ256mk = 10753,

        VPMADD52LUQZ256mkz = 10754,

        VPMADD52LUQZ256r = 10755,

        VPMADD52LUQZ256rk = 10756,

        VPMADD52LUQZ256rkz = 10757,

        VPMADD52LUQZm = 10758,

        VPMADD52LUQZmb = 10759,

        VPMADD52LUQZmbk = 10760,

        VPMADD52LUQZmbkz = 10761,

        VPMADD52LUQZmk = 10762,

        VPMADD52LUQZmkz = 10763,

        VPMADD52LUQZr = 10764,

        VPMADD52LUQZrk = 10765,

        VPMADD52LUQZrkz = 10766,

        VPMADDUBSWYrm = 10767,

        VPMADDUBSWYrr = 10768,

        VPMADDUBSWZ128rm = 10769,

        VPMADDUBSWZ128rmk = 10770,

        VPMADDUBSWZ128rmkz = 10771,

        VPMADDUBSWZ128rr = 10772,

        VPMADDUBSWZ128rrk = 10773,

        VPMADDUBSWZ128rrkz = 10774,

        VPMADDUBSWZ256rm = 10775,

        VPMADDUBSWZ256rmk = 10776,

        VPMADDUBSWZ256rmkz = 10777,

        VPMADDUBSWZ256rr = 10778,

        VPMADDUBSWZ256rrk = 10779,

        VPMADDUBSWZ256rrkz = 10780,

        VPMADDUBSWZrm = 10781,

        VPMADDUBSWZrmk = 10782,

        VPMADDUBSWZrmkz = 10783,

        VPMADDUBSWZrr = 10784,

        VPMADDUBSWZrrk = 10785,

        VPMADDUBSWZrrkz = 10786,

        VPMADDUBSWrm = 10787,

        VPMADDUBSWrr = 10788,

        VPMADDWDYrm = 10789,

        VPMADDWDYrr = 10790,

        VPMADDWDZ128rm = 10791,

        VPMADDWDZ128rmk = 10792,

        VPMADDWDZ128rmkz = 10793,

        VPMADDWDZ128rr = 10794,

        VPMADDWDZ128rrk = 10795,

        VPMADDWDZ128rrkz = 10796,

        VPMADDWDZ256rm = 10797,

        VPMADDWDZ256rmk = 10798,

        VPMADDWDZ256rmkz = 10799,

        VPMADDWDZ256rr = 10800,

        VPMADDWDZ256rrk = 10801,

        VPMADDWDZ256rrkz = 10802,

        VPMADDWDZrm = 10803,

        VPMADDWDZrmk = 10804,

        VPMADDWDZrmkz = 10805,

        VPMADDWDZrr = 10806,

        VPMADDWDZrrk = 10807,

        VPMADDWDZrrkz = 10808,

        VPMADDWDrm = 10809,

        VPMADDWDrr = 10810,

        VPMASKMOVDYmr = 10811,

        VPMASKMOVDYrm = 10812,

        VPMASKMOVDmr = 10813,

        VPMASKMOVDrm = 10814,

        VPMASKMOVQYmr = 10815,

        VPMASKMOVQYrm = 10816,

        VPMASKMOVQmr = 10817,

        VPMASKMOVQrm = 10818,

        VPMAXSBYrm = 10819,

        VPMAXSBYrr = 10820,

        VPMAXSBZ128rm = 10821,

        VPMAXSBZ128rmk = 10822,

        VPMAXSBZ128rmkz = 10823,

        VPMAXSBZ128rr = 10824,

        VPMAXSBZ128rrk = 10825,

        VPMAXSBZ128rrkz = 10826,

        VPMAXSBZ256rm = 10827,

        VPMAXSBZ256rmk = 10828,

        VPMAXSBZ256rmkz = 10829,

        VPMAXSBZ256rr = 10830,

        VPMAXSBZ256rrk = 10831,

        VPMAXSBZ256rrkz = 10832,

        VPMAXSBZrm = 10833,

        VPMAXSBZrmk = 10834,

        VPMAXSBZrmkz = 10835,

        VPMAXSBZrr = 10836,

        VPMAXSBZrrk = 10837,

        VPMAXSBZrrkz = 10838,

        VPMAXSBrm = 10839,

        VPMAXSBrr = 10840,

        VPMAXSDYrm = 10841,

        VPMAXSDYrr = 10842,

        VPMAXSDZ128rm = 10843,

        VPMAXSDZ128rmb = 10844,

        VPMAXSDZ128rmbk = 10845,

        VPMAXSDZ128rmbkz = 10846,

        VPMAXSDZ128rmk = 10847,

        VPMAXSDZ128rmkz = 10848,

        VPMAXSDZ128rr = 10849,

        VPMAXSDZ128rrk = 10850,

        VPMAXSDZ128rrkz = 10851,

        VPMAXSDZ256rm = 10852,

        VPMAXSDZ256rmb = 10853,

        VPMAXSDZ256rmbk = 10854,

        VPMAXSDZ256rmbkz = 10855,

        VPMAXSDZ256rmk = 10856,

        VPMAXSDZ256rmkz = 10857,

        VPMAXSDZ256rr = 10858,

        VPMAXSDZ256rrk = 10859,

        VPMAXSDZ256rrkz = 10860,

        VPMAXSDZrm = 10861,

        VPMAXSDZrmb = 10862,

        VPMAXSDZrmbk = 10863,

        VPMAXSDZrmbkz = 10864,

        VPMAXSDZrmk = 10865,

        VPMAXSDZrmkz = 10866,

        VPMAXSDZrr = 10867,

        VPMAXSDZrrk = 10868,

        VPMAXSDZrrkz = 10869,

        VPMAXSDrm = 10870,

        VPMAXSDrr = 10871,

        VPMAXSQZ128rm = 10872,

        VPMAXSQZ128rmb = 10873,

        VPMAXSQZ128rmbk = 10874,

        VPMAXSQZ128rmbkz = 10875,

        VPMAXSQZ128rmk = 10876,

        VPMAXSQZ128rmkz = 10877,

        VPMAXSQZ128rr = 10878,

        VPMAXSQZ128rrk = 10879,

        VPMAXSQZ128rrkz = 10880,

        VPMAXSQZ256rm = 10881,

        VPMAXSQZ256rmb = 10882,

        VPMAXSQZ256rmbk = 10883,

        VPMAXSQZ256rmbkz = 10884,

        VPMAXSQZ256rmk = 10885,

        VPMAXSQZ256rmkz = 10886,

        VPMAXSQZ256rr = 10887,

        VPMAXSQZ256rrk = 10888,

        VPMAXSQZ256rrkz = 10889,

        VPMAXSQZrm = 10890,

        VPMAXSQZrmb = 10891,

        VPMAXSQZrmbk = 10892,

        VPMAXSQZrmbkz = 10893,

        VPMAXSQZrmk = 10894,

        VPMAXSQZrmkz = 10895,

        VPMAXSQZrr = 10896,

        VPMAXSQZrrk = 10897,

        VPMAXSQZrrkz = 10898,

        VPMAXSWYrm = 10899,

        VPMAXSWYrr = 10900,

        VPMAXSWZ128rm = 10901,

        VPMAXSWZ128rmk = 10902,

        VPMAXSWZ128rmkz = 10903,

        VPMAXSWZ128rr = 10904,

        VPMAXSWZ128rrk = 10905,

        VPMAXSWZ128rrkz = 10906,

        VPMAXSWZ256rm = 10907,

        VPMAXSWZ256rmk = 10908,

        VPMAXSWZ256rmkz = 10909,

        VPMAXSWZ256rr = 10910,

        VPMAXSWZ256rrk = 10911,

        VPMAXSWZ256rrkz = 10912,

        VPMAXSWZrm = 10913,

        VPMAXSWZrmk = 10914,

        VPMAXSWZrmkz = 10915,

        VPMAXSWZrr = 10916,

        VPMAXSWZrrk = 10917,

        VPMAXSWZrrkz = 10918,

        VPMAXSWrm = 10919,

        VPMAXSWrr = 10920,

        VPMAXUBYrm = 10921,

        VPMAXUBYrr = 10922,

        VPMAXUBZ128rm = 10923,

        VPMAXUBZ128rmk = 10924,

        VPMAXUBZ128rmkz = 10925,

        VPMAXUBZ128rr = 10926,

        VPMAXUBZ128rrk = 10927,

        VPMAXUBZ128rrkz = 10928,

        VPMAXUBZ256rm = 10929,

        VPMAXUBZ256rmk = 10930,

        VPMAXUBZ256rmkz = 10931,

        VPMAXUBZ256rr = 10932,

        VPMAXUBZ256rrk = 10933,

        VPMAXUBZ256rrkz = 10934,

        VPMAXUBZrm = 10935,

        VPMAXUBZrmk = 10936,

        VPMAXUBZrmkz = 10937,

        VPMAXUBZrr = 10938,

        VPMAXUBZrrk = 10939,

        VPMAXUBZrrkz = 10940,

        VPMAXUBrm = 10941,

        VPMAXUBrr = 10942,

        VPMAXUDYrm = 10943,

        VPMAXUDYrr = 10944,

        VPMAXUDZ128rm = 10945,

        VPMAXUDZ128rmb = 10946,

        VPMAXUDZ128rmbk = 10947,

        VPMAXUDZ128rmbkz = 10948,

        VPMAXUDZ128rmk = 10949,

        VPMAXUDZ128rmkz = 10950,

        VPMAXUDZ128rr = 10951,

        VPMAXUDZ128rrk = 10952,

        VPMAXUDZ128rrkz = 10953,

        VPMAXUDZ256rm = 10954,

        VPMAXUDZ256rmb = 10955,

        VPMAXUDZ256rmbk = 10956,

        VPMAXUDZ256rmbkz = 10957,

        VPMAXUDZ256rmk = 10958,

        VPMAXUDZ256rmkz = 10959,

        VPMAXUDZ256rr = 10960,

        VPMAXUDZ256rrk = 10961,

        VPMAXUDZ256rrkz = 10962,

        VPMAXUDZrm = 10963,

        VPMAXUDZrmb = 10964,

        VPMAXUDZrmbk = 10965,

        VPMAXUDZrmbkz = 10966,

        VPMAXUDZrmk = 10967,

        VPMAXUDZrmkz = 10968,

        VPMAXUDZrr = 10969,

        VPMAXUDZrrk = 10970,

        VPMAXUDZrrkz = 10971,

        VPMAXUDrm = 10972,

        VPMAXUDrr = 10973,

        VPMAXUQZ128rm = 10974,

        VPMAXUQZ128rmb = 10975,

        VPMAXUQZ128rmbk = 10976,

        VPMAXUQZ128rmbkz = 10977,

        VPMAXUQZ128rmk = 10978,

        VPMAXUQZ128rmkz = 10979,

        VPMAXUQZ128rr = 10980,

        VPMAXUQZ128rrk = 10981,

        VPMAXUQZ128rrkz = 10982,

        VPMAXUQZ256rm = 10983,

        VPMAXUQZ256rmb = 10984,

        VPMAXUQZ256rmbk = 10985,

        VPMAXUQZ256rmbkz = 10986,

        VPMAXUQZ256rmk = 10987,

        VPMAXUQZ256rmkz = 10988,

        VPMAXUQZ256rr = 10989,

        VPMAXUQZ256rrk = 10990,

        VPMAXUQZ256rrkz = 10991,

        VPMAXUQZrm = 10992,

        VPMAXUQZrmb = 10993,

        VPMAXUQZrmbk = 10994,

        VPMAXUQZrmbkz = 10995,

        VPMAXUQZrmk = 10996,

        VPMAXUQZrmkz = 10997,

        VPMAXUQZrr = 10998,

        VPMAXUQZrrk = 10999,

        VPMAXUQZrrkz = 11000,

        VPMAXUWYrm = 11001,

        VPMAXUWYrr = 11002,

        VPMAXUWZ128rm = 11003,

        VPMAXUWZ128rmk = 11004,

        VPMAXUWZ128rmkz = 11005,

        VPMAXUWZ128rr = 11006,

        VPMAXUWZ128rrk = 11007,

        VPMAXUWZ128rrkz = 11008,

        VPMAXUWZ256rm = 11009,

        VPMAXUWZ256rmk = 11010,

        VPMAXUWZ256rmkz = 11011,

        VPMAXUWZ256rr = 11012,

        VPMAXUWZ256rrk = 11013,

        VPMAXUWZ256rrkz = 11014,

        VPMAXUWZrm = 11015,

        VPMAXUWZrmk = 11016,

        VPMAXUWZrmkz = 11017,

        VPMAXUWZrr = 11018,

        VPMAXUWZrrk = 11019,

        VPMAXUWZrrkz = 11020,

        VPMAXUWrm = 11021,

        VPMAXUWrr = 11022,

        VPMINSBYrm = 11023,

        VPMINSBYrr = 11024,

        VPMINSBZ128rm = 11025,

        VPMINSBZ128rmk = 11026,

        VPMINSBZ128rmkz = 11027,

        VPMINSBZ128rr = 11028,

        VPMINSBZ128rrk = 11029,

        VPMINSBZ128rrkz = 11030,

        VPMINSBZ256rm = 11031,

        VPMINSBZ256rmk = 11032,

        VPMINSBZ256rmkz = 11033,

        VPMINSBZ256rr = 11034,

        VPMINSBZ256rrk = 11035,

        VPMINSBZ256rrkz = 11036,

        VPMINSBZrm = 11037,

        VPMINSBZrmk = 11038,

        VPMINSBZrmkz = 11039,

        VPMINSBZrr = 11040,

        VPMINSBZrrk = 11041,

        VPMINSBZrrkz = 11042,

        VPMINSBrm = 11043,

        VPMINSBrr = 11044,

        VPMINSDYrm = 11045,

        VPMINSDYrr = 11046,

        VPMINSDZ128rm = 11047,

        VPMINSDZ128rmb = 11048,

        VPMINSDZ128rmbk = 11049,

        VPMINSDZ128rmbkz = 11050,

        VPMINSDZ128rmk = 11051,

        VPMINSDZ128rmkz = 11052,

        VPMINSDZ128rr = 11053,

        VPMINSDZ128rrk = 11054,

        VPMINSDZ128rrkz = 11055,

        VPMINSDZ256rm = 11056,

        VPMINSDZ256rmb = 11057,

        VPMINSDZ256rmbk = 11058,

        VPMINSDZ256rmbkz = 11059,

        VPMINSDZ256rmk = 11060,

        VPMINSDZ256rmkz = 11061,

        VPMINSDZ256rr = 11062,

        VPMINSDZ256rrk = 11063,

        VPMINSDZ256rrkz = 11064,

        VPMINSDZrm = 11065,

        VPMINSDZrmb = 11066,

        VPMINSDZrmbk = 11067,

        VPMINSDZrmbkz = 11068,

        VPMINSDZrmk = 11069,

        VPMINSDZrmkz = 11070,

        VPMINSDZrr = 11071,

        VPMINSDZrrk = 11072,

        VPMINSDZrrkz = 11073,

        VPMINSDrm = 11074,

        VPMINSDrr = 11075,

        VPMINSQZ128rm = 11076,

        VPMINSQZ128rmb = 11077,

        VPMINSQZ128rmbk = 11078,

        VPMINSQZ128rmbkz = 11079,

        VPMINSQZ128rmk = 11080,

        VPMINSQZ128rmkz = 11081,

        VPMINSQZ128rr = 11082,

        VPMINSQZ128rrk = 11083,

        VPMINSQZ128rrkz = 11084,

        VPMINSQZ256rm = 11085,

        VPMINSQZ256rmb = 11086,

        VPMINSQZ256rmbk = 11087,

        VPMINSQZ256rmbkz = 11088,

        VPMINSQZ256rmk = 11089,

        VPMINSQZ256rmkz = 11090,

        VPMINSQZ256rr = 11091,

        VPMINSQZ256rrk = 11092,

        VPMINSQZ256rrkz = 11093,

        VPMINSQZrm = 11094,

        VPMINSQZrmb = 11095,

        VPMINSQZrmbk = 11096,

        VPMINSQZrmbkz = 11097,

        VPMINSQZrmk = 11098,

        VPMINSQZrmkz = 11099,

        VPMINSQZrr = 11100,

        VPMINSQZrrk = 11101,

        VPMINSQZrrkz = 11102,

        VPMINSWYrm = 11103,

        VPMINSWYrr = 11104,

        VPMINSWZ128rm = 11105,

        VPMINSWZ128rmk = 11106,

        VPMINSWZ128rmkz = 11107,

        VPMINSWZ128rr = 11108,

        VPMINSWZ128rrk = 11109,

        VPMINSWZ128rrkz = 11110,

        VPMINSWZ256rm = 11111,

        VPMINSWZ256rmk = 11112,

        VPMINSWZ256rmkz = 11113,

        VPMINSWZ256rr = 11114,

        VPMINSWZ256rrk = 11115,

        VPMINSWZ256rrkz = 11116,

        VPMINSWZrm = 11117,

        VPMINSWZrmk = 11118,

        VPMINSWZrmkz = 11119,

        VPMINSWZrr = 11120,

        VPMINSWZrrk = 11121,

        VPMINSWZrrkz = 11122,

        VPMINSWrm = 11123,

        VPMINSWrr = 11124,

        VPMINUBYrm = 11125,

        VPMINUBYrr = 11126,

        VPMINUBZ128rm = 11127,

        VPMINUBZ128rmk = 11128,

        VPMINUBZ128rmkz = 11129,

        VPMINUBZ128rr = 11130,

        VPMINUBZ128rrk = 11131,

        VPMINUBZ128rrkz = 11132,

        VPMINUBZ256rm = 11133,

        VPMINUBZ256rmk = 11134,

        VPMINUBZ256rmkz = 11135,

        VPMINUBZ256rr = 11136,

        VPMINUBZ256rrk = 11137,

        VPMINUBZ256rrkz = 11138,

        VPMINUBZrm = 11139,

        VPMINUBZrmk = 11140,

        VPMINUBZrmkz = 11141,

        VPMINUBZrr = 11142,

        VPMINUBZrrk = 11143,

        VPMINUBZrrkz = 11144,

        VPMINUBrm = 11145,

        VPMINUBrr = 11146,

        VPMINUDYrm = 11147,

        VPMINUDYrr = 11148,

        VPMINUDZ128rm = 11149,

        VPMINUDZ128rmb = 11150,

        VPMINUDZ128rmbk = 11151,

        VPMINUDZ128rmbkz = 11152,

        VPMINUDZ128rmk = 11153,

        VPMINUDZ128rmkz = 11154,

        VPMINUDZ128rr = 11155,

        VPMINUDZ128rrk = 11156,

        VPMINUDZ128rrkz = 11157,

        VPMINUDZ256rm = 11158,

        VPMINUDZ256rmb = 11159,

        VPMINUDZ256rmbk = 11160,

        VPMINUDZ256rmbkz = 11161,

        VPMINUDZ256rmk = 11162,

        VPMINUDZ256rmkz = 11163,

        VPMINUDZ256rr = 11164,

        VPMINUDZ256rrk = 11165,

        VPMINUDZ256rrkz = 11166,

        VPMINUDZrm = 11167,

        VPMINUDZrmb = 11168,

        VPMINUDZrmbk = 11169,

        VPMINUDZrmbkz = 11170,

        VPMINUDZrmk = 11171,

        VPMINUDZrmkz = 11172,

        VPMINUDZrr = 11173,

        VPMINUDZrrk = 11174,

        VPMINUDZrrkz = 11175,

        VPMINUDrm = 11176,

        VPMINUDrr = 11177,

        VPMINUQZ128rm = 11178,

        VPMINUQZ128rmb = 11179,

        VPMINUQZ128rmbk = 11180,

        VPMINUQZ128rmbkz = 11181,

        VPMINUQZ128rmk = 11182,

        VPMINUQZ128rmkz = 11183,

        VPMINUQZ128rr = 11184,

        VPMINUQZ128rrk = 11185,

        VPMINUQZ128rrkz = 11186,

        VPMINUQZ256rm = 11187,

        VPMINUQZ256rmb = 11188,

        VPMINUQZ256rmbk = 11189,

        VPMINUQZ256rmbkz = 11190,

        VPMINUQZ256rmk = 11191,

        VPMINUQZ256rmkz = 11192,

        VPMINUQZ256rr = 11193,

        VPMINUQZ256rrk = 11194,

        VPMINUQZ256rrkz = 11195,

        VPMINUQZrm = 11196,

        VPMINUQZrmb = 11197,

        VPMINUQZrmbk = 11198,

        VPMINUQZrmbkz = 11199,

        VPMINUQZrmk = 11200,

        VPMINUQZrmkz = 11201,

        VPMINUQZrr = 11202,

        VPMINUQZrrk = 11203,

        VPMINUQZrrkz = 11204,

        VPMINUWYrm = 11205,

        VPMINUWYrr = 11206,

        VPMINUWZ128rm = 11207,

        VPMINUWZ128rmk = 11208,

        VPMINUWZ128rmkz = 11209,

        VPMINUWZ128rr = 11210,

        VPMINUWZ128rrk = 11211,

        VPMINUWZ128rrkz = 11212,

        VPMINUWZ256rm = 11213,

        VPMINUWZ256rmk = 11214,

        VPMINUWZ256rmkz = 11215,

        VPMINUWZ256rr = 11216,

        VPMINUWZ256rrk = 11217,

        VPMINUWZ256rrkz = 11218,

        VPMINUWZrm = 11219,

        VPMINUWZrmk = 11220,

        VPMINUWZrmkz = 11221,

        VPMINUWZrr = 11222,

        VPMINUWZrrk = 11223,

        VPMINUWZrrkz = 11224,

        VPMINUWrm = 11225,

        VPMINUWrr = 11226,

        VPMOVB2MZ128rr = 11227,

        VPMOVB2MZ256rr = 11228,

        VPMOVB2MZrr = 11229,

        VPMOVD2MZ128rr = 11230,

        VPMOVD2MZ256rr = 11231,

        VPMOVD2MZrr = 11232,

        VPMOVDBZ128mr = 11233,

        VPMOVDBZ128mrk = 11234,

        VPMOVDBZ128rr = 11235,

        VPMOVDBZ128rrk = 11236,

        VPMOVDBZ128rrkz = 11237,

        VPMOVDBZ256mr = 11238,

        VPMOVDBZ256mrk = 11239,

        VPMOVDBZ256rr = 11240,

        VPMOVDBZ256rrk = 11241,

        VPMOVDBZ256rrkz = 11242,

        VPMOVDBZmr = 11243,

        VPMOVDBZmrk = 11244,

        VPMOVDBZrr = 11245,

        VPMOVDBZrrk = 11246,

        VPMOVDBZrrkz = 11247,

        VPMOVDWZ128mr = 11248,

        VPMOVDWZ128mrk = 11249,

        VPMOVDWZ128rr = 11250,

        VPMOVDWZ128rrk = 11251,

        VPMOVDWZ128rrkz = 11252,

        VPMOVDWZ256mr = 11253,

        VPMOVDWZ256mrk = 11254,

        VPMOVDWZ256rr = 11255,

        VPMOVDWZ256rrk = 11256,

        VPMOVDWZ256rrkz = 11257,

        VPMOVDWZmr = 11258,

        VPMOVDWZmrk = 11259,

        VPMOVDWZrr = 11260,

        VPMOVDWZrrk = 11261,

        VPMOVDWZrrkz = 11262,

        VPMOVM2BZ128rr = 11263,

        VPMOVM2BZ256rr = 11264,

        VPMOVM2BZrr = 11265,

        VPMOVM2DZ128rr = 11266,

        VPMOVM2DZ256rr = 11267,

        VPMOVM2DZrr = 11268,

        VPMOVM2QZ128rr = 11269,

        VPMOVM2QZ256rr = 11270,

        VPMOVM2QZrr = 11271,

        VPMOVM2WZ128rr = 11272,

        VPMOVM2WZ256rr = 11273,

        VPMOVM2WZrr = 11274,

        VPMOVMSKBYrr = 11275,

        VPMOVMSKBrr = 11276,

        VPMOVQ2MZ128rr = 11277,

        VPMOVQ2MZ256rr = 11278,

        VPMOVQ2MZrr = 11279,

        VPMOVQBZ128mr = 11280,

        VPMOVQBZ128mrk = 11281,

        VPMOVQBZ128rr = 11282,

        VPMOVQBZ128rrk = 11283,

        VPMOVQBZ128rrkz = 11284,

        VPMOVQBZ256mr = 11285,

        VPMOVQBZ256mrk = 11286,

        VPMOVQBZ256rr = 11287,

        VPMOVQBZ256rrk = 11288,

        VPMOVQBZ256rrkz = 11289,

        VPMOVQBZmr = 11290,

        VPMOVQBZmrk = 11291,

        VPMOVQBZrr = 11292,

        VPMOVQBZrrk = 11293,

        VPMOVQBZrrkz = 11294,

        VPMOVQDZ128mr = 11295,

        VPMOVQDZ128mrk = 11296,

        VPMOVQDZ128rr = 11297,

        VPMOVQDZ128rrk = 11298,

        VPMOVQDZ128rrkz = 11299,

        VPMOVQDZ256mr = 11300,

        VPMOVQDZ256mrk = 11301,

        VPMOVQDZ256rr = 11302,

        VPMOVQDZ256rrk = 11303,

        VPMOVQDZ256rrkz = 11304,

        VPMOVQDZmr = 11305,

        VPMOVQDZmrk = 11306,

        VPMOVQDZrr = 11307,

        VPMOVQDZrrk = 11308,

        VPMOVQDZrrkz = 11309,

        VPMOVQWZ128mr = 11310,

        VPMOVQWZ128mrk = 11311,

        VPMOVQWZ128rr = 11312,

        VPMOVQWZ128rrk = 11313,

        VPMOVQWZ128rrkz = 11314,

        VPMOVQWZ256mr = 11315,

        VPMOVQWZ256mrk = 11316,

        VPMOVQWZ256rr = 11317,

        VPMOVQWZ256rrk = 11318,

        VPMOVQWZ256rrkz = 11319,

        VPMOVQWZmr = 11320,

        VPMOVQWZmrk = 11321,

        VPMOVQWZrr = 11322,

        VPMOVQWZrrk = 11323,

        VPMOVQWZrrkz = 11324,

        VPMOVSDBZ128mr = 11325,

        VPMOVSDBZ128mrk = 11326,

        VPMOVSDBZ128rr = 11327,

        VPMOVSDBZ128rrk = 11328,

        VPMOVSDBZ128rrkz = 11329,

        VPMOVSDBZ256mr = 11330,

        VPMOVSDBZ256mrk = 11331,

        VPMOVSDBZ256rr = 11332,

        VPMOVSDBZ256rrk = 11333,

        VPMOVSDBZ256rrkz = 11334,

        VPMOVSDBZmr = 11335,

        VPMOVSDBZmrk = 11336,

        VPMOVSDBZrr = 11337,

        VPMOVSDBZrrk = 11338,

        VPMOVSDBZrrkz = 11339,

        VPMOVSDWZ128mr = 11340,

        VPMOVSDWZ128mrk = 11341,

        VPMOVSDWZ128rr = 11342,

        VPMOVSDWZ128rrk = 11343,

        VPMOVSDWZ128rrkz = 11344,

        VPMOVSDWZ256mr = 11345,

        VPMOVSDWZ256mrk = 11346,

        VPMOVSDWZ256rr = 11347,

        VPMOVSDWZ256rrk = 11348,

        VPMOVSDWZ256rrkz = 11349,

        VPMOVSDWZmr = 11350,

        VPMOVSDWZmrk = 11351,

        VPMOVSDWZrr = 11352,

        VPMOVSDWZrrk = 11353,

        VPMOVSDWZrrkz = 11354,

        VPMOVSQBZ128mr = 11355,

        VPMOVSQBZ128mrk = 11356,

        VPMOVSQBZ128rr = 11357,

        VPMOVSQBZ128rrk = 11358,

        VPMOVSQBZ128rrkz = 11359,

        VPMOVSQBZ256mr = 11360,

        VPMOVSQBZ256mrk = 11361,

        VPMOVSQBZ256rr = 11362,

        VPMOVSQBZ256rrk = 11363,

        VPMOVSQBZ256rrkz = 11364,

        VPMOVSQBZmr = 11365,

        VPMOVSQBZmrk = 11366,

        VPMOVSQBZrr = 11367,

        VPMOVSQBZrrk = 11368,

        VPMOVSQBZrrkz = 11369,

        VPMOVSQDZ128mr = 11370,

        VPMOVSQDZ128mrk = 11371,

        VPMOVSQDZ128rr = 11372,

        VPMOVSQDZ128rrk = 11373,

        VPMOVSQDZ128rrkz = 11374,

        VPMOVSQDZ256mr = 11375,

        VPMOVSQDZ256mrk = 11376,

        VPMOVSQDZ256rr = 11377,

        VPMOVSQDZ256rrk = 11378,

        VPMOVSQDZ256rrkz = 11379,

        VPMOVSQDZmr = 11380,

        VPMOVSQDZmrk = 11381,

        VPMOVSQDZrr = 11382,

        VPMOVSQDZrrk = 11383,

        VPMOVSQDZrrkz = 11384,

        VPMOVSQWZ128mr = 11385,

        VPMOVSQWZ128mrk = 11386,

        VPMOVSQWZ128rr = 11387,

        VPMOVSQWZ128rrk = 11388,

        VPMOVSQWZ128rrkz = 11389,

        VPMOVSQWZ256mr = 11390,

        VPMOVSQWZ256mrk = 11391,

        VPMOVSQWZ256rr = 11392,

        VPMOVSQWZ256rrk = 11393,

        VPMOVSQWZ256rrkz = 11394,

        VPMOVSQWZmr = 11395,

        VPMOVSQWZmrk = 11396,

        VPMOVSQWZrr = 11397,

        VPMOVSQWZrrk = 11398,

        VPMOVSQWZrrkz = 11399,

        VPMOVSWBZ128mr = 11400,

        VPMOVSWBZ128mrk = 11401,

        VPMOVSWBZ128rr = 11402,

        VPMOVSWBZ128rrk = 11403,

        VPMOVSWBZ128rrkz = 11404,

        VPMOVSWBZ256mr = 11405,

        VPMOVSWBZ256mrk = 11406,

        VPMOVSWBZ256rr = 11407,

        VPMOVSWBZ256rrk = 11408,

        VPMOVSWBZ256rrkz = 11409,

        VPMOVSWBZmr = 11410,

        VPMOVSWBZmrk = 11411,

        VPMOVSWBZrr = 11412,

        VPMOVSWBZrrk = 11413,

        VPMOVSWBZrrkz = 11414,

        VPMOVSXBDYrm = 11415,

        VPMOVSXBDYrr = 11416,

        VPMOVSXBDZ128rm = 11417,

        VPMOVSXBDZ128rmk = 11418,

        VPMOVSXBDZ128rmkz = 11419,

        VPMOVSXBDZ128rr = 11420,

        VPMOVSXBDZ128rrk = 11421,

        VPMOVSXBDZ128rrkz = 11422,

        VPMOVSXBDZ256rm = 11423,

        VPMOVSXBDZ256rmk = 11424,

        VPMOVSXBDZ256rmkz = 11425,

        VPMOVSXBDZ256rr = 11426,

        VPMOVSXBDZ256rrk = 11427,

        VPMOVSXBDZ256rrkz = 11428,

        VPMOVSXBDZrm = 11429,

        VPMOVSXBDZrmk = 11430,

        VPMOVSXBDZrmkz = 11431,

        VPMOVSXBDZrr = 11432,

        VPMOVSXBDZrrk = 11433,

        VPMOVSXBDZrrkz = 11434,

        VPMOVSXBDrm = 11435,

        VPMOVSXBDrr = 11436,

        VPMOVSXBQYrm = 11437,

        VPMOVSXBQYrr = 11438,

        VPMOVSXBQZ128rm = 11439,

        VPMOVSXBQZ128rmk = 11440,

        VPMOVSXBQZ128rmkz = 11441,

        VPMOVSXBQZ128rr = 11442,

        VPMOVSXBQZ128rrk = 11443,

        VPMOVSXBQZ128rrkz = 11444,

        VPMOVSXBQZ256rm = 11445,

        VPMOVSXBQZ256rmk = 11446,

        VPMOVSXBQZ256rmkz = 11447,

        VPMOVSXBQZ256rr = 11448,

        VPMOVSXBQZ256rrk = 11449,

        VPMOVSXBQZ256rrkz = 11450,

        VPMOVSXBQZrm = 11451,

        VPMOVSXBQZrmk = 11452,

        VPMOVSXBQZrmkz = 11453,

        VPMOVSXBQZrr = 11454,

        VPMOVSXBQZrrk = 11455,

        VPMOVSXBQZrrkz = 11456,

        VPMOVSXBQrm = 11457,

        VPMOVSXBQrr = 11458,

        VPMOVSXBWYrm = 11459,

        VPMOVSXBWYrr = 11460,

        VPMOVSXBWZ128rm = 11461,

        VPMOVSXBWZ128rmk = 11462,

        VPMOVSXBWZ128rmkz = 11463,

        VPMOVSXBWZ128rr = 11464,

        VPMOVSXBWZ128rrk = 11465,

        VPMOVSXBWZ128rrkz = 11466,

        VPMOVSXBWZ256rm = 11467,

        VPMOVSXBWZ256rmk = 11468,

        VPMOVSXBWZ256rmkz = 11469,

        VPMOVSXBWZ256rr = 11470,

        VPMOVSXBWZ256rrk = 11471,

        VPMOVSXBWZ256rrkz = 11472,

        VPMOVSXBWZrm = 11473,

        VPMOVSXBWZrmk = 11474,

        VPMOVSXBWZrmkz = 11475,

        VPMOVSXBWZrr = 11476,

        VPMOVSXBWZrrk = 11477,

        VPMOVSXBWZrrkz = 11478,

        VPMOVSXBWrm = 11479,

        VPMOVSXBWrr = 11480,

        VPMOVSXDQYrm = 11481,

        VPMOVSXDQYrr = 11482,

        VPMOVSXDQZ128rm = 11483,

        VPMOVSXDQZ128rmk = 11484,

        VPMOVSXDQZ128rmkz = 11485,

        VPMOVSXDQZ128rr = 11486,

        VPMOVSXDQZ128rrk = 11487,

        VPMOVSXDQZ128rrkz = 11488,

        VPMOVSXDQZ256rm = 11489,

        VPMOVSXDQZ256rmk = 11490,

        VPMOVSXDQZ256rmkz = 11491,

        VPMOVSXDQZ256rr = 11492,

        VPMOVSXDQZ256rrk = 11493,

        VPMOVSXDQZ256rrkz = 11494,

        VPMOVSXDQZrm = 11495,

        VPMOVSXDQZrmk = 11496,

        VPMOVSXDQZrmkz = 11497,

        VPMOVSXDQZrr = 11498,

        VPMOVSXDQZrrk = 11499,

        VPMOVSXDQZrrkz = 11500,

        VPMOVSXDQrm = 11501,

        VPMOVSXDQrr = 11502,

        VPMOVSXWDYrm = 11503,

        VPMOVSXWDYrr = 11504,

        VPMOVSXWDZ128rm = 11505,

        VPMOVSXWDZ128rmk = 11506,

        VPMOVSXWDZ128rmkz = 11507,

        VPMOVSXWDZ128rr = 11508,

        VPMOVSXWDZ128rrk = 11509,

        VPMOVSXWDZ128rrkz = 11510,

        VPMOVSXWDZ256rm = 11511,

        VPMOVSXWDZ256rmk = 11512,

        VPMOVSXWDZ256rmkz = 11513,

        VPMOVSXWDZ256rr = 11514,

        VPMOVSXWDZ256rrk = 11515,

        VPMOVSXWDZ256rrkz = 11516,

        VPMOVSXWDZrm = 11517,

        VPMOVSXWDZrmk = 11518,

        VPMOVSXWDZrmkz = 11519,

        VPMOVSXWDZrr = 11520,

        VPMOVSXWDZrrk = 11521,

        VPMOVSXWDZrrkz = 11522,

        VPMOVSXWDrm = 11523,

        VPMOVSXWDrr = 11524,

        VPMOVSXWQYrm = 11525,

        VPMOVSXWQYrr = 11526,

        VPMOVSXWQZ128rm = 11527,

        VPMOVSXWQZ128rmk = 11528,

        VPMOVSXWQZ128rmkz = 11529,

        VPMOVSXWQZ128rr = 11530,

        VPMOVSXWQZ128rrk = 11531,

        VPMOVSXWQZ128rrkz = 11532,

        VPMOVSXWQZ256rm = 11533,

        VPMOVSXWQZ256rmk = 11534,

        VPMOVSXWQZ256rmkz = 11535,

        VPMOVSXWQZ256rr = 11536,

        VPMOVSXWQZ256rrk = 11537,

        VPMOVSXWQZ256rrkz = 11538,

        VPMOVSXWQZrm = 11539,

        VPMOVSXWQZrmk = 11540,

        VPMOVSXWQZrmkz = 11541,

        VPMOVSXWQZrr = 11542,

        VPMOVSXWQZrrk = 11543,

        VPMOVSXWQZrrkz = 11544,

        VPMOVSXWQrm = 11545,

        VPMOVSXWQrr = 11546,

        VPMOVUSDBZ128mr = 11547,

        VPMOVUSDBZ128mrk = 11548,

        VPMOVUSDBZ128rr = 11549,

        VPMOVUSDBZ128rrk = 11550,

        VPMOVUSDBZ128rrkz = 11551,

        VPMOVUSDBZ256mr = 11552,

        VPMOVUSDBZ256mrk = 11553,

        VPMOVUSDBZ256rr = 11554,

        VPMOVUSDBZ256rrk = 11555,

        VPMOVUSDBZ256rrkz = 11556,

        VPMOVUSDBZmr = 11557,

        VPMOVUSDBZmrk = 11558,

        VPMOVUSDBZrr = 11559,

        VPMOVUSDBZrrk = 11560,

        VPMOVUSDBZrrkz = 11561,

        VPMOVUSDWZ128mr = 11562,

        VPMOVUSDWZ128mrk = 11563,

        VPMOVUSDWZ128rr = 11564,

        VPMOVUSDWZ128rrk = 11565,

        VPMOVUSDWZ128rrkz = 11566,

        VPMOVUSDWZ256mr = 11567,

        VPMOVUSDWZ256mrk = 11568,

        VPMOVUSDWZ256rr = 11569,

        VPMOVUSDWZ256rrk = 11570,

        VPMOVUSDWZ256rrkz = 11571,

        VPMOVUSDWZmr = 11572,

        VPMOVUSDWZmrk = 11573,

        VPMOVUSDWZrr = 11574,

        VPMOVUSDWZrrk = 11575,

        VPMOVUSDWZrrkz = 11576,

        VPMOVUSQBZ128mr = 11577,

        VPMOVUSQBZ128mrk = 11578,

        VPMOVUSQBZ128rr = 11579,

        VPMOVUSQBZ128rrk = 11580,

        VPMOVUSQBZ128rrkz = 11581,

        VPMOVUSQBZ256mr = 11582,

        VPMOVUSQBZ256mrk = 11583,

        VPMOVUSQBZ256rr = 11584,

        VPMOVUSQBZ256rrk = 11585,

        VPMOVUSQBZ256rrkz = 11586,

        VPMOVUSQBZmr = 11587,

        VPMOVUSQBZmrk = 11588,

        VPMOVUSQBZrr = 11589,

        VPMOVUSQBZrrk = 11590,

        VPMOVUSQBZrrkz = 11591,

        VPMOVUSQDZ128mr = 11592,

        VPMOVUSQDZ128mrk = 11593,

        VPMOVUSQDZ128rr = 11594,

        VPMOVUSQDZ128rrk = 11595,

        VPMOVUSQDZ128rrkz = 11596,

        VPMOVUSQDZ256mr = 11597,

        VPMOVUSQDZ256mrk = 11598,

        VPMOVUSQDZ256rr = 11599,

        VPMOVUSQDZ256rrk = 11600,

        VPMOVUSQDZ256rrkz = 11601,

        VPMOVUSQDZmr = 11602,

        VPMOVUSQDZmrk = 11603,

        VPMOVUSQDZrr = 11604,

        VPMOVUSQDZrrk = 11605,

        VPMOVUSQDZrrkz = 11606,

        VPMOVUSQWZ128mr = 11607,

        VPMOVUSQWZ128mrk = 11608,

        VPMOVUSQWZ128rr = 11609,

        VPMOVUSQWZ128rrk = 11610,

        VPMOVUSQWZ128rrkz = 11611,

        VPMOVUSQWZ256mr = 11612,

        VPMOVUSQWZ256mrk = 11613,

        VPMOVUSQWZ256rr = 11614,

        VPMOVUSQWZ256rrk = 11615,

        VPMOVUSQWZ256rrkz = 11616,

        VPMOVUSQWZmr = 11617,

        VPMOVUSQWZmrk = 11618,

        VPMOVUSQWZrr = 11619,

        VPMOVUSQWZrrk = 11620,

        VPMOVUSQWZrrkz = 11621,

        VPMOVUSWBZ128mr = 11622,

        VPMOVUSWBZ128mrk = 11623,

        VPMOVUSWBZ128rr = 11624,

        VPMOVUSWBZ128rrk = 11625,

        VPMOVUSWBZ128rrkz = 11626,

        VPMOVUSWBZ256mr = 11627,

        VPMOVUSWBZ256mrk = 11628,

        VPMOVUSWBZ256rr = 11629,

        VPMOVUSWBZ256rrk = 11630,

        VPMOVUSWBZ256rrkz = 11631,

        VPMOVUSWBZmr = 11632,

        VPMOVUSWBZmrk = 11633,

        VPMOVUSWBZrr = 11634,

        VPMOVUSWBZrrk = 11635,

        VPMOVUSWBZrrkz = 11636,

        VPMOVW2MZ128rr = 11637,

        VPMOVW2MZ256rr = 11638,

        VPMOVW2MZrr = 11639,

        VPMOVWBZ128mr = 11640,

        VPMOVWBZ128mrk = 11641,

        VPMOVWBZ128rr = 11642,

        VPMOVWBZ128rrk = 11643,

        VPMOVWBZ128rrkz = 11644,

        VPMOVWBZ256mr = 11645,

        VPMOVWBZ256mrk = 11646,

        VPMOVWBZ256rr = 11647,

        VPMOVWBZ256rrk = 11648,

        VPMOVWBZ256rrkz = 11649,

        VPMOVWBZmr = 11650,

        VPMOVWBZmrk = 11651,

        VPMOVWBZrr = 11652,

        VPMOVWBZrrk = 11653,

        VPMOVWBZrrkz = 11654,

        VPMOVZXBDYrm = 11655,

        VPMOVZXBDYrr = 11656,

        VPMOVZXBDZ128rm = 11657,

        VPMOVZXBDZ128rmk = 11658,

        VPMOVZXBDZ128rmkz = 11659,

        VPMOVZXBDZ128rr = 11660,

        VPMOVZXBDZ128rrk = 11661,

        VPMOVZXBDZ128rrkz = 11662,

        VPMOVZXBDZ256rm = 11663,

        VPMOVZXBDZ256rmk = 11664,

        VPMOVZXBDZ256rmkz = 11665,

        VPMOVZXBDZ256rr = 11666,

        VPMOVZXBDZ256rrk = 11667,

        VPMOVZXBDZ256rrkz = 11668,

        VPMOVZXBDZrm = 11669,

        VPMOVZXBDZrmk = 11670,

        VPMOVZXBDZrmkz = 11671,

        VPMOVZXBDZrr = 11672,

        VPMOVZXBDZrrk = 11673,

        VPMOVZXBDZrrkz = 11674,

        VPMOVZXBDrm = 11675,

        VPMOVZXBDrr = 11676,

        VPMOVZXBQYrm = 11677,

        VPMOVZXBQYrr = 11678,

        VPMOVZXBQZ128rm = 11679,

        VPMOVZXBQZ128rmk = 11680,

        VPMOVZXBQZ128rmkz = 11681,

        VPMOVZXBQZ128rr = 11682,

        VPMOVZXBQZ128rrk = 11683,

        VPMOVZXBQZ128rrkz = 11684,

        VPMOVZXBQZ256rm = 11685,

        VPMOVZXBQZ256rmk = 11686,

        VPMOVZXBQZ256rmkz = 11687,

        VPMOVZXBQZ256rr = 11688,

        VPMOVZXBQZ256rrk = 11689,

        VPMOVZXBQZ256rrkz = 11690,

        VPMOVZXBQZrm = 11691,

        VPMOVZXBQZrmk = 11692,

        VPMOVZXBQZrmkz = 11693,

        VPMOVZXBQZrr = 11694,

        VPMOVZXBQZrrk = 11695,

        VPMOVZXBQZrrkz = 11696,

        VPMOVZXBQrm = 11697,

        VPMOVZXBQrr = 11698,

        VPMOVZXBWYrm = 11699,

        VPMOVZXBWYrr = 11700,

        VPMOVZXBWZ128rm = 11701,

        VPMOVZXBWZ128rmk = 11702,

        VPMOVZXBWZ128rmkz = 11703,

        VPMOVZXBWZ128rr = 11704,

        VPMOVZXBWZ128rrk = 11705,

        VPMOVZXBWZ128rrkz = 11706,

        VPMOVZXBWZ256rm = 11707,

        VPMOVZXBWZ256rmk = 11708,

        VPMOVZXBWZ256rmkz = 11709,

        VPMOVZXBWZ256rr = 11710,

        VPMOVZXBWZ256rrk = 11711,

        VPMOVZXBWZ256rrkz = 11712,

        VPMOVZXBWZrm = 11713,

        VPMOVZXBWZrmk = 11714,

        VPMOVZXBWZrmkz = 11715,

        VPMOVZXBWZrr = 11716,

        VPMOVZXBWZrrk = 11717,

        VPMOVZXBWZrrkz = 11718,

        VPMOVZXBWrm = 11719,

        VPMOVZXBWrr = 11720,

        VPMOVZXDQYrm = 11721,

        VPMOVZXDQYrr = 11722,

        VPMOVZXDQZ128rm = 11723,

        VPMOVZXDQZ128rmk = 11724,

        VPMOVZXDQZ128rmkz = 11725,

        VPMOVZXDQZ128rr = 11726,

        VPMOVZXDQZ128rrk = 11727,

        VPMOVZXDQZ128rrkz = 11728,

        VPMOVZXDQZ256rm = 11729,

        VPMOVZXDQZ256rmk = 11730,

        VPMOVZXDQZ256rmkz = 11731,

        VPMOVZXDQZ256rr = 11732,

        VPMOVZXDQZ256rrk = 11733,

        VPMOVZXDQZ256rrkz = 11734,

        VPMOVZXDQZrm = 11735,

        VPMOVZXDQZrmk = 11736,

        VPMOVZXDQZrmkz = 11737,

        VPMOVZXDQZrr = 11738,

        VPMOVZXDQZrrk = 11739,

        VPMOVZXDQZrrkz = 11740,

        VPMOVZXDQrm = 11741,

        VPMOVZXDQrr = 11742,

        VPMOVZXWDYrm = 11743,

        VPMOVZXWDYrr = 11744,

        VPMOVZXWDZ128rm = 11745,

        VPMOVZXWDZ128rmk = 11746,

        VPMOVZXWDZ128rmkz = 11747,

        VPMOVZXWDZ128rr = 11748,

        VPMOVZXWDZ128rrk = 11749,

        VPMOVZXWDZ128rrkz = 11750,

        VPMOVZXWDZ256rm = 11751,

        VPMOVZXWDZ256rmk = 11752,

        VPMOVZXWDZ256rmkz = 11753,

        VPMOVZXWDZ256rr = 11754,

        VPMOVZXWDZ256rrk = 11755,

        VPMOVZXWDZ256rrkz = 11756,

        VPMOVZXWDZrm = 11757,

        VPMOVZXWDZrmk = 11758,

        VPMOVZXWDZrmkz = 11759,

        VPMOVZXWDZrr = 11760,

        VPMOVZXWDZrrk = 11761,

        VPMOVZXWDZrrkz = 11762,

        VPMOVZXWDrm = 11763,

        VPMOVZXWDrr = 11764,

        VPMOVZXWQYrm = 11765,

        VPMOVZXWQYrr = 11766,

        VPMOVZXWQZ128rm = 11767,

        VPMOVZXWQZ128rmk = 11768,

        VPMOVZXWQZ128rmkz = 11769,

        VPMOVZXWQZ128rr = 11770,

        VPMOVZXWQZ128rrk = 11771,

        VPMOVZXWQZ128rrkz = 11772,

        VPMOVZXWQZ256rm = 11773,

        VPMOVZXWQZ256rmk = 11774,

        VPMOVZXWQZ256rmkz = 11775,

        VPMOVZXWQZ256rr = 11776,

        VPMOVZXWQZ256rrk = 11777,

        VPMOVZXWQZ256rrkz = 11778,

        VPMOVZXWQZrm = 11779,

        VPMOVZXWQZrmk = 11780,

        VPMOVZXWQZrmkz = 11781,

        VPMOVZXWQZrr = 11782,

        VPMOVZXWQZrrk = 11783,

        VPMOVZXWQZrrkz = 11784,

        VPMOVZXWQrm = 11785,

        VPMOVZXWQrr = 11786,

        VPMULDQYrm = 11787,

        VPMULDQYrr = 11788,

        VPMULDQZ128rm = 11789,

        VPMULDQZ128rmb = 11790,

        VPMULDQZ128rmbk = 11791,

        VPMULDQZ128rmbkz = 11792,

        VPMULDQZ128rmk = 11793,

        VPMULDQZ128rmkz = 11794,

        VPMULDQZ128rr = 11795,

        VPMULDQZ128rrk = 11796,

        VPMULDQZ128rrkz = 11797,

        VPMULDQZ256rm = 11798,

        VPMULDQZ256rmb = 11799,

        VPMULDQZ256rmbk = 11800,

        VPMULDQZ256rmbkz = 11801,

        VPMULDQZ256rmk = 11802,

        VPMULDQZ256rmkz = 11803,

        VPMULDQZ256rr = 11804,

        VPMULDQZ256rrk = 11805,

        VPMULDQZ256rrkz = 11806,

        VPMULDQZrm = 11807,

        VPMULDQZrmb = 11808,

        VPMULDQZrmbk = 11809,

        VPMULDQZrmbkz = 11810,

        VPMULDQZrmk = 11811,

        VPMULDQZrmkz = 11812,

        VPMULDQZrr = 11813,

        VPMULDQZrrk = 11814,

        VPMULDQZrrkz = 11815,

        VPMULDQrm = 11816,

        VPMULDQrr = 11817,

        VPMULHRSWYrm = 11818,

        VPMULHRSWYrr = 11819,

        VPMULHRSWZ128rm = 11820,

        VPMULHRSWZ128rmk = 11821,

        VPMULHRSWZ128rmkz = 11822,

        VPMULHRSWZ128rr = 11823,

        VPMULHRSWZ128rrk = 11824,

        VPMULHRSWZ128rrkz = 11825,

        VPMULHRSWZ256rm = 11826,

        VPMULHRSWZ256rmk = 11827,

        VPMULHRSWZ256rmkz = 11828,

        VPMULHRSWZ256rr = 11829,

        VPMULHRSWZ256rrk = 11830,

        VPMULHRSWZ256rrkz = 11831,

        VPMULHRSWZrm = 11832,

        VPMULHRSWZrmk = 11833,

        VPMULHRSWZrmkz = 11834,

        VPMULHRSWZrr = 11835,

        VPMULHRSWZrrk = 11836,

        VPMULHRSWZrrkz = 11837,

        VPMULHRSWrm = 11838,

        VPMULHRSWrr = 11839,

        VPMULHUWYrm = 11840,

        VPMULHUWYrr = 11841,

        VPMULHUWZ128rm = 11842,

        VPMULHUWZ128rmk = 11843,

        VPMULHUWZ128rmkz = 11844,

        VPMULHUWZ128rr = 11845,

        VPMULHUWZ128rrk = 11846,

        VPMULHUWZ128rrkz = 11847,

        VPMULHUWZ256rm = 11848,

        VPMULHUWZ256rmk = 11849,

        VPMULHUWZ256rmkz = 11850,

        VPMULHUWZ256rr = 11851,

        VPMULHUWZ256rrk = 11852,

        VPMULHUWZ256rrkz = 11853,

        VPMULHUWZrm = 11854,

        VPMULHUWZrmk = 11855,

        VPMULHUWZrmkz = 11856,

        VPMULHUWZrr = 11857,

        VPMULHUWZrrk = 11858,

        VPMULHUWZrrkz = 11859,

        VPMULHUWrm = 11860,

        VPMULHUWrr = 11861,

        VPMULHWYrm = 11862,

        VPMULHWYrr = 11863,

        VPMULHWZ128rm = 11864,

        VPMULHWZ128rmk = 11865,

        VPMULHWZ128rmkz = 11866,

        VPMULHWZ128rr = 11867,

        VPMULHWZ128rrk = 11868,

        VPMULHWZ128rrkz = 11869,

        VPMULHWZ256rm = 11870,

        VPMULHWZ256rmk = 11871,

        VPMULHWZ256rmkz = 11872,

        VPMULHWZ256rr = 11873,

        VPMULHWZ256rrk = 11874,

        VPMULHWZ256rrkz = 11875,

        VPMULHWZrm = 11876,

        VPMULHWZrmk = 11877,

        VPMULHWZrmkz = 11878,

        VPMULHWZrr = 11879,

        VPMULHWZrrk = 11880,

        VPMULHWZrrkz = 11881,

        VPMULHWrm = 11882,

        VPMULHWrr = 11883,

        VPMULLDYrm = 11884,

        VPMULLDYrr = 11885,

        VPMULLDZ128rm = 11886,

        VPMULLDZ128rmb = 11887,

        VPMULLDZ128rmbk = 11888,

        VPMULLDZ128rmbkz = 11889,

        VPMULLDZ128rmk = 11890,

        VPMULLDZ128rmkz = 11891,

        VPMULLDZ128rr = 11892,

        VPMULLDZ128rrk = 11893,

        VPMULLDZ128rrkz = 11894,

        VPMULLDZ256rm = 11895,

        VPMULLDZ256rmb = 11896,

        VPMULLDZ256rmbk = 11897,

        VPMULLDZ256rmbkz = 11898,

        VPMULLDZ256rmk = 11899,

        VPMULLDZ256rmkz = 11900,

        VPMULLDZ256rr = 11901,

        VPMULLDZ256rrk = 11902,

        VPMULLDZ256rrkz = 11903,

        VPMULLDZrm = 11904,

        VPMULLDZrmb = 11905,

        VPMULLDZrmbk = 11906,

        VPMULLDZrmbkz = 11907,

        VPMULLDZrmk = 11908,

        VPMULLDZrmkz = 11909,

        VPMULLDZrr = 11910,

        VPMULLDZrrk = 11911,

        VPMULLDZrrkz = 11912,

        VPMULLDrm = 11913,

        VPMULLDrr = 11914,

        VPMULLQZ128rm = 11915,

        VPMULLQZ128rmb = 11916,

        VPMULLQZ128rmbk = 11917,

        VPMULLQZ128rmbkz = 11918,

        VPMULLQZ128rmk = 11919,

        VPMULLQZ128rmkz = 11920,

        VPMULLQZ128rr = 11921,

        VPMULLQZ128rrk = 11922,

        VPMULLQZ128rrkz = 11923,

        VPMULLQZ256rm = 11924,

        VPMULLQZ256rmb = 11925,

        VPMULLQZ256rmbk = 11926,

        VPMULLQZ256rmbkz = 11927,

        VPMULLQZ256rmk = 11928,

        VPMULLQZ256rmkz = 11929,

        VPMULLQZ256rr = 11930,

        VPMULLQZ256rrk = 11931,

        VPMULLQZ256rrkz = 11932,

        VPMULLQZrm = 11933,

        VPMULLQZrmb = 11934,

        VPMULLQZrmbk = 11935,

        VPMULLQZrmbkz = 11936,

        VPMULLQZrmk = 11937,

        VPMULLQZrmkz = 11938,

        VPMULLQZrr = 11939,

        VPMULLQZrrk = 11940,

        VPMULLQZrrkz = 11941,

        VPMULLWYrm = 11942,

        VPMULLWYrr = 11943,

        VPMULLWZ128rm = 11944,

        VPMULLWZ128rmk = 11945,

        VPMULLWZ128rmkz = 11946,

        VPMULLWZ128rr = 11947,

        VPMULLWZ128rrk = 11948,

        VPMULLWZ128rrkz = 11949,

        VPMULLWZ256rm = 11950,

        VPMULLWZ256rmk = 11951,

        VPMULLWZ256rmkz = 11952,

        VPMULLWZ256rr = 11953,

        VPMULLWZ256rrk = 11954,

        VPMULLWZ256rrkz = 11955,

        VPMULLWZrm = 11956,

        VPMULLWZrmk = 11957,

        VPMULLWZrmkz = 11958,

        VPMULLWZrr = 11959,

        VPMULLWZrrk = 11960,

        VPMULLWZrrkz = 11961,

        VPMULLWrm = 11962,

        VPMULLWrr = 11963,

        VPMULTISHIFTQBZ128rm = 11964,

        VPMULTISHIFTQBZ128rmb = 11965,

        VPMULTISHIFTQBZ128rmbk = 11966,

        VPMULTISHIFTQBZ128rmbkz = 11967,

        VPMULTISHIFTQBZ128rmk = 11968,

        VPMULTISHIFTQBZ128rmkz = 11969,

        VPMULTISHIFTQBZ128rr = 11970,

        VPMULTISHIFTQBZ128rrk = 11971,

        VPMULTISHIFTQBZ128rrkz = 11972,

        VPMULTISHIFTQBZ256rm = 11973,

        VPMULTISHIFTQBZ256rmb = 11974,

        VPMULTISHIFTQBZ256rmbk = 11975,

        VPMULTISHIFTQBZ256rmbkz = 11976,

        VPMULTISHIFTQBZ256rmk = 11977,

        VPMULTISHIFTQBZ256rmkz = 11978,

        VPMULTISHIFTQBZ256rr = 11979,

        VPMULTISHIFTQBZ256rrk = 11980,

        VPMULTISHIFTQBZ256rrkz = 11981,

        VPMULTISHIFTQBZrm = 11982,

        VPMULTISHIFTQBZrmb = 11983,

        VPMULTISHIFTQBZrmbk = 11984,

        VPMULTISHIFTQBZrmbkz = 11985,

        VPMULTISHIFTQBZrmk = 11986,

        VPMULTISHIFTQBZrmkz = 11987,

        VPMULTISHIFTQBZrr = 11988,

        VPMULTISHIFTQBZrrk = 11989,

        VPMULTISHIFTQBZrrkz = 11990,

        VPMULUDQYrm = 11991,

        VPMULUDQYrr = 11992,

        VPMULUDQZ128rm = 11993,

        VPMULUDQZ128rmb = 11994,

        VPMULUDQZ128rmbk = 11995,

        VPMULUDQZ128rmbkz = 11996,

        VPMULUDQZ128rmk = 11997,

        VPMULUDQZ128rmkz = 11998,

        VPMULUDQZ128rr = 11999,

        VPMULUDQZ128rrk = 12000,

        VPMULUDQZ128rrkz = 12001,

        VPMULUDQZ256rm = 12002,

        VPMULUDQZ256rmb = 12003,

        VPMULUDQZ256rmbk = 12004,

        VPMULUDQZ256rmbkz = 12005,

        VPMULUDQZ256rmk = 12006,

        VPMULUDQZ256rmkz = 12007,

        VPMULUDQZ256rr = 12008,

        VPMULUDQZ256rrk = 12009,

        VPMULUDQZ256rrkz = 12010,

        VPMULUDQZrm = 12011,

        VPMULUDQZrmb = 12012,

        VPMULUDQZrmbk = 12013,

        VPMULUDQZrmbkz = 12014,

        VPMULUDQZrmk = 12015,

        VPMULUDQZrmkz = 12016,

        VPMULUDQZrr = 12017,

        VPMULUDQZrrk = 12018,

        VPMULUDQZrrkz = 12019,

        VPMULUDQrm = 12020,

        VPMULUDQrr = 12021,

        VPOPCNTBZ128rm = 12022,

        VPOPCNTBZ128rmk = 12023,

        VPOPCNTBZ128rmkz = 12024,

        VPOPCNTBZ128rr = 12025,

        VPOPCNTBZ128rrk = 12026,

        VPOPCNTBZ128rrkz = 12027,

        VPOPCNTBZ256rm = 12028,

        VPOPCNTBZ256rmk = 12029,

        VPOPCNTBZ256rmkz = 12030,

        VPOPCNTBZ256rr = 12031,

        VPOPCNTBZ256rrk = 12032,

        VPOPCNTBZ256rrkz = 12033,

        VPOPCNTBZrm = 12034,

        VPOPCNTBZrmk = 12035,

        VPOPCNTBZrmkz = 12036,

        VPOPCNTBZrr = 12037,

        VPOPCNTBZrrk = 12038,

        VPOPCNTBZrrkz = 12039,

        VPOPCNTDZ128rm = 12040,

        VPOPCNTDZ128rmb = 12041,

        VPOPCNTDZ128rmbk = 12042,

        VPOPCNTDZ128rmbkz = 12043,

        VPOPCNTDZ128rmk = 12044,

        VPOPCNTDZ128rmkz = 12045,

        VPOPCNTDZ128rr = 12046,

        VPOPCNTDZ128rrk = 12047,

        VPOPCNTDZ128rrkz = 12048,

        VPOPCNTDZ256rm = 12049,

        VPOPCNTDZ256rmb = 12050,

        VPOPCNTDZ256rmbk = 12051,

        VPOPCNTDZ256rmbkz = 12052,

        VPOPCNTDZ256rmk = 12053,

        VPOPCNTDZ256rmkz = 12054,

        VPOPCNTDZ256rr = 12055,

        VPOPCNTDZ256rrk = 12056,

        VPOPCNTDZ256rrkz = 12057,

        VPOPCNTDZrm = 12058,

        VPOPCNTDZrmb = 12059,

        VPOPCNTDZrmbk = 12060,

        VPOPCNTDZrmbkz = 12061,

        VPOPCNTDZrmk = 12062,

        VPOPCNTDZrmkz = 12063,

        VPOPCNTDZrr = 12064,

        VPOPCNTDZrrk = 12065,

        VPOPCNTDZrrkz = 12066,

        VPOPCNTQZ128rm = 12067,

        VPOPCNTQZ128rmb = 12068,

        VPOPCNTQZ128rmbk = 12069,

        VPOPCNTQZ128rmbkz = 12070,

        VPOPCNTQZ128rmk = 12071,

        VPOPCNTQZ128rmkz = 12072,

        VPOPCNTQZ128rr = 12073,

        VPOPCNTQZ128rrk = 12074,

        VPOPCNTQZ128rrkz = 12075,

        VPOPCNTQZ256rm = 12076,

        VPOPCNTQZ256rmb = 12077,

        VPOPCNTQZ256rmbk = 12078,

        VPOPCNTQZ256rmbkz = 12079,

        VPOPCNTQZ256rmk = 12080,

        VPOPCNTQZ256rmkz = 12081,

        VPOPCNTQZ256rr = 12082,

        VPOPCNTQZ256rrk = 12083,

        VPOPCNTQZ256rrkz = 12084,

        VPOPCNTQZrm = 12085,

        VPOPCNTQZrmb = 12086,

        VPOPCNTQZrmbk = 12087,

        VPOPCNTQZrmbkz = 12088,

        VPOPCNTQZrmk = 12089,

        VPOPCNTQZrmkz = 12090,

        VPOPCNTQZrr = 12091,

        VPOPCNTQZrrk = 12092,

        VPOPCNTQZrrkz = 12093,

        VPOPCNTWZ128rm = 12094,

        VPOPCNTWZ128rmk = 12095,

        VPOPCNTWZ128rmkz = 12096,

        VPOPCNTWZ128rr = 12097,

        VPOPCNTWZ128rrk = 12098,

        VPOPCNTWZ128rrkz = 12099,

        VPOPCNTWZ256rm = 12100,

        VPOPCNTWZ256rmk = 12101,

        VPOPCNTWZ256rmkz = 12102,

        VPOPCNTWZ256rr = 12103,

        VPOPCNTWZ256rrk = 12104,

        VPOPCNTWZ256rrkz = 12105,

        VPOPCNTWZrm = 12106,

        VPOPCNTWZrmk = 12107,

        VPOPCNTWZrmkz = 12108,

        VPOPCNTWZrr = 12109,

        VPOPCNTWZrrk = 12110,

        VPOPCNTWZrrkz = 12111,

        VPORDZ128rm = 12112,

        VPORDZ128rmb = 12113,

        VPORDZ128rmbk = 12114,

        VPORDZ128rmbkz = 12115,

        VPORDZ128rmk = 12116,

        VPORDZ128rmkz = 12117,

        VPORDZ128rr = 12118,

        VPORDZ128rrk = 12119,

        VPORDZ128rrkz = 12120,

        VPORDZ256rm = 12121,

        VPORDZ256rmb = 12122,

        VPORDZ256rmbk = 12123,

        VPORDZ256rmbkz = 12124,

        VPORDZ256rmk = 12125,

        VPORDZ256rmkz = 12126,

        VPORDZ256rr = 12127,

        VPORDZ256rrk = 12128,

        VPORDZ256rrkz = 12129,

        VPORDZrm = 12130,

        VPORDZrmb = 12131,

        VPORDZrmbk = 12132,

        VPORDZrmbkz = 12133,

        VPORDZrmk = 12134,

        VPORDZrmkz = 12135,

        VPORDZrr = 12136,

        VPORDZrrk = 12137,

        VPORDZrrkz = 12138,

        VPORQZ128rm = 12139,

        VPORQZ128rmb = 12140,

        VPORQZ128rmbk = 12141,

        VPORQZ128rmbkz = 12142,

        VPORQZ128rmk = 12143,

        VPORQZ128rmkz = 12144,

        VPORQZ128rr = 12145,

        VPORQZ128rrk = 12146,

        VPORQZ128rrkz = 12147,

        VPORQZ256rm = 12148,

        VPORQZ256rmb = 12149,

        VPORQZ256rmbk = 12150,

        VPORQZ256rmbkz = 12151,

        VPORQZ256rmk = 12152,

        VPORQZ256rmkz = 12153,

        VPORQZ256rr = 12154,

        VPORQZ256rrk = 12155,

        VPORQZ256rrkz = 12156,

        VPORQZrm = 12157,

        VPORQZrmb = 12158,

        VPORQZrmbk = 12159,

        VPORQZrmbkz = 12160,

        VPORQZrmk = 12161,

        VPORQZrmkz = 12162,

        VPORQZrr = 12163,

        VPORQZrrk = 12164,

        VPORQZrrkz = 12165,

        VPORYrm = 12166,

        VPORYrr = 12167,

        VPORrm = 12168,

        VPORrr = 12169,

        VPPERMrmr = 12170,

        VPPERMrrm = 12171,

        VPPERMrrr = 12172,

        VPPERMrrr_REV = 12173,

        VPROLDZ128mbi = 12174,

        VPROLDZ128mbik = 12175,

        VPROLDZ128mbikz = 12176,

        VPROLDZ128mi = 12177,

        VPROLDZ128mik = 12178,

        VPROLDZ128mikz = 12179,

        VPROLDZ128ri = 12180,

        VPROLDZ128rik = 12181,

        VPROLDZ128rikz = 12182,

        VPROLDZ256mbi = 12183,

        VPROLDZ256mbik = 12184,

        VPROLDZ256mbikz = 12185,

        VPROLDZ256mi = 12186,

        VPROLDZ256mik = 12187,

        VPROLDZ256mikz = 12188,

        VPROLDZ256ri = 12189,

        VPROLDZ256rik = 12190,

        VPROLDZ256rikz = 12191,

        VPROLDZmbi = 12192,

        VPROLDZmbik = 12193,

        VPROLDZmbikz = 12194,

        VPROLDZmi = 12195,

        VPROLDZmik = 12196,

        VPROLDZmikz = 12197,

        VPROLDZri = 12198,

        VPROLDZrik = 12199,

        VPROLDZrikz = 12200,

        VPROLQZ128mbi = 12201,

        VPROLQZ128mbik = 12202,

        VPROLQZ128mbikz = 12203,

        VPROLQZ128mi = 12204,

        VPROLQZ128mik = 12205,

        VPROLQZ128mikz = 12206,

        VPROLQZ128ri = 12207,

        VPROLQZ128rik = 12208,

        VPROLQZ128rikz = 12209,

        VPROLQZ256mbi = 12210,

        VPROLQZ256mbik = 12211,

        VPROLQZ256mbikz = 12212,

        VPROLQZ256mi = 12213,

        VPROLQZ256mik = 12214,

        VPROLQZ256mikz = 12215,

        VPROLQZ256ri = 12216,

        VPROLQZ256rik = 12217,

        VPROLQZ256rikz = 12218,

        VPROLQZmbi = 12219,

        VPROLQZmbik = 12220,

        VPROLQZmbikz = 12221,

        VPROLQZmi = 12222,

        VPROLQZmik = 12223,

        VPROLQZmikz = 12224,

        VPROLQZri = 12225,

        VPROLQZrik = 12226,

        VPROLQZrikz = 12227,

        VPROLVDZ128rm = 12228,

        VPROLVDZ128rmb = 12229,

        VPROLVDZ128rmbk = 12230,

        VPROLVDZ128rmbkz = 12231,

        VPROLVDZ128rmk = 12232,

        VPROLVDZ128rmkz = 12233,

        VPROLVDZ128rr = 12234,

        VPROLVDZ128rrk = 12235,

        VPROLVDZ128rrkz = 12236,

        VPROLVDZ256rm = 12237,

        VPROLVDZ256rmb = 12238,

        VPROLVDZ256rmbk = 12239,

        VPROLVDZ256rmbkz = 12240,

        VPROLVDZ256rmk = 12241,

        VPROLVDZ256rmkz = 12242,

        VPROLVDZ256rr = 12243,

        VPROLVDZ256rrk = 12244,

        VPROLVDZ256rrkz = 12245,

        VPROLVDZrm = 12246,

        VPROLVDZrmb = 12247,

        VPROLVDZrmbk = 12248,

        VPROLVDZrmbkz = 12249,

        VPROLVDZrmk = 12250,

        VPROLVDZrmkz = 12251,

        VPROLVDZrr = 12252,

        VPROLVDZrrk = 12253,

        VPROLVDZrrkz = 12254,

        VPROLVQZ128rm = 12255,

        VPROLVQZ128rmb = 12256,

        VPROLVQZ128rmbk = 12257,

        VPROLVQZ128rmbkz = 12258,

        VPROLVQZ128rmk = 12259,

        VPROLVQZ128rmkz = 12260,

        VPROLVQZ128rr = 12261,

        VPROLVQZ128rrk = 12262,

        VPROLVQZ128rrkz = 12263,

        VPROLVQZ256rm = 12264,

        VPROLVQZ256rmb = 12265,

        VPROLVQZ256rmbk = 12266,

        VPROLVQZ256rmbkz = 12267,

        VPROLVQZ256rmk = 12268,

        VPROLVQZ256rmkz = 12269,

        VPROLVQZ256rr = 12270,

        VPROLVQZ256rrk = 12271,

        VPROLVQZ256rrkz = 12272,

        VPROLVQZrm = 12273,

        VPROLVQZrmb = 12274,

        VPROLVQZrmbk = 12275,

        VPROLVQZrmbkz = 12276,

        VPROLVQZrmk = 12277,

        VPROLVQZrmkz = 12278,

        VPROLVQZrr = 12279,

        VPROLVQZrrk = 12280,

        VPROLVQZrrkz = 12281,

        VPRORDZ128mbi = 12282,

        VPRORDZ128mbik = 12283,

        VPRORDZ128mbikz = 12284,

        VPRORDZ128mi = 12285,

        VPRORDZ128mik = 12286,

        VPRORDZ128mikz = 12287,

        VPRORDZ128ri = 12288,

        VPRORDZ128rik = 12289,

        VPRORDZ128rikz = 12290,

        VPRORDZ256mbi = 12291,

        VPRORDZ256mbik = 12292,

        VPRORDZ256mbikz = 12293,

        VPRORDZ256mi = 12294,

        VPRORDZ256mik = 12295,

        VPRORDZ256mikz = 12296,

        VPRORDZ256ri = 12297,

        VPRORDZ256rik = 12298,

        VPRORDZ256rikz = 12299,

        VPRORDZmbi = 12300,

        VPRORDZmbik = 12301,

        VPRORDZmbikz = 12302,

        VPRORDZmi = 12303,

        VPRORDZmik = 12304,

        VPRORDZmikz = 12305,

        VPRORDZri = 12306,

        VPRORDZrik = 12307,

        VPRORDZrikz = 12308,

        VPRORQZ128mbi = 12309,

        VPRORQZ128mbik = 12310,

        VPRORQZ128mbikz = 12311,

        VPRORQZ128mi = 12312,

        VPRORQZ128mik = 12313,

        VPRORQZ128mikz = 12314,

        VPRORQZ128ri = 12315,

        VPRORQZ128rik = 12316,

        VPRORQZ128rikz = 12317,

        VPRORQZ256mbi = 12318,

        VPRORQZ256mbik = 12319,

        VPRORQZ256mbikz = 12320,

        VPRORQZ256mi = 12321,

        VPRORQZ256mik = 12322,

        VPRORQZ256mikz = 12323,

        VPRORQZ256ri = 12324,

        VPRORQZ256rik = 12325,

        VPRORQZ256rikz = 12326,

        VPRORQZmbi = 12327,

        VPRORQZmbik = 12328,

        VPRORQZmbikz = 12329,

        VPRORQZmi = 12330,

        VPRORQZmik = 12331,

        VPRORQZmikz = 12332,

        VPRORQZri = 12333,

        VPRORQZrik = 12334,

        VPRORQZrikz = 12335,

        VPRORVDZ128rm = 12336,

        VPRORVDZ128rmb = 12337,

        VPRORVDZ128rmbk = 12338,

        VPRORVDZ128rmbkz = 12339,

        VPRORVDZ128rmk = 12340,

        VPRORVDZ128rmkz = 12341,

        VPRORVDZ128rr = 12342,

        VPRORVDZ128rrk = 12343,

        VPRORVDZ128rrkz = 12344,

        VPRORVDZ256rm = 12345,

        VPRORVDZ256rmb = 12346,

        VPRORVDZ256rmbk = 12347,

        VPRORVDZ256rmbkz = 12348,

        VPRORVDZ256rmk = 12349,

        VPRORVDZ256rmkz = 12350,

        VPRORVDZ256rr = 12351,

        VPRORVDZ256rrk = 12352,

        VPRORVDZ256rrkz = 12353,

        VPRORVDZrm = 12354,

        VPRORVDZrmb = 12355,

        VPRORVDZrmbk = 12356,

        VPRORVDZrmbkz = 12357,

        VPRORVDZrmk = 12358,

        VPRORVDZrmkz = 12359,

        VPRORVDZrr = 12360,

        VPRORVDZrrk = 12361,

        VPRORVDZrrkz = 12362,

        VPRORVQZ128rm = 12363,

        VPRORVQZ128rmb = 12364,

        VPRORVQZ128rmbk = 12365,

        VPRORVQZ128rmbkz = 12366,

        VPRORVQZ128rmk = 12367,

        VPRORVQZ128rmkz = 12368,

        VPRORVQZ128rr = 12369,

        VPRORVQZ128rrk = 12370,

        VPRORVQZ128rrkz = 12371,

        VPRORVQZ256rm = 12372,

        VPRORVQZ256rmb = 12373,

        VPRORVQZ256rmbk = 12374,

        VPRORVQZ256rmbkz = 12375,

        VPRORVQZ256rmk = 12376,

        VPRORVQZ256rmkz = 12377,

        VPRORVQZ256rr = 12378,

        VPRORVQZ256rrk = 12379,

        VPRORVQZ256rrkz = 12380,

        VPRORVQZrm = 12381,

        VPRORVQZrmb = 12382,

        VPRORVQZrmbk = 12383,

        VPRORVQZrmbkz = 12384,

        VPRORVQZrmk = 12385,

        VPRORVQZrmkz = 12386,

        VPRORVQZrr = 12387,

        VPRORVQZrrk = 12388,

        VPRORVQZrrkz = 12389,

        VPROTBmi = 12390,

        VPROTBmr = 12391,

        VPROTBri = 12392,

        VPROTBrm = 12393,

        VPROTBrr = 12394,

        VPROTBrr_REV = 12395,

        VPROTDmi = 12396,

        VPROTDmr = 12397,

        VPROTDri = 12398,

        VPROTDrm = 12399,

        VPROTDrr = 12400,

        VPROTDrr_REV = 12401,

        VPROTQmi = 12402,

        VPROTQmr = 12403,

        VPROTQri = 12404,

        VPROTQrm = 12405,

        VPROTQrr = 12406,

        VPROTQrr_REV = 12407,

        VPROTWmi = 12408,

        VPROTWmr = 12409,

        VPROTWri = 12410,

        VPROTWrm = 12411,

        VPROTWrr = 12412,

        VPROTWrr_REV = 12413,

        VPSADBWYrm = 12414,

        VPSADBWYrr = 12415,

        VPSADBWZ128rm = 12416,

        VPSADBWZ128rr = 12417,

        VPSADBWZ256rm = 12418,

        VPSADBWZ256rr = 12419,

        VPSADBWZrm = 12420,

        VPSADBWZrr = 12421,

        VPSADBWrm = 12422,

        VPSADBWrr = 12423,

        VPSCATTERDDZ128mr = 12424,

        VPSCATTERDDZ256mr = 12425,

        VPSCATTERDDZmr = 12426,

        VPSCATTERDQZ128mr = 12427,

        VPSCATTERDQZ256mr = 12428,

        VPSCATTERDQZmr = 12429,

        VPSCATTERQDZ128mr = 12430,

        VPSCATTERQDZ256mr = 12431,

        VPSCATTERQDZmr = 12432,

        VPSCATTERQQZ128mr = 12433,

        VPSCATTERQQZ256mr = 12434,

        VPSCATTERQQZmr = 12435,

        VPSHABmr = 12436,

        VPSHABrm = 12437,

        VPSHABrr = 12438,

        VPSHABrr_REV = 12439,

        VPSHADmr = 12440,

        VPSHADrm = 12441,

        VPSHADrr = 12442,

        VPSHADrr_REV = 12443,

        VPSHAQmr = 12444,

        VPSHAQrm = 12445,

        VPSHAQrr = 12446,

        VPSHAQrr_REV = 12447,

        VPSHAWmr = 12448,

        VPSHAWrm = 12449,

        VPSHAWrr = 12450,

        VPSHAWrr_REV = 12451,

        VPSHLBmr = 12452,

        VPSHLBrm = 12453,

        VPSHLBrr = 12454,

        VPSHLBrr_REV = 12455,

        VPSHLDDZ128rmbi = 12456,

        VPSHLDDZ128rmbik = 12457,

        VPSHLDDZ128rmbikz = 12458,

        VPSHLDDZ128rmi = 12459,

        VPSHLDDZ128rmik = 12460,

        VPSHLDDZ128rmikz = 12461,

        VPSHLDDZ128rri = 12462,

        VPSHLDDZ128rrik = 12463,

        VPSHLDDZ128rrikz = 12464,

        VPSHLDDZ256rmbi = 12465,

        VPSHLDDZ256rmbik = 12466,

        VPSHLDDZ256rmbikz = 12467,

        VPSHLDDZ256rmi = 12468,

        VPSHLDDZ256rmik = 12469,

        VPSHLDDZ256rmikz = 12470,

        VPSHLDDZ256rri = 12471,

        VPSHLDDZ256rrik = 12472,

        VPSHLDDZ256rrikz = 12473,

        VPSHLDDZrmbi = 12474,

        VPSHLDDZrmbik = 12475,

        VPSHLDDZrmbikz = 12476,

        VPSHLDDZrmi = 12477,

        VPSHLDDZrmik = 12478,

        VPSHLDDZrmikz = 12479,

        VPSHLDDZrri = 12480,

        VPSHLDDZrrik = 12481,

        VPSHLDDZrrikz = 12482,

        VPSHLDQZ128rmbi = 12483,

        VPSHLDQZ128rmbik = 12484,

        VPSHLDQZ128rmbikz = 12485,

        VPSHLDQZ128rmi = 12486,

        VPSHLDQZ128rmik = 12487,

        VPSHLDQZ128rmikz = 12488,

        VPSHLDQZ128rri = 12489,

        VPSHLDQZ128rrik = 12490,

        VPSHLDQZ128rrikz = 12491,

        VPSHLDQZ256rmbi = 12492,

        VPSHLDQZ256rmbik = 12493,

        VPSHLDQZ256rmbikz = 12494,

        VPSHLDQZ256rmi = 12495,

        VPSHLDQZ256rmik = 12496,

        VPSHLDQZ256rmikz = 12497,

        VPSHLDQZ256rri = 12498,

        VPSHLDQZ256rrik = 12499,

        VPSHLDQZ256rrikz = 12500,

        VPSHLDQZrmbi = 12501,

        VPSHLDQZrmbik = 12502,

        VPSHLDQZrmbikz = 12503,

        VPSHLDQZrmi = 12504,

        VPSHLDQZrmik = 12505,

        VPSHLDQZrmikz = 12506,

        VPSHLDQZrri = 12507,

        VPSHLDQZrrik = 12508,

        VPSHLDQZrrikz = 12509,

        VPSHLDVDZ128m = 12510,

        VPSHLDVDZ128mb = 12511,

        VPSHLDVDZ128mbk = 12512,

        VPSHLDVDZ128mbkz = 12513,

        VPSHLDVDZ128mk = 12514,

        VPSHLDVDZ128mkz = 12515,

        VPSHLDVDZ128r = 12516,

        VPSHLDVDZ128rk = 12517,

        VPSHLDVDZ128rkz = 12518,

        VPSHLDVDZ256m = 12519,

        VPSHLDVDZ256mb = 12520,

        VPSHLDVDZ256mbk = 12521,

        VPSHLDVDZ256mbkz = 12522,

        VPSHLDVDZ256mk = 12523,

        VPSHLDVDZ256mkz = 12524,

        VPSHLDVDZ256r = 12525,

        VPSHLDVDZ256rk = 12526,

        VPSHLDVDZ256rkz = 12527,

        VPSHLDVDZm = 12528,

        VPSHLDVDZmb = 12529,

        VPSHLDVDZmbk = 12530,

        VPSHLDVDZmbkz = 12531,

        VPSHLDVDZmk = 12532,

        VPSHLDVDZmkz = 12533,

        VPSHLDVDZr = 12534,

        VPSHLDVDZrk = 12535,

        VPSHLDVDZrkz = 12536,

        VPSHLDVQZ128m = 12537,

        VPSHLDVQZ128mb = 12538,

        VPSHLDVQZ128mbk = 12539,

        VPSHLDVQZ128mbkz = 12540,

        VPSHLDVQZ128mk = 12541,

        VPSHLDVQZ128mkz = 12542,

        VPSHLDVQZ128r = 12543,

        VPSHLDVQZ128rk = 12544,

        VPSHLDVQZ128rkz = 12545,

        VPSHLDVQZ256m = 12546,

        VPSHLDVQZ256mb = 12547,

        VPSHLDVQZ256mbk = 12548,

        VPSHLDVQZ256mbkz = 12549,

        VPSHLDVQZ256mk = 12550,

        VPSHLDVQZ256mkz = 12551,

        VPSHLDVQZ256r = 12552,

        VPSHLDVQZ256rk = 12553,

        VPSHLDVQZ256rkz = 12554,

        VPSHLDVQZm = 12555,

        VPSHLDVQZmb = 12556,

        VPSHLDVQZmbk = 12557,

        VPSHLDVQZmbkz = 12558,

        VPSHLDVQZmk = 12559,

        VPSHLDVQZmkz = 12560,

        VPSHLDVQZr = 12561,

        VPSHLDVQZrk = 12562,

        VPSHLDVQZrkz = 12563,

        VPSHLDVWZ128m = 12564,

        VPSHLDVWZ128mk = 12565,

        VPSHLDVWZ128mkz = 12566,

        VPSHLDVWZ128r = 12567,

        VPSHLDVWZ128rk = 12568,

        VPSHLDVWZ128rkz = 12569,

        VPSHLDVWZ256m = 12570,

        VPSHLDVWZ256mk = 12571,

        VPSHLDVWZ256mkz = 12572,

        VPSHLDVWZ256r = 12573,

        VPSHLDVWZ256rk = 12574,

        VPSHLDVWZ256rkz = 12575,

        VPSHLDVWZm = 12576,

        VPSHLDVWZmk = 12577,

        VPSHLDVWZmkz = 12578,

        VPSHLDVWZr = 12579,

        VPSHLDVWZrk = 12580,

        VPSHLDVWZrkz = 12581,

        VPSHLDWZ128rmi = 12582,

        VPSHLDWZ128rmik = 12583,

        VPSHLDWZ128rmikz = 12584,

        VPSHLDWZ128rri = 12585,

        VPSHLDWZ128rrik = 12586,

        VPSHLDWZ128rrikz = 12587,

        VPSHLDWZ256rmi = 12588,

        VPSHLDWZ256rmik = 12589,

        VPSHLDWZ256rmikz = 12590,

        VPSHLDWZ256rri = 12591,

        VPSHLDWZ256rrik = 12592,

        VPSHLDWZ256rrikz = 12593,

        VPSHLDWZrmi = 12594,

        VPSHLDWZrmik = 12595,

        VPSHLDWZrmikz = 12596,

        VPSHLDWZrri = 12597,

        VPSHLDWZrrik = 12598,

        VPSHLDWZrrikz = 12599,

        VPSHLDmr = 12600,

        VPSHLDrm = 12601,

        VPSHLDrr = 12602,

        VPSHLDrr_REV = 12603,

        VPSHLQmr = 12604,

        VPSHLQrm = 12605,

        VPSHLQrr = 12606,

        VPSHLQrr_REV = 12607,

        VPSHLWmr = 12608,

        VPSHLWrm = 12609,

        VPSHLWrr = 12610,

        VPSHLWrr_REV = 12611,

        VPSHRDDZ128rmbi = 12612,

        VPSHRDDZ128rmbik = 12613,

        VPSHRDDZ128rmbikz = 12614,

        VPSHRDDZ128rmi = 12615,

        VPSHRDDZ128rmik = 12616,

        VPSHRDDZ128rmikz = 12617,

        VPSHRDDZ128rri = 12618,

        VPSHRDDZ128rrik = 12619,

        VPSHRDDZ128rrikz = 12620,

        VPSHRDDZ256rmbi = 12621,

        VPSHRDDZ256rmbik = 12622,

        VPSHRDDZ256rmbikz = 12623,

        VPSHRDDZ256rmi = 12624,

        VPSHRDDZ256rmik = 12625,

        VPSHRDDZ256rmikz = 12626,

        VPSHRDDZ256rri = 12627,

        VPSHRDDZ256rrik = 12628,

        VPSHRDDZ256rrikz = 12629,

        VPSHRDDZrmbi = 12630,

        VPSHRDDZrmbik = 12631,

        VPSHRDDZrmbikz = 12632,

        VPSHRDDZrmi = 12633,

        VPSHRDDZrmik = 12634,

        VPSHRDDZrmikz = 12635,

        VPSHRDDZrri = 12636,

        VPSHRDDZrrik = 12637,

        VPSHRDDZrrikz = 12638,

        VPSHRDQZ128rmbi = 12639,

        VPSHRDQZ128rmbik = 12640,

        VPSHRDQZ128rmbikz = 12641,

        VPSHRDQZ128rmi = 12642,

        VPSHRDQZ128rmik = 12643,

        VPSHRDQZ128rmikz = 12644,

        VPSHRDQZ128rri = 12645,

        VPSHRDQZ128rrik = 12646,

        VPSHRDQZ128rrikz = 12647,

        VPSHRDQZ256rmbi = 12648,

        VPSHRDQZ256rmbik = 12649,

        VPSHRDQZ256rmbikz = 12650,

        VPSHRDQZ256rmi = 12651,

        VPSHRDQZ256rmik = 12652,

        VPSHRDQZ256rmikz = 12653,

        VPSHRDQZ256rri = 12654,

        VPSHRDQZ256rrik = 12655,

        VPSHRDQZ256rrikz = 12656,

        VPSHRDQZrmbi = 12657,

        VPSHRDQZrmbik = 12658,

        VPSHRDQZrmbikz = 12659,

        VPSHRDQZrmi = 12660,

        VPSHRDQZrmik = 12661,

        VPSHRDQZrmikz = 12662,

        VPSHRDQZrri = 12663,

        VPSHRDQZrrik = 12664,

        VPSHRDQZrrikz = 12665,

        VPSHRDVDZ128m = 12666,

        VPSHRDVDZ128mb = 12667,

        VPSHRDVDZ128mbk = 12668,

        VPSHRDVDZ128mbkz = 12669,

        VPSHRDVDZ128mk = 12670,

        VPSHRDVDZ128mkz = 12671,

        VPSHRDVDZ128r = 12672,

        VPSHRDVDZ128rk = 12673,

        VPSHRDVDZ128rkz = 12674,

        VPSHRDVDZ256m = 12675,

        VPSHRDVDZ256mb = 12676,

        VPSHRDVDZ256mbk = 12677,

        VPSHRDVDZ256mbkz = 12678,

        VPSHRDVDZ256mk = 12679,

        VPSHRDVDZ256mkz = 12680,

        VPSHRDVDZ256r = 12681,

        VPSHRDVDZ256rk = 12682,

        VPSHRDVDZ256rkz = 12683,

        VPSHRDVDZm = 12684,

        VPSHRDVDZmb = 12685,

        VPSHRDVDZmbk = 12686,

        VPSHRDVDZmbkz = 12687,

        VPSHRDVDZmk = 12688,

        VPSHRDVDZmkz = 12689,

        VPSHRDVDZr = 12690,

        VPSHRDVDZrk = 12691,

        VPSHRDVDZrkz = 12692,

        VPSHRDVQZ128m = 12693,

        VPSHRDVQZ128mb = 12694,

        VPSHRDVQZ128mbk = 12695,

        VPSHRDVQZ128mbkz = 12696,

        VPSHRDVQZ128mk = 12697,

        VPSHRDVQZ128mkz = 12698,

        VPSHRDVQZ128r = 12699,

        VPSHRDVQZ128rk = 12700,

        VPSHRDVQZ128rkz = 12701,

        VPSHRDVQZ256m = 12702,

        VPSHRDVQZ256mb = 12703,

        VPSHRDVQZ256mbk = 12704,

        VPSHRDVQZ256mbkz = 12705,

        VPSHRDVQZ256mk = 12706,

        VPSHRDVQZ256mkz = 12707,

        VPSHRDVQZ256r = 12708,

        VPSHRDVQZ256rk = 12709,

        VPSHRDVQZ256rkz = 12710,

        VPSHRDVQZm = 12711,

        VPSHRDVQZmb = 12712,

        VPSHRDVQZmbk = 12713,

        VPSHRDVQZmbkz = 12714,

        VPSHRDVQZmk = 12715,

        VPSHRDVQZmkz = 12716,

        VPSHRDVQZr = 12717,

        VPSHRDVQZrk = 12718,

        VPSHRDVQZrkz = 12719,

        VPSHRDVWZ128m = 12720,

        VPSHRDVWZ128mk = 12721,

        VPSHRDVWZ128mkz = 12722,

        VPSHRDVWZ128r = 12723,

        VPSHRDVWZ128rk = 12724,

        VPSHRDVWZ128rkz = 12725,

        VPSHRDVWZ256m = 12726,

        VPSHRDVWZ256mk = 12727,

        VPSHRDVWZ256mkz = 12728,

        VPSHRDVWZ256r = 12729,

        VPSHRDVWZ256rk = 12730,

        VPSHRDVWZ256rkz = 12731,

        VPSHRDVWZm = 12732,

        VPSHRDVWZmk = 12733,

        VPSHRDVWZmkz = 12734,

        VPSHRDVWZr = 12735,

        VPSHRDVWZrk = 12736,

        VPSHRDVWZrkz = 12737,

        VPSHRDWZ128rmi = 12738,

        VPSHRDWZ128rmik = 12739,

        VPSHRDWZ128rmikz = 12740,

        VPSHRDWZ128rri = 12741,

        VPSHRDWZ128rrik = 12742,

        VPSHRDWZ128rrikz = 12743,

        VPSHRDWZ256rmi = 12744,

        VPSHRDWZ256rmik = 12745,

        VPSHRDWZ256rmikz = 12746,

        VPSHRDWZ256rri = 12747,

        VPSHRDWZ256rrik = 12748,

        VPSHRDWZ256rrikz = 12749,

        VPSHRDWZrmi = 12750,

        VPSHRDWZrmik = 12751,

        VPSHRDWZrmikz = 12752,

        VPSHRDWZrri = 12753,

        VPSHRDWZrrik = 12754,

        VPSHRDWZrrikz = 12755,

        VPSHUFBITQMBZ128rm = 12756,

        VPSHUFBITQMBZ128rmk = 12757,

        VPSHUFBITQMBZ128rr = 12758,

        VPSHUFBITQMBZ128rrk = 12759,

        VPSHUFBITQMBZ256rm = 12760,

        VPSHUFBITQMBZ256rmk = 12761,

        VPSHUFBITQMBZ256rr = 12762,

        VPSHUFBITQMBZ256rrk = 12763,

        VPSHUFBITQMBZrm = 12764,

        VPSHUFBITQMBZrmk = 12765,

        VPSHUFBITQMBZrr = 12766,

        VPSHUFBITQMBZrrk = 12767,

        VPSHUFBYrm = 12768,

        VPSHUFBYrr = 12769,

        VPSHUFBZ128rm = 12770,

        VPSHUFBZ128rmk = 12771,

        VPSHUFBZ128rmkz = 12772,

        VPSHUFBZ128rr = 12773,

        VPSHUFBZ128rrk = 12774,

        VPSHUFBZ128rrkz = 12775,

        VPSHUFBZ256rm = 12776,

        VPSHUFBZ256rmk = 12777,

        VPSHUFBZ256rmkz = 12778,

        VPSHUFBZ256rr = 12779,

        VPSHUFBZ256rrk = 12780,

        VPSHUFBZ256rrkz = 12781,

        VPSHUFBZrm = 12782,

        VPSHUFBZrmk = 12783,

        VPSHUFBZrmkz = 12784,

        VPSHUFBZrr = 12785,

        VPSHUFBZrrk = 12786,

        VPSHUFBZrrkz = 12787,

        VPSHUFBrm = 12788,

        VPSHUFBrr = 12789,

        VPSHUFDYmi = 12790,

        VPSHUFDYri = 12791,

        VPSHUFDZ128mbi = 12792,

        VPSHUFDZ128mbik = 12793,

        VPSHUFDZ128mbikz = 12794,

        VPSHUFDZ128mi = 12795,

        VPSHUFDZ128mik = 12796,

        VPSHUFDZ128mikz = 12797,

        VPSHUFDZ128ri = 12798,

        VPSHUFDZ128rik = 12799,

        VPSHUFDZ128rikz = 12800,

        VPSHUFDZ256mbi = 12801,

        VPSHUFDZ256mbik = 12802,

        VPSHUFDZ256mbikz = 12803,

        VPSHUFDZ256mi = 12804,

        VPSHUFDZ256mik = 12805,

        VPSHUFDZ256mikz = 12806,

        VPSHUFDZ256ri = 12807,

        VPSHUFDZ256rik = 12808,

        VPSHUFDZ256rikz = 12809,

        VPSHUFDZmbi = 12810,

        VPSHUFDZmbik = 12811,

        VPSHUFDZmbikz = 12812,

        VPSHUFDZmi = 12813,

        VPSHUFDZmik = 12814,

        VPSHUFDZmikz = 12815,

        VPSHUFDZri = 12816,

        VPSHUFDZrik = 12817,

        VPSHUFDZrikz = 12818,

        VPSHUFDmi = 12819,

        VPSHUFDri = 12820,

        VPSHUFHWYmi = 12821,

        VPSHUFHWYri = 12822,

        VPSHUFHWZ128mi = 12823,

        VPSHUFHWZ128mik = 12824,

        VPSHUFHWZ128mikz = 12825,

        VPSHUFHWZ128ri = 12826,

        VPSHUFHWZ128rik = 12827,

        VPSHUFHWZ128rikz = 12828,

        VPSHUFHWZ256mi = 12829,

        VPSHUFHWZ256mik = 12830,

        VPSHUFHWZ256mikz = 12831,

        VPSHUFHWZ256ri = 12832,

        VPSHUFHWZ256rik = 12833,

        VPSHUFHWZ256rikz = 12834,

        VPSHUFHWZmi = 12835,

        VPSHUFHWZmik = 12836,

        VPSHUFHWZmikz = 12837,

        VPSHUFHWZri = 12838,

        VPSHUFHWZrik = 12839,

        VPSHUFHWZrikz = 12840,

        VPSHUFHWmi = 12841,

        VPSHUFHWri = 12842,

        VPSHUFLWYmi = 12843,

        VPSHUFLWYri = 12844,

        VPSHUFLWZ128mi = 12845,

        VPSHUFLWZ128mik = 12846,

        VPSHUFLWZ128mikz = 12847,

        VPSHUFLWZ128ri = 12848,

        VPSHUFLWZ128rik = 12849,

        VPSHUFLWZ128rikz = 12850,

        VPSHUFLWZ256mi = 12851,

        VPSHUFLWZ256mik = 12852,

        VPSHUFLWZ256mikz = 12853,

        VPSHUFLWZ256ri = 12854,

        VPSHUFLWZ256rik = 12855,

        VPSHUFLWZ256rikz = 12856,

        VPSHUFLWZmi = 12857,

        VPSHUFLWZmik = 12858,

        VPSHUFLWZmikz = 12859,

        VPSHUFLWZri = 12860,

        VPSHUFLWZrik = 12861,

        VPSHUFLWZrikz = 12862,

        VPSHUFLWmi = 12863,

        VPSHUFLWri = 12864,

        VPSIGNBYrm = 12865,

        VPSIGNBYrr = 12866,

        VPSIGNBrm = 12867,

        VPSIGNBrr = 12868,

        VPSIGNDYrm = 12869,

        VPSIGNDYrr = 12870,

        VPSIGNDrm = 12871,

        VPSIGNDrr = 12872,

        VPSIGNWYrm = 12873,

        VPSIGNWYrr = 12874,

        VPSIGNWrm = 12875,

        VPSIGNWrr = 12876,

        VPSLLDQYri = 12877,

        VPSLLDQZ128mi = 12878,

        VPSLLDQZ128ri = 12879,

        VPSLLDQZ256mi = 12880,

        VPSLLDQZ256ri = 12881,

        VPSLLDQZmi = 12882,

        VPSLLDQZri = 12883,

        VPSLLDQri = 12884,

        VPSLLDYri = 12885,

        VPSLLDYrm = 12886,

        VPSLLDYrr = 12887,

        VPSLLDZ128mbi = 12888,

        VPSLLDZ128mbik = 12889,

        VPSLLDZ128mbikz = 12890,

        VPSLLDZ128mi = 12891,

        VPSLLDZ128mik = 12892,

        VPSLLDZ128mikz = 12893,

        VPSLLDZ128ri = 12894,

        VPSLLDZ128rik = 12895,

        VPSLLDZ128rikz = 12896,

        VPSLLDZ128rm = 12897,

        VPSLLDZ128rmk = 12898,

        VPSLLDZ128rmkz = 12899,

        VPSLLDZ128rr = 12900,

        VPSLLDZ128rrk = 12901,

        VPSLLDZ128rrkz = 12902,

        VPSLLDZ256mbi = 12903,

        VPSLLDZ256mbik = 12904,

        VPSLLDZ256mbikz = 12905,

        VPSLLDZ256mi = 12906,

        VPSLLDZ256mik = 12907,

        VPSLLDZ256mikz = 12908,

        VPSLLDZ256ri = 12909,

        VPSLLDZ256rik = 12910,

        VPSLLDZ256rikz = 12911,

        VPSLLDZ256rm = 12912,

        VPSLLDZ256rmk = 12913,

        VPSLLDZ256rmkz = 12914,

        VPSLLDZ256rr = 12915,

        VPSLLDZ256rrk = 12916,

        VPSLLDZ256rrkz = 12917,

        VPSLLDZmbi = 12918,

        VPSLLDZmbik = 12919,

        VPSLLDZmbikz = 12920,

        VPSLLDZmi = 12921,

        VPSLLDZmik = 12922,

        VPSLLDZmikz = 12923,

        VPSLLDZri = 12924,

        VPSLLDZrik = 12925,

        VPSLLDZrikz = 12926,

        VPSLLDZrm = 12927,

        VPSLLDZrmk = 12928,

        VPSLLDZrmkz = 12929,

        VPSLLDZrr = 12930,

        VPSLLDZrrk = 12931,

        VPSLLDZrrkz = 12932,

        VPSLLDri = 12933,

        VPSLLDrm = 12934,

        VPSLLDrr = 12935,

        VPSLLQYri = 12936,

        VPSLLQYrm = 12937,

        VPSLLQYrr = 12938,

        VPSLLQZ128mbi = 12939,

        VPSLLQZ128mbik = 12940,

        VPSLLQZ128mbikz = 12941,

        VPSLLQZ128mi = 12942,

        VPSLLQZ128mik = 12943,

        VPSLLQZ128mikz = 12944,

        VPSLLQZ128ri = 12945,

        VPSLLQZ128rik = 12946,

        VPSLLQZ128rikz = 12947,

        VPSLLQZ128rm = 12948,

        VPSLLQZ128rmk = 12949,

        VPSLLQZ128rmkz = 12950,

        VPSLLQZ128rr = 12951,

        VPSLLQZ128rrk = 12952,

        VPSLLQZ128rrkz = 12953,

        VPSLLQZ256mbi = 12954,

        VPSLLQZ256mbik = 12955,

        VPSLLQZ256mbikz = 12956,

        VPSLLQZ256mi = 12957,

        VPSLLQZ256mik = 12958,

        VPSLLQZ256mikz = 12959,

        VPSLLQZ256ri = 12960,

        VPSLLQZ256rik = 12961,

        VPSLLQZ256rikz = 12962,

        VPSLLQZ256rm = 12963,

        VPSLLQZ256rmk = 12964,

        VPSLLQZ256rmkz = 12965,

        VPSLLQZ256rr = 12966,

        VPSLLQZ256rrk = 12967,

        VPSLLQZ256rrkz = 12968,

        VPSLLQZmbi = 12969,

        VPSLLQZmbik = 12970,

        VPSLLQZmbikz = 12971,

        VPSLLQZmi = 12972,

        VPSLLQZmik = 12973,

        VPSLLQZmikz = 12974,

        VPSLLQZri = 12975,

        VPSLLQZrik = 12976,

        VPSLLQZrikz = 12977,

        VPSLLQZrm = 12978,

        VPSLLQZrmk = 12979,

        VPSLLQZrmkz = 12980,

        VPSLLQZrr = 12981,

        VPSLLQZrrk = 12982,

        VPSLLQZrrkz = 12983,

        VPSLLQri = 12984,

        VPSLLQrm = 12985,

        VPSLLQrr = 12986,

        VPSLLVDYrm = 12987,

        VPSLLVDYrr = 12988,

        VPSLLVDZ128rm = 12989,

        VPSLLVDZ128rmb = 12990,

        VPSLLVDZ128rmbk = 12991,

        VPSLLVDZ128rmbkz = 12992,

        VPSLLVDZ128rmk = 12993,

        VPSLLVDZ128rmkz = 12994,

        VPSLLVDZ128rr = 12995,

        VPSLLVDZ128rrk = 12996,

        VPSLLVDZ128rrkz = 12997,

        VPSLLVDZ256rm = 12998,

        VPSLLVDZ256rmb = 12999,

        VPSLLVDZ256rmbk = 13000,

        VPSLLVDZ256rmbkz = 13001,

        VPSLLVDZ256rmk = 13002,

        VPSLLVDZ256rmkz = 13003,

        VPSLLVDZ256rr = 13004,

        VPSLLVDZ256rrk = 13005,

        VPSLLVDZ256rrkz = 13006,

        VPSLLVDZrm = 13007,

        VPSLLVDZrmb = 13008,

        VPSLLVDZrmbk = 13009,

        VPSLLVDZrmbkz = 13010,

        VPSLLVDZrmk = 13011,

        VPSLLVDZrmkz = 13012,

        VPSLLVDZrr = 13013,

        VPSLLVDZrrk = 13014,

        VPSLLVDZrrkz = 13015,

        VPSLLVDrm = 13016,

        VPSLLVDrr = 13017,

        VPSLLVQYrm = 13018,

        VPSLLVQYrr = 13019,

        VPSLLVQZ128rm = 13020,

        VPSLLVQZ128rmb = 13021,

        VPSLLVQZ128rmbk = 13022,

        VPSLLVQZ128rmbkz = 13023,

        VPSLLVQZ128rmk = 13024,

        VPSLLVQZ128rmkz = 13025,

        VPSLLVQZ128rr = 13026,

        VPSLLVQZ128rrk = 13027,

        VPSLLVQZ128rrkz = 13028,

        VPSLLVQZ256rm = 13029,

        VPSLLVQZ256rmb = 13030,

        VPSLLVQZ256rmbk = 13031,

        VPSLLVQZ256rmbkz = 13032,

        VPSLLVQZ256rmk = 13033,

        VPSLLVQZ256rmkz = 13034,

        VPSLLVQZ256rr = 13035,

        VPSLLVQZ256rrk = 13036,

        VPSLLVQZ256rrkz = 13037,

        VPSLLVQZrm = 13038,

        VPSLLVQZrmb = 13039,

        VPSLLVQZrmbk = 13040,

        VPSLLVQZrmbkz = 13041,

        VPSLLVQZrmk = 13042,

        VPSLLVQZrmkz = 13043,

        VPSLLVQZrr = 13044,

        VPSLLVQZrrk = 13045,

        VPSLLVQZrrkz = 13046,

        VPSLLVQrm = 13047,

        VPSLLVQrr = 13048,

        VPSLLVWZ128rm = 13049,

        VPSLLVWZ128rmk = 13050,

        VPSLLVWZ128rmkz = 13051,

        VPSLLVWZ128rr = 13052,

        VPSLLVWZ128rrk = 13053,

        VPSLLVWZ128rrkz = 13054,

        VPSLLVWZ256rm = 13055,

        VPSLLVWZ256rmk = 13056,

        VPSLLVWZ256rmkz = 13057,

        VPSLLVWZ256rr = 13058,

        VPSLLVWZ256rrk = 13059,

        VPSLLVWZ256rrkz = 13060,

        VPSLLVWZrm = 13061,

        VPSLLVWZrmk = 13062,

        VPSLLVWZrmkz = 13063,

        VPSLLVWZrr = 13064,

        VPSLLVWZrrk = 13065,

        VPSLLVWZrrkz = 13066,

        VPSLLWYri = 13067,

        VPSLLWYrm = 13068,

        VPSLLWYrr = 13069,

        VPSLLWZ128mi = 13070,

        VPSLLWZ128mik = 13071,

        VPSLLWZ128mikz = 13072,

        VPSLLWZ128ri = 13073,

        VPSLLWZ128rik = 13074,

        VPSLLWZ128rikz = 13075,

        VPSLLWZ128rm = 13076,

        VPSLLWZ128rmk = 13077,

        VPSLLWZ128rmkz = 13078,

        VPSLLWZ128rr = 13079,

        VPSLLWZ128rrk = 13080,

        VPSLLWZ128rrkz = 13081,

        VPSLLWZ256mi = 13082,

        VPSLLWZ256mik = 13083,

        VPSLLWZ256mikz = 13084,

        VPSLLWZ256ri = 13085,

        VPSLLWZ256rik = 13086,

        VPSLLWZ256rikz = 13087,

        VPSLLWZ256rm = 13088,

        VPSLLWZ256rmk = 13089,

        VPSLLWZ256rmkz = 13090,

        VPSLLWZ256rr = 13091,

        VPSLLWZ256rrk = 13092,

        VPSLLWZ256rrkz = 13093,

        VPSLLWZmi = 13094,

        VPSLLWZmik = 13095,

        VPSLLWZmikz = 13096,

        VPSLLWZri = 13097,

        VPSLLWZrik = 13098,

        VPSLLWZrikz = 13099,

        VPSLLWZrm = 13100,

        VPSLLWZrmk = 13101,

        VPSLLWZrmkz = 13102,

        VPSLLWZrr = 13103,

        VPSLLWZrrk = 13104,

        VPSLLWZrrkz = 13105,

        VPSLLWri = 13106,

        VPSLLWrm = 13107,

        VPSLLWrr = 13108,

        VPSRADYri = 13109,

        VPSRADYrm = 13110,

        VPSRADYrr = 13111,

        VPSRADZ128mbi = 13112,

        VPSRADZ128mbik = 13113,

        VPSRADZ128mbikz = 13114,

        VPSRADZ128mi = 13115,

        VPSRADZ128mik = 13116,

        VPSRADZ128mikz = 13117,

        VPSRADZ128ri = 13118,

        VPSRADZ128rik = 13119,

        VPSRADZ128rikz = 13120,

        VPSRADZ128rm = 13121,

        VPSRADZ128rmk = 13122,

        VPSRADZ128rmkz = 13123,

        VPSRADZ128rr = 13124,

        VPSRADZ128rrk = 13125,

        VPSRADZ128rrkz = 13126,

        VPSRADZ256mbi = 13127,

        VPSRADZ256mbik = 13128,

        VPSRADZ256mbikz = 13129,

        VPSRADZ256mi = 13130,

        VPSRADZ256mik = 13131,

        VPSRADZ256mikz = 13132,

        VPSRADZ256ri = 13133,

        VPSRADZ256rik = 13134,

        VPSRADZ256rikz = 13135,

        VPSRADZ256rm = 13136,

        VPSRADZ256rmk = 13137,

        VPSRADZ256rmkz = 13138,

        VPSRADZ256rr = 13139,

        VPSRADZ256rrk = 13140,

        VPSRADZ256rrkz = 13141,

        VPSRADZmbi = 13142,

        VPSRADZmbik = 13143,

        VPSRADZmbikz = 13144,

        VPSRADZmi = 13145,

        VPSRADZmik = 13146,

        VPSRADZmikz = 13147,

        VPSRADZri = 13148,

        VPSRADZrik = 13149,

        VPSRADZrikz = 13150,

        VPSRADZrm = 13151,

        VPSRADZrmk = 13152,

        VPSRADZrmkz = 13153,

        VPSRADZrr = 13154,

        VPSRADZrrk = 13155,

        VPSRADZrrkz = 13156,

        VPSRADri = 13157,

        VPSRADrm = 13158,

        VPSRADrr = 13159,

        VPSRAQZ128mbi = 13160,

        VPSRAQZ128mbik = 13161,

        VPSRAQZ128mbikz = 13162,

        VPSRAQZ128mi = 13163,

        VPSRAQZ128mik = 13164,

        VPSRAQZ128mikz = 13165,

        VPSRAQZ128ri = 13166,

        VPSRAQZ128rik = 13167,

        VPSRAQZ128rikz = 13168,

        VPSRAQZ128rm = 13169,

        VPSRAQZ128rmk = 13170,

        VPSRAQZ128rmkz = 13171,

        VPSRAQZ128rr = 13172,

        VPSRAQZ128rrk = 13173,

        VPSRAQZ128rrkz = 13174,

        VPSRAQZ256mbi = 13175,

        VPSRAQZ256mbik = 13176,

        VPSRAQZ256mbikz = 13177,

        VPSRAQZ256mi = 13178,

        VPSRAQZ256mik = 13179,

        VPSRAQZ256mikz = 13180,

        VPSRAQZ256ri = 13181,

        VPSRAQZ256rik = 13182,

        VPSRAQZ256rikz = 13183,

        VPSRAQZ256rm = 13184,

        VPSRAQZ256rmk = 13185,

        VPSRAQZ256rmkz = 13186,

        VPSRAQZ256rr = 13187,

        VPSRAQZ256rrk = 13188,

        VPSRAQZ256rrkz = 13189,

        VPSRAQZmbi = 13190,

        VPSRAQZmbik = 13191,

        VPSRAQZmbikz = 13192,

        VPSRAQZmi = 13193,

        VPSRAQZmik = 13194,

        VPSRAQZmikz = 13195,

        VPSRAQZri = 13196,

        VPSRAQZrik = 13197,

        VPSRAQZrikz = 13198,

        VPSRAQZrm = 13199,

        VPSRAQZrmk = 13200,

        VPSRAQZrmkz = 13201,

        VPSRAQZrr = 13202,

        VPSRAQZrrk = 13203,

        VPSRAQZrrkz = 13204,

        VPSRAVDYrm = 13205,

        VPSRAVDYrr = 13206,

        VPSRAVDZ128rm = 13207,

        VPSRAVDZ128rmb = 13208,

        VPSRAVDZ128rmbk = 13209,

        VPSRAVDZ128rmbkz = 13210,

        VPSRAVDZ128rmk = 13211,

        VPSRAVDZ128rmkz = 13212,

        VPSRAVDZ128rr = 13213,

        VPSRAVDZ128rrk = 13214,

        VPSRAVDZ128rrkz = 13215,

        VPSRAVDZ256rm = 13216,

        VPSRAVDZ256rmb = 13217,

        VPSRAVDZ256rmbk = 13218,

        VPSRAVDZ256rmbkz = 13219,

        VPSRAVDZ256rmk = 13220,

        VPSRAVDZ256rmkz = 13221,

        VPSRAVDZ256rr = 13222,

        VPSRAVDZ256rrk = 13223,

        VPSRAVDZ256rrkz = 13224,

        VPSRAVDZrm = 13225,

        VPSRAVDZrmb = 13226,

        VPSRAVDZrmbk = 13227,

        VPSRAVDZrmbkz = 13228,

        VPSRAVDZrmk = 13229,

        VPSRAVDZrmkz = 13230,

        VPSRAVDZrr = 13231,

        VPSRAVDZrrk = 13232,

        VPSRAVDZrrkz = 13233,

        VPSRAVDrm = 13234,

        VPSRAVDrr = 13235,

        VPSRAVQZ128rm = 13236,

        VPSRAVQZ128rmb = 13237,

        VPSRAVQZ128rmbk = 13238,

        VPSRAVQZ128rmbkz = 13239,

        VPSRAVQZ128rmk = 13240,

        VPSRAVQZ128rmkz = 13241,

        VPSRAVQZ128rr = 13242,

        VPSRAVQZ128rrk = 13243,

        VPSRAVQZ128rrkz = 13244,

        VPSRAVQZ256rm = 13245,

        VPSRAVQZ256rmb = 13246,

        VPSRAVQZ256rmbk = 13247,

        VPSRAVQZ256rmbkz = 13248,

        VPSRAVQZ256rmk = 13249,

        VPSRAVQZ256rmkz = 13250,

        VPSRAVQZ256rr = 13251,

        VPSRAVQZ256rrk = 13252,

        VPSRAVQZ256rrkz = 13253,

        VPSRAVQZrm = 13254,

        VPSRAVQZrmb = 13255,

        VPSRAVQZrmbk = 13256,

        VPSRAVQZrmbkz = 13257,

        VPSRAVQZrmk = 13258,

        VPSRAVQZrmkz = 13259,

        VPSRAVQZrr = 13260,

        VPSRAVQZrrk = 13261,

        VPSRAVQZrrkz = 13262,

        VPSRAVWZ128rm = 13263,

        VPSRAVWZ128rmk = 13264,

        VPSRAVWZ128rmkz = 13265,

        VPSRAVWZ128rr = 13266,

        VPSRAVWZ128rrk = 13267,

        VPSRAVWZ128rrkz = 13268,

        VPSRAVWZ256rm = 13269,

        VPSRAVWZ256rmk = 13270,

        VPSRAVWZ256rmkz = 13271,

        VPSRAVWZ256rr = 13272,

        VPSRAVWZ256rrk = 13273,

        VPSRAVWZ256rrkz = 13274,

        VPSRAVWZrm = 13275,

        VPSRAVWZrmk = 13276,

        VPSRAVWZrmkz = 13277,

        VPSRAVWZrr = 13278,

        VPSRAVWZrrk = 13279,

        VPSRAVWZrrkz = 13280,

        VPSRAWYri = 13281,

        VPSRAWYrm = 13282,

        VPSRAWYrr = 13283,

        VPSRAWZ128mi = 13284,

        VPSRAWZ128mik = 13285,

        VPSRAWZ128mikz = 13286,

        VPSRAWZ128ri = 13287,

        VPSRAWZ128rik = 13288,

        VPSRAWZ128rikz = 13289,

        VPSRAWZ128rm = 13290,

        VPSRAWZ128rmk = 13291,

        VPSRAWZ128rmkz = 13292,

        VPSRAWZ128rr = 13293,

        VPSRAWZ128rrk = 13294,

        VPSRAWZ128rrkz = 13295,

        VPSRAWZ256mi = 13296,

        VPSRAWZ256mik = 13297,

        VPSRAWZ256mikz = 13298,

        VPSRAWZ256ri = 13299,

        VPSRAWZ256rik = 13300,

        VPSRAWZ256rikz = 13301,

        VPSRAWZ256rm = 13302,

        VPSRAWZ256rmk = 13303,

        VPSRAWZ256rmkz = 13304,

        VPSRAWZ256rr = 13305,

        VPSRAWZ256rrk = 13306,

        VPSRAWZ256rrkz = 13307,

        VPSRAWZmi = 13308,

        VPSRAWZmik = 13309,

        VPSRAWZmikz = 13310,

        VPSRAWZri = 13311,

        VPSRAWZrik = 13312,

        VPSRAWZrikz = 13313,

        VPSRAWZrm = 13314,

        VPSRAWZrmk = 13315,

        VPSRAWZrmkz = 13316,

        VPSRAWZrr = 13317,

        VPSRAWZrrk = 13318,

        VPSRAWZrrkz = 13319,

        VPSRAWri = 13320,

        VPSRAWrm = 13321,

        VPSRAWrr = 13322,

        VPSRLDQYri = 13323,

        VPSRLDQZ128mi = 13324,

        VPSRLDQZ128ri = 13325,

        VPSRLDQZ256mi = 13326,

        VPSRLDQZ256ri = 13327,

        VPSRLDQZmi = 13328,

        VPSRLDQZri = 13329,

        VPSRLDQri = 13330,

        VPSRLDYri = 13331,

        VPSRLDYrm = 13332,

        VPSRLDYrr = 13333,

        VPSRLDZ128mbi = 13334,

        VPSRLDZ128mbik = 13335,

        VPSRLDZ128mbikz = 13336,

        VPSRLDZ128mi = 13337,

        VPSRLDZ128mik = 13338,

        VPSRLDZ128mikz = 13339,

        VPSRLDZ128ri = 13340,

        VPSRLDZ128rik = 13341,

        VPSRLDZ128rikz = 13342,

        VPSRLDZ128rm = 13343,

        VPSRLDZ128rmk = 13344,

        VPSRLDZ128rmkz = 13345,

        VPSRLDZ128rr = 13346,

        VPSRLDZ128rrk = 13347,

        VPSRLDZ128rrkz = 13348,

        VPSRLDZ256mbi = 13349,

        VPSRLDZ256mbik = 13350,

        VPSRLDZ256mbikz = 13351,

        VPSRLDZ256mi = 13352,

        VPSRLDZ256mik = 13353,

        VPSRLDZ256mikz = 13354,

        VPSRLDZ256ri = 13355,

        VPSRLDZ256rik = 13356,

        VPSRLDZ256rikz = 13357,

        VPSRLDZ256rm = 13358,

        VPSRLDZ256rmk = 13359,

        VPSRLDZ256rmkz = 13360,

        VPSRLDZ256rr = 13361,

        VPSRLDZ256rrk = 13362,

        VPSRLDZ256rrkz = 13363,

        VPSRLDZmbi = 13364,

        VPSRLDZmbik = 13365,

        VPSRLDZmbikz = 13366,

        VPSRLDZmi = 13367,

        VPSRLDZmik = 13368,

        VPSRLDZmikz = 13369,

        VPSRLDZri = 13370,

        VPSRLDZrik = 13371,

        VPSRLDZrikz = 13372,

        VPSRLDZrm = 13373,

        VPSRLDZrmk = 13374,

        VPSRLDZrmkz = 13375,

        VPSRLDZrr = 13376,

        VPSRLDZrrk = 13377,

        VPSRLDZrrkz = 13378,

        VPSRLDri = 13379,

        VPSRLDrm = 13380,

        VPSRLDrr = 13381,

        VPSRLQYri = 13382,

        VPSRLQYrm = 13383,

        VPSRLQYrr = 13384,

        VPSRLQZ128mbi = 13385,

        VPSRLQZ128mbik = 13386,

        VPSRLQZ128mbikz = 13387,

        VPSRLQZ128mi = 13388,

        VPSRLQZ128mik = 13389,

        VPSRLQZ128mikz = 13390,

        VPSRLQZ128ri = 13391,

        VPSRLQZ128rik = 13392,

        VPSRLQZ128rikz = 13393,

        VPSRLQZ128rm = 13394,

        VPSRLQZ128rmk = 13395,

        VPSRLQZ128rmkz = 13396,

        VPSRLQZ128rr = 13397,

        VPSRLQZ128rrk = 13398,

        VPSRLQZ128rrkz = 13399,

        VPSRLQZ256mbi = 13400,

        VPSRLQZ256mbik = 13401,

        VPSRLQZ256mbikz = 13402,

        VPSRLQZ256mi = 13403,

        VPSRLQZ256mik = 13404,

        VPSRLQZ256mikz = 13405,

        VPSRLQZ256ri = 13406,

        VPSRLQZ256rik = 13407,

        VPSRLQZ256rikz = 13408,

        VPSRLQZ256rm = 13409,

        VPSRLQZ256rmk = 13410,

        VPSRLQZ256rmkz = 13411,

        VPSRLQZ256rr = 13412,

        VPSRLQZ256rrk = 13413,

        VPSRLQZ256rrkz = 13414,

        VPSRLQZmbi = 13415,

        VPSRLQZmbik = 13416,

        VPSRLQZmbikz = 13417,

        VPSRLQZmi = 13418,

        VPSRLQZmik = 13419,

        VPSRLQZmikz = 13420,

        VPSRLQZri = 13421,

        VPSRLQZrik = 13422,

        VPSRLQZrikz = 13423,

        VPSRLQZrm = 13424,

        VPSRLQZrmk = 13425,

        VPSRLQZrmkz = 13426,

        VPSRLQZrr = 13427,

        VPSRLQZrrk = 13428,

        VPSRLQZrrkz = 13429,

        VPSRLQri = 13430,

        VPSRLQrm = 13431,

        VPSRLQrr = 13432,

        VPSRLVDYrm = 13433,

        VPSRLVDYrr = 13434,

        VPSRLVDZ128rm = 13435,

        VPSRLVDZ128rmb = 13436,

        VPSRLVDZ128rmbk = 13437,

        VPSRLVDZ128rmbkz = 13438,

        VPSRLVDZ128rmk = 13439,

        VPSRLVDZ128rmkz = 13440,

        VPSRLVDZ128rr = 13441,

        VPSRLVDZ128rrk = 13442,

        VPSRLVDZ128rrkz = 13443,

        VPSRLVDZ256rm = 13444,

        VPSRLVDZ256rmb = 13445,

        VPSRLVDZ256rmbk = 13446,

        VPSRLVDZ256rmbkz = 13447,

        VPSRLVDZ256rmk = 13448,

        VPSRLVDZ256rmkz = 13449,

        VPSRLVDZ256rr = 13450,

        VPSRLVDZ256rrk = 13451,

        VPSRLVDZ256rrkz = 13452,

        VPSRLVDZrm = 13453,

        VPSRLVDZrmb = 13454,

        VPSRLVDZrmbk = 13455,

        VPSRLVDZrmbkz = 13456,

        VPSRLVDZrmk = 13457,

        VPSRLVDZrmkz = 13458,

        VPSRLVDZrr = 13459,

        VPSRLVDZrrk = 13460,

        VPSRLVDZrrkz = 13461,

        VPSRLVDrm = 13462,

        VPSRLVDrr = 13463,

        VPSRLVQYrm = 13464,

        VPSRLVQYrr = 13465,

        VPSRLVQZ128rm = 13466,

        VPSRLVQZ128rmb = 13467,

        VPSRLVQZ128rmbk = 13468,

        VPSRLVQZ128rmbkz = 13469,

        VPSRLVQZ128rmk = 13470,

        VPSRLVQZ128rmkz = 13471,

        VPSRLVQZ128rr = 13472,

        VPSRLVQZ128rrk = 13473,

        VPSRLVQZ128rrkz = 13474,

        VPSRLVQZ256rm = 13475,

        VPSRLVQZ256rmb = 13476,

        VPSRLVQZ256rmbk = 13477,

        VPSRLVQZ256rmbkz = 13478,

        VPSRLVQZ256rmk = 13479,

        VPSRLVQZ256rmkz = 13480,

        VPSRLVQZ256rr = 13481,

        VPSRLVQZ256rrk = 13482,

        VPSRLVQZ256rrkz = 13483,

        VPSRLVQZrm = 13484,

        VPSRLVQZrmb = 13485,

        VPSRLVQZrmbk = 13486,

        VPSRLVQZrmbkz = 13487,

        VPSRLVQZrmk = 13488,

        VPSRLVQZrmkz = 13489,

        VPSRLVQZrr = 13490,

        VPSRLVQZrrk = 13491,

        VPSRLVQZrrkz = 13492,

        VPSRLVQrm = 13493,

        VPSRLVQrr = 13494,

        VPSRLVWZ128rm = 13495,

        VPSRLVWZ128rmk = 13496,

        VPSRLVWZ128rmkz = 13497,

        VPSRLVWZ128rr = 13498,

        VPSRLVWZ128rrk = 13499,

        VPSRLVWZ128rrkz = 13500,

        VPSRLVWZ256rm = 13501,

        VPSRLVWZ256rmk = 13502,

        VPSRLVWZ256rmkz = 13503,

        VPSRLVWZ256rr = 13504,

        VPSRLVWZ256rrk = 13505,

        VPSRLVWZ256rrkz = 13506,

        VPSRLVWZrm = 13507,

        VPSRLVWZrmk = 13508,

        VPSRLVWZrmkz = 13509,

        VPSRLVWZrr = 13510,

        VPSRLVWZrrk = 13511,

        VPSRLVWZrrkz = 13512,

        VPSRLWYri = 13513,

        VPSRLWYrm = 13514,

        VPSRLWYrr = 13515,

        VPSRLWZ128mi = 13516,

        VPSRLWZ128mik = 13517,

        VPSRLWZ128mikz = 13518,

        VPSRLWZ128ri = 13519,

        VPSRLWZ128rik = 13520,

        VPSRLWZ128rikz = 13521,

        VPSRLWZ128rm = 13522,

        VPSRLWZ128rmk = 13523,

        VPSRLWZ128rmkz = 13524,

        VPSRLWZ128rr = 13525,

        VPSRLWZ128rrk = 13526,

        VPSRLWZ128rrkz = 13527,

        VPSRLWZ256mi = 13528,

        VPSRLWZ256mik = 13529,

        VPSRLWZ256mikz = 13530,

        VPSRLWZ256ri = 13531,

        VPSRLWZ256rik = 13532,

        VPSRLWZ256rikz = 13533,

        VPSRLWZ256rm = 13534,

        VPSRLWZ256rmk = 13535,

        VPSRLWZ256rmkz = 13536,

        VPSRLWZ256rr = 13537,

        VPSRLWZ256rrk = 13538,

        VPSRLWZ256rrkz = 13539,

        VPSRLWZmi = 13540,

        VPSRLWZmik = 13541,

        VPSRLWZmikz = 13542,

        VPSRLWZri = 13543,

        VPSRLWZrik = 13544,

        VPSRLWZrikz = 13545,

        VPSRLWZrm = 13546,

        VPSRLWZrmk = 13547,

        VPSRLWZrmkz = 13548,

        VPSRLWZrr = 13549,

        VPSRLWZrrk = 13550,

        VPSRLWZrrkz = 13551,

        VPSRLWri = 13552,

        VPSRLWrm = 13553,

        VPSRLWrr = 13554,

        VPSUBBYrm = 13555,

        VPSUBBYrr = 13556,

        VPSUBBZ128rm = 13557,

        VPSUBBZ128rmk = 13558,

        VPSUBBZ128rmkz = 13559,

        VPSUBBZ128rr = 13560,

        VPSUBBZ128rrk = 13561,

        VPSUBBZ128rrkz = 13562,

        VPSUBBZ256rm = 13563,

        VPSUBBZ256rmk = 13564,

        VPSUBBZ256rmkz = 13565,

        VPSUBBZ256rr = 13566,

        VPSUBBZ256rrk = 13567,

        VPSUBBZ256rrkz = 13568,

        VPSUBBZrm = 13569,

        VPSUBBZrmk = 13570,

        VPSUBBZrmkz = 13571,

        VPSUBBZrr = 13572,

        VPSUBBZrrk = 13573,

        VPSUBBZrrkz = 13574,

        VPSUBBrm = 13575,

        VPSUBBrr = 13576,

        VPSUBDYrm = 13577,

        VPSUBDYrr = 13578,

        VPSUBDZ128rm = 13579,

        VPSUBDZ128rmb = 13580,

        VPSUBDZ128rmbk = 13581,

        VPSUBDZ128rmbkz = 13582,

        VPSUBDZ128rmk = 13583,

        VPSUBDZ128rmkz = 13584,

        VPSUBDZ128rr = 13585,

        VPSUBDZ128rrk = 13586,

        VPSUBDZ128rrkz = 13587,

        VPSUBDZ256rm = 13588,

        VPSUBDZ256rmb = 13589,

        VPSUBDZ256rmbk = 13590,

        VPSUBDZ256rmbkz = 13591,

        VPSUBDZ256rmk = 13592,

        VPSUBDZ256rmkz = 13593,

        VPSUBDZ256rr = 13594,

        VPSUBDZ256rrk = 13595,

        VPSUBDZ256rrkz = 13596,

        VPSUBDZrm = 13597,

        VPSUBDZrmb = 13598,

        VPSUBDZrmbk = 13599,

        VPSUBDZrmbkz = 13600,

        VPSUBDZrmk = 13601,

        VPSUBDZrmkz = 13602,

        VPSUBDZrr = 13603,

        VPSUBDZrrk = 13604,

        VPSUBDZrrkz = 13605,

        VPSUBDrm = 13606,

        VPSUBDrr = 13607,

        VPSUBQYrm = 13608,

        VPSUBQYrr = 13609,

        VPSUBQZ128rm = 13610,

        VPSUBQZ128rmb = 13611,

        VPSUBQZ128rmbk = 13612,

        VPSUBQZ128rmbkz = 13613,

        VPSUBQZ128rmk = 13614,

        VPSUBQZ128rmkz = 13615,

        VPSUBQZ128rr = 13616,

        VPSUBQZ128rrk = 13617,

        VPSUBQZ128rrkz = 13618,

        VPSUBQZ256rm = 13619,

        VPSUBQZ256rmb = 13620,

        VPSUBQZ256rmbk = 13621,

        VPSUBQZ256rmbkz = 13622,

        VPSUBQZ256rmk = 13623,

        VPSUBQZ256rmkz = 13624,

        VPSUBQZ256rr = 13625,

        VPSUBQZ256rrk = 13626,

        VPSUBQZ256rrkz = 13627,

        VPSUBQZrm = 13628,

        VPSUBQZrmb = 13629,

        VPSUBQZrmbk = 13630,

        VPSUBQZrmbkz = 13631,

        VPSUBQZrmk = 13632,

        VPSUBQZrmkz = 13633,

        VPSUBQZrr = 13634,

        VPSUBQZrrk = 13635,

        VPSUBQZrrkz = 13636,

        VPSUBQrm = 13637,

        VPSUBQrr = 13638,

        VPSUBSBYrm = 13639,

        VPSUBSBYrr = 13640,

        VPSUBSBZ128rm = 13641,

        VPSUBSBZ128rmk = 13642,

        VPSUBSBZ128rmkz = 13643,

        VPSUBSBZ128rr = 13644,

        VPSUBSBZ128rrk = 13645,

        VPSUBSBZ128rrkz = 13646,

        VPSUBSBZ256rm = 13647,

        VPSUBSBZ256rmk = 13648,

        VPSUBSBZ256rmkz = 13649,

        VPSUBSBZ256rr = 13650,

        VPSUBSBZ256rrk = 13651,

        VPSUBSBZ256rrkz = 13652,

        VPSUBSBZrm = 13653,

        VPSUBSBZrmk = 13654,

        VPSUBSBZrmkz = 13655,

        VPSUBSBZrr = 13656,

        VPSUBSBZrrk = 13657,

        VPSUBSBZrrkz = 13658,

        VPSUBSBrm = 13659,

        VPSUBSBrr = 13660,

        VPSUBSWYrm = 13661,

        VPSUBSWYrr = 13662,

        VPSUBSWZ128rm = 13663,

        VPSUBSWZ128rmk = 13664,

        VPSUBSWZ128rmkz = 13665,

        VPSUBSWZ128rr = 13666,

        VPSUBSWZ128rrk = 13667,

        VPSUBSWZ128rrkz = 13668,

        VPSUBSWZ256rm = 13669,

        VPSUBSWZ256rmk = 13670,

        VPSUBSWZ256rmkz = 13671,

        VPSUBSWZ256rr = 13672,

        VPSUBSWZ256rrk = 13673,

        VPSUBSWZ256rrkz = 13674,

        VPSUBSWZrm = 13675,

        VPSUBSWZrmk = 13676,

        VPSUBSWZrmkz = 13677,

        VPSUBSWZrr = 13678,

        VPSUBSWZrrk = 13679,

        VPSUBSWZrrkz = 13680,

        VPSUBSWrm = 13681,

        VPSUBSWrr = 13682,

        VPSUBUSBYrm = 13683,

        VPSUBUSBYrr = 13684,

        VPSUBUSBZ128rm = 13685,

        VPSUBUSBZ128rmk = 13686,

        VPSUBUSBZ128rmkz = 13687,

        VPSUBUSBZ128rr = 13688,

        VPSUBUSBZ128rrk = 13689,

        VPSUBUSBZ128rrkz = 13690,

        VPSUBUSBZ256rm = 13691,

        VPSUBUSBZ256rmk = 13692,

        VPSUBUSBZ256rmkz = 13693,

        VPSUBUSBZ256rr = 13694,

        VPSUBUSBZ256rrk = 13695,

        VPSUBUSBZ256rrkz = 13696,

        VPSUBUSBZrm = 13697,

        VPSUBUSBZrmk = 13698,

        VPSUBUSBZrmkz = 13699,

        VPSUBUSBZrr = 13700,

        VPSUBUSBZrrk = 13701,

        VPSUBUSBZrrkz = 13702,

        VPSUBUSBrm = 13703,

        VPSUBUSBrr = 13704,

        VPSUBUSWYrm = 13705,

        VPSUBUSWYrr = 13706,

        VPSUBUSWZ128rm = 13707,

        VPSUBUSWZ128rmk = 13708,

        VPSUBUSWZ128rmkz = 13709,

        VPSUBUSWZ128rr = 13710,

        VPSUBUSWZ128rrk = 13711,

        VPSUBUSWZ128rrkz = 13712,

        VPSUBUSWZ256rm = 13713,

        VPSUBUSWZ256rmk = 13714,

        VPSUBUSWZ256rmkz = 13715,

        VPSUBUSWZ256rr = 13716,

        VPSUBUSWZ256rrk = 13717,

        VPSUBUSWZ256rrkz = 13718,

        VPSUBUSWZrm = 13719,

        VPSUBUSWZrmk = 13720,

        VPSUBUSWZrmkz = 13721,

        VPSUBUSWZrr = 13722,

        VPSUBUSWZrrk = 13723,

        VPSUBUSWZrrkz = 13724,

        VPSUBUSWrm = 13725,

        VPSUBUSWrr = 13726,

        VPSUBWYrm = 13727,

        VPSUBWYrr = 13728,

        VPSUBWZ128rm = 13729,

        VPSUBWZ128rmk = 13730,

        VPSUBWZ128rmkz = 13731,

        VPSUBWZ128rr = 13732,

        VPSUBWZ128rrk = 13733,

        VPSUBWZ128rrkz = 13734,

        VPSUBWZ256rm = 13735,

        VPSUBWZ256rmk = 13736,

        VPSUBWZ256rmkz = 13737,

        VPSUBWZ256rr = 13738,

        VPSUBWZ256rrk = 13739,

        VPSUBWZ256rrkz = 13740,

        VPSUBWZrm = 13741,

        VPSUBWZrmk = 13742,

        VPSUBWZrmkz = 13743,

        VPSUBWZrr = 13744,

        VPSUBWZrrk = 13745,

        VPSUBWZrrkz = 13746,

        VPSUBWrm = 13747,

        VPSUBWrr = 13748,

        VPTERNLOGDZ128rmbi = 13749,

        VPTERNLOGDZ128rmbik = 13750,

        VPTERNLOGDZ128rmbikz = 13751,

        VPTERNLOGDZ128rmi = 13752,

        VPTERNLOGDZ128rmik = 13753,

        VPTERNLOGDZ128rmikz = 13754,

        VPTERNLOGDZ128rri = 13755,

        VPTERNLOGDZ128rrik = 13756,

        VPTERNLOGDZ128rrikz = 13757,

        VPTERNLOGDZ256rmbi = 13758,

        VPTERNLOGDZ256rmbik = 13759,

        VPTERNLOGDZ256rmbikz = 13760,

        VPTERNLOGDZ256rmi = 13761,

        VPTERNLOGDZ256rmik = 13762,

        VPTERNLOGDZ256rmikz = 13763,

        VPTERNLOGDZ256rri = 13764,

        VPTERNLOGDZ256rrik = 13765,

        VPTERNLOGDZ256rrikz = 13766,

        VPTERNLOGDZrmbi = 13767,

        VPTERNLOGDZrmbik = 13768,

        VPTERNLOGDZrmbikz = 13769,

        VPTERNLOGDZrmi = 13770,

        VPTERNLOGDZrmik = 13771,

        VPTERNLOGDZrmikz = 13772,

        VPTERNLOGDZrri = 13773,

        VPTERNLOGDZrrik = 13774,

        VPTERNLOGDZrrikz = 13775,

        VPTERNLOGQZ128rmbi = 13776,

        VPTERNLOGQZ128rmbik = 13777,

        VPTERNLOGQZ128rmbikz = 13778,

        VPTERNLOGQZ128rmi = 13779,

        VPTERNLOGQZ128rmik = 13780,

        VPTERNLOGQZ128rmikz = 13781,

        VPTERNLOGQZ128rri = 13782,

        VPTERNLOGQZ128rrik = 13783,

        VPTERNLOGQZ128rrikz = 13784,

        VPTERNLOGQZ256rmbi = 13785,

        VPTERNLOGQZ256rmbik = 13786,

        VPTERNLOGQZ256rmbikz = 13787,

        VPTERNLOGQZ256rmi = 13788,

        VPTERNLOGQZ256rmik = 13789,

        VPTERNLOGQZ256rmikz = 13790,

        VPTERNLOGQZ256rri = 13791,

        VPTERNLOGQZ256rrik = 13792,

        VPTERNLOGQZ256rrikz = 13793,

        VPTERNLOGQZrmbi = 13794,

        VPTERNLOGQZrmbik = 13795,

        VPTERNLOGQZrmbikz = 13796,

        VPTERNLOGQZrmi = 13797,

        VPTERNLOGQZrmik = 13798,

        VPTERNLOGQZrmikz = 13799,

        VPTERNLOGQZrri = 13800,

        VPTERNLOGQZrrik = 13801,

        VPTERNLOGQZrrikz = 13802,

        VPTESTMBZ128rm = 13803,

        VPTESTMBZ128rmk = 13804,

        VPTESTMBZ128rr = 13805,

        VPTESTMBZ128rrk = 13806,

        VPTESTMBZ256rm = 13807,

        VPTESTMBZ256rmk = 13808,

        VPTESTMBZ256rr = 13809,

        VPTESTMBZ256rrk = 13810,

        VPTESTMBZrm = 13811,

        VPTESTMBZrmk = 13812,

        VPTESTMBZrr = 13813,

        VPTESTMBZrrk = 13814,

        VPTESTMDZ128rm = 13815,

        VPTESTMDZ128rmb = 13816,

        VPTESTMDZ128rmbk = 13817,

        VPTESTMDZ128rmk = 13818,

        VPTESTMDZ128rr = 13819,

        VPTESTMDZ128rrk = 13820,

        VPTESTMDZ256rm = 13821,

        VPTESTMDZ256rmb = 13822,

        VPTESTMDZ256rmbk = 13823,

        VPTESTMDZ256rmk = 13824,

        VPTESTMDZ256rr = 13825,

        VPTESTMDZ256rrk = 13826,

        VPTESTMDZrm = 13827,

        VPTESTMDZrmb = 13828,

        VPTESTMDZrmbk = 13829,

        VPTESTMDZrmk = 13830,

        VPTESTMDZrr = 13831,

        VPTESTMDZrrk = 13832,

        VPTESTMQZ128rm = 13833,

        VPTESTMQZ128rmb = 13834,

        VPTESTMQZ128rmbk = 13835,

        VPTESTMQZ128rmk = 13836,

        VPTESTMQZ128rr = 13837,

        VPTESTMQZ128rrk = 13838,

        VPTESTMQZ256rm = 13839,

        VPTESTMQZ256rmb = 13840,

        VPTESTMQZ256rmbk = 13841,

        VPTESTMQZ256rmk = 13842,

        VPTESTMQZ256rr = 13843,

        VPTESTMQZ256rrk = 13844,

        VPTESTMQZrm = 13845,

        VPTESTMQZrmb = 13846,

        VPTESTMQZrmbk = 13847,

        VPTESTMQZrmk = 13848,

        VPTESTMQZrr = 13849,

        VPTESTMQZrrk = 13850,

        VPTESTMWZ128rm = 13851,

        VPTESTMWZ128rmk = 13852,

        VPTESTMWZ128rr = 13853,

        VPTESTMWZ128rrk = 13854,

        VPTESTMWZ256rm = 13855,

        VPTESTMWZ256rmk = 13856,

        VPTESTMWZ256rr = 13857,

        VPTESTMWZ256rrk = 13858,

        VPTESTMWZrm = 13859,

        VPTESTMWZrmk = 13860,

        VPTESTMWZrr = 13861,

        VPTESTMWZrrk = 13862,

        VPTESTNMBZ128rm = 13863,

        VPTESTNMBZ128rmk = 13864,

        VPTESTNMBZ128rr = 13865,

        VPTESTNMBZ128rrk = 13866,

        VPTESTNMBZ256rm = 13867,

        VPTESTNMBZ256rmk = 13868,

        VPTESTNMBZ256rr = 13869,

        VPTESTNMBZ256rrk = 13870,

        VPTESTNMBZrm = 13871,

        VPTESTNMBZrmk = 13872,

        VPTESTNMBZrr = 13873,

        VPTESTNMBZrrk = 13874,

        VPTESTNMDZ128rm = 13875,

        VPTESTNMDZ128rmb = 13876,

        VPTESTNMDZ128rmbk = 13877,

        VPTESTNMDZ128rmk = 13878,

        VPTESTNMDZ128rr = 13879,

        VPTESTNMDZ128rrk = 13880,

        VPTESTNMDZ256rm = 13881,

        VPTESTNMDZ256rmb = 13882,

        VPTESTNMDZ256rmbk = 13883,

        VPTESTNMDZ256rmk = 13884,

        VPTESTNMDZ256rr = 13885,

        VPTESTNMDZ256rrk = 13886,

        VPTESTNMDZrm = 13887,

        VPTESTNMDZrmb = 13888,

        VPTESTNMDZrmbk = 13889,

        VPTESTNMDZrmk = 13890,

        VPTESTNMDZrr = 13891,

        VPTESTNMDZrrk = 13892,

        VPTESTNMQZ128rm = 13893,

        VPTESTNMQZ128rmb = 13894,

        VPTESTNMQZ128rmbk = 13895,

        VPTESTNMQZ128rmk = 13896,

        VPTESTNMQZ128rr = 13897,

        VPTESTNMQZ128rrk = 13898,

        VPTESTNMQZ256rm = 13899,

        VPTESTNMQZ256rmb = 13900,

        VPTESTNMQZ256rmbk = 13901,

        VPTESTNMQZ256rmk = 13902,

        VPTESTNMQZ256rr = 13903,

        VPTESTNMQZ256rrk = 13904,

        VPTESTNMQZrm = 13905,

        VPTESTNMQZrmb = 13906,

        VPTESTNMQZrmbk = 13907,

        VPTESTNMQZrmk = 13908,

        VPTESTNMQZrr = 13909,

        VPTESTNMQZrrk = 13910,

        VPTESTNMWZ128rm = 13911,

        VPTESTNMWZ128rmk = 13912,

        VPTESTNMWZ128rr = 13913,

        VPTESTNMWZ128rrk = 13914,

        VPTESTNMWZ256rm = 13915,

        VPTESTNMWZ256rmk = 13916,

        VPTESTNMWZ256rr = 13917,

        VPTESTNMWZ256rrk = 13918,

        VPTESTNMWZrm = 13919,

        VPTESTNMWZrmk = 13920,

        VPTESTNMWZrr = 13921,

        VPTESTNMWZrrk = 13922,

        VPTESTYrm = 13923,

        VPTESTYrr = 13924,

        VPTESTrm = 13925,

        VPTESTrr = 13926,

        VPUNPCKHBWYrm = 13927,

        VPUNPCKHBWYrr = 13928,

        VPUNPCKHBWZ128rm = 13929,

        VPUNPCKHBWZ128rmk = 13930,

        VPUNPCKHBWZ128rmkz = 13931,

        VPUNPCKHBWZ128rr = 13932,

        VPUNPCKHBWZ128rrk = 13933,

        VPUNPCKHBWZ128rrkz = 13934,

        VPUNPCKHBWZ256rm = 13935,

        VPUNPCKHBWZ256rmk = 13936,

        VPUNPCKHBWZ256rmkz = 13937,

        VPUNPCKHBWZ256rr = 13938,

        VPUNPCKHBWZ256rrk = 13939,

        VPUNPCKHBWZ256rrkz = 13940,

        VPUNPCKHBWZrm = 13941,

        VPUNPCKHBWZrmk = 13942,

        VPUNPCKHBWZrmkz = 13943,

        VPUNPCKHBWZrr = 13944,

        VPUNPCKHBWZrrk = 13945,

        VPUNPCKHBWZrrkz = 13946,

        VPUNPCKHBWrm = 13947,

        VPUNPCKHBWrr = 13948,

        VPUNPCKHDQYrm = 13949,

        VPUNPCKHDQYrr = 13950,

        VPUNPCKHDQZ128rm = 13951,

        VPUNPCKHDQZ128rmb = 13952,

        VPUNPCKHDQZ128rmbk = 13953,

        VPUNPCKHDQZ128rmbkz = 13954,

        VPUNPCKHDQZ128rmk = 13955,

        VPUNPCKHDQZ128rmkz = 13956,

        VPUNPCKHDQZ128rr = 13957,

        VPUNPCKHDQZ128rrk = 13958,

        VPUNPCKHDQZ128rrkz = 13959,

        VPUNPCKHDQZ256rm = 13960,

        VPUNPCKHDQZ256rmb = 13961,

        VPUNPCKHDQZ256rmbk = 13962,

        VPUNPCKHDQZ256rmbkz = 13963,

        VPUNPCKHDQZ256rmk = 13964,

        VPUNPCKHDQZ256rmkz = 13965,

        VPUNPCKHDQZ256rr = 13966,

        VPUNPCKHDQZ256rrk = 13967,

        VPUNPCKHDQZ256rrkz = 13968,

        VPUNPCKHDQZrm = 13969,

        VPUNPCKHDQZrmb = 13970,

        VPUNPCKHDQZrmbk = 13971,

        VPUNPCKHDQZrmbkz = 13972,

        VPUNPCKHDQZrmk = 13973,

        VPUNPCKHDQZrmkz = 13974,

        VPUNPCKHDQZrr = 13975,

        VPUNPCKHDQZrrk = 13976,

        VPUNPCKHDQZrrkz = 13977,

        VPUNPCKHDQrm = 13978,

        VPUNPCKHDQrr = 13979,

        VPUNPCKHQDQYrm = 13980,

        VPUNPCKHQDQYrr = 13981,

        VPUNPCKHQDQZ128rm = 13982,

        VPUNPCKHQDQZ128rmb = 13983,

        VPUNPCKHQDQZ128rmbk = 13984,

        VPUNPCKHQDQZ128rmbkz = 13985,

        VPUNPCKHQDQZ128rmk = 13986,

        VPUNPCKHQDQZ128rmkz = 13987,

        VPUNPCKHQDQZ128rr = 13988,

        VPUNPCKHQDQZ128rrk = 13989,

        VPUNPCKHQDQZ128rrkz = 13990,

        VPUNPCKHQDQZ256rm = 13991,

        VPUNPCKHQDQZ256rmb = 13992,

        VPUNPCKHQDQZ256rmbk = 13993,

        VPUNPCKHQDQZ256rmbkz = 13994,

        VPUNPCKHQDQZ256rmk = 13995,

        VPUNPCKHQDQZ256rmkz = 13996,

        VPUNPCKHQDQZ256rr = 13997,

        VPUNPCKHQDQZ256rrk = 13998,

        VPUNPCKHQDQZ256rrkz = 13999,

        VPUNPCKHQDQZrm = 14000,

        VPUNPCKHQDQZrmb = 14001,

        VPUNPCKHQDQZrmbk = 14002,

        VPUNPCKHQDQZrmbkz = 14003,

        VPUNPCKHQDQZrmk = 14004,

        VPUNPCKHQDQZrmkz = 14005,

        VPUNPCKHQDQZrr = 14006,

        VPUNPCKHQDQZrrk = 14007,

        VPUNPCKHQDQZrrkz = 14008,

        VPUNPCKHQDQrm = 14009,

        VPUNPCKHQDQrr = 14010,

        VPUNPCKHWDYrm = 14011,

        VPUNPCKHWDYrr = 14012,

        VPUNPCKHWDZ128rm = 14013,

        VPUNPCKHWDZ128rmk = 14014,

        VPUNPCKHWDZ128rmkz = 14015,

        VPUNPCKHWDZ128rr = 14016,

        VPUNPCKHWDZ128rrk = 14017,

        VPUNPCKHWDZ128rrkz = 14018,

        VPUNPCKHWDZ256rm = 14019,

        VPUNPCKHWDZ256rmk = 14020,

        VPUNPCKHWDZ256rmkz = 14021,

        VPUNPCKHWDZ256rr = 14022,

        VPUNPCKHWDZ256rrk = 14023,

        VPUNPCKHWDZ256rrkz = 14024,

        VPUNPCKHWDZrm = 14025,

        VPUNPCKHWDZrmk = 14026,

        VPUNPCKHWDZrmkz = 14027,

        VPUNPCKHWDZrr = 14028,

        VPUNPCKHWDZrrk = 14029,

        VPUNPCKHWDZrrkz = 14030,

        VPUNPCKHWDrm = 14031,

        VPUNPCKHWDrr = 14032,

        VPUNPCKLBWYrm = 14033,

        VPUNPCKLBWYrr = 14034,

        VPUNPCKLBWZ128rm = 14035,

        VPUNPCKLBWZ128rmk = 14036,

        VPUNPCKLBWZ128rmkz = 14037,

        VPUNPCKLBWZ128rr = 14038,

        VPUNPCKLBWZ128rrk = 14039,

        VPUNPCKLBWZ128rrkz = 14040,

        VPUNPCKLBWZ256rm = 14041,

        VPUNPCKLBWZ256rmk = 14042,

        VPUNPCKLBWZ256rmkz = 14043,

        VPUNPCKLBWZ256rr = 14044,

        VPUNPCKLBWZ256rrk = 14045,

        VPUNPCKLBWZ256rrkz = 14046,

        VPUNPCKLBWZrm = 14047,

        VPUNPCKLBWZrmk = 14048,

        VPUNPCKLBWZrmkz = 14049,

        VPUNPCKLBWZrr = 14050,

        VPUNPCKLBWZrrk = 14051,

        VPUNPCKLBWZrrkz = 14052,

        VPUNPCKLBWrm = 14053,

        VPUNPCKLBWrr = 14054,

        VPUNPCKLDQYrm = 14055,

        VPUNPCKLDQYrr = 14056,

        VPUNPCKLDQZ128rm = 14057,

        VPUNPCKLDQZ128rmb = 14058,

        VPUNPCKLDQZ128rmbk = 14059,

        VPUNPCKLDQZ128rmbkz = 14060,

        VPUNPCKLDQZ128rmk = 14061,

        VPUNPCKLDQZ128rmkz = 14062,

        VPUNPCKLDQZ128rr = 14063,

        VPUNPCKLDQZ128rrk = 14064,

        VPUNPCKLDQZ128rrkz = 14065,

        VPUNPCKLDQZ256rm = 14066,

        VPUNPCKLDQZ256rmb = 14067,

        VPUNPCKLDQZ256rmbk = 14068,

        VPUNPCKLDQZ256rmbkz = 14069,

        VPUNPCKLDQZ256rmk = 14070,

        VPUNPCKLDQZ256rmkz = 14071,

        VPUNPCKLDQZ256rr = 14072,

        VPUNPCKLDQZ256rrk = 14073,

        VPUNPCKLDQZ256rrkz = 14074,

        VPUNPCKLDQZrm = 14075,

        VPUNPCKLDQZrmb = 14076,

        VPUNPCKLDQZrmbk = 14077,

        VPUNPCKLDQZrmbkz = 14078,

        VPUNPCKLDQZrmk = 14079,

        VPUNPCKLDQZrmkz = 14080,

        VPUNPCKLDQZrr = 14081,

        VPUNPCKLDQZrrk = 14082,

        VPUNPCKLDQZrrkz = 14083,

        VPUNPCKLDQrm = 14084,

        VPUNPCKLDQrr = 14085,

        VPUNPCKLQDQYrm = 14086,

        VPUNPCKLQDQYrr = 14087,

        VPUNPCKLQDQZ128rm = 14088,

        VPUNPCKLQDQZ128rmb = 14089,

        VPUNPCKLQDQZ128rmbk = 14090,

        VPUNPCKLQDQZ128rmbkz = 14091,

        VPUNPCKLQDQZ128rmk = 14092,

        VPUNPCKLQDQZ128rmkz = 14093,

        VPUNPCKLQDQZ128rr = 14094,

        VPUNPCKLQDQZ128rrk = 14095,

        VPUNPCKLQDQZ128rrkz = 14096,

        VPUNPCKLQDQZ256rm = 14097,

        VPUNPCKLQDQZ256rmb = 14098,

        VPUNPCKLQDQZ256rmbk = 14099,

        VPUNPCKLQDQZ256rmbkz = 14100,

        VPUNPCKLQDQZ256rmk = 14101,

        VPUNPCKLQDQZ256rmkz = 14102,

        VPUNPCKLQDQZ256rr = 14103,

        VPUNPCKLQDQZ256rrk = 14104,

        VPUNPCKLQDQZ256rrkz = 14105,

        VPUNPCKLQDQZrm = 14106,

        VPUNPCKLQDQZrmb = 14107,

        VPUNPCKLQDQZrmbk = 14108,

        VPUNPCKLQDQZrmbkz = 14109,

        VPUNPCKLQDQZrmk = 14110,

        VPUNPCKLQDQZrmkz = 14111,

        VPUNPCKLQDQZrr = 14112,

        VPUNPCKLQDQZrrk = 14113,

        VPUNPCKLQDQZrrkz = 14114,

        VPUNPCKLQDQrm = 14115,

        VPUNPCKLQDQrr = 14116,

        VPUNPCKLWDYrm = 14117,

        VPUNPCKLWDYrr = 14118,

        VPUNPCKLWDZ128rm = 14119,

        VPUNPCKLWDZ128rmk = 14120,

        VPUNPCKLWDZ128rmkz = 14121,

        VPUNPCKLWDZ128rr = 14122,

        VPUNPCKLWDZ128rrk = 14123,

        VPUNPCKLWDZ128rrkz = 14124,

        VPUNPCKLWDZ256rm = 14125,

        VPUNPCKLWDZ256rmk = 14126,

        VPUNPCKLWDZ256rmkz = 14127,

        VPUNPCKLWDZ256rr = 14128,

        VPUNPCKLWDZ256rrk = 14129,

        VPUNPCKLWDZ256rrkz = 14130,

        VPUNPCKLWDZrm = 14131,

        VPUNPCKLWDZrmk = 14132,

        VPUNPCKLWDZrmkz = 14133,

        VPUNPCKLWDZrr = 14134,

        VPUNPCKLWDZrrk = 14135,

        VPUNPCKLWDZrrkz = 14136,

        VPUNPCKLWDrm = 14137,

        VPUNPCKLWDrr = 14138,

        VPXORDZ128rm = 14139,

        VPXORDZ128rmb = 14140,

        VPXORDZ128rmbk = 14141,

        VPXORDZ128rmbkz = 14142,

        VPXORDZ128rmk = 14143,

        VPXORDZ128rmkz = 14144,

        VPXORDZ128rr = 14145,

        VPXORDZ128rrk = 14146,

        VPXORDZ128rrkz = 14147,

        VPXORDZ256rm = 14148,

        VPXORDZ256rmb = 14149,

        VPXORDZ256rmbk = 14150,

        VPXORDZ256rmbkz = 14151,

        VPXORDZ256rmk = 14152,

        VPXORDZ256rmkz = 14153,

        VPXORDZ256rr = 14154,

        VPXORDZ256rrk = 14155,

        VPXORDZ256rrkz = 14156,

        VPXORDZrm = 14157,

        VPXORDZrmb = 14158,

        VPXORDZrmbk = 14159,

        VPXORDZrmbkz = 14160,

        VPXORDZrmk = 14161,

        VPXORDZrmkz = 14162,

        VPXORDZrr = 14163,

        VPXORDZrrk = 14164,

        VPXORDZrrkz = 14165,

        VPXORQZ128rm = 14166,

        VPXORQZ128rmb = 14167,

        VPXORQZ128rmbk = 14168,

        VPXORQZ128rmbkz = 14169,

        VPXORQZ128rmk = 14170,

        VPXORQZ128rmkz = 14171,

        VPXORQZ128rr = 14172,

        VPXORQZ128rrk = 14173,

        VPXORQZ128rrkz = 14174,

        VPXORQZ256rm = 14175,

        VPXORQZ256rmb = 14176,

        VPXORQZ256rmbk = 14177,

        VPXORQZ256rmbkz = 14178,

        VPXORQZ256rmk = 14179,

        VPXORQZ256rmkz = 14180,

        VPXORQZ256rr = 14181,

        VPXORQZ256rrk = 14182,

        VPXORQZ256rrkz = 14183,

        VPXORQZrm = 14184,

        VPXORQZrmb = 14185,

        VPXORQZrmbk = 14186,

        VPXORQZrmbkz = 14187,

        VPXORQZrmk = 14188,

        VPXORQZrmkz = 14189,

        VPXORQZrr = 14190,

        VPXORQZrrk = 14191,

        VPXORQZrrkz = 14192,

        VPXORYrm = 14193,

        VPXORYrr = 14194,

        VPXORrm = 14195,

        VPXORrr = 14196,

        VRANGEPDZ128rmbi = 14197,

        VRANGEPDZ128rmbik = 14198,

        VRANGEPDZ128rmbikz = 14199,

        VRANGEPDZ128rmi = 14200,

        VRANGEPDZ128rmik = 14201,

        VRANGEPDZ128rmikz = 14202,

        VRANGEPDZ128rri = 14203,

        VRANGEPDZ128rrik = 14204,

        VRANGEPDZ128rrikz = 14205,

        VRANGEPDZ256rmbi = 14206,

        VRANGEPDZ256rmbik = 14207,

        VRANGEPDZ256rmbikz = 14208,

        VRANGEPDZ256rmi = 14209,

        VRANGEPDZ256rmik = 14210,

        VRANGEPDZ256rmikz = 14211,

        VRANGEPDZ256rri = 14212,

        VRANGEPDZ256rrik = 14213,

        VRANGEPDZ256rrikz = 14214,

        VRANGEPDZrmbi = 14215,

        VRANGEPDZrmbik = 14216,

        VRANGEPDZrmbikz = 14217,

        VRANGEPDZrmi = 14218,

        VRANGEPDZrmik = 14219,

        VRANGEPDZrmikz = 14220,

        VRANGEPDZrri = 14221,

        VRANGEPDZrrib = 14222,

        VRANGEPDZrribk = 14223,

        VRANGEPDZrribkz = 14224,

        VRANGEPDZrrik = 14225,

        VRANGEPDZrrikz = 14226,

        VRANGEPSZ128rmbi = 14227,

        VRANGEPSZ128rmbik = 14228,

        VRANGEPSZ128rmbikz = 14229,

        VRANGEPSZ128rmi = 14230,

        VRANGEPSZ128rmik = 14231,

        VRANGEPSZ128rmikz = 14232,

        VRANGEPSZ128rri = 14233,

        VRANGEPSZ128rrik = 14234,

        VRANGEPSZ128rrikz = 14235,

        VRANGEPSZ256rmbi = 14236,

        VRANGEPSZ256rmbik = 14237,

        VRANGEPSZ256rmbikz = 14238,

        VRANGEPSZ256rmi = 14239,

        VRANGEPSZ256rmik = 14240,

        VRANGEPSZ256rmikz = 14241,

        VRANGEPSZ256rri = 14242,

        VRANGEPSZ256rrik = 14243,

        VRANGEPSZ256rrikz = 14244,

        VRANGEPSZrmbi = 14245,

        VRANGEPSZrmbik = 14246,

        VRANGEPSZrmbikz = 14247,

        VRANGEPSZrmi = 14248,

        VRANGEPSZrmik = 14249,

        VRANGEPSZrmikz = 14250,

        VRANGEPSZrri = 14251,

        VRANGEPSZrrib = 14252,

        VRANGEPSZrribk = 14253,

        VRANGEPSZrribkz = 14254,

        VRANGEPSZrrik = 14255,

        VRANGEPSZrrikz = 14256,

        VRANGESDZrmi = 14257,

        VRANGESDZrmik = 14258,

        VRANGESDZrmikz = 14259,

        VRANGESDZrri = 14260,

        VRANGESDZrrib = 14261,

        VRANGESDZrribk = 14262,

        VRANGESDZrribkz = 14263,

        VRANGESDZrrik = 14264,

        VRANGESDZrrikz = 14265,

        VRANGESSZrmi = 14266,

        VRANGESSZrmik = 14267,

        VRANGESSZrmikz = 14268,

        VRANGESSZrri = 14269,

        VRANGESSZrrib = 14270,

        VRANGESSZrribk = 14271,

        VRANGESSZrribkz = 14272,

        VRANGESSZrrik = 14273,

        VRANGESSZrrikz = 14274,

        VRCP14PDZ128m = 14275,

        VRCP14PDZ128mb = 14276,

        VRCP14PDZ128mbk = 14277,

        VRCP14PDZ128mbkz = 14278,

        VRCP14PDZ128mk = 14279,

        VRCP14PDZ128mkz = 14280,

        VRCP14PDZ128r = 14281,

        VRCP14PDZ128rk = 14282,

        VRCP14PDZ128rkz = 14283,

        VRCP14PDZ256m = 14284,

        VRCP14PDZ256mb = 14285,

        VRCP14PDZ256mbk = 14286,

        VRCP14PDZ256mbkz = 14287,

        VRCP14PDZ256mk = 14288,

        VRCP14PDZ256mkz = 14289,

        VRCP14PDZ256r = 14290,

        VRCP14PDZ256rk = 14291,

        VRCP14PDZ256rkz = 14292,

        VRCP14PDZm = 14293,

        VRCP14PDZmb = 14294,

        VRCP14PDZmbk = 14295,

        VRCP14PDZmbkz = 14296,

        VRCP14PDZmk = 14297,

        VRCP14PDZmkz = 14298,

        VRCP14PDZr = 14299,

        VRCP14PDZrk = 14300,

        VRCP14PDZrkz = 14301,

        VRCP14PSZ128m = 14302,

        VRCP14PSZ128mb = 14303,

        VRCP14PSZ128mbk = 14304,

        VRCP14PSZ128mbkz = 14305,

        VRCP14PSZ128mk = 14306,

        VRCP14PSZ128mkz = 14307,

        VRCP14PSZ128r = 14308,

        VRCP14PSZ128rk = 14309,

        VRCP14PSZ128rkz = 14310,

        VRCP14PSZ256m = 14311,

        VRCP14PSZ256mb = 14312,

        VRCP14PSZ256mbk = 14313,

        VRCP14PSZ256mbkz = 14314,

        VRCP14PSZ256mk = 14315,

        VRCP14PSZ256mkz = 14316,

        VRCP14PSZ256r = 14317,

        VRCP14PSZ256rk = 14318,

        VRCP14PSZ256rkz = 14319,

        VRCP14PSZm = 14320,

        VRCP14PSZmb = 14321,

        VRCP14PSZmbk = 14322,

        VRCP14PSZmbkz = 14323,

        VRCP14PSZmk = 14324,

        VRCP14PSZmkz = 14325,

        VRCP14PSZr = 14326,

        VRCP14PSZrk = 14327,

        VRCP14PSZrkz = 14328,

        VRCP14SDZrm = 14329,

        VRCP14SDZrmk = 14330,

        VRCP14SDZrmkz = 14331,

        VRCP14SDZrr = 14332,

        VRCP14SDZrrk = 14333,

        VRCP14SDZrrkz = 14334,

        VRCP14SSZrm = 14335,

        VRCP14SSZrmk = 14336,

        VRCP14SSZrmkz = 14337,

        VRCP14SSZrr = 14338,

        VRCP14SSZrrk = 14339,

        VRCP14SSZrrkz = 14340,

        VRCP28PDZm = 14341,

        VRCP28PDZmb = 14342,

        VRCP28PDZmbk = 14343,

        VRCP28PDZmbkz = 14344,

        VRCP28PDZmk = 14345,

        VRCP28PDZmkz = 14346,

        VRCP28PDZr = 14347,

        VRCP28PDZrb = 14348,

        VRCP28PDZrbk = 14349,

        VRCP28PDZrbkz = 14350,

        VRCP28PDZrk = 14351,

        VRCP28PDZrkz = 14352,

        VRCP28PSZm = 14353,

        VRCP28PSZmb = 14354,

        VRCP28PSZmbk = 14355,

        VRCP28PSZmbkz = 14356,

        VRCP28PSZmk = 14357,

        VRCP28PSZmkz = 14358,

        VRCP28PSZr = 14359,

        VRCP28PSZrb = 14360,

        VRCP28PSZrbk = 14361,

        VRCP28PSZrbkz = 14362,

        VRCP28PSZrk = 14363,

        VRCP28PSZrkz = 14364,

        VRCP28SDZm = 14365,

        VRCP28SDZmk = 14366,

        VRCP28SDZmkz = 14367,

        VRCP28SDZr = 14368,

        VRCP28SDZrb = 14369,

        VRCP28SDZrbk = 14370,

        VRCP28SDZrbkz = 14371,

        VRCP28SDZrk = 14372,

        VRCP28SDZrkz = 14373,

        VRCP28SSZm = 14374,

        VRCP28SSZmk = 14375,

        VRCP28SSZmkz = 14376,

        VRCP28SSZr = 14377,

        VRCP28SSZrb = 14378,

        VRCP28SSZrbk = 14379,

        VRCP28SSZrbkz = 14380,

        VRCP28SSZrk = 14381,

        VRCP28SSZrkz = 14382,

        VRCPPSYm = 14383,

        VRCPPSYr = 14384,

        VRCPPSm = 14385,

        VRCPPSr = 14386,

        VRCPSSm = 14387,

        VRCPSSm_Int = 14388,

        VRCPSSr = 14389,

        VRCPSSr_Int = 14390,

        VREDUCEPDZ128rmbi = 14391,

        VREDUCEPDZ128rmbik = 14392,

        VREDUCEPDZ128rmbikz = 14393,

        VREDUCEPDZ128rmi = 14394,

        VREDUCEPDZ128rmik = 14395,

        VREDUCEPDZ128rmikz = 14396,

        VREDUCEPDZ128rri = 14397,

        VREDUCEPDZ128rrik = 14398,

        VREDUCEPDZ128rrikz = 14399,

        VREDUCEPDZ256rmbi = 14400,

        VREDUCEPDZ256rmbik = 14401,

        VREDUCEPDZ256rmbikz = 14402,

        VREDUCEPDZ256rmi = 14403,

        VREDUCEPDZ256rmik = 14404,

        VREDUCEPDZ256rmikz = 14405,

        VREDUCEPDZ256rri = 14406,

        VREDUCEPDZ256rrik = 14407,

        VREDUCEPDZ256rrikz = 14408,

        VREDUCEPDZrmbi = 14409,

        VREDUCEPDZrmbik = 14410,

        VREDUCEPDZrmbikz = 14411,

        VREDUCEPDZrmi = 14412,

        VREDUCEPDZrmik = 14413,

        VREDUCEPDZrmikz = 14414,

        VREDUCEPDZrri = 14415,

        VREDUCEPDZrrib = 14416,

        VREDUCEPDZrribk = 14417,

        VREDUCEPDZrribkz = 14418,

        VREDUCEPDZrrik = 14419,

        VREDUCEPDZrrikz = 14420,

        VREDUCEPSZ128rmbi = 14421,

        VREDUCEPSZ128rmbik = 14422,

        VREDUCEPSZ128rmbikz = 14423,

        VREDUCEPSZ128rmi = 14424,

        VREDUCEPSZ128rmik = 14425,

        VREDUCEPSZ128rmikz = 14426,

        VREDUCEPSZ128rri = 14427,

        VREDUCEPSZ128rrik = 14428,

        VREDUCEPSZ128rrikz = 14429,

        VREDUCEPSZ256rmbi = 14430,

        VREDUCEPSZ256rmbik = 14431,

        VREDUCEPSZ256rmbikz = 14432,

        VREDUCEPSZ256rmi = 14433,

        VREDUCEPSZ256rmik = 14434,

        VREDUCEPSZ256rmikz = 14435,

        VREDUCEPSZ256rri = 14436,

        VREDUCEPSZ256rrik = 14437,

        VREDUCEPSZ256rrikz = 14438,

        VREDUCEPSZrmbi = 14439,

        VREDUCEPSZrmbik = 14440,

        VREDUCEPSZrmbikz = 14441,

        VREDUCEPSZrmi = 14442,

        VREDUCEPSZrmik = 14443,

        VREDUCEPSZrmikz = 14444,

        VREDUCEPSZrri = 14445,

        VREDUCEPSZrrib = 14446,

        VREDUCEPSZrribk = 14447,

        VREDUCEPSZrribkz = 14448,

        VREDUCEPSZrrik = 14449,

        VREDUCEPSZrrikz = 14450,

        VREDUCESDZrmi = 14451,

        VREDUCESDZrmik = 14452,

        VREDUCESDZrmikz = 14453,

        VREDUCESDZrri = 14454,

        VREDUCESDZrrib = 14455,

        VREDUCESDZrribk = 14456,

        VREDUCESDZrribkz = 14457,

        VREDUCESDZrrik = 14458,

        VREDUCESDZrrikz = 14459,

        VREDUCESSZrmi = 14460,

        VREDUCESSZrmik = 14461,

        VREDUCESSZrmikz = 14462,

        VREDUCESSZrri = 14463,

        VREDUCESSZrrib = 14464,

        VREDUCESSZrribk = 14465,

        VREDUCESSZrribkz = 14466,

        VREDUCESSZrrik = 14467,

        VREDUCESSZrrikz = 14468,

        VRNDSCALEPDZ128rmbi = 14469,

        VRNDSCALEPDZ128rmbik = 14470,

        VRNDSCALEPDZ128rmbikz = 14471,

        VRNDSCALEPDZ128rmi = 14472,

        VRNDSCALEPDZ128rmik = 14473,

        VRNDSCALEPDZ128rmikz = 14474,

        VRNDSCALEPDZ128rri = 14475,

        VRNDSCALEPDZ128rrik = 14476,

        VRNDSCALEPDZ128rrikz = 14477,

        VRNDSCALEPDZ256rmbi = 14478,

        VRNDSCALEPDZ256rmbik = 14479,

        VRNDSCALEPDZ256rmbikz = 14480,

        VRNDSCALEPDZ256rmi = 14481,

        VRNDSCALEPDZ256rmik = 14482,

        VRNDSCALEPDZ256rmikz = 14483,

        VRNDSCALEPDZ256rri = 14484,

        VRNDSCALEPDZ256rrik = 14485,

        VRNDSCALEPDZ256rrikz = 14486,

        VRNDSCALEPDZrmbi = 14487,

        VRNDSCALEPDZrmbik = 14488,

        VRNDSCALEPDZrmbikz = 14489,

        VRNDSCALEPDZrmi = 14490,

        VRNDSCALEPDZrmik = 14491,

        VRNDSCALEPDZrmikz = 14492,

        VRNDSCALEPDZrri = 14493,

        VRNDSCALEPDZrrib = 14494,

        VRNDSCALEPDZrribk = 14495,

        VRNDSCALEPDZrribkz = 14496,

        VRNDSCALEPDZrrik = 14497,

        VRNDSCALEPDZrrikz = 14498,

        VRNDSCALEPSZ128rmbi = 14499,

        VRNDSCALEPSZ128rmbik = 14500,

        VRNDSCALEPSZ128rmbikz = 14501,

        VRNDSCALEPSZ128rmi = 14502,

        VRNDSCALEPSZ128rmik = 14503,

        VRNDSCALEPSZ128rmikz = 14504,

        VRNDSCALEPSZ128rri = 14505,

        VRNDSCALEPSZ128rrik = 14506,

        VRNDSCALEPSZ128rrikz = 14507,

        VRNDSCALEPSZ256rmbi = 14508,

        VRNDSCALEPSZ256rmbik = 14509,

        VRNDSCALEPSZ256rmbikz = 14510,

        VRNDSCALEPSZ256rmi = 14511,

        VRNDSCALEPSZ256rmik = 14512,

        VRNDSCALEPSZ256rmikz = 14513,

        VRNDSCALEPSZ256rri = 14514,

        VRNDSCALEPSZ256rrik = 14515,

        VRNDSCALEPSZ256rrikz = 14516,

        VRNDSCALEPSZrmbi = 14517,

        VRNDSCALEPSZrmbik = 14518,

        VRNDSCALEPSZrmbikz = 14519,

        VRNDSCALEPSZrmi = 14520,

        VRNDSCALEPSZrmik = 14521,

        VRNDSCALEPSZrmikz = 14522,

        VRNDSCALEPSZrri = 14523,

        VRNDSCALEPSZrrib = 14524,

        VRNDSCALEPSZrribk = 14525,

        VRNDSCALEPSZrribkz = 14526,

        VRNDSCALEPSZrrik = 14527,

        VRNDSCALEPSZrrikz = 14528,

        VRNDSCALESDZm = 14529,

        VRNDSCALESDZm_Int = 14530,

        VRNDSCALESDZm_Intk = 14531,

        VRNDSCALESDZm_Intkz = 14532,

        VRNDSCALESDZr = 14533,

        VRNDSCALESDZr_Int = 14534,

        VRNDSCALESDZr_Intk = 14535,

        VRNDSCALESDZr_Intkz = 14536,

        VRNDSCALESDZrb_Int = 14537,

        VRNDSCALESDZrb_Intk = 14538,

        VRNDSCALESDZrb_Intkz = 14539,

        VRNDSCALESSZm = 14540,

        VRNDSCALESSZm_Int = 14541,

        VRNDSCALESSZm_Intk = 14542,

        VRNDSCALESSZm_Intkz = 14543,

        VRNDSCALESSZr = 14544,

        VRNDSCALESSZr_Int = 14545,

        VRNDSCALESSZr_Intk = 14546,

        VRNDSCALESSZr_Intkz = 14547,

        VRNDSCALESSZrb_Int = 14548,

        VRNDSCALESSZrb_Intk = 14549,

        VRNDSCALESSZrb_Intkz = 14550,

        VROUNDPDYm = 14551,

        VROUNDPDYr = 14552,

        VROUNDPDm = 14553,

        VROUNDPDr = 14554,

        VROUNDPSYm = 14555,

        VROUNDPSYr = 14556,

        VROUNDPSm = 14557,

        VROUNDPSr = 14558,

        VROUNDSDm = 14559,

        VROUNDSDm_Int = 14560,

        VROUNDSDr = 14561,

        VROUNDSDr_Int = 14562,

        VROUNDSSm = 14563,

        VROUNDSSm_Int = 14564,

        VROUNDSSr = 14565,

        VROUNDSSr_Int = 14566,

        VRSQRT14PDZ128m = 14567,

        VRSQRT14PDZ128mb = 14568,

        VRSQRT14PDZ128mbk = 14569,

        VRSQRT14PDZ128mbkz = 14570,

        VRSQRT14PDZ128mk = 14571,

        VRSQRT14PDZ128mkz = 14572,

        VRSQRT14PDZ128r = 14573,

        VRSQRT14PDZ128rk = 14574,

        VRSQRT14PDZ128rkz = 14575,

        VRSQRT14PDZ256m = 14576,

        VRSQRT14PDZ256mb = 14577,

        VRSQRT14PDZ256mbk = 14578,

        VRSQRT14PDZ256mbkz = 14579,

        VRSQRT14PDZ256mk = 14580,

        VRSQRT14PDZ256mkz = 14581,

        VRSQRT14PDZ256r = 14582,

        VRSQRT14PDZ256rk = 14583,

        VRSQRT14PDZ256rkz = 14584,

        VRSQRT14PDZm = 14585,

        VRSQRT14PDZmb = 14586,

        VRSQRT14PDZmbk = 14587,

        VRSQRT14PDZmbkz = 14588,

        VRSQRT14PDZmk = 14589,

        VRSQRT14PDZmkz = 14590,

        VRSQRT14PDZr = 14591,

        VRSQRT14PDZrk = 14592,

        VRSQRT14PDZrkz = 14593,

        VRSQRT14PSZ128m = 14594,

        VRSQRT14PSZ128mb = 14595,

        VRSQRT14PSZ128mbk = 14596,

        VRSQRT14PSZ128mbkz = 14597,

        VRSQRT14PSZ128mk = 14598,

        VRSQRT14PSZ128mkz = 14599,

        VRSQRT14PSZ128r = 14600,

        VRSQRT14PSZ128rk = 14601,

        VRSQRT14PSZ128rkz = 14602,

        VRSQRT14PSZ256m = 14603,

        VRSQRT14PSZ256mb = 14604,

        VRSQRT14PSZ256mbk = 14605,

        VRSQRT14PSZ256mbkz = 14606,

        VRSQRT14PSZ256mk = 14607,

        VRSQRT14PSZ256mkz = 14608,

        VRSQRT14PSZ256r = 14609,

        VRSQRT14PSZ256rk = 14610,

        VRSQRT14PSZ256rkz = 14611,

        VRSQRT14PSZm = 14612,

        VRSQRT14PSZmb = 14613,

        VRSQRT14PSZmbk = 14614,

        VRSQRT14PSZmbkz = 14615,

        VRSQRT14PSZmk = 14616,

        VRSQRT14PSZmkz = 14617,

        VRSQRT14PSZr = 14618,

        VRSQRT14PSZrk = 14619,

        VRSQRT14PSZrkz = 14620,

        VRSQRT14SDZrm = 14621,

        VRSQRT14SDZrmk = 14622,

        VRSQRT14SDZrmkz = 14623,

        VRSQRT14SDZrr = 14624,

        VRSQRT14SDZrrk = 14625,

        VRSQRT14SDZrrkz = 14626,

        VRSQRT14SSZrm = 14627,

        VRSQRT14SSZrmk = 14628,

        VRSQRT14SSZrmkz = 14629,

        VRSQRT14SSZrr = 14630,

        VRSQRT14SSZrrk = 14631,

        VRSQRT14SSZrrkz = 14632,

        VRSQRT28PDZm = 14633,

        VRSQRT28PDZmb = 14634,

        VRSQRT28PDZmbk = 14635,

        VRSQRT28PDZmbkz = 14636,

        VRSQRT28PDZmk = 14637,

        VRSQRT28PDZmkz = 14638,

        VRSQRT28PDZr = 14639,

        VRSQRT28PDZrb = 14640,

        VRSQRT28PDZrbk = 14641,

        VRSQRT28PDZrbkz = 14642,

        VRSQRT28PDZrk = 14643,

        VRSQRT28PDZrkz = 14644,

        VRSQRT28PSZm = 14645,

        VRSQRT28PSZmb = 14646,

        VRSQRT28PSZmbk = 14647,

        VRSQRT28PSZmbkz = 14648,

        VRSQRT28PSZmk = 14649,

        VRSQRT28PSZmkz = 14650,

        VRSQRT28PSZr = 14651,

        VRSQRT28PSZrb = 14652,

        VRSQRT28PSZrbk = 14653,

        VRSQRT28PSZrbkz = 14654,

        VRSQRT28PSZrk = 14655,

        VRSQRT28PSZrkz = 14656,

        VRSQRT28SDZm = 14657,

        VRSQRT28SDZmk = 14658,

        VRSQRT28SDZmkz = 14659,

        VRSQRT28SDZr = 14660,

        VRSQRT28SDZrb = 14661,

        VRSQRT28SDZrbk = 14662,

        VRSQRT28SDZrbkz = 14663,

        VRSQRT28SDZrk = 14664,

        VRSQRT28SDZrkz = 14665,

        VRSQRT28SSZm = 14666,

        VRSQRT28SSZmk = 14667,

        VRSQRT28SSZmkz = 14668,

        VRSQRT28SSZr = 14669,

        VRSQRT28SSZrb = 14670,

        VRSQRT28SSZrbk = 14671,

        VRSQRT28SSZrbkz = 14672,

        VRSQRT28SSZrk = 14673,

        VRSQRT28SSZrkz = 14674,

        VRSQRTPSYm = 14675,

        VRSQRTPSYr = 14676,

        VRSQRTPSm = 14677,

        VRSQRTPSr = 14678,

        VRSQRTSSm = 14679,

        VRSQRTSSm_Int = 14680,

        VRSQRTSSr = 14681,

        VRSQRTSSr_Int = 14682,

        VSCALEFPDZ128rm = 14683,

        VSCALEFPDZ128rmb = 14684,

        VSCALEFPDZ128rmbk = 14685,

        VSCALEFPDZ128rmbkz = 14686,

        VSCALEFPDZ128rmk = 14687,

        VSCALEFPDZ128rmkz = 14688,

        VSCALEFPDZ128rr = 14689,

        VSCALEFPDZ128rrk = 14690,

        VSCALEFPDZ128rrkz = 14691,

        VSCALEFPDZ256rm = 14692,

        VSCALEFPDZ256rmb = 14693,

        VSCALEFPDZ256rmbk = 14694,

        VSCALEFPDZ256rmbkz = 14695,

        VSCALEFPDZ256rmk = 14696,

        VSCALEFPDZ256rmkz = 14697,

        VSCALEFPDZ256rr = 14698,

        VSCALEFPDZ256rrk = 14699,

        VSCALEFPDZ256rrkz = 14700,

        VSCALEFPDZrm = 14701,

        VSCALEFPDZrmb = 14702,

        VSCALEFPDZrmbk = 14703,

        VSCALEFPDZrmbkz = 14704,

        VSCALEFPDZrmk = 14705,

        VSCALEFPDZrmkz = 14706,

        VSCALEFPDZrr = 14707,

        VSCALEFPDZrrb = 14708,

        VSCALEFPDZrrbk = 14709,

        VSCALEFPDZrrbkz = 14710,

        VSCALEFPDZrrk = 14711,

        VSCALEFPDZrrkz = 14712,

        VSCALEFPSZ128rm = 14713,

        VSCALEFPSZ128rmb = 14714,

        VSCALEFPSZ128rmbk = 14715,

        VSCALEFPSZ128rmbkz = 14716,

        VSCALEFPSZ128rmk = 14717,

        VSCALEFPSZ128rmkz = 14718,

        VSCALEFPSZ128rr = 14719,

        VSCALEFPSZ128rrk = 14720,

        VSCALEFPSZ128rrkz = 14721,

        VSCALEFPSZ256rm = 14722,

        VSCALEFPSZ256rmb = 14723,

        VSCALEFPSZ256rmbk = 14724,

        VSCALEFPSZ256rmbkz = 14725,

        VSCALEFPSZ256rmk = 14726,

        VSCALEFPSZ256rmkz = 14727,

        VSCALEFPSZ256rr = 14728,

        VSCALEFPSZ256rrk = 14729,

        VSCALEFPSZ256rrkz = 14730,

        VSCALEFPSZrm = 14731,

        VSCALEFPSZrmb = 14732,

        VSCALEFPSZrmbk = 14733,

        VSCALEFPSZrmbkz = 14734,

        VSCALEFPSZrmk = 14735,

        VSCALEFPSZrmkz = 14736,

        VSCALEFPSZrr = 14737,

        VSCALEFPSZrrb = 14738,

        VSCALEFPSZrrbk = 14739,

        VSCALEFPSZrrbkz = 14740,

        VSCALEFPSZrrk = 14741,

        VSCALEFPSZrrkz = 14742,

        VSCALEFSDZrm = 14743,

        VSCALEFSDZrmk = 14744,

        VSCALEFSDZrmkz = 14745,

        VSCALEFSDZrr = 14746,

        VSCALEFSDZrrb_Int = 14747,

        VSCALEFSDZrrb_Intk = 14748,

        VSCALEFSDZrrb_Intkz = 14749,

        VSCALEFSDZrrk = 14750,

        VSCALEFSDZrrkz = 14751,

        VSCALEFSSZrm = 14752,

        VSCALEFSSZrmk = 14753,

        VSCALEFSSZrmkz = 14754,

        VSCALEFSSZrr = 14755,

        VSCALEFSSZrrb_Int = 14756,

        VSCALEFSSZrrb_Intk = 14757,

        VSCALEFSSZrrb_Intkz = 14758,

        VSCALEFSSZrrk = 14759,

        VSCALEFSSZrrkz = 14760,

        VSCATTERDPDZ128mr = 14761,

        VSCATTERDPDZ256mr = 14762,

        VSCATTERDPDZmr = 14763,

        VSCATTERDPSZ128mr = 14764,

        VSCATTERDPSZ256mr = 14765,

        VSCATTERDPSZmr = 14766,

        VSCATTERPF0DPDm = 14767,

        VSCATTERPF0DPSm = 14768,

        VSCATTERPF0QPDm = 14769,

        VSCATTERPF0QPSm = 14770,

        VSCATTERPF1DPDm = 14771,

        VSCATTERPF1DPSm = 14772,

        VSCATTERPF1QPDm = 14773,

        VSCATTERPF1QPSm = 14774,

        VSCATTERQPDZ128mr = 14775,

        VSCATTERQPDZ256mr = 14776,

        VSCATTERQPDZmr = 14777,

        VSCATTERQPSZ128mr = 14778,

        VSCATTERQPSZ256mr = 14779,

        VSCATTERQPSZmr = 14780,

        VSHUFF32X4Z256rmbi = 14781,

        VSHUFF32X4Z256rmbik = 14782,

        VSHUFF32X4Z256rmbikz = 14783,

        VSHUFF32X4Z256rmi = 14784,

        VSHUFF32X4Z256rmik = 14785,

        VSHUFF32X4Z256rmikz = 14786,

        VSHUFF32X4Z256rri = 14787,

        VSHUFF32X4Z256rrik = 14788,

        VSHUFF32X4Z256rrikz = 14789,

        VSHUFF32X4Zrmbi = 14790,

        VSHUFF32X4Zrmbik = 14791,

        VSHUFF32X4Zrmbikz = 14792,

        VSHUFF32X4Zrmi = 14793,

        VSHUFF32X4Zrmik = 14794,

        VSHUFF32X4Zrmikz = 14795,

        VSHUFF32X4Zrri = 14796,

        VSHUFF32X4Zrrik = 14797,

        VSHUFF32X4Zrrikz = 14798,

        VSHUFF64X2Z256rmbi = 14799,

        VSHUFF64X2Z256rmbik = 14800,

        VSHUFF64X2Z256rmbikz = 14801,

        VSHUFF64X2Z256rmi = 14802,

        VSHUFF64X2Z256rmik = 14803,

        VSHUFF64X2Z256rmikz = 14804,

        VSHUFF64X2Z256rri = 14805,

        VSHUFF64X2Z256rrik = 14806,

        VSHUFF64X2Z256rrikz = 14807,

        VSHUFF64X2Zrmbi = 14808,

        VSHUFF64X2Zrmbik = 14809,

        VSHUFF64X2Zrmbikz = 14810,

        VSHUFF64X2Zrmi = 14811,

        VSHUFF64X2Zrmik = 14812,

        VSHUFF64X2Zrmikz = 14813,

        VSHUFF64X2Zrri = 14814,

        VSHUFF64X2Zrrik = 14815,

        VSHUFF64X2Zrrikz = 14816,

        VSHUFI32X4Z256rmbi = 14817,

        VSHUFI32X4Z256rmbik = 14818,

        VSHUFI32X4Z256rmbikz = 14819,

        VSHUFI32X4Z256rmi = 14820,

        VSHUFI32X4Z256rmik = 14821,

        VSHUFI32X4Z256rmikz = 14822,

        VSHUFI32X4Z256rri = 14823,

        VSHUFI32X4Z256rrik = 14824,

        VSHUFI32X4Z256rrikz = 14825,

        VSHUFI32X4Zrmbi = 14826,

        VSHUFI32X4Zrmbik = 14827,

        VSHUFI32X4Zrmbikz = 14828,

        VSHUFI32X4Zrmi = 14829,

        VSHUFI32X4Zrmik = 14830,

        VSHUFI32X4Zrmikz = 14831,

        VSHUFI32X4Zrri = 14832,

        VSHUFI32X4Zrrik = 14833,

        VSHUFI32X4Zrrikz = 14834,

        VSHUFI64X2Z256rmbi = 14835,

        VSHUFI64X2Z256rmbik = 14836,

        VSHUFI64X2Z256rmbikz = 14837,

        VSHUFI64X2Z256rmi = 14838,

        VSHUFI64X2Z256rmik = 14839,

        VSHUFI64X2Z256rmikz = 14840,

        VSHUFI64X2Z256rri = 14841,

        VSHUFI64X2Z256rrik = 14842,

        VSHUFI64X2Z256rrikz = 14843,

        VSHUFI64X2Zrmbi = 14844,

        VSHUFI64X2Zrmbik = 14845,

        VSHUFI64X2Zrmbikz = 14846,

        VSHUFI64X2Zrmi = 14847,

        VSHUFI64X2Zrmik = 14848,

        VSHUFI64X2Zrmikz = 14849,

        VSHUFI64X2Zrri = 14850,

        VSHUFI64X2Zrrik = 14851,

        VSHUFI64X2Zrrikz = 14852,

        VSHUFPDYrmi = 14853,

        VSHUFPDYrri = 14854,

        VSHUFPDZ128rmbi = 14855,

        VSHUFPDZ128rmbik = 14856,

        VSHUFPDZ128rmbikz = 14857,

        VSHUFPDZ128rmi = 14858,

        VSHUFPDZ128rmik = 14859,

        VSHUFPDZ128rmikz = 14860,

        VSHUFPDZ128rri = 14861,

        VSHUFPDZ128rrik = 14862,

        VSHUFPDZ128rrikz = 14863,

        VSHUFPDZ256rmbi = 14864,

        VSHUFPDZ256rmbik = 14865,

        VSHUFPDZ256rmbikz = 14866,

        VSHUFPDZ256rmi = 14867,

        VSHUFPDZ256rmik = 14868,

        VSHUFPDZ256rmikz = 14869,

        VSHUFPDZ256rri = 14870,

        VSHUFPDZ256rrik = 14871,

        VSHUFPDZ256rrikz = 14872,

        VSHUFPDZrmbi = 14873,

        VSHUFPDZrmbik = 14874,

        VSHUFPDZrmbikz = 14875,

        VSHUFPDZrmi = 14876,

        VSHUFPDZrmik = 14877,

        VSHUFPDZrmikz = 14878,

        VSHUFPDZrri = 14879,

        VSHUFPDZrrik = 14880,

        VSHUFPDZrrikz = 14881,

        VSHUFPDrmi = 14882,

        VSHUFPDrri = 14883,

        VSHUFPSYrmi = 14884,

        VSHUFPSYrri = 14885,

        VSHUFPSZ128rmbi = 14886,

        VSHUFPSZ128rmbik = 14887,

        VSHUFPSZ128rmbikz = 14888,

        VSHUFPSZ128rmi = 14889,

        VSHUFPSZ128rmik = 14890,

        VSHUFPSZ128rmikz = 14891,

        VSHUFPSZ128rri = 14892,

        VSHUFPSZ128rrik = 14893,

        VSHUFPSZ128rrikz = 14894,

        VSHUFPSZ256rmbi = 14895,

        VSHUFPSZ256rmbik = 14896,

        VSHUFPSZ256rmbikz = 14897,

        VSHUFPSZ256rmi = 14898,

        VSHUFPSZ256rmik = 14899,

        VSHUFPSZ256rmikz = 14900,

        VSHUFPSZ256rri = 14901,

        VSHUFPSZ256rrik = 14902,

        VSHUFPSZ256rrikz = 14903,

        VSHUFPSZrmbi = 14904,

        VSHUFPSZrmbik = 14905,

        VSHUFPSZrmbikz = 14906,

        VSHUFPSZrmi = 14907,

        VSHUFPSZrmik = 14908,

        VSHUFPSZrmikz = 14909,

        VSHUFPSZrri = 14910,

        VSHUFPSZrrik = 14911,

        VSHUFPSZrrikz = 14912,

        VSHUFPSrmi = 14913,

        VSHUFPSrri = 14914,

        VSQRTPDYm = 14915,

        VSQRTPDYr = 14916,

        VSQRTPDZ128m = 14917,

        VSQRTPDZ128mb = 14918,

        VSQRTPDZ128mbk = 14919,

        VSQRTPDZ128mbkz = 14920,

        VSQRTPDZ128mk = 14921,

        VSQRTPDZ128mkz = 14922,

        VSQRTPDZ128r = 14923,

        VSQRTPDZ128rk = 14924,

        VSQRTPDZ128rkz = 14925,

        VSQRTPDZ256m = 14926,

        VSQRTPDZ256mb = 14927,

        VSQRTPDZ256mbk = 14928,

        VSQRTPDZ256mbkz = 14929,

        VSQRTPDZ256mk = 14930,

        VSQRTPDZ256mkz = 14931,

        VSQRTPDZ256r = 14932,

        VSQRTPDZ256rk = 14933,

        VSQRTPDZ256rkz = 14934,

        VSQRTPDZm = 14935,

        VSQRTPDZmb = 14936,

        VSQRTPDZmbk = 14937,

        VSQRTPDZmbkz = 14938,

        VSQRTPDZmk = 14939,

        VSQRTPDZmkz = 14940,

        VSQRTPDZr = 14941,

        VSQRTPDZrb = 14942,

        VSQRTPDZrbk = 14943,

        VSQRTPDZrbkz = 14944,

        VSQRTPDZrk = 14945,

        VSQRTPDZrkz = 14946,

        VSQRTPDm = 14947,

        VSQRTPDr = 14948,

        VSQRTPSYm = 14949,

        VSQRTPSYr = 14950,

        VSQRTPSZ128m = 14951,

        VSQRTPSZ128mb = 14952,

        VSQRTPSZ128mbk = 14953,

        VSQRTPSZ128mbkz = 14954,

        VSQRTPSZ128mk = 14955,

        VSQRTPSZ128mkz = 14956,

        VSQRTPSZ128r = 14957,

        VSQRTPSZ128rk = 14958,

        VSQRTPSZ128rkz = 14959,

        VSQRTPSZ256m = 14960,

        VSQRTPSZ256mb = 14961,

        VSQRTPSZ256mbk = 14962,

        VSQRTPSZ256mbkz = 14963,

        VSQRTPSZ256mk = 14964,

        VSQRTPSZ256mkz = 14965,

        VSQRTPSZ256r = 14966,

        VSQRTPSZ256rk = 14967,

        VSQRTPSZ256rkz = 14968,

        VSQRTPSZm = 14969,

        VSQRTPSZmb = 14970,

        VSQRTPSZmbk = 14971,

        VSQRTPSZmbkz = 14972,

        VSQRTPSZmk = 14973,

        VSQRTPSZmkz = 14974,

        VSQRTPSZr = 14975,

        VSQRTPSZrb = 14976,

        VSQRTPSZrbk = 14977,

        VSQRTPSZrbkz = 14978,

        VSQRTPSZrk = 14979,

        VSQRTPSZrkz = 14980,

        VSQRTPSm = 14981,

        VSQRTPSr = 14982,

        VSQRTSDZm = 14983,

        VSQRTSDZm_Int = 14984,

        VSQRTSDZm_Intk = 14985,

        VSQRTSDZm_Intkz = 14986,

        VSQRTSDZr = 14987,

        VSQRTSDZr_Int = 14988,

        VSQRTSDZr_Intk = 14989,

        VSQRTSDZr_Intkz = 14990,

        VSQRTSDZrb_Int = 14991,

        VSQRTSDZrb_Intk = 14992,

        VSQRTSDZrb_Intkz = 14993,

        VSQRTSDm = 14994,

        VSQRTSDm_Int = 14995,

        VSQRTSDr = 14996,

        VSQRTSDr_Int = 14997,

        VSQRTSSZm = 14998,

        VSQRTSSZm_Int = 14999,

        VSQRTSSZm_Intk = 15000,

        VSQRTSSZm_Intkz = 15001,

        VSQRTSSZr = 15002,

        VSQRTSSZr_Int = 15003,

        VSQRTSSZr_Intk = 15004,

        VSQRTSSZr_Intkz = 15005,

        VSQRTSSZrb_Int = 15006,

        VSQRTSSZrb_Intk = 15007,

        VSQRTSSZrb_Intkz = 15008,

        VSQRTSSm = 15009,

        VSQRTSSm_Int = 15010,

        VSQRTSSr = 15011,

        VSQRTSSr_Int = 15012,

        VSTMXCSR = 15013,

        VSUBPDYrm = 15014,

        VSUBPDYrr = 15015,

        VSUBPDZ128rm = 15016,

        VSUBPDZ128rmb = 15017,

        VSUBPDZ128rmbk = 15018,

        VSUBPDZ128rmbkz = 15019,

        VSUBPDZ128rmk = 15020,

        VSUBPDZ128rmkz = 15021,

        VSUBPDZ128rr = 15022,

        VSUBPDZ128rrk = 15023,

        VSUBPDZ128rrkz = 15024,

        VSUBPDZ256rm = 15025,

        VSUBPDZ256rmb = 15026,

        VSUBPDZ256rmbk = 15027,

        VSUBPDZ256rmbkz = 15028,

        VSUBPDZ256rmk = 15029,

        VSUBPDZ256rmkz = 15030,

        VSUBPDZ256rr = 15031,

        VSUBPDZ256rrk = 15032,

        VSUBPDZ256rrkz = 15033,

        VSUBPDZrm = 15034,

        VSUBPDZrmb = 15035,

        VSUBPDZrmbk = 15036,

        VSUBPDZrmbkz = 15037,

        VSUBPDZrmk = 15038,

        VSUBPDZrmkz = 15039,

        VSUBPDZrr = 15040,

        VSUBPDZrrb = 15041,

        VSUBPDZrrbk = 15042,

        VSUBPDZrrbkz = 15043,

        VSUBPDZrrk = 15044,

        VSUBPDZrrkz = 15045,

        VSUBPDrm = 15046,

        VSUBPDrr = 15047,

        VSUBPSYrm = 15048,

        VSUBPSYrr = 15049,

        VSUBPSZ128rm = 15050,

        VSUBPSZ128rmb = 15051,

        VSUBPSZ128rmbk = 15052,

        VSUBPSZ128rmbkz = 15053,

        VSUBPSZ128rmk = 15054,

        VSUBPSZ128rmkz = 15055,

        VSUBPSZ128rr = 15056,

        VSUBPSZ128rrk = 15057,

        VSUBPSZ128rrkz = 15058,

        VSUBPSZ256rm = 15059,

        VSUBPSZ256rmb = 15060,

        VSUBPSZ256rmbk = 15061,

        VSUBPSZ256rmbkz = 15062,

        VSUBPSZ256rmk = 15063,

        VSUBPSZ256rmkz = 15064,

        VSUBPSZ256rr = 15065,

        VSUBPSZ256rrk = 15066,

        VSUBPSZ256rrkz = 15067,

        VSUBPSZrm = 15068,

        VSUBPSZrmb = 15069,

        VSUBPSZrmbk = 15070,

        VSUBPSZrmbkz = 15071,

        VSUBPSZrmk = 15072,

        VSUBPSZrmkz = 15073,

        VSUBPSZrr = 15074,

        VSUBPSZrrb = 15075,

        VSUBPSZrrbk = 15076,

        VSUBPSZrrbkz = 15077,

        VSUBPSZrrk = 15078,

        VSUBPSZrrkz = 15079,

        VSUBPSrm = 15080,

        VSUBPSrr = 15081,

        VSUBSDZrm = 15082,

        VSUBSDZrm_Int = 15083,

        VSUBSDZrm_Intk = 15084,

        VSUBSDZrm_Intkz = 15085,

        VSUBSDZrr = 15086,

        VSUBSDZrr_Int = 15087,

        VSUBSDZrr_Intk = 15088,

        VSUBSDZrr_Intkz = 15089,

        VSUBSDZrrb_Int = 15090,

        VSUBSDZrrb_Intk = 15091,

        VSUBSDZrrb_Intkz = 15092,

        VSUBSDrm = 15093,

        VSUBSDrm_Int = 15094,

        VSUBSDrr = 15095,

        VSUBSDrr_Int = 15096,

        VSUBSSZrm = 15097,

        VSUBSSZrm_Int = 15098,

        VSUBSSZrm_Intk = 15099,

        VSUBSSZrm_Intkz = 15100,

        VSUBSSZrr = 15101,

        VSUBSSZrr_Int = 15102,

        VSUBSSZrr_Intk = 15103,

        VSUBSSZrr_Intkz = 15104,

        VSUBSSZrrb_Int = 15105,

        VSUBSSZrrb_Intk = 15106,

        VSUBSSZrrb_Intkz = 15107,

        VSUBSSrm = 15108,

        VSUBSSrm_Int = 15109,

        VSUBSSrr = 15110,

        VSUBSSrr_Int = 15111,

        VTESTPDYrm = 15112,

        VTESTPDYrr = 15113,

        VTESTPDrm = 15114,

        VTESTPDrr = 15115,

        VTESTPSYrm = 15116,

        VTESTPSYrr = 15117,

        VTESTPSrm = 15118,

        VTESTPSrr = 15119,

        VUCOMISDZrm = 15120,

        VUCOMISDZrm_Int = 15121,

        VUCOMISDZrr = 15122,

        VUCOMISDZrr_Int = 15123,

        VUCOMISDZrrb = 15124,

        VUCOMISDrm = 15125,

        VUCOMISDrm_Int = 15126,

        VUCOMISDrr = 15127,

        VUCOMISDrr_Int = 15128,

        VUCOMISSZrm = 15129,

        VUCOMISSZrm_Int = 15130,

        VUCOMISSZrr = 15131,

        VUCOMISSZrr_Int = 15132,

        VUCOMISSZrrb = 15133,

        VUCOMISSrm = 15134,

        VUCOMISSrm_Int = 15135,

        VUCOMISSrr = 15136,

        VUCOMISSrr_Int = 15137,

        VUNPCKHPDYrm = 15138,

        VUNPCKHPDYrr = 15139,

        VUNPCKHPDZ128rm = 15140,

        VUNPCKHPDZ128rmb = 15141,

        VUNPCKHPDZ128rmbk = 15142,

        VUNPCKHPDZ128rmbkz = 15143,

        VUNPCKHPDZ128rmk = 15144,

        VUNPCKHPDZ128rmkz = 15145,

        VUNPCKHPDZ128rr = 15146,

        VUNPCKHPDZ128rrk = 15147,

        VUNPCKHPDZ128rrkz = 15148,

        VUNPCKHPDZ256rm = 15149,

        VUNPCKHPDZ256rmb = 15150,

        VUNPCKHPDZ256rmbk = 15151,

        VUNPCKHPDZ256rmbkz = 15152,

        VUNPCKHPDZ256rmk = 15153,

        VUNPCKHPDZ256rmkz = 15154,

        VUNPCKHPDZ256rr = 15155,

        VUNPCKHPDZ256rrk = 15156,

        VUNPCKHPDZ256rrkz = 15157,

        VUNPCKHPDZrm = 15158,

        VUNPCKHPDZrmb = 15159,

        VUNPCKHPDZrmbk = 15160,

        VUNPCKHPDZrmbkz = 15161,

        VUNPCKHPDZrmk = 15162,

        VUNPCKHPDZrmkz = 15163,

        VUNPCKHPDZrr = 15164,

        VUNPCKHPDZrrk = 15165,

        VUNPCKHPDZrrkz = 15166,

        VUNPCKHPDrm = 15167,

        VUNPCKHPDrr = 15168,

        VUNPCKHPSYrm = 15169,

        VUNPCKHPSYrr = 15170,

        VUNPCKHPSZ128rm = 15171,

        VUNPCKHPSZ128rmb = 15172,

        VUNPCKHPSZ128rmbk = 15173,

        VUNPCKHPSZ128rmbkz = 15174,

        VUNPCKHPSZ128rmk = 15175,

        VUNPCKHPSZ128rmkz = 15176,

        VUNPCKHPSZ128rr = 15177,

        VUNPCKHPSZ128rrk = 15178,

        VUNPCKHPSZ128rrkz = 15179,

        VUNPCKHPSZ256rm = 15180,

        VUNPCKHPSZ256rmb = 15181,

        VUNPCKHPSZ256rmbk = 15182,

        VUNPCKHPSZ256rmbkz = 15183,

        VUNPCKHPSZ256rmk = 15184,

        VUNPCKHPSZ256rmkz = 15185,

        VUNPCKHPSZ256rr = 15186,

        VUNPCKHPSZ256rrk = 15187,

        VUNPCKHPSZ256rrkz = 15188,

        VUNPCKHPSZrm = 15189,

        VUNPCKHPSZrmb = 15190,

        VUNPCKHPSZrmbk = 15191,

        VUNPCKHPSZrmbkz = 15192,

        VUNPCKHPSZrmk = 15193,

        VUNPCKHPSZrmkz = 15194,

        VUNPCKHPSZrr = 15195,

        VUNPCKHPSZrrk = 15196,

        VUNPCKHPSZrrkz = 15197,

        VUNPCKHPSrm = 15198,

        VUNPCKHPSrr = 15199,

        VUNPCKLPDYrm = 15200,

        VUNPCKLPDYrr = 15201,

        VUNPCKLPDZ128rm = 15202,

        VUNPCKLPDZ128rmb = 15203,

        VUNPCKLPDZ128rmbk = 15204,

        VUNPCKLPDZ128rmbkz = 15205,

        VUNPCKLPDZ128rmk = 15206,

        VUNPCKLPDZ128rmkz = 15207,

        VUNPCKLPDZ128rr = 15208,

        VUNPCKLPDZ128rrk = 15209,

        VUNPCKLPDZ128rrkz = 15210,

        VUNPCKLPDZ256rm = 15211,

        VUNPCKLPDZ256rmb = 15212,

        VUNPCKLPDZ256rmbk = 15213,

        VUNPCKLPDZ256rmbkz = 15214,

        VUNPCKLPDZ256rmk = 15215,

        VUNPCKLPDZ256rmkz = 15216,

        VUNPCKLPDZ256rr = 15217,

        VUNPCKLPDZ256rrk = 15218,

        VUNPCKLPDZ256rrkz = 15219,

        VUNPCKLPDZrm = 15220,

        VUNPCKLPDZrmb = 15221,

        VUNPCKLPDZrmbk = 15222,

        VUNPCKLPDZrmbkz = 15223,

        VUNPCKLPDZrmk = 15224,

        VUNPCKLPDZrmkz = 15225,

        VUNPCKLPDZrr = 15226,

        VUNPCKLPDZrrk = 15227,

        VUNPCKLPDZrrkz = 15228,

        VUNPCKLPDrm = 15229,

        VUNPCKLPDrr = 15230,

        VUNPCKLPSYrm = 15231,

        VUNPCKLPSYrr = 15232,

        VUNPCKLPSZ128rm = 15233,

        VUNPCKLPSZ128rmb = 15234,

        VUNPCKLPSZ128rmbk = 15235,

        VUNPCKLPSZ128rmbkz = 15236,

        VUNPCKLPSZ128rmk = 15237,

        VUNPCKLPSZ128rmkz = 15238,

        VUNPCKLPSZ128rr = 15239,

        VUNPCKLPSZ128rrk = 15240,

        VUNPCKLPSZ128rrkz = 15241,

        VUNPCKLPSZ256rm = 15242,

        VUNPCKLPSZ256rmb = 15243,

        VUNPCKLPSZ256rmbk = 15244,

        VUNPCKLPSZ256rmbkz = 15245,

        VUNPCKLPSZ256rmk = 15246,

        VUNPCKLPSZ256rmkz = 15247,

        VUNPCKLPSZ256rr = 15248,

        VUNPCKLPSZ256rrk = 15249,

        VUNPCKLPSZ256rrkz = 15250,

        VUNPCKLPSZrm = 15251,

        VUNPCKLPSZrmb = 15252,

        VUNPCKLPSZrmbk = 15253,

        VUNPCKLPSZrmbkz = 15254,

        VUNPCKLPSZrmk = 15255,

        VUNPCKLPSZrmkz = 15256,

        VUNPCKLPSZrr = 15257,

        VUNPCKLPSZrrk = 15258,

        VUNPCKLPSZrrkz = 15259,

        VUNPCKLPSrm = 15260,

        VUNPCKLPSrr = 15261,

        VXORPDYrm = 15262,

        VXORPDYrr = 15263,

        VXORPDZ128rm = 15264,

        VXORPDZ128rmb = 15265,

        VXORPDZ128rmbk = 15266,

        VXORPDZ128rmbkz = 15267,

        VXORPDZ128rmk = 15268,

        VXORPDZ128rmkz = 15269,

        VXORPDZ128rr = 15270,

        VXORPDZ128rrk = 15271,

        VXORPDZ128rrkz = 15272,

        VXORPDZ256rm = 15273,

        VXORPDZ256rmb = 15274,

        VXORPDZ256rmbk = 15275,

        VXORPDZ256rmbkz = 15276,

        VXORPDZ256rmk = 15277,

        VXORPDZ256rmkz = 15278,

        VXORPDZ256rr = 15279,

        VXORPDZ256rrk = 15280,

        VXORPDZ256rrkz = 15281,

        VXORPDZrm = 15282,

        VXORPDZrmb = 15283,

        VXORPDZrmbk = 15284,

        VXORPDZrmbkz = 15285,

        VXORPDZrmk = 15286,

        VXORPDZrmkz = 15287,

        VXORPDZrr = 15288,

        VXORPDZrrk = 15289,

        VXORPDZrrkz = 15290,

        VXORPDrm = 15291,

        VXORPDrr = 15292,

        VXORPSYrm = 15293,

        VXORPSYrr = 15294,

        VXORPSZ128rm = 15295,

        VXORPSZ128rmb = 15296,

        VXORPSZ128rmbk = 15297,

        VXORPSZ128rmbkz = 15298,

        VXORPSZ128rmk = 15299,

        VXORPSZ128rmkz = 15300,

        VXORPSZ128rr = 15301,

        VXORPSZ128rrk = 15302,

        VXORPSZ128rrkz = 15303,

        VXORPSZ256rm = 15304,

        VXORPSZ256rmb = 15305,

        VXORPSZ256rmbk = 15306,

        VXORPSZ256rmbkz = 15307,

        VXORPSZ256rmk = 15308,

        VXORPSZ256rmkz = 15309,

        VXORPSZ256rr = 15310,

        VXORPSZ256rrk = 15311,

        VXORPSZ256rrkz = 15312,

        VXORPSZrm = 15313,

        VXORPSZrmb = 15314,

        VXORPSZrmbk = 15315,

        VXORPSZrmbkz = 15316,

        VXORPSZrmk = 15317,

        VXORPSZrmkz = 15318,

        VXORPSZrr = 15319,

        VXORPSZrrk = 15320,

        VXORPSZrrkz = 15321,

        VXORPSrm = 15322,

        VXORPSrr = 15323,

        VZEROALL = 15324,

        VZEROUPPER = 15325,

        WAIT = 15326,

        WBINVD = 15327,

        WBNOINVD = 15328,

        WIN_ALLOCA_32 = 15329,

        WIN_ALLOCA_64 = 15330,

        WRFLAGS32 = 15331,

        WRFLAGS64 = 15332,

        WRFSBASE = 15333,

        WRFSBASE64 = 15334,

        WRGSBASE = 15335,

        WRGSBASE64 = 15336,

        WRMSR = 15337,

        WRPKRUr = 15338,

        WRSSD = 15339,

        WRSSQ = 15340,

        WRUSSD = 15341,

        WRUSSQ = 15342,

        XABORT = 15343,

        XACQUIRE_PREFIX = 15344,

        XADD16rm = 15345,

        XADD16rr = 15346,

        XADD32rm = 15347,

        XADD32rr = 15348,

        XADD64rm = 15349,

        XADD64rr = 15350,

        XADD8rm = 15351,

        XADD8rr = 15352,

        XAM_F = 15353,

        XAM_Fp32 = 15354,

        XAM_Fp64 = 15355,

        XAM_Fp80 = 15356,

        XBEGIN = 15357,

        XBEGIN_2 = 15358,

        XBEGIN_4 = 15359,

        XCHG16ar = 15360,

        XCHG16rm = 15361,

        XCHG16rr = 15362,

        XCHG32ar = 15363,

        XCHG32rm = 15364,

        XCHG32rr = 15365,

        XCHG64ar = 15366,

        XCHG64rm = 15367,

        XCHG64rr = 15368,

        XCHG8rm = 15369,

        XCHG8rr = 15370,

        XCH_F = 15371,

        XCRYPTCBC = 15372,

        XCRYPTCFB = 15373,

        XCRYPTCTR = 15374,

        XCRYPTECB = 15375,

        XCRYPTOFB = 15376,

        XEND = 15377,

        XGETBV = 15378,

        XLAT = 15379,

        XOR16i16 = 15380,

        XOR16mi = 15381,

        XOR16mi8 = 15382,

        XOR16mr = 15383,

        XOR16ri = 15384,

        XOR16ri8 = 15385,

        XOR16rm = 15386,

        XOR16rr = 15387,

        XOR16rr_REV = 15388,

        XOR32i32 = 15389,

        XOR32mi = 15390,

        XOR32mi8 = 15391,

        XOR32mr = 15392,

        XOR32ri = 15393,

        XOR32ri8 = 15394,

        XOR32rm = 15395,

        XOR32rr = 15396,

        XOR32rr_REV = 15397,

        XOR64i32 = 15398,

        XOR64mi32 = 15399,

        XOR64mi8 = 15400,

        XOR64mr = 15401,

        XOR64ri32 = 15402,

        XOR64ri8 = 15403,

        XOR64rm = 15404,

        XOR64rr = 15405,

        XOR64rr_REV = 15406,

        XOR8i8 = 15407,

        XOR8mi = 15408,

        XOR8mi8 = 15409,

        XOR8mr = 15410,

        XOR8ri = 15411,

        XOR8ri8 = 15412,

        XOR8rm = 15413,

        XOR8rr = 15414,

        XOR8rr_NOREX = 15415,

        XOR8rr_REV = 15416,

        XORPDrm = 15417,

        XORPDrr = 15418,

        XORPSrm = 15419,

        XORPSrr = 15420,

        XRELEASE_PREFIX = 15421,

        XRESLDTRK = 15422,

        XRSTOR = 15423,

        XRSTOR64 = 15424,

        XRSTORS = 15425,

        XRSTORS64 = 15426,

        XSAVE = 15427,

        XSAVE64 = 15428,

        XSAVEC = 15429,

        XSAVEC64 = 15430,

        XSAVEOPT = 15431,

        XSAVEOPT64 = 15432,

        XSAVES = 15433,

        XSAVES64 = 15434,

        XSETBV = 15435,

        XSHA1 = 15436,

        XSHA256 = 15437,

        XSTORE = 15438,

        XSUSLDTRK = 15439,

        XTEST = 15440,
    }
}
