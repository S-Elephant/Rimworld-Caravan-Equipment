using SquirtingElephant.Helpers;
using UnityEngine;
using Verse;

namespace SquirtingElephant.CaravanEquipment
{
    public class SE_Settings : Mod
    {
        #region Fields
        
        public static SettingsData Settings;
        public static TableData Table = new TableData(new Vector2(10f, 0f), new Vector2(10f, 10f), new [] { 32f, 225f, 110f, 110f }, new [] { 32f }, 4, 8);
        private const float SCROLL_AREA_OFFSET_TOP = 200f;

        // Scrolling:
        private Vector2 ScrollPosition = Vector2.zero;
        private Rect ViewRect = new Rect(0f, 0f, 100.0f, 200.0f);
        
        #endregion

        public SE_Settings(ModContentPack content) : base(content) { Settings = GetSettings<SettingsData>(); }

        public override void DoSettingsWindowContents(Rect inRect)
        {
            Listing_Standard ls = new Listing_Standard();
            ls.Begin(inRect);

            Utils.MakeTextFieldNumericLabeled(ls, "SECE_PPowerGenAmount", ref Settings.PPowerGenPowerGeneration, 1, 100000);
            ls.Gap(24f);

            AddLA_HospitalBedSettings(ls);
            ls.GapLine();

            ls.BeginScrollView(new Rect(0, SCROLL_AREA_OFFSET_TOP, inRect.width, inRect.height - SCROLL_AREA_OFFSET_TOP), ref ScrollPosition, ref ViewRect);

            CreateHeaders();
            for (int i = 0; i < Settings.Standard.Count; i++)
                Settings.Standard[i].DoSettingsWindowContents(i + 1);

            ls.EndScrollView(ref ViewRect);
            ls.End();

            Main.ApplySettingsToDefs();
        }

        private static void CreateHeaders()
        {
            Widgets.Label(Table.GetHeaderRect(1), "SECE_ItemName".Translate().CapitalizeFirst());
            Widgets.Label(Table.GetHeaderRect(2), "SECE_AlloyCost".Translate().CapitalizeFirst());
            Widgets.Label(Table.GetHeaderRect(3), "SECE_Mass".Translate().CapitalizeFirst());
        }

        private static void AddLA_HospitalBedSettings(Listing_Standard ls)
        {
            ls.Label("SECE_LAHospitalBedStats".Translate().CapitalizeFirst());
            Utils.MakeTextFieldNumericLabeled(ls, "SECE_BedRestEff", ref Settings.PHospitalBed_BedRestEff, 0.1f, 10f);
            Utils.MakeTextFieldNumericLabeled(ls, "SECE_ImmunityGainSpeedFactor", ref Settings.PHospitalBed_ImmunityGainSpeedFactor, 0.1f, 10f);
            Utils.MakeTextFieldNumericLabeled(ls, "SECE_MedicalTendQualityOffset", ref Settings.PHospitalBed_MedicalTendQualityOffset, 0.1f, 10f);
            Utils.MakeTextFieldNumericLabeled(ls, "SECE_SurgerySuccessChanceFactor", ref Settings.PHospitalBed_SurgerySuccessChanceFactor, 0.1f, 10f);
        }

        public override string SettingsCategory() => "SECE_SettingsCategory".Translate();
    }
}
