// define the audio clips:
var bluePortal: AudioClip;
var orangePortal: AudioClip;

//Make sure it's the same as shoot.cs's delay
var ShootDelay : float;
private var ShootTime : float;

private var blue: AudioSource;
private var orange: AudioSource;

function AddAudio(clip:AudioClip, loop: boolean, playAwake: boolean, vol: float): AudioSource {
    var newAudio = gameObject.AddComponent(AudioSource);
    newAudio.clip = clip;
    newAudio.loop = loop;
    newAudio.playOnAwake = playAwake;
    newAudio.volume = vol;
    return newAudio;
}

    function Awake(){
        // add the necessary AudioSources:
        blue = AddAudio(bluePortal, false, false, 1);
        orange = AddAudio(orangePortal, false, false, 1);
    }

    function Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (Time.time >= ShootTime)
            {
                blue.Play();
                ShootTime = Time.time + ShootDelay;
            }
        }
        if(Input.GetButtonDown("Fire2"))
        {
            if (Time.time >= ShootTime)
            {
                orange.Play();
                ShootTime = Time.time + ShootDelay;
            }
        }
    }