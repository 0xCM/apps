//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    using static Root;
    using static core;

    partial class IntelXed
    {
        public void ImportForms()
        {
            var src = ParseFormSources().View;
            var dst = FormCatalogPath();
            var formatter = Tables.formatter<XedFormImport>(XedFormImport.RenderWidths);
            var count = src.Length;
            var result = Outcome.Success;
            var rows = list<XedFormImport>();
            for(var i=z16; i<count; i++)
            {
                result = XedModels.parse(skip(src,i), i, out var import);

                if(result)
                    rows.Add(import);
                else
                {
                    Error(result.Message);
                    break;
                }
            }

            rows.Sort();

            TableEmit(rows.ViewDeposited(), XedFormImport.RenderWidths, dst);
        }

        Index<XedFormSource> ParseFormSources()
        {
            var src = FormSourcePath();
            var tableid = Tables.identify<XedFormSource>();
            var flow = Running(string.Format("Loading form sources from {0}", src.ToUri()));
            using var reader = src.Utf8Reader();
            var counter = 0u;
            var header = alloc<string>(XedFormSource.FieldCount);
            var succeeded = true;
            var records = list<XedFormSource>();
            while(!reader.EndOfStream)
            {
                var line = reader.ReadLine(counter);

                if(line.StartsWith(CommentMarker) || line.IsEmpty)
                    continue;

                if(counter==0)
                {
                    var outcome = ParseSourceHeader(line,header);
                    if(!outcome)
                    {
                        Error(outcome.Message);
                        succeeded = false;
                        break;
                    }
                }
                else
                {
                   var dst = new XedFormSource();
                   var outcome = ParseSummary(line, out dst);
                   if(outcome)
                        records.Add(dst);
                   else
                   {
                        Error(outcome.Message);
                        succeeded = false;
                        break;
                   }
                }

                counter++;

            }

            if(succeeded)
                Ran(flow, Tables.imported(counter, src).ToString());

            return records.ToArray();
        }

        static Outcome ParseSummary(TextLine src, out XedFormSource dst)
        {
            dst = default;
            var parts = text.despace(src.Content).Split(FieldDelimiter);
            var count = parts.Length;
            if(count != XedFormSource.FieldCount)
                return(false, $"Line splits into {count} parts, not {XedFormSource.FieldCount} as required");
            var i = 0;
            dst.Class = skip(parts,i++);
            dst.Extension = skip(parts,i++);
            dst.Category = skip(parts,i++);
            dst.Form = skip(parts,i++);
            dst.IsaSet = skip(parts,i++);
            dst.Attributes = skip(parts,i++);
            return true;
        }


        static Outcome ParseSourceHeader(TextLine src, Span<string> dst)
        {
            var parts = src.Split(FieldDelimiter);
            var count = parts.Length;
            if(count != XedFormSource.FieldCount)
                return(false, $"Line splits into {count} parts, not {XedFormSource.FieldCount} as required");

            for(var i=0; i<count; i++)
                seek(dst,i) = skip(parts,i);

            return true;
        }


    }
}