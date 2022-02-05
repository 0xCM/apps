// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0.Asm
// {
//     using static core;
//     using static AsciCharSym;
//     using static AsmOcTokens;

//     using SG = AsmPrefixCodes.SegOverrideCode;
//     using C = AsciCharSym;

//     [ApiHost]
//     public readonly struct AsmOcSpecs
//     {
//         const NumericKind Closure = UnsignedInts;

//         [MethodImpl(Inline), Op]
//         public static AsmOpCodeBits bits()
//             => default;

//         [MethodImpl(Inline), Op, Closures(Closure)]
//         public static AsmOcToken<K> token<K>(AsmOcTokenKind kind, K value)
//             where K : unmanaged
//                 => new AsmOcToken<K>(kind,value);

//         [MethodImpl(Inline), Op]
//         public static bit IsCallRel32(ReadOnlySpan<byte> src, uint offset)
//             => (offset + 4) <= src.Length && skip(src, offset) == 0xE8;

//         public static string format(in AsmOpCode src)
//         {
//             var dst = text.buffer();
//             var count = src.TokenCount;
//             for(var i=0; i<count; i++)
//             {
//                 if(i != 0)
//                     dst.Append(Chars.Space);
//                 dst.Append(src[i].Format());
//             }
//             return dst.Emit();
//         }

//         [MethodImpl(Inline), Op]
//         public static bit disp(ReadOnlySpan<char> src)
//             => parse(src, out DispToken _);

//         /// <summary>
//         /// Attempts to match one of ['cb', 'cw', 'cd', 'cp', 'co', 'ct']
//         /// </summary>
//         /// <param name="src"></param>
//         /// <param name="dst"></param>
//         [MethodImpl(Inline), Op]
//         public static bit parse(ReadOnlySpan<char> src, out DispToken dst)
//             => scan(recover<char,C>(src), out dst);

//         [MethodImpl(Inline), Op]
//         static bit scan(ReadOnlySpan<C> src, out DispToken dst)
//         {
//             var count = src.Length;
//             var found = bit.Off;
//             dst = default;
//             for(var i=0; i<count; i++)
//             {
//                 if(parse(src, out dst))
//                 {
//                     found = bit.On;
//                     break;
//                 }
//             }
//             return found;
//         }

//         [Op]
//         static bit parse(ReadOnlySpan<C> src, out DispToken dst)
//         {
//             var token = default(DispToken?);
//             if(src.Length >= 2)
//             {
//                 switch(skip(src,0))
//                 {
//                     case c:
//                     switch(skip(src,1))
//                     {
//                         case b:
//                             token = DispToken.cb;
//                         break;

//                         case w:
//                             token = DispToken.cw;
//                         break;

//                         case d:
//                             token = DispToken.cd;
//                         break;

//                         case p:
//                             token = DispToken.cp;
//                         break;

//                         case o:
//                             token = DispToken.co;
//                         break;

//                         case t:
//                             token = DispToken.cb;
//                         break;
//                     }
//                     break;
//                 }
//             }

//             dst = token ?? 0;
//             return token.HasValue;
//         }

//         [MethodImpl(Inline), Op]
//         public static bool rex(ReadOnlySpan<char> src)
//             => rex(src, out RexToken _);

//         /// <summary>
//         /// Attempts to match one of ['REX', 'REX.W', 'REX.R', 'REX.X', 'REX.B']
//         /// </summary>
//         /// <param name="src"></param>
//         /// <param name="dst"></param>
//         [MethodImpl(Inline), Op]
//         public static bool rex(ReadOnlySpan<char> src, out RexToken dst)
//             => scan(recover<char,C>(src), out dst);

//         [MethodImpl(Inline), Op]
//         static bool scan(ReadOnlySpan<C> src, out RexToken dst)
//         {
//             var count = src.Length;
//             var found = false;
//             dst = default;
//             for(var i=0; i<count; i++)
//             {
//                 if(parse(src, out dst))
//                 {
//                     found = true;
//                     break;
//                 }
//             }
//             return found;
//         }

//         [Op]
//         static bool parse(ReadOnlySpan<C> src, out RexToken dst)
//         {
//             dst = default;
//             var token = default(RexToken?);
//             var length = src.Length;
//             if(length < 3)
//                 return false;

//             var rex = skip(src,0) == R && skip(src,1) == E && skip(src,2) == X;
//             if(!rex)
//                 return false;

//             if(length == 3)
//             {
//                 token = RexToken.Rex;
//             }
//             else
//             {
//                 switch(skip(src,3))
//                 {
//                     case C.Space:
//                         token = RexToken.Rex;
//                     break;

//                     case Dot:
//                         if(length > 4)
//                         {
//                             switch(skip(src,4))
//                             {
//                                 case W:
//                                     token = RexToken.RexW;
//                                 break;
//                             }
//                         }
//                     break;
//                 }
//             }

//             dst = token ?? 0;
//             return token.HasValue;
//         }

//         [MethodImpl(Inline), Op]
//         public static bit rexB(ReadOnlySpan<char> src)
//             => parse(src, out RexBToken _);

//         /// <summary>
//         /// Attempts to match one of ['+rb', '+rw', '+rd', '+ro', 'N.A.', 'N.E.']
//         /// </summary>
//         /// <param name="src"></param>
//         /// <param name="dst"></param>
//         [MethodImpl(Inline), Op]
//         public static bit parse(ReadOnlySpan<char> src, out RexBToken dst)
//             => scan(recover<char,C>(src), out dst);

//         [MethodImpl(Inline), Op]
//         static bit scan(ReadOnlySpan<C> src, out RexBToken dst)
//         {
//             var count = src.Length;
//             var found = bit.Off;
//             dst = default;
//             for(var i=0; i<count; i++)
//             {
//                 if(parse(src, out dst))
//                 {
//                     found = bit.On;
//                     break;
//                 }
//             }
//             return found;
//         }

//         [Op]
//         static bit parse(ReadOnlySpan<C> src, out RexBToken dst)
//         {
//             var token = default(RexBToken?);
//             var length = src.Length;
//             dst = default;
//             if(length < 3)
//                 return false;

//             ref readonly var c0 = ref skip(src,0);
//             ref readonly var c1 = ref skip(src,1);
//             ref readonly var c2 = ref skip(src,2);
//             switch(c0)
//             {
//                 case Plus:
//                     switch(c1)
//                     {
//                         case r:
//                             switch(c2)
//                             {
//                                 case b:
//                                     token = RexBToken.rb;
//                                 break;
//                                 case w:
//                                     token = RexBToken.rw;
//                                 break;
//                                 case d:
//                                     token = RexBToken.rd;
//                                 break;
//                                 case o:
//                                     token = RexBToken.ro;
//                                 break;
//                             }
//                         break;
//                     }
//                 break;
//             }

//             dst = token ?? 0;
//             return token.HasValue;
//         }

//         [MethodImpl(Inline), Op]
//         public static bit parse(ReadOnlySpan<char> src, out OpCodeExtension dst)
//             => scan(recover<char,C>(src), out dst);

//         [MethodImpl(Inline), Op]
//         static bit scan(ReadOnlySpan<C> src, out OpCodeExtension dst)
//         {
//             var count = src.Length;
//             var found = bit.Off;
//             dst = default;
//             for(var i=0; i<count; i++)
//             {
//                 if(parse(src, out dst))
//                 {
//                     found = bit.On;
//                     break;
//                 }
//             }
//             return found;
//         }

//         static bit parse(ReadOnlySpan<C> src, out OpCodeExtension dst)
//         {
//             var count = src.Length;
//             var token = default(OpCodeExtension?);
//             if(count >= 2)
//             {
//                 if(skip(src,0) == C.FS)
//                 {
//                     switch(skip(src,1))
//                     {
//                         case d0:
//                             token = OpCodeExtension.r0;
//                             break;
//                         case d1:
//                             token = OpCodeExtension.r1;
//                             break;
//                         case d2:
//                             token = OpCodeExtension.r2;
//                             break;
//                         case d3:
//                             token = OpCodeExtension.r3;
//                             break;
//                         case d4:
//                             token = OpCodeExtension.r4;
//                             break;
//                         case d5:
//                             token = OpCodeExtension.r5;
//                             break;
//                         case d6:
//                             token = OpCodeExtension.r6;
//                             break;
//                         case d7:
//                             token = OpCodeExtension.r7;
//                             break;
//                     }
//                 }
//             }
//             dst = token ?? 0;
//             return token.HasValue;
//         }

//         static ReadOnlySpan<SG> SegOverrideCodes
//             => new SG[]{SG.CS, SG.DS, SG.ES, SG.FS, SG.GS, SG.SS};
//     }
// }