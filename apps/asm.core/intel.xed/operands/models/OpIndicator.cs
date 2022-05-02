//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        public readonly struct OpIndicator
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

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public bool Equals(OpIndicator src)
                => Data == src.Data;

            public override int GetHashCode()
                => Data.GetHashCode();

            public override bool Equals(object src)
                => src is OpIndicator x && Equals(x);

            [MethodImpl(Inline)]
            public static bool operator ==(OpIndicator a, OpIndicator b)
                => a.Equals(b);

            [MethodImpl(Inline)]
            public static bool operator !=(OpIndicator a, OpIndicator b)
                => !a.Equals(b);

            public static OpIndicator Empty => new OpIndicator(EmptyString);
        }
    }
}