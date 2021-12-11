//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    public class TextVar<K> : ITextVar<K>
        where K : ITextVarKind, new()
    {
        public string Name {get;}

        public K VarKind => new K();

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


        string IVar<string>.Value
            => Value;

        public string Format()
            => text.empty(Value)
            ? string.Format("{0}{1}{2}", TextTemplateVar.LeftDelimiter, Name, TextTemplateVar.RightDelimiter)
            : Value;

        public override string ToString()
            => Format();
    }
}