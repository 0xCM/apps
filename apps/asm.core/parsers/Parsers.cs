//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class Parsers
    {
        [MethodImpl(Inline)]
        public static EnumParser<E> @enum<E>()
            where E : unmanaged, Enum
                => new();
        public static RecordParser record(Type src)
            => new RecordParser(Tables.reflected(src));

        public static RecordParser<T> record<T>()
            where T : struct
                => new RecordParser<T>(Tables.reflected(typeof(T)));

        public static Parsers Service => Instance;

        public SeqParser<T> SeqParser<T>(string delimiter, ParseFunction<T> termparser)
            => new SeqParser<T>(delimiter, termparser);

        public bool Find(Type t, out IParser parser)
            => Lookup.Find(t, out parser);

        public IParser<T> Parser<T>()
        {
            if(Find(typeof(T), out var parser))
                return (IParser<T>)parser;
            else
                return ParseFunction<T>.Empty;
        }

        public static ConstLookup<Type,IParser> discover(Assembly[] src, out List<string> log)
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

            return parsers.ToConstLookup();
        }

        public static ConstLookup<Type,IParser> discover(out List<string> log)
            => discover(ApiRuntimeLoader.catalog().Components.Storage, out log);

        public ReadOnlySpan<Arrow<Name,Type>> Identities
            => _Identities;

        public Outcome Parse(Type t, string src, out dynamic dst)
        {
            var result = Outcome.Failure;
            dst = default;
            try
            {
                if(Find(t, out var parser))
                    result = parser.Parse(src, out dst);
            }
            catch(Exception e)
            {
                result = e;
            }
            return result;
        }

        public Outcome Parse<T>(string src, out T dst)
        {
            var result = Outcome.Failure;
            dst = default;
            try
            {
                if(Find(typeof(T), out var parser))
                {
                    result = parser.Parse(src, out var parsed);
                    if(result)
                        dst = parsed;
                }
            }
            catch(Exception e)
            {
                result = e;
            }
            return result;
        }

        Parsers()
        {
            Lookup = discover(out _);
            _Identities = Lookup.Keys.Select(x => new Arrow<Name,Type>("string", x)).ToArray();
        }

        ConstLookup<Type,IParser> Lookup;

        Index<Arrow<Name,Type>> _Identities;

        static Parsers()
        {
            Instance = new();
        }

        static Parsers Instance;

    }
}