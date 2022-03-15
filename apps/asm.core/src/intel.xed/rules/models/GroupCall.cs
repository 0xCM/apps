// //-----------------------------------------------------------------------------
// // Derivative Work based on https://github.com/intelxed/xed
// // Author : Chris Moore
// // License: https://github.com/intelxed/xed/blob/main/LICENSE
// //-----------------------------------------------------------------------------
// namespace Z0
// {
//     using static XedModels;

//     partial class XedRules
//     {
//         [DataWidth(8)]
//         public readonly struct GroupCall
//         {
//             public readonly GroupName Target;

//             [MethodImpl(Inline)]
//             public GroupCall(GroupName kind)
//             {
//                 Target = kind;
//             }

//             public bool IsEmpty
//             {
//                 [MethodImpl(Inline)]
//                 get => Target == 0;
//             }

//             public bool IsNonEmpty
//             {
//                 [MethodImpl(Inline)]
//                 get => Target != 0;
//             }

//             public string Format()
//                 => XedRender.format(this);

//             public override string ToString()
//                 => Format();

//             [MethodImpl(Inline)]
//             public static implicit operator GroupCall(GroupName kind)
//                 => new GroupCall(kind);

//             public static GroupCall Empty => default;
//         }
//     }
// }