//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static Root;

    [ApiHost]
    public readonly partial struct Tables
    {
        const NumericKind Closure = UInt64k;

        internal const string DefaultDelimiter = " | ";

        internal const byte DefaultFieldWidth = 24;
    }
}