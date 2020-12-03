using SquirtingElephant.Helpers;
using System.Linq;
using Verse;

namespace SquirtingElephant.CaravanEquipment
{
    public static class SE_Helper
    {
        public static void SetThingAlloyCost(string thingDefName, int newAlloyCost)
        {
            ThingDef thingDef = Utils.GetDefByDefName<ThingDef>(thingDefName);
            if (thingDef != null)
            {
                ThingDefCountClass costDef = thingDef.costList.FirstOrDefault(c => c.thingDef == DefDatabase<ThingDef>.GetNamed("LightAlloy"));
                if (costDef != null) { costDef.count = newAlloyCost; }
            }
        }
    }
}
