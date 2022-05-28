//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct StringTableSpec
    {
        public readonly Identifier TableNs;

        public readonly Identifier TableName;

        public readonly Identifier IndexName;

        public readonly ClrEnumKind BaseType;

        public readonly Identifier IndexNs;

        public readonly bool Parametric;

        public readonly bool EmitIndex;

        public StringTableSpec(Identifier tableNs, Identifier table, Identifier index, Identifier indexNs, ClrEnumKind @base, bool parametric, bool emitIndex)
        {
            TableNs = tableNs;
            TableName = table;
            IndexName = index;
            BaseType = @base;
            IndexNs = indexNs;
            Parametric = parametric;
            EmitIndex = emitIndex;
        }
    }
}