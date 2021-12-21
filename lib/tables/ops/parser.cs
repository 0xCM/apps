//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;


    partial struct Tables
    {
        public static RecordParser parser(Type src)
            => new RecordParser(reflected(src));

        public static RecordParser<T> parser<T>()
            where T : struct
                => new RecordParser<T>(reflected(typeof(T)));
    }
}