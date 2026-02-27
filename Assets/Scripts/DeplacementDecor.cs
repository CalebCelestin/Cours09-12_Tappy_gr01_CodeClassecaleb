using UnityEngine;

public class DeplacementDecor : MonoBehaviour
{
    public float vitesse;
    public float limiteGc;
    public float limiteDr;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(vitesse * Time.deltaTime, 0, 0);
        if (transform.position.x < limiteGc)
        {
            transform.position = new Vector2(limiteDr, transform.position.y);
        }
    }
}
