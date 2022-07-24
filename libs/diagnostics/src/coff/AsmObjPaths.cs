//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using G = ApiGranules;

    public readonly struct AsmObjPaths
    {
        readonly IAppDb AppDb;

        [MethodImpl(Inline)]
        public AsmObjPaths(IAppDb db)
        {
            AppDb = db;
        }
    }
}