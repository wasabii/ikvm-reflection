// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using IKVM.Reflection.TypeLoading;

namespace IKVM.Reflection
{
    internal abstract partial class NameFilter
    {
        protected NameFilter(string expectedName)
        {
            ExpectedName = expectedName;
        }

        public abstract bool Matches(string name);
        protected string ExpectedName { get; }
    }

    internal sealed partial class NameFilterCaseSensitive : NameFilter
    {
        private readonly byte[] _expectedNameUtf8;

        public NameFilterCaseSensitive(string expectedName)
            : base(expectedName)
        {
            _expectedNameUtf8 = expectedName.ToUtf8();
        }

        public sealed override bool Matches(string name) => name.Equals(ExpectedName, StringComparison.Ordinal);
    }

    internal sealed partial class NameFilterCaseInsensitive : NameFilter
    {
        public NameFilterCaseInsensitive(string expectedName)
            : base(expectedName)
        {
        }

        public sealed override bool Matches(string name) => name.Equals(ExpectedName, StringComparison.OrdinalIgnoreCase);
    }
}
