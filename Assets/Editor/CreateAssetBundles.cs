using UnityEditor;

public class CreateAssetBundles
{
	[MenuItem ("Assets/Build AssetBundles")]
	static void BuildAllAssetBundles ()
	{
        var options = new BuildAssetBundleOptions();
		BuildPipeline.BuildAssetBundles("asset_bundles", options, BuildTarget.StandaloneWindows64);
	}
}
