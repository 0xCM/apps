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
        CharMapper CharMapper;

        IntelSdmPaths SdmPaths;

        TextMap SigOpNormal;

        TextMap SigOpProd;

        Productions SigAtomics;

        protected override void OnInit()
        {
            CharMapper = Wf.CharMapper();
            SdmPaths = IntelSdmPaths.create(Wf);
            SigOpNormal = Rules.textmap(ProjectDb.Settings("asm.sigs.normal", FS.ext("map")));
            SigOpProd = Rules.textmap(ProjectDb.Settings("asm.sigs.productions", FS.ext("map")));
            SigAtomics = Rules.productions(ProjectDb.Settings("asm.sigs.atomics", FS.ext("map")));
        }

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

                var details = ImportOpCodeDetails();
                EmitSigs(details);

                EmitSigDecomps();

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

            }
            catch(Exception e)
            {
                result = e;
            }

            return result;
        }
    }
}