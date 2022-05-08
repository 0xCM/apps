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
    using Asm;
    using M = XedModels;
    using R = XedRules;

    using B = System.ReadOnlySpan<bit>;
    using U2 = System.ReadOnlySpan<uint2>;
    using U3 = System.ReadOnlySpan<uint3>;

    partial class XedOperands
    {
        public readonly partial struct Views
        {
            public const M.ASZ MaxASZ = M.ASZ.a64;

            public const M.SegPrefixKind MaxSegPrefixKind = M.SegPrefixKind.SS;

            public const M.InstAttribKind MaxInstAttribKind = M.InstAttribKind.XMM_STATE_W;

            public static ReadOnlySpan<BroadcastDef> BroadcastDefs
            {
                [MethodImpl(Inline), Op]
                get => Broadcasts;
            }

            public static ReadOnlySpan<OpWidthRecord> OpWidths
            {
                [MethodImpl(Inline), Op]
                get => _Widths;
            }

            public static ReadOnlySpan<M.ASZ> ASZ
            {
                [MethodImpl(Inline), Op]
                get => Bytes.sequential<M.ASZ>(0, (byte)MaxASZ);
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
                get => Bytes.sequential<InstAttrib>(0, (byte)MaxInstAttribKind);
            }

            public static ReadOnlySpan<M.InstIsa> InstIsa
            {
                [MethodImpl(Inline), Op]
                get => Bytes.sequential<M.InstIsa>(0, (byte)M.IsaKind.XSAVES);
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

            public static ReadOnlySpan<M.SegPrefixKind> SegPrefixKind
            {
                [MethodImpl(Inline), Op]
                get => Bytes.sequential<M.SegPrefixKind>(0, (byte)MaxSegPrefixKind);
            }

            public static ReadOnlySpan<R.RuleName> RuleNames
            {
                [MethodImpl(Inline), Op]
                get => R.RuleNames.View;
            }
        }
    }
}