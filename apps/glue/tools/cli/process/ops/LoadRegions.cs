//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Diagnostics;

    using static core;

    partial class ProcessContextPipe
    {
        public Index<ProcessMemoryRegion> LoadRegions()
        {
            var paths = ContextPaths.MemoryRegionPaths();
            if(paths.Length != 0)
            {
                var path = paths[paths.Length - 1];
                var result = LoadRegions(path);
                if(result)
                    return result.Data;
                else
                    Wf.Error(result.Message);
            }
            return sys.empty<ProcessMemoryRegion>();
        }

        public Outcome<Index<ProcessMemoryRegion>> LoadRegions(FS.FilePath src)
        {
            var tid = Tables.identify<ProcessMemoryRegion>();
            var flow = Wf.Running(string.Format("Reading {0} records from {1}", tid, src.ToUri()));
            if(!src.Exists)
                return (false, FS.Msg.DoesNotExist.Format(src));
            var lines = src.ReadNumberedLines();
            var count = lines.Length;
            if(count == 0)
            {
                return (false,"No data");
            }

            ref readonly var header = ref first(lines);
            var cells = header.Split(Chars.Pipe);
            if(cells.Length != ProcessMemoryRegion.FieldCount)
                return (false, Tables.FieldCountMismatch.Format(cells.Length, ProcessMemoryRegion.FieldCount));

            var data = slice(lines,1);
            var buffer = alloc<ProcessMemoryRegion>(data.Length);
            ref var dst = ref first(buffer);
            var counter = 0;
            for(var i=0; i<data.Length; i++)
            {
                ref readonly var line = ref skip(data,i);
                if(line.IsEmpty)
                    continue;

                var result = ImageMemory.parse(line.Content, out seek(dst,i));
                if(!result)
                    return result;

                counter++;
            }
            Wf.Ran(flow, string.Format("Read {0} {1} records from {2}", counter, tid, src.ToUri()));
            return (true,buffer);
        }
    }
}