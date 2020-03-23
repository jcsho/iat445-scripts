using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollingStones 
{
    public class TriggerPad : MonoBehaviour
    {
        [Tooltip("Test if capsule is triggered")]
        public bool IsTrigger;

        [Tooltip("Amount to change in y-axis")]
        public float CompressAmount = 0.5f;

        private Collider mTrigger;

        private Vector3 targetPosition;

        // Start is called before the first frame update
        void Start()
        {
            IsTrigger = false;

            mTrigger = GetComponent<Collider>();

            targetPosition = transform.position;

            if (mTrigger == null) 
                Debug.LogError("Missing <color=green>Collider</color> component on " + gameObject.name, gameObject);

            if (mTrigger.isTrigger == false)
                Debug.LogError("Collider's <color=white>Is Trigger</color> property must be true", mTrigger);
        }

        // Update is called once per frame
        void Update()
        {
            //if (transform.position != targetPosition) transform.Translate(targetPosition * Time.deltaTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            IsTrigger = true;
            transform.position = new Vector3(transform.position.x, transform.position.y - CompressAmount, transform.position.z);
            //targetPosition.y = targetPosition.y - CompressAmount;
        }

        private void OnTriggerExit(Collider other)
        {
            IsTrigger = false;
            transform.position = new Vector3(transform.position.x, transform.position.y + CompressAmount, transform.position.z);
            //targetPosition.y = targetPosition.y + CompressAmount;
        }
    }
}
