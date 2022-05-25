//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    public struct SymTableSpec
    {
        public string IndexName;

        public string TableName;

        public string IndexNs;

        public string TableNs;

        public ClrEnumKind IndexKind;

        public bool Parametric;

        public bool EmitIndex;
    }
}