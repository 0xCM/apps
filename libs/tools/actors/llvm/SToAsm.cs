//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Tools
    {
        /// <summary>
        /// *.s -> *.asm
        /// </summary>
        public class SToAsm : FileFlow<SToAsm,LlvmMc>
        {
            public SToAsm()
                :base(llvm_mc, FileKind.S, FileKind.Asm)
            {

            }
        }
    }
}