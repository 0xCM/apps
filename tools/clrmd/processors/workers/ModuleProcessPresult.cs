//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static DiagnosticRecords;

    partial struct DiagnosticProcessors
    {
        public class ModuleProcessPresult
        {
            internal Index<ModuleInfo> _Modules;

            internal Index<MethodTableToken> _MethodTables;

            public ModuleProcessPresult()
            {
                _Modules = sys.empty<ModuleInfo>();
                _MethodTables = sys.empty<MethodTableToken>();
            }

            public ReadOnlySpan<ModuleInfo> Modules
            {
                [MethodImpl(Inline)]
                get => _Modules.View;
            }

            public ReadOnlySpan<MethodTableToken> MethodTables
            {
                [MethodImpl(Inline)]
                get => _MethodTables.View;
            }
        }
    }
}