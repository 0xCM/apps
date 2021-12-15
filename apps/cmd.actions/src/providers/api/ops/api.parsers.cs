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
        protected Outcome RevealParsers(CmdArgs args)
        {
            var src = Parsers.Identities;
            iter(src, x => Write(string.Format("parse:string -> {0}", x.Target.DisplayName())));
            return true;
        }
    }
}