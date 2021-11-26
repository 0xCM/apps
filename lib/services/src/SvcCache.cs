//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    static class SvcCache
    {
        static object locker = new object();

        static ModelServices _ModelServices;

        public static ModelServices Models(IWfRuntime wf)
        {
            lock(locker)
            {
                if(_ModelServices == null)
                    _ModelServices = ModelServices.create(wf);
            }
            return _ModelServices;
        }
    }
}