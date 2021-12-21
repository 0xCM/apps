//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public readonly struct RecordParser<T> : IParser<T>
        where T : struct
    {
        readonly RecordParser Parser;

        [MethodImpl(Inline)]
        public RecordParser(ReflectedTable table)
        {
            Parser = new RecordParser(table);
        }

        public Outcome Parse(string src, out T dst)
        {
            var result = Parser.Parse(src, out var _dst);
            if(result)
                dst = (T)_dst;
            else
                dst = default;
            return result;
        }
    }
}