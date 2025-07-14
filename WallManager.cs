using UnityEngine;

public class WallManager : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        if (PlayerPrefs.GetInt("MiniGameSuccess") == 1)
        {
            string wallID = PlayerPrefs.GetString("DeadEndWallID", "");

            if (!string.IsNullOrEmpty(wallID))
            {
                GameObject wall = GameObject.Find(wallID);
                if (wall != null)
                {
                    wall.SetActive(false); // Collapse only this wall
                    Debug.Log("Collapsed wall: " + wallID);
                }
            }

            // Move player to respawn position
            float x = PlayerPrefs.GetFloat("RespawnX");
            float y = PlayerPrefs.GetFloat("RespawnY");
            float z = PlayerPrefs.GetFloat("RespawnZ");
            player.transform.position = new Vector3(x, y, z);

            // Clear flags
            PlayerPrefs.DeleteKey("MiniGameSuccess");
            PlayerPrefs.DeleteKey("DeadEndWallID");
        }
    }
}