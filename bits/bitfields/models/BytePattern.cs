// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0
// {
//     using static core;

//     [StructLayout(LayoutKind.Sequential, Pack=1)]
//     public struct BytePattern
//     {
//         ByteBlock16 Data;

//         public Span<BitPattern> Edit
//         {
//             [MethodImpl(Inline)]
//             get => recover<BitPattern>(Data.Bytes);
//         }

//         public ReadOnlySpan<BitPattern> View
//         {
//             [MethodImpl(Inline)]
//             get => recover<BitPattern>(Data.Bytes);
//         }

//         public ref BitPattern this[byte i]
//         {
//             [MethodImpl(Inline)]
//             get => ref seek(Edit,i);
//         }

//         [MethodImpl(Inline)]
//         public ref BitPattern Cell(N0 n)
//             => ref this[n];

//         [MethodImpl(Inline)]
//         public ref BitPattern Cell(N1 n)
//             => ref this[n];

//         [MethodImpl(Inline)]
//         public ref BitPattern Cell(N2 n)
//             => ref this[n];

//         [MethodImpl(Inline)]
//         public ref BitPattern Cell(N3 n)
//             => ref this[n];

//         [MethodImpl(Inline)]
//         public ref BitPattern Cell(N4 n)
//             => ref this[n];

//         [MethodImpl(Inline)]
//         public ref BitPattern Cell(N5 n)
//             => ref this[n];

//         [MethodImpl(Inline)]
//         public ref BitPattern Cell(N6 n)
//             => ref this[n];

//         [MethodImpl(Inline)]
//         public ref BitPattern Cell(N7 n)
//             => ref this[n];

//         public static BytePattern Empty => default;
//     }
// }