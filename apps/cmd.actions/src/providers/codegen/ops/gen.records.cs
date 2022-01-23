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
            var g = CodeGen.Records();
            var dst = text.buffer();
            iter(ApiRuntimeCatalog.TableDefs, src => g.Emit(0u,src,dst));
            Write(dst.Emit());

            return true;
        }
    }
}