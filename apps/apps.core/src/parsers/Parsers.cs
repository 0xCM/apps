//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public interface IMultiParser
    {
        Outcome Parse(Type t, string src, out dynamic dst);
    }

    public class Parsers  : AppService<Parsers>, IMultiParser
    {
        Cache ParserCache() => state(nameof(ParserCache), () => new Cache(ApiRuntimeCatalog));

        public IParser RecordParser(Type src)
            => ParserCache().RecordParser(src);

        public SeqParser<T> SeqParser<T>(string delimiter, ParseFunction<T> termparser)
            => new SeqParser<T>(delimiter, termparser);

        public IParser ValueParser(Type t)
            => ParserCache().ValueParser(t);

        public IParser<T> ValueParser<T>()
            => (IParser<T>)ValueParser(typeof(T));

        public Outcome Parse(Type t, string src, out dynamic dst)
            => ParserCache().Parse(t, src, out dst);

        public Outcome Parse<T>(string src, out T dst)
        {
            var result = Parse(typeof(T), src, out var data);
            if(result)
                dst = (T)data;
            else
                dst = default;
            return result;
        }

        public static ConcurrentDictionary<Type,IParser> discover(Assembly[] src, out List<string> log)
        {
            var methods = src.DeclaredStaticMethods().Tagged<ParserAttribute>();
            var count = methods.Length;
            var parsers = dict<Type,IParser>();
            log = list<string>();
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

        class Cache : IMultiParser
        {
            public Cache(IApiCatalog catalog)
            {
                ValueParsers = discover(catalog.Components, out _);
            }

            ConcurrentDictionary<Type, IParser> ValueParsers {get;}

            ConcurrentDictionary<Type, IParser> EnumParsers {get;} = new();

            ConcurrentDictionary<Type, IParser> RecordParsers {get;} = new();

            [MethodImpl(Inline)]
            public IParser RecordParser(Type src)
                => RecordParsers.GetOrAdd(src, t => new RecordParser(Tables.reflected(src), this));

            [MethodImpl(Inline)]
            public IParser EnumParser(Type src)
                => EnumParsers.GetOrAdd(src, t => new EnumParser(t));

            [MethodImpl(Inline)]
            public IParser ValueParser(Type src)
                => ValueParsers[src];

            public Outcome Parse(Type t, string src, out dynamic dst)
            {
                try
                {
                    if(t.IsEnum)
                        return EnumParser(t).Parse(src, out dst);
                    else
                        return ValueParser(t).Parse(src, out dst);
                }
                catch (Exception e)
                {
                    dst = default;
                    return e;
                }
            }
        }
    }
}