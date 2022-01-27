//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public class OptionRule<T> : Rule
    {
        public T Value {get;}

        public OptionRule(T opt)
        {
            Value = opt;
        }
        public override string Format()
            => text.bracket(Value.ToString());

        public static implicit operator OptionRule<T>(T value)
            => new OptionRule<T>(value);
    }
}