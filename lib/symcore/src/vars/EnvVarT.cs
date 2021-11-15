//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Defines a value-parametric environment variable
    /// </summary>
    public readonly struct EnvVar<T> : IEnvVar
    {
        public Name Name {get;}

        public T Value {get;}

        public VarSymbol Symbol
            => new VarSymbol(Name);

        string IRuleVar.Value
            => Value?.ToString() ?? EmptyString;

        [MethodImpl(Inline)]
        public EnvVar(string name, T value)
        {
            Name = name;
            Value = value;
        }

        public string Format()
            => $"{Name}={Value}";

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => Format().GetHashCode();

        public bool Equals(EnvVar<T> src)
            => string.Equals(Name,src.Name, NoCase)
            && Object.Equals(Value, src.Value);

        public override bool Equals(object src)
            => src is EnvVar<T> v && Equals(v);

        public static implicit operator EnvVar(EnvVar<T> src)
            => new EnvVar(src.Name, src.Value.ToString());

        [MethodImpl(Inline)]
        public static implicit operator EnvVar<T>((string name, T value) src)
            => new EnvVar<T>(src.name, src.value);

        [MethodImpl(Inline)]
        public static implicit operator T(EnvVar<T> src)
            => src.Value;
    }
}