//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a version schema that supports 2, 3 or 4 32-bit segments
    /// </summary>
    public readonly record struct ApiVersion : IDataType<ApiVersion>
    {
        /// <summary>
        /// The most-significant segment value
        /// </summary>
        public readonly uint A;

        /// <summary>
        /// The secondary segment value
        /// </summary>
        public readonly uint B;

        /// <summary>
        /// The tertiary segment value, or 0 if none
        /// </summary>
        public readonly uint C;

        /// <summary>
        /// The least-significant segment value, or 0 if none
        /// </summary>
        public readonly uint D;

        [MethodImpl(Inline)]
        public ApiVersion(uint a, uint b = 0, uint c = 0, uint d = 0)
        {
            A = a;
            B = b;
            C = c;
            D = d;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => core.hash(A, B, C, D);
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => A == 0 && B == 0 && C == 0 && D == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => A != 0 || B != 0 || C != 0 || D != 0;
        }

        public string Format()
            => string.Format(RpOps.SlotDot4, A, B, C, D);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(ApiVersion src)
            => A == src.A && B == src.B && C == src.C && D == src.D;


        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public int CompareTo(ApiVersion src)
        {
            var result = A.CompareTo(src.A);
            if(result == 0)
            {
                result = B.CompareTo(src.B);
                if(result==0)
                {
                    result = C.CompareTo(src.C);
                    if(result == 0)
                        result = D.CompareTo(src.D);
                }
            }

            return result;
        }

        [MethodImpl(Inline)]
        public static bool operator <(ApiVersion a, ApiVersion b)
            => a.CompareTo(b) < 0;

        [MethodImpl(Inline)]
        public static bool operator <=(ApiVersion a, ApiVersion b)
            => a.CompareTo(b) <= 0;

        [MethodImpl(Inline)]
        public static bool operator >(ApiVersion a, ApiVersion b)
            => b < a;

        [MethodImpl(Inline)]
        public static bool operator >=(ApiVersion a, ApiVersion b)
            => b <= a;

        [MethodImpl(Inline)]
        public static implicit operator ApiVersion((uint a, uint b) src)
            => new ApiVersion(src.a, src.b);

        [MethodImpl(Inline)]
        public static implicit operator ApiVersion(Version src)
            => new ApiVersion((uint)src.Major, (uint)src.Minor, (uint)src.MajorRevision, (uint)src.MinorRevision);
    }
}