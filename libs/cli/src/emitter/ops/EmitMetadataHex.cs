//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class CliEmitter
    {
        public void EmitMetadataHex(Assembly src, uint bpl, FS.FilePath dst)
        {
            var flow = EmittingFile(dst);
            ByteSize size = MemoryEmitter.emit(Clr.metadata(src), 64, dst);
            EmittedFile(flow, $"Emitted {size} bytes from {src.GetSimpleName()} to {dst.ToUri()}");
        }

        public void EmitApiHex(IApiPack dst, uint bpl = 64)
        {
            iter(ApiMd.Components, c => EmitMetadataHex(c, bpl, dst.Metadata("api.hex").Path(c.GetSimpleName(), FileKind.Hex)), true);
        }
    }
}