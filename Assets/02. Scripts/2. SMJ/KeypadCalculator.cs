/*
 * Keypad.cs - by ThunderWire Studio
 * Version 1.0
*/

using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace HFPS.Systems
{
    public class KeypadCalculator : MonoBehaviour, ISaveable
    {
        private MeshRenderer textRenderer;
        public MeshRenderer keypadRenderer;

        [Header("Materials")]
        public Material LedRedOn;
        public Material LedGreenOn;

        [Header("Setup")]
        public TextMesh AccessCodeText;

        [Header("Sounds")]
        public AudioClip enterCode;
        [Range(0, 2)] public float enterCodeVolume = 1f;

        public AudioClip accessGranted;
        [Range(0, 2)] public float grantedVolume = 1f;

        public AudioClip accessDenied;
        [Range(0, 2)] public float deniedVolume = 1f;

        [Space(15)]
        public UnityEvent OnAccessGranted;
        [Space(7)]
        public UnityEvent OnAccessDenied;

        private float result = 0;
        private string numberInsert = "";
        private int operatorInsert = 0;
        private bool enableInsert = true;

        [HideInInspector]
        public bool m_accessGranted = false;

        void Awake()
        {
            textRenderer = AccessCodeText.gameObject.GetComponent<MeshRenderer>();
        }

        void Start()
        {
            if (!keypadRenderer)
            {
                Debug.LogError("[Keypad] Please assign the Keypad Renderer!");
            }

            if (!LedGreenOn || !LedRedOn)
            {
                Debug.LogError("[Keypad] Please assign the Led Materials!");
            }
        }

        public void InsertCode(int number)
        {
            if(numberInsert.Equals("") && result == 0)
            {
                AccessCodeText.text = "";
            }

            if (enableInsert)
            {
                if (number != 10 && number != 11 && number != 12 && number != 13 && number != 14 && number != 15)
                {
                    if(numberInsert.Length < 6)
                    {
                        if (enterCode) { AudioSource.PlayClipAtPoint(enterCode, transform.position, enterCodeVolume); }
                        numberInsert += number;
                        AccessCodeText.text += number.ToString();
                    }
                }
                else
                {
                    // + Button
                    if (number == 12)
                    {
                        if (numberInsert.Length > 0)
                        {
                            if (enterCode) { AudioSource.PlayClipAtPoint(enterCode, transform.position, enterCodeVolume); }
                            if(operatorInsert != 0)
                            {
                                Calculator();
                                AccessCodeText.text = result.ToString() + " + ";
                                operatorInsert = 1;
                            }
                            else
                            {
                                result = int.Parse(numberInsert);
                                AccessCodeText.text += " + ";
                                operatorInsert = 1;
                            }
                            numberInsert = "";
                        }
                    }
                    // - Button
                    if (number == 13)
                    {
                        if (numberInsert.Length > 0)
                        {
                            if (enterCode) { AudioSource.PlayClipAtPoint(enterCode, transform.position, enterCodeVolume); }
                            if (operatorInsert != 0)
                            {
                                Calculator();
                                AccessCodeText.text = result.ToString() + " - ";
                                operatorInsert = 2;
                            }
                            else
                            {
                                result = int.Parse(numberInsert);
                                AccessCodeText.text += " - ";
                                operatorInsert = 2;
                            }
                            numberInsert = "";
                        }
                    }
                    // * Button
                    if (number == 14)
                    {
                        if (numberInsert.Length > 0)
                        {
                            if (enterCode) { AudioSource.PlayClipAtPoint(enterCode, transform.position, enterCodeVolume); }
                            if (operatorInsert != 0)
                            {
                                Calculator();
                                AccessCodeText.text = result.ToString() + " * ";
                                operatorInsert = 3;
                            }
                            else
                            {
                                result = int.Parse(numberInsert);
                                AccessCodeText.text += " * ";
                                operatorInsert = 3;
                            }
                            numberInsert = "";
                        }
                    }
                    // / Button
                    if (number == 15)
                    {
                        if (numberInsert.Length > 0)
                        {
                            if (enterCode) { AudioSource.PlayClipAtPoint(enterCode, transform.position, enterCodeVolume); }
                            if (operatorInsert != 0)
                            {
                                Calculator();
                                AccessCodeText.text = result.ToString() + " / ";
                                operatorInsert = 4;
                            }
                            else
                            {
                                result = int.Parse(numberInsert);
                                AccessCodeText.text += " / ";
                                operatorInsert = 4;
                            }
                            numberInsert = "";
                        }
                    }
                    // Back Button, number == 11
                    if (number == 10 || number == 11)
                    {
                        if (numberInsert.Length > 0)
                        {
                            if (enterCode) { AudioSource.PlayClipAtPoint(enterCode, transform.position, enterCodeVolume); }

                            if (number == 11)
                            {
                                Calculator();
                                AccessCodeText.text = result.ToString();
                            }
                            else
                            {
                                AccessCodeText.text = "";
                            }

                            numberInsert = "";
                            result = 0;
                            operatorInsert = 0;
                            StartCoroutine(WaitEnableInsert());
                        }
                    }
                }
            }
        }

        void Update()
        {
            if (enableInsert)
            {
                textRenderer.material.SetColor("_Color", Color.white);
            }
        }

        public void SetAccessGranted()
        {
            keypadRenderer.material = LedGreenOn;
            enableInsert = false;
            numberInsert = "";
            m_accessGranted = true;
        }

        IEnumerator WaitEnableInsert()
        {
            yield return new WaitForSeconds(1);
            enableInsert = true;
        }

        public Dictionary<string, object> OnSave()
        {
            return new Dictionary<string, object>()
            {
                { "accessGranted", m_accessGranted }
            };
        }

        public void OnLoad(JToken token)
        {
            m_accessGranted = (bool)token["accessGranted"];

            if (m_accessGranted)
            {
                keypadRenderer.material = LedGreenOn;
                enableInsert = false;
                enableInsert = true;
                numberInsert = "";
                textRenderer.material.SetColor("_Color", Color.green);
                AccessCodeText.text = "GRANTED";
            }
        }

        void Calculator()
        {
            // +
            if (operatorInsert == 1)
            {
                result += int.Parse(numberInsert);
            }
            // -
            else if (operatorInsert == 2)
            {
                result -= int.Parse(numberInsert);
            }
            // *
            else if (operatorInsert == 3)
            {
                result *= int.Parse(numberInsert);
            }
            // /
            else if (operatorInsert == 4)
            {
                result /= int.Parse(numberInsert);
                result = Mathf.Round(result*100) / 100;
            }
        }
    }
}