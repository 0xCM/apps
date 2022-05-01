//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedCmdProvider
    {
        ApiComments ApiComments => Service(Wf.ApiComments);

        [CmdOp("api/emit/markdown")]
        Outcome EmitMarkdownDocs(CmdArgs args)
        {
            ApiComments.EmitMarkdownDocs(array(nameof(vpack),nameof(vmask)));
            return true;
        }
    }
}