using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextSmooth : MonoBehaviour {
	LinkedList<string> story;
	float scene_start;
	bool stop = false;
	string now_writing_text;
	float writing_speed = 100;
	void Start () {
		Time.timeScale = 0;
		scene_start = Time.time;
		GetComponent<Text>().text = "";

		story = new LinkedList<string>();
		/*
		story.AddLast ("Dark times were upon this world. Terror and despair pledged our lands. Earth, water and air were all divided into two. One - ruled by the cruel and mighty emperor Desaix. Other - taken over by ruthless king Berkut. Both rulers dispised eachother and seeked to conquer the lands that were not yet their's. Five years ago, the war finally broke out and majority of humankind was wiped out.");
		story.AddLast ("Now, even though the fights are not as intense, they can still change the outcome of war.");
		story.AddLast ("Jesse: Ahhhh... Captain, even if we managed to steal the intel we came here for, I fear that we won't make it back to the capital. Our ship is sinking at a rapid pace. ");
		story.AddLast ("Captain Loyd: Damn it. No information is worth it if we have to sacrifice our brothers.");
		story.AddLast ("Jesse: There's nothing you can do now. I'm sorry...");
		story.AddLast ("Captain Loyd: Keep your crying for later. We're not dead yet. You said our submarine was sinking, didn't you?");
		story.AddLast ("Jesse: Y-yes, I did, but...");
		story.AddLast ("Captain Loyd: Then put your shaking hands to use. We WILL try to get home!");
		story.AddLast ("Jesse: How in the cruel world do you suppose we do that?! Have you gone insane, Captain?!");
		story.AddLast ("Captain Loyd: Maybe... I have an idea and it might work if we hurry.");
		story.AddLast ("Jesse: Captain, with all due respect, I still don't think even the Legendary Loyd the Water Demon could pull it off.");
		story.AddLast ("Captain Loyd: That name brings back some dark memories. Nothing but pain comes with it.");
		story.AddLast ("Jesse: I'm sorry for mentioning, Captain.");
		story.AddLast ("Captain Loyd: Don't sweat it. But I think my long forgotten skills will be useful now.");
		story.AddLast ("Jesse: We believe in you, Captain. Tell me your strategy.");
		story.AddLast ("Captain Loyd: If we manage to take fuel from abandoned oil towers and food from passerby towns. We might also manage to recover some oxygen there as well. This way we can keep a stable amount of main resources that are our only hope.");
		story.AddLast ("Jesse: it is a possibility, but a very small one.");
		story.AddLast ("Captain Loyd: That's all I need.");
		story.AddLast ("Jesse: So i presume you will take the main controls captain?");
		story.AddLast ("Captain Loyd: Yea, I will take the wheel and sonar. It's hard to see in this god damned water. You go take the ship controls.");
		story.AddLast ("Jesse: Roger that, Captain Loyd. But... I haven't worked with them before. I have no clue how they work!!!");
		story.AddLast ("Captain Loyd: Don't worry. Just Listen. In the top right you can view our resources. Oxygen - it's amount regulates whether our ship sinks or rises. Food - without it me and crew can't concentrate, so everything works slower. Fuel - we use it to move or to charge up our inner battery. Battery - energy level inside it that is also used for movement. Armor - how damaged our ship is.");
		story.AddLast ("Jesse: All clear, but how about the controls?");
		story.AddLast ("Captain Loyd: in the bottom right you can see three swtiches. First one regulates speed. Second one regulates whether we use fuel or battery energy for traversing. Last one switches energy generation for our battery. Don't forget it also uses fuel.");
		story.AddLast ("Jesse: I understand.");
		story.AddLast ("Captain Loyd: I hope you do. Lastly, in the left bottom corner you can elevation meter that shows our distance from the ground. Keep an eye on that one.");
		story.AddLast ("Jesse: I think I got it Captain.");
		story.AddLast ("Captain Loyd: Perfect. Now, let's run from our graves. My beloved Lavaiathan will take us home tonight. ");
		*/
		now_writing_text = "Press spacebar to read the story.";
		StartCoroutine (Print ("Press spacebar to read the story."));

	}



	private IEnumerator Print(string s) {
		int n = 0;
		int t = 0;
		while (n < s.Length && !stop && s==now_writing_text) {
			if(t*writing_speed > n) {
				GetComponent<Text> ().text += s [n];
				n++;

			}
			t++;
			yield return null;
		}
		stop = true;
	}



	// Update is called once per frame
	void Update () {
		if (stop && Input.GetKeyDown("space")) {
			stop = false;
			GetComponent<Text>().text = "";
			if (story.First != null) {
				now_writing_text = story.First.Value;
				StartCoroutine (Print (story.First.Value));
				story.RemoveFirst ();
			} else {
				transform.parent.gameObject.SetActive(false);
				Time.timeScale = 1;
			}

		} 
	}


	void FixedUpdate() {
		if (Input.GetKeyDown("space")) {
			writing_speed = 0.2f;
		}
	}
}
