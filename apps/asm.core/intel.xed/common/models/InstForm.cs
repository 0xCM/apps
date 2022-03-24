//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [DataWidth(16)]
        public struct InstForm : IEquatable<InstForm>, IComparable<InstForm>
        {
            public readonly IFormType Kind;

            [MethodImpl(Inline)]
            public InstForm(IFormType src)
                => Kind = src;

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Kind != 0;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Kind == 0;
            }

            [MethodImpl(Inline)]
            public bool Equals(InstForm src)
                => ((ushort)Kind).Equals((ushort)src.Kind);

            [MethodImpl(Inline)]
            public int CompareTo(InstForm src)
                => ((ushort)Kind).CompareTo((ushort)src.Kind);


            public override int GetHashCode()
                =>(int)Kind;

            public override bool Equals(object src)
                => src is InstForm && Equals(src);

            public string Format()
                => Kind == 0 ? EmptyString :  Kind.ToString();

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator InstForm(IFormType src)
                => new InstForm(src);

            [MethodImpl(Inline)]
            public static implicit operator IFormType(InstForm src)
                => src.Kind;

            public static InstForm Empty => default;
        }
    }
}