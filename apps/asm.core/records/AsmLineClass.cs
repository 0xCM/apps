//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public enum AsmLineClass : byte
    {
        None,

        Empty,

        Directive,

        Label,

        AsmSource
    }
}