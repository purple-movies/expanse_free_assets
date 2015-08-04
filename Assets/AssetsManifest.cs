using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class AssetsManifest
{
//	ulong currentAssetIndex = 0;

	[SerializeField]
	public List<ExpanseAsset> placiblePrefabs = new List<ExpanseAsset>();

	Dictionary<string, ExpanseAsset> nameToAssetMap = new Dictionary<string, ExpanseAsset>();
	Dictionary<NetworkHash128, ExpanseAsset> netIdToAssetMap = new Dictionary<NetworkHash128, ExpanseAsset>();

	public void addPlacibleAsset(ExpanseAsset asset)
	{
		placiblePrefabs.Add( asset );
	}

	public void addAsset(ExpanseAsset asset)
	{
		if (asset.name == null) throw new UnityException("Trying to add an asset with out an asset name.");
		if ( ! asset.networkAssetId.IsValid()) throw new UnityException("Trying to add an asset without a network asset ID");

//		placiblePrefabs.
		nameToAssetMap.Add(asset.name, asset);
		netIdToAssetMap.Add(asset.networkAssetId, asset);
	}

	public void setAssetNameReference(string name, ExpanseAsset asset)
	{
		nameToAssetMap.Add(name, asset);
	}

	public ExpanseAsset getAsset(string name)
	{
		return nameToAssetMap[ name ]; 
	}

	public ExpanseAsset getAsset(NetworkHash128 assetId)
	{
		return netIdToAssetMap[ assetId ];
	}
}

public class ExpanseAsset
{
	public string name;
	public NetworkHash128 networkAssetId;
	public GameObject prefab;

	public ExpanseAsset(){ }

	public ExpanseAsset(string name, NetworkHash128 networkAssetId, GameObject assetPrefab)
	{
		this.name = name;
		this.networkAssetId = networkAssetId;
		prefab = assetPrefab;
	}

	public ExpanseAsset(string name)
	{
		this.name = name;
	}

	public void setAsset(GameObject asset)
	{
		prefab = asset;
	}

	public GameObject getAsset()
	{
		return prefab;
	}
}
