//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public class InstGroup
        {
            public readonly InstClass Class;

            public readonly Index<InstGroupMember> Members;

            public InstGroup(InstClass @class, Index<InstGroupMember> src)
            {
                Class = @class;
                Members = src;
            }

            public override int GetHashCode()
                => Class.Hash;
        }
    }
}