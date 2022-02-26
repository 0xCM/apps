//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    /// <summary>
    /// Identifies refinement classes of the ModRm byte
    /// </summary>
    public enum ModRmKind
    {
        Other,

        /// <summary>
        /// Restricts the ModRm domain to values where mod[7:6] = 0b11
        /// </summary>
        Mod11 = 1,

        /// <summary>
        /// Restricts the ModRm domain to values where mod[7:6] != 0b11
        /// </summary>
        NotMod11 = 2,
    }
}