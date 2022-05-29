//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class Parsers
    {
        public static ApiParserLookup _discover(Assembly[] src)
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