using UnityEngine;
using TMPro;

public class TextAnimator : MonoBehaviour
{
    public TMP_Text logo_text;
    [SerializeField]
    private float time = 0.25f;
    [SerializeField]
    private string text = "CrashPast";
    [SerializeField]
    private bool loop = true;
    private int i = 0;
    private bool site = true;
    [SerializeField]
    private bool hide = false;
    [SerializeField]
    private float fadeOut = 1f;

    // Start is called before the first frame update
    void Start()
    {
        logo_text.text = "";
        InvokeRepeating("OutputTime", time, time);   
    }

    // Update is called once per frame
    void OutputTime() {

        if (site) {
            logo_text.text += text[i];
            if (text[i] == ':') logo_text.text += "\n";
            i++;
            if (i == text.Length ) {
                if(loop) {
                    site = false;
                } else {
                    CancelInvoke("OutputTime");
                    if (hide) {
                        InvokeRepeating("Hide", fadeOut, fadeOut);
                    }
                }
            }
        }
        else {
            logo_text.text = logo_text.text.Substring(0, i-1);
            i--;
            if (i == 0) {
                site = true;
            }
        }
    }
    void Hide() {
        logo_text.text = "";
        CancelInvoke("Hide");
    }
}