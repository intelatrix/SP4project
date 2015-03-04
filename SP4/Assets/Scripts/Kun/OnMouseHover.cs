using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OnMouseHover : MonoBehaviour {

	public GameObject title;
	public GameObject content;
	public GameObject content2;

	void OnMouseOver() {
		if (name == "dentist") {
			title.GetComponent<Text> ().text = "Dental Clinic";
			content.GetComponent<Text> ().text = "Cost: SGD$" + GameObject.Find ("elderly").GetComponent<ElderlySetting> ().costOfEvent [0].ToString ();
			content2.GetComponent<Text> ().text = "Pioneer Discount: " + GameObject.Find ("elderly").GetComponent<ElderlySetting> ().eventDiscount [0].ToString () + "% off";
		} else if (name == "hospital") {
			title.GetComponent<Text> ().text = "Hospital";
			content.GetComponent<Text> ().text = "Cost: SGD$" + GameObject.Find ("elderly").GetComponent<ElderlySetting> ().costOfEvent [1].ToString ();
			content2.GetComponent<Text> ().text = "Pioneer Discount: " + GameObject.Find ("elderly").GetComponent<ElderlySetting> ().eventDiscount [1].ToString () + "% off";
		} else if (name == "shopping_mart") {
			title.GetComponent<Text> ().text = "Mart";
			content.GetComponent<Text> ().text = "Cost: SGD$" + GameObject.Find ("elderly").GetComponent<ElderlySetting> ().costOfEvent [1].ToString ();
			content2.GetComponent<Text> ().text = "Pioneer Discount: " + GameObject.Find ("elderly").GetComponent<ElderlySetting> ().eventDiscount [1].ToString () + "% off";
		} else if (name == "church") {
			title.GetComponent<Text> ().text = "Church";
			content.GetComponent<Text> ().text = "Cost: SGD$" + GameObject.Find ("elderly").GetComponent<ElderlySetting> ().costOfEvent [1].ToString ();
			content2.GetComponent<Text> ().text = "Pioneer Discount: " + GameObject.Find ("elderly").GetComponent<ElderlySetting> ().eventDiscount [1].ToString () + "% off";
		}   else if (name == "Car") {
			title.GetComponent<Text> ().text = "How to Cheat?";
			content.GetComponent<Text> ().text = "Actual Cost: SGD$" + GameObject.Find ("elderly").GetComponent<ElderlySetting> ().actualExpense.ToString ();
			content2.GetComponent<Text> ().text = "Estimated Spending: SGD$" + GameObject.Find ("elderly").GetComponent<ElderlySetting> ().estimatedExpense.ToString ();
		}
	}
}
