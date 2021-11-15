//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public struct CmdResult<C> : ICmdResult<C>
        where C : struct, ICmd
    {
        public C Cmd {get;}

        public bool Succeeded {get;}

        public dynamic Payload {get;}

        public string Message {get;}

        [MethodImpl(Inline)]
        public CmdResult(C cmd, bool success, string msg)
        {
            Cmd = cmd;
            Succeeded = success;
            Message = minicore.ifempty(msg, CmdResult.DefaultMsg(Cmd.CmdId, success));
            Payload = Succeeded;
        }

        [MethodImpl(Inline)]
        public CmdResult(C cmd, bool success)
        {
            Cmd = cmd;
            Succeeded = success;
            Message = CmdResult.DefaultMsg(Cmd.CmdId, success);
            Payload = Succeeded;
        }

        [MethodImpl(Inline)]
        public CmdResult(C cmd, bool success, dynamic payload)
        {
            Cmd = cmd;
            Succeeded = success;
            Message = CmdResult.DefaultMsg(Cmd.CmdId, success);
            Payload = payload;
        }

        [MethodImpl(Inline)]
        public CmdResult(C cmd, Exception e)
        {
            Cmd = cmd;
            Succeeded = false;
            Message = e.ToString();
            Payload = Succeeded;
        }

        public CmdId Id  => Cmd.CmdId;

        [MethodImpl(Inline)]
        public string Format()
            => Message;


        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator CmdResult(CmdResult<C> src)
            => new CmdResult(src.Id, src.Succeeded, src.Message);

        public static CmdResult<C> Empty
            => default;
    }
}