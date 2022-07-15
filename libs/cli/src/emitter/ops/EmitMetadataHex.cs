//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class CliEmitter
    {
        public void EmitApiHex(Assembly src, uint bpl, FS.FilePath path)
        {
            try
            {
                var flow = EmittingFile(path);
                ByteSize size = MemoryEmitter.emit(Clr.metadata(src), bpl, path);
                EmittedFile(flow, $"Emitted {size} bytes from {src.GetSimpleName()} to {path.ToUri()}");
            }
            catch(Exception e)
            {
                Error(e);
            }
        }

        public void EmitApiHex(IApiPack dst, uint bpl = 64)
            => iter(ApiMd.Components, c => EmitApiHex(c, bpl, dst.Metadata(CliSections.ApiHex).Path(c.GetSimpleName(), FileKind.Hex)), true);
    }
}