//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public class CheckContext : ICheckContext
    {
        public IJsonSettings Settings {get;}

        public IPolyrand Random {get;}

        public IMessageQueue MessageQueue {get;}

        public IAppPaths Paths {get;}

        public IApiParts ApiParts {get;}

        public event Action<IAppMsg> Next;

        public CheckContext(IAppPaths paths, IPolyrand random, IJsonSettings settings, IMessageQueue queue)
        {
            Paths = paths;
            Next = msg => {};
            Random = random;
            Settings = settings;
            MessageQueue = queue;
            ApiParts = ApiRuntimeLoader.parts();
        }
    }
}