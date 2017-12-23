﻿namespace FacialStuff
{
    using System.Collections.Generic;

    using FacialStuff.Defs;

    using UnityEngine;

    using Verse;

    public class CompProperties_BodyAnimator : CompProperties
    {
        #region Public Fields

        public string handType = "Human";

        public bool bipedWithHands = false;

        public BodyAnimDef bodyAnimType;

        public Vector3 hipOffset;

        public Vector3 shoulderOffset;

        public List<PawnBodyDrawer> drawers = new List<PawnBodyDrawer>();

        public bool quadruped = false;

        #endregion Public Fields

        #region Public Constructors

        public CompProperties_BodyAnimator()
        {
            this.compClass = typeof(CompBodyAnimator);
        }

        #endregion Public Constructors
    }
}