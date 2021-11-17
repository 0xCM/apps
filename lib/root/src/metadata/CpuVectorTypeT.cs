//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class CpuVectorType<T> : VectorType<T>
        where T : CpuVectorType<T>, new()
    {
        protected CpuVectorType(BitWidth storage, BitWidth content, BitWidth cellwidth, uint cellcount)
            : base(storage, content,cellwidth,cellcount)
        {

        }
    }
}