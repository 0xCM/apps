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
    [Symbol("vaddpd xmm, xmm, xmm","vaddpd xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vaddpd_xmm_xmm_xmm = 1659,
    /// <summary>
    /// vaddpd xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vaddpd xmm, xmm, m128","vaddpd xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vaddpd_xmm_xmm_m128 = 1660,
    /// <summary>
    /// vaddpd xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vaddpd xmm, xmm, m64bcst","vaddpd xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vaddpd_xmm_xmm_m64bcst = 1661,
    /// <summary>
    /// vaddpd xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vaddpd xmm_k1z, xmm, xmm","vaddpd xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vaddpd_xmm_k1z_xmm_xmm = 1662,
    /// <summary>
    /// vaddpd xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vaddpd xmm_k1z, xmm, m128","vaddpd xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vaddpd_xmm_k1z_xmm_m128 = 1663,
    /// <summary>
    /// vaddpd xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vaddpd xmm_k1z, xmm, m64bcst","vaddpd xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vaddpd_xmm_k1z_xmm_m64bcst = 1664,
    /// <summary>
    /// vaddpd ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vaddpd ymm, ymm, ymm","vaddpd ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vaddpd_ymm_ymm_ymm = 1665,
    /// <summary>
    /// vaddpd ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vaddpd ymm, ymm, m256","vaddpd ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vaddpd_ymm_ymm_m256 = 1666,
    /// <summary>
    /// vaddpd ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vaddpd ymm, ymm, m64bcst","vaddpd ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vaddpd_ymm_ymm_m64bcst = 1667,
    /// <summary>
    /// vaddpd ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vaddpd ymm_k1z, ymm, ymm","vaddpd ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vaddpd_ymm_k1z_ymm_ymm = 1668,
    /// <summary>
    /// vaddpd ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vaddpd ymm_k1z, ymm, m256","vaddpd ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vaddpd_ymm_k1z_ymm_m256 = 1669,
    /// <summary>
    /// vaddpd ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vaddpd ymm_k1z, ymm, m64bcst","vaddpd ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vaddpd_ymm_k1z_ymm_m64bcst = 1670,
    /// <summary>
    /// vaddpd zmm {k1}{z}, zmm, zmm/m512/m64bcst {er}
    /// </summary>
    [Symbol("vaddpd zmm, zmm, zmm_er","vaddpd zmm {k1}{z}, zmm, zmm/m512/m64bcst {er}")]
    vaddpd_zmm_zmm_zmm_er = 1671,
    /// <summary>
    /// vaddpd zmm {k1}{z}, zmm, zmm/m512/m64bcst {er}
    /// </summary>
    [Symbol("vaddpd zmm, zmm, m512_er","vaddpd zmm {k1}{z}, zmm, zmm/m512/m64bcst {er}")]
    vaddpd_zmm_zmm_m512_er = 1672,
    /// <summary>
    /// vaddpd zmm {k1}{z}, zmm, zmm/m512/m64bcst {er}
    /// </summary>
    [Symbol("vaddpd zmm, zmm, m64bcst_er","vaddpd zmm {k1}{z}, zmm, zmm/m512/m64bcst {er}")]
    vaddpd_zmm_zmm_m64bcst_er = 1673,
    /// <summary>
    /// vaddpd zmm {k1}{z}, zmm, zmm/m512/m64bcst {er}
    /// </summary>
    [Symbol("vaddpd zmm_k1z, zmm, zmm_er","vaddpd zmm {k1}{z}, zmm, zmm/m512/m64bcst {er}")]
    vaddpd_zmm_k1z_zmm_zmm_er = 1674,
    /// <summary>
    /// vaddpd zmm {k1}{z}, zmm, zmm/m512/m64bcst {er}
    /// </summary>
    [Symbol("vaddpd zmm_k1z, zmm, m512_er","vaddpd zmm {k1}{z}, zmm, zmm/m512/m64bcst {er}")]
    vaddpd_zmm_k1z_zmm_m512_er = 1675,
    /// <summary>
    /// vaddpd zmm {k1}{z}, zmm, zmm/m512/m64bcst {er}
    /// </summary>
    [Symbol("vaddpd zmm_k1z, zmm, m64bcst_er","vaddpd zmm {k1}{z}, zmm, zmm/m512/m64bcst {er}")]
    vaddpd_zmm_k1z_zmm_m64bcst_er = 1676,
    /// <summary>
    /// valignd xmm {k1}{z}, xmm, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("valignd xmm, xmm, xmm, imm8","valignd xmm {k1}{z}, xmm, xmm/m128/m32bcst, imm8")]
    valignd_xmm_xmm_xmm_imm8 = 1677,
    /// <summary>
    /// valignd xmm {k1}{z}, xmm, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("valignd xmm, xmm, m128, imm8","valignd xmm {k1}{z}, xmm, xmm/m128/m32bcst, imm8")]
    valignd_xmm_xmm_m128_imm8 = 1678,
    /// <summary>
    /// valignd xmm {k1}{z}, xmm, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("valignd xmm, xmm, m32bcst, imm8","valignd xmm {k1}{z}, xmm, xmm/m128/m32bcst, imm8")]
    valignd_xmm_xmm_m32bcst_imm8 = 1679,
    /// <summary>
    /// valignd xmm {k1}{z}, xmm, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("valignd xmm_k1z, xmm, xmm, imm8","valignd xmm {k1}{z}, xmm, xmm/m128/m32bcst, imm8")]
    valignd_xmm_k1z_xmm_xmm_imm8 = 1680,
    /// <summary>
    /// valignd xmm {k1}{z}, xmm, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("valignd xmm_k1z, xmm, m128, imm8","valignd xmm {k1}{z}, xmm, xmm/m128/m32bcst, imm8")]
    valignd_xmm_k1z_xmm_m128_imm8 = 1681,
    /// <summary>
    /// valignd xmm {k1}{z}, xmm, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("valignd xmm_k1z, xmm, m32bcst, imm8","valignd xmm {k1}{z}, xmm, xmm/m128/m32bcst, imm8")]
    valignd_xmm_k1z_xmm_m32bcst_imm8 = 1682,
    /// <summary>
    /// valignd ymm {k1}{z}, ymm, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("valignd ymm, ymm, ymm, imm8","valignd ymm {k1}{z}, ymm, ymm/m256/m32bcst, imm8")]
    valignd_ymm_ymm_ymm_imm8 = 1683,
    /// <summary>
    /// valignd ymm {k1}{z}, ymm, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("valignd ymm, ymm, m256, imm8","valignd ymm {k1}{z}, ymm, ymm/m256/m32bcst, imm8")]
    valignd_ymm_ymm_m256_imm8 = 1684,
    /// <summary>
    /// valignd ymm {k1}{z}, ymm, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("valignd ymm, ymm, m32bcst, imm8","valignd ymm {k1}{z}, ymm, ymm/m256/m32bcst, imm8")]
    valignd_ymm_ymm_m32bcst_imm8 = 1685,
    /// <summary>
    /// valignd ymm {k1}{z}, ymm, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("valignd ymm_k1z, ymm, ymm, imm8","valignd ymm {k1}{z}, ymm, ymm/m256/m32bcst, imm8")]
    valignd_ymm_k1z_ymm_ymm_imm8 = 1686,
    /// <summary>
    /// valignd ymm {k1}{z}, ymm, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("valignd ymm_k1z, ymm, m256, imm8","valignd ymm {k1}{z}, ymm, ymm/m256/m32bcst, imm8")]
    valignd_ymm_k1z_ymm_m256_imm8 = 1687,
    /// <summary>
    /// valignd ymm {k1}{z}, ymm, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("valignd ymm_k1z, ymm, m32bcst, imm8","valignd ymm {k1}{z}, ymm, ymm/m256/m32bcst, imm8")]
    valignd_ymm_k1z_ymm_m32bcst_imm8 = 1688,
    /// <summary>
    /// valignd zmm {k1}{z}, zmm, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("valignd zmm, zmm, zmm, imm8","valignd zmm {k1}{z}, zmm, zmm/m512/m32bcst, imm8")]
    valignd_zmm_zmm_zmm_imm8 = 1689,
    /// <summary>
    /// valignd zmm {k1}{z}, zmm, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("valignd zmm, zmm, m512, imm8","valignd zmm {k1}{z}, zmm, zmm/m512/m32bcst, imm8")]
    valignd_zmm_zmm_m512_imm8 = 1690,
    /// <summary>
    /// valignd zmm {k1}{z}, zmm, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("valignd zmm, zmm, m32bcst, imm8","valignd zmm {k1}{z}, zmm, zmm/m512/m32bcst, imm8")]
    valignd_zmm_zmm_m32bcst_imm8 = 1691,
    /// <summary>
    /// valignd zmm {k1}{z}, zmm, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("valignd zmm_k1z, zmm, zmm, imm8","valignd zmm {k1}{z}, zmm, zmm/m512/m32bcst, imm8")]
    valignd_zmm_k1z_zmm_zmm_imm8 = 1692,
    /// <summary>
    /// valignd zmm {k1}{z}, zmm, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("valignd zmm_k1z, zmm, m512, imm8","valignd zmm {k1}{z}, zmm, zmm/m512/m32bcst, imm8")]
    valignd_zmm_k1z_zmm_m512_imm8 = 1693,
    /// <summary>
    /// valignd zmm {k1}{z}, zmm, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("valignd zmm_k1z, zmm, m32bcst, imm8","valignd zmm {k1}{z}, zmm, zmm/m512/m32bcst, imm8")]
    valignd_zmm_k1z_zmm_m32bcst_imm8 = 1694,
    /// <summary>
    /// valignq xmm {k1}{z}, xmm, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("valignq xmm, xmm, xmm, imm8","valignq xmm {k1}{z}, xmm, xmm/m128/m64bcst, imm8")]
    valignq_xmm_xmm_xmm_imm8 = 1695,
    /// <summary>
    /// valignq xmm {k1}{z}, xmm, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("valignq xmm, xmm, m128, imm8","valignq xmm {k1}{z}, xmm, xmm/m128/m64bcst, imm8")]
    valignq_xmm_xmm_m128_imm8 = 1696,
    /// <summary>
    /// valignq xmm {k1}{z}, xmm, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("valignq xmm, xmm, m64bcst, imm8","valignq xmm {k1}{z}, xmm, xmm/m128/m64bcst, imm8")]
    valignq_xmm_xmm_m64bcst_imm8 = 1697,
    /// <summary>
    /// valignq xmm {k1}{z}, xmm, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("valignq xmm_k1z, xmm, xmm, imm8","valignq xmm {k1}{z}, xmm, xmm/m128/m64bcst, imm8")]
    valignq_xmm_k1z_xmm_xmm_imm8 = 1698,
    /// <summary>
    /// valignq xmm {k1}{z}, xmm, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("valignq xmm_k1z, xmm, m128, imm8","valignq xmm {k1}{z}, xmm, xmm/m128/m64bcst, imm8")]
    valignq_xmm_k1z_xmm_m128_imm8 = 1699,
    /// <summary>
    /// valignq xmm {k1}{z}, xmm, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("valignq xmm_k1z, xmm, m64bcst, imm8","valignq xmm {k1}{z}, xmm, xmm/m128/m64bcst, imm8")]
    valignq_xmm_k1z_xmm_m64bcst_imm8 = 1700,
    /// <summary>
    /// valignq ymm {k1}{z}, ymm, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("valignq ymm, ymm, ymm, imm8","valignq ymm {k1}{z}, ymm, ymm/m256/m64bcst, imm8")]
    valignq_ymm_ymm_ymm_imm8 = 1701,
    /// <summary>
    /// valignq ymm {k1}{z}, ymm, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("valignq ymm, ymm, m256, imm8","valignq ymm {k1}{z}, ymm, ymm/m256/m64bcst, imm8")]
    valignq_ymm_ymm_m256_imm8 = 1702,
    /// <summary>
    /// valignq ymm {k1}{z}, ymm, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("valignq ymm, ymm, m64bcst, imm8","valignq ymm {k1}{z}, ymm, ymm/m256/m64bcst, imm8")]
    valignq_ymm_ymm_m64bcst_imm8 = 1703,
    /// <summary>
    /// valignq ymm {k1}{z}, ymm, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("valignq ymm_k1z, ymm, ymm, imm8","valignq ymm {k1}{z}, ymm, ymm/m256/m64bcst, imm8")]
    valignq_ymm_k1z_ymm_ymm_imm8 = 1704,
    /// <summary>
    /// valignq ymm {k1}{z}, ymm, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("valignq ymm_k1z, ymm, m256, imm8","valignq ymm {k1}{z}, ymm, ymm/m256/m64bcst, imm8")]
    valignq_ymm_k1z_ymm_m256_imm8 = 1705,
    /// <summary>
    /// valignq ymm {k1}{z}, ymm, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("valignq ymm_k1z, ymm, m64bcst, imm8","valignq ymm {k1}{z}, ymm, ymm/m256/m64bcst, imm8")]
    valignq_ymm_k1z_ymm_m64bcst_imm8 = 1706,
    /// <summary>
    /// valignq zmm {k1}{z}, zmm, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("valignq zmm, zmm, zmm, imm8","valignq zmm {k1}{z}, zmm, zmm/m512/m64bcst, imm8")]
    valignq_zmm_zmm_zmm_imm8 = 1707,
    /// <summary>
    /// valignq zmm {k1}{z}, zmm, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("valignq zmm, zmm, m512, imm8","valignq zmm {k1}{z}, zmm, zmm/m512/m64bcst, imm8")]
    valignq_zmm_zmm_m512_imm8 = 1708,
    /// <summary>
    /// valignq zmm {k1}{z}, zmm, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("valignq zmm, zmm, m64bcst, imm8","valignq zmm {k1}{z}, zmm, zmm/m512/m64bcst, imm8")]
    valignq_zmm_zmm_m64bcst_imm8 = 1709,
    /// <summary>
    /// valignq zmm {k1}{z}, zmm, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("valignq zmm_k1z, zmm, zmm, imm8","valignq zmm {k1}{z}, zmm, zmm/m512/m64bcst, imm8")]
    valignq_zmm_k1z_zmm_zmm_imm8 = 1710,
    /// <summary>
    /// valignq zmm {k1}{z}, zmm, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("valignq zmm_k1z, zmm, m512, imm8","valignq zmm {k1}{z}, zmm, zmm/m512/m64bcst, imm8")]
    valignq_zmm_k1z_zmm_m512_imm8 = 1711,
    /// <summary>
    /// valignq zmm {k1}{z}, zmm, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("valignq zmm_k1z, zmm, m64bcst, imm8","valignq zmm {k1}{z}, zmm, zmm/m512/m64bcst, imm8")]
    valignq_zmm_k1z_zmm_m64bcst_imm8 = 1712,
    /// <summary>
    /// vbroadcasti128 ymm, m128
    /// </summary>
    [Symbol("vbroadcasti128 ymm, m128","vbroadcasti128 ymm, m128")]
    vbroadcasti128_ymm_m128 = 1713,
    /// <summary>
    /// vbroadcasti32x2 xmm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vbroadcasti32x2 xmm, xmm","vbroadcasti32x2 xmm {k1}{z}, xmm/m64")]
    vbroadcasti32x2_xmm_xmm = 1714,
    /// <summary>
    /// vbroadcasti32x2 xmm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vbroadcasti32x2 xmm, m64","vbroadcasti32x2 xmm {k1}{z}, xmm/m64")]
    vbroadcasti32x2_xmm_m64 = 1715,
    /// <summary>
    /// vbroadcasti32x2 xmm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vbroadcasti32x2 xmm_k1z, xmm","vbroadcasti32x2 xmm {k1}{z}, xmm/m64")]
    vbroadcasti32x2_xmm_k1z_xmm = 1716,
    /// <summary>
    /// vbroadcasti32x2 xmm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vbroadcasti32x2 xmm_k1z, m64","vbroadcasti32x2 xmm {k1}{z}, xmm/m64")]
    vbroadcasti32x2_xmm_k1z_m64 = 1717,
    /// <summary>
    /// vbroadcasti32x2 ymm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vbroadcasti32x2 ymm, xmm","vbroadcasti32x2 ymm {k1}{z}, xmm/m64")]
    vbroadcasti32x2_ymm_xmm = 1718,
    /// <summary>
    /// vbroadcasti32x2 ymm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vbroadcasti32x2 ymm, m64","vbroadcasti32x2 ymm {k1}{z}, xmm/m64")]
    vbroadcasti32x2_ymm_m64 = 1719,
    /// <summary>
    /// vbroadcasti32x2 ymm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vbroadcasti32x2 ymm_k1z, xmm","vbroadcasti32x2 ymm {k1}{z}, xmm/m64")]
    vbroadcasti32x2_ymm_k1z_xmm = 1720,
    /// <summary>
    /// vbroadcasti32x2 ymm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vbroadcasti32x2 ymm_k1z, m64","vbroadcasti32x2 ymm {k1}{z}, xmm/m64")]
    vbroadcasti32x2_ymm_k1z_m64 = 1721,
    /// <summary>
    /// vbroadcasti32x2 zmm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vbroadcasti32x2 zmm, xmm","vbroadcasti32x2 zmm {k1}{z}, xmm/m64")]
    vbroadcasti32x2_zmm_xmm = 1722,
    /// <summary>
    /// vbroadcasti32x2 zmm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vbroadcasti32x2 zmm, m64","vbroadcasti32x2 zmm {k1}{z}, xmm/m64")]
    vbroadcasti32x2_zmm_m64 = 1723,
    /// <summary>
    /// vbroadcasti32x2 zmm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vbroadcasti32x2 zmm_k1z, xmm","vbroadcasti32x2 zmm {k1}{z}, xmm/m64")]
    vbroadcasti32x2_zmm_k1z_xmm = 1724,
    /// <summary>
    /// vbroadcasti32x2 zmm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vbroadcasti32x2 zmm_k1z, m64","vbroadcasti32x2 zmm {k1}{z}, xmm/m64")]
    vbroadcasti32x2_zmm_k1z_m64 = 1725,
    /// <summary>
    /// vbroadcasti32x4 ymm {k1}{z}, m128
    /// </summary>
    [Symbol("vbroadcasti32x4 ymm, m128","vbroadcasti32x4 ymm {k1}{z}, m128")]
    vbroadcasti32x4_ymm_m128 = 1726,
    /// <summary>
    /// vbroadcasti32x4 ymm {k1}{z}, m128
    /// </summary>
    [Symbol("vbroadcasti32x4 ymm_k1z, m128","vbroadcasti32x4 ymm {k1}{z}, m128")]
    vbroadcasti32x4_ymm_k1z_m128 = 1727,
    /// <summary>
    /// vbroadcasti32x4 zmm {k1}{z}, m128
    /// </summary>
    [Symbol("vbroadcasti32x4 zmm, m128","vbroadcasti32x4 zmm {k1}{z}, m128")]
    vbroadcasti32x4_zmm_m128 = 1728,
    /// <summary>
    /// vbroadcasti32x4 zmm {k1}{z}, m128
    /// </summary>
    [Symbol("vbroadcasti32x4 zmm_k1z, m128","vbroadcasti32x4 zmm {k1}{z}, m128")]
    vbroadcasti32x4_zmm_k1z_m128 = 1729,
    /// <summary>
    /// vbroadcasti32x8 zmm {k1}{z}, m256
    /// </summary>
    [Symbol("vbroadcasti32x8 zmm, m256","vbroadcasti32x8 zmm {k1}{z}, m256")]
    vbroadcasti32x8_zmm_m256 = 1730,
    /// <summary>
    /// vbroadcasti32x8 zmm {k1}{z}, m256
    /// </summary>
    [Symbol("vbroadcasti32x8 zmm_k1z, m256","vbroadcasti32x8 zmm {k1}{z}, m256")]
    vbroadcasti32x8_zmm_k1z_m256 = 1731,
    /// <summary>
    /// vbroadcasti64x2 ymm {k1}{z}, m128
    /// </summary>
    [Symbol("vbroadcasti64x2 ymm, m128","vbroadcasti64x2 ymm {k1}{z}, m128")]
    vbroadcasti64x2_ymm_m128 = 1732,
    /// <summary>
    /// vbroadcasti64x2 ymm {k1}{z}, m128
    /// </summary>
    [Symbol("vbroadcasti64x2 ymm_k1z, m128","vbroadcasti64x2 ymm {k1}{z}, m128")]
    vbroadcasti64x2_ymm_k1z_m128 = 1733,
    /// <summary>
    /// vbroadcasti64x2 zmm {k1}{z}, m128
    /// </summary>
    [Symbol("vbroadcasti64x2 zmm, m128","vbroadcasti64x2 zmm {k1}{z}, m128")]
    vbroadcasti64x2_zmm_m128 = 1734,
    /// <summary>
    /// vbroadcasti64x2 zmm {k1}{z}, m128
    /// </summary>
    [Symbol("vbroadcasti64x2 zmm_k1z, m128","vbroadcasti64x2 zmm {k1}{z}, m128")]
    vbroadcasti64x2_zmm_k1z_m128 = 1735,
    /// <summary>
    /// vbroadcasti64x4 zmm {k1}{z}, m256
    /// </summary>
    [Symbol("vbroadcasti64x4 zmm, m256","vbroadcasti64x4 zmm {k1}{z}, m256")]
    vbroadcasti64x4_zmm_m256 = 1736,
    /// <summary>
    /// vbroadcasti64x4 zmm {k1}{z}, m256
    /// </summary>
    [Symbol("vbroadcasti64x4 zmm_k1z, m256","vbroadcasti64x4 zmm {k1}{z}, m256")]
    vbroadcasti64x4_zmm_k1z_m256 = 1737,
    /// <summary>
    /// vcmpps k1 {k2}, xmm, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vcmpps k1, xmm, xmm, imm8","vcmpps k1 {k2}, xmm, xmm/m128/m32bcst, imm8")]
    vcmpps_k1_xmm_xmm_imm8 = 1738,
    /// <summary>
    /// vcmpps k1 {k2}, xmm, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vcmpps k1, xmm, m128, imm8","vcmpps k1 {k2}, xmm, xmm/m128/m32bcst, imm8")]
    vcmpps_k1_xmm_m128_imm8 = 1739,
    /// <summary>
    /// vcmpps k1 {k2}, xmm, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vcmpps k1, xmm, m32bcst, imm8","vcmpps k1 {k2}, xmm, xmm/m128/m32bcst, imm8")]
    vcmpps_k1_xmm_m32bcst_imm8 = 1740,
    /// <summary>
    /// vcmpps k1 {k2}, xmm, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vcmpps k12, xmm, xmm, imm8","vcmpps k1 {k2}, xmm, xmm/m128/m32bcst, imm8")]
    vcmpps_k12_xmm_xmm_imm8 = 1741,
    /// <summary>
    /// vcmpps k1 {k2}, xmm, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vcmpps k12, xmm, m128, imm8","vcmpps k1 {k2}, xmm, xmm/m128/m32bcst, imm8")]
    vcmpps_k12_xmm_m128_imm8 = 1742,
    /// <summary>
    /// vcmpps k1 {k2}, xmm, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vcmpps k12, xmm, m32bcst, imm8","vcmpps k1 {k2}, xmm, xmm/m128/m32bcst, imm8")]
    vcmpps_k12_xmm_m32bcst_imm8 = 1743,
    /// <summary>
    /// vcmpps k1 {k2}, ymm, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vcmpps k1, ymm, ymm, imm8","vcmpps k1 {k2}, ymm, ymm/m256/m32bcst, imm8")]
    vcmpps_k1_ymm_ymm_imm8 = 1744,
    /// <summary>
    /// vcmpps k1 {k2}, ymm, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vcmpps k1, ymm, m256, imm8","vcmpps k1 {k2}, ymm, ymm/m256/m32bcst, imm8")]
    vcmpps_k1_ymm_m256_imm8 = 1745,
    /// <summary>
    /// vcmpps k1 {k2}, ymm, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vcmpps k1, ymm, m32bcst, imm8","vcmpps k1 {k2}, ymm, ymm/m256/m32bcst, imm8")]
    vcmpps_k1_ymm_m32bcst_imm8 = 1746,
    /// <summary>
    /// vcmpps k1 {k2}, ymm, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vcmpps k12, ymm, ymm, imm8","vcmpps k1 {k2}, ymm, ymm/m256/m32bcst, imm8")]
    vcmpps_k12_ymm_ymm_imm8 = 1747,
    /// <summary>
    /// vcmpps k1 {k2}, ymm, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vcmpps k12, ymm, m256, imm8","vcmpps k1 {k2}, ymm, ymm/m256/m32bcst, imm8")]
    vcmpps_k12_ymm_m256_imm8 = 1748,
    /// <summary>
    /// vcmpps k1 {k2}, ymm, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vcmpps k12, ymm, m32bcst, imm8","vcmpps k1 {k2}, ymm, ymm/m256/m32bcst, imm8")]
    vcmpps_k12_ymm_m32bcst_imm8 = 1749,
    /// <summary>
    /// vcmpps k1 {k2}, zmm, zmm/m512/m32bcst {sae}, imm8
    /// </summary>
    [Symbol("vcmpps k1, zmm, zmm_sae, imm8","vcmpps k1 {k2}, zmm, zmm/m512/m32bcst {sae}, imm8")]
    vcmpps_k1_zmm_zmm_sae_imm8 = 1750,
    /// <summary>
    /// vcmpps k1 {k2}, zmm, zmm/m512/m32bcst {sae}, imm8
    /// </summary>
    [Symbol("vcmpps k1, zmm, m512_sae, imm8","vcmpps k1 {k2}, zmm, zmm/m512/m32bcst {sae}, imm8")]
    vcmpps_k1_zmm_m512_sae_imm8 = 1751,
    /// <summary>
    /// vcmpps k1 {k2}, zmm, zmm/m512/m32bcst {sae}, imm8
    /// </summary>
    [Symbol("vcmpps k1, zmm, m32bcst_sae, imm8","vcmpps k1 {k2}, zmm, zmm/m512/m32bcst {sae}, imm8")]
    vcmpps_k1_zmm_m32bcst_sae_imm8 = 1752,
    /// <summary>
    /// vcmpps k1 {k2}, zmm, zmm/m512/m32bcst {sae}, imm8
    /// </summary>
    [Symbol("vcmpps k12, zmm, zmm_sae, imm8","vcmpps k1 {k2}, zmm, zmm/m512/m32bcst {sae}, imm8")]
    vcmpps_k12_zmm_zmm_sae_imm8 = 1753,
    /// <summary>
    /// vcmpps k1 {k2}, zmm, zmm/m512/m32bcst {sae}, imm8
    /// </summary>
    [Symbol("vcmpps k12, zmm, m512_sae, imm8","vcmpps k1 {k2}, zmm, zmm/m512/m32bcst {sae}, imm8")]
    vcmpps_k12_zmm_m512_sae_imm8 = 1754,
    /// <summary>
    /// vcmpps k1 {k2}, zmm, zmm/m512/m32bcst {sae}, imm8
    /// </summary>
    [Symbol("vcmpps k12, zmm, m32bcst_sae, imm8","vcmpps k1 {k2}, zmm, zmm/m512/m32bcst {sae}, imm8")]
    vcmpps_k12_zmm_m32bcst_sae_imm8 = 1755,
    /// <summary>
    /// vcmpps xmm, xmm, xmm/m128, imm8
    /// </summary>
    [Symbol("vcmpps xmm, xmm, xmm, imm8","vcmpps xmm, xmm, xmm/m128, imm8")]
    vcmpps_xmm_xmm_xmm_imm8 = 1756,
    /// <summary>
    /// vcmpps xmm, xmm, xmm/m128, imm8
    /// </summary>
    [Symbol("vcmpps xmm, xmm, m128, imm8","vcmpps xmm, xmm, xmm/m128, imm8")]
    vcmpps_xmm_xmm_m128_imm8 = 1757,
    /// <summary>
    /// vcmpps ymm, ymm, ymm/m256, imm8
    /// </summary>
    [Symbol("vcmpps ymm, ymm, ymm, imm8","vcmpps ymm, ymm, ymm/m256, imm8")]
    vcmpps_ymm_ymm_ymm_imm8 = 1758,
    /// <summary>
    /// vcmpps ymm, ymm, ymm/m256, imm8
    /// </summary>
    [Symbol("vcmpps ymm, ymm, m256, imm8","vcmpps ymm, ymm, ymm/m256, imm8")]
    vcmpps_ymm_ymm_m256_imm8 = 1759,
    /// <summary>
    /// vcmpss k1 {k2}, xmm, xmm/m32 {sae}, imm8
    /// </summary>
    [Symbol("vcmpss k1, xmm, xmm_sae, imm8","vcmpss k1 {k2}, xmm, xmm/m32 {sae}, imm8")]
    vcmpss_k1_xmm_xmm_sae_imm8 = 1760,
    /// <summary>
    /// vcmpss k1 {k2}, xmm, xmm/m32 {sae}, imm8
    /// </summary>
    [Symbol("vcmpss k1, xmm, m32_sae, imm8","vcmpss k1 {k2}, xmm, xmm/m32 {sae}, imm8")]
    vcmpss_k1_xmm_m32_sae_imm8 = 1761,
    /// <summary>
    /// vcmpss k1 {k2}, xmm, xmm/m32 {sae}, imm8
    /// </summary>
    [Symbol("vcmpss k12, xmm, xmm_sae, imm8","vcmpss k1 {k2}, xmm, xmm/m32 {sae}, imm8")]
    vcmpss_k12_xmm_xmm_sae_imm8 = 1762,
    /// <summary>
    /// vcmpss k1 {k2}, xmm, xmm/m32 {sae}, imm8
    /// </summary>
    [Symbol("vcmpss k12, xmm, m32_sae, imm8","vcmpss k1 {k2}, xmm, xmm/m32 {sae}, imm8")]
    vcmpss_k12_xmm_m32_sae_imm8 = 1763,
    /// <summary>
    /// vcmpss xmm, xmm, xmm/m32, imm8
    /// </summary>
    [Symbol("vcmpss xmm, xmm, xmm, imm8","vcmpss xmm, xmm, xmm/m32, imm8")]
    vcmpss_xmm_xmm_xmm_imm8 = 1764,
    /// <summary>
    /// vcmpss xmm, xmm, xmm/m32, imm8
    /// </summary>
    [Symbol("vcmpss xmm, xmm, m32, imm8","vcmpss xmm, xmm, xmm/m32, imm8")]
    vcmpss_xmm_xmm_m32_imm8 = 1765,
    /// <summary>
    /// vdbpsadbw xmm {k1}{z}, xmm, xmm/m128, imm8
    /// </summary>
    [Symbol("vdbpsadbw xmm, xmm, xmm, imm8","vdbpsadbw xmm {k1}{z}, xmm, xmm/m128, imm8")]
    vdbpsadbw_xmm_xmm_xmm_imm8 = 1766,
    /// <summary>
    /// vdbpsadbw xmm {k1}{z}, xmm, xmm/m128, imm8
    /// </summary>
    [Symbol("vdbpsadbw xmm, xmm, m128, imm8","vdbpsadbw xmm {k1}{z}, xmm, xmm/m128, imm8")]
    vdbpsadbw_xmm_xmm_m128_imm8 = 1767,
    /// <summary>
    /// vdbpsadbw xmm {k1}{z}, xmm, xmm/m128, imm8
    /// </summary>
    [Symbol("vdbpsadbw xmm_k1z, xmm, xmm, imm8","vdbpsadbw xmm {k1}{z}, xmm, xmm/m128, imm8")]
    vdbpsadbw_xmm_k1z_xmm_xmm_imm8 = 1768,
    /// <summary>
    /// vdbpsadbw xmm {k1}{z}, xmm, xmm/m128, imm8
    /// </summary>
    [Symbol("vdbpsadbw xmm_k1z, xmm, m128, imm8","vdbpsadbw xmm {k1}{z}, xmm, xmm/m128, imm8")]
    vdbpsadbw_xmm_k1z_xmm_m128_imm8 = 1769,
    /// <summary>
    /// vdbpsadbw ymm {k1}{z}, ymm, ymm/m256, imm8
    /// </summary>
    [Symbol("vdbpsadbw ymm, ymm, ymm, imm8","vdbpsadbw ymm {k1}{z}, ymm, ymm/m256, imm8")]
    vdbpsadbw_ymm_ymm_ymm_imm8 = 1770,
    /// <summary>
    /// vdbpsadbw ymm {k1}{z}, ymm, ymm/m256, imm8
    /// </summary>
    [Symbol("vdbpsadbw ymm, ymm, m256, imm8","vdbpsadbw ymm {k1}{z}, ymm, ymm/m256, imm8")]
    vdbpsadbw_ymm_ymm_m256_imm8 = 1771,
    /// <summary>
    /// vdbpsadbw ymm {k1}{z}, ymm, ymm/m256, imm8
    /// </summary>
    [Symbol("vdbpsadbw ymm_k1z, ymm, ymm, imm8","vdbpsadbw ymm {k1}{z}, ymm, ymm/m256, imm8")]
    vdbpsadbw_ymm_k1z_ymm_ymm_imm8 = 1772,
    /// <summary>
    /// vdbpsadbw ymm {k1}{z}, ymm, ymm/m256, imm8
    /// </summary>
    [Symbol("vdbpsadbw ymm_k1z, ymm, m256, imm8","vdbpsadbw ymm {k1}{z}, ymm, ymm/m256, imm8")]
    vdbpsadbw_ymm_k1z_ymm_m256_imm8 = 1773,
    /// <summary>
    /// vdbpsadbw zmm {k1}{z}, zmm, zmm/m512, imm8
    /// </summary>
    [Symbol("vdbpsadbw zmm, zmm, zmm, imm8","vdbpsadbw zmm {k1}{z}, zmm, zmm/m512, imm8")]
    vdbpsadbw_zmm_zmm_zmm_imm8 = 1774,
    /// <summary>
    /// vdbpsadbw zmm {k1}{z}, zmm, zmm/m512, imm8
    /// </summary>
    [Symbol("vdbpsadbw zmm, zmm, m512, imm8","vdbpsadbw zmm {k1}{z}, zmm, zmm/m512, imm8")]
    vdbpsadbw_zmm_zmm_m512_imm8 = 1775,
    /// <summary>
    /// vdbpsadbw zmm {k1}{z}, zmm, zmm/m512, imm8
    /// </summary>
    [Symbol("vdbpsadbw zmm_k1z, zmm, zmm, imm8","vdbpsadbw zmm {k1}{z}, zmm, zmm/m512, imm8")]
    vdbpsadbw_zmm_k1z_zmm_zmm_imm8 = 1776,
    /// <summary>
    /// vdbpsadbw zmm {k1}{z}, zmm, zmm/m512, imm8
    /// </summary>
    [Symbol("vdbpsadbw zmm_k1z, zmm, m512, imm8","vdbpsadbw zmm {k1}{z}, zmm, zmm/m512, imm8")]
    vdbpsadbw_zmm_k1z_zmm_m512_imm8 = 1777,
    /// <summary>
    /// vextracti128 xmm/m128, ymm, imm8
    /// </summary>
    [Symbol("vextracti128 xmm, ymm, imm8","vextracti128 xmm/m128, ymm, imm8")]
    vextracti128_xmm_ymm_imm8 = 1778,
    /// <summary>
    /// vextracti128 xmm/m128, ymm, imm8
    /// </summary>
    [Symbol("vextracti128 m128, ymm, imm8","vextracti128 xmm/m128, ymm, imm8")]
    vextracti128_m128_ymm_imm8 = 1779,
    /// <summary>
    /// vextracti32x4 xmm/m128 {k1}{z}, ymm, imm8
    /// </summary>
    [Symbol("vextracti32x4 xmm_k1z, ymm, imm8","vextracti32x4 xmm/m128 {k1}{z}, ymm, imm8")]
    vextracti32x4_xmm_k1z_ymm_imm8 = 1780,
    /// <summary>
    /// vextracti32x4 xmm/m128 {k1}{z}, ymm, imm8
    /// </summary>
    [Symbol("vextracti32x4 m128_k1z, ymm, imm8","vextracti32x4 xmm/m128 {k1}{z}, ymm, imm8")]
    vextracti32x4_m128_k1z_ymm_imm8 = 1781,
    /// <summary>
    /// vextracti32x4 xmm/m128 {k1}{z}, zmm, imm8
    /// </summary>
    [Symbol("vextracti32x4 xmm_k1z, zmm, imm8","vextracti32x4 xmm/m128 {k1}{z}, zmm, imm8")]
    vextracti32x4_xmm_k1z_zmm_imm8 = 1782,
    /// <summary>
    /// vextracti32x4 xmm/m128 {k1}{z}, zmm, imm8
    /// </summary>
    [Symbol("vextracti32x4 m128_k1z, zmm, imm8","vextracti32x4 xmm/m128 {k1}{z}, zmm, imm8")]
    vextracti32x4_m128_k1z_zmm_imm8 = 1783,
    /// <summary>
    /// vextracti32x8 ymm/m256 {k1}{z}, zmm, imm8
    /// </summary>
    [Symbol("vextracti32x8 ymm_k1z, zmm, imm8","vextracti32x8 ymm/m256 {k1}{z}, zmm, imm8")]
    vextracti32x8_ymm_k1z_zmm_imm8 = 1784,
    /// <summary>
    /// vextracti32x8 ymm/m256 {k1}{z}, zmm, imm8
    /// </summary>
    [Symbol("vextracti32x8 m256_k1z, zmm, imm8","vextracti32x8 ymm/m256 {k1}{z}, zmm, imm8")]
    vextracti32x8_m256_k1z_zmm_imm8 = 1785,
    /// <summary>
    /// vextracti64x2 xmm/m128 {k1}{z}, ymm, imm8
    /// </summary>
    [Symbol("vextracti64x2 xmm_k1z, ymm, imm8","vextracti64x2 xmm/m128 {k1}{z}, ymm, imm8")]
    vextracti64x2_xmm_k1z_ymm_imm8 = 1786,
    /// <summary>
    /// vextracti64x2 xmm/m128 {k1}{z}, ymm, imm8
    /// </summary>
    [Symbol("vextracti64x2 m128_k1z, ymm, imm8","vextracti64x2 xmm/m128 {k1}{z}, ymm, imm8")]
    vextracti64x2_m128_k1z_ymm_imm8 = 1787,
    /// <summary>
    /// vextracti64x2 xmm/m128 {k1}{z}, zmm, imm8
    /// </summary>
    [Symbol("vextracti64x2 xmm_k1z, zmm, imm8","vextracti64x2 xmm/m128 {k1}{z}, zmm, imm8")]
    vextracti64x2_xmm_k1z_zmm_imm8 = 1788,
    /// <summary>
    /// vextracti64x2 xmm/m128 {k1}{z}, zmm, imm8
    /// </summary>
    [Symbol("vextracti64x2 m128_k1z, zmm, imm8","vextracti64x2 xmm/m128 {k1}{z}, zmm, imm8")]
    vextracti64x2_m128_k1z_zmm_imm8 = 1789,
    /// <summary>
    /// vextracti64x4 ymm/m256 {k1}{z}, zmm, imm8
    /// </summary>
    [Symbol("vextracti64x4 ymm_k1z, zmm, imm8","vextracti64x4 ymm/m256 {k1}{z}, zmm, imm8")]
    vextracti64x4_ymm_k1z_zmm_imm8 = 1790,
    /// <summary>
    /// vextracti64x4 ymm/m256 {k1}{z}, zmm, imm8
    /// </summary>
    [Symbol("vextracti64x4 m256_k1z, zmm, imm8","vextracti64x4 ymm/m256 {k1}{z}, zmm, imm8")]
    vextracti64x4_m256_k1z_zmm_imm8 = 1791,
    /// <summary>
    /// vinserti128 ymm, ymm, xmm/m128, imm8
    /// </summary>
    [Symbol("vinserti128 ymm, ymm, xmm, imm8","vinserti128 ymm, ymm, xmm/m128, imm8")]
    vinserti128_ymm_ymm_xmm_imm8 = 1792,
    /// <summary>
    /// vinserti128 ymm, ymm, xmm/m128, imm8
    /// </summary>
    [Symbol("vinserti128 ymm, ymm, m128, imm8","vinserti128 ymm, ymm, xmm/m128, imm8")]
    vinserti128_ymm_ymm_m128_imm8 = 1793,
    /// <summary>
    /// vinserti32x4 ymm {k1}{z}, ymm, xmm/m128, imm8
    /// </summary>
    [Symbol("vinserti32x4 ymm, ymm, xmm, imm8","vinserti32x4 ymm {k1}{z}, ymm, xmm/m128, imm8")]
    vinserti32x4_ymm_ymm_xmm_imm8 = 1794,
    /// <summary>
    /// vinserti32x4 ymm {k1}{z}, ymm, xmm/m128, imm8
    /// </summary>
    [Symbol("vinserti32x4 ymm, ymm, m128, imm8","vinserti32x4 ymm {k1}{z}, ymm, xmm/m128, imm8")]
    vinserti32x4_ymm_ymm_m128_imm8 = 1795,
    /// <summary>
    /// vinserti32x4 ymm {k1}{z}, ymm, xmm/m128, imm8
    /// </summary>
    [Symbol("vinserti32x4 ymm_k1z, ymm, xmm, imm8","vinserti32x4 ymm {k1}{z}, ymm, xmm/m128, imm8")]
    vinserti32x4_ymm_k1z_ymm_xmm_imm8 = 1796,
    /// <summary>
    /// vinserti32x4 ymm {k1}{z}, ymm, xmm/m128, imm8
    /// </summary>
    [Symbol("vinserti32x4 ymm_k1z, ymm, m128, imm8","vinserti32x4 ymm {k1}{z}, ymm, xmm/m128, imm8")]
    vinserti32x4_ymm_k1z_ymm_m128_imm8 = 1797,
    /// <summary>
    /// vinserti32x4 zmm {k1}{z}, zmm, xmm/m128, imm8
    /// </summary>
    [Symbol("vinserti32x4 zmm, zmm, xmm, imm8","vinserti32x4 zmm {k1}{z}, zmm, xmm/m128, imm8")]
    vinserti32x4_zmm_zmm_xmm_imm8 = 1798,
    /// <summary>
    /// vinserti32x4 zmm {k1}{z}, zmm, xmm/m128, imm8
    /// </summary>
    [Symbol("vinserti32x4 zmm, zmm, m128, imm8","vinserti32x4 zmm {k1}{z}, zmm, xmm/m128, imm8")]
    vinserti32x4_zmm_zmm_m128_imm8 = 1799,
    /// <summary>
    /// vinserti32x4 zmm {k1}{z}, zmm, xmm/m128, imm8
    /// </summary>
    [Symbol("vinserti32x4 zmm_k1z, zmm, xmm, imm8","vinserti32x4 zmm {k1}{z}, zmm, xmm/m128, imm8")]
    vinserti32x4_zmm_k1z_zmm_xmm_imm8 = 1800,
    /// <summary>
    /// vinserti32x4 zmm {k1}{z}, zmm, xmm/m128, imm8
    /// </summary>
    [Symbol("vinserti32x4 zmm_k1z, zmm, m128, imm8","vinserti32x4 zmm {k1}{z}, zmm, xmm/m128, imm8")]
    vinserti32x4_zmm_k1z_zmm_m128_imm8 = 1801,
    /// <summary>
    /// vinserti32x8 zmm {k1}{z}, zmm, ymm/m256, imm8
    /// </summary>
    [Symbol("vinserti32x8 zmm, zmm, ymm, imm8","vinserti32x8 zmm {k1}{z}, zmm, ymm/m256, imm8")]
    vinserti32x8_zmm_zmm_ymm_imm8 = 1802,
    /// <summary>
    /// vinserti32x8 zmm {k1}{z}, zmm, ymm/m256, imm8
    /// </summary>
    [Symbol("vinserti32x8 zmm, zmm, m256, imm8","vinserti32x8 zmm {k1}{z}, zmm, ymm/m256, imm8")]
    vinserti32x8_zmm_zmm_m256_imm8 = 1803,
    /// <summary>
    /// vinserti32x8 zmm {k1}{z}, zmm, ymm/m256, imm8
    /// </summary>
    [Symbol("vinserti32x8 zmm_k1z, zmm, ymm, imm8","vinserti32x8 zmm {k1}{z}, zmm, ymm/m256, imm8")]
    vinserti32x8_zmm_k1z_zmm_ymm_imm8 = 1804,
    /// <summary>
    /// vinserti32x8 zmm {k1}{z}, zmm, ymm/m256, imm8
    /// </summary>
    [Symbol("vinserti32x8 zmm_k1z, zmm, m256, imm8","vinserti32x8 zmm {k1}{z}, zmm, ymm/m256, imm8")]
    vinserti32x8_zmm_k1z_zmm_m256_imm8 = 1805,
    /// <summary>
    /// vinserti64x2 ymm {k1}{z}, ymm, xmm/m128, imm8
    /// </summary>
    [Symbol("vinserti64x2 ymm, ymm, xmm, imm8","vinserti64x2 ymm {k1}{z}, ymm, xmm/m128, imm8")]
    vinserti64x2_ymm_ymm_xmm_imm8 = 1806,
    /// <summary>
    /// vinserti64x2 ymm {k1}{z}, ymm, xmm/m128, imm8
    /// </summary>
    [Symbol("vinserti64x2 ymm, ymm, m128, imm8","vinserti64x2 ymm {k1}{z}, ymm, xmm/m128, imm8")]
    vinserti64x2_ymm_ymm_m128_imm8 = 1807,
    /// <summary>
    /// vinserti64x2 ymm {k1}{z}, ymm, xmm/m128, imm8
    /// </summary>
    [Symbol("vinserti64x2 ymm_k1z, ymm, xmm, imm8","vinserti64x2 ymm {k1}{z}, ymm, xmm/m128, imm8")]
    vinserti64x2_ymm_k1z_ymm_xmm_imm8 = 1808,
    /// <summary>
    /// vinserti64x2 ymm {k1}{z}, ymm, xmm/m128, imm8
    /// </summary>
    [Symbol("vinserti64x2 ymm_k1z, ymm, m128, imm8","vinserti64x2 ymm {k1}{z}, ymm, xmm/m128, imm8")]
    vinserti64x2_ymm_k1z_ymm_m128_imm8 = 1809,
    /// <summary>
    /// vinserti64x2 zmm {k1}{z}, zmm, xmm/m128, imm8
    /// </summary>
    [Symbol("vinserti64x2 zmm, zmm, xmm, imm8","vinserti64x2 zmm {k1}{z}, zmm, xmm/m128, imm8")]
    vinserti64x2_zmm_zmm_xmm_imm8 = 1810,
    /// <summary>
    /// vinserti64x2 zmm {k1}{z}, zmm, xmm/m128, imm8
    /// </summary>
    [Symbol("vinserti64x2 zmm, zmm, m128, imm8","vinserti64x2 zmm {k1}{z}, zmm, xmm/m128, imm8")]
    vinserti64x2_zmm_zmm_m128_imm8 = 1811,
    /// <summary>
    /// vinserti64x2 zmm {k1}{z}, zmm, xmm/m128, imm8
    /// </summary>
    [Symbol("vinserti64x2 zmm_k1z, zmm, xmm, imm8","vinserti64x2 zmm {k1}{z}, zmm, xmm/m128, imm8")]
    vinserti64x2_zmm_k1z_zmm_xmm_imm8 = 1812,
    /// <summary>
    /// vinserti64x2 zmm {k1}{z}, zmm, xmm/m128, imm8
    /// </summary>
    [Symbol("vinserti64x2 zmm_k1z, zmm, m128, imm8","vinserti64x2 zmm {k1}{z}, zmm, xmm/m128, imm8")]
    vinserti64x2_zmm_k1z_zmm_m128_imm8 = 1813,
    /// <summary>
    /// vinserti64x4 zmm {k1}{z}, zmm, ymm/m256, imm8
    /// </summary>
    [Symbol("vinserti64x4 zmm, zmm, ymm, imm8","vinserti64x4 zmm {k1}{z}, zmm, ymm/m256, imm8")]
    vinserti64x4_zmm_zmm_ymm_imm8 = 1814,
    /// <summary>
    /// vinserti64x4 zmm {k1}{z}, zmm, ymm/m256, imm8
    /// </summary>
    [Symbol("vinserti64x4 zmm, zmm, m256, imm8","vinserti64x4 zmm {k1}{z}, zmm, ymm/m256, imm8")]
    vinserti64x4_zmm_zmm_m256_imm8 = 1815,
    /// <summary>
    /// vinserti64x4 zmm {k1}{z}, zmm, ymm/m256, imm8
    /// </summary>
    [Symbol("vinserti64x4 zmm_k1z, zmm, ymm, imm8","vinserti64x4 zmm {k1}{z}, zmm, ymm/m256, imm8")]
    vinserti64x4_zmm_k1z_zmm_ymm_imm8 = 1816,
    /// <summary>
    /// vinserti64x4 zmm {k1}{z}, zmm, ymm/m256, imm8
    /// </summary>
    [Symbol("vinserti64x4 zmm_k1z, zmm, m256, imm8","vinserti64x4 zmm {k1}{z}, zmm, ymm/m256, imm8")]
    vinserti64x4_zmm_k1z_zmm_m256_imm8 = 1817,
    /// <summary>
    /// vlddqu xmm, m128
    /// </summary>
    [Symbol("vlddqu xmm, m128","vlddqu xmm, m128")]
    vlddqu_xmm_m128 = 1818,
    /// <summary>
    /// vlddqu ymm, m256
    /// </summary>
    [Symbol("vlddqu ymm, m256","vlddqu ymm, m256")]
    vlddqu_ymm_m256 = 1819,
    /// <summary>
    /// vmaskmovdqu xmm, xmm
    /// </summary>
    [Symbol("vmaskmovdqu xmm, xmm","vmaskmovdqu xmm, xmm")]
    vmaskmovdqu_xmm_xmm = 1820,
    /// <summary>
    /// vmaskmovpd m128, xmm, xmm
    /// </summary>
    [Symbol("vmaskmovpd m128, xmm, xmm","vmaskmovpd m128, xmm, xmm")]
    vmaskmovpd_m128_xmm_xmm = 1821,
    /// <summary>
    /// vmaskmovpd m256, ymm, ymm
    /// </summary>
    [Symbol("vmaskmovpd m256, ymm, ymm","vmaskmovpd m256, ymm, ymm")]
    vmaskmovpd_m256_ymm_ymm = 1822,
    /// <summary>
    /// vmaskmovpd xmm, xmm, m128
    /// </summary>
    [Symbol("vmaskmovpd xmm, xmm, m128","vmaskmovpd xmm, xmm, m128")]
    vmaskmovpd_xmm_xmm_m128 = 1823,
    /// <summary>
    /// vmaskmovpd ymm, ymm, m256
    /// </summary>
    [Symbol("vmaskmovpd ymm, ymm, m256","vmaskmovpd ymm, ymm, m256")]
    vmaskmovpd_ymm_ymm_m256 = 1824,
    /// <summary>
    /// vmaskmovps m128, xmm, xmm
    /// </summary>
    [Symbol("vmaskmovps m128, xmm, xmm","vmaskmovps m128, xmm, xmm")]
    vmaskmovps_m128_xmm_xmm = 1825,
    /// <summary>
    /// vmaskmovps m256, ymm, ymm
    /// </summary>
    [Symbol("vmaskmovps m256, ymm, ymm","vmaskmovps m256, ymm, ymm")]
    vmaskmovps_m256_ymm_ymm = 1826,
    /// <summary>
    /// vmaskmovps xmm, xmm, m128
    /// </summary>
    [Symbol("vmaskmovps xmm, xmm, m128","vmaskmovps xmm, xmm, m128")]
    vmaskmovps_xmm_xmm_m128 = 1827,
    /// <summary>
    /// vmaskmovps ymm, ymm, m256
    /// </summary>
    [Symbol("vmaskmovps ymm, ymm, m256","vmaskmovps ymm, ymm, m256")]
    vmaskmovps_ymm_ymm_m256 = 1828,
    /// <summary>
    /// vmovapd xmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vmovapd xmm, xmm","vmovapd xmm {k1}{z}, xmm/m128")]
    vmovapd_xmm_xmm = 1829,
    /// <summary>
    /// vmovapd xmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vmovapd xmm, m128","vmovapd xmm {k1}{z}, xmm/m128")]
    vmovapd_xmm_m128 = 1830,
    /// <summary>
    /// vmovapd xmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vmovapd xmm_k1z, xmm","vmovapd xmm {k1}{z}, xmm/m128")]
    vmovapd_xmm_k1z_xmm = 1831,
    /// <summary>
    /// vmovapd xmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vmovapd xmm_k1z, m128","vmovapd xmm {k1}{z}, xmm/m128")]
    vmovapd_xmm_k1z_m128 = 1832,
    /// <summary>
    /// vmovapd xmm/m128 {k1}{z}, xmm
    /// </summary>
    [Symbol("vmovapd m128_k1z, xmm","vmovapd xmm/m128 {k1}{z}, xmm")]
    vmovapd_m128_k1z_xmm = 1833,
    /// <summary>
    /// vmovapd xmm/m128, xmm
    /// </summary>
    [Symbol("vmovapd m128, xmm","vmovapd xmm/m128, xmm")]
    vmovapd_m128_xmm = 1834,
    /// <summary>
    /// vmovapd ymm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vmovapd ymm, ymm","vmovapd ymm {k1}{z}, ymm/m256")]
    vmovapd_ymm_ymm = 1835,
    /// <summary>
    /// vmovapd ymm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vmovapd ymm, m256","vmovapd ymm {k1}{z}, ymm/m256")]
    vmovapd_ymm_m256 = 1836,
    /// <summary>
    /// vmovapd ymm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vmovapd ymm_k1z, ymm","vmovapd ymm {k1}{z}, ymm/m256")]
    vmovapd_ymm_k1z_ymm = 1837,
    /// <summary>
    /// vmovapd ymm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vmovapd ymm_k1z, m256","vmovapd ymm {k1}{z}, ymm/m256")]
    vmovapd_ymm_k1z_m256 = 1838,
    /// <summary>
    /// vmovapd ymm/m256 {k1}{z}, ymm
    /// </summary>
    [Symbol("vmovapd m256_k1z, ymm","vmovapd ymm/m256 {k1}{z}, ymm")]
    vmovapd_m256_k1z_ymm = 1839,
    /// <summary>
    /// vmovapd ymm/m256, ymm
    /// </summary>
    [Symbol("vmovapd m256, ymm","vmovapd ymm/m256, ymm")]
    vmovapd_m256_ymm = 1840,
    /// <summary>
    /// vmovapd zmm {k1}{z}, zmm/m512
    /// </summary>
    [Symbol("vmovapd zmm, zmm","vmovapd zmm {k1}{z}, zmm/m512")]
    vmovapd_zmm_zmm = 1841,
    /// <summary>
    /// vmovapd zmm {k1}{z}, zmm/m512
    /// </summary>
    [Symbol("vmovapd zmm, m512","vmovapd zmm {k1}{z}, zmm/m512")]
    vmovapd_zmm_m512 = 1842,
    /// <summary>
    /// vmovapd zmm {k1}{z}, zmm/m512
    /// </summary>
    [Symbol("vmovapd zmm_k1z, zmm","vmovapd zmm {k1}{z}, zmm/m512")]
    vmovapd_zmm_k1z_zmm = 1843,
    /// <summary>
    /// vmovapd zmm {k1}{z}, zmm/m512
    /// </summary>
    [Symbol("vmovapd zmm_k1z, m512","vmovapd zmm {k1}{z}, zmm/m512")]
    vmovapd_zmm_k1z_m512 = 1844,
    /// <summary>
    /// vmovapd zmm/m512 {k1}{z}, zmm
    /// </summary>
    [Symbol("vmovapd m512_k1z, zmm","vmovapd zmm/m512 {k1}{z}, zmm")]
    vmovapd_m512_k1z_zmm = 1845,
    /// <summary>
    /// vmovaps xmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vmovaps xmm, xmm","vmovaps xmm {k1}{z}, xmm/m128")]
    vmovaps_xmm_xmm = 1846,
    /// <summary>
    /// vmovaps xmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vmovaps xmm, m128","vmovaps xmm {k1}{z}, xmm/m128")]
    vmovaps_xmm_m128 = 1847,
    /// <summary>
    /// vmovaps xmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vmovaps xmm_k1z, xmm","vmovaps xmm {k1}{z}, xmm/m128")]
    vmovaps_xmm_k1z_xmm = 1848,
    /// <summary>
    /// vmovaps xmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vmovaps xmm_k1z, m128","vmovaps xmm {k1}{z}, xmm/m128")]
    vmovaps_xmm_k1z_m128 = 1849,
    /// <summary>
    /// vmovaps xmm/m128 {k1}{z}, xmm
    /// </summary>
    [Symbol("vmovaps m128_k1z, xmm","vmovaps xmm/m128 {k1}{z}, xmm")]
    vmovaps_m128_k1z_xmm = 1850,
    /// <summary>
    /// vmovaps xmm/m128, xmm
    /// </summary>
    [Symbol("vmovaps m128, xmm","vmovaps xmm/m128, xmm")]
    vmovaps_m128_xmm = 1851,
    /// <summary>
    /// vmovaps ymm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vmovaps ymm, ymm","vmovaps ymm {k1}{z}, ymm/m256")]
    vmovaps_ymm_ymm = 1852,
    /// <summary>
    /// vmovaps ymm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vmovaps ymm, m256","vmovaps ymm {k1}{z}, ymm/m256")]
    vmovaps_ymm_m256 = 1853,
    /// <summary>
    /// vmovaps ymm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vmovaps ymm_k1z, ymm","vmovaps ymm {k1}{z}, ymm/m256")]
    vmovaps_ymm_k1z_ymm = 1854,
    /// <summary>
    /// vmovaps ymm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vmovaps ymm_k1z, m256","vmovaps ymm {k1}{z}, ymm/m256")]
    vmovaps_ymm_k1z_m256 = 1855,
    /// <summary>
    /// vmovaps ymm/m256 {k1}{z}, ymm
    /// </summary>
    [Symbol("vmovaps m256_k1z, ymm","vmovaps ymm/m256 {k1}{z}, ymm")]
    vmovaps_m256_k1z_ymm = 1856,
    /// <summary>
    /// vmovaps ymm/m256, ymm
    /// </summary>
    [Symbol("vmovaps m256, ymm","vmovaps ymm/m256, ymm")]
    vmovaps_m256_ymm = 1857,
    /// <summary>
    /// vmovaps zmm {k1}{z}, zmm/m512
    /// </summary>
    [Symbol("vmovaps zmm, zmm","vmovaps zmm {k1}{z}, zmm/m512")]
    vmovaps_zmm_zmm = 1858,
    /// <summary>
    /// vmovaps zmm {k1}{z}, zmm/m512
    /// </summary>
    [Symbol("vmovaps zmm, m512","vmovaps zmm {k1}{z}, zmm/m512")]
    vmovaps_zmm_m512 = 1859,
    /// <summary>
    /// vmovaps zmm {k1}{z}, zmm/m512
    /// </summary>
    [Symbol("vmovaps zmm_k1z, zmm","vmovaps zmm {k1}{z}, zmm/m512")]
    vmovaps_zmm_k1z_zmm = 1860,
    /// <summary>
    /// vmovaps zmm {k1}{z}, zmm/m512
    /// </summary>
    [Symbol("vmovaps zmm_k1z, m512","vmovaps zmm {k1}{z}, zmm/m512")]
    vmovaps_zmm_k1z_m512 = 1861,
    /// <summary>
    /// vmovaps zmm/m512 {k1}{z}, zmm
    /// </summary>
    [Symbol("vmovaps m512_k1z, zmm","vmovaps zmm/m512 {k1}{z}, zmm")]
    vmovaps_m512_k1z_zmm = 1862,
    /// <summary>
    /// vmovd r32/m32, xmm
    /// </summary>
    [Symbol("vmovd r32, xmm","vmovd r32/m32, xmm")]
    vmovd_r32_xmm = 1863,
    /// <summary>
    /// vmovd r32/m32, xmm
    /// </summary>
    [Symbol("vmovd m32, xmm","vmovd r32/m32, xmm")]
    vmovd_m32_xmm = 1864,
    /// <summary>
    /// vmovd xmm, r32/m32
    /// </summary>
    [Symbol("vmovd xmm, r32","vmovd xmm, r32/m32")]
    vmovd_xmm_r32 = 1865,
    /// <summary>
    /// vmovd xmm, r32/m32
    /// </summary>
    [Symbol("vmovd xmm, m32","vmovd xmm, r32/m32")]
    vmovd_xmm_m32 = 1866,
    /// <summary>
    /// vmovdqa xmm, xmm/m128
    /// </summary>
    [Symbol("vmovdqa xmm, xmm","vmovdqa xmm, xmm/m128")]
    vmovdqa_xmm_xmm = 1867,
    /// <summary>
    /// vmovdqa xmm, xmm/m128
    /// </summary>
    [Symbol("vmovdqa xmm, m128","vmovdqa xmm, xmm/m128")]
    vmovdqa_xmm_m128 = 1868,
    /// <summary>
    /// vmovdqa xmm/m128, xmm
    /// </summary>
    [Symbol("vmovdqa m128, xmm","vmovdqa xmm/m128, xmm")]
    vmovdqa_m128_xmm = 1869,
    /// <summary>
    /// vmovdqa ymm, ymm/m256
    /// </summary>
    [Symbol("vmovdqa ymm, ymm","vmovdqa ymm, ymm/m256")]
    vmovdqa_ymm_ymm = 1870,
    /// <summary>
    /// vmovdqa ymm, ymm/m256
    /// </summary>
    [Symbol("vmovdqa ymm, m256","vmovdqa ymm, ymm/m256")]
    vmovdqa_ymm_m256 = 1871,
    /// <summary>
    /// vmovdqa ymm/m256, ymm
    /// </summary>
    [Symbol("vmovdqa m256, ymm","vmovdqa ymm/m256, ymm")]
    vmovdqa_m256_ymm = 1872,
    /// <summary>
    /// vmovdqa32 xmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vmovdqa32 xmm, xmm","vmovdqa32 xmm {k1}{z}, xmm/m128")]
    vmovdqa32_xmm_xmm = 1873,
    /// <summary>
    /// vmovdqa32 xmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vmovdqa32 xmm, m128","vmovdqa32 xmm {k1}{z}, xmm/m128")]
    vmovdqa32_xmm_m128 = 1874,
    /// <summary>
    /// vmovdqa32 xmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vmovdqa32 xmm_k1z, xmm","vmovdqa32 xmm {k1}{z}, xmm/m128")]
    vmovdqa32_xmm_k1z_xmm = 1875,
    /// <summary>
    /// vmovdqa32 xmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vmovdqa32 xmm_k1z, m128","vmovdqa32 xmm {k1}{z}, xmm/m128")]
    vmovdqa32_xmm_k1z_m128 = 1876,
    /// <summary>
    /// vmovdqa32 xmm/m128 {k1}{z}, xmm
    /// </summary>
    [Symbol("vmovdqa32 m128_k1z, xmm","vmovdqa32 xmm/m128 {k1}{z}, xmm")]
    vmovdqa32_m128_k1z_xmm = 1877,
    /// <summary>
    /// vmovdqa32 ymm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vmovdqa32 ymm, ymm","vmovdqa32 ymm {k1}{z}, ymm/m256")]
    vmovdqa32_ymm_ymm = 1878,
    /// <summary>
    /// vmovdqa32 ymm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vmovdqa32 ymm, m256","vmovdqa32 ymm {k1}{z}, ymm/m256")]
    vmovdqa32_ymm_m256 = 1879,
    /// <summary>
    /// vmovdqa32 ymm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vmovdqa32 ymm_k1z, ymm","vmovdqa32 ymm {k1}{z}, ymm/m256")]
    vmovdqa32_ymm_k1z_ymm = 1880,
    /// <summary>
    /// vmovdqa32 ymm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vmovdqa32 ymm_k1z, m256","vmovdqa32 ymm {k1}{z}, ymm/m256")]
    vmovdqa32_ymm_k1z_m256 = 1881,
    /// <summary>
    /// vmovdqa32 ymm/m256 {k1}{z}, ymm
    /// </summary>
    [Symbol("vmovdqa32 m256_k1z, ymm","vmovdqa32 ymm/m256 {k1}{z}, ymm")]
    vmovdqa32_m256_k1z_ymm = 1882,
    /// <summary>
    /// vmovdqa32 zmm {k1}{z}, zmm/m512
    /// </summary>
    [Symbol("vmovdqa32 zmm, zmm","vmovdqa32 zmm {k1}{z}, zmm/m512")]
    vmovdqa32_zmm_zmm = 1883,
    /// <summary>
    /// vmovdqa32 zmm {k1}{z}, zmm/m512
    /// </summary>
    [Symbol("vmovdqa32 zmm, m512","vmovdqa32 zmm {k1}{z}, zmm/m512")]
    vmovdqa32_zmm_m512 = 1884,
    /// <summary>
    /// vmovdqa32 zmm {k1}{z}, zmm/m512
    /// </summary>
    [Symbol("vmovdqa32 zmm_k1z, zmm","vmovdqa32 zmm {k1}{z}, zmm/m512")]
    vmovdqa32_zmm_k1z_zmm = 1885,
    /// <summary>
    /// vmovdqa32 zmm {k1}{z}, zmm/m512
    /// </summary>
    [Symbol("vmovdqa32 zmm_k1z, m512","vmovdqa32 zmm {k1}{z}, zmm/m512")]
    vmovdqa32_zmm_k1z_m512 = 1886,
    /// <summary>
    /// vmovdqa32 zmm/m512 {k1}{z}, zmm
    /// </summary>
    [Symbol("vmovdqa32 m512_k1z, zmm","vmovdqa32 zmm/m512 {k1}{z}, zmm")]
    vmovdqa32_m512_k1z_zmm = 1887,
    /// <summary>
    /// vmovdqa64 xmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vmovdqa64 xmm, xmm","vmovdqa64 xmm {k1}{z}, xmm/m128")]
    vmovdqa64_xmm_xmm = 1888,
    /// <summary>
    /// vmovdqa64 xmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vmovdqa64 xmm, m128","vmovdqa64 xmm {k1}{z}, xmm/m128")]
    vmovdqa64_xmm_m128 = 1889,
    /// <summary>
    /// vmovdqa64 xmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vmovdqa64 xmm_k1z, xmm","vmovdqa64 xmm {k1}{z}, xmm/m128")]
    vmovdqa64_xmm_k1z_xmm = 1890,
    /// <summary>
    /// vmovdqa64 xmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vmovdqa64 xmm_k1z, m128","vmovdqa64 xmm {k1}{z}, xmm/m128")]
    vmovdqa64_xmm_k1z_m128 = 1891,
    /// <summary>
    /// vmovdqa64 xmm/m128 {k1}{z}, xmm
    /// </summary>
    [Symbol("vmovdqa64 m128_k1z, xmm","vmovdqa64 xmm/m128 {k1}{z}, xmm")]
    vmovdqa64_m128_k1z_xmm = 1892,
    /// <summary>
    /// vmovdqa64 ymm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vmovdqa64 ymm, ymm","vmovdqa64 ymm {k1}{z}, ymm/m256")]
    vmovdqa64_ymm_ymm = 1893,
    /// <summary>
    /// vmovdqa64 ymm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vmovdqa64 ymm, m256","vmovdqa64 ymm {k1}{z}, ymm/m256")]
    vmovdqa64_ymm_m256 = 1894,
    /// <summary>
    /// vmovdqa64 ymm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vmovdqa64 ymm_k1z, ymm","vmovdqa64 ymm {k1}{z}, ymm/m256")]
    vmovdqa64_ymm_k1z_ymm = 1895,
    /// <summary>
    /// vmovdqa64 ymm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vmovdqa64 ymm_k1z, m256","vmovdqa64 ymm {k1}{z}, ymm/m256")]
    vmovdqa64_ymm_k1z_m256 = 1896,
    /// <summary>
    /// vmovdqa64 ymm/m256 {k1}{z}, ymm
    /// </summary>
    [Symbol("vmovdqa64 m256_k1z, ymm","vmovdqa64 ymm/m256 {k1}{z}, ymm")]
    vmovdqa64_m256_k1z_ymm = 1897,
    /// <summary>
    /// vmovdqa64 zmm {k1}{z}, zmm/m512
    /// </summary>
    [Symbol("vmovdqa64 zmm, zmm","vmovdqa64 zmm {k1}{z}, zmm/m512")]
    vmovdqa64_zmm_zmm = 1898,
    /// <summary>
    /// vmovdqa64 zmm {k1}{z}, zmm/m512
    /// </summary>
    [Symbol("vmovdqa64 zmm, m512","vmovdqa64 zmm {k1}{z}, zmm/m512")]
    vmovdqa64_zmm_m512 = 1899,
    /// <summary>
    /// vmovdqa64 zmm {k1}{z}, zmm/m512
    /// </summary>
    [Symbol("vmovdqa64 zmm_k1z, zmm","vmovdqa64 zmm {k1}{z}, zmm/m512")]
    vmovdqa64_zmm_k1z_zmm = 1900,
    /// <summary>
    /// vmovdqa64 zmm {k1}{z}, zmm/m512
    /// </summary>
    [Symbol("vmovdqa64 zmm_k1z, m512","vmovdqa64 zmm {k1}{z}, zmm/m512")]
    vmovdqa64_zmm_k1z_m512 = 1901,
    /// <summary>
    /// vmovdqa64 zmm/m512 {k1}{z}, zmm
    /// </summary>
    [Symbol("vmovdqa64 m512_k1z, zmm","vmovdqa64 zmm/m512 {k1}{z}, zmm")]
    vmovdqa64_m512_k1z_zmm = 1902,
    /// <summary>
    /// vmovdqu xmm, xmm/m128
    /// </summary>
    [Symbol("vmovdqu xmm, xmm","vmovdqu xmm, xmm/m128")]
    vmovdqu_xmm_xmm = 1903,
    /// <summary>
    /// vmovdqu xmm, xmm/m128
    /// </summary>
    [Symbol("vmovdqu xmm, m128","vmovdqu xmm, xmm/m128")]
    vmovdqu_xmm_m128 = 1904,
    /// <summary>
    /// vmovdqu xmm/m128, xmm
    /// </summary>
    [Symbol("vmovdqu m128, xmm","vmovdqu xmm/m128, xmm")]
    vmovdqu_m128_xmm = 1905,
    /// <summary>
    /// vmovdqu ymm, ymm/m256
    /// </summary>
    [Symbol("vmovdqu ymm, ymm","vmovdqu ymm, ymm/m256")]
    vmovdqu_ymm_ymm = 1906,
    /// <summary>
    /// vmovdqu ymm, ymm/m256
    /// </summary>
    [Symbol("vmovdqu ymm, m256","vmovdqu ymm, ymm/m256")]
    vmovdqu_ymm_m256 = 1907,
    /// <summary>
    /// vmovdqu ymm/m256, ymm
    /// </summary>
    [Symbol("vmovdqu m256, ymm","vmovdqu ymm/m256, ymm")]
    vmovdqu_m256_ymm = 1908,
    /// <summary>
    /// vmovdqu16 xmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vmovdqu16 xmm, xmm","vmovdqu16 xmm {k1}{z}, xmm/m128")]
    vmovdqu16_xmm_xmm = 1909,
    /// <summary>
    /// vmovdqu16 xmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vmovdqu16 xmm, m128","vmovdqu16 xmm {k1}{z}, xmm/m128")]
    vmovdqu16_xmm_m128 = 1910,
    /// <summary>
    /// vmovdqu16 xmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vmovdqu16 xmm_k1z, xmm","vmovdqu16 xmm {k1}{z}, xmm/m128")]
    vmovdqu16_xmm_k1z_xmm = 1911,
    /// <summary>
    /// vmovdqu16 xmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vmovdqu16 xmm_k1z, m128","vmovdqu16 xmm {k1}{z}, xmm/m128")]
    vmovdqu16_xmm_k1z_m128 = 1912,
    /// <summary>
    /// vmovdqu16 xmm/m128 {k1}{z}, xmm
    /// </summary>
    [Symbol("vmovdqu16 m128_k1z, xmm","vmovdqu16 xmm/m128 {k1}{z}, xmm")]
    vmovdqu16_m128_k1z_xmm = 1913,
    /// <summary>
    /// vmovdqu16 ymm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vmovdqu16 ymm, ymm","vmovdqu16 ymm {k1}{z}, ymm/m256")]
    vmovdqu16_ymm_ymm = 1914,
    /// <summary>
    /// vmovdqu16 ymm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vmovdqu16 ymm, m256","vmovdqu16 ymm {k1}{z}, ymm/m256")]
    vmovdqu16_ymm_m256 = 1915,
    /// <summary>
    /// vmovdqu16 ymm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vmovdqu16 ymm_k1z, ymm","vmovdqu16 ymm {k1}{z}, ymm/m256")]
    vmovdqu16_ymm_k1z_ymm = 1916,
    /// <summary>
    /// vmovdqu16 ymm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vmovdqu16 ymm_k1z, m256","vmovdqu16 ymm {k1}{z}, ymm/m256")]
    vmovdqu16_ymm_k1z_m256 = 1917,
    /// <summary>
    /// vmovdqu16 ymm/m256 {k1}{z}, ymm
    /// </summary>
    [Symbol("vmovdqu16 m256_k1z, ymm","vmovdqu16 ymm/m256 {k1}{z}, ymm")]
    vmovdqu16_m256_k1z_ymm = 1918,
    /// <summary>
    /// vmovdqu16 zmm {k1}{z}, zmm/m512
    /// </summary>
    [Symbol("vmovdqu16 zmm, zmm","vmovdqu16 zmm {k1}{z}, zmm/m512")]
    vmovdqu16_zmm_zmm = 1919,
    /// <summary>
    /// vmovdqu16 zmm {k1}{z}, zmm/m512
    /// </summary>
    [Symbol("vmovdqu16 zmm, m512","vmovdqu16 zmm {k1}{z}, zmm/m512")]
    vmovdqu16_zmm_m512 = 1920,
    /// <summary>
    /// vmovdqu16 zmm {k1}{z}, zmm/m512
    /// </summary>
    [Symbol("vmovdqu16 zmm_k1z, zmm","vmovdqu16 zmm {k1}{z}, zmm/m512")]
    vmovdqu16_zmm_k1z_zmm = 1921,
    /// <summary>
    /// vmovdqu16 zmm {k1}{z}, zmm/m512
    /// </summary>
    [Symbol("vmovdqu16 zmm_k1z, m512","vmovdqu16 zmm {k1}{z}, zmm/m512")]
    vmovdqu16_zmm_k1z_m512 = 1922,
    /// <summary>
    /// vmovdqu16 zmm/m512 {k1}{z}, zmm
    /// </summary>
    [Symbol("vmovdqu16 m512_k1z, zmm","vmovdqu16 zmm/m512 {k1}{z}, zmm")]
    vmovdqu16_m512_k1z_zmm = 1923,
    /// <summary>
    /// vmovdqu32 xmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vmovdqu32 xmm, xmm","vmovdqu32 xmm {k1}{z}, xmm/m128")]
    vmovdqu32_xmm_xmm = 1924,
    /// <summary>
    /// vmovdqu32 xmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vmovdqu32 xmm, m128","vmovdqu32 xmm {k1}{z}, xmm/m128")]
    vmovdqu32_xmm_m128 = 1925,
    /// <summary>
    /// vmovdqu32 xmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vmovdqu32 xmm_k1z, xmm","vmovdqu32 xmm {k1}{z}, xmm/m128")]
    vmovdqu32_xmm_k1z_xmm = 1926,
    /// <summary>
    /// vmovdqu32 xmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vmovdqu32 xmm_k1z, m128","vmovdqu32 xmm {k1}{z}, xmm/m128")]
    vmovdqu32_xmm_k1z_m128 = 1927,
    /// <summary>
    /// vmovdqu32 xmm/m128 {k1}{z}, xmm
    /// </summary>
    [Symbol("vmovdqu32 m128_k1z, xmm","vmovdqu32 xmm/m128 {k1}{z}, xmm")]
    vmovdqu32_m128_k1z_xmm = 1928,
    /// <summary>
    /// vmovdqu32 ymm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vmovdqu32 ymm, ymm","vmovdqu32 ymm {k1}{z}, ymm/m256")]
    vmovdqu32_ymm_ymm = 1929,
    /// <summary>
    /// vmovdqu32 ymm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vmovdqu32 ymm, m256","vmovdqu32 ymm {k1}{z}, ymm/m256")]
    vmovdqu32_ymm_m256 = 1930,
    /// <summary>
    /// vmovdqu32 ymm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vmovdqu32 ymm_k1z, ymm","vmovdqu32 ymm {k1}{z}, ymm/m256")]
    vmovdqu32_ymm_k1z_ymm = 1931,
    /// <summary>
    /// vmovdqu32 ymm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vmovdqu32 ymm_k1z, m256","vmovdqu32 ymm {k1}{z}, ymm/m256")]
    vmovdqu32_ymm_k1z_m256 = 1932,
    /// <summary>
    /// vmovdqu32 ymm/m256 {k1}{z}, ymm
    /// </summary>
    [Symbol("vmovdqu32 m256_k1z, ymm","vmovdqu32 ymm/m256 {k1}{z}, ymm")]
    vmovdqu32_m256_k1z_ymm = 1933,
    /// <summary>
    /// vmovdqu32 zmm {k1}{z}, zmm/m512
    /// </summary>
    [Symbol("vmovdqu32 zmm, zmm","vmovdqu32 zmm {k1}{z}, zmm/m512")]
    vmovdqu32_zmm_zmm = 1934,
    /// <summary>
    /// vmovdqu32 zmm {k1}{z}, zmm/m512
    /// </summary>
    [Symbol("vmovdqu32 zmm, m512","vmovdqu32 zmm {k1}{z}, zmm/m512")]
    vmovdqu32_zmm_m512 = 1935,
    /// <summary>
    /// vmovdqu32 zmm {k1}{z}, zmm/m512
    /// </summary>
    [Symbol("vmovdqu32 zmm_k1z, zmm","vmovdqu32 zmm {k1}{z}, zmm/m512")]
    vmovdqu32_zmm_k1z_zmm = 1936,
    /// <summary>
    /// vmovdqu32 zmm {k1}{z}, zmm/m512
    /// </summary>
    [Symbol("vmovdqu32 zmm_k1z, m512","vmovdqu32 zmm {k1}{z}, zmm/m512")]
    vmovdqu32_zmm_k1z_m512 = 1937,
    /// <summary>
    /// vmovdqu32 zmm/m512 {k1}{z}, zmm
    /// </summary>
    [Symbol("vmovdqu32 m512_k1z, zmm","vmovdqu32 zmm/m512 {k1}{z}, zmm")]
    vmovdqu32_m512_k1z_zmm = 1938,
    /// <summary>
    /// vmovdqu64 xmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vmovdqu64 xmm, xmm","vmovdqu64 xmm {k1}{z}, xmm/m128")]
    vmovdqu64_xmm_xmm = 1939,
    /// <summary>
    /// vmovdqu64 xmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vmovdqu64 xmm, m128","vmovdqu64 xmm {k1}{z}, xmm/m128")]
    vmovdqu64_xmm_m128 = 1940,
    /// <summary>
    /// vmovdqu64 xmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vmovdqu64 xmm_k1z, xmm","vmovdqu64 xmm {k1}{z}, xmm/m128")]
    vmovdqu64_xmm_k1z_xmm = 1941,
    /// <summary>
    /// vmovdqu64 xmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vmovdqu64 xmm_k1z, m128","vmovdqu64 xmm {k1}{z}, xmm/m128")]
    vmovdqu64_xmm_k1z_m128 = 1942,
    /// <summary>
    /// vmovdqu64 xmm/m128 {k1}{z}, xmm
    /// </summary>
    [Symbol("vmovdqu64 m128_k1z, xmm","vmovdqu64 xmm/m128 {k1}{z}, xmm")]
    vmovdqu64_m128_k1z_xmm = 1943,
    /// <summary>
    /// vmovdqu64 ymm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vmovdqu64 ymm, ymm","vmovdqu64 ymm {k1}{z}, ymm/m256")]
    vmovdqu64_ymm_ymm = 1944,
    /// <summary>
    /// vmovdqu64 ymm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vmovdqu64 ymm, m256","vmovdqu64 ymm {k1}{z}, ymm/m256")]
    vmovdqu64_ymm_m256 = 1945,
    /// <summary>
    /// vmovdqu64 ymm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vmovdqu64 ymm_k1z, ymm","vmovdqu64 ymm {k1}{z}, ymm/m256")]
    vmovdqu64_ymm_k1z_ymm = 1946,
    /// <summary>
    /// vmovdqu64 ymm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vmovdqu64 ymm_k1z, m256","vmovdqu64 ymm {k1}{z}, ymm/m256")]
    vmovdqu64_ymm_k1z_m256 = 1947,
    /// <summary>
    /// vmovdqu64 ymm/m256 {k1}{z}, ymm
    /// </summary>
    [Symbol("vmovdqu64 m256_k1z, ymm","vmovdqu64 ymm/m256 {k1}{z}, ymm")]
    vmovdqu64_m256_k1z_ymm = 1948,
    /// <summary>
    /// vmovdqu64 zmm {k1}{z}, zmm/m512
    /// </summary>
    [Symbol("vmovdqu64 zmm, zmm","vmovdqu64 zmm {k1}{z}, zmm/m512")]
    vmovdqu64_zmm_zmm = 1949,
    /// <summary>
    /// vmovdqu64 zmm {k1}{z}, zmm/m512
    /// </summary>
    [Symbol("vmovdqu64 zmm, m512","vmovdqu64 zmm {k1}{z}, zmm/m512")]
    vmovdqu64_zmm_m512 = 1950,
    /// <summary>
    /// vmovdqu64 zmm {k1}{z}, zmm/m512
    /// </summary>
    [Symbol("vmovdqu64 zmm_k1z, zmm","vmovdqu64 zmm {k1}{z}, zmm/m512")]
    vmovdqu64_zmm_k1z_zmm = 1951,
    /// <summary>
    /// vmovdqu64 zmm {k1}{z}, zmm/m512
    /// </summary>
    [Symbol("vmovdqu64 zmm_k1z, m512","vmovdqu64 zmm {k1}{z}, zmm/m512")]
    vmovdqu64_zmm_k1z_m512 = 1952,
    /// <summary>
    /// vmovdqu64 zmm/m512 {k1}{z}, zmm
    /// </summary>
    [Symbol("vmovdqu64 m512_k1z, zmm","vmovdqu64 zmm/m512 {k1}{z}, zmm")]
    vmovdqu64_m512_k1z_zmm = 1953,
    /// <summary>
    /// vmovdqu8 xmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vmovdqu8 xmm, xmm","vmovdqu8 xmm {k1}{z}, xmm/m128")]
    vmovdqu8_xmm_xmm = 1954,
    /// <summary>
    /// vmovdqu8 xmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vmovdqu8 xmm, m128","vmovdqu8 xmm {k1}{z}, xmm/m128")]
    vmovdqu8_xmm_m128 = 1955,
    /// <summary>
    /// vmovdqu8 xmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vmovdqu8 xmm_k1z, xmm","vmovdqu8 xmm {k1}{z}, xmm/m128")]
    vmovdqu8_xmm_k1z_xmm = 1956,
    /// <summary>
    /// vmovdqu8 xmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vmovdqu8 xmm_k1z, m128","vmovdqu8 xmm {k1}{z}, xmm/m128")]
    vmovdqu8_xmm_k1z_m128 = 1957,
    /// <summary>
    /// vmovdqu8 xmm/m128 {k1}{z}, xmm
    /// </summary>
    [Symbol("vmovdqu8 m128_k1z, xmm","vmovdqu8 xmm/m128 {k1}{z}, xmm")]
    vmovdqu8_m128_k1z_xmm = 1958,
    /// <summary>
    /// vmovdqu8 ymm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vmovdqu8 ymm, ymm","vmovdqu8 ymm {k1}{z}, ymm/m256")]
    vmovdqu8_ymm_ymm = 1959,
    /// <summary>
    /// vmovdqu8 ymm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vmovdqu8 ymm, m256","vmovdqu8 ymm {k1}{z}, ymm/m256")]
    vmovdqu8_ymm_m256 = 1960,
    /// <summary>
    /// vmovdqu8 ymm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vmovdqu8 ymm_k1z, ymm","vmovdqu8 ymm {k1}{z}, ymm/m256")]
    vmovdqu8_ymm_k1z_ymm = 1961,
    /// <summary>
    /// vmovdqu8 ymm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vmovdqu8 ymm_k1z, m256","vmovdqu8 ymm {k1}{z}, ymm/m256")]
    vmovdqu8_ymm_k1z_m256 = 1962,
    /// <summary>
    /// vmovdqu8 ymm/m256 {k1}{z}, ymm
    /// </summary>
    [Symbol("vmovdqu8 m256_k1z, ymm","vmovdqu8 ymm/m256 {k1}{z}, ymm")]
    vmovdqu8_m256_k1z_ymm = 1963,
    /// <summary>
    /// vmovdqu8 zmm {k1}{z}, zmm/m512
    /// </summary>
    [Symbol("vmovdqu8 zmm, zmm","vmovdqu8 zmm {k1}{z}, zmm/m512")]
    vmovdqu8_zmm_zmm = 1964,
    /// <summary>
    /// vmovdqu8 zmm {k1}{z}, zmm/m512
    /// </summary>
    [Symbol("vmovdqu8 zmm, m512","vmovdqu8 zmm {k1}{z}, zmm/m512")]
    vmovdqu8_zmm_m512 = 1965,
    /// <summary>
    /// vmovdqu8 zmm {k1}{z}, zmm/m512
    /// </summary>
    [Symbol("vmovdqu8 zmm_k1z, zmm","vmovdqu8 zmm {k1}{z}, zmm/m512")]
    vmovdqu8_zmm_k1z_zmm = 1966,
    /// <summary>
    /// vmovdqu8 zmm {k1}{z}, zmm/m512
    /// </summary>
    [Symbol("vmovdqu8 zmm_k1z, m512","vmovdqu8 zmm {k1}{z}, zmm/m512")]
    vmovdqu8_zmm_k1z_m512 = 1967,
    /// <summary>
    /// vmovdqu8 zmm/m512 {k1}{z}, zmm
    /// </summary>
    [Symbol("vmovdqu8 m512_k1z, zmm","vmovdqu8 zmm/m512 {k1}{z}, zmm")]
    vmovdqu8_m512_k1z_zmm = 1968,
    /// <summary>
    /// vmovq r64/m64, xmm
    /// </summary>
    [Symbol("vmovq r64, xmm","vmovq r64/m64, xmm")]
    vmovq_r64_xmm = 1969,
    /// <summary>
    /// vmovq r64/m64, xmm
    /// </summary>
    [Symbol("vmovq m64, xmm","vmovq r64/m64, xmm")]
    vmovq_m64_xmm = 1970,
    /// <summary>
    /// vmovq xmm, r64/m64
    /// </summary>
    [Symbol("vmovq xmm, r64","vmovq xmm, r64/m64")]
    vmovq_xmm_r64 = 1971,
    /// <summary>
    /// vmovq xmm, r64/m64
    /// </summary>
    [Symbol("vmovq xmm, m64","vmovq xmm, r64/m64")]
    vmovq_xmm_m64 = 1972,
    /// <summary>
    /// vmovq xmm, xmm/m64
    /// </summary>
    [Symbol("vmovq xmm, xmm","vmovq xmm, xmm/m64")]
    vmovq_xmm_xmm = 1973,
    /// <summary>
    /// vmovupd xmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vmovupd xmm, xmm","vmovupd xmm {k1}{z}, xmm/m128")]
    vmovupd_xmm_xmm = 1974,
    /// <summary>
    /// vmovupd xmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vmovupd xmm, m128","vmovupd xmm {k1}{z}, xmm/m128")]
    vmovupd_xmm_m128 = 1975,
    /// <summary>
    /// vmovupd xmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vmovupd xmm_k1z, xmm","vmovupd xmm {k1}{z}, xmm/m128")]
    vmovupd_xmm_k1z_xmm = 1976,
    /// <summary>
    /// vmovupd xmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vmovupd xmm_k1z, m128","vmovupd xmm {k1}{z}, xmm/m128")]
    vmovupd_xmm_k1z_m128 = 1977,
    /// <summary>
    /// vmovupd xmm/m128 {k1}{z}, xmm
    /// </summary>
    [Symbol("vmovupd m128_k1z, xmm","vmovupd xmm/m128 {k1}{z}, xmm")]
    vmovupd_m128_k1z_xmm = 1978,
    /// <summary>
    /// vmovupd xmm/m128, xmm
    /// </summary>
    [Symbol("vmovupd m128, xmm","vmovupd xmm/m128, xmm")]
    vmovupd_m128_xmm = 1979,
    /// <summary>
    /// vmovupd ymm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vmovupd ymm, ymm","vmovupd ymm {k1}{z}, ymm/m256")]
    vmovupd_ymm_ymm = 1980,
    /// <summary>
    /// vmovupd ymm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vmovupd ymm, m256","vmovupd ymm {k1}{z}, ymm/m256")]
    vmovupd_ymm_m256 = 1981,
    /// <summary>
    /// vmovupd ymm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vmovupd ymm_k1z, ymm","vmovupd ymm {k1}{z}, ymm/m256")]
    vmovupd_ymm_k1z_ymm = 1982,
    /// <summary>
    /// vmovupd ymm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vmovupd ymm_k1z, m256","vmovupd ymm {k1}{z}, ymm/m256")]
    vmovupd_ymm_k1z_m256 = 1983,
    /// <summary>
    /// vmovupd ymm/m256 {k1}{z}, ymm
    /// </summary>
    [Symbol("vmovupd m256_k1z, ymm","vmovupd ymm/m256 {k1}{z}, ymm")]
    vmovupd_m256_k1z_ymm = 1984,
    /// <summary>
    /// vmovupd ymm/m256, ymm
    /// </summary>
    [Symbol("vmovupd m256, ymm","vmovupd ymm/m256, ymm")]
    vmovupd_m256_ymm = 1985,
    /// <summary>
    /// vmovupd zmm {k1}{z}, zmm/m512
    /// </summary>
    [Symbol("vmovupd zmm, zmm","vmovupd zmm {k1}{z}, zmm/m512")]
    vmovupd_zmm_zmm = 1986,
    /// <summary>
    /// vmovupd zmm {k1}{z}, zmm/m512
    /// </summary>
    [Symbol("vmovupd zmm, m512","vmovupd zmm {k1}{z}, zmm/m512")]
    vmovupd_zmm_m512 = 1987,
    /// <summary>
    /// vmovupd zmm {k1}{z}, zmm/m512
    /// </summary>
    [Symbol("vmovupd zmm_k1z, zmm","vmovupd zmm {k1}{z}, zmm/m512")]
    vmovupd_zmm_k1z_zmm = 1988,
    /// <summary>
    /// vmovupd zmm {k1}{z}, zmm/m512
    /// </summary>
    [Symbol("vmovupd zmm_k1z, m512","vmovupd zmm {k1}{z}, zmm/m512")]
    vmovupd_zmm_k1z_m512 = 1989,
    /// <summary>
    /// vmovupd zmm/m512 {k1}{z}, zmm
    /// </summary>
    [Symbol("vmovupd m512_k1z, zmm","vmovupd zmm/m512 {k1}{z}, zmm")]
    vmovupd_m512_k1z_zmm = 1990,
    /// <summary>
    /// vmpsadbw xmm, xmm, xmm/m128, imm8
    /// </summary>
    [Symbol("vmpsadbw xmm, xmm, xmm, imm8","vmpsadbw xmm, xmm, xmm/m128, imm8")]
    vmpsadbw_xmm_xmm_xmm_imm8 = 1991,
    /// <summary>
    /// vmpsadbw xmm, xmm, xmm/m128, imm8
    /// </summary>
    [Symbol("vmpsadbw xmm, xmm, m128, imm8","vmpsadbw xmm, xmm, xmm/m128, imm8")]
    vmpsadbw_xmm_xmm_m128_imm8 = 1992,
    /// <summary>
    /// vmpsadbw ymm, ymm, ymm/m256, imm8
    /// </summary>
    [Symbol("vmpsadbw ymm, ymm, ymm, imm8","vmpsadbw ymm, ymm, ymm/m256, imm8")]
    vmpsadbw_ymm_ymm_ymm_imm8 = 1993,
    /// <summary>
    /// vmpsadbw ymm, ymm, ymm/m256, imm8
    /// </summary>
    [Symbol("vmpsadbw ymm, ymm, m256, imm8","vmpsadbw ymm, ymm, ymm/m256, imm8")]
    vmpsadbw_ymm_ymm_m256_imm8 = 1994,
    /// <summary>
    /// vpabsb xmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vpabsb xmm, xmm","vpabsb xmm {k1}{z}, xmm/m128")]
    vpabsb_xmm_xmm = 1995,
    /// <summary>
    /// vpabsb xmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vpabsb xmm, m128","vpabsb xmm {k1}{z}, xmm/m128")]
    vpabsb_xmm_m128 = 1996,
    /// <summary>
    /// vpabsb xmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vpabsb xmm_k1z, xmm","vpabsb xmm {k1}{z}, xmm/m128")]
    vpabsb_xmm_k1z_xmm = 1997,
    /// <summary>
    /// vpabsb xmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vpabsb xmm_k1z, m128","vpabsb xmm {k1}{z}, xmm/m128")]
    vpabsb_xmm_k1z_m128 = 1998,
    /// <summary>
    /// vpabsb ymm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vpabsb ymm, ymm","vpabsb ymm {k1}{z}, ymm/m256")]
    vpabsb_ymm_ymm = 1999,
    /// <summary>
    /// vpabsb ymm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vpabsb ymm, m256","vpabsb ymm {k1}{z}, ymm/m256")]
    vpabsb_ymm_m256 = 2000,
    /// <summary>
    /// vpabsb ymm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vpabsb ymm_k1z, ymm","vpabsb ymm {k1}{z}, ymm/m256")]
    vpabsb_ymm_k1z_ymm = 2001,
    /// <summary>
    /// vpabsb ymm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vpabsb ymm_k1z, m256","vpabsb ymm {k1}{z}, ymm/m256")]
    vpabsb_ymm_k1z_m256 = 2002,
    /// <summary>
    /// vpabsb zmm {k1}{z}, zmm/m512
    /// </summary>
    [Symbol("vpabsb zmm, zmm","vpabsb zmm {k1}{z}, zmm/m512")]
    vpabsb_zmm_zmm = 2003,
    /// <summary>
    /// vpabsb zmm {k1}{z}, zmm/m512
    /// </summary>
    [Symbol("vpabsb zmm, m512","vpabsb zmm {k1}{z}, zmm/m512")]
    vpabsb_zmm_m512 = 2004,
    /// <summary>
    /// vpabsb zmm {k1}{z}, zmm/m512
    /// </summary>
    [Symbol("vpabsb zmm_k1z, zmm","vpabsb zmm {k1}{z}, zmm/m512")]
    vpabsb_zmm_k1z_zmm = 2005,
    /// <summary>
    /// vpabsb zmm {k1}{z}, zmm/m512
    /// </summary>
    [Symbol("vpabsb zmm_k1z, m512","vpabsb zmm {k1}{z}, zmm/m512")]
    vpabsb_zmm_k1z_m512 = 2006,
    /// <summary>
    /// vpabsd xmm {k1}{z}, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpabsd xmm, xmm","vpabsd xmm {k1}{z}, xmm/m128/m32bcst")]
    vpabsd_xmm_xmm = 2007,
    /// <summary>
    /// vpabsd xmm {k1}{z}, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpabsd xmm, m128","vpabsd xmm {k1}{z}, xmm/m128/m32bcst")]
    vpabsd_xmm_m128 = 2008,
    /// <summary>
    /// vpabsd xmm {k1}{z}, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpabsd xmm, m32bcst","vpabsd xmm {k1}{z}, xmm/m128/m32bcst")]
    vpabsd_xmm_m32bcst = 2009,
    /// <summary>
    /// vpabsd xmm {k1}{z}, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpabsd xmm_k1z, xmm","vpabsd xmm {k1}{z}, xmm/m128/m32bcst")]
    vpabsd_xmm_k1z_xmm = 2010,
    /// <summary>
    /// vpabsd xmm {k1}{z}, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpabsd xmm_k1z, m128","vpabsd xmm {k1}{z}, xmm/m128/m32bcst")]
    vpabsd_xmm_k1z_m128 = 2011,
    /// <summary>
    /// vpabsd xmm {k1}{z}, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpabsd xmm_k1z, m32bcst","vpabsd xmm {k1}{z}, xmm/m128/m32bcst")]
    vpabsd_xmm_k1z_m32bcst = 2012,
    /// <summary>
    /// vpabsd ymm {k1}{z}, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpabsd ymm, ymm","vpabsd ymm {k1}{z}, ymm/m256/m32bcst")]
    vpabsd_ymm_ymm = 2013,
    /// <summary>
    /// vpabsd ymm {k1}{z}, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpabsd ymm, m256","vpabsd ymm {k1}{z}, ymm/m256/m32bcst")]
    vpabsd_ymm_m256 = 2014,
    /// <summary>
    /// vpabsd ymm {k1}{z}, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpabsd ymm, m32bcst","vpabsd ymm {k1}{z}, ymm/m256/m32bcst")]
    vpabsd_ymm_m32bcst = 2015,
    /// <summary>
    /// vpabsd ymm {k1}{z}, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpabsd ymm_k1z, ymm","vpabsd ymm {k1}{z}, ymm/m256/m32bcst")]
    vpabsd_ymm_k1z_ymm = 2016,
    /// <summary>
    /// vpabsd ymm {k1}{z}, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpabsd ymm_k1z, m256","vpabsd ymm {k1}{z}, ymm/m256/m32bcst")]
    vpabsd_ymm_k1z_m256 = 2017,
    /// <summary>
    /// vpabsd ymm {k1}{z}, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpabsd ymm_k1z, m32bcst","vpabsd ymm {k1}{z}, ymm/m256/m32bcst")]
    vpabsd_ymm_k1z_m32bcst = 2018,
    /// <summary>
    /// vpabsd zmm {k1}{z}, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpabsd zmm, zmm","vpabsd zmm {k1}{z}, zmm/m512/m32bcst")]
    vpabsd_zmm_zmm = 2019,
    /// <summary>
    /// vpabsd zmm {k1}{z}, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpabsd zmm, m512","vpabsd zmm {k1}{z}, zmm/m512/m32bcst")]
    vpabsd_zmm_m512 = 2020,
    /// <summary>
    /// vpabsd zmm {k1}{z}, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpabsd zmm, m32bcst","vpabsd zmm {k1}{z}, zmm/m512/m32bcst")]
    vpabsd_zmm_m32bcst = 2021,
    /// <summary>
    /// vpabsd zmm {k1}{z}, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpabsd zmm_k1z, zmm","vpabsd zmm {k1}{z}, zmm/m512/m32bcst")]
    vpabsd_zmm_k1z_zmm = 2022,
    /// <summary>
    /// vpabsd zmm {k1}{z}, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpabsd zmm_k1z, m512","vpabsd zmm {k1}{z}, zmm/m512/m32bcst")]
    vpabsd_zmm_k1z_m512 = 2023,
    /// <summary>
    /// vpabsd zmm {k1}{z}, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpabsd zmm_k1z, m32bcst","vpabsd zmm {k1}{z}, zmm/m512/m32bcst")]
    vpabsd_zmm_k1z_m32bcst = 2024,
    /// <summary>
    /// vpabsq xmm {k1}{z}, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpabsq xmm, xmm","vpabsq xmm {k1}{z}, xmm/m128/m64bcst")]
    vpabsq_xmm_xmm = 2025,
    /// <summary>
    /// vpabsq xmm {k1}{z}, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpabsq xmm, m128","vpabsq xmm {k1}{z}, xmm/m128/m64bcst")]
    vpabsq_xmm_m128 = 2026,
    /// <summary>
    /// vpabsq xmm {k1}{z}, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpabsq xmm, m64bcst","vpabsq xmm {k1}{z}, xmm/m128/m64bcst")]
    vpabsq_xmm_m64bcst = 2027,
    /// <summary>
    /// vpabsq xmm {k1}{z}, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpabsq xmm_k1z, xmm","vpabsq xmm {k1}{z}, xmm/m128/m64bcst")]
    vpabsq_xmm_k1z_xmm = 2028,
    /// <summary>
    /// vpabsq xmm {k1}{z}, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpabsq xmm_k1z, m128","vpabsq xmm {k1}{z}, xmm/m128/m64bcst")]
    vpabsq_xmm_k1z_m128 = 2029,
    /// <summary>
    /// vpabsq xmm {k1}{z}, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpabsq xmm_k1z, m64bcst","vpabsq xmm {k1}{z}, xmm/m128/m64bcst")]
    vpabsq_xmm_k1z_m64bcst = 2030,
    /// <summary>
    /// vpabsq ymm {k1}{z}, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpabsq ymm, ymm","vpabsq ymm {k1}{z}, ymm/m256/m64bcst")]
    vpabsq_ymm_ymm = 2031,
    /// <summary>
    /// vpabsq ymm {k1}{z}, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpabsq ymm, m256","vpabsq ymm {k1}{z}, ymm/m256/m64bcst")]
    vpabsq_ymm_m256 = 2032,
    /// <summary>
    /// vpabsq ymm {k1}{z}, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpabsq ymm, m64bcst","vpabsq ymm {k1}{z}, ymm/m256/m64bcst")]
    vpabsq_ymm_m64bcst = 2033,
    /// <summary>
    /// vpabsq ymm {k1}{z}, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpabsq ymm_k1z, ymm","vpabsq ymm {k1}{z}, ymm/m256/m64bcst")]
    vpabsq_ymm_k1z_ymm = 2034,
    /// <summary>
    /// vpabsq ymm {k1}{z}, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpabsq ymm_k1z, m256","vpabsq ymm {k1}{z}, ymm/m256/m64bcst")]
    vpabsq_ymm_k1z_m256 = 2035,
    /// <summary>
    /// vpabsq ymm {k1}{z}, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpabsq ymm_k1z, m64bcst","vpabsq ymm {k1}{z}, ymm/m256/m64bcst")]
    vpabsq_ymm_k1z_m64bcst = 2036,
    /// <summary>
    /// vpabsq zmm {k1}{z}, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpabsq zmm, zmm","vpabsq zmm {k1}{z}, zmm/m512/m64bcst")]
    vpabsq_zmm_zmm = 2037,
    /// <summary>
    /// vpabsq zmm {k1}{z}, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpabsq zmm, m512","vpabsq zmm {k1}{z}, zmm/m512/m64bcst")]
    vpabsq_zmm_m512 = 2038,
    /// <summary>
    /// vpabsq zmm {k1}{z}, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpabsq zmm, m64bcst","vpabsq zmm {k1}{z}, zmm/m512/m64bcst")]
    vpabsq_zmm_m64bcst = 2039,
    /// <summary>
    /// vpabsq zmm {k1}{z}, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpabsq zmm_k1z, zmm","vpabsq zmm {k1}{z}, zmm/m512/m64bcst")]
    vpabsq_zmm_k1z_zmm = 2040,
    /// <summary>
    /// vpabsq zmm {k1}{z}, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpabsq zmm_k1z, m512","vpabsq zmm {k1}{z}, zmm/m512/m64bcst")]
    vpabsq_zmm_k1z_m512 = 2041,
    /// <summary>
    /// vpabsq zmm {k1}{z}, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpabsq zmm_k1z, m64bcst","vpabsq zmm {k1}{z}, zmm/m512/m64bcst")]
    vpabsq_zmm_k1z_m64bcst = 2042,
    /// <summary>
    /// vpabsw xmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vpabsw xmm, xmm","vpabsw xmm {k1}{z}, xmm/m128")]
    vpabsw_xmm_xmm = 2043,
    /// <summary>
    /// vpabsw xmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vpabsw xmm, m128","vpabsw xmm {k1}{z}, xmm/m128")]
    vpabsw_xmm_m128 = 2044,
    /// <summary>
    /// vpabsw xmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vpabsw xmm_k1z, xmm","vpabsw xmm {k1}{z}, xmm/m128")]
    vpabsw_xmm_k1z_xmm = 2045,
    /// <summary>
    /// vpabsw xmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vpabsw xmm_k1z, m128","vpabsw xmm {k1}{z}, xmm/m128")]
    vpabsw_xmm_k1z_m128 = 2046,
    /// <summary>
    /// vpabsw ymm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vpabsw ymm, ymm","vpabsw ymm {k1}{z}, ymm/m256")]
    vpabsw_ymm_ymm = 2047,
    /// <summary>
    /// vpabsw ymm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vpabsw ymm, m256","vpabsw ymm {k1}{z}, ymm/m256")]
    vpabsw_ymm_m256 = 2048,
    /// <summary>
    /// vpabsw ymm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vpabsw ymm_k1z, ymm","vpabsw ymm {k1}{z}, ymm/m256")]
    vpabsw_ymm_k1z_ymm = 2049,
    /// <summary>
    /// vpabsw ymm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vpabsw ymm_k1z, m256","vpabsw ymm {k1}{z}, ymm/m256")]
    vpabsw_ymm_k1z_m256 = 2050,
    /// <summary>
    /// vpabsw zmm {k1}{z}, zmm/m512
    /// </summary>
    [Symbol("vpabsw zmm, zmm","vpabsw zmm {k1}{z}, zmm/m512")]
    vpabsw_zmm_zmm = 2051,
    /// <summary>
    /// vpabsw zmm {k1}{z}, zmm/m512
    /// </summary>
    [Symbol("vpabsw zmm, m512","vpabsw zmm {k1}{z}, zmm/m512")]
    vpabsw_zmm_m512 = 2052,
    /// <summary>
    /// vpabsw zmm {k1}{z}, zmm/m512
    /// </summary>
    [Symbol("vpabsw zmm_k1z, zmm","vpabsw zmm {k1}{z}, zmm/m512")]
    vpabsw_zmm_k1z_zmm = 2053,
    /// <summary>
    /// vpabsw zmm {k1}{z}, zmm/m512
    /// </summary>
    [Symbol("vpabsw zmm_k1z, m512","vpabsw zmm {k1}{z}, zmm/m512")]
    vpabsw_zmm_k1z_m512 = 2054,
    /// <summary>
    /// vpackssdw xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpackssdw xmm, xmm, xmm","vpackssdw xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpackssdw_xmm_xmm_xmm = 2055,
    /// <summary>
    /// vpackssdw xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpackssdw xmm, xmm, m128","vpackssdw xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpackssdw_xmm_xmm_m128 = 2056,
    /// <summary>
    /// vpackssdw xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpackssdw xmm, xmm, m32bcst","vpackssdw xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpackssdw_xmm_xmm_m32bcst = 2057,
    /// <summary>
    /// vpackssdw xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpackssdw xmm_k1z, xmm, xmm","vpackssdw xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpackssdw_xmm_k1z_xmm_xmm = 2058,
    /// <summary>
    /// vpackssdw xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpackssdw xmm_k1z, xmm, m128","vpackssdw xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpackssdw_xmm_k1z_xmm_m128 = 2059,
    /// <summary>
    /// vpackssdw xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpackssdw xmm_k1z, xmm, m32bcst","vpackssdw xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpackssdw_xmm_k1z_xmm_m32bcst = 2060,
    /// <summary>
    /// vpackssdw ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpackssdw ymm, ymm, ymm","vpackssdw ymm, ymm, ymm/m256")]
    vpackssdw_ymm_ymm_ymm = 2061,
    /// <summary>
    /// vpackssdw ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpackssdw ymm, ymm, m256","vpackssdw ymm, ymm, ymm/m256")]
    vpackssdw_ymm_ymm_m256 = 2062,
    /// <summary>
    /// vpacksswb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpacksswb xmm, xmm, xmm","vpacksswb xmm {k1}{z}, xmm, xmm/m128")]
    vpacksswb_xmm_xmm_xmm = 2063,
    /// <summary>
    /// vpacksswb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpacksswb xmm, xmm, m128","vpacksswb xmm {k1}{z}, xmm, xmm/m128")]
    vpacksswb_xmm_xmm_m128 = 2064,
    /// <summary>
    /// vpacksswb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpacksswb xmm_k1z, xmm, xmm","vpacksswb xmm {k1}{z}, xmm, xmm/m128")]
    vpacksswb_xmm_k1z_xmm_xmm = 2065,
    /// <summary>
    /// vpacksswb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpacksswb xmm_k1z, xmm, m128","vpacksswb xmm {k1}{z}, xmm, xmm/m128")]
    vpacksswb_xmm_k1z_xmm_m128 = 2066,
    /// <summary>
    /// vpacksswb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpacksswb ymm, ymm, ymm","vpacksswb ymm {k1}{z}, ymm, ymm/m256")]
    vpacksswb_ymm_ymm_ymm = 2067,
    /// <summary>
    /// vpacksswb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpacksswb ymm, ymm, m256","vpacksswb ymm {k1}{z}, ymm, ymm/m256")]
    vpacksswb_ymm_ymm_m256 = 2068,
    /// <summary>
    /// vpacksswb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpacksswb ymm_k1z, ymm, ymm","vpacksswb ymm {k1}{z}, ymm, ymm/m256")]
    vpacksswb_ymm_k1z_ymm_ymm = 2069,
    /// <summary>
    /// vpacksswb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpacksswb ymm_k1z, ymm, m256","vpacksswb ymm {k1}{z}, ymm, ymm/m256")]
    vpacksswb_ymm_k1z_ymm_m256 = 2070,
    /// <summary>
    /// vpacksswb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpacksswb zmm, zmm, zmm","vpacksswb zmm {k1}{z}, zmm, zmm/m512")]
    vpacksswb_zmm_zmm_zmm = 2071,
    /// <summary>
    /// vpacksswb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpacksswb zmm, zmm, m512","vpacksswb zmm {k1}{z}, zmm, zmm/m512")]
    vpacksswb_zmm_zmm_m512 = 2072,
    /// <summary>
    /// vpacksswb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpacksswb zmm_k1z, zmm, zmm","vpacksswb zmm {k1}{z}, zmm, zmm/m512")]
    vpacksswb_zmm_k1z_zmm_zmm = 2073,
    /// <summary>
    /// vpacksswb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpacksswb zmm_k1z, zmm, m512","vpacksswb zmm {k1}{z}, zmm, zmm/m512")]
    vpacksswb_zmm_k1z_zmm_m512 = 2074,
    /// <summary>
    /// vpackusdw xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpackusdw xmm, xmm, xmm","vpackusdw xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpackusdw_xmm_xmm_xmm = 2075,
    /// <summary>
    /// vpackusdw xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpackusdw xmm, xmm, m128","vpackusdw xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpackusdw_xmm_xmm_m128 = 2076,
    /// <summary>
    /// vpackusdw xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpackusdw xmm, xmm, m32bcst","vpackusdw xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpackusdw_xmm_xmm_m32bcst = 2077,
    /// <summary>
    /// vpackusdw xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpackusdw xmm_k1z, xmm, xmm","vpackusdw xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpackusdw_xmm_k1z_xmm_xmm = 2078,
    /// <summary>
    /// vpackusdw xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpackusdw xmm_k1z, xmm, m128","vpackusdw xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpackusdw_xmm_k1z_xmm_m128 = 2079,
    /// <summary>
    /// vpackusdw xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpackusdw xmm_k1z, xmm, m32bcst","vpackusdw xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpackusdw_xmm_k1z_xmm_m32bcst = 2080,
    /// <summary>
    /// vpackusdw ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpackusdw ymm, ymm, ymm","vpackusdw ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpackusdw_ymm_ymm_ymm = 2081,
    /// <summary>
    /// vpackusdw ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpackusdw ymm, ymm, m256","vpackusdw ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpackusdw_ymm_ymm_m256 = 2082,
    /// <summary>
    /// vpackusdw ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpackusdw ymm, ymm, m32bcst","vpackusdw ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpackusdw_ymm_ymm_m32bcst = 2083,
    /// <summary>
    /// vpackusdw ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpackusdw ymm_k1z, ymm, ymm","vpackusdw ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpackusdw_ymm_k1z_ymm_ymm = 2084,
    /// <summary>
    /// vpackusdw ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpackusdw ymm_k1z, ymm, m256","vpackusdw ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpackusdw_ymm_k1z_ymm_m256 = 2085,
    /// <summary>
    /// vpackusdw ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpackusdw ymm_k1z, ymm, m32bcst","vpackusdw ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpackusdw_ymm_k1z_ymm_m32bcst = 2086,
    /// <summary>
    /// vpackusdw zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpackusdw zmm, zmm, zmm","vpackusdw zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpackusdw_zmm_zmm_zmm = 2087,
    /// <summary>
    /// vpackusdw zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpackusdw zmm, zmm, m512","vpackusdw zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpackusdw_zmm_zmm_m512 = 2088,
    /// <summary>
    /// vpackusdw zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpackusdw zmm, zmm, m32bcst","vpackusdw zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpackusdw_zmm_zmm_m32bcst = 2089,
    /// <summary>
    /// vpackusdw zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpackusdw zmm_k1z, zmm, zmm","vpackusdw zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpackusdw_zmm_k1z_zmm_zmm = 2090,
    /// <summary>
    /// vpackusdw zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpackusdw zmm_k1z, zmm, m512","vpackusdw zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpackusdw_zmm_k1z_zmm_m512 = 2091,
    /// <summary>
    /// vpackusdw zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpackusdw zmm_k1z, zmm, m32bcst","vpackusdw zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpackusdw_zmm_k1z_zmm_m32bcst = 2092,
    /// <summary>
    /// vpackuswb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpackuswb xmm, xmm, xmm","vpackuswb xmm {k1}{z}, xmm, xmm/m128")]
    vpackuswb_xmm_xmm_xmm = 2093,
    /// <summary>
    /// vpackuswb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpackuswb xmm, xmm, m128","vpackuswb xmm {k1}{z}, xmm, xmm/m128")]
    vpackuswb_xmm_xmm_m128 = 2094,
    /// <summary>
    /// vpackuswb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpackuswb xmm_k1z, xmm, xmm","vpackuswb xmm {k1}{z}, xmm, xmm/m128")]
    vpackuswb_xmm_k1z_xmm_xmm = 2095,
    /// <summary>
    /// vpackuswb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpackuswb xmm_k1z, xmm, m128","vpackuswb xmm {k1}{z}, xmm, xmm/m128")]
    vpackuswb_xmm_k1z_xmm_m128 = 2096,
    /// <summary>
    /// vpackuswb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpackuswb ymm, ymm, ymm","vpackuswb ymm {k1}{z}, ymm, ymm/m256")]
    vpackuswb_ymm_ymm_ymm = 2097,
    /// <summary>
    /// vpackuswb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpackuswb ymm, ymm, m256","vpackuswb ymm {k1}{z}, ymm, ymm/m256")]
    vpackuswb_ymm_ymm_m256 = 2098,
    /// <summary>
    /// vpackuswb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpackuswb ymm_k1z, ymm, ymm","vpackuswb ymm {k1}{z}, ymm, ymm/m256")]
    vpackuswb_ymm_k1z_ymm_ymm = 2099,
    /// <summary>
    /// vpackuswb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpackuswb ymm_k1z, ymm, m256","vpackuswb ymm {k1}{z}, ymm, ymm/m256")]
    vpackuswb_ymm_k1z_ymm_m256 = 2100,
    /// <summary>
    /// vpackuswb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpackuswb zmm, zmm, zmm","vpackuswb zmm {k1}{z}, zmm, zmm/m512")]
    vpackuswb_zmm_zmm_zmm = 2101,
    /// <summary>
    /// vpackuswb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpackuswb zmm, zmm, m512","vpackuswb zmm {k1}{z}, zmm, zmm/m512")]
    vpackuswb_zmm_zmm_m512 = 2102,
    /// <summary>
    /// vpackuswb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpackuswb zmm_k1z, zmm, zmm","vpackuswb zmm {k1}{z}, zmm, zmm/m512")]
    vpackuswb_zmm_k1z_zmm_zmm = 2103,
    /// <summary>
    /// vpackuswb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpackuswb zmm_k1z, zmm, m512","vpackuswb zmm {k1}{z}, zmm, zmm/m512")]
    vpackuswb_zmm_k1z_zmm_m512 = 2104,
    /// <summary>
    /// vpaddb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpaddb xmm, xmm, xmm","vpaddb xmm {k1}{z}, xmm, xmm/m128")]
    vpaddb_xmm_xmm_xmm = 2105,
    /// <summary>
    /// vpaddb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpaddb xmm, xmm, m128","vpaddb xmm {k1}{z}, xmm, xmm/m128")]
    vpaddb_xmm_xmm_m128 = 2106,
    /// <summary>
    /// vpaddb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpaddb xmm_k1z, xmm, xmm","vpaddb xmm {k1}{z}, xmm, xmm/m128")]
    vpaddb_xmm_k1z_xmm_xmm = 2107,
    /// <summary>
    /// vpaddb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpaddb xmm_k1z, xmm, m128","vpaddb xmm {k1}{z}, xmm, xmm/m128")]
    vpaddb_xmm_k1z_xmm_m128 = 2108,
    /// <summary>
    /// vpaddb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpaddb ymm, ymm, ymm","vpaddb ymm {k1}{z}, ymm, ymm/m256")]
    vpaddb_ymm_ymm_ymm = 2109,
    /// <summary>
    /// vpaddb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpaddb ymm, ymm, m256","vpaddb ymm {k1}{z}, ymm, ymm/m256")]
    vpaddb_ymm_ymm_m256 = 2110,
    /// <summary>
    /// vpaddb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpaddb ymm_k1z, ymm, ymm","vpaddb ymm {k1}{z}, ymm, ymm/m256")]
    vpaddb_ymm_k1z_ymm_ymm = 2111,
    /// <summary>
    /// vpaddb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpaddb ymm_k1z, ymm, m256","vpaddb ymm {k1}{z}, ymm, ymm/m256")]
    vpaddb_ymm_k1z_ymm_m256 = 2112,
    /// <summary>
    /// vpaddb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpaddb zmm, zmm, zmm","vpaddb zmm {k1}{z}, zmm, zmm/m512")]
    vpaddb_zmm_zmm_zmm = 2113,
    /// <summary>
    /// vpaddb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpaddb zmm, zmm, m512","vpaddb zmm {k1}{z}, zmm, zmm/m512")]
    vpaddb_zmm_zmm_m512 = 2114,
    /// <summary>
    /// vpaddb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpaddb zmm_k1z, zmm, zmm","vpaddb zmm {k1}{z}, zmm, zmm/m512")]
    vpaddb_zmm_k1z_zmm_zmm = 2115,
    /// <summary>
    /// vpaddb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpaddb zmm_k1z, zmm, m512","vpaddb zmm {k1}{z}, zmm, zmm/m512")]
    vpaddb_zmm_k1z_zmm_m512 = 2116,
    /// <summary>
    /// vpaddd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpaddd xmm, xmm, xmm","vpaddd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpaddd_xmm_xmm_xmm = 2117,
    /// <summary>
    /// vpaddd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpaddd xmm, xmm, m128","vpaddd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpaddd_xmm_xmm_m128 = 2118,
    /// <summary>
    /// vpaddd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpaddd xmm, xmm, m32bcst","vpaddd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpaddd_xmm_xmm_m32bcst = 2119,
    /// <summary>
    /// vpaddd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpaddd xmm_k1z, xmm, xmm","vpaddd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpaddd_xmm_k1z_xmm_xmm = 2120,
    /// <summary>
    /// vpaddd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpaddd xmm_k1z, xmm, m128","vpaddd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpaddd_xmm_k1z_xmm_m128 = 2121,
    /// <summary>
    /// vpaddd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpaddd xmm_k1z, xmm, m32bcst","vpaddd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpaddd_xmm_k1z_xmm_m32bcst = 2122,
    /// <summary>
    /// vpaddd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpaddd ymm, ymm, ymm","vpaddd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpaddd_ymm_ymm_ymm = 2123,
    /// <summary>
    /// vpaddd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpaddd ymm, ymm, m256","vpaddd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpaddd_ymm_ymm_m256 = 2124,
    /// <summary>
    /// vpaddd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpaddd ymm, ymm, m32bcst","vpaddd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpaddd_ymm_ymm_m32bcst = 2125,
    /// <summary>
    /// vpaddd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpaddd ymm_k1z, ymm, ymm","vpaddd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpaddd_ymm_k1z_ymm_ymm = 2126,
    /// <summary>
    /// vpaddd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpaddd ymm_k1z, ymm, m256","vpaddd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpaddd_ymm_k1z_ymm_m256 = 2127,
    /// <summary>
    /// vpaddd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpaddd ymm_k1z, ymm, m32bcst","vpaddd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpaddd_ymm_k1z_ymm_m32bcst = 2128,
    /// <summary>
    /// vpaddd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpaddd zmm, zmm, zmm","vpaddd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpaddd_zmm_zmm_zmm = 2129,
    /// <summary>
    /// vpaddd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpaddd zmm, zmm, m512","vpaddd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpaddd_zmm_zmm_m512 = 2130,
    /// <summary>
    /// vpaddd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpaddd zmm, zmm, m32bcst","vpaddd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpaddd_zmm_zmm_m32bcst = 2131,
    /// <summary>
    /// vpaddd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpaddd zmm_k1z, zmm, zmm","vpaddd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpaddd_zmm_k1z_zmm_zmm = 2132,
    /// <summary>
    /// vpaddd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpaddd zmm_k1z, zmm, m512","vpaddd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpaddd_zmm_k1z_zmm_m512 = 2133,
    /// <summary>
    /// vpaddd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpaddd zmm_k1z, zmm, m32bcst","vpaddd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpaddd_zmm_k1z_zmm_m32bcst = 2134,
    /// <summary>
    /// vpaddq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpaddq xmm, xmm, xmm","vpaddq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpaddq_xmm_xmm_xmm = 2135,
    /// <summary>
    /// vpaddq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpaddq xmm, xmm, m128","vpaddq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpaddq_xmm_xmm_m128 = 2136,
    /// <summary>
    /// vpaddq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpaddq xmm, xmm, m64bcst","vpaddq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpaddq_xmm_xmm_m64bcst = 2137,
    /// <summary>
    /// vpaddq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpaddq xmm_k1z, xmm, xmm","vpaddq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpaddq_xmm_k1z_xmm_xmm = 2138,
    /// <summary>
    /// vpaddq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpaddq xmm_k1z, xmm, m128","vpaddq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpaddq_xmm_k1z_xmm_m128 = 2139,
    /// <summary>
    /// vpaddq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpaddq xmm_k1z, xmm, m64bcst","vpaddq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpaddq_xmm_k1z_xmm_m64bcst = 2140,
    /// <summary>
    /// vpaddq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpaddq ymm, ymm, ymm","vpaddq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpaddq_ymm_ymm_ymm = 2141,
    /// <summary>
    /// vpaddq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpaddq ymm, ymm, m256","vpaddq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpaddq_ymm_ymm_m256 = 2142,
    /// <summary>
    /// vpaddq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpaddq ymm, ymm, m64bcst","vpaddq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpaddq_ymm_ymm_m64bcst = 2143,
    /// <summary>
    /// vpaddq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpaddq ymm_k1z, ymm, ymm","vpaddq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpaddq_ymm_k1z_ymm_ymm = 2144,
    /// <summary>
    /// vpaddq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpaddq ymm_k1z, ymm, m256","vpaddq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpaddq_ymm_k1z_ymm_m256 = 2145,
    /// <summary>
    /// vpaddq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpaddq ymm_k1z, ymm, m64bcst","vpaddq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpaddq_ymm_k1z_ymm_m64bcst = 2146,
    /// <summary>
    /// vpaddq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpaddq zmm, zmm, zmm","vpaddq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpaddq_zmm_zmm_zmm = 2147,
    /// <summary>
    /// vpaddq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpaddq zmm, zmm, m512","vpaddq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpaddq_zmm_zmm_m512 = 2148,
    /// <summary>
    /// vpaddq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpaddq zmm, zmm, m64bcst","vpaddq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpaddq_zmm_zmm_m64bcst = 2149,
    /// <summary>
    /// vpaddq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpaddq zmm_k1z, zmm, zmm","vpaddq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpaddq_zmm_k1z_zmm_zmm = 2150,
    /// <summary>
    /// vpaddq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpaddq zmm_k1z, zmm, m512","vpaddq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpaddq_zmm_k1z_zmm_m512 = 2151,
    /// <summary>
    /// vpaddq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpaddq zmm_k1z, zmm, m64bcst","vpaddq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpaddq_zmm_k1z_zmm_m64bcst = 2152,
    /// <summary>
    /// vpaddsb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpaddsb xmm, xmm, xmm","vpaddsb xmm {k1}{z}, xmm, xmm/m128")]
    vpaddsb_xmm_xmm_xmm = 2153,
    /// <summary>
    /// vpaddsb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpaddsb xmm, xmm, m128","vpaddsb xmm {k1}{z}, xmm, xmm/m128")]
    vpaddsb_xmm_xmm_m128 = 2154,
    /// <summary>
    /// vpaddsb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpaddsb xmm_k1z, xmm, xmm","vpaddsb xmm {k1}{z}, xmm, xmm/m128")]
    vpaddsb_xmm_k1z_xmm_xmm = 2155,
    /// <summary>
    /// vpaddsb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpaddsb xmm_k1z, xmm, m128","vpaddsb xmm {k1}{z}, xmm, xmm/m128")]
    vpaddsb_xmm_k1z_xmm_m128 = 2156,
    /// <summary>
    /// vpaddsb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpaddsb ymm, ymm, ymm","vpaddsb ymm {k1}{z}, ymm, ymm/m256")]
    vpaddsb_ymm_ymm_ymm = 2157,
    /// <summary>
    /// vpaddsb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpaddsb ymm, ymm, m256","vpaddsb ymm {k1}{z}, ymm, ymm/m256")]
    vpaddsb_ymm_ymm_m256 = 2158,
    /// <summary>
    /// vpaddsb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpaddsb ymm_k1z, ymm, ymm","vpaddsb ymm {k1}{z}, ymm, ymm/m256")]
    vpaddsb_ymm_k1z_ymm_ymm = 2159,
    /// <summary>
    /// vpaddsb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpaddsb ymm_k1z, ymm, m256","vpaddsb ymm {k1}{z}, ymm, ymm/m256")]
    vpaddsb_ymm_k1z_ymm_m256 = 2160,
    /// <summary>
    /// vpaddsb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpaddsb zmm, zmm, zmm","vpaddsb zmm {k1}{z}, zmm, zmm/m512")]
    vpaddsb_zmm_zmm_zmm = 2161,
    /// <summary>
    /// vpaddsb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpaddsb zmm, zmm, m512","vpaddsb zmm {k1}{z}, zmm, zmm/m512")]
    vpaddsb_zmm_zmm_m512 = 2162,
    /// <summary>
    /// vpaddsb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpaddsb zmm_k1z, zmm, zmm","vpaddsb zmm {k1}{z}, zmm, zmm/m512")]
    vpaddsb_zmm_k1z_zmm_zmm = 2163,
    /// <summary>
    /// vpaddsb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpaddsb zmm_k1z, zmm, m512","vpaddsb zmm {k1}{z}, zmm, zmm/m512")]
    vpaddsb_zmm_k1z_zmm_m512 = 2164,
    /// <summary>
    /// vpaddsw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpaddsw xmm, xmm, xmm","vpaddsw xmm {k1}{z}, xmm, xmm/m128")]
    vpaddsw_xmm_xmm_xmm = 2165,
    /// <summary>
    /// vpaddsw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpaddsw xmm, xmm, m128","vpaddsw xmm {k1}{z}, xmm, xmm/m128")]
    vpaddsw_xmm_xmm_m128 = 2166,
    /// <summary>
    /// vpaddsw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpaddsw xmm_k1z, xmm, xmm","vpaddsw xmm {k1}{z}, xmm, xmm/m128")]
    vpaddsw_xmm_k1z_xmm_xmm = 2167,
    /// <summary>
    /// vpaddsw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpaddsw xmm_k1z, xmm, m128","vpaddsw xmm {k1}{z}, xmm, xmm/m128")]
    vpaddsw_xmm_k1z_xmm_m128 = 2168,
    /// <summary>
    /// vpaddsw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpaddsw ymm, ymm, ymm","vpaddsw ymm {k1}{z}, ymm, ymm/m256")]
    vpaddsw_ymm_ymm_ymm = 2169,
    /// <summary>
    /// vpaddsw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpaddsw ymm, ymm, m256","vpaddsw ymm {k1}{z}, ymm, ymm/m256")]
    vpaddsw_ymm_ymm_m256 = 2170,
    /// <summary>
    /// vpaddsw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpaddsw ymm_k1z, ymm, ymm","vpaddsw ymm {k1}{z}, ymm, ymm/m256")]
    vpaddsw_ymm_k1z_ymm_ymm = 2171,
    /// <summary>
    /// vpaddsw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpaddsw ymm_k1z, ymm, m256","vpaddsw ymm {k1}{z}, ymm, ymm/m256")]
    vpaddsw_ymm_k1z_ymm_m256 = 2172,
    /// <summary>
    /// vpaddsw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpaddsw zmm, zmm, zmm","vpaddsw zmm {k1}{z}, zmm, zmm/m512")]
    vpaddsw_zmm_zmm_zmm = 2173,
    /// <summary>
    /// vpaddsw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpaddsw zmm, zmm, m512","vpaddsw zmm {k1}{z}, zmm, zmm/m512")]
    vpaddsw_zmm_zmm_m512 = 2174,
    /// <summary>
    /// vpaddsw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpaddsw zmm_k1z, zmm, zmm","vpaddsw zmm {k1}{z}, zmm, zmm/m512")]
    vpaddsw_zmm_k1z_zmm_zmm = 2175,
    /// <summary>
    /// vpaddsw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpaddsw zmm_k1z, zmm, m512","vpaddsw zmm {k1}{z}, zmm, zmm/m512")]
    vpaddsw_zmm_k1z_zmm_m512 = 2176,
    /// <summary>
    /// vpaddusb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpaddusb xmm, xmm, xmm","vpaddusb xmm {k1}{z}, xmm, xmm/m128")]
    vpaddusb_xmm_xmm_xmm = 2177,
    /// <summary>
    /// vpaddusb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpaddusb xmm, xmm, m128","vpaddusb xmm {k1}{z}, xmm, xmm/m128")]
    vpaddusb_xmm_xmm_m128 = 2178,
    /// <summary>
    /// vpaddusb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpaddusb xmm_k1z, xmm, xmm","vpaddusb xmm {k1}{z}, xmm, xmm/m128")]
    vpaddusb_xmm_k1z_xmm_xmm = 2179,
    /// <summary>
    /// vpaddusb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpaddusb xmm_k1z, xmm, m128","vpaddusb xmm {k1}{z}, xmm, xmm/m128")]
    vpaddusb_xmm_k1z_xmm_m128 = 2180,
    /// <summary>
    /// vpaddusb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpaddusb ymm, ymm, ymm","vpaddusb ymm {k1}{z}, ymm, ymm/m256")]
    vpaddusb_ymm_ymm_ymm = 2181,
    /// <summary>
    /// vpaddusb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpaddusb ymm, ymm, m256","vpaddusb ymm {k1}{z}, ymm, ymm/m256")]
    vpaddusb_ymm_ymm_m256 = 2182,
    /// <summary>
    /// vpaddusb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpaddusb ymm_k1z, ymm, ymm","vpaddusb ymm {k1}{z}, ymm, ymm/m256")]
    vpaddusb_ymm_k1z_ymm_ymm = 2183,
    /// <summary>
    /// vpaddusb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpaddusb ymm_k1z, ymm, m256","vpaddusb ymm {k1}{z}, ymm, ymm/m256")]
    vpaddusb_ymm_k1z_ymm_m256 = 2184,
    /// <summary>
    /// vpaddusb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpaddusb zmm, zmm, zmm","vpaddusb zmm {k1}{z}, zmm, zmm/m512")]
    vpaddusb_zmm_zmm_zmm = 2185,
    /// <summary>
    /// vpaddusb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpaddusb zmm, zmm, m512","vpaddusb zmm {k1}{z}, zmm, zmm/m512")]
    vpaddusb_zmm_zmm_m512 = 2186,
    /// <summary>
    /// vpaddusb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpaddusb zmm_k1z, zmm, zmm","vpaddusb zmm {k1}{z}, zmm, zmm/m512")]
    vpaddusb_zmm_k1z_zmm_zmm = 2187,
    /// <summary>
    /// vpaddusb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpaddusb zmm_k1z, zmm, m512","vpaddusb zmm {k1}{z}, zmm, zmm/m512")]
    vpaddusb_zmm_k1z_zmm_m512 = 2188,
    /// <summary>
    /// vpaddusw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpaddusw xmm, xmm, xmm","vpaddusw xmm {k1}{z}, xmm, xmm/m128")]
    vpaddusw_xmm_xmm_xmm = 2189,
    /// <summary>
    /// vpaddusw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpaddusw xmm, xmm, m128","vpaddusw xmm {k1}{z}, xmm, xmm/m128")]
    vpaddusw_xmm_xmm_m128 = 2190,
    /// <summary>
    /// vpaddusw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpaddusw xmm_k1z, xmm, xmm","vpaddusw xmm {k1}{z}, xmm, xmm/m128")]
    vpaddusw_xmm_k1z_xmm_xmm = 2191,
    /// <summary>
    /// vpaddusw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpaddusw xmm_k1z, xmm, m128","vpaddusw xmm {k1}{z}, xmm, xmm/m128")]
    vpaddusw_xmm_k1z_xmm_m128 = 2192,
    /// <summary>
    /// vpaddusw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpaddusw ymm, ymm, ymm","vpaddusw ymm {k1}{z}, ymm, ymm/m256")]
    vpaddusw_ymm_ymm_ymm = 2193,
    /// <summary>
    /// vpaddusw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpaddusw ymm, ymm, m256","vpaddusw ymm {k1}{z}, ymm, ymm/m256")]
    vpaddusw_ymm_ymm_m256 = 2194,
    /// <summary>
    /// vpaddusw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpaddusw ymm_k1z, ymm, ymm","vpaddusw ymm {k1}{z}, ymm, ymm/m256")]
    vpaddusw_ymm_k1z_ymm_ymm = 2195,
    /// <summary>
    /// vpaddusw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpaddusw ymm_k1z, ymm, m256","vpaddusw ymm {k1}{z}, ymm, ymm/m256")]
    vpaddusw_ymm_k1z_ymm_m256 = 2196,
    /// <summary>
    /// vpaddw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpaddw xmm, xmm, xmm","vpaddw xmm {k1}{z}, xmm, xmm/m128")]
    vpaddw_xmm_xmm_xmm = 2197,
    /// <summary>
    /// vpaddw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpaddw xmm, xmm, m128","vpaddw xmm {k1}{z}, xmm, xmm/m128")]
    vpaddw_xmm_xmm_m128 = 2198,
    /// <summary>
    /// vpaddw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpaddw xmm_k1z, xmm, xmm","vpaddw xmm {k1}{z}, xmm, xmm/m128")]
    vpaddw_xmm_k1z_xmm_xmm = 2199,
    /// <summary>
    /// vpaddw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpaddw xmm_k1z, xmm, m128","vpaddw xmm {k1}{z}, xmm, xmm/m128")]
    vpaddw_xmm_k1z_xmm_m128 = 2200,
    /// <summary>
    /// vpaddw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpaddw ymm, ymm, ymm","vpaddw ymm {k1}{z}, ymm, ymm/m256")]
    vpaddw_ymm_ymm_ymm = 2201,
    /// <summary>
    /// vpaddw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpaddw ymm, ymm, m256","vpaddw ymm {k1}{z}, ymm, ymm/m256")]
    vpaddw_ymm_ymm_m256 = 2202,
    /// <summary>
    /// vpaddw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpaddw ymm_k1z, ymm, ymm","vpaddw ymm {k1}{z}, ymm, ymm/m256")]
    vpaddw_ymm_k1z_ymm_ymm = 2203,
    /// <summary>
    /// vpaddw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpaddw ymm_k1z, ymm, m256","vpaddw ymm {k1}{z}, ymm, ymm/m256")]
    vpaddw_ymm_k1z_ymm_m256 = 2204,
    /// <summary>
    /// vpaddw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpaddw zmm, zmm, zmm","vpaddw zmm {k1}{z}, zmm, zmm/m512")]
    vpaddw_zmm_zmm_zmm = 2205,
    /// <summary>
    /// vpaddw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpaddw zmm, zmm, m512","vpaddw zmm {k1}{z}, zmm, zmm/m512")]
    vpaddw_zmm_zmm_m512 = 2206,
    /// <summary>
    /// vpaddw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpaddw zmm_k1z, zmm, zmm","vpaddw zmm {k1}{z}, zmm, zmm/m512")]
    vpaddw_zmm_k1z_zmm_zmm = 2207,
    /// <summary>
    /// vpaddw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpaddw zmm_k1z, zmm, m512","vpaddw zmm {k1}{z}, zmm, zmm/m512")]
    vpaddw_zmm_k1z_zmm_m512 = 2208,
    /// <summary>
    /// vpand xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpand xmm, xmm, xmm","vpand xmm, xmm, xmm/m128")]
    vpand_xmm_xmm_xmm = 2209,
    /// <summary>
    /// vpand xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpand xmm, xmm, m128","vpand xmm, xmm, xmm/m128")]
    vpand_xmm_xmm_m128 = 2210,
    /// <summary>
    /// vpand ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpand ymm, ymm, ymm","vpand ymm, ymm, ymm/m256")]
    vpand_ymm_ymm_ymm = 2211,
    /// <summary>
    /// vpand ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpand ymm, ymm, m256","vpand ymm, ymm, ymm/m256")]
    vpand_ymm_ymm_m256 = 2212,
    /// <summary>
    /// vpandd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpandd xmm, xmm, xmm","vpandd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpandd_xmm_xmm_xmm = 2213,
    /// <summary>
    /// vpandd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpandd xmm, xmm, m128","vpandd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpandd_xmm_xmm_m128 = 2214,
    /// <summary>
    /// vpandd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpandd xmm, xmm, m32bcst","vpandd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpandd_xmm_xmm_m32bcst = 2215,
    /// <summary>
    /// vpandd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpandd xmm_k1z, xmm, xmm","vpandd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpandd_xmm_k1z_xmm_xmm = 2216,
    /// <summary>
    /// vpandd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpandd xmm_k1z, xmm, m128","vpandd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpandd_xmm_k1z_xmm_m128 = 2217,
    /// <summary>
    /// vpandd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpandd xmm_k1z, xmm, m32bcst","vpandd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpandd_xmm_k1z_xmm_m32bcst = 2218,
    /// <summary>
    /// vpandd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpandd ymm, ymm, ymm","vpandd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpandd_ymm_ymm_ymm = 2219,
    /// <summary>
    /// vpandd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpandd ymm, ymm, m256","vpandd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpandd_ymm_ymm_m256 = 2220,
    /// <summary>
    /// vpandd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpandd ymm, ymm, m32bcst","vpandd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpandd_ymm_ymm_m32bcst = 2221,
    /// <summary>
    /// vpandd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpandd ymm_k1z, ymm, ymm","vpandd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpandd_ymm_k1z_ymm_ymm = 2222,
    /// <summary>
    /// vpandd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpandd ymm_k1z, ymm, m256","vpandd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpandd_ymm_k1z_ymm_m256 = 2223,
    /// <summary>
    /// vpandd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpandd ymm_k1z, ymm, m32bcst","vpandd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpandd_ymm_k1z_ymm_m32bcst = 2224,
    /// <summary>
    /// vpandd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpandd zmm, zmm, zmm","vpandd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpandd_zmm_zmm_zmm = 2225,
    /// <summary>
    /// vpandd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpandd zmm, zmm, m512","vpandd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpandd_zmm_zmm_m512 = 2226,
    /// <summary>
    /// vpandd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpandd zmm, zmm, m32bcst","vpandd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpandd_zmm_zmm_m32bcst = 2227,
    /// <summary>
    /// vpandd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpandd zmm_k1z, zmm, zmm","vpandd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpandd_zmm_k1z_zmm_zmm = 2228,
    /// <summary>
    /// vpandd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpandd zmm_k1z, zmm, m512","vpandd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpandd_zmm_k1z_zmm_m512 = 2229,
    /// <summary>
    /// vpandd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpandd zmm_k1z, zmm, m32bcst","vpandd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpandd_zmm_k1z_zmm_m32bcst = 2230,
    /// <summary>
    /// vpandn xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpandn xmm, xmm, xmm","vpandn xmm, xmm, xmm/m128")]
    vpandn_xmm_xmm_xmm = 2231,
    /// <summary>
    /// vpandn xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpandn xmm, xmm, m128","vpandn xmm, xmm, xmm/m128")]
    vpandn_xmm_xmm_m128 = 2232,
    /// <summary>
    /// vpandn ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpandn ymm, ymm, ymm","vpandn ymm, ymm, ymm/m256")]
    vpandn_ymm_ymm_ymm = 2233,
    /// <summary>
    /// vpandn ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpandn ymm, ymm, m256","vpandn ymm, ymm, ymm/m256")]
    vpandn_ymm_ymm_m256 = 2234,
    /// <summary>
    /// vpandnd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpandnd xmm, xmm, xmm","vpandnd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpandnd_xmm_xmm_xmm = 2235,
    /// <summary>
    /// vpandnd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpandnd xmm, xmm, m128","vpandnd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpandnd_xmm_xmm_m128 = 2236,
    /// <summary>
    /// vpandnd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpandnd xmm, xmm, m32bcst","vpandnd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpandnd_xmm_xmm_m32bcst = 2237,
    /// <summary>
    /// vpandnd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpandnd xmm_k1z, xmm, xmm","vpandnd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpandnd_xmm_k1z_xmm_xmm = 2238,
    /// <summary>
    /// vpandnd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpandnd xmm_k1z, xmm, m128","vpandnd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpandnd_xmm_k1z_xmm_m128 = 2239,
    /// <summary>
    /// vpandnd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpandnd xmm_k1z, xmm, m32bcst","vpandnd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpandnd_xmm_k1z_xmm_m32bcst = 2240,
    /// <summary>
    /// vpandnd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpandnd ymm, ymm, ymm","vpandnd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpandnd_ymm_ymm_ymm = 2241,
    /// <summary>
    /// vpandnd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpandnd ymm, ymm, m256","vpandnd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpandnd_ymm_ymm_m256 = 2242,
    /// <summary>
    /// vpandnd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpandnd ymm, ymm, m32bcst","vpandnd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpandnd_ymm_ymm_m32bcst = 2243,
    /// <summary>
    /// vpandnd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpandnd ymm_k1z, ymm, ymm","vpandnd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpandnd_ymm_k1z_ymm_ymm = 2244,
    /// <summary>
    /// vpandnd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpandnd ymm_k1z, ymm, m256","vpandnd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpandnd_ymm_k1z_ymm_m256 = 2245,
    /// <summary>
    /// vpandnd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpandnd ymm_k1z, ymm, m32bcst","vpandnd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpandnd_ymm_k1z_ymm_m32bcst = 2246,
    /// <summary>
    /// vpandnd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpandnd zmm, zmm, zmm","vpandnd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpandnd_zmm_zmm_zmm = 2247,
    /// <summary>
    /// vpandnd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpandnd zmm, zmm, m512","vpandnd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpandnd_zmm_zmm_m512 = 2248,
    /// <summary>
    /// vpandnd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpandnd zmm, zmm, m32bcst","vpandnd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpandnd_zmm_zmm_m32bcst = 2249,
    /// <summary>
    /// vpandnd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpandnd zmm_k1z, zmm, zmm","vpandnd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpandnd_zmm_k1z_zmm_zmm = 2250,
    /// <summary>
    /// vpandnd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpandnd zmm_k1z, zmm, m512","vpandnd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpandnd_zmm_k1z_zmm_m512 = 2251,
    /// <summary>
    /// vpandnd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpandnd zmm_k1z, zmm, m32bcst","vpandnd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpandnd_zmm_k1z_zmm_m32bcst = 2252,
    /// <summary>
    /// vpandnq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpandnq xmm, xmm, xmm","vpandnq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpandnq_xmm_xmm_xmm = 2253,
    /// <summary>
    /// vpandnq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpandnq xmm, xmm, m128","vpandnq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpandnq_xmm_xmm_m128 = 2254,
    /// <summary>
    /// vpandnq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpandnq xmm, xmm, m64bcst","vpandnq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpandnq_xmm_xmm_m64bcst = 2255,
    /// <summary>
    /// vpandnq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpandnq xmm_k1z, xmm, xmm","vpandnq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpandnq_xmm_k1z_xmm_xmm = 2256,
    /// <summary>
    /// vpandnq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpandnq xmm_k1z, xmm, m128","vpandnq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpandnq_xmm_k1z_xmm_m128 = 2257,
    /// <summary>
    /// vpandnq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpandnq xmm_k1z, xmm, m64bcst","vpandnq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpandnq_xmm_k1z_xmm_m64bcst = 2258,
    /// <summary>
    /// vpandnq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpandnq ymm, ymm, ymm","vpandnq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpandnq_ymm_ymm_ymm = 2259,
    /// <summary>
    /// vpandnq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpandnq ymm, ymm, m256","vpandnq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpandnq_ymm_ymm_m256 = 2260,
    /// <summary>
    /// vpandnq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpandnq ymm, ymm, m64bcst","vpandnq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpandnq_ymm_ymm_m64bcst = 2261,
    /// <summary>
    /// vpandnq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpandnq ymm_k1z, ymm, ymm","vpandnq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpandnq_ymm_k1z_ymm_ymm = 2262,
    /// <summary>
    /// vpandnq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpandnq ymm_k1z, ymm, m256","vpandnq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpandnq_ymm_k1z_ymm_m256 = 2263,
    /// <summary>
    /// vpandnq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpandnq ymm_k1z, ymm, m64bcst","vpandnq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpandnq_ymm_k1z_ymm_m64bcst = 2264,
    /// <summary>
    /// vpandnq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpandnq zmm, zmm, zmm","vpandnq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpandnq_zmm_zmm_zmm = 2265,
    /// <summary>
    /// vpandnq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpandnq zmm, zmm, m512","vpandnq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpandnq_zmm_zmm_m512 = 2266,
    /// <summary>
    /// vpandnq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpandnq zmm, zmm, m64bcst","vpandnq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpandnq_zmm_zmm_m64bcst = 2267,
    /// <summary>
    /// vpandnq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpandnq zmm_k1z, zmm, zmm","vpandnq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpandnq_zmm_k1z_zmm_zmm = 2268,
    /// <summary>
    /// vpandnq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpandnq zmm_k1z, zmm, m512","vpandnq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpandnq_zmm_k1z_zmm_m512 = 2269,
    /// <summary>
    /// vpandnq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpandnq zmm_k1z, zmm, m64bcst","vpandnq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpandnq_zmm_k1z_zmm_m64bcst = 2270,
    /// <summary>
    /// vpandq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpandq xmm, xmm, xmm","vpandq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpandq_xmm_xmm_xmm = 2271,
    /// <summary>
    /// vpandq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpandq xmm, xmm, m128","vpandq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpandq_xmm_xmm_m128 = 2272,
    /// <summary>
    /// vpandq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpandq xmm, xmm, m64bcst","vpandq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpandq_xmm_xmm_m64bcst = 2273,
    /// <summary>
    /// vpandq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpandq xmm_k1z, xmm, xmm","vpandq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpandq_xmm_k1z_xmm_xmm = 2274,
    /// <summary>
    /// vpandq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpandq xmm_k1z, xmm, m128","vpandq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpandq_xmm_k1z_xmm_m128 = 2275,
    /// <summary>
    /// vpandq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpandq xmm_k1z, xmm, m64bcst","vpandq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpandq_xmm_k1z_xmm_m64bcst = 2276,
    /// <summary>
    /// vpandq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpandq ymm, ymm, ymm","vpandq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpandq_ymm_ymm_ymm = 2277,
    /// <summary>
    /// vpandq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpandq ymm, ymm, m256","vpandq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpandq_ymm_ymm_m256 = 2278,
    /// <summary>
    /// vpandq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpandq ymm, ymm, m64bcst","vpandq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpandq_ymm_ymm_m64bcst = 2279,
    /// <summary>
    /// vpandq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpandq ymm_k1z, ymm, ymm","vpandq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpandq_ymm_k1z_ymm_ymm = 2280,
    /// <summary>
    /// vpandq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpandq ymm_k1z, ymm, m256","vpandq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpandq_ymm_k1z_ymm_m256 = 2281,
    /// <summary>
    /// vpandq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpandq ymm_k1z, ymm, m64bcst","vpandq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpandq_ymm_k1z_ymm_m64bcst = 2282,
    /// <summary>
    /// vpandq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpandq zmm, zmm, zmm","vpandq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpandq_zmm_zmm_zmm = 2283,
    /// <summary>
    /// vpandq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpandq zmm, zmm, m512","vpandq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpandq_zmm_zmm_m512 = 2284,
    /// <summary>
    /// vpandq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpandq zmm, zmm, m64bcst","vpandq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpandq_zmm_zmm_m64bcst = 2285,
    /// <summary>
    /// vpandq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpandq zmm_k1z, zmm, zmm","vpandq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpandq_zmm_k1z_zmm_zmm = 2286,
    /// <summary>
    /// vpandq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpandq zmm_k1z, zmm, m512","vpandq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpandq_zmm_k1z_zmm_m512 = 2287,
    /// <summary>
    /// vpandq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpandq zmm_k1z, zmm, m64bcst","vpandq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpandq_zmm_k1z_zmm_m64bcst = 2288,
    /// <summary>
    /// vpavgb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpavgb xmm, xmm, xmm","vpavgb xmm {k1}{z}, xmm, xmm/m128")]
    vpavgb_xmm_xmm_xmm = 2289,
    /// <summary>
    /// vpavgb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpavgb xmm, xmm, m128","vpavgb xmm {k1}{z}, xmm, xmm/m128")]
    vpavgb_xmm_xmm_m128 = 2290,
    /// <summary>
    /// vpavgb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpavgb xmm_k1z, xmm, xmm","vpavgb xmm {k1}{z}, xmm, xmm/m128")]
    vpavgb_xmm_k1z_xmm_xmm = 2291,
    /// <summary>
    /// vpavgb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpavgb xmm_k1z, xmm, m128","vpavgb xmm {k1}{z}, xmm, xmm/m128")]
    vpavgb_xmm_k1z_xmm_m128 = 2292,
    /// <summary>
    /// vpavgb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpavgb ymm, ymm, ymm","vpavgb ymm {k1}{z}, ymm, ymm/m256")]
    vpavgb_ymm_ymm_ymm = 2293,
    /// <summary>
    /// vpavgb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpavgb ymm, ymm, m256","vpavgb ymm {k1}{z}, ymm, ymm/m256")]
    vpavgb_ymm_ymm_m256 = 2294,
    /// <summary>
    /// vpavgb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpavgb ymm_k1z, ymm, ymm","vpavgb ymm {k1}{z}, ymm, ymm/m256")]
    vpavgb_ymm_k1z_ymm_ymm = 2295,
    /// <summary>
    /// vpavgb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpavgb ymm_k1z, ymm, m256","vpavgb ymm {k1}{z}, ymm, ymm/m256")]
    vpavgb_ymm_k1z_ymm_m256 = 2296,
    /// <summary>
    /// vpavgb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpavgb zmm, zmm, zmm","vpavgb zmm {k1}{z}, zmm, zmm/m512")]
    vpavgb_zmm_zmm_zmm = 2297,
    /// <summary>
    /// vpavgb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpavgb zmm, zmm, m512","vpavgb zmm {k1}{z}, zmm, zmm/m512")]
    vpavgb_zmm_zmm_m512 = 2298,
    /// <summary>
    /// vpavgb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpavgb zmm_k1z, zmm, zmm","vpavgb zmm {k1}{z}, zmm, zmm/m512")]
    vpavgb_zmm_k1z_zmm_zmm = 2299,
    /// <summary>
    /// vpavgb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpavgb zmm_k1z, zmm, m512","vpavgb zmm {k1}{z}, zmm, zmm/m512")]
    vpavgb_zmm_k1z_zmm_m512 = 2300,
    /// <summary>
    /// vpavgw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpavgw xmm, xmm, xmm","vpavgw xmm {k1}{z}, xmm, xmm/m128")]
    vpavgw_xmm_xmm_xmm = 2301,
    /// <summary>
    /// vpavgw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpavgw xmm, xmm, m128","vpavgw xmm {k1}{z}, xmm, xmm/m128")]
    vpavgw_xmm_xmm_m128 = 2302,
    /// <summary>
    /// vpavgw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpavgw xmm_k1z, xmm, xmm","vpavgw xmm {k1}{z}, xmm, xmm/m128")]
    vpavgw_xmm_k1z_xmm_xmm = 2303,
    /// <summary>
    /// vpavgw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpavgw xmm_k1z, xmm, m128","vpavgw xmm {k1}{z}, xmm, xmm/m128")]
    vpavgw_xmm_k1z_xmm_m128 = 2304,
    /// <summary>
    /// vpavgw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpavgw ymm, ymm, ymm","vpavgw ymm {k1}{z}, ymm, ymm/m256")]
    vpavgw_ymm_ymm_ymm = 2305,
    /// <summary>
    /// vpavgw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpavgw ymm, ymm, m256","vpavgw ymm {k1}{z}, ymm, ymm/m256")]
    vpavgw_ymm_ymm_m256 = 2306,
    /// <summary>
    /// vpavgw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpavgw ymm_k1z, ymm, ymm","vpavgw ymm {k1}{z}, ymm, ymm/m256")]
    vpavgw_ymm_k1z_ymm_ymm = 2307,
    /// <summary>
    /// vpavgw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpavgw ymm_k1z, ymm, m256","vpavgw ymm {k1}{z}, ymm, ymm/m256")]
    vpavgw_ymm_k1z_ymm_m256 = 2308,
    /// <summary>
    /// vpavgw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpavgw zmm, zmm, zmm","vpavgw zmm {k1}{z}, zmm, zmm/m512")]
    vpavgw_zmm_zmm_zmm = 2309,
    /// <summary>
    /// vpavgw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpavgw zmm, zmm, m512","vpavgw zmm {k1}{z}, zmm, zmm/m512")]
    vpavgw_zmm_zmm_m512 = 2310,
    /// <summary>
    /// vpavgw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpavgw zmm_k1z, zmm, zmm","vpavgw zmm {k1}{z}, zmm, zmm/m512")]
    vpavgw_zmm_k1z_zmm_zmm = 2311,
    /// <summary>
    /// vpavgw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpavgw zmm_k1z, zmm, m512","vpavgw zmm {k1}{z}, zmm, zmm/m512")]
    vpavgw_zmm_k1z_zmm_m512 = 2312,
    /// <summary>
    /// vpblendmb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpblendmb xmm, xmm, xmm","vpblendmb xmm {k1}{z}, xmm, xmm/m128")]
    vpblendmb_xmm_xmm_xmm = 2313,
    /// <summary>
    /// vpblendmb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpblendmb xmm, xmm, m128","vpblendmb xmm {k1}{z}, xmm, xmm/m128")]
    vpblendmb_xmm_xmm_m128 = 2314,
    /// <summary>
    /// vpblendmb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpblendmb xmm_k1z, xmm, xmm","vpblendmb xmm {k1}{z}, xmm, xmm/m128")]
    vpblendmb_xmm_k1z_xmm_xmm = 2315,
    /// <summary>
    /// vpblendmb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpblendmb xmm_k1z, xmm, m128","vpblendmb xmm {k1}{z}, xmm, xmm/m128")]
    vpblendmb_xmm_k1z_xmm_m128 = 2316,
    /// <summary>
    /// vpblendmb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpblendmb ymm, ymm, ymm","vpblendmb ymm {k1}{z}, ymm, ymm/m256")]
    vpblendmb_ymm_ymm_ymm = 2317,
    /// <summary>
    /// vpblendmb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpblendmb ymm, ymm, m256","vpblendmb ymm {k1}{z}, ymm, ymm/m256")]
    vpblendmb_ymm_ymm_m256 = 2318,
    /// <summary>
    /// vpblendmb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpblendmb ymm_k1z, ymm, ymm","vpblendmb ymm {k1}{z}, ymm, ymm/m256")]
    vpblendmb_ymm_k1z_ymm_ymm = 2319,
    /// <summary>
    /// vpblendmb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpblendmb ymm_k1z, ymm, m256","vpblendmb ymm {k1}{z}, ymm, ymm/m256")]
    vpblendmb_ymm_k1z_ymm_m256 = 2320,
    /// <summary>
    /// vpblendmb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpblendmb zmm, zmm, zmm","vpblendmb zmm {k1}{z}, zmm, zmm/m512")]
    vpblendmb_zmm_zmm_zmm = 2321,
    /// <summary>
    /// vpblendmb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpblendmb zmm, zmm, m512","vpblendmb zmm {k1}{z}, zmm, zmm/m512")]
    vpblendmb_zmm_zmm_m512 = 2322,
    /// <summary>
    /// vpblendmb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpblendmb zmm_k1z, zmm, zmm","vpblendmb zmm {k1}{z}, zmm, zmm/m512")]
    vpblendmb_zmm_k1z_zmm_zmm = 2323,
    /// <summary>
    /// vpblendmb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpblendmb zmm_k1z, zmm, m512","vpblendmb zmm {k1}{z}, zmm, zmm/m512")]
    vpblendmb_zmm_k1z_zmm_m512 = 2324,
    /// <summary>
    /// vpblendmd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpblendmd xmm, xmm, xmm","vpblendmd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpblendmd_xmm_xmm_xmm = 2325,
    /// <summary>
    /// vpblendmd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpblendmd xmm, xmm, m128","vpblendmd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpblendmd_xmm_xmm_m128 = 2326,
    /// <summary>
    /// vpblendmd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpblendmd xmm, xmm, m32bcst","vpblendmd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpblendmd_xmm_xmm_m32bcst = 2327,
    /// <summary>
    /// vpblendmd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpblendmd xmm_k1z, xmm, xmm","vpblendmd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpblendmd_xmm_k1z_xmm_xmm = 2328,
    /// <summary>
    /// vpblendmd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpblendmd xmm_k1z, xmm, m128","vpblendmd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpblendmd_xmm_k1z_xmm_m128 = 2329,
    /// <summary>
    /// vpblendmd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpblendmd xmm_k1z, xmm, m32bcst","vpblendmd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpblendmd_xmm_k1z_xmm_m32bcst = 2330,
    /// <summary>
    /// vpblendmd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpblendmd ymm, ymm, ymm","vpblendmd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpblendmd_ymm_ymm_ymm = 2331,
    /// <summary>
    /// vpblendmd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpblendmd ymm, ymm, m256","vpblendmd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpblendmd_ymm_ymm_m256 = 2332,
    /// <summary>
    /// vpblendmd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpblendmd ymm, ymm, m32bcst","vpblendmd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpblendmd_ymm_ymm_m32bcst = 2333,
    /// <summary>
    /// vpblendmd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpblendmd ymm_k1z, ymm, ymm","vpblendmd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpblendmd_ymm_k1z_ymm_ymm = 2334,
    /// <summary>
    /// vpblendmd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpblendmd ymm_k1z, ymm, m256","vpblendmd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpblendmd_ymm_k1z_ymm_m256 = 2335,
    /// <summary>
    /// vpblendmd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpblendmd ymm_k1z, ymm, m32bcst","vpblendmd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpblendmd_ymm_k1z_ymm_m32bcst = 2336,
    /// <summary>
    /// vpblendmd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpblendmd zmm, zmm, zmm","vpblendmd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpblendmd_zmm_zmm_zmm = 2337,
    /// <summary>
    /// vpblendmd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpblendmd zmm, zmm, m512","vpblendmd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpblendmd_zmm_zmm_m512 = 2338,
    /// <summary>
    /// vpblendmd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpblendmd zmm, zmm, m32bcst","vpblendmd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpblendmd_zmm_zmm_m32bcst = 2339,
    /// <summary>
    /// vpblendmd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpblendmd zmm_k1z, zmm, zmm","vpblendmd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpblendmd_zmm_k1z_zmm_zmm = 2340,
    /// <summary>
    /// vpblendmd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpblendmd zmm_k1z, zmm, m512","vpblendmd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpblendmd_zmm_k1z_zmm_m512 = 2341,
    /// <summary>
    /// vpblendmd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpblendmd zmm_k1z, zmm, m32bcst","vpblendmd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpblendmd_zmm_k1z_zmm_m32bcst = 2342,
    /// <summary>
    /// vpblendmq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpblendmq xmm, xmm, xmm","vpblendmq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpblendmq_xmm_xmm_xmm = 2343,
    /// <summary>
    /// vpblendmq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpblendmq xmm, xmm, m128","vpblendmq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpblendmq_xmm_xmm_m128 = 2344,
    /// <summary>
    /// vpblendmq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpblendmq xmm, xmm, m64bcst","vpblendmq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpblendmq_xmm_xmm_m64bcst = 2345,
    /// <summary>
    /// vpblendmq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpblendmq xmm_k1z, xmm, xmm","vpblendmq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpblendmq_xmm_k1z_xmm_xmm = 2346,
    /// <summary>
    /// vpblendmq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpblendmq xmm_k1z, xmm, m128","vpblendmq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpblendmq_xmm_k1z_xmm_m128 = 2347,
    /// <summary>
    /// vpblendmq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpblendmq xmm_k1z, xmm, m64bcst","vpblendmq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpblendmq_xmm_k1z_xmm_m64bcst = 2348,
    /// <summary>
    /// vpblendmq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpblendmq ymm, ymm, ymm","vpblendmq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpblendmq_ymm_ymm_ymm = 2349,
    /// <summary>
    /// vpblendmq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpblendmq ymm, ymm, m256","vpblendmq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpblendmq_ymm_ymm_m256 = 2350,
    /// <summary>
    /// vpblendmq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpblendmq ymm, ymm, m64bcst","vpblendmq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpblendmq_ymm_ymm_m64bcst = 2351,
    /// <summary>
    /// vpblendmq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpblendmq ymm_k1z, ymm, ymm","vpblendmq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpblendmq_ymm_k1z_ymm_ymm = 2352,
    /// <summary>
    /// vpblendmq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpblendmq ymm_k1z, ymm, m256","vpblendmq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpblendmq_ymm_k1z_ymm_m256 = 2353,
    /// <summary>
    /// vpblendmq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpblendmq ymm_k1z, ymm, m64bcst","vpblendmq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpblendmq_ymm_k1z_ymm_m64bcst = 2354,
    /// <summary>
    /// vpblendmq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpblendmq zmm, zmm, zmm","vpblendmq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpblendmq_zmm_zmm_zmm = 2355,
    /// <summary>
    /// vpblendmq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpblendmq zmm, zmm, m512","vpblendmq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpblendmq_zmm_zmm_m512 = 2356,
    /// <summary>
    /// vpblendmq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpblendmq zmm, zmm, m64bcst","vpblendmq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpblendmq_zmm_zmm_m64bcst = 2357,
    /// <summary>
    /// vpblendmq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpblendmq zmm_k1z, zmm, zmm","vpblendmq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpblendmq_zmm_k1z_zmm_zmm = 2358,
    /// <summary>
    /// vpblendmq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpblendmq zmm_k1z, zmm, m512","vpblendmq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpblendmq_zmm_k1z_zmm_m512 = 2359,
    /// <summary>
    /// vpblendmq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpblendmq zmm_k1z, zmm, m64bcst","vpblendmq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpblendmq_zmm_k1z_zmm_m64bcst = 2360,
    /// <summary>
    /// vpblendmw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpblendmw xmm, xmm, xmm","vpblendmw xmm {k1}{z}, xmm, xmm/m128")]
    vpblendmw_xmm_xmm_xmm = 2361,
    /// <summary>
    /// vpblendmw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpblendmw xmm, xmm, m128","vpblendmw xmm {k1}{z}, xmm, xmm/m128")]
    vpblendmw_xmm_xmm_m128 = 2362,
    /// <summary>
    /// vpblendmw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpblendmw xmm_k1z, xmm, xmm","vpblendmw xmm {k1}{z}, xmm, xmm/m128")]
    vpblendmw_xmm_k1z_xmm_xmm = 2363,
    /// <summary>
    /// vpblendmw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpblendmw xmm_k1z, xmm, m128","vpblendmw xmm {k1}{z}, xmm, xmm/m128")]
    vpblendmw_xmm_k1z_xmm_m128 = 2364,
    /// <summary>
    /// vpblendmw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpblendmw ymm, ymm, ymm","vpblendmw ymm {k1}{z}, ymm, ymm/m256")]
    vpblendmw_ymm_ymm_ymm = 2365,
    /// <summary>
    /// vpblendmw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpblendmw ymm, ymm, m256","vpblendmw ymm {k1}{z}, ymm, ymm/m256")]
    vpblendmw_ymm_ymm_m256 = 2366,
    /// <summary>
    /// vpblendmw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpblendmw ymm_k1z, ymm, ymm","vpblendmw ymm {k1}{z}, ymm, ymm/m256")]
    vpblendmw_ymm_k1z_ymm_ymm = 2367,
    /// <summary>
    /// vpblendmw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpblendmw ymm_k1z, ymm, m256","vpblendmw ymm {k1}{z}, ymm, ymm/m256")]
    vpblendmw_ymm_k1z_ymm_m256 = 2368,
    /// <summary>
    /// vpblendmw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpblendmw zmm, zmm, zmm","vpblendmw zmm {k1}{z}, zmm, zmm/m512")]
    vpblendmw_zmm_zmm_zmm = 2369,
    /// <summary>
    /// vpblendmw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpblendmw zmm, zmm, m512","vpblendmw zmm {k1}{z}, zmm, zmm/m512")]
    vpblendmw_zmm_zmm_m512 = 2370,
    /// <summary>
    /// vpblendmw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpblendmw zmm_k1z, zmm, zmm","vpblendmw zmm {k1}{z}, zmm, zmm/m512")]
    vpblendmw_zmm_k1z_zmm_zmm = 2371,
    /// <summary>
    /// vpblendmw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpblendmw zmm_k1z, zmm, m512","vpblendmw zmm {k1}{z}, zmm, zmm/m512")]
    vpblendmw_zmm_k1z_zmm_m512 = 2372,
    /// <summary>
    /// vpbroadcastb xmm {k1}{z}, xmm/m8
    /// </summary>
    [Symbol("vpbroadcastb xmm, xmm","vpbroadcastb xmm {k1}{z}, xmm/m8")]
    vpbroadcastb_xmm_xmm = 2373,
    /// <summary>
    /// vpbroadcastb xmm {k1}{z}, xmm/m8
    /// </summary>
    [Symbol("vpbroadcastb xmm, m8","vpbroadcastb xmm {k1}{z}, xmm/m8")]
    vpbroadcastb_xmm_m8 = 2374,
    /// <summary>
    /// vpbroadcastb xmm {k1}{z}, xmm/m8
    /// </summary>
    [Symbol("vpbroadcastb xmm_k1z, xmm","vpbroadcastb xmm {k1}{z}, xmm/m8")]
    vpbroadcastb_xmm_k1z_xmm = 2375,
    /// <summary>
    /// vpbroadcastb xmm {k1}{z}, xmm/m8
    /// </summary>
    [Symbol("vpbroadcastb xmm_k1z, m8","vpbroadcastb xmm {k1}{z}, xmm/m8")]
    vpbroadcastb_xmm_k1z_m8 = 2376,
    /// <summary>
    /// vpbroadcastb ymm {k1}{z}, xmm/m8
    /// </summary>
    [Symbol("vpbroadcastb ymm, xmm","vpbroadcastb ymm {k1}{z}, xmm/m8")]
    vpbroadcastb_ymm_xmm = 2377,
    /// <summary>
    /// vpbroadcastb ymm {k1}{z}, xmm/m8
    /// </summary>
    [Symbol("vpbroadcastb ymm, m8","vpbroadcastb ymm {k1}{z}, xmm/m8")]
    vpbroadcastb_ymm_m8 = 2378,
    /// <summary>
    /// vpbroadcastb ymm {k1}{z}, xmm/m8
    /// </summary>
    [Symbol("vpbroadcastb ymm_k1z, xmm","vpbroadcastb ymm {k1}{z}, xmm/m8")]
    vpbroadcastb_ymm_k1z_xmm = 2379,
    /// <summary>
    /// vpbroadcastb ymm {k1}{z}, xmm/m8
    /// </summary>
    [Symbol("vpbroadcastb ymm_k1z, m8","vpbroadcastb ymm {k1}{z}, xmm/m8")]
    vpbroadcastb_ymm_k1z_m8 = 2380,
    /// <summary>
    /// vpbroadcastb zmm {k1}{z}, xmm/m8
    /// </summary>
    [Symbol("vpbroadcastb zmm, xmm","vpbroadcastb zmm {k1}{z}, xmm/m8")]
    vpbroadcastb_zmm_xmm = 2381,
    /// <summary>
    /// vpbroadcastb zmm {k1}{z}, xmm/m8
    /// </summary>
    [Symbol("vpbroadcastb zmm, m8","vpbroadcastb zmm {k1}{z}, xmm/m8")]
    vpbroadcastb_zmm_m8 = 2382,
    /// <summary>
    /// vpbroadcastb zmm {k1}{z}, xmm/m8
    /// </summary>
    [Symbol("vpbroadcastb zmm_k1z, xmm","vpbroadcastb zmm {k1}{z}, xmm/m8")]
    vpbroadcastb_zmm_k1z_xmm = 2383,
    /// <summary>
    /// vpbroadcastb zmm {k1}{z}, xmm/m8
    /// </summary>
    [Symbol("vpbroadcastb zmm_k1z, m8","vpbroadcastb zmm {k1}{z}, xmm/m8")]
    vpbroadcastb_zmm_k1z_m8 = 2384,
    /// <summary>
    /// vpbroadcastd xmm {k1}{z}, xmm/m32
    /// </summary>
    [Symbol("vpbroadcastd xmm, xmm","vpbroadcastd xmm {k1}{z}, xmm/m32")]
    vpbroadcastd_xmm_xmm = 2385,
    /// <summary>
    /// vpbroadcastd xmm {k1}{z}, xmm/m32
    /// </summary>
    [Symbol("vpbroadcastd xmm, m32","vpbroadcastd xmm {k1}{z}, xmm/m32")]
    vpbroadcastd_xmm_m32 = 2386,
    /// <summary>
    /// vpbroadcastd xmm {k1}{z}, xmm/m32
    /// </summary>
    [Symbol("vpbroadcastd xmm_k1z, xmm","vpbroadcastd xmm {k1}{z}, xmm/m32")]
    vpbroadcastd_xmm_k1z_xmm = 2387,
    /// <summary>
    /// vpbroadcastd xmm {k1}{z}, xmm/m32
    /// </summary>
    [Symbol("vpbroadcastd xmm_k1z, m32","vpbroadcastd xmm {k1}{z}, xmm/m32")]
    vpbroadcastd_xmm_k1z_m32 = 2388,
    /// <summary>
    /// vpbroadcastd ymm {k1}{z}, xmm/m32
    /// </summary>
    [Symbol("vpbroadcastd ymm, xmm","vpbroadcastd ymm {k1}{z}, xmm/m32")]
    vpbroadcastd_ymm_xmm = 2389,
    /// <summary>
    /// vpbroadcastd ymm {k1}{z}, xmm/m32
    /// </summary>
    [Symbol("vpbroadcastd ymm, m32","vpbroadcastd ymm {k1}{z}, xmm/m32")]
    vpbroadcastd_ymm_m32 = 2390,
    /// <summary>
    /// vpbroadcastd ymm {k1}{z}, xmm/m32
    /// </summary>
    [Symbol("vpbroadcastd ymm_k1z, xmm","vpbroadcastd ymm {k1}{z}, xmm/m32")]
    vpbroadcastd_ymm_k1z_xmm = 2391,
    /// <summary>
    /// vpbroadcastd ymm {k1}{z}, xmm/m32
    /// </summary>
    [Symbol("vpbroadcastd ymm_k1z, m32","vpbroadcastd ymm {k1}{z}, xmm/m32")]
    vpbroadcastd_ymm_k1z_m32 = 2392,
    /// <summary>
    /// vpbroadcastd zmm {k1}{z}, xmm/m32
    /// </summary>
    [Symbol("vpbroadcastd zmm, xmm","vpbroadcastd zmm {k1}{z}, xmm/m32")]
    vpbroadcastd_zmm_xmm = 2393,
    /// <summary>
    /// vpbroadcastd zmm {k1}{z}, xmm/m32
    /// </summary>
    [Symbol("vpbroadcastd zmm, m32","vpbroadcastd zmm {k1}{z}, xmm/m32")]
    vpbroadcastd_zmm_m32 = 2394,
    /// <summary>
    /// vpbroadcastd zmm {k1}{z}, xmm/m32
    /// </summary>
    [Symbol("vpbroadcastd zmm_k1z, xmm","vpbroadcastd zmm {k1}{z}, xmm/m32")]
    vpbroadcastd_zmm_k1z_xmm = 2395,
    /// <summary>
    /// vpbroadcastd zmm {k1}{z}, xmm/m32
    /// </summary>
    [Symbol("vpbroadcastd zmm_k1z, m32","vpbroadcastd zmm {k1}{z}, xmm/m32")]
    vpbroadcastd_zmm_k1z_m32 = 2396,
    /// <summary>
    /// vpbroadcastmb2q xmm, k
    /// </summary>
    [Symbol("vpbroadcastmb2q xmm, k","vpbroadcastmb2q xmm, k")]
    vpbroadcastmb2q_xmm_k = 2397,
    /// <summary>
    /// vpbroadcastmb2q ymm, k
    /// </summary>
    [Symbol("vpbroadcastmb2q ymm, k","vpbroadcastmb2q ymm, k")]
    vpbroadcastmb2q_ymm_k = 2398,
    /// <summary>
    /// vpbroadcastmb2q zmm, k
    /// </summary>
    [Symbol("vpbroadcastmb2q zmm, k","vpbroadcastmb2q zmm, k")]
    vpbroadcastmb2q_zmm_k = 2399,
    /// <summary>
    /// vpbroadcastmw2d xmm, k
    /// </summary>
    [Symbol("vpbroadcastmw2d xmm, k","vpbroadcastmw2d xmm, k")]
    vpbroadcastmw2d_xmm_k = 2400,
    /// <summary>
    /// vpbroadcastmw2d ymm, k
    /// </summary>
    [Symbol("vpbroadcastmw2d ymm, k","vpbroadcastmw2d ymm, k")]
    vpbroadcastmw2d_ymm_k = 2401,
    /// <summary>
    /// vpbroadcastmw2d zmm, k
    /// </summary>
    [Symbol("vpbroadcastmw2d zmm, k","vpbroadcastmw2d zmm, k")]
    vpbroadcastmw2d_zmm_k = 2402,
    /// <summary>
    /// vpbroadcastq xmm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpbroadcastq xmm, xmm","vpbroadcastq xmm {k1}{z}, xmm/m64")]
    vpbroadcastq_xmm_xmm = 2403,
    /// <summary>
    /// vpbroadcastq xmm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpbroadcastq xmm, m64","vpbroadcastq xmm {k1}{z}, xmm/m64")]
    vpbroadcastq_xmm_m64 = 2404,
    /// <summary>
    /// vpbroadcastq xmm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpbroadcastq xmm_k1z, xmm","vpbroadcastq xmm {k1}{z}, xmm/m64")]
    vpbroadcastq_xmm_k1z_xmm = 2405,
    /// <summary>
    /// vpbroadcastq xmm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpbroadcastq xmm_k1z, m64","vpbroadcastq xmm {k1}{z}, xmm/m64")]
    vpbroadcastq_xmm_k1z_m64 = 2406,
    /// <summary>
    /// vpbroadcastq ymm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpbroadcastq ymm, xmm","vpbroadcastq ymm {k1}{z}, xmm/m64")]
    vpbroadcastq_ymm_xmm = 2407,
    /// <summary>
    /// vpbroadcastq ymm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpbroadcastq ymm, m64","vpbroadcastq ymm {k1}{z}, xmm/m64")]
    vpbroadcastq_ymm_m64 = 2408,
    /// <summary>
    /// vpbroadcastq ymm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpbroadcastq ymm_k1z, xmm","vpbroadcastq ymm {k1}{z}, xmm/m64")]
    vpbroadcastq_ymm_k1z_xmm = 2409,
    /// <summary>
    /// vpbroadcastq ymm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpbroadcastq ymm_k1z, m64","vpbroadcastq ymm {k1}{z}, xmm/m64")]
    vpbroadcastq_ymm_k1z_m64 = 2410,
    /// <summary>
    /// vpbroadcastq zmm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpbroadcastq zmm, xmm","vpbroadcastq zmm {k1}{z}, xmm/m64")]
    vpbroadcastq_zmm_xmm = 2411,
    /// <summary>
    /// vpbroadcastq zmm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpbroadcastq zmm, m64","vpbroadcastq zmm {k1}{z}, xmm/m64")]
    vpbroadcastq_zmm_m64 = 2412,
    /// <summary>
    /// vpbroadcastq zmm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpbroadcastq zmm_k1z, xmm","vpbroadcastq zmm {k1}{z}, xmm/m64")]
    vpbroadcastq_zmm_k1z_xmm = 2413,
    /// <summary>
    /// vpbroadcastq zmm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpbroadcastq zmm_k1z, m64","vpbroadcastq zmm {k1}{z}, xmm/m64")]
    vpbroadcastq_zmm_k1z_m64 = 2414,
    /// <summary>
    /// vpbroadcastw xmm {k1}{z}, xmm/m16
    /// </summary>
    [Symbol("vpbroadcastw xmm, xmm","vpbroadcastw xmm {k1}{z}, xmm/m16")]
    vpbroadcastw_xmm_xmm = 2415,
    /// <summary>
    /// vpbroadcastw xmm {k1}{z}, xmm/m16
    /// </summary>
    [Symbol("vpbroadcastw xmm, m16","vpbroadcastw xmm {k1}{z}, xmm/m16")]
    vpbroadcastw_xmm_m16 = 2416,
    /// <summary>
    /// vpbroadcastw xmm {k1}{z}, xmm/m16
    /// </summary>
    [Symbol("vpbroadcastw xmm_k1z, xmm","vpbroadcastw xmm {k1}{z}, xmm/m16")]
    vpbroadcastw_xmm_k1z_xmm = 2417,
    /// <summary>
    /// vpbroadcastw xmm {k1}{z}, xmm/m16
    /// </summary>
    [Symbol("vpbroadcastw xmm_k1z, m16","vpbroadcastw xmm {k1}{z}, xmm/m16")]
    vpbroadcastw_xmm_k1z_m16 = 2418,
    /// <summary>
    /// vpbroadcastw ymm {k1}{z}, xmm/m16
    /// </summary>
    [Symbol("vpbroadcastw ymm, xmm","vpbroadcastw ymm {k1}{z}, xmm/m16")]
    vpbroadcastw_ymm_xmm = 2419,
    /// <summary>
    /// vpbroadcastw ymm {k1}{z}, xmm/m16
    /// </summary>
    [Symbol("vpbroadcastw ymm, m16","vpbroadcastw ymm {k1}{z}, xmm/m16")]
    vpbroadcastw_ymm_m16 = 2420,
    /// <summary>
    /// vpbroadcastw ymm {k1}{z}, xmm/m16
    /// </summary>
    [Symbol("vpbroadcastw ymm_k1z, xmm","vpbroadcastw ymm {k1}{z}, xmm/m16")]
    vpbroadcastw_ymm_k1z_xmm = 2421,
    /// <summary>
    /// vpbroadcastw ymm {k1}{z}, xmm/m16
    /// </summary>
    [Symbol("vpbroadcastw ymm_k1z, m16","vpbroadcastw ymm {k1}{z}, xmm/m16")]
    vpbroadcastw_ymm_k1z_m16 = 2422,
    /// <summary>
    /// vpbroadcastw zmm {k1}{z}, xmm/m16
    /// </summary>
    [Symbol("vpbroadcastw zmm, xmm","vpbroadcastw zmm {k1}{z}, xmm/m16")]
    vpbroadcastw_zmm_xmm = 2423,
    /// <summary>
    /// vpbroadcastw zmm {k1}{z}, xmm/m16
    /// </summary>
    [Symbol("vpbroadcastw zmm, m16","vpbroadcastw zmm {k1}{z}, xmm/m16")]
    vpbroadcastw_zmm_m16 = 2424,
    /// <summary>
    /// vpbroadcastw zmm {k1}{z}, xmm/m16
    /// </summary>
    [Symbol("vpbroadcastw zmm_k1z, xmm","vpbroadcastw zmm {k1}{z}, xmm/m16")]
    vpbroadcastw_zmm_k1z_xmm = 2425,
    /// <summary>
    /// vpbroadcastw zmm {k1}{z}, xmm/m16
    /// </summary>
    [Symbol("vpbroadcastw zmm_k1z, m16","vpbroadcastw zmm {k1}{z}, xmm/m16")]
    vpbroadcastw_zmm_k1z_m16 = 2426,
    /// <summary>
    /// vpcmpb k1 {k2}, xmm, xmm/m128, imm8
    /// </summary>
    [Symbol("vpcmpb k1, xmm, xmm, imm8","vpcmpb k1 {k2}, xmm, xmm/m128, imm8")]
    vpcmpb_k1_xmm_xmm_imm8 = 2427,
    /// <summary>
    /// vpcmpb k1 {k2}, xmm, xmm/m128, imm8
    /// </summary>
    [Symbol("vpcmpb k1, xmm, m128, imm8","vpcmpb k1 {k2}, xmm, xmm/m128, imm8")]
    vpcmpb_k1_xmm_m128_imm8 = 2428,
    /// <summary>
    /// vpcmpb k1 {k2}, xmm, xmm/m128, imm8
    /// </summary>
    [Symbol("vpcmpb k12, xmm, xmm, imm8","vpcmpb k1 {k2}, xmm, xmm/m128, imm8")]
    vpcmpb_k12_xmm_xmm_imm8 = 2429,
    /// <summary>
    /// vpcmpb k1 {k2}, xmm, xmm/m128, imm8
    /// </summary>
    [Symbol("vpcmpb k12, xmm, m128, imm8","vpcmpb k1 {k2}, xmm, xmm/m128, imm8")]
    vpcmpb_k12_xmm_m128_imm8 = 2430,
    /// <summary>
    /// vpcmpb k1 {k2}, ymm, ymm/m256, imm8
    /// </summary>
    [Symbol("vpcmpb k1, ymm, ymm, imm8","vpcmpb k1 {k2}, ymm, ymm/m256, imm8")]
    vpcmpb_k1_ymm_ymm_imm8 = 2431,
    /// <summary>
    /// vpcmpb k1 {k2}, ymm, ymm/m256, imm8
    /// </summary>
    [Symbol("vpcmpb k1, ymm, m256, imm8","vpcmpb k1 {k2}, ymm, ymm/m256, imm8")]
    vpcmpb_k1_ymm_m256_imm8 = 2432,
    /// <summary>
    /// vpcmpb k1 {k2}, ymm, ymm/m256, imm8
    /// </summary>
    [Symbol("vpcmpb k12, ymm, ymm, imm8","vpcmpb k1 {k2}, ymm, ymm/m256, imm8")]
    vpcmpb_k12_ymm_ymm_imm8 = 2433,
    /// <summary>
    /// vpcmpb k1 {k2}, ymm, ymm/m256, imm8
    /// </summary>
    [Symbol("vpcmpb k12, ymm, m256, imm8","vpcmpb k1 {k2}, ymm, ymm/m256, imm8")]
    vpcmpb_k12_ymm_m256_imm8 = 2434,
    /// <summary>
    /// vpcmpb k1 {k2}, zmm, zmm/m512, imm8
    /// </summary>
    [Symbol("vpcmpb k1, zmm, zmm, imm8","vpcmpb k1 {k2}, zmm, zmm/m512, imm8")]
    vpcmpb_k1_zmm_zmm_imm8 = 2435,
    /// <summary>
    /// vpcmpb k1 {k2}, zmm, zmm/m512, imm8
    /// </summary>
    [Symbol("vpcmpb k1, zmm, m512, imm8","vpcmpb k1 {k2}, zmm, zmm/m512, imm8")]
    vpcmpb_k1_zmm_m512_imm8 = 2436,
    /// <summary>
    /// vpcmpb k1 {k2}, zmm, zmm/m512, imm8
    /// </summary>
    [Symbol("vpcmpb k12, zmm, zmm, imm8","vpcmpb k1 {k2}, zmm, zmm/m512, imm8")]
    vpcmpb_k12_zmm_zmm_imm8 = 2437,
    /// <summary>
    /// vpcmpb k1 {k2}, zmm, zmm/m512, imm8
    /// </summary>
    [Symbol("vpcmpb k12, zmm, m512, imm8","vpcmpb k1 {k2}, zmm, zmm/m512, imm8")]
    vpcmpb_k12_zmm_m512_imm8 = 2438,
    /// <summary>
    /// vpcmpd k1 {k2}, xmm, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vpcmpd k1, xmm, xmm, imm8","vpcmpd k1 {k2}, xmm, xmm/m128/m32bcst, imm8")]
    vpcmpd_k1_xmm_xmm_imm8 = 2439,
    /// <summary>
    /// vpcmpd k1 {k2}, xmm, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vpcmpd k1, xmm, m128, imm8","vpcmpd k1 {k2}, xmm, xmm/m128/m32bcst, imm8")]
    vpcmpd_k1_xmm_m128_imm8 = 2440,
    /// <summary>
    /// vpcmpd k1 {k2}, xmm, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vpcmpd k1, xmm, m32bcst, imm8","vpcmpd k1 {k2}, xmm, xmm/m128/m32bcst, imm8")]
    vpcmpd_k1_xmm_m32bcst_imm8 = 2441,
    /// <summary>
    /// vpcmpd k1 {k2}, xmm, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vpcmpd k12, xmm, xmm, imm8","vpcmpd k1 {k2}, xmm, xmm/m128/m32bcst, imm8")]
    vpcmpd_k12_xmm_xmm_imm8 = 2442,
    /// <summary>
    /// vpcmpd k1 {k2}, xmm, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vpcmpd k12, xmm, m128, imm8","vpcmpd k1 {k2}, xmm, xmm/m128/m32bcst, imm8")]
    vpcmpd_k12_xmm_m128_imm8 = 2443,
    /// <summary>
    /// vpcmpd k1 {k2}, xmm, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vpcmpd k12, xmm, m32bcst, imm8","vpcmpd k1 {k2}, xmm, xmm/m128/m32bcst, imm8")]
    vpcmpd_k12_xmm_m32bcst_imm8 = 2444,
    /// <summary>
    /// vpcmpd k1 {k2}, ymm, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vpcmpd k1, ymm, ymm, imm8","vpcmpd k1 {k2}, ymm, ymm/m256/m32bcst, imm8")]
    vpcmpd_k1_ymm_ymm_imm8 = 2445,
    /// <summary>
    /// vpcmpd k1 {k2}, ymm, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vpcmpd k1, ymm, m256, imm8","vpcmpd k1 {k2}, ymm, ymm/m256/m32bcst, imm8")]
    vpcmpd_k1_ymm_m256_imm8 = 2446,
    /// <summary>
    /// vpcmpd k1 {k2}, ymm, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vpcmpd k1, ymm, m32bcst, imm8","vpcmpd k1 {k2}, ymm, ymm/m256/m32bcst, imm8")]
    vpcmpd_k1_ymm_m32bcst_imm8 = 2447,
    /// <summary>
    /// vpcmpd k1 {k2}, ymm, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vpcmpd k12, ymm, ymm, imm8","vpcmpd k1 {k2}, ymm, ymm/m256/m32bcst, imm8")]
    vpcmpd_k12_ymm_ymm_imm8 = 2448,
    /// <summary>
    /// vpcmpd k1 {k2}, ymm, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vpcmpd k12, ymm, m256, imm8","vpcmpd k1 {k2}, ymm, ymm/m256/m32bcst, imm8")]
    vpcmpd_k12_ymm_m256_imm8 = 2449,
    /// <summary>
    /// vpcmpd k1 {k2}, ymm, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vpcmpd k12, ymm, m32bcst, imm8","vpcmpd k1 {k2}, ymm, ymm/m256/m32bcst, imm8")]
    vpcmpd_k12_ymm_m32bcst_imm8 = 2450,
    /// <summary>
    /// vpcmpd k1 {k2}, zmm, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vpcmpd k1, zmm, zmm, imm8","vpcmpd k1 {k2}, zmm, zmm/m512/m32bcst, imm8")]
    vpcmpd_k1_zmm_zmm_imm8 = 2451,
    /// <summary>
    /// vpcmpd k1 {k2}, zmm, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vpcmpd k1, zmm, m512, imm8","vpcmpd k1 {k2}, zmm, zmm/m512/m32bcst, imm8")]
    vpcmpd_k1_zmm_m512_imm8 = 2452,
    /// <summary>
    /// vpcmpd k1 {k2}, zmm, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vpcmpd k1, zmm, m32bcst, imm8","vpcmpd k1 {k2}, zmm, zmm/m512/m32bcst, imm8")]
    vpcmpd_k1_zmm_m32bcst_imm8 = 2453,
    /// <summary>
    /// vpcmpd k1 {k2}, zmm, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vpcmpd k12, zmm, zmm, imm8","vpcmpd k1 {k2}, zmm, zmm/m512/m32bcst, imm8")]
    vpcmpd_k12_zmm_zmm_imm8 = 2454,
    /// <summary>
    /// vpcmpd k1 {k2}, zmm, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vpcmpd k12, zmm, m512, imm8","vpcmpd k1 {k2}, zmm, zmm/m512/m32bcst, imm8")]
    vpcmpd_k12_zmm_m512_imm8 = 2455,
    /// <summary>
    /// vpcmpd k1 {k2}, zmm, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vpcmpd k12, zmm, m32bcst, imm8","vpcmpd k1 {k2}, zmm, zmm/m512/m32bcst, imm8")]
    vpcmpd_k12_zmm_m32bcst_imm8 = 2456,
    /// <summary>
    /// vpcmpeqb k1 {k2}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpcmpeqb k1, xmm, xmm","vpcmpeqb k1 {k2}, xmm, xmm/m128")]
    vpcmpeqb_k1_xmm_xmm = 2457,
    /// <summary>
    /// vpcmpeqb k1 {k2}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpcmpeqb k1, xmm, m128","vpcmpeqb k1 {k2}, xmm, xmm/m128")]
    vpcmpeqb_k1_xmm_m128 = 2458,
    /// <summary>
    /// vpcmpeqb k1 {k2}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpcmpeqb k12, xmm, xmm","vpcmpeqb k1 {k2}, xmm, xmm/m128")]
    vpcmpeqb_k12_xmm_xmm = 2459,
    /// <summary>
    /// vpcmpeqb k1 {k2}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpcmpeqb k12, xmm, m128","vpcmpeqb k1 {k2}, xmm, xmm/m128")]
    vpcmpeqb_k12_xmm_m128 = 2460,
    /// <summary>
    /// vpcmpeqb k1 {k2}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpcmpeqb k1, ymm, ymm","vpcmpeqb k1 {k2}, ymm, ymm/m256")]
    vpcmpeqb_k1_ymm_ymm = 2461,
    /// <summary>
    /// vpcmpeqb k1 {k2}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpcmpeqb k1, ymm, m256","vpcmpeqb k1 {k2}, ymm, ymm/m256")]
    vpcmpeqb_k1_ymm_m256 = 2462,
    /// <summary>
    /// vpcmpeqb k1 {k2}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpcmpeqb k12, ymm, ymm","vpcmpeqb k1 {k2}, ymm, ymm/m256")]
    vpcmpeqb_k12_ymm_ymm = 2463,
    /// <summary>
    /// vpcmpeqb k1 {k2}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpcmpeqb k12, ymm, m256","vpcmpeqb k1 {k2}, ymm, ymm/m256")]
    vpcmpeqb_k12_ymm_m256 = 2464,
    /// <summary>
    /// vpcmpeqb k1 {k2}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpcmpeqb k1, zmm, zmm","vpcmpeqb k1 {k2}, zmm, zmm/m512")]
    vpcmpeqb_k1_zmm_zmm = 2465,
    /// <summary>
    /// vpcmpeqb k1 {k2}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpcmpeqb k1, zmm, m512","vpcmpeqb k1 {k2}, zmm, zmm/m512")]
    vpcmpeqb_k1_zmm_m512 = 2466,
    /// <summary>
    /// vpcmpeqb k1 {k2}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpcmpeqb k12, zmm, zmm","vpcmpeqb k1 {k2}, zmm, zmm/m512")]
    vpcmpeqb_k12_zmm_zmm = 2467,
    /// <summary>
    /// vpcmpeqb k1 {k2}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpcmpeqb k12, zmm, m512","vpcmpeqb k1 {k2}, zmm, zmm/m512")]
    vpcmpeqb_k12_zmm_m512 = 2468,
    /// <summary>
    /// vpcmpeqb xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpcmpeqb xmm, xmm, xmm","vpcmpeqb xmm, xmm, xmm/m128")]
    vpcmpeqb_xmm_xmm_xmm = 2469,
    /// <summary>
    /// vpcmpeqb xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpcmpeqb xmm, xmm, m128","vpcmpeqb xmm, xmm, xmm/m128")]
    vpcmpeqb_xmm_xmm_m128 = 2470,
    /// <summary>
    /// vpcmpeqb ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpcmpeqb ymm, ymm, ymm","vpcmpeqb ymm, ymm, ymm/m256")]
    vpcmpeqb_ymm_ymm_ymm = 2471,
    /// <summary>
    /// vpcmpeqb ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpcmpeqb ymm, ymm, m256","vpcmpeqb ymm, ymm, ymm/m256")]
    vpcmpeqb_ymm_ymm_m256 = 2472,
    /// <summary>
    /// vpcmpeqd k1 {k2}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpcmpeqd k1, xmm, xmm","vpcmpeqd k1 {k2}, xmm, xmm/m128/m32bcst")]
    vpcmpeqd_k1_xmm_xmm = 2473,
    /// <summary>
    /// vpcmpeqd k1 {k2}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpcmpeqd k1, xmm, m128","vpcmpeqd k1 {k2}, xmm, xmm/m128/m32bcst")]
    vpcmpeqd_k1_xmm_m128 = 2474,
    /// <summary>
    /// vpcmpeqd k1 {k2}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpcmpeqd k1, xmm, m32bcst","vpcmpeqd k1 {k2}, xmm, xmm/m128/m32bcst")]
    vpcmpeqd_k1_xmm_m32bcst = 2475,
    /// <summary>
    /// vpcmpeqd k1 {k2}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpcmpeqd k12, xmm, xmm","vpcmpeqd k1 {k2}, xmm, xmm/m128/m32bcst")]
    vpcmpeqd_k12_xmm_xmm = 2476,
    /// <summary>
    /// vpcmpeqd k1 {k2}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpcmpeqd k12, xmm, m128","vpcmpeqd k1 {k2}, xmm, xmm/m128/m32bcst")]
    vpcmpeqd_k12_xmm_m128 = 2477,
    /// <summary>
    /// vpcmpeqd k1 {k2}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpcmpeqd k12, xmm, m32bcst","vpcmpeqd k1 {k2}, xmm, xmm/m128/m32bcst")]
    vpcmpeqd_k12_xmm_m32bcst = 2478,
    /// <summary>
    /// vpcmpeqd k1 {k2}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpcmpeqd k1, ymm, ymm","vpcmpeqd k1 {k2}, ymm, ymm/m256/m32bcst")]
    vpcmpeqd_k1_ymm_ymm = 2479,
    /// <summary>
    /// vpcmpeqd k1 {k2}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpcmpeqd k1, ymm, m256","vpcmpeqd k1 {k2}, ymm, ymm/m256/m32bcst")]
    vpcmpeqd_k1_ymm_m256 = 2480,
    /// <summary>
    /// vpcmpeqd k1 {k2}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpcmpeqd k1, ymm, m32bcst","vpcmpeqd k1 {k2}, ymm, ymm/m256/m32bcst")]
    vpcmpeqd_k1_ymm_m32bcst = 2481,
    /// <summary>
    /// vpcmpeqd k1 {k2}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpcmpeqd k12, ymm, ymm","vpcmpeqd k1 {k2}, ymm, ymm/m256/m32bcst")]
    vpcmpeqd_k12_ymm_ymm = 2482,
    /// <summary>
    /// vpcmpeqd k1 {k2}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpcmpeqd k12, ymm, m256","vpcmpeqd k1 {k2}, ymm, ymm/m256/m32bcst")]
    vpcmpeqd_k12_ymm_m256 = 2483,
    /// <summary>
    /// vpcmpeqd k1 {k2}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpcmpeqd k12, ymm, m32bcst","vpcmpeqd k1 {k2}, ymm, ymm/m256/m32bcst")]
    vpcmpeqd_k12_ymm_m32bcst = 2484,
    /// <summary>
    /// vpcmpeqd k1 {k2}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpcmpeqd k1, zmm, zmm","vpcmpeqd k1 {k2}, zmm, zmm/m512/m32bcst")]
    vpcmpeqd_k1_zmm_zmm = 2485,
    /// <summary>
    /// vpcmpeqd k1 {k2}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpcmpeqd k1, zmm, m512","vpcmpeqd k1 {k2}, zmm, zmm/m512/m32bcst")]
    vpcmpeqd_k1_zmm_m512 = 2486,
    /// <summary>
    /// vpcmpeqd k1 {k2}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpcmpeqd k1, zmm, m32bcst","vpcmpeqd k1 {k2}, zmm, zmm/m512/m32bcst")]
    vpcmpeqd_k1_zmm_m32bcst = 2487,
    /// <summary>
    /// vpcmpeqd k1 {k2}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpcmpeqd k12, zmm, zmm","vpcmpeqd k1 {k2}, zmm, zmm/m512/m32bcst")]
    vpcmpeqd_k12_zmm_zmm = 2488,
    /// <summary>
    /// vpcmpeqd k1 {k2}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpcmpeqd k12, zmm, m512","vpcmpeqd k1 {k2}, zmm, zmm/m512/m32bcst")]
    vpcmpeqd_k12_zmm_m512 = 2489,
    /// <summary>
    /// vpcmpeqd k1 {k2}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpcmpeqd k12, zmm, m32bcst","vpcmpeqd k1 {k2}, zmm, zmm/m512/m32bcst")]
    vpcmpeqd_k12_zmm_m32bcst = 2490,
    /// <summary>
    /// vpcmpeqd xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpcmpeqd xmm, xmm, xmm","vpcmpeqd xmm, xmm, xmm/m128")]
    vpcmpeqd_xmm_xmm_xmm = 2491,
    /// <summary>
    /// vpcmpeqd xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpcmpeqd xmm, xmm, m128","vpcmpeqd xmm, xmm, xmm/m128")]
    vpcmpeqd_xmm_xmm_m128 = 2492,
    /// <summary>
    /// vpcmpeqd ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpcmpeqd ymm, ymm, ymm","vpcmpeqd ymm, ymm, ymm/m256")]
    vpcmpeqd_ymm_ymm_ymm = 2493,
    /// <summary>
    /// vpcmpeqd ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpcmpeqd ymm, ymm, m256","vpcmpeqd ymm, ymm, ymm/m256")]
    vpcmpeqd_ymm_ymm_m256 = 2494,
    /// <summary>
    /// vpcmpeqq k1 {k2}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpcmpeqq k1, xmm, xmm","vpcmpeqq k1 {k2}, xmm, xmm/m128/m64bcst")]
    vpcmpeqq_k1_xmm_xmm = 2495,
    /// <summary>
    /// vpcmpeqq k1 {k2}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpcmpeqq k1, xmm, m128","vpcmpeqq k1 {k2}, xmm, xmm/m128/m64bcst")]
    vpcmpeqq_k1_xmm_m128 = 2496,
    /// <summary>
    /// vpcmpeqq k1 {k2}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpcmpeqq k1, xmm, m64bcst","vpcmpeqq k1 {k2}, xmm, xmm/m128/m64bcst")]
    vpcmpeqq_k1_xmm_m64bcst = 2497,
    /// <summary>
    /// vpcmpeqq k1 {k2}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpcmpeqq k12, xmm, xmm","vpcmpeqq k1 {k2}, xmm, xmm/m128/m64bcst")]
    vpcmpeqq_k12_xmm_xmm = 2498,
    /// <summary>
    /// vpcmpeqq k1 {k2}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpcmpeqq k12, xmm, m128","vpcmpeqq k1 {k2}, xmm, xmm/m128/m64bcst")]
    vpcmpeqq_k12_xmm_m128 = 2499,
    /// <summary>
    /// vpcmpeqq k1 {k2}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpcmpeqq k12, xmm, m64bcst","vpcmpeqq k1 {k2}, xmm, xmm/m128/m64bcst")]
    vpcmpeqq_k12_xmm_m64bcst = 2500,
    /// <summary>
    /// vpcmpeqq k1 {k2}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpcmpeqq k1, ymm, ymm","vpcmpeqq k1 {k2}, ymm, ymm/m256/m64bcst")]
    vpcmpeqq_k1_ymm_ymm = 2501,
    /// <summary>
    /// vpcmpeqq k1 {k2}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpcmpeqq k1, ymm, m256","vpcmpeqq k1 {k2}, ymm, ymm/m256/m64bcst")]
    vpcmpeqq_k1_ymm_m256 = 2502,
    /// <summary>
    /// vpcmpeqq k1 {k2}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpcmpeqq k1, ymm, m64bcst","vpcmpeqq k1 {k2}, ymm, ymm/m256/m64bcst")]
    vpcmpeqq_k1_ymm_m64bcst = 2503,
    /// <summary>
    /// vpcmpeqq k1 {k2}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpcmpeqq k12, ymm, ymm","vpcmpeqq k1 {k2}, ymm, ymm/m256/m64bcst")]
    vpcmpeqq_k12_ymm_ymm = 2504,
    /// <summary>
    /// vpcmpeqq k1 {k2}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpcmpeqq k12, ymm, m256","vpcmpeqq k1 {k2}, ymm, ymm/m256/m64bcst")]
    vpcmpeqq_k12_ymm_m256 = 2505,
    /// <summary>
    /// vpcmpeqq k1 {k2}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpcmpeqq k12, ymm, m64bcst","vpcmpeqq k1 {k2}, ymm, ymm/m256/m64bcst")]
    vpcmpeqq_k12_ymm_m64bcst = 2506,
    /// <summary>
    /// vpcmpeqq k1 {k2}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpcmpeqq k1, zmm, zmm","vpcmpeqq k1 {k2}, zmm, zmm/m512/m64bcst")]
    vpcmpeqq_k1_zmm_zmm = 2507,
    /// <summary>
    /// vpcmpeqq k1 {k2}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpcmpeqq k1, zmm, m512","vpcmpeqq k1 {k2}, zmm, zmm/m512/m64bcst")]
    vpcmpeqq_k1_zmm_m512 = 2508,
    /// <summary>
    /// vpcmpeqq k1 {k2}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpcmpeqq k1, zmm, m64bcst","vpcmpeqq k1 {k2}, zmm, zmm/m512/m64bcst")]
    vpcmpeqq_k1_zmm_m64bcst = 2509,
    /// <summary>
    /// vpcmpeqq k1 {k2}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpcmpeqq k12, zmm, zmm","vpcmpeqq k1 {k2}, zmm, zmm/m512/m64bcst")]
    vpcmpeqq_k12_zmm_zmm = 2510,
    /// <summary>
    /// vpcmpeqq k1 {k2}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpcmpeqq k12, zmm, m512","vpcmpeqq k1 {k2}, zmm, zmm/m512/m64bcst")]
    vpcmpeqq_k12_zmm_m512 = 2511,
    /// <summary>
    /// vpcmpeqq k1 {k2}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpcmpeqq k12, zmm, m64bcst","vpcmpeqq k1 {k2}, zmm, zmm/m512/m64bcst")]
    vpcmpeqq_k12_zmm_m64bcst = 2512,
    /// <summary>
    /// vpcmpeqq xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpcmpeqq xmm, xmm, xmm","vpcmpeqq xmm, xmm, xmm/m128")]
    vpcmpeqq_xmm_xmm_xmm = 2513,
    /// <summary>
    /// vpcmpeqq xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpcmpeqq xmm, xmm, m128","vpcmpeqq xmm, xmm, xmm/m128")]
    vpcmpeqq_xmm_xmm_m128 = 2514,
    /// <summary>
    /// vpcmpeqq ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpcmpeqq ymm, ymm, ymm","vpcmpeqq ymm, ymm, ymm/m256")]
    vpcmpeqq_ymm_ymm_ymm = 2515,
    /// <summary>
    /// vpcmpeqq ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpcmpeqq ymm, ymm, m256","vpcmpeqq ymm, ymm, ymm/m256")]
    vpcmpeqq_ymm_ymm_m256 = 2516,
    /// <summary>
    /// vpcmpeqw k1 {k2}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpcmpeqw k1, xmm, xmm","vpcmpeqw k1 {k2}, xmm, xmm/m128")]
    vpcmpeqw_k1_xmm_xmm = 2517,
    /// <summary>
    /// vpcmpeqw k1 {k2}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpcmpeqw k1, xmm, m128","vpcmpeqw k1 {k2}, xmm, xmm/m128")]
    vpcmpeqw_k1_xmm_m128 = 2518,
    /// <summary>
    /// vpcmpeqw k1 {k2}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpcmpeqw k12, xmm, xmm","vpcmpeqw k1 {k2}, xmm, xmm/m128")]
    vpcmpeqw_k12_xmm_xmm = 2519,
    /// <summary>
    /// vpcmpeqw k1 {k2}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpcmpeqw k12, xmm, m128","vpcmpeqw k1 {k2}, xmm, xmm/m128")]
    vpcmpeqw_k12_xmm_m128 = 2520,
    /// <summary>
    /// vpcmpeqw k1 {k2}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpcmpeqw k1, ymm, ymm","vpcmpeqw k1 {k2}, ymm, ymm/m256")]
    vpcmpeqw_k1_ymm_ymm = 2521,
    /// <summary>
    /// vpcmpeqw k1 {k2}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpcmpeqw k1, ymm, m256","vpcmpeqw k1 {k2}, ymm, ymm/m256")]
    vpcmpeqw_k1_ymm_m256 = 2522,
    /// <summary>
    /// vpcmpeqw k1 {k2}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpcmpeqw k12, ymm, ymm","vpcmpeqw k1 {k2}, ymm, ymm/m256")]
    vpcmpeqw_k12_ymm_ymm = 2523,
    /// <summary>
    /// vpcmpeqw k1 {k2}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpcmpeqw k12, ymm, m256","vpcmpeqw k1 {k2}, ymm, ymm/m256")]
    vpcmpeqw_k12_ymm_m256 = 2524,
    /// <summary>
    /// vpcmpeqw k1 {k2}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpcmpeqw k1, zmm, zmm","vpcmpeqw k1 {k2}, zmm, zmm/m512")]
    vpcmpeqw_k1_zmm_zmm = 2525,
    /// <summary>
    /// vpcmpeqw k1 {k2}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpcmpeqw k1, zmm, m512","vpcmpeqw k1 {k2}, zmm, zmm/m512")]
    vpcmpeqw_k1_zmm_m512 = 2526,
    /// <summary>
    /// vpcmpeqw k1 {k2}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpcmpeqw k12, zmm, zmm","vpcmpeqw k1 {k2}, zmm, zmm/m512")]
    vpcmpeqw_k12_zmm_zmm = 2527,
    /// <summary>
    /// vpcmpeqw k1 {k2}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpcmpeqw k12, zmm, m512","vpcmpeqw k1 {k2}, zmm, zmm/m512")]
    vpcmpeqw_k12_zmm_m512 = 2528,
    /// <summary>
    /// vpcmpeqw xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpcmpeqw xmm, xmm, xmm","vpcmpeqw xmm, xmm, xmm/m128")]
    vpcmpeqw_xmm_xmm_xmm = 2529,
    /// <summary>
    /// vpcmpeqw xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpcmpeqw xmm, xmm, m128","vpcmpeqw xmm, xmm, xmm/m128")]
    vpcmpeqw_xmm_xmm_m128 = 2530,
    /// <summary>
    /// vpcmpeqw ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpcmpeqw ymm, ymm, ymm","vpcmpeqw ymm, ymm, ymm/m256")]
    vpcmpeqw_ymm_ymm_ymm = 2531,
    /// <summary>
    /// vpcmpeqw ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpcmpeqw ymm, ymm, m256","vpcmpeqw ymm, ymm, ymm/m256")]
    vpcmpeqw_ymm_ymm_m256 = 2532,
    /// <summary>
    /// vpcmpgtb k1 {k2}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpcmpgtb k1, xmm, xmm","vpcmpgtb k1 {k2}, xmm, xmm/m128")]
    vpcmpgtb_k1_xmm_xmm = 2533,
    /// <summary>
    /// vpcmpgtb k1 {k2}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpcmpgtb k1, xmm, m128","vpcmpgtb k1 {k2}, xmm, xmm/m128")]
    vpcmpgtb_k1_xmm_m128 = 2534,
    /// <summary>
    /// vpcmpgtb k1 {k2}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpcmpgtb k12, xmm, xmm","vpcmpgtb k1 {k2}, xmm, xmm/m128")]
    vpcmpgtb_k12_xmm_xmm = 2535,
    /// <summary>
    /// vpcmpgtb k1 {k2}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpcmpgtb k12, xmm, m128","vpcmpgtb k1 {k2}, xmm, xmm/m128")]
    vpcmpgtb_k12_xmm_m128 = 2536,
    /// <summary>
    /// vpcmpgtb k1 {k2}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpcmpgtb k1, ymm, ymm","vpcmpgtb k1 {k2}, ymm, ymm/m256")]
    vpcmpgtb_k1_ymm_ymm = 2537,
    /// <summary>
    /// vpcmpgtb k1 {k2}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpcmpgtb k1, ymm, m256","vpcmpgtb k1 {k2}, ymm, ymm/m256")]
    vpcmpgtb_k1_ymm_m256 = 2538,
    /// <summary>
    /// vpcmpgtb k1 {k2}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpcmpgtb k12, ymm, ymm","vpcmpgtb k1 {k2}, ymm, ymm/m256")]
    vpcmpgtb_k12_ymm_ymm = 2539,
    /// <summary>
    /// vpcmpgtb k1 {k2}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpcmpgtb k12, ymm, m256","vpcmpgtb k1 {k2}, ymm, ymm/m256")]
    vpcmpgtb_k12_ymm_m256 = 2540,
    /// <summary>
    /// vpcmpgtb k1 {k2}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpcmpgtb k1, zmm, zmm","vpcmpgtb k1 {k2}, zmm, zmm/m512")]
    vpcmpgtb_k1_zmm_zmm = 2541,
    /// <summary>
    /// vpcmpgtb k1 {k2}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpcmpgtb k1, zmm, m512","vpcmpgtb k1 {k2}, zmm, zmm/m512")]
    vpcmpgtb_k1_zmm_m512 = 2542,
    /// <summary>
    /// vpcmpgtb k1 {k2}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpcmpgtb k12, zmm, zmm","vpcmpgtb k1 {k2}, zmm, zmm/m512")]
    vpcmpgtb_k12_zmm_zmm = 2543,
    /// <summary>
    /// vpcmpgtb k1 {k2}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpcmpgtb k12, zmm, m512","vpcmpgtb k1 {k2}, zmm, zmm/m512")]
    vpcmpgtb_k12_zmm_m512 = 2544,
    /// <summary>
    /// vpcmpgtb xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpcmpgtb xmm, xmm, xmm","vpcmpgtb xmm, xmm, xmm/m128")]
    vpcmpgtb_xmm_xmm_xmm = 2545,
    /// <summary>
    /// vpcmpgtb xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpcmpgtb xmm, xmm, m128","vpcmpgtb xmm, xmm, xmm/m128")]
    vpcmpgtb_xmm_xmm_m128 = 2546,
    /// <summary>
    /// vpcmpgtb ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpcmpgtb ymm, ymm, ymm","vpcmpgtb ymm, ymm, ymm/m256")]
    vpcmpgtb_ymm_ymm_ymm = 2547,
    /// <summary>
    /// vpcmpgtb ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpcmpgtb ymm, ymm, m256","vpcmpgtb ymm, ymm, ymm/m256")]
    vpcmpgtb_ymm_ymm_m256 = 2548,
    /// <summary>
    /// vpcmpgtd k1 {k2}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpcmpgtd k1, xmm, xmm","vpcmpgtd k1 {k2}, xmm, xmm/m128/m32bcst")]
    vpcmpgtd_k1_xmm_xmm = 2549,
    /// <summary>
    /// vpcmpgtd k1 {k2}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpcmpgtd k1, xmm, m128","vpcmpgtd k1 {k2}, xmm, xmm/m128/m32bcst")]
    vpcmpgtd_k1_xmm_m128 = 2550,
    /// <summary>
    /// vpcmpgtd k1 {k2}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpcmpgtd k1, xmm, m32bcst","vpcmpgtd k1 {k2}, xmm, xmm/m128/m32bcst")]
    vpcmpgtd_k1_xmm_m32bcst = 2551,
    /// <summary>
    /// vpcmpgtd k1 {k2}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpcmpgtd k12, xmm, xmm","vpcmpgtd k1 {k2}, xmm, xmm/m128/m32bcst")]
    vpcmpgtd_k12_xmm_xmm = 2552,
    /// <summary>
    /// vpcmpgtd k1 {k2}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpcmpgtd k12, xmm, m128","vpcmpgtd k1 {k2}, xmm, xmm/m128/m32bcst")]
    vpcmpgtd_k12_xmm_m128 = 2553,
    /// <summary>
    /// vpcmpgtd k1 {k2}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpcmpgtd k12, xmm, m32bcst","vpcmpgtd k1 {k2}, xmm, xmm/m128/m32bcst")]
    vpcmpgtd_k12_xmm_m32bcst = 2554,
    /// <summary>
    /// vpcmpgtd k1 {k2}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpcmpgtd k1, ymm, ymm","vpcmpgtd k1 {k2}, ymm, ymm/m256/m32bcst")]
    vpcmpgtd_k1_ymm_ymm = 2555,
    /// <summary>
    /// vpcmpgtd k1 {k2}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpcmpgtd k1, ymm, m256","vpcmpgtd k1 {k2}, ymm, ymm/m256/m32bcst")]
    vpcmpgtd_k1_ymm_m256 = 2556,
    /// <summary>
    /// vpcmpgtd k1 {k2}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpcmpgtd k1, ymm, m32bcst","vpcmpgtd k1 {k2}, ymm, ymm/m256/m32bcst")]
    vpcmpgtd_k1_ymm_m32bcst = 2557,
    /// <summary>
    /// vpcmpgtd k1 {k2}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpcmpgtd k12, ymm, ymm","vpcmpgtd k1 {k2}, ymm, ymm/m256/m32bcst")]
    vpcmpgtd_k12_ymm_ymm = 2558,
    /// <summary>
    /// vpcmpgtd k1 {k2}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpcmpgtd k12, ymm, m256","vpcmpgtd k1 {k2}, ymm, ymm/m256/m32bcst")]
    vpcmpgtd_k12_ymm_m256 = 2559,
    /// <summary>
    /// vpcmpgtd k1 {k2}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpcmpgtd k12, ymm, m32bcst","vpcmpgtd k1 {k2}, ymm, ymm/m256/m32bcst")]
    vpcmpgtd_k12_ymm_m32bcst = 2560,
    /// <summary>
    /// vpcmpgtd k1 {k2}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpcmpgtd k1, zmm, zmm","vpcmpgtd k1 {k2}, zmm, zmm/m512/m32bcst")]
    vpcmpgtd_k1_zmm_zmm = 2561,
    /// <summary>
    /// vpcmpgtd k1 {k2}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpcmpgtd k1, zmm, m512","vpcmpgtd k1 {k2}, zmm, zmm/m512/m32bcst")]
    vpcmpgtd_k1_zmm_m512 = 2562,
    /// <summary>
    /// vpcmpgtd k1 {k2}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpcmpgtd k1, zmm, m32bcst","vpcmpgtd k1 {k2}, zmm, zmm/m512/m32bcst")]
    vpcmpgtd_k1_zmm_m32bcst = 2563,
    /// <summary>
    /// vpcmpgtd k1 {k2}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpcmpgtd k12, zmm, zmm","vpcmpgtd k1 {k2}, zmm, zmm/m512/m32bcst")]
    vpcmpgtd_k12_zmm_zmm = 2564,
    /// <summary>
    /// vpcmpgtd k1 {k2}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpcmpgtd k12, zmm, m512","vpcmpgtd k1 {k2}, zmm, zmm/m512/m32bcst")]
    vpcmpgtd_k12_zmm_m512 = 2565,
    /// <summary>
    /// vpcmpgtd k1 {k2}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpcmpgtd k12, zmm, m32bcst","vpcmpgtd k1 {k2}, zmm, zmm/m512/m32bcst")]
    vpcmpgtd_k12_zmm_m32bcst = 2566,
    /// <summary>
    /// vpcmpgtd xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpcmpgtd xmm, xmm, xmm","vpcmpgtd xmm, xmm, xmm/m128")]
    vpcmpgtd_xmm_xmm_xmm = 2567,
    /// <summary>
    /// vpcmpgtd xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpcmpgtd xmm, xmm, m128","vpcmpgtd xmm, xmm, xmm/m128")]
    vpcmpgtd_xmm_xmm_m128 = 2568,
    /// <summary>
    /// vpcmpgtd ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpcmpgtd ymm, ymm, ymm","vpcmpgtd ymm, ymm, ymm/m256")]
    vpcmpgtd_ymm_ymm_ymm = 2569,
    /// <summary>
    /// vpcmpgtd ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpcmpgtd ymm, ymm, m256","vpcmpgtd ymm, ymm, ymm/m256")]
    vpcmpgtd_ymm_ymm_m256 = 2570,
    /// <summary>
    /// vpcmpgtq k1 {k2}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpcmpgtq k1, xmm, xmm","vpcmpgtq k1 {k2}, xmm, xmm/m128/m64bcst")]
    vpcmpgtq_k1_xmm_xmm = 2571,
    /// <summary>
    /// vpcmpgtq k1 {k2}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpcmpgtq k1, xmm, m128","vpcmpgtq k1 {k2}, xmm, xmm/m128/m64bcst")]
    vpcmpgtq_k1_xmm_m128 = 2572,
    /// <summary>
    /// vpcmpgtq k1 {k2}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpcmpgtq k1, xmm, m64bcst","vpcmpgtq k1 {k2}, xmm, xmm/m128/m64bcst")]
    vpcmpgtq_k1_xmm_m64bcst = 2573,
    /// <summary>
    /// vpcmpgtq k1 {k2}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpcmpgtq k12, xmm, xmm","vpcmpgtq k1 {k2}, xmm, xmm/m128/m64bcst")]
    vpcmpgtq_k12_xmm_xmm = 2574,
    /// <summary>
    /// vpcmpgtq k1 {k2}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpcmpgtq k12, xmm, m128","vpcmpgtq k1 {k2}, xmm, xmm/m128/m64bcst")]
    vpcmpgtq_k12_xmm_m128 = 2575,
    /// <summary>
    /// vpcmpgtq k1 {k2}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpcmpgtq k12, xmm, m64bcst","vpcmpgtq k1 {k2}, xmm, xmm/m128/m64bcst")]
    vpcmpgtq_k12_xmm_m64bcst = 2576,
    /// <summary>
    /// vpcmpgtq k1 {k2}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpcmpgtq k1, ymm, ymm","vpcmpgtq k1 {k2}, ymm, ymm/m256/m64bcst")]
    vpcmpgtq_k1_ymm_ymm = 2577,
    /// <summary>
    /// vpcmpgtq k1 {k2}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpcmpgtq k1, ymm, m256","vpcmpgtq k1 {k2}, ymm, ymm/m256/m64bcst")]
    vpcmpgtq_k1_ymm_m256 = 2578,
    /// <summary>
    /// vpcmpgtq k1 {k2}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpcmpgtq k1, ymm, m64bcst","vpcmpgtq k1 {k2}, ymm, ymm/m256/m64bcst")]
    vpcmpgtq_k1_ymm_m64bcst = 2579,
    /// <summary>
    /// vpcmpgtq k1 {k2}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpcmpgtq k12, ymm, ymm","vpcmpgtq k1 {k2}, ymm, ymm/m256/m64bcst")]
    vpcmpgtq_k12_ymm_ymm = 2580,
    /// <summary>
    /// vpcmpgtq k1 {k2}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpcmpgtq k12, ymm, m256","vpcmpgtq k1 {k2}, ymm, ymm/m256/m64bcst")]
    vpcmpgtq_k12_ymm_m256 = 2581,
    /// <summary>
    /// vpcmpgtq k1 {k2}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpcmpgtq k12, ymm, m64bcst","vpcmpgtq k1 {k2}, ymm, ymm/m256/m64bcst")]
    vpcmpgtq_k12_ymm_m64bcst = 2582,
    /// <summary>
    /// vpcmpgtq k1 {k2}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpcmpgtq k1, zmm, zmm","vpcmpgtq k1 {k2}, zmm, zmm/m512/m64bcst")]
    vpcmpgtq_k1_zmm_zmm = 2583,
    /// <summary>
    /// vpcmpgtq k1 {k2}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpcmpgtq k1, zmm, m512","vpcmpgtq k1 {k2}, zmm, zmm/m512/m64bcst")]
    vpcmpgtq_k1_zmm_m512 = 2584,
    /// <summary>
    /// vpcmpgtq k1 {k2}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpcmpgtq k1, zmm, m64bcst","vpcmpgtq k1 {k2}, zmm, zmm/m512/m64bcst")]
    vpcmpgtq_k1_zmm_m64bcst = 2585,
    /// <summary>
    /// vpcmpgtq k1 {k2}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpcmpgtq k12, zmm, zmm","vpcmpgtq k1 {k2}, zmm, zmm/m512/m64bcst")]
    vpcmpgtq_k12_zmm_zmm = 2586,
    /// <summary>
    /// vpcmpgtq k1 {k2}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpcmpgtq k12, zmm, m512","vpcmpgtq k1 {k2}, zmm, zmm/m512/m64bcst")]
    vpcmpgtq_k12_zmm_m512 = 2587,
    /// <summary>
    /// vpcmpgtq k1 {k2}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpcmpgtq k12, zmm, m64bcst","vpcmpgtq k1 {k2}, zmm, zmm/m512/m64bcst")]
    vpcmpgtq_k12_zmm_m64bcst = 2588,
    /// <summary>
    /// vpcmpgtq xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpcmpgtq xmm, xmm, xmm","vpcmpgtq xmm, xmm, xmm/m128")]
    vpcmpgtq_xmm_xmm_xmm = 2589,
    /// <summary>
    /// vpcmpgtq xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpcmpgtq xmm, xmm, m128","vpcmpgtq xmm, xmm, xmm/m128")]
    vpcmpgtq_xmm_xmm_m128 = 2590,
    /// <summary>
    /// vpcmpgtq ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpcmpgtq ymm, ymm, ymm","vpcmpgtq ymm, ymm, ymm/m256")]
    vpcmpgtq_ymm_ymm_ymm = 2591,
    /// <summary>
    /// vpcmpgtq ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpcmpgtq ymm, ymm, m256","vpcmpgtq ymm, ymm, ymm/m256")]
    vpcmpgtq_ymm_ymm_m256 = 2592,
    /// <summary>
    /// vpcmpgtw k1 {k2}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpcmpgtw k1, xmm, xmm","vpcmpgtw k1 {k2}, xmm, xmm/m128")]
    vpcmpgtw_k1_xmm_xmm = 2593,
    /// <summary>
    /// vpcmpgtw k1 {k2}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpcmpgtw k1, xmm, m128","vpcmpgtw k1 {k2}, xmm, xmm/m128")]
    vpcmpgtw_k1_xmm_m128 = 2594,
    /// <summary>
    /// vpcmpgtw k1 {k2}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpcmpgtw k12, xmm, xmm","vpcmpgtw k1 {k2}, xmm, xmm/m128")]
    vpcmpgtw_k12_xmm_xmm = 2595,
    /// <summary>
    /// vpcmpgtw k1 {k2}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpcmpgtw k12, xmm, m128","vpcmpgtw k1 {k2}, xmm, xmm/m128")]
    vpcmpgtw_k12_xmm_m128 = 2596,
    /// <summary>
    /// vpcmpgtw k1 {k2}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpcmpgtw k1, ymm, ymm","vpcmpgtw k1 {k2}, ymm, ymm/m256")]
    vpcmpgtw_k1_ymm_ymm = 2597,
    /// <summary>
    /// vpcmpgtw k1 {k2}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpcmpgtw k1, ymm, m256","vpcmpgtw k1 {k2}, ymm, ymm/m256")]
    vpcmpgtw_k1_ymm_m256 = 2598,
    /// <summary>
    /// vpcmpgtw k1 {k2}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpcmpgtw k12, ymm, ymm","vpcmpgtw k1 {k2}, ymm, ymm/m256")]
    vpcmpgtw_k12_ymm_ymm = 2599,
    /// <summary>
    /// vpcmpgtw k1 {k2}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpcmpgtw k12, ymm, m256","vpcmpgtw k1 {k2}, ymm, ymm/m256")]
    vpcmpgtw_k12_ymm_m256 = 2600,
    /// <summary>
    /// vpcmpgtw k1 {k2}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpcmpgtw k1, zmm, zmm","vpcmpgtw k1 {k2}, zmm, zmm/m512")]
    vpcmpgtw_k1_zmm_zmm = 2601,
    /// <summary>
    /// vpcmpgtw k1 {k2}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpcmpgtw k1, zmm, m512","vpcmpgtw k1 {k2}, zmm, zmm/m512")]
    vpcmpgtw_k1_zmm_m512 = 2602,
    /// <summary>
    /// vpcmpgtw k1 {k2}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpcmpgtw k12, zmm, zmm","vpcmpgtw k1 {k2}, zmm, zmm/m512")]
    vpcmpgtw_k12_zmm_zmm = 2603,
    /// <summary>
    /// vpcmpgtw k1 {k2}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpcmpgtw k12, zmm, m512","vpcmpgtw k1 {k2}, zmm, zmm/m512")]
    vpcmpgtw_k12_zmm_m512 = 2604,
    /// <summary>
    /// vpcmpgtw xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpcmpgtw xmm, xmm, xmm","vpcmpgtw xmm, xmm, xmm/m128")]
    vpcmpgtw_xmm_xmm_xmm = 2605,
    /// <summary>
    /// vpcmpgtw xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpcmpgtw xmm, xmm, m128","vpcmpgtw xmm, xmm, xmm/m128")]
    vpcmpgtw_xmm_xmm_m128 = 2606,
    /// <summary>
    /// vpcmpgtw ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpcmpgtw ymm, ymm, ymm","vpcmpgtw ymm, ymm, ymm/m256")]
    vpcmpgtw_ymm_ymm_ymm = 2607,
    /// <summary>
    /// vpcmpgtw ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpcmpgtw ymm, ymm, m256","vpcmpgtw ymm, ymm, ymm/m256")]
    vpcmpgtw_ymm_ymm_m256 = 2608,
    /// <summary>
    /// vpcmpq k1 {k2}, xmm, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("vpcmpq k1, xmm, xmm, imm8","vpcmpq k1 {k2}, xmm, xmm/m128/m64bcst, imm8")]
    vpcmpq_k1_xmm_xmm_imm8 = 2609,
    /// <summary>
    /// vpcmpq k1 {k2}, xmm, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("vpcmpq k1, xmm, m128, imm8","vpcmpq k1 {k2}, xmm, xmm/m128/m64bcst, imm8")]
    vpcmpq_k1_xmm_m128_imm8 = 2610,
    /// <summary>
    /// vpcmpq k1 {k2}, xmm, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("vpcmpq k1, xmm, m64bcst, imm8","vpcmpq k1 {k2}, xmm, xmm/m128/m64bcst, imm8")]
    vpcmpq_k1_xmm_m64bcst_imm8 = 2611,
    /// <summary>
    /// vpcmpq k1 {k2}, xmm, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("vpcmpq k12, xmm, xmm, imm8","vpcmpq k1 {k2}, xmm, xmm/m128/m64bcst, imm8")]
    vpcmpq_k12_xmm_xmm_imm8 = 2612,
    /// <summary>
    /// vpcmpq k1 {k2}, xmm, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("vpcmpq k12, xmm, m128, imm8","vpcmpq k1 {k2}, xmm, xmm/m128/m64bcst, imm8")]
    vpcmpq_k12_xmm_m128_imm8 = 2613,
    /// <summary>
    /// vpcmpq k1 {k2}, xmm, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("vpcmpq k12, xmm, m64bcst, imm8","vpcmpq k1 {k2}, xmm, xmm/m128/m64bcst, imm8")]
    vpcmpq_k12_xmm_m64bcst_imm8 = 2614,
    /// <summary>
    /// vpcmpq k1 {k2}, ymm, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vpcmpq k1, ymm, ymm, imm8","vpcmpq k1 {k2}, ymm, ymm/m256/m64bcst, imm8")]
    vpcmpq_k1_ymm_ymm_imm8 = 2615,
    /// <summary>
    /// vpcmpq k1 {k2}, ymm, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vpcmpq k1, ymm, m256, imm8","vpcmpq k1 {k2}, ymm, ymm/m256/m64bcst, imm8")]
    vpcmpq_k1_ymm_m256_imm8 = 2616,
    /// <summary>
    /// vpcmpq k1 {k2}, ymm, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vpcmpq k1, ymm, m64bcst, imm8","vpcmpq k1 {k2}, ymm, ymm/m256/m64bcst, imm8")]
    vpcmpq_k1_ymm_m64bcst_imm8 = 2617,
    /// <summary>
    /// vpcmpq k1 {k2}, ymm, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vpcmpq k12, ymm, ymm, imm8","vpcmpq k1 {k2}, ymm, ymm/m256/m64bcst, imm8")]
    vpcmpq_k12_ymm_ymm_imm8 = 2618,
    /// <summary>
    /// vpcmpq k1 {k2}, ymm, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vpcmpq k12, ymm, m256, imm8","vpcmpq k1 {k2}, ymm, ymm/m256/m64bcst, imm8")]
    vpcmpq_k12_ymm_m256_imm8 = 2619,
    /// <summary>
    /// vpcmpq k1 {k2}, ymm, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vpcmpq k12, ymm, m64bcst, imm8","vpcmpq k1 {k2}, ymm, ymm/m256/m64bcst, imm8")]
    vpcmpq_k12_ymm_m64bcst_imm8 = 2620,
    /// <summary>
    /// vpcmpq k1 {k2}, zmm, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vpcmpq k1, zmm, zmm, imm8","vpcmpq k1 {k2}, zmm, zmm/m512/m64bcst, imm8")]
    vpcmpq_k1_zmm_zmm_imm8 = 2621,
    /// <summary>
    /// vpcmpq k1 {k2}, zmm, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vpcmpq k1, zmm, m512, imm8","vpcmpq k1 {k2}, zmm, zmm/m512/m64bcst, imm8")]
    vpcmpq_k1_zmm_m512_imm8 = 2622,
    /// <summary>
    /// vpcmpq k1 {k2}, zmm, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vpcmpq k1, zmm, m64bcst, imm8","vpcmpq k1 {k2}, zmm, zmm/m512/m64bcst, imm8")]
    vpcmpq_k1_zmm_m64bcst_imm8 = 2623,
    /// <summary>
    /// vpcmpq k1 {k2}, zmm, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vpcmpq k12, zmm, zmm, imm8","vpcmpq k1 {k2}, zmm, zmm/m512/m64bcst, imm8")]
    vpcmpq_k12_zmm_zmm_imm8 = 2624,
    /// <summary>
    /// vpcmpq k1 {k2}, zmm, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vpcmpq k12, zmm, m512, imm8","vpcmpq k1 {k2}, zmm, zmm/m512/m64bcst, imm8")]
    vpcmpq_k12_zmm_m512_imm8 = 2625,
    /// <summary>
    /// vpcmpq k1 {k2}, zmm, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vpcmpq k12, zmm, m64bcst, imm8","vpcmpq k1 {k2}, zmm, zmm/m512/m64bcst, imm8")]
    vpcmpq_k12_zmm_m64bcst_imm8 = 2626,
    /// <summary>
    /// vpcmpub k1 {k2}, xmm, xmm/m128, imm8
    /// </summary>
    [Symbol("vpcmpub k1, xmm, xmm, imm8","vpcmpub k1 {k2}, xmm, xmm/m128, imm8")]
    vpcmpub_k1_xmm_xmm_imm8 = 2627,
    /// <summary>
    /// vpcmpub k1 {k2}, xmm, xmm/m128, imm8
    /// </summary>
    [Symbol("vpcmpub k1, xmm, m128, imm8","vpcmpub k1 {k2}, xmm, xmm/m128, imm8")]
    vpcmpub_k1_xmm_m128_imm8 = 2628,
    /// <summary>
    /// vpcmpub k1 {k2}, xmm, xmm/m128, imm8
    /// </summary>
    [Symbol("vpcmpub k12, xmm, xmm, imm8","vpcmpub k1 {k2}, xmm, xmm/m128, imm8")]
    vpcmpub_k12_xmm_xmm_imm8 = 2629,
    /// <summary>
    /// vpcmpub k1 {k2}, xmm, xmm/m128, imm8
    /// </summary>
    [Symbol("vpcmpub k12, xmm, m128, imm8","vpcmpub k1 {k2}, xmm, xmm/m128, imm8")]
    vpcmpub_k12_xmm_m128_imm8 = 2630,
    /// <summary>
    /// vpcmpub k1 {k2}, ymm, ymm/m256, imm8
    /// </summary>
    [Symbol("vpcmpub k1, ymm, ymm, imm8","vpcmpub k1 {k2}, ymm, ymm/m256, imm8")]
    vpcmpub_k1_ymm_ymm_imm8 = 2631,
    /// <summary>
    /// vpcmpub k1 {k2}, ymm, ymm/m256, imm8
    /// </summary>
    [Symbol("vpcmpub k1, ymm, m256, imm8","vpcmpub k1 {k2}, ymm, ymm/m256, imm8")]
    vpcmpub_k1_ymm_m256_imm8 = 2632,
    /// <summary>
    /// vpcmpub k1 {k2}, ymm, ymm/m256, imm8
    /// </summary>
    [Symbol("vpcmpub k12, ymm, ymm, imm8","vpcmpub k1 {k2}, ymm, ymm/m256, imm8")]
    vpcmpub_k12_ymm_ymm_imm8 = 2633,
    /// <summary>
    /// vpcmpub k1 {k2}, ymm, ymm/m256, imm8
    /// </summary>
    [Symbol("vpcmpub k12, ymm, m256, imm8","vpcmpub k1 {k2}, ymm, ymm/m256, imm8")]
    vpcmpub_k12_ymm_m256_imm8 = 2634,
    /// <summary>
    /// vpcmpub k1 {k2}, zmm, zmm/m512, imm8
    /// </summary>
    [Symbol("vpcmpub k1, zmm, zmm, imm8","vpcmpub k1 {k2}, zmm, zmm/m512, imm8")]
    vpcmpub_k1_zmm_zmm_imm8 = 2635,
    /// <summary>
    /// vpcmpub k1 {k2}, zmm, zmm/m512, imm8
    /// </summary>
    [Symbol("vpcmpub k1, zmm, m512, imm8","vpcmpub k1 {k2}, zmm, zmm/m512, imm8")]
    vpcmpub_k1_zmm_m512_imm8 = 2636,
    /// <summary>
    /// vpcmpub k1 {k2}, zmm, zmm/m512, imm8
    /// </summary>
    [Symbol("vpcmpub k12, zmm, zmm, imm8","vpcmpub k1 {k2}, zmm, zmm/m512, imm8")]
    vpcmpub_k12_zmm_zmm_imm8 = 2637,
    /// <summary>
    /// vpcmpub k1 {k2}, zmm, zmm/m512, imm8
    /// </summary>
    [Symbol("vpcmpub k12, zmm, m512, imm8","vpcmpub k1 {k2}, zmm, zmm/m512, imm8")]
    vpcmpub_k12_zmm_m512_imm8 = 2638,
    /// <summary>
    /// vpcmpud k1 {k2}, xmm, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vpcmpud k1, xmm, xmm, imm8","vpcmpud k1 {k2}, xmm, xmm/m128/m32bcst, imm8")]
    vpcmpud_k1_xmm_xmm_imm8 = 2639,
    /// <summary>
    /// vpcmpud k1 {k2}, xmm, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vpcmpud k1, xmm, m128, imm8","vpcmpud k1 {k2}, xmm, xmm/m128/m32bcst, imm8")]
    vpcmpud_k1_xmm_m128_imm8 = 2640,
    /// <summary>
    /// vpcmpud k1 {k2}, xmm, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vpcmpud k1, xmm, m32bcst, imm8","vpcmpud k1 {k2}, xmm, xmm/m128/m32bcst, imm8")]
    vpcmpud_k1_xmm_m32bcst_imm8 = 2641,
    /// <summary>
    /// vpcmpud k1 {k2}, xmm, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vpcmpud k12, xmm, xmm, imm8","vpcmpud k1 {k2}, xmm, xmm/m128/m32bcst, imm8")]
    vpcmpud_k12_xmm_xmm_imm8 = 2642,
    /// <summary>
    /// vpcmpud k1 {k2}, xmm, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vpcmpud k12, xmm, m128, imm8","vpcmpud k1 {k2}, xmm, xmm/m128/m32bcst, imm8")]
    vpcmpud_k12_xmm_m128_imm8 = 2643,
    /// <summary>
    /// vpcmpud k1 {k2}, xmm, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vpcmpud k12, xmm, m32bcst, imm8","vpcmpud k1 {k2}, xmm, xmm/m128/m32bcst, imm8")]
    vpcmpud_k12_xmm_m32bcst_imm8 = 2644,
    /// <summary>
    /// vpcmpud k1 {k2}, ymm, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vpcmpud k1, ymm, ymm, imm8","vpcmpud k1 {k2}, ymm, ymm/m256/m32bcst, imm8")]
    vpcmpud_k1_ymm_ymm_imm8 = 2645,
    /// <summary>
    /// vpcmpud k1 {k2}, ymm, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vpcmpud k1, ymm, m256, imm8","vpcmpud k1 {k2}, ymm, ymm/m256/m32bcst, imm8")]
    vpcmpud_k1_ymm_m256_imm8 = 2646,
    /// <summary>
    /// vpcmpud k1 {k2}, ymm, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vpcmpud k1, ymm, m32bcst, imm8","vpcmpud k1 {k2}, ymm, ymm/m256/m32bcst, imm8")]
    vpcmpud_k1_ymm_m32bcst_imm8 = 2647,
    /// <summary>
    /// vpcmpud k1 {k2}, ymm, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vpcmpud k12, ymm, ymm, imm8","vpcmpud k1 {k2}, ymm, ymm/m256/m32bcst, imm8")]
    vpcmpud_k12_ymm_ymm_imm8 = 2648,
    /// <summary>
    /// vpcmpud k1 {k2}, ymm, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vpcmpud k12, ymm, m256, imm8","vpcmpud k1 {k2}, ymm, ymm/m256/m32bcst, imm8")]
    vpcmpud_k12_ymm_m256_imm8 = 2649,
    /// <summary>
    /// vpcmpud k1 {k2}, ymm, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vpcmpud k12, ymm, m32bcst, imm8","vpcmpud k1 {k2}, ymm, ymm/m256/m32bcst, imm8")]
    vpcmpud_k12_ymm_m32bcst_imm8 = 2650,
    /// <summary>
    /// vpcmpud k1 {k2}, zmm, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vpcmpud k1, zmm, zmm, imm8","vpcmpud k1 {k2}, zmm, zmm/m512/m32bcst, imm8")]
    vpcmpud_k1_zmm_zmm_imm8 = 2651,
    /// <summary>
    /// vpcmpud k1 {k2}, zmm, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vpcmpud k1, zmm, m512, imm8","vpcmpud k1 {k2}, zmm, zmm/m512/m32bcst, imm8")]
    vpcmpud_k1_zmm_m512_imm8 = 2652,
    /// <summary>
    /// vpcmpud k1 {k2}, zmm, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vpcmpud k1, zmm, m32bcst, imm8","vpcmpud k1 {k2}, zmm, zmm/m512/m32bcst, imm8")]
    vpcmpud_k1_zmm_m32bcst_imm8 = 2653,
    /// <summary>
    /// vpcmpud k1 {k2}, zmm, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vpcmpud k12, zmm, zmm, imm8","vpcmpud k1 {k2}, zmm, zmm/m512/m32bcst, imm8")]
    vpcmpud_k12_zmm_zmm_imm8 = 2654,
    /// <summary>
    /// vpcmpud k1 {k2}, zmm, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vpcmpud k12, zmm, m512, imm8","vpcmpud k1 {k2}, zmm, zmm/m512/m32bcst, imm8")]
    vpcmpud_k12_zmm_m512_imm8 = 2655,
    /// <summary>
    /// vpcmpud k1 {k2}, zmm, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vpcmpud k12, zmm, m32bcst, imm8","vpcmpud k1 {k2}, zmm, zmm/m512/m32bcst, imm8")]
    vpcmpud_k12_zmm_m32bcst_imm8 = 2656,
    /// <summary>
    /// vpcmpuq k1 {k2}, xmm, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("vpcmpuq k1, xmm, xmm, imm8","vpcmpuq k1 {k2}, xmm, xmm/m128/m64bcst, imm8")]
    vpcmpuq_k1_xmm_xmm_imm8 = 2657,
    /// <summary>
    /// vpcmpuq k1 {k2}, xmm, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("vpcmpuq k1, xmm, m128, imm8","vpcmpuq k1 {k2}, xmm, xmm/m128/m64bcst, imm8")]
    vpcmpuq_k1_xmm_m128_imm8 = 2658,
    /// <summary>
    /// vpcmpuq k1 {k2}, xmm, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("vpcmpuq k1, xmm, m64bcst, imm8","vpcmpuq k1 {k2}, xmm, xmm/m128/m64bcst, imm8")]
    vpcmpuq_k1_xmm_m64bcst_imm8 = 2659,
    /// <summary>
    /// vpcmpuq k1 {k2}, xmm, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("vpcmpuq k12, xmm, xmm, imm8","vpcmpuq k1 {k2}, xmm, xmm/m128/m64bcst, imm8")]
    vpcmpuq_k12_xmm_xmm_imm8 = 2660,
    /// <summary>
    /// vpcmpuq k1 {k2}, xmm, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("vpcmpuq k12, xmm, m128, imm8","vpcmpuq k1 {k2}, xmm, xmm/m128/m64bcst, imm8")]
    vpcmpuq_k12_xmm_m128_imm8 = 2661,
    /// <summary>
    /// vpcmpuq k1 {k2}, xmm, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("vpcmpuq k12, xmm, m64bcst, imm8","vpcmpuq k1 {k2}, xmm, xmm/m128/m64bcst, imm8")]
    vpcmpuq_k12_xmm_m64bcst_imm8 = 2662,
    /// <summary>
    /// vpcmpuq k1 {k2}, ymm, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vpcmpuq k1, ymm, ymm, imm8","vpcmpuq k1 {k2}, ymm, ymm/m256/m64bcst, imm8")]
    vpcmpuq_k1_ymm_ymm_imm8 = 2663,
    /// <summary>
    /// vpcmpuq k1 {k2}, ymm, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vpcmpuq k1, ymm, m256, imm8","vpcmpuq k1 {k2}, ymm, ymm/m256/m64bcst, imm8")]
    vpcmpuq_k1_ymm_m256_imm8 = 2664,
    /// <summary>
    /// vpcmpuq k1 {k2}, ymm, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vpcmpuq k1, ymm, m64bcst, imm8","vpcmpuq k1 {k2}, ymm, ymm/m256/m64bcst, imm8")]
    vpcmpuq_k1_ymm_m64bcst_imm8 = 2665,
    /// <summary>
    /// vpcmpuq k1 {k2}, ymm, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vpcmpuq k12, ymm, ymm, imm8","vpcmpuq k1 {k2}, ymm, ymm/m256/m64bcst, imm8")]
    vpcmpuq_k12_ymm_ymm_imm8 = 2666,
    /// <summary>
    /// vpcmpuq k1 {k2}, ymm, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vpcmpuq k12, ymm, m256, imm8","vpcmpuq k1 {k2}, ymm, ymm/m256/m64bcst, imm8")]
    vpcmpuq_k12_ymm_m256_imm8 = 2667,
    /// <summary>
    /// vpcmpuq k1 {k2}, ymm, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vpcmpuq k12, ymm, m64bcst, imm8","vpcmpuq k1 {k2}, ymm, ymm/m256/m64bcst, imm8")]
    vpcmpuq_k12_ymm_m64bcst_imm8 = 2668,
    /// <summary>
    /// vpcmpuq k1 {k2}, zmm, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vpcmpuq k1, zmm, zmm, imm8","vpcmpuq k1 {k2}, zmm, zmm/m512/m64bcst, imm8")]
    vpcmpuq_k1_zmm_zmm_imm8 = 2669,
    /// <summary>
    /// vpcmpuq k1 {k2}, zmm, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vpcmpuq k1, zmm, m512, imm8","vpcmpuq k1 {k2}, zmm, zmm/m512/m64bcst, imm8")]
    vpcmpuq_k1_zmm_m512_imm8 = 2670,
    /// <summary>
    /// vpcmpuq k1 {k2}, zmm, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vpcmpuq k1, zmm, m64bcst, imm8","vpcmpuq k1 {k2}, zmm, zmm/m512/m64bcst, imm8")]
    vpcmpuq_k1_zmm_m64bcst_imm8 = 2671,
    /// <summary>
    /// vpcmpuq k1 {k2}, zmm, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vpcmpuq k12, zmm, zmm, imm8","vpcmpuq k1 {k2}, zmm, zmm/m512/m64bcst, imm8")]
    vpcmpuq_k12_zmm_zmm_imm8 = 2672,
    /// <summary>
    /// vpcmpuq k1 {k2}, zmm, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vpcmpuq k12, zmm, m512, imm8","vpcmpuq k1 {k2}, zmm, zmm/m512/m64bcst, imm8")]
    vpcmpuq_k12_zmm_m512_imm8 = 2673,
    /// <summary>
    /// vpcmpuq k1 {k2}, zmm, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vpcmpuq k12, zmm, m64bcst, imm8","vpcmpuq k1 {k2}, zmm, zmm/m512/m64bcst, imm8")]
    vpcmpuq_k12_zmm_m64bcst_imm8 = 2674,
    /// <summary>
    /// vpcmpuw k1 {k2}, xmm, xmm/m128, imm8
    /// </summary>
    [Symbol("vpcmpuw k1, xmm, xmm, imm8","vpcmpuw k1 {k2}, xmm, xmm/m128, imm8")]
    vpcmpuw_k1_xmm_xmm_imm8 = 2675,
    /// <summary>
    /// vpcmpuw k1 {k2}, xmm, xmm/m128, imm8
    /// </summary>
    [Symbol("vpcmpuw k1, xmm, m128, imm8","vpcmpuw k1 {k2}, xmm, xmm/m128, imm8")]
    vpcmpuw_k1_xmm_m128_imm8 = 2676,
    /// <summary>
    /// vpcmpuw k1 {k2}, xmm, xmm/m128, imm8
    /// </summary>
    [Symbol("vpcmpuw k12, xmm, xmm, imm8","vpcmpuw k1 {k2}, xmm, xmm/m128, imm8")]
    vpcmpuw_k12_xmm_xmm_imm8 = 2677,
    /// <summary>
    /// vpcmpuw k1 {k2}, xmm, xmm/m128, imm8
    /// </summary>
    [Symbol("vpcmpuw k12, xmm, m128, imm8","vpcmpuw k1 {k2}, xmm, xmm/m128, imm8")]
    vpcmpuw_k12_xmm_m128_imm8 = 2678,
    /// <summary>
    /// vpcmpuw k1 {k2}, ymm, ymm/m256, imm8
    /// </summary>
    [Symbol("vpcmpuw k1, ymm, ymm, imm8","vpcmpuw k1 {k2}, ymm, ymm/m256, imm8")]
    vpcmpuw_k1_ymm_ymm_imm8 = 2679,
    /// <summary>
    /// vpcmpuw k1 {k2}, ymm, ymm/m256, imm8
    /// </summary>
    [Symbol("vpcmpuw k1, ymm, m256, imm8","vpcmpuw k1 {k2}, ymm, ymm/m256, imm8")]
    vpcmpuw_k1_ymm_m256_imm8 = 2680,
    /// <summary>
    /// vpcmpuw k1 {k2}, ymm, ymm/m256, imm8
    /// </summary>
    [Symbol("vpcmpuw k12, ymm, ymm, imm8","vpcmpuw k1 {k2}, ymm, ymm/m256, imm8")]
    vpcmpuw_k12_ymm_ymm_imm8 = 2681,
    /// <summary>
    /// vpcmpuw k1 {k2}, ymm, ymm/m256, imm8
    /// </summary>
    [Symbol("vpcmpuw k12, ymm, m256, imm8","vpcmpuw k1 {k2}, ymm, ymm/m256, imm8")]
    vpcmpuw_k12_ymm_m256_imm8 = 2682,
    /// <summary>
    /// vpcmpuw k1 {k2}, zmm, zmm/m512, imm8
    /// </summary>
    [Symbol("vpcmpuw k1, zmm, zmm, imm8","vpcmpuw k1 {k2}, zmm, zmm/m512, imm8")]
    vpcmpuw_k1_zmm_zmm_imm8 = 2683,
    /// <summary>
    /// vpcmpuw k1 {k2}, zmm, zmm/m512, imm8
    /// </summary>
    [Symbol("vpcmpuw k1, zmm, m512, imm8","vpcmpuw k1 {k2}, zmm, zmm/m512, imm8")]
    vpcmpuw_k1_zmm_m512_imm8 = 2684,
    /// <summary>
    /// vpcmpuw k1 {k2}, zmm, zmm/m512, imm8
    /// </summary>
    [Symbol("vpcmpuw k12, zmm, zmm, imm8","vpcmpuw k1 {k2}, zmm, zmm/m512, imm8")]
    vpcmpuw_k12_zmm_zmm_imm8 = 2685,
    /// <summary>
    /// vpcmpuw k1 {k2}, zmm, zmm/m512, imm8
    /// </summary>
    [Symbol("vpcmpuw k12, zmm, m512, imm8","vpcmpuw k1 {k2}, zmm, zmm/m512, imm8")]
    vpcmpuw_k12_zmm_m512_imm8 = 2686,
    /// <summary>
    /// vpcmpw k1 {k2}, xmm, xmm/m128, imm8
    /// </summary>
    [Symbol("vpcmpw k1, xmm, xmm, imm8","vpcmpw k1 {k2}, xmm, xmm/m128, imm8")]
    vpcmpw_k1_xmm_xmm_imm8 = 2687,
    /// <summary>
    /// vpcmpw k1 {k2}, xmm, xmm/m128, imm8
    /// </summary>
    [Symbol("vpcmpw k1, xmm, m128, imm8","vpcmpw k1 {k2}, xmm, xmm/m128, imm8")]
    vpcmpw_k1_xmm_m128_imm8 = 2688,
    /// <summary>
    /// vpcmpw k1 {k2}, xmm, xmm/m128, imm8
    /// </summary>
    [Symbol("vpcmpw k12, xmm, xmm, imm8","vpcmpw k1 {k2}, xmm, xmm/m128, imm8")]
    vpcmpw_k12_xmm_xmm_imm8 = 2689,
    /// <summary>
    /// vpcmpw k1 {k2}, xmm, xmm/m128, imm8
    /// </summary>
    [Symbol("vpcmpw k12, xmm, m128, imm8","vpcmpw k1 {k2}, xmm, xmm/m128, imm8")]
    vpcmpw_k12_xmm_m128_imm8 = 2690,
    /// <summary>
    /// vpcmpw k1 {k2}, ymm, ymm/m256, imm8
    /// </summary>
    [Symbol("vpcmpw k1, ymm, ymm, imm8","vpcmpw k1 {k2}, ymm, ymm/m256, imm8")]
    vpcmpw_k1_ymm_ymm_imm8 = 2691,
    /// <summary>
    /// vpcmpw k1 {k2}, ymm, ymm/m256, imm8
    /// </summary>
    [Symbol("vpcmpw k1, ymm, m256, imm8","vpcmpw k1 {k2}, ymm, ymm/m256, imm8")]
    vpcmpw_k1_ymm_m256_imm8 = 2692,
    /// <summary>
    /// vpcmpw k1 {k2}, ymm, ymm/m256, imm8
    /// </summary>
    [Symbol("vpcmpw k12, ymm, ymm, imm8","vpcmpw k1 {k2}, ymm, ymm/m256, imm8")]
    vpcmpw_k12_ymm_ymm_imm8 = 2693,
    /// <summary>
    /// vpcmpw k1 {k2}, ymm, ymm/m256, imm8
    /// </summary>
    [Symbol("vpcmpw k12, ymm, m256, imm8","vpcmpw k1 {k2}, ymm, ymm/m256, imm8")]
    vpcmpw_k12_ymm_m256_imm8 = 2694,
    /// <summary>
    /// vpcmpw k1 {k2}, zmm, zmm/m512, imm8
    /// </summary>
    [Symbol("vpcmpw k1, zmm, zmm, imm8","vpcmpw k1 {k2}, zmm, zmm/m512, imm8")]
    vpcmpw_k1_zmm_zmm_imm8 = 2695,
    /// <summary>
    /// vpcmpw k1 {k2}, zmm, zmm/m512, imm8
    /// </summary>
    [Symbol("vpcmpw k1, zmm, m512, imm8","vpcmpw k1 {k2}, zmm, zmm/m512, imm8")]
    vpcmpw_k1_zmm_m512_imm8 = 2696,
    /// <summary>
    /// vpcmpw k1 {k2}, zmm, zmm/m512, imm8
    /// </summary>
    [Symbol("vpcmpw k12, zmm, zmm, imm8","vpcmpw k1 {k2}, zmm, zmm/m512, imm8")]
    vpcmpw_k12_zmm_zmm_imm8 = 2697,
    /// <summary>
    /// vpcmpw k1 {k2}, zmm, zmm/m512, imm8
    /// </summary>
    [Symbol("vpcmpw k12, zmm, m512, imm8","vpcmpw k1 {k2}, zmm, zmm/m512, imm8")]
    vpcmpw_k12_zmm_m512_imm8 = 2698,
    /// <summary>
    /// vpcompressd xmm/m128 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpcompressd xmm_k1z, xmm","vpcompressd xmm/m128 {k1}{z}, xmm")]
    vpcompressd_xmm_k1z_xmm = 2699,
    /// <summary>
    /// vpcompressd xmm/m128 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpcompressd m128_k1z, xmm","vpcompressd xmm/m128 {k1}{z}, xmm")]
    vpcompressd_m128_k1z_xmm = 2700,
    /// <summary>
    /// vpcompressd ymm/m256 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpcompressd ymm_k1z, ymm","vpcompressd ymm/m256 {k1}{z}, ymm")]
    vpcompressd_ymm_k1z_ymm = 2701,
    /// <summary>
    /// vpcompressd ymm/m256 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpcompressd m256_k1z, ymm","vpcompressd ymm/m256 {k1}{z}, ymm")]
    vpcompressd_m256_k1z_ymm = 2702,
    /// <summary>
    /// vpcompressd zmm/m512 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpcompressd zmm_k1z, zmm","vpcompressd zmm/m512 {k1}{z}, zmm")]
    vpcompressd_zmm_k1z_zmm = 2703,
    /// <summary>
    /// vpcompressd zmm/m512 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpcompressd m512_k1z, zmm","vpcompressd zmm/m512 {k1}{z}, zmm")]
    vpcompressd_m512_k1z_zmm = 2704,
    /// <summary>
    /// vpcompressq xmm/m128 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpcompressq xmm_k1z, xmm","vpcompressq xmm/m128 {k1}{z}, xmm")]
    vpcompressq_xmm_k1z_xmm = 2705,
    /// <summary>
    /// vpcompressq xmm/m128 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpcompressq m128_k1z, xmm","vpcompressq xmm/m128 {k1}{z}, xmm")]
    vpcompressq_m128_k1z_xmm = 2706,
    /// <summary>
    /// vpcompressq ymm/m256 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpcompressq ymm_k1z, ymm","vpcompressq ymm/m256 {k1}{z}, ymm")]
    vpcompressq_ymm_k1z_ymm = 2707,
    /// <summary>
    /// vpcompressq ymm/m256 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpcompressq m256_k1z, ymm","vpcompressq ymm/m256 {k1}{z}, ymm")]
    vpcompressq_m256_k1z_ymm = 2708,
    /// <summary>
    /// vpcompressq zmm/m512 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpcompressq zmm_k1z, zmm","vpcompressq zmm/m512 {k1}{z}, zmm")]
    vpcompressq_zmm_k1z_zmm = 2709,
    /// <summary>
    /// vpcompressq zmm/m512 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpcompressq m512_k1z, zmm","vpcompressq zmm/m512 {k1}{z}, zmm")]
    vpcompressq_m512_k1z_zmm = 2710,
    /// <summary>
    /// vpconflictd xmm {k1}{z}, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpconflictd xmm, xmm","vpconflictd xmm {k1}{z}, xmm/m128/m32bcst")]
    vpconflictd_xmm_xmm = 2711,
    /// <summary>
    /// vpconflictd xmm {k1}{z}, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpconflictd xmm, m128","vpconflictd xmm {k1}{z}, xmm/m128/m32bcst")]
    vpconflictd_xmm_m128 = 2712,
    /// <summary>
    /// vpconflictd xmm {k1}{z}, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpconflictd xmm, m32bcst","vpconflictd xmm {k1}{z}, xmm/m128/m32bcst")]
    vpconflictd_xmm_m32bcst = 2713,
    /// <summary>
    /// vpconflictd xmm {k1}{z}, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpconflictd xmm_k1z, xmm","vpconflictd xmm {k1}{z}, xmm/m128/m32bcst")]
    vpconflictd_xmm_k1z_xmm = 2714,
    /// <summary>
    /// vpconflictd xmm {k1}{z}, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpconflictd xmm_k1z, m128","vpconflictd xmm {k1}{z}, xmm/m128/m32bcst")]
    vpconflictd_xmm_k1z_m128 = 2715,
    /// <summary>
    /// vpconflictd xmm {k1}{z}, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpconflictd xmm_k1z, m32bcst","vpconflictd xmm {k1}{z}, xmm/m128/m32bcst")]
    vpconflictd_xmm_k1z_m32bcst = 2716,
    /// <summary>
    /// vpconflictd ymm {k1}{z}, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpconflictd ymm, ymm","vpconflictd ymm {k1}{z}, ymm/m256/m32bcst")]
    vpconflictd_ymm_ymm = 2717,
    /// <summary>
    /// vpconflictd ymm {k1}{z}, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpconflictd ymm, m256","vpconflictd ymm {k1}{z}, ymm/m256/m32bcst")]
    vpconflictd_ymm_m256 = 2718,
    /// <summary>
    /// vpconflictd ymm {k1}{z}, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpconflictd ymm, m32bcst","vpconflictd ymm {k1}{z}, ymm/m256/m32bcst")]
    vpconflictd_ymm_m32bcst = 2719,
    /// <summary>
    /// vpconflictd ymm {k1}{z}, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpconflictd ymm_k1z, ymm","vpconflictd ymm {k1}{z}, ymm/m256/m32bcst")]
    vpconflictd_ymm_k1z_ymm = 2720,
    /// <summary>
    /// vpconflictd ymm {k1}{z}, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpconflictd ymm_k1z, m256","vpconflictd ymm {k1}{z}, ymm/m256/m32bcst")]
    vpconflictd_ymm_k1z_m256 = 2721,
    /// <summary>
    /// vpconflictd ymm {k1}{z}, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpconflictd ymm_k1z, m32bcst","vpconflictd ymm {k1}{z}, ymm/m256/m32bcst")]
    vpconflictd_ymm_k1z_m32bcst = 2722,
    /// <summary>
    /// vpconflictd zmm {k1}{z}, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpconflictd zmm, zmm","vpconflictd zmm {k1}{z}, zmm/m512/m32bcst")]
    vpconflictd_zmm_zmm = 2723,
    /// <summary>
    /// vpconflictd zmm {k1}{z}, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpconflictd zmm, m512","vpconflictd zmm {k1}{z}, zmm/m512/m32bcst")]
    vpconflictd_zmm_m512 = 2724,
    /// <summary>
    /// vpconflictd zmm {k1}{z}, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpconflictd zmm, m32bcst","vpconflictd zmm {k1}{z}, zmm/m512/m32bcst")]
    vpconflictd_zmm_m32bcst = 2725,
    /// <summary>
    /// vpconflictd zmm {k1}{z}, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpconflictd zmm_k1z, zmm","vpconflictd zmm {k1}{z}, zmm/m512/m32bcst")]
    vpconflictd_zmm_k1z_zmm = 2726,
    /// <summary>
    /// vpconflictd zmm {k1}{z}, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpconflictd zmm_k1z, m512","vpconflictd zmm {k1}{z}, zmm/m512/m32bcst")]
    vpconflictd_zmm_k1z_m512 = 2727,
    /// <summary>
    /// vpconflictd zmm {k1}{z}, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpconflictd zmm_k1z, m32bcst","vpconflictd zmm {k1}{z}, zmm/m512/m32bcst")]
    vpconflictd_zmm_k1z_m32bcst = 2728,
    /// <summary>
    /// vpconflictq xmm {k1}{z}, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpconflictq xmm, xmm","vpconflictq xmm {k1}{z}, xmm/m128/m64bcst")]
    vpconflictq_xmm_xmm = 2729,
    /// <summary>
    /// vpconflictq xmm {k1}{z}, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpconflictq xmm, m128","vpconflictq xmm {k1}{z}, xmm/m128/m64bcst")]
    vpconflictq_xmm_m128 = 2730,
    /// <summary>
    /// vpconflictq xmm {k1}{z}, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpconflictq xmm, m64bcst","vpconflictq xmm {k1}{z}, xmm/m128/m64bcst")]
    vpconflictq_xmm_m64bcst = 2731,
    /// <summary>
    /// vpconflictq xmm {k1}{z}, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpconflictq xmm_k1z, xmm","vpconflictq xmm {k1}{z}, xmm/m128/m64bcst")]
    vpconflictq_xmm_k1z_xmm = 2732,
    /// <summary>
    /// vpconflictq xmm {k1}{z}, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpconflictq xmm_k1z, m128","vpconflictq xmm {k1}{z}, xmm/m128/m64bcst")]
    vpconflictq_xmm_k1z_m128 = 2733,
    /// <summary>
    /// vpconflictq xmm {k1}{z}, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpconflictq xmm_k1z, m64bcst","vpconflictq xmm {k1}{z}, xmm/m128/m64bcst")]
    vpconflictq_xmm_k1z_m64bcst = 2734,
    /// <summary>
    /// vpconflictq ymm {k1}{z}, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpconflictq ymm, ymm","vpconflictq ymm {k1}{z}, ymm/m256/m64bcst")]
    vpconflictq_ymm_ymm = 2735,
    /// <summary>
    /// vpconflictq ymm {k1}{z}, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpconflictq ymm, m256","vpconflictq ymm {k1}{z}, ymm/m256/m64bcst")]
    vpconflictq_ymm_m256 = 2736,
    /// <summary>
    /// vpconflictq ymm {k1}{z}, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpconflictq ymm, m64bcst","vpconflictq ymm {k1}{z}, ymm/m256/m64bcst")]
    vpconflictq_ymm_m64bcst = 2737,
    /// <summary>
    /// vpconflictq ymm {k1}{z}, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpconflictq ymm_k1z, ymm","vpconflictq ymm {k1}{z}, ymm/m256/m64bcst")]
    vpconflictq_ymm_k1z_ymm = 2738,
    /// <summary>
    /// vpconflictq ymm {k1}{z}, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpconflictq ymm_k1z, m256","vpconflictq ymm {k1}{z}, ymm/m256/m64bcst")]
    vpconflictq_ymm_k1z_m256 = 2739,
    /// <summary>
    /// vpconflictq ymm {k1}{z}, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpconflictq ymm_k1z, m64bcst","vpconflictq ymm {k1}{z}, ymm/m256/m64bcst")]
    vpconflictq_ymm_k1z_m64bcst = 2740,
    /// <summary>
    /// vpconflictq zmm {k1}{z}, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpconflictq zmm, zmm","vpconflictq zmm {k1}{z}, zmm/m512/m64bcst")]
    vpconflictq_zmm_zmm = 2741,
    /// <summary>
    /// vpconflictq zmm {k1}{z}, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpconflictq zmm, m512","vpconflictq zmm {k1}{z}, zmm/m512/m64bcst")]
    vpconflictq_zmm_m512 = 2742,
    /// <summary>
    /// vpconflictq zmm {k1}{z}, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpconflictq zmm, m64bcst","vpconflictq zmm {k1}{z}, zmm/m512/m64bcst")]
    vpconflictq_zmm_m64bcst = 2743,
    /// <summary>
    /// vpconflictq zmm {k1}{z}, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpconflictq zmm_k1z, zmm","vpconflictq zmm {k1}{z}, zmm/m512/m64bcst")]
    vpconflictq_zmm_k1z_zmm = 2744,
    /// <summary>
    /// vpconflictq zmm {k1}{z}, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpconflictq zmm_k1z, m512","vpconflictq zmm {k1}{z}, zmm/m512/m64bcst")]
    vpconflictq_zmm_k1z_m512 = 2745,
    /// <summary>
    /// vpconflictq zmm {k1}{z}, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpconflictq zmm_k1z, m64bcst","vpconflictq zmm {k1}{z}, zmm/m512/m64bcst")]
    vpconflictq_zmm_k1z_m64bcst = 2746,
    /// <summary>
    /// vperm2i128 ymm, ymm, ymm/m256, imm8
    /// </summary>
    [Symbol("vperm2i128 ymm, ymm, ymm, imm8","vperm2i128 ymm, ymm, ymm/m256, imm8")]
    vperm2i128_ymm_ymm_ymm_imm8 = 2747,
    /// <summary>
    /// vperm2i128 ymm, ymm, ymm/m256, imm8
    /// </summary>
    [Symbol("vperm2i128 ymm, ymm, m256, imm8","vperm2i128 ymm, ymm, ymm/m256, imm8")]
    vperm2i128_ymm_ymm_m256_imm8 = 2748,
    /// <summary>
    /// vpermb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpermb xmm, xmm, xmm","vpermb xmm {k1}{z}, xmm, xmm/m128")]
    vpermb_xmm_xmm_xmm = 2749,
    /// <summary>
    /// vpermb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpermb xmm, xmm, m128","vpermb xmm {k1}{z}, xmm, xmm/m128")]
    vpermb_xmm_xmm_m128 = 2750,
    /// <summary>
    /// vpermb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpermb xmm_k1z, xmm, xmm","vpermb xmm {k1}{z}, xmm, xmm/m128")]
    vpermb_xmm_k1z_xmm_xmm = 2751,
    /// <summary>
    /// vpermb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpermb xmm_k1z, xmm, m128","vpermb xmm {k1}{z}, xmm, xmm/m128")]
    vpermb_xmm_k1z_xmm_m128 = 2752,
    /// <summary>
    /// vpermb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpermb ymm, ymm, ymm","vpermb ymm {k1}{z}, ymm, ymm/m256")]
    vpermb_ymm_ymm_ymm = 2753,
    /// <summary>
    /// vpermb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpermb ymm, ymm, m256","vpermb ymm {k1}{z}, ymm, ymm/m256")]
    vpermb_ymm_ymm_m256 = 2754,
    /// <summary>
    /// vpermb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpermb ymm_k1z, ymm, ymm","vpermb ymm {k1}{z}, ymm, ymm/m256")]
    vpermb_ymm_k1z_ymm_ymm = 2755,
    /// <summary>
    /// vpermb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpermb ymm_k1z, ymm, m256","vpermb ymm {k1}{z}, ymm, ymm/m256")]
    vpermb_ymm_k1z_ymm_m256 = 2756,
    /// <summary>
    /// vpermb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpermb zmm, zmm, zmm","vpermb zmm {k1}{z}, zmm, zmm/m512")]
    vpermb_zmm_zmm_zmm = 2757,
    /// <summary>
    /// vpermb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpermb zmm, zmm, m512","vpermb zmm {k1}{z}, zmm, zmm/m512")]
    vpermb_zmm_zmm_m512 = 2758,
    /// <summary>
    /// vpermb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpermb zmm_k1z, zmm, zmm","vpermb zmm {k1}{z}, zmm, zmm/m512")]
    vpermb_zmm_k1z_zmm_zmm = 2759,
    /// <summary>
    /// vpermb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpermb zmm_k1z, zmm, m512","vpermb zmm {k1}{z}, zmm, zmm/m512")]
    vpermb_zmm_k1z_zmm_m512 = 2760,
    /// <summary>
    /// vpermd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpermd ymm, ymm, ymm","vpermd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpermd_ymm_ymm_ymm = 2761,
    /// <summary>
    /// vpermd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpermd ymm, ymm, m256","vpermd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpermd_ymm_ymm_m256 = 2762,
    /// <summary>
    /// vpermd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpermd ymm, ymm, m32bcst","vpermd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpermd_ymm_ymm_m32bcst = 2763,
    /// <summary>
    /// vpermd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpermd ymm_k1z, ymm, ymm","vpermd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpermd_ymm_k1z_ymm_ymm = 2764,
    /// <summary>
    /// vpermd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpermd ymm_k1z, ymm, m256","vpermd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpermd_ymm_k1z_ymm_m256 = 2765,
    /// <summary>
    /// vpermd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpermd ymm_k1z, ymm, m32bcst","vpermd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpermd_ymm_k1z_ymm_m32bcst = 2766,
    /// <summary>
    /// vpermd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpermd zmm, zmm, zmm","vpermd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpermd_zmm_zmm_zmm = 2767,
    /// <summary>
    /// vpermd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpermd zmm, zmm, m512","vpermd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpermd_zmm_zmm_m512 = 2768,
    /// <summary>
    /// vpermd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpermd zmm, zmm, m32bcst","vpermd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpermd_zmm_zmm_m32bcst = 2769,
    /// <summary>
    /// vpermd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpermd zmm_k1z, zmm, zmm","vpermd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpermd_zmm_k1z_zmm_zmm = 2770,
    /// <summary>
    /// vpermd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpermd zmm_k1z, zmm, m512","vpermd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpermd_zmm_k1z_zmm_m512 = 2771,
    /// <summary>
    /// vpermd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpermd zmm_k1z, zmm, m32bcst","vpermd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpermd_zmm_k1z_zmm_m32bcst = 2772,
    /// <summary>
    /// vpermi2d xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpermi2d xmm, xmm, xmm","vpermi2d xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpermi2d_xmm_xmm_xmm = 2773,
    /// <summary>
    /// vpermi2d xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpermi2d xmm, xmm, m128","vpermi2d xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpermi2d_xmm_xmm_m128 = 2774,
    /// <summary>
    /// vpermi2d xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpermi2d xmm, xmm, m32bcst","vpermi2d xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpermi2d_xmm_xmm_m32bcst = 2775,
    /// <summary>
    /// vpermi2d xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpermi2d xmm_k1z, xmm, xmm","vpermi2d xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpermi2d_xmm_k1z_xmm_xmm = 2776,
    /// <summary>
    /// vpermi2d xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpermi2d xmm_k1z, xmm, m128","vpermi2d xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpermi2d_xmm_k1z_xmm_m128 = 2777,
    /// <summary>
    /// vpermi2d xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpermi2d xmm_k1z, xmm, m32bcst","vpermi2d xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpermi2d_xmm_k1z_xmm_m32bcst = 2778,
    /// <summary>
    /// vpermi2d ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpermi2d ymm, ymm, ymm","vpermi2d ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpermi2d_ymm_ymm_ymm = 2779,
    /// <summary>
    /// vpermi2d ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpermi2d ymm, ymm, m256","vpermi2d ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpermi2d_ymm_ymm_m256 = 2780,
    /// <summary>
    /// vpermi2d ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpermi2d ymm, ymm, m32bcst","vpermi2d ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpermi2d_ymm_ymm_m32bcst = 2781,
    /// <summary>
    /// vpermi2d ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpermi2d ymm_k1z, ymm, ymm","vpermi2d ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpermi2d_ymm_k1z_ymm_ymm = 2782,
    /// <summary>
    /// vpermi2d ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpermi2d ymm_k1z, ymm, m256","vpermi2d ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpermi2d_ymm_k1z_ymm_m256 = 2783,
    /// <summary>
    /// vpermi2d ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpermi2d ymm_k1z, ymm, m32bcst","vpermi2d ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpermi2d_ymm_k1z_ymm_m32bcst = 2784,
    /// <summary>
    /// vpermi2d zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpermi2d zmm, zmm, zmm","vpermi2d zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpermi2d_zmm_zmm_zmm = 2785,
    /// <summary>
    /// vpermi2d zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpermi2d zmm, zmm, m512","vpermi2d zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpermi2d_zmm_zmm_m512 = 2786,
    /// <summary>
    /// vpermi2d zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpermi2d zmm, zmm, m32bcst","vpermi2d zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpermi2d_zmm_zmm_m32bcst = 2787,
    /// <summary>
    /// vpermi2d zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpermi2d zmm_k1z, zmm, zmm","vpermi2d zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpermi2d_zmm_k1z_zmm_zmm = 2788,
    /// <summary>
    /// vpermi2d zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpermi2d zmm_k1z, zmm, m512","vpermi2d zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpermi2d_zmm_k1z_zmm_m512 = 2789,
    /// <summary>
    /// vpermi2d zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpermi2d zmm_k1z, zmm, m32bcst","vpermi2d zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpermi2d_zmm_k1z_zmm_m32bcst = 2790,
    /// <summary>
    /// vpermi2pd xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpermi2pd xmm, xmm, xmm","vpermi2pd xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpermi2pd_xmm_xmm_xmm = 2791,
    /// <summary>
    /// vpermi2pd xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpermi2pd xmm, xmm, m128","vpermi2pd xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpermi2pd_xmm_xmm_m128 = 2792,
    /// <summary>
    /// vpermi2pd xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpermi2pd xmm, xmm, m64bcst","vpermi2pd xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpermi2pd_xmm_xmm_m64bcst = 2793,
    /// <summary>
    /// vpermi2pd xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpermi2pd xmm_k1z, xmm, xmm","vpermi2pd xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpermi2pd_xmm_k1z_xmm_xmm = 2794,
    /// <summary>
    /// vpermi2pd xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpermi2pd xmm_k1z, xmm, m128","vpermi2pd xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpermi2pd_xmm_k1z_xmm_m128 = 2795,
    /// <summary>
    /// vpermi2pd xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpermi2pd xmm_k1z, xmm, m64bcst","vpermi2pd xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpermi2pd_xmm_k1z_xmm_m64bcst = 2796,
    /// <summary>
    /// vpermi2pd ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpermi2pd ymm, ymm, ymm","vpermi2pd ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpermi2pd_ymm_ymm_ymm = 2797,
    /// <summary>
    /// vpermi2pd ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpermi2pd ymm, ymm, m256","vpermi2pd ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpermi2pd_ymm_ymm_m256 = 2798,
    /// <summary>
    /// vpermi2pd ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpermi2pd ymm, ymm, m64bcst","vpermi2pd ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpermi2pd_ymm_ymm_m64bcst = 2799,
    /// <summary>
    /// vpermi2pd ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpermi2pd ymm_k1z, ymm, ymm","vpermi2pd ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpermi2pd_ymm_k1z_ymm_ymm = 2800,
    /// <summary>
    /// vpermi2pd ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpermi2pd ymm_k1z, ymm, m256","vpermi2pd ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpermi2pd_ymm_k1z_ymm_m256 = 2801,
    /// <summary>
    /// vpermi2pd ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpermi2pd ymm_k1z, ymm, m64bcst","vpermi2pd ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpermi2pd_ymm_k1z_ymm_m64bcst = 2802,
    /// <summary>
    /// vpermi2pd zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpermi2pd zmm, zmm, zmm","vpermi2pd zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpermi2pd_zmm_zmm_zmm = 2803,
    /// <summary>
    /// vpermi2pd zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpermi2pd zmm, zmm, m512","vpermi2pd zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpermi2pd_zmm_zmm_m512 = 2804,
    /// <summary>
    /// vpermi2pd zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpermi2pd zmm, zmm, m64bcst","vpermi2pd zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpermi2pd_zmm_zmm_m64bcst = 2805,
    /// <summary>
    /// vpermi2pd zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpermi2pd zmm_k1z, zmm, zmm","vpermi2pd zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpermi2pd_zmm_k1z_zmm_zmm = 2806,
    /// <summary>
    /// vpermi2pd zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpermi2pd zmm_k1z, zmm, m512","vpermi2pd zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpermi2pd_zmm_k1z_zmm_m512 = 2807,
    /// <summary>
    /// vpermi2pd zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpermi2pd zmm_k1z, zmm, m64bcst","vpermi2pd zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpermi2pd_zmm_k1z_zmm_m64bcst = 2808,
    /// <summary>
    /// vpermi2ps xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpermi2ps xmm, xmm, xmm","vpermi2ps xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpermi2ps_xmm_xmm_xmm = 2809,
    /// <summary>
    /// vpermi2ps xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpermi2ps xmm, xmm, m128","vpermi2ps xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpermi2ps_xmm_xmm_m128 = 2810,
    /// <summary>
    /// vpermi2ps xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpermi2ps xmm, xmm, m32bcst","vpermi2ps xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpermi2ps_xmm_xmm_m32bcst = 2811,
    /// <summary>
    /// vpermi2ps xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpermi2ps xmm_k1z, xmm, xmm","vpermi2ps xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpermi2ps_xmm_k1z_xmm_xmm = 2812,
    /// <summary>
    /// vpermi2ps xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpermi2ps xmm_k1z, xmm, m128","vpermi2ps xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpermi2ps_xmm_k1z_xmm_m128 = 2813,
    /// <summary>
    /// vpermi2ps xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpermi2ps xmm_k1z, xmm, m32bcst","vpermi2ps xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpermi2ps_xmm_k1z_xmm_m32bcst = 2814,
    /// <summary>
    /// vpermi2ps ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpermi2ps ymm, ymm, ymm","vpermi2ps ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpermi2ps_ymm_ymm_ymm = 2815,
    /// <summary>
    /// vpermi2ps ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpermi2ps ymm, ymm, m256","vpermi2ps ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpermi2ps_ymm_ymm_m256 = 2816,
    /// <summary>
    /// vpermi2ps ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpermi2ps ymm, ymm, m32bcst","vpermi2ps ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpermi2ps_ymm_ymm_m32bcst = 2817,
    /// <summary>
    /// vpermi2ps ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpermi2ps ymm_k1z, ymm, ymm","vpermi2ps ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpermi2ps_ymm_k1z_ymm_ymm = 2818,
    /// <summary>
    /// vpermi2ps ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpermi2ps ymm_k1z, ymm, m256","vpermi2ps ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpermi2ps_ymm_k1z_ymm_m256 = 2819,
    /// <summary>
    /// vpermi2ps ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpermi2ps ymm_k1z, ymm, m32bcst","vpermi2ps ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpermi2ps_ymm_k1z_ymm_m32bcst = 2820,
    /// <summary>
    /// vpermi2ps zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpermi2ps zmm, zmm, zmm","vpermi2ps zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpermi2ps_zmm_zmm_zmm = 2821,
    /// <summary>
    /// vpermi2ps zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpermi2ps zmm, zmm, m512","vpermi2ps zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpermi2ps_zmm_zmm_m512 = 2822,
    /// <summary>
    /// vpermi2ps zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpermi2ps zmm, zmm, m32bcst","vpermi2ps zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpermi2ps_zmm_zmm_m32bcst = 2823,
    /// <summary>
    /// vpermi2ps zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpermi2ps zmm_k1z, zmm, zmm","vpermi2ps zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpermi2ps_zmm_k1z_zmm_zmm = 2824,
    /// <summary>
    /// vpermi2ps zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpermi2ps zmm_k1z, zmm, m512","vpermi2ps zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpermi2ps_zmm_k1z_zmm_m512 = 2825,
    /// <summary>
    /// vpermi2ps zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpermi2ps zmm_k1z, zmm, m32bcst","vpermi2ps zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpermi2ps_zmm_k1z_zmm_m32bcst = 2826,
    /// <summary>
    /// vpermi2q xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpermi2q xmm, xmm, xmm","vpermi2q xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpermi2q_xmm_xmm_xmm = 2827,
    /// <summary>
    /// vpermi2q xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpermi2q xmm, xmm, m128","vpermi2q xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpermi2q_xmm_xmm_m128 = 2828,
    /// <summary>
    /// vpermi2q xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpermi2q xmm, xmm, m64bcst","vpermi2q xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpermi2q_xmm_xmm_m64bcst = 2829,
    /// <summary>
    /// vpermi2q xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpermi2q xmm_k1z, xmm, xmm","vpermi2q xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpermi2q_xmm_k1z_xmm_xmm = 2830,
    /// <summary>
    /// vpermi2q xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpermi2q xmm_k1z, xmm, m128","vpermi2q xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpermi2q_xmm_k1z_xmm_m128 = 2831,
    /// <summary>
    /// vpermi2q xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpermi2q xmm_k1z, xmm, m64bcst","vpermi2q xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpermi2q_xmm_k1z_xmm_m64bcst = 2832,
    /// <summary>
    /// vpermi2q ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpermi2q ymm, ymm, ymm","vpermi2q ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpermi2q_ymm_ymm_ymm = 2833,
    /// <summary>
    /// vpermi2q ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpermi2q ymm, ymm, m256","vpermi2q ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpermi2q_ymm_ymm_m256 = 2834,
    /// <summary>
    /// vpermi2q ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpermi2q ymm, ymm, m64bcst","vpermi2q ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpermi2q_ymm_ymm_m64bcst = 2835,
    /// <summary>
    /// vpermi2q ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpermi2q ymm_k1z, ymm, ymm","vpermi2q ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpermi2q_ymm_k1z_ymm_ymm = 2836,
    /// <summary>
    /// vpermi2q ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpermi2q ymm_k1z, ymm, m256","vpermi2q ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpermi2q_ymm_k1z_ymm_m256 = 2837,
    /// <summary>
    /// vpermi2q ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpermi2q ymm_k1z, ymm, m64bcst","vpermi2q ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpermi2q_ymm_k1z_ymm_m64bcst = 2838,
    /// <summary>
    /// vpermi2q zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpermi2q zmm, zmm, zmm","vpermi2q zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpermi2q_zmm_zmm_zmm = 2839,
    /// <summary>
    /// vpermi2q zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpermi2q zmm, zmm, m512","vpermi2q zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpermi2q_zmm_zmm_m512 = 2840,
    /// <summary>
    /// vpermi2q zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpermi2q zmm, zmm, m64bcst","vpermi2q zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpermi2q_zmm_zmm_m64bcst = 2841,
    /// <summary>
    /// vpermi2q zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpermi2q zmm_k1z, zmm, zmm","vpermi2q zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpermi2q_zmm_k1z_zmm_zmm = 2842,
    /// <summary>
    /// vpermi2q zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpermi2q zmm_k1z, zmm, m512","vpermi2q zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpermi2q_zmm_k1z_zmm_m512 = 2843,
    /// <summary>
    /// vpermi2q zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpermi2q zmm_k1z, zmm, m64bcst","vpermi2q zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpermi2q_zmm_k1z_zmm_m64bcst = 2844,
    /// <summary>
    /// vpermi2w xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpermi2w xmm, xmm, xmm","vpermi2w xmm {k1}{z}, xmm, xmm/m128")]
    vpermi2w_xmm_xmm_xmm = 2845,
    /// <summary>
    /// vpermi2w xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpermi2w xmm, xmm, m128","vpermi2w xmm {k1}{z}, xmm, xmm/m128")]
    vpermi2w_xmm_xmm_m128 = 2846,
    /// <summary>
    /// vpermi2w xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpermi2w xmm_k1z, xmm, xmm","vpermi2w xmm {k1}{z}, xmm, xmm/m128")]
    vpermi2w_xmm_k1z_xmm_xmm = 2847,
    /// <summary>
    /// vpermi2w xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpermi2w xmm_k1z, xmm, m128","vpermi2w xmm {k1}{z}, xmm, xmm/m128")]
    vpermi2w_xmm_k1z_xmm_m128 = 2848,
    /// <summary>
    /// vpermi2w ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpermi2w ymm, ymm, ymm","vpermi2w ymm {k1}{z}, ymm, ymm/m256")]
    vpermi2w_ymm_ymm_ymm = 2849,
    /// <summary>
    /// vpermi2w ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpermi2w ymm, ymm, m256","vpermi2w ymm {k1}{z}, ymm, ymm/m256")]
    vpermi2w_ymm_ymm_m256 = 2850,
    /// <summary>
    /// vpermi2w ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpermi2w ymm_k1z, ymm, ymm","vpermi2w ymm {k1}{z}, ymm, ymm/m256")]
    vpermi2w_ymm_k1z_ymm_ymm = 2851,
    /// <summary>
    /// vpermi2w ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpermi2w ymm_k1z, ymm, m256","vpermi2w ymm {k1}{z}, ymm, ymm/m256")]
    vpermi2w_ymm_k1z_ymm_m256 = 2852,
    /// <summary>
    /// vpermi2w zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpermi2w zmm, zmm, zmm","vpermi2w zmm {k1}{z}, zmm, zmm/m512")]
    vpermi2w_zmm_zmm_zmm = 2853,
    /// <summary>
    /// vpermi2w zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpermi2w zmm, zmm, m512","vpermi2w zmm {k1}{z}, zmm, zmm/m512")]
    vpermi2w_zmm_zmm_m512 = 2854,
    /// <summary>
    /// vpermi2w zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpermi2w zmm_k1z, zmm, zmm","vpermi2w zmm {k1}{z}, zmm, zmm/m512")]
    vpermi2w_zmm_k1z_zmm_zmm = 2855,
    /// <summary>
    /// vpermi2w zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpermi2w zmm_k1z, zmm, m512","vpermi2w zmm {k1}{z}, zmm, zmm/m512")]
    vpermi2w_zmm_k1z_zmm_m512 = 2856,
    /// <summary>
    /// vpermq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpermq ymm, ymm, ymm","vpermq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpermq_ymm_ymm_ymm = 2857,
    /// <summary>
    /// vpermq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpermq ymm, ymm, m256","vpermq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpermq_ymm_ymm_m256 = 2858,
    /// <summary>
    /// vpermq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpermq ymm, ymm, m64bcst","vpermq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpermq_ymm_ymm_m64bcst = 2859,
    /// <summary>
    /// vpermq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpermq ymm_k1z, ymm, ymm","vpermq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpermq_ymm_k1z_ymm_ymm = 2860,
    /// <summary>
    /// vpermq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpermq ymm_k1z, ymm, m256","vpermq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpermq_ymm_k1z_ymm_m256 = 2861,
    /// <summary>
    /// vpermq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpermq ymm_k1z, ymm, m64bcst","vpermq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpermq_ymm_k1z_ymm_m64bcst = 2862,
    /// <summary>
    /// vpermq ymm {k1}{z}, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vpermq ymm, ymm, imm8","vpermq ymm {k1}{z}, ymm/m256/m64bcst, imm8")]
    vpermq_ymm_ymm_imm8 = 2863,
    /// <summary>
    /// vpermq ymm {k1}{z}, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vpermq ymm, m256, imm8","vpermq ymm {k1}{z}, ymm/m256/m64bcst, imm8")]
    vpermq_ymm_m256_imm8 = 2864,
    /// <summary>
    /// vpermq ymm {k1}{z}, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vpermq ymm, m64bcst, imm8","vpermq ymm {k1}{z}, ymm/m256/m64bcst, imm8")]
    vpermq_ymm_m64bcst_imm8 = 2865,
    /// <summary>
    /// vpermq ymm {k1}{z}, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vpermq ymm_k1z, ymm, imm8","vpermq ymm {k1}{z}, ymm/m256/m64bcst, imm8")]
    vpermq_ymm_k1z_ymm_imm8 = 2866,
    /// <summary>
    /// vpermq ymm {k1}{z}, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vpermq ymm_k1z, m256, imm8","vpermq ymm {k1}{z}, ymm/m256/m64bcst, imm8")]
    vpermq_ymm_k1z_m256_imm8 = 2867,
    /// <summary>
    /// vpermq ymm {k1}{z}, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vpermq ymm_k1z, m64bcst, imm8","vpermq ymm {k1}{z}, ymm/m256/m64bcst, imm8")]
    vpermq_ymm_k1z_m64bcst_imm8 = 2868,
    /// <summary>
    /// vpermq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpermq zmm, zmm, zmm","vpermq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpermq_zmm_zmm_zmm = 2869,
    /// <summary>
    /// vpermq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpermq zmm, zmm, m512","vpermq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpermq_zmm_zmm_m512 = 2870,
    /// <summary>
    /// vpermq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpermq zmm, zmm, m64bcst","vpermq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpermq_zmm_zmm_m64bcst = 2871,
    /// <summary>
    /// vpermq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpermq zmm_k1z, zmm, zmm","vpermq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpermq_zmm_k1z_zmm_zmm = 2872,
    /// <summary>
    /// vpermq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpermq zmm_k1z, zmm, m512","vpermq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpermq_zmm_k1z_zmm_m512 = 2873,
    /// <summary>
    /// vpermq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpermq zmm_k1z, zmm, m64bcst","vpermq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpermq_zmm_k1z_zmm_m64bcst = 2874,
    /// <summary>
    /// vpermq zmm {k1}{z}, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vpermq zmm, zmm, imm8","vpermq zmm {k1}{z}, zmm/m512/m64bcst, imm8")]
    vpermq_zmm_zmm_imm8 = 2875,
    /// <summary>
    /// vpermq zmm {k1}{z}, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vpermq zmm, m512, imm8","vpermq zmm {k1}{z}, zmm/m512/m64bcst, imm8")]
    vpermq_zmm_m512_imm8 = 2876,
    /// <summary>
    /// vpermq zmm {k1}{z}, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vpermq zmm, m64bcst, imm8","vpermq zmm {k1}{z}, zmm/m512/m64bcst, imm8")]
    vpermq_zmm_m64bcst_imm8 = 2877,
    /// <summary>
    /// vpermq zmm {k1}{z}, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vpermq zmm_k1z, zmm, imm8","vpermq zmm {k1}{z}, zmm/m512/m64bcst, imm8")]
    vpermq_zmm_k1z_zmm_imm8 = 2878,
    /// <summary>
    /// vpermq zmm {k1}{z}, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vpermq zmm_k1z, m512, imm8","vpermq zmm {k1}{z}, zmm/m512/m64bcst, imm8")]
    vpermq_zmm_k1z_m512_imm8 = 2879,
    /// <summary>
    /// vpermq zmm {k1}{z}, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vpermq zmm_k1z, m64bcst, imm8","vpermq zmm {k1}{z}, zmm/m512/m64bcst, imm8")]
    vpermq_zmm_k1z_m64bcst_imm8 = 2880,
    /// <summary>
    /// vpermt2b xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpermt2b xmm, xmm, xmm","vpermt2b xmm {k1}{z}, xmm, xmm/m128")]
    vpermt2b_xmm_xmm_xmm = 2881,
    /// <summary>
    /// vpermt2b xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpermt2b xmm, xmm, m128","vpermt2b xmm {k1}{z}, xmm, xmm/m128")]
    vpermt2b_xmm_xmm_m128 = 2882,
    /// <summary>
    /// vpermt2b xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpermt2b xmm_k1z, xmm, xmm","vpermt2b xmm {k1}{z}, xmm, xmm/m128")]
    vpermt2b_xmm_k1z_xmm_xmm = 2883,
    /// <summary>
    /// vpermt2b xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpermt2b xmm_k1z, xmm, m128","vpermt2b xmm {k1}{z}, xmm, xmm/m128")]
    vpermt2b_xmm_k1z_xmm_m128 = 2884,
    /// <summary>
    /// vpermt2b ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpermt2b ymm, ymm, ymm","vpermt2b ymm {k1}{z}, ymm, ymm/m256")]
    vpermt2b_ymm_ymm_ymm = 2885,
    /// <summary>
    /// vpermt2b ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpermt2b ymm, ymm, m256","vpermt2b ymm {k1}{z}, ymm, ymm/m256")]
    vpermt2b_ymm_ymm_m256 = 2886,
    /// <summary>
    /// vpermt2b ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpermt2b ymm_k1z, ymm, ymm","vpermt2b ymm {k1}{z}, ymm, ymm/m256")]
    vpermt2b_ymm_k1z_ymm_ymm = 2887,
    /// <summary>
    /// vpermt2b ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpermt2b ymm_k1z, ymm, m256","vpermt2b ymm {k1}{z}, ymm, ymm/m256")]
    vpermt2b_ymm_k1z_ymm_m256 = 2888,
    /// <summary>
    /// vpermt2b zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpermt2b zmm, zmm, zmm","vpermt2b zmm {k1}{z}, zmm, zmm/m512")]
    vpermt2b_zmm_zmm_zmm = 2889,
    /// <summary>
    /// vpermt2b zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpermt2b zmm, zmm, m512","vpermt2b zmm {k1}{z}, zmm, zmm/m512")]
    vpermt2b_zmm_zmm_m512 = 2890,
    /// <summary>
    /// vpermt2b zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpermt2b zmm_k1z, zmm, zmm","vpermt2b zmm {k1}{z}, zmm, zmm/m512")]
    vpermt2b_zmm_k1z_zmm_zmm = 2891,
    /// <summary>
    /// vpermt2b zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpermt2b zmm_k1z, zmm, m512","vpermt2b zmm {k1}{z}, zmm, zmm/m512")]
    vpermt2b_zmm_k1z_zmm_m512 = 2892,
    /// <summary>
    /// vpermt2d xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpermt2d xmm, xmm, xmm","vpermt2d xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpermt2d_xmm_xmm_xmm = 2893,
    /// <summary>
    /// vpermt2d xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpermt2d xmm, xmm, m128","vpermt2d xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpermt2d_xmm_xmm_m128 = 2894,
    /// <summary>
    /// vpermt2d xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpermt2d xmm, xmm, m32bcst","vpermt2d xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpermt2d_xmm_xmm_m32bcst = 2895,
    /// <summary>
    /// vpermt2d xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpermt2d xmm_k1z, xmm, xmm","vpermt2d xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpermt2d_xmm_k1z_xmm_xmm = 2896,
    /// <summary>
    /// vpermt2d xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpermt2d xmm_k1z, xmm, m128","vpermt2d xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpermt2d_xmm_k1z_xmm_m128 = 2897,
    /// <summary>
    /// vpermt2d xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpermt2d xmm_k1z, xmm, m32bcst","vpermt2d xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpermt2d_xmm_k1z_xmm_m32bcst = 2898,
    /// <summary>
    /// vpermt2d ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpermt2d ymm, ymm, ymm","vpermt2d ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpermt2d_ymm_ymm_ymm = 2899,
    /// <summary>
    /// vpermt2d ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpermt2d ymm, ymm, m256","vpermt2d ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpermt2d_ymm_ymm_m256 = 2900,
    /// <summary>
    /// vpermt2d ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpermt2d ymm, ymm, m32bcst","vpermt2d ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpermt2d_ymm_ymm_m32bcst = 2901,
    /// <summary>
    /// vpermt2d ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpermt2d ymm_k1z, ymm, ymm","vpermt2d ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpermt2d_ymm_k1z_ymm_ymm = 2902,
    /// <summary>
    /// vpermt2d ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpermt2d ymm_k1z, ymm, m256","vpermt2d ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpermt2d_ymm_k1z_ymm_m256 = 2903,
    /// <summary>
    /// vpermt2d ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpermt2d ymm_k1z, ymm, m32bcst","vpermt2d ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpermt2d_ymm_k1z_ymm_m32bcst = 2904,
    /// <summary>
    /// vpermt2d zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpermt2d zmm, zmm, zmm","vpermt2d zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpermt2d_zmm_zmm_zmm = 2905,
    /// <summary>
    /// vpermt2d zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpermt2d zmm, zmm, m512","vpermt2d zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpermt2d_zmm_zmm_m512 = 2906,
    /// <summary>
    /// vpermt2d zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpermt2d zmm, zmm, m32bcst","vpermt2d zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpermt2d_zmm_zmm_m32bcst = 2907,
    /// <summary>
    /// vpermt2d zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpermt2d zmm_k1z, zmm, zmm","vpermt2d zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpermt2d_zmm_k1z_zmm_zmm = 2908,
    /// <summary>
    /// vpermt2d zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpermt2d zmm_k1z, zmm, m512","vpermt2d zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpermt2d_zmm_k1z_zmm_m512 = 2909,
    /// <summary>
    /// vpermt2d zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpermt2d zmm_k1z, zmm, m32bcst","vpermt2d zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpermt2d_zmm_k1z_zmm_m32bcst = 2910,
    /// <summary>
    /// vpermt2pd xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpermt2pd xmm, xmm, xmm","vpermt2pd xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpermt2pd_xmm_xmm_xmm = 2911,
    /// <summary>
    /// vpermt2pd xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpermt2pd xmm, xmm, m128","vpermt2pd xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpermt2pd_xmm_xmm_m128 = 2912,
    /// <summary>
    /// vpermt2pd xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpermt2pd xmm, xmm, m64bcst","vpermt2pd xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpermt2pd_xmm_xmm_m64bcst = 2913,
    /// <summary>
    /// vpermt2pd xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpermt2pd xmm_k1z, xmm, xmm","vpermt2pd xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpermt2pd_xmm_k1z_xmm_xmm = 2914,
    /// <summary>
    /// vpermt2pd xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpermt2pd xmm_k1z, xmm, m128","vpermt2pd xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpermt2pd_xmm_k1z_xmm_m128 = 2915,
    /// <summary>
    /// vpermt2pd xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpermt2pd xmm_k1z, xmm, m64bcst","vpermt2pd xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpermt2pd_xmm_k1z_xmm_m64bcst = 2916,
    /// <summary>
    /// vpermt2pd ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpermt2pd ymm, ymm, ymm","vpermt2pd ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpermt2pd_ymm_ymm_ymm = 2917,
    /// <summary>
    /// vpermt2pd ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpermt2pd ymm, ymm, m256","vpermt2pd ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpermt2pd_ymm_ymm_m256 = 2918,
    /// <summary>
    /// vpermt2pd ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpermt2pd ymm, ymm, m64bcst","vpermt2pd ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpermt2pd_ymm_ymm_m64bcst = 2919,
    /// <summary>
    /// vpermt2pd ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpermt2pd ymm_k1z, ymm, ymm","vpermt2pd ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpermt2pd_ymm_k1z_ymm_ymm = 2920,
    /// <summary>
    /// vpermt2pd ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpermt2pd ymm_k1z, ymm, m256","vpermt2pd ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpermt2pd_ymm_k1z_ymm_m256 = 2921,
    /// <summary>
    /// vpermt2pd ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpermt2pd ymm_k1z, ymm, m64bcst","vpermt2pd ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpermt2pd_ymm_k1z_ymm_m64bcst = 2922,
    /// <summary>
    /// vpermt2pd zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpermt2pd zmm, zmm, zmm","vpermt2pd zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpermt2pd_zmm_zmm_zmm = 2923,
    /// <summary>
    /// vpermt2pd zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpermt2pd zmm, zmm, m512","vpermt2pd zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpermt2pd_zmm_zmm_m512 = 2924,
    /// <summary>
    /// vpermt2pd zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpermt2pd zmm, zmm, m64bcst","vpermt2pd zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpermt2pd_zmm_zmm_m64bcst = 2925,
    /// <summary>
    /// vpermt2pd zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpermt2pd zmm_k1z, zmm, zmm","vpermt2pd zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpermt2pd_zmm_k1z_zmm_zmm = 2926,
    /// <summary>
    /// vpermt2pd zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpermt2pd zmm_k1z, zmm, m512","vpermt2pd zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpermt2pd_zmm_k1z_zmm_m512 = 2927,
    /// <summary>
    /// vpermt2pd zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpermt2pd zmm_k1z, zmm, m64bcst","vpermt2pd zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpermt2pd_zmm_k1z_zmm_m64bcst = 2928,
    /// <summary>
    /// vpermt2ps xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpermt2ps xmm, xmm, xmm","vpermt2ps xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpermt2ps_xmm_xmm_xmm = 2929,
    /// <summary>
    /// vpermt2ps xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpermt2ps xmm, xmm, m128","vpermt2ps xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpermt2ps_xmm_xmm_m128 = 2930,
    /// <summary>
    /// vpermt2ps xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpermt2ps xmm, xmm, m32bcst","vpermt2ps xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpermt2ps_xmm_xmm_m32bcst = 2931,
    /// <summary>
    /// vpermt2ps xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpermt2ps xmm_k1z, xmm, xmm","vpermt2ps xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpermt2ps_xmm_k1z_xmm_xmm = 2932,
    /// <summary>
    /// vpermt2ps xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpermt2ps xmm_k1z, xmm, m128","vpermt2ps xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpermt2ps_xmm_k1z_xmm_m128 = 2933,
    /// <summary>
    /// vpermt2ps xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpermt2ps xmm_k1z, xmm, m32bcst","vpermt2ps xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpermt2ps_xmm_k1z_xmm_m32bcst = 2934,
    /// <summary>
    /// vpermt2ps ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpermt2ps ymm, ymm, ymm","vpermt2ps ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpermt2ps_ymm_ymm_ymm = 2935,
    /// <summary>
    /// vpermt2ps ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpermt2ps ymm, ymm, m256","vpermt2ps ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpermt2ps_ymm_ymm_m256 = 2936,
    /// <summary>
    /// vpermt2ps ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpermt2ps ymm, ymm, m32bcst","vpermt2ps ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpermt2ps_ymm_ymm_m32bcst = 2937,
    /// <summary>
    /// vpermt2ps ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpermt2ps ymm_k1z, ymm, ymm","vpermt2ps ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpermt2ps_ymm_k1z_ymm_ymm = 2938,
    /// <summary>
    /// vpermt2ps ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpermt2ps ymm_k1z, ymm, m256","vpermt2ps ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpermt2ps_ymm_k1z_ymm_m256 = 2939,
    /// <summary>
    /// vpermt2ps ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpermt2ps ymm_k1z, ymm, m32bcst","vpermt2ps ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpermt2ps_ymm_k1z_ymm_m32bcst = 2940,
    /// <summary>
    /// vpermt2ps zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpermt2ps zmm, zmm, zmm","vpermt2ps zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpermt2ps_zmm_zmm_zmm = 2941,
    /// <summary>
    /// vpermt2ps zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpermt2ps zmm, zmm, m512","vpermt2ps zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpermt2ps_zmm_zmm_m512 = 2942,
    /// <summary>
    /// vpermt2ps zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpermt2ps zmm, zmm, m32bcst","vpermt2ps zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpermt2ps_zmm_zmm_m32bcst = 2943,
    /// <summary>
    /// vpermt2ps zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpermt2ps zmm_k1z, zmm, zmm","vpermt2ps zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpermt2ps_zmm_k1z_zmm_zmm = 2944,
    /// <summary>
    /// vpermt2ps zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpermt2ps zmm_k1z, zmm, m512","vpermt2ps zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpermt2ps_zmm_k1z_zmm_m512 = 2945,
    /// <summary>
    /// vpermt2ps zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpermt2ps zmm_k1z, zmm, m32bcst","vpermt2ps zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpermt2ps_zmm_k1z_zmm_m32bcst = 2946,
    /// <summary>
    /// vpermt2q xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpermt2q xmm, xmm, xmm","vpermt2q xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpermt2q_xmm_xmm_xmm = 2947,
    /// <summary>
    /// vpermt2q xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpermt2q xmm, xmm, m128","vpermt2q xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpermt2q_xmm_xmm_m128 = 2948,
    /// <summary>
    /// vpermt2q xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpermt2q xmm, xmm, m64bcst","vpermt2q xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpermt2q_xmm_xmm_m64bcst = 2949,
    /// <summary>
    /// vpermt2q xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpermt2q xmm_k1z, xmm, xmm","vpermt2q xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpermt2q_xmm_k1z_xmm_xmm = 2950,
    /// <summary>
    /// vpermt2q xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpermt2q xmm_k1z, xmm, m128","vpermt2q xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpermt2q_xmm_k1z_xmm_m128 = 2951,
    /// <summary>
    /// vpermt2q xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpermt2q xmm_k1z, xmm, m64bcst","vpermt2q xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpermt2q_xmm_k1z_xmm_m64bcst = 2952,
    /// <summary>
    /// vpermt2q ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpermt2q ymm, ymm, ymm","vpermt2q ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpermt2q_ymm_ymm_ymm = 2953,
    /// <summary>
    /// vpermt2q ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpermt2q ymm, ymm, m256","vpermt2q ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpermt2q_ymm_ymm_m256 = 2954,
    /// <summary>
    /// vpermt2q ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpermt2q ymm, ymm, m64bcst","vpermt2q ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpermt2q_ymm_ymm_m64bcst = 2955,
    /// <summary>
    /// vpermt2q ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpermt2q ymm_k1z, ymm, ymm","vpermt2q ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpermt2q_ymm_k1z_ymm_ymm = 2956,
    /// <summary>
    /// vpermt2q ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpermt2q ymm_k1z, ymm, m256","vpermt2q ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpermt2q_ymm_k1z_ymm_m256 = 2957,
    /// <summary>
    /// vpermt2q ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpermt2q ymm_k1z, ymm, m64bcst","vpermt2q ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpermt2q_ymm_k1z_ymm_m64bcst = 2958,
    /// <summary>
    /// vpermt2q zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpermt2q zmm, zmm, zmm","vpermt2q zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpermt2q_zmm_zmm_zmm = 2959,
    /// <summary>
    /// vpermt2q zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpermt2q zmm, zmm, m512","vpermt2q zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpermt2q_zmm_zmm_m512 = 2960,
    /// <summary>
    /// vpermt2q zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpermt2q zmm, zmm, m64bcst","vpermt2q zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpermt2q_zmm_zmm_m64bcst = 2961,
    /// <summary>
    /// vpermt2q zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpermt2q zmm_k1z, zmm, zmm","vpermt2q zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpermt2q_zmm_k1z_zmm_zmm = 2962,
    /// <summary>
    /// vpermt2q zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpermt2q zmm_k1z, zmm, m512","vpermt2q zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpermt2q_zmm_k1z_zmm_m512 = 2963,
    /// <summary>
    /// vpermt2q zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpermt2q zmm_k1z, zmm, m64bcst","vpermt2q zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpermt2q_zmm_k1z_zmm_m64bcst = 2964,
    /// <summary>
    /// vpermt2w xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpermt2w xmm, xmm, xmm","vpermt2w xmm {k1}{z}, xmm, xmm/m128")]
    vpermt2w_xmm_xmm_xmm = 2965,
    /// <summary>
    /// vpermt2w xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpermt2w xmm, xmm, m128","vpermt2w xmm {k1}{z}, xmm, xmm/m128")]
    vpermt2w_xmm_xmm_m128 = 2966,
    /// <summary>
    /// vpermt2w xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpermt2w xmm_k1z, xmm, xmm","vpermt2w xmm {k1}{z}, xmm, xmm/m128")]
    vpermt2w_xmm_k1z_xmm_xmm = 2967,
    /// <summary>
    /// vpermt2w xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpermt2w xmm_k1z, xmm, m128","vpermt2w xmm {k1}{z}, xmm, xmm/m128")]
    vpermt2w_xmm_k1z_xmm_m128 = 2968,
    /// <summary>
    /// vpermt2w ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpermt2w ymm, ymm, ymm","vpermt2w ymm {k1}{z}, ymm, ymm/m256")]
    vpermt2w_ymm_ymm_ymm = 2969,
    /// <summary>
    /// vpermt2w ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpermt2w ymm, ymm, m256","vpermt2w ymm {k1}{z}, ymm, ymm/m256")]
    vpermt2w_ymm_ymm_m256 = 2970,
    /// <summary>
    /// vpermt2w ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpermt2w ymm_k1z, ymm, ymm","vpermt2w ymm {k1}{z}, ymm, ymm/m256")]
    vpermt2w_ymm_k1z_ymm_ymm = 2971,
    /// <summary>
    /// vpermt2w ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpermt2w ymm_k1z, ymm, m256","vpermt2w ymm {k1}{z}, ymm, ymm/m256")]
    vpermt2w_ymm_k1z_ymm_m256 = 2972,
    /// <summary>
    /// vpermt2w zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpermt2w zmm, zmm, zmm","vpermt2w zmm {k1}{z}, zmm, zmm/m512")]
    vpermt2w_zmm_zmm_zmm = 2973,
    /// <summary>
    /// vpermt2w zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpermt2w zmm, zmm, m512","vpermt2w zmm {k1}{z}, zmm, zmm/m512")]
    vpermt2w_zmm_zmm_m512 = 2974,
    /// <summary>
    /// vpermt2w zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpermt2w zmm_k1z, zmm, zmm","vpermt2w zmm {k1}{z}, zmm, zmm/m512")]
    vpermt2w_zmm_k1z_zmm_zmm = 2975,
    /// <summary>
    /// vpermt2w zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpermt2w zmm_k1z, zmm, m512","vpermt2w zmm {k1}{z}, zmm, zmm/m512")]
    vpermt2w_zmm_k1z_zmm_m512 = 2976,
    /// <summary>
    /// vpermw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpermw xmm, xmm, xmm","vpermw xmm {k1}{z}, xmm, xmm/m128")]
    vpermw_xmm_xmm_xmm = 2977,
    /// <summary>
    /// vpermw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpermw xmm, xmm, m128","vpermw xmm {k1}{z}, xmm, xmm/m128")]
    vpermw_xmm_xmm_m128 = 2978,
    /// <summary>
    /// vpermw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpermw xmm_k1z, xmm, xmm","vpermw xmm {k1}{z}, xmm, xmm/m128")]
    vpermw_xmm_k1z_xmm_xmm = 2979,
    /// <summary>
    /// vpermw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpermw xmm_k1z, xmm, m128","vpermw xmm {k1}{z}, xmm, xmm/m128")]
    vpermw_xmm_k1z_xmm_m128 = 2980,
    /// <summary>
    /// vpermw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpermw ymm, ymm, ymm","vpermw ymm {k1}{z}, ymm, ymm/m256")]
    vpermw_ymm_ymm_ymm = 2981,
    /// <summary>
    /// vpermw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpermw ymm, ymm, m256","vpermw ymm {k1}{z}, ymm, ymm/m256")]
    vpermw_ymm_ymm_m256 = 2982,
    /// <summary>
    /// vpermw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpermw ymm_k1z, ymm, ymm","vpermw ymm {k1}{z}, ymm, ymm/m256")]
    vpermw_ymm_k1z_ymm_ymm = 2983,
    /// <summary>
    /// vpermw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpermw ymm_k1z, ymm, m256","vpermw ymm {k1}{z}, ymm, ymm/m256")]
    vpermw_ymm_k1z_ymm_m256 = 2984,
    /// <summary>
    /// vpermw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpermw zmm, zmm, zmm","vpermw zmm {k1}{z}, zmm, zmm/m512")]
    vpermw_zmm_zmm_zmm = 2985,
    /// <summary>
    /// vpermw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpermw zmm, zmm, m512","vpermw zmm {k1}{z}, zmm, zmm/m512")]
    vpermw_zmm_zmm_m512 = 2986,
    /// <summary>
    /// vpermw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpermw zmm_k1z, zmm, zmm","vpermw zmm {k1}{z}, zmm, zmm/m512")]
    vpermw_zmm_k1z_zmm_zmm = 2987,
    /// <summary>
    /// vpermw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpermw zmm_k1z, zmm, m512","vpermw zmm {k1}{z}, zmm, zmm/m512")]
    vpermw_zmm_k1z_zmm_m512 = 2988,
    /// <summary>
    /// vpextrb reg/m8, xmm, imm8
    /// </summary>
    [Symbol("vpextrb reg, xmm, imm8","vpextrb reg/m8, xmm, imm8")]
    vpextrb_reg_xmm_imm8 = 2989,
    /// <summary>
    /// vpextrb reg/m8, xmm, imm8
    /// </summary>
    [Symbol("vpextrb m8, xmm, imm8","vpextrb reg/m8, xmm, imm8")]
    vpextrb_m8_xmm_imm8 = 2990,
    /// <summary>
    /// vpextrd r32/m32, xmm, imm8
    /// </summary>
    [Symbol("vpextrd r32, xmm, imm8","vpextrd r32/m32, xmm, imm8")]
    vpextrd_r32_xmm_imm8 = 2991,
    /// <summary>
    /// vpextrd r32/m32, xmm, imm8
    /// </summary>
    [Symbol("vpextrd m32, xmm, imm8","vpextrd r32/m32, xmm, imm8")]
    vpextrd_m32_xmm_imm8 = 2992,
    /// <summary>
    /// vpextrq r64/m64, xmm, imm8
    /// </summary>
    [Symbol("vpextrq r64, xmm, imm8","vpextrq r64/m64, xmm, imm8")]
    vpextrq_r64_xmm_imm8 = 2993,
    /// <summary>
    /// vpextrq r64/m64, xmm, imm8
    /// </summary>
    [Symbol("vpextrq m64, xmm, imm8","vpextrq r64/m64, xmm, imm8")]
    vpextrq_m64_xmm_imm8 = 2994,
    /// <summary>
    /// vpextrw reg, xmm, imm8
    /// </summary>
    [Symbol("vpextrw reg, xmm, imm8","vpextrw reg, xmm, imm8")]
    vpextrw_reg_xmm_imm8 = 2995,
    /// <summary>
    /// vpextrw reg/m16, xmm, imm8
    /// </summary>
    [Symbol("vpextrw m16, xmm, imm8","vpextrw reg/m16, xmm, imm8")]
    vpextrw_m16_xmm_imm8 = 2996,
    /// <summary>
    /// vpgatherdd xmm {k1}, vm32x
    /// </summary>
    [Symbol("vpgatherdd xmm, vm32x","vpgatherdd xmm {k1}, vm32x")]
    vpgatherdd_xmm_vm32x = 2997,
    /// <summary>
    /// vpgatherdd xmm {k1}, vm32x
    /// </summary>
    [Symbol("vpgatherdd xmm_k1, vm32x","vpgatherdd xmm {k1}, vm32x")]
    vpgatherdd_xmm_k1_vm32x = 2998,
    /// <summary>
    /// vpgatherdd xmm, vm32x, xmm
    /// </summary>
    [Symbol("vpgatherdd xmm, vm32x, xmm","vpgatherdd xmm, vm32x, xmm")]
    vpgatherdd_xmm_vm32x_xmm = 2999,
    /// <summary>
    /// vpgatherdd ymm {k1}, vm32y
    /// </summary>
    [Symbol("vpgatherdd ymm, vm32y","vpgatherdd ymm {k1}, vm32y")]
    vpgatherdd_ymm_vm32y = 3000,
    /// <summary>
    /// vpgatherdd ymm {k1}, vm32y
    /// </summary>
    [Symbol("vpgatherdd ymm_k1, vm32y","vpgatherdd ymm {k1}, vm32y")]
    vpgatherdd_ymm_k1_vm32y = 3001,
    /// <summary>
    /// vpgatherdd ymm, vm32y, ymm
    /// </summary>
    [Symbol("vpgatherdd ymm, vm32y, ymm","vpgatherdd ymm, vm32y, ymm")]
    vpgatherdd_ymm_vm32y_ymm = 3002,
    /// <summary>
    /// vpgatherdd zmm {k1}, vm32z
    /// </summary>
    [Symbol("vpgatherdd zmm, vm32z","vpgatherdd zmm {k1}, vm32z")]
    vpgatherdd_zmm_vm32z = 3003,
    /// <summary>
    /// vpgatherdd zmm {k1}, vm32z
    /// </summary>
    [Symbol("vpgatherdd zmm_k1, vm32z","vpgatherdd zmm {k1}, vm32z")]
    vpgatherdd_zmm_k1_vm32z = 3004,
    /// <summary>
    /// vpgatherdq xmm {k1}, vm32x
    /// </summary>
    [Symbol("vpgatherdq xmm, vm32x","vpgatherdq xmm {k1}, vm32x")]
    vpgatherdq_xmm_vm32x = 3005,
    /// <summary>
    /// vpgatherdq xmm {k1}, vm32x
    /// </summary>
    [Symbol("vpgatherdq xmm_k1, vm32x","vpgatherdq xmm {k1}, vm32x")]
    vpgatherdq_xmm_k1_vm32x = 3006,
    /// <summary>
    /// vpgatherdq xmm, vm32x, xmm
    /// </summary>
    [Symbol("vpgatherdq xmm, vm32x, xmm","vpgatherdq xmm, vm32x, xmm")]
    vpgatherdq_xmm_vm32x_xmm = 3007,
    /// <summary>
    /// vpgatherdq ymm {k1}, vm32x
    /// </summary>
    [Symbol("vpgatherdq ymm, vm32x","vpgatherdq ymm {k1}, vm32x")]
    vpgatherdq_ymm_vm32x = 3008,
    /// <summary>
    /// vpgatherdq ymm {k1}, vm32x
    /// </summary>
    [Symbol("vpgatherdq ymm_k1, vm32x","vpgatherdq ymm {k1}, vm32x")]
    vpgatherdq_ymm_k1_vm32x = 3009,
    /// <summary>
    /// vpgatherdq ymm, vm32x, ymm
    /// </summary>
    [Symbol("vpgatherdq ymm, vm32x, ymm","vpgatherdq ymm, vm32x, ymm")]
    vpgatherdq_ymm_vm32x_ymm = 3010,
    /// <summary>
    /// vpgatherdq zmm {k1}, vm32y
    /// </summary>
    [Symbol("vpgatherdq zmm, vm32y","vpgatherdq zmm {k1}, vm32y")]
    vpgatherdq_zmm_vm32y = 3011,
    /// <summary>
    /// vpgatherdq zmm {k1}, vm32y
    /// </summary>
    [Symbol("vpgatherdq zmm_k1, vm32y","vpgatherdq zmm {k1}, vm32y")]
    vpgatherdq_zmm_k1_vm32y = 3012,
    /// <summary>
    /// vpgatherqd xmm {k1}, vm64x
    /// </summary>
    [Symbol("vpgatherqd xmm, vm64x","vpgatherqd xmm {k1}, vm64x")]
    vpgatherqd_xmm_vm64x = 3013,
    /// <summary>
    /// vpgatherqd xmm {k1}, vm64x
    /// </summary>
    [Symbol("vpgatherqd xmm_k1, vm64x","vpgatherqd xmm {k1}, vm64x")]
    vpgatherqd_xmm_k1_vm64x = 3014,
    /// <summary>
    /// vpgatherqd xmm {k1}, vm64y
    /// </summary>
    [Symbol("vpgatherqd xmm, vm64y","vpgatherqd xmm {k1}, vm64y")]
    vpgatherqd_xmm_vm64y = 3015,
    /// <summary>
    /// vpgatherqd xmm {k1}, vm64y
    /// </summary>
    [Symbol("vpgatherqd xmm_k1, vm64y","vpgatherqd xmm {k1}, vm64y")]
    vpgatherqd_xmm_k1_vm64y = 3016,
    /// <summary>
    /// vpgatherqd xmm, vm64x, xmm
    /// </summary>
    [Symbol("vpgatherqd xmm, vm64x, xmm","vpgatherqd xmm, vm64x, xmm")]
    vpgatherqd_xmm_vm64x_xmm = 3017,
    /// <summary>
    /// vpgatherqd xmm, vm64y, xmm
    /// </summary>
    [Symbol("vpgatherqd xmm, vm64y, xmm","vpgatherqd xmm, vm64y, xmm")]
    vpgatherqd_xmm_vm64y_xmm = 3018,
    /// <summary>
    /// vpgatherqd ymm {k1}, vm64z
    /// </summary>
    [Symbol("vpgatherqd ymm, vm64z","vpgatherqd ymm {k1}, vm64z")]
    vpgatherqd_ymm_vm64z = 3019,
    /// <summary>
    /// vpgatherqd ymm {k1}, vm64z
    /// </summary>
    [Symbol("vpgatherqd ymm_k1, vm64z","vpgatherqd ymm {k1}, vm64z")]
    vpgatherqd_ymm_k1_vm64z = 3020,
    /// <summary>
    /// vpgatherqq xmm {k1}, vm64x
    /// </summary>
    [Symbol("vpgatherqq xmm, vm64x","vpgatherqq xmm {k1}, vm64x")]
    vpgatherqq_xmm_vm64x = 3021,
    /// <summary>
    /// vpgatherqq xmm {k1}, vm64x
    /// </summary>
    [Symbol("vpgatherqq xmm_k1, vm64x","vpgatherqq xmm {k1}, vm64x")]
    vpgatherqq_xmm_k1_vm64x = 3022,
    /// <summary>
    /// vpgatherqq xmm, vm64x, xmm
    /// </summary>
    [Symbol("vpgatherqq xmm, vm64x, xmm","vpgatherqq xmm, vm64x, xmm")]
    vpgatherqq_xmm_vm64x_xmm = 3023,
    /// <summary>
    /// vpgatherqq ymm {k1}, vm64y
    /// </summary>
    [Symbol("vpgatherqq ymm, vm64y","vpgatherqq ymm {k1}, vm64y")]
    vpgatherqq_ymm_vm64y = 3024,
    /// <summary>
    /// vpgatherqq ymm {k1}, vm64y
    /// </summary>
    [Symbol("vpgatherqq ymm_k1, vm64y","vpgatherqq ymm {k1}, vm64y")]
    vpgatherqq_ymm_k1_vm64y = 3025,
    /// <summary>
    /// vpgatherqq ymm, vm64y, ymm
    /// </summary>
    [Symbol("vpgatherqq ymm, vm64y, ymm","vpgatherqq ymm, vm64y, ymm")]
    vpgatherqq_ymm_vm64y_ymm = 3026,
    /// <summary>
    /// vpgatherqq zmm {k1}, vm64z
    /// </summary>
    [Symbol("vpgatherqq zmm, vm64z","vpgatherqq zmm {k1}, vm64z")]
    vpgatherqq_zmm_vm64z = 3027,
    /// <summary>
    /// vpgatherqq zmm {k1}, vm64z
    /// </summary>
    [Symbol("vpgatherqq zmm_k1, vm64z","vpgatherqq zmm {k1}, vm64z")]
    vpgatherqq_zmm_k1_vm64z = 3028,
    /// <summary>
    /// vphaddd xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vphaddd xmm, xmm, xmm","vphaddd xmm, xmm, xmm/m128")]
    vphaddd_xmm_xmm_xmm = 3029,
    /// <summary>
    /// vphaddd xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vphaddd xmm, xmm, m128","vphaddd xmm, xmm, xmm/m128")]
    vphaddd_xmm_xmm_m128 = 3030,
    /// <summary>
    /// vphaddd ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vphaddd ymm, ymm, ymm","vphaddd ymm, ymm, ymm/m256")]
    vphaddd_ymm_ymm_ymm = 3031,
    /// <summary>
    /// vphaddd ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vphaddd ymm, ymm, m256","vphaddd ymm, ymm, ymm/m256")]
    vphaddd_ymm_ymm_m256 = 3032,
    /// <summary>
    /// vphaddsw xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vphaddsw xmm, xmm, xmm","vphaddsw xmm, xmm, xmm/m128")]
    vphaddsw_xmm_xmm_xmm = 3033,
    /// <summary>
    /// vphaddsw xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vphaddsw xmm, xmm, m128","vphaddsw xmm, xmm, xmm/m128")]
    vphaddsw_xmm_xmm_m128 = 3034,
    /// <summary>
    /// vphaddsw ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vphaddsw ymm, ymm, ymm","vphaddsw ymm, ymm, ymm/m256")]
    vphaddsw_ymm_ymm_ymm = 3035,
    /// <summary>
    /// vphaddsw ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vphaddsw ymm, ymm, m256","vphaddsw ymm, ymm, ymm/m256")]
    vphaddsw_ymm_ymm_m256 = 3036,
    /// <summary>
    /// vphaddw xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vphaddw xmm, xmm, xmm","vphaddw xmm, xmm, xmm/m128")]
    vphaddw_xmm_xmm_xmm = 3037,
    /// <summary>
    /// vphaddw xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vphaddw xmm, xmm, m128","vphaddw xmm, xmm, xmm/m128")]
    vphaddw_xmm_xmm_m128 = 3038,
    /// <summary>
    /// vphaddw ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vphaddw ymm, ymm, ymm","vphaddw ymm, ymm, ymm/m256")]
    vphaddw_ymm_ymm_ymm = 3039,
    /// <summary>
    /// vphaddw ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vphaddw ymm, ymm, m256","vphaddw ymm, ymm, ymm/m256")]
    vphaddw_ymm_ymm_m256 = 3040,
    /// <summary>
    /// vpinsrb xmm, xmm, r32/m8, imm8
    /// </summary>
    [Symbol("vpinsrb xmm, xmm, r32, imm8","vpinsrb xmm, xmm, r32/m8, imm8")]
    vpinsrb_xmm_xmm_r32_imm8 = 3041,
    /// <summary>
    /// vpinsrb xmm, xmm, r32/m8, imm8
    /// </summary>
    [Symbol("vpinsrb xmm, xmm, m8, imm8","vpinsrb xmm, xmm, r32/m8, imm8")]
    vpinsrb_xmm_xmm_m8_imm8 = 3042,
    /// <summary>
    /// vpinsrd xmm, xmm, r/m32, imm8
    /// </summary>
    [Symbol("vpinsrd xmm, xmm, r32, imm8","vpinsrd xmm, xmm, r/m32, imm8")]
    vpinsrd_xmm_xmm_r32_imm8 = 3043,
    /// <summary>
    /// vpinsrd xmm, xmm, r/m32, imm8
    /// </summary>
    [Symbol("vpinsrd xmm, xmm, m32, imm8","vpinsrd xmm, xmm, r/m32, imm8")]
    vpinsrd_xmm_xmm_m32_imm8 = 3044,
    /// <summary>
    /// vpinsrq xmm, xmm, r/m64, imm8
    /// </summary>
    [Symbol("vpinsrq xmm, xmm, r64, imm8","vpinsrq xmm, xmm, r/m64, imm8")]
    vpinsrq_xmm_xmm_r64_imm8 = 3045,
    /// <summary>
    /// vpinsrq xmm, xmm, r/m64, imm8
    /// </summary>
    [Symbol("vpinsrq xmm, xmm, m64, imm8","vpinsrq xmm, xmm, r/m64, imm8")]
    vpinsrq_xmm_xmm_m64_imm8 = 3046,
    /// <summary>
    /// vpinsrw xmm, xmm, r32/m16, imm8
    /// </summary>
    [Symbol("vpinsrw xmm, xmm, r32, imm8","vpinsrw xmm, xmm, r32/m16, imm8")]
    vpinsrw_xmm_xmm_r32_imm8 = 3047,
    /// <summary>
    /// vpinsrw xmm, xmm, r32/m16, imm8
    /// </summary>
    [Symbol("vpinsrw xmm, xmm, m16, imm8","vpinsrw xmm, xmm, r32/m16, imm8")]
    vpinsrw_xmm_xmm_m16_imm8 = 3048,
    /// <summary>
    /// vplzcntd xmm {k1}{z}, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vplzcntd xmm, xmm","vplzcntd xmm {k1}{z}, xmm/m128/m32bcst")]
    vplzcntd_xmm_xmm = 3049,
    /// <summary>
    /// vplzcntd xmm {k1}{z}, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vplzcntd xmm, m128","vplzcntd xmm {k1}{z}, xmm/m128/m32bcst")]
    vplzcntd_xmm_m128 = 3050,
    /// <summary>
    /// vplzcntd xmm {k1}{z}, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vplzcntd xmm, m32bcst","vplzcntd xmm {k1}{z}, xmm/m128/m32bcst")]
    vplzcntd_xmm_m32bcst = 3051,
    /// <summary>
    /// vplzcntd xmm {k1}{z}, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vplzcntd xmm_k1z, xmm","vplzcntd xmm {k1}{z}, xmm/m128/m32bcst")]
    vplzcntd_xmm_k1z_xmm = 3052,
    /// <summary>
    /// vplzcntd xmm {k1}{z}, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vplzcntd xmm_k1z, m128","vplzcntd xmm {k1}{z}, xmm/m128/m32bcst")]
    vplzcntd_xmm_k1z_m128 = 3053,
    /// <summary>
    /// vplzcntd xmm {k1}{z}, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vplzcntd xmm_k1z, m32bcst","vplzcntd xmm {k1}{z}, xmm/m128/m32bcst")]
    vplzcntd_xmm_k1z_m32bcst = 3054,
    /// <summary>
    /// vplzcntd ymm {k1}{z}, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vplzcntd ymm, ymm","vplzcntd ymm {k1}{z}, ymm/m256/m32bcst")]
    vplzcntd_ymm_ymm = 3055,
    /// <summary>
    /// vplzcntd ymm {k1}{z}, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vplzcntd ymm, m256","vplzcntd ymm {k1}{z}, ymm/m256/m32bcst")]
    vplzcntd_ymm_m256 = 3056,
    /// <summary>
    /// vplzcntd ymm {k1}{z}, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vplzcntd ymm, m32bcst","vplzcntd ymm {k1}{z}, ymm/m256/m32bcst")]
    vplzcntd_ymm_m32bcst = 3057,
    /// <summary>
    /// vplzcntd ymm {k1}{z}, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vplzcntd ymm_k1z, ymm","vplzcntd ymm {k1}{z}, ymm/m256/m32bcst")]
    vplzcntd_ymm_k1z_ymm = 3058,
    /// <summary>
    /// vplzcntd ymm {k1}{z}, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vplzcntd ymm_k1z, m256","vplzcntd ymm {k1}{z}, ymm/m256/m32bcst")]
    vplzcntd_ymm_k1z_m256 = 3059,
    /// <summary>
    /// vplzcntd ymm {k1}{z}, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vplzcntd ymm_k1z, m32bcst","vplzcntd ymm {k1}{z}, ymm/m256/m32bcst")]
    vplzcntd_ymm_k1z_m32bcst = 3060,
    /// <summary>
    /// vplzcntd zmm {k1}{z}, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vplzcntd zmm, zmm","vplzcntd zmm {k1}{z}, zmm/m512/m32bcst")]
    vplzcntd_zmm_zmm = 3061,
    /// <summary>
    /// vplzcntd zmm {k1}{z}, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vplzcntd zmm, m512","vplzcntd zmm {k1}{z}, zmm/m512/m32bcst")]
    vplzcntd_zmm_m512 = 3062,
    /// <summary>
    /// vplzcntd zmm {k1}{z}, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vplzcntd zmm, m32bcst","vplzcntd zmm {k1}{z}, zmm/m512/m32bcst")]
    vplzcntd_zmm_m32bcst = 3063,
    /// <summary>
    /// vplzcntd zmm {k1}{z}, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vplzcntd zmm_k1z, zmm","vplzcntd zmm {k1}{z}, zmm/m512/m32bcst")]
    vplzcntd_zmm_k1z_zmm = 3064,
    /// <summary>
    /// vplzcntd zmm {k1}{z}, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vplzcntd zmm_k1z, m512","vplzcntd zmm {k1}{z}, zmm/m512/m32bcst")]
    vplzcntd_zmm_k1z_m512 = 3065,
    /// <summary>
    /// vplzcntd zmm {k1}{z}, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vplzcntd zmm_k1z, m32bcst","vplzcntd zmm {k1}{z}, zmm/m512/m32bcst")]
    vplzcntd_zmm_k1z_m32bcst = 3066,
    /// <summary>
    /// vplzcntq xmm {k1}{z}, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vplzcntq xmm, xmm","vplzcntq xmm {k1}{z}, xmm/m128/m64bcst")]
    vplzcntq_xmm_xmm = 3067,
    /// <summary>
    /// vplzcntq xmm {k1}{z}, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vplzcntq xmm, m128","vplzcntq xmm {k1}{z}, xmm/m128/m64bcst")]
    vplzcntq_xmm_m128 = 3068,
    /// <summary>
    /// vplzcntq xmm {k1}{z}, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vplzcntq xmm, m64bcst","vplzcntq xmm {k1}{z}, xmm/m128/m64bcst")]
    vplzcntq_xmm_m64bcst = 3069,
    /// <summary>
    /// vplzcntq xmm {k1}{z}, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vplzcntq xmm_k1z, xmm","vplzcntq xmm {k1}{z}, xmm/m128/m64bcst")]
    vplzcntq_xmm_k1z_xmm = 3070,
    /// <summary>
    /// vplzcntq xmm {k1}{z}, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vplzcntq xmm_k1z, m128","vplzcntq xmm {k1}{z}, xmm/m128/m64bcst")]
    vplzcntq_xmm_k1z_m128 = 3071,
    /// <summary>
    /// vplzcntq xmm {k1}{z}, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vplzcntq xmm_k1z, m64bcst","vplzcntq xmm {k1}{z}, xmm/m128/m64bcst")]
    vplzcntq_xmm_k1z_m64bcst = 3072,
    /// <summary>
    /// vplzcntq ymm {k1}{z}, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vplzcntq ymm, ymm","vplzcntq ymm {k1}{z}, ymm/m256/m64bcst")]
    vplzcntq_ymm_ymm = 3073,
    /// <summary>
    /// vplzcntq ymm {k1}{z}, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vplzcntq ymm, m256","vplzcntq ymm {k1}{z}, ymm/m256/m64bcst")]
    vplzcntq_ymm_m256 = 3074,
    /// <summary>
    /// vplzcntq ymm {k1}{z}, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vplzcntq ymm, m64bcst","vplzcntq ymm {k1}{z}, ymm/m256/m64bcst")]
    vplzcntq_ymm_m64bcst = 3075,
    /// <summary>
    /// vplzcntq ymm {k1}{z}, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vplzcntq ymm_k1z, ymm","vplzcntq ymm {k1}{z}, ymm/m256/m64bcst")]
    vplzcntq_ymm_k1z_ymm = 3076,
    /// <summary>
    /// vplzcntq ymm {k1}{z}, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vplzcntq ymm_k1z, m256","vplzcntq ymm {k1}{z}, ymm/m256/m64bcst")]
    vplzcntq_ymm_k1z_m256 = 3077,
    /// <summary>
    /// vplzcntq ymm {k1}{z}, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vplzcntq ymm_k1z, m64bcst","vplzcntq ymm {k1}{z}, ymm/m256/m64bcst")]
    vplzcntq_ymm_k1z_m64bcst = 3078,
    /// <summary>
    /// vplzcntq zmm {k1}{z}, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vplzcntq zmm, zmm","vplzcntq zmm {k1}{z}, zmm/m512/m64bcst")]
    vplzcntq_zmm_zmm = 3079,
    /// <summary>
    /// vplzcntq zmm {k1}{z}, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vplzcntq zmm, m512","vplzcntq zmm {k1}{z}, zmm/m512/m64bcst")]
    vplzcntq_zmm_m512 = 3080,
    /// <summary>
    /// vplzcntq zmm {k1}{z}, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vplzcntq zmm, m64bcst","vplzcntq zmm {k1}{z}, zmm/m512/m64bcst")]
    vplzcntq_zmm_m64bcst = 3081,
    /// <summary>
    /// vplzcntq zmm {k1}{z}, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vplzcntq zmm_k1z, zmm","vplzcntq zmm {k1}{z}, zmm/m512/m64bcst")]
    vplzcntq_zmm_k1z_zmm = 3082,
    /// <summary>
    /// vplzcntq zmm {k1}{z}, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vplzcntq zmm_k1z, m512","vplzcntq zmm {k1}{z}, zmm/m512/m64bcst")]
    vplzcntq_zmm_k1z_m512 = 3083,
    /// <summary>
    /// vplzcntq zmm {k1}{z}, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vplzcntq zmm_k1z, m64bcst","vplzcntq zmm {k1}{z}, zmm/m512/m64bcst")]
    vplzcntq_zmm_k1z_m64bcst = 3084,
    /// <summary>
    /// vpmaskmovd m128, xmm, xmm
    /// </summary>
    [Symbol("vpmaskmovd m128, xmm, xmm","vpmaskmovd m128, xmm, xmm")]
    vpmaskmovd_m128_xmm_xmm = 3085,
    /// <summary>
    /// vpmaskmovd m256, ymm, ymm
    /// </summary>
    [Symbol("vpmaskmovd m256, ymm, ymm","vpmaskmovd m256, ymm, ymm")]
    vpmaskmovd_m256_ymm_ymm = 3086,
    /// <summary>
    /// vpmaskmovd xmm, xmm, m128
    /// </summary>
    [Symbol("vpmaskmovd xmm, xmm, m128","vpmaskmovd xmm, xmm, m128")]
    vpmaskmovd_xmm_xmm_m128 = 3087,
    /// <summary>
    /// vpmaskmovd ymm, ymm, m256
    /// </summary>
    [Symbol("vpmaskmovd ymm, ymm, m256","vpmaskmovd ymm, ymm, m256")]
    vpmaskmovd_ymm_ymm_m256 = 3088,
    /// <summary>
    /// vpmaskmovq m128, xmm, xmm
    /// </summary>
    [Symbol("vpmaskmovq m128, xmm, xmm","vpmaskmovq m128, xmm, xmm")]
    vpmaskmovq_m128_xmm_xmm = 3089,
    /// <summary>
    /// vpmaskmovq m256, ymm, ymm
    /// </summary>
    [Symbol("vpmaskmovq m256, ymm, ymm","vpmaskmovq m256, ymm, ymm")]
    vpmaskmovq_m256_ymm_ymm = 3090,
    /// <summary>
    /// vpmaskmovq xmm, xmm, m128
    /// </summary>
    [Symbol("vpmaskmovq xmm, xmm, m128","vpmaskmovq xmm, xmm, m128")]
    vpmaskmovq_xmm_xmm_m128 = 3091,
    /// <summary>
    /// vpmaskmovq ymm, ymm, m256
    /// </summary>
    [Symbol("vpmaskmovq ymm, ymm, m256","vpmaskmovq ymm, ymm, m256")]
    vpmaskmovq_ymm_ymm_m256 = 3092,
    /// <summary>
    /// vpmaxsb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpmaxsb xmm, xmm, xmm","vpmaxsb xmm {k1}{z}, xmm, xmm/m128")]
    vpmaxsb_xmm_xmm_xmm = 3093,
    /// <summary>
    /// vpmaxsb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpmaxsb xmm, xmm, m128","vpmaxsb xmm {k1}{z}, xmm, xmm/m128")]
    vpmaxsb_xmm_xmm_m128 = 3094,
    /// <summary>
    /// vpmaxsb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpmaxsb xmm_k1z, xmm, xmm","vpmaxsb xmm {k1}{z}, xmm, xmm/m128")]
    vpmaxsb_xmm_k1z_xmm_xmm = 3095,
    /// <summary>
    /// vpmaxsb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpmaxsb xmm_k1z, xmm, m128","vpmaxsb xmm {k1}{z}, xmm, xmm/m128")]
    vpmaxsb_xmm_k1z_xmm_m128 = 3096,
    /// <summary>
    /// vpmaxsb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpmaxsb ymm, ymm, ymm","vpmaxsb ymm {k1}{z}, ymm, ymm/m256")]
    vpmaxsb_ymm_ymm_ymm = 3097,
    /// <summary>
    /// vpmaxsb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpmaxsb ymm, ymm, m256","vpmaxsb ymm {k1}{z}, ymm, ymm/m256")]
    vpmaxsb_ymm_ymm_m256 = 3098,
    /// <summary>
    /// vpmaxsb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpmaxsb ymm_k1z, ymm, ymm","vpmaxsb ymm {k1}{z}, ymm, ymm/m256")]
    vpmaxsb_ymm_k1z_ymm_ymm = 3099,
    /// <summary>
    /// vpmaxsb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpmaxsb ymm_k1z, ymm, m256","vpmaxsb ymm {k1}{z}, ymm, ymm/m256")]
    vpmaxsb_ymm_k1z_ymm_m256 = 3100,
    /// <summary>
    /// vpmaxsb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpmaxsb zmm, zmm, zmm","vpmaxsb zmm {k1}{z}, zmm, zmm/m512")]
    vpmaxsb_zmm_zmm_zmm = 3101,
    /// <summary>
    /// vpmaxsb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpmaxsb zmm, zmm, m512","vpmaxsb zmm {k1}{z}, zmm, zmm/m512")]
    vpmaxsb_zmm_zmm_m512 = 3102,
    /// <summary>
    /// vpmaxsb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpmaxsb zmm_k1z, zmm, zmm","vpmaxsb zmm {k1}{z}, zmm, zmm/m512")]
    vpmaxsb_zmm_k1z_zmm_zmm = 3103,
    /// <summary>
    /// vpmaxsb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpmaxsb zmm_k1z, zmm, m512","vpmaxsb zmm {k1}{z}, zmm, zmm/m512")]
    vpmaxsb_zmm_k1z_zmm_m512 = 3104,
    /// <summary>
    /// vpmaxsd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpmaxsd xmm, xmm, xmm","vpmaxsd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpmaxsd_xmm_xmm_xmm = 3105,
    /// <summary>
    /// vpmaxsd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpmaxsd xmm, xmm, m128","vpmaxsd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpmaxsd_xmm_xmm_m128 = 3106,
    /// <summary>
    /// vpmaxsd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpmaxsd xmm, xmm, m32bcst","vpmaxsd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpmaxsd_xmm_xmm_m32bcst = 3107,
    /// <summary>
    /// vpmaxsd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpmaxsd xmm_k1z, xmm, xmm","vpmaxsd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpmaxsd_xmm_k1z_xmm_xmm = 3108,
    /// <summary>
    /// vpmaxsd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpmaxsd xmm_k1z, xmm, m128","vpmaxsd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpmaxsd_xmm_k1z_xmm_m128 = 3109,
    /// <summary>
    /// vpmaxsd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpmaxsd xmm_k1z, xmm, m32bcst","vpmaxsd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpmaxsd_xmm_k1z_xmm_m32bcst = 3110,
    /// <summary>
    /// vpmaxsd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpmaxsd ymm, ymm, ymm","vpmaxsd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpmaxsd_ymm_ymm_ymm = 3111,
    /// <summary>
    /// vpmaxsd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpmaxsd ymm, ymm, m256","vpmaxsd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpmaxsd_ymm_ymm_m256 = 3112,
    /// <summary>
    /// vpmaxsd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpmaxsd ymm, ymm, m32bcst","vpmaxsd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpmaxsd_ymm_ymm_m32bcst = 3113,
    /// <summary>
    /// vpmaxsd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpmaxsd ymm_k1z, ymm, ymm","vpmaxsd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpmaxsd_ymm_k1z_ymm_ymm = 3114,
    /// <summary>
    /// vpmaxsd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpmaxsd ymm_k1z, ymm, m256","vpmaxsd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpmaxsd_ymm_k1z_ymm_m256 = 3115,
    /// <summary>
    /// vpmaxsd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpmaxsd ymm_k1z, ymm, m32bcst","vpmaxsd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpmaxsd_ymm_k1z_ymm_m32bcst = 3116,
    /// <summary>
    /// vpmaxsd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpmaxsd zmm, zmm, zmm","vpmaxsd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpmaxsd_zmm_zmm_zmm = 3117,
    /// <summary>
    /// vpmaxsd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpmaxsd zmm, zmm, m512","vpmaxsd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpmaxsd_zmm_zmm_m512 = 3118,
    /// <summary>
    /// vpmaxsd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpmaxsd zmm, zmm, m32bcst","vpmaxsd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpmaxsd_zmm_zmm_m32bcst = 3119,
    /// <summary>
    /// vpmaxsd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpmaxsd zmm_k1z, zmm, zmm","vpmaxsd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpmaxsd_zmm_k1z_zmm_zmm = 3120,
    /// <summary>
    /// vpmaxsd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpmaxsd zmm_k1z, zmm, m512","vpmaxsd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpmaxsd_zmm_k1z_zmm_m512 = 3121,
    /// <summary>
    /// vpmaxsd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpmaxsd zmm_k1z, zmm, m32bcst","vpmaxsd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpmaxsd_zmm_k1z_zmm_m32bcst = 3122,
    /// <summary>
    /// vpmaxsq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpmaxsq xmm, xmm, xmm","vpmaxsq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpmaxsq_xmm_xmm_xmm = 3123,
    /// <summary>
    /// vpmaxsq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpmaxsq xmm, xmm, m128","vpmaxsq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpmaxsq_xmm_xmm_m128 = 3124,
    /// <summary>
    /// vpmaxsq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpmaxsq xmm, xmm, m64bcst","vpmaxsq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpmaxsq_xmm_xmm_m64bcst = 3125,
    /// <summary>
    /// vpmaxsq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpmaxsq xmm_k1z, xmm, xmm","vpmaxsq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpmaxsq_xmm_k1z_xmm_xmm = 3126,
    /// <summary>
    /// vpmaxsq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpmaxsq xmm_k1z, xmm, m128","vpmaxsq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpmaxsq_xmm_k1z_xmm_m128 = 3127,
    /// <summary>
    /// vpmaxsq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpmaxsq xmm_k1z, xmm, m64bcst","vpmaxsq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpmaxsq_xmm_k1z_xmm_m64bcst = 3128,
    /// <summary>
    /// vpmaxsq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpmaxsq ymm, ymm, ymm","vpmaxsq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpmaxsq_ymm_ymm_ymm = 3129,
    /// <summary>
    /// vpmaxsq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpmaxsq ymm, ymm, m256","vpmaxsq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpmaxsq_ymm_ymm_m256 = 3130,
    /// <summary>
    /// vpmaxsq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpmaxsq ymm, ymm, m64bcst","vpmaxsq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpmaxsq_ymm_ymm_m64bcst = 3131,
    /// <summary>
    /// vpmaxsq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpmaxsq ymm_k1z, ymm, ymm","vpmaxsq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpmaxsq_ymm_k1z_ymm_ymm = 3132,
    /// <summary>
    /// vpmaxsq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpmaxsq ymm_k1z, ymm, m256","vpmaxsq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpmaxsq_ymm_k1z_ymm_m256 = 3133,
    /// <summary>
    /// vpmaxsq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpmaxsq ymm_k1z, ymm, m64bcst","vpmaxsq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpmaxsq_ymm_k1z_ymm_m64bcst = 3134,
    /// <summary>
    /// vpmaxsq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpmaxsq zmm, zmm, zmm","vpmaxsq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpmaxsq_zmm_zmm_zmm = 3135,
    /// <summary>
    /// vpmaxsq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpmaxsq zmm, zmm, m512","vpmaxsq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpmaxsq_zmm_zmm_m512 = 3136,
    /// <summary>
    /// vpmaxsq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpmaxsq zmm, zmm, m64bcst","vpmaxsq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpmaxsq_zmm_zmm_m64bcst = 3137,
    /// <summary>
    /// vpmaxsq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpmaxsq zmm_k1z, zmm, zmm","vpmaxsq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpmaxsq_zmm_k1z_zmm_zmm = 3138,
    /// <summary>
    /// vpmaxsq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpmaxsq zmm_k1z, zmm, m512","vpmaxsq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpmaxsq_zmm_k1z_zmm_m512 = 3139,
    /// <summary>
    /// vpmaxsq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpmaxsq zmm_k1z, zmm, m64bcst","vpmaxsq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpmaxsq_zmm_k1z_zmm_m64bcst = 3140,
    /// <summary>
    /// vpmaxsw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpmaxsw xmm, xmm, xmm","vpmaxsw xmm {k1}{z}, xmm, xmm/m128")]
    vpmaxsw_xmm_xmm_xmm = 3141,
    /// <summary>
    /// vpmaxsw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpmaxsw xmm, xmm, m128","vpmaxsw xmm {k1}{z}, xmm, xmm/m128")]
    vpmaxsw_xmm_xmm_m128 = 3142,
    /// <summary>
    /// vpmaxsw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpmaxsw xmm_k1z, xmm, xmm","vpmaxsw xmm {k1}{z}, xmm, xmm/m128")]
    vpmaxsw_xmm_k1z_xmm_xmm = 3143,
    /// <summary>
    /// vpmaxsw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpmaxsw xmm_k1z, xmm, m128","vpmaxsw xmm {k1}{z}, xmm, xmm/m128")]
    vpmaxsw_xmm_k1z_xmm_m128 = 3144,
    /// <summary>
    /// vpmaxsw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpmaxsw ymm, ymm, ymm","vpmaxsw ymm {k1}{z}, ymm, ymm/m256")]
    vpmaxsw_ymm_ymm_ymm = 3145,
    /// <summary>
    /// vpmaxsw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpmaxsw ymm, ymm, m256","vpmaxsw ymm {k1}{z}, ymm, ymm/m256")]
    vpmaxsw_ymm_ymm_m256 = 3146,
    /// <summary>
    /// vpmaxsw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpmaxsw ymm_k1z, ymm, ymm","vpmaxsw ymm {k1}{z}, ymm, ymm/m256")]
    vpmaxsw_ymm_k1z_ymm_ymm = 3147,
    /// <summary>
    /// vpmaxsw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpmaxsw ymm_k1z, ymm, m256","vpmaxsw ymm {k1}{z}, ymm, ymm/m256")]
    vpmaxsw_ymm_k1z_ymm_m256 = 3148,
    /// <summary>
    /// vpmaxsw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpmaxsw zmm, zmm, zmm","vpmaxsw zmm {k1}{z}, zmm, zmm/m512")]
    vpmaxsw_zmm_zmm_zmm = 3149,
    /// <summary>
    /// vpmaxsw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpmaxsw zmm, zmm, m512","vpmaxsw zmm {k1}{z}, zmm, zmm/m512")]
    vpmaxsw_zmm_zmm_m512 = 3150,
    /// <summary>
    /// vpmaxsw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpmaxsw zmm_k1z, zmm, zmm","vpmaxsw zmm {k1}{z}, zmm, zmm/m512")]
    vpmaxsw_zmm_k1z_zmm_zmm = 3151,
    /// <summary>
    /// vpmaxsw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpmaxsw zmm_k1z, zmm, m512","vpmaxsw zmm {k1}{z}, zmm, zmm/m512")]
    vpmaxsw_zmm_k1z_zmm_m512 = 3152,
    /// <summary>
    /// vpmaxub xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpmaxub xmm, xmm, xmm","vpmaxub xmm {k1}{z}, xmm, xmm/m128")]
    vpmaxub_xmm_xmm_xmm = 3153,
    /// <summary>
    /// vpmaxub xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpmaxub xmm, xmm, m128","vpmaxub xmm {k1}{z}, xmm, xmm/m128")]
    vpmaxub_xmm_xmm_m128 = 3154,
    /// <summary>
    /// vpmaxub xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpmaxub xmm_k1z, xmm, xmm","vpmaxub xmm {k1}{z}, xmm, xmm/m128")]
    vpmaxub_xmm_k1z_xmm_xmm = 3155,
    /// <summary>
    /// vpmaxub xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpmaxub xmm_k1z, xmm, m128","vpmaxub xmm {k1}{z}, xmm, xmm/m128")]
    vpmaxub_xmm_k1z_xmm_m128 = 3156,
    /// <summary>
    /// vpmaxub ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpmaxub ymm, ymm, ymm","vpmaxub ymm {k1}{z}, ymm, ymm/m256")]
    vpmaxub_ymm_ymm_ymm = 3157,
    /// <summary>
    /// vpmaxub ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpmaxub ymm, ymm, m256","vpmaxub ymm {k1}{z}, ymm, ymm/m256")]
    vpmaxub_ymm_ymm_m256 = 3158,
    /// <summary>
    /// vpmaxub ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpmaxub ymm_k1z, ymm, ymm","vpmaxub ymm {k1}{z}, ymm, ymm/m256")]
    vpmaxub_ymm_k1z_ymm_ymm = 3159,
    /// <summary>
    /// vpmaxub ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpmaxub ymm_k1z, ymm, m256","vpmaxub ymm {k1}{z}, ymm, ymm/m256")]
    vpmaxub_ymm_k1z_ymm_m256 = 3160,
    /// <summary>
    /// vpmaxub zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpmaxub zmm, zmm, zmm","vpmaxub zmm {k1}{z}, zmm, zmm/m512")]
    vpmaxub_zmm_zmm_zmm = 3161,
    /// <summary>
    /// vpmaxub zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpmaxub zmm, zmm, m512","vpmaxub zmm {k1}{z}, zmm, zmm/m512")]
    vpmaxub_zmm_zmm_m512 = 3162,
    /// <summary>
    /// vpmaxub zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpmaxub zmm_k1z, zmm, zmm","vpmaxub zmm {k1}{z}, zmm, zmm/m512")]
    vpmaxub_zmm_k1z_zmm_zmm = 3163,
    /// <summary>
    /// vpmaxub zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpmaxub zmm_k1z, zmm, m512","vpmaxub zmm {k1}{z}, zmm, zmm/m512")]
    vpmaxub_zmm_k1z_zmm_m512 = 3164,
    /// <summary>
    /// vpmaxuw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpmaxuw xmm, xmm, xmm","vpmaxuw xmm {k1}{z}, xmm, xmm/m128")]
    vpmaxuw_xmm_xmm_xmm = 3165,
    /// <summary>
    /// vpmaxuw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpmaxuw xmm, xmm, m128","vpmaxuw xmm {k1}{z}, xmm, xmm/m128")]
    vpmaxuw_xmm_xmm_m128 = 3166,
    /// <summary>
    /// vpmaxuw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpmaxuw xmm_k1z, xmm, xmm","vpmaxuw xmm {k1}{z}, xmm, xmm/m128")]
    vpmaxuw_xmm_k1z_xmm_xmm = 3167,
    /// <summary>
    /// vpmaxuw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpmaxuw xmm_k1z, xmm, m128","vpmaxuw xmm {k1}{z}, xmm, xmm/m128")]
    vpmaxuw_xmm_k1z_xmm_m128 = 3168,
    /// <summary>
    /// vpmaxuw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpmaxuw ymm, ymm, ymm","vpmaxuw ymm {k1}{z}, ymm, ymm/m256")]
    vpmaxuw_ymm_ymm_ymm = 3169,
    /// <summary>
    /// vpmaxuw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpmaxuw ymm, ymm, m256","vpmaxuw ymm {k1}{z}, ymm, ymm/m256")]
    vpmaxuw_ymm_ymm_m256 = 3170,
    /// <summary>
    /// vpmaxuw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpmaxuw ymm_k1z, ymm, ymm","vpmaxuw ymm {k1}{z}, ymm, ymm/m256")]
    vpmaxuw_ymm_k1z_ymm_ymm = 3171,
    /// <summary>
    /// vpmaxuw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpmaxuw ymm_k1z, ymm, m256","vpmaxuw ymm {k1}{z}, ymm, ymm/m256")]
    vpmaxuw_ymm_k1z_ymm_m256 = 3172,
    /// <summary>
    /// vpmaxuw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpmaxuw zmm, zmm, zmm","vpmaxuw zmm {k1}{z}, zmm, zmm/m512")]
    vpmaxuw_zmm_zmm_zmm = 3173,
    /// <summary>
    /// vpmaxuw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpmaxuw zmm, zmm, m512","vpmaxuw zmm {k1}{z}, zmm, zmm/m512")]
    vpmaxuw_zmm_zmm_m512 = 3174,
    /// <summary>
    /// vpmaxuw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpmaxuw zmm_k1z, zmm, zmm","vpmaxuw zmm {k1}{z}, zmm, zmm/m512")]
    vpmaxuw_zmm_k1z_zmm_zmm = 3175,
    /// <summary>
    /// vpmaxuw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpmaxuw zmm_k1z, zmm, m512","vpmaxuw zmm {k1}{z}, zmm, zmm/m512")]
    vpmaxuw_zmm_k1z_zmm_m512 = 3176,
    /// <summary>
    /// vpminsb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpminsb xmm, xmm, xmm","vpminsb xmm {k1}{z}, xmm, xmm/m128")]
    vpminsb_xmm_xmm_xmm = 3177,
    /// <summary>
    /// vpminsb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpminsb xmm, xmm, m128","vpminsb xmm {k1}{z}, xmm, xmm/m128")]
    vpminsb_xmm_xmm_m128 = 3178,
    /// <summary>
    /// vpminsb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpminsb xmm_k1z, xmm, xmm","vpminsb xmm {k1}{z}, xmm, xmm/m128")]
    vpminsb_xmm_k1z_xmm_xmm = 3179,
    /// <summary>
    /// vpminsb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpminsb xmm_k1z, xmm, m128","vpminsb xmm {k1}{z}, xmm, xmm/m128")]
    vpminsb_xmm_k1z_xmm_m128 = 3180,
    /// <summary>
    /// vpminsb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpminsb ymm, ymm, ymm","vpminsb ymm {k1}{z}, ymm, ymm/m256")]
    vpminsb_ymm_ymm_ymm = 3181,
    /// <summary>
    /// vpminsb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpminsb ymm, ymm, m256","vpminsb ymm {k1}{z}, ymm, ymm/m256")]
    vpminsb_ymm_ymm_m256 = 3182,
    /// <summary>
    /// vpminsb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpminsb ymm_k1z, ymm, ymm","vpminsb ymm {k1}{z}, ymm, ymm/m256")]
    vpminsb_ymm_k1z_ymm_ymm = 3183,
    /// <summary>
    /// vpminsb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpminsb ymm_k1z, ymm, m256","vpminsb ymm {k1}{z}, ymm, ymm/m256")]
    vpminsb_ymm_k1z_ymm_m256 = 3184,
    /// <summary>
    /// vpminsb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpminsb zmm, zmm, zmm","vpminsb zmm {k1}{z}, zmm, zmm/m512")]
    vpminsb_zmm_zmm_zmm = 3185,
    /// <summary>
    /// vpminsb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpminsb zmm, zmm, m512","vpminsb zmm {k1}{z}, zmm, zmm/m512")]
    vpminsb_zmm_zmm_m512 = 3186,
    /// <summary>
    /// vpminsb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpminsb zmm_k1z, zmm, zmm","vpminsb zmm {k1}{z}, zmm, zmm/m512")]
    vpminsb_zmm_k1z_zmm_zmm = 3187,
    /// <summary>
    /// vpminsb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpminsb zmm_k1z, zmm, m512","vpminsb zmm {k1}{z}, zmm, zmm/m512")]
    vpminsb_zmm_k1z_zmm_m512 = 3188,
    /// <summary>
    /// vpminsw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpminsw xmm, xmm, xmm","vpminsw xmm {k1}{z}, xmm, xmm/m128")]
    vpminsw_xmm_xmm_xmm = 3189,
    /// <summary>
    /// vpminsw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpminsw xmm, xmm, m128","vpminsw xmm {k1}{z}, xmm, xmm/m128")]
    vpminsw_xmm_xmm_m128 = 3190,
    /// <summary>
    /// vpminsw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpminsw xmm_k1z, xmm, xmm","vpminsw xmm {k1}{z}, xmm, xmm/m128")]
    vpminsw_xmm_k1z_xmm_xmm = 3191,
    /// <summary>
    /// vpminsw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpminsw xmm_k1z, xmm, m128","vpminsw xmm {k1}{z}, xmm, xmm/m128")]
    vpminsw_xmm_k1z_xmm_m128 = 3192,
    /// <summary>
    /// vpminsw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpminsw ymm, ymm, ymm","vpminsw ymm {k1}{z}, ymm, ymm/m256")]
    vpminsw_ymm_ymm_ymm = 3193,
    /// <summary>
    /// vpminsw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpminsw ymm, ymm, m256","vpminsw ymm {k1}{z}, ymm, ymm/m256")]
    vpminsw_ymm_ymm_m256 = 3194,
    /// <summary>
    /// vpminsw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpminsw ymm_k1z, ymm, ymm","vpminsw ymm {k1}{z}, ymm, ymm/m256")]
    vpminsw_ymm_k1z_ymm_ymm = 3195,
    /// <summary>
    /// vpminsw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpminsw ymm_k1z, ymm, m256","vpminsw ymm {k1}{z}, ymm, ymm/m256")]
    vpminsw_ymm_k1z_ymm_m256 = 3196,
    /// <summary>
    /// vpminsw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpminsw zmm, zmm, zmm","vpminsw zmm {k1}{z}, zmm, zmm/m512")]
    vpminsw_zmm_zmm_zmm = 3197,
    /// <summary>
    /// vpminsw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpminsw zmm, zmm, m512","vpminsw zmm {k1}{z}, zmm, zmm/m512")]
    vpminsw_zmm_zmm_m512 = 3198,
    /// <summary>
    /// vpminsw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpminsw zmm_k1z, zmm, zmm","vpminsw zmm {k1}{z}, zmm, zmm/m512")]
    vpminsw_zmm_k1z_zmm_zmm = 3199,
    /// <summary>
    /// vpminsw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpminsw zmm_k1z, zmm, m512","vpminsw zmm {k1}{z}, zmm, zmm/m512")]
    vpminsw_zmm_k1z_zmm_m512 = 3200,
    /// <summary>
    /// vpminub xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpminub xmm, xmm, xmm","vpminub xmm {k1}{z}, xmm, xmm/m128")]
    vpminub_xmm_xmm_xmm = 3201,
    /// <summary>
    /// vpminub xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpminub xmm, xmm, m128","vpminub xmm {k1}{z}, xmm, xmm/m128")]
    vpminub_xmm_xmm_m128 = 3202,
    /// <summary>
    /// vpminub xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpminub xmm_k1z, xmm, xmm","vpminub xmm {k1}{z}, xmm, xmm/m128")]
    vpminub_xmm_k1z_xmm_xmm = 3203,
    /// <summary>
    /// vpminub xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpminub xmm_k1z, xmm, m128","vpminub xmm {k1}{z}, xmm, xmm/m128")]
    vpminub_xmm_k1z_xmm_m128 = 3204,
    /// <summary>
    /// vpminub ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpminub ymm, ymm, ymm","vpminub ymm {k1}{z}, ymm, ymm/m256")]
    vpminub_ymm_ymm_ymm = 3205,
    /// <summary>
    /// vpminub ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpminub ymm, ymm, m256","vpminub ymm {k1}{z}, ymm, ymm/m256")]
    vpminub_ymm_ymm_m256 = 3206,
    /// <summary>
    /// vpminub ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpminub ymm_k1z, ymm, ymm","vpminub ymm {k1}{z}, ymm, ymm/m256")]
    vpminub_ymm_k1z_ymm_ymm = 3207,
    /// <summary>
    /// vpminub ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpminub ymm_k1z, ymm, m256","vpminub ymm {k1}{z}, ymm, ymm/m256")]
    vpminub_ymm_k1z_ymm_m256 = 3208,
    /// <summary>
    /// vpminub zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpminub zmm, zmm, zmm","vpminub zmm {k1}{z}, zmm, zmm/m512")]
    vpminub_zmm_zmm_zmm = 3209,
    /// <summary>
    /// vpminub zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpminub zmm, zmm, m512","vpminub zmm {k1}{z}, zmm, zmm/m512")]
    vpminub_zmm_zmm_m512 = 3210,
    /// <summary>
    /// vpminub zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpminub zmm_k1z, zmm, zmm","vpminub zmm {k1}{z}, zmm, zmm/m512")]
    vpminub_zmm_k1z_zmm_zmm = 3211,
    /// <summary>
    /// vpminub zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpminub zmm_k1z, zmm, m512","vpminub zmm {k1}{z}, zmm, zmm/m512")]
    vpminub_zmm_k1z_zmm_m512 = 3212,
    /// <summary>
    /// vpminuw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpminuw xmm, xmm, xmm","vpminuw xmm {k1}{z}, xmm, xmm/m128")]
    vpminuw_xmm_xmm_xmm = 3213,
    /// <summary>
    /// vpminuw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpminuw xmm, xmm, m128","vpminuw xmm {k1}{z}, xmm, xmm/m128")]
    vpminuw_xmm_xmm_m128 = 3214,
    /// <summary>
    /// vpminuw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpminuw xmm_k1z, xmm, xmm","vpminuw xmm {k1}{z}, xmm, xmm/m128")]
    vpminuw_xmm_k1z_xmm_xmm = 3215,
    /// <summary>
    /// vpminuw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpminuw xmm_k1z, xmm, m128","vpminuw xmm {k1}{z}, xmm, xmm/m128")]
    vpminuw_xmm_k1z_xmm_m128 = 3216,
    /// <summary>
    /// vpminuw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpminuw ymm, ymm, ymm","vpminuw ymm {k1}{z}, ymm, ymm/m256")]
    vpminuw_ymm_ymm_ymm = 3217,
    /// <summary>
    /// vpminuw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpminuw ymm, ymm, m256","vpminuw ymm {k1}{z}, ymm, ymm/m256")]
    vpminuw_ymm_ymm_m256 = 3218,
    /// <summary>
    /// vpminuw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpminuw ymm_k1z, ymm, ymm","vpminuw ymm {k1}{z}, ymm, ymm/m256")]
    vpminuw_ymm_k1z_ymm_ymm = 3219,
    /// <summary>
    /// vpminuw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpminuw ymm_k1z, ymm, m256","vpminuw ymm {k1}{z}, ymm, ymm/m256")]
    vpminuw_ymm_k1z_ymm_m256 = 3220,
    /// <summary>
    /// vpminuw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpminuw zmm, zmm, zmm","vpminuw zmm {k1}{z}, zmm, zmm/m512")]
    vpminuw_zmm_zmm_zmm = 3221,
    /// <summary>
    /// vpminuw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpminuw zmm, zmm, m512","vpminuw zmm {k1}{z}, zmm, zmm/m512")]
    vpminuw_zmm_zmm_m512 = 3222,
    /// <summary>
    /// vpminuw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpminuw zmm_k1z, zmm, zmm","vpminuw zmm {k1}{z}, zmm, zmm/m512")]
    vpminuw_zmm_k1z_zmm_zmm = 3223,
    /// <summary>
    /// vpminuw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpminuw zmm_k1z, zmm, m512","vpminuw zmm {k1}{z}, zmm, zmm/m512")]
    vpminuw_zmm_k1z_zmm_m512 = 3224,
    /// <summary>
    /// vpmovb2m k, xmm
    /// </summary>
    [Symbol("vpmovb2m k, xmm","vpmovb2m k, xmm")]
    vpmovb2m_k_xmm = 3225,
    /// <summary>
    /// vpmovb2m k, ymm
    /// </summary>
    [Symbol("vpmovb2m k, ymm","vpmovb2m k, ymm")]
    vpmovb2m_k_ymm = 3226,
    /// <summary>
    /// vpmovb2m k, zmm
    /// </summary>
    [Symbol("vpmovb2m k, zmm","vpmovb2m k, zmm")]
    vpmovb2m_k_zmm = 3227,
    /// <summary>
    /// vpmovd2m k, xmm
    /// </summary>
    [Symbol("vpmovd2m k, xmm","vpmovd2m k, xmm")]
    vpmovd2m_k_xmm = 3228,
    /// <summary>
    /// vpmovd2m k, ymm
    /// </summary>
    [Symbol("vpmovd2m k, ymm","vpmovd2m k, ymm")]
    vpmovd2m_k_ymm = 3229,
    /// <summary>
    /// vpmovd2m k, zmm
    /// </summary>
    [Symbol("vpmovd2m k, zmm","vpmovd2m k, zmm")]
    vpmovd2m_k_zmm = 3230,
    /// <summary>
    /// vpmovdb xmm/m128 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpmovdb xmm_k1z, zmm","vpmovdb xmm/m128 {k1}{z}, zmm")]
    vpmovdb_xmm_k1z_zmm = 3231,
    /// <summary>
    /// vpmovdb xmm/m128 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpmovdb m128_k1z, zmm","vpmovdb xmm/m128 {k1}{z}, zmm")]
    vpmovdb_m128_k1z_zmm = 3232,
    /// <summary>
    /// vpmovdb xmm/m32 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpmovdb xmm_k1z, xmm","vpmovdb xmm/m32 {k1}{z}, xmm")]
    vpmovdb_xmm_k1z_xmm = 3233,
    /// <summary>
    /// vpmovdb xmm/m32 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpmovdb m32_k1z, xmm","vpmovdb xmm/m32 {k1}{z}, xmm")]
    vpmovdb_m32_k1z_xmm = 3234,
    /// <summary>
    /// vpmovdb xmm/m64 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpmovdb xmm_k1z, ymm","vpmovdb xmm/m64 {k1}{z}, ymm")]
    vpmovdb_xmm_k1z_ymm = 3235,
    /// <summary>
    /// vpmovdb xmm/m64 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpmovdb m64_k1z, ymm","vpmovdb xmm/m64 {k1}{z}, ymm")]
    vpmovdb_m64_k1z_ymm = 3236,
    /// <summary>
    /// vpmovdw xmm/m128 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpmovdw xmm_k1z, ymm","vpmovdw xmm/m128 {k1}{z}, ymm")]
    vpmovdw_xmm_k1z_ymm = 3237,
    /// <summary>
    /// vpmovdw xmm/m128 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpmovdw m128_k1z, ymm","vpmovdw xmm/m128 {k1}{z}, ymm")]
    vpmovdw_m128_k1z_ymm = 3238,
    /// <summary>
    /// vpmovdw xmm/m64 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpmovdw xmm_k1z, xmm","vpmovdw xmm/m64 {k1}{z}, xmm")]
    vpmovdw_xmm_k1z_xmm = 3239,
    /// <summary>
    /// vpmovdw xmm/m64 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpmovdw m64_k1z, xmm","vpmovdw xmm/m64 {k1}{z}, xmm")]
    vpmovdw_m64_k1z_xmm = 3240,
    /// <summary>
    /// vpmovdw ymm/m256 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpmovdw ymm_k1z, zmm","vpmovdw ymm/m256 {k1}{z}, zmm")]
    vpmovdw_ymm_k1z_zmm = 3241,
    /// <summary>
    /// vpmovdw ymm/m256 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpmovdw m256_k1z, zmm","vpmovdw ymm/m256 {k1}{z}, zmm")]
    vpmovdw_m256_k1z_zmm = 3242,
    /// <summary>
    /// vpmovm2b xmm, k
    /// </summary>
    [Symbol("vpmovm2b xmm, k","vpmovm2b xmm, k")]
    vpmovm2b_xmm_k = 3243,
    /// <summary>
    /// vpmovm2b ymm, k
    /// </summary>
    [Symbol("vpmovm2b ymm, k","vpmovm2b ymm, k")]
    vpmovm2b_ymm_k = 3244,
    /// <summary>
    /// vpmovm2b zmm, k
    /// </summary>
    [Symbol("vpmovm2b zmm, k","vpmovm2b zmm, k")]
    vpmovm2b_zmm_k = 3245,
    /// <summary>
    /// vpmovm2d xmm, k
    /// </summary>
    [Symbol("vpmovm2d xmm, k","vpmovm2d xmm, k")]
    vpmovm2d_xmm_k = 3246,
    /// <summary>
    /// vpmovm2d ymm, k
    /// </summary>
    [Symbol("vpmovm2d ymm, k","vpmovm2d ymm, k")]
    vpmovm2d_ymm_k = 3247,
    /// <summary>
    /// vpmovm2d zmm, k
    /// </summary>
    [Symbol("vpmovm2d zmm, k","vpmovm2d zmm, k")]
    vpmovm2d_zmm_k = 3248,
    /// <summary>
    /// vpmovm2q xmm, k
    /// </summary>
    [Symbol("vpmovm2q xmm, k","vpmovm2q xmm, k")]
    vpmovm2q_xmm_k = 3249,
    /// <summary>
    /// vpmovm2q ymm, k
    /// </summary>
    [Symbol("vpmovm2q ymm, k","vpmovm2q ymm, k")]
    vpmovm2q_ymm_k = 3250,
    /// <summary>
    /// vpmovm2q zmm, k
    /// </summary>
    [Symbol("vpmovm2q zmm, k","vpmovm2q zmm, k")]
    vpmovm2q_zmm_k = 3251,
    /// <summary>
    /// vpmovm2w xmm, k
    /// </summary>
    [Symbol("vpmovm2w xmm, k","vpmovm2w xmm, k")]
    vpmovm2w_xmm_k = 3252,
    /// <summary>
    /// vpmovm2w ymm, k
    /// </summary>
    [Symbol("vpmovm2w ymm, k","vpmovm2w ymm, k")]
    vpmovm2w_ymm_k = 3253,
    /// <summary>
    /// vpmovm2w zmm, k
    /// </summary>
    [Symbol("vpmovm2w zmm, k","vpmovm2w zmm, k")]
    vpmovm2w_zmm_k = 3254,
    /// <summary>
    /// vpmovmskb reg, xmm
    /// </summary>
    [Symbol("vpmovmskb reg, xmm","vpmovmskb reg, xmm")]
    vpmovmskb_reg_xmm = 3255,
    /// <summary>
    /// vpmovmskb reg, ymm
    /// </summary>
    [Symbol("vpmovmskb reg, ymm","vpmovmskb reg, ymm")]
    vpmovmskb_reg_ymm = 3256,
    /// <summary>
    /// vpmovq2m k, xmm
    /// </summary>
    [Symbol("vpmovq2m k, xmm","vpmovq2m k, xmm")]
    vpmovq2m_k_xmm = 3257,
    /// <summary>
    /// vpmovq2m k, ymm
    /// </summary>
    [Symbol("vpmovq2m k, ymm","vpmovq2m k, ymm")]
    vpmovq2m_k_ymm = 3258,
    /// <summary>
    /// vpmovq2m k, zmm
    /// </summary>
    [Symbol("vpmovq2m k, zmm","vpmovq2m k, zmm")]
    vpmovq2m_k_zmm = 3259,
    /// <summary>
    /// vpmovqb xmm/m16 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpmovqb xmm_k1z, xmm","vpmovqb xmm/m16 {k1}{z}, xmm")]
    vpmovqb_xmm_k1z_xmm = 3260,
    /// <summary>
    /// vpmovqb xmm/m16 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpmovqb m16_k1z, xmm","vpmovqb xmm/m16 {k1}{z}, xmm")]
    vpmovqb_m16_k1z_xmm = 3261,
    /// <summary>
    /// vpmovqb xmm/m32 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpmovqb xmm_k1z, ymm","vpmovqb xmm/m32 {k1}{z}, ymm")]
    vpmovqb_xmm_k1z_ymm = 3262,
    /// <summary>
    /// vpmovqb xmm/m32 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpmovqb m32_k1z, ymm","vpmovqb xmm/m32 {k1}{z}, ymm")]
    vpmovqb_m32_k1z_ymm = 3263,
    /// <summary>
    /// vpmovqb xmm/m64 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpmovqb xmm_k1z, zmm","vpmovqb xmm/m64 {k1}{z}, zmm")]
    vpmovqb_xmm_k1z_zmm = 3264,
    /// <summary>
    /// vpmovqb xmm/m64 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpmovqb m64_k1z, zmm","vpmovqb xmm/m64 {k1}{z}, zmm")]
    vpmovqb_m64_k1z_zmm = 3265,
    /// <summary>
    /// vpmovqd xmm/m128 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpmovqd xmm_k1z, xmm","vpmovqd xmm/m128 {k1}{z}, xmm")]
    vpmovqd_xmm_k1z_xmm = 3266,
    /// <summary>
    /// vpmovqd xmm/m128 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpmovqd m128_k1z, xmm","vpmovqd xmm/m128 {k1}{z}, xmm")]
    vpmovqd_m128_k1z_xmm = 3267,
    /// <summary>
    /// vpmovqd xmm/m128 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpmovqd xmm_k1z, ymm","vpmovqd xmm/m128 {k1}{z}, ymm")]
    vpmovqd_xmm_k1z_ymm = 3268,
    /// <summary>
    /// vpmovqd xmm/m128 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpmovqd m128_k1z, ymm","vpmovqd xmm/m128 {k1}{z}, ymm")]
    vpmovqd_m128_k1z_ymm = 3269,
    /// <summary>
    /// vpmovqd ymm/m256 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpmovqd ymm_k1z, zmm","vpmovqd ymm/m256 {k1}{z}, zmm")]
    vpmovqd_ymm_k1z_zmm = 3270,
    /// <summary>
    /// vpmovqd ymm/m256 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpmovqd m256_k1z, zmm","vpmovqd ymm/m256 {k1}{z}, zmm")]
    vpmovqd_m256_k1z_zmm = 3271,
    /// <summary>
    /// vpmovqw xmm/m128 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpmovqw xmm_k1z, zmm","vpmovqw xmm/m128 {k1}{z}, zmm")]
    vpmovqw_xmm_k1z_zmm = 3272,
    /// <summary>
    /// vpmovqw xmm/m128 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpmovqw m128_k1z, zmm","vpmovqw xmm/m128 {k1}{z}, zmm")]
    vpmovqw_m128_k1z_zmm = 3273,
    /// <summary>
    /// vpmovqw xmm/m32 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpmovqw xmm_k1z, xmm","vpmovqw xmm/m32 {k1}{z}, xmm")]
    vpmovqw_xmm_k1z_xmm = 3274,
    /// <summary>
    /// vpmovqw xmm/m32 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpmovqw m32_k1z, xmm","vpmovqw xmm/m32 {k1}{z}, xmm")]
    vpmovqw_m32_k1z_xmm = 3275,
    /// <summary>
    /// vpmovqw xmm/m64 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpmovqw xmm_k1z, ymm","vpmovqw xmm/m64 {k1}{z}, ymm")]
    vpmovqw_xmm_k1z_ymm = 3276,
    /// <summary>
    /// vpmovqw xmm/m64 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpmovqw m64_k1z, ymm","vpmovqw xmm/m64 {k1}{z}, ymm")]
    vpmovqw_m64_k1z_ymm = 3277,
    /// <summary>
    /// vpmovsdb xmm/m128 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpmovsdb xmm_k1z, zmm","vpmovsdb xmm/m128 {k1}{z}, zmm")]
    vpmovsdb_xmm_k1z_zmm = 3278,
    /// <summary>
    /// vpmovsdb xmm/m128 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpmovsdb m128_k1z, zmm","vpmovsdb xmm/m128 {k1}{z}, zmm")]
    vpmovsdb_m128_k1z_zmm = 3279,
    /// <summary>
    /// vpmovsdb xmm/m32 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpmovsdb xmm_k1z, xmm","vpmovsdb xmm/m32 {k1}{z}, xmm")]
    vpmovsdb_xmm_k1z_xmm = 3280,
    /// <summary>
    /// vpmovsdb xmm/m32 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpmovsdb m32_k1z, xmm","vpmovsdb xmm/m32 {k1}{z}, xmm")]
    vpmovsdb_m32_k1z_xmm = 3281,
    /// <summary>
    /// vpmovsdb xmm/m64 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpmovsdb xmm_k1z, ymm","vpmovsdb xmm/m64 {k1}{z}, ymm")]
    vpmovsdb_xmm_k1z_ymm = 3282,
    /// <summary>
    /// vpmovsdb xmm/m64 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpmovsdb m64_k1z, ymm","vpmovsdb xmm/m64 {k1}{z}, ymm")]
    vpmovsdb_m64_k1z_ymm = 3283,
    /// <summary>
    /// vpmovsdw xmm/m128 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpmovsdw xmm_k1z, ymm","vpmovsdw xmm/m128 {k1}{z}, ymm")]
    vpmovsdw_xmm_k1z_ymm = 3284,
    /// <summary>
    /// vpmovsdw xmm/m128 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpmovsdw m128_k1z, ymm","vpmovsdw xmm/m128 {k1}{z}, ymm")]
    vpmovsdw_m128_k1z_ymm = 3285,
    /// <summary>
    /// vpmovsdw xmm/m64 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpmovsdw xmm_k1z, xmm","vpmovsdw xmm/m64 {k1}{z}, xmm")]
    vpmovsdw_xmm_k1z_xmm = 3286,
    /// <summary>
    /// vpmovsdw xmm/m64 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpmovsdw m64_k1z, xmm","vpmovsdw xmm/m64 {k1}{z}, xmm")]
    vpmovsdw_m64_k1z_xmm = 3287,
    /// <summary>
    /// vpmovsdw ymm/m256 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpmovsdw ymm_k1z, zmm","vpmovsdw ymm/m256 {k1}{z}, zmm")]
    vpmovsdw_ymm_k1z_zmm = 3288,
    /// <summary>
    /// vpmovsdw ymm/m256 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpmovsdw m256_k1z, zmm","vpmovsdw ymm/m256 {k1}{z}, zmm")]
    vpmovsdw_m256_k1z_zmm = 3289,
    /// <summary>
    /// vpmovsqb xmm/m16 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpmovsqb xmm_k1z, xmm","vpmovsqb xmm/m16 {k1}{z}, xmm")]
    vpmovsqb_xmm_k1z_xmm = 3290,
    /// <summary>
    /// vpmovsqb xmm/m16 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpmovsqb m16_k1z, xmm","vpmovsqb xmm/m16 {k1}{z}, xmm")]
    vpmovsqb_m16_k1z_xmm = 3291,
    /// <summary>
    /// vpmovsqb xmm/m32 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpmovsqb xmm_k1z, ymm","vpmovsqb xmm/m32 {k1}{z}, ymm")]
    vpmovsqb_xmm_k1z_ymm = 3292,
    /// <summary>
    /// vpmovsqb xmm/m32 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpmovsqb m32_k1z, ymm","vpmovsqb xmm/m32 {k1}{z}, ymm")]
    vpmovsqb_m32_k1z_ymm = 3293,
    /// <summary>
    /// vpmovsqb xmm/m64 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpmovsqb xmm_k1z, zmm","vpmovsqb xmm/m64 {k1}{z}, zmm")]
    vpmovsqb_xmm_k1z_zmm = 3294,
    /// <summary>
    /// vpmovsqb xmm/m64 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpmovsqb m64_k1z, zmm","vpmovsqb xmm/m64 {k1}{z}, zmm")]
    vpmovsqb_m64_k1z_zmm = 3295,
    /// <summary>
    /// vpmovsqd xmm/m128 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpmovsqd xmm_k1z, ymm","vpmovsqd xmm/m128 {k1}{z}, ymm")]
    vpmovsqd_xmm_k1z_ymm = 3296,
    /// <summary>
    /// vpmovsqd xmm/m128 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpmovsqd m128_k1z, ymm","vpmovsqd xmm/m128 {k1}{z}, ymm")]
    vpmovsqd_m128_k1z_ymm = 3297,
    /// <summary>
    /// vpmovsqd xmm/m64 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpmovsqd xmm_k1z, xmm","vpmovsqd xmm/m64 {k1}{z}, xmm")]
    vpmovsqd_xmm_k1z_xmm = 3298,
    /// <summary>
    /// vpmovsqd xmm/m64 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpmovsqd m64_k1z, xmm","vpmovsqd xmm/m64 {k1}{z}, xmm")]
    vpmovsqd_m64_k1z_xmm = 3299,
    /// <summary>
    /// vpmovsqd ymm/m256 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpmovsqd ymm_k1z, zmm","vpmovsqd ymm/m256 {k1}{z}, zmm")]
    vpmovsqd_ymm_k1z_zmm = 3300,
    /// <summary>
    /// vpmovsqd ymm/m256 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpmovsqd m256_k1z, zmm","vpmovsqd ymm/m256 {k1}{z}, zmm")]
    vpmovsqd_m256_k1z_zmm = 3301,
    /// <summary>
    /// vpmovsqw xmm/m128 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpmovsqw xmm_k1z, zmm","vpmovsqw xmm/m128 {k1}{z}, zmm")]
    vpmovsqw_xmm_k1z_zmm = 3302,
    /// <summary>
    /// vpmovsqw xmm/m128 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpmovsqw m128_k1z, zmm","vpmovsqw xmm/m128 {k1}{z}, zmm")]
    vpmovsqw_m128_k1z_zmm = 3303,
    /// <summary>
    /// vpmovsqw xmm/m32 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpmovsqw xmm_k1z, xmm","vpmovsqw xmm/m32 {k1}{z}, xmm")]
    vpmovsqw_xmm_k1z_xmm = 3304,
    /// <summary>
    /// vpmovsqw xmm/m32 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpmovsqw m32_k1z, xmm","vpmovsqw xmm/m32 {k1}{z}, xmm")]
    vpmovsqw_m32_k1z_xmm = 3305,
    /// <summary>
    /// vpmovsqw xmm/m64 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpmovsqw xmm_k1z, ymm","vpmovsqw xmm/m64 {k1}{z}, ymm")]
    vpmovsqw_xmm_k1z_ymm = 3306,
    /// <summary>
    /// vpmovsqw xmm/m64 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpmovsqw m64_k1z, ymm","vpmovsqw xmm/m64 {k1}{z}, ymm")]
    vpmovsqw_m64_k1z_ymm = 3307,
    /// <summary>
    /// vpmovswb xmm/m128 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpmovswb xmm_k1z, ymm","vpmovswb xmm/m128 {k1}{z}, ymm")]
    vpmovswb_xmm_k1z_ymm = 3308,
    /// <summary>
    /// vpmovswb xmm/m128 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpmovswb m128_k1z, ymm","vpmovswb xmm/m128 {k1}{z}, ymm")]
    vpmovswb_m128_k1z_ymm = 3309,
    /// <summary>
    /// vpmovswb xmm/m64 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpmovswb xmm_k1z, xmm","vpmovswb xmm/m64 {k1}{z}, xmm")]
    vpmovswb_xmm_k1z_xmm = 3310,
    /// <summary>
    /// vpmovswb xmm/m64 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpmovswb m64_k1z, xmm","vpmovswb xmm/m64 {k1}{z}, xmm")]
    vpmovswb_m64_k1z_xmm = 3311,
    /// <summary>
    /// vpmovswb ymm/m256 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpmovswb ymm_k1z, zmm","vpmovswb ymm/m256 {k1}{z}, zmm")]
    vpmovswb_ymm_k1z_zmm = 3312,
    /// <summary>
    /// vpmovswb ymm/m256 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpmovswb m256_k1z, zmm","vpmovswb ymm/m256 {k1}{z}, zmm")]
    vpmovswb_m256_k1z_zmm = 3313,
    /// <summary>
    /// vpmovsxbd xmm {k1}{z}, xmm/m32
    /// </summary>
    [Symbol("vpmovsxbd xmm, xmm","vpmovsxbd xmm {k1}{z}, xmm/m32")]
    vpmovsxbd_xmm_xmm = 3314,
    /// <summary>
    /// vpmovsxbd xmm {k1}{z}, xmm/m32
    /// </summary>
    [Symbol("vpmovsxbd xmm, m32","vpmovsxbd xmm {k1}{z}, xmm/m32")]
    vpmovsxbd_xmm_m32 = 3315,
    /// <summary>
    /// vpmovsxbd xmm {k1}{z}, xmm/m32
    /// </summary>
    [Symbol("vpmovsxbd xmm_k1z, xmm","vpmovsxbd xmm {k1}{z}, xmm/m32")]
    vpmovsxbd_xmm_k1z_xmm = 3316,
    /// <summary>
    /// vpmovsxbd xmm {k1}{z}, xmm/m32
    /// </summary>
    [Symbol("vpmovsxbd xmm_k1z, m32","vpmovsxbd xmm {k1}{z}, xmm/m32")]
    vpmovsxbd_xmm_k1z_m32 = 3317,
    /// <summary>
    /// vpmovsxbd ymm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpmovsxbd ymm, xmm","vpmovsxbd ymm {k1}{z}, xmm/m64")]
    vpmovsxbd_ymm_xmm = 3318,
    /// <summary>
    /// vpmovsxbd ymm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpmovsxbd ymm, m64","vpmovsxbd ymm {k1}{z}, xmm/m64")]
    vpmovsxbd_ymm_m64 = 3319,
    /// <summary>
    /// vpmovsxbd ymm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpmovsxbd ymm_k1z, xmm","vpmovsxbd ymm {k1}{z}, xmm/m64")]
    vpmovsxbd_ymm_k1z_xmm = 3320,
    /// <summary>
    /// vpmovsxbd ymm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpmovsxbd ymm_k1z, m64","vpmovsxbd ymm {k1}{z}, xmm/m64")]
    vpmovsxbd_ymm_k1z_m64 = 3321,
    /// <summary>
    /// vpmovsxbd zmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vpmovsxbd zmm, xmm","vpmovsxbd zmm {k1}{z}, xmm/m128")]
    vpmovsxbd_zmm_xmm = 3322,
    /// <summary>
    /// vpmovsxbd zmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vpmovsxbd zmm, m128","vpmovsxbd zmm {k1}{z}, xmm/m128")]
    vpmovsxbd_zmm_m128 = 3323,
    /// <summary>
    /// vpmovsxbd zmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vpmovsxbd zmm_k1z, xmm","vpmovsxbd zmm {k1}{z}, xmm/m128")]
    vpmovsxbd_zmm_k1z_xmm = 3324,
    /// <summary>
    /// vpmovsxbd zmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vpmovsxbd zmm_k1z, m128","vpmovsxbd zmm {k1}{z}, xmm/m128")]
    vpmovsxbd_zmm_k1z_m128 = 3325,
    /// <summary>
    /// vpmovsxbq xmm {k1}{z}, xmm/m16
    /// </summary>
    [Symbol("vpmovsxbq xmm, xmm","vpmovsxbq xmm {k1}{z}, xmm/m16")]
    vpmovsxbq_xmm_xmm = 3326,
    /// <summary>
    /// vpmovsxbq xmm {k1}{z}, xmm/m16
    /// </summary>
    [Symbol("vpmovsxbq xmm, m16","vpmovsxbq xmm {k1}{z}, xmm/m16")]
    vpmovsxbq_xmm_m16 = 3327,
    /// <summary>
    /// vpmovsxbq xmm {k1}{z}, xmm/m16
    /// </summary>
    [Symbol("vpmovsxbq xmm_k1z, xmm","vpmovsxbq xmm {k1}{z}, xmm/m16")]
    vpmovsxbq_xmm_k1z_xmm = 3328,
    /// <summary>
    /// vpmovsxbq xmm {k1}{z}, xmm/m16
    /// </summary>
    [Symbol("vpmovsxbq xmm_k1z, m16","vpmovsxbq xmm {k1}{z}, xmm/m16")]
    vpmovsxbq_xmm_k1z_m16 = 3329,
    /// <summary>
    /// vpmovsxbq ymm {k1}{z}, xmm/m32
    /// </summary>
    [Symbol("vpmovsxbq ymm, xmm","vpmovsxbq ymm {k1}{z}, xmm/m32")]
    vpmovsxbq_ymm_xmm = 3330,
    /// <summary>
    /// vpmovsxbq ymm {k1}{z}, xmm/m32
    /// </summary>
    [Symbol("vpmovsxbq ymm, m32","vpmovsxbq ymm {k1}{z}, xmm/m32")]
    vpmovsxbq_ymm_m32 = 3331,
    /// <summary>
    /// vpmovsxbq ymm {k1}{z}, xmm/m32
    /// </summary>
    [Symbol("vpmovsxbq ymm_k1z, xmm","vpmovsxbq ymm {k1}{z}, xmm/m32")]
    vpmovsxbq_ymm_k1z_xmm = 3332,
    /// <summary>
    /// vpmovsxbq ymm {k1}{z}, xmm/m32
    /// </summary>
    [Symbol("vpmovsxbq ymm_k1z, m32","vpmovsxbq ymm {k1}{z}, xmm/m32")]
    vpmovsxbq_ymm_k1z_m32 = 3333,
    /// <summary>
    /// vpmovsxbq zmm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpmovsxbq zmm, xmm","vpmovsxbq zmm {k1}{z}, xmm/m64")]
    vpmovsxbq_zmm_xmm = 3334,
    /// <summary>
    /// vpmovsxbq zmm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpmovsxbq zmm, m64","vpmovsxbq zmm {k1}{z}, xmm/m64")]
    vpmovsxbq_zmm_m64 = 3335,
    /// <summary>
    /// vpmovsxbq zmm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpmovsxbq zmm_k1z, xmm","vpmovsxbq zmm {k1}{z}, xmm/m64")]
    vpmovsxbq_zmm_k1z_xmm = 3336,
    /// <summary>
    /// vpmovsxbq zmm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpmovsxbq zmm_k1z, m64","vpmovsxbq zmm {k1}{z}, xmm/m64")]
    vpmovsxbq_zmm_k1z_m64 = 3337,
    /// <summary>
    /// vpmovsxbw xmm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpmovsxbw xmm, xmm","vpmovsxbw xmm {k1}{z}, xmm/m64")]
    vpmovsxbw_xmm_xmm = 3338,
    /// <summary>
    /// vpmovsxbw xmm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpmovsxbw xmm, m64","vpmovsxbw xmm {k1}{z}, xmm/m64")]
    vpmovsxbw_xmm_m64 = 3339,
    /// <summary>
    /// vpmovsxbw xmm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpmovsxbw xmm_k1z, xmm","vpmovsxbw xmm {k1}{z}, xmm/m64")]
    vpmovsxbw_xmm_k1z_xmm = 3340,
    /// <summary>
    /// vpmovsxbw xmm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpmovsxbw xmm_k1z, m64","vpmovsxbw xmm {k1}{z}, xmm/m64")]
    vpmovsxbw_xmm_k1z_m64 = 3341,
    /// <summary>
    /// vpmovsxbw ymm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vpmovsxbw ymm, xmm","vpmovsxbw ymm {k1}{z}, xmm/m128")]
    vpmovsxbw_ymm_xmm = 3342,
    /// <summary>
    /// vpmovsxbw ymm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vpmovsxbw ymm, m128","vpmovsxbw ymm {k1}{z}, xmm/m128")]
    vpmovsxbw_ymm_m128 = 3343,
    /// <summary>
    /// vpmovsxbw ymm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vpmovsxbw ymm_k1z, xmm","vpmovsxbw ymm {k1}{z}, xmm/m128")]
    vpmovsxbw_ymm_k1z_xmm = 3344,
    /// <summary>
    /// vpmovsxbw ymm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vpmovsxbw ymm_k1z, m128","vpmovsxbw ymm {k1}{z}, xmm/m128")]
    vpmovsxbw_ymm_k1z_m128 = 3345,
    /// <summary>
    /// vpmovsxbw zmm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vpmovsxbw zmm, ymm","vpmovsxbw zmm {k1}{z}, ymm/m256")]
    vpmovsxbw_zmm_ymm = 3346,
    /// <summary>
    /// vpmovsxbw zmm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vpmovsxbw zmm, m256","vpmovsxbw zmm {k1}{z}, ymm/m256")]
    vpmovsxbw_zmm_m256 = 3347,
    /// <summary>
    /// vpmovsxbw zmm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vpmovsxbw zmm_k1z, ymm","vpmovsxbw zmm {k1}{z}, ymm/m256")]
    vpmovsxbw_zmm_k1z_ymm = 3348,
    /// <summary>
    /// vpmovsxbw zmm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vpmovsxbw zmm_k1z, m256","vpmovsxbw zmm {k1}{z}, ymm/m256")]
    vpmovsxbw_zmm_k1z_m256 = 3349,
    /// <summary>
    /// vpmovsxdq xmm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpmovsxdq xmm, xmm","vpmovsxdq xmm {k1}{z}, xmm/m64")]
    vpmovsxdq_xmm_xmm = 3350,
    /// <summary>
    /// vpmovsxdq xmm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpmovsxdq xmm, m64","vpmovsxdq xmm {k1}{z}, xmm/m64")]
    vpmovsxdq_xmm_m64 = 3351,
    /// <summary>
    /// vpmovsxdq xmm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpmovsxdq xmm_k1z, xmm","vpmovsxdq xmm {k1}{z}, xmm/m64")]
    vpmovsxdq_xmm_k1z_xmm = 3352,
    /// <summary>
    /// vpmovsxdq xmm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpmovsxdq xmm_k1z, m64","vpmovsxdq xmm {k1}{z}, xmm/m64")]
    vpmovsxdq_xmm_k1z_m64 = 3353,
    /// <summary>
    /// vpmovsxdq ymm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vpmovsxdq ymm, xmm","vpmovsxdq ymm {k1}{z}, xmm/m128")]
    vpmovsxdq_ymm_xmm = 3354,
    /// <summary>
    /// vpmovsxdq ymm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vpmovsxdq ymm, m128","vpmovsxdq ymm {k1}{z}, xmm/m128")]
    vpmovsxdq_ymm_m128 = 3355,
    /// <summary>
    /// vpmovsxdq ymm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vpmovsxdq ymm_k1z, xmm","vpmovsxdq ymm {k1}{z}, xmm/m128")]
    vpmovsxdq_ymm_k1z_xmm = 3356,
    /// <summary>
    /// vpmovsxdq ymm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vpmovsxdq ymm_k1z, m128","vpmovsxdq ymm {k1}{z}, xmm/m128")]
    vpmovsxdq_ymm_k1z_m128 = 3357,
    /// <summary>
    /// vpmovsxdq zmm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vpmovsxdq zmm, ymm","vpmovsxdq zmm {k1}{z}, ymm/m256")]
    vpmovsxdq_zmm_ymm = 3358,
    /// <summary>
    /// vpmovsxdq zmm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vpmovsxdq zmm, m256","vpmovsxdq zmm {k1}{z}, ymm/m256")]
    vpmovsxdq_zmm_m256 = 3359,
    /// <summary>
    /// vpmovsxdq zmm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vpmovsxdq zmm_k1z, ymm","vpmovsxdq zmm {k1}{z}, ymm/m256")]
    vpmovsxdq_zmm_k1z_ymm = 3360,
    /// <summary>
    /// vpmovsxdq zmm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vpmovsxdq zmm_k1z, m256","vpmovsxdq zmm {k1}{z}, ymm/m256")]
    vpmovsxdq_zmm_k1z_m256 = 3361,
    /// <summary>
    /// vpmovsxwd xmm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpmovsxwd xmm, xmm","vpmovsxwd xmm {k1}{z}, xmm/m64")]
    vpmovsxwd_xmm_xmm = 3362,
    /// <summary>
    /// vpmovsxwd xmm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpmovsxwd xmm, m64","vpmovsxwd xmm {k1}{z}, xmm/m64")]
    vpmovsxwd_xmm_m64 = 3363,
    /// <summary>
    /// vpmovsxwd xmm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpmovsxwd xmm_k1z, xmm","vpmovsxwd xmm {k1}{z}, xmm/m64")]
    vpmovsxwd_xmm_k1z_xmm = 3364,
    /// <summary>
    /// vpmovsxwd xmm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpmovsxwd xmm_k1z, m64","vpmovsxwd xmm {k1}{z}, xmm/m64")]
    vpmovsxwd_xmm_k1z_m64 = 3365,
    /// <summary>
    /// vpmovsxwd ymm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vpmovsxwd ymm, xmm","vpmovsxwd ymm {k1}{z}, xmm/m128")]
    vpmovsxwd_ymm_xmm = 3366,
    /// <summary>
    /// vpmovsxwd ymm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vpmovsxwd ymm, m128","vpmovsxwd ymm {k1}{z}, xmm/m128")]
    vpmovsxwd_ymm_m128 = 3367,
    /// <summary>
    /// vpmovsxwd ymm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vpmovsxwd ymm_k1z, xmm","vpmovsxwd ymm {k1}{z}, xmm/m128")]
    vpmovsxwd_ymm_k1z_xmm = 3368,
    /// <summary>
    /// vpmovsxwd ymm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vpmovsxwd ymm_k1z, m128","vpmovsxwd ymm {k1}{z}, xmm/m128")]
    vpmovsxwd_ymm_k1z_m128 = 3369,
    /// <summary>
    /// vpmovsxwd zmm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vpmovsxwd zmm, ymm","vpmovsxwd zmm {k1}{z}, ymm/m256")]
    vpmovsxwd_zmm_ymm = 3370,
    /// <summary>
    /// vpmovsxwd zmm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vpmovsxwd zmm, m256","vpmovsxwd zmm {k1}{z}, ymm/m256")]
    vpmovsxwd_zmm_m256 = 3371,
    /// <summary>
    /// vpmovsxwd zmm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vpmovsxwd zmm_k1z, ymm","vpmovsxwd zmm {k1}{z}, ymm/m256")]
    vpmovsxwd_zmm_k1z_ymm = 3372,
    /// <summary>
    /// vpmovsxwd zmm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vpmovsxwd zmm_k1z, m256","vpmovsxwd zmm {k1}{z}, ymm/m256")]
    vpmovsxwd_zmm_k1z_m256 = 3373,
    /// <summary>
    /// vpmovsxwq xmm {k1}{z}, xmm/m32
    /// </summary>
    [Symbol("vpmovsxwq xmm, xmm","vpmovsxwq xmm {k1}{z}, xmm/m32")]
    vpmovsxwq_xmm_xmm = 3374,
    /// <summary>
    /// vpmovsxwq xmm {k1}{z}, xmm/m32
    /// </summary>
    [Symbol("vpmovsxwq xmm, m32","vpmovsxwq xmm {k1}{z}, xmm/m32")]
    vpmovsxwq_xmm_m32 = 3375,
    /// <summary>
    /// vpmovsxwq xmm {k1}{z}, xmm/m32
    /// </summary>
    [Symbol("vpmovsxwq xmm_k1z, xmm","vpmovsxwq xmm {k1}{z}, xmm/m32")]
    vpmovsxwq_xmm_k1z_xmm = 3376,
    /// <summary>
    /// vpmovsxwq xmm {k1}{z}, xmm/m32
    /// </summary>
    [Symbol("vpmovsxwq xmm_k1z, m32","vpmovsxwq xmm {k1}{z}, xmm/m32")]
    vpmovsxwq_xmm_k1z_m32 = 3377,
    /// <summary>
    /// vpmovsxwq ymm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpmovsxwq ymm, xmm","vpmovsxwq ymm {k1}{z}, xmm/m64")]
    vpmovsxwq_ymm_xmm = 3378,
    /// <summary>
    /// vpmovsxwq ymm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpmovsxwq ymm, m64","vpmovsxwq ymm {k1}{z}, xmm/m64")]
    vpmovsxwq_ymm_m64 = 3379,
    /// <summary>
    /// vpmovsxwq ymm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpmovsxwq ymm_k1z, xmm","vpmovsxwq ymm {k1}{z}, xmm/m64")]
    vpmovsxwq_ymm_k1z_xmm = 3380,
    /// <summary>
    /// vpmovsxwq ymm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpmovsxwq ymm_k1z, m64","vpmovsxwq ymm {k1}{z}, xmm/m64")]
    vpmovsxwq_ymm_k1z_m64 = 3381,
    /// <summary>
    /// vpmovsxwq zmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vpmovsxwq zmm, xmm","vpmovsxwq zmm {k1}{z}, xmm/m128")]
    vpmovsxwq_zmm_xmm = 3382,
    /// <summary>
    /// vpmovsxwq zmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vpmovsxwq zmm, m128","vpmovsxwq zmm {k1}{z}, xmm/m128")]
    vpmovsxwq_zmm_m128 = 3383,
    /// <summary>
    /// vpmovsxwq zmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vpmovsxwq zmm_k1z, xmm","vpmovsxwq zmm {k1}{z}, xmm/m128")]
    vpmovsxwq_zmm_k1z_xmm = 3384,
    /// <summary>
    /// vpmovsxwq zmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vpmovsxwq zmm_k1z, m128","vpmovsxwq zmm {k1}{z}, xmm/m128")]
    vpmovsxwq_zmm_k1z_m128 = 3385,
    /// <summary>
    /// vpmovusdb xmm/m128 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpmovusdb xmm_k1z, zmm","vpmovusdb xmm/m128 {k1}{z}, zmm")]
    vpmovusdb_xmm_k1z_zmm = 3386,
    /// <summary>
    /// vpmovusdb xmm/m128 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpmovusdb m128_k1z, zmm","vpmovusdb xmm/m128 {k1}{z}, zmm")]
    vpmovusdb_m128_k1z_zmm = 3387,
    /// <summary>
    /// vpmovusdb xmm/m32 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpmovusdb xmm_k1z, xmm","vpmovusdb xmm/m32 {k1}{z}, xmm")]
    vpmovusdb_xmm_k1z_xmm = 3388,
    /// <summary>
    /// vpmovusdb xmm/m32 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpmovusdb m32_k1z, xmm","vpmovusdb xmm/m32 {k1}{z}, xmm")]
    vpmovusdb_m32_k1z_xmm = 3389,
    /// <summary>
    /// vpmovusdb xmm/m64 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpmovusdb xmm_k1z, ymm","vpmovusdb xmm/m64 {k1}{z}, ymm")]
    vpmovusdb_xmm_k1z_ymm = 3390,
    /// <summary>
    /// vpmovusdb xmm/m64 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpmovusdb m64_k1z, ymm","vpmovusdb xmm/m64 {k1}{z}, ymm")]
    vpmovusdb_m64_k1z_ymm = 3391,
    /// <summary>
    /// vpmovusdw xmm/m128 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpmovusdw xmm_k1z, ymm","vpmovusdw xmm/m128 {k1}{z}, ymm")]
    vpmovusdw_xmm_k1z_ymm = 3392,
    /// <summary>
    /// vpmovusdw xmm/m128 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpmovusdw m128_k1z, ymm","vpmovusdw xmm/m128 {k1}{z}, ymm")]
    vpmovusdw_m128_k1z_ymm = 3393,
    /// <summary>
    /// vpmovusdw xmm/m64 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpmovusdw xmm_k1z, xmm","vpmovusdw xmm/m64 {k1}{z}, xmm")]
    vpmovusdw_xmm_k1z_xmm = 3394,
    /// <summary>
    /// vpmovusdw xmm/m64 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpmovusdw m64_k1z, xmm","vpmovusdw xmm/m64 {k1}{z}, xmm")]
    vpmovusdw_m64_k1z_xmm = 3395,
    /// <summary>
    /// vpmovusdw ymm/m256 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpmovusdw ymm_k1z, zmm","vpmovusdw ymm/m256 {k1}{z}, zmm")]
    vpmovusdw_ymm_k1z_zmm = 3396,
    /// <summary>
    /// vpmovusdw ymm/m256 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpmovusdw m256_k1z, zmm","vpmovusdw ymm/m256 {k1}{z}, zmm")]
    vpmovusdw_m256_k1z_zmm = 3397,
    /// <summary>
    /// vpmovusqb xmm/m16 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpmovusqb xmm_k1z, xmm","vpmovusqb xmm/m16 {k1}{z}, xmm")]
    vpmovusqb_xmm_k1z_xmm = 3398,
    /// <summary>
    /// vpmovusqb xmm/m16 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpmovusqb m16_k1z, xmm","vpmovusqb xmm/m16 {k1}{z}, xmm")]
    vpmovusqb_m16_k1z_xmm = 3399,
    /// <summary>
    /// vpmovusqb xmm/m32 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpmovusqb xmm_k1z, ymm","vpmovusqb xmm/m32 {k1}{z}, ymm")]
    vpmovusqb_xmm_k1z_ymm = 3400,
    /// <summary>
    /// vpmovusqb xmm/m32 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpmovusqb m32_k1z, ymm","vpmovusqb xmm/m32 {k1}{z}, ymm")]
    vpmovusqb_m32_k1z_ymm = 3401,
    /// <summary>
    /// vpmovusqb xmm/m64 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpmovusqb xmm_k1z, zmm","vpmovusqb xmm/m64 {k1}{z}, zmm")]
    vpmovusqb_xmm_k1z_zmm = 3402,
    /// <summary>
    /// vpmovusqb xmm/m64 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpmovusqb m64_k1z, zmm","vpmovusqb xmm/m64 {k1}{z}, zmm")]
    vpmovusqb_m64_k1z_zmm = 3403,
    /// <summary>
    /// vpmovusqd xmm/m128 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpmovusqd xmm_k1z, ymm","vpmovusqd xmm/m128 {k1}{z}, ymm")]
    vpmovusqd_xmm_k1z_ymm = 3404,
    /// <summary>
    /// vpmovusqd xmm/m128 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpmovusqd m128_k1z, ymm","vpmovusqd xmm/m128 {k1}{z}, ymm")]
    vpmovusqd_m128_k1z_ymm = 3405,
    /// <summary>
    /// vpmovusqd xmm/m64 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpmovusqd xmm_k1z, xmm","vpmovusqd xmm/m64 {k1}{z}, xmm")]
    vpmovusqd_xmm_k1z_xmm = 3406,
    /// <summary>
    /// vpmovusqd xmm/m64 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpmovusqd m64_k1z, xmm","vpmovusqd xmm/m64 {k1}{z}, xmm")]
    vpmovusqd_m64_k1z_xmm = 3407,
    /// <summary>
    /// vpmovusqd ymm/m256 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpmovusqd ymm_k1z, zmm","vpmovusqd ymm/m256 {k1}{z}, zmm")]
    vpmovusqd_ymm_k1z_zmm = 3408,
    /// <summary>
    /// vpmovusqd ymm/m256 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpmovusqd m256_k1z, zmm","vpmovusqd ymm/m256 {k1}{z}, zmm")]
    vpmovusqd_m256_k1z_zmm = 3409,
    /// <summary>
    /// vpmovusqw xmm/m128 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpmovusqw xmm_k1z, zmm","vpmovusqw xmm/m128 {k1}{z}, zmm")]
    vpmovusqw_xmm_k1z_zmm = 3410,
    /// <summary>
    /// vpmovusqw xmm/m128 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpmovusqw m128_k1z, zmm","vpmovusqw xmm/m128 {k1}{z}, zmm")]
    vpmovusqw_m128_k1z_zmm = 3411,
    /// <summary>
    /// vpmovusqw xmm/m32 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpmovusqw xmm_k1z, xmm","vpmovusqw xmm/m32 {k1}{z}, xmm")]
    vpmovusqw_xmm_k1z_xmm = 3412,
    /// <summary>
    /// vpmovusqw xmm/m32 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpmovusqw m32_k1z, xmm","vpmovusqw xmm/m32 {k1}{z}, xmm")]
    vpmovusqw_m32_k1z_xmm = 3413,
    /// <summary>
    /// vpmovusqw xmm/m64 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpmovusqw xmm_k1z, ymm","vpmovusqw xmm/m64 {k1}{z}, ymm")]
    vpmovusqw_xmm_k1z_ymm = 3414,
    /// <summary>
    /// vpmovusqw xmm/m64 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpmovusqw m64_k1z, ymm","vpmovusqw xmm/m64 {k1}{z}, ymm")]
    vpmovusqw_m64_k1z_ymm = 3415,
    /// <summary>
    /// vpmovuswb xmm/m128 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpmovuswb xmm_k1z, ymm","vpmovuswb xmm/m128 {k1}{z}, ymm")]
    vpmovuswb_xmm_k1z_ymm = 3416,
    /// <summary>
    /// vpmovuswb xmm/m128 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpmovuswb m128_k1z, ymm","vpmovuswb xmm/m128 {k1}{z}, ymm")]
    vpmovuswb_m128_k1z_ymm = 3417,
    /// <summary>
    /// vpmovuswb xmm/m64 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpmovuswb xmm_k1z, xmm","vpmovuswb xmm/m64 {k1}{z}, xmm")]
    vpmovuswb_xmm_k1z_xmm = 3418,
    /// <summary>
    /// vpmovuswb xmm/m64 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpmovuswb m64_k1z, xmm","vpmovuswb xmm/m64 {k1}{z}, xmm")]
    vpmovuswb_m64_k1z_xmm = 3419,
    /// <summary>
    /// vpmovuswb ymm/m256 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpmovuswb ymm_k1z, zmm","vpmovuswb ymm/m256 {k1}{z}, zmm")]
    vpmovuswb_ymm_k1z_zmm = 3420,
    /// <summary>
    /// vpmovuswb ymm/m256 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpmovuswb m256_k1z, zmm","vpmovuswb ymm/m256 {k1}{z}, zmm")]
    vpmovuswb_m256_k1z_zmm = 3421,
    /// <summary>
    /// vpmovw2m k, xmm
    /// </summary>
    [Symbol("vpmovw2m k, xmm","vpmovw2m k, xmm")]
    vpmovw2m_k_xmm = 3422,
    /// <summary>
    /// vpmovw2m k, ymm
    /// </summary>
    [Symbol("vpmovw2m k, ymm","vpmovw2m k, ymm")]
    vpmovw2m_k_ymm = 3423,
    /// <summary>
    /// vpmovw2m k, zmm
    /// </summary>
    [Symbol("vpmovw2m k, zmm","vpmovw2m k, zmm")]
    vpmovw2m_k_zmm = 3424,
    /// <summary>
    /// vpmovwb xmm/m128 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpmovwb xmm_k1z, ymm","vpmovwb xmm/m128 {k1}{z}, ymm")]
    vpmovwb_xmm_k1z_ymm = 3425,
    /// <summary>
    /// vpmovwb xmm/m128 {k1}{z}, ymm
    /// </summary>
    [Symbol("vpmovwb m128_k1z, ymm","vpmovwb xmm/m128 {k1}{z}, ymm")]
    vpmovwb_m128_k1z_ymm = 3426,
    /// <summary>
    /// vpmovwb xmm/m64 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpmovwb xmm_k1z, xmm","vpmovwb xmm/m64 {k1}{z}, xmm")]
    vpmovwb_xmm_k1z_xmm = 3427,
    /// <summary>
    /// vpmovwb xmm/m64 {k1}{z}, xmm
    /// </summary>
    [Symbol("vpmovwb m64_k1z, xmm","vpmovwb xmm/m64 {k1}{z}, xmm")]
    vpmovwb_m64_k1z_xmm = 3428,
    /// <summary>
    /// vpmovwb ymm/m256 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpmovwb ymm_k1z, zmm","vpmovwb ymm/m256 {k1}{z}, zmm")]
    vpmovwb_ymm_k1z_zmm = 3429,
    /// <summary>
    /// vpmovwb ymm/m256 {k1}{z}, zmm
    /// </summary>
    [Symbol("vpmovwb m256_k1z, zmm","vpmovwb ymm/m256 {k1}{z}, zmm")]
    vpmovwb_m256_k1z_zmm = 3430,
    /// <summary>
    /// vpmovzxbd xmm {k1}{z}, xmm/m32
    /// </summary>
    [Symbol("vpmovzxbd xmm, xmm","vpmovzxbd xmm {k1}{z}, xmm/m32")]
    vpmovzxbd_xmm_xmm = 3431,
    /// <summary>
    /// vpmovzxbd xmm {k1}{z}, xmm/m32
    /// </summary>
    [Symbol("vpmovzxbd xmm, m32","vpmovzxbd xmm {k1}{z}, xmm/m32")]
    vpmovzxbd_xmm_m32 = 3432,
    /// <summary>
    /// vpmovzxbd xmm {k1}{z}, xmm/m32
    /// </summary>
    [Symbol("vpmovzxbd xmm_k1z, xmm","vpmovzxbd xmm {k1}{z}, xmm/m32")]
    vpmovzxbd_xmm_k1z_xmm = 3433,
    /// <summary>
    /// vpmovzxbd xmm {k1}{z}, xmm/m32
    /// </summary>
    [Symbol("vpmovzxbd xmm_k1z, m32","vpmovzxbd xmm {k1}{z}, xmm/m32")]
    vpmovzxbd_xmm_k1z_m32 = 3434,
    /// <summary>
    /// vpmovzxbd ymm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpmovzxbd ymm, xmm","vpmovzxbd ymm {k1}{z}, xmm/m64")]
    vpmovzxbd_ymm_xmm = 3435,
    /// <summary>
    /// vpmovzxbd ymm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpmovzxbd ymm, m64","vpmovzxbd ymm {k1}{z}, xmm/m64")]
    vpmovzxbd_ymm_m64 = 3436,
    /// <summary>
    /// vpmovzxbd ymm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpmovzxbd ymm_k1z, xmm","vpmovzxbd ymm {k1}{z}, xmm/m64")]
    vpmovzxbd_ymm_k1z_xmm = 3437,
    /// <summary>
    /// vpmovzxbd ymm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpmovzxbd ymm_k1z, m64","vpmovzxbd ymm {k1}{z}, xmm/m64")]
    vpmovzxbd_ymm_k1z_m64 = 3438,
    /// <summary>
    /// vpmovzxbd zmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vpmovzxbd zmm, xmm","vpmovzxbd zmm {k1}{z}, xmm/m128")]
    vpmovzxbd_zmm_xmm = 3439,
    /// <summary>
    /// vpmovzxbd zmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vpmovzxbd zmm, m128","vpmovzxbd zmm {k1}{z}, xmm/m128")]
    vpmovzxbd_zmm_m128 = 3440,
    /// <summary>
    /// vpmovzxbd zmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vpmovzxbd zmm_k1z, xmm","vpmovzxbd zmm {k1}{z}, xmm/m128")]
    vpmovzxbd_zmm_k1z_xmm = 3441,
    /// <summary>
    /// vpmovzxbd zmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vpmovzxbd zmm_k1z, m128","vpmovzxbd zmm {k1}{z}, xmm/m128")]
    vpmovzxbd_zmm_k1z_m128 = 3442,
    /// <summary>
    /// vpmovzxbq xmm {k1}{z}, xmm/m16
    /// </summary>
    [Symbol("vpmovzxbq xmm, xmm","vpmovzxbq xmm {k1}{z}, xmm/m16")]
    vpmovzxbq_xmm_xmm = 3443,
    /// <summary>
    /// vpmovzxbq xmm {k1}{z}, xmm/m16
    /// </summary>
    [Symbol("vpmovzxbq xmm, m16","vpmovzxbq xmm {k1}{z}, xmm/m16")]
    vpmovzxbq_xmm_m16 = 3444,
    /// <summary>
    /// vpmovzxbq xmm {k1}{z}, xmm/m16
    /// </summary>
    [Symbol("vpmovzxbq xmm_k1z, xmm","vpmovzxbq xmm {k1}{z}, xmm/m16")]
    vpmovzxbq_xmm_k1z_xmm = 3445,
    /// <summary>
    /// vpmovzxbq xmm {k1}{z}, xmm/m16
    /// </summary>
    [Symbol("vpmovzxbq xmm_k1z, m16","vpmovzxbq xmm {k1}{z}, xmm/m16")]
    vpmovzxbq_xmm_k1z_m16 = 3446,
    /// <summary>
    /// vpmovzxbq ymm {k1}{z}, xmm/m32
    /// </summary>
    [Symbol("vpmovzxbq ymm, xmm","vpmovzxbq ymm {k1}{z}, xmm/m32")]
    vpmovzxbq_ymm_xmm = 3447,
    /// <summary>
    /// vpmovzxbq ymm {k1}{z}, xmm/m32
    /// </summary>
    [Symbol("vpmovzxbq ymm, m32","vpmovzxbq ymm {k1}{z}, xmm/m32")]
    vpmovzxbq_ymm_m32 = 3448,
    /// <summary>
    /// vpmovzxbq ymm {k1}{z}, xmm/m32
    /// </summary>
    [Symbol("vpmovzxbq ymm_k1z, xmm","vpmovzxbq ymm {k1}{z}, xmm/m32")]
    vpmovzxbq_ymm_k1z_xmm = 3449,
    /// <summary>
    /// vpmovzxbq ymm {k1}{z}, xmm/m32
    /// </summary>
    [Symbol("vpmovzxbq ymm_k1z, m32","vpmovzxbq ymm {k1}{z}, xmm/m32")]
    vpmovzxbq_ymm_k1z_m32 = 3450,
    /// <summary>
    /// vpmovzxbq zmm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpmovzxbq zmm, xmm","vpmovzxbq zmm {k1}{z}, xmm/m64")]
    vpmovzxbq_zmm_xmm = 3451,
    /// <summary>
    /// vpmovzxbq zmm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpmovzxbq zmm, m64","vpmovzxbq zmm {k1}{z}, xmm/m64")]
    vpmovzxbq_zmm_m64 = 3452,
    /// <summary>
    /// vpmovzxbq zmm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpmovzxbq zmm_k1z, xmm","vpmovzxbq zmm {k1}{z}, xmm/m64")]
    vpmovzxbq_zmm_k1z_xmm = 3453,
    /// <summary>
    /// vpmovzxbq zmm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpmovzxbq zmm_k1z, m64","vpmovzxbq zmm {k1}{z}, xmm/m64")]
    vpmovzxbq_zmm_k1z_m64 = 3454,
    /// <summary>
    /// vpmovzxbw xmm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpmovzxbw xmm, xmm","vpmovzxbw xmm {k1}{z}, xmm/m64")]
    vpmovzxbw_xmm_xmm = 3455,
    /// <summary>
    /// vpmovzxbw xmm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpmovzxbw xmm, m64","vpmovzxbw xmm {k1}{z}, xmm/m64")]
    vpmovzxbw_xmm_m64 = 3456,
    /// <summary>
    /// vpmovzxbw xmm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpmovzxbw xmm_k1z, xmm","vpmovzxbw xmm {k1}{z}, xmm/m64")]
    vpmovzxbw_xmm_k1z_xmm = 3457,
    /// <summary>
    /// vpmovzxbw xmm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpmovzxbw xmm_k1z, m64","vpmovzxbw xmm {k1}{z}, xmm/m64")]
    vpmovzxbw_xmm_k1z_m64 = 3458,
    /// <summary>
    /// vpmovzxbw ymm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vpmovzxbw ymm, xmm","vpmovzxbw ymm {k1}{z}, xmm/m128")]
    vpmovzxbw_ymm_xmm = 3459,
    /// <summary>
    /// vpmovzxbw ymm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vpmovzxbw ymm, m128","vpmovzxbw ymm {k1}{z}, xmm/m128")]
    vpmovzxbw_ymm_m128 = 3460,
    /// <summary>
    /// vpmovzxbw ymm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vpmovzxbw ymm_k1z, xmm","vpmovzxbw ymm {k1}{z}, xmm/m128")]
    vpmovzxbw_ymm_k1z_xmm = 3461,
    /// <summary>
    /// vpmovzxbw ymm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vpmovzxbw ymm_k1z, m128","vpmovzxbw ymm {k1}{z}, xmm/m128")]
    vpmovzxbw_ymm_k1z_m128 = 3462,
    /// <summary>
    /// vpmovzxbw zmm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vpmovzxbw zmm, ymm","vpmovzxbw zmm {k1}{z}, ymm/m256")]
    vpmovzxbw_zmm_ymm = 3463,
    /// <summary>
    /// vpmovzxbw zmm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vpmovzxbw zmm, m256","vpmovzxbw zmm {k1}{z}, ymm/m256")]
    vpmovzxbw_zmm_m256 = 3464,
    /// <summary>
    /// vpmovzxbw zmm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vpmovzxbw zmm_k1z, ymm","vpmovzxbw zmm {k1}{z}, ymm/m256")]
    vpmovzxbw_zmm_k1z_ymm = 3465,
    /// <summary>
    /// vpmovzxbw zmm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vpmovzxbw zmm_k1z, m256","vpmovzxbw zmm {k1}{z}, ymm/m256")]
    vpmovzxbw_zmm_k1z_m256 = 3466,
    /// <summary>
    /// vpmovzxdq xmm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpmovzxdq xmm, xmm","vpmovzxdq xmm {k1}{z}, xmm/m64")]
    vpmovzxdq_xmm_xmm = 3467,
    /// <summary>
    /// vpmovzxdq xmm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpmovzxdq xmm, m64","vpmovzxdq xmm {k1}{z}, xmm/m64")]
    vpmovzxdq_xmm_m64 = 3468,
    /// <summary>
    /// vpmovzxdq xmm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpmovzxdq xmm_k1z, xmm","vpmovzxdq xmm {k1}{z}, xmm/m64")]
    vpmovzxdq_xmm_k1z_xmm = 3469,
    /// <summary>
    /// vpmovzxdq xmm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpmovzxdq xmm_k1z, m64","vpmovzxdq xmm {k1}{z}, xmm/m64")]
    vpmovzxdq_xmm_k1z_m64 = 3470,
    /// <summary>
    /// vpmovzxdq ymm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vpmovzxdq ymm, xmm","vpmovzxdq ymm {k1}{z}, xmm/m128")]
    vpmovzxdq_ymm_xmm = 3471,
    /// <summary>
    /// vpmovzxdq ymm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vpmovzxdq ymm, m128","vpmovzxdq ymm {k1}{z}, xmm/m128")]
    vpmovzxdq_ymm_m128 = 3472,
    /// <summary>
    /// vpmovzxdq ymm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vpmovzxdq ymm_k1z, xmm","vpmovzxdq ymm {k1}{z}, xmm/m128")]
    vpmovzxdq_ymm_k1z_xmm = 3473,
    /// <summary>
    /// vpmovzxdq ymm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vpmovzxdq ymm_k1z, m128","vpmovzxdq ymm {k1}{z}, xmm/m128")]
    vpmovzxdq_ymm_k1z_m128 = 3474,
    /// <summary>
    /// vpmovzxdq zmm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vpmovzxdq zmm, ymm","vpmovzxdq zmm {k1}{z}, ymm/m256")]
    vpmovzxdq_zmm_ymm = 3475,
    /// <summary>
    /// vpmovzxdq zmm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vpmovzxdq zmm, m256","vpmovzxdq zmm {k1}{z}, ymm/m256")]
    vpmovzxdq_zmm_m256 = 3476,
    /// <summary>
    /// vpmovzxdq zmm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vpmovzxdq zmm_k1z, ymm","vpmovzxdq zmm {k1}{z}, ymm/m256")]
    vpmovzxdq_zmm_k1z_ymm = 3477,
    /// <summary>
    /// vpmovzxdq zmm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vpmovzxdq zmm_k1z, m256","vpmovzxdq zmm {k1}{z}, ymm/m256")]
    vpmovzxdq_zmm_k1z_m256 = 3478,
    /// <summary>
    /// vpmovzxwd xmm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpmovzxwd xmm, xmm","vpmovzxwd xmm {k1}{z}, xmm/m64")]
    vpmovzxwd_xmm_xmm = 3479,
    /// <summary>
    /// vpmovzxwd xmm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpmovzxwd xmm, m64","vpmovzxwd xmm {k1}{z}, xmm/m64")]
    vpmovzxwd_xmm_m64 = 3480,
    /// <summary>
    /// vpmovzxwd xmm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpmovzxwd xmm_k1z, xmm","vpmovzxwd xmm {k1}{z}, xmm/m64")]
    vpmovzxwd_xmm_k1z_xmm = 3481,
    /// <summary>
    /// vpmovzxwd xmm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpmovzxwd xmm_k1z, m64","vpmovzxwd xmm {k1}{z}, xmm/m64")]
    vpmovzxwd_xmm_k1z_m64 = 3482,
    /// <summary>
    /// vpmovzxwd ymm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vpmovzxwd ymm, xmm","vpmovzxwd ymm {k1}{z}, xmm/m128")]
    vpmovzxwd_ymm_xmm = 3483,
    /// <summary>
    /// vpmovzxwd ymm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vpmovzxwd ymm, m128","vpmovzxwd ymm {k1}{z}, xmm/m128")]
    vpmovzxwd_ymm_m128 = 3484,
    /// <summary>
    /// vpmovzxwd ymm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vpmovzxwd ymm_k1z, xmm","vpmovzxwd ymm {k1}{z}, xmm/m128")]
    vpmovzxwd_ymm_k1z_xmm = 3485,
    /// <summary>
    /// vpmovzxwd ymm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vpmovzxwd ymm_k1z, m128","vpmovzxwd ymm {k1}{z}, xmm/m128")]
    vpmovzxwd_ymm_k1z_m128 = 3486,
    /// <summary>
    /// vpmovzxwd zmm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vpmovzxwd zmm, ymm","vpmovzxwd zmm {k1}{z}, ymm/m256")]
    vpmovzxwd_zmm_ymm = 3487,
    /// <summary>
    /// vpmovzxwd zmm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vpmovzxwd zmm, m256","vpmovzxwd zmm {k1}{z}, ymm/m256")]
    vpmovzxwd_zmm_m256 = 3488,
    /// <summary>
    /// vpmovzxwd zmm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vpmovzxwd zmm_k1z, ymm","vpmovzxwd zmm {k1}{z}, ymm/m256")]
    vpmovzxwd_zmm_k1z_ymm = 3489,
    /// <summary>
    /// vpmovzxwd zmm {k1}{z}, ymm/m256
    /// </summary>
    [Symbol("vpmovzxwd zmm_k1z, m256","vpmovzxwd zmm {k1}{z}, ymm/m256")]
    vpmovzxwd_zmm_k1z_m256 = 3490,
    /// <summary>
    /// vpmovzxwq xmm {k1}{z}, xmm/m32
    /// </summary>
    [Symbol("vpmovzxwq xmm, xmm","vpmovzxwq xmm {k1}{z}, xmm/m32")]
    vpmovzxwq_xmm_xmm = 3491,
    /// <summary>
    /// vpmovzxwq xmm {k1}{z}, xmm/m32
    /// </summary>
    [Symbol("vpmovzxwq xmm, m32","vpmovzxwq xmm {k1}{z}, xmm/m32")]
    vpmovzxwq_xmm_m32 = 3492,
    /// <summary>
    /// vpmovzxwq xmm {k1}{z}, xmm/m32
    /// </summary>
    [Symbol("vpmovzxwq xmm_k1z, xmm","vpmovzxwq xmm {k1}{z}, xmm/m32")]
    vpmovzxwq_xmm_k1z_xmm = 3493,
    /// <summary>
    /// vpmovzxwq xmm {k1}{z}, xmm/m32
    /// </summary>
    [Symbol("vpmovzxwq xmm_k1z, m32","vpmovzxwq xmm {k1}{z}, xmm/m32")]
    vpmovzxwq_xmm_k1z_m32 = 3494,
    /// <summary>
    /// vpmovzxwq ymm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpmovzxwq ymm, xmm","vpmovzxwq ymm {k1}{z}, xmm/m64")]
    vpmovzxwq_ymm_xmm = 3495,
    /// <summary>
    /// vpmovzxwq ymm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpmovzxwq ymm, m64","vpmovzxwq ymm {k1}{z}, xmm/m64")]
    vpmovzxwq_ymm_m64 = 3496,
    /// <summary>
    /// vpmovzxwq ymm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpmovzxwq ymm_k1z, xmm","vpmovzxwq ymm {k1}{z}, xmm/m64")]
    vpmovzxwq_ymm_k1z_xmm = 3497,
    /// <summary>
    /// vpmovzxwq ymm {k1}{z}, xmm/m64
    /// </summary>
    [Symbol("vpmovzxwq ymm_k1z, m64","vpmovzxwq ymm {k1}{z}, xmm/m64")]
    vpmovzxwq_ymm_k1z_m64 = 3498,
    /// <summary>
    /// vpmovzxwq zmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vpmovzxwq zmm, xmm","vpmovzxwq zmm {k1}{z}, xmm/m128")]
    vpmovzxwq_zmm_xmm = 3499,
    /// <summary>
    /// vpmovzxwq zmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vpmovzxwq zmm, m128","vpmovzxwq zmm {k1}{z}, xmm/m128")]
    vpmovzxwq_zmm_m128 = 3500,
    /// <summary>
    /// vpmovzxwq zmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vpmovzxwq zmm_k1z, xmm","vpmovzxwq zmm {k1}{z}, xmm/m128")]
    vpmovzxwq_zmm_k1z_xmm = 3501,
    /// <summary>
    /// vpmovzxwq zmm {k1}{z}, xmm/m128
    /// </summary>
    [Symbol("vpmovzxwq zmm_k1z, m128","vpmovzxwq zmm {k1}{z}, xmm/m128")]
    vpmovzxwq_zmm_k1z_m128 = 3502,
    /// <summary>
    /// vpmulhuw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpmulhuw xmm, xmm, xmm","vpmulhuw xmm {k1}{z}, xmm, xmm/m128")]
    vpmulhuw_xmm_xmm_xmm = 3503,
    /// <summary>
    /// vpmulhuw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpmulhuw xmm, xmm, m128","vpmulhuw xmm {k1}{z}, xmm, xmm/m128")]
    vpmulhuw_xmm_xmm_m128 = 3504,
    /// <summary>
    /// vpmulhuw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpmulhuw xmm_k1z, xmm, xmm","vpmulhuw xmm {k1}{z}, xmm, xmm/m128")]
    vpmulhuw_xmm_k1z_xmm_xmm = 3505,
    /// <summary>
    /// vpmulhuw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpmulhuw xmm_k1z, xmm, m128","vpmulhuw xmm {k1}{z}, xmm, xmm/m128")]
    vpmulhuw_xmm_k1z_xmm_m128 = 3506,
    /// <summary>
    /// vpmulhuw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpmulhuw ymm, ymm, ymm","vpmulhuw ymm {k1}{z}, ymm, ymm/m256")]
    vpmulhuw_ymm_ymm_ymm = 3507,
    /// <summary>
    /// vpmulhuw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpmulhuw ymm, ymm, m256","vpmulhuw ymm {k1}{z}, ymm, ymm/m256")]
    vpmulhuw_ymm_ymm_m256 = 3508,
    /// <summary>
    /// vpmulhuw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpmulhuw ymm_k1z, ymm, ymm","vpmulhuw ymm {k1}{z}, ymm, ymm/m256")]
    vpmulhuw_ymm_k1z_ymm_ymm = 3509,
    /// <summary>
    /// vpmulhuw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpmulhuw ymm_k1z, ymm, m256","vpmulhuw ymm {k1}{z}, ymm, ymm/m256")]
    vpmulhuw_ymm_k1z_ymm_m256 = 3510,
    /// <summary>
    /// vpmulhuw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpmulhuw zmm, zmm, zmm","vpmulhuw zmm {k1}{z}, zmm, zmm/m512")]
    vpmulhuw_zmm_zmm_zmm = 3511,
    /// <summary>
    /// vpmulhuw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpmulhuw zmm, zmm, m512","vpmulhuw zmm {k1}{z}, zmm, zmm/m512")]
    vpmulhuw_zmm_zmm_m512 = 3512,
    /// <summary>
    /// vpmulhuw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpmulhuw zmm_k1z, zmm, zmm","vpmulhuw zmm {k1}{z}, zmm, zmm/m512")]
    vpmulhuw_zmm_k1z_zmm_zmm = 3513,
    /// <summary>
    /// vpmulhuw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpmulhuw zmm_k1z, zmm, m512","vpmulhuw zmm {k1}{z}, zmm, zmm/m512")]
    vpmulhuw_zmm_k1z_zmm_m512 = 3514,
    /// <summary>
    /// vpmullw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpmullw xmm, xmm, xmm","vpmullw xmm {k1}{z}, xmm, xmm/m128")]
    vpmullw_xmm_xmm_xmm = 3515,
    /// <summary>
    /// vpmullw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpmullw xmm, xmm, m128","vpmullw xmm {k1}{z}, xmm, xmm/m128")]
    vpmullw_xmm_xmm_m128 = 3516,
    /// <summary>
    /// vpmullw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpmullw xmm_k1z, xmm, xmm","vpmullw xmm {k1}{z}, xmm, xmm/m128")]
    vpmullw_xmm_k1z_xmm_xmm = 3517,
    /// <summary>
    /// vpmullw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpmullw xmm_k1z, xmm, m128","vpmullw xmm {k1}{z}, xmm, xmm/m128")]
    vpmullw_xmm_k1z_xmm_m128 = 3518,
    /// <summary>
    /// vpmullw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpmullw ymm, ymm, ymm","vpmullw ymm {k1}{z}, ymm, ymm/m256")]
    vpmullw_ymm_ymm_ymm = 3519,
    /// <summary>
    /// vpmullw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpmullw ymm, ymm, m256","vpmullw ymm {k1}{z}, ymm, ymm/m256")]
    vpmullw_ymm_ymm_m256 = 3520,
    /// <summary>
    /// vpmullw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpmullw ymm_k1z, ymm, ymm","vpmullw ymm {k1}{z}, ymm, ymm/m256")]
    vpmullw_ymm_k1z_ymm_ymm = 3521,
    /// <summary>
    /// vpmullw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpmullw ymm_k1z, ymm, m256","vpmullw ymm {k1}{z}, ymm, ymm/m256")]
    vpmullw_ymm_k1z_ymm_m256 = 3522,
    /// <summary>
    /// vpmullw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpmullw zmm, zmm, zmm","vpmullw zmm {k1}{z}, zmm, zmm/m512")]
    vpmullw_zmm_zmm_zmm = 3523,
    /// <summary>
    /// vpmullw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpmullw zmm, zmm, m512","vpmullw zmm {k1}{z}, zmm, zmm/m512")]
    vpmullw_zmm_zmm_m512 = 3524,
    /// <summary>
    /// vpmullw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpmullw zmm_k1z, zmm, zmm","vpmullw zmm {k1}{z}, zmm, zmm/m512")]
    vpmullw_zmm_k1z_zmm_zmm = 3525,
    /// <summary>
    /// vpmullw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpmullw zmm_k1z, zmm, m512","vpmullw zmm {k1}{z}, zmm, zmm/m512")]
    vpmullw_zmm_k1z_zmm_m512 = 3526,
    /// <summary>
    /// vpor xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpor xmm, xmm, xmm","vpor xmm, xmm, xmm/m128")]
    vpor_xmm_xmm_xmm = 3527,
    /// <summary>
    /// vpor xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpor xmm, xmm, m128","vpor xmm, xmm, xmm/m128")]
    vpor_xmm_xmm_m128 = 3528,
    /// <summary>
    /// vpor ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpor ymm, ymm, ymm","vpor ymm, ymm, ymm/m256")]
    vpor_ymm_ymm_ymm = 3529,
    /// <summary>
    /// vpor ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpor ymm, ymm, m256","vpor ymm, ymm, ymm/m256")]
    vpor_ymm_ymm_m256 = 3530,
    /// <summary>
    /// vpord xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpord xmm, xmm, xmm","vpord xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpord_xmm_xmm_xmm = 3531,
    /// <summary>
    /// vpord xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpord xmm, xmm, m128","vpord xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpord_xmm_xmm_m128 = 3532,
    /// <summary>
    /// vpord xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpord xmm, xmm, m32bcst","vpord xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpord_xmm_xmm_m32bcst = 3533,
    /// <summary>
    /// vpord xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpord xmm_k1z, xmm, xmm","vpord xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpord_xmm_k1z_xmm_xmm = 3534,
    /// <summary>
    /// vpord xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpord xmm_k1z, xmm, m128","vpord xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpord_xmm_k1z_xmm_m128 = 3535,
    /// <summary>
    /// vpord xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpord xmm_k1z, xmm, m32bcst","vpord xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpord_xmm_k1z_xmm_m32bcst = 3536,
    /// <summary>
    /// vpord ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpord ymm, ymm, ymm","vpord ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpord_ymm_ymm_ymm = 3537,
    /// <summary>
    /// vpord ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpord ymm, ymm, m256","vpord ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpord_ymm_ymm_m256 = 3538,
    /// <summary>
    /// vpord ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpord ymm, ymm, m32bcst","vpord ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpord_ymm_ymm_m32bcst = 3539,
    /// <summary>
    /// vpord ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpord ymm_k1z, ymm, ymm","vpord ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpord_ymm_k1z_ymm_ymm = 3540,
    /// <summary>
    /// vpord ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpord ymm_k1z, ymm, m256","vpord ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpord_ymm_k1z_ymm_m256 = 3541,
    /// <summary>
    /// vpord ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpord ymm_k1z, ymm, m32bcst","vpord ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpord_ymm_k1z_ymm_m32bcst = 3542,
    /// <summary>
    /// vpord zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpord zmm, zmm, zmm","vpord zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpord_zmm_zmm_zmm = 3543,
    /// <summary>
    /// vpord zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpord zmm, zmm, m512","vpord zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpord_zmm_zmm_m512 = 3544,
    /// <summary>
    /// vpord zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpord zmm, zmm, m32bcst","vpord zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpord_zmm_zmm_m32bcst = 3545,
    /// <summary>
    /// vpord zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpord zmm_k1z, zmm, zmm","vpord zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpord_zmm_k1z_zmm_zmm = 3546,
    /// <summary>
    /// vpord zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpord zmm_k1z, zmm, m512","vpord zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpord_zmm_k1z_zmm_m512 = 3547,
    /// <summary>
    /// vpord zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpord zmm_k1z, zmm, m32bcst","vpord zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpord_zmm_k1z_zmm_m32bcst = 3548,
    /// <summary>
    /// vporq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vporq xmm, xmm, xmm","vporq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vporq_xmm_xmm_xmm = 3549,
    /// <summary>
    /// vporq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vporq xmm, xmm, m128","vporq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vporq_xmm_xmm_m128 = 3550,
    /// <summary>
    /// vporq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vporq xmm, xmm, m64bcst","vporq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vporq_xmm_xmm_m64bcst = 3551,
    /// <summary>
    /// vporq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vporq xmm_k1z, xmm, xmm","vporq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vporq_xmm_k1z_xmm_xmm = 3552,
    /// <summary>
    /// vporq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vporq xmm_k1z, xmm, m128","vporq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vporq_xmm_k1z_xmm_m128 = 3553,
    /// <summary>
    /// vporq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vporq xmm_k1z, xmm, m64bcst","vporq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vporq_xmm_k1z_xmm_m64bcst = 3554,
    /// <summary>
    /// vporq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vporq ymm, ymm, ymm","vporq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vporq_ymm_ymm_ymm = 3555,
    /// <summary>
    /// vporq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vporq ymm, ymm, m256","vporq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vporq_ymm_ymm_m256 = 3556,
    /// <summary>
    /// vporq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vporq ymm, ymm, m64bcst","vporq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vporq_ymm_ymm_m64bcst = 3557,
    /// <summary>
    /// vporq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vporq ymm_k1z, ymm, ymm","vporq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vporq_ymm_k1z_ymm_ymm = 3558,
    /// <summary>
    /// vporq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vporq ymm_k1z, ymm, m256","vporq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vporq_ymm_k1z_ymm_m256 = 3559,
    /// <summary>
    /// vporq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vporq ymm_k1z, ymm, m64bcst","vporq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vporq_ymm_k1z_ymm_m64bcst = 3560,
    /// <summary>
    /// vporq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vporq zmm, zmm, zmm","vporq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vporq_zmm_zmm_zmm = 3561,
    /// <summary>
    /// vporq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vporq zmm, zmm, m512","vporq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vporq_zmm_zmm_m512 = 3562,
    /// <summary>
    /// vporq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vporq zmm, zmm, m64bcst","vporq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vporq_zmm_zmm_m64bcst = 3563,
    /// <summary>
    /// vporq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vporq zmm_k1z, zmm, zmm","vporq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vporq_zmm_k1z_zmm_zmm = 3564,
    /// <summary>
    /// vporq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vporq zmm_k1z, zmm, m512","vporq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vporq_zmm_k1z_zmm_m512 = 3565,
    /// <summary>
    /// vporq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vporq zmm_k1z, zmm, m64bcst","vporq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vporq_zmm_k1z_zmm_m64bcst = 3566,
    /// <summary>
    /// vprold xmm {k1}{z}, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vprold xmm, xmm, imm8","vprold xmm {k1}{z}, xmm/m128/m32bcst, imm8")]
    vprold_xmm_xmm_imm8 = 3567,
    /// <summary>
    /// vprold xmm {k1}{z}, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vprold xmm, m128, imm8","vprold xmm {k1}{z}, xmm/m128/m32bcst, imm8")]
    vprold_xmm_m128_imm8 = 3568,
    /// <summary>
    /// vprold xmm {k1}{z}, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vprold xmm, m32bcst, imm8","vprold xmm {k1}{z}, xmm/m128/m32bcst, imm8")]
    vprold_xmm_m32bcst_imm8 = 3569,
    /// <summary>
    /// vprold xmm {k1}{z}, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vprold xmm_k1z, xmm, imm8","vprold xmm {k1}{z}, xmm/m128/m32bcst, imm8")]
    vprold_xmm_k1z_xmm_imm8 = 3570,
    /// <summary>
    /// vprold xmm {k1}{z}, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vprold xmm_k1z, m128, imm8","vprold xmm {k1}{z}, xmm/m128/m32bcst, imm8")]
    vprold_xmm_k1z_m128_imm8 = 3571,
    /// <summary>
    /// vprold xmm {k1}{z}, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vprold xmm_k1z, m32bcst, imm8","vprold xmm {k1}{z}, xmm/m128/m32bcst, imm8")]
    vprold_xmm_k1z_m32bcst_imm8 = 3572,
    /// <summary>
    /// vprold ymm {k1}{z}, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vprold ymm, ymm, imm8","vprold ymm {k1}{z}, ymm/m256/m32bcst, imm8")]
    vprold_ymm_ymm_imm8 = 3573,
    /// <summary>
    /// vprold ymm {k1}{z}, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vprold ymm, m256, imm8","vprold ymm {k1}{z}, ymm/m256/m32bcst, imm8")]
    vprold_ymm_m256_imm8 = 3574,
    /// <summary>
    /// vprold ymm {k1}{z}, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vprold ymm, m32bcst, imm8","vprold ymm {k1}{z}, ymm/m256/m32bcst, imm8")]
    vprold_ymm_m32bcst_imm8 = 3575,
    /// <summary>
    /// vprold ymm {k1}{z}, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vprold ymm_k1z, ymm, imm8","vprold ymm {k1}{z}, ymm/m256/m32bcst, imm8")]
    vprold_ymm_k1z_ymm_imm8 = 3576,
    /// <summary>
    /// vprold ymm {k1}{z}, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vprold ymm_k1z, m256, imm8","vprold ymm {k1}{z}, ymm/m256/m32bcst, imm8")]
    vprold_ymm_k1z_m256_imm8 = 3577,
    /// <summary>
    /// vprold ymm {k1}{z}, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vprold ymm_k1z, m32bcst, imm8","vprold ymm {k1}{z}, ymm/m256/m32bcst, imm8")]
    vprold_ymm_k1z_m32bcst_imm8 = 3578,
    /// <summary>
    /// vprold zmm {k1}{z}, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vprold zmm, zmm, imm8","vprold zmm {k1}{z}, zmm/m512/m32bcst, imm8")]
    vprold_zmm_zmm_imm8 = 3579,
    /// <summary>
    /// vprold zmm {k1}{z}, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vprold zmm, m512, imm8","vprold zmm {k1}{z}, zmm/m512/m32bcst, imm8")]
    vprold_zmm_m512_imm8 = 3580,
    /// <summary>
    /// vprold zmm {k1}{z}, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vprold zmm, m32bcst, imm8","vprold zmm {k1}{z}, zmm/m512/m32bcst, imm8")]
    vprold_zmm_m32bcst_imm8 = 3581,
    /// <summary>
    /// vprold zmm {k1}{z}, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vprold zmm_k1z, zmm, imm8","vprold zmm {k1}{z}, zmm/m512/m32bcst, imm8")]
    vprold_zmm_k1z_zmm_imm8 = 3582,
    /// <summary>
    /// vprold zmm {k1}{z}, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vprold zmm_k1z, m512, imm8","vprold zmm {k1}{z}, zmm/m512/m32bcst, imm8")]
    vprold_zmm_k1z_m512_imm8 = 3583,
    /// <summary>
    /// vprold zmm {k1}{z}, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vprold zmm_k1z, m32bcst, imm8","vprold zmm {k1}{z}, zmm/m512/m32bcst, imm8")]
    vprold_zmm_k1z_m32bcst_imm8 = 3584,
    /// <summary>
    /// vprolq xmm {k1}{z}, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("vprolq xmm, xmm, imm8","vprolq xmm {k1}{z}, xmm/m128/m64bcst, imm8")]
    vprolq_xmm_xmm_imm8 = 3585,
    /// <summary>
    /// vprolq xmm {k1}{z}, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("vprolq xmm, m128, imm8","vprolq xmm {k1}{z}, xmm/m128/m64bcst, imm8")]
    vprolq_xmm_m128_imm8 = 3586,
    /// <summary>
    /// vprolq xmm {k1}{z}, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("vprolq xmm, m64bcst, imm8","vprolq xmm {k1}{z}, xmm/m128/m64bcst, imm8")]
    vprolq_xmm_m64bcst_imm8 = 3587,
    /// <summary>
    /// vprolq xmm {k1}{z}, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("vprolq xmm_k1z, xmm, imm8","vprolq xmm {k1}{z}, xmm/m128/m64bcst, imm8")]
    vprolq_xmm_k1z_xmm_imm8 = 3588,
    /// <summary>
    /// vprolq xmm {k1}{z}, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("vprolq xmm_k1z, m128, imm8","vprolq xmm {k1}{z}, xmm/m128/m64bcst, imm8")]
    vprolq_xmm_k1z_m128_imm8 = 3589,
    /// <summary>
    /// vprolq xmm {k1}{z}, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("vprolq xmm_k1z, m64bcst, imm8","vprolq xmm {k1}{z}, xmm/m128/m64bcst, imm8")]
    vprolq_xmm_k1z_m64bcst_imm8 = 3590,
    /// <summary>
    /// vprolq ymm {k1}{z}, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vprolq ymm, ymm, imm8","vprolq ymm {k1}{z}, ymm/m256/m64bcst, imm8")]
    vprolq_ymm_ymm_imm8 = 3591,
    /// <summary>
    /// vprolq ymm {k1}{z}, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vprolq ymm, m256, imm8","vprolq ymm {k1}{z}, ymm/m256/m64bcst, imm8")]
    vprolq_ymm_m256_imm8 = 3592,
    /// <summary>
    /// vprolq ymm {k1}{z}, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vprolq ymm, m64bcst, imm8","vprolq ymm {k1}{z}, ymm/m256/m64bcst, imm8")]
    vprolq_ymm_m64bcst_imm8 = 3593,
    /// <summary>
    /// vprolq ymm {k1}{z}, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vprolq ymm_k1z, ymm, imm8","vprolq ymm {k1}{z}, ymm/m256/m64bcst, imm8")]
    vprolq_ymm_k1z_ymm_imm8 = 3594,
    /// <summary>
    /// vprolq ymm {k1}{z}, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vprolq ymm_k1z, m256, imm8","vprolq ymm {k1}{z}, ymm/m256/m64bcst, imm8")]
    vprolq_ymm_k1z_m256_imm8 = 3595,
    /// <summary>
    /// vprolq ymm {k1}{z}, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vprolq ymm_k1z, m64bcst, imm8","vprolq ymm {k1}{z}, ymm/m256/m64bcst, imm8")]
    vprolq_ymm_k1z_m64bcst_imm8 = 3596,
    /// <summary>
    /// vprolq zmm {k1}{z}, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vprolq zmm, zmm, imm8","vprolq zmm {k1}{z}, zmm/m512/m64bcst, imm8")]
    vprolq_zmm_zmm_imm8 = 3597,
    /// <summary>
    /// vprolq zmm {k1}{z}, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vprolq zmm, m512, imm8","vprolq zmm {k1}{z}, zmm/m512/m64bcst, imm8")]
    vprolq_zmm_m512_imm8 = 3598,
    /// <summary>
    /// vprolq zmm {k1}{z}, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vprolq zmm, m64bcst, imm8","vprolq zmm {k1}{z}, zmm/m512/m64bcst, imm8")]
    vprolq_zmm_m64bcst_imm8 = 3599,
    /// <summary>
    /// vprolq zmm {k1}{z}, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vprolq zmm_k1z, zmm, imm8","vprolq zmm {k1}{z}, zmm/m512/m64bcst, imm8")]
    vprolq_zmm_k1z_zmm_imm8 = 3600,
    /// <summary>
    /// vprolq zmm {k1}{z}, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vprolq zmm_k1z, m512, imm8","vprolq zmm {k1}{z}, zmm/m512/m64bcst, imm8")]
    vprolq_zmm_k1z_m512_imm8 = 3601,
    /// <summary>
    /// vprolq zmm {k1}{z}, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vprolq zmm_k1z, m64bcst, imm8","vprolq zmm {k1}{z}, zmm/m512/m64bcst, imm8")]
    vprolq_zmm_k1z_m64bcst_imm8 = 3602,
    /// <summary>
    /// vprolvd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vprolvd xmm, xmm, xmm","vprolvd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vprolvd_xmm_xmm_xmm = 3603,
    /// <summary>
    /// vprolvd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vprolvd xmm, xmm, m128","vprolvd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vprolvd_xmm_xmm_m128 = 3604,
    /// <summary>
    /// vprolvd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vprolvd xmm, xmm, m32bcst","vprolvd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vprolvd_xmm_xmm_m32bcst = 3605,
    /// <summary>
    /// vprolvd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vprolvd xmm_k1z, xmm, xmm","vprolvd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vprolvd_xmm_k1z_xmm_xmm = 3606,
    /// <summary>
    /// vprolvd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vprolvd xmm_k1z, xmm, m128","vprolvd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vprolvd_xmm_k1z_xmm_m128 = 3607,
    /// <summary>
    /// vprolvd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vprolvd xmm_k1z, xmm, m32bcst","vprolvd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vprolvd_xmm_k1z_xmm_m32bcst = 3608,
    /// <summary>
    /// vprolvd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vprolvd ymm, ymm, ymm","vprolvd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vprolvd_ymm_ymm_ymm = 3609,
    /// <summary>
    /// vprolvd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vprolvd ymm, ymm, m256","vprolvd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vprolvd_ymm_ymm_m256 = 3610,
    /// <summary>
    /// vprolvd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vprolvd ymm, ymm, m32bcst","vprolvd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vprolvd_ymm_ymm_m32bcst = 3611,
    /// <summary>
    /// vprolvd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vprolvd ymm_k1z, ymm, ymm","vprolvd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vprolvd_ymm_k1z_ymm_ymm = 3612,
    /// <summary>
    /// vprolvd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vprolvd ymm_k1z, ymm, m256","vprolvd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vprolvd_ymm_k1z_ymm_m256 = 3613,
    /// <summary>
    /// vprolvd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vprolvd ymm_k1z, ymm, m32bcst","vprolvd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vprolvd_ymm_k1z_ymm_m32bcst = 3614,
    /// <summary>
    /// vprolvd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vprolvd zmm, zmm, zmm","vprolvd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vprolvd_zmm_zmm_zmm = 3615,
    /// <summary>
    /// vprolvd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vprolvd zmm, zmm, m512","vprolvd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vprolvd_zmm_zmm_m512 = 3616,
    /// <summary>
    /// vprolvd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vprolvd zmm, zmm, m32bcst","vprolvd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vprolvd_zmm_zmm_m32bcst = 3617,
    /// <summary>
    /// vprolvd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vprolvd zmm_k1z, zmm, zmm","vprolvd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vprolvd_zmm_k1z_zmm_zmm = 3618,
    /// <summary>
    /// vprolvd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vprolvd zmm_k1z, zmm, m512","vprolvd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vprolvd_zmm_k1z_zmm_m512 = 3619,
    /// <summary>
    /// vprolvd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vprolvd zmm_k1z, zmm, m32bcst","vprolvd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vprolvd_zmm_k1z_zmm_m32bcst = 3620,
    /// <summary>
    /// vprolvq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vprolvq xmm, xmm, xmm","vprolvq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vprolvq_xmm_xmm_xmm = 3621,
    /// <summary>
    /// vprolvq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vprolvq xmm, xmm, m128","vprolvq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vprolvq_xmm_xmm_m128 = 3622,
    /// <summary>
    /// vprolvq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vprolvq xmm, xmm, m64bcst","vprolvq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vprolvq_xmm_xmm_m64bcst = 3623,
    /// <summary>
    /// vprolvq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vprolvq xmm_k1z, xmm, xmm","vprolvq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vprolvq_xmm_k1z_xmm_xmm = 3624,
    /// <summary>
    /// vprolvq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vprolvq xmm_k1z, xmm, m128","vprolvq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vprolvq_xmm_k1z_xmm_m128 = 3625,
    /// <summary>
    /// vprolvq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vprolvq xmm_k1z, xmm, m64bcst","vprolvq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vprolvq_xmm_k1z_xmm_m64bcst = 3626,
    /// <summary>
    /// vprolvq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vprolvq ymm, ymm, ymm","vprolvq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vprolvq_ymm_ymm_ymm = 3627,
    /// <summary>
    /// vprolvq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vprolvq ymm, ymm, m256","vprolvq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vprolvq_ymm_ymm_m256 = 3628,
    /// <summary>
    /// vprolvq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vprolvq ymm, ymm, m64bcst","vprolvq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vprolvq_ymm_ymm_m64bcst = 3629,
    /// <summary>
    /// vprolvq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vprolvq ymm_k1z, ymm, ymm","vprolvq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vprolvq_ymm_k1z_ymm_ymm = 3630,
    /// <summary>
    /// vprolvq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vprolvq ymm_k1z, ymm, m256","vprolvq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vprolvq_ymm_k1z_ymm_m256 = 3631,
    /// <summary>
    /// vprolvq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vprolvq ymm_k1z, ymm, m64bcst","vprolvq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vprolvq_ymm_k1z_ymm_m64bcst = 3632,
    /// <summary>
    /// vprolvq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vprolvq zmm, zmm, zmm","vprolvq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vprolvq_zmm_zmm_zmm = 3633,
    /// <summary>
    /// vprolvq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vprolvq zmm, zmm, m512","vprolvq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vprolvq_zmm_zmm_m512 = 3634,
    /// <summary>
    /// vprolvq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vprolvq zmm, zmm, m64bcst","vprolvq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vprolvq_zmm_zmm_m64bcst = 3635,
    /// <summary>
    /// vprolvq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vprolvq zmm_k1z, zmm, zmm","vprolvq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vprolvq_zmm_k1z_zmm_zmm = 3636,
    /// <summary>
    /// vprolvq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vprolvq zmm_k1z, zmm, m512","vprolvq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vprolvq_zmm_k1z_zmm_m512 = 3637,
    /// <summary>
    /// vprolvq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vprolvq zmm_k1z, zmm, m64bcst","vprolvq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vprolvq_zmm_k1z_zmm_m64bcst = 3638,
    /// <summary>
    /// vprord xmm {k1}{z}, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vprord xmm, xmm, imm8","vprord xmm {k1}{z}, xmm/m128/m32bcst, imm8")]
    vprord_xmm_xmm_imm8 = 3639,
    /// <summary>
    /// vprord xmm {k1}{z}, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vprord xmm, m128, imm8","vprord xmm {k1}{z}, xmm/m128/m32bcst, imm8")]
    vprord_xmm_m128_imm8 = 3640,
    /// <summary>
    /// vprord xmm {k1}{z}, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vprord xmm, m32bcst, imm8","vprord xmm {k1}{z}, xmm/m128/m32bcst, imm8")]
    vprord_xmm_m32bcst_imm8 = 3641,
    /// <summary>
    /// vprord xmm {k1}{z}, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vprord xmm_k1z, xmm, imm8","vprord xmm {k1}{z}, xmm/m128/m32bcst, imm8")]
    vprord_xmm_k1z_xmm_imm8 = 3642,
    /// <summary>
    /// vprord xmm {k1}{z}, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vprord xmm_k1z, m128, imm8","vprord xmm {k1}{z}, xmm/m128/m32bcst, imm8")]
    vprord_xmm_k1z_m128_imm8 = 3643,
    /// <summary>
    /// vprord xmm {k1}{z}, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vprord xmm_k1z, m32bcst, imm8","vprord xmm {k1}{z}, xmm/m128/m32bcst, imm8")]
    vprord_xmm_k1z_m32bcst_imm8 = 3644,
    /// <summary>
    /// vprord ymm {k1}{z}, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vprord ymm, ymm, imm8","vprord ymm {k1}{z}, ymm/m256/m32bcst, imm8")]
    vprord_ymm_ymm_imm8 = 3645,
    /// <summary>
    /// vprord ymm {k1}{z}, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vprord ymm, m256, imm8","vprord ymm {k1}{z}, ymm/m256/m32bcst, imm8")]
    vprord_ymm_m256_imm8 = 3646,
    /// <summary>
    /// vprord ymm {k1}{z}, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vprord ymm, m32bcst, imm8","vprord ymm {k1}{z}, ymm/m256/m32bcst, imm8")]
    vprord_ymm_m32bcst_imm8 = 3647,
    /// <summary>
    /// vprord ymm {k1}{z}, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vprord ymm_k1z, ymm, imm8","vprord ymm {k1}{z}, ymm/m256/m32bcst, imm8")]
    vprord_ymm_k1z_ymm_imm8 = 3648,
    /// <summary>
    /// vprord ymm {k1}{z}, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vprord ymm_k1z, m256, imm8","vprord ymm {k1}{z}, ymm/m256/m32bcst, imm8")]
    vprord_ymm_k1z_m256_imm8 = 3649,
    /// <summary>
    /// vprord ymm {k1}{z}, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vprord ymm_k1z, m32bcst, imm8","vprord ymm {k1}{z}, ymm/m256/m32bcst, imm8")]
    vprord_ymm_k1z_m32bcst_imm8 = 3650,
    /// <summary>
    /// vprord zmm {k1}{z}, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vprord zmm, zmm, imm8","vprord zmm {k1}{z}, zmm/m512/m32bcst, imm8")]
    vprord_zmm_zmm_imm8 = 3651,
    /// <summary>
    /// vprord zmm {k1}{z}, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vprord zmm, m512, imm8","vprord zmm {k1}{z}, zmm/m512/m32bcst, imm8")]
    vprord_zmm_m512_imm8 = 3652,
    /// <summary>
    /// vprord zmm {k1}{z}, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vprord zmm, m32bcst, imm8","vprord zmm {k1}{z}, zmm/m512/m32bcst, imm8")]
    vprord_zmm_m32bcst_imm8 = 3653,
    /// <summary>
    /// vprord zmm {k1}{z}, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vprord zmm_k1z, zmm, imm8","vprord zmm {k1}{z}, zmm/m512/m32bcst, imm8")]
    vprord_zmm_k1z_zmm_imm8 = 3654,
    /// <summary>
    /// vprord zmm {k1}{z}, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vprord zmm_k1z, m512, imm8","vprord zmm {k1}{z}, zmm/m512/m32bcst, imm8")]
    vprord_zmm_k1z_m512_imm8 = 3655,
    /// <summary>
    /// vprord zmm {k1}{z}, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vprord zmm_k1z, m32bcst, imm8","vprord zmm {k1}{z}, zmm/m512/m32bcst, imm8")]
    vprord_zmm_k1z_m32bcst_imm8 = 3656,
    /// <summary>
    /// vprorq xmm {k1}{z}, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("vprorq xmm, xmm, imm8","vprorq xmm {k1}{z}, xmm/m128/m64bcst, imm8")]
    vprorq_xmm_xmm_imm8 = 3657,
    /// <summary>
    /// vprorq xmm {k1}{z}, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("vprorq xmm, m128, imm8","vprorq xmm {k1}{z}, xmm/m128/m64bcst, imm8")]
    vprorq_xmm_m128_imm8 = 3658,
    /// <summary>
    /// vprorq xmm {k1}{z}, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("vprorq xmm, m64bcst, imm8","vprorq xmm {k1}{z}, xmm/m128/m64bcst, imm8")]
    vprorq_xmm_m64bcst_imm8 = 3659,
    /// <summary>
    /// vprorq xmm {k1}{z}, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("vprorq xmm_k1z, xmm, imm8","vprorq xmm {k1}{z}, xmm/m128/m64bcst, imm8")]
    vprorq_xmm_k1z_xmm_imm8 = 3660,
    /// <summary>
    /// vprorq xmm {k1}{z}, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("vprorq xmm_k1z, m128, imm8","vprorq xmm {k1}{z}, xmm/m128/m64bcst, imm8")]
    vprorq_xmm_k1z_m128_imm8 = 3661,
    /// <summary>
    /// vprorq xmm {k1}{z}, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("vprorq xmm_k1z, m64bcst, imm8","vprorq xmm {k1}{z}, xmm/m128/m64bcst, imm8")]
    vprorq_xmm_k1z_m64bcst_imm8 = 3662,
    /// <summary>
    /// vprorq ymm {k1}{z}, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vprorq ymm, ymm, imm8","vprorq ymm {k1}{z}, ymm/m256/m64bcst, imm8")]
    vprorq_ymm_ymm_imm8 = 3663,
    /// <summary>
    /// vprorq ymm {k1}{z}, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vprorq ymm, m256, imm8","vprorq ymm {k1}{z}, ymm/m256/m64bcst, imm8")]
    vprorq_ymm_m256_imm8 = 3664,
    /// <summary>
    /// vprorq ymm {k1}{z}, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vprorq ymm, m64bcst, imm8","vprorq ymm {k1}{z}, ymm/m256/m64bcst, imm8")]
    vprorq_ymm_m64bcst_imm8 = 3665,
    /// <summary>
    /// vprorq ymm {k1}{z}, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vprorq ymm_k1z, ymm, imm8","vprorq ymm {k1}{z}, ymm/m256/m64bcst, imm8")]
    vprorq_ymm_k1z_ymm_imm8 = 3666,
    /// <summary>
    /// vprorq ymm {k1}{z}, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vprorq ymm_k1z, m256, imm8","vprorq ymm {k1}{z}, ymm/m256/m64bcst, imm8")]
    vprorq_ymm_k1z_m256_imm8 = 3667,
    /// <summary>
    /// vprorq ymm {k1}{z}, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vprorq ymm_k1z, m64bcst, imm8","vprorq ymm {k1}{z}, ymm/m256/m64bcst, imm8")]
    vprorq_ymm_k1z_m64bcst_imm8 = 3668,
    /// <summary>
    /// vprorq zmm {k1}{z}, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vprorq zmm, zmm, imm8","vprorq zmm {k1}{z}, zmm/m512/m64bcst, imm8")]
    vprorq_zmm_zmm_imm8 = 3669,
    /// <summary>
    /// vprorq zmm {k1}{z}, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vprorq zmm, m512, imm8","vprorq zmm {k1}{z}, zmm/m512/m64bcst, imm8")]
    vprorq_zmm_m512_imm8 = 3670,
    /// <summary>
    /// vprorq zmm {k1}{z}, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vprorq zmm, m64bcst, imm8","vprorq zmm {k1}{z}, zmm/m512/m64bcst, imm8")]
    vprorq_zmm_m64bcst_imm8 = 3671,
    /// <summary>
    /// vprorq zmm {k1}{z}, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vprorq zmm_k1z, zmm, imm8","vprorq zmm {k1}{z}, zmm/m512/m64bcst, imm8")]
    vprorq_zmm_k1z_zmm_imm8 = 3672,
    /// <summary>
    /// vprorq zmm {k1}{z}, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vprorq zmm_k1z, m512, imm8","vprorq zmm {k1}{z}, zmm/m512/m64bcst, imm8")]
    vprorq_zmm_k1z_m512_imm8 = 3673,
    /// <summary>
    /// vprorq zmm {k1}{z}, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vprorq zmm_k1z, m64bcst, imm8","vprorq zmm {k1}{z}, zmm/m512/m64bcst, imm8")]
    vprorq_zmm_k1z_m64bcst_imm8 = 3674,
    /// <summary>
    /// vprorvd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vprorvd xmm, xmm, xmm","vprorvd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vprorvd_xmm_xmm_xmm = 3675,
    /// <summary>
    /// vprorvd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vprorvd xmm, xmm, m128","vprorvd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vprorvd_xmm_xmm_m128 = 3676,
    /// <summary>
    /// vprorvd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vprorvd xmm, xmm, m32bcst","vprorvd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vprorvd_xmm_xmm_m32bcst = 3677,
    /// <summary>
    /// vprorvd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vprorvd xmm_k1z, xmm, xmm","vprorvd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vprorvd_xmm_k1z_xmm_xmm = 3678,
    /// <summary>
    /// vprorvd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vprorvd xmm_k1z, xmm, m128","vprorvd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vprorvd_xmm_k1z_xmm_m128 = 3679,
    /// <summary>
    /// vprorvd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vprorvd xmm_k1z, xmm, m32bcst","vprorvd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vprorvd_xmm_k1z_xmm_m32bcst = 3680,
    /// <summary>
    /// vprorvd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vprorvd ymm, ymm, ymm","vprorvd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vprorvd_ymm_ymm_ymm = 3681,
    /// <summary>
    /// vprorvd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vprorvd ymm, ymm, m256","vprorvd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vprorvd_ymm_ymm_m256 = 3682,
    /// <summary>
    /// vprorvd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vprorvd ymm, ymm, m32bcst","vprorvd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vprorvd_ymm_ymm_m32bcst = 3683,
    /// <summary>
    /// vprorvd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vprorvd ymm_k1z, ymm, ymm","vprorvd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vprorvd_ymm_k1z_ymm_ymm = 3684,
    /// <summary>
    /// vprorvd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vprorvd ymm_k1z, ymm, m256","vprorvd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vprorvd_ymm_k1z_ymm_m256 = 3685,
    /// <summary>
    /// vprorvd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vprorvd ymm_k1z, ymm, m32bcst","vprorvd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vprorvd_ymm_k1z_ymm_m32bcst = 3686,
    /// <summary>
    /// vprorvd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vprorvd zmm, zmm, zmm","vprorvd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vprorvd_zmm_zmm_zmm = 3687,
    /// <summary>
    /// vprorvd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vprorvd zmm, zmm, m512","vprorvd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vprorvd_zmm_zmm_m512 = 3688,
    /// <summary>
    /// vprorvd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vprorvd zmm, zmm, m32bcst","vprorvd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vprorvd_zmm_zmm_m32bcst = 3689,
    /// <summary>
    /// vprorvd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vprorvd zmm_k1z, zmm, zmm","vprorvd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vprorvd_zmm_k1z_zmm_zmm = 3690,
    /// <summary>
    /// vprorvd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vprorvd zmm_k1z, zmm, m512","vprorvd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vprorvd_zmm_k1z_zmm_m512 = 3691,
    /// <summary>
    /// vprorvd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vprorvd zmm_k1z, zmm, m32bcst","vprorvd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vprorvd_zmm_k1z_zmm_m32bcst = 3692,
    /// <summary>
    /// vprorvq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vprorvq xmm, xmm, xmm","vprorvq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vprorvq_xmm_xmm_xmm = 3693,
    /// <summary>
    /// vprorvq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vprorvq xmm, xmm, m128","vprorvq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vprorvq_xmm_xmm_m128 = 3694,
    /// <summary>
    /// vprorvq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vprorvq xmm, xmm, m64bcst","vprorvq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vprorvq_xmm_xmm_m64bcst = 3695,
    /// <summary>
    /// vprorvq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vprorvq xmm_k1z, xmm, xmm","vprorvq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vprorvq_xmm_k1z_xmm_xmm = 3696,
    /// <summary>
    /// vprorvq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vprorvq xmm_k1z, xmm, m128","vprorvq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vprorvq_xmm_k1z_xmm_m128 = 3697,
    /// <summary>
    /// vprorvq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vprorvq xmm_k1z, xmm, m64bcst","vprorvq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vprorvq_xmm_k1z_xmm_m64bcst = 3698,
    /// <summary>
    /// vprorvq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vprorvq ymm, ymm, ymm","vprorvq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vprorvq_ymm_ymm_ymm = 3699,
    /// <summary>
    /// vprorvq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vprorvq ymm, ymm, m256","vprorvq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vprorvq_ymm_ymm_m256 = 3700,
    /// <summary>
    /// vprorvq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vprorvq ymm, ymm, m64bcst","vprorvq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vprorvq_ymm_ymm_m64bcst = 3701,
    /// <summary>
    /// vprorvq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vprorvq ymm_k1z, ymm, ymm","vprorvq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vprorvq_ymm_k1z_ymm_ymm = 3702,
    /// <summary>
    /// vprorvq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vprorvq ymm_k1z, ymm, m256","vprorvq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vprorvq_ymm_k1z_ymm_m256 = 3703,
    /// <summary>
    /// vprorvq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vprorvq ymm_k1z, ymm, m64bcst","vprorvq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vprorvq_ymm_k1z_ymm_m64bcst = 3704,
    /// <summary>
    /// vprorvq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vprorvq zmm, zmm, zmm","vprorvq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vprorvq_zmm_zmm_zmm = 3705,
    /// <summary>
    /// vprorvq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vprorvq zmm, zmm, m512","vprorvq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vprorvq_zmm_zmm_m512 = 3706,
    /// <summary>
    /// vprorvq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vprorvq zmm, zmm, m64bcst","vprorvq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vprorvq_zmm_zmm_m64bcst = 3707,
    /// <summary>
    /// vprorvq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vprorvq zmm_k1z, zmm, zmm","vprorvq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vprorvq_zmm_k1z_zmm_zmm = 3708,
    /// <summary>
    /// vprorvq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vprorvq zmm_k1z, zmm, m512","vprorvq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vprorvq_zmm_k1z_zmm_m512 = 3709,
    /// <summary>
    /// vprorvq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vprorvq zmm_k1z, zmm, m64bcst","vprorvq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vprorvq_zmm_k1z_zmm_m64bcst = 3710,
    /// <summary>
    /// vpscatterdd vm32x {k1}, xmm
    /// </summary>
    [Symbol("vpscatterdd vm32x {k1}, xmm","vpscatterdd vm32x {k1}, xmm")]
    vpscatterdd_vm32x_k1_xmm = 3711,
    /// <summary>
    /// vpscatterdd vm32y {k1}, ymm
    /// </summary>
    [Symbol("vpscatterdd vm32y {k1}, ymm","vpscatterdd vm32y {k1}, ymm")]
    vpscatterdd_vm32y_k1_ymm = 3712,
    /// <summary>
    /// vpscatterdd vm32z {k1}, zmm
    /// </summary>
    [Symbol("vpscatterdd vm32z {k1}, zmm","vpscatterdd vm32z {k1}, zmm")]
    vpscatterdd_vm32z_k1_zmm = 3713,
    /// <summary>
    /// vpscatterdq vm32x {k1}, xmm
    /// </summary>
    [Symbol("vpscatterdq vm32x {k1}, xmm","vpscatterdq vm32x {k1}, xmm")]
    vpscatterdq_vm32x_k1_xmm = 3714,
    /// <summary>
    /// vpscatterdq vm32x {k1}, ymm
    /// </summary>
    [Symbol("vpscatterdq vm32x {k1}, ymm","vpscatterdq vm32x {k1}, ymm")]
    vpscatterdq_vm32x_k1_ymm = 3715,
    /// <summary>
    /// vpscatterdq vm32y {k1}, zmm
    /// </summary>
    [Symbol("vpscatterdq vm32y {k1}, zmm","vpscatterdq vm32y {k1}, zmm")]
    vpscatterdq_vm32y_k1_zmm = 3716,
    /// <summary>
    /// vpscatterqd vm64x {k1}, xmm
    /// </summary>
    [Symbol("vpscatterqd vm64x {k1}, xmm","vpscatterqd vm64x {k1}, xmm")]
    vpscatterqd_vm64x_k1_xmm = 3717,
    /// <summary>
    /// vpscatterqd vm64y {k1}, xmm
    /// </summary>
    [Symbol("vpscatterqd vm64y {k1}, xmm","vpscatterqd vm64y {k1}, xmm")]
    vpscatterqd_vm64y_k1_xmm = 3718,
    /// <summary>
    /// vpscatterqd vm64z {k1}, ymm
    /// </summary>
    [Symbol("vpscatterqd vm64z {k1}, ymm","vpscatterqd vm64z {k1}, ymm")]
    vpscatterqd_vm64z_k1_ymm = 3719,
    /// <summary>
    /// vpscatterqq vm64x {k1}, xmm
    /// </summary>
    [Symbol("vpscatterqq vm64x {k1}, xmm","vpscatterqq vm64x {k1}, xmm")]
    vpscatterqq_vm64x_k1_xmm = 3720,
    /// <summary>
    /// vpscatterqq vm64y {k1}, ymm
    /// </summary>
    [Symbol("vpscatterqq vm64y {k1}, ymm","vpscatterqq vm64y {k1}, ymm")]
    vpscatterqq_vm64y_k1_ymm = 3721,
    /// <summary>
    /// vpscatterqq vm64z {k1}, zmm
    /// </summary>
    [Symbol("vpscatterqq vm64z {k1}, zmm","vpscatterqq vm64z {k1}, zmm")]
    vpscatterqq_vm64z_k1_zmm = 3722,
    /// <summary>
    /// vpshufb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpshufb xmm, xmm, xmm","vpshufb xmm {k1}{z}, xmm, xmm/m128")]
    vpshufb_xmm_xmm_xmm = 3723,
    /// <summary>
    /// vpshufb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpshufb xmm, xmm, m128","vpshufb xmm {k1}{z}, xmm, xmm/m128")]
    vpshufb_xmm_xmm_m128 = 3724,
    /// <summary>
    /// vpshufb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpshufb xmm_k1z, xmm, xmm","vpshufb xmm {k1}{z}, xmm, xmm/m128")]
    vpshufb_xmm_k1z_xmm_xmm = 3725,
    /// <summary>
    /// vpshufb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpshufb xmm_k1z, xmm, m128","vpshufb xmm {k1}{z}, xmm, xmm/m128")]
    vpshufb_xmm_k1z_xmm_m128 = 3726,
    /// <summary>
    /// vpshufb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpshufb ymm, ymm, ymm","vpshufb ymm {k1}{z}, ymm, ymm/m256")]
    vpshufb_ymm_ymm_ymm = 3727,
    /// <summary>
    /// vpshufb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpshufb ymm, ymm, m256","vpshufb ymm {k1}{z}, ymm, ymm/m256")]
    vpshufb_ymm_ymm_m256 = 3728,
    /// <summary>
    /// vpshufb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpshufb ymm_k1z, ymm, ymm","vpshufb ymm {k1}{z}, ymm, ymm/m256")]
    vpshufb_ymm_k1z_ymm_ymm = 3729,
    /// <summary>
    /// vpshufb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpshufb ymm_k1z, ymm, m256","vpshufb ymm {k1}{z}, ymm, ymm/m256")]
    vpshufb_ymm_k1z_ymm_m256 = 3730,
    /// <summary>
    /// vpshufb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpshufb zmm, zmm, zmm","vpshufb zmm {k1}{z}, zmm, zmm/m512")]
    vpshufb_zmm_zmm_zmm = 3731,
    /// <summary>
    /// vpshufb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpshufb zmm, zmm, m512","vpshufb zmm {k1}{z}, zmm, zmm/m512")]
    vpshufb_zmm_zmm_m512 = 3732,
    /// <summary>
    /// vpshufb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpshufb zmm_k1z, zmm, zmm","vpshufb zmm {k1}{z}, zmm, zmm/m512")]
    vpshufb_zmm_k1z_zmm_zmm = 3733,
    /// <summary>
    /// vpshufb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpshufb zmm_k1z, zmm, m512","vpshufb zmm {k1}{z}, zmm, zmm/m512")]
    vpshufb_zmm_k1z_zmm_m512 = 3734,
    /// <summary>
    /// vpshufd xmm {k1}{z}, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vpshufd xmm, xmm, imm8","vpshufd xmm {k1}{z}, xmm/m128/m32bcst, imm8")]
    vpshufd_xmm_xmm_imm8 = 3735,
    /// <summary>
    /// vpshufd xmm {k1}{z}, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vpshufd xmm, m128, imm8","vpshufd xmm {k1}{z}, xmm/m128/m32bcst, imm8")]
    vpshufd_xmm_m128_imm8 = 3736,
    /// <summary>
    /// vpshufd xmm {k1}{z}, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vpshufd xmm, m32bcst, imm8","vpshufd xmm {k1}{z}, xmm/m128/m32bcst, imm8")]
    vpshufd_xmm_m32bcst_imm8 = 3737,
    /// <summary>
    /// vpshufd xmm {k1}{z}, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vpshufd xmm_k1z, xmm, imm8","vpshufd xmm {k1}{z}, xmm/m128/m32bcst, imm8")]
    vpshufd_xmm_k1z_xmm_imm8 = 3738,
    /// <summary>
    /// vpshufd xmm {k1}{z}, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vpshufd xmm_k1z, m128, imm8","vpshufd xmm {k1}{z}, xmm/m128/m32bcst, imm8")]
    vpshufd_xmm_k1z_m128_imm8 = 3739,
    /// <summary>
    /// vpshufd xmm {k1}{z}, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vpshufd xmm_k1z, m32bcst, imm8","vpshufd xmm {k1}{z}, xmm/m128/m32bcst, imm8")]
    vpshufd_xmm_k1z_m32bcst_imm8 = 3740,
    /// <summary>
    /// vpshufd ymm {k1}{z}, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vpshufd ymm, ymm, imm8","vpshufd ymm {k1}{z}, ymm/m256/m32bcst, imm8")]
    vpshufd_ymm_ymm_imm8 = 3741,
    /// <summary>
    /// vpshufd ymm {k1}{z}, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vpshufd ymm, m256, imm8","vpshufd ymm {k1}{z}, ymm/m256/m32bcst, imm8")]
    vpshufd_ymm_m256_imm8 = 3742,
    /// <summary>
    /// vpshufd ymm {k1}{z}, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vpshufd ymm, m32bcst, imm8","vpshufd ymm {k1}{z}, ymm/m256/m32bcst, imm8")]
    vpshufd_ymm_m32bcst_imm8 = 3743,
    /// <summary>
    /// vpshufd ymm {k1}{z}, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vpshufd ymm_k1z, ymm, imm8","vpshufd ymm {k1}{z}, ymm/m256/m32bcst, imm8")]
    vpshufd_ymm_k1z_ymm_imm8 = 3744,
    /// <summary>
    /// vpshufd ymm {k1}{z}, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vpshufd ymm_k1z, m256, imm8","vpshufd ymm {k1}{z}, ymm/m256/m32bcst, imm8")]
    vpshufd_ymm_k1z_m256_imm8 = 3745,
    /// <summary>
    /// vpshufd ymm {k1}{z}, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vpshufd ymm_k1z, m32bcst, imm8","vpshufd ymm {k1}{z}, ymm/m256/m32bcst, imm8")]
    vpshufd_ymm_k1z_m32bcst_imm8 = 3746,
    /// <summary>
    /// vpshufd zmm {k1}{z}, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vpshufd zmm, zmm, imm8","vpshufd zmm {k1}{z}, zmm/m512/m32bcst, imm8")]
    vpshufd_zmm_zmm_imm8 = 3747,
    /// <summary>
    /// vpshufd zmm {k1}{z}, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vpshufd zmm, m512, imm8","vpshufd zmm {k1}{z}, zmm/m512/m32bcst, imm8")]
    vpshufd_zmm_m512_imm8 = 3748,
    /// <summary>
    /// vpshufd zmm {k1}{z}, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vpshufd zmm, m32bcst, imm8","vpshufd zmm {k1}{z}, zmm/m512/m32bcst, imm8")]
    vpshufd_zmm_m32bcst_imm8 = 3749,
    /// <summary>
    /// vpshufd zmm {k1}{z}, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vpshufd zmm_k1z, zmm, imm8","vpshufd zmm {k1}{z}, zmm/m512/m32bcst, imm8")]
    vpshufd_zmm_k1z_zmm_imm8 = 3750,
    /// <summary>
    /// vpshufd zmm {k1}{z}, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vpshufd zmm_k1z, m512, imm8","vpshufd zmm {k1}{z}, zmm/m512/m32bcst, imm8")]
    vpshufd_zmm_k1z_m512_imm8 = 3751,
    /// <summary>
    /// vpshufd zmm {k1}{z}, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vpshufd zmm_k1z, m32bcst, imm8","vpshufd zmm {k1}{z}, zmm/m512/m32bcst, imm8")]
    vpshufd_zmm_k1z_m32bcst_imm8 = 3752,
    /// <summary>
    /// vpshuflw xmm {k1}{z}, xmm/m128, imm8
    /// </summary>
    [Symbol("vpshuflw xmm, xmm, imm8","vpshuflw xmm {k1}{z}, xmm/m128, imm8")]
    vpshuflw_xmm_xmm_imm8 = 3753,
    /// <summary>
    /// vpshuflw xmm {k1}{z}, xmm/m128, imm8
    /// </summary>
    [Symbol("vpshuflw xmm, m128, imm8","vpshuflw xmm {k1}{z}, xmm/m128, imm8")]
    vpshuflw_xmm_m128_imm8 = 3754,
    /// <summary>
    /// vpshuflw xmm {k1}{z}, xmm/m128, imm8
    /// </summary>
    [Symbol("vpshuflw xmm_k1z, xmm, imm8","vpshuflw xmm {k1}{z}, xmm/m128, imm8")]
    vpshuflw_xmm_k1z_xmm_imm8 = 3755,
    /// <summary>
    /// vpshuflw xmm {k1}{z}, xmm/m128, imm8
    /// </summary>
    [Symbol("vpshuflw xmm_k1z, m128, imm8","vpshuflw xmm {k1}{z}, xmm/m128, imm8")]
    vpshuflw_xmm_k1z_m128_imm8 = 3756,
    /// <summary>
    /// vpshuflw ymm {k1}{z}, ymm/m256, imm8
    /// </summary>
    [Symbol("vpshuflw ymm, ymm, imm8","vpshuflw ymm {k1}{z}, ymm/m256, imm8")]
    vpshuflw_ymm_ymm_imm8 = 3757,
    /// <summary>
    /// vpshuflw ymm {k1}{z}, ymm/m256, imm8
    /// </summary>
    [Symbol("vpshuflw ymm, m256, imm8","vpshuflw ymm {k1}{z}, ymm/m256, imm8")]
    vpshuflw_ymm_m256_imm8 = 3758,
    /// <summary>
    /// vpshuflw ymm {k1}{z}, ymm/m256, imm8
    /// </summary>
    [Symbol("vpshuflw ymm_k1z, ymm, imm8","vpshuflw ymm {k1}{z}, ymm/m256, imm8")]
    vpshuflw_ymm_k1z_ymm_imm8 = 3759,
    /// <summary>
    /// vpshuflw ymm {k1}{z}, ymm/m256, imm8
    /// </summary>
    [Symbol("vpshuflw ymm_k1z, m256, imm8","vpshuflw ymm {k1}{z}, ymm/m256, imm8")]
    vpshuflw_ymm_k1z_m256_imm8 = 3760,
    /// <summary>
    /// vpshuflw zmm {k1}{z}, zmm/m512, imm8
    /// </summary>
    [Symbol("vpshuflw zmm, zmm, imm8","vpshuflw zmm {k1}{z}, zmm/m512, imm8")]
    vpshuflw_zmm_zmm_imm8 = 3761,
    /// <summary>
    /// vpshuflw zmm {k1}{z}, zmm/m512, imm8
    /// </summary>
    [Symbol("vpshuflw zmm, m512, imm8","vpshuflw zmm {k1}{z}, zmm/m512, imm8")]
    vpshuflw_zmm_m512_imm8 = 3762,
    /// <summary>
    /// vpshuflw zmm {k1}{z}, zmm/m512, imm8
    /// </summary>
    [Symbol("vpshuflw zmm_k1z, zmm, imm8","vpshuflw zmm {k1}{z}, zmm/m512, imm8")]
    vpshuflw_zmm_k1z_zmm_imm8 = 3763,
    /// <summary>
    /// vpshuflw zmm {k1}{z}, zmm/m512, imm8
    /// </summary>
    [Symbol("vpshuflw zmm_k1z, m512, imm8","vpshuflw zmm {k1}{z}, zmm/m512, imm8")]
    vpshuflw_zmm_k1z_m512_imm8 = 3764,
    /// <summary>
    /// vpsignb xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsignb xmm, xmm, xmm","vpsignb xmm, xmm, xmm/m128")]
    vpsignb_xmm_xmm_xmm = 3765,
    /// <summary>
    /// vpsignb xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsignb xmm, xmm, m128","vpsignb xmm, xmm, xmm/m128")]
    vpsignb_xmm_xmm_m128 = 3766,
    /// <summary>
    /// vpsignb ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsignb ymm, ymm, ymm","vpsignb ymm, ymm, ymm/m256")]
    vpsignb_ymm_ymm_ymm = 3767,
    /// <summary>
    /// vpsignb ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsignb ymm, ymm, m256","vpsignb ymm, ymm, ymm/m256")]
    vpsignb_ymm_ymm_m256 = 3768,
    /// <summary>
    /// vpsignd xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsignd xmm, xmm, xmm","vpsignd xmm, xmm, xmm/m128")]
    vpsignd_xmm_xmm_xmm = 3769,
    /// <summary>
    /// vpsignd xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsignd xmm, xmm, m128","vpsignd xmm, xmm, xmm/m128")]
    vpsignd_xmm_xmm_m128 = 3770,
    /// <summary>
    /// vpsignd ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsignd ymm, ymm, ymm","vpsignd ymm, ymm, ymm/m256")]
    vpsignd_ymm_ymm_ymm = 3771,
    /// <summary>
    /// vpsignd ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsignd ymm, ymm, m256","vpsignd ymm, ymm, ymm/m256")]
    vpsignd_ymm_ymm_m256 = 3772,
    /// <summary>
    /// vpsignw xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsignw xmm, xmm, xmm","vpsignw xmm, xmm, xmm/m128")]
    vpsignw_xmm_xmm_xmm = 3773,
    /// <summary>
    /// vpsignw xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsignw xmm, xmm, m128","vpsignw xmm, xmm, xmm/m128")]
    vpsignw_xmm_xmm_m128 = 3774,
    /// <summary>
    /// vpsignw ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsignw ymm, ymm, ymm","vpsignw ymm, ymm, ymm/m256")]
    vpsignw_ymm_ymm_ymm = 3775,
    /// <summary>
    /// vpsignw ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsignw ymm, ymm, m256","vpsignw ymm, ymm, ymm/m256")]
    vpsignw_ymm_ymm_m256 = 3776,
    /// <summary>
    /// vpslld xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpslld xmm, xmm, xmm","vpslld xmm {k1}{z}, xmm, xmm/m128")]
    vpslld_xmm_xmm_xmm = 3777,
    /// <summary>
    /// vpslld xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpslld xmm, xmm, m128","vpslld xmm {k1}{z}, xmm, xmm/m128")]
    vpslld_xmm_xmm_m128 = 3778,
    /// <summary>
    /// vpslld xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpslld xmm_k1z, xmm, xmm","vpslld xmm {k1}{z}, xmm, xmm/m128")]
    vpslld_xmm_k1z_xmm_xmm = 3779,
    /// <summary>
    /// vpslld xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpslld xmm_k1z, xmm, m128","vpslld xmm {k1}{z}, xmm, xmm/m128")]
    vpslld_xmm_k1z_xmm_m128 = 3780,
    /// <summary>
    /// vpslld xmm {k1}{z}, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vpslld xmm, xmm, imm8","vpslld xmm {k1}{z}, xmm/m128/m32bcst, imm8")]
    vpslld_xmm_xmm_imm8 = 3781,
    /// <summary>
    /// vpslld xmm {k1}{z}, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vpslld xmm, m128, imm8","vpslld xmm {k1}{z}, xmm/m128/m32bcst, imm8")]
    vpslld_xmm_m128_imm8 = 3782,
    /// <summary>
    /// vpslld xmm {k1}{z}, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vpslld xmm, m32bcst, imm8","vpslld xmm {k1}{z}, xmm/m128/m32bcst, imm8")]
    vpslld_xmm_m32bcst_imm8 = 3783,
    /// <summary>
    /// vpslld xmm {k1}{z}, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vpslld xmm_k1z, xmm, imm8","vpslld xmm {k1}{z}, xmm/m128/m32bcst, imm8")]
    vpslld_xmm_k1z_xmm_imm8 = 3784,
    /// <summary>
    /// vpslld xmm {k1}{z}, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vpslld xmm_k1z, m128, imm8","vpslld xmm {k1}{z}, xmm/m128/m32bcst, imm8")]
    vpslld_xmm_k1z_m128_imm8 = 3785,
    /// <summary>
    /// vpslld xmm {k1}{z}, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vpslld xmm_k1z, m32bcst, imm8","vpslld xmm {k1}{z}, xmm/m128/m32bcst, imm8")]
    vpslld_xmm_k1z_m32bcst_imm8 = 3786,
    /// <summary>
    /// vpslld ymm {k1}{z}, ymm, xmm/m128
    /// </summary>
    [Symbol("vpslld ymm, ymm, xmm","vpslld ymm {k1}{z}, ymm, xmm/m128")]
    vpslld_ymm_ymm_xmm = 3787,
    /// <summary>
    /// vpslld ymm {k1}{z}, ymm, xmm/m128
    /// </summary>
    [Symbol("vpslld ymm, ymm, m128","vpslld ymm {k1}{z}, ymm, xmm/m128")]
    vpslld_ymm_ymm_m128 = 3788,
    /// <summary>
    /// vpslld ymm {k1}{z}, ymm, xmm/m128
    /// </summary>
    [Symbol("vpslld ymm_k1z, ymm, xmm","vpslld ymm {k1}{z}, ymm, xmm/m128")]
    vpslld_ymm_k1z_ymm_xmm = 3789,
    /// <summary>
    /// vpslld ymm {k1}{z}, ymm, xmm/m128
    /// </summary>
    [Symbol("vpslld ymm_k1z, ymm, m128","vpslld ymm {k1}{z}, ymm, xmm/m128")]
    vpslld_ymm_k1z_ymm_m128 = 3790,
    /// <summary>
    /// vpslld ymm {k1}{z}, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vpslld ymm, ymm, imm8","vpslld ymm {k1}{z}, ymm/m256/m32bcst, imm8")]
    vpslld_ymm_ymm_imm8 = 3791,
    /// <summary>
    /// vpslld ymm {k1}{z}, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vpslld ymm, m256, imm8","vpslld ymm {k1}{z}, ymm/m256/m32bcst, imm8")]
    vpslld_ymm_m256_imm8 = 3792,
    /// <summary>
    /// vpslld ymm {k1}{z}, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vpslld ymm, m32bcst, imm8","vpslld ymm {k1}{z}, ymm/m256/m32bcst, imm8")]
    vpslld_ymm_m32bcst_imm8 = 3793,
    /// <summary>
    /// vpslld ymm {k1}{z}, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vpslld ymm_k1z, ymm, imm8","vpslld ymm {k1}{z}, ymm/m256/m32bcst, imm8")]
    vpslld_ymm_k1z_ymm_imm8 = 3794,
    /// <summary>
    /// vpslld ymm {k1}{z}, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vpslld ymm_k1z, m256, imm8","vpslld ymm {k1}{z}, ymm/m256/m32bcst, imm8")]
    vpslld_ymm_k1z_m256_imm8 = 3795,
    /// <summary>
    /// vpslld ymm {k1}{z}, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vpslld ymm_k1z, m32bcst, imm8","vpslld ymm {k1}{z}, ymm/m256/m32bcst, imm8")]
    vpslld_ymm_k1z_m32bcst_imm8 = 3796,
    /// <summary>
    /// vpslld zmm {k1}{z}, zmm, xmm/m128
    /// </summary>
    [Symbol("vpslld zmm, zmm, xmm","vpslld zmm {k1}{z}, zmm, xmm/m128")]
    vpslld_zmm_zmm_xmm = 3797,
    /// <summary>
    /// vpslld zmm {k1}{z}, zmm, xmm/m128
    /// </summary>
    [Symbol("vpslld zmm, zmm, m128","vpslld zmm {k1}{z}, zmm, xmm/m128")]
    vpslld_zmm_zmm_m128 = 3798,
    /// <summary>
    /// vpslld zmm {k1}{z}, zmm, xmm/m128
    /// </summary>
    [Symbol("vpslld zmm_k1z, zmm, xmm","vpslld zmm {k1}{z}, zmm, xmm/m128")]
    vpslld_zmm_k1z_zmm_xmm = 3799,
    /// <summary>
    /// vpslld zmm {k1}{z}, zmm, xmm/m128
    /// </summary>
    [Symbol("vpslld zmm_k1z, zmm, m128","vpslld zmm {k1}{z}, zmm, xmm/m128")]
    vpslld_zmm_k1z_zmm_m128 = 3800,
    /// <summary>
    /// vpslld zmm {k1}{z}, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vpslld zmm, zmm, imm8","vpslld zmm {k1}{z}, zmm/m512/m32bcst, imm8")]
    vpslld_zmm_zmm_imm8 = 3801,
    /// <summary>
    /// vpslld zmm {k1}{z}, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vpslld zmm, m512, imm8","vpslld zmm {k1}{z}, zmm/m512/m32bcst, imm8")]
    vpslld_zmm_m512_imm8 = 3802,
    /// <summary>
    /// vpslld zmm {k1}{z}, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vpslld zmm, m32bcst, imm8","vpslld zmm {k1}{z}, zmm/m512/m32bcst, imm8")]
    vpslld_zmm_m32bcst_imm8 = 3803,
    /// <summary>
    /// vpslld zmm {k1}{z}, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vpslld zmm_k1z, zmm, imm8","vpslld zmm {k1}{z}, zmm/m512/m32bcst, imm8")]
    vpslld_zmm_k1z_zmm_imm8 = 3804,
    /// <summary>
    /// vpslld zmm {k1}{z}, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vpslld zmm_k1z, m512, imm8","vpslld zmm {k1}{z}, zmm/m512/m32bcst, imm8")]
    vpslld_zmm_k1z_m512_imm8 = 3805,
    /// <summary>
    /// vpslld zmm {k1}{z}, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vpslld zmm_k1z, m32bcst, imm8","vpslld zmm {k1}{z}, zmm/m512/m32bcst, imm8")]
    vpslld_zmm_k1z_m32bcst_imm8 = 3806,
    /// <summary>
    /// vpslldq xmm, xmm, imm8
    /// </summary>
    [Symbol("vpslldq xmm, xmm, imm8","vpslldq xmm, xmm, imm8")]
    vpslldq_xmm_xmm_imm8 = 3807,
    /// <summary>
    /// vpslldq xmm, xmm/m128, imm8
    /// </summary>
    [Symbol("vpslldq xmm, m128, imm8","vpslldq xmm, xmm/m128, imm8")]
    vpslldq_xmm_m128_imm8 = 3808,
    /// <summary>
    /// vpslldq ymm, ymm, imm8
    /// </summary>
    [Symbol("vpslldq ymm, ymm, imm8","vpslldq ymm, ymm, imm8")]
    vpslldq_ymm_ymm_imm8 = 3809,
    /// <summary>
    /// vpslldq ymm, ymm/m256, imm8
    /// </summary>
    [Symbol("vpslldq ymm, m256, imm8","vpslldq ymm, ymm/m256, imm8")]
    vpslldq_ymm_m256_imm8 = 3810,
    /// <summary>
    /// vpslldq zmm, zmm/m512, imm8
    /// </summary>
    [Symbol("vpslldq zmm, zmm, imm8","vpslldq zmm, zmm/m512, imm8")]
    vpslldq_zmm_zmm_imm8 = 3811,
    /// <summary>
    /// vpslldq zmm, zmm/m512, imm8
    /// </summary>
    [Symbol("vpslldq zmm, m512, imm8","vpslldq zmm, zmm/m512, imm8")]
    vpslldq_zmm_m512_imm8 = 3812,
    /// <summary>
    /// vpsllq xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsllq xmm, xmm, xmm","vpsllq xmm {k1}{z}, xmm, xmm/m128")]
    vpsllq_xmm_xmm_xmm = 3813,
    /// <summary>
    /// vpsllq xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsllq xmm, xmm, m128","vpsllq xmm {k1}{z}, xmm, xmm/m128")]
    vpsllq_xmm_xmm_m128 = 3814,
    /// <summary>
    /// vpsllq xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsllq xmm_k1z, xmm, xmm","vpsllq xmm {k1}{z}, xmm, xmm/m128")]
    vpsllq_xmm_k1z_xmm_xmm = 3815,
    /// <summary>
    /// vpsllq xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsllq xmm_k1z, xmm, m128","vpsllq xmm {k1}{z}, xmm, xmm/m128")]
    vpsllq_xmm_k1z_xmm_m128 = 3816,
    /// <summary>
    /// vpsllq xmm {k1}{z}, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("vpsllq xmm, xmm, imm8","vpsllq xmm {k1}{z}, xmm/m128/m64bcst, imm8")]
    vpsllq_xmm_xmm_imm8 = 3817,
    /// <summary>
    /// vpsllq xmm {k1}{z}, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("vpsllq xmm, m128, imm8","vpsllq xmm {k1}{z}, xmm/m128/m64bcst, imm8")]
    vpsllq_xmm_m128_imm8 = 3818,
    /// <summary>
    /// vpsllq xmm {k1}{z}, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("vpsllq xmm, m64bcst, imm8","vpsllq xmm {k1}{z}, xmm/m128/m64bcst, imm8")]
    vpsllq_xmm_m64bcst_imm8 = 3819,
    /// <summary>
    /// vpsllq xmm {k1}{z}, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("vpsllq xmm_k1z, xmm, imm8","vpsllq xmm {k1}{z}, xmm/m128/m64bcst, imm8")]
    vpsllq_xmm_k1z_xmm_imm8 = 3820,
    /// <summary>
    /// vpsllq xmm {k1}{z}, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("vpsllq xmm_k1z, m128, imm8","vpsllq xmm {k1}{z}, xmm/m128/m64bcst, imm8")]
    vpsllq_xmm_k1z_m128_imm8 = 3821,
    /// <summary>
    /// vpsllq xmm {k1}{z}, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("vpsllq xmm_k1z, m64bcst, imm8","vpsllq xmm {k1}{z}, xmm/m128/m64bcst, imm8")]
    vpsllq_xmm_k1z_m64bcst_imm8 = 3822,
    /// <summary>
    /// vpsllq ymm {k1}{z}, ymm, xmm/m128
    /// </summary>
    [Symbol("vpsllq ymm, ymm, xmm","vpsllq ymm {k1}{z}, ymm, xmm/m128")]
    vpsllq_ymm_ymm_xmm = 3823,
    /// <summary>
    /// vpsllq ymm {k1}{z}, ymm, xmm/m128
    /// </summary>
    [Symbol("vpsllq ymm, ymm, m128","vpsllq ymm {k1}{z}, ymm, xmm/m128")]
    vpsllq_ymm_ymm_m128 = 3824,
    /// <summary>
    /// vpsllq ymm {k1}{z}, ymm, xmm/m128
    /// </summary>
    [Symbol("vpsllq ymm_k1z, ymm, xmm","vpsllq ymm {k1}{z}, ymm, xmm/m128")]
    vpsllq_ymm_k1z_ymm_xmm = 3825,
    /// <summary>
    /// vpsllq ymm {k1}{z}, ymm, xmm/m128
    /// </summary>
    [Symbol("vpsllq ymm_k1z, ymm, m128","vpsllq ymm {k1}{z}, ymm, xmm/m128")]
    vpsllq_ymm_k1z_ymm_m128 = 3826,
    /// <summary>
    /// vpsllq ymm {k1}{z}, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vpsllq ymm, ymm, imm8","vpsllq ymm {k1}{z}, ymm/m256/m64bcst, imm8")]
    vpsllq_ymm_ymm_imm8 = 3827,
    /// <summary>
    /// vpsllq ymm {k1}{z}, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vpsllq ymm, m256, imm8","vpsllq ymm {k1}{z}, ymm/m256/m64bcst, imm8")]
    vpsllq_ymm_m256_imm8 = 3828,
    /// <summary>
    /// vpsllq ymm {k1}{z}, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vpsllq ymm, m64bcst, imm8","vpsllq ymm {k1}{z}, ymm/m256/m64bcst, imm8")]
    vpsllq_ymm_m64bcst_imm8 = 3829,
    /// <summary>
    /// vpsllq ymm {k1}{z}, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vpsllq ymm_k1z, ymm, imm8","vpsllq ymm {k1}{z}, ymm/m256/m64bcst, imm8")]
    vpsllq_ymm_k1z_ymm_imm8 = 3830,
    /// <summary>
    /// vpsllq ymm {k1}{z}, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vpsllq ymm_k1z, m256, imm8","vpsllq ymm {k1}{z}, ymm/m256/m64bcst, imm8")]
    vpsllq_ymm_k1z_m256_imm8 = 3831,
    /// <summary>
    /// vpsllq ymm {k1}{z}, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vpsllq ymm_k1z, m64bcst, imm8","vpsllq ymm {k1}{z}, ymm/m256/m64bcst, imm8")]
    vpsllq_ymm_k1z_m64bcst_imm8 = 3832,
    /// <summary>
    /// vpsllq zmm {k1}{z}, zmm, xmm/m128
    /// </summary>
    [Symbol("vpsllq zmm, zmm, xmm","vpsllq zmm {k1}{z}, zmm, xmm/m128")]
    vpsllq_zmm_zmm_xmm = 3833,
    /// <summary>
    /// vpsllq zmm {k1}{z}, zmm, xmm/m128
    /// </summary>
    [Symbol("vpsllq zmm, zmm, m128","vpsllq zmm {k1}{z}, zmm, xmm/m128")]
    vpsllq_zmm_zmm_m128 = 3834,
    /// <summary>
    /// vpsllq zmm {k1}{z}, zmm, xmm/m128
    /// </summary>
    [Symbol("vpsllq zmm_k1z, zmm, xmm","vpsllq zmm {k1}{z}, zmm, xmm/m128")]
    vpsllq_zmm_k1z_zmm_xmm = 3835,
    /// <summary>
    /// vpsllq zmm {k1}{z}, zmm, xmm/m128
    /// </summary>
    [Symbol("vpsllq zmm_k1z, zmm, m128","vpsllq zmm {k1}{z}, zmm, xmm/m128")]
    vpsllq_zmm_k1z_zmm_m128 = 3836,
    /// <summary>
    /// vpsllq zmm {k1}{z}, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vpsllq zmm, zmm, imm8","vpsllq zmm {k1}{z}, zmm/m512/m64bcst, imm8")]
    vpsllq_zmm_zmm_imm8 = 3837,
    /// <summary>
    /// vpsllq zmm {k1}{z}, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vpsllq zmm, m512, imm8","vpsllq zmm {k1}{z}, zmm/m512/m64bcst, imm8")]
    vpsllq_zmm_m512_imm8 = 3838,
    /// <summary>
    /// vpsllq zmm {k1}{z}, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vpsllq zmm, m64bcst, imm8","vpsllq zmm {k1}{z}, zmm/m512/m64bcst, imm8")]
    vpsllq_zmm_m64bcst_imm8 = 3839,
    /// <summary>
    /// vpsllq zmm {k1}{z}, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vpsllq zmm_k1z, zmm, imm8","vpsllq zmm {k1}{z}, zmm/m512/m64bcst, imm8")]
    vpsllq_zmm_k1z_zmm_imm8 = 3840,
    /// <summary>
    /// vpsllq zmm {k1}{z}, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vpsllq zmm_k1z, m512, imm8","vpsllq zmm {k1}{z}, zmm/m512/m64bcst, imm8")]
    vpsllq_zmm_k1z_m512_imm8 = 3841,
    /// <summary>
    /// vpsllq zmm {k1}{z}, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vpsllq zmm_k1z, m64bcst, imm8","vpsllq zmm {k1}{z}, zmm/m512/m64bcst, imm8")]
    vpsllq_zmm_k1z_m64bcst_imm8 = 3842,
    /// <summary>
    /// vpsllvd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpsllvd xmm, xmm, xmm","vpsllvd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpsllvd_xmm_xmm_xmm = 3843,
    /// <summary>
    /// vpsllvd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpsllvd xmm, xmm, m128","vpsllvd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpsllvd_xmm_xmm_m128 = 3844,
    /// <summary>
    /// vpsllvd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpsllvd xmm, xmm, m32bcst","vpsllvd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpsllvd_xmm_xmm_m32bcst = 3845,
    /// <summary>
    /// vpsllvd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpsllvd xmm_k1z, xmm, xmm","vpsllvd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpsllvd_xmm_k1z_xmm_xmm = 3846,
    /// <summary>
    /// vpsllvd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpsllvd xmm_k1z, xmm, m128","vpsllvd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpsllvd_xmm_k1z_xmm_m128 = 3847,
    /// <summary>
    /// vpsllvd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpsllvd xmm_k1z, xmm, m32bcst","vpsllvd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpsllvd_xmm_k1z_xmm_m32bcst = 3848,
    /// <summary>
    /// vpsllvd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpsllvd ymm, ymm, ymm","vpsllvd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpsllvd_ymm_ymm_ymm = 3849,
    /// <summary>
    /// vpsllvd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpsllvd ymm, ymm, m256","vpsllvd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpsllvd_ymm_ymm_m256 = 3850,
    /// <summary>
    /// vpsllvd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpsllvd ymm, ymm, m32bcst","vpsllvd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpsllvd_ymm_ymm_m32bcst = 3851,
    /// <summary>
    /// vpsllvd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpsllvd ymm_k1z, ymm, ymm","vpsllvd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpsllvd_ymm_k1z_ymm_ymm = 3852,
    /// <summary>
    /// vpsllvd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpsllvd ymm_k1z, ymm, m256","vpsllvd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpsllvd_ymm_k1z_ymm_m256 = 3853,
    /// <summary>
    /// vpsllvd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpsllvd ymm_k1z, ymm, m32bcst","vpsllvd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpsllvd_ymm_k1z_ymm_m32bcst = 3854,
    /// <summary>
    /// vpsllvd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpsllvd zmm, zmm, zmm","vpsllvd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpsllvd_zmm_zmm_zmm = 3855,
    /// <summary>
    /// vpsllvd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpsllvd zmm, zmm, m512","vpsllvd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpsllvd_zmm_zmm_m512 = 3856,
    /// <summary>
    /// vpsllvd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpsllvd zmm, zmm, m32bcst","vpsllvd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpsllvd_zmm_zmm_m32bcst = 3857,
    /// <summary>
    /// vpsllvd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpsllvd zmm_k1z, zmm, zmm","vpsllvd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpsllvd_zmm_k1z_zmm_zmm = 3858,
    /// <summary>
    /// vpsllvd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpsllvd zmm_k1z, zmm, m512","vpsllvd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpsllvd_zmm_k1z_zmm_m512 = 3859,
    /// <summary>
    /// vpsllvd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpsllvd zmm_k1z, zmm, m32bcst","vpsllvd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpsllvd_zmm_k1z_zmm_m32bcst = 3860,
    /// <summary>
    /// vpsllvq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpsllvq xmm, xmm, xmm","vpsllvq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpsllvq_xmm_xmm_xmm = 3861,
    /// <summary>
    /// vpsllvq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpsllvq xmm, xmm, m128","vpsllvq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpsllvq_xmm_xmm_m128 = 3862,
    /// <summary>
    /// vpsllvq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpsllvq xmm, xmm, m64bcst","vpsllvq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpsllvq_xmm_xmm_m64bcst = 3863,
    /// <summary>
    /// vpsllvq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpsllvq xmm_k1z, xmm, xmm","vpsllvq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpsllvq_xmm_k1z_xmm_xmm = 3864,
    /// <summary>
    /// vpsllvq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpsllvq xmm_k1z, xmm, m128","vpsllvq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpsllvq_xmm_k1z_xmm_m128 = 3865,
    /// <summary>
    /// vpsllvq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpsllvq xmm_k1z, xmm, m64bcst","vpsllvq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpsllvq_xmm_k1z_xmm_m64bcst = 3866,
    /// <summary>
    /// vpsllvq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpsllvq ymm, ymm, ymm","vpsllvq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpsllvq_ymm_ymm_ymm = 3867,
    /// <summary>
    /// vpsllvq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpsllvq ymm, ymm, m256","vpsllvq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpsllvq_ymm_ymm_m256 = 3868,
    /// <summary>
    /// vpsllvq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpsllvq ymm, ymm, m64bcst","vpsllvq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpsllvq_ymm_ymm_m64bcst = 3869,
    /// <summary>
    /// vpsllvq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpsllvq ymm_k1z, ymm, ymm","vpsllvq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpsllvq_ymm_k1z_ymm_ymm = 3870,
    /// <summary>
    /// vpsllvq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpsllvq ymm_k1z, ymm, m256","vpsllvq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpsllvq_ymm_k1z_ymm_m256 = 3871,
    /// <summary>
    /// vpsllvq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpsllvq ymm_k1z, ymm, m64bcst","vpsllvq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpsllvq_ymm_k1z_ymm_m64bcst = 3872,
    /// <summary>
    /// vpsllvq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpsllvq zmm, zmm, zmm","vpsllvq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpsllvq_zmm_zmm_zmm = 3873,
    /// <summary>
    /// vpsllvq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpsllvq zmm, zmm, m512","vpsllvq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpsllvq_zmm_zmm_m512 = 3874,
    /// <summary>
    /// vpsllvq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpsllvq zmm, zmm, m64bcst","vpsllvq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpsllvq_zmm_zmm_m64bcst = 3875,
    /// <summary>
    /// vpsllvq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpsllvq zmm_k1z, zmm, zmm","vpsllvq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpsllvq_zmm_k1z_zmm_zmm = 3876,
    /// <summary>
    /// vpsllvq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpsllvq zmm_k1z, zmm, m512","vpsllvq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpsllvq_zmm_k1z_zmm_m512 = 3877,
    /// <summary>
    /// vpsllvq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpsllvq zmm_k1z, zmm, m64bcst","vpsllvq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpsllvq_zmm_k1z_zmm_m64bcst = 3878,
    /// <summary>
    /// vpsllvw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsllvw xmm, xmm, xmm","vpsllvw xmm {k1}{z}, xmm, xmm/m128")]
    vpsllvw_xmm_xmm_xmm = 3879,
    /// <summary>
    /// vpsllvw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsllvw xmm, xmm, m128","vpsllvw xmm {k1}{z}, xmm, xmm/m128")]
    vpsllvw_xmm_xmm_m128 = 3880,
    /// <summary>
    /// vpsllvw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsllvw xmm_k1z, xmm, xmm","vpsllvw xmm {k1}{z}, xmm, xmm/m128")]
    vpsllvw_xmm_k1z_xmm_xmm = 3881,
    /// <summary>
    /// vpsllvw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsllvw xmm_k1z, xmm, m128","vpsllvw xmm {k1}{z}, xmm, xmm/m128")]
    vpsllvw_xmm_k1z_xmm_m128 = 3882,
    /// <summary>
    /// vpsllvw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsllvw ymm, ymm, ymm","vpsllvw ymm {k1}{z}, ymm, ymm/m256")]
    vpsllvw_ymm_ymm_ymm = 3883,
    /// <summary>
    /// vpsllvw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsllvw ymm, ymm, m256","vpsllvw ymm {k1}{z}, ymm, ymm/m256")]
    vpsllvw_ymm_ymm_m256 = 3884,
    /// <summary>
    /// vpsllvw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsllvw ymm_k1z, ymm, ymm","vpsllvw ymm {k1}{z}, ymm, ymm/m256")]
    vpsllvw_ymm_k1z_ymm_ymm = 3885,
    /// <summary>
    /// vpsllvw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsllvw ymm_k1z, ymm, m256","vpsllvw ymm {k1}{z}, ymm, ymm/m256")]
    vpsllvw_ymm_k1z_ymm_m256 = 3886,
    /// <summary>
    /// vpsllvw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpsllvw zmm, zmm, zmm","vpsllvw zmm {k1}{z}, zmm, zmm/m512")]
    vpsllvw_zmm_zmm_zmm = 3887,
    /// <summary>
    /// vpsllvw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpsllvw zmm, zmm, m512","vpsllvw zmm {k1}{z}, zmm, zmm/m512")]
    vpsllvw_zmm_zmm_m512 = 3888,
    /// <summary>
    /// vpsllvw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpsllvw zmm_k1z, zmm, zmm","vpsllvw zmm {k1}{z}, zmm, zmm/m512")]
    vpsllvw_zmm_k1z_zmm_zmm = 3889,
    /// <summary>
    /// vpsllvw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpsllvw zmm_k1z, zmm, m512","vpsllvw zmm {k1}{z}, zmm, zmm/m512")]
    vpsllvw_zmm_k1z_zmm_m512 = 3890,
    /// <summary>
    /// vpsllw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsllw xmm, xmm, xmm","vpsllw xmm {k1}{z}, xmm, xmm/m128")]
    vpsllw_xmm_xmm_xmm = 3891,
    /// <summary>
    /// vpsllw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsllw xmm, xmm, m128","vpsllw xmm {k1}{z}, xmm, xmm/m128")]
    vpsllw_xmm_xmm_m128 = 3892,
    /// <summary>
    /// vpsllw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsllw xmm_k1z, xmm, xmm","vpsllw xmm {k1}{z}, xmm, xmm/m128")]
    vpsllw_xmm_k1z_xmm_xmm = 3893,
    /// <summary>
    /// vpsllw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsllw xmm_k1z, xmm, m128","vpsllw xmm {k1}{z}, xmm, xmm/m128")]
    vpsllw_xmm_k1z_xmm_m128 = 3894,
    /// <summary>
    /// vpsllw xmm {k1}{z}, xmm/m128, imm8
    /// </summary>
    [Symbol("vpsllw xmm, xmm, imm8","vpsllw xmm {k1}{z}, xmm/m128, imm8")]
    vpsllw_xmm_xmm_imm8 = 3895,
    /// <summary>
    /// vpsllw xmm {k1}{z}, xmm/m128, imm8
    /// </summary>
    [Symbol("vpsllw xmm, m128, imm8","vpsllw xmm {k1}{z}, xmm/m128, imm8")]
    vpsllw_xmm_m128_imm8 = 3896,
    /// <summary>
    /// vpsllw xmm {k1}{z}, xmm/m128, imm8
    /// </summary>
    [Symbol("vpsllw xmm_k1z, xmm, imm8","vpsllw xmm {k1}{z}, xmm/m128, imm8")]
    vpsllw_xmm_k1z_xmm_imm8 = 3897,
    /// <summary>
    /// vpsllw xmm {k1}{z}, xmm/m128, imm8
    /// </summary>
    [Symbol("vpsllw xmm_k1z, m128, imm8","vpsllw xmm {k1}{z}, xmm/m128, imm8")]
    vpsllw_xmm_k1z_m128_imm8 = 3898,
    /// <summary>
    /// vpsllw ymm {k1}{z}, ymm, xmm/m128
    /// </summary>
    [Symbol("vpsllw ymm, ymm, xmm","vpsllw ymm {k1}{z}, ymm, xmm/m128")]
    vpsllw_ymm_ymm_xmm = 3899,
    /// <summary>
    /// vpsllw ymm {k1}{z}, ymm, xmm/m128
    /// </summary>
    [Symbol("vpsllw ymm, ymm, m128","vpsllw ymm {k1}{z}, ymm, xmm/m128")]
    vpsllw_ymm_ymm_m128 = 3900,
    /// <summary>
    /// vpsllw ymm {k1}{z}, ymm, xmm/m128
    /// </summary>
    [Symbol("vpsllw ymm_k1z, ymm, xmm","vpsllw ymm {k1}{z}, ymm, xmm/m128")]
    vpsllw_ymm_k1z_ymm_xmm = 3901,
    /// <summary>
    /// vpsllw ymm {k1}{z}, ymm, xmm/m128
    /// </summary>
    [Symbol("vpsllw ymm_k1z, ymm, m128","vpsllw ymm {k1}{z}, ymm, xmm/m128")]
    vpsllw_ymm_k1z_ymm_m128 = 3902,
    /// <summary>
    /// vpsllw ymm {k1}{z}, ymm/m256, imm8
    /// </summary>
    [Symbol("vpsllw ymm, ymm, imm8","vpsllw ymm {k1}{z}, ymm/m256, imm8")]
    vpsllw_ymm_ymm_imm8 = 3903,
    /// <summary>
    /// vpsllw ymm {k1}{z}, ymm/m256, imm8
    /// </summary>
    [Symbol("vpsllw ymm, m256, imm8","vpsllw ymm {k1}{z}, ymm/m256, imm8")]
    vpsllw_ymm_m256_imm8 = 3904,
    /// <summary>
    /// vpsllw ymm {k1}{z}, ymm/m256, imm8
    /// </summary>
    [Symbol("vpsllw ymm_k1z, ymm, imm8","vpsllw ymm {k1}{z}, ymm/m256, imm8")]
    vpsllw_ymm_k1z_ymm_imm8 = 3905,
    /// <summary>
    /// vpsllw ymm {k1}{z}, ymm/m256, imm8
    /// </summary>
    [Symbol("vpsllw ymm_k1z, m256, imm8","vpsllw ymm {k1}{z}, ymm/m256, imm8")]
    vpsllw_ymm_k1z_m256_imm8 = 3906,
    /// <summary>
    /// vpsllw zmm {k1}{z}, zmm, xmm/m128
    /// </summary>
    [Symbol("vpsllw zmm, zmm, xmm","vpsllw zmm {k1}{z}, zmm, xmm/m128")]
    vpsllw_zmm_zmm_xmm = 3907,
    /// <summary>
    /// vpsllw zmm {k1}{z}, zmm, xmm/m128
    /// </summary>
    [Symbol("vpsllw zmm, zmm, m128","vpsllw zmm {k1}{z}, zmm, xmm/m128")]
    vpsllw_zmm_zmm_m128 = 3908,
    /// <summary>
    /// vpsllw zmm {k1}{z}, zmm, xmm/m128
    /// </summary>
    [Symbol("vpsllw zmm_k1z, zmm, xmm","vpsllw zmm {k1}{z}, zmm, xmm/m128")]
    vpsllw_zmm_k1z_zmm_xmm = 3909,
    /// <summary>
    /// vpsllw zmm {k1}{z}, zmm, xmm/m128
    /// </summary>
    [Symbol("vpsllw zmm_k1z, zmm, m128","vpsllw zmm {k1}{z}, zmm, xmm/m128")]
    vpsllw_zmm_k1z_zmm_m128 = 3910,
    /// <summary>
    /// vpsllw zmm {k1}{z}, zmm/m512, imm8
    /// </summary>
    [Symbol("vpsllw zmm, zmm, imm8","vpsllw zmm {k1}{z}, zmm/m512, imm8")]
    vpsllw_zmm_zmm_imm8 = 3911,
    /// <summary>
    /// vpsllw zmm {k1}{z}, zmm/m512, imm8
    /// </summary>
    [Symbol("vpsllw zmm, m512, imm8","vpsllw zmm {k1}{z}, zmm/m512, imm8")]
    vpsllw_zmm_m512_imm8 = 3912,
    /// <summary>
    /// vpsllw zmm {k1}{z}, zmm/m512, imm8
    /// </summary>
    [Symbol("vpsllw zmm_k1z, zmm, imm8","vpsllw zmm {k1}{z}, zmm/m512, imm8")]
    vpsllw_zmm_k1z_zmm_imm8 = 3913,
    /// <summary>
    /// vpsllw zmm {k1}{z}, zmm/m512, imm8
    /// </summary>
    [Symbol("vpsllw zmm_k1z, m512, imm8","vpsllw zmm {k1}{z}, zmm/m512, imm8")]
    vpsllw_zmm_k1z_m512_imm8 = 3914,
    /// <summary>
    /// vpsrad xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsrad xmm, xmm, xmm","vpsrad xmm {k1}{z}, xmm, xmm/m128")]
    vpsrad_xmm_xmm_xmm = 3915,
    /// <summary>
    /// vpsrad xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsrad xmm, xmm, m128","vpsrad xmm {k1}{z}, xmm, xmm/m128")]
    vpsrad_xmm_xmm_m128 = 3916,
    /// <summary>
    /// vpsrad xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsrad xmm_k1z, xmm, xmm","vpsrad xmm {k1}{z}, xmm, xmm/m128")]
    vpsrad_xmm_k1z_xmm_xmm = 3917,
    /// <summary>
    /// vpsrad xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsrad xmm_k1z, xmm, m128","vpsrad xmm {k1}{z}, xmm, xmm/m128")]
    vpsrad_xmm_k1z_xmm_m128 = 3918,
    /// <summary>
    /// vpsrad xmm {k1}{z}, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vpsrad xmm, xmm, imm8","vpsrad xmm {k1}{z}, xmm/m128/m32bcst, imm8")]
    vpsrad_xmm_xmm_imm8 = 3919,
    /// <summary>
    /// vpsrad xmm {k1}{z}, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vpsrad xmm, m128, imm8","vpsrad xmm {k1}{z}, xmm/m128/m32bcst, imm8")]
    vpsrad_xmm_m128_imm8 = 3920,
    /// <summary>
    /// vpsrad xmm {k1}{z}, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vpsrad xmm, m32bcst, imm8","vpsrad xmm {k1}{z}, xmm/m128/m32bcst, imm8")]
    vpsrad_xmm_m32bcst_imm8 = 3921,
    /// <summary>
    /// vpsrad xmm {k1}{z}, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vpsrad xmm_k1z, xmm, imm8","vpsrad xmm {k1}{z}, xmm/m128/m32bcst, imm8")]
    vpsrad_xmm_k1z_xmm_imm8 = 3922,
    /// <summary>
    /// vpsrad xmm {k1}{z}, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vpsrad xmm_k1z, m128, imm8","vpsrad xmm {k1}{z}, xmm/m128/m32bcst, imm8")]
    vpsrad_xmm_k1z_m128_imm8 = 3923,
    /// <summary>
    /// vpsrad xmm {k1}{z}, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vpsrad xmm_k1z, m32bcst, imm8","vpsrad xmm {k1}{z}, xmm/m128/m32bcst, imm8")]
    vpsrad_xmm_k1z_m32bcst_imm8 = 3924,
    /// <summary>
    /// vpsrad ymm {k1}{z}, ymm, xmm/m128
    /// </summary>
    [Symbol("vpsrad ymm, ymm, xmm","vpsrad ymm {k1}{z}, ymm, xmm/m128")]
    vpsrad_ymm_ymm_xmm = 3925,
    /// <summary>
    /// vpsrad ymm {k1}{z}, ymm, xmm/m128
    /// </summary>
    [Symbol("vpsrad ymm, ymm, m128","vpsrad ymm {k1}{z}, ymm, xmm/m128")]
    vpsrad_ymm_ymm_m128 = 3926,
    /// <summary>
    /// vpsrad ymm {k1}{z}, ymm, xmm/m128
    /// </summary>
    [Symbol("vpsrad ymm_k1z, ymm, xmm","vpsrad ymm {k1}{z}, ymm, xmm/m128")]
    vpsrad_ymm_k1z_ymm_xmm = 3927,
    /// <summary>
    /// vpsrad ymm {k1}{z}, ymm, xmm/m128
    /// </summary>
    [Symbol("vpsrad ymm_k1z, ymm, m128","vpsrad ymm {k1}{z}, ymm, xmm/m128")]
    vpsrad_ymm_k1z_ymm_m128 = 3928,
    /// <summary>
    /// vpsrad ymm {k1}{z}, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vpsrad ymm, ymm, imm8","vpsrad ymm {k1}{z}, ymm/m256/m32bcst, imm8")]
    vpsrad_ymm_ymm_imm8 = 3929,
    /// <summary>
    /// vpsrad ymm {k1}{z}, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vpsrad ymm, m256, imm8","vpsrad ymm {k1}{z}, ymm/m256/m32bcst, imm8")]
    vpsrad_ymm_m256_imm8 = 3930,
    /// <summary>
    /// vpsrad ymm {k1}{z}, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vpsrad ymm, m32bcst, imm8","vpsrad ymm {k1}{z}, ymm/m256/m32bcst, imm8")]
    vpsrad_ymm_m32bcst_imm8 = 3931,
    /// <summary>
    /// vpsrad ymm {k1}{z}, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vpsrad ymm_k1z, ymm, imm8","vpsrad ymm {k1}{z}, ymm/m256/m32bcst, imm8")]
    vpsrad_ymm_k1z_ymm_imm8 = 3932,
    /// <summary>
    /// vpsrad ymm {k1}{z}, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vpsrad ymm_k1z, m256, imm8","vpsrad ymm {k1}{z}, ymm/m256/m32bcst, imm8")]
    vpsrad_ymm_k1z_m256_imm8 = 3933,
    /// <summary>
    /// vpsrad ymm {k1}{z}, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vpsrad ymm_k1z, m32bcst, imm8","vpsrad ymm {k1}{z}, ymm/m256/m32bcst, imm8")]
    vpsrad_ymm_k1z_m32bcst_imm8 = 3934,
    /// <summary>
    /// vpsrad zmm {k1}{z}, zmm, xmm/m128
    /// </summary>
    [Symbol("vpsrad zmm, zmm, xmm","vpsrad zmm {k1}{z}, zmm, xmm/m128")]
    vpsrad_zmm_zmm_xmm = 3935,
    /// <summary>
    /// vpsrad zmm {k1}{z}, zmm, xmm/m128
    /// </summary>
    [Symbol("vpsrad zmm, zmm, m128","vpsrad zmm {k1}{z}, zmm, xmm/m128")]
    vpsrad_zmm_zmm_m128 = 3936,
    /// <summary>
    /// vpsrad zmm {k1}{z}, zmm, xmm/m128
    /// </summary>
    [Symbol("vpsrad zmm_k1z, zmm, xmm","vpsrad zmm {k1}{z}, zmm, xmm/m128")]
    vpsrad_zmm_k1z_zmm_xmm = 3937,
    /// <summary>
    /// vpsrad zmm {k1}{z}, zmm, xmm/m128
    /// </summary>
    [Symbol("vpsrad zmm_k1z, zmm, m128","vpsrad zmm {k1}{z}, zmm, xmm/m128")]
    vpsrad_zmm_k1z_zmm_m128 = 3938,
    /// <summary>
    /// vpsrad zmm {k1}{z}, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vpsrad zmm, zmm, imm8","vpsrad zmm {k1}{z}, zmm/m512/m32bcst, imm8")]
    vpsrad_zmm_zmm_imm8 = 3939,
    /// <summary>
    /// vpsrad zmm {k1}{z}, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vpsrad zmm, m512, imm8","vpsrad zmm {k1}{z}, zmm/m512/m32bcst, imm8")]
    vpsrad_zmm_m512_imm8 = 3940,
    /// <summary>
    /// vpsrad zmm {k1}{z}, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vpsrad zmm, m32bcst, imm8","vpsrad zmm {k1}{z}, zmm/m512/m32bcst, imm8")]
    vpsrad_zmm_m32bcst_imm8 = 3941,
    /// <summary>
    /// vpsrad zmm {k1}{z}, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vpsrad zmm_k1z, zmm, imm8","vpsrad zmm {k1}{z}, zmm/m512/m32bcst, imm8")]
    vpsrad_zmm_k1z_zmm_imm8 = 3942,
    /// <summary>
    /// vpsrad zmm {k1}{z}, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vpsrad zmm_k1z, m512, imm8","vpsrad zmm {k1}{z}, zmm/m512/m32bcst, imm8")]
    vpsrad_zmm_k1z_m512_imm8 = 3943,
    /// <summary>
    /// vpsrad zmm {k1}{z}, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vpsrad zmm_k1z, m32bcst, imm8","vpsrad zmm {k1}{z}, zmm/m512/m32bcst, imm8")]
    vpsrad_zmm_k1z_m32bcst_imm8 = 3944,
    /// <summary>
    /// vpsraq xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsraq xmm, xmm, xmm","vpsraq xmm {k1}{z}, xmm, xmm/m128")]
    vpsraq_xmm_xmm_xmm = 3945,
    /// <summary>
    /// vpsraq xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsraq xmm, xmm, m128","vpsraq xmm {k1}{z}, xmm, xmm/m128")]
    vpsraq_xmm_xmm_m128 = 3946,
    /// <summary>
    /// vpsraq xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsraq xmm_k1z, xmm, xmm","vpsraq xmm {k1}{z}, xmm, xmm/m128")]
    vpsraq_xmm_k1z_xmm_xmm = 3947,
    /// <summary>
    /// vpsraq xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsraq xmm_k1z, xmm, m128","vpsraq xmm {k1}{z}, xmm, xmm/m128")]
    vpsraq_xmm_k1z_xmm_m128 = 3948,
    /// <summary>
    /// vpsraq xmm {k1}{z}, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("vpsraq xmm, xmm, imm8","vpsraq xmm {k1}{z}, xmm/m128/m64bcst, imm8")]
    vpsraq_xmm_xmm_imm8 = 3949,
    /// <summary>
    /// vpsraq xmm {k1}{z}, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("vpsraq xmm, m128, imm8","vpsraq xmm {k1}{z}, xmm/m128/m64bcst, imm8")]
    vpsraq_xmm_m128_imm8 = 3950,
    /// <summary>
    /// vpsraq xmm {k1}{z}, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("vpsraq xmm, m64bcst, imm8","vpsraq xmm {k1}{z}, xmm/m128/m64bcst, imm8")]
    vpsraq_xmm_m64bcst_imm8 = 3951,
    /// <summary>
    /// vpsraq xmm {k1}{z}, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("vpsraq xmm_k1z, xmm, imm8","vpsraq xmm {k1}{z}, xmm/m128/m64bcst, imm8")]
    vpsraq_xmm_k1z_xmm_imm8 = 3952,
    /// <summary>
    /// vpsraq xmm {k1}{z}, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("vpsraq xmm_k1z, m128, imm8","vpsraq xmm {k1}{z}, xmm/m128/m64bcst, imm8")]
    vpsraq_xmm_k1z_m128_imm8 = 3953,
    /// <summary>
    /// vpsraq xmm {k1}{z}, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("vpsraq xmm_k1z, m64bcst, imm8","vpsraq xmm {k1}{z}, xmm/m128/m64bcst, imm8")]
    vpsraq_xmm_k1z_m64bcst_imm8 = 3954,
    /// <summary>
    /// vpsraq ymm {k1}{z}, ymm, xmm/m128
    /// </summary>
    [Symbol("vpsraq ymm, ymm, xmm","vpsraq ymm {k1}{z}, ymm, xmm/m128")]
    vpsraq_ymm_ymm_xmm = 3955,
    /// <summary>
    /// vpsraq ymm {k1}{z}, ymm, xmm/m128
    /// </summary>
    [Symbol("vpsraq ymm, ymm, m128","vpsraq ymm {k1}{z}, ymm, xmm/m128")]
    vpsraq_ymm_ymm_m128 = 3956,
    /// <summary>
    /// vpsraq ymm {k1}{z}, ymm, xmm/m128
    /// </summary>
    [Symbol("vpsraq ymm_k1z, ymm, xmm","vpsraq ymm {k1}{z}, ymm, xmm/m128")]
    vpsraq_ymm_k1z_ymm_xmm = 3957,
    /// <summary>
    /// vpsraq ymm {k1}{z}, ymm, xmm/m128
    /// </summary>
    [Symbol("vpsraq ymm_k1z, ymm, m128","vpsraq ymm {k1}{z}, ymm, xmm/m128")]
    vpsraq_ymm_k1z_ymm_m128 = 3958,
    /// <summary>
    /// vpsraq ymm {k1}{z}, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vpsraq ymm, ymm, imm8","vpsraq ymm {k1}{z}, ymm/m256/m64bcst, imm8")]
    vpsraq_ymm_ymm_imm8 = 3959,
    /// <summary>
    /// vpsraq ymm {k1}{z}, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vpsraq ymm, m256, imm8","vpsraq ymm {k1}{z}, ymm/m256/m64bcst, imm8")]
    vpsraq_ymm_m256_imm8 = 3960,
    /// <summary>
    /// vpsraq ymm {k1}{z}, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vpsraq ymm, m64bcst, imm8","vpsraq ymm {k1}{z}, ymm/m256/m64bcst, imm8")]
    vpsraq_ymm_m64bcst_imm8 = 3961,
    /// <summary>
    /// vpsraq ymm {k1}{z}, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vpsraq ymm_k1z, ymm, imm8","vpsraq ymm {k1}{z}, ymm/m256/m64bcst, imm8")]
    vpsraq_ymm_k1z_ymm_imm8 = 3962,
    /// <summary>
    /// vpsraq ymm {k1}{z}, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vpsraq ymm_k1z, m256, imm8","vpsraq ymm {k1}{z}, ymm/m256/m64bcst, imm8")]
    vpsraq_ymm_k1z_m256_imm8 = 3963,
    /// <summary>
    /// vpsraq ymm {k1}{z}, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vpsraq ymm_k1z, m64bcst, imm8","vpsraq ymm {k1}{z}, ymm/m256/m64bcst, imm8")]
    vpsraq_ymm_k1z_m64bcst_imm8 = 3964,
    /// <summary>
    /// vpsraq zmm {k1}{z}, zmm, xmm/m128
    /// </summary>
    [Symbol("vpsraq zmm, zmm, xmm","vpsraq zmm {k1}{z}, zmm, xmm/m128")]
    vpsraq_zmm_zmm_xmm = 3965,
    /// <summary>
    /// vpsraq zmm {k1}{z}, zmm, xmm/m128
    /// </summary>
    [Symbol("vpsraq zmm, zmm, m128","vpsraq zmm {k1}{z}, zmm, xmm/m128")]
    vpsraq_zmm_zmm_m128 = 3966,
    /// <summary>
    /// vpsraq zmm {k1}{z}, zmm, xmm/m128
    /// </summary>
    [Symbol("vpsraq zmm_k1z, zmm, xmm","vpsraq zmm {k1}{z}, zmm, xmm/m128")]
    vpsraq_zmm_k1z_zmm_xmm = 3967,
    /// <summary>
    /// vpsraq zmm {k1}{z}, zmm, xmm/m128
    /// </summary>
    [Symbol("vpsraq zmm_k1z, zmm, m128","vpsraq zmm {k1}{z}, zmm, xmm/m128")]
    vpsraq_zmm_k1z_zmm_m128 = 3968,
    /// <summary>
    /// vpsraq zmm {k1}{z}, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vpsraq zmm, zmm, imm8","vpsraq zmm {k1}{z}, zmm/m512/m64bcst, imm8")]
    vpsraq_zmm_zmm_imm8 = 3969,
    /// <summary>
    /// vpsraq zmm {k1}{z}, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vpsraq zmm, m512, imm8","vpsraq zmm {k1}{z}, zmm/m512/m64bcst, imm8")]
    vpsraq_zmm_m512_imm8 = 3970,
    /// <summary>
    /// vpsraq zmm {k1}{z}, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vpsraq zmm, m64bcst, imm8","vpsraq zmm {k1}{z}, zmm/m512/m64bcst, imm8")]
    vpsraq_zmm_m64bcst_imm8 = 3971,
    /// <summary>
    /// vpsraq zmm {k1}{z}, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vpsraq zmm_k1z, zmm, imm8","vpsraq zmm {k1}{z}, zmm/m512/m64bcst, imm8")]
    vpsraq_zmm_k1z_zmm_imm8 = 3972,
    /// <summary>
    /// vpsraq zmm {k1}{z}, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vpsraq zmm_k1z, m512, imm8","vpsraq zmm {k1}{z}, zmm/m512/m64bcst, imm8")]
    vpsraq_zmm_k1z_m512_imm8 = 3973,
    /// <summary>
    /// vpsraq zmm {k1}{z}, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vpsraq zmm_k1z, m64bcst, imm8","vpsraq zmm {k1}{z}, zmm/m512/m64bcst, imm8")]
    vpsraq_zmm_k1z_m64bcst_imm8 = 3974,
    /// <summary>
    /// vpsravd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpsravd xmm, xmm, xmm","vpsravd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpsravd_xmm_xmm_xmm = 3975,
    /// <summary>
    /// vpsravd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpsravd xmm, xmm, m128","vpsravd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpsravd_xmm_xmm_m128 = 3976,
    /// <summary>
    /// vpsravd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpsravd xmm, xmm, m32bcst","vpsravd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpsravd_xmm_xmm_m32bcst = 3977,
    /// <summary>
    /// vpsravd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpsravd xmm_k1z, xmm, xmm","vpsravd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpsravd_xmm_k1z_xmm_xmm = 3978,
    /// <summary>
    /// vpsravd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpsravd xmm_k1z, xmm, m128","vpsravd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpsravd_xmm_k1z_xmm_m128 = 3979,
    /// <summary>
    /// vpsravd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpsravd xmm_k1z, xmm, m32bcst","vpsravd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpsravd_xmm_k1z_xmm_m32bcst = 3980,
    /// <summary>
    /// vpsravd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpsravd ymm, ymm, ymm","vpsravd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpsravd_ymm_ymm_ymm = 3981,
    /// <summary>
    /// vpsravd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpsravd ymm, ymm, m256","vpsravd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpsravd_ymm_ymm_m256 = 3982,
    /// <summary>
    /// vpsravd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpsravd ymm, ymm, m32bcst","vpsravd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpsravd_ymm_ymm_m32bcst = 3983,
    /// <summary>
    /// vpsravd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpsravd ymm_k1z, ymm, ymm","vpsravd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpsravd_ymm_k1z_ymm_ymm = 3984,
    /// <summary>
    /// vpsravd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpsravd ymm_k1z, ymm, m256","vpsravd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpsravd_ymm_k1z_ymm_m256 = 3985,
    /// <summary>
    /// vpsravd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpsravd ymm_k1z, ymm, m32bcst","vpsravd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpsravd_ymm_k1z_ymm_m32bcst = 3986,
    /// <summary>
    /// vpsravd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpsravd zmm, zmm, zmm","vpsravd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpsravd_zmm_zmm_zmm = 3987,
    /// <summary>
    /// vpsravd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpsravd zmm, zmm, m512","vpsravd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpsravd_zmm_zmm_m512 = 3988,
    /// <summary>
    /// vpsravd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpsravd zmm, zmm, m32bcst","vpsravd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpsravd_zmm_zmm_m32bcst = 3989,
    /// <summary>
    /// vpsravd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpsravd zmm_k1z, zmm, zmm","vpsravd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpsravd_zmm_k1z_zmm_zmm = 3990,
    /// <summary>
    /// vpsravd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpsravd zmm_k1z, zmm, m512","vpsravd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpsravd_zmm_k1z_zmm_m512 = 3991,
    /// <summary>
    /// vpsravd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpsravd zmm_k1z, zmm, m32bcst","vpsravd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpsravd_zmm_k1z_zmm_m32bcst = 3992,
    /// <summary>
    /// vpsravq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpsravq xmm, xmm, xmm","vpsravq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpsravq_xmm_xmm_xmm = 3993,
    /// <summary>
    /// vpsravq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpsravq xmm, xmm, m128","vpsravq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpsravq_xmm_xmm_m128 = 3994,
    /// <summary>
    /// vpsravq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpsravq xmm, xmm, m64bcst","vpsravq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpsravq_xmm_xmm_m64bcst = 3995,
    /// <summary>
    /// vpsravq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpsravq xmm_k1z, xmm, xmm","vpsravq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpsravq_xmm_k1z_xmm_xmm = 3996,
    /// <summary>
    /// vpsravq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpsravq xmm_k1z, xmm, m128","vpsravq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpsravq_xmm_k1z_xmm_m128 = 3997,
    /// <summary>
    /// vpsravq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpsravq xmm_k1z, xmm, m64bcst","vpsravq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpsravq_xmm_k1z_xmm_m64bcst = 3998,
    /// <summary>
    /// vpsravq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpsravq ymm, ymm, ymm","vpsravq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpsravq_ymm_ymm_ymm = 3999,
    /// <summary>
    /// vpsravq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpsravq ymm, ymm, m256","vpsravq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpsravq_ymm_ymm_m256 = 4000,
    /// <summary>
    /// vpsravq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpsravq ymm, ymm, m64bcst","vpsravq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpsravq_ymm_ymm_m64bcst = 4001,
    /// <summary>
    /// vpsravq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpsravq ymm_k1z, ymm, ymm","vpsravq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpsravq_ymm_k1z_ymm_ymm = 4002,
    /// <summary>
    /// vpsravq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpsravq ymm_k1z, ymm, m256","vpsravq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpsravq_ymm_k1z_ymm_m256 = 4003,
    /// <summary>
    /// vpsravq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpsravq ymm_k1z, ymm, m64bcst","vpsravq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpsravq_ymm_k1z_ymm_m64bcst = 4004,
    /// <summary>
    /// vpsravq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpsravq zmm, zmm, zmm","vpsravq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpsravq_zmm_zmm_zmm = 4005,
    /// <summary>
    /// vpsravq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpsravq zmm, zmm, m512","vpsravq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpsravq_zmm_zmm_m512 = 4006,
    /// <summary>
    /// vpsravq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpsravq zmm, zmm, m64bcst","vpsravq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpsravq_zmm_zmm_m64bcst = 4007,
    /// <summary>
    /// vpsravq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpsravq zmm_k1z, zmm, zmm","vpsravq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpsravq_zmm_k1z_zmm_zmm = 4008,
    /// <summary>
    /// vpsravq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpsravq zmm_k1z, zmm, m512","vpsravq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpsravq_zmm_k1z_zmm_m512 = 4009,
    /// <summary>
    /// vpsravq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpsravq zmm_k1z, zmm, m64bcst","vpsravq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpsravq_zmm_k1z_zmm_m64bcst = 4010,
    /// <summary>
    /// vpsravw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsravw xmm, xmm, xmm","vpsravw xmm {k1}{z}, xmm, xmm/m128")]
    vpsravw_xmm_xmm_xmm = 4011,
    /// <summary>
    /// vpsravw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsravw xmm, xmm, m128","vpsravw xmm {k1}{z}, xmm, xmm/m128")]
    vpsravw_xmm_xmm_m128 = 4012,
    /// <summary>
    /// vpsravw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsravw xmm_k1z, xmm, xmm","vpsravw xmm {k1}{z}, xmm, xmm/m128")]
    vpsravw_xmm_k1z_xmm_xmm = 4013,
    /// <summary>
    /// vpsravw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsravw xmm_k1z, xmm, m128","vpsravw xmm {k1}{z}, xmm, xmm/m128")]
    vpsravw_xmm_k1z_xmm_m128 = 4014,
    /// <summary>
    /// vpsravw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsravw ymm, ymm, ymm","vpsravw ymm {k1}{z}, ymm, ymm/m256")]
    vpsravw_ymm_ymm_ymm = 4015,
    /// <summary>
    /// vpsravw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsravw ymm, ymm, m256","vpsravw ymm {k1}{z}, ymm, ymm/m256")]
    vpsravw_ymm_ymm_m256 = 4016,
    /// <summary>
    /// vpsravw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsravw ymm_k1z, ymm, ymm","vpsravw ymm {k1}{z}, ymm, ymm/m256")]
    vpsravw_ymm_k1z_ymm_ymm = 4017,
    /// <summary>
    /// vpsravw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsravw ymm_k1z, ymm, m256","vpsravw ymm {k1}{z}, ymm, ymm/m256")]
    vpsravw_ymm_k1z_ymm_m256 = 4018,
    /// <summary>
    /// vpsravw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpsravw zmm, zmm, zmm","vpsravw zmm {k1}{z}, zmm, zmm/m512")]
    vpsravw_zmm_zmm_zmm = 4019,
    /// <summary>
    /// vpsravw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpsravw zmm, zmm, m512","vpsravw zmm {k1}{z}, zmm, zmm/m512")]
    vpsravw_zmm_zmm_m512 = 4020,
    /// <summary>
    /// vpsravw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpsravw zmm_k1z, zmm, zmm","vpsravw zmm {k1}{z}, zmm, zmm/m512")]
    vpsravw_zmm_k1z_zmm_zmm = 4021,
    /// <summary>
    /// vpsravw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpsravw zmm_k1z, zmm, m512","vpsravw zmm {k1}{z}, zmm, zmm/m512")]
    vpsravw_zmm_k1z_zmm_m512 = 4022,
    /// <summary>
    /// vpsraw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsraw xmm, xmm, xmm","vpsraw xmm {k1}{z}, xmm, xmm/m128")]
    vpsraw_xmm_xmm_xmm = 4023,
    /// <summary>
    /// vpsraw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsraw xmm, xmm, m128","vpsraw xmm {k1}{z}, xmm, xmm/m128")]
    vpsraw_xmm_xmm_m128 = 4024,
    /// <summary>
    /// vpsraw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsraw xmm_k1z, xmm, xmm","vpsraw xmm {k1}{z}, xmm, xmm/m128")]
    vpsraw_xmm_k1z_xmm_xmm = 4025,
    /// <summary>
    /// vpsraw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsraw xmm_k1z, xmm, m128","vpsraw xmm {k1}{z}, xmm, xmm/m128")]
    vpsraw_xmm_k1z_xmm_m128 = 4026,
    /// <summary>
    /// vpsraw xmm {k1}{z}, xmm/m128, imm8
    /// </summary>
    [Symbol("vpsraw xmm, xmm, imm8","vpsraw xmm {k1}{z}, xmm/m128, imm8")]
    vpsraw_xmm_xmm_imm8 = 4027,
    /// <summary>
    /// vpsraw xmm {k1}{z}, xmm/m128, imm8
    /// </summary>
    [Symbol("vpsraw xmm, m128, imm8","vpsraw xmm {k1}{z}, xmm/m128, imm8")]
    vpsraw_xmm_m128_imm8 = 4028,
    /// <summary>
    /// vpsraw xmm {k1}{z}, xmm/m128, imm8
    /// </summary>
    [Symbol("vpsraw xmm_k1z, xmm, imm8","vpsraw xmm {k1}{z}, xmm/m128, imm8")]
    vpsraw_xmm_k1z_xmm_imm8 = 4029,
    /// <summary>
    /// vpsraw xmm {k1}{z}, xmm/m128, imm8
    /// </summary>
    [Symbol("vpsraw xmm_k1z, m128, imm8","vpsraw xmm {k1}{z}, xmm/m128, imm8")]
    vpsraw_xmm_k1z_m128_imm8 = 4030,
    /// <summary>
    /// vpsraw ymm {k1}{z}, ymm, xmm/m128
    /// </summary>
    [Symbol("vpsraw ymm, ymm, xmm","vpsraw ymm {k1}{z}, ymm, xmm/m128")]
    vpsraw_ymm_ymm_xmm = 4031,
    /// <summary>
    /// vpsraw ymm {k1}{z}, ymm, xmm/m128
    /// </summary>
    [Symbol("vpsraw ymm, ymm, m128","vpsraw ymm {k1}{z}, ymm, xmm/m128")]
    vpsraw_ymm_ymm_m128 = 4032,
    /// <summary>
    /// vpsraw ymm {k1}{z}, ymm, xmm/m128
    /// </summary>
    [Symbol("vpsraw ymm_k1z, ymm, xmm","vpsraw ymm {k1}{z}, ymm, xmm/m128")]
    vpsraw_ymm_k1z_ymm_xmm = 4033,
    /// <summary>
    /// vpsraw ymm {k1}{z}, ymm, xmm/m128
    /// </summary>
    [Symbol("vpsraw ymm_k1z, ymm, m128","vpsraw ymm {k1}{z}, ymm, xmm/m128")]
    vpsraw_ymm_k1z_ymm_m128 = 4034,
    /// <summary>
    /// vpsraw ymm {k1}{z}, ymm/m256, imm8
    /// </summary>
    [Symbol("vpsraw ymm, ymm, imm8","vpsraw ymm {k1}{z}, ymm/m256, imm8")]
    vpsraw_ymm_ymm_imm8 = 4035,
    /// <summary>
    /// vpsraw ymm {k1}{z}, ymm/m256, imm8
    /// </summary>
    [Symbol("vpsraw ymm, m256, imm8","vpsraw ymm {k1}{z}, ymm/m256, imm8")]
    vpsraw_ymm_m256_imm8 = 4036,
    /// <summary>
    /// vpsraw ymm {k1}{z}, ymm/m256, imm8
    /// </summary>
    [Symbol("vpsraw ymm_k1z, ymm, imm8","vpsraw ymm {k1}{z}, ymm/m256, imm8")]
    vpsraw_ymm_k1z_ymm_imm8 = 4037,
    /// <summary>
    /// vpsraw ymm {k1}{z}, ymm/m256, imm8
    /// </summary>
    [Symbol("vpsraw ymm_k1z, m256, imm8","vpsraw ymm {k1}{z}, ymm/m256, imm8")]
    vpsraw_ymm_k1z_m256_imm8 = 4038,
    /// <summary>
    /// vpsraw zmm {k1}{z}, zmm, xmm/m128
    /// </summary>
    [Symbol("vpsraw zmm, zmm, xmm","vpsraw zmm {k1}{z}, zmm, xmm/m128")]
    vpsraw_zmm_zmm_xmm = 4039,
    /// <summary>
    /// vpsraw zmm {k1}{z}, zmm, xmm/m128
    /// </summary>
    [Symbol("vpsraw zmm, zmm, m128","vpsraw zmm {k1}{z}, zmm, xmm/m128")]
    vpsraw_zmm_zmm_m128 = 4040,
    /// <summary>
    /// vpsraw zmm {k1}{z}, zmm, xmm/m128
    /// </summary>
    [Symbol("vpsraw zmm_k1z, zmm, xmm","vpsraw zmm {k1}{z}, zmm, xmm/m128")]
    vpsraw_zmm_k1z_zmm_xmm = 4041,
    /// <summary>
    /// vpsraw zmm {k1}{z}, zmm, xmm/m128
    /// </summary>
    [Symbol("vpsraw zmm_k1z, zmm, m128","vpsraw zmm {k1}{z}, zmm, xmm/m128")]
    vpsraw_zmm_k1z_zmm_m128 = 4042,
    /// <summary>
    /// vpsraw zmm {k1}{z}, zmm/m512, imm8
    /// </summary>
    [Symbol("vpsraw zmm, zmm, imm8","vpsraw zmm {k1}{z}, zmm/m512, imm8")]
    vpsraw_zmm_zmm_imm8 = 4043,
    /// <summary>
    /// vpsraw zmm {k1}{z}, zmm/m512, imm8
    /// </summary>
    [Symbol("vpsraw zmm, m512, imm8","vpsraw zmm {k1}{z}, zmm/m512, imm8")]
    vpsraw_zmm_m512_imm8 = 4044,
    /// <summary>
    /// vpsraw zmm {k1}{z}, zmm/m512, imm8
    /// </summary>
    [Symbol("vpsraw zmm_k1z, zmm, imm8","vpsraw zmm {k1}{z}, zmm/m512, imm8")]
    vpsraw_zmm_k1z_zmm_imm8 = 4045,
    /// <summary>
    /// vpsraw zmm {k1}{z}, zmm/m512, imm8
    /// </summary>
    [Symbol("vpsraw zmm_k1z, m512, imm8","vpsraw zmm {k1}{z}, zmm/m512, imm8")]
    vpsraw_zmm_k1z_m512_imm8 = 4046,
    /// <summary>
    /// vpsrld xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsrld xmm, xmm, xmm","vpsrld xmm {k1}{z}, xmm, xmm/m128")]
    vpsrld_xmm_xmm_xmm = 4047,
    /// <summary>
    /// vpsrld xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsrld xmm, xmm, m128","vpsrld xmm {k1}{z}, xmm, xmm/m128")]
    vpsrld_xmm_xmm_m128 = 4048,
    /// <summary>
    /// vpsrld xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsrld xmm_k1z, xmm, xmm","vpsrld xmm {k1}{z}, xmm, xmm/m128")]
    vpsrld_xmm_k1z_xmm_xmm = 4049,
    /// <summary>
    /// vpsrld xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsrld xmm_k1z, xmm, m128","vpsrld xmm {k1}{z}, xmm, xmm/m128")]
    vpsrld_xmm_k1z_xmm_m128 = 4050,
    /// <summary>
    /// vpsrld xmm {k1}{z}, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vpsrld xmm, xmm, imm8","vpsrld xmm {k1}{z}, xmm/m128/m32bcst, imm8")]
    vpsrld_xmm_xmm_imm8 = 4051,
    /// <summary>
    /// vpsrld xmm {k1}{z}, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vpsrld xmm, m128, imm8","vpsrld xmm {k1}{z}, xmm/m128/m32bcst, imm8")]
    vpsrld_xmm_m128_imm8 = 4052,
    /// <summary>
    /// vpsrld xmm {k1}{z}, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vpsrld xmm, m32bcst, imm8","vpsrld xmm {k1}{z}, xmm/m128/m32bcst, imm8")]
    vpsrld_xmm_m32bcst_imm8 = 4053,
    /// <summary>
    /// vpsrld xmm {k1}{z}, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vpsrld xmm_k1z, xmm, imm8","vpsrld xmm {k1}{z}, xmm/m128/m32bcst, imm8")]
    vpsrld_xmm_k1z_xmm_imm8 = 4054,
    /// <summary>
    /// vpsrld xmm {k1}{z}, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vpsrld xmm_k1z, m128, imm8","vpsrld xmm {k1}{z}, xmm/m128/m32bcst, imm8")]
    vpsrld_xmm_k1z_m128_imm8 = 4055,
    /// <summary>
    /// vpsrld xmm {k1}{z}, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vpsrld xmm_k1z, m32bcst, imm8","vpsrld xmm {k1}{z}, xmm/m128/m32bcst, imm8")]
    vpsrld_xmm_k1z_m32bcst_imm8 = 4056,
    /// <summary>
    /// vpsrld ymm {k1}{z}, ymm, xmm/m128
    /// </summary>
    [Symbol("vpsrld ymm, ymm, xmm","vpsrld ymm {k1}{z}, ymm, xmm/m128")]
    vpsrld_ymm_ymm_xmm = 4057,
    /// <summary>
    /// vpsrld ymm {k1}{z}, ymm, xmm/m128
    /// </summary>
    [Symbol("vpsrld ymm, ymm, m128","vpsrld ymm {k1}{z}, ymm, xmm/m128")]
    vpsrld_ymm_ymm_m128 = 4058,
    /// <summary>
    /// vpsrld ymm {k1}{z}, ymm, xmm/m128
    /// </summary>
    [Symbol("vpsrld ymm_k1z, ymm, xmm","vpsrld ymm {k1}{z}, ymm, xmm/m128")]
    vpsrld_ymm_k1z_ymm_xmm = 4059,
    /// <summary>
    /// vpsrld ymm {k1}{z}, ymm, xmm/m128
    /// </summary>
    [Symbol("vpsrld ymm_k1z, ymm, m128","vpsrld ymm {k1}{z}, ymm, xmm/m128")]
    vpsrld_ymm_k1z_ymm_m128 = 4060,
    /// <summary>
    /// vpsrld ymm {k1}{z}, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vpsrld ymm, ymm, imm8","vpsrld ymm {k1}{z}, ymm/m256/m32bcst, imm8")]
    vpsrld_ymm_ymm_imm8 = 4061,
    /// <summary>
    /// vpsrld ymm {k1}{z}, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vpsrld ymm, m256, imm8","vpsrld ymm {k1}{z}, ymm/m256/m32bcst, imm8")]
    vpsrld_ymm_m256_imm8 = 4062,
    /// <summary>
    /// vpsrld ymm {k1}{z}, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vpsrld ymm, m32bcst, imm8","vpsrld ymm {k1}{z}, ymm/m256/m32bcst, imm8")]
    vpsrld_ymm_m32bcst_imm8 = 4063,
    /// <summary>
    /// vpsrld ymm {k1}{z}, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vpsrld ymm_k1z, ymm, imm8","vpsrld ymm {k1}{z}, ymm/m256/m32bcst, imm8")]
    vpsrld_ymm_k1z_ymm_imm8 = 4064,
    /// <summary>
    /// vpsrld ymm {k1}{z}, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vpsrld ymm_k1z, m256, imm8","vpsrld ymm {k1}{z}, ymm/m256/m32bcst, imm8")]
    vpsrld_ymm_k1z_m256_imm8 = 4065,
    /// <summary>
    /// vpsrld ymm {k1}{z}, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vpsrld ymm_k1z, m32bcst, imm8","vpsrld ymm {k1}{z}, ymm/m256/m32bcst, imm8")]
    vpsrld_ymm_k1z_m32bcst_imm8 = 4066,
    /// <summary>
    /// vpsrld zmm {k1}{z}, zmm, xmm/m128
    /// </summary>
    [Symbol("vpsrld zmm, zmm, xmm","vpsrld zmm {k1}{z}, zmm, xmm/m128")]
    vpsrld_zmm_zmm_xmm = 4067,
    /// <summary>
    /// vpsrld zmm {k1}{z}, zmm, xmm/m128
    /// </summary>
    [Symbol("vpsrld zmm, zmm, m128","vpsrld zmm {k1}{z}, zmm, xmm/m128")]
    vpsrld_zmm_zmm_m128 = 4068,
    /// <summary>
    /// vpsrld zmm {k1}{z}, zmm, xmm/m128
    /// </summary>
    [Symbol("vpsrld zmm_k1z, zmm, xmm","vpsrld zmm {k1}{z}, zmm, xmm/m128")]
    vpsrld_zmm_k1z_zmm_xmm = 4069,
    /// <summary>
    /// vpsrld zmm {k1}{z}, zmm, xmm/m128
    /// </summary>
    [Symbol("vpsrld zmm_k1z, zmm, m128","vpsrld zmm {k1}{z}, zmm, xmm/m128")]
    vpsrld_zmm_k1z_zmm_m128 = 4070,
    /// <summary>
    /// vpsrld zmm {k1}{z}, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vpsrld zmm, zmm, imm8","vpsrld zmm {k1}{z}, zmm/m512/m32bcst, imm8")]
    vpsrld_zmm_zmm_imm8 = 4071,
    /// <summary>
    /// vpsrld zmm {k1}{z}, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vpsrld zmm, m512, imm8","vpsrld zmm {k1}{z}, zmm/m512/m32bcst, imm8")]
    vpsrld_zmm_m512_imm8 = 4072,
    /// <summary>
    /// vpsrld zmm {k1}{z}, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vpsrld zmm, m32bcst, imm8","vpsrld zmm {k1}{z}, zmm/m512/m32bcst, imm8")]
    vpsrld_zmm_m32bcst_imm8 = 4073,
    /// <summary>
    /// vpsrld zmm {k1}{z}, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vpsrld zmm_k1z, zmm, imm8","vpsrld zmm {k1}{z}, zmm/m512/m32bcst, imm8")]
    vpsrld_zmm_k1z_zmm_imm8 = 4074,
    /// <summary>
    /// vpsrld zmm {k1}{z}, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vpsrld zmm_k1z, m512, imm8","vpsrld zmm {k1}{z}, zmm/m512/m32bcst, imm8")]
    vpsrld_zmm_k1z_m512_imm8 = 4075,
    /// <summary>
    /// vpsrld zmm {k1}{z}, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vpsrld zmm_k1z, m32bcst, imm8","vpsrld zmm {k1}{z}, zmm/m512/m32bcst, imm8")]
    vpsrld_zmm_k1z_m32bcst_imm8 = 4076,
    /// <summary>
    /// vpsrlq xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsrlq xmm, xmm, xmm","vpsrlq xmm {k1}{z}, xmm, xmm/m128")]
    vpsrlq_xmm_xmm_xmm = 4077,
    /// <summary>
    /// vpsrlq xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsrlq xmm, xmm, m128","vpsrlq xmm {k1}{z}, xmm, xmm/m128")]
    vpsrlq_xmm_xmm_m128 = 4078,
    /// <summary>
    /// vpsrlq xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsrlq xmm_k1z, xmm, xmm","vpsrlq xmm {k1}{z}, xmm, xmm/m128")]
    vpsrlq_xmm_k1z_xmm_xmm = 4079,
    /// <summary>
    /// vpsrlq xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsrlq xmm_k1z, xmm, m128","vpsrlq xmm {k1}{z}, xmm, xmm/m128")]
    vpsrlq_xmm_k1z_xmm_m128 = 4080,
    /// <summary>
    /// vpsrlq xmm {k1}{z}, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("vpsrlq xmm, xmm, imm8","vpsrlq xmm {k1}{z}, xmm/m128/m64bcst, imm8")]
    vpsrlq_xmm_xmm_imm8 = 4081,
    /// <summary>
    /// vpsrlq xmm {k1}{z}, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("vpsrlq xmm, m128, imm8","vpsrlq xmm {k1}{z}, xmm/m128/m64bcst, imm8")]
    vpsrlq_xmm_m128_imm8 = 4082,
    /// <summary>
    /// vpsrlq xmm {k1}{z}, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("vpsrlq xmm, m64bcst, imm8","vpsrlq xmm {k1}{z}, xmm/m128/m64bcst, imm8")]
    vpsrlq_xmm_m64bcst_imm8 = 4083,
    /// <summary>
    /// vpsrlq xmm {k1}{z}, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("vpsrlq xmm_k1z, xmm, imm8","vpsrlq xmm {k1}{z}, xmm/m128/m64bcst, imm8")]
    vpsrlq_xmm_k1z_xmm_imm8 = 4084,
    /// <summary>
    /// vpsrlq xmm {k1}{z}, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("vpsrlq xmm_k1z, m128, imm8","vpsrlq xmm {k1}{z}, xmm/m128/m64bcst, imm8")]
    vpsrlq_xmm_k1z_m128_imm8 = 4085,
    /// <summary>
    /// vpsrlq xmm {k1}{z}, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("vpsrlq xmm_k1z, m64bcst, imm8","vpsrlq xmm {k1}{z}, xmm/m128/m64bcst, imm8")]
    vpsrlq_xmm_k1z_m64bcst_imm8 = 4086,
    /// <summary>
    /// vpsrlq ymm {k1}{z}, ymm, xmm/m128
    /// </summary>
    [Symbol("vpsrlq ymm, ymm, xmm","vpsrlq ymm {k1}{z}, ymm, xmm/m128")]
    vpsrlq_ymm_ymm_xmm = 4087,
    /// <summary>
    /// vpsrlq ymm {k1}{z}, ymm, xmm/m128
    /// </summary>
    [Symbol("vpsrlq ymm, ymm, m128","vpsrlq ymm {k1}{z}, ymm, xmm/m128")]
    vpsrlq_ymm_ymm_m128 = 4088,
    /// <summary>
    /// vpsrlq ymm {k1}{z}, ymm, xmm/m128
    /// </summary>
    [Symbol("vpsrlq ymm_k1z, ymm, xmm","vpsrlq ymm {k1}{z}, ymm, xmm/m128")]
    vpsrlq_ymm_k1z_ymm_xmm = 4089,
    /// <summary>
    /// vpsrlq ymm {k1}{z}, ymm, xmm/m128
    /// </summary>
    [Symbol("vpsrlq ymm_k1z, ymm, m128","vpsrlq ymm {k1}{z}, ymm, xmm/m128")]
    vpsrlq_ymm_k1z_ymm_m128 = 4090,
    /// <summary>
    /// vpsrlq ymm {k1}{z}, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vpsrlq ymm, ymm, imm8","vpsrlq ymm {k1}{z}, ymm/m256/m64bcst, imm8")]
    vpsrlq_ymm_ymm_imm8 = 4091,
    /// <summary>
    /// vpsrlq ymm {k1}{z}, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vpsrlq ymm, m256, imm8","vpsrlq ymm {k1}{z}, ymm/m256/m64bcst, imm8")]
    vpsrlq_ymm_m256_imm8 = 4092,
    /// <summary>
    /// vpsrlq ymm {k1}{z}, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vpsrlq ymm, m64bcst, imm8","vpsrlq ymm {k1}{z}, ymm/m256/m64bcst, imm8")]
    vpsrlq_ymm_m64bcst_imm8 = 4093,
    /// <summary>
    /// vpsrlq ymm {k1}{z}, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vpsrlq ymm_k1z, ymm, imm8","vpsrlq ymm {k1}{z}, ymm/m256/m64bcst, imm8")]
    vpsrlq_ymm_k1z_ymm_imm8 = 4094,
    /// <summary>
    /// vpsrlq ymm {k1}{z}, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vpsrlq ymm_k1z, m256, imm8","vpsrlq ymm {k1}{z}, ymm/m256/m64bcst, imm8")]
    vpsrlq_ymm_k1z_m256_imm8 = 4095,
    /// <summary>
    /// vpsrlq ymm {k1}{z}, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vpsrlq ymm_k1z, m64bcst, imm8","vpsrlq ymm {k1}{z}, ymm/m256/m64bcst, imm8")]
    vpsrlq_ymm_k1z_m64bcst_imm8 = 4096,
    /// <summary>
    /// vpsrlq zmm {k1}{z}, zmm, xmm/m128
    /// </summary>
    [Symbol("vpsrlq zmm, zmm, xmm","vpsrlq zmm {k1}{z}, zmm, xmm/m128")]
    vpsrlq_zmm_zmm_xmm = 4097,
    /// <summary>
    /// vpsrlq zmm {k1}{z}, zmm, xmm/m128
    /// </summary>
    [Symbol("vpsrlq zmm, zmm, m128","vpsrlq zmm {k1}{z}, zmm, xmm/m128")]
    vpsrlq_zmm_zmm_m128 = 4098,
    /// <summary>
    /// vpsrlq zmm {k1}{z}, zmm, xmm/m128
    /// </summary>
    [Symbol("vpsrlq zmm_k1z, zmm, xmm","vpsrlq zmm {k1}{z}, zmm, xmm/m128")]
    vpsrlq_zmm_k1z_zmm_xmm = 4099,
    /// <summary>
    /// vpsrlq zmm {k1}{z}, zmm, xmm/m128
    /// </summary>
    [Symbol("vpsrlq zmm_k1z, zmm, m128","vpsrlq zmm {k1}{z}, zmm, xmm/m128")]
    vpsrlq_zmm_k1z_zmm_m128 = 4100,
    /// <summary>
    /// vpsrlq zmm {k1}{z}, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vpsrlq zmm, zmm, imm8","vpsrlq zmm {k1}{z}, zmm/m512/m64bcst, imm8")]
    vpsrlq_zmm_zmm_imm8 = 4101,
    /// <summary>
    /// vpsrlq zmm {k1}{z}, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vpsrlq zmm, m512, imm8","vpsrlq zmm {k1}{z}, zmm/m512/m64bcst, imm8")]
    vpsrlq_zmm_m512_imm8 = 4102,
    /// <summary>
    /// vpsrlq zmm {k1}{z}, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vpsrlq zmm, m64bcst, imm8","vpsrlq zmm {k1}{z}, zmm/m512/m64bcst, imm8")]
    vpsrlq_zmm_m64bcst_imm8 = 4103,
    /// <summary>
    /// vpsrlq zmm {k1}{z}, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vpsrlq zmm_k1z, zmm, imm8","vpsrlq zmm {k1}{z}, zmm/m512/m64bcst, imm8")]
    vpsrlq_zmm_k1z_zmm_imm8 = 4104,
    /// <summary>
    /// vpsrlq zmm {k1}{z}, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vpsrlq zmm_k1z, m512, imm8","vpsrlq zmm {k1}{z}, zmm/m512/m64bcst, imm8")]
    vpsrlq_zmm_k1z_m512_imm8 = 4105,
    /// <summary>
    /// vpsrlq zmm {k1}{z}, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vpsrlq zmm_k1z, m64bcst, imm8","vpsrlq zmm {k1}{z}, zmm/m512/m64bcst, imm8")]
    vpsrlq_zmm_k1z_m64bcst_imm8 = 4106,
    /// <summary>
    /// vpsrlvd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpsrlvd xmm, xmm, xmm","vpsrlvd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpsrlvd_xmm_xmm_xmm = 4107,
    /// <summary>
    /// vpsrlvd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpsrlvd xmm, xmm, m128","vpsrlvd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpsrlvd_xmm_xmm_m128 = 4108,
    /// <summary>
    /// vpsrlvd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpsrlvd xmm, xmm, m32bcst","vpsrlvd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpsrlvd_xmm_xmm_m32bcst = 4109,
    /// <summary>
    /// vpsrlvd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpsrlvd xmm_k1z, xmm, xmm","vpsrlvd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpsrlvd_xmm_k1z_xmm_xmm = 4110,
    /// <summary>
    /// vpsrlvd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpsrlvd xmm_k1z, xmm, m128","vpsrlvd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpsrlvd_xmm_k1z_xmm_m128 = 4111,
    /// <summary>
    /// vpsrlvd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpsrlvd xmm_k1z, xmm, m32bcst","vpsrlvd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpsrlvd_xmm_k1z_xmm_m32bcst = 4112,
    /// <summary>
    /// vpsrlvd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpsrlvd ymm, ymm, ymm","vpsrlvd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpsrlvd_ymm_ymm_ymm = 4113,
    /// <summary>
    /// vpsrlvd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpsrlvd ymm, ymm, m256","vpsrlvd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpsrlvd_ymm_ymm_m256 = 4114,
    /// <summary>
    /// vpsrlvd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpsrlvd ymm, ymm, m32bcst","vpsrlvd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpsrlvd_ymm_ymm_m32bcst = 4115,
    /// <summary>
    /// vpsrlvd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpsrlvd ymm_k1z, ymm, ymm","vpsrlvd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpsrlvd_ymm_k1z_ymm_ymm = 4116,
    /// <summary>
    /// vpsrlvd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpsrlvd ymm_k1z, ymm, m256","vpsrlvd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpsrlvd_ymm_k1z_ymm_m256 = 4117,
    /// <summary>
    /// vpsrlvd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpsrlvd ymm_k1z, ymm, m32bcst","vpsrlvd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpsrlvd_ymm_k1z_ymm_m32bcst = 4118,
    /// <summary>
    /// vpsrlvd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpsrlvd zmm, zmm, zmm","vpsrlvd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpsrlvd_zmm_zmm_zmm = 4119,
    /// <summary>
    /// vpsrlvd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpsrlvd zmm, zmm, m512","vpsrlvd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpsrlvd_zmm_zmm_m512 = 4120,
    /// <summary>
    /// vpsrlvd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpsrlvd zmm, zmm, m32bcst","vpsrlvd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpsrlvd_zmm_zmm_m32bcst = 4121,
    /// <summary>
    /// vpsrlvd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpsrlvd zmm_k1z, zmm, zmm","vpsrlvd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpsrlvd_zmm_k1z_zmm_zmm = 4122,
    /// <summary>
    /// vpsrlvd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpsrlvd zmm_k1z, zmm, m512","vpsrlvd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpsrlvd_zmm_k1z_zmm_m512 = 4123,
    /// <summary>
    /// vpsrlvd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpsrlvd zmm_k1z, zmm, m32bcst","vpsrlvd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpsrlvd_zmm_k1z_zmm_m32bcst = 4124,
    /// <summary>
    /// vpsrlvq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpsrlvq xmm, xmm, xmm","vpsrlvq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpsrlvq_xmm_xmm_xmm = 4125,
    /// <summary>
    /// vpsrlvq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpsrlvq xmm, xmm, m128","vpsrlvq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpsrlvq_xmm_xmm_m128 = 4126,
    /// <summary>
    /// vpsrlvq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpsrlvq xmm, xmm, m64bcst","vpsrlvq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpsrlvq_xmm_xmm_m64bcst = 4127,
    /// <summary>
    /// vpsrlvq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpsrlvq xmm_k1z, xmm, xmm","vpsrlvq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpsrlvq_xmm_k1z_xmm_xmm = 4128,
    /// <summary>
    /// vpsrlvq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpsrlvq xmm_k1z, xmm, m128","vpsrlvq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpsrlvq_xmm_k1z_xmm_m128 = 4129,
    /// <summary>
    /// vpsrlvq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpsrlvq xmm_k1z, xmm, m64bcst","vpsrlvq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpsrlvq_xmm_k1z_xmm_m64bcst = 4130,
    /// <summary>
    /// vpsrlvq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpsrlvq ymm, ymm, ymm","vpsrlvq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpsrlvq_ymm_ymm_ymm = 4131,
    /// <summary>
    /// vpsrlvq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpsrlvq ymm, ymm, m256","vpsrlvq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpsrlvq_ymm_ymm_m256 = 4132,
    /// <summary>
    /// vpsrlvq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpsrlvq ymm, ymm, m64bcst","vpsrlvq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpsrlvq_ymm_ymm_m64bcst = 4133,
    /// <summary>
    /// vpsrlvq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpsrlvq ymm_k1z, ymm, ymm","vpsrlvq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpsrlvq_ymm_k1z_ymm_ymm = 4134,
    /// <summary>
    /// vpsrlvq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpsrlvq ymm_k1z, ymm, m256","vpsrlvq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpsrlvq_ymm_k1z_ymm_m256 = 4135,
    /// <summary>
    /// vpsrlvq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpsrlvq ymm_k1z, ymm, m64bcst","vpsrlvq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpsrlvq_ymm_k1z_ymm_m64bcst = 4136,
    /// <summary>
    /// vpsrlvq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpsrlvq zmm, zmm, zmm","vpsrlvq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpsrlvq_zmm_zmm_zmm = 4137,
    /// <summary>
    /// vpsrlvq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpsrlvq zmm, zmm, m512","vpsrlvq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpsrlvq_zmm_zmm_m512 = 4138,
    /// <summary>
    /// vpsrlvq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpsrlvq zmm, zmm, m64bcst","vpsrlvq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpsrlvq_zmm_zmm_m64bcst = 4139,
    /// <summary>
    /// vpsrlvq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpsrlvq zmm_k1z, zmm, zmm","vpsrlvq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpsrlvq_zmm_k1z_zmm_zmm = 4140,
    /// <summary>
    /// vpsrlvq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpsrlvq zmm_k1z, zmm, m512","vpsrlvq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpsrlvq_zmm_k1z_zmm_m512 = 4141,
    /// <summary>
    /// vpsrlvq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpsrlvq zmm_k1z, zmm, m64bcst","vpsrlvq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpsrlvq_zmm_k1z_zmm_m64bcst = 4142,
    /// <summary>
    /// vpsrlvw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsrlvw xmm, xmm, xmm","vpsrlvw xmm {k1}{z}, xmm, xmm/m128")]
    vpsrlvw_xmm_xmm_xmm = 4143,
    /// <summary>
    /// vpsrlvw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsrlvw xmm, xmm, m128","vpsrlvw xmm {k1}{z}, xmm, xmm/m128")]
    vpsrlvw_xmm_xmm_m128 = 4144,
    /// <summary>
    /// vpsrlvw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsrlvw xmm_k1z, xmm, xmm","vpsrlvw xmm {k1}{z}, xmm, xmm/m128")]
    vpsrlvw_xmm_k1z_xmm_xmm = 4145,
    /// <summary>
    /// vpsrlvw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsrlvw xmm_k1z, xmm, m128","vpsrlvw xmm {k1}{z}, xmm, xmm/m128")]
    vpsrlvw_xmm_k1z_xmm_m128 = 4146,
    /// <summary>
    /// vpsrlvw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsrlvw ymm, ymm, ymm","vpsrlvw ymm {k1}{z}, ymm, ymm/m256")]
    vpsrlvw_ymm_ymm_ymm = 4147,
    /// <summary>
    /// vpsrlvw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsrlvw ymm, ymm, m256","vpsrlvw ymm {k1}{z}, ymm, ymm/m256")]
    vpsrlvw_ymm_ymm_m256 = 4148,
    /// <summary>
    /// vpsrlvw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsrlvw ymm_k1z, ymm, ymm","vpsrlvw ymm {k1}{z}, ymm, ymm/m256")]
    vpsrlvw_ymm_k1z_ymm_ymm = 4149,
    /// <summary>
    /// vpsrlvw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsrlvw ymm_k1z, ymm, m256","vpsrlvw ymm {k1}{z}, ymm, ymm/m256")]
    vpsrlvw_ymm_k1z_ymm_m256 = 4150,
    /// <summary>
    /// vpsrlvw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpsrlvw zmm, zmm, zmm","vpsrlvw zmm {k1}{z}, zmm, zmm/m512")]
    vpsrlvw_zmm_zmm_zmm = 4151,
    /// <summary>
    /// vpsrlvw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpsrlvw zmm, zmm, m512","vpsrlvw zmm {k1}{z}, zmm, zmm/m512")]
    vpsrlvw_zmm_zmm_m512 = 4152,
    /// <summary>
    /// vpsrlvw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpsrlvw zmm_k1z, zmm, zmm","vpsrlvw zmm {k1}{z}, zmm, zmm/m512")]
    vpsrlvw_zmm_k1z_zmm_zmm = 4153,
    /// <summary>
    /// vpsrlvw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpsrlvw zmm_k1z, zmm, m512","vpsrlvw zmm {k1}{z}, zmm, zmm/m512")]
    vpsrlvw_zmm_k1z_zmm_m512 = 4154,
    /// <summary>
    /// vpsrlw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsrlw xmm, xmm, xmm","vpsrlw xmm {k1}{z}, xmm, xmm/m128")]
    vpsrlw_xmm_xmm_xmm = 4155,
    /// <summary>
    /// vpsrlw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsrlw xmm, xmm, m128","vpsrlw xmm {k1}{z}, xmm, xmm/m128")]
    vpsrlw_xmm_xmm_m128 = 4156,
    /// <summary>
    /// vpsrlw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsrlw xmm_k1z, xmm, xmm","vpsrlw xmm {k1}{z}, xmm, xmm/m128")]
    vpsrlw_xmm_k1z_xmm_xmm = 4157,
    /// <summary>
    /// vpsrlw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsrlw xmm_k1z, xmm, m128","vpsrlw xmm {k1}{z}, xmm, xmm/m128")]
    vpsrlw_xmm_k1z_xmm_m128 = 4158,
    /// <summary>
    /// vpsrlw xmm {k1}{z}, xmm/m128, imm8
    /// </summary>
    [Symbol("vpsrlw xmm, xmm, imm8","vpsrlw xmm {k1}{z}, xmm/m128, imm8")]
    vpsrlw_xmm_xmm_imm8 = 4159,
    /// <summary>
    /// vpsrlw xmm {k1}{z}, xmm/m128, imm8
    /// </summary>
    [Symbol("vpsrlw xmm, m128, imm8","vpsrlw xmm {k1}{z}, xmm/m128, imm8")]
    vpsrlw_xmm_m128_imm8 = 4160,
    /// <summary>
    /// vpsrlw xmm {k1}{z}, xmm/m128, imm8
    /// </summary>
    [Symbol("vpsrlw xmm_k1z, xmm, imm8","vpsrlw xmm {k1}{z}, xmm/m128, imm8")]
    vpsrlw_xmm_k1z_xmm_imm8 = 4161,
    /// <summary>
    /// vpsrlw xmm {k1}{z}, xmm/m128, imm8
    /// </summary>
    [Symbol("vpsrlw xmm_k1z, m128, imm8","vpsrlw xmm {k1}{z}, xmm/m128, imm8")]
    vpsrlw_xmm_k1z_m128_imm8 = 4162,
    /// <summary>
    /// vpsrlw ymm {k1}{z}, ymm, xmm/m128
    /// </summary>
    [Symbol("vpsrlw ymm, ymm, xmm","vpsrlw ymm {k1}{z}, ymm, xmm/m128")]
    vpsrlw_ymm_ymm_xmm = 4163,
    /// <summary>
    /// vpsrlw ymm {k1}{z}, ymm, xmm/m128
    /// </summary>
    [Symbol("vpsrlw ymm, ymm, m128","vpsrlw ymm {k1}{z}, ymm, xmm/m128")]
    vpsrlw_ymm_ymm_m128 = 4164,
    /// <summary>
    /// vpsrlw ymm {k1}{z}, ymm, xmm/m128
    /// </summary>
    [Symbol("vpsrlw ymm_k1z, ymm, xmm","vpsrlw ymm {k1}{z}, ymm, xmm/m128")]
    vpsrlw_ymm_k1z_ymm_xmm = 4165,
    /// <summary>
    /// vpsrlw ymm {k1}{z}, ymm, xmm/m128
    /// </summary>
    [Symbol("vpsrlw ymm_k1z, ymm, m128","vpsrlw ymm {k1}{z}, ymm, xmm/m128")]
    vpsrlw_ymm_k1z_ymm_m128 = 4166,
    /// <summary>
    /// vpsrlw ymm {k1}{z}, ymm/m256, imm8
    /// </summary>
    [Symbol("vpsrlw ymm, ymm, imm8","vpsrlw ymm {k1}{z}, ymm/m256, imm8")]
    vpsrlw_ymm_ymm_imm8 = 4167,
    /// <summary>
    /// vpsrlw ymm {k1}{z}, ymm/m256, imm8
    /// </summary>
    [Symbol("vpsrlw ymm, m256, imm8","vpsrlw ymm {k1}{z}, ymm/m256, imm8")]
    vpsrlw_ymm_m256_imm8 = 4168,
    /// <summary>
    /// vpsrlw ymm {k1}{z}, ymm/m256, imm8
    /// </summary>
    [Symbol("vpsrlw ymm_k1z, ymm, imm8","vpsrlw ymm {k1}{z}, ymm/m256, imm8")]
    vpsrlw_ymm_k1z_ymm_imm8 = 4169,
    /// <summary>
    /// vpsrlw ymm {k1}{z}, ymm/m256, imm8
    /// </summary>
    [Symbol("vpsrlw ymm_k1z, m256, imm8","vpsrlw ymm {k1}{z}, ymm/m256, imm8")]
    vpsrlw_ymm_k1z_m256_imm8 = 4170,
    /// <summary>
    /// vpsrlw zmm {k1}{z}, zmm, xmm/m128
    /// </summary>
    [Symbol("vpsrlw zmm, zmm, xmm","vpsrlw zmm {k1}{z}, zmm, xmm/m128")]
    vpsrlw_zmm_zmm_xmm = 4171,
    /// <summary>
    /// vpsrlw zmm {k1}{z}, zmm, xmm/m128
    /// </summary>
    [Symbol("vpsrlw zmm, zmm, m128","vpsrlw zmm {k1}{z}, zmm, xmm/m128")]
    vpsrlw_zmm_zmm_m128 = 4172,
    /// <summary>
    /// vpsrlw zmm {k1}{z}, zmm, xmm/m128
    /// </summary>
    [Symbol("vpsrlw zmm_k1z, zmm, xmm","vpsrlw zmm {k1}{z}, zmm, xmm/m128")]
    vpsrlw_zmm_k1z_zmm_xmm = 4173,
    /// <summary>
    /// vpsrlw zmm {k1}{z}, zmm, xmm/m128
    /// </summary>
    [Symbol("vpsrlw zmm_k1z, zmm, m128","vpsrlw zmm {k1}{z}, zmm, xmm/m128")]
    vpsrlw_zmm_k1z_zmm_m128 = 4174,
    /// <summary>
    /// vpsrlw zmm {k1}{z}, zmm/m512, imm8
    /// </summary>
    [Symbol("vpsrlw zmm, zmm, imm8","vpsrlw zmm {k1}{z}, zmm/m512, imm8")]
    vpsrlw_zmm_zmm_imm8 = 4175,
    /// <summary>
    /// vpsrlw zmm {k1}{z}, zmm/m512, imm8
    /// </summary>
    [Symbol("vpsrlw zmm, m512, imm8","vpsrlw zmm {k1}{z}, zmm/m512, imm8")]
    vpsrlw_zmm_m512_imm8 = 4176,
    /// <summary>
    /// vpsrlw zmm {k1}{z}, zmm/m512, imm8
    /// </summary>
    [Symbol("vpsrlw zmm_k1z, zmm, imm8","vpsrlw zmm {k1}{z}, zmm/m512, imm8")]
    vpsrlw_zmm_k1z_zmm_imm8 = 4177,
    /// <summary>
    /// vpsrlw zmm {k1}{z}, zmm/m512, imm8
    /// </summary>
    [Symbol("vpsrlw zmm_k1z, m512, imm8","vpsrlw zmm {k1}{z}, zmm/m512, imm8")]
    vpsrlw_zmm_k1z_m512_imm8 = 4178,
    /// <summary>
    /// vpsubb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsubb xmm, xmm, xmm","vpsubb xmm {k1}{z}, xmm, xmm/m128")]
    vpsubb_xmm_xmm_xmm = 4179,
    /// <summary>
    /// vpsubb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsubb xmm, xmm, m128","vpsubb xmm {k1}{z}, xmm, xmm/m128")]
    vpsubb_xmm_xmm_m128 = 4180,
    /// <summary>
    /// vpsubb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsubb xmm_k1z, xmm, xmm","vpsubb xmm {k1}{z}, xmm, xmm/m128")]
    vpsubb_xmm_k1z_xmm_xmm = 4181,
    /// <summary>
    /// vpsubb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsubb xmm_k1z, xmm, m128","vpsubb xmm {k1}{z}, xmm, xmm/m128")]
    vpsubb_xmm_k1z_xmm_m128 = 4182,
    /// <summary>
    /// vpsubb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsubb ymm, ymm, ymm","vpsubb ymm {k1}{z}, ymm, ymm/m256")]
    vpsubb_ymm_ymm_ymm = 4183,
    /// <summary>
    /// vpsubb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsubb ymm, ymm, m256","vpsubb ymm {k1}{z}, ymm, ymm/m256")]
    vpsubb_ymm_ymm_m256 = 4184,
    /// <summary>
    /// vpsubb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsubb ymm_k1z, ymm, ymm","vpsubb ymm {k1}{z}, ymm, ymm/m256")]
    vpsubb_ymm_k1z_ymm_ymm = 4185,
    /// <summary>
    /// vpsubb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsubb ymm_k1z, ymm, m256","vpsubb ymm {k1}{z}, ymm, ymm/m256")]
    vpsubb_ymm_k1z_ymm_m256 = 4186,
    /// <summary>
    /// vpsubb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpsubb zmm, zmm, zmm","vpsubb zmm {k1}{z}, zmm, zmm/m512")]
    vpsubb_zmm_zmm_zmm = 4187,
    /// <summary>
    /// vpsubb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpsubb zmm, zmm, m512","vpsubb zmm {k1}{z}, zmm, zmm/m512")]
    vpsubb_zmm_zmm_m512 = 4188,
    /// <summary>
    /// vpsubb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpsubb zmm_k1z, zmm, zmm","vpsubb zmm {k1}{z}, zmm, zmm/m512")]
    vpsubb_zmm_k1z_zmm_zmm = 4189,
    /// <summary>
    /// vpsubb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpsubb zmm_k1z, zmm, m512","vpsubb zmm {k1}{z}, zmm, zmm/m512")]
    vpsubb_zmm_k1z_zmm_m512 = 4190,
    /// <summary>
    /// vpsubd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpsubd xmm, xmm, xmm","vpsubd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpsubd_xmm_xmm_xmm = 4191,
    /// <summary>
    /// vpsubd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpsubd xmm, xmm, m128","vpsubd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpsubd_xmm_xmm_m128 = 4192,
    /// <summary>
    /// vpsubd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpsubd xmm, xmm, m32bcst","vpsubd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpsubd_xmm_xmm_m32bcst = 4193,
    /// <summary>
    /// vpsubd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpsubd xmm_k1z, xmm, xmm","vpsubd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpsubd_xmm_k1z_xmm_xmm = 4194,
    /// <summary>
    /// vpsubd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpsubd xmm_k1z, xmm, m128","vpsubd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpsubd_xmm_k1z_xmm_m128 = 4195,
    /// <summary>
    /// vpsubd xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpsubd xmm_k1z, xmm, m32bcst","vpsubd xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpsubd_xmm_k1z_xmm_m32bcst = 4196,
    /// <summary>
    /// vpsubd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpsubd ymm, ymm, ymm","vpsubd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpsubd_ymm_ymm_ymm = 4197,
    /// <summary>
    /// vpsubd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpsubd ymm, ymm, m256","vpsubd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpsubd_ymm_ymm_m256 = 4198,
    /// <summary>
    /// vpsubd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpsubd ymm, ymm, m32bcst","vpsubd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpsubd_ymm_ymm_m32bcst = 4199,
    /// <summary>
    /// vpsubd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpsubd ymm_k1z, ymm, ymm","vpsubd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpsubd_ymm_k1z_ymm_ymm = 4200,
    /// <summary>
    /// vpsubd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpsubd ymm_k1z, ymm, m256","vpsubd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpsubd_ymm_k1z_ymm_m256 = 4201,
    /// <summary>
    /// vpsubd ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpsubd ymm_k1z, ymm, m32bcst","vpsubd ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpsubd_ymm_k1z_ymm_m32bcst = 4202,
    /// <summary>
    /// vpsubd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpsubd zmm, zmm, zmm","vpsubd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpsubd_zmm_zmm_zmm = 4203,
    /// <summary>
    /// vpsubd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpsubd zmm, zmm, m512","vpsubd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpsubd_zmm_zmm_m512 = 4204,
    /// <summary>
    /// vpsubd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpsubd zmm, zmm, m32bcst","vpsubd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpsubd_zmm_zmm_m32bcst = 4205,
    /// <summary>
    /// vpsubd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpsubd zmm_k1z, zmm, zmm","vpsubd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpsubd_zmm_k1z_zmm_zmm = 4206,
    /// <summary>
    /// vpsubd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpsubd zmm_k1z, zmm, m512","vpsubd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpsubd_zmm_k1z_zmm_m512 = 4207,
    /// <summary>
    /// vpsubd zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpsubd zmm_k1z, zmm, m32bcst","vpsubd zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpsubd_zmm_k1z_zmm_m32bcst = 4208,
    /// <summary>
    /// vpsubq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpsubq xmm, xmm, xmm","vpsubq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpsubq_xmm_xmm_xmm = 4209,
    /// <summary>
    /// vpsubq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpsubq xmm, xmm, m128","vpsubq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpsubq_xmm_xmm_m128 = 4210,
    /// <summary>
    /// vpsubq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpsubq xmm, xmm, m64bcst","vpsubq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpsubq_xmm_xmm_m64bcst = 4211,
    /// <summary>
    /// vpsubq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpsubq xmm_k1z, xmm, xmm","vpsubq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpsubq_xmm_k1z_xmm_xmm = 4212,
    /// <summary>
    /// vpsubq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpsubq xmm_k1z, xmm, m128","vpsubq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpsubq_xmm_k1z_xmm_m128 = 4213,
    /// <summary>
    /// vpsubq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpsubq xmm_k1z, xmm, m64bcst","vpsubq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpsubq_xmm_k1z_xmm_m64bcst = 4214,
    /// <summary>
    /// vpsubq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpsubq ymm, ymm, ymm","vpsubq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpsubq_ymm_ymm_ymm = 4215,
    /// <summary>
    /// vpsubq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpsubq ymm, ymm, m256","vpsubq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpsubq_ymm_ymm_m256 = 4216,
    /// <summary>
    /// vpsubq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpsubq ymm, ymm, m64bcst","vpsubq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpsubq_ymm_ymm_m64bcst = 4217,
    /// <summary>
    /// vpsubq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpsubq ymm_k1z, ymm, ymm","vpsubq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpsubq_ymm_k1z_ymm_ymm = 4218,
    /// <summary>
    /// vpsubq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpsubq ymm_k1z, ymm, m256","vpsubq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpsubq_ymm_k1z_ymm_m256 = 4219,
    /// <summary>
    /// vpsubq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpsubq ymm_k1z, ymm, m64bcst","vpsubq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpsubq_ymm_k1z_ymm_m64bcst = 4220,
    /// <summary>
    /// vpsubq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpsubq zmm, zmm, zmm","vpsubq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpsubq_zmm_zmm_zmm = 4221,
    /// <summary>
    /// vpsubq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpsubq zmm, zmm, m512","vpsubq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpsubq_zmm_zmm_m512 = 4222,
    /// <summary>
    /// vpsubq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpsubq zmm, zmm, m64bcst","vpsubq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpsubq_zmm_zmm_m64bcst = 4223,
    /// <summary>
    /// vpsubq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpsubq zmm_k1z, zmm, zmm","vpsubq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpsubq_zmm_k1z_zmm_zmm = 4224,
    /// <summary>
    /// vpsubq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpsubq zmm_k1z, zmm, m512","vpsubq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpsubq_zmm_k1z_zmm_m512 = 4225,
    /// <summary>
    /// vpsubq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpsubq zmm_k1z, zmm, m64bcst","vpsubq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpsubq_zmm_k1z_zmm_m64bcst = 4226,
    /// <summary>
    /// vpsubsb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsubsb xmm, xmm, xmm","vpsubsb xmm {k1}{z}, xmm, xmm/m128")]
    vpsubsb_xmm_xmm_xmm = 4227,
    /// <summary>
    /// vpsubsb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsubsb xmm, xmm, m128","vpsubsb xmm {k1}{z}, xmm, xmm/m128")]
    vpsubsb_xmm_xmm_m128 = 4228,
    /// <summary>
    /// vpsubsb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsubsb xmm_k1z, xmm, xmm","vpsubsb xmm {k1}{z}, xmm, xmm/m128")]
    vpsubsb_xmm_k1z_xmm_xmm = 4229,
    /// <summary>
    /// vpsubsb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsubsb xmm_k1z, xmm, m128","vpsubsb xmm {k1}{z}, xmm, xmm/m128")]
    vpsubsb_xmm_k1z_xmm_m128 = 4230,
    /// <summary>
    /// vpsubsb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsubsb ymm, ymm, ymm","vpsubsb ymm {k1}{z}, ymm, ymm/m256")]
    vpsubsb_ymm_ymm_ymm = 4231,
    /// <summary>
    /// vpsubsb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsubsb ymm, ymm, m256","vpsubsb ymm {k1}{z}, ymm, ymm/m256")]
    vpsubsb_ymm_ymm_m256 = 4232,
    /// <summary>
    /// vpsubsb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsubsb ymm_k1z, ymm, ymm","vpsubsb ymm {k1}{z}, ymm, ymm/m256")]
    vpsubsb_ymm_k1z_ymm_ymm = 4233,
    /// <summary>
    /// vpsubsb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsubsb ymm_k1z, ymm, m256","vpsubsb ymm {k1}{z}, ymm, ymm/m256")]
    vpsubsb_ymm_k1z_ymm_m256 = 4234,
    /// <summary>
    /// vpsubsb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpsubsb zmm, zmm, zmm","vpsubsb zmm {k1}{z}, zmm, zmm/m512")]
    vpsubsb_zmm_zmm_zmm = 4235,
    /// <summary>
    /// vpsubsb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpsubsb zmm, zmm, m512","vpsubsb zmm {k1}{z}, zmm, zmm/m512")]
    vpsubsb_zmm_zmm_m512 = 4236,
    /// <summary>
    /// vpsubsb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpsubsb zmm_k1z, zmm, zmm","vpsubsb zmm {k1}{z}, zmm, zmm/m512")]
    vpsubsb_zmm_k1z_zmm_zmm = 4237,
    /// <summary>
    /// vpsubsb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpsubsb zmm_k1z, zmm, m512","vpsubsb zmm {k1}{z}, zmm, zmm/m512")]
    vpsubsb_zmm_k1z_zmm_m512 = 4238,
    /// <summary>
    /// vpsubsw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsubsw xmm, xmm, xmm","vpsubsw xmm {k1}{z}, xmm, xmm/m128")]
    vpsubsw_xmm_xmm_xmm = 4239,
    /// <summary>
    /// vpsubsw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsubsw xmm, xmm, m128","vpsubsw xmm {k1}{z}, xmm, xmm/m128")]
    vpsubsw_xmm_xmm_m128 = 4240,
    /// <summary>
    /// vpsubsw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsubsw xmm_k1z, xmm, xmm","vpsubsw xmm {k1}{z}, xmm, xmm/m128")]
    vpsubsw_xmm_k1z_xmm_xmm = 4241,
    /// <summary>
    /// vpsubsw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsubsw xmm_k1z, xmm, m128","vpsubsw xmm {k1}{z}, xmm, xmm/m128")]
    vpsubsw_xmm_k1z_xmm_m128 = 4242,
    /// <summary>
    /// vpsubsw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsubsw ymm, ymm, ymm","vpsubsw ymm {k1}{z}, ymm, ymm/m256")]
    vpsubsw_ymm_ymm_ymm = 4243,
    /// <summary>
    /// vpsubsw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsubsw ymm, ymm, m256","vpsubsw ymm {k1}{z}, ymm, ymm/m256")]
    vpsubsw_ymm_ymm_m256 = 4244,
    /// <summary>
    /// vpsubsw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsubsw ymm_k1z, ymm, ymm","vpsubsw ymm {k1}{z}, ymm, ymm/m256")]
    vpsubsw_ymm_k1z_ymm_ymm = 4245,
    /// <summary>
    /// vpsubsw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsubsw ymm_k1z, ymm, m256","vpsubsw ymm {k1}{z}, ymm, ymm/m256")]
    vpsubsw_ymm_k1z_ymm_m256 = 4246,
    /// <summary>
    /// vpsubusb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsubusb xmm, xmm, xmm","vpsubusb xmm {k1}{z}, xmm, xmm/m128")]
    vpsubusb_xmm_xmm_xmm = 4247,
    /// <summary>
    /// vpsubusb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsubusb xmm, xmm, m128","vpsubusb xmm {k1}{z}, xmm, xmm/m128")]
    vpsubusb_xmm_xmm_m128 = 4248,
    /// <summary>
    /// vpsubusb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsubusb xmm_k1z, xmm, xmm","vpsubusb xmm {k1}{z}, xmm, xmm/m128")]
    vpsubusb_xmm_k1z_xmm_xmm = 4249,
    /// <summary>
    /// vpsubusb xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsubusb xmm_k1z, xmm, m128","vpsubusb xmm {k1}{z}, xmm, xmm/m128")]
    vpsubusb_xmm_k1z_xmm_m128 = 4250,
    /// <summary>
    /// vpsubusb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsubusb ymm, ymm, ymm","vpsubusb ymm {k1}{z}, ymm, ymm/m256")]
    vpsubusb_ymm_ymm_ymm = 4251,
    /// <summary>
    /// vpsubusb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsubusb ymm, ymm, m256","vpsubusb ymm {k1}{z}, ymm, ymm/m256")]
    vpsubusb_ymm_ymm_m256 = 4252,
    /// <summary>
    /// vpsubusb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsubusb ymm_k1z, ymm, ymm","vpsubusb ymm {k1}{z}, ymm, ymm/m256")]
    vpsubusb_ymm_k1z_ymm_ymm = 4253,
    /// <summary>
    /// vpsubusb ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsubusb ymm_k1z, ymm, m256","vpsubusb ymm {k1}{z}, ymm, ymm/m256")]
    vpsubusb_ymm_k1z_ymm_m256 = 4254,
    /// <summary>
    /// vpsubusb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpsubusb zmm, zmm, zmm","vpsubusb zmm {k1}{z}, zmm, zmm/m512")]
    vpsubusb_zmm_zmm_zmm = 4255,
    /// <summary>
    /// vpsubusb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpsubusb zmm, zmm, m512","vpsubusb zmm {k1}{z}, zmm, zmm/m512")]
    vpsubusb_zmm_zmm_m512 = 4256,
    /// <summary>
    /// vpsubusb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpsubusb zmm_k1z, zmm, zmm","vpsubusb zmm {k1}{z}, zmm, zmm/m512")]
    vpsubusb_zmm_k1z_zmm_zmm = 4257,
    /// <summary>
    /// vpsubusb zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpsubusb zmm_k1z, zmm, m512","vpsubusb zmm {k1}{z}, zmm, zmm/m512")]
    vpsubusb_zmm_k1z_zmm_m512 = 4258,
    /// <summary>
    /// vpsubusw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsubusw xmm, xmm, xmm","vpsubusw xmm {k1}{z}, xmm, xmm/m128")]
    vpsubusw_xmm_xmm_xmm = 4259,
    /// <summary>
    /// vpsubusw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsubusw xmm, xmm, m128","vpsubusw xmm {k1}{z}, xmm, xmm/m128")]
    vpsubusw_xmm_xmm_m128 = 4260,
    /// <summary>
    /// vpsubusw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsubusw xmm_k1z, xmm, xmm","vpsubusw xmm {k1}{z}, xmm, xmm/m128")]
    vpsubusw_xmm_k1z_xmm_xmm = 4261,
    /// <summary>
    /// vpsubusw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsubusw xmm_k1z, xmm, m128","vpsubusw xmm {k1}{z}, xmm, xmm/m128")]
    vpsubusw_xmm_k1z_xmm_m128 = 4262,
    /// <summary>
    /// vpsubusw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsubusw ymm, ymm, ymm","vpsubusw ymm {k1}{z}, ymm, ymm/m256")]
    vpsubusw_ymm_ymm_ymm = 4263,
    /// <summary>
    /// vpsubusw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsubusw ymm, ymm, m256","vpsubusw ymm {k1}{z}, ymm, ymm/m256")]
    vpsubusw_ymm_ymm_m256 = 4264,
    /// <summary>
    /// vpsubusw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsubusw ymm_k1z, ymm, ymm","vpsubusw ymm {k1}{z}, ymm, ymm/m256")]
    vpsubusw_ymm_k1z_ymm_ymm = 4265,
    /// <summary>
    /// vpsubusw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsubusw ymm_k1z, ymm, m256","vpsubusw ymm {k1}{z}, ymm, ymm/m256")]
    vpsubusw_ymm_k1z_ymm_m256 = 4266,
    /// <summary>
    /// vpsubw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsubw xmm, xmm, xmm","vpsubw xmm {k1}{z}, xmm, xmm/m128")]
    vpsubw_xmm_xmm_xmm = 4267,
    /// <summary>
    /// vpsubw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsubw xmm, xmm, m128","vpsubw xmm {k1}{z}, xmm, xmm/m128")]
    vpsubw_xmm_xmm_m128 = 4268,
    /// <summary>
    /// vpsubw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsubw xmm_k1z, xmm, xmm","vpsubw xmm {k1}{z}, xmm, xmm/m128")]
    vpsubw_xmm_k1z_xmm_xmm = 4269,
    /// <summary>
    /// vpsubw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpsubw xmm_k1z, xmm, m128","vpsubw xmm {k1}{z}, xmm, xmm/m128")]
    vpsubw_xmm_k1z_xmm_m128 = 4270,
    /// <summary>
    /// vpsubw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsubw ymm, ymm, ymm","vpsubw ymm {k1}{z}, ymm, ymm/m256")]
    vpsubw_ymm_ymm_ymm = 4271,
    /// <summary>
    /// vpsubw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsubw ymm, ymm, m256","vpsubw ymm {k1}{z}, ymm, ymm/m256")]
    vpsubw_ymm_ymm_m256 = 4272,
    /// <summary>
    /// vpsubw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsubw ymm_k1z, ymm, ymm","vpsubw ymm {k1}{z}, ymm, ymm/m256")]
    vpsubw_ymm_k1z_ymm_ymm = 4273,
    /// <summary>
    /// vpsubw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpsubw ymm_k1z, ymm, m256","vpsubw ymm {k1}{z}, ymm, ymm/m256")]
    vpsubw_ymm_k1z_ymm_m256 = 4274,
    /// <summary>
    /// vpsubw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpsubw zmm, zmm, zmm","vpsubw zmm {k1}{z}, zmm, zmm/m512")]
    vpsubw_zmm_zmm_zmm = 4275,
    /// <summary>
    /// vpsubw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpsubw zmm, zmm, m512","vpsubw zmm {k1}{z}, zmm, zmm/m512")]
    vpsubw_zmm_zmm_m512 = 4276,
    /// <summary>
    /// vpsubw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpsubw zmm_k1z, zmm, zmm","vpsubw zmm {k1}{z}, zmm, zmm/m512")]
    vpsubw_zmm_k1z_zmm_zmm = 4277,
    /// <summary>
    /// vpsubw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpsubw zmm_k1z, zmm, m512","vpsubw zmm {k1}{z}, zmm, zmm/m512")]
    vpsubw_zmm_k1z_zmm_m512 = 4278,
    /// <summary>
    /// vpternlogd xmm {k1}{z}, xmm, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vpternlogd xmm, xmm, xmm, imm8","vpternlogd xmm {k1}{z}, xmm, xmm/m128/m32bcst, imm8")]
    vpternlogd_xmm_xmm_xmm_imm8 = 4279,
    /// <summary>
    /// vpternlogd xmm {k1}{z}, xmm, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vpternlogd xmm, xmm, m128, imm8","vpternlogd xmm {k1}{z}, xmm, xmm/m128/m32bcst, imm8")]
    vpternlogd_xmm_xmm_m128_imm8 = 4280,
    /// <summary>
    /// vpternlogd xmm {k1}{z}, xmm, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vpternlogd xmm, xmm, m32bcst, imm8","vpternlogd xmm {k1}{z}, xmm, xmm/m128/m32bcst, imm8")]
    vpternlogd_xmm_xmm_m32bcst_imm8 = 4281,
    /// <summary>
    /// vpternlogd xmm {k1}{z}, xmm, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vpternlogd xmm_k1z, xmm, xmm, imm8","vpternlogd xmm {k1}{z}, xmm, xmm/m128/m32bcst, imm8")]
    vpternlogd_xmm_k1z_xmm_xmm_imm8 = 4282,
    /// <summary>
    /// vpternlogd xmm {k1}{z}, xmm, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vpternlogd xmm_k1z, xmm, m128, imm8","vpternlogd xmm {k1}{z}, xmm, xmm/m128/m32bcst, imm8")]
    vpternlogd_xmm_k1z_xmm_m128_imm8 = 4283,
    /// <summary>
    /// vpternlogd xmm {k1}{z}, xmm, xmm/m128/m32bcst, imm8
    /// </summary>
    [Symbol("vpternlogd xmm_k1z, xmm, m32bcst, imm8","vpternlogd xmm {k1}{z}, xmm, xmm/m128/m32bcst, imm8")]
    vpternlogd_xmm_k1z_xmm_m32bcst_imm8 = 4284,
    /// <summary>
    /// vpternlogd ymm {k1}{z}, ymm, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vpternlogd ymm, ymm, ymm, imm8","vpternlogd ymm {k1}{z}, ymm, ymm/m256/m32bcst, imm8")]
    vpternlogd_ymm_ymm_ymm_imm8 = 4285,
    /// <summary>
    /// vpternlogd ymm {k1}{z}, ymm, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vpternlogd ymm, ymm, m256, imm8","vpternlogd ymm {k1}{z}, ymm, ymm/m256/m32bcst, imm8")]
    vpternlogd_ymm_ymm_m256_imm8 = 4286,
    /// <summary>
    /// vpternlogd ymm {k1}{z}, ymm, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vpternlogd ymm, ymm, m32bcst, imm8","vpternlogd ymm {k1}{z}, ymm, ymm/m256/m32bcst, imm8")]
    vpternlogd_ymm_ymm_m32bcst_imm8 = 4287,
    /// <summary>
    /// vpternlogd ymm {k1}{z}, ymm, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vpternlogd ymm_k1z, ymm, ymm, imm8","vpternlogd ymm {k1}{z}, ymm, ymm/m256/m32bcst, imm8")]
    vpternlogd_ymm_k1z_ymm_ymm_imm8 = 4288,
    /// <summary>
    /// vpternlogd ymm {k1}{z}, ymm, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vpternlogd ymm_k1z, ymm, m256, imm8","vpternlogd ymm {k1}{z}, ymm, ymm/m256/m32bcst, imm8")]
    vpternlogd_ymm_k1z_ymm_m256_imm8 = 4289,
    /// <summary>
    /// vpternlogd ymm {k1}{z}, ymm, ymm/m256/m32bcst, imm8
    /// </summary>
    [Symbol("vpternlogd ymm_k1z, ymm, m32bcst, imm8","vpternlogd ymm {k1}{z}, ymm, ymm/m256/m32bcst, imm8")]
    vpternlogd_ymm_k1z_ymm_m32bcst_imm8 = 4290,
    /// <summary>
    /// vpternlogd zmm {k1}{z}, zmm, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vpternlogd zmm, zmm, zmm, imm8","vpternlogd zmm {k1}{z}, zmm, zmm/m512/m32bcst, imm8")]
    vpternlogd_zmm_zmm_zmm_imm8 = 4291,
    /// <summary>
    /// vpternlogd zmm {k1}{z}, zmm, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vpternlogd zmm, zmm, m512, imm8","vpternlogd zmm {k1}{z}, zmm, zmm/m512/m32bcst, imm8")]
    vpternlogd_zmm_zmm_m512_imm8 = 4292,
    /// <summary>
    /// vpternlogd zmm {k1}{z}, zmm, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vpternlogd zmm, zmm, m32bcst, imm8","vpternlogd zmm {k1}{z}, zmm, zmm/m512/m32bcst, imm8")]
    vpternlogd_zmm_zmm_m32bcst_imm8 = 4293,
    /// <summary>
    /// vpternlogd zmm {k1}{z}, zmm, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vpternlogd zmm_k1z, zmm, zmm, imm8","vpternlogd zmm {k1}{z}, zmm, zmm/m512/m32bcst, imm8")]
    vpternlogd_zmm_k1z_zmm_zmm_imm8 = 4294,
    /// <summary>
    /// vpternlogd zmm {k1}{z}, zmm, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vpternlogd zmm_k1z, zmm, m512, imm8","vpternlogd zmm {k1}{z}, zmm, zmm/m512/m32bcst, imm8")]
    vpternlogd_zmm_k1z_zmm_m512_imm8 = 4295,
    /// <summary>
    /// vpternlogd zmm {k1}{z}, zmm, zmm/m512/m32bcst, imm8
    /// </summary>
    [Symbol("vpternlogd zmm_k1z, zmm, m32bcst, imm8","vpternlogd zmm {k1}{z}, zmm, zmm/m512/m32bcst, imm8")]
    vpternlogd_zmm_k1z_zmm_m32bcst_imm8 = 4296,
    /// <summary>
    /// vpternlogq xmm {k1}{z}, xmm, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("vpternlogq xmm, xmm, xmm, imm8","vpternlogq xmm {k1}{z}, xmm, xmm/m128/m64bcst, imm8")]
    vpternlogq_xmm_xmm_xmm_imm8 = 4297,
    /// <summary>
    /// vpternlogq xmm {k1}{z}, xmm, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("vpternlogq xmm, xmm, m128, imm8","vpternlogq xmm {k1}{z}, xmm, xmm/m128/m64bcst, imm8")]
    vpternlogq_xmm_xmm_m128_imm8 = 4298,
    /// <summary>
    /// vpternlogq xmm {k1}{z}, xmm, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("vpternlogq xmm, xmm, m64bcst, imm8","vpternlogq xmm {k1}{z}, xmm, xmm/m128/m64bcst, imm8")]
    vpternlogq_xmm_xmm_m64bcst_imm8 = 4299,
    /// <summary>
    /// vpternlogq xmm {k1}{z}, xmm, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("vpternlogq xmm_k1z, xmm, xmm, imm8","vpternlogq xmm {k1}{z}, xmm, xmm/m128/m64bcst, imm8")]
    vpternlogq_xmm_k1z_xmm_xmm_imm8 = 4300,
    /// <summary>
    /// vpternlogq xmm {k1}{z}, xmm, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("vpternlogq xmm_k1z, xmm, m128, imm8","vpternlogq xmm {k1}{z}, xmm, xmm/m128/m64bcst, imm8")]
    vpternlogq_xmm_k1z_xmm_m128_imm8 = 4301,
    /// <summary>
    /// vpternlogq xmm {k1}{z}, xmm, xmm/m128/m64bcst, imm8
    /// </summary>
    [Symbol("vpternlogq xmm_k1z, xmm, m64bcst, imm8","vpternlogq xmm {k1}{z}, xmm, xmm/m128/m64bcst, imm8")]
    vpternlogq_xmm_k1z_xmm_m64bcst_imm8 = 4302,
    /// <summary>
    /// vpternlogq ymm {k1}{z}, ymm, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vpternlogq ymm, ymm, ymm, imm8","vpternlogq ymm {k1}{z}, ymm, ymm/m256/m64bcst, imm8")]
    vpternlogq_ymm_ymm_ymm_imm8 = 4303,
    /// <summary>
    /// vpternlogq ymm {k1}{z}, ymm, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vpternlogq ymm, ymm, m256, imm8","vpternlogq ymm {k1}{z}, ymm, ymm/m256/m64bcst, imm8")]
    vpternlogq_ymm_ymm_m256_imm8 = 4304,
    /// <summary>
    /// vpternlogq ymm {k1}{z}, ymm, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vpternlogq ymm, ymm, m64bcst, imm8","vpternlogq ymm {k1}{z}, ymm, ymm/m256/m64bcst, imm8")]
    vpternlogq_ymm_ymm_m64bcst_imm8 = 4305,
    /// <summary>
    /// vpternlogq ymm {k1}{z}, ymm, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vpternlogq ymm_k1z, ymm, ymm, imm8","vpternlogq ymm {k1}{z}, ymm, ymm/m256/m64bcst, imm8")]
    vpternlogq_ymm_k1z_ymm_ymm_imm8 = 4306,
    /// <summary>
    /// vpternlogq ymm {k1}{z}, ymm, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vpternlogq ymm_k1z, ymm, m256, imm8","vpternlogq ymm {k1}{z}, ymm, ymm/m256/m64bcst, imm8")]
    vpternlogq_ymm_k1z_ymm_m256_imm8 = 4307,
    /// <summary>
    /// vpternlogq ymm {k1}{z}, ymm, ymm/m256/m64bcst, imm8
    /// </summary>
    [Symbol("vpternlogq ymm_k1z, ymm, m64bcst, imm8","vpternlogq ymm {k1}{z}, ymm, ymm/m256/m64bcst, imm8")]
    vpternlogq_ymm_k1z_ymm_m64bcst_imm8 = 4308,
    /// <summary>
    /// vpternlogq zmm {k1}{z}, zmm, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vpternlogq zmm, zmm, zmm, imm8","vpternlogq zmm {k1}{z}, zmm, zmm/m512/m64bcst, imm8")]
    vpternlogq_zmm_zmm_zmm_imm8 = 4309,
    /// <summary>
    /// vpternlogq zmm {k1}{z}, zmm, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vpternlogq zmm, zmm, m512, imm8","vpternlogq zmm {k1}{z}, zmm, zmm/m512/m64bcst, imm8")]
    vpternlogq_zmm_zmm_m512_imm8 = 4310,
    /// <summary>
    /// vpternlogq zmm {k1}{z}, zmm, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vpternlogq zmm, zmm, m64bcst, imm8","vpternlogq zmm {k1}{z}, zmm, zmm/m512/m64bcst, imm8")]
    vpternlogq_zmm_zmm_m64bcst_imm8 = 4311,
    /// <summary>
    /// vpternlogq zmm {k1}{z}, zmm, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vpternlogq zmm_k1z, zmm, zmm, imm8","vpternlogq zmm {k1}{z}, zmm, zmm/m512/m64bcst, imm8")]
    vpternlogq_zmm_k1z_zmm_zmm_imm8 = 4312,
    /// <summary>
    /// vpternlogq zmm {k1}{z}, zmm, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vpternlogq zmm_k1z, zmm, m512, imm8","vpternlogq zmm {k1}{z}, zmm, zmm/m512/m64bcst, imm8")]
    vpternlogq_zmm_k1z_zmm_m512_imm8 = 4313,
    /// <summary>
    /// vpternlogq zmm {k1}{z}, zmm, zmm/m512/m64bcst, imm8
    /// </summary>
    [Symbol("vpternlogq zmm_k1z, zmm, m64bcst, imm8","vpternlogq zmm {k1}{z}, zmm, zmm/m512/m64bcst, imm8")]
    vpternlogq_zmm_k1z_zmm_m64bcst_imm8 = 4314,
    /// <summary>
    /// vptest xmm, xmm/m128
    /// </summary>
    [Symbol("vptest xmm, xmm","vptest xmm, xmm/m128")]
    vptest_xmm_xmm = 4315,
    /// <summary>
    /// vptest xmm, xmm/m128
    /// </summary>
    [Symbol("vptest xmm, m128","vptest xmm, xmm/m128")]
    vptest_xmm_m128 = 4316,
    /// <summary>
    /// vptest ymm, ymm/m256
    /// </summary>
    [Symbol("vptest ymm, ymm","vptest ymm, ymm/m256")]
    vptest_ymm_ymm = 4317,
    /// <summary>
    /// vptest ymm, ymm/m256
    /// </summary>
    [Symbol("vptest ymm, m256","vptest ymm, ymm/m256")]
    vptest_ymm_m256 = 4318,
    /// <summary>
    /// vptestmb k2 {k1}, xmm, xmm/m128
    /// </summary>
    [Symbol("vptestmb k2, xmm, xmm","vptestmb k2 {k1}, xmm, xmm/m128")]
    vptestmb_k2_xmm_xmm = 4319,
    /// <summary>
    /// vptestmb k2 {k1}, xmm, xmm/m128
    /// </summary>
    [Symbol("vptestmb k2, xmm, m128","vptestmb k2 {k1}, xmm, xmm/m128")]
    vptestmb_k2_xmm_m128 = 4320,
    /// <summary>
    /// vptestmb k2 {k1}, xmm, xmm/m128
    /// </summary>
    [Symbol("vptestmb k21, xmm, xmm","vptestmb k2 {k1}, xmm, xmm/m128")]
    vptestmb_k21_xmm_xmm = 4321,
    /// <summary>
    /// vptestmb k2 {k1}, xmm, xmm/m128
    /// </summary>
    [Symbol("vptestmb k21, xmm, m128","vptestmb k2 {k1}, xmm, xmm/m128")]
    vptestmb_k21_xmm_m128 = 4322,
    /// <summary>
    /// vptestmb k2 {k1}, ymm, ymm/m256
    /// </summary>
    [Symbol("vptestmb k2, ymm, ymm","vptestmb k2 {k1}, ymm, ymm/m256")]
    vptestmb_k2_ymm_ymm = 4323,
    /// <summary>
    /// vptestmb k2 {k1}, ymm, ymm/m256
    /// </summary>
    [Symbol("vptestmb k2, ymm, m256","vptestmb k2 {k1}, ymm, ymm/m256")]
    vptestmb_k2_ymm_m256 = 4324,
    /// <summary>
    /// vptestmb k2 {k1}, ymm, ymm/m256
    /// </summary>
    [Symbol("vptestmb k21, ymm, ymm","vptestmb k2 {k1}, ymm, ymm/m256")]
    vptestmb_k21_ymm_ymm = 4325,
    /// <summary>
    /// vptestmb k2 {k1}, ymm, ymm/m256
    /// </summary>
    [Symbol("vptestmb k21, ymm, m256","vptestmb k2 {k1}, ymm, ymm/m256")]
    vptestmb_k21_ymm_m256 = 4326,
    /// <summary>
    /// vptestmb k2 {k1}, zmm, zmm/m512
    /// </summary>
    [Symbol("vptestmb k2, zmm, zmm","vptestmb k2 {k1}, zmm, zmm/m512")]
    vptestmb_k2_zmm_zmm = 4327,
    /// <summary>
    /// vptestmb k2 {k1}, zmm, zmm/m512
    /// </summary>
    [Symbol("vptestmb k2, zmm, m512","vptestmb k2 {k1}, zmm, zmm/m512")]
    vptestmb_k2_zmm_m512 = 4328,
    /// <summary>
    /// vptestmb k2 {k1}, zmm, zmm/m512
    /// </summary>
    [Symbol("vptestmb k21, zmm, zmm","vptestmb k2 {k1}, zmm, zmm/m512")]
    vptestmb_k21_zmm_zmm = 4329,
    /// <summary>
    /// vptestmb k2 {k1}, zmm, zmm/m512
    /// </summary>
    [Symbol("vptestmb k21, zmm, m512","vptestmb k2 {k1}, zmm, zmm/m512")]
    vptestmb_k21_zmm_m512 = 4330,
    /// <summary>
    /// vptestmd k2 {k1}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vptestmd k2, xmm, xmm","vptestmd k2 {k1}, xmm, xmm/m128/m32bcst")]
    vptestmd_k2_xmm_xmm = 4331,
    /// <summary>
    /// vptestmd k2 {k1}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vptestmd k2, xmm, m128","vptestmd k2 {k1}, xmm, xmm/m128/m32bcst")]
    vptestmd_k2_xmm_m128 = 4332,
    /// <summary>
    /// vptestmd k2 {k1}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vptestmd k2, xmm, m32bcst","vptestmd k2 {k1}, xmm, xmm/m128/m32bcst")]
    vptestmd_k2_xmm_m32bcst = 4333,
    /// <summary>
    /// vptestmd k2 {k1}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vptestmd k21, xmm, xmm","vptestmd k2 {k1}, xmm, xmm/m128/m32bcst")]
    vptestmd_k21_xmm_xmm = 4334,
    /// <summary>
    /// vptestmd k2 {k1}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vptestmd k21, xmm, m128","vptestmd k2 {k1}, xmm, xmm/m128/m32bcst")]
    vptestmd_k21_xmm_m128 = 4335,
    /// <summary>
    /// vptestmd k2 {k1}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vptestmd k21, xmm, m32bcst","vptestmd k2 {k1}, xmm, xmm/m128/m32bcst")]
    vptestmd_k21_xmm_m32bcst = 4336,
    /// <summary>
    /// vptestmd k2 {k1}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vptestmd k2, ymm, ymm","vptestmd k2 {k1}, ymm, ymm/m256/m32bcst")]
    vptestmd_k2_ymm_ymm = 4337,
    /// <summary>
    /// vptestmd k2 {k1}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vptestmd k2, ymm, m256","vptestmd k2 {k1}, ymm, ymm/m256/m32bcst")]
    vptestmd_k2_ymm_m256 = 4338,
    /// <summary>
    /// vptestmd k2 {k1}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vptestmd k2, ymm, m32bcst","vptestmd k2 {k1}, ymm, ymm/m256/m32bcst")]
    vptestmd_k2_ymm_m32bcst = 4339,
    /// <summary>
    /// vptestmd k2 {k1}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vptestmd k21, ymm, ymm","vptestmd k2 {k1}, ymm, ymm/m256/m32bcst")]
    vptestmd_k21_ymm_ymm = 4340,
    /// <summary>
    /// vptestmd k2 {k1}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vptestmd k21, ymm, m256","vptestmd k2 {k1}, ymm, ymm/m256/m32bcst")]
    vptestmd_k21_ymm_m256 = 4341,
    /// <summary>
    /// vptestmd k2 {k1}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vptestmd k21, ymm, m32bcst","vptestmd k2 {k1}, ymm, ymm/m256/m32bcst")]
    vptestmd_k21_ymm_m32bcst = 4342,
    /// <summary>
    /// vptestmd k2 {k1}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vptestmd k2, zmm, zmm","vptestmd k2 {k1}, zmm, zmm/m512/m32bcst")]
    vptestmd_k2_zmm_zmm = 4343,
    /// <summary>
    /// vptestmd k2 {k1}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vptestmd k2, zmm, m512","vptestmd k2 {k1}, zmm, zmm/m512/m32bcst")]
    vptestmd_k2_zmm_m512 = 4344,
    /// <summary>
    /// vptestmd k2 {k1}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vptestmd k2, zmm, m32bcst","vptestmd k2 {k1}, zmm, zmm/m512/m32bcst")]
    vptestmd_k2_zmm_m32bcst = 4345,
    /// <summary>
    /// vptestmd k2 {k1}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vptestmd k21, zmm, zmm","vptestmd k2 {k1}, zmm, zmm/m512/m32bcst")]
    vptestmd_k21_zmm_zmm = 4346,
    /// <summary>
    /// vptestmd k2 {k1}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vptestmd k21, zmm, m512","vptestmd k2 {k1}, zmm, zmm/m512/m32bcst")]
    vptestmd_k21_zmm_m512 = 4347,
    /// <summary>
    /// vptestmd k2 {k1}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vptestmd k21, zmm, m32bcst","vptestmd k2 {k1}, zmm, zmm/m512/m32bcst")]
    vptestmd_k21_zmm_m32bcst = 4348,
    /// <summary>
    /// vptestmq k2 {k1}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vptestmq k2, xmm, xmm","vptestmq k2 {k1}, xmm, xmm/m128/m64bcst")]
    vptestmq_k2_xmm_xmm = 4349,
    /// <summary>
    /// vptestmq k2 {k1}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vptestmq k2, xmm, m128","vptestmq k2 {k1}, xmm, xmm/m128/m64bcst")]
    vptestmq_k2_xmm_m128 = 4350,
    /// <summary>
    /// vptestmq k2 {k1}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vptestmq k2, xmm, m64bcst","vptestmq k2 {k1}, xmm, xmm/m128/m64bcst")]
    vptestmq_k2_xmm_m64bcst = 4351,
    /// <summary>
    /// vptestmq k2 {k1}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vptestmq k21, xmm, xmm","vptestmq k2 {k1}, xmm, xmm/m128/m64bcst")]
    vptestmq_k21_xmm_xmm = 4352,
    /// <summary>
    /// vptestmq k2 {k1}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vptestmq k21, xmm, m128","vptestmq k2 {k1}, xmm, xmm/m128/m64bcst")]
    vptestmq_k21_xmm_m128 = 4353,
    /// <summary>
    /// vptestmq k2 {k1}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vptestmq k21, xmm, m64bcst","vptestmq k2 {k1}, xmm, xmm/m128/m64bcst")]
    vptestmq_k21_xmm_m64bcst = 4354,
    /// <summary>
    /// vptestmq k2 {k1}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vptestmq k2, ymm, ymm","vptestmq k2 {k1}, ymm, ymm/m256/m64bcst")]
    vptestmq_k2_ymm_ymm = 4355,
    /// <summary>
    /// vptestmq k2 {k1}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vptestmq k2, ymm, m256","vptestmq k2 {k1}, ymm, ymm/m256/m64bcst")]
    vptestmq_k2_ymm_m256 = 4356,
    /// <summary>
    /// vptestmq k2 {k1}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vptestmq k2, ymm, m64bcst","vptestmq k2 {k1}, ymm, ymm/m256/m64bcst")]
    vptestmq_k2_ymm_m64bcst = 4357,
    /// <summary>
    /// vptestmq k2 {k1}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vptestmq k21, ymm, ymm","vptestmq k2 {k1}, ymm, ymm/m256/m64bcst")]
    vptestmq_k21_ymm_ymm = 4358,
    /// <summary>
    /// vptestmq k2 {k1}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vptestmq k21, ymm, m256","vptestmq k2 {k1}, ymm, ymm/m256/m64bcst")]
    vptestmq_k21_ymm_m256 = 4359,
    /// <summary>
    /// vptestmq k2 {k1}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vptestmq k21, ymm, m64bcst","vptestmq k2 {k1}, ymm, ymm/m256/m64bcst")]
    vptestmq_k21_ymm_m64bcst = 4360,
    /// <summary>
    /// vptestmq k2 {k1}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vptestmq k2, zmm, zmm","vptestmq k2 {k1}, zmm, zmm/m512/m64bcst")]
    vptestmq_k2_zmm_zmm = 4361,
    /// <summary>
    /// vptestmq k2 {k1}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vptestmq k2, zmm, m512","vptestmq k2 {k1}, zmm, zmm/m512/m64bcst")]
    vptestmq_k2_zmm_m512 = 4362,
    /// <summary>
    /// vptestmq k2 {k1}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vptestmq k2, zmm, m64bcst","vptestmq k2 {k1}, zmm, zmm/m512/m64bcst")]
    vptestmq_k2_zmm_m64bcst = 4363,
    /// <summary>
    /// vptestmq k2 {k1}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vptestmq k21, zmm, zmm","vptestmq k2 {k1}, zmm, zmm/m512/m64bcst")]
    vptestmq_k21_zmm_zmm = 4364,
    /// <summary>
    /// vptestmq k2 {k1}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vptestmq k21, zmm, m512","vptestmq k2 {k1}, zmm, zmm/m512/m64bcst")]
    vptestmq_k21_zmm_m512 = 4365,
    /// <summary>
    /// vptestmq k2 {k1}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vptestmq k21, zmm, m64bcst","vptestmq k2 {k1}, zmm, zmm/m512/m64bcst")]
    vptestmq_k21_zmm_m64bcst = 4366,
    /// <summary>
    /// vptestmw k2 {k1}, xmm, xmm/m128
    /// </summary>
    [Symbol("vptestmw k2, xmm, xmm","vptestmw k2 {k1}, xmm, xmm/m128")]
    vptestmw_k2_xmm_xmm = 4367,
    /// <summary>
    /// vptestmw k2 {k1}, xmm, xmm/m128
    /// </summary>
    [Symbol("vptestmw k2, xmm, m128","vptestmw k2 {k1}, xmm, xmm/m128")]
    vptestmw_k2_xmm_m128 = 4368,
    /// <summary>
    /// vptestmw k2 {k1}, xmm, xmm/m128
    /// </summary>
    [Symbol("vptestmw k21, xmm, xmm","vptestmw k2 {k1}, xmm, xmm/m128")]
    vptestmw_k21_xmm_xmm = 4369,
    /// <summary>
    /// vptestmw k2 {k1}, xmm, xmm/m128
    /// </summary>
    [Symbol("vptestmw k21, xmm, m128","vptestmw k2 {k1}, xmm, xmm/m128")]
    vptestmw_k21_xmm_m128 = 4370,
    /// <summary>
    /// vptestmw k2 {k1}, ymm, ymm/m256
    /// </summary>
    [Symbol("vptestmw k2, ymm, ymm","vptestmw k2 {k1}, ymm, ymm/m256")]
    vptestmw_k2_ymm_ymm = 4371,
    /// <summary>
    /// vptestmw k2 {k1}, ymm, ymm/m256
    /// </summary>
    [Symbol("vptestmw k2, ymm, m256","vptestmw k2 {k1}, ymm, ymm/m256")]
    vptestmw_k2_ymm_m256 = 4372,
    /// <summary>
    /// vptestmw k2 {k1}, ymm, ymm/m256
    /// </summary>
    [Symbol("vptestmw k21, ymm, ymm","vptestmw k2 {k1}, ymm, ymm/m256")]
    vptestmw_k21_ymm_ymm = 4373,
    /// <summary>
    /// vptestmw k2 {k1}, ymm, ymm/m256
    /// </summary>
    [Symbol("vptestmw k21, ymm, m256","vptestmw k2 {k1}, ymm, ymm/m256")]
    vptestmw_k21_ymm_m256 = 4374,
    /// <summary>
    /// vptestmw k2 {k1}, zmm, zmm/m512
    /// </summary>
    [Symbol("vptestmw k2, zmm, zmm","vptestmw k2 {k1}, zmm, zmm/m512")]
    vptestmw_k2_zmm_zmm = 4375,
    /// <summary>
    /// vptestmw k2 {k1}, zmm, zmm/m512
    /// </summary>
    [Symbol("vptestmw k2, zmm, m512","vptestmw k2 {k1}, zmm, zmm/m512")]
    vptestmw_k2_zmm_m512 = 4376,
    /// <summary>
    /// vptestmw k2 {k1}, zmm, zmm/m512
    /// </summary>
    [Symbol("vptestmw k21, zmm, zmm","vptestmw k2 {k1}, zmm, zmm/m512")]
    vptestmw_k21_zmm_zmm = 4377,
    /// <summary>
    /// vptestmw k2 {k1}, zmm, zmm/m512
    /// </summary>
    [Symbol("vptestmw k21, zmm, m512","vptestmw k2 {k1}, zmm, zmm/m512")]
    vptestmw_k21_zmm_m512 = 4378,
    /// <summary>
    /// vptestnmb k2 {k1}, xmm, xmm/m128
    /// </summary>
    [Symbol("vptestnmb k2, xmm, xmm","vptestnmb k2 {k1}, xmm, xmm/m128")]
    vptestnmb_k2_xmm_xmm = 4379,
    /// <summary>
    /// vptestnmb k2 {k1}, xmm, xmm/m128
    /// </summary>
    [Symbol("vptestnmb k2, xmm, m128","vptestnmb k2 {k1}, xmm, xmm/m128")]
    vptestnmb_k2_xmm_m128 = 4380,
    /// <summary>
    /// vptestnmb k2 {k1}, xmm, xmm/m128
    /// </summary>
    [Symbol("vptestnmb k21, xmm, xmm","vptestnmb k2 {k1}, xmm, xmm/m128")]
    vptestnmb_k21_xmm_xmm = 4381,
    /// <summary>
    /// vptestnmb k2 {k1}, xmm, xmm/m128
    /// </summary>
    [Symbol("vptestnmb k21, xmm, m128","vptestnmb k2 {k1}, xmm, xmm/m128")]
    vptestnmb_k21_xmm_m128 = 4382,
    /// <summary>
    /// vptestnmb k2 {k1}, ymm, ymm/m256
    /// </summary>
    [Symbol("vptestnmb k2, ymm, ymm","vptestnmb k2 {k1}, ymm, ymm/m256")]
    vptestnmb_k2_ymm_ymm = 4383,
    /// <summary>
    /// vptestnmb k2 {k1}, ymm, ymm/m256
    /// </summary>
    [Symbol("vptestnmb k2, ymm, m256","vptestnmb k2 {k1}, ymm, ymm/m256")]
    vptestnmb_k2_ymm_m256 = 4384,
    /// <summary>
    /// vptestnmb k2 {k1}, ymm, ymm/m256
    /// </summary>
    [Symbol("vptestnmb k21, ymm, ymm","vptestnmb k2 {k1}, ymm, ymm/m256")]
    vptestnmb_k21_ymm_ymm = 4385,
    /// <summary>
    /// vptestnmb k2 {k1}, ymm, ymm/m256
    /// </summary>
    [Symbol("vptestnmb k21, ymm, m256","vptestnmb k2 {k1}, ymm, ymm/m256")]
    vptestnmb_k21_ymm_m256 = 4386,
    /// <summary>
    /// vptestnmb k2 {k1}, zmm, zmm/m512
    /// </summary>
    [Symbol("vptestnmb k2, zmm, zmm","vptestnmb k2 {k1}, zmm, zmm/m512")]
    vptestnmb_k2_zmm_zmm = 4387,
    /// <summary>
    /// vptestnmb k2 {k1}, zmm, zmm/m512
    /// </summary>
    [Symbol("vptestnmb k2, zmm, m512","vptestnmb k2 {k1}, zmm, zmm/m512")]
    vptestnmb_k2_zmm_m512 = 4388,
    /// <summary>
    /// vptestnmb k2 {k1}, zmm, zmm/m512
    /// </summary>
    [Symbol("vptestnmb k21, zmm, zmm","vptestnmb k2 {k1}, zmm, zmm/m512")]
    vptestnmb_k21_zmm_zmm = 4389,
    /// <summary>
    /// vptestnmb k2 {k1}, zmm, zmm/m512
    /// </summary>
    [Symbol("vptestnmb k21, zmm, m512","vptestnmb k2 {k1}, zmm, zmm/m512")]
    vptestnmb_k21_zmm_m512 = 4390,
    /// <summary>
    /// vptestnmd k2 {k1}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vptestnmd k2, xmm, xmm","vptestnmd k2 {k1}, xmm, xmm/m128/m32bcst")]
    vptestnmd_k2_xmm_xmm = 4391,
    /// <summary>
    /// vptestnmd k2 {k1}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vptestnmd k2, xmm, m128","vptestnmd k2 {k1}, xmm, xmm/m128/m32bcst")]
    vptestnmd_k2_xmm_m128 = 4392,
    /// <summary>
    /// vptestnmd k2 {k1}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vptestnmd k2, xmm, m32bcst","vptestnmd k2 {k1}, xmm, xmm/m128/m32bcst")]
    vptestnmd_k2_xmm_m32bcst = 4393,
    /// <summary>
    /// vptestnmd k2 {k1}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vptestnmd k21, xmm, xmm","vptestnmd k2 {k1}, xmm, xmm/m128/m32bcst")]
    vptestnmd_k21_xmm_xmm = 4394,
    /// <summary>
    /// vptestnmd k2 {k1}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vptestnmd k21, xmm, m128","vptestnmd k2 {k1}, xmm, xmm/m128/m32bcst")]
    vptestnmd_k21_xmm_m128 = 4395,
    /// <summary>
    /// vptestnmd k2 {k1}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vptestnmd k21, xmm, m32bcst","vptestnmd k2 {k1}, xmm, xmm/m128/m32bcst")]
    vptestnmd_k21_xmm_m32bcst = 4396,
    /// <summary>
    /// vptestnmd k2 {k1}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vptestnmd k2, ymm, ymm","vptestnmd k2 {k1}, ymm, ymm/m256/m32bcst")]
    vptestnmd_k2_ymm_ymm = 4397,
    /// <summary>
    /// vptestnmd k2 {k1}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vptestnmd k2, ymm, m256","vptestnmd k2 {k1}, ymm, ymm/m256/m32bcst")]
    vptestnmd_k2_ymm_m256 = 4398,
    /// <summary>
    /// vptestnmd k2 {k1}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vptestnmd k2, ymm, m32bcst","vptestnmd k2 {k1}, ymm, ymm/m256/m32bcst")]
    vptestnmd_k2_ymm_m32bcst = 4399,
    /// <summary>
    /// vptestnmd k2 {k1}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vptestnmd k21, ymm, ymm","vptestnmd k2 {k1}, ymm, ymm/m256/m32bcst")]
    vptestnmd_k21_ymm_ymm = 4400,
    /// <summary>
    /// vptestnmd k2 {k1}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vptestnmd k21, ymm, m256","vptestnmd k2 {k1}, ymm, ymm/m256/m32bcst")]
    vptestnmd_k21_ymm_m256 = 4401,
    /// <summary>
    /// vptestnmd k2 {k1}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vptestnmd k21, ymm, m32bcst","vptestnmd k2 {k1}, ymm, ymm/m256/m32bcst")]
    vptestnmd_k21_ymm_m32bcst = 4402,
    /// <summary>
    /// vptestnmd k2 {k1}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vptestnmd k2, zmm, zmm","vptestnmd k2 {k1}, zmm, zmm/m512/m32bcst")]
    vptestnmd_k2_zmm_zmm = 4403,
    /// <summary>
    /// vptestnmd k2 {k1}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vptestnmd k2, zmm, m512","vptestnmd k2 {k1}, zmm, zmm/m512/m32bcst")]
    vptestnmd_k2_zmm_m512 = 4404,
    /// <summary>
    /// vptestnmd k2 {k1}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vptestnmd k2, zmm, m32bcst","vptestnmd k2 {k1}, zmm, zmm/m512/m32bcst")]
    vptestnmd_k2_zmm_m32bcst = 4405,
    /// <summary>
    /// vptestnmd k2 {k1}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vptestnmd k21, zmm, zmm","vptestnmd k2 {k1}, zmm, zmm/m512/m32bcst")]
    vptestnmd_k21_zmm_zmm = 4406,
    /// <summary>
    /// vptestnmd k2 {k1}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vptestnmd k21, zmm, m512","vptestnmd k2 {k1}, zmm, zmm/m512/m32bcst")]
    vptestnmd_k21_zmm_m512 = 4407,
    /// <summary>
    /// vptestnmd k2 {k1}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vptestnmd k21, zmm, m32bcst","vptestnmd k2 {k1}, zmm, zmm/m512/m32bcst")]
    vptestnmd_k21_zmm_m32bcst = 4408,
    /// <summary>
    /// vptestnmq k2 {k1}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vptestnmq k2, xmm, xmm","vptestnmq k2 {k1}, xmm, xmm/m128/m64bcst")]
    vptestnmq_k2_xmm_xmm = 4409,
    /// <summary>
    /// vptestnmq k2 {k1}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vptestnmq k2, xmm, m128","vptestnmq k2 {k1}, xmm, xmm/m128/m64bcst")]
    vptestnmq_k2_xmm_m128 = 4410,
    /// <summary>
    /// vptestnmq k2 {k1}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vptestnmq k2, xmm, m64bcst","vptestnmq k2 {k1}, xmm, xmm/m128/m64bcst")]
    vptestnmq_k2_xmm_m64bcst = 4411,
    /// <summary>
    /// vptestnmq k2 {k1}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vptestnmq k21, xmm, xmm","vptestnmq k2 {k1}, xmm, xmm/m128/m64bcst")]
    vptestnmq_k21_xmm_xmm = 4412,
    /// <summary>
    /// vptestnmq k2 {k1}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vptestnmq k21, xmm, m128","vptestnmq k2 {k1}, xmm, xmm/m128/m64bcst")]
    vptestnmq_k21_xmm_m128 = 4413,
    /// <summary>
    /// vptestnmq k2 {k1}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vptestnmq k21, xmm, m64bcst","vptestnmq k2 {k1}, xmm, xmm/m128/m64bcst")]
    vptestnmq_k21_xmm_m64bcst = 4414,
    /// <summary>
    /// vptestnmq k2 {k1}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vptestnmq k2, ymm, ymm","vptestnmq k2 {k1}, ymm, ymm/m256/m64bcst")]
    vptestnmq_k2_ymm_ymm = 4415,
    /// <summary>
    /// vptestnmq k2 {k1}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vptestnmq k2, ymm, m256","vptestnmq k2 {k1}, ymm, ymm/m256/m64bcst")]
    vptestnmq_k2_ymm_m256 = 4416,
    /// <summary>
    /// vptestnmq k2 {k1}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vptestnmq k2, ymm, m64bcst","vptestnmq k2 {k1}, ymm, ymm/m256/m64bcst")]
    vptestnmq_k2_ymm_m64bcst = 4417,
    /// <summary>
    /// vptestnmq k2 {k1}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vptestnmq k21, ymm, ymm","vptestnmq k2 {k1}, ymm, ymm/m256/m64bcst")]
    vptestnmq_k21_ymm_ymm = 4418,
    /// <summary>
    /// vptestnmq k2 {k1}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vptestnmq k21, ymm, m256","vptestnmq k2 {k1}, ymm, ymm/m256/m64bcst")]
    vptestnmq_k21_ymm_m256 = 4419,
    /// <summary>
    /// vptestnmq k2 {k1}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vptestnmq k21, ymm, m64bcst","vptestnmq k2 {k1}, ymm, ymm/m256/m64bcst")]
    vptestnmq_k21_ymm_m64bcst = 4420,
    /// <summary>
    /// vptestnmq k2 {k1}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vptestnmq k2, zmm, zmm","vptestnmq k2 {k1}, zmm, zmm/m512/m64bcst")]
    vptestnmq_k2_zmm_zmm = 4421,
    /// <summary>
    /// vptestnmq k2 {k1}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vptestnmq k2, zmm, m512","vptestnmq k2 {k1}, zmm, zmm/m512/m64bcst")]
    vptestnmq_k2_zmm_m512 = 4422,
    /// <summary>
    /// vptestnmq k2 {k1}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vptestnmq k2, zmm, m64bcst","vptestnmq k2 {k1}, zmm, zmm/m512/m64bcst")]
    vptestnmq_k2_zmm_m64bcst = 4423,
    /// <summary>
    /// vptestnmq k2 {k1}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vptestnmq k21, zmm, zmm","vptestnmq k2 {k1}, zmm, zmm/m512/m64bcst")]
    vptestnmq_k21_zmm_zmm = 4424,
    /// <summary>
    /// vptestnmq k2 {k1}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vptestnmq k21, zmm, m512","vptestnmq k2 {k1}, zmm, zmm/m512/m64bcst")]
    vptestnmq_k21_zmm_m512 = 4425,
    /// <summary>
    /// vptestnmq k2 {k1}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vptestnmq k21, zmm, m64bcst","vptestnmq k2 {k1}, zmm, zmm/m512/m64bcst")]
    vptestnmq_k21_zmm_m64bcst = 4426,
    /// <summary>
    /// vptestnmw k2 {k1}, xmm, xmm/m128
    /// </summary>
    [Symbol("vptestnmw k2, xmm, xmm","vptestnmw k2 {k1}, xmm, xmm/m128")]
    vptestnmw_k2_xmm_xmm = 4427,
    /// <summary>
    /// vptestnmw k2 {k1}, xmm, xmm/m128
    /// </summary>
    [Symbol("vptestnmw k2, xmm, m128","vptestnmw k2 {k1}, xmm, xmm/m128")]
    vptestnmw_k2_xmm_m128 = 4428,
    /// <summary>
    /// vptestnmw k2 {k1}, xmm, xmm/m128
    /// </summary>
    [Symbol("vptestnmw k21, xmm, xmm","vptestnmw k2 {k1}, xmm, xmm/m128")]
    vptestnmw_k21_xmm_xmm = 4429,
    /// <summary>
    /// vptestnmw k2 {k1}, xmm, xmm/m128
    /// </summary>
    [Symbol("vptestnmw k21, xmm, m128","vptestnmw k2 {k1}, xmm, xmm/m128")]
    vptestnmw_k21_xmm_m128 = 4430,
    /// <summary>
    /// vptestnmw k2 {k1}, ymm, ymm/m256
    /// </summary>
    [Symbol("vptestnmw k2, ymm, ymm","vptestnmw k2 {k1}, ymm, ymm/m256")]
    vptestnmw_k2_ymm_ymm = 4431,
    /// <summary>
    /// vptestnmw k2 {k1}, ymm, ymm/m256
    /// </summary>
    [Symbol("vptestnmw k2, ymm, m256","vptestnmw k2 {k1}, ymm, ymm/m256")]
    vptestnmw_k2_ymm_m256 = 4432,
    /// <summary>
    /// vptestnmw k2 {k1}, ymm, ymm/m256
    /// </summary>
    [Symbol("vptestnmw k21, ymm, ymm","vptestnmw k2 {k1}, ymm, ymm/m256")]
    vptestnmw_k21_ymm_ymm = 4433,
    /// <summary>
    /// vptestnmw k2 {k1}, ymm, ymm/m256
    /// </summary>
    [Symbol("vptestnmw k21, ymm, m256","vptestnmw k2 {k1}, ymm, ymm/m256")]
    vptestnmw_k21_ymm_m256 = 4434,
    /// <summary>
    /// vptestnmw k2 {k1}, zmm, zmm/m512
    /// </summary>
    [Symbol("vptestnmw k2, zmm, zmm","vptestnmw k2 {k1}, zmm, zmm/m512")]
    vptestnmw_k2_zmm_zmm = 4435,
    /// <summary>
    /// vptestnmw k2 {k1}, zmm, zmm/m512
    /// </summary>
    [Symbol("vptestnmw k2, zmm, m512","vptestnmw k2 {k1}, zmm, zmm/m512")]
    vptestnmw_k2_zmm_m512 = 4436,
    /// <summary>
    /// vptestnmw k2 {k1}, zmm, zmm/m512
    /// </summary>
    [Symbol("vptestnmw k21, zmm, zmm","vptestnmw k2 {k1}, zmm, zmm/m512")]
    vptestnmw_k21_zmm_zmm = 4437,
    /// <summary>
    /// vptestnmw k2 {k1}, zmm, zmm/m512
    /// </summary>
    [Symbol("vptestnmw k21, zmm, m512","vptestnmw k2 {k1}, zmm, zmm/m512")]
    vptestnmw_k21_zmm_m512 = 4438,
    /// <summary>
    /// vpunpckhbw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpunpckhbw xmm, xmm, xmm","vpunpckhbw xmm {k1}{z}, xmm, xmm/m128")]
    vpunpckhbw_xmm_xmm_xmm = 4439,
    /// <summary>
    /// vpunpckhbw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpunpckhbw xmm, xmm, m128","vpunpckhbw xmm {k1}{z}, xmm, xmm/m128")]
    vpunpckhbw_xmm_xmm_m128 = 4440,
    /// <summary>
    /// vpunpckhbw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpunpckhbw xmm_k1z, xmm, xmm","vpunpckhbw xmm {k1}{z}, xmm, xmm/m128")]
    vpunpckhbw_xmm_k1z_xmm_xmm = 4441,
    /// <summary>
    /// vpunpckhbw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpunpckhbw xmm_k1z, xmm, m128","vpunpckhbw xmm {k1}{z}, xmm, xmm/m128")]
    vpunpckhbw_xmm_k1z_xmm_m128 = 4442,
    /// <summary>
    /// vpunpckhbw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpunpckhbw ymm, ymm, ymm","vpunpckhbw ymm {k1}{z}, ymm, ymm/m256")]
    vpunpckhbw_ymm_ymm_ymm = 4443,
    /// <summary>
    /// vpunpckhbw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpunpckhbw ymm, ymm, m256","vpunpckhbw ymm {k1}{z}, ymm, ymm/m256")]
    vpunpckhbw_ymm_ymm_m256 = 4444,
    /// <summary>
    /// vpunpckhbw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpunpckhbw ymm_k1z, ymm, ymm","vpunpckhbw ymm {k1}{z}, ymm, ymm/m256")]
    vpunpckhbw_ymm_k1z_ymm_ymm = 4445,
    /// <summary>
    /// vpunpckhbw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpunpckhbw ymm_k1z, ymm, m256","vpunpckhbw ymm {k1}{z}, ymm, ymm/m256")]
    vpunpckhbw_ymm_k1z_ymm_m256 = 4446,
    /// <summary>
    /// vpunpckhbw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpunpckhbw zmm, zmm, zmm","vpunpckhbw zmm {k1}{z}, zmm, zmm/m512")]
    vpunpckhbw_zmm_zmm_zmm = 4447,
    /// <summary>
    /// vpunpckhbw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpunpckhbw zmm, zmm, m512","vpunpckhbw zmm {k1}{z}, zmm, zmm/m512")]
    vpunpckhbw_zmm_zmm_m512 = 4448,
    /// <summary>
    /// vpunpckhbw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpunpckhbw zmm_k1z, zmm, zmm","vpunpckhbw zmm {k1}{z}, zmm, zmm/m512")]
    vpunpckhbw_zmm_k1z_zmm_zmm = 4449,
    /// <summary>
    /// vpunpckhbw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpunpckhbw zmm_k1z, zmm, m512","vpunpckhbw zmm {k1}{z}, zmm, zmm/m512")]
    vpunpckhbw_zmm_k1z_zmm_m512 = 4450,
    /// <summary>
    /// vpunpckhdq xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpunpckhdq xmm, xmm, xmm","vpunpckhdq xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpunpckhdq_xmm_xmm_xmm = 4451,
    /// <summary>
    /// vpunpckhdq xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpunpckhdq xmm, xmm, m128","vpunpckhdq xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpunpckhdq_xmm_xmm_m128 = 4452,
    /// <summary>
    /// vpunpckhdq xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpunpckhdq xmm, xmm, m32bcst","vpunpckhdq xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpunpckhdq_xmm_xmm_m32bcst = 4453,
    /// <summary>
    /// vpunpckhdq xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpunpckhdq xmm_k1z, xmm, xmm","vpunpckhdq xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpunpckhdq_xmm_k1z_xmm_xmm = 4454,
    /// <summary>
    /// vpunpckhdq xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpunpckhdq xmm_k1z, xmm, m128","vpunpckhdq xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpunpckhdq_xmm_k1z_xmm_m128 = 4455,
    /// <summary>
    /// vpunpckhdq xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpunpckhdq xmm_k1z, xmm, m32bcst","vpunpckhdq xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpunpckhdq_xmm_k1z_xmm_m32bcst = 4456,
    /// <summary>
    /// vpunpckhdq ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpunpckhdq ymm, ymm, ymm","vpunpckhdq ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpunpckhdq_ymm_ymm_ymm = 4457,
    /// <summary>
    /// vpunpckhdq ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpunpckhdq ymm, ymm, m256","vpunpckhdq ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpunpckhdq_ymm_ymm_m256 = 4458,
    /// <summary>
    /// vpunpckhdq ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpunpckhdq ymm, ymm, m32bcst","vpunpckhdq ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpunpckhdq_ymm_ymm_m32bcst = 4459,
    /// <summary>
    /// vpunpckhdq ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpunpckhdq ymm_k1z, ymm, ymm","vpunpckhdq ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpunpckhdq_ymm_k1z_ymm_ymm = 4460,
    /// <summary>
    /// vpunpckhdq ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpunpckhdq ymm_k1z, ymm, m256","vpunpckhdq ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpunpckhdq_ymm_k1z_ymm_m256 = 4461,
    /// <summary>
    /// vpunpckhdq ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpunpckhdq ymm_k1z, ymm, m32bcst","vpunpckhdq ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpunpckhdq_ymm_k1z_ymm_m32bcst = 4462,
    /// <summary>
    /// vpunpckhdq zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpunpckhdq zmm, zmm, zmm","vpunpckhdq zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpunpckhdq_zmm_zmm_zmm = 4463,
    /// <summary>
    /// vpunpckhdq zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpunpckhdq zmm, zmm, m512","vpunpckhdq zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpunpckhdq_zmm_zmm_m512 = 4464,
    /// <summary>
    /// vpunpckhdq zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpunpckhdq zmm, zmm, m32bcst","vpunpckhdq zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpunpckhdq_zmm_zmm_m32bcst = 4465,
    /// <summary>
    /// vpunpckhdq zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpunpckhdq zmm_k1z, zmm, zmm","vpunpckhdq zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpunpckhdq_zmm_k1z_zmm_zmm = 4466,
    /// <summary>
    /// vpunpckhdq zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpunpckhdq zmm_k1z, zmm, m512","vpunpckhdq zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpunpckhdq_zmm_k1z_zmm_m512 = 4467,
    /// <summary>
    /// vpunpckhdq zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpunpckhdq zmm_k1z, zmm, m32bcst","vpunpckhdq zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpunpckhdq_zmm_k1z_zmm_m32bcst = 4468,
    /// <summary>
    /// vpunpckhqdq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpunpckhqdq xmm, xmm, xmm","vpunpckhqdq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpunpckhqdq_xmm_xmm_xmm = 4469,
    /// <summary>
    /// vpunpckhqdq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpunpckhqdq xmm, xmm, m128","vpunpckhqdq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpunpckhqdq_xmm_xmm_m128 = 4470,
    /// <summary>
    /// vpunpckhqdq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpunpckhqdq xmm, xmm, m64bcst","vpunpckhqdq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpunpckhqdq_xmm_xmm_m64bcst = 4471,
    /// <summary>
    /// vpunpckhqdq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpunpckhqdq xmm_k1z, xmm, xmm","vpunpckhqdq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpunpckhqdq_xmm_k1z_xmm_xmm = 4472,
    /// <summary>
    /// vpunpckhqdq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpunpckhqdq xmm_k1z, xmm, m128","vpunpckhqdq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpunpckhqdq_xmm_k1z_xmm_m128 = 4473,
    /// <summary>
    /// vpunpckhqdq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpunpckhqdq xmm_k1z, xmm, m64bcst","vpunpckhqdq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpunpckhqdq_xmm_k1z_xmm_m64bcst = 4474,
    /// <summary>
    /// vpunpckhqdq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpunpckhqdq ymm, ymm, ymm","vpunpckhqdq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpunpckhqdq_ymm_ymm_ymm = 4475,
    /// <summary>
    /// vpunpckhqdq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpunpckhqdq ymm, ymm, m256","vpunpckhqdq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpunpckhqdq_ymm_ymm_m256 = 4476,
    /// <summary>
    /// vpunpckhqdq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpunpckhqdq ymm, ymm, m64bcst","vpunpckhqdq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpunpckhqdq_ymm_ymm_m64bcst = 4477,
    /// <summary>
    /// vpunpckhqdq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpunpckhqdq ymm_k1z, ymm, ymm","vpunpckhqdq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpunpckhqdq_ymm_k1z_ymm_ymm = 4478,
    /// <summary>
    /// vpunpckhqdq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpunpckhqdq ymm_k1z, ymm, m256","vpunpckhqdq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpunpckhqdq_ymm_k1z_ymm_m256 = 4479,
    /// <summary>
    /// vpunpckhqdq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpunpckhqdq ymm_k1z, ymm, m64bcst","vpunpckhqdq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpunpckhqdq_ymm_k1z_ymm_m64bcst = 4480,
    /// <summary>
    /// vpunpckhqdq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpunpckhqdq zmm, zmm, zmm","vpunpckhqdq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpunpckhqdq_zmm_zmm_zmm = 4481,
    /// <summary>
    /// vpunpckhqdq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpunpckhqdq zmm, zmm, m512","vpunpckhqdq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpunpckhqdq_zmm_zmm_m512 = 4482,
    /// <summary>
    /// vpunpckhqdq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpunpckhqdq zmm, zmm, m64bcst","vpunpckhqdq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpunpckhqdq_zmm_zmm_m64bcst = 4483,
    /// <summary>
    /// vpunpckhqdq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpunpckhqdq zmm_k1z, zmm, zmm","vpunpckhqdq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpunpckhqdq_zmm_k1z_zmm_zmm = 4484,
    /// <summary>
    /// vpunpckhqdq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpunpckhqdq zmm_k1z, zmm, m512","vpunpckhqdq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpunpckhqdq_zmm_k1z_zmm_m512 = 4485,
    /// <summary>
    /// vpunpckhqdq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpunpckhqdq zmm_k1z, zmm, m64bcst","vpunpckhqdq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpunpckhqdq_zmm_k1z_zmm_m64bcst = 4486,
    /// <summary>
    /// vpunpckhwd xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpunpckhwd xmm, xmm, xmm","vpunpckhwd xmm {k1}{z}, xmm, xmm/m128")]
    vpunpckhwd_xmm_xmm_xmm = 4487,
    /// <summary>
    /// vpunpckhwd xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpunpckhwd xmm, xmm, m128","vpunpckhwd xmm {k1}{z}, xmm, xmm/m128")]
    vpunpckhwd_xmm_xmm_m128 = 4488,
    /// <summary>
    /// vpunpckhwd xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpunpckhwd xmm_k1z, xmm, xmm","vpunpckhwd xmm {k1}{z}, xmm, xmm/m128")]
    vpunpckhwd_xmm_k1z_xmm_xmm = 4489,
    /// <summary>
    /// vpunpckhwd xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpunpckhwd xmm_k1z, xmm, m128","vpunpckhwd xmm {k1}{z}, xmm, xmm/m128")]
    vpunpckhwd_xmm_k1z_xmm_m128 = 4490,
    /// <summary>
    /// vpunpckhwd ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpunpckhwd ymm, ymm, ymm","vpunpckhwd ymm {k1}{z}, ymm, ymm/m256")]
    vpunpckhwd_ymm_ymm_ymm = 4491,
    /// <summary>
    /// vpunpckhwd ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpunpckhwd ymm, ymm, m256","vpunpckhwd ymm {k1}{z}, ymm, ymm/m256")]
    vpunpckhwd_ymm_ymm_m256 = 4492,
    /// <summary>
    /// vpunpckhwd ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpunpckhwd ymm_k1z, ymm, ymm","vpunpckhwd ymm {k1}{z}, ymm, ymm/m256")]
    vpunpckhwd_ymm_k1z_ymm_ymm = 4493,
    /// <summary>
    /// vpunpckhwd ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpunpckhwd ymm_k1z, ymm, m256","vpunpckhwd ymm {k1}{z}, ymm, ymm/m256")]
    vpunpckhwd_ymm_k1z_ymm_m256 = 4494,
    /// <summary>
    /// vpunpckhwd zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpunpckhwd zmm, zmm, zmm","vpunpckhwd zmm {k1}{z}, zmm, zmm/m512")]
    vpunpckhwd_zmm_zmm_zmm = 4495,
    /// <summary>
    /// vpunpckhwd zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpunpckhwd zmm, zmm, m512","vpunpckhwd zmm {k1}{z}, zmm, zmm/m512")]
    vpunpckhwd_zmm_zmm_m512 = 4496,
    /// <summary>
    /// vpunpckhwd zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpunpckhwd zmm_k1z, zmm, zmm","vpunpckhwd zmm {k1}{z}, zmm, zmm/m512")]
    vpunpckhwd_zmm_k1z_zmm_zmm = 4497,
    /// <summary>
    /// vpunpckhwd zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpunpckhwd zmm_k1z, zmm, m512","vpunpckhwd zmm {k1}{z}, zmm, zmm/m512")]
    vpunpckhwd_zmm_k1z_zmm_m512 = 4498,
    /// <summary>
    /// vpunpcklbw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpunpcklbw xmm, xmm, xmm","vpunpcklbw xmm {k1}{z}, xmm, xmm/m128")]
    vpunpcklbw_xmm_xmm_xmm = 4499,
    /// <summary>
    /// vpunpcklbw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpunpcklbw xmm, xmm, m128","vpunpcklbw xmm {k1}{z}, xmm, xmm/m128")]
    vpunpcklbw_xmm_xmm_m128 = 4500,
    /// <summary>
    /// vpunpcklbw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpunpcklbw xmm_k1z, xmm, xmm","vpunpcklbw xmm {k1}{z}, xmm, xmm/m128")]
    vpunpcklbw_xmm_k1z_xmm_xmm = 4501,
    /// <summary>
    /// vpunpcklbw xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpunpcklbw xmm_k1z, xmm, m128","vpunpcklbw xmm {k1}{z}, xmm, xmm/m128")]
    vpunpcklbw_xmm_k1z_xmm_m128 = 4502,
    /// <summary>
    /// vpunpcklbw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpunpcklbw ymm, ymm, ymm","vpunpcklbw ymm {k1}{z}, ymm, ymm/m256")]
    vpunpcklbw_ymm_ymm_ymm = 4503,
    /// <summary>
    /// vpunpcklbw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpunpcklbw ymm, ymm, m256","vpunpcklbw ymm {k1}{z}, ymm, ymm/m256")]
    vpunpcklbw_ymm_ymm_m256 = 4504,
    /// <summary>
    /// vpunpcklbw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpunpcklbw ymm_k1z, ymm, ymm","vpunpcklbw ymm {k1}{z}, ymm, ymm/m256")]
    vpunpcklbw_ymm_k1z_ymm_ymm = 4505,
    /// <summary>
    /// vpunpcklbw ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpunpcklbw ymm_k1z, ymm, m256","vpunpcklbw ymm {k1}{z}, ymm, ymm/m256")]
    vpunpcklbw_ymm_k1z_ymm_m256 = 4506,
    /// <summary>
    /// vpunpcklbw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpunpcklbw zmm, zmm, zmm","vpunpcklbw zmm {k1}{z}, zmm, zmm/m512")]
    vpunpcklbw_zmm_zmm_zmm = 4507,
    /// <summary>
    /// vpunpcklbw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpunpcklbw zmm, zmm, m512","vpunpcklbw zmm {k1}{z}, zmm, zmm/m512")]
    vpunpcklbw_zmm_zmm_m512 = 4508,
    /// <summary>
    /// vpunpcklbw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpunpcklbw zmm_k1z, zmm, zmm","vpunpcklbw zmm {k1}{z}, zmm, zmm/m512")]
    vpunpcklbw_zmm_k1z_zmm_zmm = 4509,
    /// <summary>
    /// vpunpcklbw zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpunpcklbw zmm_k1z, zmm, m512","vpunpcklbw zmm {k1}{z}, zmm, zmm/m512")]
    vpunpcklbw_zmm_k1z_zmm_m512 = 4510,
    /// <summary>
    /// vpunpckldq xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpunpckldq xmm, xmm, xmm","vpunpckldq xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpunpckldq_xmm_xmm_xmm = 4511,
    /// <summary>
    /// vpunpckldq xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpunpckldq xmm, xmm, m128","vpunpckldq xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpunpckldq_xmm_xmm_m128 = 4512,
    /// <summary>
    /// vpunpckldq xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpunpckldq xmm, xmm, m32bcst","vpunpckldq xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpunpckldq_xmm_xmm_m32bcst = 4513,
    /// <summary>
    /// vpunpckldq xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpunpckldq xmm_k1z, xmm, xmm","vpunpckldq xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpunpckldq_xmm_k1z_xmm_xmm = 4514,
    /// <summary>
    /// vpunpckldq xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpunpckldq xmm_k1z, xmm, m128","vpunpckldq xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpunpckldq_xmm_k1z_xmm_m128 = 4515,
    /// <summary>
    /// vpunpckldq xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpunpckldq xmm_k1z, xmm, m32bcst","vpunpckldq xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpunpckldq_xmm_k1z_xmm_m32bcst = 4516,
    /// <summary>
    /// vpunpckldq ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpunpckldq ymm, ymm, ymm","vpunpckldq ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpunpckldq_ymm_ymm_ymm = 4517,
    /// <summary>
    /// vpunpckldq ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpunpckldq ymm, ymm, m256","vpunpckldq ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpunpckldq_ymm_ymm_m256 = 4518,
    /// <summary>
    /// vpunpckldq ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpunpckldq ymm, ymm, m32bcst","vpunpckldq ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpunpckldq_ymm_ymm_m32bcst = 4519,
    /// <summary>
    /// vpunpckldq ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpunpckldq ymm_k1z, ymm, ymm","vpunpckldq ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpunpckldq_ymm_k1z_ymm_ymm = 4520,
    /// <summary>
    /// vpunpckldq ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpunpckldq ymm_k1z, ymm, m256","vpunpckldq ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpunpckldq_ymm_k1z_ymm_m256 = 4521,
    /// <summary>
    /// vpunpckldq ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpunpckldq ymm_k1z, ymm, m32bcst","vpunpckldq ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpunpckldq_ymm_k1z_ymm_m32bcst = 4522,
    /// <summary>
    /// vpunpckldq zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpunpckldq zmm, zmm, zmm","vpunpckldq zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpunpckldq_zmm_zmm_zmm = 4523,
    /// <summary>
    /// vpunpckldq zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpunpckldq zmm, zmm, m512","vpunpckldq zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpunpckldq_zmm_zmm_m512 = 4524,
    /// <summary>
    /// vpunpckldq zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpunpckldq zmm, zmm, m32bcst","vpunpckldq zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpunpckldq_zmm_zmm_m32bcst = 4525,
    /// <summary>
    /// vpunpckldq zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpunpckldq zmm_k1z, zmm, zmm","vpunpckldq zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpunpckldq_zmm_k1z_zmm_zmm = 4526,
    /// <summary>
    /// vpunpckldq zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpunpckldq zmm_k1z, zmm, m512","vpunpckldq zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpunpckldq_zmm_k1z_zmm_m512 = 4527,
    /// <summary>
    /// vpunpckldq zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpunpckldq zmm_k1z, zmm, m32bcst","vpunpckldq zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpunpckldq_zmm_k1z_zmm_m32bcst = 4528,
    /// <summary>
    /// vpunpcklqdq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpunpcklqdq xmm, xmm, xmm","vpunpcklqdq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpunpcklqdq_xmm_xmm_xmm = 4529,
    /// <summary>
    /// vpunpcklqdq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpunpcklqdq xmm, xmm, m128","vpunpcklqdq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpunpcklqdq_xmm_xmm_m128 = 4530,
    /// <summary>
    /// vpunpcklqdq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpunpcklqdq xmm, xmm, m64bcst","vpunpcklqdq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpunpcklqdq_xmm_xmm_m64bcst = 4531,
    /// <summary>
    /// vpunpcklqdq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpunpcklqdq xmm_k1z, xmm, xmm","vpunpcklqdq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpunpcklqdq_xmm_k1z_xmm_xmm = 4532,
    /// <summary>
    /// vpunpcklqdq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpunpcklqdq xmm_k1z, xmm, m128","vpunpcklqdq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpunpcklqdq_xmm_k1z_xmm_m128 = 4533,
    /// <summary>
    /// vpunpcklqdq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpunpcklqdq xmm_k1z, xmm, m64bcst","vpunpcklqdq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpunpcklqdq_xmm_k1z_xmm_m64bcst = 4534,
    /// <summary>
    /// vpunpcklqdq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpunpcklqdq ymm, ymm, ymm","vpunpcklqdq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpunpcklqdq_ymm_ymm_ymm = 4535,
    /// <summary>
    /// vpunpcklqdq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpunpcklqdq ymm, ymm, m256","vpunpcklqdq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpunpcklqdq_ymm_ymm_m256 = 4536,
    /// <summary>
    /// vpunpcklqdq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpunpcklqdq ymm, ymm, m64bcst","vpunpcklqdq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpunpcklqdq_ymm_ymm_m64bcst = 4537,
    /// <summary>
    /// vpunpcklqdq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpunpcklqdq ymm_k1z, ymm, ymm","vpunpcklqdq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpunpcklqdq_ymm_k1z_ymm_ymm = 4538,
    /// <summary>
    /// vpunpcklqdq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpunpcklqdq ymm_k1z, ymm, m256","vpunpcklqdq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpunpcklqdq_ymm_k1z_ymm_m256 = 4539,
    /// <summary>
    /// vpunpcklqdq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpunpcklqdq ymm_k1z, ymm, m64bcst","vpunpcklqdq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpunpcklqdq_ymm_k1z_ymm_m64bcst = 4540,
    /// <summary>
    /// vpunpcklqdq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpunpcklqdq zmm, zmm, zmm","vpunpcklqdq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpunpcklqdq_zmm_zmm_zmm = 4541,
    /// <summary>
    /// vpunpcklqdq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpunpcklqdq zmm, zmm, m512","vpunpcklqdq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpunpcklqdq_zmm_zmm_m512 = 4542,
    /// <summary>
    /// vpunpcklqdq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpunpcklqdq zmm, zmm, m64bcst","vpunpcklqdq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpunpcklqdq_zmm_zmm_m64bcst = 4543,
    /// <summary>
    /// vpunpcklqdq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpunpcklqdq zmm_k1z, zmm, zmm","vpunpcklqdq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpunpcklqdq_zmm_k1z_zmm_zmm = 4544,
    /// <summary>
    /// vpunpcklqdq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpunpcklqdq zmm_k1z, zmm, m512","vpunpcklqdq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpunpcklqdq_zmm_k1z_zmm_m512 = 4545,
    /// <summary>
    /// vpunpcklqdq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpunpcklqdq zmm_k1z, zmm, m64bcst","vpunpcklqdq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpunpcklqdq_zmm_k1z_zmm_m64bcst = 4546,
    /// <summary>
    /// vpunpcklwd xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpunpcklwd xmm, xmm, xmm","vpunpcklwd xmm {k1}{z}, xmm, xmm/m128")]
    vpunpcklwd_xmm_xmm_xmm = 4547,
    /// <summary>
    /// vpunpcklwd xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpunpcklwd xmm, xmm, m128","vpunpcklwd xmm {k1}{z}, xmm, xmm/m128")]
    vpunpcklwd_xmm_xmm_m128 = 4548,
    /// <summary>
    /// vpunpcklwd xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpunpcklwd xmm_k1z, xmm, xmm","vpunpcklwd xmm {k1}{z}, xmm, xmm/m128")]
    vpunpcklwd_xmm_k1z_xmm_xmm = 4549,
    /// <summary>
    /// vpunpcklwd xmm {k1}{z}, xmm, xmm/m128
    /// </summary>
    [Symbol("vpunpcklwd xmm_k1z, xmm, m128","vpunpcklwd xmm {k1}{z}, xmm, xmm/m128")]
    vpunpcklwd_xmm_k1z_xmm_m128 = 4550,
    /// <summary>
    /// vpunpcklwd ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpunpcklwd ymm, ymm, ymm","vpunpcklwd ymm {k1}{z}, ymm, ymm/m256")]
    vpunpcklwd_ymm_ymm_ymm = 4551,
    /// <summary>
    /// vpunpcklwd ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpunpcklwd ymm, ymm, m256","vpunpcklwd ymm {k1}{z}, ymm, ymm/m256")]
    vpunpcklwd_ymm_ymm_m256 = 4552,
    /// <summary>
    /// vpunpcklwd ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpunpcklwd ymm_k1z, ymm, ymm","vpunpcklwd ymm {k1}{z}, ymm, ymm/m256")]
    vpunpcklwd_ymm_k1z_ymm_ymm = 4553,
    /// <summary>
    /// vpunpcklwd ymm {k1}{z}, ymm, ymm/m256
    /// </summary>
    [Symbol("vpunpcklwd ymm_k1z, ymm, m256","vpunpcklwd ymm {k1}{z}, ymm, ymm/m256")]
    vpunpcklwd_ymm_k1z_ymm_m256 = 4554,
    /// <summary>
    /// vpunpcklwd zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpunpcklwd zmm, zmm, zmm","vpunpcklwd zmm {k1}{z}, zmm, zmm/m512")]
    vpunpcklwd_zmm_zmm_zmm = 4555,
    /// <summary>
    /// vpunpcklwd zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpunpcklwd zmm, zmm, m512","vpunpcklwd zmm {k1}{z}, zmm, zmm/m512")]
    vpunpcklwd_zmm_zmm_m512 = 4556,
    /// <summary>
    /// vpunpcklwd zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpunpcklwd zmm_k1z, zmm, zmm","vpunpcklwd zmm {k1}{z}, zmm, zmm/m512")]
    vpunpcklwd_zmm_k1z_zmm_zmm = 4557,
    /// <summary>
    /// vpunpcklwd zmm {k1}{z}, zmm, zmm/m512
    /// </summary>
    [Symbol("vpunpcklwd zmm_k1z, zmm, m512","vpunpcklwd zmm {k1}{z}, zmm, zmm/m512")]
    vpunpcklwd_zmm_k1z_zmm_m512 = 4558,
    /// <summary>
    /// vpxor xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpxor xmm, xmm, xmm","vpxor xmm, xmm, xmm/m128")]
    vpxor_xmm_xmm_xmm = 4559,
    /// <summary>
    /// vpxor xmm, xmm, xmm/m128
    /// </summary>
    [Symbol("vpxor xmm, xmm, m128","vpxor xmm, xmm, xmm/m128")]
    vpxor_xmm_xmm_m128 = 4560,
    /// <summary>
    /// vpxor ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpxor ymm, ymm, ymm","vpxor ymm, ymm, ymm/m256")]
    vpxor_ymm_ymm_ymm = 4561,
    /// <summary>
    /// vpxor ymm, ymm, ymm/m256
    /// </summary>
    [Symbol("vpxor ymm, ymm, m256","vpxor ymm, ymm, ymm/m256")]
    vpxor_ymm_ymm_m256 = 4562,
    /// <summary>
    /// vpxord xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpxord xmm, xmm, xmm","vpxord xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpxord_xmm_xmm_xmm = 4563,
    /// <summary>
    /// vpxord xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpxord xmm, xmm, m128","vpxord xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpxord_xmm_xmm_m128 = 4564,
    /// <summary>
    /// vpxord xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpxord xmm, xmm, m32bcst","vpxord xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpxord_xmm_xmm_m32bcst = 4565,
    /// <summary>
    /// vpxord xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpxord xmm_k1z, xmm, xmm","vpxord xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpxord_xmm_k1z_xmm_xmm = 4566,
    /// <summary>
    /// vpxord xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpxord xmm_k1z, xmm, m128","vpxord xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpxord_xmm_k1z_xmm_m128 = 4567,
    /// <summary>
    /// vpxord xmm {k1}{z}, xmm, xmm/m128/m32bcst
    /// </summary>
    [Symbol("vpxord xmm_k1z, xmm, m32bcst","vpxord xmm {k1}{z}, xmm, xmm/m128/m32bcst")]
    vpxord_xmm_k1z_xmm_m32bcst = 4568,
    /// <summary>
    /// vpxord ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpxord ymm, ymm, ymm","vpxord ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpxord_ymm_ymm_ymm = 4569,
    /// <summary>
    /// vpxord ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpxord ymm, ymm, m256","vpxord ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpxord_ymm_ymm_m256 = 4570,
    /// <summary>
    /// vpxord ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpxord ymm, ymm, m32bcst","vpxord ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpxord_ymm_ymm_m32bcst = 4571,
    /// <summary>
    /// vpxord ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpxord ymm_k1z, ymm, ymm","vpxord ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpxord_ymm_k1z_ymm_ymm = 4572,
    /// <summary>
    /// vpxord ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpxord ymm_k1z, ymm, m256","vpxord ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpxord_ymm_k1z_ymm_m256 = 4573,
    /// <summary>
    /// vpxord ymm {k1}{z}, ymm, ymm/m256/m32bcst
    /// </summary>
    [Symbol("vpxord ymm_k1z, ymm, m32bcst","vpxord ymm {k1}{z}, ymm, ymm/m256/m32bcst")]
    vpxord_ymm_k1z_ymm_m32bcst = 4574,
    /// <summary>
    /// vpxord zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpxord zmm, zmm, zmm","vpxord zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpxord_zmm_zmm_zmm = 4575,
    /// <summary>
    /// vpxord zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpxord zmm, zmm, m512","vpxord zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpxord_zmm_zmm_m512 = 4576,
    /// <summary>
    /// vpxord zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpxord zmm, zmm, m32bcst","vpxord zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpxord_zmm_zmm_m32bcst = 4577,
    /// <summary>
    /// vpxord zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpxord zmm_k1z, zmm, zmm","vpxord zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpxord_zmm_k1z_zmm_zmm = 4578,
    /// <summary>
    /// vpxord zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpxord zmm_k1z, zmm, m512","vpxord zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpxord_zmm_k1z_zmm_m512 = 4579,
    /// <summary>
    /// vpxord zmm {k1}{z}, zmm, zmm/m512/m32bcst
    /// </summary>
    [Symbol("vpxord zmm_k1z, zmm, m32bcst","vpxord zmm {k1}{z}, zmm, zmm/m512/m32bcst")]
    vpxord_zmm_k1z_zmm_m32bcst = 4580,
    /// <summary>
    /// vpxorq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpxorq xmm, xmm, xmm","vpxorq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpxorq_xmm_xmm_xmm = 4581,
    /// <summary>
    /// vpxorq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpxorq xmm, xmm, m128","vpxorq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpxorq_xmm_xmm_m128 = 4582,
    /// <summary>
    /// vpxorq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpxorq xmm, xmm, m64bcst","vpxorq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpxorq_xmm_xmm_m64bcst = 4583,
    /// <summary>
    /// vpxorq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpxorq xmm_k1z, xmm, xmm","vpxorq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpxorq_xmm_k1z_xmm_xmm = 4584,
    /// <summary>
    /// vpxorq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpxorq xmm_k1z, xmm, m128","vpxorq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpxorq_xmm_k1z_xmm_m128 = 4585,
    /// <summary>
    /// vpxorq xmm {k1}{z}, xmm, xmm/m128/m64bcst
    /// </summary>
    [Symbol("vpxorq xmm_k1z, xmm, m64bcst","vpxorq xmm {k1}{z}, xmm, xmm/m128/m64bcst")]
    vpxorq_xmm_k1z_xmm_m64bcst = 4586,
    /// <summary>
    /// vpxorq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpxorq ymm, ymm, ymm","vpxorq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpxorq_ymm_ymm_ymm = 4587,
    /// <summary>
    /// vpxorq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpxorq ymm, ymm, m256","vpxorq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpxorq_ymm_ymm_m256 = 4588,
    /// <summary>
    /// vpxorq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpxorq ymm, ymm, m64bcst","vpxorq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpxorq_ymm_ymm_m64bcst = 4589,
    /// <summary>
    /// vpxorq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpxorq ymm_k1z, ymm, ymm","vpxorq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpxorq_ymm_k1z_ymm_ymm = 4590,
    /// <summary>
    /// vpxorq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpxorq ymm_k1z, ymm, m256","vpxorq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpxorq_ymm_k1z_ymm_m256 = 4591,
    /// <summary>
    /// vpxorq ymm {k1}{z}, ymm, ymm/m256/m64bcst
    /// </summary>
    [Symbol("vpxorq ymm_k1z, ymm, m64bcst","vpxorq ymm {k1}{z}, ymm, ymm/m256/m64bcst")]
    vpxorq_ymm_k1z_ymm_m64bcst = 4592,
    /// <summary>
    /// vpxorq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpxorq zmm, zmm, zmm","vpxorq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpxorq_zmm_zmm_zmm = 4593,
    /// <summary>
    /// vpxorq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpxorq zmm, zmm, m512","vpxorq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpxorq_zmm_zmm_m512 = 4594,
    /// <summary>
    /// vpxorq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpxorq zmm, zmm, m64bcst","vpxorq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpxorq_zmm_zmm_m64bcst = 4595,
    /// <summary>
    /// vpxorq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpxorq zmm_k1z, zmm, zmm","vpxorq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpxorq_zmm_k1z_zmm_zmm = 4596,
    /// <summary>
    /// vpxorq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpxorq zmm_k1z, zmm, m512","vpxorq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpxorq_zmm_k1z_zmm_m512 = 4597,
    /// <summary>
    /// vpxorq zmm {k1}{z}, zmm, zmm/m512/m64bcst
    /// </summary>
    [Symbol("vpxorq zmm_k1z, zmm, m64bcst","vpxorq zmm {k1}{z}, zmm, zmm/m512/m64bcst")]
    vpxorq_zmm_k1z_zmm_m64bcst = 4598,
    /// <summary>
    /// xbegin rel16
    /// </summary>
    [Symbol("xbegin rel16","xbegin rel16")]
    xbegin_rel16 = 4599,
    /// <summary>
    /// xbegin rel32
    /// </summary>
    [Symbol("xbegin rel32","xbegin rel32")]
    xbegin_rel32 = 4600,
    /// <summary>
    /// xchg AX, r16
    /// </summary>
    [Symbol("xchg AX, r16","xchg AX, r16")]
    xchg_AX_r16 = 4601,
    /// <summary>
    /// xchg EAX, r32
    /// </summary>
    [Symbol("xchg EAX, r32","xchg EAX, r32")]
    xchg_EAX_r32 = 4602,
    /// <summary>
    /// xchg r/m16, r16
    /// </summary>
    [Symbol("xchg r16, r16","xchg r/m16, r16")]
    xchg_r16_r16 = 4603,
    /// <summary>
    /// xchg r/m16, r16
    /// </summary>
    [Symbol("xchg m16, r16","xchg r/m16, r16")]
    xchg_m16_r16 = 4604,
    /// <summary>
    /// xchg r/m32, r32
    /// </summary>
    [Symbol("xchg r32, r32","xchg r/m32, r32")]
    xchg_r32_r32 = 4605,
    /// <summary>
    /// xchg r/m32, r32
    /// </summary>
    [Symbol("xchg m32, r32","xchg r/m32, r32")]
    xchg_m32_r32 = 4606,
    /// <summary>
    /// xchg r/m64, r64
    /// </summary>
    [Symbol("xchg r64, r64","xchg r/m64, r64")]
    xchg_r64_r64 = 4607,
    /// <summary>
    /// xchg r/m64, r64
    /// </summary>
    [Symbol("xchg m64, r64","xchg r/m64, r64")]
    xchg_m64_r64 = 4608,
    /// <summary>
    /// xchg r/m8, r8
    /// </summary>
    [Symbol("xchg r8, r8","xchg r/m8, r8")]
    xchg_r8_r8 = 4609,
    /// <summary>
    /// xchg r/m8, r8
    /// </summary>
    [Symbol("xchg m8, r8","xchg r/m8, r8")]
    xchg_m8_r8 = 4610,
    /// <summary>
    /// xchg r16, AX
    /// </summary>
    [Symbol("xchg r16, AX","xchg r16, AX")]
    xchg_r16_AX = 4611,
    /// <summary>
    /// xchg r16, r/m16
    /// </summary>
    [Symbol("xchg r16, m16","xchg r16, r/m16")]
    xchg_r16_m16 = 4612,
    /// <summary>
    /// xchg r32, EAX
    /// </summary>
    [Symbol("xchg r32, EAX","xchg r32, EAX")]
    xchg_r32_EAX = 4613,
    /// <summary>
    /// xchg r32, r/m32
    /// </summary>
    [Symbol("xchg r32, m32","xchg r32, r/m32")]
    xchg_r32_m32 = 4614,
    /// <summary>
    /// xchg r64, r/m64
    /// </summary>
    [Symbol("xchg r64, m64","xchg r64, r/m64")]
    xchg_r64_m64 = 4615,
    /// <summary>
    /// xchg r64, RAX
    /// </summary>
    [Symbol("xchg r64, RAX","xchg r64, RAX")]
    xchg_r64_RAX = 4616,
    /// <summary>
    /// xchg r8, r/m8
    /// </summary>
    [Symbol("xchg r8, m8","xchg r8, r/m8")]
    xchg_r8_m8 = 4617,
    /// <summary>
    /// xchg RAX, r64
    /// </summary>
    [Symbol("xchg RAX, r64","xchg RAX, r64")]
    xchg_RAX_r64 = 4618,
    /// <summary>
    /// xgetbv
    /// </summary>
    [Symbol("xgetbv","xgetbv")]
    xgetbv = 4619,
    /// <summary>
    /// xlat m8
    /// </summary>
    [Symbol("xlat m8","xlat m8")]
    xlat_m8 = 4620,
    /// <summary>
    /// xlatb
    /// </summary>
    [Symbol("xlatb","xlatb")]
    xlatb = 4621,
    /// <summary>
    /// xor AL, imm8
    /// </summary>
    [Symbol("xor AL, imm8","xor AL, imm8")]
    xor_AL_imm8 = 4622,
    /// <summary>
    /// xor AX, imm16
    /// </summary>
    [Symbol("xor AX, imm16","xor AX, imm16")]
    xor_AX_imm16 = 4623,
    /// <summary>
    /// xor EAX, imm32
    /// </summary>
    [Symbol("xor EAX, imm32","xor EAX, imm32")]
    xor_EAX_imm32 = 4624,
    /// <summary>
    /// xor r/m16, imm16
    /// </summary>
    [Symbol("xor r16, imm16","xor r/m16, imm16")]
    xor_r16_imm16 = 4625,
    /// <summary>
    /// xor r/m16, imm16
    /// </summary>
    [Symbol("xor m16, imm16","xor r/m16, imm16")]
    xor_m16_imm16 = 4626,
    /// <summary>
    /// xor r/m16, imm8
    /// </summary>
    [Symbol("xor r16, imm8","xor r/m16, imm8")]
    xor_r16_imm8 = 4627,
    /// <summary>
    /// xor r/m16, imm8
    /// </summary>
    [Symbol("xor m16, imm8","xor r/m16, imm8")]
    xor_m16_imm8 = 4628,
    /// <summary>
    /// xor r/m16, r16
    /// </summary>
    [Symbol("xor r16, r16","xor r/m16, r16")]
    xor_r16_r16 = 4629,
    /// <summary>
    /// xor r/m16, r16
    /// </summary>
    [Symbol("xor m16, r16","xor r/m16, r16")]
    xor_m16_r16 = 4630,
    /// <summary>
    /// xor r/m32, imm32
    /// </summary>
    [Symbol("xor r32, imm32","xor r/m32, imm32")]
    xor_r32_imm32 = 4631,
    /// <summary>
    /// xor r/m32, imm32
    /// </summary>
    [Symbol("xor m32, imm32","xor r/m32, imm32")]
    xor_m32_imm32 = 4632,
    /// <summary>
    /// xor r/m32, imm8
    /// </summary>
    [Symbol("xor r32, imm8","xor r/m32, imm8")]
    xor_r32_imm8 = 4633,
    /// <summary>
    /// xor r/m32, imm8
    /// </summary>
    [Symbol("xor m32, imm8","xor r/m32, imm8")]
    xor_m32_imm8 = 4634,
    /// <summary>
    /// xor r/m32, r32
    /// </summary>
    [Symbol("xor r32, r32","xor r/m32, r32")]
    xor_r32_r32 = 4635,
    /// <summary>
    /// xor r/m32, r32
    /// </summary>
    [Symbol("xor m32, r32","xor r/m32, r32")]
    xor_m32_r32 = 4636,
    /// <summary>
    /// xor r/m64, imm32
    /// </summary>
    [Symbol("xor r64, imm32","xor r/m64, imm32")]
    xor_r64_imm32 = 4637,
    /// <summary>
    /// xor r/m64, imm32
    /// </summary>
    [Symbol("xor m64, imm32","xor r/m64, imm32")]
    xor_m64_imm32 = 4638,
    /// <summary>
    /// xor r/m64, imm8
    /// </summary>
    [Symbol("xor r64, imm8","xor r/m64, imm8")]
    xor_r64_imm8 = 4639,
    /// <summary>
    /// xor r/m64, imm8
    /// </summary>
    [Symbol("xor m64, imm8","xor r/m64, imm8")]
    xor_m64_imm8 = 4640,
    /// <summary>
    /// xor r/m64, r64
    /// </summary>
    [Symbol("xor r64, r64","xor r/m64, r64")]
    xor_r64_r64 = 4641,
    /// <summary>
    /// xor r/m64, r64
    /// </summary>
    [Symbol("xor m64, r64","xor r/m64, r64")]
    xor_m64_r64 = 4642,
    /// <summary>
    /// xor r/m8, imm8
    /// </summary>
    [Symbol("xor r8, imm8","xor r/m8, imm8")]
    xor_r8_imm8 = 4643,
    /// <summary>
    /// xor r/m8, imm8
    /// </summary>
    [Symbol("xor m8, imm8","xor r/m8, imm8")]
    xor_m8_imm8 = 4644,
    /// <summary>
    /// xor r/m8, r8
    /// </summary>
    [Symbol("xor r8, r8","xor r/m8, r8")]
    xor_r8_r8 = 4645,
    /// <summary>
    /// xor r/m8, r8
    /// </summary>
    [Symbol("xor m8, r8","xor r/m8, r8")]
    xor_m8_r8 = 4646,
    /// <summary>
    /// xor r16, r/m16
    /// </summary>
    [Symbol("xor r16, m16","xor r16, r/m16")]
    xor_r16_m16 = 4647,
    /// <summary>
    /// xor r32, r/m32
    /// </summary>
    [Symbol("xor r32, m32","xor r32, r/m32")]
    xor_r32_m32 = 4648,
    /// <summary>
    /// xor r64, r/m64
    /// </summary>
    [Symbol("xor r64, m64","xor r64, r/m64")]
    xor_r64_m64 = 4649,
    /// <summary>
    /// xor r8, r/m8
    /// </summary>
    [Symbol("xor r8, m8","xor r8, r/m8")]
    xor_r8_m8 = 4650,
    /// <summary>
    /// xor RAX, imm32
    /// </summary>
    [Symbol("xor RAX, imm32","xor RAX, imm32")]
    xor_RAX_imm32 = 4651,
    /// <summary>
    /// xsave mem
    /// </summary>
    [Symbol("xsave mem","xsave mem")]
    xsave_mem = 4652,
    /// <summary>
    /// xsave64 mem
    /// </summary>
    [Symbol("xsave64 mem","xsave64 mem")]
    xsave64_mem = 4653,
    /// <summary>
    /// xsavec mem
    /// </summary>
    [Symbol("xsavec mem","xsavec mem")]
    xsavec_mem = 4654,
    /// <summary>
    /// xsavec64 mem
    /// </summary>
    [Symbol("xsavec64 mem","xsavec64 mem")]
    xsavec64_mem = 4655,
    /// <summary>
    /// xsetbv
    /// </summary>
    [Symbol("xsetbv","xsetbv")]
    xsetbv = 4656,
    }
}

