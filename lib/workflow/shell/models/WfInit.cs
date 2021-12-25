//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection;

    using static Root;

    /// <summary>
    /// Captures workflow configuration data
    /// </summary>
    struct WfInit : IWfInit
    {
        /// <summary>
        /// The entry assembly
        /// </summary>
        public Assembly Control {get;}

        /// <summary>
        /// The entry assembly identifier
        /// </summary>
        public PartId ControlId {get;}

        /// <summary>
        /// The parts considered by the workflow
        /// </summary>
        public PartId[] PartIdentities {get;}

        /// <summary>
        /// The context root
        /// </summary>
        public IWfContext Context {get;}

        /// <summary>
        /// The specified log configuration
        /// </summary>
        public WfLogConfig LogConfig {get;}

        /// <summary>
        /// The input data archive configuration
        /// </summary>
        public IApiParts ApiParts {get;}

        public IApiCatalog ApiGlobal {get;}

        [MethodImpl(Inline)]
        public WfInit(IWfContext ctx, WfLogConfig logConfig, PartId[] parts)
        {
            Context = ctx;
            ApiParts = ctx.ApiParts;
            Control = ctx.Controller;
            ApiGlobal = ctx.ApiParts.Catalog;
            ControlId = ctx.Controller.Id;
            LogConfig = logConfig;
            PartIdentities = parts;
        }

        public IWfContext Shell
            => Context;
    }
}