using UnityEngine;
using System.Collections.Generic;

public sealed class Bullet : MonoBehaviour
{
	GameObject cam;

	float rotZ;
	float rotacao;

    public Rigidbody2D bulletRigidbody;
	public GameObject explosion;

    public Vector2 impulse;

	public Vector3 offSet;

	public List<AudioClip> se = new List<AudioClip>();
	public GameObject sound;

    private void Start()
    {
        bulletRigidbody.AddForce(impulse, ForceMode2D.Impulse);
		cam = GameObject.Find ("Camera");
		rotZ = Random.Range(0, 360);
		rotacao = Random.Range (-10, 10);
    }

	void Update()
	{
		rotZ += rotacao;

		transform.localEulerAngles = new Vector3 (0f, 0f, rotZ);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
		if (collision.gameObject.layer == 11) 
		{
			GameObject e = Instantiate (explosion, transform.position + offSet, Quaternion.identity);
			e.GetComponent<Animator> ().SetInteger("explosionId", 1);
			e.GetComponent<Transform> ().localScale = new Vector3 (4, 4, 4);
			e.GetComponent<DestroyScript> ().Tempo = 0.5f;
			GameObject s = Instantiate(sound, transform.position, Quaternion.identity);
			s.GetComponent<SoundSetup>().soundEffect = se[0];
			s.GetComponent<SoundSetup>().setup = true;
		}
		if (collision.gameObject.layer == 12) 
		{
			Vector3 InstPosition = new Vector3 (
				(collision.transform.position.x + transform.position.x) / 2,
				(collision.transform.position.y + transform.position.y) / 2,
				(collision.transform.position.z + transform.position.z) / 2);

			GameObject e = Instantiate (explosion, InstPosition, Quaternion.identity);
			e.GetComponent<Animator> ().SetInteger("explosionId", 2);
			e.GetComponent<DestroyScript> ().Tempo = 0.6f;
			GameObject s = Instantiate(sound, transform.position, Quaternion.identity);
			s.GetComponent<SoundSetup>().soundEffect = se[0];
			s.GetComponent<SoundSetup>().setup = true;
		}

		if (collision.gameObject.layer == 13) 
		{
			GameObject e = Instantiate (explosion, transform.position, Quaternion.identity);
			e.GetComponent<Animator> ().SetInteger("explosionId", 3);
			e.GetComponent<Transform> ().localScale = new Vector3 (6, 6, 6);
			e.GetComponent<DestroyScript> ().Tempo = 0.8f;
			GameObject s = Instantiate(sound, transform.position, Quaternion.identity);
			s.GetComponent<SoundSetup>().soundEffect = se[0];
			s.GetComponent<SoundSetup>().setup = true;
		}
		cam.GetComponent<Shake>().Shakes (0.3f, 0.5f);
		cam.GetComponent<Shake>().FreezeFrame();
        Destroy(gameObject);
    }
}
