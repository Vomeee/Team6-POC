﻿using DunGen.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

namespace DunGen
{
	[AddComponentMenu("DunGen/Tile")]
	public class Tile : MonoBehaviour, ISerializationCallbackReceiver
	{
		public const int CurrentFileVersion = 2;

		#region Legacy Properties

		// Legacy properties only exist to avoid breaking existing projects
		// Converting old data structures over to the new ones

		[SerializeField]
		[FormerlySerializedAs("AllowImmediateRepeats")]
		private bool allowImmediateRepeats = true;

		[SerializeField]
		[Obsolete("'Entrance' is no longer used. Please use the 'Entrances' list instead", false)]
		public Doorway Entrance;

		[SerializeField]
		[Obsolete("'Exit' is no longer used. Please use the 'Exits' list instead", false)]
		public Doorway Exit;

		#endregion

		/// <summary>
		/// Should this tile be allowed to rotate to fit in place?
		/// </summary>
		public bool AllowRotation = true;

		/// <summary>
		/// Should this tile be allowed to be placed next to another instance of itself?
		/// </summary>
		public TileRepeatMode RepeatMode = TileRepeatMode.Allow;

		/// <summary>
		/// Should the automatically generated tile bounds be overriden with a user-defined value?
		/// </summary>
		public bool OverrideAutomaticTileBounds = false;

		/// <summary>
		/// Optional tile bounds to override the automatically calculated tile bounds
		/// </summary>
		public Bounds TileBoundsOverride = new Bounds(Vector3.zero, Vector3.one);

		/// <summary>
		/// An optional collection of entrance doorways. DunGen will try to use one of these doorways as the entrance to the tile if possible
		/// </summary>
		public List<Doorway> Entrances = new List<Doorway>();

		/// <summary>
		/// An optional collection of exit doorways. DunGen will try to use one of these doorways as the exit to the tile if possible
		/// </summary>
		public List<Doorway> Exits = new List<Doorway>();

		/// <summary>
		/// Should this tile override the connection chance globally defined in the DungeonFlow?
		/// </summary>
		public bool OverrideConnectionChance = false;

		/// <summary>
		/// The overriden connection chance value. Only used if <see cref="OverrideConnectionChance"/> is true.
		/// If both tiles have overriden the connection chance, the lowest value is used
		/// </summary>
		public float ConnectionChance = 0f;

		/// <summary>
		/// A collection of tags for this tile. Can be used with the dungeon flow asset to restrict which
		/// tiles can be attached
		/// </summary>
		public TagContainer Tags = new TagContainer();

		/// <summary>
		/// The calculated world-space bounds of this Tile
		/// </summary>
		[HideInInspector]
		public Bounds Bounds { get { return transform.TransformBounds(Placement.LocalBounds); } }

		/// <summary>
		/// Information about the tile's position in the generated dungeon
		/// </summary>
		public TilePlacementData Placement
		{
			get { return placement; }
			internal set { placement = value; }
		}
		/// <summary>
		/// The dungeon that this tile belongs to
		/// </summary>
		public Dungeon Dungeon { get; internal set; }

		public List<Doorway> AllDoorways = new List<Doorway>();
		public List<Doorway> UsedDoorways = new List<Doorway>();
		public List<Doorway> UnusedDoorways = new List<Doorway>();
		public GameObject Prefab { get; internal set; }

		[SerializeField]
		private TilePlacementData placement;
		[SerializeField]
		private int fileVersion;


		internal void AddTriggerVolume()
		{
			BoxCollider triggerVolume = gameObject.AddComponent<BoxCollider>();
			triggerVolume.center = Placement.LocalBounds.center;
			triggerVolume.size = Placement.LocalBounds.size;
			triggerVolume.isTrigger = true;
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other == null)
				return;

			var character = other.gameObject.GetComponent<DungenCharacter>();

			if (character != null)
				character.OnTileEntered(this);
		}

		private void OnTriggerExit(Collider other)
		{
			if (other == null)
				return;

			var character = other.gameObject.GetComponent<DungenCharacter>();

			if (character != null)
				character.OnTileExited(this);
		}

		private void OnDrawGizmosSelected()
		{
			Gizmos.color = Color.red;
			Bounds? bounds = null;


			if (OverrideAutomaticTileBounds)
				bounds = transform.TransformBounds(TileBoundsOverride);
			else if (placement != null)
				bounds = Bounds;

			if (bounds.HasValue)
				Gizmos.DrawWireCube(bounds.Value.center, bounds.Value.size);
		}

		public IEnumerable<Tile> GetAdjactedTiles()
		{
			return UsedDoorways.Select(x => x.ConnectedDoorway.Tile).Distinct();
		}

		public bool IsAdjacentTo(Tile other)
		{
			foreach (var door in UsedDoorways)
				if (door.ConnectedDoorway.Tile == other)
					return true;

			return false;
		}

		public Doorway GetEntranceDoorway()
		{
			foreach (var doorway in UsedDoorways)
			{
				var connectedTile = doorway.ConnectedDoorway.Tile;

				if (Placement.IsOnMainPath)
				{
					if (connectedTile.Placement.IsOnMainPath && Placement.PathDepth > connectedTile.Placement.PathDepth)
						return doorway;
				}
				else
				{
					if (connectedTile.Placement.IsOnMainPath || Placement.Depth > connectedTile.Placement.Depth)
						return doorway;
				}
			}

			return null;
		}

		public Doorway GetExitDoorway()
		{
			foreach (var doorway in UsedDoorways)
			{
				var connectedTile = doorway.ConnectedDoorway.Tile;

				if (Placement.IsOnMainPath)
				{
					if (connectedTile.Placement.IsOnMainPath && Placement.PathDepth < connectedTile.Placement.PathDepth)
						return doorway;
				}
				else
				{
					if (!connectedTile.Placement.IsOnMainPath && Placement.Depth < connectedTile.Placement.Depth)
						return doorway;
				}
			}

			return null;
		}

		#region ISerializationCallbackReceiver Implementation

		public void OnBeforeSerialize()
		{
			fileVersion = CurrentFileVersion;
		}

		public void OnAfterDeserialize()
		{
#pragma warning disable 618

			// AllowImmediateRepeats (bool) -> TileRepeatMode (enum)
			if (fileVersion < 1)
				RepeatMode = (allowImmediateRepeats) ? TileRepeatMode.Allow : TileRepeatMode.DisallowImmediate;

			// Converted individual Entrance and Exit doorways to collections
			if (fileVersion < 2)
			{
				if (Entrances == null)
					Entrances = new List<Doorway>();

				if (Exits == null)
					Exits = new List<Doorway>();

				if (Entrance != null)
					Entrances.Add(Entrance);

				if(Exit != null)
					Exits.Add(Exit);

				Entrance = null;
				Exit = null;
			}
#pragma warning restore 618
		}

		#endregion
	}
}
