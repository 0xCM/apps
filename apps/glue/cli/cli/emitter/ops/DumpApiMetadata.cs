//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection.Metadata;
    using System.Reflection.PortableExecutable;
    using System.IO;

    using static core;

    partial class CliEmitter
    {
        public void EmitMetadump(FS.FilePath src, FS.FilePath dst)
        {
            try
            {
                if(Cli.valid(src))
                {
                    var flow = Wf.EmittingFile(dst);
                    using var stream = File.OpenRead(src.Name);
                    using var peFile = new PEReader(stream);
                    using var target = dst.Writer();
                    var reader = peFile.GetMetadataReader();
                    var viz = new MetadataVisualizer(reader, target);
                    viz.Visualize();
                    Wf.EmittedFile(flow,1);
                }
            }
            catch(BadImageFormatException bfe)
            {
                Wf.Warn(bfe);
            }
            catch(Exception e)
            {
                Wf.Error(e);
            }
        }

        public void EmitMetadadump(FS.FolderPath src, FS.FolderPath dst)
        {
            var paths = src.AllFiles.Where(f => f.Is(FS.Exe) || f.Is(FS.Dll)).Where(f => Cli.valid(f));
            foreach(var path in paths)
                EmitMetadump(path, dst + FS.file(path.FileName.Format(), FS.Txt));
        }

        public void EmitApiMetadump()
        {
            var dst = Db.TableDir("image.metadump");
            EmitApiMetadump(dst);
        }

        public void EmitApiMetadump(FS.FolderPath dst)
        {
            dst.Clear();
            var components = Wf.ApiCatalog.Components.View;
            var count = components.Length;
            for(var i=0; i<count; i++)
            {
                var component = skip(components,i);
                var source = FS.path(component.Location);
                var target = dst + FS.file(source.FileName.Format(), FS.Txt);
                EmitMetadump(source,target);
            }
        }
    }
}