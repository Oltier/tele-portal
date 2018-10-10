// define the audio clips:
var bluePortal: AudioClip;
var orangePortal: AudioClip;
var cannotBeShot: AudioClip;

//Make sure it's the same as shoot.cs's delay

private var blue: AudioSource;
private var orange: AudioSource;
private var none: AudioSource;

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
        none = AddAudio(cannotBeShot,false,false,1);
    }

    function OnCollisionEnter(other : Collision)
        {
            if(this.gameObject.CompareTag("CanBeShot") && other.gameObject.CompareTag("BlueBullet"))
            {
                blue.Play();
            }
            else if(this.gameObject.CompareTag("CanBeShot") && other.gameObject.CompareTag("OrangeBullet"))
            {
                orange.Play();
            }
            else if(this.gameObject.CompareTag("CannotBeShot") && (other.gameObject.CompareTag("OrangeBullet") || other.gameObject.CompareTag("BlueBullet")))
                none.Play();
        }