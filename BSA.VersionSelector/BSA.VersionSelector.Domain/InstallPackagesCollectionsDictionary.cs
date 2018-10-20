using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BSA.VersionSelector.Domain
{
    public class InstallPackagesCollectionsDictionary : ReadOnlyDictionary<EnvironmentType, InstallPackagesCollection>
    {
        public InstallPackagesCollectionsDictionary(string installPackagesPath, IEnumerable<EnvironmentType> environmentsToLoad)
            : base(CreateDictionary(installPackagesPath, environmentsToLoad))
        {
        }

        private static IDictionary<EnvironmentType, InstallPackagesCollection> CreateDictionary(string installPackagesPath, IEnumerable<EnvironmentType> environmentsToLoad)
        {
            var dictionary = new Dictionary<EnvironmentType, InstallPackagesCollection>();

            foreach (EnvironmentType environmentType in environmentsToLoad)
            {
                dictionary.Add(environmentType, new InstallPackagesCollection(installPackagesPath, environmentType));
            }

            return dictionary;
        }
    }
}
