//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class CliEmitter
    {
        IDbTargets MdHexTargets()
            => AppDb.ApiTargets("api.hex");

        FS.FilePath HexPath(Assembly src)
            => MdHexTargets().Path(src.GetSimpleName(), FileKind.Hex);

        public void EmitMetadataHex(Assembly src, uint bpl)
        {
            var dst = HexPath(src);
            var flow = EmittingFile(dst);
            ByteSize size = MemoryEmitter.emit(Clr.metadata(src), 64, dst);
            EmittedFile(flow, $"Emitted {size} bytes from {src.GetSimpleName()} to {dst.ToUri()}");
        }

        public void EmitApiHex(uint bpl = 64)
        {
            MdHexTargets().Clear();
            iter(ApiMd.Components, c => EmitMetadataHex(c, bpl), true);
        }
    }
}