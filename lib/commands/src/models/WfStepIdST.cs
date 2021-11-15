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
    /// Identifies a workflow step
    /// </summary>
    public readonly struct WfStepId<S,T>
        where S : struct
        where T : struct
    {
        public const string RenderPattern = "{0} -> {1}";

        public string HostName
        {
            [MethodImpl(Inline)]
            get => string.Format(RenderPattern, typeof(S).AssemblyQualifiedName, typeof(T).AssemblyQualifiedName);
        }

        [MethodImpl(Inline)]
        public static implicit operator WfHostId(WfStepId<S,T> src)
            => src.Token;

        /// <summary>
        /// The step controller
        /// </summary>
        public Type Source
            => typeof(T);

        /// <summary>
        /// The step effector
        /// </summary>
        public Type Target
            => typeof(S);

        /// <summary>
        /// The step token
        /// </summary>
        public WfHostId Token
        {
            [MethodImpl(Inline)]
            get => new WfHostId(alg.hash.calc<S,T>());
        }

        [MethodImpl(Inline)]
        public bool Equals(WfStepId<S,T> src)
            => true;

        [MethodImpl(Inline)]
        public int CompareTo(WfStepId<S,T> src)
            => 0;

        [MethodImpl(Inline)]
        public string Format()
            => HostName;

        public uint Hashed
        {
            [MethodImpl(Inline)]
            get => (uint)alg.hash.calc<S,T>();
        }

        public ulong Hash64
        {
            [MethodImpl(Inline)]
            get => alg.hash.calc<S,T>();
        }

        public override int GetHashCode()
            => (int)Hashed;


        public override bool Equals(object src)
            => src is WfStepId x && Equals(x);

        public override string ToString()
            => Format();
    }
}