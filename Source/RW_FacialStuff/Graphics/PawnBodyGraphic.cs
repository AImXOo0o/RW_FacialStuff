﻿// ReSharper disable StyleCop.SA1401

namespace FacialStuff.Graphics
{
    using UnityEngine;

    using Verse;

    public class PawnBodyGraphic
    {
        public readonly CompBodyAnimator CompAni;

        public Graphic FootGraphicLeft;

        public Graphic FootGraphicLeftCol;

        public Graphic FootGraphicLeftShadow;

        public Graphic FootGraphicRight;

        public Graphic FootGraphicRightCol;

        public Graphic FootGraphicRightShadow;

        public Graphic FrontPawGraphicLeft;

        public Graphic FrontPawGraphicLeftCol;

        public Graphic FrontPawGraphicLeftShadow;

        public Graphic FrontPawGraphicRight;

        public Graphic FrontPawGraphicRightCol;

        public Graphic FrontPawGraphicRightShadow;

        public Graphic HandGraphicLeft;

        public Graphic HandGraphicLeftCol;

        public Graphic HandGraphicLeftShadow;

        public Graphic HandGraphicRight;

        public Graphic HandGraphicRightCol;

        public Graphic HandGraphicRightShadow;

        private readonly Pawn pawn;

        private readonly Color shadowColor = new Color(0.54f, 0.56f, 0.6f);

        public PawnBodyGraphic(CompBodyAnimator compAni)
        {
            this.CompAni = compAni;
            this.pawn = compAni.Pawn;

            LongEventHandler.ExecuteWhenFinished(
                () =>
                    {
                        this.InitializeGraphicsHand();
                        this.InitializeGraphicsFeet();
                        if (this.CompAni.Props.quadruped)
                        {
                            this.InitializeGraphicsFrontPaws();
                        }
                    });
        }

        private void InitializeGraphicsFeet()
        {
            string texNameFoot = "Hands/" + this.CompAni.Props.handType + "_Foot";

            Color skinColor;
            if (this.pawn.RaceProps.Animal)
            {
                PawnKindLifeStage curKindLifeStage = this.pawn.ageTracker.CurKindLifeStage;

                skinColor = curKindLifeStage.bodyGraphicData.color;
            }
            else
            {
                skinColor = this.pawn.story.SkinColor;
            }

            Color rightColorFoot = Color.red;
            Color leftColorFoot = Color.blue;

            Color rightFootColor = skinColor;
            Color leftFootColor = skinColor;
            Color metal = new Color(0.51f, 0.61f, 0.66f);

            switch (this.CompAni.bodyStat.FootRight)
            {
                case PartStatus.Artificial:
                    rightFootColor = metal;
                    break;
            }

            switch (this.CompAni.bodyStat.FootLeft)
            {
                case PartStatus.Artificial:
                    leftFootColor = metal;
                    break;
            }

            Color rightFootShadowColor = rightFootColor * this.shadowColor;
            Color leftFootShadowColor = leftFootColor * this.shadowColor;

            this.FootGraphicRight = GraphicDatabase.Get<Graphic_Multi>(
                texNameFoot,
                ShaderDatabase.CutoutSkin,
                new Vector2(1f, 1f),
                rightFootColor,
                skinColor);

            this.FootGraphicLeft = GraphicDatabase.Get<Graphic_Multi>(
                texNameFoot,
                ShaderDatabase.CutoutSkin,
                new Vector2(1f, 1f),
                leftFootColor,
                skinColor);

            this.FootGraphicRightShadow = GraphicDatabase.Get<Graphic_Multi>(
                texNameFoot,
                ShaderDatabase.CutoutSkin,
                new Vector2(1f, 1f),
                rightFootShadowColor,
                skinColor);

            this.FootGraphicLeftShadow = GraphicDatabase.Get<Graphic_Multi>(
                texNameFoot,
                ShaderDatabase.CutoutSkin,
                new Vector2(1f, 1f),
                leftFootShadowColor,
                skinColor);

            this.FootGraphicRightCol = GraphicDatabase.Get<Graphic_Multi>(
                texNameFoot,
                ShaderDatabase.CutoutSkin,
                new Vector2(1f, 1f),
                rightColorFoot,
                skinColor);

            this.FootGraphicLeftCol = GraphicDatabase.Get<Graphic_Multi>(
                texNameFoot,
                ShaderDatabase.CutoutSkin,
                new Vector2(1f, 1f),
                leftColorFoot,
                skinColor);
        }

        private void InitializeGraphicsFrontPaws()
        {
            string texNameFoot = "Hands/" + this.CompAni.Props.handType + "_Foot";

            Color skinColor;
            if (this.pawn.RaceProps.Animal)
            {
                PawnKindLifeStage curKindLifeStage = this.pawn.ageTracker.CurKindLifeStage;

                skinColor = curKindLifeStage.bodyGraphicData.color;
            }
            else
            {
                skinColor = this.pawn.story.SkinColor;
            }

            Color rightColorFoot = Color.cyan;
            Color leftColorFoot = Color.magenta;

            Color rightFootColor = skinColor;
            Color leftFootColor = skinColor;
            Color metal = new Color(0.51f, 0.61f, 0.66f);

            switch (this.CompAni.bodyStat.FootRight)
            {
                case PartStatus.Artificial:
                    rightFootColor = metal;
                    break;
            }

            switch (this.CompAni.bodyStat.FootLeft)
            {
                case PartStatus.Artificial:
                    leftFootColor = metal;
                    break;
            }

            Color rightFootColorShadow = rightFootColor * this.shadowColor;
            Color leftFootColorShadow = leftFootColor * this.shadowColor;

            this.FrontPawGraphicRight = GraphicDatabase.Get<Graphic_Multi>(
                texNameFoot,
                ShaderDatabase.CutoutSkin,
                new Vector2(1f, 1f),
                rightFootColor,
                skinColor);

            this.FrontPawGraphicLeft = GraphicDatabase.Get<Graphic_Multi>(
                texNameFoot,
                ShaderDatabase.CutoutSkin,
                new Vector2(1f, 1f),
                leftFootColor,
                skinColor);

            this.FrontPawGraphicRightShadow = GraphicDatabase.Get<Graphic_Multi>(
                texNameFoot,
                ShaderDatabase.CutoutSkin,
                new Vector2(1f, 1f),
                rightFootColorShadow,
                skinColor);

            this.FrontPawGraphicLeftShadow = GraphicDatabase.Get<Graphic_Multi>(
                texNameFoot,
                ShaderDatabase.CutoutSkin,
                new Vector2(1f, 1f),
                leftFootColorShadow,
                skinColor);

            this.FrontPawGraphicRightCol = GraphicDatabase.Get<Graphic_Multi>(
                texNameFoot,
                ShaderDatabase.CutoutSkin,
                new Vector2(1f, 1f),
                rightColorFoot,
                skinColor);

            this.FrontPawGraphicLeftCol = GraphicDatabase.Get<Graphic_Multi>(
                texNameFoot,
                ShaderDatabase.CutoutSkin,
                new Vector2(1f, 1f),
                leftColorFoot,
                skinColor);
        }

        private void InitializeGraphicsHand()
        {
            if (!this.CompAni.Props.bipedWithHands)
            {
                return;
            }

            string texNameHand = "Hands/" + this.CompAni.Props.handType + "_Hand";

            Color skinColor = this.pawn.story.SkinColor;

            Color rightColorHand = Color.cyan;
            Color leftColorHand = Color.magenta;

            Color rightHandColor = skinColor;
            Color leftHandColor = skinColor;

            Color metal = new Color(0.51f, 0.61f, 0.66f);

            switch (this.CompAni.bodyStat.HandRight)
            {
                case PartStatus.Artificial:
                    rightHandColor = metal;
                    break;
            }

            switch (this.CompAni.bodyStat.HandLeft)
            {
                case PartStatus.Artificial:
                    leftHandColor = metal;
                    break;
            }

            Color leftHandColorShadow = leftHandColor * this.shadowColor;
            Color rightHandColorShadow = rightHandColor * this.shadowColor;

            this.HandGraphicRight = GraphicDatabase.Get<Graphic_Single>(
                texNameHand,
                ShaderDatabase.CutoutSkin,
                new Vector2(1f, 1f),
                rightHandColor,
                skinColor);

            this.HandGraphicLeft = GraphicDatabase.Get<Graphic_Single>(
                texNameHand,
                ShaderDatabase.CutoutSkin,
                new Vector2(1f, 1f),
                leftHandColor,
                skinColor);

            this.HandGraphicRightShadow = GraphicDatabase.Get<Graphic_Single>(
                texNameHand,
                ShaderDatabase.CutoutSkin,
                new Vector2(1f, 1f),
                rightHandColorShadow,
                skinColor);

            this.HandGraphicLeftShadow = GraphicDatabase.Get<Graphic_Single>(
                texNameHand,
                ShaderDatabase.CutoutSkin,
                new Vector2(1f, 1f),
                leftHandColorShadow,
                skinColor);

            // for development
            this.HandGraphicRightCol = GraphicDatabase.Get<Graphic_Single>(
                texNameHand,
                ShaderDatabase.CutoutSkin,
                new Vector2(1f, 1f),
                rightColorHand,
                skinColor);

            this.HandGraphicLeftCol = GraphicDatabase.Get<Graphic_Single>(
                texNameHand,
                ShaderDatabase.CutoutSkin,
                new Vector2(1f, 1f),
                leftColorHand,
                skinColor);
        }
    }
}