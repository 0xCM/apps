//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class CaptureWorkflow
    {
        [Settings("capture")]
        public struct CaptureSettings : IWfSettings<CaptureSettings>
        {
            public bit EmitComments;

            public bit PllExec;

            public CaptureSettings()
            {
                EmitComments = true;
                PllExec = true;
            }

            public static IWfSettings<CaptureSettings> Default
                => new CaptureSettings();
        }
    }
}