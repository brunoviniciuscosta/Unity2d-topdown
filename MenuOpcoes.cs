using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOpcoes : MonoBehaviour
{
    public void MenuPrincipal()
    {
        SceneManager.LoadScene("Menu");
    }
    public void SetFacil()
    {
        GameDifficulty.difficulty = GameDifficulty.Difficulties.Facil;
    }

    public void SetMedio()
    {
        GameDifficulty.difficulty = GameDifficulty.Difficulties.Medio;
    }

    public void SetDificil()
    {
        GameDifficulty.difficulty = GameDifficulty.Difficulties.Dificil;
    }

    public void SetImpossivel()
    {
        GameDifficulty.difficulty = GameDifficulty.Difficulties.Impossivel;
    }
}
