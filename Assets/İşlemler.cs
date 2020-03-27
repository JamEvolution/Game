using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro.EditorUtilities;

public class İşlemler : MonoBehaviour
{

    public GameObject bıçak,elma,trap;
    public Transform spawnpoint;
    public bool gameover;
    public int stage;
    public GameObject[] noktalar;
    public int hedef, atılandoğrubıçak,toplam;
    public Text bıçaksayısıtext,stagetext;
    public GameObject ikon, ikonpaneli, gaveoverpanali, oyuniçipaneli;
    public GameObject[] ikonlar;
    int qq = 0;
    public int elmasayısı;
    
    // Start is called before the first frame update
    void Start()
    {
        gaveoverpanali.SetActive(false);
        oyuniçipaneli.SetActive(true);
        stage = PlayerPrefs.GetInt("aşama",1);
        toplam = PlayerPrefs.GetInt("toplam",0);
        elmasayısı = PlayerPrefs.GetInt("elma", 0);
        bıçaksayısıtext.text = PlayerPrefs.GetInt("toplam").ToString();
        stagetext.text = "Stage : " + stage;
        ObjeSpawn();
        Kontrol();
        İkonYaratma();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameover == true)
        {
            gaveoverpanali.SetActive(true);
            oyuniçipaneli.SetActive(false);
            GameObject.Find("Score").GetComponent<TMPro.TextMeshProUGUI>().text ="Socre :" + toplam.ToString();
        }
        else
        {
            NextStage();
        }
        GameObject.Find("elmasayısı").GetComponent<TMPro.TextMeshProUGUI>().text = elmasayısı.ToString();
    }
    public void GameOver()
    {
        PlayerPrefs.DeleteKey("aşama");
        PlayerPrefs.DeleteKey("toplam");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    void İkonYaratma()
    {
        ikonlar = new GameObject[hedef];
        for (int i = 0; i < hedef; i++)
        {
            GameObject g = Instantiate(ikon, ikonpaneli.transform);
            g.transform.SetParent(ikonpaneli.transform);
            ikonlar[i] = g;
                    
        }

    }

    void Kontrol()
    {
        int a = PlayerPrefs.GetInt("aşama");
        if (a == 1)
        {
            hedef = 4;
        }
        else if(a == 2)
        {
            hedef = 5;
        }
        else if (a == 3)
        {
            hedef = 6;
        }
        else if (a == 4)
        {
            hedef = 7;
        }
        

     }

    void NextStage()
    {
        if (atılandoğrubıçak == hedef)
        {
            stage++;
            PlayerPrefs.SetInt("aşama", stage);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Yeni sahneyi çağırmak .. 
        }


    }



    public void Spawn()
    {
        if (gameover == false)
        {
            GameObject g = Instantiate(bıçak, spawnpoint.transform.position, Quaternion.identity);
            atılandoğrubıçak++;
            toplam++;
            PlayerPrefs.SetInt("toplam",toplam);
            bıçaksayısıtext.text = PlayerPrefs.GetInt("toplam").ToString();
            ikonlar[qq].GetComponent<Image>().color = Color.black;
            qq++;

        }
        
        

    }
    void ObjeSpawn()
    {
        int a = Random.Range(0, 7);
        GameObject g = Instantiate(elma, noktalar[a].transform);
        g.transform.SetParent(noktalar[a].transform);
        int b = Random.Range(0, 7);
        if (b != a)
        {
            GameObject h = Instantiate(trap, noktalar[b].transform.position, Quaternion.identity);
            h.transform.SetParent(noktalar[b].transform);
            if (b == 0)
            {
                noktalar[b].transform.Rotate(0, 0, 180);

            }
            else if (b == 1)
            {
                noktalar[b].transform.Rotate(0, 0, 0);

            }
            else if (b == 2)
            {
                noktalar[b].transform.Rotate(0, 0, -90);

            }
             if (b == 3)
            {
                noktalar[b].transform.Rotate(0, 0, 90);

            }
             if (b == 4)
            {
                noktalar[b].transform.Rotate(0, 0, -135);

            }
             if (b == 5)
            {
                noktalar[b].transform.Rotate(0, 0, 45);

            }
             if (b == 6)
            {
                noktalar[b].transform.Rotate(0, 0, -45);

            }
             if (b == 7)
            {
                noktalar[b].transform.Rotate(0, 0, 140);

            }
            

        }
        else
        {
            b = Random.Range(0, 7); 
        }


    }
}
