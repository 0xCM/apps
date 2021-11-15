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

        const string toc = nameof(toc);

        DocServices DocServices;

        CharMapper CharMapper;

        IntelSdmPaths SdmPaths;

        StringTableGen StringTableGen;

        protected override void OnInit()
        {
            DocServices = Wf.DocServices();
            CharMapper = Wf.CharMapper();
            SdmPaths = IntelSdmPaths.create(Wf);
            StringTableGen = Wf.Generators().StringTable();
        }

        public void ClearTargets()
        {
            SdmPaths.Imports().Clear();
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