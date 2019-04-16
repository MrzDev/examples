using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayTimeRewards : MonoBehaviour
{
    public static Int PlayedTime;
    public static Int RewardTime;
    public Button TimeReward;
    public GameObject TimeLeftText;
    public Int TimeLeft;
    public Int Hours;
    public Int Minutes;
    public Int Seconds;


    // Start is called before the first frame update
    void Start()
    {
        Minutes = 0;
        Seconds = 0;
        Hours = 0;
        if (RewardTime == 0) RewardTime = 300;
        InvokeRepeating("PlayTime", 0, 1);//the played time +1 every second
    }

    // Update is called once per frame
    void Update()
    {
        if (RewardTime == 0) RewardTime = 300; //first reward time after 5 minutes

        if (PlayedTime >= RewardTime)//when the countdown is over.. button is interactable
        {
            TimeReward.interactable = true;
        }
        if (PlayedTime < RewardTime) //when the countdown is still running.. button isn't interactable
        {
            TimeReward.interactable = false;
        }

        TimeLeft = RewardTime - PlayedTime;//get the time that is left
        if (TimeLeft >= 0)//format the seconds that are left into seconds/hours/minutes
        {
            if (TimeLeft < 60)
            {
                Seconds = TimeLeft;
                Minutes = 0;
                Hours = 0;
            }
            if (TimeLeft >= 60)
            {
                Minutes = TimeLeft / 60;
                if (TimeLeft % 60 != 0)
                {
                    Seconds = TimeLeft % 60;
                }
                if (TimeLeft % 60 == 0)
                {
                    Seconds = 0;
                }
                if (Minutes >= 60)
                {
                    Hours = Minutes / 60;
                    Minutes = Minutes % 60;
                }
            }
        }
        if (TimeLeft < 0)
        {
            Seconds = 0;
            Minutes = 0;
            Hours = 0;
        }
        TimeLeftText.GetComponent<TextMeshProUGUI>().text = "Next Reward in " + Hours.ToString("00") + ":" + Minutes.ToString("00") + ":" + Seconds.ToString("00");
		//Print the Countdown in a TextMesh Pro Text Field
		}

    public void GetReward() // when the Player clicks the Reward button
    {
        if (PlayedTime >= RewardTime)
        {
            //Reward the Player
        }

        

    public void PlayTime()//incrementing the counter +1
    {
        PlayedTime++;
    }
}
