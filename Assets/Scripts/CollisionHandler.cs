using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField]  float loadDeley = 2f;

     void OnTriggerEnter(Collider other)
     {
         StartCrashSequence();
     }

      void StartCrashSequence()
      {
          GetComponent<PlayerControls>().enabled=false;
          Invoke("ReloadLevel()",loadDeley);
      }

      void ReloadLevel()
      {
          int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
          SceneManager.LoadScene(currentSceneIndex);
      }
}
