// Guids.cs
// MUST match guids.h
using System;

namespace VSPackage.UTAssistant
{
    static class GuidList
    {
        public const string guidUTPkgString = "e4617127-5dac-4baf-848b-686d6ec68ea4";
        public const string guidUTCmdSetString = "b89a1588-591b-401c-a1ad-26fce0634678";

        public static readonly Guid guidUTCmdSet = new Guid(guidUTCmdSetString);
    };
}