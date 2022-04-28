//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;
    using static core;

    using M = XedModels;
    using R = XedRules;

    partial class XedFields
    {
        public readonly struct FieldChoices
        {
            public static ReadOnlySpan<M.EASZ> EASZ
            {
                [MethodImpl(Inline), Op]
                get => Bytes.sequential<M.EASZ>(0, (byte)M.EASZ.EASZNot16);
            }

            public static ReadOnlySpan<M.ASZ> ASZ
            {
                [MethodImpl(Inline), Op]
                get => Bytes.sequential<M.ASZ>(0, (byte)M.ASZ.a64);
            }

            public static ReadOnlySpan<M.BaseMapKind> BaseMapKind
            {
                [MethodImpl(Inline), Op]
                get => Bytes.sequential<M.BaseMapKind>(0, (byte)M.BaseMapKind.Amd3dNow);
            }

            public static ReadOnlySpan<M.InstCategory> InstCategory
            {
                [MethodImpl(Inline), Op]
                get => Bytes.sequential<M.InstCategory>(0, (byte)M.CategoryKind.XSAVEOPT);
            }

            public static ReadOnlySpan<InstAttrib> InstAttrib
            {
                [MethodImpl(Inline), Op]
                get => Bytes.sequential<InstAttrib>(0, (byte)InstAttribKind.XMM_STATE_W);
            }

            public static ReadOnlySpan<M.InstIsa> InstIsa
            {
                [MethodImpl(Inline), Op]
                get => Bytes.sequential<M.InstIsa>(0, (byte)M.IsaKind.XSAVES);
            }

            public static ReadOnlySpan<M.LLRC> LLRC
            {
                [MethodImpl(Inline), Op]
                get => Bytes.sequential<M.LLRC>(0, (byte)M.LLRC.LLRC3);
            }

            public static ReadOnlySpan<M.MaskReg> MaskReg
            {
                [MethodImpl(Inline), Op]
                get => Bytes.sequential<M.MaskReg>(0, (byte)M.MaskReg.K7);
            }

            public static ReadOnlySpan<M.ElementType> ElementType
            {
                [MethodImpl(Inline), Op]
                get => Bytes.sequential<M.ElementType>(0, (byte)M.ElementKind.VAR);
            }
        }
    }
}