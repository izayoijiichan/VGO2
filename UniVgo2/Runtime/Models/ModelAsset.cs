﻿// ----------------------------------------------------------------------
// @Namespace : UniVgo2
// @Class     : ModelAsset
// ----------------------------------------------------------------------
namespace UniVgo2
{
    using NewtonVgo;
    using System;
    using System.Collections.Generic;
    using UnityEngine;
#if UNITY_EDITOR
    using UnityEditor;
#endif

    /// <summary>
    /// Model Asset
    /// </summary>
    [Serializable]
    public class ModelAsset : IDisposable
    {
        #region Fields (Common)

        /// <summary>The game object of root.</summary>
        public GameObject Root = null;

        /// <summary>List of unity animation clip.</summary>
        public List<AnimationClip> AnimationClipList = null;

        /// <summary>List of unity material.</summary>
        public List<Material> MaterialList = null;

        /// <summary>List of unity mesh and renderer.</summary>
        public List<MeshAsset> MeshAssetList = null;

        #endregion

        #region Fields (Import)

        /// <summary>List of unity texture2D.</summary>
        public List<Texture2D> Texture2dList = null;

        /// <summary>List of scriptable object.</summary>
        public List<ScriptableObject> ScriptableObjectList = new List<ScriptableObject>();

        /// <summary>Array of spring bone collider group.</summary>
        public VgoSpringBone.VgoSpringBoneColliderGroup[] SpringBoneColliderGroupArray = null;

        /// <summary>The avatar.</summary>
        public Avatar Avatar = null;

        /// <summary>The VGO layout.</summary>
        public VgoLayout Layout = null;

        #endregion

        #region Fields (Export)

        /// <summary>List of unity animation.</summary>
        public List<Animation> AnimationList = null;

        /// <summary>List of unity mesh.</summary>
        public List<Mesh> MeshList = null;

        /// <summary>List of unity renderer.</summary>
        public List<Renderer> RendererList = null;

        /// <summary>List of unity skinned mesh renderer.</summary>
        public List<SkinnedMeshRenderer> SkinList = null;

        /// <summary>List of unity particle system.</summary>
        public List<ParticleSystem> ParticleSystemList = null;

        /// <summary>List of unity VgoSpringBoneGroup.</summary>
        public List<VgoSpringBone.VgoSpringBoneGroup> VgoSpringBoneGroupList = null;

        /// <summary>List of unity VgoSpringBoneColliderGroup.</summary>
        public List<VgoSpringBone.VgoSpringBoneColliderGroup> VgoSpringBoneColliderGroupList = null;

        #endregion

        #region Fields (Dispose)

        /// <summary></summary>
        protected bool disposedValue;

        #endregion

        #region Constructors

        // ~ModelAsset()
        // {
        //     Dispose(disposing: false);
        // }

        #endregion

        #region Methods (Dispose)

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(disposing: true);
            //GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposedValue == false)
            {
                if (disposing)
                {
                    //
                }

#if UNITY_EDITOR
                DestroyRootAndResourcesForEditor();
#else
                DestroyRootAndResources();
#endif
                Root = null;

                disposedValue = true;
            }
        }

        /// <summary>
        /// Destroy root GameObject and unity resources.
        /// </summary>
        public virtual void DestroyRootAndResources()
        {
            if (Application.isPlaying == false)
            {
                Debug.LogWarningFormat("Dispose called in editor mode. This function is for runtime");
            }

            if (Root != null)
            {
                GameObject.Destroy(Root);
            }

            if (Avatar != null)
            {
                UnityEngine.Object.Destroy(Avatar);
            }

            foreach (UnityEngine.Object obj in ObjectsForSubAsset())
            {
                UnityEngine.Object.DestroyImmediate(obj, true);
            }

            foreach (ScriptableObject sObj in ScriptableObjectList)
            {
                ScriptableObject.DestroyImmediate(sObj);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected virtual IEnumerable<UnityEngine.Object> ObjectsForSubAsset()
        {
            foreach (var x in MaterialList) { yield return x; }
            foreach (var x in MeshAssetList) { yield return x.Mesh; }
            foreach (var x in Texture2dList) { yield return x; }
            foreach (var x in SpringBoneColliderGroupArray) { yield return x; }

            if (AnimationList != null)
            {
                foreach (var x in AnimationList) { yield return x; }
            }
            if (AnimationClipList != null)
            {
                foreach (var x in AnimationClipList) { yield return x; }
            }
            if (MeshList != null)
            {
                foreach (var x in MeshList) { yield return x; }
            }
            if (RendererList != null)
            {
                foreach (var x in RendererList) { yield return x; }
            }
            if (SkinList != null)
            {
                foreach (var x in SkinList) { yield return x; }
            }
            if (ParticleSystemList != null)
            {
                foreach (var x in ParticleSystemList) { yield return x; }
            }
            if (VgoSpringBoneGroupList != null)
            {
                foreach (var x in VgoSpringBoneGroupList) { yield return x; }
            }
            if (VgoSpringBoneColliderGroupList != null)
            {
                foreach (var x in VgoSpringBoneColliderGroupList) { yield return x; }
            }
        }

#if UNITY_EDITOR
        /// <summary>
        /// Destroy root GameObject and unity resources.
        /// </summary>
        public void DestroyRootAndResourcesForEditor()
        {
            if (Application.isPlaying == false)
            {
                if (Root != null)
                {
                    if (string.IsNullOrEmpty(AssetDatabase.GetAssetPath(Root)))
                    {
                        UnityEngine.Object.DestroyImmediate(Root);
                    }
                }

                if (Avatar != null)
                {
                    if (string.IsNullOrEmpty(AssetDatabase.GetAssetPath(Avatar)))
                    {
                        UnityEngine.Object.DestroyImmediate(Avatar);
                    }
                }

                if (Texture2dList != null)
                {
                    foreach (Texture2D texture in Texture2dList)
                    {
                        if (string.IsNullOrEmpty(AssetDatabase.GetAssetPath(texture)))
                        {
                            UnityEngine.Object.DestroyImmediate(texture);
                        }
                    }
                }

                if (SpringBoneColliderGroupArray != null)
                {
                    foreach (var springBoneColliderGroup in SpringBoneColliderGroupArray)
                    {
                        if (string.IsNullOrEmpty(AssetDatabase.GetAssetPath(springBoneColliderGroup)))
                        {
                            UnityEngine.Object.DestroyImmediate(springBoneColliderGroup);
                        }
                    }
                }

                if (AnimationList != null)
                {
                    foreach (Animation animation in AnimationList)
                    {
                        if (string.IsNullOrEmpty(AssetDatabase.GetAssetPath(animation)))
                        {
                            UnityEngine.Object.DestroyImmediate(animation);
                        }
                    }
                }

                if (AnimationClipList != null)
                {
                    foreach (AnimationClip animationClip in AnimationClipList)
                    {
                        if (string.IsNullOrEmpty(AssetDatabase.GetAssetPath(animationClip)))
                        {
                            UnityEngine.Object.DestroyImmediate(animationClip);
                        }
                    }
                }

                if (MaterialList != null)
                {
                    foreach (Material material in MaterialList)
                    {
                        if (string.IsNullOrEmpty(AssetDatabase.GetAssetPath(material)))
                        {
                            UnityEngine.Object.DestroyImmediate(material);
                        }
                    }
                }

                if (MeshAssetList != null)
                {
                    foreach (MeshAsset meshAsset in MeshAssetList)
                    {
                        if (string.IsNullOrEmpty(AssetDatabase.GetAssetPath(meshAsset.Mesh)))
                        {
                            UnityEngine.Object.DestroyImmediate(meshAsset.Mesh);
                        }
                    }
                }

                if (MeshList != null)
                {
                    foreach (Mesh mesh in MeshList)
                    {
                        if (string.IsNullOrEmpty(AssetDatabase.GetAssetPath(mesh)))
                        {
                            UnityEngine.Object.DestroyImmediate(mesh);
                        }
                    }
                }

                if (RendererList != null)
                {
                    foreach (Renderer renderer in RendererList)
                    {
                        if (string.IsNullOrEmpty(AssetDatabase.GetAssetPath(renderer)))
                        {
                            UnityEngine.Object.DestroyImmediate(renderer);
                        }
                    }
                }

                if (SkinList != null)
                {
                    foreach (SkinnedMeshRenderer skin in SkinList)
                    {
                        if (string.IsNullOrEmpty(AssetDatabase.GetAssetPath(skin)))
                        {
                            UnityEngine.Object.DestroyImmediate(skin);
                        }
                    }
                }

                if (ParticleSystemList != null)
                {
                    foreach (ParticleSystem particleSystem in ParticleSystemList)
                    {
                        if (string.IsNullOrEmpty(AssetDatabase.GetAssetPath(particleSystem)))
                        {
                            UnityEngine.Object.DestroyImmediate(particleSystem);
                        }
                    }
                }

                if (VgoSpringBoneGroupList != null)
                {
                    foreach (var vgoSpringBoneGroup in VgoSpringBoneGroupList)
                    {
                        if (string.IsNullOrEmpty(AssetDatabase.GetAssetPath(vgoSpringBoneGroup)))
                        {
                            UnityEngine.Object.DestroyImmediate(vgoSpringBoneGroup);
                        }
                    }
                }

                if (VgoSpringBoneColliderGroupList != null)
                {
                    foreach (var vgoSpringBoneColliderGroup in VgoSpringBoneColliderGroupList)
                    {
                        if (string.IsNullOrEmpty(AssetDatabase.GetAssetPath(vgoSpringBoneColliderGroup)))
                        {
                            UnityEngine.Object.DestroyImmediate(vgoSpringBoneColliderGroup);
                        }
                    }
                }

                if (ScriptableObjectList != null)
                {
                    foreach (ScriptableObject sObj in ScriptableObjectList)
                    {
                        if (string.IsNullOrEmpty(AssetDatabase.GetAssetPath(sObj)))
                        {
                            UnityEngine.Object.DestroyImmediate(sObj);
                        }
                    }
                }
            }
        }
#endif
        #endregion
    }
}
