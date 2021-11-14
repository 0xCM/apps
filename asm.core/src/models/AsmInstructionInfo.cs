//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Describes an assembly instruction
    /// </summary>
    public class AsmInstructionInfo
    {
        /// <summary>
        /// The encoded bytes
        /// </summary>
        public CodeBlock Encoded {get;}

        /// <summary>
        /// The zero-based offset of the function, relative to the base address
        /// </summary>
        public uint Offset {get;}

        /// <summary>
        /// The instruction content, suitable for display
        /// </summary>
        public AsmExpr Statement {get;}

        /// <summary>
        /// The instruction string paired with the op code
        /// </summary>
        public AsmFormInfo AsmForm {get;}

        [MethodImpl(Inline)]
        public AsmInstructionInfo(MemoryAddress @base, uint offset, AsmExpr statment, AsmFormInfo form, byte[] code)
        {
            Encoded = new CodeBlock(@base, code);
            Offset = offset;
            Statement = statment;
            AsmForm = form;
        }
    }
}