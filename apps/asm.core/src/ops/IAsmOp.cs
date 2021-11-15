//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    public partial class AsmOps
    {
        [Free]
        public interface IAsmOp
        {

        }

        [Free]
        public interface IAsmOp<T> : IAsmOp
            where T : unmanaged, IAsmOp<T>
        {

        }
    }
}