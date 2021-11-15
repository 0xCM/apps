//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    /// <summary>
    /// Classifies prefix domains
    /// </summary>
    public enum AsmPrefixKind : byte
    {
        None = 0,

        SegOverride,

        SizeOverride,

        Escape,

        Lock,

        Bnd,

        BranchHint,

        Rep,

        Mandatory,

        Rex,

        Vex,

        EVex
    }
}