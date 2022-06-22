// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0
// {
//     public abstract class TextDoc<D,C> : Document<D,C,FS.FilePath>
//         where D : TextDoc<D,C>, new()
//         where C : struct, ITextual
//     {
//         public TextDoc()
//             : base(FS.FilePath.Empty, default(C))
//         {

//         }

//         public TextDoc(C content)
//             : base(FS.FilePath.Empty, content)
//         {

//         }

//         public TextDoc(FS.FilePath src, C content)
//             : base(src, content)
//         {

//         }
//     }
// }