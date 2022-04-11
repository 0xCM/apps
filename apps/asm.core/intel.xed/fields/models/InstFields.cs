//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct InstFields : IIndex<InstField>
        {
            public readonly Index<InstField> Data;

            public readonly byte LayoutCount;

            [MethodImpl(Inline)]
            public InstFields(InstField[] src, byte lCount)
            {
                Data = src;
                LayoutCount = lCount;
            }

            public ReadOnlySpan<InstField> Layout
            {
                [MethodImpl(Inline)]
                get => IsEmpty ? default : core.slice(Data.View, 0, LayoutCount);
            }

            public ReadOnlySpan<InstField> Expr
            {
                [MethodImpl(Inline)]
                get => IsEmpty ?  default :core.slice(Data.View, LayoutCount);
            }

            public InstField[] Storage
            {
                [MethodImpl(Inline)]
                get => Data;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Data.IsEmpty;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get =>  Data.IsNonEmpty;
            }

            public ref InstField First
            {
                [MethodImpl(Inline)]
                get => ref Data.First;
            }

            public ref InstField this[int i]
            {
                [MethodImpl(Inline)]
                get => ref Data[i];
            }

            public ref InstField this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref Data[i];
            }

            public byte Count
            {
                [MethodImpl(Inline)]
                get => (byte)Data.Count;
            }

            public byte ExprCount
            {
                [MethodImpl(Inline)]
                get => (byte)(Count - LayoutCount);
            }
        }
    }
}