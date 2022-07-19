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

        CliEmitter CliEmitter => Wf.CliEmitter();

        public static unsafe PEReader PeReader(MemorySeg src)
            => new PEReader(src.BaseAddress.Pointer<byte>(), src.Size);

        static IApiPack Dst
            => ApiPack.create();

        [CmdOp("projects")]
        void CheckMsBuild()
        {
            var src =  AppDb.Dev("z0/props").Path(FS.file("projects.props", FileKind.Props));
            var project = MsBuild.project(src);
            Write(project.Format());
        }

        [CmdOp("build/props")]
        void BuildProps(CmdArgs args)
        {
            var src =  AppDb.Dev("z0/props").Path(FS.file(arg(args,0), FileKind.Props));
            var project = MsBuild.project(src);
            var data = project.Format();
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