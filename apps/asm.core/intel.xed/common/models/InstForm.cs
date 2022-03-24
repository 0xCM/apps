//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        public struct InstForm : IEquatable<InstForm>, IComparable<InstForm>
        {
            public readonly IFormType Type;

            [MethodImpl(Inline)]
            public InstForm(IFormType src)
                => Type = src;

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Type != 0;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Type == 0;
            }

            [MethodImpl(Inline)]
            public bool Equals(InstForm src)
                => ((ushort)Type).Equals((ushort)src.Type);

            [MethodImpl(Inline)]
            public int CompareTo(InstForm src)
                => ((ushort)Type).CompareTo((ushort)src.Type);


            public override int GetHashCode()
                =>(int)Type;

            public override bool Equals(object src)
                => src is InstForm && Equals(src);

            public string Format()
                => Type == 0 ? EmptyString :  Type.ToString();

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator InstForm(IFormType src)
                => new InstForm(src);

            [MethodImpl(Inline)]
            public static implicit operator IFormType(InstForm src)
                => src.Type;

            public static InstForm Empty => default;
        }
    }
}