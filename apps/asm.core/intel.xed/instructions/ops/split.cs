//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;

    partial class XedFields
    {
        [MethodImpl(Inline), Op]
        public static InstFields sort(InstFields src)
        {
            var data = src.Data;
            var count = (byte)data.Count;
            var eCount = z8;
            var lCount = z8;
            for(var i=z8; i<count; i++)
            {
                ref var field = ref data[i];
                if(field.IsFieldExpr)
                    eCount++;
                else
                    lCount++;
            }

            var eIx = (byte)(lCount-1);
            var lIx = z8;
            for(var i=z8; i<count; i++)
            {
                ref var field = ref data[i];
                if(field.IsFieldExpr)
                    field = field.WithIndex(eIx++);
                else
                    field = field.WithIndex(lIx++);
            }

            return new InstFields(data.Sort(), count);
        }

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
                get => Data.IsNonEmpty;
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

            public InstFields Sort()
                => XedFields.sort(this);
        }
    }

    partial class XedPatterns
    {
        public static Pair<InstPatternBody> split(in InstPatternBody src)
        {
            var left = list<InstField>();
            var right = list<InstField>();
            var count = src.FieldCount;
            for(var i=0; i<count; i++)
            {
                ref readonly var part = ref src[i];
                if(part.IsFieldExpr)
                    right.Add(part);
                else
                    left.Add(part);
            }
            return (left.ToArray(),right.ToArray());
        }
    }
}