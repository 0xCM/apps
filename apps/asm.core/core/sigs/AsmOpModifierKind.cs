//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [SymSource("asm")]
    public enum AsmOpModifierKind : byte
    {
        None,

        [Symbol("{k1}")]
        k1 = 1,

        [Symbol("{z}")]
        z = 2,

        [Symbol("{k1}{z}")]
        k1z = k1 | z,

        [Symbol("{k2}")]
        k2 = 4,

        [Symbol("{er}")]
        er = 8,

        [Symbol("{sae}")]
        sae = 16,
    }
}