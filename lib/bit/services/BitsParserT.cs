// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0
// {
//     public readonly struct BitsParser<T> : IParser<bits<T>>
//         where T : unmanaged
//     {
//         public static BitsParser<T> Service => default;

//         public Outcome Parse(string src, out bits<T> dst)
//             => BitParser.parse(src, out dst);
//     }
// }