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
		var manifest = new AssetsManifest();

		var asset = new ExpanseAsset("Capsule");
		manifest.addPlacibleAsset( asset );
		asset = new ExpanseAsset("Sphere");
		manifest.addPlacibleAsset( asset );

		var jsonString =  serialize(typeof(AssetsManifest), manifest);
		
//		Debug.Log(manifest);
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
