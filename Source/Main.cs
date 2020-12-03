using SquirtingElephant.Helpers;
using Verse;

namespace SquirtingElephant.CaravanEquipment
{
    [StaticConstructorOnStartup]
    public class Main
    {
        /// <summary>
        /// This constructor is executed after the XML-database has been fully loaded.
        /// </summary>
        static Main()
        {
            ApplySettingsToDefs();
        }

        public static void ApplySettingsToDefs()
        {
            Utils.EditPowerGenerationValue("LA_WoodFiredGenerator", SE_Settings.Settings.PPowerGenPowerGeneration);

            Utils.SetThingStat("PortableHospitalBed", "BedRestEffectiveness", SE_Settings.Settings.PHospitalBed_BedRestEff);
            Utils.SetThingStat("PortableHospitalBed", "ImmunityGainSpeedFactor", SE_Settings.Settings.PHospitalBed_ImmunityGainSpeedFactor);
            Utils.SetThingStat("PortableHospitalBed", "MedicalTendQualityOffset", SE_Settings.Settings.PHospitalBed_MedicalTendQualityOffset);
            Utils.SetThingStat("PortableHospitalBed", "SurgerySuccessChanceFactor", SE_Settings.Settings.PHospitalBed_SurgerySuccessChanceFactor);

            SE_Settings.Settings.Standard.ForEach(s => s.ApplySettingsToDefs());
        }
    }
}
