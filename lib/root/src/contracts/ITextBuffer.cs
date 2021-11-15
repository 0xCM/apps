//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Text;

    using static Root;

    public interface ITextBuffer : IRenderBuffer<string,string>
    {
        void AppendLine();

        void Append(ReadOnlySpan<char> src);

        void Append(char[] src);

        void AppendFormat(string pattern, params object[] args);

        void Append(char c);

        StringBuilder ToStringBuilder();

        void AppendLine(string src);

        void AppendLine<T>(T src);

        void AppendLineFormat(string pattern, params object[] args);

        void IndentLine<T>(uint margin, T src);

        void IndentLineFormat(uint margin, string pattern, params object[] args);

        void AppendItem<T>(T src);

        void Delimit(string delimiter, params object[] src);

        void AppendPadded<T,W>(T value, W width, string delimiter = EmptyString);

        void Delimit<T>(T content, char delimiter, int pad);

        void Delimit<F,T>(F label, T content, int pad = 0, char delimiter = FieldDelimiter);

        void AppendSpace()
            => Append(Space);
    }
}