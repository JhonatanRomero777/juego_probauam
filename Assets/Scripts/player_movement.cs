using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_movement : MonoBehaviour
{
    private AudioSource reproductor;
    // public AudioClip[] = audios;

    public string txtValue = "0 / 8 Sentadillas";
    public Text txtElement;

    public float velocidad;
    private Transform target;
    public float DISTANCIA_MINIMA = 0;
    public GameObject[] points;
    private int cont;

    // Start is called before the first frame update
    void Start()
    {
      this.reproductor = GetComponent<AudioSource>();
      // this.reproductor.clip = audios[0];
      // this.reproductor.play();

      this.cont = 0;
      this.velocidad = 75;
      this.target = points[this.cont].GetComponent<Transform>();

      this.txtElement.text = txtValue;
    }

    // Update is called once per frame
    void Update()
    {  
      this.txtElement.text = txtValue;

      if (Vector3.Distance(this.transform.position, this.target.position) > DISTANCIA_MINIMA)
      {
        this.transform.position = Vector3.MoveTowards(this.transform.position, this.target.position, this.velocidad * Time.deltaTime);
      }
      else
      {
        cont++;
        if(cont < points.Length) this.target = points[cont].GetComponent<Transform>();
      }
    }
    void OnTriggerEnter(Collider other)
    {
      if (other.tag.Equals("Rampa"))
        {
          Debug.Log(other.tag);
          this.target = points[1].GetComponent<Transform>();
          
        }
           
    }
}