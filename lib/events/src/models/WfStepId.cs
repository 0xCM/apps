//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct WfStepId : IWfStepId
    {
        public CliToken HostKey {get;}

        public string HostName {get;}

        public string HostIdentifier
            => HostName.Contains(Chars.Comma) && HostName.Contains(Chars.Dot) ? HostName.LeftOfFirst(Chars.Comma).RightOfLast(Chars.Dot) : HostName;

        [MethodImpl(Inline)]
        public WfStepId(Name name)
        {
            HostName = name;
            HostKey = CliToken.Empty;
        }

        [MethodImpl(Inline)]
        public WfStepId(Type control)
        {
            HostName = control.AssemblyQualifiedName;
            HostKey = control.MetadataToken;
        }

        /// <summary>
        /// The step token
        /// </summary>
        public WfHostId Token
        {
            [MethodImpl(Inline)]
            get => WfHostId.create(this);
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Token.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Token.IsNonEmpty;
        }

        [MethodImpl(Inline)]
        public bool Equals(WfStepId src)
            => Token.Value == src.Token.Value;

        [MethodImpl(Inline)]
        public int CompareTo(WfStepId src)
            => HostName.CompareTo(src.HostName);

        [MethodImpl(Inline)]
        public string Format()
            => HostIdentifier;

        public uint Hashed
        {
            [MethodImpl(Inline)]
            get => FastHash.calc(Token.Hash64);
        }

        public override int GetHashCode()
            => (int)Hashed;

        public override bool Equals(object src)
            => src is WfStepId i && Equals(i);

        public override string ToString()
            => Format();

        public static WfStepId Empty
            => new WfStepId(typeof(void));

        [MethodImpl(Inline)]
        public static implicit operator WfStepId(Type control)
            => new WfStepId(control);

        public static implicit operator WfStepId(Name name)
            => new WfStepId(name);
    }
}