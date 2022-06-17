//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a value-parametric environment variable
    /// </summary>
    public readonly record struct EnvVar<T> : IEnvVar<T>
        where T : IEquatable<T>
    {
        public readonly VarSymbol VarName {get;}

        public readonly T VarValue {get;}

        [MethodImpl(Inline)]
        public EnvVar(string name, T value)
        {
            VarName = name;
            VarValue = value;
        }


        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => core.hash(Format());
        }

        public string Format()
            => $"{VarName}={VarValue}";

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => Hash;

        public bool Equals(EnvVar<T> src)
            => VarName.Equals(src.VarName)
            && VarValue.Equals(src.VarValue);

        [MethodImpl(Inline)]
        public static implicit operator EnvVar(EnvVar<T> src)
            => new EnvVar(src.VarName, src.VarValue.ToString());

        [MethodImpl(Inline)]
        public static implicit operator EnvVar<T>((string name, T value) src)
            => new EnvVar<T>(src.name, src.value);

        [MethodImpl(Inline)]
        public static implicit operator T(EnvVar<T> src)
            => src.VarValue;
    }
}