// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0
// {
//     using static core;

//     partial class ApiCode
//     {
//         public static MemoryBlocks memory(ReadOnlySpan<ApiMemberExtract> src)
//         {
//             var count = src.Length;
//             if(count == 0)
//                 return MemoryBlocks.Empty;
//             var dst = alloc<MemoryBlock>(count);
//             for(var i=0; i<count; i++)
//             {
//                 ref readonly var code = ref skip(src,i);
//                 var encoded = code.Block.Encoded;
//                 seek(dst,i) = new MemoryBlock(code.Origin, encoded);
//             }

//             dst.Sort();
//             return new MemoryBlocks(dst);
//         }

//     }
// }