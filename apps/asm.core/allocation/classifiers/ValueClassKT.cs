//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a classification
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly struct ValueClass<K,T>
        where K : unmanaged
    {
        public readonly uint Ordinal;

        public readonly Label ClassName;

        public readonly Label Identifier;

        public readonly Label Symbol;

        public readonly K Kind;

        public readonly T Value;

        [MethodImpl(Inline)]
        public ValueClass(uint ordinal, Label @class, Label ident, Label symbol, K kind, T value)
        {
            Ordinal = ordinal;
            ClassName = @class;
            Identifier = ident;
            Symbol = symbol;
            Kind = kind;
            Value = value;
        }

        [MethodImpl(Inline)]
        public static implicit operator ValueClass<T>(ValueClass<K,T> src)
            => src;
    }
}