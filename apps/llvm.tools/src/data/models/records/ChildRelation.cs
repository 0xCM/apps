//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using System.Runtime.InteropServices;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct ChildRelation
    {
        public const string TableId = "llvm.entities.relations.child";

        public uint Key;

        public uint ParentKey;

        public string ParentName;

        public uint ChildSeq;

        public string ChildName;
    }
}