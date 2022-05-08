//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [DataWidth(num8.Width)]
        public readonly record struct OpIndicator : IComparable<OpIndicator>
        {
            readonly asci8 Data;

            [MethodImpl(Inline)]
            internal OpIndicator(string src)
            {
                Data = src;
            }

            [MethodImpl(Inline)]
            public string Format()
                => Data.Format();

            public int CompareTo(OpIndicator src)
                => Data.CompareTo(src.Data);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public bool Equals(OpIndicator src)
                => Data == src.Data;

            public override int GetHashCode()
                => Data.GetHashCode();

            public static OpIndicator Empty => new OpIndicator(EmptyString);
        }
    }
}