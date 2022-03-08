//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        public readonly struct ChipIsaKinds
        {
            public ChipCode Chip {get;}

            public IsaKinds Kinds {get;}

            public ChipIsaKinds(ChipCode chip, IsaKinds kinds)
            {
                Chip = chip;
                Kinds = kinds;
            }

            public ChipIsaKinds(ChipCode chip)
            {
                Chip = chip;
                Kinds = new();
            }

            public void Add(IsaKind kind)
            {
                Kinds.Add(kind);
            }

            public void Add(IsaKind[] kinds)
            {
                foreach(var k in kinds)
                    Kinds.Add(k);
            }

            public uint Count
            {
                get => (uint)Kinds.Count;
            }
        }
    }
}