// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0.Asm
// {
//     public readonly struct AsmCells : IIndex<AsmCell>
//     {
//         readonly Index<AsmCell> Data;

//         [MethodImpl(Inline), Op]
//         public AsmCells(Index<AsmCell> src)
//         {
//             Data = src;
//         }

//         public ReadOnlySpan<AsmCell> View
//         {
//             [MethodImpl(Inline), Op]
//             get => Data;
//         }

//         public uint Count
//         {
//             [MethodImpl(Inline), Op]
//             get => Data.Count;
//         }

//         AsmCell[] IIndex<AsmCell>.Storage
//             => Data.Storage;

//         public ref readonly AsmCell this[uint i]
//         {
//             [MethodImpl(Inline), Op]
//             get => ref Data[i];
//         }

//         public ref readonly AsmCell this[int i]
//         {
//             [MethodImpl(Inline), Op]
//             get => ref Data[i];
//         }

//         public string Format()
//         {
//             var dst = text.buffer();
//             var count = Data.Count;
//             for(var i=0; i<count; i++)
//             {
//                 if(i!= 0)
//                     dst.Append(Chars.Space);
//                 dst.Append(Data[i].Format());
//             }
//             return dst.Emit();
//         }

//         public override string ToString()
//             => Format();

//         [MethodImpl(Inline), Op]
//         public static implicit operator AsmCells(AsmCell[] src)
//             => new AsmCells(src);
//     }
// }