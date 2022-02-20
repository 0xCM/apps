//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    using llvm;

    using static core;

    partial class ProjectCmdProvider
    {
        [CmdOp("project/collect")]
        Outcome Collect(CmdArgs args)
        {
            var project = Project();
            Collect(project);
            return true;
        }

        void Collect(IProjectWs project)
        {
            var receiver = new AsmStatsCollector();
            Projects.Collect(project, receiver);
            var stats = receiver.Stats();
            var dst = ProjectDb.ProjectTable<AsmStat>(project);
            TableEmit(stats.View, dst);

        }

        [CmdOp("project/objects")]
        Outcome CacheObjSymbols(CmdArgs args)
        {
            using var dispenser = Alloc.symbols();
            var project = Project();
            var catalog = project.FileCatalog();
            var files = catalog.Entries(FileKind.Obj, FileKind.O);
            var count = files.Count;
            var symbols = CoffServices.LoadSymbols(project);

            for(var i=0; i<count; i++)
            {
                ref readonly var file = ref files[i];
                var obj = CoffServices.LoadObj(file);
                var headers = CoffServices.CalcObjHeaders(file);
                for(var j=0; j<headers.Count; j++)
                {
                    ref readonly var header = ref headers[j];
                    Write(string.Format("{0,-24} | {1,-12} | {2,-12} | {3,-12} | {4,-12}",
                        file.Path.FileName,
                        header.SectionNumber,
                        header.SectionName,
                        header.RawDataAddress,
                        header.RawDataSize
                        ));
                }

            }

            return true;
        }

        [CmdOp("xed/collect")]
        Outcome XedCollect(CmdArgs args)
        {
            var result = Outcome.Success;
            var project = Project();
            var catalog = project.FileCatalog();
            var files = catalog.Entries(FileKind.XedRawDisasm);
            var count = files.Count;
            using var dispenser = Alloc.asm();
            for(var i=0; i<count; i++)
            {
                ref readonly var file = ref files[i];
                var blocks = XedDisasm.LoadDisamBlocks(file);
                result = XedDisasmOps.ParseEncodings(file, out var encodings);
                var rows = encodings.View;

                Require.equal((uint)rows.Length, blocks.LineBlocks.Count);

                result = XedDisasm.CalcDisasmDetails(blocks, dispenser, out var details);
                    if(result.Fail)
                        break;

                for(var j=0; j<rows.Length; j++)
                {
                    ref readonly var detail = ref details[j];
                    ref readonly var code = ref detail.Code;
                    ref readonly var id = ref code.Id;
                    ref readonly var iform = ref detail.IForm;
                    ref readonly var asm = ref code.Asm;
                    ref readonly var rex = ref detail.Rex;
                    ref readonly var modrm = ref detail.ModRm;
                    ref readonly var hex = ref code.Encoded;
                    ref readonly var opcode = ref detail.OpCode;
                    ref readonly var sib = ref detail.Sib;
                    ref readonly var szov = ref detail.SizeOverride;
                    ref readonly var disp = ref detail.Disp;

                    Write(string.Format("{0,-18} | {1,-36} | {2} | {3} | {4} | {5} | {6} | {7,-8} | {8}",
                        id,
                        hex,
                        szov,
                        rex.Value().FormatHex(2),
                        opcode.FormatHex(2),
                        modrm.Value().FormatHex(2),
                        sib.Value().FormatHex(2),
                        disp,
                        asm
                        ));

                }

                if(result.Fail)
                    break;
            }

            return result;
        }
    }

    public class AsmStatsCollector : CollectionEventReceiver
    {
        Dictionary<string,uint> _AsmIdCounts;

        public AsmStatsCollector()
        {
            _AsmIdCounts = new();
        }

        public override void Collected(in FileRef src, in AsmInstructionRow inst)
        {
            if(_AsmIdCounts.TryGetValue(inst.AsmName, out var count))
            {
                _AsmIdCounts[inst.AsmName] = count+1;
            }
            else
            {
                _AsmIdCounts[inst.AsmName] = 1;
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
                ref readonly var name = ref skip(keys,i);
                dst.AsmName = name;
                dst.Count = _AsmIdCounts[name];
            }
            return buffer.Sort();
        }
    }
}