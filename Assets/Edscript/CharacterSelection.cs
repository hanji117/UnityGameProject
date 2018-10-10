using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour 
{
	private GameObject[] characterList;
	private int index;//by default index is 0
	private void Awake()
	{


		index = PlayerPrefs.GetInt ("CharacterSelected");

		characterList = new GameObject[transform.childCount];

		//fill the array with our models
		for (int i = 0; i < transform.childCount; i++) 
			characterList [i] = transform.GetChild(i).gameObject;
		
			//We toggle off their renderer so we don't see them anymore
			foreach (GameObject go in characterList) 
				go.SetActive (false);
		
			//We toggle on the selected character
			if (characterList [index])
				characterList [index].SetActive (true);
		

	}

	public void ToggleLeft() 
	{
		//Toggle off the current model
		characterList[index].SetActive(false);

		index--;//index -= 1; index = index -1;
		if (index < 0)
			index = characterList.Length - 1;


		//Toggle on the new model
		characterList[index].SetActive(true);
	}
	

	public void ToggleRight() 
	{
		//Toggle off the current model
		characterList[index].SetActive(false);

		index++;//index
		if (index == characterList.Length)
			index = 0;


		//Toggle on the new model
		characterList[index].SetActive(true);
	}
		
	void Update()
	{
		//characterList [index].transform.Rotate (0, 1.5f, 0);

	}

	public void ConfirmButton()
	{
		PlayerPrefs.SetInt ("CharacterSelected", index);
		SceneManager.LoadScene ("Town");
	}

}
