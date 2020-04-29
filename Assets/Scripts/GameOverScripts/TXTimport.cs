using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TXTImport : MonoBehaviour
{
    public TextAsset txtFile;
    public string[] txtLines;
    // Start is called before the first frame update
    void Start()
    {
        if(txtFile != null)
        {
            txtLines = (txtFile.text.Split('\n'));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
