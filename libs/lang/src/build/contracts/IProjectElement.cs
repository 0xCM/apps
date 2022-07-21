//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BuildSvc
    {
        public interface IProjectElement
        {

        }

        public interface IProjectElement<F> : IProjectElement
            where F : struct, IProjectElement<F>
        {

        }
    }
}