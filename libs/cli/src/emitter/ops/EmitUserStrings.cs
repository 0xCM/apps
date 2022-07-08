//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class CliEmitter
    {
        public uint EmitUserStrings()
            => EmitUserStrings(ApiRuntimeCatalog.Components);

        public uint EmitUserStrings(ReadOnlySpan<Assembly> src)
        {
            var count = src.Length;
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                var emitted = EmitUserStrings(skip(src,i));
                counter += (uint)emitted.Length;
            }
            return counter;
        }

        public ReadOnlySpan<CliUserString> EmitUserStrings(Assembly src)
        {
            var reader = CliReader.create(src);
            var records = reader.ReadUserStringInfo();
            TableEmit(records, ProjectDb.TablePath<CliUserString>(StringScope, src.GetSimpleName()));
            return records;
        }
    }
}