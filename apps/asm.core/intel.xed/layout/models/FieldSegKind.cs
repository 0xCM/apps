//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public enum FieldSegKind : byte
        {
            None,

            [Symbol("0b")]
            ModLit,

            [Symbol("mm")]
            ModVar,

            [Symbol("0b")]
            RegLit,

            [Symbol("rrr")]
            RegVar,

            [Symbol("0b")]
            RmLit,

            [Symbol("nnn")]
            RmVar,

            [Symbol("0b")]
            SrmLit,

            [Symbol("rrr")]
            SrmVar
        }
    }
}