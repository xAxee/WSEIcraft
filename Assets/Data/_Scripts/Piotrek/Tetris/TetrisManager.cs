using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TetrisManager : MonoBehaviour
{

    public GameObject tetrCube;
    public GameObject homeObject;
    public float generateHeight = 20f;
    public Transform parent;

    private int currentStep = 0;

    [SerializeField] private AudioSource backgroundMusic;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Steps", 2.0f, 3f);
        backgroundMusic.mute = false;
        backgroundMusic.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Steps()
    {
        switch (currentStep)
        {
            case 0:
                generate(0, 0, "I");
                generate(6, 6, "T");
                break;
            case 1:
                generate(7, 7, "-Z");
                generate(3, 3, "L");
                break;
            case 2:
                generate(1, 1, "O");
                generate(4, 4, "T");
                generate(9, 9 , "I");
                break;
            case 3:
                generate(1, 1, "O");
                generate(4, 4, "O");
                break;
            case 4:
                generate(6, 6, "Z");
                generate(2, 2, "-Z");
                break;
            case 5:
                generate(6, 6, "T");
                generate(1, 1, "L");
                break;
            case 6:
                generate(6, 6, "I");
                generate(3, 3, "O");
                break;
            case 7:
                generate(3, 3, "Z");
                generate(5, 5, "-L");
                break;
            case 8:
                generate(7, 7, "I");
                generate(1, 1, "O");
                break;
            case 9:
                generate(3, 3, "L");
                generate(8, 8, "T");
                break;
            case 10:
                generate(4, 4, "Z");
                generate(6, 6, "-L");
                break;
            case 11:
                generate(2, 2, "I");
                generate(0, 0, "I");
                break;
            case 12:
                generate(0, 0, "O");
                generate(7, 7, "-Z");
                break;
            case 13:
                generate(8, 8, "O");
                generate(1, 1, "Z");
                break;
            case 14:
                generate(7, 7, "T");
                generate(1, 1, "L");
                break;
            case 15:
                generate(1, 1, "O");
                generate(7, 7, "-L");
                break;
            case 16:
                generate(0, 1, "I");
                generate(0, 7, "I");
                break;
            case 17:
                generate(5, 1, "-Z");
                generate(7, 7, "Z");
                break;
            case 18:
                win();
                break;

        }
        currentStep++;
    }
    void win()
    {
        SceneManager.LoadScene("Forest");
    }
    void generate(int x,int y,string figureType)
    {
    
        switch (figureType)
        {
            case "O":
                generateCubeAtPosition(0 + x, 0 + y, Color.yellow);
                generateCubeAtPosition(0 + x, 1 + y, Color.yellow);
                generateCubeAtPosition(1 + x, 0 + y, Color.yellow);
                generateCubeAtPosition(1 + x, 1 + y, Color.yellow);
                break;
            case "L":
                generateCubeAtPosition(0 + x, 1 + y, Color.green);
                generateCubeAtPosition(0 + x, 2 + y, Color.green);
                generateCubeAtPosition(0 + x, 3 + y, Color.green);
                generateCubeAtPosition(1 + x, 1 + y, Color.green);
                break;
            case "-L":
                generateCubeAtPosition(0 + x, 0 + y, Color.blue);
                generateCubeAtPosition(0 + x, 1 + y, Color.blue);
                generateCubeAtPosition(0 + x, 2 + y, Color.blue);
                generateCubeAtPosition(-1 + x, 0 + y, Color.blue);
                break;
            case "Z":
                generateCubeAtPosition(0 + x, 1 + y, Color.red);
                generateCubeAtPosition(1 + x, 1 + y, Color.red);
                generateCubeAtPosition(1 + x, 0 + y, Color.red);
                generateCubeAtPosition(2 + x, 0 + y, Color.red);
                break;
            case "-Z":
                generateCubeAtPosition(0 + x, 0 + y,Color.gray);
                generateCubeAtPosition(1 + x, 0 + y, Color.gray);
                generateCubeAtPosition(1 + x, 1 + y, Color.gray);
                generateCubeAtPosition(2 + x, 1 + y, Color.gray);
                break;
            case "T":
                generateCubeAtPosition(0 + x, 0 + y,Color.magenta);
                generateCubeAtPosition(1 + x, 0 + y, Color.magenta);
                generateCubeAtPosition(2 + x, 0 + y, Color.magenta);
                generateCubeAtPosition(1 + x, 1 + y, Color.magenta);
                break;
            case "I":
                generateCubeAtPosition(0 + x, 0 + y,Color.cyan);
                generateCubeAtPosition(0 + x, 1 + y, Color.cyan);
                generateCubeAtPosition(0 + x, 2 + y, Color.cyan);
                generateCubeAtPosition(0 + x, 3 + y, Color.cyan);
                break;
        }
    }

    void generateCubeAtPosition(int x,int y, Color color)
    {
        GameObject obj = Instantiate(tetrCube, new Vector3(homeObject.transform.position.x + 2f * x, generateHeight + 2f * y, homeObject.transform.position.z), Quaternion.identity, parent);
        MeshRenderer cubeRenderer = obj.transform.GetChild(0).GetComponent<MeshRenderer>();
        cubeRenderer.material.SetColor("_BaseColor",color);
    }
}
