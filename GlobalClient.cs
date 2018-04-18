using UnityEngine;
using System.Collections;

public class GlobalClient : MonoBehaviour
{

    public static GlobalClient Instance;


    protected CameraController mCamController;
    

    void Awake()
    {
        Instance = this;
    }

   
}
