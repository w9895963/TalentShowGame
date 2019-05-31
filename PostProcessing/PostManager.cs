using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


//
//
//

[ExecuteInEditMode]
public class PostManager : MonoBehaviour {
    public bool editorMode;
    public bool log;

    public RenderTexture renderTextureTemplate;
    private RenderTexture t;
    public Camera renderCamera;
    public int renderMultipler = 2;
    public MeshRenderer postScreen;
    public Camera postCamera;
    public string postShaderPropertyName = "_Texture";

    public int width;
    public int height;

    void Start () {
        // Debug.Log(789);
        renderCamera = renderCamera == null? Camera.main : renderCamera;
        postCamera.enabled = true;

        ApplyTexture ();

    }
    void Update () {

        if (t.height != postCamera.pixelHeight * renderMultipler | t.width != postCamera.pixelWidth * renderMultipler) {

            if (editorMode?true : Application.isPlaying) {


                ApplyTexture ();
            }


        }
    }

    private void OnValidate () { }


    private void OnEnable () {
        //Debug.Log (456);
        renderCamera = renderCamera == null? Camera.main : renderCamera;
        postCamera.enabled = true;
        ApplyTexture ();
    }

    private void OnDisable () {
        //Debug.Log (123);
        renderCamera.targetTexture = null;
        postCamera.enabled = false;
    }


    private void ApplyTexture () {

        if (log) Debug.Log ("成功设置渲染图层", gameObject);


        height = postCamera.pixelHeight;
        width = postCamera.pixelWidth;


        t = new RenderTexture (renderTextureTemplate);
        t.width = postCamera.pixelWidth * renderMultipler;
        t.height = postCamera.pixelHeight * renderMultipler;
        t.filterMode = FilterMode.Point;
        renderCamera.targetTexture = t;

        postScreen.sharedMaterial.SetTexture (postShaderPropertyName, t);
    }


}