using UnityEngine;
using System.Collections;

public class Controler : MonoBehaviour {

    public delegate void RockThrowDel();
    public event RockThrowDel onRockThrow;

    public Rigidbody rock;
    public float jumpForce;
    public float walkSpeed;
    public float horizontalRotateSpeed;
    public float maxSpeed;

    public float minThrowStrenght;
    public float maxThrowStrenght;
    public float chargePerSeconds;
    public float rockMaxLifeSpan;

    public AudioClip jumpingSound;
    public AudioClip[] walkingSounds;
    public AudioSource playerSoundSource;

    public Transform spawnLocation;

    private bool canThrowRock = true;
    public bool CanThrowRock
    {
        set { canThrowRock = value; }
        get { return canThrowRock; }
    }

    private bool canJump = false;
    public bool CanJump
    {
        set { canJump = value; }
        get { return canJump; }
    }

    private bool canWalk = false;
    public bool CanWalk
    {
        set { canWalk = value; }
        get { return canWalk; }
    }

    public SpawnPlayer spawner;

    private bool makingSound = false;
    private Transform respawnLocation;
    public Transform RespawnLocation
    {
        get
        {
            spawner.InvokeSpawnEvent();
            return respawnLocation;
        }
        set 
        { 
            respawnLocation = value;
        }
    }

	// Update is called once per frame
	void Update () 
    {
        // Movement
        if (Input.GetKey(KeyCode.W) && rigidbody.velocity.magnitude < maxSpeed)
            rigidbody.AddForce(transform.forward * walkSpeed, ForceMode.VelocityChange);
        if (Input.GetKey(KeyCode.S) && rigidbody.velocity.magnitude < maxSpeed)
        {
            float speedModifier = walkSpeed;
            if (!canJump)
                speedModifier/=2;
            rigidbody.AddForce(transform.forward * -speedModifier, ForceMode.VelocityChange);
        }
        if (Input.GetKey(KeyCode.D) && rigidbody.velocity.magnitude < maxSpeed)
            rigidbody.AddForce(transform.right * walkSpeed, ForceMode.VelocityChange);
        if (Input.GetKey(KeyCode.A) && rigidbody.velocity.magnitude < maxSpeed)
            rigidbody.AddForce(transform.right * -walkSpeed, ForceMode.VelocityChange);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W))
        {
            if (!makingSound && canWalk)
                StartCoroutine(WalkingSound(walkSpeed));
        }

        // Throw
        if (Input.GetMouseButtonDown(0) && rock != null)
            StartCoroutine(ChargeThrow());

        // Rotate
        if(Input.GetAxis("Mouse X") != 0)
            transform.Rotate(0, Input.GetAxis("Mouse X") * horizontalRotateSpeed, 0, Space.Self);

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            canWalk = false;
            canJump = false;
            playerSoundSource.clip = jumpingSound;
            playerSoundSource.Play();
            rigidbody.AddForce(new Vector3(0, jumpForce, 0), ForceMode.VelocityChange);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LevelState.SetLevelState = Level.menu;
        }
	}

    IEnumerator WalkingSound(float speed)
    {
        makingSound = true;
        int selection = Random.Range(0, walkingSounds.Length - 1);

        playerSoundSource.clip = walkingSounds[selection];
        playerSoundSource.Play();

        yield return new WaitForSeconds(0.4f);
        makingSound = false;

    }



    IEnumerator ChargeThrow()
    {
        float force = minThrowStrenght;

        while(!Input.GetMouseButtonUp(0))
        {
            force += chargePerSeconds * Time.deltaTime;
            force = Mathf.Min(force, maxThrowStrenght);
            yield return null;
        }
        canThrowRock = false;
        onRockThrow.Invoke();
        if (rock != null)
        {
            rock.isKinematic = false;
            rock.gameObject.transform.parent = null;
            Destroy(rock, rockMaxLifeSpan);
            rock.AddForce(rock.gameObject.transform.forward * force, ForceMode.VelocityChange);
            rock = null;
        }
    }
}
