//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    public partial class XedCmdProvider : AppCmdProvider<XedCmdProvider>, IProjectConsumer<XedCmdProvider>
    {
        FS.FilePath XedQueryOut(string id)
            => ProjectDb.Subdir("xed/queries") + FS.file(text.replace(id, Chars.FSlash,Chars.Dot), FS.Csv);

        IntelXed Xed => Service(Wf.IntelXed);

        XedDisasmSvc Disasm => Service(Wf.XedDisasm);

        WsProjects Projects => Service(Wf.WsProjects);

        XedPaths XedPaths => Service(Wf.XedPaths);


        AppDb AppDb => Service(Wf.AppDb);

        IProjectProvider _ProjectProvider;

        public XedCmdProvider With(IProjectProvider provider)
        {
            _ProjectProvider = provider;
            return this;
        }

        IProjectWs Project()
            => _ProjectProvider.Project();

    }
}