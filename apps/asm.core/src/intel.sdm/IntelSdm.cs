//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    [ApiHost]
    public partial class IntelSdm : AppService<IntelSdm>
    {
        const string lined = nameof(lined);

        CharMapper CharMapper;

        IntelSdmPaths SdmPaths;

        protected override void OnInit()
        {
            CharMapper = Wf.CharMapper();
            SdmPaths = IntelSdmPaths.create(Wf);
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

                ImportOpCodes();

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