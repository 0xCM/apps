//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct CmdOption : ICmdOption
    {
        public Name Name {get;}

        public @string Value {get;}

        [MethodImpl(Inline)]
        public CmdOption(string name, string value)
        {
            Name = name;
            Value = value;
        }

        [MethodImpl(Inline)]
        public CmdOption(string value)
        {
            Name = EmptyString;
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

        public string Format()
            => Value.IsEmpty ? Name.Format() : string.Format("{0}={1}", Name, Value);

        public override string ToString()
            => Format();

        public static CmdOption Empty
        {
            [MethodImpl(Inline)]
            get => new CmdOption(EmptyString);
        }
    }
}