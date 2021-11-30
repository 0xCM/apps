//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IApiEvalDispatcher
    {
        bit EvalCellOperators(BufferTokens buffers, ApiMemberCode[] api);

        void Dispatch(BufferTokens buffers, in ApiMemberCode api, BinaryOperatorClass k);

        void Dispatch(BufferTokens buffers, in ApiMemberCode api, UnaryOperatorClass k);

        bit EvalCellOperator(BufferTokens buffers, in ApiMemberCode api);
    }
}