//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public partial class Parsers : AppService<Parsers>, IMultiParser
    {
        MultiParser Mp() => state(nameof(Mp), () => new MultiParser(discover(Wf.Components)));

        public IParser RecordParser(Type t)
            => Mp().RecordParser(t);

        public IParser<T> RecordParser<T>()
            where T : struct
                => Mp().RecordParser<T>();

        public SeqParser<T> SeqParser<T>(IParser<T> terms, string delimiter)
            => new SeqParser<T>(terms, delimiter);

        public SeqParser<T> SeqParser<T>(string delimiter)
            => Mp().SeqParser<T>(delimiter);

        public IParser ValueParser(Type t)
            => Mp().ValueParser(t);

        public IParser<T> ValueParser<T>()
            => Mp().ValueParser<T>();

        public IParser EnumParser(Type src)
            => Mp().EnumParser(src);

        public IParser<E> EnumParser<E>()
            where E : unmanaged, Enum
                => Mp().EnumParser<E>();

        public IParser<T> EnumParser<E,T>()
            where E : unmanaged, Enum
                where T : unmanaged
                    => Mp().EnumValueParser<E,T>();

        public Outcome Parse(Type t, string src, out dynamic dst)
            => Mp().Parse(t, src, out dst);

        public Outcome Parse<T>(string src, out T dst)
            => Mp().Parse(src, out dst);

        public Outcome Parse<T>(string sep, string src, out T[] dst)
            => Mp().Parse<T>(sep, src, out dst);
    }
}