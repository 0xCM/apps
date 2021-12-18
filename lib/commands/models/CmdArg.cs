//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct CmdArg : ICmdArg
    {
        public uint Index {get;}

        public Name Name {get;}

        public @string Value {get;}

        [MethodImpl(Inline)]
        public CmdArg(string name)
        {
            Index = 0;
            Name = name;
            Value = name;
        }

        [MethodImpl(Inline)]
        public CmdArg(string name, string value)
        {
            Index = 0;
            Name = name;
            Value = value;
        }

        [MethodImpl(Inline)]
        public CmdArg(uint index, string name, string value)
        {
            Index = index;
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

        public override string ToString()
            => Value.IsEmpty ? Name.Format() : string.Format("{0}={1}", Name, Value);

        [MethodImpl(Inline)]
        public static implicit operator string(CmdArg arg)
            => arg.Value;

        [MethodImpl(Inline)]
        public static implicit operator CmdArg(string name)
            => new CmdArg(name);

        public static CmdArg Empty
            => new CmdArg(EmptyString);
    }
}