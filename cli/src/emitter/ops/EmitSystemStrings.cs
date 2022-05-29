//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class CliEmitter
    {
        public ReadOnlySpan<CliSystemString> EmitSystemStringInfo()
            => EmitSystemStringInfo(ApiRuntimeCatalog.Components);

        public ReadOnlySpan<CliSystemString> EmitSystemStringInfo(ReadOnlySpan<Assembly> src)
        {
            var count = src.Length;
            var dst = list<CliSystemString>(16404);
            for(var i=0; i<count; i++)
                EmitSystemStringInfo(skip(src,i), dst);
            return dst.ViewDeposited();
        }

        public uint EmitSystemStringInfo(Assembly src, List<CliSystemString> dst)
        {
            var srcPath = FS.path(src.Location);
            using var reader = PeTableReader.open(srcPath);
            var records = reader.ReadSystemStringInfo();
            dst.AddRange(records);
            TableEmit(records.View, ProjectDb.TablePath<CliSystemString>(StringScope, src.GetSimpleName()));
            return records.Count;
        }
    }
}