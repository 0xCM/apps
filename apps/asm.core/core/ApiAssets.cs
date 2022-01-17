//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;
    using System.IO;

    using static core;

    public sealed class ApiAssets : AppService<ApiAssets>
    {
        public Index<ResEmission> Run(EmitResDataCmd cmd)
            => EmitEmbedded(cmd.Source, cmd.Target, cmd.Match, cmd.ClearTarget);

        public Index<ResEmission> EmitAssetContent()
        {
            var outer = Running("Emitting reference data");
            var components = ApiRuntimeCatalog.Components;
            var descriptors = Resources.descriptors(components).SelectMany(x => x.Storage).View;
            var count = descriptors.Length;
            var root = ProjectDb.Api() + FS.folder("assets");
            root.Clear();
            var emissions = sys.alloc<ResEmission>(count);
            for(var i=0; i<count; i++)
            {
                try
                {
                    ref var emission = ref seek(emissions,i);
                    ref readonly var descriptor = ref skip(descriptors,i);
                    emission = Emit(descriptor, root);
                }
                catch(Exception e)
                {
                    Error(e);
                }
            }
            Ran(outer, string.Format("Emitted <{0}> reference files", count));
            return emissions;
        }

        static Index<DocLibEntry> entries(Assembly src)
        {
            var names = @readonly(src.GetManifestResourceNames());
            var count = names.Length;
            var buffer = alloc<DocLibEntry>(count);
            ref var dst = ref first(buffer);
            for(var i=0; i<count; i++)
                seek(dst,i) =new DocLibEntry(skip(names,i), Path.GetExtension(skip(names,i)));
            return buffer;
        }

        public Index<ResEmission> EmitEmbedded()
        {
            var running = Running();
            var src = ApiRuntimeCatalog.Components;
            var assets = Resources.descriptors(src);
            var count = assets.Length;
            var buffer = list<ResEmission>();
            var root = ProjectDb.Api() + FS.folder("assets");
            for(var i=0; i<count; i++)
            {
                var sources = assets[i].View;

                for(var j=0; j<sources.Length; j++)
                {
                    ref readonly var descriptor = ref skip(sources,j);
                    var size = descriptor.Size;
                    buffer.Add(Emit(descriptor, root));
                }
            }

            Ran(running);

            return buffer.ToArray();
        }

        public Index<ResEmission> EmitEmbedded(Assembly src, FS.FolderPath root, utf8 match, bool clear)
        {
            var flow = Running(string.Format("Emitting resources embedded in {0}", src.GetSimpleName()));
            var descriptors = match.IsEmpty ? Resources.descriptors(src) : Resources.descriptors(src, match);
            var count = descriptors.ResourceCount;

            if(count == 0)
                return sys.empty<ResEmission>();

            var buffer = sys.alloc<ResEmission>(count);
            ref var emission = ref first(buffer);

            if(clear)
                root.Clear();

            var sources = descriptors.View;
            for(var i=0; i<count; i++)
            {
                ref readonly var descriptor = ref skip(sources,i);
                var size = descriptor.Size;
                seek(emission,i) = Emit(descriptor, root);
            }

            Ran(flow);
            return buffer;
        }

        public ResEmission Emit(in Asset src, FS.FolderPath root)
        {
            var invalid = Path.GetInvalidPathChars();
            var name =  src.Name.ToString().ReplaceAny(invalid, Chars.Underscore);
            var target = root + FS.file(name);
            var flow = EmittingFile(target);
            var utf = Resources.utf8(src);
            using var writer = target.Writer();
            writer.Write(utf);
            EmittedFile(flow,1);
            return flows.arrow(src,target);
        }
    }
}