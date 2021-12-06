//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class GlobalCommands
    {
        [CmdOp("emit-sym-literals")]
        protected Outcome EmitSymLiterals(CmdArgs args)
        {
            var service = Wf.Symbolism();
            var dst = Db.AppTablePath<SymLiteralRow>();
            service.EmitLiterals(dst);
            return true;
        }
    }
}