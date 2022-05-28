//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class IntelIntrinsics
    {
        public interface IIntrinsicInput
        {
            IntrinsicKind Kind {get;}
        }

        public interface IIntrinsicInput<T> : IIntrinsicInput
            where T : unmanaged, IIntrinsicInput<T>
        {

        }
    }
}