//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Resources
    {
        [Op]
        public static MemoryAddress jit(MethodInfo src)
        {
            sys.prepare(src.MethodHandle);
            return src.MethodHandle.GetFunctionPointer();
        }
    }
}