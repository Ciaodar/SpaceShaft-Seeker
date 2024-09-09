using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Movement : MonoBehaviour
    {
        public CharacterController controller;
        public float speed = 8f;
        public float gravity = -9.81f;
        public float jumpHeight = 3f;
        public LayerMask groundMask;
        Vector3 velocity;
    
        public AudioClip footStepSound;
        public float footStepDelay;
 
        private float nextFootstep = 0;
        private AudioSource aSrc;
        private void Start()
        {
            aSrc = GetComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 motion = transform.right * x + transform.forward * z;
            controller.Move(motion * (speed * Time.deltaTime));

            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W))
            {
                nextFootstep -= Time.deltaTime;
                if (nextFootstep <= 0) 
                {
                    aSrc.PlayOneShot(footStepSound, 0.7f);
                    nextFootstep += footStepDelay;
                }
            }
        }
    }