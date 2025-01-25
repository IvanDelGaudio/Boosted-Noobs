using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

[RequireComponent(typeof(SFX))]
public class PlayerControllerMover : MonoBehaviour
{
    public enum OrientMode : byte
    {
        None, Movement, LookDirection
    }
    private CharacterController characterController = null;

    [Header("Anchors")]
    [SerializeField]
    private Transform renderRoot;

    [Header("Move params")]

    [SerializeField]
    [Min(0.25f)]
    private float speed = 5.0f;

    [SerializeField]
    private float Runspeed = 5.0f;

    [SerializeField]
    private OrientMode orientMode = OrientMode.Movement;

    [SerializeField]
    private Transform spawnPosition;

    private float orientToReachTime = 0.5f;
    private Vector3 orientToCurrentSpeed = Vector3.zero;
    private float verticalSpeed = 0.0f;
    private SFX sfx_;
    private Vector3 initPositionPlayer;
    private Vector3 spawnPositionRefs;

    private bool isGrounded
    {
        get
        {
            return characterController.isGrounded;
        }

    }
    void Awake()
    {
        sfx_ = GetComponent<SFX>();
        characterController = GetComponent<CharacterController>();

        // Ottieni i valori salvati nei PlayerPrefs
        spawnPositionRefs = new Vector3(
            PlayerPrefs.GetFloat("CheckpointPositionX", 0.0f), // Default a 0.0f se il valore non esiste
            PlayerPrefs.GetFloat("CheckpointPositionY", 0.0f),
            PlayerPrefs.GetFloat("CheckpointPositionZ", 0.0f)
        );

        // Controlla se i PlayerPrefs sono validi
        if (spawnPositionRefs == Vector3.zero) // Nessun checkpoint salvato
        {
            transform.position = spawnPosition.position;

            // Salva la posizione iniziale come checkpoint
            PlayerPrefs.SetFloat("CheckpointPositionX", spawnPosition.position.x);
            PlayerPrefs.SetFloat("CheckpointPositionY", spawnPosition.position.y);
            PlayerPrefs.SetFloat("CheckpointPositionZ", spawnPosition.position.z);
            PlayerPrefs.Save();
        }
        else // Posiziona il giocatore all'ultimo checkpoint salvato
        {
            transform.position = spawnPositionRefs;
        }
    }

    private void OnEnable()
    {
        Save.OnSave += UpdateCheckpoint;

    }
    private void OnDestroy()
    {
        Save.OnSave -= UpdateCheckpoint;
    }
    void Start()
    {

        if (renderRoot != null)
            renderRoot.position -= transform.up * characterController.skinWidth;
    }
    void FixedUpdate()
    {
        if (isGrounded)
            verticalSpeed = 0.0f;
        verticalSpeed -= 9.81f * Time.deltaTime;
    }
    void Update()
    {
        Vector3 moveDirection = Vector3.zero;
        Transform cam = Camera.main.transform;
        moveDirection += Input.GetAxis("Horizontal") * cam.right;
        moveDirection += Input.GetAxis("Vertical") * cam.forward;
        float moveMagnitude = moveDirection.magnitude;
        moveDirection.y = 0.0f;
        moveDirection.Normalize();
        moveDirection *= moveMagnitude;
        initPositionPlayer = transform.position;
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = speed * Runspeed;
            Debug.Log("Is run");
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = speed / Runspeed;
            Debug.Log("Is not run");
        }

        Move(moveDirection * speed);

        if (Input.GetKeyUp(KeyCode.E))
        {



        }
        if (orientMode != OrientMode.None)
        {
            Quaternion targetRotation = transform.rotation;
            switch (orientMode)
            {
                case OrientMode.Movement:
                    if (moveDirection.sqrMagnitude > Mathf.Epsilon)
                    {
                        targetRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
                    }
                    break;
                case OrientMode.LookDirection:
                    Vector3 cameraLookDirection = Camera.main.transform.forward;
                    cameraLookDirection.y = 0.0f;

                    if (cameraLookDirection.sqrMagnitude > Mathf.Epsilon)
                        targetRotation = Quaternion.LookRotation(cameraLookDirection, Vector3.up);
                    break;
                default:
                    break;
            }
            transform.rotation = SmoothDampRotation(transform.rotation, targetRotation, ref orientToCurrentSpeed, orientToReachTime);
        }

    }
    private void UpdateCheckpoint(Vector3 newCheckpoint)
    {
        // Update the current spawn position
        spawnPositionRefs = newCheckpoint;
        Debug.Log("Checkpoint updated to: " + spawnPosition);
    }

    public void Move(Vector3 direction)
    {
        direction += Vector3.up * verticalSpeed;
        characterController.Move(direction * Time.deltaTime);
        Vector3 vector3 = new Vector3(1.0f, 0.0f, 1.0f);
        if (transform.position != initPositionPlayer)
        {
            sfx_.PlaySFX(0);
        }
    }

    public void Run()
    {

    }


    private static Quaternion SmoothDampRotation(Quaternion from, Quaternion to, ref Vector3 currentVelocity, float smoothTime)
    {
        Vector3 fromEuler = from.eulerAngles;
        Vector3 toEuler = to.eulerAngles;

        Vector3 smoothedAngle = new Vector3(
            Mathf.SmoothDampAngle(fromEuler.x, toEuler.x, ref currentVelocity.x, smoothTime),
            Mathf.SmoothDampAngle(fromEuler.y, toEuler.y, ref currentVelocity.y, smoothTime),
            Mathf.SmoothDampAngle(fromEuler.z, toEuler.z, ref currentVelocity.z, smoothTime)
        );

        return Quaternion.Euler(smoothedAngle);
    }

}