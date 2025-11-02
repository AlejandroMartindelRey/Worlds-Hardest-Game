using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
   
   public void OnPlayButtonClicked()
   {
      SceneManager.LoadScene("Level_1");
      SceneManager.LoadScene(1);
   }

   public void OnExitButtonClicked()
   {
      //Only Works in the build of the game.
      Application.Quit();
   }
}
