using UnityEngine;
using System.Collections;

public class WebCam : MonoBehaviour
{

    public string url = "";
	public Texture2D texture;
    void Start()
    {
        renderer.material.mainTexture = new Texture2D(4, 4, TextureFormat.DXT1, false);
        
    }

    IEnumerator UpdateCam()
    {
        while (true)
        {
            Debug.Log("reloading webcam");
            WWW www = new WWW(url);
            yield return www;
          //  www.LoadImageIntoTexture((Texture2D)renderer.material.mainTexture);
			renderer.material.mainTexture = texture;
        }
    }
}