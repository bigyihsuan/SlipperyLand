using System;
using System.Reflection;

using HarmonyLib;
using UnityModManagerNet;
using UnityEngine;

namespace SlipperyLand
{
	public class Main
	{
		static void Load(UnityModManager.ModEntry modEntry)
		{
			var harmony = new Harmony(modEntry.Info.Id);
			harmony.PatchAll();
		}
	}

	[HarmonyPatch(typeof(TrainCarColliders), "BogiesPhysicMaterial")]
	[HarmonyPatch(MethodType.Getter)]
	class TrainCarColliders_BogiesPhysicMaterial_Getter_Patch
	{
		static void Postfix(ref PhysicMaterial __result)
		{
			if ((UnityEngine.Object) __result != (UnityEngine.Object) null)
			{
				__result.dynamicFriction = Single.Epsilon;
			}
		}
	}
	[HarmonyPatch(typeof(TrainCarColliders), "TrainCarPhysicMaterial")]
	[HarmonyPatch(MethodType.Getter)]
	class TrainCarColliders_TrainCarPhysicMaterial_Getter_Patch
	{
		static void Postfix(ref PhysicMaterial __result)
		{
			if ((UnityEngine.Object) __result != (UnityEngine.Object) null)
			{
				__result.dynamicFriction = Single.Epsilon;
			}
		}
	}
}
