using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.iOS;

public class ScreenLineRenderer : MonoBehaviour {

    // Line Drawn event handler
    public delegate void LineDrawnHandler(Vector3 begin, Vector3 end, Vector3 depth);
    public event LineDrawnHandler OnLineDrawn;
    public static bool split;

    bool dragging;
    Vector3 start;
    Vector3 end;
    Camera cam;

    public Material lineMaterial;

    // Use this for initialization
    void Start () {
        cam = Camera.main;
        dragging = false;
    }

    private void OnEnable()
    {
        Camera.onPostRender += PostRenderDrawLine;
    }

    private void OnDisable()
    {
        Camera.onPostRender -= PostRenderDrawLine;
    }

    // Update is called once per frame
    void Update () {
        //if (Input.touchCount > 0 && !MouseSlice.slicedAny)
        if(Input.GetButtonDown("Fire1") && !MouseSlice.slicedAny)
        {
            start = new Vector3(0.5f,0.0f,0.0f);
            end = new Vector3(0.5f, 1.0f, 0.0f);
            //dragging = true;
            //print(cam.ScreenToViewportPoint(Input.mousePosition));
            split = false;
        
            // Finished dragging. We draw the line segment
            //end = cam.ScreenToViewportPoint(Input.mousePosition);
            dragging = false;

            var startRay = cam.ViewportPointToRay(start);
            var endRay = cam.ViewportPointToRay(end);

            // Raise OnLineDrawnEvent
            OnLineDrawn?.Invoke(
                startRay.GetPoint(cam.nearClipPlane),
                endRay.GetPoint(cam.nearClipPlane),
                endRay.direction.normalized);
        }

    }
    

    /// <summary>
    /// Draws the line in viewport space using start and end variables
    /// </summary>
    private void PostRenderDrawLine(Camera cam)
    {
        if (dragging && lineMaterial)
        {
            GL.PushMatrix();
            lineMaterial.SetPass(0);
            GL.LoadOrtho();
            GL.Begin(GL.LINES);
            GL.Color(Color.black);
            GL.Vertex(start);
            GL.Vertex(end);
            GL.End();
            GL.PopMatrix();
        }
    }
}
