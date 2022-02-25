//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ScalarType : SizedType, IScalarType, IEquatable<ScalarType>
    {
        public ScalarClass ScalarClass {get;}

        [MethodImpl(Inline)]
        public ScalarType(Identifier name, ScalarClass kind, BitWidth content, BitWidth storage)
            : base(name, nameof(ScalarType), (ulong)kind, content, storage)
        {
            ScalarClass = kind;
        }


        public bool Equals(ScalarType src)
            => Name.Equals(src.Name) && ContentWidth == src.ContentWidth;

        public static ScalarType Empty
        {
            [MethodImpl(Inline)]
            get => new ScalarType(EmptyString, ScalarClass.None, 0, 0);
        }
    }
}