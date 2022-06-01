//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class CliEmitter
    {
        FS.FolderPath MetaBlockDir()
            => ProjectDb.Subdir(CliScope) + FS.folder("metablocks");

        FS.FilePath MetaBlockPath(Assembly src)
            => MetaBlockDir() + FS.file(src.GetSimpleName(), FS.Csv);

        public ByteSize EmitMetaBlock(Assembly src, uint bpl, FS.FilePath dst)
        {
            var flow = EmittingFile(dst);
            var segment = Clr.metadata(src);
            using var writer = dst.Writer();
            var size = ApiCode.hexpack(segment, bpl, writer);
            EmittedFile(flow, (uint)size);
            return size;
        }

        public ByteSize EmitMetaBlock(Assembly src, uint bpl = 64)
            => EmitMetaBlock(src, bpl, MetaBlockPath(src));

        public ByteSize EmitMetaBlocks(uint bpl = 64)
        {
            var components = ApiRuntimeCatalog.Components.View;
            var count = components.Length;
            var flow = Running(string.Format("Emitting {0} component metadata blocks", count));
            var size = ByteSize.Zero;
            for(var i=0; i<count; i++)
                size += EmitMetaBlock(skip(components,i), bpl);
            Ran(flow, string.Format("Emitting {0} component metadata bytes", size));
            return size;
        }
    }
}