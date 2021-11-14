//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;
    using System.IO;
    using System.Collections.Generic;

    using static core;

    public sealed class ApiAssets : AppService<ApiAssets>, IApiAssets
    {
        public Index<ResEmission> Run(EmitResDataCmd cmd)
            => EmitEmbedded(cmd.Source, cmd.Target, cmd.Match, cmd.ClearTarget);

        public Index<ResEmission> EmitAssetContent()
        {
            var outer = Wf.Running("Emitting reference data");
            var components = Wf.ApiCatalog.Components;
            var descriptors = Resources.descriptors(components).SelectMany(x => x.Storage).View;
            var count = descriptors.Length;
            var root = Db.RefDataRoot();
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
                    Wf.Error(e);
                }
            }
            Wf.Ran(outer, string.Format("Emitted <{0}> reference files", count));
            return emissions;
        }



        // public Index<DocLibEntry> EmitAssetIndex()
        // {
        //     var flow = Wf.Running();
        //     var formatter = Tables.formatter<DocLibEntry>(82);
        //     var target = Db.RefDataRoot() + FS.file("index", FS.Csv);
        //     using var dst = target.Writer();
        //     dst.WriteLine(formatter.FormatHeader());
        //     var emitting = Wf.EmittingTable<DocLibEntry>(target);
        //     var entries = list<DocLibEntry>();
        //     Emit(array(Parts.Res.Assembly), dst, entries);
        //     Wf.EmittedTable(emitting, entries.Count);
        //     Wf.Ran(flow);
        //     return entries.ToArray();
        // }

        void Emit(ReadOnlySpan<Assembly> src, StreamWriter dst, List<DocLibEntry> entries)
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
                entries.AddRange(Emit(skip(src,i),dst));
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

        Index<DocLibEntry> Emit(Assembly src, StreamWriter dst)
        {
            var _entries = entries(src);
            Emit(_entries, dst);
            return _entries;
        }

        uint Emit(ReadOnlySpan<DocLibEntry> entries, StreamWriter dst)
        {
            var count = (uint)entries.Length;
            var formatter = Tables.formatter<DocLibEntry>(82);
            for(var i=0u; i<count; i++)
                dst.WriteLine(formatter.Format(skip(entries, i)));
            return count;
        }

        public Index<ResEmission> EmitEmbedded(Assembly src, FS.FolderPath root, utf8 match, bool clear)
        {
            var flow = Wf.Running(string.Format("Emitting resources embedded in {0}", src.GetSimpleName()));
            var descriptors = match.IsEmpty ? Resources.descriptors(src) : Resources.descriptors(src, match);
            var count = descriptors.ResourceCount;

            if(count == 0)
                Wf.Warn(Msg.NoMatchingResources.Format(src, match));
            else
                Wf.Status(Msg.EmittingResources.Format(src, count));

            var buffer = sys.alloc<ResEmission>(count);
            ref var emission = ref first(buffer);

            if(clear)
                root.Clear();

            var invalid = Path.GetInvalidPathChars();
            var sources = descriptors.View;
            for(var i=0; i<count; i++)
            {
                ref readonly var descriptor = ref skip(sources,i);
                var size = descriptor.Size;
                seek(emission,i) = Emit(descriptor, root);
                Wf.Status($"Emitted {emission.Target}");
            }

            Wf.Ran(flow);
            return buffer;
        }

        public ResEmission Emit(in Asset src, FS.FolderPath root)
        {
            var invalid = Path.GetInvalidPathChars();
            var name =  src.Name.ToString().ReplaceAny(invalid, Chars.Underscore);
            var target = root + FS.file(name);
            var flow = Wf.EmittingFile(target);
            var utf = Resources.utf8(src);
            using var writer = target.Writer();
            writer.Write(utf);
            Wf.EmittedFile(flow,1);
            return relations.arrow(src,target);
        }
    }

    partial struct Msg
    {
        public static MsgPattern<Assembly,utf8> NoMatchingResources => "No {0} resources found that match {1}";

        public static MsgPattern<Assembly,uint> EmittingResources => "Emitting {1} {0} resources";
    }
}