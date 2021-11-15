//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static WsNames;

    public sealed class DevWs : IWorkspace<DevWs>
    {
        [MethodImpl(Inline)]
        public static DevWs create(FS.FolderPath root)
            => new DevWs(root);

        FS.FolderPath _WsRoot;

        FS.FolderPath _OutRoot;

        EnvData EnvData;

        [MethodImpl(Inline)]
        DevWs(FS.FolderPath root)
        {
            _WsRoot = root;
            _OutRoot = FS.dir("j:/ws/.out");
            EnvData = Env.load().Data;
        }

        public FS.FolderPath Root
        {
            [MethodImpl(Inline)]
            get => _WsRoot;
        }

        public Outcome Select(Identifier name, out IWorkspace dst)
        {
            var result = Outcome.Failure;
            dst = default;
            var id = name.Format();
            switch(id)
            {
                case api:
                    dst = Api();
                break;
                case envdb:
                    dst = EnvDb();
                break;
                case asm:
                    dst = Asm();
                break;
                case control:
                    dst = Control();
                break;
                case docs:
                    dst = Docs();
                break;
                case projects:
                    dst = Projects();
                break;
                case sources:
                    dst = Sources();
                break;
                case logs:
                    dst = Logs();
                break;
                case gen:
                    dst = Gen();
                break;
                case tools:
                    dst = Tools();
                break;
                case tables:
                    dst = Tables();
                break;
                case output:
                    dst = Output();
                break;
                case imports:
                    dst = Imports();
                break;
            }
            if(dst != null)
                result = true;
            return result;
        }

        public IWorkspace Api()
            => ApiWs.create(_WsRoot + FS.folder(api));

        public IWorkspace Asm()
            => AsmWs.create(_WsRoot + FS.folder(asm));

        public IEnvWs EnvDb()
            => EnvWs.create(EnvData.ZEnvDb);

        public IToolWs Tools()
            => ToolWs.create(_WsRoot + FS.folder(tools));

        public IWorkspace Tables()
            => TableWs.create(_WsRoot + FS.folder(tables));

        public IWorkspace Control()
            => ControlWs.create(_WsRoot + FS.folder(control));

        public IWorkspace Docs()
            => DocsWs.create(_WsRoot + FS.folder(docs));

        public IProjectWs Project(ProjectId id)
            => ProjectWs.create(_WsRoot + FS.folder(projects), id);

        public IProjectSet Projects()
            => ProjectSet.create(_WsRoot + FS.folder(projects));

        public IWorkspace Sources()
            => SourcesWs.create(_WsRoot + FS.folder(sources));

        public IWorkspace Logs()
            => LogWs.create(_WsRoot + FS.folder(logs));

        public IWorkspace Gen()
            => GenWs.create(_WsRoot + FS.folder(gen));

        public IWorkspace Output()
            => OutputWs.create(_OutRoot);

        public IWorkspace Imports()
            => ImportsWs.create(_WsRoot + FS.folder(imports));

        public string Format()
            => _WsRoot.Format();

        public override string ToString()
            => Format();
    }
}