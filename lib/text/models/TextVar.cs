//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    public class TextVar
    {
        public static TextVar define(string name)
            => new TextVar(name);

        public const char LeftDelimiter = (char)SymNotKind.Lt;

        public const char RightDelimiter = (char)SymNotKind.Gt;

        public readonly string Name;

        public string Value;

        [MethodImpl(Inline)]
        public TextVar(string name)
        {
            Name = name;
            Value = EmptyString;
        }

        [MethodImpl(Inline)]
        public TextVar(string name, string val)
        {
            Name = name;
            Value = val;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => text.empty(Value);
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => text.nonempty(Value);
        }

        public string Format()
            => IsEmpty
            ? string.Format("{0}{1}{2}", TextVar.LeftDelimiter, Name, TextVar.RightDelimiter)
            : Value;

        public override string ToString()
            => Format();
    }
}