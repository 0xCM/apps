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
            Projects.Collect(project, receiver);
            var stats = receiver.Stats();
            var dst = ProjectDb.ProjectTable<AsmStat>(project);
            TableEmit(stats.View, dst);
            return true;
        }

        [CmdOp("project/files")]
        Outcome IndexFiles(CmdArgs args)
        {
            var catalog = FileCatalog.create();
            var project = Project();
            catalog.Include(project);
            var entries = catalog.Entries();
            TableEmit(entries.View, FileRef.RenderWidths, ProjectDb.ProjectTable<FileRef>(project));
            return true;
        }
    }

    public class AsmStatsCollector : ProjectEventReceiver
    {
        Dictionary<AsmId,uint> _AsmIdCounts;

        public AsmStatsCollector()
        {
            _AsmIdCounts = new();
        }

        public override void Collected(in FileRef src, in AsmInstructionRow inst)
        {
            if(_AsmIdCounts.TryGetValue(inst.AsmId, out var count))
            {
                _AsmIdCounts[inst.AsmId] = count+1;
            }
            else
            {
                _AsmIdCounts[inst.AsmId] = 1;
            }
        }

        public Index<AsmStat> Stats()
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