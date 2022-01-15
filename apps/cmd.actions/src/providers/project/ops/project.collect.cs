//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using static core;
    using System.Collections.Generic;

    using Asm;

    [Record(TableId)]
    public struct AsmStat : IComparable<AsmStat>
    {
        public const string TableId = "asm.stats";

        public AsmId Id;

        public uint Count;

        public int CompareTo(AsmStat src)
            => Id.ToString().CompareTo(src.Id.ToString());

    }

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