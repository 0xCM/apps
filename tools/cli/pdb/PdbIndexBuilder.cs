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
        public uint IndexComponent(Assembly src)
        {
            var name = src.GetSimpleName();
            var flow = Wf.Running(Msg.ReadingPdb.Format(name));
            var asmpath = FS.path(src.Location);
            var pdbpath = asmpath.ChangeExtension(FS.Pdb);
            var stats = new PdbReaderStats();
            if(pdbpath.Exists)
            {
                var index = Wf.PdbIndex();
                var reader = PdbServices.reader(Wf, asmpath, pdbpath);
                var methods = @readonly(src.Methods());
                var count = methods.Length;
                stats.DocCount += index.Include(reader.Documents);
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

            Wf.Ran(flow, string.Format("Read {0} pdb methods with {1} documents and {2} sequence points from {3}", stats.MethodCount, stats.DocCount, stats.SeqPointCount, name));
            return stats.MethodCount;
        }

        public void IndexParts(params PartId[] parts)
        {
            IndexComponents(FindComponents(parts));
        }

        public void IndexParts(ReadOnlySpan<PartId> parts)
        {
            IndexComponents(FindComponents(parts.ToArray()));
        }

        public void IndexComponents(ReadOnlySpan<Assembly> components)
        {
            var count = components.Length;
            var flow = Wf.Running(Msg.IndexingPdbFiles.Format(count));
            var counter = 0u;
            for(var i=0; i<count; i++)
                counter += IndexComponent(skip(components,i));

            var index = Wf.PdbIndex();
            var docspath = Db.Doc("pdbdocs", FS.Md);
            var emitting = Wf.EmittingFile(docspath);
            var docs = index.Documents;
            using var writer = docspath.Writer();
            iter(docs, doc => writer.WriteLine(string.Format("<{0}>", doc.Path.ToUri())));
            Wf.EmittedFile(emitting, docs.Length);
            Wf.Ran(flow, Msg.IndexedPdbMethods.Format(counter));
        }

        ReadOnlySpan<Assembly> FindComponents(PartId[] parts)
            => Wf.ApiCatalog.FindComponents(parts);
    }
}