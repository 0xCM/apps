//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    /// <summary>
    /// Defines a nonparametric environment variable
    /// </summary>
    public readonly struct EnvVar : IEnvVar
    {
        public VarSymbol Symbol {get;}

        /// <summary>
        /// The environment variable value
        /// </summary>
        public string Value {get;}

        [MethodImpl(Inline)]
        public EnvVar(string name, string value)
        {
            Symbol = name;
            Value = value;
        }

        [MethodImpl(Inline)]
        public EnvVar(VarSymbol name, string value)
        {
            Symbol = name;
            Value = value;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Symbol.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Symbol.IsNonEmpty;
        }

        public EnvVar<T> Transform<T>(Func<string,T> f)
            => new EnvVar<T>(Symbol.Format(), f(Value));

        [MethodImpl(Inline)]
        public string Format()
            =>  nonempty(Value) ? string.Format("{0}={1}", Symbol, Value) : Symbol.Format();


        public override string ToString()
            => Format();

        public override int GetHashCode()
            => Format().GetHashCode();

        [MethodImpl(Inline)]
        public bool Equals(EnvVar src)
            => string.Equals(Symbol.Format(),src.Symbol.Format(), NoCase) && string.Equals(Value, src.Value, NoCase);

        public override bool Equals(object src)
            => src is EnvVar v && Equals(v);

        [MethodImpl(Inline)]
        public static implicit operator EnvVar((string name, string value) src)
            => new EnvVar(src.name, src.value);

        [MethodImpl(Inline)]
        public static implicit operator string(EnvVar src)
            => src.Value;

        public static EnvVar Empty
        {
            [MethodImpl(Inline)]
            get => new EnvVar(EmptyString, EmptyString);
        }
    }
}