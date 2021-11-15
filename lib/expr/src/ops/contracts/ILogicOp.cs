//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ops.Logic
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface ILogicOp : IOpExpr<LogicExprKind>
    {

    }

    public enum LogicExprKind : byte
    {
        None = 0,

        And = (byte)BinaryBitLogicKind.And,

        Or = (byte)BinaryBitLogicKind.Or,

        XOr = (byte)BinaryBitLogicKind.Xor,

        Impl = (byte)BinaryBitLogicKind.Impl,

        Not = (byte)BinaryBitLogicKind.LNot,
    }
}