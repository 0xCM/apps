//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang
{
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// A terminal atomic
    /// </summary>
    public readonly struct Atom : ISymbol<Atom,char>, ITerminalExpr<char>
    {
        public uint Key {get;}

        public char Value {get;}

        [MethodImpl(Inline)]
        public Atom(uint key, char value)
        {
            Key = key;
            Value = value;
        }

        [MethodImpl(Inline)]

        public bool Equals(Atom src)
            => src.Value == Value;

        [MethodImpl(Inline)]
        public int CompareTo(Atom src)
            => Value.CompareTo(src.Value);

        public string Format()
            => Value.ToString();

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => (int)Key;

        public override bool Equals(object src)
            => src is Atom a && Equals(a);

        [MethodImpl(Inline)]
        public static bool operator ==(Atom a, Atom b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator !=(Atom a, Atom b)
            => !a.Equals(b);

        public static Atom Empty => default;

        [MethodImpl(Inline)]
        public static implicit operator char(Atom src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator Atom((uint key, char value) src)
            => new Atom(src.key, src.value);

        [MethodImpl(Inline)]
        public static implicit operator Atom(Atom<char> src)
            => new Atom(src.Key, src.Value);
    }
}