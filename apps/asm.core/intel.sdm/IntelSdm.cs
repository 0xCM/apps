//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    [ApiHost]
    public partial class IntelSdm : AppService<IntelSdm>
    {
        CharMapper CharMapper => Service(Wf.CharMapper);

        AppServices AppSvc => Service(Wf.AppServices);

        IntelSdmPaths SdmPaths;

        protected override void OnInit()
        {
            SdmPaths = IntelSdmPaths.create(Wf);
        }

        TextMap SigNormalRules
            => Data(nameof(SigNormalRules), () => Rules.textmap(SdmPaths.SigNormalRules()));

        TextReplace OcFixupRules
            => Data(nameof(OcFixupRules), () => Rules.replace(SdmPaths.OcFixupRules()));

        TextReplace SigFixupRules
            => Data(nameof(SigFixupRules), () => Rules.replace(SdmPaths.SigFixupRules()));

        void Clear()
        {
            SdmPaths.Targets().Clear();
            ClearCache();
        }

        public Outcome Import()
        {
            var result = Outcome.Success;

            try
            {
                Clear();

                result = EmitCharMaps();
                if(result.Fail)
                    return result;

                result = ImportVolume(1);
                if(result.Fail)
                    return result;

                result = ImportVolume(2);
                if(result.Fail)
                    return result;

                result = ImportVolume(3);
                if(result.Fail)
                    return result;

                result = ImportVolume(4);
                if(result.Fail)
                    return result;

                result = EmitSdmSplits();
                if(result.Fail)
                    return result;

                result = EmitCombinedToc();
                if(result.Fail)
                    return result;

                result = EmitTocRecords();
                if(result.Fail)
                    return result;

                EmitTokens();
                var details = CalcOcDetails();
                Emit(details);
                EmitSigOps(EmitForms(details));

            }
            catch(Exception e)
            {
                result = e;
            }

            return result;
        }
   }
}