#if UNITY_EDITOR
using System.IO;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;

namespace Jp.Nobnak.HeadSway.Editor
{
    static class HeadSwaySampleSync
    {
        const string SourceRel = "Assets/Samples/HeadSway";
        const string DestRel = "Packages/jp.nobnak.headsway/Samples~/HeadSway";

        [MenuItem("jp.nobnak.headsway/Sync Samples to Package")]
        public static void SyncFromMenu() => Sync();

        public static void Sync()
        {
            var src = Path.GetFullPath(SourceRel);
            if (!Directory.Exists(src)) {
                Debug.LogWarning($"[HeadSway] Sample source not found: {SourceRel}");
                return;
            }
            var dst = Path.GetFullPath(DestRel);
            Directory.CreateDirectory(dst);
            ClearDirectory(dst);
            CopyDirectory(src, dst);
            AssetDatabase.Refresh();
            Debug.Log($"[HeadSway] Synced samples: {SourceRel} -> {DestRel}");
        }

        static void ClearDirectory(string path)
        {
            foreach (var entry in Directory.EnumerateFileSystemEntries(path)) {
                if (Directory.Exists(entry))
                    Directory.Delete(entry, true);
                else
                    File.Delete(entry);
            }
        }

        static void CopyDirectory(string src, string dst)
        {
            foreach (var dir in Directory.GetDirectories(src, "*", SearchOption.AllDirectories))
                Directory.CreateDirectory(dir.Replace(src, dst));
            foreach (var file in Directory.GetFiles(src, "*", SearchOption.AllDirectories))
                File.Copy(file, file.Replace(src, dst), true);
        }
    }

    sealed class HeadSwaySampleSyncBuild : IPreprocessBuildWithReport
    {
        public int callbackOrder => 0;
        public void OnPreprocessBuild(BuildReport report) => HeadSwaySampleSync.Sync();
    }
}
#endif
