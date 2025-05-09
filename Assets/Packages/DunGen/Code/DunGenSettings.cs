﻿#if UNITY_EDITOR
using UnityEditor;
#endif
using System.IO;
using System.Linq;
using UnityEngine;
using DunGen.Tags;

namespace DunGen
{
	public sealed class DunGenSettings : ScriptableObject
	{
		#region Singleton

		private static DunGenSettings instance;
		public static DunGenSettings Instance
		{
			get
			{
				if (instance != null)
					return instance;
				else
				{
					instance = FindOrCreateInstanceAsset();
					return instance;
				}
			}
		}

		public static DunGenSettings FindOrCreateInstanceAsset()
		{
			// Try to find an existing instance in a resource folder
			instance = Resources.Load<DunGenSettings>("DunGen Settings");

			// Create a new instance if one is not found
			if (instance == null)
			{
#if UNITY_EDITOR
				instance = CreateInstance<DunGenSettings>();

				if (!Directory.Exists(Application.dataPath + "/Resources"))
					AssetDatabase.CreateFolder("Assets", "Resources");

				AssetDatabase.CreateAsset(instance, "Assets/Resources/DunGen Settings.asset");
				instance.defaultSocket = instance.GetOrAddSocketByName("Default");
#else
				throw new System.Exception("No instance of DunGen settings was found.");
#endif
			}

			return instance;
		}

		#endregion

		public DoorwaySocket DefaultSocket { get { return defaultSocket; } }
		public TagManager TagManager { get { return tagManager; } }

		[SerializeField]
		private DoorwaySocket defaultSocket = null;

		[SerializeField]
		private TagManager tagManager = new TagManager();


#if UNITY_EDITOR
		private DoorwaySocket GetOrAddSocketByName(string name)
		{
			string path = AssetDatabase.GetAssetPath(this);

			var socket = AssetDatabase.LoadAllAssetsAtPath(path)
				.OfType<DoorwaySocket>()
				.FirstOrDefault(x => x.name == name);

			if (socket != null)
				return socket;

			socket = CreateInstance<DoorwaySocket>();
			socket.name = name;

			AssetDatabase.AddObjectToAsset(socket, this);

#if UNITY_2021_1_OR_NEWER
			AssetDatabase.SaveAssetIfDirty(socket);
#else
			AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(socket));
#endif

			return socket;
		}
#endif
	}
}
