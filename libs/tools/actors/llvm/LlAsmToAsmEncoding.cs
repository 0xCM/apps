//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using K = FileKind;

    partial class Tools
    {
        /// <summary>
        /// *ll.asm -> *.encoding.asm
        /// </summary>
        public class LlAsmToAsmEncoding : FileFlow<LlAsmToAsmEncoding,LlvmMc>
        {
            public LlAsmToAsmEncoding()
                : base(llvm_mc, K.Asm, K.EncAsm)
            {

            }
        }
    }
}