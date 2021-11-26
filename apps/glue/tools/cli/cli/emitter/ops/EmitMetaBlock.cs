//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.IO;
    using System.Reflection;

    using static core;

    partial class CliEmitter
    {
        FS.FolderPath MetaBlockDir()
            => Db.TableDir("image.metablocks");

        FS.FilePath MetaBlockPath(Assembly src)
            => MetaBlockDir() + FS.file(src.GetSimpleName(), FS.Csv);

        public ByteSize EmitMetaBlock(Assembly src, uint bpl, FS.FilePath dst)
        {
            var flow = Wf.EmittingFile(dst);
            var segment = Clr.metadata(src);
            using var writer = dst.Writer();
            var size = MemoryStore.emit(segment, bpl, writer);
            Wf.EmittedFile(flow, (uint)size);
            return size;
        }

        public ByteSize EmitMetaBlock(Assembly src, uint bpl = 64)
            => EmitMetaBlock(src, bpl, MetaBlockPath(src));

        public ByteSize EmitMetaBlocks(uint bpl = 64)
        {
            var components = Wf.ApiCatalog.Components.View;
            var count = components.Length;
            var flow = Wf.Running(string.Format("Emitting {0} component metadata blocks", count));
            var size = ByteSize.Zero;
            for(var i=0; i<count; i++)
                size += EmitMetaBlock(skip(components,i), bpl);
            Wf.Ran(flow, string.Format("Emitting {0} component metadata bytes", size));
            return size;
        }
    }
}