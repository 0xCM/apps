//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static Root;

    partial class CheckCmdProvider
    {
        [CmdOp("check/api/parsers")]
        Outcome CheckApiParsers(CmdArgs args)
        {
            var parser = Parsers.Service;
            var x = 32u;
            if(parser.Parse(x.ToString(), out uint dst))
            {
                Require.equal(x,dst);
            }
            return true;
        }
    }
}