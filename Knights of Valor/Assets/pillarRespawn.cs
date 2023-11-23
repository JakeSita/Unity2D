using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pillarRespawn : MonoBehaviour
{
    [SerializeField]
    GameObject pillar1;
    [SerializeField]
    GameObject pillar2;
    [SerializeField]
    GameObject pillar3;
    [SerializeField]
    GameObject pillar4;

    // Update is called once per frame
    void Update()
    {
        if (pillar1 && !pillar1.activeInHierarchy)
        {
            StartCoroutine(ReactivatePillar(pillar1));
        }
        if (pillar2 && !pillar2.activeInHierarchy)
        {
            StartCoroutine(ReactivatePillar(pillar1));
        }
        if (pillar4 && !pillar4.activeInHierarchy)
        {
            StartCoroutine(ReactivatePillar(pillar1));
        }
        if (pillar3 && !pillar3.activeInHierarchy)
        {
            StartCoroutine(ReactivatePillar(pillar1));
        }
    }

    private IEnumerator ReactivatePillar(GameObject pillar)
    {
        yield return new WaitForSeconds(15f);

        pillar.SetActive(true);
    }
}
