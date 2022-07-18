//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class MsBuild
    {
        public interface IProjectElement
        {
            Identifier Name {get;}
        }

        public interface IProjectElement<F> : IProjectElement
            where F : struct, IProjectElement<F>
        {

        }
    }
}