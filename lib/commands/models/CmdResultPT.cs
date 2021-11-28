//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Capures a command along with the outcome and payload
    /// </summary>
    public struct CmdResult<C,P> : ICmdResult<C,P>
        where C : struct, ICmd
    {
        public C Cmd {get;}

        public bool Succeeded {get;}

        public P Payload {get;}

        public string Message {get;}

        public CmdId Id => Cmd.CmdId;

        [MethodImpl(Inline)]
        public CmdResult(C cmd, bool success, P payload, string msg = EmptyString)
        {
            Cmd = cmd;
            Payload = payload;
            Succeeded = success;
            Message = minicore.ifempty(msg, CmdResult.DefaultMsg(cmd.CmdId, success));
        }

        [MethodImpl(Inline)]
        public CmdResult(C cmd, Exception e)
        {
            Cmd = cmd;
            Payload = default;
            Succeeded = false;
            Message = e.ToString();
        }


        [MethodImpl(Inline)]
        public string Format()
            => Message;


        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator CmdResult(CmdResult<C,P> src)
            => new CmdResult(src.Id, src.Succeeded, src.Message);

        [MethodImpl(Inline)]
        public static implicit operator CmdResult<C>(CmdResult<C,P> src)
            => new CmdResult<C>(src.Cmd, src.Succeeded, src.Message);

        public static CmdResult<C,P> Empty
            => default;
    }
}