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

        TextMap SigNormalRules()
            => Data(nameof(SigNormalRules), () => Rules.textmap(SdmPaths.SigNormalRules()));

        TextReplace OcReplaceRules()
            => Data(nameof(OcReplaceRules), () => Rules.replace(SdmPaths.OcReplaceRules()));

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

                ImportOpCodes();

            }
            catch(Exception e)
            {
                result = e;
            }

            return result;
        }

        void ImportOpCodes()
        {
            var details = ImportOpCodeDetails();
            EmitSigs(details);
            var result = SigOpRules.EmitSigProductions(details,true);
            if(result.Fail)
            {
                Error(result.Message);
                return;
            }

            SigOpRules.EmitTerminals();
        }
    }
}