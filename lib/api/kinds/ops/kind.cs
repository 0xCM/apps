//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using SK = NativeSegKind;
    using TW = NativeTypeWidth;
    using ID = ScalarKind;

    partial class NativeSegKinds
    {
        /// <summary>
        /// Determines the block classifier for a blocked type
        /// </summary>
        /// <param name="t">The type to examine</param>
        [Op]
        public static SK kind(Type t)
            => kind(NativeSegKinds.width(t), NativeSegKinds.segment(t).ApiKind());

        [Op]
        public static SK kind(TW width, ID id)
        {
            var k = width switch
                    { TW.W16 =>
                        id switch {
                            ID.U8 => SK.Seg16x8u,
                            ID.I8 => SK.Seg16x8i,
                            ID.I16 => SK.Seg16x16i,
                            ID.U16 => SK.Seg16x16u,
                            _ => SK.None
                            },

                        TW.W32 =>
                        id switch {
                            ID.U8 => SK.Seg32x8u,
                            ID.I8 => SK.Seg32x8i,
                            ID.I16 => SK.Seg32x16i,
                            ID.U16 => SK.Seg32x16u,
                            ID.I32 => SK.Seg32x32i,
                            ID.U32 => SK.Seg32x32u,
                            ID.F32 => SK.Seg32x32f,
                            _ => SK.None
                            },

                        TW.W64 =>
                        id switch {
                            ID.U8 => SK.Seg64x8u,
                            ID.I8 => SK.Seg64x8i,
                            ID.U16 => SK.Seg64x16u,
                            ID.I16 => SK.Seg64x16i,
                            ID.U32 => SK.Seg64x32i,
                            ID.I32 => SK.Seg64x32i,
                            ID.U64 => SK.Seg64x64u,
                            ID.I64 => SK.Seg64x64i,
                            ID.F32 => SK.Seg64x32f,
                            ID.F64 => SK.Seg64x64f,
                            _ => SK.None
                            },

                        TW.W128 =>
                        id switch {
                            ID.U8 => SK.Seg128x8u,
                            ID.I8 => SK.Seg128x8i,
                            ID.U16 => SK.Seg128x16u,
                            ID.I16 => SK.Seg128x16i,
                            ID.U32 => SK.Seg128x32i,
                            ID.I32 => SK.Seg128x32i,
                            ID.U64 => SK.Seg128x64u,
                            ID.I64 => SK.Seg128x64i,
                            ID.F32 => SK.Seg128x32f,
                            ID.F64 => SK.Seg128x64f,
                            _ => SK.None
                            },

                        TW.W256 =>
                        id switch {
                            ID.U8 => SK.Seg256x8u,
                            ID.I8 => SK.Seg256x8i,
                            ID.U16 => SK.Seg256x16u,
                            ID.I16 => SK.Seg256x16i,
                            ID.U32 => SK.Seg256x32i,
                            ID.I32 => SK.Seg256x32i,
                            ID.U64 => SK.Seg256x64u,
                            ID.I64 => SK.Seg256x64i,
                            ID.F32 => SK.Seg256x32f,
                            ID.F64 => SK.Seg256x64f,
                            _ => SK.None
                            },

                        TW.W512 =>
                        id switch {
                            ID.U8 => SK.Seg512x8u,
                            ID.I8 => SK.Seg512x8i,
                            ID.U16 => SK.Seg512x16u,
                            ID.I16 => SK.Seg512x16i,
                            ID.U32 => SK.Seg512x32i,
                            ID.I32 => SK.Seg512x32i,
                            ID.U64 => SK.Seg512x64u,
                            ID.I64 => SK.Seg512x64i,
                            ID.F32 => SK.Seg512x32f,
                            ID.F64 => SK.Seg512x64f,
                            _ => SK.None
                            },

                        _ => SK.None
                    };

            return k;
        }
    }
}