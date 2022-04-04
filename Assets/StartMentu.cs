
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartMentu : MonoBehaviour
{
	public void loadMainscene()
	{
		SceneManager.LoadScene("Main");
	}
	public void quitGame()
	{
		Application.Quit();
	}

}
