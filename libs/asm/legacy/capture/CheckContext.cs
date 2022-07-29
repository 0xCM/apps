//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public class CheckContext : ICheckContext
    {
        public IPolyrand Random {get;}

        public IMessageQueue MessageQueue {get;}

        public IApiParts ApiParts {get;}

        public event Action<IAppMsg> Next;

        public CheckContext(IPolyrand random, IMessageQueue queue)
        {
            Next = msg => {};
            Random = random;
            MessageQueue = queue;
            ApiParts = ApiRuntime.parts();
        }
    }
}