using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashing_Flash : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    private Material originalMaterial;

    public Material flashingMaterial;

    private float startflash = 0f;
    private float endFlash = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        originalMaterial = spriteRenderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Flashing()
    {
        //ON
        spriteRenderer.material = flashingMaterial;
        startflash = Time.timeSinceLevelLoad;
        if(Time.timeSinceLevelLoad - startflash > endFlash)
        {
            //OFF
            Flash();
        }
        //ON
        startflash = Time.timeSinceLevelLoad;
        if (Time.timeSinceLevelLoad - startflash > endFlash)
        {
            spriteRenderer.material = flashingMaterial;
        }
        //OFF
        startflash = Time.timeSinceLevelLoad;
        if (Time.timeSinceLevelLoad - startflash > endFlash)
        {
            Flash();
        }
    }

    void Flash()
    {
        spriteRenderer.material = originalMaterial;

    }
    
}
