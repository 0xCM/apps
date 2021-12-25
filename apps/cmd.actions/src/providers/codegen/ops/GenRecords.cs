//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    using System;

    using static core;

    partial class CodeGenProvider
    {
        [CmdOp("gen/records")]
        Outcome GenRecords(CmdArgs args)
        {
            var g = Generators.Records();
            var src = Tables.schema(typeof(XedModels.OperandState));
            var dst =  text.buffer();
            g.Emit(0u,src,dst);
            Write(dst.Emit());
            return true;
        }
    }
}
