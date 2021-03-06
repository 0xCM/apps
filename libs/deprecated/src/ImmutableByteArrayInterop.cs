//-----------------------------------------------------------------------------
// Copyright   :  (c) Microsoft/.NET Foundation
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Collections.Immutable;
    using System.Runtime.InteropServices;

    partial class SRM
    {
        /// <summary>
        /// Provides tools for using <see cref="ImmutableArray{Byte}"/> in interop scenarios.
        /// </summary>
        /// <remarks>
        /// *** WARNING ***
        ///
        /// If you decide to copy this code elsewhere, please retain the documentation here
        /// and the Dangerous prefixes in the API names. This will help track down and audit
        /// other places where this technique (with dangerous consequences when misused) may
        /// be applied.
        ///
        /// A generic version of this API was once public in a pre-release of immutable
        /// collections, but  it was deemed to be too subject to abuse when available publicly.
        ///
        /// This implementation is scoped to byte arrays as that is all that the metadata reader needs.
        ///
        /// Also, since we don't have access to immutable collection internals, we use a trick involving
        /// overlapping a <see cref="ImmutableArray{Byte}"/> with an array reference. While
        /// unverifiable, it is valid. See ECMA-335, section II.10.7 Controlling instance layout:
        ///
        /// "It is possible to overlap fields in this way, though offsets occupied by an object reference
        /// shall not overlap with offsets occupied by a built-in value type or a part of
        /// another object reference. While one object reference can completely overlap another, this is
        /// unverifiable."
        ///
        /// Furthermore, the fact that <see cref="ImmutableArray{Byte}"/> backed by a single byte array
        /// field is something inherent to the design of ImmutableArray in order to get its performance
        /// characteristics and therefore something we (Microsoft) are comfortable defining as a contract that
        /// can be depended upon as below.
        /// </remarks>
        public static unsafe class ImmutableByteArrayInterop
        {
            /// <summary>
            /// Creates a new instance of <see cref="ImmutableArray{Byte}"/> using a given mutable array as the backing
            /// field, without creating a defensive copy. It is the responsibility of the caller to ensure no other mutable
            /// references exist to the array.  Do not mutate the array after calling this method.
            /// </summary>
            /// <param name="array">The mutable array to use as the backing field. The incoming reference is set to null
            /// since it should not be retained by the caller.</param>
            /// <remarks>
            /// Users of this method should take extra care to ensure that the mutable array given as a parameter
            /// is never modified. The returned <see cref="ImmutableArray{T}"/> will use the given array as its backing
            /// field without creating a defensive copy, so changes made to the given mutable array will be observable
            /// on the returned <see cref="ImmutableArray{T}"/>.  Instance and static methods of <see cref="ImmutableArray{T}"/>
            /// and <see cref="ImmutableArray"/> may malfunction if they operate on an <see cref="ImmutableArray{T}"/> instance
            /// whose underlying backing field is modified.
            /// </remarks>
            /// <returns>An immutable array.</returns>
            public static ImmutableArray<byte> DangerousCreateFromUnderlyingArray(ref byte[]? array)
            {
                byte[] givenArray = array!;
                array = null;

                ByteArrayUnion union = default;
                union.UnderlyingArray = givenArray;
                return union.ImmutableArray;
            }

            /// <summary>
            /// Access the backing mutable array instance for the given <see cref="ImmutableArray{T}"/>, without
            /// creating a defensive copy.  It is the responsibility of the caller to ensure the array is not modified
            /// through the returned mutable reference.  Do not mutate the returned array.
            /// </summary>
            /// <param name="array">The <see cref="ImmutableArray{T}"/> from which to retrieve the backing field.</param>
            /// <remarks>
            /// Users of this method should take extra care to ensure that the returned mutable array is never modified.
            /// The returned mutable array continues to be used as the backing field of the given <see cref="ImmutableArray{T}"/>
            /// without creating a defensive copy, so changes made to the returned mutable array will be observable
            /// on the given <see cref="ImmutableArray{T}"/>.  Instance and static methods of <see cref="ImmutableArray{T}"/>
            /// and <see cref="ImmutableArray"/> may malfunction if they operate on an <see cref="ImmutableArray{T}"/> instance
            /// whose underlying backing field is modified.
            /// </remarks>
            /// <returns>The underlying array, or null if <see cref="ImmutableArray{T}.IsDefault"/> is true.</returns>
            public static byte[]? DangerousGetUnderlyingArray(ImmutableArray<byte> array)
            {
                ByteArrayUnion union = default;
                union.ImmutableArray = array;
                return union.UnderlyingArray;
            }

            [StructLayout(LayoutKind.Explicit)]
            struct ByteArrayUnion
            {
                [FieldOffset(0)]
                internal byte[]? UnderlyingArray;

                [FieldOffset(0)]
                internal ImmutableArray<byte> ImmutableArray;
            }
        }
    }
}
