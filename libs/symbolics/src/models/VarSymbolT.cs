// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0
// {
//     public readonly record struct VarSymbol<T> : IDataType<VarSymbol<T>>
//         where T : unmanaged, ICharBlock<T>
//     {
//         public readonly Name<T> Name;

//         [MethodImpl(Inline)]
//         public VarSymbol(Name<T> name)
//         {
//             Name = name;
//         }

//         public Hash32 Hash
//         {
//             [MethodImpl(Inline)]
//             get => Name.Hash;
//         }

//         public bool IsEmpty
//         {
//             [MethodImpl(Inline)]
//             get => Name.IsEmpty;
//         }

//         public override int GetHashCode()
//             => Hash;

//         [MethodImpl(Inline)]
//         public bool Equals(VarSymbol<T> src)
//             => Name.Equals(src.Name);

//         [MethodImpl(Inline)]
//         public int CompareTo(VarSymbol<T> src)
//             => Name.CompareTo(src.Name);

//         public string Format()
//             => Name.Format();

//         public override string ToString()
//             => Format();

//         [MethodImpl(Inline)]
//         public static implicit operator VarSymbol<T>(Name<T> src)
//             => new VarSymbol<T>(src);
//     }
// }