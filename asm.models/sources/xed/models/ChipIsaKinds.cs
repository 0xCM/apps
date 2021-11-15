//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
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