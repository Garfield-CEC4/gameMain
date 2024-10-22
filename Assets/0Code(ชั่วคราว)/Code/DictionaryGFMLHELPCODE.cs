using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DictionaryGFMLHELPCODE : MonoBehaviour

{
    public List<CC> cCs;

    public Dictionary<string, string> countryCode = new Dictionary<string, string>();

    public string code;

    // Start is called before the first frame update
    void Start()
    {
        foreach (CC entry in cCs)
        {
            code = cCs[0].acronym;

            countryCode.Add(entry.acronym, entry .fullName);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) Debug.Log($"{code} is {countryCode[code]}");
    }
}

[System.Serializable]

public class CC
{

    public string acronym;

    public string fullName;
}
