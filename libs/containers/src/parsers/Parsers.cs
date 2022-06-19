//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public partial class Parsers : AppService<Parsers>, IMultiParser
    {
        // public static ItemList<string> list(FS.FilePath src, char delimiter = Chars.Comma)
        // {
        //     var items = ItemLists.items(src.ReadText().SplitClean(delimiter).Select(x => x.Trim()).Where(text.nonempty).ToReadOnlySpan());
        //     var name = src.FileName.WithoutExtension.Format();
        //     return new ItemList<string>(items);
        // }

        public static ParserDelegate<list<T>> ListParser<T>(string type, ParserDelegate<T> terms)
        {
            Outcome parse(string src, out list<T> dst)
            {
                var input = text.fenced(src, RenderFence.Bracketed, out _) ? text.unfence(src, RenderFence.Bracketed) : src;
                var seqparser = new SeqParser<T>(new ParseFunction<T>(terms), ",");
                var result = seqparser.Parse(src, out var items);
                if(result)
                    dst = new list<T>(items);
                else
                    dst = list<T>.Empty;
                return result;
            }
            return parse;
        }


        public static ref BufferSegments<T> split<T>(SeqSplitter<T> parser, Span<T> src, out BufferSegments<T> dst)
            where T : unmanaged
        {
            dst = new BufferSegments<T>(src, byte.MaxValue);
            parser.InputCount = (uint)src.Length;
            parser.LastPos = parser.InputCount - 1;
            var segment = ClosedInterval<uint>.Zero;
            while(parser.Unfinished())
            {
                ref readonly var cell = ref core.skip(src, parser.CellPos);
                if(parser.OnLastPos())
                {
                    if(parser.Collecting)
                        dst.Range(parser.SegPos, parser.I0, parser.I1);
                }
                else if(parser.IsDelimiter(cell))
                {
                    if(parser.Collecting)
                    {
                        dst.Range(parser.SegPos, parser.I0, parser.I1 - 1);
                        parser.NextSeg();
                    }

                    parser.I0 = parser.CellPos + 1;
                    parser.I1 = parser.I0;
                    parser.Collecting = true;
                    segment = parser.MarkSegment();
                }
                else if(parser.Collecting)
                    parser.NextPoint();

                parser.NextCell();
            }

            dst.Dispensed = parser.SegPos + 1;
            return ref dst;
        }

        MultiParser Mp() => state(nameof(Mp), () => new MultiParser(discover(Wf.Components)));

        [MethodImpl(Inline)]
        public static SeqSplitter<T> splitter<T>(T delimiter)
            where T : unmanaged
                => new SeqSplitter<T>(delimiter);

        public IParser RecordParser(Type t)
            => Mp().RecordParser(t);

        public IParser<T> RecordParser<T>()
            where T : struct
                => Mp().RecordParser<T>();

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

        public static ApiParserLookup contracted(Assembly[] src)
        {
            var log = text.emitter();
            var dst = new ApiParserLookup();
            var methods = src.DeclaredStaticMethods().Tagged<ParserAttribute>().Index();
            for(var i=0; i<methods.Count; i++)
            {
                ref readonly var method = ref methods[i];
                var @return = method.ReturnType;
                if(@return == typeof(Outcome) || @return == typeof(bool))
                {
                    var parameters = method.Parameters().Index();
                    if(parameters.Count == 2)
                    {
                        ref readonly var input = ref parameters[0];
                        ref readonly var output = ref parameters[1];
                        var target = output.ParameterType.EffectiveType();
                        if(input.ParameterType != typeof(string))
                            continue;

                        if(target.ContainsGenericParameters)
                            continue;

                        log.AppendLine(string.Format("Making a parser from {0}", method.DisplaySig()));
                        var @delegate = default(Delegate);
                        if(@return == typeof(Outcome))
                            @delegate = method.CreateDelegate(typeof(ParserContracts.GenericOutcome<>).MakeGenericType(target));
                        else
                            @delegate = method.CreateDelegate(typeof(ParserContracts.GenericBool<>).MakeGenericType(target));
                        var parseFx = typeof(ParserContracts.ParseFunction<>).MakeGenericType(target);
                        var service = (ParserContracts.IParser)Activator.CreateInstance(parseFx, @delegate);
                        dst.TryAdd(service.TargetType, new ApiParser(method, service));
                    }
                }
            }

            return dst;
        }

        public static ConcurrentDictionary<Type,IParser> discover(Assembly[] src)
        {
            var methods = src.DeclaredStaticMethods().Tagged<ParserAttribute>();
            var count = methods.Length;
            var parsers = dict<Type,IParser>();
            var log = list<string>();
            for(var i=0; i<count; i++)
            {
                ref readonly var method = ref skip(methods,i);
                if(method.ReturnType.Name == nameof(Outcome))
                {
                    var parameters = method.Parameters();
                    if(parameters.Length == 2)
                    {
                        try
                        {
                            ref readonly var input = ref skip(parameters,0);
                            ref readonly var output = ref skip(parameters,1);
                            var target = output.ParameterType.EffectiveType();

                            if(input.ParameterType != typeof(string))
                                continue;

                            if(target.ContainsGenericParameters)
                                continue;

                            log.Add(string.Format("Making a parser from {0}", method.DisplaySig()));
                            var @delegate = method.CreateDelegate(typeof(ParserDelegate<>).MakeGenericType(target));
                            var parseFx = typeof(ParseFunction<>).MakeGenericType(target);
                            var parser = (IParser)Activator.CreateInstance(parseFx, @delegate);
                            parsers[parser.TargetType] = parser;
                        }
                        catch(Exception)
                        {
                            term.error(string.Format("Unable to create parser delegate from {0}.{1}", method.DeclaringType, method.Name));
                        }
                    }
                }
            }

            return parsers.ToConcurrentDictionary();
        }
    }
}