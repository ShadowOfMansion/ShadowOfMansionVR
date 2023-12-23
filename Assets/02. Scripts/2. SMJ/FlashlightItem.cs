using UnityEngine;
using HFPS.Systems;

namespace HFPS.Player 
{
    /// <summary>
    /// Script for Flashlight Controls
    /// </summary>
    public class FlashlightItem : MonoBehaviour
    {
        [Header("Setup")]
        public Light LightObject;

        [Header("Flashlight Settings")]
        [ReadOnly, SerializeField] 
        private float batteryPercentage = 100;

        public float flashlightIntensity;


        void Awake()
        {
            flashlightIntensity = batteryPercentage / 10;
            LightObject.intensity = flashlightIntensity;
        }

        void Update()
        {
            LightObject.enabled = true;
        }

        public void Event_Scare()
        {
            // ±ô¹Ú±ô¹Ú ÀÌº¥Æ® Ãß°¡

        }
    }
}