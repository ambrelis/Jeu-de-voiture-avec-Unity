using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exercice3 : MonoBehaviour
{
    private float startTime;
    private bool Direction = false;

    public MeshRenderer rend;
    public float delay;
    public Color Color1;
    public Color Color2;

    // Start is called before the first frame update
    void Start()
    {
        if (rend == null) Debug.LogError("MeshRenderer non renseigné");
        rend.material.SetColor("_Color",Color1);
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Direction)
            rend.material.SetColor("_Color",Color.Lerp(Color1,Color2,(Time.time-startTime)/delay));
        else
            rend.material.SetColor("_Color",Color.Lerp(Color2,Color1,(Time.time-startTime)/delay));

        if ((Time.time-startTime)/delay >= 1){
            startTime = Time.time;
            Direction = !Direction;
        }
    }
}
