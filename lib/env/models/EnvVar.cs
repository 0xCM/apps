//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    /// <summary>
    /// Defines a nonparametric environment variable
    /// </summary>
    [Record(TableId)]
    public readonly record struct EnvVar : IEnvVar, IComparable<EnvVar>
    {
        const string TableId = "env";

        [Render(64)]
        public readonly VarSymbol VarName;

        /// <summary>
        /// The environment variable value
        /// </summary>
        [Render(1)]
        public readonly string VarValue;

        [MethodImpl(Inline)]
        public EnvVar(string name, string value)
        {
            VarName = name;
            VarValue = value;
        }

        [MethodImpl(Inline)]
        public EnvVar(VarSymbol name, string value)
        {
            VarName = name;
            VarValue = value;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => VarName.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => VarName.IsNonEmpty;
        }

        public bool Contains(string match)
            => text.contains(VarValue,match);

        public bool Contains(ReadOnlySpan<char> match)
            => text.contains(VarValue,match);

        public bool Contains(char match)
            => text.contains(VarValue,match);

        public EnvVar<T> Transform<T>(Func<string,T> f)
            where T : IEquatable<T>
                => new EnvVar<T>(VarName.Format(), f(VarValue));

        [MethodImpl(Inline)]
        public string Format()
            =>  nonempty(VarValue) ? string.Format("{0}={1}", VarName, VarValue) : VarName.Format();


        public override string ToString()
            => Format();

        public override int GetHashCode()
            => Format().GetHashCode();

        [MethodImpl(Inline)]
        public bool Equals(EnvVar src)
            => VarName.Equals(src.VarName) && string.Equals(VarValue, src.VarValue, NoCase);

        public int CompareTo(EnvVar src)
            => VarName.CompareTo(src.VarName);

        [MethodImpl(Inline)]
        public static implicit operator EnvVar((string name, string value) src)
            => new EnvVar(src.name, src.value);

        [MethodImpl(Inline)]
        public static implicit operator string(EnvVar src)
            => src.VarValue;

        public static EnvVar Empty
        {
            [MethodImpl(Inline)]
            get => new EnvVar(EmptyString, EmptyString);
        }

        VarSymbol IVarValue.VarName
            => VarName;

        string IVarValue.VarValue
            => VarValue;
    }
}