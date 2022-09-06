using System;

namespace CheatoClient
{
	// Token: 0x02000014 RID: 20
	public enum NtStatus : uint
	{
		// Token: 0x04000054 RID: 84
		Success,
		// Token: 0x04000055 RID: 85
		Wait0 = 0U,
		// Token: 0x04000056 RID: 86
		Wait1,
		// Token: 0x04000057 RID: 87
		Wait2,
		// Token: 0x04000058 RID: 88
		Wait3,
		// Token: 0x04000059 RID: 89
		Wait63 = 63U,
		// Token: 0x0400005A RID: 90
		Abandoned = 128U,
		// Token: 0x0400005B RID: 91
		AbandonedWait0 = 128U,
		// Token: 0x0400005C RID: 92
		AbandonedWait1,
		// Token: 0x0400005D RID: 93
		AbandonedWait2,
		// Token: 0x0400005E RID: 94
		AbandonedWait3,
		// Token: 0x0400005F RID: 95
		AbandonedWait63 = 191U,
		// Token: 0x04000060 RID: 96
		UserApc,
		// Token: 0x04000061 RID: 97
		KernelApc = 256U,
		// Token: 0x04000062 RID: 98
		Alerted,
		// Token: 0x04000063 RID: 99
		Timeout,
		// Token: 0x04000064 RID: 100
		Pending,
		// Token: 0x04000065 RID: 101
		Reparse,
		// Token: 0x04000066 RID: 102
		MoreEntries,
		// Token: 0x04000067 RID: 103
		NotAllAssigned,
		// Token: 0x04000068 RID: 104
		SomeNotMapped,
		// Token: 0x04000069 RID: 105
		OpLockBreakInProgress,
		// Token: 0x0400006A RID: 106
		VolumeMounted,
		// Token: 0x0400006B RID: 107
		RxActCommitted,
		// Token: 0x0400006C RID: 108
		NotifyCleanup,
		// Token: 0x0400006D RID: 109
		NotifyEnumDir,
		// Token: 0x0400006E RID: 110
		NoQuotasForAccount,
		// Token: 0x0400006F RID: 111
		PrimaryTransportConnectFailed,
		// Token: 0x04000070 RID: 112
		PageFaultTransition = 272U,
		// Token: 0x04000071 RID: 113
		PageFaultDemandZero,
		// Token: 0x04000072 RID: 114
		PageFaultCopyOnWrite,
		// Token: 0x04000073 RID: 115
		PageFaultGuardPage,
		// Token: 0x04000074 RID: 116
		PageFaultPagingFile,
		// Token: 0x04000075 RID: 117
		CrashDump = 278U,
		// Token: 0x04000076 RID: 118
		ReparseObject = 280U,
		// Token: 0x04000077 RID: 119
		NothingToTerminate = 290U,
		// Token: 0x04000078 RID: 120
		ProcessNotInJob,
		// Token: 0x04000079 RID: 121
		ProcessInJob,
		// Token: 0x0400007A RID: 122
		ProcessCloned = 297U,
		// Token: 0x0400007B RID: 123
		FileLockedWithOnlyReaders,
		// Token: 0x0400007C RID: 124
		FileLockedWithWriters,
		// Token: 0x0400007D RID: 125
		Informational = 1073741824U,
		// Token: 0x0400007E RID: 126
		ObjectNameExists = 1073741824U,
		// Token: 0x0400007F RID: 127
		ThreadWasSuspended,
		// Token: 0x04000080 RID: 128
		WorkingSetLimitRange,
		// Token: 0x04000081 RID: 129
		ImageNotAtBase,
		// Token: 0x04000082 RID: 130
		RegistryRecovered = 1073741833U,
		// Token: 0x04000083 RID: 131
		Warning = 2147483648U,
		// Token: 0x04000084 RID: 132
		GuardPageViolation,
		// Token: 0x04000085 RID: 133
		DatatypeMisalignment,
		// Token: 0x04000086 RID: 134
		Breakpoint,
		// Token: 0x04000087 RID: 135
		SingleStep,
		// Token: 0x04000088 RID: 136
		BufferOverflow,
		// Token: 0x04000089 RID: 137
		NoMoreFiles,
		// Token: 0x0400008A RID: 138
		HandlesClosed = 2147483658U,
		// Token: 0x0400008B RID: 139
		PartialCopy = 2147483661U,
		// Token: 0x0400008C RID: 140
		DeviceBusy = 2147483665U,
		// Token: 0x0400008D RID: 141
		InvalidEaName = 2147483667U,
		// Token: 0x0400008E RID: 142
		EaListInconsistent,
		// Token: 0x0400008F RID: 143
		NoMoreEntries = 2147483674U,
		// Token: 0x04000090 RID: 144
		LongJump = 2147483686U,
		// Token: 0x04000091 RID: 145
		DllMightBeInsecure = 2147483691U,
		// Token: 0x04000092 RID: 146
		Error = 3221225472U,
		// Token: 0x04000093 RID: 147
		Unsuccessful,
		// Token: 0x04000094 RID: 148
		NotImplemented,
		// Token: 0x04000095 RID: 149
		InvalidInfoClass,
		// Token: 0x04000096 RID: 150
		InfoLengthMismatch,
		// Token: 0x04000097 RID: 151
		AccessViolation,
		// Token: 0x04000098 RID: 152
		InPageError,
		// Token: 0x04000099 RID: 153
		PagefileQuota,
		// Token: 0x0400009A RID: 154
		InvalidHandle,
		// Token: 0x0400009B RID: 155
		BadInitialStack,
		// Token: 0x0400009C RID: 156
		BadInitialPc,
		// Token: 0x0400009D RID: 157
		InvalidCid,
		// Token: 0x0400009E RID: 158
		TimerNotCanceled,
		// Token: 0x0400009F RID: 159
		InvalidParameter,
		// Token: 0x040000A0 RID: 160
		NoSuchDevice,
		// Token: 0x040000A1 RID: 161
		NoSuchFile,
		// Token: 0x040000A2 RID: 162
		InvalidDeviceRequest,
		// Token: 0x040000A3 RID: 163
		EndOfFile,
		// Token: 0x040000A4 RID: 164
		WrongVolume,
		// Token: 0x040000A5 RID: 165
		NoMediaInDevice,
		// Token: 0x040000A6 RID: 166
		NoMemory = 3221225495U,
		// Token: 0x040000A7 RID: 167
		NotMappedView = 3221225497U,
		// Token: 0x040000A8 RID: 168
		UnableToFreeVm,
		// Token: 0x040000A9 RID: 169
		UnableToDeleteSection,
		// Token: 0x040000AA RID: 170
		IllegalInstruction = 3221225501U,
		// Token: 0x040000AB RID: 171
		AlreadyCommitted = 3221225505U,
		// Token: 0x040000AC RID: 172
		AccessDenied,
		// Token: 0x040000AD RID: 173
		BufferTooSmall,
		// Token: 0x040000AE RID: 174
		ObjectTypeMismatch,
		// Token: 0x040000AF RID: 175
		NonContinuableException,
		// Token: 0x040000B0 RID: 176
		BadStack = 3221225512U,
		// Token: 0x040000B1 RID: 177
		NotLocked = 3221225514U,
		// Token: 0x040000B2 RID: 178
		NotCommitted = 3221225517U,
		// Token: 0x040000B3 RID: 179
		InvalidParameterMix = 3221225520U,
		// Token: 0x040000B4 RID: 180
		ObjectNameInvalid = 3221225523U,
		// Token: 0x040000B5 RID: 181
		ObjectNameNotFound,
		// Token: 0x040000B6 RID: 182
		ObjectNameCollision,
		// Token: 0x040000B7 RID: 183
		ObjectPathInvalid = 3221225529U,
		// Token: 0x040000B8 RID: 184
		ObjectPathNotFound,
		// Token: 0x040000B9 RID: 185
		ObjectPathSyntaxBad,
		// Token: 0x040000BA RID: 186
		DataOverrun,
		// Token: 0x040000BB RID: 187
		DataLate,
		// Token: 0x040000BC RID: 188
		DataError,
		// Token: 0x040000BD RID: 189
		CrcError,
		// Token: 0x040000BE RID: 190
		SectionTooBig,
		// Token: 0x040000BF RID: 191
		PortConnectionRefused,
		// Token: 0x040000C0 RID: 192
		InvalidPortHandle,
		// Token: 0x040000C1 RID: 193
		SharingViolation,
		// Token: 0x040000C2 RID: 194
		QuotaExceeded,
		// Token: 0x040000C3 RID: 195
		InvalidPageProtection,
		// Token: 0x040000C4 RID: 196
		MutantNotOwned,
		// Token: 0x040000C5 RID: 197
		SemaphoreLimitExceeded,
		// Token: 0x040000C6 RID: 198
		PortAlreadySet,
		// Token: 0x040000C7 RID: 199
		SectionNotImage,
		// Token: 0x040000C8 RID: 200
		SuspendCountExceeded,
		// Token: 0x040000C9 RID: 201
		ThreadIsTerminating,
		// Token: 0x040000CA RID: 202
		BadWorkingSetLimit,
		// Token: 0x040000CB RID: 203
		IncompatibleFileMap,
		// Token: 0x040000CC RID: 204
		SectionProtection,
		// Token: 0x040000CD RID: 205
		EasNotSupported,
		// Token: 0x040000CE RID: 206
		EaTooLarge,
		// Token: 0x040000CF RID: 207
		NonExistentEaEntry,
		// Token: 0x040000D0 RID: 208
		NoEasOnFile,
		// Token: 0x040000D1 RID: 209
		EaCorruptError,
		// Token: 0x040000D2 RID: 210
		FileLockConflict,
		// Token: 0x040000D3 RID: 211
		LockNotGranted,
		// Token: 0x040000D4 RID: 212
		DeletePending,
		// Token: 0x040000D5 RID: 213
		CtlFileNotSupported,
		// Token: 0x040000D6 RID: 214
		UnknownRevision,
		// Token: 0x040000D7 RID: 215
		RevisionMismatch,
		// Token: 0x040000D8 RID: 216
		InvalidOwner,
		// Token: 0x040000D9 RID: 217
		InvalidPrimaryGroup,
		// Token: 0x040000DA RID: 218
		NoImpersonationToken,
		// Token: 0x040000DB RID: 219
		CantDisableMandatory,
		// Token: 0x040000DC RID: 220
		NoLogonServers,
		// Token: 0x040000DD RID: 221
		NoSuchLogonSession,
		// Token: 0x040000DE RID: 222
		NoSuchPrivilege,
		// Token: 0x040000DF RID: 223
		PrivilegeNotHeld,
		// Token: 0x040000E0 RID: 224
		InvalidAccountName,
		// Token: 0x040000E1 RID: 225
		UserExists,
		// Token: 0x040000E2 RID: 226
		NoSuchUser,
		// Token: 0x040000E3 RID: 227
		GroupExists,
		// Token: 0x040000E4 RID: 228
		NoSuchGroup,
		// Token: 0x040000E5 RID: 229
		MemberInGroup,
		// Token: 0x040000E6 RID: 230
		MemberNotInGroup,
		// Token: 0x040000E7 RID: 231
		LastAdmin,
		// Token: 0x040000E8 RID: 232
		WrongPassword,
		// Token: 0x040000E9 RID: 233
		IllFormedPassword,
		// Token: 0x040000EA RID: 234
		PasswordRestriction,
		// Token: 0x040000EB RID: 235
		LogonFailure,
		// Token: 0x040000EC RID: 236
		AccountRestriction,
		// Token: 0x040000ED RID: 237
		InvalidLogonHours,
		// Token: 0x040000EE RID: 238
		InvalidWorkstation,
		// Token: 0x040000EF RID: 239
		PasswordExpired,
		// Token: 0x040000F0 RID: 240
		AccountDisabled,
		// Token: 0x040000F1 RID: 241
		NoneMapped,
		// Token: 0x040000F2 RID: 242
		TooManyLuidsRequested,
		// Token: 0x040000F3 RID: 243
		LuidsExhausted,
		// Token: 0x040000F4 RID: 244
		InvalidSubAuthority,
		// Token: 0x040000F5 RID: 245
		InvalidAcl,
		// Token: 0x040000F6 RID: 246
		InvalidSid,
		// Token: 0x040000F7 RID: 247
		InvalidSecurityDescr,
		// Token: 0x040000F8 RID: 248
		ProcedureNotFound,
		// Token: 0x040000F9 RID: 249
		InvalidImageFormat,
		// Token: 0x040000FA RID: 250
		NoToken,
		// Token: 0x040000FB RID: 251
		BadInheritanceAcl,
		// Token: 0x040000FC RID: 252
		RangeNotLocked,
		// Token: 0x040000FD RID: 253
		DiskFull,
		// Token: 0x040000FE RID: 254
		ServerDisabled,
		// Token: 0x040000FF RID: 255
		ServerNotDisabled,
		// Token: 0x04000100 RID: 256
		TooManyGuidsRequested,
		// Token: 0x04000101 RID: 257
		GuidsExhausted,
		// Token: 0x04000102 RID: 258
		InvalidIdAuthority,
		// Token: 0x04000103 RID: 259
		AgentsExhausted,
		// Token: 0x04000104 RID: 260
		InvalidVolumeLabel,
		// Token: 0x04000105 RID: 261
		SectionNotExtended,
		// Token: 0x04000106 RID: 262
		NotMappedData,
		// Token: 0x04000107 RID: 263
		ResourceDataNotFound,
		// Token: 0x04000108 RID: 264
		ResourceTypeNotFound,
		// Token: 0x04000109 RID: 265
		ResourceNameNotFound,
		// Token: 0x0400010A RID: 266
		ArrayBoundsExceeded,
		// Token: 0x0400010B RID: 267
		FloatDenormalOperand,
		// Token: 0x0400010C RID: 268
		FloatDivideByZero,
		// Token: 0x0400010D RID: 269
		FloatInexactResult,
		// Token: 0x0400010E RID: 270
		FloatInvalidOperation,
		// Token: 0x0400010F RID: 271
		FloatOverflow,
		// Token: 0x04000110 RID: 272
		FloatStackCheck,
		// Token: 0x04000111 RID: 273
		FloatUnderflow,
		// Token: 0x04000112 RID: 274
		IntegerDivideByZero,
		// Token: 0x04000113 RID: 275
		IntegerOverflow,
		// Token: 0x04000114 RID: 276
		PrivilegedInstruction,
		// Token: 0x04000115 RID: 277
		TooManyPagingFiles,
		// Token: 0x04000116 RID: 278
		FileInvalid,
		// Token: 0x04000117 RID: 279
		InstanceNotAvailable = 3221225643U,
		// Token: 0x04000118 RID: 280
		PipeNotAvailable,
		// Token: 0x04000119 RID: 281
		InvalidPipeState,
		// Token: 0x0400011A RID: 282
		PipeBusy,
		// Token: 0x0400011B RID: 283
		IllegalFunction,
		// Token: 0x0400011C RID: 284
		PipeDisconnected,
		// Token: 0x0400011D RID: 285
		PipeClosing,
		// Token: 0x0400011E RID: 286
		PipeConnected,
		// Token: 0x0400011F RID: 287
		PipeListening,
		// Token: 0x04000120 RID: 288
		InvalidReadMode,
		// Token: 0x04000121 RID: 289
		IoTimeout,
		// Token: 0x04000122 RID: 290
		FileForcedClosed,
		// Token: 0x04000123 RID: 291
		ProfilingNotStarted,
		// Token: 0x04000124 RID: 292
		ProfilingNotStopped,
		// Token: 0x04000125 RID: 293
		NotSameDevice = 3221225684U,
		// Token: 0x04000126 RID: 294
		FileRenamed,
		// Token: 0x04000127 RID: 295
		CantWait = 3221225688U,
		// Token: 0x04000128 RID: 296
		PipeEmpty,
		// Token: 0x04000129 RID: 297
		CantTerminateSelf = 3221225691U,
		// Token: 0x0400012A RID: 298
		InternalError = 3221225701U,
		// Token: 0x0400012B RID: 299
		InvalidParameter1 = 3221225711U,
		// Token: 0x0400012C RID: 300
		InvalidParameter2,
		// Token: 0x0400012D RID: 301
		InvalidParameter3,
		// Token: 0x0400012E RID: 302
		InvalidParameter4,
		// Token: 0x0400012F RID: 303
		InvalidParameter5,
		// Token: 0x04000130 RID: 304
		InvalidParameter6,
		// Token: 0x04000131 RID: 305
		InvalidParameter7,
		// Token: 0x04000132 RID: 306
		InvalidParameter8,
		// Token: 0x04000133 RID: 307
		InvalidParameter9,
		// Token: 0x04000134 RID: 308
		InvalidParameter10,
		// Token: 0x04000135 RID: 309
		InvalidParameter11,
		// Token: 0x04000136 RID: 310
		InvalidParameter12,
		// Token: 0x04000137 RID: 311
		MappedFileSizeZero = 3221225758U,
		// Token: 0x04000138 RID: 312
		TooManyOpenedFiles,
		// Token: 0x04000139 RID: 313
		Cancelled,
		// Token: 0x0400013A RID: 314
		CannotDelete,
		// Token: 0x0400013B RID: 315
		InvalidComputerName,
		// Token: 0x0400013C RID: 316
		FileDeleted,
		// Token: 0x0400013D RID: 317
		SpecialAccount,
		// Token: 0x0400013E RID: 318
		SpecialGroup,
		// Token: 0x0400013F RID: 319
		SpecialUser,
		// Token: 0x04000140 RID: 320
		MembersPrimaryGroup,
		// Token: 0x04000141 RID: 321
		FileClosed,
		// Token: 0x04000142 RID: 322
		TooManyThreads,
		// Token: 0x04000143 RID: 323
		ThreadNotInProcess,
		// Token: 0x04000144 RID: 324
		TokenAlreadyInUse,
		// Token: 0x04000145 RID: 325
		PagefileQuotaExceeded,
		// Token: 0x04000146 RID: 326
		CommitmentLimit,
		// Token: 0x04000147 RID: 327
		InvalidImageLeFormat,
		// Token: 0x04000148 RID: 328
		InvalidImageNotMz,
		// Token: 0x04000149 RID: 329
		InvalidImageProtect,
		// Token: 0x0400014A RID: 330
		InvalidImageWin16,
		// Token: 0x0400014B RID: 331
		LogonServer,
		// Token: 0x0400014C RID: 332
		DifferenceAtDc,
		// Token: 0x0400014D RID: 333
		SynchronizationRequired,
		// Token: 0x0400014E RID: 334
		DllNotFound,
		// Token: 0x0400014F RID: 335
		IoPrivilegeFailed = 3221225783U,
		// Token: 0x04000150 RID: 336
		OrdinalNotFound,
		// Token: 0x04000151 RID: 337
		EntryPointNotFound,
		// Token: 0x04000152 RID: 338
		ControlCExit,
		// Token: 0x04000153 RID: 339
		PortNotSet = 3221226323U,
		// Token: 0x04000154 RID: 340
		DebuggerInactive,
		// Token: 0x04000155 RID: 341
		CallbackBypass = 3221226755U,
		// Token: 0x04000156 RID: 342
		PortClosed = 3221227264U,
		// Token: 0x04000157 RID: 343
		MessageLost,
		// Token: 0x04000158 RID: 344
		InvalidMessage,
		// Token: 0x04000159 RID: 345
		RequestCanceled,
		// Token: 0x0400015A RID: 346
		RecursiveDispatch,
		// Token: 0x0400015B RID: 347
		LpcReceiveBufferExpected,
		// Token: 0x0400015C RID: 348
		LpcInvalidConnectionUsage,
		// Token: 0x0400015D RID: 349
		LpcRequestsNotAllowed,
		// Token: 0x0400015E RID: 350
		ResourceInUse,
		// Token: 0x0400015F RID: 351
		ProcessIsProtected = 3221227282U,
		// Token: 0x04000160 RID: 352
		VolumeDirty = 3221227526U,
		// Token: 0x04000161 RID: 353
		FileCheckedOut = 3221227777U,
		// Token: 0x04000162 RID: 354
		CheckOutRequired,
		// Token: 0x04000163 RID: 355
		BadFileType,
		// Token: 0x04000164 RID: 356
		FileTooLarge,
		// Token: 0x04000165 RID: 357
		FormsAuthRequired,
		// Token: 0x04000166 RID: 358
		VirusInfected,
		// Token: 0x04000167 RID: 359
		VirusDeleted,
		// Token: 0x04000168 RID: 360
		TransactionalConflict = 3222863873U,
		// Token: 0x04000169 RID: 361
		InvalidTransaction,
		// Token: 0x0400016A RID: 362
		TransactionNotActive,
		// Token: 0x0400016B RID: 363
		TmInitializationFailed,
		// Token: 0x0400016C RID: 364
		RmNotActive,
		// Token: 0x0400016D RID: 365
		RmMetadataCorrupt,
		// Token: 0x0400016E RID: 366
		TransactionNotJoined,
		// Token: 0x0400016F RID: 367
		DirectoryNotRm,
		// Token: 0x04000170 RID: 368
		CouldNotResizeLog,
		// Token: 0x04000171 RID: 369
		TransactionsUnsupportedRemote,
		// Token: 0x04000172 RID: 370
		LogResizeInvalidSize,
		// Token: 0x04000173 RID: 371
		RemoteFileVersionMismatch,
		// Token: 0x04000174 RID: 372
		CrmProtocolAlreadyExists = 3222863887U,
		// Token: 0x04000175 RID: 373
		TransactionPropagationFailed,
		// Token: 0x04000176 RID: 374
		CrmProtocolNotFound,
		// Token: 0x04000177 RID: 375
		TransactionSuperiorExists,
		// Token: 0x04000178 RID: 376
		TransactionRequestNotValid,
		// Token: 0x04000179 RID: 377
		TransactionNotRequested,
		// Token: 0x0400017A RID: 378
		TransactionAlreadyAborted,
		// Token: 0x0400017B RID: 379
		TransactionAlreadyCommitted,
		// Token: 0x0400017C RID: 380
		TransactionInvalidMarshallBuffer,
		// Token: 0x0400017D RID: 381
		CurrentTransactionNotValid,
		// Token: 0x0400017E RID: 382
		LogGrowthFailed,
		// Token: 0x0400017F RID: 383
		ObjectNoLongerExists = 3222863905U,
		// Token: 0x04000180 RID: 384
		StreamMiniversionNotFound,
		// Token: 0x04000181 RID: 385
		StreamMiniversionNotValid,
		// Token: 0x04000182 RID: 386
		MiniversionInaccessibleFromSpecifiedTransaction,
		// Token: 0x04000183 RID: 387
		CantOpenMiniversionWithModifyIntent,
		// Token: 0x04000184 RID: 388
		CantCreateMoreStreamMiniversions,
		// Token: 0x04000185 RID: 389
		HandleNoLongerValid = 3222863912U,
		// Token: 0x04000186 RID: 390
		NoTxfMetadata,
		// Token: 0x04000187 RID: 391
		LogCorruptionDetected = 3222863920U,
		// Token: 0x04000188 RID: 392
		CantRecoverWithHandleOpen,
		// Token: 0x04000189 RID: 393
		RmDisconnected,
		// Token: 0x0400018A RID: 394
		EnlistmentNotSuperior,
		// Token: 0x0400018B RID: 395
		RecoveryNotNeeded,
		// Token: 0x0400018C RID: 396
		RmAlreadyStarted,
		// Token: 0x0400018D RID: 397
		FileIdentityNotPersistent,
		// Token: 0x0400018E RID: 398
		CantBreakTransactionalDependency,
		// Token: 0x0400018F RID: 399
		CantCrossRmBoundary,
		// Token: 0x04000190 RID: 400
		TxfDirNotEmpty,
		// Token: 0x04000191 RID: 401
		IndoubtTransactionsExist,
		// Token: 0x04000192 RID: 402
		TmVolatile,
		// Token: 0x04000193 RID: 403
		RollbackTimerExpired,
		// Token: 0x04000194 RID: 404
		TxfAttributeCorrupt,
		// Token: 0x04000195 RID: 405
		EfsNotAllowedInTransaction,
		// Token: 0x04000196 RID: 406
		TransactionalOpenNotAllowed,
		// Token: 0x04000197 RID: 407
		TransactedMappingUnsupportedRemote,
		// Token: 0x04000198 RID: 408
		TxfMetadataAlreadyPresent,
		// Token: 0x04000199 RID: 409
		TransactionScopeCallbacksNotSet,
		// Token: 0x0400019A RID: 410
		TransactionRequiredPromotion,
		// Token: 0x0400019B RID: 411
		CannotExecuteFileInTransaction,
		// Token: 0x0400019C RID: 412
		TransactionsNotFrozen,
		// Token: 0x0400019D RID: 413
		MaximumNtStatus = 4294967295U
	}
}
