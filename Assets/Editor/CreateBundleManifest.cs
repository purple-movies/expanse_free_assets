using UnityEditor;
using UnityEngine;
using System.Collections;
using System.IO;
using System;
using FullSerializer;

public class CreateBundleManifest
{
	private static readonly fsSerializer serializer = new fsSerializer();

	[MenuItem ("Assets/Create Bundle Manifest")]
	public static void createBundleManifest()
	{
		var manifest1 = new AssetsManifest();
		var asset = new ExpanseAsset("Capsule");
		manifest1.addPlacibleAsset( asset );
		asset = new ExpanseAsset("Sphere");
		manifest1.addPlacibleAsset( asset );
		var jsonString =  serialize(typeof(AssetsManifest), manifest1);
		Debug.Log(jsonString);

		var manifest2 = new AssetsManifest();
		asset = new ExpanseAsset("Cylinder");
		manifest2.addPlacibleAsset(asset);
		jsonString = serialize(typeof(AssetsManifest), manifest2);
		Debug.Log(jsonString);

		Debug.Log("stuff :: " + Application.dataPath);


		File.WriteAllText(Application.dataPath + @"/assets_to_bundle", jsonString);
//		File.WriteAllText(@"C:\", jsonString);
//		
	}
	
	static string serialize(Type type, object value)
	{
		fsData data;
		serializer.TrySerialize(type, value, out data).AssertSuccessWithoutWarnings();
		return fsJsonPrinter.CompressedJson(data);
	}
}
