using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NullReferenceException = System.NullReferenceException;
using InvalidOperationException = System.InvalidOperationException;

namespace BreadAndButter.Mobile
{
    public class MobileInput : MonoBehaviour
    {
        // Has the mobile input sytem been intialised
        public static bool Initialised => instance != null;

        [SerializeField] private SwipeInput swipeInput;
        //[SerializeField] private JoystickInput joystickInput;

        // Singleton refernce instance
        private static MobileInput instance = null;

        /// <summary>
        /// If the system isn't already setup, this will instantiate the mobile input prefab and assign the static reference.
        /// </summary>
        public static void Initialise()
        {
            // If the mobile input is already initialised, throw an Exception to tell the user they done goofed.
            if (Initialised)
            {
                throw new InvalidOperationException("Mobile Input already initialised!");
            }



            // Load the Mobile Input prefab and instantiate it, setting the instance
            MobileInput prefabInstance = Resources.Load<MobileInput>("Mobile Input Prefab");
            instance = Instantiate(prefabInstance);

            // Change the instantiiated objects name and mark it to not be destroyed
            instance.gameObject.name = "Mobile Input";
            DontDestroyOnLoad(instance.gameObject);
        }

        public static SwipeInput.Swipe GetSwipe(int _index)
        {
            if (!Initialised) throw new InvalidOperationException("Mobile Input not Intialised.");

            if (instance.swipeInput == null) throw new NullReferenceException("Swipe input reference not set.");

            return instance.swipeInput.GetSwipe(_index);
        }

        public static void GetFlickData(out float _flickPower, out Vector2 _flickDirection)
        {
            if (!Initialised) throw new InvalidOperationException("Mobile Input not Intialised.");

            if (instance.swipeInput == null) throw new NullReferenceException("Swipe input reference not set.");

            _flickPower = instance.swipeInput.FlickPower;
            _flickDirection = instance.swipeInput.FlickDirection;
        }

        /// <summary>
        /// Returns the value of the joystick from the joystick module if it is valid
        /// </summary>
        /// <param name="_axis">The axis to get the input from, Horizontal = x; Vetical = y</param>
        /// <returns></returns>
        /*public static float GetJoystickAxis(JoystickAxis _axis)
        {
            if (!Initialised)
            {
                // If the mobile input isn't initialised, thrown an InvalidOperationException
                throw new InvalidOperationException("Mobile Input not initialised");
            }

            // If the joystick input module isn't set, throw a NullreferenceException
            if (instance.joystickInput == null)
            {
                throw new NullReferenceException("Joystick Input reference not set.");
            }

            // Switch on the passed axis and return the appropriate value
            switch (_axis)
            {
                case JoystickAxis.Horizontal: return instance.joystickInput.Axis.x;
                case JoystickAxis.Vertical: return instance.joystickInput.Axis.y;
                default: return 0;
            }
        }*/


    }
}
