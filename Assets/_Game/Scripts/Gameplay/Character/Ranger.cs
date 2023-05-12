using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranger : MonoBehaviour
{
    private Transform tF;

    public List<Character> listCharacter =  new List<Character> ();
    private void Awake()
    {
        tF = transform;
    }
    private void OnTriggerEnter(Collider other)
    {
        Character character = other.GetComponent<Character>();
        if (other.CompareTag(Constans.TAG_ENEMY) || other.CompareTag(Constans.TAG_PLAYER))
        {
            if (character.isDie)
            {
                if (listCharacter.Contains(character))
                {
                    listCharacter.Remove(character);
                }
                else
                {
                    listCharacter.Remove(character);
                }
            }
            else
            {
                listCharacter.Add(character);
            }
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Character character = other.GetComponent<Character>();
        if (other.CompareTag(Constans.TAG_ENEMY) || other.CompareTag(Constans.TAG_PLAYER))
        {
            listCharacter.Remove(character);
        }
    }

    public Character CharacterInRanger()
    {

        Character character = new Character();
        float distance = float.MaxValue;
        foreach(Character cha in listCharacter)
        {
            float maxdistance = Vector3.Distance(tF.position, cha.transform.position);
            if (maxdistance < distance)
            {
                character = cha;
                distance = maxdistance;
            }
        }
        if (character != null&&!character.isDie) return character;
        listCharacter.Remove(character);
        return null;
    }
}
