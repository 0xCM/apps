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
        class BlockImportDatasets
        {
            public static ReadOnlySpan<LineStats> stats(MemoryFile src)
                => AsciLines.stats(src.View(),400000);

            public static BlockImportDatasets calc(MemoryFile src)
            {
                var lines = AsciLines.lines(src);
                return calc(blockmap(lines),lines);
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

            static LineMap<FormFields> blockmap(ReadOnlySpan<string> src)
            {
                const string FirstItemMarker = "amd_3dnow_opcode:";
                const string LastItemMarker = "EOSZ_LIST:";
                const string Pattern = "{0,-6} | {1,-6} | {2,-6} | {3,-6} | {4,-64}";
                const string Marker = "iform:";
                var fields = FormFields.Empty;
                var buffer = list<LineInterval<FormFields>>();
                var form = InstForm.Empty;
                var name = EmptyString;
                var value = EmptyString;
                var field = BlockField.amd_3dnow_opcode;
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
                        buffer.Add(new LineInterval<FormFields>(fields, fields.MinLine, fields.MaxLine));
                        fields = FormFields.Empty;
                        min = counter+1;
                    }
                    else
                    {
                        var j = text.index(line,Marker);
                        if(j >= 0)
                            XedParsers.parse(value, out fields.Form);
                    }
                }

                return buffer.ToArray();
            }

            static BlockImportDatasets calc(LineMap<FormFields> map, ReadOnlySpan<string> src)
            {
                var dst = CalcDatasets(map,src);
                return data(nameof(BlockImportDatasets), () => dst);
            }

            static BlockImportDatasets CalcDatasets(LineMap<FormFields> map, ReadOnlySpan<string> src)
            {
                var dst = new BlockImportDatasets();
                dst.LineMap = map;
                var emitter = text.emitter();
                var k=0u;
                for(var i=0u; i<map.IntervalCount; i++)
                {
                    ref readonly var range = ref map[i];
                    dst.Received.TryAdd(range.Id.Form, range);
                    var spec = range.Id;
                    var form = spec.Form;
                    var import = InstBlockImport.Empty;
                    var name = EmptyString;
                    var value = EmptyString;
                    var bf = BlockField.amd_3dnow_opcode;
                    import.Form = form;
                    import.Seq = i;
                    for(var m =0; m<range.LineCount; m++)
                    {
                        ref readonly var line = ref skip(src,k++);
                        emitter.AppendLine(line);

                        split(line, out name, out value);
                        XedParsers.parse(name, out bf);

                        if(bf == BlockField.iclass)
                            XedParsers.parse(value, out import.Class);
                        else if(bf == BlockField.pattern)
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
                    dst.Imports.Add(import);
                    dst.Data.TryAdd(form, emitter.Emit());
                }

                return dst;
            }

            public LineMap<FormFields> LineMap;

            public ConcurrentDictionary<InstForm,LineInterval<FormFields>> Received = new();

            public ConcurrentBag<InstBlockImport> Imports = new();

            public ConcurrentDictionary<InstForm,string> Data = new();
        }
    }
}