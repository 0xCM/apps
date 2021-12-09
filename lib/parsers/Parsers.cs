//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class Parsers
    {
        public static Parsers Service => Instance;

        public SeqParser<T> SeqParser<T>(string delimiter, ParseFunction<T> termparser)
            => new SeqParser<T>(delimiter, termparser);

        public SeqParser<T> SeqParser<T>(string delimiter, ParserDelegate<T> termparser)
            => new SeqParser<T>(delimiter, termparser);

        Parsers()
        {

        }

        static Parsers()
        {
            Instance = new();
        }
        static Parsers Instance;
    }

}