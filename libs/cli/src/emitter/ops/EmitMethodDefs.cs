//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class CliEmitter
    {
        public void EmitMethodDefs(ReadOnlySpan<Assembly> src, IApiPack pack)
            => iter(src, a => EmitMethodDefs(a, pack.Metadata(CliSections.Methods).PrefixedTable<MethodDefInfo>(a.GetSimpleName())), true);

        void EmitMethodDefs(Assembly src, FS.FilePath dst)
        {
            var formatter = Tables.formatter<MethodDefInfo>();
            var flow = EmittingTable<MethodDefInfo>(dst);
            using var writer = dst.Writer();
            writer.WriteLine(formatter.FormatHeader());
            var reader = CliReader.create(src);
            var records = reader.ReadMethodDefInfo();
            var count = records.Length;
            for(var j=0; j<count; j++)
                writer.WriteLine(formatter.Format(skip(records, j)));
            EmittedTable(flow, count);
        }
    }
}