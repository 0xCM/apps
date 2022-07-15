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

        [CmdOp("cli/emit/hex")]
        void EmitApiHex()
            => CliEmitter.EmitApiHex(AppDb.apipack());

        [CmdOp("cli/emit/asmrefs")]
        void EmitAssemblyRefs()
            => CliEmitter.EmitAssemblyRefs(AppDb.apipack());

        [CmdOp("cli/emit/memrefs")]
        void EmitMemberRefs()
            => CliEmitter.EmitMemberRefs(AppDb.apipack());

        [CmdOp("cli/emit/blobs")]
        void EmitBlobs()
            => CliEmitter.EmitBlobs(AppDb.apipack());

        [CmdOp("cli/emit/msil")]
        void EmitMsil()
            => Cli.EmitMsil(AppDb.apipack());

        [CmdOp("cli/emit/fields")]
        void EmitFields()
            => CliEmitter.EmitFieldMetadata(AppDb.apipack());

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

            // var dst = AppDb.ApiTargets("metadata").Path(src.GetSimpleName(),FileKind.Txt);
            // CliEmitter.EmitMetadump(src,dst);
        }


    }
}