///////////////////////////////////////////////////////////////////////////////
// ShadowTransform by Ivan Klenov (aka Wolf4D). 2017.
//
// All rights reserved.
// Under Creative Commons Attribution (CC BY) License.
// So, use it as you wish, just include me in credits.
/////////////////////////////
//
// Main script for ShadowTransform. A heart of it all :)
// Idea is simple too - just let's hold some structs with obj's parameters
// for an each of states. If any parameter of obj differs from all of the saved
// states - object is not in any of saved states. Else - if some state has that
// values of pos, rot and scale - so, object is in that state :)
//
///////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

///////////////////////////////////////////////////////////////////////////////
// Structure for holding a state's parameters

[System.Serializable]  // else we could not save states in scenes
public class ShadowState
{
    public string name = "";    // name for state
    public Vector3 position;    // absolute (world) pos of object in this state
    public Vector3 eulerAngles; // absolute (world) rotation of object
    public Vector3 lossyScale;  // absolute (world) scale of object
};

///////////////////////////////////////////////////////////////////////////////

[DisallowMultipleComponent]
public class ShadowTransform : MonoBehaviour
{
    // List of ShadowStates. It's called phantoms, cause we already have word
    // "shadow" in every corner of our programm :)
    [SerializeField] public List<ShadowState> phantoms = new List<ShadowState>();

    // TODO: make a shadow color adjustable sometimes somehow
    public Color shadowColor = new Color (0.6f, 0.15f, 0.7f, 0.4f);

/////////////////////////////

    void Awake ()
    {
        if (this.gameObject.GetComponents<ShadowTransform> ().Length > 1)
        {
            Debug.LogWarning ("This GameObject (" + this.gameObject.name +") already has one shadow transform!");
            Destroy (this);
        }
    }

/////////////////////////////

    // Add new phantom with current rot/pos/scale and defined name
    public void AddPhantom(string pname)
    {
        ShadowState newPhantom = new ShadowState ();

        newPhantom.name = pname; // + " (" + phantoms.Count + ")";
        newPhantom.position = this.gameObject.transform.position;
        newPhantom.eulerAngles = this.gameObject.transform.eulerAngles;

        // Hack for calculating global scale - unparent an object,
        // define it's scale, parent it back
        Transform cparent = this.gameObject.transform.parent;
        this.gameObject.transform.SetParent (null);
        newPhantom.lossyScale = this.gameObject.transform.lossyScale;
        this.gameObject.transform.SetParent (cparent);

        // add new phantom to the phantom array
        phantoms.Add (newPhantom);

        // called manually to draw gizmo before first scene redraw
        EditorUtility.SetDirty(this);

    }

/////////////////////////////

    // Change object pos/rot/scale to some saved state by its id
    public void SwitchToPhantom(int id)
    {
        if ((id >= 0) && (id < phantoms.Count))
        {
            this.transform.position = phantoms [id].position;
            this.transform.rotation = Quaternion.Euler (phantoms [id].eulerAngles);

            // Same parenting hack as before
            Transform cparent = this.transform.parent;
            this.transform.SetParent (null);
            this.transform.localScale = phantoms[id].lossyScale;
            this.gameObject.transform.SetParent (cparent);
        }
    }

/////////////////////////////

    // Removes state from phantom array
    public void DeletePhantom()
    {
        phantoms.Remove(phantoms[CurrentPhantom()]);
        EditorUtility.SetDirty(this);
    }

/////////////////////////////

    // Finds what state has such a pos/rot/scale as object has
    // at this moment, and returns phantom's id. Returns -1 if
    // phantom wasn't found
    public int CurrentPhantom()
    {
        int current = -1;
        foreach (ShadowState obj in phantoms)
            if (obj!=null)
            {
                // Here you need to do a fuzzy compare of vectors.
                // Standard procedure of comparing is not good, cause floating
                // point numbers ars so floaty, and 1.0f may turn into
                // 1.0000001 or 0.9999999. Unity makes some inside works, so
                // you can compare vectors and get a good results... most of the time.
                // But sometimes it does not work, so it needs to be fuzzy
                if (VectorsAreEqual(obj.position, this.transform.position) &&
                    VectorsAreEqual(obj.eulerAngles, this.transform.eulerAngles) &&
                    VectorsAreEqual(obj.lossyScale, this.transform.lossyScale))
                        current = phantoms.LastIndexOf (obj);
            }

        return current;
    }

/////////////////////////////

    // Draws all object shadows
    void OnDrawGizmos()
    {
        Gizmos.color = shadowColor;
        MeshFilter meshFilter = this.GetComponent<MeshFilter> ();

        foreach (ShadowState obj in phantoms)
        {
            // We won't draw a mesh this for a static object during play - you
            // just should not move static objects during runtime!
            if (!(this.gameObject.isStatic && Application.isPlaying))
            {
				if (meshFilter != null)
					Gizmos.DrawMesh (meshFilter.sharedMesh, obj.position, Quaternion.Euler (obj.eulerAngles), obj.lossyScale);
				else
					Gizmos.DrawCube (obj.position, obj.lossyScale); // a placeholder object
            }

            // Unity's behaviour for handles is kinda strange - handles are
            // being drawn near the edge of the screen even when theirs
            // "mounting point" is not visible. So, we need to "filter" handles
            // to drop out must-be-invisible ones.

            // Projecting "mounting point" to the screen
            Vector3 objInView = Camera.current.WorldToViewportPoint (obj.position);

            // Is point on screen?
            if ((objInView.x>=0)
                 && (objInView.x<=1)
                 && (objInView.y>=0)
                 && (objInView.y<=1)
                 && (objInView.z>0))
                    Handles.Label (obj.position, "[" + this.gameObject.name + "]\n" + obj.name + " (" + phantoms.LastIndexOf(obj) + ")");

            //Gizmos.DrawIcon (obj.position, "shadowtransformicon.png");
        }
    }

/////////////////////////////

    // A simple fuzzy compare
    bool VectorsAreEqual(Vector3 one, Vector3 two)
    {
        return (Mathf.Approximately (one.x, two.x) &&
                        Mathf.Approximately (one.y, two.y) &&
                        Mathf.Approximately (one.z, two.z));
    }

}

///////////////////////////////////////////////////////////////////////////////
// If you need any help, wanna make a proposal, need some advice or
// want to employ me, feel free to e-mail me: Wolf4D@list.ru
///////////////////////////////////////////////////////////////////////////////
