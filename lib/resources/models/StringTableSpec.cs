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

        public StringTableSyntax Syntax {get;}

        public Identifier Namespace
            => Syntax.Namespace;

        public Identifier TableName
            => Syntax.TableName;

        public Identifier IndexName
            => Syntax.IndexName;

        public bool GlobalIndex
            => Syntax.GlobalIndex;

        public StringTableSpec(StringTableSyntax syntax, ListItem<string>[] entries)
        {
            Syntax = syntax;
            _Entries = entries;
        }

        public ReadOnlySpan<ListItem<string>> Entries
        {
            [MethodImpl(Inline)]
            get => _Entries.View;
        }
    }
}