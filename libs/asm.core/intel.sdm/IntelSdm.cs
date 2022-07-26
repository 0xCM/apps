//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [ApiHost]
    public partial class IntelSdm : WfSvc<IntelSdm>
    {
        CharMapper CharMapper => Service(Wf.CharMapper);

        IntelSdmPaths SdmPaths;

        protected override void OnInit()
        {
            SdmPaths = IntelSdmPaths.create(Wf);
        }

        TextMap SigNormalRules
            => Data(nameof(SigNormalRules), () => Rules.textmap(SdmPaths.SigNormalConfig()));

        TextReplace OcFixupRules
            => Data(nameof(OcFixupRules), () => Rules.replace(SdmPaths.OcFixupConfig()));

        TextReplace SigFixupRules
            => Data(nameof(SigFixupRules), () => Rules.replace(SdmPaths.SigFixupConfig()));

        void Clear()
        {
            SdmPaths.Output().Clear();
            ClearCache();
        }

        public void RunEtl()
        {
            Clear();

            EmitCharMaps();

            ImportVolume(1);

            ImportVolume(2);

            ImportVolume(3);

            ImportVolume(4);

            EmitSdmSplits();

            EmitCombinedToc();

            EmitTocRecords();

            EmitTokens();
            var details = CalcOcDetails();
            Emit(details);

            EmitSigOps(EmitForms(details));
        }
   }
}