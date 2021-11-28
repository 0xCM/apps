//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct CheckHiMaskResult<T>
    {
        public byte Count;

        public byte PopCount;

        public T Mask;

        public bit Check1;

        public bit Check2;

        public T Lowered;

        public bit Check3;

        public byte EffectiveWidth;
    }
}