//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Text;

    using static Root;
    using static minicore;

    public class TextBuffer : ITextBuffer
    {
        readonly StringBuilder Target;

        [MethodImpl(Inline)]
        public TextBuffer(StringBuilder dst)
            => Target = dst;

        [MethodImpl(Inline)]
        public TextBuffer(uint capacity)
            => Target = new StringBuilder((int)capacity);

        [MethodImpl(Inline)]
        public StringBuilder ToStringBuilder()
            => Target;

        [MethodImpl(Inline)]
        public string Emit(bool reset = true)
        {
            var content = Target.ToString();
            if(reset)
                Clear();
            return content;
        }

        [MethodImpl(Inline)]
        public void Clear()
        {
            Target.Clear();
        }

        [MethodImpl(Inline)]
        public void Append(string src)
            => Target.Append(src);

        [MethodImpl(Inline)]
        public void AppendLine(string src)
            => Target.AppendLine(src);

        [MethodImpl(Inline)]
        public void AppendLine()
            => Target.AppendLine();

        [MethodImpl(Inline)]
        public void Append(char src)
            => Target.Append(src);

        [MethodImpl(Inline)]
        public void Append(ReadOnlySpan<char> src)
            => Target.Append(src);

        [MethodImpl(Inline)]
        public void AppendFormat(string pattern, params object[] args)
            => Target.AppendFormat(pattern, args);

        [MethodImpl(Inline)]
        public void AppendLineFormat(string pattern, params object[] args)
            => AppendLine(string.Format(pattern, args));

        [MethodImpl(Inline)]
        public void AppendLine<T>(T src)
            => Target.AppendLine(src?.ToString() ?? RP.Null);

        [MethodImpl(Inline)]
        public void Append(char[] src)
            => Target.Append(src);

        [MethodImpl(Inline)]
        public void AppendItem<T>(T src)
            => Append(src?.ToString() ?? RP.Null);

        [MethodImpl(Inline)]
        public void IndentLine<T>(uint margin, T src)
            => AppendLine(string.Format("{0}{1}", new string(Chars.Space, (int)margin), src));

        public void AppendPadded<T,W>(T value, W width, string delimiter = EmptyString)
        {
            if(nonempty(delimiter))
                Append(delimiter);
            Append(string.Format(RP.pad(-i16(width)), value));
        }

        public void Delimit(string delimiter, params object[] src)
        {
            var count = src.Length;
            var terms = @readonly(src);
            var sep = string.Format("{0} ", delimiter);
            for(var i=0; i<src.Length; i++)
                Append(string.Format("{0}{1}", sep, skip(terms,i)));
        }

        public void Delimit<T>(T content, char delimiter, int pad)
        {
            Target.Append(RP.rspace(delimiter));
            Target.Append($"{content}".PadRight((int)pad));
        }

        public void Delimit<F,T>(F label, T content, int pad = 0, char delimiter = FieldDelimiter)
        {
            Target.Append(RP.rspace(delimiter));
            Target.AppendFormat(RP.pad(pad), label);
            Target.Append(content);
        }


        public override string ToString()
            => Target.ToString();

        public void IndentLineFormat(uint margin, string pattern, params object[] args)
            => IndentLine(margin, string.Format(pattern, args));
    }
}