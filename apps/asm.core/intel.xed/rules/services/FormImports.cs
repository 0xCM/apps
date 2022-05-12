//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;
    using static XedRules;

    partial class XedRules
    {
        public readonly struct FormImports
        {
            public const byte FormImportFieldCount = 6;

            const char FieldDelimiter = Chars.Space;

            public static Index<FormImport> Calc()
            {
                var src = CalcFormSources();
                var count = src.Count;
                var rows = alloc<FormImport>(count);
                for(var i=z16; i<count; i++)
                {
                    var result = parse(src[i], i, out seek(rows,i));
                    if(result.Fail)
                        Errors.Throw(result.Message);
                }
                return rows.Sort().Resequence();
            }

            public static ReadOnlySpan<FormImport> LoadImported()
            {
                const char CommentMarker = Chars.Hash;

                return Load();
                Index<FormImport> Load()
                {
                    var src = XedPaths.Service.FormCatalogPath();
                    var counter = 0u;
                    var outcome = Outcome.Success;
                    var dst = list<FormImport>();
                    using var reader = src.AsciReader();
                    reader.ReadLine();
                    while(!reader.EndOfStream)
                    {
                        var line = reader.ReadLine(counter);
                        if(line.StartsWith(CommentMarker) || line.IsEmpty)
                            continue;

                        outcome = parse(line.Content, out FormImport row);
                        if(outcome)
                            dst.Add(row);
                        else
                        {
                            term.warn(outcome.Message.Replace("{", "{{").Replace("}","}}"));
                        }

                        counter++;
                    }
                    if(outcome)
                        return dst.ToArray();
                    else
                        return default;
                }
            }

            static Outcome parse(string src, out FormImport dst)
            {
                const char Delimiter = Chars.Pipe;
                dst = FormImport.Empty;
                var result = Outcome.Success;
                var reader = text.trim(text.split(text.trim(text.despace(src)), Delimiter)).Reader();
                result = XedParsers.parse(reader.Next(), out dst.Seq);
                if(result.Fail)
                    return (false, AppMsg.ParseFailure.Format(nameof(dst.Seq), reader.Prior()));

                result = XedParsers.parse(reader.Next(), out dst.InstForm);
                if(result.Fail)
                    return (false, AppMsg.ParseFailure.Format(nameof(dst.InstForm), reader.Prior()));

                result = XedParsers.parse(reader.Next(), out dst.InstClass);
                if(result.Fail)
                    return (false, AppMsg.ParseFailure.Format(nameof(dst.InstClass), reader.Prior()));

                result = DataParser.eparse(reader.Next(), out dst.Category);
                if(result.Fail)
                    return (false, AppMsg.ParseFailure.Format(nameof(dst.Category), reader.Prior()));

                result = DataParser.eparse(reader.Next(), out dst.IsaKind);
                if(result.Fail)
                    return (false, AppMsg.ParseFailure.Format(nameof(dst.IsaKind), reader.Prior()));

                result = DataParser.eparse(reader.Next(), out dst.Extension);
                if(result.Fail)
                    return (false, AppMsg.ParseFailure.Format(nameof(dst.Extension), reader.Prior()));

                dst.Attributes = XedPatterns.attributes(reader.Next());

                return result;
            }


            static Index<FormSource> CalcFormSources()
            {
                const char CommentMarker = Chars.Hash;
                var src = XedPaths.Service.DocSource(XedDocKind.FormData);
                var tableid = Tables.identify<FormSource>();
                using var reader = src.Utf8Reader();
                var counter = 0u;
                var header = alloc<string>(FormImportFieldCount);
                var succeeded = true;
                var records = list<FormSource>();
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
                            Errors.Throw(outcome.Message);
                            break;
                        }
                    }
                    else
                    {
                    var dst = new FormSource();
                    var outcome = ParseSummary(line, out dst);
                    if(outcome)
                            records.Add(dst);
                    else
                    {
                            Errors.Throw(outcome.Message);
                            break;
                    }
                    }

                    counter++;
                }

                return records.ToArray();
            }

            static Outcome parse(in FormSource src, ushort seq, out FormImport dst)
            {
                var result = Outcome.Success;
                result = XedParsers.parse(src.Class, out dst.InstClass);
                result = DataParser.eparse(src.Extension, out dst.Extension);
                result = DataParser.eparse(src.Category, out dst.Category);
                result = XedParsers.parse(src.Form, out dst.InstForm);
                dst.Seq = (ushort)dst.InstForm.Kind;
                result = DataParser.eparse(src.IsaSet, out dst.IsaKind);
                dst.Attributes = XedPatterns.attributes(src.Attributes);
                return true;
            }

            static Outcome ParseSummary(TextLine src, out FormSource dst)
            {
                dst = default;
                var parts = text.despace(src.Content).Split(FieldDelimiter);
                var count = parts.Length;
                if(count != FormImportFieldCount)
                    return(false, $"Line splits into {count} parts, not {FormImportFieldCount} as required");
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
                if(count != FormImportFieldCount)
                    return(false, $"Line splits into {count} parts, not {FormImportFieldCount} as required");

                for(var i=0; i<count; i++)
                    seek(dst,i) = skip(parts,i);

                return true;
            }
        }
    }
}