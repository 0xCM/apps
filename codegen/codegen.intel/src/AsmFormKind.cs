namespace Z0.Asm
{
    /// <summary>
/// Defines asm form classifiers
/// </summary>
    [SymSource("asm")]
    public enum AsmFormKind : ushort
    {
        None = 0,

        /// <summary>
        /// aaa |  | 
        /// </summary>
        [Symbol("aaa","aaa |  | ")]
        aaa = 1,

        /// <summary>
        /// aad |  | 
        /// </summary>
        [Symbol("aad","aad |  | ")]
        aad = 2,

        /// <summary>
        /// aad imm8 |  | 
        /// </summary>
        [Symbol("aad imm8","aad imm8 |  | ")]
        aad_imm8 = 3,

        /// <summary>
        /// adc AL, imm8 |  | 
        /// </summary>
        [Symbol("adc AL, imm8","adc AL, imm8 |  | ")]
        adc_AL_imm8 = 4,

        /// <summary>
        /// adc AX, imm16 |  | 
        /// </summary>
        [Symbol("adc AX, imm16","adc AX, imm16 |  | ")]
        adc_AX_imm16 = 5,

        /// <summary>
        /// adc EAX, imm32 |  | 
        /// </summary>
        [Symbol("adc EAX, imm32","adc EAX, imm32 |  | ")]
        adc_EAX_imm32 = 6,

        /// <summary>
        /// adc m16, imm16 |  | 
        /// </summary>
        [Symbol("adc m16, imm16","adc m16, imm16 |  | ")]
        adc_m16_imm16 = 7,

        /// <summary>
        /// adc m16, imm8 |  | 
        /// </summary>
        [Symbol("adc m16, imm8","adc m16, imm8 |  | ")]
        adc_m16_imm8 = 8,

        /// <summary>
        /// adc m16, r16 |  | 
        /// </summary>
        [Symbol("adc m16, r16","adc m16, r16 |  | ")]
        adc_m16_r16 = 9,

        /// <summary>
        /// adc m32, imm32 |  | 
        /// </summary>
        [Symbol("adc m32, imm32","adc m32, imm32 |  | ")]
        adc_m32_imm32 = 10,

        /// <summary>
        /// adc m32, imm8 |  | 
        /// </summary>
        [Symbol("adc m32, imm8","adc m32, imm8 |  | ")]
        adc_m32_imm8 = 11,

        /// <summary>
        /// adc m32, r32 |  | 
        /// </summary>
        [Symbol("adc m32, r32","adc m32, r32 |  | ")]
        adc_m32_r32 = 12,

        /// <summary>
        /// adc m64, imm32 |  | 
        /// </summary>
        [Symbol("adc m64, imm32","adc m64, imm32 |  | ")]
        adc_m64_imm32 = 13,

        /// <summary>
        /// adc m64, imm8 |  | 
        /// </summary>
        [Symbol("adc m64, imm8","adc m64, imm8 |  | ")]
        adc_m64_imm8 = 14,

        /// <summary>
        /// adc m64, r64 |  | 
        /// </summary>
        [Symbol("adc m64, r64","adc m64, r64 |  | ")]
        adc_m64_r64 = 15,

        /// <summary>
        /// adc m8, imm8 |  | 
        /// </summary>
        [Symbol("adc m8, imm8","adc m8, imm8 |  | ")]
        adc_m8_imm8 = 16,

        /// <summary>
        /// adc m8, r8 |  | 
        /// </summary>
        [Symbol("adc m8, r8","adc m8, r8 |  | ")]
        adc_m8_r8 = 17,

        /// <summary>
        /// adc r16, imm16 |  | 
        /// </summary>
        [Symbol("adc r16, imm16","adc r16, imm16 |  | ")]
        adc_r16_imm16 = 18,

        /// <summary>
        /// adc r16, imm8 |  | 
        /// </summary>
        [Symbol("adc r16, imm8","adc r16, imm8 |  | ")]
        adc_r16_imm8 = 19,

        /// <summary>
        /// adc r16, m16 |  | 
        /// </summary>
        [Symbol("adc r16, m16","adc r16, m16 |  | ")]
        adc_r16_m16 = 20,

        /// <summary>
        /// adc r16, r16 |  | 
        /// </summary>
        [Symbol("adc r16, r16","adc r16, r16 |  | ")]
        adc_r16_r16 = 21,

        /// <summary>
        /// adc r32, imm32 |  | 
        /// </summary>
        [Symbol("adc r32, imm32","adc r32, imm32 |  | ")]
        adc_r32_imm32 = 22,

        /// <summary>
        /// adc r32, imm8 |  | 
        /// </summary>
        [Symbol("adc r32, imm8","adc r32, imm8 |  | ")]
        adc_r32_imm8 = 23,

        /// <summary>
        /// adc r32, m32 |  | 
        /// </summary>
        [Symbol("adc r32, m32","adc r32, m32 |  | ")]
        adc_r32_m32 = 24,

        /// <summary>
        /// adc r32, r32 |  | 
        /// </summary>
        [Symbol("adc r32, r32","adc r32, r32 |  | ")]
        adc_r32_r32 = 25,

        /// <summary>
        /// adc r64, imm32 |  | 
        /// </summary>
        [Symbol("adc r64, imm32","adc r64, imm32 |  | ")]
        adc_r64_imm32 = 26,

        /// <summary>
        /// adc r64, imm8 |  | 
        /// </summary>
        [Symbol("adc r64, imm8","adc r64, imm8 |  | ")]
        adc_r64_imm8 = 27,

        /// <summary>
        /// adc r64, m64 |  | 
        /// </summary>
        [Symbol("adc r64, m64","adc r64, m64 |  | ")]
        adc_r64_m64 = 28,

        /// <summary>
        /// adc r64, r64 |  | 
        /// </summary>
        [Symbol("adc r64, r64","adc r64, r64 |  | ")]
        adc_r64_r64 = 29,

        /// <summary>
        /// adc r8, imm8 |  | 
        /// </summary>
        [Symbol("adc r8, imm8","adc r8, imm8 |  | ")]
        adc_r8_imm8 = 30,

        /// <summary>
        /// adc r8, m8 |  | 
        /// </summary>
        [Symbol("adc r8, m8","adc r8, m8 |  | ")]
        adc_r8_m8 = 31,

        /// <summary>
        /// adc r8, r8 |  | 
        /// </summary>
        [Symbol("adc r8, r8","adc r8, r8 |  | ")]
        adc_r8_r8 = 32,

        /// <summary>
        /// adc RAX, imm32 |  | 
        /// </summary>
        [Symbol("adc RAX, imm32","adc RAX, imm32 |  | ")]
        adc_RAX_imm32 = 33,

        /// <summary>
        /// adcx r32, m32 |  | 
        /// </summary>
        [Symbol("adcx r32, m32","adcx r32, m32 |  | ")]
        adcx_r32_m32 = 34,

        /// <summary>
        /// adcx r32, r32 |  | 
        /// </summary>
        [Symbol("adcx r32, r32","adcx r32, r32 |  | ")]
        adcx_r32_r32 = 35,

        /// <summary>
        /// adcx r64, m64 |  | 
        /// </summary>
        [Symbol("adcx r64, m64","adcx r64, m64 |  | ")]
        adcx_r64_m64 = 36,

        /// <summary>
        /// adcx r64, r64 |  | 
        /// </summary>
        [Symbol("adcx r64, r64","adcx r64, r64 |  | ")]
        adcx_r64_r64 = 37,

        /// <summary>
        /// add AL, imm8 |  | 
        /// </summary>
        [Symbol("add AL, imm8","add AL, imm8 |  | ")]
        add_AL_imm8 = 38,

        /// <summary>
        /// add AX, imm16 |  | 
        /// </summary>
        [Symbol("add AX, imm16","add AX, imm16 |  | ")]
        add_AX_imm16 = 39,

        /// <summary>
        /// add EAX, imm32 |  | 
        /// </summary>
        [Symbol("add EAX, imm32","add EAX, imm32 |  | ")]
        add_EAX_imm32 = 40,

        /// <summary>
        /// add m16, imm16 |  | 
        /// </summary>
        [Symbol("add m16, imm16","add m16, imm16 |  | ")]
        add_m16_imm16 = 41,

        /// <summary>
        /// add m16, imm8 |  | 
        /// </summary>
        [Symbol("add m16, imm8","add m16, imm8 |  | ")]
        add_m16_imm8 = 42,

        /// <summary>
        /// add m16, r16 |  | 
        /// </summary>
        [Symbol("add m16, r16","add m16, r16 |  | ")]
        add_m16_r16 = 43,

        /// <summary>
        /// add m32, imm32 |  | 
        /// </summary>
        [Symbol("add m32, imm32","add m32, imm32 |  | ")]
        add_m32_imm32 = 44,

        /// <summary>
        /// add m32, imm8 |  | 
        /// </summary>
        [Symbol("add m32, imm8","add m32, imm8 |  | ")]
        add_m32_imm8 = 45,

        /// <summary>
        /// add m32, r32 |  | 
        /// </summary>
        [Symbol("add m32, r32","add m32, r32 |  | ")]
        add_m32_r32 = 46,

        /// <summary>
        /// add m64, imm32 |  | 
        /// </summary>
        [Symbol("add m64, imm32","add m64, imm32 |  | ")]
        add_m64_imm32 = 47,

        /// <summary>
        /// add m64, imm8 |  | 
        /// </summary>
        [Symbol("add m64, imm8","add m64, imm8 |  | ")]
        add_m64_imm8 = 48,

        /// <summary>
        /// add m64, r64 |  | 
        /// </summary>
        [Symbol("add m64, r64","add m64, r64 |  | ")]
        add_m64_r64 = 49,

        /// <summary>
        /// add m8, imm8 |  | 
        /// </summary>
        [Symbol("add m8, imm8","add m8, imm8 |  | ")]
        add_m8_imm8 = 50,

        /// <summary>
        /// add m8, r8 |  | 
        /// </summary>
        [Symbol("add m8, r8","add m8, r8 |  | ")]
        add_m8_r8 = 51,

        /// <summary>
        /// add r16, imm16 |  | 
        /// </summary>
        [Symbol("add r16, imm16","add r16, imm16 |  | ")]
        add_r16_imm16 = 52,

        /// <summary>
        /// add r16, imm8 |  | 
        /// </summary>
        [Symbol("add r16, imm8","add r16, imm8 |  | ")]
        add_r16_imm8 = 53,

        /// <summary>
        /// add r16, m16 |  | 
        /// </summary>
        [Symbol("add r16, m16","add r16, m16 |  | ")]
        add_r16_m16 = 54,

        /// <summary>
        /// add r16, r16 |  | 
        /// </summary>
        [Symbol("add r16, r16","add r16, r16 |  | ")]
        add_r16_r16 = 55,

        /// <summary>
        /// add r32, imm32 |  | 
        /// </summary>
        [Symbol("add r32, imm32","add r32, imm32 |  | ")]
        add_r32_imm32 = 56,

        /// <summary>
        /// add r32, imm8 |  | 
        /// </summary>
        [Symbol("add r32, imm8","add r32, imm8 |  | ")]
        add_r32_imm8 = 57,

        /// <summary>
        /// add r32, m32 |  | 
        /// </summary>
        [Symbol("add r32, m32","add r32, m32 |  | ")]
        add_r32_m32 = 58,

        /// <summary>
        /// add r32, r32 |  | 
        /// </summary>
        [Symbol("add r32, r32","add r32, r32 |  | ")]
        add_r32_r32 = 59,

        /// <summary>
        /// add r64, imm32 |  | 
        /// </summary>
        [Symbol("add r64, imm32","add r64, imm32 |  | ")]
        add_r64_imm32 = 60,

        /// <summary>
        /// add r64, imm8 |  | 
        /// </summary>
        [Symbol("add r64, imm8","add r64, imm8 |  | ")]
        add_r64_imm8 = 61,

        /// <summary>
        /// add r64, m64 |  | 
        /// </summary>
        [Symbol("add r64, m64","add r64, m64 |  | ")]
        add_r64_m64 = 62,

        /// <summary>
        /// add r64, r64 |  | 
        /// </summary>
        [Symbol("add r64, r64","add r64, r64 |  | ")]
        add_r64_r64 = 63,

        /// <summary>
        /// add r8, imm8 |  | 
        /// </summary>
        [Symbol("add r8, imm8","add r8, imm8 |  | ")]
        add_r8_imm8 = 64,

        /// <summary>
        /// add r8, m8 |  | 
        /// </summary>
        [Symbol("add r8, m8","add r8, m8 |  | ")]
        add_r8_m8 = 65,

        /// <summary>
        /// add r8, r8 |  | 
        /// </summary>
        [Symbol("add r8, r8","add r8, r8 |  | ")]
        add_r8_r8 = 66,

        /// <summary>
        /// add RAX, imm32 |  | 
        /// </summary>
        [Symbol("add RAX, imm32","add RAX, imm32 |  | ")]
        add_RAX_imm32 = 67,

        /// <summary>
        /// addpd xmm, m128 |  | 
        /// </summary>
        [Symbol("addpd xmm, m128","addpd xmm, m128 |  | ")]
        addpd_xmm_m128 = 68,

        /// <summary>
        /// addpd xmm, r8 |  | 
        /// </summary>
        [Symbol("addpd xmm, r8","addpd xmm, r8 |  | ")]
        addpd_xmm_r8 = 69,

        /// <summary>
        /// and AL, imm8 |  | 
        /// </summary>
        [Symbol("and AL, imm8","and AL, imm8 |  | ")]
        and_AL_imm8 = 70,

        /// <summary>
        /// and AX, imm16 |  | 
        /// </summary>
        [Symbol("and AX, imm16","and AX, imm16 |  | ")]
        and_AX_imm16 = 71,

        /// <summary>
        /// and EAX, imm32 |  | 
        /// </summary>
        [Symbol("and EAX, imm32","and EAX, imm32 |  | ")]
        and_EAX_imm32 = 72,

        /// <summary>
        /// and m16, imm16 |  | 
        /// </summary>
        [Symbol("and m16, imm16","and m16, imm16 |  | ")]
        and_m16_imm16 = 73,

        /// <summary>
        /// and m16, imm8 |  | 
        /// </summary>
        [Symbol("and m16, imm8","and m16, imm8 |  | ")]
        and_m16_imm8 = 74,

        /// <summary>
        /// and m16, r16 |  | 
        /// </summary>
        [Symbol("and m16, r16","and m16, r16 |  | ")]
        and_m16_r16 = 75,

        /// <summary>
        /// and m32, imm32 |  | 
        /// </summary>
        [Symbol("and m32, imm32","and m32, imm32 |  | ")]
        and_m32_imm32 = 76,

        /// <summary>
        /// and m32, imm8 |  | 
        /// </summary>
        [Symbol("and m32, imm8","and m32, imm8 |  | ")]
        and_m32_imm8 = 77,

        /// <summary>
        /// and m32, r32 |  | 
        /// </summary>
        [Symbol("and m32, r32","and m32, r32 |  | ")]
        and_m32_r32 = 78,

        /// <summary>
        /// and m64, imm32 |  | 
        /// </summary>
        [Symbol("and m64, imm32","and m64, imm32 |  | ")]
        and_m64_imm32 = 79,

        /// <summary>
        /// and m64, imm8 |  | 
        /// </summary>
        [Symbol("and m64, imm8","and m64, imm8 |  | ")]
        and_m64_imm8 = 80,

        /// <summary>
        /// and m64, r64 |  | 
        /// </summary>
        [Symbol("and m64, r64","and m64, r64 |  | ")]
        and_m64_r64 = 81,

        /// <summary>
        /// and m8, imm8 |  | 
        /// </summary>
        [Symbol("and m8, imm8","and m8, imm8 |  | ")]
        and_m8_imm8 = 82,

        /// <summary>
        /// and m8, r8 |  | 
        /// </summary>
        [Symbol("and m8, r8","and m8, r8 |  | ")]
        and_m8_r8 = 83,

        /// <summary>
        /// and r16, imm16 |  | 
        /// </summary>
        [Symbol("and r16, imm16","and r16, imm16 |  | ")]
        and_r16_imm16 = 84,

        /// <summary>
        /// and r16, imm8 |  | 
        /// </summary>
        [Symbol("and r16, imm8","and r16, imm8 |  | ")]
        and_r16_imm8 = 85,

        /// <summary>
        /// and r16, m16 |  | 
        /// </summary>
        [Symbol("and r16, m16","and r16, m16 |  | ")]
        and_r16_m16 = 86,

        /// <summary>
        /// and r16, r16 |  | 
        /// </summary>
        [Symbol("and r16, r16","and r16, r16 |  | ")]
        and_r16_r16 = 87,

        /// <summary>
        /// and r32, imm32 |  | 
        /// </summary>
        [Symbol("and r32, imm32","and r32, imm32 |  | ")]
        and_r32_imm32 = 88,

        /// <summary>
        /// and r32, imm8 |  | 
        /// </summary>
        [Symbol("and r32, imm8","and r32, imm8 |  | ")]
        and_r32_imm8 = 89,

        /// <summary>
        /// and r32, m32 |  | 
        /// </summary>
        [Symbol("and r32, m32","and r32, m32 |  | ")]
        and_r32_m32 = 90,

        /// <summary>
        /// and r32, r32 |  | 
        /// </summary>
        [Symbol("and r32, r32","and r32, r32 |  | ")]
        and_r32_r32 = 91,

        /// <summary>
        /// and r64, imm32 |  | 
        /// </summary>
        [Symbol("and r64, imm32","and r64, imm32 |  | ")]
        and_r64_imm32 = 92,

        /// <summary>
        /// and r64, imm8 |  | 
        /// </summary>
        [Symbol("and r64, imm8","and r64, imm8 |  | ")]
        and_r64_imm8 = 93,

        /// <summary>
        /// and r64, m64 |  | 
        /// </summary>
        [Symbol("and r64, m64","and r64, m64 |  | ")]
        and_r64_m64 = 94,

        /// <summary>
        /// and r64, r64 |  | 
        /// </summary>
        [Symbol("and r64, r64","and r64, r64 |  | ")]
        and_r64_r64 = 95,

        /// <summary>
        /// and r8, imm8 |  | 
        /// </summary>
        [Symbol("and r8, imm8","and r8, imm8 |  | ")]
        and_r8_imm8 = 96,

        /// <summary>
        /// and r8, m8 |  | 
        /// </summary>
        [Symbol("and r8, m8","and r8, m8 |  | ")]
        and_r8_m8 = 97,

        /// <summary>
        /// and r8, r8 |  | 
        /// </summary>
        [Symbol("and r8, r8","and r8, r8 |  | ")]
        and_r8_r8 = 98,

        /// <summary>
        /// and RAX, imm32 |  | 
        /// </summary>
        [Symbol("and RAX, imm32","and RAX, imm32 |  | ")]
        and_RAX_imm32 = 99,

        /// <summary>
        /// andn r32, r32, m32 |  | 
        /// </summary>
        [Symbol("andn r32, r32, m32","andn r32, r32, m32 |  | ")]
        andn_r32_r32_m32 = 100,

        /// <summary>
        /// andn r32, r32, r32 |  | 
        /// </summary>
        [Symbol("andn r32, r32, r32","andn r32, r32, r32 |  | ")]
        andn_r32_r32_r32 = 101,

        /// <summary>
        /// andn r64, r64, m64 |  | 
        /// </summary>
        [Symbol("andn r64, r64, m64","andn r64, r64, m64 |  | ")]
        andn_r64_r64_m64 = 102,

        /// <summary>
        /// andn r64, r64, r64 |  | 
        /// </summary>
        [Symbol("andn r64, r64, r64","andn r64, r64, r64 |  | ")]
        andn_r64_r64_r64 = 103,

        /// <summary>
        /// bextr r32, m32, r32 |  | 
        /// </summary>
        [Symbol("bextr r32, m32, r32","bextr r32, m32, r32 |  | ")]
        bextr_r32_m32_r32 = 104,

        /// <summary>
        /// bextr r32, r32, r32 |  | 
        /// </summary>
        [Symbol("bextr r32, r32, r32","bextr r32, r32, r32 |  | ")]
        bextr_r32_r32_r32 = 105,

        /// <summary>
        /// bextr r64, m64, r64 |  | 
        /// </summary>
        [Symbol("bextr r64, m64, r64","bextr r64, m64, r64 |  | ")]
        bextr_r64_m64_r64 = 106,

        /// <summary>
        /// bextr r64, r64, r64 |  | 
        /// </summary>
        [Symbol("bextr r64, r64, r64","bextr r64, r64, r64 |  | ")]
        bextr_r64_r64_r64 = 107,

        /// <summary>
        /// blsi r32, m32 |  | 
        /// </summary>
        [Symbol("blsi r32, m32","blsi r32, m32 |  | ")]
        blsi_r32_m32 = 108,

        /// <summary>
        /// blsi r32, r32 |  | 
        /// </summary>
        [Symbol("blsi r32, r32","blsi r32, r32 |  | ")]
        blsi_r32_r32 = 109,

        /// <summary>
        /// blsi r64, m64 |  | 
        /// </summary>
        [Symbol("blsi r64, m64","blsi r64, m64 |  | ")]
        blsi_r64_m64 = 110,

        /// <summary>
        /// blsi r64, r64 |  | 
        /// </summary>
        [Symbol("blsi r64, r64","blsi r64, r64 |  | ")]
        blsi_r64_r64 = 111,

        /// <summary>
        /// blsmsk r32, m32 |  | 
        /// </summary>
        [Symbol("blsmsk r32, m32","blsmsk r32, m32 |  | ")]
        blsmsk_r32_m32 = 112,

        /// <summary>
        /// blsmsk r32, r32 |  | 
        /// </summary>
        [Symbol("blsmsk r32, r32","blsmsk r32, r32 |  | ")]
        blsmsk_r32_r32 = 113,

        /// <summary>
        /// blsmsk r64, m64 |  | 
        /// </summary>
        [Symbol("blsmsk r64, m64","blsmsk r64, m64 |  | ")]
        blsmsk_r64_m64 = 114,

        /// <summary>
        /// blsmsk r64, r64 |  | 
        /// </summary>
        [Symbol("blsmsk r64, r64","blsmsk r64, r64 |  | ")]
        blsmsk_r64_r64 = 115,

        /// <summary>
        /// blsr r32, m32 |  | 
        /// </summary>
        [Symbol("blsr r32, m32","blsr r32, m32 |  | ")]
        blsr_r32_m32 = 116,

        /// <summary>
        /// blsr r32, r32 |  | 
        /// </summary>
        [Symbol("blsr r32, r32","blsr r32, r32 |  | ")]
        blsr_r32_r32 = 117,

        /// <summary>
        /// blsr r64, m64 |  | 
        /// </summary>
        [Symbol("blsr r64, m64","blsr r64, m64 |  | ")]
        blsr_r64_m64 = 118,

        /// <summary>
        /// blsr r64, r64 |  | 
        /// </summary>
        [Symbol("blsr r64, r64","blsr r64, r64 |  | ")]
        blsr_r64_r64 = 119,

        /// <summary>
        /// bndldx BND, mib |  | 
        /// </summary>
        [Symbol("bndldx BND, mib","bndldx BND, mib |  | ")]
        bndldx_BND_mib = 120,

        /// <summary>
        /// bndstx mib, BND |  | 
        /// </summary>
        [Symbol("bndstx mib, BND","bndstx mib, BND |  | ")]
        bndstx_mib_BND = 121,

        /// <summary>
        /// bsf r16, m16 |  | 
        /// </summary>
        [Symbol("bsf r16, m16","bsf r16, m16 |  | ")]
        bsf_r16_m16 = 122,

        /// <summary>
        /// bsf r16, r16 |  | 
        /// </summary>
        [Symbol("bsf r16, r16","bsf r16, r16 |  | ")]
        bsf_r16_r16 = 123,

        /// <summary>
        /// bsf r32, m32 |  | 
        /// </summary>
        [Symbol("bsf r32, m32","bsf r32, m32 |  | ")]
        bsf_r32_m32 = 124,

        /// <summary>
        /// bsf r32, r32 |  | 
        /// </summary>
        [Symbol("bsf r32, r32","bsf r32, r32 |  | ")]
        bsf_r32_r32 = 125,

        /// <summary>
        /// bsf r64, m64 |  | 
        /// </summary>
        [Symbol("bsf r64, m64","bsf r64, m64 |  | ")]
        bsf_r64_m64 = 126,

        /// <summary>
        /// bsf r64, r64 |  | 
        /// </summary>
        [Symbol("bsf r64, r64","bsf r64, r64 |  | ")]
        bsf_r64_r64 = 127,

        /// <summary>
        /// bsr r16, m16 |  | 
        /// </summary>
        [Symbol("bsr r16, m16","bsr r16, m16 |  | ")]
        bsr_r16_m16 = 128,

        /// <summary>
        /// bsr r16, r16 |  | 
        /// </summary>
        [Symbol("bsr r16, r16","bsr r16, r16 |  | ")]
        bsr_r16_r16 = 129,

        /// <summary>
        /// bsr r32, m32 |  | 
        /// </summary>
        [Symbol("bsr r32, m32","bsr r32, m32 |  | ")]
        bsr_r32_m32 = 130,

        /// <summary>
        /// bsr r32, r32 |  | 
        /// </summary>
        [Symbol("bsr r32, r32","bsr r32, r32 |  | ")]
        bsr_r32_r32 = 131,

        /// <summary>
        /// bsr r64, m64 |  | 
        /// </summary>
        [Symbol("bsr r64, m64","bsr r64, m64 |  | ")]
        bsr_r64_m64 = 132,

        /// <summary>
        /// bsr r64, r64 |  | 
        /// </summary>
        [Symbol("bsr r64, r64","bsr r64, r64 |  | ")]
        bsr_r64_r64 = 133,

        /// <summary>
        /// bswap r32 |  | 
        /// </summary>
        [Symbol("bswap r32","bswap r32 |  | ")]
        bswap_r32 = 134,

        /// <summary>
        /// bswap r64 |  | 
        /// </summary>
        [Symbol("bswap r64","bswap r64 |  | ")]
        bswap_r64 = 135,

        /// <summary>
        /// bt m16, imm8 |  | 
        /// </summary>
        [Symbol("bt m16, imm8","bt m16, imm8 |  | ")]
        bt_m16_imm8 = 136,

        /// <summary>
        /// bt m16, r16 |  | 
        /// </summary>
        [Symbol("bt m16, r16","bt m16, r16 |  | ")]
        bt_m16_r16 = 137,

        /// <summary>
        /// bt m32, imm8 |  | 
        /// </summary>
        [Symbol("bt m32, imm8","bt m32, imm8 |  | ")]
        bt_m32_imm8 = 138,

        /// <summary>
        /// bt m32, r32 |  | 
        /// </summary>
        [Symbol("bt m32, r32","bt m32, r32 |  | ")]
        bt_m32_r32 = 139,

        /// <summary>
        /// bt m64, imm8 |  | 
        /// </summary>
        [Symbol("bt m64, imm8","bt m64, imm8 |  | ")]
        bt_m64_imm8 = 140,

        /// <summary>
        /// bt m64, r64 |  | 
        /// </summary>
        [Symbol("bt m64, r64","bt m64, r64 |  | ")]
        bt_m64_r64 = 141,

        /// <summary>
        /// bt r16, imm8 |  | 
        /// </summary>
        [Symbol("bt r16, imm8","bt r16, imm8 |  | ")]
        bt_r16_imm8 = 142,

        /// <summary>
        /// bt r16, r16 |  | 
        /// </summary>
        [Symbol("bt r16, r16","bt r16, r16 |  | ")]
        bt_r16_r16 = 143,

        /// <summary>
        /// bt r32, imm8 |  | 
        /// </summary>
        [Symbol("bt r32, imm8","bt r32, imm8 |  | ")]
        bt_r32_imm8 = 144,

        /// <summary>
        /// bt r32, r32 |  | 
        /// </summary>
        [Symbol("bt r32, r32","bt r32, r32 |  | ")]
        bt_r32_r32 = 145,

        /// <summary>
        /// bt r64, imm8 |  | 
        /// </summary>
        [Symbol("bt r64, imm8","bt r64, imm8 |  | ")]
        bt_r64_imm8 = 146,

        /// <summary>
        /// bt r64, r64 |  | 
        /// </summary>
        [Symbol("bt r64, r64","bt r64, r64 |  | ")]
        bt_r64_r64 = 147,

        /// <summary>
        /// btc m16, imm8 |  | 
        /// </summary>
        [Symbol("btc m16, imm8","btc m16, imm8 |  | ")]
        btc_m16_imm8 = 148,

        /// <summary>
        /// btc m16, r16 |  | 
        /// </summary>
        [Symbol("btc m16, r16","btc m16, r16 |  | ")]
        btc_m16_r16 = 149,

        /// <summary>
        /// btc m32, imm8 |  | 
        /// </summary>
        [Symbol("btc m32, imm8","btc m32, imm8 |  | ")]
        btc_m32_imm8 = 150,

        /// <summary>
        /// btc m32, r32 |  | 
        /// </summary>
        [Symbol("btc m32, r32","btc m32, r32 |  | ")]
        btc_m32_r32 = 151,

        /// <summary>
        /// btc m64, imm8 |  | 
        /// </summary>
        [Symbol("btc m64, imm8","btc m64, imm8 |  | ")]
        btc_m64_imm8 = 152,

        /// <summary>
        /// btc m64, r64 |  | 
        /// </summary>
        [Symbol("btc m64, r64","btc m64, r64 |  | ")]
        btc_m64_r64 = 153,

        /// <summary>
        /// btc r16, imm8 |  | 
        /// </summary>
        [Symbol("btc r16, imm8","btc r16, imm8 |  | ")]
        btc_r16_imm8 = 154,

        /// <summary>
        /// btc r16, r16 |  | 
        /// </summary>
        [Symbol("btc r16, r16","btc r16, r16 |  | ")]
        btc_r16_r16 = 155,

        /// <summary>
        /// btc r32, imm8 |  | 
        /// </summary>
        [Symbol("btc r32, imm8","btc r32, imm8 |  | ")]
        btc_r32_imm8 = 156,

        /// <summary>
        /// btc r32, r32 |  | 
        /// </summary>
        [Symbol("btc r32, r32","btc r32, r32 |  | ")]
        btc_r32_r32 = 157,

        /// <summary>
        /// btc r64, imm8 |  | 
        /// </summary>
        [Symbol("btc r64, imm8","btc r64, imm8 |  | ")]
        btc_r64_imm8 = 158,

        /// <summary>
        /// btc r64, r64 |  | 
        /// </summary>
        [Symbol("btc r64, r64","btc r64, r64 |  | ")]
        btc_r64_r64 = 159,

        /// <summary>
        /// btr m16, imm8 |  | 
        /// </summary>
        [Symbol("btr m16, imm8","btr m16, imm8 |  | ")]
        btr_m16_imm8 = 160,

        /// <summary>
        /// btr m16, r16 |  | 
        /// </summary>
        [Symbol("btr m16, r16","btr m16, r16 |  | ")]
        btr_m16_r16 = 161,

        /// <summary>
        /// btr m32, imm8 |  | 
        /// </summary>
        [Symbol("btr m32, imm8","btr m32, imm8 |  | ")]
        btr_m32_imm8 = 162,

        /// <summary>
        /// btr m32, r32 |  | 
        /// </summary>
        [Symbol("btr m32, r32","btr m32, r32 |  | ")]
        btr_m32_r32 = 163,

        /// <summary>
        /// btr m64, imm8 |  | 
        /// </summary>
        [Symbol("btr m64, imm8","btr m64, imm8 |  | ")]
        btr_m64_imm8 = 164,

        /// <summary>
        /// btr m64, r64 |  | 
        /// </summary>
        [Symbol("btr m64, r64","btr m64, r64 |  | ")]
        btr_m64_r64 = 165,

        /// <summary>
        /// btr r16, imm8 |  | 
        /// </summary>
        [Symbol("btr r16, imm8","btr r16, imm8 |  | ")]
        btr_r16_imm8 = 166,

        /// <summary>
        /// btr r16, r16 |  | 
        /// </summary>
        [Symbol("btr r16, r16","btr r16, r16 |  | ")]
        btr_r16_r16 = 167,

        /// <summary>
        /// btr r32, imm8 |  | 
        /// </summary>
        [Symbol("btr r32, imm8","btr r32, imm8 |  | ")]
        btr_r32_imm8 = 168,

        /// <summary>
        /// btr r32, r32 |  | 
        /// </summary>
        [Symbol("btr r32, r32","btr r32, r32 |  | ")]
        btr_r32_r32 = 169,

        /// <summary>
        /// btr r64, imm8 |  | 
        /// </summary>
        [Symbol("btr r64, imm8","btr r64, imm8 |  | ")]
        btr_r64_imm8 = 170,

        /// <summary>
        /// btr r64, r64 |  | 
        /// </summary>
        [Symbol("btr r64, r64","btr r64, r64 |  | ")]
        btr_r64_r64 = 171,

        /// <summary>
        /// bts m16, imm8 |  | 
        /// </summary>
        [Symbol("bts m16, imm8","bts m16, imm8 |  | ")]
        bts_m16_imm8 = 172,

        /// <summary>
        /// bts m16, r16 |  | 
        /// </summary>
        [Symbol("bts m16, r16","bts m16, r16 |  | ")]
        bts_m16_r16 = 173,

        /// <summary>
        /// bts m32, imm8 |  | 
        /// </summary>
        [Symbol("bts m32, imm8","bts m32, imm8 |  | ")]
        bts_m32_imm8 = 174,

        /// <summary>
        /// bts m32, r32 |  | 
        /// </summary>
        [Symbol("bts m32, r32","bts m32, r32 |  | ")]
        bts_m32_r32 = 175,

        /// <summary>
        /// bts m64, imm8 |  | 
        /// </summary>
        [Symbol("bts m64, imm8","bts m64, imm8 |  | ")]
        bts_m64_imm8 = 176,

        /// <summary>
        /// bts m64, r64 |  | 
        /// </summary>
        [Symbol("bts m64, r64","bts m64, r64 |  | ")]
        bts_m64_r64 = 177,

        /// <summary>
        /// bts r16, imm8 |  | 
        /// </summary>
        [Symbol("bts r16, imm8","bts r16, imm8 |  | ")]
        bts_r16_imm8 = 178,

        /// <summary>
        /// bts r16, r16 |  | 
        /// </summary>
        [Symbol("bts r16, r16","bts r16, r16 |  | ")]
        bts_r16_r16 = 179,

        /// <summary>
        /// bts r32, imm8 |  | 
        /// </summary>
        [Symbol("bts r32, imm8","bts r32, imm8 |  | ")]
        bts_r32_imm8 = 180,

        /// <summary>
        /// bts r32, r32 |  | 
        /// </summary>
        [Symbol("bts r32, r32","bts r32, r32 |  | ")]
        bts_r32_r32 = 181,

        /// <summary>
        /// bts r64, imm8 |  | 
        /// </summary>
        [Symbol("bts r64, imm8","bts r64, imm8 |  | ")]
        bts_r64_imm8 = 182,

        /// <summary>
        /// bts r64, r64 |  | 
        /// </summary>
        [Symbol("bts r64, r64","bts r64, r64 |  | ")]
        bts_r64_r64 = 183,

        /// <summary>
        /// bzhi r32, m32, r32 |  | 
        /// </summary>
        [Symbol("bzhi r32, m32, r32","bzhi r32, m32, r32 |  | ")]
        bzhi_r32_m32_r32 = 184,

        /// <summary>
        /// bzhi r32, r32, r32 |  | 
        /// </summary>
        [Symbol("bzhi r32, r32, r32","bzhi r32, r32, r32 |  | ")]
        bzhi_r32_r32_r32 = 185,

        /// <summary>
        /// bzhi r64, m64, r64 |  | 
        /// </summary>
        [Symbol("bzhi r64, m64, r64","bzhi r64, m64, r64 |  | ")]
        bzhi_r64_m64_r64 = 186,

        /// <summary>
        /// bzhi r64, r64, r64 |  | 
        /// </summary>
        [Symbol("bzhi r64, r64, r64","bzhi r64, r64, r64 |  | ")]
        bzhi_r64_r64_r64 = 187,

        /// <summary>
        /// call m16 |  | 
        /// </summary>
        [Symbol("call m16","call m16 |  | ")]
        call_m16 = 188,

        /// <summary>
        /// call m32 |  | 
        /// </summary>
        [Symbol("call m32","call m32 |  | ")]
        call_m32 = 189,

        /// <summary>
        /// call m64 |  | 
        /// </summary>
        [Symbol("call m64","call m64 |  | ")]
        call_m64 = 190,

        /// <summary>
        /// call m16:16 |  | 
        /// </summary>
        [Symbol("call m16:16","call m16:16 |  | ")]
        call_mp16x16 = 191,

        /// <summary>
        /// call m16:32 |  | 
        /// </summary>
        [Symbol("call m16:32","call m16:32 |  | ")]
        call_mp16x32 = 192,

        /// <summary>
        /// call m16:64 |  | 
        /// </summary>
        [Symbol("call m16:64","call m16:64 |  | ")]
        call_mp16x64 = 193,

        /// <summary>
        /// call ptr16:16 |  | 
        /// </summary>
        [Symbol("call ptr16:16","call ptr16:16 |  | ")]
        call_p16x16 = 194,

        /// <summary>
        /// call ptr16:32 |  | 
        /// </summary>
        [Symbol("call ptr16:32","call ptr16:32 |  | ")]
        call_p16x32 = 195,

        /// <summary>
        /// call r16 |  | 
        /// </summary>
        [Symbol("call r16","call r16 |  | ")]
        call_r16 = 196,

        /// <summary>
        /// call r32 |  | 
        /// </summary>
        [Symbol("call r32","call r32 |  | ")]
        call_r32 = 197,

        /// <summary>
        /// call r64 |  | 
        /// </summary>
        [Symbol("call r64","call r64 |  | ")]
        call_r64 = 198,

        /// <summary>
        /// call rel16 |  | 
        /// </summary>
        [Symbol("call rel16","call rel16 |  | ")]
        call_rel16 = 199,

        /// <summary>
        /// call rel32 |  | 
        /// </summary>
        [Symbol("call rel32","call rel32 |  | ")]
        call_rel32 = 200,

        /// <summary>
        /// cbw |  | 
        /// </summary>
        [Symbol("cbw","cbw |  | ")]
        cbw = 201,

        /// <summary>
        /// cdq |  | 
        /// </summary>
        [Symbol("cdq","cdq |  | ")]
        cdq = 202,

        /// <summary>
        /// cdqe |  | 
        /// </summary>
        [Symbol("cdqe","cdqe |  | ")]
        cdqe = 203,

        /// <summary>
        /// clc |  | 
        /// </summary>
        [Symbol("clc","clc |  | ")]
        clc = 204,

        /// <summary>
        /// cli |  | 
        /// </summary>
        [Symbol("cli","cli |  | ")]
        cli = 205,

        /// <summary>
        /// clts |  | 
        /// </summary>
        [Symbol("clts","clts |  | ")]
        clts = 206,

        /// <summary>
        /// cmc |  | 
        /// </summary>
        [Symbol("cmc","cmc |  | ")]
        cmc = 207,

        /// <summary>
        /// cmova r16, m16 |  | 
        /// </summary>
        [Symbol("cmova r16, m16","cmova r16, m16 |  | ")]
        cmova_r16_m16 = 208,

        /// <summary>
        /// cmova r16, r16 |  | 
        /// </summary>
        [Symbol("cmova r16, r16","cmova r16, r16 |  | ")]
        cmova_r16_r16 = 209,

        /// <summary>
        /// cmova r32, m32 |  | 
        /// </summary>
        [Symbol("cmova r32, m32","cmova r32, m32 |  | ")]
        cmova_r32_m32 = 210,

        /// <summary>
        /// cmova r32, r32 |  | 
        /// </summary>
        [Symbol("cmova r32, r32","cmova r32, r32 |  | ")]
        cmova_r32_r32 = 211,

        /// <summary>
        /// cmova r64, m64 |  | 
        /// </summary>
        [Symbol("cmova r64, m64","cmova r64, m64 |  | ")]
        cmova_r64_m64 = 212,

        /// <summary>
        /// cmova r64, r64 |  | 
        /// </summary>
        [Symbol("cmova r64, r64","cmova r64, r64 |  | ")]
        cmova_r64_r64 = 213,

        /// <summary>
        /// cmovae r16, m16 |  | 
        /// </summary>
        [Symbol("cmovae r16, m16","cmovae r16, m16 |  | ")]
        cmovae_r16_m16 = 214,

        /// <summary>
        /// cmovae r16, r16 |  | 
        /// </summary>
        [Symbol("cmovae r16, r16","cmovae r16, r16 |  | ")]
        cmovae_r16_r16 = 215,

        /// <summary>
        /// cmovae r32, m32 |  | 
        /// </summary>
        [Symbol("cmovae r32, m32","cmovae r32, m32 |  | ")]
        cmovae_r32_m32 = 216,

        /// <summary>
        /// cmovae r32, r32 |  | 
        /// </summary>
        [Symbol("cmovae r32, r32","cmovae r32, r32 |  | ")]
        cmovae_r32_r32 = 217,

        /// <summary>
        /// cmovae r64, m64 |  | 
        /// </summary>
        [Symbol("cmovae r64, m64","cmovae r64, m64 |  | ")]
        cmovae_r64_m64 = 218,

        /// <summary>
        /// cmovae r64, r64 |  | 
        /// </summary>
        [Symbol("cmovae r64, r64","cmovae r64, r64 |  | ")]
        cmovae_r64_r64 = 219,

        /// <summary>
        /// cmovb r16, m16 |  | 
        /// </summary>
        [Symbol("cmovb r16, m16","cmovb r16, m16 |  | ")]
        cmovb_r16_m16 = 220,

        /// <summary>
        /// cmovb r16, r16 |  | 
        /// </summary>
        [Symbol("cmovb r16, r16","cmovb r16, r16 |  | ")]
        cmovb_r16_r16 = 221,

        /// <summary>
        /// cmovb r32, m32 |  | 
        /// </summary>
        [Symbol("cmovb r32, m32","cmovb r32, m32 |  | ")]
        cmovb_r32_m32 = 222,

        /// <summary>
        /// cmovb r32, r32 |  | 
        /// </summary>
        [Symbol("cmovb r32, r32","cmovb r32, r32 |  | ")]
        cmovb_r32_r32 = 223,

        /// <summary>
        /// cmovb r64, m64 |  | 
        /// </summary>
        [Symbol("cmovb r64, m64","cmovb r64, m64 |  | ")]
        cmovb_r64_m64 = 224,

        /// <summary>
        /// cmovb r64, r64 |  | 
        /// </summary>
        [Symbol("cmovb r64, r64","cmovb r64, r64 |  | ")]
        cmovb_r64_r64 = 225,

        /// <summary>
        /// cmovbe r16, m16 |  | 
        /// </summary>
        [Symbol("cmovbe r16, m16","cmovbe r16, m16 |  | ")]
        cmovbe_r16_m16 = 226,

        /// <summary>
        /// cmovbe r16, r16 |  | 
        /// </summary>
        [Symbol("cmovbe r16, r16","cmovbe r16, r16 |  | ")]
        cmovbe_r16_r16 = 227,

        /// <summary>
        /// cmovbe r32, m32 |  | 
        /// </summary>
        [Symbol("cmovbe r32, m32","cmovbe r32, m32 |  | ")]
        cmovbe_r32_m32 = 228,

        /// <summary>
        /// cmovbe r32, r32 |  | 
        /// </summary>
        [Symbol("cmovbe r32, r32","cmovbe r32, r32 |  | ")]
        cmovbe_r32_r32 = 229,

        /// <summary>
        /// cmovbe r64, m64 |  | 
        /// </summary>
        [Symbol("cmovbe r64, m64","cmovbe r64, m64 |  | ")]
        cmovbe_r64_m64 = 230,

        /// <summary>
        /// cmovbe r64, r64 |  | 
        /// </summary>
        [Symbol("cmovbe r64, r64","cmovbe r64, r64 |  | ")]
        cmovbe_r64_r64 = 231,

        /// <summary>
        /// cmovc r16, m16 |  | 
        /// </summary>
        [Symbol("cmovc r16, m16","cmovc r16, m16 |  | ")]
        cmovc_r16_m16 = 232,

        /// <summary>
        /// cmovc r16, r16 |  | 
        /// </summary>
        [Symbol("cmovc r16, r16","cmovc r16, r16 |  | ")]
        cmovc_r16_r16 = 233,

        /// <summary>
        /// cmovc r32, m32 |  | 
        /// </summary>
        [Symbol("cmovc r32, m32","cmovc r32, m32 |  | ")]
        cmovc_r32_m32 = 234,

        /// <summary>
        /// cmovc r32, r32 |  | 
        /// </summary>
        [Symbol("cmovc r32, r32","cmovc r32, r32 |  | ")]
        cmovc_r32_r32 = 235,

        /// <summary>
        /// cmovc r64, m64 |  | 
        /// </summary>
        [Symbol("cmovc r64, m64","cmovc r64, m64 |  | ")]
        cmovc_r64_m64 = 236,

        /// <summary>
        /// cmovc r64, r64 |  | 
        /// </summary>
        [Symbol("cmovc r64, r64","cmovc r64, r64 |  | ")]
        cmovc_r64_r64 = 237,

        /// <summary>
        /// cmove r16, m16 |  | 
        /// </summary>
        [Symbol("cmove r16, m16","cmove r16, m16 |  | ")]
        cmove_r16_m16 = 238,

        /// <summary>
        /// cmove r16, r16 |  | 
        /// </summary>
        [Symbol("cmove r16, r16","cmove r16, r16 |  | ")]
        cmove_r16_r16 = 239,

        /// <summary>
        /// cmove r32, m32 |  | 
        /// </summary>
        [Symbol("cmove r32, m32","cmove r32, m32 |  | ")]
        cmove_r32_m32 = 240,

        /// <summary>
        /// cmove r32, r32 |  | 
        /// </summary>
        [Symbol("cmove r32, r32","cmove r32, r32 |  | ")]
        cmove_r32_r32 = 241,

        /// <summary>
        /// cmove r64, m64 |  | 
        /// </summary>
        [Symbol("cmove r64, m64","cmove r64, m64 |  | ")]
        cmove_r64_m64 = 242,

        /// <summary>
        /// cmove r64, r64 |  | 
        /// </summary>
        [Symbol("cmove r64, r64","cmove r64, r64 |  | ")]
        cmove_r64_r64 = 243,

        /// <summary>
        /// cmovg r16, m16 |  | 
        /// </summary>
        [Symbol("cmovg r16, m16","cmovg r16, m16 |  | ")]
        cmovg_r16_m16 = 244,

        /// <summary>
        /// cmovg r16, r16 |  | 
        /// </summary>
        [Symbol("cmovg r16, r16","cmovg r16, r16 |  | ")]
        cmovg_r16_r16 = 245,

        /// <summary>
        /// cmovg r32, m32 |  | 
        /// </summary>
        [Symbol("cmovg r32, m32","cmovg r32, m32 |  | ")]
        cmovg_r32_m32 = 246,

        /// <summary>
        /// cmovg r32, r32 |  | 
        /// </summary>
        [Symbol("cmovg r32, r32","cmovg r32, r32 |  | ")]
        cmovg_r32_r32 = 247,

        /// <summary>
        /// cmovg r64, m64 |  | 
        /// </summary>
        [Symbol("cmovg r64, m64","cmovg r64, m64 |  | ")]
        cmovg_r64_m64 = 248,

        /// <summary>
        /// cmovg r64, r64 |  | 
        /// </summary>
        [Symbol("cmovg r64, r64","cmovg r64, r64 |  | ")]
        cmovg_r64_r64 = 249,

        /// <summary>
        /// cmovge r16, m16 |  | 
        /// </summary>
        [Symbol("cmovge r16, m16","cmovge r16, m16 |  | ")]
        cmovge_r16_m16 = 250,

        /// <summary>
        /// cmovge r16, r16 |  | 
        /// </summary>
        [Symbol("cmovge r16, r16","cmovge r16, r16 |  | ")]
        cmovge_r16_r16 = 251,

        /// <summary>
        /// cmovge r32, m32 |  | 
        /// </summary>
        [Symbol("cmovge r32, m32","cmovge r32, m32 |  | ")]
        cmovge_r32_m32 = 252,

        /// <summary>
        /// cmovge r32, r32 |  | 
        /// </summary>
        [Symbol("cmovge r32, r32","cmovge r32, r32 |  | ")]
        cmovge_r32_r32 = 253,

        /// <summary>
        /// cmovge r64, m64 |  | 
        /// </summary>
        [Symbol("cmovge r64, m64","cmovge r64, m64 |  | ")]
        cmovge_r64_m64 = 254,

        /// <summary>
        /// cmovge r64, r64 |  | 
        /// </summary>
        [Symbol("cmovge r64, r64","cmovge r64, r64 |  | ")]
        cmovge_r64_r64 = 255,

        /// <summary>
        /// cmovl r16, m16 |  | 
        /// </summary>
        [Symbol("cmovl r16, m16","cmovl r16, m16 |  | ")]
        cmovl_r16_m16 = 256,

        /// <summary>
        /// cmovl r16, r16 |  | 
        /// </summary>
        [Symbol("cmovl r16, r16","cmovl r16, r16 |  | ")]
        cmovl_r16_r16 = 257,

        /// <summary>
        /// cmovl r32, m32 |  | 
        /// </summary>
        [Symbol("cmovl r32, m32","cmovl r32, m32 |  | ")]
        cmovl_r32_m32 = 258,

        /// <summary>
        /// cmovl r32, r32 |  | 
        /// </summary>
        [Symbol("cmovl r32, r32","cmovl r32, r32 |  | ")]
        cmovl_r32_r32 = 259,

        /// <summary>
        /// cmovl r64, m64 |  | 
        /// </summary>
        [Symbol("cmovl r64, m64","cmovl r64, m64 |  | ")]
        cmovl_r64_m64 = 260,

        /// <summary>
        /// cmovl r64, r64 |  | 
        /// </summary>
        [Symbol("cmovl r64, r64","cmovl r64, r64 |  | ")]
        cmovl_r64_r64 = 261,

        /// <summary>
        /// cmovle r16, m16 |  | 
        /// </summary>
        [Symbol("cmovle r16, m16","cmovle r16, m16 |  | ")]
        cmovle_r16_m16 = 262,

        /// <summary>
        /// cmovle r16, r16 |  | 
        /// </summary>
        [Symbol("cmovle r16, r16","cmovle r16, r16 |  | ")]
        cmovle_r16_r16 = 263,

        /// <summary>
        /// cmovle r32, m32 |  | 
        /// </summary>
        [Symbol("cmovle r32, m32","cmovle r32, m32 |  | ")]
        cmovle_r32_m32 = 264,

        /// <summary>
        /// cmovle r32, r32 |  | 
        /// </summary>
        [Symbol("cmovle r32, r32","cmovle r32, r32 |  | ")]
        cmovle_r32_r32 = 265,

        /// <summary>
        /// cmovle r64, m64 |  | 
        /// </summary>
        [Symbol("cmovle r64, m64","cmovle r64, m64 |  | ")]
        cmovle_r64_m64 = 266,

        /// <summary>
        /// cmovle r64, r64 |  | 
        /// </summary>
        [Symbol("cmovle r64, r64","cmovle r64, r64 |  | ")]
        cmovle_r64_r64 = 267,

        /// <summary>
        /// cmovna r16, m16 |  | 
        /// </summary>
        [Symbol("cmovna r16, m16","cmovna r16, m16 |  | ")]
        cmovna_r16_m16 = 268,

        /// <summary>
        /// cmovna r16, r16 |  | 
        /// </summary>
        [Symbol("cmovna r16, r16","cmovna r16, r16 |  | ")]
        cmovna_r16_r16 = 269,

        /// <summary>
        /// cmovna r32, m32 |  | 
        /// </summary>
        [Symbol("cmovna r32, m32","cmovna r32, m32 |  | ")]
        cmovna_r32_m32 = 270,

        /// <summary>
        /// cmovna r32, r32 |  | 
        /// </summary>
        [Symbol("cmovna r32, r32","cmovna r32, r32 |  | ")]
        cmovna_r32_r32 = 271,

        /// <summary>
        /// cmovna r64, m64 |  | 
        /// </summary>
        [Symbol("cmovna r64, m64","cmovna r64, m64 |  | ")]
        cmovna_r64_m64 = 272,

        /// <summary>
        /// cmovna r64, r64 |  | 
        /// </summary>
        [Symbol("cmovna r64, r64","cmovna r64, r64 |  | ")]
        cmovna_r64_r64 = 273,

        /// <summary>
        /// cmovnae r16, m16 |  | 
        /// </summary>
        [Symbol("cmovnae r16, m16","cmovnae r16, m16 |  | ")]
        cmovnae_r16_m16 = 274,

        /// <summary>
        /// cmovnae r16, r16 |  | 
        /// </summary>
        [Symbol("cmovnae r16, r16","cmovnae r16, r16 |  | ")]
        cmovnae_r16_r16 = 275,

        /// <summary>
        /// cmovnae r32, m32 |  | 
        /// </summary>
        [Symbol("cmovnae r32, m32","cmovnae r32, m32 |  | ")]
        cmovnae_r32_m32 = 276,

        /// <summary>
        /// cmovnae r32, r32 |  | 
        /// </summary>
        [Symbol("cmovnae r32, r32","cmovnae r32, r32 |  | ")]
        cmovnae_r32_r32 = 277,

        /// <summary>
        /// cmovnae r64, m64 |  | 
        /// </summary>
        [Symbol("cmovnae r64, m64","cmovnae r64, m64 |  | ")]
        cmovnae_r64_m64 = 278,

        /// <summary>
        /// cmovnae r64, r64 |  | 
        /// </summary>
        [Symbol("cmovnae r64, r64","cmovnae r64, r64 |  | ")]
        cmovnae_r64_r64 = 279,

        /// <summary>
        /// cmovnb r16, m16 |  | 
        /// </summary>
        [Symbol("cmovnb r16, m16","cmovnb r16, m16 |  | ")]
        cmovnb_r16_m16 = 280,

        /// <summary>
        /// cmovnb r16, r16 |  | 
        /// </summary>
        [Symbol("cmovnb r16, r16","cmovnb r16, r16 |  | ")]
        cmovnb_r16_r16 = 281,

        /// <summary>
        /// cmovnb r32, m32 |  | 
        /// </summary>
        [Symbol("cmovnb r32, m32","cmovnb r32, m32 |  | ")]
        cmovnb_r32_m32 = 282,

        /// <summary>
        /// cmovnb r32, r32 |  | 
        /// </summary>
        [Symbol("cmovnb r32, r32","cmovnb r32, r32 |  | ")]
        cmovnb_r32_r32 = 283,

        /// <summary>
        /// cmovnb r64, m64 |  | 
        /// </summary>
        [Symbol("cmovnb r64, m64","cmovnb r64, m64 |  | ")]
        cmovnb_r64_m64 = 284,

        /// <summary>
        /// cmovnb r64, r64 |  | 
        /// </summary>
        [Symbol("cmovnb r64, r64","cmovnb r64, r64 |  | ")]
        cmovnb_r64_r64 = 285,

        /// <summary>
        /// cmovnbe r16, m16 |  | 
        /// </summary>
        [Symbol("cmovnbe r16, m16","cmovnbe r16, m16 |  | ")]
        cmovnbe_r16_m16 = 286,

        /// <summary>
        /// cmovnbe r16, r16 |  | 
        /// </summary>
        [Symbol("cmovnbe r16, r16","cmovnbe r16, r16 |  | ")]
        cmovnbe_r16_r16 = 287,

        /// <summary>
        /// cmovnbe r32, m32 |  | 
        /// </summary>
        [Symbol("cmovnbe r32, m32","cmovnbe r32, m32 |  | ")]
        cmovnbe_r32_m32 = 288,

        /// <summary>
        /// cmovnbe r32, r32 |  | 
        /// </summary>
        [Symbol("cmovnbe r32, r32","cmovnbe r32, r32 |  | ")]
        cmovnbe_r32_r32 = 289,

        /// <summary>
        /// cmovnbe r64, m64 |  | 
        /// </summary>
        [Symbol("cmovnbe r64, m64","cmovnbe r64, m64 |  | ")]
        cmovnbe_r64_m64 = 290,

        /// <summary>
        /// cmovnbe r64, r64 |  | 
        /// </summary>
        [Symbol("cmovnbe r64, r64","cmovnbe r64, r64 |  | ")]
        cmovnbe_r64_r64 = 291,

        /// <summary>
        /// cmovnc r16, m16 |  | 
        /// </summary>
        [Symbol("cmovnc r16, m16","cmovnc r16, m16 |  | ")]
        cmovnc_r16_m16 = 292,

        /// <summary>
        /// cmovnc r16, r16 |  | 
        /// </summary>
        [Symbol("cmovnc r16, r16","cmovnc r16, r16 |  | ")]
        cmovnc_r16_r16 = 293,

        /// <summary>
        /// cmovnc r32, m32 |  | 
        /// </summary>
        [Symbol("cmovnc r32, m32","cmovnc r32, m32 |  | ")]
        cmovnc_r32_m32 = 294,

        /// <summary>
        /// cmovnc r32, r32 |  | 
        /// </summary>
        [Symbol("cmovnc r32, r32","cmovnc r32, r32 |  | ")]
        cmovnc_r32_r32 = 295,

        /// <summary>
        /// cmovnc r64, m64 |  | 
        /// </summary>
        [Symbol("cmovnc r64, m64","cmovnc r64, m64 |  | ")]
        cmovnc_r64_m64 = 296,

        /// <summary>
        /// cmovnc r64, r64 |  | 
        /// </summary>
        [Symbol("cmovnc r64, r64","cmovnc r64, r64 |  | ")]
        cmovnc_r64_r64 = 297,

        /// <summary>
        /// cmovne r16, m16 |  | 
        /// </summary>
        [Symbol("cmovne r16, m16","cmovne r16, m16 |  | ")]
        cmovne_r16_m16 = 298,

        /// <summary>
        /// cmovne r16, r16 |  | 
        /// </summary>
        [Symbol("cmovne r16, r16","cmovne r16, r16 |  | ")]
        cmovne_r16_r16 = 299,

        /// <summary>
        /// cmovne r32, m32 |  | 
        /// </summary>
        [Symbol("cmovne r32, m32","cmovne r32, m32 |  | ")]
        cmovne_r32_m32 = 300,

        /// <summary>
        /// cmovne r32, r32 |  | 
        /// </summary>
        [Symbol("cmovne r32, r32","cmovne r32, r32 |  | ")]
        cmovne_r32_r32 = 301,

        /// <summary>
        /// cmovne r64, m64 |  | 
        /// </summary>
        [Symbol("cmovne r64, m64","cmovne r64, m64 |  | ")]
        cmovne_r64_m64 = 302,

        /// <summary>
        /// cmovne r64, r64 |  | 
        /// </summary>
        [Symbol("cmovne r64, r64","cmovne r64, r64 |  | ")]
        cmovne_r64_r64 = 303,

        /// <summary>
        /// cmovng r16, m16 |  | 
        /// </summary>
        [Symbol("cmovng r16, m16","cmovng r16, m16 |  | ")]
        cmovng_r16_m16 = 304,

        /// <summary>
        /// cmovng r16, r16 |  | 
        /// </summary>
        [Symbol("cmovng r16, r16","cmovng r16, r16 |  | ")]
        cmovng_r16_r16 = 305,

        /// <summary>
        /// cmovng r32, m32 |  | 
        /// </summary>
        [Symbol("cmovng r32, m32","cmovng r32, m32 |  | ")]
        cmovng_r32_m32 = 306,

        /// <summary>
        /// cmovng r32, r32 |  | 
        /// </summary>
        [Symbol("cmovng r32, r32","cmovng r32, r32 |  | ")]
        cmovng_r32_r32 = 307,

        /// <summary>
        /// cmovng r64, m64 |  | 
        /// </summary>
        [Symbol("cmovng r64, m64","cmovng r64, m64 |  | ")]
        cmovng_r64_m64 = 308,

        /// <summary>
        /// cmovng r64, r64 |  | 
        /// </summary>
        [Symbol("cmovng r64, r64","cmovng r64, r64 |  | ")]
        cmovng_r64_r64 = 309,

        /// <summary>
        /// cmovnge r16, m16 |  | 
        /// </summary>
        [Symbol("cmovnge r16, m16","cmovnge r16, m16 |  | ")]
        cmovnge_r16_m16 = 310,

        /// <summary>
        /// cmovnge r16, r16 |  | 
        /// </summary>
        [Symbol("cmovnge r16, r16","cmovnge r16, r16 |  | ")]
        cmovnge_r16_r16 = 311,

        /// <summary>
        /// cmovnge r32, m32 |  | 
        /// </summary>
        [Symbol("cmovnge r32, m32","cmovnge r32, m32 |  | ")]
        cmovnge_r32_m32 = 312,

        /// <summary>
        /// cmovnge r32, r32 |  | 
        /// </summary>
        [Symbol("cmovnge r32, r32","cmovnge r32, r32 |  | ")]
        cmovnge_r32_r32 = 313,

        /// <summary>
        /// cmovnge r64, m64 |  | 
        /// </summary>
        [Symbol("cmovnge r64, m64","cmovnge r64, m64 |  | ")]
        cmovnge_r64_m64 = 314,

        /// <summary>
        /// cmovnge r64, r64 |  | 
        /// </summary>
        [Symbol("cmovnge r64, r64","cmovnge r64, r64 |  | ")]
        cmovnge_r64_r64 = 315,

        /// <summary>
        /// cmovnl r16, m16 |  | 
        /// </summary>
        [Symbol("cmovnl r16, m16","cmovnl r16, m16 |  | ")]
        cmovnl_r16_m16 = 316,

        /// <summary>
        /// cmovnl r16, r16 |  | 
        /// </summary>
        [Symbol("cmovnl r16, r16","cmovnl r16, r16 |  | ")]
        cmovnl_r16_r16 = 317,

        /// <summary>
        /// cmovnl r32, m32 |  | 
        /// </summary>
        [Symbol("cmovnl r32, m32","cmovnl r32, m32 |  | ")]
        cmovnl_r32_m32 = 318,

        /// <summary>
        /// cmovnl r32, r32 |  | 
        /// </summary>
        [Symbol("cmovnl r32, r32","cmovnl r32, r32 |  | ")]
        cmovnl_r32_r32 = 319,

        /// <summary>
        /// cmovnl r64, m64 |  | 
        /// </summary>
        [Symbol("cmovnl r64, m64","cmovnl r64, m64 |  | ")]
        cmovnl_r64_m64 = 320,

        /// <summary>
        /// cmovnl r64, r64 |  | 
        /// </summary>
        [Symbol("cmovnl r64, r64","cmovnl r64, r64 |  | ")]
        cmovnl_r64_r64 = 321,

        /// <summary>
        /// cmovnle r16, m16 |  | 
        /// </summary>
        [Symbol("cmovnle r16, m16","cmovnle r16, m16 |  | ")]
        cmovnle_r16_m16 = 322,

        /// <summary>
        /// cmovnle r16, r16 |  | 
        /// </summary>
        [Symbol("cmovnle r16, r16","cmovnle r16, r16 |  | ")]
        cmovnle_r16_r16 = 323,

        /// <summary>
        /// cmovnle r32, m32 |  | 
        /// </summary>
        [Symbol("cmovnle r32, m32","cmovnle r32, m32 |  | ")]
        cmovnle_r32_m32 = 324,

        /// <summary>
        /// cmovnle r32, r32 |  | 
        /// </summary>
        [Symbol("cmovnle r32, r32","cmovnle r32, r32 |  | ")]
        cmovnle_r32_r32 = 325,

        /// <summary>
        /// cmovnle r64, m64 |  | 
        /// </summary>
        [Symbol("cmovnle r64, m64","cmovnle r64, m64 |  | ")]
        cmovnle_r64_m64 = 326,

        /// <summary>
        /// cmovnle r64, r64 |  | 
        /// </summary>
        [Symbol("cmovnle r64, r64","cmovnle r64, r64 |  | ")]
        cmovnle_r64_r64 = 327,

        /// <summary>
        /// cmovno r16, m16 |  | 
        /// </summary>
        [Symbol("cmovno r16, m16","cmovno r16, m16 |  | ")]
        cmovno_r16_m16 = 328,

        /// <summary>
        /// cmovno r16, r16 |  | 
        /// </summary>
        [Symbol("cmovno r16, r16","cmovno r16, r16 |  | ")]
        cmovno_r16_r16 = 329,

        /// <summary>
        /// cmovno r32, m32 |  | 
        /// </summary>
        [Symbol("cmovno r32, m32","cmovno r32, m32 |  | ")]
        cmovno_r32_m32 = 330,

        /// <summary>
        /// cmovno r32, r32 |  | 
        /// </summary>
        [Symbol("cmovno r32, r32","cmovno r32, r32 |  | ")]
        cmovno_r32_r32 = 331,

        /// <summary>
        /// cmovno r64, m64 |  | 
        /// </summary>
        [Symbol("cmovno r64, m64","cmovno r64, m64 |  | ")]
        cmovno_r64_m64 = 332,

        /// <summary>
        /// cmovno r64, r64 |  | 
        /// </summary>
        [Symbol("cmovno r64, r64","cmovno r64, r64 |  | ")]
        cmovno_r64_r64 = 333,

        /// <summary>
        /// cmovnp r16, m16 |  | 
        /// </summary>
        [Symbol("cmovnp r16, m16","cmovnp r16, m16 |  | ")]
        cmovnp_r16_m16 = 334,

        /// <summary>
        /// cmovnp r16, r16 |  | 
        /// </summary>
        [Symbol("cmovnp r16, r16","cmovnp r16, r16 |  | ")]
        cmovnp_r16_r16 = 335,

        /// <summary>
        /// cmovnp r32, m32 |  | 
        /// </summary>
        [Symbol("cmovnp r32, m32","cmovnp r32, m32 |  | ")]
        cmovnp_r32_m32 = 336,

        /// <summary>
        /// cmovnp r32, r32 |  | 
        /// </summary>
        [Symbol("cmovnp r32, r32","cmovnp r32, r32 |  | ")]
        cmovnp_r32_r32 = 337,

        /// <summary>
        /// cmovnp r64, m64 |  | 
        /// </summary>
        [Symbol("cmovnp r64, m64","cmovnp r64, m64 |  | ")]
        cmovnp_r64_m64 = 338,

        /// <summary>
        /// cmovnp r64, r64 |  | 
        /// </summary>
        [Symbol("cmovnp r64, r64","cmovnp r64, r64 |  | ")]
        cmovnp_r64_r64 = 339,

        /// <summary>
        /// cmovns r16, m16 |  | 
        /// </summary>
        [Symbol("cmovns r16, m16","cmovns r16, m16 |  | ")]
        cmovns_r16_m16 = 340,

        /// <summary>
        /// cmovns r16, r16 |  | 
        /// </summary>
        [Symbol("cmovns r16, r16","cmovns r16, r16 |  | ")]
        cmovns_r16_r16 = 341,

        /// <summary>
        /// cmovns r32, m32 |  | 
        /// </summary>
        [Symbol("cmovns r32, m32","cmovns r32, m32 |  | ")]
        cmovns_r32_m32 = 342,

        /// <summary>
        /// cmovns r32, r32 |  | 
        /// </summary>
        [Symbol("cmovns r32, r32","cmovns r32, r32 |  | ")]
        cmovns_r32_r32 = 343,

        /// <summary>
        /// cmovns r64, m64 |  | 
        /// </summary>
        [Symbol("cmovns r64, m64","cmovns r64, m64 |  | ")]
        cmovns_r64_m64 = 344,

        /// <summary>
        /// cmovns r64, r64 |  | 
        /// </summary>
        [Symbol("cmovns r64, r64","cmovns r64, r64 |  | ")]
        cmovns_r64_r64 = 345,

        /// <summary>
        /// cmovnz r16, m16 |  | 
        /// </summary>
        [Symbol("cmovnz r16, m16","cmovnz r16, m16 |  | ")]
        cmovnz_r16_m16 = 346,

        /// <summary>
        /// cmovnz r16, r16 |  | 
        /// </summary>
        [Symbol("cmovnz r16, r16","cmovnz r16, r16 |  | ")]
        cmovnz_r16_r16 = 347,

        /// <summary>
        /// cmovnz r32, m32 |  | 
        /// </summary>
        [Symbol("cmovnz r32, m32","cmovnz r32, m32 |  | ")]
        cmovnz_r32_m32 = 348,

        /// <summary>
        /// cmovnz r32, r32 |  | 
        /// </summary>
        [Symbol("cmovnz r32, r32","cmovnz r32, r32 |  | ")]
        cmovnz_r32_r32 = 349,

        /// <summary>
        /// cmovnz r64, m64 |  | 
        /// </summary>
        [Symbol("cmovnz r64, m64","cmovnz r64, m64 |  | ")]
        cmovnz_r64_m64 = 350,

        /// <summary>
        /// cmovnz r64, r64 |  | 
        /// </summary>
        [Symbol("cmovnz r64, r64","cmovnz r64, r64 |  | ")]
        cmovnz_r64_r64 = 351,

        /// <summary>
        /// cmovo r16, m16 |  | 
        /// </summary>
        [Symbol("cmovo r16, m16","cmovo r16, m16 |  | ")]
        cmovo_r16_m16 = 352,

        /// <summary>
        /// cmovo r16, r16 |  | 
        /// </summary>
        [Symbol("cmovo r16, r16","cmovo r16, r16 |  | ")]
        cmovo_r16_r16 = 353,

        /// <summary>
        /// cmovo r32, m32 |  | 
        /// </summary>
        [Symbol("cmovo r32, m32","cmovo r32, m32 |  | ")]
        cmovo_r32_m32 = 354,

        /// <summary>
        /// cmovo r32, r32 |  | 
        /// </summary>
        [Symbol("cmovo r32, r32","cmovo r32, r32 |  | ")]
        cmovo_r32_r32 = 355,

        /// <summary>
        /// cmovo r64, m64 |  | 
        /// </summary>
        [Symbol("cmovo r64, m64","cmovo r64, m64 |  | ")]
        cmovo_r64_m64 = 356,

        /// <summary>
        /// cmovo r64, r64 |  | 
        /// </summary>
        [Symbol("cmovo r64, r64","cmovo r64, r64 |  | ")]
        cmovo_r64_r64 = 357,

        /// <summary>
        /// cmovp r16, m16 |  | 
        /// </summary>
        [Symbol("cmovp r16, m16","cmovp r16, m16 |  | ")]
        cmovp_r16_m16 = 358,

        /// <summary>
        /// cmovp r16, r16 |  | 
        /// </summary>
        [Symbol("cmovp r16, r16","cmovp r16, r16 |  | ")]
        cmovp_r16_r16 = 359,

        /// <summary>
        /// cmovp r32, m32 |  | 
        /// </summary>
        [Symbol("cmovp r32, m32","cmovp r32, m32 |  | ")]
        cmovp_r32_m32 = 360,

        /// <summary>
        /// cmovp r32, r32 |  | 
        /// </summary>
        [Symbol("cmovp r32, r32","cmovp r32, r32 |  | ")]
        cmovp_r32_r32 = 361,

        /// <summary>
        /// cmovp r64, m64 |  | 
        /// </summary>
        [Symbol("cmovp r64, m64","cmovp r64, m64 |  | ")]
        cmovp_r64_m64 = 362,

        /// <summary>
        /// cmovp r64, r64 |  | 
        /// </summary>
        [Symbol("cmovp r64, r64","cmovp r64, r64 |  | ")]
        cmovp_r64_r64 = 363,

        /// <summary>
        /// cmovpe r16, m16 |  | 
        /// </summary>
        [Symbol("cmovpe r16, m16","cmovpe r16, m16 |  | ")]
        cmovpe_r16_m16 = 364,

        /// <summary>
        /// cmovpe r16, r16 |  | 
        /// </summary>
        [Symbol("cmovpe r16, r16","cmovpe r16, r16 |  | ")]
        cmovpe_r16_r16 = 365,

        /// <summary>
        /// cmovpe r32, m32 |  | 
        /// </summary>
        [Symbol("cmovpe r32, m32","cmovpe r32, m32 |  | ")]
        cmovpe_r32_m32 = 366,

        /// <summary>
        /// cmovpe r32, r32 |  | 
        /// </summary>
        [Symbol("cmovpe r32, r32","cmovpe r32, r32 |  | ")]
        cmovpe_r32_r32 = 367,

        /// <summary>
        /// cmovpe r64, m64 |  | 
        /// </summary>
        [Symbol("cmovpe r64, m64","cmovpe r64, m64 |  | ")]
        cmovpe_r64_m64 = 368,

        /// <summary>
        /// cmovpe r64, r64 |  | 
        /// </summary>
        [Symbol("cmovpe r64, r64","cmovpe r64, r64 |  | ")]
        cmovpe_r64_r64 = 369,

        /// <summary>
        /// cmovpo r16, m16 |  | 
        /// </summary>
        [Symbol("cmovpo r16, m16","cmovpo r16, m16 |  | ")]
        cmovpo_r16_m16 = 370,

        /// <summary>
        /// cmovpo r16, r16 |  | 
        /// </summary>
        [Symbol("cmovpo r16, r16","cmovpo r16, r16 |  | ")]
        cmovpo_r16_r16 = 371,

        /// <summary>
        /// cmovpo r32, m32 |  | 
        /// </summary>
        [Symbol("cmovpo r32, m32","cmovpo r32, m32 |  | ")]
        cmovpo_r32_m32 = 372,

        /// <summary>
        /// cmovpo r32, r32 |  | 
        /// </summary>
        [Symbol("cmovpo r32, r32","cmovpo r32, r32 |  | ")]
        cmovpo_r32_r32 = 373,

        /// <summary>
        /// cmovpo r64, m64 |  | 
        /// </summary>
        [Symbol("cmovpo r64, m64","cmovpo r64, m64 |  | ")]
        cmovpo_r64_m64 = 374,

        /// <summary>
        /// cmovpo r64, r64 |  | 
        /// </summary>
        [Symbol("cmovpo r64, r64","cmovpo r64, r64 |  | ")]
        cmovpo_r64_r64 = 375,

        /// <summary>
        /// cmovs r16, m16 |  | 
        /// </summary>
        [Symbol("cmovs r16, m16","cmovs r16, m16 |  | ")]
        cmovs_r16_m16 = 376,

        /// <summary>
        /// cmovs r16, r16 |  | 
        /// </summary>
        [Symbol("cmovs r16, r16","cmovs r16, r16 |  | ")]
        cmovs_r16_r16 = 377,

        /// <summary>
        /// cmovs r32, m32 |  | 
        /// </summary>
        [Symbol("cmovs r32, m32","cmovs r32, m32 |  | ")]
        cmovs_r32_m32 = 378,

        /// <summary>
        /// cmovs r32, r32 |  | 
        /// </summary>
        [Symbol("cmovs r32, r32","cmovs r32, r32 |  | ")]
        cmovs_r32_r32 = 379,

        /// <summary>
        /// cmovs r64, m64 |  | 
        /// </summary>
        [Symbol("cmovs r64, m64","cmovs r64, m64 |  | ")]
        cmovs_r64_m64 = 380,

        /// <summary>
        /// cmovs r64, r64 |  | 
        /// </summary>
        [Symbol("cmovs r64, r64","cmovs r64, r64 |  | ")]
        cmovs_r64_r64 = 381,

        /// <summary>
        /// cmovz r16, m16 |  | 
        /// </summary>
        [Symbol("cmovz r16, m16","cmovz r16, m16 |  | ")]
        cmovz_r16_m16 = 382,

        /// <summary>
        /// cmovz r16, r16 |  | 
        /// </summary>
        [Symbol("cmovz r16, r16","cmovz r16, r16 |  | ")]
        cmovz_r16_r16 = 383,

        /// <summary>
        /// cmovz r32, m32 |  | 
        /// </summary>
        [Symbol("cmovz r32, m32","cmovz r32, m32 |  | ")]
        cmovz_r32_m32 = 384,

        /// <summary>
        /// cmovz r32, r32 |  | 
        /// </summary>
        [Symbol("cmovz r32, r32","cmovz r32, r32 |  | ")]
        cmovz_r32_r32 = 385,

        /// <summary>
        /// cmovz r64, m64 |  | 
        /// </summary>
        [Symbol("cmovz r64, m64","cmovz r64, m64 |  | ")]
        cmovz_r64_m64 = 386,

        /// <summary>
        /// cmovz r64, r64 |  | 
        /// </summary>
        [Symbol("cmovz r64, r64","cmovz r64, r64 |  | ")]
        cmovz_r64_r64 = 387,

        /// <summary>
        /// cmp AL, imm8 |  | 
        /// </summary>
        [Symbol("cmp AL, imm8","cmp AL, imm8 |  | ")]
        cmp_AL_imm8 = 388,

        /// <summary>
        /// cmp AX, imm16 |  | 
        /// </summary>
        [Symbol("cmp AX, imm16","cmp AX, imm16 |  | ")]
        cmp_AX_imm16 = 389,

        /// <summary>
        /// cmp EAX, imm32 |  | 
        /// </summary>
        [Symbol("cmp EAX, imm32","cmp EAX, imm32 |  | ")]
        cmp_EAX_imm32 = 390,

        /// <summary>
        /// cmp m16, imm16 |  | 
        /// </summary>
        [Symbol("cmp m16, imm16","cmp m16, imm16 |  | ")]
        cmp_m16_imm16 = 391,

        /// <summary>
        /// cmp m16, imm8 |  | 
        /// </summary>
        [Symbol("cmp m16, imm8","cmp m16, imm8 |  | ")]
        cmp_m16_imm8 = 392,

        /// <summary>
        /// cmp m16, r16 |  | 
        /// </summary>
        [Symbol("cmp m16, r16","cmp m16, r16 |  | ")]
        cmp_m16_r16 = 393,

        /// <summary>
        /// cmp m32, imm32 |  | 
        /// </summary>
        [Symbol("cmp m32, imm32","cmp m32, imm32 |  | ")]
        cmp_m32_imm32 = 394,

        /// <summary>
        /// cmp m32, imm8 |  | 
        /// </summary>
        [Symbol("cmp m32, imm8","cmp m32, imm8 |  | ")]
        cmp_m32_imm8 = 395,

        /// <summary>
        /// cmp m32, r32 |  | 
        /// </summary>
        [Symbol("cmp m32, r32","cmp m32, r32 |  | ")]
        cmp_m32_r32 = 396,

        /// <summary>
        /// cmp m64, imm32 |  | 
        /// </summary>
        [Symbol("cmp m64, imm32","cmp m64, imm32 |  | ")]
        cmp_m64_imm32 = 397,

        /// <summary>
        /// cmp m64, imm8 |  | 
        /// </summary>
        [Symbol("cmp m64, imm8","cmp m64, imm8 |  | ")]
        cmp_m64_imm8 = 398,

        /// <summary>
        /// cmp m64, r64 |  | 
        /// </summary>
        [Symbol("cmp m64, r64","cmp m64, r64 |  | ")]
        cmp_m64_r64 = 399,

        /// <summary>
        /// cmp m8, imm8 |  | 
        /// </summary>
        [Symbol("cmp m8, imm8","cmp m8, imm8 |  | ")]
        cmp_m8_imm8 = 400,

        /// <summary>
        /// cmp m8, r8 |  | 
        /// </summary>
        [Symbol("cmp m8, r8","cmp m8, r8 |  | ")]
        cmp_m8_r8 = 401,

        /// <summary>
        /// cmp r16, imm16 |  | 
        /// </summary>
        [Symbol("cmp r16, imm16","cmp r16, imm16 |  | ")]
        cmp_r16_imm16 = 402,

        /// <summary>
        /// cmp r16, imm8 |  | 
        /// </summary>
        [Symbol("cmp r16, imm8","cmp r16, imm8 |  | ")]
        cmp_r16_imm8 = 403,

        /// <summary>
        /// cmp r16, m16 |  | 
        /// </summary>
        [Symbol("cmp r16, m16","cmp r16, m16 |  | ")]
        cmp_r16_m16 = 404,

        /// <summary>
        /// cmp r16, r16 |  | 
        /// </summary>
        [Symbol("cmp r16, r16","cmp r16, r16 |  | ")]
        cmp_r16_r16 = 405,

        /// <summary>
        /// cmp r32, imm32 |  | 
        /// </summary>
        [Symbol("cmp r32, imm32","cmp r32, imm32 |  | ")]
        cmp_r32_imm32 = 406,

        /// <summary>
        /// cmp r32, imm8 |  | 
        /// </summary>
        [Symbol("cmp r32, imm8","cmp r32, imm8 |  | ")]
        cmp_r32_imm8 = 407,

        /// <summary>
        /// cmp r32, m32 |  | 
        /// </summary>
        [Symbol("cmp r32, m32","cmp r32, m32 |  | ")]
        cmp_r32_m32 = 408,

        /// <summary>
        /// cmp r32, r32 |  | 
        /// </summary>
        [Symbol("cmp r32, r32","cmp r32, r32 |  | ")]
        cmp_r32_r32 = 409,

        /// <summary>
        /// cmp r64, imm32 |  | 
        /// </summary>
        [Symbol("cmp r64, imm32","cmp r64, imm32 |  | ")]
        cmp_r64_imm32 = 410,

        /// <summary>
        /// cmp r64, imm8 |  | 
        /// </summary>
        [Symbol("cmp r64, imm8","cmp r64, imm8 |  | ")]
        cmp_r64_imm8 = 411,

        /// <summary>
        /// cmp r64, m64 |  | 
        /// </summary>
        [Symbol("cmp r64, m64","cmp r64, m64 |  | ")]
        cmp_r64_m64 = 412,

        /// <summary>
        /// cmp r64, r64 |  | 
        /// </summary>
        [Symbol("cmp r64, r64","cmp r64, r64 |  | ")]
        cmp_r64_r64 = 413,

        /// <summary>
        /// cmp r8, imm8 |  | 
        /// </summary>
        [Symbol("cmp r8, imm8","cmp r8, imm8 |  | ")]
        cmp_r8_imm8 = 414,

        /// <summary>
        /// cmp r8, m8 |  | 
        /// </summary>
        [Symbol("cmp r8, m8","cmp r8, m8 |  | ")]
        cmp_r8_m8 = 415,

        /// <summary>
        /// cmp r8, r8 |  | 
        /// </summary>
        [Symbol("cmp r8, r8","cmp r8, r8 |  | ")]
        cmp_r8_r8 = 416,

        /// <summary>
        /// cmp RAX, imm32 |  | 
        /// </summary>
        [Symbol("cmp RAX, imm32","cmp RAX, imm32 |  | ")]
        cmp_RAX_imm32 = 417,

        /// <summary>
        /// cmpps xmm, m128, imm8 |  | 
        /// </summary>
        [Symbol("cmpps xmm, m128, imm8","cmpps xmm, m128, imm8 |  | ")]
        cmpps_xmm_m128_imm8 = 418,

        /// <summary>
        /// cmpps xmm, r8, imm8 |  | 
        /// </summary>
        [Symbol("cmpps xmm, r8, imm8","cmpps xmm, r8, imm8 |  | ")]
        cmpps_xmm_r8_imm8 = 419,

        /// <summary>
        /// cmps m16, m16 |  | 
        /// </summary>
        [Symbol("cmps m16, m16","cmps m16, m16 |  | ")]
        cmps_m16_m16 = 420,

        /// <summary>
        /// cmps m32, m32 |  | 
        /// </summary>
        [Symbol("cmps m32, m32","cmps m32, m32 |  | ")]
        cmps_m32_m32 = 421,

        /// <summary>
        /// cmps m64, m64 |  | 
        /// </summary>
        [Symbol("cmps m64, m64","cmps m64, m64 |  | ")]
        cmps_m64_m64 = 422,

        /// <summary>
        /// cmps m8, m8 |  | 
        /// </summary>
        [Symbol("cmps m8, m8","cmps m8, m8 |  | ")]
        cmps_m8_m8 = 423,

        /// <summary>
        /// cmpsb |  | 
        /// </summary>
        [Symbol("cmpsb","cmpsb |  | ")]
        cmpsb = 424,

        /// <summary>
        /// cmpsd |  | 
        /// </summary>
        [Symbol("cmpsd","cmpsd |  | ")]
        cmpsd = 425,

        /// <summary>
        /// cmpsq |  | 
        /// </summary>
        [Symbol("cmpsq","cmpsq |  | ")]
        cmpsq = 426,

        /// <summary>
        /// cmpss xmm, m32, imm8 |  | 
        /// </summary>
        [Symbol("cmpss xmm, m32, imm8","cmpss xmm, m32, imm8 |  | ")]
        cmpss_xmm_m32_imm8 = 427,

        /// <summary>
        /// cmpss xmm, r8, imm8 |  | 
        /// </summary>
        [Symbol("cmpss xmm, r8, imm8","cmpss xmm, r8, imm8 |  | ")]
        cmpss_xmm_r8_imm8 = 428,

        /// <summary>
        /// cmpsw |  | 
        /// </summary>
        [Symbol("cmpsw","cmpsw |  | ")]
        cmpsw = 429,

        /// <summary>
        /// cmpxchg m16, r16 |  | 
        /// </summary>
        [Symbol("cmpxchg m16, r16","cmpxchg m16, r16 |  | ")]
        cmpxchg_m16_r16 = 430,

        /// <summary>
        /// cmpxchg m32, r32 |  | 
        /// </summary>
        [Symbol("cmpxchg m32, r32","cmpxchg m32, r32 |  | ")]
        cmpxchg_m32_r32 = 431,

        /// <summary>
        /// cmpxchg m64, r64 |  | 
        /// </summary>
        [Symbol("cmpxchg m64, r64","cmpxchg m64, r64 |  | ")]
        cmpxchg_m64_r64 = 432,

        /// <summary>
        /// cmpxchg m8, r8 |  | 
        /// </summary>
        [Symbol("cmpxchg m8, r8","cmpxchg m8, r8 |  | ")]
        cmpxchg_m8_r8 = 433,

        /// <summary>
        /// cmpxchg r16, r16 |  | 
        /// </summary>
        [Symbol("cmpxchg r16, r16","cmpxchg r16, r16 |  | ")]
        cmpxchg_r16_r16 = 434,

        /// <summary>
        /// cmpxchg r32, r32 |  | 
        /// </summary>
        [Symbol("cmpxchg r32, r32","cmpxchg r32, r32 |  | ")]
        cmpxchg_r32_r32 = 435,

        /// <summary>
        /// cmpxchg r64, r64 |  | 
        /// </summary>
        [Symbol("cmpxchg r64, r64","cmpxchg r64, r64 |  | ")]
        cmpxchg_r64_r64 = 436,

        /// <summary>
        /// cmpxchg r8, r8 |  | 
        /// </summary>
        [Symbol("cmpxchg r8, r8","cmpxchg r8, r8 |  | ")]
        cmpxchg_r8_r8 = 437,

        /// <summary>
        /// cmpxchg16b m128 |  | 
        /// </summary>
        [Symbol("cmpxchg16b m128","cmpxchg16b m128 |  | ")]
        cmpxchg16b_m128 = 438,

        /// <summary>
        /// cmpxchg8b m64 |  | 
        /// </summary>
        [Symbol("cmpxchg8b m64","cmpxchg8b m64 |  | ")]
        cmpxchg8b_m64 = 439,

        /// <summary>
        /// cqo |  | 
        /// </summary>
        [Symbol("cqo","cqo |  | ")]
        cqo = 440,

        /// <summary>
        /// crc32 r32, m16 |  | 
        /// </summary>
        [Symbol("crc32 r32, m16","crc32 r32, m16 |  | ")]
        crc32_r32_m16 = 441,

        /// <summary>
        /// crc32 r32, m32 |  | 
        /// </summary>
        [Symbol("crc32 r32, m32","crc32 r32, m32 |  | ")]
        crc32_r32_m32 = 442,

        /// <summary>
        /// crc32 r32, m8 |  | 
        /// </summary>
        [Symbol("crc32 r32, m8","crc32 r32, m8 |  | ")]
        crc32_r32_m8 = 443,

        /// <summary>
        /// crc32 r32, r16 |  | 
        /// </summary>
        [Symbol("crc32 r32, r16","crc32 r32, r16 |  | ")]
        crc32_r32_r16 = 444,

        /// <summary>
        /// crc32 r32, r32 |  | 
        /// </summary>
        [Symbol("crc32 r32, r32","crc32 r32, r32 |  | ")]
        crc32_r32_r32 = 445,

        /// <summary>
        /// crc32 r32, r8 |  | 
        /// </summary>
        [Symbol("crc32 r32, r8","crc32 r32, r8 |  | ")]
        crc32_r32_r8 = 446,

        /// <summary>
        /// crc32 r64, m64 |  | 
        /// </summary>
        [Symbol("crc32 r64, m64","crc32 r64, m64 |  | ")]
        crc32_r64_m64 = 447,

        /// <summary>
        /// crc32 r64, m8 |  | 
        /// </summary>
        [Symbol("crc32 r64, m8","crc32 r64, m8 |  | ")]
        crc32_r64_m8 = 448,

        /// <summary>
        /// crc32 r64, r64 |  | 
        /// </summary>
        [Symbol("crc32 r64, r64","crc32 r64, r64 |  | ")]
        crc32_r64_r64 = 449,

        /// <summary>
        /// crc32 r64, r8 |  | 
        /// </summary>
        [Symbol("crc32 r64, r8","crc32 r64, r8 |  | ")]
        crc32_r64_r8 = 450,

        /// <summary>
        /// cwd |  | 
        /// </summary>
        [Symbol("cwd","cwd |  | ")]
        cwd = 451,

        /// <summary>
        /// cwde |  | 
        /// </summary>
        [Symbol("cwde","cwde |  | ")]
        cwde = 452,

        /// <summary>
        /// dec m16 |  | 
        /// </summary>
        [Symbol("dec m16","dec m16 |  | ")]
        dec_m16 = 453,

        /// <summary>
        /// dec m32 |  | 
        /// </summary>
        [Symbol("dec m32","dec m32 |  | ")]
        dec_m32 = 454,

        /// <summary>
        /// dec m64 |  | 
        /// </summary>
        [Symbol("dec m64","dec m64 |  | ")]
        dec_m64 = 455,

        /// <summary>
        /// dec m8 |  | 
        /// </summary>
        [Symbol("dec m8","dec m8 |  | ")]
        dec_m8 = 456,

        /// <summary>
        /// dec r16 |  | 
        /// </summary>
        [Symbol("dec r16","dec r16 |  | ")]
        dec_r16 = 457,

        /// <summary>
        /// dec r32 |  | 
        /// </summary>
        [Symbol("dec r32","dec r32 |  | ")]
        dec_r32 = 458,

        /// <summary>
        /// dec r64 |  | 
        /// </summary>
        [Symbol("dec r64","dec r64 |  | ")]
        dec_r64 = 459,

        /// <summary>
        /// dec r8 |  | 
        /// </summary>
        [Symbol("dec r8","dec r8 |  | ")]
        dec_r8 = 460,

        /// <summary>
        /// div m16 |  | 
        /// </summary>
        [Symbol("div m16","div m16 |  | ")]
        div_m16 = 461,

        /// <summary>
        /// div m32 |  | 
        /// </summary>
        [Symbol("div m32","div m32 |  | ")]
        div_m32 = 462,

        /// <summary>
        /// div m64 |  | 
        /// </summary>
        [Symbol("div m64","div m64 |  | ")]
        div_m64 = 463,

        /// <summary>
        /// div m8 |  | 
        /// </summary>
        [Symbol("div m8","div m8 |  | ")]
        div_m8 = 464,

        /// <summary>
        /// div r16 |  | 
        /// </summary>
        [Symbol("div r16","div r16 |  | ")]
        div_r16 = 465,

        /// <summary>
        /// div r32 |  | 
        /// </summary>
        [Symbol("div r32","div r32 |  | ")]
        div_r32 = 466,

        /// <summary>
        /// div r64 |  | 
        /// </summary>
        [Symbol("div r64","div r64 |  | ")]
        div_r64 = 467,

        /// <summary>
        /// div r8 |  | 
        /// </summary>
        [Symbol("div r8","div r8 |  | ")]
        div_r8 = 468,

        /// <summary>
        /// enter imm16, imm8 |  | 
        /// </summary>
        [Symbol("enter imm16, imm8","enter imm16, imm8 |  | ")]
        enter_imm16_imm8 = 469,

        /// <summary>
        /// enter imm16, 0 |  | 
        /// </summary>
        [Symbol("enter imm16, 0","enter imm16, 0 |  | ")]
        enter_imm16_n0 = 470,

        /// <summary>
        /// enter imm16, 1 |  | 
        /// </summary>
        [Symbol("enter imm16, 1","enter imm16, 1 |  | ")]
        enter_imm16_n1 = 471,

        /// <summary>
        /// hlt |  | 
        /// </summary>
        [Symbol("hlt","hlt |  | ")]
        hlt = 472,

        /// <summary>
        /// idiv m16 |  | 
        /// </summary>
        [Symbol("idiv m16","idiv m16 |  | ")]
        idiv_m16 = 473,

        /// <summary>
        /// idiv m32 |  | 
        /// </summary>
        [Symbol("idiv m32","idiv m32 |  | ")]
        idiv_m32 = 474,

        /// <summary>
        /// idiv m64 |  | 
        /// </summary>
        [Symbol("idiv m64","idiv m64 |  | ")]
        idiv_m64 = 475,

        /// <summary>
        /// idiv m8 |  | 
        /// </summary>
        [Symbol("idiv m8","idiv m8 |  | ")]
        idiv_m8 = 476,

        /// <summary>
        /// idiv r16 |  | 
        /// </summary>
        [Symbol("idiv r16","idiv r16 |  | ")]
        idiv_r16 = 477,

        /// <summary>
        /// idiv r32 |  | 
        /// </summary>
        [Symbol("idiv r32","idiv r32 |  | ")]
        idiv_r32 = 478,

        /// <summary>
        /// idiv r64 |  | 
        /// </summary>
        [Symbol("idiv r64","idiv r64 |  | ")]
        idiv_r64 = 479,

        /// <summary>
        /// idiv r8 |  | 
        /// </summary>
        [Symbol("idiv r8","idiv r8 |  | ")]
        idiv_r8 = 480,

        /// <summary>
        /// imul m16 |  | 
        /// </summary>
        [Symbol("imul m16","imul m16 |  | ")]
        imul_m16 = 481,

        /// <summary>
        /// imul m32 |  | 
        /// </summary>
        [Symbol("imul m32","imul m32 |  | ")]
        imul_m32 = 482,

        /// <summary>
        /// imul m64 |  | 
        /// </summary>
        [Symbol("imul m64","imul m64 |  | ")]
        imul_m64 = 483,

        /// <summary>
        /// imul m8 |  | 
        /// </summary>
        [Symbol("imul m8","imul m8 |  | ")]
        imul_m8 = 484,

        /// <summary>
        /// imul r16 |  | 
        /// </summary>
        [Symbol("imul r16","imul r16 |  | ")]
        imul_r16 = 485,

        /// <summary>
        /// imul r16, m16 |  | 
        /// </summary>
        [Symbol("imul r16, m16","imul r16, m16 |  | ")]
        imul_r16_m16 = 486,

        /// <summary>
        /// imul r16, m16, imm16 |  | 
        /// </summary>
        [Symbol("imul r16, m16, imm16","imul r16, m16, imm16 |  | ")]
        imul_r16_m16_imm16 = 487,

        /// <summary>
        /// imul r16, m16, imm8 |  | 
        /// </summary>
        [Symbol("imul r16, m16, imm8","imul r16, m16, imm8 |  | ")]
        imul_r16_m16_imm8 = 488,

        /// <summary>
        /// imul r16, r16 |  | 
        /// </summary>
        [Symbol("imul r16, r16","imul r16, r16 |  | ")]
        imul_r16_r16 = 489,

        /// <summary>
        /// imul r16, r16, imm16 |  | 
        /// </summary>
        [Symbol("imul r16, r16, imm16","imul r16, r16, imm16 |  | ")]
        imul_r16_r16_imm16 = 490,

        /// <summary>
        /// imul r16, r16, imm8 |  | 
        /// </summary>
        [Symbol("imul r16, r16, imm8","imul r16, r16, imm8 |  | ")]
        imul_r16_r16_imm8 = 491,

        /// <summary>
        /// imul r32 |  | 
        /// </summary>
        [Symbol("imul r32","imul r32 |  | ")]
        imul_r32 = 492,

        /// <summary>
        /// imul r32, m32 |  | 
        /// </summary>
        [Symbol("imul r32, m32","imul r32, m32 |  | ")]
        imul_r32_m32 = 493,

        /// <summary>
        /// imul r32, m32, imm32 |  | 
        /// </summary>
        [Symbol("imul r32, m32, imm32","imul r32, m32, imm32 |  | ")]
        imul_r32_m32_imm32 = 494,

        /// <summary>
        /// imul r32, m32, imm8 |  | 
        /// </summary>
        [Symbol("imul r32, m32, imm8","imul r32, m32, imm8 |  | ")]
        imul_r32_m32_imm8 = 495,

        /// <summary>
        /// imul r32, r32 |  | 
        /// </summary>
        [Symbol("imul r32, r32","imul r32, r32 |  | ")]
        imul_r32_r32 = 496,

        /// <summary>
        /// imul r32, r32, imm32 |  | 
        /// </summary>
        [Symbol("imul r32, r32, imm32","imul r32, r32, imm32 |  | ")]
        imul_r32_r32_imm32 = 497,

        /// <summary>
        /// imul r32, r32, imm8 |  | 
        /// </summary>
        [Symbol("imul r32, r32, imm8","imul r32, r32, imm8 |  | ")]
        imul_r32_r32_imm8 = 498,

        /// <summary>
        /// imul r64 |  | 
        /// </summary>
        [Symbol("imul r64","imul r64 |  | ")]
        imul_r64 = 499,

        /// <summary>
        /// imul r64, m64 |  | 
        /// </summary>
        [Symbol("imul r64, m64","imul r64, m64 |  | ")]
        imul_r64_m64 = 500,

        /// <summary>
        /// imul r64, m64, imm32 |  | 
        /// </summary>
        [Symbol("imul r64, m64, imm32","imul r64, m64, imm32 |  | ")]
        imul_r64_m64_imm32 = 501,

        /// <summary>
        /// imul r64, m64, imm8 |  | 
        /// </summary>
        [Symbol("imul r64, m64, imm8","imul r64, m64, imm8 |  | ")]
        imul_r64_m64_imm8 = 502,

        /// <summary>
        /// imul r64, r64 |  | 
        /// </summary>
        [Symbol("imul r64, r64","imul r64, r64 |  | ")]
        imul_r64_r64 = 503,

        /// <summary>
        /// imul r64, r64, imm32 |  | 
        /// </summary>
        [Symbol("imul r64, r64, imm32","imul r64, r64, imm32 |  | ")]
        imul_r64_r64_imm32 = 504,

        /// <summary>
        /// imul r64, r64, imm8 |  | 
        /// </summary>
        [Symbol("imul r64, r64, imm8","imul r64, r64, imm8 |  | ")]
        imul_r64_r64_imm8 = 505,

        /// <summary>
        /// imul r8 |  | 
        /// </summary>
        [Symbol("imul r8","imul r8 |  | ")]
        imul_r8 = 506,

        /// <summary>
        /// in AL, DX |  | 
        /// </summary>
        [Symbol("in AL, DX","in AL, DX |  | ")]
        in_AL_DX = 507,

        /// <summary>
        /// in AL, imm8 |  | 
        /// </summary>
        [Symbol("in AL, imm8","in AL, imm8 |  | ")]
        in_AL_imm8 = 508,

        /// <summary>
        /// in AX, DX |  | 
        /// </summary>
        [Symbol("in AX, DX","in AX, DX |  | ")]
        in_AX_DX = 509,

        /// <summary>
        /// in AX, imm8 |  | 
        /// </summary>
        [Symbol("in AX, imm8","in AX, imm8 |  | ")]
        in_AX_imm8 = 510,

        /// <summary>
        /// in EAX, DX |  | 
        /// </summary>
        [Symbol("in EAX, DX","in EAX, DX |  | ")]
        in_EAX_DX = 511,

        /// <summary>
        /// in EAX, imm8 |  | 
        /// </summary>
        [Symbol("in EAX, imm8","in EAX, imm8 |  | ")]
        in_EAX_imm8 = 512,

        /// <summary>
        /// inc m16 |  | 
        /// </summary>
        [Symbol("inc m16","inc m16 |  | ")]
        inc_m16 = 513,

        /// <summary>
        /// inc m32 |  | 
        /// </summary>
        [Symbol("inc m32","inc m32 |  | ")]
        inc_m32 = 514,

        /// <summary>
        /// inc m64 |  | 
        /// </summary>
        [Symbol("inc m64","inc m64 |  | ")]
        inc_m64 = 515,

        /// <summary>
        /// inc m8 |  | 
        /// </summary>
        [Symbol("inc m8","inc m8 |  | ")]
        inc_m8 = 516,

        /// <summary>
        /// inc r16 |  | 
        /// </summary>
        [Symbol("inc r16","inc r16 |  | ")]
        inc_r16 = 517,

        /// <summary>
        /// inc r32 |  | 
        /// </summary>
        [Symbol("inc r32","inc r32 |  | ")]
        inc_r32 = 518,

        /// <summary>
        /// inc r64 |  | 
        /// </summary>
        [Symbol("inc r64","inc r64 |  | ")]
        inc_r64 = 519,

        /// <summary>
        /// inc r8 |  | 
        /// </summary>
        [Symbol("inc r8","inc r8 |  | ")]
        inc_r8 = 520,

        /// <summary>
        /// ins m16, DX |  | 
        /// </summary>
        [Symbol("ins m16, DX","ins m16, DX |  | ")]
        ins_m16_DX = 521,

        /// <summary>
        /// ins m32, DX |  | 
        /// </summary>
        [Symbol("ins m32, DX","ins m32, DX |  | ")]
        ins_m32_DX = 522,

        /// <summary>
        /// ins m8, DX |  | 
        /// </summary>
        [Symbol("ins m8, DX","ins m8, DX |  | ")]
        ins_m8_DX = 523,

        /// <summary>
        /// insb |  | 
        /// </summary>
        [Symbol("insb","insb |  | ")]
        insb = 524,

        /// <summary>
        /// insd |  | 
        /// </summary>
        [Symbol("insd","insd |  | ")]
        insd = 525,

        /// <summary>
        /// insw |  | 
        /// </summary>
        [Symbol("insw","insw |  | ")]
        insw = 526,

        /// <summary>
        /// int imm8 |  | 
        /// </summary>
        [Symbol("int imm8","int imm8 |  | ")]
        int_imm8 = 527,

        /// <summary>
        /// int1 |  | 
        /// </summary>
        [Symbol("int1","int1 |  | ")]
        int1 = 528,

        /// <summary>
        /// int3 |  | 
        /// </summary>
        [Symbol("int3","int3 |  | ")]
        int3 = 529,

        /// <summary>
        /// into |  | 
        /// </summary>
        [Symbol("into","into |  | ")]
        into = 530,

        /// <summary>
        /// ja rel16 |  | 
        /// </summary>
        [Symbol("ja rel16","ja rel16 |  | ")]
        ja_rel16 = 531,

        /// <summary>
        /// ja rel32 |  | 
        /// </summary>
        [Symbol("ja rel32","ja rel32 |  | ")]
        ja_rel32 = 532,

        /// <summary>
        /// ja rel8 |  | 
        /// </summary>
        [Symbol("ja rel8","ja rel8 |  | ")]
        ja_rel8 = 533,

        /// <summary>
        /// jae rel16 |  | 
        /// </summary>
        [Symbol("jae rel16","jae rel16 |  | ")]
        jae_rel16 = 534,

        /// <summary>
        /// jae rel32 |  | 
        /// </summary>
        [Symbol("jae rel32","jae rel32 |  | ")]
        jae_rel32 = 535,

        /// <summary>
        /// jae rel8 |  | 
        /// </summary>
        [Symbol("jae rel8","jae rel8 |  | ")]
        jae_rel8 = 536,

        /// <summary>
        /// jb rel16 |  | 
        /// </summary>
        [Symbol("jb rel16","jb rel16 |  | ")]
        jb_rel16 = 537,

        /// <summary>
        /// jb rel32 |  | 
        /// </summary>
        [Symbol("jb rel32","jb rel32 |  | ")]
        jb_rel32 = 538,

        /// <summary>
        /// jb rel8 |  | 
        /// </summary>
        [Symbol("jb rel8","jb rel8 |  | ")]
        jb_rel8 = 539,

        /// <summary>
        /// jbe rel16 |  | 
        /// </summary>
        [Symbol("jbe rel16","jbe rel16 |  | ")]
        jbe_rel16 = 540,

        /// <summary>
        /// jbe rel32 |  | 
        /// </summary>
        [Symbol("jbe rel32","jbe rel32 |  | ")]
        jbe_rel32 = 541,

        /// <summary>
        /// jbe rel8 |  | 
        /// </summary>
        [Symbol("jbe rel8","jbe rel8 |  | ")]
        jbe_rel8 = 542,

        /// <summary>
        /// jc rel16 |  | 
        /// </summary>
        [Symbol("jc rel16","jc rel16 |  | ")]
        jc_rel16 = 543,

        /// <summary>
        /// jc rel32 |  | 
        /// </summary>
        [Symbol("jc rel32","jc rel32 |  | ")]
        jc_rel32 = 544,

        /// <summary>
        /// jc rel8 |  | 
        /// </summary>
        [Symbol("jc rel8","jc rel8 |  | ")]
        jc_rel8 = 545,

        /// <summary>
        /// jcxz rel8 |  | 
        /// </summary>
        [Symbol("jcxz rel8","jcxz rel8 |  | ")]
        jcxz_rel8 = 546,

        /// <summary>
        /// je rel16 |  | 
        /// </summary>
        [Symbol("je rel16","je rel16 |  | ")]
        je_rel16 = 547,

        /// <summary>
        /// je rel32 |  | 
        /// </summary>
        [Symbol("je rel32","je rel32 |  | ")]
        je_rel32 = 548,

        /// <summary>
        /// je rel8 |  | 
        /// </summary>
        [Symbol("je rel8","je rel8 |  | ")]
        je_rel8 = 549,

        /// <summary>
        /// jecxz rel8 |  | 
        /// </summary>
        [Symbol("jecxz rel8","jecxz rel8 |  | ")]
        jecxz_rel8 = 550,

        /// <summary>
        /// jg rel16 |  | 
        /// </summary>
        [Symbol("jg rel16","jg rel16 |  | ")]
        jg_rel16 = 551,

        /// <summary>
        /// jg rel32 |  | 
        /// </summary>
        [Symbol("jg rel32","jg rel32 |  | ")]
        jg_rel32 = 552,

        /// <summary>
        /// jg rel8 |  | 
        /// </summary>
        [Symbol("jg rel8","jg rel8 |  | ")]
        jg_rel8 = 553,

        /// <summary>
        /// jge rel16 |  | 
        /// </summary>
        [Symbol("jge rel16","jge rel16 |  | ")]
        jge_rel16 = 554,

        /// <summary>
        /// jge rel32 |  | 
        /// </summary>
        [Symbol("jge rel32","jge rel32 |  | ")]
        jge_rel32 = 555,

        /// <summary>
        /// jge rel8 |  | 
        /// </summary>
        [Symbol("jge rel8","jge rel8 |  | ")]
        jge_rel8 = 556,

        /// <summary>
        /// jl rel16 |  | 
        /// </summary>
        [Symbol("jl rel16","jl rel16 |  | ")]
        jl_rel16 = 557,

        /// <summary>
        /// jl rel32 |  | 
        /// </summary>
        [Symbol("jl rel32","jl rel32 |  | ")]
        jl_rel32 = 558,

        /// <summary>
        /// jl rel8 |  | 
        /// </summary>
        [Symbol("jl rel8","jl rel8 |  | ")]
        jl_rel8 = 559,

        /// <summary>
        /// jle rel16 |  | 
        /// </summary>
        [Symbol("jle rel16","jle rel16 |  | ")]
        jle_rel16 = 560,

        /// <summary>
        /// jle rel32 |  | 
        /// </summary>
        [Symbol("jle rel32","jle rel32 |  | ")]
        jle_rel32 = 561,

        /// <summary>
        /// jle rel8 |  | 
        /// </summary>
        [Symbol("jle rel8","jle rel8 |  | ")]
        jle_rel8 = 562,

        /// <summary>
        /// jmp m16 |  | 
        /// </summary>
        [Symbol("jmp m16","jmp m16 |  | ")]
        jmp_m16 = 563,

        /// <summary>
        /// jmp m32 |  | 
        /// </summary>
        [Symbol("jmp m32","jmp m32 |  | ")]
        jmp_m32 = 564,

        /// <summary>
        /// jmp m64 |  | 
        /// </summary>
        [Symbol("jmp m64","jmp m64 |  | ")]
        jmp_m64 = 565,

        /// <summary>
        /// jmp m16:16 |  | 
        /// </summary>
        [Symbol("jmp m16:16","jmp m16:16 |  | ")]
        jmp_mp16x16 = 566,

        /// <summary>
        /// jmp m16:32 |  | 
        /// </summary>
        [Symbol("jmp m16:32","jmp m16:32 |  | ")]
        jmp_mp16x32 = 567,

        /// <summary>
        /// jmp m16:64 |  | 
        /// </summary>
        [Symbol("jmp m16:64","jmp m16:64 |  | ")]
        jmp_mp16x64 = 568,

        /// <summary>
        /// jmp ptr16:16 |  | 
        /// </summary>
        [Symbol("jmp ptr16:16","jmp ptr16:16 |  | ")]
        jmp_p16x16 = 569,

        /// <summary>
        /// jmp ptr16:32 |  | 
        /// </summary>
        [Symbol("jmp ptr16:32","jmp ptr16:32 |  | ")]
        jmp_p16x32 = 570,

        /// <summary>
        /// jmp r16 |  | 
        /// </summary>
        [Symbol("jmp r16","jmp r16 |  | ")]
        jmp_r16 = 571,

        /// <summary>
        /// jmp r32 |  | 
        /// </summary>
        [Symbol("jmp r32","jmp r32 |  | ")]
        jmp_r32 = 572,

        /// <summary>
        /// jmp r64 |  | 
        /// </summary>
        [Symbol("jmp r64","jmp r64 |  | ")]
        jmp_r64 = 573,

        /// <summary>
        /// jmp rel16 |  | 
        /// </summary>
        [Symbol("jmp rel16","jmp rel16 |  | ")]
        jmp_rel16 = 574,

        /// <summary>
        /// jmp rel32 |  | 
        /// </summary>
        [Symbol("jmp rel32","jmp rel32 |  | ")]
        jmp_rel32 = 575,

        /// <summary>
        /// jmp rel8 |  | 
        /// </summary>
        [Symbol("jmp rel8","jmp rel8 |  | ")]
        jmp_rel8 = 576,

        /// <summary>
        /// jna rel16 |  | 
        /// </summary>
        [Symbol("jna rel16","jna rel16 |  | ")]
        jna_rel16 = 577,

        /// <summary>
        /// jna rel32 |  | 
        /// </summary>
        [Symbol("jna rel32","jna rel32 |  | ")]
        jna_rel32 = 578,

        /// <summary>
        /// jna rel8 |  | 
        /// </summary>
        [Symbol("jna rel8","jna rel8 |  | ")]
        jna_rel8 = 579,

        /// <summary>
        /// jnae rel16 |  | 
        /// </summary>
        [Symbol("jnae rel16","jnae rel16 |  | ")]
        jnae_rel16 = 580,

        /// <summary>
        /// jnae rel32 |  | 
        /// </summary>
        [Symbol("jnae rel32","jnae rel32 |  | ")]
        jnae_rel32 = 581,

        /// <summary>
        /// jnae rel8 |  | 
        /// </summary>
        [Symbol("jnae rel8","jnae rel8 |  | ")]
        jnae_rel8 = 582,

        /// <summary>
        /// jnb rel16 |  | 
        /// </summary>
        [Symbol("jnb rel16","jnb rel16 |  | ")]
        jnb_rel16 = 583,

        /// <summary>
        /// jnb rel32 |  | 
        /// </summary>
        [Symbol("jnb rel32","jnb rel32 |  | ")]
        jnb_rel32 = 584,

        /// <summary>
        /// jnb rel8 |  | 
        /// </summary>
        [Symbol("jnb rel8","jnb rel8 |  | ")]
        jnb_rel8 = 585,

        /// <summary>
        /// jnbe rel16 |  | 
        /// </summary>
        [Symbol("jnbe rel16","jnbe rel16 |  | ")]
        jnbe_rel16 = 586,

        /// <summary>
        /// jnbe rel32 |  | 
        /// </summary>
        [Symbol("jnbe rel32","jnbe rel32 |  | ")]
        jnbe_rel32 = 587,

        /// <summary>
        /// jnbe rel8 |  | 
        /// </summary>
        [Symbol("jnbe rel8","jnbe rel8 |  | ")]
        jnbe_rel8 = 588,

        /// <summary>
        /// jnc rel16 |  | 
        /// </summary>
        [Symbol("jnc rel16","jnc rel16 |  | ")]
        jnc_rel16 = 589,

        /// <summary>
        /// jnc rel32 |  | 
        /// </summary>
        [Symbol("jnc rel32","jnc rel32 |  | ")]
        jnc_rel32 = 590,

        /// <summary>
        /// jnc rel8 |  | 
        /// </summary>
        [Symbol("jnc rel8","jnc rel8 |  | ")]
        jnc_rel8 = 591,

        /// <summary>
        /// jne rel16 |  | 
        /// </summary>
        [Symbol("jne rel16","jne rel16 |  | ")]
        jne_rel16 = 592,

        /// <summary>
        /// jne rel32 |  | 
        /// </summary>
        [Symbol("jne rel32","jne rel32 |  | ")]
        jne_rel32 = 593,

        /// <summary>
        /// jne rel8 |  | 
        /// </summary>
        [Symbol("jne rel8","jne rel8 |  | ")]
        jne_rel8 = 594,

        /// <summary>
        /// jng rel16 |  | 
        /// </summary>
        [Symbol("jng rel16","jng rel16 |  | ")]
        jng_rel16 = 595,

        /// <summary>
        /// jng rel32 |  | 
        /// </summary>
        [Symbol("jng rel32","jng rel32 |  | ")]
        jng_rel32 = 596,

        /// <summary>
        /// jng rel8 |  | 
        /// </summary>
        [Symbol("jng rel8","jng rel8 |  | ")]
        jng_rel8 = 597,

        /// <summary>
        /// jnge rel16 |  | 
        /// </summary>
        [Symbol("jnge rel16","jnge rel16 |  | ")]
        jnge_rel16 = 598,

        /// <summary>
        /// jnge rel32 |  | 
        /// </summary>
        [Symbol("jnge rel32","jnge rel32 |  | ")]
        jnge_rel32 = 599,

        /// <summary>
        /// jnge rel8 |  | 
        /// </summary>
        [Symbol("jnge rel8","jnge rel8 |  | ")]
        jnge_rel8 = 600,

        /// <summary>
        /// jnl rel16 |  | 
        /// </summary>
        [Symbol("jnl rel16","jnl rel16 |  | ")]
        jnl_rel16 = 601,

        /// <summary>
        /// jnl rel32 |  | 
        /// </summary>
        [Symbol("jnl rel32","jnl rel32 |  | ")]
        jnl_rel32 = 602,

        /// <summary>
        /// jnl rel8 |  | 
        /// </summary>
        [Symbol("jnl rel8","jnl rel8 |  | ")]
        jnl_rel8 = 603,

        /// <summary>
        /// jnle rel16 |  | 
        /// </summary>
        [Symbol("jnle rel16","jnle rel16 |  | ")]
        jnle_rel16 = 604,

        /// <summary>
        /// jnle rel32 |  | 
        /// </summary>
        [Symbol("jnle rel32","jnle rel32 |  | ")]
        jnle_rel32 = 605,

        /// <summary>
        /// jnle rel8 |  | 
        /// </summary>
        [Symbol("jnle rel8","jnle rel8 |  | ")]
        jnle_rel8 = 606,

        /// <summary>
        /// jno rel16 |  | 
        /// </summary>
        [Symbol("jno rel16","jno rel16 |  | ")]
        jno_rel16 = 607,

        /// <summary>
        /// jno rel32 |  | 
        /// </summary>
        [Symbol("jno rel32","jno rel32 |  | ")]
        jno_rel32 = 608,

        /// <summary>
        /// jno rel8 |  | 
        /// </summary>
        [Symbol("jno rel8","jno rel8 |  | ")]
        jno_rel8 = 609,

        /// <summary>
        /// jnp rel16 |  | 
        /// </summary>
        [Symbol("jnp rel16","jnp rel16 |  | ")]
        jnp_rel16 = 610,

        /// <summary>
        /// jnp rel32 |  | 
        /// </summary>
        [Symbol("jnp rel32","jnp rel32 |  | ")]
        jnp_rel32 = 611,

        /// <summary>
        /// jnp rel8 |  | 
        /// </summary>
        [Symbol("jnp rel8","jnp rel8 |  | ")]
        jnp_rel8 = 612,

        /// <summary>
        /// jns rel16 |  | 
        /// </summary>
        [Symbol("jns rel16","jns rel16 |  | ")]
        jns_rel16 = 613,

        /// <summary>
        /// jns rel32 |  | 
        /// </summary>
        [Symbol("jns rel32","jns rel32 |  | ")]
        jns_rel32 = 614,

        /// <summary>
        /// jns rel8 |  | 
        /// </summary>
        [Symbol("jns rel8","jns rel8 |  | ")]
        jns_rel8 = 615,

        /// <summary>
        /// jnz rel16 |  | 
        /// </summary>
        [Symbol("jnz rel16","jnz rel16 |  | ")]
        jnz_rel16 = 616,

        /// <summary>
        /// jnz rel32 |  | 
        /// </summary>
        [Symbol("jnz rel32","jnz rel32 |  | ")]
        jnz_rel32 = 617,

        /// <summary>
        /// jnz rel8 |  | 
        /// </summary>
        [Symbol("jnz rel8","jnz rel8 |  | ")]
        jnz_rel8 = 618,

        /// <summary>
        /// jo rel16 |  | 
        /// </summary>
        [Symbol("jo rel16","jo rel16 |  | ")]
        jo_rel16 = 619,

        /// <summary>
        /// jo rel32 |  | 
        /// </summary>
        [Symbol("jo rel32","jo rel32 |  | ")]
        jo_rel32 = 620,

        /// <summary>
        /// jo rel8 |  | 
        /// </summary>
        [Symbol("jo rel8","jo rel8 |  | ")]
        jo_rel8 = 621,

        /// <summary>
        /// jp rel16 |  | 
        /// </summary>
        [Symbol("jp rel16","jp rel16 |  | ")]
        jp_rel16 = 622,

        /// <summary>
        /// jp rel32 |  | 
        /// </summary>
        [Symbol("jp rel32","jp rel32 |  | ")]
        jp_rel32 = 623,

        /// <summary>
        /// jp rel8 |  | 
        /// </summary>
        [Symbol("jp rel8","jp rel8 |  | ")]
        jp_rel8 = 624,

        /// <summary>
        /// jpe rel16 |  | 
        /// </summary>
        [Symbol("jpe rel16","jpe rel16 |  | ")]
        jpe_rel16 = 625,

        /// <summary>
        /// jpe rel32 |  | 
        /// </summary>
        [Symbol("jpe rel32","jpe rel32 |  | ")]
        jpe_rel32 = 626,

        /// <summary>
        /// jpe rel8 |  | 
        /// </summary>
        [Symbol("jpe rel8","jpe rel8 |  | ")]
        jpe_rel8 = 627,

        /// <summary>
        /// jpo rel16 |  | 
        /// </summary>
        [Symbol("jpo rel16","jpo rel16 |  | ")]
        jpo_rel16 = 628,

        /// <summary>
        /// jpo rel32 |  | 
        /// </summary>
        [Symbol("jpo rel32","jpo rel32 |  | ")]
        jpo_rel32 = 629,

        /// <summary>
        /// jpo rel8 |  | 
        /// </summary>
        [Symbol("jpo rel8","jpo rel8 |  | ")]
        jpo_rel8 = 630,

        /// <summary>
        /// jrcxz rel8 |  | 
        /// </summary>
        [Symbol("jrcxz rel8","jrcxz rel8 |  | ")]
        jrcxz_rel8 = 631,

        /// <summary>
        /// js rel16 |  | 
        /// </summary>
        [Symbol("js rel16","js rel16 |  | ")]
        js_rel16 = 632,

        /// <summary>
        /// js rel32 |  | 
        /// </summary>
        [Symbol("js rel32","js rel32 |  | ")]
        js_rel32 = 633,

        /// <summary>
        /// js rel8 |  | 
        /// </summary>
        [Symbol("js rel8","js rel8 |  | ")]
        js_rel8 = 634,

        /// <summary>
        /// jz rel16 |  | 
        /// </summary>
        [Symbol("jz rel16","jz rel16 |  | ")]
        jz_rel16 = 635,

        /// <summary>
        /// jz rel32 |  | 
        /// </summary>
        [Symbol("jz rel32","jz rel32 |  | ")]
        jz_rel32 = 636,

        /// <summary>
        /// jz rel8 |  | 
        /// </summary>
        [Symbol("jz rel8","jz rel8 |  | ")]
        jz_rel8 = 637,

        /// <summary>
        /// kaddb k, k, k |  | 
        /// </summary>
        [Symbol("kaddb k, k, k","kaddb k, k, k |  | ")]
        kaddb_k_k_k = 638,

        /// <summary>
        /// kaddd k, k, k |  | 
        /// </summary>
        [Symbol("kaddd k, k, k","kaddd k, k, k |  | ")]
        kaddd_k_k_k = 639,

        /// <summary>
        /// kaddq k, k, k |  | 
        /// </summary>
        [Symbol("kaddq k, k, k","kaddq k, k, k |  | ")]
        kaddq_k_k_k = 640,

        /// <summary>
        /// kaddw k, k, k |  | 
        /// </summary>
        [Symbol("kaddw k, k, k","kaddw k, k, k |  | ")]
        kaddw_k_k_k = 641,

        /// <summary>
        /// kandb k, k, k |  | 
        /// </summary>
        [Symbol("kandb k, k, k","kandb k, k, k |  | ")]
        kandb_k_k_k = 642,

        /// <summary>
        /// kandd k, k, k |  | 
        /// </summary>
        [Symbol("kandd k, k, k","kandd k, k, k |  | ")]
        kandd_k_k_k = 643,

        /// <summary>
        /// kandnb k, k, k |  | 
        /// </summary>
        [Symbol("kandnb k, k, k","kandnb k, k, k |  | ")]
        kandnb_k_k_k = 644,

        /// <summary>
        /// kandnd k, k, k |  | 
        /// </summary>
        [Symbol("kandnd k, k, k","kandnd k, k, k |  | ")]
        kandnd_k_k_k = 645,

        /// <summary>
        /// kandnq k, k, k |  | 
        /// </summary>
        [Symbol("kandnq k, k, k","kandnq k, k, k |  | ")]
        kandnq_k_k_k = 646,

        /// <summary>
        /// kandnw k, k, k |  | 
        /// </summary>
        [Symbol("kandnw k, k, k","kandnw k, k, k |  | ")]
        kandnw_k_k_k = 647,

        /// <summary>
        /// kandq k, k, k |  | 
        /// </summary>
        [Symbol("kandq k, k, k","kandq k, k, k |  | ")]
        kandq_k_k_k = 648,

        /// <summary>
        /// kandw k, k, k |  | 
        /// </summary>
        [Symbol("kandw k, k, k","kandw k, k, k |  | ")]
        kandw_k_k_k = 649,

        /// <summary>
        /// kmovb k, m8 |  | 
        /// </summary>
        [Symbol("kmovb k, m8","kmovb k, m8 |  | ")]
        kmovb_k_m8 = 650,

        /// <summary>
        /// kmovb k, r32 |  | 
        /// </summary>
        [Symbol("kmovb k, r32","kmovb k, r32 |  | ")]
        kmovb_k_r32 = 651,

        /// <summary>
        /// kmovb m8, k |  | 
        /// </summary>
        [Symbol("kmovb m8, k","kmovb m8, k |  | ")]
        kmovb_m8_k = 652,

        /// <summary>
        /// kmovb r32, k |  | 
        /// </summary>
        [Symbol("kmovb r32, k","kmovb r32, k |  | ")]
        kmovb_r32_k = 653,

        /// <summary>
        /// kmovd k, m32 |  | 
        /// </summary>
        [Symbol("kmovd k, m32","kmovd k, m32 |  | ")]
        kmovd_k_m32 = 654,

        /// <summary>
        /// kmovd k, r32 |  | 
        /// </summary>
        [Symbol("kmovd k, r32","kmovd k, r32 |  | ")]
        kmovd_k_r32 = 655,

        /// <summary>
        /// kmovd m32, k |  | 
        /// </summary>
        [Symbol("kmovd m32, k","kmovd m32, k |  | ")]
        kmovd_m32_k = 656,

        /// <summary>
        /// kmovd r32, k |  | 
        /// </summary>
        [Symbol("kmovd r32, k","kmovd r32, k |  | ")]
        kmovd_r32_k = 657,

        /// <summary>
        /// kmovq k, m64 |  | 
        /// </summary>
        [Symbol("kmovq k, m64","kmovq k, m64 |  | ")]
        kmovq_k_m64 = 658,

        /// <summary>
        /// kmovq k, r32 |  | 
        /// </summary>
        [Symbol("kmovq k, r32","kmovq k, r32 |  | ")]
        kmovq_k_r32 = 659,

        /// <summary>
        /// kmovq k, r64 |  | 
        /// </summary>
        [Symbol("kmovq k, r64","kmovq k, r64 |  | ")]
        kmovq_k_r64 = 660,

        /// <summary>
        /// kmovq m64, k |  | 
        /// </summary>
        [Symbol("kmovq m64, k","kmovq m64, k |  | ")]
        kmovq_m64_k = 661,

        /// <summary>
        /// kmovq r64, k |  | 
        /// </summary>
        [Symbol("kmovq r64, k","kmovq r64, k |  | ")]
        kmovq_r64_k = 662,

        /// <summary>
        /// kmovw k, m16 |  | 
        /// </summary>
        [Symbol("kmovw k, m16","kmovw k, m16 |  | ")]
        kmovw_k_m16 = 663,

        /// <summary>
        /// kmovw k, r32 |  | 
        /// </summary>
        [Symbol("kmovw k, r32","kmovw k, r32 |  | ")]
        kmovw_k_r32 = 664,

        /// <summary>
        /// kmovw m16, k |  | 
        /// </summary>
        [Symbol("kmovw m16, k","kmovw m16, k |  | ")]
        kmovw_m16_k = 665,

        /// <summary>
        /// kmovw r32, k |  | 
        /// </summary>
        [Symbol("kmovw r32, k","kmovw r32, k |  | ")]
        kmovw_r32_k = 666,

        /// <summary>
        /// knotb k, k |  | 
        /// </summary>
        [Symbol("knotb k, k","knotb k, k |  | ")]
        knotb_k_k = 667,

        /// <summary>
        /// knotd k, k |  | 
        /// </summary>
        [Symbol("knotd k, k","knotd k, k |  | ")]
        knotd_k_k = 668,

        /// <summary>
        /// knotq k, k |  | 
        /// </summary>
        [Symbol("knotq k, k","knotq k, k |  | ")]
        knotq_k_k = 669,

        /// <summary>
        /// knotw k, k |  | 
        /// </summary>
        [Symbol("knotw k, k","knotw k, k |  | ")]
        knotw_k_k = 670,

        /// <summary>
        /// korb k, k, k |  | 
        /// </summary>
        [Symbol("korb k, k, k","korb k, k, k |  | ")]
        korb_k_k_k = 671,

        /// <summary>
        /// kord k, k, k |  | 
        /// </summary>
        [Symbol("kord k, k, k","kord k, k, k |  | ")]
        kord_k_k_k = 672,

        /// <summary>
        /// korq k, k, k |  | 
        /// </summary>
        [Symbol("korq k, k, k","korq k, k, k |  | ")]
        korq_k_k_k = 673,

        /// <summary>
        /// kortestb k, k |  | 
        /// </summary>
        [Symbol("kortestb k, k","kortestb k, k |  | ")]
        kortestb_k_k = 674,

        /// <summary>
        /// kortestd k, k |  | 
        /// </summary>
        [Symbol("kortestd k, k","kortestd k, k |  | ")]
        kortestd_k_k = 675,

        /// <summary>
        /// kortestq k, k |  | 
        /// </summary>
        [Symbol("kortestq k, k","kortestq k, k |  | ")]
        kortestq_k_k = 676,

        /// <summary>
        /// kortestw k, k |  | 
        /// </summary>
        [Symbol("kortestw k, k","kortestw k, k |  | ")]
        kortestw_k_k = 677,

        /// <summary>
        /// korw k, k, k |  | 
        /// </summary>
        [Symbol("korw k, k, k","korw k, k, k |  | ")]
        korw_k_k_k = 678,

        /// <summary>
        /// kshiftlb k, k, imm8 |  | 
        /// </summary>
        [Symbol("kshiftlb k, k, imm8","kshiftlb k, k, imm8 |  | ")]
        kshiftlb_k_k_imm8 = 679,

        /// <summary>
        /// kshiftld k, k, imm8 |  | 
        /// </summary>
        [Symbol("kshiftld k, k, imm8","kshiftld k, k, imm8 |  | ")]
        kshiftld_k_k_imm8 = 680,

        /// <summary>
        /// kshiftlq k, k, imm8 |  | 
        /// </summary>
        [Symbol("kshiftlq k, k, imm8","kshiftlq k, k, imm8 |  | ")]
        kshiftlq_k_k_imm8 = 681,

        /// <summary>
        /// kshiftlw k, k, imm8 |  | 
        /// </summary>
        [Symbol("kshiftlw k, k, imm8","kshiftlw k, k, imm8 |  | ")]
        kshiftlw_k_k_imm8 = 682,

        /// <summary>
        /// kshiftrb k, k, imm8 |  | 
        /// </summary>
        [Symbol("kshiftrb k, k, imm8","kshiftrb k, k, imm8 |  | ")]
        kshiftrb_k_k_imm8 = 683,

        /// <summary>
        /// kshiftrd k, k, imm8 |  | 
        /// </summary>
        [Symbol("kshiftrd k, k, imm8","kshiftrd k, k, imm8 |  | ")]
        kshiftrd_k_k_imm8 = 684,

        /// <summary>
        /// kshiftrq k, k, imm8 |  | 
        /// </summary>
        [Symbol("kshiftrq k, k, imm8","kshiftrq k, k, imm8 |  | ")]
        kshiftrq_k_k_imm8 = 685,

        /// <summary>
        /// kshiftrw k, k, imm8 |  | 
        /// </summary>
        [Symbol("kshiftrw k, k, imm8","kshiftrw k, k, imm8 |  | ")]
        kshiftrw_k_k_imm8 = 686,

        /// <summary>
        /// ktestb k, k |  | 
        /// </summary>
        [Symbol("ktestb k, k","ktestb k, k |  | ")]
        ktestb_k_k = 687,

        /// <summary>
        /// ktestd k, k |  | 
        /// </summary>
        [Symbol("ktestd k, k","ktestd k, k |  | ")]
        ktestd_k_k = 688,

        /// <summary>
        /// ktestq k, k |  | 
        /// </summary>
        [Symbol("ktestq k, k","ktestq k, k |  | ")]
        ktestq_k_k = 689,

        /// <summary>
        /// ktestw k, k |  | 
        /// </summary>
        [Symbol("ktestw k, k","ktestw k, k |  | ")]
        ktestw_k_k = 690,

        /// <summary>
        /// kunpckbw k, k, k |  | 
        /// </summary>
        [Symbol("kunpckbw k, k, k","kunpckbw k, k, k |  | ")]
        kunpckbw_k_k_k = 691,

        /// <summary>
        /// kunpckdq k, k, k |  | 
        /// </summary>
        [Symbol("kunpckdq k, k, k","kunpckdq k, k, k |  | ")]
        kunpckdq_k_k_k = 692,

        /// <summary>
        /// kunpckwd k, k, k |  | 
        /// </summary>
        [Symbol("kunpckwd k, k, k","kunpckwd k, k, k |  | ")]
        kunpckwd_k_k_k = 693,

        /// <summary>
        /// kxnorb k, k, k |  | 
        /// </summary>
        [Symbol("kxnorb k, k, k","kxnorb k, k, k |  | ")]
        kxnorb_k_k_k = 694,

        /// <summary>
        /// kxnord k, k, k |  | 
        /// </summary>
        [Symbol("kxnord k, k, k","kxnord k, k, k |  | ")]
        kxnord_k_k_k = 695,

        /// <summary>
        /// kxnorq k, k, k |  | 
        /// </summary>
        [Symbol("kxnorq k, k, k","kxnorq k, k, k |  | ")]
        kxnorq_k_k_k = 696,

        /// <summary>
        /// kxnorw k, k, k |  | 
        /// </summary>
        [Symbol("kxnorw k, k, k","kxnorw k, k, k |  | ")]
        kxnorw_k_k_k = 697,

        /// <summary>
        /// kxorb k, k, k |  | 
        /// </summary>
        [Symbol("kxorb k, k, k","kxorb k, k, k |  | ")]
        kxorb_k_k_k = 698,

        /// <summary>
        /// kxord k, k, k |  | 
        /// </summary>
        [Symbol("kxord k, k, k","kxord k, k, k |  | ")]
        kxord_k_k_k = 699,

        /// <summary>
        /// kxorq k, k, k |  | 
        /// </summary>
        [Symbol("kxorq k, k, k","kxorq k, k, k |  | ")]
        kxorq_k_k_k = 700,

        /// <summary>
        /// kxorw k, k, k |  | 
        /// </summary>
        [Symbol("kxorw k, k, k","kxorw k, k, k |  | ")]
        kxorw_k_k_k = 701,

        /// <summary>
        /// lddqu xmm, mem |  | 
        /// </summary>
        [Symbol("lddqu xmm, mem","lddqu xmm, mem |  | ")]
        lddqu_xmm_mem = 702,

        /// <summary>
        /// lds r16, m16:16 |  | 
        /// </summary>
        [Symbol("lds r16, m16:16","lds r16, m16:16 |  | ")]
        lds_r16_mp16x16 = 703,

        /// <summary>
        /// lds r32, m16:32 |  | 
        /// </summary>
        [Symbol("lds r32, m16:32","lds r32, m16:32 |  | ")]
        lds_r32_mp16x32 = 704,

        /// <summary>
        /// lea r16, m |  | 
        /// </summary>
        [Symbol("lea r16, m","lea r16, m |  | ")]
        lea_r16_m = 705,

        /// <summary>
        /// lea r32, m |  | 
        /// </summary>
        [Symbol("lea r32, m","lea r32, m |  | ")]
        lea_r32_m = 706,

        /// <summary>
        /// lea r64, m |  | 
        /// </summary>
        [Symbol("lea r64, m","lea r64, m |  | ")]
        lea_r64_m = 707,

        /// <summary>
        /// leave |  | 
        /// </summary>
        [Symbol("leave","leave |  | ")]
        leave = 708,

        /// <summary>
        /// les r16, m16:16 |  | 
        /// </summary>
        [Symbol("les r16, m16:16","les r16, m16:16 |  | ")]
        les_r16_mp16x16 = 709,

        /// <summary>
        /// les r32, m16:32 |  | 
        /// </summary>
        [Symbol("les r32, m16:32","les r32, m16:32 |  | ")]
        les_r32_mp16x32 = 710,

        /// <summary>
        /// lfs r16, m16:16 |  | 
        /// </summary>
        [Symbol("lfs r16, m16:16","lfs r16, m16:16 |  | ")]
        lfs_r16_mp16x16 = 711,

        /// <summary>
        /// lfs r32, m16:32 |  | 
        /// </summary>
        [Symbol("lfs r32, m16:32","lfs r32, m16:32 |  | ")]
        lfs_r32_mp16x32 = 712,

        /// <summary>
        /// lfs r64, m16:64 |  | 
        /// </summary>
        [Symbol("lfs r64, m16:64","lfs r64, m16:64 |  | ")]
        lfs_r64_mp16x64 = 713,

        /// <summary>
        /// lgdt m16&32 |  | 
        /// </summary>
        [Symbol("lgdt m16&32","lgdt m16&32 |  | ")]
        lgdt_m16x32 = 714,

        /// <summary>
        /// lgdt m16&64 |  | 
        /// </summary>
        [Symbol("lgdt m16&64","lgdt m16&64 |  | ")]
        lgdt_m16x64 = 715,

        /// <summary>
        /// lgs r16, m16:16 |  | 
        /// </summary>
        [Symbol("lgs r16, m16:16","lgs r16, m16:16 |  | ")]
        lgs_r16_mp16x16 = 716,

        /// <summary>
        /// lgs r32, m16:32 |  | 
        /// </summary>
        [Symbol("lgs r32, m16:32","lgs r32, m16:32 |  | ")]
        lgs_r32_mp16x32 = 717,

        /// <summary>
        /// lgs r64, m16:64 |  | 
        /// </summary>
        [Symbol("lgs r64, m16:64","lgs r64, m16:64 |  | ")]
        lgs_r64_mp16x64 = 718,

        /// <summary>
        /// lidt m16&32 |  | 
        /// </summary>
        [Symbol("lidt m16&32","lidt m16&32 |  | ")]
        lidt_m16x32 = 719,

        /// <summary>
        /// lidt m16&64 |  | 
        /// </summary>
        [Symbol("lidt m16&64","lidt m16&64 |  | ")]
        lidt_m16x64 = 720,

        /// <summary>
        /// lldt m16 |  | 
        /// </summary>
        [Symbol("lldt m16","lldt m16 |  | ")]
        lldt_m16 = 721,

        /// <summary>
        /// lldt r16 |  | 
        /// </summary>
        [Symbol("lldt r16","lldt r16 |  | ")]
        lldt_r16 = 722,

        /// <summary>
        /// lmsw m16 |  | 
        /// </summary>
        [Symbol("lmsw m16","lmsw m16 |  | ")]
        lmsw_m16 = 723,

        /// <summary>
        /// lmsw r16 |  | 
        /// </summary>
        [Symbol("lmsw r16","lmsw r16 |  | ")]
        lmsw_r16 = 724,

        /// <summary>
        /// lock |  | 
        /// </summary>
        [Symbol("lock","lock |  | ")]
        @lock = 725,

        /// <summary>
        /// lods m16 |  | 
        /// </summary>
        [Symbol("lods m16","lods m16 |  | ")]
        lods_m16 = 726,

        /// <summary>
        /// lods m32 |  | 
        /// </summary>
        [Symbol("lods m32","lods m32 |  | ")]
        lods_m32 = 727,

        /// <summary>
        /// lods m64 |  | 
        /// </summary>
        [Symbol("lods m64","lods m64 |  | ")]
        lods_m64 = 728,

        /// <summary>
        /// lods m8 |  | 
        /// </summary>
        [Symbol("lods m8","lods m8 |  | ")]
        lods_m8 = 729,

        /// <summary>
        /// lodsb |  | 
        /// </summary>
        [Symbol("lodsb","lodsb |  | ")]
        lodsb = 730,

        /// <summary>
        /// lodsd |  | 
        /// </summary>
        [Symbol("lodsd","lodsd |  | ")]
        lodsd = 731,

        /// <summary>
        /// lodsq |  | 
        /// </summary>
        [Symbol("lodsq","lodsq |  | ")]
        lodsq = 732,

        /// <summary>
        /// lodsw |  | 
        /// </summary>
        [Symbol("lodsw","lodsw |  | ")]
        lodsw = 733,

        /// <summary>
        /// loop rel8 |  | 
        /// </summary>
        [Symbol("loop rel8","loop rel8 |  | ")]
        loop_rel8 = 734,

        /// <summary>
        /// loope rel8 |  | 
        /// </summary>
        [Symbol("loope rel8","loope rel8 |  | ")]
        loope_rel8 = 735,

        /// <summary>
        /// loopne rel8 |  | 
        /// </summary>
        [Symbol("loopne rel8","loopne rel8 |  | ")]
        loopne_rel8 = 736,

        /// <summary>
        /// lsl r16, m16 |  | 
        /// </summary>
        [Symbol("lsl r16, m16","lsl r16, m16 |  | ")]
        lsl_r16_m16 = 737,

        /// <summary>
        /// lsl r16, r16 |  | 
        /// </summary>
        [Symbol("lsl r16, r16","lsl r16, r16 |  | ")]
        lsl_r16_r16 = 738,

        /// <summary>
        /// lsl r32, m16 |  | 
        /// </summary>
        [Symbol("lsl r32, m16","lsl r32, m16 |  | ")]
        lsl_r32_m16 = 739,

        /// <summary>
        /// lsl r32, r32 |  | 
        /// </summary>
        [Symbol("lsl r32, r32","lsl r32, r32 |  | ")]
        lsl_r32_r32 = 740,

        /// <summary>
        /// lsl r64, m16 |  | 
        /// </summary>
        [Symbol("lsl r64, m16","lsl r64, m16 |  | ")]
        lsl_r64_m16 = 741,

        /// <summary>
        /// lsl r64, r32 |  | 
        /// </summary>
        [Symbol("lsl r64, r32","lsl r64, r32 |  | ")]
        lsl_r64_r32 = 742,

        /// <summary>
        /// lss r16, m16:16 |  | 
        /// </summary>
        [Symbol("lss r16, m16:16","lss r16, m16:16 |  | ")]
        lss_r16_mp16x16 = 743,

        /// <summary>
        /// lss r32, m16:32 |  | 
        /// </summary>
        [Symbol("lss r32, m16:32","lss r32, m16:32 |  | ")]
        lss_r32_mp16x32 = 744,

        /// <summary>
        /// lss r64, m16:64 |  | 
        /// </summary>
        [Symbol("lss r64, m16:64","lss r64, m16:64 |  | ")]
        lss_r64_mp16x64 = 745,

        /// <summary>
        /// maskmovdqu xmm, xmm |  | 
        /// </summary>
        [Symbol("maskmovdqu xmm, xmm","maskmovdqu xmm, xmm |  | ")]
        maskmovdqu_xmm_xmm = 746,

        /// <summary>
        /// maskmovq mm, mm |  | 
        /// </summary>
        [Symbol("maskmovq mm, mm","maskmovq mm, mm |  | ")]
        maskmovq_mm_mm = 747,

        /// <summary>
        /// mov AL, moffs8 |  | 
        /// </summary>
        [Symbol("mov AL, moffs8","mov AL, moffs8 |  | ")]
        mov_AL_moffs8 = 748,

        /// <summary>
        /// mov AX, moffs16 |  | 
        /// </summary>
        [Symbol("mov AX, moffs16","mov AX, moffs16 |  | ")]
        mov_AX_moffs16 = 749,

        /// <summary>
        /// mov CR, r32 |  | 
        /// </summary>
        [Symbol("mov CR, r32","mov CR, r32 |  | ")]
        mov_CR_r32 = 750,

        /// <summary>
        /// mov CR, r64 |  | 
        /// </summary>
        [Symbol("mov CR, r64","mov CR, r64 |  | ")]
        mov_CR_r64 = 751,

        /// <summary>
        /// mov CR8, r64 |  | 
        /// </summary>
        [Symbol("mov CR8, r64","mov CR8, r64 |  | ")]
        mov_CR8_r64 = 752,

        /// <summary>
        /// mov DR, r32 |  | 
        /// </summary>
        [Symbol("mov DR, r32","mov DR, r32 |  | ")]
        mov_DR_r32 = 753,

        /// <summary>
        /// mov DR, r64 |  | 
        /// </summary>
        [Symbol("mov DR, r64","mov DR, r64 |  | ")]
        mov_DR_r64 = 754,

        /// <summary>
        /// mov EAX, moffs32 |  | 
        /// </summary>
        [Symbol("mov EAX, moffs32","mov EAX, moffs32 |  | ")]
        mov_EAX_moffs32 = 755,

        /// <summary>
        /// mov m16, imm16 |  | 
        /// </summary>
        [Symbol("mov m16, imm16","mov m16, imm16 |  | ")]
        mov_m16_imm16 = 756,

        /// <summary>
        /// mov m16, r16 |  | 
        /// </summary>
        [Symbol("mov m16, r16","mov m16, r16 |  | ")]
        mov_m16_r16 = 757,

        /// <summary>
        /// mov m16, Sreg |  | 
        /// </summary>
        [Symbol("mov m16, Sreg","mov m16, Sreg |  | ")]
        mov_m16_Sreg = 758,

        /// <summary>
        /// mov m32, imm32 |  | 
        /// </summary>
        [Symbol("mov m32, imm32","mov m32, imm32 |  | ")]
        mov_m32_imm32 = 759,

        /// <summary>
        /// mov m32, r32 |  | 
        /// </summary>
        [Symbol("mov m32, r32","mov m32, r32 |  | ")]
        mov_m32_r32 = 760,

        /// <summary>
        /// mov m32, Sreg |  | 
        /// </summary>
        [Symbol("mov m32, Sreg","mov m32, Sreg |  | ")]
        mov_m32_Sreg = 761,

        /// <summary>
        /// mov m64, imm32 |  | 
        /// </summary>
        [Symbol("mov m64, imm32","mov m64, imm32 |  | ")]
        mov_m64_imm32 = 762,

        /// <summary>
        /// mov m64, r64 |  | 
        /// </summary>
        [Symbol("mov m64, r64","mov m64, r64 |  | ")]
        mov_m64_r64 = 763,

        /// <summary>
        /// mov m8, imm8 |  | 
        /// </summary>
        [Symbol("mov m8, imm8","mov m8, imm8 |  | ")]
        mov_m8_imm8 = 764,

        /// <summary>
        /// mov m8, r8 |  | 
        /// </summary>
        [Symbol("mov m8, r8","mov m8, r8 |  | ")]
        mov_m8_r8 = 765,

        /// <summary>
        /// mov moffs16, AX |  | 
        /// </summary>
        [Symbol("mov moffs16, AX","mov moffs16, AX |  | ")]
        mov_moffs16_AX = 766,

        /// <summary>
        /// mov moffs32, EAX |  | 
        /// </summary>
        [Symbol("mov moffs32, EAX","mov moffs32, EAX |  | ")]
        mov_moffs32_EAX = 767,

        /// <summary>
        /// mov moffs64, RAX |  | 
        /// </summary>
        [Symbol("mov moffs64, RAX","mov moffs64, RAX |  | ")]
        mov_moffs64_RAX = 768,

        /// <summary>
        /// mov moffs8, AL |  | 
        /// </summary>
        [Symbol("mov moffs8, AL","mov moffs8, AL |  | ")]
        mov_moffs8_AL = 769,

        /// <summary>
        /// mov r16, imm16 |  | 
        /// </summary>
        [Symbol("mov r16, imm16","mov r16, imm16 |  | ")]
        mov_r16_imm16 = 770,

        /// <summary>
        /// mov r16, m16 |  | 
        /// </summary>
        [Symbol("mov r16, m16","mov r16, m16 |  | ")]
        mov_r16_m16 = 771,

        /// <summary>
        /// mov r16, r16 |  | 
        /// </summary>
        [Symbol("mov r16, r16","mov r16, r16 |  | ")]
        mov_r16_r16 = 772,

        /// <summary>
        /// mov r16, Sreg |  | 
        /// </summary>
        [Symbol("mov r16, Sreg","mov r16, Sreg |  | ")]
        mov_r16_Sreg = 773,

        /// <summary>
        /// mov r32, CR |  | 
        /// </summary>
        [Symbol("mov r32, CR","mov r32, CR |  | ")]
        mov_r32_CR = 774,

        /// <summary>
        /// mov r32, DR |  | 
        /// </summary>
        [Symbol("mov r32, DR","mov r32, DR |  | ")]
        mov_r32_DR = 775,

        /// <summary>
        /// mov r32, imm32 |  | 
        /// </summary>
        [Symbol("mov r32, imm32","mov r32, imm32 |  | ")]
        mov_r32_imm32 = 776,

        /// <summary>
        /// mov r32, m32 |  | 
        /// </summary>
        [Symbol("mov r32, m32","mov r32, m32 |  | ")]
        mov_r32_m32 = 777,

        /// <summary>
        /// mov r32, r32 |  | 
        /// </summary>
        [Symbol("mov r32, r32","mov r32, r32 |  | ")]
        mov_r32_r32 = 778,

        /// <summary>
        /// mov r64, CR |  | 
        /// </summary>
        [Symbol("mov r64, CR","mov r64, CR |  | ")]
        mov_r64_CR = 779,

        /// <summary>
        /// mov r64, CR8 |  | 
        /// </summary>
        [Symbol("mov r64, CR8","mov r64, CR8 |  | ")]
        mov_r64_CR8 = 780,

        /// <summary>
        /// mov r64, DR |  | 
        /// </summary>
        [Symbol("mov r64, DR","mov r64, DR |  | ")]
        mov_r64_DR = 781,

        /// <summary>
        /// mov r64, imm32 |  | 
        /// </summary>
        [Symbol("mov r64, imm32","mov r64, imm32 |  | ")]
        mov_r64_imm32 = 782,

        /// <summary>
        /// mov r64, imm64 |  | 
        /// </summary>
        [Symbol("mov r64, imm64","mov r64, imm64 |  | ")]
        mov_r64_imm64 = 783,

        /// <summary>
        /// mov r64, m64 |  | 
        /// </summary>
        [Symbol("mov r64, m64","mov r64, m64 |  | ")]
        mov_r64_m64 = 784,

        /// <summary>
        /// mov r64, r64 |  | 
        /// </summary>
        [Symbol("mov r64, r64","mov r64, r64 |  | ")]
        mov_r64_r64 = 785,

        /// <summary>
        /// mov r64, Sreg |  | 
        /// </summary>
        [Symbol("mov r64, Sreg","mov r64, Sreg |  | ")]
        mov_r64_Sreg = 786,

        /// <summary>
        /// mov r8, imm8 |  | 
        /// </summary>
        [Symbol("mov r8, imm8","mov r8, imm8 |  | ")]
        mov_r8_imm8 = 787,

        /// <summary>
        /// mov r8, m8 |  | 
        /// </summary>
        [Symbol("mov r8, m8","mov r8, m8 |  | ")]
        mov_r8_m8 = 788,

        /// <summary>
        /// mov r8, r8 |  | 
        /// </summary>
        [Symbol("mov r8, r8","mov r8, r8 |  | ")]
        mov_r8_r8 = 789,

        /// <summary>
        /// mov RAX, moffs64 |  | 
        /// </summary>
        [Symbol("mov RAX, moffs64","mov RAX, moffs64 |  | ")]
        mov_RAX_moffs64 = 790,

        /// <summary>
        /// mov Sreg, m16 |  | 
        /// </summary>
        [Symbol("mov Sreg, m16","mov Sreg, m16 |  | ")]
        mov_Sreg_m16 = 791,

        /// <summary>
        /// mov Sreg, m64 |  | 
        /// </summary>
        [Symbol("mov Sreg, m64","mov Sreg, m64 |  | ")]
        mov_Sreg_m64 = 792,

        /// <summary>
        /// mov Sreg, r16 |  | 
        /// </summary>
        [Symbol("mov Sreg, r16","mov Sreg, r16 |  | ")]
        mov_Sreg_r16 = 793,

        /// <summary>
        /// mov Sreg, r64 |  | 
        /// </summary>
        [Symbol("mov Sreg, r64","mov Sreg, r64 |  | ")]
        mov_Sreg_r64 = 794,

        /// <summary>
        /// movapd m128, xmm |  | 
        /// </summary>
        [Symbol("movapd m128, xmm","movapd m128, xmm |  | ")]
        movapd_m128_xmm = 795,

        /// <summary>
        /// movapd r8, xmm |  | 
        /// </summary>
        [Symbol("movapd r8, xmm","movapd r8, xmm |  | ")]
        movapd_r8_xmm = 796,

        /// <summary>
        /// movapd xmm, m128 |  | 
        /// </summary>
        [Symbol("movapd xmm, m128","movapd xmm, m128 |  | ")]
        movapd_xmm_m128 = 797,

        /// <summary>
        /// movapd xmm, r8 |  | 
        /// </summary>
        [Symbol("movapd xmm, r8","movapd xmm, r8 |  | ")]
        movapd_xmm_r8 = 798,

        /// <summary>
        /// movaps m128, xmm |  | 
        /// </summary>
        [Symbol("movaps m128, xmm","movaps m128, xmm |  | ")]
        movaps_m128_xmm = 799,

        /// <summary>
        /// movaps r8, xmm |  | 
        /// </summary>
        [Symbol("movaps r8, xmm","movaps r8, xmm |  | ")]
        movaps_r8_xmm = 800,

        /// <summary>
        /// movaps xmm, m128 |  | 
        /// </summary>
        [Symbol("movaps xmm, m128","movaps xmm, m128 |  | ")]
        movaps_xmm_m128 = 801,

        /// <summary>
        /// movaps xmm, r8 |  | 
        /// </summary>
        [Symbol("movaps xmm, r8","movaps xmm, r8 |  | ")]
        movaps_xmm_r8 = 802,

        /// <summary>
        /// movd m32, mm |  | 
        /// </summary>
        [Symbol("movd m32, mm","movd m32, mm |  | ")]
        movd_m32_mm = 803,

        /// <summary>
        /// movd m32, xmm |  | 
        /// </summary>
        [Symbol("movd m32, xmm","movd m32, xmm |  | ")]
        movd_m32_xmm = 804,

        /// <summary>
        /// movd mm, m32 |  | 
        /// </summary>
        [Symbol("movd mm, m32","movd mm, m32 |  | ")]
        movd_mm_m32 = 805,

        /// <summary>
        /// movd mm, r32 |  | 
        /// </summary>
        [Symbol("movd mm, r32","movd mm, r32 |  | ")]
        movd_mm_r32 = 806,

        /// <summary>
        /// movd r32, mm |  | 
        /// </summary>
        [Symbol("movd r32, mm","movd r32, mm |  | ")]
        movd_r32_mm = 807,

        /// <summary>
        /// movd r32, xmm |  | 
        /// </summary>
        [Symbol("movd r32, xmm","movd r32, xmm |  | ")]
        movd_r32_xmm = 808,

        /// <summary>
        /// movd xmm, m32 |  | 
        /// </summary>
        [Symbol("movd xmm, m32","movd xmm, m32 |  | ")]
        movd_xmm_m32 = 809,

        /// <summary>
        /// movd xmm, r32 |  | 
        /// </summary>
        [Symbol("movd xmm, r32","movd xmm, r32 |  | ")]
        movd_xmm_r32 = 810,

        /// <summary>
        /// movdir64b m32, m512 |  | 
        /// </summary>
        [Symbol("movdir64b m32, m512","movdir64b m32, m512 |  | ")]
        movdir64b_m32_m512 = 811,

        /// <summary>
        /// movdir64b m64, m512 |  | 
        /// </summary>
        [Symbol("movdir64b m64, m512","movdir64b m64, m512 |  | ")]
        movdir64b_m64_m512 = 812,

        /// <summary>
        /// movdir64b r16, m512 |  | 
        /// </summary>
        [Symbol("movdir64b r16, m512","movdir64b r16, m512 |  | ")]
        movdir64b_r16_m512 = 813,

        /// <summary>
        /// movdqa m128, xmm |  | 
        /// </summary>
        [Symbol("movdqa m128, xmm","movdqa m128, xmm |  | ")]
        movdqa_m128_xmm = 814,

        /// <summary>
        /// movdqa r8, xmm |  | 
        /// </summary>
        [Symbol("movdqa r8, xmm","movdqa r8, xmm |  | ")]
        movdqa_r8_xmm = 815,

        /// <summary>
        /// movdqa xmm, m128 |  | 
        /// </summary>
        [Symbol("movdqa xmm, m128","movdqa xmm, m128 |  | ")]
        movdqa_xmm_m128 = 816,

        /// <summary>
        /// movdqa xmm, r8 |  | 
        /// </summary>
        [Symbol("movdqa xmm, r8","movdqa xmm, r8 |  | ")]
        movdqa_xmm_r8 = 817,

        /// <summary>
        /// movdqu m128, xmm |  | 
        /// </summary>
        [Symbol("movdqu m128, xmm","movdqu m128, xmm |  | ")]
        movdqu_m128_xmm = 818,

        /// <summary>
        /// movdqu r8, xmm |  | 
        /// </summary>
        [Symbol("movdqu r8, xmm","movdqu r8, xmm |  | ")]
        movdqu_r8_xmm = 819,

        /// <summary>
        /// movdqu xmm, m128 |  | 
        /// </summary>
        [Symbol("movdqu xmm, m128","movdqu xmm, m128 |  | ")]
        movdqu_xmm_m128 = 820,

        /// <summary>
        /// movdqu xmm, r8 |  | 
        /// </summary>
        [Symbol("movdqu xmm, r8","movdqu xmm, r8 |  | ")]
        movdqu_xmm_r8 = 821,

        /// <summary>
        /// movq m64, mm |  | 
        /// </summary>
        [Symbol("movq m64, mm","movq m64, mm |  | ")]
        movq_m64_mm = 822,

        /// <summary>
        /// movq m64, xmm |  | 
        /// </summary>
        [Symbol("movq m64, xmm","movq m64, xmm |  | ")]
        movq_m64_xmm = 823,

        /// <summary>
        /// movq mm, m64 |  | 
        /// </summary>
        [Symbol("movq mm, m64","movq mm, m64 |  | ")]
        movq_mm_m64 = 824,

        /// <summary>
        /// movq mm, r64 |  | 
        /// </summary>
        [Symbol("movq mm, r64","movq mm, r64 |  | ")]
        movq_mm_r64 = 825,

        /// <summary>
        /// movq mm, r8 |  | 
        /// </summary>
        [Symbol("movq mm, r8","movq mm, r8 |  | ")]
        movq_mm_r8 = 826,

        /// <summary>
        /// movq r64, mm |  | 
        /// </summary>
        [Symbol("movq r64, mm","movq r64, mm |  | ")]
        movq_r64_mm = 827,

        /// <summary>
        /// movq r64, xmm |  | 
        /// </summary>
        [Symbol("movq r64, xmm","movq r64, xmm |  | ")]
        movq_r64_xmm = 828,

        /// <summary>
        /// movq r8, mm |  | 
        /// </summary>
        [Symbol("movq r8, mm","movq r8, mm |  | ")]
        movq_r8_mm = 829,

        /// <summary>
        /// movq r8, xmm |  | 
        /// </summary>
        [Symbol("movq r8, xmm","movq r8, xmm |  | ")]
        movq_r8_xmm = 830,

        /// <summary>
        /// movq xmm, m64 |  | 
        /// </summary>
        [Symbol("movq xmm, m64","movq xmm, m64 |  | ")]
        movq_xmm_m64 = 831,

        /// <summary>
        /// movq xmm, r64 |  | 
        /// </summary>
        [Symbol("movq xmm, r64","movq xmm, r64 |  | ")]
        movq_xmm_r64 = 832,

        /// <summary>
        /// movq xmm, r8 |  | 
        /// </summary>
        [Symbol("movq xmm, r8","movq xmm, r8 |  | ")]
        movq_xmm_r8 = 833,

        /// <summary>
        /// movs m16, m16 |  | 
        /// </summary>
        [Symbol("movs m16, m16","movs m16, m16 |  | ")]
        movs_m16_m16 = 834,

        /// <summary>
        /// movs m32, m32 |  | 
        /// </summary>
        [Symbol("movs m32, m32","movs m32, m32 |  | ")]
        movs_m32_m32 = 835,

        /// <summary>
        /// movs m64, m64 |  | 
        /// </summary>
        [Symbol("movs m64, m64","movs m64, m64 |  | ")]
        movs_m64_m64 = 836,

        /// <summary>
        /// movs m8, m8 |  | 
        /// </summary>
        [Symbol("movs m8, m8","movs m8, m8 |  | ")]
        movs_m8_m8 = 837,

        /// <summary>
        /// movsb |  | 
        /// </summary>
        [Symbol("movsb","movsb |  | ")]
        movsb = 838,

        /// <summary>
        /// movsd |  | 
        /// </summary>
        [Symbol("movsd","movsd |  | ")]
        movsd = 839,

        /// <summary>
        /// movsq |  | 
        /// </summary>
        [Symbol("movsq","movsq |  | ")]
        movsq = 840,

        /// <summary>
        /// movsw |  | 
        /// </summary>
        [Symbol("movsw","movsw |  | ")]
        movsw = 841,

        /// <summary>
        /// movsx r16, m8 |  | 
        /// </summary>
        [Symbol("movsx r16, m8","movsx r16, m8 |  | ")]
        movsx_r16_m8 = 842,

        /// <summary>
        /// movsx r16, r8 |  | 
        /// </summary>
        [Symbol("movsx r16, r8","movsx r16, r8 |  | ")]
        movsx_r16_r8 = 843,

        /// <summary>
        /// movsx r32, m16 |  | 
        /// </summary>
        [Symbol("movsx r32, m16","movsx r32, m16 |  | ")]
        movsx_r32_m16 = 844,

        /// <summary>
        /// movsx r32, m8 |  | 
        /// </summary>
        [Symbol("movsx r32, m8","movsx r32, m8 |  | ")]
        movsx_r32_m8 = 845,

        /// <summary>
        /// movsx r32, r16 |  | 
        /// </summary>
        [Symbol("movsx r32, r16","movsx r32, r16 |  | ")]
        movsx_r32_r16 = 846,

        /// <summary>
        /// movsx r32, r8 |  | 
        /// </summary>
        [Symbol("movsx r32, r8","movsx r32, r8 |  | ")]
        movsx_r32_r8 = 847,

        /// <summary>
        /// movsx r64, m16 |  | 
        /// </summary>
        [Symbol("movsx r64, m16","movsx r64, m16 |  | ")]
        movsx_r64_m16 = 848,

        /// <summary>
        /// movsx r64, m8 |  | 
        /// </summary>
        [Symbol("movsx r64, m8","movsx r64, m8 |  | ")]
        movsx_r64_m8 = 849,

        /// <summary>
        /// movsx r64, r16 |  | 
        /// </summary>
        [Symbol("movsx r64, r16","movsx r64, r16 |  | ")]
        movsx_r64_r16 = 850,

        /// <summary>
        /// movsx r64, r8 |  | 
        /// </summary>
        [Symbol("movsx r64, r8","movsx r64, r8 |  | ")]
        movsx_r64_r8 = 851,

        /// <summary>
        /// movsxd r16, m16 |  | 
        /// </summary>
        [Symbol("movsxd r16, m16","movsxd r16, m16 |  | ")]
        movsxd_r16_m16 = 852,

        /// <summary>
        /// movsxd r16, r16 |  | 
        /// </summary>
        [Symbol("movsxd r16, r16","movsxd r16, r16 |  | ")]
        movsxd_r16_r16 = 853,

        /// <summary>
        /// movsxd r32, m32 |  | 
        /// </summary>
        [Symbol("movsxd r32, m32","movsxd r32, m32 |  | ")]
        movsxd_r32_m32 = 854,

        /// <summary>
        /// movsxd r32, r32 |  | 
        /// </summary>
        [Symbol("movsxd r32, r32","movsxd r32, r32 |  | ")]
        movsxd_r32_r32 = 855,

        /// <summary>
        /// movsxd r64, m32 |  | 
        /// </summary>
        [Symbol("movsxd r64, m32","movsxd r64, m32 |  | ")]
        movsxd_r64_m32 = 856,

        /// <summary>
        /// movsxd r64, r32 |  | 
        /// </summary>
        [Symbol("movsxd r64, r32","movsxd r64, r32 |  | ")]
        movsxd_r64_r32 = 857,

        /// <summary>
        /// movupd m128, xmm |  | 
        /// </summary>
        [Symbol("movupd m128, xmm","movupd m128, xmm |  | ")]
        movupd_m128_xmm = 858,

        /// <summary>
        /// movupd r8, xmm |  | 
        /// </summary>
        [Symbol("movupd r8, xmm","movupd r8, xmm |  | ")]
        movupd_r8_xmm = 859,

        /// <summary>
        /// movupd xmm, m128 |  | 
        /// </summary>
        [Symbol("movupd xmm, m128","movupd xmm, m128 |  | ")]
        movupd_xmm_m128 = 860,

        /// <summary>
        /// movupd xmm, r8 |  | 
        /// </summary>
        [Symbol("movupd xmm, r8","movupd xmm, r8 |  | ")]
        movupd_xmm_r8 = 861,

        /// <summary>
        /// movzx r16, m8 |  | 
        /// </summary>
        [Symbol("movzx r16, m8","movzx r16, m8 |  | ")]
        movzx_r16_m8 = 862,

        /// <summary>
        /// movzx r16, r8 |  | 
        /// </summary>
        [Symbol("movzx r16, r8","movzx r16, r8 |  | ")]
        movzx_r16_r8 = 863,

        /// <summary>
        /// movzx r32, m16 |  | 
        /// </summary>
        [Symbol("movzx r32, m16","movzx r32, m16 |  | ")]
        movzx_r32_m16 = 864,

        /// <summary>
        /// movzx r32, m8 |  | 
        /// </summary>
        [Symbol("movzx r32, m8","movzx r32, m8 |  | ")]
        movzx_r32_m8 = 865,

        /// <summary>
        /// movzx r32, r16 |  | 
        /// </summary>
        [Symbol("movzx r32, r16","movzx r32, r16 |  | ")]
        movzx_r32_r16 = 866,

        /// <summary>
        /// movzx r32, r8 |  | 
        /// </summary>
        [Symbol("movzx r32, r8","movzx r32, r8 |  | ")]
        movzx_r32_r8 = 867,

        /// <summary>
        /// movzx r64, m16 |  | 
        /// </summary>
        [Symbol("movzx r64, m16","movzx r64, m16 |  | ")]
        movzx_r64_m16 = 868,

        /// <summary>
        /// movzx r64, m8 |  | 
        /// </summary>
        [Symbol("movzx r64, m8","movzx r64, m8 |  | ")]
        movzx_r64_m8 = 869,

        /// <summary>
        /// movzx r64, r16 |  | 
        /// </summary>
        [Symbol("movzx r64, r16","movzx r64, r16 |  | ")]
        movzx_r64_r16 = 870,

        /// <summary>
        /// movzx r64, r8 |  | 
        /// </summary>
        [Symbol("movzx r64, r8","movzx r64, r8 |  | ")]
        movzx_r64_r8 = 871,

        /// <summary>
        /// mpsadbw xmm, m128, imm8 |  | 
        /// </summary>
        [Symbol("mpsadbw xmm, m128, imm8","mpsadbw xmm, m128, imm8 |  | ")]
        mpsadbw_xmm_m128_imm8 = 872,

        /// <summary>
        /// mpsadbw xmm, r8, imm8 |  | 
        /// </summary>
        [Symbol("mpsadbw xmm, r8, imm8","mpsadbw xmm, r8, imm8 |  | ")]
        mpsadbw_xmm_r8_imm8 = 873,

        /// <summary>
        /// mul m16 |  | 
        /// </summary>
        [Symbol("mul m16","mul m16 |  | ")]
        mul_m16 = 874,

        /// <summary>
        /// mul m32 |  | 
        /// </summary>
        [Symbol("mul m32","mul m32 |  | ")]
        mul_m32 = 875,

        /// <summary>
        /// mul m64 |  | 
        /// </summary>
        [Symbol("mul m64","mul m64 |  | ")]
        mul_m64 = 876,

        /// <summary>
        /// mul m8 |  | 
        /// </summary>
        [Symbol("mul m8","mul m8 |  | ")]
        mul_m8 = 877,

        /// <summary>
        /// mul r16 |  | 
        /// </summary>
        [Symbol("mul r16","mul r16 |  | ")]
        mul_r16 = 878,

        /// <summary>
        /// mul r32 |  | 
        /// </summary>
        [Symbol("mul r32","mul r32 |  | ")]
        mul_r32 = 879,

        /// <summary>
        /// mul r64 |  | 
        /// </summary>
        [Symbol("mul r64","mul r64 |  | ")]
        mul_r64 = 880,

        /// <summary>
        /// mul r8 |  | 
        /// </summary>
        [Symbol("mul r8","mul r8 |  | ")]
        mul_r8 = 881,

        /// <summary>
        /// neg m16 |  | 
        /// </summary>
        [Symbol("neg m16","neg m16 |  | ")]
        neg_m16 = 882,

        /// <summary>
        /// neg m32 |  | 
        /// </summary>
        [Symbol("neg m32","neg m32 |  | ")]
        neg_m32 = 883,

        /// <summary>
        /// neg m64 |  | 
        /// </summary>
        [Symbol("neg m64","neg m64 |  | ")]
        neg_m64 = 884,

        /// <summary>
        /// neg m8 |  | 
        /// </summary>
        [Symbol("neg m8","neg m8 |  | ")]
        neg_m8 = 885,

        /// <summary>
        /// neg r16 |  | 
        /// </summary>
        [Symbol("neg r16","neg r16 |  | ")]
        neg_r16 = 886,

        /// <summary>
        /// neg r32 |  | 
        /// </summary>
        [Symbol("neg r32","neg r32 |  | ")]
        neg_r32 = 887,

        /// <summary>
        /// neg r64 |  | 
        /// </summary>
        [Symbol("neg r64","neg r64 |  | ")]
        neg_r64 = 888,

        /// <summary>
        /// neg r8 |  | 
        /// </summary>
        [Symbol("neg r8","neg r8 |  | ")]
        neg_r8 = 889,

        /// <summary>
        /// not m16 |  | 
        /// </summary>
        [Symbol("not m16","not m16 |  | ")]
        not_m16 = 890,

        /// <summary>
        /// not m32 |  | 
        /// </summary>
        [Symbol("not m32","not m32 |  | ")]
        not_m32 = 891,

        /// <summary>
        /// not m64 |  | 
        /// </summary>
        [Symbol("not m64","not m64 |  | ")]
        not_m64 = 892,

        /// <summary>
        /// not m8 |  | 
        /// </summary>
        [Symbol("not m8","not m8 |  | ")]
        not_m8 = 893,

        /// <summary>
        /// not r16 |  | 
        /// </summary>
        [Symbol("not r16","not r16 |  | ")]
        not_r16 = 894,

        /// <summary>
        /// not r32 |  | 
        /// </summary>
        [Symbol("not r32","not r32 |  | ")]
        not_r32 = 895,

        /// <summary>
        /// not r64 |  | 
        /// </summary>
        [Symbol("not r64","not r64 |  | ")]
        not_r64 = 896,

        /// <summary>
        /// not r8 |  | 
        /// </summary>
        [Symbol("not r8","not r8 |  | ")]
        not_r8 = 897,

        /// <summary>
        /// or AL, imm8 |  | 
        /// </summary>
        [Symbol("or AL, imm8","or AL, imm8 |  | ")]
        or_AL_imm8 = 898,

        /// <summary>
        /// or AX, imm16 |  | 
        /// </summary>
        [Symbol("or AX, imm16","or AX, imm16 |  | ")]
        or_AX_imm16 = 899,

        /// <summary>
        /// or EAX, imm32 |  | 
        /// </summary>
        [Symbol("or EAX, imm32","or EAX, imm32 |  | ")]
        or_EAX_imm32 = 900,

        /// <summary>
        /// or m16, imm16 |  | 
        /// </summary>
        [Symbol("or m16, imm16","or m16, imm16 |  | ")]
        or_m16_imm16 = 901,

        /// <summary>
        /// or m16, imm8 |  | 
        /// </summary>
        [Symbol("or m16, imm8","or m16, imm8 |  | ")]
        or_m16_imm8 = 902,

        /// <summary>
        /// or m16, r16 |  | 
        /// </summary>
        [Symbol("or m16, r16","or m16, r16 |  | ")]
        or_m16_r16 = 903,

        /// <summary>
        /// or m32, imm32 |  | 
        /// </summary>
        [Symbol("or m32, imm32","or m32, imm32 |  | ")]
        or_m32_imm32 = 904,

        /// <summary>
        /// or m32, imm8 |  | 
        /// </summary>
        [Symbol("or m32, imm8","or m32, imm8 |  | ")]
        or_m32_imm8 = 905,

        /// <summary>
        /// or m32, r32 |  | 
        /// </summary>
        [Symbol("or m32, r32","or m32, r32 |  | ")]
        or_m32_r32 = 906,

        /// <summary>
        /// or m64, imm32 |  | 
        /// </summary>
        [Symbol("or m64, imm32","or m64, imm32 |  | ")]
        or_m64_imm32 = 907,

        /// <summary>
        /// or m64, imm8 |  | 
        /// </summary>
        [Symbol("or m64, imm8","or m64, imm8 |  | ")]
        or_m64_imm8 = 908,

        /// <summary>
        /// or m64, r64 |  | 
        /// </summary>
        [Symbol("or m64, r64","or m64, r64 |  | ")]
        or_m64_r64 = 909,

        /// <summary>
        /// or m8, imm8 |  | 
        /// </summary>
        [Symbol("or m8, imm8","or m8, imm8 |  | ")]
        or_m8_imm8 = 910,

        /// <summary>
        /// or m8, r8 |  | 
        /// </summary>
        [Symbol("or m8, r8","or m8, r8 |  | ")]
        or_m8_r8 = 911,

        /// <summary>
        /// or r16, imm16 |  | 
        /// </summary>
        [Symbol("or r16, imm16","or r16, imm16 |  | ")]
        or_r16_imm16 = 912,

        /// <summary>
        /// or r16, imm8 |  | 
        /// </summary>
        [Symbol("or r16, imm8","or r16, imm8 |  | ")]
        or_r16_imm8 = 913,

        /// <summary>
        /// or r16, m16 |  | 
        /// </summary>
        [Symbol("or r16, m16","or r16, m16 |  | ")]
        or_r16_m16 = 914,

        /// <summary>
        /// or r16, r16 |  | 
        /// </summary>
        [Symbol("or r16, r16","or r16, r16 |  | ")]
        or_r16_r16 = 915,

        /// <summary>
        /// or r32, imm32 |  | 
        /// </summary>
        [Symbol("or r32, imm32","or r32, imm32 |  | ")]
        or_r32_imm32 = 916,

        /// <summary>
        /// or r32, imm8 |  | 
        /// </summary>
        [Symbol("or r32, imm8","or r32, imm8 |  | ")]
        or_r32_imm8 = 917,

        /// <summary>
        /// or r32, m32 |  | 
        /// </summary>
        [Symbol("or r32, m32","or r32, m32 |  | ")]
        or_r32_m32 = 918,

        /// <summary>
        /// or r32, r32 |  | 
        /// </summary>
        [Symbol("or r32, r32","or r32, r32 |  | ")]
        or_r32_r32 = 919,

        /// <summary>
        /// or r64, imm32 |  | 
        /// </summary>
        [Symbol("or r64, imm32","or r64, imm32 |  | ")]
        or_r64_imm32 = 920,

        /// <summary>
        /// or r64, imm8 |  | 
        /// </summary>
        [Symbol("or r64, imm8","or r64, imm8 |  | ")]
        or_r64_imm8 = 921,

        /// <summary>
        /// or r64, m64 |  | 
        /// </summary>
        [Symbol("or r64, m64","or r64, m64 |  | ")]
        or_r64_m64 = 922,

        /// <summary>
        /// or r64, r64 |  | 
        /// </summary>
        [Symbol("or r64, r64","or r64, r64 |  | ")]
        or_r64_r64 = 923,

        /// <summary>
        /// or r8, imm8 |  | 
        /// </summary>
        [Symbol("or r8, imm8","or r8, imm8 |  | ")]
        or_r8_imm8 = 924,

        /// <summary>
        /// or r8, m8 |  | 
        /// </summary>
        [Symbol("or r8, m8","or r8, m8 |  | ")]
        or_r8_m8 = 925,

        /// <summary>
        /// or r8, r8 |  | 
        /// </summary>
        [Symbol("or r8, r8","or r8, r8 |  | ")]
        or_r8_r8 = 926,

        /// <summary>
        /// or RAX, imm32 |  | 
        /// </summary>
        [Symbol("or RAX, imm32","or RAX, imm32 |  | ")]
        or_RAX_imm32 = 927,

        /// <summary>
        /// out DX, AL |  | 
        /// </summary>
        [Symbol("out DX, AL","out DX, AL |  | ")]
        out_DX_AL = 928,

        /// <summary>
        /// out DX, AX |  | 
        /// </summary>
        [Symbol("out DX, AX","out DX, AX |  | ")]
        out_DX_AX = 929,

        /// <summary>
        /// out DX, EAX |  | 
        /// </summary>
        [Symbol("out DX, EAX","out DX, EAX |  | ")]
        out_DX_EAX = 930,

        /// <summary>
        /// out imm8, AL |  | 
        /// </summary>
        [Symbol("out imm8, AL","out imm8, AL |  | ")]
        out_imm8_AL = 931,

        /// <summary>
        /// out imm8, AX |  | 
        /// </summary>
        [Symbol("out imm8, AX","out imm8, AX |  | ")]
        out_imm8_AX = 932,

        /// <summary>
        /// out imm8, EAX |  | 
        /// </summary>
        [Symbol("out imm8, EAX","out imm8, EAX |  | ")]
        out_imm8_EAX = 933,

        /// <summary>
        /// outs DX, m16 |  | 
        /// </summary>
        [Symbol("outs DX, m16","outs DX, m16 |  | ")]
        outs_DX_m16 = 934,

        /// <summary>
        /// outs DX, m32 |  | 
        /// </summary>
        [Symbol("outs DX, m32","outs DX, m32 |  | ")]
        outs_DX_m32 = 935,

        /// <summary>
        /// outs DX, m8 |  | 
        /// </summary>
        [Symbol("outs DX, m8","outs DX, m8 |  | ")]
        outs_DX_m8 = 936,

        /// <summary>
        /// outsb |  | 
        /// </summary>
        [Symbol("outsb","outsb |  | ")]
        outsb = 937,

        /// <summary>
        /// outsd |  | 
        /// </summary>
        [Symbol("outsd","outsd |  | ")]
        outsd = 938,

        /// <summary>
        /// outsw |  | 
        /// </summary>
        [Symbol("outsw","outsw |  | ")]
        outsw = 939,

        /// <summary>
        /// pabsb mm, m64 |  | 
        /// </summary>
        [Symbol("pabsb mm, m64","pabsb mm, m64 |  | ")]
        pabsb_mm_m64 = 940,

        /// <summary>
        /// pabsb mm, r8 |  | 
        /// </summary>
        [Symbol("pabsb mm, r8","pabsb mm, r8 |  | ")]
        pabsb_mm_r8 = 941,

        /// <summary>
        /// pabsb xmm, m128 |  | 
        /// </summary>
        [Symbol("pabsb xmm, m128","pabsb xmm, m128 |  | ")]
        pabsb_xmm_m128 = 942,

        /// <summary>
        /// pabsb xmm, r8 |  | 
        /// </summary>
        [Symbol("pabsb xmm, r8","pabsb xmm, r8 |  | ")]
        pabsb_xmm_r8 = 943,

        /// <summary>
        /// pabsd mm, m64 |  | 
        /// </summary>
        [Symbol("pabsd mm, m64","pabsd mm, m64 |  | ")]
        pabsd_mm_m64 = 944,

        /// <summary>
        /// pabsd mm, r8 |  | 
        /// </summary>
        [Symbol("pabsd mm, r8","pabsd mm, r8 |  | ")]
        pabsd_mm_r8 = 945,

        /// <summary>
        /// pabsd xmm, m128 |  | 
        /// </summary>
        [Symbol("pabsd xmm, m128","pabsd xmm, m128 |  | ")]
        pabsd_xmm_m128 = 946,

        /// <summary>
        /// pabsd xmm, r8 |  | 
        /// </summary>
        [Symbol("pabsd xmm, r8","pabsd xmm, r8 |  | ")]
        pabsd_xmm_r8 = 947,

        /// <summary>
        /// pabsw mm, m64 |  | 
        /// </summary>
        [Symbol("pabsw mm, m64","pabsw mm, m64 |  | ")]
        pabsw_mm_m64 = 948,

        /// <summary>
        /// pabsw mm, r8 |  | 
        /// </summary>
        [Symbol("pabsw mm, r8","pabsw mm, r8 |  | ")]
        pabsw_mm_r8 = 949,

        /// <summary>
        /// pabsw xmm, m128 |  | 
        /// </summary>
        [Symbol("pabsw xmm, m128","pabsw xmm, m128 |  | ")]
        pabsw_xmm_m128 = 950,

        /// <summary>
        /// pabsw xmm, r8 |  | 
        /// </summary>
        [Symbol("pabsw xmm, r8","pabsw xmm, r8 |  | ")]
        pabsw_xmm_r8 = 951,

        /// <summary>
        /// packssdw mm, m64 |  | 
        /// </summary>
        [Symbol("packssdw mm, m64","packssdw mm, m64 |  | ")]
        packssdw_mm_m64 = 952,

        /// <summary>
        /// packssdw mm, r8 |  | 
        /// </summary>
        [Symbol("packssdw mm, r8","packssdw mm, r8 |  | ")]
        packssdw_mm_r8 = 953,

        /// <summary>
        /// packssdw xmm, m128 |  | 
        /// </summary>
        [Symbol("packssdw xmm, m128","packssdw xmm, m128 |  | ")]
        packssdw_xmm_m128 = 954,

        /// <summary>
        /// packssdw xmm, r8 |  | 
        /// </summary>
        [Symbol("packssdw xmm, r8","packssdw xmm, r8 |  | ")]
        packssdw_xmm_r8 = 955,

        /// <summary>
        /// packsswb mm, m64 |  | 
        /// </summary>
        [Symbol("packsswb mm, m64","packsswb mm, m64 |  | ")]
        packsswb_mm_m64 = 956,

        /// <summary>
        /// packsswb mm, r8 |  | 
        /// </summary>
        [Symbol("packsswb mm, r8","packsswb mm, r8 |  | ")]
        packsswb_mm_r8 = 957,

        /// <summary>
        /// packsswb xmm, m128 |  | 
        /// </summary>
        [Symbol("packsswb xmm, m128","packsswb xmm, m128 |  | ")]
        packsswb_xmm_m128 = 958,

        /// <summary>
        /// packsswb xmm, r8 |  | 
        /// </summary>
        [Symbol("packsswb xmm, r8","packsswb xmm, r8 |  | ")]
        packsswb_xmm_r8 = 959,

        /// <summary>
        /// packusdw xmm, m128 |  | 
        /// </summary>
        [Symbol("packusdw xmm, m128","packusdw xmm, m128 |  | ")]
        packusdw_xmm_m128 = 960,

        /// <summary>
        /// packusdw xmm, r8 |  | 
        /// </summary>
        [Symbol("packusdw xmm, r8","packusdw xmm, r8 |  | ")]
        packusdw_xmm_r8 = 961,

        /// <summary>
        /// packuswb mm, m64 |  | 
        /// </summary>
        [Symbol("packuswb mm, m64","packuswb mm, m64 |  | ")]
        packuswb_mm_m64 = 962,

        /// <summary>
        /// packuswb mm, r8 |  | 
        /// </summary>
        [Symbol("packuswb mm, r8","packuswb mm, r8 |  | ")]
        packuswb_mm_r8 = 963,

        /// <summary>
        /// packuswb xmm, m128 |  | 
        /// </summary>
        [Symbol("packuswb xmm, m128","packuswb xmm, m128 |  | ")]
        packuswb_xmm_m128 = 964,

        /// <summary>
        /// packuswb xmm, r8 |  | 
        /// </summary>
        [Symbol("packuswb xmm, r8","packuswb xmm, r8 |  | ")]
        packuswb_xmm_r8 = 965,

        /// <summary>
        /// paddb mm, m64 |  | 
        /// </summary>
        [Symbol("paddb mm, m64","paddb mm, m64 |  | ")]
        paddb_mm_m64 = 966,

        /// <summary>
        /// paddb mm, r8 |  | 
        /// </summary>
        [Symbol("paddb mm, r8","paddb mm, r8 |  | ")]
        paddb_mm_r8 = 967,

        /// <summary>
        /// paddb xmm, m128 |  | 
        /// </summary>
        [Symbol("paddb xmm, m128","paddb xmm, m128 |  | ")]
        paddb_xmm_m128 = 968,

        /// <summary>
        /// paddb xmm, r8 |  | 
        /// </summary>
        [Symbol("paddb xmm, r8","paddb xmm, r8 |  | ")]
        paddb_xmm_r8 = 969,

        /// <summary>
        /// paddd mm, m64 |  | 
        /// </summary>
        [Symbol("paddd mm, m64","paddd mm, m64 |  | ")]
        paddd_mm_m64 = 970,

        /// <summary>
        /// paddd mm, r8 |  | 
        /// </summary>
        [Symbol("paddd mm, r8","paddd mm, r8 |  | ")]
        paddd_mm_r8 = 971,

        /// <summary>
        /// paddd xmm, m128 |  | 
        /// </summary>
        [Symbol("paddd xmm, m128","paddd xmm, m128 |  | ")]
        paddd_xmm_m128 = 972,

        /// <summary>
        /// paddd xmm, r8 |  | 
        /// </summary>
        [Symbol("paddd xmm, r8","paddd xmm, r8 |  | ")]
        paddd_xmm_r8 = 973,

        /// <summary>
        /// paddq mm, m64 |  | 
        /// </summary>
        [Symbol("paddq mm, m64","paddq mm, m64 |  | ")]
        paddq_mm_m64 = 974,

        /// <summary>
        /// paddq mm, r8 |  | 
        /// </summary>
        [Symbol("paddq mm, r8","paddq mm, r8 |  | ")]
        paddq_mm_r8 = 975,

        /// <summary>
        /// paddq xmm, m128 |  | 
        /// </summary>
        [Symbol("paddq xmm, m128","paddq xmm, m128 |  | ")]
        paddq_xmm_m128 = 976,

        /// <summary>
        /// paddq xmm, r8 |  | 
        /// </summary>
        [Symbol("paddq xmm, r8","paddq xmm, r8 |  | ")]
        paddq_xmm_r8 = 977,

        /// <summary>
        /// paddsb mm, m64 |  | 
        /// </summary>
        [Symbol("paddsb mm, m64","paddsb mm, m64 |  | ")]
        paddsb_mm_m64 = 978,

        /// <summary>
        /// paddsb mm, r8 |  | 
        /// </summary>
        [Symbol("paddsb mm, r8","paddsb mm, r8 |  | ")]
        paddsb_mm_r8 = 979,

        /// <summary>
        /// paddsb xmm, m128 |  | 
        /// </summary>
        [Symbol("paddsb xmm, m128","paddsb xmm, m128 |  | ")]
        paddsb_xmm_m128 = 980,

        /// <summary>
        /// paddsb xmm, r8 |  | 
        /// </summary>
        [Symbol("paddsb xmm, r8","paddsb xmm, r8 |  | ")]
        paddsb_xmm_r8 = 981,

        /// <summary>
        /// paddsw mm, m64 |  | 
        /// </summary>
        [Symbol("paddsw mm, m64","paddsw mm, m64 |  | ")]
        paddsw_mm_m64 = 982,

        /// <summary>
        /// paddsw mm, r8 |  | 
        /// </summary>
        [Symbol("paddsw mm, r8","paddsw mm, r8 |  | ")]
        paddsw_mm_r8 = 983,

        /// <summary>
        /// paddsw xmm, m128 |  | 
        /// </summary>
        [Symbol("paddsw xmm, m128","paddsw xmm, m128 |  | ")]
        paddsw_xmm_m128 = 984,

        /// <summary>
        /// paddsw xmm, r8 |  | 
        /// </summary>
        [Symbol("paddsw xmm, r8","paddsw xmm, r8 |  | ")]
        paddsw_xmm_r8 = 985,

        /// <summary>
        /// paddusb mm, m64 |  | 
        /// </summary>
        [Symbol("paddusb mm, m64","paddusb mm, m64 |  | ")]
        paddusb_mm_m64 = 986,

        /// <summary>
        /// paddusb mm, r8 |  | 
        /// </summary>
        [Symbol("paddusb mm, r8","paddusb mm, r8 |  | ")]
        paddusb_mm_r8 = 987,

        /// <summary>
        /// paddusb xmm, m128 |  | 
        /// </summary>
        [Symbol("paddusb xmm, m128","paddusb xmm, m128 |  | ")]
        paddusb_xmm_m128 = 988,

        /// <summary>
        /// paddusb xmm, r8 |  | 
        /// </summary>
        [Symbol("paddusb xmm, r8","paddusb xmm, r8 |  | ")]
        paddusb_xmm_r8 = 989,

        /// <summary>
        /// paddusw mm, m64 |  | 
        /// </summary>
        [Symbol("paddusw mm, m64","paddusw mm, m64 |  | ")]
        paddusw_mm_m64 = 990,

        /// <summary>
        /// paddusw mm, r8 |  | 
        /// </summary>
        [Symbol("paddusw mm, r8","paddusw mm, r8 |  | ")]
        paddusw_mm_r8 = 991,

        /// <summary>
        /// paddusw xmm, m128 |  | 
        /// </summary>
        [Symbol("paddusw xmm, m128","paddusw xmm, m128 |  | ")]
        paddusw_xmm_m128 = 992,

        /// <summary>
        /// paddusw xmm, r8 |  | 
        /// </summary>
        [Symbol("paddusw xmm, r8","paddusw xmm, r8 |  | ")]
        paddusw_xmm_r8 = 993,

        /// <summary>
        /// paddw mm, m64 |  | 
        /// </summary>
        [Symbol("paddw mm, m64","paddw mm, m64 |  | ")]
        paddw_mm_m64 = 994,

        /// <summary>
        /// paddw mm, r8 |  | 
        /// </summary>
        [Symbol("paddw mm, r8","paddw mm, r8 |  | ")]
        paddw_mm_r8 = 995,

        /// <summary>
        /// paddw xmm, m128 |  | 
        /// </summary>
        [Symbol("paddw xmm, m128","paddw xmm, m128 |  | ")]
        paddw_xmm_m128 = 996,

        /// <summary>
        /// paddw xmm, r8 |  | 
        /// </summary>
        [Symbol("paddw xmm, r8","paddw xmm, r8 |  | ")]
        paddw_xmm_r8 = 997,

        /// <summary>
        /// pand mm, m64 |  | 
        /// </summary>
        [Symbol("pand mm, m64","pand mm, m64 |  | ")]
        pand_mm_m64 = 998,

        /// <summary>
        /// pand mm, r8 |  | 
        /// </summary>
        [Symbol("pand mm, r8","pand mm, r8 |  | ")]
        pand_mm_r8 = 999,

        /// <summary>
        /// pand xmm, m128 |  | 
        /// </summary>
        [Symbol("pand xmm, m128","pand xmm, m128 |  | ")]
        pand_xmm_m128 = 1000,

        /// <summary>
        /// pand xmm, r8 |  | 
        /// </summary>
        [Symbol("pand xmm, r8","pand xmm, r8 |  | ")]
        pand_xmm_r8 = 1001,

        /// <summary>
        /// pandn mm, m64 |  | 
        /// </summary>
        [Symbol("pandn mm, m64","pandn mm, m64 |  | ")]
        pandn_mm_m64 = 1002,

        /// <summary>
        /// pandn mm, r8 |  | 
        /// </summary>
        [Symbol("pandn mm, r8","pandn mm, r8 |  | ")]
        pandn_mm_r8 = 1003,

        /// <summary>
        /// pandn xmm, m128 |  | 
        /// </summary>
        [Symbol("pandn xmm, m128","pandn xmm, m128 |  | ")]
        pandn_xmm_m128 = 1004,

        /// <summary>
        /// pandn xmm, r8 |  | 
        /// </summary>
        [Symbol("pandn xmm, r8","pandn xmm, r8 |  | ")]
        pandn_xmm_r8 = 1005,

        /// <summary>
        /// pavgb mm, m64 |  | 
        /// </summary>
        [Symbol("pavgb mm, m64","pavgb mm, m64 |  | ")]
        pavgb_mm_m64 = 1006,

        /// <summary>
        /// pavgb mm, r8 |  | 
        /// </summary>
        [Symbol("pavgb mm, r8","pavgb mm, r8 |  | ")]
        pavgb_mm_r8 = 1007,

        /// <summary>
        /// pavgb xmm, m128 |  | 
        /// </summary>
        [Symbol("pavgb xmm, m128","pavgb xmm, m128 |  | ")]
        pavgb_xmm_m128 = 1008,

        /// <summary>
        /// pavgb xmm, r8 |  | 
        /// </summary>
        [Symbol("pavgb xmm, r8","pavgb xmm, r8 |  | ")]
        pavgb_xmm_r8 = 1009,

        /// <summary>
        /// pavgw mm, m64 |  | 
        /// </summary>
        [Symbol("pavgw mm, m64","pavgw mm, m64 |  | ")]
        pavgw_mm_m64 = 1010,

        /// <summary>
        /// pavgw mm, r8 |  | 
        /// </summary>
        [Symbol("pavgw mm, r8","pavgw mm, r8 |  | ")]
        pavgw_mm_r8 = 1011,

        /// <summary>
        /// pavgw xmm, m128 |  | 
        /// </summary>
        [Symbol("pavgw xmm, m128","pavgw xmm, m128 |  | ")]
        pavgw_xmm_m128 = 1012,

        /// <summary>
        /// pavgw xmm, r8 |  | 
        /// </summary>
        [Symbol("pavgw xmm, r8","pavgw xmm, r8 |  | ")]
        pavgw_xmm_r8 = 1013,

        /// <summary>
        /// pcmpeqb mm, m64 |  | 
        /// </summary>
        [Symbol("pcmpeqb mm, m64","pcmpeqb mm, m64 |  | ")]
        pcmpeqb_mm_m64 = 1014,

        /// <summary>
        /// pcmpeqb mm, r8 |  | 
        /// </summary>
        [Symbol("pcmpeqb mm, r8","pcmpeqb mm, r8 |  | ")]
        pcmpeqb_mm_r8 = 1015,

        /// <summary>
        /// pcmpeqb xmm, m128 |  | 
        /// </summary>
        [Symbol("pcmpeqb xmm, m128","pcmpeqb xmm, m128 |  | ")]
        pcmpeqb_xmm_m128 = 1016,

        /// <summary>
        /// pcmpeqb xmm, r8 |  | 
        /// </summary>
        [Symbol("pcmpeqb xmm, r8","pcmpeqb xmm, r8 |  | ")]
        pcmpeqb_xmm_r8 = 1017,

        /// <summary>
        /// pcmpeqd mm, m64 |  | 
        /// </summary>
        [Symbol("pcmpeqd mm, m64","pcmpeqd mm, m64 |  | ")]
        pcmpeqd_mm_m64 = 1018,

        /// <summary>
        /// pcmpeqd mm, r8 |  | 
        /// </summary>
        [Symbol("pcmpeqd mm, r8","pcmpeqd mm, r8 |  | ")]
        pcmpeqd_mm_r8 = 1019,

        /// <summary>
        /// pcmpeqd xmm, m128 |  | 
        /// </summary>
        [Symbol("pcmpeqd xmm, m128","pcmpeqd xmm, m128 |  | ")]
        pcmpeqd_xmm_m128 = 1020,

        /// <summary>
        /// pcmpeqd xmm, r8 |  | 
        /// </summary>
        [Symbol("pcmpeqd xmm, r8","pcmpeqd xmm, r8 |  | ")]
        pcmpeqd_xmm_r8 = 1021,

        /// <summary>
        /// pcmpeqq xmm, m128 |  | 
        /// </summary>
        [Symbol("pcmpeqq xmm, m128","pcmpeqq xmm, m128 |  | ")]
        pcmpeqq_xmm_m128 = 1022,

        /// <summary>
        /// pcmpeqq xmm, r8 |  | 
        /// </summary>
        [Symbol("pcmpeqq xmm, r8","pcmpeqq xmm, r8 |  | ")]
        pcmpeqq_xmm_r8 = 1023,

        /// <summary>
        /// pcmpeqw mm, m64 |  | 
        /// </summary>
        [Symbol("pcmpeqw mm, m64","pcmpeqw mm, m64 |  | ")]
        pcmpeqw_mm_m64 = 1024,

        /// <summary>
        /// pcmpeqw mm, r8 |  | 
        /// </summary>
        [Symbol("pcmpeqw mm, r8","pcmpeqw mm, r8 |  | ")]
        pcmpeqw_mm_r8 = 1025,

        /// <summary>
        /// pcmpeqw xmm, m128 |  | 
        /// </summary>
        [Symbol("pcmpeqw xmm, m128","pcmpeqw xmm, m128 |  | ")]
        pcmpeqw_xmm_m128 = 1026,

        /// <summary>
        /// pcmpeqw xmm, r8 |  | 
        /// </summary>
        [Symbol("pcmpeqw xmm, r8","pcmpeqw xmm, r8 |  | ")]
        pcmpeqw_xmm_r8 = 1027,

        /// <summary>
        /// pcmpgtb mm, m64 |  | 
        /// </summary>
        [Symbol("pcmpgtb mm, m64","pcmpgtb mm, m64 |  | ")]
        pcmpgtb_mm_m64 = 1028,

        /// <summary>
        /// pcmpgtb mm, r8 |  | 
        /// </summary>
        [Symbol("pcmpgtb mm, r8","pcmpgtb mm, r8 |  | ")]
        pcmpgtb_mm_r8 = 1029,

        /// <summary>
        /// pcmpgtb xmm, m128 |  | 
        /// </summary>
        [Symbol("pcmpgtb xmm, m128","pcmpgtb xmm, m128 |  | ")]
        pcmpgtb_xmm_m128 = 1030,

        /// <summary>
        /// pcmpgtb xmm, r8 |  | 
        /// </summary>
        [Symbol("pcmpgtb xmm, r8","pcmpgtb xmm, r8 |  | ")]
        pcmpgtb_xmm_r8 = 1031,

        /// <summary>
        /// pcmpgtd mm, m64 |  | 
        /// </summary>
        [Symbol("pcmpgtd mm, m64","pcmpgtd mm, m64 |  | ")]
        pcmpgtd_mm_m64 = 1032,

        /// <summary>
        /// pcmpgtd mm, r8 |  | 
        /// </summary>
        [Symbol("pcmpgtd mm, r8","pcmpgtd mm, r8 |  | ")]
        pcmpgtd_mm_r8 = 1033,

        /// <summary>
        /// pcmpgtd xmm, m128 |  | 
        /// </summary>
        [Symbol("pcmpgtd xmm, m128","pcmpgtd xmm, m128 |  | ")]
        pcmpgtd_xmm_m128 = 1034,

        /// <summary>
        /// pcmpgtd xmm, r8 |  | 
        /// </summary>
        [Symbol("pcmpgtd xmm, r8","pcmpgtd xmm, r8 |  | ")]
        pcmpgtd_xmm_r8 = 1035,

        /// <summary>
        /// pcmpgtq xmm, m128 |  | 
        /// </summary>
        [Symbol("pcmpgtq xmm, m128","pcmpgtq xmm, m128 |  | ")]
        pcmpgtq_xmm_m128 = 1036,

        /// <summary>
        /// pcmpgtq xmm, r8 |  | 
        /// </summary>
        [Symbol("pcmpgtq xmm, r8","pcmpgtq xmm, r8 |  | ")]
        pcmpgtq_xmm_r8 = 1037,

        /// <summary>
        /// pcmpgtw mm, m64 |  | 
        /// </summary>
        [Symbol("pcmpgtw mm, m64","pcmpgtw mm, m64 |  | ")]
        pcmpgtw_mm_m64 = 1038,

        /// <summary>
        /// pcmpgtw mm, r8 |  | 
        /// </summary>
        [Symbol("pcmpgtw mm, r8","pcmpgtw mm, r8 |  | ")]
        pcmpgtw_mm_r8 = 1039,

        /// <summary>
        /// pcmpgtw xmm, m128 |  | 
        /// </summary>
        [Symbol("pcmpgtw xmm, m128","pcmpgtw xmm, m128 |  | ")]
        pcmpgtw_xmm_m128 = 1040,

        /// <summary>
        /// pcmpgtw xmm, r8 |  | 
        /// </summary>
        [Symbol("pcmpgtw xmm, r8","pcmpgtw xmm, r8 |  | ")]
        pcmpgtw_xmm_r8 = 1041,

        /// <summary>
        /// pdep r32, r32, m32 |  | 
        /// </summary>
        [Symbol("pdep r32, r32, m32","pdep r32, r32, m32 |  | ")]
        pdep_r32_r32_m32 = 1042,

        /// <summary>
        /// pdep r32, r32, r32 |  | 
        /// </summary>
        [Symbol("pdep r32, r32, r32","pdep r32, r32, r32 |  | ")]
        pdep_r32_r32_r32 = 1043,

        /// <summary>
        /// pdep r64, r64, m64 |  | 
        /// </summary>
        [Symbol("pdep r64, r64, m64","pdep r64, r64, m64 |  | ")]
        pdep_r64_r64_m64 = 1044,

        /// <summary>
        /// pdep r64, r64, r64 |  | 
        /// </summary>
        [Symbol("pdep r64, r64, r64","pdep r64, r64, r64 |  | ")]
        pdep_r64_r64_r64 = 1045,

        /// <summary>
        /// pextrb m8, xmm, imm8 |  | 
        /// </summary>
        [Symbol("pextrb m8, xmm, imm8","pextrb m8, xmm, imm8 |  | ")]
        pextrb_m8_xmm_imm8 = 1046,

        /// <summary>
        /// pextrb r8, xmm, imm8 |  | 
        /// </summary>
        [Symbol("pextrb r8, xmm, imm8","pextrb r8, xmm, imm8 |  | ")]
        pextrb_r8_xmm_imm8 = 1047,

        /// <summary>
        /// pextrd m32, xmm, imm8 |  | 
        /// </summary>
        [Symbol("pextrd m32, xmm, imm8","pextrd m32, xmm, imm8 |  | ")]
        pextrd_m32_xmm_imm8 = 1048,

        /// <summary>
        /// pextrd r32, xmm, imm8 |  | 
        /// </summary>
        [Symbol("pextrd r32, xmm, imm8","pextrd r32, xmm, imm8 |  | ")]
        pextrd_r32_xmm_imm8 = 1049,

        /// <summary>
        /// pextrq m64, xmm, imm8 |  | 
        /// </summary>
        [Symbol("pextrq m64, xmm, imm8","pextrq m64, xmm, imm8 |  | ")]
        pextrq_m64_xmm_imm8 = 1050,

        /// <summary>
        /// pextrq r64, xmm, imm8 |  | 
        /// </summary>
        [Symbol("pextrq r64, xmm, imm8","pextrq r64, xmm, imm8 |  | ")]
        pextrq_r64_xmm_imm8 = 1051,

        /// <summary>
        /// pextrw m16, xmm, imm8 |  | 
        /// </summary>
        [Symbol("pextrw m16, xmm, imm8","pextrw m16, xmm, imm8 |  | ")]
        pextrw_m16_xmm_imm8 = 1052,

        /// <summary>
        /// pextrw r16, xmm, imm8 |  | 
        /// </summary>
        [Symbol("pextrw r16, xmm, imm8","pextrw r16, xmm, imm8 |  | ")]
        pextrw_r16_xmm_imm8 = 1053,

        /// <summary>
        /// pextrw reg, mm, imm8 |  | 
        /// </summary>
        [Symbol("pextrw reg, mm, imm8","pextrw reg, mm, imm8 |  | ")]
        pextrw_reg_mm_imm8 = 1054,

        /// <summary>
        /// pextrw reg, xmm, imm8 |  | 
        /// </summary>
        [Symbol("pextrw reg, xmm, imm8","pextrw reg, xmm, imm8 |  | ")]
        pextrw_reg_xmm_imm8 = 1055,

        /// <summary>
        /// phaddd mm, m64 |  | 
        /// </summary>
        [Symbol("phaddd mm, m64","phaddd mm, m64 |  | ")]
        phaddd_mm_m64 = 1056,

        /// <summary>
        /// phaddd mm, r8 |  | 
        /// </summary>
        [Symbol("phaddd mm, r8","phaddd mm, r8 |  | ")]
        phaddd_mm_r8 = 1057,

        /// <summary>
        /// phaddd xmm, m128 |  | 
        /// </summary>
        [Symbol("phaddd xmm, m128","phaddd xmm, m128 |  | ")]
        phaddd_xmm_m128 = 1058,

        /// <summary>
        /// phaddd xmm, r8 |  | 
        /// </summary>
        [Symbol("phaddd xmm, r8","phaddd xmm, r8 |  | ")]
        phaddd_xmm_r8 = 1059,

        /// <summary>
        /// phaddsw mm, m64 |  | 
        /// </summary>
        [Symbol("phaddsw mm, m64","phaddsw mm, m64 |  | ")]
        phaddsw_mm_m64 = 1060,

        /// <summary>
        /// phaddsw mm, r8 |  | 
        /// </summary>
        [Symbol("phaddsw mm, r8","phaddsw mm, r8 |  | ")]
        phaddsw_mm_r8 = 1061,

        /// <summary>
        /// phaddsw xmm, m128 |  | 
        /// </summary>
        [Symbol("phaddsw xmm, m128","phaddsw xmm, m128 |  | ")]
        phaddsw_xmm_m128 = 1062,

        /// <summary>
        /// phaddsw xmm, r8 |  | 
        /// </summary>
        [Symbol("phaddsw xmm, r8","phaddsw xmm, r8 |  | ")]
        phaddsw_xmm_r8 = 1063,

        /// <summary>
        /// phaddw mm, m64 |  | 
        /// </summary>
        [Symbol("phaddw mm, m64","phaddw mm, m64 |  | ")]
        phaddw_mm_m64 = 1064,

        /// <summary>
        /// phaddw mm, r8 |  | 
        /// </summary>
        [Symbol("phaddw mm, r8","phaddw mm, r8 |  | ")]
        phaddw_mm_r8 = 1065,

        /// <summary>
        /// phaddw xmm, m128 |  | 
        /// </summary>
        [Symbol("phaddw xmm, m128","phaddw xmm, m128 |  | ")]
        phaddw_xmm_m128 = 1066,

        /// <summary>
        /// phaddw xmm, r8 |  | 
        /// </summary>
        [Symbol("phaddw xmm, r8","phaddw xmm, r8 |  | ")]
        phaddw_xmm_r8 = 1067,

        /// <summary>
        /// pinsrb xmm, m8, imm8 |  | 
        /// </summary>
        [Symbol("pinsrb xmm, m8, imm8","pinsrb xmm, m8, imm8 |  | ")]
        pinsrb_xmm_m8_imm8 = 1068,

        /// <summary>
        /// pinsrb xmm, r32, imm8 |  | 
        /// </summary>
        [Symbol("pinsrb xmm, r32, imm8","pinsrb xmm, r32, imm8 |  | ")]
        pinsrb_xmm_r32_imm8 = 1069,

        /// <summary>
        /// pinsrd xmm, m32, imm8 |  | 
        /// </summary>
        [Symbol("pinsrd xmm, m32, imm8","pinsrd xmm, m32, imm8 |  | ")]
        pinsrd_xmm_m32_imm8 = 1070,

        /// <summary>
        /// pinsrd xmm, r32, imm8 |  | 
        /// </summary>
        [Symbol("pinsrd xmm, r32, imm8","pinsrd xmm, r32, imm8 |  | ")]
        pinsrd_xmm_r32_imm8 = 1071,

        /// <summary>
        /// pinsrq xmm, m64, imm8 |  | 
        /// </summary>
        [Symbol("pinsrq xmm, m64, imm8","pinsrq xmm, m64, imm8 |  | ")]
        pinsrq_xmm_m64_imm8 = 1072,

        /// <summary>
        /// pinsrq xmm, r64, imm8 |  | 
        /// </summary>
        [Symbol("pinsrq xmm, r64, imm8","pinsrq xmm, r64, imm8 |  | ")]
        pinsrq_xmm_r64_imm8 = 1073,

        /// <summary>
        /// pinsrw mm, m16, imm8 |  | 
        /// </summary>
        [Symbol("pinsrw mm, m16, imm8","pinsrw mm, m16, imm8 |  | ")]
        pinsrw_mm_m16_imm8 = 1074,

        /// <summary>
        /// pinsrw mm, r32, imm8 |  | 
        /// </summary>
        [Symbol("pinsrw mm, r32, imm8","pinsrw mm, r32, imm8 |  | ")]
        pinsrw_mm_r32_imm8 = 1075,

        /// <summary>
        /// pinsrw xmm, m16, imm8 |  | 
        /// </summary>
        [Symbol("pinsrw xmm, m16, imm8","pinsrw xmm, m16, imm8 |  | ")]
        pinsrw_xmm_m16_imm8 = 1076,

        /// <summary>
        /// pinsrw xmm, r32, imm8 |  | 
        /// </summary>
        [Symbol("pinsrw xmm, r32, imm8","pinsrw xmm, r32, imm8 |  | ")]
        pinsrw_xmm_r32_imm8 = 1077,

        /// <summary>
        /// pmaxsb xmm, m128 |  | 
        /// </summary>
        [Symbol("pmaxsb xmm, m128","pmaxsb xmm, m128 |  | ")]
        pmaxsb_xmm_m128 = 1078,

        /// <summary>
        /// pmaxsb xmm, r8 |  | 
        /// </summary>
        [Symbol("pmaxsb xmm, r8","pmaxsb xmm, r8 |  | ")]
        pmaxsb_xmm_r8 = 1079,

        /// <summary>
        /// pmaxsd xmm, m128 |  | 
        /// </summary>
        [Symbol("pmaxsd xmm, m128","pmaxsd xmm, m128 |  | ")]
        pmaxsd_xmm_m128 = 1080,

        /// <summary>
        /// pmaxsd xmm, r8 |  | 
        /// </summary>
        [Symbol("pmaxsd xmm, r8","pmaxsd xmm, r8 |  | ")]
        pmaxsd_xmm_r8 = 1081,

        /// <summary>
        /// pmaxsw mm, m64 |  | 
        /// </summary>
        [Symbol("pmaxsw mm, m64","pmaxsw mm, m64 |  | ")]
        pmaxsw_mm_m64 = 1082,

        /// <summary>
        /// pmaxsw mm, r8 |  | 
        /// </summary>
        [Symbol("pmaxsw mm, r8","pmaxsw mm, r8 |  | ")]
        pmaxsw_mm_r8 = 1083,

        /// <summary>
        /// pmaxsw xmm, m128 |  | 
        /// </summary>
        [Symbol("pmaxsw xmm, m128","pmaxsw xmm, m128 |  | ")]
        pmaxsw_xmm_m128 = 1084,

        /// <summary>
        /// pmaxsw xmm, r8 |  | 
        /// </summary>
        [Symbol("pmaxsw xmm, r8","pmaxsw xmm, r8 |  | ")]
        pmaxsw_xmm_r8 = 1085,

        /// <summary>
        /// pmaxub mm, m64 |  | 
        /// </summary>
        [Symbol("pmaxub mm, m64","pmaxub mm, m64 |  | ")]
        pmaxub_mm_m64 = 1086,

        /// <summary>
        /// pmaxub mm, r8 |  | 
        /// </summary>
        [Symbol("pmaxub mm, r8","pmaxub mm, r8 |  | ")]
        pmaxub_mm_r8 = 1087,

        /// <summary>
        /// pmaxub xmm, m128 |  | 
        /// </summary>
        [Symbol("pmaxub xmm, m128","pmaxub xmm, m128 |  | ")]
        pmaxub_xmm_m128 = 1088,

        /// <summary>
        /// pmaxub xmm, r8 |  | 
        /// </summary>
        [Symbol("pmaxub xmm, r8","pmaxub xmm, r8 |  | ")]
        pmaxub_xmm_r8 = 1089,

        /// <summary>
        /// pmaxuw xmm, m128 |  | 
        /// </summary>
        [Symbol("pmaxuw xmm, m128","pmaxuw xmm, m128 |  | ")]
        pmaxuw_xmm_m128 = 1090,

        /// <summary>
        /// pmaxuw xmm, r8 |  | 
        /// </summary>
        [Symbol("pmaxuw xmm, r8","pmaxuw xmm, r8 |  | ")]
        pmaxuw_xmm_r8 = 1091,

        /// <summary>
        /// pminsb xmm, m128 |  | 
        /// </summary>
        [Symbol("pminsb xmm, m128","pminsb xmm, m128 |  | ")]
        pminsb_xmm_m128 = 1092,

        /// <summary>
        /// pminsb xmm, r8 |  | 
        /// </summary>
        [Symbol("pminsb xmm, r8","pminsb xmm, r8 |  | ")]
        pminsb_xmm_r8 = 1093,

        /// <summary>
        /// pminsw mm, m64 |  | 
        /// </summary>
        [Symbol("pminsw mm, m64","pminsw mm, m64 |  | ")]
        pminsw_mm_m64 = 1094,

        /// <summary>
        /// pminsw mm, r8 |  | 
        /// </summary>
        [Symbol("pminsw mm, r8","pminsw mm, r8 |  | ")]
        pminsw_mm_r8 = 1095,

        /// <summary>
        /// pminsw xmm, m128 |  | 
        /// </summary>
        [Symbol("pminsw xmm, m128","pminsw xmm, m128 |  | ")]
        pminsw_xmm_m128 = 1096,

        /// <summary>
        /// pminsw xmm, r8 |  | 
        /// </summary>
        [Symbol("pminsw xmm, r8","pminsw xmm, r8 |  | ")]
        pminsw_xmm_r8 = 1097,

        /// <summary>
        /// pminub mm, m64 |  | 
        /// </summary>
        [Symbol("pminub mm, m64","pminub mm, m64 |  | ")]
        pminub_mm_m64 = 1098,

        /// <summary>
        /// pminub mm, r8 |  | 
        /// </summary>
        [Symbol("pminub mm, r8","pminub mm, r8 |  | ")]
        pminub_mm_r8 = 1099,

        /// <summary>
        /// pminub xmm, m128 |  | 
        /// </summary>
        [Symbol("pminub xmm, m128","pminub xmm, m128 |  | ")]
        pminub_xmm_m128 = 1100,

        /// <summary>
        /// pminub xmm, r8 |  | 
        /// </summary>
        [Symbol("pminub xmm, r8","pminub xmm, r8 |  | ")]
        pminub_xmm_r8 = 1101,

        /// <summary>
        /// pminuw xmm, m128 |  | 
        /// </summary>
        [Symbol("pminuw xmm, m128","pminuw xmm, m128 |  | ")]
        pminuw_xmm_m128 = 1102,

        /// <summary>
        /// pminuw xmm, r8 |  | 
        /// </summary>
        [Symbol("pminuw xmm, r8","pminuw xmm, r8 |  | ")]
        pminuw_xmm_r8 = 1103,

        /// <summary>
        /// pmovmskb reg, mm |  | 
        /// </summary>
        [Symbol("pmovmskb reg, mm","pmovmskb reg, mm |  | ")]
        pmovmskb_reg_mm = 1104,

        /// <summary>
        /// pmovmskb reg, xmm |  | 
        /// </summary>
        [Symbol("pmovmskb reg, xmm","pmovmskb reg, xmm |  | ")]
        pmovmskb_reg_xmm = 1105,

        /// <summary>
        /// pmovsxbd xmm, m32 |  | 
        /// </summary>
        [Symbol("pmovsxbd xmm, m32","pmovsxbd xmm, m32 |  | ")]
        pmovsxbd_xmm_m32 = 1106,

        /// <summary>
        /// pmovsxbd xmm, r8 |  | 
        /// </summary>
        [Symbol("pmovsxbd xmm, r8","pmovsxbd xmm, r8 |  | ")]
        pmovsxbd_xmm_r8 = 1107,

        /// <summary>
        /// pmovsxbq xmm, m16 |  | 
        /// </summary>
        [Symbol("pmovsxbq xmm, m16","pmovsxbq xmm, m16 |  | ")]
        pmovsxbq_xmm_m16 = 1108,

        /// <summary>
        /// pmovsxbq xmm, r8 |  | 
        /// </summary>
        [Symbol("pmovsxbq xmm, r8","pmovsxbq xmm, r8 |  | ")]
        pmovsxbq_xmm_r8 = 1109,

        /// <summary>
        /// pmovsxbw xmm, m64 |  | 
        /// </summary>
        [Symbol("pmovsxbw xmm, m64","pmovsxbw xmm, m64 |  | ")]
        pmovsxbw_xmm_m64 = 1110,

        /// <summary>
        /// pmovsxbw xmm, r8 |  | 
        /// </summary>
        [Symbol("pmovsxbw xmm, r8","pmovsxbw xmm, r8 |  | ")]
        pmovsxbw_xmm_r8 = 1111,

        /// <summary>
        /// pmovsxdq xmm, m64 |  | 
        /// </summary>
        [Symbol("pmovsxdq xmm, m64","pmovsxdq xmm, m64 |  | ")]
        pmovsxdq_xmm_m64 = 1112,

        /// <summary>
        /// pmovsxdq xmm, r8 |  | 
        /// </summary>
        [Symbol("pmovsxdq xmm, r8","pmovsxdq xmm, r8 |  | ")]
        pmovsxdq_xmm_r8 = 1113,

        /// <summary>
        /// pmovsxwd xmm, m64 |  | 
        /// </summary>
        [Symbol("pmovsxwd xmm, m64","pmovsxwd xmm, m64 |  | ")]
        pmovsxwd_xmm_m64 = 1114,

        /// <summary>
        /// pmovsxwd xmm, r8 |  | 
        /// </summary>
        [Symbol("pmovsxwd xmm, r8","pmovsxwd xmm, r8 |  | ")]
        pmovsxwd_xmm_r8 = 1115,

        /// <summary>
        /// pmovsxwq xmm, m32 |  | 
        /// </summary>
        [Symbol("pmovsxwq xmm, m32","pmovsxwq xmm, m32 |  | ")]
        pmovsxwq_xmm_m32 = 1116,

        /// <summary>
        /// pmovsxwq xmm, r8 |  | 
        /// </summary>
        [Symbol("pmovsxwq xmm, r8","pmovsxwq xmm, r8 |  | ")]
        pmovsxwq_xmm_r8 = 1117,

        /// <summary>
        /// pmovzxbd xmm, m32 |  | 
        /// </summary>
        [Symbol("pmovzxbd xmm, m32","pmovzxbd xmm, m32 |  | ")]
        pmovzxbd_xmm_m32 = 1118,

        /// <summary>
        /// pmovzxbd xmm, r8 |  | 
        /// </summary>
        [Symbol("pmovzxbd xmm, r8","pmovzxbd xmm, r8 |  | ")]
        pmovzxbd_xmm_r8 = 1119,

        /// <summary>
        /// pmovzxbq xmm, m16 |  | 
        /// </summary>
        [Symbol("pmovzxbq xmm, m16","pmovzxbq xmm, m16 |  | ")]
        pmovzxbq_xmm_m16 = 1120,

        /// <summary>
        /// pmovzxbq xmm, r8 |  | 
        /// </summary>
        [Symbol("pmovzxbq xmm, r8","pmovzxbq xmm, r8 |  | ")]
        pmovzxbq_xmm_r8 = 1121,

        /// <summary>
        /// pmovzxbw xmm, m64 |  | 
        /// </summary>
        [Symbol("pmovzxbw xmm, m64","pmovzxbw xmm, m64 |  | ")]
        pmovzxbw_xmm_m64 = 1122,

        /// <summary>
        /// pmovzxbw xmm, r8 |  | 
        /// </summary>
        [Symbol("pmovzxbw xmm, r8","pmovzxbw xmm, r8 |  | ")]
        pmovzxbw_xmm_r8 = 1123,

        /// <summary>
        /// pmovzxdq xmm, m64 |  | 
        /// </summary>
        [Symbol("pmovzxdq xmm, m64","pmovzxdq xmm, m64 |  | ")]
        pmovzxdq_xmm_m64 = 1124,

        /// <summary>
        /// pmovzxdq xmm, r8 |  | 
        /// </summary>
        [Symbol("pmovzxdq xmm, r8","pmovzxdq xmm, r8 |  | ")]
        pmovzxdq_xmm_r8 = 1125,

        /// <summary>
        /// pmovzxwd xmm, m64 |  | 
        /// </summary>
        [Symbol("pmovzxwd xmm, m64","pmovzxwd xmm, m64 |  | ")]
        pmovzxwd_xmm_m64 = 1126,

        /// <summary>
        /// pmovzxwd xmm, r8 |  | 
        /// </summary>
        [Symbol("pmovzxwd xmm, r8","pmovzxwd xmm, r8 |  | ")]
        pmovzxwd_xmm_r8 = 1127,

        /// <summary>
        /// pmovzxwq xmm, m32 |  | 
        /// </summary>
        [Symbol("pmovzxwq xmm, m32","pmovzxwq xmm, m32 |  | ")]
        pmovzxwq_xmm_m32 = 1128,

        /// <summary>
        /// pmovzxwq xmm, r8 |  | 
        /// </summary>
        [Symbol("pmovzxwq xmm, r8","pmovzxwq xmm, r8 |  | ")]
        pmovzxwq_xmm_r8 = 1129,

        /// <summary>
        /// pmulhuw mm, m64 |  | 
        /// </summary>
        [Symbol("pmulhuw mm, m64","pmulhuw mm, m64 |  | ")]
        pmulhuw_mm_m64 = 1130,

        /// <summary>
        /// pmulhuw mm, r8 |  | 
        /// </summary>
        [Symbol("pmulhuw mm, r8","pmulhuw mm, r8 |  | ")]
        pmulhuw_mm_r8 = 1131,

        /// <summary>
        /// pmulhuw xmm, m128 |  | 
        /// </summary>
        [Symbol("pmulhuw xmm, m128","pmulhuw xmm, m128 |  | ")]
        pmulhuw_xmm_m128 = 1132,

        /// <summary>
        /// pmulhuw xmm, r8 |  | 
        /// </summary>
        [Symbol("pmulhuw xmm, r8","pmulhuw xmm, r8 |  | ")]
        pmulhuw_xmm_r8 = 1133,

        /// <summary>
        /// pmullw mm, m64 |  | 
        /// </summary>
        [Symbol("pmullw mm, m64","pmullw mm, m64 |  | ")]
        pmullw_mm_m64 = 1134,

        /// <summary>
        /// pmullw mm, r8 |  | 
        /// </summary>
        [Symbol("pmullw mm, r8","pmullw mm, r8 |  | ")]
        pmullw_mm_r8 = 1135,

        /// <summary>
        /// pmullw xmm, m128 |  | 
        /// </summary>
        [Symbol("pmullw xmm, m128","pmullw xmm, m128 |  | ")]
        pmullw_xmm_m128 = 1136,

        /// <summary>
        /// pmullw xmm, r8 |  | 
        /// </summary>
        [Symbol("pmullw xmm, r8","pmullw xmm, r8 |  | ")]
        pmullw_xmm_r8 = 1137,

        /// <summary>
        /// pop DS |  | 
        /// </summary>
        [Symbol("pop DS","pop DS |  | ")]
        pop_DS = 1138,

        /// <summary>
        /// pop ES |  | 
        /// </summary>
        [Symbol("pop ES","pop ES |  | ")]
        pop_ES = 1139,

        /// <summary>
        /// pop FS |  | 
        /// </summary>
        [Symbol("pop FS","pop FS |  | ")]
        pop_FS = 1140,

        /// <summary>
        /// pop GS |  | 
        /// </summary>
        [Symbol("pop GS","pop GS |  | ")]
        pop_GS = 1141,

        /// <summary>
        /// pop m16 |  | 
        /// </summary>
        [Symbol("pop m16","pop m16 |  | ")]
        pop_m16 = 1142,

        /// <summary>
        /// pop m32 |  | 
        /// </summary>
        [Symbol("pop m32","pop m32 |  | ")]
        pop_m32 = 1143,

        /// <summary>
        /// pop m64 |  | 
        /// </summary>
        [Symbol("pop m64","pop m64 |  | ")]
        pop_m64 = 1144,

        /// <summary>
        /// pop r16 |  | 
        /// </summary>
        [Symbol("pop r16","pop r16 |  | ")]
        pop_r16 = 1145,

        /// <summary>
        /// pop r32 |  | 
        /// </summary>
        [Symbol("pop r32","pop r32 |  | ")]
        pop_r32 = 1146,

        /// <summary>
        /// pop r64 |  | 
        /// </summary>
        [Symbol("pop r64","pop r64 |  | ")]
        pop_r64 = 1147,

        /// <summary>
        /// pop SS |  | 
        /// </summary>
        [Symbol("pop SS","pop SS |  | ")]
        pop_SS = 1148,

        /// <summary>
        /// popf |  | 
        /// </summary>
        [Symbol("popf","popf |  | ")]
        popf = 1149,

        /// <summary>
        /// popfd |  | 
        /// </summary>
        [Symbol("popfd","popfd |  | ")]
        popfd = 1150,

        /// <summary>
        /// popfq |  | 
        /// </summary>
        [Symbol("popfq","popfq |  | ")]
        popfq = 1151,

        /// <summary>
        /// por mm, m64 |  | 
        /// </summary>
        [Symbol("por mm, m64","por mm, m64 |  | ")]
        por_mm_m64 = 1152,

        /// <summary>
        /// por mm, r8 |  | 
        /// </summary>
        [Symbol("por mm, r8","por mm, r8 |  | ")]
        por_mm_r8 = 1153,

        /// <summary>
        /// por xmm, m128 |  | 
        /// </summary>
        [Symbol("por xmm, m128","por xmm, m128 |  | ")]
        por_xmm_m128 = 1154,

        /// <summary>
        /// por xmm, r8 |  | 
        /// </summary>
        [Symbol("por xmm, r8","por xmm, r8 |  | ")]
        por_xmm_r8 = 1155,

        /// <summary>
        /// prefetchnta m8 |  | 
        /// </summary>
        [Symbol("prefetchnta m8","prefetchnta m8 |  | ")]
        prefetchnta_m8 = 1156,

        /// <summary>
        /// prefetcht0 m8 |  | 
        /// </summary>
        [Symbol("prefetcht0 m8","prefetcht0 m8 |  | ")]
        prefetcht0_m8 = 1157,

        /// <summary>
        /// prefetcht1 m8 |  | 
        /// </summary>
        [Symbol("prefetcht1 m8","prefetcht1 m8 |  | ")]
        prefetcht1_m8 = 1158,

        /// <summary>
        /// prefetcht2 m8 |  | 
        /// </summary>
        [Symbol("prefetcht2 m8","prefetcht2 m8 |  | ")]
        prefetcht2_m8 = 1159,

        /// <summary>
        /// pshufb mm, m64 |  | 
        /// </summary>
        [Symbol("pshufb mm, m64","pshufb mm, m64 |  | ")]
        pshufb_mm_m64 = 1160,

        /// <summary>
        /// pshufb mm, r8 |  | 
        /// </summary>
        [Symbol("pshufb mm, r8","pshufb mm, r8 |  | ")]
        pshufb_mm_r8 = 1161,

        /// <summary>
        /// pshufb xmm, m128 |  | 
        /// </summary>
        [Symbol("pshufb xmm, m128","pshufb xmm, m128 |  | ")]
        pshufb_xmm_m128 = 1162,

        /// <summary>
        /// pshufb xmm, r8 |  | 
        /// </summary>
        [Symbol("pshufb xmm, r8","pshufb xmm, r8 |  | ")]
        pshufb_xmm_r8 = 1163,

        /// <summary>
        /// pshufd xmm, m128, imm8 |  | 
        /// </summary>
        [Symbol("pshufd xmm, m128, imm8","pshufd xmm, m128, imm8 |  | ")]
        pshufd_xmm_m128_imm8 = 1164,

        /// <summary>
        /// pshufd xmm, r8, imm8 |  | 
        /// </summary>
        [Symbol("pshufd xmm, r8, imm8","pshufd xmm, r8, imm8 |  | ")]
        pshufd_xmm_r8_imm8 = 1165,

        /// <summary>
        /// pshuflw xmm, m128, imm8 |  | 
        /// </summary>
        [Symbol("pshuflw xmm, m128, imm8","pshuflw xmm, m128, imm8 |  | ")]
        pshuflw_xmm_m128_imm8 = 1166,

        /// <summary>
        /// pshuflw xmm, r8, imm8 |  | 
        /// </summary>
        [Symbol("pshuflw xmm, r8, imm8","pshuflw xmm, r8, imm8 |  | ")]
        pshuflw_xmm_r8_imm8 = 1167,

        /// <summary>
        /// pshufw mm, m64, imm8 |  | 
        /// </summary>
        [Symbol("pshufw mm, m64, imm8","pshufw mm, m64, imm8 |  | ")]
        pshufw_mm_m64_imm8 = 1168,

        /// <summary>
        /// pshufw mm, r8, imm8 |  | 
        /// </summary>
        [Symbol("pshufw mm, r8, imm8","pshufw mm, r8, imm8 |  | ")]
        pshufw_mm_r8_imm8 = 1169,

        /// <summary>
        /// psignb mm, m64 |  | 
        /// </summary>
        [Symbol("psignb mm, m64","psignb mm, m64 |  | ")]
        psignb_mm_m64 = 1170,

        /// <summary>
        /// psignb mm, r8 |  | 
        /// </summary>
        [Symbol("psignb mm, r8","psignb mm, r8 |  | ")]
        psignb_mm_r8 = 1171,

        /// <summary>
        /// psignb xmm, m128 |  | 
        /// </summary>
        [Symbol("psignb xmm, m128","psignb xmm, m128 |  | ")]
        psignb_xmm_m128 = 1172,

        /// <summary>
        /// psignb xmm, r8 |  | 
        /// </summary>
        [Symbol("psignb xmm, r8","psignb xmm, r8 |  | ")]
        psignb_xmm_r8 = 1173,

        /// <summary>
        /// psignd mm, m64 |  | 
        /// </summary>
        [Symbol("psignd mm, m64","psignd mm, m64 |  | ")]
        psignd_mm_m64 = 1174,

        /// <summary>
        /// psignd mm, r8 |  | 
        /// </summary>
        [Symbol("psignd mm, r8","psignd mm, r8 |  | ")]
        psignd_mm_r8 = 1175,

        /// <summary>
        /// psignd xmm, m128 |  | 
        /// </summary>
        [Symbol("psignd xmm, m128","psignd xmm, m128 |  | ")]
        psignd_xmm_m128 = 1176,

        /// <summary>
        /// psignd xmm, r8 |  | 
        /// </summary>
        [Symbol("psignd xmm, r8","psignd xmm, r8 |  | ")]
        psignd_xmm_r8 = 1177,

        /// <summary>
        /// psignw mm, m64 |  | 
        /// </summary>
        [Symbol("psignw mm, m64","psignw mm, m64 |  | ")]
        psignw_mm_m64 = 1178,

        /// <summary>
        /// psignw mm, r8 |  | 
        /// </summary>
        [Symbol("psignw mm, r8","psignw mm, r8 |  | ")]
        psignw_mm_r8 = 1179,

        /// <summary>
        /// psignw xmm, m128 |  | 
        /// </summary>
        [Symbol("psignw xmm, m128","psignw xmm, m128 |  | ")]
        psignw_xmm_m128 = 1180,

        /// <summary>
        /// psignw xmm, r8 |  | 
        /// </summary>
        [Symbol("psignw xmm, r8","psignw xmm, r8 |  | ")]
        psignw_xmm_r8 = 1181,

        /// <summary>
        /// pslld mm, imm8 |  | 
        /// </summary>
        [Symbol("pslld mm, imm8","pslld mm, imm8 |  | ")]
        pslld_mm_imm8 = 1182,

        /// <summary>
        /// pslld mm, m64 |  | 
        /// </summary>
        [Symbol("pslld mm, m64","pslld mm, m64 |  | ")]
        pslld_mm_m64 = 1183,

        /// <summary>
        /// pslld mm, r8 |  | 
        /// </summary>
        [Symbol("pslld mm, r8","pslld mm, r8 |  | ")]
        pslld_mm_r8 = 1184,

        /// <summary>
        /// pslld xmm, imm8 |  | 
        /// </summary>
        [Symbol("pslld xmm, imm8","pslld xmm, imm8 |  | ")]
        pslld_xmm_imm8 = 1185,

        /// <summary>
        /// pslld xmm, m128 |  | 
        /// </summary>
        [Symbol("pslld xmm, m128","pslld xmm, m128 |  | ")]
        pslld_xmm_m128 = 1186,

        /// <summary>
        /// pslld xmm, r8 |  | 
        /// </summary>
        [Symbol("pslld xmm, r8","pslld xmm, r8 |  | ")]
        pslld_xmm_r8 = 1187,

        /// <summary>
        /// pslldq xmm, imm8 |  | 
        /// </summary>
        [Symbol("pslldq xmm, imm8","pslldq xmm, imm8 |  | ")]
        pslldq_xmm_imm8 = 1188,

        /// <summary>
        /// psllq mm, imm8 |  | 
        /// </summary>
        [Symbol("psllq mm, imm8","psllq mm, imm8 |  | ")]
        psllq_mm_imm8 = 1189,

        /// <summary>
        /// psllq mm, m64 |  | 
        /// </summary>
        [Symbol("psllq mm, m64","psllq mm, m64 |  | ")]
        psllq_mm_m64 = 1190,

        /// <summary>
        /// psllq mm, r8 |  | 
        /// </summary>
        [Symbol("psllq mm, r8","psllq mm, r8 |  | ")]
        psllq_mm_r8 = 1191,

        /// <summary>
        /// psllq xmm, imm8 |  | 
        /// </summary>
        [Symbol("psllq xmm, imm8","psllq xmm, imm8 |  | ")]
        psllq_xmm_imm8 = 1192,

        /// <summary>
        /// psllq xmm, m128 |  | 
        /// </summary>
        [Symbol("psllq xmm, m128","psllq xmm, m128 |  | ")]
        psllq_xmm_m128 = 1193,

        /// <summary>
        /// psllq xmm, r8 |  | 
        /// </summary>
        [Symbol("psllq xmm, r8","psllq xmm, r8 |  | ")]
        psllq_xmm_r8 = 1194,

        /// <summary>
        /// psllw mm, imm8 |  | 
        /// </summary>
        [Symbol("psllw mm, imm8","psllw mm, imm8 |  | ")]
        psllw_mm_imm8 = 1195,

        /// <summary>
        /// psllw mm, m64 |  | 
        /// </summary>
        [Symbol("psllw mm, m64","psllw mm, m64 |  | ")]
        psllw_mm_m64 = 1196,

        /// <summary>
        /// psllw mm, r8 |  | 
        /// </summary>
        [Symbol("psllw mm, r8","psllw mm, r8 |  | ")]
        psllw_mm_r8 = 1197,

        /// <summary>
        /// psllw xmm, imm8 |  | 
        /// </summary>
        [Symbol("psllw xmm, imm8","psllw xmm, imm8 |  | ")]
        psllw_xmm_imm8 = 1198,

        /// <summary>
        /// psllw xmm, m128 |  | 
        /// </summary>
        [Symbol("psllw xmm, m128","psllw xmm, m128 |  | ")]
        psllw_xmm_m128 = 1199,

        /// <summary>
        /// psllw xmm, r8 |  | 
        /// </summary>
        [Symbol("psllw xmm, r8","psllw xmm, r8 |  | ")]
        psllw_xmm_r8 = 1200,

        /// <summary>
        /// psrad mm, imm8 |  | 
        /// </summary>
        [Symbol("psrad mm, imm8","psrad mm, imm8 |  | ")]
        psrad_mm_imm8 = 1201,

        /// <summary>
        /// psrad mm, m64 |  | 
        /// </summary>
        [Symbol("psrad mm, m64","psrad mm, m64 |  | ")]
        psrad_mm_m64 = 1202,

        /// <summary>
        /// psrad mm, r8 |  | 
        /// </summary>
        [Symbol("psrad mm, r8","psrad mm, r8 |  | ")]
        psrad_mm_r8 = 1203,

        /// <summary>
        /// psrad xmm, imm8 |  | 
        /// </summary>
        [Symbol("psrad xmm, imm8","psrad xmm, imm8 |  | ")]
        psrad_xmm_imm8 = 1204,

        /// <summary>
        /// psrad xmm, m128 |  | 
        /// </summary>
        [Symbol("psrad xmm, m128","psrad xmm, m128 |  | ")]
        psrad_xmm_m128 = 1205,

        /// <summary>
        /// psrad xmm, r8 |  | 
        /// </summary>
        [Symbol("psrad xmm, r8","psrad xmm, r8 |  | ")]
        psrad_xmm_r8 = 1206,

        /// <summary>
        /// psraw mm, imm8 |  | 
        /// </summary>
        [Symbol("psraw mm, imm8","psraw mm, imm8 |  | ")]
        psraw_mm_imm8 = 1207,

        /// <summary>
        /// psraw mm, m64 |  | 
        /// </summary>
        [Symbol("psraw mm, m64","psraw mm, m64 |  | ")]
        psraw_mm_m64 = 1208,

        /// <summary>
        /// psraw mm, r8 |  | 
        /// </summary>
        [Symbol("psraw mm, r8","psraw mm, r8 |  | ")]
        psraw_mm_r8 = 1209,

        /// <summary>
        /// psraw xmm, imm8 |  | 
        /// </summary>
        [Symbol("psraw xmm, imm8","psraw xmm, imm8 |  | ")]
        psraw_xmm_imm8 = 1210,

        /// <summary>
        /// psraw xmm, m128 |  | 
        /// </summary>
        [Symbol("psraw xmm, m128","psraw xmm, m128 |  | ")]
        psraw_xmm_m128 = 1211,

        /// <summary>
        /// psraw xmm, r8 |  | 
        /// </summary>
        [Symbol("psraw xmm, r8","psraw xmm, r8 |  | ")]
        psraw_xmm_r8 = 1212,

        /// <summary>
        /// psrld mm, imm8 |  | 
        /// </summary>
        [Symbol("psrld mm, imm8","psrld mm, imm8 |  | ")]
        psrld_mm_imm8 = 1213,

        /// <summary>
        /// psrld mm, m64 |  | 
        /// </summary>
        [Symbol("psrld mm, m64","psrld mm, m64 |  | ")]
        psrld_mm_m64 = 1214,

        /// <summary>
        /// psrld mm, r8 |  | 
        /// </summary>
        [Symbol("psrld mm, r8","psrld mm, r8 |  | ")]
        psrld_mm_r8 = 1215,

        /// <summary>
        /// psrld xmm, imm8 |  | 
        /// </summary>
        [Symbol("psrld xmm, imm8","psrld xmm, imm8 |  | ")]
        psrld_xmm_imm8 = 1216,

        /// <summary>
        /// psrld xmm, m128 |  | 
        /// </summary>
        [Symbol("psrld xmm, m128","psrld xmm, m128 |  | ")]
        psrld_xmm_m128 = 1217,

        /// <summary>
        /// psrld xmm, r8 |  | 
        /// </summary>
        [Symbol("psrld xmm, r8","psrld xmm, r8 |  | ")]
        psrld_xmm_r8 = 1218,

        /// <summary>
        /// psrlq mm, imm8 |  | 
        /// </summary>
        [Symbol("psrlq mm, imm8","psrlq mm, imm8 |  | ")]
        psrlq_mm_imm8 = 1219,

        /// <summary>
        /// psrlq mm, m64 |  | 
        /// </summary>
        [Symbol("psrlq mm, m64","psrlq mm, m64 |  | ")]
        psrlq_mm_m64 = 1220,

        /// <summary>
        /// psrlq mm, r8 |  | 
        /// </summary>
        [Symbol("psrlq mm, r8","psrlq mm, r8 |  | ")]
        psrlq_mm_r8 = 1221,

        /// <summary>
        /// psrlq xmm, imm8 |  | 
        /// </summary>
        [Symbol("psrlq xmm, imm8","psrlq xmm, imm8 |  | ")]
        psrlq_xmm_imm8 = 1222,

        /// <summary>
        /// psrlq xmm, m128 |  | 
        /// </summary>
        [Symbol("psrlq xmm, m128","psrlq xmm, m128 |  | ")]
        psrlq_xmm_m128 = 1223,

        /// <summary>
        /// psrlq xmm, r8 |  | 
        /// </summary>
        [Symbol("psrlq xmm, r8","psrlq xmm, r8 |  | ")]
        psrlq_xmm_r8 = 1224,

        /// <summary>
        /// psrlw mm, imm8 |  | 
        /// </summary>
        [Symbol("psrlw mm, imm8","psrlw mm, imm8 |  | ")]
        psrlw_mm_imm8 = 1225,

        /// <summary>
        /// psrlw mm, m64 |  | 
        /// </summary>
        [Symbol("psrlw mm, m64","psrlw mm, m64 |  | ")]
        psrlw_mm_m64 = 1226,

        /// <summary>
        /// psrlw mm, r8 |  | 
        /// </summary>
        [Symbol("psrlw mm, r8","psrlw mm, r8 |  | ")]
        psrlw_mm_r8 = 1227,

        /// <summary>
        /// psrlw xmm, imm8 |  | 
        /// </summary>
        [Symbol("psrlw xmm, imm8","psrlw xmm, imm8 |  | ")]
        psrlw_xmm_imm8 = 1228,

        /// <summary>
        /// psrlw xmm, m128 |  | 
        /// </summary>
        [Symbol("psrlw xmm, m128","psrlw xmm, m128 |  | ")]
        psrlw_xmm_m128 = 1229,

        /// <summary>
        /// psrlw xmm, r8 |  | 
        /// </summary>
        [Symbol("psrlw xmm, r8","psrlw xmm, r8 |  | ")]
        psrlw_xmm_r8 = 1230,

        /// <summary>
        /// psubb mm, m64 |  | 
        /// </summary>
        [Symbol("psubb mm, m64","psubb mm, m64 |  | ")]
        psubb_mm_m64 = 1231,

        /// <summary>
        /// psubb mm, r8 |  | 
        /// </summary>
        [Symbol("psubb mm, r8","psubb mm, r8 |  | ")]
        psubb_mm_r8 = 1232,

        /// <summary>
        /// psubb xmm, m128 |  | 
        /// </summary>
        [Symbol("psubb xmm, m128","psubb xmm, m128 |  | ")]
        psubb_xmm_m128 = 1233,

        /// <summary>
        /// psubb xmm, r8 |  | 
        /// </summary>
        [Symbol("psubb xmm, r8","psubb xmm, r8 |  | ")]
        psubb_xmm_r8 = 1234,

        /// <summary>
        /// psubd mm, m64 |  | 
        /// </summary>
        [Symbol("psubd mm, m64","psubd mm, m64 |  | ")]
        psubd_mm_m64 = 1235,

        /// <summary>
        /// psubd mm, r8 |  | 
        /// </summary>
        [Symbol("psubd mm, r8","psubd mm, r8 |  | ")]
        psubd_mm_r8 = 1236,

        /// <summary>
        /// psubd xmm, m128 |  | 
        /// </summary>
        [Symbol("psubd xmm, m128","psubd xmm, m128 |  | ")]
        psubd_xmm_m128 = 1237,

        /// <summary>
        /// psubd xmm, r8 |  | 
        /// </summary>
        [Symbol("psubd xmm, r8","psubd xmm, r8 |  | ")]
        psubd_xmm_r8 = 1238,

        /// <summary>
        /// psubq mm, m64 |  | 
        /// </summary>
        [Symbol("psubq mm, m64","psubq mm, m64 |  | ")]
        psubq_mm_m64 = 1239,

        /// <summary>
        /// psubq mm, r8 |  | 
        /// </summary>
        [Symbol("psubq mm, r8","psubq mm, r8 |  | ")]
        psubq_mm_r8 = 1240,

        /// <summary>
        /// psubq xmm, m128 |  | 
        /// </summary>
        [Symbol("psubq xmm, m128","psubq xmm, m128 |  | ")]
        psubq_xmm_m128 = 1241,

        /// <summary>
        /// psubq xmm, r8 |  | 
        /// </summary>
        [Symbol("psubq xmm, r8","psubq xmm, r8 |  | ")]
        psubq_xmm_r8 = 1242,

        /// <summary>
        /// psubsb mm, m64 |  | 
        /// </summary>
        [Symbol("psubsb mm, m64","psubsb mm, m64 |  | ")]
        psubsb_mm_m64 = 1243,

        /// <summary>
        /// psubsb mm, r8 |  | 
        /// </summary>
        [Symbol("psubsb mm, r8","psubsb mm, r8 |  | ")]
        psubsb_mm_r8 = 1244,

        /// <summary>
        /// psubsb xmm, m128 |  | 
        /// </summary>
        [Symbol("psubsb xmm, m128","psubsb xmm, m128 |  | ")]
        psubsb_xmm_m128 = 1245,

        /// <summary>
        /// psubsb xmm, r8 |  | 
        /// </summary>
        [Symbol("psubsb xmm, r8","psubsb xmm, r8 |  | ")]
        psubsb_xmm_r8 = 1246,

        /// <summary>
        /// psubsw mm, m64 |  | 
        /// </summary>
        [Symbol("psubsw mm, m64","psubsw mm, m64 |  | ")]
        psubsw_mm_m64 = 1247,

        /// <summary>
        /// psubsw mm, r8 |  | 
        /// </summary>
        [Symbol("psubsw mm, r8","psubsw mm, r8 |  | ")]
        psubsw_mm_r8 = 1248,

        /// <summary>
        /// psubsw xmm, m128 |  | 
        /// </summary>
        [Symbol("psubsw xmm, m128","psubsw xmm, m128 |  | ")]
        psubsw_xmm_m128 = 1249,

        /// <summary>
        /// psubsw xmm, r8 |  | 
        /// </summary>
        [Symbol("psubsw xmm, r8","psubsw xmm, r8 |  | ")]
        psubsw_xmm_r8 = 1250,

        /// <summary>
        /// psubusb mm, m64 |  | 
        /// </summary>
        [Symbol("psubusb mm, m64","psubusb mm, m64 |  | ")]
        psubusb_mm_m64 = 1251,

        /// <summary>
        /// psubusb mm, r8 |  | 
        /// </summary>
        [Symbol("psubusb mm, r8","psubusb mm, r8 |  | ")]
        psubusb_mm_r8 = 1252,

        /// <summary>
        /// psubusb xmm, m128 |  | 
        /// </summary>
        [Symbol("psubusb xmm, m128","psubusb xmm, m128 |  | ")]
        psubusb_xmm_m128 = 1253,

        /// <summary>
        /// psubusb xmm, r8 |  | 
        /// </summary>
        [Symbol("psubusb xmm, r8","psubusb xmm, r8 |  | ")]
        psubusb_xmm_r8 = 1254,

        /// <summary>
        /// psubusw mm, m64 |  | 
        /// </summary>
        [Symbol("psubusw mm, m64","psubusw mm, m64 |  | ")]
        psubusw_mm_m64 = 1255,

        /// <summary>
        /// psubusw mm, r8 |  | 
        /// </summary>
        [Symbol("psubusw mm, r8","psubusw mm, r8 |  | ")]
        psubusw_mm_r8 = 1256,

        /// <summary>
        /// psubusw xmm, m128 |  | 
        /// </summary>
        [Symbol("psubusw xmm, m128","psubusw xmm, m128 |  | ")]
        psubusw_xmm_m128 = 1257,

        /// <summary>
        /// psubusw xmm, r8 |  | 
        /// </summary>
        [Symbol("psubusw xmm, r8","psubusw xmm, r8 |  | ")]
        psubusw_xmm_r8 = 1258,

        /// <summary>
        /// psubw mm, m64 |  | 
        /// </summary>
        [Symbol("psubw mm, m64","psubw mm, m64 |  | ")]
        psubw_mm_m64 = 1259,

        /// <summary>
        /// psubw mm, r8 |  | 
        /// </summary>
        [Symbol("psubw mm, r8","psubw mm, r8 |  | ")]
        psubw_mm_r8 = 1260,

        /// <summary>
        /// psubw xmm, m128 |  | 
        /// </summary>
        [Symbol("psubw xmm, m128","psubw xmm, m128 |  | ")]
        psubw_xmm_m128 = 1261,

        /// <summary>
        /// psubw xmm, r8 |  | 
        /// </summary>
        [Symbol("psubw xmm, r8","psubw xmm, r8 |  | ")]
        psubw_xmm_r8 = 1262,

        /// <summary>
        /// ptest xmm, m128 |  | 
        /// </summary>
        [Symbol("ptest xmm, m128","ptest xmm, m128 |  | ")]
        ptest_xmm_m128 = 1263,

        /// <summary>
        /// ptest xmm, r8 |  | 
        /// </summary>
        [Symbol("ptest xmm, r8","ptest xmm, r8 |  | ")]
        ptest_xmm_r8 = 1264,

        /// <summary>
        /// punpckhbw mm, m64 |  | 
        /// </summary>
        [Symbol("punpckhbw mm, m64","punpckhbw mm, m64 |  | ")]
        punpckhbw_mm_m64 = 1265,

        /// <summary>
        /// punpckhbw mm, r8 |  | 
        /// </summary>
        [Symbol("punpckhbw mm, r8","punpckhbw mm, r8 |  | ")]
        punpckhbw_mm_r8 = 1266,

        /// <summary>
        /// punpckhbw xmm, m128 |  | 
        /// </summary>
        [Symbol("punpckhbw xmm, m128","punpckhbw xmm, m128 |  | ")]
        punpckhbw_xmm_m128 = 1267,

        /// <summary>
        /// punpckhbw xmm, r8 |  | 
        /// </summary>
        [Symbol("punpckhbw xmm, r8","punpckhbw xmm, r8 |  | ")]
        punpckhbw_xmm_r8 = 1268,

        /// <summary>
        /// punpckhdq mm, m64 |  | 
        /// </summary>
        [Symbol("punpckhdq mm, m64","punpckhdq mm, m64 |  | ")]
        punpckhdq_mm_m64 = 1269,

        /// <summary>
        /// punpckhdq mm, r8 |  | 
        /// </summary>
        [Symbol("punpckhdq mm, r8","punpckhdq mm, r8 |  | ")]
        punpckhdq_mm_r8 = 1270,

        /// <summary>
        /// punpckhdq xmm, m128 |  | 
        /// </summary>
        [Symbol("punpckhdq xmm, m128","punpckhdq xmm, m128 |  | ")]
        punpckhdq_xmm_m128 = 1271,

        /// <summary>
        /// punpckhdq xmm, r8 |  | 
        /// </summary>
        [Symbol("punpckhdq xmm, r8","punpckhdq xmm, r8 |  | ")]
        punpckhdq_xmm_r8 = 1272,

        /// <summary>
        /// punpckhqdq xmm, m128 |  | 
        /// </summary>
        [Symbol("punpckhqdq xmm, m128","punpckhqdq xmm, m128 |  | ")]
        punpckhqdq_xmm_m128 = 1273,

        /// <summary>
        /// punpckhqdq xmm, r8 |  | 
        /// </summary>
        [Symbol("punpckhqdq xmm, r8","punpckhqdq xmm, r8 |  | ")]
        punpckhqdq_xmm_r8 = 1274,

        /// <summary>
        /// punpckhwd mm, m64 |  | 
        /// </summary>
        [Symbol("punpckhwd mm, m64","punpckhwd mm, m64 |  | ")]
        punpckhwd_mm_m64 = 1275,

        /// <summary>
        /// punpckhwd mm, r8 |  | 
        /// </summary>
        [Symbol("punpckhwd mm, r8","punpckhwd mm, r8 |  | ")]
        punpckhwd_mm_r8 = 1276,

        /// <summary>
        /// punpckhwd xmm, m128 |  | 
        /// </summary>
        [Symbol("punpckhwd xmm, m128","punpckhwd xmm, m128 |  | ")]
        punpckhwd_xmm_m128 = 1277,

        /// <summary>
        /// punpckhwd xmm, r8 |  | 
        /// </summary>
        [Symbol("punpckhwd xmm, r8","punpckhwd xmm, r8 |  | ")]
        punpckhwd_xmm_r8 = 1278,

        /// <summary>
        /// punpckldq mm, m32 |  | 
        /// </summary>
        [Symbol("punpckldq mm, m32","punpckldq mm, m32 |  | ")]
        punpckldq_mm_m32 = 1279,

        /// <summary>
        /// punpckldq mm, r8 |  | 
        /// </summary>
        [Symbol("punpckldq mm, r8","punpckldq mm, r8 |  | ")]
        punpckldq_mm_r8 = 1280,

        /// <summary>
        /// punpckldq xmm, m128 |  | 
        /// </summary>
        [Symbol("punpckldq xmm, m128","punpckldq xmm, m128 |  | ")]
        punpckldq_xmm_m128 = 1281,

        /// <summary>
        /// punpckldq xmm, r8 |  | 
        /// </summary>
        [Symbol("punpckldq xmm, r8","punpckldq xmm, r8 |  | ")]
        punpckldq_xmm_r8 = 1282,

        /// <summary>
        /// punpcklqdq xmm, m128 |  | 
        /// </summary>
        [Symbol("punpcklqdq xmm, m128","punpcklqdq xmm, m128 |  | ")]
        punpcklqdq_xmm_m128 = 1283,

        /// <summary>
        /// punpcklqdq xmm, r8 |  | 
        /// </summary>
        [Symbol("punpcklqdq xmm, r8","punpcklqdq xmm, r8 |  | ")]
        punpcklqdq_xmm_r8 = 1284,

        /// <summary>
        /// push CS |  | 
        /// </summary>
        [Symbol("push CS","push CS |  | ")]
        push_CS = 1285,

        /// <summary>
        /// push DS |  | 
        /// </summary>
        [Symbol("push DS","push DS |  | ")]
        push_DS = 1286,

        /// <summary>
        /// push ES |  | 
        /// </summary>
        [Symbol("push ES","push ES |  | ")]
        push_ES = 1287,

        /// <summary>
        /// push FS |  | 
        /// </summary>
        [Symbol("push FS","push FS |  | ")]
        push_FS = 1288,

        /// <summary>
        /// push GS |  | 
        /// </summary>
        [Symbol("push GS","push GS |  | ")]
        push_GS = 1289,

        /// <summary>
        /// push imm16 |  | 
        /// </summary>
        [Symbol("push imm16","push imm16 |  | ")]
        push_imm16 = 1290,

        /// <summary>
        /// push imm32 |  | 
        /// </summary>
        [Symbol("push imm32","push imm32 |  | ")]
        push_imm32 = 1291,

        /// <summary>
        /// push imm8 |  | 
        /// </summary>
        [Symbol("push imm8","push imm8 |  | ")]
        push_imm8 = 1292,

        /// <summary>
        /// push m16 |  | 
        /// </summary>
        [Symbol("push m16","push m16 |  | ")]
        push_m16 = 1293,

        /// <summary>
        /// push m32 |  | 
        /// </summary>
        [Symbol("push m32","push m32 |  | ")]
        push_m32 = 1294,

        /// <summary>
        /// push m64 |  | 
        /// </summary>
        [Symbol("push m64","push m64 |  | ")]
        push_m64 = 1295,

        /// <summary>
        /// push r16 |  | 
        /// </summary>
        [Symbol("push r16","push r16 |  | ")]
        push_r16 = 1296,

        /// <summary>
        /// push r32 |  | 
        /// </summary>
        [Symbol("push r32","push r32 |  | ")]
        push_r32 = 1297,

        /// <summary>
        /// push r64 |  | 
        /// </summary>
        [Symbol("push r64","push r64 |  | ")]
        push_r64 = 1298,

        /// <summary>
        /// push SS |  | 
        /// </summary>
        [Symbol("push SS","push SS |  | ")]
        push_SS = 1299,

        /// <summary>
        /// pushf |  | 
        /// </summary>
        [Symbol("pushf","pushf |  | ")]
        pushf = 1300,

        /// <summary>
        /// pushfd |  | 
        /// </summary>
        [Symbol("pushfd","pushfd |  | ")]
        pushfd = 1301,

        /// <summary>
        /// pushfq |  | 
        /// </summary>
        [Symbol("pushfq","pushfq |  | ")]
        pushfq = 1302,

        /// <summary>
        /// pxor mm, m64 |  | 
        /// </summary>
        [Symbol("pxor mm, m64","pxor mm, m64 |  | ")]
        pxor_mm_m64 = 1303,

        /// <summary>
        /// pxor mm, r8 |  | 
        /// </summary>
        [Symbol("pxor mm, r8","pxor mm, r8 |  | ")]
        pxor_mm_r8 = 1304,

        /// <summary>
        /// pxor xmm, m128 |  | 
        /// </summary>
        [Symbol("pxor xmm, m128","pxor xmm, m128 |  | ")]
        pxor_xmm_m128 = 1305,

        /// <summary>
        /// pxor xmm, r8 |  | 
        /// </summary>
        [Symbol("pxor xmm, r8","pxor xmm, r8 |  | ")]
        pxor_xmm_r8 = 1306,

        /// <summary>
        /// rcl m16, CL |  | 
        /// </summary>
        [Symbol("rcl m16, CL","rcl m16, CL |  | ")]
        rcl_m16_CL = 1307,

        /// <summary>
        /// rcl m16, imm8 |  | 
        /// </summary>
        [Symbol("rcl m16, imm8","rcl m16, imm8 |  | ")]
        rcl_m16_imm8 = 1308,

        /// <summary>
        /// rcl m16, 1 |  | 
        /// </summary>
        [Symbol("rcl m16, 1","rcl m16, 1 |  | ")]
        rcl_m16_n1 = 1309,

        /// <summary>
        /// rcl m32, CL |  | 
        /// </summary>
        [Symbol("rcl m32, CL","rcl m32, CL |  | ")]
        rcl_m32_CL = 1310,

        /// <summary>
        /// rcl m32, imm8 |  | 
        /// </summary>
        [Symbol("rcl m32, imm8","rcl m32, imm8 |  | ")]
        rcl_m32_imm8 = 1311,

        /// <summary>
        /// rcl m32, 1 |  | 
        /// </summary>
        [Symbol("rcl m32, 1","rcl m32, 1 |  | ")]
        rcl_m32_n1 = 1312,

        /// <summary>
        /// rcl m64, CL |  | 
        /// </summary>
        [Symbol("rcl m64, CL","rcl m64, CL |  | ")]
        rcl_m64_CL = 1313,

        /// <summary>
        /// rcl m64, imm8 |  | 
        /// </summary>
        [Symbol("rcl m64, imm8","rcl m64, imm8 |  | ")]
        rcl_m64_imm8 = 1314,

        /// <summary>
        /// rcl m64, 1 |  | 
        /// </summary>
        [Symbol("rcl m64, 1","rcl m64, 1 |  | ")]
        rcl_m64_n1 = 1315,

        /// <summary>
        /// rcl m8, CL |  | 
        /// </summary>
        [Symbol("rcl m8, CL","rcl m8, CL |  | ")]
        rcl_m8_CL = 1316,

        /// <summary>
        /// rcl m8, imm8 |  | 
        /// </summary>
        [Symbol("rcl m8, imm8","rcl m8, imm8 |  | ")]
        rcl_m8_imm8 = 1317,

        /// <summary>
        /// rcl m8, 1 |  | 
        /// </summary>
        [Symbol("rcl m8, 1","rcl m8, 1 |  | ")]
        rcl_m8_n1 = 1318,

        /// <summary>
        /// rcl r16, CL |  | 
        /// </summary>
        [Symbol("rcl r16, CL","rcl r16, CL |  | ")]
        rcl_r16_CL = 1319,

        /// <summary>
        /// rcl r16, imm8 |  | 
        /// </summary>
        [Symbol("rcl r16, imm8","rcl r16, imm8 |  | ")]
        rcl_r16_imm8 = 1320,

        /// <summary>
        /// rcl r16, 1 |  | 
        /// </summary>
        [Symbol("rcl r16, 1","rcl r16, 1 |  | ")]
        rcl_r16_n1 = 1321,

        /// <summary>
        /// rcl r32, CL |  | 
        /// </summary>
        [Symbol("rcl r32, CL","rcl r32, CL |  | ")]
        rcl_r32_CL = 1322,

        /// <summary>
        /// rcl r32, imm8 |  | 
        /// </summary>
        [Symbol("rcl r32, imm8","rcl r32, imm8 |  | ")]
        rcl_r32_imm8 = 1323,

        /// <summary>
        /// rcl r32, 1 |  | 
        /// </summary>
        [Symbol("rcl r32, 1","rcl r32, 1 |  | ")]
        rcl_r32_n1 = 1324,

        /// <summary>
        /// rcl r64, CL |  | 
        /// </summary>
        [Symbol("rcl r64, CL","rcl r64, CL |  | ")]
        rcl_r64_CL = 1325,

        /// <summary>
        /// rcl r64, imm8 |  | 
        /// </summary>
        [Symbol("rcl r64, imm8","rcl r64, imm8 |  | ")]
        rcl_r64_imm8 = 1326,

        /// <summary>
        /// rcl r64, 1 |  | 
        /// </summary>
        [Symbol("rcl r64, 1","rcl r64, 1 |  | ")]
        rcl_r64_n1 = 1327,

        /// <summary>
        /// rcl r8, CL |  | 
        /// </summary>
        [Symbol("rcl r8, CL","rcl r8, CL |  | ")]
        rcl_r8_CL = 1328,

        /// <summary>
        /// rcl r8, imm8 |  | 
        /// </summary>
        [Symbol("rcl r8, imm8","rcl r8, imm8 |  | ")]
        rcl_r8_imm8 = 1329,

        /// <summary>
        /// rcl r8, 1 |  | 
        /// </summary>
        [Symbol("rcl r8, 1","rcl r8, 1 |  | ")]
        rcl_r8_n1 = 1330,

        /// <summary>
        /// rcr m16, CL |  | 
        /// </summary>
        [Symbol("rcr m16, CL","rcr m16, CL |  | ")]
        rcr_m16_CL = 1331,

        /// <summary>
        /// rcr m16, imm8 |  | 
        /// </summary>
        [Symbol("rcr m16, imm8","rcr m16, imm8 |  | ")]
        rcr_m16_imm8 = 1332,

        /// <summary>
        /// rcr m16, 1 |  | 
        /// </summary>
        [Symbol("rcr m16, 1","rcr m16, 1 |  | ")]
        rcr_m16_n1 = 1333,

        /// <summary>
        /// rcr m32, CL |  | 
        /// </summary>
        [Symbol("rcr m32, CL","rcr m32, CL |  | ")]
        rcr_m32_CL = 1334,

        /// <summary>
        /// rcr m32, imm8 |  | 
        /// </summary>
        [Symbol("rcr m32, imm8","rcr m32, imm8 |  | ")]
        rcr_m32_imm8 = 1335,

        /// <summary>
        /// rcr m32, 1 |  | 
        /// </summary>
        [Symbol("rcr m32, 1","rcr m32, 1 |  | ")]
        rcr_m32_n1 = 1336,

        /// <summary>
        /// rcr m64, CL |  | 
        /// </summary>
        [Symbol("rcr m64, CL","rcr m64, CL |  | ")]
        rcr_m64_CL = 1337,

        /// <summary>
        /// rcr m64, imm8 |  | 
        /// </summary>
        [Symbol("rcr m64, imm8","rcr m64, imm8 |  | ")]
        rcr_m64_imm8 = 1338,

        /// <summary>
        /// rcr m64, 1 |  | 
        /// </summary>
        [Symbol("rcr m64, 1","rcr m64, 1 |  | ")]
        rcr_m64_n1 = 1339,

        /// <summary>
        /// rcr m8, CL |  | 
        /// </summary>
        [Symbol("rcr m8, CL","rcr m8, CL |  | ")]
        rcr_m8_CL = 1340,

        /// <summary>
        /// rcr m8, imm8 |  | 
        /// </summary>
        [Symbol("rcr m8, imm8","rcr m8, imm8 |  | ")]
        rcr_m8_imm8 = 1341,

        /// <summary>
        /// rcr m8, 1 |  | 
        /// </summary>
        [Symbol("rcr m8, 1","rcr m8, 1 |  | ")]
        rcr_m8_n1 = 1342,

        /// <summary>
        /// rcr r16, CL |  | 
        /// </summary>
        [Symbol("rcr r16, CL","rcr r16, CL |  | ")]
        rcr_r16_CL = 1343,

        /// <summary>
        /// rcr r16, imm8 |  | 
        /// </summary>
        [Symbol("rcr r16, imm8","rcr r16, imm8 |  | ")]
        rcr_r16_imm8 = 1344,

        /// <summary>
        /// rcr r16, 1 |  | 
        /// </summary>
        [Symbol("rcr r16, 1","rcr r16, 1 |  | ")]
        rcr_r16_n1 = 1345,

        /// <summary>
        /// rcr r32, CL |  | 
        /// </summary>
        [Symbol("rcr r32, CL","rcr r32, CL |  | ")]
        rcr_r32_CL = 1346,

        /// <summary>
        /// rcr r32, imm8 |  | 
        /// </summary>
        [Symbol("rcr r32, imm8","rcr r32, imm8 |  | ")]
        rcr_r32_imm8 = 1347,

        /// <summary>
        /// rcr r32, 1 |  | 
        /// </summary>
        [Symbol("rcr r32, 1","rcr r32, 1 |  | ")]
        rcr_r32_n1 = 1348,

        /// <summary>
        /// rcr r64, CL |  | 
        /// </summary>
        [Symbol("rcr r64, CL","rcr r64, CL |  | ")]
        rcr_r64_CL = 1349,

        /// <summary>
        /// rcr r64, imm8 |  | 
        /// </summary>
        [Symbol("rcr r64, imm8","rcr r64, imm8 |  | ")]
        rcr_r64_imm8 = 1350,

        /// <summary>
        /// rcr r64, 1 |  | 
        /// </summary>
        [Symbol("rcr r64, 1","rcr r64, 1 |  | ")]
        rcr_r64_n1 = 1351,

        /// <summary>
        /// rcr r8, CL |  | 
        /// </summary>
        [Symbol("rcr r8, CL","rcr r8, CL |  | ")]
        rcr_r8_CL = 1352,

        /// <summary>
        /// rcr r8, imm8 |  | 
        /// </summary>
        [Symbol("rcr r8, imm8","rcr r8, imm8 |  | ")]
        rcr_r8_imm8 = 1353,

        /// <summary>
        /// rcr r8, 1 |  | 
        /// </summary>
        [Symbol("rcr r8, 1","rcr r8, 1 |  | ")]
        rcr_r8_n1 = 1354,

        /// <summary>
        /// rdfsbase r32 |  | 
        /// </summary>
        [Symbol("rdfsbase r32","rdfsbase r32 |  | ")]
        rdfsbase_r32 = 1355,

        /// <summary>
        /// rdfsbase r64 |  | 
        /// </summary>
        [Symbol("rdfsbase r64","rdfsbase r64 |  | ")]
        rdfsbase_r64 = 1356,

        /// <summary>
        /// rdgsbase r32 |  | 
        /// </summary>
        [Symbol("rdgsbase r32","rdgsbase r32 |  | ")]
        rdgsbase_r32 = 1357,

        /// <summary>
        /// rdgsbase r64 |  | 
        /// </summary>
        [Symbol("rdgsbase r64","rdgsbase r64 |  | ")]
        rdgsbase_r64 = 1358,

        /// <summary>
        /// rdtsc |  | 
        /// </summary>
        [Symbol("rdtsc","rdtsc |  | ")]
        rdtsc = 1359,

        /// <summary>
        /// rol m16, CL |  | 
        /// </summary>
        [Symbol("rol m16, CL","rol m16, CL |  | ")]
        rol_m16_CL = 1360,

        /// <summary>
        /// rol m16, imm8 |  | 
        /// </summary>
        [Symbol("rol m16, imm8","rol m16, imm8 |  | ")]
        rol_m16_imm8 = 1361,

        /// <summary>
        /// rol m16, 1 |  | 
        /// </summary>
        [Symbol("rol m16, 1","rol m16, 1 |  | ")]
        rol_m16_n1 = 1362,

        /// <summary>
        /// rol m32, CL |  | 
        /// </summary>
        [Symbol("rol m32, CL","rol m32, CL |  | ")]
        rol_m32_CL = 1363,

        /// <summary>
        /// rol m32, imm8 |  | 
        /// </summary>
        [Symbol("rol m32, imm8","rol m32, imm8 |  | ")]
        rol_m32_imm8 = 1364,

        /// <summary>
        /// rol m32, 1 |  | 
        /// </summary>
        [Symbol("rol m32, 1","rol m32, 1 |  | ")]
        rol_m32_n1 = 1365,

        /// <summary>
        /// rol m64, CL |  | 
        /// </summary>
        [Symbol("rol m64, CL","rol m64, CL |  | ")]
        rol_m64_CL = 1366,

        /// <summary>
        /// rol m64, imm8 |  | 
        /// </summary>
        [Symbol("rol m64, imm8","rol m64, imm8 |  | ")]
        rol_m64_imm8 = 1367,

        /// <summary>
        /// rol m64, 1 |  | 
        /// </summary>
        [Symbol("rol m64, 1","rol m64, 1 |  | ")]
        rol_m64_n1 = 1368,

        /// <summary>
        /// rol m8, CL |  | 
        /// </summary>
        [Symbol("rol m8, CL","rol m8, CL |  | ")]
        rol_m8_CL = 1369,

        /// <summary>
        /// rol m8, imm8 |  | 
        /// </summary>
        [Symbol("rol m8, imm8","rol m8, imm8 |  | ")]
        rol_m8_imm8 = 1370,

        /// <summary>
        /// rol m8, 1 |  | 
        /// </summary>
        [Symbol("rol m8, 1","rol m8, 1 |  | ")]
        rol_m8_n1 = 1371,

        /// <summary>
        /// rol r16, CL |  | 
        /// </summary>
        [Symbol("rol r16, CL","rol r16, CL |  | ")]
        rol_r16_CL = 1372,

        /// <summary>
        /// rol r16, imm8 |  | 
        /// </summary>
        [Symbol("rol r16, imm8","rol r16, imm8 |  | ")]
        rol_r16_imm8 = 1373,

        /// <summary>
        /// rol r16, 1 |  | 
        /// </summary>
        [Symbol("rol r16, 1","rol r16, 1 |  | ")]
        rol_r16_n1 = 1374,

        /// <summary>
        /// rol r32, CL |  | 
        /// </summary>
        [Symbol("rol r32, CL","rol r32, CL |  | ")]
        rol_r32_CL = 1375,

        /// <summary>
        /// rol r32, imm8 |  | 
        /// </summary>
        [Symbol("rol r32, imm8","rol r32, imm8 |  | ")]
        rol_r32_imm8 = 1376,

        /// <summary>
        /// rol r32, 1 |  | 
        /// </summary>
        [Symbol("rol r32, 1","rol r32, 1 |  | ")]
        rol_r32_n1 = 1377,

        /// <summary>
        /// rol r64, CL |  | 
        /// </summary>
        [Symbol("rol r64, CL","rol r64, CL |  | ")]
        rol_r64_CL = 1378,

        /// <summary>
        /// rol r64, imm8 |  | 
        /// </summary>
        [Symbol("rol r64, imm8","rol r64, imm8 |  | ")]
        rol_r64_imm8 = 1379,

        /// <summary>
        /// rol r64, 1 |  | 
        /// </summary>
        [Symbol("rol r64, 1","rol r64, 1 |  | ")]
        rol_r64_n1 = 1380,

        /// <summary>
        /// rol r8, CL |  | 
        /// </summary>
        [Symbol("rol r8, CL","rol r8, CL |  | ")]
        rol_r8_CL = 1381,

        /// <summary>
        /// rol r8, imm8 |  | 
        /// </summary>
        [Symbol("rol r8, imm8","rol r8, imm8 |  | ")]
        rol_r8_imm8 = 1382,

        /// <summary>
        /// rol r8, 1 |  | 
        /// </summary>
        [Symbol("rol r8, 1","rol r8, 1 |  | ")]
        rol_r8_n1 = 1383,

        /// <summary>
        /// ror m16, CL |  | 
        /// </summary>
        [Symbol("ror m16, CL","ror m16, CL |  | ")]
        ror_m16_CL = 1384,

        /// <summary>
        /// ror m16, imm8 |  | 
        /// </summary>
        [Symbol("ror m16, imm8","ror m16, imm8 |  | ")]
        ror_m16_imm8 = 1385,

        /// <summary>
        /// ror m16, 1 |  | 
        /// </summary>
        [Symbol("ror m16, 1","ror m16, 1 |  | ")]
        ror_m16_n1 = 1386,

        /// <summary>
        /// ror m32, CL |  | 
        /// </summary>
        [Symbol("ror m32, CL","ror m32, CL |  | ")]
        ror_m32_CL = 1387,

        /// <summary>
        /// ror m32, imm8 |  | 
        /// </summary>
        [Symbol("ror m32, imm8","ror m32, imm8 |  | ")]
        ror_m32_imm8 = 1388,

        /// <summary>
        /// ror m32, 1 |  | 
        /// </summary>
        [Symbol("ror m32, 1","ror m32, 1 |  | ")]
        ror_m32_n1 = 1389,

        /// <summary>
        /// ror m64, CL |  | 
        /// </summary>
        [Symbol("ror m64, CL","ror m64, CL |  | ")]
        ror_m64_CL = 1390,

        /// <summary>
        /// ror m64, imm8 |  | 
        /// </summary>
        [Symbol("ror m64, imm8","ror m64, imm8 |  | ")]
        ror_m64_imm8 = 1391,

        /// <summary>
        /// ror m64, 1 |  | 
        /// </summary>
        [Symbol("ror m64, 1","ror m64, 1 |  | ")]
        ror_m64_n1 = 1392,

        /// <summary>
        /// ror m8, CL |  | 
        /// </summary>
        [Symbol("ror m8, CL","ror m8, CL |  | ")]
        ror_m8_CL = 1393,

        /// <summary>
        /// ror m8, imm8 |  | 
        /// </summary>
        [Symbol("ror m8, imm8","ror m8, imm8 |  | ")]
        ror_m8_imm8 = 1394,

        /// <summary>
        /// ror m8, 1 |  | 
        /// </summary>
        [Symbol("ror m8, 1","ror m8, 1 |  | ")]
        ror_m8_n1 = 1395,

        /// <summary>
        /// ror r16, CL |  | 
        /// </summary>
        [Symbol("ror r16, CL","ror r16, CL |  | ")]
        ror_r16_CL = 1396,

        /// <summary>
        /// ror r16, imm8 |  | 
        /// </summary>
        [Symbol("ror r16, imm8","ror r16, imm8 |  | ")]
        ror_r16_imm8 = 1397,

        /// <summary>
        /// ror r16, 1 |  | 
        /// </summary>
        [Symbol("ror r16, 1","ror r16, 1 |  | ")]
        ror_r16_n1 = 1398,

        /// <summary>
        /// ror r32, CL |  | 
        /// </summary>
        [Symbol("ror r32, CL","ror r32, CL |  | ")]
        ror_r32_CL = 1399,

        /// <summary>
        /// ror r32, imm8 |  | 
        /// </summary>
        [Symbol("ror r32, imm8","ror r32, imm8 |  | ")]
        ror_r32_imm8 = 1400,

        /// <summary>
        /// ror r32, 1 |  | 
        /// </summary>
        [Symbol("ror r32, 1","ror r32, 1 |  | ")]
        ror_r32_n1 = 1401,

        /// <summary>
        /// ror r64, CL |  | 
        /// </summary>
        [Symbol("ror r64, CL","ror r64, CL |  | ")]
        ror_r64_CL = 1402,

        /// <summary>
        /// ror r64, imm8 |  | 
        /// </summary>
        [Symbol("ror r64, imm8","ror r64, imm8 |  | ")]
        ror_r64_imm8 = 1403,

        /// <summary>
        /// ror r64, 1 |  | 
        /// </summary>
        [Symbol("ror r64, 1","ror r64, 1 |  | ")]
        ror_r64_n1 = 1404,

        /// <summary>
        /// ror r8, CL |  | 
        /// </summary>
        [Symbol("ror r8, CL","ror r8, CL |  | ")]
        ror_r8_CL = 1405,

        /// <summary>
        /// ror r8, imm8 |  | 
        /// </summary>
        [Symbol("ror r8, imm8","ror r8, imm8 |  | ")]
        ror_r8_imm8 = 1406,

        /// <summary>
        /// ror r8, 1 |  | 
        /// </summary>
        [Symbol("ror r8, 1","ror r8, 1 |  | ")]
        ror_r8_n1 = 1407,

        /// <summary>
        /// sal m16, CL |  | 
        /// </summary>
        [Symbol("sal m16, CL","sal m16, CL |  | ")]
        sal_m16_CL = 1408,

        /// <summary>
        /// sal m16, imm8 |  | 
        /// </summary>
        [Symbol("sal m16, imm8","sal m16, imm8 |  | ")]
        sal_m16_imm8 = 1409,

        /// <summary>
        /// sal m16, 1 |  | 
        /// </summary>
        [Symbol("sal m16, 1","sal m16, 1 |  | ")]
        sal_m16_n1 = 1410,

        /// <summary>
        /// sal m32, CL |  | 
        /// </summary>
        [Symbol("sal m32, CL","sal m32, CL |  | ")]
        sal_m32_CL = 1411,

        /// <summary>
        /// sal m32, imm8 |  | 
        /// </summary>
        [Symbol("sal m32, imm8","sal m32, imm8 |  | ")]
        sal_m32_imm8 = 1412,

        /// <summary>
        /// sal m32, 1 |  | 
        /// </summary>
        [Symbol("sal m32, 1","sal m32, 1 |  | ")]
        sal_m32_n1 = 1413,

        /// <summary>
        /// sal m64, CL |  | 
        /// </summary>
        [Symbol("sal m64, CL","sal m64, CL |  | ")]
        sal_m64_CL = 1414,

        /// <summary>
        /// sal m64, imm8 |  | 
        /// </summary>
        [Symbol("sal m64, imm8","sal m64, imm8 |  | ")]
        sal_m64_imm8 = 1415,

        /// <summary>
        /// sal m64, 1 |  | 
        /// </summary>
        [Symbol("sal m64, 1","sal m64, 1 |  | ")]
        sal_m64_n1 = 1416,

        /// <summary>
        /// sal m8, CL |  | 
        /// </summary>
        [Symbol("sal m8, CL","sal m8, CL |  | ")]
        sal_m8_CL = 1417,

        /// <summary>
        /// sal m8, imm8 |  | 
        /// </summary>
        [Symbol("sal m8, imm8","sal m8, imm8 |  | ")]
        sal_m8_imm8 = 1418,

        /// <summary>
        /// sal m8, 1 |  | 
        /// </summary>
        [Symbol("sal m8, 1","sal m8, 1 |  | ")]
        sal_m8_n1 = 1419,

        /// <summary>
        /// sal r16, CL |  | 
        /// </summary>
        [Symbol("sal r16, CL","sal r16, CL |  | ")]
        sal_r16_CL = 1420,

        /// <summary>
        /// sal r16, imm8 |  | 
        /// </summary>
        [Symbol("sal r16, imm8","sal r16, imm8 |  | ")]
        sal_r16_imm8 = 1421,

        /// <summary>
        /// sal r16, 1 |  | 
        /// </summary>
        [Symbol("sal r16, 1","sal r16, 1 |  | ")]
        sal_r16_n1 = 1422,

        /// <summary>
        /// sal r32, CL |  | 
        /// </summary>
        [Symbol("sal r32, CL","sal r32, CL |  | ")]
        sal_r32_CL = 1423,

        /// <summary>
        /// sal r32, imm8 |  | 
        /// </summary>
        [Symbol("sal r32, imm8","sal r32, imm8 |  | ")]
        sal_r32_imm8 = 1424,

        /// <summary>
        /// sal r32, 1 |  | 
        /// </summary>
        [Symbol("sal r32, 1","sal r32, 1 |  | ")]
        sal_r32_n1 = 1425,

        /// <summary>
        /// sal r64, CL |  | 
        /// </summary>
        [Symbol("sal r64, CL","sal r64, CL |  | ")]
        sal_r64_CL = 1426,

        /// <summary>
        /// sal r64, imm8 |  | 
        /// </summary>
        [Symbol("sal r64, imm8","sal r64, imm8 |  | ")]
        sal_r64_imm8 = 1427,

        /// <summary>
        /// sal r64, 1 |  | 
        /// </summary>
        [Symbol("sal r64, 1","sal r64, 1 |  | ")]
        sal_r64_n1 = 1428,

        /// <summary>
        /// sal r8, CL |  | 
        /// </summary>
        [Symbol("sal r8, CL","sal r8, CL |  | ")]
        sal_r8_CL = 1429,

        /// <summary>
        /// sal r8, imm8 |  | 
        /// </summary>
        [Symbol("sal r8, imm8","sal r8, imm8 |  | ")]
        sal_r8_imm8 = 1430,

        /// <summary>
        /// sal r8, 1 |  | 
        /// </summary>
        [Symbol("sal r8, 1","sal r8, 1 |  | ")]
        sal_r8_n1 = 1431,

        /// <summary>
        /// sar m16, CL |  | 
        /// </summary>
        [Symbol("sar m16, CL","sar m16, CL |  | ")]
        sar_m16_CL = 1432,

        /// <summary>
        /// sar m16, imm8 |  | 
        /// </summary>
        [Symbol("sar m16, imm8","sar m16, imm8 |  | ")]
        sar_m16_imm8 = 1433,

        /// <summary>
        /// sar m16, 1 |  | 
        /// </summary>
        [Symbol("sar m16, 1","sar m16, 1 |  | ")]
        sar_m16_n1 = 1434,

        /// <summary>
        /// sar m32, CL |  | 
        /// </summary>
        [Symbol("sar m32, CL","sar m32, CL |  | ")]
        sar_m32_CL = 1435,

        /// <summary>
        /// sar m32, imm8 |  | 
        /// </summary>
        [Symbol("sar m32, imm8","sar m32, imm8 |  | ")]
        sar_m32_imm8 = 1436,

        /// <summary>
        /// sar m32, 1 |  | 
        /// </summary>
        [Symbol("sar m32, 1","sar m32, 1 |  | ")]
        sar_m32_n1 = 1437,

        /// <summary>
        /// sar m64, CL |  | 
        /// </summary>
        [Symbol("sar m64, CL","sar m64, CL |  | ")]
        sar_m64_CL = 1438,

        /// <summary>
        /// sar m64, imm8 |  | 
        /// </summary>
        [Symbol("sar m64, imm8","sar m64, imm8 |  | ")]
        sar_m64_imm8 = 1439,

        /// <summary>
        /// sar m64, 1 |  | 
        /// </summary>
        [Symbol("sar m64, 1","sar m64, 1 |  | ")]
        sar_m64_n1 = 1440,

        /// <summary>
        /// sar m8, CL |  | 
        /// </summary>
        [Symbol("sar m8, CL","sar m8, CL |  | ")]
        sar_m8_CL = 1441,

        /// <summary>
        /// sar m8, imm8 |  | 
        /// </summary>
        [Symbol("sar m8, imm8","sar m8, imm8 |  | ")]
        sar_m8_imm8 = 1442,

        /// <summary>
        /// sar m8, 1 |  | 
        /// </summary>
        [Symbol("sar m8, 1","sar m8, 1 |  | ")]
        sar_m8_n1 = 1443,

        /// <summary>
        /// sar r16, CL |  | 
        /// </summary>
        [Symbol("sar r16, CL","sar r16, CL |  | ")]
        sar_r16_CL = 1444,

        /// <summary>
        /// sar r16, imm8 |  | 
        /// </summary>
        [Symbol("sar r16, imm8","sar r16, imm8 |  | ")]
        sar_r16_imm8 = 1445,

        /// <summary>
        /// sar r16, 1 |  | 
        /// </summary>
        [Symbol("sar r16, 1","sar r16, 1 |  | ")]
        sar_r16_n1 = 1446,

        /// <summary>
        /// sar r32, CL |  | 
        /// </summary>
        [Symbol("sar r32, CL","sar r32, CL |  | ")]
        sar_r32_CL = 1447,

        /// <summary>
        /// sar r32, imm8 |  | 
        /// </summary>
        [Symbol("sar r32, imm8","sar r32, imm8 |  | ")]
        sar_r32_imm8 = 1448,

        /// <summary>
        /// sar r32, 1 |  | 
        /// </summary>
        [Symbol("sar r32, 1","sar r32, 1 |  | ")]
        sar_r32_n1 = 1449,

        /// <summary>
        /// sar r64, CL |  | 
        /// </summary>
        [Symbol("sar r64, CL","sar r64, CL |  | ")]
        sar_r64_CL = 1450,

        /// <summary>
        /// sar r64, imm8 |  | 
        /// </summary>
        [Symbol("sar r64, imm8","sar r64, imm8 |  | ")]
        sar_r64_imm8 = 1451,

        /// <summary>
        /// sar r64, 1 |  | 
        /// </summary>
        [Symbol("sar r64, 1","sar r64, 1 |  | ")]
        sar_r64_n1 = 1452,

        /// <summary>
        /// sar r8, CL |  | 
        /// </summary>
        [Symbol("sar r8, CL","sar r8, CL |  | ")]
        sar_r8_CL = 1453,

        /// <summary>
        /// sar r8, imm8 |  | 
        /// </summary>
        [Symbol("sar r8, imm8","sar r8, imm8 |  | ")]
        sar_r8_imm8 = 1454,

        /// <summary>
        /// sar r8, 1 |  | 
        /// </summary>
        [Symbol("sar r8, 1","sar r8, 1 |  | ")]
        sar_r8_n1 = 1455,

        /// <summary>
        /// sarx r32, m32, r32 |  | 
        /// </summary>
        [Symbol("sarx r32, m32, r32","sarx r32, m32, r32 |  | ")]
        sarx_r32_m32_r32 = 1456,

        /// <summary>
        /// sarx r32, r32, r32 |  | 
        /// </summary>
        [Symbol("sarx r32, r32, r32","sarx r32, r32, r32 |  | ")]
        sarx_r32_r32_r32 = 1457,

        /// <summary>
        /// sarx r64, m64, r64 |  | 
        /// </summary>
        [Symbol("sarx r64, m64, r64","sarx r64, m64, r64 |  | ")]
        sarx_r64_m64_r64 = 1458,

        /// <summary>
        /// sarx r64, r64, r64 |  | 
        /// </summary>
        [Symbol("sarx r64, r64, r64","sarx r64, r64, r64 |  | ")]
        sarx_r64_r64_r64 = 1459,

        /// <summary>
        /// sbb AL, imm8 |  | 
        /// </summary>
        [Symbol("sbb AL, imm8","sbb AL, imm8 |  | ")]
        sbb_AL_imm8 = 1460,

        /// <summary>
        /// sbb AX, imm16 |  | 
        /// </summary>
        [Symbol("sbb AX, imm16","sbb AX, imm16 |  | ")]
        sbb_AX_imm16 = 1461,

        /// <summary>
        /// sbb EAX, imm32 |  | 
        /// </summary>
        [Symbol("sbb EAX, imm32","sbb EAX, imm32 |  | ")]
        sbb_EAX_imm32 = 1462,

        /// <summary>
        /// sbb m16, imm16 |  | 
        /// </summary>
        [Symbol("sbb m16, imm16","sbb m16, imm16 |  | ")]
        sbb_m16_imm16 = 1463,

        /// <summary>
        /// sbb m16, imm8 |  | 
        /// </summary>
        [Symbol("sbb m16, imm8","sbb m16, imm8 |  | ")]
        sbb_m16_imm8 = 1464,

        /// <summary>
        /// sbb m16, r16 |  | 
        /// </summary>
        [Symbol("sbb m16, r16","sbb m16, r16 |  | ")]
        sbb_m16_r16 = 1465,

        /// <summary>
        /// sbb m32, imm32 |  | 
        /// </summary>
        [Symbol("sbb m32, imm32","sbb m32, imm32 |  | ")]
        sbb_m32_imm32 = 1466,

        /// <summary>
        /// sbb m32, imm8 |  | 
        /// </summary>
        [Symbol("sbb m32, imm8","sbb m32, imm8 |  | ")]
        sbb_m32_imm8 = 1467,

        /// <summary>
        /// sbb m32, r32 |  | 
        /// </summary>
        [Symbol("sbb m32, r32","sbb m32, r32 |  | ")]
        sbb_m32_r32 = 1468,

        /// <summary>
        /// sbb m64, imm32 |  | 
        /// </summary>
        [Symbol("sbb m64, imm32","sbb m64, imm32 |  | ")]
        sbb_m64_imm32 = 1469,

        /// <summary>
        /// sbb m64, imm8 |  | 
        /// </summary>
        [Symbol("sbb m64, imm8","sbb m64, imm8 |  | ")]
        sbb_m64_imm8 = 1470,

        /// <summary>
        /// sbb m64, r64 |  | 
        /// </summary>
        [Symbol("sbb m64, r64","sbb m64, r64 |  | ")]
        sbb_m64_r64 = 1471,

        /// <summary>
        /// sbb m8, imm8 |  | 
        /// </summary>
        [Symbol("sbb m8, imm8","sbb m8, imm8 |  | ")]
        sbb_m8_imm8 = 1472,

        /// <summary>
        /// sbb m8, r8 |  | 
        /// </summary>
        [Symbol("sbb m8, r8","sbb m8, r8 |  | ")]
        sbb_m8_r8 = 1473,

        /// <summary>
        /// sbb r16, imm16 |  | 
        /// </summary>
        [Symbol("sbb r16, imm16","sbb r16, imm16 |  | ")]
        sbb_r16_imm16 = 1474,

        /// <summary>
        /// sbb r16, imm8 |  | 
        /// </summary>
        [Symbol("sbb r16, imm8","sbb r16, imm8 |  | ")]
        sbb_r16_imm8 = 1475,

        /// <summary>
        /// sbb r16, m16 |  | 
        /// </summary>
        [Symbol("sbb r16, m16","sbb r16, m16 |  | ")]
        sbb_r16_m16 = 1476,

        /// <summary>
        /// sbb r16, r16 |  | 
        /// </summary>
        [Symbol("sbb r16, r16","sbb r16, r16 |  | ")]
        sbb_r16_r16 = 1477,

        /// <summary>
        /// sbb r32, imm32 |  | 
        /// </summary>
        [Symbol("sbb r32, imm32","sbb r32, imm32 |  | ")]
        sbb_r32_imm32 = 1478,

        /// <summary>
        /// sbb r32, imm8 |  | 
        /// </summary>
        [Symbol("sbb r32, imm8","sbb r32, imm8 |  | ")]
        sbb_r32_imm8 = 1479,

        /// <summary>
        /// sbb r32, m32 |  | 
        /// </summary>
        [Symbol("sbb r32, m32","sbb r32, m32 |  | ")]
        sbb_r32_m32 = 1480,

        /// <summary>
        /// sbb r32, r32 |  | 
        /// </summary>
        [Symbol("sbb r32, r32","sbb r32, r32 |  | ")]
        sbb_r32_r32 = 1481,

        /// <summary>
        /// sbb r64, imm32 |  | 
        /// </summary>
        [Symbol("sbb r64, imm32","sbb r64, imm32 |  | ")]
        sbb_r64_imm32 = 1482,

        /// <summary>
        /// sbb r64, imm8 |  | 
        /// </summary>
        [Symbol("sbb r64, imm8","sbb r64, imm8 |  | ")]
        sbb_r64_imm8 = 1483,

        /// <summary>
        /// sbb r64, m64 |  | 
        /// </summary>
        [Symbol("sbb r64, m64","sbb r64, m64 |  | ")]
        sbb_r64_m64 = 1484,

        /// <summary>
        /// sbb r64, r64 |  | 
        /// </summary>
        [Symbol("sbb r64, r64","sbb r64, r64 |  | ")]
        sbb_r64_r64 = 1485,

        /// <summary>
        /// sbb r8, imm8 |  | 
        /// </summary>
        [Symbol("sbb r8, imm8","sbb r8, imm8 |  | ")]
        sbb_r8_imm8 = 1486,

        /// <summary>
        /// sbb r8, m8 |  | 
        /// </summary>
        [Symbol("sbb r8, m8","sbb r8, m8 |  | ")]
        sbb_r8_m8 = 1487,

        /// <summary>
        /// sbb r8, r8 |  | 
        /// </summary>
        [Symbol("sbb r8, r8","sbb r8, r8 |  | ")]
        sbb_r8_r8 = 1488,

        /// <summary>
        /// sbb RAX, imm32 |  | 
        /// </summary>
        [Symbol("sbb RAX, imm32","sbb RAX, imm32 |  | ")]
        sbb_RAX_imm32 = 1489,

        /// <summary>
        /// seta m8 |  | 
        /// </summary>
        [Symbol("seta m8","seta m8 |  | ")]
        seta_m8 = 1490,

        /// <summary>
        /// seta r8 |  | 
        /// </summary>
        [Symbol("seta r8","seta r8 |  | ")]
        seta_r8 = 1491,

        /// <summary>
        /// setae m8 |  | 
        /// </summary>
        [Symbol("setae m8","setae m8 |  | ")]
        setae_m8 = 1492,

        /// <summary>
        /// setae r8 |  | 
        /// </summary>
        [Symbol("setae r8","setae r8 |  | ")]
        setae_r8 = 1493,

        /// <summary>
        /// setb m8 |  | 
        /// </summary>
        [Symbol("setb m8","setb m8 |  | ")]
        setb_m8 = 1494,

        /// <summary>
        /// setb r8 |  | 
        /// </summary>
        [Symbol("setb r8","setb r8 |  | ")]
        setb_r8 = 1495,

        /// <summary>
        /// setbe m8 |  | 
        /// </summary>
        [Symbol("setbe m8","setbe m8 |  | ")]
        setbe_m8 = 1496,

        /// <summary>
        /// setbe r8 |  | 
        /// </summary>
        [Symbol("setbe r8","setbe r8 |  | ")]
        setbe_r8 = 1497,

        /// <summary>
        /// setc m8 |  | 
        /// </summary>
        [Symbol("setc m8","setc m8 |  | ")]
        setc_m8 = 1498,

        /// <summary>
        /// setc r8 |  | 
        /// </summary>
        [Symbol("setc r8","setc r8 |  | ")]
        setc_r8 = 1499,

        /// <summary>
        /// sete m8 |  | 
        /// </summary>
        [Symbol("sete m8","sete m8 |  | ")]
        sete_m8 = 1500,

        /// <summary>
        /// sete r8 |  | 
        /// </summary>
        [Symbol("sete r8","sete r8 |  | ")]
        sete_r8 = 1501,

        /// <summary>
        /// setg m8 |  | 
        /// </summary>
        [Symbol("setg m8","setg m8 |  | ")]
        setg_m8 = 1502,

        /// <summary>
        /// setg r8 |  | 
        /// </summary>
        [Symbol("setg r8","setg r8 |  | ")]
        setg_r8 = 1503,

        /// <summary>
        /// setge m8 |  | 
        /// </summary>
        [Symbol("setge m8","setge m8 |  | ")]
        setge_m8 = 1504,

        /// <summary>
        /// setge r8 |  | 
        /// </summary>
        [Symbol("setge r8","setge r8 |  | ")]
        setge_r8 = 1505,

        /// <summary>
        /// setl m8 |  | 
        /// </summary>
        [Symbol("setl m8","setl m8 |  | ")]
        setl_m8 = 1506,

        /// <summary>
        /// setl r8 |  | 
        /// </summary>
        [Symbol("setl r8","setl r8 |  | ")]
        setl_r8 = 1507,

        /// <summary>
        /// setle m8 |  | 
        /// </summary>
        [Symbol("setle m8","setle m8 |  | ")]
        setle_m8 = 1508,

        /// <summary>
        /// setle r8 |  | 
        /// </summary>
        [Symbol("setle r8","setle r8 |  | ")]
        setle_r8 = 1509,

        /// <summary>
        /// setna m8 |  | 
        /// </summary>
        [Symbol("setna m8","setna m8 |  | ")]
        setna_m8 = 1510,

        /// <summary>
        /// setna r8 |  | 
        /// </summary>
        [Symbol("setna r8","setna r8 |  | ")]
        setna_r8 = 1511,

        /// <summary>
        /// setnae m8 |  | 
        /// </summary>
        [Symbol("setnae m8","setnae m8 |  | ")]
        setnae_m8 = 1512,

        /// <summary>
        /// setnae r8 |  | 
        /// </summary>
        [Symbol("setnae r8","setnae r8 |  | ")]
        setnae_r8 = 1513,

        /// <summary>
        /// setnb m8 |  | 
        /// </summary>
        [Symbol("setnb m8","setnb m8 |  | ")]
        setnb_m8 = 1514,

        /// <summary>
        /// setnb r8 |  | 
        /// </summary>
        [Symbol("setnb r8","setnb r8 |  | ")]
        setnb_r8 = 1515,

        /// <summary>
        /// setnbe m8 |  | 
        /// </summary>
        [Symbol("setnbe m8","setnbe m8 |  | ")]
        setnbe_m8 = 1516,

        /// <summary>
        /// setnbe r8 |  | 
        /// </summary>
        [Symbol("setnbe r8","setnbe r8 |  | ")]
        setnbe_r8 = 1517,

        /// <summary>
        /// setnc m8 |  | 
        /// </summary>
        [Symbol("setnc m8","setnc m8 |  | ")]
        setnc_m8 = 1518,

        /// <summary>
        /// setnc r8 |  | 
        /// </summary>
        [Symbol("setnc r8","setnc r8 |  | ")]
        setnc_r8 = 1519,

        /// <summary>
        /// setne m8 |  | 
        /// </summary>
        [Symbol("setne m8","setne m8 |  | ")]
        setne_m8 = 1520,

        /// <summary>
        /// setne r8 |  | 
        /// </summary>
        [Symbol("setne r8","setne r8 |  | ")]
        setne_r8 = 1521,

        /// <summary>
        /// setng m8 |  | 
        /// </summary>
        [Symbol("setng m8","setng m8 |  | ")]
        setng_m8 = 1522,

        /// <summary>
        /// setng r8 |  | 
        /// </summary>
        [Symbol("setng r8","setng r8 |  | ")]
        setng_r8 = 1523,

        /// <summary>
        /// setnge m8 |  | 
        /// </summary>
        [Symbol("setnge m8","setnge m8 |  | ")]
        setnge_m8 = 1524,

        /// <summary>
        /// setnge r8 |  | 
        /// </summary>
        [Symbol("setnge r8","setnge r8 |  | ")]
        setnge_r8 = 1525,

        /// <summary>
        /// setnl m8 |  | 
        /// </summary>
        [Symbol("setnl m8","setnl m8 |  | ")]
        setnl_m8 = 1526,

        /// <summary>
        /// setnl r8 |  | 
        /// </summary>
        [Symbol("setnl r8","setnl r8 |  | ")]
        setnl_r8 = 1527,

        /// <summary>
        /// setnle m8 |  | 
        /// </summary>
        [Symbol("setnle m8","setnle m8 |  | ")]
        setnle_m8 = 1528,

        /// <summary>
        /// setnle r8 |  | 
        /// </summary>
        [Symbol("setnle r8","setnle r8 |  | ")]
        setnle_r8 = 1529,

        /// <summary>
        /// setno m8 |  | 
        /// </summary>
        [Symbol("setno m8","setno m8 |  | ")]
        setno_m8 = 1530,

        /// <summary>
        /// setno r8 |  | 
        /// </summary>
        [Symbol("setno r8","setno r8 |  | ")]
        setno_r8 = 1531,

        /// <summary>
        /// setnp m8 |  | 
        /// </summary>
        [Symbol("setnp m8","setnp m8 |  | ")]
        setnp_m8 = 1532,

        /// <summary>
        /// setnp r8 |  | 
        /// </summary>
        [Symbol("setnp r8","setnp r8 |  | ")]
        setnp_r8 = 1533,

        /// <summary>
        /// setns m8 |  | 
        /// </summary>
        [Symbol("setns m8","setns m8 |  | ")]
        setns_m8 = 1534,

        /// <summary>
        /// setns r8 |  | 
        /// </summary>
        [Symbol("setns r8","setns r8 |  | ")]
        setns_r8 = 1535,

        /// <summary>
        /// setnz m8 |  | 
        /// </summary>
        [Symbol("setnz m8","setnz m8 |  | ")]
        setnz_m8 = 1536,

        /// <summary>
        /// setnz r8 |  | 
        /// </summary>
        [Symbol("setnz r8","setnz r8 |  | ")]
        setnz_r8 = 1537,

        /// <summary>
        /// seto m8 |  | 
        /// </summary>
        [Symbol("seto m8","seto m8 |  | ")]
        seto_m8 = 1538,

        /// <summary>
        /// seto r8 |  | 
        /// </summary>
        [Symbol("seto r8","seto r8 |  | ")]
        seto_r8 = 1539,

        /// <summary>
        /// setp m8 |  | 
        /// </summary>
        [Symbol("setp m8","setp m8 |  | ")]
        setp_m8 = 1540,

        /// <summary>
        /// setp r8 |  | 
        /// </summary>
        [Symbol("setp r8","setp r8 |  | ")]
        setp_r8 = 1541,

        /// <summary>
        /// setpe m8 |  | 
        /// </summary>
        [Symbol("setpe m8","setpe m8 |  | ")]
        setpe_m8 = 1542,

        /// <summary>
        /// setpe r8 |  | 
        /// </summary>
        [Symbol("setpe r8","setpe r8 |  | ")]
        setpe_r8 = 1543,

        /// <summary>
        /// setpo m8 |  | 
        /// </summary>
        [Symbol("setpo m8","setpo m8 |  | ")]
        setpo_m8 = 1544,

        /// <summary>
        /// setpo r8 |  | 
        /// </summary>
        [Symbol("setpo r8","setpo r8 |  | ")]
        setpo_r8 = 1545,

        /// <summary>
        /// sets m8 |  | 
        /// </summary>
        [Symbol("sets m8","sets m8 |  | ")]
        sets_m8 = 1546,

        /// <summary>
        /// sets r8 |  | 
        /// </summary>
        [Symbol("sets r8","sets r8 |  | ")]
        sets_r8 = 1547,

        /// <summary>
        /// setz m8 |  | 
        /// </summary>
        [Symbol("setz m8","setz m8 |  | ")]
        setz_m8 = 1548,

        /// <summary>
        /// setz r8 |  | 
        /// </summary>
        [Symbol("setz r8","setz r8 |  | ")]
        setz_r8 = 1549,

        /// <summary>
        /// shl m16, CL |  | 
        /// </summary>
        [Symbol("shl m16, CL","shl m16, CL |  | ")]
        shl_m16_CL = 1550,

        /// <summary>
        /// shl m16, imm8 |  | 
        /// </summary>
        [Symbol("shl m16, imm8","shl m16, imm8 |  | ")]
        shl_m16_imm8 = 1551,

        /// <summary>
        /// shl m16, 1 |  | 
        /// </summary>
        [Symbol("shl m16, 1","shl m16, 1 |  | ")]
        shl_m16_n1 = 1552,

        /// <summary>
        /// shl m32, CL |  | 
        /// </summary>
        [Symbol("shl m32, CL","shl m32, CL |  | ")]
        shl_m32_CL = 1553,

        /// <summary>
        /// shl m32, imm8 |  | 
        /// </summary>
        [Symbol("shl m32, imm8","shl m32, imm8 |  | ")]
        shl_m32_imm8 = 1554,

        /// <summary>
        /// shl m32, 1 |  | 
        /// </summary>
        [Symbol("shl m32, 1","shl m32, 1 |  | ")]
        shl_m32_n1 = 1555,

        /// <summary>
        /// shl m64, CL |  | 
        /// </summary>
        [Symbol("shl m64, CL","shl m64, CL |  | ")]
        shl_m64_CL = 1556,

        /// <summary>
        /// shl m64, imm8 |  | 
        /// </summary>
        [Symbol("shl m64, imm8","shl m64, imm8 |  | ")]
        shl_m64_imm8 = 1557,

        /// <summary>
        /// shl m64, 1 |  | 
        /// </summary>
        [Symbol("shl m64, 1","shl m64, 1 |  | ")]
        shl_m64_n1 = 1558,

        /// <summary>
        /// shl m8, CL |  | 
        /// </summary>
        [Symbol("shl m8, CL","shl m8, CL |  | ")]
        shl_m8_CL = 1559,

        /// <summary>
        /// shl m8, imm8 |  | 
        /// </summary>
        [Symbol("shl m8, imm8","shl m8, imm8 |  | ")]
        shl_m8_imm8 = 1560,

        /// <summary>
        /// shl m8, 1 |  | 
        /// </summary>
        [Symbol("shl m8, 1","shl m8, 1 |  | ")]
        shl_m8_n1 = 1561,

        /// <summary>
        /// shl r16, CL |  | 
        /// </summary>
        [Symbol("shl r16, CL","shl r16, CL |  | ")]
        shl_r16_CL = 1562,

        /// <summary>
        /// shl r16, imm8 |  | 
        /// </summary>
        [Symbol("shl r16, imm8","shl r16, imm8 |  | ")]
        shl_r16_imm8 = 1563,

        /// <summary>
        /// shl r16, 1 |  | 
        /// </summary>
        [Symbol("shl r16, 1","shl r16, 1 |  | ")]
        shl_r16_n1 = 1564,

        /// <summary>
        /// shl r32, CL |  | 
        /// </summary>
        [Symbol("shl r32, CL","shl r32, CL |  | ")]
        shl_r32_CL = 1565,

        /// <summary>
        /// shl r32, imm8 |  | 
        /// </summary>
        [Symbol("shl r32, imm8","shl r32, imm8 |  | ")]
        shl_r32_imm8 = 1566,

        /// <summary>
        /// shl r32, 1 |  | 
        /// </summary>
        [Symbol("shl r32, 1","shl r32, 1 |  | ")]
        shl_r32_n1 = 1567,

        /// <summary>
        /// shl r64, CL |  | 
        /// </summary>
        [Symbol("shl r64, CL","shl r64, CL |  | ")]
        shl_r64_CL = 1568,

        /// <summary>
        /// shl r64, imm8 |  | 
        /// </summary>
        [Symbol("shl r64, imm8","shl r64, imm8 |  | ")]
        shl_r64_imm8 = 1569,

        /// <summary>
        /// shl r64, 1 |  | 
        /// </summary>
        [Symbol("shl r64, 1","shl r64, 1 |  | ")]
        shl_r64_n1 = 1570,

        /// <summary>
        /// shl r8, CL |  | 
        /// </summary>
        [Symbol("shl r8, CL","shl r8, CL |  | ")]
        shl_r8_CL = 1571,

        /// <summary>
        /// shl r8, imm8 |  | 
        /// </summary>
        [Symbol("shl r8, imm8","shl r8, imm8 |  | ")]
        shl_r8_imm8 = 1572,

        /// <summary>
        /// shl r8, 1 |  | 
        /// </summary>
        [Symbol("shl r8, 1","shl r8, 1 |  | ")]
        shl_r8_n1 = 1573,

        /// <summary>
        /// shlx r32, m32, r32 |  | 
        /// </summary>
        [Symbol("shlx r32, m32, r32","shlx r32, m32, r32 |  | ")]
        shlx_r32_m32_r32 = 1574,

        /// <summary>
        /// shlx r32, r32, r32 |  | 
        /// </summary>
        [Symbol("shlx r32, r32, r32","shlx r32, r32, r32 |  | ")]
        shlx_r32_r32_r32 = 1575,

        /// <summary>
        /// shlx r64, m64, r64 |  | 
        /// </summary>
        [Symbol("shlx r64, m64, r64","shlx r64, m64, r64 |  | ")]
        shlx_r64_m64_r64 = 1576,

        /// <summary>
        /// shlx r64, r64, r64 |  | 
        /// </summary>
        [Symbol("shlx r64, r64, r64","shlx r64, r64, r64 |  | ")]
        shlx_r64_r64_r64 = 1577,

        /// <summary>
        /// shr m16, CL |  | 
        /// </summary>
        [Symbol("shr m16, CL","shr m16, CL |  | ")]
        shr_m16_CL = 1578,

        /// <summary>
        /// shr m16, imm8 |  | 
        /// </summary>
        [Symbol("shr m16, imm8","shr m16, imm8 |  | ")]
        shr_m16_imm8 = 1579,

        /// <summary>
        /// shr m16, 1 |  | 
        /// </summary>
        [Symbol("shr m16, 1","shr m16, 1 |  | ")]
        shr_m16_n1 = 1580,

        /// <summary>
        /// shr m32, CL |  | 
        /// </summary>
        [Symbol("shr m32, CL","shr m32, CL |  | ")]
        shr_m32_CL = 1581,

        /// <summary>
        /// shr m32, imm8 |  | 
        /// </summary>
        [Symbol("shr m32, imm8","shr m32, imm8 |  | ")]
        shr_m32_imm8 = 1582,

        /// <summary>
        /// shr m32, 1 |  | 
        /// </summary>
        [Symbol("shr m32, 1","shr m32, 1 |  | ")]
        shr_m32_n1 = 1583,

        /// <summary>
        /// shr m64, CL |  | 
        /// </summary>
        [Symbol("shr m64, CL","shr m64, CL |  | ")]
        shr_m64_CL = 1584,

        /// <summary>
        /// shr m64, imm8 |  | 
        /// </summary>
        [Symbol("shr m64, imm8","shr m64, imm8 |  | ")]
        shr_m64_imm8 = 1585,

        /// <summary>
        /// shr m64, 1 |  | 
        /// </summary>
        [Symbol("shr m64, 1","shr m64, 1 |  | ")]
        shr_m64_n1 = 1586,

        /// <summary>
        /// shr m8, CL |  | 
        /// </summary>
        [Symbol("shr m8, CL","shr m8, CL |  | ")]
        shr_m8_CL = 1587,

        /// <summary>
        /// shr m8, imm8 |  | 
        /// </summary>
        [Symbol("shr m8, imm8","shr m8, imm8 |  | ")]
        shr_m8_imm8 = 1588,

        /// <summary>
        /// shr m8, 1 |  | 
        /// </summary>
        [Symbol("shr m8, 1","shr m8, 1 |  | ")]
        shr_m8_n1 = 1589,

        /// <summary>
        /// shr r16, CL |  | 
        /// </summary>
        [Symbol("shr r16, CL","shr r16, CL |  | ")]
        shr_r16_CL = 1590,

        /// <summary>
        /// shr r16, imm8 |  | 
        /// </summary>
        [Symbol("shr r16, imm8","shr r16, imm8 |  | ")]
        shr_r16_imm8 = 1591,

        /// <summary>
        /// shr r16, 1 |  | 
        /// </summary>
        [Symbol("shr r16, 1","shr r16, 1 |  | ")]
        shr_r16_n1 = 1592,

        /// <summary>
        /// shr r32, CL |  | 
        /// </summary>
        [Symbol("shr r32, CL","shr r32, CL |  | ")]
        shr_r32_CL = 1593,

        /// <summary>
        /// shr r32, imm8 |  | 
        /// </summary>
        [Symbol("shr r32, imm8","shr r32, imm8 |  | ")]
        shr_r32_imm8 = 1594,

        /// <summary>
        /// shr r32, 1 |  | 
        /// </summary>
        [Symbol("shr r32, 1","shr r32, 1 |  | ")]
        shr_r32_n1 = 1595,

        /// <summary>
        /// shr r64, CL |  | 
        /// </summary>
        [Symbol("shr r64, CL","shr r64, CL |  | ")]
        shr_r64_CL = 1596,

        /// <summary>
        /// shr r64, imm8 |  | 
        /// </summary>
        [Symbol("shr r64, imm8","shr r64, imm8 |  | ")]
        shr_r64_imm8 = 1597,

        /// <summary>
        /// shr r64, 1 |  | 
        /// </summary>
        [Symbol("shr r64, 1","shr r64, 1 |  | ")]
        shr_r64_n1 = 1598,

        /// <summary>
        /// shr r8, CL |  | 
        /// </summary>
        [Symbol("shr r8, CL","shr r8, CL |  | ")]
        shr_r8_CL = 1599,

        /// <summary>
        /// shr r8, imm8 |  | 
        /// </summary>
        [Symbol("shr r8, imm8","shr r8, imm8 |  | ")]
        shr_r8_imm8 = 1600,

        /// <summary>
        /// shr r8, 1 |  | 
        /// </summary>
        [Symbol("shr r8, 1","shr r8, 1 |  | ")]
        shr_r8_n1 = 1601,

        /// <summary>
        /// shrx r32, m32, r32 |  | 
        /// </summary>
        [Symbol("shrx r32, m32, r32","shrx r32, m32, r32 |  | ")]
        shrx_r32_m32_r32 = 1602,

        /// <summary>
        /// shrx r32, r32, r32 |  | 
        /// </summary>
        [Symbol("shrx r32, r32, r32","shrx r32, r32, r32 |  | ")]
        shrx_r32_r32_r32 = 1603,

        /// <summary>
        /// shrx r64, m64, r64 |  | 
        /// </summary>
        [Symbol("shrx r64, m64, r64","shrx r64, m64, r64 |  | ")]
        shrx_r64_m64_r64 = 1604,

        /// <summary>
        /// shrx r64, r64, r64 |  | 
        /// </summary>
        [Symbol("shrx r64, r64, r64","shrx r64, r64, r64 |  | ")]
        shrx_r64_r64_r64 = 1605,

        /// <summary>
        /// sti |  | 
        /// </summary>
        [Symbol("sti","sti |  | ")]
        sti = 1606,

        /// <summary>
        /// stos m16 |  | 
        /// </summary>
        [Symbol("stos m16","stos m16 |  | ")]
        stos_m16 = 1607,

        /// <summary>
        /// stos m32 |  | 
        /// </summary>
        [Symbol("stos m32","stos m32 |  | ")]
        stos_m32 = 1608,

        /// <summary>
        /// stos m64 |  | 
        /// </summary>
        [Symbol("stos m64","stos m64 |  | ")]
        stos_m64 = 1609,

        /// <summary>
        /// stos m8 |  | 
        /// </summary>
        [Symbol("stos m8","stos m8 |  | ")]
        stos_m8 = 1610,

        /// <summary>
        /// stosb |  | 
        /// </summary>
        [Symbol("stosb","stosb |  | ")]
        stosb = 1611,

        /// <summary>
        /// stosd |  | 
        /// </summary>
        [Symbol("stosd","stosd |  | ")]
        stosd = 1612,

        /// <summary>
        /// stosq |  | 
        /// </summary>
        [Symbol("stosq","stosq |  | ")]
        stosq = 1613,

        /// <summary>
        /// stosw |  | 
        /// </summary>
        [Symbol("stosw","stosw |  | ")]
        stosw = 1614,

        /// <summary>
        /// sub AL, imm8 |  | 
        /// </summary>
        [Symbol("sub AL, imm8","sub AL, imm8 |  | ")]
        sub_AL_imm8 = 1615,

        /// <summary>
        /// sub AX, imm16 |  | 
        /// </summary>
        [Symbol("sub AX, imm16","sub AX, imm16 |  | ")]
        sub_AX_imm16 = 1616,

        /// <summary>
        /// sub EAX, imm32 |  | 
        /// </summary>
        [Symbol("sub EAX, imm32","sub EAX, imm32 |  | ")]
        sub_EAX_imm32 = 1617,

        /// <summary>
        /// sub m16, imm16 |  | 
        /// </summary>
        [Symbol("sub m16, imm16","sub m16, imm16 |  | ")]
        sub_m16_imm16 = 1618,

        /// <summary>
        /// sub m16, imm8 |  | 
        /// </summary>
        [Symbol("sub m16, imm8","sub m16, imm8 |  | ")]
        sub_m16_imm8 = 1619,

        /// <summary>
        /// sub m16, r16 |  | 
        /// </summary>
        [Symbol("sub m16, r16","sub m16, r16 |  | ")]
        sub_m16_r16 = 1620,

        /// <summary>
        /// sub m32, imm32 |  | 
        /// </summary>
        [Symbol("sub m32, imm32","sub m32, imm32 |  | ")]
        sub_m32_imm32 = 1621,

        /// <summary>
        /// sub m32, imm8 |  | 
        /// </summary>
        [Symbol("sub m32, imm8","sub m32, imm8 |  | ")]
        sub_m32_imm8 = 1622,

        /// <summary>
        /// sub m32, r32 |  | 
        /// </summary>
        [Symbol("sub m32, r32","sub m32, r32 |  | ")]
        sub_m32_r32 = 1623,

        /// <summary>
        /// sub m64, imm32 |  | 
        /// </summary>
        [Symbol("sub m64, imm32","sub m64, imm32 |  | ")]
        sub_m64_imm32 = 1624,

        /// <summary>
        /// sub m64, imm8 |  | 
        /// </summary>
        [Symbol("sub m64, imm8","sub m64, imm8 |  | ")]
        sub_m64_imm8 = 1625,

        /// <summary>
        /// sub m64, r64 |  | 
        /// </summary>
        [Symbol("sub m64, r64","sub m64, r64 |  | ")]
        sub_m64_r64 = 1626,

        /// <summary>
        /// sub m8, imm8 |  | 
        /// </summary>
        [Symbol("sub m8, imm8","sub m8, imm8 |  | ")]
        sub_m8_imm8 = 1627,

        /// <summary>
        /// sub m8, r8 |  | 
        /// </summary>
        [Symbol("sub m8, r8","sub m8, r8 |  | ")]
        sub_m8_r8 = 1628,

        /// <summary>
        /// sub r16, imm16 |  | 
        /// </summary>
        [Symbol("sub r16, imm16","sub r16, imm16 |  | ")]
        sub_r16_imm16 = 1629,

        /// <summary>
        /// sub r16, imm8 |  | 
        /// </summary>
        [Symbol("sub r16, imm8","sub r16, imm8 |  | ")]
        sub_r16_imm8 = 1630,

        /// <summary>
        /// sub r16, m16 |  | 
        /// </summary>
        [Symbol("sub r16, m16","sub r16, m16 |  | ")]
        sub_r16_m16 = 1631,

        /// <summary>
        /// sub r16, r16 |  | 
        /// </summary>
        [Symbol("sub r16, r16","sub r16, r16 |  | ")]
        sub_r16_r16 = 1632,

        /// <summary>
        /// sub r32, imm32 |  | 
        /// </summary>
        [Symbol("sub r32, imm32","sub r32, imm32 |  | ")]
        sub_r32_imm32 = 1633,

        /// <summary>
        /// sub r32, imm8 |  | 
        /// </summary>
        [Symbol("sub r32, imm8","sub r32, imm8 |  | ")]
        sub_r32_imm8 = 1634,

        /// <summary>
        /// sub r32, m32 |  | 
        /// </summary>
        [Symbol("sub r32, m32","sub r32, m32 |  | ")]
        sub_r32_m32 = 1635,

        /// <summary>
        /// sub r32, r32 |  | 
        /// </summary>
        [Symbol("sub r32, r32","sub r32, r32 |  | ")]
        sub_r32_r32 = 1636,

        /// <summary>
        /// sub r64, imm32 |  | 
        /// </summary>
        [Symbol("sub r64, imm32","sub r64, imm32 |  | ")]
        sub_r64_imm32 = 1637,

        /// <summary>
        /// sub r64, imm8 |  | 
        /// </summary>
        [Symbol("sub r64, imm8","sub r64, imm8 |  | ")]
        sub_r64_imm8 = 1638,

        /// <summary>
        /// sub r64, m64 |  | 
        /// </summary>
        [Symbol("sub r64, m64","sub r64, m64 |  | ")]
        sub_r64_m64 = 1639,

        /// <summary>
        /// sub r64, r64 |  | 
        /// </summary>
        [Symbol("sub r64, r64","sub r64, r64 |  | ")]
        sub_r64_r64 = 1640,

        /// <summary>
        /// sub r8, imm8 |  | 
        /// </summary>
        [Symbol("sub r8, imm8","sub r8, imm8 |  | ")]
        sub_r8_imm8 = 1641,

        /// <summary>
        /// sub r8, m8 |  | 
        /// </summary>
        [Symbol("sub r8, m8","sub r8, m8 |  | ")]
        sub_r8_m8 = 1642,

        /// <summary>
        /// sub r8, r8 |  | 
        /// </summary>
        [Symbol("sub r8, r8","sub r8, r8 |  | ")]
        sub_r8_r8 = 1643,

        /// <summary>
        /// sub RAX, imm32 |  | 
        /// </summary>
        [Symbol("sub RAX, imm32","sub RAX, imm32 |  | ")]
        sub_RAX_imm32 = 1644,

        /// <summary>
        /// syscall |  | 
        /// </summary>
        [Symbol("syscall","syscall |  | ")]
        syscall = 1645,

        /// <summary>
        /// test AL, imm8 |  | 
        /// </summary>
        [Symbol("test AL, imm8","test AL, imm8 |  | ")]
        test_AL_imm8 = 1646,

        /// <summary>
        /// test AX, imm16 |  | 
        /// </summary>
        [Symbol("test AX, imm16","test AX, imm16 |  | ")]
        test_AX_imm16 = 1647,

        /// <summary>
        /// test EAX, imm32 |  | 
        /// </summary>
        [Symbol("test EAX, imm32","test EAX, imm32 |  | ")]
        test_EAX_imm32 = 1648,

        /// <summary>
        /// test m16, imm16 |  | 
        /// </summary>
        [Symbol("test m16, imm16","test m16, imm16 |  | ")]
        test_m16_imm16 = 1649,

        /// <summary>
        /// test m16, r16 |  | 
        /// </summary>
        [Symbol("test m16, r16","test m16, r16 |  | ")]
        test_m16_r16 = 1650,

        /// <summary>
        /// test m32, imm32 |  | 
        /// </summary>
        [Symbol("test m32, imm32","test m32, imm32 |  | ")]
        test_m32_imm32 = 1651,

        /// <summary>
        /// test m32, r32 |  | 
        /// </summary>
        [Symbol("test m32, r32","test m32, r32 |  | ")]
        test_m32_r32 = 1652,

        /// <summary>
        /// test m64, imm32 |  | 
        /// </summary>
        [Symbol("test m64, imm32","test m64, imm32 |  | ")]
        test_m64_imm32 = 1653,

        /// <summary>
        /// test m64, r64 |  | 
        /// </summary>
        [Symbol("test m64, r64","test m64, r64 |  | ")]
        test_m64_r64 = 1654,

        /// <summary>
        /// test m8, imm8 |  | 
        /// </summary>
        [Symbol("test m8, imm8","test m8, imm8 |  | ")]
        test_m8_imm8 = 1655,

        /// <summary>
        /// test m8, r8 |  | 
        /// </summary>
        [Symbol("test m8, r8","test m8, r8 |  | ")]
        test_m8_r8 = 1656,

        /// <summary>
        /// test r16, imm16 |  | 
        /// </summary>
        [Symbol("test r16, imm16","test r16, imm16 |  | ")]
        test_r16_imm16 = 1657,

        /// <summary>
        /// test r16, r16 |  | 
        /// </summary>
        [Symbol("test r16, r16","test r16, r16 |  | ")]
        test_r16_r16 = 1658,

        /// <summary>
        /// test r32, imm32 |  | 
        /// </summary>
        [Symbol("test r32, imm32","test r32, imm32 |  | ")]
        test_r32_imm32 = 1659,

        /// <summary>
        /// test r32, r32 |  | 
        /// </summary>
        [Symbol("test r32, r32","test r32, r32 |  | ")]
        test_r32_r32 = 1660,

        /// <summary>
        /// test r64, imm32 |  | 
        /// </summary>
        [Symbol("test r64, imm32","test r64, imm32 |  | ")]
        test_r64_imm32 = 1661,

        /// <summary>
        /// test r64, r64 |  | 
        /// </summary>
        [Symbol("test r64, r64","test r64, r64 |  | ")]
        test_r64_r64 = 1662,

        /// <summary>
        /// test r8, imm8 |  | 
        /// </summary>
        [Symbol("test r8, imm8","test r8, imm8 |  | ")]
        test_r8_imm8 = 1663,

        /// <summary>
        /// test r8, r8 |  | 
        /// </summary>
        [Symbol("test r8, r8","test r8, r8 |  | ")]
        test_r8_r8 = 1664,

        /// <summary>
        /// test RAX, imm32 |  | 
        /// </summary>
        [Symbol("test RAX, imm32","test RAX, imm32 |  | ")]
        test_RAX_imm32 = 1665,

        /// <summary>
        /// tpause r32, EDX, EAX |  | 
        /// </summary>
        [Symbol("tpause r32, EDX, EAX","tpause r32, EDX, EAX |  | ")]
        tpause_r32_EDX_EAX = 1666,

        /// <summary>
        /// vaddpd xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vaddpd xmm {k1}{z}, xmm, m128","vaddpd xmm {k1}{z}, xmm, m128 |  | ")]
        vaddpd_xmm_k1z_xmm_m128 = 1667,

        /// <summary>
        /// vaddpd xmm {k1}{z}, xmm, m64bcst |  | 
        /// </summary>
        [Symbol("vaddpd xmm {k1}{z}, xmm, m64bcst","vaddpd xmm {k1}{z}, xmm, m64bcst |  | ")]
        vaddpd_xmm_k1z_xmm_m64bcst = 1668,

        /// <summary>
        /// vaddpd xmm {k1}{z}, xmm, xmm |  | 
        /// </summary>
        [Symbol("vaddpd xmm {k1}{z}, xmm, xmm","vaddpd xmm {k1}{z}, xmm, xmm |  | ")]
        vaddpd_xmm_k1z_xmm_xmm = 1669,

        /// <summary>
        /// vaddpd xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vaddpd xmm, xmm, m128","vaddpd xmm, xmm, m128 |  | ")]
        vaddpd_xmm_xmm_m128 = 1670,

        /// <summary>
        /// vaddpd xmm, xmm, m64bcst |  | 
        /// </summary>
        [Symbol("vaddpd xmm, xmm, m64bcst","vaddpd xmm, xmm, m64bcst |  | ")]
        vaddpd_xmm_xmm_m64bcst = 1671,

        /// <summary>
        /// vaddpd xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vaddpd xmm, xmm, r8","vaddpd xmm, xmm, r8 |  | ")]
        vaddpd_xmm_xmm_r8 = 1672,

        /// <summary>
        /// vaddpd xmm, xmm, xmm |  | 
        /// </summary>
        [Symbol("vaddpd xmm, xmm, xmm","vaddpd xmm, xmm, xmm |  | ")]
        vaddpd_xmm_xmm_xmm = 1673,

        /// <summary>
        /// vaddpd ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vaddpd ymm {k1}{z}, ymm, m256","vaddpd ymm {k1}{z}, ymm, m256 |  | ")]
        vaddpd_ymm_k1z_ymm_m256 = 1674,

        /// <summary>
        /// vaddpd ymm {k1}{z}, ymm, m64bcst |  | 
        /// </summary>
        [Symbol("vaddpd ymm {k1}{z}, ymm, m64bcst","vaddpd ymm {k1}{z}, ymm, m64bcst |  | ")]
        vaddpd_ymm_k1z_ymm_m64bcst = 1675,

        /// <summary>
        /// vaddpd ymm {k1}{z}, ymm, ymm |  | 
        /// </summary>
        [Symbol("vaddpd ymm {k1}{z}, ymm, ymm","vaddpd ymm {k1}{z}, ymm, ymm |  | ")]
        vaddpd_ymm_k1z_ymm_ymm = 1676,

        /// <summary>
        /// vaddpd ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vaddpd ymm, ymm, m256","vaddpd ymm, ymm, m256 |  | ")]
        vaddpd_ymm_ymm_m256 = 1677,

        /// <summary>
        /// vaddpd ymm, ymm, m64bcst |  | 
        /// </summary>
        [Symbol("vaddpd ymm, ymm, m64bcst","vaddpd ymm, ymm, m64bcst |  | ")]
        vaddpd_ymm_ymm_m64bcst = 1678,

        /// <summary>
        /// vaddpd ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vaddpd ymm, ymm, r16","vaddpd ymm, ymm, r16 |  | ")]
        vaddpd_ymm_ymm_r16 = 1679,

        /// <summary>
        /// vaddpd ymm, ymm, ymm |  | 
        /// </summary>
        [Symbol("vaddpd ymm, ymm, ymm","vaddpd ymm, ymm, ymm |  | ")]
        vaddpd_ymm_ymm_ymm = 1680,

        /// <summary>
        /// vaddpd zmm {k1}{z}, zmm, m512 {k1} |  | 
        /// </summary>
        [Symbol("vaddpd zmm {k1}{z}, zmm, m512 {k1}","vaddpd zmm {k1}{z}, zmm, m512 {k1} |  | ")]
        vaddpd_zmm_k1z_zmm_m512_k1 = 1681,

        /// <summary>
        /// vaddpd zmm {k1}{z}, zmm, m64bcst {k1} |  | 
        /// </summary>
        [Symbol("vaddpd zmm {k1}{z}, zmm, m64bcst {k1}","vaddpd zmm {k1}{z}, zmm, m64bcst {k1} |  | ")]
        vaddpd_zmm_k1z_zmm_m64bcst_k1 = 1682,

        /// <summary>
        /// vaddpd zmm {k1}{z}, zmm, zmm {k1} |  | 
        /// </summary>
        [Symbol("vaddpd zmm {k1}{z}, zmm, zmm {k1}","vaddpd zmm {k1}{z}, zmm, zmm {k1} |  | ")]
        vaddpd_zmm_k1z_zmm_zmm_k1 = 1683,

        /// <summary>
        /// vaddpd zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vaddpd zmm, zmm, m512","vaddpd zmm, zmm, m512 |  | ")]
        vaddpd_zmm_zmm_m512 = 1684,

        /// <summary>
        /// vaddpd zmm, zmm, m64bcst |  | 
        /// </summary>
        [Symbol("vaddpd zmm, zmm, m64bcst","vaddpd zmm, zmm, m64bcst |  | ")]
        vaddpd_zmm_zmm_m64bcst = 1685,

        /// <summary>
        /// vaddpd zmm, zmm, zmm |  | 
        /// </summary>
        [Symbol("vaddpd zmm, zmm, zmm","vaddpd zmm, zmm, zmm |  | ")]
        vaddpd_zmm_zmm_zmm = 1686,

        /// <summary>
        /// valignd xmm {k1}{z}, xmm, m128, imm8 |  | 
        /// </summary>
        [Symbol("valignd xmm {k1}{z}, xmm, m128, imm8","valignd xmm {k1}{z}, xmm, m128, imm8 |  | ")]
        valignd_xmm_k1z_xmm_m128_imm8 = 1687,

        /// <summary>
        /// valignd xmm {k1}{z}, xmm, m32bcst, imm8 |  | 
        /// </summary>
        [Symbol("valignd xmm {k1}{z}, xmm, m32bcst, imm8","valignd xmm {k1}{z}, xmm, m32bcst, imm8 |  | ")]
        valignd_xmm_k1z_xmm_m32bcst_imm8 = 1688,

        /// <summary>
        /// valignd xmm {k1}{z}, xmm, xmm, imm8 |  | 
        /// </summary>
        [Symbol("valignd xmm {k1}{z}, xmm, xmm, imm8","valignd xmm {k1}{z}, xmm, xmm, imm8 |  | ")]
        valignd_xmm_k1z_xmm_xmm_imm8 = 1689,

        /// <summary>
        /// valignd xmm, xmm, m128, imm8 |  | 
        /// </summary>
        [Symbol("valignd xmm, xmm, m128, imm8","valignd xmm, xmm, m128, imm8 |  | ")]
        valignd_xmm_xmm_m128_imm8 = 1690,

        /// <summary>
        /// valignd xmm, xmm, m32bcst, imm8 |  | 
        /// </summary>
        [Symbol("valignd xmm, xmm, m32bcst, imm8","valignd xmm, xmm, m32bcst, imm8 |  | ")]
        valignd_xmm_xmm_m32bcst_imm8 = 1691,

        /// <summary>
        /// valignd xmm, xmm, xmm, imm8 |  | 
        /// </summary>
        [Symbol("valignd xmm, xmm, xmm, imm8","valignd xmm, xmm, xmm, imm8 |  | ")]
        valignd_xmm_xmm_xmm_imm8 = 1692,

        /// <summary>
        /// valignd ymm {k1}{z}, ymm, m256, imm8 |  | 
        /// </summary>
        [Symbol("valignd ymm {k1}{z}, ymm, m256, imm8","valignd ymm {k1}{z}, ymm, m256, imm8 |  | ")]
        valignd_ymm_k1z_ymm_m256_imm8 = 1693,

        /// <summary>
        /// valignd ymm {k1}{z}, ymm, m32bcst, imm8 |  | 
        /// </summary>
        [Symbol("valignd ymm {k1}{z}, ymm, m32bcst, imm8","valignd ymm {k1}{z}, ymm, m32bcst, imm8 |  | ")]
        valignd_ymm_k1z_ymm_m32bcst_imm8 = 1694,

        /// <summary>
        /// valignd ymm {k1}{z}, ymm, ymm, imm8 |  | 
        /// </summary>
        [Symbol("valignd ymm {k1}{z}, ymm, ymm, imm8","valignd ymm {k1}{z}, ymm, ymm, imm8 |  | ")]
        valignd_ymm_k1z_ymm_ymm_imm8 = 1695,

        /// <summary>
        /// valignd ymm, ymm, m256, imm8 |  | 
        /// </summary>
        [Symbol("valignd ymm, ymm, m256, imm8","valignd ymm, ymm, m256, imm8 |  | ")]
        valignd_ymm_ymm_m256_imm8 = 1696,

        /// <summary>
        /// valignd ymm, ymm, m32bcst, imm8 |  | 
        /// </summary>
        [Symbol("valignd ymm, ymm, m32bcst, imm8","valignd ymm, ymm, m32bcst, imm8 |  | ")]
        valignd_ymm_ymm_m32bcst_imm8 = 1697,

        /// <summary>
        /// valignd ymm, ymm, ymm, imm8 |  | 
        /// </summary>
        [Symbol("valignd ymm, ymm, ymm, imm8","valignd ymm, ymm, ymm, imm8 |  | ")]
        valignd_ymm_ymm_ymm_imm8 = 1698,

        /// <summary>
        /// valignd zmm {k1}{z}, zmm, m32bcst, imm8 |  | 
        /// </summary>
        [Symbol("valignd zmm {k1}{z}, zmm, m32bcst, imm8","valignd zmm {k1}{z}, zmm, m32bcst, imm8 |  | ")]
        valignd_zmm_k1z_zmm_m32bcst_imm8 = 1699,

        /// <summary>
        /// valignd zmm {k1}{z}, zmm, m512, imm8 |  | 
        /// </summary>
        [Symbol("valignd zmm {k1}{z}, zmm, m512, imm8","valignd zmm {k1}{z}, zmm, m512, imm8 |  | ")]
        valignd_zmm_k1z_zmm_m512_imm8 = 1700,

        /// <summary>
        /// valignd zmm {k1}{z}, zmm, zmm, imm8 |  | 
        /// </summary>
        [Symbol("valignd zmm {k1}{z}, zmm, zmm, imm8","valignd zmm {k1}{z}, zmm, zmm, imm8 |  | ")]
        valignd_zmm_k1z_zmm_zmm_imm8 = 1701,

        /// <summary>
        /// valignd zmm, zmm, m32bcst, imm8 |  | 
        /// </summary>
        [Symbol("valignd zmm, zmm, m32bcst, imm8","valignd zmm, zmm, m32bcst, imm8 |  | ")]
        valignd_zmm_zmm_m32bcst_imm8 = 1702,

        /// <summary>
        /// valignd zmm, zmm, m512, imm8 |  | 
        /// </summary>
        [Symbol("valignd zmm, zmm, m512, imm8","valignd zmm, zmm, m512, imm8 |  | ")]
        valignd_zmm_zmm_m512_imm8 = 1703,

        /// <summary>
        /// valignd zmm, zmm, zmm, imm8 |  | 
        /// </summary>
        [Symbol("valignd zmm, zmm, zmm, imm8","valignd zmm, zmm, zmm, imm8 |  | ")]
        valignd_zmm_zmm_zmm_imm8 = 1704,

        /// <summary>
        /// valignq xmm {k1}{z}, xmm, m128, imm8 |  | 
        /// </summary>
        [Symbol("valignq xmm {k1}{z}, xmm, m128, imm8","valignq xmm {k1}{z}, xmm, m128, imm8 |  | ")]
        valignq_xmm_k1z_xmm_m128_imm8 = 1705,

        /// <summary>
        /// valignq xmm {k1}{z}, xmm, m64bcst, imm8 |  | 
        /// </summary>
        [Symbol("valignq xmm {k1}{z}, xmm, m64bcst, imm8","valignq xmm {k1}{z}, xmm, m64bcst, imm8 |  | ")]
        valignq_xmm_k1z_xmm_m64bcst_imm8 = 1706,

        /// <summary>
        /// valignq xmm {k1}{z}, xmm, xmm, imm8 |  | 
        /// </summary>
        [Symbol("valignq xmm {k1}{z}, xmm, xmm, imm8","valignq xmm {k1}{z}, xmm, xmm, imm8 |  | ")]
        valignq_xmm_k1z_xmm_xmm_imm8 = 1707,

        /// <summary>
        /// valignq xmm, xmm, m128, imm8 |  | 
        /// </summary>
        [Symbol("valignq xmm, xmm, m128, imm8","valignq xmm, xmm, m128, imm8 |  | ")]
        valignq_xmm_xmm_m128_imm8 = 1708,

        /// <summary>
        /// valignq xmm, xmm, m64bcst, imm8 |  | 
        /// </summary>
        [Symbol("valignq xmm, xmm, m64bcst, imm8","valignq xmm, xmm, m64bcst, imm8 |  | ")]
        valignq_xmm_xmm_m64bcst_imm8 = 1709,

        /// <summary>
        /// valignq xmm, xmm, xmm, imm8 |  | 
        /// </summary>
        [Symbol("valignq xmm, xmm, xmm, imm8","valignq xmm, xmm, xmm, imm8 |  | ")]
        valignq_xmm_xmm_xmm_imm8 = 1710,

        /// <summary>
        /// valignq ymm {k1}{z}, ymm, m256, imm8 |  | 
        /// </summary>
        [Symbol("valignq ymm {k1}{z}, ymm, m256, imm8","valignq ymm {k1}{z}, ymm, m256, imm8 |  | ")]
        valignq_ymm_k1z_ymm_m256_imm8 = 1711,

        /// <summary>
        /// valignq ymm {k1}{z}, ymm, m64bcst, imm8 |  | 
        /// </summary>
        [Symbol("valignq ymm {k1}{z}, ymm, m64bcst, imm8","valignq ymm {k1}{z}, ymm, m64bcst, imm8 |  | ")]
        valignq_ymm_k1z_ymm_m64bcst_imm8 = 1712,

        /// <summary>
        /// valignq ymm {k1}{z}, ymm, ymm, imm8 |  | 
        /// </summary>
        [Symbol("valignq ymm {k1}{z}, ymm, ymm, imm8","valignq ymm {k1}{z}, ymm, ymm, imm8 |  | ")]
        valignq_ymm_k1z_ymm_ymm_imm8 = 1713,

        /// <summary>
        /// valignq ymm, ymm, m256, imm8 |  | 
        /// </summary>
        [Symbol("valignq ymm, ymm, m256, imm8","valignq ymm, ymm, m256, imm8 |  | ")]
        valignq_ymm_ymm_m256_imm8 = 1714,

        /// <summary>
        /// valignq ymm, ymm, m64bcst, imm8 |  | 
        /// </summary>
        [Symbol("valignq ymm, ymm, m64bcst, imm8","valignq ymm, ymm, m64bcst, imm8 |  | ")]
        valignq_ymm_ymm_m64bcst_imm8 = 1715,

        /// <summary>
        /// valignq ymm, ymm, ymm, imm8 |  | 
        /// </summary>
        [Symbol("valignq ymm, ymm, ymm, imm8","valignq ymm, ymm, ymm, imm8 |  | ")]
        valignq_ymm_ymm_ymm_imm8 = 1716,

        /// <summary>
        /// valignq zmm {k1}{z}, zmm, m512, imm8 |  | 
        /// </summary>
        [Symbol("valignq zmm {k1}{z}, zmm, m512, imm8","valignq zmm {k1}{z}, zmm, m512, imm8 |  | ")]
        valignq_zmm_k1z_zmm_m512_imm8 = 1717,

        /// <summary>
        /// valignq zmm {k1}{z}, zmm, m64bcst, imm8 |  | 
        /// </summary>
        [Symbol("valignq zmm {k1}{z}, zmm, m64bcst, imm8","valignq zmm {k1}{z}, zmm, m64bcst, imm8 |  | ")]
        valignq_zmm_k1z_zmm_m64bcst_imm8 = 1718,

        /// <summary>
        /// valignq zmm {k1}{z}, zmm, zmm, imm8 |  | 
        /// </summary>
        [Symbol("valignq zmm {k1}{z}, zmm, zmm, imm8","valignq zmm {k1}{z}, zmm, zmm, imm8 |  | ")]
        valignq_zmm_k1z_zmm_zmm_imm8 = 1719,

        /// <summary>
        /// valignq zmm, zmm, m512, imm8 |  | 
        /// </summary>
        [Symbol("valignq zmm, zmm, m512, imm8","valignq zmm, zmm, m512, imm8 |  | ")]
        valignq_zmm_zmm_m512_imm8 = 1720,

        /// <summary>
        /// valignq zmm, zmm, m64bcst, imm8 |  | 
        /// </summary>
        [Symbol("valignq zmm, zmm, m64bcst, imm8","valignq zmm, zmm, m64bcst, imm8 |  | ")]
        valignq_zmm_zmm_m64bcst_imm8 = 1721,

        /// <summary>
        /// valignq zmm, zmm, zmm, imm8 |  | 
        /// </summary>
        [Symbol("valignq zmm, zmm, zmm, imm8","valignq zmm, zmm, zmm, imm8 |  | ")]
        valignq_zmm_zmm_zmm_imm8 = 1722,

        /// <summary>
        /// vbroadcasti128 ymm, m128 |  | 
        /// </summary>
        [Symbol("vbroadcasti128 ymm, m128","vbroadcasti128 ymm, m128 |  | ")]
        vbroadcasti128_ymm_m128 = 1723,

        /// <summary>
        /// vbroadcasti32x2 xmm {k1}{z}, m64 |  | 
        /// </summary>
        [Symbol("vbroadcasti32x2 xmm {k1}{z}, m64","vbroadcasti32x2 xmm {k1}{z}, m64 |  | ")]
        vbroadcasti32x2_xmm_k1z_m64 = 1724,

        /// <summary>
        /// vbroadcasti32x2 xmm {k1}{z}, r8 |  | 
        /// </summary>
        [Symbol("vbroadcasti32x2 xmm {k1}{z}, r8","vbroadcasti32x2 xmm {k1}{z}, r8 |  | ")]
        vbroadcasti32x2_xmm_k1z_r8 = 1725,

        /// <summary>
        /// vbroadcasti32x2 xmm, m64 |  | 
        /// </summary>
        [Symbol("vbroadcasti32x2 xmm, m64","vbroadcasti32x2 xmm, m64 |  | ")]
        vbroadcasti32x2_xmm_m64 = 1726,

        /// <summary>
        /// vbroadcasti32x2 xmm, r8 |  | 
        /// </summary>
        [Symbol("vbroadcasti32x2 xmm, r8","vbroadcasti32x2 xmm, r8 |  | ")]
        vbroadcasti32x2_xmm_r8 = 1727,

        /// <summary>
        /// vbroadcasti32x2 ymm {k1}{z}, m64 |  | 
        /// </summary>
        [Symbol("vbroadcasti32x2 ymm {k1}{z}, m64","vbroadcasti32x2 ymm {k1}{z}, m64 |  | ")]
        vbroadcasti32x2_ymm_k1z_m64 = 1728,

        /// <summary>
        /// vbroadcasti32x2 ymm {k1}{z}, r8 |  | 
        /// </summary>
        [Symbol("vbroadcasti32x2 ymm {k1}{z}, r8","vbroadcasti32x2 ymm {k1}{z}, r8 |  | ")]
        vbroadcasti32x2_ymm_k1z_r8 = 1729,

        /// <summary>
        /// vbroadcasti32x2 ymm, m64 |  | 
        /// </summary>
        [Symbol("vbroadcasti32x2 ymm, m64","vbroadcasti32x2 ymm, m64 |  | ")]
        vbroadcasti32x2_ymm_m64 = 1730,

        /// <summary>
        /// vbroadcasti32x2 ymm, r8 |  | 
        /// </summary>
        [Symbol("vbroadcasti32x2 ymm, r8","vbroadcasti32x2 ymm, r8 |  | ")]
        vbroadcasti32x2_ymm_r8 = 1731,

        /// <summary>
        /// vbroadcasti32x2 zmm {k1}{z}, m64 |  | 
        /// </summary>
        [Symbol("vbroadcasti32x2 zmm {k1}{z}, m64","vbroadcasti32x2 zmm {k1}{z}, m64 |  | ")]
        vbroadcasti32x2_zmm_k1z_m64 = 1732,

        /// <summary>
        /// vbroadcasti32x2 zmm {k1}{z}, r8 |  | 
        /// </summary>
        [Symbol("vbroadcasti32x2 zmm {k1}{z}, r8","vbroadcasti32x2 zmm {k1}{z}, r8 |  | ")]
        vbroadcasti32x2_zmm_k1z_r8 = 1733,

        /// <summary>
        /// vbroadcasti32x2 zmm, m64 |  | 
        /// </summary>
        [Symbol("vbroadcasti32x2 zmm, m64","vbroadcasti32x2 zmm, m64 |  | ")]
        vbroadcasti32x2_zmm_m64 = 1734,

        /// <summary>
        /// vbroadcasti32x2 zmm, r8 |  | 
        /// </summary>
        [Symbol("vbroadcasti32x2 zmm, r8","vbroadcasti32x2 zmm, r8 |  | ")]
        vbroadcasti32x2_zmm_r8 = 1735,

        /// <summary>
        /// vbroadcasti32x4 ymm {k1}{z}, m128 |  | 
        /// </summary>
        [Symbol("vbroadcasti32x4 ymm {k1}{z}, m128","vbroadcasti32x4 ymm {k1}{z}, m128 |  | ")]
        vbroadcasti32x4_ymm_k1z_m128 = 1736,

        /// <summary>
        /// vbroadcasti32x4 ymm, m128 |  | 
        /// </summary>
        [Symbol("vbroadcasti32x4 ymm, m128","vbroadcasti32x4 ymm, m128 |  | ")]
        vbroadcasti32x4_ymm_m128 = 1737,

        /// <summary>
        /// vbroadcasti32x4 zmm {k1}{z}, m128 |  | 
        /// </summary>
        [Symbol("vbroadcasti32x4 zmm {k1}{z}, m128","vbroadcasti32x4 zmm {k1}{z}, m128 |  | ")]
        vbroadcasti32x4_zmm_k1z_m128 = 1738,

        /// <summary>
        /// vbroadcasti32x4 zmm, m128 |  | 
        /// </summary>
        [Symbol("vbroadcasti32x4 zmm, m128","vbroadcasti32x4 zmm, m128 |  | ")]
        vbroadcasti32x4_zmm_m128 = 1739,

        /// <summary>
        /// vbroadcasti32x8 zmm {k1}{z}, m256 |  | 
        /// </summary>
        [Symbol("vbroadcasti32x8 zmm {k1}{z}, m256","vbroadcasti32x8 zmm {k1}{z}, m256 |  | ")]
        vbroadcasti32x8_zmm_k1z_m256 = 1740,

        /// <summary>
        /// vbroadcasti32x8 zmm, m256 |  | 
        /// </summary>
        [Symbol("vbroadcasti32x8 zmm, m256","vbroadcasti32x8 zmm, m256 |  | ")]
        vbroadcasti32x8_zmm_m256 = 1741,

        /// <summary>
        /// vbroadcasti64x2 ymm {k1}{z}, m128 |  | 
        /// </summary>
        [Symbol("vbroadcasti64x2 ymm {k1}{z}, m128","vbroadcasti64x2 ymm {k1}{z}, m128 |  | ")]
        vbroadcasti64x2_ymm_k1z_m128 = 1742,

        /// <summary>
        /// vbroadcasti64x2 ymm, m128 |  | 
        /// </summary>
        [Symbol("vbroadcasti64x2 ymm, m128","vbroadcasti64x2 ymm, m128 |  | ")]
        vbroadcasti64x2_ymm_m128 = 1743,

        /// <summary>
        /// vbroadcasti64x2 zmm {k1}{z}, m128 |  | 
        /// </summary>
        [Symbol("vbroadcasti64x2 zmm {k1}{z}, m128","vbroadcasti64x2 zmm {k1}{z}, m128 |  | ")]
        vbroadcasti64x2_zmm_k1z_m128 = 1744,

        /// <summary>
        /// vbroadcasti64x2 zmm, m128 |  | 
        /// </summary>
        [Symbol("vbroadcasti64x2 zmm, m128","vbroadcasti64x2 zmm, m128 |  | ")]
        vbroadcasti64x2_zmm_m128 = 1745,

        /// <summary>
        /// vbroadcasti64x4 zmm {k1}{z}, m256 |  | 
        /// </summary>
        [Symbol("vbroadcasti64x4 zmm {k1}{z}, m256","vbroadcasti64x4 zmm {k1}{z}, m256 |  | ")]
        vbroadcasti64x4_zmm_k1z_m256 = 1746,

        /// <summary>
        /// vbroadcasti64x4 zmm, m256 |  | 
        /// </summary>
        [Symbol("vbroadcasti64x4 zmm, m256","vbroadcasti64x4 zmm, m256 |  | ")]
        vbroadcasti64x4_zmm_m256 = 1747,

        /// <summary>
        /// vcmpps k1 {k2}, xmm, m128, imm8 |  | 
        /// </summary>
        [Symbol("vcmpps k1 {k2}, xmm, m128, imm8","vcmpps k1 {k2}, xmm, m128, imm8 |  | ")]
        vcmpps_k1_k2_xmm_m128_imm8 = 1748,

        /// <summary>
        /// vcmpps k1 {k2}, xmm, m32bcst, imm8 |  | 
        /// </summary>
        [Symbol("vcmpps k1 {k2}, xmm, m32bcst, imm8","vcmpps k1 {k2}, xmm, m32bcst, imm8 |  | ")]
        vcmpps_k1_k2_xmm_m32bcst_imm8 = 1749,

        /// <summary>
        /// vcmpps k1 {k2}, xmm, xmm, imm8 |  | 
        /// </summary>
        [Symbol("vcmpps k1 {k2}, xmm, xmm, imm8","vcmpps k1 {k2}, xmm, xmm, imm8 |  | ")]
        vcmpps_k1_k2_xmm_xmm_imm8 = 1750,

        /// <summary>
        /// vcmpps k1 {k2}, ymm, m256, imm8 |  | 
        /// </summary>
        [Symbol("vcmpps k1 {k2}, ymm, m256, imm8","vcmpps k1 {k2}, ymm, m256, imm8 |  | ")]
        vcmpps_k1_k2_ymm_m256_imm8 = 1751,

        /// <summary>
        /// vcmpps k1 {k2}, ymm, m32bcst, imm8 |  | 
        /// </summary>
        [Symbol("vcmpps k1 {k2}, ymm, m32bcst, imm8","vcmpps k1 {k2}, ymm, m32bcst, imm8 |  | ")]
        vcmpps_k1_k2_ymm_m32bcst_imm8 = 1752,

        /// <summary>
        /// vcmpps k1 {k2}, ymm, ymm, imm8 |  | 
        /// </summary>
        [Symbol("vcmpps k1 {k2}, ymm, ymm, imm8","vcmpps k1 {k2}, ymm, ymm, imm8 |  | ")]
        vcmpps_k1_k2_ymm_ymm_imm8 = 1753,

        /// <summary>
        /// vcmpps k1 {k2}, zmm, m32bcst {k1}, imm8 |  | 
        /// </summary>
        [Symbol("vcmpps k1 {k2}, zmm, m32bcst {k1}, imm8","vcmpps k1 {k2}, zmm, m32bcst {k1}, imm8 |  | ")]
        vcmpps_k1_k2_zmm_m32bcst_k1_imm8 = 1754,

        /// <summary>
        /// vcmpps k1 {k2}, zmm, m512 {k1}, imm8 |  | 
        /// </summary>
        [Symbol("vcmpps k1 {k2}, zmm, m512 {k1}, imm8","vcmpps k1 {k2}, zmm, m512 {k1}, imm8 |  | ")]
        vcmpps_k1_k2_zmm_m512_k1_imm8 = 1755,

        /// <summary>
        /// vcmpps k1 {k2}, zmm, zmm {k1}, imm8 |  | 
        /// </summary>
        [Symbol("vcmpps k1 {k2}, zmm, zmm {k1}, imm8","vcmpps k1 {k2}, zmm, zmm {k1}, imm8 |  | ")]
        vcmpps_k1_k2_zmm_zmm_k1_imm8 = 1756,

        /// <summary>
        /// vcmpps k1, xmm, m128, imm8 |  | 
        /// </summary>
        [Symbol("vcmpps k1, xmm, m128, imm8","vcmpps k1, xmm, m128, imm8 |  | ")]
        vcmpps_k1_xmm_m128_imm8 = 1757,

        /// <summary>
        /// vcmpps k1, xmm, m32bcst, imm8 |  | 
        /// </summary>
        [Symbol("vcmpps k1, xmm, m32bcst, imm8","vcmpps k1, xmm, m32bcst, imm8 |  | ")]
        vcmpps_k1_xmm_m32bcst_imm8 = 1758,

        /// <summary>
        /// vcmpps k1, xmm, xmm, imm8 |  | 
        /// </summary>
        [Symbol("vcmpps k1, xmm, xmm, imm8","vcmpps k1, xmm, xmm, imm8 |  | ")]
        vcmpps_k1_xmm_xmm_imm8 = 1759,

        /// <summary>
        /// vcmpps k1, ymm, m256, imm8 |  | 
        /// </summary>
        [Symbol("vcmpps k1, ymm, m256, imm8","vcmpps k1, ymm, m256, imm8 |  | ")]
        vcmpps_k1_ymm_m256_imm8 = 1760,

        /// <summary>
        /// vcmpps k1, ymm, m32bcst, imm8 |  | 
        /// </summary>
        [Symbol("vcmpps k1, ymm, m32bcst, imm8","vcmpps k1, ymm, m32bcst, imm8 |  | ")]
        vcmpps_k1_ymm_m32bcst_imm8 = 1761,

        /// <summary>
        /// vcmpps k1, ymm, ymm, imm8 |  | 
        /// </summary>
        [Symbol("vcmpps k1, ymm, ymm, imm8","vcmpps k1, ymm, ymm, imm8 |  | ")]
        vcmpps_k1_ymm_ymm_imm8 = 1762,

        /// <summary>
        /// vcmpps k1, zmm, m32bcst, imm8 |  | 
        /// </summary>
        [Symbol("vcmpps k1, zmm, m32bcst, imm8","vcmpps k1, zmm, m32bcst, imm8 |  | ")]
        vcmpps_k1_zmm_m32bcst_imm8 = 1763,

        /// <summary>
        /// vcmpps k1, zmm, m512, imm8 |  | 
        /// </summary>
        [Symbol("vcmpps k1, zmm, m512, imm8","vcmpps k1, zmm, m512, imm8 |  | ")]
        vcmpps_k1_zmm_m512_imm8 = 1764,

        /// <summary>
        /// vcmpps k1, zmm, zmm, imm8 |  | 
        /// </summary>
        [Symbol("vcmpps k1, zmm, zmm, imm8","vcmpps k1, zmm, zmm, imm8 |  | ")]
        vcmpps_k1_zmm_zmm_imm8 = 1765,

        /// <summary>
        /// vcmpps xmm, xmm, m128, imm8 |  | 
        /// </summary>
        [Symbol("vcmpps xmm, xmm, m128, imm8","vcmpps xmm, xmm, m128, imm8 |  | ")]
        vcmpps_xmm_xmm_m128_imm8 = 1766,

        /// <summary>
        /// vcmpps xmm, xmm, r8, imm8 |  | 
        /// </summary>
        [Symbol("vcmpps xmm, xmm, r8, imm8","vcmpps xmm, xmm, r8, imm8 |  | ")]
        vcmpps_xmm_xmm_r8_imm8 = 1767,

        /// <summary>
        /// vcmpps ymm, ymm, m256, imm8 |  | 
        /// </summary>
        [Symbol("vcmpps ymm, ymm, m256, imm8","vcmpps ymm, ymm, m256, imm8 |  | ")]
        vcmpps_ymm_ymm_m256_imm8 = 1768,

        /// <summary>
        /// vcmpps ymm, ymm, r16, imm8 |  | 
        /// </summary>
        [Symbol("vcmpps ymm, ymm, r16, imm8","vcmpps ymm, ymm, r16, imm8 |  | ")]
        vcmpps_ymm_ymm_r16_imm8 = 1769,

        /// <summary>
        /// vcmpss k1 {k2}, xmm, m32 {k1}, imm8 |  | 
        /// </summary>
        [Symbol("vcmpss k1 {k2}, xmm, m32 {k1}, imm8","vcmpss k1 {k2}, xmm, m32 {k1}, imm8 |  | ")]
        vcmpss_k1_k2_xmm_m32_k1_imm8 = 1770,

        /// <summary>
        /// vcmpss k1 {k2}, xmm, r8 {k1}, imm8 |  | 
        /// </summary>
        [Symbol("vcmpss k1 {k2}, xmm, r8 {k1}, imm8","vcmpss k1 {k2}, xmm, r8 {k1}, imm8 |  | ")]
        vcmpss_k1_k2_xmm_r8_k1_imm8 = 1771,

        /// <summary>
        /// vcmpss k1, xmm, m32, imm8 |  | 
        /// </summary>
        [Symbol("vcmpss k1, xmm, m32, imm8","vcmpss k1, xmm, m32, imm8 |  | ")]
        vcmpss_k1_xmm_m32_imm8 = 1772,

        /// <summary>
        /// vcmpss k1, xmm, r8, imm8 |  | 
        /// </summary>
        [Symbol("vcmpss k1, xmm, r8, imm8","vcmpss k1, xmm, r8, imm8 |  | ")]
        vcmpss_k1_xmm_r8_imm8 = 1773,

        /// <summary>
        /// vcmpss xmm, xmm, m32, imm8 |  | 
        /// </summary>
        [Symbol("vcmpss xmm, xmm, m32, imm8","vcmpss xmm, xmm, m32, imm8 |  | ")]
        vcmpss_xmm_xmm_m32_imm8 = 1774,

        /// <summary>
        /// vcmpss xmm, xmm, r8, imm8 |  | 
        /// </summary>
        [Symbol("vcmpss xmm, xmm, r8, imm8","vcmpss xmm, xmm, r8, imm8 |  | ")]
        vcmpss_xmm_xmm_r8_imm8 = 1775,

        /// <summary>
        /// vdbpsadbw xmm {k1}{z}, xmm, m128, imm8 |  | 
        /// </summary>
        [Symbol("vdbpsadbw xmm {k1}{z}, xmm, m128, imm8","vdbpsadbw xmm {k1}{z}, xmm, m128, imm8 |  | ")]
        vdbpsadbw_xmm_k1z_xmm_m128_imm8 = 1776,

        /// <summary>
        /// vdbpsadbw xmm {k1}{z}, xmm, r8, imm8 |  | 
        /// </summary>
        [Symbol("vdbpsadbw xmm {k1}{z}, xmm, r8, imm8","vdbpsadbw xmm {k1}{z}, xmm, r8, imm8 |  | ")]
        vdbpsadbw_xmm_k1z_xmm_r8_imm8 = 1777,

        /// <summary>
        /// vdbpsadbw xmm, xmm, m128, imm8 |  | 
        /// </summary>
        [Symbol("vdbpsadbw xmm, xmm, m128, imm8","vdbpsadbw xmm, xmm, m128, imm8 |  | ")]
        vdbpsadbw_xmm_xmm_m128_imm8 = 1778,

        /// <summary>
        /// vdbpsadbw xmm, xmm, r8, imm8 |  | 
        /// </summary>
        [Symbol("vdbpsadbw xmm, xmm, r8, imm8","vdbpsadbw xmm, xmm, r8, imm8 |  | ")]
        vdbpsadbw_xmm_xmm_r8_imm8 = 1779,

        /// <summary>
        /// vdbpsadbw ymm {k1}{z}, ymm, m256, imm8 |  | 
        /// </summary>
        [Symbol("vdbpsadbw ymm {k1}{z}, ymm, m256, imm8","vdbpsadbw ymm {k1}{z}, ymm, m256, imm8 |  | ")]
        vdbpsadbw_ymm_k1z_ymm_m256_imm8 = 1780,

        /// <summary>
        /// vdbpsadbw ymm {k1}{z}, ymm, r16, imm8 |  | 
        /// </summary>
        [Symbol("vdbpsadbw ymm {k1}{z}, ymm, r16, imm8","vdbpsadbw ymm {k1}{z}, ymm, r16, imm8 |  | ")]
        vdbpsadbw_ymm_k1z_ymm_r16_imm8 = 1781,

        /// <summary>
        /// vdbpsadbw ymm, ymm, m256, imm8 |  | 
        /// </summary>
        [Symbol("vdbpsadbw ymm, ymm, m256, imm8","vdbpsadbw ymm, ymm, m256, imm8 |  | ")]
        vdbpsadbw_ymm_ymm_m256_imm8 = 1782,

        /// <summary>
        /// vdbpsadbw ymm, ymm, r16, imm8 |  | 
        /// </summary>
        [Symbol("vdbpsadbw ymm, ymm, r16, imm8","vdbpsadbw ymm, ymm, r16, imm8 |  | ")]
        vdbpsadbw_ymm_ymm_r16_imm8 = 1783,

        /// <summary>
        /// vdbpsadbw zmm {k1}{z}, zmm, m512, imm8 |  | 
        /// </summary>
        [Symbol("vdbpsadbw zmm {k1}{z}, zmm, m512, imm8","vdbpsadbw zmm {k1}{z}, zmm, m512, imm8 |  | ")]
        vdbpsadbw_zmm_k1z_zmm_m512_imm8 = 1784,

        /// <summary>
        /// vdbpsadbw zmm {k1}{z}, zmm, r32, imm8 |  | 
        /// </summary>
        [Symbol("vdbpsadbw zmm {k1}{z}, zmm, r32, imm8","vdbpsadbw zmm {k1}{z}, zmm, r32, imm8 |  | ")]
        vdbpsadbw_zmm_k1z_zmm_r32_imm8 = 1785,

        /// <summary>
        /// vdbpsadbw zmm, zmm, m512, imm8 |  | 
        /// </summary>
        [Symbol("vdbpsadbw zmm, zmm, m512, imm8","vdbpsadbw zmm, zmm, m512, imm8 |  | ")]
        vdbpsadbw_zmm_zmm_m512_imm8 = 1786,

        /// <summary>
        /// vdbpsadbw zmm, zmm, r32, imm8 |  | 
        /// </summary>
        [Symbol("vdbpsadbw zmm, zmm, r32, imm8","vdbpsadbw zmm, zmm, r32, imm8 |  | ")]
        vdbpsadbw_zmm_zmm_r32_imm8 = 1787,

        /// <summary>
        /// vextracti128 m128, ymm, imm8 |  | 
        /// </summary>
        [Symbol("vextracti128 m128, ymm, imm8","vextracti128 m128, ymm, imm8 |  | ")]
        vextracti128_m128_ymm_imm8 = 1788,

        /// <summary>
        /// vextracti128 r8, ymm, imm8 |  | 
        /// </summary>
        [Symbol("vextracti128 r8, ymm, imm8","vextracti128 r8, ymm, imm8 |  | ")]
        vextracti128_r8_ymm_imm8 = 1789,

        /// <summary>
        /// vextracti32x4 m128 {k1}{z}, ymm, imm8 |  | 
        /// </summary>
        [Symbol("vextracti32x4 m128 {k1}{z}, ymm, imm8","vextracti32x4 m128 {k1}{z}, ymm, imm8 |  | ")]
        vextracti32x4_m128_k1z_ymm_imm8 = 1790,

        /// <summary>
        /// vextracti32x4 m128 {k1}{z}, zmm, imm8 |  | 
        /// </summary>
        [Symbol("vextracti32x4 m128 {k1}{z}, zmm, imm8","vextracti32x4 m128 {k1}{z}, zmm, imm8 |  | ")]
        vextracti32x4_m128_k1z_zmm_imm8 = 1791,

        /// <summary>
        /// vextracti32x4 m128, ymm, imm8 |  | 
        /// </summary>
        [Symbol("vextracti32x4 m128, ymm, imm8","vextracti32x4 m128, ymm, imm8 |  | ")]
        vextracti32x4_m128_ymm_imm8 = 1792,

        /// <summary>
        /// vextracti32x4 m128, zmm, imm8 |  | 
        /// </summary>
        [Symbol("vextracti32x4 m128, zmm, imm8","vextracti32x4 m128, zmm, imm8 |  | ")]
        vextracti32x4_m128_zmm_imm8 = 1793,

        /// <summary>
        /// vextracti32x4 r8 {k1}{z}, ymm, imm8 |  | 
        /// </summary>
        [Symbol("vextracti32x4 r8 {k1}{z}, ymm, imm8","vextracti32x4 r8 {k1}{z}, ymm, imm8 |  | ")]
        vextracti32x4_r8_k1z_ymm_imm8 = 1794,

        /// <summary>
        /// vextracti32x4 r8 {k1}{z}, zmm, imm8 |  | 
        /// </summary>
        [Symbol("vextracti32x4 r8 {k1}{z}, zmm, imm8","vextracti32x4 r8 {k1}{z}, zmm, imm8 |  | ")]
        vextracti32x4_r8_k1z_zmm_imm8 = 1795,

        /// <summary>
        /// vextracti32x4 r8, ymm, imm8 |  | 
        /// </summary>
        [Symbol("vextracti32x4 r8, ymm, imm8","vextracti32x4 r8, ymm, imm8 |  | ")]
        vextracti32x4_r8_ymm_imm8 = 1796,

        /// <summary>
        /// vextracti32x4 r8, zmm, imm8 |  | 
        /// </summary>
        [Symbol("vextracti32x4 r8, zmm, imm8","vextracti32x4 r8, zmm, imm8 |  | ")]
        vextracti32x4_r8_zmm_imm8 = 1797,

        /// <summary>
        /// vextracti32x8 m256 {k1}{z}, zmm, imm8 |  | 
        /// </summary>
        [Symbol("vextracti32x8 m256 {k1}{z}, zmm, imm8","vextracti32x8 m256 {k1}{z}, zmm, imm8 |  | ")]
        vextracti32x8_m256_k1z_zmm_imm8 = 1798,

        /// <summary>
        /// vextracti32x8 m256, zmm, imm8 |  | 
        /// </summary>
        [Symbol("vextracti32x8 m256, zmm, imm8","vextracti32x8 m256, zmm, imm8 |  | ")]
        vextracti32x8_m256_zmm_imm8 = 1799,

        /// <summary>
        /// vextracti32x8 r16 {k1}{z}, zmm, imm8 |  | 
        /// </summary>
        [Symbol("vextracti32x8 r16 {k1}{z}, zmm, imm8","vextracti32x8 r16 {k1}{z}, zmm, imm8 |  | ")]
        vextracti32x8_r16_k1z_zmm_imm8 = 1800,

        /// <summary>
        /// vextracti32x8 r16, zmm, imm8 |  | 
        /// </summary>
        [Symbol("vextracti32x8 r16, zmm, imm8","vextracti32x8 r16, zmm, imm8 |  | ")]
        vextracti32x8_r16_zmm_imm8 = 1801,

        /// <summary>
        /// vextracti64x2 m128 {k1}{z}, ymm, imm8 |  | 
        /// </summary>
        [Symbol("vextracti64x2 m128 {k1}{z}, ymm, imm8","vextracti64x2 m128 {k1}{z}, ymm, imm8 |  | ")]
        vextracti64x2_m128_k1z_ymm_imm8 = 1802,

        /// <summary>
        /// vextracti64x2 m128 {k1}{z}, zmm, imm8 |  | 
        /// </summary>
        [Symbol("vextracti64x2 m128 {k1}{z}, zmm, imm8","vextracti64x2 m128 {k1}{z}, zmm, imm8 |  | ")]
        vextracti64x2_m128_k1z_zmm_imm8 = 1803,

        /// <summary>
        /// vextracti64x2 m128, ymm, imm8 |  | 
        /// </summary>
        [Symbol("vextracti64x2 m128, ymm, imm8","vextracti64x2 m128, ymm, imm8 |  | ")]
        vextracti64x2_m128_ymm_imm8 = 1804,

        /// <summary>
        /// vextracti64x2 m128, zmm, imm8 |  | 
        /// </summary>
        [Symbol("vextracti64x2 m128, zmm, imm8","vextracti64x2 m128, zmm, imm8 |  | ")]
        vextracti64x2_m128_zmm_imm8 = 1805,

        /// <summary>
        /// vextracti64x2 r8 {k1}{z}, ymm, imm8 |  | 
        /// </summary>
        [Symbol("vextracti64x2 r8 {k1}{z}, ymm, imm8","vextracti64x2 r8 {k1}{z}, ymm, imm8 |  | ")]
        vextracti64x2_r8_k1z_ymm_imm8 = 1806,

        /// <summary>
        /// vextracti64x2 r8 {k1}{z}, zmm, imm8 |  | 
        /// </summary>
        [Symbol("vextracti64x2 r8 {k1}{z}, zmm, imm8","vextracti64x2 r8 {k1}{z}, zmm, imm8 |  | ")]
        vextracti64x2_r8_k1z_zmm_imm8 = 1807,

        /// <summary>
        /// vextracti64x2 r8, ymm, imm8 |  | 
        /// </summary>
        [Symbol("vextracti64x2 r8, ymm, imm8","vextracti64x2 r8, ymm, imm8 |  | ")]
        vextracti64x2_r8_ymm_imm8 = 1808,

        /// <summary>
        /// vextracti64x2 r8, zmm, imm8 |  | 
        /// </summary>
        [Symbol("vextracti64x2 r8, zmm, imm8","vextracti64x2 r8, zmm, imm8 |  | ")]
        vextracti64x2_r8_zmm_imm8 = 1809,

        /// <summary>
        /// vextracti64x4 m256 {k1}{z}, zmm, imm8 |  | 
        /// </summary>
        [Symbol("vextracti64x4 m256 {k1}{z}, zmm, imm8","vextracti64x4 m256 {k1}{z}, zmm, imm8 |  | ")]
        vextracti64x4_m256_k1z_zmm_imm8 = 1810,

        /// <summary>
        /// vextracti64x4 m256, zmm, imm8 |  | 
        /// </summary>
        [Symbol("vextracti64x4 m256, zmm, imm8","vextracti64x4 m256, zmm, imm8 |  | ")]
        vextracti64x4_m256_zmm_imm8 = 1811,

        /// <summary>
        /// vextracti64x4 r16 {k1}{z}, zmm, imm8 |  | 
        /// </summary>
        [Symbol("vextracti64x4 r16 {k1}{z}, zmm, imm8","vextracti64x4 r16 {k1}{z}, zmm, imm8 |  | ")]
        vextracti64x4_r16_k1z_zmm_imm8 = 1812,

        /// <summary>
        /// vextracti64x4 r16, zmm, imm8 |  | 
        /// </summary>
        [Symbol("vextracti64x4 r16, zmm, imm8","vextracti64x4 r16, zmm, imm8 |  | ")]
        vextracti64x4_r16_zmm_imm8 = 1813,

        /// <summary>
        /// vinserti128 ymm, ymm, m128, imm8 |  | 
        /// </summary>
        [Symbol("vinserti128 ymm, ymm, m128, imm8","vinserti128 ymm, ymm, m128, imm8 |  | ")]
        vinserti128_ymm_ymm_m128_imm8 = 1814,

        /// <summary>
        /// vinserti128 ymm, ymm, r8, imm8 |  | 
        /// </summary>
        [Symbol("vinserti128 ymm, ymm, r8, imm8","vinserti128 ymm, ymm, r8, imm8 |  | ")]
        vinserti128_ymm_ymm_r8_imm8 = 1815,

        /// <summary>
        /// vinserti32x4 ymm {k1}{z}, ymm, m128, imm8 |  | 
        /// </summary>
        [Symbol("vinserti32x4 ymm {k1}{z}, ymm, m128, imm8","vinserti32x4 ymm {k1}{z}, ymm, m128, imm8 |  | ")]
        vinserti32x4_ymm_k1z_ymm_m128_imm8 = 1816,

        /// <summary>
        /// vinserti32x4 ymm {k1}{z}, ymm, r8, imm8 |  | 
        /// </summary>
        [Symbol("vinserti32x4 ymm {k1}{z}, ymm, r8, imm8","vinserti32x4 ymm {k1}{z}, ymm, r8, imm8 |  | ")]
        vinserti32x4_ymm_k1z_ymm_r8_imm8 = 1817,

        /// <summary>
        /// vinserti32x4 ymm, ymm, m128, imm8 |  | 
        /// </summary>
        [Symbol("vinserti32x4 ymm, ymm, m128, imm8","vinserti32x4 ymm, ymm, m128, imm8 |  | ")]
        vinserti32x4_ymm_ymm_m128_imm8 = 1818,

        /// <summary>
        /// vinserti32x4 ymm, ymm, r8, imm8 |  | 
        /// </summary>
        [Symbol("vinserti32x4 ymm, ymm, r8, imm8","vinserti32x4 ymm, ymm, r8, imm8 |  | ")]
        vinserti32x4_ymm_ymm_r8_imm8 = 1819,

        /// <summary>
        /// vinserti32x4 zmm {k1}{z}, zmm, m128, imm8 |  | 
        /// </summary>
        [Symbol("vinserti32x4 zmm {k1}{z}, zmm, m128, imm8","vinserti32x4 zmm {k1}{z}, zmm, m128, imm8 |  | ")]
        vinserti32x4_zmm_k1z_zmm_m128_imm8 = 1820,

        /// <summary>
        /// vinserti32x4 zmm {k1}{z}, zmm, r8, imm8 |  | 
        /// </summary>
        [Symbol("vinserti32x4 zmm {k1}{z}, zmm, r8, imm8","vinserti32x4 zmm {k1}{z}, zmm, r8, imm8 |  | ")]
        vinserti32x4_zmm_k1z_zmm_r8_imm8 = 1821,

        /// <summary>
        /// vinserti32x4 zmm, zmm, m128, imm8 |  | 
        /// </summary>
        [Symbol("vinserti32x4 zmm, zmm, m128, imm8","vinserti32x4 zmm, zmm, m128, imm8 |  | ")]
        vinserti32x4_zmm_zmm_m128_imm8 = 1822,

        /// <summary>
        /// vinserti32x4 zmm, zmm, r8, imm8 |  | 
        /// </summary>
        [Symbol("vinserti32x4 zmm, zmm, r8, imm8","vinserti32x4 zmm, zmm, r8, imm8 |  | ")]
        vinserti32x4_zmm_zmm_r8_imm8 = 1823,

        /// <summary>
        /// vinserti32x8 zmm {k1}{z}, zmm, m256, imm8 |  | 
        /// </summary>
        [Symbol("vinserti32x8 zmm {k1}{z}, zmm, m256, imm8","vinserti32x8 zmm {k1}{z}, zmm, m256, imm8 |  | ")]
        vinserti32x8_zmm_k1z_zmm_m256_imm8 = 1824,

        /// <summary>
        /// vinserti32x8 zmm {k1}{z}, zmm, r16, imm8 |  | 
        /// </summary>
        [Symbol("vinserti32x8 zmm {k1}{z}, zmm, r16, imm8","vinserti32x8 zmm {k1}{z}, zmm, r16, imm8 |  | ")]
        vinserti32x8_zmm_k1z_zmm_r16_imm8 = 1825,

        /// <summary>
        /// vinserti32x8 zmm, zmm, m256, imm8 |  | 
        /// </summary>
        [Symbol("vinserti32x8 zmm, zmm, m256, imm8","vinserti32x8 zmm, zmm, m256, imm8 |  | ")]
        vinserti32x8_zmm_zmm_m256_imm8 = 1826,

        /// <summary>
        /// vinserti32x8 zmm, zmm, r16, imm8 |  | 
        /// </summary>
        [Symbol("vinserti32x8 zmm, zmm, r16, imm8","vinserti32x8 zmm, zmm, r16, imm8 |  | ")]
        vinserti32x8_zmm_zmm_r16_imm8 = 1827,

        /// <summary>
        /// vinserti64x2 ymm {k1}{z}, ymm, m128, imm8 |  | 
        /// </summary>
        [Symbol("vinserti64x2 ymm {k1}{z}, ymm, m128, imm8","vinserti64x2 ymm {k1}{z}, ymm, m128, imm8 |  | ")]
        vinserti64x2_ymm_k1z_ymm_m128_imm8 = 1828,

        /// <summary>
        /// vinserti64x2 ymm {k1}{z}, ymm, r8, imm8 |  | 
        /// </summary>
        [Symbol("vinserti64x2 ymm {k1}{z}, ymm, r8, imm8","vinserti64x2 ymm {k1}{z}, ymm, r8, imm8 |  | ")]
        vinserti64x2_ymm_k1z_ymm_r8_imm8 = 1829,

        /// <summary>
        /// vinserti64x2 ymm, ymm, m128, imm8 |  | 
        /// </summary>
        [Symbol("vinserti64x2 ymm, ymm, m128, imm8","vinserti64x2 ymm, ymm, m128, imm8 |  | ")]
        vinserti64x2_ymm_ymm_m128_imm8 = 1830,

        /// <summary>
        /// vinserti64x2 ymm, ymm, r8, imm8 |  | 
        /// </summary>
        [Symbol("vinserti64x2 ymm, ymm, r8, imm8","vinserti64x2 ymm, ymm, r8, imm8 |  | ")]
        vinserti64x2_ymm_ymm_r8_imm8 = 1831,

        /// <summary>
        /// vinserti64x2 zmm {k1}{z}, zmm, m128, imm8 |  | 
        /// </summary>
        [Symbol("vinserti64x2 zmm {k1}{z}, zmm, m128, imm8","vinserti64x2 zmm {k1}{z}, zmm, m128, imm8 |  | ")]
        vinserti64x2_zmm_k1z_zmm_m128_imm8 = 1832,

        /// <summary>
        /// vinserti64x2 zmm {k1}{z}, zmm, r8, imm8 |  | 
        /// </summary>
        [Symbol("vinserti64x2 zmm {k1}{z}, zmm, r8, imm8","vinserti64x2 zmm {k1}{z}, zmm, r8, imm8 |  | ")]
        vinserti64x2_zmm_k1z_zmm_r8_imm8 = 1833,

        /// <summary>
        /// vinserti64x2 zmm, zmm, m128, imm8 |  | 
        /// </summary>
        [Symbol("vinserti64x2 zmm, zmm, m128, imm8","vinserti64x2 zmm, zmm, m128, imm8 |  | ")]
        vinserti64x2_zmm_zmm_m128_imm8 = 1834,

        /// <summary>
        /// vinserti64x2 zmm, zmm, r8, imm8 |  | 
        /// </summary>
        [Symbol("vinserti64x2 zmm, zmm, r8, imm8","vinserti64x2 zmm, zmm, r8, imm8 |  | ")]
        vinserti64x2_zmm_zmm_r8_imm8 = 1835,

        /// <summary>
        /// vinserti64x4 zmm {k1}{z}, zmm, m256, imm8 |  | 
        /// </summary>
        [Symbol("vinserti64x4 zmm {k1}{z}, zmm, m256, imm8","vinserti64x4 zmm {k1}{z}, zmm, m256, imm8 |  | ")]
        vinserti64x4_zmm_k1z_zmm_m256_imm8 = 1836,

        /// <summary>
        /// vinserti64x4 zmm {k1}{z}, zmm, r16, imm8 |  | 
        /// </summary>
        [Symbol("vinserti64x4 zmm {k1}{z}, zmm, r16, imm8","vinserti64x4 zmm {k1}{z}, zmm, r16, imm8 |  | ")]
        vinserti64x4_zmm_k1z_zmm_r16_imm8 = 1837,

        /// <summary>
        /// vinserti64x4 zmm, zmm, m256, imm8 |  | 
        /// </summary>
        [Symbol("vinserti64x4 zmm, zmm, m256, imm8","vinserti64x4 zmm, zmm, m256, imm8 |  | ")]
        vinserti64x4_zmm_zmm_m256_imm8 = 1838,

        /// <summary>
        /// vinserti64x4 zmm, zmm, r16, imm8 |  | 
        /// </summary>
        [Symbol("vinserti64x4 zmm, zmm, r16, imm8","vinserti64x4 zmm, zmm, r16, imm8 |  | ")]
        vinserti64x4_zmm_zmm_r16_imm8 = 1839,

        /// <summary>
        /// vlddqu xmm, m128 |  | 
        /// </summary>
        [Symbol("vlddqu xmm, m128","vlddqu xmm, m128 |  | ")]
        vlddqu_xmm_m128 = 1840,

        /// <summary>
        /// vlddqu ymm, m256 |  | 
        /// </summary>
        [Symbol("vlddqu ymm, m256","vlddqu ymm, m256 |  | ")]
        vlddqu_ymm_m256 = 1841,

        /// <summary>
        /// vmaskmovdqu xmm, xmm |  | 
        /// </summary>
        [Symbol("vmaskmovdqu xmm, xmm","vmaskmovdqu xmm, xmm |  | ")]
        vmaskmovdqu_xmm_xmm = 1842,

        /// <summary>
        /// vmaskmovpd m128, xmm, xmm |  | 
        /// </summary>
        [Symbol("vmaskmovpd m128, xmm, xmm","vmaskmovpd m128, xmm, xmm |  | ")]
        vmaskmovpd_m128_xmm_xmm = 1843,

        /// <summary>
        /// vmaskmovpd m256, ymm, ymm |  | 
        /// </summary>
        [Symbol("vmaskmovpd m256, ymm, ymm","vmaskmovpd m256, ymm, ymm |  | ")]
        vmaskmovpd_m256_ymm_ymm = 1844,

        /// <summary>
        /// vmaskmovpd xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vmaskmovpd xmm, xmm, m128","vmaskmovpd xmm, xmm, m128 |  | ")]
        vmaskmovpd_xmm_xmm_m128 = 1845,

        /// <summary>
        /// vmaskmovpd ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vmaskmovpd ymm, ymm, m256","vmaskmovpd ymm, ymm, m256 |  | ")]
        vmaskmovpd_ymm_ymm_m256 = 1846,

        /// <summary>
        /// vmaskmovps m128, xmm, xmm |  | 
        /// </summary>
        [Symbol("vmaskmovps m128, xmm, xmm","vmaskmovps m128, xmm, xmm |  | ")]
        vmaskmovps_m128_xmm_xmm = 1847,

        /// <summary>
        /// vmaskmovps m256, ymm, ymm |  | 
        /// </summary>
        [Symbol("vmaskmovps m256, ymm, ymm","vmaskmovps m256, ymm, ymm |  | ")]
        vmaskmovps_m256_ymm_ymm = 1848,

        /// <summary>
        /// vmaskmovps xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vmaskmovps xmm, xmm, m128","vmaskmovps xmm, xmm, m128 |  | ")]
        vmaskmovps_xmm_xmm_m128 = 1849,

        /// <summary>
        /// vmaskmovps ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vmaskmovps ymm, ymm, m256","vmaskmovps ymm, ymm, m256 |  | ")]
        vmaskmovps_ymm_ymm_m256 = 1850,

        /// <summary>
        /// vmovapd m128 {k1}{z}, xmm |  | 
        /// </summary>
        [Symbol("vmovapd m128 {k1}{z}, xmm","vmovapd m128 {k1}{z}, xmm |  | ")]
        vmovapd_m128_k1z_xmm = 1851,

        /// <summary>
        /// vmovapd m128, xmm |  | 
        /// </summary>
        [Symbol("vmovapd m128, xmm","vmovapd m128, xmm |  | ")]
        vmovapd_m128_xmm = 1852,

        /// <summary>
        /// vmovapd m256 {k1}{z}, ymm |  | 
        /// </summary>
        [Symbol("vmovapd m256 {k1}{z}, ymm","vmovapd m256 {k1}{z}, ymm |  | ")]
        vmovapd_m256_k1z_ymm = 1853,

        /// <summary>
        /// vmovapd m256, ymm |  | 
        /// </summary>
        [Symbol("vmovapd m256, ymm","vmovapd m256, ymm |  | ")]
        vmovapd_m256_ymm = 1854,

        /// <summary>
        /// vmovapd m512 {k1}{z}, zmm |  | 
        /// </summary>
        [Symbol("vmovapd m512 {k1}{z}, zmm","vmovapd m512 {k1}{z}, zmm |  | ")]
        vmovapd_m512_k1z_zmm = 1855,

        /// <summary>
        /// vmovapd m512, zmm |  | 
        /// </summary>
        [Symbol("vmovapd m512, zmm","vmovapd m512, zmm |  | ")]
        vmovapd_m512_zmm = 1856,

        /// <summary>
        /// vmovapd r16 {k1}{z}, ymm |  | 
        /// </summary>
        [Symbol("vmovapd r16 {k1}{z}, ymm","vmovapd r16 {k1}{z}, ymm |  | ")]
        vmovapd_r16_k1z_ymm = 1857,

        /// <summary>
        /// vmovapd r16, ymm |  | 
        /// </summary>
        [Symbol("vmovapd r16, ymm","vmovapd r16, ymm |  | ")]
        vmovapd_r16_ymm = 1858,

        /// <summary>
        /// vmovapd r32 {k1}{z}, zmm |  | 
        /// </summary>
        [Symbol("vmovapd r32 {k1}{z}, zmm","vmovapd r32 {k1}{z}, zmm |  | ")]
        vmovapd_r32_k1z_zmm = 1859,

        /// <summary>
        /// vmovapd r32, zmm |  | 
        /// </summary>
        [Symbol("vmovapd r32, zmm","vmovapd r32, zmm |  | ")]
        vmovapd_r32_zmm = 1860,

        /// <summary>
        /// vmovapd r8 {k1}{z}, xmm |  | 
        /// </summary>
        [Symbol("vmovapd r8 {k1}{z}, xmm","vmovapd r8 {k1}{z}, xmm |  | ")]
        vmovapd_r8_k1z_xmm = 1861,

        /// <summary>
        /// vmovapd r8, xmm |  | 
        /// </summary>
        [Symbol("vmovapd r8, xmm","vmovapd r8, xmm |  | ")]
        vmovapd_r8_xmm = 1862,

        /// <summary>
        /// vmovapd xmm {k1}{z}, m128 |  | 
        /// </summary>
        [Symbol("vmovapd xmm {k1}{z}, m128","vmovapd xmm {k1}{z}, m128 |  | ")]
        vmovapd_xmm_k1z_m128 = 1863,

        /// <summary>
        /// vmovapd xmm {k1}{z}, r8 |  | 
        /// </summary>
        [Symbol("vmovapd xmm {k1}{z}, r8","vmovapd xmm {k1}{z}, r8 |  | ")]
        vmovapd_xmm_k1z_r8 = 1864,

        /// <summary>
        /// vmovapd xmm, m128 |  | 
        /// </summary>
        [Symbol("vmovapd xmm, m128","vmovapd xmm, m128 |  | ")]
        vmovapd_xmm_m128 = 1865,

        /// <summary>
        /// vmovapd xmm, r8 |  | 
        /// </summary>
        [Symbol("vmovapd xmm, r8","vmovapd xmm, r8 |  | ")]
        vmovapd_xmm_r8 = 1866,

        /// <summary>
        /// vmovapd ymm {k1}{z}, m256 |  | 
        /// </summary>
        [Symbol("vmovapd ymm {k1}{z}, m256","vmovapd ymm {k1}{z}, m256 |  | ")]
        vmovapd_ymm_k1z_m256 = 1867,

        /// <summary>
        /// vmovapd ymm {k1}{z}, r16 |  | 
        /// </summary>
        [Symbol("vmovapd ymm {k1}{z}, r16","vmovapd ymm {k1}{z}, r16 |  | ")]
        vmovapd_ymm_k1z_r16 = 1868,

        /// <summary>
        /// vmovapd ymm, m256 |  | 
        /// </summary>
        [Symbol("vmovapd ymm, m256","vmovapd ymm, m256 |  | ")]
        vmovapd_ymm_m256 = 1869,

        /// <summary>
        /// vmovapd ymm, r16 |  | 
        /// </summary>
        [Symbol("vmovapd ymm, r16","vmovapd ymm, r16 |  | ")]
        vmovapd_ymm_r16 = 1870,

        /// <summary>
        /// vmovapd zmm {k1}{z}, m512 |  | 
        /// </summary>
        [Symbol("vmovapd zmm {k1}{z}, m512","vmovapd zmm {k1}{z}, m512 |  | ")]
        vmovapd_zmm_k1z_m512 = 1871,

        /// <summary>
        /// vmovapd zmm {k1}{z}, r32 |  | 
        /// </summary>
        [Symbol("vmovapd zmm {k1}{z}, r32","vmovapd zmm {k1}{z}, r32 |  | ")]
        vmovapd_zmm_k1z_r32 = 1872,

        /// <summary>
        /// vmovapd zmm, m512 |  | 
        /// </summary>
        [Symbol("vmovapd zmm, m512","vmovapd zmm, m512 |  | ")]
        vmovapd_zmm_m512 = 1873,

        /// <summary>
        /// vmovapd zmm, r32 |  | 
        /// </summary>
        [Symbol("vmovapd zmm, r32","vmovapd zmm, r32 |  | ")]
        vmovapd_zmm_r32 = 1874,

        /// <summary>
        /// vmovaps m128 {k1}{z}, xmm |  | 
        /// </summary>
        [Symbol("vmovaps m128 {k1}{z}, xmm","vmovaps m128 {k1}{z}, xmm |  | ")]
        vmovaps_m128_k1z_xmm = 1875,

        /// <summary>
        /// vmovaps m128, xmm |  | 
        /// </summary>
        [Symbol("vmovaps m128, xmm","vmovaps m128, xmm |  | ")]
        vmovaps_m128_xmm = 1876,

        /// <summary>
        /// vmovaps m256 {k1}{z}, ymm |  | 
        /// </summary>
        [Symbol("vmovaps m256 {k1}{z}, ymm","vmovaps m256 {k1}{z}, ymm |  | ")]
        vmovaps_m256_k1z_ymm = 1877,

        /// <summary>
        /// vmovaps m256, ymm |  | 
        /// </summary>
        [Symbol("vmovaps m256, ymm","vmovaps m256, ymm |  | ")]
        vmovaps_m256_ymm = 1878,

        /// <summary>
        /// vmovaps m512 {k1}{z}, zmm |  | 
        /// </summary>
        [Symbol("vmovaps m512 {k1}{z}, zmm","vmovaps m512 {k1}{z}, zmm |  | ")]
        vmovaps_m512_k1z_zmm = 1879,

        /// <summary>
        /// vmovaps m512, zmm |  | 
        /// </summary>
        [Symbol("vmovaps m512, zmm","vmovaps m512, zmm |  | ")]
        vmovaps_m512_zmm = 1880,

        /// <summary>
        /// vmovaps r16 {k1}{z}, ymm |  | 
        /// </summary>
        [Symbol("vmovaps r16 {k1}{z}, ymm","vmovaps r16 {k1}{z}, ymm |  | ")]
        vmovaps_r16_k1z_ymm = 1881,

        /// <summary>
        /// vmovaps r16, ymm |  | 
        /// </summary>
        [Symbol("vmovaps r16, ymm","vmovaps r16, ymm |  | ")]
        vmovaps_r16_ymm = 1882,

        /// <summary>
        /// vmovaps r32 {k1}{z}, zmm |  | 
        /// </summary>
        [Symbol("vmovaps r32 {k1}{z}, zmm","vmovaps r32 {k1}{z}, zmm |  | ")]
        vmovaps_r32_k1z_zmm = 1883,

        /// <summary>
        /// vmovaps r32, zmm |  | 
        /// </summary>
        [Symbol("vmovaps r32, zmm","vmovaps r32, zmm |  | ")]
        vmovaps_r32_zmm = 1884,

        /// <summary>
        /// vmovaps r8 {k1}{z}, xmm |  | 
        /// </summary>
        [Symbol("vmovaps r8 {k1}{z}, xmm","vmovaps r8 {k1}{z}, xmm |  | ")]
        vmovaps_r8_k1z_xmm = 1885,

        /// <summary>
        /// vmovaps r8, xmm |  | 
        /// </summary>
        [Symbol("vmovaps r8, xmm","vmovaps r8, xmm |  | ")]
        vmovaps_r8_xmm = 1886,

        /// <summary>
        /// vmovaps xmm {k1}{z}, m128 |  | 
        /// </summary>
        [Symbol("vmovaps xmm {k1}{z}, m128","vmovaps xmm {k1}{z}, m128 |  | ")]
        vmovaps_xmm_k1z_m128 = 1887,

        /// <summary>
        /// vmovaps xmm {k1}{z}, r8 |  | 
        /// </summary>
        [Symbol("vmovaps xmm {k1}{z}, r8","vmovaps xmm {k1}{z}, r8 |  | ")]
        vmovaps_xmm_k1z_r8 = 1888,

        /// <summary>
        /// vmovaps xmm, m128 |  | 
        /// </summary>
        [Symbol("vmovaps xmm, m128","vmovaps xmm, m128 |  | ")]
        vmovaps_xmm_m128 = 1889,

        /// <summary>
        /// vmovaps xmm, r8 |  | 
        /// </summary>
        [Symbol("vmovaps xmm, r8","vmovaps xmm, r8 |  | ")]
        vmovaps_xmm_r8 = 1890,

        /// <summary>
        /// vmovaps ymm {k1}{z}, m256 |  | 
        /// </summary>
        [Symbol("vmovaps ymm {k1}{z}, m256","vmovaps ymm {k1}{z}, m256 |  | ")]
        vmovaps_ymm_k1z_m256 = 1891,

        /// <summary>
        /// vmovaps ymm {k1}{z}, r16 |  | 
        /// </summary>
        [Symbol("vmovaps ymm {k1}{z}, r16","vmovaps ymm {k1}{z}, r16 |  | ")]
        vmovaps_ymm_k1z_r16 = 1892,

        /// <summary>
        /// vmovaps ymm, m256 |  | 
        /// </summary>
        [Symbol("vmovaps ymm, m256","vmovaps ymm, m256 |  | ")]
        vmovaps_ymm_m256 = 1893,

        /// <summary>
        /// vmovaps ymm, r16 |  | 
        /// </summary>
        [Symbol("vmovaps ymm, r16","vmovaps ymm, r16 |  | ")]
        vmovaps_ymm_r16 = 1894,

        /// <summary>
        /// vmovaps zmm {k1}{z}, m512 |  | 
        /// </summary>
        [Symbol("vmovaps zmm {k1}{z}, m512","vmovaps zmm {k1}{z}, m512 |  | ")]
        vmovaps_zmm_k1z_m512 = 1895,

        /// <summary>
        /// vmovaps zmm {k1}{z}, r32 |  | 
        /// </summary>
        [Symbol("vmovaps zmm {k1}{z}, r32","vmovaps zmm {k1}{z}, r32 |  | ")]
        vmovaps_zmm_k1z_r32 = 1896,

        /// <summary>
        /// vmovaps zmm, m512 |  | 
        /// </summary>
        [Symbol("vmovaps zmm, m512","vmovaps zmm, m512 |  | ")]
        vmovaps_zmm_m512 = 1897,

        /// <summary>
        /// vmovaps zmm, r32 |  | 
        /// </summary>
        [Symbol("vmovaps zmm, r32","vmovaps zmm, r32 |  | ")]
        vmovaps_zmm_r32 = 1898,

        /// <summary>
        /// vmovd m32, xmm |  | 
        /// </summary>
        [Symbol("vmovd m32, xmm","vmovd m32, xmm |  | ")]
        vmovd_m32_xmm = 1899,

        /// <summary>
        /// vmovd r32, xmm |  | 
        /// </summary>
        [Symbol("vmovd r32, xmm","vmovd r32, xmm |  | ")]
        vmovd_r32_xmm = 1900,

        /// <summary>
        /// vmovd xmm, m32 |  | 
        /// </summary>
        [Symbol("vmovd xmm, m32","vmovd xmm, m32 |  | ")]
        vmovd_xmm_m32 = 1901,

        /// <summary>
        /// vmovd xmm, r32 |  | 
        /// </summary>
        [Symbol("vmovd xmm, r32","vmovd xmm, r32 |  | ")]
        vmovd_xmm_r32 = 1902,

        /// <summary>
        /// vmovdqa m128, xmm |  | 
        /// </summary>
        [Symbol("vmovdqa m128, xmm","vmovdqa m128, xmm |  | ")]
        vmovdqa_m128_xmm = 1903,

        /// <summary>
        /// vmovdqa m256, ymm |  | 
        /// </summary>
        [Symbol("vmovdqa m256, ymm","vmovdqa m256, ymm |  | ")]
        vmovdqa_m256_ymm = 1904,

        /// <summary>
        /// vmovdqa r16, ymm |  | 
        /// </summary>
        [Symbol("vmovdqa r16, ymm","vmovdqa r16, ymm |  | ")]
        vmovdqa_r16_ymm = 1905,

        /// <summary>
        /// vmovdqa r8, xmm |  | 
        /// </summary>
        [Symbol("vmovdqa r8, xmm","vmovdqa r8, xmm |  | ")]
        vmovdqa_r8_xmm = 1906,

        /// <summary>
        /// vmovdqa xmm, m128 |  | 
        /// </summary>
        [Symbol("vmovdqa xmm, m128","vmovdqa xmm, m128 |  | ")]
        vmovdqa_xmm_m128 = 1907,

        /// <summary>
        /// vmovdqa xmm, r8 |  | 
        /// </summary>
        [Symbol("vmovdqa xmm, r8","vmovdqa xmm, r8 |  | ")]
        vmovdqa_xmm_r8 = 1908,

        /// <summary>
        /// vmovdqa ymm, m256 |  | 
        /// </summary>
        [Symbol("vmovdqa ymm, m256","vmovdqa ymm, m256 |  | ")]
        vmovdqa_ymm_m256 = 1909,

        /// <summary>
        /// vmovdqa ymm, r16 |  | 
        /// </summary>
        [Symbol("vmovdqa ymm, r16","vmovdqa ymm, r16 |  | ")]
        vmovdqa_ymm_r16 = 1910,

        /// <summary>
        /// vmovdqa32 m128 {k1}{z}, xmm |  | 
        /// </summary>
        [Symbol("vmovdqa32 m128 {k1}{z}, xmm","vmovdqa32 m128 {k1}{z}, xmm |  | ")]
        vmovdqa32_m128_k1z_xmm = 1911,

        /// <summary>
        /// vmovdqa32 m128, xmm |  | 
        /// </summary>
        [Symbol("vmovdqa32 m128, xmm","vmovdqa32 m128, xmm |  | ")]
        vmovdqa32_m128_xmm = 1912,

        /// <summary>
        /// vmovdqa32 m256 {k1}{z}, ymm |  | 
        /// </summary>
        [Symbol("vmovdqa32 m256 {k1}{z}, ymm","vmovdqa32 m256 {k1}{z}, ymm |  | ")]
        vmovdqa32_m256_k1z_ymm = 1913,

        /// <summary>
        /// vmovdqa32 m256, ymm |  | 
        /// </summary>
        [Symbol("vmovdqa32 m256, ymm","vmovdqa32 m256, ymm |  | ")]
        vmovdqa32_m256_ymm = 1914,

        /// <summary>
        /// vmovdqa32 m512 {k1}{z}, zmm |  | 
        /// </summary>
        [Symbol("vmovdqa32 m512 {k1}{z}, zmm","vmovdqa32 m512 {k1}{z}, zmm |  | ")]
        vmovdqa32_m512_k1z_zmm = 1915,

        /// <summary>
        /// vmovdqa32 m512, zmm |  | 
        /// </summary>
        [Symbol("vmovdqa32 m512, zmm","vmovdqa32 m512, zmm |  | ")]
        vmovdqa32_m512_zmm = 1916,

        /// <summary>
        /// vmovdqa32 r16 {k1}{z}, ymm |  | 
        /// </summary>
        [Symbol("vmovdqa32 r16 {k1}{z}, ymm","vmovdqa32 r16 {k1}{z}, ymm |  | ")]
        vmovdqa32_r16_k1z_ymm = 1917,

        /// <summary>
        /// vmovdqa32 r16, ymm |  | 
        /// </summary>
        [Symbol("vmovdqa32 r16, ymm","vmovdqa32 r16, ymm |  | ")]
        vmovdqa32_r16_ymm = 1918,

        /// <summary>
        /// vmovdqa32 r32 {k1}{z}, zmm |  | 
        /// </summary>
        [Symbol("vmovdqa32 r32 {k1}{z}, zmm","vmovdqa32 r32 {k1}{z}, zmm |  | ")]
        vmovdqa32_r32_k1z_zmm = 1919,

        /// <summary>
        /// vmovdqa32 r32, zmm |  | 
        /// </summary>
        [Symbol("vmovdqa32 r32, zmm","vmovdqa32 r32, zmm |  | ")]
        vmovdqa32_r32_zmm = 1920,

        /// <summary>
        /// vmovdqa32 r8 {k1}{z}, xmm |  | 
        /// </summary>
        [Symbol("vmovdqa32 r8 {k1}{z}, xmm","vmovdqa32 r8 {k1}{z}, xmm |  | ")]
        vmovdqa32_r8_k1z_xmm = 1921,

        /// <summary>
        /// vmovdqa32 r8, xmm |  | 
        /// </summary>
        [Symbol("vmovdqa32 r8, xmm","vmovdqa32 r8, xmm |  | ")]
        vmovdqa32_r8_xmm = 1922,

        /// <summary>
        /// vmovdqa32 xmm {k1}{z}, m128 |  | 
        /// </summary>
        [Symbol("vmovdqa32 xmm {k1}{z}, m128","vmovdqa32 xmm {k1}{z}, m128 |  | ")]
        vmovdqa32_xmm_k1z_m128 = 1923,

        /// <summary>
        /// vmovdqa32 xmm {k1}{z}, r8 |  | 
        /// </summary>
        [Symbol("vmovdqa32 xmm {k1}{z}, r8","vmovdqa32 xmm {k1}{z}, r8 |  | ")]
        vmovdqa32_xmm_k1z_r8 = 1924,

        /// <summary>
        /// vmovdqa32 xmm, m128 |  | 
        /// </summary>
        [Symbol("vmovdqa32 xmm, m128","vmovdqa32 xmm, m128 |  | ")]
        vmovdqa32_xmm_m128 = 1925,

        /// <summary>
        /// vmovdqa32 xmm, r8 |  | 
        /// </summary>
        [Symbol("vmovdqa32 xmm, r8","vmovdqa32 xmm, r8 |  | ")]
        vmovdqa32_xmm_r8 = 1926,

        /// <summary>
        /// vmovdqa32 ymm {k1}{z}, m256 |  | 
        /// </summary>
        [Symbol("vmovdqa32 ymm {k1}{z}, m256","vmovdqa32 ymm {k1}{z}, m256 |  | ")]
        vmovdqa32_ymm_k1z_m256 = 1927,

        /// <summary>
        /// vmovdqa32 ymm {k1}{z}, r16 |  | 
        /// </summary>
        [Symbol("vmovdqa32 ymm {k1}{z}, r16","vmovdqa32 ymm {k1}{z}, r16 |  | ")]
        vmovdqa32_ymm_k1z_r16 = 1928,

        /// <summary>
        /// vmovdqa32 ymm, m256 |  | 
        /// </summary>
        [Symbol("vmovdqa32 ymm, m256","vmovdqa32 ymm, m256 |  | ")]
        vmovdqa32_ymm_m256 = 1929,

        /// <summary>
        /// vmovdqa32 ymm, r16 |  | 
        /// </summary>
        [Symbol("vmovdqa32 ymm, r16","vmovdqa32 ymm, r16 |  | ")]
        vmovdqa32_ymm_r16 = 1930,

        /// <summary>
        /// vmovdqa32 zmm {k1}{z}, m512 |  | 
        /// </summary>
        [Symbol("vmovdqa32 zmm {k1}{z}, m512","vmovdqa32 zmm {k1}{z}, m512 |  | ")]
        vmovdqa32_zmm_k1z_m512 = 1931,

        /// <summary>
        /// vmovdqa32 zmm {k1}{z}, r32 |  | 
        /// </summary>
        [Symbol("vmovdqa32 zmm {k1}{z}, r32","vmovdqa32 zmm {k1}{z}, r32 |  | ")]
        vmovdqa32_zmm_k1z_r32 = 1932,

        /// <summary>
        /// vmovdqa32 zmm, m512 |  | 
        /// </summary>
        [Symbol("vmovdqa32 zmm, m512","vmovdqa32 zmm, m512 |  | ")]
        vmovdqa32_zmm_m512 = 1933,

        /// <summary>
        /// vmovdqa32 zmm, r32 |  | 
        /// </summary>
        [Symbol("vmovdqa32 zmm, r32","vmovdqa32 zmm, r32 |  | ")]
        vmovdqa32_zmm_r32 = 1934,

        /// <summary>
        /// vmovdqa64 m128 {k1}{z}, xmm |  | 
        /// </summary>
        [Symbol("vmovdqa64 m128 {k1}{z}, xmm","vmovdqa64 m128 {k1}{z}, xmm |  | ")]
        vmovdqa64_m128_k1z_xmm = 1935,

        /// <summary>
        /// vmovdqa64 m128, xmm |  | 
        /// </summary>
        [Symbol("vmovdqa64 m128, xmm","vmovdqa64 m128, xmm |  | ")]
        vmovdqa64_m128_xmm = 1936,

        /// <summary>
        /// vmovdqa64 m256 {k1}{z}, ymm |  | 
        /// </summary>
        [Symbol("vmovdqa64 m256 {k1}{z}, ymm","vmovdqa64 m256 {k1}{z}, ymm |  | ")]
        vmovdqa64_m256_k1z_ymm = 1937,

        /// <summary>
        /// vmovdqa64 m256, ymm |  | 
        /// </summary>
        [Symbol("vmovdqa64 m256, ymm","vmovdqa64 m256, ymm |  | ")]
        vmovdqa64_m256_ymm = 1938,

        /// <summary>
        /// vmovdqa64 m512 {k1}{z}, zmm |  | 
        /// </summary>
        [Symbol("vmovdqa64 m512 {k1}{z}, zmm","vmovdqa64 m512 {k1}{z}, zmm |  | ")]
        vmovdqa64_m512_k1z_zmm = 1939,

        /// <summary>
        /// vmovdqa64 m512, zmm |  | 
        /// </summary>
        [Symbol("vmovdqa64 m512, zmm","vmovdqa64 m512, zmm |  | ")]
        vmovdqa64_m512_zmm = 1940,

        /// <summary>
        /// vmovdqa64 r16 {k1}{z}, ymm |  | 
        /// </summary>
        [Symbol("vmovdqa64 r16 {k1}{z}, ymm","vmovdqa64 r16 {k1}{z}, ymm |  | ")]
        vmovdqa64_r16_k1z_ymm = 1941,

        /// <summary>
        /// vmovdqa64 r16, ymm |  | 
        /// </summary>
        [Symbol("vmovdqa64 r16, ymm","vmovdqa64 r16, ymm |  | ")]
        vmovdqa64_r16_ymm = 1942,

        /// <summary>
        /// vmovdqa64 r32 {k1}{z}, zmm |  | 
        /// </summary>
        [Symbol("vmovdqa64 r32 {k1}{z}, zmm","vmovdqa64 r32 {k1}{z}, zmm |  | ")]
        vmovdqa64_r32_k1z_zmm = 1943,

        /// <summary>
        /// vmovdqa64 r32, zmm |  | 
        /// </summary>
        [Symbol("vmovdqa64 r32, zmm","vmovdqa64 r32, zmm |  | ")]
        vmovdqa64_r32_zmm = 1944,

        /// <summary>
        /// vmovdqa64 r8 {k1}{z}, xmm |  | 
        /// </summary>
        [Symbol("vmovdqa64 r8 {k1}{z}, xmm","vmovdqa64 r8 {k1}{z}, xmm |  | ")]
        vmovdqa64_r8_k1z_xmm = 1945,

        /// <summary>
        /// vmovdqa64 r8, xmm |  | 
        /// </summary>
        [Symbol("vmovdqa64 r8, xmm","vmovdqa64 r8, xmm |  | ")]
        vmovdqa64_r8_xmm = 1946,

        /// <summary>
        /// vmovdqa64 xmm {k1}{z}, m128 |  | 
        /// </summary>
        [Symbol("vmovdqa64 xmm {k1}{z}, m128","vmovdqa64 xmm {k1}{z}, m128 |  | ")]
        vmovdqa64_xmm_k1z_m128 = 1947,

        /// <summary>
        /// vmovdqa64 xmm {k1}{z}, r8 |  | 
        /// </summary>
        [Symbol("vmovdqa64 xmm {k1}{z}, r8","vmovdqa64 xmm {k1}{z}, r8 |  | ")]
        vmovdqa64_xmm_k1z_r8 = 1948,

        /// <summary>
        /// vmovdqa64 xmm, m128 |  | 
        /// </summary>
        [Symbol("vmovdqa64 xmm, m128","vmovdqa64 xmm, m128 |  | ")]
        vmovdqa64_xmm_m128 = 1949,

        /// <summary>
        /// vmovdqa64 xmm, r8 |  | 
        /// </summary>
        [Symbol("vmovdqa64 xmm, r8","vmovdqa64 xmm, r8 |  | ")]
        vmovdqa64_xmm_r8 = 1950,

        /// <summary>
        /// vmovdqa64 ymm {k1}{z}, m256 |  | 
        /// </summary>
        [Symbol("vmovdqa64 ymm {k1}{z}, m256","vmovdqa64 ymm {k1}{z}, m256 |  | ")]
        vmovdqa64_ymm_k1z_m256 = 1951,

        /// <summary>
        /// vmovdqa64 ymm {k1}{z}, r16 |  | 
        /// </summary>
        [Symbol("vmovdqa64 ymm {k1}{z}, r16","vmovdqa64 ymm {k1}{z}, r16 |  | ")]
        vmovdqa64_ymm_k1z_r16 = 1952,

        /// <summary>
        /// vmovdqa64 ymm, m256 |  | 
        /// </summary>
        [Symbol("vmovdqa64 ymm, m256","vmovdqa64 ymm, m256 |  | ")]
        vmovdqa64_ymm_m256 = 1953,

        /// <summary>
        /// vmovdqa64 ymm, r16 |  | 
        /// </summary>
        [Symbol("vmovdqa64 ymm, r16","vmovdqa64 ymm, r16 |  | ")]
        vmovdqa64_ymm_r16 = 1954,

        /// <summary>
        /// vmovdqa64 zmm {k1}{z}, m512 |  | 
        /// </summary>
        [Symbol("vmovdqa64 zmm {k1}{z}, m512","vmovdqa64 zmm {k1}{z}, m512 |  | ")]
        vmovdqa64_zmm_k1z_m512 = 1955,

        /// <summary>
        /// vmovdqa64 zmm {k1}{z}, r32 |  | 
        /// </summary>
        [Symbol("vmovdqa64 zmm {k1}{z}, r32","vmovdqa64 zmm {k1}{z}, r32 |  | ")]
        vmovdqa64_zmm_k1z_r32 = 1956,

        /// <summary>
        /// vmovdqa64 zmm, m512 |  | 
        /// </summary>
        [Symbol("vmovdqa64 zmm, m512","vmovdqa64 zmm, m512 |  | ")]
        vmovdqa64_zmm_m512 = 1957,

        /// <summary>
        /// vmovdqa64 zmm, r32 |  | 
        /// </summary>
        [Symbol("vmovdqa64 zmm, r32","vmovdqa64 zmm, r32 |  | ")]
        vmovdqa64_zmm_r32 = 1958,

        /// <summary>
        /// vmovdqu m128, xmm |  | 
        /// </summary>
        [Symbol("vmovdqu m128, xmm","vmovdqu m128, xmm |  | ")]
        vmovdqu_m128_xmm = 1959,

        /// <summary>
        /// vmovdqu m256, ymm |  | 
        /// </summary>
        [Symbol("vmovdqu m256, ymm","vmovdqu m256, ymm |  | ")]
        vmovdqu_m256_ymm = 1960,

        /// <summary>
        /// vmovdqu r16, ymm |  | 
        /// </summary>
        [Symbol("vmovdqu r16, ymm","vmovdqu r16, ymm |  | ")]
        vmovdqu_r16_ymm = 1961,

        /// <summary>
        /// vmovdqu r8, xmm |  | 
        /// </summary>
        [Symbol("vmovdqu r8, xmm","vmovdqu r8, xmm |  | ")]
        vmovdqu_r8_xmm = 1962,

        /// <summary>
        /// vmovdqu xmm, m128 |  | 
        /// </summary>
        [Symbol("vmovdqu xmm, m128","vmovdqu xmm, m128 |  | ")]
        vmovdqu_xmm_m128 = 1963,

        /// <summary>
        /// vmovdqu xmm, r8 |  | 
        /// </summary>
        [Symbol("vmovdqu xmm, r8","vmovdqu xmm, r8 |  | ")]
        vmovdqu_xmm_r8 = 1964,

        /// <summary>
        /// vmovdqu ymm, m256 |  | 
        /// </summary>
        [Symbol("vmovdqu ymm, m256","vmovdqu ymm, m256 |  | ")]
        vmovdqu_ymm_m256 = 1965,

        /// <summary>
        /// vmovdqu ymm, r16 |  | 
        /// </summary>
        [Symbol("vmovdqu ymm, r16","vmovdqu ymm, r16 |  | ")]
        vmovdqu_ymm_r16 = 1966,

        /// <summary>
        /// vmovdqu16 m128 {k1}{z}, xmm |  | 
        /// </summary>
        [Symbol("vmovdqu16 m128 {k1}{z}, xmm","vmovdqu16 m128 {k1}{z}, xmm |  | ")]
        vmovdqu16_m128_k1z_xmm = 1967,

        /// <summary>
        /// vmovdqu16 m128, xmm |  | 
        /// </summary>
        [Symbol("vmovdqu16 m128, xmm","vmovdqu16 m128, xmm |  | ")]
        vmovdqu16_m128_xmm = 1968,

        /// <summary>
        /// vmovdqu16 m256 {k1}{z}, ymm |  | 
        /// </summary>
        [Symbol("vmovdqu16 m256 {k1}{z}, ymm","vmovdqu16 m256 {k1}{z}, ymm |  | ")]
        vmovdqu16_m256_k1z_ymm = 1969,

        /// <summary>
        /// vmovdqu16 m256, ymm |  | 
        /// </summary>
        [Symbol("vmovdqu16 m256, ymm","vmovdqu16 m256, ymm |  | ")]
        vmovdqu16_m256_ymm = 1970,

        /// <summary>
        /// vmovdqu16 m512 {k1}{z}, zmm |  | 
        /// </summary>
        [Symbol("vmovdqu16 m512 {k1}{z}, zmm","vmovdqu16 m512 {k1}{z}, zmm |  | ")]
        vmovdqu16_m512_k1z_zmm = 1971,

        /// <summary>
        /// vmovdqu16 m512, zmm |  | 
        /// </summary>
        [Symbol("vmovdqu16 m512, zmm","vmovdqu16 m512, zmm |  | ")]
        vmovdqu16_m512_zmm = 1972,

        /// <summary>
        /// vmovdqu16 r16 {k1}{z}, ymm |  | 
        /// </summary>
        [Symbol("vmovdqu16 r16 {k1}{z}, ymm","vmovdqu16 r16 {k1}{z}, ymm |  | ")]
        vmovdqu16_r16_k1z_ymm = 1973,

        /// <summary>
        /// vmovdqu16 r16, ymm |  | 
        /// </summary>
        [Symbol("vmovdqu16 r16, ymm","vmovdqu16 r16, ymm |  | ")]
        vmovdqu16_r16_ymm = 1974,

        /// <summary>
        /// vmovdqu16 r32 {k1}{z}, zmm |  | 
        /// </summary>
        [Symbol("vmovdqu16 r32 {k1}{z}, zmm","vmovdqu16 r32 {k1}{z}, zmm |  | ")]
        vmovdqu16_r32_k1z_zmm = 1975,

        /// <summary>
        /// vmovdqu16 r32, zmm |  | 
        /// </summary>
        [Symbol("vmovdqu16 r32, zmm","vmovdqu16 r32, zmm |  | ")]
        vmovdqu16_r32_zmm = 1976,

        /// <summary>
        /// vmovdqu16 r8 {k1}{z}, xmm |  | 
        /// </summary>
        [Symbol("vmovdqu16 r8 {k1}{z}, xmm","vmovdqu16 r8 {k1}{z}, xmm |  | ")]
        vmovdqu16_r8_k1z_xmm = 1977,

        /// <summary>
        /// vmovdqu16 r8, xmm |  | 
        /// </summary>
        [Symbol("vmovdqu16 r8, xmm","vmovdqu16 r8, xmm |  | ")]
        vmovdqu16_r8_xmm = 1978,

        /// <summary>
        /// vmovdqu16 xmm {k1}{z}, m128 |  | 
        /// </summary>
        [Symbol("vmovdqu16 xmm {k1}{z}, m128","vmovdqu16 xmm {k1}{z}, m128 |  | ")]
        vmovdqu16_xmm_k1z_m128 = 1979,

        /// <summary>
        /// vmovdqu16 xmm {k1}{z}, r8 |  | 
        /// </summary>
        [Symbol("vmovdqu16 xmm {k1}{z}, r8","vmovdqu16 xmm {k1}{z}, r8 |  | ")]
        vmovdqu16_xmm_k1z_r8 = 1980,

        /// <summary>
        /// vmovdqu16 xmm, m128 |  | 
        /// </summary>
        [Symbol("vmovdqu16 xmm, m128","vmovdqu16 xmm, m128 |  | ")]
        vmovdqu16_xmm_m128 = 1981,

        /// <summary>
        /// vmovdqu16 xmm, r8 |  | 
        /// </summary>
        [Symbol("vmovdqu16 xmm, r8","vmovdqu16 xmm, r8 |  | ")]
        vmovdqu16_xmm_r8 = 1982,

        /// <summary>
        /// vmovdqu16 ymm {k1}{z}, m256 |  | 
        /// </summary>
        [Symbol("vmovdqu16 ymm {k1}{z}, m256","vmovdqu16 ymm {k1}{z}, m256 |  | ")]
        vmovdqu16_ymm_k1z_m256 = 1983,

        /// <summary>
        /// vmovdqu16 ymm {k1}{z}, r16 |  | 
        /// </summary>
        [Symbol("vmovdqu16 ymm {k1}{z}, r16","vmovdqu16 ymm {k1}{z}, r16 |  | ")]
        vmovdqu16_ymm_k1z_r16 = 1984,

        /// <summary>
        /// vmovdqu16 ymm, m256 |  | 
        /// </summary>
        [Symbol("vmovdqu16 ymm, m256","vmovdqu16 ymm, m256 |  | ")]
        vmovdqu16_ymm_m256 = 1985,

        /// <summary>
        /// vmovdqu16 ymm, r16 |  | 
        /// </summary>
        [Symbol("vmovdqu16 ymm, r16","vmovdqu16 ymm, r16 |  | ")]
        vmovdqu16_ymm_r16 = 1986,

        /// <summary>
        /// vmovdqu16 zmm {k1}{z}, m512 |  | 
        /// </summary>
        [Symbol("vmovdqu16 zmm {k1}{z}, m512","vmovdqu16 zmm {k1}{z}, m512 |  | ")]
        vmovdqu16_zmm_k1z_m512 = 1987,

        /// <summary>
        /// vmovdqu16 zmm {k1}{z}, r32 |  | 
        /// </summary>
        [Symbol("vmovdqu16 zmm {k1}{z}, r32","vmovdqu16 zmm {k1}{z}, r32 |  | ")]
        vmovdqu16_zmm_k1z_r32 = 1988,

        /// <summary>
        /// vmovdqu16 zmm, m512 |  | 
        /// </summary>
        [Symbol("vmovdqu16 zmm, m512","vmovdqu16 zmm, m512 |  | ")]
        vmovdqu16_zmm_m512 = 1989,

        /// <summary>
        /// vmovdqu16 zmm, r32 |  | 
        /// </summary>
        [Symbol("vmovdqu16 zmm, r32","vmovdqu16 zmm, r32 |  | ")]
        vmovdqu16_zmm_r32 = 1990,

        /// <summary>
        /// vmovdqu32 m128 {k1}{z}, xmm |  | 
        /// </summary>
        [Symbol("vmovdqu32 m128 {k1}{z}, xmm","vmovdqu32 m128 {k1}{z}, xmm |  | ")]
        vmovdqu32_m128_k1z_xmm = 1991,

        /// <summary>
        /// vmovdqu32 m128, xmm |  | 
        /// </summary>
        [Symbol("vmovdqu32 m128, xmm","vmovdqu32 m128, xmm |  | ")]
        vmovdqu32_m128_xmm = 1992,

        /// <summary>
        /// vmovdqu32 m256 {k1}{z}, ymm |  | 
        /// </summary>
        [Symbol("vmovdqu32 m256 {k1}{z}, ymm","vmovdqu32 m256 {k1}{z}, ymm |  | ")]
        vmovdqu32_m256_k1z_ymm = 1993,

        /// <summary>
        /// vmovdqu32 m256, ymm |  | 
        /// </summary>
        [Symbol("vmovdqu32 m256, ymm","vmovdqu32 m256, ymm |  | ")]
        vmovdqu32_m256_ymm = 1994,

        /// <summary>
        /// vmovdqu32 m512 {k1}{z}, zmm |  | 
        /// </summary>
        [Symbol("vmovdqu32 m512 {k1}{z}, zmm","vmovdqu32 m512 {k1}{z}, zmm |  | ")]
        vmovdqu32_m512_k1z_zmm = 1995,

        /// <summary>
        /// vmovdqu32 m512, zmm |  | 
        /// </summary>
        [Symbol("vmovdqu32 m512, zmm","vmovdqu32 m512, zmm |  | ")]
        vmovdqu32_m512_zmm = 1996,

        /// <summary>
        /// vmovdqu32 r16 {k1}{z}, ymm |  | 
        /// </summary>
        [Symbol("vmovdqu32 r16 {k1}{z}, ymm","vmovdqu32 r16 {k1}{z}, ymm |  | ")]
        vmovdqu32_r16_k1z_ymm = 1997,

        /// <summary>
        /// vmovdqu32 r16, ymm |  | 
        /// </summary>
        [Symbol("vmovdqu32 r16, ymm","vmovdqu32 r16, ymm |  | ")]
        vmovdqu32_r16_ymm = 1998,

        /// <summary>
        /// vmovdqu32 r32 {k1}{z}, zmm |  | 
        /// </summary>
        [Symbol("vmovdqu32 r32 {k1}{z}, zmm","vmovdqu32 r32 {k1}{z}, zmm |  | ")]
        vmovdqu32_r32_k1z_zmm = 1999,

        /// <summary>
        /// vmovdqu32 r32, zmm |  | 
        /// </summary>
        [Symbol("vmovdqu32 r32, zmm","vmovdqu32 r32, zmm |  | ")]
        vmovdqu32_r32_zmm = 2000,

        /// <summary>
        /// vmovdqu32 r8 {k1}{z}, xmm |  | 
        /// </summary>
        [Symbol("vmovdqu32 r8 {k1}{z}, xmm","vmovdqu32 r8 {k1}{z}, xmm |  | ")]
        vmovdqu32_r8_k1z_xmm = 2001,

        /// <summary>
        /// vmovdqu32 r8, xmm |  | 
        /// </summary>
        [Symbol("vmovdqu32 r8, xmm","vmovdqu32 r8, xmm |  | ")]
        vmovdqu32_r8_xmm = 2002,

        /// <summary>
        /// vmovdqu32 xmm {k1}{z}, m128 |  | 
        /// </summary>
        [Symbol("vmovdqu32 xmm {k1}{z}, m128","vmovdqu32 xmm {k1}{z}, m128 |  | ")]
        vmovdqu32_xmm_k1z_m128 = 2003,

        /// <summary>
        /// vmovdqu32 xmm {k1}{z}, r8 |  | 
        /// </summary>
        [Symbol("vmovdqu32 xmm {k1}{z}, r8","vmovdqu32 xmm {k1}{z}, r8 |  | ")]
        vmovdqu32_xmm_k1z_r8 = 2004,

        /// <summary>
        /// vmovdqu32 xmm, m128 |  | 
        /// </summary>
        [Symbol("vmovdqu32 xmm, m128","vmovdqu32 xmm, m128 |  | ")]
        vmovdqu32_xmm_m128 = 2005,

        /// <summary>
        /// vmovdqu32 xmm, r8 |  | 
        /// </summary>
        [Symbol("vmovdqu32 xmm, r8","vmovdqu32 xmm, r8 |  | ")]
        vmovdqu32_xmm_r8 = 2006,

        /// <summary>
        /// vmovdqu32 ymm {k1}{z}, m256 |  | 
        /// </summary>
        [Symbol("vmovdqu32 ymm {k1}{z}, m256","vmovdqu32 ymm {k1}{z}, m256 |  | ")]
        vmovdqu32_ymm_k1z_m256 = 2007,

        /// <summary>
        /// vmovdqu32 ymm {k1}{z}, r16 |  | 
        /// </summary>
        [Symbol("vmovdqu32 ymm {k1}{z}, r16","vmovdqu32 ymm {k1}{z}, r16 |  | ")]
        vmovdqu32_ymm_k1z_r16 = 2008,

        /// <summary>
        /// vmovdqu32 ymm, m256 |  | 
        /// </summary>
        [Symbol("vmovdqu32 ymm, m256","vmovdqu32 ymm, m256 |  | ")]
        vmovdqu32_ymm_m256 = 2009,

        /// <summary>
        /// vmovdqu32 ymm, r16 |  | 
        /// </summary>
        [Symbol("vmovdqu32 ymm, r16","vmovdqu32 ymm, r16 |  | ")]
        vmovdqu32_ymm_r16 = 2010,

        /// <summary>
        /// vmovdqu32 zmm {k1}{z}, m512 |  | 
        /// </summary>
        [Symbol("vmovdqu32 zmm {k1}{z}, m512","vmovdqu32 zmm {k1}{z}, m512 |  | ")]
        vmovdqu32_zmm_k1z_m512 = 2011,

        /// <summary>
        /// vmovdqu32 zmm {k1}{z}, r32 |  | 
        /// </summary>
        [Symbol("vmovdqu32 zmm {k1}{z}, r32","vmovdqu32 zmm {k1}{z}, r32 |  | ")]
        vmovdqu32_zmm_k1z_r32 = 2012,

        /// <summary>
        /// vmovdqu32 zmm, m512 |  | 
        /// </summary>
        [Symbol("vmovdqu32 zmm, m512","vmovdqu32 zmm, m512 |  | ")]
        vmovdqu32_zmm_m512 = 2013,

        /// <summary>
        /// vmovdqu32 zmm, r32 |  | 
        /// </summary>
        [Symbol("vmovdqu32 zmm, r32","vmovdqu32 zmm, r32 |  | ")]
        vmovdqu32_zmm_r32 = 2014,

        /// <summary>
        /// vmovdqu64 m128 {k1}{z}, xmm |  | 
        /// </summary>
        [Symbol("vmovdqu64 m128 {k1}{z}, xmm","vmovdqu64 m128 {k1}{z}, xmm |  | ")]
        vmovdqu64_m128_k1z_xmm = 2015,

        /// <summary>
        /// vmovdqu64 m128, xmm |  | 
        /// </summary>
        [Symbol("vmovdqu64 m128, xmm","vmovdqu64 m128, xmm |  | ")]
        vmovdqu64_m128_xmm = 2016,

        /// <summary>
        /// vmovdqu64 m256 {k1}{z}, ymm |  | 
        /// </summary>
        [Symbol("vmovdqu64 m256 {k1}{z}, ymm","vmovdqu64 m256 {k1}{z}, ymm |  | ")]
        vmovdqu64_m256_k1z_ymm = 2017,

        /// <summary>
        /// vmovdqu64 m256, ymm |  | 
        /// </summary>
        [Symbol("vmovdqu64 m256, ymm","vmovdqu64 m256, ymm |  | ")]
        vmovdqu64_m256_ymm = 2018,

        /// <summary>
        /// vmovdqu64 m512 {k1}{z}, zmm |  | 
        /// </summary>
        [Symbol("vmovdqu64 m512 {k1}{z}, zmm","vmovdqu64 m512 {k1}{z}, zmm |  | ")]
        vmovdqu64_m512_k1z_zmm = 2019,

        /// <summary>
        /// vmovdqu64 m512, zmm |  | 
        /// </summary>
        [Symbol("vmovdqu64 m512, zmm","vmovdqu64 m512, zmm |  | ")]
        vmovdqu64_m512_zmm = 2020,

        /// <summary>
        /// vmovdqu64 r16 {k1}{z}, ymm |  | 
        /// </summary>
        [Symbol("vmovdqu64 r16 {k1}{z}, ymm","vmovdqu64 r16 {k1}{z}, ymm |  | ")]
        vmovdqu64_r16_k1z_ymm = 2021,

        /// <summary>
        /// vmovdqu64 r16, ymm |  | 
        /// </summary>
        [Symbol("vmovdqu64 r16, ymm","vmovdqu64 r16, ymm |  | ")]
        vmovdqu64_r16_ymm = 2022,

        /// <summary>
        /// vmovdqu64 r32 {k1}{z}, zmm |  | 
        /// </summary>
        [Symbol("vmovdqu64 r32 {k1}{z}, zmm","vmovdqu64 r32 {k1}{z}, zmm |  | ")]
        vmovdqu64_r32_k1z_zmm = 2023,

        /// <summary>
        /// vmovdqu64 r32, zmm |  | 
        /// </summary>
        [Symbol("vmovdqu64 r32, zmm","vmovdqu64 r32, zmm |  | ")]
        vmovdqu64_r32_zmm = 2024,

        /// <summary>
        /// vmovdqu64 r8 {k1}{z}, xmm |  | 
        /// </summary>
        [Symbol("vmovdqu64 r8 {k1}{z}, xmm","vmovdqu64 r8 {k1}{z}, xmm |  | ")]
        vmovdqu64_r8_k1z_xmm = 2025,

        /// <summary>
        /// vmovdqu64 r8, xmm |  | 
        /// </summary>
        [Symbol("vmovdqu64 r8, xmm","vmovdqu64 r8, xmm |  | ")]
        vmovdqu64_r8_xmm = 2026,

        /// <summary>
        /// vmovdqu64 xmm {k1}{z}, m128 |  | 
        /// </summary>
        [Symbol("vmovdqu64 xmm {k1}{z}, m128","vmovdqu64 xmm {k1}{z}, m128 |  | ")]
        vmovdqu64_xmm_k1z_m128 = 2027,

        /// <summary>
        /// vmovdqu64 xmm {k1}{z}, r8 |  | 
        /// </summary>
        [Symbol("vmovdqu64 xmm {k1}{z}, r8","vmovdqu64 xmm {k1}{z}, r8 |  | ")]
        vmovdqu64_xmm_k1z_r8 = 2028,

        /// <summary>
        /// vmovdqu64 xmm, m128 |  | 
        /// </summary>
        [Symbol("vmovdqu64 xmm, m128","vmovdqu64 xmm, m128 |  | ")]
        vmovdqu64_xmm_m128 = 2029,

        /// <summary>
        /// vmovdqu64 xmm, r8 |  | 
        /// </summary>
        [Symbol("vmovdqu64 xmm, r8","vmovdqu64 xmm, r8 |  | ")]
        vmovdqu64_xmm_r8 = 2030,

        /// <summary>
        /// vmovdqu64 ymm {k1}{z}, m256 |  | 
        /// </summary>
        [Symbol("vmovdqu64 ymm {k1}{z}, m256","vmovdqu64 ymm {k1}{z}, m256 |  | ")]
        vmovdqu64_ymm_k1z_m256 = 2031,

        /// <summary>
        /// vmovdqu64 ymm {k1}{z}, r16 |  | 
        /// </summary>
        [Symbol("vmovdqu64 ymm {k1}{z}, r16","vmovdqu64 ymm {k1}{z}, r16 |  | ")]
        vmovdqu64_ymm_k1z_r16 = 2032,

        /// <summary>
        /// vmovdqu64 ymm, m256 |  | 
        /// </summary>
        [Symbol("vmovdqu64 ymm, m256","vmovdqu64 ymm, m256 |  | ")]
        vmovdqu64_ymm_m256 = 2033,

        /// <summary>
        /// vmovdqu64 ymm, r16 |  | 
        /// </summary>
        [Symbol("vmovdqu64 ymm, r16","vmovdqu64 ymm, r16 |  | ")]
        vmovdqu64_ymm_r16 = 2034,

        /// <summary>
        /// vmovdqu64 zmm {k1}{z}, m512 |  | 
        /// </summary>
        [Symbol("vmovdqu64 zmm {k1}{z}, m512","vmovdqu64 zmm {k1}{z}, m512 |  | ")]
        vmovdqu64_zmm_k1z_m512 = 2035,

        /// <summary>
        /// vmovdqu64 zmm {k1}{z}, r32 |  | 
        /// </summary>
        [Symbol("vmovdqu64 zmm {k1}{z}, r32","vmovdqu64 zmm {k1}{z}, r32 |  | ")]
        vmovdqu64_zmm_k1z_r32 = 2036,

        /// <summary>
        /// vmovdqu64 zmm, m512 |  | 
        /// </summary>
        [Symbol("vmovdqu64 zmm, m512","vmovdqu64 zmm, m512 |  | ")]
        vmovdqu64_zmm_m512 = 2037,

        /// <summary>
        /// vmovdqu64 zmm, r32 |  | 
        /// </summary>
        [Symbol("vmovdqu64 zmm, r32","vmovdqu64 zmm, r32 |  | ")]
        vmovdqu64_zmm_r32 = 2038,

        /// <summary>
        /// vmovdqu8 m128 {k1}{z}, xmm |  | 
        /// </summary>
        [Symbol("vmovdqu8 m128 {k1}{z}, xmm","vmovdqu8 m128 {k1}{z}, xmm |  | ")]
        vmovdqu8_m128_k1z_xmm = 2039,

        /// <summary>
        /// vmovdqu8 m128, xmm |  | 
        /// </summary>
        [Symbol("vmovdqu8 m128, xmm","vmovdqu8 m128, xmm |  | ")]
        vmovdqu8_m128_xmm = 2040,

        /// <summary>
        /// vmovdqu8 m256 {k1}{z}, ymm |  | 
        /// </summary>
        [Symbol("vmovdqu8 m256 {k1}{z}, ymm","vmovdqu8 m256 {k1}{z}, ymm |  | ")]
        vmovdqu8_m256_k1z_ymm = 2041,

        /// <summary>
        /// vmovdqu8 m256, ymm |  | 
        /// </summary>
        [Symbol("vmovdqu8 m256, ymm","vmovdqu8 m256, ymm |  | ")]
        vmovdqu8_m256_ymm = 2042,

        /// <summary>
        /// vmovdqu8 m512 {k1}{z}, zmm |  | 
        /// </summary>
        [Symbol("vmovdqu8 m512 {k1}{z}, zmm","vmovdqu8 m512 {k1}{z}, zmm |  | ")]
        vmovdqu8_m512_k1z_zmm = 2043,

        /// <summary>
        /// vmovdqu8 m512, zmm |  | 
        /// </summary>
        [Symbol("vmovdqu8 m512, zmm","vmovdqu8 m512, zmm |  | ")]
        vmovdqu8_m512_zmm = 2044,

        /// <summary>
        /// vmovdqu8 r16 {k1}{z}, ymm |  | 
        /// </summary>
        [Symbol("vmovdqu8 r16 {k1}{z}, ymm","vmovdqu8 r16 {k1}{z}, ymm |  | ")]
        vmovdqu8_r16_k1z_ymm = 2045,

        /// <summary>
        /// vmovdqu8 r16, ymm |  | 
        /// </summary>
        [Symbol("vmovdqu8 r16, ymm","vmovdqu8 r16, ymm |  | ")]
        vmovdqu8_r16_ymm = 2046,

        /// <summary>
        /// vmovdqu8 r32 {k1}{z}, zmm |  | 
        /// </summary>
        [Symbol("vmovdqu8 r32 {k1}{z}, zmm","vmovdqu8 r32 {k1}{z}, zmm |  | ")]
        vmovdqu8_r32_k1z_zmm = 2047,

        /// <summary>
        /// vmovdqu8 r32, zmm |  | 
        /// </summary>
        [Symbol("vmovdqu8 r32, zmm","vmovdqu8 r32, zmm |  | ")]
        vmovdqu8_r32_zmm = 2048,

        /// <summary>
        /// vmovdqu8 r8 {k1}{z}, xmm |  | 
        /// </summary>
        [Symbol("vmovdqu8 r8 {k1}{z}, xmm","vmovdqu8 r8 {k1}{z}, xmm |  | ")]
        vmovdqu8_r8_k1z_xmm = 2049,

        /// <summary>
        /// vmovdqu8 r8, xmm |  | 
        /// </summary>
        [Symbol("vmovdqu8 r8, xmm","vmovdqu8 r8, xmm |  | ")]
        vmovdqu8_r8_xmm = 2050,

        /// <summary>
        /// vmovdqu8 xmm {k1}{z}, m128 |  | 
        /// </summary>
        [Symbol("vmovdqu8 xmm {k1}{z}, m128","vmovdqu8 xmm {k1}{z}, m128 |  | ")]
        vmovdqu8_xmm_k1z_m128 = 2051,

        /// <summary>
        /// vmovdqu8 xmm {k1}{z}, r8 |  | 
        /// </summary>
        [Symbol("vmovdqu8 xmm {k1}{z}, r8","vmovdqu8 xmm {k1}{z}, r8 |  | ")]
        vmovdqu8_xmm_k1z_r8 = 2052,

        /// <summary>
        /// vmovdqu8 xmm, m128 |  | 
        /// </summary>
        [Symbol("vmovdqu8 xmm, m128","vmovdqu8 xmm, m128 |  | ")]
        vmovdqu8_xmm_m128 = 2053,

        /// <summary>
        /// vmovdqu8 xmm, r8 |  | 
        /// </summary>
        [Symbol("vmovdqu8 xmm, r8","vmovdqu8 xmm, r8 |  | ")]
        vmovdqu8_xmm_r8 = 2054,

        /// <summary>
        /// vmovdqu8 ymm {k1}{z}, m256 |  | 
        /// </summary>
        [Symbol("vmovdqu8 ymm {k1}{z}, m256","vmovdqu8 ymm {k1}{z}, m256 |  | ")]
        vmovdqu8_ymm_k1z_m256 = 2055,

        /// <summary>
        /// vmovdqu8 ymm {k1}{z}, r16 |  | 
        /// </summary>
        [Symbol("vmovdqu8 ymm {k1}{z}, r16","vmovdqu8 ymm {k1}{z}, r16 |  | ")]
        vmovdqu8_ymm_k1z_r16 = 2056,

        /// <summary>
        /// vmovdqu8 ymm, m256 |  | 
        /// </summary>
        [Symbol("vmovdqu8 ymm, m256","vmovdqu8 ymm, m256 |  | ")]
        vmovdqu8_ymm_m256 = 2057,

        /// <summary>
        /// vmovdqu8 ymm, r16 |  | 
        /// </summary>
        [Symbol("vmovdqu8 ymm, r16","vmovdqu8 ymm, r16 |  | ")]
        vmovdqu8_ymm_r16 = 2058,

        /// <summary>
        /// vmovdqu8 zmm {k1}{z}, m512 |  | 
        /// </summary>
        [Symbol("vmovdqu8 zmm {k1}{z}, m512","vmovdqu8 zmm {k1}{z}, m512 |  | ")]
        vmovdqu8_zmm_k1z_m512 = 2059,

        /// <summary>
        /// vmovdqu8 zmm {k1}{z}, r32 |  | 
        /// </summary>
        [Symbol("vmovdqu8 zmm {k1}{z}, r32","vmovdqu8 zmm {k1}{z}, r32 |  | ")]
        vmovdqu8_zmm_k1z_r32 = 2060,

        /// <summary>
        /// vmovdqu8 zmm, m512 |  | 
        /// </summary>
        [Symbol("vmovdqu8 zmm, m512","vmovdqu8 zmm, m512 |  | ")]
        vmovdqu8_zmm_m512 = 2061,

        /// <summary>
        /// vmovdqu8 zmm, r32 |  | 
        /// </summary>
        [Symbol("vmovdqu8 zmm, r32","vmovdqu8 zmm, r32 |  | ")]
        vmovdqu8_zmm_r32 = 2062,

        /// <summary>
        /// vmovq m64, xmm |  | 
        /// </summary>
        [Symbol("vmovq m64, xmm","vmovq m64, xmm |  | ")]
        vmovq_m64_xmm = 2063,

        /// <summary>
        /// vmovq r64, xmm |  | 
        /// </summary>
        [Symbol("vmovq r64, xmm","vmovq r64, xmm |  | ")]
        vmovq_r64_xmm = 2064,

        /// <summary>
        /// vmovq r8, xmm |  | 
        /// </summary>
        [Symbol("vmovq r8, xmm","vmovq r8, xmm |  | ")]
        vmovq_r8_xmm = 2065,

        /// <summary>
        /// vmovq xmm, m64 |  | 
        /// </summary>
        [Symbol("vmovq xmm, m64","vmovq xmm, m64 |  | ")]
        vmovq_xmm_m64 = 2066,

        /// <summary>
        /// vmovq xmm, r64 |  | 
        /// </summary>
        [Symbol("vmovq xmm, r64","vmovq xmm, r64 |  | ")]
        vmovq_xmm_r64 = 2067,

        /// <summary>
        /// vmovq xmm, r8 |  | 
        /// </summary>
        [Symbol("vmovq xmm, r8","vmovq xmm, r8 |  | ")]
        vmovq_xmm_r8 = 2068,

        /// <summary>
        /// vmovupd m128 {k1}{z}, xmm |  | 
        /// </summary>
        [Symbol("vmovupd m128 {k1}{z}, xmm","vmovupd m128 {k1}{z}, xmm |  | ")]
        vmovupd_m128_k1z_xmm = 2069,

        /// <summary>
        /// vmovupd m128, xmm |  | 
        /// </summary>
        [Symbol("vmovupd m128, xmm","vmovupd m128, xmm |  | ")]
        vmovupd_m128_xmm = 2070,

        /// <summary>
        /// vmovupd m256 {k1}{z}, ymm |  | 
        /// </summary>
        [Symbol("vmovupd m256 {k1}{z}, ymm","vmovupd m256 {k1}{z}, ymm |  | ")]
        vmovupd_m256_k1z_ymm = 2071,

        /// <summary>
        /// vmovupd m256, ymm |  | 
        /// </summary>
        [Symbol("vmovupd m256, ymm","vmovupd m256, ymm |  | ")]
        vmovupd_m256_ymm = 2072,

        /// <summary>
        /// vmovupd m512 {k1}{z}, zmm |  | 
        /// </summary>
        [Symbol("vmovupd m512 {k1}{z}, zmm","vmovupd m512 {k1}{z}, zmm |  | ")]
        vmovupd_m512_k1z_zmm = 2073,

        /// <summary>
        /// vmovupd m512, zmm |  | 
        /// </summary>
        [Symbol("vmovupd m512, zmm","vmovupd m512, zmm |  | ")]
        vmovupd_m512_zmm = 2074,

        /// <summary>
        /// vmovupd r16 {k1}{z}, ymm |  | 
        /// </summary>
        [Symbol("vmovupd r16 {k1}{z}, ymm","vmovupd r16 {k1}{z}, ymm |  | ")]
        vmovupd_r16_k1z_ymm = 2075,

        /// <summary>
        /// vmovupd r16, ymm |  | 
        /// </summary>
        [Symbol("vmovupd r16, ymm","vmovupd r16, ymm |  | ")]
        vmovupd_r16_ymm = 2076,

        /// <summary>
        /// vmovupd r32 {k1}{z}, zmm |  | 
        /// </summary>
        [Symbol("vmovupd r32 {k1}{z}, zmm","vmovupd r32 {k1}{z}, zmm |  | ")]
        vmovupd_r32_k1z_zmm = 2077,

        /// <summary>
        /// vmovupd r32, zmm |  | 
        /// </summary>
        [Symbol("vmovupd r32, zmm","vmovupd r32, zmm |  | ")]
        vmovupd_r32_zmm = 2078,

        /// <summary>
        /// vmovupd r8 {k1}{z}, xmm |  | 
        /// </summary>
        [Symbol("vmovupd r8 {k1}{z}, xmm","vmovupd r8 {k1}{z}, xmm |  | ")]
        vmovupd_r8_k1z_xmm = 2079,

        /// <summary>
        /// vmovupd r8, xmm |  | 
        /// </summary>
        [Symbol("vmovupd r8, xmm","vmovupd r8, xmm |  | ")]
        vmovupd_r8_xmm = 2080,

        /// <summary>
        /// vmovupd xmm {k1}{z}, m128 |  | 
        /// </summary>
        [Symbol("vmovupd xmm {k1}{z}, m128","vmovupd xmm {k1}{z}, m128 |  | ")]
        vmovupd_xmm_k1z_m128 = 2081,

        /// <summary>
        /// vmovupd xmm {k1}{z}, r8 |  | 
        /// </summary>
        [Symbol("vmovupd xmm {k1}{z}, r8","vmovupd xmm {k1}{z}, r8 |  | ")]
        vmovupd_xmm_k1z_r8 = 2082,

        /// <summary>
        /// vmovupd xmm, m128 |  | 
        /// </summary>
        [Symbol("vmovupd xmm, m128","vmovupd xmm, m128 |  | ")]
        vmovupd_xmm_m128 = 2083,

        /// <summary>
        /// vmovupd xmm, r8 |  | 
        /// </summary>
        [Symbol("vmovupd xmm, r8","vmovupd xmm, r8 |  | ")]
        vmovupd_xmm_r8 = 2084,

        /// <summary>
        /// vmovupd ymm {k1}{z}, m256 |  | 
        /// </summary>
        [Symbol("vmovupd ymm {k1}{z}, m256","vmovupd ymm {k1}{z}, m256 |  | ")]
        vmovupd_ymm_k1z_m256 = 2085,

        /// <summary>
        /// vmovupd ymm {k1}{z}, r16 |  | 
        /// </summary>
        [Symbol("vmovupd ymm {k1}{z}, r16","vmovupd ymm {k1}{z}, r16 |  | ")]
        vmovupd_ymm_k1z_r16 = 2086,

        /// <summary>
        /// vmovupd ymm, m256 |  | 
        /// </summary>
        [Symbol("vmovupd ymm, m256","vmovupd ymm, m256 |  | ")]
        vmovupd_ymm_m256 = 2087,

        /// <summary>
        /// vmovupd ymm, r16 |  | 
        /// </summary>
        [Symbol("vmovupd ymm, r16","vmovupd ymm, r16 |  | ")]
        vmovupd_ymm_r16 = 2088,

        /// <summary>
        /// vmovupd zmm {k1}{z}, m512 |  | 
        /// </summary>
        [Symbol("vmovupd zmm {k1}{z}, m512","vmovupd zmm {k1}{z}, m512 |  | ")]
        vmovupd_zmm_k1z_m512 = 2089,

        /// <summary>
        /// vmovupd zmm {k1}{z}, r32 |  | 
        /// </summary>
        [Symbol("vmovupd zmm {k1}{z}, r32","vmovupd zmm {k1}{z}, r32 |  | ")]
        vmovupd_zmm_k1z_r32 = 2090,

        /// <summary>
        /// vmovupd zmm, m512 |  | 
        /// </summary>
        [Symbol("vmovupd zmm, m512","vmovupd zmm, m512 |  | ")]
        vmovupd_zmm_m512 = 2091,

        /// <summary>
        /// vmovupd zmm, r32 |  | 
        /// </summary>
        [Symbol("vmovupd zmm, r32","vmovupd zmm, r32 |  | ")]
        vmovupd_zmm_r32 = 2092,

        /// <summary>
        /// vmpsadbw xmm, xmm, m128, imm8 |  | 
        /// </summary>
        [Symbol("vmpsadbw xmm, xmm, m128, imm8","vmpsadbw xmm, xmm, m128, imm8 |  | ")]
        vmpsadbw_xmm_xmm_m128_imm8 = 2093,

        /// <summary>
        /// vmpsadbw xmm, xmm, r8, imm8 |  | 
        /// </summary>
        [Symbol("vmpsadbw xmm, xmm, r8, imm8","vmpsadbw xmm, xmm, r8, imm8 |  | ")]
        vmpsadbw_xmm_xmm_r8_imm8 = 2094,

        /// <summary>
        /// vmpsadbw ymm, ymm, m256, imm8 |  | 
        /// </summary>
        [Symbol("vmpsadbw ymm, ymm, m256, imm8","vmpsadbw ymm, ymm, m256, imm8 |  | ")]
        vmpsadbw_ymm_ymm_m256_imm8 = 2095,

        /// <summary>
        /// vmpsadbw ymm, ymm, r16, imm8 |  | 
        /// </summary>
        [Symbol("vmpsadbw ymm, ymm, r16, imm8","vmpsadbw ymm, ymm, r16, imm8 |  | ")]
        vmpsadbw_ymm_ymm_r16_imm8 = 2096,

        /// <summary>
        /// vpabsb xmm {k1}{z}, m128 |  | 
        /// </summary>
        [Symbol("vpabsb xmm {k1}{z}, m128","vpabsb xmm {k1}{z}, m128 |  | ")]
        vpabsb_xmm_k1z_m128 = 2097,

        /// <summary>
        /// vpabsb xmm {k1}{z}, r8 |  | 
        /// </summary>
        [Symbol("vpabsb xmm {k1}{z}, r8","vpabsb xmm {k1}{z}, r8 |  | ")]
        vpabsb_xmm_k1z_r8 = 2098,

        /// <summary>
        /// vpabsb xmm, m128 |  | 
        /// </summary>
        [Symbol("vpabsb xmm, m128","vpabsb xmm, m128 |  | ")]
        vpabsb_xmm_m128 = 2099,

        /// <summary>
        /// vpabsb xmm, r8 |  | 
        /// </summary>
        [Symbol("vpabsb xmm, r8","vpabsb xmm, r8 |  | ")]
        vpabsb_xmm_r8 = 2100,

        /// <summary>
        /// vpabsb ymm {k1}{z}, m256 |  | 
        /// </summary>
        [Symbol("vpabsb ymm {k1}{z}, m256","vpabsb ymm {k1}{z}, m256 |  | ")]
        vpabsb_ymm_k1z_m256 = 2101,

        /// <summary>
        /// vpabsb ymm {k1}{z}, r16 |  | 
        /// </summary>
        [Symbol("vpabsb ymm {k1}{z}, r16","vpabsb ymm {k1}{z}, r16 |  | ")]
        vpabsb_ymm_k1z_r16 = 2102,

        /// <summary>
        /// vpabsb ymm, m256 |  | 
        /// </summary>
        [Symbol("vpabsb ymm, m256","vpabsb ymm, m256 |  | ")]
        vpabsb_ymm_m256 = 2103,

        /// <summary>
        /// vpabsb ymm, r16 |  | 
        /// </summary>
        [Symbol("vpabsb ymm, r16","vpabsb ymm, r16 |  | ")]
        vpabsb_ymm_r16 = 2104,

        /// <summary>
        /// vpabsb zmm {k1}{z}, m512 |  | 
        /// </summary>
        [Symbol("vpabsb zmm {k1}{z}, m512","vpabsb zmm {k1}{z}, m512 |  | ")]
        vpabsb_zmm_k1z_m512 = 2105,

        /// <summary>
        /// vpabsb zmm {k1}{z}, r32 |  | 
        /// </summary>
        [Symbol("vpabsb zmm {k1}{z}, r32","vpabsb zmm {k1}{z}, r32 |  | ")]
        vpabsb_zmm_k1z_r32 = 2106,

        /// <summary>
        /// vpabsb zmm, m512 |  | 
        /// </summary>
        [Symbol("vpabsb zmm, m512","vpabsb zmm, m512 |  | ")]
        vpabsb_zmm_m512 = 2107,

        /// <summary>
        /// vpabsb zmm, r32 |  | 
        /// </summary>
        [Symbol("vpabsb zmm, r32","vpabsb zmm, r32 |  | ")]
        vpabsb_zmm_r32 = 2108,

        /// <summary>
        /// vpabsd xmm {k1}{z}, m128 |  | 
        /// </summary>
        [Symbol("vpabsd xmm {k1}{z}, m128","vpabsd xmm {k1}{z}, m128 |  | ")]
        vpabsd_xmm_k1z_m128 = 2109,

        /// <summary>
        /// vpabsd xmm {k1}{z}, m32bcst |  | 
        /// </summary>
        [Symbol("vpabsd xmm {k1}{z}, m32bcst","vpabsd xmm {k1}{z}, m32bcst |  | ")]
        vpabsd_xmm_k1z_m32bcst = 2110,

        /// <summary>
        /// vpabsd xmm {k1}{z}, xmm |  | 
        /// </summary>
        [Symbol("vpabsd xmm {k1}{z}, xmm","vpabsd xmm {k1}{z}, xmm |  | ")]
        vpabsd_xmm_k1z_xmm = 2111,

        /// <summary>
        /// vpabsd xmm, m128 |  | 
        /// </summary>
        [Symbol("vpabsd xmm, m128","vpabsd xmm, m128 |  | ")]
        vpabsd_xmm_m128 = 2112,

        /// <summary>
        /// vpabsd xmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpabsd xmm, m32bcst","vpabsd xmm, m32bcst |  | ")]
        vpabsd_xmm_m32bcst = 2113,

        /// <summary>
        /// vpabsd xmm, r8 |  | 
        /// </summary>
        [Symbol("vpabsd xmm, r8","vpabsd xmm, r8 |  | ")]
        vpabsd_xmm_r8 = 2114,

        /// <summary>
        /// vpabsd xmm, xmm |  | 
        /// </summary>
        [Symbol("vpabsd xmm, xmm","vpabsd xmm, xmm |  | ")]
        vpabsd_xmm_xmm = 2115,

        /// <summary>
        /// vpabsd ymm {k1}{z}, m256 |  | 
        /// </summary>
        [Symbol("vpabsd ymm {k1}{z}, m256","vpabsd ymm {k1}{z}, m256 |  | ")]
        vpabsd_ymm_k1z_m256 = 2116,

        /// <summary>
        /// vpabsd ymm {k1}{z}, m32bcst |  | 
        /// </summary>
        [Symbol("vpabsd ymm {k1}{z}, m32bcst","vpabsd ymm {k1}{z}, m32bcst |  | ")]
        vpabsd_ymm_k1z_m32bcst = 2117,

        /// <summary>
        /// vpabsd ymm {k1}{z}, ymm |  | 
        /// </summary>
        [Symbol("vpabsd ymm {k1}{z}, ymm","vpabsd ymm {k1}{z}, ymm |  | ")]
        vpabsd_ymm_k1z_ymm = 2118,

        /// <summary>
        /// vpabsd ymm, m256 |  | 
        /// </summary>
        [Symbol("vpabsd ymm, m256","vpabsd ymm, m256 |  | ")]
        vpabsd_ymm_m256 = 2119,

        /// <summary>
        /// vpabsd ymm, m32bcst |  | 
        /// </summary>
        [Symbol("vpabsd ymm, m32bcst","vpabsd ymm, m32bcst |  | ")]
        vpabsd_ymm_m32bcst = 2120,

        /// <summary>
        /// vpabsd ymm, r16 |  | 
        /// </summary>
        [Symbol("vpabsd ymm, r16","vpabsd ymm, r16 |  | ")]
        vpabsd_ymm_r16 = 2121,

        /// <summary>
        /// vpabsd ymm, ymm |  | 
        /// </summary>
        [Symbol("vpabsd ymm, ymm","vpabsd ymm, ymm |  | ")]
        vpabsd_ymm_ymm = 2122,

        /// <summary>
        /// vpabsd zmm {k1}{z}, m32bcst |  | 
        /// </summary>
        [Symbol("vpabsd zmm {k1}{z}, m32bcst","vpabsd zmm {k1}{z}, m32bcst |  | ")]
        vpabsd_zmm_k1z_m32bcst = 2123,

        /// <summary>
        /// vpabsd zmm {k1}{z}, m512 |  | 
        /// </summary>
        [Symbol("vpabsd zmm {k1}{z}, m512","vpabsd zmm {k1}{z}, m512 |  | ")]
        vpabsd_zmm_k1z_m512 = 2124,

        /// <summary>
        /// vpabsd zmm {k1}{z}, zmm |  | 
        /// </summary>
        [Symbol("vpabsd zmm {k1}{z}, zmm","vpabsd zmm {k1}{z}, zmm |  | ")]
        vpabsd_zmm_k1z_zmm = 2125,

        /// <summary>
        /// vpabsd zmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpabsd zmm, m32bcst","vpabsd zmm, m32bcst |  | ")]
        vpabsd_zmm_m32bcst = 2126,

        /// <summary>
        /// vpabsd zmm, m512 |  | 
        /// </summary>
        [Symbol("vpabsd zmm, m512","vpabsd zmm, m512 |  | ")]
        vpabsd_zmm_m512 = 2127,

        /// <summary>
        /// vpabsd zmm, zmm |  | 
        /// </summary>
        [Symbol("vpabsd zmm, zmm","vpabsd zmm, zmm |  | ")]
        vpabsd_zmm_zmm = 2128,

        /// <summary>
        /// vpabsq xmm {k1}{z}, m128 |  | 
        /// </summary>
        [Symbol("vpabsq xmm {k1}{z}, m128","vpabsq xmm {k1}{z}, m128 |  | ")]
        vpabsq_xmm_k1z_m128 = 2129,

        /// <summary>
        /// vpabsq xmm {k1}{z}, m64bcst |  | 
        /// </summary>
        [Symbol("vpabsq xmm {k1}{z}, m64bcst","vpabsq xmm {k1}{z}, m64bcst |  | ")]
        vpabsq_xmm_k1z_m64bcst = 2130,

        /// <summary>
        /// vpabsq xmm {k1}{z}, xmm |  | 
        /// </summary>
        [Symbol("vpabsq xmm {k1}{z}, xmm","vpabsq xmm {k1}{z}, xmm |  | ")]
        vpabsq_xmm_k1z_xmm = 2131,

        /// <summary>
        /// vpabsq xmm, m128 |  | 
        /// </summary>
        [Symbol("vpabsq xmm, m128","vpabsq xmm, m128 |  | ")]
        vpabsq_xmm_m128 = 2132,

        /// <summary>
        /// vpabsq xmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpabsq xmm, m64bcst","vpabsq xmm, m64bcst |  | ")]
        vpabsq_xmm_m64bcst = 2133,

        /// <summary>
        /// vpabsq xmm, xmm |  | 
        /// </summary>
        [Symbol("vpabsq xmm, xmm","vpabsq xmm, xmm |  | ")]
        vpabsq_xmm_xmm = 2134,

        /// <summary>
        /// vpabsq ymm {k1}{z}, m256 |  | 
        /// </summary>
        [Symbol("vpabsq ymm {k1}{z}, m256","vpabsq ymm {k1}{z}, m256 |  | ")]
        vpabsq_ymm_k1z_m256 = 2135,

        /// <summary>
        /// vpabsq ymm {k1}{z}, m64bcst |  | 
        /// </summary>
        [Symbol("vpabsq ymm {k1}{z}, m64bcst","vpabsq ymm {k1}{z}, m64bcst |  | ")]
        vpabsq_ymm_k1z_m64bcst = 2136,

        /// <summary>
        /// vpabsq ymm {k1}{z}, ymm |  | 
        /// </summary>
        [Symbol("vpabsq ymm {k1}{z}, ymm","vpabsq ymm {k1}{z}, ymm |  | ")]
        vpabsq_ymm_k1z_ymm = 2137,

        /// <summary>
        /// vpabsq ymm, m256 |  | 
        /// </summary>
        [Symbol("vpabsq ymm, m256","vpabsq ymm, m256 |  | ")]
        vpabsq_ymm_m256 = 2138,

        /// <summary>
        /// vpabsq ymm, m64bcst |  | 
        /// </summary>
        [Symbol("vpabsq ymm, m64bcst","vpabsq ymm, m64bcst |  | ")]
        vpabsq_ymm_m64bcst = 2139,

        /// <summary>
        /// vpabsq ymm, ymm |  | 
        /// </summary>
        [Symbol("vpabsq ymm, ymm","vpabsq ymm, ymm |  | ")]
        vpabsq_ymm_ymm = 2140,

        /// <summary>
        /// vpabsq zmm {k1}{z}, m512 |  | 
        /// </summary>
        [Symbol("vpabsq zmm {k1}{z}, m512","vpabsq zmm {k1}{z}, m512 |  | ")]
        vpabsq_zmm_k1z_m512 = 2141,

        /// <summary>
        /// vpabsq zmm {k1}{z}, m64bcst |  | 
        /// </summary>
        [Symbol("vpabsq zmm {k1}{z}, m64bcst","vpabsq zmm {k1}{z}, m64bcst |  | ")]
        vpabsq_zmm_k1z_m64bcst = 2142,

        /// <summary>
        /// vpabsq zmm {k1}{z}, zmm |  | 
        /// </summary>
        [Symbol("vpabsq zmm {k1}{z}, zmm","vpabsq zmm {k1}{z}, zmm |  | ")]
        vpabsq_zmm_k1z_zmm = 2143,

        /// <summary>
        /// vpabsq zmm, m512 |  | 
        /// </summary>
        [Symbol("vpabsq zmm, m512","vpabsq zmm, m512 |  | ")]
        vpabsq_zmm_m512 = 2144,

        /// <summary>
        /// vpabsq zmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpabsq zmm, m64bcst","vpabsq zmm, m64bcst |  | ")]
        vpabsq_zmm_m64bcst = 2145,

        /// <summary>
        /// vpabsq zmm, zmm |  | 
        /// </summary>
        [Symbol("vpabsq zmm, zmm","vpabsq zmm, zmm |  | ")]
        vpabsq_zmm_zmm = 2146,

        /// <summary>
        /// vpabsw xmm {k1}{z}, m128 |  | 
        /// </summary>
        [Symbol("vpabsw xmm {k1}{z}, m128","vpabsw xmm {k1}{z}, m128 |  | ")]
        vpabsw_xmm_k1z_m128 = 2147,

        /// <summary>
        /// vpabsw xmm {k1}{z}, r8 |  | 
        /// </summary>
        [Symbol("vpabsw xmm {k1}{z}, r8","vpabsw xmm {k1}{z}, r8 |  | ")]
        vpabsw_xmm_k1z_r8 = 2148,

        /// <summary>
        /// vpabsw xmm, m128 |  | 
        /// </summary>
        [Symbol("vpabsw xmm, m128","vpabsw xmm, m128 |  | ")]
        vpabsw_xmm_m128 = 2149,

        /// <summary>
        /// vpabsw xmm, r8 |  | 
        /// </summary>
        [Symbol("vpabsw xmm, r8","vpabsw xmm, r8 |  | ")]
        vpabsw_xmm_r8 = 2150,

        /// <summary>
        /// vpabsw ymm {k1}{z}, m256 |  | 
        /// </summary>
        [Symbol("vpabsw ymm {k1}{z}, m256","vpabsw ymm {k1}{z}, m256 |  | ")]
        vpabsw_ymm_k1z_m256 = 2151,

        /// <summary>
        /// vpabsw ymm {k1}{z}, r16 |  | 
        /// </summary>
        [Symbol("vpabsw ymm {k1}{z}, r16","vpabsw ymm {k1}{z}, r16 |  | ")]
        vpabsw_ymm_k1z_r16 = 2152,

        /// <summary>
        /// vpabsw ymm, m256 |  | 
        /// </summary>
        [Symbol("vpabsw ymm, m256","vpabsw ymm, m256 |  | ")]
        vpabsw_ymm_m256 = 2153,

        /// <summary>
        /// vpabsw ymm, r16 |  | 
        /// </summary>
        [Symbol("vpabsw ymm, r16","vpabsw ymm, r16 |  | ")]
        vpabsw_ymm_r16 = 2154,

        /// <summary>
        /// vpabsw zmm {k1}{z}, m512 |  | 
        /// </summary>
        [Symbol("vpabsw zmm {k1}{z}, m512","vpabsw zmm {k1}{z}, m512 |  | ")]
        vpabsw_zmm_k1z_m512 = 2155,

        /// <summary>
        /// vpabsw zmm {k1}{z}, r32 |  | 
        /// </summary>
        [Symbol("vpabsw zmm {k1}{z}, r32","vpabsw zmm {k1}{z}, r32 |  | ")]
        vpabsw_zmm_k1z_r32 = 2156,

        /// <summary>
        /// vpabsw zmm, m512 |  | 
        /// </summary>
        [Symbol("vpabsw zmm, m512","vpabsw zmm, m512 |  | ")]
        vpabsw_zmm_m512 = 2157,

        /// <summary>
        /// vpabsw zmm, r32 |  | 
        /// </summary>
        [Symbol("vpabsw zmm, r32","vpabsw zmm, r32 |  | ")]
        vpabsw_zmm_r32 = 2158,

        /// <summary>
        /// vpackssdw xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpackssdw xmm {k1}{z}, xmm, m128","vpackssdw xmm {k1}{z}, xmm, m128 |  | ")]
        vpackssdw_xmm_k1z_xmm_m128 = 2159,

        /// <summary>
        /// vpackssdw xmm {k1}{z}, xmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpackssdw xmm {k1}{z}, xmm, m32bcst","vpackssdw xmm {k1}{z}, xmm, m32bcst |  | ")]
        vpackssdw_xmm_k1z_xmm_m32bcst = 2160,

        /// <summary>
        /// vpackssdw xmm {k1}{z}, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpackssdw xmm {k1}{z}, xmm, xmm","vpackssdw xmm {k1}{z}, xmm, xmm |  | ")]
        vpackssdw_xmm_k1z_xmm_xmm = 2161,

        /// <summary>
        /// vpackssdw xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpackssdw xmm, xmm, m128","vpackssdw xmm, xmm, m128 |  | ")]
        vpackssdw_xmm_xmm_m128 = 2162,

        /// <summary>
        /// vpackssdw xmm, xmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpackssdw xmm, xmm, m32bcst","vpackssdw xmm, xmm, m32bcst |  | ")]
        vpackssdw_xmm_xmm_m32bcst = 2163,

        /// <summary>
        /// vpackssdw xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpackssdw xmm, xmm, r8","vpackssdw xmm, xmm, r8 |  | ")]
        vpackssdw_xmm_xmm_r8 = 2164,

        /// <summary>
        /// vpackssdw xmm, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpackssdw xmm, xmm, xmm","vpackssdw xmm, xmm, xmm |  | ")]
        vpackssdw_xmm_xmm_xmm = 2165,

        /// <summary>
        /// vpackssdw ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpackssdw ymm, ymm, m256","vpackssdw ymm, ymm, m256 |  | ")]
        vpackssdw_ymm_ymm_m256 = 2166,

        /// <summary>
        /// vpackssdw ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpackssdw ymm, ymm, r16","vpackssdw ymm, ymm, r16 |  | ")]
        vpackssdw_ymm_ymm_r16 = 2167,

        /// <summary>
        /// vpacksswb xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpacksswb xmm {k1}{z}, xmm, m128","vpacksswb xmm {k1}{z}, xmm, m128 |  | ")]
        vpacksswb_xmm_k1z_xmm_m128 = 2168,

        /// <summary>
        /// vpacksswb xmm {k1}{z}, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpacksswb xmm {k1}{z}, xmm, r8","vpacksswb xmm {k1}{z}, xmm, r8 |  | ")]
        vpacksswb_xmm_k1z_xmm_r8 = 2169,

        /// <summary>
        /// vpacksswb xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpacksswb xmm, xmm, m128","vpacksswb xmm, xmm, m128 |  | ")]
        vpacksswb_xmm_xmm_m128 = 2170,

        /// <summary>
        /// vpacksswb xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpacksswb xmm, xmm, r8","vpacksswb xmm, xmm, r8 |  | ")]
        vpacksswb_xmm_xmm_r8 = 2171,

        /// <summary>
        /// vpacksswb ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpacksswb ymm {k1}{z}, ymm, m256","vpacksswb ymm {k1}{z}, ymm, m256 |  | ")]
        vpacksswb_ymm_k1z_ymm_m256 = 2172,

        /// <summary>
        /// vpacksswb ymm {k1}{z}, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpacksswb ymm {k1}{z}, ymm, r16","vpacksswb ymm {k1}{z}, ymm, r16 |  | ")]
        vpacksswb_ymm_k1z_ymm_r16 = 2173,

        /// <summary>
        /// vpacksswb ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpacksswb ymm, ymm, m256","vpacksswb ymm, ymm, m256 |  | ")]
        vpacksswb_ymm_ymm_m256 = 2174,

        /// <summary>
        /// vpacksswb ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpacksswb ymm, ymm, r16","vpacksswb ymm, ymm, r16 |  | ")]
        vpacksswb_ymm_ymm_r16 = 2175,

        /// <summary>
        /// vpacksswb zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpacksswb zmm {k1}{z}, zmm, m512","vpacksswb zmm {k1}{z}, zmm, m512 |  | ")]
        vpacksswb_zmm_k1z_zmm_m512 = 2176,

        /// <summary>
        /// vpacksswb zmm {k1}{z}, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpacksswb zmm {k1}{z}, zmm, r32","vpacksswb zmm {k1}{z}, zmm, r32 |  | ")]
        vpacksswb_zmm_k1z_zmm_r32 = 2177,

        /// <summary>
        /// vpacksswb zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpacksswb zmm, zmm, m512","vpacksswb zmm, zmm, m512 |  | ")]
        vpacksswb_zmm_zmm_m512 = 2178,

        /// <summary>
        /// vpacksswb zmm, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpacksswb zmm, zmm, r32","vpacksswb zmm, zmm, r32 |  | ")]
        vpacksswb_zmm_zmm_r32 = 2179,

        /// <summary>
        /// vpackusdw xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpackusdw xmm {k1}{z}, xmm, m128","vpackusdw xmm {k1}{z}, xmm, m128 |  | ")]
        vpackusdw_xmm_k1z_xmm_m128 = 2180,

        /// <summary>
        /// vpackusdw xmm {k1}{z}, xmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpackusdw xmm {k1}{z}, xmm, m32bcst","vpackusdw xmm {k1}{z}, xmm, m32bcst |  | ")]
        vpackusdw_xmm_k1z_xmm_m32bcst = 2181,

        /// <summary>
        /// vpackusdw xmm {k1}{z}, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpackusdw xmm {k1}{z}, xmm, xmm","vpackusdw xmm {k1}{z}, xmm, xmm |  | ")]
        vpackusdw_xmm_k1z_xmm_xmm = 2182,

        /// <summary>
        /// vpackusdw xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpackusdw xmm, xmm, m128","vpackusdw xmm, xmm, m128 |  | ")]
        vpackusdw_xmm_xmm_m128 = 2183,

        /// <summary>
        /// vpackusdw xmm, xmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpackusdw xmm, xmm, m32bcst","vpackusdw xmm, xmm, m32bcst |  | ")]
        vpackusdw_xmm_xmm_m32bcst = 2184,

        /// <summary>
        /// vpackusdw xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpackusdw xmm, xmm, r8","vpackusdw xmm, xmm, r8 |  | ")]
        vpackusdw_xmm_xmm_r8 = 2185,

        /// <summary>
        /// vpackusdw xmm, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpackusdw xmm, xmm, xmm","vpackusdw xmm, xmm, xmm |  | ")]
        vpackusdw_xmm_xmm_xmm = 2186,

        /// <summary>
        /// vpackusdw ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpackusdw ymm {k1}{z}, ymm, m256","vpackusdw ymm {k1}{z}, ymm, m256 |  | ")]
        vpackusdw_ymm_k1z_ymm_m256 = 2187,

        /// <summary>
        /// vpackusdw ymm {k1}{z}, ymm, m32bcst |  | 
        /// </summary>
        [Symbol("vpackusdw ymm {k1}{z}, ymm, m32bcst","vpackusdw ymm {k1}{z}, ymm, m32bcst |  | ")]
        vpackusdw_ymm_k1z_ymm_m32bcst = 2188,

        /// <summary>
        /// vpackusdw ymm {k1}{z}, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpackusdw ymm {k1}{z}, ymm, ymm","vpackusdw ymm {k1}{z}, ymm, ymm |  | ")]
        vpackusdw_ymm_k1z_ymm_ymm = 2189,

        /// <summary>
        /// vpackusdw ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpackusdw ymm, ymm, m256","vpackusdw ymm, ymm, m256 |  | ")]
        vpackusdw_ymm_ymm_m256 = 2190,

        /// <summary>
        /// vpackusdw ymm, ymm, m32bcst |  | 
        /// </summary>
        [Symbol("vpackusdw ymm, ymm, m32bcst","vpackusdw ymm, ymm, m32bcst |  | ")]
        vpackusdw_ymm_ymm_m32bcst = 2191,

        /// <summary>
        /// vpackusdw ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpackusdw ymm, ymm, r16","vpackusdw ymm, ymm, r16 |  | ")]
        vpackusdw_ymm_ymm_r16 = 2192,

        /// <summary>
        /// vpackusdw ymm, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpackusdw ymm, ymm, ymm","vpackusdw ymm, ymm, ymm |  | ")]
        vpackusdw_ymm_ymm_ymm = 2193,

        /// <summary>
        /// vpackusdw zmm {k1}{z}, zmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpackusdw zmm {k1}{z}, zmm, m32bcst","vpackusdw zmm {k1}{z}, zmm, m32bcst |  | ")]
        vpackusdw_zmm_k1z_zmm_m32bcst = 2194,

        /// <summary>
        /// vpackusdw zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpackusdw zmm {k1}{z}, zmm, m512","vpackusdw zmm {k1}{z}, zmm, m512 |  | ")]
        vpackusdw_zmm_k1z_zmm_m512 = 2195,

        /// <summary>
        /// vpackusdw zmm {k1}{z}, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpackusdw zmm {k1}{z}, zmm, zmm","vpackusdw zmm {k1}{z}, zmm, zmm |  | ")]
        vpackusdw_zmm_k1z_zmm_zmm = 2196,

        /// <summary>
        /// vpackusdw zmm, zmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpackusdw zmm, zmm, m32bcst","vpackusdw zmm, zmm, m32bcst |  | ")]
        vpackusdw_zmm_zmm_m32bcst = 2197,

        /// <summary>
        /// vpackusdw zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpackusdw zmm, zmm, m512","vpackusdw zmm, zmm, m512 |  | ")]
        vpackusdw_zmm_zmm_m512 = 2198,

        /// <summary>
        /// vpackusdw zmm, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpackusdw zmm, zmm, zmm","vpackusdw zmm, zmm, zmm |  | ")]
        vpackusdw_zmm_zmm_zmm = 2199,

        /// <summary>
        /// vpackuswb xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpackuswb xmm {k1}{z}, xmm, m128","vpackuswb xmm {k1}{z}, xmm, m128 |  | ")]
        vpackuswb_xmm_k1z_xmm_m128 = 2200,

        /// <summary>
        /// vpackuswb xmm {k1}{z}, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpackuswb xmm {k1}{z}, xmm, r8","vpackuswb xmm {k1}{z}, xmm, r8 |  | ")]
        vpackuswb_xmm_k1z_xmm_r8 = 2201,

        /// <summary>
        /// vpackuswb xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpackuswb xmm, xmm, m128","vpackuswb xmm, xmm, m128 |  | ")]
        vpackuswb_xmm_xmm_m128 = 2202,

        /// <summary>
        /// vpackuswb xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpackuswb xmm, xmm, r8","vpackuswb xmm, xmm, r8 |  | ")]
        vpackuswb_xmm_xmm_r8 = 2203,

        /// <summary>
        /// vpackuswb ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpackuswb ymm {k1}{z}, ymm, m256","vpackuswb ymm {k1}{z}, ymm, m256 |  | ")]
        vpackuswb_ymm_k1z_ymm_m256 = 2204,

        /// <summary>
        /// vpackuswb ymm {k1}{z}, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpackuswb ymm {k1}{z}, ymm, r16","vpackuswb ymm {k1}{z}, ymm, r16 |  | ")]
        vpackuswb_ymm_k1z_ymm_r16 = 2205,

        /// <summary>
        /// vpackuswb ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpackuswb ymm, ymm, m256","vpackuswb ymm, ymm, m256 |  | ")]
        vpackuswb_ymm_ymm_m256 = 2206,

        /// <summary>
        /// vpackuswb ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpackuswb ymm, ymm, r16","vpackuswb ymm, ymm, r16 |  | ")]
        vpackuswb_ymm_ymm_r16 = 2207,

        /// <summary>
        /// vpackuswb zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpackuswb zmm {k1}{z}, zmm, m512","vpackuswb zmm {k1}{z}, zmm, m512 |  | ")]
        vpackuswb_zmm_k1z_zmm_m512 = 2208,

        /// <summary>
        /// vpackuswb zmm {k1}{z}, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpackuswb zmm {k1}{z}, zmm, r32","vpackuswb zmm {k1}{z}, zmm, r32 |  | ")]
        vpackuswb_zmm_k1z_zmm_r32 = 2209,

        /// <summary>
        /// vpackuswb zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpackuswb zmm, zmm, m512","vpackuswb zmm, zmm, m512 |  | ")]
        vpackuswb_zmm_zmm_m512 = 2210,

        /// <summary>
        /// vpackuswb zmm, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpackuswb zmm, zmm, r32","vpackuswb zmm, zmm, r32 |  | ")]
        vpackuswb_zmm_zmm_r32 = 2211,

        /// <summary>
        /// vpaddb xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpaddb xmm {k1}{z}, xmm, m128","vpaddb xmm {k1}{z}, xmm, m128 |  | ")]
        vpaddb_xmm_k1z_xmm_m128 = 2212,

        /// <summary>
        /// vpaddb xmm {k1}{z}, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpaddb xmm {k1}{z}, xmm, r8","vpaddb xmm {k1}{z}, xmm, r8 |  | ")]
        vpaddb_xmm_k1z_xmm_r8 = 2213,

        /// <summary>
        /// vpaddb xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpaddb xmm, xmm, m128","vpaddb xmm, xmm, m128 |  | ")]
        vpaddb_xmm_xmm_m128 = 2214,

        /// <summary>
        /// vpaddb xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpaddb xmm, xmm, r8","vpaddb xmm, xmm, r8 |  | ")]
        vpaddb_xmm_xmm_r8 = 2215,

        /// <summary>
        /// vpaddb ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpaddb ymm {k1}{z}, ymm, m256","vpaddb ymm {k1}{z}, ymm, m256 |  | ")]
        vpaddb_ymm_k1z_ymm_m256 = 2216,

        /// <summary>
        /// vpaddb ymm {k1}{z}, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpaddb ymm {k1}{z}, ymm, r16","vpaddb ymm {k1}{z}, ymm, r16 |  | ")]
        vpaddb_ymm_k1z_ymm_r16 = 2217,

        /// <summary>
        /// vpaddb ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpaddb ymm, ymm, m256","vpaddb ymm, ymm, m256 |  | ")]
        vpaddb_ymm_ymm_m256 = 2218,

        /// <summary>
        /// vpaddb ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpaddb ymm, ymm, r16","vpaddb ymm, ymm, r16 |  | ")]
        vpaddb_ymm_ymm_r16 = 2219,

        /// <summary>
        /// vpaddb zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpaddb zmm {k1}{z}, zmm, m512","vpaddb zmm {k1}{z}, zmm, m512 |  | ")]
        vpaddb_zmm_k1z_zmm_m512 = 2220,

        /// <summary>
        /// vpaddb zmm {k1}{z}, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpaddb zmm {k1}{z}, zmm, r32","vpaddb zmm {k1}{z}, zmm, r32 |  | ")]
        vpaddb_zmm_k1z_zmm_r32 = 2221,

        /// <summary>
        /// vpaddb zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpaddb zmm, zmm, m512","vpaddb zmm, zmm, m512 |  | ")]
        vpaddb_zmm_zmm_m512 = 2222,

        /// <summary>
        /// vpaddb zmm, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpaddb zmm, zmm, r32","vpaddb zmm, zmm, r32 |  | ")]
        vpaddb_zmm_zmm_r32 = 2223,

        /// <summary>
        /// vpaddd xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpaddd xmm {k1}{z}, xmm, m128","vpaddd xmm {k1}{z}, xmm, m128 |  | ")]
        vpaddd_xmm_k1z_xmm_m128 = 2224,

        /// <summary>
        /// vpaddd xmm {k1}{z}, xmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpaddd xmm {k1}{z}, xmm, m32bcst","vpaddd xmm {k1}{z}, xmm, m32bcst |  | ")]
        vpaddd_xmm_k1z_xmm_m32bcst = 2225,

        /// <summary>
        /// vpaddd xmm {k1}{z}, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpaddd xmm {k1}{z}, xmm, xmm","vpaddd xmm {k1}{z}, xmm, xmm |  | ")]
        vpaddd_xmm_k1z_xmm_xmm = 2226,

        /// <summary>
        /// vpaddd xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpaddd xmm, xmm, m128","vpaddd xmm, xmm, m128 |  | ")]
        vpaddd_xmm_xmm_m128 = 2227,

        /// <summary>
        /// vpaddd xmm, xmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpaddd xmm, xmm, m32bcst","vpaddd xmm, xmm, m32bcst |  | ")]
        vpaddd_xmm_xmm_m32bcst = 2228,

        /// <summary>
        /// vpaddd xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpaddd xmm, xmm, r8","vpaddd xmm, xmm, r8 |  | ")]
        vpaddd_xmm_xmm_r8 = 2229,

        /// <summary>
        /// vpaddd xmm, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpaddd xmm, xmm, xmm","vpaddd xmm, xmm, xmm |  | ")]
        vpaddd_xmm_xmm_xmm = 2230,

        /// <summary>
        /// vpaddd ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpaddd ymm {k1}{z}, ymm, m256","vpaddd ymm {k1}{z}, ymm, m256 |  | ")]
        vpaddd_ymm_k1z_ymm_m256 = 2231,

        /// <summary>
        /// vpaddd ymm {k1}{z}, ymm, m32bcst |  | 
        /// </summary>
        [Symbol("vpaddd ymm {k1}{z}, ymm, m32bcst","vpaddd ymm {k1}{z}, ymm, m32bcst |  | ")]
        vpaddd_ymm_k1z_ymm_m32bcst = 2232,

        /// <summary>
        /// vpaddd ymm {k1}{z}, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpaddd ymm {k1}{z}, ymm, ymm","vpaddd ymm {k1}{z}, ymm, ymm |  | ")]
        vpaddd_ymm_k1z_ymm_ymm = 2233,

        /// <summary>
        /// vpaddd ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpaddd ymm, ymm, m256","vpaddd ymm, ymm, m256 |  | ")]
        vpaddd_ymm_ymm_m256 = 2234,

        /// <summary>
        /// vpaddd ymm, ymm, m32bcst |  | 
        /// </summary>
        [Symbol("vpaddd ymm, ymm, m32bcst","vpaddd ymm, ymm, m32bcst |  | ")]
        vpaddd_ymm_ymm_m32bcst = 2235,

        /// <summary>
        /// vpaddd ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpaddd ymm, ymm, r16","vpaddd ymm, ymm, r16 |  | ")]
        vpaddd_ymm_ymm_r16 = 2236,

        /// <summary>
        /// vpaddd ymm, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpaddd ymm, ymm, ymm","vpaddd ymm, ymm, ymm |  | ")]
        vpaddd_ymm_ymm_ymm = 2237,

        /// <summary>
        /// vpaddd zmm {k1}{z}, zmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpaddd zmm {k1}{z}, zmm, m32bcst","vpaddd zmm {k1}{z}, zmm, m32bcst |  | ")]
        vpaddd_zmm_k1z_zmm_m32bcst = 2238,

        /// <summary>
        /// vpaddd zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpaddd zmm {k1}{z}, zmm, m512","vpaddd zmm {k1}{z}, zmm, m512 |  | ")]
        vpaddd_zmm_k1z_zmm_m512 = 2239,

        /// <summary>
        /// vpaddd zmm {k1}{z}, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpaddd zmm {k1}{z}, zmm, zmm","vpaddd zmm {k1}{z}, zmm, zmm |  | ")]
        vpaddd_zmm_k1z_zmm_zmm = 2240,

        /// <summary>
        /// vpaddd zmm, zmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpaddd zmm, zmm, m32bcst","vpaddd zmm, zmm, m32bcst |  | ")]
        vpaddd_zmm_zmm_m32bcst = 2241,

        /// <summary>
        /// vpaddd zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpaddd zmm, zmm, m512","vpaddd zmm, zmm, m512 |  | ")]
        vpaddd_zmm_zmm_m512 = 2242,

        /// <summary>
        /// vpaddd zmm, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpaddd zmm, zmm, zmm","vpaddd zmm, zmm, zmm |  | ")]
        vpaddd_zmm_zmm_zmm = 2243,

        /// <summary>
        /// vpaddq xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpaddq xmm {k1}{z}, xmm, m128","vpaddq xmm {k1}{z}, xmm, m128 |  | ")]
        vpaddq_xmm_k1z_xmm_m128 = 2244,

        /// <summary>
        /// vpaddq xmm {k1}{z}, xmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpaddq xmm {k1}{z}, xmm, m64bcst","vpaddq xmm {k1}{z}, xmm, m64bcst |  | ")]
        vpaddq_xmm_k1z_xmm_m64bcst = 2245,

        /// <summary>
        /// vpaddq xmm {k1}{z}, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpaddq xmm {k1}{z}, xmm, xmm","vpaddq xmm {k1}{z}, xmm, xmm |  | ")]
        vpaddq_xmm_k1z_xmm_xmm = 2246,

        /// <summary>
        /// vpaddq xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpaddq xmm, xmm, m128","vpaddq xmm, xmm, m128 |  | ")]
        vpaddq_xmm_xmm_m128 = 2247,

        /// <summary>
        /// vpaddq xmm, xmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpaddq xmm, xmm, m64bcst","vpaddq xmm, xmm, m64bcst |  | ")]
        vpaddq_xmm_xmm_m64bcst = 2248,

        /// <summary>
        /// vpaddq xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpaddq xmm, xmm, r8","vpaddq xmm, xmm, r8 |  | ")]
        vpaddq_xmm_xmm_r8 = 2249,

        /// <summary>
        /// vpaddq xmm, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpaddq xmm, xmm, xmm","vpaddq xmm, xmm, xmm |  | ")]
        vpaddq_xmm_xmm_xmm = 2250,

        /// <summary>
        /// vpaddq ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpaddq ymm {k1}{z}, ymm, m256","vpaddq ymm {k1}{z}, ymm, m256 |  | ")]
        vpaddq_ymm_k1z_ymm_m256 = 2251,

        /// <summary>
        /// vpaddq ymm {k1}{z}, ymm, m64bcst |  | 
        /// </summary>
        [Symbol("vpaddq ymm {k1}{z}, ymm, m64bcst","vpaddq ymm {k1}{z}, ymm, m64bcst |  | ")]
        vpaddq_ymm_k1z_ymm_m64bcst = 2252,

        /// <summary>
        /// vpaddq ymm {k1}{z}, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpaddq ymm {k1}{z}, ymm, ymm","vpaddq ymm {k1}{z}, ymm, ymm |  | ")]
        vpaddq_ymm_k1z_ymm_ymm = 2253,

        /// <summary>
        /// vpaddq ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpaddq ymm, ymm, m256","vpaddq ymm, ymm, m256 |  | ")]
        vpaddq_ymm_ymm_m256 = 2254,

        /// <summary>
        /// vpaddq ymm, ymm, m64bcst |  | 
        /// </summary>
        [Symbol("vpaddq ymm, ymm, m64bcst","vpaddq ymm, ymm, m64bcst |  | ")]
        vpaddq_ymm_ymm_m64bcst = 2255,

        /// <summary>
        /// vpaddq ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpaddq ymm, ymm, r16","vpaddq ymm, ymm, r16 |  | ")]
        vpaddq_ymm_ymm_r16 = 2256,

        /// <summary>
        /// vpaddq ymm, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpaddq ymm, ymm, ymm","vpaddq ymm, ymm, ymm |  | ")]
        vpaddq_ymm_ymm_ymm = 2257,

        /// <summary>
        /// vpaddq zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpaddq zmm {k1}{z}, zmm, m512","vpaddq zmm {k1}{z}, zmm, m512 |  | ")]
        vpaddq_zmm_k1z_zmm_m512 = 2258,

        /// <summary>
        /// vpaddq zmm {k1}{z}, zmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpaddq zmm {k1}{z}, zmm, m64bcst","vpaddq zmm {k1}{z}, zmm, m64bcst |  | ")]
        vpaddq_zmm_k1z_zmm_m64bcst = 2259,

        /// <summary>
        /// vpaddq zmm {k1}{z}, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpaddq zmm {k1}{z}, zmm, zmm","vpaddq zmm {k1}{z}, zmm, zmm |  | ")]
        vpaddq_zmm_k1z_zmm_zmm = 2260,

        /// <summary>
        /// vpaddq zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpaddq zmm, zmm, m512","vpaddq zmm, zmm, m512 |  | ")]
        vpaddq_zmm_zmm_m512 = 2261,

        /// <summary>
        /// vpaddq zmm, zmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpaddq zmm, zmm, m64bcst","vpaddq zmm, zmm, m64bcst |  | ")]
        vpaddq_zmm_zmm_m64bcst = 2262,

        /// <summary>
        /// vpaddq zmm, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpaddq zmm, zmm, zmm","vpaddq zmm, zmm, zmm |  | ")]
        vpaddq_zmm_zmm_zmm = 2263,

        /// <summary>
        /// vpaddsb xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpaddsb xmm {k1}{z}, xmm, m128","vpaddsb xmm {k1}{z}, xmm, m128 |  | ")]
        vpaddsb_xmm_k1z_xmm_m128 = 2264,

        /// <summary>
        /// vpaddsb xmm {k1}{z}, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpaddsb xmm {k1}{z}, xmm, r8","vpaddsb xmm {k1}{z}, xmm, r8 |  | ")]
        vpaddsb_xmm_k1z_xmm_r8 = 2265,

        /// <summary>
        /// vpaddsb xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpaddsb xmm, xmm, m128","vpaddsb xmm, xmm, m128 |  | ")]
        vpaddsb_xmm_xmm_m128 = 2266,

        /// <summary>
        /// vpaddsb xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpaddsb xmm, xmm, r8","vpaddsb xmm, xmm, r8 |  | ")]
        vpaddsb_xmm_xmm_r8 = 2267,

        /// <summary>
        /// vpaddsb ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpaddsb ymm {k1}{z}, ymm, m256","vpaddsb ymm {k1}{z}, ymm, m256 |  | ")]
        vpaddsb_ymm_k1z_ymm_m256 = 2268,

        /// <summary>
        /// vpaddsb ymm {k1}{z}, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpaddsb ymm {k1}{z}, ymm, r16","vpaddsb ymm {k1}{z}, ymm, r16 |  | ")]
        vpaddsb_ymm_k1z_ymm_r16 = 2269,

        /// <summary>
        /// vpaddsb ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpaddsb ymm, ymm, m256","vpaddsb ymm, ymm, m256 |  | ")]
        vpaddsb_ymm_ymm_m256 = 2270,

        /// <summary>
        /// vpaddsb ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpaddsb ymm, ymm, r16","vpaddsb ymm, ymm, r16 |  | ")]
        vpaddsb_ymm_ymm_r16 = 2271,

        /// <summary>
        /// vpaddsb zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpaddsb zmm {k1}{z}, zmm, m512","vpaddsb zmm {k1}{z}, zmm, m512 |  | ")]
        vpaddsb_zmm_k1z_zmm_m512 = 2272,

        /// <summary>
        /// vpaddsb zmm {k1}{z}, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpaddsb zmm {k1}{z}, zmm, r32","vpaddsb zmm {k1}{z}, zmm, r32 |  | ")]
        vpaddsb_zmm_k1z_zmm_r32 = 2273,

        /// <summary>
        /// vpaddsb zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpaddsb zmm, zmm, m512","vpaddsb zmm, zmm, m512 |  | ")]
        vpaddsb_zmm_zmm_m512 = 2274,

        /// <summary>
        /// vpaddsb zmm, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpaddsb zmm, zmm, r32","vpaddsb zmm, zmm, r32 |  | ")]
        vpaddsb_zmm_zmm_r32 = 2275,

        /// <summary>
        /// vpaddsw xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpaddsw xmm {k1}{z}, xmm, m128","vpaddsw xmm {k1}{z}, xmm, m128 |  | ")]
        vpaddsw_xmm_k1z_xmm_m128 = 2276,

        /// <summary>
        /// vpaddsw xmm {k1}{z}, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpaddsw xmm {k1}{z}, xmm, r8","vpaddsw xmm {k1}{z}, xmm, r8 |  | ")]
        vpaddsw_xmm_k1z_xmm_r8 = 2277,

        /// <summary>
        /// vpaddsw xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpaddsw xmm, xmm, m128","vpaddsw xmm, xmm, m128 |  | ")]
        vpaddsw_xmm_xmm_m128 = 2278,

        /// <summary>
        /// vpaddsw xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpaddsw xmm, xmm, r8","vpaddsw xmm, xmm, r8 |  | ")]
        vpaddsw_xmm_xmm_r8 = 2279,

        /// <summary>
        /// vpaddsw ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpaddsw ymm {k1}{z}, ymm, m256","vpaddsw ymm {k1}{z}, ymm, m256 |  | ")]
        vpaddsw_ymm_k1z_ymm_m256 = 2280,

        /// <summary>
        /// vpaddsw ymm {k1}{z}, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpaddsw ymm {k1}{z}, ymm, r16","vpaddsw ymm {k1}{z}, ymm, r16 |  | ")]
        vpaddsw_ymm_k1z_ymm_r16 = 2281,

        /// <summary>
        /// vpaddsw ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpaddsw ymm, ymm, m256","vpaddsw ymm, ymm, m256 |  | ")]
        vpaddsw_ymm_ymm_m256 = 2282,

        /// <summary>
        /// vpaddsw ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpaddsw ymm, ymm, r16","vpaddsw ymm, ymm, r16 |  | ")]
        vpaddsw_ymm_ymm_r16 = 2283,

        /// <summary>
        /// vpaddsw zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpaddsw zmm {k1}{z}, zmm, m512","vpaddsw zmm {k1}{z}, zmm, m512 |  | ")]
        vpaddsw_zmm_k1z_zmm_m512 = 2284,

        /// <summary>
        /// vpaddsw zmm {k1}{z}, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpaddsw zmm {k1}{z}, zmm, r32","vpaddsw zmm {k1}{z}, zmm, r32 |  | ")]
        vpaddsw_zmm_k1z_zmm_r32 = 2285,

        /// <summary>
        /// vpaddsw zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpaddsw zmm, zmm, m512","vpaddsw zmm, zmm, m512 |  | ")]
        vpaddsw_zmm_zmm_m512 = 2286,

        /// <summary>
        /// vpaddsw zmm, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpaddsw zmm, zmm, r32","vpaddsw zmm, zmm, r32 |  | ")]
        vpaddsw_zmm_zmm_r32 = 2287,

        /// <summary>
        /// vpaddusb xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpaddusb xmm {k1}{z}, xmm, m128","vpaddusb xmm {k1}{z}, xmm, m128 |  | ")]
        vpaddusb_xmm_k1z_xmm_m128 = 2288,

        /// <summary>
        /// vpaddusb xmm {k1}{z}, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpaddusb xmm {k1}{z}, xmm, r8","vpaddusb xmm {k1}{z}, xmm, r8 |  | ")]
        vpaddusb_xmm_k1z_xmm_r8 = 2289,

        /// <summary>
        /// vpaddusb xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpaddusb xmm, xmm, m128","vpaddusb xmm, xmm, m128 |  | ")]
        vpaddusb_xmm_xmm_m128 = 2290,

        /// <summary>
        /// vpaddusb xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpaddusb xmm, xmm, r8","vpaddusb xmm, xmm, r8 |  | ")]
        vpaddusb_xmm_xmm_r8 = 2291,

        /// <summary>
        /// vpaddusb ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpaddusb ymm {k1}{z}, ymm, m256","vpaddusb ymm {k1}{z}, ymm, m256 |  | ")]
        vpaddusb_ymm_k1z_ymm_m256 = 2292,

        /// <summary>
        /// vpaddusb ymm {k1}{z}, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpaddusb ymm {k1}{z}, ymm, r16","vpaddusb ymm {k1}{z}, ymm, r16 |  | ")]
        vpaddusb_ymm_k1z_ymm_r16 = 2293,

        /// <summary>
        /// vpaddusb ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpaddusb ymm, ymm, m256","vpaddusb ymm, ymm, m256 |  | ")]
        vpaddusb_ymm_ymm_m256 = 2294,

        /// <summary>
        /// vpaddusb ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpaddusb ymm, ymm, r16","vpaddusb ymm, ymm, r16 |  | ")]
        vpaddusb_ymm_ymm_r16 = 2295,

        /// <summary>
        /// vpaddusb zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpaddusb zmm {k1}{z}, zmm, m512","vpaddusb zmm {k1}{z}, zmm, m512 |  | ")]
        vpaddusb_zmm_k1z_zmm_m512 = 2296,

        /// <summary>
        /// vpaddusb zmm {k1}{z}, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpaddusb zmm {k1}{z}, zmm, r32","vpaddusb zmm {k1}{z}, zmm, r32 |  | ")]
        vpaddusb_zmm_k1z_zmm_r32 = 2297,

        /// <summary>
        /// vpaddusb zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpaddusb zmm, zmm, m512","vpaddusb zmm, zmm, m512 |  | ")]
        vpaddusb_zmm_zmm_m512 = 2298,

        /// <summary>
        /// vpaddusb zmm, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpaddusb zmm, zmm, r32","vpaddusb zmm, zmm, r32 |  | ")]
        vpaddusb_zmm_zmm_r32 = 2299,

        /// <summary>
        /// vpaddusw xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpaddusw xmm {k1}{z}, xmm, m128","vpaddusw xmm {k1}{z}, xmm, m128 |  | ")]
        vpaddusw_xmm_k1z_xmm_m128 = 2300,

        /// <summary>
        /// vpaddusw xmm {k1}{z}, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpaddusw xmm {k1}{z}, xmm, r8","vpaddusw xmm {k1}{z}, xmm, r8 |  | ")]
        vpaddusw_xmm_k1z_xmm_r8 = 2301,

        /// <summary>
        /// vpaddusw xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpaddusw xmm, xmm, m128","vpaddusw xmm, xmm, m128 |  | ")]
        vpaddusw_xmm_xmm_m128 = 2302,

        /// <summary>
        /// vpaddusw xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpaddusw xmm, xmm, r8","vpaddusw xmm, xmm, r8 |  | ")]
        vpaddusw_xmm_xmm_r8 = 2303,

        /// <summary>
        /// vpaddusw ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpaddusw ymm {k1}{z}, ymm, m256","vpaddusw ymm {k1}{z}, ymm, m256 |  | ")]
        vpaddusw_ymm_k1z_ymm_m256 = 2304,

        /// <summary>
        /// vpaddusw ymm {k1}{z}, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpaddusw ymm {k1}{z}, ymm, r16","vpaddusw ymm {k1}{z}, ymm, r16 |  | ")]
        vpaddusw_ymm_k1z_ymm_r16 = 2305,

        /// <summary>
        /// vpaddusw ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpaddusw ymm, ymm, m256","vpaddusw ymm, ymm, m256 |  | ")]
        vpaddusw_ymm_ymm_m256 = 2306,

        /// <summary>
        /// vpaddusw ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpaddusw ymm, ymm, r16","vpaddusw ymm, ymm, r16 |  | ")]
        vpaddusw_ymm_ymm_r16 = 2307,

        /// <summary>
        /// vpaddw xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpaddw xmm {k1}{z}, xmm, m128","vpaddw xmm {k1}{z}, xmm, m128 |  | ")]
        vpaddw_xmm_k1z_xmm_m128 = 2308,

        /// <summary>
        /// vpaddw xmm {k1}{z}, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpaddw xmm {k1}{z}, xmm, r8","vpaddw xmm {k1}{z}, xmm, r8 |  | ")]
        vpaddw_xmm_k1z_xmm_r8 = 2309,

        /// <summary>
        /// vpaddw xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpaddw xmm, xmm, m128","vpaddw xmm, xmm, m128 |  | ")]
        vpaddw_xmm_xmm_m128 = 2310,

        /// <summary>
        /// vpaddw xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpaddw xmm, xmm, r8","vpaddw xmm, xmm, r8 |  | ")]
        vpaddw_xmm_xmm_r8 = 2311,

        /// <summary>
        /// vpaddw ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpaddw ymm {k1}{z}, ymm, m256","vpaddw ymm {k1}{z}, ymm, m256 |  | ")]
        vpaddw_ymm_k1z_ymm_m256 = 2312,

        /// <summary>
        /// vpaddw ymm {k1}{z}, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpaddw ymm {k1}{z}, ymm, r16","vpaddw ymm {k1}{z}, ymm, r16 |  | ")]
        vpaddw_ymm_k1z_ymm_r16 = 2313,

        /// <summary>
        /// vpaddw ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpaddw ymm, ymm, m256","vpaddw ymm, ymm, m256 |  | ")]
        vpaddw_ymm_ymm_m256 = 2314,

        /// <summary>
        /// vpaddw ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpaddw ymm, ymm, r16","vpaddw ymm, ymm, r16 |  | ")]
        vpaddw_ymm_ymm_r16 = 2315,

        /// <summary>
        /// vpaddw zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpaddw zmm {k1}{z}, zmm, m512","vpaddw zmm {k1}{z}, zmm, m512 |  | ")]
        vpaddw_zmm_k1z_zmm_m512 = 2316,

        /// <summary>
        /// vpaddw zmm {k1}{z}, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpaddw zmm {k1}{z}, zmm, r32","vpaddw zmm {k1}{z}, zmm, r32 |  | ")]
        vpaddw_zmm_k1z_zmm_r32 = 2317,

        /// <summary>
        /// vpaddw zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpaddw zmm, zmm, m512","vpaddw zmm, zmm, m512 |  | ")]
        vpaddw_zmm_zmm_m512 = 2318,

        /// <summary>
        /// vpaddw zmm, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpaddw zmm, zmm, r32","vpaddw zmm, zmm, r32 |  | ")]
        vpaddw_zmm_zmm_r32 = 2319,

        /// <summary>
        /// vpand xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpand xmm, xmm, m128","vpand xmm, xmm, m128 |  | ")]
        vpand_xmm_xmm_m128 = 2320,

        /// <summary>
        /// vpand xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpand xmm, xmm, r8","vpand xmm, xmm, r8 |  | ")]
        vpand_xmm_xmm_r8 = 2321,

        /// <summary>
        /// vpand ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpand ymm, ymm, m256","vpand ymm, ymm, m256 |  | ")]
        vpand_ymm_ymm_m256 = 2322,

        /// <summary>
        /// vpand ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpand ymm, ymm, r16","vpand ymm, ymm, r16 |  | ")]
        vpand_ymm_ymm_r16 = 2323,

        /// <summary>
        /// vpandd xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpandd xmm {k1}{z}, xmm, m128","vpandd xmm {k1}{z}, xmm, m128 |  | ")]
        vpandd_xmm_k1z_xmm_m128 = 2324,

        /// <summary>
        /// vpandd xmm {k1}{z}, xmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpandd xmm {k1}{z}, xmm, m32bcst","vpandd xmm {k1}{z}, xmm, m32bcst |  | ")]
        vpandd_xmm_k1z_xmm_m32bcst = 2325,

        /// <summary>
        /// vpandd xmm {k1}{z}, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpandd xmm {k1}{z}, xmm, xmm","vpandd xmm {k1}{z}, xmm, xmm |  | ")]
        vpandd_xmm_k1z_xmm_xmm = 2326,

        /// <summary>
        /// vpandd xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpandd xmm, xmm, m128","vpandd xmm, xmm, m128 |  | ")]
        vpandd_xmm_xmm_m128 = 2327,

        /// <summary>
        /// vpandd xmm, xmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpandd xmm, xmm, m32bcst","vpandd xmm, xmm, m32bcst |  | ")]
        vpandd_xmm_xmm_m32bcst = 2328,

        /// <summary>
        /// vpandd xmm, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpandd xmm, xmm, xmm","vpandd xmm, xmm, xmm |  | ")]
        vpandd_xmm_xmm_xmm = 2329,

        /// <summary>
        /// vpandd ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpandd ymm {k1}{z}, ymm, m256","vpandd ymm {k1}{z}, ymm, m256 |  | ")]
        vpandd_ymm_k1z_ymm_m256 = 2330,

        /// <summary>
        /// vpandd ymm {k1}{z}, ymm, m32bcst |  | 
        /// </summary>
        [Symbol("vpandd ymm {k1}{z}, ymm, m32bcst","vpandd ymm {k1}{z}, ymm, m32bcst |  | ")]
        vpandd_ymm_k1z_ymm_m32bcst = 2331,

        /// <summary>
        /// vpandd ymm {k1}{z}, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpandd ymm {k1}{z}, ymm, ymm","vpandd ymm {k1}{z}, ymm, ymm |  | ")]
        vpandd_ymm_k1z_ymm_ymm = 2332,

        /// <summary>
        /// vpandd ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpandd ymm, ymm, m256","vpandd ymm, ymm, m256 |  | ")]
        vpandd_ymm_ymm_m256 = 2333,

        /// <summary>
        /// vpandd ymm, ymm, m32bcst |  | 
        /// </summary>
        [Symbol("vpandd ymm, ymm, m32bcst","vpandd ymm, ymm, m32bcst |  | ")]
        vpandd_ymm_ymm_m32bcst = 2334,

        /// <summary>
        /// vpandd ymm, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpandd ymm, ymm, ymm","vpandd ymm, ymm, ymm |  | ")]
        vpandd_ymm_ymm_ymm = 2335,

        /// <summary>
        /// vpandd zmm {k1}{z}, zmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpandd zmm {k1}{z}, zmm, m32bcst","vpandd zmm {k1}{z}, zmm, m32bcst |  | ")]
        vpandd_zmm_k1z_zmm_m32bcst = 2336,

        /// <summary>
        /// vpandd zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpandd zmm {k1}{z}, zmm, m512","vpandd zmm {k1}{z}, zmm, m512 |  | ")]
        vpandd_zmm_k1z_zmm_m512 = 2337,

        /// <summary>
        /// vpandd zmm {k1}{z}, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpandd zmm {k1}{z}, zmm, zmm","vpandd zmm {k1}{z}, zmm, zmm |  | ")]
        vpandd_zmm_k1z_zmm_zmm = 2338,

        /// <summary>
        /// vpandd zmm, zmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpandd zmm, zmm, m32bcst","vpandd zmm, zmm, m32bcst |  | ")]
        vpandd_zmm_zmm_m32bcst = 2339,

        /// <summary>
        /// vpandd zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpandd zmm, zmm, m512","vpandd zmm, zmm, m512 |  | ")]
        vpandd_zmm_zmm_m512 = 2340,

        /// <summary>
        /// vpandd zmm, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpandd zmm, zmm, zmm","vpandd zmm, zmm, zmm |  | ")]
        vpandd_zmm_zmm_zmm = 2341,

        /// <summary>
        /// vpandn xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpandn xmm, xmm, m128","vpandn xmm, xmm, m128 |  | ")]
        vpandn_xmm_xmm_m128 = 2342,

        /// <summary>
        /// vpandn xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpandn xmm, xmm, r8","vpandn xmm, xmm, r8 |  | ")]
        vpandn_xmm_xmm_r8 = 2343,

        /// <summary>
        /// vpandn ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpandn ymm, ymm, m256","vpandn ymm, ymm, m256 |  | ")]
        vpandn_ymm_ymm_m256 = 2344,

        /// <summary>
        /// vpandn ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpandn ymm, ymm, r16","vpandn ymm, ymm, r16 |  | ")]
        vpandn_ymm_ymm_r16 = 2345,

        /// <summary>
        /// vpandnd xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpandnd xmm {k1}{z}, xmm, m128","vpandnd xmm {k1}{z}, xmm, m128 |  | ")]
        vpandnd_xmm_k1z_xmm_m128 = 2346,

        /// <summary>
        /// vpandnd xmm {k1}{z}, xmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpandnd xmm {k1}{z}, xmm, m32bcst","vpandnd xmm {k1}{z}, xmm, m32bcst |  | ")]
        vpandnd_xmm_k1z_xmm_m32bcst = 2347,

        /// <summary>
        /// vpandnd xmm {k1}{z}, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpandnd xmm {k1}{z}, xmm, xmm","vpandnd xmm {k1}{z}, xmm, xmm |  | ")]
        vpandnd_xmm_k1z_xmm_xmm = 2348,

        /// <summary>
        /// vpandnd xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpandnd xmm, xmm, m128","vpandnd xmm, xmm, m128 |  | ")]
        vpandnd_xmm_xmm_m128 = 2349,

        /// <summary>
        /// vpandnd xmm, xmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpandnd xmm, xmm, m32bcst","vpandnd xmm, xmm, m32bcst |  | ")]
        vpandnd_xmm_xmm_m32bcst = 2350,

        /// <summary>
        /// vpandnd xmm, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpandnd xmm, xmm, xmm","vpandnd xmm, xmm, xmm |  | ")]
        vpandnd_xmm_xmm_xmm = 2351,

        /// <summary>
        /// vpandnd ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpandnd ymm {k1}{z}, ymm, m256","vpandnd ymm {k1}{z}, ymm, m256 |  | ")]
        vpandnd_ymm_k1z_ymm_m256 = 2352,

        /// <summary>
        /// vpandnd ymm {k1}{z}, ymm, m32bcst |  | 
        /// </summary>
        [Symbol("vpandnd ymm {k1}{z}, ymm, m32bcst","vpandnd ymm {k1}{z}, ymm, m32bcst |  | ")]
        vpandnd_ymm_k1z_ymm_m32bcst = 2353,

        /// <summary>
        /// vpandnd ymm {k1}{z}, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpandnd ymm {k1}{z}, ymm, ymm","vpandnd ymm {k1}{z}, ymm, ymm |  | ")]
        vpandnd_ymm_k1z_ymm_ymm = 2354,

        /// <summary>
        /// vpandnd ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpandnd ymm, ymm, m256","vpandnd ymm, ymm, m256 |  | ")]
        vpandnd_ymm_ymm_m256 = 2355,

        /// <summary>
        /// vpandnd ymm, ymm, m32bcst |  | 
        /// </summary>
        [Symbol("vpandnd ymm, ymm, m32bcst","vpandnd ymm, ymm, m32bcst |  | ")]
        vpandnd_ymm_ymm_m32bcst = 2356,

        /// <summary>
        /// vpandnd ymm, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpandnd ymm, ymm, ymm","vpandnd ymm, ymm, ymm |  | ")]
        vpandnd_ymm_ymm_ymm = 2357,

        /// <summary>
        /// vpandnd zmm {k1}{z}, zmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpandnd zmm {k1}{z}, zmm, m32bcst","vpandnd zmm {k1}{z}, zmm, m32bcst |  | ")]
        vpandnd_zmm_k1z_zmm_m32bcst = 2358,

        /// <summary>
        /// vpandnd zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpandnd zmm {k1}{z}, zmm, m512","vpandnd zmm {k1}{z}, zmm, m512 |  | ")]
        vpandnd_zmm_k1z_zmm_m512 = 2359,

        /// <summary>
        /// vpandnd zmm {k1}{z}, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpandnd zmm {k1}{z}, zmm, zmm","vpandnd zmm {k1}{z}, zmm, zmm |  | ")]
        vpandnd_zmm_k1z_zmm_zmm = 2360,

        /// <summary>
        /// vpandnd zmm, zmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpandnd zmm, zmm, m32bcst","vpandnd zmm, zmm, m32bcst |  | ")]
        vpandnd_zmm_zmm_m32bcst = 2361,

        /// <summary>
        /// vpandnd zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpandnd zmm, zmm, m512","vpandnd zmm, zmm, m512 |  | ")]
        vpandnd_zmm_zmm_m512 = 2362,

        /// <summary>
        /// vpandnd zmm, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpandnd zmm, zmm, zmm","vpandnd zmm, zmm, zmm |  | ")]
        vpandnd_zmm_zmm_zmm = 2363,

        /// <summary>
        /// vpandnq xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpandnq xmm {k1}{z}, xmm, m128","vpandnq xmm {k1}{z}, xmm, m128 |  | ")]
        vpandnq_xmm_k1z_xmm_m128 = 2364,

        /// <summary>
        /// vpandnq xmm {k1}{z}, xmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpandnq xmm {k1}{z}, xmm, m64bcst","vpandnq xmm {k1}{z}, xmm, m64bcst |  | ")]
        vpandnq_xmm_k1z_xmm_m64bcst = 2365,

        /// <summary>
        /// vpandnq xmm {k1}{z}, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpandnq xmm {k1}{z}, xmm, xmm","vpandnq xmm {k1}{z}, xmm, xmm |  | ")]
        vpandnq_xmm_k1z_xmm_xmm = 2366,

        /// <summary>
        /// vpandnq xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpandnq xmm, xmm, m128","vpandnq xmm, xmm, m128 |  | ")]
        vpandnq_xmm_xmm_m128 = 2367,

        /// <summary>
        /// vpandnq xmm, xmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpandnq xmm, xmm, m64bcst","vpandnq xmm, xmm, m64bcst |  | ")]
        vpandnq_xmm_xmm_m64bcst = 2368,

        /// <summary>
        /// vpandnq xmm, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpandnq xmm, xmm, xmm","vpandnq xmm, xmm, xmm |  | ")]
        vpandnq_xmm_xmm_xmm = 2369,

        /// <summary>
        /// vpandnq ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpandnq ymm {k1}{z}, ymm, m256","vpandnq ymm {k1}{z}, ymm, m256 |  | ")]
        vpandnq_ymm_k1z_ymm_m256 = 2370,

        /// <summary>
        /// vpandnq ymm {k1}{z}, ymm, m64bcst |  | 
        /// </summary>
        [Symbol("vpandnq ymm {k1}{z}, ymm, m64bcst","vpandnq ymm {k1}{z}, ymm, m64bcst |  | ")]
        vpandnq_ymm_k1z_ymm_m64bcst = 2371,

        /// <summary>
        /// vpandnq ymm {k1}{z}, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpandnq ymm {k1}{z}, ymm, ymm","vpandnq ymm {k1}{z}, ymm, ymm |  | ")]
        vpandnq_ymm_k1z_ymm_ymm = 2372,

        /// <summary>
        /// vpandnq ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpandnq ymm, ymm, m256","vpandnq ymm, ymm, m256 |  | ")]
        vpandnq_ymm_ymm_m256 = 2373,

        /// <summary>
        /// vpandnq ymm, ymm, m64bcst |  | 
        /// </summary>
        [Symbol("vpandnq ymm, ymm, m64bcst","vpandnq ymm, ymm, m64bcst |  | ")]
        vpandnq_ymm_ymm_m64bcst = 2374,

        /// <summary>
        /// vpandnq ymm, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpandnq ymm, ymm, ymm","vpandnq ymm, ymm, ymm |  | ")]
        vpandnq_ymm_ymm_ymm = 2375,

        /// <summary>
        /// vpandnq zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpandnq zmm {k1}{z}, zmm, m512","vpandnq zmm {k1}{z}, zmm, m512 |  | ")]
        vpandnq_zmm_k1z_zmm_m512 = 2376,

        /// <summary>
        /// vpandnq zmm {k1}{z}, zmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpandnq zmm {k1}{z}, zmm, m64bcst","vpandnq zmm {k1}{z}, zmm, m64bcst |  | ")]
        vpandnq_zmm_k1z_zmm_m64bcst = 2377,

        /// <summary>
        /// vpandnq zmm {k1}{z}, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpandnq zmm {k1}{z}, zmm, zmm","vpandnq zmm {k1}{z}, zmm, zmm |  | ")]
        vpandnq_zmm_k1z_zmm_zmm = 2378,

        /// <summary>
        /// vpandnq zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpandnq zmm, zmm, m512","vpandnq zmm, zmm, m512 |  | ")]
        vpandnq_zmm_zmm_m512 = 2379,

        /// <summary>
        /// vpandnq zmm, zmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpandnq zmm, zmm, m64bcst","vpandnq zmm, zmm, m64bcst |  | ")]
        vpandnq_zmm_zmm_m64bcst = 2380,

        /// <summary>
        /// vpandnq zmm, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpandnq zmm, zmm, zmm","vpandnq zmm, zmm, zmm |  | ")]
        vpandnq_zmm_zmm_zmm = 2381,

        /// <summary>
        /// vpandq xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpandq xmm {k1}{z}, xmm, m128","vpandq xmm {k1}{z}, xmm, m128 |  | ")]
        vpandq_xmm_k1z_xmm_m128 = 2382,

        /// <summary>
        /// vpandq xmm {k1}{z}, xmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpandq xmm {k1}{z}, xmm, m64bcst","vpandq xmm {k1}{z}, xmm, m64bcst |  | ")]
        vpandq_xmm_k1z_xmm_m64bcst = 2383,

        /// <summary>
        /// vpandq xmm {k1}{z}, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpandq xmm {k1}{z}, xmm, xmm","vpandq xmm {k1}{z}, xmm, xmm |  | ")]
        vpandq_xmm_k1z_xmm_xmm = 2384,

        /// <summary>
        /// vpandq xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpandq xmm, xmm, m128","vpandq xmm, xmm, m128 |  | ")]
        vpandq_xmm_xmm_m128 = 2385,

        /// <summary>
        /// vpandq xmm, xmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpandq xmm, xmm, m64bcst","vpandq xmm, xmm, m64bcst |  | ")]
        vpandq_xmm_xmm_m64bcst = 2386,

        /// <summary>
        /// vpandq xmm, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpandq xmm, xmm, xmm","vpandq xmm, xmm, xmm |  | ")]
        vpandq_xmm_xmm_xmm = 2387,

        /// <summary>
        /// vpandq ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpandq ymm {k1}{z}, ymm, m256","vpandq ymm {k1}{z}, ymm, m256 |  | ")]
        vpandq_ymm_k1z_ymm_m256 = 2388,

        /// <summary>
        /// vpandq ymm {k1}{z}, ymm, m64bcst |  | 
        /// </summary>
        [Symbol("vpandq ymm {k1}{z}, ymm, m64bcst","vpandq ymm {k1}{z}, ymm, m64bcst |  | ")]
        vpandq_ymm_k1z_ymm_m64bcst = 2389,

        /// <summary>
        /// vpandq ymm {k1}{z}, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpandq ymm {k1}{z}, ymm, ymm","vpandq ymm {k1}{z}, ymm, ymm |  | ")]
        vpandq_ymm_k1z_ymm_ymm = 2390,

        /// <summary>
        /// vpandq ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpandq ymm, ymm, m256","vpandq ymm, ymm, m256 |  | ")]
        vpandq_ymm_ymm_m256 = 2391,

        /// <summary>
        /// vpandq ymm, ymm, m64bcst |  | 
        /// </summary>
        [Symbol("vpandq ymm, ymm, m64bcst","vpandq ymm, ymm, m64bcst |  | ")]
        vpandq_ymm_ymm_m64bcst = 2392,

        /// <summary>
        /// vpandq ymm, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpandq ymm, ymm, ymm","vpandq ymm, ymm, ymm |  | ")]
        vpandq_ymm_ymm_ymm = 2393,

        /// <summary>
        /// vpandq zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpandq zmm {k1}{z}, zmm, m512","vpandq zmm {k1}{z}, zmm, m512 |  | ")]
        vpandq_zmm_k1z_zmm_m512 = 2394,

        /// <summary>
        /// vpandq zmm {k1}{z}, zmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpandq zmm {k1}{z}, zmm, m64bcst","vpandq zmm {k1}{z}, zmm, m64bcst |  | ")]
        vpandq_zmm_k1z_zmm_m64bcst = 2395,

        /// <summary>
        /// vpandq zmm {k1}{z}, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpandq zmm {k1}{z}, zmm, zmm","vpandq zmm {k1}{z}, zmm, zmm |  | ")]
        vpandq_zmm_k1z_zmm_zmm = 2396,

        /// <summary>
        /// vpandq zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpandq zmm, zmm, m512","vpandq zmm, zmm, m512 |  | ")]
        vpandq_zmm_zmm_m512 = 2397,

        /// <summary>
        /// vpandq zmm, zmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpandq zmm, zmm, m64bcst","vpandq zmm, zmm, m64bcst |  | ")]
        vpandq_zmm_zmm_m64bcst = 2398,

        /// <summary>
        /// vpandq zmm, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpandq zmm, zmm, zmm","vpandq zmm, zmm, zmm |  | ")]
        vpandq_zmm_zmm_zmm = 2399,

        /// <summary>
        /// vpavgb xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpavgb xmm {k1}{z}, xmm, m128","vpavgb xmm {k1}{z}, xmm, m128 |  | ")]
        vpavgb_xmm_k1z_xmm_m128 = 2400,

        /// <summary>
        /// vpavgb xmm {k1}{z}, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpavgb xmm {k1}{z}, xmm, r8","vpavgb xmm {k1}{z}, xmm, r8 |  | ")]
        vpavgb_xmm_k1z_xmm_r8 = 2401,

        /// <summary>
        /// vpavgb xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpavgb xmm, xmm, m128","vpavgb xmm, xmm, m128 |  | ")]
        vpavgb_xmm_xmm_m128 = 2402,

        /// <summary>
        /// vpavgb xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpavgb xmm, xmm, r8","vpavgb xmm, xmm, r8 |  | ")]
        vpavgb_xmm_xmm_r8 = 2403,

        /// <summary>
        /// vpavgb ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpavgb ymm {k1}{z}, ymm, m256","vpavgb ymm {k1}{z}, ymm, m256 |  | ")]
        vpavgb_ymm_k1z_ymm_m256 = 2404,

        /// <summary>
        /// vpavgb ymm {k1}{z}, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpavgb ymm {k1}{z}, ymm, r16","vpavgb ymm {k1}{z}, ymm, r16 |  | ")]
        vpavgb_ymm_k1z_ymm_r16 = 2405,

        /// <summary>
        /// vpavgb ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpavgb ymm, ymm, m256","vpavgb ymm, ymm, m256 |  | ")]
        vpavgb_ymm_ymm_m256 = 2406,

        /// <summary>
        /// vpavgb ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpavgb ymm, ymm, r16","vpavgb ymm, ymm, r16 |  | ")]
        vpavgb_ymm_ymm_r16 = 2407,

        /// <summary>
        /// vpavgb zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpavgb zmm {k1}{z}, zmm, m512","vpavgb zmm {k1}{z}, zmm, m512 |  | ")]
        vpavgb_zmm_k1z_zmm_m512 = 2408,

        /// <summary>
        /// vpavgb zmm {k1}{z}, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpavgb zmm {k1}{z}, zmm, r32","vpavgb zmm {k1}{z}, zmm, r32 |  | ")]
        vpavgb_zmm_k1z_zmm_r32 = 2409,

        /// <summary>
        /// vpavgb zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpavgb zmm, zmm, m512","vpavgb zmm, zmm, m512 |  | ")]
        vpavgb_zmm_zmm_m512 = 2410,

        /// <summary>
        /// vpavgb zmm, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpavgb zmm, zmm, r32","vpavgb zmm, zmm, r32 |  | ")]
        vpavgb_zmm_zmm_r32 = 2411,

        /// <summary>
        /// vpavgw xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpavgw xmm {k1}{z}, xmm, m128","vpavgw xmm {k1}{z}, xmm, m128 |  | ")]
        vpavgw_xmm_k1z_xmm_m128 = 2412,

        /// <summary>
        /// vpavgw xmm {k1}{z}, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpavgw xmm {k1}{z}, xmm, r8","vpavgw xmm {k1}{z}, xmm, r8 |  | ")]
        vpavgw_xmm_k1z_xmm_r8 = 2413,

        /// <summary>
        /// vpavgw xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpavgw xmm, xmm, m128","vpavgw xmm, xmm, m128 |  | ")]
        vpavgw_xmm_xmm_m128 = 2414,

        /// <summary>
        /// vpavgw xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpavgw xmm, xmm, r8","vpavgw xmm, xmm, r8 |  | ")]
        vpavgw_xmm_xmm_r8 = 2415,

        /// <summary>
        /// vpavgw ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpavgw ymm {k1}{z}, ymm, m256","vpavgw ymm {k1}{z}, ymm, m256 |  | ")]
        vpavgw_ymm_k1z_ymm_m256 = 2416,

        /// <summary>
        /// vpavgw ymm {k1}{z}, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpavgw ymm {k1}{z}, ymm, r16","vpavgw ymm {k1}{z}, ymm, r16 |  | ")]
        vpavgw_ymm_k1z_ymm_r16 = 2417,

        /// <summary>
        /// vpavgw ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpavgw ymm, ymm, m256","vpavgw ymm, ymm, m256 |  | ")]
        vpavgw_ymm_ymm_m256 = 2418,

        /// <summary>
        /// vpavgw ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpavgw ymm, ymm, r16","vpavgw ymm, ymm, r16 |  | ")]
        vpavgw_ymm_ymm_r16 = 2419,

        /// <summary>
        /// vpavgw zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpavgw zmm {k1}{z}, zmm, m512","vpavgw zmm {k1}{z}, zmm, m512 |  | ")]
        vpavgw_zmm_k1z_zmm_m512 = 2420,

        /// <summary>
        /// vpavgw zmm {k1}{z}, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpavgw zmm {k1}{z}, zmm, r32","vpavgw zmm {k1}{z}, zmm, r32 |  | ")]
        vpavgw_zmm_k1z_zmm_r32 = 2421,

        /// <summary>
        /// vpavgw zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpavgw zmm, zmm, m512","vpavgw zmm, zmm, m512 |  | ")]
        vpavgw_zmm_zmm_m512 = 2422,

        /// <summary>
        /// vpavgw zmm, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpavgw zmm, zmm, r32","vpavgw zmm, zmm, r32 |  | ")]
        vpavgw_zmm_zmm_r32 = 2423,

        /// <summary>
        /// vpblendmb xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpblendmb xmm {k1}{z}, xmm, m128","vpblendmb xmm {k1}{z}, xmm, m128 |  | ")]
        vpblendmb_xmm_k1z_xmm_m128 = 2424,

        /// <summary>
        /// vpblendmb xmm {k1}{z}, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpblendmb xmm {k1}{z}, xmm, r8","vpblendmb xmm {k1}{z}, xmm, r8 |  | ")]
        vpblendmb_xmm_k1z_xmm_r8 = 2425,

        /// <summary>
        /// vpblendmb xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpblendmb xmm, xmm, m128","vpblendmb xmm, xmm, m128 |  | ")]
        vpblendmb_xmm_xmm_m128 = 2426,

        /// <summary>
        /// vpblendmb xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpblendmb xmm, xmm, r8","vpblendmb xmm, xmm, r8 |  | ")]
        vpblendmb_xmm_xmm_r8 = 2427,

        /// <summary>
        /// vpblendmb ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpblendmb ymm {k1}{z}, ymm, m256","vpblendmb ymm {k1}{z}, ymm, m256 |  | ")]
        vpblendmb_ymm_k1z_ymm_m256 = 2428,

        /// <summary>
        /// vpblendmb ymm {k1}{z}, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpblendmb ymm {k1}{z}, ymm, r16","vpblendmb ymm {k1}{z}, ymm, r16 |  | ")]
        vpblendmb_ymm_k1z_ymm_r16 = 2429,

        /// <summary>
        /// vpblendmb ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpblendmb ymm, ymm, m256","vpblendmb ymm, ymm, m256 |  | ")]
        vpblendmb_ymm_ymm_m256 = 2430,

        /// <summary>
        /// vpblendmb ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpblendmb ymm, ymm, r16","vpblendmb ymm, ymm, r16 |  | ")]
        vpblendmb_ymm_ymm_r16 = 2431,

        /// <summary>
        /// vpblendmb zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpblendmb zmm {k1}{z}, zmm, m512","vpblendmb zmm {k1}{z}, zmm, m512 |  | ")]
        vpblendmb_zmm_k1z_zmm_m512 = 2432,

        /// <summary>
        /// vpblendmb zmm {k1}{z}, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpblendmb zmm {k1}{z}, zmm, r32","vpblendmb zmm {k1}{z}, zmm, r32 |  | ")]
        vpblendmb_zmm_k1z_zmm_r32 = 2433,

        /// <summary>
        /// vpblendmb zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpblendmb zmm, zmm, m512","vpblendmb zmm, zmm, m512 |  | ")]
        vpblendmb_zmm_zmm_m512 = 2434,

        /// <summary>
        /// vpblendmb zmm, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpblendmb zmm, zmm, r32","vpblendmb zmm, zmm, r32 |  | ")]
        vpblendmb_zmm_zmm_r32 = 2435,

        /// <summary>
        /// vpblendmd xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpblendmd xmm {k1}{z}, xmm, m128","vpblendmd xmm {k1}{z}, xmm, m128 |  | ")]
        vpblendmd_xmm_k1z_xmm_m128 = 2436,

        /// <summary>
        /// vpblendmd xmm {k1}{z}, xmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpblendmd xmm {k1}{z}, xmm, m32bcst","vpblendmd xmm {k1}{z}, xmm, m32bcst |  | ")]
        vpblendmd_xmm_k1z_xmm_m32bcst = 2437,

        /// <summary>
        /// vpblendmd xmm {k1}{z}, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpblendmd xmm {k1}{z}, xmm, xmm","vpblendmd xmm {k1}{z}, xmm, xmm |  | ")]
        vpblendmd_xmm_k1z_xmm_xmm = 2438,

        /// <summary>
        /// vpblendmd xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpblendmd xmm, xmm, m128","vpblendmd xmm, xmm, m128 |  | ")]
        vpblendmd_xmm_xmm_m128 = 2439,

        /// <summary>
        /// vpblendmd xmm, xmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpblendmd xmm, xmm, m32bcst","vpblendmd xmm, xmm, m32bcst |  | ")]
        vpblendmd_xmm_xmm_m32bcst = 2440,

        /// <summary>
        /// vpblendmd xmm, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpblendmd xmm, xmm, xmm","vpblendmd xmm, xmm, xmm |  | ")]
        vpblendmd_xmm_xmm_xmm = 2441,

        /// <summary>
        /// vpblendmd ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpblendmd ymm {k1}{z}, ymm, m256","vpblendmd ymm {k1}{z}, ymm, m256 |  | ")]
        vpblendmd_ymm_k1z_ymm_m256 = 2442,

        /// <summary>
        /// vpblendmd ymm {k1}{z}, ymm, m32bcst |  | 
        /// </summary>
        [Symbol("vpblendmd ymm {k1}{z}, ymm, m32bcst","vpblendmd ymm {k1}{z}, ymm, m32bcst |  | ")]
        vpblendmd_ymm_k1z_ymm_m32bcst = 2443,

        /// <summary>
        /// vpblendmd ymm {k1}{z}, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpblendmd ymm {k1}{z}, ymm, ymm","vpblendmd ymm {k1}{z}, ymm, ymm |  | ")]
        vpblendmd_ymm_k1z_ymm_ymm = 2444,

        /// <summary>
        /// vpblendmd ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpblendmd ymm, ymm, m256","vpblendmd ymm, ymm, m256 |  | ")]
        vpblendmd_ymm_ymm_m256 = 2445,

        /// <summary>
        /// vpblendmd ymm, ymm, m32bcst |  | 
        /// </summary>
        [Symbol("vpblendmd ymm, ymm, m32bcst","vpblendmd ymm, ymm, m32bcst |  | ")]
        vpblendmd_ymm_ymm_m32bcst = 2446,

        /// <summary>
        /// vpblendmd ymm, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpblendmd ymm, ymm, ymm","vpblendmd ymm, ymm, ymm |  | ")]
        vpblendmd_ymm_ymm_ymm = 2447,

        /// <summary>
        /// vpblendmd zmm {k1}{z}, zmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpblendmd zmm {k1}{z}, zmm, m32bcst","vpblendmd zmm {k1}{z}, zmm, m32bcst |  | ")]
        vpblendmd_zmm_k1z_zmm_m32bcst = 2448,

        /// <summary>
        /// vpblendmd zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpblendmd zmm {k1}{z}, zmm, m512","vpblendmd zmm {k1}{z}, zmm, m512 |  | ")]
        vpblendmd_zmm_k1z_zmm_m512 = 2449,

        /// <summary>
        /// vpblendmd zmm {k1}{z}, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpblendmd zmm {k1}{z}, zmm, zmm","vpblendmd zmm {k1}{z}, zmm, zmm |  | ")]
        vpblendmd_zmm_k1z_zmm_zmm = 2450,

        /// <summary>
        /// vpblendmd zmm, zmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpblendmd zmm, zmm, m32bcst","vpblendmd zmm, zmm, m32bcst |  | ")]
        vpblendmd_zmm_zmm_m32bcst = 2451,

        /// <summary>
        /// vpblendmd zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpblendmd zmm, zmm, m512","vpblendmd zmm, zmm, m512 |  | ")]
        vpblendmd_zmm_zmm_m512 = 2452,

        /// <summary>
        /// vpblendmd zmm, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpblendmd zmm, zmm, zmm","vpblendmd zmm, zmm, zmm |  | ")]
        vpblendmd_zmm_zmm_zmm = 2453,

        /// <summary>
        /// vpblendmq xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpblendmq xmm {k1}{z}, xmm, m128","vpblendmq xmm {k1}{z}, xmm, m128 |  | ")]
        vpblendmq_xmm_k1z_xmm_m128 = 2454,

        /// <summary>
        /// vpblendmq xmm {k1}{z}, xmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpblendmq xmm {k1}{z}, xmm, m64bcst","vpblendmq xmm {k1}{z}, xmm, m64bcst |  | ")]
        vpblendmq_xmm_k1z_xmm_m64bcst = 2455,

        /// <summary>
        /// vpblendmq xmm {k1}{z}, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpblendmq xmm {k1}{z}, xmm, xmm","vpblendmq xmm {k1}{z}, xmm, xmm |  | ")]
        vpblendmq_xmm_k1z_xmm_xmm = 2456,

        /// <summary>
        /// vpblendmq xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpblendmq xmm, xmm, m128","vpblendmq xmm, xmm, m128 |  | ")]
        vpblendmq_xmm_xmm_m128 = 2457,

        /// <summary>
        /// vpblendmq xmm, xmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpblendmq xmm, xmm, m64bcst","vpblendmq xmm, xmm, m64bcst |  | ")]
        vpblendmq_xmm_xmm_m64bcst = 2458,

        /// <summary>
        /// vpblendmq xmm, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpblendmq xmm, xmm, xmm","vpblendmq xmm, xmm, xmm |  | ")]
        vpblendmq_xmm_xmm_xmm = 2459,

        /// <summary>
        /// vpblendmq ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpblendmq ymm {k1}{z}, ymm, m256","vpblendmq ymm {k1}{z}, ymm, m256 |  | ")]
        vpblendmq_ymm_k1z_ymm_m256 = 2460,

        /// <summary>
        /// vpblendmq ymm {k1}{z}, ymm, m64bcst |  | 
        /// </summary>
        [Symbol("vpblendmq ymm {k1}{z}, ymm, m64bcst","vpblendmq ymm {k1}{z}, ymm, m64bcst |  | ")]
        vpblendmq_ymm_k1z_ymm_m64bcst = 2461,

        /// <summary>
        /// vpblendmq ymm {k1}{z}, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpblendmq ymm {k1}{z}, ymm, ymm","vpblendmq ymm {k1}{z}, ymm, ymm |  | ")]
        vpblendmq_ymm_k1z_ymm_ymm = 2462,

        /// <summary>
        /// vpblendmq ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpblendmq ymm, ymm, m256","vpblendmq ymm, ymm, m256 |  | ")]
        vpblendmq_ymm_ymm_m256 = 2463,

        /// <summary>
        /// vpblendmq ymm, ymm, m64bcst |  | 
        /// </summary>
        [Symbol("vpblendmq ymm, ymm, m64bcst","vpblendmq ymm, ymm, m64bcst |  | ")]
        vpblendmq_ymm_ymm_m64bcst = 2464,

        /// <summary>
        /// vpblendmq ymm, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpblendmq ymm, ymm, ymm","vpblendmq ymm, ymm, ymm |  | ")]
        vpblendmq_ymm_ymm_ymm = 2465,

        /// <summary>
        /// vpblendmq zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpblendmq zmm {k1}{z}, zmm, m512","vpblendmq zmm {k1}{z}, zmm, m512 |  | ")]
        vpblendmq_zmm_k1z_zmm_m512 = 2466,

        /// <summary>
        /// vpblendmq zmm {k1}{z}, zmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpblendmq zmm {k1}{z}, zmm, m64bcst","vpblendmq zmm {k1}{z}, zmm, m64bcst |  | ")]
        vpblendmq_zmm_k1z_zmm_m64bcst = 2467,

        /// <summary>
        /// vpblendmq zmm {k1}{z}, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpblendmq zmm {k1}{z}, zmm, zmm","vpblendmq zmm {k1}{z}, zmm, zmm |  | ")]
        vpblendmq_zmm_k1z_zmm_zmm = 2468,

        /// <summary>
        /// vpblendmq zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpblendmq zmm, zmm, m512","vpblendmq zmm, zmm, m512 |  | ")]
        vpblendmq_zmm_zmm_m512 = 2469,

        /// <summary>
        /// vpblendmq zmm, zmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpblendmq zmm, zmm, m64bcst","vpblendmq zmm, zmm, m64bcst |  | ")]
        vpblendmq_zmm_zmm_m64bcst = 2470,

        /// <summary>
        /// vpblendmq zmm, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpblendmq zmm, zmm, zmm","vpblendmq zmm, zmm, zmm |  | ")]
        vpblendmq_zmm_zmm_zmm = 2471,

        /// <summary>
        /// vpblendmw xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpblendmw xmm {k1}{z}, xmm, m128","vpblendmw xmm {k1}{z}, xmm, m128 |  | ")]
        vpblendmw_xmm_k1z_xmm_m128 = 2472,

        /// <summary>
        /// vpblendmw xmm {k1}{z}, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpblendmw xmm {k1}{z}, xmm, r8","vpblendmw xmm {k1}{z}, xmm, r8 |  | ")]
        vpblendmw_xmm_k1z_xmm_r8 = 2473,

        /// <summary>
        /// vpblendmw xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpblendmw xmm, xmm, m128","vpblendmw xmm, xmm, m128 |  | ")]
        vpblendmw_xmm_xmm_m128 = 2474,

        /// <summary>
        /// vpblendmw xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpblendmw xmm, xmm, r8","vpblendmw xmm, xmm, r8 |  | ")]
        vpblendmw_xmm_xmm_r8 = 2475,

        /// <summary>
        /// vpblendmw ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpblendmw ymm {k1}{z}, ymm, m256","vpblendmw ymm {k1}{z}, ymm, m256 |  | ")]
        vpblendmw_ymm_k1z_ymm_m256 = 2476,

        /// <summary>
        /// vpblendmw ymm {k1}{z}, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpblendmw ymm {k1}{z}, ymm, r16","vpblendmw ymm {k1}{z}, ymm, r16 |  | ")]
        vpblendmw_ymm_k1z_ymm_r16 = 2477,

        /// <summary>
        /// vpblendmw ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpblendmw ymm, ymm, m256","vpblendmw ymm, ymm, m256 |  | ")]
        vpblendmw_ymm_ymm_m256 = 2478,

        /// <summary>
        /// vpblendmw ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpblendmw ymm, ymm, r16","vpblendmw ymm, ymm, r16 |  | ")]
        vpblendmw_ymm_ymm_r16 = 2479,

        /// <summary>
        /// vpblendmw zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpblendmw zmm {k1}{z}, zmm, m512","vpblendmw zmm {k1}{z}, zmm, m512 |  | ")]
        vpblendmw_zmm_k1z_zmm_m512 = 2480,

        /// <summary>
        /// vpblendmw zmm {k1}{z}, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpblendmw zmm {k1}{z}, zmm, r32","vpblendmw zmm {k1}{z}, zmm, r32 |  | ")]
        vpblendmw_zmm_k1z_zmm_r32 = 2481,

        /// <summary>
        /// vpblendmw zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpblendmw zmm, zmm, m512","vpblendmw zmm, zmm, m512 |  | ")]
        vpblendmw_zmm_zmm_m512 = 2482,

        /// <summary>
        /// vpblendmw zmm, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpblendmw zmm, zmm, r32","vpblendmw zmm, zmm, r32 |  | ")]
        vpblendmw_zmm_zmm_r32 = 2483,

        /// <summary>
        /// vpbroadcastb xmm {k1}{z}, m8 |  | 
        /// </summary>
        [Symbol("vpbroadcastb xmm {k1}{z}, m8","vpbroadcastb xmm {k1}{z}, m8 |  | ")]
        vpbroadcastb_xmm_k1z_m8 = 2484,

        /// <summary>
        /// vpbroadcastb xmm {k1}{z}, r8 |  | 
        /// </summary>
        [Symbol("vpbroadcastb xmm {k1}{z}, r8","vpbroadcastb xmm {k1}{z}, r8 |  | ")]
        vpbroadcastb_xmm_k1z_r8 = 2485,

        /// <summary>
        /// vpbroadcastb xmm, m8 |  | 
        /// </summary>
        [Symbol("vpbroadcastb xmm, m8","vpbroadcastb xmm, m8 |  | ")]
        vpbroadcastb_xmm_m8 = 2486,

        /// <summary>
        /// vpbroadcastb xmm, r8 |  | 
        /// </summary>
        [Symbol("vpbroadcastb xmm, r8","vpbroadcastb xmm, r8 |  | ")]
        vpbroadcastb_xmm_r8 = 2487,

        /// <summary>
        /// vpbroadcastb ymm {k1}{z}, m8 |  | 
        /// </summary>
        [Symbol("vpbroadcastb ymm {k1}{z}, m8","vpbroadcastb ymm {k1}{z}, m8 |  | ")]
        vpbroadcastb_ymm_k1z_m8 = 2488,

        /// <summary>
        /// vpbroadcastb ymm {k1}{z}, r8 |  | 
        /// </summary>
        [Symbol("vpbroadcastb ymm {k1}{z}, r8","vpbroadcastb ymm {k1}{z}, r8 |  | ")]
        vpbroadcastb_ymm_k1z_r8 = 2489,

        /// <summary>
        /// vpbroadcastb ymm, m8 |  | 
        /// </summary>
        [Symbol("vpbroadcastb ymm, m8","vpbroadcastb ymm, m8 |  | ")]
        vpbroadcastb_ymm_m8 = 2490,

        /// <summary>
        /// vpbroadcastb ymm, r8 |  | 
        /// </summary>
        [Symbol("vpbroadcastb ymm, r8","vpbroadcastb ymm, r8 |  | ")]
        vpbroadcastb_ymm_r8 = 2491,

        /// <summary>
        /// vpbroadcastb zmm {k1}{z}, m8 |  | 
        /// </summary>
        [Symbol("vpbroadcastb zmm {k1}{z}, m8","vpbroadcastb zmm {k1}{z}, m8 |  | ")]
        vpbroadcastb_zmm_k1z_m8 = 2492,

        /// <summary>
        /// vpbroadcastb zmm {k1}{z}, r8 |  | 
        /// </summary>
        [Symbol("vpbroadcastb zmm {k1}{z}, r8","vpbroadcastb zmm {k1}{z}, r8 |  | ")]
        vpbroadcastb_zmm_k1z_r8 = 2493,

        /// <summary>
        /// vpbroadcastb zmm, m8 |  | 
        /// </summary>
        [Symbol("vpbroadcastb zmm, m8","vpbroadcastb zmm, m8 |  | ")]
        vpbroadcastb_zmm_m8 = 2494,

        /// <summary>
        /// vpbroadcastb zmm, r8 |  | 
        /// </summary>
        [Symbol("vpbroadcastb zmm, r8","vpbroadcastb zmm, r8 |  | ")]
        vpbroadcastb_zmm_r8 = 2495,

        /// <summary>
        /// vpbroadcastd xmm {k1}{z}, m32 |  | 
        /// </summary>
        [Symbol("vpbroadcastd xmm {k1}{z}, m32","vpbroadcastd xmm {k1}{z}, m32 |  | ")]
        vpbroadcastd_xmm_k1z_m32 = 2496,

        /// <summary>
        /// vpbroadcastd xmm {k1}{z}, r8 |  | 
        /// </summary>
        [Symbol("vpbroadcastd xmm {k1}{z}, r8","vpbroadcastd xmm {k1}{z}, r8 |  | ")]
        vpbroadcastd_xmm_k1z_r8 = 2497,

        /// <summary>
        /// vpbroadcastd xmm, m32 |  | 
        /// </summary>
        [Symbol("vpbroadcastd xmm, m32","vpbroadcastd xmm, m32 |  | ")]
        vpbroadcastd_xmm_m32 = 2498,

        /// <summary>
        /// vpbroadcastd xmm, r8 |  | 
        /// </summary>
        [Symbol("vpbroadcastd xmm, r8","vpbroadcastd xmm, r8 |  | ")]
        vpbroadcastd_xmm_r8 = 2499,

        /// <summary>
        /// vpbroadcastd ymm {k1}{z}, m32 |  | 
        /// </summary>
        [Symbol("vpbroadcastd ymm {k1}{z}, m32","vpbroadcastd ymm {k1}{z}, m32 |  | ")]
        vpbroadcastd_ymm_k1z_m32 = 2500,

        /// <summary>
        /// vpbroadcastd ymm {k1}{z}, r8 |  | 
        /// </summary>
        [Symbol("vpbroadcastd ymm {k1}{z}, r8","vpbroadcastd ymm {k1}{z}, r8 |  | ")]
        vpbroadcastd_ymm_k1z_r8 = 2501,

        /// <summary>
        /// vpbroadcastd ymm, m32 |  | 
        /// </summary>
        [Symbol("vpbroadcastd ymm, m32","vpbroadcastd ymm, m32 |  | ")]
        vpbroadcastd_ymm_m32 = 2502,

        /// <summary>
        /// vpbroadcastd ymm, r8 |  | 
        /// </summary>
        [Symbol("vpbroadcastd ymm, r8","vpbroadcastd ymm, r8 |  | ")]
        vpbroadcastd_ymm_r8 = 2503,

        /// <summary>
        /// vpbroadcastd zmm {k1}{z}, m32 |  | 
        /// </summary>
        [Symbol("vpbroadcastd zmm {k1}{z}, m32","vpbroadcastd zmm {k1}{z}, m32 |  | ")]
        vpbroadcastd_zmm_k1z_m32 = 2504,

        /// <summary>
        /// vpbroadcastd zmm {k1}{z}, r8 |  | 
        /// </summary>
        [Symbol("vpbroadcastd zmm {k1}{z}, r8","vpbroadcastd zmm {k1}{z}, r8 |  | ")]
        vpbroadcastd_zmm_k1z_r8 = 2505,

        /// <summary>
        /// vpbroadcastd zmm, m32 |  | 
        /// </summary>
        [Symbol("vpbroadcastd zmm, m32","vpbroadcastd zmm, m32 |  | ")]
        vpbroadcastd_zmm_m32 = 2506,

        /// <summary>
        /// vpbroadcastd zmm, r8 |  | 
        /// </summary>
        [Symbol("vpbroadcastd zmm, r8","vpbroadcastd zmm, r8 |  | ")]
        vpbroadcastd_zmm_r8 = 2507,

        /// <summary>
        /// vpbroadcastmb2q xmm, k |  | 
        /// </summary>
        [Symbol("vpbroadcastmb2q xmm, k","vpbroadcastmb2q xmm, k |  | ")]
        vpbroadcastmb2q_xmm_k = 2508,

        /// <summary>
        /// vpbroadcastmb2q ymm, k |  | 
        /// </summary>
        [Symbol("vpbroadcastmb2q ymm, k","vpbroadcastmb2q ymm, k |  | ")]
        vpbroadcastmb2q_ymm_k = 2509,

        /// <summary>
        /// vpbroadcastmb2q zmm, k |  | 
        /// </summary>
        [Symbol("vpbroadcastmb2q zmm, k","vpbroadcastmb2q zmm, k |  | ")]
        vpbroadcastmb2q_zmm_k = 2510,

        /// <summary>
        /// vpbroadcastmw2d xmm, k |  | 
        /// </summary>
        [Symbol("vpbroadcastmw2d xmm, k","vpbroadcastmw2d xmm, k |  | ")]
        vpbroadcastmw2d_xmm_k = 2511,

        /// <summary>
        /// vpbroadcastmw2d ymm, k |  | 
        /// </summary>
        [Symbol("vpbroadcastmw2d ymm, k","vpbroadcastmw2d ymm, k |  | ")]
        vpbroadcastmw2d_ymm_k = 2512,

        /// <summary>
        /// vpbroadcastmw2d zmm, k |  | 
        /// </summary>
        [Symbol("vpbroadcastmw2d zmm, k","vpbroadcastmw2d zmm, k |  | ")]
        vpbroadcastmw2d_zmm_k = 2513,

        /// <summary>
        /// vpbroadcastq xmm {k1}{z}, m64 |  | 
        /// </summary>
        [Symbol("vpbroadcastq xmm {k1}{z}, m64","vpbroadcastq xmm {k1}{z}, m64 |  | ")]
        vpbroadcastq_xmm_k1z_m64 = 2514,

        /// <summary>
        /// vpbroadcastq xmm {k1}{z}, r8 |  | 
        /// </summary>
        [Symbol("vpbroadcastq xmm {k1}{z}, r8","vpbroadcastq xmm {k1}{z}, r8 |  | ")]
        vpbroadcastq_xmm_k1z_r8 = 2515,

        /// <summary>
        /// vpbroadcastq xmm, m64 |  | 
        /// </summary>
        [Symbol("vpbroadcastq xmm, m64","vpbroadcastq xmm, m64 |  | ")]
        vpbroadcastq_xmm_m64 = 2516,

        /// <summary>
        /// vpbroadcastq xmm, r8 |  | 
        /// </summary>
        [Symbol("vpbroadcastq xmm, r8","vpbroadcastq xmm, r8 |  | ")]
        vpbroadcastq_xmm_r8 = 2517,

        /// <summary>
        /// vpbroadcastq ymm {k1}{z}, m64 |  | 
        /// </summary>
        [Symbol("vpbroadcastq ymm {k1}{z}, m64","vpbroadcastq ymm {k1}{z}, m64 |  | ")]
        vpbroadcastq_ymm_k1z_m64 = 2518,

        /// <summary>
        /// vpbroadcastq ymm {k1}{z}, r8 |  | 
        /// </summary>
        [Symbol("vpbroadcastq ymm {k1}{z}, r8","vpbroadcastq ymm {k1}{z}, r8 |  | ")]
        vpbroadcastq_ymm_k1z_r8 = 2519,

        /// <summary>
        /// vpbroadcastq ymm, m64 |  | 
        /// </summary>
        [Symbol("vpbroadcastq ymm, m64","vpbroadcastq ymm, m64 |  | ")]
        vpbroadcastq_ymm_m64 = 2520,

        /// <summary>
        /// vpbroadcastq ymm, r8 |  | 
        /// </summary>
        [Symbol("vpbroadcastq ymm, r8","vpbroadcastq ymm, r8 |  | ")]
        vpbroadcastq_ymm_r8 = 2521,

        /// <summary>
        /// vpbroadcastq zmm {k1}{z}, m64 |  | 
        /// </summary>
        [Symbol("vpbroadcastq zmm {k1}{z}, m64","vpbroadcastq zmm {k1}{z}, m64 |  | ")]
        vpbroadcastq_zmm_k1z_m64 = 2522,

        /// <summary>
        /// vpbroadcastq zmm {k1}{z}, r8 |  | 
        /// </summary>
        [Symbol("vpbroadcastq zmm {k1}{z}, r8","vpbroadcastq zmm {k1}{z}, r8 |  | ")]
        vpbroadcastq_zmm_k1z_r8 = 2523,

        /// <summary>
        /// vpbroadcastq zmm, m64 |  | 
        /// </summary>
        [Symbol("vpbroadcastq zmm, m64","vpbroadcastq zmm, m64 |  | ")]
        vpbroadcastq_zmm_m64 = 2524,

        /// <summary>
        /// vpbroadcastq zmm, r8 |  | 
        /// </summary>
        [Symbol("vpbroadcastq zmm, r8","vpbroadcastq zmm, r8 |  | ")]
        vpbroadcastq_zmm_r8 = 2525,

        /// <summary>
        /// vpbroadcastw xmm {k1}{z}, m16 |  | 
        /// </summary>
        [Symbol("vpbroadcastw xmm {k1}{z}, m16","vpbroadcastw xmm {k1}{z}, m16 |  | ")]
        vpbroadcastw_xmm_k1z_m16 = 2526,

        /// <summary>
        /// vpbroadcastw xmm {k1}{z}, r8 |  | 
        /// </summary>
        [Symbol("vpbroadcastw xmm {k1}{z}, r8","vpbroadcastw xmm {k1}{z}, r8 |  | ")]
        vpbroadcastw_xmm_k1z_r8 = 2527,

        /// <summary>
        /// vpbroadcastw xmm, m16 |  | 
        /// </summary>
        [Symbol("vpbroadcastw xmm, m16","vpbroadcastw xmm, m16 |  | ")]
        vpbroadcastw_xmm_m16 = 2528,

        /// <summary>
        /// vpbroadcastw xmm, r8 |  | 
        /// </summary>
        [Symbol("vpbroadcastw xmm, r8","vpbroadcastw xmm, r8 |  | ")]
        vpbroadcastw_xmm_r8 = 2529,

        /// <summary>
        /// vpbroadcastw ymm {k1}{z}, m16 |  | 
        /// </summary>
        [Symbol("vpbroadcastw ymm {k1}{z}, m16","vpbroadcastw ymm {k1}{z}, m16 |  | ")]
        vpbroadcastw_ymm_k1z_m16 = 2530,

        /// <summary>
        /// vpbroadcastw ymm {k1}{z}, r8 |  | 
        /// </summary>
        [Symbol("vpbroadcastw ymm {k1}{z}, r8","vpbroadcastw ymm {k1}{z}, r8 |  | ")]
        vpbroadcastw_ymm_k1z_r8 = 2531,

        /// <summary>
        /// vpbroadcastw ymm, m16 |  | 
        /// </summary>
        [Symbol("vpbroadcastw ymm, m16","vpbroadcastw ymm, m16 |  | ")]
        vpbroadcastw_ymm_m16 = 2532,

        /// <summary>
        /// vpbroadcastw ymm, r8 |  | 
        /// </summary>
        [Symbol("vpbroadcastw ymm, r8","vpbroadcastw ymm, r8 |  | ")]
        vpbroadcastw_ymm_r8 = 2533,

        /// <summary>
        /// vpbroadcastw zmm {k1}{z}, m16 |  | 
        /// </summary>
        [Symbol("vpbroadcastw zmm {k1}{z}, m16","vpbroadcastw zmm {k1}{z}, m16 |  | ")]
        vpbroadcastw_zmm_k1z_m16 = 2534,

        /// <summary>
        /// vpbroadcastw zmm {k1}{z}, r8 |  | 
        /// </summary>
        [Symbol("vpbroadcastw zmm {k1}{z}, r8","vpbroadcastw zmm {k1}{z}, r8 |  | ")]
        vpbroadcastw_zmm_k1z_r8 = 2535,

        /// <summary>
        /// vpbroadcastw zmm, m16 |  | 
        /// </summary>
        [Symbol("vpbroadcastw zmm, m16","vpbroadcastw zmm, m16 |  | ")]
        vpbroadcastw_zmm_m16 = 2536,

        /// <summary>
        /// vpbroadcastw zmm, r8 |  | 
        /// </summary>
        [Symbol("vpbroadcastw zmm, r8","vpbroadcastw zmm, r8 |  | ")]
        vpbroadcastw_zmm_r8 = 2537,

        /// <summary>
        /// vpcmpb k1 {k2}, xmm, m128, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpb k1 {k2}, xmm, m128, imm8","vpcmpb k1 {k2}, xmm, m128, imm8 |  | ")]
        vpcmpb_k1_k2_xmm_m128_imm8 = 2538,

        /// <summary>
        /// vpcmpb k1 {k2}, xmm, r8, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpb k1 {k2}, xmm, r8, imm8","vpcmpb k1 {k2}, xmm, r8, imm8 |  | ")]
        vpcmpb_k1_k2_xmm_r8_imm8 = 2539,

        /// <summary>
        /// vpcmpb k1 {k2}, ymm, m256, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpb k1 {k2}, ymm, m256, imm8","vpcmpb k1 {k2}, ymm, m256, imm8 |  | ")]
        vpcmpb_k1_k2_ymm_m256_imm8 = 2540,

        /// <summary>
        /// vpcmpb k1 {k2}, ymm, r16, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpb k1 {k2}, ymm, r16, imm8","vpcmpb k1 {k2}, ymm, r16, imm8 |  | ")]
        vpcmpb_k1_k2_ymm_r16_imm8 = 2541,

        /// <summary>
        /// vpcmpb k1 {k2}, zmm, m512, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpb k1 {k2}, zmm, m512, imm8","vpcmpb k1 {k2}, zmm, m512, imm8 |  | ")]
        vpcmpb_k1_k2_zmm_m512_imm8 = 2542,

        /// <summary>
        /// vpcmpb k1 {k2}, zmm, r32, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpb k1 {k2}, zmm, r32, imm8","vpcmpb k1 {k2}, zmm, r32, imm8 |  | ")]
        vpcmpb_k1_k2_zmm_r32_imm8 = 2543,

        /// <summary>
        /// vpcmpb k1, xmm, m128, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpb k1, xmm, m128, imm8","vpcmpb k1, xmm, m128, imm8 |  | ")]
        vpcmpb_k1_xmm_m128_imm8 = 2544,

        /// <summary>
        /// vpcmpb k1, xmm, r8, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpb k1, xmm, r8, imm8","vpcmpb k1, xmm, r8, imm8 |  | ")]
        vpcmpb_k1_xmm_r8_imm8 = 2545,

        /// <summary>
        /// vpcmpb k1, ymm, m256, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpb k1, ymm, m256, imm8","vpcmpb k1, ymm, m256, imm8 |  | ")]
        vpcmpb_k1_ymm_m256_imm8 = 2546,

        /// <summary>
        /// vpcmpb k1, ymm, r16, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpb k1, ymm, r16, imm8","vpcmpb k1, ymm, r16, imm8 |  | ")]
        vpcmpb_k1_ymm_r16_imm8 = 2547,

        /// <summary>
        /// vpcmpb k1, zmm, m512, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpb k1, zmm, m512, imm8","vpcmpb k1, zmm, m512, imm8 |  | ")]
        vpcmpb_k1_zmm_m512_imm8 = 2548,

        /// <summary>
        /// vpcmpb k1, zmm, r32, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpb k1, zmm, r32, imm8","vpcmpb k1, zmm, r32, imm8 |  | ")]
        vpcmpb_k1_zmm_r32_imm8 = 2549,

        /// <summary>
        /// vpcmpd k1 {k2}, xmm, m128, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpd k1 {k2}, xmm, m128, imm8","vpcmpd k1 {k2}, xmm, m128, imm8 |  | ")]
        vpcmpd_k1_k2_xmm_m128_imm8 = 2550,

        /// <summary>
        /// vpcmpd k1 {k2}, xmm, m32bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpd k1 {k2}, xmm, m32bcst, imm8","vpcmpd k1 {k2}, xmm, m32bcst, imm8 |  | ")]
        vpcmpd_k1_k2_xmm_m32bcst_imm8 = 2551,

        /// <summary>
        /// vpcmpd k1 {k2}, xmm, xmm, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpd k1 {k2}, xmm, xmm, imm8","vpcmpd k1 {k2}, xmm, xmm, imm8 |  | ")]
        vpcmpd_k1_k2_xmm_xmm_imm8 = 2552,

        /// <summary>
        /// vpcmpd k1 {k2}, ymm, m256, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpd k1 {k2}, ymm, m256, imm8","vpcmpd k1 {k2}, ymm, m256, imm8 |  | ")]
        vpcmpd_k1_k2_ymm_m256_imm8 = 2553,

        /// <summary>
        /// vpcmpd k1 {k2}, ymm, m32bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpd k1 {k2}, ymm, m32bcst, imm8","vpcmpd k1 {k2}, ymm, m32bcst, imm8 |  | ")]
        vpcmpd_k1_k2_ymm_m32bcst_imm8 = 2554,

        /// <summary>
        /// vpcmpd k1 {k2}, ymm, ymm, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpd k1 {k2}, ymm, ymm, imm8","vpcmpd k1 {k2}, ymm, ymm, imm8 |  | ")]
        vpcmpd_k1_k2_ymm_ymm_imm8 = 2555,

        /// <summary>
        /// vpcmpd k1 {k2}, zmm, m32bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpd k1 {k2}, zmm, m32bcst, imm8","vpcmpd k1 {k2}, zmm, m32bcst, imm8 |  | ")]
        vpcmpd_k1_k2_zmm_m32bcst_imm8 = 2556,

        /// <summary>
        /// vpcmpd k1 {k2}, zmm, m512, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpd k1 {k2}, zmm, m512, imm8","vpcmpd k1 {k2}, zmm, m512, imm8 |  | ")]
        vpcmpd_k1_k2_zmm_m512_imm8 = 2557,

        /// <summary>
        /// vpcmpd k1 {k2}, zmm, zmm, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpd k1 {k2}, zmm, zmm, imm8","vpcmpd k1 {k2}, zmm, zmm, imm8 |  | ")]
        vpcmpd_k1_k2_zmm_zmm_imm8 = 2558,

        /// <summary>
        /// vpcmpd k1, xmm, m128, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpd k1, xmm, m128, imm8","vpcmpd k1, xmm, m128, imm8 |  | ")]
        vpcmpd_k1_xmm_m128_imm8 = 2559,

        /// <summary>
        /// vpcmpd k1, xmm, m32bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpd k1, xmm, m32bcst, imm8","vpcmpd k1, xmm, m32bcst, imm8 |  | ")]
        vpcmpd_k1_xmm_m32bcst_imm8 = 2560,

        /// <summary>
        /// vpcmpd k1, xmm, xmm, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpd k1, xmm, xmm, imm8","vpcmpd k1, xmm, xmm, imm8 |  | ")]
        vpcmpd_k1_xmm_xmm_imm8 = 2561,

        /// <summary>
        /// vpcmpd k1, ymm, m256, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpd k1, ymm, m256, imm8","vpcmpd k1, ymm, m256, imm8 |  | ")]
        vpcmpd_k1_ymm_m256_imm8 = 2562,

        /// <summary>
        /// vpcmpd k1, ymm, m32bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpd k1, ymm, m32bcst, imm8","vpcmpd k1, ymm, m32bcst, imm8 |  | ")]
        vpcmpd_k1_ymm_m32bcst_imm8 = 2563,

        /// <summary>
        /// vpcmpd k1, ymm, ymm, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpd k1, ymm, ymm, imm8","vpcmpd k1, ymm, ymm, imm8 |  | ")]
        vpcmpd_k1_ymm_ymm_imm8 = 2564,

        /// <summary>
        /// vpcmpd k1, zmm, m32bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpd k1, zmm, m32bcst, imm8","vpcmpd k1, zmm, m32bcst, imm8 |  | ")]
        vpcmpd_k1_zmm_m32bcst_imm8 = 2565,

        /// <summary>
        /// vpcmpd k1, zmm, m512, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpd k1, zmm, m512, imm8","vpcmpd k1, zmm, m512, imm8 |  | ")]
        vpcmpd_k1_zmm_m512_imm8 = 2566,

        /// <summary>
        /// vpcmpd k1, zmm, zmm, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpd k1, zmm, zmm, imm8","vpcmpd k1, zmm, zmm, imm8 |  | ")]
        vpcmpd_k1_zmm_zmm_imm8 = 2567,

        /// <summary>
        /// vpcmpeqb k1 {k2}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpcmpeqb k1 {k2}, xmm, m128","vpcmpeqb k1 {k2}, xmm, m128 |  | ")]
        vpcmpeqb_k1_k2_xmm_m128 = 2568,

        /// <summary>
        /// vpcmpeqb k1 {k2}, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpcmpeqb k1 {k2}, xmm, r8","vpcmpeqb k1 {k2}, xmm, r8 |  | ")]
        vpcmpeqb_k1_k2_xmm_r8 = 2569,

        /// <summary>
        /// vpcmpeqb k1 {k2}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpcmpeqb k1 {k2}, ymm, m256","vpcmpeqb k1 {k2}, ymm, m256 |  | ")]
        vpcmpeqb_k1_k2_ymm_m256 = 2570,

        /// <summary>
        /// vpcmpeqb k1 {k2}, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpcmpeqb k1 {k2}, ymm, r16","vpcmpeqb k1 {k2}, ymm, r16 |  | ")]
        vpcmpeqb_k1_k2_ymm_r16 = 2571,

        /// <summary>
        /// vpcmpeqb k1 {k2}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpcmpeqb k1 {k2}, zmm, m512","vpcmpeqb k1 {k2}, zmm, m512 |  | ")]
        vpcmpeqb_k1_k2_zmm_m512 = 2572,

        /// <summary>
        /// vpcmpeqb k1 {k2}, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpcmpeqb k1 {k2}, zmm, r32","vpcmpeqb k1 {k2}, zmm, r32 |  | ")]
        vpcmpeqb_k1_k2_zmm_r32 = 2573,

        /// <summary>
        /// vpcmpeqb k1, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpcmpeqb k1, xmm, m128","vpcmpeqb k1, xmm, m128 |  | ")]
        vpcmpeqb_k1_xmm_m128 = 2574,

        /// <summary>
        /// vpcmpeqb k1, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpcmpeqb k1, xmm, r8","vpcmpeqb k1, xmm, r8 |  | ")]
        vpcmpeqb_k1_xmm_r8 = 2575,

        /// <summary>
        /// vpcmpeqb k1, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpcmpeqb k1, ymm, m256","vpcmpeqb k1, ymm, m256 |  | ")]
        vpcmpeqb_k1_ymm_m256 = 2576,

        /// <summary>
        /// vpcmpeqb k1, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpcmpeqb k1, ymm, r16","vpcmpeqb k1, ymm, r16 |  | ")]
        vpcmpeqb_k1_ymm_r16 = 2577,

        /// <summary>
        /// vpcmpeqb k1, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpcmpeqb k1, zmm, m512","vpcmpeqb k1, zmm, m512 |  | ")]
        vpcmpeqb_k1_zmm_m512 = 2578,

        /// <summary>
        /// vpcmpeqb k1, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpcmpeqb k1, zmm, r32","vpcmpeqb k1, zmm, r32 |  | ")]
        vpcmpeqb_k1_zmm_r32 = 2579,

        /// <summary>
        /// vpcmpeqb xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpcmpeqb xmm, xmm, m128","vpcmpeqb xmm, xmm, m128 |  | ")]
        vpcmpeqb_xmm_xmm_m128 = 2580,

        /// <summary>
        /// vpcmpeqb xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpcmpeqb xmm, xmm, r8","vpcmpeqb xmm, xmm, r8 |  | ")]
        vpcmpeqb_xmm_xmm_r8 = 2581,

        /// <summary>
        /// vpcmpeqb ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpcmpeqb ymm, ymm, m256","vpcmpeqb ymm, ymm, m256 |  | ")]
        vpcmpeqb_ymm_ymm_m256 = 2582,

        /// <summary>
        /// vpcmpeqb ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpcmpeqb ymm, ymm, r16","vpcmpeqb ymm, ymm, r16 |  | ")]
        vpcmpeqb_ymm_ymm_r16 = 2583,

        /// <summary>
        /// vpcmpeqd k1 {k2}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpcmpeqd k1 {k2}, xmm, m128","vpcmpeqd k1 {k2}, xmm, m128 |  | ")]
        vpcmpeqd_k1_k2_xmm_m128 = 2584,

        /// <summary>
        /// vpcmpeqd k1 {k2}, xmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpcmpeqd k1 {k2}, xmm, m32bcst","vpcmpeqd k1 {k2}, xmm, m32bcst |  | ")]
        vpcmpeqd_k1_k2_xmm_m32bcst = 2585,

        /// <summary>
        /// vpcmpeqd k1 {k2}, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpcmpeqd k1 {k2}, xmm, xmm","vpcmpeqd k1 {k2}, xmm, xmm |  | ")]
        vpcmpeqd_k1_k2_xmm_xmm = 2586,

        /// <summary>
        /// vpcmpeqd k1 {k2}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpcmpeqd k1 {k2}, ymm, m256","vpcmpeqd k1 {k2}, ymm, m256 |  | ")]
        vpcmpeqd_k1_k2_ymm_m256 = 2587,

        /// <summary>
        /// vpcmpeqd k1 {k2}, ymm, m32bcst |  | 
        /// </summary>
        [Symbol("vpcmpeqd k1 {k2}, ymm, m32bcst","vpcmpeqd k1 {k2}, ymm, m32bcst |  | ")]
        vpcmpeqd_k1_k2_ymm_m32bcst = 2588,

        /// <summary>
        /// vpcmpeqd k1 {k2}, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpcmpeqd k1 {k2}, ymm, ymm","vpcmpeqd k1 {k2}, ymm, ymm |  | ")]
        vpcmpeqd_k1_k2_ymm_ymm = 2589,

        /// <summary>
        /// vpcmpeqd k1 {k2}, zmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpcmpeqd k1 {k2}, zmm, m32bcst","vpcmpeqd k1 {k2}, zmm, m32bcst |  | ")]
        vpcmpeqd_k1_k2_zmm_m32bcst = 2590,

        /// <summary>
        /// vpcmpeqd k1 {k2}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpcmpeqd k1 {k2}, zmm, m512","vpcmpeqd k1 {k2}, zmm, m512 |  | ")]
        vpcmpeqd_k1_k2_zmm_m512 = 2591,

        /// <summary>
        /// vpcmpeqd k1 {k2}, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpcmpeqd k1 {k2}, zmm, zmm","vpcmpeqd k1 {k2}, zmm, zmm |  | ")]
        vpcmpeqd_k1_k2_zmm_zmm = 2592,

        /// <summary>
        /// vpcmpeqd k1, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpcmpeqd k1, xmm, m128","vpcmpeqd k1, xmm, m128 |  | ")]
        vpcmpeqd_k1_xmm_m128 = 2593,

        /// <summary>
        /// vpcmpeqd k1, xmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpcmpeqd k1, xmm, m32bcst","vpcmpeqd k1, xmm, m32bcst |  | ")]
        vpcmpeqd_k1_xmm_m32bcst = 2594,

        /// <summary>
        /// vpcmpeqd k1, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpcmpeqd k1, xmm, xmm","vpcmpeqd k1, xmm, xmm |  | ")]
        vpcmpeqd_k1_xmm_xmm = 2595,

        /// <summary>
        /// vpcmpeqd k1, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpcmpeqd k1, ymm, m256","vpcmpeqd k1, ymm, m256 |  | ")]
        vpcmpeqd_k1_ymm_m256 = 2596,

        /// <summary>
        /// vpcmpeqd k1, ymm, m32bcst |  | 
        /// </summary>
        [Symbol("vpcmpeqd k1, ymm, m32bcst","vpcmpeqd k1, ymm, m32bcst |  | ")]
        vpcmpeqd_k1_ymm_m32bcst = 2597,

        /// <summary>
        /// vpcmpeqd k1, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpcmpeqd k1, ymm, ymm","vpcmpeqd k1, ymm, ymm |  | ")]
        vpcmpeqd_k1_ymm_ymm = 2598,

        /// <summary>
        /// vpcmpeqd k1, zmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpcmpeqd k1, zmm, m32bcst","vpcmpeqd k1, zmm, m32bcst |  | ")]
        vpcmpeqd_k1_zmm_m32bcst = 2599,

        /// <summary>
        /// vpcmpeqd k1, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpcmpeqd k1, zmm, m512","vpcmpeqd k1, zmm, m512 |  | ")]
        vpcmpeqd_k1_zmm_m512 = 2600,

        /// <summary>
        /// vpcmpeqd k1, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpcmpeqd k1, zmm, zmm","vpcmpeqd k1, zmm, zmm |  | ")]
        vpcmpeqd_k1_zmm_zmm = 2601,

        /// <summary>
        /// vpcmpeqd xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpcmpeqd xmm, xmm, m128","vpcmpeqd xmm, xmm, m128 |  | ")]
        vpcmpeqd_xmm_xmm_m128 = 2602,

        /// <summary>
        /// vpcmpeqd xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpcmpeqd xmm, xmm, r8","vpcmpeqd xmm, xmm, r8 |  | ")]
        vpcmpeqd_xmm_xmm_r8 = 2603,

        /// <summary>
        /// vpcmpeqd ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpcmpeqd ymm, ymm, m256","vpcmpeqd ymm, ymm, m256 |  | ")]
        vpcmpeqd_ymm_ymm_m256 = 2604,

        /// <summary>
        /// vpcmpeqd ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpcmpeqd ymm, ymm, r16","vpcmpeqd ymm, ymm, r16 |  | ")]
        vpcmpeqd_ymm_ymm_r16 = 2605,

        /// <summary>
        /// vpcmpeqq k1 {k2}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpcmpeqq k1 {k2}, xmm, m128","vpcmpeqq k1 {k2}, xmm, m128 |  | ")]
        vpcmpeqq_k1_k2_xmm_m128 = 2606,

        /// <summary>
        /// vpcmpeqq k1 {k2}, xmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpcmpeqq k1 {k2}, xmm, m64bcst","vpcmpeqq k1 {k2}, xmm, m64bcst |  | ")]
        vpcmpeqq_k1_k2_xmm_m64bcst = 2607,

        /// <summary>
        /// vpcmpeqq k1 {k2}, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpcmpeqq k1 {k2}, xmm, xmm","vpcmpeqq k1 {k2}, xmm, xmm |  | ")]
        vpcmpeqq_k1_k2_xmm_xmm = 2608,

        /// <summary>
        /// vpcmpeqq k1 {k2}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpcmpeqq k1 {k2}, ymm, m256","vpcmpeqq k1 {k2}, ymm, m256 |  | ")]
        vpcmpeqq_k1_k2_ymm_m256 = 2609,

        /// <summary>
        /// vpcmpeqq k1 {k2}, ymm, m64bcst |  | 
        /// </summary>
        [Symbol("vpcmpeqq k1 {k2}, ymm, m64bcst","vpcmpeqq k1 {k2}, ymm, m64bcst |  | ")]
        vpcmpeqq_k1_k2_ymm_m64bcst = 2610,

        /// <summary>
        /// vpcmpeqq k1 {k2}, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpcmpeqq k1 {k2}, ymm, ymm","vpcmpeqq k1 {k2}, ymm, ymm |  | ")]
        vpcmpeqq_k1_k2_ymm_ymm = 2611,

        /// <summary>
        /// vpcmpeqq k1 {k2}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpcmpeqq k1 {k2}, zmm, m512","vpcmpeqq k1 {k2}, zmm, m512 |  | ")]
        vpcmpeqq_k1_k2_zmm_m512 = 2612,

        /// <summary>
        /// vpcmpeqq k1 {k2}, zmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpcmpeqq k1 {k2}, zmm, m64bcst","vpcmpeqq k1 {k2}, zmm, m64bcst |  | ")]
        vpcmpeqq_k1_k2_zmm_m64bcst = 2613,

        /// <summary>
        /// vpcmpeqq k1 {k2}, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpcmpeqq k1 {k2}, zmm, zmm","vpcmpeqq k1 {k2}, zmm, zmm |  | ")]
        vpcmpeqq_k1_k2_zmm_zmm = 2614,

        /// <summary>
        /// vpcmpeqq k1, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpcmpeqq k1, xmm, m128","vpcmpeqq k1, xmm, m128 |  | ")]
        vpcmpeqq_k1_xmm_m128 = 2615,

        /// <summary>
        /// vpcmpeqq k1, xmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpcmpeqq k1, xmm, m64bcst","vpcmpeqq k1, xmm, m64bcst |  | ")]
        vpcmpeqq_k1_xmm_m64bcst = 2616,

        /// <summary>
        /// vpcmpeqq k1, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpcmpeqq k1, xmm, xmm","vpcmpeqq k1, xmm, xmm |  | ")]
        vpcmpeqq_k1_xmm_xmm = 2617,

        /// <summary>
        /// vpcmpeqq k1, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpcmpeqq k1, ymm, m256","vpcmpeqq k1, ymm, m256 |  | ")]
        vpcmpeqq_k1_ymm_m256 = 2618,

        /// <summary>
        /// vpcmpeqq k1, ymm, m64bcst |  | 
        /// </summary>
        [Symbol("vpcmpeqq k1, ymm, m64bcst","vpcmpeqq k1, ymm, m64bcst |  | ")]
        vpcmpeqq_k1_ymm_m64bcst = 2619,

        /// <summary>
        /// vpcmpeqq k1, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpcmpeqq k1, ymm, ymm","vpcmpeqq k1, ymm, ymm |  | ")]
        vpcmpeqq_k1_ymm_ymm = 2620,

        /// <summary>
        /// vpcmpeqq k1, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpcmpeqq k1, zmm, m512","vpcmpeqq k1, zmm, m512 |  | ")]
        vpcmpeqq_k1_zmm_m512 = 2621,

        /// <summary>
        /// vpcmpeqq k1, zmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpcmpeqq k1, zmm, m64bcst","vpcmpeqq k1, zmm, m64bcst |  | ")]
        vpcmpeqq_k1_zmm_m64bcst = 2622,

        /// <summary>
        /// vpcmpeqq k1, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpcmpeqq k1, zmm, zmm","vpcmpeqq k1, zmm, zmm |  | ")]
        vpcmpeqq_k1_zmm_zmm = 2623,

        /// <summary>
        /// vpcmpeqq xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpcmpeqq xmm, xmm, m128","vpcmpeqq xmm, xmm, m128 |  | ")]
        vpcmpeqq_xmm_xmm_m128 = 2624,

        /// <summary>
        /// vpcmpeqq xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpcmpeqq xmm, xmm, r8","vpcmpeqq xmm, xmm, r8 |  | ")]
        vpcmpeqq_xmm_xmm_r8 = 2625,

        /// <summary>
        /// vpcmpeqq ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpcmpeqq ymm, ymm, m256","vpcmpeqq ymm, ymm, m256 |  | ")]
        vpcmpeqq_ymm_ymm_m256 = 2626,

        /// <summary>
        /// vpcmpeqq ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpcmpeqq ymm, ymm, r16","vpcmpeqq ymm, ymm, r16 |  | ")]
        vpcmpeqq_ymm_ymm_r16 = 2627,

        /// <summary>
        /// vpcmpeqw k1 {k2}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpcmpeqw k1 {k2}, xmm, m128","vpcmpeqw k1 {k2}, xmm, m128 |  | ")]
        vpcmpeqw_k1_k2_xmm_m128 = 2628,

        /// <summary>
        /// vpcmpeqw k1 {k2}, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpcmpeqw k1 {k2}, xmm, r8","vpcmpeqw k1 {k2}, xmm, r8 |  | ")]
        vpcmpeqw_k1_k2_xmm_r8 = 2629,

        /// <summary>
        /// vpcmpeqw k1 {k2}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpcmpeqw k1 {k2}, ymm, m256","vpcmpeqw k1 {k2}, ymm, m256 |  | ")]
        vpcmpeqw_k1_k2_ymm_m256 = 2630,

        /// <summary>
        /// vpcmpeqw k1 {k2}, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpcmpeqw k1 {k2}, ymm, r16","vpcmpeqw k1 {k2}, ymm, r16 |  | ")]
        vpcmpeqw_k1_k2_ymm_r16 = 2631,

        /// <summary>
        /// vpcmpeqw k1 {k2}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpcmpeqw k1 {k2}, zmm, m512","vpcmpeqw k1 {k2}, zmm, m512 |  | ")]
        vpcmpeqw_k1_k2_zmm_m512 = 2632,

        /// <summary>
        /// vpcmpeqw k1 {k2}, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpcmpeqw k1 {k2}, zmm, r32","vpcmpeqw k1 {k2}, zmm, r32 |  | ")]
        vpcmpeqw_k1_k2_zmm_r32 = 2633,

        /// <summary>
        /// vpcmpeqw k1, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpcmpeqw k1, xmm, m128","vpcmpeqw k1, xmm, m128 |  | ")]
        vpcmpeqw_k1_xmm_m128 = 2634,

        /// <summary>
        /// vpcmpeqw k1, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpcmpeqw k1, xmm, r8","vpcmpeqw k1, xmm, r8 |  | ")]
        vpcmpeqw_k1_xmm_r8 = 2635,

        /// <summary>
        /// vpcmpeqw k1, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpcmpeqw k1, ymm, m256","vpcmpeqw k1, ymm, m256 |  | ")]
        vpcmpeqw_k1_ymm_m256 = 2636,

        /// <summary>
        /// vpcmpeqw k1, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpcmpeqw k1, ymm, r16","vpcmpeqw k1, ymm, r16 |  | ")]
        vpcmpeqw_k1_ymm_r16 = 2637,

        /// <summary>
        /// vpcmpeqw k1, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpcmpeqw k1, zmm, m512","vpcmpeqw k1, zmm, m512 |  | ")]
        vpcmpeqw_k1_zmm_m512 = 2638,

        /// <summary>
        /// vpcmpeqw k1, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpcmpeqw k1, zmm, r32","vpcmpeqw k1, zmm, r32 |  | ")]
        vpcmpeqw_k1_zmm_r32 = 2639,

        /// <summary>
        /// vpcmpeqw xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpcmpeqw xmm, xmm, m128","vpcmpeqw xmm, xmm, m128 |  | ")]
        vpcmpeqw_xmm_xmm_m128 = 2640,

        /// <summary>
        /// vpcmpeqw xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpcmpeqw xmm, xmm, r8","vpcmpeqw xmm, xmm, r8 |  | ")]
        vpcmpeqw_xmm_xmm_r8 = 2641,

        /// <summary>
        /// vpcmpeqw ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpcmpeqw ymm, ymm, m256","vpcmpeqw ymm, ymm, m256 |  | ")]
        vpcmpeqw_ymm_ymm_m256 = 2642,

        /// <summary>
        /// vpcmpeqw ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpcmpeqw ymm, ymm, r16","vpcmpeqw ymm, ymm, r16 |  | ")]
        vpcmpeqw_ymm_ymm_r16 = 2643,

        /// <summary>
        /// vpcmpgtb k1 {k2}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpcmpgtb k1 {k2}, xmm, m128","vpcmpgtb k1 {k2}, xmm, m128 |  | ")]
        vpcmpgtb_k1_k2_xmm_m128 = 2644,

        /// <summary>
        /// vpcmpgtb k1 {k2}, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpcmpgtb k1 {k2}, xmm, r8","vpcmpgtb k1 {k2}, xmm, r8 |  | ")]
        vpcmpgtb_k1_k2_xmm_r8 = 2645,

        /// <summary>
        /// vpcmpgtb k1 {k2}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpcmpgtb k1 {k2}, ymm, m256","vpcmpgtb k1 {k2}, ymm, m256 |  | ")]
        vpcmpgtb_k1_k2_ymm_m256 = 2646,

        /// <summary>
        /// vpcmpgtb k1 {k2}, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpcmpgtb k1 {k2}, ymm, r16","vpcmpgtb k1 {k2}, ymm, r16 |  | ")]
        vpcmpgtb_k1_k2_ymm_r16 = 2647,

        /// <summary>
        /// vpcmpgtb k1 {k2}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpcmpgtb k1 {k2}, zmm, m512","vpcmpgtb k1 {k2}, zmm, m512 |  | ")]
        vpcmpgtb_k1_k2_zmm_m512 = 2648,

        /// <summary>
        /// vpcmpgtb k1 {k2}, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpcmpgtb k1 {k2}, zmm, r32","vpcmpgtb k1 {k2}, zmm, r32 |  | ")]
        vpcmpgtb_k1_k2_zmm_r32 = 2649,

        /// <summary>
        /// vpcmpgtb k1, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpcmpgtb k1, xmm, m128","vpcmpgtb k1, xmm, m128 |  | ")]
        vpcmpgtb_k1_xmm_m128 = 2650,

        /// <summary>
        /// vpcmpgtb k1, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpcmpgtb k1, xmm, r8","vpcmpgtb k1, xmm, r8 |  | ")]
        vpcmpgtb_k1_xmm_r8 = 2651,

        /// <summary>
        /// vpcmpgtb k1, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpcmpgtb k1, ymm, m256","vpcmpgtb k1, ymm, m256 |  | ")]
        vpcmpgtb_k1_ymm_m256 = 2652,

        /// <summary>
        /// vpcmpgtb k1, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpcmpgtb k1, ymm, r16","vpcmpgtb k1, ymm, r16 |  | ")]
        vpcmpgtb_k1_ymm_r16 = 2653,

        /// <summary>
        /// vpcmpgtb k1, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpcmpgtb k1, zmm, m512","vpcmpgtb k1, zmm, m512 |  | ")]
        vpcmpgtb_k1_zmm_m512 = 2654,

        /// <summary>
        /// vpcmpgtb k1, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpcmpgtb k1, zmm, r32","vpcmpgtb k1, zmm, r32 |  | ")]
        vpcmpgtb_k1_zmm_r32 = 2655,

        /// <summary>
        /// vpcmpgtb xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpcmpgtb xmm, xmm, m128","vpcmpgtb xmm, xmm, m128 |  | ")]
        vpcmpgtb_xmm_xmm_m128 = 2656,

        /// <summary>
        /// vpcmpgtb xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpcmpgtb xmm, xmm, r8","vpcmpgtb xmm, xmm, r8 |  | ")]
        vpcmpgtb_xmm_xmm_r8 = 2657,

        /// <summary>
        /// vpcmpgtb ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpcmpgtb ymm, ymm, m256","vpcmpgtb ymm, ymm, m256 |  | ")]
        vpcmpgtb_ymm_ymm_m256 = 2658,

        /// <summary>
        /// vpcmpgtb ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpcmpgtb ymm, ymm, r16","vpcmpgtb ymm, ymm, r16 |  | ")]
        vpcmpgtb_ymm_ymm_r16 = 2659,

        /// <summary>
        /// vpcmpgtd k1 {k2}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpcmpgtd k1 {k2}, xmm, m128","vpcmpgtd k1 {k2}, xmm, m128 |  | ")]
        vpcmpgtd_k1_k2_xmm_m128 = 2660,

        /// <summary>
        /// vpcmpgtd k1 {k2}, xmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpcmpgtd k1 {k2}, xmm, m32bcst","vpcmpgtd k1 {k2}, xmm, m32bcst |  | ")]
        vpcmpgtd_k1_k2_xmm_m32bcst = 2661,

        /// <summary>
        /// vpcmpgtd k1 {k2}, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpcmpgtd k1 {k2}, xmm, xmm","vpcmpgtd k1 {k2}, xmm, xmm |  | ")]
        vpcmpgtd_k1_k2_xmm_xmm = 2662,

        /// <summary>
        /// vpcmpgtd k1 {k2}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpcmpgtd k1 {k2}, ymm, m256","vpcmpgtd k1 {k2}, ymm, m256 |  | ")]
        vpcmpgtd_k1_k2_ymm_m256 = 2663,

        /// <summary>
        /// vpcmpgtd k1 {k2}, ymm, m32bcst |  | 
        /// </summary>
        [Symbol("vpcmpgtd k1 {k2}, ymm, m32bcst","vpcmpgtd k1 {k2}, ymm, m32bcst |  | ")]
        vpcmpgtd_k1_k2_ymm_m32bcst = 2664,

        /// <summary>
        /// vpcmpgtd k1 {k2}, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpcmpgtd k1 {k2}, ymm, ymm","vpcmpgtd k1 {k2}, ymm, ymm |  | ")]
        vpcmpgtd_k1_k2_ymm_ymm = 2665,

        /// <summary>
        /// vpcmpgtd k1 {k2}, zmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpcmpgtd k1 {k2}, zmm, m32bcst","vpcmpgtd k1 {k2}, zmm, m32bcst |  | ")]
        vpcmpgtd_k1_k2_zmm_m32bcst = 2666,

        /// <summary>
        /// vpcmpgtd k1 {k2}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpcmpgtd k1 {k2}, zmm, m512","vpcmpgtd k1 {k2}, zmm, m512 |  | ")]
        vpcmpgtd_k1_k2_zmm_m512 = 2667,

        /// <summary>
        /// vpcmpgtd k1 {k2}, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpcmpgtd k1 {k2}, zmm, zmm","vpcmpgtd k1 {k2}, zmm, zmm |  | ")]
        vpcmpgtd_k1_k2_zmm_zmm = 2668,

        /// <summary>
        /// vpcmpgtd k1, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpcmpgtd k1, xmm, m128","vpcmpgtd k1, xmm, m128 |  | ")]
        vpcmpgtd_k1_xmm_m128 = 2669,

        /// <summary>
        /// vpcmpgtd k1, xmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpcmpgtd k1, xmm, m32bcst","vpcmpgtd k1, xmm, m32bcst |  | ")]
        vpcmpgtd_k1_xmm_m32bcst = 2670,

        /// <summary>
        /// vpcmpgtd k1, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpcmpgtd k1, xmm, xmm","vpcmpgtd k1, xmm, xmm |  | ")]
        vpcmpgtd_k1_xmm_xmm = 2671,

        /// <summary>
        /// vpcmpgtd k1, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpcmpgtd k1, ymm, m256","vpcmpgtd k1, ymm, m256 |  | ")]
        vpcmpgtd_k1_ymm_m256 = 2672,

        /// <summary>
        /// vpcmpgtd k1, ymm, m32bcst |  | 
        /// </summary>
        [Symbol("vpcmpgtd k1, ymm, m32bcst","vpcmpgtd k1, ymm, m32bcst |  | ")]
        vpcmpgtd_k1_ymm_m32bcst = 2673,

        /// <summary>
        /// vpcmpgtd k1, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpcmpgtd k1, ymm, ymm","vpcmpgtd k1, ymm, ymm |  | ")]
        vpcmpgtd_k1_ymm_ymm = 2674,

        /// <summary>
        /// vpcmpgtd k1, zmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpcmpgtd k1, zmm, m32bcst","vpcmpgtd k1, zmm, m32bcst |  | ")]
        vpcmpgtd_k1_zmm_m32bcst = 2675,

        /// <summary>
        /// vpcmpgtd k1, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpcmpgtd k1, zmm, m512","vpcmpgtd k1, zmm, m512 |  | ")]
        vpcmpgtd_k1_zmm_m512 = 2676,

        /// <summary>
        /// vpcmpgtd k1, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpcmpgtd k1, zmm, zmm","vpcmpgtd k1, zmm, zmm |  | ")]
        vpcmpgtd_k1_zmm_zmm = 2677,

        /// <summary>
        /// vpcmpgtd xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpcmpgtd xmm, xmm, m128","vpcmpgtd xmm, xmm, m128 |  | ")]
        vpcmpgtd_xmm_xmm_m128 = 2678,

        /// <summary>
        /// vpcmpgtd xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpcmpgtd xmm, xmm, r8","vpcmpgtd xmm, xmm, r8 |  | ")]
        vpcmpgtd_xmm_xmm_r8 = 2679,

        /// <summary>
        /// vpcmpgtd ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpcmpgtd ymm, ymm, m256","vpcmpgtd ymm, ymm, m256 |  | ")]
        vpcmpgtd_ymm_ymm_m256 = 2680,

        /// <summary>
        /// vpcmpgtd ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpcmpgtd ymm, ymm, r16","vpcmpgtd ymm, ymm, r16 |  | ")]
        vpcmpgtd_ymm_ymm_r16 = 2681,

        /// <summary>
        /// vpcmpgtq k1 {k2}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpcmpgtq k1 {k2}, xmm, m128","vpcmpgtq k1 {k2}, xmm, m128 |  | ")]
        vpcmpgtq_k1_k2_xmm_m128 = 2682,

        /// <summary>
        /// vpcmpgtq k1 {k2}, xmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpcmpgtq k1 {k2}, xmm, m64bcst","vpcmpgtq k1 {k2}, xmm, m64bcst |  | ")]
        vpcmpgtq_k1_k2_xmm_m64bcst = 2683,

        /// <summary>
        /// vpcmpgtq k1 {k2}, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpcmpgtq k1 {k2}, xmm, xmm","vpcmpgtq k1 {k2}, xmm, xmm |  | ")]
        vpcmpgtq_k1_k2_xmm_xmm = 2684,

        /// <summary>
        /// vpcmpgtq k1 {k2}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpcmpgtq k1 {k2}, ymm, m256","vpcmpgtq k1 {k2}, ymm, m256 |  | ")]
        vpcmpgtq_k1_k2_ymm_m256 = 2685,

        /// <summary>
        /// vpcmpgtq k1 {k2}, ymm, m64bcst |  | 
        /// </summary>
        [Symbol("vpcmpgtq k1 {k2}, ymm, m64bcst","vpcmpgtq k1 {k2}, ymm, m64bcst |  | ")]
        vpcmpgtq_k1_k2_ymm_m64bcst = 2686,

        /// <summary>
        /// vpcmpgtq k1 {k2}, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpcmpgtq k1 {k2}, ymm, ymm","vpcmpgtq k1 {k2}, ymm, ymm |  | ")]
        vpcmpgtq_k1_k2_ymm_ymm = 2687,

        /// <summary>
        /// vpcmpgtq k1 {k2}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpcmpgtq k1 {k2}, zmm, m512","vpcmpgtq k1 {k2}, zmm, m512 |  | ")]
        vpcmpgtq_k1_k2_zmm_m512 = 2688,

        /// <summary>
        /// vpcmpgtq k1 {k2}, zmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpcmpgtq k1 {k2}, zmm, m64bcst","vpcmpgtq k1 {k2}, zmm, m64bcst |  | ")]
        vpcmpgtq_k1_k2_zmm_m64bcst = 2689,

        /// <summary>
        /// vpcmpgtq k1 {k2}, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpcmpgtq k1 {k2}, zmm, zmm","vpcmpgtq k1 {k2}, zmm, zmm |  | ")]
        vpcmpgtq_k1_k2_zmm_zmm = 2690,

        /// <summary>
        /// vpcmpgtq k1, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpcmpgtq k1, xmm, m128","vpcmpgtq k1, xmm, m128 |  | ")]
        vpcmpgtq_k1_xmm_m128 = 2691,

        /// <summary>
        /// vpcmpgtq k1, xmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpcmpgtq k1, xmm, m64bcst","vpcmpgtq k1, xmm, m64bcst |  | ")]
        vpcmpgtq_k1_xmm_m64bcst = 2692,

        /// <summary>
        /// vpcmpgtq k1, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpcmpgtq k1, xmm, xmm","vpcmpgtq k1, xmm, xmm |  | ")]
        vpcmpgtq_k1_xmm_xmm = 2693,

        /// <summary>
        /// vpcmpgtq k1, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpcmpgtq k1, ymm, m256","vpcmpgtq k1, ymm, m256 |  | ")]
        vpcmpgtq_k1_ymm_m256 = 2694,

        /// <summary>
        /// vpcmpgtq k1, ymm, m64bcst |  | 
        /// </summary>
        [Symbol("vpcmpgtq k1, ymm, m64bcst","vpcmpgtq k1, ymm, m64bcst |  | ")]
        vpcmpgtq_k1_ymm_m64bcst = 2695,

        /// <summary>
        /// vpcmpgtq k1, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpcmpgtq k1, ymm, ymm","vpcmpgtq k1, ymm, ymm |  | ")]
        vpcmpgtq_k1_ymm_ymm = 2696,

        /// <summary>
        /// vpcmpgtq k1, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpcmpgtq k1, zmm, m512","vpcmpgtq k1, zmm, m512 |  | ")]
        vpcmpgtq_k1_zmm_m512 = 2697,

        /// <summary>
        /// vpcmpgtq k1, zmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpcmpgtq k1, zmm, m64bcst","vpcmpgtq k1, zmm, m64bcst |  | ")]
        vpcmpgtq_k1_zmm_m64bcst = 2698,

        /// <summary>
        /// vpcmpgtq k1, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpcmpgtq k1, zmm, zmm","vpcmpgtq k1, zmm, zmm |  | ")]
        vpcmpgtq_k1_zmm_zmm = 2699,

        /// <summary>
        /// vpcmpgtq xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpcmpgtq xmm, xmm, m128","vpcmpgtq xmm, xmm, m128 |  | ")]
        vpcmpgtq_xmm_xmm_m128 = 2700,

        /// <summary>
        /// vpcmpgtq xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpcmpgtq xmm, xmm, r8","vpcmpgtq xmm, xmm, r8 |  | ")]
        vpcmpgtq_xmm_xmm_r8 = 2701,

        /// <summary>
        /// vpcmpgtq ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpcmpgtq ymm, ymm, m256","vpcmpgtq ymm, ymm, m256 |  | ")]
        vpcmpgtq_ymm_ymm_m256 = 2702,

        /// <summary>
        /// vpcmpgtq ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpcmpgtq ymm, ymm, r16","vpcmpgtq ymm, ymm, r16 |  | ")]
        vpcmpgtq_ymm_ymm_r16 = 2703,

        /// <summary>
        /// vpcmpgtw k1 {k2}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpcmpgtw k1 {k2}, xmm, m128","vpcmpgtw k1 {k2}, xmm, m128 |  | ")]
        vpcmpgtw_k1_k2_xmm_m128 = 2704,

        /// <summary>
        /// vpcmpgtw k1 {k2}, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpcmpgtw k1 {k2}, xmm, r8","vpcmpgtw k1 {k2}, xmm, r8 |  | ")]
        vpcmpgtw_k1_k2_xmm_r8 = 2705,

        /// <summary>
        /// vpcmpgtw k1 {k2}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpcmpgtw k1 {k2}, ymm, m256","vpcmpgtw k1 {k2}, ymm, m256 |  | ")]
        vpcmpgtw_k1_k2_ymm_m256 = 2706,

        /// <summary>
        /// vpcmpgtw k1 {k2}, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpcmpgtw k1 {k2}, ymm, r16","vpcmpgtw k1 {k2}, ymm, r16 |  | ")]
        vpcmpgtw_k1_k2_ymm_r16 = 2707,

        /// <summary>
        /// vpcmpgtw k1 {k2}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpcmpgtw k1 {k2}, zmm, m512","vpcmpgtw k1 {k2}, zmm, m512 |  | ")]
        vpcmpgtw_k1_k2_zmm_m512 = 2708,

        /// <summary>
        /// vpcmpgtw k1 {k2}, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpcmpgtw k1 {k2}, zmm, r32","vpcmpgtw k1 {k2}, zmm, r32 |  | ")]
        vpcmpgtw_k1_k2_zmm_r32 = 2709,

        /// <summary>
        /// vpcmpgtw k1, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpcmpgtw k1, xmm, m128","vpcmpgtw k1, xmm, m128 |  | ")]
        vpcmpgtw_k1_xmm_m128 = 2710,

        /// <summary>
        /// vpcmpgtw k1, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpcmpgtw k1, xmm, r8","vpcmpgtw k1, xmm, r8 |  | ")]
        vpcmpgtw_k1_xmm_r8 = 2711,

        /// <summary>
        /// vpcmpgtw k1, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpcmpgtw k1, ymm, m256","vpcmpgtw k1, ymm, m256 |  | ")]
        vpcmpgtw_k1_ymm_m256 = 2712,

        /// <summary>
        /// vpcmpgtw k1, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpcmpgtw k1, ymm, r16","vpcmpgtw k1, ymm, r16 |  | ")]
        vpcmpgtw_k1_ymm_r16 = 2713,

        /// <summary>
        /// vpcmpgtw k1, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpcmpgtw k1, zmm, m512","vpcmpgtw k1, zmm, m512 |  | ")]
        vpcmpgtw_k1_zmm_m512 = 2714,

        /// <summary>
        /// vpcmpgtw k1, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpcmpgtw k1, zmm, r32","vpcmpgtw k1, zmm, r32 |  | ")]
        vpcmpgtw_k1_zmm_r32 = 2715,

        /// <summary>
        /// vpcmpgtw xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpcmpgtw xmm, xmm, m128","vpcmpgtw xmm, xmm, m128 |  | ")]
        vpcmpgtw_xmm_xmm_m128 = 2716,

        /// <summary>
        /// vpcmpgtw xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpcmpgtw xmm, xmm, r8","vpcmpgtw xmm, xmm, r8 |  | ")]
        vpcmpgtw_xmm_xmm_r8 = 2717,

        /// <summary>
        /// vpcmpgtw ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpcmpgtw ymm, ymm, m256","vpcmpgtw ymm, ymm, m256 |  | ")]
        vpcmpgtw_ymm_ymm_m256 = 2718,

        /// <summary>
        /// vpcmpgtw ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpcmpgtw ymm, ymm, r16","vpcmpgtw ymm, ymm, r16 |  | ")]
        vpcmpgtw_ymm_ymm_r16 = 2719,

        /// <summary>
        /// vpcmpq k1 {k2}, xmm, m128, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpq k1 {k2}, xmm, m128, imm8","vpcmpq k1 {k2}, xmm, m128, imm8 |  | ")]
        vpcmpq_k1_k2_xmm_m128_imm8 = 2720,

        /// <summary>
        /// vpcmpq k1 {k2}, xmm, m64bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpq k1 {k2}, xmm, m64bcst, imm8","vpcmpq k1 {k2}, xmm, m64bcst, imm8 |  | ")]
        vpcmpq_k1_k2_xmm_m64bcst_imm8 = 2721,

        /// <summary>
        /// vpcmpq k1 {k2}, xmm, xmm, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpq k1 {k2}, xmm, xmm, imm8","vpcmpq k1 {k2}, xmm, xmm, imm8 |  | ")]
        vpcmpq_k1_k2_xmm_xmm_imm8 = 2722,

        /// <summary>
        /// vpcmpq k1 {k2}, ymm, m256, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpq k1 {k2}, ymm, m256, imm8","vpcmpq k1 {k2}, ymm, m256, imm8 |  | ")]
        vpcmpq_k1_k2_ymm_m256_imm8 = 2723,

        /// <summary>
        /// vpcmpq k1 {k2}, ymm, m64bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpq k1 {k2}, ymm, m64bcst, imm8","vpcmpq k1 {k2}, ymm, m64bcst, imm8 |  | ")]
        vpcmpq_k1_k2_ymm_m64bcst_imm8 = 2724,

        /// <summary>
        /// vpcmpq k1 {k2}, ymm, ymm, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpq k1 {k2}, ymm, ymm, imm8","vpcmpq k1 {k2}, ymm, ymm, imm8 |  | ")]
        vpcmpq_k1_k2_ymm_ymm_imm8 = 2725,

        /// <summary>
        /// vpcmpq k1 {k2}, zmm, m512, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpq k1 {k2}, zmm, m512, imm8","vpcmpq k1 {k2}, zmm, m512, imm8 |  | ")]
        vpcmpq_k1_k2_zmm_m512_imm8 = 2726,

        /// <summary>
        /// vpcmpq k1 {k2}, zmm, m64bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpq k1 {k2}, zmm, m64bcst, imm8","vpcmpq k1 {k2}, zmm, m64bcst, imm8 |  | ")]
        vpcmpq_k1_k2_zmm_m64bcst_imm8 = 2727,

        /// <summary>
        /// vpcmpq k1 {k2}, zmm, zmm, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpq k1 {k2}, zmm, zmm, imm8","vpcmpq k1 {k2}, zmm, zmm, imm8 |  | ")]
        vpcmpq_k1_k2_zmm_zmm_imm8 = 2728,

        /// <summary>
        /// vpcmpq k1, xmm, m128, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpq k1, xmm, m128, imm8","vpcmpq k1, xmm, m128, imm8 |  | ")]
        vpcmpq_k1_xmm_m128_imm8 = 2729,

        /// <summary>
        /// vpcmpq k1, xmm, m64bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpq k1, xmm, m64bcst, imm8","vpcmpq k1, xmm, m64bcst, imm8 |  | ")]
        vpcmpq_k1_xmm_m64bcst_imm8 = 2730,

        /// <summary>
        /// vpcmpq k1, xmm, xmm, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpq k1, xmm, xmm, imm8","vpcmpq k1, xmm, xmm, imm8 |  | ")]
        vpcmpq_k1_xmm_xmm_imm8 = 2731,

        /// <summary>
        /// vpcmpq k1, ymm, m256, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpq k1, ymm, m256, imm8","vpcmpq k1, ymm, m256, imm8 |  | ")]
        vpcmpq_k1_ymm_m256_imm8 = 2732,

        /// <summary>
        /// vpcmpq k1, ymm, m64bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpq k1, ymm, m64bcst, imm8","vpcmpq k1, ymm, m64bcst, imm8 |  | ")]
        vpcmpq_k1_ymm_m64bcst_imm8 = 2733,

        /// <summary>
        /// vpcmpq k1, ymm, ymm, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpq k1, ymm, ymm, imm8","vpcmpq k1, ymm, ymm, imm8 |  | ")]
        vpcmpq_k1_ymm_ymm_imm8 = 2734,

        /// <summary>
        /// vpcmpq k1, zmm, m512, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpq k1, zmm, m512, imm8","vpcmpq k1, zmm, m512, imm8 |  | ")]
        vpcmpq_k1_zmm_m512_imm8 = 2735,

        /// <summary>
        /// vpcmpq k1, zmm, m64bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpq k1, zmm, m64bcst, imm8","vpcmpq k1, zmm, m64bcst, imm8 |  | ")]
        vpcmpq_k1_zmm_m64bcst_imm8 = 2736,

        /// <summary>
        /// vpcmpq k1, zmm, zmm, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpq k1, zmm, zmm, imm8","vpcmpq k1, zmm, zmm, imm8 |  | ")]
        vpcmpq_k1_zmm_zmm_imm8 = 2737,

        /// <summary>
        /// vpcmpub k1 {k2}, xmm, m128, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpub k1 {k2}, xmm, m128, imm8","vpcmpub k1 {k2}, xmm, m128, imm8 |  | ")]
        vpcmpub_k1_k2_xmm_m128_imm8 = 2738,

        /// <summary>
        /// vpcmpub k1 {k2}, xmm, r8, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpub k1 {k2}, xmm, r8, imm8","vpcmpub k1 {k2}, xmm, r8, imm8 |  | ")]
        vpcmpub_k1_k2_xmm_r8_imm8 = 2739,

        /// <summary>
        /// vpcmpub k1 {k2}, ymm, m256, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpub k1 {k2}, ymm, m256, imm8","vpcmpub k1 {k2}, ymm, m256, imm8 |  | ")]
        vpcmpub_k1_k2_ymm_m256_imm8 = 2740,

        /// <summary>
        /// vpcmpub k1 {k2}, ymm, r16, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpub k1 {k2}, ymm, r16, imm8","vpcmpub k1 {k2}, ymm, r16, imm8 |  | ")]
        vpcmpub_k1_k2_ymm_r16_imm8 = 2741,

        /// <summary>
        /// vpcmpub k1 {k2}, zmm, m512, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpub k1 {k2}, zmm, m512, imm8","vpcmpub k1 {k2}, zmm, m512, imm8 |  | ")]
        vpcmpub_k1_k2_zmm_m512_imm8 = 2742,

        /// <summary>
        /// vpcmpub k1 {k2}, zmm, r32, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpub k1 {k2}, zmm, r32, imm8","vpcmpub k1 {k2}, zmm, r32, imm8 |  | ")]
        vpcmpub_k1_k2_zmm_r32_imm8 = 2743,

        /// <summary>
        /// vpcmpub k1, xmm, m128, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpub k1, xmm, m128, imm8","vpcmpub k1, xmm, m128, imm8 |  | ")]
        vpcmpub_k1_xmm_m128_imm8 = 2744,

        /// <summary>
        /// vpcmpub k1, xmm, r8, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpub k1, xmm, r8, imm8","vpcmpub k1, xmm, r8, imm8 |  | ")]
        vpcmpub_k1_xmm_r8_imm8 = 2745,

        /// <summary>
        /// vpcmpub k1, ymm, m256, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpub k1, ymm, m256, imm8","vpcmpub k1, ymm, m256, imm8 |  | ")]
        vpcmpub_k1_ymm_m256_imm8 = 2746,

        /// <summary>
        /// vpcmpub k1, ymm, r16, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpub k1, ymm, r16, imm8","vpcmpub k1, ymm, r16, imm8 |  | ")]
        vpcmpub_k1_ymm_r16_imm8 = 2747,

        /// <summary>
        /// vpcmpub k1, zmm, m512, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpub k1, zmm, m512, imm8","vpcmpub k1, zmm, m512, imm8 |  | ")]
        vpcmpub_k1_zmm_m512_imm8 = 2748,

        /// <summary>
        /// vpcmpub k1, zmm, r32, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpub k1, zmm, r32, imm8","vpcmpub k1, zmm, r32, imm8 |  | ")]
        vpcmpub_k1_zmm_r32_imm8 = 2749,

        /// <summary>
        /// vpcmpud k1 {k2}, xmm, m128, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpud k1 {k2}, xmm, m128, imm8","vpcmpud k1 {k2}, xmm, m128, imm8 |  | ")]
        vpcmpud_k1_k2_xmm_m128_imm8 = 2750,

        /// <summary>
        /// vpcmpud k1 {k2}, xmm, m32bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpud k1 {k2}, xmm, m32bcst, imm8","vpcmpud k1 {k2}, xmm, m32bcst, imm8 |  | ")]
        vpcmpud_k1_k2_xmm_m32bcst_imm8 = 2751,

        /// <summary>
        /// vpcmpud k1 {k2}, xmm, xmm, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpud k1 {k2}, xmm, xmm, imm8","vpcmpud k1 {k2}, xmm, xmm, imm8 |  | ")]
        vpcmpud_k1_k2_xmm_xmm_imm8 = 2752,

        /// <summary>
        /// vpcmpud k1 {k2}, ymm, m256, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpud k1 {k2}, ymm, m256, imm8","vpcmpud k1 {k2}, ymm, m256, imm8 |  | ")]
        vpcmpud_k1_k2_ymm_m256_imm8 = 2753,

        /// <summary>
        /// vpcmpud k1 {k2}, ymm, m32bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpud k1 {k2}, ymm, m32bcst, imm8","vpcmpud k1 {k2}, ymm, m32bcst, imm8 |  | ")]
        vpcmpud_k1_k2_ymm_m32bcst_imm8 = 2754,

        /// <summary>
        /// vpcmpud k1 {k2}, ymm, ymm, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpud k1 {k2}, ymm, ymm, imm8","vpcmpud k1 {k2}, ymm, ymm, imm8 |  | ")]
        vpcmpud_k1_k2_ymm_ymm_imm8 = 2755,

        /// <summary>
        /// vpcmpud k1 {k2}, zmm, m32bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpud k1 {k2}, zmm, m32bcst, imm8","vpcmpud k1 {k2}, zmm, m32bcst, imm8 |  | ")]
        vpcmpud_k1_k2_zmm_m32bcst_imm8 = 2756,

        /// <summary>
        /// vpcmpud k1 {k2}, zmm, m512, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpud k1 {k2}, zmm, m512, imm8","vpcmpud k1 {k2}, zmm, m512, imm8 |  | ")]
        vpcmpud_k1_k2_zmm_m512_imm8 = 2757,

        /// <summary>
        /// vpcmpud k1 {k2}, zmm, zmm, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpud k1 {k2}, zmm, zmm, imm8","vpcmpud k1 {k2}, zmm, zmm, imm8 |  | ")]
        vpcmpud_k1_k2_zmm_zmm_imm8 = 2758,

        /// <summary>
        /// vpcmpud k1, xmm, m128, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpud k1, xmm, m128, imm8","vpcmpud k1, xmm, m128, imm8 |  | ")]
        vpcmpud_k1_xmm_m128_imm8 = 2759,

        /// <summary>
        /// vpcmpud k1, xmm, m32bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpud k1, xmm, m32bcst, imm8","vpcmpud k1, xmm, m32bcst, imm8 |  | ")]
        vpcmpud_k1_xmm_m32bcst_imm8 = 2760,

        /// <summary>
        /// vpcmpud k1, xmm, xmm, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpud k1, xmm, xmm, imm8","vpcmpud k1, xmm, xmm, imm8 |  | ")]
        vpcmpud_k1_xmm_xmm_imm8 = 2761,

        /// <summary>
        /// vpcmpud k1, ymm, m256, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpud k1, ymm, m256, imm8","vpcmpud k1, ymm, m256, imm8 |  | ")]
        vpcmpud_k1_ymm_m256_imm8 = 2762,

        /// <summary>
        /// vpcmpud k1, ymm, m32bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpud k1, ymm, m32bcst, imm8","vpcmpud k1, ymm, m32bcst, imm8 |  | ")]
        vpcmpud_k1_ymm_m32bcst_imm8 = 2763,

        /// <summary>
        /// vpcmpud k1, ymm, ymm, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpud k1, ymm, ymm, imm8","vpcmpud k1, ymm, ymm, imm8 |  | ")]
        vpcmpud_k1_ymm_ymm_imm8 = 2764,

        /// <summary>
        /// vpcmpud k1, zmm, m32bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpud k1, zmm, m32bcst, imm8","vpcmpud k1, zmm, m32bcst, imm8 |  | ")]
        vpcmpud_k1_zmm_m32bcst_imm8 = 2765,

        /// <summary>
        /// vpcmpud k1, zmm, m512, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpud k1, zmm, m512, imm8","vpcmpud k1, zmm, m512, imm8 |  | ")]
        vpcmpud_k1_zmm_m512_imm8 = 2766,

        /// <summary>
        /// vpcmpud k1, zmm, zmm, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpud k1, zmm, zmm, imm8","vpcmpud k1, zmm, zmm, imm8 |  | ")]
        vpcmpud_k1_zmm_zmm_imm8 = 2767,

        /// <summary>
        /// vpcmpuq k1 {k2}, xmm, m128, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpuq k1 {k2}, xmm, m128, imm8","vpcmpuq k1 {k2}, xmm, m128, imm8 |  | ")]
        vpcmpuq_k1_k2_xmm_m128_imm8 = 2768,

        /// <summary>
        /// vpcmpuq k1 {k2}, xmm, m64bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpuq k1 {k2}, xmm, m64bcst, imm8","vpcmpuq k1 {k2}, xmm, m64bcst, imm8 |  | ")]
        vpcmpuq_k1_k2_xmm_m64bcst_imm8 = 2769,

        /// <summary>
        /// vpcmpuq k1 {k2}, xmm, xmm, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpuq k1 {k2}, xmm, xmm, imm8","vpcmpuq k1 {k2}, xmm, xmm, imm8 |  | ")]
        vpcmpuq_k1_k2_xmm_xmm_imm8 = 2770,

        /// <summary>
        /// vpcmpuq k1 {k2}, ymm, m256, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpuq k1 {k2}, ymm, m256, imm8","vpcmpuq k1 {k2}, ymm, m256, imm8 |  | ")]
        vpcmpuq_k1_k2_ymm_m256_imm8 = 2771,

        /// <summary>
        /// vpcmpuq k1 {k2}, ymm, m64bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpuq k1 {k2}, ymm, m64bcst, imm8","vpcmpuq k1 {k2}, ymm, m64bcst, imm8 |  | ")]
        vpcmpuq_k1_k2_ymm_m64bcst_imm8 = 2772,

        /// <summary>
        /// vpcmpuq k1 {k2}, ymm, ymm, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpuq k1 {k2}, ymm, ymm, imm8","vpcmpuq k1 {k2}, ymm, ymm, imm8 |  | ")]
        vpcmpuq_k1_k2_ymm_ymm_imm8 = 2773,

        /// <summary>
        /// vpcmpuq k1 {k2}, zmm, m512, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpuq k1 {k2}, zmm, m512, imm8","vpcmpuq k1 {k2}, zmm, m512, imm8 |  | ")]
        vpcmpuq_k1_k2_zmm_m512_imm8 = 2774,

        /// <summary>
        /// vpcmpuq k1 {k2}, zmm, m64bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpuq k1 {k2}, zmm, m64bcst, imm8","vpcmpuq k1 {k2}, zmm, m64bcst, imm8 |  | ")]
        vpcmpuq_k1_k2_zmm_m64bcst_imm8 = 2775,

        /// <summary>
        /// vpcmpuq k1 {k2}, zmm, zmm, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpuq k1 {k2}, zmm, zmm, imm8","vpcmpuq k1 {k2}, zmm, zmm, imm8 |  | ")]
        vpcmpuq_k1_k2_zmm_zmm_imm8 = 2776,

        /// <summary>
        /// vpcmpuq k1, xmm, m128, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpuq k1, xmm, m128, imm8","vpcmpuq k1, xmm, m128, imm8 |  | ")]
        vpcmpuq_k1_xmm_m128_imm8 = 2777,

        /// <summary>
        /// vpcmpuq k1, xmm, m64bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpuq k1, xmm, m64bcst, imm8","vpcmpuq k1, xmm, m64bcst, imm8 |  | ")]
        vpcmpuq_k1_xmm_m64bcst_imm8 = 2778,

        /// <summary>
        /// vpcmpuq k1, xmm, xmm, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpuq k1, xmm, xmm, imm8","vpcmpuq k1, xmm, xmm, imm8 |  | ")]
        vpcmpuq_k1_xmm_xmm_imm8 = 2779,

        /// <summary>
        /// vpcmpuq k1, ymm, m256, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpuq k1, ymm, m256, imm8","vpcmpuq k1, ymm, m256, imm8 |  | ")]
        vpcmpuq_k1_ymm_m256_imm8 = 2780,

        /// <summary>
        /// vpcmpuq k1, ymm, m64bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpuq k1, ymm, m64bcst, imm8","vpcmpuq k1, ymm, m64bcst, imm8 |  | ")]
        vpcmpuq_k1_ymm_m64bcst_imm8 = 2781,

        /// <summary>
        /// vpcmpuq k1, ymm, ymm, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpuq k1, ymm, ymm, imm8","vpcmpuq k1, ymm, ymm, imm8 |  | ")]
        vpcmpuq_k1_ymm_ymm_imm8 = 2782,

        /// <summary>
        /// vpcmpuq k1, zmm, m512, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpuq k1, zmm, m512, imm8","vpcmpuq k1, zmm, m512, imm8 |  | ")]
        vpcmpuq_k1_zmm_m512_imm8 = 2783,

        /// <summary>
        /// vpcmpuq k1, zmm, m64bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpuq k1, zmm, m64bcst, imm8","vpcmpuq k1, zmm, m64bcst, imm8 |  | ")]
        vpcmpuq_k1_zmm_m64bcst_imm8 = 2784,

        /// <summary>
        /// vpcmpuq k1, zmm, zmm, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpuq k1, zmm, zmm, imm8","vpcmpuq k1, zmm, zmm, imm8 |  | ")]
        vpcmpuq_k1_zmm_zmm_imm8 = 2785,

        /// <summary>
        /// vpcmpuw k1 {k2}, xmm, m128, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpuw k1 {k2}, xmm, m128, imm8","vpcmpuw k1 {k2}, xmm, m128, imm8 |  | ")]
        vpcmpuw_k1_k2_xmm_m128_imm8 = 2786,

        /// <summary>
        /// vpcmpuw k1 {k2}, xmm, r8, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpuw k1 {k2}, xmm, r8, imm8","vpcmpuw k1 {k2}, xmm, r8, imm8 |  | ")]
        vpcmpuw_k1_k2_xmm_r8_imm8 = 2787,

        /// <summary>
        /// vpcmpuw k1 {k2}, ymm, m256, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpuw k1 {k2}, ymm, m256, imm8","vpcmpuw k1 {k2}, ymm, m256, imm8 |  | ")]
        vpcmpuw_k1_k2_ymm_m256_imm8 = 2788,

        /// <summary>
        /// vpcmpuw k1 {k2}, ymm, r16, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpuw k1 {k2}, ymm, r16, imm8","vpcmpuw k1 {k2}, ymm, r16, imm8 |  | ")]
        vpcmpuw_k1_k2_ymm_r16_imm8 = 2789,

        /// <summary>
        /// vpcmpuw k1 {k2}, zmm, m512, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpuw k1 {k2}, zmm, m512, imm8","vpcmpuw k1 {k2}, zmm, m512, imm8 |  | ")]
        vpcmpuw_k1_k2_zmm_m512_imm8 = 2790,

        /// <summary>
        /// vpcmpuw k1 {k2}, zmm, r32, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpuw k1 {k2}, zmm, r32, imm8","vpcmpuw k1 {k2}, zmm, r32, imm8 |  | ")]
        vpcmpuw_k1_k2_zmm_r32_imm8 = 2791,

        /// <summary>
        /// vpcmpuw k1, xmm, m128, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpuw k1, xmm, m128, imm8","vpcmpuw k1, xmm, m128, imm8 |  | ")]
        vpcmpuw_k1_xmm_m128_imm8 = 2792,

        /// <summary>
        /// vpcmpuw k1, xmm, r8, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpuw k1, xmm, r8, imm8","vpcmpuw k1, xmm, r8, imm8 |  | ")]
        vpcmpuw_k1_xmm_r8_imm8 = 2793,

        /// <summary>
        /// vpcmpuw k1, ymm, m256, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpuw k1, ymm, m256, imm8","vpcmpuw k1, ymm, m256, imm8 |  | ")]
        vpcmpuw_k1_ymm_m256_imm8 = 2794,

        /// <summary>
        /// vpcmpuw k1, ymm, r16, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpuw k1, ymm, r16, imm8","vpcmpuw k1, ymm, r16, imm8 |  | ")]
        vpcmpuw_k1_ymm_r16_imm8 = 2795,

        /// <summary>
        /// vpcmpuw k1, zmm, m512, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpuw k1, zmm, m512, imm8","vpcmpuw k1, zmm, m512, imm8 |  | ")]
        vpcmpuw_k1_zmm_m512_imm8 = 2796,

        /// <summary>
        /// vpcmpuw k1, zmm, r32, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpuw k1, zmm, r32, imm8","vpcmpuw k1, zmm, r32, imm8 |  | ")]
        vpcmpuw_k1_zmm_r32_imm8 = 2797,

        /// <summary>
        /// vpcmpw k1 {k2}, xmm, m128, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpw k1 {k2}, xmm, m128, imm8","vpcmpw k1 {k2}, xmm, m128, imm8 |  | ")]
        vpcmpw_k1_k2_xmm_m128_imm8 = 2798,

        /// <summary>
        /// vpcmpw k1 {k2}, xmm, r8, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpw k1 {k2}, xmm, r8, imm8","vpcmpw k1 {k2}, xmm, r8, imm8 |  | ")]
        vpcmpw_k1_k2_xmm_r8_imm8 = 2799,

        /// <summary>
        /// vpcmpw k1 {k2}, ymm, m256, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpw k1 {k2}, ymm, m256, imm8","vpcmpw k1 {k2}, ymm, m256, imm8 |  | ")]
        vpcmpw_k1_k2_ymm_m256_imm8 = 2800,

        /// <summary>
        /// vpcmpw k1 {k2}, ymm, r16, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpw k1 {k2}, ymm, r16, imm8","vpcmpw k1 {k2}, ymm, r16, imm8 |  | ")]
        vpcmpw_k1_k2_ymm_r16_imm8 = 2801,

        /// <summary>
        /// vpcmpw k1 {k2}, zmm, m512, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpw k1 {k2}, zmm, m512, imm8","vpcmpw k1 {k2}, zmm, m512, imm8 |  | ")]
        vpcmpw_k1_k2_zmm_m512_imm8 = 2802,

        /// <summary>
        /// vpcmpw k1 {k2}, zmm, r32, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpw k1 {k2}, zmm, r32, imm8","vpcmpw k1 {k2}, zmm, r32, imm8 |  | ")]
        vpcmpw_k1_k2_zmm_r32_imm8 = 2803,

        /// <summary>
        /// vpcmpw k1, xmm, m128, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpw k1, xmm, m128, imm8","vpcmpw k1, xmm, m128, imm8 |  | ")]
        vpcmpw_k1_xmm_m128_imm8 = 2804,

        /// <summary>
        /// vpcmpw k1, xmm, r8, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpw k1, xmm, r8, imm8","vpcmpw k1, xmm, r8, imm8 |  | ")]
        vpcmpw_k1_xmm_r8_imm8 = 2805,

        /// <summary>
        /// vpcmpw k1, ymm, m256, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpw k1, ymm, m256, imm8","vpcmpw k1, ymm, m256, imm8 |  | ")]
        vpcmpw_k1_ymm_m256_imm8 = 2806,

        /// <summary>
        /// vpcmpw k1, ymm, r16, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpw k1, ymm, r16, imm8","vpcmpw k1, ymm, r16, imm8 |  | ")]
        vpcmpw_k1_ymm_r16_imm8 = 2807,

        /// <summary>
        /// vpcmpw k1, zmm, m512, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpw k1, zmm, m512, imm8","vpcmpw k1, zmm, m512, imm8 |  | ")]
        vpcmpw_k1_zmm_m512_imm8 = 2808,

        /// <summary>
        /// vpcmpw k1, zmm, r32, imm8 |  | 
        /// </summary>
        [Symbol("vpcmpw k1, zmm, r32, imm8","vpcmpw k1, zmm, r32, imm8 |  | ")]
        vpcmpw_k1_zmm_r32_imm8 = 2809,

        /// <summary>
        /// vpcompressd m128 {k1}{z}, xmm |  | 
        /// </summary>
        [Symbol("vpcompressd m128 {k1}{z}, xmm","vpcompressd m128 {k1}{z}, xmm |  | ")]
        vpcompressd_m128_k1z_xmm = 2810,

        /// <summary>
        /// vpcompressd m128, xmm |  | 
        /// </summary>
        [Symbol("vpcompressd m128, xmm","vpcompressd m128, xmm |  | ")]
        vpcompressd_m128_xmm = 2811,

        /// <summary>
        /// vpcompressd m256 {k1}{z}, ymm |  | 
        /// </summary>
        [Symbol("vpcompressd m256 {k1}{z}, ymm","vpcompressd m256 {k1}{z}, ymm |  | ")]
        vpcompressd_m256_k1z_ymm = 2812,

        /// <summary>
        /// vpcompressd m256, ymm |  | 
        /// </summary>
        [Symbol("vpcompressd m256, ymm","vpcompressd m256, ymm |  | ")]
        vpcompressd_m256_ymm = 2813,

        /// <summary>
        /// vpcompressd m512 {k1}{z}, zmm |  | 
        /// </summary>
        [Symbol("vpcompressd m512 {k1}{z}, zmm","vpcompressd m512 {k1}{z}, zmm |  | ")]
        vpcompressd_m512_k1z_zmm = 2814,

        /// <summary>
        /// vpcompressd m512, zmm |  | 
        /// </summary>
        [Symbol("vpcompressd m512, zmm","vpcompressd m512, zmm |  | ")]
        vpcompressd_m512_zmm = 2815,

        /// <summary>
        /// vpcompressd r16 {k1}{z}, ymm |  | 
        /// </summary>
        [Symbol("vpcompressd r16 {k1}{z}, ymm","vpcompressd r16 {k1}{z}, ymm |  | ")]
        vpcompressd_r16_k1z_ymm = 2816,

        /// <summary>
        /// vpcompressd r16, ymm |  | 
        /// </summary>
        [Symbol("vpcompressd r16, ymm","vpcompressd r16, ymm |  | ")]
        vpcompressd_r16_ymm = 2817,

        /// <summary>
        /// vpcompressd r32 {k1}{z}, zmm |  | 
        /// </summary>
        [Symbol("vpcompressd r32 {k1}{z}, zmm","vpcompressd r32 {k1}{z}, zmm |  | ")]
        vpcompressd_r32_k1z_zmm = 2818,

        /// <summary>
        /// vpcompressd r32, zmm |  | 
        /// </summary>
        [Symbol("vpcompressd r32, zmm","vpcompressd r32, zmm |  | ")]
        vpcompressd_r32_zmm = 2819,

        /// <summary>
        /// vpcompressd r8 {k1}{z}, xmm |  | 
        /// </summary>
        [Symbol("vpcompressd r8 {k1}{z}, xmm","vpcompressd r8 {k1}{z}, xmm |  | ")]
        vpcompressd_r8_k1z_xmm = 2820,

        /// <summary>
        /// vpcompressd r8, xmm |  | 
        /// </summary>
        [Symbol("vpcompressd r8, xmm","vpcompressd r8, xmm |  | ")]
        vpcompressd_r8_xmm = 2821,

        /// <summary>
        /// vpcompressq m128 {k1}{z}, xmm |  | 
        /// </summary>
        [Symbol("vpcompressq m128 {k1}{z}, xmm","vpcompressq m128 {k1}{z}, xmm |  | ")]
        vpcompressq_m128_k1z_xmm = 2822,

        /// <summary>
        /// vpcompressq m128, xmm |  | 
        /// </summary>
        [Symbol("vpcompressq m128, xmm","vpcompressq m128, xmm |  | ")]
        vpcompressq_m128_xmm = 2823,

        /// <summary>
        /// vpcompressq m256 {k1}{z}, ymm |  | 
        /// </summary>
        [Symbol("vpcompressq m256 {k1}{z}, ymm","vpcompressq m256 {k1}{z}, ymm |  | ")]
        vpcompressq_m256_k1z_ymm = 2824,

        /// <summary>
        /// vpcompressq m256, ymm |  | 
        /// </summary>
        [Symbol("vpcompressq m256, ymm","vpcompressq m256, ymm |  | ")]
        vpcompressq_m256_ymm = 2825,

        /// <summary>
        /// vpcompressq m512 {k1}{z}, zmm |  | 
        /// </summary>
        [Symbol("vpcompressq m512 {k1}{z}, zmm","vpcompressq m512 {k1}{z}, zmm |  | ")]
        vpcompressq_m512_k1z_zmm = 2826,

        /// <summary>
        /// vpcompressq m512, zmm |  | 
        /// </summary>
        [Symbol("vpcompressq m512, zmm","vpcompressq m512, zmm |  | ")]
        vpcompressq_m512_zmm = 2827,

        /// <summary>
        /// vpcompressq r16 {k1}{z}, ymm |  | 
        /// </summary>
        [Symbol("vpcompressq r16 {k1}{z}, ymm","vpcompressq r16 {k1}{z}, ymm |  | ")]
        vpcompressq_r16_k1z_ymm = 2828,

        /// <summary>
        /// vpcompressq r16, ymm |  | 
        /// </summary>
        [Symbol("vpcompressq r16, ymm","vpcompressq r16, ymm |  | ")]
        vpcompressq_r16_ymm = 2829,

        /// <summary>
        /// vpcompressq r32 {k1}{z}, zmm |  | 
        /// </summary>
        [Symbol("vpcompressq r32 {k1}{z}, zmm","vpcompressq r32 {k1}{z}, zmm |  | ")]
        vpcompressq_r32_k1z_zmm = 2830,

        /// <summary>
        /// vpcompressq r32, zmm |  | 
        /// </summary>
        [Symbol("vpcompressq r32, zmm","vpcompressq r32, zmm |  | ")]
        vpcompressq_r32_zmm = 2831,

        /// <summary>
        /// vpcompressq r8 {k1}{z}, xmm |  | 
        /// </summary>
        [Symbol("vpcompressq r8 {k1}{z}, xmm","vpcompressq r8 {k1}{z}, xmm |  | ")]
        vpcompressq_r8_k1z_xmm = 2832,

        /// <summary>
        /// vpcompressq r8, xmm |  | 
        /// </summary>
        [Symbol("vpcompressq r8, xmm","vpcompressq r8, xmm |  | ")]
        vpcompressq_r8_xmm = 2833,

        /// <summary>
        /// vpconflictd xmm {k1}{z}, m128 |  | 
        /// </summary>
        [Symbol("vpconflictd xmm {k1}{z}, m128","vpconflictd xmm {k1}{z}, m128 |  | ")]
        vpconflictd_xmm_k1z_m128 = 2834,

        /// <summary>
        /// vpconflictd xmm {k1}{z}, m32bcst |  | 
        /// </summary>
        [Symbol("vpconflictd xmm {k1}{z}, m32bcst","vpconflictd xmm {k1}{z}, m32bcst |  | ")]
        vpconflictd_xmm_k1z_m32bcst = 2835,

        /// <summary>
        /// vpconflictd xmm {k1}{z}, xmm |  | 
        /// </summary>
        [Symbol("vpconflictd xmm {k1}{z}, xmm","vpconflictd xmm {k1}{z}, xmm |  | ")]
        vpconflictd_xmm_k1z_xmm = 2836,

        /// <summary>
        /// vpconflictd xmm, m128 |  | 
        /// </summary>
        [Symbol("vpconflictd xmm, m128","vpconflictd xmm, m128 |  | ")]
        vpconflictd_xmm_m128 = 2837,

        /// <summary>
        /// vpconflictd xmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpconflictd xmm, m32bcst","vpconflictd xmm, m32bcst |  | ")]
        vpconflictd_xmm_m32bcst = 2838,

        /// <summary>
        /// vpconflictd xmm, xmm |  | 
        /// </summary>
        [Symbol("vpconflictd xmm, xmm","vpconflictd xmm, xmm |  | ")]
        vpconflictd_xmm_xmm = 2839,

        /// <summary>
        /// vpconflictd ymm {k1}{z}, m256 |  | 
        /// </summary>
        [Symbol("vpconflictd ymm {k1}{z}, m256","vpconflictd ymm {k1}{z}, m256 |  | ")]
        vpconflictd_ymm_k1z_m256 = 2840,

        /// <summary>
        /// vpconflictd ymm {k1}{z}, m32bcst |  | 
        /// </summary>
        [Symbol("vpconflictd ymm {k1}{z}, m32bcst","vpconflictd ymm {k1}{z}, m32bcst |  | ")]
        vpconflictd_ymm_k1z_m32bcst = 2841,

        /// <summary>
        /// vpconflictd ymm {k1}{z}, ymm |  | 
        /// </summary>
        [Symbol("vpconflictd ymm {k1}{z}, ymm","vpconflictd ymm {k1}{z}, ymm |  | ")]
        vpconflictd_ymm_k1z_ymm = 2842,

        /// <summary>
        /// vpconflictd ymm, m256 |  | 
        /// </summary>
        [Symbol("vpconflictd ymm, m256","vpconflictd ymm, m256 |  | ")]
        vpconflictd_ymm_m256 = 2843,

        /// <summary>
        /// vpconflictd ymm, m32bcst |  | 
        /// </summary>
        [Symbol("vpconflictd ymm, m32bcst","vpconflictd ymm, m32bcst |  | ")]
        vpconflictd_ymm_m32bcst = 2844,

        /// <summary>
        /// vpconflictd ymm, ymm |  | 
        /// </summary>
        [Symbol("vpconflictd ymm, ymm","vpconflictd ymm, ymm |  | ")]
        vpconflictd_ymm_ymm = 2845,

        /// <summary>
        /// vpconflictd zmm {k1}{z}, m32bcst |  | 
        /// </summary>
        [Symbol("vpconflictd zmm {k1}{z}, m32bcst","vpconflictd zmm {k1}{z}, m32bcst |  | ")]
        vpconflictd_zmm_k1z_m32bcst = 2846,

        /// <summary>
        /// vpconflictd zmm {k1}{z}, m512 |  | 
        /// </summary>
        [Symbol("vpconflictd zmm {k1}{z}, m512","vpconflictd zmm {k1}{z}, m512 |  | ")]
        vpconflictd_zmm_k1z_m512 = 2847,

        /// <summary>
        /// vpconflictd zmm {k1}{z}, zmm |  | 
        /// </summary>
        [Symbol("vpconflictd zmm {k1}{z}, zmm","vpconflictd zmm {k1}{z}, zmm |  | ")]
        vpconflictd_zmm_k1z_zmm = 2848,

        /// <summary>
        /// vpconflictd zmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpconflictd zmm, m32bcst","vpconflictd zmm, m32bcst |  | ")]
        vpconflictd_zmm_m32bcst = 2849,

        /// <summary>
        /// vpconflictd zmm, m512 |  | 
        /// </summary>
        [Symbol("vpconflictd zmm, m512","vpconflictd zmm, m512 |  | ")]
        vpconflictd_zmm_m512 = 2850,

        /// <summary>
        /// vpconflictd zmm, zmm |  | 
        /// </summary>
        [Symbol("vpconflictd zmm, zmm","vpconflictd zmm, zmm |  | ")]
        vpconflictd_zmm_zmm = 2851,

        /// <summary>
        /// vpconflictq xmm {k1}{z}, m128 |  | 
        /// </summary>
        [Symbol("vpconflictq xmm {k1}{z}, m128","vpconflictq xmm {k1}{z}, m128 |  | ")]
        vpconflictq_xmm_k1z_m128 = 2852,

        /// <summary>
        /// vpconflictq xmm {k1}{z}, m64bcst |  | 
        /// </summary>
        [Symbol("vpconflictq xmm {k1}{z}, m64bcst","vpconflictq xmm {k1}{z}, m64bcst |  | ")]
        vpconflictq_xmm_k1z_m64bcst = 2853,

        /// <summary>
        /// vpconflictq xmm {k1}{z}, xmm |  | 
        /// </summary>
        [Symbol("vpconflictq xmm {k1}{z}, xmm","vpconflictq xmm {k1}{z}, xmm |  | ")]
        vpconflictq_xmm_k1z_xmm = 2854,

        /// <summary>
        /// vpconflictq xmm, m128 |  | 
        /// </summary>
        [Symbol("vpconflictq xmm, m128","vpconflictq xmm, m128 |  | ")]
        vpconflictq_xmm_m128 = 2855,

        /// <summary>
        /// vpconflictq xmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpconflictq xmm, m64bcst","vpconflictq xmm, m64bcst |  | ")]
        vpconflictq_xmm_m64bcst = 2856,

        /// <summary>
        /// vpconflictq xmm, xmm |  | 
        /// </summary>
        [Symbol("vpconflictq xmm, xmm","vpconflictq xmm, xmm |  | ")]
        vpconflictq_xmm_xmm = 2857,

        /// <summary>
        /// vpconflictq ymm {k1}{z}, m256 |  | 
        /// </summary>
        [Symbol("vpconflictq ymm {k1}{z}, m256","vpconflictq ymm {k1}{z}, m256 |  | ")]
        vpconflictq_ymm_k1z_m256 = 2858,

        /// <summary>
        /// vpconflictq ymm {k1}{z}, m64bcst |  | 
        /// </summary>
        [Symbol("vpconflictq ymm {k1}{z}, m64bcst","vpconflictq ymm {k1}{z}, m64bcst |  | ")]
        vpconflictq_ymm_k1z_m64bcst = 2859,

        /// <summary>
        /// vpconflictq ymm {k1}{z}, ymm |  | 
        /// </summary>
        [Symbol("vpconflictq ymm {k1}{z}, ymm","vpconflictq ymm {k1}{z}, ymm |  | ")]
        vpconflictq_ymm_k1z_ymm = 2860,

        /// <summary>
        /// vpconflictq ymm, m256 |  | 
        /// </summary>
        [Symbol("vpconflictq ymm, m256","vpconflictq ymm, m256 |  | ")]
        vpconflictq_ymm_m256 = 2861,

        /// <summary>
        /// vpconflictq ymm, m64bcst |  | 
        /// </summary>
        [Symbol("vpconflictq ymm, m64bcst","vpconflictq ymm, m64bcst |  | ")]
        vpconflictq_ymm_m64bcst = 2862,

        /// <summary>
        /// vpconflictq ymm, ymm |  | 
        /// </summary>
        [Symbol("vpconflictq ymm, ymm","vpconflictq ymm, ymm |  | ")]
        vpconflictq_ymm_ymm = 2863,

        /// <summary>
        /// vpconflictq zmm {k1}{z}, m512 |  | 
        /// </summary>
        [Symbol("vpconflictq zmm {k1}{z}, m512","vpconflictq zmm {k1}{z}, m512 |  | ")]
        vpconflictq_zmm_k1z_m512 = 2864,

        /// <summary>
        /// vpconflictq zmm {k1}{z}, m64bcst |  | 
        /// </summary>
        [Symbol("vpconflictq zmm {k1}{z}, m64bcst","vpconflictq zmm {k1}{z}, m64bcst |  | ")]
        vpconflictq_zmm_k1z_m64bcst = 2865,

        /// <summary>
        /// vpconflictq zmm {k1}{z}, zmm |  | 
        /// </summary>
        [Symbol("vpconflictq zmm {k1}{z}, zmm","vpconflictq zmm {k1}{z}, zmm |  | ")]
        vpconflictq_zmm_k1z_zmm = 2866,

        /// <summary>
        /// vpconflictq zmm, m512 |  | 
        /// </summary>
        [Symbol("vpconflictq zmm, m512","vpconflictq zmm, m512 |  | ")]
        vpconflictq_zmm_m512 = 2867,

        /// <summary>
        /// vpconflictq zmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpconflictq zmm, m64bcst","vpconflictq zmm, m64bcst |  | ")]
        vpconflictq_zmm_m64bcst = 2868,

        /// <summary>
        /// vpconflictq zmm, zmm |  | 
        /// </summary>
        [Symbol("vpconflictq zmm, zmm","vpconflictq zmm, zmm |  | ")]
        vpconflictq_zmm_zmm = 2869,

        /// <summary>
        /// vperm2i128 ymm, ymm, m256, imm8 |  | 
        /// </summary>
        [Symbol("vperm2i128 ymm, ymm, m256, imm8","vperm2i128 ymm, ymm, m256, imm8 |  | ")]
        vperm2i128_ymm_ymm_m256_imm8 = 2870,

        /// <summary>
        /// vperm2i128 ymm, ymm, r16, imm8 |  | 
        /// </summary>
        [Symbol("vperm2i128 ymm, ymm, r16, imm8","vperm2i128 ymm, ymm, r16, imm8 |  | ")]
        vperm2i128_ymm_ymm_r16_imm8 = 2871,

        /// <summary>
        /// vpermb xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpermb xmm {k1}{z}, xmm, m128","vpermb xmm {k1}{z}, xmm, m128 |  | ")]
        vpermb_xmm_k1z_xmm_m128 = 2872,

        /// <summary>
        /// vpermb xmm {k1}{z}, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpermb xmm {k1}{z}, xmm, r8","vpermb xmm {k1}{z}, xmm, r8 |  | ")]
        vpermb_xmm_k1z_xmm_r8 = 2873,

        /// <summary>
        /// vpermb xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpermb xmm, xmm, m128","vpermb xmm, xmm, m128 |  | ")]
        vpermb_xmm_xmm_m128 = 2874,

        /// <summary>
        /// vpermb xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpermb xmm, xmm, r8","vpermb xmm, xmm, r8 |  | ")]
        vpermb_xmm_xmm_r8 = 2875,

        /// <summary>
        /// vpermb ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpermb ymm {k1}{z}, ymm, m256","vpermb ymm {k1}{z}, ymm, m256 |  | ")]
        vpermb_ymm_k1z_ymm_m256 = 2876,

        /// <summary>
        /// vpermb ymm {k1}{z}, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpermb ymm {k1}{z}, ymm, r16","vpermb ymm {k1}{z}, ymm, r16 |  | ")]
        vpermb_ymm_k1z_ymm_r16 = 2877,

        /// <summary>
        /// vpermb ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpermb ymm, ymm, m256","vpermb ymm, ymm, m256 |  | ")]
        vpermb_ymm_ymm_m256 = 2878,

        /// <summary>
        /// vpermb ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpermb ymm, ymm, r16","vpermb ymm, ymm, r16 |  | ")]
        vpermb_ymm_ymm_r16 = 2879,

        /// <summary>
        /// vpermb zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpermb zmm {k1}{z}, zmm, m512","vpermb zmm {k1}{z}, zmm, m512 |  | ")]
        vpermb_zmm_k1z_zmm_m512 = 2880,

        /// <summary>
        /// vpermb zmm {k1}{z}, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpermb zmm {k1}{z}, zmm, r32","vpermb zmm {k1}{z}, zmm, r32 |  | ")]
        vpermb_zmm_k1z_zmm_r32 = 2881,

        /// <summary>
        /// vpermb zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpermb zmm, zmm, m512","vpermb zmm, zmm, m512 |  | ")]
        vpermb_zmm_zmm_m512 = 2882,

        /// <summary>
        /// vpermb zmm, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpermb zmm, zmm, r32","vpermb zmm, zmm, r32 |  | ")]
        vpermb_zmm_zmm_r32 = 2883,

        /// <summary>
        /// vpermd ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpermd ymm {k1}{z}, ymm, m256","vpermd ymm {k1}{z}, ymm, m256 |  | ")]
        vpermd_ymm_k1z_ymm_m256 = 2884,

        /// <summary>
        /// vpermd ymm {k1}{z}, ymm, m32bcst |  | 
        /// </summary>
        [Symbol("vpermd ymm {k1}{z}, ymm, m32bcst","vpermd ymm {k1}{z}, ymm, m32bcst |  | ")]
        vpermd_ymm_k1z_ymm_m32bcst = 2885,

        /// <summary>
        /// vpermd ymm {k1}{z}, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpermd ymm {k1}{z}, ymm, ymm","vpermd ymm {k1}{z}, ymm, ymm |  | ")]
        vpermd_ymm_k1z_ymm_ymm = 2886,

        /// <summary>
        /// vpermd ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpermd ymm, ymm, m256","vpermd ymm, ymm, m256 |  | ")]
        vpermd_ymm_ymm_m256 = 2887,

        /// <summary>
        /// vpermd ymm, ymm, m32bcst |  | 
        /// </summary>
        [Symbol("vpermd ymm, ymm, m32bcst","vpermd ymm, ymm, m32bcst |  | ")]
        vpermd_ymm_ymm_m32bcst = 2888,

        /// <summary>
        /// vpermd ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpermd ymm, ymm, r16","vpermd ymm, ymm, r16 |  | ")]
        vpermd_ymm_ymm_r16 = 2889,

        /// <summary>
        /// vpermd ymm, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpermd ymm, ymm, ymm","vpermd ymm, ymm, ymm |  | ")]
        vpermd_ymm_ymm_ymm = 2890,

        /// <summary>
        /// vpermd zmm {k1}{z}, zmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpermd zmm {k1}{z}, zmm, m32bcst","vpermd zmm {k1}{z}, zmm, m32bcst |  | ")]
        vpermd_zmm_k1z_zmm_m32bcst = 2891,

        /// <summary>
        /// vpermd zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpermd zmm {k1}{z}, zmm, m512","vpermd zmm {k1}{z}, zmm, m512 |  | ")]
        vpermd_zmm_k1z_zmm_m512 = 2892,

        /// <summary>
        /// vpermd zmm {k1}{z}, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpermd zmm {k1}{z}, zmm, zmm","vpermd zmm {k1}{z}, zmm, zmm |  | ")]
        vpermd_zmm_k1z_zmm_zmm = 2893,

        /// <summary>
        /// vpermd zmm, zmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpermd zmm, zmm, m32bcst","vpermd zmm, zmm, m32bcst |  | ")]
        vpermd_zmm_zmm_m32bcst = 2894,

        /// <summary>
        /// vpermd zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpermd zmm, zmm, m512","vpermd zmm, zmm, m512 |  | ")]
        vpermd_zmm_zmm_m512 = 2895,

        /// <summary>
        /// vpermd zmm, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpermd zmm, zmm, zmm","vpermd zmm, zmm, zmm |  | ")]
        vpermd_zmm_zmm_zmm = 2896,

        /// <summary>
        /// vpermi2d xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpermi2d xmm {k1}{z}, xmm, m128","vpermi2d xmm {k1}{z}, xmm, m128 |  | ")]
        vpermi2d_xmm_k1z_xmm_m128 = 2897,

        /// <summary>
        /// vpermi2d xmm {k1}{z}, xmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpermi2d xmm {k1}{z}, xmm, m32bcst","vpermi2d xmm {k1}{z}, xmm, m32bcst |  | ")]
        vpermi2d_xmm_k1z_xmm_m32bcst = 2898,

        /// <summary>
        /// vpermi2d xmm {k1}{z}, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpermi2d xmm {k1}{z}, xmm, xmm","vpermi2d xmm {k1}{z}, xmm, xmm |  | ")]
        vpermi2d_xmm_k1z_xmm_xmm = 2899,

        /// <summary>
        /// vpermi2d xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpermi2d xmm, xmm, m128","vpermi2d xmm, xmm, m128 |  | ")]
        vpermi2d_xmm_xmm_m128 = 2900,

        /// <summary>
        /// vpermi2d xmm, xmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpermi2d xmm, xmm, m32bcst","vpermi2d xmm, xmm, m32bcst |  | ")]
        vpermi2d_xmm_xmm_m32bcst = 2901,

        /// <summary>
        /// vpermi2d xmm, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpermi2d xmm, xmm, xmm","vpermi2d xmm, xmm, xmm |  | ")]
        vpermi2d_xmm_xmm_xmm = 2902,

        /// <summary>
        /// vpermi2d ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpermi2d ymm {k1}{z}, ymm, m256","vpermi2d ymm {k1}{z}, ymm, m256 |  | ")]
        vpermi2d_ymm_k1z_ymm_m256 = 2903,

        /// <summary>
        /// vpermi2d ymm {k1}{z}, ymm, m32bcst |  | 
        /// </summary>
        [Symbol("vpermi2d ymm {k1}{z}, ymm, m32bcst","vpermi2d ymm {k1}{z}, ymm, m32bcst |  | ")]
        vpermi2d_ymm_k1z_ymm_m32bcst = 2904,

        /// <summary>
        /// vpermi2d ymm {k1}{z}, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpermi2d ymm {k1}{z}, ymm, ymm","vpermi2d ymm {k1}{z}, ymm, ymm |  | ")]
        vpermi2d_ymm_k1z_ymm_ymm = 2905,

        /// <summary>
        /// vpermi2d ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpermi2d ymm, ymm, m256","vpermi2d ymm, ymm, m256 |  | ")]
        vpermi2d_ymm_ymm_m256 = 2906,

        /// <summary>
        /// vpermi2d ymm, ymm, m32bcst |  | 
        /// </summary>
        [Symbol("vpermi2d ymm, ymm, m32bcst","vpermi2d ymm, ymm, m32bcst |  | ")]
        vpermi2d_ymm_ymm_m32bcst = 2907,

        /// <summary>
        /// vpermi2d ymm, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpermi2d ymm, ymm, ymm","vpermi2d ymm, ymm, ymm |  | ")]
        vpermi2d_ymm_ymm_ymm = 2908,

        /// <summary>
        /// vpermi2d zmm {k1}{z}, zmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpermi2d zmm {k1}{z}, zmm, m32bcst","vpermi2d zmm {k1}{z}, zmm, m32bcst |  | ")]
        vpermi2d_zmm_k1z_zmm_m32bcst = 2909,

        /// <summary>
        /// vpermi2d zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpermi2d zmm {k1}{z}, zmm, m512","vpermi2d zmm {k1}{z}, zmm, m512 |  | ")]
        vpermi2d_zmm_k1z_zmm_m512 = 2910,

        /// <summary>
        /// vpermi2d zmm {k1}{z}, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpermi2d zmm {k1}{z}, zmm, zmm","vpermi2d zmm {k1}{z}, zmm, zmm |  | ")]
        vpermi2d_zmm_k1z_zmm_zmm = 2911,

        /// <summary>
        /// vpermi2d zmm, zmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpermi2d zmm, zmm, m32bcst","vpermi2d zmm, zmm, m32bcst |  | ")]
        vpermi2d_zmm_zmm_m32bcst = 2912,

        /// <summary>
        /// vpermi2d zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpermi2d zmm, zmm, m512","vpermi2d zmm, zmm, m512 |  | ")]
        vpermi2d_zmm_zmm_m512 = 2913,

        /// <summary>
        /// vpermi2d zmm, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpermi2d zmm, zmm, zmm","vpermi2d zmm, zmm, zmm |  | ")]
        vpermi2d_zmm_zmm_zmm = 2914,

        /// <summary>
        /// vpermi2pd xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpermi2pd xmm {k1}{z}, xmm, m128","vpermi2pd xmm {k1}{z}, xmm, m128 |  | ")]
        vpermi2pd_xmm_k1z_xmm_m128 = 2915,

        /// <summary>
        /// vpermi2pd xmm {k1}{z}, xmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpermi2pd xmm {k1}{z}, xmm, m64bcst","vpermi2pd xmm {k1}{z}, xmm, m64bcst |  | ")]
        vpermi2pd_xmm_k1z_xmm_m64bcst = 2916,

        /// <summary>
        /// vpermi2pd xmm {k1}{z}, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpermi2pd xmm {k1}{z}, xmm, xmm","vpermi2pd xmm {k1}{z}, xmm, xmm |  | ")]
        vpermi2pd_xmm_k1z_xmm_xmm = 2917,

        /// <summary>
        /// vpermi2pd xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpermi2pd xmm, xmm, m128","vpermi2pd xmm, xmm, m128 |  | ")]
        vpermi2pd_xmm_xmm_m128 = 2918,

        /// <summary>
        /// vpermi2pd xmm, xmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpermi2pd xmm, xmm, m64bcst","vpermi2pd xmm, xmm, m64bcst |  | ")]
        vpermi2pd_xmm_xmm_m64bcst = 2919,

        /// <summary>
        /// vpermi2pd xmm, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpermi2pd xmm, xmm, xmm","vpermi2pd xmm, xmm, xmm |  | ")]
        vpermi2pd_xmm_xmm_xmm = 2920,

        /// <summary>
        /// vpermi2pd ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpermi2pd ymm {k1}{z}, ymm, m256","vpermi2pd ymm {k1}{z}, ymm, m256 |  | ")]
        vpermi2pd_ymm_k1z_ymm_m256 = 2921,

        /// <summary>
        /// vpermi2pd ymm {k1}{z}, ymm, m64bcst |  | 
        /// </summary>
        [Symbol("vpermi2pd ymm {k1}{z}, ymm, m64bcst","vpermi2pd ymm {k1}{z}, ymm, m64bcst |  | ")]
        vpermi2pd_ymm_k1z_ymm_m64bcst = 2922,

        /// <summary>
        /// vpermi2pd ymm {k1}{z}, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpermi2pd ymm {k1}{z}, ymm, ymm","vpermi2pd ymm {k1}{z}, ymm, ymm |  | ")]
        vpermi2pd_ymm_k1z_ymm_ymm = 2923,

        /// <summary>
        /// vpermi2pd ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpermi2pd ymm, ymm, m256","vpermi2pd ymm, ymm, m256 |  | ")]
        vpermi2pd_ymm_ymm_m256 = 2924,

        /// <summary>
        /// vpermi2pd ymm, ymm, m64bcst |  | 
        /// </summary>
        [Symbol("vpermi2pd ymm, ymm, m64bcst","vpermi2pd ymm, ymm, m64bcst |  | ")]
        vpermi2pd_ymm_ymm_m64bcst = 2925,

        /// <summary>
        /// vpermi2pd ymm, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpermi2pd ymm, ymm, ymm","vpermi2pd ymm, ymm, ymm |  | ")]
        vpermi2pd_ymm_ymm_ymm = 2926,

        /// <summary>
        /// vpermi2pd zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpermi2pd zmm {k1}{z}, zmm, m512","vpermi2pd zmm {k1}{z}, zmm, m512 |  | ")]
        vpermi2pd_zmm_k1z_zmm_m512 = 2927,

        /// <summary>
        /// vpermi2pd zmm {k1}{z}, zmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpermi2pd zmm {k1}{z}, zmm, m64bcst","vpermi2pd zmm {k1}{z}, zmm, m64bcst |  | ")]
        vpermi2pd_zmm_k1z_zmm_m64bcst = 2928,

        /// <summary>
        /// vpermi2pd zmm {k1}{z}, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpermi2pd zmm {k1}{z}, zmm, zmm","vpermi2pd zmm {k1}{z}, zmm, zmm |  | ")]
        vpermi2pd_zmm_k1z_zmm_zmm = 2929,

        /// <summary>
        /// vpermi2pd zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpermi2pd zmm, zmm, m512","vpermi2pd zmm, zmm, m512 |  | ")]
        vpermi2pd_zmm_zmm_m512 = 2930,

        /// <summary>
        /// vpermi2pd zmm, zmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpermi2pd zmm, zmm, m64bcst","vpermi2pd zmm, zmm, m64bcst |  | ")]
        vpermi2pd_zmm_zmm_m64bcst = 2931,

        /// <summary>
        /// vpermi2pd zmm, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpermi2pd zmm, zmm, zmm","vpermi2pd zmm, zmm, zmm |  | ")]
        vpermi2pd_zmm_zmm_zmm = 2932,

        /// <summary>
        /// vpermi2ps xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpermi2ps xmm {k1}{z}, xmm, m128","vpermi2ps xmm {k1}{z}, xmm, m128 |  | ")]
        vpermi2ps_xmm_k1z_xmm_m128 = 2933,

        /// <summary>
        /// vpermi2ps xmm {k1}{z}, xmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpermi2ps xmm {k1}{z}, xmm, m32bcst","vpermi2ps xmm {k1}{z}, xmm, m32bcst |  | ")]
        vpermi2ps_xmm_k1z_xmm_m32bcst = 2934,

        /// <summary>
        /// vpermi2ps xmm {k1}{z}, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpermi2ps xmm {k1}{z}, xmm, xmm","vpermi2ps xmm {k1}{z}, xmm, xmm |  | ")]
        vpermi2ps_xmm_k1z_xmm_xmm = 2935,

        /// <summary>
        /// vpermi2ps xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpermi2ps xmm, xmm, m128","vpermi2ps xmm, xmm, m128 |  | ")]
        vpermi2ps_xmm_xmm_m128 = 2936,

        /// <summary>
        /// vpermi2ps xmm, xmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpermi2ps xmm, xmm, m32bcst","vpermi2ps xmm, xmm, m32bcst |  | ")]
        vpermi2ps_xmm_xmm_m32bcst = 2937,

        /// <summary>
        /// vpermi2ps xmm, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpermi2ps xmm, xmm, xmm","vpermi2ps xmm, xmm, xmm |  | ")]
        vpermi2ps_xmm_xmm_xmm = 2938,

        /// <summary>
        /// vpermi2ps ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpermi2ps ymm {k1}{z}, ymm, m256","vpermi2ps ymm {k1}{z}, ymm, m256 |  | ")]
        vpermi2ps_ymm_k1z_ymm_m256 = 2939,

        /// <summary>
        /// vpermi2ps ymm {k1}{z}, ymm, m32bcst |  | 
        /// </summary>
        [Symbol("vpermi2ps ymm {k1}{z}, ymm, m32bcst","vpermi2ps ymm {k1}{z}, ymm, m32bcst |  | ")]
        vpermi2ps_ymm_k1z_ymm_m32bcst = 2940,

        /// <summary>
        /// vpermi2ps ymm {k1}{z}, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpermi2ps ymm {k1}{z}, ymm, ymm","vpermi2ps ymm {k1}{z}, ymm, ymm |  | ")]
        vpermi2ps_ymm_k1z_ymm_ymm = 2941,

        /// <summary>
        /// vpermi2ps ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpermi2ps ymm, ymm, m256","vpermi2ps ymm, ymm, m256 |  | ")]
        vpermi2ps_ymm_ymm_m256 = 2942,

        /// <summary>
        /// vpermi2ps ymm, ymm, m32bcst |  | 
        /// </summary>
        [Symbol("vpermi2ps ymm, ymm, m32bcst","vpermi2ps ymm, ymm, m32bcst |  | ")]
        vpermi2ps_ymm_ymm_m32bcst = 2943,

        /// <summary>
        /// vpermi2ps ymm, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpermi2ps ymm, ymm, ymm","vpermi2ps ymm, ymm, ymm |  | ")]
        vpermi2ps_ymm_ymm_ymm = 2944,

        /// <summary>
        /// vpermi2ps zmm {k1}{z}, zmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpermi2ps zmm {k1}{z}, zmm, m32bcst","vpermi2ps zmm {k1}{z}, zmm, m32bcst |  | ")]
        vpermi2ps_zmm_k1z_zmm_m32bcst = 2945,

        /// <summary>
        /// vpermi2ps zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpermi2ps zmm {k1}{z}, zmm, m512","vpermi2ps zmm {k1}{z}, zmm, m512 |  | ")]
        vpermi2ps_zmm_k1z_zmm_m512 = 2946,

        /// <summary>
        /// vpermi2ps zmm {k1}{z}, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpermi2ps zmm {k1}{z}, zmm, zmm","vpermi2ps zmm {k1}{z}, zmm, zmm |  | ")]
        vpermi2ps_zmm_k1z_zmm_zmm = 2947,

        /// <summary>
        /// vpermi2ps zmm, zmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpermi2ps zmm, zmm, m32bcst","vpermi2ps zmm, zmm, m32bcst |  | ")]
        vpermi2ps_zmm_zmm_m32bcst = 2948,

        /// <summary>
        /// vpermi2ps zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpermi2ps zmm, zmm, m512","vpermi2ps zmm, zmm, m512 |  | ")]
        vpermi2ps_zmm_zmm_m512 = 2949,

        /// <summary>
        /// vpermi2ps zmm, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpermi2ps zmm, zmm, zmm","vpermi2ps zmm, zmm, zmm |  | ")]
        vpermi2ps_zmm_zmm_zmm = 2950,

        /// <summary>
        /// vpermi2q xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpermi2q xmm {k1}{z}, xmm, m128","vpermi2q xmm {k1}{z}, xmm, m128 |  | ")]
        vpermi2q_xmm_k1z_xmm_m128 = 2951,

        /// <summary>
        /// vpermi2q xmm {k1}{z}, xmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpermi2q xmm {k1}{z}, xmm, m64bcst","vpermi2q xmm {k1}{z}, xmm, m64bcst |  | ")]
        vpermi2q_xmm_k1z_xmm_m64bcst = 2952,

        /// <summary>
        /// vpermi2q xmm {k1}{z}, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpermi2q xmm {k1}{z}, xmm, xmm","vpermi2q xmm {k1}{z}, xmm, xmm |  | ")]
        vpermi2q_xmm_k1z_xmm_xmm = 2953,

        /// <summary>
        /// vpermi2q xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpermi2q xmm, xmm, m128","vpermi2q xmm, xmm, m128 |  | ")]
        vpermi2q_xmm_xmm_m128 = 2954,

        /// <summary>
        /// vpermi2q xmm, xmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpermi2q xmm, xmm, m64bcst","vpermi2q xmm, xmm, m64bcst |  | ")]
        vpermi2q_xmm_xmm_m64bcst = 2955,

        /// <summary>
        /// vpermi2q xmm, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpermi2q xmm, xmm, xmm","vpermi2q xmm, xmm, xmm |  | ")]
        vpermi2q_xmm_xmm_xmm = 2956,

        /// <summary>
        /// vpermi2q ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpermi2q ymm {k1}{z}, ymm, m256","vpermi2q ymm {k1}{z}, ymm, m256 |  | ")]
        vpermi2q_ymm_k1z_ymm_m256 = 2957,

        /// <summary>
        /// vpermi2q ymm {k1}{z}, ymm, m64bcst |  | 
        /// </summary>
        [Symbol("vpermi2q ymm {k1}{z}, ymm, m64bcst","vpermi2q ymm {k1}{z}, ymm, m64bcst |  | ")]
        vpermi2q_ymm_k1z_ymm_m64bcst = 2958,

        /// <summary>
        /// vpermi2q ymm {k1}{z}, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpermi2q ymm {k1}{z}, ymm, ymm","vpermi2q ymm {k1}{z}, ymm, ymm |  | ")]
        vpermi2q_ymm_k1z_ymm_ymm = 2959,

        /// <summary>
        /// vpermi2q ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpermi2q ymm, ymm, m256","vpermi2q ymm, ymm, m256 |  | ")]
        vpermi2q_ymm_ymm_m256 = 2960,

        /// <summary>
        /// vpermi2q ymm, ymm, m64bcst |  | 
        /// </summary>
        [Symbol("vpermi2q ymm, ymm, m64bcst","vpermi2q ymm, ymm, m64bcst |  | ")]
        vpermi2q_ymm_ymm_m64bcst = 2961,

        /// <summary>
        /// vpermi2q ymm, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpermi2q ymm, ymm, ymm","vpermi2q ymm, ymm, ymm |  | ")]
        vpermi2q_ymm_ymm_ymm = 2962,

        /// <summary>
        /// vpermi2q zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpermi2q zmm {k1}{z}, zmm, m512","vpermi2q zmm {k1}{z}, zmm, m512 |  | ")]
        vpermi2q_zmm_k1z_zmm_m512 = 2963,

        /// <summary>
        /// vpermi2q zmm {k1}{z}, zmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpermi2q zmm {k1}{z}, zmm, m64bcst","vpermi2q zmm {k1}{z}, zmm, m64bcst |  | ")]
        vpermi2q_zmm_k1z_zmm_m64bcst = 2964,

        /// <summary>
        /// vpermi2q zmm {k1}{z}, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpermi2q zmm {k1}{z}, zmm, zmm","vpermi2q zmm {k1}{z}, zmm, zmm |  | ")]
        vpermi2q_zmm_k1z_zmm_zmm = 2965,

        /// <summary>
        /// vpermi2q zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpermi2q zmm, zmm, m512","vpermi2q zmm, zmm, m512 |  | ")]
        vpermi2q_zmm_zmm_m512 = 2966,

        /// <summary>
        /// vpermi2q zmm, zmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpermi2q zmm, zmm, m64bcst","vpermi2q zmm, zmm, m64bcst |  | ")]
        vpermi2q_zmm_zmm_m64bcst = 2967,

        /// <summary>
        /// vpermi2q zmm, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpermi2q zmm, zmm, zmm","vpermi2q zmm, zmm, zmm |  | ")]
        vpermi2q_zmm_zmm_zmm = 2968,

        /// <summary>
        /// vpermi2w xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpermi2w xmm {k1}{z}, xmm, m128","vpermi2w xmm {k1}{z}, xmm, m128 |  | ")]
        vpermi2w_xmm_k1z_xmm_m128 = 2969,

        /// <summary>
        /// vpermi2w xmm {k1}{z}, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpermi2w xmm {k1}{z}, xmm, r8","vpermi2w xmm {k1}{z}, xmm, r8 |  | ")]
        vpermi2w_xmm_k1z_xmm_r8 = 2970,

        /// <summary>
        /// vpermi2w xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpermi2w xmm, xmm, m128","vpermi2w xmm, xmm, m128 |  | ")]
        vpermi2w_xmm_xmm_m128 = 2971,

        /// <summary>
        /// vpermi2w xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpermi2w xmm, xmm, r8","vpermi2w xmm, xmm, r8 |  | ")]
        vpermi2w_xmm_xmm_r8 = 2972,

        /// <summary>
        /// vpermi2w ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpermi2w ymm {k1}{z}, ymm, m256","vpermi2w ymm {k1}{z}, ymm, m256 |  | ")]
        vpermi2w_ymm_k1z_ymm_m256 = 2973,

        /// <summary>
        /// vpermi2w ymm {k1}{z}, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpermi2w ymm {k1}{z}, ymm, r16","vpermi2w ymm {k1}{z}, ymm, r16 |  | ")]
        vpermi2w_ymm_k1z_ymm_r16 = 2974,

        /// <summary>
        /// vpermi2w ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpermi2w ymm, ymm, m256","vpermi2w ymm, ymm, m256 |  | ")]
        vpermi2w_ymm_ymm_m256 = 2975,

        /// <summary>
        /// vpermi2w ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpermi2w ymm, ymm, r16","vpermi2w ymm, ymm, r16 |  | ")]
        vpermi2w_ymm_ymm_r16 = 2976,

        /// <summary>
        /// vpermi2w zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpermi2w zmm {k1}{z}, zmm, m512","vpermi2w zmm {k1}{z}, zmm, m512 |  | ")]
        vpermi2w_zmm_k1z_zmm_m512 = 2977,

        /// <summary>
        /// vpermi2w zmm {k1}{z}, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpermi2w zmm {k1}{z}, zmm, r32","vpermi2w zmm {k1}{z}, zmm, r32 |  | ")]
        vpermi2w_zmm_k1z_zmm_r32 = 2978,

        /// <summary>
        /// vpermi2w zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpermi2w zmm, zmm, m512","vpermi2w zmm, zmm, m512 |  | ")]
        vpermi2w_zmm_zmm_m512 = 2979,

        /// <summary>
        /// vpermi2w zmm, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpermi2w zmm, zmm, r32","vpermi2w zmm, zmm, r32 |  | ")]
        vpermi2w_zmm_zmm_r32 = 2980,

        /// <summary>
        /// vpermq ymm {k1}{z}, m256, imm8 |  | 
        /// </summary>
        [Symbol("vpermq ymm {k1}{z}, m256, imm8","vpermq ymm {k1}{z}, m256, imm8 |  | ")]
        vpermq_ymm_k1z_m256_imm8 = 2981,

        /// <summary>
        /// vpermq ymm {k1}{z}, m64bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpermq ymm {k1}{z}, m64bcst, imm8","vpermq ymm {k1}{z}, m64bcst, imm8 |  | ")]
        vpermq_ymm_k1z_m64bcst_imm8 = 2982,

        /// <summary>
        /// vpermq ymm {k1}{z}, ymm, imm8 |  | 
        /// </summary>
        [Symbol("vpermq ymm {k1}{z}, ymm, imm8","vpermq ymm {k1}{z}, ymm, imm8 |  | ")]
        vpermq_ymm_k1z_ymm_imm8 = 2983,

        /// <summary>
        /// vpermq ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpermq ymm {k1}{z}, ymm, m256","vpermq ymm {k1}{z}, ymm, m256 |  | ")]
        vpermq_ymm_k1z_ymm_m256 = 2984,

        /// <summary>
        /// vpermq ymm {k1}{z}, ymm, m64bcst |  | 
        /// </summary>
        [Symbol("vpermq ymm {k1}{z}, ymm, m64bcst","vpermq ymm {k1}{z}, ymm, m64bcst |  | ")]
        vpermq_ymm_k1z_ymm_m64bcst = 2985,

        /// <summary>
        /// vpermq ymm {k1}{z}, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpermq ymm {k1}{z}, ymm, ymm","vpermq ymm {k1}{z}, ymm, ymm |  | ")]
        vpermq_ymm_k1z_ymm_ymm = 2986,

        /// <summary>
        /// vpermq ymm, m256, imm8 |  | 
        /// </summary>
        [Symbol("vpermq ymm, m256, imm8","vpermq ymm, m256, imm8 |  | ")]
        vpermq_ymm_m256_imm8 = 2987,

        /// <summary>
        /// vpermq ymm, m64bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpermq ymm, m64bcst, imm8","vpermq ymm, m64bcst, imm8 |  | ")]
        vpermq_ymm_m64bcst_imm8 = 2988,

        /// <summary>
        /// vpermq ymm, r16, imm8 |  | 
        /// </summary>
        [Symbol("vpermq ymm, r16, imm8","vpermq ymm, r16, imm8 |  | ")]
        vpermq_ymm_r16_imm8 = 2989,

        /// <summary>
        /// vpermq ymm, ymm, imm8 |  | 
        /// </summary>
        [Symbol("vpermq ymm, ymm, imm8","vpermq ymm, ymm, imm8 |  | ")]
        vpermq_ymm_ymm_imm8 = 2990,

        /// <summary>
        /// vpermq ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpermq ymm, ymm, m256","vpermq ymm, ymm, m256 |  | ")]
        vpermq_ymm_ymm_m256 = 2991,

        /// <summary>
        /// vpermq ymm, ymm, m64bcst |  | 
        /// </summary>
        [Symbol("vpermq ymm, ymm, m64bcst","vpermq ymm, ymm, m64bcst |  | ")]
        vpermq_ymm_ymm_m64bcst = 2992,

        /// <summary>
        /// vpermq ymm, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpermq ymm, ymm, ymm","vpermq ymm, ymm, ymm |  | ")]
        vpermq_ymm_ymm_ymm = 2993,

        /// <summary>
        /// vpermq zmm {k1}{z}, m512, imm8 |  | 
        /// </summary>
        [Symbol("vpermq zmm {k1}{z}, m512, imm8","vpermq zmm {k1}{z}, m512, imm8 |  | ")]
        vpermq_zmm_k1z_m512_imm8 = 2994,

        /// <summary>
        /// vpermq zmm {k1}{z}, m64bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpermq zmm {k1}{z}, m64bcst, imm8","vpermq zmm {k1}{z}, m64bcst, imm8 |  | ")]
        vpermq_zmm_k1z_m64bcst_imm8 = 2995,

        /// <summary>
        /// vpermq zmm {k1}{z}, zmm, imm8 |  | 
        /// </summary>
        [Symbol("vpermq zmm {k1}{z}, zmm, imm8","vpermq zmm {k1}{z}, zmm, imm8 |  | ")]
        vpermq_zmm_k1z_zmm_imm8 = 2996,

        /// <summary>
        /// vpermq zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpermq zmm {k1}{z}, zmm, m512","vpermq zmm {k1}{z}, zmm, m512 |  | ")]
        vpermq_zmm_k1z_zmm_m512 = 2997,

        /// <summary>
        /// vpermq zmm {k1}{z}, zmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpermq zmm {k1}{z}, zmm, m64bcst","vpermq zmm {k1}{z}, zmm, m64bcst |  | ")]
        vpermq_zmm_k1z_zmm_m64bcst = 2998,

        /// <summary>
        /// vpermq zmm {k1}{z}, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpermq zmm {k1}{z}, zmm, zmm","vpermq zmm {k1}{z}, zmm, zmm |  | ")]
        vpermq_zmm_k1z_zmm_zmm = 2999,

        /// <summary>
        /// vpermq zmm, m512, imm8 |  | 
        /// </summary>
        [Symbol("vpermq zmm, m512, imm8","vpermq zmm, m512, imm8 |  | ")]
        vpermq_zmm_m512_imm8 = 3000,

        /// <summary>
        /// vpermq zmm, m64bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpermq zmm, m64bcst, imm8","vpermq zmm, m64bcst, imm8 |  | ")]
        vpermq_zmm_m64bcst_imm8 = 3001,

        /// <summary>
        /// vpermq zmm, zmm, imm8 |  | 
        /// </summary>
        [Symbol("vpermq zmm, zmm, imm8","vpermq zmm, zmm, imm8 |  | ")]
        vpermq_zmm_zmm_imm8 = 3002,

        /// <summary>
        /// vpermq zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpermq zmm, zmm, m512","vpermq zmm, zmm, m512 |  | ")]
        vpermq_zmm_zmm_m512 = 3003,

        /// <summary>
        /// vpermq zmm, zmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpermq zmm, zmm, m64bcst","vpermq zmm, zmm, m64bcst |  | ")]
        vpermq_zmm_zmm_m64bcst = 3004,

        /// <summary>
        /// vpermq zmm, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpermq zmm, zmm, zmm","vpermq zmm, zmm, zmm |  | ")]
        vpermq_zmm_zmm_zmm = 3005,

        /// <summary>
        /// vpermt2b xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpermt2b xmm {k1}{z}, xmm, m128","vpermt2b xmm {k1}{z}, xmm, m128 |  | ")]
        vpermt2b_xmm_k1z_xmm_m128 = 3006,

        /// <summary>
        /// vpermt2b xmm {k1}{z}, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpermt2b xmm {k1}{z}, xmm, r8","vpermt2b xmm {k1}{z}, xmm, r8 |  | ")]
        vpermt2b_xmm_k1z_xmm_r8 = 3007,

        /// <summary>
        /// vpermt2b xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpermt2b xmm, xmm, m128","vpermt2b xmm, xmm, m128 |  | ")]
        vpermt2b_xmm_xmm_m128 = 3008,

        /// <summary>
        /// vpermt2b xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpermt2b xmm, xmm, r8","vpermt2b xmm, xmm, r8 |  | ")]
        vpermt2b_xmm_xmm_r8 = 3009,

        /// <summary>
        /// vpermt2b ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpermt2b ymm {k1}{z}, ymm, m256","vpermt2b ymm {k1}{z}, ymm, m256 |  | ")]
        vpermt2b_ymm_k1z_ymm_m256 = 3010,

        /// <summary>
        /// vpermt2b ymm {k1}{z}, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpermt2b ymm {k1}{z}, ymm, r16","vpermt2b ymm {k1}{z}, ymm, r16 |  | ")]
        vpermt2b_ymm_k1z_ymm_r16 = 3011,

        /// <summary>
        /// vpermt2b ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpermt2b ymm, ymm, m256","vpermt2b ymm, ymm, m256 |  | ")]
        vpermt2b_ymm_ymm_m256 = 3012,

        /// <summary>
        /// vpermt2b ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpermt2b ymm, ymm, r16","vpermt2b ymm, ymm, r16 |  | ")]
        vpermt2b_ymm_ymm_r16 = 3013,

        /// <summary>
        /// vpermt2b zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpermt2b zmm {k1}{z}, zmm, m512","vpermt2b zmm {k1}{z}, zmm, m512 |  | ")]
        vpermt2b_zmm_k1z_zmm_m512 = 3014,

        /// <summary>
        /// vpermt2b zmm {k1}{z}, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpermt2b zmm {k1}{z}, zmm, r32","vpermt2b zmm {k1}{z}, zmm, r32 |  | ")]
        vpermt2b_zmm_k1z_zmm_r32 = 3015,

        /// <summary>
        /// vpermt2b zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpermt2b zmm, zmm, m512","vpermt2b zmm, zmm, m512 |  | ")]
        vpermt2b_zmm_zmm_m512 = 3016,

        /// <summary>
        /// vpermt2b zmm, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpermt2b zmm, zmm, r32","vpermt2b zmm, zmm, r32 |  | ")]
        vpermt2b_zmm_zmm_r32 = 3017,

        /// <summary>
        /// vpermt2d xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpermt2d xmm {k1}{z}, xmm, m128","vpermt2d xmm {k1}{z}, xmm, m128 |  | ")]
        vpermt2d_xmm_k1z_xmm_m128 = 3018,

        /// <summary>
        /// vpermt2d xmm {k1}{z}, xmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpermt2d xmm {k1}{z}, xmm, m32bcst","vpermt2d xmm {k1}{z}, xmm, m32bcst |  | ")]
        vpermt2d_xmm_k1z_xmm_m32bcst = 3019,

        /// <summary>
        /// vpermt2d xmm {k1}{z}, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpermt2d xmm {k1}{z}, xmm, xmm","vpermt2d xmm {k1}{z}, xmm, xmm |  | ")]
        vpermt2d_xmm_k1z_xmm_xmm = 3020,

        /// <summary>
        /// vpermt2d xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpermt2d xmm, xmm, m128","vpermt2d xmm, xmm, m128 |  | ")]
        vpermt2d_xmm_xmm_m128 = 3021,

        /// <summary>
        /// vpermt2d xmm, xmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpermt2d xmm, xmm, m32bcst","vpermt2d xmm, xmm, m32bcst |  | ")]
        vpermt2d_xmm_xmm_m32bcst = 3022,

        /// <summary>
        /// vpermt2d xmm, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpermt2d xmm, xmm, xmm","vpermt2d xmm, xmm, xmm |  | ")]
        vpermt2d_xmm_xmm_xmm = 3023,

        /// <summary>
        /// vpermt2d ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpermt2d ymm {k1}{z}, ymm, m256","vpermt2d ymm {k1}{z}, ymm, m256 |  | ")]
        vpermt2d_ymm_k1z_ymm_m256 = 3024,

        /// <summary>
        /// vpermt2d ymm {k1}{z}, ymm, m32bcst |  | 
        /// </summary>
        [Symbol("vpermt2d ymm {k1}{z}, ymm, m32bcst","vpermt2d ymm {k1}{z}, ymm, m32bcst |  | ")]
        vpermt2d_ymm_k1z_ymm_m32bcst = 3025,

        /// <summary>
        /// vpermt2d ymm {k1}{z}, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpermt2d ymm {k1}{z}, ymm, ymm","vpermt2d ymm {k1}{z}, ymm, ymm |  | ")]
        vpermt2d_ymm_k1z_ymm_ymm = 3026,

        /// <summary>
        /// vpermt2d ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpermt2d ymm, ymm, m256","vpermt2d ymm, ymm, m256 |  | ")]
        vpermt2d_ymm_ymm_m256 = 3027,

        /// <summary>
        /// vpermt2d ymm, ymm, m32bcst |  | 
        /// </summary>
        [Symbol("vpermt2d ymm, ymm, m32bcst","vpermt2d ymm, ymm, m32bcst |  | ")]
        vpermt2d_ymm_ymm_m32bcst = 3028,

        /// <summary>
        /// vpermt2d ymm, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpermt2d ymm, ymm, ymm","vpermt2d ymm, ymm, ymm |  | ")]
        vpermt2d_ymm_ymm_ymm = 3029,

        /// <summary>
        /// vpermt2d zmm {k1}{z}, zmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpermt2d zmm {k1}{z}, zmm, m32bcst","vpermt2d zmm {k1}{z}, zmm, m32bcst |  | ")]
        vpermt2d_zmm_k1z_zmm_m32bcst = 3030,

        /// <summary>
        /// vpermt2d zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpermt2d zmm {k1}{z}, zmm, m512","vpermt2d zmm {k1}{z}, zmm, m512 |  | ")]
        vpermt2d_zmm_k1z_zmm_m512 = 3031,

        /// <summary>
        /// vpermt2d zmm {k1}{z}, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpermt2d zmm {k1}{z}, zmm, zmm","vpermt2d zmm {k1}{z}, zmm, zmm |  | ")]
        vpermt2d_zmm_k1z_zmm_zmm = 3032,

        /// <summary>
        /// vpermt2d zmm, zmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpermt2d zmm, zmm, m32bcst","vpermt2d zmm, zmm, m32bcst |  | ")]
        vpermt2d_zmm_zmm_m32bcst = 3033,

        /// <summary>
        /// vpermt2d zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpermt2d zmm, zmm, m512","vpermt2d zmm, zmm, m512 |  | ")]
        vpermt2d_zmm_zmm_m512 = 3034,

        /// <summary>
        /// vpermt2d zmm, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpermt2d zmm, zmm, zmm","vpermt2d zmm, zmm, zmm |  | ")]
        vpermt2d_zmm_zmm_zmm = 3035,

        /// <summary>
        /// vpermt2pd xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpermt2pd xmm {k1}{z}, xmm, m128","vpermt2pd xmm {k1}{z}, xmm, m128 |  | ")]
        vpermt2pd_xmm_k1z_xmm_m128 = 3036,

        /// <summary>
        /// vpermt2pd xmm {k1}{z}, xmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpermt2pd xmm {k1}{z}, xmm, m64bcst","vpermt2pd xmm {k1}{z}, xmm, m64bcst |  | ")]
        vpermt2pd_xmm_k1z_xmm_m64bcst = 3037,

        /// <summary>
        /// vpermt2pd xmm {k1}{z}, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpermt2pd xmm {k1}{z}, xmm, xmm","vpermt2pd xmm {k1}{z}, xmm, xmm |  | ")]
        vpermt2pd_xmm_k1z_xmm_xmm = 3038,

        /// <summary>
        /// vpermt2pd xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpermt2pd xmm, xmm, m128","vpermt2pd xmm, xmm, m128 |  | ")]
        vpermt2pd_xmm_xmm_m128 = 3039,

        /// <summary>
        /// vpermt2pd xmm, xmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpermt2pd xmm, xmm, m64bcst","vpermt2pd xmm, xmm, m64bcst |  | ")]
        vpermt2pd_xmm_xmm_m64bcst = 3040,

        /// <summary>
        /// vpermt2pd xmm, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpermt2pd xmm, xmm, xmm","vpermt2pd xmm, xmm, xmm |  | ")]
        vpermt2pd_xmm_xmm_xmm = 3041,

        /// <summary>
        /// vpermt2pd ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpermt2pd ymm {k1}{z}, ymm, m256","vpermt2pd ymm {k1}{z}, ymm, m256 |  | ")]
        vpermt2pd_ymm_k1z_ymm_m256 = 3042,

        /// <summary>
        /// vpermt2pd ymm {k1}{z}, ymm, m64bcst |  | 
        /// </summary>
        [Symbol("vpermt2pd ymm {k1}{z}, ymm, m64bcst","vpermt2pd ymm {k1}{z}, ymm, m64bcst |  | ")]
        vpermt2pd_ymm_k1z_ymm_m64bcst = 3043,

        /// <summary>
        /// vpermt2pd ymm {k1}{z}, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpermt2pd ymm {k1}{z}, ymm, ymm","vpermt2pd ymm {k1}{z}, ymm, ymm |  | ")]
        vpermt2pd_ymm_k1z_ymm_ymm = 3044,

        /// <summary>
        /// vpermt2pd ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpermt2pd ymm, ymm, m256","vpermt2pd ymm, ymm, m256 |  | ")]
        vpermt2pd_ymm_ymm_m256 = 3045,

        /// <summary>
        /// vpermt2pd ymm, ymm, m64bcst |  | 
        /// </summary>
        [Symbol("vpermt2pd ymm, ymm, m64bcst","vpermt2pd ymm, ymm, m64bcst |  | ")]
        vpermt2pd_ymm_ymm_m64bcst = 3046,

        /// <summary>
        /// vpermt2pd ymm, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpermt2pd ymm, ymm, ymm","vpermt2pd ymm, ymm, ymm |  | ")]
        vpermt2pd_ymm_ymm_ymm = 3047,

        /// <summary>
        /// vpermt2pd zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpermt2pd zmm {k1}{z}, zmm, m512","vpermt2pd zmm {k1}{z}, zmm, m512 |  | ")]
        vpermt2pd_zmm_k1z_zmm_m512 = 3048,

        /// <summary>
        /// vpermt2pd zmm {k1}{z}, zmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpermt2pd zmm {k1}{z}, zmm, m64bcst","vpermt2pd zmm {k1}{z}, zmm, m64bcst |  | ")]
        vpermt2pd_zmm_k1z_zmm_m64bcst = 3049,

        /// <summary>
        /// vpermt2pd zmm {k1}{z}, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpermt2pd zmm {k1}{z}, zmm, zmm","vpermt2pd zmm {k1}{z}, zmm, zmm |  | ")]
        vpermt2pd_zmm_k1z_zmm_zmm = 3050,

        /// <summary>
        /// vpermt2pd zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpermt2pd zmm, zmm, m512","vpermt2pd zmm, zmm, m512 |  | ")]
        vpermt2pd_zmm_zmm_m512 = 3051,

        /// <summary>
        /// vpermt2pd zmm, zmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpermt2pd zmm, zmm, m64bcst","vpermt2pd zmm, zmm, m64bcst |  | ")]
        vpermt2pd_zmm_zmm_m64bcst = 3052,

        /// <summary>
        /// vpermt2pd zmm, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpermt2pd zmm, zmm, zmm","vpermt2pd zmm, zmm, zmm |  | ")]
        vpermt2pd_zmm_zmm_zmm = 3053,

        /// <summary>
        /// vpermt2ps xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpermt2ps xmm {k1}{z}, xmm, m128","vpermt2ps xmm {k1}{z}, xmm, m128 |  | ")]
        vpermt2ps_xmm_k1z_xmm_m128 = 3054,

        /// <summary>
        /// vpermt2ps xmm {k1}{z}, xmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpermt2ps xmm {k1}{z}, xmm, m32bcst","vpermt2ps xmm {k1}{z}, xmm, m32bcst |  | ")]
        vpermt2ps_xmm_k1z_xmm_m32bcst = 3055,

        /// <summary>
        /// vpermt2ps xmm {k1}{z}, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpermt2ps xmm {k1}{z}, xmm, xmm","vpermt2ps xmm {k1}{z}, xmm, xmm |  | ")]
        vpermt2ps_xmm_k1z_xmm_xmm = 3056,

        /// <summary>
        /// vpermt2ps xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpermt2ps xmm, xmm, m128","vpermt2ps xmm, xmm, m128 |  | ")]
        vpermt2ps_xmm_xmm_m128 = 3057,

        /// <summary>
        /// vpermt2ps xmm, xmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpermt2ps xmm, xmm, m32bcst","vpermt2ps xmm, xmm, m32bcst |  | ")]
        vpermt2ps_xmm_xmm_m32bcst = 3058,

        /// <summary>
        /// vpermt2ps xmm, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpermt2ps xmm, xmm, xmm","vpermt2ps xmm, xmm, xmm |  | ")]
        vpermt2ps_xmm_xmm_xmm = 3059,

        /// <summary>
        /// vpermt2ps ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpermt2ps ymm {k1}{z}, ymm, m256","vpermt2ps ymm {k1}{z}, ymm, m256 |  | ")]
        vpermt2ps_ymm_k1z_ymm_m256 = 3060,

        /// <summary>
        /// vpermt2ps ymm {k1}{z}, ymm, m32bcst |  | 
        /// </summary>
        [Symbol("vpermt2ps ymm {k1}{z}, ymm, m32bcst","vpermt2ps ymm {k1}{z}, ymm, m32bcst |  | ")]
        vpermt2ps_ymm_k1z_ymm_m32bcst = 3061,

        /// <summary>
        /// vpermt2ps ymm {k1}{z}, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpermt2ps ymm {k1}{z}, ymm, ymm","vpermt2ps ymm {k1}{z}, ymm, ymm |  | ")]
        vpermt2ps_ymm_k1z_ymm_ymm = 3062,

        /// <summary>
        /// vpermt2ps ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpermt2ps ymm, ymm, m256","vpermt2ps ymm, ymm, m256 |  | ")]
        vpermt2ps_ymm_ymm_m256 = 3063,

        /// <summary>
        /// vpermt2ps ymm, ymm, m32bcst |  | 
        /// </summary>
        [Symbol("vpermt2ps ymm, ymm, m32bcst","vpermt2ps ymm, ymm, m32bcst |  | ")]
        vpermt2ps_ymm_ymm_m32bcst = 3064,

        /// <summary>
        /// vpermt2ps ymm, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpermt2ps ymm, ymm, ymm","vpermt2ps ymm, ymm, ymm |  | ")]
        vpermt2ps_ymm_ymm_ymm = 3065,

        /// <summary>
        /// vpermt2ps zmm {k1}{z}, zmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpermt2ps zmm {k1}{z}, zmm, m32bcst","vpermt2ps zmm {k1}{z}, zmm, m32bcst |  | ")]
        vpermt2ps_zmm_k1z_zmm_m32bcst = 3066,

        /// <summary>
        /// vpermt2ps zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpermt2ps zmm {k1}{z}, zmm, m512","vpermt2ps zmm {k1}{z}, zmm, m512 |  | ")]
        vpermt2ps_zmm_k1z_zmm_m512 = 3067,

        /// <summary>
        /// vpermt2ps zmm {k1}{z}, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpermt2ps zmm {k1}{z}, zmm, zmm","vpermt2ps zmm {k1}{z}, zmm, zmm |  | ")]
        vpermt2ps_zmm_k1z_zmm_zmm = 3068,

        /// <summary>
        /// vpermt2ps zmm, zmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpermt2ps zmm, zmm, m32bcst","vpermt2ps zmm, zmm, m32bcst |  | ")]
        vpermt2ps_zmm_zmm_m32bcst = 3069,

        /// <summary>
        /// vpermt2ps zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpermt2ps zmm, zmm, m512","vpermt2ps zmm, zmm, m512 |  | ")]
        vpermt2ps_zmm_zmm_m512 = 3070,

        /// <summary>
        /// vpermt2ps zmm, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpermt2ps zmm, zmm, zmm","vpermt2ps zmm, zmm, zmm |  | ")]
        vpermt2ps_zmm_zmm_zmm = 3071,

        /// <summary>
        /// vpermt2q xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpermt2q xmm {k1}{z}, xmm, m128","vpermt2q xmm {k1}{z}, xmm, m128 |  | ")]
        vpermt2q_xmm_k1z_xmm_m128 = 3072,

        /// <summary>
        /// vpermt2q xmm {k1}{z}, xmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpermt2q xmm {k1}{z}, xmm, m64bcst","vpermt2q xmm {k1}{z}, xmm, m64bcst |  | ")]
        vpermt2q_xmm_k1z_xmm_m64bcst = 3073,

        /// <summary>
        /// vpermt2q xmm {k1}{z}, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpermt2q xmm {k1}{z}, xmm, xmm","vpermt2q xmm {k1}{z}, xmm, xmm |  | ")]
        vpermt2q_xmm_k1z_xmm_xmm = 3074,

        /// <summary>
        /// vpermt2q xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpermt2q xmm, xmm, m128","vpermt2q xmm, xmm, m128 |  | ")]
        vpermt2q_xmm_xmm_m128 = 3075,

        /// <summary>
        /// vpermt2q xmm, xmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpermt2q xmm, xmm, m64bcst","vpermt2q xmm, xmm, m64bcst |  | ")]
        vpermt2q_xmm_xmm_m64bcst = 3076,

        /// <summary>
        /// vpermt2q xmm, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpermt2q xmm, xmm, xmm","vpermt2q xmm, xmm, xmm |  | ")]
        vpermt2q_xmm_xmm_xmm = 3077,

        /// <summary>
        /// vpermt2q ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpermt2q ymm {k1}{z}, ymm, m256","vpermt2q ymm {k1}{z}, ymm, m256 |  | ")]
        vpermt2q_ymm_k1z_ymm_m256 = 3078,

        /// <summary>
        /// vpermt2q ymm {k1}{z}, ymm, m64bcst |  | 
        /// </summary>
        [Symbol("vpermt2q ymm {k1}{z}, ymm, m64bcst","vpermt2q ymm {k1}{z}, ymm, m64bcst |  | ")]
        vpermt2q_ymm_k1z_ymm_m64bcst = 3079,

        /// <summary>
        /// vpermt2q ymm {k1}{z}, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpermt2q ymm {k1}{z}, ymm, ymm","vpermt2q ymm {k1}{z}, ymm, ymm |  | ")]
        vpermt2q_ymm_k1z_ymm_ymm = 3080,

        /// <summary>
        /// vpermt2q ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpermt2q ymm, ymm, m256","vpermt2q ymm, ymm, m256 |  | ")]
        vpermt2q_ymm_ymm_m256 = 3081,

        /// <summary>
        /// vpermt2q ymm, ymm, m64bcst |  | 
        /// </summary>
        [Symbol("vpermt2q ymm, ymm, m64bcst","vpermt2q ymm, ymm, m64bcst |  | ")]
        vpermt2q_ymm_ymm_m64bcst = 3082,

        /// <summary>
        /// vpermt2q ymm, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpermt2q ymm, ymm, ymm","vpermt2q ymm, ymm, ymm |  | ")]
        vpermt2q_ymm_ymm_ymm = 3083,

        /// <summary>
        /// vpermt2q zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpermt2q zmm {k1}{z}, zmm, m512","vpermt2q zmm {k1}{z}, zmm, m512 |  | ")]
        vpermt2q_zmm_k1z_zmm_m512 = 3084,

        /// <summary>
        /// vpermt2q zmm {k1}{z}, zmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpermt2q zmm {k1}{z}, zmm, m64bcst","vpermt2q zmm {k1}{z}, zmm, m64bcst |  | ")]
        vpermt2q_zmm_k1z_zmm_m64bcst = 3085,

        /// <summary>
        /// vpermt2q zmm {k1}{z}, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpermt2q zmm {k1}{z}, zmm, zmm","vpermt2q zmm {k1}{z}, zmm, zmm |  | ")]
        vpermt2q_zmm_k1z_zmm_zmm = 3086,

        /// <summary>
        /// vpermt2q zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpermt2q zmm, zmm, m512","vpermt2q zmm, zmm, m512 |  | ")]
        vpermt2q_zmm_zmm_m512 = 3087,

        /// <summary>
        /// vpermt2q zmm, zmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpermt2q zmm, zmm, m64bcst","vpermt2q zmm, zmm, m64bcst |  | ")]
        vpermt2q_zmm_zmm_m64bcst = 3088,

        /// <summary>
        /// vpermt2q zmm, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpermt2q zmm, zmm, zmm","vpermt2q zmm, zmm, zmm |  | ")]
        vpermt2q_zmm_zmm_zmm = 3089,

        /// <summary>
        /// vpermt2w xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpermt2w xmm {k1}{z}, xmm, m128","vpermt2w xmm {k1}{z}, xmm, m128 |  | ")]
        vpermt2w_xmm_k1z_xmm_m128 = 3090,

        /// <summary>
        /// vpermt2w xmm {k1}{z}, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpermt2w xmm {k1}{z}, xmm, r8","vpermt2w xmm {k1}{z}, xmm, r8 |  | ")]
        vpermt2w_xmm_k1z_xmm_r8 = 3091,

        /// <summary>
        /// vpermt2w xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpermt2w xmm, xmm, m128","vpermt2w xmm, xmm, m128 |  | ")]
        vpermt2w_xmm_xmm_m128 = 3092,

        /// <summary>
        /// vpermt2w xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpermt2w xmm, xmm, r8","vpermt2w xmm, xmm, r8 |  | ")]
        vpermt2w_xmm_xmm_r8 = 3093,

        /// <summary>
        /// vpermt2w ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpermt2w ymm {k1}{z}, ymm, m256","vpermt2w ymm {k1}{z}, ymm, m256 |  | ")]
        vpermt2w_ymm_k1z_ymm_m256 = 3094,

        /// <summary>
        /// vpermt2w ymm {k1}{z}, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpermt2w ymm {k1}{z}, ymm, r16","vpermt2w ymm {k1}{z}, ymm, r16 |  | ")]
        vpermt2w_ymm_k1z_ymm_r16 = 3095,

        /// <summary>
        /// vpermt2w ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpermt2w ymm, ymm, m256","vpermt2w ymm, ymm, m256 |  | ")]
        vpermt2w_ymm_ymm_m256 = 3096,

        /// <summary>
        /// vpermt2w ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpermt2w ymm, ymm, r16","vpermt2w ymm, ymm, r16 |  | ")]
        vpermt2w_ymm_ymm_r16 = 3097,

        /// <summary>
        /// vpermt2w zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpermt2w zmm {k1}{z}, zmm, m512","vpermt2w zmm {k1}{z}, zmm, m512 |  | ")]
        vpermt2w_zmm_k1z_zmm_m512 = 3098,

        /// <summary>
        /// vpermt2w zmm {k1}{z}, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpermt2w zmm {k1}{z}, zmm, r32","vpermt2w zmm {k1}{z}, zmm, r32 |  | ")]
        vpermt2w_zmm_k1z_zmm_r32 = 3099,

        /// <summary>
        /// vpermt2w zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpermt2w zmm, zmm, m512","vpermt2w zmm, zmm, m512 |  | ")]
        vpermt2w_zmm_zmm_m512 = 3100,

        /// <summary>
        /// vpermt2w zmm, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpermt2w zmm, zmm, r32","vpermt2w zmm, zmm, r32 |  | ")]
        vpermt2w_zmm_zmm_r32 = 3101,

        /// <summary>
        /// vpermw xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpermw xmm {k1}{z}, xmm, m128","vpermw xmm {k1}{z}, xmm, m128 |  | ")]
        vpermw_xmm_k1z_xmm_m128 = 3102,

        /// <summary>
        /// vpermw xmm {k1}{z}, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpermw xmm {k1}{z}, xmm, r8","vpermw xmm {k1}{z}, xmm, r8 |  | ")]
        vpermw_xmm_k1z_xmm_r8 = 3103,

        /// <summary>
        /// vpermw xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpermw xmm, xmm, m128","vpermw xmm, xmm, m128 |  | ")]
        vpermw_xmm_xmm_m128 = 3104,

        /// <summary>
        /// vpermw xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpermw xmm, xmm, r8","vpermw xmm, xmm, r8 |  | ")]
        vpermw_xmm_xmm_r8 = 3105,

        /// <summary>
        /// vpermw ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpermw ymm {k1}{z}, ymm, m256","vpermw ymm {k1}{z}, ymm, m256 |  | ")]
        vpermw_ymm_k1z_ymm_m256 = 3106,

        /// <summary>
        /// vpermw ymm {k1}{z}, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpermw ymm {k1}{z}, ymm, r16","vpermw ymm {k1}{z}, ymm, r16 |  | ")]
        vpermw_ymm_k1z_ymm_r16 = 3107,

        /// <summary>
        /// vpermw ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpermw ymm, ymm, m256","vpermw ymm, ymm, m256 |  | ")]
        vpermw_ymm_ymm_m256 = 3108,

        /// <summary>
        /// vpermw ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpermw ymm, ymm, r16","vpermw ymm, ymm, r16 |  | ")]
        vpermw_ymm_ymm_r16 = 3109,

        /// <summary>
        /// vpermw zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpermw zmm {k1}{z}, zmm, m512","vpermw zmm {k1}{z}, zmm, m512 |  | ")]
        vpermw_zmm_k1z_zmm_m512 = 3110,

        /// <summary>
        /// vpermw zmm {k1}{z}, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpermw zmm {k1}{z}, zmm, r32","vpermw zmm {k1}{z}, zmm, r32 |  | ")]
        vpermw_zmm_k1z_zmm_r32 = 3111,

        /// <summary>
        /// vpermw zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpermw zmm, zmm, m512","vpermw zmm, zmm, m512 |  | ")]
        vpermw_zmm_zmm_m512 = 3112,

        /// <summary>
        /// vpermw zmm, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpermw zmm, zmm, r32","vpermw zmm, zmm, r32 |  | ")]
        vpermw_zmm_zmm_r32 = 3113,

        /// <summary>
        /// vpextrb m8, xmm, imm8 |  | 
        /// </summary>
        [Symbol("vpextrb m8, xmm, imm8","vpextrb m8, xmm, imm8 |  | ")]
        vpextrb_m8_xmm_imm8 = 3114,

        /// <summary>
        /// vpextrb r8, xmm, imm8 |  | 
        /// </summary>
        [Symbol("vpextrb r8, xmm, imm8","vpextrb r8, xmm, imm8 |  | ")]
        vpextrb_r8_xmm_imm8 = 3115,

        /// <summary>
        /// vpextrd m32, xmm, imm8 |  | 
        /// </summary>
        [Symbol("vpextrd m32, xmm, imm8","vpextrd m32, xmm, imm8 |  | ")]
        vpextrd_m32_xmm_imm8 = 3116,

        /// <summary>
        /// vpextrd r32, xmm, imm8 |  | 
        /// </summary>
        [Symbol("vpextrd r32, xmm, imm8","vpextrd r32, xmm, imm8 |  | ")]
        vpextrd_r32_xmm_imm8 = 3117,

        /// <summary>
        /// vpextrq m64, xmm, imm8 |  | 
        /// </summary>
        [Symbol("vpextrq m64, xmm, imm8","vpextrq m64, xmm, imm8 |  | ")]
        vpextrq_m64_xmm_imm8 = 3118,

        /// <summary>
        /// vpextrq r64, xmm, imm8 |  | 
        /// </summary>
        [Symbol("vpextrq r64, xmm, imm8","vpextrq r64, xmm, imm8 |  | ")]
        vpextrq_r64_xmm_imm8 = 3119,

        /// <summary>
        /// vpextrw m16, xmm, imm8 |  | 
        /// </summary>
        [Symbol("vpextrw m16, xmm, imm8","vpextrw m16, xmm, imm8 |  | ")]
        vpextrw_m16_xmm_imm8 = 3120,

        /// <summary>
        /// vpextrw r16, xmm, imm8 |  | 
        /// </summary>
        [Symbol("vpextrw r16, xmm, imm8","vpextrw r16, xmm, imm8 |  | ")]
        vpextrw_r16_xmm_imm8 = 3121,

        /// <summary>
        /// vpextrw reg, xmm, imm8 |  | 
        /// </summary>
        [Symbol("vpextrw reg, xmm, imm8","vpextrw reg, xmm, imm8 |  | ")]
        vpextrw_reg_xmm_imm8 = 3122,

        /// <summary>
        /// vpgatherdd xmm {k1}, vm32x |  | 
        /// </summary>
        [Symbol("vpgatherdd xmm {k1}, vm32x","vpgatherdd xmm {k1}, vm32x |  | ")]
        vpgatherdd_xmm_k1_vm32x = 3123,

        /// <summary>
        /// vpgatherdd xmm, vm32x |  | 
        /// </summary>
        [Symbol("vpgatherdd xmm, vm32x","vpgatherdd xmm, vm32x |  | ")]
        vpgatherdd_xmm_vm32x = 3124,

        /// <summary>
        /// vpgatherdd xmm, vm32x, xmm |  | 
        /// </summary>
        [Symbol("vpgatherdd xmm, vm32x, xmm","vpgatherdd xmm, vm32x, xmm |  | ")]
        vpgatherdd_xmm_vm32x_xmm = 3125,

        /// <summary>
        /// vpgatherdd ymm {k1}, vm32y |  | 
        /// </summary>
        [Symbol("vpgatherdd ymm {k1}, vm32y","vpgatherdd ymm {k1}, vm32y |  | ")]
        vpgatherdd_ymm_k1_vm32y = 3126,

        /// <summary>
        /// vpgatherdd ymm, vm32y |  | 
        /// </summary>
        [Symbol("vpgatherdd ymm, vm32y","vpgatherdd ymm, vm32y |  | ")]
        vpgatherdd_ymm_vm32y = 3127,

        /// <summary>
        /// vpgatherdd ymm, vm32y, ymm |  | 
        /// </summary>
        [Symbol("vpgatherdd ymm, vm32y, ymm","vpgatherdd ymm, vm32y, ymm |  | ")]
        vpgatherdd_ymm_vm32y_ymm = 3128,

        /// <summary>
        /// vpgatherdd zmm {k1}, vm32z |  | 
        /// </summary>
        [Symbol("vpgatherdd zmm {k1}, vm32z","vpgatherdd zmm {k1}, vm32z |  | ")]
        vpgatherdd_zmm_k1_vm32z = 3129,

        /// <summary>
        /// vpgatherdd zmm, vm32z |  | 
        /// </summary>
        [Symbol("vpgatherdd zmm, vm32z","vpgatherdd zmm, vm32z |  | ")]
        vpgatherdd_zmm_vm32z = 3130,

        /// <summary>
        /// vpgatherdq xmm {k1}, vm32x |  | 
        /// </summary>
        [Symbol("vpgatherdq xmm {k1}, vm32x","vpgatherdq xmm {k1}, vm32x |  | ")]
        vpgatherdq_xmm_k1_vm32x = 3131,

        /// <summary>
        /// vpgatherdq xmm, vm32x |  | 
        /// </summary>
        [Symbol("vpgatherdq xmm, vm32x","vpgatherdq xmm, vm32x |  | ")]
        vpgatherdq_xmm_vm32x = 3132,

        /// <summary>
        /// vpgatherdq xmm, vm32x, xmm |  | 
        /// </summary>
        [Symbol("vpgatherdq xmm, vm32x, xmm","vpgatherdq xmm, vm32x, xmm |  | ")]
        vpgatherdq_xmm_vm32x_xmm = 3133,

        /// <summary>
        /// vpgatherdq ymm {k1}, vm32x |  | 
        /// </summary>
        [Symbol("vpgatherdq ymm {k1}, vm32x","vpgatherdq ymm {k1}, vm32x |  | ")]
        vpgatherdq_ymm_k1_vm32x = 3134,

        /// <summary>
        /// vpgatherdq ymm, vm32x |  | 
        /// </summary>
        [Symbol("vpgatherdq ymm, vm32x","vpgatherdq ymm, vm32x |  | ")]
        vpgatherdq_ymm_vm32x = 3135,

        /// <summary>
        /// vpgatherdq ymm, vm32x, ymm |  | 
        /// </summary>
        [Symbol("vpgatherdq ymm, vm32x, ymm","vpgatherdq ymm, vm32x, ymm |  | ")]
        vpgatherdq_ymm_vm32x_ymm = 3136,

        /// <summary>
        /// vpgatherdq zmm {k1}, vm32y |  | 
        /// </summary>
        [Symbol("vpgatherdq zmm {k1}, vm32y","vpgatherdq zmm {k1}, vm32y |  | ")]
        vpgatherdq_zmm_k1_vm32y = 3137,

        /// <summary>
        /// vpgatherdq zmm, vm32y |  | 
        /// </summary>
        [Symbol("vpgatherdq zmm, vm32y","vpgatherdq zmm, vm32y |  | ")]
        vpgatherdq_zmm_vm32y = 3138,

        /// <summary>
        /// vpgatherqd xmm {k1}, vm64x |  | 
        /// </summary>
        [Symbol("vpgatherqd xmm {k1}, vm64x","vpgatherqd xmm {k1}, vm64x |  | ")]
        vpgatherqd_xmm_k1_vm64x = 3139,

        /// <summary>
        /// vpgatherqd xmm {k1}, vm64y |  | 
        /// </summary>
        [Symbol("vpgatherqd xmm {k1}, vm64y","vpgatherqd xmm {k1}, vm64y |  | ")]
        vpgatherqd_xmm_k1_vm64y = 3140,

        /// <summary>
        /// vpgatherqd xmm, vm64x |  | 
        /// </summary>
        [Symbol("vpgatherqd xmm, vm64x","vpgatherqd xmm, vm64x |  | ")]
        vpgatherqd_xmm_vm64x = 3141,

        /// <summary>
        /// vpgatherqd xmm, vm64x, xmm |  | 
        /// </summary>
        [Symbol("vpgatherqd xmm, vm64x, xmm","vpgatherqd xmm, vm64x, xmm |  | ")]
        vpgatherqd_xmm_vm64x_xmm = 3142,

        /// <summary>
        /// vpgatherqd xmm, vm64y |  | 
        /// </summary>
        [Symbol("vpgatherqd xmm, vm64y","vpgatherqd xmm, vm64y |  | ")]
        vpgatherqd_xmm_vm64y = 3143,

        /// <summary>
        /// vpgatherqd xmm, vm64y, xmm |  | 
        /// </summary>
        [Symbol("vpgatherqd xmm, vm64y, xmm","vpgatherqd xmm, vm64y, xmm |  | ")]
        vpgatherqd_xmm_vm64y_xmm = 3144,

        /// <summary>
        /// vpgatherqd ymm {k1}, vm64z |  | 
        /// </summary>
        [Symbol("vpgatherqd ymm {k1}, vm64z","vpgatherqd ymm {k1}, vm64z |  | ")]
        vpgatherqd_ymm_k1_vm64z = 3145,

        /// <summary>
        /// vpgatherqd ymm, vm64z |  | 
        /// </summary>
        [Symbol("vpgatherqd ymm, vm64z","vpgatherqd ymm, vm64z |  | ")]
        vpgatherqd_ymm_vm64z = 3146,

        /// <summary>
        /// vpgatherqq xmm {k1}, vm64x |  | 
        /// </summary>
        [Symbol("vpgatherqq xmm {k1}, vm64x","vpgatherqq xmm {k1}, vm64x |  | ")]
        vpgatherqq_xmm_k1_vm64x = 3147,

        /// <summary>
        /// vpgatherqq xmm, vm64x |  | 
        /// </summary>
        [Symbol("vpgatherqq xmm, vm64x","vpgatherqq xmm, vm64x |  | ")]
        vpgatherqq_xmm_vm64x = 3148,

        /// <summary>
        /// vpgatherqq xmm, vm64x, xmm |  | 
        /// </summary>
        [Symbol("vpgatherqq xmm, vm64x, xmm","vpgatherqq xmm, vm64x, xmm |  | ")]
        vpgatherqq_xmm_vm64x_xmm = 3149,

        /// <summary>
        /// vpgatherqq ymm {k1}, vm64y |  | 
        /// </summary>
        [Symbol("vpgatherqq ymm {k1}, vm64y","vpgatherqq ymm {k1}, vm64y |  | ")]
        vpgatherqq_ymm_k1_vm64y = 3150,

        /// <summary>
        /// vpgatherqq ymm, vm64y |  | 
        /// </summary>
        [Symbol("vpgatherqq ymm, vm64y","vpgatherqq ymm, vm64y |  | ")]
        vpgatherqq_ymm_vm64y = 3151,

        /// <summary>
        /// vpgatherqq ymm, vm64y, ymm |  | 
        /// </summary>
        [Symbol("vpgatherqq ymm, vm64y, ymm","vpgatherqq ymm, vm64y, ymm |  | ")]
        vpgatherqq_ymm_vm64y_ymm = 3152,

        /// <summary>
        /// vpgatherqq zmm {k1}, vm64z |  | 
        /// </summary>
        [Symbol("vpgatherqq zmm {k1}, vm64z","vpgatherqq zmm {k1}, vm64z |  | ")]
        vpgatherqq_zmm_k1_vm64z = 3153,

        /// <summary>
        /// vpgatherqq zmm, vm64z |  | 
        /// </summary>
        [Symbol("vpgatherqq zmm, vm64z","vpgatherqq zmm, vm64z |  | ")]
        vpgatherqq_zmm_vm64z = 3154,

        /// <summary>
        /// vphaddd xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vphaddd xmm, xmm, m128","vphaddd xmm, xmm, m128 |  | ")]
        vphaddd_xmm_xmm_m128 = 3155,

        /// <summary>
        /// vphaddd xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vphaddd xmm, xmm, r8","vphaddd xmm, xmm, r8 |  | ")]
        vphaddd_xmm_xmm_r8 = 3156,

        /// <summary>
        /// vphaddd ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vphaddd ymm, ymm, m256","vphaddd ymm, ymm, m256 |  | ")]
        vphaddd_ymm_ymm_m256 = 3157,

        /// <summary>
        /// vphaddd ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vphaddd ymm, ymm, r16","vphaddd ymm, ymm, r16 |  | ")]
        vphaddd_ymm_ymm_r16 = 3158,

        /// <summary>
        /// vphaddsw xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vphaddsw xmm, xmm, m128","vphaddsw xmm, xmm, m128 |  | ")]
        vphaddsw_xmm_xmm_m128 = 3159,

        /// <summary>
        /// vphaddsw xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vphaddsw xmm, xmm, r8","vphaddsw xmm, xmm, r8 |  | ")]
        vphaddsw_xmm_xmm_r8 = 3160,

        /// <summary>
        /// vphaddsw ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vphaddsw ymm, ymm, m256","vphaddsw ymm, ymm, m256 |  | ")]
        vphaddsw_ymm_ymm_m256 = 3161,

        /// <summary>
        /// vphaddsw ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vphaddsw ymm, ymm, r16","vphaddsw ymm, ymm, r16 |  | ")]
        vphaddsw_ymm_ymm_r16 = 3162,

        /// <summary>
        /// vphaddw xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vphaddw xmm, xmm, m128","vphaddw xmm, xmm, m128 |  | ")]
        vphaddw_xmm_xmm_m128 = 3163,

        /// <summary>
        /// vphaddw xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vphaddw xmm, xmm, r8","vphaddw xmm, xmm, r8 |  | ")]
        vphaddw_xmm_xmm_r8 = 3164,

        /// <summary>
        /// vphaddw ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vphaddw ymm, ymm, m256","vphaddw ymm, ymm, m256 |  | ")]
        vphaddw_ymm_ymm_m256 = 3165,

        /// <summary>
        /// vphaddw ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vphaddw ymm, ymm, r16","vphaddw ymm, ymm, r16 |  | ")]
        vphaddw_ymm_ymm_r16 = 3166,

        /// <summary>
        /// vpinsrb xmm, xmm, m8, imm8 |  | 
        /// </summary>
        [Symbol("vpinsrb xmm, xmm, m8, imm8","vpinsrb xmm, xmm, m8, imm8 |  | ")]
        vpinsrb_xmm_xmm_m8_imm8 = 3167,

        /// <summary>
        /// vpinsrb xmm, xmm, r32, imm8 |  | 
        /// </summary>
        [Symbol("vpinsrb xmm, xmm, r32, imm8","vpinsrb xmm, xmm, r32, imm8 |  | ")]
        vpinsrb_xmm_xmm_r32_imm8 = 3168,

        /// <summary>
        /// vpinsrd xmm, xmm, m32, imm8 |  | 
        /// </summary>
        [Symbol("vpinsrd xmm, xmm, m32, imm8","vpinsrd xmm, xmm, m32, imm8 |  | ")]
        vpinsrd_xmm_xmm_m32_imm8 = 3169,

        /// <summary>
        /// vpinsrd xmm, xmm, r32, imm8 |  | 
        /// </summary>
        [Symbol("vpinsrd xmm, xmm, r32, imm8","vpinsrd xmm, xmm, r32, imm8 |  | ")]
        vpinsrd_xmm_xmm_r32_imm8 = 3170,

        /// <summary>
        /// vpinsrq xmm, xmm, m64, imm8 |  | 
        /// </summary>
        [Symbol("vpinsrq xmm, xmm, m64, imm8","vpinsrq xmm, xmm, m64, imm8 |  | ")]
        vpinsrq_xmm_xmm_m64_imm8 = 3171,

        /// <summary>
        /// vpinsrq xmm, xmm, r64, imm8 |  | 
        /// </summary>
        [Symbol("vpinsrq xmm, xmm, r64, imm8","vpinsrq xmm, xmm, r64, imm8 |  | ")]
        vpinsrq_xmm_xmm_r64_imm8 = 3172,

        /// <summary>
        /// vpinsrw xmm, xmm, m16, imm8 |  | 
        /// </summary>
        [Symbol("vpinsrw xmm, xmm, m16, imm8","vpinsrw xmm, xmm, m16, imm8 |  | ")]
        vpinsrw_xmm_xmm_m16_imm8 = 3173,

        /// <summary>
        /// vpinsrw xmm, xmm, r32, imm8 |  | 
        /// </summary>
        [Symbol("vpinsrw xmm, xmm, r32, imm8","vpinsrw xmm, xmm, r32, imm8 |  | ")]
        vpinsrw_xmm_xmm_r32_imm8 = 3174,

        /// <summary>
        /// vplzcntd xmm {k1}{z}, m128 |  | 
        /// </summary>
        [Symbol("vplzcntd xmm {k1}{z}, m128","vplzcntd xmm {k1}{z}, m128 |  | ")]
        vplzcntd_xmm_k1z_m128 = 3175,

        /// <summary>
        /// vplzcntd xmm {k1}{z}, m32bcst |  | 
        /// </summary>
        [Symbol("vplzcntd xmm {k1}{z}, m32bcst","vplzcntd xmm {k1}{z}, m32bcst |  | ")]
        vplzcntd_xmm_k1z_m32bcst = 3176,

        /// <summary>
        /// vplzcntd xmm {k1}{z}, xmm |  | 
        /// </summary>
        [Symbol("vplzcntd xmm {k1}{z}, xmm","vplzcntd xmm {k1}{z}, xmm |  | ")]
        vplzcntd_xmm_k1z_xmm = 3177,

        /// <summary>
        /// vplzcntd xmm, m128 |  | 
        /// </summary>
        [Symbol("vplzcntd xmm, m128","vplzcntd xmm, m128 |  | ")]
        vplzcntd_xmm_m128 = 3178,

        /// <summary>
        /// vplzcntd xmm, m32bcst |  | 
        /// </summary>
        [Symbol("vplzcntd xmm, m32bcst","vplzcntd xmm, m32bcst |  | ")]
        vplzcntd_xmm_m32bcst = 3179,

        /// <summary>
        /// vplzcntd xmm, xmm |  | 
        /// </summary>
        [Symbol("vplzcntd xmm, xmm","vplzcntd xmm, xmm |  | ")]
        vplzcntd_xmm_xmm = 3180,

        /// <summary>
        /// vplzcntd ymm {k1}{z}, m256 |  | 
        /// </summary>
        [Symbol("vplzcntd ymm {k1}{z}, m256","vplzcntd ymm {k1}{z}, m256 |  | ")]
        vplzcntd_ymm_k1z_m256 = 3181,

        /// <summary>
        /// vplzcntd ymm {k1}{z}, m32bcst |  | 
        /// </summary>
        [Symbol("vplzcntd ymm {k1}{z}, m32bcst","vplzcntd ymm {k1}{z}, m32bcst |  | ")]
        vplzcntd_ymm_k1z_m32bcst = 3182,

        /// <summary>
        /// vplzcntd ymm {k1}{z}, ymm |  | 
        /// </summary>
        [Symbol("vplzcntd ymm {k1}{z}, ymm","vplzcntd ymm {k1}{z}, ymm |  | ")]
        vplzcntd_ymm_k1z_ymm = 3183,

        /// <summary>
        /// vplzcntd ymm, m256 |  | 
        /// </summary>
        [Symbol("vplzcntd ymm, m256","vplzcntd ymm, m256 |  | ")]
        vplzcntd_ymm_m256 = 3184,

        /// <summary>
        /// vplzcntd ymm, m32bcst |  | 
        /// </summary>
        [Symbol("vplzcntd ymm, m32bcst","vplzcntd ymm, m32bcst |  | ")]
        vplzcntd_ymm_m32bcst = 3185,

        /// <summary>
        /// vplzcntd ymm, ymm |  | 
        /// </summary>
        [Symbol("vplzcntd ymm, ymm","vplzcntd ymm, ymm |  | ")]
        vplzcntd_ymm_ymm = 3186,

        /// <summary>
        /// vplzcntd zmm {k1}{z}, m32bcst |  | 
        /// </summary>
        [Symbol("vplzcntd zmm {k1}{z}, m32bcst","vplzcntd zmm {k1}{z}, m32bcst |  | ")]
        vplzcntd_zmm_k1z_m32bcst = 3187,

        /// <summary>
        /// vplzcntd zmm {k1}{z}, m512 |  | 
        /// </summary>
        [Symbol("vplzcntd zmm {k1}{z}, m512","vplzcntd zmm {k1}{z}, m512 |  | ")]
        vplzcntd_zmm_k1z_m512 = 3188,

        /// <summary>
        /// vplzcntd zmm {k1}{z}, zmm |  | 
        /// </summary>
        [Symbol("vplzcntd zmm {k1}{z}, zmm","vplzcntd zmm {k1}{z}, zmm |  | ")]
        vplzcntd_zmm_k1z_zmm = 3189,

        /// <summary>
        /// vplzcntd zmm, m32bcst |  | 
        /// </summary>
        [Symbol("vplzcntd zmm, m32bcst","vplzcntd zmm, m32bcst |  | ")]
        vplzcntd_zmm_m32bcst = 3190,

        /// <summary>
        /// vplzcntd zmm, m512 |  | 
        /// </summary>
        [Symbol("vplzcntd zmm, m512","vplzcntd zmm, m512 |  | ")]
        vplzcntd_zmm_m512 = 3191,

        /// <summary>
        /// vplzcntd zmm, zmm |  | 
        /// </summary>
        [Symbol("vplzcntd zmm, zmm","vplzcntd zmm, zmm |  | ")]
        vplzcntd_zmm_zmm = 3192,

        /// <summary>
        /// vplzcntq xmm {k1}{z}, m128 |  | 
        /// </summary>
        [Symbol("vplzcntq xmm {k1}{z}, m128","vplzcntq xmm {k1}{z}, m128 |  | ")]
        vplzcntq_xmm_k1z_m128 = 3193,

        /// <summary>
        /// vplzcntq xmm {k1}{z}, m64bcst |  | 
        /// </summary>
        [Symbol("vplzcntq xmm {k1}{z}, m64bcst","vplzcntq xmm {k1}{z}, m64bcst |  | ")]
        vplzcntq_xmm_k1z_m64bcst = 3194,

        /// <summary>
        /// vplzcntq xmm {k1}{z}, xmm |  | 
        /// </summary>
        [Symbol("vplzcntq xmm {k1}{z}, xmm","vplzcntq xmm {k1}{z}, xmm |  | ")]
        vplzcntq_xmm_k1z_xmm = 3195,

        /// <summary>
        /// vplzcntq xmm, m128 |  | 
        /// </summary>
        [Symbol("vplzcntq xmm, m128","vplzcntq xmm, m128 |  | ")]
        vplzcntq_xmm_m128 = 3196,

        /// <summary>
        /// vplzcntq xmm, m64bcst |  | 
        /// </summary>
        [Symbol("vplzcntq xmm, m64bcst","vplzcntq xmm, m64bcst |  | ")]
        vplzcntq_xmm_m64bcst = 3197,

        /// <summary>
        /// vplzcntq xmm, xmm |  | 
        /// </summary>
        [Symbol("vplzcntq xmm, xmm","vplzcntq xmm, xmm |  | ")]
        vplzcntq_xmm_xmm = 3198,

        /// <summary>
        /// vplzcntq ymm {k1}{z}, m256 |  | 
        /// </summary>
        [Symbol("vplzcntq ymm {k1}{z}, m256","vplzcntq ymm {k1}{z}, m256 |  | ")]
        vplzcntq_ymm_k1z_m256 = 3199,

        /// <summary>
        /// vplzcntq ymm {k1}{z}, m64bcst |  | 
        /// </summary>
        [Symbol("vplzcntq ymm {k1}{z}, m64bcst","vplzcntq ymm {k1}{z}, m64bcst |  | ")]
        vplzcntq_ymm_k1z_m64bcst = 3200,

        /// <summary>
        /// vplzcntq ymm {k1}{z}, ymm |  | 
        /// </summary>
        [Symbol("vplzcntq ymm {k1}{z}, ymm","vplzcntq ymm {k1}{z}, ymm |  | ")]
        vplzcntq_ymm_k1z_ymm = 3201,

        /// <summary>
        /// vplzcntq ymm, m256 |  | 
        /// </summary>
        [Symbol("vplzcntq ymm, m256","vplzcntq ymm, m256 |  | ")]
        vplzcntq_ymm_m256 = 3202,

        /// <summary>
        /// vplzcntq ymm, m64bcst |  | 
        /// </summary>
        [Symbol("vplzcntq ymm, m64bcst","vplzcntq ymm, m64bcst |  | ")]
        vplzcntq_ymm_m64bcst = 3203,

        /// <summary>
        /// vplzcntq ymm, ymm |  | 
        /// </summary>
        [Symbol("vplzcntq ymm, ymm","vplzcntq ymm, ymm |  | ")]
        vplzcntq_ymm_ymm = 3204,

        /// <summary>
        /// vplzcntq zmm {k1}{z}, m512 |  | 
        /// </summary>
        [Symbol("vplzcntq zmm {k1}{z}, m512","vplzcntq zmm {k1}{z}, m512 |  | ")]
        vplzcntq_zmm_k1z_m512 = 3205,

        /// <summary>
        /// vplzcntq zmm {k1}{z}, m64bcst |  | 
        /// </summary>
        [Symbol("vplzcntq zmm {k1}{z}, m64bcst","vplzcntq zmm {k1}{z}, m64bcst |  | ")]
        vplzcntq_zmm_k1z_m64bcst = 3206,

        /// <summary>
        /// vplzcntq zmm {k1}{z}, zmm |  | 
        /// </summary>
        [Symbol("vplzcntq zmm {k1}{z}, zmm","vplzcntq zmm {k1}{z}, zmm |  | ")]
        vplzcntq_zmm_k1z_zmm = 3207,

        /// <summary>
        /// vplzcntq zmm, m512 |  | 
        /// </summary>
        [Symbol("vplzcntq zmm, m512","vplzcntq zmm, m512 |  | ")]
        vplzcntq_zmm_m512 = 3208,

        /// <summary>
        /// vplzcntq zmm, m64bcst |  | 
        /// </summary>
        [Symbol("vplzcntq zmm, m64bcst","vplzcntq zmm, m64bcst |  | ")]
        vplzcntq_zmm_m64bcst = 3209,

        /// <summary>
        /// vplzcntq zmm, zmm |  | 
        /// </summary>
        [Symbol("vplzcntq zmm, zmm","vplzcntq zmm, zmm |  | ")]
        vplzcntq_zmm_zmm = 3210,

        /// <summary>
        /// vpmaskmovd m128, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpmaskmovd m128, xmm, xmm","vpmaskmovd m128, xmm, xmm |  | ")]
        vpmaskmovd_m128_xmm_xmm = 3211,

        /// <summary>
        /// vpmaskmovd m256, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpmaskmovd m256, ymm, ymm","vpmaskmovd m256, ymm, ymm |  | ")]
        vpmaskmovd_m256_ymm_ymm = 3212,

        /// <summary>
        /// vpmaskmovd xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpmaskmovd xmm, xmm, m128","vpmaskmovd xmm, xmm, m128 |  | ")]
        vpmaskmovd_xmm_xmm_m128 = 3213,

        /// <summary>
        /// vpmaskmovd ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpmaskmovd ymm, ymm, m256","vpmaskmovd ymm, ymm, m256 |  | ")]
        vpmaskmovd_ymm_ymm_m256 = 3214,

        /// <summary>
        /// vpmaskmovq m128, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpmaskmovq m128, xmm, xmm","vpmaskmovq m128, xmm, xmm |  | ")]
        vpmaskmovq_m128_xmm_xmm = 3215,

        /// <summary>
        /// vpmaskmovq m256, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpmaskmovq m256, ymm, ymm","vpmaskmovq m256, ymm, ymm |  | ")]
        vpmaskmovq_m256_ymm_ymm = 3216,

        /// <summary>
        /// vpmaskmovq xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpmaskmovq xmm, xmm, m128","vpmaskmovq xmm, xmm, m128 |  | ")]
        vpmaskmovq_xmm_xmm_m128 = 3217,

        /// <summary>
        /// vpmaskmovq ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpmaskmovq ymm, ymm, m256","vpmaskmovq ymm, ymm, m256 |  | ")]
        vpmaskmovq_ymm_ymm_m256 = 3218,

        /// <summary>
        /// vpmaxsb xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpmaxsb xmm {k1}{z}, xmm, m128","vpmaxsb xmm {k1}{z}, xmm, m128 |  | ")]
        vpmaxsb_xmm_k1z_xmm_m128 = 3219,

        /// <summary>
        /// vpmaxsb xmm {k1}{z}, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpmaxsb xmm {k1}{z}, xmm, r8","vpmaxsb xmm {k1}{z}, xmm, r8 |  | ")]
        vpmaxsb_xmm_k1z_xmm_r8 = 3220,

        /// <summary>
        /// vpmaxsb xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpmaxsb xmm, xmm, m128","vpmaxsb xmm, xmm, m128 |  | ")]
        vpmaxsb_xmm_xmm_m128 = 3221,

        /// <summary>
        /// vpmaxsb xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpmaxsb xmm, xmm, r8","vpmaxsb xmm, xmm, r8 |  | ")]
        vpmaxsb_xmm_xmm_r8 = 3222,

        /// <summary>
        /// vpmaxsb ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpmaxsb ymm {k1}{z}, ymm, m256","vpmaxsb ymm {k1}{z}, ymm, m256 |  | ")]
        vpmaxsb_ymm_k1z_ymm_m256 = 3223,

        /// <summary>
        /// vpmaxsb ymm {k1}{z}, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpmaxsb ymm {k1}{z}, ymm, r16","vpmaxsb ymm {k1}{z}, ymm, r16 |  | ")]
        vpmaxsb_ymm_k1z_ymm_r16 = 3224,

        /// <summary>
        /// vpmaxsb ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpmaxsb ymm, ymm, m256","vpmaxsb ymm, ymm, m256 |  | ")]
        vpmaxsb_ymm_ymm_m256 = 3225,

        /// <summary>
        /// vpmaxsb ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpmaxsb ymm, ymm, r16","vpmaxsb ymm, ymm, r16 |  | ")]
        vpmaxsb_ymm_ymm_r16 = 3226,

        /// <summary>
        /// vpmaxsb zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpmaxsb zmm {k1}{z}, zmm, m512","vpmaxsb zmm {k1}{z}, zmm, m512 |  | ")]
        vpmaxsb_zmm_k1z_zmm_m512 = 3227,

        /// <summary>
        /// vpmaxsb zmm {k1}{z}, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpmaxsb zmm {k1}{z}, zmm, r32","vpmaxsb zmm {k1}{z}, zmm, r32 |  | ")]
        vpmaxsb_zmm_k1z_zmm_r32 = 3228,

        /// <summary>
        /// vpmaxsb zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpmaxsb zmm, zmm, m512","vpmaxsb zmm, zmm, m512 |  | ")]
        vpmaxsb_zmm_zmm_m512 = 3229,

        /// <summary>
        /// vpmaxsb zmm, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpmaxsb zmm, zmm, r32","vpmaxsb zmm, zmm, r32 |  | ")]
        vpmaxsb_zmm_zmm_r32 = 3230,

        /// <summary>
        /// vpmaxsd xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpmaxsd xmm {k1}{z}, xmm, m128","vpmaxsd xmm {k1}{z}, xmm, m128 |  | ")]
        vpmaxsd_xmm_k1z_xmm_m128 = 3231,

        /// <summary>
        /// vpmaxsd xmm {k1}{z}, xmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpmaxsd xmm {k1}{z}, xmm, m32bcst","vpmaxsd xmm {k1}{z}, xmm, m32bcst |  | ")]
        vpmaxsd_xmm_k1z_xmm_m32bcst = 3232,

        /// <summary>
        /// vpmaxsd xmm {k1}{z}, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpmaxsd xmm {k1}{z}, xmm, xmm","vpmaxsd xmm {k1}{z}, xmm, xmm |  | ")]
        vpmaxsd_xmm_k1z_xmm_xmm = 3233,

        /// <summary>
        /// vpmaxsd xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpmaxsd xmm, xmm, m128","vpmaxsd xmm, xmm, m128 |  | ")]
        vpmaxsd_xmm_xmm_m128 = 3234,

        /// <summary>
        /// vpmaxsd xmm, xmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpmaxsd xmm, xmm, m32bcst","vpmaxsd xmm, xmm, m32bcst |  | ")]
        vpmaxsd_xmm_xmm_m32bcst = 3235,

        /// <summary>
        /// vpmaxsd xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpmaxsd xmm, xmm, r8","vpmaxsd xmm, xmm, r8 |  | ")]
        vpmaxsd_xmm_xmm_r8 = 3236,

        /// <summary>
        /// vpmaxsd xmm, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpmaxsd xmm, xmm, xmm","vpmaxsd xmm, xmm, xmm |  | ")]
        vpmaxsd_xmm_xmm_xmm = 3237,

        /// <summary>
        /// vpmaxsd ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpmaxsd ymm {k1}{z}, ymm, m256","vpmaxsd ymm {k1}{z}, ymm, m256 |  | ")]
        vpmaxsd_ymm_k1z_ymm_m256 = 3238,

        /// <summary>
        /// vpmaxsd ymm {k1}{z}, ymm, m32bcst |  | 
        /// </summary>
        [Symbol("vpmaxsd ymm {k1}{z}, ymm, m32bcst","vpmaxsd ymm {k1}{z}, ymm, m32bcst |  | ")]
        vpmaxsd_ymm_k1z_ymm_m32bcst = 3239,

        /// <summary>
        /// vpmaxsd ymm {k1}{z}, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpmaxsd ymm {k1}{z}, ymm, ymm","vpmaxsd ymm {k1}{z}, ymm, ymm |  | ")]
        vpmaxsd_ymm_k1z_ymm_ymm = 3240,

        /// <summary>
        /// vpmaxsd ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpmaxsd ymm, ymm, m256","vpmaxsd ymm, ymm, m256 |  | ")]
        vpmaxsd_ymm_ymm_m256 = 3241,

        /// <summary>
        /// vpmaxsd ymm, ymm, m32bcst |  | 
        /// </summary>
        [Symbol("vpmaxsd ymm, ymm, m32bcst","vpmaxsd ymm, ymm, m32bcst |  | ")]
        vpmaxsd_ymm_ymm_m32bcst = 3242,

        /// <summary>
        /// vpmaxsd ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpmaxsd ymm, ymm, r16","vpmaxsd ymm, ymm, r16 |  | ")]
        vpmaxsd_ymm_ymm_r16 = 3243,

        /// <summary>
        /// vpmaxsd ymm, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpmaxsd ymm, ymm, ymm","vpmaxsd ymm, ymm, ymm |  | ")]
        vpmaxsd_ymm_ymm_ymm = 3244,

        /// <summary>
        /// vpmaxsd zmm {k1}{z}, zmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpmaxsd zmm {k1}{z}, zmm, m32bcst","vpmaxsd zmm {k1}{z}, zmm, m32bcst |  | ")]
        vpmaxsd_zmm_k1z_zmm_m32bcst = 3245,

        /// <summary>
        /// vpmaxsd zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpmaxsd zmm {k1}{z}, zmm, m512","vpmaxsd zmm {k1}{z}, zmm, m512 |  | ")]
        vpmaxsd_zmm_k1z_zmm_m512 = 3246,

        /// <summary>
        /// vpmaxsd zmm {k1}{z}, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpmaxsd zmm {k1}{z}, zmm, zmm","vpmaxsd zmm {k1}{z}, zmm, zmm |  | ")]
        vpmaxsd_zmm_k1z_zmm_zmm = 3247,

        /// <summary>
        /// vpmaxsd zmm, zmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpmaxsd zmm, zmm, m32bcst","vpmaxsd zmm, zmm, m32bcst |  | ")]
        vpmaxsd_zmm_zmm_m32bcst = 3248,

        /// <summary>
        /// vpmaxsd zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpmaxsd zmm, zmm, m512","vpmaxsd zmm, zmm, m512 |  | ")]
        vpmaxsd_zmm_zmm_m512 = 3249,

        /// <summary>
        /// vpmaxsd zmm, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpmaxsd zmm, zmm, zmm","vpmaxsd zmm, zmm, zmm |  | ")]
        vpmaxsd_zmm_zmm_zmm = 3250,

        /// <summary>
        /// vpmaxsq xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpmaxsq xmm {k1}{z}, xmm, m128","vpmaxsq xmm {k1}{z}, xmm, m128 |  | ")]
        vpmaxsq_xmm_k1z_xmm_m128 = 3251,

        /// <summary>
        /// vpmaxsq xmm {k1}{z}, xmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpmaxsq xmm {k1}{z}, xmm, m64bcst","vpmaxsq xmm {k1}{z}, xmm, m64bcst |  | ")]
        vpmaxsq_xmm_k1z_xmm_m64bcst = 3252,

        /// <summary>
        /// vpmaxsq xmm {k1}{z}, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpmaxsq xmm {k1}{z}, xmm, xmm","vpmaxsq xmm {k1}{z}, xmm, xmm |  | ")]
        vpmaxsq_xmm_k1z_xmm_xmm = 3253,

        /// <summary>
        /// vpmaxsq xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpmaxsq xmm, xmm, m128","vpmaxsq xmm, xmm, m128 |  | ")]
        vpmaxsq_xmm_xmm_m128 = 3254,

        /// <summary>
        /// vpmaxsq xmm, xmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpmaxsq xmm, xmm, m64bcst","vpmaxsq xmm, xmm, m64bcst |  | ")]
        vpmaxsq_xmm_xmm_m64bcst = 3255,

        /// <summary>
        /// vpmaxsq xmm, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpmaxsq xmm, xmm, xmm","vpmaxsq xmm, xmm, xmm |  | ")]
        vpmaxsq_xmm_xmm_xmm = 3256,

        /// <summary>
        /// vpmaxsq ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpmaxsq ymm {k1}{z}, ymm, m256","vpmaxsq ymm {k1}{z}, ymm, m256 |  | ")]
        vpmaxsq_ymm_k1z_ymm_m256 = 3257,

        /// <summary>
        /// vpmaxsq ymm {k1}{z}, ymm, m64bcst |  | 
        /// </summary>
        [Symbol("vpmaxsq ymm {k1}{z}, ymm, m64bcst","vpmaxsq ymm {k1}{z}, ymm, m64bcst |  | ")]
        vpmaxsq_ymm_k1z_ymm_m64bcst = 3258,

        /// <summary>
        /// vpmaxsq ymm {k1}{z}, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpmaxsq ymm {k1}{z}, ymm, ymm","vpmaxsq ymm {k1}{z}, ymm, ymm |  | ")]
        vpmaxsq_ymm_k1z_ymm_ymm = 3259,

        /// <summary>
        /// vpmaxsq ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpmaxsq ymm, ymm, m256","vpmaxsq ymm, ymm, m256 |  | ")]
        vpmaxsq_ymm_ymm_m256 = 3260,

        /// <summary>
        /// vpmaxsq ymm, ymm, m64bcst |  | 
        /// </summary>
        [Symbol("vpmaxsq ymm, ymm, m64bcst","vpmaxsq ymm, ymm, m64bcst |  | ")]
        vpmaxsq_ymm_ymm_m64bcst = 3261,

        /// <summary>
        /// vpmaxsq ymm, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpmaxsq ymm, ymm, ymm","vpmaxsq ymm, ymm, ymm |  | ")]
        vpmaxsq_ymm_ymm_ymm = 3262,

        /// <summary>
        /// vpmaxsq zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpmaxsq zmm {k1}{z}, zmm, m512","vpmaxsq zmm {k1}{z}, zmm, m512 |  | ")]
        vpmaxsq_zmm_k1z_zmm_m512 = 3263,

        /// <summary>
        /// vpmaxsq zmm {k1}{z}, zmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpmaxsq zmm {k1}{z}, zmm, m64bcst","vpmaxsq zmm {k1}{z}, zmm, m64bcst |  | ")]
        vpmaxsq_zmm_k1z_zmm_m64bcst = 3264,

        /// <summary>
        /// vpmaxsq zmm {k1}{z}, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpmaxsq zmm {k1}{z}, zmm, zmm","vpmaxsq zmm {k1}{z}, zmm, zmm |  | ")]
        vpmaxsq_zmm_k1z_zmm_zmm = 3265,

        /// <summary>
        /// vpmaxsq zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpmaxsq zmm, zmm, m512","vpmaxsq zmm, zmm, m512 |  | ")]
        vpmaxsq_zmm_zmm_m512 = 3266,

        /// <summary>
        /// vpmaxsq zmm, zmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpmaxsq zmm, zmm, m64bcst","vpmaxsq zmm, zmm, m64bcst |  | ")]
        vpmaxsq_zmm_zmm_m64bcst = 3267,

        /// <summary>
        /// vpmaxsq zmm, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpmaxsq zmm, zmm, zmm","vpmaxsq zmm, zmm, zmm |  | ")]
        vpmaxsq_zmm_zmm_zmm = 3268,

        /// <summary>
        /// vpmaxsw xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpmaxsw xmm {k1}{z}, xmm, m128","vpmaxsw xmm {k1}{z}, xmm, m128 |  | ")]
        vpmaxsw_xmm_k1z_xmm_m128 = 3269,

        /// <summary>
        /// vpmaxsw xmm {k1}{z}, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpmaxsw xmm {k1}{z}, xmm, r8","vpmaxsw xmm {k1}{z}, xmm, r8 |  | ")]
        vpmaxsw_xmm_k1z_xmm_r8 = 3270,

        /// <summary>
        /// vpmaxsw xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpmaxsw xmm, xmm, m128","vpmaxsw xmm, xmm, m128 |  | ")]
        vpmaxsw_xmm_xmm_m128 = 3271,

        /// <summary>
        /// vpmaxsw xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpmaxsw xmm, xmm, r8","vpmaxsw xmm, xmm, r8 |  | ")]
        vpmaxsw_xmm_xmm_r8 = 3272,

        /// <summary>
        /// vpmaxsw ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpmaxsw ymm {k1}{z}, ymm, m256","vpmaxsw ymm {k1}{z}, ymm, m256 |  | ")]
        vpmaxsw_ymm_k1z_ymm_m256 = 3273,

        /// <summary>
        /// vpmaxsw ymm {k1}{z}, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpmaxsw ymm {k1}{z}, ymm, r16","vpmaxsw ymm {k1}{z}, ymm, r16 |  | ")]
        vpmaxsw_ymm_k1z_ymm_r16 = 3274,

        /// <summary>
        /// vpmaxsw ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpmaxsw ymm, ymm, m256","vpmaxsw ymm, ymm, m256 |  | ")]
        vpmaxsw_ymm_ymm_m256 = 3275,

        /// <summary>
        /// vpmaxsw ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpmaxsw ymm, ymm, r16","vpmaxsw ymm, ymm, r16 |  | ")]
        vpmaxsw_ymm_ymm_r16 = 3276,

        /// <summary>
        /// vpmaxsw zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpmaxsw zmm {k1}{z}, zmm, m512","vpmaxsw zmm {k1}{z}, zmm, m512 |  | ")]
        vpmaxsw_zmm_k1z_zmm_m512 = 3277,

        /// <summary>
        /// vpmaxsw zmm {k1}{z}, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpmaxsw zmm {k1}{z}, zmm, r32","vpmaxsw zmm {k1}{z}, zmm, r32 |  | ")]
        vpmaxsw_zmm_k1z_zmm_r32 = 3278,

        /// <summary>
        /// vpmaxsw zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpmaxsw zmm, zmm, m512","vpmaxsw zmm, zmm, m512 |  | ")]
        vpmaxsw_zmm_zmm_m512 = 3279,

        /// <summary>
        /// vpmaxsw zmm, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpmaxsw zmm, zmm, r32","vpmaxsw zmm, zmm, r32 |  | ")]
        vpmaxsw_zmm_zmm_r32 = 3280,

        /// <summary>
        /// vpmaxub xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpmaxub xmm {k1}{z}, xmm, m128","vpmaxub xmm {k1}{z}, xmm, m128 |  | ")]
        vpmaxub_xmm_k1z_xmm_m128 = 3281,

        /// <summary>
        /// vpmaxub xmm {k1}{z}, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpmaxub xmm {k1}{z}, xmm, r8","vpmaxub xmm {k1}{z}, xmm, r8 |  | ")]
        vpmaxub_xmm_k1z_xmm_r8 = 3282,

        /// <summary>
        /// vpmaxub xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpmaxub xmm, xmm, m128","vpmaxub xmm, xmm, m128 |  | ")]
        vpmaxub_xmm_xmm_m128 = 3283,

        /// <summary>
        /// vpmaxub xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpmaxub xmm, xmm, r8","vpmaxub xmm, xmm, r8 |  | ")]
        vpmaxub_xmm_xmm_r8 = 3284,

        /// <summary>
        /// vpmaxub ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpmaxub ymm {k1}{z}, ymm, m256","vpmaxub ymm {k1}{z}, ymm, m256 |  | ")]
        vpmaxub_ymm_k1z_ymm_m256 = 3285,

        /// <summary>
        /// vpmaxub ymm {k1}{z}, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpmaxub ymm {k1}{z}, ymm, r16","vpmaxub ymm {k1}{z}, ymm, r16 |  | ")]
        vpmaxub_ymm_k1z_ymm_r16 = 3286,

        /// <summary>
        /// vpmaxub ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpmaxub ymm, ymm, m256","vpmaxub ymm, ymm, m256 |  | ")]
        vpmaxub_ymm_ymm_m256 = 3287,

        /// <summary>
        /// vpmaxub ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpmaxub ymm, ymm, r16","vpmaxub ymm, ymm, r16 |  | ")]
        vpmaxub_ymm_ymm_r16 = 3288,

        /// <summary>
        /// vpmaxub zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpmaxub zmm {k1}{z}, zmm, m512","vpmaxub zmm {k1}{z}, zmm, m512 |  | ")]
        vpmaxub_zmm_k1z_zmm_m512 = 3289,

        /// <summary>
        /// vpmaxub zmm {k1}{z}, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpmaxub zmm {k1}{z}, zmm, r32","vpmaxub zmm {k1}{z}, zmm, r32 |  | ")]
        vpmaxub_zmm_k1z_zmm_r32 = 3290,

        /// <summary>
        /// vpmaxub zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpmaxub zmm, zmm, m512","vpmaxub zmm, zmm, m512 |  | ")]
        vpmaxub_zmm_zmm_m512 = 3291,

        /// <summary>
        /// vpmaxub zmm, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpmaxub zmm, zmm, r32","vpmaxub zmm, zmm, r32 |  | ")]
        vpmaxub_zmm_zmm_r32 = 3292,

        /// <summary>
        /// vpmaxuw xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpmaxuw xmm {k1}{z}, xmm, m128","vpmaxuw xmm {k1}{z}, xmm, m128 |  | ")]
        vpmaxuw_xmm_k1z_xmm_m128 = 3293,

        /// <summary>
        /// vpmaxuw xmm {k1}{z}, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpmaxuw xmm {k1}{z}, xmm, r8","vpmaxuw xmm {k1}{z}, xmm, r8 |  | ")]
        vpmaxuw_xmm_k1z_xmm_r8 = 3294,

        /// <summary>
        /// vpmaxuw xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpmaxuw xmm, xmm, m128","vpmaxuw xmm, xmm, m128 |  | ")]
        vpmaxuw_xmm_xmm_m128 = 3295,

        /// <summary>
        /// vpmaxuw xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpmaxuw xmm, xmm, r8","vpmaxuw xmm, xmm, r8 |  | ")]
        vpmaxuw_xmm_xmm_r8 = 3296,

        /// <summary>
        /// vpmaxuw ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpmaxuw ymm {k1}{z}, ymm, m256","vpmaxuw ymm {k1}{z}, ymm, m256 |  | ")]
        vpmaxuw_ymm_k1z_ymm_m256 = 3297,

        /// <summary>
        /// vpmaxuw ymm {k1}{z}, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpmaxuw ymm {k1}{z}, ymm, r16","vpmaxuw ymm {k1}{z}, ymm, r16 |  | ")]
        vpmaxuw_ymm_k1z_ymm_r16 = 3298,

        /// <summary>
        /// vpmaxuw ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpmaxuw ymm, ymm, m256","vpmaxuw ymm, ymm, m256 |  | ")]
        vpmaxuw_ymm_ymm_m256 = 3299,

        /// <summary>
        /// vpmaxuw ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpmaxuw ymm, ymm, r16","vpmaxuw ymm, ymm, r16 |  | ")]
        vpmaxuw_ymm_ymm_r16 = 3300,

        /// <summary>
        /// vpmaxuw zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpmaxuw zmm {k1}{z}, zmm, m512","vpmaxuw zmm {k1}{z}, zmm, m512 |  | ")]
        vpmaxuw_zmm_k1z_zmm_m512 = 3301,

        /// <summary>
        /// vpmaxuw zmm {k1}{z}, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpmaxuw zmm {k1}{z}, zmm, r32","vpmaxuw zmm {k1}{z}, zmm, r32 |  | ")]
        vpmaxuw_zmm_k1z_zmm_r32 = 3302,

        /// <summary>
        /// vpmaxuw zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpmaxuw zmm, zmm, m512","vpmaxuw zmm, zmm, m512 |  | ")]
        vpmaxuw_zmm_zmm_m512 = 3303,

        /// <summary>
        /// vpmaxuw zmm, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpmaxuw zmm, zmm, r32","vpmaxuw zmm, zmm, r32 |  | ")]
        vpmaxuw_zmm_zmm_r32 = 3304,

        /// <summary>
        /// vpminsb xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpminsb xmm {k1}{z}, xmm, m128","vpminsb xmm {k1}{z}, xmm, m128 |  | ")]
        vpminsb_xmm_k1z_xmm_m128 = 3305,

        /// <summary>
        /// vpminsb xmm {k1}{z}, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpminsb xmm {k1}{z}, xmm, r8","vpminsb xmm {k1}{z}, xmm, r8 |  | ")]
        vpminsb_xmm_k1z_xmm_r8 = 3306,

        /// <summary>
        /// vpminsb xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpminsb xmm, xmm, m128","vpminsb xmm, xmm, m128 |  | ")]
        vpminsb_xmm_xmm_m128 = 3307,

        /// <summary>
        /// vpminsb xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpminsb xmm, xmm, r8","vpminsb xmm, xmm, r8 |  | ")]
        vpminsb_xmm_xmm_r8 = 3308,

        /// <summary>
        /// vpminsb ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpminsb ymm {k1}{z}, ymm, m256","vpminsb ymm {k1}{z}, ymm, m256 |  | ")]
        vpminsb_ymm_k1z_ymm_m256 = 3309,

        /// <summary>
        /// vpminsb ymm {k1}{z}, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpminsb ymm {k1}{z}, ymm, r16","vpminsb ymm {k1}{z}, ymm, r16 |  | ")]
        vpminsb_ymm_k1z_ymm_r16 = 3310,

        /// <summary>
        /// vpminsb ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpminsb ymm, ymm, m256","vpminsb ymm, ymm, m256 |  | ")]
        vpminsb_ymm_ymm_m256 = 3311,

        /// <summary>
        /// vpminsb ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpminsb ymm, ymm, r16","vpminsb ymm, ymm, r16 |  | ")]
        vpminsb_ymm_ymm_r16 = 3312,

        /// <summary>
        /// vpminsb zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpminsb zmm {k1}{z}, zmm, m512","vpminsb zmm {k1}{z}, zmm, m512 |  | ")]
        vpminsb_zmm_k1z_zmm_m512 = 3313,

        /// <summary>
        /// vpminsb zmm {k1}{z}, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpminsb zmm {k1}{z}, zmm, r32","vpminsb zmm {k1}{z}, zmm, r32 |  | ")]
        vpminsb_zmm_k1z_zmm_r32 = 3314,

        /// <summary>
        /// vpminsb zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpminsb zmm, zmm, m512","vpminsb zmm, zmm, m512 |  | ")]
        vpminsb_zmm_zmm_m512 = 3315,

        /// <summary>
        /// vpminsb zmm, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpminsb zmm, zmm, r32","vpminsb zmm, zmm, r32 |  | ")]
        vpminsb_zmm_zmm_r32 = 3316,

        /// <summary>
        /// vpminsw xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpminsw xmm {k1}{z}, xmm, m128","vpminsw xmm {k1}{z}, xmm, m128 |  | ")]
        vpminsw_xmm_k1z_xmm_m128 = 3317,

        /// <summary>
        /// vpminsw xmm {k1}{z}, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpminsw xmm {k1}{z}, xmm, r8","vpminsw xmm {k1}{z}, xmm, r8 |  | ")]
        vpminsw_xmm_k1z_xmm_r8 = 3318,

        /// <summary>
        /// vpminsw xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpminsw xmm, xmm, m128","vpminsw xmm, xmm, m128 |  | ")]
        vpminsw_xmm_xmm_m128 = 3319,

        /// <summary>
        /// vpminsw xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpminsw xmm, xmm, r8","vpminsw xmm, xmm, r8 |  | ")]
        vpminsw_xmm_xmm_r8 = 3320,

        /// <summary>
        /// vpminsw ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpminsw ymm {k1}{z}, ymm, m256","vpminsw ymm {k1}{z}, ymm, m256 |  | ")]
        vpminsw_ymm_k1z_ymm_m256 = 3321,

        /// <summary>
        /// vpminsw ymm {k1}{z}, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpminsw ymm {k1}{z}, ymm, r16","vpminsw ymm {k1}{z}, ymm, r16 |  | ")]
        vpminsw_ymm_k1z_ymm_r16 = 3322,

        /// <summary>
        /// vpminsw ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpminsw ymm, ymm, m256","vpminsw ymm, ymm, m256 |  | ")]
        vpminsw_ymm_ymm_m256 = 3323,

        /// <summary>
        /// vpminsw ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpminsw ymm, ymm, r16","vpminsw ymm, ymm, r16 |  | ")]
        vpminsw_ymm_ymm_r16 = 3324,

        /// <summary>
        /// vpminsw zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpminsw zmm {k1}{z}, zmm, m512","vpminsw zmm {k1}{z}, zmm, m512 |  | ")]
        vpminsw_zmm_k1z_zmm_m512 = 3325,

        /// <summary>
        /// vpminsw zmm {k1}{z}, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpminsw zmm {k1}{z}, zmm, r32","vpminsw zmm {k1}{z}, zmm, r32 |  | ")]
        vpminsw_zmm_k1z_zmm_r32 = 3326,

        /// <summary>
        /// vpminsw zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpminsw zmm, zmm, m512","vpminsw zmm, zmm, m512 |  | ")]
        vpminsw_zmm_zmm_m512 = 3327,

        /// <summary>
        /// vpminsw zmm, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpminsw zmm, zmm, r32","vpminsw zmm, zmm, r32 |  | ")]
        vpminsw_zmm_zmm_r32 = 3328,

        /// <summary>
        /// vpminub xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpminub xmm {k1}{z}, xmm, m128","vpminub xmm {k1}{z}, xmm, m128 |  | ")]
        vpminub_xmm_k1z_xmm_m128 = 3329,

        /// <summary>
        /// vpminub xmm {k1}{z}, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpminub xmm {k1}{z}, xmm, r8","vpminub xmm {k1}{z}, xmm, r8 |  | ")]
        vpminub_xmm_k1z_xmm_r8 = 3330,

        /// <summary>
        /// vpminub xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpminub xmm, xmm, m128","vpminub xmm, xmm, m128 |  | ")]
        vpminub_xmm_xmm_m128 = 3331,

        /// <summary>
        /// vpminub xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpminub xmm, xmm, r8","vpminub xmm, xmm, r8 |  | ")]
        vpminub_xmm_xmm_r8 = 3332,

        /// <summary>
        /// vpminub ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpminub ymm {k1}{z}, ymm, m256","vpminub ymm {k1}{z}, ymm, m256 |  | ")]
        vpminub_ymm_k1z_ymm_m256 = 3333,

        /// <summary>
        /// vpminub ymm {k1}{z}, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpminub ymm {k1}{z}, ymm, r16","vpminub ymm {k1}{z}, ymm, r16 |  | ")]
        vpminub_ymm_k1z_ymm_r16 = 3334,

        /// <summary>
        /// vpminub ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpminub ymm, ymm, m256","vpminub ymm, ymm, m256 |  | ")]
        vpminub_ymm_ymm_m256 = 3335,

        /// <summary>
        /// vpminub ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpminub ymm, ymm, r16","vpminub ymm, ymm, r16 |  | ")]
        vpminub_ymm_ymm_r16 = 3336,

        /// <summary>
        /// vpminub zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpminub zmm {k1}{z}, zmm, m512","vpminub zmm {k1}{z}, zmm, m512 |  | ")]
        vpminub_zmm_k1z_zmm_m512 = 3337,

        /// <summary>
        /// vpminub zmm {k1}{z}, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpminub zmm {k1}{z}, zmm, r32","vpminub zmm {k1}{z}, zmm, r32 |  | ")]
        vpminub_zmm_k1z_zmm_r32 = 3338,

        /// <summary>
        /// vpminub zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpminub zmm, zmm, m512","vpminub zmm, zmm, m512 |  | ")]
        vpminub_zmm_zmm_m512 = 3339,

        /// <summary>
        /// vpminub zmm, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpminub zmm, zmm, r32","vpminub zmm, zmm, r32 |  | ")]
        vpminub_zmm_zmm_r32 = 3340,

        /// <summary>
        /// vpminuw xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpminuw xmm {k1}{z}, xmm, m128","vpminuw xmm {k1}{z}, xmm, m128 |  | ")]
        vpminuw_xmm_k1z_xmm_m128 = 3341,

        /// <summary>
        /// vpminuw xmm {k1}{z}, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpminuw xmm {k1}{z}, xmm, r8","vpminuw xmm {k1}{z}, xmm, r8 |  | ")]
        vpminuw_xmm_k1z_xmm_r8 = 3342,

        /// <summary>
        /// vpminuw xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpminuw xmm, xmm, m128","vpminuw xmm, xmm, m128 |  | ")]
        vpminuw_xmm_xmm_m128 = 3343,

        /// <summary>
        /// vpminuw xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpminuw xmm, xmm, r8","vpminuw xmm, xmm, r8 |  | ")]
        vpminuw_xmm_xmm_r8 = 3344,

        /// <summary>
        /// vpminuw ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpminuw ymm {k1}{z}, ymm, m256","vpminuw ymm {k1}{z}, ymm, m256 |  | ")]
        vpminuw_ymm_k1z_ymm_m256 = 3345,

        /// <summary>
        /// vpminuw ymm {k1}{z}, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpminuw ymm {k1}{z}, ymm, r16","vpminuw ymm {k1}{z}, ymm, r16 |  | ")]
        vpminuw_ymm_k1z_ymm_r16 = 3346,

        /// <summary>
        /// vpminuw ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpminuw ymm, ymm, m256","vpminuw ymm, ymm, m256 |  | ")]
        vpminuw_ymm_ymm_m256 = 3347,

        /// <summary>
        /// vpminuw ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpminuw ymm, ymm, r16","vpminuw ymm, ymm, r16 |  | ")]
        vpminuw_ymm_ymm_r16 = 3348,

        /// <summary>
        /// vpminuw zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpminuw zmm {k1}{z}, zmm, m512","vpminuw zmm {k1}{z}, zmm, m512 |  | ")]
        vpminuw_zmm_k1z_zmm_m512 = 3349,

        /// <summary>
        /// vpminuw zmm {k1}{z}, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpminuw zmm {k1}{z}, zmm, r32","vpminuw zmm {k1}{z}, zmm, r32 |  | ")]
        vpminuw_zmm_k1z_zmm_r32 = 3350,

        /// <summary>
        /// vpminuw zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpminuw zmm, zmm, m512","vpminuw zmm, zmm, m512 |  | ")]
        vpminuw_zmm_zmm_m512 = 3351,

        /// <summary>
        /// vpminuw zmm, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpminuw zmm, zmm, r32","vpminuw zmm, zmm, r32 |  | ")]
        vpminuw_zmm_zmm_r32 = 3352,

        /// <summary>
        /// vpmovb2m k, xmm |  | 
        /// </summary>
        [Symbol("vpmovb2m k, xmm","vpmovb2m k, xmm |  | ")]
        vpmovb2m_k_xmm = 3353,

        /// <summary>
        /// vpmovb2m k, ymm |  | 
        /// </summary>
        [Symbol("vpmovb2m k, ymm","vpmovb2m k, ymm |  | ")]
        vpmovb2m_k_ymm = 3354,

        /// <summary>
        /// vpmovb2m k, zmm |  | 
        /// </summary>
        [Symbol("vpmovb2m k, zmm","vpmovb2m k, zmm |  | ")]
        vpmovb2m_k_zmm = 3355,

        /// <summary>
        /// vpmovd2m k, xmm |  | 
        /// </summary>
        [Symbol("vpmovd2m k, xmm","vpmovd2m k, xmm |  | ")]
        vpmovd2m_k_xmm = 3356,

        /// <summary>
        /// vpmovd2m k, ymm |  | 
        /// </summary>
        [Symbol("vpmovd2m k, ymm","vpmovd2m k, ymm |  | ")]
        vpmovd2m_k_ymm = 3357,

        /// <summary>
        /// vpmovd2m k, zmm |  | 
        /// </summary>
        [Symbol("vpmovd2m k, zmm","vpmovd2m k, zmm |  | ")]
        vpmovd2m_k_zmm = 3358,

        /// <summary>
        /// vpmovdb m128 {k1}{z}, zmm |  | 
        /// </summary>
        [Symbol("vpmovdb m128 {k1}{z}, zmm","vpmovdb m128 {k1}{z}, zmm |  | ")]
        vpmovdb_m128_k1z_zmm = 3359,

        /// <summary>
        /// vpmovdb m128, zmm |  | 
        /// </summary>
        [Symbol("vpmovdb m128, zmm","vpmovdb m128, zmm |  | ")]
        vpmovdb_m128_zmm = 3360,

        /// <summary>
        /// vpmovdb m32 {k1}{z}, xmm |  | 
        /// </summary>
        [Symbol("vpmovdb m32 {k1}{z}, xmm","vpmovdb m32 {k1}{z}, xmm |  | ")]
        vpmovdb_m32_k1z_xmm = 3361,

        /// <summary>
        /// vpmovdb m32, xmm |  | 
        /// </summary>
        [Symbol("vpmovdb m32, xmm","vpmovdb m32, xmm |  | ")]
        vpmovdb_m32_xmm = 3362,

        /// <summary>
        /// vpmovdb m64 {k1}{z}, ymm |  | 
        /// </summary>
        [Symbol("vpmovdb m64 {k1}{z}, ymm","vpmovdb m64 {k1}{z}, ymm |  | ")]
        vpmovdb_m64_k1z_ymm = 3363,

        /// <summary>
        /// vpmovdb m64, ymm |  | 
        /// </summary>
        [Symbol("vpmovdb m64, ymm","vpmovdb m64, ymm |  | ")]
        vpmovdb_m64_ymm = 3364,

        /// <summary>
        /// vpmovdb r8 {k1}{z}, xmm |  | 
        /// </summary>
        [Symbol("vpmovdb r8 {k1}{z}, xmm","vpmovdb r8 {k1}{z}, xmm |  | ")]
        vpmovdb_r8_k1z_xmm = 3365,

        /// <summary>
        /// vpmovdb r8 {k1}{z}, ymm |  | 
        /// </summary>
        [Symbol("vpmovdb r8 {k1}{z}, ymm","vpmovdb r8 {k1}{z}, ymm |  | ")]
        vpmovdb_r8_k1z_ymm = 3366,

        /// <summary>
        /// vpmovdb r8 {k1}{z}, zmm |  | 
        /// </summary>
        [Symbol("vpmovdb r8 {k1}{z}, zmm","vpmovdb r8 {k1}{z}, zmm |  | ")]
        vpmovdb_r8_k1z_zmm = 3367,

        /// <summary>
        /// vpmovdb r8, xmm |  | 
        /// </summary>
        [Symbol("vpmovdb r8, xmm","vpmovdb r8, xmm |  | ")]
        vpmovdb_r8_xmm = 3368,

        /// <summary>
        /// vpmovdb r8, ymm |  | 
        /// </summary>
        [Symbol("vpmovdb r8, ymm","vpmovdb r8, ymm |  | ")]
        vpmovdb_r8_ymm = 3369,

        /// <summary>
        /// vpmovdb r8, zmm |  | 
        /// </summary>
        [Symbol("vpmovdb r8, zmm","vpmovdb r8, zmm |  | ")]
        vpmovdb_r8_zmm = 3370,

        /// <summary>
        /// vpmovdw m128 {k1}{z}, ymm |  | 
        /// </summary>
        [Symbol("vpmovdw m128 {k1}{z}, ymm","vpmovdw m128 {k1}{z}, ymm |  | ")]
        vpmovdw_m128_k1z_ymm = 3371,

        /// <summary>
        /// vpmovdw m128, ymm |  | 
        /// </summary>
        [Symbol("vpmovdw m128, ymm","vpmovdw m128, ymm |  | ")]
        vpmovdw_m128_ymm = 3372,

        /// <summary>
        /// vpmovdw m256 {k1}{z}, zmm |  | 
        /// </summary>
        [Symbol("vpmovdw m256 {k1}{z}, zmm","vpmovdw m256 {k1}{z}, zmm |  | ")]
        vpmovdw_m256_k1z_zmm = 3373,

        /// <summary>
        /// vpmovdw m256, zmm |  | 
        /// </summary>
        [Symbol("vpmovdw m256, zmm","vpmovdw m256, zmm |  | ")]
        vpmovdw_m256_zmm = 3374,

        /// <summary>
        /// vpmovdw m64 {k1}{z}, xmm |  | 
        /// </summary>
        [Symbol("vpmovdw m64 {k1}{z}, xmm","vpmovdw m64 {k1}{z}, xmm |  | ")]
        vpmovdw_m64_k1z_xmm = 3375,

        /// <summary>
        /// vpmovdw m64, xmm |  | 
        /// </summary>
        [Symbol("vpmovdw m64, xmm","vpmovdw m64, xmm |  | ")]
        vpmovdw_m64_xmm = 3376,

        /// <summary>
        /// vpmovdw r16 {k1}{z}, zmm |  | 
        /// </summary>
        [Symbol("vpmovdw r16 {k1}{z}, zmm","vpmovdw r16 {k1}{z}, zmm |  | ")]
        vpmovdw_r16_k1z_zmm = 3377,

        /// <summary>
        /// vpmovdw r16, zmm |  | 
        /// </summary>
        [Symbol("vpmovdw r16, zmm","vpmovdw r16, zmm |  | ")]
        vpmovdw_r16_zmm = 3378,

        /// <summary>
        /// vpmovdw r8 {k1}{z}, xmm |  | 
        /// </summary>
        [Symbol("vpmovdw r8 {k1}{z}, xmm","vpmovdw r8 {k1}{z}, xmm |  | ")]
        vpmovdw_r8_k1z_xmm = 3379,

        /// <summary>
        /// vpmovdw r8 {k1}{z}, ymm |  | 
        /// </summary>
        [Symbol("vpmovdw r8 {k1}{z}, ymm","vpmovdw r8 {k1}{z}, ymm |  | ")]
        vpmovdw_r8_k1z_ymm = 3380,

        /// <summary>
        /// vpmovdw r8, xmm |  | 
        /// </summary>
        [Symbol("vpmovdw r8, xmm","vpmovdw r8, xmm |  | ")]
        vpmovdw_r8_xmm = 3381,

        /// <summary>
        /// vpmovdw r8, ymm |  | 
        /// </summary>
        [Symbol("vpmovdw r8, ymm","vpmovdw r8, ymm |  | ")]
        vpmovdw_r8_ymm = 3382,

        /// <summary>
        /// vpmovm2b xmm, k |  | 
        /// </summary>
        [Symbol("vpmovm2b xmm, k","vpmovm2b xmm, k |  | ")]
        vpmovm2b_xmm_k = 3383,

        /// <summary>
        /// vpmovm2b ymm, k |  | 
        /// </summary>
        [Symbol("vpmovm2b ymm, k","vpmovm2b ymm, k |  | ")]
        vpmovm2b_ymm_k = 3384,

        /// <summary>
        /// vpmovm2b zmm, k |  | 
        /// </summary>
        [Symbol("vpmovm2b zmm, k","vpmovm2b zmm, k |  | ")]
        vpmovm2b_zmm_k = 3385,

        /// <summary>
        /// vpmovm2d xmm, k |  | 
        /// </summary>
        [Symbol("vpmovm2d xmm, k","vpmovm2d xmm, k |  | ")]
        vpmovm2d_xmm_k = 3386,

        /// <summary>
        /// vpmovm2d ymm, k |  | 
        /// </summary>
        [Symbol("vpmovm2d ymm, k","vpmovm2d ymm, k |  | ")]
        vpmovm2d_ymm_k = 3387,

        /// <summary>
        /// vpmovm2d zmm, k |  | 
        /// </summary>
        [Symbol("vpmovm2d zmm, k","vpmovm2d zmm, k |  | ")]
        vpmovm2d_zmm_k = 3388,

        /// <summary>
        /// vpmovm2q xmm, k |  | 
        /// </summary>
        [Symbol("vpmovm2q xmm, k","vpmovm2q xmm, k |  | ")]
        vpmovm2q_xmm_k = 3389,

        /// <summary>
        /// vpmovm2q ymm, k |  | 
        /// </summary>
        [Symbol("vpmovm2q ymm, k","vpmovm2q ymm, k |  | ")]
        vpmovm2q_ymm_k = 3390,

        /// <summary>
        /// vpmovm2q zmm, k |  | 
        /// </summary>
        [Symbol("vpmovm2q zmm, k","vpmovm2q zmm, k |  | ")]
        vpmovm2q_zmm_k = 3391,

        /// <summary>
        /// vpmovm2w xmm, k |  | 
        /// </summary>
        [Symbol("vpmovm2w xmm, k","vpmovm2w xmm, k |  | ")]
        vpmovm2w_xmm_k = 3392,

        /// <summary>
        /// vpmovm2w ymm, k |  | 
        /// </summary>
        [Symbol("vpmovm2w ymm, k","vpmovm2w ymm, k |  | ")]
        vpmovm2w_ymm_k = 3393,

        /// <summary>
        /// vpmovm2w zmm, k |  | 
        /// </summary>
        [Symbol("vpmovm2w zmm, k","vpmovm2w zmm, k |  | ")]
        vpmovm2w_zmm_k = 3394,

        /// <summary>
        /// vpmovmskb reg, xmm |  | 
        /// </summary>
        [Symbol("vpmovmskb reg, xmm","vpmovmskb reg, xmm |  | ")]
        vpmovmskb_reg_xmm = 3395,

        /// <summary>
        /// vpmovmskb reg, ymm |  | 
        /// </summary>
        [Symbol("vpmovmskb reg, ymm","vpmovmskb reg, ymm |  | ")]
        vpmovmskb_reg_ymm = 3396,

        /// <summary>
        /// vpmovq2m k, xmm |  | 
        /// </summary>
        [Symbol("vpmovq2m k, xmm","vpmovq2m k, xmm |  | ")]
        vpmovq2m_k_xmm = 3397,

        /// <summary>
        /// vpmovq2m k, ymm |  | 
        /// </summary>
        [Symbol("vpmovq2m k, ymm","vpmovq2m k, ymm |  | ")]
        vpmovq2m_k_ymm = 3398,

        /// <summary>
        /// vpmovq2m k, zmm |  | 
        /// </summary>
        [Symbol("vpmovq2m k, zmm","vpmovq2m k, zmm |  | ")]
        vpmovq2m_k_zmm = 3399,

        /// <summary>
        /// vpmovqb m16 {k1}{z}, xmm |  | 
        /// </summary>
        [Symbol("vpmovqb m16 {k1}{z}, xmm","vpmovqb m16 {k1}{z}, xmm |  | ")]
        vpmovqb_m16_k1z_xmm = 3400,

        /// <summary>
        /// vpmovqb m16, xmm |  | 
        /// </summary>
        [Symbol("vpmovqb m16, xmm","vpmovqb m16, xmm |  | ")]
        vpmovqb_m16_xmm = 3401,

        /// <summary>
        /// vpmovqb m32 {k1}{z}, ymm |  | 
        /// </summary>
        [Symbol("vpmovqb m32 {k1}{z}, ymm","vpmovqb m32 {k1}{z}, ymm |  | ")]
        vpmovqb_m32_k1z_ymm = 3402,

        /// <summary>
        /// vpmovqb m32, ymm |  | 
        /// </summary>
        [Symbol("vpmovqb m32, ymm","vpmovqb m32, ymm |  | ")]
        vpmovqb_m32_ymm = 3403,

        /// <summary>
        /// vpmovqb m64 {k1}{z}, zmm |  | 
        /// </summary>
        [Symbol("vpmovqb m64 {k1}{z}, zmm","vpmovqb m64 {k1}{z}, zmm |  | ")]
        vpmovqb_m64_k1z_zmm = 3404,

        /// <summary>
        /// vpmovqb m64, zmm |  | 
        /// </summary>
        [Symbol("vpmovqb m64, zmm","vpmovqb m64, zmm |  | ")]
        vpmovqb_m64_zmm = 3405,

        /// <summary>
        /// vpmovqb r8 {k1}{z}, xmm |  | 
        /// </summary>
        [Symbol("vpmovqb r8 {k1}{z}, xmm","vpmovqb r8 {k1}{z}, xmm |  | ")]
        vpmovqb_r8_k1z_xmm = 3406,

        /// <summary>
        /// vpmovqb r8 {k1}{z}, ymm |  | 
        /// </summary>
        [Symbol("vpmovqb r8 {k1}{z}, ymm","vpmovqb r8 {k1}{z}, ymm |  | ")]
        vpmovqb_r8_k1z_ymm = 3407,

        /// <summary>
        /// vpmovqb r8 {k1}{z}, zmm |  | 
        /// </summary>
        [Symbol("vpmovqb r8 {k1}{z}, zmm","vpmovqb r8 {k1}{z}, zmm |  | ")]
        vpmovqb_r8_k1z_zmm = 3408,

        /// <summary>
        /// vpmovqb r8, xmm |  | 
        /// </summary>
        [Symbol("vpmovqb r8, xmm","vpmovqb r8, xmm |  | ")]
        vpmovqb_r8_xmm = 3409,

        /// <summary>
        /// vpmovqb r8, ymm |  | 
        /// </summary>
        [Symbol("vpmovqb r8, ymm","vpmovqb r8, ymm |  | ")]
        vpmovqb_r8_ymm = 3410,

        /// <summary>
        /// vpmovqb r8, zmm |  | 
        /// </summary>
        [Symbol("vpmovqb r8, zmm","vpmovqb r8, zmm |  | ")]
        vpmovqb_r8_zmm = 3411,

        /// <summary>
        /// vpmovqd m128 {k1}{z}, xmm |  | 
        /// </summary>
        [Symbol("vpmovqd m128 {k1}{z}, xmm","vpmovqd m128 {k1}{z}, xmm |  | ")]
        vpmovqd_m128_k1z_xmm = 3412,

        /// <summary>
        /// vpmovqd m128 {k1}{z}, ymm |  | 
        /// </summary>
        [Symbol("vpmovqd m128 {k1}{z}, ymm","vpmovqd m128 {k1}{z}, ymm |  | ")]
        vpmovqd_m128_k1z_ymm = 3413,

        /// <summary>
        /// vpmovqd m128, xmm |  | 
        /// </summary>
        [Symbol("vpmovqd m128, xmm","vpmovqd m128, xmm |  | ")]
        vpmovqd_m128_xmm = 3414,

        /// <summary>
        /// vpmovqd m128, ymm |  | 
        /// </summary>
        [Symbol("vpmovqd m128, ymm","vpmovqd m128, ymm |  | ")]
        vpmovqd_m128_ymm = 3415,

        /// <summary>
        /// vpmovqd m256 {k1}{z}, zmm |  | 
        /// </summary>
        [Symbol("vpmovqd m256 {k1}{z}, zmm","vpmovqd m256 {k1}{z}, zmm |  | ")]
        vpmovqd_m256_k1z_zmm = 3416,

        /// <summary>
        /// vpmovqd m256, zmm |  | 
        /// </summary>
        [Symbol("vpmovqd m256, zmm","vpmovqd m256, zmm |  | ")]
        vpmovqd_m256_zmm = 3417,

        /// <summary>
        /// vpmovqd r16 {k1}{z}, zmm |  | 
        /// </summary>
        [Symbol("vpmovqd r16 {k1}{z}, zmm","vpmovqd r16 {k1}{z}, zmm |  | ")]
        vpmovqd_r16_k1z_zmm = 3418,

        /// <summary>
        /// vpmovqd r16, zmm |  | 
        /// </summary>
        [Symbol("vpmovqd r16, zmm","vpmovqd r16, zmm |  | ")]
        vpmovqd_r16_zmm = 3419,

        /// <summary>
        /// vpmovqd r8 {k1}{z}, xmm |  | 
        /// </summary>
        [Symbol("vpmovqd r8 {k1}{z}, xmm","vpmovqd r8 {k1}{z}, xmm |  | ")]
        vpmovqd_r8_k1z_xmm = 3420,

        /// <summary>
        /// vpmovqd r8 {k1}{z}, ymm |  | 
        /// </summary>
        [Symbol("vpmovqd r8 {k1}{z}, ymm","vpmovqd r8 {k1}{z}, ymm |  | ")]
        vpmovqd_r8_k1z_ymm = 3421,

        /// <summary>
        /// vpmovqd r8, xmm |  | 
        /// </summary>
        [Symbol("vpmovqd r8, xmm","vpmovqd r8, xmm |  | ")]
        vpmovqd_r8_xmm = 3422,

        /// <summary>
        /// vpmovqd r8, ymm |  | 
        /// </summary>
        [Symbol("vpmovqd r8, ymm","vpmovqd r8, ymm |  | ")]
        vpmovqd_r8_ymm = 3423,

        /// <summary>
        /// vpmovqw m128 {k1}{z}, zmm |  | 
        /// </summary>
        [Symbol("vpmovqw m128 {k1}{z}, zmm","vpmovqw m128 {k1}{z}, zmm |  | ")]
        vpmovqw_m128_k1z_zmm = 3424,

        /// <summary>
        /// vpmovqw m128, zmm |  | 
        /// </summary>
        [Symbol("vpmovqw m128, zmm","vpmovqw m128, zmm |  | ")]
        vpmovqw_m128_zmm = 3425,

        /// <summary>
        /// vpmovqw m32 {k1}{z}, xmm |  | 
        /// </summary>
        [Symbol("vpmovqw m32 {k1}{z}, xmm","vpmovqw m32 {k1}{z}, xmm |  | ")]
        vpmovqw_m32_k1z_xmm = 3426,

        /// <summary>
        /// vpmovqw m32, xmm |  | 
        /// </summary>
        [Symbol("vpmovqw m32, xmm","vpmovqw m32, xmm |  | ")]
        vpmovqw_m32_xmm = 3427,

        /// <summary>
        /// vpmovqw m64 {k1}{z}, ymm |  | 
        /// </summary>
        [Symbol("vpmovqw m64 {k1}{z}, ymm","vpmovqw m64 {k1}{z}, ymm |  | ")]
        vpmovqw_m64_k1z_ymm = 3428,

        /// <summary>
        /// vpmovqw m64, ymm |  | 
        /// </summary>
        [Symbol("vpmovqw m64, ymm","vpmovqw m64, ymm |  | ")]
        vpmovqw_m64_ymm = 3429,

        /// <summary>
        /// vpmovqw r8 {k1}{z}, xmm |  | 
        /// </summary>
        [Symbol("vpmovqw r8 {k1}{z}, xmm","vpmovqw r8 {k1}{z}, xmm |  | ")]
        vpmovqw_r8_k1z_xmm = 3430,

        /// <summary>
        /// vpmovqw r8 {k1}{z}, ymm |  | 
        /// </summary>
        [Symbol("vpmovqw r8 {k1}{z}, ymm","vpmovqw r8 {k1}{z}, ymm |  | ")]
        vpmovqw_r8_k1z_ymm = 3431,

        /// <summary>
        /// vpmovqw r8 {k1}{z}, zmm |  | 
        /// </summary>
        [Symbol("vpmovqw r8 {k1}{z}, zmm","vpmovqw r8 {k1}{z}, zmm |  | ")]
        vpmovqw_r8_k1z_zmm = 3432,

        /// <summary>
        /// vpmovqw r8, xmm |  | 
        /// </summary>
        [Symbol("vpmovqw r8, xmm","vpmovqw r8, xmm |  | ")]
        vpmovqw_r8_xmm = 3433,

        /// <summary>
        /// vpmovqw r8, ymm |  | 
        /// </summary>
        [Symbol("vpmovqw r8, ymm","vpmovqw r8, ymm |  | ")]
        vpmovqw_r8_ymm = 3434,

        /// <summary>
        /// vpmovqw r8, zmm |  | 
        /// </summary>
        [Symbol("vpmovqw r8, zmm","vpmovqw r8, zmm |  | ")]
        vpmovqw_r8_zmm = 3435,

        /// <summary>
        /// vpmovsdb m128 {k1}{z}, zmm |  | 
        /// </summary>
        [Symbol("vpmovsdb m128 {k1}{z}, zmm","vpmovsdb m128 {k1}{z}, zmm |  | ")]
        vpmovsdb_m128_k1z_zmm = 3436,

        /// <summary>
        /// vpmovsdb m128, zmm |  | 
        /// </summary>
        [Symbol("vpmovsdb m128, zmm","vpmovsdb m128, zmm |  | ")]
        vpmovsdb_m128_zmm = 3437,

        /// <summary>
        /// vpmovsdb m32 {k1}{z}, xmm |  | 
        /// </summary>
        [Symbol("vpmovsdb m32 {k1}{z}, xmm","vpmovsdb m32 {k1}{z}, xmm |  | ")]
        vpmovsdb_m32_k1z_xmm = 3438,

        /// <summary>
        /// vpmovsdb m32, xmm |  | 
        /// </summary>
        [Symbol("vpmovsdb m32, xmm","vpmovsdb m32, xmm |  | ")]
        vpmovsdb_m32_xmm = 3439,

        /// <summary>
        /// vpmovsdb m64 {k1}{z}, ymm |  | 
        /// </summary>
        [Symbol("vpmovsdb m64 {k1}{z}, ymm","vpmovsdb m64 {k1}{z}, ymm |  | ")]
        vpmovsdb_m64_k1z_ymm = 3440,

        /// <summary>
        /// vpmovsdb m64, ymm |  | 
        /// </summary>
        [Symbol("vpmovsdb m64, ymm","vpmovsdb m64, ymm |  | ")]
        vpmovsdb_m64_ymm = 3441,

        /// <summary>
        /// vpmovsdb r8 {k1}{z}, xmm |  | 
        /// </summary>
        [Symbol("vpmovsdb r8 {k1}{z}, xmm","vpmovsdb r8 {k1}{z}, xmm |  | ")]
        vpmovsdb_r8_k1z_xmm = 3442,

        /// <summary>
        /// vpmovsdb r8 {k1}{z}, ymm |  | 
        /// </summary>
        [Symbol("vpmovsdb r8 {k1}{z}, ymm","vpmovsdb r8 {k1}{z}, ymm |  | ")]
        vpmovsdb_r8_k1z_ymm = 3443,

        /// <summary>
        /// vpmovsdb r8 {k1}{z}, zmm |  | 
        /// </summary>
        [Symbol("vpmovsdb r8 {k1}{z}, zmm","vpmovsdb r8 {k1}{z}, zmm |  | ")]
        vpmovsdb_r8_k1z_zmm = 3444,

        /// <summary>
        /// vpmovsdb r8, xmm |  | 
        /// </summary>
        [Symbol("vpmovsdb r8, xmm","vpmovsdb r8, xmm |  | ")]
        vpmovsdb_r8_xmm = 3445,

        /// <summary>
        /// vpmovsdb r8, ymm |  | 
        /// </summary>
        [Symbol("vpmovsdb r8, ymm","vpmovsdb r8, ymm |  | ")]
        vpmovsdb_r8_ymm = 3446,

        /// <summary>
        /// vpmovsdb r8, zmm |  | 
        /// </summary>
        [Symbol("vpmovsdb r8, zmm","vpmovsdb r8, zmm |  | ")]
        vpmovsdb_r8_zmm = 3447,

        /// <summary>
        /// vpmovsdw m128 {k1}{z}, ymm |  | 
        /// </summary>
        [Symbol("vpmovsdw m128 {k1}{z}, ymm","vpmovsdw m128 {k1}{z}, ymm |  | ")]
        vpmovsdw_m128_k1z_ymm = 3448,

        /// <summary>
        /// vpmovsdw m128, ymm |  | 
        /// </summary>
        [Symbol("vpmovsdw m128, ymm","vpmovsdw m128, ymm |  | ")]
        vpmovsdw_m128_ymm = 3449,

        /// <summary>
        /// vpmovsdw m256 {k1}{z}, zmm |  | 
        /// </summary>
        [Symbol("vpmovsdw m256 {k1}{z}, zmm","vpmovsdw m256 {k1}{z}, zmm |  | ")]
        vpmovsdw_m256_k1z_zmm = 3450,

        /// <summary>
        /// vpmovsdw m256, zmm |  | 
        /// </summary>
        [Symbol("vpmovsdw m256, zmm","vpmovsdw m256, zmm |  | ")]
        vpmovsdw_m256_zmm = 3451,

        /// <summary>
        /// vpmovsdw m64 {k1}{z}, xmm |  | 
        /// </summary>
        [Symbol("vpmovsdw m64 {k1}{z}, xmm","vpmovsdw m64 {k1}{z}, xmm |  | ")]
        vpmovsdw_m64_k1z_xmm = 3452,

        /// <summary>
        /// vpmovsdw m64, xmm |  | 
        /// </summary>
        [Symbol("vpmovsdw m64, xmm","vpmovsdw m64, xmm |  | ")]
        vpmovsdw_m64_xmm = 3453,

        /// <summary>
        /// vpmovsdw r16 {k1}{z}, zmm |  | 
        /// </summary>
        [Symbol("vpmovsdw r16 {k1}{z}, zmm","vpmovsdw r16 {k1}{z}, zmm |  | ")]
        vpmovsdw_r16_k1z_zmm = 3454,

        /// <summary>
        /// vpmovsdw r16, zmm |  | 
        /// </summary>
        [Symbol("vpmovsdw r16, zmm","vpmovsdw r16, zmm |  | ")]
        vpmovsdw_r16_zmm = 3455,

        /// <summary>
        /// vpmovsdw r8 {k1}{z}, xmm |  | 
        /// </summary>
        [Symbol("vpmovsdw r8 {k1}{z}, xmm","vpmovsdw r8 {k1}{z}, xmm |  | ")]
        vpmovsdw_r8_k1z_xmm = 3456,

        /// <summary>
        /// vpmovsdw r8 {k1}{z}, ymm |  | 
        /// </summary>
        [Symbol("vpmovsdw r8 {k1}{z}, ymm","vpmovsdw r8 {k1}{z}, ymm |  | ")]
        vpmovsdw_r8_k1z_ymm = 3457,

        /// <summary>
        /// vpmovsdw r8, xmm |  | 
        /// </summary>
        [Symbol("vpmovsdw r8, xmm","vpmovsdw r8, xmm |  | ")]
        vpmovsdw_r8_xmm = 3458,

        /// <summary>
        /// vpmovsdw r8, ymm |  | 
        /// </summary>
        [Symbol("vpmovsdw r8, ymm","vpmovsdw r8, ymm |  | ")]
        vpmovsdw_r8_ymm = 3459,

        /// <summary>
        /// vpmovsqb m16 {k1}{z}, xmm |  | 
        /// </summary>
        [Symbol("vpmovsqb m16 {k1}{z}, xmm","vpmovsqb m16 {k1}{z}, xmm |  | ")]
        vpmovsqb_m16_k1z_xmm = 3460,

        /// <summary>
        /// vpmovsqb m16, xmm |  | 
        /// </summary>
        [Symbol("vpmovsqb m16, xmm","vpmovsqb m16, xmm |  | ")]
        vpmovsqb_m16_xmm = 3461,

        /// <summary>
        /// vpmovsqb m32 {k1}{z}, ymm |  | 
        /// </summary>
        [Symbol("vpmovsqb m32 {k1}{z}, ymm","vpmovsqb m32 {k1}{z}, ymm |  | ")]
        vpmovsqb_m32_k1z_ymm = 3462,

        /// <summary>
        /// vpmovsqb m32, ymm |  | 
        /// </summary>
        [Symbol("vpmovsqb m32, ymm","vpmovsqb m32, ymm |  | ")]
        vpmovsqb_m32_ymm = 3463,

        /// <summary>
        /// vpmovsqb m64 {k1}{z}, zmm |  | 
        /// </summary>
        [Symbol("vpmovsqb m64 {k1}{z}, zmm","vpmovsqb m64 {k1}{z}, zmm |  | ")]
        vpmovsqb_m64_k1z_zmm = 3464,

        /// <summary>
        /// vpmovsqb m64, zmm |  | 
        /// </summary>
        [Symbol("vpmovsqb m64, zmm","vpmovsqb m64, zmm |  | ")]
        vpmovsqb_m64_zmm = 3465,

        /// <summary>
        /// vpmovsqb r8 {k1}{z}, xmm |  | 
        /// </summary>
        [Symbol("vpmovsqb r8 {k1}{z}, xmm","vpmovsqb r8 {k1}{z}, xmm |  | ")]
        vpmovsqb_r8_k1z_xmm = 3466,

        /// <summary>
        /// vpmovsqb r8 {k1}{z}, ymm |  | 
        /// </summary>
        [Symbol("vpmovsqb r8 {k1}{z}, ymm","vpmovsqb r8 {k1}{z}, ymm |  | ")]
        vpmovsqb_r8_k1z_ymm = 3467,

        /// <summary>
        /// vpmovsqb r8 {k1}{z}, zmm |  | 
        /// </summary>
        [Symbol("vpmovsqb r8 {k1}{z}, zmm","vpmovsqb r8 {k1}{z}, zmm |  | ")]
        vpmovsqb_r8_k1z_zmm = 3468,

        /// <summary>
        /// vpmovsqb r8, xmm |  | 
        /// </summary>
        [Symbol("vpmovsqb r8, xmm","vpmovsqb r8, xmm |  | ")]
        vpmovsqb_r8_xmm = 3469,

        /// <summary>
        /// vpmovsqb r8, ymm |  | 
        /// </summary>
        [Symbol("vpmovsqb r8, ymm","vpmovsqb r8, ymm |  | ")]
        vpmovsqb_r8_ymm = 3470,

        /// <summary>
        /// vpmovsqb r8, zmm |  | 
        /// </summary>
        [Symbol("vpmovsqb r8, zmm","vpmovsqb r8, zmm |  | ")]
        vpmovsqb_r8_zmm = 3471,

        /// <summary>
        /// vpmovsqd m128 {k1}{z}, ymm |  | 
        /// </summary>
        [Symbol("vpmovsqd m128 {k1}{z}, ymm","vpmovsqd m128 {k1}{z}, ymm |  | ")]
        vpmovsqd_m128_k1z_ymm = 3472,

        /// <summary>
        /// vpmovsqd m128, ymm |  | 
        /// </summary>
        [Symbol("vpmovsqd m128, ymm","vpmovsqd m128, ymm |  | ")]
        vpmovsqd_m128_ymm = 3473,

        /// <summary>
        /// vpmovsqd m256 {k1}{z}, zmm |  | 
        /// </summary>
        [Symbol("vpmovsqd m256 {k1}{z}, zmm","vpmovsqd m256 {k1}{z}, zmm |  | ")]
        vpmovsqd_m256_k1z_zmm = 3474,

        /// <summary>
        /// vpmovsqd m256, zmm |  | 
        /// </summary>
        [Symbol("vpmovsqd m256, zmm","vpmovsqd m256, zmm |  | ")]
        vpmovsqd_m256_zmm = 3475,

        /// <summary>
        /// vpmovsqd m64 {k1}{z}, xmm |  | 
        /// </summary>
        [Symbol("vpmovsqd m64 {k1}{z}, xmm","vpmovsqd m64 {k1}{z}, xmm |  | ")]
        vpmovsqd_m64_k1z_xmm = 3476,

        /// <summary>
        /// vpmovsqd m64, xmm |  | 
        /// </summary>
        [Symbol("vpmovsqd m64, xmm","vpmovsqd m64, xmm |  | ")]
        vpmovsqd_m64_xmm = 3477,

        /// <summary>
        /// vpmovsqd r16 {k1}{z}, zmm |  | 
        /// </summary>
        [Symbol("vpmovsqd r16 {k1}{z}, zmm","vpmovsqd r16 {k1}{z}, zmm |  | ")]
        vpmovsqd_r16_k1z_zmm = 3478,

        /// <summary>
        /// vpmovsqd r16, zmm |  | 
        /// </summary>
        [Symbol("vpmovsqd r16, zmm","vpmovsqd r16, zmm |  | ")]
        vpmovsqd_r16_zmm = 3479,

        /// <summary>
        /// vpmovsqd r8 {k1}{z}, xmm |  | 
        /// </summary>
        [Symbol("vpmovsqd r8 {k1}{z}, xmm","vpmovsqd r8 {k1}{z}, xmm |  | ")]
        vpmovsqd_r8_k1z_xmm = 3480,

        /// <summary>
        /// vpmovsqd r8 {k1}{z}, ymm |  | 
        /// </summary>
        [Symbol("vpmovsqd r8 {k1}{z}, ymm","vpmovsqd r8 {k1}{z}, ymm |  | ")]
        vpmovsqd_r8_k1z_ymm = 3481,

        /// <summary>
        /// vpmovsqd r8, xmm |  | 
        /// </summary>
        [Symbol("vpmovsqd r8, xmm","vpmovsqd r8, xmm |  | ")]
        vpmovsqd_r8_xmm = 3482,

        /// <summary>
        /// vpmovsqd r8, ymm |  | 
        /// </summary>
        [Symbol("vpmovsqd r8, ymm","vpmovsqd r8, ymm |  | ")]
        vpmovsqd_r8_ymm = 3483,

        /// <summary>
        /// vpmovsqw m128 {k1}{z}, zmm |  | 
        /// </summary>
        [Symbol("vpmovsqw m128 {k1}{z}, zmm","vpmovsqw m128 {k1}{z}, zmm |  | ")]
        vpmovsqw_m128_k1z_zmm = 3484,

        /// <summary>
        /// vpmovsqw m128, zmm |  | 
        /// </summary>
        [Symbol("vpmovsqw m128, zmm","vpmovsqw m128, zmm |  | ")]
        vpmovsqw_m128_zmm = 3485,

        /// <summary>
        /// vpmovsqw m32 {k1}{z}, xmm |  | 
        /// </summary>
        [Symbol("vpmovsqw m32 {k1}{z}, xmm","vpmovsqw m32 {k1}{z}, xmm |  | ")]
        vpmovsqw_m32_k1z_xmm = 3486,

        /// <summary>
        /// vpmovsqw m32, xmm |  | 
        /// </summary>
        [Symbol("vpmovsqw m32, xmm","vpmovsqw m32, xmm |  | ")]
        vpmovsqw_m32_xmm = 3487,

        /// <summary>
        /// vpmovsqw m64 {k1}{z}, ymm |  | 
        /// </summary>
        [Symbol("vpmovsqw m64 {k1}{z}, ymm","vpmovsqw m64 {k1}{z}, ymm |  | ")]
        vpmovsqw_m64_k1z_ymm = 3488,

        /// <summary>
        /// vpmovsqw m64, ymm |  | 
        /// </summary>
        [Symbol("vpmovsqw m64, ymm","vpmovsqw m64, ymm |  | ")]
        vpmovsqw_m64_ymm = 3489,

        /// <summary>
        /// vpmovsqw r8 {k1}{z}, xmm |  | 
        /// </summary>
        [Symbol("vpmovsqw r8 {k1}{z}, xmm","vpmovsqw r8 {k1}{z}, xmm |  | ")]
        vpmovsqw_r8_k1z_xmm = 3490,

        /// <summary>
        /// vpmovsqw r8 {k1}{z}, ymm |  | 
        /// </summary>
        [Symbol("vpmovsqw r8 {k1}{z}, ymm","vpmovsqw r8 {k1}{z}, ymm |  | ")]
        vpmovsqw_r8_k1z_ymm = 3491,

        /// <summary>
        /// vpmovsqw r8 {k1}{z}, zmm |  | 
        /// </summary>
        [Symbol("vpmovsqw r8 {k1}{z}, zmm","vpmovsqw r8 {k1}{z}, zmm |  | ")]
        vpmovsqw_r8_k1z_zmm = 3492,

        /// <summary>
        /// vpmovsqw r8, xmm |  | 
        /// </summary>
        [Symbol("vpmovsqw r8, xmm","vpmovsqw r8, xmm |  | ")]
        vpmovsqw_r8_xmm = 3493,

        /// <summary>
        /// vpmovsqw r8, ymm |  | 
        /// </summary>
        [Symbol("vpmovsqw r8, ymm","vpmovsqw r8, ymm |  | ")]
        vpmovsqw_r8_ymm = 3494,

        /// <summary>
        /// vpmovsqw r8, zmm |  | 
        /// </summary>
        [Symbol("vpmovsqw r8, zmm","vpmovsqw r8, zmm |  | ")]
        vpmovsqw_r8_zmm = 3495,

        /// <summary>
        /// vpmovswb m128 {k1}{z}, ymm |  | 
        /// </summary>
        [Symbol("vpmovswb m128 {k1}{z}, ymm","vpmovswb m128 {k1}{z}, ymm |  | ")]
        vpmovswb_m128_k1z_ymm = 3496,

        /// <summary>
        /// vpmovswb m128, ymm |  | 
        /// </summary>
        [Symbol("vpmovswb m128, ymm","vpmovswb m128, ymm |  | ")]
        vpmovswb_m128_ymm = 3497,

        /// <summary>
        /// vpmovswb m256 {k1}{z}, zmm |  | 
        /// </summary>
        [Symbol("vpmovswb m256 {k1}{z}, zmm","vpmovswb m256 {k1}{z}, zmm |  | ")]
        vpmovswb_m256_k1z_zmm = 3498,

        /// <summary>
        /// vpmovswb m256, zmm |  | 
        /// </summary>
        [Symbol("vpmovswb m256, zmm","vpmovswb m256, zmm |  | ")]
        vpmovswb_m256_zmm = 3499,

        /// <summary>
        /// vpmovswb m64 {k1}{z}, xmm |  | 
        /// </summary>
        [Symbol("vpmovswb m64 {k1}{z}, xmm","vpmovswb m64 {k1}{z}, xmm |  | ")]
        vpmovswb_m64_k1z_xmm = 3500,

        /// <summary>
        /// vpmovswb m64, xmm |  | 
        /// </summary>
        [Symbol("vpmovswb m64, xmm","vpmovswb m64, xmm |  | ")]
        vpmovswb_m64_xmm = 3501,

        /// <summary>
        /// vpmovswb r16 {k1}{z}, zmm |  | 
        /// </summary>
        [Symbol("vpmovswb r16 {k1}{z}, zmm","vpmovswb r16 {k1}{z}, zmm |  | ")]
        vpmovswb_r16_k1z_zmm = 3502,

        /// <summary>
        /// vpmovswb r16, zmm |  | 
        /// </summary>
        [Symbol("vpmovswb r16, zmm","vpmovswb r16, zmm |  | ")]
        vpmovswb_r16_zmm = 3503,

        /// <summary>
        /// vpmovswb r8 {k1}{z}, xmm |  | 
        /// </summary>
        [Symbol("vpmovswb r8 {k1}{z}, xmm","vpmovswb r8 {k1}{z}, xmm |  | ")]
        vpmovswb_r8_k1z_xmm = 3504,

        /// <summary>
        /// vpmovswb r8 {k1}{z}, ymm |  | 
        /// </summary>
        [Symbol("vpmovswb r8 {k1}{z}, ymm","vpmovswb r8 {k1}{z}, ymm |  | ")]
        vpmovswb_r8_k1z_ymm = 3505,

        /// <summary>
        /// vpmovswb r8, xmm |  | 
        /// </summary>
        [Symbol("vpmovswb r8, xmm","vpmovswb r8, xmm |  | ")]
        vpmovswb_r8_xmm = 3506,

        /// <summary>
        /// vpmovswb r8, ymm |  | 
        /// </summary>
        [Symbol("vpmovswb r8, ymm","vpmovswb r8, ymm |  | ")]
        vpmovswb_r8_ymm = 3507,

        /// <summary>
        /// vpmovsxbd xmm {k1}{z}, m32 |  | 
        /// </summary>
        [Symbol("vpmovsxbd xmm {k1}{z}, m32","vpmovsxbd xmm {k1}{z}, m32 |  | ")]
        vpmovsxbd_xmm_k1z_m32 = 3508,

        /// <summary>
        /// vpmovsxbd xmm {k1}{z}, r8 |  | 
        /// </summary>
        [Symbol("vpmovsxbd xmm {k1}{z}, r8","vpmovsxbd xmm {k1}{z}, r8 |  | ")]
        vpmovsxbd_xmm_k1z_r8 = 3509,

        /// <summary>
        /// vpmovsxbd xmm, m32 |  | 
        /// </summary>
        [Symbol("vpmovsxbd xmm, m32","vpmovsxbd xmm, m32 |  | ")]
        vpmovsxbd_xmm_m32 = 3510,

        /// <summary>
        /// vpmovsxbd xmm, r8 |  | 
        /// </summary>
        [Symbol("vpmovsxbd xmm, r8","vpmovsxbd xmm, r8 |  | ")]
        vpmovsxbd_xmm_r8 = 3511,

        /// <summary>
        /// vpmovsxbd ymm {k1}{z}, m64 |  | 
        /// </summary>
        [Symbol("vpmovsxbd ymm {k1}{z}, m64","vpmovsxbd ymm {k1}{z}, m64 |  | ")]
        vpmovsxbd_ymm_k1z_m64 = 3512,

        /// <summary>
        /// vpmovsxbd ymm {k1}{z}, r8 |  | 
        /// </summary>
        [Symbol("vpmovsxbd ymm {k1}{z}, r8","vpmovsxbd ymm {k1}{z}, r8 |  | ")]
        vpmovsxbd_ymm_k1z_r8 = 3513,

        /// <summary>
        /// vpmovsxbd ymm, m64 |  | 
        /// </summary>
        [Symbol("vpmovsxbd ymm, m64","vpmovsxbd ymm, m64 |  | ")]
        vpmovsxbd_ymm_m64 = 3514,

        /// <summary>
        /// vpmovsxbd ymm, r8 |  | 
        /// </summary>
        [Symbol("vpmovsxbd ymm, r8","vpmovsxbd ymm, r8 |  | ")]
        vpmovsxbd_ymm_r8 = 3515,

        /// <summary>
        /// vpmovsxbd zmm {k1}{z}, m128 |  | 
        /// </summary>
        [Symbol("vpmovsxbd zmm {k1}{z}, m128","vpmovsxbd zmm {k1}{z}, m128 |  | ")]
        vpmovsxbd_zmm_k1z_m128 = 3516,

        /// <summary>
        /// vpmovsxbd zmm {k1}{z}, r8 |  | 
        /// </summary>
        [Symbol("vpmovsxbd zmm {k1}{z}, r8","vpmovsxbd zmm {k1}{z}, r8 |  | ")]
        vpmovsxbd_zmm_k1z_r8 = 3517,

        /// <summary>
        /// vpmovsxbd zmm, m128 |  | 
        /// </summary>
        [Symbol("vpmovsxbd zmm, m128","vpmovsxbd zmm, m128 |  | ")]
        vpmovsxbd_zmm_m128 = 3518,

        /// <summary>
        /// vpmovsxbd zmm, r8 |  | 
        /// </summary>
        [Symbol("vpmovsxbd zmm, r8","vpmovsxbd zmm, r8 |  | ")]
        vpmovsxbd_zmm_r8 = 3519,

        /// <summary>
        /// vpmovsxbq xmm {k1}{z}, m16 |  | 
        /// </summary>
        [Symbol("vpmovsxbq xmm {k1}{z}, m16","vpmovsxbq xmm {k1}{z}, m16 |  | ")]
        vpmovsxbq_xmm_k1z_m16 = 3520,

        /// <summary>
        /// vpmovsxbq xmm {k1}{z}, r8 |  | 
        /// </summary>
        [Symbol("vpmovsxbq xmm {k1}{z}, r8","vpmovsxbq xmm {k1}{z}, r8 |  | ")]
        vpmovsxbq_xmm_k1z_r8 = 3521,

        /// <summary>
        /// vpmovsxbq xmm, m16 |  | 
        /// </summary>
        [Symbol("vpmovsxbq xmm, m16","vpmovsxbq xmm, m16 |  | ")]
        vpmovsxbq_xmm_m16 = 3522,

        /// <summary>
        /// vpmovsxbq xmm, r8 |  | 
        /// </summary>
        [Symbol("vpmovsxbq xmm, r8","vpmovsxbq xmm, r8 |  | ")]
        vpmovsxbq_xmm_r8 = 3523,

        /// <summary>
        /// vpmovsxbq ymm {k1}{z}, m32 |  | 
        /// </summary>
        [Symbol("vpmovsxbq ymm {k1}{z}, m32","vpmovsxbq ymm {k1}{z}, m32 |  | ")]
        vpmovsxbq_ymm_k1z_m32 = 3524,

        /// <summary>
        /// vpmovsxbq ymm {k1}{z}, r8 |  | 
        /// </summary>
        [Symbol("vpmovsxbq ymm {k1}{z}, r8","vpmovsxbq ymm {k1}{z}, r8 |  | ")]
        vpmovsxbq_ymm_k1z_r8 = 3525,

        /// <summary>
        /// vpmovsxbq ymm, m32 |  | 
        /// </summary>
        [Symbol("vpmovsxbq ymm, m32","vpmovsxbq ymm, m32 |  | ")]
        vpmovsxbq_ymm_m32 = 3526,

        /// <summary>
        /// vpmovsxbq ymm, r8 |  | 
        /// </summary>
        [Symbol("vpmovsxbq ymm, r8","vpmovsxbq ymm, r8 |  | ")]
        vpmovsxbq_ymm_r8 = 3527,

        /// <summary>
        /// vpmovsxbq zmm {k1}{z}, m64 |  | 
        /// </summary>
        [Symbol("vpmovsxbq zmm {k1}{z}, m64","vpmovsxbq zmm {k1}{z}, m64 |  | ")]
        vpmovsxbq_zmm_k1z_m64 = 3528,

        /// <summary>
        /// vpmovsxbq zmm {k1}{z}, r8 |  | 
        /// </summary>
        [Symbol("vpmovsxbq zmm {k1}{z}, r8","vpmovsxbq zmm {k1}{z}, r8 |  | ")]
        vpmovsxbq_zmm_k1z_r8 = 3529,

        /// <summary>
        /// vpmovsxbq zmm, m64 |  | 
        /// </summary>
        [Symbol("vpmovsxbq zmm, m64","vpmovsxbq zmm, m64 |  | ")]
        vpmovsxbq_zmm_m64 = 3530,

        /// <summary>
        /// vpmovsxbq zmm, r8 |  | 
        /// </summary>
        [Symbol("vpmovsxbq zmm, r8","vpmovsxbq zmm, r8 |  | ")]
        vpmovsxbq_zmm_r8 = 3531,

        /// <summary>
        /// vpmovsxbw xmm {k1}{z}, m64 |  | 
        /// </summary>
        [Symbol("vpmovsxbw xmm {k1}{z}, m64","vpmovsxbw xmm {k1}{z}, m64 |  | ")]
        vpmovsxbw_xmm_k1z_m64 = 3532,

        /// <summary>
        /// vpmovsxbw xmm {k1}{z}, r8 |  | 
        /// </summary>
        [Symbol("vpmovsxbw xmm {k1}{z}, r8","vpmovsxbw xmm {k1}{z}, r8 |  | ")]
        vpmovsxbw_xmm_k1z_r8 = 3533,

        /// <summary>
        /// vpmovsxbw xmm, m64 |  | 
        /// </summary>
        [Symbol("vpmovsxbw xmm, m64","vpmovsxbw xmm, m64 |  | ")]
        vpmovsxbw_xmm_m64 = 3534,

        /// <summary>
        /// vpmovsxbw xmm, r8 |  | 
        /// </summary>
        [Symbol("vpmovsxbw xmm, r8","vpmovsxbw xmm, r8 |  | ")]
        vpmovsxbw_xmm_r8 = 3535,

        /// <summary>
        /// vpmovsxbw ymm {k1}{z}, m128 |  | 
        /// </summary>
        [Symbol("vpmovsxbw ymm {k1}{z}, m128","vpmovsxbw ymm {k1}{z}, m128 |  | ")]
        vpmovsxbw_ymm_k1z_m128 = 3536,

        /// <summary>
        /// vpmovsxbw ymm {k1}{z}, r8 |  | 
        /// </summary>
        [Symbol("vpmovsxbw ymm {k1}{z}, r8","vpmovsxbw ymm {k1}{z}, r8 |  | ")]
        vpmovsxbw_ymm_k1z_r8 = 3537,

        /// <summary>
        /// vpmovsxbw ymm, m128 |  | 
        /// </summary>
        [Symbol("vpmovsxbw ymm, m128","vpmovsxbw ymm, m128 |  | ")]
        vpmovsxbw_ymm_m128 = 3538,

        /// <summary>
        /// vpmovsxbw ymm, r8 |  | 
        /// </summary>
        [Symbol("vpmovsxbw ymm, r8","vpmovsxbw ymm, r8 |  | ")]
        vpmovsxbw_ymm_r8 = 3539,

        /// <summary>
        /// vpmovsxbw zmm {k1}{z}, m256 |  | 
        /// </summary>
        [Symbol("vpmovsxbw zmm {k1}{z}, m256","vpmovsxbw zmm {k1}{z}, m256 |  | ")]
        vpmovsxbw_zmm_k1z_m256 = 3540,

        /// <summary>
        /// vpmovsxbw zmm {k1}{z}, r16 |  | 
        /// </summary>
        [Symbol("vpmovsxbw zmm {k1}{z}, r16","vpmovsxbw zmm {k1}{z}, r16 |  | ")]
        vpmovsxbw_zmm_k1z_r16 = 3541,

        /// <summary>
        /// vpmovsxbw zmm, m256 |  | 
        /// </summary>
        [Symbol("vpmovsxbw zmm, m256","vpmovsxbw zmm, m256 |  | ")]
        vpmovsxbw_zmm_m256 = 3542,

        /// <summary>
        /// vpmovsxbw zmm, r16 |  | 
        /// </summary>
        [Symbol("vpmovsxbw zmm, r16","vpmovsxbw zmm, r16 |  | ")]
        vpmovsxbw_zmm_r16 = 3543,

        /// <summary>
        /// vpmovsxdq xmm {k1}{z}, m64 |  | 
        /// </summary>
        [Symbol("vpmovsxdq xmm {k1}{z}, m64","vpmovsxdq xmm {k1}{z}, m64 |  | ")]
        vpmovsxdq_xmm_k1z_m64 = 3544,

        /// <summary>
        /// vpmovsxdq xmm {k1}{z}, r8 |  | 
        /// </summary>
        [Symbol("vpmovsxdq xmm {k1}{z}, r8","vpmovsxdq xmm {k1}{z}, r8 |  | ")]
        vpmovsxdq_xmm_k1z_r8 = 3545,

        /// <summary>
        /// vpmovsxdq xmm, m64 |  | 
        /// </summary>
        [Symbol("vpmovsxdq xmm, m64","vpmovsxdq xmm, m64 |  | ")]
        vpmovsxdq_xmm_m64 = 3546,

        /// <summary>
        /// vpmovsxdq xmm, r8 |  | 
        /// </summary>
        [Symbol("vpmovsxdq xmm, r8","vpmovsxdq xmm, r8 |  | ")]
        vpmovsxdq_xmm_r8 = 3547,

        /// <summary>
        /// vpmovsxdq ymm {k1}{z}, m128 |  | 
        /// </summary>
        [Symbol("vpmovsxdq ymm {k1}{z}, m128","vpmovsxdq ymm {k1}{z}, m128 |  | ")]
        vpmovsxdq_ymm_k1z_m128 = 3548,

        /// <summary>
        /// vpmovsxdq ymm {k1}{z}, r8 |  | 
        /// </summary>
        [Symbol("vpmovsxdq ymm {k1}{z}, r8","vpmovsxdq ymm {k1}{z}, r8 |  | ")]
        vpmovsxdq_ymm_k1z_r8 = 3549,

        /// <summary>
        /// vpmovsxdq ymm, m128 |  | 
        /// </summary>
        [Symbol("vpmovsxdq ymm, m128","vpmovsxdq ymm, m128 |  | ")]
        vpmovsxdq_ymm_m128 = 3550,

        /// <summary>
        /// vpmovsxdq ymm, r8 |  | 
        /// </summary>
        [Symbol("vpmovsxdq ymm, r8","vpmovsxdq ymm, r8 |  | ")]
        vpmovsxdq_ymm_r8 = 3551,

        /// <summary>
        /// vpmovsxdq zmm {k1}{z}, m256 |  | 
        /// </summary>
        [Symbol("vpmovsxdq zmm {k1}{z}, m256","vpmovsxdq zmm {k1}{z}, m256 |  | ")]
        vpmovsxdq_zmm_k1z_m256 = 3552,

        /// <summary>
        /// vpmovsxdq zmm {k1}{z}, r16 |  | 
        /// </summary>
        [Symbol("vpmovsxdq zmm {k1}{z}, r16","vpmovsxdq zmm {k1}{z}, r16 |  | ")]
        vpmovsxdq_zmm_k1z_r16 = 3553,

        /// <summary>
        /// vpmovsxdq zmm, m256 |  | 
        /// </summary>
        [Symbol("vpmovsxdq zmm, m256","vpmovsxdq zmm, m256 |  | ")]
        vpmovsxdq_zmm_m256 = 3554,

        /// <summary>
        /// vpmovsxdq zmm, r16 |  | 
        /// </summary>
        [Symbol("vpmovsxdq zmm, r16","vpmovsxdq zmm, r16 |  | ")]
        vpmovsxdq_zmm_r16 = 3555,

        /// <summary>
        /// vpmovsxwd xmm {k1}{z}, m64 |  | 
        /// </summary>
        [Symbol("vpmovsxwd xmm {k1}{z}, m64","vpmovsxwd xmm {k1}{z}, m64 |  | ")]
        vpmovsxwd_xmm_k1z_m64 = 3556,

        /// <summary>
        /// vpmovsxwd xmm {k1}{z}, r8 |  | 
        /// </summary>
        [Symbol("vpmovsxwd xmm {k1}{z}, r8","vpmovsxwd xmm {k1}{z}, r8 |  | ")]
        vpmovsxwd_xmm_k1z_r8 = 3557,

        /// <summary>
        /// vpmovsxwd xmm, m64 |  | 
        /// </summary>
        [Symbol("vpmovsxwd xmm, m64","vpmovsxwd xmm, m64 |  | ")]
        vpmovsxwd_xmm_m64 = 3558,

        /// <summary>
        /// vpmovsxwd xmm, r8 |  | 
        /// </summary>
        [Symbol("vpmovsxwd xmm, r8","vpmovsxwd xmm, r8 |  | ")]
        vpmovsxwd_xmm_r8 = 3559,

        /// <summary>
        /// vpmovsxwd ymm {k1}{z}, m128 |  | 
        /// </summary>
        [Symbol("vpmovsxwd ymm {k1}{z}, m128","vpmovsxwd ymm {k1}{z}, m128 |  | ")]
        vpmovsxwd_ymm_k1z_m128 = 3560,

        /// <summary>
        /// vpmovsxwd ymm {k1}{z}, r8 |  | 
        /// </summary>
        [Symbol("vpmovsxwd ymm {k1}{z}, r8","vpmovsxwd ymm {k1}{z}, r8 |  | ")]
        vpmovsxwd_ymm_k1z_r8 = 3561,

        /// <summary>
        /// vpmovsxwd ymm, m128 |  | 
        /// </summary>
        [Symbol("vpmovsxwd ymm, m128","vpmovsxwd ymm, m128 |  | ")]
        vpmovsxwd_ymm_m128 = 3562,

        /// <summary>
        /// vpmovsxwd ymm, r8 |  | 
        /// </summary>
        [Symbol("vpmovsxwd ymm, r8","vpmovsxwd ymm, r8 |  | ")]
        vpmovsxwd_ymm_r8 = 3563,

        /// <summary>
        /// vpmovsxwd zmm {k1}{z}, m256 |  | 
        /// </summary>
        [Symbol("vpmovsxwd zmm {k1}{z}, m256","vpmovsxwd zmm {k1}{z}, m256 |  | ")]
        vpmovsxwd_zmm_k1z_m256 = 3564,

        /// <summary>
        /// vpmovsxwd zmm {k1}{z}, r16 |  | 
        /// </summary>
        [Symbol("vpmovsxwd zmm {k1}{z}, r16","vpmovsxwd zmm {k1}{z}, r16 |  | ")]
        vpmovsxwd_zmm_k1z_r16 = 3565,

        /// <summary>
        /// vpmovsxwd zmm, m256 |  | 
        /// </summary>
        [Symbol("vpmovsxwd zmm, m256","vpmovsxwd zmm, m256 |  | ")]
        vpmovsxwd_zmm_m256 = 3566,

        /// <summary>
        /// vpmovsxwd zmm, r16 |  | 
        /// </summary>
        [Symbol("vpmovsxwd zmm, r16","vpmovsxwd zmm, r16 |  | ")]
        vpmovsxwd_zmm_r16 = 3567,

        /// <summary>
        /// vpmovsxwq xmm {k1}{z}, m32 |  | 
        /// </summary>
        [Symbol("vpmovsxwq xmm {k1}{z}, m32","vpmovsxwq xmm {k1}{z}, m32 |  | ")]
        vpmovsxwq_xmm_k1z_m32 = 3568,

        /// <summary>
        /// vpmovsxwq xmm {k1}{z}, r8 |  | 
        /// </summary>
        [Symbol("vpmovsxwq xmm {k1}{z}, r8","vpmovsxwq xmm {k1}{z}, r8 |  | ")]
        vpmovsxwq_xmm_k1z_r8 = 3569,

        /// <summary>
        /// vpmovsxwq xmm, m32 |  | 
        /// </summary>
        [Symbol("vpmovsxwq xmm, m32","vpmovsxwq xmm, m32 |  | ")]
        vpmovsxwq_xmm_m32 = 3570,

        /// <summary>
        /// vpmovsxwq xmm, r8 |  | 
        /// </summary>
        [Symbol("vpmovsxwq xmm, r8","vpmovsxwq xmm, r8 |  | ")]
        vpmovsxwq_xmm_r8 = 3571,

        /// <summary>
        /// vpmovsxwq ymm {k1}{z}, m64 |  | 
        /// </summary>
        [Symbol("vpmovsxwq ymm {k1}{z}, m64","vpmovsxwq ymm {k1}{z}, m64 |  | ")]
        vpmovsxwq_ymm_k1z_m64 = 3572,

        /// <summary>
        /// vpmovsxwq ymm {k1}{z}, r8 |  | 
        /// </summary>
        [Symbol("vpmovsxwq ymm {k1}{z}, r8","vpmovsxwq ymm {k1}{z}, r8 |  | ")]
        vpmovsxwq_ymm_k1z_r8 = 3573,

        /// <summary>
        /// vpmovsxwq ymm, m64 |  | 
        /// </summary>
        [Symbol("vpmovsxwq ymm, m64","vpmovsxwq ymm, m64 |  | ")]
        vpmovsxwq_ymm_m64 = 3574,

        /// <summary>
        /// vpmovsxwq ymm, r8 |  | 
        /// </summary>
        [Symbol("vpmovsxwq ymm, r8","vpmovsxwq ymm, r8 |  | ")]
        vpmovsxwq_ymm_r8 = 3575,

        /// <summary>
        /// vpmovsxwq zmm {k1}{z}, m128 |  | 
        /// </summary>
        [Symbol("vpmovsxwq zmm {k1}{z}, m128","vpmovsxwq zmm {k1}{z}, m128 |  | ")]
        vpmovsxwq_zmm_k1z_m128 = 3576,

        /// <summary>
        /// vpmovsxwq zmm {k1}{z}, r8 |  | 
        /// </summary>
        [Symbol("vpmovsxwq zmm {k1}{z}, r8","vpmovsxwq zmm {k1}{z}, r8 |  | ")]
        vpmovsxwq_zmm_k1z_r8 = 3577,

        /// <summary>
        /// vpmovsxwq zmm, m128 |  | 
        /// </summary>
        [Symbol("vpmovsxwq zmm, m128","vpmovsxwq zmm, m128 |  | ")]
        vpmovsxwq_zmm_m128 = 3578,

        /// <summary>
        /// vpmovsxwq zmm, r8 |  | 
        /// </summary>
        [Symbol("vpmovsxwq zmm, r8","vpmovsxwq zmm, r8 |  | ")]
        vpmovsxwq_zmm_r8 = 3579,

        /// <summary>
        /// vpmovusdb m128 {k1}{z}, zmm |  | 
        /// </summary>
        [Symbol("vpmovusdb m128 {k1}{z}, zmm","vpmovusdb m128 {k1}{z}, zmm |  | ")]
        vpmovusdb_m128_k1z_zmm = 3580,

        /// <summary>
        /// vpmovusdb m128, zmm |  | 
        /// </summary>
        [Symbol("vpmovusdb m128, zmm","vpmovusdb m128, zmm |  | ")]
        vpmovusdb_m128_zmm = 3581,

        /// <summary>
        /// vpmovusdb m32 {k1}{z}, xmm |  | 
        /// </summary>
        [Symbol("vpmovusdb m32 {k1}{z}, xmm","vpmovusdb m32 {k1}{z}, xmm |  | ")]
        vpmovusdb_m32_k1z_xmm = 3582,

        /// <summary>
        /// vpmovusdb m32, xmm |  | 
        /// </summary>
        [Symbol("vpmovusdb m32, xmm","vpmovusdb m32, xmm |  | ")]
        vpmovusdb_m32_xmm = 3583,

        /// <summary>
        /// vpmovusdb m64 {k1}{z}, ymm |  | 
        /// </summary>
        [Symbol("vpmovusdb m64 {k1}{z}, ymm","vpmovusdb m64 {k1}{z}, ymm |  | ")]
        vpmovusdb_m64_k1z_ymm = 3584,

        /// <summary>
        /// vpmovusdb m64, ymm |  | 
        /// </summary>
        [Symbol("vpmovusdb m64, ymm","vpmovusdb m64, ymm |  | ")]
        vpmovusdb_m64_ymm = 3585,

        /// <summary>
        /// vpmovusdb r8 {k1}{z}, xmm |  | 
        /// </summary>
        [Symbol("vpmovusdb r8 {k1}{z}, xmm","vpmovusdb r8 {k1}{z}, xmm |  | ")]
        vpmovusdb_r8_k1z_xmm = 3586,

        /// <summary>
        /// vpmovusdb r8 {k1}{z}, ymm |  | 
        /// </summary>
        [Symbol("vpmovusdb r8 {k1}{z}, ymm","vpmovusdb r8 {k1}{z}, ymm |  | ")]
        vpmovusdb_r8_k1z_ymm = 3587,

        /// <summary>
        /// vpmovusdb r8 {k1}{z}, zmm |  | 
        /// </summary>
        [Symbol("vpmovusdb r8 {k1}{z}, zmm","vpmovusdb r8 {k1}{z}, zmm |  | ")]
        vpmovusdb_r8_k1z_zmm = 3588,

        /// <summary>
        /// vpmovusdb r8, xmm |  | 
        /// </summary>
        [Symbol("vpmovusdb r8, xmm","vpmovusdb r8, xmm |  | ")]
        vpmovusdb_r8_xmm = 3589,

        /// <summary>
        /// vpmovusdb r8, ymm |  | 
        /// </summary>
        [Symbol("vpmovusdb r8, ymm","vpmovusdb r8, ymm |  | ")]
        vpmovusdb_r8_ymm = 3590,

        /// <summary>
        /// vpmovusdb r8, zmm |  | 
        /// </summary>
        [Symbol("vpmovusdb r8, zmm","vpmovusdb r8, zmm |  | ")]
        vpmovusdb_r8_zmm = 3591,

        /// <summary>
        /// vpmovusdw m128 {k1}{z}, ymm |  | 
        /// </summary>
        [Symbol("vpmovusdw m128 {k1}{z}, ymm","vpmovusdw m128 {k1}{z}, ymm |  | ")]
        vpmovusdw_m128_k1z_ymm = 3592,

        /// <summary>
        /// vpmovusdw m128, ymm |  | 
        /// </summary>
        [Symbol("vpmovusdw m128, ymm","vpmovusdw m128, ymm |  | ")]
        vpmovusdw_m128_ymm = 3593,

        /// <summary>
        /// vpmovusdw m256 {k1}{z}, zmm |  | 
        /// </summary>
        [Symbol("vpmovusdw m256 {k1}{z}, zmm","vpmovusdw m256 {k1}{z}, zmm |  | ")]
        vpmovusdw_m256_k1z_zmm = 3594,

        /// <summary>
        /// vpmovusdw m256, zmm |  | 
        /// </summary>
        [Symbol("vpmovusdw m256, zmm","vpmovusdw m256, zmm |  | ")]
        vpmovusdw_m256_zmm = 3595,

        /// <summary>
        /// vpmovusdw m64 {k1}{z}, xmm |  | 
        /// </summary>
        [Symbol("vpmovusdw m64 {k1}{z}, xmm","vpmovusdw m64 {k1}{z}, xmm |  | ")]
        vpmovusdw_m64_k1z_xmm = 3596,

        /// <summary>
        /// vpmovusdw m64, xmm |  | 
        /// </summary>
        [Symbol("vpmovusdw m64, xmm","vpmovusdw m64, xmm |  | ")]
        vpmovusdw_m64_xmm = 3597,

        /// <summary>
        /// vpmovusdw r16 {k1}{z}, zmm |  | 
        /// </summary>
        [Symbol("vpmovusdw r16 {k1}{z}, zmm","vpmovusdw r16 {k1}{z}, zmm |  | ")]
        vpmovusdw_r16_k1z_zmm = 3598,

        /// <summary>
        /// vpmovusdw r16, zmm |  | 
        /// </summary>
        [Symbol("vpmovusdw r16, zmm","vpmovusdw r16, zmm |  | ")]
        vpmovusdw_r16_zmm = 3599,

        /// <summary>
        /// vpmovusdw r8 {k1}{z}, xmm |  | 
        /// </summary>
        [Symbol("vpmovusdw r8 {k1}{z}, xmm","vpmovusdw r8 {k1}{z}, xmm |  | ")]
        vpmovusdw_r8_k1z_xmm = 3600,

        /// <summary>
        /// vpmovusdw r8 {k1}{z}, ymm |  | 
        /// </summary>
        [Symbol("vpmovusdw r8 {k1}{z}, ymm","vpmovusdw r8 {k1}{z}, ymm |  | ")]
        vpmovusdw_r8_k1z_ymm = 3601,

        /// <summary>
        /// vpmovusdw r8, xmm |  | 
        /// </summary>
        [Symbol("vpmovusdw r8, xmm","vpmovusdw r8, xmm |  | ")]
        vpmovusdw_r8_xmm = 3602,

        /// <summary>
        /// vpmovusdw r8, ymm |  | 
        /// </summary>
        [Symbol("vpmovusdw r8, ymm","vpmovusdw r8, ymm |  | ")]
        vpmovusdw_r8_ymm = 3603,

        /// <summary>
        /// vpmovusqb m16 {k1}{z}, xmm |  | 
        /// </summary>
        [Symbol("vpmovusqb m16 {k1}{z}, xmm","vpmovusqb m16 {k1}{z}, xmm |  | ")]
        vpmovusqb_m16_k1z_xmm = 3604,

        /// <summary>
        /// vpmovusqb m16, xmm |  | 
        /// </summary>
        [Symbol("vpmovusqb m16, xmm","vpmovusqb m16, xmm |  | ")]
        vpmovusqb_m16_xmm = 3605,

        /// <summary>
        /// vpmovusqb m32 {k1}{z}, ymm |  | 
        /// </summary>
        [Symbol("vpmovusqb m32 {k1}{z}, ymm","vpmovusqb m32 {k1}{z}, ymm |  | ")]
        vpmovusqb_m32_k1z_ymm = 3606,

        /// <summary>
        /// vpmovusqb m32, ymm |  | 
        /// </summary>
        [Symbol("vpmovusqb m32, ymm","vpmovusqb m32, ymm |  | ")]
        vpmovusqb_m32_ymm = 3607,

        /// <summary>
        /// vpmovusqb m64 {k1}{z}, zmm |  | 
        /// </summary>
        [Symbol("vpmovusqb m64 {k1}{z}, zmm","vpmovusqb m64 {k1}{z}, zmm |  | ")]
        vpmovusqb_m64_k1z_zmm = 3608,

        /// <summary>
        /// vpmovusqb m64, zmm |  | 
        /// </summary>
        [Symbol("vpmovusqb m64, zmm","vpmovusqb m64, zmm |  | ")]
        vpmovusqb_m64_zmm = 3609,

        /// <summary>
        /// vpmovusqb r8 {k1}{z}, xmm |  | 
        /// </summary>
        [Symbol("vpmovusqb r8 {k1}{z}, xmm","vpmovusqb r8 {k1}{z}, xmm |  | ")]
        vpmovusqb_r8_k1z_xmm = 3610,

        /// <summary>
        /// vpmovusqb r8 {k1}{z}, ymm |  | 
        /// </summary>
        [Symbol("vpmovusqb r8 {k1}{z}, ymm","vpmovusqb r8 {k1}{z}, ymm |  | ")]
        vpmovusqb_r8_k1z_ymm = 3611,

        /// <summary>
        /// vpmovusqb r8 {k1}{z}, zmm |  | 
        /// </summary>
        [Symbol("vpmovusqb r8 {k1}{z}, zmm","vpmovusqb r8 {k1}{z}, zmm |  | ")]
        vpmovusqb_r8_k1z_zmm = 3612,

        /// <summary>
        /// vpmovusqb r8, xmm |  | 
        /// </summary>
        [Symbol("vpmovusqb r8, xmm","vpmovusqb r8, xmm |  | ")]
        vpmovusqb_r8_xmm = 3613,

        /// <summary>
        /// vpmovusqb r8, ymm |  | 
        /// </summary>
        [Symbol("vpmovusqb r8, ymm","vpmovusqb r8, ymm |  | ")]
        vpmovusqb_r8_ymm = 3614,

        /// <summary>
        /// vpmovusqb r8, zmm |  | 
        /// </summary>
        [Symbol("vpmovusqb r8, zmm","vpmovusqb r8, zmm |  | ")]
        vpmovusqb_r8_zmm = 3615,

        /// <summary>
        /// vpmovusqd m128 {k1}{z}, ymm |  | 
        /// </summary>
        [Symbol("vpmovusqd m128 {k1}{z}, ymm","vpmovusqd m128 {k1}{z}, ymm |  | ")]
        vpmovusqd_m128_k1z_ymm = 3616,

        /// <summary>
        /// vpmovusqd m128, ymm |  | 
        /// </summary>
        [Symbol("vpmovusqd m128, ymm","vpmovusqd m128, ymm |  | ")]
        vpmovusqd_m128_ymm = 3617,

        /// <summary>
        /// vpmovusqd m256 {k1}{z}, zmm |  | 
        /// </summary>
        [Symbol("vpmovusqd m256 {k1}{z}, zmm","vpmovusqd m256 {k1}{z}, zmm |  | ")]
        vpmovusqd_m256_k1z_zmm = 3618,

        /// <summary>
        /// vpmovusqd m256, zmm |  | 
        /// </summary>
        [Symbol("vpmovusqd m256, zmm","vpmovusqd m256, zmm |  | ")]
        vpmovusqd_m256_zmm = 3619,

        /// <summary>
        /// vpmovusqd m64 {k1}{z}, xmm |  | 
        /// </summary>
        [Symbol("vpmovusqd m64 {k1}{z}, xmm","vpmovusqd m64 {k1}{z}, xmm |  | ")]
        vpmovusqd_m64_k1z_xmm = 3620,

        /// <summary>
        /// vpmovusqd m64, xmm |  | 
        /// </summary>
        [Symbol("vpmovusqd m64, xmm","vpmovusqd m64, xmm |  | ")]
        vpmovusqd_m64_xmm = 3621,

        /// <summary>
        /// vpmovusqd r16 {k1}{z}, zmm |  | 
        /// </summary>
        [Symbol("vpmovusqd r16 {k1}{z}, zmm","vpmovusqd r16 {k1}{z}, zmm |  | ")]
        vpmovusqd_r16_k1z_zmm = 3622,

        /// <summary>
        /// vpmovusqd r16, zmm |  | 
        /// </summary>
        [Symbol("vpmovusqd r16, zmm","vpmovusqd r16, zmm |  | ")]
        vpmovusqd_r16_zmm = 3623,

        /// <summary>
        /// vpmovusqd r8 {k1}{z}, xmm |  | 
        /// </summary>
        [Symbol("vpmovusqd r8 {k1}{z}, xmm","vpmovusqd r8 {k1}{z}, xmm |  | ")]
        vpmovusqd_r8_k1z_xmm = 3624,

        /// <summary>
        /// vpmovusqd r8 {k1}{z}, ymm |  | 
        /// </summary>
        [Symbol("vpmovusqd r8 {k1}{z}, ymm","vpmovusqd r8 {k1}{z}, ymm |  | ")]
        vpmovusqd_r8_k1z_ymm = 3625,

        /// <summary>
        /// vpmovusqd r8, xmm |  | 
        /// </summary>
        [Symbol("vpmovusqd r8, xmm","vpmovusqd r8, xmm |  | ")]
        vpmovusqd_r8_xmm = 3626,

        /// <summary>
        /// vpmovusqd r8, ymm |  | 
        /// </summary>
        [Symbol("vpmovusqd r8, ymm","vpmovusqd r8, ymm |  | ")]
        vpmovusqd_r8_ymm = 3627,

        /// <summary>
        /// vpmovusqw m128 {k1}{z}, zmm |  | 
        /// </summary>
        [Symbol("vpmovusqw m128 {k1}{z}, zmm","vpmovusqw m128 {k1}{z}, zmm |  | ")]
        vpmovusqw_m128_k1z_zmm = 3628,

        /// <summary>
        /// vpmovusqw m128, zmm |  | 
        /// </summary>
        [Symbol("vpmovusqw m128, zmm","vpmovusqw m128, zmm |  | ")]
        vpmovusqw_m128_zmm = 3629,

        /// <summary>
        /// vpmovusqw m32 {k1}{z}, xmm |  | 
        /// </summary>
        [Symbol("vpmovusqw m32 {k1}{z}, xmm","vpmovusqw m32 {k1}{z}, xmm |  | ")]
        vpmovusqw_m32_k1z_xmm = 3630,

        /// <summary>
        /// vpmovusqw m32, xmm |  | 
        /// </summary>
        [Symbol("vpmovusqw m32, xmm","vpmovusqw m32, xmm |  | ")]
        vpmovusqw_m32_xmm = 3631,

        /// <summary>
        /// vpmovusqw m64 {k1}{z}, ymm |  | 
        /// </summary>
        [Symbol("vpmovusqw m64 {k1}{z}, ymm","vpmovusqw m64 {k1}{z}, ymm |  | ")]
        vpmovusqw_m64_k1z_ymm = 3632,

        /// <summary>
        /// vpmovusqw m64, ymm |  | 
        /// </summary>
        [Symbol("vpmovusqw m64, ymm","vpmovusqw m64, ymm |  | ")]
        vpmovusqw_m64_ymm = 3633,

        /// <summary>
        /// vpmovusqw r8 {k1}{z}, xmm |  | 
        /// </summary>
        [Symbol("vpmovusqw r8 {k1}{z}, xmm","vpmovusqw r8 {k1}{z}, xmm |  | ")]
        vpmovusqw_r8_k1z_xmm = 3634,

        /// <summary>
        /// vpmovusqw r8 {k1}{z}, ymm |  | 
        /// </summary>
        [Symbol("vpmovusqw r8 {k1}{z}, ymm","vpmovusqw r8 {k1}{z}, ymm |  | ")]
        vpmovusqw_r8_k1z_ymm = 3635,

        /// <summary>
        /// vpmovusqw r8 {k1}{z}, zmm |  | 
        /// </summary>
        [Symbol("vpmovusqw r8 {k1}{z}, zmm","vpmovusqw r8 {k1}{z}, zmm |  | ")]
        vpmovusqw_r8_k1z_zmm = 3636,

        /// <summary>
        /// vpmovusqw r8, xmm |  | 
        /// </summary>
        [Symbol("vpmovusqw r8, xmm","vpmovusqw r8, xmm |  | ")]
        vpmovusqw_r8_xmm = 3637,

        /// <summary>
        /// vpmovusqw r8, ymm |  | 
        /// </summary>
        [Symbol("vpmovusqw r8, ymm","vpmovusqw r8, ymm |  | ")]
        vpmovusqw_r8_ymm = 3638,

        /// <summary>
        /// vpmovusqw r8, zmm |  | 
        /// </summary>
        [Symbol("vpmovusqw r8, zmm","vpmovusqw r8, zmm |  | ")]
        vpmovusqw_r8_zmm = 3639,

        /// <summary>
        /// vpmovuswb m128 {k1}{z}, ymm |  | 
        /// </summary>
        [Symbol("vpmovuswb m128 {k1}{z}, ymm","vpmovuswb m128 {k1}{z}, ymm |  | ")]
        vpmovuswb_m128_k1z_ymm = 3640,

        /// <summary>
        /// vpmovuswb m128, ymm |  | 
        /// </summary>
        [Symbol("vpmovuswb m128, ymm","vpmovuswb m128, ymm |  | ")]
        vpmovuswb_m128_ymm = 3641,

        /// <summary>
        /// vpmovuswb m256 {k1}{z}, zmm |  | 
        /// </summary>
        [Symbol("vpmovuswb m256 {k1}{z}, zmm","vpmovuswb m256 {k1}{z}, zmm |  | ")]
        vpmovuswb_m256_k1z_zmm = 3642,

        /// <summary>
        /// vpmovuswb m256, zmm |  | 
        /// </summary>
        [Symbol("vpmovuswb m256, zmm","vpmovuswb m256, zmm |  | ")]
        vpmovuswb_m256_zmm = 3643,

        /// <summary>
        /// vpmovuswb m64 {k1}{z}, xmm |  | 
        /// </summary>
        [Symbol("vpmovuswb m64 {k1}{z}, xmm","vpmovuswb m64 {k1}{z}, xmm |  | ")]
        vpmovuswb_m64_k1z_xmm = 3644,

        /// <summary>
        /// vpmovuswb m64, xmm |  | 
        /// </summary>
        [Symbol("vpmovuswb m64, xmm","vpmovuswb m64, xmm |  | ")]
        vpmovuswb_m64_xmm = 3645,

        /// <summary>
        /// vpmovuswb r16 {k1}{z}, zmm |  | 
        /// </summary>
        [Symbol("vpmovuswb r16 {k1}{z}, zmm","vpmovuswb r16 {k1}{z}, zmm |  | ")]
        vpmovuswb_r16_k1z_zmm = 3646,

        /// <summary>
        /// vpmovuswb r16, zmm |  | 
        /// </summary>
        [Symbol("vpmovuswb r16, zmm","vpmovuswb r16, zmm |  | ")]
        vpmovuswb_r16_zmm = 3647,

        /// <summary>
        /// vpmovuswb r8 {k1}{z}, xmm |  | 
        /// </summary>
        [Symbol("vpmovuswb r8 {k1}{z}, xmm","vpmovuswb r8 {k1}{z}, xmm |  | ")]
        vpmovuswb_r8_k1z_xmm = 3648,

        /// <summary>
        /// vpmovuswb r8 {k1}{z}, ymm |  | 
        /// </summary>
        [Symbol("vpmovuswb r8 {k1}{z}, ymm","vpmovuswb r8 {k1}{z}, ymm |  | ")]
        vpmovuswb_r8_k1z_ymm = 3649,

        /// <summary>
        /// vpmovuswb r8, xmm |  | 
        /// </summary>
        [Symbol("vpmovuswb r8, xmm","vpmovuswb r8, xmm |  | ")]
        vpmovuswb_r8_xmm = 3650,

        /// <summary>
        /// vpmovuswb r8, ymm |  | 
        /// </summary>
        [Symbol("vpmovuswb r8, ymm","vpmovuswb r8, ymm |  | ")]
        vpmovuswb_r8_ymm = 3651,

        /// <summary>
        /// vpmovw2m k, xmm |  | 
        /// </summary>
        [Symbol("vpmovw2m k, xmm","vpmovw2m k, xmm |  | ")]
        vpmovw2m_k_xmm = 3652,

        /// <summary>
        /// vpmovw2m k, ymm |  | 
        /// </summary>
        [Symbol("vpmovw2m k, ymm","vpmovw2m k, ymm |  | ")]
        vpmovw2m_k_ymm = 3653,

        /// <summary>
        /// vpmovw2m k, zmm |  | 
        /// </summary>
        [Symbol("vpmovw2m k, zmm","vpmovw2m k, zmm |  | ")]
        vpmovw2m_k_zmm = 3654,

        /// <summary>
        /// vpmovwb m128 {k1}{z}, ymm |  | 
        /// </summary>
        [Symbol("vpmovwb m128 {k1}{z}, ymm","vpmovwb m128 {k1}{z}, ymm |  | ")]
        vpmovwb_m128_k1z_ymm = 3655,

        /// <summary>
        /// vpmovwb m128, ymm |  | 
        /// </summary>
        [Symbol("vpmovwb m128, ymm","vpmovwb m128, ymm |  | ")]
        vpmovwb_m128_ymm = 3656,

        /// <summary>
        /// vpmovwb m256 {k1}{z}, zmm |  | 
        /// </summary>
        [Symbol("vpmovwb m256 {k1}{z}, zmm","vpmovwb m256 {k1}{z}, zmm |  | ")]
        vpmovwb_m256_k1z_zmm = 3657,

        /// <summary>
        /// vpmovwb m256, zmm |  | 
        /// </summary>
        [Symbol("vpmovwb m256, zmm","vpmovwb m256, zmm |  | ")]
        vpmovwb_m256_zmm = 3658,

        /// <summary>
        /// vpmovwb m64 {k1}{z}, xmm |  | 
        /// </summary>
        [Symbol("vpmovwb m64 {k1}{z}, xmm","vpmovwb m64 {k1}{z}, xmm |  | ")]
        vpmovwb_m64_k1z_xmm = 3659,

        /// <summary>
        /// vpmovwb m64, xmm |  | 
        /// </summary>
        [Symbol("vpmovwb m64, xmm","vpmovwb m64, xmm |  | ")]
        vpmovwb_m64_xmm = 3660,

        /// <summary>
        /// vpmovwb r16 {k1}{z}, zmm |  | 
        /// </summary>
        [Symbol("vpmovwb r16 {k1}{z}, zmm","vpmovwb r16 {k1}{z}, zmm |  | ")]
        vpmovwb_r16_k1z_zmm = 3661,

        /// <summary>
        /// vpmovwb r16, zmm |  | 
        /// </summary>
        [Symbol("vpmovwb r16, zmm","vpmovwb r16, zmm |  | ")]
        vpmovwb_r16_zmm = 3662,

        /// <summary>
        /// vpmovwb r8 {k1}{z}, xmm |  | 
        /// </summary>
        [Symbol("vpmovwb r8 {k1}{z}, xmm","vpmovwb r8 {k1}{z}, xmm |  | ")]
        vpmovwb_r8_k1z_xmm = 3663,

        /// <summary>
        /// vpmovwb r8 {k1}{z}, ymm |  | 
        /// </summary>
        [Symbol("vpmovwb r8 {k1}{z}, ymm","vpmovwb r8 {k1}{z}, ymm |  | ")]
        vpmovwb_r8_k1z_ymm = 3664,

        /// <summary>
        /// vpmovwb r8, xmm |  | 
        /// </summary>
        [Symbol("vpmovwb r8, xmm","vpmovwb r8, xmm |  | ")]
        vpmovwb_r8_xmm = 3665,

        /// <summary>
        /// vpmovwb r8, ymm |  | 
        /// </summary>
        [Symbol("vpmovwb r8, ymm","vpmovwb r8, ymm |  | ")]
        vpmovwb_r8_ymm = 3666,

        /// <summary>
        /// vpmovzxbd xmm {k1}{z}, m32 |  | 
        /// </summary>
        [Symbol("vpmovzxbd xmm {k1}{z}, m32","vpmovzxbd xmm {k1}{z}, m32 |  | ")]
        vpmovzxbd_xmm_k1z_m32 = 3667,

        /// <summary>
        /// vpmovzxbd xmm {k1}{z}, r8 |  | 
        /// </summary>
        [Symbol("vpmovzxbd xmm {k1}{z}, r8","vpmovzxbd xmm {k1}{z}, r8 |  | ")]
        vpmovzxbd_xmm_k1z_r8 = 3668,

        /// <summary>
        /// vpmovzxbd xmm, m32 |  | 
        /// </summary>
        [Symbol("vpmovzxbd xmm, m32","vpmovzxbd xmm, m32 |  | ")]
        vpmovzxbd_xmm_m32 = 3669,

        /// <summary>
        /// vpmovzxbd xmm, r8 |  | 
        /// </summary>
        [Symbol("vpmovzxbd xmm, r8","vpmovzxbd xmm, r8 |  | ")]
        vpmovzxbd_xmm_r8 = 3670,

        /// <summary>
        /// vpmovzxbd ymm {k1}{z}, m64 |  | 
        /// </summary>
        [Symbol("vpmovzxbd ymm {k1}{z}, m64","vpmovzxbd ymm {k1}{z}, m64 |  | ")]
        vpmovzxbd_ymm_k1z_m64 = 3671,

        /// <summary>
        /// vpmovzxbd ymm {k1}{z}, r8 |  | 
        /// </summary>
        [Symbol("vpmovzxbd ymm {k1}{z}, r8","vpmovzxbd ymm {k1}{z}, r8 |  | ")]
        vpmovzxbd_ymm_k1z_r8 = 3672,

        /// <summary>
        /// vpmovzxbd ymm, m64 |  | 
        /// </summary>
        [Symbol("vpmovzxbd ymm, m64","vpmovzxbd ymm, m64 |  | ")]
        vpmovzxbd_ymm_m64 = 3673,

        /// <summary>
        /// vpmovzxbd ymm, r8 |  | 
        /// </summary>
        [Symbol("vpmovzxbd ymm, r8","vpmovzxbd ymm, r8 |  | ")]
        vpmovzxbd_ymm_r8 = 3674,

        /// <summary>
        /// vpmovzxbd zmm {k1}{z}, m128 |  | 
        /// </summary>
        [Symbol("vpmovzxbd zmm {k1}{z}, m128","vpmovzxbd zmm {k1}{z}, m128 |  | ")]
        vpmovzxbd_zmm_k1z_m128 = 3675,

        /// <summary>
        /// vpmovzxbd zmm {k1}{z}, r8 |  | 
        /// </summary>
        [Symbol("vpmovzxbd zmm {k1}{z}, r8","vpmovzxbd zmm {k1}{z}, r8 |  | ")]
        vpmovzxbd_zmm_k1z_r8 = 3676,

        /// <summary>
        /// vpmovzxbd zmm, m128 |  | 
        /// </summary>
        [Symbol("vpmovzxbd zmm, m128","vpmovzxbd zmm, m128 |  | ")]
        vpmovzxbd_zmm_m128 = 3677,

        /// <summary>
        /// vpmovzxbd zmm, r8 |  | 
        /// </summary>
        [Symbol("vpmovzxbd zmm, r8","vpmovzxbd zmm, r8 |  | ")]
        vpmovzxbd_zmm_r8 = 3678,

        /// <summary>
        /// vpmovzxbq xmm {k1}{z}, m16 |  | 
        /// </summary>
        [Symbol("vpmovzxbq xmm {k1}{z}, m16","vpmovzxbq xmm {k1}{z}, m16 |  | ")]
        vpmovzxbq_xmm_k1z_m16 = 3679,

        /// <summary>
        /// vpmovzxbq xmm {k1}{z}, r8 |  | 
        /// </summary>
        [Symbol("vpmovzxbq xmm {k1}{z}, r8","vpmovzxbq xmm {k1}{z}, r8 |  | ")]
        vpmovzxbq_xmm_k1z_r8 = 3680,

        /// <summary>
        /// vpmovzxbq xmm, m16 |  | 
        /// </summary>
        [Symbol("vpmovzxbq xmm, m16","vpmovzxbq xmm, m16 |  | ")]
        vpmovzxbq_xmm_m16 = 3681,

        /// <summary>
        /// vpmovzxbq xmm, r8 |  | 
        /// </summary>
        [Symbol("vpmovzxbq xmm, r8","vpmovzxbq xmm, r8 |  | ")]
        vpmovzxbq_xmm_r8 = 3682,

        /// <summary>
        /// vpmovzxbq ymm {k1}{z}, m32 |  | 
        /// </summary>
        [Symbol("vpmovzxbq ymm {k1}{z}, m32","vpmovzxbq ymm {k1}{z}, m32 |  | ")]
        vpmovzxbq_ymm_k1z_m32 = 3683,

        /// <summary>
        /// vpmovzxbq ymm {k1}{z}, r8 |  | 
        /// </summary>
        [Symbol("vpmovzxbq ymm {k1}{z}, r8","vpmovzxbq ymm {k1}{z}, r8 |  | ")]
        vpmovzxbq_ymm_k1z_r8 = 3684,

        /// <summary>
        /// vpmovzxbq ymm, m32 |  | 
        /// </summary>
        [Symbol("vpmovzxbq ymm, m32","vpmovzxbq ymm, m32 |  | ")]
        vpmovzxbq_ymm_m32 = 3685,

        /// <summary>
        /// vpmovzxbq ymm, r8 |  | 
        /// </summary>
        [Symbol("vpmovzxbq ymm, r8","vpmovzxbq ymm, r8 |  | ")]
        vpmovzxbq_ymm_r8 = 3686,

        /// <summary>
        /// vpmovzxbq zmm {k1}{z}, m64 |  | 
        /// </summary>
        [Symbol("vpmovzxbq zmm {k1}{z}, m64","vpmovzxbq zmm {k1}{z}, m64 |  | ")]
        vpmovzxbq_zmm_k1z_m64 = 3687,

        /// <summary>
        /// vpmovzxbq zmm {k1}{z}, r8 |  | 
        /// </summary>
        [Symbol("vpmovzxbq zmm {k1}{z}, r8","vpmovzxbq zmm {k1}{z}, r8 |  | ")]
        vpmovzxbq_zmm_k1z_r8 = 3688,

        /// <summary>
        /// vpmovzxbq zmm, m64 |  | 
        /// </summary>
        [Symbol("vpmovzxbq zmm, m64","vpmovzxbq zmm, m64 |  | ")]
        vpmovzxbq_zmm_m64 = 3689,

        /// <summary>
        /// vpmovzxbq zmm, r8 |  | 
        /// </summary>
        [Symbol("vpmovzxbq zmm, r8","vpmovzxbq zmm, r8 |  | ")]
        vpmovzxbq_zmm_r8 = 3690,

        /// <summary>
        /// vpmovzxbw xmm {k1}{z}, m64 |  | 
        /// </summary>
        [Symbol("vpmovzxbw xmm {k1}{z}, m64","vpmovzxbw xmm {k1}{z}, m64 |  | ")]
        vpmovzxbw_xmm_k1z_m64 = 3691,

        /// <summary>
        /// vpmovzxbw xmm {k1}{z}, r8 |  | 
        /// </summary>
        [Symbol("vpmovzxbw xmm {k1}{z}, r8","vpmovzxbw xmm {k1}{z}, r8 |  | ")]
        vpmovzxbw_xmm_k1z_r8 = 3692,

        /// <summary>
        /// vpmovzxbw xmm, m64 |  | 
        /// </summary>
        [Symbol("vpmovzxbw xmm, m64","vpmovzxbw xmm, m64 |  | ")]
        vpmovzxbw_xmm_m64 = 3693,

        /// <summary>
        /// vpmovzxbw xmm, r8 |  | 
        /// </summary>
        [Symbol("vpmovzxbw xmm, r8","vpmovzxbw xmm, r8 |  | ")]
        vpmovzxbw_xmm_r8 = 3694,

        /// <summary>
        /// vpmovzxbw ymm {k1}{z}, m128 |  | 
        /// </summary>
        [Symbol("vpmovzxbw ymm {k1}{z}, m128","vpmovzxbw ymm {k1}{z}, m128 |  | ")]
        vpmovzxbw_ymm_k1z_m128 = 3695,

        /// <summary>
        /// vpmovzxbw ymm {k1}{z}, r8 |  | 
        /// </summary>
        [Symbol("vpmovzxbw ymm {k1}{z}, r8","vpmovzxbw ymm {k1}{z}, r8 |  | ")]
        vpmovzxbw_ymm_k1z_r8 = 3696,

        /// <summary>
        /// vpmovzxbw ymm, m128 |  | 
        /// </summary>
        [Symbol("vpmovzxbw ymm, m128","vpmovzxbw ymm, m128 |  | ")]
        vpmovzxbw_ymm_m128 = 3697,

        /// <summary>
        /// vpmovzxbw ymm, r8 |  | 
        /// </summary>
        [Symbol("vpmovzxbw ymm, r8","vpmovzxbw ymm, r8 |  | ")]
        vpmovzxbw_ymm_r8 = 3698,

        /// <summary>
        /// vpmovzxbw zmm {k1}{z}, m256 |  | 
        /// </summary>
        [Symbol("vpmovzxbw zmm {k1}{z}, m256","vpmovzxbw zmm {k1}{z}, m256 |  | ")]
        vpmovzxbw_zmm_k1z_m256 = 3699,

        /// <summary>
        /// vpmovzxbw zmm {k1}{z}, r16 |  | 
        /// </summary>
        [Symbol("vpmovzxbw zmm {k1}{z}, r16","vpmovzxbw zmm {k1}{z}, r16 |  | ")]
        vpmovzxbw_zmm_k1z_r16 = 3700,

        /// <summary>
        /// vpmovzxbw zmm, m256 |  | 
        /// </summary>
        [Symbol("vpmovzxbw zmm, m256","vpmovzxbw zmm, m256 |  | ")]
        vpmovzxbw_zmm_m256 = 3701,

        /// <summary>
        /// vpmovzxbw zmm, r16 |  | 
        /// </summary>
        [Symbol("vpmovzxbw zmm, r16","vpmovzxbw zmm, r16 |  | ")]
        vpmovzxbw_zmm_r16 = 3702,

        /// <summary>
        /// vpmovzxdq xmm {k1}{z}, m64 |  | 
        /// </summary>
        [Symbol("vpmovzxdq xmm {k1}{z}, m64","vpmovzxdq xmm {k1}{z}, m64 |  | ")]
        vpmovzxdq_xmm_k1z_m64 = 3703,

        /// <summary>
        /// vpmovzxdq xmm {k1}{z}, r8 |  | 
        /// </summary>
        [Symbol("vpmovzxdq xmm {k1}{z}, r8","vpmovzxdq xmm {k1}{z}, r8 |  | ")]
        vpmovzxdq_xmm_k1z_r8 = 3704,

        /// <summary>
        /// vpmovzxdq xmm, m64 |  | 
        /// </summary>
        [Symbol("vpmovzxdq xmm, m64","vpmovzxdq xmm, m64 |  | ")]
        vpmovzxdq_xmm_m64 = 3705,

        /// <summary>
        /// vpmovzxdq xmm, r8 |  | 
        /// </summary>
        [Symbol("vpmovzxdq xmm, r8","vpmovzxdq xmm, r8 |  | ")]
        vpmovzxdq_xmm_r8 = 3706,

        /// <summary>
        /// vpmovzxdq ymm {k1}{z}, m128 |  | 
        /// </summary>
        [Symbol("vpmovzxdq ymm {k1}{z}, m128","vpmovzxdq ymm {k1}{z}, m128 |  | ")]
        vpmovzxdq_ymm_k1z_m128 = 3707,

        /// <summary>
        /// vpmovzxdq ymm {k1}{z}, r8 |  | 
        /// </summary>
        [Symbol("vpmovzxdq ymm {k1}{z}, r8","vpmovzxdq ymm {k1}{z}, r8 |  | ")]
        vpmovzxdq_ymm_k1z_r8 = 3708,

        /// <summary>
        /// vpmovzxdq ymm, m128 |  | 
        /// </summary>
        [Symbol("vpmovzxdq ymm, m128","vpmovzxdq ymm, m128 |  | ")]
        vpmovzxdq_ymm_m128 = 3709,

        /// <summary>
        /// vpmovzxdq ymm, r8 |  | 
        /// </summary>
        [Symbol("vpmovzxdq ymm, r8","vpmovzxdq ymm, r8 |  | ")]
        vpmovzxdq_ymm_r8 = 3710,

        /// <summary>
        /// vpmovzxdq zmm {k1}{z}, m256 |  | 
        /// </summary>
        [Symbol("vpmovzxdq zmm {k1}{z}, m256","vpmovzxdq zmm {k1}{z}, m256 |  | ")]
        vpmovzxdq_zmm_k1z_m256 = 3711,

        /// <summary>
        /// vpmovzxdq zmm {k1}{z}, r16 |  | 
        /// </summary>
        [Symbol("vpmovzxdq zmm {k1}{z}, r16","vpmovzxdq zmm {k1}{z}, r16 |  | ")]
        vpmovzxdq_zmm_k1z_r16 = 3712,

        /// <summary>
        /// vpmovzxdq zmm, m256 |  | 
        /// </summary>
        [Symbol("vpmovzxdq zmm, m256","vpmovzxdq zmm, m256 |  | ")]
        vpmovzxdq_zmm_m256 = 3713,

        /// <summary>
        /// vpmovzxdq zmm, r16 |  | 
        /// </summary>
        [Symbol("vpmovzxdq zmm, r16","vpmovzxdq zmm, r16 |  | ")]
        vpmovzxdq_zmm_r16 = 3714,

        /// <summary>
        /// vpmovzxwd xmm {k1}{z}, m64 |  | 
        /// </summary>
        [Symbol("vpmovzxwd xmm {k1}{z}, m64","vpmovzxwd xmm {k1}{z}, m64 |  | ")]
        vpmovzxwd_xmm_k1z_m64 = 3715,

        /// <summary>
        /// vpmovzxwd xmm {k1}{z}, r8 |  | 
        /// </summary>
        [Symbol("vpmovzxwd xmm {k1}{z}, r8","vpmovzxwd xmm {k1}{z}, r8 |  | ")]
        vpmovzxwd_xmm_k1z_r8 = 3716,

        /// <summary>
        /// vpmovzxwd xmm, m64 |  | 
        /// </summary>
        [Symbol("vpmovzxwd xmm, m64","vpmovzxwd xmm, m64 |  | ")]
        vpmovzxwd_xmm_m64 = 3717,

        /// <summary>
        /// vpmovzxwd xmm, r8 |  | 
        /// </summary>
        [Symbol("vpmovzxwd xmm, r8","vpmovzxwd xmm, r8 |  | ")]
        vpmovzxwd_xmm_r8 = 3718,

        /// <summary>
        /// vpmovzxwd ymm {k1}{z}, m128 |  | 
        /// </summary>
        [Symbol("vpmovzxwd ymm {k1}{z}, m128","vpmovzxwd ymm {k1}{z}, m128 |  | ")]
        vpmovzxwd_ymm_k1z_m128 = 3719,

        /// <summary>
        /// vpmovzxwd ymm {k1}{z}, r8 |  | 
        /// </summary>
        [Symbol("vpmovzxwd ymm {k1}{z}, r8","vpmovzxwd ymm {k1}{z}, r8 |  | ")]
        vpmovzxwd_ymm_k1z_r8 = 3720,

        /// <summary>
        /// vpmovzxwd ymm, m128 |  | 
        /// </summary>
        [Symbol("vpmovzxwd ymm, m128","vpmovzxwd ymm, m128 |  | ")]
        vpmovzxwd_ymm_m128 = 3721,

        /// <summary>
        /// vpmovzxwd ymm, r8 |  | 
        /// </summary>
        [Symbol("vpmovzxwd ymm, r8","vpmovzxwd ymm, r8 |  | ")]
        vpmovzxwd_ymm_r8 = 3722,

        /// <summary>
        /// vpmovzxwd zmm {k1}{z}, m256 |  | 
        /// </summary>
        [Symbol("vpmovzxwd zmm {k1}{z}, m256","vpmovzxwd zmm {k1}{z}, m256 |  | ")]
        vpmovzxwd_zmm_k1z_m256 = 3723,

        /// <summary>
        /// vpmovzxwd zmm {k1}{z}, r16 |  | 
        /// </summary>
        [Symbol("vpmovzxwd zmm {k1}{z}, r16","vpmovzxwd zmm {k1}{z}, r16 |  | ")]
        vpmovzxwd_zmm_k1z_r16 = 3724,

        /// <summary>
        /// vpmovzxwd zmm, m256 |  | 
        /// </summary>
        [Symbol("vpmovzxwd zmm, m256","vpmovzxwd zmm, m256 |  | ")]
        vpmovzxwd_zmm_m256 = 3725,

        /// <summary>
        /// vpmovzxwd zmm, r16 |  | 
        /// </summary>
        [Symbol("vpmovzxwd zmm, r16","vpmovzxwd zmm, r16 |  | ")]
        vpmovzxwd_zmm_r16 = 3726,

        /// <summary>
        /// vpmovzxwq xmm {k1}{z}, m32 |  | 
        /// </summary>
        [Symbol("vpmovzxwq xmm {k1}{z}, m32","vpmovzxwq xmm {k1}{z}, m32 |  | ")]
        vpmovzxwq_xmm_k1z_m32 = 3727,

        /// <summary>
        /// vpmovzxwq xmm {k1}{z}, r8 |  | 
        /// </summary>
        [Symbol("vpmovzxwq xmm {k1}{z}, r8","vpmovzxwq xmm {k1}{z}, r8 |  | ")]
        vpmovzxwq_xmm_k1z_r8 = 3728,

        /// <summary>
        /// vpmovzxwq xmm, m32 |  | 
        /// </summary>
        [Symbol("vpmovzxwq xmm, m32","vpmovzxwq xmm, m32 |  | ")]
        vpmovzxwq_xmm_m32 = 3729,

        /// <summary>
        /// vpmovzxwq xmm, r8 |  | 
        /// </summary>
        [Symbol("vpmovzxwq xmm, r8","vpmovzxwq xmm, r8 |  | ")]
        vpmovzxwq_xmm_r8 = 3730,

        /// <summary>
        /// vpmovzxwq ymm {k1}{z}, m64 |  | 
        /// </summary>
        [Symbol("vpmovzxwq ymm {k1}{z}, m64","vpmovzxwq ymm {k1}{z}, m64 |  | ")]
        vpmovzxwq_ymm_k1z_m64 = 3731,

        /// <summary>
        /// vpmovzxwq ymm {k1}{z}, r8 |  | 
        /// </summary>
        [Symbol("vpmovzxwq ymm {k1}{z}, r8","vpmovzxwq ymm {k1}{z}, r8 |  | ")]
        vpmovzxwq_ymm_k1z_r8 = 3732,

        /// <summary>
        /// vpmovzxwq ymm, m64 |  | 
        /// </summary>
        [Symbol("vpmovzxwq ymm, m64","vpmovzxwq ymm, m64 |  | ")]
        vpmovzxwq_ymm_m64 = 3733,

        /// <summary>
        /// vpmovzxwq ymm, r8 |  | 
        /// </summary>
        [Symbol("vpmovzxwq ymm, r8","vpmovzxwq ymm, r8 |  | ")]
        vpmovzxwq_ymm_r8 = 3734,

        /// <summary>
        /// vpmovzxwq zmm {k1}{z}, m128 |  | 
        /// </summary>
        [Symbol("vpmovzxwq zmm {k1}{z}, m128","vpmovzxwq zmm {k1}{z}, m128 |  | ")]
        vpmovzxwq_zmm_k1z_m128 = 3735,

        /// <summary>
        /// vpmovzxwq zmm {k1}{z}, r8 |  | 
        /// </summary>
        [Symbol("vpmovzxwq zmm {k1}{z}, r8","vpmovzxwq zmm {k1}{z}, r8 |  | ")]
        vpmovzxwq_zmm_k1z_r8 = 3736,

        /// <summary>
        /// vpmovzxwq zmm, m128 |  | 
        /// </summary>
        [Symbol("vpmovzxwq zmm, m128","vpmovzxwq zmm, m128 |  | ")]
        vpmovzxwq_zmm_m128 = 3737,

        /// <summary>
        /// vpmovzxwq zmm, r8 |  | 
        /// </summary>
        [Symbol("vpmovzxwq zmm, r8","vpmovzxwq zmm, r8 |  | ")]
        vpmovzxwq_zmm_r8 = 3738,

        /// <summary>
        /// vpmulhuw xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpmulhuw xmm {k1}{z}, xmm, m128","vpmulhuw xmm {k1}{z}, xmm, m128 |  | ")]
        vpmulhuw_xmm_k1z_xmm_m128 = 3739,

        /// <summary>
        /// vpmulhuw xmm {k1}{z}, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpmulhuw xmm {k1}{z}, xmm, r8","vpmulhuw xmm {k1}{z}, xmm, r8 |  | ")]
        vpmulhuw_xmm_k1z_xmm_r8 = 3740,

        /// <summary>
        /// vpmulhuw xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpmulhuw xmm, xmm, m128","vpmulhuw xmm, xmm, m128 |  | ")]
        vpmulhuw_xmm_xmm_m128 = 3741,

        /// <summary>
        /// vpmulhuw xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpmulhuw xmm, xmm, r8","vpmulhuw xmm, xmm, r8 |  | ")]
        vpmulhuw_xmm_xmm_r8 = 3742,

        /// <summary>
        /// vpmulhuw ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpmulhuw ymm {k1}{z}, ymm, m256","vpmulhuw ymm {k1}{z}, ymm, m256 |  | ")]
        vpmulhuw_ymm_k1z_ymm_m256 = 3743,

        /// <summary>
        /// vpmulhuw ymm {k1}{z}, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpmulhuw ymm {k1}{z}, ymm, r16","vpmulhuw ymm {k1}{z}, ymm, r16 |  | ")]
        vpmulhuw_ymm_k1z_ymm_r16 = 3744,

        /// <summary>
        /// vpmulhuw ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpmulhuw ymm, ymm, m256","vpmulhuw ymm, ymm, m256 |  | ")]
        vpmulhuw_ymm_ymm_m256 = 3745,

        /// <summary>
        /// vpmulhuw ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpmulhuw ymm, ymm, r16","vpmulhuw ymm, ymm, r16 |  | ")]
        vpmulhuw_ymm_ymm_r16 = 3746,

        /// <summary>
        /// vpmulhuw zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpmulhuw zmm {k1}{z}, zmm, m512","vpmulhuw zmm {k1}{z}, zmm, m512 |  | ")]
        vpmulhuw_zmm_k1z_zmm_m512 = 3747,

        /// <summary>
        /// vpmulhuw zmm {k1}{z}, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpmulhuw zmm {k1}{z}, zmm, r32","vpmulhuw zmm {k1}{z}, zmm, r32 |  | ")]
        vpmulhuw_zmm_k1z_zmm_r32 = 3748,

        /// <summary>
        /// vpmulhuw zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpmulhuw zmm, zmm, m512","vpmulhuw zmm, zmm, m512 |  | ")]
        vpmulhuw_zmm_zmm_m512 = 3749,

        /// <summary>
        /// vpmulhuw zmm, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpmulhuw zmm, zmm, r32","vpmulhuw zmm, zmm, r32 |  | ")]
        vpmulhuw_zmm_zmm_r32 = 3750,

        /// <summary>
        /// vpmullw xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpmullw xmm {k1}{z}, xmm, m128","vpmullw xmm {k1}{z}, xmm, m128 |  | ")]
        vpmullw_xmm_k1z_xmm_m128 = 3751,

        /// <summary>
        /// vpmullw xmm {k1}{z}, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpmullw xmm {k1}{z}, xmm, r8","vpmullw xmm {k1}{z}, xmm, r8 |  | ")]
        vpmullw_xmm_k1z_xmm_r8 = 3752,

        /// <summary>
        /// vpmullw xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpmullw xmm, xmm, m128","vpmullw xmm, xmm, m128 |  | ")]
        vpmullw_xmm_xmm_m128 = 3753,

        /// <summary>
        /// vpmullw xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpmullw xmm, xmm, r8","vpmullw xmm, xmm, r8 |  | ")]
        vpmullw_xmm_xmm_r8 = 3754,

        /// <summary>
        /// vpmullw ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpmullw ymm {k1}{z}, ymm, m256","vpmullw ymm {k1}{z}, ymm, m256 |  | ")]
        vpmullw_ymm_k1z_ymm_m256 = 3755,

        /// <summary>
        /// vpmullw ymm {k1}{z}, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpmullw ymm {k1}{z}, ymm, r16","vpmullw ymm {k1}{z}, ymm, r16 |  | ")]
        vpmullw_ymm_k1z_ymm_r16 = 3756,

        /// <summary>
        /// vpmullw ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpmullw ymm, ymm, m256","vpmullw ymm, ymm, m256 |  | ")]
        vpmullw_ymm_ymm_m256 = 3757,

        /// <summary>
        /// vpmullw ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpmullw ymm, ymm, r16","vpmullw ymm, ymm, r16 |  | ")]
        vpmullw_ymm_ymm_r16 = 3758,

        /// <summary>
        /// vpmullw zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpmullw zmm {k1}{z}, zmm, m512","vpmullw zmm {k1}{z}, zmm, m512 |  | ")]
        vpmullw_zmm_k1z_zmm_m512 = 3759,

        /// <summary>
        /// vpmullw zmm {k1}{z}, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpmullw zmm {k1}{z}, zmm, r32","vpmullw zmm {k1}{z}, zmm, r32 |  | ")]
        vpmullw_zmm_k1z_zmm_r32 = 3760,

        /// <summary>
        /// vpmullw zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpmullw zmm, zmm, m512","vpmullw zmm, zmm, m512 |  | ")]
        vpmullw_zmm_zmm_m512 = 3761,

        /// <summary>
        /// vpmullw zmm, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpmullw zmm, zmm, r32","vpmullw zmm, zmm, r32 |  | ")]
        vpmullw_zmm_zmm_r32 = 3762,

        /// <summary>
        /// vpor xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpor xmm, xmm, m128","vpor xmm, xmm, m128 |  | ")]
        vpor_xmm_xmm_m128 = 3763,

        /// <summary>
        /// vpor xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpor xmm, xmm, r8","vpor xmm, xmm, r8 |  | ")]
        vpor_xmm_xmm_r8 = 3764,

        /// <summary>
        /// vpor ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpor ymm, ymm, m256","vpor ymm, ymm, m256 |  | ")]
        vpor_ymm_ymm_m256 = 3765,

        /// <summary>
        /// vpor ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpor ymm, ymm, r16","vpor ymm, ymm, r16 |  | ")]
        vpor_ymm_ymm_r16 = 3766,

        /// <summary>
        /// vpord xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpord xmm {k1}{z}, xmm, m128","vpord xmm {k1}{z}, xmm, m128 |  | ")]
        vpord_xmm_k1z_xmm_m128 = 3767,

        /// <summary>
        /// vpord xmm {k1}{z}, xmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpord xmm {k1}{z}, xmm, m32bcst","vpord xmm {k1}{z}, xmm, m32bcst |  | ")]
        vpord_xmm_k1z_xmm_m32bcst = 3768,

        /// <summary>
        /// vpord xmm {k1}{z}, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpord xmm {k1}{z}, xmm, xmm","vpord xmm {k1}{z}, xmm, xmm |  | ")]
        vpord_xmm_k1z_xmm_xmm = 3769,

        /// <summary>
        /// vpord xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpord xmm, xmm, m128","vpord xmm, xmm, m128 |  | ")]
        vpord_xmm_xmm_m128 = 3770,

        /// <summary>
        /// vpord xmm, xmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpord xmm, xmm, m32bcst","vpord xmm, xmm, m32bcst |  | ")]
        vpord_xmm_xmm_m32bcst = 3771,

        /// <summary>
        /// vpord xmm, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpord xmm, xmm, xmm","vpord xmm, xmm, xmm |  | ")]
        vpord_xmm_xmm_xmm = 3772,

        /// <summary>
        /// vpord ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpord ymm {k1}{z}, ymm, m256","vpord ymm {k1}{z}, ymm, m256 |  | ")]
        vpord_ymm_k1z_ymm_m256 = 3773,

        /// <summary>
        /// vpord ymm {k1}{z}, ymm, m32bcst |  | 
        /// </summary>
        [Symbol("vpord ymm {k1}{z}, ymm, m32bcst","vpord ymm {k1}{z}, ymm, m32bcst |  | ")]
        vpord_ymm_k1z_ymm_m32bcst = 3774,

        /// <summary>
        /// vpord ymm {k1}{z}, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpord ymm {k1}{z}, ymm, ymm","vpord ymm {k1}{z}, ymm, ymm |  | ")]
        vpord_ymm_k1z_ymm_ymm = 3775,

        /// <summary>
        /// vpord ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpord ymm, ymm, m256","vpord ymm, ymm, m256 |  | ")]
        vpord_ymm_ymm_m256 = 3776,

        /// <summary>
        /// vpord ymm, ymm, m32bcst |  | 
        /// </summary>
        [Symbol("vpord ymm, ymm, m32bcst","vpord ymm, ymm, m32bcst |  | ")]
        vpord_ymm_ymm_m32bcst = 3777,

        /// <summary>
        /// vpord ymm, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpord ymm, ymm, ymm","vpord ymm, ymm, ymm |  | ")]
        vpord_ymm_ymm_ymm = 3778,

        /// <summary>
        /// vpord zmm {k1}{z}, zmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpord zmm {k1}{z}, zmm, m32bcst","vpord zmm {k1}{z}, zmm, m32bcst |  | ")]
        vpord_zmm_k1z_zmm_m32bcst = 3779,

        /// <summary>
        /// vpord zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpord zmm {k1}{z}, zmm, m512","vpord zmm {k1}{z}, zmm, m512 |  | ")]
        vpord_zmm_k1z_zmm_m512 = 3780,

        /// <summary>
        /// vpord zmm {k1}{z}, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpord zmm {k1}{z}, zmm, zmm","vpord zmm {k1}{z}, zmm, zmm |  | ")]
        vpord_zmm_k1z_zmm_zmm = 3781,

        /// <summary>
        /// vpord zmm, zmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpord zmm, zmm, m32bcst","vpord zmm, zmm, m32bcst |  | ")]
        vpord_zmm_zmm_m32bcst = 3782,

        /// <summary>
        /// vpord zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpord zmm, zmm, m512","vpord zmm, zmm, m512 |  | ")]
        vpord_zmm_zmm_m512 = 3783,

        /// <summary>
        /// vpord zmm, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpord zmm, zmm, zmm","vpord zmm, zmm, zmm |  | ")]
        vpord_zmm_zmm_zmm = 3784,

        /// <summary>
        /// vporq xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vporq xmm {k1}{z}, xmm, m128","vporq xmm {k1}{z}, xmm, m128 |  | ")]
        vporq_xmm_k1z_xmm_m128 = 3785,

        /// <summary>
        /// vporq xmm {k1}{z}, xmm, m64bcst |  | 
        /// </summary>
        [Symbol("vporq xmm {k1}{z}, xmm, m64bcst","vporq xmm {k1}{z}, xmm, m64bcst |  | ")]
        vporq_xmm_k1z_xmm_m64bcst = 3786,

        /// <summary>
        /// vporq xmm {k1}{z}, xmm, xmm |  | 
        /// </summary>
        [Symbol("vporq xmm {k1}{z}, xmm, xmm","vporq xmm {k1}{z}, xmm, xmm |  | ")]
        vporq_xmm_k1z_xmm_xmm = 3787,

        /// <summary>
        /// vporq xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vporq xmm, xmm, m128","vporq xmm, xmm, m128 |  | ")]
        vporq_xmm_xmm_m128 = 3788,

        /// <summary>
        /// vporq xmm, xmm, m64bcst |  | 
        /// </summary>
        [Symbol("vporq xmm, xmm, m64bcst","vporq xmm, xmm, m64bcst |  | ")]
        vporq_xmm_xmm_m64bcst = 3789,

        /// <summary>
        /// vporq xmm, xmm, xmm |  | 
        /// </summary>
        [Symbol("vporq xmm, xmm, xmm","vporq xmm, xmm, xmm |  | ")]
        vporq_xmm_xmm_xmm = 3790,

        /// <summary>
        /// vporq ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vporq ymm {k1}{z}, ymm, m256","vporq ymm {k1}{z}, ymm, m256 |  | ")]
        vporq_ymm_k1z_ymm_m256 = 3791,

        /// <summary>
        /// vporq ymm {k1}{z}, ymm, m64bcst |  | 
        /// </summary>
        [Symbol("vporq ymm {k1}{z}, ymm, m64bcst","vporq ymm {k1}{z}, ymm, m64bcst |  | ")]
        vporq_ymm_k1z_ymm_m64bcst = 3792,

        /// <summary>
        /// vporq ymm {k1}{z}, ymm, ymm |  | 
        /// </summary>
        [Symbol("vporq ymm {k1}{z}, ymm, ymm","vporq ymm {k1}{z}, ymm, ymm |  | ")]
        vporq_ymm_k1z_ymm_ymm = 3793,

        /// <summary>
        /// vporq ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vporq ymm, ymm, m256","vporq ymm, ymm, m256 |  | ")]
        vporq_ymm_ymm_m256 = 3794,

        /// <summary>
        /// vporq ymm, ymm, m64bcst |  | 
        /// </summary>
        [Symbol("vporq ymm, ymm, m64bcst","vporq ymm, ymm, m64bcst |  | ")]
        vporq_ymm_ymm_m64bcst = 3795,

        /// <summary>
        /// vporq ymm, ymm, ymm |  | 
        /// </summary>
        [Symbol("vporq ymm, ymm, ymm","vporq ymm, ymm, ymm |  | ")]
        vporq_ymm_ymm_ymm = 3796,

        /// <summary>
        /// vporq zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vporq zmm {k1}{z}, zmm, m512","vporq zmm {k1}{z}, zmm, m512 |  | ")]
        vporq_zmm_k1z_zmm_m512 = 3797,

        /// <summary>
        /// vporq zmm {k1}{z}, zmm, m64bcst |  | 
        /// </summary>
        [Symbol("vporq zmm {k1}{z}, zmm, m64bcst","vporq zmm {k1}{z}, zmm, m64bcst |  | ")]
        vporq_zmm_k1z_zmm_m64bcst = 3798,

        /// <summary>
        /// vporq zmm {k1}{z}, zmm, zmm |  | 
        /// </summary>
        [Symbol("vporq zmm {k1}{z}, zmm, zmm","vporq zmm {k1}{z}, zmm, zmm |  | ")]
        vporq_zmm_k1z_zmm_zmm = 3799,

        /// <summary>
        /// vporq zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vporq zmm, zmm, m512","vporq zmm, zmm, m512 |  | ")]
        vporq_zmm_zmm_m512 = 3800,

        /// <summary>
        /// vporq zmm, zmm, m64bcst |  | 
        /// </summary>
        [Symbol("vporq zmm, zmm, m64bcst","vporq zmm, zmm, m64bcst |  | ")]
        vporq_zmm_zmm_m64bcst = 3801,

        /// <summary>
        /// vporq zmm, zmm, zmm |  | 
        /// </summary>
        [Symbol("vporq zmm, zmm, zmm","vporq zmm, zmm, zmm |  | ")]
        vporq_zmm_zmm_zmm = 3802,

        /// <summary>
        /// vprold xmm {k1}{z}, m128, imm8 |  | 
        /// </summary>
        [Symbol("vprold xmm {k1}{z}, m128, imm8","vprold xmm {k1}{z}, m128, imm8 |  | ")]
        vprold_xmm_k1z_m128_imm8 = 3803,

        /// <summary>
        /// vprold xmm {k1}{z}, m32bcst, imm8 |  | 
        /// </summary>
        [Symbol("vprold xmm {k1}{z}, m32bcst, imm8","vprold xmm {k1}{z}, m32bcst, imm8 |  | ")]
        vprold_xmm_k1z_m32bcst_imm8 = 3804,

        /// <summary>
        /// vprold xmm {k1}{z}, xmm, imm8 |  | 
        /// </summary>
        [Symbol("vprold xmm {k1}{z}, xmm, imm8","vprold xmm {k1}{z}, xmm, imm8 |  | ")]
        vprold_xmm_k1z_xmm_imm8 = 3805,

        /// <summary>
        /// vprold xmm, m128, imm8 |  | 
        /// </summary>
        [Symbol("vprold xmm, m128, imm8","vprold xmm, m128, imm8 |  | ")]
        vprold_xmm_m128_imm8 = 3806,

        /// <summary>
        /// vprold xmm, m32bcst, imm8 |  | 
        /// </summary>
        [Symbol("vprold xmm, m32bcst, imm8","vprold xmm, m32bcst, imm8 |  | ")]
        vprold_xmm_m32bcst_imm8 = 3807,

        /// <summary>
        /// vprold xmm, xmm, imm8 |  | 
        /// </summary>
        [Symbol("vprold xmm, xmm, imm8","vprold xmm, xmm, imm8 |  | ")]
        vprold_xmm_xmm_imm8 = 3808,

        /// <summary>
        /// vprold ymm {k1}{z}, m256, imm8 |  | 
        /// </summary>
        [Symbol("vprold ymm {k1}{z}, m256, imm8","vprold ymm {k1}{z}, m256, imm8 |  | ")]
        vprold_ymm_k1z_m256_imm8 = 3809,

        /// <summary>
        /// vprold ymm {k1}{z}, m32bcst, imm8 |  | 
        /// </summary>
        [Symbol("vprold ymm {k1}{z}, m32bcst, imm8","vprold ymm {k1}{z}, m32bcst, imm8 |  | ")]
        vprold_ymm_k1z_m32bcst_imm8 = 3810,

        /// <summary>
        /// vprold ymm {k1}{z}, ymm, imm8 |  | 
        /// </summary>
        [Symbol("vprold ymm {k1}{z}, ymm, imm8","vprold ymm {k1}{z}, ymm, imm8 |  | ")]
        vprold_ymm_k1z_ymm_imm8 = 3811,

        /// <summary>
        /// vprold ymm, m256, imm8 |  | 
        /// </summary>
        [Symbol("vprold ymm, m256, imm8","vprold ymm, m256, imm8 |  | ")]
        vprold_ymm_m256_imm8 = 3812,

        /// <summary>
        /// vprold ymm, m32bcst, imm8 |  | 
        /// </summary>
        [Symbol("vprold ymm, m32bcst, imm8","vprold ymm, m32bcst, imm8 |  | ")]
        vprold_ymm_m32bcst_imm8 = 3813,

        /// <summary>
        /// vprold ymm, ymm, imm8 |  | 
        /// </summary>
        [Symbol("vprold ymm, ymm, imm8","vprold ymm, ymm, imm8 |  | ")]
        vprold_ymm_ymm_imm8 = 3814,

        /// <summary>
        /// vprold zmm {k1}{z}, m32bcst, imm8 |  | 
        /// </summary>
        [Symbol("vprold zmm {k1}{z}, m32bcst, imm8","vprold zmm {k1}{z}, m32bcst, imm8 |  | ")]
        vprold_zmm_k1z_m32bcst_imm8 = 3815,

        /// <summary>
        /// vprold zmm {k1}{z}, m512, imm8 |  | 
        /// </summary>
        [Symbol("vprold zmm {k1}{z}, m512, imm8","vprold zmm {k1}{z}, m512, imm8 |  | ")]
        vprold_zmm_k1z_m512_imm8 = 3816,

        /// <summary>
        /// vprold zmm {k1}{z}, zmm, imm8 |  | 
        /// </summary>
        [Symbol("vprold zmm {k1}{z}, zmm, imm8","vprold zmm {k1}{z}, zmm, imm8 |  | ")]
        vprold_zmm_k1z_zmm_imm8 = 3817,

        /// <summary>
        /// vprold zmm, m32bcst, imm8 |  | 
        /// </summary>
        [Symbol("vprold zmm, m32bcst, imm8","vprold zmm, m32bcst, imm8 |  | ")]
        vprold_zmm_m32bcst_imm8 = 3818,

        /// <summary>
        /// vprold zmm, m512, imm8 |  | 
        /// </summary>
        [Symbol("vprold zmm, m512, imm8","vprold zmm, m512, imm8 |  | ")]
        vprold_zmm_m512_imm8 = 3819,

        /// <summary>
        /// vprold zmm, zmm, imm8 |  | 
        /// </summary>
        [Symbol("vprold zmm, zmm, imm8","vprold zmm, zmm, imm8 |  | ")]
        vprold_zmm_zmm_imm8 = 3820,

        /// <summary>
        /// vprolq xmm {k1}{z}, m128, imm8 |  | 
        /// </summary>
        [Symbol("vprolq xmm {k1}{z}, m128, imm8","vprolq xmm {k1}{z}, m128, imm8 |  | ")]
        vprolq_xmm_k1z_m128_imm8 = 3821,

        /// <summary>
        /// vprolq xmm {k1}{z}, m64bcst, imm8 |  | 
        /// </summary>
        [Symbol("vprolq xmm {k1}{z}, m64bcst, imm8","vprolq xmm {k1}{z}, m64bcst, imm8 |  | ")]
        vprolq_xmm_k1z_m64bcst_imm8 = 3822,

        /// <summary>
        /// vprolq xmm {k1}{z}, xmm, imm8 |  | 
        /// </summary>
        [Symbol("vprolq xmm {k1}{z}, xmm, imm8","vprolq xmm {k1}{z}, xmm, imm8 |  | ")]
        vprolq_xmm_k1z_xmm_imm8 = 3823,

        /// <summary>
        /// vprolq xmm, m128, imm8 |  | 
        /// </summary>
        [Symbol("vprolq xmm, m128, imm8","vprolq xmm, m128, imm8 |  | ")]
        vprolq_xmm_m128_imm8 = 3824,

        /// <summary>
        /// vprolq xmm, m64bcst, imm8 |  | 
        /// </summary>
        [Symbol("vprolq xmm, m64bcst, imm8","vprolq xmm, m64bcst, imm8 |  | ")]
        vprolq_xmm_m64bcst_imm8 = 3825,

        /// <summary>
        /// vprolq xmm, xmm, imm8 |  | 
        /// </summary>
        [Symbol("vprolq xmm, xmm, imm8","vprolq xmm, xmm, imm8 |  | ")]
        vprolq_xmm_xmm_imm8 = 3826,

        /// <summary>
        /// vprolq ymm {k1}{z}, m256, imm8 |  | 
        /// </summary>
        [Symbol("vprolq ymm {k1}{z}, m256, imm8","vprolq ymm {k1}{z}, m256, imm8 |  | ")]
        vprolq_ymm_k1z_m256_imm8 = 3827,

        /// <summary>
        /// vprolq ymm {k1}{z}, m64bcst, imm8 |  | 
        /// </summary>
        [Symbol("vprolq ymm {k1}{z}, m64bcst, imm8","vprolq ymm {k1}{z}, m64bcst, imm8 |  | ")]
        vprolq_ymm_k1z_m64bcst_imm8 = 3828,

        /// <summary>
        /// vprolq ymm {k1}{z}, ymm, imm8 |  | 
        /// </summary>
        [Symbol("vprolq ymm {k1}{z}, ymm, imm8","vprolq ymm {k1}{z}, ymm, imm8 |  | ")]
        vprolq_ymm_k1z_ymm_imm8 = 3829,

        /// <summary>
        /// vprolq ymm, m256, imm8 |  | 
        /// </summary>
        [Symbol("vprolq ymm, m256, imm8","vprolq ymm, m256, imm8 |  | ")]
        vprolq_ymm_m256_imm8 = 3830,

        /// <summary>
        /// vprolq ymm, m64bcst, imm8 |  | 
        /// </summary>
        [Symbol("vprolq ymm, m64bcst, imm8","vprolq ymm, m64bcst, imm8 |  | ")]
        vprolq_ymm_m64bcst_imm8 = 3831,

        /// <summary>
        /// vprolq ymm, ymm, imm8 |  | 
        /// </summary>
        [Symbol("vprolq ymm, ymm, imm8","vprolq ymm, ymm, imm8 |  | ")]
        vprolq_ymm_ymm_imm8 = 3832,

        /// <summary>
        /// vprolq zmm {k1}{z}, m512, imm8 |  | 
        /// </summary>
        [Symbol("vprolq zmm {k1}{z}, m512, imm8","vprolq zmm {k1}{z}, m512, imm8 |  | ")]
        vprolq_zmm_k1z_m512_imm8 = 3833,

        /// <summary>
        /// vprolq zmm {k1}{z}, m64bcst, imm8 |  | 
        /// </summary>
        [Symbol("vprolq zmm {k1}{z}, m64bcst, imm8","vprolq zmm {k1}{z}, m64bcst, imm8 |  | ")]
        vprolq_zmm_k1z_m64bcst_imm8 = 3834,

        /// <summary>
        /// vprolq zmm {k1}{z}, zmm, imm8 |  | 
        /// </summary>
        [Symbol("vprolq zmm {k1}{z}, zmm, imm8","vprolq zmm {k1}{z}, zmm, imm8 |  | ")]
        vprolq_zmm_k1z_zmm_imm8 = 3835,

        /// <summary>
        /// vprolq zmm, m512, imm8 |  | 
        /// </summary>
        [Symbol("vprolq zmm, m512, imm8","vprolq zmm, m512, imm8 |  | ")]
        vprolq_zmm_m512_imm8 = 3836,

        /// <summary>
        /// vprolq zmm, m64bcst, imm8 |  | 
        /// </summary>
        [Symbol("vprolq zmm, m64bcst, imm8","vprolq zmm, m64bcst, imm8 |  | ")]
        vprolq_zmm_m64bcst_imm8 = 3837,

        /// <summary>
        /// vprolq zmm, zmm, imm8 |  | 
        /// </summary>
        [Symbol("vprolq zmm, zmm, imm8","vprolq zmm, zmm, imm8 |  | ")]
        vprolq_zmm_zmm_imm8 = 3838,

        /// <summary>
        /// vprolvd xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vprolvd xmm {k1}{z}, xmm, m128","vprolvd xmm {k1}{z}, xmm, m128 |  | ")]
        vprolvd_xmm_k1z_xmm_m128 = 3839,

        /// <summary>
        /// vprolvd xmm {k1}{z}, xmm, m32bcst |  | 
        /// </summary>
        [Symbol("vprolvd xmm {k1}{z}, xmm, m32bcst","vprolvd xmm {k1}{z}, xmm, m32bcst |  | ")]
        vprolvd_xmm_k1z_xmm_m32bcst = 3840,

        /// <summary>
        /// vprolvd xmm {k1}{z}, xmm, xmm |  | 
        /// </summary>
        [Symbol("vprolvd xmm {k1}{z}, xmm, xmm","vprolvd xmm {k1}{z}, xmm, xmm |  | ")]
        vprolvd_xmm_k1z_xmm_xmm = 3841,

        /// <summary>
        /// vprolvd xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vprolvd xmm, xmm, m128","vprolvd xmm, xmm, m128 |  | ")]
        vprolvd_xmm_xmm_m128 = 3842,

        /// <summary>
        /// vprolvd xmm, xmm, m32bcst |  | 
        /// </summary>
        [Symbol("vprolvd xmm, xmm, m32bcst","vprolvd xmm, xmm, m32bcst |  | ")]
        vprolvd_xmm_xmm_m32bcst = 3843,

        /// <summary>
        /// vprolvd xmm, xmm, xmm |  | 
        /// </summary>
        [Symbol("vprolvd xmm, xmm, xmm","vprolvd xmm, xmm, xmm |  | ")]
        vprolvd_xmm_xmm_xmm = 3844,

        /// <summary>
        /// vprolvd ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vprolvd ymm {k1}{z}, ymm, m256","vprolvd ymm {k1}{z}, ymm, m256 |  | ")]
        vprolvd_ymm_k1z_ymm_m256 = 3845,

        /// <summary>
        /// vprolvd ymm {k1}{z}, ymm, m32bcst |  | 
        /// </summary>
        [Symbol("vprolvd ymm {k1}{z}, ymm, m32bcst","vprolvd ymm {k1}{z}, ymm, m32bcst |  | ")]
        vprolvd_ymm_k1z_ymm_m32bcst = 3846,

        /// <summary>
        /// vprolvd ymm {k1}{z}, ymm, ymm |  | 
        /// </summary>
        [Symbol("vprolvd ymm {k1}{z}, ymm, ymm","vprolvd ymm {k1}{z}, ymm, ymm |  | ")]
        vprolvd_ymm_k1z_ymm_ymm = 3847,

        /// <summary>
        /// vprolvd ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vprolvd ymm, ymm, m256","vprolvd ymm, ymm, m256 |  | ")]
        vprolvd_ymm_ymm_m256 = 3848,

        /// <summary>
        /// vprolvd ymm, ymm, m32bcst |  | 
        /// </summary>
        [Symbol("vprolvd ymm, ymm, m32bcst","vprolvd ymm, ymm, m32bcst |  | ")]
        vprolvd_ymm_ymm_m32bcst = 3849,

        /// <summary>
        /// vprolvd ymm, ymm, ymm |  | 
        /// </summary>
        [Symbol("vprolvd ymm, ymm, ymm","vprolvd ymm, ymm, ymm |  | ")]
        vprolvd_ymm_ymm_ymm = 3850,

        /// <summary>
        /// vprolvd zmm {k1}{z}, zmm, m32bcst |  | 
        /// </summary>
        [Symbol("vprolvd zmm {k1}{z}, zmm, m32bcst","vprolvd zmm {k1}{z}, zmm, m32bcst |  | ")]
        vprolvd_zmm_k1z_zmm_m32bcst = 3851,

        /// <summary>
        /// vprolvd zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vprolvd zmm {k1}{z}, zmm, m512","vprolvd zmm {k1}{z}, zmm, m512 |  | ")]
        vprolvd_zmm_k1z_zmm_m512 = 3852,

        /// <summary>
        /// vprolvd zmm {k1}{z}, zmm, zmm |  | 
        /// </summary>
        [Symbol("vprolvd zmm {k1}{z}, zmm, zmm","vprolvd zmm {k1}{z}, zmm, zmm |  | ")]
        vprolvd_zmm_k1z_zmm_zmm = 3853,

        /// <summary>
        /// vprolvd zmm, zmm, m32bcst |  | 
        /// </summary>
        [Symbol("vprolvd zmm, zmm, m32bcst","vprolvd zmm, zmm, m32bcst |  | ")]
        vprolvd_zmm_zmm_m32bcst = 3854,

        /// <summary>
        /// vprolvd zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vprolvd zmm, zmm, m512","vprolvd zmm, zmm, m512 |  | ")]
        vprolvd_zmm_zmm_m512 = 3855,

        /// <summary>
        /// vprolvd zmm, zmm, zmm |  | 
        /// </summary>
        [Symbol("vprolvd zmm, zmm, zmm","vprolvd zmm, zmm, zmm |  | ")]
        vprolvd_zmm_zmm_zmm = 3856,

        /// <summary>
        /// vprolvq xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vprolvq xmm {k1}{z}, xmm, m128","vprolvq xmm {k1}{z}, xmm, m128 |  | ")]
        vprolvq_xmm_k1z_xmm_m128 = 3857,

        /// <summary>
        /// vprolvq xmm {k1}{z}, xmm, m64bcst |  | 
        /// </summary>
        [Symbol("vprolvq xmm {k1}{z}, xmm, m64bcst","vprolvq xmm {k1}{z}, xmm, m64bcst |  | ")]
        vprolvq_xmm_k1z_xmm_m64bcst = 3858,

        /// <summary>
        /// vprolvq xmm {k1}{z}, xmm, xmm |  | 
        /// </summary>
        [Symbol("vprolvq xmm {k1}{z}, xmm, xmm","vprolvq xmm {k1}{z}, xmm, xmm |  | ")]
        vprolvq_xmm_k1z_xmm_xmm = 3859,

        /// <summary>
        /// vprolvq xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vprolvq xmm, xmm, m128","vprolvq xmm, xmm, m128 |  | ")]
        vprolvq_xmm_xmm_m128 = 3860,

        /// <summary>
        /// vprolvq xmm, xmm, m64bcst |  | 
        /// </summary>
        [Symbol("vprolvq xmm, xmm, m64bcst","vprolvq xmm, xmm, m64bcst |  | ")]
        vprolvq_xmm_xmm_m64bcst = 3861,

        /// <summary>
        /// vprolvq xmm, xmm, xmm |  | 
        /// </summary>
        [Symbol("vprolvq xmm, xmm, xmm","vprolvq xmm, xmm, xmm |  | ")]
        vprolvq_xmm_xmm_xmm = 3862,

        /// <summary>
        /// vprolvq ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vprolvq ymm {k1}{z}, ymm, m256","vprolvq ymm {k1}{z}, ymm, m256 |  | ")]
        vprolvq_ymm_k1z_ymm_m256 = 3863,

        /// <summary>
        /// vprolvq ymm {k1}{z}, ymm, m64bcst |  | 
        /// </summary>
        [Symbol("vprolvq ymm {k1}{z}, ymm, m64bcst","vprolvq ymm {k1}{z}, ymm, m64bcst |  | ")]
        vprolvq_ymm_k1z_ymm_m64bcst = 3864,

        /// <summary>
        /// vprolvq ymm {k1}{z}, ymm, ymm |  | 
        /// </summary>
        [Symbol("vprolvq ymm {k1}{z}, ymm, ymm","vprolvq ymm {k1}{z}, ymm, ymm |  | ")]
        vprolvq_ymm_k1z_ymm_ymm = 3865,

        /// <summary>
        /// vprolvq ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vprolvq ymm, ymm, m256","vprolvq ymm, ymm, m256 |  | ")]
        vprolvq_ymm_ymm_m256 = 3866,

        /// <summary>
        /// vprolvq ymm, ymm, m64bcst |  | 
        /// </summary>
        [Symbol("vprolvq ymm, ymm, m64bcst","vprolvq ymm, ymm, m64bcst |  | ")]
        vprolvq_ymm_ymm_m64bcst = 3867,

        /// <summary>
        /// vprolvq ymm, ymm, ymm |  | 
        /// </summary>
        [Symbol("vprolvq ymm, ymm, ymm","vprolvq ymm, ymm, ymm |  | ")]
        vprolvq_ymm_ymm_ymm = 3868,

        /// <summary>
        /// vprolvq zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vprolvq zmm {k1}{z}, zmm, m512","vprolvq zmm {k1}{z}, zmm, m512 |  | ")]
        vprolvq_zmm_k1z_zmm_m512 = 3869,

        /// <summary>
        /// vprolvq zmm {k1}{z}, zmm, m64bcst |  | 
        /// </summary>
        [Symbol("vprolvq zmm {k1}{z}, zmm, m64bcst","vprolvq zmm {k1}{z}, zmm, m64bcst |  | ")]
        vprolvq_zmm_k1z_zmm_m64bcst = 3870,

        /// <summary>
        /// vprolvq zmm {k1}{z}, zmm, zmm |  | 
        /// </summary>
        [Symbol("vprolvq zmm {k1}{z}, zmm, zmm","vprolvq zmm {k1}{z}, zmm, zmm |  | ")]
        vprolvq_zmm_k1z_zmm_zmm = 3871,

        /// <summary>
        /// vprolvq zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vprolvq zmm, zmm, m512","vprolvq zmm, zmm, m512 |  | ")]
        vprolvq_zmm_zmm_m512 = 3872,

        /// <summary>
        /// vprolvq zmm, zmm, m64bcst |  | 
        /// </summary>
        [Symbol("vprolvq zmm, zmm, m64bcst","vprolvq zmm, zmm, m64bcst |  | ")]
        vprolvq_zmm_zmm_m64bcst = 3873,

        /// <summary>
        /// vprolvq zmm, zmm, zmm |  | 
        /// </summary>
        [Symbol("vprolvq zmm, zmm, zmm","vprolvq zmm, zmm, zmm |  | ")]
        vprolvq_zmm_zmm_zmm = 3874,

        /// <summary>
        /// vprord xmm {k1}{z}, m128, imm8 |  | 
        /// </summary>
        [Symbol("vprord xmm {k1}{z}, m128, imm8","vprord xmm {k1}{z}, m128, imm8 |  | ")]
        vprord_xmm_k1z_m128_imm8 = 3875,

        /// <summary>
        /// vprord xmm {k1}{z}, m32bcst, imm8 |  | 
        /// </summary>
        [Symbol("vprord xmm {k1}{z}, m32bcst, imm8","vprord xmm {k1}{z}, m32bcst, imm8 |  | ")]
        vprord_xmm_k1z_m32bcst_imm8 = 3876,

        /// <summary>
        /// vprord xmm {k1}{z}, xmm, imm8 |  | 
        /// </summary>
        [Symbol("vprord xmm {k1}{z}, xmm, imm8","vprord xmm {k1}{z}, xmm, imm8 |  | ")]
        vprord_xmm_k1z_xmm_imm8 = 3877,

        /// <summary>
        /// vprord xmm, m128, imm8 |  | 
        /// </summary>
        [Symbol("vprord xmm, m128, imm8","vprord xmm, m128, imm8 |  | ")]
        vprord_xmm_m128_imm8 = 3878,

        /// <summary>
        /// vprord xmm, m32bcst, imm8 |  | 
        /// </summary>
        [Symbol("vprord xmm, m32bcst, imm8","vprord xmm, m32bcst, imm8 |  | ")]
        vprord_xmm_m32bcst_imm8 = 3879,

        /// <summary>
        /// vprord xmm, xmm, imm8 |  | 
        /// </summary>
        [Symbol("vprord xmm, xmm, imm8","vprord xmm, xmm, imm8 |  | ")]
        vprord_xmm_xmm_imm8 = 3880,

        /// <summary>
        /// vprord ymm {k1}{z}, m256, imm8 |  | 
        /// </summary>
        [Symbol("vprord ymm {k1}{z}, m256, imm8","vprord ymm {k1}{z}, m256, imm8 |  | ")]
        vprord_ymm_k1z_m256_imm8 = 3881,

        /// <summary>
        /// vprord ymm {k1}{z}, m32bcst, imm8 |  | 
        /// </summary>
        [Symbol("vprord ymm {k1}{z}, m32bcst, imm8","vprord ymm {k1}{z}, m32bcst, imm8 |  | ")]
        vprord_ymm_k1z_m32bcst_imm8 = 3882,

        /// <summary>
        /// vprord ymm {k1}{z}, ymm, imm8 |  | 
        /// </summary>
        [Symbol("vprord ymm {k1}{z}, ymm, imm8","vprord ymm {k1}{z}, ymm, imm8 |  | ")]
        vprord_ymm_k1z_ymm_imm8 = 3883,

        /// <summary>
        /// vprord ymm, m256, imm8 |  | 
        /// </summary>
        [Symbol("vprord ymm, m256, imm8","vprord ymm, m256, imm8 |  | ")]
        vprord_ymm_m256_imm8 = 3884,

        /// <summary>
        /// vprord ymm, m32bcst, imm8 |  | 
        /// </summary>
        [Symbol("vprord ymm, m32bcst, imm8","vprord ymm, m32bcst, imm8 |  | ")]
        vprord_ymm_m32bcst_imm8 = 3885,

        /// <summary>
        /// vprord ymm, ymm, imm8 |  | 
        /// </summary>
        [Symbol("vprord ymm, ymm, imm8","vprord ymm, ymm, imm8 |  | ")]
        vprord_ymm_ymm_imm8 = 3886,

        /// <summary>
        /// vprord zmm {k1}{z}, m32bcst, imm8 |  | 
        /// </summary>
        [Symbol("vprord zmm {k1}{z}, m32bcst, imm8","vprord zmm {k1}{z}, m32bcst, imm8 |  | ")]
        vprord_zmm_k1z_m32bcst_imm8 = 3887,

        /// <summary>
        /// vprord zmm {k1}{z}, m512, imm8 |  | 
        /// </summary>
        [Symbol("vprord zmm {k1}{z}, m512, imm8","vprord zmm {k1}{z}, m512, imm8 |  | ")]
        vprord_zmm_k1z_m512_imm8 = 3888,

        /// <summary>
        /// vprord zmm {k1}{z}, zmm, imm8 |  | 
        /// </summary>
        [Symbol("vprord zmm {k1}{z}, zmm, imm8","vprord zmm {k1}{z}, zmm, imm8 |  | ")]
        vprord_zmm_k1z_zmm_imm8 = 3889,

        /// <summary>
        /// vprord zmm, m32bcst, imm8 |  | 
        /// </summary>
        [Symbol("vprord zmm, m32bcst, imm8","vprord zmm, m32bcst, imm8 |  | ")]
        vprord_zmm_m32bcst_imm8 = 3890,

        /// <summary>
        /// vprord zmm, m512, imm8 |  | 
        /// </summary>
        [Symbol("vprord zmm, m512, imm8","vprord zmm, m512, imm8 |  | ")]
        vprord_zmm_m512_imm8 = 3891,

        /// <summary>
        /// vprord zmm, zmm, imm8 |  | 
        /// </summary>
        [Symbol("vprord zmm, zmm, imm8","vprord zmm, zmm, imm8 |  | ")]
        vprord_zmm_zmm_imm8 = 3892,

        /// <summary>
        /// vprorq xmm {k1}{z}, m128, imm8 |  | 
        /// </summary>
        [Symbol("vprorq xmm {k1}{z}, m128, imm8","vprorq xmm {k1}{z}, m128, imm8 |  | ")]
        vprorq_xmm_k1z_m128_imm8 = 3893,

        /// <summary>
        /// vprorq xmm {k1}{z}, m64bcst, imm8 |  | 
        /// </summary>
        [Symbol("vprorq xmm {k1}{z}, m64bcst, imm8","vprorq xmm {k1}{z}, m64bcst, imm8 |  | ")]
        vprorq_xmm_k1z_m64bcst_imm8 = 3894,

        /// <summary>
        /// vprorq xmm {k1}{z}, xmm, imm8 |  | 
        /// </summary>
        [Symbol("vprorq xmm {k1}{z}, xmm, imm8","vprorq xmm {k1}{z}, xmm, imm8 |  | ")]
        vprorq_xmm_k1z_xmm_imm8 = 3895,

        /// <summary>
        /// vprorq xmm, m128, imm8 |  | 
        /// </summary>
        [Symbol("vprorq xmm, m128, imm8","vprorq xmm, m128, imm8 |  | ")]
        vprorq_xmm_m128_imm8 = 3896,

        /// <summary>
        /// vprorq xmm, m64bcst, imm8 |  | 
        /// </summary>
        [Symbol("vprorq xmm, m64bcst, imm8","vprorq xmm, m64bcst, imm8 |  | ")]
        vprorq_xmm_m64bcst_imm8 = 3897,

        /// <summary>
        /// vprorq xmm, xmm, imm8 |  | 
        /// </summary>
        [Symbol("vprorq xmm, xmm, imm8","vprorq xmm, xmm, imm8 |  | ")]
        vprorq_xmm_xmm_imm8 = 3898,

        /// <summary>
        /// vprorq ymm {k1}{z}, m256, imm8 |  | 
        /// </summary>
        [Symbol("vprorq ymm {k1}{z}, m256, imm8","vprorq ymm {k1}{z}, m256, imm8 |  | ")]
        vprorq_ymm_k1z_m256_imm8 = 3899,

        /// <summary>
        /// vprorq ymm {k1}{z}, m64bcst, imm8 |  | 
        /// </summary>
        [Symbol("vprorq ymm {k1}{z}, m64bcst, imm8","vprorq ymm {k1}{z}, m64bcst, imm8 |  | ")]
        vprorq_ymm_k1z_m64bcst_imm8 = 3900,

        /// <summary>
        /// vprorq ymm {k1}{z}, ymm, imm8 |  | 
        /// </summary>
        [Symbol("vprorq ymm {k1}{z}, ymm, imm8","vprorq ymm {k1}{z}, ymm, imm8 |  | ")]
        vprorq_ymm_k1z_ymm_imm8 = 3901,

        /// <summary>
        /// vprorq ymm, m256, imm8 |  | 
        /// </summary>
        [Symbol("vprorq ymm, m256, imm8","vprorq ymm, m256, imm8 |  | ")]
        vprorq_ymm_m256_imm8 = 3902,

        /// <summary>
        /// vprorq ymm, m64bcst, imm8 |  | 
        /// </summary>
        [Symbol("vprorq ymm, m64bcst, imm8","vprorq ymm, m64bcst, imm8 |  | ")]
        vprorq_ymm_m64bcst_imm8 = 3903,

        /// <summary>
        /// vprorq ymm, ymm, imm8 |  | 
        /// </summary>
        [Symbol("vprorq ymm, ymm, imm8","vprorq ymm, ymm, imm8 |  | ")]
        vprorq_ymm_ymm_imm8 = 3904,

        /// <summary>
        /// vprorq zmm {k1}{z}, m512, imm8 |  | 
        /// </summary>
        [Symbol("vprorq zmm {k1}{z}, m512, imm8","vprorq zmm {k1}{z}, m512, imm8 |  | ")]
        vprorq_zmm_k1z_m512_imm8 = 3905,

        /// <summary>
        /// vprorq zmm {k1}{z}, m64bcst, imm8 |  | 
        /// </summary>
        [Symbol("vprorq zmm {k1}{z}, m64bcst, imm8","vprorq zmm {k1}{z}, m64bcst, imm8 |  | ")]
        vprorq_zmm_k1z_m64bcst_imm8 = 3906,

        /// <summary>
        /// vprorq zmm {k1}{z}, zmm, imm8 |  | 
        /// </summary>
        [Symbol("vprorq zmm {k1}{z}, zmm, imm8","vprorq zmm {k1}{z}, zmm, imm8 |  | ")]
        vprorq_zmm_k1z_zmm_imm8 = 3907,

        /// <summary>
        /// vprorq zmm, m512, imm8 |  | 
        /// </summary>
        [Symbol("vprorq zmm, m512, imm8","vprorq zmm, m512, imm8 |  | ")]
        vprorq_zmm_m512_imm8 = 3908,

        /// <summary>
        /// vprorq zmm, m64bcst, imm8 |  | 
        /// </summary>
        [Symbol("vprorq zmm, m64bcst, imm8","vprorq zmm, m64bcst, imm8 |  | ")]
        vprorq_zmm_m64bcst_imm8 = 3909,

        /// <summary>
        /// vprorq zmm, zmm, imm8 |  | 
        /// </summary>
        [Symbol("vprorq zmm, zmm, imm8","vprorq zmm, zmm, imm8 |  | ")]
        vprorq_zmm_zmm_imm8 = 3910,

        /// <summary>
        /// vprorvd xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vprorvd xmm {k1}{z}, xmm, m128","vprorvd xmm {k1}{z}, xmm, m128 |  | ")]
        vprorvd_xmm_k1z_xmm_m128 = 3911,

        /// <summary>
        /// vprorvd xmm {k1}{z}, xmm, m32bcst |  | 
        /// </summary>
        [Symbol("vprorvd xmm {k1}{z}, xmm, m32bcst","vprorvd xmm {k1}{z}, xmm, m32bcst |  | ")]
        vprorvd_xmm_k1z_xmm_m32bcst = 3912,

        /// <summary>
        /// vprorvd xmm {k1}{z}, xmm, xmm |  | 
        /// </summary>
        [Symbol("vprorvd xmm {k1}{z}, xmm, xmm","vprorvd xmm {k1}{z}, xmm, xmm |  | ")]
        vprorvd_xmm_k1z_xmm_xmm = 3913,

        /// <summary>
        /// vprorvd xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vprorvd xmm, xmm, m128","vprorvd xmm, xmm, m128 |  | ")]
        vprorvd_xmm_xmm_m128 = 3914,

        /// <summary>
        /// vprorvd xmm, xmm, m32bcst |  | 
        /// </summary>
        [Symbol("vprorvd xmm, xmm, m32bcst","vprorvd xmm, xmm, m32bcst |  | ")]
        vprorvd_xmm_xmm_m32bcst = 3915,

        /// <summary>
        /// vprorvd xmm, xmm, xmm |  | 
        /// </summary>
        [Symbol("vprorvd xmm, xmm, xmm","vprorvd xmm, xmm, xmm |  | ")]
        vprorvd_xmm_xmm_xmm = 3916,

        /// <summary>
        /// vprorvd ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vprorvd ymm {k1}{z}, ymm, m256","vprorvd ymm {k1}{z}, ymm, m256 |  | ")]
        vprorvd_ymm_k1z_ymm_m256 = 3917,

        /// <summary>
        /// vprorvd ymm {k1}{z}, ymm, m32bcst |  | 
        /// </summary>
        [Symbol("vprorvd ymm {k1}{z}, ymm, m32bcst","vprorvd ymm {k1}{z}, ymm, m32bcst |  | ")]
        vprorvd_ymm_k1z_ymm_m32bcst = 3918,

        /// <summary>
        /// vprorvd ymm {k1}{z}, ymm, ymm |  | 
        /// </summary>
        [Symbol("vprorvd ymm {k1}{z}, ymm, ymm","vprorvd ymm {k1}{z}, ymm, ymm |  | ")]
        vprorvd_ymm_k1z_ymm_ymm = 3919,

        /// <summary>
        /// vprorvd ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vprorvd ymm, ymm, m256","vprorvd ymm, ymm, m256 |  | ")]
        vprorvd_ymm_ymm_m256 = 3920,

        /// <summary>
        /// vprorvd ymm, ymm, m32bcst |  | 
        /// </summary>
        [Symbol("vprorvd ymm, ymm, m32bcst","vprorvd ymm, ymm, m32bcst |  | ")]
        vprorvd_ymm_ymm_m32bcst = 3921,

        /// <summary>
        /// vprorvd ymm, ymm, ymm |  | 
        /// </summary>
        [Symbol("vprorvd ymm, ymm, ymm","vprorvd ymm, ymm, ymm |  | ")]
        vprorvd_ymm_ymm_ymm = 3922,

        /// <summary>
        /// vprorvd zmm {k1}{z}, zmm, m32bcst |  | 
        /// </summary>
        [Symbol("vprorvd zmm {k1}{z}, zmm, m32bcst","vprorvd zmm {k1}{z}, zmm, m32bcst |  | ")]
        vprorvd_zmm_k1z_zmm_m32bcst = 3923,

        /// <summary>
        /// vprorvd zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vprorvd zmm {k1}{z}, zmm, m512","vprorvd zmm {k1}{z}, zmm, m512 |  | ")]
        vprorvd_zmm_k1z_zmm_m512 = 3924,

        /// <summary>
        /// vprorvd zmm {k1}{z}, zmm, zmm |  | 
        /// </summary>
        [Symbol("vprorvd zmm {k1}{z}, zmm, zmm","vprorvd zmm {k1}{z}, zmm, zmm |  | ")]
        vprorvd_zmm_k1z_zmm_zmm = 3925,

        /// <summary>
        /// vprorvd zmm, zmm, m32bcst |  | 
        /// </summary>
        [Symbol("vprorvd zmm, zmm, m32bcst","vprorvd zmm, zmm, m32bcst |  | ")]
        vprorvd_zmm_zmm_m32bcst = 3926,

        /// <summary>
        /// vprorvd zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vprorvd zmm, zmm, m512","vprorvd zmm, zmm, m512 |  | ")]
        vprorvd_zmm_zmm_m512 = 3927,

        /// <summary>
        /// vprorvd zmm, zmm, zmm |  | 
        /// </summary>
        [Symbol("vprorvd zmm, zmm, zmm","vprorvd zmm, zmm, zmm |  | ")]
        vprorvd_zmm_zmm_zmm = 3928,

        /// <summary>
        /// vprorvq xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vprorvq xmm {k1}{z}, xmm, m128","vprorvq xmm {k1}{z}, xmm, m128 |  | ")]
        vprorvq_xmm_k1z_xmm_m128 = 3929,

        /// <summary>
        /// vprorvq xmm {k1}{z}, xmm, m64bcst |  | 
        /// </summary>
        [Symbol("vprorvq xmm {k1}{z}, xmm, m64bcst","vprorvq xmm {k1}{z}, xmm, m64bcst |  | ")]
        vprorvq_xmm_k1z_xmm_m64bcst = 3930,

        /// <summary>
        /// vprorvq xmm {k1}{z}, xmm, xmm |  | 
        /// </summary>
        [Symbol("vprorvq xmm {k1}{z}, xmm, xmm","vprorvq xmm {k1}{z}, xmm, xmm |  | ")]
        vprorvq_xmm_k1z_xmm_xmm = 3931,

        /// <summary>
        /// vprorvq xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vprorvq xmm, xmm, m128","vprorvq xmm, xmm, m128 |  | ")]
        vprorvq_xmm_xmm_m128 = 3932,

        /// <summary>
        /// vprorvq xmm, xmm, m64bcst |  | 
        /// </summary>
        [Symbol("vprorvq xmm, xmm, m64bcst","vprorvq xmm, xmm, m64bcst |  | ")]
        vprorvq_xmm_xmm_m64bcst = 3933,

        /// <summary>
        /// vprorvq xmm, xmm, xmm |  | 
        /// </summary>
        [Symbol("vprorvq xmm, xmm, xmm","vprorvq xmm, xmm, xmm |  | ")]
        vprorvq_xmm_xmm_xmm = 3934,

        /// <summary>
        /// vprorvq ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vprorvq ymm {k1}{z}, ymm, m256","vprorvq ymm {k1}{z}, ymm, m256 |  | ")]
        vprorvq_ymm_k1z_ymm_m256 = 3935,

        /// <summary>
        /// vprorvq ymm {k1}{z}, ymm, m64bcst |  | 
        /// </summary>
        [Symbol("vprorvq ymm {k1}{z}, ymm, m64bcst","vprorvq ymm {k1}{z}, ymm, m64bcst |  | ")]
        vprorvq_ymm_k1z_ymm_m64bcst = 3936,

        /// <summary>
        /// vprorvq ymm {k1}{z}, ymm, ymm |  | 
        /// </summary>
        [Symbol("vprorvq ymm {k1}{z}, ymm, ymm","vprorvq ymm {k1}{z}, ymm, ymm |  | ")]
        vprorvq_ymm_k1z_ymm_ymm = 3937,

        /// <summary>
        /// vprorvq ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vprorvq ymm, ymm, m256","vprorvq ymm, ymm, m256 |  | ")]
        vprorvq_ymm_ymm_m256 = 3938,

        /// <summary>
        /// vprorvq ymm, ymm, m64bcst |  | 
        /// </summary>
        [Symbol("vprorvq ymm, ymm, m64bcst","vprorvq ymm, ymm, m64bcst |  | ")]
        vprorvq_ymm_ymm_m64bcst = 3939,

        /// <summary>
        /// vprorvq ymm, ymm, ymm |  | 
        /// </summary>
        [Symbol("vprorvq ymm, ymm, ymm","vprorvq ymm, ymm, ymm |  | ")]
        vprorvq_ymm_ymm_ymm = 3940,

        /// <summary>
        /// vprorvq zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vprorvq zmm {k1}{z}, zmm, m512","vprorvq zmm {k1}{z}, zmm, m512 |  | ")]
        vprorvq_zmm_k1z_zmm_m512 = 3941,

        /// <summary>
        /// vprorvq zmm {k1}{z}, zmm, m64bcst |  | 
        /// </summary>
        [Symbol("vprorvq zmm {k1}{z}, zmm, m64bcst","vprorvq zmm {k1}{z}, zmm, m64bcst |  | ")]
        vprorvq_zmm_k1z_zmm_m64bcst = 3942,

        /// <summary>
        /// vprorvq zmm {k1}{z}, zmm, zmm |  | 
        /// </summary>
        [Symbol("vprorvq zmm {k1}{z}, zmm, zmm","vprorvq zmm {k1}{z}, zmm, zmm |  | ")]
        vprorvq_zmm_k1z_zmm_zmm = 3943,

        /// <summary>
        /// vprorvq zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vprorvq zmm, zmm, m512","vprorvq zmm, zmm, m512 |  | ")]
        vprorvq_zmm_zmm_m512 = 3944,

        /// <summary>
        /// vprorvq zmm, zmm, m64bcst |  | 
        /// </summary>
        [Symbol("vprorvq zmm, zmm, m64bcst","vprorvq zmm, zmm, m64bcst |  | ")]
        vprorvq_zmm_zmm_m64bcst = 3945,

        /// <summary>
        /// vprorvq zmm, zmm, zmm |  | 
        /// </summary>
        [Symbol("vprorvq zmm, zmm, zmm","vprorvq zmm, zmm, zmm |  | ")]
        vprorvq_zmm_zmm_zmm = 3946,

        /// <summary>
        /// vpscatterdd vm32x {k1}, xmm |  | 
        /// </summary>
        [Symbol("vpscatterdd vm32x {k1}, xmm","vpscatterdd vm32x {k1}, xmm |  | ")]
        vpscatterdd_vm32x_k1_xmm = 3947,

        /// <summary>
        /// vpscatterdd vm32x, xmm |  | 
        /// </summary>
        [Symbol("vpscatterdd vm32x, xmm","vpscatterdd vm32x, xmm |  | ")]
        vpscatterdd_vm32x_xmm = 3948,

        /// <summary>
        /// vpscatterdd vm32y {k1}, ymm |  | 
        /// </summary>
        [Symbol("vpscatterdd vm32y {k1}, ymm","vpscatterdd vm32y {k1}, ymm |  | ")]
        vpscatterdd_vm32y_k1_ymm = 3949,

        /// <summary>
        /// vpscatterdd vm32y, ymm |  | 
        /// </summary>
        [Symbol("vpscatterdd vm32y, ymm","vpscatterdd vm32y, ymm |  | ")]
        vpscatterdd_vm32y_ymm = 3950,

        /// <summary>
        /// vpscatterdd vm32z {k1}, zmm |  | 
        /// </summary>
        [Symbol("vpscatterdd vm32z {k1}, zmm","vpscatterdd vm32z {k1}, zmm |  | ")]
        vpscatterdd_vm32z_k1_zmm = 3951,

        /// <summary>
        /// vpscatterdd vm32z, zmm |  | 
        /// </summary>
        [Symbol("vpscatterdd vm32z, zmm","vpscatterdd vm32z, zmm |  | ")]
        vpscatterdd_vm32z_zmm = 3952,

        /// <summary>
        /// vpscatterdq vm32x {k1}, xmm |  | 
        /// </summary>
        [Symbol("vpscatterdq vm32x {k1}, xmm","vpscatterdq vm32x {k1}, xmm |  | ")]
        vpscatterdq_vm32x_k1_xmm = 3953,

        /// <summary>
        /// vpscatterdq vm32x {k1}, ymm |  | 
        /// </summary>
        [Symbol("vpscatterdq vm32x {k1}, ymm","vpscatterdq vm32x {k1}, ymm |  | ")]
        vpscatterdq_vm32x_k1_ymm = 3954,

        /// <summary>
        /// vpscatterdq vm32x, xmm |  | 
        /// </summary>
        [Symbol("vpscatterdq vm32x, xmm","vpscatterdq vm32x, xmm |  | ")]
        vpscatterdq_vm32x_xmm = 3955,

        /// <summary>
        /// vpscatterdq vm32x, ymm |  | 
        /// </summary>
        [Symbol("vpscatterdq vm32x, ymm","vpscatterdq vm32x, ymm |  | ")]
        vpscatterdq_vm32x_ymm = 3956,

        /// <summary>
        /// vpscatterdq vm32y {k1}, zmm |  | 
        /// </summary>
        [Symbol("vpscatterdq vm32y {k1}, zmm","vpscatterdq vm32y {k1}, zmm |  | ")]
        vpscatterdq_vm32y_k1_zmm = 3957,

        /// <summary>
        /// vpscatterdq vm32y, zmm |  | 
        /// </summary>
        [Symbol("vpscatterdq vm32y, zmm","vpscatterdq vm32y, zmm |  | ")]
        vpscatterdq_vm32y_zmm = 3958,

        /// <summary>
        /// vpscatterqd vm64x {k1}, xmm |  | 
        /// </summary>
        [Symbol("vpscatterqd vm64x {k1}, xmm","vpscatterqd vm64x {k1}, xmm |  | ")]
        vpscatterqd_vm64x_k1_xmm = 3959,

        /// <summary>
        /// vpscatterqd vm64x, xmm |  | 
        /// </summary>
        [Symbol("vpscatterqd vm64x, xmm","vpscatterqd vm64x, xmm |  | ")]
        vpscatterqd_vm64x_xmm = 3960,

        /// <summary>
        /// vpscatterqd vm64y {k1}, xmm |  | 
        /// </summary>
        [Symbol("vpscatterqd vm64y {k1}, xmm","vpscatterqd vm64y {k1}, xmm |  | ")]
        vpscatterqd_vm64y_k1_xmm = 3961,

        /// <summary>
        /// vpscatterqd vm64y, xmm |  | 
        /// </summary>
        [Symbol("vpscatterqd vm64y, xmm","vpscatterqd vm64y, xmm |  | ")]
        vpscatterqd_vm64y_xmm = 3962,

        /// <summary>
        /// vpscatterqd vm64z {k1}, ymm |  | 
        /// </summary>
        [Symbol("vpscatterqd vm64z {k1}, ymm","vpscatterqd vm64z {k1}, ymm |  | ")]
        vpscatterqd_vm64z_k1_ymm = 3963,

        /// <summary>
        /// vpscatterqd vm64z, ymm |  | 
        /// </summary>
        [Symbol("vpscatterqd vm64z, ymm","vpscatterqd vm64z, ymm |  | ")]
        vpscatterqd_vm64z_ymm = 3964,

        /// <summary>
        /// vpscatterqq vm64x {k1}, xmm |  | 
        /// </summary>
        [Symbol("vpscatterqq vm64x {k1}, xmm","vpscatterqq vm64x {k1}, xmm |  | ")]
        vpscatterqq_vm64x_k1_xmm = 3965,

        /// <summary>
        /// vpscatterqq vm64x, xmm |  | 
        /// </summary>
        [Symbol("vpscatterqq vm64x, xmm","vpscatterqq vm64x, xmm |  | ")]
        vpscatterqq_vm64x_xmm = 3966,

        /// <summary>
        /// vpscatterqq vm64y {k1}, ymm |  | 
        /// </summary>
        [Symbol("vpscatterqq vm64y {k1}, ymm","vpscatterqq vm64y {k1}, ymm |  | ")]
        vpscatterqq_vm64y_k1_ymm = 3967,

        /// <summary>
        /// vpscatterqq vm64y, ymm |  | 
        /// </summary>
        [Symbol("vpscatterqq vm64y, ymm","vpscatterqq vm64y, ymm |  | ")]
        vpscatterqq_vm64y_ymm = 3968,

        /// <summary>
        /// vpscatterqq vm64z {k1}, zmm |  | 
        /// </summary>
        [Symbol("vpscatterqq vm64z {k1}, zmm","vpscatterqq vm64z {k1}, zmm |  | ")]
        vpscatterqq_vm64z_k1_zmm = 3969,

        /// <summary>
        /// vpscatterqq vm64z, zmm |  | 
        /// </summary>
        [Symbol("vpscatterqq vm64z, zmm","vpscatterqq vm64z, zmm |  | ")]
        vpscatterqq_vm64z_zmm = 3970,

        /// <summary>
        /// vpshufb xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpshufb xmm {k1}{z}, xmm, m128","vpshufb xmm {k1}{z}, xmm, m128 |  | ")]
        vpshufb_xmm_k1z_xmm_m128 = 3971,

        /// <summary>
        /// vpshufb xmm {k1}{z}, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpshufb xmm {k1}{z}, xmm, r8","vpshufb xmm {k1}{z}, xmm, r8 |  | ")]
        vpshufb_xmm_k1z_xmm_r8 = 3972,

        /// <summary>
        /// vpshufb xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpshufb xmm, xmm, m128","vpshufb xmm, xmm, m128 |  | ")]
        vpshufb_xmm_xmm_m128 = 3973,

        /// <summary>
        /// vpshufb xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpshufb xmm, xmm, r8","vpshufb xmm, xmm, r8 |  | ")]
        vpshufb_xmm_xmm_r8 = 3974,

        /// <summary>
        /// vpshufb ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpshufb ymm {k1}{z}, ymm, m256","vpshufb ymm {k1}{z}, ymm, m256 |  | ")]
        vpshufb_ymm_k1z_ymm_m256 = 3975,

        /// <summary>
        /// vpshufb ymm {k1}{z}, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpshufb ymm {k1}{z}, ymm, r16","vpshufb ymm {k1}{z}, ymm, r16 |  | ")]
        vpshufb_ymm_k1z_ymm_r16 = 3976,

        /// <summary>
        /// vpshufb ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpshufb ymm, ymm, m256","vpshufb ymm, ymm, m256 |  | ")]
        vpshufb_ymm_ymm_m256 = 3977,

        /// <summary>
        /// vpshufb ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpshufb ymm, ymm, r16","vpshufb ymm, ymm, r16 |  | ")]
        vpshufb_ymm_ymm_r16 = 3978,

        /// <summary>
        /// vpshufb zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpshufb zmm {k1}{z}, zmm, m512","vpshufb zmm {k1}{z}, zmm, m512 |  | ")]
        vpshufb_zmm_k1z_zmm_m512 = 3979,

        /// <summary>
        /// vpshufb zmm {k1}{z}, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpshufb zmm {k1}{z}, zmm, r32","vpshufb zmm {k1}{z}, zmm, r32 |  | ")]
        vpshufb_zmm_k1z_zmm_r32 = 3980,

        /// <summary>
        /// vpshufb zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpshufb zmm, zmm, m512","vpshufb zmm, zmm, m512 |  | ")]
        vpshufb_zmm_zmm_m512 = 3981,

        /// <summary>
        /// vpshufb zmm, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpshufb zmm, zmm, r32","vpshufb zmm, zmm, r32 |  | ")]
        vpshufb_zmm_zmm_r32 = 3982,

        /// <summary>
        /// vpshufd xmm {k1}{z}, m128, imm8 |  | 
        /// </summary>
        [Symbol("vpshufd xmm {k1}{z}, m128, imm8","vpshufd xmm {k1}{z}, m128, imm8 |  | ")]
        vpshufd_xmm_k1z_m128_imm8 = 3983,

        /// <summary>
        /// vpshufd xmm {k1}{z}, m32bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpshufd xmm {k1}{z}, m32bcst, imm8","vpshufd xmm {k1}{z}, m32bcst, imm8 |  | ")]
        vpshufd_xmm_k1z_m32bcst_imm8 = 3984,

        /// <summary>
        /// vpshufd xmm {k1}{z}, xmm, imm8 |  | 
        /// </summary>
        [Symbol("vpshufd xmm {k1}{z}, xmm, imm8","vpshufd xmm {k1}{z}, xmm, imm8 |  | ")]
        vpshufd_xmm_k1z_xmm_imm8 = 3985,

        /// <summary>
        /// vpshufd xmm, m128, imm8 |  | 
        /// </summary>
        [Symbol("vpshufd xmm, m128, imm8","vpshufd xmm, m128, imm8 |  | ")]
        vpshufd_xmm_m128_imm8 = 3986,

        /// <summary>
        /// vpshufd xmm, m32bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpshufd xmm, m32bcst, imm8","vpshufd xmm, m32bcst, imm8 |  | ")]
        vpshufd_xmm_m32bcst_imm8 = 3987,

        /// <summary>
        /// vpshufd xmm, r8, imm8 |  | 
        /// </summary>
        [Symbol("vpshufd xmm, r8, imm8","vpshufd xmm, r8, imm8 |  | ")]
        vpshufd_xmm_r8_imm8 = 3988,

        /// <summary>
        /// vpshufd xmm, xmm, imm8 |  | 
        /// </summary>
        [Symbol("vpshufd xmm, xmm, imm8","vpshufd xmm, xmm, imm8 |  | ")]
        vpshufd_xmm_xmm_imm8 = 3989,

        /// <summary>
        /// vpshufd ymm {k1}{z}, m256, imm8 |  | 
        /// </summary>
        [Symbol("vpshufd ymm {k1}{z}, m256, imm8","vpshufd ymm {k1}{z}, m256, imm8 |  | ")]
        vpshufd_ymm_k1z_m256_imm8 = 3990,

        /// <summary>
        /// vpshufd ymm {k1}{z}, m32bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpshufd ymm {k1}{z}, m32bcst, imm8","vpshufd ymm {k1}{z}, m32bcst, imm8 |  | ")]
        vpshufd_ymm_k1z_m32bcst_imm8 = 3991,

        /// <summary>
        /// vpshufd ymm {k1}{z}, ymm, imm8 |  | 
        /// </summary>
        [Symbol("vpshufd ymm {k1}{z}, ymm, imm8","vpshufd ymm {k1}{z}, ymm, imm8 |  | ")]
        vpshufd_ymm_k1z_ymm_imm8 = 3992,

        /// <summary>
        /// vpshufd ymm, m256, imm8 |  | 
        /// </summary>
        [Symbol("vpshufd ymm, m256, imm8","vpshufd ymm, m256, imm8 |  | ")]
        vpshufd_ymm_m256_imm8 = 3993,

        /// <summary>
        /// vpshufd ymm, m32bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpshufd ymm, m32bcst, imm8","vpshufd ymm, m32bcst, imm8 |  | ")]
        vpshufd_ymm_m32bcst_imm8 = 3994,

        /// <summary>
        /// vpshufd ymm, r16, imm8 |  | 
        /// </summary>
        [Symbol("vpshufd ymm, r16, imm8","vpshufd ymm, r16, imm8 |  | ")]
        vpshufd_ymm_r16_imm8 = 3995,

        /// <summary>
        /// vpshufd ymm, ymm, imm8 |  | 
        /// </summary>
        [Symbol("vpshufd ymm, ymm, imm8","vpshufd ymm, ymm, imm8 |  | ")]
        vpshufd_ymm_ymm_imm8 = 3996,

        /// <summary>
        /// vpshufd zmm {k1}{z}, m32bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpshufd zmm {k1}{z}, m32bcst, imm8","vpshufd zmm {k1}{z}, m32bcst, imm8 |  | ")]
        vpshufd_zmm_k1z_m32bcst_imm8 = 3997,

        /// <summary>
        /// vpshufd zmm {k1}{z}, m512, imm8 |  | 
        /// </summary>
        [Symbol("vpshufd zmm {k1}{z}, m512, imm8","vpshufd zmm {k1}{z}, m512, imm8 |  | ")]
        vpshufd_zmm_k1z_m512_imm8 = 3998,

        /// <summary>
        /// vpshufd zmm {k1}{z}, zmm, imm8 |  | 
        /// </summary>
        [Symbol("vpshufd zmm {k1}{z}, zmm, imm8","vpshufd zmm {k1}{z}, zmm, imm8 |  | ")]
        vpshufd_zmm_k1z_zmm_imm8 = 3999,

        /// <summary>
        /// vpshufd zmm, m32bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpshufd zmm, m32bcst, imm8","vpshufd zmm, m32bcst, imm8 |  | ")]
        vpshufd_zmm_m32bcst_imm8 = 4000,

        /// <summary>
        /// vpshufd zmm, m512, imm8 |  | 
        /// </summary>
        [Symbol("vpshufd zmm, m512, imm8","vpshufd zmm, m512, imm8 |  | ")]
        vpshufd_zmm_m512_imm8 = 4001,

        /// <summary>
        /// vpshufd zmm, zmm, imm8 |  | 
        /// </summary>
        [Symbol("vpshufd zmm, zmm, imm8","vpshufd zmm, zmm, imm8 |  | ")]
        vpshufd_zmm_zmm_imm8 = 4002,

        /// <summary>
        /// vpshuflw xmm {k1}{z}, m128, imm8 |  | 
        /// </summary>
        [Symbol("vpshuflw xmm {k1}{z}, m128, imm8","vpshuflw xmm {k1}{z}, m128, imm8 |  | ")]
        vpshuflw_xmm_k1z_m128_imm8 = 4003,

        /// <summary>
        /// vpshuflw xmm {k1}{z}, r8, imm8 |  | 
        /// </summary>
        [Symbol("vpshuflw xmm {k1}{z}, r8, imm8","vpshuflw xmm {k1}{z}, r8, imm8 |  | ")]
        vpshuflw_xmm_k1z_r8_imm8 = 4004,

        /// <summary>
        /// vpshuflw xmm, m128, imm8 |  | 
        /// </summary>
        [Symbol("vpshuflw xmm, m128, imm8","vpshuflw xmm, m128, imm8 |  | ")]
        vpshuflw_xmm_m128_imm8 = 4005,

        /// <summary>
        /// vpshuflw xmm, r8, imm8 |  | 
        /// </summary>
        [Symbol("vpshuflw xmm, r8, imm8","vpshuflw xmm, r8, imm8 |  | ")]
        vpshuflw_xmm_r8_imm8 = 4006,

        /// <summary>
        /// vpshuflw ymm {k1}{z}, m256, imm8 |  | 
        /// </summary>
        [Symbol("vpshuflw ymm {k1}{z}, m256, imm8","vpshuflw ymm {k1}{z}, m256, imm8 |  | ")]
        vpshuflw_ymm_k1z_m256_imm8 = 4007,

        /// <summary>
        /// vpshuflw ymm {k1}{z}, r16, imm8 |  | 
        /// </summary>
        [Symbol("vpshuflw ymm {k1}{z}, r16, imm8","vpshuflw ymm {k1}{z}, r16, imm8 |  | ")]
        vpshuflw_ymm_k1z_r16_imm8 = 4008,

        /// <summary>
        /// vpshuflw ymm, m256, imm8 |  | 
        /// </summary>
        [Symbol("vpshuflw ymm, m256, imm8","vpshuflw ymm, m256, imm8 |  | ")]
        vpshuflw_ymm_m256_imm8 = 4009,

        /// <summary>
        /// vpshuflw ymm, r16, imm8 |  | 
        /// </summary>
        [Symbol("vpshuflw ymm, r16, imm8","vpshuflw ymm, r16, imm8 |  | ")]
        vpshuflw_ymm_r16_imm8 = 4010,

        /// <summary>
        /// vpshuflw zmm {k1}{z}, m512, imm8 |  | 
        /// </summary>
        [Symbol("vpshuflw zmm {k1}{z}, m512, imm8","vpshuflw zmm {k1}{z}, m512, imm8 |  | ")]
        vpshuflw_zmm_k1z_m512_imm8 = 4011,

        /// <summary>
        /// vpshuflw zmm {k1}{z}, r32, imm8 |  | 
        /// </summary>
        [Symbol("vpshuflw zmm {k1}{z}, r32, imm8","vpshuflw zmm {k1}{z}, r32, imm8 |  | ")]
        vpshuflw_zmm_k1z_r32_imm8 = 4012,

        /// <summary>
        /// vpshuflw zmm, m512, imm8 |  | 
        /// </summary>
        [Symbol("vpshuflw zmm, m512, imm8","vpshuflw zmm, m512, imm8 |  | ")]
        vpshuflw_zmm_m512_imm8 = 4013,

        /// <summary>
        /// vpshuflw zmm, r32, imm8 |  | 
        /// </summary>
        [Symbol("vpshuflw zmm, r32, imm8","vpshuflw zmm, r32, imm8 |  | ")]
        vpshuflw_zmm_r32_imm8 = 4014,

        /// <summary>
        /// vpsignb xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpsignb xmm, xmm, m128","vpsignb xmm, xmm, m128 |  | ")]
        vpsignb_xmm_xmm_m128 = 4015,

        /// <summary>
        /// vpsignb xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpsignb xmm, xmm, r8","vpsignb xmm, xmm, r8 |  | ")]
        vpsignb_xmm_xmm_r8 = 4016,

        /// <summary>
        /// vpsignb ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpsignb ymm, ymm, m256","vpsignb ymm, ymm, m256 |  | ")]
        vpsignb_ymm_ymm_m256 = 4017,

        /// <summary>
        /// vpsignb ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpsignb ymm, ymm, r16","vpsignb ymm, ymm, r16 |  | ")]
        vpsignb_ymm_ymm_r16 = 4018,

        /// <summary>
        /// vpsignd xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpsignd xmm, xmm, m128","vpsignd xmm, xmm, m128 |  | ")]
        vpsignd_xmm_xmm_m128 = 4019,

        /// <summary>
        /// vpsignd xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpsignd xmm, xmm, r8","vpsignd xmm, xmm, r8 |  | ")]
        vpsignd_xmm_xmm_r8 = 4020,

        /// <summary>
        /// vpsignd ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpsignd ymm, ymm, m256","vpsignd ymm, ymm, m256 |  | ")]
        vpsignd_ymm_ymm_m256 = 4021,

        /// <summary>
        /// vpsignd ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpsignd ymm, ymm, r16","vpsignd ymm, ymm, r16 |  | ")]
        vpsignd_ymm_ymm_r16 = 4022,

        /// <summary>
        /// vpsignw xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpsignw xmm, xmm, m128","vpsignw xmm, xmm, m128 |  | ")]
        vpsignw_xmm_xmm_m128 = 4023,

        /// <summary>
        /// vpsignw xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpsignw xmm, xmm, r8","vpsignw xmm, xmm, r8 |  | ")]
        vpsignw_xmm_xmm_r8 = 4024,

        /// <summary>
        /// vpsignw ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpsignw ymm, ymm, m256","vpsignw ymm, ymm, m256 |  | ")]
        vpsignw_ymm_ymm_m256 = 4025,

        /// <summary>
        /// vpsignw ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpsignw ymm, ymm, r16","vpsignw ymm, ymm, r16 |  | ")]
        vpsignw_ymm_ymm_r16 = 4026,

        /// <summary>
        /// vpslld xmm {k1}{z}, m128, imm8 |  | 
        /// </summary>
        [Symbol("vpslld xmm {k1}{z}, m128, imm8","vpslld xmm {k1}{z}, m128, imm8 |  | ")]
        vpslld_xmm_k1z_m128_imm8 = 4027,

        /// <summary>
        /// vpslld xmm {k1}{z}, m32bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpslld xmm {k1}{z}, m32bcst, imm8","vpslld xmm {k1}{z}, m32bcst, imm8 |  | ")]
        vpslld_xmm_k1z_m32bcst_imm8 = 4028,

        /// <summary>
        /// vpslld xmm {k1}{z}, xmm, imm8 |  | 
        /// </summary>
        [Symbol("vpslld xmm {k1}{z}, xmm, imm8","vpslld xmm {k1}{z}, xmm, imm8 |  | ")]
        vpslld_xmm_k1z_xmm_imm8 = 4029,

        /// <summary>
        /// vpslld xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpslld xmm {k1}{z}, xmm, m128","vpslld xmm {k1}{z}, xmm, m128 |  | ")]
        vpslld_xmm_k1z_xmm_m128 = 4030,

        /// <summary>
        /// vpslld xmm {k1}{z}, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpslld xmm {k1}{z}, xmm, r8","vpslld xmm {k1}{z}, xmm, r8 |  | ")]
        vpslld_xmm_k1z_xmm_r8 = 4031,

        /// <summary>
        /// vpslld xmm, m128, imm8 |  | 
        /// </summary>
        [Symbol("vpslld xmm, m128, imm8","vpslld xmm, m128, imm8 |  | ")]
        vpslld_xmm_m128_imm8 = 4032,

        /// <summary>
        /// vpslld xmm, m32bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpslld xmm, m32bcst, imm8","vpslld xmm, m32bcst, imm8 |  | ")]
        vpslld_xmm_m32bcst_imm8 = 4033,

        /// <summary>
        /// vpslld xmm, xmm, imm8 |  | 
        /// </summary>
        [Symbol("vpslld xmm, xmm, imm8","vpslld xmm, xmm, imm8 |  | ")]
        vpslld_xmm_xmm_imm8 = 4034,

        /// <summary>
        /// vpslld xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpslld xmm, xmm, m128","vpslld xmm, xmm, m128 |  | ")]
        vpslld_xmm_xmm_m128 = 4035,

        /// <summary>
        /// vpslld xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpslld xmm, xmm, r8","vpslld xmm, xmm, r8 |  | ")]
        vpslld_xmm_xmm_r8 = 4036,

        /// <summary>
        /// vpslld ymm {k1}{z}, m256, imm8 |  | 
        /// </summary>
        [Symbol("vpslld ymm {k1}{z}, m256, imm8","vpslld ymm {k1}{z}, m256, imm8 |  | ")]
        vpslld_ymm_k1z_m256_imm8 = 4037,

        /// <summary>
        /// vpslld ymm {k1}{z}, m32bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpslld ymm {k1}{z}, m32bcst, imm8","vpslld ymm {k1}{z}, m32bcst, imm8 |  | ")]
        vpslld_ymm_k1z_m32bcst_imm8 = 4038,

        /// <summary>
        /// vpslld ymm {k1}{z}, ymm, imm8 |  | 
        /// </summary>
        [Symbol("vpslld ymm {k1}{z}, ymm, imm8","vpslld ymm {k1}{z}, ymm, imm8 |  | ")]
        vpslld_ymm_k1z_ymm_imm8 = 4039,

        /// <summary>
        /// vpslld ymm {k1}{z}, ymm, m128 |  | 
        /// </summary>
        [Symbol("vpslld ymm {k1}{z}, ymm, m128","vpslld ymm {k1}{z}, ymm, m128 |  | ")]
        vpslld_ymm_k1z_ymm_m128 = 4040,

        /// <summary>
        /// vpslld ymm {k1}{z}, ymm, r8 |  | 
        /// </summary>
        [Symbol("vpslld ymm {k1}{z}, ymm, r8","vpslld ymm {k1}{z}, ymm, r8 |  | ")]
        vpslld_ymm_k1z_ymm_r8 = 4041,

        /// <summary>
        /// vpslld ymm, m256, imm8 |  | 
        /// </summary>
        [Symbol("vpslld ymm, m256, imm8","vpslld ymm, m256, imm8 |  | ")]
        vpslld_ymm_m256_imm8 = 4042,

        /// <summary>
        /// vpslld ymm, m32bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpslld ymm, m32bcst, imm8","vpslld ymm, m32bcst, imm8 |  | ")]
        vpslld_ymm_m32bcst_imm8 = 4043,

        /// <summary>
        /// vpslld ymm, ymm, imm8 |  | 
        /// </summary>
        [Symbol("vpslld ymm, ymm, imm8","vpslld ymm, ymm, imm8 |  | ")]
        vpslld_ymm_ymm_imm8 = 4044,

        /// <summary>
        /// vpslld ymm, ymm, m128 |  | 
        /// </summary>
        [Symbol("vpslld ymm, ymm, m128","vpslld ymm, ymm, m128 |  | ")]
        vpslld_ymm_ymm_m128 = 4045,

        /// <summary>
        /// vpslld ymm, ymm, r8 |  | 
        /// </summary>
        [Symbol("vpslld ymm, ymm, r8","vpslld ymm, ymm, r8 |  | ")]
        vpslld_ymm_ymm_r8 = 4046,

        /// <summary>
        /// vpslld zmm {k1}{z}, m32bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpslld zmm {k1}{z}, m32bcst, imm8","vpslld zmm {k1}{z}, m32bcst, imm8 |  | ")]
        vpslld_zmm_k1z_m32bcst_imm8 = 4047,

        /// <summary>
        /// vpslld zmm {k1}{z}, m512, imm8 |  | 
        /// </summary>
        [Symbol("vpslld zmm {k1}{z}, m512, imm8","vpslld zmm {k1}{z}, m512, imm8 |  | ")]
        vpslld_zmm_k1z_m512_imm8 = 4048,

        /// <summary>
        /// vpslld zmm {k1}{z}, zmm, imm8 |  | 
        /// </summary>
        [Symbol("vpslld zmm {k1}{z}, zmm, imm8","vpslld zmm {k1}{z}, zmm, imm8 |  | ")]
        vpslld_zmm_k1z_zmm_imm8 = 4049,

        /// <summary>
        /// vpslld zmm {k1}{z}, zmm, m128 |  | 
        /// </summary>
        [Symbol("vpslld zmm {k1}{z}, zmm, m128","vpslld zmm {k1}{z}, zmm, m128 |  | ")]
        vpslld_zmm_k1z_zmm_m128 = 4050,

        /// <summary>
        /// vpslld zmm {k1}{z}, zmm, r8 |  | 
        /// </summary>
        [Symbol("vpslld zmm {k1}{z}, zmm, r8","vpslld zmm {k1}{z}, zmm, r8 |  | ")]
        vpslld_zmm_k1z_zmm_r8 = 4051,

        /// <summary>
        /// vpslld zmm, m32bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpslld zmm, m32bcst, imm8","vpslld zmm, m32bcst, imm8 |  | ")]
        vpslld_zmm_m32bcst_imm8 = 4052,

        /// <summary>
        /// vpslld zmm, m512, imm8 |  | 
        /// </summary>
        [Symbol("vpslld zmm, m512, imm8","vpslld zmm, m512, imm8 |  | ")]
        vpslld_zmm_m512_imm8 = 4053,

        /// <summary>
        /// vpslld zmm, zmm, imm8 |  | 
        /// </summary>
        [Symbol("vpslld zmm, zmm, imm8","vpslld zmm, zmm, imm8 |  | ")]
        vpslld_zmm_zmm_imm8 = 4054,

        /// <summary>
        /// vpslld zmm, zmm, m128 |  | 
        /// </summary>
        [Symbol("vpslld zmm, zmm, m128","vpslld zmm, zmm, m128 |  | ")]
        vpslld_zmm_zmm_m128 = 4055,

        /// <summary>
        /// vpslld zmm, zmm, r8 |  | 
        /// </summary>
        [Symbol("vpslld zmm, zmm, r8","vpslld zmm, zmm, r8 |  | ")]
        vpslld_zmm_zmm_r8 = 4056,

        /// <summary>
        /// vpslldq xmm, m128, imm8 |  | 
        /// </summary>
        [Symbol("vpslldq xmm, m128, imm8","vpslldq xmm, m128, imm8 |  | ")]
        vpslldq_xmm_m128_imm8 = 4057,

        /// <summary>
        /// vpslldq xmm, r8, imm8 |  | 
        /// </summary>
        [Symbol("vpslldq xmm, r8, imm8","vpslldq xmm, r8, imm8 |  | ")]
        vpslldq_xmm_r8_imm8 = 4058,

        /// <summary>
        /// vpslldq xmm, xmm, imm8 |  | 
        /// </summary>
        [Symbol("vpslldq xmm, xmm, imm8","vpslldq xmm, xmm, imm8 |  | ")]
        vpslldq_xmm_xmm_imm8 = 4059,

        /// <summary>
        /// vpslldq ymm, m256, imm8 |  | 
        /// </summary>
        [Symbol("vpslldq ymm, m256, imm8","vpslldq ymm, m256, imm8 |  | ")]
        vpslldq_ymm_m256_imm8 = 4060,

        /// <summary>
        /// vpslldq ymm, r16, imm8 |  | 
        /// </summary>
        [Symbol("vpslldq ymm, r16, imm8","vpslldq ymm, r16, imm8 |  | ")]
        vpslldq_ymm_r16_imm8 = 4061,

        /// <summary>
        /// vpslldq ymm, ymm, imm8 |  | 
        /// </summary>
        [Symbol("vpslldq ymm, ymm, imm8","vpslldq ymm, ymm, imm8 |  | ")]
        vpslldq_ymm_ymm_imm8 = 4062,

        /// <summary>
        /// vpslldq zmm, m512, imm8 |  | 
        /// </summary>
        [Symbol("vpslldq zmm, m512, imm8","vpslldq zmm, m512, imm8 |  | ")]
        vpslldq_zmm_m512_imm8 = 4063,

        /// <summary>
        /// vpslldq zmm, r32, imm8 |  | 
        /// </summary>
        [Symbol("vpslldq zmm, r32, imm8","vpslldq zmm, r32, imm8 |  | ")]
        vpslldq_zmm_r32_imm8 = 4064,

        /// <summary>
        /// vpsllq xmm {k1}{z}, m128, imm8 |  | 
        /// </summary>
        [Symbol("vpsllq xmm {k1}{z}, m128, imm8","vpsllq xmm {k1}{z}, m128, imm8 |  | ")]
        vpsllq_xmm_k1z_m128_imm8 = 4065,

        /// <summary>
        /// vpsllq xmm {k1}{z}, m64bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpsllq xmm {k1}{z}, m64bcst, imm8","vpsllq xmm {k1}{z}, m64bcst, imm8 |  | ")]
        vpsllq_xmm_k1z_m64bcst_imm8 = 4066,

        /// <summary>
        /// vpsllq xmm {k1}{z}, xmm, imm8 |  | 
        /// </summary>
        [Symbol("vpsllq xmm {k1}{z}, xmm, imm8","vpsllq xmm {k1}{z}, xmm, imm8 |  | ")]
        vpsllq_xmm_k1z_xmm_imm8 = 4067,

        /// <summary>
        /// vpsllq xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpsllq xmm {k1}{z}, xmm, m128","vpsllq xmm {k1}{z}, xmm, m128 |  | ")]
        vpsllq_xmm_k1z_xmm_m128 = 4068,

        /// <summary>
        /// vpsllq xmm {k1}{z}, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpsllq xmm {k1}{z}, xmm, r8","vpsllq xmm {k1}{z}, xmm, r8 |  | ")]
        vpsllq_xmm_k1z_xmm_r8 = 4069,

        /// <summary>
        /// vpsllq xmm, m128, imm8 |  | 
        /// </summary>
        [Symbol("vpsllq xmm, m128, imm8","vpsllq xmm, m128, imm8 |  | ")]
        vpsllq_xmm_m128_imm8 = 4070,

        /// <summary>
        /// vpsllq xmm, m64bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpsllq xmm, m64bcst, imm8","vpsllq xmm, m64bcst, imm8 |  | ")]
        vpsllq_xmm_m64bcst_imm8 = 4071,

        /// <summary>
        /// vpsllq xmm, xmm, imm8 |  | 
        /// </summary>
        [Symbol("vpsllq xmm, xmm, imm8","vpsllq xmm, xmm, imm8 |  | ")]
        vpsllq_xmm_xmm_imm8 = 4072,

        /// <summary>
        /// vpsllq xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpsllq xmm, xmm, m128","vpsllq xmm, xmm, m128 |  | ")]
        vpsllq_xmm_xmm_m128 = 4073,

        /// <summary>
        /// vpsllq xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpsllq xmm, xmm, r8","vpsllq xmm, xmm, r8 |  | ")]
        vpsllq_xmm_xmm_r8 = 4074,

        /// <summary>
        /// vpsllq ymm {k1}{z}, m256, imm8 |  | 
        /// </summary>
        [Symbol("vpsllq ymm {k1}{z}, m256, imm8","vpsllq ymm {k1}{z}, m256, imm8 |  | ")]
        vpsllq_ymm_k1z_m256_imm8 = 4075,

        /// <summary>
        /// vpsllq ymm {k1}{z}, m64bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpsllq ymm {k1}{z}, m64bcst, imm8","vpsllq ymm {k1}{z}, m64bcst, imm8 |  | ")]
        vpsllq_ymm_k1z_m64bcst_imm8 = 4076,

        /// <summary>
        /// vpsllq ymm {k1}{z}, ymm, imm8 |  | 
        /// </summary>
        [Symbol("vpsllq ymm {k1}{z}, ymm, imm8","vpsllq ymm {k1}{z}, ymm, imm8 |  | ")]
        vpsllq_ymm_k1z_ymm_imm8 = 4077,

        /// <summary>
        /// vpsllq ymm {k1}{z}, ymm, m128 |  | 
        /// </summary>
        [Symbol("vpsllq ymm {k1}{z}, ymm, m128","vpsllq ymm {k1}{z}, ymm, m128 |  | ")]
        vpsllq_ymm_k1z_ymm_m128 = 4078,

        /// <summary>
        /// vpsllq ymm {k1}{z}, ymm, r8 |  | 
        /// </summary>
        [Symbol("vpsllq ymm {k1}{z}, ymm, r8","vpsllq ymm {k1}{z}, ymm, r8 |  | ")]
        vpsllq_ymm_k1z_ymm_r8 = 4079,

        /// <summary>
        /// vpsllq ymm, m256, imm8 |  | 
        /// </summary>
        [Symbol("vpsllq ymm, m256, imm8","vpsllq ymm, m256, imm8 |  | ")]
        vpsllq_ymm_m256_imm8 = 4080,

        /// <summary>
        /// vpsllq ymm, m64bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpsllq ymm, m64bcst, imm8","vpsllq ymm, m64bcst, imm8 |  | ")]
        vpsllq_ymm_m64bcst_imm8 = 4081,

        /// <summary>
        /// vpsllq ymm, ymm, imm8 |  | 
        /// </summary>
        [Symbol("vpsllq ymm, ymm, imm8","vpsllq ymm, ymm, imm8 |  | ")]
        vpsllq_ymm_ymm_imm8 = 4082,

        /// <summary>
        /// vpsllq ymm, ymm, m128 |  | 
        /// </summary>
        [Symbol("vpsllq ymm, ymm, m128","vpsllq ymm, ymm, m128 |  | ")]
        vpsllq_ymm_ymm_m128 = 4083,

        /// <summary>
        /// vpsllq ymm, ymm, r8 |  | 
        /// </summary>
        [Symbol("vpsllq ymm, ymm, r8","vpsllq ymm, ymm, r8 |  | ")]
        vpsllq_ymm_ymm_r8 = 4084,

        /// <summary>
        /// vpsllq zmm {k1}{z}, m512, imm8 |  | 
        /// </summary>
        [Symbol("vpsllq zmm {k1}{z}, m512, imm8","vpsllq zmm {k1}{z}, m512, imm8 |  | ")]
        vpsllq_zmm_k1z_m512_imm8 = 4085,

        /// <summary>
        /// vpsllq zmm {k1}{z}, m64bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpsllq zmm {k1}{z}, m64bcst, imm8","vpsllq zmm {k1}{z}, m64bcst, imm8 |  | ")]
        vpsllq_zmm_k1z_m64bcst_imm8 = 4086,

        /// <summary>
        /// vpsllq zmm {k1}{z}, zmm, imm8 |  | 
        /// </summary>
        [Symbol("vpsllq zmm {k1}{z}, zmm, imm8","vpsllq zmm {k1}{z}, zmm, imm8 |  | ")]
        vpsllq_zmm_k1z_zmm_imm8 = 4087,

        /// <summary>
        /// vpsllq zmm {k1}{z}, zmm, m128 |  | 
        /// </summary>
        [Symbol("vpsllq zmm {k1}{z}, zmm, m128","vpsllq zmm {k1}{z}, zmm, m128 |  | ")]
        vpsllq_zmm_k1z_zmm_m128 = 4088,

        /// <summary>
        /// vpsllq zmm {k1}{z}, zmm, r8 |  | 
        /// </summary>
        [Symbol("vpsllq zmm {k1}{z}, zmm, r8","vpsllq zmm {k1}{z}, zmm, r8 |  | ")]
        vpsllq_zmm_k1z_zmm_r8 = 4089,

        /// <summary>
        /// vpsllq zmm, m512, imm8 |  | 
        /// </summary>
        [Symbol("vpsllq zmm, m512, imm8","vpsllq zmm, m512, imm8 |  | ")]
        vpsllq_zmm_m512_imm8 = 4090,

        /// <summary>
        /// vpsllq zmm, m64bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpsllq zmm, m64bcst, imm8","vpsllq zmm, m64bcst, imm8 |  | ")]
        vpsllq_zmm_m64bcst_imm8 = 4091,

        /// <summary>
        /// vpsllq zmm, zmm, imm8 |  | 
        /// </summary>
        [Symbol("vpsllq zmm, zmm, imm8","vpsllq zmm, zmm, imm8 |  | ")]
        vpsllq_zmm_zmm_imm8 = 4092,

        /// <summary>
        /// vpsllq zmm, zmm, m128 |  | 
        /// </summary>
        [Symbol("vpsllq zmm, zmm, m128","vpsllq zmm, zmm, m128 |  | ")]
        vpsllq_zmm_zmm_m128 = 4093,

        /// <summary>
        /// vpsllq zmm, zmm, r8 |  | 
        /// </summary>
        [Symbol("vpsllq zmm, zmm, r8","vpsllq zmm, zmm, r8 |  | ")]
        vpsllq_zmm_zmm_r8 = 4094,

        /// <summary>
        /// vpsllvd xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpsllvd xmm {k1}{z}, xmm, m128","vpsllvd xmm {k1}{z}, xmm, m128 |  | ")]
        vpsllvd_xmm_k1z_xmm_m128 = 4095,

        /// <summary>
        /// vpsllvd xmm {k1}{z}, xmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpsllvd xmm {k1}{z}, xmm, m32bcst","vpsllvd xmm {k1}{z}, xmm, m32bcst |  | ")]
        vpsllvd_xmm_k1z_xmm_m32bcst = 4096,

        /// <summary>
        /// vpsllvd xmm {k1}{z}, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpsllvd xmm {k1}{z}, xmm, xmm","vpsllvd xmm {k1}{z}, xmm, xmm |  | ")]
        vpsllvd_xmm_k1z_xmm_xmm = 4097,

        /// <summary>
        /// vpsllvd xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpsllvd xmm, xmm, m128","vpsllvd xmm, xmm, m128 |  | ")]
        vpsllvd_xmm_xmm_m128 = 4098,

        /// <summary>
        /// vpsllvd xmm, xmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpsllvd xmm, xmm, m32bcst","vpsllvd xmm, xmm, m32bcst |  | ")]
        vpsllvd_xmm_xmm_m32bcst = 4099,

        /// <summary>
        /// vpsllvd xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpsllvd xmm, xmm, r8","vpsllvd xmm, xmm, r8 |  | ")]
        vpsllvd_xmm_xmm_r8 = 4100,

        /// <summary>
        /// vpsllvd xmm, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpsllvd xmm, xmm, xmm","vpsllvd xmm, xmm, xmm |  | ")]
        vpsllvd_xmm_xmm_xmm = 4101,

        /// <summary>
        /// vpsllvd ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpsllvd ymm {k1}{z}, ymm, m256","vpsllvd ymm {k1}{z}, ymm, m256 |  | ")]
        vpsllvd_ymm_k1z_ymm_m256 = 4102,

        /// <summary>
        /// vpsllvd ymm {k1}{z}, ymm, m32bcst |  | 
        /// </summary>
        [Symbol("vpsllvd ymm {k1}{z}, ymm, m32bcst","vpsllvd ymm {k1}{z}, ymm, m32bcst |  | ")]
        vpsllvd_ymm_k1z_ymm_m32bcst = 4103,

        /// <summary>
        /// vpsllvd ymm {k1}{z}, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpsllvd ymm {k1}{z}, ymm, ymm","vpsllvd ymm {k1}{z}, ymm, ymm |  | ")]
        vpsllvd_ymm_k1z_ymm_ymm = 4104,

        /// <summary>
        /// vpsllvd ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpsllvd ymm, ymm, m256","vpsllvd ymm, ymm, m256 |  | ")]
        vpsllvd_ymm_ymm_m256 = 4105,

        /// <summary>
        /// vpsllvd ymm, ymm, m32bcst |  | 
        /// </summary>
        [Symbol("vpsllvd ymm, ymm, m32bcst","vpsllvd ymm, ymm, m32bcst |  | ")]
        vpsllvd_ymm_ymm_m32bcst = 4106,

        /// <summary>
        /// vpsllvd ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpsllvd ymm, ymm, r16","vpsllvd ymm, ymm, r16 |  | ")]
        vpsllvd_ymm_ymm_r16 = 4107,

        /// <summary>
        /// vpsllvd ymm, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpsllvd ymm, ymm, ymm","vpsllvd ymm, ymm, ymm |  | ")]
        vpsllvd_ymm_ymm_ymm = 4108,

        /// <summary>
        /// vpsllvd zmm {k1}{z}, zmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpsllvd zmm {k1}{z}, zmm, m32bcst","vpsllvd zmm {k1}{z}, zmm, m32bcst |  | ")]
        vpsllvd_zmm_k1z_zmm_m32bcst = 4109,

        /// <summary>
        /// vpsllvd zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpsllvd zmm {k1}{z}, zmm, m512","vpsllvd zmm {k1}{z}, zmm, m512 |  | ")]
        vpsllvd_zmm_k1z_zmm_m512 = 4110,

        /// <summary>
        /// vpsllvd zmm {k1}{z}, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpsllvd zmm {k1}{z}, zmm, zmm","vpsllvd zmm {k1}{z}, zmm, zmm |  | ")]
        vpsllvd_zmm_k1z_zmm_zmm = 4111,

        /// <summary>
        /// vpsllvd zmm, zmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpsllvd zmm, zmm, m32bcst","vpsllvd zmm, zmm, m32bcst |  | ")]
        vpsllvd_zmm_zmm_m32bcst = 4112,

        /// <summary>
        /// vpsllvd zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpsllvd zmm, zmm, m512","vpsllvd zmm, zmm, m512 |  | ")]
        vpsllvd_zmm_zmm_m512 = 4113,

        /// <summary>
        /// vpsllvd zmm, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpsllvd zmm, zmm, zmm","vpsllvd zmm, zmm, zmm |  | ")]
        vpsllvd_zmm_zmm_zmm = 4114,

        /// <summary>
        /// vpsllvq xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpsllvq xmm {k1}{z}, xmm, m128","vpsllvq xmm {k1}{z}, xmm, m128 |  | ")]
        vpsllvq_xmm_k1z_xmm_m128 = 4115,

        /// <summary>
        /// vpsllvq xmm {k1}{z}, xmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpsllvq xmm {k1}{z}, xmm, m64bcst","vpsllvq xmm {k1}{z}, xmm, m64bcst |  | ")]
        vpsllvq_xmm_k1z_xmm_m64bcst = 4116,

        /// <summary>
        /// vpsllvq xmm {k1}{z}, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpsllvq xmm {k1}{z}, xmm, xmm","vpsllvq xmm {k1}{z}, xmm, xmm |  | ")]
        vpsllvq_xmm_k1z_xmm_xmm = 4117,

        /// <summary>
        /// vpsllvq xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpsllvq xmm, xmm, m128","vpsllvq xmm, xmm, m128 |  | ")]
        vpsllvq_xmm_xmm_m128 = 4118,

        /// <summary>
        /// vpsllvq xmm, xmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpsllvq xmm, xmm, m64bcst","vpsllvq xmm, xmm, m64bcst |  | ")]
        vpsllvq_xmm_xmm_m64bcst = 4119,

        /// <summary>
        /// vpsllvq xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpsllvq xmm, xmm, r8","vpsllvq xmm, xmm, r8 |  | ")]
        vpsllvq_xmm_xmm_r8 = 4120,

        /// <summary>
        /// vpsllvq xmm, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpsllvq xmm, xmm, xmm","vpsllvq xmm, xmm, xmm |  | ")]
        vpsllvq_xmm_xmm_xmm = 4121,

        /// <summary>
        /// vpsllvq ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpsllvq ymm {k1}{z}, ymm, m256","vpsllvq ymm {k1}{z}, ymm, m256 |  | ")]
        vpsllvq_ymm_k1z_ymm_m256 = 4122,

        /// <summary>
        /// vpsllvq ymm {k1}{z}, ymm, m64bcst |  | 
        /// </summary>
        [Symbol("vpsllvq ymm {k1}{z}, ymm, m64bcst","vpsllvq ymm {k1}{z}, ymm, m64bcst |  | ")]
        vpsllvq_ymm_k1z_ymm_m64bcst = 4123,

        /// <summary>
        /// vpsllvq ymm {k1}{z}, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpsllvq ymm {k1}{z}, ymm, ymm","vpsllvq ymm {k1}{z}, ymm, ymm |  | ")]
        vpsllvq_ymm_k1z_ymm_ymm = 4124,

        /// <summary>
        /// vpsllvq ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpsllvq ymm, ymm, m256","vpsllvq ymm, ymm, m256 |  | ")]
        vpsllvq_ymm_ymm_m256 = 4125,

        /// <summary>
        /// vpsllvq ymm, ymm, m64bcst |  | 
        /// </summary>
        [Symbol("vpsllvq ymm, ymm, m64bcst","vpsllvq ymm, ymm, m64bcst |  | ")]
        vpsllvq_ymm_ymm_m64bcst = 4126,

        /// <summary>
        /// vpsllvq ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpsllvq ymm, ymm, r16","vpsllvq ymm, ymm, r16 |  | ")]
        vpsllvq_ymm_ymm_r16 = 4127,

        /// <summary>
        /// vpsllvq ymm, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpsllvq ymm, ymm, ymm","vpsllvq ymm, ymm, ymm |  | ")]
        vpsllvq_ymm_ymm_ymm = 4128,

        /// <summary>
        /// vpsllvq zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpsllvq zmm {k1}{z}, zmm, m512","vpsllvq zmm {k1}{z}, zmm, m512 |  | ")]
        vpsllvq_zmm_k1z_zmm_m512 = 4129,

        /// <summary>
        /// vpsllvq zmm {k1}{z}, zmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpsllvq zmm {k1}{z}, zmm, m64bcst","vpsllvq zmm {k1}{z}, zmm, m64bcst |  | ")]
        vpsllvq_zmm_k1z_zmm_m64bcst = 4130,

        /// <summary>
        /// vpsllvq zmm {k1}{z}, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpsllvq zmm {k1}{z}, zmm, zmm","vpsllvq zmm {k1}{z}, zmm, zmm |  | ")]
        vpsllvq_zmm_k1z_zmm_zmm = 4131,

        /// <summary>
        /// vpsllvq zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpsllvq zmm, zmm, m512","vpsllvq zmm, zmm, m512 |  | ")]
        vpsllvq_zmm_zmm_m512 = 4132,

        /// <summary>
        /// vpsllvq zmm, zmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpsllvq zmm, zmm, m64bcst","vpsllvq zmm, zmm, m64bcst |  | ")]
        vpsllvq_zmm_zmm_m64bcst = 4133,

        /// <summary>
        /// vpsllvq zmm, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpsllvq zmm, zmm, zmm","vpsllvq zmm, zmm, zmm |  | ")]
        vpsllvq_zmm_zmm_zmm = 4134,

        /// <summary>
        /// vpsllvw xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpsllvw xmm {k1}{z}, xmm, m128","vpsllvw xmm {k1}{z}, xmm, m128 |  | ")]
        vpsllvw_xmm_k1z_xmm_m128 = 4135,

        /// <summary>
        /// vpsllvw xmm {k1}{z}, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpsllvw xmm {k1}{z}, xmm, r8","vpsllvw xmm {k1}{z}, xmm, r8 |  | ")]
        vpsllvw_xmm_k1z_xmm_r8 = 4136,

        /// <summary>
        /// vpsllvw xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpsllvw xmm, xmm, m128","vpsllvw xmm, xmm, m128 |  | ")]
        vpsllvw_xmm_xmm_m128 = 4137,

        /// <summary>
        /// vpsllvw xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpsllvw xmm, xmm, r8","vpsllvw xmm, xmm, r8 |  | ")]
        vpsllvw_xmm_xmm_r8 = 4138,

        /// <summary>
        /// vpsllvw ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpsllvw ymm {k1}{z}, ymm, m256","vpsllvw ymm {k1}{z}, ymm, m256 |  | ")]
        vpsllvw_ymm_k1z_ymm_m256 = 4139,

        /// <summary>
        /// vpsllvw ymm {k1}{z}, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpsllvw ymm {k1}{z}, ymm, r16","vpsllvw ymm {k1}{z}, ymm, r16 |  | ")]
        vpsllvw_ymm_k1z_ymm_r16 = 4140,

        /// <summary>
        /// vpsllvw ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpsllvw ymm, ymm, m256","vpsllvw ymm, ymm, m256 |  | ")]
        vpsllvw_ymm_ymm_m256 = 4141,

        /// <summary>
        /// vpsllvw ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpsllvw ymm, ymm, r16","vpsllvw ymm, ymm, r16 |  | ")]
        vpsllvw_ymm_ymm_r16 = 4142,

        /// <summary>
        /// vpsllvw zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpsllvw zmm {k1}{z}, zmm, m512","vpsllvw zmm {k1}{z}, zmm, m512 |  | ")]
        vpsllvw_zmm_k1z_zmm_m512 = 4143,

        /// <summary>
        /// vpsllvw zmm {k1}{z}, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpsllvw zmm {k1}{z}, zmm, r32","vpsllvw zmm {k1}{z}, zmm, r32 |  | ")]
        vpsllvw_zmm_k1z_zmm_r32 = 4144,

        /// <summary>
        /// vpsllvw zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpsllvw zmm, zmm, m512","vpsllvw zmm, zmm, m512 |  | ")]
        vpsllvw_zmm_zmm_m512 = 4145,

        /// <summary>
        /// vpsllvw zmm, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpsllvw zmm, zmm, r32","vpsllvw zmm, zmm, r32 |  | ")]
        vpsllvw_zmm_zmm_r32 = 4146,

        /// <summary>
        /// vpsllw xmm {k1}{z}, m128, imm8 |  | 
        /// </summary>
        [Symbol("vpsllw xmm {k1}{z}, m128, imm8","vpsllw xmm {k1}{z}, m128, imm8 |  | ")]
        vpsllw_xmm_k1z_m128_imm8 = 4147,

        /// <summary>
        /// vpsllw xmm {k1}{z}, r8, imm8 |  | 
        /// </summary>
        [Symbol("vpsllw xmm {k1}{z}, r8, imm8","vpsllw xmm {k1}{z}, r8, imm8 |  | ")]
        vpsllw_xmm_k1z_r8_imm8 = 4148,

        /// <summary>
        /// vpsllw xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpsllw xmm {k1}{z}, xmm, m128","vpsllw xmm {k1}{z}, xmm, m128 |  | ")]
        vpsllw_xmm_k1z_xmm_m128 = 4149,

        /// <summary>
        /// vpsllw xmm {k1}{z}, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpsllw xmm {k1}{z}, xmm, r8","vpsllw xmm {k1}{z}, xmm, r8 |  | ")]
        vpsllw_xmm_k1z_xmm_r8 = 4150,

        /// <summary>
        /// vpsllw xmm, m128, imm8 |  | 
        /// </summary>
        [Symbol("vpsllw xmm, m128, imm8","vpsllw xmm, m128, imm8 |  | ")]
        vpsllw_xmm_m128_imm8 = 4151,

        /// <summary>
        /// vpsllw xmm, r8, imm8 |  | 
        /// </summary>
        [Symbol("vpsllw xmm, r8, imm8","vpsllw xmm, r8, imm8 |  | ")]
        vpsllw_xmm_r8_imm8 = 4152,

        /// <summary>
        /// vpsllw xmm, xmm, imm8 |  | 
        /// </summary>
        [Symbol("vpsllw xmm, xmm, imm8","vpsllw xmm, xmm, imm8 |  | ")]
        vpsllw_xmm_xmm_imm8 = 4153,

        /// <summary>
        /// vpsllw xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpsllw xmm, xmm, m128","vpsllw xmm, xmm, m128 |  | ")]
        vpsllw_xmm_xmm_m128 = 4154,

        /// <summary>
        /// vpsllw xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpsllw xmm, xmm, r8","vpsllw xmm, xmm, r8 |  | ")]
        vpsllw_xmm_xmm_r8 = 4155,

        /// <summary>
        /// vpsllw ymm {k1}{z}, m256, imm8 |  | 
        /// </summary>
        [Symbol("vpsllw ymm {k1}{z}, m256, imm8","vpsllw ymm {k1}{z}, m256, imm8 |  | ")]
        vpsllw_ymm_k1z_m256_imm8 = 4156,

        /// <summary>
        /// vpsllw ymm {k1}{z}, r16, imm8 |  | 
        /// </summary>
        [Symbol("vpsllw ymm {k1}{z}, r16, imm8","vpsllw ymm {k1}{z}, r16, imm8 |  | ")]
        vpsllw_ymm_k1z_r16_imm8 = 4157,

        /// <summary>
        /// vpsllw ymm {k1}{z}, ymm, m128 |  | 
        /// </summary>
        [Symbol("vpsllw ymm {k1}{z}, ymm, m128","vpsllw ymm {k1}{z}, ymm, m128 |  | ")]
        vpsllw_ymm_k1z_ymm_m128 = 4158,

        /// <summary>
        /// vpsllw ymm {k1}{z}, ymm, r8 |  | 
        /// </summary>
        [Symbol("vpsllw ymm {k1}{z}, ymm, r8","vpsllw ymm {k1}{z}, ymm, r8 |  | ")]
        vpsllw_ymm_k1z_ymm_r8 = 4159,

        /// <summary>
        /// vpsllw ymm, m256, imm8 |  | 
        /// </summary>
        [Symbol("vpsllw ymm, m256, imm8","vpsllw ymm, m256, imm8 |  | ")]
        vpsllw_ymm_m256_imm8 = 4160,

        /// <summary>
        /// vpsllw ymm, r16, imm8 |  | 
        /// </summary>
        [Symbol("vpsllw ymm, r16, imm8","vpsllw ymm, r16, imm8 |  | ")]
        vpsllw_ymm_r16_imm8 = 4161,

        /// <summary>
        /// vpsllw ymm, ymm, imm8 |  | 
        /// </summary>
        [Symbol("vpsllw ymm, ymm, imm8","vpsllw ymm, ymm, imm8 |  | ")]
        vpsllw_ymm_ymm_imm8 = 4162,

        /// <summary>
        /// vpsllw ymm, ymm, m128 |  | 
        /// </summary>
        [Symbol("vpsllw ymm, ymm, m128","vpsllw ymm, ymm, m128 |  | ")]
        vpsllw_ymm_ymm_m128 = 4163,

        /// <summary>
        /// vpsllw ymm, ymm, r8 |  | 
        /// </summary>
        [Symbol("vpsllw ymm, ymm, r8","vpsllw ymm, ymm, r8 |  | ")]
        vpsllw_ymm_ymm_r8 = 4164,

        /// <summary>
        /// vpsllw zmm {k1}{z}, m512, imm8 |  | 
        /// </summary>
        [Symbol("vpsllw zmm {k1}{z}, m512, imm8","vpsllw zmm {k1}{z}, m512, imm8 |  | ")]
        vpsllw_zmm_k1z_m512_imm8 = 4165,

        /// <summary>
        /// vpsllw zmm {k1}{z}, r32, imm8 |  | 
        /// </summary>
        [Symbol("vpsllw zmm {k1}{z}, r32, imm8","vpsllw zmm {k1}{z}, r32, imm8 |  | ")]
        vpsllw_zmm_k1z_r32_imm8 = 4166,

        /// <summary>
        /// vpsllw zmm {k1}{z}, zmm, m128 |  | 
        /// </summary>
        [Symbol("vpsllw zmm {k1}{z}, zmm, m128","vpsllw zmm {k1}{z}, zmm, m128 |  | ")]
        vpsllw_zmm_k1z_zmm_m128 = 4167,

        /// <summary>
        /// vpsllw zmm {k1}{z}, zmm, r8 |  | 
        /// </summary>
        [Symbol("vpsllw zmm {k1}{z}, zmm, r8","vpsllw zmm {k1}{z}, zmm, r8 |  | ")]
        vpsllw_zmm_k1z_zmm_r8 = 4168,

        /// <summary>
        /// vpsllw zmm, m512, imm8 |  | 
        /// </summary>
        [Symbol("vpsllw zmm, m512, imm8","vpsllw zmm, m512, imm8 |  | ")]
        vpsllw_zmm_m512_imm8 = 4169,

        /// <summary>
        /// vpsllw zmm, r32, imm8 |  | 
        /// </summary>
        [Symbol("vpsllw zmm, r32, imm8","vpsllw zmm, r32, imm8 |  | ")]
        vpsllw_zmm_r32_imm8 = 4170,

        /// <summary>
        /// vpsllw zmm, zmm, m128 |  | 
        /// </summary>
        [Symbol("vpsllw zmm, zmm, m128","vpsllw zmm, zmm, m128 |  | ")]
        vpsllw_zmm_zmm_m128 = 4171,

        /// <summary>
        /// vpsllw zmm, zmm, r8 |  | 
        /// </summary>
        [Symbol("vpsllw zmm, zmm, r8","vpsllw zmm, zmm, r8 |  | ")]
        vpsllw_zmm_zmm_r8 = 4172,

        /// <summary>
        /// vpsrad xmm {k1}{z}, m128, imm8 |  | 
        /// </summary>
        [Symbol("vpsrad xmm {k1}{z}, m128, imm8","vpsrad xmm {k1}{z}, m128, imm8 |  | ")]
        vpsrad_xmm_k1z_m128_imm8 = 4173,

        /// <summary>
        /// vpsrad xmm {k1}{z}, m32bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpsrad xmm {k1}{z}, m32bcst, imm8","vpsrad xmm {k1}{z}, m32bcst, imm8 |  | ")]
        vpsrad_xmm_k1z_m32bcst_imm8 = 4174,

        /// <summary>
        /// vpsrad xmm {k1}{z}, xmm, imm8 |  | 
        /// </summary>
        [Symbol("vpsrad xmm {k1}{z}, xmm, imm8","vpsrad xmm {k1}{z}, xmm, imm8 |  | ")]
        vpsrad_xmm_k1z_xmm_imm8 = 4175,

        /// <summary>
        /// vpsrad xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpsrad xmm {k1}{z}, xmm, m128","vpsrad xmm {k1}{z}, xmm, m128 |  | ")]
        vpsrad_xmm_k1z_xmm_m128 = 4176,

        /// <summary>
        /// vpsrad xmm {k1}{z}, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpsrad xmm {k1}{z}, xmm, r8","vpsrad xmm {k1}{z}, xmm, r8 |  | ")]
        vpsrad_xmm_k1z_xmm_r8 = 4177,

        /// <summary>
        /// vpsrad xmm, m128, imm8 |  | 
        /// </summary>
        [Symbol("vpsrad xmm, m128, imm8","vpsrad xmm, m128, imm8 |  | ")]
        vpsrad_xmm_m128_imm8 = 4178,

        /// <summary>
        /// vpsrad xmm, m32bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpsrad xmm, m32bcst, imm8","vpsrad xmm, m32bcst, imm8 |  | ")]
        vpsrad_xmm_m32bcst_imm8 = 4179,

        /// <summary>
        /// vpsrad xmm, xmm, imm8 |  | 
        /// </summary>
        [Symbol("vpsrad xmm, xmm, imm8","vpsrad xmm, xmm, imm8 |  | ")]
        vpsrad_xmm_xmm_imm8 = 4180,

        /// <summary>
        /// vpsrad xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpsrad xmm, xmm, m128","vpsrad xmm, xmm, m128 |  | ")]
        vpsrad_xmm_xmm_m128 = 4181,

        /// <summary>
        /// vpsrad xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpsrad xmm, xmm, r8","vpsrad xmm, xmm, r8 |  | ")]
        vpsrad_xmm_xmm_r8 = 4182,

        /// <summary>
        /// vpsrad ymm {k1}{z}, m256, imm8 |  | 
        /// </summary>
        [Symbol("vpsrad ymm {k1}{z}, m256, imm8","vpsrad ymm {k1}{z}, m256, imm8 |  | ")]
        vpsrad_ymm_k1z_m256_imm8 = 4183,

        /// <summary>
        /// vpsrad ymm {k1}{z}, m32bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpsrad ymm {k1}{z}, m32bcst, imm8","vpsrad ymm {k1}{z}, m32bcst, imm8 |  | ")]
        vpsrad_ymm_k1z_m32bcst_imm8 = 4184,

        /// <summary>
        /// vpsrad ymm {k1}{z}, ymm, imm8 |  | 
        /// </summary>
        [Symbol("vpsrad ymm {k1}{z}, ymm, imm8","vpsrad ymm {k1}{z}, ymm, imm8 |  | ")]
        vpsrad_ymm_k1z_ymm_imm8 = 4185,

        /// <summary>
        /// vpsrad ymm {k1}{z}, ymm, m128 |  | 
        /// </summary>
        [Symbol("vpsrad ymm {k1}{z}, ymm, m128","vpsrad ymm {k1}{z}, ymm, m128 |  | ")]
        vpsrad_ymm_k1z_ymm_m128 = 4186,

        /// <summary>
        /// vpsrad ymm {k1}{z}, ymm, r8 |  | 
        /// </summary>
        [Symbol("vpsrad ymm {k1}{z}, ymm, r8","vpsrad ymm {k1}{z}, ymm, r8 |  | ")]
        vpsrad_ymm_k1z_ymm_r8 = 4187,

        /// <summary>
        /// vpsrad ymm, m256, imm8 |  | 
        /// </summary>
        [Symbol("vpsrad ymm, m256, imm8","vpsrad ymm, m256, imm8 |  | ")]
        vpsrad_ymm_m256_imm8 = 4188,

        /// <summary>
        /// vpsrad ymm, m32bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpsrad ymm, m32bcst, imm8","vpsrad ymm, m32bcst, imm8 |  | ")]
        vpsrad_ymm_m32bcst_imm8 = 4189,

        /// <summary>
        /// vpsrad ymm, ymm, imm8 |  | 
        /// </summary>
        [Symbol("vpsrad ymm, ymm, imm8","vpsrad ymm, ymm, imm8 |  | ")]
        vpsrad_ymm_ymm_imm8 = 4190,

        /// <summary>
        /// vpsrad ymm, ymm, m128 |  | 
        /// </summary>
        [Symbol("vpsrad ymm, ymm, m128","vpsrad ymm, ymm, m128 |  | ")]
        vpsrad_ymm_ymm_m128 = 4191,

        /// <summary>
        /// vpsrad ymm, ymm, r8 |  | 
        /// </summary>
        [Symbol("vpsrad ymm, ymm, r8","vpsrad ymm, ymm, r8 |  | ")]
        vpsrad_ymm_ymm_r8 = 4192,

        /// <summary>
        /// vpsrad zmm {k1}{z}, m32bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpsrad zmm {k1}{z}, m32bcst, imm8","vpsrad zmm {k1}{z}, m32bcst, imm8 |  | ")]
        vpsrad_zmm_k1z_m32bcst_imm8 = 4193,

        /// <summary>
        /// vpsrad zmm {k1}{z}, m512, imm8 |  | 
        /// </summary>
        [Symbol("vpsrad zmm {k1}{z}, m512, imm8","vpsrad zmm {k1}{z}, m512, imm8 |  | ")]
        vpsrad_zmm_k1z_m512_imm8 = 4194,

        /// <summary>
        /// vpsrad zmm {k1}{z}, zmm, imm8 |  | 
        /// </summary>
        [Symbol("vpsrad zmm {k1}{z}, zmm, imm8","vpsrad zmm {k1}{z}, zmm, imm8 |  | ")]
        vpsrad_zmm_k1z_zmm_imm8 = 4195,

        /// <summary>
        /// vpsrad zmm {k1}{z}, zmm, m128 |  | 
        /// </summary>
        [Symbol("vpsrad zmm {k1}{z}, zmm, m128","vpsrad zmm {k1}{z}, zmm, m128 |  | ")]
        vpsrad_zmm_k1z_zmm_m128 = 4196,

        /// <summary>
        /// vpsrad zmm {k1}{z}, zmm, r8 |  | 
        /// </summary>
        [Symbol("vpsrad zmm {k1}{z}, zmm, r8","vpsrad zmm {k1}{z}, zmm, r8 |  | ")]
        vpsrad_zmm_k1z_zmm_r8 = 4197,

        /// <summary>
        /// vpsrad zmm, m32bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpsrad zmm, m32bcst, imm8","vpsrad zmm, m32bcst, imm8 |  | ")]
        vpsrad_zmm_m32bcst_imm8 = 4198,

        /// <summary>
        /// vpsrad zmm, m512, imm8 |  | 
        /// </summary>
        [Symbol("vpsrad zmm, m512, imm8","vpsrad zmm, m512, imm8 |  | ")]
        vpsrad_zmm_m512_imm8 = 4199,

        /// <summary>
        /// vpsrad zmm, zmm, imm8 |  | 
        /// </summary>
        [Symbol("vpsrad zmm, zmm, imm8","vpsrad zmm, zmm, imm8 |  | ")]
        vpsrad_zmm_zmm_imm8 = 4200,

        /// <summary>
        /// vpsrad zmm, zmm, m128 |  | 
        /// </summary>
        [Symbol("vpsrad zmm, zmm, m128","vpsrad zmm, zmm, m128 |  | ")]
        vpsrad_zmm_zmm_m128 = 4201,

        /// <summary>
        /// vpsrad zmm, zmm, r8 |  | 
        /// </summary>
        [Symbol("vpsrad zmm, zmm, r8","vpsrad zmm, zmm, r8 |  | ")]
        vpsrad_zmm_zmm_r8 = 4202,

        /// <summary>
        /// vpsraq xmm {k1}{z}, m128, imm8 |  | 
        /// </summary>
        [Symbol("vpsraq xmm {k1}{z}, m128, imm8","vpsraq xmm {k1}{z}, m128, imm8 |  | ")]
        vpsraq_xmm_k1z_m128_imm8 = 4203,

        /// <summary>
        /// vpsraq xmm {k1}{z}, m64bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpsraq xmm {k1}{z}, m64bcst, imm8","vpsraq xmm {k1}{z}, m64bcst, imm8 |  | ")]
        vpsraq_xmm_k1z_m64bcst_imm8 = 4204,

        /// <summary>
        /// vpsraq xmm {k1}{z}, xmm, imm8 |  | 
        /// </summary>
        [Symbol("vpsraq xmm {k1}{z}, xmm, imm8","vpsraq xmm {k1}{z}, xmm, imm8 |  | ")]
        vpsraq_xmm_k1z_xmm_imm8 = 4205,

        /// <summary>
        /// vpsraq xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpsraq xmm {k1}{z}, xmm, m128","vpsraq xmm {k1}{z}, xmm, m128 |  | ")]
        vpsraq_xmm_k1z_xmm_m128 = 4206,

        /// <summary>
        /// vpsraq xmm {k1}{z}, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpsraq xmm {k1}{z}, xmm, r8","vpsraq xmm {k1}{z}, xmm, r8 |  | ")]
        vpsraq_xmm_k1z_xmm_r8 = 4207,

        /// <summary>
        /// vpsraq xmm, m128, imm8 |  | 
        /// </summary>
        [Symbol("vpsraq xmm, m128, imm8","vpsraq xmm, m128, imm8 |  | ")]
        vpsraq_xmm_m128_imm8 = 4208,

        /// <summary>
        /// vpsraq xmm, m64bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpsraq xmm, m64bcst, imm8","vpsraq xmm, m64bcst, imm8 |  | ")]
        vpsraq_xmm_m64bcst_imm8 = 4209,

        /// <summary>
        /// vpsraq xmm, xmm, imm8 |  | 
        /// </summary>
        [Symbol("vpsraq xmm, xmm, imm8","vpsraq xmm, xmm, imm8 |  | ")]
        vpsraq_xmm_xmm_imm8 = 4210,

        /// <summary>
        /// vpsraq xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpsraq xmm, xmm, m128","vpsraq xmm, xmm, m128 |  | ")]
        vpsraq_xmm_xmm_m128 = 4211,

        /// <summary>
        /// vpsraq xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpsraq xmm, xmm, r8","vpsraq xmm, xmm, r8 |  | ")]
        vpsraq_xmm_xmm_r8 = 4212,

        /// <summary>
        /// vpsraq ymm {k1}{z}, m256, imm8 |  | 
        /// </summary>
        [Symbol("vpsraq ymm {k1}{z}, m256, imm8","vpsraq ymm {k1}{z}, m256, imm8 |  | ")]
        vpsraq_ymm_k1z_m256_imm8 = 4213,

        /// <summary>
        /// vpsraq ymm {k1}{z}, m64bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpsraq ymm {k1}{z}, m64bcst, imm8","vpsraq ymm {k1}{z}, m64bcst, imm8 |  | ")]
        vpsraq_ymm_k1z_m64bcst_imm8 = 4214,

        /// <summary>
        /// vpsraq ymm {k1}{z}, ymm, imm8 |  | 
        /// </summary>
        [Symbol("vpsraq ymm {k1}{z}, ymm, imm8","vpsraq ymm {k1}{z}, ymm, imm8 |  | ")]
        vpsraq_ymm_k1z_ymm_imm8 = 4215,

        /// <summary>
        /// vpsraq ymm {k1}{z}, ymm, m128 |  | 
        /// </summary>
        [Symbol("vpsraq ymm {k1}{z}, ymm, m128","vpsraq ymm {k1}{z}, ymm, m128 |  | ")]
        vpsraq_ymm_k1z_ymm_m128 = 4216,

        /// <summary>
        /// vpsraq ymm {k1}{z}, ymm, r8 |  | 
        /// </summary>
        [Symbol("vpsraq ymm {k1}{z}, ymm, r8","vpsraq ymm {k1}{z}, ymm, r8 |  | ")]
        vpsraq_ymm_k1z_ymm_r8 = 4217,

        /// <summary>
        /// vpsraq ymm, m256, imm8 |  | 
        /// </summary>
        [Symbol("vpsraq ymm, m256, imm8","vpsraq ymm, m256, imm8 |  | ")]
        vpsraq_ymm_m256_imm8 = 4218,

        /// <summary>
        /// vpsraq ymm, m64bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpsraq ymm, m64bcst, imm8","vpsraq ymm, m64bcst, imm8 |  | ")]
        vpsraq_ymm_m64bcst_imm8 = 4219,

        /// <summary>
        /// vpsraq ymm, ymm, imm8 |  | 
        /// </summary>
        [Symbol("vpsraq ymm, ymm, imm8","vpsraq ymm, ymm, imm8 |  | ")]
        vpsraq_ymm_ymm_imm8 = 4220,

        /// <summary>
        /// vpsraq ymm, ymm, m128 |  | 
        /// </summary>
        [Symbol("vpsraq ymm, ymm, m128","vpsraq ymm, ymm, m128 |  | ")]
        vpsraq_ymm_ymm_m128 = 4221,

        /// <summary>
        /// vpsraq ymm, ymm, r8 |  | 
        /// </summary>
        [Symbol("vpsraq ymm, ymm, r8","vpsraq ymm, ymm, r8 |  | ")]
        vpsraq_ymm_ymm_r8 = 4222,

        /// <summary>
        /// vpsraq zmm {k1}{z}, m512, imm8 |  | 
        /// </summary>
        [Symbol("vpsraq zmm {k1}{z}, m512, imm8","vpsraq zmm {k1}{z}, m512, imm8 |  | ")]
        vpsraq_zmm_k1z_m512_imm8 = 4223,

        /// <summary>
        /// vpsraq zmm {k1}{z}, m64bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpsraq zmm {k1}{z}, m64bcst, imm8","vpsraq zmm {k1}{z}, m64bcst, imm8 |  | ")]
        vpsraq_zmm_k1z_m64bcst_imm8 = 4224,

        /// <summary>
        /// vpsraq zmm {k1}{z}, zmm, imm8 |  | 
        /// </summary>
        [Symbol("vpsraq zmm {k1}{z}, zmm, imm8","vpsraq zmm {k1}{z}, zmm, imm8 |  | ")]
        vpsraq_zmm_k1z_zmm_imm8 = 4225,

        /// <summary>
        /// vpsraq zmm {k1}{z}, zmm, m128 |  | 
        /// </summary>
        [Symbol("vpsraq zmm {k1}{z}, zmm, m128","vpsraq zmm {k1}{z}, zmm, m128 |  | ")]
        vpsraq_zmm_k1z_zmm_m128 = 4226,

        /// <summary>
        /// vpsraq zmm {k1}{z}, zmm, r8 |  | 
        /// </summary>
        [Symbol("vpsraq zmm {k1}{z}, zmm, r8","vpsraq zmm {k1}{z}, zmm, r8 |  | ")]
        vpsraq_zmm_k1z_zmm_r8 = 4227,

        /// <summary>
        /// vpsraq zmm, m512, imm8 |  | 
        /// </summary>
        [Symbol("vpsraq zmm, m512, imm8","vpsraq zmm, m512, imm8 |  | ")]
        vpsraq_zmm_m512_imm8 = 4228,

        /// <summary>
        /// vpsraq zmm, m64bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpsraq zmm, m64bcst, imm8","vpsraq zmm, m64bcst, imm8 |  | ")]
        vpsraq_zmm_m64bcst_imm8 = 4229,

        /// <summary>
        /// vpsraq zmm, zmm, imm8 |  | 
        /// </summary>
        [Symbol("vpsraq zmm, zmm, imm8","vpsraq zmm, zmm, imm8 |  | ")]
        vpsraq_zmm_zmm_imm8 = 4230,

        /// <summary>
        /// vpsraq zmm, zmm, m128 |  | 
        /// </summary>
        [Symbol("vpsraq zmm, zmm, m128","vpsraq zmm, zmm, m128 |  | ")]
        vpsraq_zmm_zmm_m128 = 4231,

        /// <summary>
        /// vpsraq zmm, zmm, r8 |  | 
        /// </summary>
        [Symbol("vpsraq zmm, zmm, r8","vpsraq zmm, zmm, r8 |  | ")]
        vpsraq_zmm_zmm_r8 = 4232,

        /// <summary>
        /// vpsravd xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpsravd xmm {k1}{z}, xmm, m128","vpsravd xmm {k1}{z}, xmm, m128 |  | ")]
        vpsravd_xmm_k1z_xmm_m128 = 4233,

        /// <summary>
        /// vpsravd xmm {k1}{z}, xmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpsravd xmm {k1}{z}, xmm, m32bcst","vpsravd xmm {k1}{z}, xmm, m32bcst |  | ")]
        vpsravd_xmm_k1z_xmm_m32bcst = 4234,

        /// <summary>
        /// vpsravd xmm {k1}{z}, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpsravd xmm {k1}{z}, xmm, xmm","vpsravd xmm {k1}{z}, xmm, xmm |  | ")]
        vpsravd_xmm_k1z_xmm_xmm = 4235,

        /// <summary>
        /// vpsravd xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpsravd xmm, xmm, m128","vpsravd xmm, xmm, m128 |  | ")]
        vpsravd_xmm_xmm_m128 = 4236,

        /// <summary>
        /// vpsravd xmm, xmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpsravd xmm, xmm, m32bcst","vpsravd xmm, xmm, m32bcst |  | ")]
        vpsravd_xmm_xmm_m32bcst = 4237,

        /// <summary>
        /// vpsravd xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpsravd xmm, xmm, r8","vpsravd xmm, xmm, r8 |  | ")]
        vpsravd_xmm_xmm_r8 = 4238,

        /// <summary>
        /// vpsravd xmm, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpsravd xmm, xmm, xmm","vpsravd xmm, xmm, xmm |  | ")]
        vpsravd_xmm_xmm_xmm = 4239,

        /// <summary>
        /// vpsravd ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpsravd ymm {k1}{z}, ymm, m256","vpsravd ymm {k1}{z}, ymm, m256 |  | ")]
        vpsravd_ymm_k1z_ymm_m256 = 4240,

        /// <summary>
        /// vpsravd ymm {k1}{z}, ymm, m32bcst |  | 
        /// </summary>
        [Symbol("vpsravd ymm {k1}{z}, ymm, m32bcst","vpsravd ymm {k1}{z}, ymm, m32bcst |  | ")]
        vpsravd_ymm_k1z_ymm_m32bcst = 4241,

        /// <summary>
        /// vpsravd ymm {k1}{z}, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpsravd ymm {k1}{z}, ymm, ymm","vpsravd ymm {k1}{z}, ymm, ymm |  | ")]
        vpsravd_ymm_k1z_ymm_ymm = 4242,

        /// <summary>
        /// vpsravd ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpsravd ymm, ymm, m256","vpsravd ymm, ymm, m256 |  | ")]
        vpsravd_ymm_ymm_m256 = 4243,

        /// <summary>
        /// vpsravd ymm, ymm, m32bcst |  | 
        /// </summary>
        [Symbol("vpsravd ymm, ymm, m32bcst","vpsravd ymm, ymm, m32bcst |  | ")]
        vpsravd_ymm_ymm_m32bcst = 4244,

        /// <summary>
        /// vpsravd ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpsravd ymm, ymm, r16","vpsravd ymm, ymm, r16 |  | ")]
        vpsravd_ymm_ymm_r16 = 4245,

        /// <summary>
        /// vpsravd ymm, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpsravd ymm, ymm, ymm","vpsravd ymm, ymm, ymm |  | ")]
        vpsravd_ymm_ymm_ymm = 4246,

        /// <summary>
        /// vpsravd zmm {k1}{z}, zmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpsravd zmm {k1}{z}, zmm, m32bcst","vpsravd zmm {k1}{z}, zmm, m32bcst |  | ")]
        vpsravd_zmm_k1z_zmm_m32bcst = 4247,

        /// <summary>
        /// vpsravd zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpsravd zmm {k1}{z}, zmm, m512","vpsravd zmm {k1}{z}, zmm, m512 |  | ")]
        vpsravd_zmm_k1z_zmm_m512 = 4248,

        /// <summary>
        /// vpsravd zmm {k1}{z}, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpsravd zmm {k1}{z}, zmm, zmm","vpsravd zmm {k1}{z}, zmm, zmm |  | ")]
        vpsravd_zmm_k1z_zmm_zmm = 4249,

        /// <summary>
        /// vpsravd zmm, zmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpsravd zmm, zmm, m32bcst","vpsravd zmm, zmm, m32bcst |  | ")]
        vpsravd_zmm_zmm_m32bcst = 4250,

        /// <summary>
        /// vpsravd zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpsravd zmm, zmm, m512","vpsravd zmm, zmm, m512 |  | ")]
        vpsravd_zmm_zmm_m512 = 4251,

        /// <summary>
        /// vpsravd zmm, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpsravd zmm, zmm, zmm","vpsravd zmm, zmm, zmm |  | ")]
        vpsravd_zmm_zmm_zmm = 4252,

        /// <summary>
        /// vpsravq xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpsravq xmm {k1}{z}, xmm, m128","vpsravq xmm {k1}{z}, xmm, m128 |  | ")]
        vpsravq_xmm_k1z_xmm_m128 = 4253,

        /// <summary>
        /// vpsravq xmm {k1}{z}, xmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpsravq xmm {k1}{z}, xmm, m64bcst","vpsravq xmm {k1}{z}, xmm, m64bcst |  | ")]
        vpsravq_xmm_k1z_xmm_m64bcst = 4254,

        /// <summary>
        /// vpsravq xmm {k1}{z}, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpsravq xmm {k1}{z}, xmm, xmm","vpsravq xmm {k1}{z}, xmm, xmm |  | ")]
        vpsravq_xmm_k1z_xmm_xmm = 4255,

        /// <summary>
        /// vpsravq xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpsravq xmm, xmm, m128","vpsravq xmm, xmm, m128 |  | ")]
        vpsravq_xmm_xmm_m128 = 4256,

        /// <summary>
        /// vpsravq xmm, xmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpsravq xmm, xmm, m64bcst","vpsravq xmm, xmm, m64bcst |  | ")]
        vpsravq_xmm_xmm_m64bcst = 4257,

        /// <summary>
        /// vpsravq xmm, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpsravq xmm, xmm, xmm","vpsravq xmm, xmm, xmm |  | ")]
        vpsravq_xmm_xmm_xmm = 4258,

        /// <summary>
        /// vpsravq ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpsravq ymm {k1}{z}, ymm, m256","vpsravq ymm {k1}{z}, ymm, m256 |  | ")]
        vpsravq_ymm_k1z_ymm_m256 = 4259,

        /// <summary>
        /// vpsravq ymm {k1}{z}, ymm, m64bcst |  | 
        /// </summary>
        [Symbol("vpsravq ymm {k1}{z}, ymm, m64bcst","vpsravq ymm {k1}{z}, ymm, m64bcst |  | ")]
        vpsravq_ymm_k1z_ymm_m64bcst = 4260,

        /// <summary>
        /// vpsravq ymm {k1}{z}, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpsravq ymm {k1}{z}, ymm, ymm","vpsravq ymm {k1}{z}, ymm, ymm |  | ")]
        vpsravq_ymm_k1z_ymm_ymm = 4261,

        /// <summary>
        /// vpsravq ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpsravq ymm, ymm, m256","vpsravq ymm, ymm, m256 |  | ")]
        vpsravq_ymm_ymm_m256 = 4262,

        /// <summary>
        /// vpsravq ymm, ymm, m64bcst |  | 
        /// </summary>
        [Symbol("vpsravq ymm, ymm, m64bcst","vpsravq ymm, ymm, m64bcst |  | ")]
        vpsravq_ymm_ymm_m64bcst = 4263,

        /// <summary>
        /// vpsravq ymm, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpsravq ymm, ymm, ymm","vpsravq ymm, ymm, ymm |  | ")]
        vpsravq_ymm_ymm_ymm = 4264,

        /// <summary>
        /// vpsravq zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpsravq zmm {k1}{z}, zmm, m512","vpsravq zmm {k1}{z}, zmm, m512 |  | ")]
        vpsravq_zmm_k1z_zmm_m512 = 4265,

        /// <summary>
        /// vpsravq zmm {k1}{z}, zmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpsravq zmm {k1}{z}, zmm, m64bcst","vpsravq zmm {k1}{z}, zmm, m64bcst |  | ")]
        vpsravq_zmm_k1z_zmm_m64bcst = 4266,

        /// <summary>
        /// vpsravq zmm {k1}{z}, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpsravq zmm {k1}{z}, zmm, zmm","vpsravq zmm {k1}{z}, zmm, zmm |  | ")]
        vpsravq_zmm_k1z_zmm_zmm = 4267,

        /// <summary>
        /// vpsravq zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpsravq zmm, zmm, m512","vpsravq zmm, zmm, m512 |  | ")]
        vpsravq_zmm_zmm_m512 = 4268,

        /// <summary>
        /// vpsravq zmm, zmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpsravq zmm, zmm, m64bcst","vpsravq zmm, zmm, m64bcst |  | ")]
        vpsravq_zmm_zmm_m64bcst = 4269,

        /// <summary>
        /// vpsravq zmm, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpsravq zmm, zmm, zmm","vpsravq zmm, zmm, zmm |  | ")]
        vpsravq_zmm_zmm_zmm = 4270,

        /// <summary>
        /// vpsravw xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpsravw xmm {k1}{z}, xmm, m128","vpsravw xmm {k1}{z}, xmm, m128 |  | ")]
        vpsravw_xmm_k1z_xmm_m128 = 4271,

        /// <summary>
        /// vpsravw xmm {k1}{z}, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpsravw xmm {k1}{z}, xmm, r8","vpsravw xmm {k1}{z}, xmm, r8 |  | ")]
        vpsravw_xmm_k1z_xmm_r8 = 4272,

        /// <summary>
        /// vpsravw xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpsravw xmm, xmm, m128","vpsravw xmm, xmm, m128 |  | ")]
        vpsravw_xmm_xmm_m128 = 4273,

        /// <summary>
        /// vpsravw xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpsravw xmm, xmm, r8","vpsravw xmm, xmm, r8 |  | ")]
        vpsravw_xmm_xmm_r8 = 4274,

        /// <summary>
        /// vpsravw ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpsravw ymm {k1}{z}, ymm, m256","vpsravw ymm {k1}{z}, ymm, m256 |  | ")]
        vpsravw_ymm_k1z_ymm_m256 = 4275,

        /// <summary>
        /// vpsravw ymm {k1}{z}, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpsravw ymm {k1}{z}, ymm, r16","vpsravw ymm {k1}{z}, ymm, r16 |  | ")]
        vpsravw_ymm_k1z_ymm_r16 = 4276,

        /// <summary>
        /// vpsravw ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpsravw ymm, ymm, m256","vpsravw ymm, ymm, m256 |  | ")]
        vpsravw_ymm_ymm_m256 = 4277,

        /// <summary>
        /// vpsravw ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpsravw ymm, ymm, r16","vpsravw ymm, ymm, r16 |  | ")]
        vpsravw_ymm_ymm_r16 = 4278,

        /// <summary>
        /// vpsravw zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpsravw zmm {k1}{z}, zmm, m512","vpsravw zmm {k1}{z}, zmm, m512 |  | ")]
        vpsravw_zmm_k1z_zmm_m512 = 4279,

        /// <summary>
        /// vpsravw zmm {k1}{z}, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpsravw zmm {k1}{z}, zmm, r32","vpsravw zmm {k1}{z}, zmm, r32 |  | ")]
        vpsravw_zmm_k1z_zmm_r32 = 4280,

        /// <summary>
        /// vpsravw zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpsravw zmm, zmm, m512","vpsravw zmm, zmm, m512 |  | ")]
        vpsravw_zmm_zmm_m512 = 4281,

        /// <summary>
        /// vpsravw zmm, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpsravw zmm, zmm, r32","vpsravw zmm, zmm, r32 |  | ")]
        vpsravw_zmm_zmm_r32 = 4282,

        /// <summary>
        /// vpsraw xmm {k1}{z}, m128, imm8 |  | 
        /// </summary>
        [Symbol("vpsraw xmm {k1}{z}, m128, imm8","vpsraw xmm {k1}{z}, m128, imm8 |  | ")]
        vpsraw_xmm_k1z_m128_imm8 = 4283,

        /// <summary>
        /// vpsraw xmm {k1}{z}, r8, imm8 |  | 
        /// </summary>
        [Symbol("vpsraw xmm {k1}{z}, r8, imm8","vpsraw xmm {k1}{z}, r8, imm8 |  | ")]
        vpsraw_xmm_k1z_r8_imm8 = 4284,

        /// <summary>
        /// vpsraw xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpsraw xmm {k1}{z}, xmm, m128","vpsraw xmm {k1}{z}, xmm, m128 |  | ")]
        vpsraw_xmm_k1z_xmm_m128 = 4285,

        /// <summary>
        /// vpsraw xmm {k1}{z}, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpsraw xmm {k1}{z}, xmm, r8","vpsraw xmm {k1}{z}, xmm, r8 |  | ")]
        vpsraw_xmm_k1z_xmm_r8 = 4286,

        /// <summary>
        /// vpsraw xmm, m128, imm8 |  | 
        /// </summary>
        [Symbol("vpsraw xmm, m128, imm8","vpsraw xmm, m128, imm8 |  | ")]
        vpsraw_xmm_m128_imm8 = 4287,

        /// <summary>
        /// vpsraw xmm, r8, imm8 |  | 
        /// </summary>
        [Symbol("vpsraw xmm, r8, imm8","vpsraw xmm, r8, imm8 |  | ")]
        vpsraw_xmm_r8_imm8 = 4288,

        /// <summary>
        /// vpsraw xmm, xmm, imm8 |  | 
        /// </summary>
        [Symbol("vpsraw xmm, xmm, imm8","vpsraw xmm, xmm, imm8 |  | ")]
        vpsraw_xmm_xmm_imm8 = 4289,

        /// <summary>
        /// vpsraw xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpsraw xmm, xmm, m128","vpsraw xmm, xmm, m128 |  | ")]
        vpsraw_xmm_xmm_m128 = 4290,

        /// <summary>
        /// vpsraw xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpsraw xmm, xmm, r8","vpsraw xmm, xmm, r8 |  | ")]
        vpsraw_xmm_xmm_r8 = 4291,

        /// <summary>
        /// vpsraw ymm {k1}{z}, m256, imm8 |  | 
        /// </summary>
        [Symbol("vpsraw ymm {k1}{z}, m256, imm8","vpsraw ymm {k1}{z}, m256, imm8 |  | ")]
        vpsraw_ymm_k1z_m256_imm8 = 4292,

        /// <summary>
        /// vpsraw ymm {k1}{z}, r16, imm8 |  | 
        /// </summary>
        [Symbol("vpsraw ymm {k1}{z}, r16, imm8","vpsraw ymm {k1}{z}, r16, imm8 |  | ")]
        vpsraw_ymm_k1z_r16_imm8 = 4293,

        /// <summary>
        /// vpsraw ymm {k1}{z}, ymm, m128 |  | 
        /// </summary>
        [Symbol("vpsraw ymm {k1}{z}, ymm, m128","vpsraw ymm {k1}{z}, ymm, m128 |  | ")]
        vpsraw_ymm_k1z_ymm_m128 = 4294,

        /// <summary>
        /// vpsraw ymm {k1}{z}, ymm, r8 |  | 
        /// </summary>
        [Symbol("vpsraw ymm {k1}{z}, ymm, r8","vpsraw ymm {k1}{z}, ymm, r8 |  | ")]
        vpsraw_ymm_k1z_ymm_r8 = 4295,

        /// <summary>
        /// vpsraw ymm, m256, imm8 |  | 
        /// </summary>
        [Symbol("vpsraw ymm, m256, imm8","vpsraw ymm, m256, imm8 |  | ")]
        vpsraw_ymm_m256_imm8 = 4296,

        /// <summary>
        /// vpsraw ymm, r16, imm8 |  | 
        /// </summary>
        [Symbol("vpsraw ymm, r16, imm8","vpsraw ymm, r16, imm8 |  | ")]
        vpsraw_ymm_r16_imm8 = 4297,

        /// <summary>
        /// vpsraw ymm, ymm, imm8 |  | 
        /// </summary>
        [Symbol("vpsraw ymm, ymm, imm8","vpsraw ymm, ymm, imm8 |  | ")]
        vpsraw_ymm_ymm_imm8 = 4298,

        /// <summary>
        /// vpsraw ymm, ymm, m128 |  | 
        /// </summary>
        [Symbol("vpsraw ymm, ymm, m128","vpsraw ymm, ymm, m128 |  | ")]
        vpsraw_ymm_ymm_m128 = 4299,

        /// <summary>
        /// vpsraw ymm, ymm, r8 |  | 
        /// </summary>
        [Symbol("vpsraw ymm, ymm, r8","vpsraw ymm, ymm, r8 |  | ")]
        vpsraw_ymm_ymm_r8 = 4300,

        /// <summary>
        /// vpsraw zmm {k1}{z}, m512, imm8 |  | 
        /// </summary>
        [Symbol("vpsraw zmm {k1}{z}, m512, imm8","vpsraw zmm {k1}{z}, m512, imm8 |  | ")]
        vpsraw_zmm_k1z_m512_imm8 = 4301,

        /// <summary>
        /// vpsraw zmm {k1}{z}, r32, imm8 |  | 
        /// </summary>
        [Symbol("vpsraw zmm {k1}{z}, r32, imm8","vpsraw zmm {k1}{z}, r32, imm8 |  | ")]
        vpsraw_zmm_k1z_r32_imm8 = 4302,

        /// <summary>
        /// vpsraw zmm {k1}{z}, zmm, m128 |  | 
        /// </summary>
        [Symbol("vpsraw zmm {k1}{z}, zmm, m128","vpsraw zmm {k1}{z}, zmm, m128 |  | ")]
        vpsraw_zmm_k1z_zmm_m128 = 4303,

        /// <summary>
        /// vpsraw zmm {k1}{z}, zmm, r8 |  | 
        /// </summary>
        [Symbol("vpsraw zmm {k1}{z}, zmm, r8","vpsraw zmm {k1}{z}, zmm, r8 |  | ")]
        vpsraw_zmm_k1z_zmm_r8 = 4304,

        /// <summary>
        /// vpsraw zmm, m512, imm8 |  | 
        /// </summary>
        [Symbol("vpsraw zmm, m512, imm8","vpsraw zmm, m512, imm8 |  | ")]
        vpsraw_zmm_m512_imm8 = 4305,

        /// <summary>
        /// vpsraw zmm, r32, imm8 |  | 
        /// </summary>
        [Symbol("vpsraw zmm, r32, imm8","vpsraw zmm, r32, imm8 |  | ")]
        vpsraw_zmm_r32_imm8 = 4306,

        /// <summary>
        /// vpsraw zmm, zmm, m128 |  | 
        /// </summary>
        [Symbol("vpsraw zmm, zmm, m128","vpsraw zmm, zmm, m128 |  | ")]
        vpsraw_zmm_zmm_m128 = 4307,

        /// <summary>
        /// vpsraw zmm, zmm, r8 |  | 
        /// </summary>
        [Symbol("vpsraw zmm, zmm, r8","vpsraw zmm, zmm, r8 |  | ")]
        vpsraw_zmm_zmm_r8 = 4308,

        /// <summary>
        /// vpsrld xmm {k1}{z}, m128, imm8 |  | 
        /// </summary>
        [Symbol("vpsrld xmm {k1}{z}, m128, imm8","vpsrld xmm {k1}{z}, m128, imm8 |  | ")]
        vpsrld_xmm_k1z_m128_imm8 = 4309,

        /// <summary>
        /// vpsrld xmm {k1}{z}, m32bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpsrld xmm {k1}{z}, m32bcst, imm8","vpsrld xmm {k1}{z}, m32bcst, imm8 |  | ")]
        vpsrld_xmm_k1z_m32bcst_imm8 = 4310,

        /// <summary>
        /// vpsrld xmm {k1}{z}, xmm, imm8 |  | 
        /// </summary>
        [Symbol("vpsrld xmm {k1}{z}, xmm, imm8","vpsrld xmm {k1}{z}, xmm, imm8 |  | ")]
        vpsrld_xmm_k1z_xmm_imm8 = 4311,

        /// <summary>
        /// vpsrld xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpsrld xmm {k1}{z}, xmm, m128","vpsrld xmm {k1}{z}, xmm, m128 |  | ")]
        vpsrld_xmm_k1z_xmm_m128 = 4312,

        /// <summary>
        /// vpsrld xmm {k1}{z}, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpsrld xmm {k1}{z}, xmm, r8","vpsrld xmm {k1}{z}, xmm, r8 |  | ")]
        vpsrld_xmm_k1z_xmm_r8 = 4313,

        /// <summary>
        /// vpsrld xmm, m128, imm8 |  | 
        /// </summary>
        [Symbol("vpsrld xmm, m128, imm8","vpsrld xmm, m128, imm8 |  | ")]
        vpsrld_xmm_m128_imm8 = 4314,

        /// <summary>
        /// vpsrld xmm, m32bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpsrld xmm, m32bcst, imm8","vpsrld xmm, m32bcst, imm8 |  | ")]
        vpsrld_xmm_m32bcst_imm8 = 4315,

        /// <summary>
        /// vpsrld xmm, xmm, imm8 |  | 
        /// </summary>
        [Symbol("vpsrld xmm, xmm, imm8","vpsrld xmm, xmm, imm8 |  | ")]
        vpsrld_xmm_xmm_imm8 = 4316,

        /// <summary>
        /// vpsrld xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpsrld xmm, xmm, m128","vpsrld xmm, xmm, m128 |  | ")]
        vpsrld_xmm_xmm_m128 = 4317,

        /// <summary>
        /// vpsrld xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpsrld xmm, xmm, r8","vpsrld xmm, xmm, r8 |  | ")]
        vpsrld_xmm_xmm_r8 = 4318,

        /// <summary>
        /// vpsrld ymm {k1}{z}, m256, imm8 |  | 
        /// </summary>
        [Symbol("vpsrld ymm {k1}{z}, m256, imm8","vpsrld ymm {k1}{z}, m256, imm8 |  | ")]
        vpsrld_ymm_k1z_m256_imm8 = 4319,

        /// <summary>
        /// vpsrld ymm {k1}{z}, m32bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpsrld ymm {k1}{z}, m32bcst, imm8","vpsrld ymm {k1}{z}, m32bcst, imm8 |  | ")]
        vpsrld_ymm_k1z_m32bcst_imm8 = 4320,

        /// <summary>
        /// vpsrld ymm {k1}{z}, ymm, imm8 |  | 
        /// </summary>
        [Symbol("vpsrld ymm {k1}{z}, ymm, imm8","vpsrld ymm {k1}{z}, ymm, imm8 |  | ")]
        vpsrld_ymm_k1z_ymm_imm8 = 4321,

        /// <summary>
        /// vpsrld ymm {k1}{z}, ymm, m128 |  | 
        /// </summary>
        [Symbol("vpsrld ymm {k1}{z}, ymm, m128","vpsrld ymm {k1}{z}, ymm, m128 |  | ")]
        vpsrld_ymm_k1z_ymm_m128 = 4322,

        /// <summary>
        /// vpsrld ymm {k1}{z}, ymm, r8 |  | 
        /// </summary>
        [Symbol("vpsrld ymm {k1}{z}, ymm, r8","vpsrld ymm {k1}{z}, ymm, r8 |  | ")]
        vpsrld_ymm_k1z_ymm_r8 = 4323,

        /// <summary>
        /// vpsrld ymm, m256, imm8 |  | 
        /// </summary>
        [Symbol("vpsrld ymm, m256, imm8","vpsrld ymm, m256, imm8 |  | ")]
        vpsrld_ymm_m256_imm8 = 4324,

        /// <summary>
        /// vpsrld ymm, m32bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpsrld ymm, m32bcst, imm8","vpsrld ymm, m32bcst, imm8 |  | ")]
        vpsrld_ymm_m32bcst_imm8 = 4325,

        /// <summary>
        /// vpsrld ymm, ymm, imm8 |  | 
        /// </summary>
        [Symbol("vpsrld ymm, ymm, imm8","vpsrld ymm, ymm, imm8 |  | ")]
        vpsrld_ymm_ymm_imm8 = 4326,

        /// <summary>
        /// vpsrld ymm, ymm, m128 |  | 
        /// </summary>
        [Symbol("vpsrld ymm, ymm, m128","vpsrld ymm, ymm, m128 |  | ")]
        vpsrld_ymm_ymm_m128 = 4327,

        /// <summary>
        /// vpsrld ymm, ymm, r8 |  | 
        /// </summary>
        [Symbol("vpsrld ymm, ymm, r8","vpsrld ymm, ymm, r8 |  | ")]
        vpsrld_ymm_ymm_r8 = 4328,

        /// <summary>
        /// vpsrld zmm {k1}{z}, m32bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpsrld zmm {k1}{z}, m32bcst, imm8","vpsrld zmm {k1}{z}, m32bcst, imm8 |  | ")]
        vpsrld_zmm_k1z_m32bcst_imm8 = 4329,

        /// <summary>
        /// vpsrld zmm {k1}{z}, m512, imm8 |  | 
        /// </summary>
        [Symbol("vpsrld zmm {k1}{z}, m512, imm8","vpsrld zmm {k1}{z}, m512, imm8 |  | ")]
        vpsrld_zmm_k1z_m512_imm8 = 4330,

        /// <summary>
        /// vpsrld zmm {k1}{z}, zmm, imm8 |  | 
        /// </summary>
        [Symbol("vpsrld zmm {k1}{z}, zmm, imm8","vpsrld zmm {k1}{z}, zmm, imm8 |  | ")]
        vpsrld_zmm_k1z_zmm_imm8 = 4331,

        /// <summary>
        /// vpsrld zmm {k1}{z}, zmm, m128 |  | 
        /// </summary>
        [Symbol("vpsrld zmm {k1}{z}, zmm, m128","vpsrld zmm {k1}{z}, zmm, m128 |  | ")]
        vpsrld_zmm_k1z_zmm_m128 = 4332,

        /// <summary>
        /// vpsrld zmm {k1}{z}, zmm, r8 |  | 
        /// </summary>
        [Symbol("vpsrld zmm {k1}{z}, zmm, r8","vpsrld zmm {k1}{z}, zmm, r8 |  | ")]
        vpsrld_zmm_k1z_zmm_r8 = 4333,

        /// <summary>
        /// vpsrld zmm, m32bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpsrld zmm, m32bcst, imm8","vpsrld zmm, m32bcst, imm8 |  | ")]
        vpsrld_zmm_m32bcst_imm8 = 4334,

        /// <summary>
        /// vpsrld zmm, m512, imm8 |  | 
        /// </summary>
        [Symbol("vpsrld zmm, m512, imm8","vpsrld zmm, m512, imm8 |  | ")]
        vpsrld_zmm_m512_imm8 = 4335,

        /// <summary>
        /// vpsrld zmm, zmm, imm8 |  | 
        /// </summary>
        [Symbol("vpsrld zmm, zmm, imm8","vpsrld zmm, zmm, imm8 |  | ")]
        vpsrld_zmm_zmm_imm8 = 4336,

        /// <summary>
        /// vpsrld zmm, zmm, m128 |  | 
        /// </summary>
        [Symbol("vpsrld zmm, zmm, m128","vpsrld zmm, zmm, m128 |  | ")]
        vpsrld_zmm_zmm_m128 = 4337,

        /// <summary>
        /// vpsrld zmm, zmm, r8 |  | 
        /// </summary>
        [Symbol("vpsrld zmm, zmm, r8","vpsrld zmm, zmm, r8 |  | ")]
        vpsrld_zmm_zmm_r8 = 4338,

        /// <summary>
        /// vpsrlq xmm {k1}{z}, m128, imm8 |  | 
        /// </summary>
        [Symbol("vpsrlq xmm {k1}{z}, m128, imm8","vpsrlq xmm {k1}{z}, m128, imm8 |  | ")]
        vpsrlq_xmm_k1z_m128_imm8 = 4339,

        /// <summary>
        /// vpsrlq xmm {k1}{z}, m64bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpsrlq xmm {k1}{z}, m64bcst, imm8","vpsrlq xmm {k1}{z}, m64bcst, imm8 |  | ")]
        vpsrlq_xmm_k1z_m64bcst_imm8 = 4340,

        /// <summary>
        /// vpsrlq xmm {k1}{z}, xmm, imm8 |  | 
        /// </summary>
        [Symbol("vpsrlq xmm {k1}{z}, xmm, imm8","vpsrlq xmm {k1}{z}, xmm, imm8 |  | ")]
        vpsrlq_xmm_k1z_xmm_imm8 = 4341,

        /// <summary>
        /// vpsrlq xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpsrlq xmm {k1}{z}, xmm, m128","vpsrlq xmm {k1}{z}, xmm, m128 |  | ")]
        vpsrlq_xmm_k1z_xmm_m128 = 4342,

        /// <summary>
        /// vpsrlq xmm {k1}{z}, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpsrlq xmm {k1}{z}, xmm, r8","vpsrlq xmm {k1}{z}, xmm, r8 |  | ")]
        vpsrlq_xmm_k1z_xmm_r8 = 4343,

        /// <summary>
        /// vpsrlq xmm, m128, imm8 |  | 
        /// </summary>
        [Symbol("vpsrlq xmm, m128, imm8","vpsrlq xmm, m128, imm8 |  | ")]
        vpsrlq_xmm_m128_imm8 = 4344,

        /// <summary>
        /// vpsrlq xmm, m64bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpsrlq xmm, m64bcst, imm8","vpsrlq xmm, m64bcst, imm8 |  | ")]
        vpsrlq_xmm_m64bcst_imm8 = 4345,

        /// <summary>
        /// vpsrlq xmm, xmm, imm8 |  | 
        /// </summary>
        [Symbol("vpsrlq xmm, xmm, imm8","vpsrlq xmm, xmm, imm8 |  | ")]
        vpsrlq_xmm_xmm_imm8 = 4346,

        /// <summary>
        /// vpsrlq xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpsrlq xmm, xmm, m128","vpsrlq xmm, xmm, m128 |  | ")]
        vpsrlq_xmm_xmm_m128 = 4347,

        /// <summary>
        /// vpsrlq xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpsrlq xmm, xmm, r8","vpsrlq xmm, xmm, r8 |  | ")]
        vpsrlq_xmm_xmm_r8 = 4348,

        /// <summary>
        /// vpsrlq ymm {k1}{z}, m256, imm8 |  | 
        /// </summary>
        [Symbol("vpsrlq ymm {k1}{z}, m256, imm8","vpsrlq ymm {k1}{z}, m256, imm8 |  | ")]
        vpsrlq_ymm_k1z_m256_imm8 = 4349,

        /// <summary>
        /// vpsrlq ymm {k1}{z}, m64bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpsrlq ymm {k1}{z}, m64bcst, imm8","vpsrlq ymm {k1}{z}, m64bcst, imm8 |  | ")]
        vpsrlq_ymm_k1z_m64bcst_imm8 = 4350,

        /// <summary>
        /// vpsrlq ymm {k1}{z}, ymm, imm8 |  | 
        /// </summary>
        [Symbol("vpsrlq ymm {k1}{z}, ymm, imm8","vpsrlq ymm {k1}{z}, ymm, imm8 |  | ")]
        vpsrlq_ymm_k1z_ymm_imm8 = 4351,

        /// <summary>
        /// vpsrlq ymm {k1}{z}, ymm, m128 |  | 
        /// </summary>
        [Symbol("vpsrlq ymm {k1}{z}, ymm, m128","vpsrlq ymm {k1}{z}, ymm, m128 |  | ")]
        vpsrlq_ymm_k1z_ymm_m128 = 4352,

        /// <summary>
        /// vpsrlq ymm {k1}{z}, ymm, r8 |  | 
        /// </summary>
        [Symbol("vpsrlq ymm {k1}{z}, ymm, r8","vpsrlq ymm {k1}{z}, ymm, r8 |  | ")]
        vpsrlq_ymm_k1z_ymm_r8 = 4353,

        /// <summary>
        /// vpsrlq ymm, m256, imm8 |  | 
        /// </summary>
        [Symbol("vpsrlq ymm, m256, imm8","vpsrlq ymm, m256, imm8 |  | ")]
        vpsrlq_ymm_m256_imm8 = 4354,

        /// <summary>
        /// vpsrlq ymm, m64bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpsrlq ymm, m64bcst, imm8","vpsrlq ymm, m64bcst, imm8 |  | ")]
        vpsrlq_ymm_m64bcst_imm8 = 4355,

        /// <summary>
        /// vpsrlq ymm, ymm, imm8 |  | 
        /// </summary>
        [Symbol("vpsrlq ymm, ymm, imm8","vpsrlq ymm, ymm, imm8 |  | ")]
        vpsrlq_ymm_ymm_imm8 = 4356,

        /// <summary>
        /// vpsrlq ymm, ymm, m128 |  | 
        /// </summary>
        [Symbol("vpsrlq ymm, ymm, m128","vpsrlq ymm, ymm, m128 |  | ")]
        vpsrlq_ymm_ymm_m128 = 4357,

        /// <summary>
        /// vpsrlq ymm, ymm, r8 |  | 
        /// </summary>
        [Symbol("vpsrlq ymm, ymm, r8","vpsrlq ymm, ymm, r8 |  | ")]
        vpsrlq_ymm_ymm_r8 = 4358,

        /// <summary>
        /// vpsrlq zmm {k1}{z}, m512, imm8 |  | 
        /// </summary>
        [Symbol("vpsrlq zmm {k1}{z}, m512, imm8","vpsrlq zmm {k1}{z}, m512, imm8 |  | ")]
        vpsrlq_zmm_k1z_m512_imm8 = 4359,

        /// <summary>
        /// vpsrlq zmm {k1}{z}, m64bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpsrlq zmm {k1}{z}, m64bcst, imm8","vpsrlq zmm {k1}{z}, m64bcst, imm8 |  | ")]
        vpsrlq_zmm_k1z_m64bcst_imm8 = 4360,

        /// <summary>
        /// vpsrlq zmm {k1}{z}, zmm, imm8 |  | 
        /// </summary>
        [Symbol("vpsrlq zmm {k1}{z}, zmm, imm8","vpsrlq zmm {k1}{z}, zmm, imm8 |  | ")]
        vpsrlq_zmm_k1z_zmm_imm8 = 4361,

        /// <summary>
        /// vpsrlq zmm {k1}{z}, zmm, m128 |  | 
        /// </summary>
        [Symbol("vpsrlq zmm {k1}{z}, zmm, m128","vpsrlq zmm {k1}{z}, zmm, m128 |  | ")]
        vpsrlq_zmm_k1z_zmm_m128 = 4362,

        /// <summary>
        /// vpsrlq zmm {k1}{z}, zmm, r8 |  | 
        /// </summary>
        [Symbol("vpsrlq zmm {k1}{z}, zmm, r8","vpsrlq zmm {k1}{z}, zmm, r8 |  | ")]
        vpsrlq_zmm_k1z_zmm_r8 = 4363,

        /// <summary>
        /// vpsrlq zmm, m512, imm8 |  | 
        /// </summary>
        [Symbol("vpsrlq zmm, m512, imm8","vpsrlq zmm, m512, imm8 |  | ")]
        vpsrlq_zmm_m512_imm8 = 4364,

        /// <summary>
        /// vpsrlq zmm, m64bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpsrlq zmm, m64bcst, imm8","vpsrlq zmm, m64bcst, imm8 |  | ")]
        vpsrlq_zmm_m64bcst_imm8 = 4365,

        /// <summary>
        /// vpsrlq zmm, zmm, imm8 |  | 
        /// </summary>
        [Symbol("vpsrlq zmm, zmm, imm8","vpsrlq zmm, zmm, imm8 |  | ")]
        vpsrlq_zmm_zmm_imm8 = 4366,

        /// <summary>
        /// vpsrlq zmm, zmm, m128 |  | 
        /// </summary>
        [Symbol("vpsrlq zmm, zmm, m128","vpsrlq zmm, zmm, m128 |  | ")]
        vpsrlq_zmm_zmm_m128 = 4367,

        /// <summary>
        /// vpsrlq zmm, zmm, r8 |  | 
        /// </summary>
        [Symbol("vpsrlq zmm, zmm, r8","vpsrlq zmm, zmm, r8 |  | ")]
        vpsrlq_zmm_zmm_r8 = 4368,

        /// <summary>
        /// vpsrlvd xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpsrlvd xmm {k1}{z}, xmm, m128","vpsrlvd xmm {k1}{z}, xmm, m128 |  | ")]
        vpsrlvd_xmm_k1z_xmm_m128 = 4369,

        /// <summary>
        /// vpsrlvd xmm {k1}{z}, xmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpsrlvd xmm {k1}{z}, xmm, m32bcst","vpsrlvd xmm {k1}{z}, xmm, m32bcst |  | ")]
        vpsrlvd_xmm_k1z_xmm_m32bcst = 4370,

        /// <summary>
        /// vpsrlvd xmm {k1}{z}, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpsrlvd xmm {k1}{z}, xmm, xmm","vpsrlvd xmm {k1}{z}, xmm, xmm |  | ")]
        vpsrlvd_xmm_k1z_xmm_xmm = 4371,

        /// <summary>
        /// vpsrlvd xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpsrlvd xmm, xmm, m128","vpsrlvd xmm, xmm, m128 |  | ")]
        vpsrlvd_xmm_xmm_m128 = 4372,

        /// <summary>
        /// vpsrlvd xmm, xmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpsrlvd xmm, xmm, m32bcst","vpsrlvd xmm, xmm, m32bcst |  | ")]
        vpsrlvd_xmm_xmm_m32bcst = 4373,

        /// <summary>
        /// vpsrlvd xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpsrlvd xmm, xmm, r8","vpsrlvd xmm, xmm, r8 |  | ")]
        vpsrlvd_xmm_xmm_r8 = 4374,

        /// <summary>
        /// vpsrlvd xmm, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpsrlvd xmm, xmm, xmm","vpsrlvd xmm, xmm, xmm |  | ")]
        vpsrlvd_xmm_xmm_xmm = 4375,

        /// <summary>
        /// vpsrlvd ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpsrlvd ymm {k1}{z}, ymm, m256","vpsrlvd ymm {k1}{z}, ymm, m256 |  | ")]
        vpsrlvd_ymm_k1z_ymm_m256 = 4376,

        /// <summary>
        /// vpsrlvd ymm {k1}{z}, ymm, m32bcst |  | 
        /// </summary>
        [Symbol("vpsrlvd ymm {k1}{z}, ymm, m32bcst","vpsrlvd ymm {k1}{z}, ymm, m32bcst |  | ")]
        vpsrlvd_ymm_k1z_ymm_m32bcst = 4377,

        /// <summary>
        /// vpsrlvd ymm {k1}{z}, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpsrlvd ymm {k1}{z}, ymm, ymm","vpsrlvd ymm {k1}{z}, ymm, ymm |  | ")]
        vpsrlvd_ymm_k1z_ymm_ymm = 4378,

        /// <summary>
        /// vpsrlvd ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpsrlvd ymm, ymm, m256","vpsrlvd ymm, ymm, m256 |  | ")]
        vpsrlvd_ymm_ymm_m256 = 4379,

        /// <summary>
        /// vpsrlvd ymm, ymm, m32bcst |  | 
        /// </summary>
        [Symbol("vpsrlvd ymm, ymm, m32bcst","vpsrlvd ymm, ymm, m32bcst |  | ")]
        vpsrlvd_ymm_ymm_m32bcst = 4380,

        /// <summary>
        /// vpsrlvd ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpsrlvd ymm, ymm, r16","vpsrlvd ymm, ymm, r16 |  | ")]
        vpsrlvd_ymm_ymm_r16 = 4381,

        /// <summary>
        /// vpsrlvd ymm, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpsrlvd ymm, ymm, ymm","vpsrlvd ymm, ymm, ymm |  | ")]
        vpsrlvd_ymm_ymm_ymm = 4382,

        /// <summary>
        /// vpsrlvd zmm {k1}{z}, zmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpsrlvd zmm {k1}{z}, zmm, m32bcst","vpsrlvd zmm {k1}{z}, zmm, m32bcst |  | ")]
        vpsrlvd_zmm_k1z_zmm_m32bcst = 4383,

        /// <summary>
        /// vpsrlvd zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpsrlvd zmm {k1}{z}, zmm, m512","vpsrlvd zmm {k1}{z}, zmm, m512 |  | ")]
        vpsrlvd_zmm_k1z_zmm_m512 = 4384,

        /// <summary>
        /// vpsrlvd zmm {k1}{z}, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpsrlvd zmm {k1}{z}, zmm, zmm","vpsrlvd zmm {k1}{z}, zmm, zmm |  | ")]
        vpsrlvd_zmm_k1z_zmm_zmm = 4385,

        /// <summary>
        /// vpsrlvd zmm, zmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpsrlvd zmm, zmm, m32bcst","vpsrlvd zmm, zmm, m32bcst |  | ")]
        vpsrlvd_zmm_zmm_m32bcst = 4386,

        /// <summary>
        /// vpsrlvd zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpsrlvd zmm, zmm, m512","vpsrlvd zmm, zmm, m512 |  | ")]
        vpsrlvd_zmm_zmm_m512 = 4387,

        /// <summary>
        /// vpsrlvd zmm, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpsrlvd zmm, zmm, zmm","vpsrlvd zmm, zmm, zmm |  | ")]
        vpsrlvd_zmm_zmm_zmm = 4388,

        /// <summary>
        /// vpsrlvq xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpsrlvq xmm {k1}{z}, xmm, m128","vpsrlvq xmm {k1}{z}, xmm, m128 |  | ")]
        vpsrlvq_xmm_k1z_xmm_m128 = 4389,

        /// <summary>
        /// vpsrlvq xmm {k1}{z}, xmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpsrlvq xmm {k1}{z}, xmm, m64bcst","vpsrlvq xmm {k1}{z}, xmm, m64bcst |  | ")]
        vpsrlvq_xmm_k1z_xmm_m64bcst = 4390,

        /// <summary>
        /// vpsrlvq xmm {k1}{z}, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpsrlvq xmm {k1}{z}, xmm, xmm","vpsrlvq xmm {k1}{z}, xmm, xmm |  | ")]
        vpsrlvq_xmm_k1z_xmm_xmm = 4391,

        /// <summary>
        /// vpsrlvq xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpsrlvq xmm, xmm, m128","vpsrlvq xmm, xmm, m128 |  | ")]
        vpsrlvq_xmm_xmm_m128 = 4392,

        /// <summary>
        /// vpsrlvq xmm, xmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpsrlvq xmm, xmm, m64bcst","vpsrlvq xmm, xmm, m64bcst |  | ")]
        vpsrlvq_xmm_xmm_m64bcst = 4393,

        /// <summary>
        /// vpsrlvq xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpsrlvq xmm, xmm, r8","vpsrlvq xmm, xmm, r8 |  | ")]
        vpsrlvq_xmm_xmm_r8 = 4394,

        /// <summary>
        /// vpsrlvq xmm, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpsrlvq xmm, xmm, xmm","vpsrlvq xmm, xmm, xmm |  | ")]
        vpsrlvq_xmm_xmm_xmm = 4395,

        /// <summary>
        /// vpsrlvq ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpsrlvq ymm {k1}{z}, ymm, m256","vpsrlvq ymm {k1}{z}, ymm, m256 |  | ")]
        vpsrlvq_ymm_k1z_ymm_m256 = 4396,

        /// <summary>
        /// vpsrlvq ymm {k1}{z}, ymm, m64bcst |  | 
        /// </summary>
        [Symbol("vpsrlvq ymm {k1}{z}, ymm, m64bcst","vpsrlvq ymm {k1}{z}, ymm, m64bcst |  | ")]
        vpsrlvq_ymm_k1z_ymm_m64bcst = 4397,

        /// <summary>
        /// vpsrlvq ymm {k1}{z}, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpsrlvq ymm {k1}{z}, ymm, ymm","vpsrlvq ymm {k1}{z}, ymm, ymm |  | ")]
        vpsrlvq_ymm_k1z_ymm_ymm = 4398,

        /// <summary>
        /// vpsrlvq ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpsrlvq ymm, ymm, m256","vpsrlvq ymm, ymm, m256 |  | ")]
        vpsrlvq_ymm_ymm_m256 = 4399,

        /// <summary>
        /// vpsrlvq ymm, ymm, m64bcst |  | 
        /// </summary>
        [Symbol("vpsrlvq ymm, ymm, m64bcst","vpsrlvq ymm, ymm, m64bcst |  | ")]
        vpsrlvq_ymm_ymm_m64bcst = 4400,

        /// <summary>
        /// vpsrlvq ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpsrlvq ymm, ymm, r16","vpsrlvq ymm, ymm, r16 |  | ")]
        vpsrlvq_ymm_ymm_r16 = 4401,

        /// <summary>
        /// vpsrlvq ymm, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpsrlvq ymm, ymm, ymm","vpsrlvq ymm, ymm, ymm |  | ")]
        vpsrlvq_ymm_ymm_ymm = 4402,

        /// <summary>
        /// vpsrlvq zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpsrlvq zmm {k1}{z}, zmm, m512","vpsrlvq zmm {k1}{z}, zmm, m512 |  | ")]
        vpsrlvq_zmm_k1z_zmm_m512 = 4403,

        /// <summary>
        /// vpsrlvq zmm {k1}{z}, zmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpsrlvq zmm {k1}{z}, zmm, m64bcst","vpsrlvq zmm {k1}{z}, zmm, m64bcst |  | ")]
        vpsrlvq_zmm_k1z_zmm_m64bcst = 4404,

        /// <summary>
        /// vpsrlvq zmm {k1}{z}, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpsrlvq zmm {k1}{z}, zmm, zmm","vpsrlvq zmm {k1}{z}, zmm, zmm |  | ")]
        vpsrlvq_zmm_k1z_zmm_zmm = 4405,

        /// <summary>
        /// vpsrlvq zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpsrlvq zmm, zmm, m512","vpsrlvq zmm, zmm, m512 |  | ")]
        vpsrlvq_zmm_zmm_m512 = 4406,

        /// <summary>
        /// vpsrlvq zmm, zmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpsrlvq zmm, zmm, m64bcst","vpsrlvq zmm, zmm, m64bcst |  | ")]
        vpsrlvq_zmm_zmm_m64bcst = 4407,

        /// <summary>
        /// vpsrlvq zmm, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpsrlvq zmm, zmm, zmm","vpsrlvq zmm, zmm, zmm |  | ")]
        vpsrlvq_zmm_zmm_zmm = 4408,

        /// <summary>
        /// vpsrlvw xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpsrlvw xmm {k1}{z}, xmm, m128","vpsrlvw xmm {k1}{z}, xmm, m128 |  | ")]
        vpsrlvw_xmm_k1z_xmm_m128 = 4409,

        /// <summary>
        /// vpsrlvw xmm {k1}{z}, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpsrlvw xmm {k1}{z}, xmm, r8","vpsrlvw xmm {k1}{z}, xmm, r8 |  | ")]
        vpsrlvw_xmm_k1z_xmm_r8 = 4410,

        /// <summary>
        /// vpsrlvw xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpsrlvw xmm, xmm, m128","vpsrlvw xmm, xmm, m128 |  | ")]
        vpsrlvw_xmm_xmm_m128 = 4411,

        /// <summary>
        /// vpsrlvw xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpsrlvw xmm, xmm, r8","vpsrlvw xmm, xmm, r8 |  | ")]
        vpsrlvw_xmm_xmm_r8 = 4412,

        /// <summary>
        /// vpsrlvw ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpsrlvw ymm {k1}{z}, ymm, m256","vpsrlvw ymm {k1}{z}, ymm, m256 |  | ")]
        vpsrlvw_ymm_k1z_ymm_m256 = 4413,

        /// <summary>
        /// vpsrlvw ymm {k1}{z}, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpsrlvw ymm {k1}{z}, ymm, r16","vpsrlvw ymm {k1}{z}, ymm, r16 |  | ")]
        vpsrlvw_ymm_k1z_ymm_r16 = 4414,

        /// <summary>
        /// vpsrlvw ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpsrlvw ymm, ymm, m256","vpsrlvw ymm, ymm, m256 |  | ")]
        vpsrlvw_ymm_ymm_m256 = 4415,

        /// <summary>
        /// vpsrlvw ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpsrlvw ymm, ymm, r16","vpsrlvw ymm, ymm, r16 |  | ")]
        vpsrlvw_ymm_ymm_r16 = 4416,

        /// <summary>
        /// vpsrlvw zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpsrlvw zmm {k1}{z}, zmm, m512","vpsrlvw zmm {k1}{z}, zmm, m512 |  | ")]
        vpsrlvw_zmm_k1z_zmm_m512 = 4417,

        /// <summary>
        /// vpsrlvw zmm {k1}{z}, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpsrlvw zmm {k1}{z}, zmm, r32","vpsrlvw zmm {k1}{z}, zmm, r32 |  | ")]
        vpsrlvw_zmm_k1z_zmm_r32 = 4418,

        /// <summary>
        /// vpsrlvw zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpsrlvw zmm, zmm, m512","vpsrlvw zmm, zmm, m512 |  | ")]
        vpsrlvw_zmm_zmm_m512 = 4419,

        /// <summary>
        /// vpsrlvw zmm, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpsrlvw zmm, zmm, r32","vpsrlvw zmm, zmm, r32 |  | ")]
        vpsrlvw_zmm_zmm_r32 = 4420,

        /// <summary>
        /// vpsrlw xmm {k1}{z}, m128, imm8 |  | 
        /// </summary>
        [Symbol("vpsrlw xmm {k1}{z}, m128, imm8","vpsrlw xmm {k1}{z}, m128, imm8 |  | ")]
        vpsrlw_xmm_k1z_m128_imm8 = 4421,

        /// <summary>
        /// vpsrlw xmm {k1}{z}, r8, imm8 |  | 
        /// </summary>
        [Symbol("vpsrlw xmm {k1}{z}, r8, imm8","vpsrlw xmm {k1}{z}, r8, imm8 |  | ")]
        vpsrlw_xmm_k1z_r8_imm8 = 4422,

        /// <summary>
        /// vpsrlw xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpsrlw xmm {k1}{z}, xmm, m128","vpsrlw xmm {k1}{z}, xmm, m128 |  | ")]
        vpsrlw_xmm_k1z_xmm_m128 = 4423,

        /// <summary>
        /// vpsrlw xmm {k1}{z}, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpsrlw xmm {k1}{z}, xmm, r8","vpsrlw xmm {k1}{z}, xmm, r8 |  | ")]
        vpsrlw_xmm_k1z_xmm_r8 = 4424,

        /// <summary>
        /// vpsrlw xmm, m128, imm8 |  | 
        /// </summary>
        [Symbol("vpsrlw xmm, m128, imm8","vpsrlw xmm, m128, imm8 |  | ")]
        vpsrlw_xmm_m128_imm8 = 4425,

        /// <summary>
        /// vpsrlw xmm, r8, imm8 |  | 
        /// </summary>
        [Symbol("vpsrlw xmm, r8, imm8","vpsrlw xmm, r8, imm8 |  | ")]
        vpsrlw_xmm_r8_imm8 = 4426,

        /// <summary>
        /// vpsrlw xmm, xmm, imm8 |  | 
        /// </summary>
        [Symbol("vpsrlw xmm, xmm, imm8","vpsrlw xmm, xmm, imm8 |  | ")]
        vpsrlw_xmm_xmm_imm8 = 4427,

        /// <summary>
        /// vpsrlw xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpsrlw xmm, xmm, m128","vpsrlw xmm, xmm, m128 |  | ")]
        vpsrlw_xmm_xmm_m128 = 4428,

        /// <summary>
        /// vpsrlw xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpsrlw xmm, xmm, r8","vpsrlw xmm, xmm, r8 |  | ")]
        vpsrlw_xmm_xmm_r8 = 4429,

        /// <summary>
        /// vpsrlw ymm {k1}{z}, m256, imm8 |  | 
        /// </summary>
        [Symbol("vpsrlw ymm {k1}{z}, m256, imm8","vpsrlw ymm {k1}{z}, m256, imm8 |  | ")]
        vpsrlw_ymm_k1z_m256_imm8 = 4430,

        /// <summary>
        /// vpsrlw ymm {k1}{z}, r16, imm8 |  | 
        /// </summary>
        [Symbol("vpsrlw ymm {k1}{z}, r16, imm8","vpsrlw ymm {k1}{z}, r16, imm8 |  | ")]
        vpsrlw_ymm_k1z_r16_imm8 = 4431,

        /// <summary>
        /// vpsrlw ymm {k1}{z}, ymm, m128 |  | 
        /// </summary>
        [Symbol("vpsrlw ymm {k1}{z}, ymm, m128","vpsrlw ymm {k1}{z}, ymm, m128 |  | ")]
        vpsrlw_ymm_k1z_ymm_m128 = 4432,

        /// <summary>
        /// vpsrlw ymm {k1}{z}, ymm, r8 |  | 
        /// </summary>
        [Symbol("vpsrlw ymm {k1}{z}, ymm, r8","vpsrlw ymm {k1}{z}, ymm, r8 |  | ")]
        vpsrlw_ymm_k1z_ymm_r8 = 4433,

        /// <summary>
        /// vpsrlw ymm, m256, imm8 |  | 
        /// </summary>
        [Symbol("vpsrlw ymm, m256, imm8","vpsrlw ymm, m256, imm8 |  | ")]
        vpsrlw_ymm_m256_imm8 = 4434,

        /// <summary>
        /// vpsrlw ymm, r16, imm8 |  | 
        /// </summary>
        [Symbol("vpsrlw ymm, r16, imm8","vpsrlw ymm, r16, imm8 |  | ")]
        vpsrlw_ymm_r16_imm8 = 4435,

        /// <summary>
        /// vpsrlw ymm, ymm, imm8 |  | 
        /// </summary>
        [Symbol("vpsrlw ymm, ymm, imm8","vpsrlw ymm, ymm, imm8 |  | ")]
        vpsrlw_ymm_ymm_imm8 = 4436,

        /// <summary>
        /// vpsrlw ymm, ymm, m128 |  | 
        /// </summary>
        [Symbol("vpsrlw ymm, ymm, m128","vpsrlw ymm, ymm, m128 |  | ")]
        vpsrlw_ymm_ymm_m128 = 4437,

        /// <summary>
        /// vpsrlw ymm, ymm, r8 |  | 
        /// </summary>
        [Symbol("vpsrlw ymm, ymm, r8","vpsrlw ymm, ymm, r8 |  | ")]
        vpsrlw_ymm_ymm_r8 = 4438,

        /// <summary>
        /// vpsrlw zmm {k1}{z}, m512, imm8 |  | 
        /// </summary>
        [Symbol("vpsrlw zmm {k1}{z}, m512, imm8","vpsrlw zmm {k1}{z}, m512, imm8 |  | ")]
        vpsrlw_zmm_k1z_m512_imm8 = 4439,

        /// <summary>
        /// vpsrlw zmm {k1}{z}, r32, imm8 |  | 
        /// </summary>
        [Symbol("vpsrlw zmm {k1}{z}, r32, imm8","vpsrlw zmm {k1}{z}, r32, imm8 |  | ")]
        vpsrlw_zmm_k1z_r32_imm8 = 4440,

        /// <summary>
        /// vpsrlw zmm {k1}{z}, zmm, m128 |  | 
        /// </summary>
        [Symbol("vpsrlw zmm {k1}{z}, zmm, m128","vpsrlw zmm {k1}{z}, zmm, m128 |  | ")]
        vpsrlw_zmm_k1z_zmm_m128 = 4441,

        /// <summary>
        /// vpsrlw zmm {k1}{z}, zmm, r8 |  | 
        /// </summary>
        [Symbol("vpsrlw zmm {k1}{z}, zmm, r8","vpsrlw zmm {k1}{z}, zmm, r8 |  | ")]
        vpsrlw_zmm_k1z_zmm_r8 = 4442,

        /// <summary>
        /// vpsrlw zmm, m512, imm8 |  | 
        /// </summary>
        [Symbol("vpsrlw zmm, m512, imm8","vpsrlw zmm, m512, imm8 |  | ")]
        vpsrlw_zmm_m512_imm8 = 4443,

        /// <summary>
        /// vpsrlw zmm, r32, imm8 |  | 
        /// </summary>
        [Symbol("vpsrlw zmm, r32, imm8","vpsrlw zmm, r32, imm8 |  | ")]
        vpsrlw_zmm_r32_imm8 = 4444,

        /// <summary>
        /// vpsrlw zmm, zmm, m128 |  | 
        /// </summary>
        [Symbol("vpsrlw zmm, zmm, m128","vpsrlw zmm, zmm, m128 |  | ")]
        vpsrlw_zmm_zmm_m128 = 4445,

        /// <summary>
        /// vpsrlw zmm, zmm, r8 |  | 
        /// </summary>
        [Symbol("vpsrlw zmm, zmm, r8","vpsrlw zmm, zmm, r8 |  | ")]
        vpsrlw_zmm_zmm_r8 = 4446,

        /// <summary>
        /// vpsubb xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpsubb xmm {k1}{z}, xmm, m128","vpsubb xmm {k1}{z}, xmm, m128 |  | ")]
        vpsubb_xmm_k1z_xmm_m128 = 4447,

        /// <summary>
        /// vpsubb xmm {k1}{z}, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpsubb xmm {k1}{z}, xmm, r8","vpsubb xmm {k1}{z}, xmm, r8 |  | ")]
        vpsubb_xmm_k1z_xmm_r8 = 4448,

        /// <summary>
        /// vpsubb xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpsubb xmm, xmm, m128","vpsubb xmm, xmm, m128 |  | ")]
        vpsubb_xmm_xmm_m128 = 4449,

        /// <summary>
        /// vpsubb xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpsubb xmm, xmm, r8","vpsubb xmm, xmm, r8 |  | ")]
        vpsubb_xmm_xmm_r8 = 4450,

        /// <summary>
        /// vpsubb ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpsubb ymm {k1}{z}, ymm, m256","vpsubb ymm {k1}{z}, ymm, m256 |  | ")]
        vpsubb_ymm_k1z_ymm_m256 = 4451,

        /// <summary>
        /// vpsubb ymm {k1}{z}, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpsubb ymm {k1}{z}, ymm, r16","vpsubb ymm {k1}{z}, ymm, r16 |  | ")]
        vpsubb_ymm_k1z_ymm_r16 = 4452,

        /// <summary>
        /// vpsubb ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpsubb ymm, ymm, m256","vpsubb ymm, ymm, m256 |  | ")]
        vpsubb_ymm_ymm_m256 = 4453,

        /// <summary>
        /// vpsubb ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpsubb ymm, ymm, r16","vpsubb ymm, ymm, r16 |  | ")]
        vpsubb_ymm_ymm_r16 = 4454,

        /// <summary>
        /// vpsubb zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpsubb zmm {k1}{z}, zmm, m512","vpsubb zmm {k1}{z}, zmm, m512 |  | ")]
        vpsubb_zmm_k1z_zmm_m512 = 4455,

        /// <summary>
        /// vpsubb zmm {k1}{z}, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpsubb zmm {k1}{z}, zmm, r32","vpsubb zmm {k1}{z}, zmm, r32 |  | ")]
        vpsubb_zmm_k1z_zmm_r32 = 4456,

        /// <summary>
        /// vpsubb zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpsubb zmm, zmm, m512","vpsubb zmm, zmm, m512 |  | ")]
        vpsubb_zmm_zmm_m512 = 4457,

        /// <summary>
        /// vpsubb zmm, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpsubb zmm, zmm, r32","vpsubb zmm, zmm, r32 |  | ")]
        vpsubb_zmm_zmm_r32 = 4458,

        /// <summary>
        /// vpsubd xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpsubd xmm {k1}{z}, xmm, m128","vpsubd xmm {k1}{z}, xmm, m128 |  | ")]
        vpsubd_xmm_k1z_xmm_m128 = 4459,

        /// <summary>
        /// vpsubd xmm {k1}{z}, xmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpsubd xmm {k1}{z}, xmm, m32bcst","vpsubd xmm {k1}{z}, xmm, m32bcst |  | ")]
        vpsubd_xmm_k1z_xmm_m32bcst = 4460,

        /// <summary>
        /// vpsubd xmm {k1}{z}, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpsubd xmm {k1}{z}, xmm, xmm","vpsubd xmm {k1}{z}, xmm, xmm |  | ")]
        vpsubd_xmm_k1z_xmm_xmm = 4461,

        /// <summary>
        /// vpsubd xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpsubd xmm, xmm, m128","vpsubd xmm, xmm, m128 |  | ")]
        vpsubd_xmm_xmm_m128 = 4462,

        /// <summary>
        /// vpsubd xmm, xmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpsubd xmm, xmm, m32bcst","vpsubd xmm, xmm, m32bcst |  | ")]
        vpsubd_xmm_xmm_m32bcst = 4463,

        /// <summary>
        /// vpsubd xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpsubd xmm, xmm, r8","vpsubd xmm, xmm, r8 |  | ")]
        vpsubd_xmm_xmm_r8 = 4464,

        /// <summary>
        /// vpsubd xmm, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpsubd xmm, xmm, xmm","vpsubd xmm, xmm, xmm |  | ")]
        vpsubd_xmm_xmm_xmm = 4465,

        /// <summary>
        /// vpsubd ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpsubd ymm {k1}{z}, ymm, m256","vpsubd ymm {k1}{z}, ymm, m256 |  | ")]
        vpsubd_ymm_k1z_ymm_m256 = 4466,

        /// <summary>
        /// vpsubd ymm {k1}{z}, ymm, m32bcst |  | 
        /// </summary>
        [Symbol("vpsubd ymm {k1}{z}, ymm, m32bcst","vpsubd ymm {k1}{z}, ymm, m32bcst |  | ")]
        vpsubd_ymm_k1z_ymm_m32bcst = 4467,

        /// <summary>
        /// vpsubd ymm {k1}{z}, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpsubd ymm {k1}{z}, ymm, ymm","vpsubd ymm {k1}{z}, ymm, ymm |  | ")]
        vpsubd_ymm_k1z_ymm_ymm = 4468,

        /// <summary>
        /// vpsubd ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpsubd ymm, ymm, m256","vpsubd ymm, ymm, m256 |  | ")]
        vpsubd_ymm_ymm_m256 = 4469,

        /// <summary>
        /// vpsubd ymm, ymm, m32bcst |  | 
        /// </summary>
        [Symbol("vpsubd ymm, ymm, m32bcst","vpsubd ymm, ymm, m32bcst |  | ")]
        vpsubd_ymm_ymm_m32bcst = 4470,

        /// <summary>
        /// vpsubd ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpsubd ymm, ymm, r16","vpsubd ymm, ymm, r16 |  | ")]
        vpsubd_ymm_ymm_r16 = 4471,

        /// <summary>
        /// vpsubd ymm, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpsubd ymm, ymm, ymm","vpsubd ymm, ymm, ymm |  | ")]
        vpsubd_ymm_ymm_ymm = 4472,

        /// <summary>
        /// vpsubd zmm {k1}{z}, zmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpsubd zmm {k1}{z}, zmm, m32bcst","vpsubd zmm {k1}{z}, zmm, m32bcst |  | ")]
        vpsubd_zmm_k1z_zmm_m32bcst = 4473,

        /// <summary>
        /// vpsubd zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpsubd zmm {k1}{z}, zmm, m512","vpsubd zmm {k1}{z}, zmm, m512 |  | ")]
        vpsubd_zmm_k1z_zmm_m512 = 4474,

        /// <summary>
        /// vpsubd zmm {k1}{z}, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpsubd zmm {k1}{z}, zmm, zmm","vpsubd zmm {k1}{z}, zmm, zmm |  | ")]
        vpsubd_zmm_k1z_zmm_zmm = 4475,

        /// <summary>
        /// vpsubd zmm, zmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpsubd zmm, zmm, m32bcst","vpsubd zmm, zmm, m32bcst |  | ")]
        vpsubd_zmm_zmm_m32bcst = 4476,

        /// <summary>
        /// vpsubd zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpsubd zmm, zmm, m512","vpsubd zmm, zmm, m512 |  | ")]
        vpsubd_zmm_zmm_m512 = 4477,

        /// <summary>
        /// vpsubd zmm, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpsubd zmm, zmm, zmm","vpsubd zmm, zmm, zmm |  | ")]
        vpsubd_zmm_zmm_zmm = 4478,

        /// <summary>
        /// vpsubq xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpsubq xmm {k1}{z}, xmm, m128","vpsubq xmm {k1}{z}, xmm, m128 |  | ")]
        vpsubq_xmm_k1z_xmm_m128 = 4479,

        /// <summary>
        /// vpsubq xmm {k1}{z}, xmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpsubq xmm {k1}{z}, xmm, m64bcst","vpsubq xmm {k1}{z}, xmm, m64bcst |  | ")]
        vpsubq_xmm_k1z_xmm_m64bcst = 4480,

        /// <summary>
        /// vpsubq xmm {k1}{z}, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpsubq xmm {k1}{z}, xmm, xmm","vpsubq xmm {k1}{z}, xmm, xmm |  | ")]
        vpsubq_xmm_k1z_xmm_xmm = 4481,

        /// <summary>
        /// vpsubq xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpsubq xmm, xmm, m128","vpsubq xmm, xmm, m128 |  | ")]
        vpsubq_xmm_xmm_m128 = 4482,

        /// <summary>
        /// vpsubq xmm, xmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpsubq xmm, xmm, m64bcst","vpsubq xmm, xmm, m64bcst |  | ")]
        vpsubq_xmm_xmm_m64bcst = 4483,

        /// <summary>
        /// vpsubq xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpsubq xmm, xmm, r8","vpsubq xmm, xmm, r8 |  | ")]
        vpsubq_xmm_xmm_r8 = 4484,

        /// <summary>
        /// vpsubq xmm, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpsubq xmm, xmm, xmm","vpsubq xmm, xmm, xmm |  | ")]
        vpsubq_xmm_xmm_xmm = 4485,

        /// <summary>
        /// vpsubq ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpsubq ymm {k1}{z}, ymm, m256","vpsubq ymm {k1}{z}, ymm, m256 |  | ")]
        vpsubq_ymm_k1z_ymm_m256 = 4486,

        /// <summary>
        /// vpsubq ymm {k1}{z}, ymm, m64bcst |  | 
        /// </summary>
        [Symbol("vpsubq ymm {k1}{z}, ymm, m64bcst","vpsubq ymm {k1}{z}, ymm, m64bcst |  | ")]
        vpsubq_ymm_k1z_ymm_m64bcst = 4487,

        /// <summary>
        /// vpsubq ymm {k1}{z}, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpsubq ymm {k1}{z}, ymm, ymm","vpsubq ymm {k1}{z}, ymm, ymm |  | ")]
        vpsubq_ymm_k1z_ymm_ymm = 4488,

        /// <summary>
        /// vpsubq ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpsubq ymm, ymm, m256","vpsubq ymm, ymm, m256 |  | ")]
        vpsubq_ymm_ymm_m256 = 4489,

        /// <summary>
        /// vpsubq ymm, ymm, m64bcst |  | 
        /// </summary>
        [Symbol("vpsubq ymm, ymm, m64bcst","vpsubq ymm, ymm, m64bcst |  | ")]
        vpsubq_ymm_ymm_m64bcst = 4490,

        /// <summary>
        /// vpsubq ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpsubq ymm, ymm, r16","vpsubq ymm, ymm, r16 |  | ")]
        vpsubq_ymm_ymm_r16 = 4491,

        /// <summary>
        /// vpsubq ymm, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpsubq ymm, ymm, ymm","vpsubq ymm, ymm, ymm |  | ")]
        vpsubq_ymm_ymm_ymm = 4492,

        /// <summary>
        /// vpsubq zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpsubq zmm {k1}{z}, zmm, m512","vpsubq zmm {k1}{z}, zmm, m512 |  | ")]
        vpsubq_zmm_k1z_zmm_m512 = 4493,

        /// <summary>
        /// vpsubq zmm {k1}{z}, zmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpsubq zmm {k1}{z}, zmm, m64bcst","vpsubq zmm {k1}{z}, zmm, m64bcst |  | ")]
        vpsubq_zmm_k1z_zmm_m64bcst = 4494,

        /// <summary>
        /// vpsubq zmm {k1}{z}, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpsubq zmm {k1}{z}, zmm, zmm","vpsubq zmm {k1}{z}, zmm, zmm |  | ")]
        vpsubq_zmm_k1z_zmm_zmm = 4495,

        /// <summary>
        /// vpsubq zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpsubq zmm, zmm, m512","vpsubq zmm, zmm, m512 |  | ")]
        vpsubq_zmm_zmm_m512 = 4496,

        /// <summary>
        /// vpsubq zmm, zmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpsubq zmm, zmm, m64bcst","vpsubq zmm, zmm, m64bcst |  | ")]
        vpsubq_zmm_zmm_m64bcst = 4497,

        /// <summary>
        /// vpsubq zmm, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpsubq zmm, zmm, zmm","vpsubq zmm, zmm, zmm |  | ")]
        vpsubq_zmm_zmm_zmm = 4498,

        /// <summary>
        /// vpsubsb xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpsubsb xmm {k1}{z}, xmm, m128","vpsubsb xmm {k1}{z}, xmm, m128 |  | ")]
        vpsubsb_xmm_k1z_xmm_m128 = 4499,

        /// <summary>
        /// vpsubsb xmm {k1}{z}, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpsubsb xmm {k1}{z}, xmm, r8","vpsubsb xmm {k1}{z}, xmm, r8 |  | ")]
        vpsubsb_xmm_k1z_xmm_r8 = 4500,

        /// <summary>
        /// vpsubsb xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpsubsb xmm, xmm, m128","vpsubsb xmm, xmm, m128 |  | ")]
        vpsubsb_xmm_xmm_m128 = 4501,

        /// <summary>
        /// vpsubsb xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpsubsb xmm, xmm, r8","vpsubsb xmm, xmm, r8 |  | ")]
        vpsubsb_xmm_xmm_r8 = 4502,

        /// <summary>
        /// vpsubsb ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpsubsb ymm {k1}{z}, ymm, m256","vpsubsb ymm {k1}{z}, ymm, m256 |  | ")]
        vpsubsb_ymm_k1z_ymm_m256 = 4503,

        /// <summary>
        /// vpsubsb ymm {k1}{z}, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpsubsb ymm {k1}{z}, ymm, r16","vpsubsb ymm {k1}{z}, ymm, r16 |  | ")]
        vpsubsb_ymm_k1z_ymm_r16 = 4504,

        /// <summary>
        /// vpsubsb ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpsubsb ymm, ymm, m256","vpsubsb ymm, ymm, m256 |  | ")]
        vpsubsb_ymm_ymm_m256 = 4505,

        /// <summary>
        /// vpsubsb ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpsubsb ymm, ymm, r16","vpsubsb ymm, ymm, r16 |  | ")]
        vpsubsb_ymm_ymm_r16 = 4506,

        /// <summary>
        /// vpsubsb zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpsubsb zmm {k1}{z}, zmm, m512","vpsubsb zmm {k1}{z}, zmm, m512 |  | ")]
        vpsubsb_zmm_k1z_zmm_m512 = 4507,

        /// <summary>
        /// vpsubsb zmm {k1}{z}, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpsubsb zmm {k1}{z}, zmm, r32","vpsubsb zmm {k1}{z}, zmm, r32 |  | ")]
        vpsubsb_zmm_k1z_zmm_r32 = 4508,

        /// <summary>
        /// vpsubsb zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpsubsb zmm, zmm, m512","vpsubsb zmm, zmm, m512 |  | ")]
        vpsubsb_zmm_zmm_m512 = 4509,

        /// <summary>
        /// vpsubsb zmm, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpsubsb zmm, zmm, r32","vpsubsb zmm, zmm, r32 |  | ")]
        vpsubsb_zmm_zmm_r32 = 4510,

        /// <summary>
        /// vpsubsw xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpsubsw xmm {k1}{z}, xmm, m128","vpsubsw xmm {k1}{z}, xmm, m128 |  | ")]
        vpsubsw_xmm_k1z_xmm_m128 = 4511,

        /// <summary>
        /// vpsubsw xmm {k1}{z}, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpsubsw xmm {k1}{z}, xmm, r8","vpsubsw xmm {k1}{z}, xmm, r8 |  | ")]
        vpsubsw_xmm_k1z_xmm_r8 = 4512,

        /// <summary>
        /// vpsubsw xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpsubsw xmm, xmm, m128","vpsubsw xmm, xmm, m128 |  | ")]
        vpsubsw_xmm_xmm_m128 = 4513,

        /// <summary>
        /// vpsubsw xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpsubsw xmm, xmm, r8","vpsubsw xmm, xmm, r8 |  | ")]
        vpsubsw_xmm_xmm_r8 = 4514,

        /// <summary>
        /// vpsubsw ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpsubsw ymm {k1}{z}, ymm, m256","vpsubsw ymm {k1}{z}, ymm, m256 |  | ")]
        vpsubsw_ymm_k1z_ymm_m256 = 4515,

        /// <summary>
        /// vpsubsw ymm {k1}{z}, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpsubsw ymm {k1}{z}, ymm, r16","vpsubsw ymm {k1}{z}, ymm, r16 |  | ")]
        vpsubsw_ymm_k1z_ymm_r16 = 4516,

        /// <summary>
        /// vpsubsw ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpsubsw ymm, ymm, m256","vpsubsw ymm, ymm, m256 |  | ")]
        vpsubsw_ymm_ymm_m256 = 4517,

        /// <summary>
        /// vpsubsw ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpsubsw ymm, ymm, r16","vpsubsw ymm, ymm, r16 |  | ")]
        vpsubsw_ymm_ymm_r16 = 4518,

        /// <summary>
        /// vpsubusb xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpsubusb xmm {k1}{z}, xmm, m128","vpsubusb xmm {k1}{z}, xmm, m128 |  | ")]
        vpsubusb_xmm_k1z_xmm_m128 = 4519,

        /// <summary>
        /// vpsubusb xmm {k1}{z}, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpsubusb xmm {k1}{z}, xmm, r8","vpsubusb xmm {k1}{z}, xmm, r8 |  | ")]
        vpsubusb_xmm_k1z_xmm_r8 = 4520,

        /// <summary>
        /// vpsubusb xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpsubusb xmm, xmm, m128","vpsubusb xmm, xmm, m128 |  | ")]
        vpsubusb_xmm_xmm_m128 = 4521,

        /// <summary>
        /// vpsubusb xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpsubusb xmm, xmm, r8","vpsubusb xmm, xmm, r8 |  | ")]
        vpsubusb_xmm_xmm_r8 = 4522,

        /// <summary>
        /// vpsubusb ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpsubusb ymm {k1}{z}, ymm, m256","vpsubusb ymm {k1}{z}, ymm, m256 |  | ")]
        vpsubusb_ymm_k1z_ymm_m256 = 4523,

        /// <summary>
        /// vpsubusb ymm {k1}{z}, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpsubusb ymm {k1}{z}, ymm, r16","vpsubusb ymm {k1}{z}, ymm, r16 |  | ")]
        vpsubusb_ymm_k1z_ymm_r16 = 4524,

        /// <summary>
        /// vpsubusb ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpsubusb ymm, ymm, m256","vpsubusb ymm, ymm, m256 |  | ")]
        vpsubusb_ymm_ymm_m256 = 4525,

        /// <summary>
        /// vpsubusb ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpsubusb ymm, ymm, r16","vpsubusb ymm, ymm, r16 |  | ")]
        vpsubusb_ymm_ymm_r16 = 4526,

        /// <summary>
        /// vpsubusb zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpsubusb zmm {k1}{z}, zmm, m512","vpsubusb zmm {k1}{z}, zmm, m512 |  | ")]
        vpsubusb_zmm_k1z_zmm_m512 = 4527,

        /// <summary>
        /// vpsubusb zmm {k1}{z}, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpsubusb zmm {k1}{z}, zmm, r32","vpsubusb zmm {k1}{z}, zmm, r32 |  | ")]
        vpsubusb_zmm_k1z_zmm_r32 = 4528,

        /// <summary>
        /// vpsubusb zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpsubusb zmm, zmm, m512","vpsubusb zmm, zmm, m512 |  | ")]
        vpsubusb_zmm_zmm_m512 = 4529,

        /// <summary>
        /// vpsubusb zmm, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpsubusb zmm, zmm, r32","vpsubusb zmm, zmm, r32 |  | ")]
        vpsubusb_zmm_zmm_r32 = 4530,

        /// <summary>
        /// vpsubusw xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpsubusw xmm {k1}{z}, xmm, m128","vpsubusw xmm {k1}{z}, xmm, m128 |  | ")]
        vpsubusw_xmm_k1z_xmm_m128 = 4531,

        /// <summary>
        /// vpsubusw xmm {k1}{z}, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpsubusw xmm {k1}{z}, xmm, r8","vpsubusw xmm {k1}{z}, xmm, r8 |  | ")]
        vpsubusw_xmm_k1z_xmm_r8 = 4532,

        /// <summary>
        /// vpsubusw xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpsubusw xmm, xmm, m128","vpsubusw xmm, xmm, m128 |  | ")]
        vpsubusw_xmm_xmm_m128 = 4533,

        /// <summary>
        /// vpsubusw xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpsubusw xmm, xmm, r8","vpsubusw xmm, xmm, r8 |  | ")]
        vpsubusw_xmm_xmm_r8 = 4534,

        /// <summary>
        /// vpsubusw ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpsubusw ymm {k1}{z}, ymm, m256","vpsubusw ymm {k1}{z}, ymm, m256 |  | ")]
        vpsubusw_ymm_k1z_ymm_m256 = 4535,

        /// <summary>
        /// vpsubusw ymm {k1}{z}, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpsubusw ymm {k1}{z}, ymm, r16","vpsubusw ymm {k1}{z}, ymm, r16 |  | ")]
        vpsubusw_ymm_k1z_ymm_r16 = 4536,

        /// <summary>
        /// vpsubusw ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpsubusw ymm, ymm, m256","vpsubusw ymm, ymm, m256 |  | ")]
        vpsubusw_ymm_ymm_m256 = 4537,

        /// <summary>
        /// vpsubusw ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpsubusw ymm, ymm, r16","vpsubusw ymm, ymm, r16 |  | ")]
        vpsubusw_ymm_ymm_r16 = 4538,

        /// <summary>
        /// vpsubw xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpsubw xmm {k1}{z}, xmm, m128","vpsubw xmm {k1}{z}, xmm, m128 |  | ")]
        vpsubw_xmm_k1z_xmm_m128 = 4539,

        /// <summary>
        /// vpsubw xmm {k1}{z}, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpsubw xmm {k1}{z}, xmm, r8","vpsubw xmm {k1}{z}, xmm, r8 |  | ")]
        vpsubw_xmm_k1z_xmm_r8 = 4540,

        /// <summary>
        /// vpsubw xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpsubw xmm, xmm, m128","vpsubw xmm, xmm, m128 |  | ")]
        vpsubw_xmm_xmm_m128 = 4541,

        /// <summary>
        /// vpsubw xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpsubw xmm, xmm, r8","vpsubw xmm, xmm, r8 |  | ")]
        vpsubw_xmm_xmm_r8 = 4542,

        /// <summary>
        /// vpsubw ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpsubw ymm {k1}{z}, ymm, m256","vpsubw ymm {k1}{z}, ymm, m256 |  | ")]
        vpsubw_ymm_k1z_ymm_m256 = 4543,

        /// <summary>
        /// vpsubw ymm {k1}{z}, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpsubw ymm {k1}{z}, ymm, r16","vpsubw ymm {k1}{z}, ymm, r16 |  | ")]
        vpsubw_ymm_k1z_ymm_r16 = 4544,

        /// <summary>
        /// vpsubw ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpsubw ymm, ymm, m256","vpsubw ymm, ymm, m256 |  | ")]
        vpsubw_ymm_ymm_m256 = 4545,

        /// <summary>
        /// vpsubw ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpsubw ymm, ymm, r16","vpsubw ymm, ymm, r16 |  | ")]
        vpsubw_ymm_ymm_r16 = 4546,

        /// <summary>
        /// vpsubw zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpsubw zmm {k1}{z}, zmm, m512","vpsubw zmm {k1}{z}, zmm, m512 |  | ")]
        vpsubw_zmm_k1z_zmm_m512 = 4547,

        /// <summary>
        /// vpsubw zmm {k1}{z}, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpsubw zmm {k1}{z}, zmm, r32","vpsubw zmm {k1}{z}, zmm, r32 |  | ")]
        vpsubw_zmm_k1z_zmm_r32 = 4548,

        /// <summary>
        /// vpsubw zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpsubw zmm, zmm, m512","vpsubw zmm, zmm, m512 |  | ")]
        vpsubw_zmm_zmm_m512 = 4549,

        /// <summary>
        /// vpsubw zmm, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpsubw zmm, zmm, r32","vpsubw zmm, zmm, r32 |  | ")]
        vpsubw_zmm_zmm_r32 = 4550,

        /// <summary>
        /// vpternlogd xmm {k1}{z}, xmm, m128, imm8 |  | 
        /// </summary>
        [Symbol("vpternlogd xmm {k1}{z}, xmm, m128, imm8","vpternlogd xmm {k1}{z}, xmm, m128, imm8 |  | ")]
        vpternlogd_xmm_k1z_xmm_m128_imm8 = 4551,

        /// <summary>
        /// vpternlogd xmm {k1}{z}, xmm, m32bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpternlogd xmm {k1}{z}, xmm, m32bcst, imm8","vpternlogd xmm {k1}{z}, xmm, m32bcst, imm8 |  | ")]
        vpternlogd_xmm_k1z_xmm_m32bcst_imm8 = 4552,

        /// <summary>
        /// vpternlogd xmm {k1}{z}, xmm, xmm, imm8 |  | 
        /// </summary>
        [Symbol("vpternlogd xmm {k1}{z}, xmm, xmm, imm8","vpternlogd xmm {k1}{z}, xmm, xmm, imm8 |  | ")]
        vpternlogd_xmm_k1z_xmm_xmm_imm8 = 4553,

        /// <summary>
        /// vpternlogd xmm, xmm, m128, imm8 |  | 
        /// </summary>
        [Symbol("vpternlogd xmm, xmm, m128, imm8","vpternlogd xmm, xmm, m128, imm8 |  | ")]
        vpternlogd_xmm_xmm_m128_imm8 = 4554,

        /// <summary>
        /// vpternlogd xmm, xmm, m32bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpternlogd xmm, xmm, m32bcst, imm8","vpternlogd xmm, xmm, m32bcst, imm8 |  | ")]
        vpternlogd_xmm_xmm_m32bcst_imm8 = 4555,

        /// <summary>
        /// vpternlogd xmm, xmm, xmm, imm8 |  | 
        /// </summary>
        [Symbol("vpternlogd xmm, xmm, xmm, imm8","vpternlogd xmm, xmm, xmm, imm8 |  | ")]
        vpternlogd_xmm_xmm_xmm_imm8 = 4556,

        /// <summary>
        /// vpternlogd ymm {k1}{z}, ymm, m256, imm8 |  | 
        /// </summary>
        [Symbol("vpternlogd ymm {k1}{z}, ymm, m256, imm8","vpternlogd ymm {k1}{z}, ymm, m256, imm8 |  | ")]
        vpternlogd_ymm_k1z_ymm_m256_imm8 = 4557,

        /// <summary>
        /// vpternlogd ymm {k1}{z}, ymm, m32bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpternlogd ymm {k1}{z}, ymm, m32bcst, imm8","vpternlogd ymm {k1}{z}, ymm, m32bcst, imm8 |  | ")]
        vpternlogd_ymm_k1z_ymm_m32bcst_imm8 = 4558,

        /// <summary>
        /// vpternlogd ymm {k1}{z}, ymm, ymm, imm8 |  | 
        /// </summary>
        [Symbol("vpternlogd ymm {k1}{z}, ymm, ymm, imm8","vpternlogd ymm {k1}{z}, ymm, ymm, imm8 |  | ")]
        vpternlogd_ymm_k1z_ymm_ymm_imm8 = 4559,

        /// <summary>
        /// vpternlogd ymm, ymm, m256, imm8 |  | 
        /// </summary>
        [Symbol("vpternlogd ymm, ymm, m256, imm8","vpternlogd ymm, ymm, m256, imm8 |  | ")]
        vpternlogd_ymm_ymm_m256_imm8 = 4560,

        /// <summary>
        /// vpternlogd ymm, ymm, m32bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpternlogd ymm, ymm, m32bcst, imm8","vpternlogd ymm, ymm, m32bcst, imm8 |  | ")]
        vpternlogd_ymm_ymm_m32bcst_imm8 = 4561,

        /// <summary>
        /// vpternlogd ymm, ymm, ymm, imm8 |  | 
        /// </summary>
        [Symbol("vpternlogd ymm, ymm, ymm, imm8","vpternlogd ymm, ymm, ymm, imm8 |  | ")]
        vpternlogd_ymm_ymm_ymm_imm8 = 4562,

        /// <summary>
        /// vpternlogd zmm {k1}{z}, zmm, m32bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpternlogd zmm {k1}{z}, zmm, m32bcst, imm8","vpternlogd zmm {k1}{z}, zmm, m32bcst, imm8 |  | ")]
        vpternlogd_zmm_k1z_zmm_m32bcst_imm8 = 4563,

        /// <summary>
        /// vpternlogd zmm {k1}{z}, zmm, m512, imm8 |  | 
        /// </summary>
        [Symbol("vpternlogd zmm {k1}{z}, zmm, m512, imm8","vpternlogd zmm {k1}{z}, zmm, m512, imm8 |  | ")]
        vpternlogd_zmm_k1z_zmm_m512_imm8 = 4564,

        /// <summary>
        /// vpternlogd zmm {k1}{z}, zmm, zmm, imm8 |  | 
        /// </summary>
        [Symbol("vpternlogd zmm {k1}{z}, zmm, zmm, imm8","vpternlogd zmm {k1}{z}, zmm, zmm, imm8 |  | ")]
        vpternlogd_zmm_k1z_zmm_zmm_imm8 = 4565,

        /// <summary>
        /// vpternlogd zmm, zmm, m32bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpternlogd zmm, zmm, m32bcst, imm8","vpternlogd zmm, zmm, m32bcst, imm8 |  | ")]
        vpternlogd_zmm_zmm_m32bcst_imm8 = 4566,

        /// <summary>
        /// vpternlogd zmm, zmm, m512, imm8 |  | 
        /// </summary>
        [Symbol("vpternlogd zmm, zmm, m512, imm8","vpternlogd zmm, zmm, m512, imm8 |  | ")]
        vpternlogd_zmm_zmm_m512_imm8 = 4567,

        /// <summary>
        /// vpternlogd zmm, zmm, zmm, imm8 |  | 
        /// </summary>
        [Symbol("vpternlogd zmm, zmm, zmm, imm8","vpternlogd zmm, zmm, zmm, imm8 |  | ")]
        vpternlogd_zmm_zmm_zmm_imm8 = 4568,

        /// <summary>
        /// vpternlogq xmm {k1}{z}, xmm, m128, imm8 |  | 
        /// </summary>
        [Symbol("vpternlogq xmm {k1}{z}, xmm, m128, imm8","vpternlogq xmm {k1}{z}, xmm, m128, imm8 |  | ")]
        vpternlogq_xmm_k1z_xmm_m128_imm8 = 4569,

        /// <summary>
        /// vpternlogq xmm {k1}{z}, xmm, m64bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpternlogq xmm {k1}{z}, xmm, m64bcst, imm8","vpternlogq xmm {k1}{z}, xmm, m64bcst, imm8 |  | ")]
        vpternlogq_xmm_k1z_xmm_m64bcst_imm8 = 4570,

        /// <summary>
        /// vpternlogq xmm {k1}{z}, xmm, xmm, imm8 |  | 
        /// </summary>
        [Symbol("vpternlogq xmm {k1}{z}, xmm, xmm, imm8","vpternlogq xmm {k1}{z}, xmm, xmm, imm8 |  | ")]
        vpternlogq_xmm_k1z_xmm_xmm_imm8 = 4571,

        /// <summary>
        /// vpternlogq xmm, xmm, m128, imm8 |  | 
        /// </summary>
        [Symbol("vpternlogq xmm, xmm, m128, imm8","vpternlogq xmm, xmm, m128, imm8 |  | ")]
        vpternlogq_xmm_xmm_m128_imm8 = 4572,

        /// <summary>
        /// vpternlogq xmm, xmm, m64bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpternlogq xmm, xmm, m64bcst, imm8","vpternlogq xmm, xmm, m64bcst, imm8 |  | ")]
        vpternlogq_xmm_xmm_m64bcst_imm8 = 4573,

        /// <summary>
        /// vpternlogq xmm, xmm, xmm, imm8 |  | 
        /// </summary>
        [Symbol("vpternlogq xmm, xmm, xmm, imm8","vpternlogq xmm, xmm, xmm, imm8 |  | ")]
        vpternlogq_xmm_xmm_xmm_imm8 = 4574,

        /// <summary>
        /// vpternlogq ymm {k1}{z}, ymm, m256, imm8 |  | 
        /// </summary>
        [Symbol("vpternlogq ymm {k1}{z}, ymm, m256, imm8","vpternlogq ymm {k1}{z}, ymm, m256, imm8 |  | ")]
        vpternlogq_ymm_k1z_ymm_m256_imm8 = 4575,

        /// <summary>
        /// vpternlogq ymm {k1}{z}, ymm, m64bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpternlogq ymm {k1}{z}, ymm, m64bcst, imm8","vpternlogq ymm {k1}{z}, ymm, m64bcst, imm8 |  | ")]
        vpternlogq_ymm_k1z_ymm_m64bcst_imm8 = 4576,

        /// <summary>
        /// vpternlogq ymm {k1}{z}, ymm, ymm, imm8 |  | 
        /// </summary>
        [Symbol("vpternlogq ymm {k1}{z}, ymm, ymm, imm8","vpternlogq ymm {k1}{z}, ymm, ymm, imm8 |  | ")]
        vpternlogq_ymm_k1z_ymm_ymm_imm8 = 4577,

        /// <summary>
        /// vpternlogq ymm, ymm, m256, imm8 |  | 
        /// </summary>
        [Symbol("vpternlogq ymm, ymm, m256, imm8","vpternlogq ymm, ymm, m256, imm8 |  | ")]
        vpternlogq_ymm_ymm_m256_imm8 = 4578,

        /// <summary>
        /// vpternlogq ymm, ymm, m64bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpternlogq ymm, ymm, m64bcst, imm8","vpternlogq ymm, ymm, m64bcst, imm8 |  | ")]
        vpternlogq_ymm_ymm_m64bcst_imm8 = 4579,

        /// <summary>
        /// vpternlogq ymm, ymm, ymm, imm8 |  | 
        /// </summary>
        [Symbol("vpternlogq ymm, ymm, ymm, imm8","vpternlogq ymm, ymm, ymm, imm8 |  | ")]
        vpternlogq_ymm_ymm_ymm_imm8 = 4580,

        /// <summary>
        /// vpternlogq zmm {k1}{z}, zmm, m512, imm8 |  | 
        /// </summary>
        [Symbol("vpternlogq zmm {k1}{z}, zmm, m512, imm8","vpternlogq zmm {k1}{z}, zmm, m512, imm8 |  | ")]
        vpternlogq_zmm_k1z_zmm_m512_imm8 = 4581,

        /// <summary>
        /// vpternlogq zmm {k1}{z}, zmm, m64bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpternlogq zmm {k1}{z}, zmm, m64bcst, imm8","vpternlogq zmm {k1}{z}, zmm, m64bcst, imm8 |  | ")]
        vpternlogq_zmm_k1z_zmm_m64bcst_imm8 = 4582,

        /// <summary>
        /// vpternlogq zmm {k1}{z}, zmm, zmm, imm8 |  | 
        /// </summary>
        [Symbol("vpternlogq zmm {k1}{z}, zmm, zmm, imm8","vpternlogq zmm {k1}{z}, zmm, zmm, imm8 |  | ")]
        vpternlogq_zmm_k1z_zmm_zmm_imm8 = 4583,

        /// <summary>
        /// vpternlogq zmm, zmm, m512, imm8 |  | 
        /// </summary>
        [Symbol("vpternlogq zmm, zmm, m512, imm8","vpternlogq zmm, zmm, m512, imm8 |  | ")]
        vpternlogq_zmm_zmm_m512_imm8 = 4584,

        /// <summary>
        /// vpternlogq zmm, zmm, m64bcst, imm8 |  | 
        /// </summary>
        [Symbol("vpternlogq zmm, zmm, m64bcst, imm8","vpternlogq zmm, zmm, m64bcst, imm8 |  | ")]
        vpternlogq_zmm_zmm_m64bcst_imm8 = 4585,

        /// <summary>
        /// vpternlogq zmm, zmm, zmm, imm8 |  | 
        /// </summary>
        [Symbol("vpternlogq zmm, zmm, zmm, imm8","vpternlogq zmm, zmm, zmm, imm8 |  | ")]
        vpternlogq_zmm_zmm_zmm_imm8 = 4586,

        /// <summary>
        /// vptest xmm, m128 |  | 
        /// </summary>
        [Symbol("vptest xmm, m128","vptest xmm, m128 |  | ")]
        vptest_xmm_m128 = 4587,

        /// <summary>
        /// vptest xmm, r8 |  | 
        /// </summary>
        [Symbol("vptest xmm, r8","vptest xmm, r8 |  | ")]
        vptest_xmm_r8 = 4588,

        /// <summary>
        /// vptest ymm, m256 |  | 
        /// </summary>
        [Symbol("vptest ymm, m256","vptest ymm, m256 |  | ")]
        vptest_ymm_m256 = 4589,

        /// <summary>
        /// vptest ymm, r16 |  | 
        /// </summary>
        [Symbol("vptest ymm, r16","vptest ymm, r16 |  | ")]
        vptest_ymm_r16 = 4590,

        /// <summary>
        /// vptestmb k2 {k1}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vptestmb k2 {k1}, xmm, m128","vptestmb k2 {k1}, xmm, m128 |  | ")]
        vptestmb_k2_k1_xmm_m128 = 4591,

        /// <summary>
        /// vptestmb k2 {k1}, xmm, r8 |  | 
        /// </summary>
        [Symbol("vptestmb k2 {k1}, xmm, r8","vptestmb k2 {k1}, xmm, r8 |  | ")]
        vptestmb_k2_k1_xmm_r8 = 4592,

        /// <summary>
        /// vptestmb k2 {k1}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vptestmb k2 {k1}, ymm, m256","vptestmb k2 {k1}, ymm, m256 |  | ")]
        vptestmb_k2_k1_ymm_m256 = 4593,

        /// <summary>
        /// vptestmb k2 {k1}, ymm, r16 |  | 
        /// </summary>
        [Symbol("vptestmb k2 {k1}, ymm, r16","vptestmb k2 {k1}, ymm, r16 |  | ")]
        vptestmb_k2_k1_ymm_r16 = 4594,

        /// <summary>
        /// vptestmb k2 {k1}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vptestmb k2 {k1}, zmm, m512","vptestmb k2 {k1}, zmm, m512 |  | ")]
        vptestmb_k2_k1_zmm_m512 = 4595,

        /// <summary>
        /// vptestmb k2 {k1}, zmm, r32 |  | 
        /// </summary>
        [Symbol("vptestmb k2 {k1}, zmm, r32","vptestmb k2 {k1}, zmm, r32 |  | ")]
        vptestmb_k2_k1_zmm_r32 = 4596,

        /// <summary>
        /// vptestmb k2, xmm, m128 |  | 
        /// </summary>
        [Symbol("vptestmb k2, xmm, m128","vptestmb k2, xmm, m128 |  | ")]
        vptestmb_k2_xmm_m128 = 4597,

        /// <summary>
        /// vptestmb k2, xmm, r8 |  | 
        /// </summary>
        [Symbol("vptestmb k2, xmm, r8","vptestmb k2, xmm, r8 |  | ")]
        vptestmb_k2_xmm_r8 = 4598,

        /// <summary>
        /// vptestmb k2, ymm, m256 |  | 
        /// </summary>
        [Symbol("vptestmb k2, ymm, m256","vptestmb k2, ymm, m256 |  | ")]
        vptestmb_k2_ymm_m256 = 4599,

        /// <summary>
        /// vptestmb k2, ymm, r16 |  | 
        /// </summary>
        [Symbol("vptestmb k2, ymm, r16","vptestmb k2, ymm, r16 |  | ")]
        vptestmb_k2_ymm_r16 = 4600,

        /// <summary>
        /// vptestmb k2, zmm, m512 |  | 
        /// </summary>
        [Symbol("vptestmb k2, zmm, m512","vptestmb k2, zmm, m512 |  | ")]
        vptestmb_k2_zmm_m512 = 4601,

        /// <summary>
        /// vptestmb k2, zmm, r32 |  | 
        /// </summary>
        [Symbol("vptestmb k2, zmm, r32","vptestmb k2, zmm, r32 |  | ")]
        vptestmb_k2_zmm_r32 = 4602,

        /// <summary>
        /// vptestmd k2 {k1}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vptestmd k2 {k1}, xmm, m128","vptestmd k2 {k1}, xmm, m128 |  | ")]
        vptestmd_k2_k1_xmm_m128 = 4603,

        /// <summary>
        /// vptestmd k2 {k1}, xmm, m32bcst |  | 
        /// </summary>
        [Symbol("vptestmd k2 {k1}, xmm, m32bcst","vptestmd k2 {k1}, xmm, m32bcst |  | ")]
        vptestmd_k2_k1_xmm_m32bcst = 4604,

        /// <summary>
        /// vptestmd k2 {k1}, xmm, xmm |  | 
        /// </summary>
        [Symbol("vptestmd k2 {k1}, xmm, xmm","vptestmd k2 {k1}, xmm, xmm |  | ")]
        vptestmd_k2_k1_xmm_xmm = 4605,

        /// <summary>
        /// vptestmd k2 {k1}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vptestmd k2 {k1}, ymm, m256","vptestmd k2 {k1}, ymm, m256 |  | ")]
        vptestmd_k2_k1_ymm_m256 = 4606,

        /// <summary>
        /// vptestmd k2 {k1}, ymm, m32bcst |  | 
        /// </summary>
        [Symbol("vptestmd k2 {k1}, ymm, m32bcst","vptestmd k2 {k1}, ymm, m32bcst |  | ")]
        vptestmd_k2_k1_ymm_m32bcst = 4607,

        /// <summary>
        /// vptestmd k2 {k1}, ymm, ymm |  | 
        /// </summary>
        [Symbol("vptestmd k2 {k1}, ymm, ymm","vptestmd k2 {k1}, ymm, ymm |  | ")]
        vptestmd_k2_k1_ymm_ymm = 4608,

        /// <summary>
        /// vptestmd k2 {k1}, zmm, m32bcst |  | 
        /// </summary>
        [Symbol("vptestmd k2 {k1}, zmm, m32bcst","vptestmd k2 {k1}, zmm, m32bcst |  | ")]
        vptestmd_k2_k1_zmm_m32bcst = 4609,

        /// <summary>
        /// vptestmd k2 {k1}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vptestmd k2 {k1}, zmm, m512","vptestmd k2 {k1}, zmm, m512 |  | ")]
        vptestmd_k2_k1_zmm_m512 = 4610,

        /// <summary>
        /// vptestmd k2 {k1}, zmm, zmm |  | 
        /// </summary>
        [Symbol("vptestmd k2 {k1}, zmm, zmm","vptestmd k2 {k1}, zmm, zmm |  | ")]
        vptestmd_k2_k1_zmm_zmm = 4611,

        /// <summary>
        /// vptestmd k2, xmm, m128 |  | 
        /// </summary>
        [Symbol("vptestmd k2, xmm, m128","vptestmd k2, xmm, m128 |  | ")]
        vptestmd_k2_xmm_m128 = 4612,

        /// <summary>
        /// vptestmd k2, xmm, m32bcst |  | 
        /// </summary>
        [Symbol("vptestmd k2, xmm, m32bcst","vptestmd k2, xmm, m32bcst |  | ")]
        vptestmd_k2_xmm_m32bcst = 4613,

        /// <summary>
        /// vptestmd k2, xmm, xmm |  | 
        /// </summary>
        [Symbol("vptestmd k2, xmm, xmm","vptestmd k2, xmm, xmm |  | ")]
        vptestmd_k2_xmm_xmm = 4614,

        /// <summary>
        /// vptestmd k2, ymm, m256 |  | 
        /// </summary>
        [Symbol("vptestmd k2, ymm, m256","vptestmd k2, ymm, m256 |  | ")]
        vptestmd_k2_ymm_m256 = 4615,

        /// <summary>
        /// vptestmd k2, ymm, m32bcst |  | 
        /// </summary>
        [Symbol("vptestmd k2, ymm, m32bcst","vptestmd k2, ymm, m32bcst |  | ")]
        vptestmd_k2_ymm_m32bcst = 4616,

        /// <summary>
        /// vptestmd k2, ymm, ymm |  | 
        /// </summary>
        [Symbol("vptestmd k2, ymm, ymm","vptestmd k2, ymm, ymm |  | ")]
        vptestmd_k2_ymm_ymm = 4617,

        /// <summary>
        /// vptestmd k2, zmm, m32bcst |  | 
        /// </summary>
        [Symbol("vptestmd k2, zmm, m32bcst","vptestmd k2, zmm, m32bcst |  | ")]
        vptestmd_k2_zmm_m32bcst = 4618,

        /// <summary>
        /// vptestmd k2, zmm, m512 |  | 
        /// </summary>
        [Symbol("vptestmd k2, zmm, m512","vptestmd k2, zmm, m512 |  | ")]
        vptestmd_k2_zmm_m512 = 4619,

        /// <summary>
        /// vptestmd k2, zmm, zmm |  | 
        /// </summary>
        [Symbol("vptestmd k2, zmm, zmm","vptestmd k2, zmm, zmm |  | ")]
        vptestmd_k2_zmm_zmm = 4620,

        /// <summary>
        /// vptestmq k2 {k1}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vptestmq k2 {k1}, xmm, m128","vptestmq k2 {k1}, xmm, m128 |  | ")]
        vptestmq_k2_k1_xmm_m128 = 4621,

        /// <summary>
        /// vptestmq k2 {k1}, xmm, m64bcst |  | 
        /// </summary>
        [Symbol("vptestmq k2 {k1}, xmm, m64bcst","vptestmq k2 {k1}, xmm, m64bcst |  | ")]
        vptestmq_k2_k1_xmm_m64bcst = 4622,

        /// <summary>
        /// vptestmq k2 {k1}, xmm, xmm |  | 
        /// </summary>
        [Symbol("vptestmq k2 {k1}, xmm, xmm","vptestmq k2 {k1}, xmm, xmm |  | ")]
        vptestmq_k2_k1_xmm_xmm = 4623,

        /// <summary>
        /// vptestmq k2 {k1}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vptestmq k2 {k1}, ymm, m256","vptestmq k2 {k1}, ymm, m256 |  | ")]
        vptestmq_k2_k1_ymm_m256 = 4624,

        /// <summary>
        /// vptestmq k2 {k1}, ymm, m64bcst |  | 
        /// </summary>
        [Symbol("vptestmq k2 {k1}, ymm, m64bcst","vptestmq k2 {k1}, ymm, m64bcst |  | ")]
        vptestmq_k2_k1_ymm_m64bcst = 4625,

        /// <summary>
        /// vptestmq k2 {k1}, ymm, ymm |  | 
        /// </summary>
        [Symbol("vptestmq k2 {k1}, ymm, ymm","vptestmq k2 {k1}, ymm, ymm |  | ")]
        vptestmq_k2_k1_ymm_ymm = 4626,

        /// <summary>
        /// vptestmq k2 {k1}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vptestmq k2 {k1}, zmm, m512","vptestmq k2 {k1}, zmm, m512 |  | ")]
        vptestmq_k2_k1_zmm_m512 = 4627,

        /// <summary>
        /// vptestmq k2 {k1}, zmm, m64bcst |  | 
        /// </summary>
        [Symbol("vptestmq k2 {k1}, zmm, m64bcst","vptestmq k2 {k1}, zmm, m64bcst |  | ")]
        vptestmq_k2_k1_zmm_m64bcst = 4628,

        /// <summary>
        /// vptestmq k2 {k1}, zmm, zmm |  | 
        /// </summary>
        [Symbol("vptestmq k2 {k1}, zmm, zmm","vptestmq k2 {k1}, zmm, zmm |  | ")]
        vptestmq_k2_k1_zmm_zmm = 4629,

        /// <summary>
        /// vptestmq k2, xmm, m128 |  | 
        /// </summary>
        [Symbol("vptestmq k2, xmm, m128","vptestmq k2, xmm, m128 |  | ")]
        vptestmq_k2_xmm_m128 = 4630,

        /// <summary>
        /// vptestmq k2, xmm, m64bcst |  | 
        /// </summary>
        [Symbol("vptestmq k2, xmm, m64bcst","vptestmq k2, xmm, m64bcst |  | ")]
        vptestmq_k2_xmm_m64bcst = 4631,

        /// <summary>
        /// vptestmq k2, xmm, xmm |  | 
        /// </summary>
        [Symbol("vptestmq k2, xmm, xmm","vptestmq k2, xmm, xmm |  | ")]
        vptestmq_k2_xmm_xmm = 4632,

        /// <summary>
        /// vptestmq k2, ymm, m256 |  | 
        /// </summary>
        [Symbol("vptestmq k2, ymm, m256","vptestmq k2, ymm, m256 |  | ")]
        vptestmq_k2_ymm_m256 = 4633,

        /// <summary>
        /// vptestmq k2, ymm, m64bcst |  | 
        /// </summary>
        [Symbol("vptestmq k2, ymm, m64bcst","vptestmq k2, ymm, m64bcst |  | ")]
        vptestmq_k2_ymm_m64bcst = 4634,

        /// <summary>
        /// vptestmq k2, ymm, ymm |  | 
        /// </summary>
        [Symbol("vptestmq k2, ymm, ymm","vptestmq k2, ymm, ymm |  | ")]
        vptestmq_k2_ymm_ymm = 4635,

        /// <summary>
        /// vptestmq k2, zmm, m512 |  | 
        /// </summary>
        [Symbol("vptestmq k2, zmm, m512","vptestmq k2, zmm, m512 |  | ")]
        vptestmq_k2_zmm_m512 = 4636,

        /// <summary>
        /// vptestmq k2, zmm, m64bcst |  | 
        /// </summary>
        [Symbol("vptestmq k2, zmm, m64bcst","vptestmq k2, zmm, m64bcst |  | ")]
        vptestmq_k2_zmm_m64bcst = 4637,

        /// <summary>
        /// vptestmq k2, zmm, zmm |  | 
        /// </summary>
        [Symbol("vptestmq k2, zmm, zmm","vptestmq k2, zmm, zmm |  | ")]
        vptestmq_k2_zmm_zmm = 4638,

        /// <summary>
        /// vptestmw k2 {k1}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vptestmw k2 {k1}, xmm, m128","vptestmw k2 {k1}, xmm, m128 |  | ")]
        vptestmw_k2_k1_xmm_m128 = 4639,

        /// <summary>
        /// vptestmw k2 {k1}, xmm, r8 |  | 
        /// </summary>
        [Symbol("vptestmw k2 {k1}, xmm, r8","vptestmw k2 {k1}, xmm, r8 |  | ")]
        vptestmw_k2_k1_xmm_r8 = 4640,

        /// <summary>
        /// vptestmw k2 {k1}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vptestmw k2 {k1}, ymm, m256","vptestmw k2 {k1}, ymm, m256 |  | ")]
        vptestmw_k2_k1_ymm_m256 = 4641,

        /// <summary>
        /// vptestmw k2 {k1}, ymm, r16 |  | 
        /// </summary>
        [Symbol("vptestmw k2 {k1}, ymm, r16","vptestmw k2 {k1}, ymm, r16 |  | ")]
        vptestmw_k2_k1_ymm_r16 = 4642,

        /// <summary>
        /// vptestmw k2 {k1}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vptestmw k2 {k1}, zmm, m512","vptestmw k2 {k1}, zmm, m512 |  | ")]
        vptestmw_k2_k1_zmm_m512 = 4643,

        /// <summary>
        /// vptestmw k2 {k1}, zmm, r32 |  | 
        /// </summary>
        [Symbol("vptestmw k2 {k1}, zmm, r32","vptestmw k2 {k1}, zmm, r32 |  | ")]
        vptestmw_k2_k1_zmm_r32 = 4644,

        /// <summary>
        /// vptestmw k2, xmm, m128 |  | 
        /// </summary>
        [Symbol("vptestmw k2, xmm, m128","vptestmw k2, xmm, m128 |  | ")]
        vptestmw_k2_xmm_m128 = 4645,

        /// <summary>
        /// vptestmw k2, xmm, r8 |  | 
        /// </summary>
        [Symbol("vptestmw k2, xmm, r8","vptestmw k2, xmm, r8 |  | ")]
        vptestmw_k2_xmm_r8 = 4646,

        /// <summary>
        /// vptestmw k2, ymm, m256 |  | 
        /// </summary>
        [Symbol("vptestmw k2, ymm, m256","vptestmw k2, ymm, m256 |  | ")]
        vptestmw_k2_ymm_m256 = 4647,

        /// <summary>
        /// vptestmw k2, ymm, r16 |  | 
        /// </summary>
        [Symbol("vptestmw k2, ymm, r16","vptestmw k2, ymm, r16 |  | ")]
        vptestmw_k2_ymm_r16 = 4648,

        /// <summary>
        /// vptestmw k2, zmm, m512 |  | 
        /// </summary>
        [Symbol("vptestmw k2, zmm, m512","vptestmw k2, zmm, m512 |  | ")]
        vptestmw_k2_zmm_m512 = 4649,

        /// <summary>
        /// vptestmw k2, zmm, r32 |  | 
        /// </summary>
        [Symbol("vptestmw k2, zmm, r32","vptestmw k2, zmm, r32 |  | ")]
        vptestmw_k2_zmm_r32 = 4650,

        /// <summary>
        /// vptestnmb k2 {k1}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vptestnmb k2 {k1}, xmm, m128","vptestnmb k2 {k1}, xmm, m128 |  | ")]
        vptestnmb_k2_k1_xmm_m128 = 4651,

        /// <summary>
        /// vptestnmb k2 {k1}, xmm, r8 |  | 
        /// </summary>
        [Symbol("vptestnmb k2 {k1}, xmm, r8","vptestnmb k2 {k1}, xmm, r8 |  | ")]
        vptestnmb_k2_k1_xmm_r8 = 4652,

        /// <summary>
        /// vptestnmb k2 {k1}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vptestnmb k2 {k1}, ymm, m256","vptestnmb k2 {k1}, ymm, m256 |  | ")]
        vptestnmb_k2_k1_ymm_m256 = 4653,

        /// <summary>
        /// vptestnmb k2 {k1}, ymm, r16 |  | 
        /// </summary>
        [Symbol("vptestnmb k2 {k1}, ymm, r16","vptestnmb k2 {k1}, ymm, r16 |  | ")]
        vptestnmb_k2_k1_ymm_r16 = 4654,

        /// <summary>
        /// vptestnmb k2 {k1}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vptestnmb k2 {k1}, zmm, m512","vptestnmb k2 {k1}, zmm, m512 |  | ")]
        vptestnmb_k2_k1_zmm_m512 = 4655,

        /// <summary>
        /// vptestnmb k2 {k1}, zmm, r32 |  | 
        /// </summary>
        [Symbol("vptestnmb k2 {k1}, zmm, r32","vptestnmb k2 {k1}, zmm, r32 |  | ")]
        vptestnmb_k2_k1_zmm_r32 = 4656,

        /// <summary>
        /// vptestnmb k2, xmm, m128 |  | 
        /// </summary>
        [Symbol("vptestnmb k2, xmm, m128","vptestnmb k2, xmm, m128 |  | ")]
        vptestnmb_k2_xmm_m128 = 4657,

        /// <summary>
        /// vptestnmb k2, xmm, r8 |  | 
        /// </summary>
        [Symbol("vptestnmb k2, xmm, r8","vptestnmb k2, xmm, r8 |  | ")]
        vptestnmb_k2_xmm_r8 = 4658,

        /// <summary>
        /// vptestnmb k2, ymm, m256 |  | 
        /// </summary>
        [Symbol("vptestnmb k2, ymm, m256","vptestnmb k2, ymm, m256 |  | ")]
        vptestnmb_k2_ymm_m256 = 4659,

        /// <summary>
        /// vptestnmb k2, ymm, r16 |  | 
        /// </summary>
        [Symbol("vptestnmb k2, ymm, r16","vptestnmb k2, ymm, r16 |  | ")]
        vptestnmb_k2_ymm_r16 = 4660,

        /// <summary>
        /// vptestnmb k2, zmm, m512 |  | 
        /// </summary>
        [Symbol("vptestnmb k2, zmm, m512","vptestnmb k2, zmm, m512 |  | ")]
        vptestnmb_k2_zmm_m512 = 4661,

        /// <summary>
        /// vptestnmb k2, zmm, r32 |  | 
        /// </summary>
        [Symbol("vptestnmb k2, zmm, r32","vptestnmb k2, zmm, r32 |  | ")]
        vptestnmb_k2_zmm_r32 = 4662,

        /// <summary>
        /// vptestnmd k2 {k1}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vptestnmd k2 {k1}, xmm, m128","vptestnmd k2 {k1}, xmm, m128 |  | ")]
        vptestnmd_k2_k1_xmm_m128 = 4663,

        /// <summary>
        /// vptestnmd k2 {k1}, xmm, m32bcst |  | 
        /// </summary>
        [Symbol("vptestnmd k2 {k1}, xmm, m32bcst","vptestnmd k2 {k1}, xmm, m32bcst |  | ")]
        vptestnmd_k2_k1_xmm_m32bcst = 4664,

        /// <summary>
        /// vptestnmd k2 {k1}, xmm, xmm |  | 
        /// </summary>
        [Symbol("vptestnmd k2 {k1}, xmm, xmm","vptestnmd k2 {k1}, xmm, xmm |  | ")]
        vptestnmd_k2_k1_xmm_xmm = 4665,

        /// <summary>
        /// vptestnmd k2 {k1}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vptestnmd k2 {k1}, ymm, m256","vptestnmd k2 {k1}, ymm, m256 |  | ")]
        vptestnmd_k2_k1_ymm_m256 = 4666,

        /// <summary>
        /// vptestnmd k2 {k1}, ymm, m32bcst |  | 
        /// </summary>
        [Symbol("vptestnmd k2 {k1}, ymm, m32bcst","vptestnmd k2 {k1}, ymm, m32bcst |  | ")]
        vptestnmd_k2_k1_ymm_m32bcst = 4667,

        /// <summary>
        /// vptestnmd k2 {k1}, ymm, ymm |  | 
        /// </summary>
        [Symbol("vptestnmd k2 {k1}, ymm, ymm","vptestnmd k2 {k1}, ymm, ymm |  | ")]
        vptestnmd_k2_k1_ymm_ymm = 4668,

        /// <summary>
        /// vptestnmd k2 {k1}, zmm, m32bcst |  | 
        /// </summary>
        [Symbol("vptestnmd k2 {k1}, zmm, m32bcst","vptestnmd k2 {k1}, zmm, m32bcst |  | ")]
        vptestnmd_k2_k1_zmm_m32bcst = 4669,

        /// <summary>
        /// vptestnmd k2 {k1}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vptestnmd k2 {k1}, zmm, m512","vptestnmd k2 {k1}, zmm, m512 |  | ")]
        vptestnmd_k2_k1_zmm_m512 = 4670,

        /// <summary>
        /// vptestnmd k2 {k1}, zmm, zmm |  | 
        /// </summary>
        [Symbol("vptestnmd k2 {k1}, zmm, zmm","vptestnmd k2 {k1}, zmm, zmm |  | ")]
        vptestnmd_k2_k1_zmm_zmm = 4671,

        /// <summary>
        /// vptestnmd k2, xmm, m128 |  | 
        /// </summary>
        [Symbol("vptestnmd k2, xmm, m128","vptestnmd k2, xmm, m128 |  | ")]
        vptestnmd_k2_xmm_m128 = 4672,

        /// <summary>
        /// vptestnmd k2, xmm, m32bcst |  | 
        /// </summary>
        [Symbol("vptestnmd k2, xmm, m32bcst","vptestnmd k2, xmm, m32bcst |  | ")]
        vptestnmd_k2_xmm_m32bcst = 4673,

        /// <summary>
        /// vptestnmd k2, xmm, xmm |  | 
        /// </summary>
        [Symbol("vptestnmd k2, xmm, xmm","vptestnmd k2, xmm, xmm |  | ")]
        vptestnmd_k2_xmm_xmm = 4674,

        /// <summary>
        /// vptestnmd k2, ymm, m256 |  | 
        /// </summary>
        [Symbol("vptestnmd k2, ymm, m256","vptestnmd k2, ymm, m256 |  | ")]
        vptestnmd_k2_ymm_m256 = 4675,

        /// <summary>
        /// vptestnmd k2, ymm, m32bcst |  | 
        /// </summary>
        [Symbol("vptestnmd k2, ymm, m32bcst","vptestnmd k2, ymm, m32bcst |  | ")]
        vptestnmd_k2_ymm_m32bcst = 4676,

        /// <summary>
        /// vptestnmd k2, ymm, ymm |  | 
        /// </summary>
        [Symbol("vptestnmd k2, ymm, ymm","vptestnmd k2, ymm, ymm |  | ")]
        vptestnmd_k2_ymm_ymm = 4677,

        /// <summary>
        /// vptestnmd k2, zmm, m32bcst |  | 
        /// </summary>
        [Symbol("vptestnmd k2, zmm, m32bcst","vptestnmd k2, zmm, m32bcst |  | ")]
        vptestnmd_k2_zmm_m32bcst = 4678,

        /// <summary>
        /// vptestnmd k2, zmm, m512 |  | 
        /// </summary>
        [Symbol("vptestnmd k2, zmm, m512","vptestnmd k2, zmm, m512 |  | ")]
        vptestnmd_k2_zmm_m512 = 4679,

        /// <summary>
        /// vptestnmd k2, zmm, zmm |  | 
        /// </summary>
        [Symbol("vptestnmd k2, zmm, zmm","vptestnmd k2, zmm, zmm |  | ")]
        vptestnmd_k2_zmm_zmm = 4680,

        /// <summary>
        /// vptestnmq k2 {k1}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vptestnmq k2 {k1}, xmm, m128","vptestnmq k2 {k1}, xmm, m128 |  | ")]
        vptestnmq_k2_k1_xmm_m128 = 4681,

        /// <summary>
        /// vptestnmq k2 {k1}, xmm, m64bcst |  | 
        /// </summary>
        [Symbol("vptestnmq k2 {k1}, xmm, m64bcst","vptestnmq k2 {k1}, xmm, m64bcst |  | ")]
        vptestnmq_k2_k1_xmm_m64bcst = 4682,

        /// <summary>
        /// vptestnmq k2 {k1}, xmm, xmm |  | 
        /// </summary>
        [Symbol("vptestnmq k2 {k1}, xmm, xmm","vptestnmq k2 {k1}, xmm, xmm |  | ")]
        vptestnmq_k2_k1_xmm_xmm = 4683,

        /// <summary>
        /// vptestnmq k2 {k1}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vptestnmq k2 {k1}, ymm, m256","vptestnmq k2 {k1}, ymm, m256 |  | ")]
        vptestnmq_k2_k1_ymm_m256 = 4684,

        /// <summary>
        /// vptestnmq k2 {k1}, ymm, m64bcst |  | 
        /// </summary>
        [Symbol("vptestnmq k2 {k1}, ymm, m64bcst","vptestnmq k2 {k1}, ymm, m64bcst |  | ")]
        vptestnmq_k2_k1_ymm_m64bcst = 4685,

        /// <summary>
        /// vptestnmq k2 {k1}, ymm, ymm |  | 
        /// </summary>
        [Symbol("vptestnmq k2 {k1}, ymm, ymm","vptestnmq k2 {k1}, ymm, ymm |  | ")]
        vptestnmq_k2_k1_ymm_ymm = 4686,

        /// <summary>
        /// vptestnmq k2 {k1}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vptestnmq k2 {k1}, zmm, m512","vptestnmq k2 {k1}, zmm, m512 |  | ")]
        vptestnmq_k2_k1_zmm_m512 = 4687,

        /// <summary>
        /// vptestnmq k2 {k1}, zmm, m64bcst |  | 
        /// </summary>
        [Symbol("vptestnmq k2 {k1}, zmm, m64bcst","vptestnmq k2 {k1}, zmm, m64bcst |  | ")]
        vptestnmq_k2_k1_zmm_m64bcst = 4688,

        /// <summary>
        /// vptestnmq k2 {k1}, zmm, zmm |  | 
        /// </summary>
        [Symbol("vptestnmq k2 {k1}, zmm, zmm","vptestnmq k2 {k1}, zmm, zmm |  | ")]
        vptestnmq_k2_k1_zmm_zmm = 4689,

        /// <summary>
        /// vptestnmq k2, xmm, m128 |  | 
        /// </summary>
        [Symbol("vptestnmq k2, xmm, m128","vptestnmq k2, xmm, m128 |  | ")]
        vptestnmq_k2_xmm_m128 = 4690,

        /// <summary>
        /// vptestnmq k2, xmm, m64bcst |  | 
        /// </summary>
        [Symbol("vptestnmq k2, xmm, m64bcst","vptestnmq k2, xmm, m64bcst |  | ")]
        vptestnmq_k2_xmm_m64bcst = 4691,

        /// <summary>
        /// vptestnmq k2, xmm, xmm |  | 
        /// </summary>
        [Symbol("vptestnmq k2, xmm, xmm","vptestnmq k2, xmm, xmm |  | ")]
        vptestnmq_k2_xmm_xmm = 4692,

        /// <summary>
        /// vptestnmq k2, ymm, m256 |  | 
        /// </summary>
        [Symbol("vptestnmq k2, ymm, m256","vptestnmq k2, ymm, m256 |  | ")]
        vptestnmq_k2_ymm_m256 = 4693,

        /// <summary>
        /// vptestnmq k2, ymm, m64bcst |  | 
        /// </summary>
        [Symbol("vptestnmq k2, ymm, m64bcst","vptestnmq k2, ymm, m64bcst |  | ")]
        vptestnmq_k2_ymm_m64bcst = 4694,

        /// <summary>
        /// vptestnmq k2, ymm, ymm |  | 
        /// </summary>
        [Symbol("vptestnmq k2, ymm, ymm","vptestnmq k2, ymm, ymm |  | ")]
        vptestnmq_k2_ymm_ymm = 4695,

        /// <summary>
        /// vptestnmq k2, zmm, m512 |  | 
        /// </summary>
        [Symbol("vptestnmq k2, zmm, m512","vptestnmq k2, zmm, m512 |  | ")]
        vptestnmq_k2_zmm_m512 = 4696,

        /// <summary>
        /// vptestnmq k2, zmm, m64bcst |  | 
        /// </summary>
        [Symbol("vptestnmq k2, zmm, m64bcst","vptestnmq k2, zmm, m64bcst |  | ")]
        vptestnmq_k2_zmm_m64bcst = 4697,

        /// <summary>
        /// vptestnmq k2, zmm, zmm |  | 
        /// </summary>
        [Symbol("vptestnmq k2, zmm, zmm","vptestnmq k2, zmm, zmm |  | ")]
        vptestnmq_k2_zmm_zmm = 4698,

        /// <summary>
        /// vptestnmw k2 {k1}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vptestnmw k2 {k1}, xmm, m128","vptestnmw k2 {k1}, xmm, m128 |  | ")]
        vptestnmw_k2_k1_xmm_m128 = 4699,

        /// <summary>
        /// vptestnmw k2 {k1}, xmm, r8 |  | 
        /// </summary>
        [Symbol("vptestnmw k2 {k1}, xmm, r8","vptestnmw k2 {k1}, xmm, r8 |  | ")]
        vptestnmw_k2_k1_xmm_r8 = 4700,

        /// <summary>
        /// vptestnmw k2 {k1}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vptestnmw k2 {k1}, ymm, m256","vptestnmw k2 {k1}, ymm, m256 |  | ")]
        vptestnmw_k2_k1_ymm_m256 = 4701,

        /// <summary>
        /// vptestnmw k2 {k1}, ymm, r16 |  | 
        /// </summary>
        [Symbol("vptestnmw k2 {k1}, ymm, r16","vptestnmw k2 {k1}, ymm, r16 |  | ")]
        vptestnmw_k2_k1_ymm_r16 = 4702,

        /// <summary>
        /// vptestnmw k2 {k1}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vptestnmw k2 {k1}, zmm, m512","vptestnmw k2 {k1}, zmm, m512 |  | ")]
        vptestnmw_k2_k1_zmm_m512 = 4703,

        /// <summary>
        /// vptestnmw k2 {k1}, zmm, r32 |  | 
        /// </summary>
        [Symbol("vptestnmw k2 {k1}, zmm, r32","vptestnmw k2 {k1}, zmm, r32 |  | ")]
        vptestnmw_k2_k1_zmm_r32 = 4704,

        /// <summary>
        /// vptestnmw k2, xmm, m128 |  | 
        /// </summary>
        [Symbol("vptestnmw k2, xmm, m128","vptestnmw k2, xmm, m128 |  | ")]
        vptestnmw_k2_xmm_m128 = 4705,

        /// <summary>
        /// vptestnmw k2, xmm, r8 |  | 
        /// </summary>
        [Symbol("vptestnmw k2, xmm, r8","vptestnmw k2, xmm, r8 |  | ")]
        vptestnmw_k2_xmm_r8 = 4706,

        /// <summary>
        /// vptestnmw k2, ymm, m256 |  | 
        /// </summary>
        [Symbol("vptestnmw k2, ymm, m256","vptestnmw k2, ymm, m256 |  | ")]
        vptestnmw_k2_ymm_m256 = 4707,

        /// <summary>
        /// vptestnmw k2, ymm, r16 |  | 
        /// </summary>
        [Symbol("vptestnmw k2, ymm, r16","vptestnmw k2, ymm, r16 |  | ")]
        vptestnmw_k2_ymm_r16 = 4708,

        /// <summary>
        /// vptestnmw k2, zmm, m512 |  | 
        /// </summary>
        [Symbol("vptestnmw k2, zmm, m512","vptestnmw k2, zmm, m512 |  | ")]
        vptestnmw_k2_zmm_m512 = 4709,

        /// <summary>
        /// vptestnmw k2, zmm, r32 |  | 
        /// </summary>
        [Symbol("vptestnmw k2, zmm, r32","vptestnmw k2, zmm, r32 |  | ")]
        vptestnmw_k2_zmm_r32 = 4710,

        /// <summary>
        /// vpunpckhbw xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpunpckhbw xmm {k1}{z}, xmm, m128","vpunpckhbw xmm {k1}{z}, xmm, m128 |  | ")]
        vpunpckhbw_xmm_k1z_xmm_m128 = 4711,

        /// <summary>
        /// vpunpckhbw xmm {k1}{z}, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpunpckhbw xmm {k1}{z}, xmm, r8","vpunpckhbw xmm {k1}{z}, xmm, r8 |  | ")]
        vpunpckhbw_xmm_k1z_xmm_r8 = 4712,

        /// <summary>
        /// vpunpckhbw xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpunpckhbw xmm, xmm, m128","vpunpckhbw xmm, xmm, m128 |  | ")]
        vpunpckhbw_xmm_xmm_m128 = 4713,

        /// <summary>
        /// vpunpckhbw xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpunpckhbw xmm, xmm, r8","vpunpckhbw xmm, xmm, r8 |  | ")]
        vpunpckhbw_xmm_xmm_r8 = 4714,

        /// <summary>
        /// vpunpckhbw ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpunpckhbw ymm {k1}{z}, ymm, m256","vpunpckhbw ymm {k1}{z}, ymm, m256 |  | ")]
        vpunpckhbw_ymm_k1z_ymm_m256 = 4715,

        /// <summary>
        /// vpunpckhbw ymm {k1}{z}, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpunpckhbw ymm {k1}{z}, ymm, r16","vpunpckhbw ymm {k1}{z}, ymm, r16 |  | ")]
        vpunpckhbw_ymm_k1z_ymm_r16 = 4716,

        /// <summary>
        /// vpunpckhbw ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpunpckhbw ymm, ymm, m256","vpunpckhbw ymm, ymm, m256 |  | ")]
        vpunpckhbw_ymm_ymm_m256 = 4717,

        /// <summary>
        /// vpunpckhbw ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpunpckhbw ymm, ymm, r16","vpunpckhbw ymm, ymm, r16 |  | ")]
        vpunpckhbw_ymm_ymm_r16 = 4718,

        /// <summary>
        /// vpunpckhbw zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpunpckhbw zmm {k1}{z}, zmm, m512","vpunpckhbw zmm {k1}{z}, zmm, m512 |  | ")]
        vpunpckhbw_zmm_k1z_zmm_m512 = 4719,

        /// <summary>
        /// vpunpckhbw zmm {k1}{z}, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpunpckhbw zmm {k1}{z}, zmm, r32","vpunpckhbw zmm {k1}{z}, zmm, r32 |  | ")]
        vpunpckhbw_zmm_k1z_zmm_r32 = 4720,

        /// <summary>
        /// vpunpckhbw zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpunpckhbw zmm, zmm, m512","vpunpckhbw zmm, zmm, m512 |  | ")]
        vpunpckhbw_zmm_zmm_m512 = 4721,

        /// <summary>
        /// vpunpckhbw zmm, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpunpckhbw zmm, zmm, r32","vpunpckhbw zmm, zmm, r32 |  | ")]
        vpunpckhbw_zmm_zmm_r32 = 4722,

        /// <summary>
        /// vpunpckhdq xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpunpckhdq xmm {k1}{z}, xmm, m128","vpunpckhdq xmm {k1}{z}, xmm, m128 |  | ")]
        vpunpckhdq_xmm_k1z_xmm_m128 = 4723,

        /// <summary>
        /// vpunpckhdq xmm {k1}{z}, xmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpunpckhdq xmm {k1}{z}, xmm, m32bcst","vpunpckhdq xmm {k1}{z}, xmm, m32bcst |  | ")]
        vpunpckhdq_xmm_k1z_xmm_m32bcst = 4724,

        /// <summary>
        /// vpunpckhdq xmm {k1}{z}, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpunpckhdq xmm {k1}{z}, xmm, xmm","vpunpckhdq xmm {k1}{z}, xmm, xmm |  | ")]
        vpunpckhdq_xmm_k1z_xmm_xmm = 4725,

        /// <summary>
        /// vpunpckhdq xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpunpckhdq xmm, xmm, m128","vpunpckhdq xmm, xmm, m128 |  | ")]
        vpunpckhdq_xmm_xmm_m128 = 4726,

        /// <summary>
        /// vpunpckhdq xmm, xmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpunpckhdq xmm, xmm, m32bcst","vpunpckhdq xmm, xmm, m32bcst |  | ")]
        vpunpckhdq_xmm_xmm_m32bcst = 4727,

        /// <summary>
        /// vpunpckhdq xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpunpckhdq xmm, xmm, r8","vpunpckhdq xmm, xmm, r8 |  | ")]
        vpunpckhdq_xmm_xmm_r8 = 4728,

        /// <summary>
        /// vpunpckhdq xmm, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpunpckhdq xmm, xmm, xmm","vpunpckhdq xmm, xmm, xmm |  | ")]
        vpunpckhdq_xmm_xmm_xmm = 4729,

        /// <summary>
        /// vpunpckhdq ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpunpckhdq ymm {k1}{z}, ymm, m256","vpunpckhdq ymm {k1}{z}, ymm, m256 |  | ")]
        vpunpckhdq_ymm_k1z_ymm_m256 = 4730,

        /// <summary>
        /// vpunpckhdq ymm {k1}{z}, ymm, m32bcst |  | 
        /// </summary>
        [Symbol("vpunpckhdq ymm {k1}{z}, ymm, m32bcst","vpunpckhdq ymm {k1}{z}, ymm, m32bcst |  | ")]
        vpunpckhdq_ymm_k1z_ymm_m32bcst = 4731,

        /// <summary>
        /// vpunpckhdq ymm {k1}{z}, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpunpckhdq ymm {k1}{z}, ymm, ymm","vpunpckhdq ymm {k1}{z}, ymm, ymm |  | ")]
        vpunpckhdq_ymm_k1z_ymm_ymm = 4732,

        /// <summary>
        /// vpunpckhdq ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpunpckhdq ymm, ymm, m256","vpunpckhdq ymm, ymm, m256 |  | ")]
        vpunpckhdq_ymm_ymm_m256 = 4733,

        /// <summary>
        /// vpunpckhdq ymm, ymm, m32bcst |  | 
        /// </summary>
        [Symbol("vpunpckhdq ymm, ymm, m32bcst","vpunpckhdq ymm, ymm, m32bcst |  | ")]
        vpunpckhdq_ymm_ymm_m32bcst = 4734,

        /// <summary>
        /// vpunpckhdq ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpunpckhdq ymm, ymm, r16","vpunpckhdq ymm, ymm, r16 |  | ")]
        vpunpckhdq_ymm_ymm_r16 = 4735,

        /// <summary>
        /// vpunpckhdq ymm, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpunpckhdq ymm, ymm, ymm","vpunpckhdq ymm, ymm, ymm |  | ")]
        vpunpckhdq_ymm_ymm_ymm = 4736,

        /// <summary>
        /// vpunpckhdq zmm {k1}{z}, zmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpunpckhdq zmm {k1}{z}, zmm, m32bcst","vpunpckhdq zmm {k1}{z}, zmm, m32bcst |  | ")]
        vpunpckhdq_zmm_k1z_zmm_m32bcst = 4737,

        /// <summary>
        /// vpunpckhdq zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpunpckhdq zmm {k1}{z}, zmm, m512","vpunpckhdq zmm {k1}{z}, zmm, m512 |  | ")]
        vpunpckhdq_zmm_k1z_zmm_m512 = 4738,

        /// <summary>
        /// vpunpckhdq zmm {k1}{z}, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpunpckhdq zmm {k1}{z}, zmm, zmm","vpunpckhdq zmm {k1}{z}, zmm, zmm |  | ")]
        vpunpckhdq_zmm_k1z_zmm_zmm = 4739,

        /// <summary>
        /// vpunpckhdq zmm, zmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpunpckhdq zmm, zmm, m32bcst","vpunpckhdq zmm, zmm, m32bcst |  | ")]
        vpunpckhdq_zmm_zmm_m32bcst = 4740,

        /// <summary>
        /// vpunpckhdq zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpunpckhdq zmm, zmm, m512","vpunpckhdq zmm, zmm, m512 |  | ")]
        vpunpckhdq_zmm_zmm_m512 = 4741,

        /// <summary>
        /// vpunpckhdq zmm, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpunpckhdq zmm, zmm, zmm","vpunpckhdq zmm, zmm, zmm |  | ")]
        vpunpckhdq_zmm_zmm_zmm = 4742,

        /// <summary>
        /// vpunpckhqdq xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpunpckhqdq xmm {k1}{z}, xmm, m128","vpunpckhqdq xmm {k1}{z}, xmm, m128 |  | ")]
        vpunpckhqdq_xmm_k1z_xmm_m128 = 4743,

        /// <summary>
        /// vpunpckhqdq xmm {k1}{z}, xmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpunpckhqdq xmm {k1}{z}, xmm, m64bcst","vpunpckhqdq xmm {k1}{z}, xmm, m64bcst |  | ")]
        vpunpckhqdq_xmm_k1z_xmm_m64bcst = 4744,

        /// <summary>
        /// vpunpckhqdq xmm {k1}{z}, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpunpckhqdq xmm {k1}{z}, xmm, xmm","vpunpckhqdq xmm {k1}{z}, xmm, xmm |  | ")]
        vpunpckhqdq_xmm_k1z_xmm_xmm = 4745,

        /// <summary>
        /// vpunpckhqdq xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpunpckhqdq xmm, xmm, m128","vpunpckhqdq xmm, xmm, m128 |  | ")]
        vpunpckhqdq_xmm_xmm_m128 = 4746,

        /// <summary>
        /// vpunpckhqdq xmm, xmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpunpckhqdq xmm, xmm, m64bcst","vpunpckhqdq xmm, xmm, m64bcst |  | ")]
        vpunpckhqdq_xmm_xmm_m64bcst = 4747,

        /// <summary>
        /// vpunpckhqdq xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpunpckhqdq xmm, xmm, r8","vpunpckhqdq xmm, xmm, r8 |  | ")]
        vpunpckhqdq_xmm_xmm_r8 = 4748,

        /// <summary>
        /// vpunpckhqdq xmm, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpunpckhqdq xmm, xmm, xmm","vpunpckhqdq xmm, xmm, xmm |  | ")]
        vpunpckhqdq_xmm_xmm_xmm = 4749,

        /// <summary>
        /// vpunpckhqdq ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpunpckhqdq ymm {k1}{z}, ymm, m256","vpunpckhqdq ymm {k1}{z}, ymm, m256 |  | ")]
        vpunpckhqdq_ymm_k1z_ymm_m256 = 4750,

        /// <summary>
        /// vpunpckhqdq ymm {k1}{z}, ymm, m64bcst |  | 
        /// </summary>
        [Symbol("vpunpckhqdq ymm {k1}{z}, ymm, m64bcst","vpunpckhqdq ymm {k1}{z}, ymm, m64bcst |  | ")]
        vpunpckhqdq_ymm_k1z_ymm_m64bcst = 4751,

        /// <summary>
        /// vpunpckhqdq ymm {k1}{z}, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpunpckhqdq ymm {k1}{z}, ymm, ymm","vpunpckhqdq ymm {k1}{z}, ymm, ymm |  | ")]
        vpunpckhqdq_ymm_k1z_ymm_ymm = 4752,

        /// <summary>
        /// vpunpckhqdq ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpunpckhqdq ymm, ymm, m256","vpunpckhqdq ymm, ymm, m256 |  | ")]
        vpunpckhqdq_ymm_ymm_m256 = 4753,

        /// <summary>
        /// vpunpckhqdq ymm, ymm, m64bcst |  | 
        /// </summary>
        [Symbol("vpunpckhqdq ymm, ymm, m64bcst","vpunpckhqdq ymm, ymm, m64bcst |  | ")]
        vpunpckhqdq_ymm_ymm_m64bcst = 4754,

        /// <summary>
        /// vpunpckhqdq ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpunpckhqdq ymm, ymm, r16","vpunpckhqdq ymm, ymm, r16 |  | ")]
        vpunpckhqdq_ymm_ymm_r16 = 4755,

        /// <summary>
        /// vpunpckhqdq ymm, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpunpckhqdq ymm, ymm, ymm","vpunpckhqdq ymm, ymm, ymm |  | ")]
        vpunpckhqdq_ymm_ymm_ymm = 4756,

        /// <summary>
        /// vpunpckhqdq zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpunpckhqdq zmm {k1}{z}, zmm, m512","vpunpckhqdq zmm {k1}{z}, zmm, m512 |  | ")]
        vpunpckhqdq_zmm_k1z_zmm_m512 = 4757,

        /// <summary>
        /// vpunpckhqdq zmm {k1}{z}, zmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpunpckhqdq zmm {k1}{z}, zmm, m64bcst","vpunpckhqdq zmm {k1}{z}, zmm, m64bcst |  | ")]
        vpunpckhqdq_zmm_k1z_zmm_m64bcst = 4758,

        /// <summary>
        /// vpunpckhqdq zmm {k1}{z}, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpunpckhqdq zmm {k1}{z}, zmm, zmm","vpunpckhqdq zmm {k1}{z}, zmm, zmm |  | ")]
        vpunpckhqdq_zmm_k1z_zmm_zmm = 4759,

        /// <summary>
        /// vpunpckhqdq zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpunpckhqdq zmm, zmm, m512","vpunpckhqdq zmm, zmm, m512 |  | ")]
        vpunpckhqdq_zmm_zmm_m512 = 4760,

        /// <summary>
        /// vpunpckhqdq zmm, zmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpunpckhqdq zmm, zmm, m64bcst","vpunpckhqdq zmm, zmm, m64bcst |  | ")]
        vpunpckhqdq_zmm_zmm_m64bcst = 4761,

        /// <summary>
        /// vpunpckhqdq zmm, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpunpckhqdq zmm, zmm, zmm","vpunpckhqdq zmm, zmm, zmm |  | ")]
        vpunpckhqdq_zmm_zmm_zmm = 4762,

        /// <summary>
        /// vpunpckhwd xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpunpckhwd xmm {k1}{z}, xmm, m128","vpunpckhwd xmm {k1}{z}, xmm, m128 |  | ")]
        vpunpckhwd_xmm_k1z_xmm_m128 = 4763,

        /// <summary>
        /// vpunpckhwd xmm {k1}{z}, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpunpckhwd xmm {k1}{z}, xmm, r8","vpunpckhwd xmm {k1}{z}, xmm, r8 |  | ")]
        vpunpckhwd_xmm_k1z_xmm_r8 = 4764,

        /// <summary>
        /// vpunpckhwd xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpunpckhwd xmm, xmm, m128","vpunpckhwd xmm, xmm, m128 |  | ")]
        vpunpckhwd_xmm_xmm_m128 = 4765,

        /// <summary>
        /// vpunpckhwd xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpunpckhwd xmm, xmm, r8","vpunpckhwd xmm, xmm, r8 |  | ")]
        vpunpckhwd_xmm_xmm_r8 = 4766,

        /// <summary>
        /// vpunpckhwd ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpunpckhwd ymm {k1}{z}, ymm, m256","vpunpckhwd ymm {k1}{z}, ymm, m256 |  | ")]
        vpunpckhwd_ymm_k1z_ymm_m256 = 4767,

        /// <summary>
        /// vpunpckhwd ymm {k1}{z}, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpunpckhwd ymm {k1}{z}, ymm, r16","vpunpckhwd ymm {k1}{z}, ymm, r16 |  | ")]
        vpunpckhwd_ymm_k1z_ymm_r16 = 4768,

        /// <summary>
        /// vpunpckhwd ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpunpckhwd ymm, ymm, m256","vpunpckhwd ymm, ymm, m256 |  | ")]
        vpunpckhwd_ymm_ymm_m256 = 4769,

        /// <summary>
        /// vpunpckhwd ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpunpckhwd ymm, ymm, r16","vpunpckhwd ymm, ymm, r16 |  | ")]
        vpunpckhwd_ymm_ymm_r16 = 4770,

        /// <summary>
        /// vpunpckhwd zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpunpckhwd zmm {k1}{z}, zmm, m512","vpunpckhwd zmm {k1}{z}, zmm, m512 |  | ")]
        vpunpckhwd_zmm_k1z_zmm_m512 = 4771,

        /// <summary>
        /// vpunpckhwd zmm {k1}{z}, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpunpckhwd zmm {k1}{z}, zmm, r32","vpunpckhwd zmm {k1}{z}, zmm, r32 |  | ")]
        vpunpckhwd_zmm_k1z_zmm_r32 = 4772,

        /// <summary>
        /// vpunpckhwd zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpunpckhwd zmm, zmm, m512","vpunpckhwd zmm, zmm, m512 |  | ")]
        vpunpckhwd_zmm_zmm_m512 = 4773,

        /// <summary>
        /// vpunpckhwd zmm, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpunpckhwd zmm, zmm, r32","vpunpckhwd zmm, zmm, r32 |  | ")]
        vpunpckhwd_zmm_zmm_r32 = 4774,

        /// <summary>
        /// vpunpcklbw xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpunpcklbw xmm {k1}{z}, xmm, m128","vpunpcklbw xmm {k1}{z}, xmm, m128 |  | ")]
        vpunpcklbw_xmm_k1z_xmm_m128 = 4775,

        /// <summary>
        /// vpunpcklbw xmm {k1}{z}, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpunpcklbw xmm {k1}{z}, xmm, r8","vpunpcklbw xmm {k1}{z}, xmm, r8 |  | ")]
        vpunpcklbw_xmm_k1z_xmm_r8 = 4776,

        /// <summary>
        /// vpunpcklbw xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpunpcklbw xmm, xmm, m128","vpunpcklbw xmm, xmm, m128 |  | ")]
        vpunpcklbw_xmm_xmm_m128 = 4777,

        /// <summary>
        /// vpunpcklbw xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpunpcklbw xmm, xmm, r8","vpunpcklbw xmm, xmm, r8 |  | ")]
        vpunpcklbw_xmm_xmm_r8 = 4778,

        /// <summary>
        /// vpunpcklbw ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpunpcklbw ymm {k1}{z}, ymm, m256","vpunpcklbw ymm {k1}{z}, ymm, m256 |  | ")]
        vpunpcklbw_ymm_k1z_ymm_m256 = 4779,

        /// <summary>
        /// vpunpcklbw ymm {k1}{z}, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpunpcklbw ymm {k1}{z}, ymm, r16","vpunpcklbw ymm {k1}{z}, ymm, r16 |  | ")]
        vpunpcklbw_ymm_k1z_ymm_r16 = 4780,

        /// <summary>
        /// vpunpcklbw ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpunpcklbw ymm, ymm, m256","vpunpcklbw ymm, ymm, m256 |  | ")]
        vpunpcklbw_ymm_ymm_m256 = 4781,

        /// <summary>
        /// vpunpcklbw ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpunpcklbw ymm, ymm, r16","vpunpcklbw ymm, ymm, r16 |  | ")]
        vpunpcklbw_ymm_ymm_r16 = 4782,

        /// <summary>
        /// vpunpcklbw zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpunpcklbw zmm {k1}{z}, zmm, m512","vpunpcklbw zmm {k1}{z}, zmm, m512 |  | ")]
        vpunpcklbw_zmm_k1z_zmm_m512 = 4783,

        /// <summary>
        /// vpunpcklbw zmm {k1}{z}, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpunpcklbw zmm {k1}{z}, zmm, r32","vpunpcklbw zmm {k1}{z}, zmm, r32 |  | ")]
        vpunpcklbw_zmm_k1z_zmm_r32 = 4784,

        /// <summary>
        /// vpunpcklbw zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpunpcklbw zmm, zmm, m512","vpunpcklbw zmm, zmm, m512 |  | ")]
        vpunpcklbw_zmm_zmm_m512 = 4785,

        /// <summary>
        /// vpunpcklbw zmm, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpunpcklbw zmm, zmm, r32","vpunpcklbw zmm, zmm, r32 |  | ")]
        vpunpcklbw_zmm_zmm_r32 = 4786,

        /// <summary>
        /// vpunpckldq xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpunpckldq xmm {k1}{z}, xmm, m128","vpunpckldq xmm {k1}{z}, xmm, m128 |  | ")]
        vpunpckldq_xmm_k1z_xmm_m128 = 4787,

        /// <summary>
        /// vpunpckldq xmm {k1}{z}, xmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpunpckldq xmm {k1}{z}, xmm, m32bcst","vpunpckldq xmm {k1}{z}, xmm, m32bcst |  | ")]
        vpunpckldq_xmm_k1z_xmm_m32bcst = 4788,

        /// <summary>
        /// vpunpckldq xmm {k1}{z}, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpunpckldq xmm {k1}{z}, xmm, xmm","vpunpckldq xmm {k1}{z}, xmm, xmm |  | ")]
        vpunpckldq_xmm_k1z_xmm_xmm = 4789,

        /// <summary>
        /// vpunpckldq xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpunpckldq xmm, xmm, m128","vpunpckldq xmm, xmm, m128 |  | ")]
        vpunpckldq_xmm_xmm_m128 = 4790,

        /// <summary>
        /// vpunpckldq xmm, xmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpunpckldq xmm, xmm, m32bcst","vpunpckldq xmm, xmm, m32bcst |  | ")]
        vpunpckldq_xmm_xmm_m32bcst = 4791,

        /// <summary>
        /// vpunpckldq xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpunpckldq xmm, xmm, r8","vpunpckldq xmm, xmm, r8 |  | ")]
        vpunpckldq_xmm_xmm_r8 = 4792,

        /// <summary>
        /// vpunpckldq xmm, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpunpckldq xmm, xmm, xmm","vpunpckldq xmm, xmm, xmm |  | ")]
        vpunpckldq_xmm_xmm_xmm = 4793,

        /// <summary>
        /// vpunpckldq ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpunpckldq ymm {k1}{z}, ymm, m256","vpunpckldq ymm {k1}{z}, ymm, m256 |  | ")]
        vpunpckldq_ymm_k1z_ymm_m256 = 4794,

        /// <summary>
        /// vpunpckldq ymm {k1}{z}, ymm, m32bcst |  | 
        /// </summary>
        [Symbol("vpunpckldq ymm {k1}{z}, ymm, m32bcst","vpunpckldq ymm {k1}{z}, ymm, m32bcst |  | ")]
        vpunpckldq_ymm_k1z_ymm_m32bcst = 4795,

        /// <summary>
        /// vpunpckldq ymm {k1}{z}, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpunpckldq ymm {k1}{z}, ymm, ymm","vpunpckldq ymm {k1}{z}, ymm, ymm |  | ")]
        vpunpckldq_ymm_k1z_ymm_ymm = 4796,

        /// <summary>
        /// vpunpckldq ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpunpckldq ymm, ymm, m256","vpunpckldq ymm, ymm, m256 |  | ")]
        vpunpckldq_ymm_ymm_m256 = 4797,

        /// <summary>
        /// vpunpckldq ymm, ymm, m32bcst |  | 
        /// </summary>
        [Symbol("vpunpckldq ymm, ymm, m32bcst","vpunpckldq ymm, ymm, m32bcst |  | ")]
        vpunpckldq_ymm_ymm_m32bcst = 4798,

        /// <summary>
        /// vpunpckldq ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpunpckldq ymm, ymm, r16","vpunpckldq ymm, ymm, r16 |  | ")]
        vpunpckldq_ymm_ymm_r16 = 4799,

        /// <summary>
        /// vpunpckldq ymm, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpunpckldq ymm, ymm, ymm","vpunpckldq ymm, ymm, ymm |  | ")]
        vpunpckldq_ymm_ymm_ymm = 4800,

        /// <summary>
        /// vpunpckldq zmm {k1}{z}, zmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpunpckldq zmm {k1}{z}, zmm, m32bcst","vpunpckldq zmm {k1}{z}, zmm, m32bcst |  | ")]
        vpunpckldq_zmm_k1z_zmm_m32bcst = 4801,

        /// <summary>
        /// vpunpckldq zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpunpckldq zmm {k1}{z}, zmm, m512","vpunpckldq zmm {k1}{z}, zmm, m512 |  | ")]
        vpunpckldq_zmm_k1z_zmm_m512 = 4802,

        /// <summary>
        /// vpunpckldq zmm {k1}{z}, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpunpckldq zmm {k1}{z}, zmm, zmm","vpunpckldq zmm {k1}{z}, zmm, zmm |  | ")]
        vpunpckldq_zmm_k1z_zmm_zmm = 4803,

        /// <summary>
        /// vpunpckldq zmm, zmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpunpckldq zmm, zmm, m32bcst","vpunpckldq zmm, zmm, m32bcst |  | ")]
        vpunpckldq_zmm_zmm_m32bcst = 4804,

        /// <summary>
        /// vpunpckldq zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpunpckldq zmm, zmm, m512","vpunpckldq zmm, zmm, m512 |  | ")]
        vpunpckldq_zmm_zmm_m512 = 4805,

        /// <summary>
        /// vpunpckldq zmm, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpunpckldq zmm, zmm, zmm","vpunpckldq zmm, zmm, zmm |  | ")]
        vpunpckldq_zmm_zmm_zmm = 4806,

        /// <summary>
        /// vpunpcklqdq xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpunpcklqdq xmm {k1}{z}, xmm, m128","vpunpcklqdq xmm {k1}{z}, xmm, m128 |  | ")]
        vpunpcklqdq_xmm_k1z_xmm_m128 = 4807,

        /// <summary>
        /// vpunpcklqdq xmm {k1}{z}, xmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpunpcklqdq xmm {k1}{z}, xmm, m64bcst","vpunpcklqdq xmm {k1}{z}, xmm, m64bcst |  | ")]
        vpunpcklqdq_xmm_k1z_xmm_m64bcst = 4808,

        /// <summary>
        /// vpunpcklqdq xmm {k1}{z}, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpunpcklqdq xmm {k1}{z}, xmm, xmm","vpunpcklqdq xmm {k1}{z}, xmm, xmm |  | ")]
        vpunpcklqdq_xmm_k1z_xmm_xmm = 4809,

        /// <summary>
        /// vpunpcklqdq xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpunpcklqdq xmm, xmm, m128","vpunpcklqdq xmm, xmm, m128 |  | ")]
        vpunpcklqdq_xmm_xmm_m128 = 4810,

        /// <summary>
        /// vpunpcklqdq xmm, xmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpunpcklqdq xmm, xmm, m64bcst","vpunpcklqdq xmm, xmm, m64bcst |  | ")]
        vpunpcklqdq_xmm_xmm_m64bcst = 4811,

        /// <summary>
        /// vpunpcklqdq xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpunpcklqdq xmm, xmm, r8","vpunpcklqdq xmm, xmm, r8 |  | ")]
        vpunpcklqdq_xmm_xmm_r8 = 4812,

        /// <summary>
        /// vpunpcklqdq xmm, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpunpcklqdq xmm, xmm, xmm","vpunpcklqdq xmm, xmm, xmm |  | ")]
        vpunpcklqdq_xmm_xmm_xmm = 4813,

        /// <summary>
        /// vpunpcklqdq ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpunpcklqdq ymm {k1}{z}, ymm, m256","vpunpcklqdq ymm {k1}{z}, ymm, m256 |  | ")]
        vpunpcklqdq_ymm_k1z_ymm_m256 = 4814,

        /// <summary>
        /// vpunpcklqdq ymm {k1}{z}, ymm, m64bcst |  | 
        /// </summary>
        [Symbol("vpunpcklqdq ymm {k1}{z}, ymm, m64bcst","vpunpcklqdq ymm {k1}{z}, ymm, m64bcst |  | ")]
        vpunpcklqdq_ymm_k1z_ymm_m64bcst = 4815,

        /// <summary>
        /// vpunpcklqdq ymm {k1}{z}, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpunpcklqdq ymm {k1}{z}, ymm, ymm","vpunpcklqdq ymm {k1}{z}, ymm, ymm |  | ")]
        vpunpcklqdq_ymm_k1z_ymm_ymm = 4816,

        /// <summary>
        /// vpunpcklqdq ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpunpcklqdq ymm, ymm, m256","vpunpcklqdq ymm, ymm, m256 |  | ")]
        vpunpcklqdq_ymm_ymm_m256 = 4817,

        /// <summary>
        /// vpunpcklqdq ymm, ymm, m64bcst |  | 
        /// </summary>
        [Symbol("vpunpcklqdq ymm, ymm, m64bcst","vpunpcklqdq ymm, ymm, m64bcst |  | ")]
        vpunpcklqdq_ymm_ymm_m64bcst = 4818,

        /// <summary>
        /// vpunpcklqdq ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpunpcklqdq ymm, ymm, r16","vpunpcklqdq ymm, ymm, r16 |  | ")]
        vpunpcklqdq_ymm_ymm_r16 = 4819,

        /// <summary>
        /// vpunpcklqdq ymm, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpunpcklqdq ymm, ymm, ymm","vpunpcklqdq ymm, ymm, ymm |  | ")]
        vpunpcklqdq_ymm_ymm_ymm = 4820,

        /// <summary>
        /// vpunpcklqdq zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpunpcklqdq zmm {k1}{z}, zmm, m512","vpunpcklqdq zmm {k1}{z}, zmm, m512 |  | ")]
        vpunpcklqdq_zmm_k1z_zmm_m512 = 4821,

        /// <summary>
        /// vpunpcklqdq zmm {k1}{z}, zmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpunpcklqdq zmm {k1}{z}, zmm, m64bcst","vpunpcklqdq zmm {k1}{z}, zmm, m64bcst |  | ")]
        vpunpcklqdq_zmm_k1z_zmm_m64bcst = 4822,

        /// <summary>
        /// vpunpcklqdq zmm {k1}{z}, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpunpcklqdq zmm {k1}{z}, zmm, zmm","vpunpcklqdq zmm {k1}{z}, zmm, zmm |  | ")]
        vpunpcklqdq_zmm_k1z_zmm_zmm = 4823,

        /// <summary>
        /// vpunpcklqdq zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpunpcklqdq zmm, zmm, m512","vpunpcklqdq zmm, zmm, m512 |  | ")]
        vpunpcklqdq_zmm_zmm_m512 = 4824,

        /// <summary>
        /// vpunpcklqdq zmm, zmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpunpcklqdq zmm, zmm, m64bcst","vpunpcklqdq zmm, zmm, m64bcst |  | ")]
        vpunpcklqdq_zmm_zmm_m64bcst = 4825,

        /// <summary>
        /// vpunpcklqdq zmm, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpunpcklqdq zmm, zmm, zmm","vpunpcklqdq zmm, zmm, zmm |  | ")]
        vpunpcklqdq_zmm_zmm_zmm = 4826,

        /// <summary>
        /// vpunpcklwd xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpunpcklwd xmm {k1}{z}, xmm, m128","vpunpcklwd xmm {k1}{z}, xmm, m128 |  | ")]
        vpunpcklwd_xmm_k1z_xmm_m128 = 4827,

        /// <summary>
        /// vpunpcklwd xmm {k1}{z}, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpunpcklwd xmm {k1}{z}, xmm, r8","vpunpcklwd xmm {k1}{z}, xmm, r8 |  | ")]
        vpunpcklwd_xmm_k1z_xmm_r8 = 4828,

        /// <summary>
        /// vpunpcklwd xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpunpcklwd xmm, xmm, m128","vpunpcklwd xmm, xmm, m128 |  | ")]
        vpunpcklwd_xmm_xmm_m128 = 4829,

        /// <summary>
        /// vpunpcklwd xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpunpcklwd xmm, xmm, r8","vpunpcklwd xmm, xmm, r8 |  | ")]
        vpunpcklwd_xmm_xmm_r8 = 4830,

        /// <summary>
        /// vpunpcklwd ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpunpcklwd ymm {k1}{z}, ymm, m256","vpunpcklwd ymm {k1}{z}, ymm, m256 |  | ")]
        vpunpcklwd_ymm_k1z_ymm_m256 = 4831,

        /// <summary>
        /// vpunpcklwd ymm {k1}{z}, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpunpcklwd ymm {k1}{z}, ymm, r16","vpunpcklwd ymm {k1}{z}, ymm, r16 |  | ")]
        vpunpcklwd_ymm_k1z_ymm_r16 = 4832,

        /// <summary>
        /// vpunpcklwd ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpunpcklwd ymm, ymm, m256","vpunpcklwd ymm, ymm, m256 |  | ")]
        vpunpcklwd_ymm_ymm_m256 = 4833,

        /// <summary>
        /// vpunpcklwd ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpunpcklwd ymm, ymm, r16","vpunpcklwd ymm, ymm, r16 |  | ")]
        vpunpcklwd_ymm_ymm_r16 = 4834,

        /// <summary>
        /// vpunpcklwd zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpunpcklwd zmm {k1}{z}, zmm, m512","vpunpcklwd zmm {k1}{z}, zmm, m512 |  | ")]
        vpunpcklwd_zmm_k1z_zmm_m512 = 4835,

        /// <summary>
        /// vpunpcklwd zmm {k1}{z}, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpunpcklwd zmm {k1}{z}, zmm, r32","vpunpcklwd zmm {k1}{z}, zmm, r32 |  | ")]
        vpunpcklwd_zmm_k1z_zmm_r32 = 4836,

        /// <summary>
        /// vpunpcklwd zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpunpcklwd zmm, zmm, m512","vpunpcklwd zmm, zmm, m512 |  | ")]
        vpunpcklwd_zmm_zmm_m512 = 4837,

        /// <summary>
        /// vpunpcklwd zmm, zmm, r32 |  | 
        /// </summary>
        [Symbol("vpunpcklwd zmm, zmm, r32","vpunpcklwd zmm, zmm, r32 |  | ")]
        vpunpcklwd_zmm_zmm_r32 = 4838,

        /// <summary>
        /// vpxor xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpxor xmm, xmm, m128","vpxor xmm, xmm, m128 |  | ")]
        vpxor_xmm_xmm_m128 = 4839,

        /// <summary>
        /// vpxor xmm, xmm, r8 |  | 
        /// </summary>
        [Symbol("vpxor xmm, xmm, r8","vpxor xmm, xmm, r8 |  | ")]
        vpxor_xmm_xmm_r8 = 4840,

        /// <summary>
        /// vpxor ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpxor ymm, ymm, m256","vpxor ymm, ymm, m256 |  | ")]
        vpxor_ymm_ymm_m256 = 4841,

        /// <summary>
        /// vpxor ymm, ymm, r16 |  | 
        /// </summary>
        [Symbol("vpxor ymm, ymm, r16","vpxor ymm, ymm, r16 |  | ")]
        vpxor_ymm_ymm_r16 = 4842,

        /// <summary>
        /// vpxord xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpxord xmm {k1}{z}, xmm, m128","vpxord xmm {k1}{z}, xmm, m128 |  | ")]
        vpxord_xmm_k1z_xmm_m128 = 4843,

        /// <summary>
        /// vpxord xmm {k1}{z}, xmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpxord xmm {k1}{z}, xmm, m32bcst","vpxord xmm {k1}{z}, xmm, m32bcst |  | ")]
        vpxord_xmm_k1z_xmm_m32bcst = 4844,

        /// <summary>
        /// vpxord xmm {k1}{z}, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpxord xmm {k1}{z}, xmm, xmm","vpxord xmm {k1}{z}, xmm, xmm |  | ")]
        vpxord_xmm_k1z_xmm_xmm = 4845,

        /// <summary>
        /// vpxord xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpxord xmm, xmm, m128","vpxord xmm, xmm, m128 |  | ")]
        vpxord_xmm_xmm_m128 = 4846,

        /// <summary>
        /// vpxord xmm, xmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpxord xmm, xmm, m32bcst","vpxord xmm, xmm, m32bcst |  | ")]
        vpxord_xmm_xmm_m32bcst = 4847,

        /// <summary>
        /// vpxord xmm, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpxord xmm, xmm, xmm","vpxord xmm, xmm, xmm |  | ")]
        vpxord_xmm_xmm_xmm = 4848,

        /// <summary>
        /// vpxord ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpxord ymm {k1}{z}, ymm, m256","vpxord ymm {k1}{z}, ymm, m256 |  | ")]
        vpxord_ymm_k1z_ymm_m256 = 4849,

        /// <summary>
        /// vpxord ymm {k1}{z}, ymm, m32bcst |  | 
        /// </summary>
        [Symbol("vpxord ymm {k1}{z}, ymm, m32bcst","vpxord ymm {k1}{z}, ymm, m32bcst |  | ")]
        vpxord_ymm_k1z_ymm_m32bcst = 4850,

        /// <summary>
        /// vpxord ymm {k1}{z}, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpxord ymm {k1}{z}, ymm, ymm","vpxord ymm {k1}{z}, ymm, ymm |  | ")]
        vpxord_ymm_k1z_ymm_ymm = 4851,

        /// <summary>
        /// vpxord ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpxord ymm, ymm, m256","vpxord ymm, ymm, m256 |  | ")]
        vpxord_ymm_ymm_m256 = 4852,

        /// <summary>
        /// vpxord ymm, ymm, m32bcst |  | 
        /// </summary>
        [Symbol("vpxord ymm, ymm, m32bcst","vpxord ymm, ymm, m32bcst |  | ")]
        vpxord_ymm_ymm_m32bcst = 4853,

        /// <summary>
        /// vpxord ymm, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpxord ymm, ymm, ymm","vpxord ymm, ymm, ymm |  | ")]
        vpxord_ymm_ymm_ymm = 4854,

        /// <summary>
        /// vpxord zmm {k1}{z}, zmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpxord zmm {k1}{z}, zmm, m32bcst","vpxord zmm {k1}{z}, zmm, m32bcst |  | ")]
        vpxord_zmm_k1z_zmm_m32bcst = 4855,

        /// <summary>
        /// vpxord zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpxord zmm {k1}{z}, zmm, m512","vpxord zmm {k1}{z}, zmm, m512 |  | ")]
        vpxord_zmm_k1z_zmm_m512 = 4856,

        /// <summary>
        /// vpxord zmm {k1}{z}, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpxord zmm {k1}{z}, zmm, zmm","vpxord zmm {k1}{z}, zmm, zmm |  | ")]
        vpxord_zmm_k1z_zmm_zmm = 4857,

        /// <summary>
        /// vpxord zmm, zmm, m32bcst |  | 
        /// </summary>
        [Symbol("vpxord zmm, zmm, m32bcst","vpxord zmm, zmm, m32bcst |  | ")]
        vpxord_zmm_zmm_m32bcst = 4858,

        /// <summary>
        /// vpxord zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpxord zmm, zmm, m512","vpxord zmm, zmm, m512 |  | ")]
        vpxord_zmm_zmm_m512 = 4859,

        /// <summary>
        /// vpxord zmm, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpxord zmm, zmm, zmm","vpxord zmm, zmm, zmm |  | ")]
        vpxord_zmm_zmm_zmm = 4860,

        /// <summary>
        /// vpxorq xmm {k1}{z}, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpxorq xmm {k1}{z}, xmm, m128","vpxorq xmm {k1}{z}, xmm, m128 |  | ")]
        vpxorq_xmm_k1z_xmm_m128 = 4861,

        /// <summary>
        /// vpxorq xmm {k1}{z}, xmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpxorq xmm {k1}{z}, xmm, m64bcst","vpxorq xmm {k1}{z}, xmm, m64bcst |  | ")]
        vpxorq_xmm_k1z_xmm_m64bcst = 4862,

        /// <summary>
        /// vpxorq xmm {k1}{z}, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpxorq xmm {k1}{z}, xmm, xmm","vpxorq xmm {k1}{z}, xmm, xmm |  | ")]
        vpxorq_xmm_k1z_xmm_xmm = 4863,

        /// <summary>
        /// vpxorq xmm, xmm, m128 |  | 
        /// </summary>
        [Symbol("vpxorq xmm, xmm, m128","vpxorq xmm, xmm, m128 |  | ")]
        vpxorq_xmm_xmm_m128 = 4864,

        /// <summary>
        /// vpxorq xmm, xmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpxorq xmm, xmm, m64bcst","vpxorq xmm, xmm, m64bcst |  | ")]
        vpxorq_xmm_xmm_m64bcst = 4865,

        /// <summary>
        /// vpxorq xmm, xmm, xmm |  | 
        /// </summary>
        [Symbol("vpxorq xmm, xmm, xmm","vpxorq xmm, xmm, xmm |  | ")]
        vpxorq_xmm_xmm_xmm = 4866,

        /// <summary>
        /// vpxorq ymm {k1}{z}, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpxorq ymm {k1}{z}, ymm, m256","vpxorq ymm {k1}{z}, ymm, m256 |  | ")]
        vpxorq_ymm_k1z_ymm_m256 = 4867,

        /// <summary>
        /// vpxorq ymm {k1}{z}, ymm, m64bcst |  | 
        /// </summary>
        [Symbol("vpxorq ymm {k1}{z}, ymm, m64bcst","vpxorq ymm {k1}{z}, ymm, m64bcst |  | ")]
        vpxorq_ymm_k1z_ymm_m64bcst = 4868,

        /// <summary>
        /// vpxorq ymm {k1}{z}, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpxorq ymm {k1}{z}, ymm, ymm","vpxorq ymm {k1}{z}, ymm, ymm |  | ")]
        vpxorq_ymm_k1z_ymm_ymm = 4869,

        /// <summary>
        /// vpxorq ymm, ymm, m256 |  | 
        /// </summary>
        [Symbol("vpxorq ymm, ymm, m256","vpxorq ymm, ymm, m256 |  | ")]
        vpxorq_ymm_ymm_m256 = 4870,

        /// <summary>
        /// vpxorq ymm, ymm, m64bcst |  | 
        /// </summary>
        [Symbol("vpxorq ymm, ymm, m64bcst","vpxorq ymm, ymm, m64bcst |  | ")]
        vpxorq_ymm_ymm_m64bcst = 4871,

        /// <summary>
        /// vpxorq ymm, ymm, ymm |  | 
        /// </summary>
        [Symbol("vpxorq ymm, ymm, ymm","vpxorq ymm, ymm, ymm |  | ")]
        vpxorq_ymm_ymm_ymm = 4872,

        /// <summary>
        /// vpxorq zmm {k1}{z}, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpxorq zmm {k1}{z}, zmm, m512","vpxorq zmm {k1}{z}, zmm, m512 |  | ")]
        vpxorq_zmm_k1z_zmm_m512 = 4873,

        /// <summary>
        /// vpxorq zmm {k1}{z}, zmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpxorq zmm {k1}{z}, zmm, m64bcst","vpxorq zmm {k1}{z}, zmm, m64bcst |  | ")]
        vpxorq_zmm_k1z_zmm_m64bcst = 4874,

        /// <summary>
        /// vpxorq zmm {k1}{z}, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpxorq zmm {k1}{z}, zmm, zmm","vpxorq zmm {k1}{z}, zmm, zmm |  | ")]
        vpxorq_zmm_k1z_zmm_zmm = 4875,

        /// <summary>
        /// vpxorq zmm, zmm, m512 |  | 
        /// </summary>
        [Symbol("vpxorq zmm, zmm, m512","vpxorq zmm, zmm, m512 |  | ")]
        vpxorq_zmm_zmm_m512 = 4876,

        /// <summary>
        /// vpxorq zmm, zmm, m64bcst |  | 
        /// </summary>
        [Symbol("vpxorq zmm, zmm, m64bcst","vpxorq zmm, zmm, m64bcst |  | ")]
        vpxorq_zmm_zmm_m64bcst = 4877,

        /// <summary>
        /// vpxorq zmm, zmm, zmm |  | 
        /// </summary>
        [Symbol("vpxorq zmm, zmm, zmm","vpxorq zmm, zmm, zmm |  | ")]
        vpxorq_zmm_zmm_zmm = 4878,

        /// <summary>
        /// xbegin rel16 |  | 
        /// </summary>
        [Symbol("xbegin rel16","xbegin rel16 |  | ")]
        xbegin_rel16 = 4879,

        /// <summary>
        /// xbegin rel32 |  | 
        /// </summary>
        [Symbol("xbegin rel32","xbegin rel32 |  | ")]
        xbegin_rel32 = 4880,

        /// <summary>
        /// xchg AX, r16 |  | 
        /// </summary>
        [Symbol("xchg AX, r16","xchg AX, r16 |  | ")]
        xchg_AX_r16 = 4881,

        /// <summary>
        /// xchg EAX, r32 |  | 
        /// </summary>
        [Symbol("xchg EAX, r32","xchg EAX, r32 |  | ")]
        xchg_EAX_r32 = 4882,

        /// <summary>
        /// xchg m16, r16 |  | 
        /// </summary>
        [Symbol("xchg m16, r16","xchg m16, r16 |  | ")]
        xchg_m16_r16 = 4883,

        /// <summary>
        /// xchg m32, r32 |  | 
        /// </summary>
        [Symbol("xchg m32, r32","xchg m32, r32 |  | ")]
        xchg_m32_r32 = 4884,

        /// <summary>
        /// xchg m64, r64 |  | 
        /// </summary>
        [Symbol("xchg m64, r64","xchg m64, r64 |  | ")]
        xchg_m64_r64 = 4885,

        /// <summary>
        /// xchg m8, r8 |  | 
        /// </summary>
        [Symbol("xchg m8, r8","xchg m8, r8 |  | ")]
        xchg_m8_r8 = 4886,

        /// <summary>
        /// xchg r16, AX |  | 
        /// </summary>
        [Symbol("xchg r16, AX","xchg r16, AX |  | ")]
        xchg_r16_AX = 4887,

        /// <summary>
        /// xchg r16, m16 |  | 
        /// </summary>
        [Symbol("xchg r16, m16","xchg r16, m16 |  | ")]
        xchg_r16_m16 = 4888,

        /// <summary>
        /// xchg r16, r16 |  | 
        /// </summary>
        [Symbol("xchg r16, r16","xchg r16, r16 |  | ")]
        xchg_r16_r16 = 4889,

        /// <summary>
        /// xchg r32, EAX |  | 
        /// </summary>
        [Symbol("xchg r32, EAX","xchg r32, EAX |  | ")]
        xchg_r32_EAX = 4890,

        /// <summary>
        /// xchg r32, m32 |  | 
        /// </summary>
        [Symbol("xchg r32, m32","xchg r32, m32 |  | ")]
        xchg_r32_m32 = 4891,

        /// <summary>
        /// xchg r32, r32 |  | 
        /// </summary>
        [Symbol("xchg r32, r32","xchg r32, r32 |  | ")]
        xchg_r32_r32 = 4892,

        /// <summary>
        /// xchg r64, m64 |  | 
        /// </summary>
        [Symbol("xchg r64, m64","xchg r64, m64 |  | ")]
        xchg_r64_m64 = 4893,

        /// <summary>
        /// xchg r64, r64 |  | 
        /// </summary>
        [Symbol("xchg r64, r64","xchg r64, r64 |  | ")]
        xchg_r64_r64 = 4894,

        /// <summary>
        /// xchg r64, RAX |  | 
        /// </summary>
        [Symbol("xchg r64, RAX","xchg r64, RAX |  | ")]
        xchg_r64_RAX = 4895,

        /// <summary>
        /// xchg r8, m8 |  | 
        /// </summary>
        [Symbol("xchg r8, m8","xchg r8, m8 |  | ")]
        xchg_r8_m8 = 4896,

        /// <summary>
        /// xchg r8, r8 |  | 
        /// </summary>
        [Symbol("xchg r8, r8","xchg r8, r8 |  | ")]
        xchg_r8_r8 = 4897,

        /// <summary>
        /// xchg RAX, r64 |  | 
        /// </summary>
        [Symbol("xchg RAX, r64","xchg RAX, r64 |  | ")]
        xchg_RAX_r64 = 4898,

        /// <summary>
        /// xgetbv |  | 
        /// </summary>
        [Symbol("xgetbv","xgetbv |  | ")]
        xgetbv = 4899,

        /// <summary>
        /// xlat m8 |  | 
        /// </summary>
        [Symbol("xlat m8","xlat m8 |  | ")]
        xlat_m8 = 4900,

        /// <summary>
        /// xlatb |  | 
        /// </summary>
        [Symbol("xlatb","xlatb |  | ")]
        xlatb = 4901,

        /// <summary>
        /// xor AL, imm8 |  | 
        /// </summary>
        [Symbol("xor AL, imm8","xor AL, imm8 |  | ")]
        xor_AL_imm8 = 4902,

        /// <summary>
        /// xor AX, imm16 |  | 
        /// </summary>
        [Symbol("xor AX, imm16","xor AX, imm16 |  | ")]
        xor_AX_imm16 = 4903,

        /// <summary>
        /// xor EAX, imm32 |  | 
        /// </summary>
        [Symbol("xor EAX, imm32","xor EAX, imm32 |  | ")]
        xor_EAX_imm32 = 4904,

        /// <summary>
        /// xor m16, imm16 |  | 
        /// </summary>
        [Symbol("xor m16, imm16","xor m16, imm16 |  | ")]
        xor_m16_imm16 = 4905,

        /// <summary>
        /// xor m16, imm8 |  | 
        /// </summary>
        [Symbol("xor m16, imm8","xor m16, imm8 |  | ")]
        xor_m16_imm8 = 4906,

        /// <summary>
        /// xor m16, r16 |  | 
        /// </summary>
        [Symbol("xor m16, r16","xor m16, r16 |  | ")]
        xor_m16_r16 = 4907,

        /// <summary>
        /// xor m32, imm32 |  | 
        /// </summary>
        [Symbol("xor m32, imm32","xor m32, imm32 |  | ")]
        xor_m32_imm32 = 4908,

        /// <summary>
        /// xor m32, imm8 |  | 
        /// </summary>
        [Symbol("xor m32, imm8","xor m32, imm8 |  | ")]
        xor_m32_imm8 = 4909,

        /// <summary>
        /// xor m32, r32 |  | 
        /// </summary>
        [Symbol("xor m32, r32","xor m32, r32 |  | ")]
        xor_m32_r32 = 4910,

        /// <summary>
        /// xor m64, imm32 |  | 
        /// </summary>
        [Symbol("xor m64, imm32","xor m64, imm32 |  | ")]
        xor_m64_imm32 = 4911,

        /// <summary>
        /// xor m64, imm8 |  | 
        /// </summary>
        [Symbol("xor m64, imm8","xor m64, imm8 |  | ")]
        xor_m64_imm8 = 4912,

        /// <summary>
        /// xor m64, r64 |  | 
        /// </summary>
        [Symbol("xor m64, r64","xor m64, r64 |  | ")]
        xor_m64_r64 = 4913,

        /// <summary>
        /// xor m8, imm8 |  | 
        /// </summary>
        [Symbol("xor m8, imm8","xor m8, imm8 |  | ")]
        xor_m8_imm8 = 4914,

        /// <summary>
        /// xor m8, r8 |  | 
        /// </summary>
        [Symbol("xor m8, r8","xor m8, r8 |  | ")]
        xor_m8_r8 = 4915,

        /// <summary>
        /// xor r16, imm16 |  | 
        /// </summary>
        [Symbol("xor r16, imm16","xor r16, imm16 |  | ")]
        xor_r16_imm16 = 4916,

        /// <summary>
        /// xor r16, imm8 |  | 
        /// </summary>
        [Symbol("xor r16, imm8","xor r16, imm8 |  | ")]
        xor_r16_imm8 = 4917,

        /// <summary>
        /// xor r16, m16 |  | 
        /// </summary>
        [Symbol("xor r16, m16","xor r16, m16 |  | ")]
        xor_r16_m16 = 4918,

        /// <summary>
        /// xor r16, r16 |  | 
        /// </summary>
        [Symbol("xor r16, r16","xor r16, r16 |  | ")]
        xor_r16_r16 = 4919,

        /// <summary>
        /// xor r32, imm32 |  | 
        /// </summary>
        [Symbol("xor r32, imm32","xor r32, imm32 |  | ")]
        xor_r32_imm32 = 4920,

        /// <summary>
        /// xor r32, imm8 |  | 
        /// </summary>
        [Symbol("xor r32, imm8","xor r32, imm8 |  | ")]
        xor_r32_imm8 = 4921,

        /// <summary>
        /// xor r32, m32 |  | 
        /// </summary>
        [Symbol("xor r32, m32","xor r32, m32 |  | ")]
        xor_r32_m32 = 4922,

        /// <summary>
        /// xor r32, r32 |  | 
        /// </summary>
        [Symbol("xor r32, r32","xor r32, r32 |  | ")]
        xor_r32_r32 = 4923,

        /// <summary>
        /// xor r64, imm32 |  | 
        /// </summary>
        [Symbol("xor r64, imm32","xor r64, imm32 |  | ")]
        xor_r64_imm32 = 4924,

        /// <summary>
        /// xor r64, imm8 |  | 
        /// </summary>
        [Symbol("xor r64, imm8","xor r64, imm8 |  | ")]
        xor_r64_imm8 = 4925,

        /// <summary>
        /// xor r64, m64 |  | 
        /// </summary>
        [Symbol("xor r64, m64","xor r64, m64 |  | ")]
        xor_r64_m64 = 4926,

        /// <summary>
        /// xor r64, r64 |  | 
        /// </summary>
        [Symbol("xor r64, r64","xor r64, r64 |  | ")]
        xor_r64_r64 = 4927,

        /// <summary>
        /// xor r8, imm8 |  | 
        /// </summary>
        [Symbol("xor r8, imm8","xor r8, imm8 |  | ")]
        xor_r8_imm8 = 4928,

        /// <summary>
        /// xor r8, m8 |  | 
        /// </summary>
        [Symbol("xor r8, m8","xor r8, m8 |  | ")]
        xor_r8_m8 = 4929,

        /// <summary>
        /// xor r8, r8 |  | 
        /// </summary>
        [Symbol("xor r8, r8","xor r8, r8 |  | ")]
        xor_r8_r8 = 4930,

        /// <summary>
        /// xor RAX, imm32 |  | 
        /// </summary>
        [Symbol("xor RAX, imm32","xor RAX, imm32 |  | ")]
        xor_RAX_imm32 = 4931,

        /// <summary>
        /// xsave mem |  | 
        /// </summary>
        [Symbol("xsave mem","xsave mem |  | ")]
        xsave_mem = 4932,

        /// <summary>
        /// xsave64 mem |  | 
        /// </summary>
        [Symbol("xsave64 mem","xsave64 mem |  | ")]
        xsave64_mem = 4933,

        /// <summary>
        /// xsavec mem |  | 
        /// </summary>
        [Symbol("xsavec mem","xsavec mem |  | ")]
        xsavec_mem = 4934,

        /// <summary>
        /// xsavec64 mem |  | 
        /// </summary>
        [Symbol("xsavec64 mem","xsavec64 mem |  | ")]
        xsavec64_mem = 4935,

        /// <summary>
        /// xsetbv |  | 
        /// </summary>
        [Symbol("xsetbv","xsetbv |  | ")]
        xsetbv = 4936,
    }
}

