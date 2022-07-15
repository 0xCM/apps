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
        public void EmitAssemblyRefs(IApiPack dst)
            => EmitAssemblyRefs(ApiMd.Components, dst);

        public void EmitAssemblyRefs(ReadOnlySpan<Assembly> src, IApiPack dst)
            => EmitAssemblyRefs(src, dst.Metadata().Table<AssemblyRefInfo>());

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
                    dst.WriteLine(formatter.Format(refs[i]));
                    counter++;
                }

            }
            return counter;
        }
    }
}