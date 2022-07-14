//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using K = ApiMdKind;

    public class SosCmd : AppCmdService<SosCmd>
    {
        ApiMd ApiMd => Wf.ApiMetadata();

        PdbIndexBuilder PdbIndexBuilder => Wf.PdbIndexBuilder();

        PdbSvc PdbSvc => Wf.PdbSvc();

        [CmdOp("api/emit/pdb-info")]
        void EmitApiPdbInfo()
            => PdbSvc.EmitPdbInfo(ApiMd.Components.Single(c => c.GetSimpleName().Contains("z0.circuits")));

        [CmdOp("api/emit/pdb-index")]
        void IndexApiPdbFiles()
            => PdbIndexBuilder.IndexComponents(ApiMd.Components, new PdbIndex());

        public Index<BitMaskInfo> ApiBitMasks
            => Data(K.BitMasks, () => BitMask.masks(typeof(BitMaskLiterals)));


    }
}