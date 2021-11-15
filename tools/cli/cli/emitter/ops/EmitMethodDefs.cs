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
        public uint EmitMethodDefs(ReadOnlySpan<Assembly> src, FS.FilePath dst)
        {
            var counter = 0u;
            var flow = Wf.EmittingTable<MethodDefInfo>(dst);
            using var writer = dst.Writer();
            var formatter = Tables.formatter<MethodDefInfo>(MethodDefInfo.RenderWidths);
            writer.WriteLine(formatter.FormatHeader());
            for(var i=0; i<src.Length; i++)
            {
                ref readonly var a = ref skip(src,i);
                var reader = CliReader.read(a);
                var records = reader.ReadMethodDefInfo();
                var count = records.Length;
                for(var j=0; j<count; j++)
                {
                    writer.WriteLine(formatter.Format(skip(records, j)));
                    counter++;
                }
            }
            Wf.EmittedTable(flow, counter);
            return counter;
        }
    }
}