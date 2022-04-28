//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedDb
    {
        [Free]
        public interface IType : ISequential
        {
            asci32 Name {get;}

            DataSize Size {get;}
        }

        [Free]
        public interface IType<T> : IType, IElement<T>
            where T : IType<T>
        {

        }
    }
}