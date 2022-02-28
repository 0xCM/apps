//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using llvm;
    using Asm;
    using System.Linq;

    using static core;
    using static XedModels;
    partial class ProjectCmdProvider
    {
        [CmdOp("project/collect")]
        Outcome Collect(CmdArgs args)
        {
            var project = Project();
            var data = ProjectData.Collect(project);
            return true;
        }

        [CmdOp("project/disasm/detail")]
        Outcome CollectDisasmDetail(CmdArgs args)
        {
            var context = Projects.Context(Project());
            var details = ProjectData.CollectDisasmDetail(context);
            var count = details.Count;
            var max = 0;
            for(var i=0; i<count; i++)
            {
                ref readonly var detail = ref details[i];
                ref readonly var ops = ref detail.Operands;
                var opcount = ops.Count;
                for(var j=0; j<opcount; j++)
                {
                    ref readonly var op = ref ops[j];
                    ref readonly var fk = ref op.Def.Kind;
                    if(fk == FieldKind.MEM0)
                    {
                        ref readonly var desc = ref op.RuleDescription;
                        if(op.RuleDescription.Length > max)
                        {
                            max = desc.Length;
                            Write(desc);
                        }
                    }

                }
            }

            Write(string.Format("Max MEM0 length:{0}", max));

            return true;
        }

        void Recode(WsDataCollection data)
        {
            static void BeginFile(in ObjDumpRow row, ITextBuffer dst)
            {
                dst.AppendLine(AsmDirectives.define(AsmDirectiveKind.DK_INTEL_SYNTAX, AsmDirectiveOp.noprefix));
                dst.AppendLine();
            }

            var project = data.Project;
            var files = data.Files;
            var objdump = data.ObjDumpRows;
            var xed = data.DetailLookup;
            var buffer = text.buffer();
            var docid = objdump.First.OriginId;
            var file = files[docid];
            var docname = file.DocName;
            var counter = 0u;
            var blockname = EmptyString;
            BeginFile(objdump.First, buffer);
            for(var i=0; i<objdump.Count; i++, counter++)
            {
                ref readonly var row = ref objdump[i];
                if(row.OriginId != docid)
                {
                    var outpath = AppDb.CgStagePath(project.Name.Format(), docname, FileKind.Asm);
                    FileEmit(buffer.Emit(), counter, outpath, TextEncodingKind.Asci);
                    docid = row.OriginId;
                    file = files[docid];
                    docname = file.DocName;
                    counter = 0;
                    blockname = EmptyString;
                    BeginFile(row, buffer);
                }

                if(blockname != row.BlockName)
                {
                    if(empty(blockname))
                    {
                        blockname = row.BlockName;
                        buffer.AppendLine(asm.label(blockname));
                    }
                    else
                    {
                        buffer.AppendLine();
                        blockname = row.BlockName;
                        buffer.AppendLine(asm.label(blockname));
                    }
                }

                if(xed.Find(row.InstructionId, out var x))
                {
                    buffer.IndentLineFormat(4, "{0,-56} # {1,-42} | {2}/{3}", row.Asm, row.Encoded, x.IForm, x.OpCode);
                }
                else
                    buffer.IndentLineFormat(4, "{0,-56} # {1}", row.Asm, row.Encoded);

                if(i == objdump.Count - 1)
                {
                    var outpath = AppDb.CgStagePath(project.Name.Format(), docname, FileKind.Asm);
                    FileEmit(buffer.Emit(), counter, outpath, TextEncodingKind.Asci);
                }
            }
        }


        [CmdOp("project/flows")]
        Outcome ProjectFlows(CmdArgs args)
        {
            var project = Project();
            var index = Projects.LoadBuildFlowIndex(project);
            var kinds = array(FileKind.ObjAsm, FileKind.XedRawDisasm, FileKind.McAsm, FileKind.Sym);
            var buffer = list<FileRef>();

            foreach(var kind in kinds)
            {
                var targets = index.Files(kind);
                foreach(var target in targets)
                {
                    if(index.Root(target.Path, out var source))
                    {
                        var fmt = string.Format("<{0}:{1}, {2}:{3}>", target.Path.FileName, target.Kind, source.Path.FileName, source.Kind);
                        Write(fmt);
                    }
                }
            }

            // index.DescribeFlows(FileKind.C, dst);
            // Write(dst.Emit());

            return true;
        }

        [CmdOp("project/mcasm")]
        Outcome McAsmDocs(CmdArgs args)
        {
            var project = Project();
            var catalog = project.FileCatalog();
            var files = catalog.Entries(FileKind.McAsm);

            var docs = ProjectData.CalcMcAsmDocs(project);
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

        [CmdOp("project/coff")]
        Outcome Blah(CmdArgs args)
        {
            var project = Project();
            var symindex = CoffServices.LoadSymIndex(project);
            var catalog = project.FileCatalog();
            var blocks = ProjectData.LoadObjBlocks(project);
            var files = catalog.Entries(FileKind.Obj, FileKind.O);
            var count = files.Count;
            var docsyms = symindex.Symbols();
            iter(blocks, block => Write(string.Format("'{0}'", block.BlockName)));
            return true;
        }

        [CmdOp("project/objects")]
        Outcome CacheObjSymbols(CmdArgs args)
        {
            using var dispenser = Alloc.symbols();
            var project = Project();
            var context = Projects.Context(project);
            var catalog = project.FileCatalog();
            var files = catalog.Entries(FileKind.Obj, FileKind.O);
            var count = files.Count;
            var buffer = text.buffer();
            var indent = 0u;
            buffer.IndentLine(indent, "namespace Z0");
            buffer.IndentLine(indent, Chars.LBrace);
            indent += 4;
            buffer.IndentLineFormat(indent, "public readonly struct {0}", project.Name);
            buffer.IndentLine(indent, Chars.LBrace);
            indent += 4;
            for(var i=0; i<count; i++)
            {
                ref readonly var file = ref files[i];
                var code = dict<MemoryRange,BinaryCode>();
                var obj = CoffServices.LoadObj(file);
                var sections = CoffServices.CalcObjSections(context, file);
                for(var j=0; j<sections.Count; j++)
                {
                    ref readonly var section = ref sections[j];
                    if(section.SectionKind == CoffSectionKind.Text)
                    {
                        var range = new MemoryRange(section.RawDataAddress, section.RawDataSize);
                        code[range] = obj.Data;
                        var data = obj.Bytes(range);
                        var identifier = file.Path.FileName.WithoutExtension.Format().Replace(Chars.Dot, Chars.Underscore).Replace(Chars.Dash,Chars.Underscore);
                        var hex = data.FormatHex(Chars.Comma,true);
                        var gen = string.Format("public static ReadOnlySpan<byte> {0} = new byte[{1}]", identifier, (uint)section.RawDataSize);
                        var statement = gen + "{" + hex + "};";
                        buffer.IndentLine(indent, statement);
                        buffer.AppendLine();
                    }
                }
            }

            indent -= 4;
            buffer.IndentLine(indent, Chars.RBrace);

            indent -= 4;
            buffer.IndentLine(indent, Chars.RBrace);

            FileEmit(buffer.Emit(), count, ProjectDb.Logs() + FS.file(project.Name.Format(), FS.Cs));
            return true;
        }

        [CmdOp("xed/collect")]
        Outcome XedCollect(CmdArgs args)
        {
            var context = Projects.Context(Project());
            var details = XedDisasm.CollectDisasmDetails(context);
            return true;
        }
   }
}