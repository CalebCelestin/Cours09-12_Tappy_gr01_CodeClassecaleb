using UnityEngine;

public class GestionEtoile : MonoBehaviour
{
    public void Cacher()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        Invoke("Reapparaitre", 2f);
    }

    void Reapparaitre()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Collider2D>().enabled = true;
    }

}
