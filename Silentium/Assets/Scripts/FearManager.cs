using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FearManager : MonoBehaviour {
	public float InitialFearLevel;
	public float FearDecreaseRate;

	private float _fearLevel; //0-1
	private float _lastTimeIncreased;
	public List<FearMeter> _fearMeters;

	private void Start () {
		_fearLevel = InitialFearLevel;
		_fearMeters = GetComponentsInChildren<FearMeter> ().ToList();
		UpdateLastTimeIncreased ();
	}
	
	void Update () {
		if(Time.time - _lastTimeIncreased > 5 && _fearLevel>0) 
			AddToFearLevel (-FearDecreaseRate * Time.deltaTime);
		
		_fearMeters.ForEach(meter => meter.Display(_fearLevel));
        print(_fearLevel);
	}

	private void AddToFearLevel(float diff) { 
		if (diff > 0) {
			UpdateLastTimeIncreased ();
		}

        //_fearLevel = Mathf.Clamp01 (_fearLevel + diff);
        _fearLevel += diff / 150;
    }

	private void UpdateLastTimeIncreased() {
		_lastTimeIncreased = Time.time;
	}

	public void IncreaseForHearingWalkingSounds() {
		AddToFearLevel (1);
	}

	public void IncreaseForObstacleSounds() {
		AddToFearLevel (2);
	}

	public void IncreaseForBeingNoticed() {
		AddToFearLevel (5);
	}

	public void IncreaseForFindingDeadBody() {
		AddToFearLevel (15);
	}

	public void IncreaseForKilling() {
		AddToFearLevel (20);
	}
}