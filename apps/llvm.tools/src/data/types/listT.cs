//-----------------------------------------------------------------------------------------//
// Source : LLVM - https://github.com/llvm/llvm-project/
// License: Apache-2.0 WITH LLVM-exception
//-----------------------------------------------------------------------------------------//
namespace Z0.llvm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public class list<T>
    {
        public const string Identifier = "list<{0}>";

        public static ParserDelegate<list<T>> parser(ParserDelegate<T> itemparser)
        {
            Outcome parse(string src, out list<T> dst)
            {
                var seqparser = new SeqParser<T>(",", new ParseFunction<T>(itemparser));
                var result = seqparser.Parse(src, out var items);
                if(result)
                {
                    dst = items;
                }
                else
                    dst = Empty;
                return result;
            }
            return parse;
        }

        Index<T> _Data;

        [MethodImpl(Inline)]
        public list(T[] src)
        {
            _Data = src;
        }

        public ReadOnlySpan<T> Items
        {
            [MethodImpl(Inline)]
            get => _Data.View;
        }

        public string TypeName
            => string.Format(Identifier, typeof(T).Name);

        public string Format()
            => string.Format("[{0}]", text.join(",", Items));

        public override string ToString()
            => Format();

        public static implicit operator list<T>(T[] src)
            => new list<T>(src);

        public static list<T> Empty => new list<T>(sys.empty<T>());
    }
}