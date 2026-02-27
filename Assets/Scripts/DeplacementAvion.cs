using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class DeplacementAvion : MonoBehaviour
{
    //===== Variables publiques
    public float vitesse;
    public InputAction onDeplacementVertical;
    public InputAction onDeplacementHorizontal;
    public int points = 0;
    //Sons

    //UI


    //===== Variables privées
    Rigidbody2D rigid;
    //Audiosource
    float deplacementHor = 0;
    float deplacementVert = 0;
    public bool estMort = false;

    //Points

    void OnEnable()
    {
        onDeplacementHorizontal.Enable();
        onDeplacementVertical.Enable();
    }
    void OnDisable()
    {
        onDeplacementHorizontal.Disable();
        onDeplacementVertical.Disable();
    }

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        //Affecter le composant AudioSource à une variable
    }

    void Update()
    {
        if (estMort == false)
        {

            deplacementHor = onDeplacementHorizontal.ReadValue<float>();
            deplacementVert = onDeplacementVertical.ReadValue<float>();
        }
        else
        {
            deplacementHor = 0;
            deplacementVert = -0.1f;
        }

        // Modifier la vélocité linéaire de l'avion.
        rigid.linearVelocityX = deplacementHor * vitesse;
        rigid.linearVelocityY = deplacementVert * vitesse;
    }


 void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            estMort = true;
            GetComponent<Collider2D>().enabled = false;
            rigid.freezeRotation = false;
            rigid.angularVelocity = 500f;
           
        }
    }
 
    // Si le tag du gameobject de la collision est "Obstacle" et que le joueur n'est pas mort
    //// Affecter true à estMort
    //// Déclencher la fonction Mourir
    //Fin OnCollisionEnter2D

    void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "Etoile"){
            points++;
            collision.gameObject.GetComponent<GestionEtoile>().Cacher();
        //     collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        //     collision.gameObject.GetComponent<Collider2D>().enabled = false;
        // }
    }



    // Ajouter une méthode OnTriggerEnter2D
    // Si le tag du gameobject de la collision est "Etoile" et que le joueur n'est pas mort
    //// Accéder au script "GestionEtoile"
    //// Déclencher la fonction publique Cacher de l'étoile
    //// Ajouter un son d'étoile
    //// Ajouter des points
    //// Mettre à jour le texte du UI
    // Fin OnTriggerEnter2D


    void Mourir()
    {
        // Enlever la contrainte de rotation
        // Ajouter une vélocité de rotation
        // Ajouter un son de mort
        // Déclencher la fonction RedemarrerScene après 3sec
    }

    /**
    * Fonction servant à redémarrer la scène actuelle
    */
    void RedemarrerScene()
    {
        string nomSceneCourante = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(nomSceneCourante);
    }

}
