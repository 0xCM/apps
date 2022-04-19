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
        public VarSymbol Name {get;}

        /// <summary>
        /// The environment variable value
        /// </summary>
        public string Value {get;}

        [MethodImpl(Inline)]
        public EnvVar(string name, string value)
        {
            Name = name;
            Value = value;
        }

        [MethodImpl(Inline)]
        public EnvVar(VarSymbol name, string value)
        {
            Name = name;
            Value = value;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsNonEmpty;
        }

        public EnvVar<T> Transform<T>(Func<string,T> f)
            => new EnvVar<T>(Name.Format(), f(Value));

        [MethodImpl(Inline)]
        public string Format()
            =>  nonempty(Value) ? string.Format("{0}={1}", Name, Value) : Name.Format();


        public override string ToString()
            => Format();

        public override int GetHashCode()
            => Format().GetHashCode();

        [MethodImpl(Inline)]
        public bool Equals(EnvVar src)
            => Name.Equals(src.Name) && string.Equals(Value, src.Value, NoCase);

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