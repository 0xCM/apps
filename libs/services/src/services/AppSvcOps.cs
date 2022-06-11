//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    public class AppSvcOps : WfSvc<AppSvcOps>
    {
        public new void Babble<T>(T content)
            => WfMsg.Babble(content);
    }
}