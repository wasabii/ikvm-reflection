// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace IKVM.Reflection.TypeLoading
{
#pragma warning disable IDE0065
    // This disambiguating "using" must be inside the "namespace" or else we'll pick up the wrong AssemblyHashAlgorithm.
    using AssemblyHashAlgorithm = System.Configuration.Assemblies.AssemblyHashAlgorithm;
#pragma warning restore IDE0065

    //
    // Collects together everything needed to generate an AssemblyName quickly. We don't want to do all the metadata analysis every time
    // GetName() is called.
    //
    internal sealed class AssemblyNameData
    {
        public AssemblyNameFlags Flags;
        public string? Name;
        public Version? Version;
        public string? CultureName;
        public byte[]? PublicKey;
        public byte[]? PublicKeyToken;
        public AssemblyContentType ContentType;
        public AssemblyHashAlgorithm HashAlgorithm;
        public ProcessorArchitecture ProcessorArchitecture;

        // Creates a newly allocated AssemblyName that is safe to return out of an api.
        public AssemblyName CreateAssemblyName()
        {
            AssemblyName an = new AssemblyName
            {
                Flags = Flags,
                Name = Name,
                Version = Version,
                CultureName = CultureName,
                ContentType = ContentType,
#pragma warning disable SYSLIB0037 // AssemblyName members HashAlgorithm and ProcessorArchitecture are obsolete
                HashAlgorithm = HashAlgorithm,
                ProcessorArchitecture = ProcessorArchitecture
#pragma warning restore
            };

            // Yes, *we* have to clone the array. AssemblyName.SetPublicKey() violates framework guidelines and doesn't make a copy.
            an.SetPublicKey(PublicKey.CloneArray());
            an.SetPublicKeyToken(PublicKeyToken.CloneArray());
            return an;
        }
    }
}
