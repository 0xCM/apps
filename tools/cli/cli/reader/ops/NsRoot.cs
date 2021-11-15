//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Reflection.Metadata;

    using static Root;

    partial class CliReader
    {
        [MethodImpl(Inline), Op]
        public NamespaceDefinition NsRoot()
            => MD.GetNamespaceDefinitionRoot();
    }
}
