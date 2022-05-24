//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ProjectProvider : IProjectProvider
    {
        public static ProjectProvider create(IProjectWs ws)
            => new ProjectProvider(Require.notnull(ws));

        readonly IProjectWs Ws;

        [MethodImpl(Inline)]
        ProjectProvider(IProjectWs ws)
        {
            Ws = ws;
        }

        public IProjectWs Project()
            => default;
    }
}