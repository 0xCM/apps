//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    using static Root;

    public class ToolConfigs
    {
        public static ToolConfigs create(ToolConfig[] src)
            => new ToolConfigs(src);

        readonly Index<ToolConfig> _Tools;

        readonly Dictionary<ToolId,ToolConfig> Lookup;

        internal ToolConfigs(ToolConfig[] tools)
        {
            _Tools = tools;
            Lookup = tools.Select(t => (t.ToolId, t)).ToDictionary();
        }

        public bool Config(ToolId id, out ToolConfig config)
            => Lookup.TryGetValue(id,out config);

        public ReadOnlySpan<ToolConfig> Configured
        {
            [MethodImpl(Inline)]
            get => _Tools.View;
        }

        public uint ToolCount
        {
            [MethodImpl(Inline)]
            get => _Tools.Count;
        }
    }
}