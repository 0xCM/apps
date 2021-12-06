//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class GlobalCommands
    {
        [CmdOp("api/emit/symbols")]
        protected Outcome EmitSymLiterals(CmdArgs args)
        {
            var service = Wf.Symbolism();
            var dst = Db.AppTablePath<SymLiteralRow>();
            service.EmitLiterals(dst);
            return true;
        }
    }
}