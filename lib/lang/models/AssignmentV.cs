//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Root;

    public class Assignment<V>
        where V : IValue
    {
        public Identifier Name {get;}

        public V Value {get;}

        public Assignment(Identifier name, V value)
        {
            Name = name;
            Value = value;
        }
    }
}