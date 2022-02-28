//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
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