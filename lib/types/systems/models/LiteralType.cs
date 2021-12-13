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
        where V : unmanaged, IScalarValue
    {
        public Identifier Name {get;}

        public ScalarType ScalarType {get;}

        public V Value {get;}

        public LiteralType(Identifier name, ScalarType type, V value)
        {
            Name = name;
            ScalarType = type;
            Value = value;
        }

        public string Format()
            => string.Format("{0}:{1}={2}", Name, ScalarType, Value);
    }
}