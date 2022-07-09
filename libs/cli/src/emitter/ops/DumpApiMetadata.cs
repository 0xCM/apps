//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;

    using static core;

    partial class CliEmitter
    {
        public void EmitMetadump(FS.FilePath src, FS.FilePath dst)
        {
            try
            {
                if(ClrModules.valid(src))
                {
                    var flow = EmittingFile(dst);
                    using var stream = File.OpenRead(src.Name);
                    using var pe = ImageMemory.pe(stream);
                    using var target = dst.Writer();
                    Cil.mdv(pe.GetMetadataReader(), target).Visualize();
                    EmittedFile(flow,1);
                }
            }
            catch(BadImageFormatException bfe)
            {
                Error(bfe);
            }
            catch(Exception e)
            {
                Error(e);
            }
        }


        public void EmitMetadadump(FS.FolderPath src, FS.FolderPath dst, bool clear = true)
        {
            if(clear)
                dst.Clear();

            var srcpaths = src.AllFiles.Where(f => f.Is(FS.Exe) || f.Is(FS.Dll)).Where(f => ClrModules.valid(f));
            var count = srcpaths.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var srcpath =ref srcpaths[i];
                var dstpath = dst + FS.file(srcpath.FileName.Format(), FS.Txt);
                EmitMetadump(srcpath, dstpath);
            }
        }

        public void EmitApiMetadump(IApiPack dst)
        {
            EmitApiMetadump(dst.Metadata("metadump"));
        }

        public void EmitMetadump(ReadOnlySpan<Assembly> src, FS.FolderPath dst, bool clear = true)
        {
            if(clear)
                dst.Clear();
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                var component = skip(src,i);
                var source = FS.path(component.Location);
                var target = dst + FS.file(source.FileName.Format(), FS.Txt);
                EmitMetadump(source,target);
            }
        }

        public void EmitApiMetadump(IDbTargets dst)
            => EmitMetadump(ApiMd.Components, dst.Root);
    }
}