//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class MsProjects
    {
        public interface IProjectElement : ITextual
        {
            Identifier Name {get;}
        }

        public interface IProjectElement<F> : IProjectElement
            where F : struct, IProjectElement<F>
        {

        }
    }
}