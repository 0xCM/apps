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
            ProjectManager.Collect(project);
            return true;
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

        [CmdOp("project/coff")]
        Outcome Blah(CmdArgs args)
        {
            var project = Project();
            var symindex = CoffServices.LoadSymIndex(project);
            var catalog = project.FileCatalog();
            var blocks = LlvmObjDump.LoadObjBlocks(project);
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