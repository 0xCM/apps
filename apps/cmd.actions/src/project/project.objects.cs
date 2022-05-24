//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class ProjectCmd
    {
        [CmdOp("project/objects")]
        Outcome CacheObjSymbols(CmdArgs args)
        {
            using var dispenser = Alloc.symbols();
            var project = Project();
            var context = WsContext.create(project);
            var catalog = FileCatalog.load(project);
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
    }
}