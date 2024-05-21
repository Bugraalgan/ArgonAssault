using UnityEngine;
public class PlayerControls : MonoBehaviour
{
    [SerializeField] float controlspeedX=1f;
    [SerializeField] float controlspeedY=1f;
    [SerializeField] float xRange=5f;
    [SerializeField] float yRange=5f;

    [SerializeField] float positionPitchFactor=-2f;
    [SerializeField] float controlFactor=-10f;
    [SerializeField] float positionYawFactor=2f;
    [SerializeField] float controlRollFactor=-20f;

    [SerializeField] GameObject[] lasers;

    float xThrow,yThrow;

    void Update()
    {
        if(Input.GetButton("Fire1")){
            ActiveLasers();
        }else{
            DeActiveLasers();
        }
        ProcessPosition();
        ProcessRotation();
    }
    void ActiveLasers(){
        foreach(GameObject laser in lasers){
            laser.SetActive(true);
        }

    }

    void DeActiveLasers(){
        foreach(GameObject laser in lasers){
            laser.SetActive(false);

        }

    }
   
    void ProcessRotation(){

        float pitchDueToPosition=transform.localPosition.y * yThrow;
        float pitchDueToThrow=positionPitchFactor * controlFactor;

        float pitch=pitchDueToPosition+pitchDueToThrow;
        float yaw=transform.localPosition.x * positionYawFactor;
        float roll=xThrow * controlRollFactor;
        transform.localRotation=Quaternion.Euler(pitch,yaw,roll);
     }
   
   
   
   
    void ProcessPosition(){
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");


        float xOffSet=xThrow * Time.deltaTime * controlspeedX;
        float rawXPos=transform.localPosition.x + xOffSet;
        float clampPosX = Mathf.Clamp(rawXPos,-xRange,xRange);

        float yOffSet=yThrow * Time.deltaTime * controlspeedY;
        float rawYPos=transform.localPosition.y + yOffSet;
        float clampPosY = Mathf.Clamp(rawYPos,-yRange,yRange);

        transform.localPosition = new Vector3(clampPosX,clampPosY,transform.localPosition.z);
    }


}