//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Collections.Generic;

    using Asm;

    using static core;

    partial class ProjectCmdProvider
    {
        [CmdOp("project/collect")]
        Outcome Collect(CmdArgs args)
        {
            var project = Project();
            var receiver = new AsmStatsCollector();
            ProjectCollector.Collect(project, receiver);
            var stats = receiver.Collected();
            var dst = ProjectDb.ProjectTable<AsmStat>(project);
            TableEmit(stats.View, dst);
            return true;
        }

        [CmdOp("project/index")]
        public Outcome IndexEncoding(CmdArgs args)
        {
            var project = Project();
            var src = ProjectDb.ProjectTable<ObjDumpRow>(project);
            var rows = ObjDump.LoadRows(src);
            using var allocation = AsmCodeAllocation.allocate(rows.View);
            var allocated = allocation.Allocated;
            var count = allocated.Length;
            var buffer = alloc<AsmCodeIndexRow>(count);
            for(var i=0; i<count; i++)
            {
                ref var dst = ref seek(buffer,i);
                ref readonly var code = ref skip(allocated,i);
                ref readonly var row = ref rows[i];
                dst.Seq = row.Seq;
                dst.CT = code.CT;
                dst.Asm = code.Asm.Format();
                dst.Encoding = code.Code;
                dst.Offset = code.Offset;

                //Write(string.Format("{0,-8} | {1,-8} | {2,-132} | {3}", (ulong)code.CT, row.Seq, code.Format(), row.HexCode.Format()));
            }

            TableEmit(@readonly(buffer), AsmCodeIndexRow.RenderWidths, ProjectDb.ProjectTable<AsmCodeIndexRow>(project));

            return true;
        }

    }


    public class AsmStatsCollector : AsmEventReceiver
    {
        Dictionary<AsmId,uint> _AsmIdCounts;

        public AsmStatsCollector()
        {
            _AsmIdCounts = new();
        }

        public override void Correlated(in AsmEncodingRow enc, in AsmSyntaxRow syn, in AsmInstructionRow inst, in AsmDocCorrelation result)
        {
            if(_AsmIdCounts.TryGetValue(result.AsmId, out var count))
            {
                _AsmIdCounts[result.AsmId] = count+1;
            }
            else
            {
                _AsmIdCounts[result.AsmId] = 1;
            }
        }

        public Index<AsmStat> Collected()
        {
            var count = _AsmIdCounts.Count;
            var buffer = alloc<AsmStat>(count);
            var keys = _AsmIdCounts.Keys.Array();
            for(var i=0;i<count; i++)
            {
                ref var dst = ref seek(buffer,i);
                ref readonly var key = ref skip(keys,i);
                dst.Id = key;
                dst.Count = _AsmIdCounts[key];
            }
            return buffer.Sort();
        }

    }
}