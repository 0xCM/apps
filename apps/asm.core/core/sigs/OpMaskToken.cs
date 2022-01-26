//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [SymSource("asm.sigs")]
    public enum OpMaskToken : byte
    {
        [Symbol("xmm_k1z")]
        xmm_k1z,

        [Symbol("ymm_k1z")]
        ymm_k1z,

        [Symbol("zmm_k1z")]
        zmm_k1z,

        [Symbol("k2_k1")]
        k2_k1,

        [Symbol("k1_k2")]
        k1_k2,

        [Symbol("m128_k1z")]
        m128_k1z,

        [Symbol("m256_k1z")]
        m256_k1z,

        [Symbol("m512_k1z")]
        m512_k1z,
    }
}