//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [SymSource]
    public enum CgTarget : byte
    {
        None,

        [Symbol("codegen.common")]
        Common,

        [Symbol("codegen.intel")]
        Intel,

        [Symbol("codegen.llvm")]
        Llvm,

        [Symbol("codegen.respack")]
        Respack
    }
}