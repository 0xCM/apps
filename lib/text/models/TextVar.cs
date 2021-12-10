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
        public const char LeftDelimiter = (char)SymNotKind.Lt;

        public const char RightDelimiter = (char)SymNotKind.Gt;

        public readonly string Name;

        public ITextual Value;

        [MethodImpl(Inline)]
        public TextVar(string name)
        {
            Name = name;
            Value = null;
        }

        [MethodImpl(Inline)]
        public TextVar(string name, ITextual val)
        {
            Name = name;
            Value = val;
        }

        public bool IsEmpty => Value is null || text.empty(Value.Format());

        public bool IsNonEmpty => !IsEmpty;

        public string Format()
            => IsNonEmpty
            ? string.Format("{0}{1}{2}", TextVar.LeftDelimiter, Name, TextVar.RightDelimiter)
            : Value.Format();

        public override string ToString()
            => Format();
    }
}