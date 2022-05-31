//-----------------------------------------------------------------------------
// Copyright   :  (c) Microsoft
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class CoffRecords
    {
        public enum IMAGE_DIRECTORY_ENTRY : uint
        {
            IMAGE_DIRECTORY_ENTRY_ARCHITECTURE = 7u,

            IMAGE_DIRECTORY_ENTRY_BASERELOC = 5u,

            IMAGE_DIRECTORY_ENTRY_BOUND_IMPORT = 11u,

            IMAGE_DIRECTORY_ENTRY_COM_DESCRIPTOR = 14u,

            IMAGE_DIRECTORY_ENTRY_DEBUG = 6u,

            IMAGE_DIRECTORY_ENTRY_DELAY_IMPORT = 13u,

            IMAGE_DIRECTORY_ENTRY_EXCEPTION = 3u,

            IMAGE_DIRECTORY_ENTRY_EXPORT = 0u,

            IMAGE_DIRECTORY_ENTRY_GLOBALPTR = 8u,

            IMAGE_DIRECTORY_ENTRY_IAT = 12u,

            IMAGE_DIRECTORY_ENTRY_IMPORT = 1u,

            IMAGE_DIRECTORY_ENTRY_LOAD_CONFIG = 10u,

            IMAGE_DIRECTORY_ENTRY_RESOURCE = 2u,

            IMAGE_DIRECTORY_ENTRY_SECURITY = 4u,

            IMAGE_DIRECTORY_ENTRY_TLS = 9u
        }

        public enum IMAGE_DEBUG_TYPE : uint
        {
            IMAGE_DEBUG_TYPE_UNKNOWN = 0u,

            IMAGE_DEBUG_TYPE_COFF = 1u,

            IMAGE_DEBUG_TYPE_CODEVIEW = 2u,

            IMAGE_DEBUG_TYPE_FPO = 3u,

            IMAGE_DEBUG_TYPE_MISC = 4u,

            IMAGE_DEBUG_TYPE_EXCEPTION = 5u,

            IMAGE_DEBUG_TYPE_FIXUP = 6u,

            IMAGE_DEBUG_TYPE_BORLAND = 9u
        }

        public enum IMAGE_FILE_MACHINE : ushort
        {
            IMAGE_FILE_MACHINE_AXP64 = 644,

            IMAGE_FILE_MACHINE_I386 = 332,

            IMAGE_FILE_MACHINE_IA64 = 0x200,

            IMAGE_FILE_MACHINE_AMD64 = 34404,

            IMAGE_FILE_MACHINE_UNKNOWN = 0,

            IMAGE_FILE_MACHINE_TARGET_HOST = 1,

            IMAGE_FILE_MACHINE_R3000 = 354,

            IMAGE_FILE_MACHINE_R4000 = 358,

            IMAGE_FILE_MACHINE_R10000 = 360,

            IMAGE_FILE_MACHINE_WCEMIPSV2 = 361,

            IMAGE_FILE_MACHINE_ALPHA = 388,

            IMAGE_FILE_MACHINE_SH3 = 418,

            IMAGE_FILE_MACHINE_SH3DSP = 419,

            IMAGE_FILE_MACHINE_SH3E = 420,

            IMAGE_FILE_MACHINE_SH4 = 422,

            IMAGE_FILE_MACHINE_SH5 = 424,

            IMAGE_FILE_MACHINE_ARM = 448,

            IMAGE_FILE_MACHINE_THUMB = 450,

            IMAGE_FILE_MACHINE_ARMNT = 452,

            IMAGE_FILE_MACHINE_AM33 = 467,

            IMAGE_FILE_MACHINE_POWERPC = 496,

            IMAGE_FILE_MACHINE_POWERPCFP = 497,

            IMAGE_FILE_MACHINE_MIPS16 = 614,

            IMAGE_FILE_MACHINE_ALPHA64 = 644,

            IMAGE_FILE_MACHINE_MIPSFPU = 870,

            IMAGE_FILE_MACHINE_MIPSFPU16 = 1126,

            IMAGE_FILE_MACHINE_TRICORE = 1312,

            IMAGE_FILE_MACHINE_CEF = 3311,

            IMAGE_FILE_MACHINE_EBC = 3772,

            IMAGE_FILE_MACHINE_M32R = 36929,

            IMAGE_FILE_MACHINE_ARM64 = 43620,

            IMAGE_FILE_MACHINE_CEE = 49390
        }

        public enum IMAGE_SUBSYSTEM : uint
        {
            IMAGE_SUBSYSTEM_UNKNOWN = 0u,

            IMAGE_SUBSYSTEM_NATIVE = 1u,

            IMAGE_SUBSYSTEM_WINDOWS_GUI = 2u,

            IMAGE_SUBSYSTEM_WINDOWS_CUI = 3u,

            IMAGE_SUBSYSTEM_OS2_CUI = 5u,

            IMAGE_SUBSYSTEM_POSIX_CUI = 7u,

            IMAGE_SUBSYSTEM_NATIVE_WINDOWS = 8u,

            IMAGE_SUBSYSTEM_WINDOWS_CE_GUI = 9u,

            IMAGE_SUBSYSTEM_EFI_APPLICATION = 10u,

            IMAGE_SUBSYSTEM_EFI_BOOT_SERVICE_DRIVER = 11u,

            IMAGE_SUBSYSTEM_EFI_RUNTIME_DRIVER = 12u,

            IMAGE_SUBSYSTEM_EFI_ROM = 13u,

            IMAGE_SUBSYSTEM_XBOX = 14u,

            IMAGE_SUBSYSTEM_WINDOWS_BOOT_APPLICATION = 0x10u,

            IMAGE_SUBSYSTEM_XBOX_CODE_CATALOG = 17u
        }

        public enum IMAGE_OPTIONAL_HEADER_MAGIC : uint
        {
            IMAGE_NT_OPTIONAL_HDR_MAGIC = 523u,
            IMAGE_NT_OPTIONAL_HDR32_MAGIC = 267u,
            IMAGE_NT_OPTIONAL_HDR64_MAGIC = 523u,
            IMAGE_ROM_OPTIONAL_HDR_MAGIC = 263u
        }

        [Flags]
        public enum IMAGE_DLL_FLAGS : uint
        {
            IMAGE_DLLCHARACTERISTICS_HIGH_ENTROPY_VA = 0x20u,

            IMAGE_DLLCHARACTERISTICS_DYNAMIC_BASE = 0x40u,

            IMAGE_DLLCHARACTERISTICS_FORCE_INTEGRITY = 0x80u,

            IMAGE_DLLCHARACTERISTICS_NX_COMPAT = 0x100u,

            IMAGE_DLLCHARACTERISTICS_NO_ISOLATION = 0x200u,

            IMAGE_DLLCHARACTERISTICS_NO_SEH = 0x400u,

            IMAGE_DLLCHARACTERISTICS_NO_BIND = 0x800u,

            IMAGE_DLLCHARACTERISTICS_APPCONTAINER = 0x1000u,

            IMAGE_DLLCHARACTERISTICS_WDM_DRIVER = 0x2000u,

            IMAGE_DLLCHARACTERISTICS_GUARD_CF = 0x4000u,

            IMAGE_DLLCHARACTERISTICS_TERMINAL_SERVER_AWARE = 0x8000u,

            IMAGE_DLLCHARACTERISTICS_EX_CET_COMPAT = 0x1u
        }

        [Flags]
        public enum IMAGE_FILE_FLAGS : uint
        {
            IMAGE_FILE_RELOCS_STRIPPED = 0x1u,

            IMAGE_FILE_EXECUTABLE_IMAGE = 0x2u,

            IMAGE_FILE_LINE_NUMS_STRIPPED = 0x4u,

            IMAGE_FILE_LOCAL_SYMS_STRIPPED = 0x8u,

            IMAGE_FILE_AGGRESIVE_WS_TRIM = 0x10u,

            IMAGE_FILE_LARGE_ADDRESS_AWARE = 0x20u,

            IMAGE_FILE_BYTES_REVERSED_LO = 0x80u,

            IMAGE_FILE_32BIT_MACHINE = 0x100u,

            IMAGE_FILE_DEBUG_STRIPPED = 0x200u,

            IMAGE_FILE_REMOVABLE_RUN_FROM_SWAP = 0x400u,

            IMAGE_FILE_NET_RUN_FROM_SWAP = 0x800u,

            IMAGE_FILE_SYSTEM = 0x1000u,

            IMAGE_FILE_DLL = 0x2000u,

            IMAGE_FILE_UP_SYSTEM_ONLY = 0x4000u,

            IMAGE_FILE_BYTES_REVERSED_HI = 0x8000u
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4)]
        public struct IMAGE_FUNCTION_ENTRY64
        {
            [StructLayout(LayoutKind.Explicit, Pack = 4)]
            public struct _Anonymous_e__Union
            {
                [FieldOffset(0)]
                public ulong EndOfPrologue;

                [FieldOffset(0)]
                public ulong UnwindInfoAddress;
            }

            public ulong StartingAddress;

            public ulong EndingAddress;

            public _Anonymous_e__Union Anonymous;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4)]
        public struct IMAGE_LOAD_CONFIG_DIRECTORY64
        {
            public uint Size;

            public uint TimeDateStamp;

            public ushort MajorVersion;

            public ushort MinorVersion;

            public uint GlobalFlagsClear;

            public uint GlobalFlagsSet;

            public uint CriticalSectionDefaultTimeout;

            public ulong DeCommitFreeBlockThreshold;

            public ulong DeCommitTotalFreeThreshold;

            public ulong LockPrefixTable;

            public ulong MaximumAllocationSize;

            public ulong VirtualMemoryThreshold;

            public ulong ProcessAffinityMask;

            public uint ProcessHeapFlags;

            public ushort CSDVersion;

            public ushort DependentLoadFlags;

            public ulong EditList;

            public ulong SecurityCookie;

            public ulong SEHandlerTable;

            public ulong SEHandlerCount;

            public ulong GuardCFCheckFunctionPointer;

            public ulong GuardCFDispatchFunctionPointer;

            public ulong GuardCFFunctionTable;

            public ulong GuardCFFunctionCount;

            public uint GuardFlags;

            public IMAGE_LOAD_CONFIG_CODE_INTEGRITY CodeIntegrity;

            public ulong GuardAddressTakenIatEntryTable;

            public ulong GuardAddressTakenIatEntryCount;

            public ulong GuardLongJumpTargetTable;

            public ulong GuardLongJumpTargetCount;

            public ulong DynamicValueRelocTable;

            public ulong CHPEMetadataPointer;

            public ulong GuardRFFailureRoutine;

            public ulong GuardRFFailureRoutineFunctionPointer;

            public uint DynamicValueRelocTableOffset;

            public ushort DynamicValueRelocTableSection;

            public ushort Reserved2;

            public ulong GuardRFVerifyStackPointerFunctionPointer;

            public uint HotPatchTableOffset;

            public uint Reserved3;

            public ulong EnclaveConfigurationPointer;

            public ulong VolatileMetadataPointer;

            public ulong GuardEHContinuationTable;

            public ulong GuardEHContinuationCount;
        }

        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public struct IMAGE_LOAD_CONFIG_DIRECTORY32
        {
            public uint Size;

            public uint TimeDateStamp;

            public ushort MajorVersion;

            public ushort MinorVersion;

            public uint GlobalFlagsClear;

            public uint GlobalFlagsSet;

            public uint CriticalSectionDefaultTimeout;

            public uint DeCommitFreeBlockThreshold;

            public uint DeCommitTotalFreeThreshold;

            public uint LockPrefixTable;

            public uint MaximumAllocationSize;

            public uint VirtualMemoryThreshold;

            public uint ProcessHeapFlags;

            public uint ProcessAffinityMask;

            public ushort CSDVersion;

            public ushort DependentLoadFlags;

            public uint EditList;

            public uint SecurityCookie;

            public uint SEHandlerTable;

            public uint SEHandlerCount;

            public uint GuardCFCheckFunctionPointer;

            public uint GuardCFDispatchFunctionPointer;

            public uint GuardCFFunctionTable;

            public uint GuardCFFunctionCount;

            public uint GuardFlags;

            public IMAGE_LOAD_CONFIG_CODE_INTEGRITY CodeIntegrity;

            public uint GuardAddressTakenIatEntryTable;

            public uint GuardAddressTakenIatEntryCount;

            public uint GuardLongJumpTargetTable;

            public uint GuardLongJumpTargetCount;

            public uint DynamicValueRelocTable;

            public uint CHPEMetadataPointer;

            public uint GuardRFFailureRoutine;

            public uint GuardRFFailureRoutineFunctionPointer;

            public uint DynamicValueRelocTableOffset;

            public ushort DynamicValueRelocTableSection;

            public ushort Reserved2;

            public uint GuardRFVerifyStackPointerFunctionPointer;

            public uint HotPatchTableOffset;

            public uint Reserved3;

            public uint EnclaveConfigurationPointer;

            public uint VolatileMetadataPointer;

            public uint GuardEHContinuationTable;

            public uint GuardEHContinuationCount;
        }

        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public struct IMAGE_LOAD_CONFIG_CODE_INTEGRITY
        {
            public ushort Flags;

            public ushort Catalog;

            public uint CatalogOffset;

            public uint Reserved;
        }

        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public struct IMAGE_NT_HEADERS32
        {
            public uint Signature;

            public CoffHeader FileHeader;

            public IMAGE_OPTIONAL_HEADER32 OptionalHeader;
        }

        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public struct IMAGE_NT_HEADERS64
        {
            public uint Signature;

            public CoffHeader FileHeader;

            public IMAGE_OPTIONAL_HEADER64 OptionalHeader;
        }

        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public struct IMAGE_DATA_DIRECTORY
        {
            public uint VirtualAddress;

            public uint Size;
        }

        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public struct IMAGE_FUNCTION_ENTRY
        {
            public uint StartingAddress;

            public uint EndingAddress;

            public uint EndOfPrologue;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct IMAGE_OPTIONAL_HEADER32
        {
            public IMAGE_OPTIONAL_HEADER_MAGIC Magic;

            public byte MajorLinkerVersion;

            public byte MinorLinkerVersion;

            public uint SizeOfCode;

            public uint SizeOfInitializedData;

            public uint SizeOfUninitializedData;

            public uint AddressOfEntryPoint;

            public uint BaseOfCode;

            public uint BaseOfData;

            public uint ImageBase;

            public uint SectionAlignment;

            public uint FileAlignment;

            public ushort MajorOperatingSystemVersion;

            public ushort MinorOperatingSystemVersion;

            public ushort MajorImageVersion;

            public ushort MinorImageVersion;

            public ushort MajorSubsystemVersion;

            public ushort MinorSubsystemVersion;

            public uint Win32VersionValue;

            public uint SizeOfImage;

            public uint SizeOfHeaders;

            public uint CheckSum;

            public IMAGE_SUBSYSTEM Subsystem;

            public IMAGE_DLL_FLAGS DllCharacteristics;

            public uint SizeOfStackReserve;

            public uint SizeOfStackCommit;

            public uint SizeOfHeapReserve;

            public uint SizeOfHeapCommit;

            [Obsolete]
            public uint LoaderFlags;

            public uint NumberOfRvaAndSizes;

            public IMAGE_DATA_DIRECTORY[] DataDirectory;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4)]
        public struct IMAGE_OPTIONAL_HEADER64
        {
            public IMAGE_OPTIONAL_HEADER_MAGIC Magic;

            public byte MajorLinkerVersion;

            public byte MinorLinkerVersion;

            public uint SizeOfCode;

            public uint SizeOfInitializedData;

            public uint SizeOfUninitializedData;

            public uint AddressOfEntryPoint;

            public uint BaseOfCode;

            public ulong ImageBase;

            public uint SectionAlignment;

            public uint FileAlignment;

            public ushort MajorOperatingSystemVersion;

            public ushort MinorOperatingSystemVersion;

            public ushort MajorImageVersion;

            public ushort MinorImageVersion;

            public ushort MajorSubsystemVersion;

            public ushort MinorSubsystemVersion;

            public uint Win32VersionValue;

            public uint SizeOfImage;

            public uint SizeOfHeaders;

            public uint CheckSum;

            public IMAGE_SUBSYSTEM Subsystem;

            public IMAGE_DLL_FLAGS DllCharacteristics;

            public ulong SizeOfStackReserve;

            public ulong SizeOfStackCommit;

            public ulong SizeOfHeapReserve;

            public ulong SizeOfHeapCommit;

            [Obsolete]
            public uint LoaderFlags;

            public uint NumberOfRvaAndSizes;

            public IMAGE_DATA_DIRECTORY[] DataDirectory;
        }
    }
}