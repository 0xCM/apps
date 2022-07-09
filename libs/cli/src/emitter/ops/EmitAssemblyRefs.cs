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
        public FS.FilePath MemberRefsPath(Assembly src)
            => ProjectDb.TablePath<MemberRefInfo>(CliScope, src.GetSimpleName());

        public void EmitAssemblyRefs(FS.Files src)
            => EmitAssemblyRefs(src, ProjectDb.TablePath<AssemblyRefInfo>(CliScope));

        public void EmitAssemblyRefs(IApiPack dst)
            => EmitAssemblyRefs(ApiMd.Components, dst);

        public void EmitAssemblyRefs(ReadOnlySpan<Assembly> src, FS.FilePath dst)
        {
            var count = src.Length;
            var counter = 0u;
            var flow = EmittingTable<AssemblyRefInfo>(dst);
            var formatter = Tables.formatter<AssemblyRefInfo>();
            using var writer = dst.Writer();
            writer.WriteLine(formatter.FormatHeader());
            for(var i=0; i<count; i++)
                counter += EmitAssemblyRefs(skip(src,i), formatter, writer);
            EmittedTable(flow, counter);
        }

        public void EmitAssemblyRefs(ReadOnlySpan<Assembly> src, IApiPack dst)
            => EmitAssemblyRefs(src, dst.Metadata().Table<AssemblyRefInfo>());

        void EmitAssemblyRefs(FS.Files input, FS.FilePath dst)
        {
            var sources = input.View;
            var srcCount = sources.Length;
            using var writer = dst.Writer();
            var formatter = Tables.formatter<AssemblyRefInfo>(48);
            writer.WriteLine(formatter.FormatHeader());
            for(var k=0u; k<srcCount; k++)
            {
                ref readonly var source = ref skip(sources,k);
                Wf.Status(string.Format("Emitting {0} assembly references", source.Name));
                using var reader = PeReader.create(source);
                var data = reader.ReadAssemblyRefs();
                var count = data.Length;
                for(var i=0; i<count; i++)
                    writer.WriteLine(formatter.Format(skip(data,i)));
            }
        }

        uint EmitAssemblyRefs(Assembly src, IRecordFormatter formatter, StreamWriter dst)
        {
            var path = FS.path(src.Location);
            var counter = 0u;
            if(ClrModules.valid(path))
            {
                using var reader = PeReader.create(path);
                var refs = reader.ReadAssemblyRefs();
                var count = refs.Length;
                for(var i=0; i<count; i++)
                {
                    dst.WriteLine(formatter.Format(skip(refs,i)));
                    counter++;
                }

            }
            return counter;
        }
    }
}