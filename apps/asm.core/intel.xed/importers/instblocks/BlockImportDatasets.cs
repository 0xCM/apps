//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedModels;
    using static core;

    partial class XedImport
    {
        public class ImportedBlocks
        {
            public SortedLookup<InstForm,uint> Forms;

            public Index<InstBlockImport> Imports;

            public InstBlockLines BlockLines;

            public LineMap<InstBlockLineSpec> LineMap;

            public ConcurrentDictionary<InstForm,string> FormBlocks;

            public ConcurrentDictionary<InstForm,string> FormHeaders;

            public string Description(InstForm form)
                => FormBlocks[form];

            public string Header(InstForm form)
                => FormHeaders[form];
        }

        class BlockImportDatasets
        {
            static FormImportDatasets forms(BlockImportDatasets src)
                => data(nameof(FormImportDatasets), ()=> FormImportDatasets.calc(src));

            public LineMap<InstBlockLineSpec> MappedForms = new();

            public InstBlockLines BlockLines = new();

            public ConcurrentBag<InstBlockImport> BlockImports = new();

            public ConcurrentDictionary<InstForm,string> FormData = new();

            public static ReadOnlySpan<LineStats> stats(MemoryFile src)
                => AsciLines.stats(src.View(),400000);

            public static ImportedBlocks calc(MemoryFile src)
            {
                var dst = new ImportedBlocks();
                var ds = datasets(src);
                var fds = forms(ds);
                dst.BlockLines = ds.BlockLines;
                dst.LineMap = ds.MappedForms;
                dst.FormBlocks = fds.Descriptions;
                dst.FormHeaders = fds.Headers;
                dst.Forms = fds.Sorted;
                dst.Imports = ds.BlockImports.Index().Sort().Resequence();
                return dst;
            }

            public static BlockImportDatasets datasets(MemoryFile src)
            {
                return data(nameof(BlockImportDatasets), Calc);
                BlockImportDatasets Calc()
                {
                    var dst = new BlockImportDatasets();
                    var lines = AsciLines.lines(src);
                    CalcBlockLines(lines, dst);
                    CalcDatasets(lines,dst);
                    return dst;
                }
            }

            static bool split(string src, out string name, out string value)
            {
                var result = false;
                var i = text.index(src,Chars.Colon);
                if(i > 0)
                {
                    name = text.trim(text.left(src,i));
                    value = text.trim(text.right(src,i));
                    result = true;
                }
                else
                {
                    name = EmptyString;
                    value = EmptyString;
                }
                return result;
            }

            static void CalcBlockLines(ReadOnlySpan<string> src, BlockImportDatasets dst)
            {
                const string FirstItemMarker = "amd_3dnow_opcode:";
                const string LastItemMarker = "EOSZ_LIST:";
                const string Pattern = "{0,-6} | {1,-6} | {2,-6} | {3,-6} | {4,-64}";
                const string Marker = "iform:";
                var fields = InstBlockLineSpec.Empty;
                var buffer = list<LineInterval<InstBlockLineSpec>>();
                var form = InstForm.Empty;
                var name = EmptyString;
                var value = EmptyString;
                var field = InstBlockField.amd_3dnow_opcode;
                var counter = 0u;
                var min = 0u;
                var seq = 0u;
                for(var i=0u; i<src.Length; i++)
                {
                    var line = text.trim(skip(src,i));
                    counter += (uint)line.Length;
                    if(split(line, out name, out value))
                    {
                        if(XedParsers.parse(name, out field))
                            fields.Fields[field] = bit.On;
                    }
                    if(text.begins(line,FirstItemMarker))
                        fields.MinLine = i;
                    else if(text.begins(line, LastItemMarker))
                    {
                        fields.MaxLine = i;
                        fields.MinChar = min;
                        fields.MaxChar = counter;
                        fields.Seq = seq++;
                        fields.Lines = fields.MaxLine - fields.MinLine + 1;
                        dst.BlockLines.Add(fields);
                        buffer.Add(new LineInterval<InstBlockLineSpec>(fields, fields.MinLine, fields.MaxLine));
                        fields = InstBlockLineSpec.Empty;
                        min = counter+1;
                    }
                    else
                    {
                        var j = text.index(line,Marker);
                        if(j >= 0)
                            XedParsers.parse(value, out fields.Form);
                    }
                }

                dst.MappedForms = buffer.ToArray();
            }

            static void CalcDatasets(ReadOnlySpan<string> src, BlockImportDatasets dst)
            {
                var emitter = text.emitter();
                var map = dst.MappedForms;
                var k=0u;
                for(var i=0u; i<map.IntervalCount; i++)
                {
                    ref readonly var range = ref map[i];
                    //dst.FormLines.TryAdd(range.Id.Form, range);
                    var spec = range.Id;
                    var form = spec.Form;
                    var import = InstBlockImport.Empty;
                    var name = EmptyString;
                    var value = EmptyString;
                    var bf = InstBlockField.amd_3dnow_opcode;
                    import.Form = form;
                    import.Seq = i;
                    for(var m =0; m<range.LineCount; m++)
                    {
                        ref readonly var line = ref skip(src,k++);
                        emitter.AppendLine(line);

                        split(line, out name, out value);
                        XedParsers.parse(name, out bf);

                        if(bf == InstBlockField.iclass)
                            XedParsers.parse(value, out import.Class);
                        else if(bf == InstBlockField.pattern)
                        {
                            split(line, out _, out value);
                            try
                            {
                                InstParser.parse(value, out import.Pattern);
                                var fields = InstCells.sort(import.Pattern.Cells);
                                import.Pattern = new (fields);

                            }
                            catch(Exception e)
                            {
                                term.warn(e.Message);
                            }
                        }
                    }
                    dst.BlockImports.Add(import);
                    dst.FormData.TryAdd(form, emitter.Emit());
                }
            }
        }
    }
}