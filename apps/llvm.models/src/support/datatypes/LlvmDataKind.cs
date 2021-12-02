//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    [SymSource(nameof(llvm))]
    public enum LlvmDataKind : byte
    {
        [Symbol("unknown")]
        Other,

        [Symbol("bit")]
        Bit,

        [Symbol("string")]
        String,

        [Symbol("int")]
        Int,

        [Symbol("list<{0}>")]
        List,

        [Symbol("bits<{0}>")]
        Bits,

        [Symbol("dag")]
        Dag,
    }
}