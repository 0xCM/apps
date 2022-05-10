//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public partial class InstSigs
        {
            [DataWidth(Width)]
            public readonly record struct OpIndicator : IComparable<OpIndicator>
            {
                public const byte Width = num8.Width;

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
}