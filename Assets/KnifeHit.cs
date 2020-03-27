using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeHit : MonoBehaviour
{
    Rigidbody2D rb;
    İşlemler kod;
    AudioSource kaynak;
    public AudioClip ses;
    public GameObject elmaefekt;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponentInParent<Rigidbody2D>();
        kod = GameObject.Find("İşlemler").GetComponent<İşlemler>();
        kaynak = this.GetComponentInParent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag =="kabza" || other.gameObject.tag == "Trap")
        {
            kaynak.PlayOneShot(ses);
            rb.velocity = new Vector2(rb.velocity.x, -20.0f);
            kod.gameover = true;
        }
        if (other.gameObject.tag == "elma")
        {
            elmaefekt.SetActive(true);
            kod.elmasayısı++;
            PlayerPrefs.SetInt("elma", kod.elmasayısı);
            Destroy(elmaefekt, 2.0f);
            Destroy(other.gameObject);

        }
    }
}
