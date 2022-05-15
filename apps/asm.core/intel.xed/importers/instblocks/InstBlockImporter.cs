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
        public class InstBlockImporter : IDisposable
        {
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

            public static LineMap<FormFields> linemap(ReadOnlySpan<string> src)
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

            void Process(LineMap<FormFields> map, ReadOnlySpan<string> lines)
            {
                var emitter = text.emitter();
                var k=0u;
                for(var i=0u; i<map.IntervalCount; i++)
                {
                    ref readonly var range = ref map[i];
                    Received.TryAdd(range.Id.Form, range);
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
                        ref readonly var line = ref skip(lines,k++);
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
                            }
                            catch(Exception e)
                            {
                                AppSvc.Warn(e.Message);
                            }
                        }
                    }
                    Imports.Add(import);
                    Data.TryAdd(form, emitter.Emit());
                }
            }

            ConcurrentDictionary<InstForm,LineInterval<FormFields>> Received = new();

            ConcurrentDictionary<InstForm,string> Data = new();

            SortedLookup<InstForm,uint> FormSeq;

            ConcurrentBag<InstBlockImport> Imports = new();

            ConcurrentDictionary<InstForm,string> Descriptions = new();

            ConcurrentDictionary<InstForm,string> Headers = new();

            readonly AppServices AppSvc;

            XedPaths XedPaths;

            MemoryFile File;

            const uint Partition = 128;

            readonly uint FileSize;

            readonly uint BlockSize;

            readonly uint BlockCount;

            readonly uint Remainder;

            readonly uint Contiguous;

            readonly uint Parts;

            readonly uint PartRemainder;

            static W256 w => default;

            public InstBlockImporter(AppServices svc)
            {
                AppSvc = svc;
                XedPaths = XedPaths.Service;
                File = XedPaths.InstDumpSource().MemoryMap(true);
                BlockSize = (uint)w.DataWidth/8;
                FileSize = (uint)File.Size;
                BlockCount = FileSize/BlockSize;
                Remainder = FileSize%BlockSize;
                Contiguous = BlockCount*BlockSize;
                Parts = BlockCount/Partition;
                PartRemainder = BlockCount%Partition;
            }

            void Process(InstForm form)
            {
                if(form.IsNonEmpty)
                {
                    var dst = InstBlockImport.Empty;
                    var range = Received[form];
                    var content = Data[form];
                    var seq = FormSeq[form];
                    Descriptions[form] = content;
                    Headers[form] = string.Format("{0,-64} | {1:D5} | {2:D2} | {3:D6} | {4:D6}", form, seq, range.LineCount, (uint)range.MinLine, (uint)range.MaxLine);
                }
            }

            Index<InstForm> CalcFormSeq()
            {
                var keys = Data.Keys.Index().Sort();
                var dst = dict<InstForm,uint>();
                for(var i=0u; i<keys.Count; i++)
                    dst[keys[i]] = i;
                FormSeq = dst;
                return keys;
            }

            public void Run()
            {
                var src = Lines.lines(File);
                EmitEol();
                var map = linemap(src);
                Process(map,src);
                Emit();
                EmitLineMap(map, XedPaths.Imports().Path("xed.instblocks.linemap", FileKind.Csv));
            }

            void EmitEol()
            {
                var dst = text.buffer();
                dst.AppendLine(LineStats.Header);
                var data = stats(File);
                for(var i=0; i<data.Length; i++)
                    dst.AppendLine(skip(data,i).Format());
                AppSvc.FileEmit(dst.Emit(), data.Length, XedPaths.Imports().Path(LineStats.TableId, FileKind.Csv));
            }

            void Emit()
            {
                var forms = CalcFormSeq();
                iter(forms,Process,true);
                var dst = XedPaths.Imports().Path("xed.instblocks.detail", FileKind.Txt);
                using var writer = dst.AsciWriter();
                var emitting = AppSvc.EmittingFile(dst);
                for(var i=0u; i<forms.Count; i++)
                {
                    ref readonly var key = ref forms[i];
                    if(key.IsEmpty)
                        continue;

                    writer.AppendLine(Headers[key]);
                    writer.WriteLine(RP.PageBreak120);
                    writer.AppendLine(Descriptions[key]);
                    writer.WriteLine();
                }

                AppSvc.EmittedFile(emitting, forms.Count);

                var records = Imports.Index().Sort().Resequence();
                AppSvc.TableEmit(records, XedPaths.Imports().Table<InstBlockImport>());
            }

            public void EmitLineMap(LineMap<FormFields> data, FS.FilePath dst)
            {
                const string Pattern = "{0,-6} | {1,-12} | {2,-12} | {3,-12} | {4,-12} | {5,-6} | {6,-64} | {7}";
                var formatter = Tables.formatter<FormFields>();
                var emitting = AppSvc.EmittingTable<FormFields>(dst);
                using var writer = dst.AsciWriter();
                writer.WriteLine(formatter.FormatHeader());
                for(var i=0u; i<data.IntervalCount; i++)
                {
                    ref readonly var seg = ref data[i];
                    ref readonly var content = ref seg.Id;
                    writer.WriteLine(formatter.Format(content));
                }
                AppSvc.EmittedTable(emitting, data.IntervalCount);
            }

            public void Dispose()
            {
                File.Dispose();
            }
        }
    }
}