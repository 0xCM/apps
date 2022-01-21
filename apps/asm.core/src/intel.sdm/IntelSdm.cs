//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    using static core;

    [ApiHost]
    public partial class IntelSdm : AppService<IntelSdm>
    {
        CharMapper CharMapper => Service(Wf.CharMapper);

        SdmSigOpRules SigOpRules => Service(() => SdmSigOpRules.create(Wf));

        IntelSdmPaths SdmPaths;

        protected override void OnInit()
        {
            SdmPaths = IntelSdmPaths.create(Wf);
        }

        TextMap SigNormalizationRules()
            => Data(nameof(SigNormalizationRules), () => Rules.textmap(ProjectDb.Settings("asm.sigs.normalize", FS.ext("map"))));

        public void ClearTargets()
        {
            SdmPaths.Targets().Clear();
        }

        public Outcome Import()
        {
            var result = Outcome.Success;

            try
            {
                ClearTargets();

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

                var details = ImportOpCodeDetails();
                EmitSigs(details);
                EmitSigDecomps(details);
            }
            catch(Exception e)
            {
                result = e;
            }

            return result;
        }
    }
}