//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    public sealed partial class AsmCmdProvider : AppCmdProvider<AsmCmdProvider>, IProjectProvider
    {
        AsmRegSets Regs => Service(AsmRegSets.create);

        AsmDocs AsmDocs => Service(Wf.AsmDocs);

        AsmOpCodes OpCodes => Service(Wf.AsmOpCodes);

        ApiCodeBanks ApiCodeBanks => Service(Wf.ApiCodeBanks);

        EncodingCollector CodeCollector => Service(Wf.EncodingCollector);

        WsProjects Projects => Service(Wf.WsProjects);

        CoffServices CoffServices => Service(Wf.CoffServices);

        IProjectProvider _ProjectProvider;

        public AsmCmdProvider With(IProjectProvider provider)
        {
            _ProjectProvider = provider;
            return this;
        }

        public IProjectWs Project()
            => _ProjectProvider.Project();

        public IProjectWs Project(ProjectId id)
            => _ProjectProvider.Project(id);
    }
}