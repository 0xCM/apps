//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Collections.Generic;

    using static core;

    public sealed class ModelServices : AppService<ModelServices>
    {
        List<NativeBuffer> Allocations;

        public ModelServices()
        {
            Allocations = new();
        }

        protected override void Disposing()
        {
            iter(Allocations, a => a.Dispose());
        }
    }
}