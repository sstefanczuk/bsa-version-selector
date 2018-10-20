using System.Diagnostics;

namespace BSA.VersionSelector.Domain
{
    public class ConfigSelector
    {
        private readonly string _path;

        public ConfigSelector(string path)
        {
            _path = path;
        }

        public void Run()
        {
            Process.Start(_path);
        }
    }
}
