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
        public Outcome<Arrow<FS.FilePath>> EmitMetadump(FS.FilePath src, FS.FilePath dst)
        {
            try
            {
                if(ClrModules.valid(src))
                {
                    var flow = Wf.EmittingFile(dst);
                    using var stream = File.OpenRead(src.Name);
                    using var peFile = new PEReader(stream);
                    using var target = dst.Writer();
                    var reader = peFile.GetMetadataReader();
                    var viz = new MetadataVisualizer(reader, target);
                    viz.Visualize();
                    Wf.EmittedFile(flow,1);
                    return (true,(src,dst));
                }
                else
                {
                    return (false, string.Format("No cli metadata found in {0}", src));
                }
            }
            catch(BadImageFormatException bfe)
            {
                return bfe;
            }
            catch(Exception e)
            {
                return e;
            }
        }

        public Index<Arrow<FS.FilePath>> EmitMetadadump(FS.FolderPath src, FS.FolderPath dst, bool clear = true)
        {
            if(clear)
                dst.Clear();

            var srcpaths = src.AllFiles.Where(f => f.Is(FS.Exe) || f.Is(FS.Dll)).Where(f => ClrModules.valid(f));
            var count = srcpaths.Count;
            var flows = alloc<Arrow<FS.FilePath>>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var srcpath =ref srcpaths[i];
                var dstpath = dst + FS.file(srcpath.FileName.Format(), FS.Txt);
                var result = EmitMetadump(srcpath, dstpath);
                if(result.Fail)
                    Warn(result.Message);
                else
                    seek(flows,i) = result.Data;
            }
            return flows;
        }

        public void EmitApiMetadump()
        {
            EmitApiMetadump(ProjectDb.Subdir(MetadumpScope));
        }

        public Index<Arrow<FS.FilePath>> EmitMetadump(ReadOnlySpan<Assembly> src, FS.FolderPath dst, bool clear = true)
        {
            if(clear)
                dst.Clear();
            var count = src.Length;
            var flows = alloc<Arrow<FS.FilePath>>(count);
            for(var i=0; i<count; i++)
            {
                var component = skip(src,i);
                var source = FS.path(component.Location);
                var target = dst + FS.file(source.FileName.Format(), FS.Txt);
                var result = EmitMetadump(source,target);
                if(result.Fail)
                    Warn(result.Message);
                else
                    seek(flows,i) = result.Data;
            }
            return flows;
        }

        public Index<Arrow<FS.FilePath>> EmitApiMetadump(FS.FolderPath dst)
            => EmitMetadump(ApiRuntimeCatalog.Components.View, dst);
    }
}