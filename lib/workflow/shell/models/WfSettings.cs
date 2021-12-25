//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;

    using static Root;

    public readonly struct WfSettings
    {
        readonly KeyedValues<string,string> Index;

        [MethodImpl(Inline)]
        public WfSettings(KeyedValue<string,string>[] src)
            => Index = new KeyedValues<string,string>(src);

        public WfSettings(IJsonSettings src)
            : this(src.All.Map(s => new KeyedValue<string,string>(s.Name, s.Value)))
        {

        }

        [MethodImpl(Inline)]
        public WfSettings(Dictionary<string,string> src)
            => Index = Lookups.keyed(src);

        public string this[string key]
        {
            [MethodImpl(Inline)]
            get => Index.Search(key, out var value) ? value : EmptyString;
        }
    }
}