//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Represents a line of text in the context of a line-oriented text data source
    /// </summary>
    [StructLayout(StructLayout,Pack=1)]
    public readonly struct TextLine : IComparable<TextLine>
    {
        /// <summary>
        /// The number of characters consumed by the line number
        /// </summary>
        public const byte NumberWidth = 8;

        /// <summary>
        /// The line number of the data source from which the line was extracted
        /// </summary>
        public readonly LineNumber LineNumber;

        /// <summary>
        /// The line content
        /// </summary>
        public readonly string Content;

        [MethodImpl(Inline)]
        public TextLine(uint number, string text)
        {
            LineNumber = number;
            Content = text ?? EmptyString;
        }

        [MethodImpl(Inline)]
        public TextLine(int number, string text)
        {
            LineNumber = (uint)number;
            Content = text ?? EmptyString;
        }

        public char this[int charidx]
        {
            [MethodImpl(Inline)]
            get => Content[charidx];
        }

        public ReadOnlySpan<char> Data
        {
            [MethodImpl(Inline)]
            get => Content;
        }

        public Index<string> Cells(char delimiter)
            => text.trim(text.split(Content, delimiter));

        public Index<string> Cells(char delimiter, uint count)
        {
            var cells = Cells(delimiter);
            if(cells.Count != count)
                Errors.Throw(AppMsg.CellCountMismatch.Format(cells.Count, count, Content));
            return cells;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Content?.Length ?? 0;
        }

        public TextBlock Trim()
            => IsNonEmpty ? Content.Trim() : TextBlock.Empty;

        [MethodImpl(Inline)]
        public static bool nonempty(string src)
            => !string.IsNullOrWhiteSpace(src);

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => nonempty(Content);
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => string.IsNullOrWhiteSpace(Content);
        }

        public bool Contains(string match)
            => IsNonEmpty && Content.Contains(match);

        public int Index(string match)
            => IsNonEmpty ? Content.IndexOf(match) : NotFound;

        public int Index(char match)
            => IsNonEmpty ? Content.IndexOf(match) : NotFound;

        public bool Contains(char match)
            => IsNonEmpty && Content.Contains(match);

        public string Left(int index)
            => index != NotFound ? Content.LeftOfIndex(index) : EmptyString;

        public string Right(int index)
            => index != NotFound ? Content.RightOfIndex(index) : EmptyString;

        public bool StartsWith(char match)
            => IsNonEmpty && Content.StartsWith(match);

        public bool StartsWith(string match)
            => IsNonEmpty && Content.StartsWith(match);

        public bool EndsWith(char match)
            => IsNonEmpty && Content.EndsWith(match);

        public bool EndsWith(string match)
            => IsNonEmpty && Content.EndsWith(match);

        // public ReadOnlySpan<string> Split(in TextDocFormat spec)
        //     => IsNonEmpty ? spec.SplitClean ? Content.SplitClean(spec.Delimiter) : Content.Split(spec.Delimiter) : Array.Empty<string>();

        public ReadOnlySpan<string> Split(char delimiter, bool clean = true)
        {
            if(string.IsNullOrWhiteSpace(Content))
                return Array.Empty<string>();
            else
                return clean ? Content.SplitClean(delimiter) : Content.Split(delimiter);
        }

        public string Format()
            => string.Format("{0}:{1}", LineNumber, Content);


        public override string ToString()
            => Format();

        public string this[int startpos, int endpos]
            => Content.Substring(startpos, endpos - startpos + 1);

        public int CompareTo(TextLine src)
            => LineNumber.CompareTo(src.LineNumber);

        [MethodImpl(Inline)]
        public static implicit operator TextLine((int index, string text) src)
            =>  new TextLine((uint)src.index, src.text);

        [MethodImpl(Inline)]
        public static implicit operator TextLine((uint index, string text) src)
            =>  new TextLine(src.index, src.text);

        public static TextLine Empty
            => new TextLine(0, EmptyString);
    }
}