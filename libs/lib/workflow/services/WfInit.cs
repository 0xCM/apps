//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Captures workflow configuration data
    /// </summary>
    public class WfInit
    {
        public Assembly Control;

        public PartId ControlId;

        public WfLogConfig LogConfig;

        public IApiParts ApiParts;

        public IJsonSettings Settings;

        public string[] Args;

        public IAppPaths Paths;

        public PartName AppName;

        public TokenDispenser Tokens;

        public PartToken Ct;

        public IEventBroker EventBroker;

        public WfHost Host;

        public IWfEmissionLog EmissionLog;
    }
}