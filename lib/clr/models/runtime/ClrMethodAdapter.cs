//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct ClrMethodAdapter : IClrRuntimeMethod<ClrMethodAdapter>
    {
        [MethodImpl(Inline)]
        public static ClrMethodAdapter adapt(MethodInfo src)
            => new ClrMethodAdapter(src);

        public MethodInfo Definition {get;}

        [MethodImpl(Inline)]
        public ClrMethodAdapter(MethodInfo src)
            => Definition = src;

        public CliToken Token
        {
            [MethodImpl(Inline)]
            get => Definition.MetadataToken;
        }

        public ClrMemberName Name
        {
            [MethodImpl(Inline)]
            get => Definition;
        }

        public Assembly Assembly
        {
            [MethodImpl(Inline)]
            get => DeclaringType.Assembly;
        }

        public ClrTypeAdapter DeclaringType
        {
            [MethodImpl(Inline)]
            get => Definition.DeclaringType ?? typeof(void);
        }

        public CallingConventions CallingConvention
        {
            [MethodImpl(Inline)]
            get => Definition.CallingConvention;
        }

        public RuntimeMethodHandle MethodHandle
        {
            [MethodImpl(Inline)]
            get => Definition.MethodHandle;
        }

        public MemoryAddress HandleAddress
        {
            [MethodImpl(Inline)]
            get => Definition.MethodHandle.Value;
        }

        public MemoryAddress PointerAddress
        {
            [MethodImpl(Inline)]
            get => MethodHandle.GetFunctionPointer();
        }

        public MethodDisplaySig DisplaySig
        {
            [MethodImpl(Inline)]
            get => Definition.DisplaySig();
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Definition is null;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !IsEmpty;
        }

        [MethodImpl(Inline)]
        public string Format()
            => Definition.Name;

        public ClrArtifactKind Kind
            => ClrArtifactKind.Method;

        public override bool Equals(object obj)
            => Definition.Equals(obj);

        public override int GetHashCode()
            => Definition.GetHashCode();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static bool operator ==(ClrMethodAdapter lhs, ClrMethodAdapter rhs)
            => lhs.Equals(rhs);

        [MethodImpl(Inline)]
        public static bool operator !=(ClrMethodAdapter lhs, ClrMethodAdapter rhs)
            => !lhs.Equals(rhs);

        [MethodImpl(Inline)]
        public static implicit operator MethodInfo(ClrMethodAdapter src)
            => src.Definition;

        [MethodImpl(Inline)]
        public static implicit operator ClrMethodAdapter(MethodInfo src)
            => adapt(src);
    }
}