//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;
    using System.Collections.Generic;

    using static core;

    public class Parsers
    {
        public static Parsers Service => Instance;

        public SeqParser<T> SeqParser<T>(string delimiter, ParseFunction<T> termparser)
            => new SeqParser<T>(delimiter, termparser);

        public bool Find(Type t, out IParser parser)
            => Lookup.Find(t, out parser);

        public static ConstLookup<Type,IParser> lookup(out List<string> log)
        {
            var src = ApiRuntimeLoader.catalog().Components.Storage;
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
                }
            }

            return parsers.ToConstLookup();
        }

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
            Lookup = lookup(out _);
        }

        ConstLookup<Type,IParser> Lookup;

        static Parsers()
        {
            Instance = new();
        }

        static Parsers Instance;
    }

}