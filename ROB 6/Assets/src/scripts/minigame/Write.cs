using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * PauseMenu.
 *
 * @author Rémi Wickuler
 * @author Julien Delane
 * @version 17.12.11
 * @since 17.10.11
 */
public class Write : MonoBehaviour
{
    /**
     * The input field.
     *
     * @unityParam
     * @since 17.10.11
     */
    [SerializeField]
	private InputField inputField;

    /**
     * The code of the player.
     *
     * @unityParam
     * @since 17.12.11
     */
    private string code;

    /**
     * Say if the player is compiling or not.
     *
     * @unityParam
     * @since 17.12.11
     */
    private bool isCompiling = false;

    /**
     * three Dictionary used to store player's int variables, char varibales and string variables
     *
     * @unityParam
     * @since 17.12.11
     */
    private Dictionary<string, int> hisInt = new Dictionary<string, int>();
    private Dictionary<string, char> hisChar = new Dictionary<string, char>();
    private Dictionary<string, string> hisString = new Dictionary<string, string>();


    /**
     * Init the input field.
     *
     * @since 17.10.11
     */
	private void Start()
    {
		inputField.ActivateInputField();
	}

    void Update()
    {
        if (isCompiling == true)
        {
            if (inputField.IsActive() == true)
                inputField.DeactivateInputField();
        }
        else if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Return) && isCompiling == false)
        {
            isCompiling = true;
            code = GetComponentInChildren<Text>().text;
            compileIt();
        }
    }

    int getNbLines()
    {
        int i = 0;
        foreach (char c in code)
        {
            if (c == '\n')
                i++;
        }
        return (i + 1);
    }

    int getNbChar(int i)
    {
        while (i <= code.Length)
        {
            if (code[i] == '\n')
                return (i);
        }
        return (i);
    }


    void compileIt()
    {
        char[][] map;
        int nbLine;
        int sum = 0;
        int i = 0;

        nbLine = getNbLines();
        map = new char[nbLine][];
        while (i <= nbLine)
        {
            int j = 0;
            map[i] = new char[getNbChar(sum)];
            while (sum <= code.Length && code[sum] != '\n')
            {
                map[i][j] = code[sum];
                j++;
                sum++;
            }
            i++;
        }
    }
}
