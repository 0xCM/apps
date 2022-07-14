//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class CliEmitter
    {
        public void EmitMetadataHex(Assembly src, uint bpl, FS.FilePath path)
        {
            try
            {
                if(path.Exists)
                    Errors.ThrowWithOrigin(AppMsg.FileExists.Format(path));

                var flow = EmittingFile(path);
                ByteSize size = MemoryEmitter.emit(Clr.metadata(src), 64, path);
                EmittedFile(flow, $"Emitted {size} bytes from {src.GetSimpleName()} to {path.ToUri()}");
            }
            catch(Exception e)
            {
                Error(e);
            }
        }

        public void EmitApiHex(IApiPack dst, uint bpl = 64)
            => iter(ApiMd.Components, c => EmitMetadataHex(c, bpl, dst.Metadata("api.hex").Path(c.GetSimpleName(), FileKind.Hex)), true);
    }
}