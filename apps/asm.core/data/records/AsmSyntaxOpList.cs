//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct AsmSyntaxOpList
    {
        public readonly AsmSyntaxRow Row;

        public readonly Index<string> OpClasses;

        public readonly Index<int> Indices;

        public AsmSyntaxOpList(in AsmSyntaxRow row, Index<string> classes, Index<int> indices)
        {
            Row = row;
            OpClasses = classes;
            Indices = indices;
        }
    }
}