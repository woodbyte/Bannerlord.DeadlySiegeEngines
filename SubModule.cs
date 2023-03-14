using HarmonyLib;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace Bannerlord.DeadlySiegeEngines
{
    public class SubModule : MBSubModuleBase
    {
        protected override void OnSubModuleLoad()
        {
            Harmony harmony = new Harmony("bannerlord.deadlysiegeengines");
            harmony.PatchAll();
        }

        [HarmonyPatch(typeof(Agent))]
        [HarmonyPatch(nameof(Agent.Die))]
        internal class Patch01
        {
            static void Prefix(ref Blow b)
            {
                if (b.IsMissile && b.DamageType == DamageTypes.Blunt && b.WeaponRecord.WeaponClass == WeaponClass.Boulder)
                {
                    b.DamageType = DamageTypes.Pierce;
                }
            }
        }
    }
}