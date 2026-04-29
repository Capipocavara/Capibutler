using System.IO;
using UnityEngine;

namespace Capibutler.Editor.Utils
{
    public static class PathUtils
    {
        private const string PackageName = "de.capipocavara.capibutler";
        private const string PackageFolder = "Capibutler";
        public static string ApplicationProjectPath => Directory.GetParent(Application.dataPath)?.FullName ?? Application.dataPath;
        public static string DefaultSavePath => Path.Combine(Application.dataPath, PackageFolder).Replace("\\", "/");
        public static string ProjectPathToFullPath(string relativePath) => Path.GetFullPath(Path.Combine(ApplicationProjectPath, relativePath.Trim('\\', '/', ' ')));
        public static string PersistentDataPathToFullPath(string relativePath) => Path.GetFullPath(Path.Combine(Application.persistentDataPath, relativePath.Trim('\\', '/', ' ')));
        public static string PackagePath(string relativePath) => Path.Combine($"Packages/{PackageName}", relativePath.Trim('\\', '/', ' ')).Replace("\\", "/");
        public static string AssetPathToNamespace(string relativePath) => Path.GetRelativePath(Application.dataPath, relativePath.Trim('\\', '/', ' ')).Replace("\\", "/").Replace("/", ".");
        public static string AssetPathToProjectPath(string relativePath) => Path.GetRelativePath(ApplicationProjectPath, Path.Combine("Assets", relativePath.Trim('\\', '/', ' ')));

        public static string CapibutlerAssetPath(string relativePath)
        {
            var path = Path.Combine(Path.GetFullPath(SettingsUtils.GetString("SavePath", DefaultSavePath)), relativePath.Trim('\\', '/', ' ')).Replace("\\", "/");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            return path;
        }
    }
}