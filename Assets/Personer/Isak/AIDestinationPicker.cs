using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class AIDestinationPicker : MonoBehaviour
{
    [SerializeField]
    List<GameObject> list = new List<GameObject>();
    [SerializeField]
    GameObject player;

    public WeightedList<GameObject> w_list = new WeightedList<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        ErikManager manager = gameObject.GetComponent<ErikManager>();
        ErikManager.erikSeeCallback += UpdateWeights;
        ErikManager.erikEndPath += UpdateTarget;

        foreach (GameObject go in list)
        {
            WeightedListItem<GameObject> item = new WeightedListItem<GameObject>(go, 0.5f);
            w_list.Add(item);
        }
        gameObject.GetComponent<ErikManager>().SetErikTarget(w_list.RandomItem());
    }

    void UpdateTarget() { gameObject.GetComponent<ErikManager>().SetErikTarget(w_list.RandomItem());
    }
    void UpdateWeights()
    {
        w_list.Sort((a, b) => Vector3.Distance(a.Item.transform.position, player.transform.position).
        CompareTo(Vector3.Distance(b.Item.transform.position, player.transform.position)));


        for(int i = 0; i < w_list.Count; i++)
        {
            //Ljusterar vikten med interpolering :)
            w_list[i].Weight *= (float)(1.25-0.75*Mathf.Cos(Mathf.PI*(i/w_list.Count)));
             
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
