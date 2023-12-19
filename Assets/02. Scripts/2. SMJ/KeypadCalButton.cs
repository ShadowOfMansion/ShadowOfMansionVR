using UnityEngine;

namespace HFPS.Systems
{
	public class KeypadCalButton : MonoBehaviour
	{
		private KeypadCalculator keypad;

		public int number;

		void Start()
		{
			keypad = transform.parent.GetComponent<KeypadCalculator>();
		}

		public void UseObject()
		{
			if (!keypad.m_accessGranted)
			{
				keypad.InsertCode(number);
			}
		}
	}
}