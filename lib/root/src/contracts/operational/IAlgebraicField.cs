//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Operational
    {
        public interface IAlgebraicField<T> : ICommutativeRing<T>, IDivisionRing<T>
            where T : unmanaged
        {

        }
    }
}