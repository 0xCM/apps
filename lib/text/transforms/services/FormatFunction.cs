//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct FormatFunction : IFormatter
    {
        public Type SourceType {get;}

        readonly FormatterDelegate F;

        [MethodImpl(Inline),Op]
        public FormatFunction(Type target, FormatterDelegate f)
        {
            SourceType = target;
            F = f;
        }

        [MethodImpl(Inline),Op]
        public string Format(dynamic src)
            => F(src);
    }
}