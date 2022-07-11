//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class CliEmitter
    {
        public ReadOnlySpan<CliString> EmitSystemStringInfo(IApiPack dst)
            => EmitSystemStringInfo(ApiMd.Components, dst);

        public ReadOnlySpan<CliString> EmitSystemStringInfo(ReadOnlySpan<Assembly> src, IApiPack dst)
        {
            var count = src.Length;
            var buffer = list<CliString>(16404);
            for(var i=0; i<count; i++)
                EmitSystemStringInfo(skip(src,i), buffer, dst.Metadata("strings.system").PrefixedTable<CliString>(skip(src,i).GetSimpleName()));
            return buffer.ViewDeposited();
        }

        public uint EmitSystemStringInfo(Assembly src, List<CliString> buffer, FS.FilePath dst)
        {
            var srcPath = FS.path(src.Location);
            using var reader = PeTableReader.open(srcPath);
            var records = reader.ReadSystemStringInfo();
            buffer.AddRange(records);
            TableEmit(records.View, dst, unicode);
            return records.Count;
        }
    }
}