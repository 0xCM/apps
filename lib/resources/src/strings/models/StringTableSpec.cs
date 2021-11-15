//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public class StringTableSpec
    {
        readonly Index<ListItem<string>> _Entries;

        public Identifier Namespace {get;}

        public Identifier TableName {get;}

        public StringTableSpec(Identifier ns, Identifier table, ListItem<string>[] entries)
        {
            Namespace = ns;
            TableName = table;
            _Entries = entries;
        }

        public ReadOnlySpan<ListItem<string>> Entries
        {
            [MethodImpl(Inline)]
            get => _Entries.View;
        }
    }
}