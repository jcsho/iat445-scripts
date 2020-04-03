using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollingStones
{
    public class TriggerItem : MonoBehaviour
    {
        public enum MovementDirection
        {
            Up,
            Down
        }

        [Tooltip("Must be a component with TriggerPad script")]
        public TriggerPad TriggerPad;

        [Header("Animation Settings")]

        public MovementDirection Direction;

        [Space(10)]

        [Tooltip("Duration of the trigger-activated movment")]
        public int TriggerTimer = 5;

        [Tooltip("Duration of the trigger-released movment")]
        public int ReleaseTimer = 5;

        [Tooltip("Delay before item starts moving down after trigger is false")]
        public int ReleaseDelay = 1;

        [Space(10)]

        [Tooltip("Amount to increase in y-axis")]
        public int MovementAmount = 1;

        private float baseYAxis;
        private float triggerMovementPerSec;
        private float releaseMovementPerSec;

        private float timer = 0f;
        private int counter;

        // Start is called before the first frame update
        void Start()
        {
            baseYAxis = transform.position.y;

            triggerMovementPerSec = (float)MovementAmount / (float)TriggerTimer;
            triggerMovementPerSec = Direction == MovementDirection.Up ? triggerMovementPerSec : -triggerMovementPerSec;
            
            releaseMovementPerSec = (float)MovementAmount / (float)TriggerTimer;
            releaseMovementPerSec = Direction == MovementDirection.Down ? releaseMovementPerSec : -releaseMovementPerSec;

            counter = ReleaseDelay;

            if (TriggerPad == null)
                Debug.LogWarning("Trigger item is missing trigger pad and will not move", gameObject);
        }

        // Update is called once per frame
        void Update()
        {
            AnimateItem(TriggerPad.IsTrigger, Direction);
        }

        private void AnimateItem(bool trigger, MovementDirection direction)
        {
            float triggerPosition1 = direction == MovementDirection.Up ? transform.position.y : (baseYAxis - MovementAmount);

            float triggerPosition2 = direction == MovementDirection.Up ? (baseYAxis + MovementAmount) : transform.position.y;

            float releasePosition1 = direction == MovementDirection.Up ? transform.position.y : baseYAxis;

            float releasePosition2 = direction == MovementDirection.Up ? baseYAxis : transform.position.y;

            if (trigger && triggerPosition1 < triggerPosition2)
            {
                transform.Translate(new Vector3(0, triggerMovementPerSec) * Time.deltaTime);
                counter = ReleaseDelay;
            }
            // delay for a x seconds
            // delay should refresh if trigger is true again
            else if (!trigger && releasePosition1 > releasePosition2)
            {
                timer += Time.deltaTime;

                if (timer >= 1f)
                {
                    timer = timer % 1f;
                    if (counter > 0)
                    {
                        counter--;
                    }
                }

                if (counter == 0)
                {
                    transform.Translate(new Vector3(0, releaseMovementPerSec) * Time.deltaTime, Space.World);
                }
            }
        }
    }
}
