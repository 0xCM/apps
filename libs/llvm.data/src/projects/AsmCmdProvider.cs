//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed partial class AsmCmdProvider : AppCmdProvider<AsmCmdProvider>, IProjectProvider
    {
        IProjectProvider _ProjectProvider;

        public IProjectWs Project()
            => _ProjectProvider.Project();
    }
}