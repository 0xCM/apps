//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using TE = TextEncodingKind;

    partial struct Root
    {
        public const TE unicode = TE.Unicode;

        public const TE asci7 = TE.Asci;

        public const TE UTF8 = TE.Utf8;
    }
}