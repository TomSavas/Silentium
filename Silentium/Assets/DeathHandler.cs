using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour {
	public List<AudioClip> screams;
	public ParticleSystem screamSoundParticles;

	private AudioSource _audioSource;

	private void Start() {
		_audioSource = GetComponent<AudioSource> ();
	}

	public void ExecuteDeathActions() {
		Scream ();
		EmitSoundParticles ();
		Destroy (this.gameObject.transform.parent.gameObject.GetComponent<CivilianAI> ());
		Destroy (this.gameObject.transform.parent.gameObject.GetComponent<SoundTrigger> ());
		Destroy (this.gameObject.transform.parent.gameObject.GetComponent<Unit> ());
		Destroy (this.gameObject.transform.parent.gameObject, _audioSource.clip.length);
	}

	private void Scream() {
		_audioSource.clip = screams [Random.Range (0, screams.Count - 1)];
		_audioSource.Play ();
	}
		
	private void EmitSoundParticles() {
		gameObject.transform.parent.gameObject.tag = "Untagged";
		gameObject.transform.parent.gameObject.layer = 0;
		var particleSystem = Instantiate (screamSoundParticles, transform);
		StartCoroutine (EmitMultipleWaves (particleSystem, Random.Range(0, 5)));
	}

	private IEnumerator EmitMultipleWaves(ParticleSystem particleSystem, int waveCount) {
		int wavesEmitted = 0;

		while (wavesEmitted++ < waveCount) {
			Debug.Log ("emit");
			particleSystem.Emit(300);
			yield return new WaitForSeconds (Random.Range (0.1f, 0.3f));
		}
	}
}
