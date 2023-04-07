using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstPersonController : MonoBehaviour
{
    private static float defaultMoveSpeed = 2f;
    private static float defaultJumpForce = 3f;
    private static float defaultLookSensitivity = 2f;
    private static float defaultCrouchScale = 0.45f;
    private float moveSpeed = defaultMoveSpeed;
    private float jumpForce = defaultJumpForce;
    private float lookSensitivity = defaultLookSensitivity;
    [SerializeField] private float maxLookUpAngle = 80f;
    [SerializeField] private float maxLookDownAngle = -80f;
    [SerializeField] private LayerMask mask;
    [SerializeField] private AudioSource audio3;
    [SerializeField] private AudioSource audio2;
    [SerializeField] private AudioSource audio;
    [SerializeField] private AudioSource bgMusic;
    [SerializeField] private TextMeshProUGUI notesLeftText;
    [SerializeField] private GameObject finalClipboard;
    [SerializeField] private GameObject easterEggMushroom;
    
    private PlayerUI playerUI;
    
    public float crouchSpeed = 2f;
    public float crouchScale = defaultCrouchScale;

    private Rigidbody rb;
    private Camera playerCamera;
    private float verticalRotation = 0f;
    private bool isCrouching = false;
    private Vector3 originalScale;
    private float usageDistance = 3f;
    private bool isNoteShowed = false;
    private string noteSceneName;
    private bool isPlayerFreezed = false;
    private int notesLeft;
    
    private ImageFrameActions interaction;
    private string dataToSave = "";


    private void LoadState()
    {
        string[] data = PlayerPrefs.GetString("Save").Split("|");
        GameObject[] allNotes = GameObject.FindGameObjectsWithTag("ImageFrame");
        foreach (var singleNote in allNotes)
        {
            Debug.Log(singleNote.name);
            foreach (var noteName in data)
            {
                dataToSave += noteName+"|";
                if (singleNote.name == noteName)
                {
                    singleNote.SetActive(false);
                }
                else if (noteName == "EasterEggMushroom")
                {
                    easterEggMushroom.SetActive(false);
                }
            }
        }
    }
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerCamera = GetComponentInChildren<Camera>();
        playerUI = GetComponent<PlayerUI>();
        Cursor.lockState = CursorLockMode.Locked;
        originalScale = transform.localScale;
        finalClipboard.SetActive(false);
    }

    private void Start()
    {
        audio2.mute = true;
        audio3.mute = true;
        bgMusic.loop = true;
        //bgMusic.enabled = true;
        LoadState();
        GameObject[] getAllNotes = GameObject.FindGameObjectsWithTag("ImageFrame");
        foreach (var singleNote in getAllNotes)
        {
            if (singleNote.activeSelf) notesLeft++;
        }

        
        if (notesLeft <= 0)
        {
            notesLeftText.SetText("FINAL NOTE UNLOCKED!");
            finalClipboard.SetActive(true);
        }
        else
        {
            notesLeftText.SetText("notes left: " + notesLeft);
        }
    }
    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * lookSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * lookSensitivity;

        transform.Rotate(Vector3.up * mouseX);

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, maxLookDownAngle, maxLookUpAngle);
        playerCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);

        
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        playerUI.UpdateText(string.Empty);
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        Debug.DrawRay(ray.origin,ray.direction * usageDistance);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, usageDistance, mask))
        {
            if (hitInfo.collider.GetComponent<ImageFrameActions>() != null)
            {
                interaction = hitInfo.collider.GetComponent<ImageFrameActions>();
                playerUI.UpdateText(interaction.noteMessage);
                if (Input.GetKeyUp(KeyCode.E))
                {
                    if (interaction.tag != "EasterEgg_Mushroom")
                    {
                        moveSpeed = 0f;
                        lookSensitivity = 0f;
                        jumpForce = 0f;
                        crouchScale = 0.75f;
                        isNoteShowed = true;
                        noteSceneName = interaction.noteSceneName;
                        audio2.mute = false;
                        audio2.Play();
                        isPlayerFreezed = true;
                        notesLeftText.SetText(string.Empty);
                        notesLeft -= 1;
                        Debug.Log("Added: "+interaction.name);
                        if (notesLeft <= 0)
                        {
                            notesLeftText.SetText("FINAL NOTE UNLOCKED!");
                            finalClipboard.SetActive(true);
                        }
                    }
                    else
                    {
                        audio3.mute = false;
                        audio3.Play();
                        defaultMoveSpeed += 2;
                        moveSpeed = defaultMoveSpeed;
                        playerCamera.fieldOfView = 90;
                    }
                    Debug.Log("collected: "+interaction.name);
                    dataToSave += interaction.name+"|";
                    interaction.BaseInteract();
                }
            }
        }

        if (isNoteShowed)
        {
            PlayerPrefs.SetString("Save", dataToSave);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                notesLeftText.SetText("notes left: "+notesLeft);
                if (noteSceneName != "")
                {
                    Debug.Log("Loading scene: " + noteSceneName);
                    SceneManager.LoadScene(noteSceneName);
                    Cursor.lockState = CursorLockMode.None;
                    noteSceneName = "";
                }
                else
                {
                    isPlayerFreezed = false;
                    isNoteShowed = false;
                    moveSpeed = defaultMoveSpeed;
                    lookSensitivity = defaultLookSensitivity;
                    jumpForce = defaultJumpForce;
                    crouchScale = defaultCrouchScale;
                    interaction.HideInteract();
                }
            }
        }


        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            isCrouching = true;
            transform.localScale = new Vector3(originalScale.x, crouchScale, originalScale.z);
            transform.position = new Vector3(transform.position.x, transform.position.y - crouchScale, transform.position.z);
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            isCrouching = false;
            transform.localScale = originalScale;
        }

        if (
            Input.GetKey(KeyCode.W)
            || Input.GetKey(KeyCode.S)
            || Input.GetKey(KeyCode.A)
            || Input.GetKey(KeyCode.D)
            )
        {
            if (!isPlayerFreezed)
            {
                audio.loop = true;
                audio.enabled = true;
            }
        }
        else
        {
            audio.enabled = false;
        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            PlayerPrefs.SetString("Save", dataToSave);
            SceneManager.LoadScene("PauseMenu");
        }
    }

    private void FixedUpdate()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        Vector3 movement = transform.right * moveX + transform.forward * moveZ;
        movement = movement.normalized * moveSpeed;
        //rb.MovePosition(rb.position + movement);
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);

    }

    private void Jump()
    {
        if (IsGrounded())
        {
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }
    }

    private bool IsGrounded()
    {
        float distance = GetComponent<Collider>().bounds.extents.y + 0.1f;
        return Physics.Raycast(transform.position, Vector3.down, distance);
    }
}
