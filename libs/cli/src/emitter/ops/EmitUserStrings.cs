//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class CliEmitter
    {
        public uint EmitUserStrings(IApiPack dst)
            => EmitUserStrings(ApiMd.Components, dst);

        public uint EmitUserStrings(ReadOnlySpan<Assembly> src, IApiPack dst)
        {
            var count = src.Length;
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                var emitted = EmitUserStrings(skip(src,i), dst);
                counter += (uint)emitted.Length;
            }
            return counter;
        }

        public ReadOnlySpan<CliString> EmitUserStrings(Assembly src, IApiPack dst)
        {
            var reader = CliReader.create(src);
            var records = reader.ReadUserStringInfo();
            TableEmit(records, dst.Metadata("strings.user").PrefixedTable<CliString>(src.GetSimpleName()), unicode);
            return records;
        }
    }
}