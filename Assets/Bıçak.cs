using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bıçak : MonoBehaviour
{
    public float hız;
    Rigidbody2D rb;
    public bool hazır;
    İşlemler erişim;
    BoxCollider2D col;
    AudioSource kaynak;
    public AudioClip sestahta;
    public GameObject tahtaefekt;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hazır = true;
        erişim = GameObject.Find("İşlemler").GetComponent<İşlemler>();
        col = GetComponent<BoxCollider2D>();
        kaynak = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && hazır== true )
        {
            Fırlatma();
        }
    }
    void Fırlatma()
    {
        rb.velocity = new Vector2(0, hız);
        hazır = false;

    }
        void OnCollisionEnter2D(Collision2D other)
    {
            if (other.gameObject.name == "Trunk")

            {
                kaynak.PlayOneShot(sestahta);
                tahtaefekt.SetActive(true);
                Destroy(tahtaefekt, 2.0f);
                rb.isKinematic = true;
                rb.velocity = new Vector2(0, hız);
                transform.SetParent(other.transform); // Bıçak ile Trunk birlikte bir obje oluyor
                col.enabled = false; // Collider'ı kapatıyoruz bıçakla düzgün dönmesi için .. 
                erişim.Spawn();
            }
       
    }
}
