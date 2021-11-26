//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using System.Collections.Generic;

    using Asm;

    using static core;


    [Tool(ToolId)]
    public class LlvmLlc : ToolService<LlvmLlc>
    {
        public const string ToolId = LlvmNames.Tools.llc;

        public LlvmLlc()
            : base(ToolId)
        {


        }
    }
}
