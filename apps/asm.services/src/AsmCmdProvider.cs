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

        IProjectProvider _ProjectProvider;

        public AsmCmdProvider With(IProjectProvider provider)
        {
            _ProjectProvider = provider;
            return this;
        }

        public IProjectWs Project()
            => _ProjectProvider.Project();
    }
}