//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;

    using static core;

    partial class CliEmitter
    {
        public uint EmitUserStrings()
            => EmitUserStrings(Wf.Components);

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
            var reader = CliReader.read(src);
            var records = reader.ReadUserStringInfo();
            TableEmit(records, Paths.TableDir<CliUserString>() + Paths.TableFile<CliUserString>(src.GetSimpleName()));
            return records;
        }
    }
}