// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0
// {
//     public class ApiCaptureSet
//     {
//         public readonly OpUri Id;

//         public readonly MsilCode Msil;

//         public readonly CodeBlock Hex;

//         public readonly AsmSourceBlock Asm;

//         public readonly MethodDisplaySig DisplaySig;

//         [MethodImpl(Inline)]
//         public ApiCaptureSet(OpUri uri, ApiMsil msil, in CodeBlock hex, in AsmSourceBlock asm)
//         {
//             Id = uri;
//             Msil = msil.Source;
//             Hex = hex;
//             Asm = asm;
//             DisplaySig = msil.DisplaySig;
//         }

//         [MethodImpl(Inline)]
//         public ApiCaptureSet(OpUri id, MsilCode msil, in CodeBlock hex, in AsmSourceBlock asm, in MethodDisplaySig sig)
//         {
//             Id = id;
//             Msil = msil;
//             Hex = hex;
//             Asm = asm;
//             DisplaySig = sig;
//         }

//         public bool Complete
//         {
//             [MethodImpl(Inline)]
//             get => Msil.Complete && Id.IsNonEmpty && Hex.IsNonEmpty && Asm.IsNonEmpty;
//         }

//         public PartId Part
//         {
//             [MethodImpl(Inline)]
//             get => Id.Part;
//         }

//         public ApiHostUri Host
//         {
//             [MethodImpl(Inline)]
//             get => Id.Host;
//         }

//         public ByteSize HexSize
//         {
//             [MethodImpl(Inline)]
//             get => Hex.ByteCount;
//         }

//         public ByteSize MsilSize
//         {
//             [MethodImpl(Inline)]
//             get => Msil.Size;
//         }

//         public CliSig CliSig
//         {
//             [MethodImpl(Inline)]
//             get => Msil.Sig;
//         }
//     }
// }