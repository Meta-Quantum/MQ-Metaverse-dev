using System;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
    internal class PropInstance : IProp
    {
        // MEMBERS: -------------------------------------------------------------------------------
        
        private readonly IBone m_Bone;

        private readonly Vector3 m_OffsetPosition;
        private readonly Quaternion m_OffsetRotation;
        
        private readonly Vector3 m_LocalScale;

        // PROPERTIES: ----------------------------------------------------------------------------

        [field: NonSerialized] public Transform Bone { get; private set; }
        [field: NonSerialized] public GameObject Instance { get; }

        // CONSTRUCTORS: --------------------------------------------------------------------------

        public PropInstance(IBone bone, GameObject instance, Vector3 position, Quaternion rotation)
        {
            this.m_Bone = bone;
            this.Instance = instance;

            this.m_OffsetPosition = position;
            this.m_OffsetRotation = rotation;
            
            this.m_LocalScale = instance != null
                ? instance.transform.localScale 
                : Vector3.one;
        }

        // PUBLIC METHODS: ------------------------------------------------------------------------

        public void Create(Animator animator)
        {
            if (animator == null) return;
            if (this.Instance == null) return;
            
            this.Bone = this.m_Bone?.GetTransform(animator);
            if (this.Bone == null) return;

            this.Instance.transform.localScale = this.m_LocalScale;
            this.Instance.transform.SetParent(this.Bone, true);
            
            this.Instance.transform.localPosition = this.m_OffsetPosition;
            this.Instance.transform.localRotation = this.m_OffsetRotation;
        }

        public void Destroy()
        {
            if (this.Instance == null) return;
            UnityEngine.Object.Destroy(this.Instance);
        }
        
        public void Drop()
        {
            if (this.Instance == null) return;
            this.Instance.transform.SetParent(null, true);
        }
    }
}