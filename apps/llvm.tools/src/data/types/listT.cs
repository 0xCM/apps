//-----------------------------------------------------------------------------------------//
// Source : LLVM - https://github.com/llvm/llvm-project/
// License: Apache-2.0 WITH LLVM-exception
//-----------------------------------------------------------------------------------------//
namespace Z0.llvm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct list<T> : IIndex<T>
    {
        public const string Identifier = "list<{0}>";

        public static ParserDelegate<list<T>> parser(ParserDelegate<T> itemparser)
        {
            Outcome parse(string src, out list<T> dst)
            {
                var seqparser = new SeqParser<T>(",", new ParseFunction<T>(itemparser));
                var result = seqparser.Parse(src, out var items);
                if(result)
                    dst = new list<T>(items);
                else
                    dst = Empty;
                return result;
            }
            return parse;
        }

        readonly Index<T> Data;

        [MethodImpl(Inline)]
        public list(T[] src)
        {
            Data = src;
        }

        public ReadOnlySpan<T> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsNonEmpty;
        }

        public T[] Storage
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public string TypeName
            => string.Format(Identifier, typeof(T).Name);

        public string Format()
            => string.Format("[{0}]", text.join(",", View));

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator list<T>(T[] src)
            => new list<T>(src);

        public static list<T> Empty => new list<T>(sys.empty<T>());
    }
}