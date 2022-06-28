//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ExecutingPart
    {
        public static ref readonly Assembly Component => ref _Component;

        public static ref readonly PartId Id => ref _Id;

        static PartId _Id;

        static Assembly _Component;

        static ExecutingPart()
        {
            _Component = Assembly.GetEntryAssembly();
            _Id = PartIdAttribute.id(_Component);
        }
    }
}