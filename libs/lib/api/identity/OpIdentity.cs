//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Specifies host-independent api member identity
    /// </summary>
    public class OpIdentity : IMethodIdentity<OpIdentity>
    {
        /// <summary>
        /// The operation identifier
        /// </summary>
        public string IdentityText {get;}

        /// <summary>
        /// The unqualified operation name
        /// </summary>
        public string Name {get;}

        /// <summary>
        /// The identifier suffix, if any
        /// </summary>
        public string Suffix {get;}

        /// <summary>
        /// Specifies whether the operation was reified from a generic definition
        /// </summary>
        public bool IsGeneric {get;}

        /// <summary>
        /// Specifies whether the operation is specialized for an immediate value
        /// </summary>
        public bool HasImm {get;}

        /// <summary>
        /// The moniker parts, as determined by part delimiters
        /// </summary>
        public string[] Components {get;}

        internal OpIdentity(string data, string name, string suffix, bool generic, bool imm, string[] components)
        {
            IdentityText = data;
            Name = name;
            Suffix = suffix;
            IsGeneric = generic;
            HasImm = imm;
            Components = components;
        }

        [MethodImpl(Inline)]
        public OpIdentity(string data)
        {
            IdentityText = data;
            Name = EmptyString;
            Suffix = EmptyString;
            IsGeneric = false;
            HasImm = false;
            Components = Array.Empty<string>();
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => string.IsNullOrEmpty(IdentityText);
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !string.IsNullOrEmpty(IdentityText);
        }

        public override int GetHashCode()
            => IdentityText.GetHashCode();

        public bool Equals(OpIdentity src)
            => string.Equals(IdentityText, src.IdentityText, StringComparison.InvariantCultureIgnoreCase);

        public override bool Equals(object src)
            => src is OpIdentity x && Equals(x);

        public string Format()
            => IdentityText;

        public override string ToString()
            => IdentityText;

        [MethodImpl(Inline)]
        public static implicit operator string(OpIdentity src)
            => src.IdentityText;

        [MethodImpl(Inline)]
        public static bool operator==(OpIdentity a, OpIdentity b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator!=(OpIdentity a, OpIdentity b)
            => !a.Equals(b);

        public static OpIdentity Empty
            => new OpIdentity(EmptyString);
    }
}