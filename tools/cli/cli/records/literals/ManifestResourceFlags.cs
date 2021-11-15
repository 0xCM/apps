// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
namespace Z0
{
    public enum ManifestResourceFlags : uint
    {
        PublicVisibility = 0x00000001,

        PrivateVisibility = 0x00000002,

        VisibilityMask = 0x00000007,

        InExternalFile = 0x00000010,
    }
}