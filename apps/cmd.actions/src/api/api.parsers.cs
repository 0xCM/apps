//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class ApiCmdProvider
    {
        [CmdOp("api/parsers")]
        Outcome RevealParsers(CmdArgs args)
        {
            // var parsers = Parsers.discover(ApiRuntimeCatalog.Components, out var log);
            // var targets = parsers.Keys;
            // foreach(var target in targets)
            //     Write(string.Format("parse:string -> {0}", target.DisplayName()));

            return true;
        }
    }
}