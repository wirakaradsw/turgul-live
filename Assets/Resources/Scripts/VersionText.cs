using UnityEngine;
using UnityEngine.UI;

public class VersionText : MonoBehaviour
{
    public Text versionText;

    void Start()
    {
        int yearNow = System.DateTime.Now.Year;
        //versionText.text = "© 2023 DYNAMIC SOUL WORKS | Version " + Application.version;
        versionText.text = "TURGUL® RAPID FIGHTING, VERSION " + Application.version + "\r\n© DYNAMIC SOUL WORKS, 2016 - " + yearNow.ToString();
    }

}
