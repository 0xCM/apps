//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    public partial class AsmCoreCmd : WsCmdService<AsmCoreCmd>
    {
        protected override AppDb AppDb
            => Xed.AppDb;

        protected override WsProjects Projects
            => Xed.Projects;

        AsmOpCodes OpCodes => Service(Wf.AsmOpCodes);

        CsLang CsLang => Service(Wf.CsLang);

        BitMaskServices ApiBitMasks => Service(Wf.ApiBitMasks);

        ApiComments ApiComments => Service(Wf.ApiComments);

        AsmDocs AsmDocs => Service(Wf.AsmDocs);

        AsmTables AsmTables => Service(Wf.AsmTables);

        AsmCodeGen AsmCodeGen => Service(Wf.AsmCodeGen);

        X86Dispatcher Jumps => Service(() => X86Dispatcher.create(Wf));

        IntelSdm Sdm => Service(Wf.IntelSdm);

        ApiCodeBanks ApiCodeBanks => Service(Wf.ApiCodeBanks);

        ApiDataPaths ApiDataPaths => Service(Wf.ApiDataPaths);

        EncodingCollector CodeCollector => Service(Wf.EncodingCollector);

        AsmObjects AsmObjects => Service(Wf.AsmObjects);

        CoffServices CoffServices => Service(Wf.CoffServices);

        AsmRegSets Regs => Service(AsmRegSets.create);

        protected override void Initialized()
        {
            LoadProject("canonical");
        }
    }
}