//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    public interface ITextVar : ITextual
    {
        string Name {get;}

        string Value {get;}
    }

    public interface ITextVar<T> : ITextVar
        where T : ITextual, INullity
    {
        new T Value {get;}

        string ITextVar.Value
            => Value.Format();
    }

    public class TextVar<T> : ITextVar<T>
        where T : ITextual, INullity
    {
        public string Name {get;}

        public T Value;

        [MethodImpl(Inline)]
        public TextVar(string name)
        {
            Name = name;
            Value = default;
        }

        [MethodImpl(Inline)]
        public TextVar(string name, T val)
        {
            Name = name;
            Value = val;
        }

        T ITextVar<T>.Value => Value;

        public string Format()
            => (Value is null || Value.IsEmpty)
            ? string.Format("{0}{1}{2}", TextVar.LeftDelimiter, Name, TextVar.RightDelimiter)
            : Value.Format();

        public override string ToString()
            => Format();
    }
}