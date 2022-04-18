//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    public class XedLimits
    {
        public const IClass MaxIClassMember = IClass.XTEST;

        public Hex12 MaxIClass => (ushort)MaxIClassMember;

        public const byte IClassWidth = Hex12.Width;

        public const IFormType MaxIFormMember = IFormType.XTEST;

        public Hex14 MaxIForm => (ushort)MaxIFormMember;

        public const byte IFormWidth = Hex14.Width;
    }
}