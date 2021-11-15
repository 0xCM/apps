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
    /// Defines a kinded argument
    /// </summary>
    public struct ToolCmdArg<K,T>
        where K : unmanaged
    {
        public K Kind {get;}

        public T Value {get;}

        [MethodImpl(Inline)]
        public ToolCmdArg(K kind, T value)
        {
            Kind = kind;
            Value = value;
        }

        [MethodImpl(Inline)]
        public string Format()
            => Cmd.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator ToolCmdArg<K,T>((K kind, T value) src)
            => new ToolCmdArg<K,T>(src.kind, src.value);

        [MethodImpl(Inline)]
        public static implicit operator ToolCmdArg<K,T>(Paired<K,T> src)
            => new ToolCmdArg<K,T>(src.Left, src.Right);

        [MethodImpl(Inline)]
        public static implicit operator ToolCmdArg(ToolCmdArg<K,T> src)
            => new ToolCmdArg(src.Kind.ToString(), src.Value?.ToString() ?? EmptyString);

        [MethodImpl(Inline)]
        public static implicit operator ToolCmdArg<T>(ToolCmdArg<K,T> src)
            => new ToolCmdArg<T>(src.Kind.ToString(), src.Value);
    }
}