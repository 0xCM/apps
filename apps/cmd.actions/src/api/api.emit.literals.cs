//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using L = LiteralProvider;

    partial class ApiCmdProvider
    {
        [CmdOp("api/emit/literals")]
        Outcome EmitApiLiterals(CmdArgs args)
        {
            var result = Outcome.Success;
            ApiSvc.EmitApiLiterals();
            return result;
        }
    }
}