//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using System.Runtime.InteropServices;

    [Cmd(LlvmNames.Tools.llvm_mc), StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct McCmd : IToolCmd<McCmd>
    {
        [CmdFlag("--assemble")]
        public bit Assemble;

        [CmdArg("--filetype={0}")]
        public text7 FileType;

        [CmdArg("--target-abi={0}")]
        public text15 TargetAbi;

        [CmdArg("--triple={0}")]
        public text31 Triple;
    }
}