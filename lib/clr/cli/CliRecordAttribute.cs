//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    [AttributeUsage(AttributeTargets.Struct)]
    public class CliRecordAttribute : RecordAttribute
    {
        public CliRecordAttribute(CliTableKind kind)
            : base(kind)
        {

        }

        public new CliTableKind TableKind
            => (CliTableKind)base.TableKind;
    }
}