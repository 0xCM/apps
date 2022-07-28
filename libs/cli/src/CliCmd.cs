//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Spans;

    public class CliCmd : AppCmdService<CliCmd>
    {
        Cli Cli => Wf.Cli();

        ApiMd ApiMd => Wf.ApiMd();

        CsLang CsLang => Wf.CsLang();

        CliEmitter CliEmitter => Wf.CliEmitter();

        BuildSvc BuildSvc => Wf.BuildSvc();

        public static unsafe PEReader PeReader(MemorySeg src)
            => new PEReader(src.BaseAddress.Pointer<byte>(), src.Size);

        static IApiPack Dst
            => ApiPacks.create();

        [CmdOp("gen/replicants")]
        Outcome GenEnums(CmdArgs args)
        {
            const string Name = "api.types.enums";
            var src = AppDb.ApiTargets().Path(Name, FileKind.List);
            var types = ApiMd.LoadTypes(src);
            var name = "EnumDefs";
            CsLang.EmitReplicants(CsLang.replicant(AppDb.CgStage(name).Root, out var spec), types, AppDb.CgStage(name).Root);
            return true;
        }

        [CmdOp("cmd/copy")]
        void Copy(CmdArgs args)
        {
            var src = FS.dir(arg(args,0).Value);
            var dst = FS.dir(arg(args,1).Value);
            Archives.robocopy(src,dst);
        }

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

        [CmdOp("cli/emit/hex")]
        void EmitApiHex()
            => CliEmitter.EmitApiHex(Dst);

        [CmdOp("cli/emit/refs")]
        void EmitMemberRefs()
            => CliEmitter.EmitRefs(Dst);

        [CmdOp("cli/emit/strings")]
        void EmitStrings()
            => CliEmitter.EmitStrings(Dst);

        [CmdOp("cli/emit/stats")]
        void EmitStats()
            => CliEmitter.EmitRowStats(Dst);

        [CmdOp("cli/emit/blobs")]
        void EmitBlobs()
            => CliEmitter.EmitBlobs(Dst);

        [CmdOp("cli/emit/msil")]
        void EmitMsil()
            => Cli.EmitIl(Dst);

        [CmdOp("cli/emit/ildat")]
        void EmitIlDat()
            => CliEmitter.EmitIlDat(Dst);

        [CmdOp("cli/emit/fields")]
        void EmitFields()
            => CliEmitter.EmitFieldMetadata(Dst);

        [CmdOp("cli/emit/literals")]
        void EmitLiterals()
            => CliEmitter.EmitLiterals(Dst);

        [CmdOp("cli/emit/headers")]
        void EmitHeaders()
            => CliEmitter.EmitSectionHeaders(Dst);

        [CmdOp("api/emit/corelib")]
        void EmitCorLib()
        {
            var src = Clr.corlib();
            var reader = CliReader.create(src);
            var blobs = reader.ReadBlobs();
            for(var i=0; i<blobs.Length; i++)
            {
                ref readonly var blob = ref skip(blobs,i);
                Write(string.Format("{0,-8} | {1,-8} | {2,-8}", blob.Seq, blob.Offset, blob.DataSize));
            }
        }
    }
}