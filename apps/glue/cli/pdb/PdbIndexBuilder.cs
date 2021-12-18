//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection;

    using static core;

    public sealed class PdbIndexBuilder : AppService<PdbIndexBuilder>
    {
        PdbIndex PdbIndex => Service(Wf.PdbIndex);

        public uint IndexComponent(Assembly src)
        {
            var name = src.GetSimpleName();
            var flow = Running(Msg.ReadingPdb.Format(name));
            var asmpath = FS.path(src.Location);
            var pdbpath = asmpath.ChangeExtension(FS.Pdb);
            var stats = new PdbReaderStats();
            if(pdbpath.Exists)
            {
                var reader = PdbServices.reader(Wf, asmpath, pdbpath);
                var methods = @readonly(src.Methods());
                var count = methods.Length;
                stats.DocCount += PdbIndex.Include(reader.Documents);
                for(var i=0; i<count; i++)
                {
                    ref readonly var method = ref skip(methods,i);
                    var result = reader.Method(method.MetadataToken);
                    if(result)
                    {
                        var pdbMethod = result.Payload;
                        var points = pdbMethod.SequencePoints;
                        var methodDocs = pdbMethod.Documents;
                        stats.MethodCount++;
                        stats.SeqPointCount += (uint)points.Length;
                    }
                }
            }
            else
            {
                Warn(Msg.PdbNotFound.Format(name));
            }

            Ran(flow, string.Format("Read {0} pdb methods with {1} documents and {2} sequence points from {3}", stats.MethodCount, stats.DocCount, stats.SeqPointCount, name));
            return stats.MethodCount;
        }

        public void IndexComponents(ReadOnlySpan<Assembly> components)
        {
            var count = components.Length;
            var flow = Running(Msg.IndexingPdbFiles.Format(count));
            var counter = 0u;
            for(var i=0; i<count; i++)
                counter += IndexComponent(skip(components,i));

            var db = Ws.Project("db");
            var dst = db.Subdir("api") + FS.file("pdbdocs", FS.Md);
            var emitting = EmittingFile(dst);
            var docs = PdbIndex.Documents;
            using var writer = dst.Writer();
            foreach(var doc in docs)
            {
                writer.WriteLine(string.Format("<{0}>", doc.Path.ToUri()));
            }
            EmittedFile(emitting, docs.Length);
            Ran(flow, Msg.IndexedPdbMethods.Format(counter));
        }
    }
}