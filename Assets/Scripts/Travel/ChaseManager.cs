using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseManager : MonoBehaviour
{
    [SerializeField] GameObject jerFighter;
    Context context;
    // Start is called before the first frame update
    void Awake()
    {
        context = Context.Instance;
        if (context.isChase)
            jerFighter.SetActive(true);
        else
            jerFighter.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
