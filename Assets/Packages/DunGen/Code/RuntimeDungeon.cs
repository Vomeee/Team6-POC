using UnityEngine;

namespace DunGen
{
	[AddComponentMenu("DunGen/Runtime Dungeon")]
	public class RuntimeDungeon : MonoBehaviour
	{
		public DungeonGenerator Generator = new DungeonGenerator();
		public bool GenerateOnStart = true;
		public GameObject Root;


		protected virtual void Start()
		{
			if (GenerateOnStart)
				Generate();
		}

		public void Generate()
		{
			if (Root != null)
				Generator.Root = Root;

			if (!Generator.IsGenerating)
				Generator.Generate();
		}
	}
}
