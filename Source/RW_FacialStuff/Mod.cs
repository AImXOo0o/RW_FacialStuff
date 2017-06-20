﻿using RimWorld;
using UnityEngine;
using Verse;
using static UnityEngine.GUILayout;

namespace RW_FacialStuff
{
    using FacialStuff;

    public class FS_Mod : Mod
    {
        #region Fields
        public override string SettingsCategory() => "Facial Stuff";

        private ModSettings modSettings = new FS_Settings();

        #endregion

        public FS_Mod(ModContentPack content) : base(content)
        {
            this.modSettings = this.GetSettings<FS_Settings>();
        }

        #region Methods

        public override void WriteSettings()
        {
            if (this.modSettings != null)
            {
                this.modSettings.Write();
            }


            if (Current.ProgramState == ProgramState.Playing)
            {
                if (Find.ColonistBar != null)
                {
                    Find.ColonistBar.MarkColonistsDirty();
                }
                foreach (Pawn pawn in PawnsFinder.AllMapsAndWorld_Alive)
                {
                    if (pawn.RaceProps.Humanlike)
                    {
                        CompFace faceComp = pawn.TryGetComp<CompFace>();
                        if (faceComp != null)
                        {
                            pawn.Drawer.renderer.graphics.ResolveAllGraphics();
                        }

                    }
                }
            }
        }

        public override void DoSettingsWindowContents(Rect inRect)
        {

            BeginArea(inRect);
            BeginVertical();
            FS_Settings.UseWrinkles = Toggle(FS_Settings.UseWrinkles, "Settings.UseWrinkles".Translate());
            EndVertical();
            BeginVertical();
            FS_Settings.UseMouth = Toggle(FS_Settings.UseMouth, "Settings.UseMouth".Translate());
            EndVertical();
            BeginVertical();
            FS_Settings.MergeHair = Toggle(FS_Settings.MergeHair, "Settings.MergeHair".Translate());
            EndVertical();
            BeginVertical();
            FS_Settings.HideHatInBed = Toggle(FS_Settings.HideHatInBed, "Settings.HideHatInBed".Translate());
            EndVertical();
            //     FlexibleSpace();
            //     BeginVertical();
            //     if (Button("Settings.Apply".Translate()))
            //     {
            //         foreach (Pawn pawn in PawnsFinder.AllMapsAndWorld_Alive)
            //         {
            //             if (pawn.RaceProps.Humanlike)
            //             {
            //                 CompFace faceComp = pawn.TryGetComp<CompFace>();
            //                 if (faceComp != null)
            //                 {
            //                     this.WriteSettings();
            //                     faceComp.sessionOptimized = false;
            //                     pawn.Drawer.renderer.graphics.ResolveAllGraphics();
            //                 }
            //
            //             }
            //         }
            //     }
            //     EndVertical();
            //     FlexibleSpace();
            EndArea();
        }

    }

    public class FS_Settings : ModSettings
    {
        public static bool UseMouth = false;

        public static bool UseWrinkles = true;

        public static bool MergeHair = true;

        public static bool HideHatInBed = true;

        public static float MaleAverageNormalOffsetX = 0.06226415f;
        public static float MaleAveragePointyOffsetX = 0.06603774f;
        public static float MaleAverageWideOffsetX = 0.05943396f;
        public static float FemaleAverageNormalOffsetX = -0.001886792f;
        public static float FemaleAveragePointyOffsetX =  -0.0009433962f;
        public static float FemaleAverageWideOffsetX = 0.04916981f;

        public static float MaleNarrowNormalOffsetX = 0;
        public static float MaleNarrowPointyOffsetX = 0.005660374f;
        public static float MaleNarrowWideOffsetX = -0.01698113f;
        public static float FemaleNarrowNormalOffsetX = -0.01415095f;
        public static float FemaleNarrowPointyOffsetX = 0.01132075f;
        public static float FemaleNarrowWideOffsetX = 0.01226415f;

        public static float MaleAverageNormalOffsetY = 0.002830188f;
        public static float MaleAveragePointyOffsetY = 0.006603774f;
        public static float MaleAverageWideOffsetY = 0;
        public static float FemaleAverageNormalOffsetY = 0;
        public static float FemaleAveragePointyOffsetY = 0;
        public static float FemaleAverageWideOffsetY = 0.01415094f;

        public static float MaleNarrowNormalOffsetY = 0.03962264f;
        public static float MaleNarrowPointyOffsetY = 0.02641509f;
        public static float MaleNarrowWideOffsetY = 0.05188679f;
        public static float FemaleNarrowNormalOffsetY = 0.02830189f;
        public static float FemaleNarrowPointyOffsetY = 0.03773585f;
        public static float FemaleNarrowWideOffsetY = 0.03301887f;




        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref UseWrinkles, "UseWrinkles", false, true);
            Scribe_Values.Look(ref UseMouth, "UseMouth", false, true);
            Scribe_Values.Look(ref MergeHair, "MergeHair", false, true);
            Scribe_Values.Look(ref HideHatInBed, "HideHatInBed", false, true);

#if develop


            Scribe_Values.Look(ref MaleAverageNormalOffsetX, "MaleAverageNormalOffsetX");
            Scribe_Values.Look(ref MaleAveragePointyOffsetX, "MaleAveragePointyOffsetX");
            Scribe_Values.Look(ref MaleAverageWideOffsetX, "MaleAverageWideOffsetX");

            Scribe_Values.Look(ref FemaleAverageNormalOffsetX, "FemaleAverageNormalOffsetX");
            Scribe_Values.Look(ref FemaleAveragePointyOffsetX, "FemaleAveragePointyOffsetX");
            Scribe_Values.Look(ref FemaleAverageWideOffsetX, "FemaleAverageWideOffsetX");

            Scribe_Values.Look(ref MaleNarrowNormalOffsetX, "MaleNarrowNormalOffsetX");
            Scribe_Values.Look(ref MaleNarrowPointyOffsetX, "MaleNarrowPointyOffsetX");
            Scribe_Values.Look(ref MaleNarrowWideOffsetX, "MaleNarrowWideOffsetX");

            Scribe_Values.Look(ref FemaleNarrowNormalOffsetX, "FemaleNarrowNormalOffsetX");
            Scribe_Values.Look(ref FemaleNarrowPointyOffsetX, "FemaleNarrowPointyOffsetX");
            Scribe_Values.Look(ref FemaleNarrowWideOffsetX, "FemaleNarrowWideOffsetX");

            Scribe_Values.Look(ref MaleAverageNormalOffsetY, "MaleAverageNormalOffsetY");
            Scribe_Values.Look(ref MaleAveragePointyOffsetY, "MaleAveragePointyOffsetY");
            Scribe_Values.Look(ref MaleAverageWideOffsetY, "MaleAverageWideOffsetY");

            Scribe_Values.Look(ref FemaleAverageNormalOffsetY, "FemaleAverageNormalOffsetY");
            Scribe_Values.Look(ref FemaleAveragePointyOffsetY, "FemaleAveragePointyOffsetY");
            Scribe_Values.Look(ref FemaleAverageWideOffsetY, "FemaleAverageWideOffsetY");

            Scribe_Values.Look(ref MaleNarrowNormalOffsetY, "MaleNarrowNormalOffsetY");
            Scribe_Values.Look(ref MaleNarrowPointyOffsetY, "MaleNarrowPointyOffsetY");
            Scribe_Values.Look(ref MaleNarrowWideOffsetY, "MaleNarrowWideOffsetY");

            Scribe_Values.Look(ref FemaleNarrowNormalOffsetY, "FemaleNarrowNormalOffsetY");
            Scribe_Values.Look(ref FemaleNarrowPointyOffsetY, "FemaleNarrowPointyOffsetY");
            Scribe_Values.Look(ref FemaleNarrowWideOffsetY, "FemaleNarrowWideOffsetY");
#endif
        }
    }

    #endregion
    // Backup:
 // <MaleAverageOffsetX>0.04716981</MaleAverageOffsetX>
 //
 // <MaleAverageOffsetY>0.01320755</MaleAverageOffsetY>
 //
 // <MaleNarrowOffsetX>-0.0245283</MaleNarrowOffsetX>
 //
 // <MaleNarrowOffsetY>0.03773585</MaleNarrowOffsetY>
 //
 // <FemaleAverageOffsetX>0.03584905</FemaleAverageOffsetX>
 //
 // <FemaleAverageOffsetY>0.04150943</FemaleAverageOffsetY>
 //
 // <FemaleNarrowOffsetX>0.009433965</FemaleNarrowOffsetX>
 //
 // <FemaleNarrowOffsetY>0.06981131</FemaleNarrowOffsetY>
 //
 // <MaleAverageNormalOffsetX>0.02641509</MaleAverageNormalOffsetX>
 //
 // <MaleAveragePointyOffsetX>0.02264151</MaleAveragePointyOffsetX>
 //
 // <MaleAverageWideOffsetX>0.00754717</MaleAverageWideOffsetX>
 //
 // <FemaleAverageNormalOffsetX>0.02452831</FemaleAverageNormalOffsetX>
 //
 // <FemaleAveragePointyOffsetX>0.02452831</FemaleAveragePointyOffsetX>
 //
 // <FemaleAverageWideOffsetX>0.04150943</FemaleAverageWideOffsetX>
}
