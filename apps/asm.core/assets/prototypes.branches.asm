# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# byte branch(Branch02 m, byte src)::located://test.checks/prototypes.branches?branch#branchヽ(Branch02,8u)
# public static ReadOnlySpan<byte> branchヽᐤBranch02ㆍ8uᐤ => new byte[202]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb6,0xc2,0x83,0xf8,0x55,0x77,0x40,0x83,0xf8,0x18,0x77,0x2a,0x8d,0x50,0xef,0x83,0xfa,0x03,0x77,0x18,0x8b,0xc2,0x48,0x8d,0x0d,0xad,0x00,0x00,0x00,0x8b,0x0c,0x81,0x48,0x8d,0x15,0xd8,0xff,0xff,0xff,0x48,0x03,0xca,0xff,0xe1,0x83,0xf8,0x18,0x74,0x6a,0xe9,0x88,0x00,0x00,0x00,0x83,0xf8,0x21,0x74,0x6e,0x83,0xf8,0x3f,0x74,0x54,0x83,0xf8,0x55,0x74,0x41,0xeb,0x77,0x83,0xf8,0x68,0x77,0x0c,0x83,0xf8,0x59,0x74,0x5f,0x83,0xf8,0x68,0x74,0x37,0xeb,0x66,0x3d,0x81,0x00,0x00,0x00,0x74,0x14,0x3d,0x86,0x00,0x00,0x00,0x74,0x51,0x3d,0xf3,0x00,0x00,0x00,0x75,0x51,0xb8,0x32,0x00,0x00,0x00,0xc3,0xb8,0x19,0x00,0x00,0x00,0xc3,0xb8,0x78,0x00,0x00,0x00,0xc3,0xb9,0x22,0x00,0x00,0x00,0xeb,0x3a,0xb9,0x39,0x00,0x00,0x00,0xeb,0x33,0xb9,0x81,0x00,0x00,0x00,0xeb,0x2c,0xb9,0x23,0x00,0x00,0x00,0xeb,0x25,0xb9,0x91,0x00,0x00,0x00,0xeb,0x1e,0xb9,0x87,0x00,0x00,0x00,0xeb,0x17,0xb9,0x33,0x00,0x00,0x00,0xeb,0x10,0xb9,0x93,0x00,0x00,0x00,0xeb,0x09,0xb9,0x18,0x00,0x00,0x00,0xeb,0x02,0x33,0xc9,0x0f,0xb6,0xc1,0xc3};
# [0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb6,0xc2,0x83,0xf8,0x55,0x77,0x40,0x83,0xf8,0x18,0x77,0x2a,0x8d,0x50,0xef,0x83,0xfa,0x03,0x77,0x18,0x8b,0xc2,0x48,0x8d,0x0d,0xad,0x00,0x00,0x00,0x8b,0x0c,0x81,0x48,0x8d,0x15,0xd8,0xff,0xff,0xff,0x48,0x03,0xca,0xff,0xe1,0x83,0xf8,0x18,0x74,0x6a,0xe9,0x88,0x00,0x00,0x00,0x83,0xf8,0x21,0x74,0x6e,0x83,0xf8,0x3f,0x74,0x54,0x83,0xf8,0x55,0x74,0x41,0xeb,0x77,0x83,0xf8,0x68,0x77,0x0c,0x83,0xf8,0x59,0x74,0x5f,0x83,0xf8,0x68,0x74,0x37,0xeb,0x66,0x3d,0x81,0x00,0x00,0x00,0x74,0x14,0x3d,0x86,0x00,0x00,0x00,0x74,0x51,0x3d,0xf3,0x00,0x00,0x00,0x75,0x51,0xb8,0x32,0x00,0x00,0x00,0xc3,0xb8,0x19,0x00,0x00,0x00,0xc3,0xb8,0x78,0x00,0x00,0x00,0xc3,0xb9,0x22,0x00,0x00,0x00,0xeb,0x3a,0xb9,0x39,0x00,0x00,0x00,0xeb,0x33,0xb9,0x81,0x00,0x00,0x00,0xeb,0x2c,0xb9,0x23,0x00,0x00,0x00,0xeb,0x25,0xb9,0x91,0x00,0x00,0x00,0xeb,0x1e,0xb9,0x87,0x00,0x00,0x00,0xeb,0x17,0xb9,0x33,0x00,0x00,0x00,0xeb,0x10,0xb9,0x93,0x00,0x00,0x00,0xeb,0x09,0xb9,0x18,0x00,0x00,0x00,0xeb,0x02,0x33,0xc9,0x0f,0xb6,0xc1,0xc3]
# BaseAddress = 7ffb67de1520h
# TermCode = None
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
_@7ffb67de1520:
nop dword ptr [rax+rax]                       # 0000h  | 5   | 0f 1f 44 00 00                   | (NOP r/m32) = 0F 1F /0
movzx eax,dl                                  # 0005h  | 3   | 0f b6 c2                         | (MOVZX r32, r/m8) = 0F B6 /r
cmp eax,55h                                   # 0008h  | 3   | 83 f8 55                         | (CMP r/m32, imm8) = 83 /7 ib
ja short 004dh                                # 000bh  | 2   | 77 40                            | (JA rel8) = 77 cb
cmp eax,18h                                   # 000dh  | 3   | 83 f8 18                         | (CMP r/m32, imm8) = 83 /7 ib
ja short 003ch                                # 0010h  | 2   | 77 2a                            | (JA rel8) = 77 cb
lea edx,[rax-11h]                             # 0012h  | 3   | 8d 50 ef                         | (LEA r32, m) = 8D /r
cmp edx,3                                     # 0015h  | 3   | 83 fa 03                         | (CMP r/m32, imm8) = 83 /7 ib
ja short 0032h                                # 0018h  | 2   | 77 18                            | (JA rel8) = 77 cb
mov eax,edx                                   # 001ah  | 2   | 8b c2                            | (MOV r32, r/m32) = 8B /r
lea rcx,[rip+0adh]                            # 001ch  | 7   | 48 8d 0d ad 00 00 00             | (LEA r64, m) = REX.W 8D /r
mov ecx,[rcx+rax*4]                           # 0023h  | 3   | 8b 0c 81                         | (MOV r32, r/m32) = 8B /r
lea rdx,[rip-28h]                             # 0026h  | 7   | 48 8d 15 d8 ff ff ff             | (LEA r64, m) = REX.W 8D /r
add rcx,rdx                                   # 002dh  | 3   | 48 03 ca                         | (ADD r64, r/m64) = REX.W 03 /r
jmp rcx                                       # 0030h  | 2   | ff e1                            | (JMP r/m64) = FF /4
cmp eax,18h                                   # 0032h  | 3   | 83 f8 18                         | (CMP r/m32, imm8) = 83 /7 ib
je short 00a1h                                # 0035h  | 2   | 74 6a                            | (JE rel8) = 74 cb
jmp near ptr 00c4h                            # 0037h  | 5   | e9 88 00 00 00                   | (JMP rel32) = E9 cd
cmp eax,21h                                   # 003ch  | 3   | 83 f8 21                         | (CMP r/m32, imm8) = 83 /7 ib
je short 00afh                                # 003fh  | 2   | 74 6e                            | (JE rel8) = 74 cb
cmp eax,3fh                                   # 0041h  | 3   | 83 f8 3f                         | (CMP r/m32, imm8) = 83 /7 ib
je short 009ah                                # 0044h  | 2   | 74 54                            | (JE rel8) = 74 cb
cmp eax,55h                                   # 0046h  | 3   | 83 f8 55                         | (CMP r/m32, imm8) = 83 /7 ib
je short 008ch                                # 0049h  | 2   | 74 41                            | (JE rel8) = 74 cb
jmp short 00c4h                               # 004bh  | 2   | eb 77                            | (JMP rel8) = EB cb
cmp eax,68h                                   # 004dh  | 3   | 83 f8 68                         | (CMP r/m32, imm8) = 83 /7 ib
ja short 005eh                                # 0050h  | 2   | 77 0c                            | (JA rel8) = 77 cb
cmp eax,59h                                   # 0052h  | 3   | 83 f8 59                         | (CMP r/m32, imm8) = 83 /7 ib
je short 00b6h                                # 0055h  | 2   | 74 5f                            | (JE rel8) = 74 cb
cmp eax,68h                                   # 0057h  | 3   | 83 f8 68                         | (CMP r/m32, imm8) = 83 /7 ib
je short 0093h                                # 005ah  | 2   | 74 37                            | (JE rel8) = 74 cb
jmp short 00c4h                               # 005ch  | 2   | eb 66                            | (JMP rel8) = EB cb
cmp eax,81h                                   # 005eh  | 5   | 3d 81 00 00 00                   | (CMP EAX, imm32) = 3D id
je short 0079h                                # 0063h  | 2   | 74 14                            | (JE rel8) = 74 cb
cmp eax,86h                                   # 0065h  | 5   | 3d 86 00 00 00                   | (CMP EAX, imm32) = 3D id
je short 00bdh                                # 006ah  | 2   | 74 51                            | (JE rel8) = 74 cb
cmp eax,0f3h                                  # 006ch  | 5   | 3d f3 00 00 00                   | (CMP EAX, imm32) = 3D id
jne short 00c4h                               # 0071h  | 2   | 75 51                            | (JNE rel8) = 75 cb
mov eax,32h                                   # 0073h  | 5   | b8 32 00 00 00                   | (MOV r32, imm32) = B8 +rd id
ret                                           # 0078h  | 1   | c3                               | (RET) = C3
mov eax,19h                                   # 0079h  | 5   | b8 19 00 00 00                   | (MOV r32, imm32) = B8 +rd id
ret                                           # 007eh  | 1   | c3                               | (RET) = C3
mov eax,78h                                   # 007fh  | 5   | b8 78 00 00 00                   | (MOV r32, imm32) = B8 +rd id
ret                                           # 0084h  | 1   | c3                               | (RET) = C3
mov ecx,22h                                   # 0085h  | 5   | b9 22 00 00 00                   | (MOV r32, imm32) = B8 +rd id
jmp short 00c6h                               # 008ah  | 2   | eb 3a                            | (JMP rel8) = EB cb
mov ecx,39h                                   # 008ch  | 5   | b9 39 00 00 00                   | (MOV r32, imm32) = B8 +rd id
jmp short 00c6h                               # 0091h  | 2   | eb 33                            | (JMP rel8) = EB cb
mov ecx,81h                                   # 0093h  | 5   | b9 81 00 00 00                   | (MOV r32, imm32) = B8 +rd id
jmp short 00c6h                               # 0098h  | 2   | eb 2c                            | (JMP rel8) = EB cb
mov ecx,23h                                   # 009ah  | 5   | b9 23 00 00 00                   | (MOV r32, imm32) = B8 +rd id
jmp short 00c6h                               # 009fh  | 2   | eb 25                            | (JMP rel8) = EB cb
mov ecx,91h                                   # 00a1h  | 5   | b9 91 00 00 00                   | (MOV r32, imm32) = B8 +rd id
jmp short 00c6h                               # 00a6h  | 2   | eb 1e                            | (JMP rel8) = EB cb
mov ecx,87h                                   # 00a8h  | 5   | b9 87 00 00 00                   | (MOV r32, imm32) = B8 +rd id
jmp short 00c6h                               # 00adh  | 2   | eb 17                            | (JMP rel8) = EB cb
mov ecx,33h                                   # 00afh  | 5   | b9 33 00 00 00                   | (MOV r32, imm32) = B8 +rd id
jmp short 00c6h                               # 00b4h  | 2   | eb 10                            | (JMP rel8) = EB cb
mov ecx,93h                                   # 00b6h  | 5   | b9 93 00 00 00                   | (MOV r32, imm32) = B8 +rd id
jmp short 00c6h                               # 00bbh  | 2   | eb 09                            | (JMP rel8) = EB cb
mov ecx,18h                                   # 00bdh  | 5   | b9 18 00 00 00                   | (MOV r32, imm32) = B8 +rd id
jmp short 00c6h                               # 00c2h  | 2   | eb 02                            | (JMP rel8) = EB cb
xor ecx,ecx                                   # 00c4h  | 2   | 33 c9                            | (XOR r32, r/m32) = 33 /r
movzx eax,cl                                  # 00c6h  | 3   | 0f b6 c1                         | (MOVZX r32, r/m8) = 0F B6 /r
ret                                           # 00c9h  | 1   | c3                               | (RET) = C3
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# byte branch(Branch03 m, ulong src)::located://test.checks/prototypes.branches?branch#branchヽ(Branch03,64u)
# public static ReadOnlySpan<byte> branchヽᐤBranch03ㆍ64uᐤ => new byte[251]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x81,0xfa,0x30,0x30,0x30,0x30,0x77,0x51,0x48,0x81,0xfa,0x0a,0x0a,0x0a,0x0a,0x77,0x28,0x48,0x81,0xfa,0x08,0x08,0x08,0x08,0x0f,0x84,0xb5,0x00,0x00,0x00,0x48,0x81,0xfa,0x09,0x08,0x09,0x09,0x0f,0x84,0xaf,0x00,0x00,0x00,0x48,0x81,0xfa,0x0a,0x0a,0x0a,0x0a,0x74,0x6a,0xe9,0xb6,0x00,0x00,0x00,0x48,0x81,0xfa,0x10,0x10,0x10,0x10,0x74,0x62,0x48,0x81,0xfa,0x20,0x20,0x20,0x20,0x74,0x5f,0x48,0x81,0xfa,0x30,0x30,0x30,0x30,0x74,0x5c,0xe9,0x96,0x00,0x00,0x00,0x48,0x81,0xfa,0x60,0x60,0x60,0x60,0x77,0x1d,0x48,0x81,0xfa,0x40,0x40,0x40,0x40,0x74,0x4c,0x48,0x81,0xfa,0x50,0x50,0x50,0x50,0x74,0x4a,0x48,0x81,0xfa,0x60,0x60,0x60,0x60,0x74,0x48,0xeb,0x70,0x48,0x81,0xfa,0x70,0x70,0x70,0x70,0x74,0x44,0xb8,0xb0,0xb0,0xb0,0xb0,0x48,0x3b,0xd0,0x74,0x4f,0xb8,0xc0,0xc0,0xc0,0xc0,0x48,0x3b,0xd0,0x74,0x4c,0xeb,0x51,0xb8,0x32,0x00,0x00,0x00,0xc3,0xb8,0x19,0x00,0x00,0x00,0xc3,0xb8,0x78,0x00,0x00,0x00,0xc3,0xb8,0x22,0x00,0x00,0x00,0xeb,0x3a,0xb8,0x39,0x00,0x00,0x00,0xeb,0x33,0xb8,0x81,0x00,0x00,0x00,0xeb,0x2c,0xb8,0x23,0x00,0x00,0x00,0xeb,0x25,0xb8,0x91,0x00,0x00,0x00,0xeb,0x1e,0xb8,0x87,0x00,0x00,0x00,0xeb,0x17,0xb8,0x33,0x00,0x00,0x00,0xeb,0x10,0xb8,0x93,0x00,0x00,0x00,0xeb,0x09,0xb8,0x18,0x00,0x00,0x00,0xeb,0x02,0x33,0xc0,0x0f,0xb6,0xc0,0xc3};
# [0x0f,0x1f,0x44,0x00,0x00,0x48,0x81,0xfa,0x30,0x30,0x30,0x30,0x77,0x51,0x48,0x81,0xfa,0x0a,0x0a,0x0a,0x0a,0x77,0x28,0x48,0x81,0xfa,0x08,0x08,0x08,0x08,0x0f,0x84,0xb5,0x00,0x00,0x00,0x48,0x81,0xfa,0x09,0x08,0x09,0x09,0x0f,0x84,0xaf,0x00,0x00,0x00,0x48,0x81,0xfa,0x0a,0x0a,0x0a,0x0a,0x74,0x6a,0xe9,0xb6,0x00,0x00,0x00,0x48,0x81,0xfa,0x10,0x10,0x10,0x10,0x74,0x62,0x48,0x81,0xfa,0x20,0x20,0x20,0x20,0x74,0x5f,0x48,0x81,0xfa,0x30,0x30,0x30,0x30,0x74,0x5c,0xe9,0x96,0x00,0x00,0x00,0x48,0x81,0xfa,0x60,0x60,0x60,0x60,0x77,0x1d,0x48,0x81,0xfa,0x40,0x40,0x40,0x40,0x74,0x4c,0x48,0x81,0xfa,0x50,0x50,0x50,0x50,0x74,0x4a,0x48,0x81,0xfa,0x60,0x60,0x60,0x60,0x74,0x48,0xeb,0x70,0x48,0x81,0xfa,0x70,0x70,0x70,0x70,0x74,0x44,0xb8,0xb0,0xb0,0xb0,0xb0,0x48,0x3b,0xd0,0x74,0x4f,0xb8,0xc0,0xc0,0xc0,0xc0,0x48,0x3b,0xd0,0x74,0x4c,0xeb,0x51,0xb8,0x32,0x00,0x00,0x00,0xc3,0xb8,0x19,0x00,0x00,0x00,0xc3,0xb8,0x78,0x00,0x00,0x00,0xc3,0xb8,0x22,0x00,0x00,0x00,0xeb,0x3a,0xb8,0x39,0x00,0x00,0x00,0xeb,0x33,0xb8,0x81,0x00,0x00,0x00,0xeb,0x2c,0xb8,0x23,0x00,0x00,0x00,0xeb,0x25,0xb8,0x91,0x00,0x00,0x00,0xeb,0x1e,0xb8,0x87,0x00,0x00,0x00,0xeb,0x17,0xb8,0x33,0x00,0x00,0x00,0xeb,0x10,0xb8,0x93,0x00,0x00,0x00,0xeb,0x09,0xb8,0x18,0x00,0x00,0x00,0xeb,0x02,0x33,0xc0,0x0f,0xb6,0xc0,0xc3]
# BaseAddress = 7ffb67de1610h
# TermCode = None
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
_@7ffb67de1610:
nop dword ptr [rax+rax]                       # 0000h  | 5   | 0f 1f 44 00 00                   | (NOP r/m32) = 0F 1F /0
cmp rdx,30303030h                             # 0005h  | 7   | 48 81 fa 30 30 30 30             | (CMP r/m64, imm32) = REX.W 81 /7 id
ja short 005fh                                # 000ch  | 2   | 77 51                            | (JA rel8) = 77 cb
cmp rdx,0a0a0a0ah                             # 000eh  | 7   | 48 81 fa 0a 0a 0a 0a             | (CMP r/m64, imm32) = REX.W 81 /7 id
ja short 003fh                                # 0015h  | 2   | 77 28                            | (JA rel8) = 77 cb
cmp rdx,8080808h                              # 0017h  | 7   | 48 81 fa 08 08 08 08             | (CMP r/m64, imm32) = REX.W 81 /7 id
je near ptr 00d9h                             # 001eh  | 6   | 0f 84 b5 00 00 00                | (JE rel32) = 0F 84 cd
cmp rdx,9090809h                              # 0024h  | 7   | 48 81 fa 09 08 09 09             | (CMP r/m64, imm32) = REX.W 81 /7 id
je near ptr 00e0h                             # 002bh  | 6   | 0f 84 af 00 00 00                | (JE rel32) = 0F 84 cd
cmp rdx,0a0a0a0ah                             # 0031h  | 7   | 48 81 fa 0a 0a 0a 0a             | (CMP r/m64, imm32) = REX.W 81 /7 id
je short 00a4h                                # 0038h  | 2   | 74 6a                            | (JE rel8) = 74 cb
jmp near ptr 00f5h                            # 003ah  | 5   | e9 b6 00 00 00                   | (JMP rel32) = E9 cd
cmp rdx,10101010h                             # 003fh  | 7   | 48 81 fa 10 10 10 10             | (CMP r/m64, imm32) = REX.W 81 /7 id
je short 00aah                                # 0046h  | 2   | 74 62                            | (JE rel8) = 74 cb
cmp rdx,20202020h                             # 0048h  | 7   | 48 81 fa 20 20 20 20             | (CMP r/m64, imm32) = REX.W 81 /7 id
je short 00b0h                                # 004fh  | 2   | 74 5f                            | (JE rel8) = 74 cb
cmp rdx,30303030h                             # 0051h  | 7   | 48 81 fa 30 30 30 30             | (CMP r/m64, imm32) = REX.W 81 /7 id
je short 00b6h                                # 0058h  | 2   | 74 5c                            | (JE rel8) = 74 cb
jmp near ptr 00f5h                            # 005ah  | 5   | e9 96 00 00 00                   | (JMP rel32) = E9 cd
cmp rdx,60606060h                             # 005fh  | 7   | 48 81 fa 60 60 60 60             | (CMP r/m64, imm32) = REX.W 81 /7 id
ja short 0085h                                # 0066h  | 2   | 77 1d                            | (JA rel8) = 77 cb
cmp rdx,40404040h                             # 0068h  | 7   | 48 81 fa 40 40 40 40             | (CMP r/m64, imm32) = REX.W 81 /7 id
je short 00bdh                                # 006fh  | 2   | 74 4c                            | (JE rel8) = 74 cb
cmp rdx,50505050h                             # 0071h  | 7   | 48 81 fa 50 50 50 50             | (CMP r/m64, imm32) = REX.W 81 /7 id
je short 00c4h                                # 0078h  | 2   | 74 4a                            | (JE rel8) = 74 cb
cmp rdx,60606060h                             # 007ah  | 7   | 48 81 fa 60 60 60 60             | (CMP r/m64, imm32) = REX.W 81 /7 id
je short 00cbh                                # 0081h  | 2   | 74 48                            | (JE rel8) = 74 cb
jmp short 00f5h                               # 0083h  | 2   | eb 70                            | (JMP rel8) = EB cb
cmp rdx,70707070h                             # 0085h  | 7   | 48 81 fa 70 70 70 70             | (CMP r/m64, imm32) = REX.W 81 /7 id
je short 00d2h                                # 008ch  | 2   | 74 44                            | (JE rel8) = 74 cb
mov eax,0b0b0b0b0h                            # 008eh  | 5   | b8 b0 b0 b0 b0                   | (MOV r32, imm32) = B8 +rd id
cmp rdx,rax                                   # 0093h  | 3   | 48 3b d0                         | (CMP r64, r/m64) = REX.W 3B /r
je short 00e7h                                # 0096h  | 2   | 74 4f                            | (JE rel8) = 74 cb
mov eax,0c0c0c0c0h                            # 0098h  | 5   | b8 c0 c0 c0 c0                   | (MOV r32, imm32) = B8 +rd id
cmp rdx,rax                                   # 009dh  | 3   | 48 3b d0                         | (CMP r64, r/m64) = REX.W 3B /r
je short 00eeh                                # 00a0h  | 2   | 74 4c                            | (JE rel8) = 74 cb
jmp short 00f5h                               # 00a2h  | 2   | eb 51                            | (JMP rel8) = EB cb
mov eax,32h                                   # 00a4h  | 5   | b8 32 00 00 00                   | (MOV r32, imm32) = B8 +rd id
ret                                           # 00a9h  | 1   | c3                               | (RET) = C3
mov eax,19h                                   # 00aah  | 5   | b8 19 00 00 00                   | (MOV r32, imm32) = B8 +rd id
ret                                           # 00afh  | 1   | c3                               | (RET) = C3
mov eax,78h                                   # 00b0h  | 5   | b8 78 00 00 00                   | (MOV r32, imm32) = B8 +rd id
ret                                           # 00b5h  | 1   | c3                               | (RET) = C3
mov eax,22h                                   # 00b6h  | 5   | b8 22 00 00 00                   | (MOV r32, imm32) = B8 +rd id
jmp short 00f7h                               # 00bbh  | 2   | eb 3a                            | (JMP rel8) = EB cb
mov eax,39h                                   # 00bdh  | 5   | b8 39 00 00 00                   | (MOV r32, imm32) = B8 +rd id
jmp short 00f7h                               # 00c2h  | 2   | eb 33                            | (JMP rel8) = EB cb
mov eax,81h                                   # 00c4h  | 5   | b8 81 00 00 00                   | (MOV r32, imm32) = B8 +rd id
jmp short 00f7h                               # 00c9h  | 2   | eb 2c                            | (JMP rel8) = EB cb
mov eax,23h                                   # 00cbh  | 5   | b8 23 00 00 00                   | (MOV r32, imm32) = B8 +rd id
jmp short 00f7h                               # 00d0h  | 2   | eb 25                            | (JMP rel8) = EB cb
mov eax,91h                                   # 00d2h  | 5   | b8 91 00 00 00                   | (MOV r32, imm32) = B8 +rd id
jmp short 00f7h                               # 00d7h  | 2   | eb 1e                            | (JMP rel8) = EB cb
mov eax,87h                                   # 00d9h  | 5   | b8 87 00 00 00                   | (MOV r32, imm32) = B8 +rd id
jmp short 00f7h                               # 00deh  | 2   | eb 17                            | (JMP rel8) = EB cb
mov eax,33h                                   # 00e0h  | 5   | b8 33 00 00 00                   | (MOV r32, imm32) = B8 +rd id
jmp short 00f7h                               # 00e5h  | 2   | eb 10                            | (JMP rel8) = EB cb
mov eax,93h                                   # 00e7h  | 5   | b8 93 00 00 00                   | (MOV r32, imm32) = B8 +rd id
jmp short 00f7h                               # 00ech  | 2   | eb 09                            | (JMP rel8) = EB cb
mov eax,18h                                   # 00eeh  | 5   | b8 18 00 00 00                   | (MOV r32, imm32) = B8 +rd id
jmp short 00f7h                               # 00f3h  | 2   | eb 02                            | (JMP rel8) = EB cb
xor eax,eax                                   # 00f5h  | 2   | 33 c0                            | (XOR r32, r/m32) = 33 /r
movzx eax,al                                  # 00f7h  | 3   | 0f b6 c0                         | (MOVZX r32, r/m8) = 0F B6 /r
ret                                           # 00fah  | 1   | c3                               | (RET) = C3
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
# ushort branch(Branch04 m, uint src)::located://test.checks/prototypes.branches?branch#branchヽ(Branch04,32u)
# public static ReadOnlySpan<byte> branchヽᐤBranch04ㆍ32uᐤ => new byte[230]{0x0f,0x1f,0x44,0x00,0x00,0x81,0xfa,0x08,0x78,0x08,0x38,0x77,0x46,0x81,0xfa,0x07,0x08,0x39,0x19,0x77,0x21,0x81,0xfa,0x0a,0x0a,0x1a,0x0a,0x74,0x72,0x81,0xfa,0x10,0x11,0x10,0x10,0x74,0x70,0x81,0xfa,0x07,0x08,0x39,0x19,0x0f,0x84,0x9a,0x00,0x00,0x00,0xe9,0xaa,0x00,0x00,0x00,0x81,0xfa,0x20,0x20,0x20,0x20,0x74,0x5d,0x81,0xfa,0x30,0x30,0x37,0x30,0x74,0x5b,0x81,0xfa,0x08,0x78,0x08,0x38,0x74,0x76,0xe9,0x8d,0x00,0x00,0x00,0x81,0xfa,0x60,0x60,0x67,0x60,0x77,0x1a,0x81,0xfa,0x49,0x40,0x40,0x40,0x74,0x45,0x81,0xfa,0x50,0x50,0x59,0x50,0x74,0x44,0x81,0xfa,0x60,0x60,0x67,0x60,0x74,0x43,0xeb,0x6b,0x81,0xfa,0x70,0x70,0x70,0x70,0x74,0x40,0x81,0xfa,0xb0,0xb0,0xbc,0xb7,0x74,0x4d,0x81,0xfa,0xc1,0xc0,0xc0,0xc9,0x74,0x4c,0xeb,0x51,0xb8,0x11,0x00,0x00,0x00,0xc3,0xb8,0x22,0x00,0x00,0x00,0xc3,0xb8,0x33,0x00,0x00,0x00,0xc3,0xb8,0x44,0x00,0x00,0x00,0xeb,0x3a,0xb8,0x55,0x00,0x00,0x00,0xeb,0x33,0xb8,0x66,0x00,0x00,0x00,0xeb,0x2c,0xb8,0x77,0x00,0x00,0x00,0xeb,0x25,0xb8,0x88,0x00,0x00,0x00,0xeb,0x1e,0xb8,0x99,0x00,0x00,0x00,0xeb,0x17,0xb8,0xaa,0x00,0x00,0x00,0xeb,0x10,0xb8,0xbb,0x00,0x00,0x00,0xeb,0x09,0xb8,0xcc,0x00,0x00,0x00,0xeb,0x02,0x33,0xc0,0x0f,0xb7,0xc0,0xc3};
# [0x0f,0x1f,0x44,0x00,0x00,0x81,0xfa,0x08,0x78,0x08,0x38,0x77,0x46,0x81,0xfa,0x07,0x08,0x39,0x19,0x77,0x21,0x81,0xfa,0x0a,0x0a,0x1a,0x0a,0x74,0x72,0x81,0xfa,0x10,0x11,0x10,0x10,0x74,0x70,0x81,0xfa,0x07,0x08,0x39,0x19,0x0f,0x84,0x9a,0x00,0x00,0x00,0xe9,0xaa,0x00,0x00,0x00,0x81,0xfa,0x20,0x20,0x20,0x20,0x74,0x5d,0x81,0xfa,0x30,0x30,0x37,0x30,0x74,0x5b,0x81,0xfa,0x08,0x78,0x08,0x38,0x74,0x76,0xe9,0x8d,0x00,0x00,0x00,0x81,0xfa,0x60,0x60,0x67,0x60,0x77,0x1a,0x81,0xfa,0x49,0x40,0x40,0x40,0x74,0x45,0x81,0xfa,0x50,0x50,0x59,0x50,0x74,0x44,0x81,0xfa,0x60,0x60,0x67,0x60,0x74,0x43,0xeb,0x6b,0x81,0xfa,0x70,0x70,0x70,0x70,0x74,0x40,0x81,0xfa,0xb0,0xb0,0xbc,0xb7,0x74,0x4d,0x81,0xfa,0xc1,0xc0,0xc0,0xc9,0x74,0x4c,0xeb,0x51,0xb8,0x11,0x00,0x00,0x00,0xc3,0xb8,0x22,0x00,0x00,0x00,0xc3,0xb8,0x33,0x00,0x00,0x00,0xc3,0xb8,0x44,0x00,0x00,0x00,0xeb,0x3a,0xb8,0x55,0x00,0x00,0x00,0xeb,0x33,0xb8,0x66,0x00,0x00,0x00,0xeb,0x2c,0xb8,0x77,0x00,0x00,0x00,0xeb,0x25,0xb8,0x88,0x00,0x00,0x00,0xeb,0x1e,0xb8,0x99,0x00,0x00,0x00,0xeb,0x17,0xb8,0xaa,0x00,0x00,0x00,0xeb,0x10,0xb8,0xbb,0x00,0x00,0x00,0xeb,0x09,0xb8,0xcc,0x00,0x00,0x00,0xeb,0x02,0x33,0xc0,0x0f,0xb7,0xc0,0xc3]
# BaseAddress = 7ffb67de1720h
# TermCode = None
# ----------------------------------------------------------------------------------------------------------------------------------------------------------------
_@7ffb67de1720:
nop dword ptr [rax+rax]                       # 0000h  | 5   | 0f 1f 44 00 00                   | (NOP r/m32) = 0F 1F /0
cmp edx,38087808h                             # 0005h  | 6   | 81 fa 08 78 08 38                | (CMP r/m32, imm32) = 81 /7 id
ja short 0053h                                # 000bh  | 2   | 77 46                            | (JA rel8) = 77 cb
cmp edx,19390807h                             # 000dh  | 6   | 81 fa 07 08 39 19                | (CMP r/m32, imm32) = 81 /7 id
ja short 0036h                                # 0013h  | 2   | 77 21                            | (JA rel8) = 77 cb
cmp edx,0a1a0a0ah                             # 0015h  | 6   | 81 fa 0a 0a 1a 0a                | (CMP r/m32, imm32) = 81 /7 id
je short 008fh                                # 001bh  | 2   | 74 72                            | (JE rel8) = 74 cb
cmp edx,10101110h                             # 001dh  | 6   | 81 fa 10 11 10 10                | (CMP r/m32, imm32) = 81 /7 id
je short 0095h                                # 0023h  | 2   | 74 70                            | (JE rel8) = 74 cb
cmp edx,19390807h                             # 0025h  | 6   | 81 fa 07 08 39 19                | (CMP r/m32, imm32) = 81 /7 id
je near ptr 00cbh                             # 002bh  | 6   | 0f 84 9a 00 00 00                | (JE rel32) = 0F 84 cd
jmp near ptr 00e0h                            # 0031h  | 5   | e9 aa 00 00 00                   | (JMP rel32) = E9 cd
cmp edx,20202020h                             # 0036h  | 6   | 81 fa 20 20 20 20                | (CMP r/m32, imm32) = 81 /7 id
je short 009bh                                # 003ch  | 2   | 74 5d                            | (JE rel8) = 74 cb
cmp edx,30373030h                             # 003eh  | 6   | 81 fa 30 30 37 30                | (CMP r/m32, imm32) = 81 /7 id
je short 00a1h                                # 0044h  | 2   | 74 5b                            | (JE rel8) = 74 cb
cmp edx,38087808h                             # 0046h  | 6   | 81 fa 08 78 08 38                | (CMP r/m32, imm32) = 81 /7 id
je short 00c4h                                # 004ch  | 2   | 74 76                            | (JE rel8) = 74 cb
jmp near ptr 00e0h                            # 004eh  | 5   | e9 8d 00 00 00                   | (JMP rel32) = E9 cd
cmp edx,60676060h                             # 0053h  | 6   | 81 fa 60 60 67 60                | (CMP r/m32, imm32) = 81 /7 id
ja short 0075h                                # 0059h  | 2   | 77 1a                            | (JA rel8) = 77 cb
cmp edx,40404049h                             # 005bh  | 6   | 81 fa 49 40 40 40                | (CMP r/m32, imm32) = 81 /7 id
je short 00a8h                                # 0061h  | 2   | 74 45                            | (JE rel8) = 74 cb
cmp edx,50595050h                             # 0063h  | 6   | 81 fa 50 50 59 50                | (CMP r/m32, imm32) = 81 /7 id
je short 00afh                                # 0069h  | 2   | 74 44                            | (JE rel8) = 74 cb
cmp edx,60676060h                             # 006bh  | 6   | 81 fa 60 60 67 60                | (CMP r/m32, imm32) = 81 /7 id
je short 00b6h                                # 0071h  | 2   | 74 43                            | (JE rel8) = 74 cb
jmp short 00e0h                               # 0073h  | 2   | eb 6b                            | (JMP rel8) = EB cb
cmp edx,70707070h                             # 0075h  | 6   | 81 fa 70 70 70 70                | (CMP r/m32, imm32) = 81 /7 id
je short 00bdh                                # 007bh  | 2   | 74 40                            | (JE rel8) = 74 cb
cmp edx,0b7bcb0b0h                            # 007dh  | 6   | 81 fa b0 b0 bc b7                | (CMP r/m32, imm32) = 81 /7 id
je short 00d2h                                # 0083h  | 2   | 74 4d                            | (JE rel8) = 74 cb
cmp edx,0c9c0c0c1h                            # 0085h  | 6   | 81 fa c1 c0 c0 c9                | (CMP r/m32, imm32) = 81 /7 id
je short 00d9h                                # 008bh  | 2   | 74 4c                            | (JE rel8) = 74 cb
jmp short 00e0h                               # 008dh  | 2   | eb 51                            | (JMP rel8) = EB cb
mov eax,11h                                   # 008fh  | 5   | b8 11 00 00 00                   | (MOV r32, imm32) = B8 +rd id
ret                                           # 0094h  | 1   | c3                               | (RET) = C3
mov eax,22h                                   # 0095h  | 5   | b8 22 00 00 00                   | (MOV r32, imm32) = B8 +rd id
ret                                           # 009ah  | 1   | c3                               | (RET) = C3
mov eax,33h                                   # 009bh  | 5   | b8 33 00 00 00                   | (MOV r32, imm32) = B8 +rd id
ret                                           # 00a0h  | 1   | c3                               | (RET) = C3
mov eax,44h                                   # 00a1h  | 5   | b8 44 00 00 00                   | (MOV r32, imm32) = B8 +rd id
jmp short 00e2h                               # 00a6h  | 2   | eb 3a                            | (JMP rel8) = EB cb
mov eax,55h                                   # 00a8h  | 5   | b8 55 00 00 00                   | (MOV r32, imm32) = B8 +rd id
jmp short 00e2h                               # 00adh  | 2   | eb 33                            | (JMP rel8) = EB cb
mov eax,66h                                   # 00afh  | 5   | b8 66 00 00 00                   | (MOV r32, imm32) = B8 +rd id
jmp short 00e2h                               # 00b4h  | 2   | eb 2c                            | (JMP rel8) = EB cb
mov eax,77h                                   # 00b6h  | 5   | b8 77 00 00 00                   | (MOV r32, imm32) = B8 +rd id
jmp short 00e2h                               # 00bbh  | 2   | eb 25                            | (JMP rel8) = EB cb
mov eax,88h                                   # 00bdh  | 5   | b8 88 00 00 00                   | (MOV r32, imm32) = B8 +rd id
jmp short 00e2h                               # 00c2h  | 2   | eb 1e                            | (JMP rel8) = EB cb
mov eax,99h                                   # 00c4h  | 5   | b8 99 00 00 00                   | (MOV r32, imm32) = B8 +rd id
jmp short 00e2h                               # 00c9h  | 2   | eb 17                            | (JMP rel8) = EB cb
mov eax,0aah                                  # 00cbh  | 5   | b8 aa 00 00 00                   | (MOV r32, imm32) = B8 +rd id
jmp short 00e2h                               # 00d0h  | 2   | eb 10                            | (JMP rel8) = EB cb
mov eax,0bbh                                  # 00d2h  | 5   | b8 bb 00 00 00                   | (MOV r32, imm32) = B8 +rd id
jmp short 00e2h                               # 00d7h  | 2   | eb 09                            | (JMP rel8) = EB cb
mov eax,0cch                                  # 00d9h  | 5   | b8 cc 00 00 00                   | (MOV r32, imm32) = B8 +rd id
jmp short 00e2h                               # 00deh  | 2   | eb 02                            | (JMP rel8) = EB cb
xor eax,eax                                   # 00e0h  | 2   | 33 c0                            | (XOR r32, r/m32) = 33 /r
movzx eax,ax                                  # 00e2h  | 3   | 0f b7 c0                         | (MOVZX r32, r/m16) = 0F B7 /r
ret                                           # 00e5h  | 1   | c3                               | (RET) = C3