//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.InteropServices;

    using static Root;

    public readonly partial struct ClrDefs
    {
        public static LiteralField literal(Identifier name, ClrLiteralKind type, dynamic value, TextBlock desc)
            => new LiteralField(name, type, value, desc);

        public static LiteralProvider provider(Identifier ns, Identifier name, LiteralField[] fields, TextBlock? desc = null)
            => new LiteralProvider(ns,name, fields, desc ?? EmptyString);
    }
}