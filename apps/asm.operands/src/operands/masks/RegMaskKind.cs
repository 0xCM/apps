//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [SymSource("asm")]
    public enum RegMaskKind : byte
    {
        None = 0,

        [Symbol("{k1}", "Merge-masking")]
        Merge = 1,

        [Symbol("{k1}{z}", "Zero-masking, where all unspecified elements in the target are zeroed-out")]
        Zero = 2,
    }
}