using UnityEngine;

public sealed class Cannon : MonoBehaviour
{
	public GameObject laser;
	public GameObject sound;
	public AudioClip se;

    public Bullet bulletPrefab;
    public float instantiateOffset = 10.0f;
    public float shootImpulse = 30.0f;

    public Vector3 startingDirection = Vector3.left;

	public Shake mexe;

	Vector3 rot;

	string weapow;

	void Start()
	{
		weapow = "bomb";
	}

    private void Update()
    {
		switch (Input.inputString) {
		case "1":
			weapow = "bomb";
			break;
		case "2":
			weapow = "laser";
			break;
		}

		Debug.Log (weapow);

        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 mouseDirection = Input.mousePosition - screenPosition;
        mouseDirection.z = 0.0f;

        var rotation = Quaternion.FromToRotation(startingDirection, mouseDirection);
        transform.localRotation = rotation;

		if (weapow == "bomb") {
			laser.SetActive (false);
			if (Input.GetMouseButtonDown (0)) {
				mexe.Shakes (0.1f, 0.2f);

				Vector2 direction = ((Vector2)mouseDirection).normalized;
				Vector3 position = transform.position + (Vector3)direction * instantiateOffset;

				var bullet = Instantiate (bulletPrefab.gameObject, position, Quaternion.identity).GetComponent<Bullet> ();
				bullet.impulse = direction * shootImpulse;
			}
		}
		if (weapow == "laser") {
			if (Input.GetMouseButton (0)) {
				mexe.Shakes (0.5f, 0.1f);
				laserSoundSpawn ();
				laser.SetActive (true);
			}
			if (Input.GetMouseButtonUp (0)) {
				laser.SetActive (false);
			}
		}
    }

	float time;

	void laserSoundSpawn()
	{
		time += 1f * Time.deltaTime;

		if (time > 1) {
			GameObject s = Instantiate (sound, transform.position, Quaternion.identity);
			s.GetComponent<SoundSetup> ().soundEffect = se;
			s.GetComponent<SoundSetup> ().setup = true;
			time = 0f;
		}
	}
}
