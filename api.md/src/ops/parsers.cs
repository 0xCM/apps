//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ApiMd
    {
        static ApiParserLookup parsers(Assembly[] src)
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
    }
}