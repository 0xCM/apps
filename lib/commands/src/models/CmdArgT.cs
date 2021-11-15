//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct CmdArg<T>
    {
        public string Name {get;}

        public T Value {get;}

        [MethodImpl(Inline)]
        public CmdArg(ushort pos, T value)
        {
            Value = value;
            Name = EmptyString;
        }

        [MethodImpl(Inline)]
        public CmdArg(ushort index, string name, T value)
        {
            Value = value;
            Name = name;
        }

        [MethodImpl(Inline)]
        public static implicit operator CmdArg<T>((int index, T value) src)
            => new CmdArg<T>((ushort)src.index, src.value);

        [MethodImpl(Inline)]
        public static implicit operator CmdArg(CmdArg<T> src)
            => new CmdArg(src.Name, src.Value.ToString());

        public static CmdArg<T> Empty
            => new CmdArg<T>(0, default(T));
    }
}