//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class MsBuild
    {
        public interface IProjectItem : IProjectElement
        {

        }

        public interface IProjectItem<F> : IProjectItem, IProjectElement<F>
            where F : struct, IProjectItem<F>
        {

        }
    }
}