//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public struct CellMetrics
        {
            public readonly CellKey Key;

            public readonly DataSize Size;

            [MethodImpl(Inline)]
            public CellMetrics(CellKey key, DataSize size)
            {
                Key = key;
                Size = size;
            }

            public LogicClass Logic
            {
                [MethodImpl(Inline)]
                get => Key.Logic;
            }

            public Coordinate Location
            {
                [MethodImpl(Inline)]
                get => new Coordinate(Key.Rule.TableKind, Key.Table, Key.Row, Key.Col);
            }

            public FieldKind Field
            {
                [MethodImpl(Inline)]
                get => Key.Field;
            }

            public RuleCellType CellType
            {
                [MethodImpl(Inline)]
                get => Key.CellType;
            }

            public RuleCellKind CellKind
            {
                [MethodImpl(Inline)]
                get => CellType.Kind;
            }

            public KeywordKind Keyword
            {
                [MethodImpl(Inline)]
                get => Key.Keyword;
            }

        }
    }
}