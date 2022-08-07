//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack=1), Settings(Id)]
    public struct CaptureWfSettings : IWfSettings<CaptureWfSettings>
    {
        const string Id = "capture";

        public bit PllExec;

        public bit EmitCatalog;

        public bit EmitMetadata;

        public bit EmitContext;

        public bit EmitRegions;

        public bit RunChecks;

        public bit PurgeTarget;

        public Seq<PartId> Parts;

        public CliEmissionSettings CliEmissions;

        public CaptureWfSettings()
        {
            PllExec = true;
            EmitCatalog = true;
            EmitMetadata = true;
            EmitContext = true;
            EmitRegions = true;
            RunChecks = false;
            PurgeTarget = false;
            CliEmissions = CliEmissionSettings.Default;
            Parts = sys.empty<PartId>();
        }

        public static IWfSettings<CaptureWfSettings> Default
            => new CaptureWfSettings();
    }    
}