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

        ApiMetadataService ApiMetadata => Service(Wf.ApiMetadata);

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

        Productions SigDecompRules
            => Data(nameof(SigDecompRules), () => Rules.productions(SdmPaths.SigDecompRules()));

        Productions SigOpMaskRules
            => Data(nameof(SigOpMaskRules), () => Rules.productions(SdmPaths.SigDecompRules()));

        void Clear()
        {
            SdmPaths.Targets().Clear();
            ClearCache();
        }


        void EmitTokens()
        {
            ApiMetadata.EmitTokenSet(AsmOcTokenSet.create(), SdmPaths.Tokens("opcodes"));
            ApiMetadata.EmitTokenSet(AsmSigTokenSet.create(), SdmPaths.Tokens("sigs"));
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
                ImportOpCodes();

            }
            catch(Exception e)
            {
                result = e;
            }

            return result;
        }
   }
}