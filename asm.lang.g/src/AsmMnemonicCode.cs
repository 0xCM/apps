//-----------------------------------------------------------------------------
// Generated   :  2021-06-10.20.36.31.586
// Copyright   :  (c) Chris Moore, 2021
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public enum AsmMnemonicCode : ushort
    {
        [Symbol("none")]
        None = 0,

        [Symbol("aaa")]
        AAA = 1,

        [Symbol("aad")]
        AAD = 2,

        [Symbol("aam")]
        AAM = 3,

        [Symbol("aas")]
        AAS = 4,

        [Symbol("adc")]
        ADC = 5,

        [Symbol("adcx")]
        ADCX = 6,

        [Symbol("adc_lock")]
        ADC_LOCK = 7,

        [Symbol("add")]
        ADD = 8,

        [Symbol("addpd")]
        ADDPD = 9,

        [Symbol("addps")]
        ADDPS = 10,

        [Symbol("addsd")]
        ADDSD = 11,

        [Symbol("addss")]
        ADDSS = 12,

        [Symbol("addsubpd")]
        ADDSUBPD = 13,

        [Symbol("addsubps")]
        ADDSUBPS = 14,

        [Symbol("add_lock")]
        ADD_LOCK = 15,

        [Symbol("adox")]
        ADOX = 16,

        [Symbol("aesdec")]
        AESDEC = 17,

        [Symbol("aesdec128kl")]
        AESDEC128KL = 18,

        [Symbol("aesdec256kl")]
        AESDEC256KL = 19,

        [Symbol("aesdeclast")]
        AESDECLAST = 20,

        [Symbol("aesdecwide128kl")]
        AESDECWIDE128KL = 21,

        [Symbol("aesdecwide256kl")]
        AESDECWIDE256KL = 22,

        [Symbol("aesenc")]
        AESENC = 23,

        [Symbol("aesenc128kl")]
        AESENC128KL = 24,

        [Symbol("aesenc256kl")]
        AESENC256KL = 25,

        [Symbol("aesenclast")]
        AESENCLAST = 26,

        [Symbol("aesencwide128kl")]
        AESENCWIDE128KL = 27,

        [Symbol("aesencwide256kl")]
        AESENCWIDE256KL = 28,

        [Symbol("aesimc")]
        AESIMC = 29,

        [Symbol("aeskeygenassist")]
        AESKEYGENASSIST = 30,

        [Symbol("and")]
        AND = 31,

        [Symbol("andn")]
        ANDN = 32,

        [Symbol("andnpd")]
        ANDNPD = 33,

        [Symbol("andnps")]
        ANDNPS = 34,

        [Symbol("andpd")]
        ANDPD = 35,

        [Symbol("andps")]
        ANDPS = 36,

        [Symbol("and_lock")]
        AND_LOCK = 37,

        [Symbol("arpl")]
        ARPL = 38,

        [Symbol("bextr")]
        BEXTR = 39,

        [Symbol("bextr_xop")]
        BEXTR_XOP = 40,

        [Symbol("blcfill")]
        BLCFILL = 41,

        [Symbol("blci")]
        BLCI = 42,

        [Symbol("blcic")]
        BLCIC = 43,

        [Symbol("blcmsk")]
        BLCMSK = 44,

        [Symbol("blcs")]
        BLCS = 45,

        [Symbol("blendpd")]
        BLENDPD = 46,

        [Symbol("blendps")]
        BLENDPS = 47,

        [Symbol("blendvpd")]
        BLENDVPD = 48,

        [Symbol("blendvps")]
        BLENDVPS = 49,

        [Symbol("blsfill")]
        BLSFILL = 50,

        [Symbol("blsi")]
        BLSI = 51,

        [Symbol("blsic")]
        BLSIC = 52,

        [Symbol("blsmsk")]
        BLSMSK = 53,

        [Symbol("blsr")]
        BLSR = 54,

        [Symbol("bndcl")]
        BNDCL = 55,

        [Symbol("bndcn")]
        BNDCN = 56,

        [Symbol("bndcu")]
        BNDCU = 57,

        [Symbol("bndldx")]
        BNDLDX = 58,

        [Symbol("bndmk")]
        BNDMK = 59,

        [Symbol("bndmov")]
        BNDMOV = 60,

        [Symbol("bndstx")]
        BNDSTX = 61,

        [Symbol("bound")]
        BOUND = 62,

        [Symbol("bsf")]
        BSF = 63,

        [Symbol("bsr")]
        BSR = 64,

        [Symbol("bswap")]
        BSWAP = 65,

        [Symbol("bt")]
        BT = 66,

        [Symbol("btc")]
        BTC = 67,

        [Symbol("btc_lock")]
        BTC_LOCK = 68,

        [Symbol("btr")]
        BTR = 69,

        [Symbol("btr_lock")]
        BTR_LOCK = 70,

        [Symbol("bts")]
        BTS = 71,

        [Symbol("bts_lock")]
        BTS_LOCK = 72,

        [Symbol("bzhi")]
        BZHI = 73,

        [Symbol("call_far")]
        CALL_FAR = 74,

        [Symbol("call_near")]
        CALL_NEAR = 75,

        [Symbol("cbw")]
        CBW = 76,

        [Symbol("cdq")]
        CDQ = 77,

        [Symbol("cdqe")]
        CDQE = 78,

        [Symbol("clac")]
        CLAC = 79,

        [Symbol("clc")]
        CLC = 80,

        [Symbol("cld")]
        CLD = 81,

        [Symbol("cldemote")]
        CLDEMOTE = 82,

        [Symbol("clflush")]
        CLFLUSH = 83,

        [Symbol("clflushopt")]
        CLFLUSHOPT = 84,

        [Symbol("clgi")]
        CLGI = 85,

        [Symbol("cli")]
        CLI = 86,

        [Symbol("clrssbsy")]
        CLRSSBSY = 87,

        [Symbol("clts")]
        CLTS = 88,

        [Symbol("clui")]
        CLUI = 89,

        [Symbol("clwb")]
        CLWB = 90,

        [Symbol("clzero")]
        CLZERO = 91,

        [Symbol("cmc")]
        CMC = 92,

        [Symbol("cmovb")]
        CMOVB = 93,

        [Symbol("cmovbe")]
        CMOVBE = 94,

        [Symbol("cmovl")]
        CMOVL = 95,

        [Symbol("cmovle")]
        CMOVLE = 96,

        [Symbol("cmovnb")]
        CMOVNB = 97,

        [Symbol("cmovnbe")]
        CMOVNBE = 98,

        [Symbol("cmovnl")]
        CMOVNL = 99,

        [Symbol("cmovnle")]
        CMOVNLE = 100,

        [Symbol("cmovno")]
        CMOVNO = 101,

        [Symbol("cmovnp")]
        CMOVNP = 102,

        [Symbol("cmovns")]
        CMOVNS = 103,

        [Symbol("cmovnz")]
        CMOVNZ = 104,

        [Symbol("cmovo")]
        CMOVO = 105,

        [Symbol("cmovp")]
        CMOVP = 106,

        [Symbol("cmovs")]
        CMOVS = 107,

        [Symbol("cmovz")]
        CMOVZ = 108,

        [Symbol("cmp")]
        CMP = 109,

        [Symbol("cmppd")]
        CMPPD = 110,

        [Symbol("cmpps")]
        CMPPS = 111,

        [Symbol("cmpsb")]
        CMPSB = 112,

        [Symbol("cmpsd")]
        CMPSD = 113,

        [Symbol("cmpsd_xmm")]
        CMPSD_XMM = 114,

        [Symbol("cmpsq")]
        CMPSQ = 115,

        [Symbol("cmpss")]
        CMPSS = 116,

        [Symbol("cmpsw")]
        CMPSW = 117,

        [Symbol("cmpxchg")]
        CMPXCHG = 118,

        [Symbol("cmpxchg16b")]
        CMPXCHG16B = 119,

        [Symbol("cmpxchg16b_lock")]
        CMPXCHG16B_LOCK = 120,

        [Symbol("cmpxchg8b")]
        CMPXCHG8B = 121,

        [Symbol("cmpxchg8b_lock")]
        CMPXCHG8B_LOCK = 122,

        [Symbol("cmpxchg_lock")]
        CMPXCHG_LOCK = 123,

        [Symbol("comisd")]
        COMISD = 124,

        [Symbol("comiss")]
        COMISS = 125,

        [Symbol("cpuid")]
        CPUID = 126,

        [Symbol("cqo")]
        CQO = 127,

        [Symbol("crc32")]
        CRC32 = 128,

        [Symbol("cvtdq2pd")]
        CVTDQ2PD = 129,

        [Symbol("cvtdq2ps")]
        CVTDQ2PS = 130,

        [Symbol("cvtpd2dq")]
        CVTPD2DQ = 131,

        [Symbol("cvtpd2pi")]
        CVTPD2PI = 132,

        [Symbol("cvtpd2ps")]
        CVTPD2PS = 133,

        [Symbol("cvtpi2pd")]
        CVTPI2PD = 134,

        [Symbol("cvtpi2ps")]
        CVTPI2PS = 135,

        [Symbol("cvtps2dq")]
        CVTPS2DQ = 136,

        [Symbol("cvtps2pd")]
        CVTPS2PD = 137,

        [Symbol("cvtps2pi")]
        CVTPS2PI = 138,

        [Symbol("cvtsd2si")]
        CVTSD2SI = 139,

        [Symbol("cvtsd2ss")]
        CVTSD2SS = 140,

        [Symbol("cvtsi2sd")]
        CVTSI2SD = 141,

        [Symbol("cvtsi2ss")]
        CVTSI2SS = 142,

        [Symbol("cvtss2sd")]
        CVTSS2SD = 143,

        [Symbol("cvtss2si")]
        CVTSS2SI = 144,

        [Symbol("cvttpd2dq")]
        CVTTPD2DQ = 145,

        [Symbol("cvttpd2pi")]
        CVTTPD2PI = 146,

        [Symbol("cvttps2dq")]
        CVTTPS2DQ = 147,

        [Symbol("cvttps2pi")]
        CVTTPS2PI = 148,

        [Symbol("cvttsd2si")]
        CVTTSD2SI = 149,

        [Symbol("cvttss2si")]
        CVTTSS2SI = 150,

        [Symbol("cwd")]
        CWD = 151,

        [Symbol("cwde")]
        CWDE = 152,

        [Symbol("daa")]
        DAA = 153,

        [Symbol("das")]
        DAS = 154,

        [Symbol("dec")]
        DEC = 155,

        [Symbol("dec_lock")]
        DEC_LOCK = 156,

        [Symbol("div")]
        DIV = 157,

        [Symbol("divpd")]
        DIVPD = 158,

        [Symbol("divps")]
        DIVPS = 159,

        [Symbol("divsd")]
        DIVSD = 160,

        [Symbol("divss")]
        DIVSS = 161,

        [Symbol("dppd")]
        DPPD = 162,

        [Symbol("dpps")]
        DPPS = 163,

        [Symbol("emms")]
        EMMS = 164,

        [Symbol("encls")]
        ENCLS = 165,

        [Symbol("enclu")]
        ENCLU = 166,

        [Symbol("enclv")]
        ENCLV = 167,

        [Symbol("encodekey128")]
        ENCODEKEY128 = 168,

        [Symbol("encodekey256")]
        ENCODEKEY256 = 169,

        [Symbol("endbr32")]
        ENDBR32 = 170,

        [Symbol("endbr64")]
        ENDBR64 = 171,

        [Symbol("enqcmd")]
        ENQCMD = 172,

        [Symbol("enqcmds")]
        ENQCMDS = 173,

        [Symbol("enter")]
        ENTER = 174,

        [Symbol("extractps")]
        EXTRACTPS = 175,

        [Symbol("extrq")]
        EXTRQ = 176,

        [Symbol("f2xm1")]
        F2XM1 = 177,

        [Symbol("fabs")]
        FABS = 178,

        [Symbol("fadd")]
        FADD = 179,

        [Symbol("faddp")]
        FADDP = 180,

        [Symbol("fbld")]
        FBLD = 181,

        [Symbol("fbstp")]
        FBSTP = 182,

        [Symbol("fchs")]
        FCHS = 183,

        [Symbol("fcmovb")]
        FCMOVB = 184,

        [Symbol("fcmovbe")]
        FCMOVBE = 185,

        [Symbol("fcmove")]
        FCMOVE = 186,

        [Symbol("fcmovnb")]
        FCMOVNB = 187,

        [Symbol("fcmovnbe")]
        FCMOVNBE = 188,

        [Symbol("fcmovne")]
        FCMOVNE = 189,

        [Symbol("fcmovnu")]
        FCMOVNU = 190,

        [Symbol("fcmovu")]
        FCMOVU = 191,

        [Symbol("fcom")]
        FCOM = 192,

        [Symbol("fcomi")]
        FCOMI = 193,

        [Symbol("fcomip")]
        FCOMIP = 194,

        [Symbol("fcomp")]
        FCOMP = 195,

        [Symbol("fcompp")]
        FCOMPP = 196,

        [Symbol("fcos")]
        FCOS = 197,

        [Symbol("fdecstp")]
        FDECSTP = 198,

        [Symbol("fdisi8087_nop")]
        FDISI8087_NOP = 199,

        [Symbol("fdiv")]
        FDIV = 200,

        [Symbol("fdivp")]
        FDIVP = 201,

        [Symbol("fdivr")]
        FDIVR = 202,

        [Symbol("fdivrp")]
        FDIVRP = 203,

        [Symbol("femms")]
        FEMMS = 204,

        [Symbol("feni8087_nop")]
        FENI8087_NOP = 205,

        [Symbol("ffree")]
        FFREE = 206,

        [Symbol("ffreep")]
        FFREEP = 207,

        [Symbol("fiadd")]
        FIADD = 208,

        [Symbol("ficom")]
        FICOM = 209,

        [Symbol("ficomp")]
        FICOMP = 210,

        [Symbol("fidiv")]
        FIDIV = 211,

        [Symbol("fidivr")]
        FIDIVR = 212,

        [Symbol("fild")]
        FILD = 213,

        [Symbol("fimul")]
        FIMUL = 214,

        [Symbol("fincstp")]
        FINCSTP = 215,

        [Symbol("fist")]
        FIST = 216,

        [Symbol("fistp")]
        FISTP = 217,

        [Symbol("fisttp")]
        FISTTP = 218,

        [Symbol("fisub")]
        FISUB = 219,

        [Symbol("fisubr")]
        FISUBR = 220,

        [Symbol("fld")]
        FLD = 221,

        [Symbol("fld1")]
        FLD1 = 222,

        [Symbol("fldcw")]
        FLDCW = 223,

        [Symbol("fldenv")]
        FLDENV = 224,

        [Symbol("fldl2e")]
        FLDL2E = 225,

        [Symbol("fldl2t")]
        FLDL2T = 226,

        [Symbol("fldlg2")]
        FLDLG2 = 227,

        [Symbol("fldln2")]
        FLDLN2 = 228,

        [Symbol("fldpi")]
        FLDPI = 229,

        [Symbol("fldz")]
        FLDZ = 230,

        [Symbol("fmul")]
        FMUL = 231,

        [Symbol("fmulp")]
        FMULP = 232,

        [Symbol("fnclex")]
        FNCLEX = 233,

        [Symbol("fninit")]
        FNINIT = 234,

        [Symbol("fnop")]
        FNOP = 235,

        [Symbol("fnsave")]
        FNSAVE = 236,

        [Symbol("fnstcw")]
        FNSTCW = 237,

        [Symbol("fnstenv")]
        FNSTENV = 238,

        [Symbol("fnstsw")]
        FNSTSW = 239,

        [Symbol("fpatan")]
        FPATAN = 240,

        [Symbol("fprem")]
        FPREM = 241,

        [Symbol("fprem1")]
        FPREM1 = 242,

        [Symbol("fptan")]
        FPTAN = 243,

        [Symbol("frndint")]
        FRNDINT = 244,

        [Symbol("frstor")]
        FRSTOR = 245,

        [Symbol("fscale")]
        FSCALE = 246,

        [Symbol("fsetpm287_nop")]
        FSETPM287_NOP = 247,

        [Symbol("fsin")]
        FSIN = 248,

        [Symbol("fsincos")]
        FSINCOS = 249,

        [Symbol("fsqrt")]
        FSQRT = 250,

        [Symbol("fst")]
        FST = 251,

        [Symbol("fstp")]
        FSTP = 252,

        [Symbol("fstpnce")]
        FSTPNCE = 253,

        [Symbol("fsub")]
        FSUB = 254,

        [Symbol("fsubp")]
        FSUBP = 255,

        [Symbol("fsubr")]
        FSUBR = 256,

        [Symbol("fsubrp")]
        FSUBRP = 257,

        [Symbol("ftst")]
        FTST = 258,

        [Symbol("fucom")]
        FUCOM = 259,

        [Symbol("fucomi")]
        FUCOMI = 260,

        [Symbol("fucomip")]
        FUCOMIP = 261,

        [Symbol("fucomp")]
        FUCOMP = 262,

        [Symbol("fucompp")]
        FUCOMPP = 263,

        [Symbol("fwait")]
        FWAIT = 264,

        [Symbol("fxam")]
        FXAM = 265,

        [Symbol("fxch")]
        FXCH = 266,

        [Symbol("fxrstor")]
        FXRSTOR = 267,

        [Symbol("fxrstor64")]
        FXRSTOR64 = 268,

        [Symbol("fxsave")]
        FXSAVE = 269,

        [Symbol("fxsave64")]
        FXSAVE64 = 270,

        [Symbol("fxtract")]
        FXTRACT = 271,

        [Symbol("fyl2x")]
        FYL2X = 272,

        [Symbol("fyl2xp1")]
        FYL2XP1 = 273,

        [Symbol("getsec")]
        GETSEC = 274,

        [Symbol("gf2p8affineinvqb")]
        GF2P8AFFINEINVQB = 275,

        [Symbol("gf2p8affineqb")]
        GF2P8AFFINEQB = 276,

        [Symbol("gf2p8mulb")]
        GF2P8MULB = 277,

        [Symbol("haddpd")]
        HADDPD = 278,

        [Symbol("haddps")]
        HADDPS = 279,

        [Symbol("hlt")]
        HLT = 280,

        [Symbol("hreset")]
        HRESET = 281,

        [Symbol("hsubpd")]
        HSUBPD = 282,

        [Symbol("hsubps")]
        HSUBPS = 283,

        [Symbol("idiv")]
        IDIV = 284,

        [Symbol("imul")]
        IMUL = 285,

        [Symbol("in")]
        IN = 286,

        [Symbol("inc")]
        INC = 287,

        [Symbol("incsspd")]
        INCSSPD = 288,

        [Symbol("incsspq")]
        INCSSPQ = 289,

        [Symbol("inc_lock")]
        INC_LOCK = 290,

        [Symbol("insb")]
        INSB = 291,

        [Symbol("insd")]
        INSD = 292,

        [Symbol("insertps")]
        INSERTPS = 293,

        [Symbol("insertq")]
        INSERTQ = 294,

        [Symbol("insw")]
        INSW = 295,

        [Symbol("int")]
        INT = 296,

        [Symbol("int1")]
        INT1 = 297,

        [Symbol("int3")]
        INT3 = 298,

        [Symbol("into")]
        INTO = 299,

        [Symbol("invd")]
        INVD = 300,

        [Symbol("invept")]
        INVEPT = 301,

        [Symbol("invlpg")]
        INVLPG = 302,

        [Symbol("invlpga")]
        INVLPGA = 303,

        [Symbol("invlpgb")]
        INVLPGB = 304,

        [Symbol("invpcid")]
        INVPCID = 305,

        [Symbol("invvpid")]
        INVVPID = 306,

        [Symbol("iret")]
        IRET = 307,

        [Symbol("iretd")]
        IRETD = 308,

        [Symbol("iretq")]
        IRETQ = 309,

        [Symbol("jb")]
        JB = 310,

        [Symbol("jbe")]
        JBE = 311,

        [Symbol("jcxz")]
        JCXZ = 312,

        [Symbol("jecxz")]
        JECXZ = 313,

        [Symbol("jl")]
        JL = 314,

        [Symbol("jle")]
        JLE = 315,

        [Symbol("jmp")]
        JMP = 316,

        [Symbol("jmp_far")]
        JMP_FAR = 317,

        [Symbol("jnb")]
        JNB = 318,

        [Symbol("jnbe")]
        JNBE = 319,

        [Symbol("jnl")]
        JNL = 320,

        [Symbol("jnle")]
        JNLE = 321,

        [Symbol("jno")]
        JNO = 322,

        [Symbol("jnp")]
        JNP = 323,

        [Symbol("jns")]
        JNS = 324,

        [Symbol("jnz")]
        JNZ = 325,

        [Symbol("jo")]
        JO = 326,

        [Symbol("jp")]
        JP = 327,

        [Symbol("jrcxz")]
        JRCXZ = 328,

        [Symbol("js")]
        JS = 329,

        [Symbol("jz")]
        JZ = 330,

        [Symbol("kaddb")]
        KADDB = 331,

        [Symbol("kaddd")]
        KADDD = 332,

        [Symbol("kaddq")]
        KADDQ = 333,

        [Symbol("kaddw")]
        KADDW = 334,

        [Symbol("kandb")]
        KANDB = 335,

        [Symbol("kandd")]
        KANDD = 336,

        [Symbol("kandnb")]
        KANDNB = 337,

        [Symbol("kandnd")]
        KANDND = 338,

        [Symbol("kandnq")]
        KANDNQ = 339,

        [Symbol("kandnw")]
        KANDNW = 340,

        [Symbol("kandq")]
        KANDQ = 341,

        [Symbol("kandw")]
        KANDW = 342,

        [Symbol("kmovb")]
        KMOVB = 343,

        [Symbol("kmovd")]
        KMOVD = 344,

        [Symbol("kmovq")]
        KMOVQ = 345,

        [Symbol("kmovw")]
        KMOVW = 346,

        [Symbol("knotb")]
        KNOTB = 347,

        [Symbol("knotd")]
        KNOTD = 348,

        [Symbol("knotq")]
        KNOTQ = 349,

        [Symbol("knotw")]
        KNOTW = 350,

        [Symbol("korb")]
        KORB = 351,

        [Symbol("kord")]
        KORD = 352,

        [Symbol("korq")]
        KORQ = 353,

        [Symbol("kortestb")]
        KORTESTB = 354,

        [Symbol("kortestd")]
        KORTESTD = 355,

        [Symbol("kortestq")]
        KORTESTQ = 356,

        [Symbol("kortestw")]
        KORTESTW = 357,

        [Symbol("korw")]
        KORW = 358,

        [Symbol("kshiftlb")]
        KSHIFTLB = 359,

        [Symbol("kshiftld")]
        KSHIFTLD = 360,

        [Symbol("kshiftlq")]
        KSHIFTLQ = 361,

        [Symbol("kshiftlw")]
        KSHIFTLW = 362,

        [Symbol("kshiftrb")]
        KSHIFTRB = 363,

        [Symbol("kshiftrd")]
        KSHIFTRD = 364,

        [Symbol("kshiftrq")]
        KSHIFTRQ = 365,

        [Symbol("kshiftrw")]
        KSHIFTRW = 366,

        [Symbol("ktestb")]
        KTESTB = 367,

        [Symbol("ktestd")]
        KTESTD = 368,

        [Symbol("ktestq")]
        KTESTQ = 369,

        [Symbol("ktestw")]
        KTESTW = 370,

        [Symbol("kunpckbw")]
        KUNPCKBW = 371,

        [Symbol("kunpckdq")]
        KUNPCKDQ = 372,

        [Symbol("kunpckwd")]
        KUNPCKWD = 373,

        [Symbol("kxnorb")]
        KXNORB = 374,

        [Symbol("kxnord")]
        KXNORD = 375,

        [Symbol("kxnorq")]
        KXNORQ = 376,

        [Symbol("kxnorw")]
        KXNORW = 377,

        [Symbol("kxorb")]
        KXORB = 378,

        [Symbol("kxord")]
        KXORD = 379,

        [Symbol("kxorq")]
        KXORQ = 380,

        [Symbol("kxorw")]
        KXORW = 381,

        [Symbol("lahf")]
        LAHF = 382,

        [Symbol("lar")]
        LAR = 383,

        [Symbol("lddqu")]
        LDDQU = 384,

        [Symbol("ldmxcsr")]
        LDMXCSR = 385,

        [Symbol("lds")]
        LDS = 386,

        [Symbol("ldtilecfg")]
        LDTILECFG = 387,

        [Symbol("lea")]
        LEA = 388,

        [Symbol("leave")]
        LEAVE = 389,

        [Symbol("les")]
        LES = 390,

        [Symbol("lfence")]
        LFENCE = 391,

        [Symbol("lfs")]
        LFS = 392,

        [Symbol("lgdt")]
        LGDT = 393,

        [Symbol("lgs")]
        LGS = 394,

        [Symbol("lidt")]
        LIDT = 395,

        [Symbol("lldt")]
        LLDT = 396,

        [Symbol("llwpcb")]
        LLWPCB = 397,

        [Symbol("lmsw")]
        LMSW = 398,

        [Symbol("loadiwkey")]
        LOADIWKEY = 399,

        [Symbol("lodsb")]
        LODSB = 400,

        [Symbol("lodsd")]
        LODSD = 401,

        [Symbol("lodsq")]
        LODSQ = 402,

        [Symbol("lodsw")]
        LODSW = 403,

        [Symbol("loop")]
        LOOP = 404,

        [Symbol("loope")]
        LOOPE = 405,

        [Symbol("loopne")]
        LOOPNE = 406,

        [Symbol("lsl")]
        LSL = 407,

        [Symbol("lss")]
        LSS = 408,

        [Symbol("ltr")]
        LTR = 409,

        [Symbol("lwpins")]
        LWPINS = 410,

        [Symbol("lwpval")]
        LWPVAL = 411,

        [Symbol("lzcnt")]
        LZCNT = 412,

        [Symbol("maskmovdqu")]
        MASKMOVDQU = 413,

        [Symbol("maskmovq")]
        MASKMOVQ = 414,

        [Symbol("maxpd")]
        MAXPD = 415,

        [Symbol("maxps")]
        MAXPS = 416,

        [Symbol("maxsd")]
        MAXSD = 417,

        [Symbol("maxss")]
        MAXSS = 418,

        [Symbol("mcommit")]
        MCOMMIT = 419,

        [Symbol("mfence")]
        MFENCE = 420,

        [Symbol("minpd")]
        MINPD = 421,

        [Symbol("minps")]
        MINPS = 422,

        [Symbol("minsd")]
        MINSD = 423,

        [Symbol("minss")]
        MINSS = 424,

        [Symbol("monitor")]
        MONITOR = 425,

        [Symbol("monitorx")]
        MONITORX = 426,

        [Symbol("mov")]
        MOV = 427,

        [Symbol("movapd")]
        MOVAPD = 428,

        [Symbol("movaps")]
        MOVAPS = 429,

        [Symbol("movbe")]
        MOVBE = 430,

        [Symbol("movd")]
        MOVD = 431,

        [Symbol("movddup")]
        MOVDDUP = 432,

        [Symbol("movdir64b")]
        MOVDIR64B = 433,

        [Symbol("movdiri")]
        MOVDIRI = 434,

        [Symbol("movdq2q")]
        MOVDQ2Q = 435,

        [Symbol("movdqa")]
        MOVDQA = 436,

        [Symbol("movdqu")]
        MOVDQU = 437,

        [Symbol("movhlps")]
        MOVHLPS = 438,

        [Symbol("movhpd")]
        MOVHPD = 439,

        [Symbol("movhps")]
        MOVHPS = 440,

        [Symbol("movlhps")]
        MOVLHPS = 441,

        [Symbol("movlpd")]
        MOVLPD = 442,

        [Symbol("movlps")]
        MOVLPS = 443,

        [Symbol("movmskpd")]
        MOVMSKPD = 444,

        [Symbol("movmskps")]
        MOVMSKPS = 445,

        [Symbol("movntdq")]
        MOVNTDQ = 446,

        [Symbol("movntdqa")]
        MOVNTDQA = 447,

        [Symbol("movnti")]
        MOVNTI = 448,

        [Symbol("movntpd")]
        MOVNTPD = 449,

        [Symbol("movntps")]
        MOVNTPS = 450,

        [Symbol("movntq")]
        MOVNTQ = 451,

        [Symbol("movntsd")]
        MOVNTSD = 452,

        [Symbol("movntss")]
        MOVNTSS = 453,

        [Symbol("movq")]
        MOVQ = 454,

        [Symbol("movq2dq")]
        MOVQ2DQ = 455,

        [Symbol("movsb")]
        MOVSB = 456,

        [Symbol("movsd")]
        MOVSD = 457,

        [Symbol("movsd_xmm")]
        MOVSD_XMM = 458,

        [Symbol("movshdup")]
        MOVSHDUP = 459,

        [Symbol("movsldup")]
        MOVSLDUP = 460,

        [Symbol("movsq")]
        MOVSQ = 461,

        [Symbol("movss")]
        MOVSS = 462,

        [Symbol("movsw")]
        MOVSW = 463,

        [Symbol("movsx")]
        MOVSX = 464,

        [Symbol("movsxd")]
        MOVSXD = 465,

        [Symbol("movupd")]
        MOVUPD = 466,

        [Symbol("movups")]
        MOVUPS = 467,

        [Symbol("movzx")]
        MOVZX = 468,

        [Symbol("mov_cr")]
        MOV_CR = 469,

        [Symbol("mov_dr")]
        MOV_DR = 470,

        [Symbol("mpsadbw")]
        MPSADBW = 471,

        [Symbol("mul")]
        MUL = 472,

        [Symbol("mulpd")]
        MULPD = 473,

        [Symbol("mulps")]
        MULPS = 474,

        [Symbol("mulsd")]
        MULSD = 475,

        [Symbol("mulss")]
        MULSS = 476,

        [Symbol("mulx")]
        MULX = 477,

        [Symbol("mwait")]
        MWAIT = 478,

        [Symbol("mwaitx")]
        MWAITX = 479,

        [Symbol("neg")]
        NEG = 480,

        [Symbol("neg_lock")]
        NEG_LOCK = 481,

        [Symbol("nop")]
        NOP = 482,

        [Symbol("nop2")]
        NOP2 = 483,

        [Symbol("nop3")]
        NOP3 = 484,

        [Symbol("nop4")]
        NOP4 = 485,

        [Symbol("nop5")]
        NOP5 = 486,

        [Symbol("nop6")]
        NOP6 = 487,

        [Symbol("nop7")]
        NOP7 = 488,

        [Symbol("nop8")]
        NOP8 = 489,

        [Symbol("nop9")]
        NOP9 = 490,

        [Symbol("not")]
        NOT = 491,

        [Symbol("not_lock")]
        NOT_LOCK = 492,

        [Symbol("or")]
        OR = 493,

        [Symbol("orpd")]
        ORPD = 494,

        [Symbol("orps")]
        ORPS = 495,

        [Symbol("or_lock")]
        OR_LOCK = 496,

        [Symbol("out")]
        OUT = 497,

        [Symbol("outsb")]
        OUTSB = 498,

        [Symbol("outsd")]
        OUTSD = 499,

        [Symbol("outsw")]
        OUTSW = 500,

        [Symbol("pabsb")]
        PABSB = 501,

        [Symbol("pabsd")]
        PABSD = 502,

        [Symbol("pabsw")]
        PABSW = 503,

        [Symbol("packssdw")]
        PACKSSDW = 504,

        [Symbol("packsswb")]
        PACKSSWB = 505,

        [Symbol("packusdw")]
        PACKUSDW = 506,

        [Symbol("packuswb")]
        PACKUSWB = 507,

        [Symbol("paddb")]
        PADDB = 508,

        [Symbol("paddd")]
        PADDD = 509,

        [Symbol("paddq")]
        PADDQ = 510,

        [Symbol("paddsb")]
        PADDSB = 511,

        [Symbol("paddsw")]
        PADDSW = 512,

        [Symbol("paddusb")]
        PADDUSB = 513,

        [Symbol("paddusw")]
        PADDUSW = 514,

        [Symbol("paddw")]
        PADDW = 515,

        [Symbol("palignr")]
        PALIGNR = 516,

        [Symbol("pand")]
        PAND = 517,

        [Symbol("pandn")]
        PANDN = 518,

        [Symbol("pause")]
        PAUSE = 519,

        [Symbol("pavgb")]
        PAVGB = 520,

        [Symbol("pavgusb")]
        PAVGUSB = 521,

        [Symbol("pavgw")]
        PAVGW = 522,

        [Symbol("pblendvb")]
        PBLENDVB = 523,

        [Symbol("pblendw")]
        PBLENDW = 524,

        [Symbol("pclmulqdq")]
        PCLMULQDQ = 525,

        [Symbol("pcmpeqb")]
        PCMPEQB = 526,

        [Symbol("pcmpeqd")]
        PCMPEQD = 527,

        [Symbol("pcmpeqq")]
        PCMPEQQ = 528,

        [Symbol("pcmpeqw")]
        PCMPEQW = 529,

        [Symbol("pcmpestri")]
        PCMPESTRI = 530,

        [Symbol("pcmpestri64")]
        PCMPESTRI64 = 531,

        [Symbol("pcmpestrm")]
        PCMPESTRM = 532,

        [Symbol("pcmpestrm64")]
        PCMPESTRM64 = 533,

        [Symbol("pcmpgtb")]
        PCMPGTB = 534,

        [Symbol("pcmpgtd")]
        PCMPGTD = 535,

        [Symbol("pcmpgtq")]
        PCMPGTQ = 536,

        [Symbol("pcmpgtw")]
        PCMPGTW = 537,

        [Symbol("pcmpistri")]
        PCMPISTRI = 538,

        [Symbol("pcmpistri64")]
        PCMPISTRI64 = 539,

        [Symbol("pcmpistrm")]
        PCMPISTRM = 540,

        [Symbol("pconfig")]
        PCONFIG = 541,

        [Symbol("pdep")]
        PDEP = 542,

        [Symbol("pext")]
        PEXT = 543,

        [Symbol("pextrb")]
        PEXTRB = 544,

        [Symbol("pextrd")]
        PEXTRD = 545,

        [Symbol("pextrq")]
        PEXTRQ = 546,

        [Symbol("pextrw")]
        PEXTRW = 547,

        [Symbol("pextrw_sse4")]
        PEXTRW_SSE4 = 548,

        [Symbol("pf2id")]
        PF2ID = 549,

        [Symbol("pf2iw")]
        PF2IW = 550,

        [Symbol("pfacc")]
        PFACC = 551,

        [Symbol("pfadd")]
        PFADD = 552,

        [Symbol("pfcmpeq")]
        PFCMPEQ = 553,

        [Symbol("pfcmpge")]
        PFCMPGE = 554,

        [Symbol("pfcmpgt")]
        PFCMPGT = 555,

        [Symbol("pfmax")]
        PFMAX = 556,

        [Symbol("pfmin")]
        PFMIN = 557,

        [Symbol("pfmul")]
        PFMUL = 558,

        [Symbol("pfnacc")]
        PFNACC = 559,

        [Symbol("pfpnacc")]
        PFPNACC = 560,

        [Symbol("pfrcp")]
        PFRCP = 561,

        [Symbol("pfrcpit1")]
        PFRCPIT1 = 562,

        [Symbol("pfrcpit2")]
        PFRCPIT2 = 563,

        [Symbol("pfrsqit1")]
        PFRSQIT1 = 564,

        [Symbol("pfrsqrt")]
        PFRSQRT = 565,

        [Symbol("pfsub")]
        PFSUB = 566,

        [Symbol("pfsubr")]
        PFSUBR = 567,

        [Symbol("phaddd")]
        PHADDD = 568,

        [Symbol("phaddsw")]
        PHADDSW = 569,

        [Symbol("phaddw")]
        PHADDW = 570,

        [Symbol("phminposuw")]
        PHMINPOSUW = 571,

        [Symbol("phsubd")]
        PHSUBD = 572,

        [Symbol("phsubsw")]
        PHSUBSW = 573,

        [Symbol("phsubw")]
        PHSUBW = 574,

        [Symbol("pi2fd")]
        PI2FD = 575,

        [Symbol("pi2fw")]
        PI2FW = 576,

        [Symbol("pinsrb")]
        PINSRB = 577,

        [Symbol("pinsrd")]
        PINSRD = 578,

        [Symbol("pinsrq")]
        PINSRQ = 579,

        [Symbol("pinsrw")]
        PINSRW = 580,

        [Symbol("pmaddubsw")]
        PMADDUBSW = 581,

        [Symbol("pmaddwd")]
        PMADDWD = 582,

        [Symbol("pmaxsb")]
        PMAXSB = 583,

        [Symbol("pmaxsd")]
        PMAXSD = 584,

        [Symbol("pmaxsw")]
        PMAXSW = 585,

        [Symbol("pmaxub")]
        PMAXUB = 586,

        [Symbol("pmaxud")]
        PMAXUD = 587,

        [Symbol("pmaxuw")]
        PMAXUW = 588,

        [Symbol("pminsb")]
        PMINSB = 589,

        [Symbol("pminsd")]
        PMINSD = 590,

        [Symbol("pminsw")]
        PMINSW = 591,

        [Symbol("pminub")]
        PMINUB = 592,

        [Symbol("pminud")]
        PMINUD = 593,

        [Symbol("pminuw")]
        PMINUW = 594,

        [Symbol("pmovmskb")]
        PMOVMSKB = 595,

        [Symbol("pmovsxbd")]
        PMOVSXBD = 596,

        [Symbol("pmovsxbq")]
        PMOVSXBQ = 597,

        [Symbol("pmovsxbw")]
        PMOVSXBW = 598,

        [Symbol("pmovsxdq")]
        PMOVSXDQ = 599,

        [Symbol("pmovsxwd")]
        PMOVSXWD = 600,

        [Symbol("pmovsxwq")]
        PMOVSXWQ = 601,

        [Symbol("pmovzxbd")]
        PMOVZXBD = 602,

        [Symbol("pmovzxbq")]
        PMOVZXBQ = 603,

        [Symbol("pmovzxbw")]
        PMOVZXBW = 604,

        [Symbol("pmovzxdq")]
        PMOVZXDQ = 605,

        [Symbol("pmovzxwd")]
        PMOVZXWD = 606,

        [Symbol("pmovzxwq")]
        PMOVZXWQ = 607,

        [Symbol("pmuldq")]
        PMULDQ = 608,

        [Symbol("pmulhrsw")]
        PMULHRSW = 609,

        [Symbol("pmulhrw")]
        PMULHRW = 610,

        [Symbol("pmulhuw")]
        PMULHUW = 611,

        [Symbol("pmulhw")]
        PMULHW = 612,

        [Symbol("pmulld")]
        PMULLD = 613,

        [Symbol("pmullw")]
        PMULLW = 614,

        [Symbol("pmuludq")]
        PMULUDQ = 615,

        [Symbol("pop")]
        POP = 616,

        [Symbol("popa")]
        POPA = 617,

        [Symbol("popad")]
        POPAD = 618,

        [Symbol("popcnt")]
        POPCNT = 619,

        [Symbol("popf")]
        POPF = 620,

        [Symbol("popfd")]
        POPFD = 621,

        [Symbol("popfq")]
        POPFQ = 622,

        [Symbol("por")]
        POR = 623,

        [Symbol("prefetchnta")]
        PREFETCHNTA = 624,

        [Symbol("prefetcht0")]
        PREFETCHT0 = 625,

        [Symbol("prefetcht1")]
        PREFETCHT1 = 626,

        [Symbol("prefetcht2")]
        PREFETCHT2 = 627,

        [Symbol("prefetchw")]
        PREFETCHW = 628,

        [Symbol("prefetchwt1")]
        PREFETCHWT1 = 629,

        [Symbol("prefetch_exclusive")]
        PREFETCH_EXCLUSIVE = 630,

        [Symbol("prefetch_reserved")]
        PREFETCH_RESERVED = 631,

        [Symbol("psadbw")]
        PSADBW = 632,

        [Symbol("pshufb")]
        PSHUFB = 633,

        [Symbol("pshufd")]
        PSHUFD = 634,

        [Symbol("pshufhw")]
        PSHUFHW = 635,

        [Symbol("pshuflw")]
        PSHUFLW = 636,

        [Symbol("pshufw")]
        PSHUFW = 637,

        [Symbol("psignb")]
        PSIGNB = 638,

        [Symbol("psignd")]
        PSIGND = 639,

        [Symbol("psignw")]
        PSIGNW = 640,

        [Symbol("pslld")]
        PSLLD = 641,

        [Symbol("pslldq")]
        PSLLDQ = 642,

        [Symbol("psllq")]
        PSLLQ = 643,

        [Symbol("psllw")]
        PSLLW = 644,

        [Symbol("psmash")]
        PSMASH = 645,

        [Symbol("psrad")]
        PSRAD = 646,

        [Symbol("psraw")]
        PSRAW = 647,

        [Symbol("psrld")]
        PSRLD = 648,

        [Symbol("psrldq")]
        PSRLDQ = 649,

        [Symbol("psrlq")]
        PSRLQ = 650,

        [Symbol("psrlw")]
        PSRLW = 651,

        [Symbol("psubb")]
        PSUBB = 652,

        [Symbol("psubd")]
        PSUBD = 653,

        [Symbol("psubq")]
        PSUBQ = 654,

        [Symbol("psubsb")]
        PSUBSB = 655,

        [Symbol("psubsw")]
        PSUBSW = 656,

        [Symbol("psubusb")]
        PSUBUSB = 657,

        [Symbol("psubusw")]
        PSUBUSW = 658,

        [Symbol("psubw")]
        PSUBW = 659,

        [Symbol("pswapd")]
        PSWAPD = 660,

        [Symbol("ptest")]
        PTEST = 661,

        [Symbol("ptwrite")]
        PTWRITE = 662,

        [Symbol("punpckhbw")]
        PUNPCKHBW = 663,

        [Symbol("punpckhdq")]
        PUNPCKHDQ = 664,

        [Symbol("punpckhqdq")]
        PUNPCKHQDQ = 665,

        [Symbol("punpckhwd")]
        PUNPCKHWD = 666,

        [Symbol("punpcklbw")]
        PUNPCKLBW = 667,

        [Symbol("punpckldq")]
        PUNPCKLDQ = 668,

        [Symbol("punpcklqdq")]
        PUNPCKLQDQ = 669,

        [Symbol("punpcklwd")]
        PUNPCKLWD = 670,

        [Symbol("push")]
        PUSH = 671,

        [Symbol("pusha")]
        PUSHA = 672,

        [Symbol("pushad")]
        PUSHAD = 673,

        [Symbol("pushf")]
        PUSHF = 674,

        [Symbol("pushfd")]
        PUSHFD = 675,

        [Symbol("pushfq")]
        PUSHFQ = 676,

        [Symbol("pvalidate")]
        PVALIDATE = 677,

        [Symbol("pxor")]
        PXOR = 678,

        [Symbol("rcl")]
        RCL = 679,

        [Symbol("rcpps")]
        RCPPS = 680,

        [Symbol("rcpss")]
        RCPSS = 681,

        [Symbol("rcr")]
        RCR = 682,

        [Symbol("rdfsbase")]
        RDFSBASE = 683,

        [Symbol("rdgsbase")]
        RDGSBASE = 684,

        [Symbol("rdmsr")]
        RDMSR = 685,

        [Symbol("rdpid")]
        RDPID = 686,

        [Symbol("rdpkru")]
        RDPKRU = 687,

        [Symbol("rdpmc")]
        RDPMC = 688,

        [Symbol("rdpru")]
        RDPRU = 689,

        [Symbol("rdrand")]
        RDRAND = 690,

        [Symbol("rdseed")]
        RDSEED = 691,

        [Symbol("rdsspd")]
        RDSSPD = 692,

        [Symbol("rdsspq")]
        RDSSPQ = 693,

        [Symbol("rdtsc")]
        RDTSC = 694,

        [Symbol("rdtscp")]
        RDTSCP = 695,

        [Symbol("repe_cmpsb")]
        REPE_CMPSB = 696,

        [Symbol("repe_cmpsd")]
        REPE_CMPSD = 697,

        [Symbol("repe_cmpsq")]
        REPE_CMPSQ = 698,

        [Symbol("repe_cmpsw")]
        REPE_CMPSW = 699,

        [Symbol("repe_scasb")]
        REPE_SCASB = 700,

        [Symbol("repe_scasd")]
        REPE_SCASD = 701,

        [Symbol("repe_scasq")]
        REPE_SCASQ = 702,

        [Symbol("repe_scasw")]
        REPE_SCASW = 703,

        [Symbol("repne_cmpsb")]
        REPNE_CMPSB = 704,

        [Symbol("repne_cmpsd")]
        REPNE_CMPSD = 705,

        [Symbol("repne_cmpsq")]
        REPNE_CMPSQ = 706,

        [Symbol("repne_cmpsw")]
        REPNE_CMPSW = 707,

        [Symbol("repne_scasb")]
        REPNE_SCASB = 708,

        [Symbol("repne_scasd")]
        REPNE_SCASD = 709,

        [Symbol("repne_scasq")]
        REPNE_SCASQ = 710,

        [Symbol("repne_scasw")]
        REPNE_SCASW = 711,

        [Symbol("rep_insb")]
        REP_INSB = 712,

        [Symbol("rep_insd")]
        REP_INSD = 713,

        [Symbol("rep_insw")]
        REP_INSW = 714,

        [Symbol("rep_lodsb")]
        REP_LODSB = 715,

        [Symbol("rep_lodsd")]
        REP_LODSD = 716,

        [Symbol("rep_lodsq")]
        REP_LODSQ = 717,

        [Symbol("rep_lodsw")]
        REP_LODSW = 718,

        [Symbol("rep_montmul")]
        REP_MONTMUL = 719,

        [Symbol("rep_movsb")]
        REP_MOVSB = 720,

        [Symbol("rep_movsd")]
        REP_MOVSD = 721,

        [Symbol("rep_movsq")]
        REP_MOVSQ = 722,

        [Symbol("rep_movsw")]
        REP_MOVSW = 723,

        [Symbol("rep_outsb")]
        REP_OUTSB = 724,

        [Symbol("rep_outsd")]
        REP_OUTSD = 725,

        [Symbol("rep_outsw")]
        REP_OUTSW = 726,

        [Symbol("rep_stosb")]
        REP_STOSB = 727,

        [Symbol("rep_stosd")]
        REP_STOSD = 728,

        [Symbol("rep_stosq")]
        REP_STOSQ = 729,

        [Symbol("rep_stosw")]
        REP_STOSW = 730,

        [Symbol("rep_xcryptcbc")]
        REP_XCRYPTCBC = 731,

        [Symbol("rep_xcryptcfb")]
        REP_XCRYPTCFB = 732,

        [Symbol("rep_xcryptctr")]
        REP_XCRYPTCTR = 733,

        [Symbol("rep_xcryptecb")]
        REP_XCRYPTECB = 734,

        [Symbol("rep_xcryptofb")]
        REP_XCRYPTOFB = 735,

        [Symbol("rep_xsha1")]
        REP_XSHA1 = 736,

        [Symbol("rep_xsha256")]
        REP_XSHA256 = 737,

        [Symbol("rep_xstore")]
        REP_XSTORE = 738,

        [Symbol("ret_far")]
        RET_FAR = 739,

        [Symbol("ret_near")]
        RET_NEAR = 740,

        [Symbol("rmpadjust")]
        RMPADJUST = 741,

        [Symbol("rmpupdate")]
        RMPUPDATE = 742,

        [Symbol("rol")]
        ROL = 743,

        [Symbol("ror")]
        ROR = 744,

        [Symbol("rorx")]
        RORX = 745,

        [Symbol("roundpd")]
        ROUNDPD = 746,

        [Symbol("roundps")]
        ROUNDPS = 747,

        [Symbol("roundsd")]
        ROUNDSD = 748,

        [Symbol("roundss")]
        ROUNDSS = 749,

        [Symbol("rsm")]
        RSM = 750,

        [Symbol("rsqrtps")]
        RSQRTPS = 751,

        [Symbol("rsqrtss")]
        RSQRTSS = 752,

        [Symbol("rstorssp")]
        RSTORSSP = 753,

        [Symbol("sahf")]
        SAHF = 754,

        [Symbol("salc")]
        SALC = 755,

        [Symbol("sar")]
        SAR = 756,

        [Symbol("sarx")]
        SARX = 757,

        [Symbol("saveprevssp")]
        SAVEPREVSSP = 758,

        [Symbol("sbb")]
        SBB = 759,

        [Symbol("sbb_lock")]
        SBB_LOCK = 760,

        [Symbol("scasb")]
        SCASB = 761,

        [Symbol("scasd")]
        SCASD = 762,

        [Symbol("scasq")]
        SCASQ = 763,

        [Symbol("scasw")]
        SCASW = 764,

        [Symbol("seamcall")]
        SEAMCALL = 765,

        [Symbol("seamops")]
        SEAMOPS = 766,

        [Symbol("seamret")]
        SEAMRET = 767,

        [Symbol("senduipi")]
        SENDUIPI = 768,

        [Symbol("serialize")]
        SERIALIZE = 769,

        [Symbol("setb")]
        SETB = 770,

        [Symbol("setbe")]
        SETBE = 771,

        [Symbol("setl")]
        SETL = 772,

        [Symbol("setle")]
        SETLE = 773,

        [Symbol("setnb")]
        SETNB = 774,

        [Symbol("setnbe")]
        SETNBE = 775,

        [Symbol("setnl")]
        SETNL = 776,

        [Symbol("setnle")]
        SETNLE = 777,

        [Symbol("setno")]
        SETNO = 778,

        [Symbol("setnp")]
        SETNP = 779,

        [Symbol("setns")]
        SETNS = 780,

        [Symbol("setnz")]
        SETNZ = 781,

        [Symbol("seto")]
        SETO = 782,

        [Symbol("setp")]
        SETP = 783,

        [Symbol("sets")]
        SETS = 784,

        [Symbol("setssbsy")]
        SETSSBSY = 785,

        [Symbol("setz")]
        SETZ = 786,

        [Symbol("sfence")]
        SFENCE = 787,

        [Symbol("sgdt")]
        SGDT = 788,

        [Symbol("sha1msg1")]
        SHA1MSG1 = 789,

        [Symbol("sha1msg2")]
        SHA1MSG2 = 790,

        [Symbol("sha1nexte")]
        SHA1NEXTE = 791,

        [Symbol("sha1rnds4")]
        SHA1RNDS4 = 792,

        [Symbol("sha256msg1")]
        SHA256MSG1 = 793,

        [Symbol("sha256msg2")]
        SHA256MSG2 = 794,

        [Symbol("sha256rnds2")]
        SHA256RNDS2 = 795,

        [Symbol("shl")]
        SHL = 796,

        [Symbol("shld")]
        SHLD = 797,

        [Symbol("shlx")]
        SHLX = 798,

        [Symbol("shr")]
        SHR = 799,

        [Symbol("shrd")]
        SHRD = 800,

        [Symbol("shrx")]
        SHRX = 801,

        [Symbol("shufpd")]
        SHUFPD = 802,

        [Symbol("shufps")]
        SHUFPS = 803,

        [Symbol("sidt")]
        SIDT = 804,

        [Symbol("skinit")]
        SKINIT = 805,

        [Symbol("sldt")]
        SLDT = 806,

        [Symbol("slwpcb")]
        SLWPCB = 807,

        [Symbol("smsw")]
        SMSW = 808,

        [Symbol("sqrtpd")]
        SQRTPD = 809,

        [Symbol("sqrtps")]
        SQRTPS = 810,

        [Symbol("sqrtsd")]
        SQRTSD = 811,

        [Symbol("sqrtss")]
        SQRTSS = 812,

        [Symbol("stac")]
        STAC = 813,

        [Symbol("stc")]
        STC = 814,

        [Symbol("std")]
        STD = 815,

        [Symbol("stgi")]
        STGI = 816,

        [Symbol("sti")]
        STI = 817,

        [Symbol("stmxcsr")]
        STMXCSR = 818,

        [Symbol("stosb")]
        STOSB = 819,

        [Symbol("stosd")]
        STOSD = 820,

        [Symbol("stosq")]
        STOSQ = 821,

        [Symbol("stosw")]
        STOSW = 822,

        [Symbol("str")]
        STR = 823,

        [Symbol("sttilecfg")]
        STTILECFG = 824,

        [Symbol("stui")]
        STUI = 825,

        [Symbol("sub")]
        SUB = 826,

        [Symbol("subpd")]
        SUBPD = 827,

        [Symbol("subps")]
        SUBPS = 828,

        [Symbol("subsd")]
        SUBSD = 829,

        [Symbol("subss")]
        SUBSS = 830,

        [Symbol("sub_lock")]
        SUB_LOCK = 831,

        [Symbol("swapgs")]
        SWAPGS = 832,

        [Symbol("syscall")]
        SYSCALL = 833,

        [Symbol("syscall_amd")]
        SYSCALL_AMD = 834,

        [Symbol("sysenter")]
        SYSENTER = 835,

        [Symbol("sysexit")]
        SYSEXIT = 836,

        [Symbol("sysret")]
        SYSRET = 837,

        [Symbol("sysret64")]
        SYSRET64 = 838,

        [Symbol("sysret_amd")]
        SYSRET_AMD = 839,

        [Symbol("t1mskc")]
        T1MSKC = 840,

        [Symbol("tdcall")]
        TDCALL = 841,

        [Symbol("tdpbf16ps")]
        TDPBF16PS = 842,

        [Symbol("tdpbssd")]
        TDPBSSD = 843,

        [Symbol("tdpbsud")]
        TDPBSUD = 844,

        [Symbol("tdpbusd")]
        TDPBUSD = 845,

        [Symbol("tdpbuud")]
        TDPBUUD = 846,

        [Symbol("test")]
        TEST = 847,

        [Symbol("testui")]
        TESTUI = 848,

        [Symbol("tileloadd")]
        TILELOADD = 849,

        [Symbol("tileloaddt1")]
        TILELOADDT1 = 850,

        [Symbol("tilerelease")]
        TILERELEASE = 851,

        [Symbol("tilestored")]
        TILESTORED = 852,

        [Symbol("tilezero")]
        TILEZERO = 853,

        [Symbol("tlbsync")]
        TLBSYNC = 854,

        [Symbol("tpause")]
        TPAUSE = 855,

        [Symbol("tzcnt")]
        TZCNT = 856,

        [Symbol("tzmsk")]
        TZMSK = 857,

        [Symbol("ucomisd")]
        UCOMISD = 858,

        [Symbol("ucomiss")]
        UCOMISS = 859,

        [Symbol("ud0")]
        UD0 = 860,

        [Symbol("ud1")]
        UD1 = 861,

        [Symbol("ud2")]
        UD2 = 862,

        [Symbol("uiret")]
        UIRET = 863,

        [Symbol("umonitor")]
        UMONITOR = 864,

        [Symbol("umwait")]
        UMWAIT = 865,

        [Symbol("unpckhpd")]
        UNPCKHPD = 866,

        [Symbol("unpckhps")]
        UNPCKHPS = 867,

        [Symbol("unpcklpd")]
        UNPCKLPD = 868,

        [Symbol("unpcklps")]
        UNPCKLPS = 869,

        [Symbol("v4fmaddps")]
        V4FMADDPS = 870,

        [Symbol("v4fmaddss")]
        V4FMADDSS = 871,

        [Symbol("v4fnmaddps")]
        V4FNMADDPS = 872,

        [Symbol("v4fnmaddss")]
        V4FNMADDSS = 873,

        [Symbol("vaddpd")]
        VADDPD = 874,

        [Symbol("vaddps")]
        VADDPS = 875,

        [Symbol("vaddsd")]
        VADDSD = 876,

        [Symbol("vaddss")]
        VADDSS = 877,

        [Symbol("vaddsubpd")]
        VADDSUBPD = 878,

        [Symbol("vaddsubps")]
        VADDSUBPS = 879,

        [Symbol("vaesdec")]
        VAESDEC = 880,

        [Symbol("vaesdeclast")]
        VAESDECLAST = 881,

        [Symbol("vaesenc")]
        VAESENC = 882,

        [Symbol("vaesenclast")]
        VAESENCLAST = 883,

        [Symbol("vaesimc")]
        VAESIMC = 884,

        [Symbol("vaeskeygenassist")]
        VAESKEYGENASSIST = 885,

        [Symbol("valignd")]
        VALIGND = 886,

        [Symbol("valignq")]
        VALIGNQ = 887,

        [Symbol("vandnpd")]
        VANDNPD = 888,

        [Symbol("vandnps")]
        VANDNPS = 889,

        [Symbol("vandpd")]
        VANDPD = 890,

        [Symbol("vandps")]
        VANDPS = 891,

        [Symbol("vblendmpd")]
        VBLENDMPD = 892,

        [Symbol("vblendmps")]
        VBLENDMPS = 893,

        [Symbol("vblendpd")]
        VBLENDPD = 894,

        [Symbol("vblendps")]
        VBLENDPS = 895,

        [Symbol("vblendvpd")]
        VBLENDVPD = 896,

        [Symbol("vblendvps")]
        VBLENDVPS = 897,

        [Symbol("vbroadcastf128")]
        VBROADCASTF128 = 898,

        [Symbol("vbroadcastf32x2")]
        VBROADCASTF32X2 = 899,

        [Symbol("vbroadcastf32x4")]
        VBROADCASTF32X4 = 900,

        [Symbol("vbroadcastf32x8")]
        VBROADCASTF32X8 = 901,

        [Symbol("vbroadcastf64x2")]
        VBROADCASTF64X2 = 902,

        [Symbol("vbroadcastf64x4")]
        VBROADCASTF64X4 = 903,

        [Symbol("vbroadcasti128")]
        VBROADCASTI128 = 904,

        [Symbol("vbroadcasti32x2")]
        VBROADCASTI32X2 = 905,

        [Symbol("vbroadcasti32x4")]
        VBROADCASTI32X4 = 906,

        [Symbol("vbroadcasti32x8")]
        VBROADCASTI32X8 = 907,

        [Symbol("vbroadcasti64x2")]
        VBROADCASTI64X2 = 908,

        [Symbol("vbroadcasti64x4")]
        VBROADCASTI64X4 = 909,

        [Symbol("vbroadcastsd")]
        VBROADCASTSD = 910,

        [Symbol("vbroadcastss")]
        VBROADCASTSS = 911,

        [Symbol("vcmppd")]
        VCMPPD = 912,

        [Symbol("vcmpps")]
        VCMPPS = 913,

        [Symbol("vcmpsd")]
        VCMPSD = 914,

        [Symbol("vcmpss")]
        VCMPSS = 915,

        [Symbol("vcomisd")]
        VCOMISD = 916,

        [Symbol("vcomiss")]
        VCOMISS = 917,

        [Symbol("vcompresspd")]
        VCOMPRESSPD = 918,

        [Symbol("vcompressps")]
        VCOMPRESSPS = 919,

        [Symbol("vcvtdq2pd")]
        VCVTDQ2PD = 920,

        [Symbol("vcvtdq2ps")]
        VCVTDQ2PS = 921,

        [Symbol("vcvtne2ps2bf16")]
        VCVTNE2PS2BF16 = 922,

        [Symbol("vcvtneps2bf16")]
        VCVTNEPS2BF16 = 923,

        [Symbol("vcvtpd2dq")]
        VCVTPD2DQ = 924,

        [Symbol("vcvtpd2ps")]
        VCVTPD2PS = 925,

        [Symbol("vcvtpd2qq")]
        VCVTPD2QQ = 926,

        [Symbol("vcvtpd2udq")]
        VCVTPD2UDQ = 927,

        [Symbol("vcvtpd2uqq")]
        VCVTPD2UQQ = 928,

        [Symbol("vcvtph2ps")]
        VCVTPH2PS = 929,

        [Symbol("vcvtps2dq")]
        VCVTPS2DQ = 930,

        [Symbol("vcvtps2pd")]
        VCVTPS2PD = 931,

        [Symbol("vcvtps2ph")]
        VCVTPS2PH = 932,

        [Symbol("vcvtps2qq")]
        VCVTPS2QQ = 933,

        [Symbol("vcvtps2udq")]
        VCVTPS2UDQ = 934,

        [Symbol("vcvtps2uqq")]
        VCVTPS2UQQ = 935,

        [Symbol("vcvtqq2pd")]
        VCVTQQ2PD = 936,

        [Symbol("vcvtqq2ps")]
        VCVTQQ2PS = 937,

        [Symbol("vcvtsd2si")]
        VCVTSD2SI = 938,

        [Symbol("vcvtsd2ss")]
        VCVTSD2SS = 939,

        [Symbol("vcvtsd2usi")]
        VCVTSD2USI = 940,

        [Symbol("vcvtsi2sd")]
        VCVTSI2SD = 941,

        [Symbol("vcvtsi2ss")]
        VCVTSI2SS = 942,

        [Symbol("vcvtss2sd")]
        VCVTSS2SD = 943,

        [Symbol("vcvtss2si")]
        VCVTSS2SI = 944,

        [Symbol("vcvtss2usi")]
        VCVTSS2USI = 945,

        [Symbol("vcvttpd2dq")]
        VCVTTPD2DQ = 946,

        [Symbol("vcvttpd2qq")]
        VCVTTPD2QQ = 947,

        [Symbol("vcvttpd2udq")]
        VCVTTPD2UDQ = 948,

        [Symbol("vcvttpd2uqq")]
        VCVTTPD2UQQ = 949,

        [Symbol("vcvttps2dq")]
        VCVTTPS2DQ = 950,

        [Symbol("vcvttps2qq")]
        VCVTTPS2QQ = 951,

        [Symbol("vcvttps2udq")]
        VCVTTPS2UDQ = 952,

        [Symbol("vcvttps2uqq")]
        VCVTTPS2UQQ = 953,

        [Symbol("vcvttsd2si")]
        VCVTTSD2SI = 954,

        [Symbol("vcvttsd2usi")]
        VCVTTSD2USI = 955,

        [Symbol("vcvttss2si")]
        VCVTTSS2SI = 956,

        [Symbol("vcvttss2usi")]
        VCVTTSS2USI = 957,

        [Symbol("vcvtudq2pd")]
        VCVTUDQ2PD = 958,

        [Symbol("vcvtudq2ps")]
        VCVTUDQ2PS = 959,

        [Symbol("vcvtuqq2pd")]
        VCVTUQQ2PD = 960,

        [Symbol("vcvtuqq2ps")]
        VCVTUQQ2PS = 961,

        [Symbol("vcvtusi2sd")]
        VCVTUSI2SD = 962,

        [Symbol("vcvtusi2ss")]
        VCVTUSI2SS = 963,

        [Symbol("vdbpsadbw")]
        VDBPSADBW = 964,

        [Symbol("vdivpd")]
        VDIVPD = 965,

        [Symbol("vdivps")]
        VDIVPS = 966,

        [Symbol("vdivsd")]
        VDIVSD = 967,

        [Symbol("vdivss")]
        VDIVSS = 968,

        [Symbol("vdpbf16ps")]
        VDPBF16PS = 969,

        [Symbol("vdppd")]
        VDPPD = 970,

        [Symbol("vdpps")]
        VDPPS = 971,

        [Symbol("verr")]
        VERR = 972,

        [Symbol("verw")]
        VERW = 973,

        [Symbol("vexp2pd")]
        VEXP2PD = 974,

        [Symbol("vexp2ps")]
        VEXP2PS = 975,

        [Symbol("vexpandpd")]
        VEXPANDPD = 976,

        [Symbol("vexpandps")]
        VEXPANDPS = 977,

        [Symbol("vextractf128")]
        VEXTRACTF128 = 978,

        [Symbol("vextractf32x4")]
        VEXTRACTF32X4 = 979,

        [Symbol("vextractf32x8")]
        VEXTRACTF32X8 = 980,

        [Symbol("vextractf64x2")]
        VEXTRACTF64X2 = 981,

        [Symbol("vextractf64x4")]
        VEXTRACTF64X4 = 982,

        [Symbol("vextracti128")]
        VEXTRACTI128 = 983,

        [Symbol("vextracti32x4")]
        VEXTRACTI32X4 = 984,

        [Symbol("vextracti32x8")]
        VEXTRACTI32X8 = 985,

        [Symbol("vextracti64x2")]
        VEXTRACTI64X2 = 986,

        [Symbol("vextracti64x4")]
        VEXTRACTI64X4 = 987,

        [Symbol("vextractps")]
        VEXTRACTPS = 988,

        [Symbol("vfixupimmpd")]
        VFIXUPIMMPD = 989,

        [Symbol("vfixupimmps")]
        VFIXUPIMMPS = 990,

        [Symbol("vfixupimmsd")]
        VFIXUPIMMSD = 991,

        [Symbol("vfixupimmss")]
        VFIXUPIMMSS = 992,

        [Symbol("vfmadd132pd")]
        VFMADD132PD = 993,

        [Symbol("vfmadd132ps")]
        VFMADD132PS = 994,

        [Symbol("vfmadd132sd")]
        VFMADD132SD = 995,

        [Symbol("vfmadd132ss")]
        VFMADD132SS = 996,

        [Symbol("vfmadd213pd")]
        VFMADD213PD = 997,

        [Symbol("vfmadd213ps")]
        VFMADD213PS = 998,

        [Symbol("vfmadd213sd")]
        VFMADD213SD = 999,

        [Symbol("vfmadd213ss")]
        VFMADD213SS = 1000,

        [Symbol("vfmadd231pd")]
        VFMADD231PD = 1001,

        [Symbol("vfmadd231ps")]
        VFMADD231PS = 1002,

        [Symbol("vfmadd231sd")]
        VFMADD231SD = 1003,

        [Symbol("vfmadd231ss")]
        VFMADD231SS = 1004,

        [Symbol("vfmaddpd")]
        VFMADDPD = 1005,

        [Symbol("vfmaddps")]
        VFMADDPS = 1006,

        [Symbol("vfmaddsd")]
        VFMADDSD = 1007,

        [Symbol("vfmaddss")]
        VFMADDSS = 1008,

        [Symbol("vfmaddsub132pd")]
        VFMADDSUB132PD = 1009,

        [Symbol("vfmaddsub132ps")]
        VFMADDSUB132PS = 1010,

        [Symbol("vfmaddsub213pd")]
        VFMADDSUB213PD = 1011,

        [Symbol("vfmaddsub213ps")]
        VFMADDSUB213PS = 1012,

        [Symbol("vfmaddsub231pd")]
        VFMADDSUB231PD = 1013,

        [Symbol("vfmaddsub231ps")]
        VFMADDSUB231PS = 1014,

        [Symbol("vfmaddsubpd")]
        VFMADDSUBPD = 1015,

        [Symbol("vfmaddsubps")]
        VFMADDSUBPS = 1016,

        [Symbol("vfmsub132pd")]
        VFMSUB132PD = 1017,

        [Symbol("vfmsub132ps")]
        VFMSUB132PS = 1018,

        [Symbol("vfmsub132sd")]
        VFMSUB132SD = 1019,

        [Symbol("vfmsub132ss")]
        VFMSUB132SS = 1020,

        [Symbol("vfmsub213pd")]
        VFMSUB213PD = 1021,

        [Symbol("vfmsub213ps")]
        VFMSUB213PS = 1022,

        [Symbol("vfmsub213sd")]
        VFMSUB213SD = 1023,

        [Symbol("vfmsub213ss")]
        VFMSUB213SS = 1024,

        [Symbol("vfmsub231pd")]
        VFMSUB231PD = 1025,

        [Symbol("vfmsub231ps")]
        VFMSUB231PS = 1026,

        [Symbol("vfmsub231sd")]
        VFMSUB231SD = 1027,

        [Symbol("vfmsub231ss")]
        VFMSUB231SS = 1028,

        [Symbol("vfmsubadd132pd")]
        VFMSUBADD132PD = 1029,

        [Symbol("vfmsubadd132ps")]
        VFMSUBADD132PS = 1030,

        [Symbol("vfmsubadd213pd")]
        VFMSUBADD213PD = 1031,

        [Symbol("vfmsubadd213ps")]
        VFMSUBADD213PS = 1032,

        [Symbol("vfmsubadd231pd")]
        VFMSUBADD231PD = 1033,

        [Symbol("vfmsubadd231ps")]
        VFMSUBADD231PS = 1034,

        [Symbol("vfmsubaddpd")]
        VFMSUBADDPD = 1035,

        [Symbol("vfmsubaddps")]
        VFMSUBADDPS = 1036,

        [Symbol("vfmsubpd")]
        VFMSUBPD = 1037,

        [Symbol("vfmsubps")]
        VFMSUBPS = 1038,

        [Symbol("vfmsubsd")]
        VFMSUBSD = 1039,

        [Symbol("vfmsubss")]
        VFMSUBSS = 1040,

        [Symbol("vfnmadd132pd")]
        VFNMADD132PD = 1041,

        [Symbol("vfnmadd132ps")]
        VFNMADD132PS = 1042,

        [Symbol("vfnmadd132sd")]
        VFNMADD132SD = 1043,

        [Symbol("vfnmadd132ss")]
        VFNMADD132SS = 1044,

        [Symbol("vfnmadd213pd")]
        VFNMADD213PD = 1045,

        [Symbol("vfnmadd213ps")]
        VFNMADD213PS = 1046,

        [Symbol("vfnmadd213sd")]
        VFNMADD213SD = 1047,

        [Symbol("vfnmadd213ss")]
        VFNMADD213SS = 1048,

        [Symbol("vfnmadd231pd")]
        VFNMADD231PD = 1049,

        [Symbol("vfnmadd231ps")]
        VFNMADD231PS = 1050,

        [Symbol("vfnmadd231sd")]
        VFNMADD231SD = 1051,

        [Symbol("vfnmadd231ss")]
        VFNMADD231SS = 1052,

        [Symbol("vfnmaddpd")]
        VFNMADDPD = 1053,

        [Symbol("vfnmaddps")]
        VFNMADDPS = 1054,

        [Symbol("vfnmaddsd")]
        VFNMADDSD = 1055,

        [Symbol("vfnmaddss")]
        VFNMADDSS = 1056,

        [Symbol("vfnmsub132pd")]
        VFNMSUB132PD = 1057,

        [Symbol("vfnmsub132ps")]
        VFNMSUB132PS = 1058,

        [Symbol("vfnmsub132sd")]
        VFNMSUB132SD = 1059,

        [Symbol("vfnmsub132ss")]
        VFNMSUB132SS = 1060,

        [Symbol("vfnmsub213pd")]
        VFNMSUB213PD = 1061,

        [Symbol("vfnmsub213ps")]
        VFNMSUB213PS = 1062,

        [Symbol("vfnmsub213sd")]
        VFNMSUB213SD = 1063,

        [Symbol("vfnmsub213ss")]
        VFNMSUB213SS = 1064,

        [Symbol("vfnmsub231pd")]
        VFNMSUB231PD = 1065,

        [Symbol("vfnmsub231ps")]
        VFNMSUB231PS = 1066,

        [Symbol("vfnmsub231sd")]
        VFNMSUB231SD = 1067,

        [Symbol("vfnmsub231ss")]
        VFNMSUB231SS = 1068,

        [Symbol("vfnmsubpd")]
        VFNMSUBPD = 1069,

        [Symbol("vfnmsubps")]
        VFNMSUBPS = 1070,

        [Symbol("vfnmsubsd")]
        VFNMSUBSD = 1071,

        [Symbol("vfnmsubss")]
        VFNMSUBSS = 1072,

        [Symbol("vfpclasspd")]
        VFPCLASSPD = 1073,

        [Symbol("vfpclassps")]
        VFPCLASSPS = 1074,

        [Symbol("vfpclasssd")]
        VFPCLASSSD = 1075,

        [Symbol("vfpclassss")]
        VFPCLASSSS = 1076,

        [Symbol("vfrczpd")]
        VFRCZPD = 1077,

        [Symbol("vfrczps")]
        VFRCZPS = 1078,

        [Symbol("vfrczsd")]
        VFRCZSD = 1079,

        [Symbol("vfrczss")]
        VFRCZSS = 1080,

        [Symbol("vgatherdpd")]
        VGATHERDPD = 1081,

        [Symbol("vgatherdps")]
        VGATHERDPS = 1082,

        [Symbol("vgatherpf0dpd")]
        VGATHERPF0DPD = 1083,

        [Symbol("vgatherpf0dps")]
        VGATHERPF0DPS = 1084,

        [Symbol("vgatherpf0qpd")]
        VGATHERPF0QPD = 1085,

        [Symbol("vgatherpf0qps")]
        VGATHERPF0QPS = 1086,

        [Symbol("vgatherpf1dpd")]
        VGATHERPF1DPD = 1087,

        [Symbol("vgatherpf1dps")]
        VGATHERPF1DPS = 1088,

        [Symbol("vgatherpf1qpd")]
        VGATHERPF1QPD = 1089,

        [Symbol("vgatherpf1qps")]
        VGATHERPF1QPS = 1090,

        [Symbol("vgatherqpd")]
        VGATHERQPD = 1091,

        [Symbol("vgatherqps")]
        VGATHERQPS = 1092,

        [Symbol("vgetexppd")]
        VGETEXPPD = 1093,

        [Symbol("vgetexpps")]
        VGETEXPPS = 1094,

        [Symbol("vgetexpsd")]
        VGETEXPSD = 1095,

        [Symbol("vgetexpss")]
        VGETEXPSS = 1096,

        [Symbol("vgetmantpd")]
        VGETMANTPD = 1097,

        [Symbol("vgetmantps")]
        VGETMANTPS = 1098,

        [Symbol("vgetmantsd")]
        VGETMANTSD = 1099,

        [Symbol("vgetmantss")]
        VGETMANTSS = 1100,

        [Symbol("vgf2p8affineinvqb")]
        VGF2P8AFFINEINVQB = 1101,

        [Symbol("vgf2p8affineqb")]
        VGF2P8AFFINEQB = 1102,

        [Symbol("vgf2p8mulb")]
        VGF2P8MULB = 1103,

        [Symbol("vhaddpd")]
        VHADDPD = 1104,

        [Symbol("vhaddps")]
        VHADDPS = 1105,

        [Symbol("vhsubpd")]
        VHSUBPD = 1106,

        [Symbol("vhsubps")]
        VHSUBPS = 1107,

        [Symbol("vinsertf128")]
        VINSERTF128 = 1108,

        [Symbol("vinsertf32x4")]
        VINSERTF32X4 = 1109,

        [Symbol("vinsertf32x8")]
        VINSERTF32X8 = 1110,

        [Symbol("vinsertf64x2")]
        VINSERTF64X2 = 1111,

        [Symbol("vinsertf64x4")]
        VINSERTF64X4 = 1112,

        [Symbol("vinserti128")]
        VINSERTI128 = 1113,

        [Symbol("vinserti32x4")]
        VINSERTI32X4 = 1114,

        [Symbol("vinserti32x8")]
        VINSERTI32X8 = 1115,

        [Symbol("vinserti64x2")]
        VINSERTI64X2 = 1116,

        [Symbol("vinserti64x4")]
        VINSERTI64X4 = 1117,

        [Symbol("vinsertps")]
        VINSERTPS = 1118,

        [Symbol("vlddqu")]
        VLDDQU = 1119,

        [Symbol("vldmxcsr")]
        VLDMXCSR = 1120,

        [Symbol("vmaskmovdqu")]
        VMASKMOVDQU = 1121,

        [Symbol("vmaskmovpd")]
        VMASKMOVPD = 1122,

        [Symbol("vmaskmovps")]
        VMASKMOVPS = 1123,

        [Symbol("vmaxpd")]
        VMAXPD = 1124,

        [Symbol("vmaxps")]
        VMAXPS = 1125,

        [Symbol("vmaxsd")]
        VMAXSD = 1126,

        [Symbol("vmaxss")]
        VMAXSS = 1127,

        [Symbol("vmcall")]
        VMCALL = 1128,

        [Symbol("vmclear")]
        VMCLEAR = 1129,

        [Symbol("vmfunc")]
        VMFUNC = 1130,

        [Symbol("vminpd")]
        VMINPD = 1131,

        [Symbol("vminps")]
        VMINPS = 1132,

        [Symbol("vminsd")]
        VMINSD = 1133,

        [Symbol("vminss")]
        VMINSS = 1134,

        [Symbol("vmlaunch")]
        VMLAUNCH = 1135,

        [Symbol("vmload")]
        VMLOAD = 1136,

        [Symbol("vmmcall")]
        VMMCALL = 1137,

        [Symbol("vmovapd")]
        VMOVAPD = 1138,

        [Symbol("vmovaps")]
        VMOVAPS = 1139,

        [Symbol("vmovd")]
        VMOVD = 1140,

        [Symbol("vmovddup")]
        VMOVDDUP = 1141,

        [Symbol("vmovdqa")]
        VMOVDQA = 1142,

        [Symbol("vmovdqa32")]
        VMOVDQA32 = 1143,

        [Symbol("vmovdqa64")]
        VMOVDQA64 = 1144,

        [Symbol("vmovdqu")]
        VMOVDQU = 1145,

        [Symbol("vmovdqu16")]
        VMOVDQU16 = 1146,

        [Symbol("vmovdqu32")]
        VMOVDQU32 = 1147,

        [Symbol("vmovdqu64")]
        VMOVDQU64 = 1148,

        [Symbol("vmovdqu8")]
        VMOVDQU8 = 1149,

        [Symbol("vmovhlps")]
        VMOVHLPS = 1150,

        [Symbol("vmovhpd")]
        VMOVHPD = 1151,

        [Symbol("vmovhps")]
        VMOVHPS = 1152,

        [Symbol("vmovlhps")]
        VMOVLHPS = 1153,

        [Symbol("vmovlpd")]
        VMOVLPD = 1154,

        [Symbol("vmovlps")]
        VMOVLPS = 1155,

        [Symbol("vmovmskpd")]
        VMOVMSKPD = 1156,

        [Symbol("vmovmskps")]
        VMOVMSKPS = 1157,

        [Symbol("vmovntdq")]
        VMOVNTDQ = 1158,

        [Symbol("vmovntdqa")]
        VMOVNTDQA = 1159,

        [Symbol("vmovntpd")]
        VMOVNTPD = 1160,

        [Symbol("vmovntps")]
        VMOVNTPS = 1161,

        [Symbol("vmovq")]
        VMOVQ = 1162,

        [Symbol("vmovsd")]
        VMOVSD = 1163,

        [Symbol("vmovshdup")]
        VMOVSHDUP = 1164,

        [Symbol("vmovsldup")]
        VMOVSLDUP = 1165,

        [Symbol("vmovss")]
        VMOVSS = 1166,

        [Symbol("vmovupd")]
        VMOVUPD = 1167,

        [Symbol("vmovups")]
        VMOVUPS = 1168,

        [Symbol("vmpsadbw")]
        VMPSADBW = 1169,

        [Symbol("vmptrld")]
        VMPTRLD = 1170,

        [Symbol("vmptrst")]
        VMPTRST = 1171,

        [Symbol("vmread")]
        VMREAD = 1172,

        [Symbol("vmresume")]
        VMRESUME = 1173,

        [Symbol("vmrun")]
        VMRUN = 1174,

        [Symbol("vmsave")]
        VMSAVE = 1175,

        [Symbol("vmulpd")]
        VMULPD = 1176,

        [Symbol("vmulps")]
        VMULPS = 1177,

        [Symbol("vmulsd")]
        VMULSD = 1178,

        [Symbol("vmulss")]
        VMULSS = 1179,

        [Symbol("vmwrite")]
        VMWRITE = 1180,

        [Symbol("vmxoff")]
        VMXOFF = 1181,

        [Symbol("vmxon")]
        VMXON = 1182,

        [Symbol("vorpd")]
        VORPD = 1183,

        [Symbol("vorps")]
        VORPS = 1184,

        [Symbol("vp2intersectd")]
        VP2INTERSECTD = 1185,

        [Symbol("vp2intersectq")]
        VP2INTERSECTQ = 1186,

        [Symbol("vp4dpwssd")]
        VP4DPWSSD = 1187,

        [Symbol("vp4dpwssds")]
        VP4DPWSSDS = 1188,

        [Symbol("vpabsb")]
        VPABSB = 1189,

        [Symbol("vpabsd")]
        VPABSD = 1190,

        [Symbol("vpabsq")]
        VPABSQ = 1191,

        [Symbol("vpabsw")]
        VPABSW = 1192,

        [Symbol("vpackssdw")]
        VPACKSSDW = 1193,

        [Symbol("vpacksswb")]
        VPACKSSWB = 1194,

        [Symbol("vpackusdw")]
        VPACKUSDW = 1195,

        [Symbol("vpackuswb")]
        VPACKUSWB = 1196,

        [Symbol("vpaddb")]
        VPADDB = 1197,

        [Symbol("vpaddd")]
        VPADDD = 1198,

        [Symbol("vpaddq")]
        VPADDQ = 1199,

        [Symbol("vpaddsb")]
        VPADDSB = 1200,

        [Symbol("vpaddsw")]
        VPADDSW = 1201,

        [Symbol("vpaddusb")]
        VPADDUSB = 1202,

        [Symbol("vpaddusw")]
        VPADDUSW = 1203,

        [Symbol("vpaddw")]
        VPADDW = 1204,

        [Symbol("vpalignr")]
        VPALIGNR = 1205,

        [Symbol("vpand")]
        VPAND = 1206,

        [Symbol("vpandd")]
        VPANDD = 1207,

        [Symbol("vpandn")]
        VPANDN = 1208,

        [Symbol("vpandnd")]
        VPANDND = 1209,

        [Symbol("vpandnq")]
        VPANDNQ = 1210,

        [Symbol("vpandq")]
        VPANDQ = 1211,

        [Symbol("vpavgb")]
        VPAVGB = 1212,

        [Symbol("vpavgw")]
        VPAVGW = 1213,

        [Symbol("vpblendd")]
        VPBLENDD = 1214,

        [Symbol("vpblendmb")]
        VPBLENDMB = 1215,

        [Symbol("vpblendmd")]
        VPBLENDMD = 1216,

        [Symbol("vpblendmq")]
        VPBLENDMQ = 1217,

        [Symbol("vpblendmw")]
        VPBLENDMW = 1218,

        [Symbol("vpblendvb")]
        VPBLENDVB = 1219,

        [Symbol("vpblendw")]
        VPBLENDW = 1220,

        [Symbol("vpbroadcastb")]
        VPBROADCASTB = 1221,

        [Symbol("vpbroadcastd")]
        VPBROADCASTD = 1222,

        [Symbol("vpbroadcastmb2q")]
        VPBROADCASTMB2Q = 1223,

        [Symbol("vpbroadcastmw2d")]
        VPBROADCASTMW2D = 1224,

        [Symbol("vpbroadcastq")]
        VPBROADCASTQ = 1225,

        [Symbol("vpbroadcastw")]
        VPBROADCASTW = 1226,

        [Symbol("vpclmulqdq")]
        VPCLMULQDQ = 1227,

        [Symbol("vpcmov")]
        VPCMOV = 1228,

        [Symbol("vpcmpb")]
        VPCMPB = 1229,

        [Symbol("vpcmpd")]
        VPCMPD = 1230,

        [Symbol("vpcmpeqb")]
        VPCMPEQB = 1231,

        [Symbol("vpcmpeqd")]
        VPCMPEQD = 1232,

        [Symbol("vpcmpeqq")]
        VPCMPEQQ = 1233,

        [Symbol("vpcmpeqw")]
        VPCMPEQW = 1234,

        [Symbol("vpcmpestri")]
        VPCMPESTRI = 1235,

        [Symbol("vpcmpestri64")]
        VPCMPESTRI64 = 1236,

        [Symbol("vpcmpestrm")]
        VPCMPESTRM = 1237,

        [Symbol("vpcmpestrm64")]
        VPCMPESTRM64 = 1238,

        [Symbol("vpcmpgtb")]
        VPCMPGTB = 1239,

        [Symbol("vpcmpgtd")]
        VPCMPGTD = 1240,

        [Symbol("vpcmpgtq")]
        VPCMPGTQ = 1241,

        [Symbol("vpcmpgtw")]
        VPCMPGTW = 1242,

        [Symbol("vpcmpistri")]
        VPCMPISTRI = 1243,

        [Symbol("vpcmpistri64")]
        VPCMPISTRI64 = 1244,

        [Symbol("vpcmpistrm")]
        VPCMPISTRM = 1245,

        [Symbol("vpcmpq")]
        VPCMPQ = 1246,

        [Symbol("vpcmpub")]
        VPCMPUB = 1247,

        [Symbol("vpcmpud")]
        VPCMPUD = 1248,

        [Symbol("vpcmpuq")]
        VPCMPUQ = 1249,

        [Symbol("vpcmpuw")]
        VPCMPUW = 1250,

        [Symbol("vpcmpw")]
        VPCMPW = 1251,

        [Symbol("vpcomb")]
        VPCOMB = 1252,

        [Symbol("vpcomd")]
        VPCOMD = 1253,

        [Symbol("vpcompressb")]
        VPCOMPRESSB = 1254,

        [Symbol("vpcompressd")]
        VPCOMPRESSD = 1255,

        [Symbol("vpcompressq")]
        VPCOMPRESSQ = 1256,

        [Symbol("vpcompressw")]
        VPCOMPRESSW = 1257,

        [Symbol("vpcomq")]
        VPCOMQ = 1258,

        [Symbol("vpcomub")]
        VPCOMUB = 1259,

        [Symbol("vpcomud")]
        VPCOMUD = 1260,

        [Symbol("vpcomuq")]
        VPCOMUQ = 1261,

        [Symbol("vpcomuw")]
        VPCOMUW = 1262,

        [Symbol("vpcomw")]
        VPCOMW = 1263,

        [Symbol("vpconflictd")]
        VPCONFLICTD = 1264,

        [Symbol("vpconflictq")]
        VPCONFLICTQ = 1265,

        [Symbol("vpdpbusd")]
        VPDPBUSD = 1266,

        [Symbol("vpdpbusds")]
        VPDPBUSDS = 1267,

        [Symbol("vpdpwssd")]
        VPDPWSSD = 1268,

        [Symbol("vpdpwssds")]
        VPDPWSSDS = 1269,

        [Symbol("vperm2f128")]
        VPERM2F128 = 1270,

        [Symbol("vperm2i128")]
        VPERM2I128 = 1271,

        [Symbol("vpermb")]
        VPERMB = 1272,

        [Symbol("vpermd")]
        VPERMD = 1273,

        [Symbol("vpermi2b")]
        VPERMI2B = 1274,

        [Symbol("vpermi2d")]
        VPERMI2D = 1275,

        [Symbol("vpermi2pd")]
        VPERMI2PD = 1276,

        [Symbol("vpermi2ps")]
        VPERMI2PS = 1277,

        [Symbol("vpermi2q")]
        VPERMI2Q = 1278,

        [Symbol("vpermi2w")]
        VPERMI2W = 1279,

        [Symbol("vpermil2pd")]
        VPERMIL2PD = 1280,

        [Symbol("vpermil2ps")]
        VPERMIL2PS = 1281,

        [Symbol("vpermilpd")]
        VPERMILPD = 1282,

        [Symbol("vpermilps")]
        VPERMILPS = 1283,

        [Symbol("vpermpd")]
        VPERMPD = 1284,

        [Symbol("vpermps")]
        VPERMPS = 1285,

        [Symbol("vpermq")]
        VPERMQ = 1286,

        [Symbol("vpermt2b")]
        VPERMT2B = 1287,

        [Symbol("vpermt2d")]
        VPERMT2D = 1288,

        [Symbol("vpermt2pd")]
        VPERMT2PD = 1289,

        [Symbol("vpermt2ps")]
        VPERMT2PS = 1290,

        [Symbol("vpermt2q")]
        VPERMT2Q = 1291,

        [Symbol("vpermt2w")]
        VPERMT2W = 1292,

        [Symbol("vpermw")]
        VPERMW = 1293,

        [Symbol("vpexpandb")]
        VPEXPANDB = 1294,

        [Symbol("vpexpandd")]
        VPEXPANDD = 1295,

        [Symbol("vpexpandq")]
        VPEXPANDQ = 1296,

        [Symbol("vpexpandw")]
        VPEXPANDW = 1297,

        [Symbol("vpextrb")]
        VPEXTRB = 1298,

        [Symbol("vpextrd")]
        VPEXTRD = 1299,

        [Symbol("vpextrq")]
        VPEXTRQ = 1300,

        [Symbol("vpextrw")]
        VPEXTRW = 1301,

        [Symbol("vpextrw_c5")]
        VPEXTRW_C5 = 1302,

        [Symbol("vpgatherdd")]
        VPGATHERDD = 1303,

        [Symbol("vpgatherdq")]
        VPGATHERDQ = 1304,

        [Symbol("vpgatherqd")]
        VPGATHERQD = 1305,

        [Symbol("vpgatherqq")]
        VPGATHERQQ = 1306,

        [Symbol("vphaddbd")]
        VPHADDBD = 1307,

        [Symbol("vphaddbq")]
        VPHADDBQ = 1308,

        [Symbol("vphaddbw")]
        VPHADDBW = 1309,

        [Symbol("vphaddd")]
        VPHADDD = 1310,

        [Symbol("vphadddq")]
        VPHADDDQ = 1311,

        [Symbol("vphaddsw")]
        VPHADDSW = 1312,

        [Symbol("vphaddubd")]
        VPHADDUBD = 1313,

        [Symbol("vphaddubq")]
        VPHADDUBQ = 1314,

        [Symbol("vphaddubw")]
        VPHADDUBW = 1315,

        [Symbol("vphaddudq")]
        VPHADDUDQ = 1316,

        [Symbol("vphadduwd")]
        VPHADDUWD = 1317,

        [Symbol("vphadduwq")]
        VPHADDUWQ = 1318,

        [Symbol("vphaddw")]
        VPHADDW = 1319,

        [Symbol("vphaddwd")]
        VPHADDWD = 1320,

        [Symbol("vphaddwq")]
        VPHADDWQ = 1321,

        [Symbol("vphminposuw")]
        VPHMINPOSUW = 1322,

        [Symbol("vphsubbw")]
        VPHSUBBW = 1323,

        [Symbol("vphsubd")]
        VPHSUBD = 1324,

        [Symbol("vphsubdq")]
        VPHSUBDQ = 1325,

        [Symbol("vphsubsw")]
        VPHSUBSW = 1326,

        [Symbol("vphsubw")]
        VPHSUBW = 1327,

        [Symbol("vphsubwd")]
        VPHSUBWD = 1328,

        [Symbol("vpinsrb")]
        VPINSRB = 1329,

        [Symbol("vpinsrd")]
        VPINSRD = 1330,

        [Symbol("vpinsrq")]
        VPINSRQ = 1331,

        [Symbol("vpinsrw")]
        VPINSRW = 1332,

        [Symbol("vplzcntd")]
        VPLZCNTD = 1333,

        [Symbol("vplzcntq")]
        VPLZCNTQ = 1334,

        [Symbol("vpmacsdd")]
        VPMACSDD = 1335,

        [Symbol("vpmacsdqh")]
        VPMACSDQH = 1336,

        [Symbol("vpmacsdql")]
        VPMACSDQL = 1337,

        [Symbol("vpmacssdd")]
        VPMACSSDD = 1338,

        [Symbol("vpmacssdqh")]
        VPMACSSDQH = 1339,

        [Symbol("vpmacssdql")]
        VPMACSSDQL = 1340,

        [Symbol("vpmacsswd")]
        VPMACSSWD = 1341,

        [Symbol("vpmacssww")]
        VPMACSSWW = 1342,

        [Symbol("vpmacswd")]
        VPMACSWD = 1343,

        [Symbol("vpmacsww")]
        VPMACSWW = 1344,

        [Symbol("vpmadcsswd")]
        VPMADCSSWD = 1345,

        [Symbol("vpmadcswd")]
        VPMADCSWD = 1346,

        [Symbol("vpmadd52huq")]
        VPMADD52HUQ = 1347,

        [Symbol("vpmadd52luq")]
        VPMADD52LUQ = 1348,

        [Symbol("vpmaddubsw")]
        VPMADDUBSW = 1349,

        [Symbol("vpmaddwd")]
        VPMADDWD = 1350,

        [Symbol("vpmaskmovd")]
        VPMASKMOVD = 1351,

        [Symbol("vpmaskmovq")]
        VPMASKMOVQ = 1352,

        [Symbol("vpmaxsb")]
        VPMAXSB = 1353,

        [Symbol("vpmaxsd")]
        VPMAXSD = 1354,

        [Symbol("vpmaxsq")]
        VPMAXSQ = 1355,

        [Symbol("vpmaxsw")]
        VPMAXSW = 1356,

        [Symbol("vpmaxub")]
        VPMAXUB = 1357,

        [Symbol("vpmaxud")]
        VPMAXUD = 1358,

        [Symbol("vpmaxuq")]
        VPMAXUQ = 1359,

        [Symbol("vpmaxuw")]
        VPMAXUW = 1360,

        [Symbol("vpminsb")]
        VPMINSB = 1361,

        [Symbol("vpminsd")]
        VPMINSD = 1362,

        [Symbol("vpminsq")]
        VPMINSQ = 1363,

        [Symbol("vpminsw")]
        VPMINSW = 1364,

        [Symbol("vpminub")]
        VPMINUB = 1365,

        [Symbol("vpminud")]
        VPMINUD = 1366,

        [Symbol("vpminuq")]
        VPMINUQ = 1367,

        [Symbol("vpminuw")]
        VPMINUW = 1368,

        [Symbol("vpmovb2m")]
        VPMOVB2M = 1369,

        [Symbol("vpmovd2m")]
        VPMOVD2M = 1370,

        [Symbol("vpmovdb")]
        VPMOVDB = 1371,

        [Symbol("vpmovdw")]
        VPMOVDW = 1372,

        [Symbol("vpmovm2b")]
        VPMOVM2B = 1373,

        [Symbol("vpmovm2d")]
        VPMOVM2D = 1374,

        [Symbol("vpmovm2q")]
        VPMOVM2Q = 1375,

        [Symbol("vpmovm2w")]
        VPMOVM2W = 1376,

        [Symbol("vpmovmskb")]
        VPMOVMSKB = 1377,

        [Symbol("vpmovq2m")]
        VPMOVQ2M = 1378,

        [Symbol("vpmovqb")]
        VPMOVQB = 1379,

        [Symbol("vpmovqd")]
        VPMOVQD = 1380,

        [Symbol("vpmovqw")]
        VPMOVQW = 1381,

        [Symbol("vpmovsdb")]
        VPMOVSDB = 1382,

        [Symbol("vpmovsdw")]
        VPMOVSDW = 1383,

        [Symbol("vpmovsqb")]
        VPMOVSQB = 1384,

        [Symbol("vpmovsqd")]
        VPMOVSQD = 1385,

        [Symbol("vpmovsqw")]
        VPMOVSQW = 1386,

        [Symbol("vpmovswb")]
        VPMOVSWB = 1387,

        [Symbol("vpmovsxbd")]
        VPMOVSXBD = 1388,

        [Symbol("vpmovsxbq")]
        VPMOVSXBQ = 1389,

        [Symbol("vpmovsxbw")]
        VPMOVSXBW = 1390,

        [Symbol("vpmovsxdq")]
        VPMOVSXDQ = 1391,

        [Symbol("vpmovsxwd")]
        VPMOVSXWD = 1392,

        [Symbol("vpmovsxwq")]
        VPMOVSXWQ = 1393,

        [Symbol("vpmovusdb")]
        VPMOVUSDB = 1394,

        [Symbol("vpmovusdw")]
        VPMOVUSDW = 1395,

        [Symbol("vpmovusqb")]
        VPMOVUSQB = 1396,

        [Symbol("vpmovusqd")]
        VPMOVUSQD = 1397,

        [Symbol("vpmovusqw")]
        VPMOVUSQW = 1398,

        [Symbol("vpmovuswb")]
        VPMOVUSWB = 1399,

        [Symbol("vpmovw2m")]
        VPMOVW2M = 1400,

        [Symbol("vpmovwb")]
        VPMOVWB = 1401,

        [Symbol("vpmovzxbd")]
        VPMOVZXBD = 1402,

        [Symbol("vpmovzxbq")]
        VPMOVZXBQ = 1403,

        [Symbol("vpmovzxbw")]
        VPMOVZXBW = 1404,

        [Symbol("vpmovzxdq")]
        VPMOVZXDQ = 1405,

        [Symbol("vpmovzxwd")]
        VPMOVZXWD = 1406,

        [Symbol("vpmovzxwq")]
        VPMOVZXWQ = 1407,

        [Symbol("vpmuldq")]
        VPMULDQ = 1408,

        [Symbol("vpmulhrsw")]
        VPMULHRSW = 1409,

        [Symbol("vpmulhuw")]
        VPMULHUW = 1410,

        [Symbol("vpmulhw")]
        VPMULHW = 1411,

        [Symbol("vpmulld")]
        VPMULLD = 1412,

        [Symbol("vpmullq")]
        VPMULLQ = 1413,

        [Symbol("vpmullw")]
        VPMULLW = 1414,

        [Symbol("vpmultishiftqb")]
        VPMULTISHIFTQB = 1415,

        [Symbol("vpmuludq")]
        VPMULUDQ = 1416,

        [Symbol("vpopcntb")]
        VPOPCNTB = 1417,

        [Symbol("vpopcntd")]
        VPOPCNTD = 1418,

        [Symbol("vpopcntq")]
        VPOPCNTQ = 1419,

        [Symbol("vpopcntw")]
        VPOPCNTW = 1420,

        [Symbol("vpor")]
        VPOR = 1421,

        [Symbol("vpord")]
        VPORD = 1422,

        [Symbol("vporq")]
        VPORQ = 1423,

        [Symbol("vpperm")]
        VPPERM = 1424,

        [Symbol("vprold")]
        VPROLD = 1425,

        [Symbol("vprolq")]
        VPROLQ = 1426,

        [Symbol("vprolvd")]
        VPROLVD = 1427,

        [Symbol("vprolvq")]
        VPROLVQ = 1428,

        [Symbol("vprord")]
        VPRORD = 1429,

        [Symbol("vprorq")]
        VPRORQ = 1430,

        [Symbol("vprorvd")]
        VPRORVD = 1431,

        [Symbol("vprorvq")]
        VPRORVQ = 1432,

        [Symbol("vprotb")]
        VPROTB = 1433,

        [Symbol("vprotd")]
        VPROTD = 1434,

        [Symbol("vprotq")]
        VPROTQ = 1435,

        [Symbol("vprotw")]
        VPROTW = 1436,

        [Symbol("vpsadbw")]
        VPSADBW = 1437,

        [Symbol("vpscatterdd")]
        VPSCATTERDD = 1438,

        [Symbol("vpscatterdq")]
        VPSCATTERDQ = 1439,

        [Symbol("vpscatterqd")]
        VPSCATTERQD = 1440,

        [Symbol("vpscatterqq")]
        VPSCATTERQQ = 1441,

        [Symbol("vpshab")]
        VPSHAB = 1442,

        [Symbol("vpshad")]
        VPSHAD = 1443,

        [Symbol("vpshaq")]
        VPSHAQ = 1444,

        [Symbol("vpshaw")]
        VPSHAW = 1445,

        [Symbol("vpshlb")]
        VPSHLB = 1446,

        [Symbol("vpshld")]
        VPSHLD = 1447,

        [Symbol("vpshldd")]
        VPSHLDD = 1448,

        [Symbol("vpshldq")]
        VPSHLDQ = 1449,

        [Symbol("vpshldvd")]
        VPSHLDVD = 1450,

        [Symbol("vpshldvq")]
        VPSHLDVQ = 1451,

        [Symbol("vpshldvw")]
        VPSHLDVW = 1452,

        [Symbol("vpshldw")]
        VPSHLDW = 1453,

        [Symbol("vpshlq")]
        VPSHLQ = 1454,

        [Symbol("vpshlw")]
        VPSHLW = 1455,

        [Symbol("vpshrdd")]
        VPSHRDD = 1456,

        [Symbol("vpshrdq")]
        VPSHRDQ = 1457,

        [Symbol("vpshrdvd")]
        VPSHRDVD = 1458,

        [Symbol("vpshrdvq")]
        VPSHRDVQ = 1459,

        [Symbol("vpshrdvw")]
        VPSHRDVW = 1460,

        [Symbol("vpshrdw")]
        VPSHRDW = 1461,

        [Symbol("vpshufb")]
        VPSHUFB = 1462,

        [Symbol("vpshufbitqmb")]
        VPSHUFBITQMB = 1463,

        [Symbol("vpshufd")]
        VPSHUFD = 1464,

        [Symbol("vpshufhw")]
        VPSHUFHW = 1465,

        [Symbol("vpshuflw")]
        VPSHUFLW = 1466,

        [Symbol("vpsignb")]
        VPSIGNB = 1467,

        [Symbol("vpsignd")]
        VPSIGND = 1468,

        [Symbol("vpsignw")]
        VPSIGNW = 1469,

        [Symbol("vpslld")]
        VPSLLD = 1470,

        [Symbol("vpslldq")]
        VPSLLDQ = 1471,

        [Symbol("vpsllq")]
        VPSLLQ = 1472,

        [Symbol("vpsllvd")]
        VPSLLVD = 1473,

        [Symbol("vpsllvq")]
        VPSLLVQ = 1474,

        [Symbol("vpsllvw")]
        VPSLLVW = 1475,

        [Symbol("vpsllw")]
        VPSLLW = 1476,

        [Symbol("vpsrad")]
        VPSRAD = 1477,

        [Symbol("vpsraq")]
        VPSRAQ = 1478,

        [Symbol("vpsravd")]
        VPSRAVD = 1479,

        [Symbol("vpsravq")]
        VPSRAVQ = 1480,

        [Symbol("vpsravw")]
        VPSRAVW = 1481,

        [Symbol("vpsraw")]
        VPSRAW = 1482,

        [Symbol("vpsrld")]
        VPSRLD = 1483,

        [Symbol("vpsrldq")]
        VPSRLDQ = 1484,

        [Symbol("vpsrlq")]
        VPSRLQ = 1485,

        [Symbol("vpsrlvd")]
        VPSRLVD = 1486,

        [Symbol("vpsrlvq")]
        VPSRLVQ = 1487,

        [Symbol("vpsrlvw")]
        VPSRLVW = 1488,

        [Symbol("vpsrlw")]
        VPSRLW = 1489,

        [Symbol("vpsubb")]
        VPSUBB = 1490,

        [Symbol("vpsubd")]
        VPSUBD = 1491,

        [Symbol("vpsubq")]
        VPSUBQ = 1492,

        [Symbol("vpsubsb")]
        VPSUBSB = 1493,

        [Symbol("vpsubsw")]
        VPSUBSW = 1494,

        [Symbol("vpsubusb")]
        VPSUBUSB = 1495,

        [Symbol("vpsubusw")]
        VPSUBUSW = 1496,

        [Symbol("vpsubw")]
        VPSUBW = 1497,

        [Symbol("vpternlogd")]
        VPTERNLOGD = 1498,

        [Symbol("vpternlogq")]
        VPTERNLOGQ = 1499,

        [Symbol("vptest")]
        VPTEST = 1500,

        [Symbol("vptestmb")]
        VPTESTMB = 1501,

        [Symbol("vptestmd")]
        VPTESTMD = 1502,

        [Symbol("vptestmq")]
        VPTESTMQ = 1503,

        [Symbol("vptestmw")]
        VPTESTMW = 1504,

        [Symbol("vptestnmb")]
        VPTESTNMB = 1505,

        [Symbol("vptestnmd")]
        VPTESTNMD = 1506,

        [Symbol("vptestnmq")]
        VPTESTNMQ = 1507,

        [Symbol("vptestnmw")]
        VPTESTNMW = 1508,

        [Symbol("vpunpckhbw")]
        VPUNPCKHBW = 1509,

        [Symbol("vpunpckhdq")]
        VPUNPCKHDQ = 1510,

        [Symbol("vpunpckhqdq")]
        VPUNPCKHQDQ = 1511,

        [Symbol("vpunpckhwd")]
        VPUNPCKHWD = 1512,

        [Symbol("vpunpcklbw")]
        VPUNPCKLBW = 1513,

        [Symbol("vpunpckldq")]
        VPUNPCKLDQ = 1514,

        [Symbol("vpunpcklqdq")]
        VPUNPCKLQDQ = 1515,

        [Symbol("vpunpcklwd")]
        VPUNPCKLWD = 1516,

        [Symbol("vpxor")]
        VPXOR = 1517,

        [Symbol("vpxord")]
        VPXORD = 1518,

        [Symbol("vpxorq")]
        VPXORQ = 1519,

        [Symbol("vrangepd")]
        VRANGEPD = 1520,

        [Symbol("vrangeps")]
        VRANGEPS = 1521,

        [Symbol("vrangesd")]
        VRANGESD = 1522,

        [Symbol("vrangess")]
        VRANGESS = 1523,

        [Symbol("vrcp14pd")]
        VRCP14PD = 1524,

        [Symbol("vrcp14ps")]
        VRCP14PS = 1525,

        [Symbol("vrcp14sd")]
        VRCP14SD = 1526,

        [Symbol("vrcp14ss")]
        VRCP14SS = 1527,

        [Symbol("vrcp28pd")]
        VRCP28PD = 1528,

        [Symbol("vrcp28ps")]
        VRCP28PS = 1529,

        [Symbol("vrcp28sd")]
        VRCP28SD = 1530,

        [Symbol("vrcp28ss")]
        VRCP28SS = 1531,

        [Symbol("vrcpps")]
        VRCPPS = 1532,

        [Symbol("vrcpss")]
        VRCPSS = 1533,

        [Symbol("vreducepd")]
        VREDUCEPD = 1534,

        [Symbol("vreduceps")]
        VREDUCEPS = 1535,

        [Symbol("vreducesd")]
        VREDUCESD = 1536,

        [Symbol("vreducess")]
        VREDUCESS = 1537,

        [Symbol("vrndscalepd")]
        VRNDSCALEPD = 1538,

        [Symbol("vrndscaleps")]
        VRNDSCALEPS = 1539,

        [Symbol("vrndscalesd")]
        VRNDSCALESD = 1540,

        [Symbol("vrndscaless")]
        VRNDSCALESS = 1541,

        [Symbol("vroundpd")]
        VROUNDPD = 1542,

        [Symbol("vroundps")]
        VROUNDPS = 1543,

        [Symbol("vroundsd")]
        VROUNDSD = 1544,

        [Symbol("vroundss")]
        VROUNDSS = 1545,

        [Symbol("vrsqrt14pd")]
        VRSQRT14PD = 1546,

        [Symbol("vrsqrt14ps")]
        VRSQRT14PS = 1547,

        [Symbol("vrsqrt14sd")]
        VRSQRT14SD = 1548,

        [Symbol("vrsqrt14ss")]
        VRSQRT14SS = 1549,

        [Symbol("vrsqrt28pd")]
        VRSQRT28PD = 1550,

        [Symbol("vrsqrt28ps")]
        VRSQRT28PS = 1551,

        [Symbol("vrsqrt28sd")]
        VRSQRT28SD = 1552,

        [Symbol("vrsqrt28ss")]
        VRSQRT28SS = 1553,

        [Symbol("vrsqrtps")]
        VRSQRTPS = 1554,

        [Symbol("vrsqrtss")]
        VRSQRTSS = 1555,

        [Symbol("vscalefpd")]
        VSCALEFPD = 1556,

        [Symbol("vscalefps")]
        VSCALEFPS = 1557,

        [Symbol("vscalefsd")]
        VSCALEFSD = 1558,

        [Symbol("vscalefss")]
        VSCALEFSS = 1559,

        [Symbol("vscatterdpd")]
        VSCATTERDPD = 1560,

        [Symbol("vscatterdps")]
        VSCATTERDPS = 1561,

        [Symbol("vscatterpf0dpd")]
        VSCATTERPF0DPD = 1562,

        [Symbol("vscatterpf0dps")]
        VSCATTERPF0DPS = 1563,

        [Symbol("vscatterpf0qpd")]
        VSCATTERPF0QPD = 1564,

        [Symbol("vscatterpf0qps")]
        VSCATTERPF0QPS = 1565,

        [Symbol("vscatterpf1dpd")]
        VSCATTERPF1DPD = 1566,

        [Symbol("vscatterpf1dps")]
        VSCATTERPF1DPS = 1567,

        [Symbol("vscatterpf1qpd")]
        VSCATTERPF1QPD = 1568,

        [Symbol("vscatterpf1qps")]
        VSCATTERPF1QPS = 1569,

        [Symbol("vscatterqpd")]
        VSCATTERQPD = 1570,

        [Symbol("vscatterqps")]
        VSCATTERQPS = 1571,

        [Symbol("vshuff32x4")]
        VSHUFF32X4 = 1572,

        [Symbol("vshuff64x2")]
        VSHUFF64X2 = 1573,

        [Symbol("vshufi32x4")]
        VSHUFI32X4 = 1574,

        [Symbol("vshufi64x2")]
        VSHUFI64X2 = 1575,

        [Symbol("vshufpd")]
        VSHUFPD = 1576,

        [Symbol("vshufps")]
        VSHUFPS = 1577,

        [Symbol("vsqrtpd")]
        VSQRTPD = 1578,

        [Symbol("vsqrtps")]
        VSQRTPS = 1579,

        [Symbol("vsqrtsd")]
        VSQRTSD = 1580,

        [Symbol("vsqrtss")]
        VSQRTSS = 1581,

        [Symbol("vstmxcsr")]
        VSTMXCSR = 1582,

        [Symbol("vsubpd")]
        VSUBPD = 1583,

        [Symbol("vsubps")]
        VSUBPS = 1584,

        [Symbol("vsubsd")]
        VSUBSD = 1585,

        [Symbol("vsubss")]
        VSUBSS = 1586,

        [Symbol("vtestpd")]
        VTESTPD = 1587,

        [Symbol("vtestps")]
        VTESTPS = 1588,

        [Symbol("vucomisd")]
        VUCOMISD = 1589,

        [Symbol("vucomiss")]
        VUCOMISS = 1590,

        [Symbol("vunpckhpd")]
        VUNPCKHPD = 1591,

        [Symbol("vunpckhps")]
        VUNPCKHPS = 1592,

        [Symbol("vunpcklpd")]
        VUNPCKLPD = 1593,

        [Symbol("vunpcklps")]
        VUNPCKLPS = 1594,

        [Symbol("vxorpd")]
        VXORPD = 1595,

        [Symbol("vxorps")]
        VXORPS = 1596,

        [Symbol("vzeroall")]
        VZEROALL = 1597,

        [Symbol("vzeroupper")]
        VZEROUPPER = 1598,

        [Symbol("wbinvd")]
        WBINVD = 1599,

        [Symbol("wbnoinvd")]
        WBNOINVD = 1600,

        [Symbol("wrfsbase")]
        WRFSBASE = 1601,

        [Symbol("wrgsbase")]
        WRGSBASE = 1602,

        [Symbol("wrmsr")]
        WRMSR = 1603,

        [Symbol("wrpkru")]
        WRPKRU = 1604,

        [Symbol("wrssd")]
        WRSSD = 1605,

        [Symbol("wrssq")]
        WRSSQ = 1606,

        [Symbol("wrussd")]
        WRUSSD = 1607,

        [Symbol("wrussq")]
        WRUSSQ = 1608,

        [Symbol("xabort")]
        XABORT = 1609,

        [Symbol("xadd")]
        XADD = 1610,

        [Symbol("xadd_lock")]
        XADD_LOCK = 1611,

        [Symbol("xbegin")]
        XBEGIN = 1612,

        [Symbol("xchg")]
        XCHG = 1613,

        [Symbol("xend")]
        XEND = 1614,

        [Symbol("xgetbv")]
        XGETBV = 1615,

        [Symbol("xlat")]
        XLAT = 1616,

        [Symbol("xor")]
        XOR = 1617,

        [Symbol("xorpd")]
        XORPD = 1618,

        [Symbol("xorps")]
        XORPS = 1619,

        [Symbol("xor_lock")]
        XOR_LOCK = 1620,

        [Symbol("xresldtrk")]
        XRESLDTRK = 1621,

        [Symbol("xrstor")]
        XRSTOR = 1622,

        [Symbol("xrstor64")]
        XRSTOR64 = 1623,

        [Symbol("xrstors")]
        XRSTORS = 1624,

        [Symbol("xrstors64")]
        XRSTORS64 = 1625,

        [Symbol("xsave")]
        XSAVE = 1626,

        [Symbol("xsave64")]
        XSAVE64 = 1627,

        [Symbol("xsavec")]
        XSAVEC = 1628,

        [Symbol("xsavec64")]
        XSAVEC64 = 1629,

        [Symbol("xsaveopt")]
        XSAVEOPT = 1630,

        [Symbol("xsaveopt64")]
        XSAVEOPT64 = 1631,

        [Symbol("xsaves")]
        XSAVES = 1632,

        [Symbol("xsaves64")]
        XSAVES64 = 1633,

        [Symbol("xsetbv")]
        XSETBV = 1634,

        [Symbol("xstore")]
        XSTORE = 1635,

        [Symbol("xsusldtrk")]
        XSUSLDTRK = 1636,

        [Symbol("xtest")]
        XTEST = 1637,

    }
}
