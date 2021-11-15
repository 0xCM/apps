//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct MimeType : ITextual
    {
        public string BaseTypeName {get;}

        public string SubtypeName {get;}

        [MethodImpl(Inline)]
        public MimeType(string @base, string subtype)
        {
            BaseTypeName = @base;
            SubtypeName = subtype;
        }

        public string Format()
            => string.Format("{0}/{1}", BaseTypeName, SubtypeName);

        public override string ToString()
            => Format();
    }
}