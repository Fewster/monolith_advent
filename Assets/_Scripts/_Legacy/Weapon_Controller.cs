using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Controller : MonoBehaviour
{
    public List<GameObject> _weapons = new List<GameObject>();
    GameObject _weapon_equipped;
    
    public GameObject _default_weapon;

    void Start()
    {
        foreach (var weapon in _weapons)
        {
            Debug.Log($"Weapons Collected: {weapon.gameObject.name}");    
        }
    }

    void Update()
    {
        if(_weapon_equipped != null )
        {
            int input_code = Utilities.GetIntegerFromInput(Input.inputString);
            if(input_code < 0 )
            {
                return;
            }

            Debug.Log(input_code);

            if(input_code <= (_weapons.Count - 1) && input_code > -1)
            {
                UnequipWeapons();
                _weapon_equipped.SetActive(false);
			    _weapons[input_code].gameObject.SetActive(true);
            }
        }
        else
        {
            _weapon_equipped = _default_weapon;
            if (!_default_weapon.activeSelf)
            {
                _default_weapon.SetActive(true);
                _weapon_equipped = _default_weapon;
            }

            UnequipWeapons();
		}
    }

    void UnequipWeapons()
    {
		for (int i = 1; i < this.transform.childCount; i++)
		{
			this.gameObject.transform.GetChild(i).gameObject.SetActive(false);
		}
	}
}
