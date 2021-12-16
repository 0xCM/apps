//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Lifts literal values to type
    /// </summary>
    /// <typeparam name="K"></typeparam>
    public class LiteralType<V> : ILiteralType<V>
        where V : ITyped
    {
        public Identifier Name {get;}

        public V Value {get;}

        public LiteralType(Identifier name, V value)
        {
            Name = name;
            Value = value;
        }

        public string Format()
            => string.Format("{0}:{1}={2}", Name, Value.Type, Value);
    }
}