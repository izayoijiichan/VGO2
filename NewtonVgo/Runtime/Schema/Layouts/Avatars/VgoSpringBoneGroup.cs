﻿// ----------------------------------------------------------------------
// @Namespace : NewtonVgo
// @Class     : VgoSpringBoneGroup
// ----------------------------------------------------------------------
namespace NewtonVgo
{
    using Newtonsoft.Json;
    using System;
    using System.ComponentModel;
    using System.Numerics;

    /// <summary>
    /// VGO Spring Bone Group
    /// </summary>
    [Serializable]
    public class VgoSpringBoneGroup
    {
        /// <summary>Comments on this component.</summary>
        [JsonProperty("comment")]
        public string comment;

        /// <summary>The drag force.</summary>
        [JsonProperty("dragForce", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        //[Range(0.0f, 1.0f)]
        [DefaultValue(0.0f)]
        public float dragForce;

        /// <summary>The stiffness force.</summary>
        [JsonProperty("stiffnessForce", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        //[Range(0.0f, 4.0f)]
        [DefaultValue(1.0f)]
        public float stiffnessForce;

        /// <summary>Direction of gravity.</summary>
        [JsonProperty("gravityDirection")]
        public Vector3 gravityDirection;

        /// <summary></summary>
        [JsonProperty("gravityPower", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        //[Range(0.0f, 2.0f)]
        [DefaultValue(1.0f)]
        public float gravityPower;

        /// <summary>The indices of the root bone nodes.</summary>
        [JsonProperty("rootBones")]
        public int[] rootBones;

        /// <summary></summary>
        [JsonProperty("hitRadius", DefaultValueHandling = DefaultValueHandling.Populate)]
        //[Range(0.0f, 0.5f)]
        [DefaultValue(0.1f)]
        public float hitRadius;

        /// <summary>The indices of the collider groups.</summary>
        [JsonProperty("colliderGroups")]
        public int[] colliderGroups = null;

        /// <summary>Whether to draw Gizmo.</summary>
        [JsonProperty("drawGizmo", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(false)]
        public bool drawGizmo;

        /// <summary>The Gizmo color.</summary>
        /// <remarks>yellow</remarks>
        [JsonProperty("gizmoColor")]
        public Color3 gizmoColor = new Color3(1.0f, 0.92f, 0.016f);
    }
}