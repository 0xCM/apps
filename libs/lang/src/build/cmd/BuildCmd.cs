//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    class BuildCmd : AppCmdService<BuildCmd>
    {
        BuildSvc BuildSvc => Wf.BuildSvc();

        [CmdOp("build/projects")]
        void LoadProjects()
        {
            var ws = AppDb.Dev("z0");
            var src = ws.Sources("props").Path(FS.file("projects", FileKind.Props));
            var project = BuildSvc.LoadProject(src);
            Write(project.Format());
        }

        [CmdOp("build/props")]
        void BuildProps(CmdArgs args)
        {
            var ws = AppDb.Dev("z0");
            var src =  ws.Sources("props").Path(FS.file(arg(args,0), FileKind.Props));
            var project = BuildSvc.LoadProject(src);
            var data = project.Format();
            Write(data);
            FileEmit(data, AppDb.App().Path(src.FileName.WithoutExtension.Format(), FileKind.Env), (ByteSize)data.Length);
        }

        [CmdOp("build/libinfo")]
        void BuildProject(CmdArgs args)
        {
            var ws = AppDb.Dev("z0");
            var id = arg(args,0).Value;
            var name = $"z0.{id}";
            var src =  ws.Sources($"libs/{id}").Path(FS.file(name, FileKind.CsProj));
            var project = BuildSvc.LoadProject(src);
            var data = project.Format();
            Write(data);
            FileEmit(data, AppDb.App().Path(src.FileName.WithoutExtension.Format(), FileKind.Env), (ByteSize)data.Length);
        }

        [CmdOp("build/slninfo")]
        void BuildSln(CmdArgs args)
        {
            var ws = AppDb.Dev("z0");
            var src =  ws.Path(FS.file(arg(args,0), FileKind.Sln));
            var sln = BuildSvc.sln(src);
            var data = sln.ToString();
            Write(data);
            FileEmit(data, AppDb.App().Path(src.FileName.WithoutExtension.Format(), FileKind.Env), (ByteSize)data.Length);
        }
    }
}