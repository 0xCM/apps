namespace Z0.Asm
{
    [SymSource("asm")]
    public enum AsmSigId : ushort
    {
    None = 0,
    /// <summary>
    /// adc AL, imm8
    /// </summary>
    [Symbol("adc AL, imm8","adc AL, imm8")]
    adc_AL_imm8 = 1,
    /// <summary>
    /// adc AX, imm16
    /// </summary>
    [Symbol("adc AX, imm16","adc AX, imm16")]
    adc_AX_imm16 = 2,
    /// <summary>
    /// adc EAX, imm32
    /// </summary>
    [Symbol("adc EAX, imm32","adc EAX, imm32")]
    adc_EAX_imm32 = 3,
    /// <summary>
    /// adc r/m16, imm16
    /// </summary>
    [Symbol("adc r16, imm16","adc r/m16, imm16")]
    adc_r16_imm16 = 4,
    /// <summary>
    /// adc r/m16, imm16
    /// </summary>
    [Symbol("adc m16, imm16","adc r/m16, imm16")]
    adc_m16_imm16 = 5,
    /// <summary>
    /// adc r/m16, imm8
    /// </summary>
    [Symbol("adc r16, imm8","adc r/m16, imm8")]
    adc_r16_imm8 = 6,
    /// <summary>
    /// adc r/m16, imm8
    /// </summary>
    [Symbol("adc m16, imm8","adc r/m16, imm8")]
    adc_m16_imm8 = 7,
    /// <summary>
    /// adc r/m16, r16
    /// </summary>
    [Symbol("adc r16, r16","adc r/m16, r16")]
    adc_r16_r16 = 8,
    /// <summary>
    /// adc r/m16, r16
    /// </summary>
    [Symbol("adc m16, r16","adc r/m16, r16")]
    adc_m16_r16 = 9,
    /// <summary>
    /// adc r/m32, imm32
    /// </summary>
    [Symbol("adc r32, imm32","adc r/m32, imm32")]
    adc_r32_imm32 = 10,
    /// <summary>
    /// adc r/m32, imm32
    /// </summary>
    [Symbol("adc m32, imm32","adc r/m32, imm32")]
    adc_m32_imm32 = 11,
    /// <summary>
    /// adc r/m32, imm8
    /// </summary>
    [Symbol("adc r32, imm8","adc r/m32, imm8")]
    adc_r32_imm8 = 12,
    /// <summary>
    /// adc r/m32, imm8
    /// </summary>
    [Symbol("adc m32, imm8","adc r/m32, imm8")]
    adc_m32_imm8 = 13,
    /// <summary>
    /// adc r/m32, r32
    /// </summary>
    [Symbol("adc r32, r32","adc r/m32, r32")]
    adc_r32_r32 = 14,
    /// <summary>
    /// adc r/m32, r32
    /// </summary>
    [Symbol("adc m32, r32","adc r/m32, r32")]
    adc_m32_r32 = 15,
    /// <summary>
    /// adc r/m64, imm32
    /// </summary>
    [Symbol("adc r64, imm32","adc r/m64, imm32")]
    adc_r64_imm32 = 16,
    /// <summary>
    /// adc r/m64, imm32
    /// </summary>
    [Symbol("adc m64, imm32","adc r/m64, imm32")]
    adc_m64_imm32 = 17,
    /// <summary>
    /// adc r/m64, imm8
    /// </summary>
    [Symbol("adc r64, imm8","adc r/m64, imm8")]
    adc_r64_imm8 = 18,
    /// <summary>
    /// adc r/m64, imm8
    /// </summary>
    [Symbol("adc m64, imm8","adc r/m64, imm8")]
    adc_m64_imm8 = 19,
    /// <summary>
    /// adc r/m64, r64
    /// </summary>
    [Symbol("adc r64, r64","adc r/m64, r64")]
    adc_r64_r64 = 20,
    /// <summary>
    /// adc r/m64, r64
    /// </summary>
    [Symbol("adc m64, r64","adc r/m64, r64")]
    adc_m64_r64 = 21,
    /// <summary>
    /// adc r/m8, imm8
    /// </summary>
    [Symbol("adc r8, imm8","adc r/m8, imm8")]
    adc_r8_imm8 = 22,
    /// <summary>
    /// adc r/m8, imm8
    /// </summary>
    [Symbol("adc m8, imm8","adc r/m8, imm8")]
    adc_m8_imm8 = 23,
    /// <summary>
    /// adc r/m8, r8
    /// </summary>
    [Symbol("adc r8, r8","adc r/m8, r8")]
    adc_r8_r8 = 24,
    /// <summary>
    /// adc r/m8, r8
    /// </summary>
    [Symbol("adc m8, r8","adc r/m8, r8")]
    adc_m8_r8 = 25,
    /// <summary>
    /// adc r16, r/m16
    /// </summary>
    [Symbol("adc r16, m16","adc r16, r/m16")]
    adc_r16_m16 = 26,
    /// <summary>
    /// adc r32, r/m32
    /// </summary>
    [Symbol("adc r32, m32","adc r32, r/m32")]
    adc_r32_m32 = 27,
    /// <summary>
    /// adc r64, r/m64
    /// </summary>
    [Symbol("adc r64, m64","adc r64, r/m64")]
    adc_r64_m64 = 28,
    /// <summary>
    /// adc r8, r/m8
    /// </summary>
    [Symbol("adc r8, m8","adc r8, r/m8")]
    adc_r8_m8 = 29,
    /// <summary>
    /// adc RAX, imm32
    /// </summary>
    [Symbol("adc RAX, imm32","adc RAX, imm32")]
    adc_RAX_imm32 = 30,
    /// <summary>
    /// adcx r32, r/m32
    /// </summary>
    [Symbol("adcx r32, r32","adcx r32, r/m32")]
    adcx_r32_r32 = 31,
    /// <summary>
    /// adcx r32, r/m32
    /// </summary>
    [Symbol("adcx r32, m32","adcx r32, r/m32")]
    adcx_r32_m32 = 32,
    /// <summary>
    /// adcx r64, r/m64
    /// </summary>
    [Symbol("adcx r64, r64","adcx r64, r/m64")]
    adcx_r64_r64 = 33,
    /// <summary>
    /// adcx r64, r/m64
    /// </summary>
    [Symbol("adcx r64, m64","adcx r64, r/m64")]
    adcx_r64_m64 = 34,
    /// <summary>
    /// add AL, imm8
    /// </summary>
    [Symbol("add AL, imm8","add AL, imm8")]
    add_AL_imm8 = 35,
    /// <summary>
    /// add AX, imm16
    /// </summary>
    [Symbol("add AX, imm16","add AX, imm16")]
    add_AX_imm16 = 36,
    /// <summary>
    /// add EAX, imm32
    /// </summary>
    [Symbol("add EAX, imm32","add EAX, imm32")]
    add_EAX_imm32 = 37,
    /// <summary>
    /// add r/m16, imm16
    /// </summary>
    [Symbol("add r16, imm16","add r/m16, imm16")]
    add_r16_imm16 = 38,
    /// <summary>
    /// add r/m16, imm16
    /// </summary>
    [Symbol("add m16, imm16","add r/m16, imm16")]
    add_m16_imm16 = 39,
    /// <summary>
    /// add r/m16, imm8
    /// </summary>
    [Symbol("add r16, imm8","add r/m16, imm8")]
    add_r16_imm8 = 40,
    /// <summary>
    /// add r/m16, imm8
    /// </summary>
    [Symbol("add m16, imm8","add r/m16, imm8")]
    add_m16_imm8 = 41,
    /// <summary>
    /// add r/m16, r16
    /// </summary>
    [Symbol("add r16, r16","add r/m16, r16")]
    add_r16_r16 = 42,
    /// <summary>
    /// add r/m16, r16
    /// </summary>
    [Symbol("add m16, r16","add r/m16, r16")]
    add_m16_r16 = 43,
    /// <summary>
    /// add r/m32, imm32
    /// </summary>
    [Symbol("add r32, imm32","add r/m32, imm32")]
    add_r32_imm32 = 44,
    /// <summary>
    /// add r/m32, imm32
    /// </summary>
    [Symbol("add m32, imm32","add r/m32, imm32")]
    add_m32_imm32 = 45,
    /// <summary>
    /// add r/m32, imm8
    /// </summary>
    [Symbol("add r32, imm8","add r/m32, imm8")]
    add_r32_imm8 = 46,
    /// <summary>
    /// add r/m32, imm8
    /// </summary>
    [Symbol("add m32, imm8","add r/m32, imm8")]
    add_m32_imm8 = 47,
    /// <summary>
    /// add r/m32, r32
    /// </summary>
    [Symbol("add r32, r32","add r/m32, r32")]
    add_r32_r32 = 48,
    /// <summary>
    /// add r/m32, r32
    /// </summary>
    [Symbol("add m32, r32","add r/m32, r32")]
    add_m32_r32 = 49,
    /// <summary>
    /// add r/m64, imm32
    /// </summary>
    [Symbol("add r64, imm32","add r/m64, imm32")]
    add_r64_imm32 = 50,
    /// <summary>
    /// add r/m64, imm32
    /// </summary>
    [Symbol("add m64, imm32","add r/m64, imm32")]
    add_m64_imm32 = 51,
    /// <summary>
    /// add r/m64, imm8
    /// </summary>
    [Symbol("add r64, imm8","add r/m64, imm8")]
    add_r64_imm8 = 52,
    /// <summary>
    /// add r/m64, imm8
    /// </summary>
    [Symbol("add m64, imm8","add r/m64, imm8")]
    add_m64_imm8 = 53,
    /// <summary>
    /// add r/m64, r64
    /// </summary>
    [Symbol("add r64, r64","add r/m64, r64")]
    add_r64_r64 = 54,
    /// <summary>
    /// add r/m64, r64
    /// </summary>
    [Symbol("add m64, r64","add r/m64, r64")]
    add_m64_r64 = 55,
    /// <summary>
    /// add r/m8, imm8
    /// </summary>
    [Symbol("add r8, imm8","add r/m8, imm8")]
    add_r8_imm8 = 56,
    /// <summary>
    /// add r/m8, imm8
    /// </summary>
    [Symbol("add m8, imm8","add r/m8, imm8")]
    add_m8_imm8 = 57,
    /// <summary>
    /// add r/m8, r8
    /// </summary>
    [Symbol("add r8, r8","add r/m8, r8")]
    add_r8_r8 = 58,
    /// <summary>
    /// add r/m8, r8
    /// </summary>
    [Symbol("add m8, r8","add r/m8, r8")]
    add_m8_r8 = 59,
    /// <summary>
    /// add r16, r/m16
    /// </summary>
    [Symbol("add r16, m16","add r16, r/m16")]
    add_r16_m16 = 60,
    /// <summary>
    /// add r32, r/m32
    /// </summary>
    [Symbol("add r32, m32","add r32, r/m32")]
    add_r32_m32 = 61,
    /// <summary>
    /// add r64, r/m64
    /// </summary>
    [Symbol("add r64, m64","add r64, r/m64")]
    add_r64_m64 = 62,
    /// <summary>
    /// add r8, r/m8
    /// </summary>
    [Symbol("add r8, m8","add r8, r/m8")]
    add_r8_m8 = 63,
    /// <summary>
    /// add RAX, imm32
    /// </summary>
    [Symbol("add RAX, imm32","add RAX, imm32")]
    add_RAX_imm32 = 64,
    /// <summary>
    /// addpd xmm, xmm/m128
    /// </summary>
    [Symbol("addpd xmm, xmm","addpd xmm, xmm/m128")]
    addpd_xmm_xmm = 65,
    /// <summary>
    /// addpd xmm, xmm/m128
    /// </summary>
    [Symbol("addpd xmm, m128","addpd xmm, xmm/m128")]
    addpd_xmm_m128 = 66,
    /// <summary>
    /// and AL, imm8
    /// </summary>
    [Symbol("and AL, imm8","and AL, imm8")]
    and_AL_imm8 = 67,
    /// <summary>
    /// and AX, imm16
    /// </summary>
    [Symbol("and AX, imm16","and AX, imm16")]
    and_AX_imm16 = 68,
    /// <summary>
    /// and EAX, imm32
    /// </summary>
    [Symbol("and EAX, imm32","and EAX, imm32")]
    and_EAX_imm32 = 69,
    /// <summary>
    /// and r/m16, imm16
    /// </summary>
    [Symbol("and r16, imm16","and r/m16, imm16")]
    and_r16_imm16 = 70,
    /// <summary>
    /// and r/m16, imm16
    /// </summary>
    [Symbol("and m16, imm16","and r/m16, imm16")]
    and_m16_imm16 = 71,
    /// <summary>
    /// and r/m16, imm8
    /// </summary>
    [Symbol("and r16, imm8","and r/m16, imm8")]
    and_r16_imm8 = 72,
    /// <summary>
    /// and r/m16, imm8
    /// </summary>
    [Symbol("and m16, imm8","and r/m16, imm8")]
    and_m16_imm8 = 73,
    /// <summary>
    /// and r/m16, r16
    /// </summary>
    [Symbol("and r16, r16","and r/m16, r16")]
    and_r16_r16 = 74,
    /// <summary>
    /// and r/m16, r16
    /// </summary>
    [Symbol("and m16, r16","and r/m16, r16")]
    and_m16_r16 = 75,
    /// <summary>
    /// and r/m32, imm32
    /// </summary>
    [Symbol("and r32, imm32","and r/m32, imm32")]
    and_r32_imm32 = 76,
    /// <summary>
    /// and r/m32, imm32
    /// </summary>
    [Symbol("and m32, imm32","and r/m32, imm32")]
    and_m32_imm32 = 77,
    /// <summary>
    /// and r/m32, imm8
    /// </summary>
    [Symbol("and r32, imm8","and r/m32, imm8")]
    and_r32_imm8 = 78,
    /// <summary>
    /// and r/m32, imm8
    /// </summary>
    [Symbol("and m32, imm8","and r/m32, imm8")]
    and_m32_imm8 = 79,
    /// <summary>
    /// and r/m32, r32
    /// </summary>
    [Symbol("and r32, r32","and r/m32, r32")]
    and_r32_r32 = 80,
    /// <summary>
    /// and r/m32, r32
    /// </summary>
    [Symbol("and m32, r32","and r/m32, r32")]
    and_m32_r32 = 81,
    /// <summary>
    /// and r/m64, imm32
    /// </summary>
    [Symbol("and r64, imm32","and r/m64, imm32")]
    and_r64_imm32 = 82,
    /// <summary>
    /// and r/m64, imm32
    /// </summary>
    [Symbol("and m64, imm32","and r/m64, imm32")]
    and_m64_imm32 = 83,
    /// <summary>
    /// and r/m64, imm8
    /// </summary>
    [Symbol("and r64, imm8","and r/m64, imm8")]
    and_r64_imm8 = 84,
    /// <summary>
    /// and r/m64, imm8
    /// </summary>
    [Symbol("and m64, imm8","and r/m64, imm8")]
    and_m64_imm8 = 85,
    /// <summary>
    /// and r/m64, r64
    /// </summary>
    [Symbol("and r64, r64","and r/m64, r64")]
    and_r64_r64 = 86,
    /// <summary>
    /// and r/m64, r64
    /// </summary>
    [Symbol("and m64, r64","and r/m64, r64")]
    and_m64_r64 = 87,
    /// <summary>
    /// and r/m8, imm8
    /// </summary>
    [Symbol("and r8, imm8","and r/m8, imm8")]
    and_r8_imm8 = 88,
    /// <summary>
    /// and r/m8, imm8
    /// </summary>
    [Symbol("and m8, imm8","and r/m8, imm8")]
    and_m8_imm8 = 89,
    /// <summary>
    /// and r/m8, r8
    /// </summary>
    [Symbol("and r8, r8","and r/m8, r8")]
    and_r8_r8 = 90,
    /// <summary>
    /// and r/m8, r8
    /// </summary>
    [Symbol("and m8, r8","and r/m8, r8")]
    and_m8_r8 = 91,
    /// <summary>
    /// and r16, r/m16
    /// </summary>
    [Symbol("and r16, m16","and r16, r/m16")]
    and_r16_m16 = 92,
    /// <summary>
    /// and r32, r/m32
    /// </summary>
    [Symbol("and r32, m32","and r32, r/m32")]
    and_r32_m32 = 93,
    /// <summary>
    /// and r64, r/m64
    /// </summary>
    [Symbol("and r64, m64","and r64, r/m64")]
    and_r64_m64 = 94,
    /// <summary>
    /// and r8, r/m8
    /// </summary>
    [Symbol("and r8, m8","and r8, r/m8")]
    and_r8_m8 = 95,
    /// <summary>
    /// and RAX, imm32
    /// </summary>
    [Symbol("and RAX, imm32","and RAX, imm32")]
    and_RAX_imm32 = 96,
    /// <summary>
    /// andn r32, r32, r/m32
    /// </summary>
    [Symbol("andn r32, r32, r32","andn r32, r32, r/m32")]
    andn_r32_r32_r32 = 97,
    /// <summary>
    /// andn r32, r32, r/m32
    /// </summary>
    [Symbol("andn r32, r32, m32","andn r32, r32, r/m32")]
    andn_r32_r32_m32 = 98,
    /// <summary>
    /// andn r64, r64, r/m64
    /// </summary>
    [Symbol("andn r64, r64, r64","andn r64, r64, r/m64")]
    andn_r64_r64_r64 = 99,
    /// <summary>
    /// andn r64, r64, r/m64
    /// </summary>
    [Symbol("andn r64, r64, m64","andn r64, r64, r/m64")]
    andn_r64_r64_m64 = 100,
    /// <summary>
    /// bextr r32, r/m32, r32
    /// </summary>
    [Symbol("bextr r32, r32, r32","bextr r32, r/m32, r32")]
    bextr_r32_r32_r32 = 101,
    /// <summary>
    /// bextr r32, r/m32, r32
    /// </summary>
    [Symbol("bextr r32, m32, r32","bextr r32, r/m32, r32")]
    bextr_r32_m32_r32 = 102,
    /// <summary>
    /// bextr r64, r/m64, r64
    /// </summary>
    [Symbol("bextr r64, r64, r64","bextr r64, r/m64, r64")]
    bextr_r64_r64_r64 = 103,
    /// <summary>
    /// bextr r64, r/m64, r64
    /// </summary>
    [Symbol("bextr r64, m64, r64","bextr r64, r/m64, r64")]
    bextr_r64_m64_r64 = 104,
    /// <summary>
    /// blsi r32, r/m32
    /// </summary>
    [Symbol("blsi r32, r32","blsi r32, r/m32")]
    blsi_r32_r32 = 105,
    /// <summary>
    /// blsi r32, r/m32
    /// </summary>
    [Symbol("blsi r32, m32","blsi r32, r/m32")]
    blsi_r32_m32 = 106,
    /// <summary>
    /// blsi r64, r/m64
    /// </summary>
    [Symbol("blsi r64, r64","blsi r64, r/m64")]
    blsi_r64_r64 = 107,
    /// <summary>
    /// blsi r64, r/m64
    /// </summary>
    [Symbol("blsi r64, m64","blsi r64, r/m64")]
    blsi_r64_m64 = 108,
    /// <summary>
    /// blsmsk r32, r/m32
    /// </summary>
    [Symbol("blsmsk r32, r32","blsmsk r32, r/m32")]
    blsmsk_r32_r32 = 109,
    /// <summary>
    /// blsmsk r32, r/m32
    /// </summary>
    [Symbol("blsmsk r32, m32","blsmsk r32, r/m32")]
    blsmsk_r32_m32 = 110,
    /// <summary>
    /// blsmsk r64, r/m64
    /// </summary>
    [Symbol("blsmsk r64, r64","blsmsk r64, r/m64")]
    blsmsk_r64_r64 = 111,
    /// <summary>
    /// blsmsk r64, r/m64
    /// </summary>
    [Symbol("blsmsk r64, m64","blsmsk r64, r/m64")]
    blsmsk_r64_m64 = 112,
    /// <summary>
    /// blsr r32, r/m32
    /// </summary>
    [Symbol("blsr r32, r32","blsr r32, r/m32")]
    blsr_r32_r32 = 113,
    /// <summary>
    /// blsr r32, r/m32
    /// </summary>
    [Symbol("blsr r32, m32","blsr r32, r/m32")]
    blsr_r32_m32 = 114,
    /// <summary>
    /// blsr r64, r/m64
    /// </summary>
    [Symbol("blsr r64, r64","blsr r64, r/m64")]
    blsr_r64_r64 = 115,
    /// <summary>
    /// blsr r64, r/m64
    /// </summary>
    [Symbol("blsr r64, m64","blsr r64, r/m64")]
    blsr_r64_m64 = 116,
    /// <summary>
    /// bndldx BND, mib
    /// </summary>
    [Symbol("bndldx BND, mib","bndldx BND, mib")]
    bndldx_BND_mib = 117,
    /// <summary>
    /// bndstx mib, BND
    /// </summary>
    [Symbol("bndstx mib, BND","bndstx mib, BND")]
    bndstx_mib_BND = 118,
    /// <summary>
    /// bsf r16, r/m16
    /// </summary>
    [Symbol("bsf r16, r16","bsf r16, r/m16")]
    bsf_r16_r16 = 119,
    /// <summary>
    /// bsf r16, r/m16
    /// </summary>
    [Symbol("bsf r16, m16","bsf r16, r/m16")]
    bsf_r16_m16 = 120,
    /// <summary>
    /// bsf r32, r/m32
    /// </summary>
    [Symbol("bsf r32, r32","bsf r32, r/m32")]
    bsf_r32_r32 = 121,
    /// <summary>
    /// bsf r32, r/m32
    /// </summary>
    [Symbol("bsf r32, m32","bsf r32, r/m32")]
    bsf_r32_m32 = 122,
    /// <summary>
    /// bsf r64, r/m64
    /// </summary>
    [Symbol("bsf r64, r64","bsf r64, r/m64")]
    bsf_r64_r64 = 123,
    /// <summary>
    /// bsf r64, r/m64
    /// </summary>
    [Symbol("bsf r64, m64","bsf r64, r/m64")]
    bsf_r64_m64 = 124,
    /// <summary>
    /// bsr r16, r/m16
    /// </summary>
    [Symbol("bsr r16, r16","bsr r16, r/m16")]
    bsr_r16_r16 = 125,
    /// <summary>
    /// bsr r16, r/m16
    /// </summary>
    [Symbol("bsr r16, m16","bsr r16, r/m16")]
    bsr_r16_m16 = 126,
    /// <summary>
    /// bsr r32, r/m32
    /// </summary>
    [Symbol("bsr r32, r32","bsr r32, r/m32")]
    bsr_r32_r32 = 127,
    /// <summary>
    /// bsr r32, r/m32
    /// </summary>
    [Symbol("bsr r32, m32","bsr r32, r/m32")]
    bsr_r32_m32 = 128,
    /// <summary>
    /// bsr r64, r/m64
    /// </summary>
    [Symbol("bsr r64, r64","bsr r64, r/m64")]
    bsr_r64_r64 = 129,
    /// <summary>
    /// bsr r64, r/m64
    /// </summary>
    [Symbol("bsr r64, m64","bsr r64, r/m64")]
    bsr_r64_m64 = 130,
    /// <summary>
    /// bswap r32
    /// </summary>
    [Symbol("bswap r32","bswap r32")]
    bswap_r32 = 131,
    /// <summary>
    /// bswap r64
    /// </summary>
    [Symbol("bswap r64","bswap r64")]
    bswap_r64 = 132,
    /// <summary>
    /// bt r/m16, imm8
    /// </summary>
    [Symbol("bt r16, imm8","bt r/m16, imm8")]
    bt_r16_imm8 = 133,
    /// <summary>
    /// bt r/m16, imm8
    /// </summary>
    [Symbol("bt m16, imm8","bt r/m16, imm8")]
    bt_m16_imm8 = 134,
    /// <summary>
    /// bt r/m16, r16
    /// </summary>
    [Symbol("bt r16, r16","bt r/m16, r16")]
    bt_r16_r16 = 135,
    /// <summary>
    /// bt r/m16, r16
    /// </summary>
    [Symbol("bt m16, r16","bt r/m16, r16")]
    bt_m16_r16 = 136,
    /// <summary>
    /// bt r/m32, imm8
    /// </summary>
    [Symbol("bt r32, imm8","bt r/m32, imm8")]
    bt_r32_imm8 = 137,
    /// <summary>
    /// bt r/m32, imm8
    /// </summary>
    [Symbol("bt m32, imm8","bt r/m32, imm8")]
    bt_m32_imm8 = 138,
    /// <summary>
    /// bt r/m32, r32
    /// </summary>
    [Symbol("bt r32, r32","bt r/m32, r32")]
    bt_r32_r32 = 139,
    /// <summary>
    /// bt r/m32, r32
    /// </summary>
    [Symbol("bt m32, r32","bt r/m32, r32")]
    bt_m32_r32 = 140,
    /// <summary>
    /// bt r/m64, imm8
    /// </summary>
    [Symbol("bt r64, imm8","bt r/m64, imm8")]
    bt_r64_imm8 = 141,
    /// <summary>
    /// bt r/m64, imm8
    /// </summary>
    [Symbol("bt m64, imm8","bt r/m64, imm8")]
    bt_m64_imm8 = 142,
    /// <summary>
    /// bt r/m64, r64
    /// </summary>
    [Symbol("bt r64, r64","bt r/m64, r64")]
    bt_r64_r64 = 143,
    /// <summary>
    /// bt r/m64, r64
    /// </summary>
    [Symbol("bt m64, r64","bt r/m64, r64")]
    bt_m64_r64 = 144,
    /// <summary>
    /// btc r/m16, imm8
    /// </summary>
    [Symbol("btc r16, imm8","btc r/m16, imm8")]
    btc_r16_imm8 = 145,
    /// <summary>
    /// btc r/m16, imm8
    /// </summary>
    [Symbol("btc m16, imm8","btc r/m16, imm8")]
    btc_m16_imm8 = 146,
    /// <summary>
    /// btc r/m16, r16
    /// </summary>
    [Symbol("btc r16, r16","btc r/m16, r16")]
    btc_r16_r16 = 147,
    /// <summary>
    /// btc r/m16, r16
    /// </summary>
    [Symbol("btc m16, r16","btc r/m16, r16")]
    btc_m16_r16 = 148,
    /// <summary>
    /// btc r/m32, imm8
    /// </summary>
    [Symbol("btc r32, imm8","btc r/m32, imm8")]
    btc_r32_imm8 = 149,
    /// <summary>
    /// btc r/m32, imm8
    /// </summary>
    [Symbol("btc m32, imm8","btc r/m32, imm8")]
    btc_m32_imm8 = 150,
    /// <summary>
    /// btc r/m32, r32
    /// </summary>
    [Symbol("btc r32, r32","btc r/m32, r32")]
    btc_r32_r32 = 151,
    /// <summary>
    /// btc r/m32, r32
    /// </summary>
    [Symbol("btc m32, r32","btc r/m32, r32")]
    btc_m32_r32 = 152,
    /// <summary>
    /// btc r/m64, imm8
    /// </summary>
    [Symbol("btc r64, imm8","btc r/m64, imm8")]
    btc_r64_imm8 = 153,
    /// <summary>
    /// btc r/m64, imm8
    /// </summary>
    [Symbol("btc m64, imm8","btc r/m64, imm8")]
    btc_m64_imm8 = 154,
    /// <summary>
    /// btc r/m64, r64
    /// </summary>
    [Symbol("btc r64, r64","btc r/m64, r64")]
    btc_r64_r64 = 155,
    /// <summary>
    /// btc r/m64, r64
    /// </summary>
    [Symbol("btc m64, r64","btc r/m64, r64")]
    btc_m64_r64 = 156,
    /// <summary>
    /// btr r/m16, imm8
    /// </summary>
    [Symbol("btr r16, imm8","btr r/m16, imm8")]
    btr_r16_imm8 = 157,
    /// <summary>
    /// btr r/m16, imm8
    /// </summary>
    [Symbol("btr m16, imm8","btr r/m16, imm8")]
    btr_m16_imm8 = 158,
    /// <summary>
    /// btr r/m16, r16
    /// </summary>
    [Symbol("btr r16, r16","btr r/m16, r16")]
    btr_r16_r16 = 159,
    /// <summary>
    /// btr r/m16, r16
    /// </summary>
    [Symbol("btr m16, r16","btr r/m16, r16")]
    btr_m16_r16 = 160,
    /// <summary>
    /// btr r/m32, imm8
    /// </summary>
    [Symbol("btr r32, imm8","btr r/m32, imm8")]
    btr_r32_imm8 = 161,
    /// <summary>
    /// btr r/m32, imm8
    /// </summary>
    [Symbol("btr m32, imm8","btr r/m32, imm8")]
    btr_m32_imm8 = 162,
    /// <summary>
    /// btr r/m32, r32
    /// </summary>
    [Symbol("btr r32, r32","btr r/m32, r32")]
    btr_r32_r32 = 163,
    /// <summary>
    /// btr r/m32, r32
    /// </summary>
    [Symbol("btr m32, r32","btr r/m32, r32")]
    btr_m32_r32 = 164,
    /// <summary>
    /// btr r/m64, imm8
    /// </summary>
    [Symbol("btr r64, imm8","btr r/m64, imm8")]
    btr_r64_imm8 = 165,
    /// <summary>
    /// btr r/m64, imm8
    /// </summary>
    [Symbol("btr m64, imm8","btr r/m64, imm8")]
    btr_m64_imm8 = 166,
    /// <summary>
    /// btr r/m64, r64
    /// </summary>
    [Symbol("btr r64, r64","btr r/m64, r64")]
    btr_r64_r64 = 167,
    /// <summary>
    /// btr r/m64, r64
    /// </summary>
    [Symbol("btr m64, r64","btr r/m64, r64")]
    btr_m64_r64 = 168,
    /// <summary>
    /// bts r/m16, imm8
    /// </summary>
    [Symbol("bts r16, imm8","bts r/m16, imm8")]
    bts_r16_imm8 = 169,
    /// <summary>
    /// bts r/m16, imm8
    /// </summary>
    [Symbol("bts m16, imm8","bts r/m16, imm8")]
    bts_m16_imm8 = 170,
    /// <summary>
    /// bts r/m16, r16
    /// </summary>
    [Symbol("bts r16, r16","bts r/m16, r16")]
    bts_r16_r16 = 171,
    /// <summary>
    /// bts r/m16, r16
    /// </summary>
    [Symbol("bts m16, r16","bts r/m16, r16")]
    bts_m16_r16 = 172,
    /// <summary>
    /// bts r/m32, imm8
    /// </summary>
    [Symbol("bts r32, imm8","bts r/m32, imm8")]
    bts_r32_imm8 = 173,
    /// <summary>
    /// bts r/m32, imm8
    /// </summary>
    [Symbol("bts m32, imm8","bts r/m32, imm8")]
    bts_m32_imm8 = 174,
    /// <summary>
    /// bts r/m32, r32
    /// </summary>
    [Symbol("bts r32, r32","bts r/m32, r32")]
    bts_r32_r32 = 175,
    /// <summary>
    /// bts r/m32, r32
    /// </summary>
    [Symbol("bts m32, r32","bts r/m32, r32")]
    bts_m32_r32 = 176,
    /// <summary>
    /// bts r/m64, imm8
    /// </summary>
    [Symbol("bts r64, imm8","bts r/m64, imm8")]
    bts_r64_imm8 = 177,
    /// <summary>
    /// bts r/m64, imm8
    /// </summary>
    [Symbol("bts m64, imm8","bts r/m64, imm8")]
    bts_m64_imm8 = 178,
    /// <summary>
    /// bts r/m64, r64
    /// </summary>
    [Symbol("bts r64, r64","bts r/m64, r64")]
    bts_r64_r64 = 179,
    /// <summary>
    /// bts r/m64, r64
    /// </summary>
    [Symbol("bts m64, r64","bts r/m64, r64")]
    bts_m64_r64 = 180,
    /// <summary>
    /// bzhi r32, r/m32, r32
    /// </summary>
    [Symbol("bzhi r32, r32, r32","bzhi r32, r/m32, r32")]
    bzhi_r32_r32_r32 = 181,
    /// <summary>
    /// bzhi r32, r/m32, r32
    /// </summary>
    [Symbol("bzhi r32, m32, r32","bzhi r32, r/m32, r32")]
    bzhi_r32_m32_r32 = 182,
    /// <summary>
    /// bzhi r64, r/m64, r64
    /// </summary>
    [Symbol("bzhi r64, r64, r64","bzhi r64, r/m64, r64")]
    bzhi_r64_r64_r64 = 183,
    /// <summary>
    /// bzhi r64, r/m64, r64
    /// </summary>
    [Symbol("bzhi r64, m64, r64","bzhi r64, r/m64, r64")]
    bzhi_r64_m64_r64 = 184,
    /// <summary>
    /// call m16:16
    /// </summary>
    [Symbol("call m16:16","call m16:16")]
    call_m16x16 = 185,
    /// <summary>
    /// call m16:32
    /// </summary>
    [Symbol("call m16:32","call m16:32")]
    call_m16x32 = 186,
    /// <summary>
    /// call m16:64
    /// </summary>
    [Symbol("call m16:64","call m16:64")]
    call_m16x64 = 187,
    /// <summary>
    /// call ptr16:16
    /// </summary>
    [Symbol("call ptr16:16","call ptr16:16")]
    call_ptr16x16 = 188,
    /// <summary>
    /// call ptr16:32
    /// </summary>
    [Symbol("call ptr16:32","call ptr16:32")]
    call_ptr16x32 = 189,
    /// <summary>
    /// call r/m16
    /// </summary>
    [Symbol("call r16","call r/m16")]
    call_r16 = 190,
    /// <summary>
    /// call r/m16
    /// </summary>
    [Symbol("call m16","call r/m16")]
    call_m16 = 191,
    /// <summary>
    /// call r/m32
    /// </summary>
    [Symbol("call r32","call r/m32")]
    call_r32 = 192,
    /// <summary>
    /// call r/m32
    /// </summary>
    [Symbol("call m32","call r/m32")]
    call_m32 = 193,
    /// <summary>
    /// call r/m64
    /// </summary>
    [Symbol("call r64","call r/m64")]
    call_r64 = 194,
    /// <summary>
    /// call r/m64
    /// </summary>
    [Symbol("call m64","call r/m64")]
    call_m64 = 195,
    /// <summary>
    /// call rel16
    /// </summary>
    [Symbol("call rel16","call rel16")]
    call_rel16 = 196,
    /// <summary>
    /// call rel32
    /// </summary>
    [Symbol("call rel32","call rel32")]
    call_rel32 = 197,
    /// <summary>
    /// cbw
    /// </summary>
    [Symbol("cbw","cbw")]
    cbw = 198,
    /// <summary>
    /// cdq
    /// </summary>
    [Symbol("cdq","cdq")]
    cdq = 199,
    /// <summary>
    /// cdqe
    /// </summary>
    [Symbol("cdqe","cdqe")]
    cdqe = 200,
    /// <summary>
    /// clc
    /// </summary>
    [Symbol("clc","clc")]
    clc = 201,
    /// <summary>
    /// cli
    /// </summary>
    [Symbol("cli","cli")]
    cli = 202,
    /// <summary>
    /// clts
    /// </summary>
    [Symbol("clts","clts")]
    clts = 203,
    /// <summary>
    /// cmc
    /// </summary>
    [Symbol("cmc","cmc")]
    cmc = 204,
    /// <summary>
    /// cmova r16, r/m16
    /// </summary>
    [Symbol("cmova r16, r16","cmova r16, r/m16")]
    cmova_r16_r16 = 205,
    /// <summary>
    /// cmova r16, r/m16
    /// </summary>
    [Symbol("cmova r16, m16","cmova r16, r/m16")]
    cmova_r16_m16 = 206,
    /// <summary>
    /// cmova r32, r/m32
    /// </summary>
    [Symbol("cmova r32, r32","cmova r32, r/m32")]
    cmova_r32_r32 = 207,
    /// <summary>
    /// cmova r32, r/m32
    /// </summary>
    [Symbol("cmova r32, m32","cmova r32, r/m32")]
    cmova_r32_m32 = 208,
    /// <summary>
    /// cmova r64, r/m64
    /// </summary>
    [Symbol("cmova r64, r64","cmova r64, r/m64")]
    cmova_r64_r64 = 209,
    /// <summary>
    /// cmova r64, r/m64
    /// </summary>
    [Symbol("cmova r64, m64","cmova r64, r/m64")]
    cmova_r64_m64 = 210,
    /// <summary>
    /// cmovae r16, r/m16
    /// </summary>
    [Symbol("cmovae r16, r16","cmovae r16, r/m16")]
    cmovae_r16_r16 = 211,
    /// <summary>
    /// cmovae r16, r/m16
    /// </summary>
    [Symbol("cmovae r16, m16","cmovae r16, r/m16")]
    cmovae_r16_m16 = 212,
    /// <summary>
    /// cmovae r32, r/m32
    /// </summary>
    [Symbol("cmovae r32, r32","cmovae r32, r/m32")]
    cmovae_r32_r32 = 213,
    /// <summary>
    /// cmovae r32, r/m32
    /// </summary>
    [Symbol("cmovae r32, m32","cmovae r32, r/m32")]
    cmovae_r32_m32 = 214,
    /// <summary>
    /// cmovae r64, r/m64
    /// </summary>
    [Symbol("cmovae r64, r64","cmovae r64, r/m64")]
    cmovae_r64_r64 = 215,
    /// <summary>
    /// cmovae r64, r/m64
    /// </summary>
    [Symbol("cmovae r64, m64","cmovae r64, r/m64")]
    cmovae_r64_m64 = 216,
    /// <summary>
    /// cmovb r16, r/m16
    /// </summary>
    [Symbol("cmovb r16, r16","cmovb r16, r/m16")]
    cmovb_r16_r16 = 217,
    /// <summary>
    /// cmovb r16, r/m16
    /// </summary>
    [Symbol("cmovb r16, m16","cmovb r16, r/m16")]
    cmovb_r16_m16 = 218,
    /// <summary>
    /// cmovb r32, r/m32
    /// </summary>
    [Symbol("cmovb r32, r32","cmovb r32, r/m32")]
    cmovb_r32_r32 = 219,
    /// <summary>
    /// cmovb r32, r/m32
    /// </summary>
    [Symbol("cmovb r32, m32","cmovb r32, r/m32")]
    cmovb_r32_m32 = 220,
    /// <summary>
    /// cmovb r64, r/m64
    /// </summary>
    [Symbol("cmovb r64, r64","cmovb r64, r/m64")]
    cmovb_r64_r64 = 221,
    /// <summary>
    /// cmovb r64, r/m64
    /// </summary>
    [Symbol("cmovb r64, m64","cmovb r64, r/m64")]
    cmovb_r64_m64 = 222,
    /// <summary>
    /// cmovbe r16, r/m16
    /// </summary>
    [Symbol("cmovbe r16, r16","cmovbe r16, r/m16")]
    cmovbe_r16_r16 = 223,
    /// <summary>
    /// cmovbe r16, r/m16
    /// </summary>
    [Symbol("cmovbe r16, m16","cmovbe r16, r/m16")]
    cmovbe_r16_m16 = 224,
    /// <summary>
    /// cmovbe r32, r/m32
    /// </summary>
    [Symbol("cmovbe r32, r32","cmovbe r32, r/m32")]
    cmovbe_r32_r32 = 225,
    /// <summary>
    /// cmovbe r32, r/m32
    /// </summary>
    [Symbol("cmovbe r32, m32","cmovbe r32, r/m32")]
    cmovbe_r32_m32 = 226,
    /// <summary>
    /// cmovbe r64, r/m64
    /// </summary>
    [Symbol("cmovbe r64, r64","cmovbe r64, r/m64")]
    cmovbe_r64_r64 = 227,
    /// <summary>
    /// cmovbe r64, r/m64
    /// </summary>
    [Symbol("cmovbe r64, m64","cmovbe r64, r/m64")]
    cmovbe_r64_m64 = 228,
    /// <summary>
    /// cmovc r16, r/m16
    /// </summary>
    [Symbol("cmovc r16, r16","cmovc r16, r/m16")]
    cmovc_r16_r16 = 229,
    /// <summary>
    /// cmovc r16, r/m16
    /// </summary>
    [Symbol("cmovc r16, m16","cmovc r16, r/m16")]
    cmovc_r16_m16 = 230,
    /// <summary>
    /// cmovc r32, r/m32
    /// </summary>
    [Symbol("cmovc r32, r32","cmovc r32, r/m32")]
    cmovc_r32_r32 = 231,
    /// <summary>
    /// cmovc r32, r/m32
    /// </summary>
    [Symbol("cmovc r32, m32","cmovc r32, r/m32")]
    cmovc_r32_m32 = 232,
    /// <summary>
    /// cmovc r64, r/m64
    /// </summary>
    [Symbol("cmovc r64, r64","cmovc r64, r/m64")]
    cmovc_r64_r64 = 233,
    /// <summary>
    /// cmovc r64, r/m64
    /// </summary>
    [Symbol("cmovc r64, m64","cmovc r64, r/m64")]
    cmovc_r64_m64 = 234,
    /// <summary>
    /// cmove r16, r/m16
    /// </summary>
    [Symbol("cmove r16, r16","cmove r16, r/m16")]
    cmove_r16_r16 = 235,
    /// <summary>
    /// cmove r16, r/m16
    /// </summary>
    [Symbol("cmove r16, m16","cmove r16, r/m16")]
    cmove_r16_m16 = 236,
    /// <summary>
    /// cmove r32, r/m32
    /// </summary>
    [Symbol("cmove r32, r32","cmove r32, r/m32")]
    cmove_r32_r32 = 237,
    /// <summary>
    /// cmove r32, r/m32
    /// </summary>
    [Symbol("cmove r32, m32","cmove r32, r/m32")]
    cmove_r32_m32 = 238,
    /// <summary>
    /// cmove r64, r/m64
    /// </summary>
    [Symbol("cmove r64, r64","cmove r64, r/m64")]
    cmove_r64_r64 = 239,
    /// <summary>
    /// cmove r64, r/m64
    /// </summary>
    [Symbol("cmove r64, m64","cmove r64, r/m64")]
    cmove_r64_m64 = 240,
    /// <summary>
    /// cmovg r16, r/m16
    /// </summary>
    [Symbol("cmovg r16, r16","cmovg r16, r/m16")]
    cmovg_r16_r16 = 241,
    /// <summary>
    /// cmovg r16, r/m16
    /// </summary>
    [Symbol("cmovg r16, m16","cmovg r16, r/m16")]
    cmovg_r16_m16 = 242,
    /// <summary>
    /// cmovg r32, r/m32
    /// </summary>
    [Symbol("cmovg r32, r32","cmovg r32, r/m32")]
    cmovg_r32_r32 = 243,
    /// <summary>
    /// cmovg r32, r/m32
    /// </summary>
    [Symbol("cmovg r32, m32","cmovg r32, r/m32")]
    cmovg_r32_m32 = 244,
    /// <summary>
    /// cmovg r64, r/m64
    /// </summary>
    [Symbol("cmovg r64, r64","cmovg r64, r/m64")]
    cmovg_r64_r64 = 245,
    /// <summary>
    /// cmovg r64, r/m64
    /// </summary>
    [Symbol("cmovg r64, m64","cmovg r64, r/m64")]
    cmovg_r64_m64 = 246,
    /// <summary>
    /// cmovge r16, r/m16
    /// </summary>
    [Symbol("cmovge r16, r16","cmovge r16, r/m16")]
    cmovge_r16_r16 = 247,
    /// <summary>
    /// cmovge r16, r/m16
    /// </summary>
    [Symbol("cmovge r16, m16","cmovge r16, r/m16")]
    cmovge_r16_m16 = 248,
    /// <summary>
    /// cmovge r32, r/m32
    /// </summary>
    [Symbol("cmovge r32, r32","cmovge r32, r/m32")]
    cmovge_r32_r32 = 249,
    /// <summary>
    /// cmovge r32, r/m32
    /// </summary>
    [Symbol("cmovge r32, m32","cmovge r32, r/m32")]
    cmovge_r32_m32 = 250,
    /// <summary>
    /// cmovge r64, r/m64
    /// </summary>
    [Symbol("cmovge r64, r64","cmovge r64, r/m64")]
    cmovge_r64_r64 = 251,
    /// <summary>
    /// cmovge r64, r/m64
    /// </summary>
    [Symbol("cmovge r64, m64","cmovge r64, r/m64")]
    cmovge_r64_m64 = 252,
    /// <summary>
    /// cmovl r16, r/m16
    /// </summary>
    [Symbol("cmovl r16, r16","cmovl r16, r/m16")]
    cmovl_r16_r16 = 253,
    /// <summary>
    /// cmovl r16, r/m16
    /// </summary>
    [Symbol("cmovl r16, m16","cmovl r16, r/m16")]
    cmovl_r16_m16 = 254,
    /// <summary>
    /// cmovl r32, r/m32
    /// </summary>
    [Symbol("cmovl r32, r32","cmovl r32, r/m32")]
    cmovl_r32_r32 = 255,
    /// <summary>
    /// cmovl r32, r/m32
    /// </summary>
    [Symbol("cmovl r32, m32","cmovl r32, r/m32")]
    cmovl_r32_m32 = 256,
    /// <summary>
    /// cmovl r64, r/m64
    /// </summary>
    [Symbol("cmovl r64, r64","cmovl r64, r/m64")]
    cmovl_r64_r64 = 257,
    /// <summary>
    /// cmovl r64, r/m64
    /// </summary>
    [Symbol("cmovl r64, m64","cmovl r64, r/m64")]
    cmovl_r64_m64 = 258,
    /// <summary>
    /// cmovle r16, r/m16
    /// </summary>
    [Symbol("cmovle r16, r16","cmovle r16, r/m16")]
    cmovle_r16_r16 = 259,
    /// <summary>
    /// cmovle r16, r/m16
    /// </summary>
    [Symbol("cmovle r16, m16","cmovle r16, r/m16")]
    cmovle_r16_m16 = 260,
    /// <summary>
    /// cmovle r32, r/m32
    /// </summary>
    [Symbol("cmovle r32, r32","cmovle r32, r/m32")]
    cmovle_r32_r32 = 261,
    /// <summary>
    /// cmovle r32, r/m32
    /// </summary>
    [Symbol("cmovle r32, m32","cmovle r32, r/m32")]
    cmovle_r32_m32 = 262,
    /// <summary>
    /// cmovle r64, r/m64
    /// </summary>
    [Symbol("cmovle r64, r64","cmovle r64, r/m64")]
    cmovle_r64_r64 = 263,
    /// <summary>
    /// cmovle r64, r/m64
    /// </summary>
    [Symbol("cmovle r64, m64","cmovle r64, r/m64")]
    cmovle_r64_m64 = 264,
    /// <summary>
    /// cmovna r16, r/m16
    /// </summary>
    [Symbol("cmovna r16, r16","cmovna r16, r/m16")]
    cmovna_r16_r16 = 265,
    /// <summary>
    /// cmovna r16, r/m16
    /// </summary>
    [Symbol("cmovna r16, m16","cmovna r16, r/m16")]
    cmovna_r16_m16 = 266,
    /// <summary>
    /// cmovna r32, r/m32
    /// </summary>
    [Symbol("cmovna r32, r32","cmovna r32, r/m32")]
    cmovna_r32_r32 = 267,
    /// <summary>
    /// cmovna r32, r/m32
    /// </summary>
    [Symbol("cmovna r32, m32","cmovna r32, r/m32")]
    cmovna_r32_m32 = 268,
    /// <summary>
    /// cmovna r64, r/m64
    /// </summary>
    [Symbol("cmovna r64, r64","cmovna r64, r/m64")]
    cmovna_r64_r64 = 269,
    /// <summary>
    /// cmovna r64, r/m64
    /// </summary>
    [Symbol("cmovna r64, m64","cmovna r64, r/m64")]
    cmovna_r64_m64 = 270,
    /// <summary>
    /// cmovnae r16, r/m16
    /// </summary>
    [Symbol("cmovnae r16, r16","cmovnae r16, r/m16")]
    cmovnae_r16_r16 = 271,
    /// <summary>
    /// cmovnae r16, r/m16
    /// </summary>
    [Symbol("cmovnae r16, m16","cmovnae r16, r/m16")]
    cmovnae_r16_m16 = 272,
    /// <summary>
    /// cmovnae r32, r/m32
    /// </summary>
    [Symbol("cmovnae r32, r32","cmovnae r32, r/m32")]
    cmovnae_r32_r32 = 273,
    /// <summary>
    /// cmovnae r32, r/m32
    /// </summary>
    [Symbol("cmovnae r32, m32","cmovnae r32, r/m32")]
    cmovnae_r32_m32 = 274,
    /// <summary>
    /// cmovnae r64, r/m64
    /// </summary>
    [Symbol("cmovnae r64, r64","cmovnae r64, r/m64")]
    cmovnae_r64_r64 = 275,
    /// <summary>
    /// cmovnae r64, r/m64
    /// </summary>
    [Symbol("cmovnae r64, m64","cmovnae r64, r/m64")]
    cmovnae_r64_m64 = 276,
    /// <summary>
    /// cmovnb r16, r/m16
    /// </summary>
    [Symbol("cmovnb r16, r16","cmovnb r16, r/m16")]
    cmovnb_r16_r16 = 277,
    /// <summary>
    /// cmovnb r16, r/m16
    /// </summary>
    [Symbol("cmovnb r16, m16","cmovnb r16, r/m16")]
    cmovnb_r16_m16 = 278,
    /// <summary>
    /// cmovnb r32, r/m32
    /// </summary>
    [Symbol("cmovnb r32, r32","cmovnb r32, r/m32")]
    cmovnb_r32_r32 = 279,
    /// <summary>
    /// cmovnb r32, r/m32
    /// </summary>
    [Symbol("cmovnb r32, m32","cmovnb r32, r/m32")]
    cmovnb_r32_m32 = 280,
    /// <summary>
    /// cmovnb r64, r/m64
    /// </summary>
    [Symbol("cmovnb r64, r64","cmovnb r64, r/m64")]
    cmovnb_r64_r64 = 281,
    /// <summary>
    /// cmovnb r64, r/m64
    /// </summary>
    [Symbol("cmovnb r64, m64","cmovnb r64, r/m64")]
    cmovnb_r64_m64 = 282,
    /// <summary>
    /// cmovnbe r16, r/m16
    /// </summary>
    [Symbol("cmovnbe r16, r16","cmovnbe r16, r/m16")]
    cmovnbe_r16_r16 = 283,
    /// <summary>
    /// cmovnbe r16, r/m16
    /// </summary>
    [Symbol("cmovnbe r16, m16","cmovnbe r16, r/m16")]
    cmovnbe_r16_m16 = 284,
    /// <summary>
    /// cmovnbe r32, r/m32
    /// </summary>
    [Symbol("cmovnbe r32, r32","cmovnbe r32, r/m32")]
    cmovnbe_r32_r32 = 285,
    /// <summary>
    /// cmovnbe r32, r/m32
    /// </summary>
    [Symbol("cmovnbe r32, m32","cmovnbe r32, r/m32")]
    cmovnbe_r32_m32 = 286,
    /// <summary>
    /// cmovnbe r64, r/m64
    /// </summary>
    [Symbol("cmovnbe r64, r64","cmovnbe r64, r/m64")]
    cmovnbe_r64_r64 = 287,
    /// <summary>
    /// cmovnbe r64, r/m64
    /// </summary>
    [Symbol("cmovnbe r64, m64","cmovnbe r64, r/m64")]
    cmovnbe_r64_m64 = 288,
    /// <summary>
    /// cmovnc r16, r/m16
    /// </summary>
    [Symbol("cmovnc r16, r16","cmovnc r16, r/m16")]
    cmovnc_r16_r16 = 289,
    /// <summary>
    /// cmovnc r16, r/m16
    /// </summary>
    [Symbol("cmovnc r16, m16","cmovnc r16, r/m16")]
    cmovnc_r16_m16 = 290,
    /// <summary>
    /// cmovnc r32, r/m32
    /// </summary>
    [Symbol("cmovnc r32, r32","cmovnc r32, r/m32")]
    cmovnc_r32_r32 = 291,
    /// <summary>
    /// cmovnc r32, r/m32
    /// </summary>
    [Symbol("cmovnc r32, m32","cmovnc r32, r/m32")]
    cmovnc_r32_m32 = 292,
    /// <summary>
    /// cmovnc r64, r/m64
    /// </summary>
    [Symbol("cmovnc r64, r64","cmovnc r64, r/m64")]
    cmovnc_r64_r64 = 293,
    /// <summary>
    /// cmovnc r64, r/m64
    /// </summary>
    [Symbol("cmovnc r64, m64","cmovnc r64, r/m64")]
    cmovnc_r64_m64 = 294,
    /// <summary>
    /// cmovne r16, r/m16
    /// </summary>
    [Symbol("cmovne r16, r16","cmovne r16, r/m16")]
    cmovne_r16_r16 = 295,
    /// <summary>
    /// cmovne r16, r/m16
    /// </summary>
    [Symbol("cmovne r16, m16","cmovne r16, r/m16")]
    cmovne_r16_m16 = 296,
    /// <summary>
    /// cmovne r32, r/m32
    /// </summary>
    [Symbol("cmovne r32, r32","cmovne r32, r/m32")]
    cmovne_r32_r32 = 297,
    /// <summary>
    /// cmovne r32, r/m32
    /// </summary>
    [Symbol("cmovne r32, m32","cmovne r32, r/m32")]
    cmovne_r32_m32 = 298,
    /// <summary>
    /// cmovne r64, r/m64
    /// </summary>
    [Symbol("cmovne r64, r64","cmovne r64, r/m64")]
    cmovne_r64_r64 = 299,
    /// <summary>
    /// cmovne r64, r/m64
    /// </summary>
    [Symbol("cmovne r64, m64","cmovne r64, r/m64")]
    cmovne_r64_m64 = 300,
    /// <summary>
    /// cmovng r16, r/m16
    /// </summary>
    [Symbol("cmovng r16, r16","cmovng r16, r/m16")]
    cmovng_r16_r16 = 301,
    /// <summary>
    /// cmovng r16, r/m16
    /// </summary>
    [Symbol("cmovng r16, m16","cmovng r16, r/m16")]
    cmovng_r16_m16 = 302,
    /// <summary>
    /// cmovng r32, r/m32
    /// </summary>
    [Symbol("cmovng r32, r32","cmovng r32, r/m32")]
    cmovng_r32_r32 = 303,
    /// <summary>
    /// cmovng r32, r/m32
    /// </summary>
    [Symbol("cmovng r32, m32","cmovng r32, r/m32")]
    cmovng_r32_m32 = 304,
    /// <summary>
    /// cmovng r64, r/m64
    /// </summary>
    [Symbol("cmovng r64, r64","cmovng r64, r/m64")]
    cmovng_r64_r64 = 305,
    /// <summary>
    /// cmovng r64, r/m64
    /// </summary>
    [Symbol("cmovng r64, m64","cmovng r64, r/m64")]
    cmovng_r64_m64 = 306,
    /// <summary>
    /// cmovnge r16, r/m16
    /// </summary>
    [Symbol("cmovnge r16, r16","cmovnge r16, r/m16")]
    cmovnge_r16_r16 = 307,
    /// <summary>
    /// cmovnge r16, r/m16
    /// </summary>
    [Symbol("cmovnge r16, m16","cmovnge r16, r/m16")]
    cmovnge_r16_m16 = 308,
    /// <summary>
    /// cmovnge r32, r/m32
    /// </summary>
    [Symbol("cmovnge r32, r32","cmovnge r32, r/m32")]
    cmovnge_r32_r32 = 309,
    /// <summary>
    /// cmovnge r32, r/m32
    /// </summary>
    [Symbol("cmovnge r32, m32","cmovnge r32, r/m32")]
    cmovnge_r32_m32 = 310,
    /// <summary>
    /// cmovnge r64, r/m64
    /// </summary>
    [Symbol("cmovnge r64, r64","cmovnge r64, r/m64")]
    cmovnge_r64_r64 = 311,
    /// <summary>
    /// cmovnge r64, r/m64
    /// </summary>
    [Symbol("cmovnge r64, m64","cmovnge r64, r/m64")]
    cmovnge_r64_m64 = 312,
    /// <summary>
    /// cmovnl r16, r/m16
    /// </summary>
    [Symbol("cmovnl r16, r16","cmovnl r16, r/m16")]
    cmovnl_r16_r16 = 313,
    /// <summary>
    /// cmovnl r16, r/m16
    /// </summary>
    [Symbol("cmovnl r16, m16","cmovnl r16, r/m16")]
    cmovnl_r16_m16 = 314,
    /// <summary>
    /// cmovnl r32, r/m32
    /// </summary>
    [Symbol("cmovnl r32, r32","cmovnl r32, r/m32")]
    cmovnl_r32_r32 = 315,
    /// <summary>
    /// cmovnl r32, r/m32
    /// </summary>
    [Symbol("cmovnl r32, m32","cmovnl r32, r/m32")]
    cmovnl_r32_m32 = 316,
    /// <summary>
    /// cmovnl r64, r/m64
    /// </summary>
    [Symbol("cmovnl r64, r64","cmovnl r64, r/m64")]
    cmovnl_r64_r64 = 317,
    /// <summary>
    /// cmovnl r64, r/m64
    /// </summary>
    [Symbol("cmovnl r64, m64","cmovnl r64, r/m64")]
    cmovnl_r64_m64 = 318,
    /// <summary>
    /// cmovnle r16, r/m16
    /// </summary>
    [Symbol("cmovnle r16, r16","cmovnle r16, r/m16")]
    cmovnle_r16_r16 = 319,
    /// <summary>
    /// cmovnle r16, r/m16
    /// </summary>
    [Symbol("cmovnle r16, m16","cmovnle r16, r/m16")]
    cmovnle_r16_m16 = 320,
    /// <summary>
    /// cmovnle r32, r/m32
    /// </summary>
    [Symbol("cmovnle r32, r32","cmovnle r32, r/m32")]
    cmovnle_r32_r32 = 321,
    /// <summary>
    /// cmovnle r32, r/m32
    /// </summary>
    [Symbol("cmovnle r32, m32","cmovnle r32, r/m32")]
    cmovnle_r32_m32 = 322,
    /// <summary>
    /// cmovnle r64, r/m64
    /// </summary>
    [Symbol("cmovnle r64, r64","cmovnle r64, r/m64")]
    cmovnle_r64_r64 = 323,
    /// <summary>
    /// cmovnle r64, r/m64
    /// </summary>
    [Symbol("cmovnle r64, m64","cmovnle r64, r/m64")]
    cmovnle_r64_m64 = 324,
    /// <summary>
    /// cmovno r16, r/m16
    /// </summary>
    [Symbol("cmovno r16, r16","cmovno r16, r/m16")]
    cmovno_r16_r16 = 325,
    /// <summary>
    /// cmovno r16, r/m16
    /// </summary>
    [Symbol("cmovno r16, m16","cmovno r16, r/m16")]
    cmovno_r16_m16 = 326,
    /// <summary>
    /// cmovno r32, r/m32
    /// </summary>
    [Symbol("cmovno r32, r32","cmovno r32, r/m32")]
    cmovno_r32_r32 = 327,
    /// <summary>
    /// cmovno r32, r/m32
    /// </summary>
    [Symbol("cmovno r32, m32","cmovno r32, r/m32")]
    cmovno_r32_m32 = 328,
    /// <summary>
    /// cmovno r64, r/m64
    /// </summary>
    [Symbol("cmovno r64, r64","cmovno r64, r/m64")]
    cmovno_r64_r64 = 329,
    /// <summary>
    /// cmovno r64, r/m64
    /// </summary>
    [Symbol("cmovno r64, m64","cmovno r64, r/m64")]
    cmovno_r64_m64 = 330,
    /// <summary>
    /// cmovnp r16, r/m16
    /// </summary>
    [Symbol("cmovnp r16, r16","cmovnp r16, r/m16")]
    cmovnp_r16_r16 = 331,
    /// <summary>
    /// cmovnp r16, r/m16
    /// </summary>
    [Symbol("cmovnp r16, m16","cmovnp r16, r/m16")]
    cmovnp_r16_m16 = 332,
    /// <summary>
    /// cmovnp r32, r/m32
    /// </summary>
    [Symbol("cmovnp r32, r32","cmovnp r32, r/m32")]
    cmovnp_r32_r32 = 333,
    /// <summary>
    /// cmovnp r32, r/m32
    /// </summary>
    [Symbol("cmovnp r32, m32","cmovnp r32, r/m32")]
    cmovnp_r32_m32 = 334,
    /// <summary>
    /// cmovnp r64, r/m64
    /// </summary>
    [Symbol("cmovnp r64, r64","cmovnp r64, r/m64")]
    cmovnp_r64_r64 = 335,
    /// <summary>
    /// cmovnp r64, r/m64
    /// </summary>
    [Symbol("cmovnp r64, m64","cmovnp r64, r/m64")]
    cmovnp_r64_m64 = 336,
    /// <summary>
    /// cmovns r16, r/m16
    /// </summary>
    [Symbol("cmovns r16, r16","cmovns r16, r/m16")]
    cmovns_r16_r16 = 337,
    /// <summary>
    /// cmovns r16, r/m16
    /// </summary>
    [Symbol("cmovns r16, m16","cmovns r16, r/m16")]
    cmovns_r16_m16 = 338,
    /// <summary>
    /// cmovns r32, r/m32
    /// </summary>
    [Symbol("cmovns r32, r32","cmovns r32, r/m32")]
    cmovns_r32_r32 = 339,
    /// <summary>
    /// cmovns r32, r/m32
    /// </summary>
    [Symbol("cmovns r32, m32","cmovns r32, r/m32")]
    cmovns_r32_m32 = 340,
    /// <summary>
    /// cmovns r64, r/m64
    /// </summary>
    [Symbol("cmovns r64, r64","cmovns r64, r/m64")]
    cmovns_r64_r64 = 341,
    /// <summary>
    /// cmovns r64, r/m64
    /// </summary>
    [Symbol("cmovns r64, m64","cmovns r64, r/m64")]
    cmovns_r64_m64 = 342,
    /// <summary>
    /// cmovnz r16, r/m16
    /// </summary>
    [Symbol("cmovnz r16, r16","cmovnz r16, r/m16")]
    cmovnz_r16_r16 = 343,
    /// <summary>
    /// cmovnz r16, r/m16
    /// </summary>
    [Symbol("cmovnz r16, m16","cmovnz r16, r/m16")]
    cmovnz_r16_m16 = 344,
    /// <summary>
    /// cmovnz r32, r/m32
    /// </summary>
    [Symbol("cmovnz r32, r32","cmovnz r32, r/m32")]
    cmovnz_r32_r32 = 345,
    /// <summary>
    /// cmovnz r32, r/m32
    /// </summary>
    [Symbol("cmovnz r32, m32","cmovnz r32, r/m32")]
    cmovnz_r32_m32 = 346,
    /// <summary>
    /// cmovnz r64, r/m64
    /// </summary>
    [Symbol("cmovnz r64, r64","cmovnz r64, r/m64")]
    cmovnz_r64_r64 = 347,
    /// <summary>
    /// cmovnz r64, r/m64
    /// </summary>
    [Symbol("cmovnz r64, m64","cmovnz r64, r/m64")]
    cmovnz_r64_m64 = 348,
    /// <summary>
    /// cmovo r16, r/m16
    /// </summary>
    [Symbol("cmovo r16, r16","cmovo r16, r/m16")]
    cmovo_r16_r16 = 349,
    /// <summary>
    /// cmovo r16, r/m16
    /// </summary>
    [Symbol("cmovo r16, m16","cmovo r16, r/m16")]
    cmovo_r16_m16 = 350,
    /// <summary>
    /// cmovo r32, r/m32
    /// </summary>
    [Symbol("cmovo r32, r32","cmovo r32, r/m32")]
    cmovo_r32_r32 = 351,
    /// <summary>
    /// cmovo r32, r/m32
    /// </summary>
    [Symbol("cmovo r32, m32","cmovo r32, r/m32")]
    cmovo_r32_m32 = 352,
    /// <summary>
    /// cmovo r64, r/m64
    /// </summary>
    [Symbol("cmovo r64, r64","cmovo r64, r/m64")]
    cmovo_r64_r64 = 353,
    /// <summary>
    /// cmovo r64, r/m64
    /// </summary>
    [Symbol("cmovo r64, m64","cmovo r64, r/m64")]
    cmovo_r64_m64 = 354,
    /// <summary>
    /// cmovp r16, r/m16
    /// </summary>
    [Symbol("cmovp r16, r16","cmovp r16, r/m16")]
    cmovp_r16_r16 = 355,
    /// <summary>
    /// cmovp r16, r/m16
    /// </summary>
    [Symbol("cmovp r16, m16","cmovp r16, r/m16")]
    cmovp_r16_m16 = 356,
    /// <summary>
    /// cmovp r32, r/m32
    /// </summary>
    [Symbol("cmovp r32, r32","cmovp r32, r/m32")]
    cmovp_r32_r32 = 357,
    /// <summary>
    /// cmovp r32, r/m32
    /// </summary>
    [Symbol("cmovp r32, m32","cmovp r32, r/m32")]
    cmovp_r32_m32 = 358,
    /// <summary>
    /// cmovp r64, r/m64
    /// </summary>
    [Symbol("cmovp r64, r64","cmovp r64, r/m64")]
    cmovp_r64_r64 = 359,
    /// <summary>
    /// cmovp r64, r/m64
    /// </summary>
    [Symbol("cmovp r64, m64","cmovp r64, r/m64")]
    cmovp_r64_m64 = 360,
    /// <summary>
    /// cmovpe r16, r/m16
    /// </summary>
    [Symbol("cmovpe r16, r16","cmovpe r16, r/m16")]
    cmovpe_r16_r16 = 361,
    /// <summary>
    /// cmovpe r16, r/m16
    /// </summary>
    [Symbol("cmovpe r16, m16","cmovpe r16, r/m16")]
    cmovpe_r16_m16 = 362,
    /// <summary>
    /// cmovpe r32, r/m32
    /// </summary>
    [Symbol("cmovpe r32, r32","cmovpe r32, r/m32")]
    cmovpe_r32_r32 = 363,
    /// <summary>
    /// cmovpe r32, r/m32
    /// </summary>
    [Symbol("cmovpe r32, m32","cmovpe r32, r/m32")]
    cmovpe_r32_m32 = 364,
    /// <summary>
    /// cmovpe r64, r/m64
    /// </summary>
    [Symbol("cmovpe r64, r64","cmovpe r64, r/m64")]
    cmovpe_r64_r64 = 365,
    /// <summary>
    /// cmovpe r64, r/m64
    /// </summary>
    [Symbol("cmovpe r64, m64","cmovpe r64, r/m64")]
    cmovpe_r64_m64 = 366,
    /// <summary>
    /// cmovpo r16, r/m16
    /// </summary>
    [Symbol("cmovpo r16, r16","cmovpo r16, r/m16")]
    cmovpo_r16_r16 = 367,
    /// <summary>
    /// cmovpo r16, r/m16
    /// </summary>
    [Symbol("cmovpo r16, m16","cmovpo r16, r/m16")]
    cmovpo_r16_m16 = 368,
    /// <summary>
    /// cmovpo r32, r/m32
    /// </summary>
    [Symbol("cmovpo r32, r32","cmovpo r32, r/m32")]
    cmovpo_r32_r32 = 369,
    /// <summary>
    /// cmovpo r32, r/m32
    /// </summary>
    [Symbol("cmovpo r32, m32","cmovpo r32, r/m32")]
    cmovpo_r32_m32 = 370,
    /// <summary>
    /// cmovpo r64, r/m64
    /// </summary>
    [Symbol("cmovpo r64, r64","cmovpo r64, r/m64")]
    cmovpo_r64_r64 = 371,
    /// <summary>
    /// cmovpo r64, r/m64
    /// </summary>
    [Symbol("cmovpo r64, m64","cmovpo r64, r/m64")]
    cmovpo_r64_m64 = 372,
    /// <summary>
    /// cmovs r16, r/m16
    /// </summary>
    [Symbol("cmovs r16, r16","cmovs r16, r/m16")]
    cmovs_r16_r16 = 373,
    /// <summary>
    /// cmovs r16, r/m16
    /// </summary>
    [Symbol("cmovs r16, m16","cmovs r16, r/m16")]
    cmovs_r16_m16 = 374,
    /// <summary>
    /// cmovs r32, r/m32
    /// </summary>
    [Symbol("cmovs r32, r32","cmovs r32, r/m32")]
    cmovs_r32_r32 = 375,
    /// <summary>
    /// cmovs r32, r/m32
    /// </summary>
    [Symbol("cmovs r32, m32","cmovs r32, r/m32")]
    cmovs_r32_m32 = 376,
    /// <summary>
    /// cmovs r64, r/m64
    /// </summary>
    [Symbol("cmovs r64, r64","cmovs r64, r/m64")]
    cmovs_r64_r64 = 377,
    /// <summary>
    /// cmovs r64, r/m64
    /// </summary>
    [Symbol("cmovs r64, m64","cmovs r64, r/m64")]
    cmovs_r64_m64 = 378,
    /// <summary>
    /// cmovz r16, r/m16
    /// </summary>
    [Symbol("cmovz r16, r16","cmovz r16, r/m16")]
    cmovz_r16_r16 = 379,
    /// <summary>
    /// cmovz r16, r/m16
    /// </summary>
    [Symbol("cmovz r16, m16","cmovz r16, r/m16")]
    cmovz_r16_m16 = 380,
    /// <summary>
    /// cmovz r32, r/m32
    /// </summary>
    [Symbol("cmovz r32, r32","cmovz r32, r/m32")]
    cmovz_r32_r32 = 381,
    /// <summary>
    /// cmovz r32, r/m32
    /// </summary>
    [Symbol("cmovz r32, m32","cmovz r32, r/m32")]
    cmovz_r32_m32 = 382,
    /// <summary>
    /// cmovz r64, r/m64
    /// </summary>
    [Symbol("cmovz r64, r64","cmovz r64, r/m64")]
    cmovz_r64_r64 = 383,
    /// <summary>
    /// cmovz r64, r/m64
    /// </summary>
    [Symbol("cmovz r64, m64","cmovz r64, r/m64")]
    cmovz_r64_m64 = 384,
    /// <summary>
    /// cmp AL, imm8
    /// </summary>
    [Symbol("cmp AL, imm8","cmp AL, imm8")]
    cmp_AL_imm8 = 385,
    /// <summary>
    /// cmp AX, imm16
    /// </summary>
    [Symbol("cmp AX, imm16","cmp AX, imm16")]
    cmp_AX_imm16 = 386,
    /// <summary>
    /// cmp EAX, imm32
    /// </summary>
    [Symbol("cmp EAX, imm32","cmp EAX, imm32")]
    cmp_EAX_imm32 = 387,
    /// <summary>
    /// cmp r/m16, imm16
    /// </summary>
    [Symbol("cmp r16, imm16","cmp r/m16, imm16")]
    cmp_r16_imm16 = 388,
    /// <summary>
    /// cmp r/m16, imm16
    /// </summary>
    [Symbol("cmp m16, imm16","cmp r/m16, imm16")]
    cmp_m16_imm16 = 389,
    /// <summary>
    /// cmp r/m16, imm8
    /// </summary>
    [Symbol("cmp r16, imm8","cmp r/m16, imm8")]
    cmp_r16_imm8 = 390,
    /// <summary>
    /// cmp r/m16, imm8
    /// </summary>
    [Symbol("cmp m16, imm8","cmp r/m16, imm8")]
    cmp_m16_imm8 = 391,
    /// <summary>
    /// cmp r/m16, r16
    /// </summary>
    [Symbol("cmp r16, r16","cmp r/m16, r16")]
    cmp_r16_r16 = 392,
    /// <summary>
    /// cmp r/m16, r16
    /// </summary>
    [Symbol("cmp m16, r16","cmp r/m16, r16")]
    cmp_m16_r16 = 393,
    /// <summary>
    /// cmp r/m32, imm32
    /// </summary>
    [Symbol("cmp r32, imm32","cmp r/m32, imm32")]
    cmp_r32_imm32 = 394,
    /// <summary>
    /// cmp r/m32, imm32
    /// </summary>
    [Symbol("cmp m32, imm32","cmp r/m32, imm32")]
    cmp_m32_imm32 = 395,
    /// <summary>
    /// cmp r/m32, imm8
    /// </summary>
    [Symbol("cmp r32, imm8","cmp r/m32, imm8")]
    cmp_r32_imm8 = 396,
    /// <summary>
    /// cmp r/m32, imm8
    /// </summary>
    [Symbol("cmp m32, imm8","cmp r/m32, imm8")]
    cmp_m32_imm8 = 397,
    /// <summary>
    /// cmp r/m32, r32
    /// </summary>
    [Symbol("cmp r32, r32","cmp r/m32, r32")]
    cmp_r32_r32 = 398,
    /// <summary>
    /// cmp r/m32, r32
    /// </summary>
    [Symbol("cmp m32, r32","cmp r/m32, r32")]
    cmp_m32_r32 = 399,
    /// <summary>
    /// cmp r/m64, imm32
    /// </summary>
    [Symbol("cmp r64, imm32","cmp r/m64, imm32")]
    cmp_r64_imm32 = 400,
    /// <summary>
    /// cmp r/m64, imm32
    /// </summary>
    [Symbol("cmp m64, imm32","cmp r/m64, imm32")]
    cmp_m64_imm32 = 401,
    /// <summary>
    /// cmp r/m64, imm8
    /// </summary>
    [Symbol("cmp r64, imm8","cmp r/m64, imm8")]
    cmp_r64_imm8 = 402,
    /// <summary>
    /// cmp r/m64, imm8
    /// </summary>
    [Symbol("cmp m64, imm8","cmp r/m64, imm8")]
    cmp_m64_imm8 = 403,
    /// <summary>
    /// cmp r/m64, r64
    /// </summary>
    [Symbol("cmp r64, r64","cmp r/m64, r64")]
    cmp_r64_r64 = 404,
    /// <summary>
    /// cmp r/m64, r64
    /// </summary>
    [Symbol("cmp m64, r64","cmp r/m64, r64")]
    cmp_m64_r64 = 405,
    /// <summary>
    /// cmp r/m8, imm8
    /// </summary>
    [Symbol("cmp r8, imm8","cmp r/m8, imm8")]
    cmp_r8_imm8 = 406,
    /// <summary>
    /// cmp r/m8, imm8
    /// </summary>
    [Symbol("cmp m8, imm8","cmp r/m8, imm8")]
    cmp_m8_imm8 = 407,
    /// <summary>
    /// cmp r/m8, r8
    /// </summary>
    [Symbol("cmp r8, r8","cmp r/m8, r8")]
    cmp_r8_r8 = 408,
    /// <summary>
    /// cmp r/m8, r8
    /// </summary>
    [Symbol("cmp m8, r8","cmp r/m8, r8")]
    cmp_m8_r8 = 409,
    /// <summary>
    /// cmp r16, r/m16
    /// </summary>
    [Symbol("cmp r16, m16","cmp r16, r/m16")]
    cmp_r16_m16 = 410,
    /// <summary>
    /// cmp r32, r/m32
    /// </summary>
    [Symbol("cmp r32, m32","cmp r32, r/m32")]
    cmp_r32_m32 = 411,
    /// <summary>
    /// cmp r64, r/m64
    /// </summary>
    [Symbol("cmp r64, m64","cmp r64, r/m64")]
    cmp_r64_m64 = 412,
    /// <summary>
    /// cmp r8, r/m8
    /// </summary>
    [Symbol("cmp r8, m8","cmp r8, r/m8")]
    cmp_r8_m8 = 413,
    /// <summary>
    /// cmp RAX, imm32
    /// </summary>
    [Symbol("cmp RAX, imm32","cmp RAX, imm32")]
    cmp_RAX_imm32 = 414,
    /// <summary>
    /// cmpps xmm, xmm/m128, imm8
    /// </summary>
    [Symbol("cmpps xmm, xmm, imm8","cmpps xmm, xmm/m128, imm8")]
    cmpps_xmm_xmm_imm8 = 415,
    /// <summary>
    /// cmpps xmm, xmm/m128, imm8
    /// </summary>
    [Symbol("cmpps xmm, m128, imm8","cmpps xmm, xmm/m128, imm8")]
    cmpps_xmm_m128_imm8 = 416,
    /// <summary>
    /// cmps m16, m16
    /// </summary>
    [Symbol("cmps m16, m16","cmps m16, m16")]
    cmps_m16_m16 = 417,
    /// <summary>
    /// cmps m32, m32
    /// </summary>
    [Symbol("cmps m32, m32","cmps m32, m32")]
    cmps_m32_m32 = 418,
    /// <summary>
    /// cmps m64, m64
    /// </summary>
    [Symbol("cmps m64, m64","cmps m64, m64")]
    cmps_m64_m64 = 419,
    /// <summary>
    /// cmps m8, m8
    /// </summary>
    [Symbol("cmps m8, m8","cmps m8, m8")]
    cmps_m8_m8 = 420,
    /// <summary>
    /// cmpsb
    /// </summary>
    [Symbol("cmpsb","cmpsb")]
    cmpsb = 421,
    /// <summary>
    /// cmpsd
    /// </summary>
    [Symbol("cmpsd","cmpsd")]
    cmpsd = 422,
    /// <summary>
    /// cmpsq
    /// </summary>
    [Symbol("cmpsq","cmpsq")]
    cmpsq = 423,
    /// <summary>
    /// cmpss xmm, xmm/m32, imm8
    /// </summary>
    [Symbol("cmpss xmm, xmm, imm8","cmpss xmm, xmm/m32, imm8")]
    cmpss_xmm_xmm_imm8 = 424,
    /// <summary>
    /// cmpss xmm, xmm/m32, imm8
    /// </summary>
    [Symbol("cmpss xmm, m32, imm8","cmpss xmm, xmm/m32, imm8")]
    cmpss_xmm_m32_imm8 = 425,
    /// <summary>
    /// cmpsw
    /// </summary>
    [Symbol("cmpsw","cmpsw")]
    cmpsw = 426,
    /// <summary>
    /// cmpxchg r/m16, r16
    /// </summary>
    [Symbol("cmpxchg r16, r16","cmpxchg r/m16, r16")]
    cmpxchg_r16_r16 = 427,
    /// <summary>
    /// cmpxchg r/m16, r16
    /// </summary>
    [Symbol("cmpxchg m16, r16","cmpxchg r/m16, r16")]
    cmpxchg_m16_r16 = 428,
    /// <summary>
    /// cmpxchg r/m32, r32
    /// </summary>
    [Symbol("cmpxchg r32, r32","cmpxchg r/m32, r32")]
    cmpxchg_r32_r32 = 429,
    /// <summary>
    /// cmpxchg r/m32, r32
    /// </summary>
    [Symbol("cmpxchg m32, r32","cmpxchg r/m32, r32")]
    cmpxchg_m32_r32 = 430,
    /// <summary>
    /// cmpxchg r/m64, r64
    /// </summary>
    [Symbol("cmpxchg r64, r64","cmpxchg r/m64, r64")]
    cmpxchg_r64_r64 = 431,
    /// <summary>
    /// cmpxchg r/m64, r64
    /// </summary>
    [Symbol("cmpxchg m64, r64","cmpxchg r/m64, r64")]
    cmpxchg_m64_r64 = 432,
    /// <summary>
    /// cmpxchg r/m8, r8
    /// </summary>
    [Symbol("cmpxchg r8, r8","cmpxchg r/m8, r8")]
    cmpxchg_r8_r8 = 433,
    /// <summary>
    /// cmpxchg r/m8, r8
    /// </summary>
    [Symbol("cmpxchg m8, r8","cmpxchg r/m8, r8")]
    cmpxchg_m8_r8 = 434,
    /// <summary>
    /// cmpxchg16b m128
    /// </summary>
    [Symbol("cmpxchg16b m128","cmpxchg16b m128")]
    cmpxchg16b_m128 = 435,
    /// <summary>
    /// cmpxchg8b m64
    /// </summary>
    [Symbol("cmpxchg8b m64","cmpxchg8b m64")]
    cmpxchg8b_m64 = 436,
    /// <summary>
    /// cqo
    /// </summary>
    [Symbol("cqo","cqo")]
    cqo = 437,
    /// <summary>
    /// crc32 r32, r/m16
    /// </summary>
    [Symbol("crc32 r32, r16","crc32 r32, r/m16")]
    crc32_r32_r16 = 438,
    /// <summary>
    /// crc32 r32, r/m16
    /// </summary>
    [Symbol("crc32 r32, m16","crc32 r32, r/m16")]
    crc32_r32_m16 = 439,
    /// <summary>
    /// crc32 r32, r/m32
    /// </summary>
    [Symbol("crc32 r32, r32","crc32 r32, r/m32")]
    crc32_r32_r32 = 440,
    /// <summary>
    /// crc32 r32, r/m32
    /// </summary>
    [Symbol("crc32 r32, m32","crc32 r32, r/m32")]
    crc32_r32_m32 = 441,
    /// <summary>
    /// crc32 r32, r/m8
    /// </summary>
    [Symbol("crc32 r32, r8","crc32 r32, r/m8")]
    crc32_r32_r8 = 442,
    /// <summary>
    /// crc32 r32, r/m8
    /// </summary>
    [Symbol("crc32 r32, m8","crc32 r32, r/m8")]
    crc32_r32_m8 = 443,
    /// <summary>
    /// crc32 r64, r/m64
    /// </summary>
    [Symbol("crc32 r64, r64","crc32 r64, r/m64")]
    crc32_r64_r64 = 444,
    /// <summary>
    /// crc32 r64, r/m64
    /// </summary>
    [Symbol("crc32 r64, m64","crc32 r64, r/m64")]
    crc32_r64_m64 = 445,
    /// <summary>
    /// crc32 r64, r/m8
    /// </summary>
    [Symbol("crc32 r64, r8","crc32 r64, r/m8")]
    crc32_r64_r8 = 446,
    /// <summary>
    /// crc32 r64, r/m8
    /// </summary>
    [Symbol("crc32 r64, m8","crc32 r64, r/m8")]
    crc32_r64_m8 = 447,
    /// <summary>
    /// cwd
    /// </summary>
    [Symbol("cwd","cwd")]
    cwd = 448,
    /// <summary>
    /// cwde
    /// </summary>
    [Symbol("cwde","cwde")]
    cwde = 449,
    /// <summary>
    /// dec r/m16
    /// </summary>
    [Symbol("dec r16","dec r/m16")]
    dec_r16 = 450,
    /// <summary>
    /// dec r/m16
    /// </summary>
    [Symbol("dec m16","dec r/m16")]
    dec_m16 = 451,
    /// <summary>
    /// dec r/m32
    /// </summary>
    [Symbol("dec r32","dec r/m32")]
    dec_r32 = 452,
    /// <summary>
    /// dec r/m32
    /// </summary>
    [Symbol("dec m32","dec r/m32")]
    dec_m32 = 453,
    /// <summary>
    /// dec r/m64
    /// </summary>
    [Symbol("dec r64","dec r/m64")]
    dec_r64 = 454,
    /// <summary>
    /// dec r/m64
    /// </summary>
    [Symbol("dec m64","dec r/m64")]
    dec_m64 = 455,
    /// <summary>
    /// dec r/m8
    /// </summary>
    [Symbol("dec r8","dec r/m8")]
    dec_r8 = 456,
    /// <summary>
    /// dec r/m8
    /// </summary>
    [Symbol("dec m8","dec r/m8")]
    dec_m8 = 457,
    /// <summary>
    /// div r/m16
    /// </summary>
    [Symbol("div r16","div r/m16")]
    div_r16 = 458,
    /// <summary>
    /// div r/m16
    /// </summary>
    [Symbol("div m16","div r/m16")]
    div_m16 = 459,
    /// <summary>
    /// div r/m32
    /// </summary>
    [Symbol("div r32","div r/m32")]
    div_r32 = 460,
    /// <summary>
    /// div r/m32
    /// </summary>
    [Symbol("div m32","div r/m32")]
    div_m32 = 461,
    /// <summary>
    /// div r/m64
    /// </summary>
    [Symbol("div r64","div r/m64")]
    div_r64 = 462,
    /// <summary>
    /// div r/m64
    /// </summary>
    [Symbol("div m64","div r/m64")]
    div_m64 = 463,
    /// <summary>
    /// div r/m8
    /// </summary>
    [Symbol("div r8","div r/m8")]
    div_r8 = 464,
    /// <summary>
    /// div r/m8
    /// </summary>
    [Symbol("div m8","div r/m8")]
    div_m8 = 465,
    /// <summary>
    /// enter imm16, 0
    /// </summary>
    [Symbol("enter imm16, 0","enter imm16, 0")]
    enter_imm16_0 = 466,
    /// <summary>
    /// enter imm16, 1
    /// </summary>
    [Symbol("enter imm16, 1","enter imm16, 1")]
    enter_imm16_1 = 467,
    /// <summary>
    /// enter imm16, imm8
    /// </summary>
    [Symbol("enter imm16, imm8","enter imm16, imm8")]
    enter_imm16_imm8 = 468,
    /// <summary>
    /// hlt
    /// </summary>
    [Symbol("hlt","hlt")]
    hlt = 469,
    /// <summary>
    /// idiv r/m16
    /// </summary>
    [Symbol("idiv r16","idiv r/m16")]
    idiv_r16 = 470,
    /// <summary>
    /// idiv r/m16
    /// </summary>
    [Symbol("idiv m16","idiv r/m16")]
    idiv_m16 = 471,
    /// <summary>
    /// idiv r/m32
    /// </summary>
    [Symbol("idiv r32","idiv r/m32")]
    idiv_r32 = 472,
    /// <summary>
    /// idiv r/m32
    /// </summary>
    [Symbol("idiv m32","idiv r/m32")]
    idiv_m32 = 473,
    /// <summary>
    /// idiv r/m64
    /// </summary>
    [Symbol("idiv r64","idiv r/m64")]
    idiv_r64 = 474,
    /// <summary>
    /// idiv r/m64
    /// </summary>
    [Symbol("idiv m64","idiv r/m64")]
    idiv_m64 = 475,
    /// <summary>
    /// idiv r/m8
    /// </summary>
    [Symbol("idiv r8","idiv r/m8")]
    idiv_r8 = 476,
    /// <summary>
    /// idiv r/m8
    /// </summary>
    [Symbol("idiv m8","idiv r/m8")]
    idiv_m8 = 477,
    /// <summary>
    /// imul r/m16
    /// </summary>
    [Symbol("imul r16","imul r/m16")]
    imul_r16 = 478,
    /// <summary>
    /// imul r/m16
    /// </summary>
    [Symbol("imul m16","imul r/m16")]
    imul_m16 = 479,
    /// <summary>
    /// imul r/m32
    /// </summary>
    [Symbol("imul r32","imul r/m32")]
    imul_r32 = 480,
    /// <summary>
    /// imul r/m32
    /// </summary>
    [Symbol("imul m32","imul r/m32")]
    imul_m32 = 481,
    /// <summary>
    /// imul r/m64
    /// </summary>
    [Symbol("imul r64","imul r/m64")]
    imul_r64 = 482,
    /// <summary>
    /// imul r/m64
    /// </summary>
    [Symbol("imul m64","imul r/m64")]
    imul_m64 = 483,
    /// <summary>
    /// imul r/m8
    /// </summary>
    [Symbol("imul r8","imul r/m8")]
    imul_r8 = 484,
    /// <summary>
    /// imul r/m8
    /// </summary>
    [Symbol("imul m8","imul r/m8")]
    imul_m8 = 485,
    /// <summary>
    /// imul r16, r/m16
    /// </summary>
    [Symbol("imul r16, r16","imul r16, r/m16")]
    imul_r16_r16 = 486,
    /// <summary>
    /// imul r16, r/m16
    /// </summary>
    [Symbol("imul r16, m16","imul r16, r/m16")]
    imul_r16_m16 = 487,
    /// <summary>
    /// imul r16, r/m16, imm16
    /// </summary>
    [Symbol("imul r16, r16, imm16","imul r16, r/m16, imm16")]
    imul_r16_r16_imm16 = 488,
    /// <summary>
    /// imul r16, r/m16, imm16
    /// </summary>
    [Symbol("imul r16, m16, imm16","imul r16, r/m16, imm16")]
    imul_r16_m16_imm16 = 489,
    /// <summary>
    /// imul r16, r/m16, imm8
    /// </summary>
    [Symbol("imul r16, r16, imm8","imul r16, r/m16, imm8")]
    imul_r16_r16_imm8 = 490,
    /// <summary>
    /// imul r16, r/m16, imm8
    /// </summary>
    [Symbol("imul r16, m16, imm8","imul r16, r/m16, imm8")]
    imul_r16_m16_imm8 = 491,
    /// <summary>
    /// imul r32, r/m32
    /// </summary>
    [Symbol("imul r32, r32","imul r32, r/m32")]
    imul_r32_r32 = 492,
    /// <summary>
    /// imul r32, r/m32
    /// </summary>
    [Symbol("imul r32, m32","imul r32, r/m32")]
    imul_r32_m32 = 493,
    /// <summary>
    /// imul r32, r/m32, imm32
    /// </summary>
    [Symbol("imul r32, r32, imm32","imul r32, r/m32, imm32")]
    imul_r32_r32_imm32 = 494,
    /// <summary>
    /// imul r32, r/m32, imm32
    /// </summary>
    [Symbol("imul r32, m32, imm32","imul r32, r/m32, imm32")]
    imul_r32_m32_imm32 = 495,
    /// <summary>
    /// imul r32, r/m32, imm8
    /// </summary>
    [Symbol("imul r32, r32, imm8","imul r32, r/m32, imm8")]
    imul_r32_r32_imm8 = 496,
    /// <summary>
    /// imul r32, r/m32, imm8
    /// </summary>
    [Symbol("imul r32, m32, imm8","imul r32, r/m32, imm8")]
    imul_r32_m32_imm8 = 497,
    /// <summary>
    /// imul r64, r/m64
    /// </summary>
    [Symbol("imul r64, r64","imul r64, r/m64")]
    imul_r64_r64 = 498,
    /// <summary>
    /// imul r64, r/m64
    /// </summary>
    [Symbol("imul r64, m64","imul r64, r/m64")]
    imul_r64_m64 = 499,
    /// <summary>
    /// imul r64, r/m64, imm32
    /// </summary>
    [Symbol("imul r64, r64, imm32","imul r64, r/m64, imm32")]
    imul_r64_r64_imm32 = 500,
    /// <summary>
    /// imul r64, r/m64, imm32
    /// </summary>
    [Symbol("imul r64, m64, imm32","imul r64, r/m64, imm32")]
    imul_r64_m64_imm32 = 501,
    /// <summary>
    /// imul r64, r/m64, imm8
    /// </summary>
    [Symbol("imul r64, r64, imm8","imul r64, r/m64, imm8")]
    imul_r64_r64_imm8 = 502,
    /// <summary>
    /// imul r64, r/m64, imm8
    /// </summary>
    [Symbol("imul r64, m64, imm8","imul r64, r/m64, imm8")]
    imul_r64_m64_imm8 = 503,
    /// <summary>
    /// in AL, DX
    /// </summary>
    [Symbol("in AL, DX","in AL, DX")]
    in_AL_DX = 504,
    /// <summary>
    /// in AL, imm8
    /// </summary>
    [Symbol("in AL, imm8","in AL, imm8")]
    in_AL_imm8 = 505,
    /// <summary>
    /// in AX, DX
    /// </summary>
    [Symbol("in AX, DX","in AX, DX")]
    in_AX_DX = 506,
    /// <summary>
    /// in AX, imm8
    /// </summary>
    [Symbol("in AX, imm8","in AX, imm8")]
    in_AX_imm8 = 507,
    /// <summary>
    /// in EAX, DX
    /// </summary>
    [Symbol("in EAX, DX","in EAX, DX")]
    in_EAX_DX = 508,
    /// <summary>
    /// in EAX, imm8
    /// </summary>
    [Symbol("in EAX, imm8","in EAX, imm8")]
    in_EAX_imm8 = 509,
    /// <summary>
    /// inc r/m16
    /// </summary>
    [Symbol("inc r16","inc r/m16")]
    inc_r16 = 510,
    /// <summary>
    /// inc r/m16
    /// </summary>
    [Symbol("inc m16","inc r/m16")]
    inc_m16 = 511,
    /// <summary>
    /// inc r/m32
    /// </summary>
    [Symbol("inc r32","inc r/m32")]
    inc_r32 = 512,
    /// <summary>
    /// inc r/m32
    /// </summary>
    [Symbol("inc m32","inc r/m32")]
    inc_m32 = 513,
    /// <summary>
    /// inc r/m64
    /// </summary>
    [Symbol("inc r64","inc r/m64")]
    inc_r64 = 514,
    /// <summary>
    /// inc r/m64
    /// </summary>
    [Symbol("inc m64","inc r/m64")]
    inc_m64 = 515,
    /// <summary>
    /// inc r/m8
    /// </summary>
    [Symbol("inc r8","inc r/m8")]
    inc_r8 = 516,
    /// <summary>
    /// inc r/m8
    /// </summary>
    [Symbol("inc m8","inc r/m8")]
    inc_m8 = 517,
    /// <summary>
    /// ins m16, DX
    /// </summary>
    [Symbol("ins m16, DX","ins m16, DX")]
    ins_m16_DX = 518,
    /// <summary>
    /// ins m32, DX
    /// </summary>
    [Symbol("ins m32, DX","ins m32, DX")]
    ins_m32_DX = 519,
    /// <summary>
    /// ins m8, DX
    /// </summary>
    [Symbol("ins m8, DX","ins m8, DX")]
    ins_m8_DX = 520,
    /// <summary>
    /// insb
    /// </summary>
    [Symbol("insb","insb")]
    insb = 521,
    /// <summary>
    /// insd
    /// </summary>
    [Symbol("insd","insd")]
    insd = 522,
    /// <summary>
    /// insw
    /// </summary>
    [Symbol("insw","insw")]
    insw = 523,
    /// <summary>
    /// int imm8
    /// </summary>
    [Symbol("int imm8","int imm8")]
    int_imm8 = 524,
    /// <summary>
    /// int1
    /// </summary>
    [Symbol("int1","int1")]
    int1 = 525,
    /// <summary>
    /// int3
    /// </summary>
    [Symbol("int3","int3")]
    int3 = 526,
    /// <summary>
    /// into
    /// </summary>
    [Symbol("into","into")]
    into = 527,
    /// <summary>
    /// ja rel16
    /// </summary>
    [Symbol("ja rel16","ja rel16")]
    ja_rel16 = 528,
    /// <summary>
    /// ja rel32
    /// </summary>
    [Symbol("ja rel32","ja rel32")]
    ja_rel32 = 529,
    /// <summary>
    /// ja rel8
    /// </summary>
    [Symbol("ja rel8","ja rel8")]
    ja_rel8 = 530,
    /// <summary>
    /// jae rel16
    /// </summary>
    [Symbol("jae rel16","jae rel16")]
    jae_rel16 = 531,
    /// <summary>
    /// jae rel32
    /// </summary>
    [Symbol("jae rel32","jae rel32")]
    jae_rel32 = 532,
    /// <summary>
    /// jae rel8
    /// </summary>
    [Symbol("jae rel8","jae rel8")]
    jae_rel8 = 533,
    /// <summary>
    /// jb rel16
    /// </summary>
    [Symbol("jb rel16","jb rel16")]
    jb_rel16 = 534,
    /// <summary>
    /// jb rel32
    /// </summary>
    [Symbol("jb rel32","jb rel32")]
    jb_rel32 = 535,
    /// <summary>
    /// jb rel8
    /// </summary>
    [Symbol("jb rel8","jb rel8")]
    jb_rel8 = 536,
    /// <summary>
    /// jbe rel16
    /// </summary>
    [Symbol("jbe rel16","jbe rel16")]
    jbe_rel16 = 537,
    /// <summary>
    /// jbe rel32
    /// </summary>
    [Symbol("jbe rel32","jbe rel32")]
    jbe_rel32 = 538,
    /// <summary>
    /// jbe rel8
    /// </summary>
    [Symbol("jbe rel8","jbe rel8")]
    jbe_rel8 = 539,
    /// <summary>
    /// jc rel16
    /// </summary>
    [Symbol("jc rel16","jc rel16")]
    jc_rel16 = 540,
    /// <summary>
    /// jc rel32
    /// </summary>
    [Symbol("jc rel32","jc rel32")]
    jc_rel32 = 541,
    /// <summary>
    /// jc rel8
    /// </summary>
    [Symbol("jc rel8","jc rel8")]
    jc_rel8 = 542,
    /// <summary>
    /// jcxz rel8
    /// </summary>
    [Symbol("jcxz rel8","jcxz rel8")]
    jcxz_rel8 = 543,
    /// <summary>
    /// je rel16
    /// </summary>
    [Symbol("je rel16","je rel16")]
    je_rel16 = 544,
    /// <summary>
    /// je rel32
    /// </summary>
    [Symbol("je rel32","je rel32")]
    je_rel32 = 545,
    /// <summary>
    /// je rel8
    /// </summary>
    [Symbol("je rel8","je rel8")]
    je_rel8 = 546,
    /// <summary>
    /// jecxz rel8
    /// </summary>
    [Symbol("jecxz rel8","jecxz rel8")]
    jecxz_rel8 = 547,
    /// <summary>
    /// jg rel16
    /// </summary>
    [Symbol("jg rel16","jg rel16")]
    jg_rel16 = 548,
    /// <summary>
    /// jg rel32
    /// </summary>
    [Symbol("jg rel32","jg rel32")]
    jg_rel32 = 549,
    /// <summary>
    /// jg rel8
    /// </summary>
    [Symbol("jg rel8","jg rel8")]
    jg_rel8 = 550,
    /// <summary>
    /// jge rel16
    /// </summary>
    [Symbol("jge rel16","jge rel16")]
    jge_rel16 = 551,
    /// <summary>
    /// jge rel32
    /// </summary>
    [Symbol("jge rel32","jge rel32")]
    jge_rel32 = 552,
    /// <summary>
    /// jge rel8
    /// </summary>
    [Symbol("jge rel8","jge rel8")]
    jge_rel8 = 553,
    /// <summary>
    /// jl rel16
    /// </summary>
    [Symbol("jl rel16","jl rel16")]
    jl_rel16 = 554,
    /// <summary>
    /// jl rel32
    /// </summary>
    [Symbol("jl rel32","jl rel32")]
    jl_rel32 = 555,
    /// <summary>
    /// jl rel8
    /// </summary>
    [Symbol("jl rel8","jl rel8")]
    jl_rel8 = 556,
    /// <summary>
    /// jle rel16
    /// </summary>
    [Symbol("jle rel16","jle rel16")]
    jle_rel16 = 557,
    /// <summary>
    /// jle rel32
    /// </summary>
    [Symbol("jle rel32","jle rel32")]
    jle_rel32 = 558,
    /// <summary>
    /// jle rel8
    /// </summary>
    [Symbol("jle rel8","jle rel8")]
    jle_rel8 = 559,
    /// <summary>
    /// jmp m16:16
    /// </summary>
    [Symbol("jmp m16:16","jmp m16:16")]
    jmp_m16x16 = 560,
    /// <summary>
    /// jmp m16:32
    /// </summary>
    [Symbol("jmp m16:32","jmp m16:32")]
    jmp_m16x32 = 561,
    /// <summary>
    /// jmp m16:64
    /// </summary>
    [Symbol("jmp m16:64","jmp m16:64")]
    jmp_m16x64 = 562,
    /// <summary>
    /// jmp ptr16:16
    /// </summary>
    [Symbol("jmp ptr16:16","jmp ptr16:16")]
    jmp_ptr16x16 = 563,
    /// <summary>
    /// jmp ptr16:32
    /// </summary>
    [Symbol("jmp ptr16:32","jmp ptr16:32")]
    jmp_ptr16x32 = 564,
    /// <summary>
    /// jmp r/m16
    /// </summary>
    [Symbol("jmp r16","jmp r/m16")]
    jmp_r16 = 565,
    /// <summary>
    /// jmp r/m16
    /// </summary>
    [Symbol("jmp m16","jmp r/m16")]
    jmp_m16 = 566,
    /// <summary>
    /// jmp r/m32
    /// </summary>
    [Symbol("jmp r32","jmp r/m32")]
    jmp_r32 = 567,
    /// <summary>
    /// jmp r/m32
    /// </summary>
    [Symbol("jmp m32","jmp r/m32")]
    jmp_m32 = 568,
    /// <summary>
    /// jmp r/m64
    /// </summary>
    [Symbol("jmp r64","jmp r/m64")]
    jmp_r64 = 569,
    /// <summary>
    /// jmp r/m64
    /// </summary>
    [Symbol("jmp m64","jmp r/m64")]
    jmp_m64 = 570,
    /// <summary>
    /// jmp rel16
    /// </summary>
    [Symbol("jmp rel16","jmp rel16")]
    jmp_rel16 = 571,
    /// <summary>
    /// jmp rel32
    /// </summary>
    [Symbol("jmp rel32","jmp rel32")]
    jmp_rel32 = 572,
    /// <summary>
    /// jmp rel8
    /// </summary>
    [Symbol("jmp rel8","jmp rel8")]
    jmp_rel8 = 573,
    /// <summary>
    /// jna rel16
    /// </summary>
    [Symbol("jna rel16","jna rel16")]
    jna_rel16 = 574,
    /// <summary>
    /// jna rel32
    /// </summary>
    [Symbol("jna rel32","jna rel32")]
    jna_rel32 = 575,
    /// <summary>
    /// jna rel8
    /// </summary>
    [Symbol("jna rel8","jna rel8")]
    jna_rel8 = 576,
    /// <summary>
    /// jnae rel16
    /// </summary>
    [Symbol("jnae rel16","jnae rel16")]
    jnae_rel16 = 577,
    /// <summary>
    /// jnae rel32
    /// </summary>
    [Symbol("jnae rel32","jnae rel32")]
    jnae_rel32 = 578,
    /// <summary>
    /// jnae rel8
    /// </summary>
    [Symbol("jnae rel8","jnae rel8")]
    jnae_rel8 = 579,
    /// <summary>
    /// jnb rel16
    /// </summary>
    [Symbol("jnb rel16","jnb rel16")]
    jnb_rel16 = 580,
    /// <summary>
    /// jnb rel32
    /// </summary>
    [Symbol("jnb rel32","jnb rel32")]
    jnb_rel32 = 581,
    /// <summary>
    /// jnb rel8
    /// </summary>
    [Symbol("jnb rel8","jnb rel8")]
    jnb_rel8 = 582,
    /// <summary>
    /// jnbe rel16
    /// </summary>
    [Symbol("jnbe rel16","jnbe rel16")]
    jnbe_rel16 = 583,
    /// <summary>
    /// jnbe rel32
    /// </summary>
    [Symbol("jnbe rel32","jnbe rel32")]
    jnbe_rel32 = 584,
    /// <summary>
    /// jnbe rel8
    /// </summary>
    [Symbol("jnbe rel8","jnbe rel8")]
    jnbe_rel8 = 585,
    /// <summary>
    /// jnc rel16
    /// </summary>
    [Symbol("jnc rel16","jnc rel16")]
    jnc_rel16 = 586,
    /// <summary>
    /// jnc rel32
    /// </summary>
    [Symbol("jnc rel32","jnc rel32")]
    jnc_rel32 = 587,
    /// <summary>
    /// jnc rel8
    /// </summary>
    [Symbol("jnc rel8","jnc rel8")]
    jnc_rel8 = 588,
    /// <summary>
    /// jne rel16
    /// </summary>
    [Symbol("jne rel16","jne rel16")]
    jne_rel16 = 589,
    /// <summary>
    /// jne rel32
    /// </summary>
    [Symbol("jne rel32","jne rel32")]
    jne_rel32 = 590,
    /// <summary>
    /// jne rel8
    /// </summary>
    [Symbol("jne rel8","jne rel8")]
    jne_rel8 = 591,
    /// <summary>
    /// jng rel16
    /// </summary>
    [Symbol("jng rel16","jng rel16")]
    jng_rel16 = 592,
    /// <summary>
    /// jng rel32
    /// </summary>
    [Symbol("jng rel32","jng rel32")]
    jng_rel32 = 593,
    /// <summary>
    /// jng rel8
    /// </summary>
    [Symbol("jng rel8","jng rel8")]
    jng_rel8 = 594,
    /// <summary>
    /// jnge rel16
    /// </summary>
    [Symbol("jnge rel16","jnge rel16")]
    jnge_rel16 = 595,
    /// <summary>
    /// jnge rel32
    /// </summary>
    [Symbol("jnge rel32","jnge rel32")]
    jnge_rel32 = 596,
    /// <summary>
    /// jnge rel8
    /// </summary>
    [Symbol("jnge rel8","jnge rel8")]
    jnge_rel8 = 597,
    /// <summary>
    /// jnl rel16
    /// </summary>
    [Symbol("jnl rel16","jnl rel16")]
    jnl_rel16 = 598,
    /// <summary>
    /// jnl rel32
    /// </summary>
    [Symbol("jnl rel32","jnl rel32")]
    jnl_rel32 = 599,
    /// <summary>
    /// jnl rel8
    /// </summary>
    [Symbol("jnl rel8","jnl rel8")]
    jnl_rel8 = 600,
    /// <summary>
    /// jnle rel16
    /// </summary>
    [Symbol("jnle rel16","jnle rel16")]
    jnle_rel16 = 601,
    /// <summary>
    /// jnle rel32
    /// </summary>
    [Symbol("jnle rel32","jnle rel32")]
    jnle_rel32 = 602,
    /// <summary>
    /// jnle rel8
    /// </summary>
    [Symbol("jnle rel8","jnle rel8")]
    jnle_rel8 = 603,
    /// <summary>
    /// jno rel16
    /// </summary>
    [Symbol("jno rel16","jno rel16")]
    jno_rel16 = 604,
    /// <summary>
    /// jno rel32
    /// </summary>
    [Symbol("jno rel32","jno rel32")]
    jno_rel32 = 605,
    /// <summary>
    /// jno rel8
    /// </summary>
    [Symbol("jno rel8","jno rel8")]
    jno_rel8 = 606,
    /// <summary>
    /// jnp rel16
    /// </summary>
    [Symbol("jnp rel16","jnp rel16")]
    jnp_rel16 = 607,
    /// <summary>
    /// jnp rel32
    /// </summary>
    [Symbol("jnp rel32","jnp rel32")]
    jnp_rel32 = 608,
    /// <summary>
    /// jnp rel8
    /// </summary>
    [Symbol("jnp rel8","jnp rel8")]
    jnp_rel8 = 609,
    /// <summary>
    /// jns rel16
    /// </summary>
    [Symbol("jns rel16","jns rel16")]
    jns_rel16 = 610,
    /// <summary>
    /// jns rel32
    /// </summary>
    [Symbol("jns rel32","jns rel32")]
    jns_rel32 = 611,
    /// <summary>
    /// jns rel8
    /// </summary>
    [Symbol("jns rel8","jns rel8")]
    jns_rel8 = 612,
    /// <summary>
    /// jnz rel16
    /// </summary>
    [Symbol("jnz rel16","jnz rel16")]
    jnz_rel16 = 613,
    /// <summary>
    /// jnz rel32
    /// </summary>
    [Symbol("jnz rel32","jnz rel32")]
    jnz_rel32 = 614,
    /// <summary>
    /// jnz rel8
    /// </summary>
    [Symbol("jnz rel8","jnz rel8")]
    jnz_rel8 = 615,
    /// <summary>
    /// jo rel16
    /// </summary>
    [Symbol("jo rel16","jo rel16")]
    jo_rel16 = 616,
    /// <summary>
    /// jo rel32
    /// </summary>
    [Symbol("jo rel32","jo rel32")]
    jo_rel32 = 617,
    /// <summary>
    /// jo rel8
    /// </summary>
    [Symbol("jo rel8","jo rel8")]
    jo_rel8 = 618,
    /// <summary>
    /// jp rel16
    /// </summary>
    [Symbol("jp rel16","jp rel16")]
    jp_rel16 = 619,
    /// <summary>
    /// jp rel32
    /// </summary>
    [Symbol("jp rel32","jp rel32")]
    jp_rel32 = 620,
    /// <summary>
    /// jp rel8
    /// </summary>
    [Symbol("jp rel8","jp rel8")]
    jp_rel8 = 621,
    /// <summary>
    /// jpe rel16
    /// </summary>
    [Symbol("jpe rel16","jpe rel16")]
    jpe_rel16 = 622,
    /// <summary>
    /// jpe rel32
    /// </summary>
    [Symbol("jpe rel32","jpe rel32")]
    jpe_rel32 = 623,
    /// <summary>
    /// jpe rel8
    /// </summary>
    [Symbol("jpe rel8","jpe rel8")]
    jpe_rel8 = 624,
    /// <summary>
    /// jpo rel16
    /// </summary>
    [Symbol("jpo rel16","jpo rel16")]
    jpo_rel16 = 625,
    /// <summary>
    /// jpo rel32
    /// </summary>
    [Symbol("jpo rel32","jpo rel32")]
    jpo_rel32 = 626,
    /// <summary>
    /// jpo rel8
    /// </summary>
    [Symbol("jpo rel8","jpo rel8")]
    jpo_rel8 = 627,
    /// <summary>
    /// jrcxz rel8
    /// </summary>
    [Symbol("jrcxz rel8","jrcxz rel8")]
    jrcxz_rel8 = 628,
    /// <summary>
    /// js rel16
    /// </summary>
    [Symbol("js rel16","js rel16")]
    js_rel16 = 629,
    /// <summary>
    /// js rel32
    /// </summary>
    [Symbol("js rel32","js rel32")]
    js_rel32 = 630,
    /// <summary>
    /// js rel8
    /// </summary>
    [Symbol("js rel8","js rel8")]
    js_rel8 = 631,
    /// <summary>
    /// jz rel16
    /// </summary>
    [Symbol("jz rel16","jz rel16")]
    jz_rel16 = 632,
    /// <summary>
    /// jz rel32
    /// </summary>
    [Symbol("jz rel32","jz rel32")]
    jz_rel32 = 633,
    /// <summary>
    /// jz rel8
    /// </summary>
    [Symbol("jz rel8","jz rel8")]
    jz_rel8 = 634,
    /// <summary>
    /// kaddb k, k, k
    /// </summary>
    [Symbol("kaddb k, k, k","kaddb k, k, k")]
    kaddb_k_k_k = 635,
    /// <summary>
    /// kaddd k, k, k
    /// </summary>
    [Symbol("kaddd k, k, k","kaddd k, k, k")]
    kaddd_k_k_k = 636,
    /// <summary>
    /// kaddq k, k, k
    /// </summary>
    [Symbol("kaddq k, k, k","kaddq k, k, k")]
    kaddq_k_k_k = 637,
    /// <summary>
    /// kaddw k, k, k
    /// </summary>
    [Symbol("kaddw k, k, k","kaddw k, k, k")]
    kaddw_k_k_k = 638,
    /// <summary>
    /// kandb k, k, k
    /// </summary>
    [Symbol("kandb k, k, k","kandb k, k, k")]
    kandb_k_k_k = 639,
    /// <summary>
    /// kandd k, k, k
    /// </summary>
    [Symbol("kandd k, k, k","kandd k, k, k")]
    kandd_k_k_k = 640,
    /// <summary>
    /// kandnb k, k, k
    /// </summary>
    [Symbol("kandnb k, k, k","kandnb k, k, k")]
    kandnb_k_k_k = 641,
    /// <summary>
    /// kandnd k, k, k
    /// </summary>
    [Symbol("kandnd k, k, k","kandnd k, k, k")]
    kandnd_k_k_k = 642,
    /// <summary>
    /// kandnq k, k, k
    /// </summary>
    [Symbol("kandnq k, k, k","kandnq k, k, k")]
    kandnq_k_k_k = 643,
    /// <summary>
    /// kandnw k, k, k
    /// </summary>
    [Symbol("kandnw k, k, k","kandnw k, k, k")]
    kandnw_k_k_k = 644,
    /// <summary>
    /// kandq k, k, k
    /// </summary>
    [Symbol("kandq k, k, k","kandq k, k, k")]
    kandq_k_k_k = 645,
    /// <summary>
    /// kandw k, k, k
    /// </summary>
    [Symbol("kandw k, k, k","kandw k, k, k")]
    kandw_k_k_k = 646,
    /// <summary>
    /// kmovb k, k/m8
    /// </summary>
    [Symbol("kmovb k, k","kmovb k, k/m8")]
    kmovb_k_k = 647,
    /// <summary>
    /// kmovb k, k/m8
    /// </summary>
    [Symbol("kmovb k, m8","kmovb k, k/m8")]
    kmovb_k_m8 = 648,
    /// <summary>
    /// kmovb k, r32
    /// </summary>
    [Symbol("kmovb k, r32","kmovb k, r32")]
    kmovb_k_r32 = 649,
    /// <summary>
    /// kmovb m8, k
    /// </summary>
    [Symbol("kmovb m8, k","kmovb m8, k")]
    kmovb_m8_k = 650,
    /// <summary>
    /// kmovb r32, k
    /// </summary>
    [Symbol("kmovb r32, k","kmovb r32, k")]
    kmovb_r32_k = 651,
    /// <summary>
    /// kmovd k, k/m32
    /// </summary>
    [Symbol("kmovd k, k","kmovd k, k/m32")]
    kmovd_k_k = 652,
    /// <summary>
    /// kmovd k, k/m32
    /// </summary>
    [Symbol("kmovd k, m32","kmovd k, k/m32")]
    kmovd_k_m32 = 653,
    /// <summary>
    /// kmovd k, r32
    /// </summary>
    [Symbol("kmovd k, r32","kmovd k, r32")]
    kmovd_k_r32 = 654,
    /// <summary>
    /// kmovd m32, k
    /// </summary>
    [Symbol("kmovd m32, k","kmovd m32, k")]
    kmovd_m32_k = 655,
    /// <summary>
    /// kmovd r32, k
    /// </summary>
    [Symbol("kmovd r32, k","kmovd r32, k")]
    kmovd_r32_k = 656,
    /// <summary>
    /// kmovq k, k/m64
    /// </summary>
    [Symbol("kmovq k, k","kmovq k, k/m64")]
    kmovq_k_k = 657,
    /// <summary>
    /// kmovq k, k/m64
    /// </summary>
    [Symbol("kmovq k, m64","kmovq k, k/m64")]
    kmovq_k_m64 = 658,
    /// <summary>
    /// kmovq k, r64
    /// </summary>
    [Symbol("kmovq k, r64","kmovq k, r64")]
    kmovq_k_r64 = 659,
    /// <summary>
    /// kmovq m64, k
    /// </summary>
    [Symbol("kmovq m64, k","kmovq m64, k")]
    kmovq_m64_k = 660,
    /// <summary>
    /// kmovq r64, k
    /// </summary>
    [Symbol("kmovq r64, k","kmovq r64, k")]
    kmovq_r64_k = 661,
    /// <summary>
    /// kmovw k, k/m16
    /// </summary>
    [Symbol("kmovw k, k","kmovw k, k/m16")]
    kmovw_k_k = 662,
    /// <summary>
    /// kmovw k, k/m16
    /// </summary>
    [Symbol("kmovw k, m16","kmovw k, k/m16")]
    kmovw_k_m16 = 663,
    /// <summary>
    /// kmovw k, r32
    /// </summary>
    [Symbol("kmovw k, r32","kmovw k, r32")]
    kmovw_k_r32 = 664,
    /// <summary>
    /// kmovw m16, k
    /// </summary>
    [Symbol("kmovw m16, k","kmovw m16, k")]
    kmovw_m16_k = 665,
    /// <summary>
    /// kmovw r32, k
    /// </summary>
    [Symbol("kmovw r32, k","kmovw r32, k")]
    kmovw_r32_k = 666,
    /// <summary>
    /// knotb k, k
    /// </summary>
    [Symbol("knotb k, k","knotb k, k")]
    knotb_k_k = 667,
    /// <summary>
    /// knotd k, k
    /// </summary>
    [Symbol("knotd k, k","knotd k, k")]
    knotd_k_k = 668,
    /// <summary>
    /// knotq k, k
    /// </summary>
    [Symbol("knotq k, k","knotq k, k")]
    knotq_k_k = 669,
    /// <summary>
    /// knotw k, k
    /// </summary>
    [Symbol("knotw k, k","knotw k, k")]
    knotw_k_k = 670,
    /// <summary>
    /// korb k, k, k
    /// </summary>
    [Symbol("korb k, k, k","korb k, k, k")]
    korb_k_k_k = 671,
    /// <summary>
    /// kord k, k, k
    /// </summary>
    [Symbol("kord k, k, k","kord k, k, k")]
    kord_k_k_k = 672,
    /// <summary>
    /// korq k, k, k
    /// </summary>
    [Symbol("korq k, k, k","korq k, k, k")]
    korq_k_k_k = 673,
    /// <summary>
    /// kortestb k, k
    /// </summary>
    [Symbol("kortestb k, k","kortestb k, k")]
    kortestb_k_k = 674,
    /// <summary>
    /// kortestd k, k
    /// </summary>
    [Symbol("kortestd k, k","kortestd k, k")]
    kortestd_k_k = 675,
    /// <summary>
    /// kortestq k, k
    /// </summary>
    [Symbol("kortestq k, k","kortestq k, k")]
    kortestq_k_k = 676,
    /// <summary>
    /// kortestw k, k
    /// </summary>
    [Symbol("kortestw k, k","kortestw k, k")]
    kortestw_k_k = 677,
    /// <summary>
    /// korw k, k, k
    /// </summary>
    [Symbol("korw k, k, k","korw k, k, k")]
    korw_k_k_k = 678,
    /// <summary>
    /// kshiftlb k, k, imm8
    /// </summary>
    [Symbol("kshiftlb k, k, imm8","kshiftlb k, k, imm8")]
    kshiftlb_k_k_imm8 = 679,
    /// <summary>
    /// kshiftld k, k, imm8
    /// </summary>
    [Symbol("kshiftld k, k, imm8","kshiftld k, k, imm8")]
    kshiftld_k_k_imm8 = 680,
    /// <summary>
    /// kshiftlq k, k, imm8
    /// </summary>
    [Symbol("kshiftlq k, k, imm8","kshiftlq k, k, imm8")]
    kshiftlq_k_k_imm8 = 681,
    /// <summary>
    /// kshiftlw k, k, imm8
    /// </summary>
    [Symbol("kshiftlw k, k, imm8","kshiftlw k, k, imm8")]
    kshiftlw_k_k_imm8 = 682,
    /// <summary>
    /// kshiftrb k, k, imm8
    /// </summary>
    [Symbol("kshiftrb k, k, imm8","kshiftrb k, k, imm8")]
    kshiftrb_k_k_imm8 = 683,
    /// <summary>
    /// kshiftrd k, k, imm8
    /// </summary>
    [Symbol("kshiftrd k, k, imm8","kshiftrd k, k, imm8")]
    kshiftrd_k_k_imm8 = 684,
    /// <summary>
    /// kshiftrq k, k, imm8
    /// </summary>
    [Symbol("kshiftrq k, k, imm8","kshiftrq k, k, imm8")]
    kshiftrq_k_k_imm8 = 685,
    /// <summary>
    /// kshiftrw k, k, imm8
    /// </summary>
    [Symbol("kshiftrw k, k, imm8","kshiftrw k, k, imm8")]
    kshiftrw_k_k_imm8 = 686,
    /// <summary>
    /// ktestb k, k
    /// </summary>
    [Symbol("ktestb k, k","ktestb k, k")]
    ktestb_k_k = 687,
    /// <summary>
    /// ktestd k, k
    /// </summary>
    [Symbol("ktestd k, k","ktestd k, k")]
    ktestd_k_k = 688,
    /// <summary>
    /// ktestq k, k
    /// </summary>
    [Symbol("ktestq k, k","ktestq k, k")]
    ktestq_k_k = 689,
    /// <summary>
    /// ktestw k, k
    /// </summary>
    [Symbol("ktestw k, k","ktestw k, k")]
    ktestw_k_k = 690,
    /// <summary>
    /// kunpckbw k, k, k
    /// </summary>
    [Symbol("kunpckbw k, k, k","kunpckbw k, k, k")]
    kunpckbw_k_k_k = 691,
    /// <summary>
    /// kunpckdq k, k, k
    /// </summary>
    [Symbol("kunpckdq k, k, k","kunpckdq k, k, k")]
    kunpckdq_k_k_k = 692,
    /// <summary>
    /// kunpckwd k, k, k
    /// </summary>
    [Symbol("kunpckwd k, k, k","kunpckwd k, k, k")]
    kunpckwd_k_k_k = 693,
    /// <summary>
    /// kxnorb k, k, k
    /// </summary>
    [Symbol("kxnorb k, k, k","kxnorb k, k, k")]
    kxnorb_k_k_k = 694,
    /// <summary>
    /// kxnord k, k, k
    /// </summary>
    [Symbol("kxnord k, k, k","kxnord k, k, k")]
    kxnord_k_k_k = 695,
    /// <summary>
    /// kxnorq k, k, k
    /// </summary>
    [Symbol("kxnorq k, k, k","kxnorq k, k, k")]
    kxnorq_k_k_k = 696,
    /// <summary>
    /// kxnorw k, k, k
    /// </summary>
    [Symbol("kxnorw k, k, k","kxnorw k, k, k")]
    kxnorw_k_k_k = 697,
    /// <summary>
    /// kxorb k, k, k
    /// </summary>
    [Symbol("kxorb k, k, k","kxorb k, k, k")]
    kxorb_k_k_k = 698,
    /// <summary>
    /// kxord k, k, k
    /// </summary>
    [Symbol("kxord k, k, k","kxord k, k, k")]
    kxord_k_k_k = 699,
    /// <summary>
    /// kxorq k, k, k
    /// </summary>
    [Symbol("kxorq k, k, k","kxorq k, k, k")]
    kxorq_k_k_k = 700,
    /// <summary>
    /// kxorw k, k, k
    /// </summary>
    [Symbol("kxorw k, k, k","kxorw k, k, k")]
    kxorw_k_k_k = 701,
    /// <summary>
    /// lddqu xmm, mem
    /// </summary>
    [Symbol("lddqu xmm, mem","lddqu xmm, mem")]
    lddqu_xmm_mem = 702,
    /// <summary>
    /// lds r16, m16:16
    /// </summary>
    [Symbol("lds r16, m16:16","lds r16, m16:16")]
    lds_r16_m16x16 = 703,
    /// <summary>
    /// lds r32, m16:32
    /// </summary>
    [Symbol("lds r32, m16:32","lds r32, m16:32")]
    lds_r32_m16x32 = 704,
    /// <summary>
    /// lea r16, m
    /// </summary>
    [Symbol("lea r16, m","lea r16, m")]
    lea_r16_m = 705,
    /// <summary>
    /// lea r32, m
    /// </summary>
    [Symbol("lea r32, m","lea r32, m")]
    lea_r32_m = 706,
    /// <summary>
    /// lea r64, m
    /// </summary>
    [Symbol("lea r64, m","lea r64, m")]
    lea_r64_m = 707,
    /// <summary>
    /// leave
    /// </summary>
    [Symbol("leave","leave")]
    leave = 708,
    /// <summary>
    /// les r16, m16:16
    /// </summary>
    [Symbol("les r16, m16:16","les r16, m16:16")]
    les_r16_m16x16 = 709,
    /// <summary>
    /// les r32, m16:32
    /// </summary>
    [Symbol("les r32, m16:32","les r32, m16:32")]
    les_r32_m16x32 = 710,
    /// <summary>
    /// lfs r16, m16:16
    /// </summary>
    [Symbol("lfs r16, m16:16","lfs r16, m16:16")]
    lfs_r16_m16x16 = 711,
    /// <summary>
    /// lfs r32, m16:32
    /// </summary>
    [Symbol("lfs r32, m16:32","lfs r32, m16:32")]
    lfs_r32_m16x32 = 712,
    /// <summary>
    /// lfs r64, m16:64
    /// </summary>
    [Symbol("lfs r64, m16:64","lfs r64, m16:64")]
    lfs_r64_m16x64 = 713,
    /// <summary>
    /// lgdt m16&32
    /// </summary>
    [Symbol("lgdt m16&32","lgdt m16&32")]
    lgdt_m16a32 = 714,
    /// <summary>
    /// lgdt m16&64
    /// </summary>
    [Symbol("lgdt m16&64","lgdt m16&64")]
    lgdt_m16a64 = 715,
    /// <summary>
    /// lgs r16, m16:16
    /// </summary>
    [Symbol("lgs r16, m16:16","lgs r16, m16:16")]
    lgs_r16_m16x16 = 716,
    /// <summary>
    /// lgs r32, m16:32
    /// </summary>
    [Symbol("lgs r32, m16:32","lgs r32, m16:32")]
    lgs_r32_m16x32 = 717,
    /// <summary>
    /// lgs r64, m16:64
    /// </summary>
    [Symbol("lgs r64, m16:64","lgs r64, m16:64")]
    lgs_r64_m16x64 = 718,
    /// <summary>
    /// lidt m16&32
    /// </summary>
    [Symbol("lidt m16&32","lidt m16&32")]
    lidt_m16a32 = 719,
    /// <summary>
    /// lidt m16&64
    /// </summary>
    [Symbol("lidt m16&64","lidt m16&64")]
    lidt_m16a64 = 720,
    /// <summary>
    /// lldt r/m16
    /// </summary>
    [Symbol("lldt r16","lldt r/m16")]
    lldt_r16 = 721,
    /// <summary>
    /// lldt r/m16
    /// </summary>
    [Symbol("lldt m16","lldt r/m16")]
    lldt_m16 = 722,
    /// <summary>
    /// lmsw r/m16
    /// </summary>
    [Symbol("lmsw r16","lmsw r/m16")]
    lmsw_r16 = 723,
    /// <summary>
    /// lmsw r/m16
    /// </summary>
    [Symbol("lmsw m16","lmsw r/m16")]
    lmsw_m16 = 724,
    /// <summary>
    /// lock
    /// </summary>
    [Symbol("lock","lock")]
    @lock = 725,
    /// <summary>
    /// lods m16
    /// </summary>
    [Symbol("lods m16","lods m16")]
    lods_m16 = 726,
    /// <summary>
    /// lods m32
    /// </summary>
    [Symbol("lods m32","lods m32")]
    lods_m32 = 727,
    /// <summary>
    /// lods m64
    /// </summary>
    [Symbol("lods m64","lods m64")]
    lods_m64 = 728,
    /// <summary>
    /// lods m8
    /// </summary>
    [Symbol("lods m8","lods m8")]
    lods_m8 = 729,
    /// <summary>
    /// lodsb
    /// </summary>
    [Symbol("lodsb","lodsb")]
    lodsb = 730,
    /// <summary>
    /// lodsd
    /// </summary>
    [Symbol("lodsd","lodsd")]
    lodsd = 731,
    /// <summary>
    /// lodsq
    /// </summary>
    [Symbol("lodsq","lodsq")]
    lodsq = 732,
    /// <summary>
    /// lodsw
    /// </summary>
    [Symbol("lodsw","lodsw")]
    lodsw = 733,
    /// <summary>
    /// loop rel8
    /// </summary>
    [Symbol("loop rel8","loop rel8")]
    loop_rel8 = 734,
    /// <summary>
    /// loope rel8
    /// </summary>
    [Symbol("loope rel8","loope rel8")]
    loope_rel8 = 735,
    /// <summary>
    /// loopne rel8
    /// </summary>
    [Symbol("loopne rel8","loopne rel8")]
    loopne_rel8 = 736,
    /// <summary>
    /// lsl r16, r16/m16
    /// </summary>
    [Symbol("lsl r16, r16","lsl r16, r16/m16")]
    lsl_r16_r16 = 737,
    /// <summary>
    /// lsl r16, r16/m16
    /// </summary>
    [Symbol("lsl r16, m16","lsl r16, r16/m16")]
    lsl_r16_m16 = 738,
    /// <summary>
    /// lsl r32, r32/m16
    /// </summary>
    [Symbol("lsl r32, r32","lsl r32, r32/m16")]
    lsl_r32_r32 = 739,
    /// <summary>
    /// lsl r32, r32/m16
    /// </summary>
    [Symbol("lsl r32, m16","lsl r32, r32/m16")]
    lsl_r32_m16 = 740,
    /// <summary>
    /// lsl r64, r32/m16
    /// </summary>
    [Symbol("lsl r64, r32","lsl r64, r32/m16")]
    lsl_r64_r32 = 741,
    /// <summary>
    /// lsl r64, r32/m16
    /// </summary>
    [Symbol("lsl r64, m16","lsl r64, r32/m16")]
    lsl_r64_m16 = 742,
    /// <summary>
    /// lss r16, m16:16
    /// </summary>
    [Symbol("lss r16, m16:16","lss r16, m16:16")]
    lss_r16_m16x16 = 743,
    /// <summary>
    /// lss r32, m16:32
    /// </summary>
    [Symbol("lss r32, m16:32","lss r32, m16:32")]
    lss_r32_m16x32 = 744,
    /// <summary>
    /// lss r64, m16:64
    /// </summary>
    [Symbol("lss r64, m16:64","lss r64, m16:64")]
    lss_r64_m16x64 = 745,
    /// <summary>
    /// maskmovdqu xmm, xmm
    /// </summary>
    [Symbol("maskmovdqu xmm, xmm","maskmovdqu xmm, xmm")]
    maskmovdqu_xmm_xmm = 746,
    /// <summary>
    /// maskmovq mm, mm
    /// </summary>
    [Symbol("maskmovq mm, mm","maskmovq mm, mm")]
    maskmovq_mm_mm = 747,
    /// <summary>
    /// mov AL, moffs8
    /// </summary>
    [Symbol("mov AL, moffs8","mov AL, moffs8")]
    mov_AL_moffs8 = 748,
    /// <summary>
    /// mov AX, moffs16
    /// </summary>
    [Symbol("mov AX, moffs16","mov AX, moffs16")]
    mov_AX_moffs16 = 749,
    /// <summary>
    /// mov CR, r32
    /// </summary>
    [Symbol("mov CR, r32","mov CR, r32")]
    mov_CR_r32 = 750,
    /// <summary>
    /// mov CR, r64
    /// </summary>
    [Symbol("mov CR, r64","mov CR, r64")]
    mov_CR_r64 = 751,
    /// <summary>
    /// mov CR8, r64
    /// </summary>
    [Symbol("mov CR8, r64","mov CR8, r64")]
    mov_CR8_r64 = 752,
    /// <summary>
    /// mov DR, r32
    /// </summary>
    [Symbol("mov DR, r32","mov DR, r32")]
    mov_DR_r32 = 753,
    /// <summary>
    /// mov DR, r64
    /// </summary>
    [Symbol("mov DR, r64","mov DR, r64")]
    mov_DR_r64 = 754,
    /// <summary>
    /// mov EAX, moffs32
    /// </summary>
    [Symbol("mov EAX, moffs32","mov EAX, moffs32")]
    mov_EAX_moffs32 = 755,
    /// <summary>
    /// mov moffs16, AX
    /// </summary>
    [Symbol("mov moffs16, AX","mov moffs16, AX")]
    mov_moffs16_AX = 756,
    /// <summary>
    /// mov moffs32, EAX
    /// </summary>
    [Symbol("mov moffs32, EAX","mov moffs32, EAX")]
    mov_moffs32_EAX = 757,
    /// <summary>
    /// mov moffs64, RAX
    /// </summary>
    [Symbol("mov moffs64, RAX","mov moffs64, RAX")]
    mov_moffs64_RAX = 758,
    /// <summary>
    /// mov moffs8, AL
    /// </summary>
    [Symbol("mov moffs8, AL","mov moffs8, AL")]
    mov_moffs8_AL = 759,
    /// <summary>
    /// mov r/m16, imm16
    /// </summary>
    [Symbol("mov r16, imm16","mov r/m16, imm16")]
    mov_r16_imm16 = 760,
    /// <summary>
    /// mov r/m16, imm16
    /// </summary>
    [Symbol("mov m16, imm16","mov r/m16, imm16")]
    mov_m16_imm16 = 761,
    /// <summary>
    /// mov r/m16, r16
    /// </summary>
    [Symbol("mov r16, r16","mov r/m16, r16")]
    mov_r16_r16 = 762,
    /// <summary>
    /// mov r/m16, r16
    /// </summary>
    [Symbol("mov m16, r16","mov r/m16, r16")]
    mov_m16_r16 = 763,
    /// <summary>
    /// mov r/m16, Sreg
    /// </summary>
    [Symbol("mov r16, Sreg","mov r/m16, Sreg")]
    mov_r16_Sreg = 764,
    /// <summary>
    /// mov r/m16, Sreg
    /// </summary>
    [Symbol("mov m16, Sreg","mov r/m16, Sreg")]
    mov_m16_Sreg = 765,
    /// <summary>
    /// mov r/m32, imm32
    /// </summary>
    [Symbol("mov r32, imm32","mov r/m32, imm32")]
    mov_r32_imm32 = 766,
    /// <summary>
    /// mov r/m32, imm32
    /// </summary>
    [Symbol("mov m32, imm32","mov r/m32, imm32")]
    mov_m32_imm32 = 767,
    /// <summary>
    /// mov r/m32, r32
    /// </summary>
    [Symbol("mov r32, r32","mov r/m32, r32")]
    mov_r32_r32 = 768,
    /// <summary>
    /// mov r/m32, r32
    /// </summary>
    [Symbol("mov m32, r32","mov r/m32, r32")]
    mov_m32_r32 = 769,
    /// <summary>
    /// mov r/m64, imm32
    /// </summary>
    [Symbol("mov r64, imm32","mov r/m64, imm32")]
    mov_r64_imm32 = 770,
    /// <summary>
    /// mov r/m64, imm32
    /// </summary>
    [Symbol("mov m64, imm32","mov r/m64, imm32")]
    mov_m64_imm32 = 771,
    /// <summary>
    /// mov r/m64, r64
    /// </summary>
    [Symbol("mov r64, r64","mov r/m64, r64")]
    mov_r64_r64 = 772,
    /// <summary>
    /// mov r/m64, r64
    /// </summary>
    [Symbol("mov m64, r64","mov r/m64, r64")]
    mov_m64_r64 = 773,
    /// <summary>
    /// mov r/m8, imm8
    /// </summary>
    [Symbol("mov r8, imm8","mov r/m8, imm8")]
    mov_r8_imm8 = 774,
    /// <summary>
    /// mov r/m8, imm8
    /// </summary>
    [Symbol("mov m8, imm8","mov r/m8, imm8")]
    mov_m8_imm8 = 775,
    /// <summary>
    /// mov r/m8, r8
    /// </summary>
    [Symbol("mov r8, r8","mov r/m8, r8")]
    mov_r8_r8 = 776,
    /// <summary>
    /// mov r/m8, r8
    /// </summary>
    [Symbol("mov m8, r8","mov r/m8, r8")]
    mov_m8_r8 = 777,
    /// <summary>
    /// mov r16, r/m16
    /// </summary>
    [Symbol("mov r16, m16","mov r16, r/m16")]
    mov_r16_m16 = 778,
    /// <summary>
    /// mov r16/r32/m16, Sreg
    /// </summary>
    [Symbol("mov r32, Sreg","mov r16/r32/m16, Sreg")]
    mov_r32_Sreg = 779,
    /// <summary>
    /// mov r32, CR
    /// </summary>
    [Symbol("mov r32, CR","mov r32, CR")]
    mov_r32_CR = 780,
    /// <summary>
    /// mov r32, DR
    /// </summary>
    [Symbol("mov r32, DR","mov r32, DR")]
    mov_r32_DR = 781,
    /// <summary>
    /// mov r32, r/m32
    /// </summary>
    [Symbol("mov r32, m32","mov r32, r/m32")]
    mov_r32_m32 = 782,
    /// <summary>
    /// mov r64, CR
    /// </summary>
    [Symbol("mov r64, CR","mov r64, CR")]
    mov_r64_CR = 783,
    /// <summary>
    /// mov r64, CR8
    /// </summary>
    [Symbol("mov r64, CR8","mov r64, CR8")]
    mov_r64_CR8 = 784,
    /// <summary>
    /// mov r64, DR
    /// </summary>
    [Symbol("mov r64, DR","mov r64, DR")]
    mov_r64_DR = 785,
    /// <summary>
    /// mov r64, imm64
    /// </summary>
    [Symbol("mov r64, imm64","mov r64, imm64")]
    mov_r64_imm64 = 786,
    /// <summary>
    /// mov r64, r/m64
    /// </summary>
    [Symbol("mov r64, m64","mov r64, r/m64")]
    mov_r64_m64 = 787,
    /// <summary>
    /// mov r64/m16, Sreg
    /// </summary>
    [Symbol("mov r64, Sreg","mov r64/m16, Sreg")]
    mov_r64_Sreg = 788,
    /// <summary>
    /// mov r8, r/m8
    /// </summary>
    [Symbol("mov r8, m8","mov r8, r/m8")]
    mov_r8_m8 = 789,
    /// <summary>
    /// mov RAX, moffs64
    /// </summary>
    [Symbol("mov RAX, moffs64","mov RAX, moffs64")]
    mov_RAX_moffs64 = 790,
    /// <summary>
    /// mov Sreg, r/m16
    /// </summary>
    [Symbol("mov Sreg, r16","mov Sreg, r/m16")]
    mov_Sreg_r16 = 791,
    /// <summary>
    /// mov Sreg, r/m16
    /// </summary>
    [Symbol("mov Sreg, m16","mov Sreg, r/m16")]
    mov_Sreg_m16 = 792,
    /// <summary>
    /// mov Sreg, r/m64
    /// </summary>
    [Symbol("mov Sreg, r64","mov Sreg, r/m64")]
    mov_Sreg_r64 = 793,
    /// <summary>
    /// mov Sreg, r/m64
    /// </summary>
    [Symbol("mov Sreg, m64","mov Sreg, r/m64")]
    mov_Sreg_m64 = 794,
    /// <summary>
    /// movapd xmm, xmm/m128
    /// </summary>
    [Symbol("movapd xmm, xmm","movapd xmm, xmm/m128")]
    movapd_xmm_xmm = 795,
    /// <summary>
    /// movapd xmm, xmm/m128
    /// </summary>
    [Symbol("movapd xmm, m128","movapd xmm, xmm/m128")]
    movapd_xmm_m128 = 796,
    /// <summary>
    /// movapd xmm/m128, xmm
    /// </summary>
    [Symbol("movapd m128, xmm","movapd xmm/m128, xmm")]
    movapd_m128_xmm = 797,
    /// <summary>
    /// movaps xmm, xmm/m128
    /// </summary>
    [Symbol("movaps xmm, xmm","movaps xmm, xmm/m128")]
    movaps_xmm_xmm = 798,
    /// <summary>
    /// movaps xmm, xmm/m128
    /// </summary>
    [Symbol("movaps xmm, m128","movaps xmm, xmm/m128")]
    movaps_xmm_m128 = 799,
    /// <summary>
    /// movaps xmm/m128, xmm
    /// </summary>
    [Symbol("movaps m128, xmm","movaps xmm/m128, xmm")]
    movaps_m128_xmm = 800,
    /// <summary>
    /// movd mm, r/m32
    /// </summary>
    [Symbol("movd mm, r32","movd mm, r/m32")]
    movd_mm_r32 = 801,
    /// <summary>
    /// movd mm, r/m32
    /// </summary>
    [Symbol("movd mm, m32","movd mm, r/m32")]
    movd_mm_m32 = 802,
    /// <summary>
    /// movd r/m32, mm
    /// </summary>
    [Symbol("movd r32, mm","movd r/m32, mm")]
    movd_r32_mm = 803,
    /// <summary>
    /// movd r/m32, mm
    /// </summary>
    [Symbol("movd m32, mm","movd r/m32, mm")]
    movd_m32_mm = 804,
    /// <summary>
    /// movd r/m32, xmm
    /// </summary>
    [Symbol("movd r32, xmm","movd r/m32, xmm")]
    movd_r32_xmm = 805,
    /// <summary>
    /// movd r/m32, xmm
    /// </summary>
    [Symbol("movd m32, xmm","movd r/m32, xmm")]
    movd_m32_xmm = 806,
    /// <summary>
    /// movd xmm, r/m32
    /// </summary>
    [Symbol("movd xmm, r32","movd xmm, r/m32")]
    movd_xmm_r32 = 807,
    /// <summary>
    /// movd xmm, r/m32
    /// </summary>
    [Symbol("movd xmm, m32","movd xmm, r/m32")]
    movd_xmm_m32 = 808,
    /// <summary>
    /// movdir64b r16/r32/r64, m512
    /// </summary>
    [Symbol("movdir64b r16, m512","movdir64b r16/r32/r64, m512")]
    movdir64b_r16_m512 = 809,
    /// <summary>
    /// movdir64b r16/r32/r64, m512
    /// </summary>
    [Symbol("movdir64b r32, m512","movdir64b r16/r32/r64, m512")]
    movdir64b_r32_m512 = 810,
    /// <summary>
    /// movdir64b r16/r32/r64, m512
    /// </summary>
    [Symbol("movdir64b r64, m512","movdir64b r16/r32/r64, m512")]
    movdir64b_r64_m512 = 811,
    /// <summary>
    /// movdqa xmm, xmm/m128
    /// </summary>
    [Symbol("movdqa xmm, xmm","movdqa xmm, xmm/m128")]
    movdqa_xmm_xmm = 812,
    /// <summary>
    /// movdqa xmm, xmm/m128
    /// </summary>
    [Symbol("movdqa xmm, m128","movdqa xmm, xmm/m128")]
    movdqa_xmm_m128 = 813,
    /// <summary>
    /// movdqa xmm/m128, xmm
    /// </summary>
    [Symbol("movdqa m128, xmm","movdqa xmm/m128, xmm")]
    movdqa_m128_xmm = 814,
    /// <summary>
    /// movdqu xmm, xmm/m128
    /// </summary>
    [Symbol("movdqu xmm, xmm","movdqu xmm, xmm/m128")]
    movdqu_xmm_xmm = 815,
    /// <summary>
    /// movdqu xmm, xmm/m128
    /// </summary>
    [Symbol("movdqu xmm, m128","movdqu xmm, xmm/m128")]
    movdqu_xmm_m128 = 816,
    /// <summary>
    /// movdqu xmm/m128, xmm
    /// </summary>
    [Symbol("movdqu m128, xmm","movdqu xmm/m128, xmm")]
    movdqu_m128_xmm = 817,
    /// <summary>
    /// movq mm, mm/m64
    /// </summary>
    [Symbol("movq mm, mm","movq mm, mm/m64")]
    movq_mm_mm = 818,
    /// <summary>
    /// movq mm, mm/m64
    /// </summary>
    [Symbol("movq mm, m64","movq mm, mm/m64")]
    movq_mm_m64 = 819,
    /// <summary>
    /// movq mm, r/m64
    /// </summary>
    [Symbol("movq mm, r64","movq mm, r/m64")]
    movq_mm_r64 = 820,
    /// <summary>
    /// movq mm/m64, mm
    /// </summary>
    [Symbol("movq m64, mm","movq mm/m64, mm")]
    movq_m64_mm = 821,
    /// <summary>
    /// movq r/m64, mm
    /// </summary>
    [Symbol("movq r64, mm","movq r/m64, mm")]
    movq_r64_mm = 822,
    /// <summary>
    /// movq r/m64, xmm
    /// </summary>
    [Symbol("movq r64, xmm","movq r/m64, xmm")]
    movq_r64_xmm = 823,
    /// <summary>
    /// movq r/m64, xmm
    /// </summary>
    [Symbol("movq m64, xmm","movq r/m64, xmm")]
    movq_m64_xmm = 824,
    /// <summary>
    /// movq xmm, r/m64
    /// </summary>
    [Symbol("movq xmm, r64","movq xmm, r/m64")]
    movq_xmm_r64 = 825,
    /// <summary>
    /// movq xmm, r/m64
    /// </summary>
    [Symbol("movq xmm, m64","movq xmm, r/m64")]
    movq_xmm_m64 = 826,
    /// <summary>
    /// movq xmm, xmm/m64
    /// </summary>
    [Symbol("movq xmm, xmm","movq xmm, xmm/m64")]
    movq_xmm_xmm = 827,
    /// <summary>
    /// movs m16, m16
    /// </summary>
    [Symbol("movs m16, m16","movs m16, m16")]
    movs_m16_m16 = 828,
    /// <summary>
    /// movs m32, m32
    /// </summary>
    [Symbol("movs m32, m32","movs m32, m32")]
    movs_m32_m32 = 829,
    /// <summary>
    /// movs m64, m64
    /// </summary>
    [Symbol("movs m64, m64","movs m64, m64")]
    movs_m64_m64 = 830,
    /// <summary>
    /// movs m8, m8
    /// </summary>
    [Symbol("movs m8, m8","movs m8, m8")]
    movs_m8_m8 = 831,
    /// <summary>
    /// movsb
    /// </summary>
    [Symbol("movsb","movsb")]
    movsb = 832,
    /// <summary>
    /// movsd
    /// </summary>
    [Symbol("movsd","movsd")]
    movsd = 833,
    /// <summary>
    /// movsq
    /// </summary>
    [Symbol("movsq","movsq")]
    movsq = 834,
    /// <summary>
    /// movsw
    /// </summary>
    [Symbol("movsw","movsw")]
    movsw = 835,
    /// <summary>
    /// movsx r16, r/m8
    /// </summary>
    [Symbol("movsx r16, r8","movsx r16, r/m8")]
    movsx_r16_r8 = 836,
    /// <summary>
    /// movsx r16, r/m8
    /// </summary>
    [Symbol("movsx r16, m8","movsx r16, r/m8")]
    movsx_r16_m8 = 837,
    /// <summary>
    /// movsx r32, r/m16
    /// </summary>
    [Symbol("movsx r32, r16","movsx r32, r/m16")]
    movsx_r32_r16 = 838,
    /// <summary>
    /// movsx r32, r/m16
    /// </summary>
    [Symbol("movsx r32, m16","movsx r32, r/m16")]
    movsx_r32_m16 = 839,
    /// <summary>
    /// movsx r32, r/m8
    /// </summary>
    [Symbol("movsx r32, r8","movsx r32, r/m8")]
    movsx_r32_r8 = 840,
    /// <summary>
    /// movsx r32, r/m8
    /// </summary>
    [Symbol("movsx r32, m8","movsx r32, r/m8")]
    movsx_r32_m8 = 841,
    /// <summary>
    /// movsx r64, r/m16
    /// </summary>
    [Symbol("movsx r64, r16","movsx r64, r/m16")]
    movsx_r64_r16 = 842,
    /// <summary>
    /// movsx r64, r/m16
    /// </summary>
    [Symbol("movsx r64, m16","movsx r64, r/m16")]
    movsx_r64_m16 = 843,
    /// <summary>
    /// movsx r64, r/m8
    /// </summary>
    [Symbol("movsx r64, r8","movsx r64, r/m8")]
    movsx_r64_r8 = 844,
    /// <summary>
    /// movsx r64, r/m8
    /// </summary>
    [Symbol("movsx r64, m8","movsx r64, r/m8")]
    movsx_r64_m8 = 845,
    /// <summary>
    /// movsxd r16, r/m16
    /// </summary>
    [Symbol("movsxd r16, r16","movsxd r16, r/m16")]
    movsxd_r16_r16 = 846,
    /// <summary>
    /// movsxd r16, r/m16
    /// </summary>
    [Symbol("movsxd r16, m16","movsxd r16, r/m16")]
    movsxd_r16_m16 = 847,
    /// <summary>
    /// movsxd r32, r/m32
    /// </summary>
    [Symbol("movsxd r32, r32","movsxd r32, r/m32")]
    movsxd_r32_r32 = 848,
    /// <summary>
    /// movsxd r32, r/m32
    /// </summary>
    [Symbol("movsxd r32, m32","movsxd r32, r/m32")]
    movsxd_r32_m32 = 849,
    /// <summary>
    /// movsxd r64, r/m32
    /// </summary>
    [Symbol("movsxd r64, r32","movsxd r64, r/m32")]
    movsxd_r64_r32 = 850,
    /// <summary>
    /// movsxd r64, r/m32
    /// </summary>
    [Symbol("movsxd r64, m32","movsxd r64, r/m32")]
    movsxd_r64_m32 = 851,
    /// <summary>
    /// movupd xmm, xmm/m128
    /// </summary>
    [Symbol("movupd xmm, xmm","movupd xmm, xmm/m128")]
    movupd_xmm_xmm = 852,
    /// <summary>
    /// movupd xmm, xmm/m128
    /// </summary>
    [Symbol("movupd xmm, m128","movupd xmm, xmm/m128")]
    movupd_xmm_m128 = 853,
    /// <summary>
    /// movupd xmm/m128, xmm
    /// </summary>
    [Symbol("movupd m128, xmm","movupd xmm/m128, xmm")]
    movupd_m128_xmm = 854,
    /// <summary>
    /// movzx r16, r/m8
    /// </summary>
    [Symbol("movzx r16, r8","movzx r16, r/m8")]
    movzx_r16_r8 = 855,
    /// <summary>
    /// movzx r16, r/m8
    /// </summary>
    [Symbol("movzx r16, m8","movzx r16, r/m8")]
    movzx_r16_m8 = 856,
    /// <summary>
    /// movzx r32, r/m16
    /// </summary>
    [Symbol("movzx r32, r16","movzx r32, r/m16")]
    movzx_r32_r16 = 857,
    /// <summary>
    /// movzx r32, r/m16
    /// </summary>
    [Symbol("movzx r32, m16","movzx r32, r/m16")]
    movzx_r32_m16 = 858,
    /// <summary>
    /// movzx r32, r/m8
    /// </summary>
    [Symbol("movzx r32, r8","movzx r32, r/m8")]
    movzx_r32_r8 = 859,
    /// <summary>
    /// movzx r32, r/m8
    /// </summary>
    [Symbol("movzx r32, m8","movzx r32, r/m8")]
    movzx_r32_m8 = 860,
    /// <summary>
    /// movzx r64, r/m16
    /// </summary>
    [Symbol("movzx r64, r16","movzx r64, r/m16")]
    movzx_r64_r16 = 861,
    /// <summary>
    /// movzx r64, r/m16
    /// </summary>
    [Symbol("movzx r64, m16","movzx r64, r/m16")]
    movzx_r64_m16 = 862,
    /// <summary>
    /// movzx r64, r/m8
    /// </summary>
    [Symbol("movzx r64, r8","movzx r64, r/m8")]
    movzx_r64_r8 = 863,
    /// <summary>
    /// movzx r64, r/m8
    /// </summary>
    [Symbol("movzx r64, m8","movzx r64, r/m8")]
    movzx_r64_m8 = 864,
    /// <summary>
    /// mpsadbw xmm, xmm/m128, imm8
    /// </summary>
    [Symbol("mpsadbw xmm, xmm, imm8","mpsadbw xmm, xmm/m128, imm8")]
    mpsadbw_xmm_xmm_imm8 = 865,
    /// <summary>
    /// mpsadbw xmm, xmm/m128, imm8
    /// </summary>
    [Symbol("mpsadbw xmm, m128, imm8","mpsadbw xmm, xmm/m128, imm8")]
    mpsadbw_xmm_m128_imm8 = 866,
    /// <summary>
    /// mul r/m16
    /// </summary>
    [Symbol("mul r16","mul r/m16")]
    mul_r16 = 867,
    /// <summary>
    /// mul r/m16
    /// </summary>
    [Symbol("mul m16","mul r/m16")]
    mul_m16 = 868,
    /// <summary>
    /// mul r/m32
    /// </summary>
    [Symbol("mul r32","mul r/m32")]
    mul_r32 = 869,
    /// <summary>
    /// mul r/m32
    /// </summary>
    [Symbol("mul m32","mul r/m32")]
    mul_m32 = 870,
    /// <summary>
    /// mul r/m64
    /// </summary>
    [Symbol("mul r64","mul r/m64")]
    mul_r64 = 871,
    /// <summary>
    /// mul r/m64
    /// </summary>
    [Symbol("mul m64","mul r/m64")]
    mul_m64 = 872,
    /// <summary>
    /// mul r/m8
    /// </summary>
    [Symbol("mul r8","mul r/m8")]
    mul_r8 = 873,
    /// <summary>
    /// mul r/m8
    /// </summary>
    [Symbol("mul m8","mul r/m8")]
    mul_m8 = 874,
    /// <summary>
    /// neg r/m16
    /// </summary>
    [Symbol("neg r16","neg r/m16")]
    neg_r16 = 875,
    /// <summary>
    /// neg r/m16
    /// </summary>
    [Symbol("neg m16","neg r/m16")]
    neg_m16 = 876,
    /// <summary>
    /// neg r/m32
    /// </summary>
    [Symbol("neg r32","neg r/m32")]
    neg_r32 = 877,
    /// <summary>
    /// neg r/m32
    /// </summary>
    [Symbol("neg m32","neg r/m32")]
    neg_m32 = 878,
    /// <summary>
    /// neg r/m64
    /// </summary>
    [Symbol("neg r64","neg r/m64")]
    neg_r64 = 879,
    /// <summary>
    /// neg r/m64
    /// </summary>
    [Symbol("neg m64","neg r/m64")]
    neg_m64 = 880,
    /// <summary>
    /// neg r/m8
    /// </summary>
    [Symbol("neg r8","neg r/m8")]
    neg_r8 = 881,
    /// <summary>
    /// neg r/m8
    /// </summary>
    [Symbol("neg m8","neg r/m8")]
    neg_m8 = 882,
    /// <summary>
    /// not r/m16
    /// </summary>
    [Symbol("not r16","not r/m16")]
    not_r16 = 883,
    /// <summary>
    /// not r/m16
    /// </summary>
    [Symbol("not m16","not r/m16")]
    not_m16 = 884,
    /// <summary>
    /// not r/m32
    /// </summary>
    [Symbol("not r32","not r/m32")]
    not_r32 = 885,
    /// <summary>
    /// not r/m32
    /// </summary>
    [Symbol("not m32","not r/m32")]
    not_m32 = 886,
    /// <summary>
    /// not r/m64
    /// </summary>
    [Symbol("not r64","not r/m64")]
    not_r64 = 887,
    /// <summary>
    /// not r/m64
    /// </summary>
    [Symbol("not m64","not r/m64")]
    not_m64 = 888,
    /// <summary>
    /// not r/m8
    /// </summary>
    [Symbol("not r8","not r/m8")]
    not_r8 = 889,
    /// <summary>
    /// not r/m8
    /// </summary>
    [Symbol("not m8","not r/m8")]
    not_m8 = 890,
    /// <summary>
    /// or AL, imm8
    /// </summary>
    [Symbol("or AL, imm8","or AL, imm8")]
    or_AL_imm8 = 891,
    /// <summary>
    /// or AX, imm16
    /// </summary>
    [Symbol("or AX, imm16","or AX, imm16")]
    or_AX_imm16 = 892,
    /// <summary>
    /// or EAX, imm32
    /// </summary>
    [Symbol("or EAX, imm32","or EAX, imm32")]
    or_EAX_imm32 = 893,
    /// <summary>
    /// or r/m16, imm16
    /// </summary>
    [Symbol("or r16, imm16","or r/m16, imm16")]
    or_r16_imm16 = 894,
    /// <summary>
    /// or r/m16, imm16
    /// </summary>
    [Symbol("or m16, imm16","or r/m16, imm16")]
    or_m16_imm16 = 895,
    /// <summary>
    /// or r/m16, imm8
    /// </summary>
    [Symbol("or r16, imm8","or r/m16, imm8")]
    or_r16_imm8 = 896,
    /// <summary>
    /// or r/m16, imm8
    /// </summary>
    [Symbol("or m16, imm8","or r/m16, imm8")]
    or_m16_imm8 = 897,
    /// <summary>
    /// or r/m16, r16
    /// </summary>
    [Symbol("or r16, r16","or r/m16, r16")]
    or_r16_r16 = 898,
    /// <summary>
    /// or r/m16, r16
    /// </summary>
    [Symbol("or m16, r16","or r/m16, r16")]
    or_m16_r16 = 899,
    /// <summary>
    /// or r/m32, imm32
    /// </summary>
    [Symbol("or r32, imm32","or r/m32, imm32")]
    or_r32_imm32 = 900,
    /// <summary>
    /// or r/m32, imm32
    /// </summary>
    [Symbol("or m32, imm32","or r/m32, imm32")]
    or_m32_imm32 = 901,
    /// <summary>
    /// or r/m32, imm8
    /// </summary>
    [Symbol("or r32, imm8","or r/m32, imm8")]
    or_r32_imm8 = 902,
    /// <summary>
    /// or r/m32, imm8
    /// </summary>
    [Symbol("or m32, imm8","or r/m32, imm8")]
    or_m32_imm8 = 903,
    /// <summary>
    /// or r/m32, r32
    /// </summary>
    [Symbol("or r32, r32","or r/m32, r32")]
    or_r32_r32 = 904,
    /// <summary>
    /// or r/m32, r32
    /// </summary>
    [Symbol("or m32, r32","or r/m32, r32")]
    or_m32_r32 = 905,
    /// <summary>
    /// or r/m64, imm32
    /// </summary>
    [Symbol("or r64, imm32","or r/m64, imm32")]
    or_r64_imm32 = 906,
    /// <summary>
    /// or r/m64, imm32
    /// </summary>
    [Symbol("or m64, imm32","or r/m64, imm32")]
    or_m64_imm32 = 907,
    /// <summary>
    /// or r/m64, imm8
    /// </summary>
    [Symbol("or r64, imm8","or r/m64, imm8")]
    or_r64_imm8 = 908,
    /// <summary>
    /// or r/m64, imm8
    /// </summary>
    [Symbol("or m64, imm8","or r/m64, imm8")]
    or_m64_imm8 = 909,
    /// <summary>
    /// or r/m64, r64
    /// </summary>
    [Symbol("or r64, r64","or r/m64, r64")]
    or_r64_r64 = 910,
    /// <summary>
    /// or r/m64, r64
    /// </summary>
    [Symbol("or m64, r64","or r/m64, r64")]
    or_m64_r64 = 911,
    /// <summary>
    /// or r/m8, imm8
    /// </summary>
    [Symbol("or r8, imm8","or r/m8, imm8")]
    or_r8_imm8 = 912,
    /// <summary>
    /// or r/m8, imm8
    /// </summary>
    [Symbol("or m8, imm8","or r/m8, imm8")]
    or_m8_imm8 = 913,
    /// <summary>
    /// or r/m8, r8
    /// </summary>
    [Symbol("or r8, r8","or r/m8, r8")]
    or_r8_r8 = 914,
    /// <summary>
    /// or r/m8, r8
    /// </summary>
    [Symbol("or m8, r8","or r/m8, r8")]
    or_m8_r8 = 915,
    /// <summary>
    /// or r16, r/m16
    /// </summary>
    [Symbol("or r16, m16","or r16, r/m16")]
    or_r16_m16 = 916,
    /// <summary>
    /// or r32, r/m32
    /// </summary>
    [Symbol("or r32, m32","or r32, r/m32")]
    or_r32_m32 = 917,
    /// <summary>
    /// or r64, r/m64
    /// </summary>
    [Symbol("or r64, m64","or r64, r/m64")]
    or_r64_m64 = 918,
    /// <summary>
    /// or r8, r/m8
    /// </summary>
    [Symbol("or r8, m8","or r8, r/m8")]
    or_r8_m8 = 919,
    /// <summary>
    /// or RAX, imm32
    /// </summary>
    [Symbol("or RAX, imm32","or RAX, imm32")]
    or_RAX_imm32 = 920,
    /// <summary>
    /// out DX, AL
    /// </summary>
    [Symbol("out DX, AL","out DX, AL")]
    out_DX_AL = 921,
    /// <summary>
    /// out DX, AX
    /// </summary>
    [Symbol("out DX, AX","out DX, AX")]
    out_DX_AX = 922,
    /// <summary>
    /// out DX, EAX
    /// </summary>
    [Symbol("out DX, EAX","out DX, EAX")]
    out_DX_EAX = 923,
    /// <summary>
    /// out imm8, AL
    /// </summary>
    [Symbol("out imm8, AL","out imm8, AL")]
    out_imm8_AL = 924,
    /// <summary>
    /// out imm8, AX
    /// </summary>
    [Symbol("out imm8, AX","out imm8, AX")]
    out_imm8_AX = 925,
    /// <summary>
    /// out imm8, EAX
    /// </summary>
    [Symbol("out imm8, EAX","out imm8, EAX")]
    out_imm8_EAX = 926,
    /// <summary>
    /// outs DX, m16
    /// </summary>
    [Symbol("outs DX, m16","outs DX, m16")]
    outs_DX_m16 = 927,
    /// <summary>
    /// outs DX, m32
    /// </summary>
    [Symbol("outs DX, m32","outs DX, m32")]
    outs_DX_m32 = 928,
    /// <summary>
    /// outs DX, m8
    /// </summary>
    [Symbol("outs DX, m8","outs DX, m8")]
    outs_DX_m8 = 929,
    /// <summary>
    /// outsb
    /// </summary>
    [Symbol("outsb","outsb")]
    outsb = 930,
    /// <summary>
    /// outsd
    /// </summary>
    [Symbol("outsd","outsd")]
    outsd = 931,
    /// <summary>
    /// outsw
    /// </summary>
    [Symbol("outsw","outsw")]
    outsw = 932,
    /// <summary>
    /// pabsb mm, mm/m64
    /// </summary>
    [Symbol("pabsb mm, mm","pabsb mm, mm/m64")]
    pabsb_mm_mm = 933,
    /// <summary>
    /// pabsb mm, mm/m64
    /// </summary>
    [Symbol("pabsb mm, m64","pabsb mm, mm/m64")]
    pabsb_mm_m64 = 934,
    /// <summary>
    /// pabsb xmm, xmm/m128
    /// </summary>
    [Symbol("pabsb xmm, xmm","pabsb xmm, xmm/m128")]
    pabsb_xmm_xmm = 935,
    /// <summary>
    /// pabsb xmm, xmm/m128
    /// </summary>
    [Symbol("pabsb xmm, m128","pabsb xmm, xmm/m128")]
    pabsb_xmm_m128 = 936,
    /// <summary>
    /// pabsd mm, mm/m64
    /// </summary>
    [Symbol("pabsd mm, mm","pabsd mm, mm/m64")]
    pabsd_mm_mm = 937,
    /// <summary>
    /// pabsd mm, mm/m64
    /// </summary>
    [Symbol("pabsd mm, m64","pabsd mm, mm/m64")]
    pabsd_mm_m64 = 938,
    /// <summary>
    /// pabsd xmm, xmm/m128
    /// </summary>
    [Symbol("pabsd xmm, xmm","pabsd xmm, xmm/m128")]
    pabsd_xmm_xmm = 939,
    /// <summary>
    /// pabsd xmm, xmm/m128
    /// </summary>
    [Symbol("pabsd xmm, m128","pabsd xmm, xmm/m128")]
    pabsd_xmm_m128 = 940,
    /// <summary>
    /// pabsw mm, mm/m64
    /// </summary>
    [Symbol("pabsw mm, mm","pabsw mm, mm/m64")]
    pabsw_mm_mm = 941,
    /// <summary>
    /// pabsw mm, mm/m64
    /// </summary>
    [Symbol("pabsw mm, m64","pabsw mm, mm/m64")]
    pabsw_mm_m64 = 942,
    /// <summary>
    /// pabsw xmm, xmm/m128
    /// </summary>
    [Symbol("pabsw xmm, xmm","pabsw xmm, xmm/m128")]
    pabsw_xmm_xmm = 943,
    /// <summary>
    /// pabsw xmm, xmm/m128
    /// </summary>
    [Symbol("pabsw xmm, m128","pabsw xmm, xmm/m128")]
    pabsw_xmm_m128 = 944,
    /// <summary>
    /// packssdw mm, mm/m64
    /// </summary>
    [Symbol("packssdw mm, mm","packssdw mm, mm/m64")]
    packssdw_mm_mm = 945,
    /// <summary>
    /// packssdw mm, mm/m64
    /// </summary>
    [Symbol("packssdw mm, m64","packssdw mm, mm/m64")]
    packssdw_mm_m64 = 946,
    /// <summary>
    /// packssdw xmm, xmm/m128
    /// </summary>
    [Symbol("packssdw xmm, xmm","packssdw xmm, xmm/m128")]
    packssdw_xmm_xmm = 947,
    /// <summary>
    /// packssdw xmm, xmm/m128
    /// </summary>
    [Symbol("packssdw xmm, m128","packssdw xmm, xmm/m128")]
    packssdw_xmm_m128 = 948,
    /// <summary>
    /// packsswb mm, mm/m64
    /// </summary>
    [Symbol("packsswb mm, mm","packsswb mm, mm/m64")]
    packsswb_mm_mm = 949,
    /// <summary>
    /// packsswb mm, mm/m64
    /// </summary>
    [Symbol("packsswb mm, m64","packsswb mm, mm/m64")]
    packsswb_mm_m64 = 950,
    /// <summary>
    /// packsswb xmm, xmm/m128
    /// </summary>
    [Symbol("packsswb xmm, xmm","packsswb xmm, xmm/m128")]
    packsswb_xmm_xmm = 951,
    /// <summary>
    /// packsswb xmm, xmm/m128
    /// </summary>
    [Symbol("packsswb xmm, m128","packsswb xmm, xmm/m128")]
    packsswb_xmm_m128 = 952,
    /// <summary>
    /// packusdw xmm, xmm/m128
    /// </summary>
    [Symbol("packusdw xmm, xmm","packusdw xmm, xmm/m128")]
    packusdw_xmm_xmm = 953,
    /// <summary>
    /// packusdw xmm, xmm/m128
    /// </summary>
    [Symbol("packusdw xmm, m128","packusdw xmm, xmm/m128")]
    packusdw_xmm_m128 = 954,
    /// <summary>
    /// packuswb mm, mm/m64
    /// </summary>
    [Symbol("packuswb mm, mm","packuswb mm, mm/m64")]
    packuswb_mm_mm = 955,
    /// <summary>
    /// packuswb mm, mm/m64
    /// </summary>
    [Symbol("packuswb mm, m64","packuswb mm, mm/m64")]
    packuswb_mm_m64 = 956,
    /// <summary>
    /// packuswb xmm, xmm/m128
    /// </summary>
    [Symbol("packuswb xmm, xmm","packuswb xmm, xmm/m128")]
    packuswb_xmm_xmm = 957,
    /// <summary>
    /// packuswb xmm, xmm/m128
    /// </summary>
    [Symbol("packuswb xmm, m128","packuswb xmm, xmm/m128")]
    packuswb_xmm_m128 = 958,
    /// <summary>
    /// paddb mm, mm/m64
    /// </summary>
    [Symbol("paddb mm, mm","paddb mm, mm/m64")]
    paddb_mm_mm = 959,
    /// <summary>
    /// paddb mm, mm/m64
    /// </summary>
    [Symbol("paddb mm, m64","paddb mm, mm/m64")]
    paddb_mm_m64 = 960,
    /// <summary>
    /// paddb xmm, xmm/m128
    /// </summary>
    [Symbol("paddb xmm, xmm","paddb xmm, xmm/m128")]
    paddb_xmm_xmm = 961,
    /// <summary>
    /// paddb xmm, xmm/m128
    /// </summary>
    [Symbol("paddb xmm, m128","paddb xmm, xmm/m128")]
    paddb_xmm_m128 = 962,
    /// <summary>
    /// paddd mm, mm/m64
    /// </summary>
    [Symbol("paddd mm, mm","paddd mm, mm/m64")]
    paddd_mm_mm = 963,
    /// <summary>
    /// paddd mm, mm/m64
    /// </summary>
    [Symbol("paddd mm, m64","paddd mm, mm/m64")]
    paddd_mm_m64 = 964,
    /// <summary>
    /// paddd xmm, xmm/m128
    /// </summary>
    [Symbol("paddd xmm, xmm","paddd xmm, xmm/m128")]
    paddd_xmm_xmm = 965,
    /// <summary>
    /// paddd xmm, xmm/m128
    /// </summary>
    [Symbol("paddd xmm, m128","paddd xmm, xmm/m128")]
    paddd_xmm_m128 = 966,
    /// <summary>
    /// paddq mm, mm/m64
    /// </summary>
    [Symbol("paddq mm, mm","paddq mm, mm/m64")]
    paddq_mm_mm = 967,
    /// <summary>
    /// paddq mm, mm/m64
    /// </summary>
    [Symbol("paddq mm, m64","paddq mm, mm/m64")]
    paddq_mm_m64 = 968,
    /// <summary>
    /// paddq xmm, xmm/m128
    /// </summary>
    [Symbol("paddq xmm, xmm","paddq xmm, xmm/m128")]
    paddq_xmm_xmm = 969,
    /// <summary>
    /// paddq xmm, xmm/m128
    /// </summary>
    [Symbol("paddq xmm, m128","paddq xmm, xmm/m128")]
    paddq_xmm_m128 = 970,
    /// <summary>
    /// paddsb mm, mm/m64
    /// </summary>
    [Symbol("paddsb mm, mm","paddsb mm, mm/m64")]
    paddsb_mm_mm = 971,
    /// <summary>
    /// paddsb mm, mm/m64
    /// </summary>
    [Symbol("paddsb mm, m64","paddsb mm, mm/m64")]
    paddsb_mm_m64 = 972,
    /// <summary>
    /// paddsb xmm, xmm/m128
    /// </summary>
    [Symbol("paddsb xmm, xmm","paddsb xmm, xmm/m128")]
    paddsb_xmm_xmm = 973,
    /// <summary>
    /// paddsb xmm, xmm/m128
    /// </summary>
    [Symbol("paddsb xmm, m128","paddsb xmm, xmm/m128")]
    paddsb_xmm_m128 = 974,
    /// <summary>
    /// paddsw mm, mm/m64
    /// </summary>
    [Symbol("paddsw mm, mm","paddsw mm, mm/m64")]
    paddsw_mm_mm = 975,
    /// <summary>
    /// paddsw mm, mm/m64
    /// </summary>
    [Symbol("paddsw mm, m64","paddsw mm, mm/m64")]
    paddsw_mm_m64 = 976,
    /// <summary>
    /// paddsw xmm, xmm/m128
    /// </summary>
    [Symbol("paddsw xmm, xmm","paddsw xmm, xmm/m128")]
    paddsw_xmm_xmm = 977,
    /// <summary>
    /// paddsw xmm, xmm/m128
    /// </summary>
    [Symbol("paddsw xmm, m128","paddsw xmm, xmm/m128")]
    paddsw_xmm_m128 = 978,
    /// <summary>
    /// paddusb mm, mm/m64
    /// </summary>
    [Symbol("paddusb mm, mm","paddusb mm, mm/m64")]
    paddusb_mm_mm = 979,
    /// <summary>
    /// paddusb mm, mm/m64
    /// </summary>
    [Symbol("paddusb mm, m64","paddusb mm, mm/m64")]
    paddusb_mm_m64 = 980,
    /// <summary>
    /// paddusb xmm, xmm/m128
    /// </summary>
    [Symbol("paddusb xmm, xmm","paddusb xmm, xmm/m128")]
    paddusb_xmm_xmm = 981,
    /// <summary>
    /// paddusb xmm, xmm/m128
    /// </summary>
    [Symbol("paddusb xmm, m128","paddusb xmm, xmm/m128")]
    paddusb_xmm_m128 = 982,
    /// <summary>
    /// paddusw mm, mm/m64
    /// </summary>
    [Symbol("paddusw mm, mm","paddusw mm, mm/m64")]
    paddusw_mm_mm = 983,
    /// <summary>
    /// paddusw mm, mm/m64
    /// </summary>
    [Symbol("paddusw mm, m64","paddusw mm, mm/m64")]
    paddusw_mm_m64 = 984,
    /// <summary>
    /// paddusw xmm, xmm/m128
    /// </summary>
    [Symbol("paddusw xmm, xmm","paddusw xmm, xmm/m128")]
    paddusw_xmm_xmm = 985,
    /// <summary>
    /// paddusw xmm, xmm/m128
    /// </summary>
    [Symbol("paddusw xmm, m128","paddusw xmm, xmm/m128")]
    paddusw_xmm_m128 = 986,
    /// <summary>
    /// paddw mm, mm/m64
    /// </summary>
    [Symbol("paddw mm, mm","paddw mm, mm/m64")]
    paddw_mm_mm = 987,
    /// <summary>
    /// paddw mm, mm/m64
    /// </summary>
    [Symbol("paddw mm, m64","paddw mm, mm/m64")]
    paddw_mm_m64 = 988,
    /// <summary>
    /// paddw xmm, xmm/m128
    /// </summary>
    [Symbol("paddw xmm, xmm","paddw xmm, xmm/m128")]
    paddw_xmm_xmm = 989,
    /// <summary>
    /// paddw xmm, xmm/m128
    /// </summary>
    [Symbol("paddw xmm, m128","paddw xmm, xmm/m128")]
    paddw_xmm_m128 = 990,
    /// <summary>
    /// pand mm, mm/m64
    /// </summary>
    [Symbol("pand mm, mm","pand mm, mm/m64")]
    pand_mm_mm = 991,
    /// <summary>
    /// pand mm, mm/m64
    /// </summary>
    [Symbol("pand mm, m64","pand mm, mm/m64")]
    pand_mm_m64 = 992,
    /// <summary>
    /// pand xmm, xmm/m128
    /// </summary>
    [Symbol("pand xmm, xmm","pand xmm, xmm/m128")]
    pand_xmm_xmm = 993,
    /// <summary>
    /// pand xmm, xmm/m128
    /// </summary>
    [Symbol("pand xmm, m128","pand xmm, xmm/m128")]
    pand_xmm_m128 = 994,
    /// <summary>
    /// pandn mm, mm/m64
    /// </summary>
    [Symbol("pandn mm, mm","pandn mm, mm/m64")]
    pandn_mm_mm = 995,
    /// <summary>
    /// pandn mm, mm/m64
    /// </summary>
    [Symbol("pandn mm, m64","pandn mm, mm/m64")]
    pandn_mm_m64 = 996,
    /// <summary>
    /// pandn xmm, xmm/m128
    /// </summary>
    [Symbol("pandn xmm, xmm","pandn xmm, xmm/m128")]
    pandn_xmm_xmm = 997,
    /// <summary>
    /// pandn xmm, xmm/m128
    /// </summary>
    [Symbol("pandn xmm, m128","pandn xmm, xmm/m128")]
    pandn_xmm_m128 = 998,
    /// <summary>
    /// pavgb mm, mm/m64
    /// </summary>
    [Symbol("pavgb mm, mm","pavgb mm, mm/m64")]
    pavgb_mm_mm = 999,
    /// <summary>
    /// pavgb mm, mm/m64
    /// </summary>
    [Symbol("pavgb mm, m64","pavgb mm, mm/m64")]
    pavgb_mm_m64 = 1000,
    /// <summary>
    /// pavgb xmm, xmm/m128
    /// </summary>
    [Symbol("pavgb xmm, xmm","pavgb xmm, xmm/m128")]
    pavgb_xmm_xmm = 1001,
    /// <summary>
    /// pavgb xmm, xmm/m128
    /// </summary>
    [Symbol("pavgb xmm, m128","pavgb xmm, xmm/m128")]
    pavgb_xmm_m128 = 1002,
    /// <summary>
    /// pavgw mm, mm/m64
    /// </summary>
    [Symbol("pavgw mm, mm","pavgw mm, mm/m64")]
    pavgw_mm_mm = 1003,
    /// <summary>
    /// pavgw mm, mm/m64
    /// </summary>
    [Symbol("pavgw mm, m64","pavgw mm, mm/m64")]
    pavgw_mm_m64 = 1004,
    /// <summary>
    /// pavgw xmm, xmm/m128
    /// </summary>
    [Symbol("pavgw xmm, xmm","pavgw xmm, xmm/m128")]
    pavgw_xmm_xmm = 1005,
    /// <summary>
    /// pavgw xmm, xmm/m128
    /// </summary>
    [Symbol("pavgw xmm, m128","pavgw xmm, xmm/m128")]
    pavgw_xmm_m128 = 1006,
    /// <summary>
    /// pcmpeqb mm, mm/m64
    /// </summary>
    [Symbol("pcmpeqb mm, mm","pcmpeqb mm, mm/m64")]
    pcmpeqb_mm_mm = 1007,
    /// <summary>
    /// pcmpeqb mm, mm/m64
    /// </summary>
    [Symbol("pcmpeqb mm, m64","pcmpeqb mm, mm/m64")]
    pcmpeqb_mm_m64 = 1008,
    /// <summary>
    /// pcmpeqb xmm, xmm/m128
    /// </summary>
    [Symbol("pcmpeqb xmm, xmm","pcmpeqb xmm, xmm/m128")]
    pcmpeqb_xmm_xmm = 1009,
    /// <summary>
    /// pcmpeqb xmm, xmm/m128
    /// </summary>
    [Symbol("pcmpeqb xmm, m128","pcmpeqb xmm, xmm/m128")]
    pcmpeqb_xmm_m128 = 1010,
    /// <summary>
    /// pcmpeqd mm, mm/m64
    /// </summary>
    [Symbol("pcmpeqd mm, mm","pcmpeqd mm, mm/m64")]
    pcmpeqd_mm_mm = 1011,
    /// <summary>
    /// pcmpeqd mm, mm/m64
    /// </summary>
    [Symbol("pcmpeqd mm, m64","pcmpeqd mm, mm/m64")]
    pcmpeqd_mm_m64 = 1012,
    /// <summary>
    /// pcmpeqd xmm, xmm/m128
    /// </summary>
    [Symbol("pcmpeqd xmm, xmm","pcmpeqd xmm, xmm/m128")]
    pcmpeqd_xmm_xmm = 1013,
    /// <summary>
    /// pcmpeqd xmm, xmm/m128
    /// </summary>
    [Symbol("pcmpeqd xmm, m128","pcmpeqd xmm, xmm/m128")]
    pcmpeqd_xmm_m128 = 1014,
    /// <summary>
    /// pcmpeqq xmm, xmm/m128
    /// </summary>
    [Symbol("pcmpeqq xmm, xmm","pcmpeqq xmm, xmm/m128")]
    pcmpeqq_xmm_xmm = 1015,
    /// <summary>
    /// pcmpeqq xmm, xmm/m128
    /// </summary>
    [Symbol("pcmpeqq xmm, m128","pcmpeqq xmm, xmm/m128")]
    pcmpeqq_xmm_m128 = 1016,
    /// <summary>
    /// pcmpeqw mm, mm/m64
    /// </summary>
    [Symbol("pcmpeqw mm, mm","pcmpeqw mm, mm/m64")]
    pcmpeqw_mm_mm = 1017,
    /// <summary>
    /// pcmpeqw mm, mm/m64
    /// </summary>
    [Symbol("pcmpeqw mm, m64","pcmpeqw mm, mm/m64")]
    pcmpeqw_mm_m64 = 1018,
    /// <summary>
    /// pcmpeqw xmm, xmm/m128
    /// </summary>
    [Symbol("pcmpeqw xmm, xmm","pcmpeqw xmm, xmm/m128")]
    pcmpeqw_xmm_xmm = 1019,
    /// <summary>
    /// pcmpeqw xmm, xmm/m128
    /// </summary>
    [Symbol("pcmpeqw xmm, m128","pcmpeqw xmm, xmm/m128")]
    pcmpeqw_xmm_m128 = 1020,
    /// <summary>
    /// pcmpgtb mm, mm/m64
    /// </summary>
    [Symbol("pcmpgtb mm, mm","pcmpgtb mm, mm/m64")]
    pcmpgtb_mm_mm = 1021,
    /// <summary>
    /// pcmpgtb mm, mm/m64
    /// </summary>
    [Symbol("pcmpgtb mm, m64","pcmpgtb mm, mm/m64")]
    pcmpgtb_mm_m64 = 1022,
    /// <summary>
    /// pcmpgtb xmm, xmm/m128
    /// </summary>
    [Symbol("pcmpgtb xmm, xmm","pcmpgtb xmm, xmm/m128")]
    pcmpgtb_xmm_xmm = 1023,
    /// <summary>
    /// pcmpgtb xmm, xmm/m128
    /// </summary>
    [Symbol("pcmpgtb xmm, m128","pcmpgtb xmm, xmm/m128")]
    pcmpgtb_xmm_m128 = 1024,
    /// <summary>
    /// pcmpgtd mm, mm/m64
    /// </summary>
    [Symbol("pcmpgtd mm, mm","pcmpgtd mm, mm/m64")]
    pcmpgtd_mm_mm = 1025,
    /// <summary>
    /// pcmpgtd mm, mm/m64
    /// </summary>
    [Symbol("pcmpgtd mm, m64","pcmpgtd mm, mm/m64")]
    pcmpgtd_mm_m64 = 1026,
    /// <summary>
    /// pcmpgtd xmm, xmm/m128
    /// </summary>
    [Symbol("pcmpgtd xmm, xmm","pcmpgtd xmm, xmm/m128")]
    pcmpgtd_xmm_xmm = 1027,
    /// <summary>
    /// pcmpgtd xmm, xmm/m128
    /// </summary>
    [Symbol("pcmpgtd xmm, m128","pcmpgtd xmm, xmm/m128")]
    pcmpgtd_xmm_m128 = 1028,
    /// <summary>
    /// pcmpgtq xmm, xmm/m128
    /// </summary>
    [Symbol("pcmpgtq xmm, xmm","pcmpgtq xmm, xmm/m128")]
    pcmpgtq_xmm_xmm = 1029,
    /// <summary>
    /// pcmpgtq xmm, xmm/m128
    /// </summary>
    [Symbol("pcmpgtq xmm, m128","pcmpgtq xmm, xmm/m128")]
    pcmpgtq_xmm_m128 = 1030,
    /// <summary>
    /// pcmpgtw mm, mm/m64
    /// </summary>
    [Symbol("pcmpgtw mm, mm","pcmpgtw mm, mm/m64")]
    pcmpgtw_mm_mm = 1031,
    /// <summary>
    /// pcmpgtw mm, mm/m64
    /// </summary>
    [Symbol("pcmpgtw mm, m64","pcmpgtw mm, mm/m64")]
    pcmpgtw_mm_m64 = 1032,
    /// <summary>
    /// pcmpgtw xmm, xmm/m128
    /// </summary>
    [Symbol("pcmpgtw xmm, xmm","pcmpgtw xmm, xmm/m128")]
    pcmpgtw_xmm_xmm = 1033,
    /// <summary>
    /// pcmpgtw xmm, xmm/m128
    /// </summary>
    [Symbol("pcmpgtw xmm, m128","pcmpgtw xmm, xmm/m128")]
    pcmpgtw_xmm_m128 = 1034,
    /// <summary>
    /// pdep r32, r32, r/m32
    /// </summary>
    [Symbol("pdep r32, r32, r32","pdep r32, r32, r/m32")]
    pdep_r32_r32_r32 = 1035,
    /// <summary>
    /// pdep r32, r32, r/m32
    /// </summary>
    [Symbol("pdep r32, r32, m32","pdep r32, r32, r/m32")]
    pdep_r32_r32_m32 = 1036,
    /// <summary>
    /// pdep r64, r64, r/m64
    /// </summary>
    [Symbol("pdep r64, r64, r64","pdep r64, r64, r/m64")]
    pdep_r64_r64_r64 = 1037,
    /// <summary>
    /// pdep r64, r64, r/m64
    /// </summary>
    [Symbol("pdep r64, r64, m64","pdep r64, r64, r/m64")]
    pdep_r64_r64_m64 = 1038,
    /// <summary>
    /// pextrb reg/m8, xmm, imm8
    /// </summary>
    [Symbol("pextrb reg, xmm, imm8","pextrb reg/m8, xmm, imm8")]
    pextrb_reg_xmm_imm8 = 1039,
    /// <summary>
    /// pextrb reg/m8, xmm, imm8
    /// </summary>
    [Symbol("pextrb m8, xmm, imm8","pextrb reg/m8, xmm, imm8")]
    pextrb_m8_xmm_imm8 = 1040,
    /// <summary>
    /// pextrd r/m32, xmm, imm8
    /// </summary>
    [Symbol("pextrd r32, xmm, imm8","pextrd r/m32, xmm, imm8")]
    pextrd_r32_xmm_imm8 = 1041,
    /// <summary>
    /// pextrd r/m32, xmm, imm8
    /// </summary>
    [Symbol("pextrd m32, xmm, imm8","pextrd r/m32, xmm, imm8")]
    pextrd_m32_xmm_imm8 = 1042,
    /// <summary>
    /// pextrq r/m64, xmm, imm8
    /// </summary>
    [Symbol("pextrq r64, xmm, imm8","pextrq r/m64, xmm, imm8")]
    pextrq_r64_xmm_imm8 = 1043,
    /// <summary>
    /// pextrq r/m64, xmm, imm8
    /// </summary>
    [Symbol("pextrq m64, xmm, imm8","pextrq r/m64, xmm, imm8")]
    pextrq_m64_xmm_imm8 = 1044,
    /// <summary>
    /// pextrw reg, mm, imm8
    /// </summary>
    [Symbol("pextrw reg, mm, imm8","pextrw reg, mm, imm8")]
    pextrw_reg_mm_imm8 = 1045,
    /// <summary>
    /// pextrw reg, xmm, imm8
    /// </summary>
    [Symbol("pextrw reg, xmm, imm8","pextrw reg, xmm, imm8")]
    pextrw_reg_xmm_imm8 = 1046,
    /// <summary>
    /// pextrw reg/m16, xmm, imm8
    /// </summary>
    [Symbol("pextrw m16, xmm, imm8","pextrw reg/m16, xmm, imm8")]
    pextrw_m16_xmm_imm8 = 1047,
    /// <summary>
    /// phaddd mm, mm/m64
    /// </summary>
    [Symbol("phaddd mm, mm","phaddd mm, mm/m64")]
    phaddd_mm_mm = 1048,
    /// <summary>
    /// phaddd mm, mm/m64
    /// </summary>
    [Symbol("phaddd mm, m64","phaddd mm, mm/m64")]
    phaddd_mm_m64 = 1049,
    /// <summary>
    /// phaddd xmm, xmm/m128
    /// </summary>
    [Symbol("phaddd xmm, xmm","phaddd xmm, xmm/m128")]
    phaddd_xmm_xmm = 1050,
    /// <summary>
    /// phaddd xmm, xmm/m128
    /// </summary>
    [Symbol("phaddd xmm, m128","phaddd xmm, xmm/m128")]
    phaddd_xmm_m128 = 1051,
    /// <summary>
    /// phaddsw mm, mm/m64
    /// </summary>
    [Symbol("phaddsw mm, mm","phaddsw mm, mm/m64")]
    phaddsw_mm_mm = 1052,
    /// <summary>
    /// phaddsw mm, mm/m64
    /// </summary>
    [Symbol("phaddsw mm, m64","phaddsw mm, mm/m64")]
    phaddsw_mm_m64 = 1053,
    /// <summary>
    /// phaddsw xmm, xmm/m128
    /// </summary>
    [Symbol("phaddsw xmm, xmm","phaddsw xmm, xmm/m128")]
    phaddsw_xmm_xmm = 1054,
    /// <summary>
    /// phaddsw xmm, xmm/m128
    /// </summary>
    [Symbol("phaddsw xmm, m128","phaddsw xmm, xmm/m128")]
    phaddsw_xmm_m128 = 1055,
    /// <summary>
    /// phaddw mm, mm/m64
    /// </summary>
    [Symbol("phaddw mm, mm","phaddw mm, mm/m64")]
    phaddw_mm_mm = 1056,
    /// <summary>
    /// phaddw mm, mm/m64
    /// </summary>
    [Symbol("phaddw mm, m64","phaddw mm, mm/m64")]
    phaddw_mm_m64 = 1057,
    /// <summary>
    /// phaddw xmm, xmm/m128
    /// </summary>
    [Symbol("phaddw xmm, xmm","phaddw xmm, xmm/m128")]
    phaddw_xmm_xmm = 1058,
    /// <summary>
    /// phaddw xmm, xmm/m128
    /// </summary>
    [Symbol("phaddw xmm, m128","phaddw xmm, xmm/m128")]
    phaddw_xmm_m128 = 1059,
    /// <summary>
    /// pinsrb xmm, r32/m8, imm8
    /// </summary>
    [Symbol("pinsrb xmm, r32, imm8","pinsrb xmm, r32/m8, imm8")]
    pinsrb_xmm_r32_imm8 = 1060,
    /// <summary>
    /// pinsrb xmm, r32/m8, imm8
    /// </summary>
    [Symbol("pinsrb xmm, m8, imm8","pinsrb xmm, r32/m8, imm8")]
    pinsrb_xmm_m8_imm8 = 1061,
    /// <summary>
    /// pinsrd xmm, r/m32, imm8
    /// </summary>
    [Symbol("pinsrd xmm, r32, imm8","pinsrd xmm, r/m32, imm8")]
    pinsrd_xmm_r32_imm8 = 1062,
    /// <summary>
    /// pinsrd xmm, r/m32, imm8
    /// </summary>
    [Symbol("pinsrd xmm, m32, imm8","pinsrd xmm, r/m32, imm8")]
    pinsrd_xmm_m32_imm8 = 1063,
    /// <summary>
    /// pinsrq xmm, r/m64, imm8
    /// </summary>
    [Symbol("pinsrq xmm, r64, imm8","pinsrq xmm, r/m64, imm8")]
    pinsrq_xmm_r64_imm8 = 1064,
    /// <summary>
    /// pinsrq xmm, r/m64, imm8
    /// </summary>
    [Symbol("pinsrq xmm, m64, imm8","pinsrq xmm, r/m64, imm8")]
    pinsrq_xmm_m64_imm8 = 1065,
    /// <summary>
    /// pinsrw mm, r32/m16, imm8
    /// </summary>
    [Symbol("pinsrw mm, r32, imm8","pinsrw mm, r32/m16, imm8")]
    pinsrw_mm_r32_imm8 = 1066,
    /// <summary>
    /// pinsrw mm, r32/m16, imm8
    /// </summary>
    [Symbol("pinsrw mm, m16, imm8","pinsrw mm, r32/m16, imm8")]
    pinsrw_mm_m16_imm8 = 1067,
    /// <summary>
    /// pinsrw xmm, r32/m16, imm8
    /// </summary>
    [Symbol("pinsrw xmm, r32, imm8","pinsrw xmm, r32/m16, imm8")]
    pinsrw_xmm_r32_imm8 = 1068,
    /// <summary>
    /// pinsrw xmm, r32/m16, imm8
    /// </summary>
    [Symbol("pinsrw xmm, m16, imm8","pinsrw xmm, r32/m16, imm8")]
    pinsrw_xmm_m16_imm8 = 1069,
    /// <summary>
    /// pmaxsb xmm, xmm/m128
    /// </summary>
    [Symbol("pmaxsb xmm, xmm","pmaxsb xmm, xmm/m128")]
    pmaxsb_xmm_xmm = 1070,
    /// <summary>
    /// pmaxsb xmm, xmm/m128
    /// </summary>
    [Symbol("pmaxsb xmm, m128","pmaxsb xmm, xmm/m128")]
    pmaxsb_xmm_m128 = 1071,
    /// <summary>
    /// pmaxsd xmm, xmm/m128
    /// </summary>
    [Symbol("pmaxsd xmm, xmm","pmaxsd xmm, xmm/m128")]
    pmaxsd_xmm_xmm = 1072,
    /// <summary>
    /// pmaxsd xmm, xmm/m128
    /// </summary>
    [Symbol("pmaxsd xmm, m128","pmaxsd xmm, xmm/m128")]
    pmaxsd_xmm_m128 = 1073,
    /// <summary>
    /// pmaxsw mm, mm/m64
    /// </summary>
    [Symbol("pmaxsw mm, mm","pmaxsw mm, mm/m64")]
    pmaxsw_mm_mm = 1074,
    /// <summary>
    /// pmaxsw mm, mm/m64
    /// </summary>
    [Symbol("pmaxsw mm, m64","pmaxsw mm, mm/m64")]
    pmaxsw_mm_m64 = 1075,
    /// <summary>
    /// pmaxsw xmm, xmm/m128
    /// </summary>
    [Symbol("pmaxsw xmm, xmm","pmaxsw xmm, xmm/m128")]
    pmaxsw_xmm_xmm = 1076,
    /// <summary>
    /// pmaxsw xmm, xmm/m128
    /// </summary>
    [Symbol("pmaxsw xmm, m128","pmaxsw xmm, xmm/m128")]
    pmaxsw_xmm_m128 = 1077,
    /// <summary>
    /// pmaxub mm, mm/m64
    /// </summary>
    [Symbol("pmaxub mm, mm","pmaxub mm, mm/m64")]
    pmaxub_mm_mm = 1078,
    /// <summary>
    /// pmaxub mm, mm/m64
    /// </summary>
    [Symbol("pmaxub mm, m64","pmaxub mm, mm/m64")]
    pmaxub_mm_m64 = 1079,
    /// <summary>
    /// pmaxub xmm, xmm/m128
    /// </summary>
    [Symbol("pmaxub xmm, xmm","pmaxub xmm, xmm/m128")]
    pmaxub_xmm_xmm = 1080,
    /// <summary>
    /// pmaxub xmm, xmm/m128
    /// </summary>
    [Symbol("pmaxub xmm, m128","pmaxub xmm, xmm/m128")]
    pmaxub_xmm_m128 = 1081,
    /// <summary>
    /// pmaxuw xmm, xmm/m128
    /// </summary>
    [Symbol("pmaxuw xmm, xmm","pmaxuw xmm, xmm/m128")]
    pmaxuw_xmm_xmm = 1082,
    /// <summary>
    /// pmaxuw xmm, xmm/m128
    /// </summary>
    [Symbol("pmaxuw xmm, m128","pmaxuw xmm, xmm/m128")]
    pmaxuw_xmm_m128 = 1083,
    /// <summary>
    /// pminsb xmm, xmm/m128
    /// </summary>
    [Symbol("pminsb xmm, xmm","pminsb xmm, xmm/m128")]
    pminsb_xmm_xmm = 1084,
    /// <summary>
    /// pminsb xmm, xmm/m128
    /// </summary>
    [Symbol("pminsb xmm, m128","pminsb xmm, xmm/m128")]
    pminsb_xmm_m128 = 1085,
    /// <summary>
    /// pminsw mm, mm/m64
    /// </summary>
    [Symbol("pminsw mm, mm","pminsw mm, mm/m64")]
    pminsw_mm_mm = 1086,
    /// <summary>
    /// pminsw mm, mm/m64
    /// </summary>
    [Symbol("pminsw mm, m64","pminsw mm, mm/m64")]
    pminsw_mm_m64 = 1087,
    /// <summary>
    /// pminsw xmm, xmm/m128
    /// </summary>
    [Symbol("pminsw xmm, xmm","pminsw xmm, xmm/m128")]
    pminsw_xmm_xmm = 1088,
    /// <summary>
    /// pminsw xmm, xmm/m128
    /// </summary>
    [Symbol("pminsw xmm, m128","pminsw xmm, xmm/m128")]
    pminsw_xmm_m128 = 1089,
    /// <summary>
    /// pminub mm, mm/m64
    /// </summary>
    [Symbol("pminub mm, mm","pminub mm, mm/m64")]
    pminub_mm_mm = 1090,
    /// <summary>
    /// pminub mm, mm/m64
    /// </summary>
    [Symbol("pminub mm, m64","pminub mm, mm/m64")]
    pminub_mm_m64 = 1091,
    /// <summary>
    /// pminub xmm, xmm/m128
    /// </summary>
    [Symbol("pminub xmm, xmm","pminub xmm, xmm/m128")]
    pminub_xmm_xmm = 1092,
    /// <summary>
    /// pminub xmm, xmm/m128
    /// </summary>
    [Symbol("pminub xmm, m128","pminub xmm, xmm/m128")]
    pminub_xmm_m128 = 1093,
    /// <summary>
    /// pminuw xmm, xmm/m128
    /// </summary>
    [Symbol("pminuw xmm, xmm","pminuw xmm, xmm/m128")]
    pminuw_xmm_xmm = 1094,
    /// <summary>
    /// pminuw xmm, xmm/m128
    /// </summary>
    [Symbol("pminuw xmm, m128","pminuw xmm, xmm/m128")]
    pminuw_xmm_m128 = 1095,
    /// <summary>
    /// pmovmskb reg, mm
    /// </summary>
    [Symbol("pmovmskb reg, mm","pmovmskb reg, mm")]
    pmovmskb_reg_mm = 1096,
    /// <summary>
    /// pmovmskb reg, xmm
    /// </summary>
    [Symbol("pmovmskb reg, xmm","pmovmskb reg, xmm")]
    pmovmskb_reg_xmm = 1097,
    /// <summary>
    /// pmovsxbd xmm, xmm/m32
    /// </summary>
    [Symbol("pmovsxbd xmm, xmm","pmovsxbd xmm, xmm/m32")]
    pmovsxbd_xmm_xmm = 1098,
    /// <summary>
    /// pmovsxbd xmm, xmm/m32
    /// </summary>
    [Symbol("pmovsxbd xmm, m32","pmovsxbd xmm, xmm/m32")]
    pmovsxbd_xmm_m32 = 1099,
    /// <summary>
    /// pmovsxbq xmm, xmm/m16
    /// </summary>
    [Symbol("pmovsxbq xmm, xmm","pmovsxbq xmm, xmm/m16")]
    pmovsxbq_xmm_xmm = 1100,
    /// <summary>
    /// pmovsxbq xmm, xmm/m16
    /// </summary>
    [Symbol("pmovsxbq xmm, m16","pmovsxbq xmm, xmm/m16")]
    pmovsxbq_xmm_m16 = 1101,
    /// <summary>
    /// pmovsxbw xmm, xmm/m64
    /// </summary>
    [Symbol("pmovsxbw xmm, xmm","pmovsxbw xmm, xmm/m64")]
    pmovsxbw_xmm_xmm = 1102,
    /// <summary>
    /// pmovsxbw xmm, xmm/m64
    /// </summary>
    [Symbol("pmovsxbw xmm, m64","pmovsxbw xmm, xmm/m64")]
    pmovsxbw_xmm_m64 = 1103,
    /// <summary>
    /// pmovsxdq xmm, xmm/m64
    /// </summary>
    [Symbol("pmovsxdq xmm, xmm","pmovsxdq xmm, xmm/m64")]
    pmovsxdq_xmm_xmm = 1104,
    /// <summary>
    /// pmovsxdq xmm, xmm/m64
    /// </summary>
    [Symbol("pmovsxdq xmm, m64","pmovsxdq xmm, xmm/m64")]
    pmovsxdq_xmm_m64 = 1105,
    /// <summary>
    /// pmovsxwd xmm, xmm/m64
    /// </summary>
    [Symbol("pmovsxwd xmm, xmm","pmovsxwd xmm, xmm/m64")]
    pmovsxwd_xmm_xmm = 1106,
    /// <summary>
    /// pmovsxwd xmm, xmm/m64
    /// </summary>
    [Symbol("pmovsxwd xmm, m64","pmovsxwd xmm, xmm/m64")]
    pmovsxwd_xmm_m64 = 1107,
    /// <summary>
    /// pmovsxwq xmm, xmm/m32
    /// </summary>
    [Symbol("pmovsxwq xmm, xmm","pmovsxwq xmm, xmm/m32")]
    pmovsxwq_xmm_xmm = 1108,
    /// <summary>
    /// pmovsxwq xmm, xmm/m32
    /// </summary>
    [Symbol("pmovsxwq xmm, m32","pmovsxwq xmm, xmm/m32")]
    pmovsxwq_xmm_m32 = 1109,
    /// <summary>
    /// pmovzxbd xmm, xmm/m32
    /// </summary>
    [Symbol("pmovzxbd xmm, xmm","pmovzxbd xmm, xmm/m32")]
    pmovzxbd_xmm_xmm = 1110,
    /// <summary>
    /// pmovzxbd xmm, xmm/m32
    /// </summary>
    [Symbol("pmovzxbd xmm, m32","pmovzxbd xmm, xmm/m32")]
    pmovzxbd_xmm_m32 = 1111,
    /// <summary>
    /// pmovzxbq xmm, xmm/m16
    /// </summary>
    [Symbol("pmovzxbq xmm, xmm","pmovzxbq xmm, xmm/m16")]
    pmovzxbq_xmm_xmm = 1112,
    /// <summary>
    /// pmovzxbq xmm, xmm/m16
    /// </summary>
    [Symbol("pmovzxbq xmm, m16","pmovzxbq xmm, xmm/m16")]
    pmovzxbq_xmm_m16 = 1113,
    /// <summary>
    /// pmovzxbw xmm, xmm/m64
    /// </summary>
    [Symbol("pmovzxbw xmm, xmm","pmovzxbw xmm, xmm/m64")]
    pmovzxbw_xmm_xmm = 1114,
    /// <summary>
    /// pmovzxbw xmm, xmm/m64
    /// </summary>
    [Symbol("pmovzxbw xmm, m64","pmovzxbw xmm, xmm/m64")]
    pmovzxbw_xmm_m64 = 1115,
    /// <summary>
    /// pmovzxdq xmm, xmm/m64
    /// </summary>
    [Symbol("pmovzxdq xmm, xmm","pmovzxdq xmm, xmm/m64")]
    pmovzxdq_xmm_xmm = 1116,
    /// <summary>
    /// pmovzxdq xmm, xmm/m64
    /// </summary>
    [Symbol("pmovzxdq xmm, m64","pmovzxdq xmm, xmm/m64")]
    pmovzxdq_xmm_m64 = 1117,
    /// <summary>
    /// pmovzxwd xmm, xmm/m64
    /// </summary>
    [Symbol("pmovzxwd xmm, xmm","pmovzxwd xmm, xmm/m64")]
    pmovzxwd_xmm_xmm = 1118,
    /// <summary>
    /// pmovzxwd xmm, xmm/m64
    /// </summary>
    [Symbol("pmovzxwd xmm, m64","pmovzxwd xmm, xmm/m64")]
    pmovzxwd_xmm_m64 = 1119,
    /// <summary>
    /// pmovzxwq xmm, xmm/m32
    /// </summary>
    [Symbol("pmovzxwq xmm, xmm","pmovzxwq xmm, xmm/m32")]
    pmovzxwq_xmm_xmm = 1120,
    /// <summary>
    /// pmovzxwq xmm, xmm/m32
    /// </summary>
    [Symbol("pmovzxwq xmm, m32","pmovzxwq xmm, xmm/m32")]
    pmovzxwq_xmm_m32 = 1121,
    /// <summary>
    /// pmulhuw mm, mm/m64
    /// </summary>
    [Symbol("pmulhuw mm, mm","pmulhuw mm, mm/m64")]
    pmulhuw_mm_mm = 1122,
    /// <summary>
    /// pmulhuw mm, mm/m64
    /// </summary>
    [Symbol("pmulhuw mm, m64","pmulhuw mm, mm/m64")]
    pmulhuw_mm_m64 = 1123,
    /// <summary>
    /// pmulhuw xmm, xmm/m128
    /// </summary>
    [Symbol("pmulhuw xmm, xmm","pmulhuw xmm, xmm/m128")]
    pmulhuw_xmm_xmm = 1124,
    /// <summary>
    /// pmulhuw xmm, xmm/m128
    /// </summary>
    [Symbol("pmulhuw xmm, m128","pmulhuw xmm, xmm/m128")]
    pmulhuw_xmm_m128 = 1125,
    /// <summary>
    /// pmullw mm, mm/m64
    /// </summary>
    [Symbol("pmullw mm, mm","pmullw mm, mm/m64")]
    pmullw_mm_mm = 1126,
    /// <summary>
    /// pmullw mm, mm/m64
    /// </summary>
    [Symbol("pmullw mm, m64","pmullw mm, mm/m64")]
    pmullw_mm_m64 = 1127,
    /// <summary>
    /// pmullw xmm, xmm/m128
    /// </summary>
    [Symbol("pmullw xmm, xmm","pmullw xmm, xmm/m128")]
    pmullw_xmm_xmm = 1128,
    /// <summary>
    /// pmullw xmm, xmm/m128
    /// </summary>
    [Symbol("pmullw xmm, m128","pmullw xmm, xmm/m128")]
    pmullw_xmm_m128 = 1129,
    /// <summary>
    /// pop DS
    /// </summary>
    [Symbol("pop DS","pop DS")]
    pop_DS = 1130,
    /// <summary>
    /// pop ES
    /// </summary>
    [Symbol("pop ES","pop ES")]
    pop_ES = 1131,
    /// <summary>
    /// pop FS
    /// </summary>
    [Symbol("pop FS","pop FS")]
    pop_FS = 1132,
    /// <summary>
    /// pop GS
    /// </summary>
    [Symbol("pop GS","pop GS")]
    pop_GS = 1133,
    /// <summary>
    /// pop r/m16
    /// </summary>
    [Symbol("pop r16","pop r/m16")]
    pop_r16 = 1134,
    /// <summary>
    /// pop r/m16
    /// </summary>
    [Symbol("pop m16","pop r/m16")]
    pop_m16 = 1135,
    /// <summary>
    /// pop r/m32
    /// </summary>
    [Symbol("pop r32","pop r/m32")]
    pop_r32 = 1136,
    /// <summary>
    /// pop r/m32
    /// </summary>
    [Symbol("pop m32","pop r/m32")]
    pop_m32 = 1137,
    /// <summary>
    /// pop r/m64
    /// </summary>
    [Symbol("pop r64","pop r/m64")]
    pop_r64 = 1138,
    /// <summary>
    /// pop r/m64
    /// </summary>
    [Symbol("pop m64","pop r/m64")]
    pop_m64 = 1139,
    /// <summary>
    /// pop SS
    /// </summary>
    [Symbol("pop SS","pop SS")]
    pop_SS = 1140,
    /// <summary>
    /// popf
    /// </summary>
    [Symbol("popf","popf")]
    popf = 1141,
    /// <summary>
    /// popfd
    /// </summary>
    [Symbol("popfd","popfd")]
    popfd = 1142,
    /// <summary>
    /// popfq
    /// </summary>
    [Symbol("popfq","popfq")]
    popfq = 1143,
    /// <summary>
    /// por mm, mm/m64
    /// </summary>
    [Symbol("por mm, mm","por mm, mm/m64")]
    por_mm_mm = 1144,
    /// <summary>
    /// por mm, mm/m64
    /// </summary>
    [Symbol("por mm, m64","por mm, mm/m64")]
    por_mm_m64 = 1145,
    /// <summary>
    /// por xmm, xmm/m128
    /// </summary>
    [Symbol("por xmm, xmm","por xmm, xmm/m128")]
    por_xmm_xmm = 1146,
    /// <summary>
    /// por xmm, xmm/m128
    /// </summary>
    [Symbol("por xmm, m128","por xmm, xmm/m128")]
    por_xmm_m128 = 1147,
    /// <summary>
    /// prefetchnta m8
    /// </summary>
    [Symbol("prefetchnta m8","prefetchnta m8")]
    prefetchnta_m8 = 1148,
    /// <summary>
    /// prefetcht0 m8
    /// </summary>
    [Symbol("prefetcht0 m8","prefetcht0 m8")]
    prefetcht0_m8 = 1149,
    /// <summary>
    /// prefetcht1 m8
    /// </summary>
    [Symbol("prefetcht1 m8","prefetcht1 m8")]
    prefetcht1_m8 = 1150,
    /// <summary>
    /// prefetcht2 m8
    /// </summary>
    [Symbol("prefetcht2 m8","prefetcht2 m8")]
    prefetcht2_m8 = 1151,
    /// <summary>
    /// pshufb mm, mm/m64
    /// </summary>
    [Symbol("pshufb mm, mm","pshufb mm, mm/m64")]
    pshufb_mm_mm = 1152,
    /// <summary>
    /// pshufb mm, mm/m64
    /// </summary>
    [Symbol("pshufb mm, m64","pshufb mm, mm/m64")]
    pshufb_mm_m64 = 1153,
    /// <summary>
    /// pshufb xmm, xmm/m128
    /// </summary>
    [Symbol("pshufb xmm, xmm","pshufb xmm, xmm/m128")]
    pshufb_xmm_xmm = 1154,
    /// <summary>
    /// pshufb xmm, xmm/m128
    /// </summary>
    [Symbol("pshufb xmm, m128","pshufb xmm, xmm/m128")]
    pshufb_xmm_m128 = 1155,
    /// <summary>
    /// pshufd xmm, xmm/m128, imm8
    /// </summary>
    [Symbol("pshufd xmm, xmm, imm8","pshufd xmm, xmm/m128, imm8")]
    pshufd_xmm_xmm_imm8 = 1156,
    /// <summary>
    /// pshufd xmm, xmm/m128, imm8
    /// </summary>
    [Symbol("pshufd xmm, m128, imm8","pshufd xmm, xmm/m128, imm8")]
    pshufd_xmm_m128_imm8 = 1157,
    /// <summary>
    /// pshuflw xmm, xmm/m128, imm8
    /// </summary>
    [Symbol("pshuflw xmm, xmm, imm8","pshuflw xmm, xmm/m128, imm8")]
    pshuflw_xmm_xmm_imm8 = 1158,
    /// <summary>
    /// pshuflw xmm, xmm/m128, imm8
    /// </summary>
    [Symbol("pshuflw xmm, m128, imm8","pshuflw xmm, xmm/m128, imm8")]
    pshuflw_xmm_m128_imm8 = 1159,
    /// <summary>
    /// pshufw mm, mm/m64, imm8
    /// </summary>
    [Symbol("pshufw mm, mm, imm8","pshufw mm, mm/m64, imm8")]
    pshufw_mm_mm_imm8 = 1160,
    /// <summary>
    /// pshufw mm, mm/m64, imm8
    /// </summary>
    [Symbol("pshufw mm, m64, imm8","pshufw mm, mm/m64, imm8")]
    pshufw_mm_m64_imm8 = 1161,
    /// <summary>
    /// psignb mm, mm/m64
    /// </summary>
    [Symbol("psignb mm, mm","psignb mm, mm/m64")]
    psignb_mm_mm = 1162,
    /// <summary>
    /// psignb mm, mm/m64
    /// </summary>
    [Symbol("psignb mm, m64","psignb mm, mm/m64")]
    psignb_mm_m64 = 1163,
    /// <summary>
    /// psignb xmm, xmm/m128
    /// </summary>
    [Symbol("psignb xmm, xmm","psignb xmm, xmm/m128")]
    psignb_xmm_xmm = 1164,
    /// <summary>
    /// psignb xmm, xmm/m128
    /// </summary>
    [Symbol("psignb xmm, m128","psignb xmm, xmm/m128")]
    psignb_xmm_m128 = 1165,
    /// <summary>
    /// psignd mm, mm/m64
    /// </summary>
    [Symbol("psignd mm, mm","psignd mm, mm/m64")]
    psignd_mm_mm = 1166,
    /// <summary>
    /// psignd mm, mm/m64
    /// </summary>
    [Symbol("psignd mm, m64","psignd mm, mm/m64")]
    psignd_mm_m64 = 1167,
    /// <summary>
    /// psignd xmm, xmm/m128
    /// </summary>
    [Symbol("psignd xmm, xmm","psignd xmm, xmm/m128")]
    psignd_xmm_xmm = 1168,
    /// <summary>
    /// psignd xmm, xmm/m128
    /// </summary>
    [Symbol("psignd xmm, m128","psignd xmm, xmm/m128")]
    psignd_xmm_m128 = 1169,
    /// <summary>
    /// psignw mm, mm/m64
    /// </summary>
    [Symbol("psignw mm, mm","psignw mm, mm/m64")]
    psignw_mm_mm = 1170,
    /// <summary>
    /// psignw mm, mm/m64
    /// </summary>
    [Symbol("psignw mm, m64","psignw mm, mm/m64")]
    psignw_mm_m64 = 1171,
    /// <summary>
    /// psignw xmm, xmm/m128
    /// </summary>
    [Symbol("psignw xmm, xmm","psignw xmm, xmm/m128")]
    psignw_xmm_xmm = 1172,
    /// <summary>
    /// psignw xmm, xmm/m128
    /// </summary>
    [Symbol("psignw xmm, m128","psignw xmm, xmm/m128")]
    psignw_xmm_m128 = 1173,
    /// <summary>
    /// pslld mm, imm8
    /// </summary>
    [Symbol("pslld mm, imm8","pslld mm, imm8")]
    pslld_mm_imm8 = 1174,
    /// <summary>
    /// pslld mm, mm/m64
    /// </summary>
    [Symbol("pslld mm, mm","pslld mm, mm/m64")]
    pslld_mm_mm = 1175,
    /// <summary>
    /// pslld mm, mm/m64
    /// </summary>
    [Symbol("pslld mm, m64","pslld mm, mm/m64")]
    pslld_mm_m64 = 1176,
    /// <summary>
    /// pslld xmm, imm8
    /// </summary>
    [Symbol("pslld xmm, imm8","pslld xmm, imm8")]
    pslld_xmm_imm8 = 1177,
    /// <summary>
    /// pslld xmm, xmm/m128
    /// </summary>
    [Symbol("pslld xmm, xmm","pslld xmm, xmm/m128")]
    pslld_xmm_xmm = 1178,
    /// <summary>
    /// pslld xmm, xmm/m128
    /// </summary>
    [Symbol("pslld xmm, m128","pslld xmm, xmm/m128")]
    pslld_xmm_m128 = 1179,
    /// <summary>
    /// pslldq xmm, imm8
    /// </summary>
    [Symbol("pslldq xmm, imm8","pslldq xmm, imm8")]
    pslldq_xmm_imm8 = 1180,
    /// <summary>
    /// psllq mm, imm8
    /// </summary>
    [Symbol("psllq mm, imm8","psllq mm, imm8")]
    psllq_mm_imm8 = 1181,
    /// <summary>
    /// psllq mm, mm/m64
    /// </summary>
    [Symbol("psllq mm, mm","psllq mm, mm/m64")]
    psllq_mm_mm = 1182,
    /// <summary>
    /// psllq mm, mm/m64
    /// </summary>
    [Symbol("psllq mm, m64","psllq mm, mm/m64")]
    psllq_mm_m64 = 1183,
    /// <summary>
    /// psllq xmm, imm8
    /// </summary>
    [Symbol("psllq xmm, imm8","psllq xmm, imm8")]
    psllq_xmm_imm8 = 1184,
    /// <summary>
    /// psllq xmm, xmm/m128
    /// </summary>
    [Symbol("psllq xmm, xmm","psllq xmm, xmm/m128")]
    psllq_xmm_xmm = 1185,
    /// <summary>
    /// psllq xmm, xmm/m128
    /// </summary>
    [Symbol("psllq xmm, m128","psllq xmm, xmm/m128")]
    psllq_xmm_m128 = 1186,
    /// <summary>
    /// psllw mm, imm8
    /// </summary>
    [Symbol("psllw mm, imm8","psllw mm, imm8")]
    psllw_mm_imm8 = 1187,
    /// <summary>
    /// psllw mm, mm/m64
    /// </summary>
    [Symbol("psllw mm, mm","psllw mm, mm/m64")]
    psllw_mm_mm = 1188,
    /// <summary>
    /// psllw mm, mm/m64
    /// </summary>
    [Symbol("psllw mm, m64","psllw mm, mm/m64")]
    psllw_mm_m64 = 1189,
    /// <summary>
    /// psllw xmm, imm8
    /// </summary>
    [Symbol("psllw xmm, imm8","psllw xmm, imm8")]
    psllw_xmm_imm8 = 1190,
    /// <summary>
    /// psllw xmm, xmm/m128
    /// </summary>
    [Symbol("psllw xmm, xmm","psllw xmm, xmm/m128")]
    psllw_xmm_xmm = 1191,
    /// <summary>
    /// psllw xmm, xmm/m128
    /// </summary>
    [Symbol("psllw xmm, m128","psllw xmm, xmm/m128")]
    psllw_xmm_m128 = 1192,
    /// <summary>
    /// psrad mm, imm8
    /// </summary>
    [Symbol("psrad mm, imm8","psrad mm, imm8")]
    psrad_mm_imm8 = 1193,
    /// <summary>
    /// psrad mm, mm/m64
    /// </summary>
    [Symbol("psrad mm, mm","psrad mm, mm/m64")]
    psrad_mm_mm = 1194,
    /// <summary>
    /// psrad mm, mm/m64
    /// </summary>
    [Symbol("psrad mm, m64","psrad mm, mm/m64")]
    psrad_mm_m64 = 1195,
    /// <summary>
    /// psrad xmm, imm8
    /// </summary>
    [Symbol("psrad xmm, imm8","psrad xmm, imm8")]
    psrad_xmm_imm8 = 1196,
    /// <summary>
    /// psrad xmm, xmm/m128
    /// </summary>
    [Symbol("psrad xmm, xmm","psrad xmm, xmm/m128")]
    psrad_xmm_xmm = 1197,
    /// <summary>
    /// psrad xmm, xmm/m128
    /// </summary>
    [Symbol("psrad xmm, m128","psrad xmm, xmm/m128")]
    psrad_xmm_m128 = 1198,
    /// <summary>
    /// psraw mm, imm8
    /// </summary>
    [Symbol("psraw mm, imm8","psraw mm, imm8")]
    psraw_mm_imm8 = 1199,
    /// <summary>
    /// psraw mm, mm/m64
    /// </summary>
    [Symbol("psraw mm, mm","psraw mm, mm/m64")]
    psraw_mm_mm = 1200,
    /// <summary>
    /// psraw mm, mm/m64
    /// </summary>
    [Symbol("psraw mm, m64","psraw mm, mm/m64")]
    psraw_mm_m64 = 1201,
    /// <summary>
    /// psraw xmm, imm8
    /// </summary>
    [Symbol("psraw xmm, imm8","psraw xmm, imm8")]
    psraw_xmm_imm8 = 1202,
    /// <summary>
    /// psraw xmm, xmm/m128
    /// </summary>
    [Symbol("psraw xmm, xmm","psraw xmm, xmm/m128")]
    psraw_xmm_xmm = 1203,
    /// <summary>
    /// psraw xmm, xmm/m128
    /// </summary>
    [Symbol("psraw xmm, m128","psraw xmm, xmm/m128")]
    psraw_xmm_m128 = 1204,
    /// <summary>
    /// psrld mm, imm8
    /// </summary>
    [Symbol("psrld mm, imm8","psrld mm, imm8")]
    psrld_mm_imm8 = 1205,
    /// <summary>
    /// psrld mm, mm/m64
    /// </summary>
    [Symbol("psrld mm, mm","psrld mm, mm/m64")]
    psrld_mm_mm = 1206,
    /// <summary>
    /// psrld mm, mm/m64
    /// </summary>
    [Symbol("psrld mm, m64","psrld mm, mm/m64")]
    psrld_mm_m64 = 1207,
    /// <summary>
    /// psrld xmm, imm8
    /// </summary>
    [Symbol("psrld xmm, imm8","psrld xmm, imm8")]
    psrld_xmm_imm8 = 1208,
    /// <summary>
    /// psrld xmm, xmm/m128
    /// </summary>
    [Symbol("psrld xmm, xmm","psrld xmm, xmm/m128")]
    psrld_xmm_xmm = 1209,
    /// <summary>
    /// psrld xmm, xmm/m128
    /// </summary>
    [Symbol("psrld xmm, m128","psrld xmm, xmm/m128")]
    psrld_xmm_m128 = 1210,
    /// <summary>
    /// psrlq mm, imm8
    /// </summary>
    [Symbol("psrlq mm, imm8","psrlq mm, imm8")]
    psrlq_mm_imm8 = 1211,
    /// <summary>
    /// psrlq mm, mm/m64
    /// </summary>
    [Symbol("psrlq mm, mm","psrlq mm, mm/m64")]
    psrlq_mm_mm = 1212,
    /// <summary>
    /// psrlq mm, mm/m64
    /// </summary>
    [Symbol("psrlq mm, m64","psrlq mm, mm/m64")]
    psrlq_mm_m64 = 1213,
    /// <summary>
    /// psrlq xmm, imm8
    /// </summary>
    [Symbol("psrlq xmm, imm8","psrlq xmm, imm8")]
    psrlq_xmm_imm8 = 1214,
    /// <summary>
    /// psrlq xmm, xmm/m128
    /// </summary>
    [Symbol("psrlq xmm, xmm","psrlq xmm, xmm/m128")]
    psrlq_xmm_xmm = 1215,
    /// <summary>
    /// psrlq xmm, xmm/m128
    /// </summary>
    [Symbol("psrlq xmm, m128","psrlq xmm, xmm/m128")]
    psrlq_xmm_m128 = 1216,
    /// <summary>
    /// psrlw mm, imm8
    /// </summary>
    [Symbol("psrlw mm, imm8","psrlw mm, imm8")]
    psrlw_mm_imm8 = 1217,
    /// <summary>
    /// psrlw mm, mm/m64
    /// </summary>
    [Symbol("psrlw mm, mm","psrlw mm, mm/m64")]
    psrlw_mm_mm = 1218,
    /// <summary>
    /// psrlw mm, mm/m64
    /// </summary>
    [Symbol("psrlw mm, m64","psrlw mm, mm/m64")]
    psrlw_mm_m64 = 1219,
    /// <summary>
    /// psrlw xmm, imm8
    /// </summary>
    [Symbol("psrlw xmm, imm8","psrlw xmm, imm8")]
    psrlw_xmm_imm8 = 1220,
    /// <summary>
    /// psrlw xmm, xmm/m128
    /// </summary>
    [Symbol("psrlw xmm, xmm","psrlw xmm, xmm/m128")]
    psrlw_xmm_xmm = 1221,
    /// <summary>
    /// psrlw xmm, xmm/m128
    /// </summary>
    [Symbol("psrlw xmm, m128","psrlw xmm, xmm/m128")]
    psrlw_xmm_m128 = 1222,
    /// <summary>
    /// psubb mm, mm/m64
    /// </summary>
    [Symbol("psubb mm, mm","psubb mm, mm/m64")]
    psubb_mm_mm = 1223,
    /// <summary>
    /// psubb mm, mm/m64
    /// </summary>
    [Symbol("psubb mm, m64","psubb mm, mm/m64")]
    psubb_mm_m64 = 1224,
    /// <summary>
    /// psubb xmm, xmm/m128
    /// </summary>
    [Symbol("psubb xmm, xmm","psubb xmm, xmm/m128")]
    psubb_xmm_xmm = 1225,
    /// <summary>
    /// psubb xmm, xmm/m128
    /// </summary>
    [Symbol("psubb xmm, m128","psubb xmm, xmm/m128")]
    psubb_xmm_m128 = 1226,
    /// <summary>
    /// psubd mm, mm/m64
    /// </summary>
    [Symbol("psubd mm, mm","psubd mm, mm/m64")]
    psubd_mm_mm = 1227,
    /// <summary>
    /// psubd mm, mm/m64
    /// </summary>
    [Symbol("psubd mm, m64","psubd mm, mm/m64")]
    psubd_mm_m64 = 1228,
    /// <summary>
    /// psubd xmm, xmm/m128
    /// </summary>
    [Symbol("psubd xmm, xmm","psubd xmm, xmm/m128")]
    psubd_xmm_xmm = 1229,
    /// <summary>
    /// psubd xmm, xmm/m128
    /// </summary>
    [Symbol("psubd xmm, m128","psubd xmm, xmm/m128")]
    psubd_xmm_m128 = 1230,
    /// <summary>
    /// psubq mm, mm/m64
    /// </summary>
    [Symbol("psubq mm, mm","psubq mm, mm/m64")]
    psubq_mm_mm = 1231,
    /// <summary>
    /// psubq mm, mm/m64
    /// </summary>
    [Symbol("psubq mm, m64","psubq mm, mm/m64")]
    psubq_mm_m64 = 1232,
    /// <summary>
    /// psubq xmm, xmm/m128
    /// </summary>
    [Symbol("psubq xmm, xmm","psubq xmm, xmm/m128")]
    psubq_xmm_xmm = 1233,
    /// <summary>
    /// psubq xmm, xmm/m128
    /// </summary>
    [Symbol("psubq xmm, m128","psubq xmm, xmm/m128")]
    psubq_xmm_m128 = 1234,
    /// <summary>
    /// psubsb mm, mm/m64
    /// </summary>
    [Symbol("psubsb mm, mm","psubsb mm, mm/m64")]
    psubsb_mm_mm = 1235,
    /// <summary>
    /// psubsb mm, mm/m64
    /// </summary>
    [Symbol("psubsb mm, m64","psubsb mm, mm/m64")]
    psubsb_mm_m64 = 1236,
    /// <summary>
    /// psubsb xmm, xmm/m128
    /// </summary>
    [Symbol("psubsb xmm, xmm","psubsb xmm, xmm/m128")]
    psubsb_xmm_xmm = 1237,
    /// <summary>
    /// psubsb xmm, xmm/m128
    /// </summary>
    [Symbol("psubsb xmm, m128","psubsb xmm, xmm/m128")]
    psubsb_xmm_m128 = 1238,
    /// <summary>
    /// psubsw mm, mm/m64
    /// </summary>
    [Symbol("psubsw mm, mm","psubsw mm, mm/m64")]
    psubsw_mm_mm = 1239,
    /// <summary>
    /// psubsw mm, mm/m64
    /// </summary>
    [Symbol("psubsw mm, m64","psubsw mm, mm/m64")]
    psubsw_mm_m64 = 1240,
    /// <summary>
    /// psubsw xmm, xmm/m128
    /// </summary>
    [Symbol("psubsw xmm, xmm","psubsw xmm, xmm/m128")]
    psubsw_xmm_xmm = 1241,
    /// <summary>
    /// psubsw xmm, xmm/m128
    /// </summary>
    [Symbol("psubsw xmm, m128","psubsw xmm, xmm/m128")]
    psubsw_xmm_m128 = 1242,
    /// <summary>
    /// psubusb mm, mm/m64
    /// </summary>
    [Symbol("psubusb mm, mm","psubusb mm, mm/m64")]
    psubusb_mm_mm = 1243,
    /// <summary>
    /// psubusb mm, mm/m64
    /// </summary>
    [Symbol("psubusb mm, m64","psubusb mm, mm/m64")]
    psubusb_mm_m64 = 1244,
    /// <summary>
    /// psubusb xmm, xmm/m128
    /// </summary>
    [Symbol("psubusb xmm, xmm","psubusb xmm, xmm/m128")]
    psubusb_xmm_xmm = 1245,
    /// <summary>
    /// psubusb xmm, xmm/m128
    /// </summary>
    [Symbol("psubusb xmm, m128","psubusb xmm, xmm/m128")]
    psubusb_xmm_m128 = 1246,
    /// <summary>
    /// psubusw mm, mm/m64
    /// </summary>
    [Symbol("psubusw mm, mm","psubusw mm, mm/m64")]
    psubusw_mm_mm = 1247,
    /// <summary>
    /// psubusw mm, mm/m64
    /// </summary>
    [Symbol("psubusw mm, m64","psubusw mm, mm/m64")]
    psubusw_mm_m64 = 1248,
    /// <summary>
    /// psubusw xmm, xmm/m128
    /// </summary>
    [Symbol("psubusw xmm, xmm","psubusw xmm, xmm/m128")]
    psubusw_xmm_xmm = 1249,
    /// <summary>
    /// psubusw xmm, xmm/m128
    /// </summary>
    [Symbol("psubusw xmm, m128","psubusw xmm, xmm/m128")]
    psubusw_xmm_m128 = 1250,
    /// <summary>
    /// psubw mm, mm/m64
    /// </summary>
    [Symbol("psubw mm, mm","psubw mm, mm/m64")]
    psubw_mm_mm = 1251,
    /// <summary>
    /// psubw mm, mm/m64
    /// </summary>
    [Symbol("psubw mm, m64","psubw mm, mm/m64")]
    psubw_mm_m64 = 1252,
    /// <summary>
    /// psubw xmm, xmm/m128
    /// </summary>
    [Symbol("psubw xmm, xmm","psubw xmm, xmm/m128")]
    psubw_xmm_xmm = 1253,
    /// <summary>
    /// psubw xmm, xmm/m128
    /// </summary>
    [Symbol("psubw xmm, m128","psubw xmm, xmm/m128")]
    psubw_xmm_m128 = 1254,
    /// <summary>
    /// ptest xmm, xmm/m128
    /// </summary>
    [Symbol("ptest xmm, xmm","ptest xmm, xmm/m128")]
    ptest_xmm_xmm = 1255,
    /// <summary>
    /// ptest xmm, xmm/m128
    /// </summary>
    [Symbol("ptest xmm, m128","ptest xmm, xmm/m128")]
    ptest_xmm_m128 = 1256,
    /// <summary>
    /// punpckhbw mm, mm/m64
    /// </summary>
    [Symbol("punpckhbw mm, mm","punpckhbw mm, mm/m64")]
    punpckhbw_mm_mm = 1257,
    /// <summary>
    /// punpckhbw mm, mm/m64
    /// </summary>
    [Symbol("punpckhbw mm, m64","punpckhbw mm, mm/m64")]
    punpckhbw_mm_m64 = 1258,
    /// <summary>
    /// punpckhbw xmm, xmm/m128
    /// </summary>
    [Symbol("punpckhbw xmm, xmm","punpckhbw xmm, xmm/m128")]
    punpckhbw_xmm_xmm = 1259,
    /// <summary>
    /// punpckhbw xmm, xmm/m128
    /// </summary>
    [Symbol("punpckhbw xmm, m128","punpckhbw xmm, xmm/m128")]
    punpckhbw_xmm_m128 = 1260,
    /// <summary>
    /// punpckhdq mm, mm/m64
    /// </summary>
    [Symbol("punpckhdq mm, mm","punpckhdq mm, mm/m64")]
    punpckhdq_mm_mm = 1261,
    /// <summary>
    /// punpckhdq mm, mm/m64
    /// </summary>
    [Symbol("punpckhdq mm, m64","punpckhdq mm, mm/m64")]
    punpckhdq_mm_m64 = 1262,
    /// <summary>
    /// punpckhdq xmm, xmm/m128
    /// </summary>
    [Symbol("punpckhdq xmm, xmm","punpckhdq xmm, xmm/m128")]
    punpckhdq_xmm_xmm = 1263,
    /// <summary>
    /// punpckhdq xmm, xmm/m128
    /// </summary>
    [Symbol("punpckhdq xmm, m128","punpckhdq xmm, xmm/m128")]
    punpckhdq_xmm_m128 = 1264,
    /// <summary>
    /// punpckhqdq xmm, xmm/m128
    /// </summary>
    [Symbol("punpckhqdq xmm, xmm","punpckhqdq xmm, xmm/m128")]
    punpckhqdq_xmm_xmm = 1265,
    /// <summary>
    /// punpckhqdq xmm, xmm/m128
    /// </summary>
    [Symbol("punpckhqdq xmm, m128","punpckhqdq xmm, xmm/m128")]
    punpckhqdq_xmm_m128 = 1266,
    /// <summary>
    /// punpckhwd mm, mm/m64
    /// </summary>
    [Symbol("punpckhwd mm, mm","punpckhwd mm, mm/m64")]
    punpckhwd_mm_mm = 1267,
    /// <summary>
    /// punpckhwd mm, mm/m64
    /// </summary>
    [Symbol("punpckhwd mm, m64","punpckhwd mm, mm/m64")]
    punpckhwd_mm_m64 = 1268,
    /// <summary>
    /// punpckhwd xmm, xmm/m128
    /// </summary>
    [Symbol("punpckhwd xmm, xmm","punpckhwd xmm, xmm/m128")]
    punpckhwd_xmm_xmm = 1269,
    /// <summary>
    /// punpckhwd xmm, xmm/m128
    /// </summary>
    [Symbol("punpckhwd xmm, m128","punpckhwd xmm, xmm/m128")]
    punpckhwd_xmm_m128 = 1270,
    /// <summary>
    /// punpckldq mm, mm/m32
    /// </summary>
    [Symbol("punpckldq mm, mm","punpckldq mm, mm/m32")]
    punpckldq_mm_mm = 1271,
    /// <summary>
    /// punpckldq mm, mm/m32
    /// </summary>
    [Symbol("punpckldq mm, m32","punpckldq mm, mm/m32")]
    punpckldq_mm_m32 = 1272,
    /// <summary>
    /// punpckldq xmm, xmm/m128
    /// </summary>
    [Symbol("punpckldq xmm, xmm","punpckldq xmm, xmm/m128")]
    punpckldq_xmm_xmm = 1273,
    /// <summary>
    /// punpckldq xmm, xmm/m128
    /// </summary>
    [Symbol("punpckldq xmm, m128","punpckldq xmm, xmm/m128")]
    punpckldq_xmm_m128 = 1274,
    /// <summary>
    /// punpcklqdq xmm, xmm/m128
    /// </summary>
    [Symbol("punpcklqdq xmm, xmm","punpcklqdq xmm, xmm/m128")]
    punpcklqdq_xmm_xmm = 1275,
    /// <summary>
    /// punpcklqdq xmm, xmm/m128
    /// </summary>
    [Symbol("punpcklqdq xmm, m128","punpcklqdq xmm, xmm/m128")]
    punpcklqdq_xmm_m128 = 1276,
    /// <summary>
    /// push CS
    /// </summary>
    [Symbol("push CS","push CS")]
    push_CS = 1277,
    /// <summary>
    /// push DS
    /// </summary>
    [Symbol("push DS","push DS")]
    push_DS = 1278,
    /// <summary>
    /// push ES
    /// </summary>
    [Symbol("push ES","push ES")]
    push_ES = 1279,
    /// <summary>
    /// push FS
    /// </summary>
    [Symbol("push FS","push FS")]
    push_FS = 1280,
    /// <summary>
    /// push GS
    /// </summary>
    [Symbol("push GS","push GS")]
    push_GS = 1281,
    /// <summary>
    /// push imm16
    /// </summary>
    [Symbol("push imm16","push imm16")]
    push_imm16 = 1282,
    /// <summary>
    /// push imm32
    /// </summary>
    [Symbol("push imm32","push imm32")]
    push_imm32 = 1283,
    /// <summary>
    /// push imm8
    /// </summary>
    [Symbol("push imm8","push imm8")]
    push_imm8 = 1284,
    /// <summary>
    /// push r/m16
    /// </summary>
    [Symbol("push r16","push r/m16")]
    push_r16 = 1285,
    /// <summary>
    /// push r/m16
    /// </summary>
    [Symbol("push m16","push r/m16")]
    push_m16 = 1286,
    /// <summary>
    /// push r/m32
    /// </summary>
    [Symbol("push r32","push r/m32")]
    push_r32 = 1287,
    /// <summary>
    /// push r/m32
    /// </summary>
    [Symbol("push m32","push r/m32")]
    push_m32 = 1288,
    /// <summary>
    /// push r/m64
    /// </summary>
    [Symbol("push r64","push r/m64")]
    push_r64 = 1289,
    /// <summary>
    /// push r/m64
    /// </summary>
    [Symbol("push m64","push r/m64")]
    push_m64 = 1290,
    /// <summary>
    /// push SS
    /// </summary>
    [Symbol("push SS","push SS")]
    push_SS = 1291,
    /// <summary>
    /// pushf
    /// </summary>
    [Symbol("pushf","pushf")]
    pushf = 1292,
    /// <summary>
    /// pushfd
    /// </summary>
    [Symbol("pushfd","pushfd")]
    pushfd = 1293,
    /// <summary>
    /// pushfq
    /// </summary>
    [Symbol("pushfq","pushfq")]
    pushfq = 1294,
    /// <summary>
    /// pxor mm, mm/m64
    /// </summary>
    [Symbol("pxor mm, mm","pxor mm, mm/m64")]
    pxor_mm_mm = 1295,
    /// <summary>
    /// pxor mm, mm/m64
    /// </summary>
    [Symbol("pxor mm, m64","pxor mm, mm/m64")]
    pxor_mm_m64 = 1296,
    /// <summary>
    /// pxor xmm, xmm/m128
    /// </summary>
    [Symbol("pxor xmm, xmm","pxor xmm, xmm/m128")]
    pxor_xmm_xmm = 1297,
    /// <summary>
    /// pxor xmm, xmm/m128
    /// </summary>
    [Symbol("pxor xmm, m128","pxor xmm, xmm/m128")]
    pxor_xmm_m128 = 1298,
    /// <summary>
    /// rcl r/m16, 1
    /// </summary>
    [Symbol("rcl r16, 1","rcl r/m16, 1")]
    rcl_r16_1 = 1299,
    /// <summary>
    /// rcl r/m16, 1
    /// </summary>
    [Symbol("rcl m16, 1","rcl r/m16, 1")]
    rcl_m16_1 = 1300,
    /// <summary>
    /// rcl r/m16, CL
    /// </summary>
    [Symbol("rcl r16, CL","rcl r/m16, CL")]
    rcl_r16_CL = 1301,
    /// <summary>
    /// rcl r/m16, CL
    /// </summary>
    [Symbol("rcl m16, CL","rcl r/m16, CL")]
    rcl_m16_CL = 1302,
    /// <summary>
    /// rcl r/m16, imm8
    /// </summary>
    [Symbol("rcl r16, imm8","rcl r/m16, imm8")]
    rcl_r16_imm8 = 1303,
    /// <summary>
    /// rcl r/m16, imm8
    /// </summary>
    [Symbol("rcl m16, imm8","rcl r/m16, imm8")]
    rcl_m16_imm8 = 1304,
    /// <summary>
    /// rcl r/m32, 1
    /// </summary>
    [Symbol("rcl r32, 1","rcl r/m32, 1")]
    rcl_r32_1 = 1305,
    /// <summary>
    /// rcl r/m32, 1
    /// </summary>
    [Symbol("rcl m32, 1","rcl r/m32, 1")]
    rcl_m32_1 = 1306,
    /// <summary>
    /// rcl r/m32, CL
    /// </summary>
    [Symbol("rcl r32, CL","rcl r/m32, CL")]
    rcl_r32_CL = 1307,
    /// <summary>
    /// rcl r/m32, CL
    /// </summary>
    [Symbol("rcl m32, CL","rcl r/m32, CL")]
    rcl_m32_CL = 1308,
    /// <summary>
    /// rcl r/m32, imm8
    /// </summary>
    [Symbol("rcl r32, imm8","rcl r/m32, imm8")]
    rcl_r32_imm8 = 1309,
    /// <summary>
    /// rcl r/m32, imm8
    /// </summary>
    [Symbol("rcl m32, imm8","rcl r/m32, imm8")]
    rcl_m32_imm8 = 1310,
    /// <summary>
    /// rcl r/m64, 1
    /// </summary>
    [Symbol("rcl r64, 1","rcl r/m64, 1")]
    rcl_r64_1 = 1311,
    /// <summary>
    /// rcl r/m64, 1
    /// </summary>
    [Symbol("rcl m64, 1","rcl r/m64, 1")]
    rcl_m64_1 = 1312,
    /// <summary>
    /// rcl r/m64, CL
    /// </summary>
    [Symbol("rcl r64, CL","rcl r/m64, CL")]
    rcl_r64_CL = 1313,
    /// <summary>
    /// rcl r/m64, CL
    /// </summary>
    [Symbol("rcl m64, CL","rcl r/m64, CL")]
    rcl_m64_CL = 1314,
    /// <summary>
    /// rcl r/m64, imm8
    /// </summary>
    [Symbol("rcl r64, imm8","rcl r/m64, imm8")]
    rcl_r64_imm8 = 1315,
    /// <summary>
    /// rcl r/m64, imm8
    /// </summary>
    [Symbol("rcl m64, imm8","rcl r/m64, imm8")]
    rcl_m64_imm8 = 1316,
    /// <summary>
    /// rcl r/m8, 1
    /// </summary>
    [Symbol("rcl r8, 1","rcl r/m8, 1")]
    rcl_r8_1 = 1317,
    /// <summary>
    /// rcl r/m8, 1
    /// </summary>
    [Symbol("rcl m8, 1","rcl r/m8, 1")]
    rcl_m8_1 = 1318,
    /// <summary>
    /// rcl r/m8, CL
    /// </summary>
    [Symbol("rcl r8, CL","rcl r/m8, CL")]
    rcl_r8_CL = 1319,
    /// <summary>
    /// rcl r/m8, CL
    /// </summary>
    [Symbol("rcl m8, CL","rcl r/m8, CL")]
    rcl_m8_CL = 1320,
    /// <summary>
    /// rcl r/m8, imm8
    /// </summary>
    [Symbol("rcl r8, imm8","rcl r/m8, imm8")]
    rcl_r8_imm8 = 1321,
    /// <summary>
    /// rcl r/m8, imm8
    /// </summary>
    [Symbol("rcl m8, imm8","rcl r/m8, imm8")]
    rcl_m8_imm8 = 1322,
    /// <summary>
    /// rcr r/m16, 1
    /// </summary>
    [Symbol("rcr r16, 1","rcr r/m16, 1")]
    rcr_r16_1 = 1323,
    /// <summary>
    /// rcr r/m16, 1
    /// </summary>
    [Symbol("rcr m16, 1","rcr r/m16, 1")]
    rcr_m16_1 = 1324,
    /// <summary>
    /// rcr r/m16, CL
    /// </summary>
    [Symbol("rcr r16, CL","rcr r/m16, CL")]
    rcr_r16_CL = 1325,
    /// <summary>
    /// rcr r/m16, CL
    /// </summary>
    [Symbol("rcr m16, CL","rcr r/m16, CL")]
    rcr_m16_CL = 1326,
    /// <summary>
    /// rcr r/m16, imm8
    /// </summary>
    [Symbol("rcr r16, imm8","rcr r/m16, imm8")]
    rcr_r16_imm8 = 1327,
    /// <summary>
    /// rcr r/m16, imm8
    /// </summary>
    [Symbol("rcr m16, imm8","rcr r/m16, imm8")]
    rcr_m16_imm8 = 1328,
    /// <summary>
    /// rcr r/m32, 1
    /// </summary>
    [Symbol("rcr r32, 1","rcr r/m32, 1")]
    rcr_r32_1 = 1329,
    /// <summary>
    /// rcr r/m32, 1
    /// </summary>
    [Symbol("rcr m32, 1","rcr r/m32, 1")]
    rcr_m32_1 = 1330,
    /// <summary>
    /// rcr r/m32, CL
    /// </summary>
    [Symbol("rcr r32, CL","rcr r/m32, CL")]
    rcr_r32_CL = 1331,
    /// <summary>
    /// rcr r/m32, CL
    /// </summary>
    [Symbol("rcr m32, CL","rcr r/m32, CL")]
    rcr_m32_CL = 1332,
    /// <summary>
    /// rcr r/m32, imm8
    /// </summary>
    [Symbol("rcr r32, imm8","rcr r/m32, imm8")]
    rcr_r32_imm8 = 1333,
    /// <summary>
    /// rcr r/m32, imm8
    /// </summary>
    [Symbol("rcr m32, imm8","rcr r/m32, imm8")]
    rcr_m32_imm8 = 1334,
    /// <summary>
    /// rcr r/m64, 1
    /// </summary>
    [Symbol("rcr r64, 1","rcr r/m64, 1")]
    rcr_r64_1 = 1335,
    /// <summary>
    /// rcr r/m64, 1
    /// </summary>
    [Symbol("rcr m64, 1","rcr r/m64, 1")]
    rcr_m64_1 = 1336,
    /// <summary>
    /// rcr r/m64, CL
    /// </summary>
    [Symbol("rcr r64, CL","rcr r/m64, CL")]
    rcr_r64_CL = 1337,
    /// <summary>
    /// rcr r/m64, CL
    /// </summary>
    [Symbol("rcr m64, CL","rcr r/m64, CL")]
    rcr_m64_CL = 1338,
    /// <summary>
    /// rcr r/m64, imm8
    /// </summary>
    [Symbol("rcr r64, imm8","rcr r/m64, imm8")]
    rcr_r64_imm8 = 1339,
    /// <summary>
    /// rcr r/m64, imm8
    /// </summary>
    [Symbol("rcr m64, imm8","rcr r/m64, imm8")]
    rcr_m64_imm8 = 1340,
    /// <summary>
    /// rcr r/m8, 1
    /// </summary>
    [Symbol("rcr r8, 1","rcr r/m8, 1")]
    rcr_r8_1 = 1341,
    /// <summary>
    /// rcr r/m8, 1
    /// </summary>
    [Symbol("rcr m8, 1","rcr r/m8, 1")]
    rcr_m8_1 = 1342,
    /// <summary>
    /// rcr r/m8, CL
    /// </summary>
    [Symbol("rcr r8, CL","rcr r/m8, CL")]
    rcr_r8_CL = 1343,
    /// <summary>
    /// rcr r/m8, CL
    /// </summary>
    [Symbol("rcr m8, CL","rcr r/m8, CL")]
    rcr_m8_CL = 1344,
    /// <summary>
    /// rcr r/m8, imm8
    /// </summary>
    [Symbol("rcr r8, imm8","rcr r/m8, imm8")]
    rcr_r8_imm8 = 1345,
    /// <summary>
    /// rcr r/m8, imm8
    /// </summary>
    [Symbol("rcr m8, imm8","rcr r/m8, imm8")]
    rcr_m8_imm8 = 1346,
    /// <summary>
    /// rdfsbase r32
    /// </summary>
    [Symbol("rdfsbase r32","rdfsbase r32")]
    rdfsbase_r32 = 1347,
    /// <summary>
    /// rdfsbase r64
    /// </summary>
    [Symbol("rdfsbase r64","rdfsbase r64")]
    rdfsbase_r64 = 1348,
    /// <summary>
    /// rdgsbase r32
    /// </summary>
    [Symbol("rdgsbase r32","rdgsbase r32")]
    rdgsbase_r32 = 1349,
    /// <summary>
    /// rdgsbase r64
    /// </summary>
    [Symbol("rdgsbase r64","rdgsbase r64")]
    rdgsbase_r64 = 1350,
    /// <summary>
    /// rdtsc
    /// </summary>
    [Symbol("rdtsc","rdtsc")]
    rdtsc = 1351,
    /// <summary>
    /// rol r/m16, 1
    /// </summary>
    [Symbol("rol r16, 1","rol r/m16, 1")]
    rol_r16_1 = 1352,
    /// <summary>
    /// rol r/m16, 1
    /// </summary>
    [Symbol("rol m16, 1","rol r/m16, 1")]
    rol_m16_1 = 1353,
    /// <summary>
    /// rol r/m16, CL
    /// </summary>
    [Symbol("rol r16, CL","rol r/m16, CL")]
    rol_r16_CL = 1354,
    /// <summary>
    /// rol r/m16, CL
    /// </summary>
    [Symbol("rol m16, CL","rol r/m16, CL")]
    rol_m16_CL = 1355,
    /// <summary>
    /// rol r/m16, imm8
    /// </summary>
    [Symbol("rol r16, imm8","rol r/m16, imm8")]
    rol_r16_imm8 = 1356,
    /// <summary>
    /// rol r/m16, imm8
    /// </summary>
    [Symbol("rol m16, imm8","rol r/m16, imm8")]
    rol_m16_imm8 = 1357,
    /// <summary>
    /// rol r/m32, 1
    /// </summary>
    [Symbol("rol r32, 1","rol r/m32, 1")]
    rol_r32_1 = 1358,
    /// <summary>
    /// rol r/m32, 1
    /// </summary>
    [Symbol("rol m32, 1","rol r/m32, 1")]
    rol_m32_1 = 1359,
    /// <summary>
    /// rol r/m32, CL
    /// </summary>
    [Symbol("rol r32, CL","rol r/m32, CL")]
    rol_r32_CL = 1360,
    /// <summary>
    /// rol r/m32, CL
    /// </summary>
    [Symbol("rol m32, CL","rol r/m32, CL")]
    rol_m32_CL = 1361,
    /// <summary>
    /// rol r/m32, imm8
    /// </summary>
    [Symbol("rol r32, imm8","rol r/m32, imm8")]
    rol_r32_imm8 = 1362,
    /// <summary>
    /// rol r/m32, imm8
    /// </summary>
    [Symbol("rol m32, imm8","rol r/m32, imm8")]
    rol_m32_imm8 = 1363,
    /// <summary>
    /// rol r/m64, 1
    /// </summary>
    [Symbol("rol r64, 1","rol r/m64, 1")]
    rol_r64_1 = 1364,
    /// <summary>
    /// rol r/m64, 1
    /// </summary>
    [Symbol("rol m64, 1","rol r/m64, 1")]
    rol_m64_1 = 1365,
    /// <summary>
    /// rol r/m64, CL
    /// </summary>
    [Symbol("rol r64, CL","rol r/m64, CL")]
    rol_r64_CL = 1366,
    /// <summary>
    /// rol r/m64, CL
    /// </summary>
    [Symbol("rol m64, CL","rol r/m64, CL")]
    rol_m64_CL = 1367,
    /// <summary>
    /// rol r/m64, imm8
    /// </summary>
    [Symbol("rol r64, imm8","rol r/m64, imm8")]
    rol_r64_imm8 = 1368,
    /// <summary>
    /// rol r/m64, imm8
    /// </summary>
    [Symbol("rol m64, imm8","rol r/m64, imm8")]
    rol_m64_imm8 = 1369,
    /// <summary>
    /// rol r/m8, 1
    /// </summary>
    [Symbol("rol r8, 1","rol r/m8, 1")]
    rol_r8_1 = 1370,
    /// <summary>
    /// rol r/m8, 1
    /// </summary>
    [Symbol("rol m8, 1","rol r/m8, 1")]
    rol_m8_1 = 1371,
    /// <summary>
    /// rol r/m8, CL
    /// </summary>
    [Symbol("rol r8, CL","rol r/m8, CL")]
    rol_r8_CL = 1372,
    /// <summary>
    /// rol r/m8, CL
    /// </summary>
    [Symbol("rol m8, CL","rol r/m8, CL")]
    rol_m8_CL = 1373,
    /// <summary>
    /// rol r/m8, imm8
    /// </summary>
    [Symbol("rol r8, imm8","rol r/m8, imm8")]
    rol_r8_imm8 = 1374,
    /// <summary>
    /// rol r/m8, imm8
    /// </summary>
    [Symbol("rol m8, imm8","rol r/m8, imm8")]
    rol_m8_imm8 = 1375,
    /// <summary>
    /// ror r/m16, 1
    /// </summary>
    [Symbol("ror r16, 1","ror r/m16, 1")]
    ror_r16_1 = 1376,
    /// <summary>
    /// ror r/m16, 1
    /// </summary>
    [Symbol("ror m16, 1","ror r/m16, 1")]
    ror_m16_1 = 1377,
    /// <summary>
    /// ror r/m16, CL
    /// </summary>
    [Symbol("ror r16, CL","ror r/m16, CL")]
    ror_r16_CL = 1378,
    /// <summary>
    /// ror r/m16, CL
    /// </summary>
    [Symbol("ror m16, CL","ror r/m16, CL")]
    ror_m16_CL = 1379,
    /// <summary>
    /// ror r/m16, imm8
    /// </summary>
    [Symbol("ror r16, imm8","ror r/m16, imm8")]
    ror_r16_imm8 = 1380,
    /// <summary>
    /// ror r/m16, imm8
    /// </summary>
    [Symbol("ror m16, imm8","ror r/m16, imm8")]
    ror_m16_imm8 = 1381,
    /// <summary>
    /// ror r/m32, 1
    /// </summary>
    [Symbol("ror r32, 1","ror r/m32, 1")]
    ror_r32_1 = 1382,
    /// <summary>
    /// ror r/m32, 1
    /// </summary>
    [Symbol("ror m32, 1","ror r/m32, 1")]
    ror_m32_1 = 1383,
    /// <summary>
    /// ror r/m32, CL
    /// </summary>
    [Symbol("ror r32, CL","ror r/m32, CL")]
    ror_r32_CL = 1384,
    /// <summary>
    /// ror r/m32, CL
    /// </summary>
    [Symbol("ror m32, CL","ror r/m32, CL")]
    ror_m32_CL = 1385,
    /// <summary>
    /// ror r/m32, imm8
    /// </summary>
    [Symbol("ror r32, imm8","ror r/m32, imm8")]
    ror_r32_imm8 = 1386,
    /// <summary>
    /// ror r/m32, imm8
    /// </summary>
    [Symbol("ror m32, imm8","ror r/m32, imm8")]
    ror_m32_imm8 = 1387,
    /// <summary>
    /// ror r/m64, 1
    /// </summary>
    [Symbol("ror r64, 1","ror r/m64, 1")]
    ror_r64_1 = 1388,
    /// <summary>
    /// ror r/m64, 1
    /// </summary>
    [Symbol("ror m64, 1","ror r/m64, 1")]
    ror_m64_1 = 1389,
    /// <summary>
    /// ror r/m64, CL
    /// </summary>
    [Symbol("ror r64, CL","ror r/m64, CL")]
    ror_r64_CL = 1390,
    /// <summary>
    /// ror r/m64, CL
    /// </summary>
    [Symbol("ror m64, CL","ror r/m64, CL")]
    ror_m64_CL = 1391,
    /// <summary>
    /// ror r/m64, imm8
    /// </summary>
    [Symbol("ror r64, imm8","ror r/m64, imm8")]
    ror_r64_imm8 = 1392,
    /// <summary>
    /// ror r/m64, imm8
    /// </summary>
    [Symbol("ror m64, imm8","ror r/m64, imm8")]
    ror_m64_imm8 = 1393,
    /// <summary>
    /// ror r/m8, 1
    /// </summary>
    [Symbol("ror r8, 1","ror r/m8, 1")]
    ror_r8_1 = 1394,
    /// <summary>
    /// ror r/m8, 1
    /// </summary>
    [Symbol("ror m8, 1","ror r/m8, 1")]
    ror_m8_1 = 1395,
    /// <summary>
    /// ror r/m8, CL
    /// </summary>
    [Symbol("ror r8, CL","ror r/m8, CL")]
    ror_r8_CL = 1396,
    /// <summary>
    /// ror r/m8, CL
    /// </summary>
    [Symbol("ror m8, CL","ror r/m8, CL")]
    ror_m8_CL = 1397,
    /// <summary>
    /// ror r/m8, imm8
    /// </summary>
    [Symbol("ror r8, imm8","ror r/m8, imm8")]
    ror_r8_imm8 = 1398,
    /// <summary>
    /// ror r/m8, imm8
    /// </summary>
    [Symbol("ror m8, imm8","ror r/m8, imm8")]
    ror_m8_imm8 = 1399,
    /// <summary>
    /// sal r/m16, 1
    /// </summary>
    [Symbol("sal r16, 1","sal r/m16, 1")]
    sal_r16_1 = 1400,
    /// <summary>
    /// sal r/m16, 1
    /// </summary>
    [Symbol("sal m16, 1","sal r/m16, 1")]
    sal_m16_1 = 1401,
    /// <summary>
    /// sal r/m16, CL
    /// </summary>
    [Symbol("sal r16, CL","sal r/m16, CL")]
    sal_r16_CL = 1402,
    /// <summary>
    /// sal r/m16, CL
    /// </summary>
    [Symbol("sal m16, CL","sal r/m16, CL")]
    sal_m16_CL = 1403,
    /// <summary>
    /// sal r/m16, imm8
    /// </summary>
    [Symbol("sal r16, imm8","sal r/m16, imm8")]
    sal_r16_imm8 = 1404,
    /// <summary>
    /// sal r/m16, imm8
    /// </summary>
    [Symbol("sal m16, imm8","sal r/m16, imm8")]
    sal_m16_imm8 = 1405,
    /// <summary>
    /// sal r/m32, 1
    /// </summary>
    [Symbol("sal r32, 1","sal r/m32, 1")]
    sal_r32_1 = 1406,
    /// <summary>
    /// sal r/m32, 1
    /// </summary>
    [Symbol("sal m32, 1","sal r/m32, 1")]
    sal_m32_1 = 1407,
    /// <summary>
    /// sal r/m32, CL
    /// </summary>
    [Symbol("sal r32, CL","sal r/m32, CL")]
    sal_r32_CL = 1408,
    /// <summary>
    /// sal r/m32, CL
    /// </summary>
    [Symbol("sal m32, CL","sal r/m32, CL")]
    sal_m32_CL = 1409,
    /// <summary>
    /// sal r/m32, imm8
    /// </summary>
    [Symbol("sal r32, imm8","sal r/m32, imm8")]
    sal_r32_imm8 = 1410,
    /// <summary>
    /// sal r/m32, imm8
    /// </summary>
    [Symbol("sal m32, imm8","sal r/m32, imm8")]
    sal_m32_imm8 = 1411,
    /// <summary>
    /// sal r/m64, 1
    /// </summary>
    [Symbol("sal r64, 1","sal r/m64, 1")]
    sal_r64_1 = 1412,
    /// <summary>
    /// sal r/m64, 1
    /// </summary>
    [Symbol("sal m64, 1","sal r/m64, 1")]
    sal_m64_1 = 1413,
    /// <summary>
    /// sal r/m64, CL
    /// </summary>
    [Symbol("sal r64, CL","sal r/m64, CL")]
    sal_r64_CL = 1414,
    /// <summary>
    /// sal r/m64, CL
    /// </summary>
    [Symbol("sal m64, CL","sal r/m64, CL")]
    sal_m64_CL = 1415,
    /// <summary>
    /// sal r/m64, imm8
    /// </summary>
    [Symbol("sal r64, imm8","sal r/m64, imm8")]
    sal_r64_imm8 = 1416,
    /// <summary>
    /// sal r/m64, imm8
    /// </summary>
    [Symbol("sal m64, imm8","sal r/m64, imm8")]
    sal_m64_imm8 = 1417,
    /// <summary>
    /// sal r/m8, 1
    /// </summary>
    [Symbol("sal r8, 1","sal r/m8, 1")]
    sal_r8_1 = 1418,
    /// <summary>
    /// sal r/m8, 1
    /// </summary>
    [Symbol("sal m8, 1","sal r/m8, 1")]
    sal_m8_1 = 1419,
    /// <summary>
    /// sal r/m8, CL
    /// </summary>
    [Symbol("sal r8, CL","sal r/m8, CL")]
    sal_r8_CL = 1420,
    /// <summary>
    /// sal r/m8, CL
    /// </summary>
    [Symbol("sal m8, CL","sal r/m8, CL")]
    sal_m8_CL = 1421,
    /// <summary>
    /// sal r/m8, imm8
    /// </summary>
    [Symbol("sal r8, imm8","sal r/m8, imm8")]
    sal_r8_imm8 = 1422,
    /// <summary>
    /// sal r/m8, imm8
    /// </summary>
    [Symbol("sal m8, imm8","sal r/m8, imm8")]
    sal_m8_imm8 = 1423,
    /// <summary>
    /// sar r/m16, 1
    /// </summary>
    [Symbol("sar r16, 1","sar r/m16, 1")]
    sar_r16_1 = 1424,
    /// <summary>
    /// sar r/m16, 1
    /// </summary>
    [Symbol("sar m16, 1","sar r/m16, 1")]
    sar_m16_1 = 1425,
    /// <summary>
    /// sar r/m16, CL
    /// </summary>
    [Symbol("sar r16, CL","sar r/m16, CL")]
    sar_r16_CL = 1426,
    /// <summary>
    /// sar r/m16, CL
    /// </summary>
    [Symbol("sar m16, CL","sar r/m16, CL")]
    sar_m16_CL = 1427,
    /// <summary>
    /// sar r/m16, imm8
    /// </summary>
    [Symbol("sar r16, imm8","sar r/m16, imm8")]
    sar_r16_imm8 = 1428,
    /// <summary>
    /// sar r/m16, imm8
    /// </summary>
    [Symbol("sar m16, imm8","sar r/m16, imm8")]
    sar_m16_imm8 = 1429,
    /// <summary>
    /// sar r/m32, 1
    /// </summary>
    [Symbol("sar r32, 1","sar r/m32, 1")]
    sar_r32_1 = 1430,
    /// <summary>
    /// sar r/m32, 1
    /// </summary>
    [Symbol("sar m32, 1","sar r/m32, 1")]
    sar_m32_1 = 1431,
    /// <summary>
    /// sar r/m32, CL
    /// </summary>
    [Symbol("sar r32, CL","sar r/m32, CL")]
    sar_r32_CL = 1432,
    /// <summary>
    /// sar r/m32, CL
    /// </summary>
    [Symbol("sar m32, CL","sar r/m32, CL")]
    sar_m32_CL = 1433,
    /// <summary>
    /// sar r/m32, imm8
    /// </summary>
    [Symbol("sar r32, imm8","sar r/m32, imm8")]
    sar_r32_imm8 = 1434,
    /// <summary>
    /// sar r/m32, imm8
    /// </summary>
    [Symbol("sar m32, imm8","sar r/m32, imm8")]
    sar_m32_imm8 = 1435,
    /// <summary>
    /// sar r/m64, 1
    /// </summary>
    [Symbol("sar r64, 1","sar r/m64, 1")]
    sar_r64_1 = 1436,
    /// <summary>
    /// sar r/m64, 1
    /// </summary>
    [Symbol("sar m64, 1","sar r/m64, 1")]
    sar_m64_1 = 1437,
    /// <summary>
    /// sar r/m64, CL
    /// </summary>
    [Symbol("sar r64, CL","sar r/m64, CL")]
    sar_r64_CL = 1438,
    /// <summary>
    /// sar r/m64, CL
    /// </summary>
    [Symbol("sar m64, CL","sar r/m64, CL")]
    sar_m64_CL = 1439,
    /// <summary>
    /// sar r/m64, imm8
    /// </summary>
    [Symbol("sar r64, imm8","sar r/m64, imm8")]
    sar_r64_imm8 = 1440,
    /// <summary>
    /// sar r/m64, imm8
    /// </summary>
    [Symbol("sar m64, imm8","sar r/m64, imm8")]
    sar_m64_imm8 = 1441,
    /// <summary>
    /// sar r/m8, 1
    /// </summary>
    [Symbol("sar r8, 1","sar r/m8, 1")]
    sar_r8_1 = 1442,
    /// <summary>
    /// sar r/m8, 1
    /// </summary>
    [Symbol("sar m8, 1","sar r/m8, 1")]
    sar_m8_1 = 1443,
    /// <summary>
    /// sar r/m8, CL
    /// </summary>
    [Symbol("sar r8, CL","sar r/m8, CL")]
    sar_r8_CL = 1444,
    /// <summary>
    /// sar r/m8, CL
    /// </summary>
    [Symbol("sar m8, CL","sar r/m8, CL")]
    sar_m8_CL = 1445,
    /// <summary>
    /// sar r/m8, imm8
    /// </summary>
    [Symbol("sar r8, imm8","sar r/m8, imm8")]
    sar_r8_imm8 = 1446,
    /// <summary>
    /// sar r/m8, imm8
    /// </summary>
    [Symbol("sar m8, imm8","sar r/m8, imm8")]
    sar_m8_imm8 = 1447,
    /// <summary>
    /// sarx r32, r/m32, r32
    /// </summary>
    [Symbol("sarx r32, r32, r32","sarx r32, r/m32, r32")]
    sarx_r32_r32_r32 = 1448,
    /// <summary>
    /// sarx r32, r/m32, r32
    /// </summary>
    [Symbol("sarx r32, m32, r32","sarx r32, r/m32, r32")]
    sarx_r32_m32_r32 = 1449,
    /// <summary>
    /// sarx r64, r/m64, r64
    /// </summary>
    [Symbol("sarx r64, r64, r64","sarx r64, r/m64, r64")]
    sarx_r64_r64_r64 = 1450,
    /// <summary>
    /// sarx r64, r/m64, r64
    /// </summary>
    [Symbol("sarx r64, m64, r64","sarx r64, r/m64, r64")]
    sarx_r64_m64_r64 = 1451,
    /// <summary>
    /// sbb AL, imm8
    /// </summary>
    [Symbol("sbb AL, imm8","sbb AL, imm8")]
    sbb_AL_imm8 = 1452,
    /// <summary>
    /// sbb AX, imm16
    /// </summary>
    [Symbol("sbb AX, imm16","sbb AX, imm16")]
    sbb_AX_imm16 = 1453,
    /// <summary>
    /// sbb EAX, imm32
    /// </summary>
    [Symbol("sbb EAX, imm32","sbb EAX, imm32")]
    sbb_EAX_imm32 = 1454,
    /// <summary>
    /// sbb r/m16, imm16
    /// </summary>
    [Symbol("sbb r16, imm16","sbb r/m16, imm16")]
    sbb_r16_imm16 = 1455,
    /// <summary>
    /// sbb r/m16, imm16
    /// </summary>
    [Symbol("sbb m16, imm16","sbb r/m16, imm16")]
    sbb_m16_imm16 = 1456,
    /// <summary>
    /// sbb r/m16, imm8
    /// </summary>
    [Symbol("sbb r16, imm8","sbb r/m16, imm8")]
    sbb_r16_imm8 = 1457,
    /// <summary>
    /// sbb r/m16, imm8
    /// </summary>
    [Symbol("sbb m16, imm8","sbb r/m16, imm8")]
    sbb_m16_imm8 = 1458,
    /// <summary>
    /// sbb r/m16, r16
    /// </summary>
    [Symbol("sbb r16, r16","sbb r/m16, r16")]
    sbb_r16_r16 = 1459,
    /// <summary>
    /// sbb r/m16, r16
    /// </summary>
    [Symbol("sbb m16, r16","sbb r/m16, r16")]
    sbb_m16_r16 = 1460,
    /// <summary>
    /// sbb r/m32, imm32
    /// </summary>
    [Symbol("sbb r32, imm32","sbb r/m32, imm32")]
    sbb_r32_imm32 = 1461,
    /// <summary>
    /// sbb r/m32, imm32
    /// </summary>
    [Symbol("sbb m32, imm32","sbb r/m32, imm32")]
    sbb_m32_imm32 = 1462,
    /// <summary>
    /// sbb r/m32, imm8
    /// </summary>
    [Symbol("sbb r32, imm8","sbb r/m32, imm8")]
    sbb_r32_imm8 = 1463,
    /// <summary>
    /// sbb r/m32, imm8
    /// </summary>
    [Symbol("sbb m32, imm8","sbb r/m32, imm8")]
    sbb_m32_imm8 = 1464,
    /// <summary>
    /// sbb r/m32, r32
    /// </summary>
    [Symbol("sbb r32, r32","sbb r/m32, r32")]
    sbb_r32_r32 = 1465,
    /// <summary>
    /// sbb r/m32, r32
    /// </summary>
    [Symbol("sbb m32, r32","sbb r/m32, r32")]
    sbb_m32_r32 = 1466,
    /// <summary>
    /// sbb r/m64, imm32
    /// </summary>
    [Symbol("sbb r64, imm32","sbb r/m64, imm32")]
    sbb_r64_imm32 = 1467,
    /// <summary>
    /// sbb r/m64, imm32
    /// </summary>
    [Symbol("sbb m64, imm32","sbb r/m64, imm32")]
    sbb_m64_imm32 = 1468,
    /// <summary>
    /// sbb r/m64, imm8
    /// </summary>
    [Symbol("sbb r64, imm8","sbb r/m64, imm8")]
    sbb_r64_imm8 = 1469,
    /// <summary>
    /// sbb r/m64, imm8
    /// </summary>
    [Symbol("sbb m64, imm8","sbb r/m64, imm8")]
    sbb_m64_imm8 = 1470,
    /// <summary>
    /// sbb r/m64, r64
    /// </summary>
    [Symbol("sbb r64, r64","sbb r/m64, r64")]
    sbb_r64_r64 = 1471,
    /// <summary>
    /// sbb r/m64, r64
    /// </summary>
    [Symbol("sbb m64, r64","sbb r/m64, r64")]
    sbb_m64_r64 = 1472,
    /// <summary>
    /// sbb r/m8, imm8
    /// </summary>
    [Symbol("sbb r8, imm8","sbb r/m8, imm8")]
    sbb_r8_imm8 = 1473,
    /// <summary>
    /// sbb r/m8, imm8
    /// </summary>
    [Symbol("sbb m8, imm8","sbb r/m8, imm8")]
    sbb_m8_imm8 = 1474,
    /// <summary>
    /// sbb r/m8, r8
    /// </summary>
    [Symbol("sbb r8, r8","sbb r/m8, r8")]
    sbb_r8_r8 = 1475,
    /// <summary>
    /// sbb r/m8, r8
    /// </summary>
    [Symbol("sbb m8, r8","sbb r/m8, r8")]
    sbb_m8_r8 = 1476,
    /// <summary>
    /// sbb r16, r/m16
    /// </summary>
    [Symbol("sbb r16, m16","sbb r16, r/m16")]
    sbb_r16_m16 = 1477,
    /// <summary>
    /// sbb r32, r/m32
    /// </summary>
    [Symbol("sbb r32, m32","sbb r32, r/m32")]
    sbb_r32_m32 = 1478,
    /// <summary>
    /// sbb r64, r/m64
    /// </summary>
    [Symbol("sbb r64, m64","sbb r64, r/m64")]
    sbb_r64_m64 = 1479,
    /// <summary>
    /// sbb r8, r/m8
    /// </summary>
    [Symbol("sbb r8, m8","sbb r8, r/m8")]
    sbb_r8_m8 = 1480,
    /// <summary>
    /// sbb RAX, imm32
    /// </summary>
    [Symbol("sbb RAX, imm32","sbb RAX, imm32")]
    sbb_RAX_imm32 = 1481,
    /// <summary>
    /// seta r/m8
    /// </summary>
    [Symbol("seta r8","seta r/m8")]
    seta_r8 = 1482,
    /// <summary>
    /// seta r/m8
    /// </summary>
    [Symbol("seta m8","seta r/m8")]
    seta_m8 = 1483,
    /// <summary>
    /// setae r/m8
    /// </summary>
    [Symbol("setae r8","setae r/m8")]
    setae_r8 = 1484,
    /// <summary>
    /// setae r/m8
    /// </summary>
    [Symbol("setae m8","setae r/m8")]
    setae_m8 = 1485,
    /// <summary>
    /// setb r/m8
    /// </summary>
    [Symbol("setb r8","setb r/m8")]
    setb_r8 = 1486,
    /// <summary>
    /// setb r/m8
    /// </summary>
    [Symbol("setb m8","setb r/m8")]
    setb_m8 = 1487,
    /// <summary>
    /// setbe r/m8
    /// </summary>
    [Symbol("setbe r8","setbe r/m8")]
    setbe_r8 = 1488,
    /// <summary>
    /// setbe r/m8
    /// </summary>
    [Symbol("setbe m8","setbe r/m8")]
    setbe_m8 = 1489,
    /// <summary>
    /// setc r/m8
    /// </summary>
    [Symbol("setc r8","setc r/m8")]
    setc_r8 = 1490,
    /// <summary>
    /// setc r/m8
    /// </summary>
    [Symbol("setc m8","setc r/m8")]
    setc_m8 = 1491,
    /// <summary>
    /// sete r/m8
    /// </summary>
    [Symbol("sete r8","sete r/m8")]
    sete_r8 = 1492,
    /// <summary>
    /// sete r/m8
    /// </summary>
    [Symbol("sete m8","sete r/m8")]
    sete_m8 = 1493,
    /// <summary>
    /// setg r/m8
    /// </summary>
    [Symbol("setg r8","setg r/m8")]
    setg_r8 = 1494,
    /// <summary>
    /// setg r/m8
    /// </summary>
    [Symbol("setg m8","setg r/m8")]
    setg_m8 = 1495,
    /// <summary>
    /// setge r/m8
    /// </summary>
    [Symbol("setge r8","setge r/m8")]
    setge_r8 = 1496,
    /// <summary>
    /// setge r/m8
    /// </summary>
    [Symbol("setge m8","setge r/m8")]
    setge_m8 = 1497,
    /// <summary>
    /// setl r/m8
    /// </summary>
    [Symbol("setl r8","setl r/m8")]
    setl_r8 = 1498,
    /// <summary>
    /// setl r/m8
    /// </summary>
    [Symbol("setl m8","setl r/m8")]
    setl_m8 = 1499,
    /// <summary>
    /// setle r/m8
    /// </summary>
    [Symbol("setle r8","setle r/m8")]
    setle_r8 = 1500,
    /// <summary>
    /// setle r/m8
    /// </summary>
    [Symbol("setle m8","setle r/m8")]
    setle_m8 = 1501,
    /// <summary>
    /// setna r/m8
    /// </summary>
    [Symbol("setna r8","setna r/m8")]
    setna_r8 = 1502,
    /// <summary>
    /// setna r/m8
    /// </summary>
    [Symbol("setna m8","setna r/m8")]
    setna_m8 = 1503,
    /// <summary>
    /// setnae r/m8
    /// </summary>
    [Symbol("setnae r8","setnae r/m8")]
    setnae_r8 = 1504,
    /// <summary>
    /// setnae r/m8
    /// </summary>
    [Symbol("setnae m8","setnae r/m8")]
    setnae_m8 = 1505,
    /// <summary>
    /// setnb r/m8
    /// </summary>
    [Symbol("setnb r8","setnb r/m8")]
    setnb_r8 = 1506,
    /// <summary>
    /// setnb r/m8
    /// </summary>
    [Symbol("setnb m8","setnb r/m8")]
    setnb_m8 = 1507,
    /// <summary>
    /// setnbe r/m8
    /// </summary>
    [Symbol("setnbe r8","setnbe r/m8")]
    setnbe_r8 = 1508,
    /// <summary>
    /// setnbe r/m8
    /// </summary>
    [Symbol("setnbe m8","setnbe r/m8")]
    setnbe_m8 = 1509,
    /// <summary>
    /// setnc r/m8
    /// </summary>
    [Symbol("setnc r8","setnc r/m8")]
    setnc_r8 = 1510,
    /// <summary>
    /// setnc r/m8
    /// </summary>
    [Symbol("setnc m8","setnc r/m8")]
    setnc_m8 = 1511,
    /// <summary>
    /// setne r/m8
    /// </summary>
    [Symbol("setne r8","setne r/m8")]
    setne_r8 = 1512,
    /// <summary>
    /// setne r/m8
    /// </summary>
    [Symbol("setne m8","setne r/m8")]
    setne_m8 = 1513,
    /// <summary>
    /// setng r/m8
    /// </summary>
    [Symbol("setng r8","setng r/m8")]
    setng_r8 = 1514,
    /// <summary>
    /// setng r/m8
    /// </summary>
    [Symbol("setng m8","setng r/m8")]
    setng_m8 = 1515,
    /// <summary>
    /// setnge r/m8
    /// </summary>
    [Symbol("setnge r8","setnge r/m8")]
    setnge_r8 = 1516,
    /// <summary>
    /// setnge r/m8
    /// </summary>
    [Symbol("setnge m8","setnge r/m8")]
    setnge_m8 = 1517,
    /// <summary>
    /// setnl r/m8
    /// </summary>
    [Symbol("setnl r8","setnl r/m8")]
    setnl_r8 = 1518,
    /// <summary>
    /// setnl r/m8
    /// </summary>
    [Symbol("setnl m8","setnl r/m8")]
    setnl_m8 = 1519,
    /// <summary>
    /// setnle r/m8
    /// </summary>
    [Symbol("setnle r8","setnle r/m8")]
    setnle_r8 = 1520,
    /// <summary>
    /// setnle r/m8
    /// </summary>
    [Symbol("setnle m8","setnle r/m8")]
    setnle_m8 = 1521,
    /// <summary>
    /// setno r/m8
    /// </summary>
    [Symbol("setno r8","setno r/m8")]
    setno_r8 = 1522,
    /// <summary>
    /// setno r/m8
    /// </summary>
    [Symbol("setno m8","setno r/m8")]
    setno_m8 = 1523,
    /// <summary>
    /// setnp r/m8
    /// </summary>
    [Symbol("setnp r8","setnp r/m8")]
    setnp_r8 = 1524,
    /// <summary>
    /// setnp r/m8
    /// </summary>
    [Symbol("setnp m8","setnp r/m8")]
    setnp_m8 = 1525,
    /// <summary>
    /// setns r/m8
    /// </summary>
    [Symbol("setns r8","setns r/m8")]
    setns_r8 = 1526,
    /// <summary>
    /// setns r/m8
    /// </summary>
    [Symbol("setns m8","setns r/m8")]
    setns_m8 = 1527,
    /// <summary>
    /// setnz r/m8
    /// </summary>
    [Symbol("setnz r8","setnz r/m8")]
    setnz_r8 = 1528,
    /// <summary>
    /// setnz r/m8
    /// </summary>
    [Symbol("setnz m8","setnz r/m8")]
    setnz_m8 = 1529,
    /// <summary>
    /// seto r/m8
    /// </summary>
    [Symbol("seto r8","seto r/m8")]
    seto_r8 = 1530,
    /// <summary>
    /// seto r/m8
    /// </summary>
    [Symbol("seto m8","seto r/m8")]
    seto_m8 = 1531,
    /// <summary>
    /// setp r/m8
    /// </summary>
    [Symbol("setp r8","setp r/m8")]
    setp_r8 = 1532,
    /// <summary>
    /// setp r/m8
    /// </summary>
    [Symbol("setp m8","setp r/m8")]
    setp_m8 = 1533,
    /// <summary>
    /// setpe r/m8
    /// </summary>
    [Symbol("setpe r8","setpe r/m8")]
    setpe_r8 = 1534,
    /// <summary>
    /// setpe r/m8
    /// </summary>
    [Symbol("setpe m8","setpe r/m8")]
    setpe_m8 = 1535,
    /// <summary>
    /// setpo r/m8
    /// </summary>
    [Symbol("setpo r8","setpo r/m8")]
    setpo_r8 = 1536,
    /// <summary>
    /// setpo r/m8
    /// </summary>
    [Symbol("setpo m8","setpo r/m8")]
    setpo_m8 = 1537,
    /// <summary>
    /// sets r/m8
    /// </summary>
    [Symbol("sets r8","sets r/m8")]
    sets_r8 = 1538,
    /// <summary>
    /// sets r/m8
    /// </summary>
    [Symbol("sets m8","sets r/m8")]
    sets_m8 = 1539,
    /// <summary>
    /// setz r/m8
    /// </summary>
    [Symbol("setz r8","setz r/m8")]
    setz_r8 = 1540,
    /// <summary>
    /// setz r/m8
    /// </summary>
    [Symbol("setz m8","setz r/m8")]
    setz_m8 = 1541,
    /// <summary>
    /// shl r/m16, 1
    /// </summary>
    [Symbol("shl r16, 1","shl r/m16, 1")]
    shl_r16_1 = 1542,
    /// <summary>
    /// shl r/m16, 1
    /// </summary>
    [Symbol("shl m16, 1","shl r/m16, 1")]
    shl_m16_1 = 1543,
    /// <summary>
    /// shl r/m16, CL
    /// </summary>
    [Symbol("shl r16, CL","shl r/m16, CL")]
    shl_r16_CL = 1544,
    /// <summary>
    /// shl r/m16, CL
    /// </summary>
    [Symbol("shl m16, CL","shl r/m16, CL")]
    shl_m16_CL = 1545,
    /// <summary>
    /// shl r/m16, imm8
    /// </summary>
    [Symbol("shl r16, imm8","shl r/m16, imm8")]
    shl_r16_imm8 = 1546,
    /// <summary>
    /// shl r/m16, imm8
    /// </summary>
    [Symbol("shl m16, imm8","shl r/m16, imm8")]
    shl_m16_imm8 = 1547,
    /// <summary>
    /// shl r/m32, 1
    /// </summary>
    [Symbol("shl r32, 1","shl r/m32, 1")]
    shl_r32_1 = 1548,
    /// <summary>
    /// shl r/m32, 1
    /// </summary>
    [Symbol("shl m32, 1","shl r/m32, 1")]
    shl_m32_1 = 1549,
    /// <summary>
    /// shl r/m32, CL
    /// </summary>
    [Symbol("shl r32, CL","shl r/m32, CL")]
    shl_r32_CL = 1550,
    /// <summary>
    /// shl r/m32, CL
    /// </summary>
    [Symbol("shl m32, CL","shl r/m32, CL")]
    shl_m32_CL = 1551,
    /// <summary>
    /// shl r/m32, imm8
    /// </summary>
    [Symbol("shl r32, imm8","shl r/m32, imm8")]
    shl_r32_imm8 = 1552,
    /// <summary>
    /// shl r/m32, imm8
    /// </summary>
    [Symbol("shl m32, imm8","shl r/m32, imm8")]
    shl_m32_imm8 = 1553,
    /// <summary>
    /// shl r/m64, 1
    /// </summary>
    [Symbol("shl r64, 1","shl r/m64, 1")]
    shl_r64_1 = 1554,
    /// <summary>
    /// shl r/m64, 1
    /// </summary>
    [Symbol("shl m64, 1","shl r/m64, 1")]
    shl_m64_1 = 1555,
    /// <summary>
    /// shl r/m64, CL
    /// </summary>
    [Symbol("shl r64, CL","shl r/m64, CL")]
    shl_r64_CL = 1556,
    /// <summary>
    /// shl r/m64, CL
    /// </summary>
    [Symbol("shl m64, CL","shl r/m64, CL")]
    shl_m64_CL = 1557,
    /// <summary>
    /// shl r/m64, imm8
    /// </summary>
    [Symbol("shl r64, imm8","shl r/m64, imm8")]
    shl_r64_imm8 = 1558,
    /// <summary>
    /// shl r/m64, imm8
    /// </summary>
    [Symbol("shl m64, imm8","shl r/m64, imm8")]
    shl_m64_imm8 = 1559,
    /// <summary>
    /// shl r/m8, 1
    /// </summary>
    [Symbol("shl r8, 1","shl r/m8, 1")]
    shl_r8_1 = 1560,
    /// <summary>
    /// shl r/m8, 1
    /// </summary>
    [Symbol("shl m8, 1","shl r/m8, 1")]
    shl_m8_1 = 1561,
    /// <summary>
    /// shl r/m8, CL
    /// </summary>
    [Symbol("shl r8, CL","shl r/m8, CL")]
    shl_r8_CL = 1562,
    /// <summary>
    /// shl r/m8, CL
    /// </summary>
    [Symbol("shl m8, CL","shl r/m8, CL")]
    shl_m8_CL = 1563,
    /// <summary>
    /// shl r/m8, imm8
    /// </summary>
    [Symbol("shl r8, imm8","shl r/m8, imm8")]
    shl_r8_imm8 = 1564,
    /// <summary>
    /// shl r/m8, imm8
    /// </summary>
    [Symbol("shl m8, imm8","shl r/m8, imm8")]
    shl_m8_imm8 = 1565,
    /// <summary>
    /// shlx r32, r/m32, r32
    /// </summary>
    [Symbol("shlx r32, r32, r32","shlx r32, r/m32, r32")]
    shlx_r32_r32_r32 = 1566,
    /// <summary>
    /// shlx r32, r/m32, r32
    /// </summary>
    [Symbol("shlx r32, m32, r32","shlx r32, r/m32, r32")]
    shlx_r32_m32_r32 = 1567,
    /// <summary>
    /// shlx r64, r/m64, r64
    /// </summary>
    [Symbol("shlx r64, r64, r64","shlx r64, r/m64, r64")]
    shlx_r64_r64_r64 = 1568,
    /// <summary>
    /// shlx r64, r/m64, r64
    /// </summary>
    [Symbol("shlx r64, m64, r64","shlx r64, r/m64, r64")]
    shlx_r64_m64_r64 = 1569,
    /// <summary>
    /// shr r/m16, 1
    /// </summary>
    [Symbol("shr r16, 1","shr r/m16, 1")]
    shr_r16_1 = 1570,
    /// <summary>
    /// shr r/m16, 1
    /// </summary>
    [Symbol("shr m16, 1","shr r/m16, 1")]
    shr_m16_1 = 1571,
    /// <summary>
    /// shr r/m16, CL
    /// </summary>
    [Symbol("shr r16, CL","shr r/m16, CL")]
    shr_r16_CL = 1572,
    /// <summary>
    /// shr r/m16, CL
    /// </summary>
    [Symbol("shr m16, CL","shr r/m16, CL")]
    shr_m16_CL = 1573,
    /// <summary>
    /// shr r/m16, imm8
    /// </summary>
    [Symbol("shr r16, imm8","shr r/m16, imm8")]
    shr_r16_imm8 = 1574,
    /// <summary>
    /// shr r/m16, imm8
    /// </summary>
    [Symbol("shr m16, imm8","shr r/m16, imm8")]
    shr_m16_imm8 = 1575,
    /// <summary>
    /// shr r/m32, 1
    /// </summary>
    [Symbol("shr r32, 1","shr r/m32, 1")]
    shr_r32_1 = 1576,
    /// <summary>
    /// shr r/m32, 1
    /// </summary>
    [Symbol("shr m32, 1","shr r/m32, 1")]
    shr_m32_1 = 1577,
    /// <summary>
    /// shr r/m32, CL
    /// </summary>
    [Symbol("shr r32, CL","shr r/m32, CL")]
    shr_r32_CL = 1578,
    /// <summary>
    /// shr r/m32, CL
    /// </summary>
    [Symbol("shr m32, CL","shr r/m32, CL")]
    shr_m32_CL = 1579,
    /// <summary>
    /// shr r/m32, imm8
    /// </summary>
    [Symbol("shr r32, imm8","shr r/m32, imm8")]
    shr_r32_imm8 = 1580,
    /// <summary>
    /// shr r/m32, imm8
    /// </summary>
    [Symbol("shr m32, imm8","shr r/m32, imm8")]
    shr_m32_imm8 = 1581,
    /// <summary>
    /// shr r/m64, 1
    /// </summary>
    [Symbol("shr r64, 1","shr r/m64, 1")]
    shr_r64_1 = 1582,
    /// <summary>
    /// shr r/m64, 1
    /// </summary>
    [Symbol("shr m64, 1","shr r/m64, 1")]
    shr_m64_1 = 1583,
    /// <summary>
    /// shr r/m64, CL
    /// </summary>
    [Symbol("shr r64, CL","shr r/m64, CL")]
    shr_r64_CL = 1584,
    /// <summary>
    /// shr r/m64, CL
    /// </summary>
    [Symbol("shr m64, CL","shr r/m64, CL")]
    shr_m64_CL = 1585,
    /// <summary>
    /// shr r/m64, imm8
    /// </summary>
    [Symbol("shr r64, imm8","shr r/m64, imm8")]
    shr_r64_imm8 = 1586,
    /// <summary>
    /// shr r/m64, imm8
    /// </summary>
    [Symbol("shr m64, imm8","shr r/m64, imm8")]
    shr_m64_imm8 = 1587,
    /// <summary>
    /// shr r/m8, 1
    /// </summary>
    [Symbol("shr r8, 1","shr r/m8, 1")]
    shr_r8_1 = 1588,
    /// <summary>
    /// shr r/m8, 1
    /// </summary>
    [Symbol("shr m8, 1","shr r/m8, 1")]
    shr_m8_1 = 1589,
    /// <summary>
    /// shr r/m8, CL
    /// </summary>
    [Symbol("shr r8, CL","shr r/m8, CL")]
    shr_r8_CL = 1590,
    /// <summary>
    /// shr r/m8, CL
    /// </summary>
    [Symbol("shr m8, CL","shr r/m8, CL")]
    shr_m8_CL = 1591,
    /// <summary>
    /// shr r/m8, imm8
    /// </summary>
    [Symbol("shr r8, imm8","shr r/m8, imm8")]
    shr_r8_imm8 = 1592,
    /// <summary>
    /// shr r/m8, imm8
    /// </summary>
    [Symbol("shr m8, imm8","shr r/m8, imm8")]
    shr_m8_imm8 = 1593,
    /// <summary>
    /// shrx r32, r/m32, r32
    /// </summary>
    [Symbol("shrx r32, r32, r32","shrx r32, r/m32, r32")]
    shrx_r32_r32_r32 = 1594,
    /// <summary>
    /// shrx r32, r/m32, r32
    /// </summary>
    [Symbol("shrx r32, m32, r32","shrx r32, r/m32, r32")]
    shrx_r32_m32_r32 = 1595,
    /// <summary>
    /// shrx r64, r/m64, r64
    /// </summary>
    [Symbol("shrx r64, r64, r64","shrx r64, r/m64, r64")]
    shrx_r64_r64_r64 = 1596,
    /// <summary>
    /// shrx r64, r/m64, r64
    /// </summary>
    [Symbol("shrx r64, m64, r64","shrx r64, r/m64, r64")]
    shrx_r64_m64_r64 = 1597,
    /// <summary>
    /// sti
    /// </summary>
    [Symbol("sti","sti")]
    sti = 1598,
    /// <summary>
    /// stos m16
    /// </summary>
    [Symbol("stos m16","stos m16")]
    stos_m16 = 1599,
    /// <summary>
    /// stos m32
    /// </summary>
    [Symbol("stos m32","stos m32")]
    stos_m32 = 1600,
    /// <summary>
    /// stos m64
    /// </summary>
    [Symbol("stos m64","stos m64")]
    stos_m64 = 1601,
    /// <summary>
    /// stos m8
    /// </summary>
    [Symbol("stos m8","stos m8")]
    stos_m8 = 1602,
    /// <summary>
    /// stosb
    /// </summary>
    [Symbol("stosb","stosb")]
    stosb = 1603,
    /// <summary>
    /// stosd
    /// </summary>
    [Symbol("stosd","stosd")]
    stosd = 1604,
    /// <summary>
    /// stosq
    /// </summary>
    [Symbol("stosq","stosq")]
    stosq = 1605,
    /// <summary>
    /// stosw
    /// </summary>
    [Symbol("stosw","stosw")]
    stosw = 1606,
    /// <summary>
    /// sub AL, imm8
    /// </summary>
    [Symbol("sub AL, imm8","sub AL, imm8")]
    sub_AL_imm8 = 1607,
    /// <summary>
    /// sub AX, imm16
    /// </summary>
    [Symbol("sub AX, imm16","sub AX, imm16")]
    sub_AX_imm16 = 1608,
    /// <summary>
    /// sub EAX, imm32
    /// </summary>
    [Symbol("sub EAX, imm32","sub EAX, imm32")]
    sub_EAX_imm32 = 1609,
    /// <summary>
    /// sub r/m16, imm16
    /// </summary>
    [Symbol("sub r16, imm16","sub r/m16, imm16")]
    sub_r16_imm16 = 1610,
    /// <summary>
    /// sub r/m16, imm16
    /// </summary>
    [Symbol("sub m16, imm16","sub r/m16, imm16")]
    sub_m16_imm16 = 1611,
    /// <summary>
    /// sub r/m16, imm8
    /// </summary>
    [Symbol("sub r16, imm8","sub r/m16, imm8")]
    sub_r16_imm8 = 1612,
    /// <summary>
    /// sub r/m16, imm8
    /// </summary>
    [Symbol("sub m16, imm8","sub r/m16, imm8")]
    sub_m16_imm8 = 1613,
    /// <summary>
    /// sub r/m16, r16
    /// </summary>
    [Symbol("sub r16, r16","sub r/m16, r16")]
    sub_r16_r16 = 1614,
    /// <summary>
    /// sub r/m16, r16
    /// </summary>
    [Symbol("sub m16, r16","sub r/m16, r16")]
    sub_m16_r16 = 1615,
    /// <summary>
    /// sub r/m32, imm32
    /// </summary>
    [Symbol("sub r32, imm32","sub r/m32, imm32")]
    sub_r32_imm32 = 1616,
    /// <summary>
    /// sub r/m32, imm32
    /// </summary>
    [Symbol("sub m32, imm32","sub r/m32, imm32")]
    sub_m32_imm32 = 1617,
    /// <summary>
    /// sub r/m32, imm8
    /// </summary>
    [Symbol("sub r32, imm8","sub r/m32, imm8")]
    sub_r32_imm8 = 1618,
    /// <summary>
    /// sub r/m32, imm8
    /// </summary>
    [Symbol("sub m32, imm8","sub r/m32, imm8")]
    sub_m32_imm8 = 1619,
    /// <summary>
    /// sub r/m32, r32
    /// </summary>
    [Symbol("sub r32, r32","sub r/m32, r32")]
    sub_r32_r32 = 1620,
    /// <summary>
    /// sub r/m32, r32
    /// </summary>
    [Symbol("sub m32, r32","sub r/m32, r32")]
    sub_m32_r32 = 1621,
    /// <summary>
    /// sub r/m64, imm32
    /// </summary>
    [Symbol("sub r64, imm32","sub r/m64, imm32")]
    sub_r64_imm32 = 1622,
    /// <summary>
    /// sub r/m64, imm32
    /// </summary>
    [Symbol("sub m64, imm32","sub r/m64, imm32")]
    sub_m64_imm32 = 1623,
    /// <summary>
    /// sub r/m64, imm8
    /// </summary>
    [Symbol("sub r64, imm8","sub r/m64, imm8")]
    sub_r64_imm8 = 1624,
    /// <summary>
    /// sub r/m64, imm8
    /// </summary>
    [Symbol("sub m64, imm8","sub r/m64, imm8")]
    sub_m64_imm8 = 1625,
    /// <summary>
    /// sub r/m64, r64
    /// </summary>
    [Symbol("sub r64, r64","sub r/m64, r64")]
    sub_r64_r64 = 1626,
    /// <summary>
    /// sub r/m64, r64
    /// </summary>
    [Symbol("sub m64, r64","sub r/m64, r64")]
    sub_m64_r64 = 1627,
    /// <summary>
    /// sub r/m8, imm8
    /// </summary>
    [Symbol("sub r8, imm8","sub r/m8, imm8")]
    sub_r8_imm8 = 1628,
    /// <summary>
    /// sub r/m8, imm8
    /// </summary>
    [Symbol("sub m8, imm8","sub r/m8, imm8")]
    sub_m8_imm8 = 1629,
    /// <summary>
    /// sub r/m8, r8
    /// </summary>
    [Symbol("sub r8, r8","sub r/m8, r8")]
    sub_r8_r8 = 1630,
    /// <summary>
    /// sub r/m8, r8
    /// </summary>
    [Symbol("sub m8, r8","sub r/m8, r8")]
    sub_m8_r8 = 1631,
    /// <summary>
    /// sub r16, r/m16
    /// </summary>
    [Symbol("sub r16, m16","sub r16, r/m16")]
    sub_r16_m16 = 1632,
    /// <summary>
    /// sub r32, r/m32
    /// </summary>
    [Symbol("sub r32, m32","sub r32, r/m32")]
    sub_r32_m32 = 1633,
    /// <summary>
    /// sub r64, r/m64
    /// </summary>
    [Symbol("sub r64, m64","sub r64, r/m64")]
    sub_r64_m64 = 1634,
    /// <summary>
    /// sub r8, r/m8
    /// </summary>
    [Symbol("sub r8, m8","sub r8, r/m8")]
    sub_r8_m8 = 1635,
    /// <summary>
    /// sub RAX, imm32
    /// </summary>
    [Symbol("sub RAX, imm32","sub RAX, imm32")]
    sub_RAX_imm32 = 1636,
    /// <summary>
    /// syscall
    /// </summary>
    [Symbol("syscall","syscall")]
    syscall = 1637,
    /// <summary>
    /// test AL, imm8
    /// </summary>
    [Symbol("test AL, imm8","test AL, imm8")]
    test_AL_imm8 = 1638,
    /// <summary>
    /// test AX, imm16
    /// </summary>
    [Symbol("test AX, imm16","test AX, imm16")]
    test_AX_imm16 = 1639,
    /// <summary>
    /// test EAX, imm32
    /// </summary>
    [Symbol("test EAX, imm32","test EAX, imm32")]
    test_EAX_imm32 = 1640,
    /// <summary>
    /// test r/m16, imm16
    /// </summary>
    [Symbol("test r16, imm16","test r/m16, imm16")]
    test_r16_imm16 = 1641,
    /// <summary>
    /// test r/m16, imm16
    /// </summary>
    [Symbol("test m16, imm16","test r/m16, imm16")]
    test_m16_imm16 = 1642,
    /// <summary>
    /// test r/m16, r16
    /// </summary>
    [Symbol("test r16, r16","test r/m16, r16")]
    test_r16_r16 = 1643,
    /// <summary>
    /// test r/m16, r16
    /// </summary>
    [Symbol("test m16, r16","test r/m16, r16")]
    test_m16_r16 = 1644,
    /// <summary>
    /// test r/m32, imm32
    /// </summary>
    [Symbol("test r32, imm32","test r/m32, imm32")]
    test_r32_imm32 = 1645,
    /// <summary>
    /// test r/m32, imm32
    /// </summary>
    [Symbol("test m32, imm32","test r/m32, imm32")]
    test_m32_imm32 = 1646,
    /// <summary>
    /// test r/m32, r32
    /// </summary>
    [Symbol("test r32, r32","test r/m32, r32")]
    test_r32_r32 = 1647,
    /// <summary>
    /// test r/m32, r32
    /// </summary>
    [Symbol("test m32, r32","test r/m32, r32")]
    test_m32_r32 = 1648,
    /// <summary>
    /// test r/m64, imm32
    /// </summary>
    [Symbol("test r64, imm32","test r/m64, imm32")]
    test_r64_imm32 = 1649,
    /// <summary>
    /// test r/m64, imm32
    /// </summary>
    [Symbol("test m64, imm32","test r/m64, imm32")]
    test_m64_imm32 = 1650,
    /// <summary>
    /// test r/m64, r64
    /// </summary>
    [Symbol("test r64, r64","test r/m64, r64")]
    test_r64_r64 = 1651,
    /// <summary>
    /// test r/m64, r64
    /// </summary>
    [Symbol("test m64, r64","test r/m64, r64")]
    test_m64_r64 = 1652,
    /// <summary>
    /// test r/m8, imm8
    /// </summary>
    [Symbol("test r8, imm8","test r/m8, imm8")]
    test_r8_imm8 = 1653,
    /// <summary>
    /// test r/m8, imm8
    /// </summary>
    [Symbol("test m8, imm8","test r/m8, imm8")]
    test_m8_imm8 = 1654,
    /// <summary>
    /// test r/m8, r8
    /// </summary>
    [Symbol("test r8, r8","test r/m8, r8")]
    test_r8_r8 = 1655,
    /// <summary>
    /// test r/m8, r8
    /// </summary>
    [Symbol("test m8, r8","test r/m8, r8")]
    test_m8_r8 = 1656,
    /// <summary>
    /// test RAX, imm32
    /// </summary>
    [Symbol("test RAX, imm32","test RAX, imm32")]
    test_RAX_imm32 = 1657,
    /// <summary>
    /// tpause r32, EDX, EAX
    /// </summary>
    [Symbol("tpause r32, EDX, EAX","tpause r32, EDX, EAX")]
    tpause_r32_EDX_EAX = 1658,
    /// <summary>
    /// vaddpd xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vaddpd xmm {k1}{z}, xmm, xmm","vaddpd xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vaddpd_xmm_k1z_xmm_xmm = 1659,
    /// <summary>
    /// vaddpd xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vaddpd xmm {k1}{z}, xmm, m128","vaddpd xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vaddpd_xmm_k1z_xmm_m128 = 1660,
    /// <summary>
    /// vaddpd xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vaddpd xmm {k1}{z}, xmm, m64bcst","vaddpd xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vaddpd_xmm_k1z_xmm_m64bcst = 1661,
    /// <summary>
    /// vaddpd xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vaddpd xmm, xmm, xmm","vaddpd xmm, xmm, xmm/m128")]
    vaddpd_xmm_xmm_xmm = 1662,
    /// <summary>
    /// vaddpd xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vaddpd xmm, xmm, m128","vaddpd xmm, xmm, xmm/m128")]
    vaddpd_xmm_xmm_m128 = 1663,
    /// <summary>
    /// vaddpd ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vaddpd ymm {k1}{z}, ymm, ymm","vaddpd ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vaddpd_ymm_k1z_ymm_ymm = 1664,
    /// <summary>
    /// vaddpd ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vaddpd ymm {k1}{z}, ymm, m256","vaddpd ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vaddpd_ymm_k1z_ymm_m256 = 1665,
    /// <summary>
    /// vaddpd ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vaddpd ymm {k1}{z}, ymm, m64bcst","vaddpd ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vaddpd_ymm_k1z_ymm_m64bcst = 1666,
    /// <summary>
    /// vaddpd ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vaddpd ymm, ymm, ymm","vaddpd ymm, ymm, ymm/m256")]
    vaddpd_ymm_ymm_ymm = 1667,
    /// <summary>
    /// vaddpd ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vaddpd ymm, ymm, m256","vaddpd ymm, ymm, ymm/m256")]
    vaddpd_ymm_ymm_m256 = 1668,
    /// <summary>
    /// vaddpd zmm {k1}{z}, zmm, zmm/m512/m64bcst {er}
    /// </summary>
    [Symbol("vaddpd zmm {k1}{z}, zmm, zmm {er}","vaddpd zmm {k1}{z}, zmm, zmm/m512/m64bcst {er}")]
    vaddpd_zmm_k1z_zmm_zmm_er = 1669,
    /// <summary>
    /// vaddpd zmm {k1}{z}, zmm, zmm/m512/m64bcst {er}
    /// </summary>
    [Symbol("vaddpd zmm {k1}{z}, zmm, m512 {er}","vaddpd zmm {k1}{z}, zmm, zmm/m512/m64bcst {er}")]
    vaddpd_zmm_k1z_zmm_m512_er = 1670,
    /// <summary>
    /// vaddpd zmm {k1}{z}, zmm, zmm/m512/m64bcst {er}
    /// </summary>
    [Symbol("vaddpd zmm {k1}{z}, zmm, m64bcst {er}","vaddpd zmm {k1}{z}, zmm, zmm/m512/m64bcst {er}")]
    vaddpd_zmm_k1z_zmm_m64bcst_er = 1671,
    /// <summary>
    /// valignd xmm {k1}{z}, xmm, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("valignd xmm {k1}{z}, xmm, xmm, imm8","valignd xmm {k1}{z}, xmm, xmm/m128/m32bcst, imm8")]
    valignd_xmm_k1z_xmm_xmm_imm8 = 1672,
    /// <summary>
    /// valignd xmm {k1}{z}, xmm, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("valignd xmm {k1}{z}, xmm, m128, imm8","valignd xmm {k1}{z}, xmm, xmm/m128/m32bcst, imm8")]
    valignd_xmm_k1z_xmm_m128_imm8 = 1673,
    /// <summary>
    /// valignd xmm {k1}{z}, xmm, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("valignd xmm {k1}{z}, xmm, m32bcst, imm8","valignd xmm {k1}{z}, xmm, xmm/m128/m32bcst, imm8")]
    valignd_xmm_k1z_xmm_m32bcst_imm8 = 1674,
    /// <summary>
    /// valignd ymm {k1}{z}, ymm, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("valignd ymm {k1}{z}, ymm, ymm, imm8","valignd ymm {k1}{z}, ymm, ymm/m256/m32bcst, imm8")]
    valignd_ymm_k1z_ymm_ymm_imm8 = 1675,
    /// <summary>
    /// valignd ymm {k1}{z}, ymm, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("valignd ymm {k1}{z}, ymm, m256, imm8","valignd ymm {k1}{z}, ymm, ymm/m256/m32bcst, imm8")]
    valignd_ymm_k1z_ymm_m256_imm8 = 1676,
    /// <summary>
    /// valignd ymm {k1}{z}, ymm, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("valignd ymm {k1}{z}, ymm, m32bcst, imm8","valignd ymm {k1}{z}, ymm, ymm/m256/m32bcst, imm8")]
    valignd_ymm_k1z_ymm_m32bcst_imm8 = 1677,
    /// <summary>
    /// valignd zmm {k1}{z}, zmm, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("valignd zmm {k1}{z}, zmm, zmm, imm8","valignd zmm {k1}{z}, zmm, zmm/m512/m32bcst, imm8")]
    valignd_zmm_k1z_zmm_zmm_imm8 = 1678,
    /// <summary>
    /// valignd zmm {k1}{z}, zmm, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("valignd zmm {k1}{z}, zmm, m512, imm8","valignd zmm {k1}{z}, zmm, zmm/m512/m32bcst, imm8")]
    valignd_zmm_k1z_zmm_m512_imm8 = 1679,
    /// <summary>
    /// valignd zmm {k1}{z}, zmm, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("valignd zmm {k1}{z}, zmm, m32bcst, imm8","valignd zmm {k1}{z}, zmm, zmm/m512/m32bcst, imm8")]
    valignd_zmm_k1z_zmm_m32bcst_imm8 = 1680,
    /// <summary>
    /// valignq xmm {k1}{z}, xmm, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("valignq xmm {k1}{z}, xmm, xmm, imm8","valignq xmm {k1}{z}, xmm, xmm/m128/m64bcst, imm8")]
    valignq_xmm_k1z_xmm_xmm_imm8 = 1681,
    /// <summary>
    /// valignq xmm {k1}{z}, xmm, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("valignq xmm {k1}{z}, xmm, m128, imm8","valignq xmm {k1}{z}, xmm, xmm/m128/m64bcst, imm8")]
    valignq_xmm_k1z_xmm_m128_imm8 = 1682,
    /// <summary>
    /// valignq xmm {k1}{z}, xmm, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("valignq xmm {k1}{z}, xmm, m64bcst, imm8","valignq xmm {k1}{z}, xmm, xmm/m128/m64bcst, imm8")]
    valignq_xmm_k1z_xmm_m64bcst_imm8 = 1683,
    /// <summary>
    /// valignq ymm {k1}{z}, ymm, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("valignq ymm {k1}{z}, ymm, ymm, imm8","valignq ymm {k1}{z}, ymm, ymm/m256/m64bcst, imm8")]
    valignq_ymm_k1z_ymm_ymm_imm8 = 1684,
    /// <summary>
    /// valignq ymm {k1}{z}, ymm, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("valignq ymm {k1}{z}, ymm, m256, imm8","valignq ymm {k1}{z}, ymm, ymm/m256/m64bcst, imm8")]
    valignq_ymm_k1z_ymm_m256_imm8 = 1685,
    /// <summary>
    /// valignq ymm {k1}{z}, ymm, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("valignq ymm {k1}{z}, ymm, m64bcst, imm8","valignq ymm {k1}{z}, ymm, ymm/m256/m64bcst, imm8")]
    valignq_ymm_k1z_ymm_m64bcst_imm8 = 1686,
    /// <summary>
    /// valignq zmm {k1}{z}, zmm, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("valignq zmm {k1}{z}, zmm, zmm, imm8","valignq zmm {k1}{z}, zmm, zmm/m512/m64bcst, imm8")]
    valignq_zmm_k1z_zmm_zmm_imm8 = 1687,
    /// <summary>
    /// valignq zmm {k1}{z}, zmm, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("valignq zmm {k1}{z}, zmm, m512, imm8","valignq zmm {k1}{z}, zmm, zmm/m512/m64bcst, imm8")]
    valignq_zmm_k1z_zmm_m512_imm8 = 1688,
    /// <summary>
    /// valignq zmm {k1}{z}, zmm, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("valignq zmm {k1}{z}, zmm, m64bcst, imm8","valignq zmm {k1}{z}, zmm, zmm/m512/m64bcst, imm8")]
    valignq_zmm_k1z_zmm_m64bcst_imm8 = 1689,
    /// <summary>
    /// vbroadcasti128 ymm, m128
    /// </summary>
    [Symbol("vbroadcasti128 ymm, m128","vbroadcasti128 ymm, m128")]
    vbroadcasti128_ymm_m128 = 1690,
    /// <summary>
    /// vbroadcasti32x2 xmm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vbroadcasti32x2 xmm {k1}{z}, xmm","vbroadcasti32x2 xmm {k1}{z}, xmm/m64")]
    vbroadcasti32x2_xmm_k1z_xmm = 1691,
    /// <summary>
    /// vbroadcasti32x2 xmm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vbroadcasti32x2 xmm {k1}{z}, m64","vbroadcasti32x2 xmm {k1}{z}, xmm/m64")]
    vbroadcasti32x2_xmm_k1z_m64 = 1692,
    /// <summary>
    /// vbroadcasti32x2 ymm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vbroadcasti32x2 ymm {k1}{z}, xmm","vbroadcasti32x2 ymm {k1}{z}, xmm/m64")]
    vbroadcasti32x2_ymm_k1z_xmm = 1693,
    /// <summary>
    /// vbroadcasti32x2 ymm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vbroadcasti32x2 ymm {k1}{z}, m64","vbroadcasti32x2 ymm {k1}{z}, xmm/m64")]
    vbroadcasti32x2_ymm_k1z_m64 = 1694,
    /// <summary>
    /// vbroadcasti32x2 zmm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vbroadcasti32x2 zmm {k1}{z}, xmm","vbroadcasti32x2 zmm {k1}{z}, xmm/m64")]
    vbroadcasti32x2_zmm_k1z_xmm = 1695,
    /// <summary>
    /// vbroadcasti32x2 zmm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vbroadcasti32x2 zmm {k1}{z}, m64","vbroadcasti32x2 zmm {k1}{z}, xmm/m64")]
    vbroadcasti32x2_zmm_k1z_m64 = 1696,
    /// <summary>
    /// vbroadcasti32x4 ymm {k1}{z}, m128
    /// </summary>
    [Symbol("vbroadcasti32x4 ymm {k1}{z}, m128","vbroadcasti32x4 ymm {k1}{z}, m128")]
    vbroadcasti32x4_ymm_k1z_m128 = 1697,
    /// <summary>
    /// vbroadcasti32x4 zmm {k1}{z}, m128
    /// </summary>
    [Symbol("vbroadcasti32x4 zmm {k1}{z}, m128","vbroadcasti32x4 zmm {k1}{z}, m128")]
    vbroadcasti32x4_zmm_k1z_m128 = 1698,
    /// <summary>
    /// vbroadcasti32x8 zmm {k1}{z}, m256
    /// </summary>
    [Symbol("vbroadcasti32x8 zmm {k1}{z}, m256","vbroadcasti32x8 zmm {k1}{z}, m256")]
    vbroadcasti32x8_zmm_k1z_m256 = 1699,
    /// <summary>
    /// vbroadcasti64x2 ymm {k1}{z}, m128
    /// </summary>
    [Symbol("vbroadcasti64x2 ymm {k1}{z}, m128","vbroadcasti64x2 ymm {k1}{z}, m128")]
    vbroadcasti64x2_ymm_k1z_m128 = 1700,
    /// <summary>
    /// vbroadcasti64x2 zmm {k1}{z}, m128
    /// </summary>
    [Symbol("vbroadcasti64x2 zmm {k1}{z}, m128","vbroadcasti64x2 zmm {k1}{z}, m128")]
    vbroadcasti64x2_zmm_k1z_m128 = 1701,
    /// <summary>
    /// vbroadcasti64x4 zmm {k1}{z}, m256
    /// </summary>
    [Symbol("vbroadcasti64x4 zmm {k1}{z}, m256","vbroadcasti64x4 zmm {k1}{z}, m256")]
    vbroadcasti64x4_zmm_k1z_m256 = 1702,
    /// <summary>
    /// vcmpps k1 {k2}, xmm, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vcmpps k1 {k2}, xmm, xmm, imm8","vcmpps k1 {k2}, xmm, xmm/m128/m32bcst, imm8")]
    vcmpps_k1_k2_xmm_xmm_imm8 = 1703,
    /// <summary>
    /// vcmpps k1 {k2}, xmm, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vcmpps k1 {k2}, xmm, m128, imm8","vcmpps k1 {k2}, xmm, xmm/m128/m32bcst, imm8")]
    vcmpps_k1_k2_xmm_m128_imm8 = 1704,
    /// <summary>
    /// vcmpps k1 {k2}, xmm, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vcmpps k1 {k2}, xmm, m32bcst, imm8","vcmpps k1 {k2}, xmm, xmm/m128/m32bcst, imm8")]
    vcmpps_k1_k2_xmm_m32bcst_imm8 = 1705,
    /// <summary>
    /// vcmpps k1 {k2}, ymm, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vcmpps k1 {k2}, ymm, ymm, imm8","vcmpps k1 {k2}, ymm, ymm/m256/m32bcst, imm8")]
    vcmpps_k1_k2_ymm_ymm_imm8 = 1706,
    /// <summary>
    /// vcmpps k1 {k2}, ymm, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vcmpps k1 {k2}, ymm, m256, imm8","vcmpps k1 {k2}, ymm, ymm/m256/m32bcst, imm8")]
    vcmpps_k1_k2_ymm_m256_imm8 = 1707,
    /// <summary>
    /// vcmpps k1 {k2}, ymm, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vcmpps k1 {k2}, ymm, m32bcst, imm8","vcmpps k1 {k2}, ymm, ymm/m256/m32bcst, imm8")]
    vcmpps_k1_k2_ymm_m32bcst_imm8 = 1708,
    /// <summary>
    /// vcmpps k1 {k2}, zmm, zmm/m512/m32bcst {sae}, imm8
    /// </summary>
    [Symbol("vcmpps k1 {k2}, zmm, zmm {sae}, imm8","vcmpps k1 {k2}, zmm, zmm/m512/m32bcst {sae}, imm8")]
    vcmpps_k1_k2_zmm_zmm_sae_imm8 = 1709,
    /// <summary>
    /// vcmpps k1 {k2}, zmm, zmm/m512/m32bcst {sae}, imm8
    /// </summary>
    [Symbol("vcmpps k1 {k2}, zmm, m512 {sae}, imm8","vcmpps k1 {k2}, zmm, zmm/m512/m32bcst {sae}, imm8")]
    vcmpps_k1_k2_zmm_m512_sae_imm8 = 1710,
    /// <summary>
    /// vcmpps k1 {k2}, zmm, zmm/m512/m32bcst {sae}, imm8
    /// </summary>
    [Symbol("vcmpps k1 {k2}, zmm, m32bcst {sae}, imm8","vcmpps k1 {k2}, zmm, zmm/m512/m32bcst {sae}, imm8")]
    vcmpps_k1_k2_zmm_m32bcst_sae_imm8 = 1711,
    /// <summary>
    /// vcmpps xmm, xmm, xmm/m128, imm8
    /// </summary>
    [Symbol("vcmpps xmm, xmm, xmm, imm8","vcmpps xmm, xmm, xmm/m128, imm8")]
    vcmpps_xmm_xmm_xmm_imm8 = 1712,
    /// <summary>
    /// vcmpps xmm, xmm, xmm/m128, imm8
    /// </summary>
    [Symbol("vcmpps xmm, xmm, m128, imm8","vcmpps xmm, xmm, xmm/m128, imm8")]
    vcmpps_xmm_xmm_m128_imm8 = 1713,
    /// <summary>
    /// vcmpps ymm, ymm, ymm/m256, imm8
    /// </summary>
    [Symbol("vcmpps ymm, ymm, ymm, imm8","vcmpps ymm, ymm, ymm/m256, imm8")]
    vcmpps_ymm_ymm_ymm_imm8 = 1714,
    /// <summary>
    /// vcmpps ymm, ymm, ymm/m256, imm8
    /// </summary>
    [Symbol("vcmpps ymm, ymm, m256, imm8","vcmpps ymm, ymm, ymm/m256, imm8")]
    vcmpps_ymm_ymm_m256_imm8 = 1715,
    /// <summary>
    /// vcmpss k1 {k2}, xmm, xmm/m32 {sae}, imm8
    /// </summary>
    [Symbol("vcmpss k1 {k2}, xmm, xmm {sae}, imm8","vcmpss k1 {k2}, xmm, xmm/m32 {sae}, imm8")]
    vcmpss_k1_k2_xmm_xmm_sae_imm8 = 1716,
    /// <summary>
    /// vcmpss k1 {k2}, xmm, xmm/m32 {sae}, imm8
    /// </summary>
    [Symbol("vcmpss k1 {k2}, xmm, m32 {sae}, imm8","vcmpss k1 {k2}, xmm, xmm/m32 {sae}, imm8")]
    vcmpss_k1_k2_xmm_m32_sae_imm8 = 1717,
    /// <summary>
    /// vcmpss xmm, xmm, xmm/m32, imm8
    /// </summary>
    [Symbol("vcmpss xmm, xmm, xmm, imm8","vcmpss xmm, xmm, xmm/m32, imm8")]
    vcmpss_xmm_xmm_xmm_imm8 = 1718,
    /// <summary>
    /// vcmpss xmm, xmm, xmm/m32, imm8
    /// </summary>
    [Symbol("vcmpss xmm, xmm, m32, imm8","vcmpss xmm, xmm, xmm/m32, imm8")]
    vcmpss_xmm_xmm_m32_imm8 = 1719,
    /// <summary>
    /// vdbpsadbw xmm {k1}{z}, xmm, xmm/m128, imm8
    /// </summary>
    [Symbol("vdbpsadbw xmm {k1}{z}, xmm, xmm, imm8","vdbpsadbw xmm {k1}{z}, xmm, xmm/m128, imm8")]
    vdbpsadbw_xmm_k1z_xmm_xmm_imm8 = 1720,
    /// <summary>
    /// vdbpsadbw xmm {k1}{z}, xmm, xmm/m128, imm8
    /// </summary>
    [Symbol("vdbpsadbw xmm {k1}{z}, xmm, m128, imm8","vdbpsadbw xmm {k1}{z}, xmm, xmm/m128, imm8")]
    vdbpsadbw_xmm_k1z_xmm_m128_imm8 = 1721,
    /// <summary>
    /// vdbpsadbw ymm {k1}{z}, ymm, ymm/m256, imm8
    /// </summary>
    [Symbol("vdbpsadbw ymm {k1}{z}, ymm, ymm, imm8","vdbpsadbw ymm {k1}{z}, ymm, ymm/m256, imm8")]
    vdbpsadbw_ymm_k1z_ymm_ymm_imm8 = 1722,
    /// <summary>
    /// vdbpsadbw ymm {k1}{z}, ymm, ymm/m256, imm8
    /// </summary>
    [Symbol("vdbpsadbw ymm {k1}{z}, ymm, m256, imm8","vdbpsadbw ymm {k1}{z}, ymm, ymm/m256, imm8")]
    vdbpsadbw_ymm_k1z_ymm_m256_imm8 = 1723,
    /// <summary>
    /// vdbpsadbw zmm {k1}{z}, zmm, zmm/m512, imm8
    /// </summary>
    [Symbol("vdbpsadbw zmm {k1}{z}, zmm, zmm, imm8","vdbpsadbw zmm {k1}{z}, zmm, zmm/m512, imm8")]
    vdbpsadbw_zmm_k1z_zmm_zmm_imm8 = 1724,
    /// <summary>
    /// vdbpsadbw zmm {k1}{z}, zmm, zmm/m512, imm8
    /// </summary>
    [Symbol("vdbpsadbw zmm {k1}{z}, zmm, m512, imm8","vdbpsadbw zmm {k1}{z}, zmm, zmm/m512, imm8")]
    vdbpsadbw_zmm_k1z_zmm_m512_imm8 = 1725,
    /// <summary>
    /// vextracti128 xmm/m128, ymm, imm8
    /// </summary>
    [Symbol("vextracti128 xmm, ymm, imm8","vextracti128 xmm/m128, ymm, imm8")]
    vextracti128_xmm_ymm_imm8 = 1726,
    /// <summary>
    /// vextracti128 xmm/m128, ymm, imm8
    /// </summary>
    [Symbol("vextracti128 m128, ymm, imm8","vextracti128 xmm/m128, ymm, imm8")]
    vextracti128_m128_ymm_imm8 = 1727,
    /// <summary>
    /// vextracti32x4 xmm/m128 {k1}{z}, ymm, imm8
    /// </summary>
    [Symbol("vextracti32x4 xmm {k1}{z}, ymm, imm8","vextracti32x4 xmm/m128 {k1}{z}, ymm, imm8")]
    vextracti32x4_xmm_k1z_ymm_imm8 = 1728,
    /// <summary>
    /// vextracti32x4 xmm/m128 {k1}{z}, ymm, imm8
    /// </summary>
    [Symbol("vextracti32x4 m128 {k1}{z}, ymm, imm8","vextracti32x4 xmm/m128 {k1}{z}, ymm, imm8")]
    vextracti32x4_m128_k1z_ymm_imm8 = 1729,
    /// <summary>
    /// vextracti32x4 xmm/m128 {k1}{z}, zmm, imm8
    /// </summary>
    [Symbol("vextracti32x4 xmm {k1}{z}, zmm, imm8","vextracti32x4 xmm/m128 {k1}{z}, zmm, imm8")]
    vextracti32x4_xmm_k1z_zmm_imm8 = 1730,
    /// <summary>
    /// vextracti32x4 xmm/m128 {k1}{z}, zmm, imm8
    /// </summary>
    [Symbol("vextracti32x4 m128 {k1}{z}, zmm, imm8","vextracti32x4 xmm/m128 {k1}{z}, zmm, imm8")]
    vextracti32x4_m128_k1z_zmm_imm8 = 1731,
    /// <summary>
    /// vextracti32x8 ymm/m256 {k1}{z}, zmm, imm8
    /// </summary>
    [Symbol("vextracti32x8 ymm {k1}{z}, zmm, imm8","vextracti32x8 ymm/m256 {k1}{z}, zmm, imm8")]
    vextracti32x8_ymm_k1z_zmm_imm8 = 1732,
    /// <summary>
    /// vextracti32x8 ymm/m256 {k1}{z}, zmm, imm8
    /// </summary>
    [Symbol("vextracti32x8 m256 {k1}{z}, zmm, imm8","vextracti32x8 ymm/m256 {k1}{z}, zmm, imm8")]
    vextracti32x8_m256_k1z_zmm_imm8 = 1733,
    /// <summary>
    /// vextracti64x2 xmm/m128 {k1}{z}, ymm, imm8
    /// </summary>
    [Symbol("vextracti64x2 xmm {k1}{z}, ymm, imm8","vextracti64x2 xmm/m128 {k1}{z}, ymm, imm8")]
    vextracti64x2_xmm_k1z_ymm_imm8 = 1734,
    /// <summary>
    /// vextracti64x2 xmm/m128 {k1}{z}, ymm, imm8
    /// </summary>
    [Symbol("vextracti64x2 m128 {k1}{z}, ymm, imm8","vextracti64x2 xmm/m128 {k1}{z}, ymm, imm8")]
    vextracti64x2_m128_k1z_ymm_imm8 = 1735,
    /// <summary>
    /// vextracti64x2 xmm/m128 {k1}{z}, zmm, imm8
    /// </summary>
    [Symbol("vextracti64x2 xmm {k1}{z}, zmm, imm8","vextracti64x2 xmm/m128 {k1}{z}, zmm, imm8")]
    vextracti64x2_xmm_k1z_zmm_imm8 = 1736,
    /// <summary>
    /// vextracti64x2 xmm/m128 {k1}{z}, zmm, imm8
    /// </summary>
    [Symbol("vextracti64x2 m128 {k1}{z}, zmm, imm8","vextracti64x2 xmm/m128 {k1}{z}, zmm, imm8")]
    vextracti64x2_m128_k1z_zmm_imm8 = 1737,
    /// <summary>
    /// vextracti64x4 ymm/m256 {k1}{z}, zmm, imm8
    /// </summary>
    [Symbol("vextracti64x4 ymm {k1}{z}, zmm, imm8","vextracti64x4 ymm/m256 {k1}{z}, zmm, imm8")]
    vextracti64x4_ymm_k1z_zmm_imm8 = 1738,
    /// <summary>
    /// vextracti64x4 ymm/m256 {k1}{z}, zmm, imm8
    /// </summary>
    [Symbol("vextracti64x4 m256 {k1}{z}, zmm, imm8","vextracti64x4 ymm/m256 {k1}{z}, zmm, imm8")]
    vextracti64x4_m256_k1z_zmm_imm8 = 1739,
    /// <summary>
    /// vinserti128 ymm, ymm, xmm/m128, imm8
    /// </summary>
    [Symbol("vinserti128 ymm, ymm, xmm, imm8","vinserti128 ymm, ymm, xmm/m128, imm8")]
    vinserti128_ymm_ymm_xmm_imm8 = 1740,
    /// <summary>
    /// vinserti128 ymm, ymm, xmm/m128, imm8
    /// </summary>
    [Symbol("vinserti128 ymm, ymm, m128, imm8","vinserti128 ymm, ymm, xmm/m128, imm8")]
    vinserti128_ymm_ymm_m128_imm8 = 1741,
    /// <summary>
    /// vinserti32x4 ymm {k1}{z}, ymm, xmm/m128, imm8
    /// </summary>
    [Symbol("vinserti32x4 ymm {k1}{z}, ymm, xmm, imm8","vinserti32x4 ymm {k1}{z}, ymm, xmm/m128, imm8")]
    vinserti32x4_ymm_k1z_ymm_xmm_imm8 = 1742,
    /// <summary>
    /// vinserti32x4 ymm {k1}{z}, ymm, xmm/m128, imm8
    /// </summary>
    [Symbol("vinserti32x4 ymm {k1}{z}, ymm, m128, imm8","vinserti32x4 ymm {k1}{z}, ymm, xmm/m128, imm8")]
    vinserti32x4_ymm_k1z_ymm_m128_imm8 = 1743,
    /// <summary>
    /// vinserti32x4 zmm {k1}{z}, zmm, xmm/m128, imm8
    /// </summary>
    [Symbol("vinserti32x4 zmm {k1}{z}, zmm, xmm, imm8","vinserti32x4 zmm {k1}{z}, zmm, xmm/m128, imm8")]
    vinserti32x4_zmm_k1z_zmm_xmm_imm8 = 1744,
    /// <summary>
    /// vinserti32x4 zmm {k1}{z}, zmm, xmm/m128, imm8
    /// </summary>
    [Symbol("vinserti32x4 zmm {k1}{z}, zmm, m128, imm8","vinserti32x4 zmm {k1}{z}, zmm, xmm/m128, imm8")]
    vinserti32x4_zmm_k1z_zmm_m128_imm8 = 1745,
    /// <summary>
    /// vinserti32x8 zmm {k1}{z}, zmm, ymm/m256, imm8
    /// </summary>
    [Symbol("vinserti32x8 zmm {k1}{z}, zmm, ymm, imm8","vinserti32x8 zmm {k1}{z}, zmm, ymm/m256, imm8")]
    vinserti32x8_zmm_k1z_zmm_ymm_imm8 = 1746,
    /// <summary>
    /// vinserti32x8 zmm {k1}{z}, zmm, ymm/m256, imm8
    /// </summary>
    [Symbol("vinserti32x8 zmm {k1}{z}, zmm, m256, imm8","vinserti32x8 zmm {k1}{z}, zmm, ymm/m256, imm8")]
    vinserti32x8_zmm_k1z_zmm_m256_imm8 = 1747,
    /// <summary>
    /// vinserti64x2 ymm {k1}{z}, ymm, xmm/m128, imm8
    /// </summary>
    [Symbol("vinserti64x2 ymm {k1}{z}, ymm, xmm, imm8","vinserti64x2 ymm {k1}{z}, ymm, xmm/m128, imm8")]
    vinserti64x2_ymm_k1z_ymm_xmm_imm8 = 1748,
    /// <summary>
    /// vinserti64x2 ymm {k1}{z}, ymm, xmm/m128, imm8
    /// </summary>
    [Symbol("vinserti64x2 ymm {k1}{z}, ymm, m128, imm8","vinserti64x2 ymm {k1}{z}, ymm, xmm/m128, imm8")]
    vinserti64x2_ymm_k1z_ymm_m128_imm8 = 1749,
    /// <summary>
    /// vinserti64x2 zmm {k1}{z}, zmm, xmm/m128, imm8
    /// </summary>
    [Symbol("vinserti64x2 zmm {k1}{z}, zmm, xmm, imm8","vinserti64x2 zmm {k1}{z}, zmm, xmm/m128, imm8")]
    vinserti64x2_zmm_k1z_zmm_xmm_imm8 = 1750,
    /// <summary>
    /// vinserti64x2 zmm {k1}{z}, zmm, xmm/m128, imm8
    /// </summary>
    [Symbol("vinserti64x2 zmm {k1}{z}, zmm, m128, imm8","vinserti64x2 zmm {k1}{z}, zmm, xmm/m128, imm8")]
    vinserti64x2_zmm_k1z_zmm_m128_imm8 = 1751,
    /// <summary>
    /// vinserti64x4 zmm {k1}{z}, zmm, ymm/m256, imm8
    /// </summary>
    [Symbol("vinserti64x4 zmm {k1}{z}, zmm, ymm, imm8","vinserti64x4 zmm {k1}{z}, zmm, ymm/m256, imm8")]
    vinserti64x4_zmm_k1z_zmm_ymm_imm8 = 1752,
    /// <summary>
    /// vinserti64x4 zmm {k1}{z}, zmm, ymm/m256, imm8
    /// </summary>
    [Symbol("vinserti64x4 zmm {k1}{z}, zmm, m256, imm8","vinserti64x4 zmm {k1}{z}, zmm, ymm/m256, imm8")]
    vinserti64x4_zmm_k1z_zmm_m256_imm8 = 1753,
    /// <summary>
    /// vlddqu xmm, m128
    /// </summary>
    [Symbol("vlddqu xmm, m128","vlddqu xmm, m128")]
    vlddqu_xmm_m128 = 1754,
    /// <summary>
    /// vlddqu ymm, m256
    /// </summary>
    [Symbol("vlddqu ymm, m256","vlddqu ymm, m256")]
    vlddqu_ymm_m256 = 1755,
    /// <summary>
    /// vmaskmovdqu xmm, xmm
    /// </summary>
    [Symbol("vmaskmovdqu xmm, xmm","vmaskmovdqu xmm, xmm")]
    vmaskmovdqu_xmm_xmm = 1756,
    /// <summary>
    /// vmaskmovpd m128, xmm, xmm
    /// </summary>
    [Symbol("vmaskmovpd m128, xmm, xmm","vmaskmovpd m128, xmm, xmm")]
    vmaskmovpd_m128_xmm_xmm = 1757,
    /// <summary>
    /// vmaskmovpd m256, ymm, ymm
    /// </summary>
    [Symbol("vmaskmovpd m256, ymm, ymm","vmaskmovpd m256, ymm, ymm")]
    vmaskmovpd_m256_ymm_ymm = 1758,
    /// <summary>
    /// vmaskmovpd xmm, xmm, m128
    /// </summary>
    [Symbol("vmaskmovpd xmm, xmm, m128","vmaskmovpd xmm, xmm, m128")]
    vmaskmovpd_xmm_xmm_m128 = 1759,
    /// <summary>
    /// vmaskmovpd ymm, ymm, m256
    /// </summary>
    [Symbol("vmaskmovpd ymm, ymm, m256","vmaskmovpd ymm, ymm, m256")]
    vmaskmovpd_ymm_ymm_m256 = 1760,
    /// <summary>
    /// vmaskmovps m128, xmm, xmm
    /// </summary>
    [Symbol("vmaskmovps m128, xmm, xmm","vmaskmovps m128, xmm, xmm")]
    vmaskmovps_m128_xmm_xmm = 1761,
    /// <summary>
    /// vmaskmovps m256, ymm, ymm
    /// </summary>
    [Symbol("vmaskmovps m256, ymm, ymm","vmaskmovps m256, ymm, ymm")]
    vmaskmovps_m256_ymm_ymm = 1762,
    /// <summary>
    /// vmaskmovps xmm, xmm, m128
    /// </summary>
    [Symbol("vmaskmovps xmm, xmm, m128","vmaskmovps xmm, xmm, m128")]
    vmaskmovps_xmm_xmm_m128 = 1763,
    /// <summary>
    /// vmaskmovps ymm, ymm, m256
    /// </summary>
    [Symbol("vmaskmovps ymm, ymm, m256","vmaskmovps ymm, ymm, m256")]
    vmaskmovps_ymm_ymm_m256 = 1764,
    /// <summary>
    /// vmovapd xmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vmovapd xmm {k1}{z}, xmm","vmovapd xmm {k1}{z}, xmm/m128")]
    vmovapd_xmm_k1z_xmm = 1765,
    /// <summary>
    /// vmovapd xmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vmovapd xmm {k1}{z}, m128","vmovapd xmm {k1}{z}, xmm/m128")]
    vmovapd_xmm_k1z_m128 = 1766,
    /// <summary>
    /// vmovapd xmm, xmm/m128
    /// </summary>
    [Symbol("vmovapd xmm, xmm","vmovapd xmm, xmm/m128")]
    vmovapd_xmm_xmm = 1767,
    /// <summary>
    /// vmovapd xmm, xmm/m128
    /// </summary>
    [Symbol("vmovapd xmm, m128","vmovapd xmm, xmm/m128")]
    vmovapd_xmm_m128 = 1768,
    /// <summary>
    /// vmovapd xmm/m128 {k1}{z}, xmm
    /// </summary>
    [Symbol("vmovapd m128 {k1}{z}, xmm","vmovapd xmm/m128 {k1}{z}, xmm")]
    vmovapd_m128_k1z_xmm = 1769,
    /// <summary>
    /// vmovapd xmm/m128, xmm
    /// </summary>
    [Symbol("vmovapd m128, xmm","vmovapd xmm/m128, xmm")]
    vmovapd_m128_xmm = 1770,
    /// <summary>
    /// vmovapd ymm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vmovapd ymm {k1}{z}, ymm","vmovapd ymm {k1}{z}, ymm/m256")]
    vmovapd_ymm_k1z_ymm = 1771,
    /// <summary>
    /// vmovapd ymm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vmovapd ymm {k1}{z}, m256","vmovapd ymm {k1}{z}, ymm/m256")]
    vmovapd_ymm_k1z_m256 = 1772,
    /// <summary>
    /// vmovapd ymm, ymm/m256
    /// </summary>
    [Symbol("vmovapd ymm, ymm","vmovapd ymm, ymm/m256")]
    vmovapd_ymm_ymm = 1773,
    /// <summary>
    /// vmovapd ymm, ymm/m256
    /// </summary>
    [Symbol("vmovapd ymm, m256","vmovapd ymm, ymm/m256")]
    vmovapd_ymm_m256 = 1774,
    /// <summary>
    /// vmovapd ymm/m256 {k1}{z}, ymm
    /// </summary>
    [Symbol("vmovapd m256 {k1}{z}, ymm","vmovapd ymm/m256 {k1}{z}, ymm")]
    vmovapd_m256_k1z_ymm = 1775,
    /// <summary>
    /// vmovapd ymm/m256, ymm
    /// </summary>
    [Symbol("vmovapd m256, ymm","vmovapd ymm/m256, ymm")]
    vmovapd_m256_ymm = 1776,
    /// <summary>
    /// vmovapd zmm {k1}{z}, zmm/m512
    /// </summary>
    [Symbol("vmovapd zmm {k1}{z}, zmm","vmovapd zmm {k1}{z}, zmm/m512")]
    vmovapd_zmm_k1z_zmm = 1777,
    /// <summary>
    /// vmovapd zmm {k1}{z}, zmm/m512
    /// </summary>
    [Symbol("vmovapd zmm {k1}{z}, m512","vmovapd zmm {k1}{z}, zmm/m512")]
    vmovapd_zmm_k1z_m512 = 1778,
    /// <summary>
    /// vmovapd zmm/m512 {k1}{z}, zmm
    /// </summary>
    [Symbol("vmovapd m512 {k1}{z}, zmm","vmovapd zmm/m512 {k1}{z}, zmm")]
    vmovapd_m512_k1z_zmm = 1779,
    /// <summary>
    /// vmovaps xmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vmovaps xmm {k1}{z}, xmm","vmovaps xmm {k1}{z}, xmm/m128")]
    vmovaps_xmm_k1z_xmm = 1780,
    /// <summary>
    /// vmovaps xmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vmovaps xmm {k1}{z}, m128","vmovaps xmm {k1}{z}, xmm/m128")]
    vmovaps_xmm_k1z_m128 = 1781,
    /// <summary>
    /// vmovaps xmm, xmm/m128
    /// </summary>
    [Symbol("vmovaps xmm, xmm","vmovaps xmm, xmm/m128")]
    vmovaps_xmm_xmm = 1782,
    /// <summary>
    /// vmovaps xmm, xmm/m128
    /// </summary>
    [Symbol("vmovaps xmm, m128","vmovaps xmm, xmm/m128")]
    vmovaps_xmm_m128 = 1783,
    /// <summary>
    /// vmovaps xmm/m128 {k1}{z}, xmm
    /// </summary>
    [Symbol("vmovaps m128 {k1}{z}, xmm","vmovaps xmm/m128 {k1}{z}, xmm")]
    vmovaps_m128_k1z_xmm = 1784,
    /// <summary>
    /// vmovaps xmm/m128, xmm
    /// </summary>
    [Symbol("vmovaps m128, xmm","vmovaps xmm/m128, xmm")]
    vmovaps_m128_xmm = 1785,
    /// <summary>
    /// vmovaps ymm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vmovaps ymm {k1}{z}, ymm","vmovaps ymm {k1}{z}, ymm/m256")]
    vmovaps_ymm_k1z_ymm = 1786,
    /// <summary>
    /// vmovaps ymm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vmovaps ymm {k1}{z}, m256","vmovaps ymm {k1}{z}, ymm/m256")]
    vmovaps_ymm_k1z_m256 = 1787,
    /// <summary>
    /// vmovaps ymm, ymm/m256
    /// </summary>
    [Symbol("vmovaps ymm, ymm","vmovaps ymm, ymm/m256")]
    vmovaps_ymm_ymm = 1788,
    /// <summary>
    /// vmovaps ymm, ymm/m256
    /// </summary>
    [Symbol("vmovaps ymm, m256","vmovaps ymm, ymm/m256")]
    vmovaps_ymm_m256 = 1789,
    /// <summary>
    /// vmovaps ymm/m256 {k1}{z}, ymm
    /// </summary>
    [Symbol("vmovaps m256 {k1}{z}, ymm","vmovaps ymm/m256 {k1}{z}, ymm")]
    vmovaps_m256_k1z_ymm = 1790,
    /// <summary>
    /// vmovaps ymm/m256, ymm
    /// </summary>
    [Symbol("vmovaps m256, ymm","vmovaps ymm/m256, ymm")]
    vmovaps_m256_ymm = 1791,
    /// <summary>
    /// vmovaps zmm {k1}{z}, zmm/m512
    /// </summary>
    [Symbol("vmovaps zmm {k1}{z}, zmm","vmovaps zmm {k1}{z}, zmm/m512")]
    vmovaps_zmm_k1z_zmm = 1792,
    /// <summary>
    /// vmovaps zmm {k1}{z}, zmm/m512
    /// </summary>
    [Symbol("vmovaps zmm {k1}{z}, m512","vmovaps zmm {k1}{z}, zmm/m512")]
    vmovaps_zmm_k1z_m512 = 1793,
    /// <summary>
    /// vmovaps zmm/m512 {k1}{z}, zmm
    /// </summary>
    [Symbol("vmovaps m512 {k1}{z}, zmm","vmovaps zmm/m512 {k1}{z}, zmm")]
    vmovaps_m512_k1z_zmm = 1794,
    /// <summary>
    /// vmovd r32/m32, xmm
    /// </summary>
    [Symbol("vmovd r32, xmm","vmovd r32/m32, xmm")]
    vmovd_r32_xmm = 1795,
    /// <summary>
    /// vmovd r32/m32, xmm
    /// </summary>
    [Symbol("vmovd m32, xmm","vmovd r32/m32, xmm")]
    vmovd_m32_xmm = 1796,
    /// <summary>
    /// vmovd xmm, r32/m32
    /// </summary>
    [Symbol("vmovd xmm, r32","vmovd xmm, r32/m32")]
    vmovd_xmm_r32 = 1797,
    /// <summary>
    /// vmovd xmm, r32/m32
    /// </summary>
    [Symbol("vmovd xmm, m32","vmovd xmm, r32/m32")]
    vmovd_xmm_m32 = 1798,
    /// <summary>
    /// vmovdqa xmm, xmm/m128
    /// </summary>
    [Symbol("vmovdqa xmm, xmm","vmovdqa xmm, xmm/m128")]
    vmovdqa_xmm_xmm = 1799,
    /// <summary>
    /// vmovdqa xmm, xmm/m128
    /// </summary>
    [Symbol("vmovdqa xmm, m128","vmovdqa xmm, xmm/m128")]
    vmovdqa_xmm_m128 = 1800,
    /// <summary>
    /// vmovdqa xmm/m128, xmm
    /// </summary>
    [Symbol("vmovdqa m128, xmm","vmovdqa xmm/m128, xmm")]
    vmovdqa_m128_xmm = 1801,
    /// <summary>
    /// vmovdqa ymm, ymm/m256
    /// </summary>
    [Symbol("vmovdqa ymm, ymm","vmovdqa ymm, ymm/m256")]
    vmovdqa_ymm_ymm = 1802,
    /// <summary>
    /// vmovdqa ymm, ymm/m256
    /// </summary>
    [Symbol("vmovdqa ymm, m256","vmovdqa ymm, ymm/m256")]
    vmovdqa_ymm_m256 = 1803,
    /// <summary>
    /// vmovdqa ymm/m256, ymm
    /// </summary>
    [Symbol("vmovdqa m256, ymm","vmovdqa ymm/m256, ymm")]
    vmovdqa_m256_ymm = 1804,
    /// <summary>
    /// vmovdqa32 xmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vmovdqa32 xmm {k1}{z}, xmm","vmovdqa32 xmm {k1}{z}, xmm/m128")]
    vmovdqa32_xmm_k1z_xmm = 1805,
    /// <summary>
    /// vmovdqa32 xmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vmovdqa32 xmm {k1}{z}, m128","vmovdqa32 xmm {k1}{z}, xmm/m128")]
    vmovdqa32_xmm_k1z_m128 = 1806,
    /// <summary>
    /// vmovdqa32 xmm/m128 {k1}{z}, xmm
    /// </summary>
    [Symbol("vmovdqa32 m128 {k1}{z}, xmm","vmovdqa32 xmm/m128 {k1}{z}, xmm")]
    vmovdqa32_m128_k1z_xmm = 1807,
    /// <summary>
    /// vmovdqa32 ymm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vmovdqa32 ymm {k1}{z}, ymm","vmovdqa32 ymm {k1}{z}, ymm/m256")]
    vmovdqa32_ymm_k1z_ymm = 1808,
    /// <summary>
    /// vmovdqa32 ymm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vmovdqa32 ymm {k1}{z}, m256","vmovdqa32 ymm {k1}{z}, ymm/m256")]
    vmovdqa32_ymm_k1z_m256 = 1809,
    /// <summary>
    /// vmovdqa32 ymm/m256 {k1}{z}, ymm
    /// </summary>
    [Symbol("vmovdqa32 m256 {k1}{z}, ymm","vmovdqa32 ymm/m256 {k1}{z}, ymm")]
    vmovdqa32_m256_k1z_ymm = 1810,
    /// <summary>
    /// vmovdqa32 zmm {k1}{z}, zmm/m512
    /// </summary>
    [Symbol("vmovdqa32 zmm {k1}{z}, zmm","vmovdqa32 zmm {k1}{z}, zmm/m512")]
    vmovdqa32_zmm_k1z_zmm = 1811,
    /// <summary>
    /// vmovdqa32 zmm {k1}{z}, zmm/m512
    /// </summary>
    [Symbol("vmovdqa32 zmm {k1}{z}, m512","vmovdqa32 zmm {k1}{z}, zmm/m512")]
    vmovdqa32_zmm_k1z_m512 = 1812,
    /// <summary>
    /// vmovdqa32 zmm/m512 {k1}{z}, zmm
    /// </summary>
    [Symbol("vmovdqa32 m512 {k1}{z}, zmm","vmovdqa32 zmm/m512 {k1}{z}, zmm")]
    vmovdqa32_m512_k1z_zmm = 1813,
    /// <summary>
    /// vmovdqa64 xmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vmovdqa64 xmm {k1}{z}, xmm","vmovdqa64 xmm {k1}{z}, xmm/m128")]
    vmovdqa64_xmm_k1z_xmm = 1814,
    /// <summary>
    /// vmovdqa64 xmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vmovdqa64 xmm {k1}{z}, m128","vmovdqa64 xmm {k1}{z}, xmm/m128")]
    vmovdqa64_xmm_k1z_m128 = 1815,
    /// <summary>
    /// vmovdqa64 xmm/m128 {k1}{z}, xmm
    /// </summary>
    [Symbol("vmovdqa64 m128 {k1}{z}, xmm","vmovdqa64 xmm/m128 {k1}{z}, xmm")]
    vmovdqa64_m128_k1z_xmm = 1816,
    /// <summary>
    /// vmovdqa64 ymm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vmovdqa64 ymm {k1}{z}, ymm","vmovdqa64 ymm {k1}{z}, ymm/m256")]
    vmovdqa64_ymm_k1z_ymm = 1817,
    /// <summary>
    /// vmovdqa64 ymm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vmovdqa64 ymm {k1}{z}, m256","vmovdqa64 ymm {k1}{z}, ymm/m256")]
    vmovdqa64_ymm_k1z_m256 = 1818,
    /// <summary>
    /// vmovdqa64 ymm/m256 {k1}{z}, ymm
    /// </summary>
    [Symbol("vmovdqa64 m256 {k1}{z}, ymm","vmovdqa64 ymm/m256 {k1}{z}, ymm")]
    vmovdqa64_m256_k1z_ymm = 1819,
    /// <summary>
    /// vmovdqa64 zmm {k1}{z}, zmm/m512
    /// </summary>
    [Symbol("vmovdqa64 zmm {k1}{z}, zmm","vmovdqa64 zmm {k1}{z}, zmm/m512")]
    vmovdqa64_zmm_k1z_zmm = 1820,
    /// <summary>
    /// vmovdqa64 zmm {k1}{z}, zmm/m512
    /// </summary>
    [Symbol("vmovdqa64 zmm {k1}{z}, m512","vmovdqa64 zmm {k1}{z}, zmm/m512")]
    vmovdqa64_zmm_k1z_m512 = 1821,
    /// <summary>
    /// vmovdqa64 zmm/m512 {k1}{z}, zmm
    /// </summary>
    [Symbol("vmovdqa64 m512 {k1}{z}, zmm","vmovdqa64 zmm/m512 {k1}{z}, zmm")]
    vmovdqa64_m512_k1z_zmm = 1822,
    /// <summary>
    /// vmovdqu xmm, xmm/m128
    /// </summary>
    [Symbol("vmovdqu xmm, xmm","vmovdqu xmm, xmm/m128")]
    vmovdqu_xmm_xmm = 1823,
    /// <summary>
    /// vmovdqu xmm, xmm/m128
    /// </summary>
    [Symbol("vmovdqu xmm, m128","vmovdqu xmm, xmm/m128")]
    vmovdqu_xmm_m128 = 1824,
    /// <summary>
    /// vmovdqu xmm/m128, xmm
    /// </summary>
    [Symbol("vmovdqu m128, xmm","vmovdqu xmm/m128, xmm")]
    vmovdqu_m128_xmm = 1825,
    /// <summary>
    /// vmovdqu ymm, ymm/m256
    /// </summary>
    [Symbol("vmovdqu ymm, ymm","vmovdqu ymm, ymm/m256")]
    vmovdqu_ymm_ymm = 1826,
    /// <summary>
    /// vmovdqu ymm, ymm/m256
    /// </summary>
    [Symbol("vmovdqu ymm, m256","vmovdqu ymm, ymm/m256")]
    vmovdqu_ymm_m256 = 1827,
    /// <summary>
    /// vmovdqu ymm/m256, ymm
    /// </summary>
    [Symbol("vmovdqu m256, ymm","vmovdqu ymm/m256, ymm")]
    vmovdqu_m256_ymm = 1828,
    /// <summary>
    /// vmovdqu16 xmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vmovdqu16 xmm {k1}{z}, xmm","vmovdqu16 xmm {k1}{z}, xmm/m128")]
    vmovdqu16_xmm_k1z_xmm = 1829,
    /// <summary>
    /// vmovdqu16 xmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vmovdqu16 xmm {k1}{z}, m128","vmovdqu16 xmm {k1}{z}, xmm/m128")]
    vmovdqu16_xmm_k1z_m128 = 1830,
    /// <summary>
    /// vmovdqu16 xmm/m128 {k1}{z}, xmm
    /// </summary>
    [Symbol("vmovdqu16 m128 {k1}{z}, xmm","vmovdqu16 xmm/m128 {k1}{z}, xmm")]
    vmovdqu16_m128_k1z_xmm = 1831,
    /// <summary>
    /// vmovdqu16 ymm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vmovdqu16 ymm {k1}{z}, ymm","vmovdqu16 ymm {k1}{z}, ymm/m256")]
    vmovdqu16_ymm_k1z_ymm = 1832,
    /// <summary>
    /// vmovdqu16 ymm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vmovdqu16 ymm {k1}{z}, m256","vmovdqu16 ymm {k1}{z}, ymm/m256")]
    vmovdqu16_ymm_k1z_m256 = 1833,
    /// <summary>
    /// vmovdqu16 ymm/m256 {k1}{z}, ymm
    /// </summary>
    [Symbol("vmovdqu16 m256 {k1}{z}, ymm","vmovdqu16 ymm/m256 {k1}{z}, ymm")]
    vmovdqu16_m256_k1z_ymm = 1834,
    /// <summary>
    /// vmovdqu16 zmm {k1}{z}, zmm/m512
    /// </summary>
    [Symbol("vmovdqu16 zmm {k1}{z}, zmm","vmovdqu16 zmm {k1}{z}, zmm/m512")]
    vmovdqu16_zmm_k1z_zmm = 1835,
    /// <summary>
    /// vmovdqu16 zmm {k1}{z}, zmm/m512
    /// </summary>
    [Symbol("vmovdqu16 zmm {k1}{z}, m512","vmovdqu16 zmm {k1}{z}, zmm/m512")]
    vmovdqu16_zmm_k1z_m512 = 1836,
    /// <summary>
    /// vmovdqu16 zmm/m512 {k1}{z}, zmm
    /// </summary>
    [Symbol("vmovdqu16 m512 {k1}{z}, zmm","vmovdqu16 zmm/m512 {k1}{z}, zmm")]
    vmovdqu16_m512_k1z_zmm = 1837,
    /// <summary>
    /// vmovdqu32 xmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vmovdqu32 xmm {k1}{z}, xmm","vmovdqu32 xmm {k1}{z}, xmm/m128")]
    vmovdqu32_xmm_k1z_xmm = 1838,
    /// <summary>
    /// vmovdqu32 xmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vmovdqu32 xmm {k1}{z}, m128","vmovdqu32 xmm {k1}{z}, xmm/m128")]
    vmovdqu32_xmm_k1z_m128 = 1839,
    /// <summary>
    /// vmovdqu32 xmm/m128 {k1}{z}, xmm
    /// </summary>
    [Symbol("vmovdqu32 m128 {k1}{z}, xmm","vmovdqu32 xmm/m128 {k1}{z}, xmm")]
    vmovdqu32_m128_k1z_xmm = 1840,
    /// <summary>
    /// vmovdqu32 ymm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vmovdqu32 ymm {k1}{z}, ymm","vmovdqu32 ymm {k1}{z}, ymm/m256")]
    vmovdqu32_ymm_k1z_ymm = 1841,
    /// <summary>
    /// vmovdqu32 ymm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vmovdqu32 ymm {k1}{z}, m256","vmovdqu32 ymm {k1}{z}, ymm/m256")]
    vmovdqu32_ymm_k1z_m256 = 1842,
    /// <summary>
    /// vmovdqu32 ymm/m256 {k1}{z}, ymm
    /// </summary>
    [Symbol("vmovdqu32 m256 {k1}{z}, ymm","vmovdqu32 ymm/m256 {k1}{z}, ymm")]
    vmovdqu32_m256_k1z_ymm = 1843,
    /// <summary>
    /// vmovdqu32 zmm {k1}{z}, zmm/m512
    /// </summary>
    [Symbol("vmovdqu32 zmm {k1}{z}, zmm","vmovdqu32 zmm {k1}{z}, zmm/m512")]
    vmovdqu32_zmm_k1z_zmm = 1844,
    /// <summary>
    /// vmovdqu32 zmm {k1}{z}, zmm/m512
    /// </summary>
    [Symbol("vmovdqu32 zmm {k1}{z}, m512","vmovdqu32 zmm {k1}{z}, zmm/m512")]
    vmovdqu32_zmm_k1z_m512 = 1845,
    /// <summary>
    /// vmovdqu32 zmm/m512 {k1}{z}, zmm
    /// </summary>
    [Symbol("vmovdqu32 m512 {k1}{z}, zmm","vmovdqu32 zmm/m512 {k1}{z}, zmm")]
    vmovdqu32_m512_k1z_zmm = 1846,
    /// <summary>
    /// vmovdqu64 xmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vmovdqu64 xmm {k1}{z}, xmm","vmovdqu64 xmm {k1}{z}, xmm/m128")]
    vmovdqu64_xmm_k1z_xmm = 1847,
    /// <summary>
    /// vmovdqu64 xmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vmovdqu64 xmm {k1}{z}, m128","vmovdqu64 xmm {k1}{z}, xmm/m128")]
    vmovdqu64_xmm_k1z_m128 = 1848,
    /// <summary>
    /// vmovdqu64 xmm/m128 {k1}{z}, xmm
    /// </summary>
    [Symbol("vmovdqu64 m128 {k1}{z}, xmm","vmovdqu64 xmm/m128 {k1}{z}, xmm")]
    vmovdqu64_m128_k1z_xmm = 1849,
    /// <summary>
    /// vmovdqu64 ymm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vmovdqu64 ymm {k1}{z}, ymm","vmovdqu64 ymm {k1}{z}, ymm/m256")]
    vmovdqu64_ymm_k1z_ymm = 1850,
    /// <summary>
    /// vmovdqu64 ymm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vmovdqu64 ymm {k1}{z}, m256","vmovdqu64 ymm {k1}{z}, ymm/m256")]
    vmovdqu64_ymm_k1z_m256 = 1851,
    /// <summary>
    /// vmovdqu64 ymm/m256 {k1}{z}, ymm
    /// </summary>
    [Symbol("vmovdqu64 m256 {k1}{z}, ymm","vmovdqu64 ymm/m256 {k1}{z}, ymm")]
    vmovdqu64_m256_k1z_ymm = 1852,
    /// <summary>
    /// vmovdqu64 zmm {k1}{z}, zmm/m512
    /// </summary>
    [Symbol("vmovdqu64 zmm {k1}{z}, zmm","vmovdqu64 zmm {k1}{z}, zmm/m512")]
    vmovdqu64_zmm_k1z_zmm = 1853,
    /// <summary>
    /// vmovdqu64 zmm {k1}{z}, zmm/m512
    /// </summary>
    [Symbol("vmovdqu64 zmm {k1}{z}, m512","vmovdqu64 zmm {k1}{z}, zmm/m512")]
    vmovdqu64_zmm_k1z_m512 = 1854,
    /// <summary>
    /// vmovdqu64 zmm/m512 {k1}{z}, zmm
    /// </summary>
    [Symbol("vmovdqu64 m512 {k1}{z}, zmm","vmovdqu64 zmm/m512 {k1}{z}, zmm")]
    vmovdqu64_m512_k1z_zmm = 1855,
    /// <summary>
    /// vmovdqu8 xmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vmovdqu8 xmm {k1}{z}, xmm","vmovdqu8 xmm {k1}{z}, xmm/m128")]
    vmovdqu8_xmm_k1z_xmm = 1856,
    /// <summary>
    /// vmovdqu8 xmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vmovdqu8 xmm {k1}{z}, m128","vmovdqu8 xmm {k1}{z}, xmm/m128")]
    vmovdqu8_xmm_k1z_m128 = 1857,
    /// <summary>
    /// vmovdqu8 xmm/m128 {k1}{z}, xmm
    /// </summary>
    [Symbol("vmovdqu8 m128 {k1}{z}, xmm","vmovdqu8 xmm/m128 {k1}{z}, xmm")]
    vmovdqu8_m128_k1z_xmm = 1858,
    /// <summary>
    /// vmovdqu8 ymm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vmovdqu8 ymm {k1}{z}, ymm","vmovdqu8 ymm {k1}{z}, ymm/m256")]
    vmovdqu8_ymm_k1z_ymm = 1859,
    /// <summary>
    /// vmovdqu8 ymm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vmovdqu8 ymm {k1}{z}, m256","vmovdqu8 ymm {k1}{z}, ymm/m256")]
    vmovdqu8_ymm_k1z_m256 = 1860,
    /// <summary>
    /// vmovdqu8 ymm/m256 {k1}{z}, ymm
    /// </summary>
    [Symbol("vmovdqu8 m256 {k1}{z}, ymm","vmovdqu8 ymm/m256 {k1}{z}, ymm")]
    vmovdqu8_m256_k1z_ymm = 1861,
    /// <summary>
    /// vmovdqu8 zmm {k1}{z}, zmm/m512
    /// </summary>
    [Symbol("vmovdqu8 zmm {k1}{z}, zmm","vmovdqu8 zmm {k1}{z}, zmm/m512")]
    vmovdqu8_zmm_k1z_zmm = 1862,
    /// <summary>
    /// vmovdqu8 zmm {k1}{z}, zmm/m512
    /// </summary>
    [Symbol("vmovdqu8 zmm {k1}{z}, m512","vmovdqu8 zmm {k1}{z}, zmm/m512")]
    vmovdqu8_zmm_k1z_m512 = 1863,
    /// <summary>
    /// vmovdqu8 zmm/m512 {k1}{z}, zmm
    /// </summary>
    [Symbol("vmovdqu8 m512 {k1}{z}, zmm","vmovdqu8 zmm/m512 {k1}{z}, zmm")]
    vmovdqu8_m512_k1z_zmm = 1864,
    /// <summary>
    /// vmovq r64/m64, xmm
    /// </summary>
    [Symbol("vmovq r64, xmm","vmovq r64/m64, xmm")]
    vmovq_r64_xmm = 1865,
    /// <summary>
    /// vmovq r64/m64, xmm
    /// </summary>
    [Symbol("vmovq m64, xmm","vmovq r64/m64, xmm")]
    vmovq_m64_xmm = 1866,
    /// <summary>
    /// vmovq xmm, r64/m64
    /// </summary>
    [Symbol("vmovq xmm, r64","vmovq xmm, r64/m64")]
    vmovq_xmm_r64 = 1867,
    /// <summary>
    /// vmovq xmm, r64/m64
    /// </summary>
    [Symbol("vmovq xmm, m64","vmovq xmm, r64/m64")]
    vmovq_xmm_m64 = 1868,
    /// <summary>
    /// vmovq xmm, xmm/m64
    /// </summary>
    [Symbol("vmovq xmm, xmm","vmovq xmm, xmm/m64")]
    vmovq_xmm_xmm = 1869,
    /// <summary>
    /// vmovupd xmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vmovupd xmm {k1}{z}, xmm","vmovupd xmm {k1}{z}, xmm/m128")]
    vmovupd_xmm_k1z_xmm = 1870,
    /// <summary>
    /// vmovupd xmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vmovupd xmm {k1}{z}, m128","vmovupd xmm {k1}{z}, xmm/m128")]
    vmovupd_xmm_k1z_m128 = 1871,
    /// <summary>
    /// vmovupd xmm, xmm/m128
    /// </summary>
    [Symbol("vmovupd xmm, xmm","vmovupd xmm, xmm/m128")]
    vmovupd_xmm_xmm = 1872,
    /// <summary>
    /// vmovupd xmm, xmm/m128
    /// </summary>
    [Symbol("vmovupd xmm, m128","vmovupd xmm, xmm/m128")]
    vmovupd_xmm_m128 = 1873,
    /// <summary>
    /// vmovupd xmm/m128 {k1}{z}, xmm
    /// </summary>
    [Symbol("vmovupd m128 {k1}{z}, xmm","vmovupd xmm/m128 {k1}{z}, xmm")]
    vmovupd_m128_k1z_xmm = 1874,
    /// <summary>
    /// vmovupd xmm/m128, xmm
    /// </summary>
    [Symbol("vmovupd m128, xmm","vmovupd xmm/m128, xmm")]
    vmovupd_m128_xmm = 1875,
    /// <summary>
    /// vmovupd ymm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vmovupd ymm {k1}{z}, ymm","vmovupd ymm {k1}{z}, ymm/m256")]
    vmovupd_ymm_k1z_ymm = 1876,
    /// <summary>
    /// vmovupd ymm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vmovupd ymm {k1}{z}, m256","vmovupd ymm {k1}{z}, ymm/m256")]
    vmovupd_ymm_k1z_m256 = 1877,
    /// <summary>
    /// vmovupd ymm, ymm/m256
    /// </summary>
    [Symbol("vmovupd ymm, ymm","vmovupd ymm, ymm/m256")]
    vmovupd_ymm_ymm = 1878,
    /// <summary>
    /// vmovupd ymm, ymm/m256
    /// </summary>
    [Symbol("vmovupd ymm, m256","vmovupd ymm, ymm/m256")]
    vmovupd_ymm_m256 = 1879,
    /// <summary>
    /// vmovupd ymm/m256 {k1}{z}, ymm
    /// </summary>
    [Symbol("vmovupd m256 {k1}{z}, ymm","vmovupd ymm/m256 {k1}{z}, ymm")]
    vmovupd_m256_k1z_ymm = 1880,
    /// <summary>
    /// vmovupd ymm/m256, ymm
    /// </summary>
    [Symbol("vmovupd m256, ymm","vmovupd ymm/m256, ymm")]
    vmovupd_m256_ymm = 1881,
    /// <summary>
    /// vmovupd zmm {k1}{z}, zmm/m512
    /// </summary>
    [Symbol("vmovupd zmm {k1}{z}, zmm","vmovupd zmm {k1}{z}, zmm/m512")]
    vmovupd_zmm_k1z_zmm = 1882,
    /// <summary>
    /// vmovupd zmm {k1}{z}, zmm/m512
    /// </summary>
    [Symbol("vmovupd zmm {k1}{z}, m512","vmovupd zmm {k1}{z}, zmm/m512")]
    vmovupd_zmm_k1z_m512 = 1883,
    /// <summary>
    /// vmovupd zmm/m512 {k1}{z}, zmm
    /// </summary>
    [Symbol("vmovupd m512 {k1}{z}, zmm","vmovupd zmm/m512 {k1}{z}, zmm")]
    vmovupd_m512_k1z_zmm = 1884,
    /// <summary>
    /// vmpsadbw xmm, xmm, xmm/m128, imm8
    /// </summary>
    [Symbol("vmpsadbw xmm, xmm, xmm, imm8","vmpsadbw xmm, xmm, xmm/m128, imm8")]
    vmpsadbw_xmm_xmm_xmm_imm8 = 1885,
    /// <summary>
    /// vmpsadbw xmm, xmm, xmm/m128, imm8
    /// </summary>
    [Symbol("vmpsadbw xmm, xmm, m128, imm8","vmpsadbw xmm, xmm, xmm/m128, imm8")]
    vmpsadbw_xmm_xmm_m128_imm8 = 1886,
    /// <summary>
    /// vmpsadbw ymm, ymm, ymm/m256, imm8
    /// </summary>
    [Symbol("vmpsadbw ymm, ymm, ymm, imm8","vmpsadbw ymm, ymm, ymm/m256, imm8")]
    vmpsadbw_ymm_ymm_ymm_imm8 = 1887,
    /// <summary>
    /// vmpsadbw ymm, ymm, ymm/m256, imm8
    /// </summary>
    [Symbol("vmpsadbw ymm, ymm, m256, imm8","vmpsadbw ymm, ymm, ymm/m256, imm8")]
    vmpsadbw_ymm_ymm_m256_imm8 = 1888,
    /// <summary>
    /// vpabsb xmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vpabsb xmm {k1}{z}, xmm","vpabsb xmm {k1}{z}, xmm/m128")]
    vpabsb_xmm_k1z_xmm = 1889,
    /// <summary>
    /// vpabsb xmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vpabsb xmm {k1}{z}, m128","vpabsb xmm {k1}{z}, xmm/m128")]
    vpabsb_xmm_k1z_m128 = 1890,
    /// <summary>
    /// vpabsb xmm, xmm/m128
    /// </summary>
    [Symbol("vpabsb xmm, xmm","vpabsb xmm, xmm/m128")]
    vpabsb_xmm_xmm = 1891,
    /// <summary>
    /// vpabsb xmm, xmm/m128
    /// </summary>
    [Symbol("vpabsb xmm, m128","vpabsb xmm, xmm/m128")]
    vpabsb_xmm_m128 = 1892,
    /// <summary>
    /// vpabsb ymm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vpabsb ymm {k1}{z}, ymm","vpabsb ymm {k1}{z}, ymm/m256")]
    vpabsb_ymm_k1z_ymm = 1893,
    /// <summary>
    /// vpabsb ymm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vpabsb ymm {k1}{z}, m256","vpabsb ymm {k1}{z}, ymm/m256")]
    vpabsb_ymm_k1z_m256 = 1894,
    /// <summary>
    /// vpabsb ymm, ymm/m256
    /// </summary>
    [Symbol("vpabsb ymm, ymm","vpabsb ymm, ymm/m256")]
    vpabsb_ymm_ymm = 1895,
    /// <summary>
    /// vpabsb ymm, ymm/m256
    /// </summary>
    [Symbol("vpabsb ymm, m256","vpabsb ymm, ymm/m256")]
    vpabsb_ymm_m256 = 1896,
    /// <summary>
    /// vpabsb zmm {k1}{z}, zmm/m512
    /// </summary>
    [Symbol("vpabsb zmm {k1}{z}, zmm","vpabsb zmm {k1}{z}, zmm/m512")]
    vpabsb_zmm_k1z_zmm = 1897,
    /// <summary>
    /// vpabsb zmm {k1}{z}, zmm/m512
    /// </summary>
    [Symbol("vpabsb zmm {k1}{z}, m512","vpabsb zmm {k1}{z}, zmm/m512")]
    vpabsb_zmm_k1z_m512 = 1898,
    /// <summary>
    /// vpabsd xmm {k1}{z}, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpabsd xmm {k1}{z}, xmm","vpabsd xmm {k1}{z}, xmm/m128/m32bcst")]
    vpabsd_xmm_k1z_xmm = 1899,
    /// <summary>
    /// vpabsd xmm {k1}{z}, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpabsd xmm {k1}{z}, m128","vpabsd xmm {k1}{z}, xmm/m128/m32bcst")]
    vpabsd_xmm_k1z_m128 = 1900,
    /// <summary>
    /// vpabsd xmm {k1}{z}, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpabsd xmm {k1}{z}, m32bcst","vpabsd xmm {k1}{z}, xmm/m128/m32bcst")]
    vpabsd_xmm_k1z_m32bcst = 1901,
    /// <summary>
    /// vpabsd xmm, xmm/m128
    /// </summary>
    [Symbol("vpabsd xmm, xmm","vpabsd xmm, xmm/m128")]
    vpabsd_xmm_xmm = 1902,
    /// <summary>
    /// vpabsd xmm, xmm/m128
    /// </summary>
    [Symbol("vpabsd xmm, m128","vpabsd xmm, xmm/m128")]
    vpabsd_xmm_m128 = 1903,
    /// <summary>
    /// vpabsd ymm {k1}{z}, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpabsd ymm {k1}{z}, ymm","vpabsd ymm {k1}{z}, ymm/m256/m32bcst")]
    vpabsd_ymm_k1z_ymm = 1904,
    /// <summary>
    /// vpabsd ymm {k1}{z}, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpabsd ymm {k1}{z}, m256","vpabsd ymm {k1}{z}, ymm/m256/m32bcst")]
    vpabsd_ymm_k1z_m256 = 1905,
    /// <summary>
    /// vpabsd ymm {k1}{z}, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpabsd ymm {k1}{z}, m32bcst","vpabsd ymm {k1}{z}, ymm/m256/m32bcst")]
    vpabsd_ymm_k1z_m32bcst = 1906,
    /// <summary>
    /// vpabsd ymm, ymm/m256
    /// </summary>
    [Symbol("vpabsd ymm, ymm","vpabsd ymm, ymm/m256")]
    vpabsd_ymm_ymm = 1907,
    /// <summary>
    /// vpabsd ymm, ymm/m256
    /// </summary>
    [Symbol("vpabsd ymm, m256","vpabsd ymm, ymm/m256")]
    vpabsd_ymm_m256 = 1908,
    /// <summary>
    /// vpabsd zmm {k1}{z}, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpabsd zmm {k1}{z}, zmm","vpabsd zmm {k1}{z}, zmm/m512/m32bcst")]
    vpabsd_zmm_k1z_zmm = 1909,
    /// <summary>
    /// vpabsd zmm {k1}{z}, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpabsd zmm {k1}{z}, m512","vpabsd zmm {k1}{z}, zmm/m512/m32bcst")]
    vpabsd_zmm_k1z_m512 = 1910,
    /// <summary>
    /// vpabsd zmm {k1}{z}, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpabsd zmm {k1}{z}, m32bcst","vpabsd zmm {k1}{z}, zmm/m512/m32bcst")]
    vpabsd_zmm_k1z_m32bcst = 1911,
    /// <summary>
    /// vpabsq xmm {k1}{z}, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpabsq xmm {k1}{z}, xmm","vpabsq xmm {k1}{z}, xmm/m128/m64bcst")]
    vpabsq_xmm_k1z_xmm = 1912,
    /// <summary>
    /// vpabsq xmm {k1}{z}, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpabsq xmm {k1}{z}, m128","vpabsq xmm {k1}{z}, xmm/m128/m64bcst")]
    vpabsq_xmm_k1z_m128 = 1913,
    /// <summary>
    /// vpabsq xmm {k1}{z}, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpabsq xmm {k1}{z}, m64bcst","vpabsq xmm {k1}{z}, xmm/m128/m64bcst")]
    vpabsq_xmm_k1z_m64bcst = 1914,
    /// <summary>
    /// vpabsq ymm {k1}{z}, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpabsq ymm {k1}{z}, ymm","vpabsq ymm {k1}{z}, ymm/m256/m64bcst")]
    vpabsq_ymm_k1z_ymm = 1915,
    /// <summary>
    /// vpabsq ymm {k1}{z}, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpabsq ymm {k1}{z}, m256","vpabsq ymm {k1}{z}, ymm/m256/m64bcst")]
    vpabsq_ymm_k1z_m256 = 1916,
    /// <summary>
    /// vpabsq ymm {k1}{z}, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpabsq ymm {k1}{z}, m64bcst","vpabsq ymm {k1}{z}, ymm/m256/m64bcst")]
    vpabsq_ymm_k1z_m64bcst = 1917,
    /// <summary>
    /// vpabsq zmm {k1}{z}, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpabsq zmm {k1}{z}, zmm","vpabsq zmm {k1}{z}, zmm/m512/m64bcst")]
    vpabsq_zmm_k1z_zmm = 1918,
    /// <summary>
    /// vpabsq zmm {k1}{z}, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpabsq zmm {k1}{z}, m512","vpabsq zmm {k1}{z}, zmm/m512/m64bcst")]
    vpabsq_zmm_k1z_m512 = 1919,
    /// <summary>
    /// vpabsq zmm {k1}{z}, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpabsq zmm {k1}{z}, m64bcst","vpabsq zmm {k1}{z}, zmm/m512/m64bcst")]
    vpabsq_zmm_k1z_m64bcst = 1920,
    /// <summary>
    /// vpabsw xmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vpabsw xmm {k1}{z}, xmm","vpabsw xmm {k1}{z}, xmm/m128")]
    vpabsw_xmm_k1z_xmm = 1921,
    /// <summary>
    /// vpabsw xmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vpabsw xmm {k1}{z}, m128","vpabsw xmm {k1}{z}, xmm/m128")]
    vpabsw_xmm_k1z_m128 = 1922,
    /// <summary>
    /// vpabsw xmm, xmm/m128
    /// </summary>
    [Symbol("vpabsw xmm, xmm","vpabsw xmm, xmm/m128")]
    vpabsw_xmm_xmm = 1923,
    /// <summary>
    /// vpabsw xmm, xmm/m128
    /// </summary>
    [Symbol("vpabsw xmm, m128","vpabsw xmm, xmm/m128")]
    vpabsw_xmm_m128 = 1924,
    /// <summary>
    /// vpabsw ymm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vpabsw ymm {k1}{z}, ymm","vpabsw ymm {k1}{z}, ymm/m256")]
    vpabsw_ymm_k1z_ymm = 1925,
    /// <summary>
    /// vpabsw ymm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vpabsw ymm {k1}{z}, m256","vpabsw ymm {k1}{z}, ymm/m256")]
    vpabsw_ymm_k1z_m256 = 1926,
    /// <summary>
    /// vpabsw ymm, ymm/m256
    /// </summary>
    [Symbol("vpabsw ymm, ymm","vpabsw ymm, ymm/m256")]
    vpabsw_ymm_ymm = 1927,
    /// <summary>
    /// vpabsw ymm, ymm/m256
    /// </summary>
    [Symbol("vpabsw ymm, m256","vpabsw ymm, ymm/m256")]
    vpabsw_ymm_m256 = 1928,
    /// <summary>
    /// vpabsw zmm {k1}{z}, zmm/m512
    /// </summary>
    [Symbol("vpabsw zmm {k1}{z}, zmm","vpabsw zmm {k1}{z}, zmm/m512")]
    vpabsw_zmm_k1z_zmm = 1929,
    /// <summary>
    /// vpabsw zmm {k1}{z}, zmm/m512
    /// </summary>
    [Symbol("vpabsw zmm {k1}{z}, m512","vpabsw zmm {k1}{z}, zmm/m512")]
    vpabsw_zmm_k1z_m512 = 1930,
    /// <summary>
    /// vpackssdw xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpackssdw xmm {k1}{z}, xmm, xmm","vpackssdw xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpackssdw_xmm_k1z_xmm_xmm = 1931,
    /// <summary>
    /// vpackssdw xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpackssdw xmm {k1}{z}, xmm, m128","vpackssdw xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpackssdw_xmm_k1z_xmm_m128 = 1932,
    /// <summary>
    /// vpackssdw xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpackssdw xmm {k1}{z}, xmm, m32bcst","vpackssdw xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpackssdw_xmm_k1z_xmm_m32bcst = 1933,
    /// <summary>
    /// vpackssdw xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpackssdw xmm, xmm, xmm","vpackssdw xmm, xmm, xmm/m128")]
    vpackssdw_xmm_xmm_xmm = 1934,
    /// <summary>
    /// vpackssdw xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpackssdw xmm, xmm, m128","vpackssdw xmm, xmm, xmm/m128")]
    vpackssdw_xmm_xmm_m128 = 1935,
    /// <summary>
    /// vpackssdw ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpackssdw ymm, ymm, ymm","vpackssdw ymm, ymm, ymm/m256")]
    vpackssdw_ymm_ymm_ymm = 1936,
    /// <summary>
    /// vpackssdw ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpackssdw ymm, ymm, m256","vpackssdw ymm, ymm, ymm/m256")]
    vpackssdw_ymm_ymm_m256 = 1937,
    /// <summary>
    /// vpacksswb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpacksswb xmm {k1}{z}, xmm, xmm","vpacksswb xmm {k1}{z}, xmm, xmm/m128")]
    vpacksswb_xmm_k1z_xmm_xmm = 1938,
    /// <summary>
    /// vpacksswb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpacksswb xmm {k1}{z}, xmm, m128","vpacksswb xmm {k1}{z}, xmm, xmm/m128")]
    vpacksswb_xmm_k1z_xmm_m128 = 1939,
    /// <summary>
    /// vpacksswb xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpacksswb xmm, xmm, xmm","vpacksswb xmm, xmm, xmm/m128")]
    vpacksswb_xmm_xmm_xmm = 1940,
    /// <summary>
    /// vpacksswb xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpacksswb xmm, xmm, m128","vpacksswb xmm, xmm, xmm/m128")]
    vpacksswb_xmm_xmm_m128 = 1941,
    /// <summary>
    /// vpacksswb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpacksswb ymm {k1}{z}, ymm, ymm","vpacksswb ymm {k1}{z}, ymm, ymm/m256")]
    vpacksswb_ymm_k1z_ymm_ymm = 1942,
    /// <summary>
    /// vpacksswb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpacksswb ymm {k1}{z}, ymm, m256","vpacksswb ymm {k1}{z}, ymm, ymm/m256")]
    vpacksswb_ymm_k1z_ymm_m256 = 1943,
    /// <summary>
    /// vpacksswb ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpacksswb ymm, ymm, ymm","vpacksswb ymm, ymm, ymm/m256")]
    vpacksswb_ymm_ymm_ymm = 1944,
    /// <summary>
    /// vpacksswb ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpacksswb ymm, ymm, m256","vpacksswb ymm, ymm, ymm/m256")]
    vpacksswb_ymm_ymm_m256 = 1945,
    /// <summary>
    /// vpacksswb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpacksswb zmm {k1}{z}, zmm, zmm","vpacksswb zmm {k1}{z}, zmm, zmm/m512")]
    vpacksswb_zmm_k1z_zmm_zmm = 1946,
    /// <summary>
    /// vpacksswb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpacksswb zmm {k1}{z}, zmm, m512","vpacksswb zmm {k1}{z}, zmm, zmm/m512")]
    vpacksswb_zmm_k1z_zmm_m512 = 1947,
    /// <summary>
    /// vpackusdw xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpackusdw xmm {k1}{z}, xmm, xmm","vpackusdw xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpackusdw_xmm_k1z_xmm_xmm = 1948,
    /// <summary>
    /// vpackusdw xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpackusdw xmm {k1}{z}, xmm, m128","vpackusdw xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpackusdw_xmm_k1z_xmm_m128 = 1949,
    /// <summary>
    /// vpackusdw xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpackusdw xmm {k1}{z}, xmm, m32bcst","vpackusdw xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpackusdw_xmm_k1z_xmm_m32bcst = 1950,
    /// <summary>
    /// vpackusdw xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpackusdw xmm, xmm, xmm","vpackusdw xmm, xmm, xmm/m128")]
    vpackusdw_xmm_xmm_xmm = 1951,
    /// <summary>
    /// vpackusdw xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpackusdw xmm, xmm, m128","vpackusdw xmm, xmm, xmm/m128")]
    vpackusdw_xmm_xmm_m128 = 1952,
    /// <summary>
    /// vpackusdw ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpackusdw ymm {k1}{z}, ymm, ymm","vpackusdw ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpackusdw_ymm_k1z_ymm_ymm = 1953,
    /// <summary>
    /// vpackusdw ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpackusdw ymm {k1}{z}, ymm, m256","vpackusdw ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpackusdw_ymm_k1z_ymm_m256 = 1954,
    /// <summary>
    /// vpackusdw ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpackusdw ymm {k1}{z}, ymm, m32bcst","vpackusdw ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpackusdw_ymm_k1z_ymm_m32bcst = 1955,
    /// <summary>
    /// vpackusdw ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpackusdw ymm, ymm, ymm","vpackusdw ymm, ymm, ymm/m256")]
    vpackusdw_ymm_ymm_ymm = 1956,
    /// <summary>
    /// vpackusdw ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpackusdw ymm, ymm, m256","vpackusdw ymm, ymm, ymm/m256")]
    vpackusdw_ymm_ymm_m256 = 1957,
    /// <summary>
    /// vpackusdw zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpackusdw zmm {k1}{z}, zmm, zmm","vpackusdw zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpackusdw_zmm_k1z_zmm_zmm = 1958,
    /// <summary>
    /// vpackusdw zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpackusdw zmm {k1}{z}, zmm, m512","vpackusdw zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpackusdw_zmm_k1z_zmm_m512 = 1959,
    /// <summary>
    /// vpackusdw zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpackusdw zmm {k1}{z}, zmm, m32bcst","vpackusdw zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpackusdw_zmm_k1z_zmm_m32bcst = 1960,
    /// <summary>
    /// vpackuswb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpackuswb xmm {k1}{z}, xmm, xmm","vpackuswb xmm {k1}{z}, xmm, xmm/m128")]
    vpackuswb_xmm_k1z_xmm_xmm = 1961,
    /// <summary>
    /// vpackuswb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpackuswb xmm {k1}{z}, xmm, m128","vpackuswb xmm {k1}{z}, xmm, xmm/m128")]
    vpackuswb_xmm_k1z_xmm_m128 = 1962,
    /// <summary>
    /// vpackuswb xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpackuswb xmm, xmm, xmm","vpackuswb xmm, xmm, xmm/m128")]
    vpackuswb_xmm_xmm_xmm = 1963,
    /// <summary>
    /// vpackuswb xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpackuswb xmm, xmm, m128","vpackuswb xmm, xmm, xmm/m128")]
    vpackuswb_xmm_xmm_m128 = 1964,
    /// <summary>
    /// vpackuswb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpackuswb ymm {k1}{z}, ymm, ymm","vpackuswb ymm {k1}{z}, ymm, ymm/m256")]
    vpackuswb_ymm_k1z_ymm_ymm = 1965,
    /// <summary>
    /// vpackuswb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpackuswb ymm {k1}{z}, ymm, m256","vpackuswb ymm {k1}{z}, ymm, ymm/m256")]
    vpackuswb_ymm_k1z_ymm_m256 = 1966,
    /// <summary>
    /// vpackuswb ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpackuswb ymm, ymm, ymm","vpackuswb ymm, ymm, ymm/m256")]
    vpackuswb_ymm_ymm_ymm = 1967,
    /// <summary>
    /// vpackuswb ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpackuswb ymm, ymm, m256","vpackuswb ymm, ymm, ymm/m256")]
    vpackuswb_ymm_ymm_m256 = 1968,
    /// <summary>
    /// vpackuswb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpackuswb zmm {k1}{z}, zmm, zmm","vpackuswb zmm {k1}{z}, zmm, zmm/m512")]
    vpackuswb_zmm_k1z_zmm_zmm = 1969,
    /// <summary>
    /// vpackuswb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpackuswb zmm {k1}{z}, zmm, m512","vpackuswb zmm {k1}{z}, zmm, zmm/m512")]
    vpackuswb_zmm_k1z_zmm_m512 = 1970,
    /// <summary>
    /// vpaddb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpaddb xmm {k1}{z}, xmm, xmm","vpaddb xmm {k1}{z}, xmm, xmm/m128")]
    vpaddb_xmm_k1z_xmm_xmm = 1971,
    /// <summary>
    /// vpaddb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpaddb xmm {k1}{z}, xmm, m128","vpaddb xmm {k1}{z}, xmm, xmm/m128")]
    vpaddb_xmm_k1z_xmm_m128 = 1972,
    /// <summary>
    /// vpaddb xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpaddb xmm, xmm, xmm","vpaddb xmm, xmm, xmm/m128")]
    vpaddb_xmm_xmm_xmm = 1973,
    /// <summary>
    /// vpaddb xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpaddb xmm, xmm, m128","vpaddb xmm, xmm, xmm/m128")]
    vpaddb_xmm_xmm_m128 = 1974,
    /// <summary>
    /// vpaddb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpaddb ymm {k1}{z}, ymm, ymm","vpaddb ymm {k1}{z}, ymm, ymm/m256")]
    vpaddb_ymm_k1z_ymm_ymm = 1975,
    /// <summary>
    /// vpaddb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpaddb ymm {k1}{z}, ymm, m256","vpaddb ymm {k1}{z}, ymm, ymm/m256")]
    vpaddb_ymm_k1z_ymm_m256 = 1976,
    /// <summary>
    /// vpaddb ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpaddb ymm, ymm, ymm","vpaddb ymm, ymm, ymm/m256")]
    vpaddb_ymm_ymm_ymm = 1977,
    /// <summary>
    /// vpaddb ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpaddb ymm, ymm, m256","vpaddb ymm, ymm, ymm/m256")]
    vpaddb_ymm_ymm_m256 = 1978,
    /// <summary>
    /// vpaddb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpaddb zmm {k1}{z}, zmm, zmm","vpaddb zmm {k1}{z}, zmm, zmm/m512")]
    vpaddb_zmm_k1z_zmm_zmm = 1979,
    /// <summary>
    /// vpaddb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpaddb zmm {k1}{z}, zmm, m512","vpaddb zmm {k1}{z}, zmm, zmm/m512")]
    vpaddb_zmm_k1z_zmm_m512 = 1980,
    /// <summary>
    /// vpaddd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpaddd xmm {k1}{z}, xmm, xmm","vpaddd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpaddd_xmm_k1z_xmm_xmm = 1981,
    /// <summary>
    /// vpaddd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpaddd xmm {k1}{z}, xmm, m128","vpaddd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpaddd_xmm_k1z_xmm_m128 = 1982,
    /// <summary>
    /// vpaddd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpaddd xmm {k1}{z}, xmm, m32bcst","vpaddd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpaddd_xmm_k1z_xmm_m32bcst = 1983,
    /// <summary>
    /// vpaddd xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpaddd xmm, xmm, xmm","vpaddd xmm, xmm, xmm/m128")]
    vpaddd_xmm_xmm_xmm = 1984,
    /// <summary>
    /// vpaddd xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpaddd xmm, xmm, m128","vpaddd xmm, xmm, xmm/m128")]
    vpaddd_xmm_xmm_m128 = 1985,
    /// <summary>
    /// vpaddd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpaddd ymm {k1}{z}, ymm, ymm","vpaddd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpaddd_ymm_k1z_ymm_ymm = 1986,
    /// <summary>
    /// vpaddd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpaddd ymm {k1}{z}, ymm, m256","vpaddd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpaddd_ymm_k1z_ymm_m256 = 1987,
    /// <summary>
    /// vpaddd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpaddd ymm {k1}{z}, ymm, m32bcst","vpaddd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpaddd_ymm_k1z_ymm_m32bcst = 1988,
    /// <summary>
    /// vpaddd ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpaddd ymm, ymm, ymm","vpaddd ymm, ymm, ymm/m256")]
    vpaddd_ymm_ymm_ymm = 1989,
    /// <summary>
    /// vpaddd ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpaddd ymm, ymm, m256","vpaddd ymm, ymm, ymm/m256")]
    vpaddd_ymm_ymm_m256 = 1990,
    /// <summary>
    /// vpaddd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpaddd zmm {k1}{z}, zmm, zmm","vpaddd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpaddd_zmm_k1z_zmm_zmm = 1991,
    /// <summary>
    /// vpaddd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpaddd zmm {k1}{z}, zmm, m512","vpaddd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpaddd_zmm_k1z_zmm_m512 = 1992,
    /// <summary>
    /// vpaddd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpaddd zmm {k1}{z}, zmm, m32bcst","vpaddd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpaddd_zmm_k1z_zmm_m32bcst = 1993,
    /// <summary>
    /// vpaddq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpaddq xmm {k1}{z}, xmm, xmm","vpaddq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpaddq_xmm_k1z_xmm_xmm = 1994,
    /// <summary>
    /// vpaddq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpaddq xmm {k1}{z}, xmm, m128","vpaddq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpaddq_xmm_k1z_xmm_m128 = 1995,
    /// <summary>
    /// vpaddq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpaddq xmm {k1}{z}, xmm, m64bcst","vpaddq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpaddq_xmm_k1z_xmm_m64bcst = 1996,
    /// <summary>
    /// vpaddq xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpaddq xmm, xmm, xmm","vpaddq xmm, xmm, xmm/m128")]
    vpaddq_xmm_xmm_xmm = 1997,
    /// <summary>
    /// vpaddq xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpaddq xmm, xmm, m128","vpaddq xmm, xmm, xmm/m128")]
    vpaddq_xmm_xmm_m128 = 1998,
    /// <summary>
    /// vpaddq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpaddq ymm {k1}{z}, ymm, ymm","vpaddq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpaddq_ymm_k1z_ymm_ymm = 1999,
    /// <summary>
    /// vpaddq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpaddq ymm {k1}{z}, ymm, m256","vpaddq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpaddq_ymm_k1z_ymm_m256 = 2000,
    /// <summary>
    /// vpaddq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpaddq ymm {k1}{z}, ymm, m64bcst","vpaddq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpaddq_ymm_k1z_ymm_m64bcst = 2001,
    /// <summary>
    /// vpaddq ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpaddq ymm, ymm, ymm","vpaddq ymm, ymm, ymm/m256")]
    vpaddq_ymm_ymm_ymm = 2002,
    /// <summary>
    /// vpaddq ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpaddq ymm, ymm, m256","vpaddq ymm, ymm, ymm/m256")]
    vpaddq_ymm_ymm_m256 = 2003,
    /// <summary>
    /// vpaddq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpaddq zmm {k1}{z}, zmm, zmm","vpaddq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpaddq_zmm_k1z_zmm_zmm = 2004,
    /// <summary>
    /// vpaddq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpaddq zmm {k1}{z}, zmm, m512","vpaddq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpaddq_zmm_k1z_zmm_m512 = 2005,
    /// <summary>
    /// vpaddq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpaddq zmm {k1}{z}, zmm, m64bcst","vpaddq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpaddq_zmm_k1z_zmm_m64bcst = 2006,
    /// <summary>
    /// vpaddsb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpaddsb xmm {k1}{z}, xmm, xmm","vpaddsb xmm {k1}{z}, xmm, xmm/m128")]
    vpaddsb_xmm_k1z_xmm_xmm = 2007,
    /// <summary>
    /// vpaddsb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpaddsb xmm {k1}{z}, xmm, m128","vpaddsb xmm {k1}{z}, xmm, xmm/m128")]
    vpaddsb_xmm_k1z_xmm_m128 = 2008,
    /// <summary>
    /// vpaddsb xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpaddsb xmm, xmm, xmm","vpaddsb xmm, xmm, xmm/m128")]
    vpaddsb_xmm_xmm_xmm = 2009,
    /// <summary>
    /// vpaddsb xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpaddsb xmm, xmm, m128","vpaddsb xmm, xmm, xmm/m128")]
    vpaddsb_xmm_xmm_m128 = 2010,
    /// <summary>
    /// vpaddsb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpaddsb ymm {k1}{z}, ymm, ymm","vpaddsb ymm {k1}{z}, ymm, ymm/m256")]
    vpaddsb_ymm_k1z_ymm_ymm = 2011,
    /// <summary>
    /// vpaddsb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpaddsb ymm {k1}{z}, ymm, m256","vpaddsb ymm {k1}{z}, ymm, ymm/m256")]
    vpaddsb_ymm_k1z_ymm_m256 = 2012,
    /// <summary>
    /// vpaddsb ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpaddsb ymm, ymm, ymm","vpaddsb ymm, ymm, ymm/m256")]
    vpaddsb_ymm_ymm_ymm = 2013,
    /// <summary>
    /// vpaddsb ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpaddsb ymm, ymm, m256","vpaddsb ymm, ymm, ymm/m256")]
    vpaddsb_ymm_ymm_m256 = 2014,
    /// <summary>
    /// vpaddsb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpaddsb zmm {k1}{z}, zmm, zmm","vpaddsb zmm {k1}{z}, zmm, zmm/m512")]
    vpaddsb_zmm_k1z_zmm_zmm = 2015,
    /// <summary>
    /// vpaddsb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpaddsb zmm {k1}{z}, zmm, m512","vpaddsb zmm {k1}{z}, zmm, zmm/m512")]
    vpaddsb_zmm_k1z_zmm_m512 = 2016,
    /// <summary>
    /// vpaddsw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpaddsw xmm {k1}{z}, xmm, xmm","vpaddsw xmm {k1}{z}, xmm, xmm/m128")]
    vpaddsw_xmm_k1z_xmm_xmm = 2017,
    /// <summary>
    /// vpaddsw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpaddsw xmm {k1}{z}, xmm, m128","vpaddsw xmm {k1}{z}, xmm, xmm/m128")]
    vpaddsw_xmm_k1z_xmm_m128 = 2018,
    /// <summary>
    /// vpaddsw xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpaddsw xmm, xmm, xmm","vpaddsw xmm, xmm, xmm/m128")]
    vpaddsw_xmm_xmm_xmm = 2019,
    /// <summary>
    /// vpaddsw xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpaddsw xmm, xmm, m128","vpaddsw xmm, xmm, xmm/m128")]
    vpaddsw_xmm_xmm_m128 = 2020,
    /// <summary>
    /// vpaddsw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpaddsw ymm {k1}{z}, ymm, ymm","vpaddsw ymm {k1}{z}, ymm, ymm/m256")]
    vpaddsw_ymm_k1z_ymm_ymm = 2021,
    /// <summary>
    /// vpaddsw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpaddsw ymm {k1}{z}, ymm, m256","vpaddsw ymm {k1}{z}, ymm, ymm/m256")]
    vpaddsw_ymm_k1z_ymm_m256 = 2022,
    /// <summary>
    /// vpaddsw ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpaddsw ymm, ymm, ymm","vpaddsw ymm, ymm, ymm/m256")]
    vpaddsw_ymm_ymm_ymm = 2023,
    /// <summary>
    /// vpaddsw ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpaddsw ymm, ymm, m256","vpaddsw ymm, ymm, ymm/m256")]
    vpaddsw_ymm_ymm_m256 = 2024,
    /// <summary>
    /// vpaddsw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpaddsw zmm {k1}{z}, zmm, zmm","vpaddsw zmm {k1}{z}, zmm, zmm/m512")]
    vpaddsw_zmm_k1z_zmm_zmm = 2025,
    /// <summary>
    /// vpaddsw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpaddsw zmm {k1}{z}, zmm, m512","vpaddsw zmm {k1}{z}, zmm, zmm/m512")]
    vpaddsw_zmm_k1z_zmm_m512 = 2026,
    /// <summary>
    /// vpaddusb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpaddusb xmm {k1}{z}, xmm, xmm","vpaddusb xmm {k1}{z}, xmm, xmm/m128")]
    vpaddusb_xmm_k1z_xmm_xmm = 2027,
    /// <summary>
    /// vpaddusb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpaddusb xmm {k1}{z}, xmm, m128","vpaddusb xmm {k1}{z}, xmm, xmm/m128")]
    vpaddusb_xmm_k1z_xmm_m128 = 2028,
    /// <summary>
    /// vpaddusb xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpaddusb xmm, xmm, xmm","vpaddusb xmm, xmm, xmm/m128")]
    vpaddusb_xmm_xmm_xmm = 2029,
    /// <summary>
    /// vpaddusb xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpaddusb xmm, xmm, m128","vpaddusb xmm, xmm, xmm/m128")]
    vpaddusb_xmm_xmm_m128 = 2030,
    /// <summary>
    /// vpaddusb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpaddusb ymm {k1}{z}, ymm, ymm","vpaddusb ymm {k1}{z}, ymm, ymm/m256")]
    vpaddusb_ymm_k1z_ymm_ymm = 2031,
    /// <summary>
    /// vpaddusb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpaddusb ymm {k1}{z}, ymm, m256","vpaddusb ymm {k1}{z}, ymm, ymm/m256")]
    vpaddusb_ymm_k1z_ymm_m256 = 2032,
    /// <summary>
    /// vpaddusb ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpaddusb ymm, ymm, ymm","vpaddusb ymm, ymm, ymm/m256")]
    vpaddusb_ymm_ymm_ymm = 2033,
    /// <summary>
    /// vpaddusb ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpaddusb ymm, ymm, m256","vpaddusb ymm, ymm, ymm/m256")]
    vpaddusb_ymm_ymm_m256 = 2034,
    /// <summary>
    /// vpaddusb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpaddusb zmm {k1}{z}, zmm, zmm","vpaddusb zmm {k1}{z}, zmm, zmm/m512")]
    vpaddusb_zmm_k1z_zmm_zmm = 2035,
    /// <summary>
    /// vpaddusb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpaddusb zmm {k1}{z}, zmm, m512","vpaddusb zmm {k1}{z}, zmm, zmm/m512")]
    vpaddusb_zmm_k1z_zmm_m512 = 2036,
    /// <summary>
    /// vpaddusw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpaddusw xmm {k1}{z}, xmm, xmm","vpaddusw xmm {k1}{z}, xmm, xmm/m128")]
    vpaddusw_xmm_k1z_xmm_xmm = 2037,
    /// <summary>
    /// vpaddusw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpaddusw xmm {k1}{z}, xmm, m128","vpaddusw xmm {k1}{z}, xmm, xmm/m128")]
    vpaddusw_xmm_k1z_xmm_m128 = 2038,
    /// <summary>
    /// vpaddusw xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpaddusw xmm, xmm, xmm","vpaddusw xmm, xmm, xmm/m128")]
    vpaddusw_xmm_xmm_xmm = 2039,
    /// <summary>
    /// vpaddusw xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpaddusw xmm, xmm, m128","vpaddusw xmm, xmm, xmm/m128")]
    vpaddusw_xmm_xmm_m128 = 2040,
    /// <summary>
    /// vpaddusw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpaddusw ymm {k1}{z}, ymm, ymm","vpaddusw ymm {k1}{z}, ymm, ymm/m256")]
    vpaddusw_ymm_k1z_ymm_ymm = 2041,
    /// <summary>
    /// vpaddusw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpaddusw ymm {k1}{z}, ymm, m256","vpaddusw ymm {k1}{z}, ymm, ymm/m256")]
    vpaddusw_ymm_k1z_ymm_m256 = 2042,
    /// <summary>
    /// vpaddusw ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpaddusw ymm, ymm, ymm","vpaddusw ymm, ymm, ymm/m256")]
    vpaddusw_ymm_ymm_ymm = 2043,
    /// <summary>
    /// vpaddusw ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpaddusw ymm, ymm, m256","vpaddusw ymm, ymm, ymm/m256")]
    vpaddusw_ymm_ymm_m256 = 2044,
    /// <summary>
    /// vpaddw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpaddw xmm {k1}{z}, xmm, xmm","vpaddw xmm {k1}{z}, xmm, xmm/m128")]
    vpaddw_xmm_k1z_xmm_xmm = 2045,
    /// <summary>
    /// vpaddw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpaddw xmm {k1}{z}, xmm, m128","vpaddw xmm {k1}{z}, xmm, xmm/m128")]
    vpaddw_xmm_k1z_xmm_m128 = 2046,
    /// <summary>
    /// vpaddw xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpaddw xmm, xmm, xmm","vpaddw xmm, xmm, xmm/m128")]
    vpaddw_xmm_xmm_xmm = 2047,
    /// <summary>
    /// vpaddw xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpaddw xmm, xmm, m128","vpaddw xmm, xmm, xmm/m128")]
    vpaddw_xmm_xmm_m128 = 2048,
    /// <summary>
    /// vpaddw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpaddw ymm {k1}{z}, ymm, ymm","vpaddw ymm {k1}{z}, ymm, ymm/m256")]
    vpaddw_ymm_k1z_ymm_ymm = 2049,
    /// <summary>
    /// vpaddw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpaddw ymm {k1}{z}, ymm, m256","vpaddw ymm {k1}{z}, ymm, ymm/m256")]
    vpaddw_ymm_k1z_ymm_m256 = 2050,
    /// <summary>
    /// vpaddw ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpaddw ymm, ymm, ymm","vpaddw ymm, ymm, ymm/m256")]
    vpaddw_ymm_ymm_ymm = 2051,
    /// <summary>
    /// vpaddw ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpaddw ymm, ymm, m256","vpaddw ymm, ymm, ymm/m256")]
    vpaddw_ymm_ymm_m256 = 2052,
    /// <summary>
    /// vpaddw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpaddw zmm {k1}{z}, zmm, zmm","vpaddw zmm {k1}{z}, zmm, zmm/m512")]
    vpaddw_zmm_k1z_zmm_zmm = 2053,
    /// <summary>
    /// vpaddw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpaddw zmm {k1}{z}, zmm, m512","vpaddw zmm {k1}{z}, zmm, zmm/m512")]
    vpaddw_zmm_k1z_zmm_m512 = 2054,
    /// <summary>
    /// vpand xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpand xmm, xmm, xmm","vpand xmm, xmm, xmm/m128")]
    vpand_xmm_xmm_xmm = 2055,
    /// <summary>
    /// vpand xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpand xmm, xmm, m128","vpand xmm, xmm, xmm/m128")]
    vpand_xmm_xmm_m128 = 2056,
    /// <summary>
    /// vpand ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpand ymm, ymm, ymm","vpand ymm, ymm, ymm/m256")]
    vpand_ymm_ymm_ymm = 2057,
    /// <summary>
    /// vpand ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpand ymm, ymm, m256","vpand ymm, ymm, ymm/m256")]
    vpand_ymm_ymm_m256 = 2058,
    /// <summary>
    /// vpandd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpandd xmm {k1}{z}, xmm, xmm","vpandd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpandd_xmm_k1z_xmm_xmm = 2059,
    /// <summary>
    /// vpandd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpandd xmm {k1}{z}, xmm, m128","vpandd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpandd_xmm_k1z_xmm_m128 = 2060,
    /// <summary>
    /// vpandd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpandd xmm {k1}{z}, xmm, m32bcst","vpandd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpandd_xmm_k1z_xmm_m32bcst = 2061,
    /// <summary>
    /// vpandd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpandd ymm {k1}{z}, ymm, ymm","vpandd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpandd_ymm_k1z_ymm_ymm = 2062,
    /// <summary>
    /// vpandd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpandd ymm {k1}{z}, ymm, m256","vpandd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpandd_ymm_k1z_ymm_m256 = 2063,
    /// <summary>
    /// vpandd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpandd ymm {k1}{z}, ymm, m32bcst","vpandd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpandd_ymm_k1z_ymm_m32bcst = 2064,
    /// <summary>
    /// vpandd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpandd zmm {k1}{z}, zmm, zmm","vpandd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpandd_zmm_k1z_zmm_zmm = 2065,
    /// <summary>
    /// vpandd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpandd zmm {k1}{z}, zmm, m512","vpandd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpandd_zmm_k1z_zmm_m512 = 2066,
    /// <summary>
    /// vpandd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpandd zmm {k1}{z}, zmm, m32bcst","vpandd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpandd_zmm_k1z_zmm_m32bcst = 2067,
    /// <summary>
    /// vpandn xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpandn xmm, xmm, xmm","vpandn xmm, xmm, xmm/m128")]
    vpandn_xmm_xmm_xmm = 2068,
    /// <summary>
    /// vpandn xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpandn xmm, xmm, m128","vpandn xmm, xmm, xmm/m128")]
    vpandn_xmm_xmm_m128 = 2069,
    /// <summary>
    /// vpandn ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpandn ymm, ymm, ymm","vpandn ymm, ymm, ymm/m256")]
    vpandn_ymm_ymm_ymm = 2070,
    /// <summary>
    /// vpandn ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpandn ymm, ymm, m256","vpandn ymm, ymm, ymm/m256")]
    vpandn_ymm_ymm_m256 = 2071,
    /// <summary>
    /// vpandnd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpandnd xmm {k1}{z}, xmm, xmm","vpandnd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpandnd_xmm_k1z_xmm_xmm = 2072,
    /// <summary>
    /// vpandnd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpandnd xmm {k1}{z}, xmm, m128","vpandnd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpandnd_xmm_k1z_xmm_m128 = 2073,
    /// <summary>
    /// vpandnd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpandnd xmm {k1}{z}, xmm, m32bcst","vpandnd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpandnd_xmm_k1z_xmm_m32bcst = 2074,
    /// <summary>
    /// vpandnd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpandnd ymm {k1}{z}, ymm, ymm","vpandnd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpandnd_ymm_k1z_ymm_ymm = 2075,
    /// <summary>
    /// vpandnd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpandnd ymm {k1}{z}, ymm, m256","vpandnd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpandnd_ymm_k1z_ymm_m256 = 2076,
    /// <summary>
    /// vpandnd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpandnd ymm {k1}{z}, ymm, m32bcst","vpandnd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpandnd_ymm_k1z_ymm_m32bcst = 2077,
    /// <summary>
    /// vpandnd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpandnd zmm {k1}{z}, zmm, zmm","vpandnd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpandnd_zmm_k1z_zmm_zmm = 2078,
    /// <summary>
    /// vpandnd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpandnd zmm {k1}{z}, zmm, m512","vpandnd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpandnd_zmm_k1z_zmm_m512 = 2079,
    /// <summary>
    /// vpandnd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpandnd zmm {k1}{z}, zmm, m32bcst","vpandnd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpandnd_zmm_k1z_zmm_m32bcst = 2080,
    /// <summary>
    /// vpandnq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpandnq xmm {k1}{z}, xmm, xmm","vpandnq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpandnq_xmm_k1z_xmm_xmm = 2081,
    /// <summary>
    /// vpandnq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpandnq xmm {k1}{z}, xmm, m128","vpandnq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpandnq_xmm_k1z_xmm_m128 = 2082,
    /// <summary>
    /// vpandnq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpandnq xmm {k1}{z}, xmm, m64bcst","vpandnq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpandnq_xmm_k1z_xmm_m64bcst = 2083,
    /// <summary>
    /// vpandnq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpandnq ymm {k1}{z}, ymm, ymm","vpandnq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpandnq_ymm_k1z_ymm_ymm = 2084,
    /// <summary>
    /// vpandnq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpandnq ymm {k1}{z}, ymm, m256","vpandnq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpandnq_ymm_k1z_ymm_m256 = 2085,
    /// <summary>
    /// vpandnq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpandnq ymm {k1}{z}, ymm, m64bcst","vpandnq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpandnq_ymm_k1z_ymm_m64bcst = 2086,
    /// <summary>
    /// vpandnq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpandnq zmm {k1}{z}, zmm, zmm","vpandnq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpandnq_zmm_k1z_zmm_zmm = 2087,
    /// <summary>
    /// vpandnq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpandnq zmm {k1}{z}, zmm, m512","vpandnq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpandnq_zmm_k1z_zmm_m512 = 2088,
    /// <summary>
    /// vpandnq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpandnq zmm {k1}{z}, zmm, m64bcst","vpandnq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpandnq_zmm_k1z_zmm_m64bcst = 2089,
    /// <summary>
    /// vpandq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpandq xmm {k1}{z}, xmm, xmm","vpandq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpandq_xmm_k1z_xmm_xmm = 2090,
    /// <summary>
    /// vpandq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpandq xmm {k1}{z}, xmm, m128","vpandq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpandq_xmm_k1z_xmm_m128 = 2091,
    /// <summary>
    /// vpandq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpandq xmm {k1}{z}, xmm, m64bcst","vpandq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpandq_xmm_k1z_xmm_m64bcst = 2092,
    /// <summary>
    /// vpandq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpandq ymm {k1}{z}, ymm, ymm","vpandq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpandq_ymm_k1z_ymm_ymm = 2093,
    /// <summary>
    /// vpandq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpandq ymm {k1}{z}, ymm, m256","vpandq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpandq_ymm_k1z_ymm_m256 = 2094,
    /// <summary>
    /// vpandq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpandq ymm {k1}{z}, ymm, m64bcst","vpandq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpandq_ymm_k1z_ymm_m64bcst = 2095,
    /// <summary>
    /// vpandq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpandq zmm {k1}{z}, zmm, zmm","vpandq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpandq_zmm_k1z_zmm_zmm = 2096,
    /// <summary>
    /// vpandq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpandq zmm {k1}{z}, zmm, m512","vpandq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpandq_zmm_k1z_zmm_m512 = 2097,
    /// <summary>
    /// vpandq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpandq zmm {k1}{z}, zmm, m64bcst","vpandq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpandq_zmm_k1z_zmm_m64bcst = 2098,
    /// <summary>
    /// vpavgb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpavgb xmm {k1}{z}, xmm, xmm","vpavgb xmm {k1}{z}, xmm, xmm/m128")]
    vpavgb_xmm_k1z_xmm_xmm = 2099,
    /// <summary>
    /// vpavgb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpavgb xmm {k1}{z}, xmm, m128","vpavgb xmm {k1}{z}, xmm, xmm/m128")]
    vpavgb_xmm_k1z_xmm_m128 = 2100,
    /// <summary>
    /// vpavgb xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpavgb xmm, xmm, xmm","vpavgb xmm, xmm, xmm/m128")]
    vpavgb_xmm_xmm_xmm = 2101,
    /// <summary>
    /// vpavgb xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpavgb xmm, xmm, m128","vpavgb xmm, xmm, xmm/m128")]
    vpavgb_xmm_xmm_m128 = 2102,
    /// <summary>
    /// vpavgb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpavgb ymm {k1}{z}, ymm, ymm","vpavgb ymm {k1}{z}, ymm, ymm/m256")]
    vpavgb_ymm_k1z_ymm_ymm = 2103,
    /// <summary>
    /// vpavgb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpavgb ymm {k1}{z}, ymm, m256","vpavgb ymm {k1}{z}, ymm, ymm/m256")]
    vpavgb_ymm_k1z_ymm_m256 = 2104,
    /// <summary>
    /// vpavgb ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpavgb ymm, ymm, ymm","vpavgb ymm, ymm, ymm/m256")]
    vpavgb_ymm_ymm_ymm = 2105,
    /// <summary>
    /// vpavgb ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpavgb ymm, ymm, m256","vpavgb ymm, ymm, ymm/m256")]
    vpavgb_ymm_ymm_m256 = 2106,
    /// <summary>
    /// vpavgb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpavgb zmm {k1}{z}, zmm, zmm","vpavgb zmm {k1}{z}, zmm, zmm/m512")]
    vpavgb_zmm_k1z_zmm_zmm = 2107,
    /// <summary>
    /// vpavgb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpavgb zmm {k1}{z}, zmm, m512","vpavgb zmm {k1}{z}, zmm, zmm/m512")]
    vpavgb_zmm_k1z_zmm_m512 = 2108,
    /// <summary>
    /// vpavgw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpavgw xmm {k1}{z}, xmm, xmm","vpavgw xmm {k1}{z}, xmm, xmm/m128")]
    vpavgw_xmm_k1z_xmm_xmm = 2109,
    /// <summary>
    /// vpavgw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpavgw xmm {k1}{z}, xmm, m128","vpavgw xmm {k1}{z}, xmm, xmm/m128")]
    vpavgw_xmm_k1z_xmm_m128 = 2110,
    /// <summary>
    /// vpavgw xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpavgw xmm, xmm, xmm","vpavgw xmm, xmm, xmm/m128")]
    vpavgw_xmm_xmm_xmm = 2111,
    /// <summary>
    /// vpavgw xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpavgw xmm, xmm, m128","vpavgw xmm, xmm, xmm/m128")]
    vpavgw_xmm_xmm_m128 = 2112,
    /// <summary>
    /// vpavgw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpavgw ymm {k1}{z}, ymm, ymm","vpavgw ymm {k1}{z}, ymm, ymm/m256")]
    vpavgw_ymm_k1z_ymm_ymm = 2113,
    /// <summary>
    /// vpavgw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpavgw ymm {k1}{z}, ymm, m256","vpavgw ymm {k1}{z}, ymm, ymm/m256")]
    vpavgw_ymm_k1z_ymm_m256 = 2114,
    /// <summary>
    /// vpavgw ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpavgw ymm, ymm, ymm","vpavgw ymm, ymm, ymm/m256")]
    vpavgw_ymm_ymm_ymm = 2115,
    /// <summary>
    /// vpavgw ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpavgw ymm, ymm, m256","vpavgw ymm, ymm, ymm/m256")]
    vpavgw_ymm_ymm_m256 = 2116,
    /// <summary>
    /// vpavgw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpavgw zmm {k1}{z}, zmm, zmm","vpavgw zmm {k1}{z}, zmm, zmm/m512")]
    vpavgw_zmm_k1z_zmm_zmm = 2117,
    /// <summary>
    /// vpavgw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpavgw zmm {k1}{z}, zmm, m512","vpavgw zmm {k1}{z}, zmm, zmm/m512")]
    vpavgw_zmm_k1z_zmm_m512 = 2118,
    /// <summary>
    /// vpblendmb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpblendmb xmm {k1}{z}, xmm, xmm","vpblendmb xmm {k1}{z}, xmm, xmm/m128")]
    vpblendmb_xmm_k1z_xmm_xmm = 2119,
    /// <summary>
    /// vpblendmb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpblendmb xmm {k1}{z}, xmm, m128","vpblendmb xmm {k1}{z}, xmm, xmm/m128")]
    vpblendmb_xmm_k1z_xmm_m128 = 2120,
    /// <summary>
    /// vpblendmb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpblendmb ymm {k1}{z}, ymm, ymm","vpblendmb ymm {k1}{z}, ymm, ymm/m256")]
    vpblendmb_ymm_k1z_ymm_ymm = 2121,
    /// <summary>
    /// vpblendmb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpblendmb ymm {k1}{z}, ymm, m256","vpblendmb ymm {k1}{z}, ymm, ymm/m256")]
    vpblendmb_ymm_k1z_ymm_m256 = 2122,
    /// <summary>
    /// vpblendmb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpblendmb zmm {k1}{z}, zmm, zmm","vpblendmb zmm {k1}{z}, zmm, zmm/m512")]
    vpblendmb_zmm_k1z_zmm_zmm = 2123,
    /// <summary>
    /// vpblendmb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpblendmb zmm {k1}{z}, zmm, m512","vpblendmb zmm {k1}{z}, zmm, zmm/m512")]
    vpblendmb_zmm_k1z_zmm_m512 = 2124,
    /// <summary>
    /// vpblendmd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpblendmd xmm {k1}{z}, xmm, xmm","vpblendmd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpblendmd_xmm_k1z_xmm_xmm = 2125,
    /// <summary>
    /// vpblendmd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpblendmd xmm {k1}{z}, xmm, m128","vpblendmd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpblendmd_xmm_k1z_xmm_m128 = 2126,
    /// <summary>
    /// vpblendmd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpblendmd xmm {k1}{z}, xmm, m32bcst","vpblendmd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpblendmd_xmm_k1z_xmm_m32bcst = 2127,
    /// <summary>
    /// vpblendmd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpblendmd ymm {k1}{z}, ymm, ymm","vpblendmd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpblendmd_ymm_k1z_ymm_ymm = 2128,
    /// <summary>
    /// vpblendmd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpblendmd ymm {k1}{z}, ymm, m256","vpblendmd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpblendmd_ymm_k1z_ymm_m256 = 2129,
    /// <summary>
    /// vpblendmd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpblendmd ymm {k1}{z}, ymm, m32bcst","vpblendmd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpblendmd_ymm_k1z_ymm_m32bcst = 2130,
    /// <summary>
    /// vpblendmd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpblendmd zmm {k1}{z}, zmm, zmm","vpblendmd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpblendmd_zmm_k1z_zmm_zmm = 2131,
    /// <summary>
    /// vpblendmd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpblendmd zmm {k1}{z}, zmm, m512","vpblendmd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpblendmd_zmm_k1z_zmm_m512 = 2132,
    /// <summary>
    /// vpblendmd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpblendmd zmm {k1}{z}, zmm, m32bcst","vpblendmd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpblendmd_zmm_k1z_zmm_m32bcst = 2133,
    /// <summary>
    /// vpblendmq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpblendmq xmm {k1}{z}, xmm, xmm","vpblendmq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpblendmq_xmm_k1z_xmm_xmm = 2134,
    /// <summary>
    /// vpblendmq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpblendmq xmm {k1}{z}, xmm, m128","vpblendmq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpblendmq_xmm_k1z_xmm_m128 = 2135,
    /// <summary>
    /// vpblendmq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpblendmq xmm {k1}{z}, xmm, m64bcst","vpblendmq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpblendmq_xmm_k1z_xmm_m64bcst = 2136,
    /// <summary>
    /// vpblendmq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpblendmq ymm {k1}{z}, ymm, ymm","vpblendmq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpblendmq_ymm_k1z_ymm_ymm = 2137,
    /// <summary>
    /// vpblendmq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpblendmq ymm {k1}{z}, ymm, m256","vpblendmq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpblendmq_ymm_k1z_ymm_m256 = 2138,
    /// <summary>
    /// vpblendmq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpblendmq ymm {k1}{z}, ymm, m64bcst","vpblendmq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpblendmq_ymm_k1z_ymm_m64bcst = 2139,
    /// <summary>
    /// vpblendmq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpblendmq zmm {k1}{z}, zmm, zmm","vpblendmq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpblendmq_zmm_k1z_zmm_zmm = 2140,
    /// <summary>
    /// vpblendmq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpblendmq zmm {k1}{z}, zmm, m512","vpblendmq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpblendmq_zmm_k1z_zmm_m512 = 2141,
    /// <summary>
    /// vpblendmq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpblendmq zmm {k1}{z}, zmm, m64bcst","vpblendmq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpblendmq_zmm_k1z_zmm_m64bcst = 2142,
    /// <summary>
    /// vpblendmw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpblendmw xmm {k1}{z}, xmm, xmm","vpblendmw xmm {k1}{z}, xmm, xmm/m128")]
    vpblendmw_xmm_k1z_xmm_xmm = 2143,
    /// <summary>
    /// vpblendmw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpblendmw xmm {k1}{z}, xmm, m128","vpblendmw xmm {k1}{z}, xmm, xmm/m128")]
    vpblendmw_xmm_k1z_xmm_m128 = 2144,
    /// <summary>
    /// vpblendmw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpblendmw ymm {k1}{z}, ymm, ymm","vpblendmw ymm {k1}{z}, ymm, ymm/m256")]
    vpblendmw_ymm_k1z_ymm_ymm = 2145,
    /// <summary>
    /// vpblendmw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpblendmw ymm {k1}{z}, ymm, m256","vpblendmw ymm {k1}{z}, ymm, ymm/m256")]
    vpblendmw_ymm_k1z_ymm_m256 = 2146,
    /// <summary>
    /// vpblendmw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpblendmw zmm {k1}{z}, zmm, zmm","vpblendmw zmm {k1}{z}, zmm, zmm/m512")]
    vpblendmw_zmm_k1z_zmm_zmm = 2147,
    /// <summary>
    /// vpblendmw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpblendmw zmm {k1}{z}, zmm, m512","vpblendmw zmm {k1}{z}, zmm, zmm/m512")]
    vpblendmw_zmm_k1z_zmm_m512 = 2148,
    /// <summary>
    /// vpbroadcastb xmm {k1}{z}, xmm/m8
    /// </summary>
    [Symbol("vpbroadcastb xmm {k1}{z}, xmm","vpbroadcastb xmm {k1}{z}, xmm/m8")]
    vpbroadcastb_xmm_k1z_xmm = 2149,
    /// <summary>
    /// vpbroadcastb xmm {k1}{z}, xmm/m8
    /// </summary>
    [Symbol("vpbroadcastb xmm {k1}{z}, m8","vpbroadcastb xmm {k1}{z}, xmm/m8")]
    vpbroadcastb_xmm_k1z_m8 = 2150,
    /// <summary>
    /// vpbroadcastb xmm, xmm/m8
    /// </summary>
    [Symbol("vpbroadcastb xmm, xmm","vpbroadcastb xmm, xmm/m8")]
    vpbroadcastb_xmm_xmm = 2151,
    /// <summary>
    /// vpbroadcastb xmm, xmm/m8
    /// </summary>
    [Symbol("vpbroadcastb xmm, m8","vpbroadcastb xmm, xmm/m8")]
    vpbroadcastb_xmm_m8 = 2152,
    /// <summary>
    /// vpbroadcastb ymm {k1}{z}, xmm/m8
    /// </summary>
    [Symbol("vpbroadcastb ymm {k1}{z}, xmm","vpbroadcastb ymm {k1}{z}, xmm/m8")]
    vpbroadcastb_ymm_k1z_xmm = 2153,
    /// <summary>
    /// vpbroadcastb ymm {k1}{z}, xmm/m8
    /// </summary>
    [Symbol("vpbroadcastb ymm {k1}{z}, m8","vpbroadcastb ymm {k1}{z}, xmm/m8")]
    vpbroadcastb_ymm_k1z_m8 = 2154,
    /// <summary>
    /// vpbroadcastb ymm, xmm/m8
    /// </summary>
    [Symbol("vpbroadcastb ymm, xmm","vpbroadcastb ymm, xmm/m8")]
    vpbroadcastb_ymm_xmm = 2155,
    /// <summary>
    /// vpbroadcastb ymm, xmm/m8
    /// </summary>
    [Symbol("vpbroadcastb ymm, m8","vpbroadcastb ymm, xmm/m8")]
    vpbroadcastb_ymm_m8 = 2156,
    /// <summary>
    /// vpbroadcastb zmm {k1}{z}, xmm/m8
    /// </summary>
    [Symbol("vpbroadcastb zmm {k1}{z}, xmm","vpbroadcastb zmm {k1}{z}, xmm/m8")]
    vpbroadcastb_zmm_k1z_xmm = 2157,
    /// <summary>
    /// vpbroadcastb zmm {k1}{z}, xmm/m8
    /// </summary>
    [Symbol("vpbroadcastb zmm {k1}{z}, m8","vpbroadcastb zmm {k1}{z}, xmm/m8")]
    vpbroadcastb_zmm_k1z_m8 = 2158,
    /// <summary>
    /// vpbroadcastd xmm {k1}{z}, xmm/m32
    /// </summary>
    [Symbol("vpbroadcastd xmm {k1}{z}, xmm","vpbroadcastd xmm {k1}{z}, xmm/m32")]
    vpbroadcastd_xmm_k1z_xmm = 2159,
    /// <summary>
    /// vpbroadcastd xmm {k1}{z}, xmm/m32
    /// </summary>
    [Symbol("vpbroadcastd xmm {k1}{z}, m32","vpbroadcastd xmm {k1}{z}, xmm/m32")]
    vpbroadcastd_xmm_k1z_m32 = 2160,
    /// <summary>
    /// vpbroadcastd xmm, xmm/m32
    /// </summary>
    [Symbol("vpbroadcastd xmm, xmm","vpbroadcastd xmm, xmm/m32")]
    vpbroadcastd_xmm_xmm = 2161,
    /// <summary>
    /// vpbroadcastd xmm, xmm/m32
    /// </summary>
    [Symbol("vpbroadcastd xmm, m32","vpbroadcastd xmm, xmm/m32")]
    vpbroadcastd_xmm_m32 = 2162,
    /// <summary>
    /// vpbroadcastd ymm {k1}{z}, xmm/m32
    /// </summary>
    [Symbol("vpbroadcastd ymm {k1}{z}, xmm","vpbroadcastd ymm {k1}{z}, xmm/m32")]
    vpbroadcastd_ymm_k1z_xmm = 2163,
    /// <summary>
    /// vpbroadcastd ymm {k1}{z}, xmm/m32
    /// </summary>
    [Symbol("vpbroadcastd ymm {k1}{z}, m32","vpbroadcastd ymm {k1}{z}, xmm/m32")]
    vpbroadcastd_ymm_k1z_m32 = 2164,
    /// <summary>
    /// vpbroadcastd ymm, xmm/m32
    /// </summary>
    [Symbol("vpbroadcastd ymm, xmm","vpbroadcastd ymm, xmm/m32")]
    vpbroadcastd_ymm_xmm = 2165,
    /// <summary>
    /// vpbroadcastd ymm, xmm/m32
    /// </summary>
    [Symbol("vpbroadcastd ymm, m32","vpbroadcastd ymm, xmm/m32")]
    vpbroadcastd_ymm_m32 = 2166,
    /// <summary>
    /// vpbroadcastd zmm {k1}{z}, xmm/m32
    /// </summary>
    [Symbol("vpbroadcastd zmm {k1}{z}, xmm","vpbroadcastd zmm {k1}{z}, xmm/m32")]
    vpbroadcastd_zmm_k1z_xmm = 2167,
    /// <summary>
    /// vpbroadcastd zmm {k1}{z}, xmm/m32
    /// </summary>
    [Symbol("vpbroadcastd zmm {k1}{z}, m32","vpbroadcastd zmm {k1}{z}, xmm/m32")]
    vpbroadcastd_zmm_k1z_m32 = 2168,
    /// <summary>
    /// vpbroadcastmb2q xmm, k
    /// </summary>
    [Symbol("vpbroadcastmb2q xmm, k","vpbroadcastmb2q xmm, k")]
    vpbroadcastmb2q_xmm_k = 2169,
    /// <summary>
    /// vpbroadcastmb2q ymm, k
    /// </summary>
    [Symbol("vpbroadcastmb2q ymm, k","vpbroadcastmb2q ymm, k")]
    vpbroadcastmb2q_ymm_k = 2170,
    /// <summary>
    /// vpbroadcastmb2q zmm, k
    /// </summary>
    [Symbol("vpbroadcastmb2q zmm, k","vpbroadcastmb2q zmm, k")]
    vpbroadcastmb2q_zmm_k = 2171,
    /// <summary>
    /// vpbroadcastmw2d xmm, k
    /// </summary>
    [Symbol("vpbroadcastmw2d xmm, k","vpbroadcastmw2d xmm, k")]
    vpbroadcastmw2d_xmm_k = 2172,
    /// <summary>
    /// vpbroadcastmw2d ymm, k
    /// </summary>
    [Symbol("vpbroadcastmw2d ymm, k","vpbroadcastmw2d ymm, k")]
    vpbroadcastmw2d_ymm_k = 2173,
    /// <summary>
    /// vpbroadcastmw2d zmm, k
    /// </summary>
    [Symbol("vpbroadcastmw2d zmm, k","vpbroadcastmw2d zmm, k")]
    vpbroadcastmw2d_zmm_k = 2174,
    /// <summary>
    /// vpbroadcastq xmm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpbroadcastq xmm {k1}{z}, xmm","vpbroadcastq xmm {k1}{z}, xmm/m64")]
    vpbroadcastq_xmm_k1z_xmm = 2175,
    /// <summary>
    /// vpbroadcastq xmm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpbroadcastq xmm {k1}{z}, m64","vpbroadcastq xmm {k1}{z}, xmm/m64")]
    vpbroadcastq_xmm_k1z_m64 = 2176,
    /// <summary>
    /// vpbroadcastq xmm, xmm/m64
    /// </summary>
    [Symbol("vpbroadcastq xmm, xmm","vpbroadcastq xmm, xmm/m64")]
    vpbroadcastq_xmm_xmm = 2177,
    /// <summary>
    /// vpbroadcastq xmm, xmm/m64
    /// </summary>
    [Symbol("vpbroadcastq xmm, m64","vpbroadcastq xmm, xmm/m64")]
    vpbroadcastq_xmm_m64 = 2178,
    /// <summary>
    /// vpbroadcastq ymm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpbroadcastq ymm {k1}{z}, xmm","vpbroadcastq ymm {k1}{z}, xmm/m64")]
    vpbroadcastq_ymm_k1z_xmm = 2179,
    /// <summary>
    /// vpbroadcastq ymm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpbroadcastq ymm {k1}{z}, m64","vpbroadcastq ymm {k1}{z}, xmm/m64")]
    vpbroadcastq_ymm_k1z_m64 = 2180,
    /// <summary>
    /// vpbroadcastq ymm, xmm/m64
    /// </summary>
    [Symbol("vpbroadcastq ymm, xmm","vpbroadcastq ymm, xmm/m64")]
    vpbroadcastq_ymm_xmm = 2181,
    /// <summary>
    /// vpbroadcastq ymm, xmm/m64
    /// </summary>
    [Symbol("vpbroadcastq ymm, m64","vpbroadcastq ymm, xmm/m64")]
    vpbroadcastq_ymm_m64 = 2182,
    /// <summary>
    /// vpbroadcastq zmm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpbroadcastq zmm {k1}{z}, xmm","vpbroadcastq zmm {k1}{z}, xmm/m64")]
    vpbroadcastq_zmm_k1z_xmm = 2183,
    /// <summary>
    /// vpbroadcastq zmm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpbroadcastq zmm {k1}{z}, m64","vpbroadcastq zmm {k1}{z}, xmm/m64")]
    vpbroadcastq_zmm_k1z_m64 = 2184,
    /// <summary>
    /// vpbroadcastw xmm {k1}{z}, xmm/m16
    /// </summary>
    [Symbol("vpbroadcastw xmm {k1}{z}, xmm","vpbroadcastw xmm {k1}{z}, xmm/m16")]
    vpbroadcastw_xmm_k1z_xmm = 2185,
    /// <summary>
    /// vpbroadcastw xmm {k1}{z}, xmm/m16
    /// </summary>
    [Symbol("vpbroadcastw xmm {k1}{z}, m16","vpbroadcastw xmm {k1}{z}, xmm/m16")]
    vpbroadcastw_xmm_k1z_m16 = 2186,
    /// <summary>
    /// vpbroadcastw xmm, xmm/m16
    /// </summary>
    [Symbol("vpbroadcastw xmm, xmm","vpbroadcastw xmm, xmm/m16")]
    vpbroadcastw_xmm_xmm = 2187,
    /// <summary>
    /// vpbroadcastw xmm, xmm/m16
    /// </summary>
    [Symbol("vpbroadcastw xmm, m16","vpbroadcastw xmm, xmm/m16")]
    vpbroadcastw_xmm_m16 = 2188,
    /// <summary>
    /// vpbroadcastw ymm {k1}{z}, xmm/m16
    /// </summary>
    [Symbol("vpbroadcastw ymm {k1}{z}, xmm","vpbroadcastw ymm {k1}{z}, xmm/m16")]
    vpbroadcastw_ymm_k1z_xmm = 2189,
    /// <summary>
    /// vpbroadcastw ymm {k1}{z}, xmm/m16
    /// </summary>
    [Symbol("vpbroadcastw ymm {k1}{z}, m16","vpbroadcastw ymm {k1}{z}, xmm/m16")]
    vpbroadcastw_ymm_k1z_m16 = 2190,
    /// <summary>
    /// vpbroadcastw ymm, xmm/m16
    /// </summary>
    [Symbol("vpbroadcastw ymm, xmm","vpbroadcastw ymm, xmm/m16")]
    vpbroadcastw_ymm_xmm = 2191,
    /// <summary>
    /// vpbroadcastw ymm, xmm/m16
    /// </summary>
    [Symbol("vpbroadcastw ymm, m16","vpbroadcastw ymm, xmm/m16")]
    vpbroadcastw_ymm_m16 = 2192,
    /// <summary>
    /// vpbroadcastw zmm {k1}{z}, xmm/m16
    /// </summary>
    [Symbol("vpbroadcastw zmm {k1}{z}, xmm","vpbroadcastw zmm {k1}{z}, xmm/m16")]
    vpbroadcastw_zmm_k1z_xmm = 2193,
    /// <summary>
    /// vpbroadcastw zmm {k1}{z}, xmm/m16
    /// </summary>
    [Symbol("vpbroadcastw zmm {k1}{z}, m16","vpbroadcastw zmm {k1}{z}, xmm/m16")]
    vpbroadcastw_zmm_k1z_m16 = 2194,
    /// <summary>
    /// vpcmpb k1 {k2}, xmm, xmm/m128, imm8
    /// </summary>
    [Symbol("vpcmpb k1 {k2}, xmm, xmm, imm8","vpcmpb k1 {k2}, xmm, xmm/m128, imm8")]
    vpcmpb_k1_k2_xmm_xmm_imm8 = 2195,
    /// <summary>
    /// vpcmpb k1 {k2}, xmm, xmm/m128, imm8
    /// </summary>
    [Symbol("vpcmpb k1 {k2}, xmm, m128, imm8","vpcmpb k1 {k2}, xmm, xmm/m128, imm8")]
    vpcmpb_k1_k2_xmm_m128_imm8 = 2196,
    /// <summary>
    /// vpcmpb k1 {k2}, ymm, ymm/m256, imm8
    /// </summary>
    [Symbol("vpcmpb k1 {k2}, ymm, ymm, imm8","vpcmpb k1 {k2}, ymm, ymm/m256, imm8")]
    vpcmpb_k1_k2_ymm_ymm_imm8 = 2197,
    /// <summary>
    /// vpcmpb k1 {k2}, ymm, ymm/m256, imm8
    /// </summary>
    [Symbol("vpcmpb k1 {k2}, ymm, m256, imm8","vpcmpb k1 {k2}, ymm, ymm/m256, imm8")]
    vpcmpb_k1_k2_ymm_m256_imm8 = 2198,
    /// <summary>
    /// vpcmpb k1 {k2}, zmm, zmm/m512, imm8
    /// </summary>
    [Symbol("vpcmpb k1 {k2}, zmm, zmm, imm8","vpcmpb k1 {k2}, zmm, zmm/m512, imm8")]
    vpcmpb_k1_k2_zmm_zmm_imm8 = 2199,
    /// <summary>
    /// vpcmpb k1 {k2}, zmm, zmm/m512, imm8
    /// </summary>
    [Symbol("vpcmpb k1 {k2}, zmm, m512, imm8","vpcmpb k1 {k2}, zmm, zmm/m512, imm8")]
    vpcmpb_k1_k2_zmm_m512_imm8 = 2200,
    /// <summary>
    /// vpcmpd k1 {k2}, xmm, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vpcmpd k1 {k2}, xmm, xmm, imm8","vpcmpd k1 {k2}, xmm, xmm/m128/m32bcst, imm8")]
    vpcmpd_k1_k2_xmm_xmm_imm8 = 2201,
    /// <summary>
    /// vpcmpd k1 {k2}, xmm, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vpcmpd k1 {k2}, xmm, m128, imm8","vpcmpd k1 {k2}, xmm, xmm/m128/m32bcst, imm8")]
    vpcmpd_k1_k2_xmm_m128_imm8 = 2202,
    /// <summary>
    /// vpcmpd k1 {k2}, xmm, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vpcmpd k1 {k2}, xmm, m32bcst, imm8","vpcmpd k1 {k2}, xmm, xmm/m128/m32bcst, imm8")]
    vpcmpd_k1_k2_xmm_m32bcst_imm8 = 2203,
    /// <summary>
    /// vpcmpd k1 {k2}, ymm, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vpcmpd k1 {k2}, ymm, ymm, imm8","vpcmpd k1 {k2}, ymm, ymm/m256/m32bcst, imm8")]
    vpcmpd_k1_k2_ymm_ymm_imm8 = 2204,
    /// <summary>
    /// vpcmpd k1 {k2}, ymm, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vpcmpd k1 {k2}, ymm, m256, imm8","vpcmpd k1 {k2}, ymm, ymm/m256/m32bcst, imm8")]
    vpcmpd_k1_k2_ymm_m256_imm8 = 2205,
    /// <summary>
    /// vpcmpd k1 {k2}, ymm, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vpcmpd k1 {k2}, ymm, m32bcst, imm8","vpcmpd k1 {k2}, ymm, ymm/m256/m32bcst, imm8")]
    vpcmpd_k1_k2_ymm_m32bcst_imm8 = 2206,
    /// <summary>
    /// vpcmpd k1 {k2}, zmm, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vpcmpd k1 {k2}, zmm, zmm, imm8","vpcmpd k1 {k2}, zmm, zmm/m512/m32bcst, imm8")]
    vpcmpd_k1_k2_zmm_zmm_imm8 = 2207,
    /// <summary>
    /// vpcmpd k1 {k2}, zmm, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vpcmpd k1 {k2}, zmm, m512, imm8","vpcmpd k1 {k2}, zmm, zmm/m512/m32bcst, imm8")]
    vpcmpd_k1_k2_zmm_m512_imm8 = 2208,
    /// <summary>
    /// vpcmpd k1 {k2}, zmm, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vpcmpd k1 {k2}, zmm, m32bcst, imm8","vpcmpd k1 {k2}, zmm, zmm/m512/m32bcst, imm8")]
    vpcmpd_k1_k2_zmm_m32bcst_imm8 = 2209,
    /// <summary>
    /// vpcmpeqb k1 {k2}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpcmpeqb k1 {k2}, xmm, xmm","vpcmpeqb k1 {k2}, xmm, xmm/m128")]
    vpcmpeqb_k1_k2_xmm_xmm = 2210,
    /// <summary>
    /// vpcmpeqb k1 {k2}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpcmpeqb k1 {k2}, xmm, m128","vpcmpeqb k1 {k2}, xmm, xmm/m128")]
    vpcmpeqb_k1_k2_xmm_m128 = 2211,
    /// <summary>
    /// vpcmpeqb k1 {k2}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpcmpeqb k1 {k2}, ymm, ymm","vpcmpeqb k1 {k2}, ymm, ymm/m256")]
    vpcmpeqb_k1_k2_ymm_ymm = 2212,
    /// <summary>
    /// vpcmpeqb k1 {k2}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpcmpeqb k1 {k2}, ymm, m256","vpcmpeqb k1 {k2}, ymm, ymm/m256")]
    vpcmpeqb_k1_k2_ymm_m256 = 2213,
    /// <summary>
    /// vpcmpeqb k1 {k2}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpcmpeqb k1 {k2}, zmm, zmm","vpcmpeqb k1 {k2}, zmm, zmm/m512")]
    vpcmpeqb_k1_k2_zmm_zmm = 2214,
    /// <summary>
    /// vpcmpeqb k1 {k2}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpcmpeqb k1 {k2}, zmm, m512","vpcmpeqb k1 {k2}, zmm, zmm/m512")]
    vpcmpeqb_k1_k2_zmm_m512 = 2215,
    /// <summary>
    /// vpcmpeqb xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpcmpeqb xmm, xmm, xmm","vpcmpeqb xmm, xmm, xmm/m128")]
    vpcmpeqb_xmm_xmm_xmm = 2216,
    /// <summary>
    /// vpcmpeqb xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpcmpeqb xmm, xmm, m128","vpcmpeqb xmm, xmm, xmm/m128")]
    vpcmpeqb_xmm_xmm_m128 = 2217,
    /// <summary>
    /// vpcmpeqb ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpcmpeqb ymm, ymm, ymm","vpcmpeqb ymm, ymm, ymm/m256")]
    vpcmpeqb_ymm_ymm_ymm = 2218,
    /// <summary>
    /// vpcmpeqb ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpcmpeqb ymm, ymm, m256","vpcmpeqb ymm, ymm, ymm/m256")]
    vpcmpeqb_ymm_ymm_m256 = 2219,
    /// <summary>
    /// vpcmpeqd k1 {k2}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpcmpeqd k1 {k2}, xmm, xmm","vpcmpeqd k1 {k2}, xmm, xmm/m128/m32bcst")]
    vpcmpeqd_k1_k2_xmm_xmm = 2220,
    /// <summary>
    /// vpcmpeqd k1 {k2}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpcmpeqd k1 {k2}, xmm, m128","vpcmpeqd k1 {k2}, xmm, xmm/m128/m32bcst")]
    vpcmpeqd_k1_k2_xmm_m128 = 2221,
    /// <summary>
    /// vpcmpeqd k1 {k2}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpcmpeqd k1 {k2}, xmm, m32bcst","vpcmpeqd k1 {k2}, xmm, xmm/m128/m32bcst")]
    vpcmpeqd_k1_k2_xmm_m32bcst = 2222,
    /// <summary>
    /// vpcmpeqd k1 {k2}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpcmpeqd k1 {k2}, ymm, ymm","vpcmpeqd k1 {k2}, ymm, ymm/m256/m32bcst")]
    vpcmpeqd_k1_k2_ymm_ymm = 2223,
    /// <summary>
    /// vpcmpeqd k1 {k2}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpcmpeqd k1 {k2}, ymm, m256","vpcmpeqd k1 {k2}, ymm, ymm/m256/m32bcst")]
    vpcmpeqd_k1_k2_ymm_m256 = 2224,
    /// <summary>
    /// vpcmpeqd k1 {k2}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpcmpeqd k1 {k2}, ymm, m32bcst","vpcmpeqd k1 {k2}, ymm, ymm/m256/m32bcst")]
    vpcmpeqd_k1_k2_ymm_m32bcst = 2225,
    /// <summary>
    /// vpcmpeqd k1 {k2}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpcmpeqd k1 {k2}, zmm, zmm","vpcmpeqd k1 {k2}, zmm, zmm/m512/m32bcst")]
    vpcmpeqd_k1_k2_zmm_zmm = 2226,
    /// <summary>
    /// vpcmpeqd k1 {k2}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpcmpeqd k1 {k2}, zmm, m512","vpcmpeqd k1 {k2}, zmm, zmm/m512/m32bcst")]
    vpcmpeqd_k1_k2_zmm_m512 = 2227,
    /// <summary>
    /// vpcmpeqd k1 {k2}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpcmpeqd k1 {k2}, zmm, m32bcst","vpcmpeqd k1 {k2}, zmm, zmm/m512/m32bcst")]
    vpcmpeqd_k1_k2_zmm_m32bcst = 2228,
    /// <summary>
    /// vpcmpeqd xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpcmpeqd xmm, xmm, xmm","vpcmpeqd xmm, xmm, xmm/m128")]
    vpcmpeqd_xmm_xmm_xmm = 2229,
    /// <summary>
    /// vpcmpeqd xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpcmpeqd xmm, xmm, m128","vpcmpeqd xmm, xmm, xmm/m128")]
    vpcmpeqd_xmm_xmm_m128 = 2230,
    /// <summary>
    /// vpcmpeqd ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpcmpeqd ymm, ymm, ymm","vpcmpeqd ymm, ymm, ymm/m256")]
    vpcmpeqd_ymm_ymm_ymm = 2231,
    /// <summary>
    /// vpcmpeqd ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpcmpeqd ymm, ymm, m256","vpcmpeqd ymm, ymm, ymm/m256")]
    vpcmpeqd_ymm_ymm_m256 = 2232,
    /// <summary>
    /// vpcmpeqq k1 {k2}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpcmpeqq k1 {k2}, xmm, xmm","vpcmpeqq k1 {k2}, xmm, xmm/m128/m64bcst")]
    vpcmpeqq_k1_k2_xmm_xmm = 2233,
    /// <summary>
    /// vpcmpeqq k1 {k2}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpcmpeqq k1 {k2}, xmm, m128","vpcmpeqq k1 {k2}, xmm, xmm/m128/m64bcst")]
    vpcmpeqq_k1_k2_xmm_m128 = 2234,
    /// <summary>
    /// vpcmpeqq k1 {k2}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpcmpeqq k1 {k2}, xmm, m64bcst","vpcmpeqq k1 {k2}, xmm, xmm/m128/m64bcst")]
    vpcmpeqq_k1_k2_xmm_m64bcst = 2235,
    /// <summary>
    /// vpcmpeqq k1 {k2}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpcmpeqq k1 {k2}, ymm, ymm","vpcmpeqq k1 {k2}, ymm, ymm/m256/m64bcst")]
    vpcmpeqq_k1_k2_ymm_ymm = 2236,
    /// <summary>
    /// vpcmpeqq k1 {k2}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpcmpeqq k1 {k2}, ymm, m256","vpcmpeqq k1 {k2}, ymm, ymm/m256/m64bcst")]
    vpcmpeqq_k1_k2_ymm_m256 = 2237,
    /// <summary>
    /// vpcmpeqq k1 {k2}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpcmpeqq k1 {k2}, ymm, m64bcst","vpcmpeqq k1 {k2}, ymm, ymm/m256/m64bcst")]
    vpcmpeqq_k1_k2_ymm_m64bcst = 2238,
    /// <summary>
    /// vpcmpeqq k1 {k2}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpcmpeqq k1 {k2}, zmm, zmm","vpcmpeqq k1 {k2}, zmm, zmm/m512/m64bcst")]
    vpcmpeqq_k1_k2_zmm_zmm = 2239,
    /// <summary>
    /// vpcmpeqq k1 {k2}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpcmpeqq k1 {k2}, zmm, m512","vpcmpeqq k1 {k2}, zmm, zmm/m512/m64bcst")]
    vpcmpeqq_k1_k2_zmm_m512 = 2240,
    /// <summary>
    /// vpcmpeqq k1 {k2}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpcmpeqq k1 {k2}, zmm, m64bcst","vpcmpeqq k1 {k2}, zmm, zmm/m512/m64bcst")]
    vpcmpeqq_k1_k2_zmm_m64bcst = 2241,
    /// <summary>
    /// vpcmpeqq xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpcmpeqq xmm, xmm, xmm","vpcmpeqq xmm, xmm, xmm/m128")]
    vpcmpeqq_xmm_xmm_xmm = 2242,
    /// <summary>
    /// vpcmpeqq xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpcmpeqq xmm, xmm, m128","vpcmpeqq xmm, xmm, xmm/m128")]
    vpcmpeqq_xmm_xmm_m128 = 2243,
    /// <summary>
    /// vpcmpeqq ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpcmpeqq ymm, ymm, ymm","vpcmpeqq ymm, ymm, ymm/m256")]
    vpcmpeqq_ymm_ymm_ymm = 2244,
    /// <summary>
    /// vpcmpeqq ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpcmpeqq ymm, ymm, m256","vpcmpeqq ymm, ymm, ymm/m256")]
    vpcmpeqq_ymm_ymm_m256 = 2245,
    /// <summary>
    /// vpcmpeqw k1 {k2}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpcmpeqw k1 {k2}, xmm, xmm","vpcmpeqw k1 {k2}, xmm, xmm/m128")]
    vpcmpeqw_k1_k2_xmm_xmm = 2246,
    /// <summary>
    /// vpcmpeqw k1 {k2}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpcmpeqw k1 {k2}, xmm, m128","vpcmpeqw k1 {k2}, xmm, xmm/m128")]
    vpcmpeqw_k1_k2_xmm_m128 = 2247,
    /// <summary>
    /// vpcmpeqw k1 {k2}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpcmpeqw k1 {k2}, ymm, ymm","vpcmpeqw k1 {k2}, ymm, ymm/m256")]
    vpcmpeqw_k1_k2_ymm_ymm = 2248,
    /// <summary>
    /// vpcmpeqw k1 {k2}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpcmpeqw k1 {k2}, ymm, m256","vpcmpeqw k1 {k2}, ymm, ymm/m256")]
    vpcmpeqw_k1_k2_ymm_m256 = 2249,
    /// <summary>
    /// vpcmpeqw k1 {k2}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpcmpeqw k1 {k2}, zmm, zmm","vpcmpeqw k1 {k2}, zmm, zmm/m512")]
    vpcmpeqw_k1_k2_zmm_zmm = 2250,
    /// <summary>
    /// vpcmpeqw k1 {k2}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpcmpeqw k1 {k2}, zmm, m512","vpcmpeqw k1 {k2}, zmm, zmm/m512")]
    vpcmpeqw_k1_k2_zmm_m512 = 2251,
    /// <summary>
    /// vpcmpeqw xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpcmpeqw xmm, xmm, xmm","vpcmpeqw xmm, xmm, xmm/m128")]
    vpcmpeqw_xmm_xmm_xmm = 2252,
    /// <summary>
    /// vpcmpeqw xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpcmpeqw xmm, xmm, m128","vpcmpeqw xmm, xmm, xmm/m128")]
    vpcmpeqw_xmm_xmm_m128 = 2253,
    /// <summary>
    /// vpcmpeqw ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpcmpeqw ymm, ymm, ymm","vpcmpeqw ymm, ymm, ymm/m256")]
    vpcmpeqw_ymm_ymm_ymm = 2254,
    /// <summary>
    /// vpcmpeqw ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpcmpeqw ymm, ymm, m256","vpcmpeqw ymm, ymm, ymm/m256")]
    vpcmpeqw_ymm_ymm_m256 = 2255,
    /// <summary>
    /// vpcmpgtb k1 {k2}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpcmpgtb k1 {k2}, xmm, xmm","vpcmpgtb k1 {k2}, xmm, xmm/m128")]
    vpcmpgtb_k1_k2_xmm_xmm = 2256,
    /// <summary>
    /// vpcmpgtb k1 {k2}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpcmpgtb k1 {k2}, xmm, m128","vpcmpgtb k1 {k2}, xmm, xmm/m128")]
    vpcmpgtb_k1_k2_xmm_m128 = 2257,
    /// <summary>
    /// vpcmpgtb k1 {k2}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpcmpgtb k1 {k2}, ymm, ymm","vpcmpgtb k1 {k2}, ymm, ymm/m256")]
    vpcmpgtb_k1_k2_ymm_ymm = 2258,
    /// <summary>
    /// vpcmpgtb k1 {k2}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpcmpgtb k1 {k2}, ymm, m256","vpcmpgtb k1 {k2}, ymm, ymm/m256")]
    vpcmpgtb_k1_k2_ymm_m256 = 2259,
    /// <summary>
    /// vpcmpgtb k1 {k2}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpcmpgtb k1 {k2}, zmm, zmm","vpcmpgtb k1 {k2}, zmm, zmm/m512")]
    vpcmpgtb_k1_k2_zmm_zmm = 2260,
    /// <summary>
    /// vpcmpgtb k1 {k2}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpcmpgtb k1 {k2}, zmm, m512","vpcmpgtb k1 {k2}, zmm, zmm/m512")]
    vpcmpgtb_k1_k2_zmm_m512 = 2261,
    /// <summary>
    /// vpcmpgtb xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpcmpgtb xmm, xmm, xmm","vpcmpgtb xmm, xmm, xmm/m128")]
    vpcmpgtb_xmm_xmm_xmm = 2262,
    /// <summary>
    /// vpcmpgtb xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpcmpgtb xmm, xmm, m128","vpcmpgtb xmm, xmm, xmm/m128")]
    vpcmpgtb_xmm_xmm_m128 = 2263,
    /// <summary>
    /// vpcmpgtb ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpcmpgtb ymm, ymm, ymm","vpcmpgtb ymm, ymm, ymm/m256")]
    vpcmpgtb_ymm_ymm_ymm = 2264,
    /// <summary>
    /// vpcmpgtb ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpcmpgtb ymm, ymm, m256","vpcmpgtb ymm, ymm, ymm/m256")]
    vpcmpgtb_ymm_ymm_m256 = 2265,
    /// <summary>
    /// vpcmpgtd k1 {k2}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpcmpgtd k1 {k2}, xmm, xmm","vpcmpgtd k1 {k2}, xmm, xmm/m128/m32bcst")]
    vpcmpgtd_k1_k2_xmm_xmm = 2266,
    /// <summary>
    /// vpcmpgtd k1 {k2}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpcmpgtd k1 {k2}, xmm, m128","vpcmpgtd k1 {k2}, xmm, xmm/m128/m32bcst")]
    vpcmpgtd_k1_k2_xmm_m128 = 2267,
    /// <summary>
    /// vpcmpgtd k1 {k2}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpcmpgtd k1 {k2}, xmm, m32bcst","vpcmpgtd k1 {k2}, xmm, xmm/m128/m32bcst")]
    vpcmpgtd_k1_k2_xmm_m32bcst = 2268,
    /// <summary>
    /// vpcmpgtd k1 {k2}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpcmpgtd k1 {k2}, ymm, ymm","vpcmpgtd k1 {k2}, ymm, ymm/m256/m32bcst")]
    vpcmpgtd_k1_k2_ymm_ymm = 2269,
    /// <summary>
    /// vpcmpgtd k1 {k2}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpcmpgtd k1 {k2}, ymm, m256","vpcmpgtd k1 {k2}, ymm, ymm/m256/m32bcst")]
    vpcmpgtd_k1_k2_ymm_m256 = 2270,
    /// <summary>
    /// vpcmpgtd k1 {k2}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpcmpgtd k1 {k2}, ymm, m32bcst","vpcmpgtd k1 {k2}, ymm, ymm/m256/m32bcst")]
    vpcmpgtd_k1_k2_ymm_m32bcst = 2271,
    /// <summary>
    /// vpcmpgtd k1 {k2}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpcmpgtd k1 {k2}, zmm, zmm","vpcmpgtd k1 {k2}, zmm, zmm/m512/m32bcst")]
    vpcmpgtd_k1_k2_zmm_zmm = 2272,
    /// <summary>
    /// vpcmpgtd k1 {k2}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpcmpgtd k1 {k2}, zmm, m512","vpcmpgtd k1 {k2}, zmm, zmm/m512/m32bcst")]
    vpcmpgtd_k1_k2_zmm_m512 = 2273,
    /// <summary>
    /// vpcmpgtd k1 {k2}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpcmpgtd k1 {k2}, zmm, m32bcst","vpcmpgtd k1 {k2}, zmm, zmm/m512/m32bcst")]
    vpcmpgtd_k1_k2_zmm_m32bcst = 2274,
    /// <summary>
    /// vpcmpgtd xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpcmpgtd xmm, xmm, xmm","vpcmpgtd xmm, xmm, xmm/m128")]
    vpcmpgtd_xmm_xmm_xmm = 2275,
    /// <summary>
    /// vpcmpgtd xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpcmpgtd xmm, xmm, m128","vpcmpgtd xmm, xmm, xmm/m128")]
    vpcmpgtd_xmm_xmm_m128 = 2276,
    /// <summary>
    /// vpcmpgtd ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpcmpgtd ymm, ymm, ymm","vpcmpgtd ymm, ymm, ymm/m256")]
    vpcmpgtd_ymm_ymm_ymm = 2277,
    /// <summary>
    /// vpcmpgtd ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpcmpgtd ymm, ymm, m256","vpcmpgtd ymm, ymm, ymm/m256")]
    vpcmpgtd_ymm_ymm_m256 = 2278,
    /// <summary>
    /// vpcmpgtq k1 {k2}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpcmpgtq k1 {k2}, xmm, xmm","vpcmpgtq k1 {k2}, xmm, xmm/m128/m64bcst")]
    vpcmpgtq_k1_k2_xmm_xmm = 2279,
    /// <summary>
    /// vpcmpgtq k1 {k2}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpcmpgtq k1 {k2}, xmm, m128","vpcmpgtq k1 {k2}, xmm, xmm/m128/m64bcst")]
    vpcmpgtq_k1_k2_xmm_m128 = 2280,
    /// <summary>
    /// vpcmpgtq k1 {k2}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpcmpgtq k1 {k2}, xmm, m64bcst","vpcmpgtq k1 {k2}, xmm, xmm/m128/m64bcst")]
    vpcmpgtq_k1_k2_xmm_m64bcst = 2281,
    /// <summary>
    /// vpcmpgtq k1 {k2}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpcmpgtq k1 {k2}, ymm, ymm","vpcmpgtq k1 {k2}, ymm, ymm/m256/m64bcst")]
    vpcmpgtq_k1_k2_ymm_ymm = 2282,
    /// <summary>
    /// vpcmpgtq k1 {k2}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpcmpgtq k1 {k2}, ymm, m256","vpcmpgtq k1 {k2}, ymm, ymm/m256/m64bcst")]
    vpcmpgtq_k1_k2_ymm_m256 = 2283,
    /// <summary>
    /// vpcmpgtq k1 {k2}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpcmpgtq k1 {k2}, ymm, m64bcst","vpcmpgtq k1 {k2}, ymm, ymm/m256/m64bcst")]
    vpcmpgtq_k1_k2_ymm_m64bcst = 2284,
    /// <summary>
    /// vpcmpgtq k1 {k2}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpcmpgtq k1 {k2}, zmm, zmm","vpcmpgtq k1 {k2}, zmm, zmm/m512/m64bcst")]
    vpcmpgtq_k1_k2_zmm_zmm = 2285,
    /// <summary>
    /// vpcmpgtq k1 {k2}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpcmpgtq k1 {k2}, zmm, m512","vpcmpgtq k1 {k2}, zmm, zmm/m512/m64bcst")]
    vpcmpgtq_k1_k2_zmm_m512 = 2286,
    /// <summary>
    /// vpcmpgtq k1 {k2}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpcmpgtq k1 {k2}, zmm, m64bcst","vpcmpgtq k1 {k2}, zmm, zmm/m512/m64bcst")]
    vpcmpgtq_k1_k2_zmm_m64bcst = 2287,
    /// <summary>
    /// vpcmpgtq xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpcmpgtq xmm, xmm, xmm","vpcmpgtq xmm, xmm, xmm/m128")]
    vpcmpgtq_xmm_xmm_xmm = 2288,
    /// <summary>
    /// vpcmpgtq xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpcmpgtq xmm, xmm, m128","vpcmpgtq xmm, xmm, xmm/m128")]
    vpcmpgtq_xmm_xmm_m128 = 2289,
    /// <summary>
    /// vpcmpgtq ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpcmpgtq ymm, ymm, ymm","vpcmpgtq ymm, ymm, ymm/m256")]
    vpcmpgtq_ymm_ymm_ymm = 2290,
    /// <summary>
    /// vpcmpgtq ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpcmpgtq ymm, ymm, m256","vpcmpgtq ymm, ymm, ymm/m256")]
    vpcmpgtq_ymm_ymm_m256 = 2291,
    /// <summary>
    /// vpcmpgtw k1 {k2}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpcmpgtw k1 {k2}, xmm, xmm","vpcmpgtw k1 {k2}, xmm, xmm/m128")]
    vpcmpgtw_k1_k2_xmm_xmm = 2292,
    /// <summary>
    /// vpcmpgtw k1 {k2}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpcmpgtw k1 {k2}, xmm, m128","vpcmpgtw k1 {k2}, xmm, xmm/m128")]
    vpcmpgtw_k1_k2_xmm_m128 = 2293,
    /// <summary>
    /// vpcmpgtw k1 {k2}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpcmpgtw k1 {k2}, ymm, ymm","vpcmpgtw k1 {k2}, ymm, ymm/m256")]
    vpcmpgtw_k1_k2_ymm_ymm = 2294,
    /// <summary>
    /// vpcmpgtw k1 {k2}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpcmpgtw k1 {k2}, ymm, m256","vpcmpgtw k1 {k2}, ymm, ymm/m256")]
    vpcmpgtw_k1_k2_ymm_m256 = 2295,
    /// <summary>
    /// vpcmpgtw k1 {k2}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpcmpgtw k1 {k2}, zmm, zmm","vpcmpgtw k1 {k2}, zmm, zmm/m512")]
    vpcmpgtw_k1_k2_zmm_zmm = 2296,
    /// <summary>
    /// vpcmpgtw k1 {k2}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpcmpgtw k1 {k2}, zmm, m512","vpcmpgtw k1 {k2}, zmm, zmm/m512")]
    vpcmpgtw_k1_k2_zmm_m512 = 2297,
    /// <summary>
    /// vpcmpgtw xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpcmpgtw xmm, xmm, xmm","vpcmpgtw xmm, xmm, xmm/m128")]
    vpcmpgtw_xmm_xmm_xmm = 2298,
    /// <summary>
    /// vpcmpgtw xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpcmpgtw xmm, xmm, m128","vpcmpgtw xmm, xmm, xmm/m128")]
    vpcmpgtw_xmm_xmm_m128 = 2299,
    /// <summary>
    /// vpcmpgtw ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpcmpgtw ymm, ymm, ymm","vpcmpgtw ymm, ymm, ymm/m256")]
    vpcmpgtw_ymm_ymm_ymm = 2300,
    /// <summary>
    /// vpcmpgtw ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpcmpgtw ymm, ymm, m256","vpcmpgtw ymm, ymm, ymm/m256")]
    vpcmpgtw_ymm_ymm_m256 = 2301,
    /// <summary>
    /// vpcmpq k1 {k2}, xmm, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("vpcmpq k1 {k2}, xmm, xmm, imm8","vpcmpq k1 {k2}, xmm, xmm/m128/m64bcst, imm8")]
    vpcmpq_k1_k2_xmm_xmm_imm8 = 2302,
    /// <summary>
    /// vpcmpq k1 {k2}, xmm, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("vpcmpq k1 {k2}, xmm, m128, imm8","vpcmpq k1 {k2}, xmm, xmm/m128/m64bcst, imm8")]
    vpcmpq_k1_k2_xmm_m128_imm8 = 2303,
    /// <summary>
    /// vpcmpq k1 {k2}, xmm, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("vpcmpq k1 {k2}, xmm, m64bcst, imm8","vpcmpq k1 {k2}, xmm, xmm/m128/m64bcst, imm8")]
    vpcmpq_k1_k2_xmm_m64bcst_imm8 = 2304,
    /// <summary>
    /// vpcmpq k1 {k2}, ymm, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vpcmpq k1 {k2}, ymm, ymm, imm8","vpcmpq k1 {k2}, ymm, ymm/m256/m64bcst, imm8")]
    vpcmpq_k1_k2_ymm_ymm_imm8 = 2305,
    /// <summary>
    /// vpcmpq k1 {k2}, ymm, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vpcmpq k1 {k2}, ymm, m256, imm8","vpcmpq k1 {k2}, ymm, ymm/m256/m64bcst, imm8")]
    vpcmpq_k1_k2_ymm_m256_imm8 = 2306,
    /// <summary>
    /// vpcmpq k1 {k2}, ymm, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vpcmpq k1 {k2}, ymm, m64bcst, imm8","vpcmpq k1 {k2}, ymm, ymm/m256/m64bcst, imm8")]
    vpcmpq_k1_k2_ymm_m64bcst_imm8 = 2307,
    /// <summary>
    /// vpcmpq k1 {k2}, zmm, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vpcmpq k1 {k2}, zmm, zmm, imm8","vpcmpq k1 {k2}, zmm, zmm/m512/m64bcst, imm8")]
    vpcmpq_k1_k2_zmm_zmm_imm8 = 2308,
    /// <summary>
    /// vpcmpq k1 {k2}, zmm, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vpcmpq k1 {k2}, zmm, m512, imm8","vpcmpq k1 {k2}, zmm, zmm/m512/m64bcst, imm8")]
    vpcmpq_k1_k2_zmm_m512_imm8 = 2309,
    /// <summary>
    /// vpcmpq k1 {k2}, zmm, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vpcmpq k1 {k2}, zmm, m64bcst, imm8","vpcmpq k1 {k2}, zmm, zmm/m512/m64bcst, imm8")]
    vpcmpq_k1_k2_zmm_m64bcst_imm8 = 2310,
    /// <summary>
    /// vpcmpub k1 {k2}, xmm, xmm/m128, imm8
    /// </summary>
    [Symbol("vpcmpub k1 {k2}, xmm, xmm, imm8","vpcmpub k1 {k2}, xmm, xmm/m128, imm8")]
    vpcmpub_k1_k2_xmm_xmm_imm8 = 2311,
    /// <summary>
    /// vpcmpub k1 {k2}, xmm, xmm/m128, imm8
    /// </summary>
    [Symbol("vpcmpub k1 {k2}, xmm, m128, imm8","vpcmpub k1 {k2}, xmm, xmm/m128, imm8")]
    vpcmpub_k1_k2_xmm_m128_imm8 = 2312,
    /// <summary>
    /// vpcmpub k1 {k2}, ymm, ymm/m256, imm8
    /// </summary>
    [Symbol("vpcmpub k1 {k2}, ymm, ymm, imm8","vpcmpub k1 {k2}, ymm, ymm/m256, imm8")]
    vpcmpub_k1_k2_ymm_ymm_imm8 = 2313,
    /// <summary>
    /// vpcmpub k1 {k2}, ymm, ymm/m256, imm8
    /// </summary>
    [Symbol("vpcmpub k1 {k2}, ymm, m256, imm8","vpcmpub k1 {k2}, ymm, ymm/m256, imm8")]
    vpcmpub_k1_k2_ymm_m256_imm8 = 2314,
    /// <summary>
    /// vpcmpub k1 {k2}, zmm, zmm/m512, imm8
    /// </summary>
    [Symbol("vpcmpub k1 {k2}, zmm, zmm, imm8","vpcmpub k1 {k2}, zmm, zmm/m512, imm8")]
    vpcmpub_k1_k2_zmm_zmm_imm8 = 2315,
    /// <summary>
    /// vpcmpub k1 {k2}, zmm, zmm/m512, imm8
    /// </summary>
    [Symbol("vpcmpub k1 {k2}, zmm, m512, imm8","vpcmpub k1 {k2}, zmm, zmm/m512, imm8")]
    vpcmpub_k1_k2_zmm_m512_imm8 = 2316,
    /// <summary>
    /// vpcmpud k1 {k2}, xmm, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vpcmpud k1 {k2}, xmm, xmm, imm8","vpcmpud k1 {k2}, xmm, xmm/m128/m32bcst, imm8")]
    vpcmpud_k1_k2_xmm_xmm_imm8 = 2317,
    /// <summary>
    /// vpcmpud k1 {k2}, xmm, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vpcmpud k1 {k2}, xmm, m128, imm8","vpcmpud k1 {k2}, xmm, xmm/m128/m32bcst, imm8")]
    vpcmpud_k1_k2_xmm_m128_imm8 = 2318,
    /// <summary>
    /// vpcmpud k1 {k2}, xmm, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vpcmpud k1 {k2}, xmm, m32bcst, imm8","vpcmpud k1 {k2}, xmm, xmm/m128/m32bcst, imm8")]
    vpcmpud_k1_k2_xmm_m32bcst_imm8 = 2319,
    /// <summary>
    /// vpcmpud k1 {k2}, ymm, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vpcmpud k1 {k2}, ymm, ymm, imm8","vpcmpud k1 {k2}, ymm, ymm/m256/m32bcst, imm8")]
    vpcmpud_k1_k2_ymm_ymm_imm8 = 2320,
    /// <summary>
    /// vpcmpud k1 {k2}, ymm, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vpcmpud k1 {k2}, ymm, m256, imm8","vpcmpud k1 {k2}, ymm, ymm/m256/m32bcst, imm8")]
    vpcmpud_k1_k2_ymm_m256_imm8 = 2321,
    /// <summary>
    /// vpcmpud k1 {k2}, ymm, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vpcmpud k1 {k2}, ymm, m32bcst, imm8","vpcmpud k1 {k2}, ymm, ymm/m256/m32bcst, imm8")]
    vpcmpud_k1_k2_ymm_m32bcst_imm8 = 2322,
    /// <summary>
    /// vpcmpud k1 {k2}, zmm, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vpcmpud k1 {k2}, zmm, zmm, imm8","vpcmpud k1 {k2}, zmm, zmm/m512/m32bcst, imm8")]
    vpcmpud_k1_k2_zmm_zmm_imm8 = 2323,
    /// <summary>
    /// vpcmpud k1 {k2}, zmm, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vpcmpud k1 {k2}, zmm, m512, imm8","vpcmpud k1 {k2}, zmm, zmm/m512/m32bcst, imm8")]
    vpcmpud_k1_k2_zmm_m512_imm8 = 2324,
    /// <summary>
    /// vpcmpud k1 {k2}, zmm, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vpcmpud k1 {k2}, zmm, m32bcst, imm8","vpcmpud k1 {k2}, zmm, zmm/m512/m32bcst, imm8")]
    vpcmpud_k1_k2_zmm_m32bcst_imm8 = 2325,
    /// <summary>
    /// vpcmpuq k1 {k2}, xmm, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("vpcmpuq k1 {k2}, xmm, xmm, imm8","vpcmpuq k1 {k2}, xmm, xmm/m128/m64bcst, imm8")]
    vpcmpuq_k1_k2_xmm_xmm_imm8 = 2326,
    /// <summary>
    /// vpcmpuq k1 {k2}, xmm, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("vpcmpuq k1 {k2}, xmm, m128, imm8","vpcmpuq k1 {k2}, xmm, xmm/m128/m64bcst, imm8")]
    vpcmpuq_k1_k2_xmm_m128_imm8 = 2327,
    /// <summary>
    /// vpcmpuq k1 {k2}, xmm, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("vpcmpuq k1 {k2}, xmm, m64bcst, imm8","vpcmpuq k1 {k2}, xmm, xmm/m128/m64bcst, imm8")]
    vpcmpuq_k1_k2_xmm_m64bcst_imm8 = 2328,
    /// <summary>
    /// vpcmpuq k1 {k2}, ymm, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vpcmpuq k1 {k2}, ymm, ymm, imm8","vpcmpuq k1 {k2}, ymm, ymm/m256/m64bcst, imm8")]
    vpcmpuq_k1_k2_ymm_ymm_imm8 = 2329,
    /// <summary>
    /// vpcmpuq k1 {k2}, ymm, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vpcmpuq k1 {k2}, ymm, m256, imm8","vpcmpuq k1 {k2}, ymm, ymm/m256/m64bcst, imm8")]
    vpcmpuq_k1_k2_ymm_m256_imm8 = 2330,
    /// <summary>
    /// vpcmpuq k1 {k2}, ymm, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vpcmpuq k1 {k2}, ymm, m64bcst, imm8","vpcmpuq k1 {k2}, ymm, ymm/m256/m64bcst, imm8")]
    vpcmpuq_k1_k2_ymm_m64bcst_imm8 = 2331,
    /// <summary>
    /// vpcmpuq k1 {k2}, zmm, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vpcmpuq k1 {k2}, zmm, zmm, imm8","vpcmpuq k1 {k2}, zmm, zmm/m512/m64bcst, imm8")]
    vpcmpuq_k1_k2_zmm_zmm_imm8 = 2332,
    /// <summary>
    /// vpcmpuq k1 {k2}, zmm, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vpcmpuq k1 {k2}, zmm, m512, imm8","vpcmpuq k1 {k2}, zmm, zmm/m512/m64bcst, imm8")]
    vpcmpuq_k1_k2_zmm_m512_imm8 = 2333,
    /// <summary>
    /// vpcmpuq k1 {k2}, zmm, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vpcmpuq k1 {k2}, zmm, m64bcst, imm8","vpcmpuq k1 {k2}, zmm, zmm/m512/m64bcst, imm8")]
    vpcmpuq_k1_k2_zmm_m64bcst_imm8 = 2334,
    /// <summary>
    /// vpcmpuw k1 {k2}, xmm, xmm/m128, imm8
    /// </summary>
    [Symbol("vpcmpuw k1 {k2}, xmm, xmm, imm8","vpcmpuw k1 {k2}, xmm, xmm/m128, imm8")]
    vpcmpuw_k1_k2_xmm_xmm_imm8 = 2335,
    /// <summary>
    /// vpcmpuw k1 {k2}, xmm, xmm/m128, imm8
    /// </summary>
    [Symbol("vpcmpuw k1 {k2}, xmm, m128, imm8","vpcmpuw k1 {k2}, xmm, xmm/m128, imm8")]
    vpcmpuw_k1_k2_xmm_m128_imm8 = 2336,
    /// <summary>
    /// vpcmpuw k1 {k2}, ymm, ymm/m256, imm8
    /// </summary>
    [Symbol("vpcmpuw k1 {k2}, ymm, ymm, imm8","vpcmpuw k1 {k2}, ymm, ymm/m256, imm8")]
    vpcmpuw_k1_k2_ymm_ymm_imm8 = 2337,
    /// <summary>
    /// vpcmpuw k1 {k2}, ymm, ymm/m256, imm8
    /// </summary>
    [Symbol("vpcmpuw k1 {k2}, ymm, m256, imm8","vpcmpuw k1 {k2}, ymm, ymm/m256, imm8")]
    vpcmpuw_k1_k2_ymm_m256_imm8 = 2338,
    /// <summary>
    /// vpcmpuw k1 {k2}, zmm, zmm/m512, imm8
    /// </summary>
    [Symbol("vpcmpuw k1 {k2}, zmm, zmm, imm8","vpcmpuw k1 {k2}, zmm, zmm/m512, imm8")]
    vpcmpuw_k1_k2_zmm_zmm_imm8 = 2339,
    /// <summary>
    /// vpcmpuw k1 {k2}, zmm, zmm/m512, imm8
    /// </summary>
    [Symbol("vpcmpuw k1 {k2}, zmm, m512, imm8","vpcmpuw k1 {k2}, zmm, zmm/m512, imm8")]
    vpcmpuw_k1_k2_zmm_m512_imm8 = 2340,
    /// <summary>
    /// vpcmpw k1 {k2}, xmm, xmm/m128, imm8
    /// </summary>
    [Symbol("vpcmpw k1 {k2}, xmm, xmm, imm8","vpcmpw k1 {k2}, xmm, xmm/m128, imm8")]
    vpcmpw_k1_k2_xmm_xmm_imm8 = 2341,
    /// <summary>
    /// vpcmpw k1 {k2}, xmm, xmm/m128, imm8
    /// </summary>
    [Symbol("vpcmpw k1 {k2}, xmm, m128, imm8","vpcmpw k1 {k2}, xmm, xmm/m128, imm8")]
    vpcmpw_k1_k2_xmm_m128_imm8 = 2342,
    /// <summary>
    /// vpcmpw k1 {k2}, ymm, ymm/m256, imm8
    /// </summary>
    [Symbol("vpcmpw k1 {k2}, ymm, ymm, imm8","vpcmpw k1 {k2}, ymm, ymm/m256, imm8")]
    vpcmpw_k1_k2_ymm_ymm_imm8 = 2343,
    /// <summary>
    /// vpcmpw k1 {k2}, ymm, ymm/m256, imm8
    /// </summary>
    [Symbol("vpcmpw k1 {k2}, ymm, m256, imm8","vpcmpw k1 {k2}, ymm, ymm/m256, imm8")]
    vpcmpw_k1_k2_ymm_m256_imm8 = 2344,
    /// <summary>
    /// vpcmpw k1 {k2}, zmm, zmm/m512, imm8
    /// </summary>
    [Symbol("vpcmpw k1 {k2}, zmm, zmm, imm8","vpcmpw k1 {k2}, zmm, zmm/m512, imm8")]
    vpcmpw_k1_k2_zmm_zmm_imm8 = 2345,
    /// <summary>
    /// vpcmpw k1 {k2}, zmm, zmm/m512, imm8
    /// </summary>
    [Symbol("vpcmpw k1 {k2}, zmm, m512, imm8","vpcmpw k1 {k2}, zmm, zmm/m512, imm8")]
    vpcmpw_k1_k2_zmm_m512_imm8 = 2346,
    /// <summary>
    /// vpcompressd xmm/m128 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpcompressd xmm {k1}{z}, xmm","vpcompressd xmm/m128 {k1}{z}, xmm")]
    vpcompressd_xmm_k1z_xmm = 2347,
    /// <summary>
    /// vpcompressd xmm/m128 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpcompressd m128 {k1}{z}, xmm","vpcompressd xmm/m128 {k1}{z}, xmm")]
    vpcompressd_m128_k1z_xmm = 2348,
    /// <summary>
    /// vpcompressd ymm/m256 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpcompressd ymm {k1}{z}, ymm","vpcompressd ymm/m256 {k1}{z}, ymm")]
    vpcompressd_ymm_k1z_ymm = 2349,
    /// <summary>
    /// vpcompressd ymm/m256 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpcompressd m256 {k1}{z}, ymm","vpcompressd ymm/m256 {k1}{z}, ymm")]
    vpcompressd_m256_k1z_ymm = 2350,
    /// <summary>
    /// vpcompressd zmm/m512 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpcompressd zmm {k1}{z}, zmm","vpcompressd zmm/m512 {k1}{z}, zmm")]
    vpcompressd_zmm_k1z_zmm = 2351,
    /// <summary>
    /// vpcompressd zmm/m512 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpcompressd m512 {k1}{z}, zmm","vpcompressd zmm/m512 {k1}{z}, zmm")]
    vpcompressd_m512_k1z_zmm = 2352,
    /// <summary>
    /// vpcompressq xmm/m128 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpcompressq xmm {k1}{z}, xmm","vpcompressq xmm/m128 {k1}{z}, xmm")]
    vpcompressq_xmm_k1z_xmm = 2353,
    /// <summary>
    /// vpcompressq xmm/m128 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpcompressq m128 {k1}{z}, xmm","vpcompressq xmm/m128 {k1}{z}, xmm")]
    vpcompressq_m128_k1z_xmm = 2354,
    /// <summary>
    /// vpcompressq ymm/m256 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpcompressq ymm {k1}{z}, ymm","vpcompressq ymm/m256 {k1}{z}, ymm")]
    vpcompressq_ymm_k1z_ymm = 2355,
    /// <summary>
    /// vpcompressq ymm/m256 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpcompressq m256 {k1}{z}, ymm","vpcompressq ymm/m256 {k1}{z}, ymm")]
    vpcompressq_m256_k1z_ymm = 2356,
    /// <summary>
    /// vpcompressq zmm/m512 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpcompressq zmm {k1}{z}, zmm","vpcompressq zmm/m512 {k1}{z}, zmm")]
    vpcompressq_zmm_k1z_zmm = 2357,
    /// <summary>
    /// vpcompressq zmm/m512 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpcompressq m512 {k1}{z}, zmm","vpcompressq zmm/m512 {k1}{z}, zmm")]
    vpcompressq_m512_k1z_zmm = 2358,
    /// <summary>
    /// vpconflictd xmm {k1}{z}, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpconflictd xmm {k1}{z}, xmm","vpconflictd xmm {k1}{z}, xmm/m128/m32bcst")]
    vpconflictd_xmm_k1z_xmm = 2359,
    /// <summary>
    /// vpconflictd xmm {k1}{z}, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpconflictd xmm {k1}{z}, m128","vpconflictd xmm {k1}{z}, xmm/m128/m32bcst")]
    vpconflictd_xmm_k1z_m128 = 2360,
    /// <summary>
    /// vpconflictd xmm {k1}{z}, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpconflictd xmm {k1}{z}, m32bcst","vpconflictd xmm {k1}{z}, xmm/m128/m32bcst")]
    vpconflictd_xmm_k1z_m32bcst = 2361,
    /// <summary>
    /// vpconflictd ymm {k1}{z}, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpconflictd ymm {k1}{z}, ymm","vpconflictd ymm {k1}{z}, ymm/m256/m32bcst")]
    vpconflictd_ymm_k1z_ymm = 2362,
    /// <summary>
    /// vpconflictd ymm {k1}{z}, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpconflictd ymm {k1}{z}, m256","vpconflictd ymm {k1}{z}, ymm/m256/m32bcst")]
    vpconflictd_ymm_k1z_m256 = 2363,
    /// <summary>
    /// vpconflictd ymm {k1}{z}, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpconflictd ymm {k1}{z}, m32bcst","vpconflictd ymm {k1}{z}, ymm/m256/m32bcst")]
    vpconflictd_ymm_k1z_m32bcst = 2364,
    /// <summary>
    /// vpconflictd zmm {k1}{z}, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpconflictd zmm {k1}{z}, zmm","vpconflictd zmm {k1}{z}, zmm/m512/m32bcst")]
    vpconflictd_zmm_k1z_zmm = 2365,
    /// <summary>
    /// vpconflictd zmm {k1}{z}, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpconflictd zmm {k1}{z}, m512","vpconflictd zmm {k1}{z}, zmm/m512/m32bcst")]
    vpconflictd_zmm_k1z_m512 = 2366,
    /// <summary>
    /// vpconflictd zmm {k1}{z}, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpconflictd zmm {k1}{z}, m32bcst","vpconflictd zmm {k1}{z}, zmm/m512/m32bcst")]
    vpconflictd_zmm_k1z_m32bcst = 2367,
    /// <summary>
    /// vpconflictq xmm {k1}{z}, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpconflictq xmm {k1}{z}, xmm","vpconflictq xmm {k1}{z}, xmm/m128/m64bcst")]
    vpconflictq_xmm_k1z_xmm = 2368,
    /// <summary>
    /// vpconflictq xmm {k1}{z}, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpconflictq xmm {k1}{z}, m128","vpconflictq xmm {k1}{z}, xmm/m128/m64bcst")]
    vpconflictq_xmm_k1z_m128 = 2369,
    /// <summary>
    /// vpconflictq xmm {k1}{z}, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpconflictq xmm {k1}{z}, m64bcst","vpconflictq xmm {k1}{z}, xmm/m128/m64bcst")]
    vpconflictq_xmm_k1z_m64bcst = 2370,
    /// <summary>
    /// vpconflictq ymm {k1}{z}, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpconflictq ymm {k1}{z}, ymm","vpconflictq ymm {k1}{z}, ymm/m256/m64bcst")]
    vpconflictq_ymm_k1z_ymm = 2371,
    /// <summary>
    /// vpconflictq ymm {k1}{z}, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpconflictq ymm {k1}{z}, m256","vpconflictq ymm {k1}{z}, ymm/m256/m64bcst")]
    vpconflictq_ymm_k1z_m256 = 2372,
    /// <summary>
    /// vpconflictq ymm {k1}{z}, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpconflictq ymm {k1}{z}, m64bcst","vpconflictq ymm {k1}{z}, ymm/m256/m64bcst")]
    vpconflictq_ymm_k1z_m64bcst = 2373,
    /// <summary>
    /// vpconflictq zmm {k1}{z}, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpconflictq zmm {k1}{z}, zmm","vpconflictq zmm {k1}{z}, zmm/m512/m64bcst")]
    vpconflictq_zmm_k1z_zmm = 2374,
    /// <summary>
    /// vpconflictq zmm {k1}{z}, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpconflictq zmm {k1}{z}, m512","vpconflictq zmm {k1}{z}, zmm/m512/m64bcst")]
    vpconflictq_zmm_k1z_m512 = 2375,
    /// <summary>
    /// vpconflictq zmm {k1}{z}, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpconflictq zmm {k1}{z}, m64bcst","vpconflictq zmm {k1}{z}, zmm/m512/m64bcst")]
    vpconflictq_zmm_k1z_m64bcst = 2376,
    /// <summary>
    /// vperm2i128 ymm, ymm, ymm/m256, imm8
    /// </summary>
    [Symbol("vperm2i128 ymm, ymm, ymm, imm8","vperm2i128 ymm, ymm, ymm/m256, imm8")]
    vperm2i128_ymm_ymm_ymm_imm8 = 2377,
    /// <summary>
    /// vperm2i128 ymm, ymm, ymm/m256, imm8
    /// </summary>
    [Symbol("vperm2i128 ymm, ymm, m256, imm8","vperm2i128 ymm, ymm, ymm/m256, imm8")]
    vperm2i128_ymm_ymm_m256_imm8 = 2378,
    /// <summary>
    /// vpermb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpermb xmm {k1}{z}, xmm, xmm","vpermb xmm {k1}{z}, xmm, xmm/m128")]
    vpermb_xmm_k1z_xmm_xmm = 2379,
    /// <summary>
    /// vpermb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpermb xmm {k1}{z}, xmm, m128","vpermb xmm {k1}{z}, xmm, xmm/m128")]
    vpermb_xmm_k1z_xmm_m128 = 2380,
    /// <summary>
    /// vpermb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpermb ymm {k1}{z}, ymm, ymm","vpermb ymm {k1}{z}, ymm, ymm/m256")]
    vpermb_ymm_k1z_ymm_ymm = 2381,
    /// <summary>
    /// vpermb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpermb ymm {k1}{z}, ymm, m256","vpermb ymm {k1}{z}, ymm, ymm/m256")]
    vpermb_ymm_k1z_ymm_m256 = 2382,
    /// <summary>
    /// vpermb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpermb zmm {k1}{z}, zmm, zmm","vpermb zmm {k1}{z}, zmm, zmm/m512")]
    vpermb_zmm_k1z_zmm_zmm = 2383,
    /// <summary>
    /// vpermb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpermb zmm {k1}{z}, zmm, m512","vpermb zmm {k1}{z}, zmm, zmm/m512")]
    vpermb_zmm_k1z_zmm_m512 = 2384,
    /// <summary>
    /// vpermd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpermd ymm {k1}{z}, ymm, ymm","vpermd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpermd_ymm_k1z_ymm_ymm = 2385,
    /// <summary>
    /// vpermd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpermd ymm {k1}{z}, ymm, m256","vpermd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpermd_ymm_k1z_ymm_m256 = 2386,
    /// <summary>
    /// vpermd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpermd ymm {k1}{z}, ymm, m32bcst","vpermd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpermd_ymm_k1z_ymm_m32bcst = 2387,
    /// <summary>
    /// vpermd ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpermd ymm, ymm, ymm","vpermd ymm, ymm, ymm/m256")]
    vpermd_ymm_ymm_ymm = 2388,
    /// <summary>
    /// vpermd ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpermd ymm, ymm, m256","vpermd ymm, ymm, ymm/m256")]
    vpermd_ymm_ymm_m256 = 2389,
    /// <summary>
    /// vpermd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpermd zmm {k1}{z}, zmm, zmm","vpermd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpermd_zmm_k1z_zmm_zmm = 2390,
    /// <summary>
    /// vpermd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpermd zmm {k1}{z}, zmm, m512","vpermd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpermd_zmm_k1z_zmm_m512 = 2391,
    /// <summary>
    /// vpermd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpermd zmm {k1}{z}, zmm, m32bcst","vpermd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpermd_zmm_k1z_zmm_m32bcst = 2392,
    /// <summary>
    /// vpermi2d xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpermi2d xmm {k1}{z}, xmm, xmm","vpermi2d xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpermi2d_xmm_k1z_xmm_xmm = 2393,
    /// <summary>
    /// vpermi2d xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpermi2d xmm {k1}{z}, xmm, m128","vpermi2d xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpermi2d_xmm_k1z_xmm_m128 = 2394,
    /// <summary>
    /// vpermi2d xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpermi2d xmm {k1}{z}, xmm, m32bcst","vpermi2d xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpermi2d_xmm_k1z_xmm_m32bcst = 2395,
    /// <summary>
    /// vpermi2d ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpermi2d ymm {k1}{z}, ymm, ymm","vpermi2d ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpermi2d_ymm_k1z_ymm_ymm = 2396,
    /// <summary>
    /// vpermi2d ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpermi2d ymm {k1}{z}, ymm, m256","vpermi2d ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpermi2d_ymm_k1z_ymm_m256 = 2397,
    /// <summary>
    /// vpermi2d ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpermi2d ymm {k1}{z}, ymm, m32bcst","vpermi2d ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpermi2d_ymm_k1z_ymm_m32bcst = 2398,
    /// <summary>
    /// vpermi2d zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpermi2d zmm {k1}{z}, zmm, zmm","vpermi2d zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpermi2d_zmm_k1z_zmm_zmm = 2399,
    /// <summary>
    /// vpermi2d zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpermi2d zmm {k1}{z}, zmm, m512","vpermi2d zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpermi2d_zmm_k1z_zmm_m512 = 2400,
    /// <summary>
    /// vpermi2d zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpermi2d zmm {k1}{z}, zmm, m32bcst","vpermi2d zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpermi2d_zmm_k1z_zmm_m32bcst = 2401,
    /// <summary>
    /// vpermi2pd xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpermi2pd xmm {k1}{z}, xmm, xmm","vpermi2pd xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpermi2pd_xmm_k1z_xmm_xmm = 2402,
    /// <summary>
    /// vpermi2pd xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpermi2pd xmm {k1}{z}, xmm, m128","vpermi2pd xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpermi2pd_xmm_k1z_xmm_m128 = 2403,
    /// <summary>
    /// vpermi2pd xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpermi2pd xmm {k1}{z}, xmm, m64bcst","vpermi2pd xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpermi2pd_xmm_k1z_xmm_m64bcst = 2404,
    /// <summary>
    /// vpermi2pd ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpermi2pd ymm {k1}{z}, ymm, ymm","vpermi2pd ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpermi2pd_ymm_k1z_ymm_ymm = 2405,
    /// <summary>
    /// vpermi2pd ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpermi2pd ymm {k1}{z}, ymm, m256","vpermi2pd ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpermi2pd_ymm_k1z_ymm_m256 = 2406,
    /// <summary>
    /// vpermi2pd ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpermi2pd ymm {k1}{z}, ymm, m64bcst","vpermi2pd ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpermi2pd_ymm_k1z_ymm_m64bcst = 2407,
    /// <summary>
    /// vpermi2pd zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpermi2pd zmm {k1}{z}, zmm, zmm","vpermi2pd zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpermi2pd_zmm_k1z_zmm_zmm = 2408,
    /// <summary>
    /// vpermi2pd zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpermi2pd zmm {k1}{z}, zmm, m512","vpermi2pd zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpermi2pd_zmm_k1z_zmm_m512 = 2409,
    /// <summary>
    /// vpermi2pd zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpermi2pd zmm {k1}{z}, zmm, m64bcst","vpermi2pd zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpermi2pd_zmm_k1z_zmm_m64bcst = 2410,
    /// <summary>
    /// vpermi2ps xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpermi2ps xmm {k1}{z}, xmm, xmm","vpermi2ps xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpermi2ps_xmm_k1z_xmm_xmm = 2411,
    /// <summary>
    /// vpermi2ps xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpermi2ps xmm {k1}{z}, xmm, m128","vpermi2ps xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpermi2ps_xmm_k1z_xmm_m128 = 2412,
    /// <summary>
    /// vpermi2ps xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpermi2ps xmm {k1}{z}, xmm, m32bcst","vpermi2ps xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpermi2ps_xmm_k1z_xmm_m32bcst = 2413,
    /// <summary>
    /// vpermi2ps ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpermi2ps ymm {k1}{z}, ymm, ymm","vpermi2ps ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpermi2ps_ymm_k1z_ymm_ymm = 2414,
    /// <summary>
    /// vpermi2ps ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpermi2ps ymm {k1}{z}, ymm, m256","vpermi2ps ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpermi2ps_ymm_k1z_ymm_m256 = 2415,
    /// <summary>
    /// vpermi2ps ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpermi2ps ymm {k1}{z}, ymm, m32bcst","vpermi2ps ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpermi2ps_ymm_k1z_ymm_m32bcst = 2416,
    /// <summary>
    /// vpermi2ps zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpermi2ps zmm {k1}{z}, zmm, zmm","vpermi2ps zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpermi2ps_zmm_k1z_zmm_zmm = 2417,
    /// <summary>
    /// vpermi2ps zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpermi2ps zmm {k1}{z}, zmm, m512","vpermi2ps zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpermi2ps_zmm_k1z_zmm_m512 = 2418,
    /// <summary>
    /// vpermi2ps zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpermi2ps zmm {k1}{z}, zmm, m32bcst","vpermi2ps zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpermi2ps_zmm_k1z_zmm_m32bcst = 2419,
    /// <summary>
    /// vpermi2q xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpermi2q xmm {k1}{z}, xmm, xmm","vpermi2q xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpermi2q_xmm_k1z_xmm_xmm = 2420,
    /// <summary>
    /// vpermi2q xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpermi2q xmm {k1}{z}, xmm, m128","vpermi2q xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpermi2q_xmm_k1z_xmm_m128 = 2421,
    /// <summary>
    /// vpermi2q xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpermi2q xmm {k1}{z}, xmm, m64bcst","vpermi2q xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpermi2q_xmm_k1z_xmm_m64bcst = 2422,
    /// <summary>
    /// vpermi2q ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpermi2q ymm {k1}{z}, ymm, ymm","vpermi2q ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpermi2q_ymm_k1z_ymm_ymm = 2423,
    /// <summary>
    /// vpermi2q ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpermi2q ymm {k1}{z}, ymm, m256","vpermi2q ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpermi2q_ymm_k1z_ymm_m256 = 2424,
    /// <summary>
    /// vpermi2q ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpermi2q ymm {k1}{z}, ymm, m64bcst","vpermi2q ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpermi2q_ymm_k1z_ymm_m64bcst = 2425,
    /// <summary>
    /// vpermi2q zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpermi2q zmm {k1}{z}, zmm, zmm","vpermi2q zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpermi2q_zmm_k1z_zmm_zmm = 2426,
    /// <summary>
    /// vpermi2q zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpermi2q zmm {k1}{z}, zmm, m512","vpermi2q zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpermi2q_zmm_k1z_zmm_m512 = 2427,
    /// <summary>
    /// vpermi2q zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpermi2q zmm {k1}{z}, zmm, m64bcst","vpermi2q zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpermi2q_zmm_k1z_zmm_m64bcst = 2428,
    /// <summary>
    /// vpermi2w xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpermi2w xmm {k1}{z}, xmm, xmm","vpermi2w xmm {k1}{z}, xmm, xmm/m128")]
    vpermi2w_xmm_k1z_xmm_xmm = 2429,
    /// <summary>
    /// vpermi2w xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpermi2w xmm {k1}{z}, xmm, m128","vpermi2w xmm {k1}{z}, xmm, xmm/m128")]
    vpermi2w_xmm_k1z_xmm_m128 = 2430,
    /// <summary>
    /// vpermi2w ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpermi2w ymm {k1}{z}, ymm, ymm","vpermi2w ymm {k1}{z}, ymm, ymm/m256")]
    vpermi2w_ymm_k1z_ymm_ymm = 2431,
    /// <summary>
    /// vpermi2w ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpermi2w ymm {k1}{z}, ymm, m256","vpermi2w ymm {k1}{z}, ymm, ymm/m256")]
    vpermi2w_ymm_k1z_ymm_m256 = 2432,
    /// <summary>
    /// vpermi2w zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpermi2w zmm {k1}{z}, zmm, zmm","vpermi2w zmm {k1}{z}, zmm, zmm/m512")]
    vpermi2w_zmm_k1z_zmm_zmm = 2433,
    /// <summary>
    /// vpermi2w zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpermi2w zmm {k1}{z}, zmm, m512","vpermi2w zmm {k1}{z}, zmm, zmm/m512")]
    vpermi2w_zmm_k1z_zmm_m512 = 2434,
    /// <summary>
    /// vpermq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpermq ymm {k1}{z}, ymm, ymm","vpermq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpermq_ymm_k1z_ymm_ymm = 2435,
    /// <summary>
    /// vpermq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpermq ymm {k1}{z}, ymm, m256","vpermq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpermq_ymm_k1z_ymm_m256 = 2436,
    /// <summary>
    /// vpermq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpermq ymm {k1}{z}, ymm, m64bcst","vpermq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpermq_ymm_k1z_ymm_m64bcst = 2437,
    /// <summary>
    /// vpermq ymm {k1}{z}, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vpermq ymm {k1}{z}, ymm, imm8","vpermq ymm {k1}{z}, ymm/m256/m64bcst, imm8")]
    vpermq_ymm_k1z_ymm_imm8 = 2438,
    /// <summary>
    /// vpermq ymm {k1}{z}, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vpermq ymm {k1}{z}, m256, imm8","vpermq ymm {k1}{z}, ymm/m256/m64bcst, imm8")]
    vpermq_ymm_k1z_m256_imm8 = 2439,
    /// <summary>
    /// vpermq ymm {k1}{z}, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vpermq ymm {k1}{z}, m64bcst, imm8","vpermq ymm {k1}{z}, ymm/m256/m64bcst, imm8")]
    vpermq_ymm_k1z_m64bcst_imm8 = 2440,
    /// <summary>
    /// vpermq ymm, ymm/m256, imm8
    /// </summary>
    [Symbol("vpermq ymm, ymm, imm8","vpermq ymm, ymm/m256, imm8")]
    vpermq_ymm_ymm_imm8 = 2441,
    /// <summary>
    /// vpermq ymm, ymm/m256, imm8
    /// </summary>
    [Symbol("vpermq ymm, m256, imm8","vpermq ymm, ymm/m256, imm8")]
    vpermq_ymm_m256_imm8 = 2442,
    /// <summary>
    /// vpermq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpermq zmm {k1}{z}, zmm, zmm","vpermq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpermq_zmm_k1z_zmm_zmm = 2443,
    /// <summary>
    /// vpermq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpermq zmm {k1}{z}, zmm, m512","vpermq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpermq_zmm_k1z_zmm_m512 = 2444,
    /// <summary>
    /// vpermq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpermq zmm {k1}{z}, zmm, m64bcst","vpermq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpermq_zmm_k1z_zmm_m64bcst = 2445,
    /// <summary>
    /// vpermq zmm {k1}{z}, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vpermq zmm {k1}{z}, zmm, imm8","vpermq zmm {k1}{z}, zmm/m512/m64bcst, imm8")]
    vpermq_zmm_k1z_zmm_imm8 = 2446,
    /// <summary>
    /// vpermq zmm {k1}{z}, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vpermq zmm {k1}{z}, m512, imm8","vpermq zmm {k1}{z}, zmm/m512/m64bcst, imm8")]
    vpermq_zmm_k1z_m512_imm8 = 2447,
    /// <summary>
    /// vpermq zmm {k1}{z}, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vpermq zmm {k1}{z}, m64bcst, imm8","vpermq zmm {k1}{z}, zmm/m512/m64bcst, imm8")]
    vpermq_zmm_k1z_m64bcst_imm8 = 2448,
    /// <summary>
    /// vpermt2b xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpermt2b xmm {k1}{z}, xmm, xmm","vpermt2b xmm {k1}{z}, xmm, xmm/m128")]
    vpermt2b_xmm_k1z_xmm_xmm = 2449,
    /// <summary>
    /// vpermt2b xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpermt2b xmm {k1}{z}, xmm, m128","vpermt2b xmm {k1}{z}, xmm, xmm/m128")]
    vpermt2b_xmm_k1z_xmm_m128 = 2450,
    /// <summary>
    /// vpermt2b ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpermt2b ymm {k1}{z}, ymm, ymm","vpermt2b ymm {k1}{z}, ymm, ymm/m256")]
    vpermt2b_ymm_k1z_ymm_ymm = 2451,
    /// <summary>
    /// vpermt2b ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpermt2b ymm {k1}{z}, ymm, m256","vpermt2b ymm {k1}{z}, ymm, ymm/m256")]
    vpermt2b_ymm_k1z_ymm_m256 = 2452,
    /// <summary>
    /// vpermt2b zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpermt2b zmm {k1}{z}, zmm, zmm","vpermt2b zmm {k1}{z}, zmm, zmm/m512")]
    vpermt2b_zmm_k1z_zmm_zmm = 2453,
    /// <summary>
    /// vpermt2b zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpermt2b zmm {k1}{z}, zmm, m512","vpermt2b zmm {k1}{z}, zmm, zmm/m512")]
    vpermt2b_zmm_k1z_zmm_m512 = 2454,
    /// <summary>
    /// vpermt2d xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpermt2d xmm {k1}{z}, xmm, xmm","vpermt2d xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpermt2d_xmm_k1z_xmm_xmm = 2455,
    /// <summary>
    /// vpermt2d xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpermt2d xmm {k1}{z}, xmm, m128","vpermt2d xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpermt2d_xmm_k1z_xmm_m128 = 2456,
    /// <summary>
    /// vpermt2d xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpermt2d xmm {k1}{z}, xmm, m32bcst","vpermt2d xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpermt2d_xmm_k1z_xmm_m32bcst = 2457,
    /// <summary>
    /// vpermt2d ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpermt2d ymm {k1}{z}, ymm, ymm","vpermt2d ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpermt2d_ymm_k1z_ymm_ymm = 2458,
    /// <summary>
    /// vpermt2d ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpermt2d ymm {k1}{z}, ymm, m256","vpermt2d ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpermt2d_ymm_k1z_ymm_m256 = 2459,
    /// <summary>
    /// vpermt2d ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpermt2d ymm {k1}{z}, ymm, m32bcst","vpermt2d ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpermt2d_ymm_k1z_ymm_m32bcst = 2460,
    /// <summary>
    /// vpermt2d zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpermt2d zmm {k1}{z}, zmm, zmm","vpermt2d zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpermt2d_zmm_k1z_zmm_zmm = 2461,
    /// <summary>
    /// vpermt2d zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpermt2d zmm {k1}{z}, zmm, m512","vpermt2d zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpermt2d_zmm_k1z_zmm_m512 = 2462,
    /// <summary>
    /// vpermt2d zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpermt2d zmm {k1}{z}, zmm, m32bcst","vpermt2d zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpermt2d_zmm_k1z_zmm_m32bcst = 2463,
    /// <summary>
    /// vpermt2pd xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpermt2pd xmm {k1}{z}, xmm, xmm","vpermt2pd xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpermt2pd_xmm_k1z_xmm_xmm = 2464,
    /// <summary>
    /// vpermt2pd xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpermt2pd xmm {k1}{z}, xmm, m128","vpermt2pd xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpermt2pd_xmm_k1z_xmm_m128 = 2465,
    /// <summary>
    /// vpermt2pd xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpermt2pd xmm {k1}{z}, xmm, m64bcst","vpermt2pd xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpermt2pd_xmm_k1z_xmm_m64bcst = 2466,
    /// <summary>
    /// vpermt2pd ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpermt2pd ymm {k1}{z}, ymm, ymm","vpermt2pd ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpermt2pd_ymm_k1z_ymm_ymm = 2467,
    /// <summary>
    /// vpermt2pd ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpermt2pd ymm {k1}{z}, ymm, m256","vpermt2pd ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpermt2pd_ymm_k1z_ymm_m256 = 2468,
    /// <summary>
    /// vpermt2pd ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpermt2pd ymm {k1}{z}, ymm, m64bcst","vpermt2pd ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpermt2pd_ymm_k1z_ymm_m64bcst = 2469,
    /// <summary>
    /// vpermt2pd zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpermt2pd zmm {k1}{z}, zmm, zmm","vpermt2pd zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpermt2pd_zmm_k1z_zmm_zmm = 2470,
    /// <summary>
    /// vpermt2pd zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpermt2pd zmm {k1}{z}, zmm, m512","vpermt2pd zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpermt2pd_zmm_k1z_zmm_m512 = 2471,
    /// <summary>
    /// vpermt2pd zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpermt2pd zmm {k1}{z}, zmm, m64bcst","vpermt2pd zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpermt2pd_zmm_k1z_zmm_m64bcst = 2472,
    /// <summary>
    /// vpermt2ps xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpermt2ps xmm {k1}{z}, xmm, xmm","vpermt2ps xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpermt2ps_xmm_k1z_xmm_xmm = 2473,
    /// <summary>
    /// vpermt2ps xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpermt2ps xmm {k1}{z}, xmm, m128","vpermt2ps xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpermt2ps_xmm_k1z_xmm_m128 = 2474,
    /// <summary>
    /// vpermt2ps xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpermt2ps xmm {k1}{z}, xmm, m32bcst","vpermt2ps xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpermt2ps_xmm_k1z_xmm_m32bcst = 2475,
    /// <summary>
    /// vpermt2ps ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpermt2ps ymm {k1}{z}, ymm, ymm","vpermt2ps ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpermt2ps_ymm_k1z_ymm_ymm = 2476,
    /// <summary>
    /// vpermt2ps ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpermt2ps ymm {k1}{z}, ymm, m256","vpermt2ps ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpermt2ps_ymm_k1z_ymm_m256 = 2477,
    /// <summary>
    /// vpermt2ps ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpermt2ps ymm {k1}{z}, ymm, m32bcst","vpermt2ps ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpermt2ps_ymm_k1z_ymm_m32bcst = 2478,
    /// <summary>
    /// vpermt2ps zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpermt2ps zmm {k1}{z}, zmm, zmm","vpermt2ps zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpermt2ps_zmm_k1z_zmm_zmm = 2479,
    /// <summary>
    /// vpermt2ps zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpermt2ps zmm {k1}{z}, zmm, m512","vpermt2ps zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpermt2ps_zmm_k1z_zmm_m512 = 2480,
    /// <summary>
    /// vpermt2ps zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpermt2ps zmm {k1}{z}, zmm, m32bcst","vpermt2ps zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpermt2ps_zmm_k1z_zmm_m32bcst = 2481,
    /// <summary>
    /// vpermt2q xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpermt2q xmm {k1}{z}, xmm, xmm","vpermt2q xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpermt2q_xmm_k1z_xmm_xmm = 2482,
    /// <summary>
    /// vpermt2q xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpermt2q xmm {k1}{z}, xmm, m128","vpermt2q xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpermt2q_xmm_k1z_xmm_m128 = 2483,
    /// <summary>
    /// vpermt2q xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpermt2q xmm {k1}{z}, xmm, m64bcst","vpermt2q xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpermt2q_xmm_k1z_xmm_m64bcst = 2484,
    /// <summary>
    /// vpermt2q ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpermt2q ymm {k1}{z}, ymm, ymm","vpermt2q ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpermt2q_ymm_k1z_ymm_ymm = 2485,
    /// <summary>
    /// vpermt2q ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpermt2q ymm {k1}{z}, ymm, m256","vpermt2q ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpermt2q_ymm_k1z_ymm_m256 = 2486,
    /// <summary>
    /// vpermt2q ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpermt2q ymm {k1}{z}, ymm, m64bcst","vpermt2q ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpermt2q_ymm_k1z_ymm_m64bcst = 2487,
    /// <summary>
    /// vpermt2q zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpermt2q zmm {k1}{z}, zmm, zmm","vpermt2q zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpermt2q_zmm_k1z_zmm_zmm = 2488,
    /// <summary>
    /// vpermt2q zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpermt2q zmm {k1}{z}, zmm, m512","vpermt2q zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpermt2q_zmm_k1z_zmm_m512 = 2489,
    /// <summary>
    /// vpermt2q zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpermt2q zmm {k1}{z}, zmm, m64bcst","vpermt2q zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpermt2q_zmm_k1z_zmm_m64bcst = 2490,
    /// <summary>
    /// vpermt2w xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpermt2w xmm {k1}{z}, xmm, xmm","vpermt2w xmm {k1}{z}, xmm, xmm/m128")]
    vpermt2w_xmm_k1z_xmm_xmm = 2491,
    /// <summary>
    /// vpermt2w xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpermt2w xmm {k1}{z}, xmm, m128","vpermt2w xmm {k1}{z}, xmm, xmm/m128")]
    vpermt2w_xmm_k1z_xmm_m128 = 2492,
    /// <summary>
    /// vpermt2w ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpermt2w ymm {k1}{z}, ymm, ymm","vpermt2w ymm {k1}{z}, ymm, ymm/m256")]
    vpermt2w_ymm_k1z_ymm_ymm = 2493,
    /// <summary>
    /// vpermt2w ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpermt2w ymm {k1}{z}, ymm, m256","vpermt2w ymm {k1}{z}, ymm, ymm/m256")]
    vpermt2w_ymm_k1z_ymm_m256 = 2494,
    /// <summary>
    /// vpermt2w zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpermt2w zmm {k1}{z}, zmm, zmm","vpermt2w zmm {k1}{z}, zmm, zmm/m512")]
    vpermt2w_zmm_k1z_zmm_zmm = 2495,
    /// <summary>
    /// vpermt2w zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpermt2w zmm {k1}{z}, zmm, m512","vpermt2w zmm {k1}{z}, zmm, zmm/m512")]
    vpermt2w_zmm_k1z_zmm_m512 = 2496,
    /// <summary>
    /// vpermw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpermw xmm {k1}{z}, xmm, xmm","vpermw xmm {k1}{z}, xmm, xmm/m128")]
    vpermw_xmm_k1z_xmm_xmm = 2497,
    /// <summary>
    /// vpermw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpermw xmm {k1}{z}, xmm, m128","vpermw xmm {k1}{z}, xmm, xmm/m128")]
    vpermw_xmm_k1z_xmm_m128 = 2498,
    /// <summary>
    /// vpermw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpermw ymm {k1}{z}, ymm, ymm","vpermw ymm {k1}{z}, ymm, ymm/m256")]
    vpermw_ymm_k1z_ymm_ymm = 2499,
    /// <summary>
    /// vpermw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpermw ymm {k1}{z}, ymm, m256","vpermw ymm {k1}{z}, ymm, ymm/m256")]
    vpermw_ymm_k1z_ymm_m256 = 2500,
    /// <summary>
    /// vpermw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpermw zmm {k1}{z}, zmm, zmm","vpermw zmm {k1}{z}, zmm, zmm/m512")]
    vpermw_zmm_k1z_zmm_zmm = 2501,
    /// <summary>
    /// vpermw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpermw zmm {k1}{z}, zmm, m512","vpermw zmm {k1}{z}, zmm, zmm/m512")]
    vpermw_zmm_k1z_zmm_m512 = 2502,
    /// <summary>
    /// vpextrb reg/m8, xmm, imm8
    /// </summary>
    [Symbol("vpextrb reg, xmm, imm8","vpextrb reg/m8, xmm, imm8")]
    vpextrb_reg_xmm_imm8 = 2503,
    /// <summary>
    /// vpextrb reg/m8, xmm, imm8
    /// </summary>
    [Symbol("vpextrb m8, xmm, imm8","vpextrb reg/m8, xmm, imm8")]
    vpextrb_m8_xmm_imm8 = 2504,
    /// <summary>
    /// vpextrd r32/m32, xmm, imm8
    /// </summary>
    [Symbol("vpextrd r32, xmm, imm8","vpextrd r32/m32, xmm, imm8")]
    vpextrd_r32_xmm_imm8 = 2505,
    /// <summary>
    /// vpextrd r32/m32, xmm, imm8
    /// </summary>
    [Symbol("vpextrd m32, xmm, imm8","vpextrd r32/m32, xmm, imm8")]
    vpextrd_m32_xmm_imm8 = 2506,
    /// <summary>
    /// vpextrq r64/m64, xmm, imm8
    /// </summary>
    [Symbol("vpextrq r64, xmm, imm8","vpextrq r64/m64, xmm, imm8")]
    vpextrq_r64_xmm_imm8 = 2507,
    /// <summary>
    /// vpextrq r64/m64, xmm, imm8
    /// </summary>
    [Symbol("vpextrq m64, xmm, imm8","vpextrq r64/m64, xmm, imm8")]
    vpextrq_m64_xmm_imm8 = 2508,
    /// <summary>
    /// vpextrw reg, xmm, imm8
    /// </summary>
    [Symbol("vpextrw reg, xmm, imm8","vpextrw reg, xmm, imm8")]
    vpextrw_reg_xmm_imm8 = 2509,
    /// <summary>
    /// vpextrw reg/m16, xmm, imm8
    /// </summary>
    [Symbol("vpextrw m16, xmm, imm8","vpextrw reg/m16, xmm, imm8")]
    vpextrw_m16_xmm_imm8 = 2510,
    /// <summary>
    /// vpgatherdd xmm {k1}, vm32x
    /// </summary>
    [Symbol("vpgatherdd xmm {k1}, vm32x","vpgatherdd xmm {k1}, vm32x")]
    vpgatherdd_xmm_k1_vm32x = 2511,
    /// <summary>
    /// vpgatherdd xmm, vm32x, xmm
    /// </summary>
    [Symbol("vpgatherdd xmm, vm32x, xmm","vpgatherdd xmm, vm32x, xmm")]
    vpgatherdd_xmm_vm32x_xmm = 2512,
    /// <summary>
    /// vpgatherdd ymm {k1}, vm32y
    /// </summary>
    [Symbol("vpgatherdd ymm {k1}, vm32y","vpgatherdd ymm {k1}, vm32y")]
    vpgatherdd_ymm_k1_vm32y = 2513,
    /// <summary>
    /// vpgatherdd ymm, vm32y, ymm
    /// </summary>
    [Symbol("vpgatherdd ymm, vm32y, ymm","vpgatherdd ymm, vm32y, ymm")]
    vpgatherdd_ymm_vm32y_ymm = 2514,
    /// <summary>
    /// vpgatherdd zmm {k1}, vm32z
    /// </summary>
    [Symbol("vpgatherdd zmm {k1}, vm32z","vpgatherdd zmm {k1}, vm32z")]
    vpgatherdd_zmm_k1_vm32z = 2515,
    /// <summary>
    /// vpgatherdq xmm {k1}, vm32x
    /// </summary>
    [Symbol("vpgatherdq xmm {k1}, vm32x","vpgatherdq xmm {k1}, vm32x")]
    vpgatherdq_xmm_k1_vm32x = 2516,
    /// <summary>
    /// vpgatherdq xmm, vm32x, xmm
    /// </summary>
    [Symbol("vpgatherdq xmm, vm32x, xmm","vpgatherdq xmm, vm32x, xmm")]
    vpgatherdq_xmm_vm32x_xmm = 2517,
    /// <summary>
    /// vpgatherdq ymm {k1}, vm32x
    /// </summary>
    [Symbol("vpgatherdq ymm {k1}, vm32x","vpgatherdq ymm {k1}, vm32x")]
    vpgatherdq_ymm_k1_vm32x = 2518,
    /// <summary>
    /// vpgatherdq ymm, vm32x, ymm
    /// </summary>
    [Symbol("vpgatherdq ymm, vm32x, ymm","vpgatherdq ymm, vm32x, ymm")]
    vpgatherdq_ymm_vm32x_ymm = 2519,
    /// <summary>
    /// vpgatherdq zmm {k1}, vm32y
    /// </summary>
    [Symbol("vpgatherdq zmm {k1}, vm32y","vpgatherdq zmm {k1}, vm32y")]
    vpgatherdq_zmm_k1_vm32y = 2520,
    /// <summary>
    /// vpgatherqd xmm {k1}, vm64x
    /// </summary>
    [Symbol("vpgatherqd xmm {k1}, vm64x","vpgatherqd xmm {k1}, vm64x")]
    vpgatherqd_xmm_k1_vm64x = 2521,
    /// <summary>
    /// vpgatherqd xmm {k1}, vm64y
    /// </summary>
    [Symbol("vpgatherqd xmm {k1}, vm64y","vpgatherqd xmm {k1}, vm64y")]
    vpgatherqd_xmm_k1_vm64y = 2522,
    /// <summary>
    /// vpgatherqd xmm, vm64x, xmm
    /// </summary>
    [Symbol("vpgatherqd xmm, vm64x, xmm","vpgatherqd xmm, vm64x, xmm")]
    vpgatherqd_xmm_vm64x_xmm = 2523,
    /// <summary>
    /// vpgatherqd xmm, vm64y, xmm
    /// </summary>
    [Symbol("vpgatherqd xmm, vm64y, xmm","vpgatherqd xmm, vm64y, xmm")]
    vpgatherqd_xmm_vm64y_xmm = 2524,
    /// <summary>
    /// vpgatherqd ymm {k1}, vm64z
    /// </summary>
    [Symbol("vpgatherqd ymm {k1}, vm64z","vpgatherqd ymm {k1}, vm64z")]
    vpgatherqd_ymm_k1_vm64z = 2525,
    /// <summary>
    /// vpgatherqq xmm {k1}, vm64x
    /// </summary>
    [Symbol("vpgatherqq xmm {k1}, vm64x","vpgatherqq xmm {k1}, vm64x")]
    vpgatherqq_xmm_k1_vm64x = 2526,
    /// <summary>
    /// vpgatherqq xmm, vm64x, xmm
    /// </summary>
    [Symbol("vpgatherqq xmm, vm64x, xmm","vpgatherqq xmm, vm64x, xmm")]
    vpgatherqq_xmm_vm64x_xmm = 2527,
    /// <summary>
    /// vpgatherqq ymm {k1}, vm64y
    /// </summary>
    [Symbol("vpgatherqq ymm {k1}, vm64y","vpgatherqq ymm {k1}, vm64y")]
    vpgatherqq_ymm_k1_vm64y = 2528,
    /// <summary>
    /// vpgatherqq ymm, vm64y, ymm
    /// </summary>
    [Symbol("vpgatherqq ymm, vm64y, ymm","vpgatherqq ymm, vm64y, ymm")]
    vpgatherqq_ymm_vm64y_ymm = 2529,
    /// <summary>
    /// vpgatherqq zmm {k1}, vm64z
    /// </summary>
    [Symbol("vpgatherqq zmm {k1}, vm64z","vpgatherqq zmm {k1}, vm64z")]
    vpgatherqq_zmm_k1_vm64z = 2530,
    /// <summary>
    /// vphaddd xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vphaddd xmm, xmm, xmm","vphaddd xmm, xmm, xmm/m128")]
    vphaddd_xmm_xmm_xmm = 2531,
    /// <summary>
    /// vphaddd xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vphaddd xmm, xmm, m128","vphaddd xmm, xmm, xmm/m128")]
    vphaddd_xmm_xmm_m128 = 2532,
    /// <summary>
    /// vphaddd ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vphaddd ymm, ymm, ymm","vphaddd ymm, ymm, ymm/m256")]
    vphaddd_ymm_ymm_ymm = 2533,
    /// <summary>
    /// vphaddd ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vphaddd ymm, ymm, m256","vphaddd ymm, ymm, ymm/m256")]
    vphaddd_ymm_ymm_m256 = 2534,
    /// <summary>
    /// vphaddsw xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vphaddsw xmm, xmm, xmm","vphaddsw xmm, xmm, xmm/m128")]
    vphaddsw_xmm_xmm_xmm = 2535,
    /// <summary>
    /// vphaddsw xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vphaddsw xmm, xmm, m128","vphaddsw xmm, xmm, xmm/m128")]
    vphaddsw_xmm_xmm_m128 = 2536,
    /// <summary>
    /// vphaddsw ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vphaddsw ymm, ymm, ymm","vphaddsw ymm, ymm, ymm/m256")]
    vphaddsw_ymm_ymm_ymm = 2537,
    /// <summary>
    /// vphaddsw ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vphaddsw ymm, ymm, m256","vphaddsw ymm, ymm, ymm/m256")]
    vphaddsw_ymm_ymm_m256 = 2538,
    /// <summary>
    /// vphaddw xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vphaddw xmm, xmm, xmm","vphaddw xmm, xmm, xmm/m128")]
    vphaddw_xmm_xmm_xmm = 2539,
    /// <summary>
    /// vphaddw xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vphaddw xmm, xmm, m128","vphaddw xmm, xmm, xmm/m128")]
    vphaddw_xmm_xmm_m128 = 2540,
    /// <summary>
    /// vphaddw ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vphaddw ymm, ymm, ymm","vphaddw ymm, ymm, ymm/m256")]
    vphaddw_ymm_ymm_ymm = 2541,
    /// <summary>
    /// vphaddw ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vphaddw ymm, ymm, m256","vphaddw ymm, ymm, ymm/m256")]
    vphaddw_ymm_ymm_m256 = 2542,
    /// <summary>
    /// vpinsrb xmm, xmm, r32/m8, imm8
    /// </summary>
    [Symbol("vpinsrb xmm, xmm, r32, imm8","vpinsrb xmm, xmm, r32/m8, imm8")]
    vpinsrb_xmm_xmm_r32_imm8 = 2543,
    /// <summary>
    /// vpinsrb xmm, xmm, r32/m8, imm8
    /// </summary>
    [Symbol("vpinsrb xmm, xmm, m8, imm8","vpinsrb xmm, xmm, r32/m8, imm8")]
    vpinsrb_xmm_xmm_m8_imm8 = 2544,
    /// <summary>
    /// vpinsrd xmm, xmm, r/m32, imm8
    /// </summary>
    [Symbol("vpinsrd xmm, xmm, r32, imm8","vpinsrd xmm, xmm, r/m32, imm8")]
    vpinsrd_xmm_xmm_r32_imm8 = 2545,
    /// <summary>
    /// vpinsrd xmm, xmm, r/m32, imm8
    /// </summary>
    [Symbol("vpinsrd xmm, xmm, m32, imm8","vpinsrd xmm, xmm, r/m32, imm8")]
    vpinsrd_xmm_xmm_m32_imm8 = 2546,
    /// <summary>
    /// vpinsrq xmm, xmm, r/m64, imm8
    /// </summary>
    [Symbol("vpinsrq xmm, xmm, r64, imm8","vpinsrq xmm, xmm, r/m64, imm8")]
    vpinsrq_xmm_xmm_r64_imm8 = 2547,
    /// <summary>
    /// vpinsrq xmm, xmm, r/m64, imm8
    /// </summary>
    [Symbol("vpinsrq xmm, xmm, m64, imm8","vpinsrq xmm, xmm, r/m64, imm8")]
    vpinsrq_xmm_xmm_m64_imm8 = 2548,
    /// <summary>
    /// vpinsrw xmm, xmm, r32/m16, imm8
    /// </summary>
    [Symbol("vpinsrw xmm, xmm, r32, imm8","vpinsrw xmm, xmm, r32/m16, imm8")]
    vpinsrw_xmm_xmm_r32_imm8 = 2549,
    /// <summary>
    /// vpinsrw xmm, xmm, r32/m16, imm8
    /// </summary>
    [Symbol("vpinsrw xmm, xmm, m16, imm8","vpinsrw xmm, xmm, r32/m16, imm8")]
    vpinsrw_xmm_xmm_m16_imm8 = 2550,
    /// <summary>
    /// vplzcntd xmm {k1}{z}, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vplzcntd xmm {k1}{z}, xmm","vplzcntd xmm {k1}{z}, xmm/m128/m32bcst")]
    vplzcntd_xmm_k1z_xmm = 2551,
    /// <summary>
    /// vplzcntd xmm {k1}{z}, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vplzcntd xmm {k1}{z}, m128","vplzcntd xmm {k1}{z}, xmm/m128/m32bcst")]
    vplzcntd_xmm_k1z_m128 = 2552,
    /// <summary>
    /// vplzcntd xmm {k1}{z}, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vplzcntd xmm {k1}{z}, m32bcst","vplzcntd xmm {k1}{z}, xmm/m128/m32bcst")]
    vplzcntd_xmm_k1z_m32bcst = 2553,
    /// <summary>
    /// vplzcntd ymm {k1}{z}, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vplzcntd ymm {k1}{z}, ymm","vplzcntd ymm {k1}{z}, ymm/m256/m32bcst")]
    vplzcntd_ymm_k1z_ymm = 2554,
    /// <summary>
    /// vplzcntd ymm {k1}{z}, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vplzcntd ymm {k1}{z}, m256","vplzcntd ymm {k1}{z}, ymm/m256/m32bcst")]
    vplzcntd_ymm_k1z_m256 = 2555,
    /// <summary>
    /// vplzcntd ymm {k1}{z}, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vplzcntd ymm {k1}{z}, m32bcst","vplzcntd ymm {k1}{z}, ymm/m256/m32bcst")]
    vplzcntd_ymm_k1z_m32bcst = 2556,
    /// <summary>
    /// vplzcntd zmm {k1}{z}, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vplzcntd zmm {k1}{z}, zmm","vplzcntd zmm {k1}{z}, zmm/m512/m32bcst")]
    vplzcntd_zmm_k1z_zmm = 2557,
    /// <summary>
    /// vplzcntd zmm {k1}{z}, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vplzcntd zmm {k1}{z}, m512","vplzcntd zmm {k1}{z}, zmm/m512/m32bcst")]
    vplzcntd_zmm_k1z_m512 = 2558,
    /// <summary>
    /// vplzcntd zmm {k1}{z}, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vplzcntd zmm {k1}{z}, m32bcst","vplzcntd zmm {k1}{z}, zmm/m512/m32bcst")]
    vplzcntd_zmm_k1z_m32bcst = 2559,
    /// <summary>
    /// vplzcntq xmm {k1}{z}, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vplzcntq xmm {k1}{z}, xmm","vplzcntq xmm {k1}{z}, xmm/m128/m64bcst")]
    vplzcntq_xmm_k1z_xmm = 2560,
    /// <summary>
    /// vplzcntq xmm {k1}{z}, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vplzcntq xmm {k1}{z}, m128","vplzcntq xmm {k1}{z}, xmm/m128/m64bcst")]
    vplzcntq_xmm_k1z_m128 = 2561,
    /// <summary>
    /// vplzcntq xmm {k1}{z}, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vplzcntq xmm {k1}{z}, m64bcst","vplzcntq xmm {k1}{z}, xmm/m128/m64bcst")]
    vplzcntq_xmm_k1z_m64bcst = 2562,
    /// <summary>
    /// vplzcntq ymm {k1}{z}, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vplzcntq ymm {k1}{z}, ymm","vplzcntq ymm {k1}{z}, ymm/m256/m64bcst")]
    vplzcntq_ymm_k1z_ymm = 2563,
    /// <summary>
    /// vplzcntq ymm {k1}{z}, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vplzcntq ymm {k1}{z}, m256","vplzcntq ymm {k1}{z}, ymm/m256/m64bcst")]
    vplzcntq_ymm_k1z_m256 = 2564,
    /// <summary>
    /// vplzcntq ymm {k1}{z}, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vplzcntq ymm {k1}{z}, m64bcst","vplzcntq ymm {k1}{z}, ymm/m256/m64bcst")]
    vplzcntq_ymm_k1z_m64bcst = 2565,
    /// <summary>
    /// vplzcntq zmm {k1}{z}, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vplzcntq zmm {k1}{z}, zmm","vplzcntq zmm {k1}{z}, zmm/m512/m64bcst")]
    vplzcntq_zmm_k1z_zmm = 2566,
    /// <summary>
    /// vplzcntq zmm {k1}{z}, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vplzcntq zmm {k1}{z}, m512","vplzcntq zmm {k1}{z}, zmm/m512/m64bcst")]
    vplzcntq_zmm_k1z_m512 = 2567,
    /// <summary>
    /// vplzcntq zmm {k1}{z}, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vplzcntq zmm {k1}{z}, m64bcst","vplzcntq zmm {k1}{z}, zmm/m512/m64bcst")]
    vplzcntq_zmm_k1z_m64bcst = 2568,
    /// <summary>
    /// vpmaskmovd m128, xmm, xmm
    /// </summary>
    [Symbol("vpmaskmovd m128, xmm, xmm","vpmaskmovd m128, xmm, xmm")]
    vpmaskmovd_m128_xmm_xmm = 2569,
    /// <summary>
    /// vpmaskmovd m256, ymm, ymm
    /// </summary>
    [Symbol("vpmaskmovd m256, ymm, ymm","vpmaskmovd m256, ymm, ymm")]
    vpmaskmovd_m256_ymm_ymm = 2570,
    /// <summary>
    /// vpmaskmovd xmm, xmm, m128
    /// </summary>
    [Symbol("vpmaskmovd xmm, xmm, m128","vpmaskmovd xmm, xmm, m128")]
    vpmaskmovd_xmm_xmm_m128 = 2571,
    /// <summary>
    /// vpmaskmovd ymm, ymm, m256
    /// </summary>
    [Symbol("vpmaskmovd ymm, ymm, m256","vpmaskmovd ymm, ymm, m256")]
    vpmaskmovd_ymm_ymm_m256 = 2572,
    /// <summary>
    /// vpmaskmovq m128, xmm, xmm
    /// </summary>
    [Symbol("vpmaskmovq m128, xmm, xmm","vpmaskmovq m128, xmm, xmm")]
    vpmaskmovq_m128_xmm_xmm = 2573,
    /// <summary>
    /// vpmaskmovq m256, ymm, ymm
    /// </summary>
    [Symbol("vpmaskmovq m256, ymm, ymm","vpmaskmovq m256, ymm, ymm")]
    vpmaskmovq_m256_ymm_ymm = 2574,
    /// <summary>
    /// vpmaskmovq xmm, xmm, m128
    /// </summary>
    [Symbol("vpmaskmovq xmm, xmm, m128","vpmaskmovq xmm, xmm, m128")]
    vpmaskmovq_xmm_xmm_m128 = 2575,
    /// <summary>
    /// vpmaskmovq ymm, ymm, m256
    /// </summary>
    [Symbol("vpmaskmovq ymm, ymm, m256","vpmaskmovq ymm, ymm, m256")]
    vpmaskmovq_ymm_ymm_m256 = 2576,
    /// <summary>
    /// vpmaxsb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpmaxsb xmm {k1}{z}, xmm, xmm","vpmaxsb xmm {k1}{z}, xmm, xmm/m128")]
    vpmaxsb_xmm_k1z_xmm_xmm = 2577,
    /// <summary>
    /// vpmaxsb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpmaxsb xmm {k1}{z}, xmm, m128","vpmaxsb xmm {k1}{z}, xmm, xmm/m128")]
    vpmaxsb_xmm_k1z_xmm_m128 = 2578,
    /// <summary>
    /// vpmaxsb xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpmaxsb xmm, xmm, xmm","vpmaxsb xmm, xmm, xmm/m128")]
    vpmaxsb_xmm_xmm_xmm = 2579,
    /// <summary>
    /// vpmaxsb xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpmaxsb xmm, xmm, m128","vpmaxsb xmm, xmm, xmm/m128")]
    vpmaxsb_xmm_xmm_m128 = 2580,
    /// <summary>
    /// vpmaxsb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpmaxsb ymm {k1}{z}, ymm, ymm","vpmaxsb ymm {k1}{z}, ymm, ymm/m256")]
    vpmaxsb_ymm_k1z_ymm_ymm = 2581,
    /// <summary>
    /// vpmaxsb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpmaxsb ymm {k1}{z}, ymm, m256","vpmaxsb ymm {k1}{z}, ymm, ymm/m256")]
    vpmaxsb_ymm_k1z_ymm_m256 = 2582,
    /// <summary>
    /// vpmaxsb ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpmaxsb ymm, ymm, ymm","vpmaxsb ymm, ymm, ymm/m256")]
    vpmaxsb_ymm_ymm_ymm = 2583,
    /// <summary>
    /// vpmaxsb ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpmaxsb ymm, ymm, m256","vpmaxsb ymm, ymm, ymm/m256")]
    vpmaxsb_ymm_ymm_m256 = 2584,
    /// <summary>
    /// vpmaxsb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpmaxsb zmm {k1}{z}, zmm, zmm","vpmaxsb zmm {k1}{z}, zmm, zmm/m512")]
    vpmaxsb_zmm_k1z_zmm_zmm = 2585,
    /// <summary>
    /// vpmaxsb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpmaxsb zmm {k1}{z}, zmm, m512","vpmaxsb zmm {k1}{z}, zmm, zmm/m512")]
    vpmaxsb_zmm_k1z_zmm_m512 = 2586,
    /// <summary>
    /// vpmaxsd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpmaxsd xmm {k1}{z}, xmm, xmm","vpmaxsd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpmaxsd_xmm_k1z_xmm_xmm = 2587,
    /// <summary>
    /// vpmaxsd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpmaxsd xmm {k1}{z}, xmm, m128","vpmaxsd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpmaxsd_xmm_k1z_xmm_m128 = 2588,
    /// <summary>
    /// vpmaxsd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpmaxsd xmm {k1}{z}, xmm, m32bcst","vpmaxsd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpmaxsd_xmm_k1z_xmm_m32bcst = 2589,
    /// <summary>
    /// vpmaxsd xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpmaxsd xmm, xmm, xmm","vpmaxsd xmm, xmm, xmm/m128")]
    vpmaxsd_xmm_xmm_xmm = 2590,
    /// <summary>
    /// vpmaxsd xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpmaxsd xmm, xmm, m128","vpmaxsd xmm, xmm, xmm/m128")]
    vpmaxsd_xmm_xmm_m128 = 2591,
    /// <summary>
    /// vpmaxsd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpmaxsd ymm {k1}{z}, ymm, ymm","vpmaxsd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpmaxsd_ymm_k1z_ymm_ymm = 2592,
    /// <summary>
    /// vpmaxsd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpmaxsd ymm {k1}{z}, ymm, m256","vpmaxsd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpmaxsd_ymm_k1z_ymm_m256 = 2593,
    /// <summary>
    /// vpmaxsd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpmaxsd ymm {k1}{z}, ymm, m32bcst","vpmaxsd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpmaxsd_ymm_k1z_ymm_m32bcst = 2594,
    /// <summary>
    /// vpmaxsd ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpmaxsd ymm, ymm, ymm","vpmaxsd ymm, ymm, ymm/m256")]
    vpmaxsd_ymm_ymm_ymm = 2595,
    /// <summary>
    /// vpmaxsd ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpmaxsd ymm, ymm, m256","vpmaxsd ymm, ymm, ymm/m256")]
    vpmaxsd_ymm_ymm_m256 = 2596,
    /// <summary>
    /// vpmaxsd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpmaxsd zmm {k1}{z}, zmm, zmm","vpmaxsd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpmaxsd_zmm_k1z_zmm_zmm = 2597,
    /// <summary>
    /// vpmaxsd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpmaxsd zmm {k1}{z}, zmm, m512","vpmaxsd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpmaxsd_zmm_k1z_zmm_m512 = 2598,
    /// <summary>
    /// vpmaxsd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpmaxsd zmm {k1}{z}, zmm, m32bcst","vpmaxsd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpmaxsd_zmm_k1z_zmm_m32bcst = 2599,
    /// <summary>
    /// vpmaxsq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpmaxsq xmm {k1}{z}, xmm, xmm","vpmaxsq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpmaxsq_xmm_k1z_xmm_xmm = 2600,
    /// <summary>
    /// vpmaxsq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpmaxsq xmm {k1}{z}, xmm, m128","vpmaxsq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpmaxsq_xmm_k1z_xmm_m128 = 2601,
    /// <summary>
    /// vpmaxsq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpmaxsq xmm {k1}{z}, xmm, m64bcst","vpmaxsq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpmaxsq_xmm_k1z_xmm_m64bcst = 2602,
    /// <summary>
    /// vpmaxsq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpmaxsq ymm {k1}{z}, ymm, ymm","vpmaxsq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpmaxsq_ymm_k1z_ymm_ymm = 2603,
    /// <summary>
    /// vpmaxsq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpmaxsq ymm {k1}{z}, ymm, m256","vpmaxsq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpmaxsq_ymm_k1z_ymm_m256 = 2604,
    /// <summary>
    /// vpmaxsq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpmaxsq ymm {k1}{z}, ymm, m64bcst","vpmaxsq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpmaxsq_ymm_k1z_ymm_m64bcst = 2605,
    /// <summary>
    /// vpmaxsq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpmaxsq zmm {k1}{z}, zmm, zmm","vpmaxsq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpmaxsq_zmm_k1z_zmm_zmm = 2606,
    /// <summary>
    /// vpmaxsq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpmaxsq zmm {k1}{z}, zmm, m512","vpmaxsq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpmaxsq_zmm_k1z_zmm_m512 = 2607,
    /// <summary>
    /// vpmaxsq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpmaxsq zmm {k1}{z}, zmm, m64bcst","vpmaxsq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpmaxsq_zmm_k1z_zmm_m64bcst = 2608,
    /// <summary>
    /// vpmaxsw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpmaxsw xmm {k1}{z}, xmm, xmm","vpmaxsw xmm {k1}{z}, xmm, xmm/m128")]
    vpmaxsw_xmm_k1z_xmm_xmm = 2609,
    /// <summary>
    /// vpmaxsw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpmaxsw xmm {k1}{z}, xmm, m128","vpmaxsw xmm {k1}{z}, xmm, xmm/m128")]
    vpmaxsw_xmm_k1z_xmm_m128 = 2610,
    /// <summary>
    /// vpmaxsw xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpmaxsw xmm, xmm, xmm","vpmaxsw xmm, xmm, xmm/m128")]
    vpmaxsw_xmm_xmm_xmm = 2611,
    /// <summary>
    /// vpmaxsw xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpmaxsw xmm, xmm, m128","vpmaxsw xmm, xmm, xmm/m128")]
    vpmaxsw_xmm_xmm_m128 = 2612,
    /// <summary>
    /// vpmaxsw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpmaxsw ymm {k1}{z}, ymm, ymm","vpmaxsw ymm {k1}{z}, ymm, ymm/m256")]
    vpmaxsw_ymm_k1z_ymm_ymm = 2613,
    /// <summary>
    /// vpmaxsw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpmaxsw ymm {k1}{z}, ymm, m256","vpmaxsw ymm {k1}{z}, ymm, ymm/m256")]
    vpmaxsw_ymm_k1z_ymm_m256 = 2614,
    /// <summary>
    /// vpmaxsw ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpmaxsw ymm, ymm, ymm","vpmaxsw ymm, ymm, ymm/m256")]
    vpmaxsw_ymm_ymm_ymm = 2615,
    /// <summary>
    /// vpmaxsw ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpmaxsw ymm, ymm, m256","vpmaxsw ymm, ymm, ymm/m256")]
    vpmaxsw_ymm_ymm_m256 = 2616,
    /// <summary>
    /// vpmaxsw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpmaxsw zmm {k1}{z}, zmm, zmm","vpmaxsw zmm {k1}{z}, zmm, zmm/m512")]
    vpmaxsw_zmm_k1z_zmm_zmm = 2617,
    /// <summary>
    /// vpmaxsw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpmaxsw zmm {k1}{z}, zmm, m512","vpmaxsw zmm {k1}{z}, zmm, zmm/m512")]
    vpmaxsw_zmm_k1z_zmm_m512 = 2618,
    /// <summary>
    /// vpmaxub xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpmaxub xmm {k1}{z}, xmm, xmm","vpmaxub xmm {k1}{z}, xmm, xmm/m128")]
    vpmaxub_xmm_k1z_xmm_xmm = 2619,
    /// <summary>
    /// vpmaxub xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpmaxub xmm {k1}{z}, xmm, m128","vpmaxub xmm {k1}{z}, xmm, xmm/m128")]
    vpmaxub_xmm_k1z_xmm_m128 = 2620,
    /// <summary>
    /// vpmaxub xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpmaxub xmm, xmm, xmm","vpmaxub xmm, xmm, xmm/m128")]
    vpmaxub_xmm_xmm_xmm = 2621,
    /// <summary>
    /// vpmaxub xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpmaxub xmm, xmm, m128","vpmaxub xmm, xmm, xmm/m128")]
    vpmaxub_xmm_xmm_m128 = 2622,
    /// <summary>
    /// vpmaxub ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpmaxub ymm {k1}{z}, ymm, ymm","vpmaxub ymm {k1}{z}, ymm, ymm/m256")]
    vpmaxub_ymm_k1z_ymm_ymm = 2623,
    /// <summary>
    /// vpmaxub ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpmaxub ymm {k1}{z}, ymm, m256","vpmaxub ymm {k1}{z}, ymm, ymm/m256")]
    vpmaxub_ymm_k1z_ymm_m256 = 2624,
    /// <summary>
    /// vpmaxub ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpmaxub ymm, ymm, ymm","vpmaxub ymm, ymm, ymm/m256")]
    vpmaxub_ymm_ymm_ymm = 2625,
    /// <summary>
    /// vpmaxub ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpmaxub ymm, ymm, m256","vpmaxub ymm, ymm, ymm/m256")]
    vpmaxub_ymm_ymm_m256 = 2626,
    /// <summary>
    /// vpmaxub zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpmaxub zmm {k1}{z}, zmm, zmm","vpmaxub zmm {k1}{z}, zmm, zmm/m512")]
    vpmaxub_zmm_k1z_zmm_zmm = 2627,
    /// <summary>
    /// vpmaxub zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpmaxub zmm {k1}{z}, zmm, m512","vpmaxub zmm {k1}{z}, zmm, zmm/m512")]
    vpmaxub_zmm_k1z_zmm_m512 = 2628,
    /// <summary>
    /// vpmaxuw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpmaxuw xmm {k1}{z}, xmm, xmm","vpmaxuw xmm {k1}{z}, xmm, xmm/m128")]
    vpmaxuw_xmm_k1z_xmm_xmm = 2629,
    /// <summary>
    /// vpmaxuw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpmaxuw xmm {k1}{z}, xmm, m128","vpmaxuw xmm {k1}{z}, xmm, xmm/m128")]
    vpmaxuw_xmm_k1z_xmm_m128 = 2630,
    /// <summary>
    /// vpmaxuw xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpmaxuw xmm, xmm, xmm","vpmaxuw xmm, xmm, xmm/m128")]
    vpmaxuw_xmm_xmm_xmm = 2631,
    /// <summary>
    /// vpmaxuw xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpmaxuw xmm, xmm, m128","vpmaxuw xmm, xmm, xmm/m128")]
    vpmaxuw_xmm_xmm_m128 = 2632,
    /// <summary>
    /// vpmaxuw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpmaxuw ymm {k1}{z}, ymm, ymm","vpmaxuw ymm {k1}{z}, ymm, ymm/m256")]
    vpmaxuw_ymm_k1z_ymm_ymm = 2633,
    /// <summary>
    /// vpmaxuw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpmaxuw ymm {k1}{z}, ymm, m256","vpmaxuw ymm {k1}{z}, ymm, ymm/m256")]
    vpmaxuw_ymm_k1z_ymm_m256 = 2634,
    /// <summary>
    /// vpmaxuw ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpmaxuw ymm, ymm, ymm","vpmaxuw ymm, ymm, ymm/m256")]
    vpmaxuw_ymm_ymm_ymm = 2635,
    /// <summary>
    /// vpmaxuw ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpmaxuw ymm, ymm, m256","vpmaxuw ymm, ymm, ymm/m256")]
    vpmaxuw_ymm_ymm_m256 = 2636,
    /// <summary>
    /// vpmaxuw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpmaxuw zmm {k1}{z}, zmm, zmm","vpmaxuw zmm {k1}{z}, zmm, zmm/m512")]
    vpmaxuw_zmm_k1z_zmm_zmm = 2637,
    /// <summary>
    /// vpmaxuw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpmaxuw zmm {k1}{z}, zmm, m512","vpmaxuw zmm {k1}{z}, zmm, zmm/m512")]
    vpmaxuw_zmm_k1z_zmm_m512 = 2638,
    /// <summary>
    /// vpminsb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpminsb xmm {k1}{z}, xmm, xmm","vpminsb xmm {k1}{z}, xmm, xmm/m128")]
    vpminsb_xmm_k1z_xmm_xmm = 2639,
    /// <summary>
    /// vpminsb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpminsb xmm {k1}{z}, xmm, m128","vpminsb xmm {k1}{z}, xmm, xmm/m128")]
    vpminsb_xmm_k1z_xmm_m128 = 2640,
    /// <summary>
    /// vpminsb xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpminsb xmm, xmm, xmm","vpminsb xmm, xmm, xmm/m128")]
    vpminsb_xmm_xmm_xmm = 2641,
    /// <summary>
    /// vpminsb xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpminsb xmm, xmm, m128","vpminsb xmm, xmm, xmm/m128")]
    vpminsb_xmm_xmm_m128 = 2642,
    /// <summary>
    /// vpminsb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpminsb ymm {k1}{z}, ymm, ymm","vpminsb ymm {k1}{z}, ymm, ymm/m256")]
    vpminsb_ymm_k1z_ymm_ymm = 2643,
    /// <summary>
    /// vpminsb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpminsb ymm {k1}{z}, ymm, m256","vpminsb ymm {k1}{z}, ymm, ymm/m256")]
    vpminsb_ymm_k1z_ymm_m256 = 2644,
    /// <summary>
    /// vpminsb ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpminsb ymm, ymm, ymm","vpminsb ymm, ymm, ymm/m256")]
    vpminsb_ymm_ymm_ymm = 2645,
    /// <summary>
    /// vpminsb ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpminsb ymm, ymm, m256","vpminsb ymm, ymm, ymm/m256")]
    vpminsb_ymm_ymm_m256 = 2646,
    /// <summary>
    /// vpminsb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpminsb zmm {k1}{z}, zmm, zmm","vpminsb zmm {k1}{z}, zmm, zmm/m512")]
    vpminsb_zmm_k1z_zmm_zmm = 2647,
    /// <summary>
    /// vpminsb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpminsb zmm {k1}{z}, zmm, m512","vpminsb zmm {k1}{z}, zmm, zmm/m512")]
    vpminsb_zmm_k1z_zmm_m512 = 2648,
    /// <summary>
    /// vpminsw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpminsw xmm {k1}{z}, xmm, xmm","vpminsw xmm {k1}{z}, xmm, xmm/m128")]
    vpminsw_xmm_k1z_xmm_xmm = 2649,
    /// <summary>
    /// vpminsw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpminsw xmm {k1}{z}, xmm, m128","vpminsw xmm {k1}{z}, xmm, xmm/m128")]
    vpminsw_xmm_k1z_xmm_m128 = 2650,
    /// <summary>
    /// vpminsw xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpminsw xmm, xmm, xmm","vpminsw xmm, xmm, xmm/m128")]
    vpminsw_xmm_xmm_xmm = 2651,
    /// <summary>
    /// vpminsw xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpminsw xmm, xmm, m128","vpminsw xmm, xmm, xmm/m128")]
    vpminsw_xmm_xmm_m128 = 2652,
    /// <summary>
    /// vpminsw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpminsw ymm {k1}{z}, ymm, ymm","vpminsw ymm {k1}{z}, ymm, ymm/m256")]
    vpminsw_ymm_k1z_ymm_ymm = 2653,
    /// <summary>
    /// vpminsw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpminsw ymm {k1}{z}, ymm, m256","vpminsw ymm {k1}{z}, ymm, ymm/m256")]
    vpminsw_ymm_k1z_ymm_m256 = 2654,
    /// <summary>
    /// vpminsw ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpminsw ymm, ymm, ymm","vpminsw ymm, ymm, ymm/m256")]
    vpminsw_ymm_ymm_ymm = 2655,
    /// <summary>
    /// vpminsw ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpminsw ymm, ymm, m256","vpminsw ymm, ymm, ymm/m256")]
    vpminsw_ymm_ymm_m256 = 2656,
    /// <summary>
    /// vpminsw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpminsw zmm {k1}{z}, zmm, zmm","vpminsw zmm {k1}{z}, zmm, zmm/m512")]
    vpminsw_zmm_k1z_zmm_zmm = 2657,
    /// <summary>
    /// vpminsw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpminsw zmm {k1}{z}, zmm, m512","vpminsw zmm {k1}{z}, zmm, zmm/m512")]
    vpminsw_zmm_k1z_zmm_m512 = 2658,
    /// <summary>
    /// vpminub xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpminub xmm {k1}{z}, xmm, xmm","vpminub xmm {k1}{z}, xmm, xmm/m128")]
    vpminub_xmm_k1z_xmm_xmm = 2659,
    /// <summary>
    /// vpminub xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpminub xmm {k1}{z}, xmm, m128","vpminub xmm {k1}{z}, xmm, xmm/m128")]
    vpminub_xmm_k1z_xmm_m128 = 2660,
    /// <summary>
    /// vpminub xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpminub xmm, xmm, xmm","vpminub xmm, xmm, xmm/m128")]
    vpminub_xmm_xmm_xmm = 2661,
    /// <summary>
    /// vpminub xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpminub xmm, xmm, m128","vpminub xmm, xmm, xmm/m128")]
    vpminub_xmm_xmm_m128 = 2662,
    /// <summary>
    /// vpminub ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpminub ymm {k1}{z}, ymm, ymm","vpminub ymm {k1}{z}, ymm, ymm/m256")]
    vpminub_ymm_k1z_ymm_ymm = 2663,
    /// <summary>
    /// vpminub ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpminub ymm {k1}{z}, ymm, m256","vpminub ymm {k1}{z}, ymm, ymm/m256")]
    vpminub_ymm_k1z_ymm_m256 = 2664,
    /// <summary>
    /// vpminub ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpminub ymm, ymm, ymm","vpminub ymm, ymm, ymm/m256")]
    vpminub_ymm_ymm_ymm = 2665,
    /// <summary>
    /// vpminub ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpminub ymm, ymm, m256","vpminub ymm, ymm, ymm/m256")]
    vpminub_ymm_ymm_m256 = 2666,
    /// <summary>
    /// vpminub zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpminub zmm {k1}{z}, zmm, zmm","vpminub zmm {k1}{z}, zmm, zmm/m512")]
    vpminub_zmm_k1z_zmm_zmm = 2667,
    /// <summary>
    /// vpminub zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpminub zmm {k1}{z}, zmm, m512","vpminub zmm {k1}{z}, zmm, zmm/m512")]
    vpminub_zmm_k1z_zmm_m512 = 2668,
    /// <summary>
    /// vpminuw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpminuw xmm {k1}{z}, xmm, xmm","vpminuw xmm {k1}{z}, xmm, xmm/m128")]
    vpminuw_xmm_k1z_xmm_xmm = 2669,
    /// <summary>
    /// vpminuw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpminuw xmm {k1}{z}, xmm, m128","vpminuw xmm {k1}{z}, xmm, xmm/m128")]
    vpminuw_xmm_k1z_xmm_m128 = 2670,
    /// <summary>
    /// vpminuw xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpminuw xmm, xmm, xmm","vpminuw xmm, xmm, xmm/m128")]
    vpminuw_xmm_xmm_xmm = 2671,
    /// <summary>
    /// vpminuw xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpminuw xmm, xmm, m128","vpminuw xmm, xmm, xmm/m128")]
    vpminuw_xmm_xmm_m128 = 2672,
    /// <summary>
    /// vpminuw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpminuw ymm {k1}{z}, ymm, ymm","vpminuw ymm {k1}{z}, ymm, ymm/m256")]
    vpminuw_ymm_k1z_ymm_ymm = 2673,
    /// <summary>
    /// vpminuw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpminuw ymm {k1}{z}, ymm, m256","vpminuw ymm {k1}{z}, ymm, ymm/m256")]
    vpminuw_ymm_k1z_ymm_m256 = 2674,
    /// <summary>
    /// vpminuw ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpminuw ymm, ymm, ymm","vpminuw ymm, ymm, ymm/m256")]
    vpminuw_ymm_ymm_ymm = 2675,
    /// <summary>
    /// vpminuw ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpminuw ymm, ymm, m256","vpminuw ymm, ymm, ymm/m256")]
    vpminuw_ymm_ymm_m256 = 2676,
    /// <summary>
    /// vpminuw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpminuw zmm {k1}{z}, zmm, zmm","vpminuw zmm {k1}{z}, zmm, zmm/m512")]
    vpminuw_zmm_k1z_zmm_zmm = 2677,
    /// <summary>
    /// vpminuw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpminuw zmm {k1}{z}, zmm, m512","vpminuw zmm {k1}{z}, zmm, zmm/m512")]
    vpminuw_zmm_k1z_zmm_m512 = 2678,
    /// <summary>
    /// vpmovb2m k, xmm
    /// </summary>
    [Symbol("vpmovb2m k, xmm","vpmovb2m k, xmm")]
    vpmovb2m_k_xmm = 2679,
    /// <summary>
    /// vpmovb2m k, ymm
    /// </summary>
    [Symbol("vpmovb2m k, ymm","vpmovb2m k, ymm")]
    vpmovb2m_k_ymm = 2680,
    /// <summary>
    /// vpmovb2m k, zmm
    /// </summary>
    [Symbol("vpmovb2m k, zmm","vpmovb2m k, zmm")]
    vpmovb2m_k_zmm = 2681,
    /// <summary>
    /// vpmovd2m k, xmm
    /// </summary>
    [Symbol("vpmovd2m k, xmm","vpmovd2m k, xmm")]
    vpmovd2m_k_xmm = 2682,
    /// <summary>
    /// vpmovd2m k, ymm
    /// </summary>
    [Symbol("vpmovd2m k, ymm","vpmovd2m k, ymm")]
    vpmovd2m_k_ymm = 2683,
    /// <summary>
    /// vpmovd2m k, zmm
    /// </summary>
    [Symbol("vpmovd2m k, zmm","vpmovd2m k, zmm")]
    vpmovd2m_k_zmm = 2684,
    /// <summary>
    /// vpmovdb xmm/m128 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpmovdb xmm {k1}{z}, zmm","vpmovdb xmm/m128 {k1}{z}, zmm")]
    vpmovdb_xmm_k1z_zmm = 2685,
    /// <summary>
    /// vpmovdb xmm/m128 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpmovdb m128 {k1}{z}, zmm","vpmovdb xmm/m128 {k1}{z}, zmm")]
    vpmovdb_m128_k1z_zmm = 2686,
    /// <summary>
    /// vpmovdb xmm/m32 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpmovdb xmm {k1}{z}, xmm","vpmovdb xmm/m32 {k1}{z}, xmm")]
    vpmovdb_xmm_k1z_xmm = 2687,
    /// <summary>
    /// vpmovdb xmm/m32 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpmovdb m32 {k1}{z}, xmm","vpmovdb xmm/m32 {k1}{z}, xmm")]
    vpmovdb_m32_k1z_xmm = 2688,
    /// <summary>
    /// vpmovdb xmm/m64 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpmovdb xmm {k1}{z}, ymm","vpmovdb xmm/m64 {k1}{z}, ymm")]
    vpmovdb_xmm_k1z_ymm = 2689,
    /// <summary>
    /// vpmovdb xmm/m64 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpmovdb m64 {k1}{z}, ymm","vpmovdb xmm/m64 {k1}{z}, ymm")]
    vpmovdb_m64_k1z_ymm = 2690,
    /// <summary>
    /// vpmovdw xmm/m128 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpmovdw xmm {k1}{z}, ymm","vpmovdw xmm/m128 {k1}{z}, ymm")]
    vpmovdw_xmm_k1z_ymm = 2691,
    /// <summary>
    /// vpmovdw xmm/m128 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpmovdw m128 {k1}{z}, ymm","vpmovdw xmm/m128 {k1}{z}, ymm")]
    vpmovdw_m128_k1z_ymm = 2692,
    /// <summary>
    /// vpmovdw xmm/m64 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpmovdw xmm {k1}{z}, xmm","vpmovdw xmm/m64 {k1}{z}, xmm")]
    vpmovdw_xmm_k1z_xmm = 2693,
    /// <summary>
    /// vpmovdw xmm/m64 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpmovdw m64 {k1}{z}, xmm","vpmovdw xmm/m64 {k1}{z}, xmm")]
    vpmovdw_m64_k1z_xmm = 2694,
    /// <summary>
    /// vpmovdw ymm/m256 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpmovdw ymm {k1}{z}, zmm","vpmovdw ymm/m256 {k1}{z}, zmm")]
    vpmovdw_ymm_k1z_zmm = 2695,
    /// <summary>
    /// vpmovdw ymm/m256 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpmovdw m256 {k1}{z}, zmm","vpmovdw ymm/m256 {k1}{z}, zmm")]
    vpmovdw_m256_k1z_zmm = 2696,
    /// <summary>
    /// vpmovm2b xmm, k
    /// </summary>
    [Symbol("vpmovm2b xmm, k","vpmovm2b xmm, k")]
    vpmovm2b_xmm_k = 2697,
    /// <summary>
    /// vpmovm2b ymm, k
    /// </summary>
    [Symbol("vpmovm2b ymm, k","vpmovm2b ymm, k")]
    vpmovm2b_ymm_k = 2698,
    /// <summary>
    /// vpmovm2b zmm, k
    /// </summary>
    [Symbol("vpmovm2b zmm, k","vpmovm2b zmm, k")]
    vpmovm2b_zmm_k = 2699,
    /// <summary>
    /// vpmovm2d xmm, k
    /// </summary>
    [Symbol("vpmovm2d xmm, k","vpmovm2d xmm, k")]
    vpmovm2d_xmm_k = 2700,
    /// <summary>
    /// vpmovm2d ymm, k
    /// </summary>
    [Symbol("vpmovm2d ymm, k","vpmovm2d ymm, k")]
    vpmovm2d_ymm_k = 2701,
    /// <summary>
    /// vpmovm2d zmm, k
    /// </summary>
    [Symbol("vpmovm2d zmm, k","vpmovm2d zmm, k")]
    vpmovm2d_zmm_k = 2702,
    /// <summary>
    /// vpmovm2q xmm, k
    /// </summary>
    [Symbol("vpmovm2q xmm, k","vpmovm2q xmm, k")]
    vpmovm2q_xmm_k = 2703,
    /// <summary>
    /// vpmovm2q ymm, k
    /// </summary>
    [Symbol("vpmovm2q ymm, k","vpmovm2q ymm, k")]
    vpmovm2q_ymm_k = 2704,
    /// <summary>
    /// vpmovm2q zmm, k
    /// </summary>
    [Symbol("vpmovm2q zmm, k","vpmovm2q zmm, k")]
    vpmovm2q_zmm_k = 2705,
    /// <summary>
    /// vpmovm2w xmm, k
    /// </summary>
    [Symbol("vpmovm2w xmm, k","vpmovm2w xmm, k")]
    vpmovm2w_xmm_k = 2706,
    /// <summary>
    /// vpmovm2w ymm, k
    /// </summary>
    [Symbol("vpmovm2w ymm, k","vpmovm2w ymm, k")]
    vpmovm2w_ymm_k = 2707,
    /// <summary>
    /// vpmovm2w zmm, k
    /// </summary>
    [Symbol("vpmovm2w zmm, k","vpmovm2w zmm, k")]
    vpmovm2w_zmm_k = 2708,
    /// <summary>
    /// vpmovmskb reg, xmm
    /// </summary>
    [Symbol("vpmovmskb reg, xmm","vpmovmskb reg, xmm")]
    vpmovmskb_reg_xmm = 2709,
    /// <summary>
    /// vpmovmskb reg, ymm
    /// </summary>
    [Symbol("vpmovmskb reg, ymm","vpmovmskb reg, ymm")]
    vpmovmskb_reg_ymm = 2710,
    /// <summary>
    /// vpmovq2m k, xmm
    /// </summary>
    [Symbol("vpmovq2m k, xmm","vpmovq2m k, xmm")]
    vpmovq2m_k_xmm = 2711,
    /// <summary>
    /// vpmovq2m k, ymm
    /// </summary>
    [Symbol("vpmovq2m k, ymm","vpmovq2m k, ymm")]
    vpmovq2m_k_ymm = 2712,
    /// <summary>
    /// vpmovq2m k, zmm
    /// </summary>
    [Symbol("vpmovq2m k, zmm","vpmovq2m k, zmm")]
    vpmovq2m_k_zmm = 2713,
    /// <summary>
    /// vpmovqb xmm/m16 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpmovqb xmm {k1}{z}, xmm","vpmovqb xmm/m16 {k1}{z}, xmm")]
    vpmovqb_xmm_k1z_xmm = 2714,
    /// <summary>
    /// vpmovqb xmm/m16 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpmovqb m16 {k1}{z}, xmm","vpmovqb xmm/m16 {k1}{z}, xmm")]
    vpmovqb_m16_k1z_xmm = 2715,
    /// <summary>
    /// vpmovqb xmm/m32 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpmovqb xmm {k1}{z}, ymm","vpmovqb xmm/m32 {k1}{z}, ymm")]
    vpmovqb_xmm_k1z_ymm = 2716,
    /// <summary>
    /// vpmovqb xmm/m32 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpmovqb m32 {k1}{z}, ymm","vpmovqb xmm/m32 {k1}{z}, ymm")]
    vpmovqb_m32_k1z_ymm = 2717,
    /// <summary>
    /// vpmovqb xmm/m64 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpmovqb xmm {k1}{z}, zmm","vpmovqb xmm/m64 {k1}{z}, zmm")]
    vpmovqb_xmm_k1z_zmm = 2718,
    /// <summary>
    /// vpmovqb xmm/m64 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpmovqb m64 {k1}{z}, zmm","vpmovqb xmm/m64 {k1}{z}, zmm")]
    vpmovqb_m64_k1z_zmm = 2719,
    /// <summary>
    /// vpmovqd xmm/m128 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpmovqd xmm {k1}{z}, xmm","vpmovqd xmm/m128 {k1}{z}, xmm")]
    vpmovqd_xmm_k1z_xmm = 2720,
    /// <summary>
    /// vpmovqd xmm/m128 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpmovqd m128 {k1}{z}, xmm","vpmovqd xmm/m128 {k1}{z}, xmm")]
    vpmovqd_m128_k1z_xmm = 2721,
    /// <summary>
    /// vpmovqd xmm/m128 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpmovqd xmm {k1}{z}, ymm","vpmovqd xmm/m128 {k1}{z}, ymm")]
    vpmovqd_xmm_k1z_ymm = 2722,
    /// <summary>
    /// vpmovqd xmm/m128 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpmovqd m128 {k1}{z}, ymm","vpmovqd xmm/m128 {k1}{z}, ymm")]
    vpmovqd_m128_k1z_ymm = 2723,
    /// <summary>
    /// vpmovqd ymm/m256 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpmovqd ymm {k1}{z}, zmm","vpmovqd ymm/m256 {k1}{z}, zmm")]
    vpmovqd_ymm_k1z_zmm = 2724,
    /// <summary>
    /// vpmovqd ymm/m256 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpmovqd m256 {k1}{z}, zmm","vpmovqd ymm/m256 {k1}{z}, zmm")]
    vpmovqd_m256_k1z_zmm = 2725,
    /// <summary>
    /// vpmovqw xmm/m128 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpmovqw xmm {k1}{z}, zmm","vpmovqw xmm/m128 {k1}{z}, zmm")]
    vpmovqw_xmm_k1z_zmm = 2726,
    /// <summary>
    /// vpmovqw xmm/m128 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpmovqw m128 {k1}{z}, zmm","vpmovqw xmm/m128 {k1}{z}, zmm")]
    vpmovqw_m128_k1z_zmm = 2727,
    /// <summary>
    /// vpmovqw xmm/m32 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpmovqw xmm {k1}{z}, xmm","vpmovqw xmm/m32 {k1}{z}, xmm")]
    vpmovqw_xmm_k1z_xmm = 2728,
    /// <summary>
    /// vpmovqw xmm/m32 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpmovqw m32 {k1}{z}, xmm","vpmovqw xmm/m32 {k1}{z}, xmm")]
    vpmovqw_m32_k1z_xmm = 2729,
    /// <summary>
    /// vpmovqw xmm/m64 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpmovqw xmm {k1}{z}, ymm","vpmovqw xmm/m64 {k1}{z}, ymm")]
    vpmovqw_xmm_k1z_ymm = 2730,
    /// <summary>
    /// vpmovqw xmm/m64 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpmovqw m64 {k1}{z}, ymm","vpmovqw xmm/m64 {k1}{z}, ymm")]
    vpmovqw_m64_k1z_ymm = 2731,
    /// <summary>
    /// vpmovsdb xmm/m128 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpmovsdb xmm {k1}{z}, zmm","vpmovsdb xmm/m128 {k1}{z}, zmm")]
    vpmovsdb_xmm_k1z_zmm = 2732,
    /// <summary>
    /// vpmovsdb xmm/m128 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpmovsdb m128 {k1}{z}, zmm","vpmovsdb xmm/m128 {k1}{z}, zmm")]
    vpmovsdb_m128_k1z_zmm = 2733,
    /// <summary>
    /// vpmovsdb xmm/m32 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpmovsdb xmm {k1}{z}, xmm","vpmovsdb xmm/m32 {k1}{z}, xmm")]
    vpmovsdb_xmm_k1z_xmm = 2734,
    /// <summary>
    /// vpmovsdb xmm/m32 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpmovsdb m32 {k1}{z}, xmm","vpmovsdb xmm/m32 {k1}{z}, xmm")]
    vpmovsdb_m32_k1z_xmm = 2735,
    /// <summary>
    /// vpmovsdb xmm/m64 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpmovsdb xmm {k1}{z}, ymm","vpmovsdb xmm/m64 {k1}{z}, ymm")]
    vpmovsdb_xmm_k1z_ymm = 2736,
    /// <summary>
    /// vpmovsdb xmm/m64 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpmovsdb m64 {k1}{z}, ymm","vpmovsdb xmm/m64 {k1}{z}, ymm")]
    vpmovsdb_m64_k1z_ymm = 2737,
    /// <summary>
    /// vpmovsdw xmm/m128 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpmovsdw xmm {k1}{z}, ymm","vpmovsdw xmm/m128 {k1}{z}, ymm")]
    vpmovsdw_xmm_k1z_ymm = 2738,
    /// <summary>
    /// vpmovsdw xmm/m128 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpmovsdw m128 {k1}{z}, ymm","vpmovsdw xmm/m128 {k1}{z}, ymm")]
    vpmovsdw_m128_k1z_ymm = 2739,
    /// <summary>
    /// vpmovsdw xmm/m64 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpmovsdw xmm {k1}{z}, xmm","vpmovsdw xmm/m64 {k1}{z}, xmm")]
    vpmovsdw_xmm_k1z_xmm = 2740,
    /// <summary>
    /// vpmovsdw xmm/m64 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpmovsdw m64 {k1}{z}, xmm","vpmovsdw xmm/m64 {k1}{z}, xmm")]
    vpmovsdw_m64_k1z_xmm = 2741,
    /// <summary>
    /// vpmovsdw ymm/m256 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpmovsdw ymm {k1}{z}, zmm","vpmovsdw ymm/m256 {k1}{z}, zmm")]
    vpmovsdw_ymm_k1z_zmm = 2742,
    /// <summary>
    /// vpmovsdw ymm/m256 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpmovsdw m256 {k1}{z}, zmm","vpmovsdw ymm/m256 {k1}{z}, zmm")]
    vpmovsdw_m256_k1z_zmm = 2743,
    /// <summary>
    /// vpmovsqb xmm/m16 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpmovsqb xmm {k1}{z}, xmm","vpmovsqb xmm/m16 {k1}{z}, xmm")]
    vpmovsqb_xmm_k1z_xmm = 2744,
    /// <summary>
    /// vpmovsqb xmm/m16 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpmovsqb m16 {k1}{z}, xmm","vpmovsqb xmm/m16 {k1}{z}, xmm")]
    vpmovsqb_m16_k1z_xmm = 2745,
    /// <summary>
    /// vpmovsqb xmm/m32 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpmovsqb xmm {k1}{z}, ymm","vpmovsqb xmm/m32 {k1}{z}, ymm")]
    vpmovsqb_xmm_k1z_ymm = 2746,
    /// <summary>
    /// vpmovsqb xmm/m32 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpmovsqb m32 {k1}{z}, ymm","vpmovsqb xmm/m32 {k1}{z}, ymm")]
    vpmovsqb_m32_k1z_ymm = 2747,
    /// <summary>
    /// vpmovsqb xmm/m64 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpmovsqb xmm {k1}{z}, zmm","vpmovsqb xmm/m64 {k1}{z}, zmm")]
    vpmovsqb_xmm_k1z_zmm = 2748,
    /// <summary>
    /// vpmovsqb xmm/m64 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpmovsqb m64 {k1}{z}, zmm","vpmovsqb xmm/m64 {k1}{z}, zmm")]
    vpmovsqb_m64_k1z_zmm = 2749,
    /// <summary>
    /// vpmovsqd xmm/m128 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpmovsqd xmm {k1}{z}, ymm","vpmovsqd xmm/m128 {k1}{z}, ymm")]
    vpmovsqd_xmm_k1z_ymm = 2750,
    /// <summary>
    /// vpmovsqd xmm/m128 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpmovsqd m128 {k1}{z}, ymm","vpmovsqd xmm/m128 {k1}{z}, ymm")]
    vpmovsqd_m128_k1z_ymm = 2751,
    /// <summary>
    /// vpmovsqd xmm/m64 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpmovsqd xmm {k1}{z}, xmm","vpmovsqd xmm/m64 {k1}{z}, xmm")]
    vpmovsqd_xmm_k1z_xmm = 2752,
    /// <summary>
    /// vpmovsqd xmm/m64 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpmovsqd m64 {k1}{z}, xmm","vpmovsqd xmm/m64 {k1}{z}, xmm")]
    vpmovsqd_m64_k1z_xmm = 2753,
    /// <summary>
    /// vpmovsqd ymm/m256 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpmovsqd ymm {k1}{z}, zmm","vpmovsqd ymm/m256 {k1}{z}, zmm")]
    vpmovsqd_ymm_k1z_zmm = 2754,
    /// <summary>
    /// vpmovsqd ymm/m256 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpmovsqd m256 {k1}{z}, zmm","vpmovsqd ymm/m256 {k1}{z}, zmm")]
    vpmovsqd_m256_k1z_zmm = 2755,
    /// <summary>
    /// vpmovsqw xmm/m128 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpmovsqw xmm {k1}{z}, zmm","vpmovsqw xmm/m128 {k1}{z}, zmm")]
    vpmovsqw_xmm_k1z_zmm = 2756,
    /// <summary>
    /// vpmovsqw xmm/m128 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpmovsqw m128 {k1}{z}, zmm","vpmovsqw xmm/m128 {k1}{z}, zmm")]
    vpmovsqw_m128_k1z_zmm = 2757,
    /// <summary>
    /// vpmovsqw xmm/m32 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpmovsqw xmm {k1}{z}, xmm","vpmovsqw xmm/m32 {k1}{z}, xmm")]
    vpmovsqw_xmm_k1z_xmm = 2758,
    /// <summary>
    /// vpmovsqw xmm/m32 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpmovsqw m32 {k1}{z}, xmm","vpmovsqw xmm/m32 {k1}{z}, xmm")]
    vpmovsqw_m32_k1z_xmm = 2759,
    /// <summary>
    /// vpmovsqw xmm/m64 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpmovsqw xmm {k1}{z}, ymm","vpmovsqw xmm/m64 {k1}{z}, ymm")]
    vpmovsqw_xmm_k1z_ymm = 2760,
    /// <summary>
    /// vpmovsqw xmm/m64 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpmovsqw m64 {k1}{z}, ymm","vpmovsqw xmm/m64 {k1}{z}, ymm")]
    vpmovsqw_m64_k1z_ymm = 2761,
    /// <summary>
    /// vpmovswb xmm/m128 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpmovswb xmm {k1}{z}, ymm","vpmovswb xmm/m128 {k1}{z}, ymm")]
    vpmovswb_xmm_k1z_ymm = 2762,
    /// <summary>
    /// vpmovswb xmm/m128 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpmovswb m128 {k1}{z}, ymm","vpmovswb xmm/m128 {k1}{z}, ymm")]
    vpmovswb_m128_k1z_ymm = 2763,
    /// <summary>
    /// vpmovswb xmm/m64 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpmovswb xmm {k1}{z}, xmm","vpmovswb xmm/m64 {k1}{z}, xmm")]
    vpmovswb_xmm_k1z_xmm = 2764,
    /// <summary>
    /// vpmovswb xmm/m64 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpmovswb m64 {k1}{z}, xmm","vpmovswb xmm/m64 {k1}{z}, xmm")]
    vpmovswb_m64_k1z_xmm = 2765,
    /// <summary>
    /// vpmovswb ymm/m256 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpmovswb ymm {k1}{z}, zmm","vpmovswb ymm/m256 {k1}{z}, zmm")]
    vpmovswb_ymm_k1z_zmm = 2766,
    /// <summary>
    /// vpmovswb ymm/m256 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpmovswb m256 {k1}{z}, zmm","vpmovswb ymm/m256 {k1}{z}, zmm")]
    vpmovswb_m256_k1z_zmm = 2767,
    /// <summary>
    /// vpmovsxbd xmm {k1}{z}, xmm/m32
    /// </summary>
    [Symbol("vpmovsxbd xmm {k1}{z}, xmm","vpmovsxbd xmm {k1}{z}, xmm/m32")]
    vpmovsxbd_xmm_k1z_xmm = 2768,
    /// <summary>
    /// vpmovsxbd xmm {k1}{z}, xmm/m32
    /// </summary>
    [Symbol("vpmovsxbd xmm {k1}{z}, m32","vpmovsxbd xmm {k1}{z}, xmm/m32")]
    vpmovsxbd_xmm_k1z_m32 = 2769,
    /// <summary>
    /// vpmovsxbd xmm, xmm/m32
    /// </summary>
    [Symbol("vpmovsxbd xmm, xmm","vpmovsxbd xmm, xmm/m32")]
    vpmovsxbd_xmm_xmm = 2770,
    /// <summary>
    /// vpmovsxbd xmm, xmm/m32
    /// </summary>
    [Symbol("vpmovsxbd xmm, m32","vpmovsxbd xmm, xmm/m32")]
    vpmovsxbd_xmm_m32 = 2771,
    /// <summary>
    /// vpmovsxbd ymm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpmovsxbd ymm {k1}{z}, xmm","vpmovsxbd ymm {k1}{z}, xmm/m64")]
    vpmovsxbd_ymm_k1z_xmm = 2772,
    /// <summary>
    /// vpmovsxbd ymm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpmovsxbd ymm {k1}{z}, m64","vpmovsxbd ymm {k1}{z}, xmm/m64")]
    vpmovsxbd_ymm_k1z_m64 = 2773,
    /// <summary>
    /// vpmovsxbd ymm, xmm/m64
    /// </summary>
    [Symbol("vpmovsxbd ymm, xmm","vpmovsxbd ymm, xmm/m64")]
    vpmovsxbd_ymm_xmm = 2774,
    /// <summary>
    /// vpmovsxbd ymm, xmm/m64
    /// </summary>
    [Symbol("vpmovsxbd ymm, m64","vpmovsxbd ymm, xmm/m64")]
    vpmovsxbd_ymm_m64 = 2775,
    /// <summary>
    /// vpmovsxbd zmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vpmovsxbd zmm {k1}{z}, xmm","vpmovsxbd zmm {k1}{z}, xmm/m128")]
    vpmovsxbd_zmm_k1z_xmm = 2776,
    /// <summary>
    /// vpmovsxbd zmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vpmovsxbd zmm {k1}{z}, m128","vpmovsxbd zmm {k1}{z}, xmm/m128")]
    vpmovsxbd_zmm_k1z_m128 = 2777,
    /// <summary>
    /// vpmovsxbq xmm {k1}{z}, xmm/m16
    /// </summary>
    [Symbol("vpmovsxbq xmm {k1}{z}, xmm","vpmovsxbq xmm {k1}{z}, xmm/m16")]
    vpmovsxbq_xmm_k1z_xmm = 2778,
    /// <summary>
    /// vpmovsxbq xmm {k1}{z}, xmm/m16
    /// </summary>
    [Symbol("vpmovsxbq xmm {k1}{z}, m16","vpmovsxbq xmm {k1}{z}, xmm/m16")]
    vpmovsxbq_xmm_k1z_m16 = 2779,
    /// <summary>
    /// vpmovsxbq xmm, xmm/m16
    /// </summary>
    [Symbol("vpmovsxbq xmm, xmm","vpmovsxbq xmm, xmm/m16")]
    vpmovsxbq_xmm_xmm = 2780,
    /// <summary>
    /// vpmovsxbq xmm, xmm/m16
    /// </summary>
    [Symbol("vpmovsxbq xmm, m16","vpmovsxbq xmm, xmm/m16")]
    vpmovsxbq_xmm_m16 = 2781,
    /// <summary>
    /// vpmovsxbq ymm {k1}{z}, xmm/m32
    /// </summary>
    [Symbol("vpmovsxbq ymm {k1}{z}, xmm","vpmovsxbq ymm {k1}{z}, xmm/m32")]
    vpmovsxbq_ymm_k1z_xmm = 2782,
    /// <summary>
    /// vpmovsxbq ymm {k1}{z}, xmm/m32
    /// </summary>
    [Symbol("vpmovsxbq ymm {k1}{z}, m32","vpmovsxbq ymm {k1}{z}, xmm/m32")]
    vpmovsxbq_ymm_k1z_m32 = 2783,
    /// <summary>
    /// vpmovsxbq ymm, xmm/m32
    /// </summary>
    [Symbol("vpmovsxbq ymm, xmm","vpmovsxbq ymm, xmm/m32")]
    vpmovsxbq_ymm_xmm = 2784,
    /// <summary>
    /// vpmovsxbq ymm, xmm/m32
    /// </summary>
    [Symbol("vpmovsxbq ymm, m32","vpmovsxbq ymm, xmm/m32")]
    vpmovsxbq_ymm_m32 = 2785,
    /// <summary>
    /// vpmovsxbq zmm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpmovsxbq zmm {k1}{z}, xmm","vpmovsxbq zmm {k1}{z}, xmm/m64")]
    vpmovsxbq_zmm_k1z_xmm = 2786,
    /// <summary>
    /// vpmovsxbq zmm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpmovsxbq zmm {k1}{z}, m64","vpmovsxbq zmm {k1}{z}, xmm/m64")]
    vpmovsxbq_zmm_k1z_m64 = 2787,
    /// <summary>
    /// vpmovsxbw xmm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpmovsxbw xmm {k1}{z}, xmm","vpmovsxbw xmm {k1}{z}, xmm/m64")]
    vpmovsxbw_xmm_k1z_xmm = 2788,
    /// <summary>
    /// vpmovsxbw xmm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpmovsxbw xmm {k1}{z}, m64","vpmovsxbw xmm {k1}{z}, xmm/m64")]
    vpmovsxbw_xmm_k1z_m64 = 2789,
    /// <summary>
    /// vpmovsxbw xmm, xmm/m64
    /// </summary>
    [Symbol("vpmovsxbw xmm, xmm","vpmovsxbw xmm, xmm/m64")]
    vpmovsxbw_xmm_xmm = 2790,
    /// <summary>
    /// vpmovsxbw xmm, xmm/m64
    /// </summary>
    [Symbol("vpmovsxbw xmm, m64","vpmovsxbw xmm, xmm/m64")]
    vpmovsxbw_xmm_m64 = 2791,
    /// <summary>
    /// vpmovsxbw ymm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vpmovsxbw ymm {k1}{z}, xmm","vpmovsxbw ymm {k1}{z}, xmm/m128")]
    vpmovsxbw_ymm_k1z_xmm = 2792,
    /// <summary>
    /// vpmovsxbw ymm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vpmovsxbw ymm {k1}{z}, m128","vpmovsxbw ymm {k1}{z}, xmm/m128")]
    vpmovsxbw_ymm_k1z_m128 = 2793,
    /// <summary>
    /// vpmovsxbw ymm, xmm/m128
    /// </summary>
    [Symbol("vpmovsxbw ymm, xmm","vpmovsxbw ymm, xmm/m128")]
    vpmovsxbw_ymm_xmm = 2794,
    /// <summary>
    /// vpmovsxbw ymm, xmm/m128
    /// </summary>
    [Symbol("vpmovsxbw ymm, m128","vpmovsxbw ymm, xmm/m128")]
    vpmovsxbw_ymm_m128 = 2795,
    /// <summary>
    /// vpmovsxbw zmm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vpmovsxbw zmm {k1}{z}, ymm","vpmovsxbw zmm {k1}{z}, ymm/m256")]
    vpmovsxbw_zmm_k1z_ymm = 2796,
    /// <summary>
    /// vpmovsxbw zmm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vpmovsxbw zmm {k1}{z}, m256","vpmovsxbw zmm {k1}{z}, ymm/m256")]
    vpmovsxbw_zmm_k1z_m256 = 2797,
    /// <summary>
    /// vpmovsxdq xmm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpmovsxdq xmm {k1}{z}, xmm","vpmovsxdq xmm {k1}{z}, xmm/m64")]
    vpmovsxdq_xmm_k1z_xmm = 2798,
    /// <summary>
    /// vpmovsxdq xmm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpmovsxdq xmm {k1}{z}, m64","vpmovsxdq xmm {k1}{z}, xmm/m64")]
    vpmovsxdq_xmm_k1z_m64 = 2799,
    /// <summary>
    /// vpmovsxdq xmm, xmm/m64
    /// </summary>
    [Symbol("vpmovsxdq xmm, xmm","vpmovsxdq xmm, xmm/m64")]
    vpmovsxdq_xmm_xmm = 2800,
    /// <summary>
    /// vpmovsxdq xmm, xmm/m64
    /// </summary>
    [Symbol("vpmovsxdq xmm, m64","vpmovsxdq xmm, xmm/m64")]
    vpmovsxdq_xmm_m64 = 2801,
    /// <summary>
    /// vpmovsxdq ymm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vpmovsxdq ymm {k1}{z}, xmm","vpmovsxdq ymm {k1}{z}, xmm/m128")]
    vpmovsxdq_ymm_k1z_xmm = 2802,
    /// <summary>
    /// vpmovsxdq ymm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vpmovsxdq ymm {k1}{z}, m128","vpmovsxdq ymm {k1}{z}, xmm/m128")]
    vpmovsxdq_ymm_k1z_m128 = 2803,
    /// <summary>
    /// vpmovsxdq ymm, xmm/m128
    /// </summary>
    [Symbol("vpmovsxdq ymm, xmm","vpmovsxdq ymm, xmm/m128")]
    vpmovsxdq_ymm_xmm = 2804,
    /// <summary>
    /// vpmovsxdq ymm, xmm/m128
    /// </summary>
    [Symbol("vpmovsxdq ymm, m128","vpmovsxdq ymm, xmm/m128")]
    vpmovsxdq_ymm_m128 = 2805,
    /// <summary>
    /// vpmovsxdq zmm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vpmovsxdq zmm {k1}{z}, ymm","vpmovsxdq zmm {k1}{z}, ymm/m256")]
    vpmovsxdq_zmm_k1z_ymm = 2806,
    /// <summary>
    /// vpmovsxdq zmm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vpmovsxdq zmm {k1}{z}, m256","vpmovsxdq zmm {k1}{z}, ymm/m256")]
    vpmovsxdq_zmm_k1z_m256 = 2807,
    /// <summary>
    /// vpmovsxwd xmm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpmovsxwd xmm {k1}{z}, xmm","vpmovsxwd xmm {k1}{z}, xmm/m64")]
    vpmovsxwd_xmm_k1z_xmm = 2808,
    /// <summary>
    /// vpmovsxwd xmm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpmovsxwd xmm {k1}{z}, m64","vpmovsxwd xmm {k1}{z}, xmm/m64")]
    vpmovsxwd_xmm_k1z_m64 = 2809,
    /// <summary>
    /// vpmovsxwd xmm, xmm/m64
    /// </summary>
    [Symbol("vpmovsxwd xmm, xmm","vpmovsxwd xmm, xmm/m64")]
    vpmovsxwd_xmm_xmm = 2810,
    /// <summary>
    /// vpmovsxwd xmm, xmm/m64
    /// </summary>
    [Symbol("vpmovsxwd xmm, m64","vpmovsxwd xmm, xmm/m64")]
    vpmovsxwd_xmm_m64 = 2811,
    /// <summary>
    /// vpmovsxwd ymm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vpmovsxwd ymm {k1}{z}, xmm","vpmovsxwd ymm {k1}{z}, xmm/m128")]
    vpmovsxwd_ymm_k1z_xmm = 2812,
    /// <summary>
    /// vpmovsxwd ymm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vpmovsxwd ymm {k1}{z}, m128","vpmovsxwd ymm {k1}{z}, xmm/m128")]
    vpmovsxwd_ymm_k1z_m128 = 2813,
    /// <summary>
    /// vpmovsxwd ymm, xmm/m128
    /// </summary>
    [Symbol("vpmovsxwd ymm, xmm","vpmovsxwd ymm, xmm/m128")]
    vpmovsxwd_ymm_xmm = 2814,
    /// <summary>
    /// vpmovsxwd ymm, xmm/m128
    /// </summary>
    [Symbol("vpmovsxwd ymm, m128","vpmovsxwd ymm, xmm/m128")]
    vpmovsxwd_ymm_m128 = 2815,
    /// <summary>
    /// vpmovsxwd zmm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vpmovsxwd zmm {k1}{z}, ymm","vpmovsxwd zmm {k1}{z}, ymm/m256")]
    vpmovsxwd_zmm_k1z_ymm = 2816,
    /// <summary>
    /// vpmovsxwd zmm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vpmovsxwd zmm {k1}{z}, m256","vpmovsxwd zmm {k1}{z}, ymm/m256")]
    vpmovsxwd_zmm_k1z_m256 = 2817,
    /// <summary>
    /// vpmovsxwq xmm {k1}{z}, xmm/m32
    /// </summary>
    [Symbol("vpmovsxwq xmm {k1}{z}, xmm","vpmovsxwq xmm {k1}{z}, xmm/m32")]
    vpmovsxwq_xmm_k1z_xmm = 2818,
    /// <summary>
    /// vpmovsxwq xmm {k1}{z}, xmm/m32
    /// </summary>
    [Symbol("vpmovsxwq xmm {k1}{z}, m32","vpmovsxwq xmm {k1}{z}, xmm/m32")]
    vpmovsxwq_xmm_k1z_m32 = 2819,
    /// <summary>
    /// vpmovsxwq xmm, xmm/m32
    /// </summary>
    [Symbol("vpmovsxwq xmm, xmm","vpmovsxwq xmm, xmm/m32")]
    vpmovsxwq_xmm_xmm = 2820,
    /// <summary>
    /// vpmovsxwq xmm, xmm/m32
    /// </summary>
    [Symbol("vpmovsxwq xmm, m32","vpmovsxwq xmm, xmm/m32")]
    vpmovsxwq_xmm_m32 = 2821,
    /// <summary>
    /// vpmovsxwq ymm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpmovsxwq ymm {k1}{z}, xmm","vpmovsxwq ymm {k1}{z}, xmm/m64")]
    vpmovsxwq_ymm_k1z_xmm = 2822,
    /// <summary>
    /// vpmovsxwq ymm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpmovsxwq ymm {k1}{z}, m64","vpmovsxwq ymm {k1}{z}, xmm/m64")]
    vpmovsxwq_ymm_k1z_m64 = 2823,
    /// <summary>
    /// vpmovsxwq ymm, xmm/m64
    /// </summary>
    [Symbol("vpmovsxwq ymm, xmm","vpmovsxwq ymm, xmm/m64")]
    vpmovsxwq_ymm_xmm = 2824,
    /// <summary>
    /// vpmovsxwq ymm, xmm/m64
    /// </summary>
    [Symbol("vpmovsxwq ymm, m64","vpmovsxwq ymm, xmm/m64")]
    vpmovsxwq_ymm_m64 = 2825,
    /// <summary>
    /// vpmovsxwq zmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vpmovsxwq zmm {k1}{z}, xmm","vpmovsxwq zmm {k1}{z}, xmm/m128")]
    vpmovsxwq_zmm_k1z_xmm = 2826,
    /// <summary>
    /// vpmovsxwq zmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vpmovsxwq zmm {k1}{z}, m128","vpmovsxwq zmm {k1}{z}, xmm/m128")]
    vpmovsxwq_zmm_k1z_m128 = 2827,
    /// <summary>
    /// vpmovusdb xmm/m128 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpmovusdb xmm {k1}{z}, zmm","vpmovusdb xmm/m128 {k1}{z}, zmm")]
    vpmovusdb_xmm_k1z_zmm = 2828,
    /// <summary>
    /// vpmovusdb xmm/m128 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpmovusdb m128 {k1}{z}, zmm","vpmovusdb xmm/m128 {k1}{z}, zmm")]
    vpmovusdb_m128_k1z_zmm = 2829,
    /// <summary>
    /// vpmovusdb xmm/m32 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpmovusdb xmm {k1}{z}, xmm","vpmovusdb xmm/m32 {k1}{z}, xmm")]
    vpmovusdb_xmm_k1z_xmm = 2830,
    /// <summary>
    /// vpmovusdb xmm/m32 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpmovusdb m32 {k1}{z}, xmm","vpmovusdb xmm/m32 {k1}{z}, xmm")]
    vpmovusdb_m32_k1z_xmm = 2831,
    /// <summary>
    /// vpmovusdb xmm/m64 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpmovusdb xmm {k1}{z}, ymm","vpmovusdb xmm/m64 {k1}{z}, ymm")]
    vpmovusdb_xmm_k1z_ymm = 2832,
    /// <summary>
    /// vpmovusdb xmm/m64 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpmovusdb m64 {k1}{z}, ymm","vpmovusdb xmm/m64 {k1}{z}, ymm")]
    vpmovusdb_m64_k1z_ymm = 2833,
    /// <summary>
    /// vpmovusdw xmm/m128 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpmovusdw xmm {k1}{z}, ymm","vpmovusdw xmm/m128 {k1}{z}, ymm")]
    vpmovusdw_xmm_k1z_ymm = 2834,
    /// <summary>
    /// vpmovusdw xmm/m128 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpmovusdw m128 {k1}{z}, ymm","vpmovusdw xmm/m128 {k1}{z}, ymm")]
    vpmovusdw_m128_k1z_ymm = 2835,
    /// <summary>
    /// vpmovusdw xmm/m64 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpmovusdw xmm {k1}{z}, xmm","vpmovusdw xmm/m64 {k1}{z}, xmm")]
    vpmovusdw_xmm_k1z_xmm = 2836,
    /// <summary>
    /// vpmovusdw xmm/m64 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpmovusdw m64 {k1}{z}, xmm","vpmovusdw xmm/m64 {k1}{z}, xmm")]
    vpmovusdw_m64_k1z_xmm = 2837,
    /// <summary>
    /// vpmovusdw ymm/m256 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpmovusdw ymm {k1}{z}, zmm","vpmovusdw ymm/m256 {k1}{z}, zmm")]
    vpmovusdw_ymm_k1z_zmm = 2838,
    /// <summary>
    /// vpmovusdw ymm/m256 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpmovusdw m256 {k1}{z}, zmm","vpmovusdw ymm/m256 {k1}{z}, zmm")]
    vpmovusdw_m256_k1z_zmm = 2839,
    /// <summary>
    /// vpmovusqb xmm/m16 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpmovusqb xmm {k1}{z}, xmm","vpmovusqb xmm/m16 {k1}{z}, xmm")]
    vpmovusqb_xmm_k1z_xmm = 2840,
    /// <summary>
    /// vpmovusqb xmm/m16 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpmovusqb m16 {k1}{z}, xmm","vpmovusqb xmm/m16 {k1}{z}, xmm")]
    vpmovusqb_m16_k1z_xmm = 2841,
    /// <summary>
    /// vpmovusqb xmm/m32 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpmovusqb xmm {k1}{z}, ymm","vpmovusqb xmm/m32 {k1}{z}, ymm")]
    vpmovusqb_xmm_k1z_ymm = 2842,
    /// <summary>
    /// vpmovusqb xmm/m32 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpmovusqb m32 {k1}{z}, ymm","vpmovusqb xmm/m32 {k1}{z}, ymm")]
    vpmovusqb_m32_k1z_ymm = 2843,
    /// <summary>
    /// vpmovusqb xmm/m64 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpmovusqb xmm {k1}{z}, zmm","vpmovusqb xmm/m64 {k1}{z}, zmm")]
    vpmovusqb_xmm_k1z_zmm = 2844,
    /// <summary>
    /// vpmovusqb xmm/m64 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpmovusqb m64 {k1}{z}, zmm","vpmovusqb xmm/m64 {k1}{z}, zmm")]
    vpmovusqb_m64_k1z_zmm = 2845,
    /// <summary>
    /// vpmovusqd xmm/m128 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpmovusqd xmm {k1}{z}, ymm","vpmovusqd xmm/m128 {k1}{z}, ymm")]
    vpmovusqd_xmm_k1z_ymm = 2846,
    /// <summary>
    /// vpmovusqd xmm/m128 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpmovusqd m128 {k1}{z}, ymm","vpmovusqd xmm/m128 {k1}{z}, ymm")]
    vpmovusqd_m128_k1z_ymm = 2847,
    /// <summary>
    /// vpmovusqd xmm/m64 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpmovusqd xmm {k1}{z}, xmm","vpmovusqd xmm/m64 {k1}{z}, xmm")]
    vpmovusqd_xmm_k1z_xmm = 2848,
    /// <summary>
    /// vpmovusqd xmm/m64 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpmovusqd m64 {k1}{z}, xmm","vpmovusqd xmm/m64 {k1}{z}, xmm")]
    vpmovusqd_m64_k1z_xmm = 2849,
    /// <summary>
    /// vpmovusqd ymm/m256 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpmovusqd ymm {k1}{z}, zmm","vpmovusqd ymm/m256 {k1}{z}, zmm")]
    vpmovusqd_ymm_k1z_zmm = 2850,
    /// <summary>
    /// vpmovusqd ymm/m256 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpmovusqd m256 {k1}{z}, zmm","vpmovusqd ymm/m256 {k1}{z}, zmm")]
    vpmovusqd_m256_k1z_zmm = 2851,
    /// <summary>
    /// vpmovusqw xmm/m128 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpmovusqw xmm {k1}{z}, zmm","vpmovusqw xmm/m128 {k1}{z}, zmm")]
    vpmovusqw_xmm_k1z_zmm = 2852,
    /// <summary>
    /// vpmovusqw xmm/m128 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpmovusqw m128 {k1}{z}, zmm","vpmovusqw xmm/m128 {k1}{z}, zmm")]
    vpmovusqw_m128_k1z_zmm = 2853,
    /// <summary>
    /// vpmovusqw xmm/m32 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpmovusqw xmm {k1}{z}, xmm","vpmovusqw xmm/m32 {k1}{z}, xmm")]
    vpmovusqw_xmm_k1z_xmm = 2854,
    /// <summary>
    /// vpmovusqw xmm/m32 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpmovusqw m32 {k1}{z}, xmm","vpmovusqw xmm/m32 {k1}{z}, xmm")]
    vpmovusqw_m32_k1z_xmm = 2855,
    /// <summary>
    /// vpmovusqw xmm/m64 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpmovusqw xmm {k1}{z}, ymm","vpmovusqw xmm/m64 {k1}{z}, ymm")]
    vpmovusqw_xmm_k1z_ymm = 2856,
    /// <summary>
    /// vpmovusqw xmm/m64 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpmovusqw m64 {k1}{z}, ymm","vpmovusqw xmm/m64 {k1}{z}, ymm")]
    vpmovusqw_m64_k1z_ymm = 2857,
    /// <summary>
    /// vpmovuswb xmm/m128 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpmovuswb xmm {k1}{z}, ymm","vpmovuswb xmm/m128 {k1}{z}, ymm")]
    vpmovuswb_xmm_k1z_ymm = 2858,
    /// <summary>
    /// vpmovuswb xmm/m128 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpmovuswb m128 {k1}{z}, ymm","vpmovuswb xmm/m128 {k1}{z}, ymm")]
    vpmovuswb_m128_k1z_ymm = 2859,
    /// <summary>
    /// vpmovuswb xmm/m64 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpmovuswb xmm {k1}{z}, xmm","vpmovuswb xmm/m64 {k1}{z}, xmm")]
    vpmovuswb_xmm_k1z_xmm = 2860,
    /// <summary>
    /// vpmovuswb xmm/m64 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpmovuswb m64 {k1}{z}, xmm","vpmovuswb xmm/m64 {k1}{z}, xmm")]
    vpmovuswb_m64_k1z_xmm = 2861,
    /// <summary>
    /// vpmovuswb ymm/m256 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpmovuswb ymm {k1}{z}, zmm","vpmovuswb ymm/m256 {k1}{z}, zmm")]
    vpmovuswb_ymm_k1z_zmm = 2862,
    /// <summary>
    /// vpmovuswb ymm/m256 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpmovuswb m256 {k1}{z}, zmm","vpmovuswb ymm/m256 {k1}{z}, zmm")]
    vpmovuswb_m256_k1z_zmm = 2863,
    /// <summary>
    /// vpmovw2m k, xmm
    /// </summary>
    [Symbol("vpmovw2m k, xmm","vpmovw2m k, xmm")]
    vpmovw2m_k_xmm = 2864,
    /// <summary>
    /// vpmovw2m k, ymm
    /// </summary>
    [Symbol("vpmovw2m k, ymm","vpmovw2m k, ymm")]
    vpmovw2m_k_ymm = 2865,
    /// <summary>
    /// vpmovw2m k, zmm
    /// </summary>
    [Symbol("vpmovw2m k, zmm","vpmovw2m k, zmm")]
    vpmovw2m_k_zmm = 2866,
    /// <summary>
    /// vpmovwb xmm/m128 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpmovwb xmm {k1}{z}, ymm","vpmovwb xmm/m128 {k1}{z}, ymm")]
    vpmovwb_xmm_k1z_ymm = 2867,
    /// <summary>
    /// vpmovwb xmm/m128 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpmovwb m128 {k1}{z}, ymm","vpmovwb xmm/m128 {k1}{z}, ymm")]
    vpmovwb_m128_k1z_ymm = 2868,
    /// <summary>
    /// vpmovwb xmm/m64 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpmovwb xmm {k1}{z}, xmm","vpmovwb xmm/m64 {k1}{z}, xmm")]
    vpmovwb_xmm_k1z_xmm = 2869,
    /// <summary>
    /// vpmovwb xmm/m64 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpmovwb m64 {k1}{z}, xmm","vpmovwb xmm/m64 {k1}{z}, xmm")]
    vpmovwb_m64_k1z_xmm = 2870,
    /// <summary>
    /// vpmovwb ymm/m256 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpmovwb ymm {k1}{z}, zmm","vpmovwb ymm/m256 {k1}{z}, zmm")]
    vpmovwb_ymm_k1z_zmm = 2871,
    /// <summary>
    /// vpmovwb ymm/m256 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpmovwb m256 {k1}{z}, zmm","vpmovwb ymm/m256 {k1}{z}, zmm")]
    vpmovwb_m256_k1z_zmm = 2872,
    /// <summary>
    /// vpmovzxbd xmm {k1}{z}, xmm/m32
    /// </summary>
    [Symbol("vpmovzxbd xmm {k1}{z}, xmm","vpmovzxbd xmm {k1}{z}, xmm/m32")]
    vpmovzxbd_xmm_k1z_xmm = 2873,
    /// <summary>
    /// vpmovzxbd xmm {k1}{z}, xmm/m32
    /// </summary>
    [Symbol("vpmovzxbd xmm {k1}{z}, m32","vpmovzxbd xmm {k1}{z}, xmm/m32")]
    vpmovzxbd_xmm_k1z_m32 = 2874,
    /// <summary>
    /// vpmovzxbd xmm, xmm/m32
    /// </summary>
    [Symbol("vpmovzxbd xmm, xmm","vpmovzxbd xmm, xmm/m32")]
    vpmovzxbd_xmm_xmm = 2875,
    /// <summary>
    /// vpmovzxbd xmm, xmm/m32
    /// </summary>
    [Symbol("vpmovzxbd xmm, m32","vpmovzxbd xmm, xmm/m32")]
    vpmovzxbd_xmm_m32 = 2876,
    /// <summary>
    /// vpmovzxbd ymm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpmovzxbd ymm {k1}{z}, xmm","vpmovzxbd ymm {k1}{z}, xmm/m64")]
    vpmovzxbd_ymm_k1z_xmm = 2877,
    /// <summary>
    /// vpmovzxbd ymm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpmovzxbd ymm {k1}{z}, m64","vpmovzxbd ymm {k1}{z}, xmm/m64")]
    vpmovzxbd_ymm_k1z_m64 = 2878,
    /// <summary>
    /// vpmovzxbd ymm, xmm/m64
    /// </summary>
    [Symbol("vpmovzxbd ymm, xmm","vpmovzxbd ymm, xmm/m64")]
    vpmovzxbd_ymm_xmm = 2879,
    /// <summary>
    /// vpmovzxbd ymm, xmm/m64
    /// </summary>
    [Symbol("vpmovzxbd ymm, m64","vpmovzxbd ymm, xmm/m64")]
    vpmovzxbd_ymm_m64 = 2880,
    /// <summary>
    /// vpmovzxbd zmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vpmovzxbd zmm {k1}{z}, xmm","vpmovzxbd zmm {k1}{z}, xmm/m128")]
    vpmovzxbd_zmm_k1z_xmm = 2881,
    /// <summary>
    /// vpmovzxbd zmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vpmovzxbd zmm {k1}{z}, m128","vpmovzxbd zmm {k1}{z}, xmm/m128")]
    vpmovzxbd_zmm_k1z_m128 = 2882,
    /// <summary>
    /// vpmovzxbq xmm {k1}{z}, xmm/m16
    /// </summary>
    [Symbol("vpmovzxbq xmm {k1}{z}, xmm","vpmovzxbq xmm {k1}{z}, xmm/m16")]
    vpmovzxbq_xmm_k1z_xmm = 2883,
    /// <summary>
    /// vpmovzxbq xmm {k1}{z}, xmm/m16
    /// </summary>
    [Symbol("vpmovzxbq xmm {k1}{z}, m16","vpmovzxbq xmm {k1}{z}, xmm/m16")]
    vpmovzxbq_xmm_k1z_m16 = 2884,
    /// <summary>
    /// vpmovzxbq xmm, xmm/m16
    /// </summary>
    [Symbol("vpmovzxbq xmm, xmm","vpmovzxbq xmm, xmm/m16")]
    vpmovzxbq_xmm_xmm = 2885,
    /// <summary>
    /// vpmovzxbq xmm, xmm/m16
    /// </summary>
    [Symbol("vpmovzxbq xmm, m16","vpmovzxbq xmm, xmm/m16")]
    vpmovzxbq_xmm_m16 = 2886,
    /// <summary>
    /// vpmovzxbq ymm {k1}{z}, xmm/m32
    /// </summary>
    [Symbol("vpmovzxbq ymm {k1}{z}, xmm","vpmovzxbq ymm {k1}{z}, xmm/m32")]
    vpmovzxbq_ymm_k1z_xmm = 2887,
    /// <summary>
    /// vpmovzxbq ymm {k1}{z}, xmm/m32
    /// </summary>
    [Symbol("vpmovzxbq ymm {k1}{z}, m32","vpmovzxbq ymm {k1}{z}, xmm/m32")]
    vpmovzxbq_ymm_k1z_m32 = 2888,
    /// <summary>
    /// vpmovzxbq ymm, xmm/m32
    /// </summary>
    [Symbol("vpmovzxbq ymm, xmm","vpmovzxbq ymm, xmm/m32")]
    vpmovzxbq_ymm_xmm = 2889,
    /// <summary>
    /// vpmovzxbq ymm, xmm/m32
    /// </summary>
    [Symbol("vpmovzxbq ymm, m32","vpmovzxbq ymm, xmm/m32")]
    vpmovzxbq_ymm_m32 = 2890,
    /// <summary>
    /// vpmovzxbq zmm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpmovzxbq zmm {k1}{z}, xmm","vpmovzxbq zmm {k1}{z}, xmm/m64")]
    vpmovzxbq_zmm_k1z_xmm = 2891,
    /// <summary>
    /// vpmovzxbq zmm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpmovzxbq zmm {k1}{z}, m64","vpmovzxbq zmm {k1}{z}, xmm/m64")]
    vpmovzxbq_zmm_k1z_m64 = 2892,
    /// <summary>
    /// vpmovzxbw xmm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpmovzxbw xmm {k1}{z}, xmm","vpmovzxbw xmm {k1}{z}, xmm/m64")]
    vpmovzxbw_xmm_k1z_xmm = 2893,
    /// <summary>
    /// vpmovzxbw xmm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpmovzxbw xmm {k1}{z}, m64","vpmovzxbw xmm {k1}{z}, xmm/m64")]
    vpmovzxbw_xmm_k1z_m64 = 2894,
    /// <summary>
    /// vpmovzxbw xmm, xmm/m64
    /// </summary>
    [Symbol("vpmovzxbw xmm, xmm","vpmovzxbw xmm, xmm/m64")]
    vpmovzxbw_xmm_xmm = 2895,
    /// <summary>
    /// vpmovzxbw xmm, xmm/m64
    /// </summary>
    [Symbol("vpmovzxbw xmm, m64","vpmovzxbw xmm, xmm/m64")]
    vpmovzxbw_xmm_m64 = 2896,
    /// <summary>
    /// vpmovzxbw ymm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vpmovzxbw ymm {k1}{z}, xmm","vpmovzxbw ymm {k1}{z}, xmm/m128")]
    vpmovzxbw_ymm_k1z_xmm = 2897,
    /// <summary>
    /// vpmovzxbw ymm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vpmovzxbw ymm {k1}{z}, m128","vpmovzxbw ymm {k1}{z}, xmm/m128")]
    vpmovzxbw_ymm_k1z_m128 = 2898,
    /// <summary>
    /// vpmovzxbw ymm, xmm/m128
    /// </summary>
    [Symbol("vpmovzxbw ymm, xmm","vpmovzxbw ymm, xmm/m128")]
    vpmovzxbw_ymm_xmm = 2899,
    /// <summary>
    /// vpmovzxbw ymm, xmm/m128
    /// </summary>
    [Symbol("vpmovzxbw ymm, m128","vpmovzxbw ymm, xmm/m128")]
    vpmovzxbw_ymm_m128 = 2900,
    /// <summary>
    /// vpmovzxbw zmm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vpmovzxbw zmm {k1}{z}, ymm","vpmovzxbw zmm {k1}{z}, ymm/m256")]
    vpmovzxbw_zmm_k1z_ymm = 2901,
    /// <summary>
    /// vpmovzxbw zmm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vpmovzxbw zmm {k1}{z}, m256","vpmovzxbw zmm {k1}{z}, ymm/m256")]
    vpmovzxbw_zmm_k1z_m256 = 2902,
    /// <summary>
    /// vpmovzxdq xmm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpmovzxdq xmm {k1}{z}, xmm","vpmovzxdq xmm {k1}{z}, xmm/m64")]
    vpmovzxdq_xmm_k1z_xmm = 2903,
    /// <summary>
    /// vpmovzxdq xmm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpmovzxdq xmm {k1}{z}, m64","vpmovzxdq xmm {k1}{z}, xmm/m64")]
    vpmovzxdq_xmm_k1z_m64 = 2904,
    /// <summary>
    /// vpmovzxdq xmm, xmm/m64
    /// </summary>
    [Symbol("vpmovzxdq xmm, xmm","vpmovzxdq xmm, xmm/m64")]
    vpmovzxdq_xmm_xmm = 2905,
    /// <summary>
    /// vpmovzxdq xmm, xmm/m64
    /// </summary>
    [Symbol("vpmovzxdq xmm, m64","vpmovzxdq xmm, xmm/m64")]
    vpmovzxdq_xmm_m64 = 2906,
    /// <summary>
    /// vpmovzxdq ymm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vpmovzxdq ymm {k1}{z}, xmm","vpmovzxdq ymm {k1}{z}, xmm/m128")]
    vpmovzxdq_ymm_k1z_xmm = 2907,
    /// <summary>
    /// vpmovzxdq ymm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vpmovzxdq ymm {k1}{z}, m128","vpmovzxdq ymm {k1}{z}, xmm/m128")]
    vpmovzxdq_ymm_k1z_m128 = 2908,
    /// <summary>
    /// vpmovzxdq ymm, xmm/m128
    /// </summary>
    [Symbol("vpmovzxdq ymm, xmm","vpmovzxdq ymm, xmm/m128")]
    vpmovzxdq_ymm_xmm = 2909,
    /// <summary>
    /// vpmovzxdq ymm, xmm/m128
    /// </summary>
    [Symbol("vpmovzxdq ymm, m128","vpmovzxdq ymm, xmm/m128")]
    vpmovzxdq_ymm_m128 = 2910,
    /// <summary>
    /// vpmovzxdq zmm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vpmovzxdq zmm {k1}{z}, ymm","vpmovzxdq zmm {k1}{z}, ymm/m256")]
    vpmovzxdq_zmm_k1z_ymm = 2911,
    /// <summary>
    /// vpmovzxdq zmm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vpmovzxdq zmm {k1}{z}, m256","vpmovzxdq zmm {k1}{z}, ymm/m256")]
    vpmovzxdq_zmm_k1z_m256 = 2912,
    /// <summary>
    /// vpmovzxwd xmm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpmovzxwd xmm {k1}{z}, xmm","vpmovzxwd xmm {k1}{z}, xmm/m64")]
    vpmovzxwd_xmm_k1z_xmm = 2913,
    /// <summary>
    /// vpmovzxwd xmm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpmovzxwd xmm {k1}{z}, m64","vpmovzxwd xmm {k1}{z}, xmm/m64")]
    vpmovzxwd_xmm_k1z_m64 = 2914,
    /// <summary>
    /// vpmovzxwd xmm, xmm/m64
    /// </summary>
    [Symbol("vpmovzxwd xmm, xmm","vpmovzxwd xmm, xmm/m64")]
    vpmovzxwd_xmm_xmm = 2915,
    /// <summary>
    /// vpmovzxwd xmm, xmm/m64
    /// </summary>
    [Symbol("vpmovzxwd xmm, m64","vpmovzxwd xmm, xmm/m64")]
    vpmovzxwd_xmm_m64 = 2916,
    /// <summary>
    /// vpmovzxwd ymm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vpmovzxwd ymm {k1}{z}, xmm","vpmovzxwd ymm {k1}{z}, xmm/m128")]
    vpmovzxwd_ymm_k1z_xmm = 2917,
    /// <summary>
    /// vpmovzxwd ymm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vpmovzxwd ymm {k1}{z}, m128","vpmovzxwd ymm {k1}{z}, xmm/m128")]
    vpmovzxwd_ymm_k1z_m128 = 2918,
    /// <summary>
    /// vpmovzxwd ymm, xmm/m128
    /// </summary>
    [Symbol("vpmovzxwd ymm, xmm","vpmovzxwd ymm, xmm/m128")]
    vpmovzxwd_ymm_xmm = 2919,
    /// <summary>
    /// vpmovzxwd ymm, xmm/m128
    /// </summary>
    [Symbol("vpmovzxwd ymm, m128","vpmovzxwd ymm, xmm/m128")]
    vpmovzxwd_ymm_m128 = 2920,
    /// <summary>
    /// vpmovzxwd zmm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vpmovzxwd zmm {k1}{z}, ymm","vpmovzxwd zmm {k1}{z}, ymm/m256")]
    vpmovzxwd_zmm_k1z_ymm = 2921,
    /// <summary>
    /// vpmovzxwd zmm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vpmovzxwd zmm {k1}{z}, m256","vpmovzxwd zmm {k1}{z}, ymm/m256")]
    vpmovzxwd_zmm_k1z_m256 = 2922,
    /// <summary>
    /// vpmovzxwq xmm {k1}{z}, xmm/m32
    /// </summary>
    [Symbol("vpmovzxwq xmm {k1}{z}, xmm","vpmovzxwq xmm {k1}{z}, xmm/m32")]
    vpmovzxwq_xmm_k1z_xmm = 2923,
    /// <summary>
    /// vpmovzxwq xmm {k1}{z}, xmm/m32
    /// </summary>
    [Symbol("vpmovzxwq xmm {k1}{z}, m32","vpmovzxwq xmm {k1}{z}, xmm/m32")]
    vpmovzxwq_xmm_k1z_m32 = 2924,
    /// <summary>
    /// vpmovzxwq xmm, xmm/m32
    /// </summary>
    [Symbol("vpmovzxwq xmm, xmm","vpmovzxwq xmm, xmm/m32")]
    vpmovzxwq_xmm_xmm = 2925,
    /// <summary>
    /// vpmovzxwq xmm, xmm/m32
    /// </summary>
    [Symbol("vpmovzxwq xmm, m32","vpmovzxwq xmm, xmm/m32")]
    vpmovzxwq_xmm_m32 = 2926,
    /// <summary>
    /// vpmovzxwq ymm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpmovzxwq ymm {k1}{z}, xmm","vpmovzxwq ymm {k1}{z}, xmm/m64")]
    vpmovzxwq_ymm_k1z_xmm = 2927,
    /// <summary>
    /// vpmovzxwq ymm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpmovzxwq ymm {k1}{z}, m64","vpmovzxwq ymm {k1}{z}, xmm/m64")]
    vpmovzxwq_ymm_k1z_m64 = 2928,
    /// <summary>
    /// vpmovzxwq ymm, xmm/m64
    /// </summary>
    [Symbol("vpmovzxwq ymm, xmm","vpmovzxwq ymm, xmm/m64")]
    vpmovzxwq_ymm_xmm = 2929,
    /// <summary>
    /// vpmovzxwq ymm, xmm/m64
    /// </summary>
    [Symbol("vpmovzxwq ymm, m64","vpmovzxwq ymm, xmm/m64")]
    vpmovzxwq_ymm_m64 = 2930,
    /// <summary>
    /// vpmovzxwq zmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vpmovzxwq zmm {k1}{z}, xmm","vpmovzxwq zmm {k1}{z}, xmm/m128")]
    vpmovzxwq_zmm_k1z_xmm = 2931,
    /// <summary>
    /// vpmovzxwq zmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vpmovzxwq zmm {k1}{z}, m128","vpmovzxwq zmm {k1}{z}, xmm/m128")]
    vpmovzxwq_zmm_k1z_m128 = 2932,
    /// <summary>
    /// vpmulhuw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpmulhuw xmm {k1}{z}, xmm, xmm","vpmulhuw xmm {k1}{z}, xmm, xmm/m128")]
    vpmulhuw_xmm_k1z_xmm_xmm = 2933,
    /// <summary>
    /// vpmulhuw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpmulhuw xmm {k1}{z}, xmm, m128","vpmulhuw xmm {k1}{z}, xmm, xmm/m128")]
    vpmulhuw_xmm_k1z_xmm_m128 = 2934,
    /// <summary>
    /// vpmulhuw xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpmulhuw xmm, xmm, xmm","vpmulhuw xmm, xmm, xmm/m128")]
    vpmulhuw_xmm_xmm_xmm = 2935,
    /// <summary>
    /// vpmulhuw xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpmulhuw xmm, xmm, m128","vpmulhuw xmm, xmm, xmm/m128")]
    vpmulhuw_xmm_xmm_m128 = 2936,
    /// <summary>
    /// vpmulhuw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpmulhuw ymm {k1}{z}, ymm, ymm","vpmulhuw ymm {k1}{z}, ymm, ymm/m256")]
    vpmulhuw_ymm_k1z_ymm_ymm = 2937,
    /// <summary>
    /// vpmulhuw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpmulhuw ymm {k1}{z}, ymm, m256","vpmulhuw ymm {k1}{z}, ymm, ymm/m256")]
    vpmulhuw_ymm_k1z_ymm_m256 = 2938,
    /// <summary>
    /// vpmulhuw ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpmulhuw ymm, ymm, ymm","vpmulhuw ymm, ymm, ymm/m256")]
    vpmulhuw_ymm_ymm_ymm = 2939,
    /// <summary>
    /// vpmulhuw ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpmulhuw ymm, ymm, m256","vpmulhuw ymm, ymm, ymm/m256")]
    vpmulhuw_ymm_ymm_m256 = 2940,
    /// <summary>
    /// vpmulhuw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpmulhuw zmm {k1}{z}, zmm, zmm","vpmulhuw zmm {k1}{z}, zmm, zmm/m512")]
    vpmulhuw_zmm_k1z_zmm_zmm = 2941,
    /// <summary>
    /// vpmulhuw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpmulhuw zmm {k1}{z}, zmm, m512","vpmulhuw zmm {k1}{z}, zmm, zmm/m512")]
    vpmulhuw_zmm_k1z_zmm_m512 = 2942,
    /// <summary>
    /// vpmullw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpmullw xmm {k1}{z}, xmm, xmm","vpmullw xmm {k1}{z}, xmm, xmm/m128")]
    vpmullw_xmm_k1z_xmm_xmm = 2943,
    /// <summary>
    /// vpmullw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpmullw xmm {k1}{z}, xmm, m128","vpmullw xmm {k1}{z}, xmm, xmm/m128")]
    vpmullw_xmm_k1z_xmm_m128 = 2944,
    /// <summary>
    /// vpmullw xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpmullw xmm, xmm, xmm","vpmullw xmm, xmm, xmm/m128")]
    vpmullw_xmm_xmm_xmm = 2945,
    /// <summary>
    /// vpmullw xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpmullw xmm, xmm, m128","vpmullw xmm, xmm, xmm/m128")]
    vpmullw_xmm_xmm_m128 = 2946,
    /// <summary>
    /// vpmullw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpmullw ymm {k1}{z}, ymm, ymm","vpmullw ymm {k1}{z}, ymm, ymm/m256")]
    vpmullw_ymm_k1z_ymm_ymm = 2947,
    /// <summary>
    /// vpmullw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpmullw ymm {k1}{z}, ymm, m256","vpmullw ymm {k1}{z}, ymm, ymm/m256")]
    vpmullw_ymm_k1z_ymm_m256 = 2948,
    /// <summary>
    /// vpmullw ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpmullw ymm, ymm, ymm","vpmullw ymm, ymm, ymm/m256")]
    vpmullw_ymm_ymm_ymm = 2949,
    /// <summary>
    /// vpmullw ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpmullw ymm, ymm, m256","vpmullw ymm, ymm, ymm/m256")]
    vpmullw_ymm_ymm_m256 = 2950,
    /// <summary>
    /// vpmullw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpmullw zmm {k1}{z}, zmm, zmm","vpmullw zmm {k1}{z}, zmm, zmm/m512")]
    vpmullw_zmm_k1z_zmm_zmm = 2951,
    /// <summary>
    /// vpmullw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpmullw zmm {k1}{z}, zmm, m512","vpmullw zmm {k1}{z}, zmm, zmm/m512")]
    vpmullw_zmm_k1z_zmm_m512 = 2952,
    /// <summary>
    /// vpor xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpor xmm, xmm, xmm","vpor xmm, xmm, xmm/m128")]
    vpor_xmm_xmm_xmm = 2953,
    /// <summary>
    /// vpor xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpor xmm, xmm, m128","vpor xmm, xmm, xmm/m128")]
    vpor_xmm_xmm_m128 = 2954,
    /// <summary>
    /// vpor ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpor ymm, ymm, ymm","vpor ymm, ymm, ymm/m256")]
    vpor_ymm_ymm_ymm = 2955,
    /// <summary>
    /// vpor ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpor ymm, ymm, m256","vpor ymm, ymm, ymm/m256")]
    vpor_ymm_ymm_m256 = 2956,
    /// <summary>
    /// vpord xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpord xmm {k1}{z}, xmm, xmm","vpord xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpord_xmm_k1z_xmm_xmm = 2957,
    /// <summary>
    /// vpord xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpord xmm {k1}{z}, xmm, m128","vpord xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpord_xmm_k1z_xmm_m128 = 2958,
    /// <summary>
    /// vpord xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpord xmm {k1}{z}, xmm, m32bcst","vpord xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpord_xmm_k1z_xmm_m32bcst = 2959,
    /// <summary>
    /// vpord ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpord ymm {k1}{z}, ymm, ymm","vpord ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpord_ymm_k1z_ymm_ymm = 2960,
    /// <summary>
    /// vpord ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpord ymm {k1}{z}, ymm, m256","vpord ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpord_ymm_k1z_ymm_m256 = 2961,
    /// <summary>
    /// vpord ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpord ymm {k1}{z}, ymm, m32bcst","vpord ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpord_ymm_k1z_ymm_m32bcst = 2962,
    /// <summary>
    /// vpord zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpord zmm {k1}{z}, zmm, zmm","vpord zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpord_zmm_k1z_zmm_zmm = 2963,
    /// <summary>
    /// vpord zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpord zmm {k1}{z}, zmm, m512","vpord zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpord_zmm_k1z_zmm_m512 = 2964,
    /// <summary>
    /// vpord zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpord zmm {k1}{z}, zmm, m32bcst","vpord zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpord_zmm_k1z_zmm_m32bcst = 2965,
    /// <summary>
    /// vporq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vporq xmm {k1}{z}, xmm, xmm","vporq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vporq_xmm_k1z_xmm_xmm = 2966,
    /// <summary>
    /// vporq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vporq xmm {k1}{z}, xmm, m128","vporq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vporq_xmm_k1z_xmm_m128 = 2967,
    /// <summary>
    /// vporq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vporq xmm {k1}{z}, xmm, m64bcst","vporq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vporq_xmm_k1z_xmm_m64bcst = 2968,
    /// <summary>
    /// vporq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vporq ymm {k1}{z}, ymm, ymm","vporq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vporq_ymm_k1z_ymm_ymm = 2969,
    /// <summary>
    /// vporq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vporq ymm {k1}{z}, ymm, m256","vporq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vporq_ymm_k1z_ymm_m256 = 2970,
    /// <summary>
    /// vporq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vporq ymm {k1}{z}, ymm, m64bcst","vporq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vporq_ymm_k1z_ymm_m64bcst = 2971,
    /// <summary>
    /// vporq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vporq zmm {k1}{z}, zmm, zmm","vporq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vporq_zmm_k1z_zmm_zmm = 2972,
    /// <summary>
    /// vporq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vporq zmm {k1}{z}, zmm, m512","vporq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vporq_zmm_k1z_zmm_m512 = 2973,
    /// <summary>
    /// vporq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vporq zmm {k1}{z}, zmm, m64bcst","vporq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vporq_zmm_k1z_zmm_m64bcst = 2974,
    /// <summary>
    /// vprold xmm {k1}{z}, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vprold xmm {k1}{z}, xmm, imm8","vprold xmm {k1}{z}, xmm/m128/m32bcst, imm8")]
    vprold_xmm_k1z_xmm_imm8 = 2975,
    /// <summary>
    /// vprold xmm {k1}{z}, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vprold xmm {k1}{z}, m128, imm8","vprold xmm {k1}{z}, xmm/m128/m32bcst, imm8")]
    vprold_xmm_k1z_m128_imm8 = 2976,
    /// <summary>
    /// vprold xmm {k1}{z}, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vprold xmm {k1}{z}, m32bcst, imm8","vprold xmm {k1}{z}, xmm/m128/m32bcst, imm8")]
    vprold_xmm_k1z_m32bcst_imm8 = 2977,
    /// <summary>
    /// vprold ymm {k1}{z}, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vprold ymm {k1}{z}, ymm, imm8","vprold ymm {k1}{z}, ymm/m256/m32bcst, imm8")]
    vprold_ymm_k1z_ymm_imm8 = 2978,
    /// <summary>
    /// vprold ymm {k1}{z}, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vprold ymm {k1}{z}, m256, imm8","vprold ymm {k1}{z}, ymm/m256/m32bcst, imm8")]
    vprold_ymm_k1z_m256_imm8 = 2979,
    /// <summary>
    /// vprold ymm {k1}{z}, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vprold ymm {k1}{z}, m32bcst, imm8","vprold ymm {k1}{z}, ymm/m256/m32bcst, imm8")]
    vprold_ymm_k1z_m32bcst_imm8 = 2980,
    /// <summary>
    /// vprold zmm {k1}{z}, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vprold zmm {k1}{z}, zmm, imm8","vprold zmm {k1}{z}, zmm/m512/m32bcst, imm8")]
    vprold_zmm_k1z_zmm_imm8 = 2981,
    /// <summary>
    /// vprold zmm {k1}{z}, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vprold zmm {k1}{z}, m512, imm8","vprold zmm {k1}{z}, zmm/m512/m32bcst, imm8")]
    vprold_zmm_k1z_m512_imm8 = 2982,
    /// <summary>
    /// vprold zmm {k1}{z}, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vprold zmm {k1}{z}, m32bcst, imm8","vprold zmm {k1}{z}, zmm/m512/m32bcst, imm8")]
    vprold_zmm_k1z_m32bcst_imm8 = 2983,
    /// <summary>
    /// vprolq xmm {k1}{z}, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("vprolq xmm {k1}{z}, xmm, imm8","vprolq xmm {k1}{z}, xmm/m128/m64bcst, imm8")]
    vprolq_xmm_k1z_xmm_imm8 = 2984,
    /// <summary>
    /// vprolq xmm {k1}{z}, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("vprolq xmm {k1}{z}, m128, imm8","vprolq xmm {k1}{z}, xmm/m128/m64bcst, imm8")]
    vprolq_xmm_k1z_m128_imm8 = 2985,
    /// <summary>
    /// vprolq xmm {k1}{z}, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("vprolq xmm {k1}{z}, m64bcst, imm8","vprolq xmm {k1}{z}, xmm/m128/m64bcst, imm8")]
    vprolq_xmm_k1z_m64bcst_imm8 = 2986,
    /// <summary>
    /// vprolq ymm {k1}{z}, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vprolq ymm {k1}{z}, ymm, imm8","vprolq ymm {k1}{z}, ymm/m256/m64bcst, imm8")]
    vprolq_ymm_k1z_ymm_imm8 = 2987,
    /// <summary>
    /// vprolq ymm {k1}{z}, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vprolq ymm {k1}{z}, m256, imm8","vprolq ymm {k1}{z}, ymm/m256/m64bcst, imm8")]
    vprolq_ymm_k1z_m256_imm8 = 2988,
    /// <summary>
    /// vprolq ymm {k1}{z}, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vprolq ymm {k1}{z}, m64bcst, imm8","vprolq ymm {k1}{z}, ymm/m256/m64bcst, imm8")]
    vprolq_ymm_k1z_m64bcst_imm8 = 2989,
    /// <summary>
    /// vprolq zmm {k1}{z}, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vprolq zmm {k1}{z}, zmm, imm8","vprolq zmm {k1}{z}, zmm/m512/m64bcst, imm8")]
    vprolq_zmm_k1z_zmm_imm8 = 2990,
    /// <summary>
    /// vprolq zmm {k1}{z}, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vprolq zmm {k1}{z}, m512, imm8","vprolq zmm {k1}{z}, zmm/m512/m64bcst, imm8")]
    vprolq_zmm_k1z_m512_imm8 = 2991,
    /// <summary>
    /// vprolq zmm {k1}{z}, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vprolq zmm {k1}{z}, m64bcst, imm8","vprolq zmm {k1}{z}, zmm/m512/m64bcst, imm8")]
    vprolq_zmm_k1z_m64bcst_imm8 = 2992,
    /// <summary>
    /// vprolvd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vprolvd xmm {k1}{z}, xmm, xmm","vprolvd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vprolvd_xmm_k1z_xmm_xmm = 2993,
    /// <summary>
    /// vprolvd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vprolvd xmm {k1}{z}, xmm, m128","vprolvd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vprolvd_xmm_k1z_xmm_m128 = 2994,
    /// <summary>
    /// vprolvd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vprolvd xmm {k1}{z}, xmm, m32bcst","vprolvd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vprolvd_xmm_k1z_xmm_m32bcst = 2995,
    /// <summary>
    /// vprolvd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vprolvd ymm {k1}{z}, ymm, ymm","vprolvd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vprolvd_ymm_k1z_ymm_ymm = 2996,
    /// <summary>
    /// vprolvd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vprolvd ymm {k1}{z}, ymm, m256","vprolvd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vprolvd_ymm_k1z_ymm_m256 = 2997,
    /// <summary>
    /// vprolvd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vprolvd ymm {k1}{z}, ymm, m32bcst","vprolvd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vprolvd_ymm_k1z_ymm_m32bcst = 2998,
    /// <summary>
    /// vprolvd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vprolvd zmm {k1}{z}, zmm, zmm","vprolvd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vprolvd_zmm_k1z_zmm_zmm = 2999,
    /// <summary>
    /// vprolvd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vprolvd zmm {k1}{z}, zmm, m512","vprolvd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vprolvd_zmm_k1z_zmm_m512 = 3000,
    /// <summary>
    /// vprolvd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vprolvd zmm {k1}{z}, zmm, m32bcst","vprolvd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vprolvd_zmm_k1z_zmm_m32bcst = 3001,
    /// <summary>
    /// vprolvq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vprolvq xmm {k1}{z}, xmm, xmm","vprolvq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vprolvq_xmm_k1z_xmm_xmm = 3002,
    /// <summary>
    /// vprolvq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vprolvq xmm {k1}{z}, xmm, m128","vprolvq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vprolvq_xmm_k1z_xmm_m128 = 3003,
    /// <summary>
    /// vprolvq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vprolvq xmm {k1}{z}, xmm, m64bcst","vprolvq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vprolvq_xmm_k1z_xmm_m64bcst = 3004,
    /// <summary>
    /// vprolvq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vprolvq ymm {k1}{z}, ymm, ymm","vprolvq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vprolvq_ymm_k1z_ymm_ymm = 3005,
    /// <summary>
    /// vprolvq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vprolvq ymm {k1}{z}, ymm, m256","vprolvq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vprolvq_ymm_k1z_ymm_m256 = 3006,
    /// <summary>
    /// vprolvq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vprolvq ymm {k1}{z}, ymm, m64bcst","vprolvq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vprolvq_ymm_k1z_ymm_m64bcst = 3007,
    /// <summary>
    /// vprolvq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vprolvq zmm {k1}{z}, zmm, zmm","vprolvq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vprolvq_zmm_k1z_zmm_zmm = 3008,
    /// <summary>
    /// vprolvq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vprolvq zmm {k1}{z}, zmm, m512","vprolvq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vprolvq_zmm_k1z_zmm_m512 = 3009,
    /// <summary>
    /// vprolvq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vprolvq zmm {k1}{z}, zmm, m64bcst","vprolvq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vprolvq_zmm_k1z_zmm_m64bcst = 3010,
    /// <summary>
    /// vprord xmm {k1}{z}, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vprord xmm {k1}{z}, xmm, imm8","vprord xmm {k1}{z}, xmm/m128/m32bcst, imm8")]
    vprord_xmm_k1z_xmm_imm8 = 3011,
    /// <summary>
    /// vprord xmm {k1}{z}, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vprord xmm {k1}{z}, m128, imm8","vprord xmm {k1}{z}, xmm/m128/m32bcst, imm8")]
    vprord_xmm_k1z_m128_imm8 = 3012,
    /// <summary>
    /// vprord xmm {k1}{z}, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vprord xmm {k1}{z}, m32bcst, imm8","vprord xmm {k1}{z}, xmm/m128/m32bcst, imm8")]
    vprord_xmm_k1z_m32bcst_imm8 = 3013,
    /// <summary>
    /// vprord ymm {k1}{z}, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vprord ymm {k1}{z}, ymm, imm8","vprord ymm {k1}{z}, ymm/m256/m32bcst, imm8")]
    vprord_ymm_k1z_ymm_imm8 = 3014,
    /// <summary>
    /// vprord ymm {k1}{z}, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vprord ymm {k1}{z}, m256, imm8","vprord ymm {k1}{z}, ymm/m256/m32bcst, imm8")]
    vprord_ymm_k1z_m256_imm8 = 3015,
    /// <summary>
    /// vprord ymm {k1}{z}, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vprord ymm {k1}{z}, m32bcst, imm8","vprord ymm {k1}{z}, ymm/m256/m32bcst, imm8")]
    vprord_ymm_k1z_m32bcst_imm8 = 3016,
    /// <summary>
    /// vprord zmm {k1}{z}, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vprord zmm {k1}{z}, zmm, imm8","vprord zmm {k1}{z}, zmm/m512/m32bcst, imm8")]
    vprord_zmm_k1z_zmm_imm8 = 3017,
    /// <summary>
    /// vprord zmm {k1}{z}, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vprord zmm {k1}{z}, m512, imm8","vprord zmm {k1}{z}, zmm/m512/m32bcst, imm8")]
    vprord_zmm_k1z_m512_imm8 = 3018,
    /// <summary>
    /// vprord zmm {k1}{z}, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vprord zmm {k1}{z}, m32bcst, imm8","vprord zmm {k1}{z}, zmm/m512/m32bcst, imm8")]
    vprord_zmm_k1z_m32bcst_imm8 = 3019,
    /// <summary>
    /// vprorq xmm {k1}{z}, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("vprorq xmm {k1}{z}, xmm, imm8","vprorq xmm {k1}{z}, xmm/m128/m64bcst, imm8")]
    vprorq_xmm_k1z_xmm_imm8 = 3020,
    /// <summary>
    /// vprorq xmm {k1}{z}, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("vprorq xmm {k1}{z}, m128, imm8","vprorq xmm {k1}{z}, xmm/m128/m64bcst, imm8")]
    vprorq_xmm_k1z_m128_imm8 = 3021,
    /// <summary>
    /// vprorq xmm {k1}{z}, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("vprorq xmm {k1}{z}, m64bcst, imm8","vprorq xmm {k1}{z}, xmm/m128/m64bcst, imm8")]
    vprorq_xmm_k1z_m64bcst_imm8 = 3022,
    /// <summary>
    /// vprorq ymm {k1}{z}, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vprorq ymm {k1}{z}, ymm, imm8","vprorq ymm {k1}{z}, ymm/m256/m64bcst, imm8")]
    vprorq_ymm_k1z_ymm_imm8 = 3023,
    /// <summary>
    /// vprorq ymm {k1}{z}, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vprorq ymm {k1}{z}, m256, imm8","vprorq ymm {k1}{z}, ymm/m256/m64bcst, imm8")]
    vprorq_ymm_k1z_m256_imm8 = 3024,
    /// <summary>
    /// vprorq ymm {k1}{z}, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vprorq ymm {k1}{z}, m64bcst, imm8","vprorq ymm {k1}{z}, ymm/m256/m64bcst, imm8")]
    vprorq_ymm_k1z_m64bcst_imm8 = 3025,
    /// <summary>
    /// vprorq zmm {k1}{z}, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vprorq zmm {k1}{z}, zmm, imm8","vprorq zmm {k1}{z}, zmm/m512/m64bcst, imm8")]
    vprorq_zmm_k1z_zmm_imm8 = 3026,
    /// <summary>
    /// vprorq zmm {k1}{z}, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vprorq zmm {k1}{z}, m512, imm8","vprorq zmm {k1}{z}, zmm/m512/m64bcst, imm8")]
    vprorq_zmm_k1z_m512_imm8 = 3027,
    /// <summary>
    /// vprorq zmm {k1}{z}, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vprorq zmm {k1}{z}, m64bcst, imm8","vprorq zmm {k1}{z}, zmm/m512/m64bcst, imm8")]
    vprorq_zmm_k1z_m64bcst_imm8 = 3028,
    /// <summary>
    /// vprorvd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vprorvd xmm {k1}{z}, xmm, xmm","vprorvd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vprorvd_xmm_k1z_xmm_xmm = 3029,
    /// <summary>
    /// vprorvd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vprorvd xmm {k1}{z}, xmm, m128","vprorvd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vprorvd_xmm_k1z_xmm_m128 = 3030,
    /// <summary>
    /// vprorvd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vprorvd xmm {k1}{z}, xmm, m32bcst","vprorvd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vprorvd_xmm_k1z_xmm_m32bcst = 3031,
    /// <summary>
    /// vprorvd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vprorvd ymm {k1}{z}, ymm, ymm","vprorvd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vprorvd_ymm_k1z_ymm_ymm = 3032,
    /// <summary>
    /// vprorvd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vprorvd ymm {k1}{z}, ymm, m256","vprorvd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vprorvd_ymm_k1z_ymm_m256 = 3033,
    /// <summary>
    /// vprorvd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vprorvd ymm {k1}{z}, ymm, m32bcst","vprorvd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vprorvd_ymm_k1z_ymm_m32bcst = 3034,
    /// <summary>
    /// vprorvd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vprorvd zmm {k1}{z}, zmm, zmm","vprorvd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vprorvd_zmm_k1z_zmm_zmm = 3035,
    /// <summary>
    /// vprorvd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vprorvd zmm {k1}{z}, zmm, m512","vprorvd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vprorvd_zmm_k1z_zmm_m512 = 3036,
    /// <summary>
    /// vprorvd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vprorvd zmm {k1}{z}, zmm, m32bcst","vprorvd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vprorvd_zmm_k1z_zmm_m32bcst = 3037,
    /// <summary>
    /// vprorvq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vprorvq xmm {k1}{z}, xmm, xmm","vprorvq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vprorvq_xmm_k1z_xmm_xmm = 3038,
    /// <summary>
    /// vprorvq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vprorvq xmm {k1}{z}, xmm, m128","vprorvq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vprorvq_xmm_k1z_xmm_m128 = 3039,
    /// <summary>
    /// vprorvq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vprorvq xmm {k1}{z}, xmm, m64bcst","vprorvq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vprorvq_xmm_k1z_xmm_m64bcst = 3040,
    /// <summary>
    /// vprorvq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vprorvq ymm {k1}{z}, ymm, ymm","vprorvq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vprorvq_ymm_k1z_ymm_ymm = 3041,
    /// <summary>
    /// vprorvq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vprorvq ymm {k1}{z}, ymm, m256","vprorvq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vprorvq_ymm_k1z_ymm_m256 = 3042,
    /// <summary>
    /// vprorvq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vprorvq ymm {k1}{z}, ymm, m64bcst","vprorvq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vprorvq_ymm_k1z_ymm_m64bcst = 3043,
    /// <summary>
    /// vprorvq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vprorvq zmm {k1}{z}, zmm, zmm","vprorvq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vprorvq_zmm_k1z_zmm_zmm = 3044,
    /// <summary>
    /// vprorvq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vprorvq zmm {k1}{z}, zmm, m512","vprorvq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vprorvq_zmm_k1z_zmm_m512 = 3045,
    /// <summary>
    /// vprorvq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vprorvq zmm {k1}{z}, zmm, m64bcst","vprorvq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vprorvq_zmm_k1z_zmm_m64bcst = 3046,
    /// <summary>
    /// vpscatterdd vm32x {k1}, xmm
    /// </summary>
    [Symbol("vpscatterdd vm32x {k1}, xmm","vpscatterdd vm32x {k1}, xmm")]
    vpscatterdd_vm32x_k1_xmm = 3047,
    /// <summary>
    /// vpscatterdd vm32y {k1}, ymm
    /// </summary>
    [Symbol("vpscatterdd vm32y {k1}, ymm","vpscatterdd vm32y {k1}, ymm")]
    vpscatterdd_vm32y_k1_ymm = 3048,
    /// <summary>
    /// vpscatterdd vm32z {k1}, zmm
    /// </summary>
    [Symbol("vpscatterdd vm32z {k1}, zmm","vpscatterdd vm32z {k1}, zmm")]
    vpscatterdd_vm32z_k1_zmm = 3049,
    /// <summary>
    /// vpscatterdq vm32x {k1}, xmm
    /// </summary>
    [Symbol("vpscatterdq vm32x {k1}, xmm","vpscatterdq vm32x {k1}, xmm")]
    vpscatterdq_vm32x_k1_xmm = 3050,
    /// <summary>
    /// vpscatterdq vm32x {k1}, ymm
    /// </summary>
    [Symbol("vpscatterdq vm32x {k1}, ymm","vpscatterdq vm32x {k1}, ymm")]
    vpscatterdq_vm32x_k1_ymm = 3051,
    /// <summary>
    /// vpscatterdq vm32y {k1}, zmm
    /// </summary>
    [Symbol("vpscatterdq vm32y {k1}, zmm","vpscatterdq vm32y {k1}, zmm")]
    vpscatterdq_vm32y_k1_zmm = 3052,
    /// <summary>
    /// vpscatterqd vm64x {k1}, xmm
    /// </summary>
    [Symbol("vpscatterqd vm64x {k1}, xmm","vpscatterqd vm64x {k1}, xmm")]
    vpscatterqd_vm64x_k1_xmm = 3053,
    /// <summary>
    /// vpscatterqd vm64y {k1}, xmm
    /// </summary>
    [Symbol("vpscatterqd vm64y {k1}, xmm","vpscatterqd vm64y {k1}, xmm")]
    vpscatterqd_vm64y_k1_xmm = 3054,
    /// <summary>
    /// vpscatterqd vm64z {k1}, ymm
    /// </summary>
    [Symbol("vpscatterqd vm64z {k1}, ymm","vpscatterqd vm64z {k1}, ymm")]
    vpscatterqd_vm64z_k1_ymm = 3055,
    /// <summary>
    /// vpscatterqq vm64x {k1}, xmm
    /// </summary>
    [Symbol("vpscatterqq vm64x {k1}, xmm","vpscatterqq vm64x {k1}, xmm")]
    vpscatterqq_vm64x_k1_xmm = 3056,
    /// <summary>
    /// vpscatterqq vm64y {k1}, ymm
    /// </summary>
    [Symbol("vpscatterqq vm64y {k1}, ymm","vpscatterqq vm64y {k1}, ymm")]
    vpscatterqq_vm64y_k1_ymm = 3057,
    /// <summary>
    /// vpscatterqq vm64z {k1}, zmm
    /// </summary>
    [Symbol("vpscatterqq vm64z {k1}, zmm","vpscatterqq vm64z {k1}, zmm")]
    vpscatterqq_vm64z_k1_zmm = 3058,
    /// <summary>
    /// vpshufb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpshufb xmm {k1}{z}, xmm, xmm","vpshufb xmm {k1}{z}, xmm, xmm/m128")]
    vpshufb_xmm_k1z_xmm_xmm = 3059,
    /// <summary>
    /// vpshufb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpshufb xmm {k1}{z}, xmm, m128","vpshufb xmm {k1}{z}, xmm, xmm/m128")]
    vpshufb_xmm_k1z_xmm_m128 = 3060,
    /// <summary>
    /// vpshufb xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpshufb xmm, xmm, xmm","vpshufb xmm, xmm, xmm/m128")]
    vpshufb_xmm_xmm_xmm = 3061,
    /// <summary>
    /// vpshufb xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpshufb xmm, xmm, m128","vpshufb xmm, xmm, xmm/m128")]
    vpshufb_xmm_xmm_m128 = 3062,
    /// <summary>
    /// vpshufb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpshufb ymm {k1}{z}, ymm, ymm","vpshufb ymm {k1}{z}, ymm, ymm/m256")]
    vpshufb_ymm_k1z_ymm_ymm = 3063,
    /// <summary>
    /// vpshufb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpshufb ymm {k1}{z}, ymm, m256","vpshufb ymm {k1}{z}, ymm, ymm/m256")]
    vpshufb_ymm_k1z_ymm_m256 = 3064,
    /// <summary>
    /// vpshufb ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpshufb ymm, ymm, ymm","vpshufb ymm, ymm, ymm/m256")]
    vpshufb_ymm_ymm_ymm = 3065,
    /// <summary>
    /// vpshufb ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpshufb ymm, ymm, m256","vpshufb ymm, ymm, ymm/m256")]
    vpshufb_ymm_ymm_m256 = 3066,
    /// <summary>
    /// vpshufb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpshufb zmm {k1}{z}, zmm, zmm","vpshufb zmm {k1}{z}, zmm, zmm/m512")]
    vpshufb_zmm_k1z_zmm_zmm = 3067,
    /// <summary>
    /// vpshufb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpshufb zmm {k1}{z}, zmm, m512","vpshufb zmm {k1}{z}, zmm, zmm/m512")]
    vpshufb_zmm_k1z_zmm_m512 = 3068,
    /// <summary>
    /// vpshufd xmm {k1}{z}, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vpshufd xmm {k1}{z}, xmm, imm8","vpshufd xmm {k1}{z}, xmm/m128/m32bcst, imm8")]
    vpshufd_xmm_k1z_xmm_imm8 = 3069,
    /// <summary>
    /// vpshufd xmm {k1}{z}, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vpshufd xmm {k1}{z}, m128, imm8","vpshufd xmm {k1}{z}, xmm/m128/m32bcst, imm8")]
    vpshufd_xmm_k1z_m128_imm8 = 3070,
    /// <summary>
    /// vpshufd xmm {k1}{z}, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vpshufd xmm {k1}{z}, m32bcst, imm8","vpshufd xmm {k1}{z}, xmm/m128/m32bcst, imm8")]
    vpshufd_xmm_k1z_m32bcst_imm8 = 3071,
    /// <summary>
    /// vpshufd xmm, xmm/m128, imm8
    /// </summary>
    [Symbol("vpshufd xmm, xmm, imm8","vpshufd xmm, xmm/m128, imm8")]
    vpshufd_xmm_xmm_imm8 = 3072,
    /// <summary>
    /// vpshufd xmm, xmm/m128, imm8
    /// </summary>
    [Symbol("vpshufd xmm, m128, imm8","vpshufd xmm, xmm/m128, imm8")]
    vpshufd_xmm_m128_imm8 = 3073,
    /// <summary>
    /// vpshufd ymm {k1}{z}, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vpshufd ymm {k1}{z}, ymm, imm8","vpshufd ymm {k1}{z}, ymm/m256/m32bcst, imm8")]
    vpshufd_ymm_k1z_ymm_imm8 = 3074,
    /// <summary>
    /// vpshufd ymm {k1}{z}, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vpshufd ymm {k1}{z}, m256, imm8","vpshufd ymm {k1}{z}, ymm/m256/m32bcst, imm8")]
    vpshufd_ymm_k1z_m256_imm8 = 3075,
    /// <summary>
    /// vpshufd ymm {k1}{z}, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vpshufd ymm {k1}{z}, m32bcst, imm8","vpshufd ymm {k1}{z}, ymm/m256/m32bcst, imm8")]
    vpshufd_ymm_k1z_m32bcst_imm8 = 3076,
    /// <summary>
    /// vpshufd ymm, ymm/m256, imm8
    /// </summary>
    [Symbol("vpshufd ymm, ymm, imm8","vpshufd ymm, ymm/m256, imm8")]
    vpshufd_ymm_ymm_imm8 = 3077,
    /// <summary>
    /// vpshufd ymm, ymm/m256, imm8
    /// </summary>
    [Symbol("vpshufd ymm, m256, imm8","vpshufd ymm, ymm/m256, imm8")]
    vpshufd_ymm_m256_imm8 = 3078,
    /// <summary>
    /// vpshufd zmm {k1}{z}, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vpshufd zmm {k1}{z}, zmm, imm8","vpshufd zmm {k1}{z}, zmm/m512/m32bcst, imm8")]
    vpshufd_zmm_k1z_zmm_imm8 = 3079,
    /// <summary>
    /// vpshufd zmm {k1}{z}, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vpshufd zmm {k1}{z}, m512, imm8","vpshufd zmm {k1}{z}, zmm/m512/m32bcst, imm8")]
    vpshufd_zmm_k1z_m512_imm8 = 3080,
    /// <summary>
    /// vpshufd zmm {k1}{z}, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vpshufd zmm {k1}{z}, m32bcst, imm8","vpshufd zmm {k1}{z}, zmm/m512/m32bcst, imm8")]
    vpshufd_zmm_k1z_m32bcst_imm8 = 3081,
    /// <summary>
    /// vpshuflw xmm {k1}{z}, xmm/m128, imm8
    /// </summary>
    [Symbol("vpshuflw xmm {k1}{z}, xmm, imm8","vpshuflw xmm {k1}{z}, xmm/m128, imm8")]
    vpshuflw_xmm_k1z_xmm_imm8 = 3082,
    /// <summary>
    /// vpshuflw xmm {k1}{z}, xmm/m128, imm8
    /// </summary>
    [Symbol("vpshuflw xmm {k1}{z}, m128, imm8","vpshuflw xmm {k1}{z}, xmm/m128, imm8")]
    vpshuflw_xmm_k1z_m128_imm8 = 3083,
    /// <summary>
    /// vpshuflw xmm, xmm/m128, imm8
    /// </summary>
    [Symbol("vpshuflw xmm, xmm, imm8","vpshuflw xmm, xmm/m128, imm8")]
    vpshuflw_xmm_xmm_imm8 = 3084,
    /// <summary>
    /// vpshuflw xmm, xmm/m128, imm8
    /// </summary>
    [Symbol("vpshuflw xmm, m128, imm8","vpshuflw xmm, xmm/m128, imm8")]
    vpshuflw_xmm_m128_imm8 = 3085,
    /// <summary>
    /// vpshuflw ymm {k1}{z}, ymm/m256, imm8
    /// </summary>
    [Symbol("vpshuflw ymm {k1}{z}, ymm, imm8","vpshuflw ymm {k1}{z}, ymm/m256, imm8")]
    vpshuflw_ymm_k1z_ymm_imm8 = 3086,
    /// <summary>
    /// vpshuflw ymm {k1}{z}, ymm/m256, imm8
    /// </summary>
    [Symbol("vpshuflw ymm {k1}{z}, m256, imm8","vpshuflw ymm {k1}{z}, ymm/m256, imm8")]
    vpshuflw_ymm_k1z_m256_imm8 = 3087,
    /// <summary>
    /// vpshuflw ymm, ymm/m256, imm8
    /// </summary>
    [Symbol("vpshuflw ymm, ymm, imm8","vpshuflw ymm, ymm/m256, imm8")]
    vpshuflw_ymm_ymm_imm8 = 3088,
    /// <summary>
    /// vpshuflw ymm, ymm/m256, imm8
    /// </summary>
    [Symbol("vpshuflw ymm, m256, imm8","vpshuflw ymm, ymm/m256, imm8")]
    vpshuflw_ymm_m256_imm8 = 3089,
    /// <summary>
    /// vpshuflw zmm {k1}{z}, zmm/m512, imm8
    /// </summary>
    [Symbol("vpshuflw zmm {k1}{z}, zmm, imm8","vpshuflw zmm {k1}{z}, zmm/m512, imm8")]
    vpshuflw_zmm_k1z_zmm_imm8 = 3090,
    /// <summary>
    /// vpshuflw zmm {k1}{z}, zmm/m512, imm8
    /// </summary>
    [Symbol("vpshuflw zmm {k1}{z}, m512, imm8","vpshuflw zmm {k1}{z}, zmm/m512, imm8")]
    vpshuflw_zmm_k1z_m512_imm8 = 3091,
    /// <summary>
    /// vpsignb xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsignb xmm, xmm, xmm","vpsignb xmm, xmm, xmm/m128")]
    vpsignb_xmm_xmm_xmm = 3092,
    /// <summary>
    /// vpsignb xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsignb xmm, xmm, m128","vpsignb xmm, xmm, xmm/m128")]
    vpsignb_xmm_xmm_m128 = 3093,
    /// <summary>
    /// vpsignb ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsignb ymm, ymm, ymm","vpsignb ymm, ymm, ymm/m256")]
    vpsignb_ymm_ymm_ymm = 3094,
    /// <summary>
    /// vpsignb ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsignb ymm, ymm, m256","vpsignb ymm, ymm, ymm/m256")]
    vpsignb_ymm_ymm_m256 = 3095,
    /// <summary>
    /// vpsignd xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsignd xmm, xmm, xmm","vpsignd xmm, xmm, xmm/m128")]
    vpsignd_xmm_xmm_xmm = 3096,
    /// <summary>
    /// vpsignd xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsignd xmm, xmm, m128","vpsignd xmm, xmm, xmm/m128")]
    vpsignd_xmm_xmm_m128 = 3097,
    /// <summary>
    /// vpsignd ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsignd ymm, ymm, ymm","vpsignd ymm, ymm, ymm/m256")]
    vpsignd_ymm_ymm_ymm = 3098,
    /// <summary>
    /// vpsignd ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsignd ymm, ymm, m256","vpsignd ymm, ymm, ymm/m256")]
    vpsignd_ymm_ymm_m256 = 3099,
    /// <summary>
    /// vpsignw xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsignw xmm, xmm, xmm","vpsignw xmm, xmm, xmm/m128")]
    vpsignw_xmm_xmm_xmm = 3100,
    /// <summary>
    /// vpsignw xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsignw xmm, xmm, m128","vpsignw xmm, xmm, xmm/m128")]
    vpsignw_xmm_xmm_m128 = 3101,
    /// <summary>
    /// vpsignw ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsignw ymm, ymm, ymm","vpsignw ymm, ymm, ymm/m256")]
    vpsignw_ymm_ymm_ymm = 3102,
    /// <summary>
    /// vpsignw ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsignw ymm, ymm, m256","vpsignw ymm, ymm, ymm/m256")]
    vpsignw_ymm_ymm_m256 = 3103,
    /// <summary>
    /// vpslld xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpslld xmm {k1}{z}, xmm, xmm","vpslld xmm {k1}{z}, xmm, xmm/m128")]
    vpslld_xmm_k1z_xmm_xmm = 3104,
    /// <summary>
    /// vpslld xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpslld xmm {k1}{z}, xmm, m128","vpslld xmm {k1}{z}, xmm, xmm/m128")]
    vpslld_xmm_k1z_xmm_m128 = 3105,
    /// <summary>
    /// vpslld xmm {k1}{z}, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vpslld xmm {k1}{z}, xmm, imm8","vpslld xmm {k1}{z}, xmm/m128/m32bcst, imm8")]
    vpslld_xmm_k1z_xmm_imm8 = 3106,
    /// <summary>
    /// vpslld xmm {k1}{z}, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vpslld xmm {k1}{z}, m128, imm8","vpslld xmm {k1}{z}, xmm/m128/m32bcst, imm8")]
    vpslld_xmm_k1z_m128_imm8 = 3107,
    /// <summary>
    /// vpslld xmm {k1}{z}, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vpslld xmm {k1}{z}, m32bcst, imm8","vpslld xmm {k1}{z}, xmm/m128/m32bcst, imm8")]
    vpslld_xmm_k1z_m32bcst_imm8 = 3108,
    /// <summary>
    /// vpslld xmm, xmm, imm8
    /// </summary>
    [Symbol("vpslld xmm, xmm, imm8","vpslld xmm, xmm, imm8")]
    vpslld_xmm_xmm_imm8 = 3109,
    /// <summary>
    /// vpslld xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpslld xmm, xmm, xmm","vpslld xmm, xmm, xmm/m128")]
    vpslld_xmm_xmm_xmm = 3110,
    /// <summary>
    /// vpslld xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpslld xmm, xmm, m128","vpslld xmm, xmm, xmm/m128")]
    vpslld_xmm_xmm_m128 = 3111,
    /// <summary>
    /// vpslld ymm {k1}{z}, ymm, xmm/m128
    /// </summary>
    [Symbol("vpslld ymm {k1}{z}, ymm, xmm","vpslld ymm {k1}{z}, ymm, xmm/m128")]
    vpslld_ymm_k1z_ymm_xmm = 3112,
    /// <summary>
    /// vpslld ymm {k1}{z}, ymm, xmm/m128
    /// </summary>
    [Symbol("vpslld ymm {k1}{z}, ymm, m128","vpslld ymm {k1}{z}, ymm, xmm/m128")]
    vpslld_ymm_k1z_ymm_m128 = 3113,
    /// <summary>
    /// vpslld ymm {k1}{z}, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vpslld ymm {k1}{z}, ymm, imm8","vpslld ymm {k1}{z}, ymm/m256/m32bcst, imm8")]
    vpslld_ymm_k1z_ymm_imm8 = 3114,
    /// <summary>
    /// vpslld ymm {k1}{z}, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vpslld ymm {k1}{z}, m256, imm8","vpslld ymm {k1}{z}, ymm/m256/m32bcst, imm8")]
    vpslld_ymm_k1z_m256_imm8 = 3115,
    /// <summary>
    /// vpslld ymm {k1}{z}, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vpslld ymm {k1}{z}, m32bcst, imm8","vpslld ymm {k1}{z}, ymm/m256/m32bcst, imm8")]
    vpslld_ymm_k1z_m32bcst_imm8 = 3116,
    /// <summary>
    /// vpslld ymm, ymm, imm8
    /// </summary>
    [Symbol("vpslld ymm, ymm, imm8","vpslld ymm, ymm, imm8")]
    vpslld_ymm_ymm_imm8 = 3117,
    /// <summary>
    /// vpslld ymm, ymm, xmm/m128
    /// </summary>
    [Symbol("vpslld ymm, ymm, xmm","vpslld ymm, ymm, xmm/m128")]
    vpslld_ymm_ymm_xmm = 3118,
    /// <summary>
    /// vpslld ymm, ymm, xmm/m128
    /// </summary>
    [Symbol("vpslld ymm, ymm, m128","vpslld ymm, ymm, xmm/m128")]
    vpslld_ymm_ymm_m128 = 3119,
    /// <summary>
    /// vpslld zmm {k1}{z}, zmm, xmm/m128
    /// </summary>
    [Symbol("vpslld zmm {k1}{z}, zmm, xmm","vpslld zmm {k1}{z}, zmm, xmm/m128")]
    vpslld_zmm_k1z_zmm_xmm = 3120,
    /// <summary>
    /// vpslld zmm {k1}{z}, zmm, xmm/m128
    /// </summary>
    [Symbol("vpslld zmm {k1}{z}, zmm, m128","vpslld zmm {k1}{z}, zmm, xmm/m128")]
    vpslld_zmm_k1z_zmm_m128 = 3121,
    /// <summary>
    /// vpslld zmm {k1}{z}, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vpslld zmm {k1}{z}, zmm, imm8","vpslld zmm {k1}{z}, zmm/m512/m32bcst, imm8")]
    vpslld_zmm_k1z_zmm_imm8 = 3122,
    /// <summary>
    /// vpslld zmm {k1}{z}, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vpslld zmm {k1}{z}, m512, imm8","vpslld zmm {k1}{z}, zmm/m512/m32bcst, imm8")]
    vpslld_zmm_k1z_m512_imm8 = 3123,
    /// <summary>
    /// vpslld zmm {k1}{z}, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vpslld zmm {k1}{z}, m32bcst, imm8","vpslld zmm {k1}{z}, zmm/m512/m32bcst, imm8")]
    vpslld_zmm_k1z_m32bcst_imm8 = 3124,
    /// <summary>
    /// vpslldq xmm, xmm, imm8
    /// </summary>
    [Symbol("vpslldq xmm, xmm, imm8","vpslldq xmm, xmm, imm8")]
    vpslldq_xmm_xmm_imm8 = 3125,
    /// <summary>
    /// vpslldq xmm, xmm/m128, imm8
    /// </summary>
    [Symbol("vpslldq xmm, m128, imm8","vpslldq xmm, xmm/m128, imm8")]
    vpslldq_xmm_m128_imm8 = 3126,
    /// <summary>
    /// vpslldq ymm, ymm, imm8
    /// </summary>
    [Symbol("vpslldq ymm, ymm, imm8","vpslldq ymm, ymm, imm8")]
    vpslldq_ymm_ymm_imm8 = 3127,
    /// <summary>
    /// vpslldq ymm, ymm/m256, imm8
    /// </summary>
    [Symbol("vpslldq ymm, m256, imm8","vpslldq ymm, ymm/m256, imm8")]
    vpslldq_ymm_m256_imm8 = 3128,
    /// <summary>
    /// vpslldq zmm, zmm/m512, imm8
    /// </summary>
    [Symbol("vpslldq zmm, zmm, imm8","vpslldq zmm, zmm/m512, imm8")]
    vpslldq_zmm_zmm_imm8 = 3129,
    /// <summary>
    /// vpslldq zmm, zmm/m512, imm8
    /// </summary>
    [Symbol("vpslldq zmm, m512, imm8","vpslldq zmm, zmm/m512, imm8")]
    vpslldq_zmm_m512_imm8 = 3130,
    /// <summary>
    /// vpsllq xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsllq xmm {k1}{z}, xmm, xmm","vpsllq xmm {k1}{z}, xmm, xmm/m128")]
    vpsllq_xmm_k1z_xmm_xmm = 3131,
    /// <summary>
    /// vpsllq xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsllq xmm {k1}{z}, xmm, m128","vpsllq xmm {k1}{z}, xmm, xmm/m128")]
    vpsllq_xmm_k1z_xmm_m128 = 3132,
    /// <summary>
    /// vpsllq xmm {k1}{z}, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("vpsllq xmm {k1}{z}, xmm, imm8","vpsllq xmm {k1}{z}, xmm/m128/m64bcst, imm8")]
    vpsllq_xmm_k1z_xmm_imm8 = 3133,
    /// <summary>
    /// vpsllq xmm {k1}{z}, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("vpsllq xmm {k1}{z}, m128, imm8","vpsllq xmm {k1}{z}, xmm/m128/m64bcst, imm8")]
    vpsllq_xmm_k1z_m128_imm8 = 3134,
    /// <summary>
    /// vpsllq xmm {k1}{z}, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("vpsllq xmm {k1}{z}, m64bcst, imm8","vpsllq xmm {k1}{z}, xmm/m128/m64bcst, imm8")]
    vpsllq_xmm_k1z_m64bcst_imm8 = 3135,
    /// <summary>
    /// vpsllq xmm, xmm, imm8
    /// </summary>
    [Symbol("vpsllq xmm, xmm, imm8","vpsllq xmm, xmm, imm8")]
    vpsllq_xmm_xmm_imm8 = 3136,
    /// <summary>
    /// vpsllq xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsllq xmm, xmm, xmm","vpsllq xmm, xmm, xmm/m128")]
    vpsllq_xmm_xmm_xmm = 3137,
    /// <summary>
    /// vpsllq xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsllq xmm, xmm, m128","vpsllq xmm, xmm, xmm/m128")]
    vpsllq_xmm_xmm_m128 = 3138,
    /// <summary>
    /// vpsllq ymm {k1}{z}, ymm, xmm/m128
    /// </summary>
    [Symbol("vpsllq ymm {k1}{z}, ymm, xmm","vpsllq ymm {k1}{z}, ymm, xmm/m128")]
    vpsllq_ymm_k1z_ymm_xmm = 3139,
    /// <summary>
    /// vpsllq ymm {k1}{z}, ymm, xmm/m128
    /// </summary>
    [Symbol("vpsllq ymm {k1}{z}, ymm, m128","vpsllq ymm {k1}{z}, ymm, xmm/m128")]
    vpsllq_ymm_k1z_ymm_m128 = 3140,
    /// <summary>
    /// vpsllq ymm {k1}{z}, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vpsllq ymm {k1}{z}, ymm, imm8","vpsllq ymm {k1}{z}, ymm/m256/m64bcst, imm8")]
    vpsllq_ymm_k1z_ymm_imm8 = 3141,
    /// <summary>
    /// vpsllq ymm {k1}{z}, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vpsllq ymm {k1}{z}, m256, imm8","vpsllq ymm {k1}{z}, ymm/m256/m64bcst, imm8")]
    vpsllq_ymm_k1z_m256_imm8 = 3142,
    /// <summary>
    /// vpsllq ymm {k1}{z}, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vpsllq ymm {k1}{z}, m64bcst, imm8","vpsllq ymm {k1}{z}, ymm/m256/m64bcst, imm8")]
    vpsllq_ymm_k1z_m64bcst_imm8 = 3143,
    /// <summary>
    /// vpsllq ymm, ymm, imm8
    /// </summary>
    [Symbol("vpsllq ymm, ymm, imm8","vpsllq ymm, ymm, imm8")]
    vpsllq_ymm_ymm_imm8 = 3144,
    /// <summary>
    /// vpsllq ymm, ymm, xmm/m128
    /// </summary>
    [Symbol("vpsllq ymm, ymm, xmm","vpsllq ymm, ymm, xmm/m128")]
    vpsllq_ymm_ymm_xmm = 3145,
    /// <summary>
    /// vpsllq ymm, ymm, xmm/m128
    /// </summary>
    [Symbol("vpsllq ymm, ymm, m128","vpsllq ymm, ymm, xmm/m128")]
    vpsllq_ymm_ymm_m128 = 3146,
    /// <summary>
    /// vpsllq zmm {k1}{z}, zmm, xmm/m128
    /// </summary>
    [Symbol("vpsllq zmm {k1}{z}, zmm, xmm","vpsllq zmm {k1}{z}, zmm, xmm/m128")]
    vpsllq_zmm_k1z_zmm_xmm = 3147,
    /// <summary>
    /// vpsllq zmm {k1}{z}, zmm, xmm/m128
    /// </summary>
    [Symbol("vpsllq zmm {k1}{z}, zmm, m128","vpsllq zmm {k1}{z}, zmm, xmm/m128")]
    vpsllq_zmm_k1z_zmm_m128 = 3148,
    /// <summary>
    /// vpsllq zmm {k1}{z}, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vpsllq zmm {k1}{z}, zmm, imm8","vpsllq zmm {k1}{z}, zmm/m512/m64bcst, imm8")]
    vpsllq_zmm_k1z_zmm_imm8 = 3149,
    /// <summary>
    /// vpsllq zmm {k1}{z}, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vpsllq zmm {k1}{z}, m512, imm8","vpsllq zmm {k1}{z}, zmm/m512/m64bcst, imm8")]
    vpsllq_zmm_k1z_m512_imm8 = 3150,
    /// <summary>
    /// vpsllq zmm {k1}{z}, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vpsllq zmm {k1}{z}, m64bcst, imm8","vpsllq zmm {k1}{z}, zmm/m512/m64bcst, imm8")]
    vpsllq_zmm_k1z_m64bcst_imm8 = 3151,
    /// <summary>
    /// vpsllvd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpsllvd xmm {k1}{z}, xmm, xmm","vpsllvd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpsllvd_xmm_k1z_xmm_xmm = 3152,
    /// <summary>
    /// vpsllvd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpsllvd xmm {k1}{z}, xmm, m128","vpsllvd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpsllvd_xmm_k1z_xmm_m128 = 3153,
    /// <summary>
    /// vpsllvd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpsllvd xmm {k1}{z}, xmm, m32bcst","vpsllvd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpsllvd_xmm_k1z_xmm_m32bcst = 3154,
    /// <summary>
    /// vpsllvd xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsllvd xmm, xmm, xmm","vpsllvd xmm, xmm, xmm/m128")]
    vpsllvd_xmm_xmm_xmm = 3155,
    /// <summary>
    /// vpsllvd xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsllvd xmm, xmm, m128","vpsllvd xmm, xmm, xmm/m128")]
    vpsllvd_xmm_xmm_m128 = 3156,
    /// <summary>
    /// vpsllvd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpsllvd ymm {k1}{z}, ymm, ymm","vpsllvd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpsllvd_ymm_k1z_ymm_ymm = 3157,
    /// <summary>
    /// vpsllvd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpsllvd ymm {k1}{z}, ymm, m256","vpsllvd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpsllvd_ymm_k1z_ymm_m256 = 3158,
    /// <summary>
    /// vpsllvd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpsllvd ymm {k1}{z}, ymm, m32bcst","vpsllvd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpsllvd_ymm_k1z_ymm_m32bcst = 3159,
    /// <summary>
    /// vpsllvd ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsllvd ymm, ymm, ymm","vpsllvd ymm, ymm, ymm/m256")]
    vpsllvd_ymm_ymm_ymm = 3160,
    /// <summary>
    /// vpsllvd ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsllvd ymm, ymm, m256","vpsllvd ymm, ymm, ymm/m256")]
    vpsllvd_ymm_ymm_m256 = 3161,
    /// <summary>
    /// vpsllvd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpsllvd zmm {k1}{z}, zmm, zmm","vpsllvd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpsllvd_zmm_k1z_zmm_zmm = 3162,
    /// <summary>
    /// vpsllvd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpsllvd zmm {k1}{z}, zmm, m512","vpsllvd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpsllvd_zmm_k1z_zmm_m512 = 3163,
    /// <summary>
    /// vpsllvd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpsllvd zmm {k1}{z}, zmm, m32bcst","vpsllvd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpsllvd_zmm_k1z_zmm_m32bcst = 3164,
    /// <summary>
    /// vpsllvq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpsllvq xmm {k1}{z}, xmm, xmm","vpsllvq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpsllvq_xmm_k1z_xmm_xmm = 3165,
    /// <summary>
    /// vpsllvq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpsllvq xmm {k1}{z}, xmm, m128","vpsllvq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpsllvq_xmm_k1z_xmm_m128 = 3166,
    /// <summary>
    /// vpsllvq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpsllvq xmm {k1}{z}, xmm, m64bcst","vpsllvq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpsllvq_xmm_k1z_xmm_m64bcst = 3167,
    /// <summary>
    /// vpsllvq xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsllvq xmm, xmm, xmm","vpsllvq xmm, xmm, xmm/m128")]
    vpsllvq_xmm_xmm_xmm = 3168,
    /// <summary>
    /// vpsllvq xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsllvq xmm, xmm, m128","vpsllvq xmm, xmm, xmm/m128")]
    vpsllvq_xmm_xmm_m128 = 3169,
    /// <summary>
    /// vpsllvq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpsllvq ymm {k1}{z}, ymm, ymm","vpsllvq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpsllvq_ymm_k1z_ymm_ymm = 3170,
    /// <summary>
    /// vpsllvq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpsllvq ymm {k1}{z}, ymm, m256","vpsllvq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpsllvq_ymm_k1z_ymm_m256 = 3171,
    /// <summary>
    /// vpsllvq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpsllvq ymm {k1}{z}, ymm, m64bcst","vpsllvq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpsllvq_ymm_k1z_ymm_m64bcst = 3172,
    /// <summary>
    /// vpsllvq ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsllvq ymm, ymm, ymm","vpsllvq ymm, ymm, ymm/m256")]
    vpsllvq_ymm_ymm_ymm = 3173,
    /// <summary>
    /// vpsllvq ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsllvq ymm, ymm, m256","vpsllvq ymm, ymm, ymm/m256")]
    vpsllvq_ymm_ymm_m256 = 3174,
    /// <summary>
    /// vpsllvq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpsllvq zmm {k1}{z}, zmm, zmm","vpsllvq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpsllvq_zmm_k1z_zmm_zmm = 3175,
    /// <summary>
    /// vpsllvq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpsllvq zmm {k1}{z}, zmm, m512","vpsllvq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpsllvq_zmm_k1z_zmm_m512 = 3176,
    /// <summary>
    /// vpsllvq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpsllvq zmm {k1}{z}, zmm, m64bcst","vpsllvq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpsllvq_zmm_k1z_zmm_m64bcst = 3177,
    /// <summary>
    /// vpsllvw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsllvw xmm {k1}{z}, xmm, xmm","vpsllvw xmm {k1}{z}, xmm, xmm/m128")]
    vpsllvw_xmm_k1z_xmm_xmm = 3178,
    /// <summary>
    /// vpsllvw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsllvw xmm {k1}{z}, xmm, m128","vpsllvw xmm {k1}{z}, xmm, xmm/m128")]
    vpsllvw_xmm_k1z_xmm_m128 = 3179,
    /// <summary>
    /// vpsllvw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsllvw ymm {k1}{z}, ymm, ymm","vpsllvw ymm {k1}{z}, ymm, ymm/m256")]
    vpsllvw_ymm_k1z_ymm_ymm = 3180,
    /// <summary>
    /// vpsllvw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsllvw ymm {k1}{z}, ymm, m256","vpsllvw ymm {k1}{z}, ymm, ymm/m256")]
    vpsllvw_ymm_k1z_ymm_m256 = 3181,
    /// <summary>
    /// vpsllvw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpsllvw zmm {k1}{z}, zmm, zmm","vpsllvw zmm {k1}{z}, zmm, zmm/m512")]
    vpsllvw_zmm_k1z_zmm_zmm = 3182,
    /// <summary>
    /// vpsllvw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpsllvw zmm {k1}{z}, zmm, m512","vpsllvw zmm {k1}{z}, zmm, zmm/m512")]
    vpsllvw_zmm_k1z_zmm_m512 = 3183,
    /// <summary>
    /// vpsllw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsllw xmm {k1}{z}, xmm, xmm","vpsllw xmm {k1}{z}, xmm, xmm/m128")]
    vpsllw_xmm_k1z_xmm_xmm = 3184,
    /// <summary>
    /// vpsllw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsllw xmm {k1}{z}, xmm, m128","vpsllw xmm {k1}{z}, xmm, xmm/m128")]
    vpsllw_xmm_k1z_xmm_m128 = 3185,
    /// <summary>
    /// vpsllw xmm {k1}{z}, xmm/m128, imm8
    /// </summary>
    [Symbol("vpsllw xmm {k1}{z}, xmm, imm8","vpsllw xmm {k1}{z}, xmm/m128, imm8")]
    vpsllw_xmm_k1z_xmm_imm8 = 3186,
    /// <summary>
    /// vpsllw xmm {k1}{z}, xmm/m128, imm8
    /// </summary>
    [Symbol("vpsllw xmm {k1}{z}, m128, imm8","vpsllw xmm {k1}{z}, xmm/m128, imm8")]
    vpsllw_xmm_k1z_m128_imm8 = 3187,
    /// <summary>
    /// vpsllw xmm, xmm, imm8
    /// </summary>
    [Symbol("vpsllw xmm, xmm, imm8","vpsllw xmm, xmm, imm8")]
    vpsllw_xmm_xmm_imm8 = 3188,
    /// <summary>
    /// vpsllw xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsllw xmm, xmm, xmm","vpsllw xmm, xmm, xmm/m128")]
    vpsllw_xmm_xmm_xmm = 3189,
    /// <summary>
    /// vpsllw xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsllw xmm, xmm, m128","vpsllw xmm, xmm, xmm/m128")]
    vpsllw_xmm_xmm_m128 = 3190,
    /// <summary>
    /// vpsllw ymm {k1}{z}, ymm, xmm/m128
    /// </summary>
    [Symbol("vpsllw ymm {k1}{z}, ymm, xmm","vpsllw ymm {k1}{z}, ymm, xmm/m128")]
    vpsllw_ymm_k1z_ymm_xmm = 3191,
    /// <summary>
    /// vpsllw ymm {k1}{z}, ymm, xmm/m128
    /// </summary>
    [Symbol("vpsllw ymm {k1}{z}, ymm, m128","vpsllw ymm {k1}{z}, ymm, xmm/m128")]
    vpsllw_ymm_k1z_ymm_m128 = 3192,
    /// <summary>
    /// vpsllw ymm {k1}{z}, ymm/m256, imm8
    /// </summary>
    [Symbol("vpsllw ymm {k1}{z}, ymm, imm8","vpsllw ymm {k1}{z}, ymm/m256, imm8")]
    vpsllw_ymm_k1z_ymm_imm8 = 3193,
    /// <summary>
    /// vpsllw ymm {k1}{z}, ymm/m256, imm8
    /// </summary>
    [Symbol("vpsllw ymm {k1}{z}, m256, imm8","vpsllw ymm {k1}{z}, ymm/m256, imm8")]
    vpsllw_ymm_k1z_m256_imm8 = 3194,
    /// <summary>
    /// vpsllw ymm, ymm, imm8
    /// </summary>
    [Symbol("vpsllw ymm, ymm, imm8","vpsllw ymm, ymm, imm8")]
    vpsllw_ymm_ymm_imm8 = 3195,
    /// <summary>
    /// vpsllw ymm, ymm, xmm/m128
    /// </summary>
    [Symbol("vpsllw ymm, ymm, xmm","vpsllw ymm, ymm, xmm/m128")]
    vpsllw_ymm_ymm_xmm = 3196,
    /// <summary>
    /// vpsllw ymm, ymm, xmm/m128
    /// </summary>
    [Symbol("vpsllw ymm, ymm, m128","vpsllw ymm, ymm, xmm/m128")]
    vpsllw_ymm_ymm_m128 = 3197,
    /// <summary>
    /// vpsllw zmm {k1}{z}, zmm, xmm/m128
    /// </summary>
    [Symbol("vpsllw zmm {k1}{z}, zmm, xmm","vpsllw zmm {k1}{z}, zmm, xmm/m128")]
    vpsllw_zmm_k1z_zmm_xmm = 3198,
    /// <summary>
    /// vpsllw zmm {k1}{z}, zmm, xmm/m128
    /// </summary>
    [Symbol("vpsllw zmm {k1}{z}, zmm, m128","vpsllw zmm {k1}{z}, zmm, xmm/m128")]
    vpsllw_zmm_k1z_zmm_m128 = 3199,
    /// <summary>
    /// vpsllw zmm {k1}{z}, zmm/m512, imm8
    /// </summary>
    [Symbol("vpsllw zmm {k1}{z}, zmm, imm8","vpsllw zmm {k1}{z}, zmm/m512, imm8")]
    vpsllw_zmm_k1z_zmm_imm8 = 3200,
    /// <summary>
    /// vpsllw zmm {k1}{z}, zmm/m512, imm8
    /// </summary>
    [Symbol("vpsllw zmm {k1}{z}, m512, imm8","vpsllw zmm {k1}{z}, zmm/m512, imm8")]
    vpsllw_zmm_k1z_m512_imm8 = 3201,
    /// <summary>
    /// vpsrad xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsrad xmm {k1}{z}, xmm, xmm","vpsrad xmm {k1}{z}, xmm, xmm/m128")]
    vpsrad_xmm_k1z_xmm_xmm = 3202,
    /// <summary>
    /// vpsrad xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsrad xmm {k1}{z}, xmm, m128","vpsrad xmm {k1}{z}, xmm, xmm/m128")]
    vpsrad_xmm_k1z_xmm_m128 = 3203,
    /// <summary>
    /// vpsrad xmm {k1}{z}, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vpsrad xmm {k1}{z}, xmm, imm8","vpsrad xmm {k1}{z}, xmm/m128/m32bcst, imm8")]
    vpsrad_xmm_k1z_xmm_imm8 = 3204,
    /// <summary>
    /// vpsrad xmm {k1}{z}, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vpsrad xmm {k1}{z}, m128, imm8","vpsrad xmm {k1}{z}, xmm/m128/m32bcst, imm8")]
    vpsrad_xmm_k1z_m128_imm8 = 3205,
    /// <summary>
    /// vpsrad xmm {k1}{z}, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vpsrad xmm {k1}{z}, m32bcst, imm8","vpsrad xmm {k1}{z}, xmm/m128/m32bcst, imm8")]
    vpsrad_xmm_k1z_m32bcst_imm8 = 3206,
    /// <summary>
    /// vpsrad xmm, xmm, imm8
    /// </summary>
    [Symbol("vpsrad xmm, xmm, imm8","vpsrad xmm, xmm, imm8")]
    vpsrad_xmm_xmm_imm8 = 3207,
    /// <summary>
    /// vpsrad xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsrad xmm, xmm, xmm","vpsrad xmm, xmm, xmm/m128")]
    vpsrad_xmm_xmm_xmm = 3208,
    /// <summary>
    /// vpsrad xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsrad xmm, xmm, m128","vpsrad xmm, xmm, xmm/m128")]
    vpsrad_xmm_xmm_m128 = 3209,
    /// <summary>
    /// vpsrad ymm {k1}{z}, ymm, xmm/m128
    /// </summary>
    [Symbol("vpsrad ymm {k1}{z}, ymm, xmm","vpsrad ymm {k1}{z}, ymm, xmm/m128")]
    vpsrad_ymm_k1z_ymm_xmm = 3210,
    /// <summary>
    /// vpsrad ymm {k1}{z}, ymm, xmm/m128
    /// </summary>
    [Symbol("vpsrad ymm {k1}{z}, ymm, m128","vpsrad ymm {k1}{z}, ymm, xmm/m128")]
    vpsrad_ymm_k1z_ymm_m128 = 3211,
    /// <summary>
    /// vpsrad ymm {k1}{z}, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vpsrad ymm {k1}{z}, ymm, imm8","vpsrad ymm {k1}{z}, ymm/m256/m32bcst, imm8")]
    vpsrad_ymm_k1z_ymm_imm8 = 3212,
    /// <summary>
    /// vpsrad ymm {k1}{z}, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vpsrad ymm {k1}{z}, m256, imm8","vpsrad ymm {k1}{z}, ymm/m256/m32bcst, imm8")]
    vpsrad_ymm_k1z_m256_imm8 = 3213,
    /// <summary>
    /// vpsrad ymm {k1}{z}, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vpsrad ymm {k1}{z}, m32bcst, imm8","vpsrad ymm {k1}{z}, ymm/m256/m32bcst, imm8")]
    vpsrad_ymm_k1z_m32bcst_imm8 = 3214,
    /// <summary>
    /// vpsrad ymm, ymm, imm8
    /// </summary>
    [Symbol("vpsrad ymm, ymm, imm8","vpsrad ymm, ymm, imm8")]
    vpsrad_ymm_ymm_imm8 = 3215,
    /// <summary>
    /// vpsrad ymm, ymm, xmm/m128
    /// </summary>
    [Symbol("vpsrad ymm, ymm, xmm","vpsrad ymm, ymm, xmm/m128")]
    vpsrad_ymm_ymm_xmm = 3216,
    /// <summary>
    /// vpsrad ymm, ymm, xmm/m128
    /// </summary>
    [Symbol("vpsrad ymm, ymm, m128","vpsrad ymm, ymm, xmm/m128")]
    vpsrad_ymm_ymm_m128 = 3217,
    /// <summary>
    /// vpsrad zmm {k1}{z}, zmm, xmm/m128
    /// </summary>
    [Symbol("vpsrad zmm {k1}{z}, zmm, xmm","vpsrad zmm {k1}{z}, zmm, xmm/m128")]
    vpsrad_zmm_k1z_zmm_xmm = 3218,
    /// <summary>
    /// vpsrad zmm {k1}{z}, zmm, xmm/m128
    /// </summary>
    [Symbol("vpsrad zmm {k1}{z}, zmm, m128","vpsrad zmm {k1}{z}, zmm, xmm/m128")]
    vpsrad_zmm_k1z_zmm_m128 = 3219,
    /// <summary>
    /// vpsrad zmm {k1}{z}, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vpsrad zmm {k1}{z}, zmm, imm8","vpsrad zmm {k1}{z}, zmm/m512/m32bcst, imm8")]
    vpsrad_zmm_k1z_zmm_imm8 = 3220,
    /// <summary>
    /// vpsrad zmm {k1}{z}, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vpsrad zmm {k1}{z}, m512, imm8","vpsrad zmm {k1}{z}, zmm/m512/m32bcst, imm8")]
    vpsrad_zmm_k1z_m512_imm8 = 3221,
    /// <summary>
    /// vpsrad zmm {k1}{z}, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vpsrad zmm {k1}{z}, m32bcst, imm8","vpsrad zmm {k1}{z}, zmm/m512/m32bcst, imm8")]
    vpsrad_zmm_k1z_m32bcst_imm8 = 3222,
    /// <summary>
    /// vpsraq xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsraq xmm {k1}{z}, xmm, xmm","vpsraq xmm {k1}{z}, xmm, xmm/m128")]
    vpsraq_xmm_k1z_xmm_xmm = 3223,
    /// <summary>
    /// vpsraq xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsraq xmm {k1}{z}, xmm, m128","vpsraq xmm {k1}{z}, xmm, xmm/m128")]
    vpsraq_xmm_k1z_xmm_m128 = 3224,
    /// <summary>
    /// vpsraq xmm {k1}{z}, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("vpsraq xmm {k1}{z}, xmm, imm8","vpsraq xmm {k1}{z}, xmm/m128/m64bcst, imm8")]
    vpsraq_xmm_k1z_xmm_imm8 = 3225,
    /// <summary>
    /// vpsraq xmm {k1}{z}, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("vpsraq xmm {k1}{z}, m128, imm8","vpsraq xmm {k1}{z}, xmm/m128/m64bcst, imm8")]
    vpsraq_xmm_k1z_m128_imm8 = 3226,
    /// <summary>
    /// vpsraq xmm {k1}{z}, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("vpsraq xmm {k1}{z}, m64bcst, imm8","vpsraq xmm {k1}{z}, xmm/m128/m64bcst, imm8")]
    vpsraq_xmm_k1z_m64bcst_imm8 = 3227,
    /// <summary>
    /// vpsraq ymm {k1}{z}, ymm, xmm/m128
    /// </summary>
    [Symbol("vpsraq ymm {k1}{z}, ymm, xmm","vpsraq ymm {k1}{z}, ymm, xmm/m128")]
    vpsraq_ymm_k1z_ymm_xmm = 3228,
    /// <summary>
    /// vpsraq ymm {k1}{z}, ymm, xmm/m128
    /// </summary>
    [Symbol("vpsraq ymm {k1}{z}, ymm, m128","vpsraq ymm {k1}{z}, ymm, xmm/m128")]
    vpsraq_ymm_k1z_ymm_m128 = 3229,
    /// <summary>
    /// vpsraq ymm {k1}{z}, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vpsraq ymm {k1}{z}, ymm, imm8","vpsraq ymm {k1}{z}, ymm/m256/m64bcst, imm8")]
    vpsraq_ymm_k1z_ymm_imm8 = 3230,
    /// <summary>
    /// vpsraq ymm {k1}{z}, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vpsraq ymm {k1}{z}, m256, imm8","vpsraq ymm {k1}{z}, ymm/m256/m64bcst, imm8")]
    vpsraq_ymm_k1z_m256_imm8 = 3231,
    /// <summary>
    /// vpsraq ymm {k1}{z}, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vpsraq ymm {k1}{z}, m64bcst, imm8","vpsraq ymm {k1}{z}, ymm/m256/m64bcst, imm8")]
    vpsraq_ymm_k1z_m64bcst_imm8 = 3232,
    /// <summary>
    /// vpsraq zmm {k1}{z}, zmm, xmm/m128
    /// </summary>
    [Symbol("vpsraq zmm {k1}{z}, zmm, xmm","vpsraq zmm {k1}{z}, zmm, xmm/m128")]
    vpsraq_zmm_k1z_zmm_xmm = 3233,
    /// <summary>
    /// vpsraq zmm {k1}{z}, zmm, xmm/m128
    /// </summary>
    [Symbol("vpsraq zmm {k1}{z}, zmm, m128","vpsraq zmm {k1}{z}, zmm, xmm/m128")]
    vpsraq_zmm_k1z_zmm_m128 = 3234,
    /// <summary>
    /// vpsraq zmm {k1}{z}, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vpsraq zmm {k1}{z}, zmm, imm8","vpsraq zmm {k1}{z}, zmm/m512/m64bcst, imm8")]
    vpsraq_zmm_k1z_zmm_imm8 = 3235,
    /// <summary>
    /// vpsraq zmm {k1}{z}, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vpsraq zmm {k1}{z}, m512, imm8","vpsraq zmm {k1}{z}, zmm/m512/m64bcst, imm8")]
    vpsraq_zmm_k1z_m512_imm8 = 3236,
    /// <summary>
    /// vpsraq zmm {k1}{z}, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vpsraq zmm {k1}{z}, m64bcst, imm8","vpsraq zmm {k1}{z}, zmm/m512/m64bcst, imm8")]
    vpsraq_zmm_k1z_m64bcst_imm8 = 3237,
    /// <summary>
    /// vpsravd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpsravd xmm {k1}{z}, xmm, xmm","vpsravd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpsravd_xmm_k1z_xmm_xmm = 3238,
    /// <summary>
    /// vpsravd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpsravd xmm {k1}{z}, xmm, m128","vpsravd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpsravd_xmm_k1z_xmm_m128 = 3239,
    /// <summary>
    /// vpsravd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpsravd xmm {k1}{z}, xmm, m32bcst","vpsravd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpsravd_xmm_k1z_xmm_m32bcst = 3240,
    /// <summary>
    /// vpsravd xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsravd xmm, xmm, xmm","vpsravd xmm, xmm, xmm/m128")]
    vpsravd_xmm_xmm_xmm = 3241,
    /// <summary>
    /// vpsravd xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsravd xmm, xmm, m128","vpsravd xmm, xmm, xmm/m128")]
    vpsravd_xmm_xmm_m128 = 3242,
    /// <summary>
    /// vpsravd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpsravd ymm {k1}{z}, ymm, ymm","vpsravd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpsravd_ymm_k1z_ymm_ymm = 3243,
    /// <summary>
    /// vpsravd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpsravd ymm {k1}{z}, ymm, m256","vpsravd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpsravd_ymm_k1z_ymm_m256 = 3244,
    /// <summary>
    /// vpsravd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpsravd ymm {k1}{z}, ymm, m32bcst","vpsravd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpsravd_ymm_k1z_ymm_m32bcst = 3245,
    /// <summary>
    /// vpsravd ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsravd ymm, ymm, ymm","vpsravd ymm, ymm, ymm/m256")]
    vpsravd_ymm_ymm_ymm = 3246,
    /// <summary>
    /// vpsravd ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsravd ymm, ymm, m256","vpsravd ymm, ymm, ymm/m256")]
    vpsravd_ymm_ymm_m256 = 3247,
    /// <summary>
    /// vpsravd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpsravd zmm {k1}{z}, zmm, zmm","vpsravd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpsravd_zmm_k1z_zmm_zmm = 3248,
    /// <summary>
    /// vpsravd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpsravd zmm {k1}{z}, zmm, m512","vpsravd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpsravd_zmm_k1z_zmm_m512 = 3249,
    /// <summary>
    /// vpsravd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpsravd zmm {k1}{z}, zmm, m32bcst","vpsravd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpsravd_zmm_k1z_zmm_m32bcst = 3250,
    /// <summary>
    /// vpsravq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpsravq xmm {k1}{z}, xmm, xmm","vpsravq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpsravq_xmm_k1z_xmm_xmm = 3251,
    /// <summary>
    /// vpsravq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpsravq xmm {k1}{z}, xmm, m128","vpsravq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpsravq_xmm_k1z_xmm_m128 = 3252,
    /// <summary>
    /// vpsravq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpsravq xmm {k1}{z}, xmm, m64bcst","vpsravq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpsravq_xmm_k1z_xmm_m64bcst = 3253,
    /// <summary>
    /// vpsravq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpsravq ymm {k1}{z}, ymm, ymm","vpsravq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpsravq_ymm_k1z_ymm_ymm = 3254,
    /// <summary>
    /// vpsravq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpsravq ymm {k1}{z}, ymm, m256","vpsravq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpsravq_ymm_k1z_ymm_m256 = 3255,
    /// <summary>
    /// vpsravq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpsravq ymm {k1}{z}, ymm, m64bcst","vpsravq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpsravq_ymm_k1z_ymm_m64bcst = 3256,
    /// <summary>
    /// vpsravq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpsravq zmm {k1}{z}, zmm, zmm","vpsravq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpsravq_zmm_k1z_zmm_zmm = 3257,
    /// <summary>
    /// vpsravq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpsravq zmm {k1}{z}, zmm, m512","vpsravq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpsravq_zmm_k1z_zmm_m512 = 3258,
    /// <summary>
    /// vpsravq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpsravq zmm {k1}{z}, zmm, m64bcst","vpsravq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpsravq_zmm_k1z_zmm_m64bcst = 3259,
    /// <summary>
    /// vpsravw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsravw xmm {k1}{z}, xmm, xmm","vpsravw xmm {k1}{z}, xmm, xmm/m128")]
    vpsravw_xmm_k1z_xmm_xmm = 3260,
    /// <summary>
    /// vpsravw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsravw xmm {k1}{z}, xmm, m128","vpsravw xmm {k1}{z}, xmm, xmm/m128")]
    vpsravw_xmm_k1z_xmm_m128 = 3261,
    /// <summary>
    /// vpsravw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsravw ymm {k1}{z}, ymm, ymm","vpsravw ymm {k1}{z}, ymm, ymm/m256")]
    vpsravw_ymm_k1z_ymm_ymm = 3262,
    /// <summary>
    /// vpsravw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsravw ymm {k1}{z}, ymm, m256","vpsravw ymm {k1}{z}, ymm, ymm/m256")]
    vpsravw_ymm_k1z_ymm_m256 = 3263,
    /// <summary>
    /// vpsravw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpsravw zmm {k1}{z}, zmm, zmm","vpsravw zmm {k1}{z}, zmm, zmm/m512")]
    vpsravw_zmm_k1z_zmm_zmm = 3264,
    /// <summary>
    /// vpsravw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpsravw zmm {k1}{z}, zmm, m512","vpsravw zmm {k1}{z}, zmm, zmm/m512")]
    vpsravw_zmm_k1z_zmm_m512 = 3265,
    /// <summary>
    /// vpsraw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsraw xmm {k1}{z}, xmm, xmm","vpsraw xmm {k1}{z}, xmm, xmm/m128")]
    vpsraw_xmm_k1z_xmm_xmm = 3266,
    /// <summary>
    /// vpsraw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsraw xmm {k1}{z}, xmm, m128","vpsraw xmm {k1}{z}, xmm, xmm/m128")]
    vpsraw_xmm_k1z_xmm_m128 = 3267,
    /// <summary>
    /// vpsraw xmm {k1}{z}, xmm/m128, imm8
    /// </summary>
    [Symbol("vpsraw xmm {k1}{z}, xmm, imm8","vpsraw xmm {k1}{z}, xmm/m128, imm8")]
    vpsraw_xmm_k1z_xmm_imm8 = 3268,
    /// <summary>
    /// vpsraw xmm {k1}{z}, xmm/m128, imm8
    /// </summary>
    [Symbol("vpsraw xmm {k1}{z}, m128, imm8","vpsraw xmm {k1}{z}, xmm/m128, imm8")]
    vpsraw_xmm_k1z_m128_imm8 = 3269,
    /// <summary>
    /// vpsraw xmm, xmm, imm8
    /// </summary>
    [Symbol("vpsraw xmm, xmm, imm8","vpsraw xmm, xmm, imm8")]
    vpsraw_xmm_xmm_imm8 = 3270,
    /// <summary>
    /// vpsraw xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsraw xmm, xmm, xmm","vpsraw xmm, xmm, xmm/m128")]
    vpsraw_xmm_xmm_xmm = 3271,
    /// <summary>
    /// vpsraw xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsraw xmm, xmm, m128","vpsraw xmm, xmm, xmm/m128")]
    vpsraw_xmm_xmm_m128 = 3272,
    /// <summary>
    /// vpsraw ymm {k1}{z}, ymm, xmm/m128
    /// </summary>
    [Symbol("vpsraw ymm {k1}{z}, ymm, xmm","vpsraw ymm {k1}{z}, ymm, xmm/m128")]
    vpsraw_ymm_k1z_ymm_xmm = 3273,
    /// <summary>
    /// vpsraw ymm {k1}{z}, ymm, xmm/m128
    /// </summary>
    [Symbol("vpsraw ymm {k1}{z}, ymm, m128","vpsraw ymm {k1}{z}, ymm, xmm/m128")]
    vpsraw_ymm_k1z_ymm_m128 = 3274,
    /// <summary>
    /// vpsraw ymm {k1}{z}, ymm/m256, imm8
    /// </summary>
    [Symbol("vpsraw ymm {k1}{z}, ymm, imm8","vpsraw ymm {k1}{z}, ymm/m256, imm8")]
    vpsraw_ymm_k1z_ymm_imm8 = 3275,
    /// <summary>
    /// vpsraw ymm {k1}{z}, ymm/m256, imm8
    /// </summary>
    [Symbol("vpsraw ymm {k1}{z}, m256, imm8","vpsraw ymm {k1}{z}, ymm/m256, imm8")]
    vpsraw_ymm_k1z_m256_imm8 = 3276,
    /// <summary>
    /// vpsraw ymm, ymm, imm8
    /// </summary>
    [Symbol("vpsraw ymm, ymm, imm8","vpsraw ymm, ymm, imm8")]
    vpsraw_ymm_ymm_imm8 = 3277,
    /// <summary>
    /// vpsraw ymm, ymm, xmm/m128
    /// </summary>
    [Symbol("vpsraw ymm, ymm, xmm","vpsraw ymm, ymm, xmm/m128")]
    vpsraw_ymm_ymm_xmm = 3278,
    /// <summary>
    /// vpsraw ymm, ymm, xmm/m128
    /// </summary>
    [Symbol("vpsraw ymm, ymm, m128","vpsraw ymm, ymm, xmm/m128")]
    vpsraw_ymm_ymm_m128 = 3279,
    /// <summary>
    /// vpsraw zmm {k1}{z}, zmm, xmm/m128
    /// </summary>
    [Symbol("vpsraw zmm {k1}{z}, zmm, xmm","vpsraw zmm {k1}{z}, zmm, xmm/m128")]
    vpsraw_zmm_k1z_zmm_xmm = 3280,
    /// <summary>
    /// vpsraw zmm {k1}{z}, zmm, xmm/m128
    /// </summary>
    [Symbol("vpsraw zmm {k1}{z}, zmm, m128","vpsraw zmm {k1}{z}, zmm, xmm/m128")]
    vpsraw_zmm_k1z_zmm_m128 = 3281,
    /// <summary>
    /// vpsraw zmm {k1}{z}, zmm/m512, imm8
    /// </summary>
    [Symbol("vpsraw zmm {k1}{z}, zmm, imm8","vpsraw zmm {k1}{z}, zmm/m512, imm8")]
    vpsraw_zmm_k1z_zmm_imm8 = 3282,
    /// <summary>
    /// vpsraw zmm {k1}{z}, zmm/m512, imm8
    /// </summary>
    [Symbol("vpsraw zmm {k1}{z}, m512, imm8","vpsraw zmm {k1}{z}, zmm/m512, imm8")]
    vpsraw_zmm_k1z_m512_imm8 = 3283,
    /// <summary>
    /// vpsrld xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsrld xmm {k1}{z}, xmm, xmm","vpsrld xmm {k1}{z}, xmm, xmm/m128")]
    vpsrld_xmm_k1z_xmm_xmm = 3284,
    /// <summary>
    /// vpsrld xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsrld xmm {k1}{z}, xmm, m128","vpsrld xmm {k1}{z}, xmm, xmm/m128")]
    vpsrld_xmm_k1z_xmm_m128 = 3285,
    /// <summary>
    /// vpsrld xmm {k1}{z}, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vpsrld xmm {k1}{z}, xmm, imm8","vpsrld xmm {k1}{z}, xmm/m128/m32bcst, imm8")]
    vpsrld_xmm_k1z_xmm_imm8 = 3286,
    /// <summary>
    /// vpsrld xmm {k1}{z}, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vpsrld xmm {k1}{z}, m128, imm8","vpsrld xmm {k1}{z}, xmm/m128/m32bcst, imm8")]
    vpsrld_xmm_k1z_m128_imm8 = 3287,
    /// <summary>
    /// vpsrld xmm {k1}{z}, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vpsrld xmm {k1}{z}, m32bcst, imm8","vpsrld xmm {k1}{z}, xmm/m128/m32bcst, imm8")]
    vpsrld_xmm_k1z_m32bcst_imm8 = 3288,
    /// <summary>
    /// vpsrld xmm, xmm, imm8
    /// </summary>
    [Symbol("vpsrld xmm, xmm, imm8","vpsrld xmm, xmm, imm8")]
    vpsrld_xmm_xmm_imm8 = 3289,
    /// <summary>
    /// vpsrld xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsrld xmm, xmm, xmm","vpsrld xmm, xmm, xmm/m128")]
    vpsrld_xmm_xmm_xmm = 3290,
    /// <summary>
    /// vpsrld xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsrld xmm, xmm, m128","vpsrld xmm, xmm, xmm/m128")]
    vpsrld_xmm_xmm_m128 = 3291,
    /// <summary>
    /// vpsrld ymm {k1}{z}, ymm, xmm/m128
    /// </summary>
    [Symbol("vpsrld ymm {k1}{z}, ymm, xmm","vpsrld ymm {k1}{z}, ymm, xmm/m128")]
    vpsrld_ymm_k1z_ymm_xmm = 3292,
    /// <summary>
    /// vpsrld ymm {k1}{z}, ymm, xmm/m128
    /// </summary>
    [Symbol("vpsrld ymm {k1}{z}, ymm, m128","vpsrld ymm {k1}{z}, ymm, xmm/m128")]
    vpsrld_ymm_k1z_ymm_m128 = 3293,
    /// <summary>
    /// vpsrld ymm {k1}{z}, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vpsrld ymm {k1}{z}, ymm, imm8","vpsrld ymm {k1}{z}, ymm/m256/m32bcst, imm8")]
    vpsrld_ymm_k1z_ymm_imm8 = 3294,
    /// <summary>
    /// vpsrld ymm {k1}{z}, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vpsrld ymm {k1}{z}, m256, imm8","vpsrld ymm {k1}{z}, ymm/m256/m32bcst, imm8")]
    vpsrld_ymm_k1z_m256_imm8 = 3295,
    /// <summary>
    /// vpsrld ymm {k1}{z}, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vpsrld ymm {k1}{z}, m32bcst, imm8","vpsrld ymm {k1}{z}, ymm/m256/m32bcst, imm8")]
    vpsrld_ymm_k1z_m32bcst_imm8 = 3296,
    /// <summary>
    /// vpsrld ymm, ymm, imm8
    /// </summary>
    [Symbol("vpsrld ymm, ymm, imm8","vpsrld ymm, ymm, imm8")]
    vpsrld_ymm_ymm_imm8 = 3297,
    /// <summary>
    /// vpsrld ymm, ymm, xmm/m128
    /// </summary>
    [Symbol("vpsrld ymm, ymm, xmm","vpsrld ymm, ymm, xmm/m128")]
    vpsrld_ymm_ymm_xmm = 3298,
    /// <summary>
    /// vpsrld ymm, ymm, xmm/m128
    /// </summary>
    [Symbol("vpsrld ymm, ymm, m128","vpsrld ymm, ymm, xmm/m128")]
    vpsrld_ymm_ymm_m128 = 3299,
    /// <summary>
    /// vpsrld zmm {k1}{z}, zmm, xmm/m128
    /// </summary>
    [Symbol("vpsrld zmm {k1}{z}, zmm, xmm","vpsrld zmm {k1}{z}, zmm, xmm/m128")]
    vpsrld_zmm_k1z_zmm_xmm = 3300,
    /// <summary>
    /// vpsrld zmm {k1}{z}, zmm, xmm/m128
    /// </summary>
    [Symbol("vpsrld zmm {k1}{z}, zmm, m128","vpsrld zmm {k1}{z}, zmm, xmm/m128")]
    vpsrld_zmm_k1z_zmm_m128 = 3301,
    /// <summary>
    /// vpsrld zmm {k1}{z}, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vpsrld zmm {k1}{z}, zmm, imm8","vpsrld zmm {k1}{z}, zmm/m512/m32bcst, imm8")]
    vpsrld_zmm_k1z_zmm_imm8 = 3302,
    /// <summary>
    /// vpsrld zmm {k1}{z}, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vpsrld zmm {k1}{z}, m512, imm8","vpsrld zmm {k1}{z}, zmm/m512/m32bcst, imm8")]
    vpsrld_zmm_k1z_m512_imm8 = 3303,
    /// <summary>
    /// vpsrld zmm {k1}{z}, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vpsrld zmm {k1}{z}, m32bcst, imm8","vpsrld zmm {k1}{z}, zmm/m512/m32bcst, imm8")]
    vpsrld_zmm_k1z_m32bcst_imm8 = 3304,
    /// <summary>
    /// vpsrlq xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsrlq xmm {k1}{z}, xmm, xmm","vpsrlq xmm {k1}{z}, xmm, xmm/m128")]
    vpsrlq_xmm_k1z_xmm_xmm = 3305,
    /// <summary>
    /// vpsrlq xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsrlq xmm {k1}{z}, xmm, m128","vpsrlq xmm {k1}{z}, xmm, xmm/m128")]
    vpsrlq_xmm_k1z_xmm_m128 = 3306,
    /// <summary>
    /// vpsrlq xmm {k1}{z}, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("vpsrlq xmm {k1}{z}, xmm, imm8","vpsrlq xmm {k1}{z}, xmm/m128/m64bcst, imm8")]
    vpsrlq_xmm_k1z_xmm_imm8 = 3307,
    /// <summary>
    /// vpsrlq xmm {k1}{z}, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("vpsrlq xmm {k1}{z}, m128, imm8","vpsrlq xmm {k1}{z}, xmm/m128/m64bcst, imm8")]
    vpsrlq_xmm_k1z_m128_imm8 = 3308,
    /// <summary>
    /// vpsrlq xmm {k1}{z}, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("vpsrlq xmm {k1}{z}, m64bcst, imm8","vpsrlq xmm {k1}{z}, xmm/m128/m64bcst, imm8")]
    vpsrlq_xmm_k1z_m64bcst_imm8 = 3309,
    /// <summary>
    /// vpsrlq xmm, xmm, imm8
    /// </summary>
    [Symbol("vpsrlq xmm, xmm, imm8","vpsrlq xmm, xmm, imm8")]
    vpsrlq_xmm_xmm_imm8 = 3310,
    /// <summary>
    /// vpsrlq xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsrlq xmm, xmm, xmm","vpsrlq xmm, xmm, xmm/m128")]
    vpsrlq_xmm_xmm_xmm = 3311,
    /// <summary>
    /// vpsrlq xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsrlq xmm, xmm, m128","vpsrlq xmm, xmm, xmm/m128")]
    vpsrlq_xmm_xmm_m128 = 3312,
    /// <summary>
    /// vpsrlq ymm {k1}{z}, ymm, xmm/m128
    /// </summary>
    [Symbol("vpsrlq ymm {k1}{z}, ymm, xmm","vpsrlq ymm {k1}{z}, ymm, xmm/m128")]
    vpsrlq_ymm_k1z_ymm_xmm = 3313,
    /// <summary>
    /// vpsrlq ymm {k1}{z}, ymm, xmm/m128
    /// </summary>
    [Symbol("vpsrlq ymm {k1}{z}, ymm, m128","vpsrlq ymm {k1}{z}, ymm, xmm/m128")]
    vpsrlq_ymm_k1z_ymm_m128 = 3314,
    /// <summary>
    /// vpsrlq ymm {k1}{z}, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vpsrlq ymm {k1}{z}, ymm, imm8","vpsrlq ymm {k1}{z}, ymm/m256/m64bcst, imm8")]
    vpsrlq_ymm_k1z_ymm_imm8 = 3315,
    /// <summary>
    /// vpsrlq ymm {k1}{z}, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vpsrlq ymm {k1}{z}, m256, imm8","vpsrlq ymm {k1}{z}, ymm/m256/m64bcst, imm8")]
    vpsrlq_ymm_k1z_m256_imm8 = 3316,
    /// <summary>
    /// vpsrlq ymm {k1}{z}, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vpsrlq ymm {k1}{z}, m64bcst, imm8","vpsrlq ymm {k1}{z}, ymm/m256/m64bcst, imm8")]
    vpsrlq_ymm_k1z_m64bcst_imm8 = 3317,
    /// <summary>
    /// vpsrlq ymm, ymm, imm8
    /// </summary>
    [Symbol("vpsrlq ymm, ymm, imm8","vpsrlq ymm, ymm, imm8")]
    vpsrlq_ymm_ymm_imm8 = 3318,
    /// <summary>
    /// vpsrlq ymm, ymm, xmm/m128
    /// </summary>
    [Symbol("vpsrlq ymm, ymm, xmm","vpsrlq ymm, ymm, xmm/m128")]
    vpsrlq_ymm_ymm_xmm = 3319,
    /// <summary>
    /// vpsrlq ymm, ymm, xmm/m128
    /// </summary>
    [Symbol("vpsrlq ymm, ymm, m128","vpsrlq ymm, ymm, xmm/m128")]
    vpsrlq_ymm_ymm_m128 = 3320,
    /// <summary>
    /// vpsrlq zmm {k1}{z}, zmm, xmm/m128
    /// </summary>
    [Symbol("vpsrlq zmm {k1}{z}, zmm, xmm","vpsrlq zmm {k1}{z}, zmm, xmm/m128")]
    vpsrlq_zmm_k1z_zmm_xmm = 3321,
    /// <summary>
    /// vpsrlq zmm {k1}{z}, zmm, xmm/m128
    /// </summary>
    [Symbol("vpsrlq zmm {k1}{z}, zmm, m128","vpsrlq zmm {k1}{z}, zmm, xmm/m128")]
    vpsrlq_zmm_k1z_zmm_m128 = 3322,
    /// <summary>
    /// vpsrlq zmm {k1}{z}, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vpsrlq zmm {k1}{z}, zmm, imm8","vpsrlq zmm {k1}{z}, zmm/m512/m64bcst, imm8")]
    vpsrlq_zmm_k1z_zmm_imm8 = 3323,
    /// <summary>
    /// vpsrlq zmm {k1}{z}, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vpsrlq zmm {k1}{z}, m512, imm8","vpsrlq zmm {k1}{z}, zmm/m512/m64bcst, imm8")]
    vpsrlq_zmm_k1z_m512_imm8 = 3324,
    /// <summary>
    /// vpsrlq zmm {k1}{z}, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vpsrlq zmm {k1}{z}, m64bcst, imm8","vpsrlq zmm {k1}{z}, zmm/m512/m64bcst, imm8")]
    vpsrlq_zmm_k1z_m64bcst_imm8 = 3325,
    /// <summary>
    /// vpsrlvd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpsrlvd xmm {k1}{z}, xmm, xmm","vpsrlvd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpsrlvd_xmm_k1z_xmm_xmm = 3326,
    /// <summary>
    /// vpsrlvd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpsrlvd xmm {k1}{z}, xmm, m128","vpsrlvd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpsrlvd_xmm_k1z_xmm_m128 = 3327,
    /// <summary>
    /// vpsrlvd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpsrlvd xmm {k1}{z}, xmm, m32bcst","vpsrlvd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpsrlvd_xmm_k1z_xmm_m32bcst = 3328,
    /// <summary>
    /// vpsrlvd xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsrlvd xmm, xmm, xmm","vpsrlvd xmm, xmm, xmm/m128")]
    vpsrlvd_xmm_xmm_xmm = 3329,
    /// <summary>
    /// vpsrlvd xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsrlvd xmm, xmm, m128","vpsrlvd xmm, xmm, xmm/m128")]
    vpsrlvd_xmm_xmm_m128 = 3330,
    /// <summary>
    /// vpsrlvd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpsrlvd ymm {k1}{z}, ymm, ymm","vpsrlvd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpsrlvd_ymm_k1z_ymm_ymm = 3331,
    /// <summary>
    /// vpsrlvd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpsrlvd ymm {k1}{z}, ymm, m256","vpsrlvd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpsrlvd_ymm_k1z_ymm_m256 = 3332,
    /// <summary>
    /// vpsrlvd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpsrlvd ymm {k1}{z}, ymm, m32bcst","vpsrlvd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpsrlvd_ymm_k1z_ymm_m32bcst = 3333,
    /// <summary>
    /// vpsrlvd ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsrlvd ymm, ymm, ymm","vpsrlvd ymm, ymm, ymm/m256")]
    vpsrlvd_ymm_ymm_ymm = 3334,
    /// <summary>
    /// vpsrlvd ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsrlvd ymm, ymm, m256","vpsrlvd ymm, ymm, ymm/m256")]
    vpsrlvd_ymm_ymm_m256 = 3335,
    /// <summary>
    /// vpsrlvd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpsrlvd zmm {k1}{z}, zmm, zmm","vpsrlvd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpsrlvd_zmm_k1z_zmm_zmm = 3336,
    /// <summary>
    /// vpsrlvd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpsrlvd zmm {k1}{z}, zmm, m512","vpsrlvd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpsrlvd_zmm_k1z_zmm_m512 = 3337,
    /// <summary>
    /// vpsrlvd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpsrlvd zmm {k1}{z}, zmm, m32bcst","vpsrlvd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpsrlvd_zmm_k1z_zmm_m32bcst = 3338,
    /// <summary>
    /// vpsrlvq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpsrlvq xmm {k1}{z}, xmm, xmm","vpsrlvq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpsrlvq_xmm_k1z_xmm_xmm = 3339,
    /// <summary>
    /// vpsrlvq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpsrlvq xmm {k1}{z}, xmm, m128","vpsrlvq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpsrlvq_xmm_k1z_xmm_m128 = 3340,
    /// <summary>
    /// vpsrlvq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpsrlvq xmm {k1}{z}, xmm, m64bcst","vpsrlvq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpsrlvq_xmm_k1z_xmm_m64bcst = 3341,
    /// <summary>
    /// vpsrlvq xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsrlvq xmm, xmm, xmm","vpsrlvq xmm, xmm, xmm/m128")]
    vpsrlvq_xmm_xmm_xmm = 3342,
    /// <summary>
    /// vpsrlvq xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsrlvq xmm, xmm, m128","vpsrlvq xmm, xmm, xmm/m128")]
    vpsrlvq_xmm_xmm_m128 = 3343,
    /// <summary>
    /// vpsrlvq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpsrlvq ymm {k1}{z}, ymm, ymm","vpsrlvq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpsrlvq_ymm_k1z_ymm_ymm = 3344,
    /// <summary>
    /// vpsrlvq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpsrlvq ymm {k1}{z}, ymm, m256","vpsrlvq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpsrlvq_ymm_k1z_ymm_m256 = 3345,
    /// <summary>
    /// vpsrlvq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpsrlvq ymm {k1}{z}, ymm, m64bcst","vpsrlvq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpsrlvq_ymm_k1z_ymm_m64bcst = 3346,
    /// <summary>
    /// vpsrlvq ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsrlvq ymm, ymm, ymm","vpsrlvq ymm, ymm, ymm/m256")]
    vpsrlvq_ymm_ymm_ymm = 3347,
    /// <summary>
    /// vpsrlvq ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsrlvq ymm, ymm, m256","vpsrlvq ymm, ymm, ymm/m256")]
    vpsrlvq_ymm_ymm_m256 = 3348,
    /// <summary>
    /// vpsrlvq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpsrlvq zmm {k1}{z}, zmm, zmm","vpsrlvq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpsrlvq_zmm_k1z_zmm_zmm = 3349,
    /// <summary>
    /// vpsrlvq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpsrlvq zmm {k1}{z}, zmm, m512","vpsrlvq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpsrlvq_zmm_k1z_zmm_m512 = 3350,
    /// <summary>
    /// vpsrlvq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpsrlvq zmm {k1}{z}, zmm, m64bcst","vpsrlvq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpsrlvq_zmm_k1z_zmm_m64bcst = 3351,
    /// <summary>
    /// vpsrlvw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsrlvw xmm {k1}{z}, xmm, xmm","vpsrlvw xmm {k1}{z}, xmm, xmm/m128")]
    vpsrlvw_xmm_k1z_xmm_xmm = 3352,
    /// <summary>
    /// vpsrlvw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsrlvw xmm {k1}{z}, xmm, m128","vpsrlvw xmm {k1}{z}, xmm, xmm/m128")]
    vpsrlvw_xmm_k1z_xmm_m128 = 3353,
    /// <summary>
    /// vpsrlvw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsrlvw ymm {k1}{z}, ymm, ymm","vpsrlvw ymm {k1}{z}, ymm, ymm/m256")]
    vpsrlvw_ymm_k1z_ymm_ymm = 3354,
    /// <summary>
    /// vpsrlvw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsrlvw ymm {k1}{z}, ymm, m256","vpsrlvw ymm {k1}{z}, ymm, ymm/m256")]
    vpsrlvw_ymm_k1z_ymm_m256 = 3355,
    /// <summary>
    /// vpsrlvw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpsrlvw zmm {k1}{z}, zmm, zmm","vpsrlvw zmm {k1}{z}, zmm, zmm/m512")]
    vpsrlvw_zmm_k1z_zmm_zmm = 3356,
    /// <summary>
    /// vpsrlvw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpsrlvw zmm {k1}{z}, zmm, m512","vpsrlvw zmm {k1}{z}, zmm, zmm/m512")]
    vpsrlvw_zmm_k1z_zmm_m512 = 3357,
    /// <summary>
    /// vpsrlw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsrlw xmm {k1}{z}, xmm, xmm","vpsrlw xmm {k1}{z}, xmm, xmm/m128")]
    vpsrlw_xmm_k1z_xmm_xmm = 3358,
    /// <summary>
    /// vpsrlw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsrlw xmm {k1}{z}, xmm, m128","vpsrlw xmm {k1}{z}, xmm, xmm/m128")]
    vpsrlw_xmm_k1z_xmm_m128 = 3359,
    /// <summary>
    /// vpsrlw xmm {k1}{z}, xmm/m128, imm8
    /// </summary>
    [Symbol("vpsrlw xmm {k1}{z}, xmm, imm8","vpsrlw xmm {k1}{z}, xmm/m128, imm8")]
    vpsrlw_xmm_k1z_xmm_imm8 = 3360,
    /// <summary>
    /// vpsrlw xmm {k1}{z}, xmm/m128, imm8
    /// </summary>
    [Symbol("vpsrlw xmm {k1}{z}, m128, imm8","vpsrlw xmm {k1}{z}, xmm/m128, imm8")]
    vpsrlw_xmm_k1z_m128_imm8 = 3361,
    /// <summary>
    /// vpsrlw xmm, xmm, imm8
    /// </summary>
    [Symbol("vpsrlw xmm, xmm, imm8","vpsrlw xmm, xmm, imm8")]
    vpsrlw_xmm_xmm_imm8 = 3362,
    /// <summary>
    /// vpsrlw xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsrlw xmm, xmm, xmm","vpsrlw xmm, xmm, xmm/m128")]
    vpsrlw_xmm_xmm_xmm = 3363,
    /// <summary>
    /// vpsrlw xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsrlw xmm, xmm, m128","vpsrlw xmm, xmm, xmm/m128")]
    vpsrlw_xmm_xmm_m128 = 3364,
    /// <summary>
    /// vpsrlw ymm {k1}{z}, ymm, xmm/m128
    /// </summary>
    [Symbol("vpsrlw ymm {k1}{z}, ymm, xmm","vpsrlw ymm {k1}{z}, ymm, xmm/m128")]
    vpsrlw_ymm_k1z_ymm_xmm = 3365,
    /// <summary>
    /// vpsrlw ymm {k1}{z}, ymm, xmm/m128
    /// </summary>
    [Symbol("vpsrlw ymm {k1}{z}, ymm, m128","vpsrlw ymm {k1}{z}, ymm, xmm/m128")]
    vpsrlw_ymm_k1z_ymm_m128 = 3366,
    /// <summary>
    /// vpsrlw ymm {k1}{z}, ymm/m256, imm8
    /// </summary>
    [Symbol("vpsrlw ymm {k1}{z}, ymm, imm8","vpsrlw ymm {k1}{z}, ymm/m256, imm8")]
    vpsrlw_ymm_k1z_ymm_imm8 = 3367,
    /// <summary>
    /// vpsrlw ymm {k1}{z}, ymm/m256, imm8
    /// </summary>
    [Symbol("vpsrlw ymm {k1}{z}, m256, imm8","vpsrlw ymm {k1}{z}, ymm/m256, imm8")]
    vpsrlw_ymm_k1z_m256_imm8 = 3368,
    /// <summary>
    /// vpsrlw ymm, ymm, imm8
    /// </summary>
    [Symbol("vpsrlw ymm, ymm, imm8","vpsrlw ymm, ymm, imm8")]
    vpsrlw_ymm_ymm_imm8 = 3369,
    /// <summary>
    /// vpsrlw ymm, ymm, xmm/m128
    /// </summary>
    [Symbol("vpsrlw ymm, ymm, xmm","vpsrlw ymm, ymm, xmm/m128")]
    vpsrlw_ymm_ymm_xmm = 3370,
    /// <summary>
    /// vpsrlw ymm, ymm, xmm/m128
    /// </summary>
    [Symbol("vpsrlw ymm, ymm, m128","vpsrlw ymm, ymm, xmm/m128")]
    vpsrlw_ymm_ymm_m128 = 3371,
    /// <summary>
    /// vpsrlw zmm {k1}{z}, zmm, xmm/m128
    /// </summary>
    [Symbol("vpsrlw zmm {k1}{z}, zmm, xmm","vpsrlw zmm {k1}{z}, zmm, xmm/m128")]
    vpsrlw_zmm_k1z_zmm_xmm = 3372,
    /// <summary>
    /// vpsrlw zmm {k1}{z}, zmm, xmm/m128
    /// </summary>
    [Symbol("vpsrlw zmm {k1}{z}, zmm, m128","vpsrlw zmm {k1}{z}, zmm, xmm/m128")]
    vpsrlw_zmm_k1z_zmm_m128 = 3373,
    /// <summary>
    /// vpsrlw zmm {k1}{z}, zmm/m512, imm8
    /// </summary>
    [Symbol("vpsrlw zmm {k1}{z}, zmm, imm8","vpsrlw zmm {k1}{z}, zmm/m512, imm8")]
    vpsrlw_zmm_k1z_zmm_imm8 = 3374,
    /// <summary>
    /// vpsrlw zmm {k1}{z}, zmm/m512, imm8
    /// </summary>
    [Symbol("vpsrlw zmm {k1}{z}, m512, imm8","vpsrlw zmm {k1}{z}, zmm/m512, imm8")]
    vpsrlw_zmm_k1z_m512_imm8 = 3375,
    /// <summary>
    /// vpsubb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsubb xmm {k1}{z}, xmm, xmm","vpsubb xmm {k1}{z}, xmm, xmm/m128")]
    vpsubb_xmm_k1z_xmm_xmm = 3376,
    /// <summary>
    /// vpsubb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsubb xmm {k1}{z}, xmm, m128","vpsubb xmm {k1}{z}, xmm, xmm/m128")]
    vpsubb_xmm_k1z_xmm_m128 = 3377,
    /// <summary>
    /// vpsubb xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsubb xmm, xmm, xmm","vpsubb xmm, xmm, xmm/m128")]
    vpsubb_xmm_xmm_xmm = 3378,
    /// <summary>
    /// vpsubb xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsubb xmm, xmm, m128","vpsubb xmm, xmm, xmm/m128")]
    vpsubb_xmm_xmm_m128 = 3379,
    /// <summary>
    /// vpsubb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsubb ymm {k1}{z}, ymm, ymm","vpsubb ymm {k1}{z}, ymm, ymm/m256")]
    vpsubb_ymm_k1z_ymm_ymm = 3380,
    /// <summary>
    /// vpsubb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsubb ymm {k1}{z}, ymm, m256","vpsubb ymm {k1}{z}, ymm, ymm/m256")]
    vpsubb_ymm_k1z_ymm_m256 = 3381,
    /// <summary>
    /// vpsubb ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsubb ymm, ymm, ymm","vpsubb ymm, ymm, ymm/m256")]
    vpsubb_ymm_ymm_ymm = 3382,
    /// <summary>
    /// vpsubb ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsubb ymm, ymm, m256","vpsubb ymm, ymm, ymm/m256")]
    vpsubb_ymm_ymm_m256 = 3383,
    /// <summary>
    /// vpsubb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpsubb zmm {k1}{z}, zmm, zmm","vpsubb zmm {k1}{z}, zmm, zmm/m512")]
    vpsubb_zmm_k1z_zmm_zmm = 3384,
    /// <summary>
    /// vpsubb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpsubb zmm {k1}{z}, zmm, m512","vpsubb zmm {k1}{z}, zmm, zmm/m512")]
    vpsubb_zmm_k1z_zmm_m512 = 3385,
    /// <summary>
    /// vpsubd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpsubd xmm {k1}{z}, xmm, xmm","vpsubd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpsubd_xmm_k1z_xmm_xmm = 3386,
    /// <summary>
    /// vpsubd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpsubd xmm {k1}{z}, xmm, m128","vpsubd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpsubd_xmm_k1z_xmm_m128 = 3387,
    /// <summary>
    /// vpsubd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpsubd xmm {k1}{z}, xmm, m32bcst","vpsubd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpsubd_xmm_k1z_xmm_m32bcst = 3388,
    /// <summary>
    /// vpsubd xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsubd xmm, xmm, xmm","vpsubd xmm, xmm, xmm/m128")]
    vpsubd_xmm_xmm_xmm = 3389,
    /// <summary>
    /// vpsubd xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsubd xmm, xmm, m128","vpsubd xmm, xmm, xmm/m128")]
    vpsubd_xmm_xmm_m128 = 3390,
    /// <summary>
    /// vpsubd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpsubd ymm {k1}{z}, ymm, ymm","vpsubd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpsubd_ymm_k1z_ymm_ymm = 3391,
    /// <summary>
    /// vpsubd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpsubd ymm {k1}{z}, ymm, m256","vpsubd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpsubd_ymm_k1z_ymm_m256 = 3392,
    /// <summary>
    /// vpsubd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpsubd ymm {k1}{z}, ymm, m32bcst","vpsubd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpsubd_ymm_k1z_ymm_m32bcst = 3393,
    /// <summary>
    /// vpsubd ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsubd ymm, ymm, ymm","vpsubd ymm, ymm, ymm/m256")]
    vpsubd_ymm_ymm_ymm = 3394,
    /// <summary>
    /// vpsubd ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsubd ymm, ymm, m256","vpsubd ymm, ymm, ymm/m256")]
    vpsubd_ymm_ymm_m256 = 3395,
    /// <summary>
    /// vpsubd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpsubd zmm {k1}{z}, zmm, zmm","vpsubd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpsubd_zmm_k1z_zmm_zmm = 3396,
    /// <summary>
    /// vpsubd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpsubd zmm {k1}{z}, zmm, m512","vpsubd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpsubd_zmm_k1z_zmm_m512 = 3397,
    /// <summary>
    /// vpsubd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpsubd zmm {k1}{z}, zmm, m32bcst","vpsubd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpsubd_zmm_k1z_zmm_m32bcst = 3398,
    /// <summary>
    /// vpsubq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpsubq xmm {k1}{z}, xmm, xmm","vpsubq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpsubq_xmm_k1z_xmm_xmm = 3399,
    /// <summary>
    /// vpsubq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpsubq xmm {k1}{z}, xmm, m128","vpsubq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpsubq_xmm_k1z_xmm_m128 = 3400,
    /// <summary>
    /// vpsubq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpsubq xmm {k1}{z}, xmm, m64bcst","vpsubq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpsubq_xmm_k1z_xmm_m64bcst = 3401,
    /// <summary>
    /// vpsubq xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsubq xmm, xmm, xmm","vpsubq xmm, xmm, xmm/m128")]
    vpsubq_xmm_xmm_xmm = 3402,
    /// <summary>
    /// vpsubq xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsubq xmm, xmm, m128","vpsubq xmm, xmm, xmm/m128")]
    vpsubq_xmm_xmm_m128 = 3403,
    /// <summary>
    /// vpsubq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpsubq ymm {k1}{z}, ymm, ymm","vpsubq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpsubq_ymm_k1z_ymm_ymm = 3404,
    /// <summary>
    /// vpsubq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpsubq ymm {k1}{z}, ymm, m256","vpsubq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpsubq_ymm_k1z_ymm_m256 = 3405,
    /// <summary>
    /// vpsubq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpsubq ymm {k1}{z}, ymm, m64bcst","vpsubq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpsubq_ymm_k1z_ymm_m64bcst = 3406,
    /// <summary>
    /// vpsubq ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsubq ymm, ymm, ymm","vpsubq ymm, ymm, ymm/m256")]
    vpsubq_ymm_ymm_ymm = 3407,
    /// <summary>
    /// vpsubq ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsubq ymm, ymm, m256","vpsubq ymm, ymm, ymm/m256")]
    vpsubq_ymm_ymm_m256 = 3408,
    /// <summary>
    /// vpsubq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpsubq zmm {k1}{z}, zmm, zmm","vpsubq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpsubq_zmm_k1z_zmm_zmm = 3409,
    /// <summary>
    /// vpsubq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpsubq zmm {k1}{z}, zmm, m512","vpsubq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpsubq_zmm_k1z_zmm_m512 = 3410,
    /// <summary>
    /// vpsubq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpsubq zmm {k1}{z}, zmm, m64bcst","vpsubq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpsubq_zmm_k1z_zmm_m64bcst = 3411,
    /// <summary>
    /// vpsubsb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsubsb xmm {k1}{z}, xmm, xmm","vpsubsb xmm {k1}{z}, xmm, xmm/m128")]
    vpsubsb_xmm_k1z_xmm_xmm = 3412,
    /// <summary>
    /// vpsubsb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsubsb xmm {k1}{z}, xmm, m128","vpsubsb xmm {k1}{z}, xmm, xmm/m128")]
    vpsubsb_xmm_k1z_xmm_m128 = 3413,
    /// <summary>
    /// vpsubsb xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsubsb xmm, xmm, xmm","vpsubsb xmm, xmm, xmm/m128")]
    vpsubsb_xmm_xmm_xmm = 3414,
    /// <summary>
    /// vpsubsb xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsubsb xmm, xmm, m128","vpsubsb xmm, xmm, xmm/m128")]
    vpsubsb_xmm_xmm_m128 = 3415,
    /// <summary>
    /// vpsubsb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsubsb ymm {k1}{z}, ymm, ymm","vpsubsb ymm {k1}{z}, ymm, ymm/m256")]
    vpsubsb_ymm_k1z_ymm_ymm = 3416,
    /// <summary>
    /// vpsubsb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsubsb ymm {k1}{z}, ymm, m256","vpsubsb ymm {k1}{z}, ymm, ymm/m256")]
    vpsubsb_ymm_k1z_ymm_m256 = 3417,
    /// <summary>
    /// vpsubsb ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsubsb ymm, ymm, ymm","vpsubsb ymm, ymm, ymm/m256")]
    vpsubsb_ymm_ymm_ymm = 3418,
    /// <summary>
    /// vpsubsb ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsubsb ymm, ymm, m256","vpsubsb ymm, ymm, ymm/m256")]
    vpsubsb_ymm_ymm_m256 = 3419,
    /// <summary>
    /// vpsubsb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpsubsb zmm {k1}{z}, zmm, zmm","vpsubsb zmm {k1}{z}, zmm, zmm/m512")]
    vpsubsb_zmm_k1z_zmm_zmm = 3420,
    /// <summary>
    /// vpsubsb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpsubsb zmm {k1}{z}, zmm, m512","vpsubsb zmm {k1}{z}, zmm, zmm/m512")]
    vpsubsb_zmm_k1z_zmm_m512 = 3421,
    /// <summary>
    /// vpsubsw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsubsw xmm {k1}{z}, xmm, xmm","vpsubsw xmm {k1}{z}, xmm, xmm/m128")]
    vpsubsw_xmm_k1z_xmm_xmm = 3422,
    /// <summary>
    /// vpsubsw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsubsw xmm {k1}{z}, xmm, m128","vpsubsw xmm {k1}{z}, xmm, xmm/m128")]
    vpsubsw_xmm_k1z_xmm_m128 = 3423,
    /// <summary>
    /// vpsubsw xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsubsw xmm, xmm, xmm","vpsubsw xmm, xmm, xmm/m128")]
    vpsubsw_xmm_xmm_xmm = 3424,
    /// <summary>
    /// vpsubsw xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsubsw xmm, xmm, m128","vpsubsw xmm, xmm, xmm/m128")]
    vpsubsw_xmm_xmm_m128 = 3425,
    /// <summary>
    /// vpsubsw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsubsw ymm {k1}{z}, ymm, ymm","vpsubsw ymm {k1}{z}, ymm, ymm/m256")]
    vpsubsw_ymm_k1z_ymm_ymm = 3426,
    /// <summary>
    /// vpsubsw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsubsw ymm {k1}{z}, ymm, m256","vpsubsw ymm {k1}{z}, ymm, ymm/m256")]
    vpsubsw_ymm_k1z_ymm_m256 = 3427,
    /// <summary>
    /// vpsubsw ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsubsw ymm, ymm, ymm","vpsubsw ymm, ymm, ymm/m256")]
    vpsubsw_ymm_ymm_ymm = 3428,
    /// <summary>
    /// vpsubsw ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsubsw ymm, ymm, m256","vpsubsw ymm, ymm, ymm/m256")]
    vpsubsw_ymm_ymm_m256 = 3429,
    /// <summary>
    /// vpsubusb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsubusb xmm {k1}{z}, xmm, xmm","vpsubusb xmm {k1}{z}, xmm, xmm/m128")]
    vpsubusb_xmm_k1z_xmm_xmm = 3430,
    /// <summary>
    /// vpsubusb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsubusb xmm {k1}{z}, xmm, m128","vpsubusb xmm {k1}{z}, xmm, xmm/m128")]
    vpsubusb_xmm_k1z_xmm_m128 = 3431,
    /// <summary>
    /// vpsubusb xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsubusb xmm, xmm, xmm","vpsubusb xmm, xmm, xmm/m128")]
    vpsubusb_xmm_xmm_xmm = 3432,
    /// <summary>
    /// vpsubusb xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsubusb xmm, xmm, m128","vpsubusb xmm, xmm, xmm/m128")]
    vpsubusb_xmm_xmm_m128 = 3433,
    /// <summary>
    /// vpsubusb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsubusb ymm {k1}{z}, ymm, ymm","vpsubusb ymm {k1}{z}, ymm, ymm/m256")]
    vpsubusb_ymm_k1z_ymm_ymm = 3434,
    /// <summary>
    /// vpsubusb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsubusb ymm {k1}{z}, ymm, m256","vpsubusb ymm {k1}{z}, ymm, ymm/m256")]
    vpsubusb_ymm_k1z_ymm_m256 = 3435,
    /// <summary>
    /// vpsubusb ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsubusb ymm, ymm, ymm","vpsubusb ymm, ymm, ymm/m256")]
    vpsubusb_ymm_ymm_ymm = 3436,
    /// <summary>
    /// vpsubusb ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsubusb ymm, ymm, m256","vpsubusb ymm, ymm, ymm/m256")]
    vpsubusb_ymm_ymm_m256 = 3437,
    /// <summary>
    /// vpsubusb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpsubusb zmm {k1}{z}, zmm, zmm","vpsubusb zmm {k1}{z}, zmm, zmm/m512")]
    vpsubusb_zmm_k1z_zmm_zmm = 3438,
    /// <summary>
    /// vpsubusb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpsubusb zmm {k1}{z}, zmm, m512","vpsubusb zmm {k1}{z}, zmm, zmm/m512")]
    vpsubusb_zmm_k1z_zmm_m512 = 3439,
    /// <summary>
    /// vpsubusw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsubusw xmm {k1}{z}, xmm, xmm","vpsubusw xmm {k1}{z}, xmm, xmm/m128")]
    vpsubusw_xmm_k1z_xmm_xmm = 3440,
    /// <summary>
    /// vpsubusw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsubusw xmm {k1}{z}, xmm, m128","vpsubusw xmm {k1}{z}, xmm, xmm/m128")]
    vpsubusw_xmm_k1z_xmm_m128 = 3441,
    /// <summary>
    /// vpsubusw xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsubusw xmm, xmm, xmm","vpsubusw xmm, xmm, xmm/m128")]
    vpsubusw_xmm_xmm_xmm = 3442,
    /// <summary>
    /// vpsubusw xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsubusw xmm, xmm, m128","vpsubusw xmm, xmm, xmm/m128")]
    vpsubusw_xmm_xmm_m128 = 3443,
    /// <summary>
    /// vpsubusw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsubusw ymm {k1}{z}, ymm, ymm","vpsubusw ymm {k1}{z}, ymm, ymm/m256")]
    vpsubusw_ymm_k1z_ymm_ymm = 3444,
    /// <summary>
    /// vpsubusw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsubusw ymm {k1}{z}, ymm, m256","vpsubusw ymm {k1}{z}, ymm, ymm/m256")]
    vpsubusw_ymm_k1z_ymm_m256 = 3445,
    /// <summary>
    /// vpsubusw ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsubusw ymm, ymm, ymm","vpsubusw ymm, ymm, ymm/m256")]
    vpsubusw_ymm_ymm_ymm = 3446,
    /// <summary>
    /// vpsubusw ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsubusw ymm, ymm, m256","vpsubusw ymm, ymm, ymm/m256")]
    vpsubusw_ymm_ymm_m256 = 3447,
    /// <summary>
    /// vpsubw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsubw xmm {k1}{z}, xmm, xmm","vpsubw xmm {k1}{z}, xmm, xmm/m128")]
    vpsubw_xmm_k1z_xmm_xmm = 3448,
    /// <summary>
    /// vpsubw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsubw xmm {k1}{z}, xmm, m128","vpsubw xmm {k1}{z}, xmm, xmm/m128")]
    vpsubw_xmm_k1z_xmm_m128 = 3449,
    /// <summary>
    /// vpsubw xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsubw xmm, xmm, xmm","vpsubw xmm, xmm, xmm/m128")]
    vpsubw_xmm_xmm_xmm = 3450,
    /// <summary>
    /// vpsubw xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsubw xmm, xmm, m128","vpsubw xmm, xmm, xmm/m128")]
    vpsubw_xmm_xmm_m128 = 3451,
    /// <summary>
    /// vpsubw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsubw ymm {k1}{z}, ymm, ymm","vpsubw ymm {k1}{z}, ymm, ymm/m256")]
    vpsubw_ymm_k1z_ymm_ymm = 3452,
    /// <summary>
    /// vpsubw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsubw ymm {k1}{z}, ymm, m256","vpsubw ymm {k1}{z}, ymm, ymm/m256")]
    vpsubw_ymm_k1z_ymm_m256 = 3453,
    /// <summary>
    /// vpsubw ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsubw ymm, ymm, ymm","vpsubw ymm, ymm, ymm/m256")]
    vpsubw_ymm_ymm_ymm = 3454,
    /// <summary>
    /// vpsubw ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsubw ymm, ymm, m256","vpsubw ymm, ymm, ymm/m256")]
    vpsubw_ymm_ymm_m256 = 3455,
    /// <summary>
    /// vpsubw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpsubw zmm {k1}{z}, zmm, zmm","vpsubw zmm {k1}{z}, zmm, zmm/m512")]
    vpsubw_zmm_k1z_zmm_zmm = 3456,
    /// <summary>
    /// vpsubw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpsubw zmm {k1}{z}, zmm, m512","vpsubw zmm {k1}{z}, zmm, zmm/m512")]
    vpsubw_zmm_k1z_zmm_m512 = 3457,
    /// <summary>
    /// vpternlogd xmm {k1}{z}, xmm, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vpternlogd xmm {k1}{z}, xmm, xmm, imm8","vpternlogd xmm {k1}{z}, xmm, xmm/m128/m32bcst, imm8")]
    vpternlogd_xmm_k1z_xmm_xmm_imm8 = 3458,
    /// <summary>
    /// vpternlogd xmm {k1}{z}, xmm, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vpternlogd xmm {k1}{z}, xmm, m128, imm8","vpternlogd xmm {k1}{z}, xmm, xmm/m128/m32bcst, imm8")]
    vpternlogd_xmm_k1z_xmm_m128_imm8 = 3459,
    /// <summary>
    /// vpternlogd xmm {k1}{z}, xmm, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vpternlogd xmm {k1}{z}, xmm, m32bcst, imm8","vpternlogd xmm {k1}{z}, xmm, xmm/m128/m32bcst, imm8")]
    vpternlogd_xmm_k1z_xmm_m32bcst_imm8 = 3460,
    /// <summary>
    /// vpternlogd ymm {k1}{z}, ymm, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vpternlogd ymm {k1}{z}, ymm, ymm, imm8","vpternlogd ymm {k1}{z}, ymm, ymm/m256/m32bcst, imm8")]
    vpternlogd_ymm_k1z_ymm_ymm_imm8 = 3461,
    /// <summary>
    /// vpternlogd ymm {k1}{z}, ymm, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vpternlogd ymm {k1}{z}, ymm, m256, imm8","vpternlogd ymm {k1}{z}, ymm, ymm/m256/m32bcst, imm8")]
    vpternlogd_ymm_k1z_ymm_m256_imm8 = 3462,
    /// <summary>
    /// vpternlogd ymm {k1}{z}, ymm, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vpternlogd ymm {k1}{z}, ymm, m32bcst, imm8","vpternlogd ymm {k1}{z}, ymm, ymm/m256/m32bcst, imm8")]
    vpternlogd_ymm_k1z_ymm_m32bcst_imm8 = 3463,
    /// <summary>
    /// vpternlogd zmm {k1}{z}, zmm, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vpternlogd zmm {k1}{z}, zmm, zmm, imm8","vpternlogd zmm {k1}{z}, zmm, zmm/m512/m32bcst, imm8")]
    vpternlogd_zmm_k1z_zmm_zmm_imm8 = 3464,
    /// <summary>
    /// vpternlogd zmm {k1}{z}, zmm, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vpternlogd zmm {k1}{z}, zmm, m512, imm8","vpternlogd zmm {k1}{z}, zmm, zmm/m512/m32bcst, imm8")]
    vpternlogd_zmm_k1z_zmm_m512_imm8 = 3465,
    /// <summary>
    /// vpternlogd zmm {k1}{z}, zmm, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vpternlogd zmm {k1}{z}, zmm, m32bcst, imm8","vpternlogd zmm {k1}{z}, zmm, zmm/m512/m32bcst, imm8")]
    vpternlogd_zmm_k1z_zmm_m32bcst_imm8 = 3466,
    /// <summary>
    /// vpternlogq xmm {k1}{z}, xmm, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("vpternlogq xmm {k1}{z}, xmm, xmm, imm8","vpternlogq xmm {k1}{z}, xmm, xmm/m128/m64bcst, imm8")]
    vpternlogq_xmm_k1z_xmm_xmm_imm8 = 3467,
    /// <summary>
    /// vpternlogq xmm {k1}{z}, xmm, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("vpternlogq xmm {k1}{z}, xmm, m128, imm8","vpternlogq xmm {k1}{z}, xmm, xmm/m128/m64bcst, imm8")]
    vpternlogq_xmm_k1z_xmm_m128_imm8 = 3468,
    /// <summary>
    /// vpternlogq xmm {k1}{z}, xmm, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("vpternlogq xmm {k1}{z}, xmm, m64bcst, imm8","vpternlogq xmm {k1}{z}, xmm, xmm/m128/m64bcst, imm8")]
    vpternlogq_xmm_k1z_xmm_m64bcst_imm8 = 3469,
    /// <summary>
    /// vpternlogq ymm {k1}{z}, ymm, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vpternlogq ymm {k1}{z}, ymm, ymm, imm8","vpternlogq ymm {k1}{z}, ymm, ymm/m256/m64bcst, imm8")]
    vpternlogq_ymm_k1z_ymm_ymm_imm8 = 3470,
    /// <summary>
    /// vpternlogq ymm {k1}{z}, ymm, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vpternlogq ymm {k1}{z}, ymm, m256, imm8","vpternlogq ymm {k1}{z}, ymm, ymm/m256/m64bcst, imm8")]
    vpternlogq_ymm_k1z_ymm_m256_imm8 = 3471,
    /// <summary>
    /// vpternlogq ymm {k1}{z}, ymm, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vpternlogq ymm {k1}{z}, ymm, m64bcst, imm8","vpternlogq ymm {k1}{z}, ymm, ymm/m256/m64bcst, imm8")]
    vpternlogq_ymm_k1z_ymm_m64bcst_imm8 = 3472,
    /// <summary>
    /// vpternlogq zmm {k1}{z}, zmm, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vpternlogq zmm {k1}{z}, zmm, zmm, imm8","vpternlogq zmm {k1}{z}, zmm, zmm/m512/m64bcst, imm8")]
    vpternlogq_zmm_k1z_zmm_zmm_imm8 = 3473,
    /// <summary>
    /// vpternlogq zmm {k1}{z}, zmm, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vpternlogq zmm {k1}{z}, zmm, m512, imm8","vpternlogq zmm {k1}{z}, zmm, zmm/m512/m64bcst, imm8")]
    vpternlogq_zmm_k1z_zmm_m512_imm8 = 3474,
    /// <summary>
    /// vpternlogq zmm {k1}{z}, zmm, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vpternlogq zmm {k1}{z}, zmm, m64bcst, imm8","vpternlogq zmm {k1}{z}, zmm, zmm/m512/m64bcst, imm8")]
    vpternlogq_zmm_k1z_zmm_m64bcst_imm8 = 3475,
    /// <summary>
    /// vptest xmm, xmm/m128
    /// </summary>
    [Symbol("vptest xmm, xmm","vptest xmm, xmm/m128")]
    vptest_xmm_xmm = 3476,
    /// <summary>
    /// vptest xmm, xmm/m128
    /// </summary>
    [Symbol("vptest xmm, m128","vptest xmm, xmm/m128")]
    vptest_xmm_m128 = 3477,
    /// <summary>
    /// vptest ymm, ymm/m256
    /// </summary>
    [Symbol("vptest ymm, ymm","vptest ymm, ymm/m256")]
    vptest_ymm_ymm = 3478,
    /// <summary>
    /// vptest ymm, ymm/m256
    /// </summary>
    [Symbol("vptest ymm, m256","vptest ymm, ymm/m256")]
    vptest_ymm_m256 = 3479,
    /// <summary>
    /// vptestmb k2 {k1}, xmm, xmm/m128
    /// </summary>
    [Symbol("vptestmb k2 {k1}, xmm, xmm","vptestmb k2 {k1}, xmm, xmm/m128")]
    vptestmb_k2_k1_xmm_xmm = 3480,
    /// <summary>
    /// vptestmb k2 {k1}, xmm, xmm/m128
    /// </summary>
    [Symbol("vptestmb k2 {k1}, xmm, m128","vptestmb k2 {k1}, xmm, xmm/m128")]
    vptestmb_k2_k1_xmm_m128 = 3481,
    /// <summary>
    /// vptestmb k2 {k1}, ymm, ymm/m256
    /// </summary>
    [Symbol("vptestmb k2 {k1}, ymm, ymm","vptestmb k2 {k1}, ymm, ymm/m256")]
    vptestmb_k2_k1_ymm_ymm = 3482,
    /// <summary>
    /// vptestmb k2 {k1}, ymm, ymm/m256
    /// </summary>
    [Symbol("vptestmb k2 {k1}, ymm, m256","vptestmb k2 {k1}, ymm, ymm/m256")]
    vptestmb_k2_k1_ymm_m256 = 3483,
    /// <summary>
    /// vptestmb k2 {k1}, zmm, zmm/m512
    /// </summary>
    [Symbol("vptestmb k2 {k1}, zmm, zmm","vptestmb k2 {k1}, zmm, zmm/m512")]
    vptestmb_k2_k1_zmm_zmm = 3484,
    /// <summary>
    /// vptestmb k2 {k1}, zmm, zmm/m512
    /// </summary>
    [Symbol("vptestmb k2 {k1}, zmm, m512","vptestmb k2 {k1}, zmm, zmm/m512")]
    vptestmb_k2_k1_zmm_m512 = 3485,
    /// <summary>
    /// vptestmd k2 {k1}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vptestmd k2 {k1}, xmm, xmm","vptestmd k2 {k1}, xmm, xmm/m128/m32bcst")]
    vptestmd_k2_k1_xmm_xmm = 3486,
    /// <summary>
    /// vptestmd k2 {k1}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vptestmd k2 {k1}, xmm, m128","vptestmd k2 {k1}, xmm, xmm/m128/m32bcst")]
    vptestmd_k2_k1_xmm_m128 = 3487,
    /// <summary>
    /// vptestmd k2 {k1}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vptestmd k2 {k1}, xmm, m32bcst","vptestmd k2 {k1}, xmm, xmm/m128/m32bcst")]
    vptestmd_k2_k1_xmm_m32bcst = 3488,
    /// <summary>
    /// vptestmd k2 {k1}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vptestmd k2 {k1}, ymm, ymm","vptestmd k2 {k1}, ymm, ymm/m256/m32bcst")]
    vptestmd_k2_k1_ymm_ymm = 3489,
    /// <summary>
    /// vptestmd k2 {k1}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vptestmd k2 {k1}, ymm, m256","vptestmd k2 {k1}, ymm, ymm/m256/m32bcst")]
    vptestmd_k2_k1_ymm_m256 = 3490,
    /// <summary>
    /// vptestmd k2 {k1}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vptestmd k2 {k1}, ymm, m32bcst","vptestmd k2 {k1}, ymm, ymm/m256/m32bcst")]
    vptestmd_k2_k1_ymm_m32bcst = 3491,
    /// <summary>
    /// vptestmd k2 {k1}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vptestmd k2 {k1}, zmm, zmm","vptestmd k2 {k1}, zmm, zmm/m512/m32bcst")]
    vptestmd_k2_k1_zmm_zmm = 3492,
    /// <summary>
    /// vptestmd k2 {k1}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vptestmd k2 {k1}, zmm, m512","vptestmd k2 {k1}, zmm, zmm/m512/m32bcst")]
    vptestmd_k2_k1_zmm_m512 = 3493,
    /// <summary>
    /// vptestmd k2 {k1}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vptestmd k2 {k1}, zmm, m32bcst","vptestmd k2 {k1}, zmm, zmm/m512/m32bcst")]
    vptestmd_k2_k1_zmm_m32bcst = 3494,
    /// <summary>
    /// vptestmq k2 {k1}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vptestmq k2 {k1}, xmm, xmm","vptestmq k2 {k1}, xmm, xmm/m128/m64bcst")]
    vptestmq_k2_k1_xmm_xmm = 3495,
    /// <summary>
    /// vptestmq k2 {k1}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vptestmq k2 {k1}, xmm, m128","vptestmq k2 {k1}, xmm, xmm/m128/m64bcst")]
    vptestmq_k2_k1_xmm_m128 = 3496,
    /// <summary>
    /// vptestmq k2 {k1}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vptestmq k2 {k1}, xmm, m64bcst","vptestmq k2 {k1}, xmm, xmm/m128/m64bcst")]
    vptestmq_k2_k1_xmm_m64bcst = 3497,
    /// <summary>
    /// vptestmq k2 {k1}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vptestmq k2 {k1}, ymm, ymm","vptestmq k2 {k1}, ymm, ymm/m256/m64bcst")]
    vptestmq_k2_k1_ymm_ymm = 3498,
    /// <summary>
    /// vptestmq k2 {k1}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vptestmq k2 {k1}, ymm, m256","vptestmq k2 {k1}, ymm, ymm/m256/m64bcst")]
    vptestmq_k2_k1_ymm_m256 = 3499,
    /// <summary>
    /// vptestmq k2 {k1}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vptestmq k2 {k1}, ymm, m64bcst","vptestmq k2 {k1}, ymm, ymm/m256/m64bcst")]
    vptestmq_k2_k1_ymm_m64bcst = 3500,
    /// <summary>
    /// vptestmq k2 {k1}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vptestmq k2 {k1}, zmm, zmm","vptestmq k2 {k1}, zmm, zmm/m512/m64bcst")]
    vptestmq_k2_k1_zmm_zmm = 3501,
    /// <summary>
    /// vptestmq k2 {k1}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vptestmq k2 {k1}, zmm, m512","vptestmq k2 {k1}, zmm, zmm/m512/m64bcst")]
    vptestmq_k2_k1_zmm_m512 = 3502,
    /// <summary>
    /// vptestmq k2 {k1}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vptestmq k2 {k1}, zmm, m64bcst","vptestmq k2 {k1}, zmm, zmm/m512/m64bcst")]
    vptestmq_k2_k1_zmm_m64bcst = 3503,
    /// <summary>
    /// vptestmw k2 {k1}, xmm, xmm/m128
    /// </summary>
    [Symbol("vptestmw k2 {k1}, xmm, xmm","vptestmw k2 {k1}, xmm, xmm/m128")]
    vptestmw_k2_k1_xmm_xmm = 3504,
    /// <summary>
    /// vptestmw k2 {k1}, xmm, xmm/m128
    /// </summary>
    [Symbol("vptestmw k2 {k1}, xmm, m128","vptestmw k2 {k1}, xmm, xmm/m128")]
    vptestmw_k2_k1_xmm_m128 = 3505,
    /// <summary>
    /// vptestmw k2 {k1}, ymm, ymm/m256
    /// </summary>
    [Symbol("vptestmw k2 {k1}, ymm, ymm","vptestmw k2 {k1}, ymm, ymm/m256")]
    vptestmw_k2_k1_ymm_ymm = 3506,
    /// <summary>
    /// vptestmw k2 {k1}, ymm, ymm/m256
    /// </summary>
    [Symbol("vptestmw k2 {k1}, ymm, m256","vptestmw k2 {k1}, ymm, ymm/m256")]
    vptestmw_k2_k1_ymm_m256 = 3507,
    /// <summary>
    /// vptestmw k2 {k1}, zmm, zmm/m512
    /// </summary>
    [Symbol("vptestmw k2 {k1}, zmm, zmm","vptestmw k2 {k1}, zmm, zmm/m512")]
    vptestmw_k2_k1_zmm_zmm = 3508,
    /// <summary>
    /// vptestmw k2 {k1}, zmm, zmm/m512
    /// </summary>
    [Symbol("vptestmw k2 {k1}, zmm, m512","vptestmw k2 {k1}, zmm, zmm/m512")]
    vptestmw_k2_k1_zmm_m512 = 3509,
    /// <summary>
    /// vptestnmb k2 {k1}, xmm, xmm/m128
    /// </summary>
    [Symbol("vptestnmb k2 {k1}, xmm, xmm","vptestnmb k2 {k1}, xmm, xmm/m128")]
    vptestnmb_k2_k1_xmm_xmm = 3510,
    /// <summary>
    /// vptestnmb k2 {k1}, xmm, xmm/m128
    /// </summary>
    [Symbol("vptestnmb k2 {k1}, xmm, m128","vptestnmb k2 {k1}, xmm, xmm/m128")]
    vptestnmb_k2_k1_xmm_m128 = 3511,
    /// <summary>
    /// vptestnmb k2 {k1}, ymm, ymm/m256
    /// </summary>
    [Symbol("vptestnmb k2 {k1}, ymm, ymm","vptestnmb k2 {k1}, ymm, ymm/m256")]
    vptestnmb_k2_k1_ymm_ymm = 3512,
    /// <summary>
    /// vptestnmb k2 {k1}, ymm, ymm/m256
    /// </summary>
    [Symbol("vptestnmb k2 {k1}, ymm, m256","vptestnmb k2 {k1}, ymm, ymm/m256")]
    vptestnmb_k2_k1_ymm_m256 = 3513,
    /// <summary>
    /// vptestnmb k2 {k1}, zmm, zmm/m512
    /// </summary>
    [Symbol("vptestnmb k2 {k1}, zmm, zmm","vptestnmb k2 {k1}, zmm, zmm/m512")]
    vptestnmb_k2_k1_zmm_zmm = 3514,
    /// <summary>
    /// vptestnmb k2 {k1}, zmm, zmm/m512
    /// </summary>
    [Symbol("vptestnmb k2 {k1}, zmm, m512","vptestnmb k2 {k1}, zmm, zmm/m512")]
    vptestnmb_k2_k1_zmm_m512 = 3515,
    /// <summary>
    /// vptestnmd k2 {k1}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vptestnmd k2 {k1}, xmm, xmm","vptestnmd k2 {k1}, xmm, xmm/m128/m32bcst")]
    vptestnmd_k2_k1_xmm_xmm = 3516,
    /// <summary>
    /// vptestnmd k2 {k1}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vptestnmd k2 {k1}, xmm, m128","vptestnmd k2 {k1}, xmm, xmm/m128/m32bcst")]
    vptestnmd_k2_k1_xmm_m128 = 3517,
    /// <summary>
    /// vptestnmd k2 {k1}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vptestnmd k2 {k1}, xmm, m32bcst","vptestnmd k2 {k1}, xmm, xmm/m128/m32bcst")]
    vptestnmd_k2_k1_xmm_m32bcst = 3518,
    /// <summary>
    /// vptestnmd k2 {k1}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vptestnmd k2 {k1}, ymm, ymm","vptestnmd k2 {k1}, ymm, ymm/m256/m32bcst")]
    vptestnmd_k2_k1_ymm_ymm = 3519,
    /// <summary>
    /// vptestnmd k2 {k1}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vptestnmd k2 {k1}, ymm, m256","vptestnmd k2 {k1}, ymm, ymm/m256/m32bcst")]
    vptestnmd_k2_k1_ymm_m256 = 3520,
    /// <summary>
    /// vptestnmd k2 {k1}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vptestnmd k2 {k1}, ymm, m32bcst","vptestnmd k2 {k1}, ymm, ymm/m256/m32bcst")]
    vptestnmd_k2_k1_ymm_m32bcst = 3521,
    /// <summary>
    /// vptestnmd k2 {k1}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vptestnmd k2 {k1}, zmm, zmm","vptestnmd k2 {k1}, zmm, zmm/m512/m32bcst")]
    vptestnmd_k2_k1_zmm_zmm = 3522,
    /// <summary>
    /// vptestnmd k2 {k1}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vptestnmd k2 {k1}, zmm, m512","vptestnmd k2 {k1}, zmm, zmm/m512/m32bcst")]
    vptestnmd_k2_k1_zmm_m512 = 3523,
    /// <summary>
    /// vptestnmd k2 {k1}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vptestnmd k2 {k1}, zmm, m32bcst","vptestnmd k2 {k1}, zmm, zmm/m512/m32bcst")]
    vptestnmd_k2_k1_zmm_m32bcst = 3524,
    /// <summary>
    /// vptestnmq k2 {k1}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vptestnmq k2 {k1}, xmm, xmm","vptestnmq k2 {k1}, xmm, xmm/m128/m64bcst")]
    vptestnmq_k2_k1_xmm_xmm = 3525,
    /// <summary>
    /// vptestnmq k2 {k1}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vptestnmq k2 {k1}, xmm, m128","vptestnmq k2 {k1}, xmm, xmm/m128/m64bcst")]
    vptestnmq_k2_k1_xmm_m128 = 3526,
    /// <summary>
    /// vptestnmq k2 {k1}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vptestnmq k2 {k1}, xmm, m64bcst","vptestnmq k2 {k1}, xmm, xmm/m128/m64bcst")]
    vptestnmq_k2_k1_xmm_m64bcst = 3527,
    /// <summary>
    /// vptestnmq k2 {k1}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vptestnmq k2 {k1}, ymm, ymm","vptestnmq k2 {k1}, ymm, ymm/m256/m64bcst")]
    vptestnmq_k2_k1_ymm_ymm = 3528,
    /// <summary>
    /// vptestnmq k2 {k1}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vptestnmq k2 {k1}, ymm, m256","vptestnmq k2 {k1}, ymm, ymm/m256/m64bcst")]
    vptestnmq_k2_k1_ymm_m256 = 3529,
    /// <summary>
    /// vptestnmq k2 {k1}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vptestnmq k2 {k1}, ymm, m64bcst","vptestnmq k2 {k1}, ymm, ymm/m256/m64bcst")]
    vptestnmq_k2_k1_ymm_m64bcst = 3530,
    /// <summary>
    /// vptestnmq k2 {k1}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vptestnmq k2 {k1}, zmm, zmm","vptestnmq k2 {k1}, zmm, zmm/m512/m64bcst")]
    vptestnmq_k2_k1_zmm_zmm = 3531,
    /// <summary>
    /// vptestnmq k2 {k1}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vptestnmq k2 {k1}, zmm, m512","vptestnmq k2 {k1}, zmm, zmm/m512/m64bcst")]
    vptestnmq_k2_k1_zmm_m512 = 3532,
    /// <summary>
    /// vptestnmq k2 {k1}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vptestnmq k2 {k1}, zmm, m64bcst","vptestnmq k2 {k1}, zmm, zmm/m512/m64bcst")]
    vptestnmq_k2_k1_zmm_m64bcst = 3533,
    /// <summary>
    /// vptestnmw k2 {k1}, xmm, xmm/m128
    /// </summary>
    [Symbol("vptestnmw k2 {k1}, xmm, xmm","vptestnmw k2 {k1}, xmm, xmm/m128")]
    vptestnmw_k2_k1_xmm_xmm = 3534,
    /// <summary>
    /// vptestnmw k2 {k1}, xmm, xmm/m128
    /// </summary>
    [Symbol("vptestnmw k2 {k1}, xmm, m128","vptestnmw k2 {k1}, xmm, xmm/m128")]
    vptestnmw_k2_k1_xmm_m128 = 3535,
    /// <summary>
    /// vptestnmw k2 {k1}, ymm, ymm/m256
    /// </summary>
    [Symbol("vptestnmw k2 {k1}, ymm, ymm","vptestnmw k2 {k1}, ymm, ymm/m256")]
    vptestnmw_k2_k1_ymm_ymm = 3536,
    /// <summary>
    /// vptestnmw k2 {k1}, ymm, ymm/m256
    /// </summary>
    [Symbol("vptestnmw k2 {k1}, ymm, m256","vptestnmw k2 {k1}, ymm, ymm/m256")]
    vptestnmw_k2_k1_ymm_m256 = 3537,
    /// <summary>
    /// vptestnmw k2 {k1}, zmm, zmm/m512
    /// </summary>
    [Symbol("vptestnmw k2 {k1}, zmm, zmm","vptestnmw k2 {k1}, zmm, zmm/m512")]
    vptestnmw_k2_k1_zmm_zmm = 3538,
    /// <summary>
    /// vptestnmw k2 {k1}, zmm, zmm/m512
    /// </summary>
    [Symbol("vptestnmw k2 {k1}, zmm, m512","vptestnmw k2 {k1}, zmm, zmm/m512")]
    vptestnmw_k2_k1_zmm_m512 = 3539,
    /// <summary>
    /// vpunpckhbw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpunpckhbw xmm {k1}{z}, xmm, xmm","vpunpckhbw xmm {k1}{z}, xmm, xmm/m128")]
    vpunpckhbw_xmm_k1z_xmm_xmm = 3540,
    /// <summary>
    /// vpunpckhbw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpunpckhbw xmm {k1}{z}, xmm, m128","vpunpckhbw xmm {k1}{z}, xmm, xmm/m128")]
    vpunpckhbw_xmm_k1z_xmm_m128 = 3541,
    /// <summary>
    /// vpunpckhbw xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpunpckhbw xmm, xmm, xmm","vpunpckhbw xmm, xmm, xmm/m128")]
    vpunpckhbw_xmm_xmm_xmm = 3542,
    /// <summary>
    /// vpunpckhbw xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpunpckhbw xmm, xmm, m128","vpunpckhbw xmm, xmm, xmm/m128")]
    vpunpckhbw_xmm_xmm_m128 = 3543,
    /// <summary>
    /// vpunpckhbw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpunpckhbw ymm {k1}{z}, ymm, ymm","vpunpckhbw ymm {k1}{z}, ymm, ymm/m256")]
    vpunpckhbw_ymm_k1z_ymm_ymm = 3544,
    /// <summary>
    /// vpunpckhbw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpunpckhbw ymm {k1}{z}, ymm, m256","vpunpckhbw ymm {k1}{z}, ymm, ymm/m256")]
    vpunpckhbw_ymm_k1z_ymm_m256 = 3545,
    /// <summary>
    /// vpunpckhbw ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpunpckhbw ymm, ymm, ymm","vpunpckhbw ymm, ymm, ymm/m256")]
    vpunpckhbw_ymm_ymm_ymm = 3546,
    /// <summary>
    /// vpunpckhbw ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpunpckhbw ymm, ymm, m256","vpunpckhbw ymm, ymm, ymm/m256")]
    vpunpckhbw_ymm_ymm_m256 = 3547,
    /// <summary>
    /// vpunpckhbw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpunpckhbw zmm {k1}{z}, zmm, zmm","vpunpckhbw zmm {k1}{z}, zmm, zmm/m512")]
    vpunpckhbw_zmm_k1z_zmm_zmm = 3548,
    /// <summary>
    /// vpunpckhbw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpunpckhbw zmm {k1}{z}, zmm, m512","vpunpckhbw zmm {k1}{z}, zmm, zmm/m512")]
    vpunpckhbw_zmm_k1z_zmm_m512 = 3549,
    /// <summary>
    /// vpunpckhdq xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpunpckhdq xmm {k1}{z}, xmm, xmm","vpunpckhdq xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpunpckhdq_xmm_k1z_xmm_xmm = 3550,
    /// <summary>
    /// vpunpckhdq xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpunpckhdq xmm {k1}{z}, xmm, m128","vpunpckhdq xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpunpckhdq_xmm_k1z_xmm_m128 = 3551,
    /// <summary>
    /// vpunpckhdq xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpunpckhdq xmm {k1}{z}, xmm, m32bcst","vpunpckhdq xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpunpckhdq_xmm_k1z_xmm_m32bcst = 3552,
    /// <summary>
    /// vpunpckhdq xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpunpckhdq xmm, xmm, xmm","vpunpckhdq xmm, xmm, xmm/m128")]
    vpunpckhdq_xmm_xmm_xmm = 3553,
    /// <summary>
    /// vpunpckhdq xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpunpckhdq xmm, xmm, m128","vpunpckhdq xmm, xmm, xmm/m128")]
    vpunpckhdq_xmm_xmm_m128 = 3554,
    /// <summary>
    /// vpunpckhdq ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpunpckhdq ymm {k1}{z}, ymm, ymm","vpunpckhdq ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpunpckhdq_ymm_k1z_ymm_ymm = 3555,
    /// <summary>
    /// vpunpckhdq ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpunpckhdq ymm {k1}{z}, ymm, m256","vpunpckhdq ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpunpckhdq_ymm_k1z_ymm_m256 = 3556,
    /// <summary>
    /// vpunpckhdq ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpunpckhdq ymm {k1}{z}, ymm, m32bcst","vpunpckhdq ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpunpckhdq_ymm_k1z_ymm_m32bcst = 3557,
    /// <summary>
    /// vpunpckhdq ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpunpckhdq ymm, ymm, ymm","vpunpckhdq ymm, ymm, ymm/m256")]
    vpunpckhdq_ymm_ymm_ymm = 3558,
    /// <summary>
    /// vpunpckhdq ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpunpckhdq ymm, ymm, m256","vpunpckhdq ymm, ymm, ymm/m256")]
    vpunpckhdq_ymm_ymm_m256 = 3559,
    /// <summary>
    /// vpunpckhdq zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpunpckhdq zmm {k1}{z}, zmm, zmm","vpunpckhdq zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpunpckhdq_zmm_k1z_zmm_zmm = 3560,
    /// <summary>
    /// vpunpckhdq zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpunpckhdq zmm {k1}{z}, zmm, m512","vpunpckhdq zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpunpckhdq_zmm_k1z_zmm_m512 = 3561,
    /// <summary>
    /// vpunpckhdq zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpunpckhdq zmm {k1}{z}, zmm, m32bcst","vpunpckhdq zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpunpckhdq_zmm_k1z_zmm_m32bcst = 3562,
    /// <summary>
    /// vpunpckhqdq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpunpckhqdq xmm {k1}{z}, xmm, xmm","vpunpckhqdq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpunpckhqdq_xmm_k1z_xmm_xmm = 3563,
    /// <summary>
    /// vpunpckhqdq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpunpckhqdq xmm {k1}{z}, xmm, m128","vpunpckhqdq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpunpckhqdq_xmm_k1z_xmm_m128 = 3564,
    /// <summary>
    /// vpunpckhqdq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpunpckhqdq xmm {k1}{z}, xmm, m64bcst","vpunpckhqdq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpunpckhqdq_xmm_k1z_xmm_m64bcst = 3565,
    /// <summary>
    /// vpunpckhqdq xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpunpckhqdq xmm, xmm, xmm","vpunpckhqdq xmm, xmm, xmm/m128")]
    vpunpckhqdq_xmm_xmm_xmm = 3566,
    /// <summary>
    /// vpunpckhqdq xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpunpckhqdq xmm, xmm, m128","vpunpckhqdq xmm, xmm, xmm/m128")]
    vpunpckhqdq_xmm_xmm_m128 = 3567,
    /// <summary>
    /// vpunpckhqdq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpunpckhqdq ymm {k1}{z}, ymm, ymm","vpunpckhqdq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpunpckhqdq_ymm_k1z_ymm_ymm = 3568,
    /// <summary>
    /// vpunpckhqdq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpunpckhqdq ymm {k1}{z}, ymm, m256","vpunpckhqdq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpunpckhqdq_ymm_k1z_ymm_m256 = 3569,
    /// <summary>
    /// vpunpckhqdq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpunpckhqdq ymm {k1}{z}, ymm, m64bcst","vpunpckhqdq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpunpckhqdq_ymm_k1z_ymm_m64bcst = 3570,
    /// <summary>
    /// vpunpckhqdq ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpunpckhqdq ymm, ymm, ymm","vpunpckhqdq ymm, ymm, ymm/m256")]
    vpunpckhqdq_ymm_ymm_ymm = 3571,
    /// <summary>
    /// vpunpckhqdq ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpunpckhqdq ymm, ymm, m256","vpunpckhqdq ymm, ymm, ymm/m256")]
    vpunpckhqdq_ymm_ymm_m256 = 3572,
    /// <summary>
    /// vpunpckhqdq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpunpckhqdq zmm {k1}{z}, zmm, zmm","vpunpckhqdq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpunpckhqdq_zmm_k1z_zmm_zmm = 3573,
    /// <summary>
    /// vpunpckhqdq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpunpckhqdq zmm {k1}{z}, zmm, m512","vpunpckhqdq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpunpckhqdq_zmm_k1z_zmm_m512 = 3574,
    /// <summary>
    /// vpunpckhqdq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpunpckhqdq zmm {k1}{z}, zmm, m64bcst","vpunpckhqdq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpunpckhqdq_zmm_k1z_zmm_m64bcst = 3575,
    /// <summary>
    /// vpunpckhwd xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpunpckhwd xmm {k1}{z}, xmm, xmm","vpunpckhwd xmm {k1}{z}, xmm, xmm/m128")]
    vpunpckhwd_xmm_k1z_xmm_xmm = 3576,
    /// <summary>
    /// vpunpckhwd xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpunpckhwd xmm {k1}{z}, xmm, m128","vpunpckhwd xmm {k1}{z}, xmm, xmm/m128")]
    vpunpckhwd_xmm_k1z_xmm_m128 = 3577,
    /// <summary>
    /// vpunpckhwd xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpunpckhwd xmm, xmm, xmm","vpunpckhwd xmm, xmm, xmm/m128")]
    vpunpckhwd_xmm_xmm_xmm = 3578,
    /// <summary>
    /// vpunpckhwd xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpunpckhwd xmm, xmm, m128","vpunpckhwd xmm, xmm, xmm/m128")]
    vpunpckhwd_xmm_xmm_m128 = 3579,
    /// <summary>
    /// vpunpckhwd ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpunpckhwd ymm {k1}{z}, ymm, ymm","vpunpckhwd ymm {k1}{z}, ymm, ymm/m256")]
    vpunpckhwd_ymm_k1z_ymm_ymm = 3580,
    /// <summary>
    /// vpunpckhwd ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpunpckhwd ymm {k1}{z}, ymm, m256","vpunpckhwd ymm {k1}{z}, ymm, ymm/m256")]
    vpunpckhwd_ymm_k1z_ymm_m256 = 3581,
    /// <summary>
    /// vpunpckhwd ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpunpckhwd ymm, ymm, ymm","vpunpckhwd ymm, ymm, ymm/m256")]
    vpunpckhwd_ymm_ymm_ymm = 3582,
    /// <summary>
    /// vpunpckhwd ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpunpckhwd ymm, ymm, m256","vpunpckhwd ymm, ymm, ymm/m256")]
    vpunpckhwd_ymm_ymm_m256 = 3583,
    /// <summary>
    /// vpunpckhwd zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpunpckhwd zmm {k1}{z}, zmm, zmm","vpunpckhwd zmm {k1}{z}, zmm, zmm/m512")]
    vpunpckhwd_zmm_k1z_zmm_zmm = 3584,
    /// <summary>
    /// vpunpckhwd zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpunpckhwd zmm {k1}{z}, zmm, m512","vpunpckhwd zmm {k1}{z}, zmm, zmm/m512")]
    vpunpckhwd_zmm_k1z_zmm_m512 = 3585,
    /// <summary>
    /// vpunpcklbw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpunpcklbw xmm {k1}{z}, xmm, xmm","vpunpcklbw xmm {k1}{z}, xmm, xmm/m128")]
    vpunpcklbw_xmm_k1z_xmm_xmm = 3586,
    /// <summary>
    /// vpunpcklbw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpunpcklbw xmm {k1}{z}, xmm, m128","vpunpcklbw xmm {k1}{z}, xmm, xmm/m128")]
    vpunpcklbw_xmm_k1z_xmm_m128 = 3587,
    /// <summary>
    /// vpunpcklbw xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpunpcklbw xmm, xmm, xmm","vpunpcklbw xmm, xmm, xmm/m128")]
    vpunpcklbw_xmm_xmm_xmm = 3588,
    /// <summary>
    /// vpunpcklbw xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpunpcklbw xmm, xmm, m128","vpunpcklbw xmm, xmm, xmm/m128")]
    vpunpcklbw_xmm_xmm_m128 = 3589,
    /// <summary>
    /// vpunpcklbw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpunpcklbw ymm {k1}{z}, ymm, ymm","vpunpcklbw ymm {k1}{z}, ymm, ymm/m256")]
    vpunpcklbw_ymm_k1z_ymm_ymm = 3590,
    /// <summary>
    /// vpunpcklbw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpunpcklbw ymm {k1}{z}, ymm, m256","vpunpcklbw ymm {k1}{z}, ymm, ymm/m256")]
    vpunpcklbw_ymm_k1z_ymm_m256 = 3591,
    /// <summary>
    /// vpunpcklbw ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpunpcklbw ymm, ymm, ymm","vpunpcklbw ymm, ymm, ymm/m256")]
    vpunpcklbw_ymm_ymm_ymm = 3592,
    /// <summary>
    /// vpunpcklbw ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpunpcklbw ymm, ymm, m256","vpunpcklbw ymm, ymm, ymm/m256")]
    vpunpcklbw_ymm_ymm_m256 = 3593,
    /// <summary>
    /// vpunpcklbw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpunpcklbw zmm {k1}{z}, zmm, zmm","vpunpcklbw zmm {k1}{z}, zmm, zmm/m512")]
    vpunpcklbw_zmm_k1z_zmm_zmm = 3594,
    /// <summary>
    /// vpunpcklbw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpunpcklbw zmm {k1}{z}, zmm, m512","vpunpcklbw zmm {k1}{z}, zmm, zmm/m512")]
    vpunpcklbw_zmm_k1z_zmm_m512 = 3595,
    /// <summary>
    /// vpunpckldq xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpunpckldq xmm {k1}{z}, xmm, xmm","vpunpckldq xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpunpckldq_xmm_k1z_xmm_xmm = 3596,
    /// <summary>
    /// vpunpckldq xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpunpckldq xmm {k1}{z}, xmm, m128","vpunpckldq xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpunpckldq_xmm_k1z_xmm_m128 = 3597,
    /// <summary>
    /// vpunpckldq xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpunpckldq xmm {k1}{z}, xmm, m32bcst","vpunpckldq xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpunpckldq_xmm_k1z_xmm_m32bcst = 3598,
    /// <summary>
    /// vpunpckldq xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpunpckldq xmm, xmm, xmm","vpunpckldq xmm, xmm, xmm/m128")]
    vpunpckldq_xmm_xmm_xmm = 3599,
    /// <summary>
    /// vpunpckldq xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpunpckldq xmm, xmm, m128","vpunpckldq xmm, xmm, xmm/m128")]
    vpunpckldq_xmm_xmm_m128 = 3600,
    /// <summary>
    /// vpunpckldq ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpunpckldq ymm {k1}{z}, ymm, ymm","vpunpckldq ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpunpckldq_ymm_k1z_ymm_ymm = 3601,
    /// <summary>
    /// vpunpckldq ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpunpckldq ymm {k1}{z}, ymm, m256","vpunpckldq ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpunpckldq_ymm_k1z_ymm_m256 = 3602,
    /// <summary>
    /// vpunpckldq ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpunpckldq ymm {k1}{z}, ymm, m32bcst","vpunpckldq ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpunpckldq_ymm_k1z_ymm_m32bcst = 3603,
    /// <summary>
    /// vpunpckldq ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpunpckldq ymm, ymm, ymm","vpunpckldq ymm, ymm, ymm/m256")]
    vpunpckldq_ymm_ymm_ymm = 3604,
    /// <summary>
    /// vpunpckldq ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpunpckldq ymm, ymm, m256","vpunpckldq ymm, ymm, ymm/m256")]
    vpunpckldq_ymm_ymm_m256 = 3605,
    /// <summary>
    /// vpunpckldq zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpunpckldq zmm {k1}{z}, zmm, zmm","vpunpckldq zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpunpckldq_zmm_k1z_zmm_zmm = 3606,
    /// <summary>
    /// vpunpckldq zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpunpckldq zmm {k1}{z}, zmm, m512","vpunpckldq zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpunpckldq_zmm_k1z_zmm_m512 = 3607,
    /// <summary>
    /// vpunpckldq zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpunpckldq zmm {k1}{z}, zmm, m32bcst","vpunpckldq zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpunpckldq_zmm_k1z_zmm_m32bcst = 3608,
    /// <summary>
    /// vpunpcklqdq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpunpcklqdq xmm {k1}{z}, xmm, xmm","vpunpcklqdq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpunpcklqdq_xmm_k1z_xmm_xmm = 3609,
    /// <summary>
    /// vpunpcklqdq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpunpcklqdq xmm {k1}{z}, xmm, m128","vpunpcklqdq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpunpcklqdq_xmm_k1z_xmm_m128 = 3610,
    /// <summary>
    /// vpunpcklqdq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpunpcklqdq xmm {k1}{z}, xmm, m64bcst","vpunpcklqdq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpunpcklqdq_xmm_k1z_xmm_m64bcst = 3611,
    /// <summary>
    /// vpunpcklqdq xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpunpcklqdq xmm, xmm, xmm","vpunpcklqdq xmm, xmm, xmm/m128")]
    vpunpcklqdq_xmm_xmm_xmm = 3612,
    /// <summary>
    /// vpunpcklqdq xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpunpcklqdq xmm, xmm, m128","vpunpcklqdq xmm, xmm, xmm/m128")]
    vpunpcklqdq_xmm_xmm_m128 = 3613,
    /// <summary>
    /// vpunpcklqdq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpunpcklqdq ymm {k1}{z}, ymm, ymm","vpunpcklqdq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpunpcklqdq_ymm_k1z_ymm_ymm = 3614,
    /// <summary>
    /// vpunpcklqdq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpunpcklqdq ymm {k1}{z}, ymm, m256","vpunpcklqdq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpunpcklqdq_ymm_k1z_ymm_m256 = 3615,
    /// <summary>
    /// vpunpcklqdq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpunpcklqdq ymm {k1}{z}, ymm, m64bcst","vpunpcklqdq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpunpcklqdq_ymm_k1z_ymm_m64bcst = 3616,
    /// <summary>
    /// vpunpcklqdq ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpunpcklqdq ymm, ymm, ymm","vpunpcklqdq ymm, ymm, ymm/m256")]
    vpunpcklqdq_ymm_ymm_ymm = 3617,
    /// <summary>
    /// vpunpcklqdq ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpunpcklqdq ymm, ymm, m256","vpunpcklqdq ymm, ymm, ymm/m256")]
    vpunpcklqdq_ymm_ymm_m256 = 3618,
    /// <summary>
    /// vpunpcklqdq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpunpcklqdq zmm {k1}{z}, zmm, zmm","vpunpcklqdq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpunpcklqdq_zmm_k1z_zmm_zmm = 3619,
    /// <summary>
    /// vpunpcklqdq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpunpcklqdq zmm {k1}{z}, zmm, m512","vpunpcklqdq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpunpcklqdq_zmm_k1z_zmm_m512 = 3620,
    /// <summary>
    /// vpunpcklqdq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpunpcklqdq zmm {k1}{z}, zmm, m64bcst","vpunpcklqdq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpunpcklqdq_zmm_k1z_zmm_m64bcst = 3621,
    /// <summary>
    /// vpunpcklwd xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpunpcklwd xmm {k1}{z}, xmm, xmm","vpunpcklwd xmm {k1}{z}, xmm, xmm/m128")]
    vpunpcklwd_xmm_k1z_xmm_xmm = 3622,
    /// <summary>
    /// vpunpcklwd xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpunpcklwd xmm {k1}{z}, xmm, m128","vpunpcklwd xmm {k1}{z}, xmm, xmm/m128")]
    vpunpcklwd_xmm_k1z_xmm_m128 = 3623,
    /// <summary>
    /// vpunpcklwd xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpunpcklwd xmm, xmm, xmm","vpunpcklwd xmm, xmm, xmm/m128")]
    vpunpcklwd_xmm_xmm_xmm = 3624,
    /// <summary>
    /// vpunpcklwd xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpunpcklwd xmm, xmm, m128","vpunpcklwd xmm, xmm, xmm/m128")]
    vpunpcklwd_xmm_xmm_m128 = 3625,
    /// <summary>
    /// vpunpcklwd ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpunpcklwd ymm {k1}{z}, ymm, ymm","vpunpcklwd ymm {k1}{z}, ymm, ymm/m256")]
    vpunpcklwd_ymm_k1z_ymm_ymm = 3626,
    /// <summary>
    /// vpunpcklwd ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpunpcklwd ymm {k1}{z}, ymm, m256","vpunpcklwd ymm {k1}{z}, ymm, ymm/m256")]
    vpunpcklwd_ymm_k1z_ymm_m256 = 3627,
    /// <summary>
    /// vpunpcklwd ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpunpcklwd ymm, ymm, ymm","vpunpcklwd ymm, ymm, ymm/m256")]
    vpunpcklwd_ymm_ymm_ymm = 3628,
    /// <summary>
    /// vpunpcklwd ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpunpcklwd ymm, ymm, m256","vpunpcklwd ymm, ymm, ymm/m256")]
    vpunpcklwd_ymm_ymm_m256 = 3629,
    /// <summary>
    /// vpunpcklwd zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpunpcklwd zmm {k1}{z}, zmm, zmm","vpunpcklwd zmm {k1}{z}, zmm, zmm/m512")]
    vpunpcklwd_zmm_k1z_zmm_zmm = 3630,
    /// <summary>
    /// vpunpcklwd zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpunpcklwd zmm {k1}{z}, zmm, m512","vpunpcklwd zmm {k1}{z}, zmm, zmm/m512")]
    vpunpcklwd_zmm_k1z_zmm_m512 = 3631,
    /// <summary>
    /// vpxor xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpxor xmm, xmm, xmm","vpxor xmm, xmm, xmm/m128")]
    vpxor_xmm_xmm_xmm = 3632,
    /// <summary>
    /// vpxor xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpxor xmm, xmm, m128","vpxor xmm, xmm, xmm/m128")]
    vpxor_xmm_xmm_m128 = 3633,
    /// <summary>
    /// vpxor ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpxor ymm, ymm, ymm","vpxor ymm, ymm, ymm/m256")]
    vpxor_ymm_ymm_ymm = 3634,
    /// <summary>
    /// vpxor ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpxor ymm, ymm, m256","vpxor ymm, ymm, ymm/m256")]
    vpxor_ymm_ymm_m256 = 3635,
    /// <summary>
    /// vpxord xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpxord xmm {k1}{z}, xmm, xmm","vpxord xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpxord_xmm_k1z_xmm_xmm = 3636,
    /// <summary>
    /// vpxord xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpxord xmm {k1}{z}, xmm, m128","vpxord xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpxord_xmm_k1z_xmm_m128 = 3637,
    /// <summary>
    /// vpxord xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpxord xmm {k1}{z}, xmm, m32bcst","vpxord xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpxord_xmm_k1z_xmm_m32bcst = 3638,
    /// <summary>
    /// vpxord ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpxord ymm {k1}{z}, ymm, ymm","vpxord ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpxord_ymm_k1z_ymm_ymm = 3639,
    /// <summary>
    /// vpxord ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpxord ymm {k1}{z}, ymm, m256","vpxord ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpxord_ymm_k1z_ymm_m256 = 3640,
    /// <summary>
    /// vpxord ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpxord ymm {k1}{z}, ymm, m32bcst","vpxord ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpxord_ymm_k1z_ymm_m32bcst = 3641,
    /// <summary>
    /// vpxord zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpxord zmm {k1}{z}, zmm, zmm","vpxord zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpxord_zmm_k1z_zmm_zmm = 3642,
    /// <summary>
    /// vpxord zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpxord zmm {k1}{z}, zmm, m512","vpxord zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpxord_zmm_k1z_zmm_m512 = 3643,
    /// <summary>
    /// vpxord zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpxord zmm {k1}{z}, zmm, m32bcst","vpxord zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpxord_zmm_k1z_zmm_m32bcst = 3644,
    /// <summary>
    /// vpxorq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpxorq xmm {k1}{z}, xmm, xmm","vpxorq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpxorq_xmm_k1z_xmm_xmm = 3645,
    /// <summary>
    /// vpxorq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpxorq xmm {k1}{z}, xmm, m128","vpxorq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpxorq_xmm_k1z_xmm_m128 = 3646,
    /// <summary>
    /// vpxorq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpxorq xmm {k1}{z}, xmm, m64bcst","vpxorq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpxorq_xmm_k1z_xmm_m64bcst = 3647,
    /// <summary>
    /// vpxorq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpxorq ymm {k1}{z}, ymm, ymm","vpxorq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpxorq_ymm_k1z_ymm_ymm = 3648,
    /// <summary>
    /// vpxorq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpxorq ymm {k1}{z}, ymm, m256","vpxorq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpxorq_ymm_k1z_ymm_m256 = 3649,
    /// <summary>
    /// vpxorq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpxorq ymm {k1}{z}, ymm, m64bcst","vpxorq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpxorq_ymm_k1z_ymm_m64bcst = 3650,
    /// <summary>
    /// vpxorq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpxorq zmm {k1}{z}, zmm, zmm","vpxorq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpxorq_zmm_k1z_zmm_zmm = 3651,
    /// <summary>
    /// vpxorq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpxorq zmm {k1}{z}, zmm, m512","vpxorq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpxorq_zmm_k1z_zmm_m512 = 3652,
    /// <summary>
    /// vpxorq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpxorq zmm {k1}{z}, zmm, m64bcst","vpxorq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpxorq_zmm_k1z_zmm_m64bcst = 3653,
    /// <summary>
    /// xbegin rel16
    /// </summary>
    [Symbol("xbegin rel16","xbegin rel16")]
    xbegin_rel16 = 3654,
    /// <summary>
    /// xbegin rel32
    /// </summary>
    [Symbol("xbegin rel32","xbegin rel32")]
    xbegin_rel32 = 3655,
    /// <summary>
    /// xchg AX, r16
    /// </summary>
    [Symbol("xchg AX, r16","xchg AX, r16")]
    xchg_AX_r16 = 3656,
    /// <summary>
    /// xchg EAX, r32
    /// </summary>
    [Symbol("xchg EAX, r32","xchg EAX, r32")]
    xchg_EAX_r32 = 3657,
    /// <summary>
    /// xchg r/m16, r16
    /// </summary>
    [Symbol("xchg r16, r16","xchg r/m16, r16")]
    xchg_r16_r16 = 3658,
    /// <summary>
    /// xchg r/m16, r16
    /// </summary>
    [Symbol("xchg m16, r16","xchg r/m16, r16")]
    xchg_m16_r16 = 3659,
    /// <summary>
    /// xchg r/m32, r32
    /// </summary>
    [Symbol("xchg r32, r32","xchg r/m32, r32")]
    xchg_r32_r32 = 3660,
    /// <summary>
    /// xchg r/m32, r32
    /// </summary>
    [Symbol("xchg m32, r32","xchg r/m32, r32")]
    xchg_m32_r32 = 3661,
    /// <summary>
    /// xchg r/m64, r64
    /// </summary>
    [Symbol("xchg r64, r64","xchg r/m64, r64")]
    xchg_r64_r64 = 3662,
    /// <summary>
    /// xchg r/m64, r64
    /// </summary>
    [Symbol("xchg m64, r64","xchg r/m64, r64")]
    xchg_m64_r64 = 3663,
    /// <summary>
    /// xchg r/m8, r8
    /// </summary>
    [Symbol("xchg r8, r8","xchg r/m8, r8")]
    xchg_r8_r8 = 3664,
    /// <summary>
    /// xchg r/m8, r8
    /// </summary>
    [Symbol("xchg m8, r8","xchg r/m8, r8")]
    xchg_m8_r8 = 3665,
    /// <summary>
    /// xchg r16, AX
    /// </summary>
    [Symbol("xchg r16, AX","xchg r16, AX")]
    xchg_r16_AX = 3666,
    /// <summary>
    /// xchg r16, r/m16
    /// </summary>
    [Symbol("xchg r16, m16","xchg r16, r/m16")]
    xchg_r16_m16 = 3667,
    /// <summary>
    /// xchg r32, EAX
    /// </summary>
    [Symbol("xchg r32, EAX","xchg r32, EAX")]
    xchg_r32_EAX = 3668,
    /// <summary>
    /// xchg r32, r/m32
    /// </summary>
    [Symbol("xchg r32, m32","xchg r32, r/m32")]
    xchg_r32_m32 = 3669,
    /// <summary>
    /// xchg r64, r/m64
    /// </summary>
    [Symbol("xchg r64, m64","xchg r64, r/m64")]
    xchg_r64_m64 = 3670,
    /// <summary>
    /// xchg r64, RAX
    /// </summary>
    [Symbol("xchg r64, RAX","xchg r64, RAX")]
    xchg_r64_RAX = 3671,
    /// <summary>
    /// xchg r8, r/m8
    /// </summary>
    [Symbol("xchg r8, m8","xchg r8, r/m8")]
    xchg_r8_m8 = 3672,
    /// <summary>
    /// xchg RAX, r64
    /// </summary>
    [Symbol("xchg RAX, r64","xchg RAX, r64")]
    xchg_RAX_r64 = 3673,
    /// <summary>
    /// xgetbv
    /// </summary>
    [Symbol("xgetbv","xgetbv")]
    xgetbv = 3674,
    /// <summary>
    /// xlat m8
    /// </summary>
    [Symbol("xlat m8","xlat m8")]
    xlat_m8 = 3675,
    /// <summary>
    /// xlatb
    /// </summary>
    [Symbol("xlatb","xlatb")]
    xlatb = 3676,
    /// <summary>
    /// xor AL, imm8
    /// </summary>
    [Symbol("xor AL, imm8","xor AL, imm8")]
    xor_AL_imm8 = 3677,
    /// <summary>
    /// xor AX, imm16
    /// </summary>
    [Symbol("xor AX, imm16","xor AX, imm16")]
    xor_AX_imm16 = 3678,
    /// <summary>
    /// xor EAX, imm32
    /// </summary>
    [Symbol("xor EAX, imm32","xor EAX, imm32")]
    xor_EAX_imm32 = 3679,
    /// <summary>
    /// xor r/m16, imm16
    /// </summary>
    [Symbol("xor r16, imm16","xor r/m16, imm16")]
    xor_r16_imm16 = 3680,
    /// <summary>
    /// xor r/m16, imm16
    /// </summary>
    [Symbol("xor m16, imm16","xor r/m16, imm16")]
    xor_m16_imm16 = 3681,
    /// <summary>
    /// xor r/m16, imm8
    /// </summary>
    [Symbol("xor r16, imm8","xor r/m16, imm8")]
    xor_r16_imm8 = 3682,
    /// <summary>
    /// xor r/m16, imm8
    /// </summary>
    [Symbol("xor m16, imm8","xor r/m16, imm8")]
    xor_m16_imm8 = 3683,
    /// <summary>
    /// xor r/m16, r16
    /// </summary>
    [Symbol("xor r16, r16","xor r/m16, r16")]
    xor_r16_r16 = 3684,
    /// <summary>
    /// xor r/m16, r16
    /// </summary>
    [Symbol("xor m16, r16","xor r/m16, r16")]
    xor_m16_r16 = 3685,
    /// <summary>
    /// xor r/m32, imm32
    /// </summary>
    [Symbol("xor r32, imm32","xor r/m32, imm32")]
    xor_r32_imm32 = 3686,
    /// <summary>
    /// xor r/m32, imm32
    /// </summary>
    [Symbol("xor m32, imm32","xor r/m32, imm32")]
    xor_m32_imm32 = 3687,
    /// <summary>
    /// xor r/m32, imm8
    /// </summary>
    [Symbol("xor r32, imm8","xor r/m32, imm8")]
    xor_r32_imm8 = 3688,
    /// <summary>
    /// xor r/m32, imm8
    /// </summary>
    [Symbol("xor m32, imm8","xor r/m32, imm8")]
    xor_m32_imm8 = 3689,
    /// <summary>
    /// xor r/m32, r32
    /// </summary>
    [Symbol("xor r32, r32","xor r/m32, r32")]
    xor_r32_r32 = 3690,
    /// <summary>
    /// xor r/m32, r32
    /// </summary>
    [Symbol("xor m32, r32","xor r/m32, r32")]
    xor_m32_r32 = 3691,
    /// <summary>
    /// xor r/m64, imm32
    /// </summary>
    [Symbol("xor r64, imm32","xor r/m64, imm32")]
    xor_r64_imm32 = 3692,
    /// <summary>
    /// xor r/m64, imm32
    /// </summary>
    [Symbol("xor m64, imm32","xor r/m64, imm32")]
    xor_m64_imm32 = 3693,
    /// <summary>
    /// xor r/m64, imm8
    /// </summary>
    [Symbol("xor r64, imm8","xor r/m64, imm8")]
    xor_r64_imm8 = 3694,
    /// <summary>
    /// xor r/m64, imm8
    /// </summary>
    [Symbol("xor m64, imm8","xor r/m64, imm8")]
    xor_m64_imm8 = 3695,
    /// <summary>
    /// xor r/m64, r64
    /// </summary>
    [Symbol("xor r64, r64","xor r/m64, r64")]
    xor_r64_r64 = 3696,
    /// <summary>
    /// xor r/m64, r64
    /// </summary>
    [Symbol("xor m64, r64","xor r/m64, r64")]
    xor_m64_r64 = 3697,
    /// <summary>
    /// xor r/m8, imm8
    /// </summary>
    [Symbol("xor r8, imm8","xor r/m8, imm8")]
    xor_r8_imm8 = 3698,
    /// <summary>
    /// xor r/m8, imm8
    /// </summary>
    [Symbol("xor m8, imm8","xor r/m8, imm8")]
    xor_m8_imm8 = 3699,
    /// <summary>
    /// xor r/m8, r8
    /// </summary>
    [Symbol("xor r8, r8","xor r/m8, r8")]
    xor_r8_r8 = 3700,
    /// <summary>
    /// xor r/m8, r8
    /// </summary>
    [Symbol("xor m8, r8","xor r/m8, r8")]
    xor_m8_r8 = 3701,
    /// <summary>
    /// xor r16, r/m16
    /// </summary>
    [Symbol("xor r16, m16","xor r16, r/m16")]
    xor_r16_m16 = 3702,
    /// <summary>
    /// xor r32, r/m32
    /// </summary>
    [Symbol("xor r32, m32","xor r32, r/m32")]
    xor_r32_m32 = 3703,
    /// <summary>
    /// xor r64, r/m64
    /// </summary>
    [Symbol("xor r64, m64","xor r64, r/m64")]
    xor_r64_m64 = 3704,
    /// <summary>
    /// xor r8, r/m8
    /// </summary>
    [Symbol("xor r8, m8","xor r8, r/m8")]
    xor_r8_m8 = 3705,
    /// <summary>
    /// xor RAX, imm32
    /// </summary>
    [Symbol("xor RAX, imm32","xor RAX, imm32")]
    xor_RAX_imm32 = 3706,
    /// <summary>
    /// xsave mem
    /// </summary>
    [Symbol("xsave mem","xsave mem")]
    xsave_mem = 3707,
    /// <summary>
    /// xsave64 mem
    /// </summary>
    [Symbol("xsave64 mem","xsave64 mem")]
    xsave64_mem = 3708,
    /// <summary>
    /// xsavec mem
    /// </summary>
    [Symbol("xsavec mem","xsavec mem")]
    xsavec_mem = 3709,
    /// <summary>
    /// xsavec64 mem
    /// </summary>
    [Symbol("xsavec64 mem","xsavec64 mem")]
    xsavec64_mem = 3710,
    /// <summary>
    /// xsetbv
    /// </summary>
    [Symbol("xsetbv","xsetbv")]
    xsetbv = 3711,
    }
}

