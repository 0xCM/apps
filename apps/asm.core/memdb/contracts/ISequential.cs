//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class MemDb
    {
        public interface ISequential : IElement
        {
            uint Seq {get;}
        }

        public interface ISequential<T> : ISequential, IElement<T>
            where T : ISequential<T>
        {

        }
    }
}