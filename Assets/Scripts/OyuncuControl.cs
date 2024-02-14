using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OyuncuControl : MonoBehaviour
{

    public Transform bulletPos;
    public GameObject bullet;
    public GameObject explosion;
    public float lifeValue;
    public Image lifeImage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Mouse0)) {
        
            GameObject go = Instantiate(bullet,bulletPos.position,bulletPos.rotation) as GameObject;
            GameObject goExplosion = Instantiate(explosion, bulletPos.position, bulletPos.rotation) as GameObject;

            go.GetComponent<Rigidbody>().velocity = bulletPos.transform.forward * 5f;
            Destroy(go.gameObject, 2f);
            Destroy(goExplosion.gameObject, 2f);

        }
        
    }

    public void OnCollisionEnter(Collision c)
    {
        if (c.collider.gameObject.tag.Equals("zombi"))
        {   lifeValue -= 10f;
            float x = lifeValue / 100f;
            
            lifeImage.fillAmount = x;
            lifeImage.color = Color.Lerp(Color.red, Color.green, x);
        }
    }
    private void OnTriggerEnter(Collider c)
    {
        if(c.gameObject.tag.Equals("heart"))
        {   lifeValue += 20f;
            float x = lifeValue / 100f;
            
            lifeImage.fillAmount = x;
            lifeImage.color = Color.Lerp(Color.red, Color.green, x);
            Destroy(c.gameObject);
        }
    }
}
