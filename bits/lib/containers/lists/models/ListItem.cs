//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct ListItem : IListItem
    {
        public const string HeaderText = " Key      | Value";

        public const string RenderPattern = " {0,-8} | {1}";

        public uint Key {get;}

        public TextBlock Value {get;}

        [MethodImpl(Inline)]
        public ListItem(uint key, string value)
        {
            Key = key;
            Value = value;
        }

        public string Format()
            => string.Format(RenderPattern, Key, Value);

        public override string ToString()
            => Format();
    }
}