//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential,Pack =1)]
        public record struct InstGroupKey
        {
            public readonly ushort PatternId;

            public readonly ushort Index;

            public InstGroupKey(ushort pid, byte index)
            {
                Index = index;
                PatternId = pid;
            }

            public Hash32 Hash
            {
                [MethodImpl(Inline)]
                get => (int)PatternId | (int)Index << 16;
            }

            public override int GetHashCode()
                => Hash;
        }
    }
}