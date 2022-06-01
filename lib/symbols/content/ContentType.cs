// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0
// {
//     public readonly struct ContentType
//     {
//         public readonly ContentKind Kind;

//         public readonly Label Name;

//         [MethodImpl(Inline)]
//         internal ContentType(ContentKind kind, string name)
//         {
//             Kind = kind;
//             Name = name;
//         }

//         public bool IsEmpty
//         {
//             [MethodImpl(Inline)]
//             get => Kind == 0;
//         }

//         public bool IsNonEmpty
//         {
//             [MethodImpl(Inline)]
//             get => Kind != 0 && Name.IsNonEmpty;
//         }

//         public string Format()
//             => Name.Format();

//         public override string ToString()
//             => Format();

//         public static ContentType Empty
//         {
//             [MethodImpl(Inline)]
//             get => new ContentType(0, EmptyString);
//         }
//     }
// }