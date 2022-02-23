//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    using llvm;

    public sealed partial class AsmCmdProvider : AppCmdProvider<AsmCmdProvider>
    {
        AsmRegSets Regs => Service(AsmRegSets.create);

        IntelSdm Sdm => Service(Wf.IntelSdm);

        AsmGen AsmGen => Service(AsmGen.generator);

        AsmDocs AsmDocs => Service(Wf.AsmDocs);

        AsmOpCodes OpCodes => Service(Wf.AsmOpCodes);

        AsmCodeGen AsmCodeGen => Service(Wf.AsmCodeGen);

        X86Dispatcher JmpStubs => Service(() => X86Dispatcher.create(Wf));

        ApiCodeBanks ApiCodeBanks => Service(Wf.ApiCodeBanks);

        EncodingCollector CodeCollector => Service(Wf.EncodingCollector);

        LlvmMcSvc LlvmMc => Service(Wf.LlvmMc);

        LlvmObjDumpSvc ObjDump => Service(Wf.LlvmObjDump);

        WsProjects Projects => Service(Wf.WsProjects);

        AsmObjects AsmObjects => Service(Wf.AsmObjects);

        CoffServices CoffServices => Service(Wf.CoffServices);

        IProjectProvider _ProjectProvider;

        public AsmCmdProvider With(IProjectProvider provider)
        {
            _ProjectProvider = provider;
            return this;
        }

        IProjectWs Project()
            => _ProjectProvider.Project();
    }
}