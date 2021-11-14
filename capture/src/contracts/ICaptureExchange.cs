//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public interface ICaptureExchange
    {
        /// <summary>
        /// The buffer that receives the captured data
        /// </summary>
        BufferToken TargetBuffer {get;}

        CaptureExchange Context {get;}
    }
}