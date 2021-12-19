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
        public static ParserDelegate<list<T>> parser(string type, ParserDelegate<T> itemparser)
        {
            Outcome parse(string src, out list<T> dst)
            {
                var input = text.fenced(src, RenderFence.Bracketed, out _) ? text.unfence(src, RenderFence.Bracketed) : src;
                var seqparser = new SeqParser<T>(",", new ParseFunction<T>(itemparser));
                var result = seqparser.Parse(src, out var items);
                if(result)
                    dst = new list<T>(type, items);
                else
                    dst = Empty;
                return result;
            }
            return parse;
        }

        readonly Index<T> Data;

        public string ListType {get;}

        [MethodImpl(Inline)]
        public list(string type, T[] src)
        {
            ListType = type;
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

        public ref T this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public ref T this[int i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public string Format()
            => string.Format("[{0}]", text.join(",", View));

        public override string ToString()
            => Format();

        public static list<T> Empty => new list<T>(EmptyString, sys.empty<T>());
    }
}