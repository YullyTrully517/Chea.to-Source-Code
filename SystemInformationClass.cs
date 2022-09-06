using System;

namespace CheatoClient
{
	// Token: 0x02000016 RID: 22
	public enum SystemInformationClass
	{
		// Token: 0x040001DF RID: 479
		SystemBasicInformation,
		// Token: 0x040001E0 RID: 480
		SystemProcessorInformation,
		// Token: 0x040001E1 RID: 481
		SystemPerformanceInformation,
		// Token: 0x040001E2 RID: 482
		SystemTimeOfDayInformation,
		// Token: 0x040001E3 RID: 483
		SystemPathInformation,
		// Token: 0x040001E4 RID: 484
		SystemProcessInformation,
		// Token: 0x040001E5 RID: 485
		SystemCallCountInformation,
		// Token: 0x040001E6 RID: 486
		SystemDeviceInformation,
		// Token: 0x040001E7 RID: 487
		SystemProcessorPerformanceInformation,
		// Token: 0x040001E8 RID: 488
		SystemFlagsInformation,
		// Token: 0x040001E9 RID: 489
		SystemCallTimeInformation,
		// Token: 0x040001EA RID: 490
		SystemModuleInformation,
		// Token: 0x040001EB RID: 491
		SystemLocksInformation,
		// Token: 0x040001EC RID: 492
		SystemStackTraceInformation,
		// Token: 0x040001ED RID: 493
		SystemPagedPoolInformation,
		// Token: 0x040001EE RID: 494
		SystemNonPagedPoolInformation,
		// Token: 0x040001EF RID: 495
		SystemHandleInformation,
		// Token: 0x040001F0 RID: 496
		SystemObjectInformation,
		// Token: 0x040001F1 RID: 497
		SystemPageFileInformation,
		// Token: 0x040001F2 RID: 498
		SystemVdmInstemulInformation,
		// Token: 0x040001F3 RID: 499
		SystemVdmBopInformation,
		// Token: 0x040001F4 RID: 500
		SystemFileCacheInformation,
		// Token: 0x040001F5 RID: 501
		SystemPoolTagInformation,
		// Token: 0x040001F6 RID: 502
		SystemInterruptInformation,
		// Token: 0x040001F7 RID: 503
		SystemDpcBehaviorInformation,
		// Token: 0x040001F8 RID: 504
		SystemFullMemoryInformation,
		// Token: 0x040001F9 RID: 505
		SystemLoadGdiDriverInformation,
		// Token: 0x040001FA RID: 506
		SystemUnloadGdiDriverInformation,
		// Token: 0x040001FB RID: 507
		SystemTimeAdjustmentInformation,
		// Token: 0x040001FC RID: 508
		SystemSummaryMemoryInformation,
		// Token: 0x040001FD RID: 509
		SystemMirrorMemoryInformation,
		// Token: 0x040001FE RID: 510
		SystemPerformanceTraceInformation,
		// Token: 0x040001FF RID: 511
		SystemObsolete0,
		// Token: 0x04000200 RID: 512
		SystemExceptionInformation,
		// Token: 0x04000201 RID: 513
		SystemCrashDumpStateInformation,
		// Token: 0x04000202 RID: 514
		SystemKernelDebuggerInformation,
		// Token: 0x04000203 RID: 515
		SystemContextSwitchInformation,
		// Token: 0x04000204 RID: 516
		SystemRegistryQuotaInformation,
		// Token: 0x04000205 RID: 517
		SystemExtendServiceTableInformation,
		// Token: 0x04000206 RID: 518
		SystemPrioritySeperation,
		// Token: 0x04000207 RID: 519
		SystemVerifierAddDriverInformation,
		// Token: 0x04000208 RID: 520
		SystemVerifierRemoveDriverInformation,
		// Token: 0x04000209 RID: 521
		SystemProcessorIdleInformation,
		// Token: 0x0400020A RID: 522
		SystemLegacyDriverInformation,
		// Token: 0x0400020B RID: 523
		SystemCurrentTimeZoneInformation,
		// Token: 0x0400020C RID: 524
		SystemLookasideInformation,
		// Token: 0x0400020D RID: 525
		SystemTimeSlipNotification,
		// Token: 0x0400020E RID: 526
		SystemSessionCreate,
		// Token: 0x0400020F RID: 527
		SystemSessionDetach,
		// Token: 0x04000210 RID: 528
		SystemSessionInformation,
		// Token: 0x04000211 RID: 529
		SystemRangeStartInformation,
		// Token: 0x04000212 RID: 530
		SystemVerifierInformation,
		// Token: 0x04000213 RID: 531
		SystemVerifierThunkExtend,
		// Token: 0x04000214 RID: 532
		SystemSessionProcessInformation,
		// Token: 0x04000215 RID: 533
		SystemLoadGdiDriverInSystemSpace,
		// Token: 0x04000216 RID: 534
		SystemNumaProcessorMap,
		// Token: 0x04000217 RID: 535
		SystemPrefetcherInformation,
		// Token: 0x04000218 RID: 536
		SystemExtendedProcessInformation,
		// Token: 0x04000219 RID: 537
		SystemRecommendedSharedDataAlignment,
		// Token: 0x0400021A RID: 538
		SystemComPlusPackage,
		// Token: 0x0400021B RID: 539
		SystemNumaAvailableMemory,
		// Token: 0x0400021C RID: 540
		SystemProcessorPowerInformation,
		// Token: 0x0400021D RID: 541
		SystemEmulationBasicInformation,
		// Token: 0x0400021E RID: 542
		SystemEmulationProcessorInformation,
		// Token: 0x0400021F RID: 543
		SystemExtendedHandleInformation,
		// Token: 0x04000220 RID: 544
		SystemLostDelayedWriteInformation,
		// Token: 0x04000221 RID: 545
		SystemBigPoolInformation,
		// Token: 0x04000222 RID: 546
		SystemSessionPoolTagInformation,
		// Token: 0x04000223 RID: 547
		SystemSessionMappedViewInformation,
		// Token: 0x04000224 RID: 548
		SystemHotpatchInformation,
		// Token: 0x04000225 RID: 549
		SystemObjectSecurityMode,
		// Token: 0x04000226 RID: 550
		SystemWatchdogTimerHandler,
		// Token: 0x04000227 RID: 551
		SystemWatchdogTimerInformation,
		// Token: 0x04000228 RID: 552
		SystemLogicalProcessorInformation,
		// Token: 0x04000229 RID: 553
		SystemWow64SharedInformationObsolete,
		// Token: 0x0400022A RID: 554
		SystemRegisterFirmwareTableInformationHandler,
		// Token: 0x0400022B RID: 555
		SystemFirmwareTableInformation,
		// Token: 0x0400022C RID: 556
		SystemModuleInformationEx,
		// Token: 0x0400022D RID: 557
		SystemVerifierTriageInformation,
		// Token: 0x0400022E RID: 558
		SystemSuperfetchInformation,
		// Token: 0x0400022F RID: 559
		SystemMemoryListInformation,
		// Token: 0x04000230 RID: 560
		SystemFileCacheInformationEx,
		// Token: 0x04000231 RID: 561
		SystemThreadPriorityClientIdInformation,
		// Token: 0x04000232 RID: 562
		SystemProcessorIdleCycleTimeInformation,
		// Token: 0x04000233 RID: 563
		SystemVerifierCancellationInformation,
		// Token: 0x04000234 RID: 564
		SystemProcessorPowerInformationEx,
		// Token: 0x04000235 RID: 565
		SystemRefTraceInformation,
		// Token: 0x04000236 RID: 566
		SystemSpecialPoolInformation,
		// Token: 0x04000237 RID: 567
		SystemProcessIdInformation,
		// Token: 0x04000238 RID: 568
		SystemErrorPortInformation,
		// Token: 0x04000239 RID: 569
		SystemBootEnvironmentInformation,
		// Token: 0x0400023A RID: 570
		SystemHypervisorInformation,
		// Token: 0x0400023B RID: 571
		SystemVerifierInformationEx,
		// Token: 0x0400023C RID: 572
		SystemTimeZoneInformation,
		// Token: 0x0400023D RID: 573
		SystemImageFileExecutionOptionsInformation,
		// Token: 0x0400023E RID: 574
		SystemCoverageInformation,
		// Token: 0x0400023F RID: 575
		SystemPrefetchPatchInformation,
		// Token: 0x04000240 RID: 576
		SystemVerifierFaultsInformation,
		// Token: 0x04000241 RID: 577
		SystemSystemPartitionInformation,
		// Token: 0x04000242 RID: 578
		SystemSystemDiskInformation,
		// Token: 0x04000243 RID: 579
		SystemProcessorPerformanceDistribution,
		// Token: 0x04000244 RID: 580
		SystemNumaProximityNodeInformation,
		// Token: 0x04000245 RID: 581
		SystemDynamicTimeZoneInformation,
		// Token: 0x04000246 RID: 582
		SystemCodeIntegrityInformation,
		// Token: 0x04000247 RID: 583
		SystemProcessorMicrocodeUpdateInformation,
		// Token: 0x04000248 RID: 584
		SystemProcessorBrandString,
		// Token: 0x04000249 RID: 585
		SystemVirtualAddressInformation,
		// Token: 0x0400024A RID: 586
		SystemLogicalProcessorAndGroupInformation,
		// Token: 0x0400024B RID: 587
		SystemProcessorCycleTimeInformation,
		// Token: 0x0400024C RID: 588
		SystemStoreInformation,
		// Token: 0x0400024D RID: 589
		SystemRegistryAppendString,
		// Token: 0x0400024E RID: 590
		SystemAitSamplingValue,
		// Token: 0x0400024F RID: 591
		SystemVhdBootInformation,
		// Token: 0x04000250 RID: 592
		SystemCpuQuotaInformation,
		// Token: 0x04000251 RID: 593
		SystemNativeBasicInformation,
		// Token: 0x04000252 RID: 594
		SystemSpare1,
		// Token: 0x04000253 RID: 595
		SystemLowPriorityIoInformation,
		// Token: 0x04000254 RID: 596
		SystemTpmBootEntropyInformation,
		// Token: 0x04000255 RID: 597
		SystemVerifierCountersInformation,
		// Token: 0x04000256 RID: 598
		SystemPagedPoolInformationEx,
		// Token: 0x04000257 RID: 599
		SystemSystemPtesInformationEx,
		// Token: 0x04000258 RID: 600
		SystemNodeDistanceInformation,
		// Token: 0x04000259 RID: 601
		SystemAcpiAuditInformation,
		// Token: 0x0400025A RID: 602
		SystemBasicPerformanceInformation,
		// Token: 0x0400025B RID: 603
		SystemQueryPerformanceCounterInformation,
		// Token: 0x0400025C RID: 604
		SystemSessionBigPoolInformation,
		// Token: 0x0400025D RID: 605
		SystemBootGraphicsInformation,
		// Token: 0x0400025E RID: 606
		SystemScrubPhysicalMemoryInformation,
		// Token: 0x0400025F RID: 607
		SystemBadPageInformation,
		// Token: 0x04000260 RID: 608
		SystemProcessorProfileControlArea,
		// Token: 0x04000261 RID: 609
		SystemCombinePhysicalMemoryInformation,
		// Token: 0x04000262 RID: 610
		SystemEntropyInterruptTimingCallback,
		// Token: 0x04000263 RID: 611
		SystemConsoleInformation,
		// Token: 0x04000264 RID: 612
		SystemPlatformBinaryInformation,
		// Token: 0x04000265 RID: 613
		SystemThrottleNotificationInformation,
		// Token: 0x04000266 RID: 614
		SystemHypervisorProcessorCountInformation,
		// Token: 0x04000267 RID: 615
		SystemDeviceDataInformation,
		// Token: 0x04000268 RID: 616
		SystemDeviceDataEnumerationInformation,
		// Token: 0x04000269 RID: 617
		SystemMemoryTopologyInformation,
		// Token: 0x0400026A RID: 618
		SystemMemoryChannelInformation,
		// Token: 0x0400026B RID: 619
		SystemBootLogoInformation,
		// Token: 0x0400026C RID: 620
		SystemProcessorPerformanceInformationEx,
		// Token: 0x0400026D RID: 621
		SystemSpare0,
		// Token: 0x0400026E RID: 622
		SystemSecureBootPolicyInformation,
		// Token: 0x0400026F RID: 623
		SystemPageFileInformationEx,
		// Token: 0x04000270 RID: 624
		SystemSecureBootInformation,
		// Token: 0x04000271 RID: 625
		SystemEntropyInterruptTimingRawInformation,
		// Token: 0x04000272 RID: 626
		SystemPortableWorkspaceEfiLauncherInformation,
		// Token: 0x04000273 RID: 627
		SystemFullProcessInformation,
		// Token: 0x04000274 RID: 628
		SystemKernelDebuggerInformationEx,
		// Token: 0x04000275 RID: 629
		SystemBootMetadataInformation,
		// Token: 0x04000276 RID: 630
		SystemSoftRebootInformation,
		// Token: 0x04000277 RID: 631
		SystemElamCertificateInformation,
		// Token: 0x04000278 RID: 632
		SystemOfflineDumpConfigInformation,
		// Token: 0x04000279 RID: 633
		SystemProcessorFeaturesInformation,
		// Token: 0x0400027A RID: 634
		SystemRegistryReconciliationInformation,
		// Token: 0x0400027B RID: 635
		SystemEdidInformation,
		// Token: 0x0400027C RID: 636
		MaxSystemInfoClass
	}
}
