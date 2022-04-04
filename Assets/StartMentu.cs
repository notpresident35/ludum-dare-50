
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartMentu : MonoBehaviour
{
	public void loadMainscene()
	{
		SceneManager.LoadScene("Bryan");
	}
	public void quitGame()
	{
		Application.Quit();
	}

}
