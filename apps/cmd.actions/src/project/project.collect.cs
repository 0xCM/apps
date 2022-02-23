//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using llvm;

    using static core;

    partial class ProjectCmdProvider
    {
        [CmdOp("project/collect")]
        Outcome Collect(CmdArgs args)
        {
            var project = Project();
            var collection = ProjectManager.Collect(project);
            return true;
        }

        [CmdOp("project/flows")]
        Outcome ProjectFlows(CmdArgs args)
        {
            var project = Project();
            var index = Projects.LoadBuildFlowIndex(project);
            var flows = index.Flows;
            var count = flows.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var flow = ref skip(flows,i);
                Write(string.Format("{0} -> {1}", flow.Source.Path.FileName, flow.Target.Path.FileName));
            }

            return true;
        }

        [CmdOp("project/mcasm")]
        Outcome McAsmDocs(CmdArgs args)
        {
            var project = Project();
            var catalog = project.FileCatalog();
            var files = catalog.Entries(FileKind.McAsm);

            var docs = LlvmMc.ParseMcAsmDocs(project);
            var count = docs.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var doc = ref docs[i];
                MergeDirectives(doc);
                // var labels = doc.BlockLabels;
                // var blocklines = labels.Keys;
                // for(var  j=0; j<blocklines.Length; j++)
                // {
                //     ref readonly var blockline = ref skip(blocklines,j);
                //     Write(string.Format("{0:d5} {1}", blockline, labels[blockline].Format()));
                // }
            }

            return true;
        }

        void MergeDirectives(in McAsmDoc src)
        {
            var lines = src.DocLines;
            var directives = src.Directives;
            var numbers = src.DocLines.Keys.ToArray().Sort();
            var count = numbers.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var number = ref skip(numbers,i);
                var line = lines[number];
                if(directives.Find(number, out var directive))
                {
                    Write(string.Format("{0,-8} {1}", number, directive.Format()));
                }
                else
                {
                    //Write(string.Format("{0,-8} {1}",number, line.Format()));
                }

            }
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
            for(var i=0; i<count; i++)
            {
                ref readonly var file = ref files[i];
                var blocks = XedDisasm.LoadDisamBlocks(file);
                result = XedDisasmOps.ParseEncodings(file, out var encodings);
                var rows = encodings.View;

                Require.equal((uint)rows.Length, blocks.LineBlocks.Count);

                result = XedDisasm.CalcDisasmDetails(blocks, out var details);
                    if(result.Fail)
                        break;

                for(var j=0; j<rows.Length; j++)
                {
                    ref readonly var detail = ref details[j];
                    ref readonly var docid = ref detail.DocId;
                    ref readonly var encid = ref detail.EncodingId;
                    ref readonly var ip = ref detail.IP;
                    ref readonly var encoded = ref detail.Encoded;
                    ref readonly var opcode = ref detail.OpCode;
                    ref readonly var psz = ref detail.PrefixSize;
                    ref readonly var szov = ref detail.SizeOverride;
                    ref readonly var rex = ref detail.Rex;
                    ref readonly var modrm = ref detail.ModRm;
                    ref readonly var sib = ref detail.Sib;
                    ref readonly var disp = ref detail.Disp;
                    ref readonly var asm = ref detail.Asm;
                    ref readonly var iform = ref detail.IForm;

                    Write(string.Format("{0,-12} | {1,-18} | {2,-12} | {3,-36} | {4,-8} | {5,-5} | {6,-5} | {7,-5} | {8,-5} | {9,-8} | {10,-8} | {11,-54} | {12,-54} | {13}",
                        docid,
                        encid,
                        ip,
                        encoded,
                        opcode.FormatHex(2),
                        psz.FormatHex(1),
                        szov,
                        rex.Value().FormatHex(2),
                        modrm.Value().FormatHex(2),
                        sib.Value().FormatHex(2),
                        disp,
                        asm,
                        iform,
                        detail.Operands
                        ));
                }

                if(result.Fail)
                    break;
            }

            return result;
        }
    }
}