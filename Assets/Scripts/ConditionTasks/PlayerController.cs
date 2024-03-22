using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float Xmove;
    float ZMove;
    public float speed;
    public GameObject Mask;
    public bool MaskOn;

    public CharacterController characterController;

    public string MicName;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //Find all mics in computer
        if (Microphone.devices.Length > 0)
        {
            MicName = Microphone.devices[0].ToString();
            //Start Recording
            audioSource.clip = Microphone.Start(MicName, true, 2, AudioSettings.outputSampleRate);
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Xmove = Input.GetAxis("Horizontal") * speed;
        ZMove = Input.GetAxis("Vertical") * speed;

        Vector3 move = transform.right * Xmove + transform.forward * ZMove;

        characterController.Move(move * speed * Time.deltaTime);

        Mask.SetActive(MaskOn);
    }
}
