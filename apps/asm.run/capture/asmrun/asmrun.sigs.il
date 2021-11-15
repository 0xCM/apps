// ------------------------------------------------------------------------------------------------------------------------
// Id:0x6000009        BaseAddress:7ffaa270abb8h    Uri:located://asmrun/sigs?func_32i_32i_32i#func_32i_32i_32i_(void~ptr)
// CliSig:[10] = [00 01 1b 09 02 08 08 08 0f 01]
// Encoded[2] = [02 2a]
// IntPtr func_32i_32i_32i(void* f)
{
  IL_0000:  ldarg.0
  IL_0001:  ret
}

// ------------------------------------------------------------------------------------------------------------------------
// Id:0x600000a        BaseAddress:7ffaa270abc0h    Uri:located://asmrun/sigs?invoke#invoke_(IntPtr,32i,32i)
// CliSig:[11] = [00 03 08 1b 09 02 08 08 08 08 08]
// Encoded[11] = [02 0a 03 04 06 29 06 00 00 11 2a]
// int invoke(IntPtr f, int a, int b)
{
  IL_0000:  ldarg.0
  IL_0001:  stloc.0
  IL_0002:  ldarg.1
  IL_0003:  ldarg.2
  IL_0004:  ldloc.0
  IL_0005:  calli      0x11000006
  IL_000a:  ret
}

