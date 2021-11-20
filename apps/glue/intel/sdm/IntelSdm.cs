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

        StringTableGen StringTableGen;

        protected override void OnInit()
        {
            CharMapper = Wf.CharMapper();
            SdmPaths = IntelSdmPaths.create(Wf);
            StringTableGen = Wf.StringTableGen();
        }

        public void ClearTargets()
        {
            SdmPaths.Targets().Clear();
        }

        public Outcome RunEtl()
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

            }
            catch(Exception e)
            {
                Wf.Error(e);
                result = e;
            }

            return result;
        }
    }
}