using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Wind : MonoBehaviour {

	string CurrentWord;
	int LetterPosition = 0;
	float Speed =0;
	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		AdjustWordPosition();
		if(!GameObject.Find("Controls").GetComponent<YOGControls>().CrossedLast())
			transform.position -= new Vector3(Speed,0,0) * Time.deltaTime;
		else
			transform.position -= new Vector3(Speed,0,0) * Time.deltaTime * 4;
		if(transform.position.x <= GameObject.Find("RunningMan").transform.position.x)
		{
			LevelLoader.LoseLevel();
		}
	}
	
	public bool CheckNextLetter(char NextLetter)
	{
		if (char.ToLower(NextLetter) == char.ToLower(CurrentWord[LetterPosition]))
		{
			++LetterPosition;
			PushCharacter(NextLetter);
			
			if(LetterPosition == CurrentWord.Length)
			{
				return true;
			}
		}
		return false;
	}
	
	public void SetCurrentWord(string NewWord)
	{
		CurrentWord = NewWord;
		foreach (Transform child in transform)
		{
			foreach (Transform grandChild in child)
			{
				if(grandChild.name == "CurrentWord")
				{
					grandChild.GetComponent<Text>().text = NewWord;
				}
			}
		}
	}
	
	void AdjustWordPosition()
	{
		foreach (Transform child in transform)
		{
			foreach (Transform grandChild in child)
			{
				if(grandChild.name == "CurrentWord")
				{
					float PosX = 0;
					grandChild.GetComponent<Text>().transform.localPosition = new Vector3(PosX,0.75f, 0);
				}
			}
		}
	}
	
	void PushCharacter(char NextCharacter)
	{
		foreach (Transform child in transform)
		{
			foreach (Transform grandChild in child)
			{
				if(grandChild.name == "CurrentWord")
				{
					Text GCText = grandChild.GetComponent<Text>();
					string CorrectString = CurrentWord.Substring(0,LetterPosition);
					string RestOfString =  CurrentWord.Substring(LetterPosition);
					GCText.text = "<color=maroon>" + CorrectString + "</color><color=aqua>"+ RestOfString + "</color>";
				}
			}
		}
	}
	
	public void SetSpeed(float NewSpeed)
	{
		Speed = NewSpeed;
	}
	
	public void ResetWord()
	{
		foreach (Transform child in transform)
		{
			foreach (Transform grandChild in child)
			{
				if(grandChild.name == "CurrentWord")
				{
					LetterPosition = 0;
					Text GCText = grandChild.GetComponent<Text>();
					GCText.text =  "<color=aqua>"+ CurrentWord + "</color>";
				}
			}
		}
	}
}
