//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    public class AppSvcOps : WfSvc<AppSvcOps>
    {

    }

    public sealed class AppSvcOps<T> : WfSvc<AppSvcOps<T>>
        where T : IAppService<T>, new()
    {
        public override Type EffectiveHost
            => typeof(T);
    }
}