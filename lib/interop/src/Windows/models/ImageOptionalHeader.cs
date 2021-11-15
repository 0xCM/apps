// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Windows
{
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Explicit)]
    public struct ImageOptionalHeader
    {
        [FieldOffset(0)]
        public ushort Magic;

        [FieldOffset(56)]
        public int SizeOfImage;
    }
}
