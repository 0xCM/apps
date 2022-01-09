//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct WfContext : IWfContext
    {
        public IAppPaths Paths {get; internal set;}

        public IApiParts ApiParts {get; internal set;}

        public Index<PartId> PartIdentities {get; set;}

        public IJsonSettings Settings {get; internal set;}

        public PartId ControlId {get; internal set;}

        public string[] Args {get; internal set;}

        public WfController Controller {get; internal set;}
    }
}