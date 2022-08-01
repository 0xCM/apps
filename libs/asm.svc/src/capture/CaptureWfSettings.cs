//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Settings("capture")]
    public struct CaptureWfSettings : IWfSettings<CaptureWfSettings>
    {
        public bit PllExec;

        public bit EmitCatalog;

        public bit EmitMetadata;

        public bit EmitContext;

        public bit EmitRegions;

        public bit RunChecks;

        public bit PurgeTarget;

        public Seq<PartId> Parts;

        public CaptureWfSettings()
        {
            PllExec = true;
            EmitCatalog = false;
            EmitMetadata = true;
            EmitContext = true;
            EmitRegions = true;
            RunChecks = false;
            PurgeTarget = false;
            Parts = sys.empty<PartId>();
        }

        public static IWfSettings<CaptureWfSettings> Default
            => new CaptureWfSettings();
    }    
}