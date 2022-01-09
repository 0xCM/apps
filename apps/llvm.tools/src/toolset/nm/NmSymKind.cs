//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    public enum NmSymKind : byte
    {
        None,

        AbsoluteSymbol,

        BssSection,

        BssObject,

        CodeObject,

        CodeSection,

        Common,

        CoffDebugSymbol,

        DataSection,

        DataObject,

        ReadOnlyDataSection,

        ReadOnlyDataObject,

        DebugSymbol,

        UndefinedSymbol,

        Other,
    }
}