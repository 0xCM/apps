//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : all-state.txt
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        public unsafe struct AssignmentRule
        {
            public readonly text31 Name;

            public readonly Index<FieldAssignment> Fields;

            [MethodImpl(Inline)]
            public AssignmentRule(text31 name, FieldAssignment[] fields)
            {
                Name = name;
                Fields = fields;
            }
        }
    }
}