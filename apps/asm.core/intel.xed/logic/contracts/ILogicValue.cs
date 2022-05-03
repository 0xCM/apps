//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public interface ILogicValue
        {
            LogicDataKind DataKind {get;}

            DataSize Size {get;}
        }

        public interface ILogicValue<T> : ILogicValue
            where T : unmanaged
        {
            T Storage {get;}
        }
    }
}