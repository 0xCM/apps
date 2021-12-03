//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;

    using static Root;

    [ApiHost]
    public class ParseFunctions
    {
        Dictionary<Type,IParser> _Parsers;

        public ParseFunctions()
        {
            _Parsers = new Dictionary<Type,IParser>();
        }

        public ParseFunctions(ReadOnlySpan<IParser> src)
            : this()
        {
            foreach(var item in src)
                Include(item);
        }

        [Op, Closures(UnsignedInts)]
        public bool Parse<T>(string src, out T dst)
        {
            if(Lookup(typeof(T), out var parser))
            {
                if(parser.Parse(src, out var parsed))
                {
                    dst = (T)parsed;
                    return true;
                }
            }
            dst = default;
            return false;
        }

        [MethodImpl(Inline)]
        public void Include(IParser parser)
            => _Parsers[parser.TargetType] = parser;

        [MethodImpl(Inline)]
        public bool Lookup(Type target, out IParser parser)
            => _Parsers.TryGetValue(target, out parser);

        [MethodImpl(Inline)]
        public bool CanParse(Type target)
            => _Parsers.ContainsKey(target);

        [MethodImpl(Inline)]
        public IParser Require(Type target)
            => _Parsers[target];
    }
}