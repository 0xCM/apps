//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.IO;

    using static Root;
    using static core;

    [ApiHost]
    public readonly struct TextGrids
    {
        public static Outcome load(FS.FilePath src, uint width, out FixedTextGrid dst)
        {
            try
            {
                dst = FixedTextGrid.load(width,src.ReadUnicode());
                return true;
            }
            catch(Exception e)
            {
                dst = default;
                return e;
            }
        }

        public static Outcome load(FS.FilePath src, TextEncodingKind encoding, out TextGrid dst)
        {
            dst = TextGrid.Empty;
            if(!src.Exists)
                return (false,FS.missing(src));

            using var reader = src.Reader(encoding);
            var result =  parse(reader);
            if(result)
            {
                dst = result.Value;
                return true;
            }
            else
            {
                return (false, string.Format("Unable to parse grid: {0}", result.Message));
            }
        }

        public static Outcome load(FS.FilePath src, out TextGrid dst)
            => load(src, TextDocFormat.Structured(), out dst);

        public static Outcome load(FS.FilePath src, TextDocFormat format, out TextGrid dst)
        {
            dst = TextGrid.Empty;
            if(!src.Exists)
                return (false,FS.missing(src));

            using var reader = src.Utf8Reader();
            var attempt =  parse(reader,format);
            if(attempt)
            {
                dst = attempt.Value;
                return true;
            }
            else
            {
                return (false, attempt.Message?.ToString());
            }
        }

        [Op]
        public static Outcome resource(Asset src, TextDocFormat format, out TextGrid dst)
        {
            var content = Resources.utf8(src);
            using var stream = content.Stream();
            using var reader = new StreamReader(stream);
            var result = parse(reader, format);
            if(result)
            {
                dst = result.Value;
                return true;
            }
            else
            {
                dst = TextGrid.Empty;
                return false;
            }
        }

        [Op]
        public static Outcome resource(Asset src, out TextGrid dst)
        {
            var content = Resources.utf8(src);
            using var stream = content.Stream();
            using var reader = new StreamReader(stream);
            var result = parse(reader, TextDocFormat.Structured());
            if(result)
            {
                dst = result.Value;
                return true;
            }
            else
            {
                dst = TextGrid.Empty;
                return false;
            }
        }

        public static ReadOnlySpan<TextGrid> load(ReadOnlySpan<FS.FilePath> src)
        {
            var dst = bag<TextGrid>();
            iter(src, path => {
                using var reader = path.Utf8Reader();
                var attempt = parse(reader);
                if(attempt)
                    dst.Add(attempt.Value);
            },true);
            return dst.ToArray();
        }

        /// Parses a header row from a line of text
        /// </summary>
        /// <param name="src">The source line</param>
        /// <param name="spec">The text format</param>
        [Op]
        public static bool header(TextLine src, in TextDocFormat spec, out TextDocHeader dst)
        {
            var parts = src.Split(spec);
            var count = parts.Length;
            var buffer = list<string>();

            if(parts.Length != 0)
            {
                for(var i=0; i<count; i++)
                {
                    var part = skip(parts,i).Trim();
                    if(nonempty(part))
                        buffer.Add(part);
                }
            }

            if(buffer.Count != 0)
            {
                dst = new TextDocHeader(buffer.ToArray());
                return true;
            }

            dst = TextDocHeader.Empty;
            return false;
        }

        public static ReadOnlySpan<string> header(string src, char delimiter)
        {
            var dst = Span<string>.Empty;
            if(nonempty(src))
            {
                var parts = src.SplitClean(delimiter).ToReadOnlySpan();
                var count = (uint)parts.Length;
                dst = span<string>(count);
                for(var i=0; i<count; i++)
                    seek(dst,i) = skip(parts,i);
            }
            return dst;
        }

        public static Outcome parse(string src, out TextGrid dst, TextDocFormat? format = null)
        {
            using var stream = src.ToStream();
            using var reader = stream.CreateReader();
            var result = parse(reader, format);
            if(result)
            {
                dst = result.Value;
                return true;
            }
            else
            {
                dst = default;
                return (false,result.Message?.ToString());
            }
        }

        public static Outcome load(ReadOnlySpan<string> src, out TextGrid dst)
        {
            dst = TextGrid.Empty;
            var result = Outcome.Success;
            var rows = list<TextRow>();
            var counter = 1u;
            var fmt = TextDocFormat.Structured();
            var comment = fmt.CommentPrefix;
            var rowsep = fmt.RowBlockSep;
            var count = src.Length;
            Option<TextDocHeader> docheader = default;

            try
            {
                for(var i=0; i<count; i++)
                {
                    var data = skip(src,i).Trim();

                    if(text.blank(data))
                        continue;

                    counter++;

                    var line = new TextLine(counter, data);
                    var lead = line[0];

                    // skip comments
                    if(lead == comment)
                        continue;

                    // skip row separators
                    if(line.Content.StartsWith(rowsep))
                        continue;

                    if(fmt.HasHeader && docheader.IsNone() && rows.Count == 0)
                    {
                        if(TextGrids.header(line, fmt, out var _docheader))
                            docheader = _docheader;
                    }
                    else
                    {
                        if(row(line,fmt, out var _row))
                            rows.Add(_row);
                    }
                }

                dst = new TextGrid(fmt, docheader ? docheader.Value : TextDocHeader.Empty, rows.ToArray());
            }
            catch(Exception e)
            {
                return e;
            }

            return result;
        }

        /// <summary>
        /// Attempts to parse a text document and returns the result if successful
        /// </summary>
        /// <param name="src">The source document path</param>
        /// <param name="format">The document format</param>
        /// <param name="observer">An optional observer to witness intersting events</param>
        public static ParseResult<TextGrid> parse(StreamReader reader, TextDocFormat? format = null)
        {
            var rows = list<TextRow>();
            var counter = 1u;
            var fmt = format ?? TextDocFormat.Structured();
            var comment = fmt.CommentPrefix;
            var rowsep = fmt.RowBlockSep;
            Option<TextDocHeader> docheader = default;
            try
            {
                while(!reader.EndOfStream)
                {
                    var data = reader.ReadLine().Trim();

                    counter++;

                    // Nothing to see here
                    if(text.blank(data))
                        continue;

                    var line = new TextLine(counter, data);
                    var lead = line[0];

                    // skip comments
                    if(lead == comment)
                        continue;

                    // skip row separators
                    if(line.Content.StartsWith(rowsep))
                        continue;

                    if(fmt.HasHeader && docheader.IsNone() && rows.Count == 0)
                    {
                        if(TextGrids.header(line, fmt, out var _docheader))
                            docheader = _docheader;
                    }
                    else
                    {
                        if(row(line,fmt, out var _row))
                            rows.Add(_row);
                    }
                }

                var doc = new TextGrid(fmt, docheader ? docheader.Value : TextDocHeader.Empty, rows.ToArray());
                return ParseResult.parsed(string.Empty, doc);
            }
            catch(Exception e)
            {
                return ParseResult.unparsed<TextGrid>(EmptyString,e);
            }
        }

        /// <summary>
        /// Parses a row from a line of text
        /// </summary>
        /// <param name="src">The source text</param>
        /// <param name="spec">The text format spec</param>
        [Op]
        public static bool row(TextLine src, in TextDocFormat spec, out TextRow dst)
        {
            if(skipline(src, spec))
            {
                dst = TextRow.Empty;
                return false;
            }
            else
            {
                if(spec.HasHeader)
                {
                    var parts = src.Split(spec);
                    var count = parts.Length;
                    var buffer = alloc<TextBlock>(count);
                    ref var target= ref first(buffer);
                    for(var i=0u; i<count; i++)
                        seek(target, i) = new TextBlock(skip(parts,i).Trim());
                    dst= new TextRow(buffer);
                }
                else
                    dst = new TextRow(new TextBlock(src.Content));

                return true;
            }
        }

        public static ParseResult<string,TextGrid> parse(FS.FilePath src, TextDocFormat? format = null)
        {
            using var reader = src.Utf8Reader();
            return parse(reader, format).Select(doc => ParseResult.parsed(src.Name.Format(), doc)).Value;
        }

        public static ParseResult<T> parse<T>(string data, Func<TextGrid,ParseResult<T>> pfx)
        {
            using var stream = Streams.memory(data);
            using var reader = Streams.reader(stream);
            return from doc in parse(reader)
                from content in pfx(doc)
                select content;
        }

        [MethodImpl(Inline), Op]
        static bool skipline(TextLine src, in TextDocFormat spec)
            => src.IsEmpty || src.StartsWith(spec.CommentPrefix) || src.StartsWith(spec.RowBlockSep);
    }
}